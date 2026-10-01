using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.FocusTransparent
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        private bool transparentInitializing = false;

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

            transparentInitializing = true;

            chkEnable.Checked = vizcore3dx.View.Transparent.Enable;

            cboSelectionObject3DType.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.SelectionObject3DTypes));
            cboSelectionObject3DType.SelectedItem = vizcore3dx.View.Transparent.SelectionObject3DType;

            vizcore3dx.View.SelectionColor = Color.Red;

            rdoSelectionColor.Checked = vizcore3dx.View.Transparent.ColorType == VIZCore3DX.NET.Data.TransparentColorTypes.SELECTION_COLOR;
            rdoObjectColor.Checked = vizcore3dx.View.Transparent.ColorType == VIZCore3DX.NET.Data.TransparentColorTypes.OBJECT_COLOR;

            lstFocusedNodes.DisplayMember = "NodeName";

            UpdateSelectionStyle();

            transparentInitializing = false;

            RefreshFocusedNodes();
        }

        #region Model

        private void BtnOpenModel_Click(object sender, EventArgs e)
        {
            vizcore3dx.Model.OpenFileDialog();

            RefreshFocusedNodes();
        }

        #endregion

        #region Transparent

        private void ChkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (transparentInitializing == true) return;

            vizcore3dx.View.Transparent.Enable = chkEnable.Checked;

            UpdateSelectionStyle();

            RefreshFocusedNodes();
        }

        private void UpdateSelectionStyle()
        {
            bool enable = vizcore3dx.View.Transparent.Enable;

            rdoSelectionColor.Enabled = enable;
            rdoObjectColor.Enabled = enable;

            if (enable == false)
            {
                vizcore3dx.View.SelectionColor = Color.Red;
                vizcore3dx.View.SelectionColorEnabled = true;
                vizcore3dx.View.SelectionOutlineEnabled = false;
                return;
            }

            if (vizcore3dx.View.Transparent.ColorType == VIZCore3DX.NET.Data.TransparentColorTypes.SELECTION_COLOR)
            {
                vizcore3dx.View.SelectionColor = Color.Red;
                vizcore3dx.View.SelectionColorEnabled = true;
                vizcore3dx.View.SelectionOutlineEnabled = false;
            }
            else
            {
                vizcore3dx.View.SelectionColorEnabled = false;
                vizcore3dx.View.SelectionOutlineEnabled = true;
            }
        }

        private void RdoSelectionColor_CheckedChanged(object sender, EventArgs e)
        {
            if (transparentInitializing == true) return;
            if (rdoSelectionColor.Checked == false) return;
            if (vizcore3dx.View.Transparent.Enable == false) return;

            // 기존 일반 선택 Highlight 제거
            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            vizcore3dx.View.Transparent.ColorType = VIZCore3DX.NET.Data.TransparentColorTypes.SELECTION_COLOR;

            UpdateSelectionStyle();
        }

        private void RdoObjectColor_CheckedChanged(object sender, EventArgs e)
        {
            if (transparentInitializing == true) return;
            if (rdoObjectColor.Checked == false) return;
            if (vizcore3dx.View.Transparent.Enable == false) return;

            // 일반 선택 Highlight 제거
            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            vizcore3dx.View.Transparent.ColorType = VIZCore3DX.NET.Data.TransparentColorTypes.OBJECT_COLOR;

            UpdateSelectionStyle();
        }

        private void CboSelectionObject3DType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (transparentInitializing == true) return;
            if (cboSelectionObject3DType.SelectedItem == null) return;

            vizcore3dx.View.Transparent.SelectionObject3DType = (VIZCore3DX.NET.Data.SelectionObject3DTypes)cboSelectionObject3DType.SelectedItem;
        }

        private void BtnApplyFocus_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.GetSelectedObjects().OfType<VIZCore3DX.NET.Data.Node>().ToList();

            if (nodes.Count == 0)
            {
                MessageBox.Show("모델에서 Focus할 노드를 먼저 선택하세요.", "Focus Transparent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 현재 선택한 노드를 Focus 상태로 설정
            vizcore3dx.View.Transparent.Select(nodes, true, false);

            // 일반 Object3D 선택 상태 제거
            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            RefreshFocusedNodes();
        }

        private void BtnRemoveFocus_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = lstFocusedNodes.SelectedItems.Cast<object>().OfType<VIZCore3DX.NET.Data.Node>().ToList();

            if (nodes.Count == 0)
            {
                MessageBox.Show("Focus 목록에서 해제할 노드를 선택하세요.", "Focus Transparent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 선택한 Focus 노드만 해제
            vizcore3dx.View.Transparent.Select(nodes, false, false);

            RefreshFocusedNodes();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            vizcore3dx.View.Transparent.Clear();

            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            RefreshFocusedNodes();
        }

        private void RefreshFocusedNodes()
        {
            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.View.Transparent.GetSelectedNode();

            lstFocusedNodes.BeginUpdate();
            lstFocusedNodes.Items.Clear();

            if (nodes != null)
            {
                foreach (VIZCore3DX.NET.Data.Node node in nodes)
                {
                    if (node == null) continue;

                    lstFocusedNodes.Items.Add(node);
                }
            }

            lstFocusedNodes.EndUpdate();

            lblFocusedCount.Text = string.Format("Focus 노드 : {0}", nodes == null ? 0 : nodes.Count);
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