using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Sketch
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        private class LockState
        {
            public VIZCore3DX.NET.NavigationDragMode NavigationDragMode;
            public bool ShortcutEnabled;
            public VIZCore3DX.NET.Data.InputPreset InputPreset;
            public List<VIZCore3DX.NET.Data.InputBindingItem> InputBindings;
            public bool ViewCubeEnabled;
            public bool ViewToolbarEnabled;
            public bool RibbonMode;
            public readonly Dictionary<string, bool> RibbonTabs = new Dictionary<string, bool>();
            public readonly Dictionary<VIZCore3DX.NET.Data.ToolbarKind, bool> Toolbars = new Dictionary<VIZCore3DX.NET.Data.ToolbarKind, bool>();
        }

        private LockState lockState;
        private bool isRefreshingItems = false;

        // 카메라 이동·회전·확대/축소 등 뷰를 바꾸는 입력 동작
        private static readonly VIZCore3DX.NET.Data.InputAction[] CameraActions =
        {
            VIZCore3DX.NET.Data.InputAction.Orbit,
            VIZCore3DX.NET.Data.InputAction.Pan,
            VIZCore3DX.NET.Data.InputAction.ZoomDrag,
            VIZCore3DX.NET.Data.InputAction.Roll,
            VIZCore3DX.NET.Data.InputAction.LookAround,
            VIZCore3DX.NET.Data.InputAction.ZoomWheel,
            VIZCore3DX.NET.Data.InputAction.Tilt,
            VIZCore3DX.NET.Data.InputAction.CenterViewAtCursor,
            VIZCore3DX.NET.Data.InputAction.FitAtCursor,
            VIZCore3DX.NET.Data.InputAction.SetPivotAtCursor
        };

        public FrmMain()
        {
            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            InitializeComponent();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            pnlViewHost.Controls.Add(vizcore3dx);
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================

            // 라이선스 파일을 통한 인증
            //VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            //VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("127.0.0.1", 8901);
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("127.0.0.1", 8901);

            // ================================================================
            // License
            // ================================================================
            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeSketchUI();
        }

        private void InitializeSketchUI()
        {
            List<VIZCore3DX.NET.Data.SketchType> sketchTypes = new List<VIZCore3DX.NET.Data.SketchType>();
            foreach (VIZCore3DX.NET.Data.SketchType type in Enum.GetValues(typeof(VIZCore3DX.NET.Data.SketchType)))
            {
                if (type != VIZCore3DX.NET.Data.SketchType.Unknown && type != VIZCore3DX.NET.Data.SketchType.Text)
                    sketchTypes.Add(type);
            }
            cmbSketchType.DataSource = sketchTypes;

            chkIsContinuousDrawing.Checked = vizcore3dx.Sketch.IsContinuousDrawing;

            pgStyle.SelectedObject = vizcore3dx.Sketch.GetStyle();

            btnLockCamera.Enabled = true;
            btnUnlockCamera.Enabled = false;
            SetSketchGroupsEnabled(false);

            RefreshItems();
            tmrItems.Start();
        }

        private void btnLockCamera_Click(object sender, EventArgs e)
        {
            if (lockState != null)
                return;

            LockState state = new LockState();

            state.NavigationDragMode = vizcore3dx.View.NavigationDragMode;
            state.ShortcutEnabled = vizcore3dx.Shortcuts.Enable;

            // 현재 입력 체계를 보관하고, 카메라를 움직이는 마우스 동작의 바인딩을 해제
            state.InputPreset = vizcore3dx.Input.CurrentPreset;
            state.InputBindings = vizcore3dx.Input.GetCustomBindings();

            List<VIZCore3DX.NET.Data.InputBindingItem> bindings = vizcore3dx.Input.GetCustomBindings();
            foreach (VIZCore3DX.NET.Data.InputBindingItem item in bindings)
            {
                if (Array.IndexOf(CameraActions, item.Action) >= 0)
                    item.Assigned = false;
            }
            vizcore3dx.Input.ApplyCustomBindings(bindings);

            // 뷰 큐브와 뷰 화면 안의 뷰 툴바도 사용하지 못하게 함
            state.ViewCubeEnabled = vizcore3dx.ViewCube.Enable;
            vizcore3dx.ViewCube.Enable = false;

            state.ViewToolbarEnabled = vizcore3dx.View.Toolbar.Enable;
            vizcore3dx.View.Toolbar.Enable = false;

            // 리본(또는 툴바)을 모두 숨김
            HideRibbonAndToolbars(state);

            vizcore3dx.View.NavigationDragMode = VIZCore3DX.NET.NavigationDragMode.NONE;
            vizcore3dx.Shortcuts.Enable = false;

            lockState = state;

            btnLockCamera.Enabled = false;
            btnUnlockCamera.Enabled = true;
            SetSketchGroupsEnabled(true);
        }

        private void btnUnlockCamera_Click(object sender, EventArgs e)
        {
            if (lockState == null)
                return;

            LockState state = lockState;

            vizcore3dx.View.NavigationDragMode = state.NavigationDragMode;
            vizcore3dx.Shortcuts.Enable = state.ShortcutEnabled;

            // 잠금 전 입력 체계로 복원
            if (state.InputPreset == VIZCore3DX.NET.Data.InputPreset.Custom && state.InputBindings != null)
                vizcore3dx.Input.ApplyCustomBindings(state.InputBindings);
            else
                vizcore3dx.Input.ApplyPreset(state.InputPreset);

            vizcore3dx.ViewCube.Enable = state.ViewCubeEnabled;
            vizcore3dx.View.Toolbar.Enable = state.ViewToolbarEnabled;

            // 숨겼던 리본(또는 툴바)을 다시 표시
            RestoreRibbonAndToolbars(state);

            lockState = null;

            btnLockCamera.Enabled = true;
            btnUnlockCamera.Enabled = false;
            SetSketchGroupsEnabled(false);
        }

        // 스케치는 카메라를 고정한 상태에서만 그릴 수 있음 (목록/삭제 그룹은 항상 사용)
        private void SetSketchGroupsEnabled(bool enabled)
        {
            groupBoxSettings.Enabled = enabled;
            groupBoxCreate.Enabled = enabled;
            groupBoxText.Enabled = enabled;
            groupBoxStyle.Enabled = enabled;
        }

        // 리본과 모든 툴바를 숨기고 이전 표시 상태를 보관 (리본 모드는 잠시 꺼서 리본 영역까지 숨김)
        private void HideRibbonAndToolbars(LockState state)
        {
            state.RibbonMode = vizcore3dx.RibbonMode;

            if (state.RibbonMode)
            {
                foreach (string tab in vizcore3dx.Ribbon.GetTabNames())
                    state.RibbonTabs[tab] = vizcore3dx.Ribbon.GetTabVisible(tab);
            }

            foreach (VIZCore3DX.NET.Data.ToolbarKind kind in Enum.GetValues(typeof(VIZCore3DX.NET.Data.ToolbarKind)))
                state.Toolbars[kind] = vizcore3dx.Toolbar.GetVisible(kind);

            vizcore3dx.RibbonMode = false;

            foreach (VIZCore3DX.NET.Data.ToolbarKind kind in state.Toolbars.Keys)
                vizcore3dx.Toolbar.SetVisible(kind, false);
        }

        private void RestoreRibbonAndToolbars(LockState state)
        {
            foreach (KeyValuePair<VIZCore3DX.NET.Data.ToolbarKind, bool> toolbar in state.Toolbars)
                vizcore3dx.Toolbar.SetVisible(toolbar.Key, toolbar.Value);

            vizcore3dx.RibbonMode = state.RibbonMode;

            foreach (KeyValuePair<string, bool> tab in state.RibbonTabs)
                vizcore3dx.Ribbon.SetTabVisible(tab.Key, tab.Value);
        }

        private void chkIsContinuousDrawing_CheckedChanged(object sender, EventArgs e)
        {
            if (vizcore3dx.Sketch.IsContinuousDrawing == chkIsContinuousDrawing.Checked)
                return;

            vizcore3dx.Sketch.IsContinuousDrawing = chkIsContinuousDrawing.Checked;
        }

        private void chkHighlightable_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.Sketch.SetHighlightable(chkHighlightable.Checked);
        }

        private void btnCreateSketch_Click(object sender, EventArgs e)
        {
            if (cmbSketchType.SelectedItem == null)
                return;

            VIZCore3DX.NET.Data.SketchType selectedType = (VIZCore3DX.NET.Data.SketchType)cmbSketchType.SelectedItem;

            vizcore3dx.Sketch.CreateSketch(selectedType);
        }

        private void btnCreateTextSketch_Click(object sender, EventArgs e)
        {
            string textToDraw = txtSketchText.Text.Trim();

            if (string.IsNullOrEmpty(textToDraw))
            {
                MessageBox.Show("생성할 문자를 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vizcore3dx.Sketch.CreateTextSketch(textToDraw);
        }

        private void btnShowSketchTextDialog_Click(object sender, EventArgs e)
        {
            vizcore3dx.Sketch.ShowSketchTextDialog();
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            vizcore3dx.Sketch.DeleteSelected();
        }

        private void btnDeleteBox_Click(object sender, EventArgs e)
        {
            vizcore3dx.Sketch.DeleteBox();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            vizcore3dx.Sketch.DeleteAll();
        }

        private void btnGetStyle_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.SketchStyle style = vizcore3dx.Sketch.GetStyle();

            if (style != null)
                pgStyle.SelectedObject = style;
        }

        private void pgStyle_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            VIZCore3DX.NET.Data.SketchStyle style = pgStyle.SelectedObject as VIZCore3DX.NET.Data.SketchStyle;

            if (style != null)
                vizcore3dx.Sketch.SetStyle(style);
        }

        private void btnShowSketchStyleDialog_Click(object sender, EventArgs e)
        {
            vizcore3dx.Sketch.ShowSketchStyleDialog();

            pgStyle.SelectedObject = vizcore3dx.Sketch.GetStyle();
        }

        private void tmrItems_Tick(object sender, EventArgs e)
        {
            // DLL 쪽에서 바뀐 값을 토글에 반영 (핸들러는 같은 값이면 다시 설정하지 않음)
            if (chkIsContinuousDrawing.Checked != vizcore3dx.Sketch.IsContinuousDrawing)
                chkIsContinuousDrawing.Checked = vizcore3dx.Sketch.IsContinuousDrawing;

            // 카메라 시점이 바뀌면 스케치와 스냅샷을 전체 삭제 (이전 카메라는 타이머 Tag 에 보관)
            VIZCore3DX.NET.Data.CameraData camera = vizcore3dx.View.GetCameraData();
            VIZCore3DX.NET.Data.CameraData lastCamera = tmrItems.Tag as VIZCore3DX.NET.Data.CameraData;
            tmrItems.Tag = camera;

            if (lastCamera != null && IsCameraChanged(lastCamera, camera))
            {
                vizcore3dx.Sketch.DeleteAll();
                vizcore3dx.Snapshot.Clear();
            }

            RefreshItems();
        }

        private static bool IsCameraChanged(VIZCore3DX.NET.Data.CameraData a, VIZCore3DX.NET.Data.CameraData b)
        {
            return IsVertexChanged(a.EyePosition, b.EyePosition)
                || IsVertexChanged(a.CameraDirection, b.CameraDirection)
                || IsVertexChanged(a.UpDirection, b.UpDirection)
                || Math.Abs(a.Zoom - b.Zoom) > 1e-4f;
        }

        private static bool IsVertexChanged(VIZCore3DX.NET.Data.Vertex3D a, VIZCore3DX.NET.Data.Vertex3D b)
        {
            return Math.Abs(a.X - b.X) > 1e-3f || Math.Abs(a.Y - b.Y) > 1e-3f || Math.Abs(a.Z - b.Z) > 1e-3f;
        }

        // 스케치 항목 목록을 조회해 표에 표시 (변경이 있을 때만 갱신)
        private void RefreshItems()
        {
            List<VIZCore3DX.NET.Data.SketchItem> items = new List<VIZCore3DX.NET.Data.SketchItem>();

            foreach (VIZCore3DX.NET.Data.SketchItem item in vizcore3dx.Sketch.GetItems())
            {
                if (item != null)
                    items.Add(item);
            }

            bool changed = items.Count != dgvItems.Rows.Count;

            for (int i = 0; changed == false && i < items.Count; i++)
            {
                DataGridViewRow row = dgvItems.Rows[i];

                changed = (string)row.Cells[colType.Index].Value != items[i].Type.ToString()
                    || (bool)row.Cells[colSelected.Index].Value != items[i].IsSelected
                    || (bool)row.Cells[colHighlighted.Index].Value != items[i].IsHighlighted;
            }

            // 표시 중인 항목과 같은 순서로 보관해 삭제 때 인덱스가 어긋나지 않게 함
            dgvItems.Tag = items;

            if (changed == false)
                return;

            List<int> selectedRows = new List<int>();
            foreach (DataGridViewRow row in dgvItems.SelectedRows)
                selectedRows.Add(row.Index);

            isRefreshingItems = true;

            dgvItems.Rows.Clear();

            for (int i = 0; i < items.Count; i++)
                dgvItems.Rows.Add(i + 1, items[i].Type.ToString(), items[i].IsSelected, items[i].IsHighlighted);

            isRefreshingItems = false;

            dgvItems.ClearSelection();
            foreach (int index in selectedRows)
            {
                if (index < dgvItems.Rows.Count)
                    dgvItems.Rows[index].Selected = true;
            }
        }

        private void dgvItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // 체크박스를 누르는 즉시 값 변경으로 처리
            if (dgvItems.IsCurrentCellDirty)
                dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isRefreshingItems || e.RowIndex < 0)
                return;

            List<VIZCore3DX.NET.Data.SketchItem> items = dgvItems.Tag as List<VIZCore3DX.NET.Data.SketchItem>;

            if (items == null || e.RowIndex >= items.Count)
                return;

            VIZCore3DX.NET.Data.SketchItem item = items[e.RowIndex];

            if (item.IsValid == false || item.IsDeleted)
                return;

            bool value = (bool)dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            if (e.ColumnIndex == colSelected.Index)
                item.IsSelected = value;
            else if (e.ColumnIndex == colHighlighted.Index)
                item.IsHighlighted = value;
            else
                return;

            RefreshItems();
        }

        private void btnDeleteListSelected_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.SketchItem> items = dgvItems.Tag as List<VIZCore3DX.NET.Data.SketchItem> ?? new List<VIZCore3DX.NET.Data.SketchItem>();

            List<VIZCore3DX.NET.Data.SketchItem> selected = new List<VIZCore3DX.NET.Data.SketchItem>();

            foreach (DataGridViewRow row in dgvItems.SelectedRows)
            {
                int index = row.Index;

                if (index < 0 || index >= items.Count) continue;

                // 이미 삭제된 항목을 Delete 에 넘기면 AccessViolation 이 발생하므로 제외
                if (items[index].IsValid == false || items[index].IsDeleted) continue;

                selected.Add(items[index]);
            }

            if (selected.Count == 0)
            {
                MessageBox.Show("삭제할 항목을 목록에서 선택해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vizcore3dx.Sketch.Delete(selected);

            ShowLastOperationStatus();
            RefreshItems();
        }

        private void ShowLastOperationStatus()
        {
            VIZCore3DX.NET.Data.OperationStatus status = vizcore3dx.Sketch.LastOperationStatus;

            lblLastOperationStatus.Text = string.Format("마지막 상태 : {0}", status == null ? "-" : status.Result.ToString());
        }
    }
}