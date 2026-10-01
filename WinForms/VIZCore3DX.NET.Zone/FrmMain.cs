using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Zone
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 목록 행 ↔ 공간 ID (표와 같은 순서)
        private List<int> _rowIds = new List<int>();

        // 겹침 행 ↔ 공간 ID 쌍 (표와 같은 순서)
        private List<KeyValuePair<int, int>> _overlapIds = new List<KeyValuePair<int, int>>();

        // 목록 갱신 중에는 선택·이름 변경을 뷰어로 되돌려 보내지 않습니다.
        private bool _syncing;

        public FrmMain()
        {
            InitializeComponent();

            // 뷰어와 무관한 콤보 항목은 생성자에서 채웁니다.
            cmbOption.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.BoundBoxSearchOption));
            cmbOption.SelectedItem = VIZCore3DX.NET.Data.BoundBoxSearchOption.IncludingPart;

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer2.Panel1.Controls.Add(vizcore3dx);

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================

            // 라이선스 파일을 통한 인증
            //VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("127.0.0.1", 8901);

            // ================================================================
            // License
            // ================================================================

            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeVIZCore3DX();
            InitializeVIZCore3DXEvent();
        }

        private void InitializeVIZCore3DX()
        {
            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs(VIZCore3DX.NET.Data.ToolbarKind.Zone, VIZCore3DX.NET.Data.ToolbarKind.SelectionBox);
            ShowAttributeTabs();

            // 뷰에서 공간을 클릭하면 선택 통지를 받고, 경계면 끌기는 체크 상태를 따릅니다.
            vizcore3dx.Zone.IsViewPickingEnabled = chkViewPicking.Checked;
            vizcore3dx.Zone.IsFaceDragEnabled = chkFaceDrag.Checked;

            SetStatus("모델을 열어 주세요.");
        }

        // 공간 목록은 뷰어가 소유하므로, 변경 이벤트를 받아 표를 다시 그립니다.
        // 내장 리본·다면체 공간 패널로 바뀐 것도 같은 이벤트로 들어옵니다.
        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.Zone.OnZoneCreatedEvent -= Zone_OnZoneCreatedEvent;
            vizcore3dx.Zone.OnZoneCreatedEvent += Zone_OnZoneCreatedEvent;
            vizcore3dx.Zone.OnZoneDeletedEvent -= Zone_OnZoneDeletedEvent;
            vizcore3dx.Zone.OnZoneDeletedEvent += Zone_OnZoneDeletedEvent;
            vizcore3dx.Zone.OnZoneClearedEvent -= Zone_OnZoneClearedEvent;
            vizcore3dx.Zone.OnZoneClearedEvent += Zone_OnZoneClearedEvent;
            vizcore3dx.Zone.OnZoneNameChangedEvent -= Zone_OnZoneNameChangedEvent;
            vizcore3dx.Zone.OnZoneNameChangedEvent += Zone_OnZoneNameChangedEvent;
            vizcore3dx.Zone.OnZoneVisibleChangedEvent -= Zone_OnZoneVisibleChangedEvent;
            vizcore3dx.Zone.OnZoneVisibleChangedEvent += Zone_OnZoneVisibleChangedEvent;
            vizcore3dx.Zone.OnZoneColorChangedEvent -= Zone_OnZoneColorChangedEvent;
            vizcore3dx.Zone.OnZoneColorChangedEvent += Zone_OnZoneColorChangedEvent;
            vizcore3dx.Zone.OnZoneGeometryChangedEvent -= Zone_OnZoneGeometryChangedEvent;
            vizcore3dx.Zone.OnZoneGeometryChangedEvent += Zone_OnZoneGeometryChangedEvent;
            vizcore3dx.Zone.OnZoneSelectedEvent -= Zone_OnZoneSelectedEvent;
            vizcore3dx.Zone.OnZoneSelectedEvent += Zone_OnZoneSelectedEvent;
        }

        // 종료 시 이벤트 구독을 먼저 끊습니다. 자식 컨트롤이 정리된 뒤에 이벤트가 오면 안 됩니다.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            vizcore3dx.Zone.OnZoneCreatedEvent -= Zone_OnZoneCreatedEvent;
            vizcore3dx.Zone.OnZoneDeletedEvent -= Zone_OnZoneDeletedEvent;
            vizcore3dx.Zone.OnZoneClearedEvent -= Zone_OnZoneClearedEvent;
            vizcore3dx.Zone.OnZoneNameChangedEvent -= Zone_OnZoneNameChangedEvent;
            vizcore3dx.Zone.OnZoneVisibleChangedEvent -= Zone_OnZoneVisibleChangedEvent;
            vizcore3dx.Zone.OnZoneColorChangedEvent -= Zone_OnZoneColorChangedEvent;
            vizcore3dx.Zone.OnZoneGeometryChangedEvent -= Zone_OnZoneGeometryChangedEvent;
            vizcore3dx.Zone.OnZoneSelectedEvent -= Zone_OnZoneSelectedEvent;

            base.OnFormClosing(e);
        }

        private void Zone_OnZoneCreatedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ZoneEventArgs e)
        {
            RunOnUi(RefreshList);
        }

        private void Zone_OnZoneDeletedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ZoneEventArgs e)
        {
            RunOnUi(RefreshList);
        }

        // 모델을 닫아도 이 이벤트가 옵니다.
        private void Zone_OnZoneClearedEvent(object sender, EventArgs e)
        {
            RunOnUi(() => { ClearOverlaps(); RefreshList(); });
        }

        private void Zone_OnZoneNameChangedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ZoneEventArgs e)
        {
            RunOnUi(RefreshList);
        }

        private void Zone_OnZoneVisibleChangedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ZoneEventArgs e)
        {
            RunOnUi(RefreshList);
        }

        private void Zone_OnZoneColorChangedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ZoneEventArgs e)
        {
            RunOnUi(RefreshList);
        }

        // 경계면 끌기·불리언 연산으로 형상이 바뀌면 공간마다 한 번씩 옵니다.
        private void Zone_OnZoneGeometryChangedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ZoneGeometryChangedEventArgs e)
        {
            RunOnUi(RefreshList);
        }

        // 뷰 클릭(FromView)은 통지만 하므로 여기서 선택 상태를 바꾸고, 그 밖의 선택 변화는 표에 맞춥니다.
        private void Zone_OnZoneSelectedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ZoneEventArgs e)
        {
            if (e.FromView)
                RunOnUi(() => vizcore3dx.Zone.SetSelectedOnly(e.IDs));
            else
                RunOnUi(SyncSelectionFromViewer);
        }

        #region 1. 모델
        // 공간을 만들 모델을 엽니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            ClearOverlaps();
            RefreshList();
            SetStatus("모델을 열었습니다.");
        }
        #endregion

        #region 2. 생성
        // 모델 경계상자를 가로·세로로 나눠 공간을 한꺼번에 만듭니다. 30초 안에 결과를 보기 위한 시연입니다.
        private void btnCreateGrid_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            List<VIZCore3DX.NET.Data.BoundBox3D> boxes = SplitBoundBox(vizcore3dx.Model.BoundBox, (int)numGridX.Value, (int)numGridY.Value);
            List<int> ids = vizcore3dx.Zone.CreateZonesFromBoundBoxes(boxes, txtName.Text, (float)numMargin.Value);

            vizcore3dx.View.FitToView();
            SetStatus(string.Format("공간 {0}개를 만들었습니다.", ids.Count));
        }

        // 뷰에서 선택한 노드들의 경계상자로 공간을 하나 만듭니다.
        private void btnFromNodes_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);
            if (nodes.Count == 0) { SetStatus("뷰에서 노드를 먼저 선택하세요."); return; }

            int id = vizcore3dx.Zone.CreateZoneFromSelectedNodes(txtName.Text, (float)numMargin.Value);
            if (id <= 0) { SetStatus(string.Format("공간을 만들지 못했습니다 : {0}", vizcore3dx.Zone.LastOperationResult)); return; }

            vizcore3dx.Zone.SetSelectedOnly(new List<int> { id });
            SetStatus(string.Format("선택 노드 {0}개로 공간 {1}을(를) 만들었습니다.", nodes.Count, id));
        }

        // 선택 상자(SelectionBox)를 공간으로 바꿉니다. 선택 상자는 내장 리본의 선택 상자 탭에서 만듭니다.
        private void btnFromSelectionBox_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            List<int> boxes = vizcore3dx.SelectionBox.GetSelectedItems();
            if (boxes.Count == 0) { SetStatus("선택 상자를 먼저 만들고 선택하세요."); return; }

            int id = vizcore3dx.Zone.CreateZoneFromSelectionBox(boxes[0], txtName.Text);
            if (id <= 0) { SetStatus(string.Format("공간을 만들지 못했습니다 : {0}", vizcore3dx.Zone.LastOperationResult)); return; }

            vizcore3dx.Zone.SetSelectedOnly(new List<int> { id });
            SetStatus(string.Format("선택 상자 {0}으로 공간 {1}을(를) 만들었습니다.", boxes[0], id));
        }
        #endregion

        #region 3. 조작
        // 뷰에서 공간을 클릭하면 OnZoneSelectedEvent 가 FromView = true 로 옵니다.
        private void chkViewPicking_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.Zone.IsViewPickingEnabled = chkViewPicking.Checked;
        }

        // 켜면 경계면 위에서의 끌기가 화면 회전 대신 면 이동이 됩니다. 형상이 바뀌면 GeometryChanged 이벤트가 옵니다.
        private void chkFaceDrag_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.Zone.IsFaceDragEnabled = chkFaceDrag.Checked;
        }

        // 선택한 공간 안의 노드를 선택합니다. 판정 기준(완전 포함·일부 포함)은 콤보로 고릅니다.
        private void btnSelectNodes_Click(object sender, EventArgs e)
        {
            List<int> ids = SelectedIds();
            if (ids.Count == 0) { SetStatus("목록에서 공간을 선택하세요."); return; }

            int count = vizcore3dx.Zone.SelectNodesInZone(ids, SearchOption());
            SetStatus(string.Format("공간 안의 노드 {0}개를 선택했습니다.", count));
        }

        // 선택한 공간 안의 노드만 남기고 나머지는 숨깁니다. 되돌리려면 모델 트리나 리본의 전체 표시를 쓰세요.
        private void btnIsolateNodes_Click(object sender, EventArgs e)
        {
            List<int> ids = SelectedIds();
            if (ids.Count == 0) { SetStatus("목록에서 공간을 선택하세요."); return; }

            int count = vizcore3dx.Zone.IsolateNodesInZone(ids, SearchOption());
            SetStatus(string.Format("공간 안의 노드 {0}개만 표시합니다.", count));
        }

        // 카메라를 선택한 공간에 맞춥니다.
        private void btnFit_Click(object sender, EventArgs e)
        {
            List<int> ids = SelectedIds();
            if (ids.Count == 0) { SetStatus("목록에서 공간을 선택하세요."); return; }

            vizcore3dx.Zone.FitToZone(ids, 1.2f);
        }

        // 선택한 공간들을 합쳐 새 공간을 만듭니다. 원본은 체크에 따라 남기거나 지웁니다.
        private void btnUnion_Click(object sender, EventArgs e)
        {
            List<int> ids = SelectedIds();
            if (ids.Count < 2) { SetStatus("목록에서 공간을 2개 이상 선택하세요."); return; }

            int id = vizcore3dx.Zone.Union(ids, txtName.Text, chkDeleteSources.Checked);
            if (id <= 0) { SetStatus(string.Format("합집합 실패 : {0}", vizcore3dx.Zone.LastOperationResult)); return; }

            vizcore3dx.Zone.SetSelectedOnly(new List<int> { id });
            SetStatus(string.Format("공간 {0}개의 합집합으로 공간 {1}을(를) 만들었습니다.", ids.Count, id));
        }

        // 표의 위 행(A)에서 아래 행(B)을 뺀 새 공간을 만듭니다.
        private void btnSubtract_Click(object sender, EventArgs e)
        {
            List<int> ids = SelectedIds();
            if (ids.Count != 2) { SetStatus("목록에서 공간을 정확히 2개 선택하세요. 위 행이 A, 아래 행이 B 입니다."); return; }

            int id = vizcore3dx.Zone.Subtract(ids[0], ids[1], txtName.Text, chkDeleteSources.Checked);
            if (id <= 0) { SetStatus(string.Format("차집합 실패 : {0}", vizcore3dx.Zone.LastOperationResult)); return; }

            vizcore3dx.Zone.SetSelectedOnly(new List<int> { id });
            SetStatus(string.Format("공간 {0} − {1} 로 공간 {2}을(를) 만들었습니다.", ids[0], ids[1], id));
        }

        // 선택한 공간의 면·경계선 색을 바꿉니다. 색의 알파는 무시되고 불투명도는 스타일 값이 결정합니다.
        private void btnColor_Click(object sender, EventArgs e)
        {
            List<int> ids = SelectedIds();
            if (ids.Count == 0) { SetStatus("목록에서 공간을 선택하세요."); return; }

            using (ColorDialog dialog = new ColorDialog())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                System.Drawing.Color face = dialog.Color;
                System.Drawing.Color line = System.Drawing.Color.FromArgb(face.R / 2, face.G / 2, face.B / 2);
                vizcore3dx.Zone.SetColor(ids, face, line);
                SetStatus(string.Format("공간 {0}개의 색을 바꿨습니다.", ids.Count));
            }
        }

        // 모든 공간에 적용되는 표시 스타일 중 면 불투명도(0~100)를 바꿉니다. 0 이면 경계선만 보입니다.
        private void btnApplyStyle_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.ZoneStyle style = vizcore3dx.Zone.Style;
            style.FaceOpacity = (int)numOpacity.Value;
            vizcore3dx.Zone.SetStyle(style);
            SetStatus(string.Format("면 불투명도를 {0} 으로 적용했습니다.", style.FaceOpacity));
        }

        // 서로 겹치는 공간 쌍과 겹친 체적을 아래 표에 채웁니다. 행을 더블클릭하면 두 공간으로 이동합니다.
        private void btnOverlaps_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            ClearOverlaps();
            foreach (var overlap in vizcore3dx.Zone.GetOverlaps())
            {
                dgvOverlaps.Rows.Add(ZoneLabel(overlap.idA), ZoneLabel(overlap.idB), (overlap.volume / 1e9).ToString("N3"));
                _overlapIds.Add(new KeyValuePair<int, int>(overlap.idA, overlap.idB));
            }
            SetStatus(string.Format("겹치는 공간 쌍 {0}개를 찾았습니다.", _overlapIds.Count));
        }
        #endregion

        #region 4. 파일
        // 공간 전체를 JSON 파일로 저장합니다. Tag 는 저장되지 않습니다.
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Zone.Count == 0) { SetStatus("저장할 공간이 없습니다."); return; }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Zone JSON (*.json)|*.json";
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                bool ok = vizcore3dx.Zone.Export(dialog.FileName);
                SetStatus(ok ? "공간을 저장했습니다." : string.Format("저장하지 못했습니다 : {0}", vizcore3dx.Zone.LastOperationResult));
            }
        }

        // JSON 파일의 공간을 현재 목록에 덧붙입니다. ID 는 새로 부여됩니다.
        private void btnImport_Click(object sender, EventArgs e)
        {
            Import(VIZCore3DX.NET.Data.ZoneImportMode.Append);
        }

        // 현재 공간을 모두 지우고 JSON 파일의 공간으로 바꿉니다.
        private void btnImportReplace_Click(object sender, EventArgs e)
        {
            Import(VIZCore3DX.NET.Data.ZoneImportMode.Replace);
        }
        #endregion

        #region 5. 정리
        // 공간을 모두 보입니다.
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            vizcore3dx.Zone.SetVisible(true);
        }

        // 공간을 모두 숨깁니다. 항목은 남아 있어 목록·조회는 그대로 됩니다.
        private void btnHideAll_Click(object sender, EventArgs e)
        {
            vizcore3dx.Zone.SetVisible(false);
        }

        // 선택한 공간을 삭제합니다.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> ids = SelectedIds();
            if (ids.Count == 0) { SetStatus("목록에서 공간을 선택하세요."); return; }

            vizcore3dx.Zone.Delete(ids);
            ClearOverlaps();
            SetStatus(string.Format("공간 {0}개를 삭제했습니다.", ids.Count));
        }

        // 공간을 전부 삭제합니다.
        private void btnClear_Click(object sender, EventArgs e)
        {
            vizcore3dx.Zone.Clear();
            ClearOverlaps();
            SetStatus("공간을 모두 삭제했습니다.");
        }
        #endregion

        #region 목록
        // 표에서 고른 행들을 뷰어의 선택 상태로 보냅니다. 숨긴 공간은 선택해도 보이지 않으므로 먼저 표시합니다.
        private void dgvZones_SelectionChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            List<int> ids = SelectedIds();

            _syncing = true;
            try
            {
                foreach (int id in ids)
                    if (!vizcore3dx.Zone.GetVisible(id)) vizcore3dx.Zone.SetVisible(id, true);

                vizcore3dx.Zone.SetSelectedOnly(ids);
            }
            finally
            {
                _syncing = false;
            }

            if (chkFollow.Checked && ids.Count > 0) vizcore3dx.Zone.FitToZone(ids, 1.2f);
        }

        // 이름 칸을 고치면 공간 이름을 바꿉니다. 바뀐 이름은 NameChanged 이벤트로 표에 다시 들어옵니다.
        private void dgvZones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_syncing || e.RowIndex < 0 || e.RowIndex >= _rowIds.Count) return;
            if (dgvZones.Columns[e.ColumnIndex] != colName) return;

            string name = Convert.ToString(dgvZones.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            if (string.IsNullOrWhiteSpace(name)) { RefreshList(); return; }

            vizcore3dx.Zone.SetName(_rowIds[e.RowIndex], name.Trim());
        }

        // 선택한 공간의 표시를 뒤집습니다.
        private void btnToggleVisible_Click(object sender, EventArgs e)
        {
            List<int> ids = SelectedIds();
            if (ids.Count == 0) { SetStatus("목록에서 공간을 선택하세요."); return; }

            vizcore3dx.Zone.BeginUpdate();
            try
            {
                foreach (int id in ids)
                    vizcore3dx.Zone.SetVisible(id, !vizcore3dx.Zone.GetVisible(id));
            }
            finally
            {
                vizcore3dx.Zone.EndUpdate();
            }
        }

        // 겹침 행을 더블클릭하면 두 공간을 목록에서 선택합니다. 선택 동기로 뷰 강조·카메라 이동이 따라옵니다.
        private void dgvOverlaps_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _overlapIds.Count) return;

            KeyValuePair<int, int> pair = _overlapIds[e.RowIndex];
            dgvZones.ClearSelection();
            for (int i = 0; i < _rowIds.Count; i++)
                if (_rowIds[i] == pair.Key || _rowIds[i] == pair.Value) dgvZones.Rows[i].Selected = true;
        }
        #endregion

        #region Helpers
        // 모델이 열려 있지 않으면 상태 문구를 남기고 false 를 돌려줍니다.
        private bool IsModelOpened()
        {
            if (vizcore3dx.Model.IsOpen()) return true;

            SetStatus("먼저 모델을 여세요.");
            return false;
        }

        private void SetStatus(string message)
        {
            lblStatus.Text = message;
        }

        private void RunOnUi(Action action)
        {
            if (InvokeRequired) BeginInvoke(action);
            else action();
        }

        private VIZCore3DX.NET.Data.BoundBoxSearchOption SearchOption()
        {
            return (VIZCore3DX.NET.Data.BoundBoxSearchOption)cmbOption.SelectedItem;
        }

        private List<int> SelectedIds()
        {
            List<int> ids = new List<int>();
            for (int i = 0; i < _rowIds.Count; i++)
                if (dgvZones.Rows[i].Selected) ids.Add(_rowIds[i]);
            return ids;
        }

        private string ZoneLabel(int id)
        {
            return string.Format("{0} ({1})", vizcore3dx.Zone.GetName(id), id);
        }

        // 모델 경계상자를 X 방향 nx 칸, Y 방향 ny 칸으로 나눕니다. Z 는 전체 높이입니다.
        private static List<VIZCore3DX.NET.Data.BoundBox3D> SplitBoundBox(VIZCore3DX.NET.Data.BoundBox3D box, int nx, int ny)
        {
            List<VIZCore3DX.NET.Data.BoundBox3D> boxes = new List<VIZCore3DX.NET.Data.BoundBox3D>();
            float dx = box.LengthX / nx;
            float dy = box.LengthY / ny;

            for (int iy = 0; iy < ny; iy++)
                for (int ix = 0; ix < nx; ix++)
                    boxes.Add(new VIZCore3DX.NET.Data.BoundBox3D(
                        box.MinX + dx * ix, box.MinY + dy * iy, box.MinZ,
                        box.MinX + dx * (ix + 1), box.MinY + dy * (iy + 1), box.MaxZ));
            return boxes;
        }

        // 파일의 공간을 불러옵니다. 뷰 잠금으로 형상마다 다시 그리지 않게 합니다.
        private void Import(VIZCore3DX.NET.Data.ZoneImportMode mode)
        {
            if (!IsModelOpened()) return;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Zone JSON (*.json)|*.json";
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                List<int> ids;
                vizcore3dx.BeginUpdate();
                try
                {
                    ids = vizcore3dx.Zone.Import(dialog.FileName, mode);
                }
                finally
                {
                    vizcore3dx.EndUpdate();
                }

                ClearOverlaps();
                SetStatus(ids.Count > 0 ? string.Format("공간 {0}개를 불러왔습니다.", ids.Count) : string.Format("불러온 공간이 없습니다 : {0}", vizcore3dx.Zone.LastOperationResult));
            }
        }

        private void ClearOverlaps()
        {
            dgvOverlaps.Rows.Clear();
            _overlapIds.Clear();
        }

        // 뷰어의 공간 목록을 표에 다시 채우고, 뷰어의 선택 상태를 표에 맞춥니다.
        private void RefreshList()
        {
            _syncing = true;
            try
            {
                dgvZones.Rows.Clear();
                _rowIds.Clear();

                foreach (VIZCore3DX.NET.Data.ZoneItem item in vizcore3dx.Zone.Items)
                {
                    VIZCore3DX.NET.Data.BoundBox3D box = item.BoundBox;
                    string size = box == null ? string.Empty : string.Format("{0:N0} × {1:N0} × {2:N0}", box.LengthX, box.LengthY, box.LengthZ);
                    int row = dgvZones.Rows.Add(item.ID, item.Name, (item.Volume / 1e9).ToString("N2"), size, item.IsVisible ? "보임" : "숨김");
                    dgvZones.Rows[row].Cells[colName.Index].Style.BackColor = item.FaceColor;
                    _rowIds.Add(item.ID);
                }
            }
            finally
            {
                _syncing = false;
            }

            SyncSelectionFromViewer();
        }

        private void SyncSelectionFromViewer()
        {
            if (_syncing) return;

            List<int> selected = vizcore3dx.Zone.GetSelectedItems();

            _syncing = true;
            try
            {
                dgvZones.ClearSelection();
                for (int i = 0; i < _rowIds.Count; i++)
                    if (selected.Contains(_rowIds[i])) dgvZones.Rows[i].Selected = true;
            }
            finally
            {
                _syncing = false;
            }
        }

        // 지정한 탭만 남기고 나머지 툴바(=리본 탭)와 모델 트리 패널의 같은 탭을 숨깁니다. 홈 탭·모델 트리는 항상 표시합니다.
        private void ShowRibbonTabs(params VIZCore3DX.NET.Data.ToolbarKind[] keep)
        {
            foreach (VIZCore3DX.NET.Data.ToolbarKind kind in Enum.GetValues(typeof(VIZCore3DX.NET.Data.ToolbarKind)))
                vizcore3dx.Toolbar.SetVisible(kind, kind == VIZCore3DX.NET.Data.ToolbarKind.Main || Array.IndexOf(keep, kind) >= 0);

            vizcore3dx.TabSnapshotEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Snapshot) >= 0;
            vizcore3dx.TabNotetEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Note) >= 0;
            vizcore3dx.TabMeasureEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Measure) >= 0;
            vizcore3dx.TabSectionEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Section) >= 0;
            vizcore3dx.TabDecalEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Decal) >= 0;
            vizcore3dx.TabSelectionBoxEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.SelectionBox) >= 0;
            vizcore3dx.TabZoneEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Zone) >= 0;
            vizcore3dx.TabEffectEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Effect) >= 0;
            vizcore3dx.TabObserverEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Observer) >= 0;
        }

        // 속성 패널은 노드 특성·노드 속성만 기본으로 남기고, 예제가 다루는 탭만 켭니다.
        private void ShowAttributeTabs(bool attributeTree = false, bool nodeGroup = false, bool projection = false, bool pmi = false)
        {
            vizcore3dx.TabAttributeTreeEnabled = attributeTree;
            vizcore3dx.TabNodeGroupEnabled = nodeGroup;
            vizcore3dx.TabProjectionEnabled = projection;
            vizcore3dx.TabPmiEnabled = pmi;
            vizcore3dx.TabEnvironmentEnabled = false;
            vizcore3dx.TabGenericDataEnabled = false;
            vizcore3dx.AttributePanelVisible = attributeTree || nodeGroup || projection || pmi;
        }
        #endregion
    }
}
