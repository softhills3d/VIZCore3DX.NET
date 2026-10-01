using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.NodeLock
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

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

            vizcore3dx.Object3D.NodeLock.Enable = false;
            vizcore3dx.Object3D.NodeLock.OnNodeLockChangedEvent += NodeLock_OnNodeLockChangedEvent;

            UpdateNodeLockList();
            UpdateNodeLockButtonsUI();
        }

        #region Node Lock
        private void ckEnable_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.Object3D.NodeLock.Enable = ckEnable.Checked;

            // 비활성화 시 잠금이 모두 해제되므로 목록 갱신
            UpdateNodeLockList();
            UpdateNodeLockButtonsUI();
        }

        private void UpdateNodeLockButtonsUI()
        {
            bool enabled = ckEnable.Checked;

            btnLockSelected.Enabled = enabled;
            btnUnlockSelected.Enabled = enabled;
            btnUnlockAll.Enabled = enabled;
        }

        private void UpdateNodeLockList()
        {
            dgvNodeLock.SuspendLayout();
            dgvNodeLock.Rows.Clear();

            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.NodeLock.List();

            if (nodes != null)
            {
                foreach (VIZCore3DX.NET.Data.Node node in nodes)
                {
                    if (node == null || node.IsValid == false) continue;

                    int rowIndex = dgvNodeLock.Rows.Add(node.NodeName, node.Kind);
                    dgvNodeLock.Rows[rowIndex].Tag = node;
                }
            }

            lblCount.Text = dgvNodeLock.Rows.Count.ToString();

            dgvNodeLock.ClearSelection();
            dgvNodeLock.ResumeLayout();
        }

        private List<VIZCore3DX.NET.Data.Node> GetSelectedGridNodes()
        {
            List<VIZCore3DX.NET.Data.Node> nodes = new List<VIZCore3DX.NET.Data.Node>();

            foreach (DataGridViewRow row in dgvNodeLock.SelectedRows)
            {
                VIZCore3DX.NET.Data.Node node = row.Tag as VIZCore3DX.NET.Data.Node;

                if (node == null || node.IsValid == false) continue;

                nodes.Add(node);
            }

            return nodes;
        }

        private void BtnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            UpdateNodeLockList();
        }

        private void BtnLockSelected_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);

            if (nodes == null || nodes.Count == 0)
            {
                MessageBox.Show("View에서 개체를 선택하세요.", "Node Lock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 노드 잠금 기능이 비활성화 상태이면 잠금이 적용되지 않음
            if (vizcore3dx.Object3D.NodeLock.Enable == false)
            {
                MessageBox.Show("노드 잠금 기능을 먼저 활성화(체크)하세요.", "Node Lock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 선택된 개체 잠금 (하위 전개 비용이 적은 인자 없는 Lock() 사용)
            vizcore3dx.Object3D.NodeLock.Lock();
        }

        private void BtnUnlockSelected_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = GetSelectedGridNodes();

            if (nodes.Count == 0) return;

            vizcore3dx.Object3D.NodeLock.Unlock(nodes);
        }

        private void BtnUnlockAll_Click(object sender, EventArgs e)
        {
            vizcore3dx.Object3D.NodeLock.Clear();
        }

        private void NodeLock_OnNodeLockChangedEvent(object sender, EventArgs e)
        {
            if (InvokeRequired == true)
            {
                BeginInvoke(new Action(UpdateNodeLockList));
                return;
            }

            UpdateNodeLockList();
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