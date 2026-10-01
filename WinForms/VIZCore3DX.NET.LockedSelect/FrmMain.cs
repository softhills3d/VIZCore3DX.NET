using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.LockedSelect
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;
        private bool synchronizingVisibleState;

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

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
        }

        private void InitializeVIZCore3DX()
        {
            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();

            vizcore3dx.Object3D.OnObject3DVisibleChangedEvent += Object3D_OnObject3DVisibleChangedEvent;

            // 선택 고정 목록 변경 이벤트 : 뷰/모델 트리 등 외부에서 변경된 경우에도 목록 동기화
            vizcore3dx.Object3D.LockedSelect.OnObject3DLockedSelectChangedEvent += LockedSelect_OnObject3DLockedSelectChangedEvent;

            InitializeObjectList();
        }

        #region Locked Select

        private void InitializeObjectList()
        {
            synchronizingVisibleState = true;
            dgvLockedSelect.SuspendLayout();

            try
            {
                dgvLockedSelect.Rows.Clear();

                // 엔진의 선택 고정 목록(LockedSelect.List)을 기준으로 목록 구성
                if (vizcore3dx.Model.IsOpen() == true)
                {
                    List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.LockedSelect.List();

                    if (nodes != null)
                    {
                        foreach (VIZCore3DX.NET.Data.Node node in nodes)
                        {
                            AddGridNode(node);
                        }
                    }
                }

                UpdateCount();
                dgvLockedSelect.ClearSelection();
            }
            finally
            {
                dgvLockedSelect.ResumeLayout();
                synchronizingVisibleState = false;
            }
        }

        private bool ContainsGridNode(VIZCore3DX.NET.Data.Node node)
        {
            if (node == null || node.IsValid == false) return false;

            foreach (DataGridViewRow row in dgvLockedSelect.Rows)
            {
                VIZCore3DX.NET.Data.Node gridNode = row.Tag as VIZCore3DX.NET.Data.Node;

                if (gridNode == null || gridNode.IsValid == false) continue;
                if (gridNode.EntityID == node.EntityID && gridNode.Index == node.Index) return true;
            }

            return false;
        }

        private void AddGridNode(VIZCore3DX.NET.Data.Node node)
        {
            if (node == null || node.IsValid == false) return;
            if (ContainsGridNode(node) == true) return;

            int rowIndex = dgvLockedSelect.Rows.Add(node.NodeName, node.Kind, node.Visible);
            dgvLockedSelect.Rows[rowIndex].Tag = node;
        }

        private List<VIZCore3DX.NET.Data.Node> GetSelectedGridNodes()
        {
            List<VIZCore3DX.NET.Data.Node> nodes = new List<VIZCore3DX.NET.Data.Node>();

            foreach (DataGridViewRow row in dgvLockedSelect.SelectedRows)
            {
                VIZCore3DX.NET.Data.Node node = row.Tag as VIZCore3DX.NET.Data.Node;

                if (node == null || node.IsValid == false) continue;

                nodes.Add(node);
            }

            return nodes;
        }

        private List<VIZCore3DX.NET.Data.Node> GetAllGridNodes()
        {
            List<VIZCore3DX.NET.Data.Node> nodes = new List<VIZCore3DX.NET.Data.Node>();

            foreach (DataGridViewRow row in dgvLockedSelect.Rows)
            {
                VIZCore3DX.NET.Data.Node node = row.Tag as VIZCore3DX.NET.Data.Node;

                if (node == null || node.IsValid == false) continue;

                nodes.Add(node);
            }

            return nodes;
        }

        private void UpdateCount()
        {
            lblCount.Text = dgvLockedSelect.Rows.Count.ToString();
        }

        private void UpdateVisibleRows(List<VIZCore3DX.NET.Data.Node> nodes, bool visible)
        {
            if (nodes == null || nodes.Count == 0) return;

            synchronizingVisibleState = true;
            dgvLockedSelect.SuspendLayout();

            try
            {
                foreach (DataGridViewRow row in dgvLockedSelect.Rows)
                {
                    VIZCore3DX.NET.Data.Node gridNode = row.Tag as VIZCore3DX.NET.Data.Node;

                    if (gridNode == null || gridNode.IsValid == false) continue;

                    foreach (VIZCore3DX.NET.Data.Node node in nodes)
                    {
                        if (node == null || node.IsValid == false) continue;
                        if (gridNode.EntityID != node.EntityID || gridNode.Index != node.Index) continue;

                        bool currentVisible = Convert.ToBoolean(row.Cells[colVisible.Index].Value);

                        if (currentVisible != visible) row.Cells[colVisible.Index].Value = visible;

                        break;
                    }
                }
            }
            finally
            {
                dgvLockedSelect.ResumeLayout();
                synchronizingVisibleState = false;
            }
        }

        private void SetObjectVisible(List<VIZCore3DX.NET.Data.Node> nodes, bool visible)
        {
            if (nodes == null || nodes.Count == 0) return;

            vizcore3dx.BeginUpdate();

            try
            {
                vizcore3dx.Object3D.Show(nodes, visible);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        private void BtnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            InitializeObjectList();
        }

        private void BtnAddSelected_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);

            if (nodes == null || nodes.Count == 0)
            {
                MessageBox.Show("View에서 개체를 선택하세요.", "Locked Select", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> targets = new List<VIZCore3DX.NET.Data.Node>();

            foreach (VIZCore3DX.NET.Data.Node node in nodes)
            {
                if (node == null || node.IsValid == false) continue;
                if (ContainsGridNode(node) == true) continue;

                targets.Add(node);
            }

            if (targets.Count == 0) return;

            vizcore3dx.Object3D.LockedSelect.Add(targets);

            InitializeObjectList();
        }

        private void BtnUnlockSelected_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = GetSelectedGridNodes();

            if (nodes.Count == 0) return;

            vizcore3dx.Object3D.LockedSelect.Delete(nodes);

            InitializeObjectList();
        }

        private void BtnClearLock_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            // LockedSelect.Clear()는 DLL 버그로 멈추는 경우가 있어 Delete로 전체 해제
            List<VIZCore3DX.NET.Data.Node> nodes = GetAllGridNodes();

            if (nodes.Count == 0) return;

            vizcore3dx.Object3D.LockedSelect.Delete(nodes);

            InitializeObjectList();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            SetObjectVisible(GetSelectedGridNodes(), true);
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            SetObjectVisible(GetSelectedGridNodes(), false);
        }

        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            SetObjectVisible(GetAllGridNodes(), true);
        }

        private void BtnHideAll_Click(object sender, EventArgs e)
        {
            SetObjectVisible(GetAllGridNodes(), false);
        }

        private void DgvLockedSelect_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLockedSelect.CurrentCell == null) return;
            if (dgvLockedSelect.IsCurrentCellDirty == false) return;
            if (dgvLockedSelect.CurrentCell.ColumnIndex != colVisible.Index) return;

            dgvLockedSelect.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DgvLockedSelect_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (synchronizingVisibleState == true) return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != colVisible.Index) return;

            DataGridViewRow row = dgvLockedSelect.Rows[e.RowIndex];
            VIZCore3DX.NET.Data.Node node = row.Tag as VIZCore3DX.NET.Data.Node;

            if (node == null || node.IsValid == false) return;

            bool visible = Convert.ToBoolean(row.Cells[colVisible.Index].Value);
            List<VIZCore3DX.NET.Data.Node> nodes = new List<VIZCore3DX.NET.Data.Node> { node };

            SetObjectVisible(nodes, visible);
        }

        private void LockedSelect_OnObject3DLockedSelectChangedEvent(object sender, EventArgs e)
        {
            if (IsDisposed == true || Disposing == true) return;

            // 재진입으로 멈추는 것 방지 위해 항상 BeginInvoke로 미룸
            BeginInvoke(new Action(InitializeObjectList));
        }

        private void Object3D_OnObject3DVisibleChangedEvent(object sender, VIZCore3DX.NET.Event.EventManager.Object3DVisibleChangedEventArgs e)
        {
            if (e == null || e.Node == null || e.Node.Count == 0) return;

            List<VIZCore3DX.NET.Data.Node> nodes = new List<VIZCore3DX.NET.Data.Node>(e.Node);
            bool visible = e.Visible;

            if (IsDisposed == true || Disposing == true) return;

            if (InvokeRequired == true)
            {
                BeginInvoke(new Action(() => UpdateVisibleRows(nodes, visible)));
                return;
            }

            UpdateVisibleRows(nodes, visible);
        }

        #endregion

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
    }
}