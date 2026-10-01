using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.PlasticFocusReview
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        private bool plasticInitializing = false;

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

            plasticInitializing = true;

            chkEnable.Checked = vizcore3dx.View.Plastic.Enable;

            vizcore3dx.View.SelectionColor = Color.Red;

            rdoSelectionColor.Checked = vizcore3dx.View.Plastic.ColorType == VIZCore3DX.NET.Data.PlasticColorTypes.SELECTION_COLOR;
            rdoObjectColor.Checked = vizcore3dx.View.Plastic.ColorType == VIZCore3DX.NET.Data.PlasticColorTypes.OBJECT_COLOR;

            cboSelectionObject3DType.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.SelectionObject3DTypes));
            cboSelectionObject3DType.SelectedItem = vizcore3dx.View.Plastic.SelectionObject3DType;

            chkSetPivot.Checked = true;

            lstPlasticNodes.DisplayMember = "NodeName";

            UpdatePlasticControlState();

            plasticInitializing = false;

            RefreshPlasticNodes();
        }

        #region Model

        private void BtnOpenModel_Click(object sender, EventArgs e)
        {
            vizcore3dx.Model.OpenFileDialog();

            RefreshPlasticNodes();
        }

        #endregion

        #region Plastic

        private void ChkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (plasticInitializing == true) return;

            vizcore3dx.View.Plastic.Enable = chkEnable.Checked;

            UpdatePlasticControlState();

            RefreshPlasticNodes();
        }

        private void RdoSelectionColor_CheckedChanged(object sender, EventArgs e)
        {
            if (plasticInitializing == true) return;
            if (rdoSelectionColor.Checked == false) return;
            if (vizcore3dx.View.Plastic.Enable == false) return;

            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            vizcore3dx.View.Plastic.ColorType = VIZCore3DX.NET.Data.PlasticColorTypes.SELECTION_COLOR;
        }

        private void RdoObjectColor_CheckedChanged(object sender, EventArgs e)
        {
            if (plasticInitializing == true) return;
            if (rdoObjectColor.Checked == false) return;
            if (vizcore3dx.View.Plastic.Enable == false) return;

            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            vizcore3dx.View.Plastic.ColorType = VIZCore3DX.NET.Data.PlasticColorTypes.OBJECT_COLOR;
        }

        private void CboSelectionObject3DType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (plasticInitializing == true) return;
            if (cboSelectionObject3DType.SelectedItem == null) return;
            if (vizcore3dx.View.Plastic.Enable == false) return;

            vizcore3dx.View.Plastic.SelectionObject3DType = (VIZCore3DX.NET.Data.SelectionObject3DTypes)cboSelectionObject3DType.SelectedItem;
        }

        private void BtnApplyPlastic_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.GetSelectedObjects().OfType<VIZCore3DX.NET.Data.Node>().ToList();

            if (nodes.Count == 0)
            {
                MessageBox.Show("모델에서 Plastic으로 검토할 노드를 먼저 선택하세요.", "Plastic Focus Review", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (vizcore3dx.View.Plastic.Enable == false)
            {
                vizcore3dx.View.Plastic.Enable = true;

                plasticInitializing = true;
                chkEnable.Checked = true;
                plasticInitializing = false;

                UpdatePlasticControlState();
            }

            vizcore3dx.View.Plastic.Select(nodes, true, chkSetPivot.Checked);

            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            RefreshPlasticNodes();
        }

        private void BtnRemovePlastic_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = lstPlasticNodes.SelectedItems.Cast<object>().OfType<VIZCore3DX.NET.Data.Node>().ToList();

            if (nodes.Count == 0)
            {
                MessageBox.Show("Plastic 목록에서 해제할 노드를 선택하세요.", "Plastic Focus Review", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            vizcore3dx.View.Plastic.Select(nodes, false, false);

            RefreshPlasticNodes();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            vizcore3dx.View.Plastic.Clear();

            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            RefreshPlasticNodes();
        }

        private void RefreshPlasticNodes()
        {
            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.View.Plastic.GetSelectedNode();

            lstPlasticNodes.BeginUpdate();
            lstPlasticNodes.Items.Clear();

            if (nodes != null)
            {
                foreach (VIZCore3DX.NET.Data.Node node in nodes)
                {
                    if (node == null) continue;

                    lstPlasticNodes.Items.Add(node);
                }
            }

            lstPlasticNodes.EndUpdate();

            lblPlasticCount.Text = string.Format("Plastic 노드 : {0}", nodes == null ? 0 : nodes.Count);
        }

        private void UpdatePlasticControlState()
        {
            bool enable = vizcore3dx.View.Plastic.Enable;

            rdoSelectionColor.Enabled = enable;
            rdoObjectColor.Enabled = enable;
            cboSelectionObject3DType.Enabled = enable;
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