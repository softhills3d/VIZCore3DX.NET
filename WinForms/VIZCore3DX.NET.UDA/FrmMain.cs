using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.UDA
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
            splitContainer1.Panel1.Controls.Add(vizcore3dx);

            //License
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================
            // 라이선스 파일을 통한 인증
            //vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("127.0.0.1", 8901);

            // ================================================================
            // License
            // ================================================================
            // VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");
            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 모델 로드
            InitializeVIZCore3DX();
            InitializeVIZCore3DXEvent();
        }

        private void InitializeVIZCore3DX()
        {
            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 차단
            // ================================================================
            vizcore3dx.BeginUpdate();

            // ================================================================
            // 설정 - 툴바
            // ================================================================

            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs(attributeTree: true);

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }

        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.Object3D.OnNodeEvent += Object3D_OnNodeEvent;
        }

        private void Object3D_OnNodeEvent(object sender, EventManager.NodeEventArgs e)
        {
            if (e.Node == null || e.Node.Count == 0)
            {
                lvAttribute.BeginUpdate();
                lvAttribute.Items.Clear();
                lvAttribute.EndUpdate();
            }
            else
            {
                ObjectAttributeCollection attribute = vizcore3dx.Object3D.UDA.FromNode(e.Node[0], true);
                if (attribute == null) { lvAttribute.Items.Clear(); return; }


                lvAttribute.BeginUpdate();
                lvAttribute.Items.Clear();
                foreach (ObjectAttribute item in attribute)
                {
                    ListViewItem lvi = new ListViewItem(new string[] { item.Key, item.Val });
                    lvAttribute.Items.Add(lvi);
                }
                lvAttribute.EndUpdate();
            }
        }

        #region Common

        /// <summary>
        /// UDAManager 실패 원인 표시
        /// </summary>
        /// <param name="message">표시할 메시지</param>
        private void ShowUdaFailure(string message)
        {
            MessageBox.Show(string.Format("{0}\r\n\r\nResult : {1}", message, vizcore3dx.Object3D.UDA.LastOperationStatus.Result), "VIZCore3DX.NET.UDA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 노드 선택
        /// </summary>
        /// <param name="nodes">선택할 노드</param>
        private void SelectNodes(List<Node> nodes)
        {
            if (nodes == null || nodes.Count == 0) return;

            using (vizcore3dx.BeginUpdateScope())
            {
                vizcore3dx.Object3D.Select(nodes, true);
                vizcore3dx.View.FlyToObject3d(nodes, 1.0f);
            }
        }

        #endregion

        #region UDA Tree / Export

        private void btnGetTree_Click(object sender, EventArgs e)
        {
            List<UdaTreeCategory> tree = vizcore3dx.Object3D.UDA.GetTree();

            tvUdaTree.BeginUpdate();
            tvUdaTree.Nodes.Clear();

            int keyCount = 0;
            int valueCount = 0;

            if (tree != null)
            {
                foreach (UdaTreeCategory category in tree)
                {
                    // 카테고리 > 키 > 값 (노드 수)
                    TreeNode categoryNode = tvUdaTree.Nodes.Add(category.Category);

                    foreach (UdaTreeKey key in category.Keys)
                    {
                        TreeNode keyNode = categoryNode.Nodes.Add(string.Format("{0} ({1})", key.Key, key.Values.Count));
                        keyNode.Tag = new string[] { category.Category, key.Key };
                        keyCount++;

                        foreach (UdaTreeValue value in key.Values)
                        {
                            TreeNode valueNode = keyNode.Nodes.Add(string.Format("{0} ({1})", value.Value, value.NodeCount));
                            valueNode.Tag = new string[] { category.Category, key.Key, value.Value };
                            valueCount++;
                        }
                    }
                }
            }

            tvUdaTree.EndUpdate();

            lblTreeInfo.Text = string.Format("카테고리 {0} / 키 {1} / 값 {2}  (값 더블 클릭 : 해당 노드 선택)", tvUdaTree.Nodes.Count, keyCount, valueCount);

            if (vizcore3dx.Object3D.UDA.LastOperationStatus.IsFailure) ShowUdaFailure("속성 트리를 조회하지 못했습니다.");
        }

        private void tvUdaTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string[] tag = e.Node.Tag as string[];
            if (tag == null) return;

            // 키 : 해당 속성을 가진 노드 (이름 완전 일치), 값 : 해당 속성 값을 가진 노드
            List<Node> nodes = tag.Length == 2
                ? vizcore3dx.Object3D.UDA.GetCategoryNameNodes(tag[0], tag[1], true)
                : vizcore3dx.Object3D.UDA.GetCategoryNameValueNodes(tag[0], tag[1], tag[2], true);

            SelectNodes(nodes);
        }

        private void btnExportTree_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                // 확장자에 따라 CSV / JSON / XML 형식으로 저장
                dlg.Filter = "CSV (*.csv)|*.csv|JSON (*.json)|*.json|XML (*.xml)|*.xml";
                dlg.FileName = "UdaTree.csv";
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                if (vizcore3dx.Object3D.UDA.ExportTree(dlg.FileName) == false)
                {
                    ShowUdaFailure("속성 트리를 내보내지 못했습니다.");
                    return;
                }

                MessageBox.Show(string.Format("속성 트리를 내보냈습니다.\r\n{0}", dlg.FileName), "VIZCore3DX.NET.UDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportMatrix_Click(object sender, EventArgs e)
        {
            // 선택 개체만 : 선택된 노드, 그 외 : 전체 노드 (null)
            List<Node> nodes = null;
            if (chkMatrixSelectedOnly.Checked)
            {
                nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP);
                if (nodes.Count == 0)
                {
                    MessageBox.Show("선택된 개체가 없습니다.", "VIZCore3DX.NET.UDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV (*.csv)|*.csv";
                dlg.FileName = "UdaMatrix.csv";
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                if (vizcore3dx.Object3D.UDA.ExportMatrix(dlg.FileName, nodes) == false)
                {
                    ShowUdaFailure("속성 매트릭스를 내보내지 못했습니다.");
                    return;
                }

                MessageBox.Show(string.Format("속성 매트릭스(노드 × 속성)를 내보냈습니다.\r\n{0}", dlg.FileName), "VIZCore3DX.NET.UDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Value Distribution

        private void btnRefreshCategory_Click(object sender, EventArgs e)
        {
            List<string> categories = vizcore3dx.Object3D.UDA.Categories;

            cmbDistCategory.BeginUpdate();
            cmbDistCategory.Items.Clear();
            if (categories != null)
            {
                foreach (string category in categories)
                {
                    cmbDistCategory.Items.Add(category);
                }
            }
            cmbDistCategory.EndUpdate();

            cmbDistName.Items.Clear();

            if (cmbDistCategory.Items.Count > 0) cmbDistCategory.SelectedIndex = 0;
        }

        private void cmbDistCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDistCategory.SelectedItem == null) return;

            List<string> names = vizcore3dx.Object3D.UDA.GetNames(cmbDistCategory.SelectedItem.ToString());

            cmbDistName.BeginUpdate();
            cmbDistName.Items.Clear();
            if (names != null)
            {
                foreach (string name in names)
                {
                    cmbDistName.Items.Add(name);
                }
            }
            cmbDistName.EndUpdate();

            if (cmbDistName.Items.Count > 0) cmbDistName.SelectedIndex = 0;
        }

        private void btnGetDistribution_Click(object sender, EventArgs e)
        {
            if (cmbDistCategory.SelectedItem == null || cmbDistName.SelectedItem == null) return;

            AttributeDistribution distribution = vizcore3dx.Object3D.UDA.GetValueDistribution(cmbDistCategory.SelectedItem.ToString(), cmbDistName.SelectedItem.ToString(), (int)numTopN.Value);

            lvDistribution.BeginUpdate();
            lvDistribution.Items.Clear();
            if (distribution != null)
            {
                foreach (AttributeValueCount item in distribution.Items)
                {
                    ListViewItem lvi = new ListViewItem(new string[] { item.Value, item.Count.ToString(), item.Percent.ToString("0.00") });
                    lvi.Tag = item.Value;
                    lvDistribution.Items.Add(lvi);
                }
            }
            lvDistribution.EndUpdate();

            if (distribution == null)
            {
                lblDistInfo.Text = string.Empty;
                ShowUdaFailure("속성 값 분포를 조회하지 못했습니다.");
                return;
            }

            lblDistInfo.Text = string.Format("노드 {0} / 고유 값 {1}{2}  (더블 클릭 : 해당 노드 선택)", distribution.NodeCount, distribution.DistinctValueCount, distribution.Truncated ? " (상위 N개만 표시)" : string.Empty);
        }

        private void lvDistribution_DoubleClick(object sender, EventArgs e)
        {
            if (lvDistribution.SelectedItems.Count == 0) return;
            if (cmbDistCategory.SelectedItem == null || cmbDistName.SelectedItem == null) return;

            string value = lvDistribution.SelectedItems[0].Tag as string;
            List<Node> nodes = vizcore3dx.Object3D.UDA.GetCategoryNameValueNodes(cmbDistCategory.SelectedItem.ToString(), cmbDistName.SelectedItem.ToString(), value, true);

            SelectNodes(nodes);
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
