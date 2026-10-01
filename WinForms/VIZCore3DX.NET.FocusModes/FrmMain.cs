using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.FocusModes
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 모드 종류 (라디오 순서와 같음)
        private enum FocusMode { XRay, Plastic, Transparent }

        // 컨트롤 값을 코드에서 바꾸는 동안 핸들러가 뷰어에 되돌려 쓰지 않도록 막습니다.
        private bool _syncing;

        public FrmMain()
        {
            InitializeComponent();

            // 뷰어와 무관한 콤보 항목은 생성자에서 채웁니다. 채우는 동안은 핸들러가 뷰어를 건드리지 않습니다.
            _syncing = true;
            cmbObjectType.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.SelectionObject3DTypes));
            cmbAlphaLevel.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.AlphaLevel));
            _syncing = false;

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

            ReadModeToControls();
            SetStatus("모델을 열어 주세요.");
        }

        #region 1. 모델
        // 모델 파일을 열고 적용 목록을 비웁니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (!vizcore3dx.Model.OpenFileDialog()) return;

            RefreshList();
            SetStatus("모델을 열었습니다. 뷰에서 노드를 선택하세요.");
        }
        #endregion

        #region 2. 모드
        // 모드를 바꾸면 다른 두 모드는 지우고 끕니다. 한 번에 하나만 켭니다.
        private void rdoMode_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;
            RadioButton rdo = sender as RadioButton;
            if (rdo == null || !rdo.Checked) return;

            foreach (FocusMode other in Enum.GetValues(typeof(FocusMode)))
            {
                if (other == CurrentMode) continue;
                ClearMode(other);
                SetEnable(other, false);
            }

            // 켜기 체크는 모드와 함께 따라옵니다.
            if (chkEnable.Checked) SetEnable(CurrentMode, true);

            ReadModeToControls();
            RefreshList();
            SetStatus(ModeName(CurrentMode) + " 모드로 바꿨습니다.");
        }

        // 현재 모드를 켜거나 끕니다.
        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            SetEnable(CurrentMode, chkEnable.Checked);
            RefreshList();
            SetStatus(string.Format("{0} 모드를 {1}.", ModeName(CurrentMode), chkEnable.Checked ? "켰습니다" : "껐습니다"));
        }

        // 강조 색을 선택 색상 또는 원본 색상으로 바꿉니다.
        private void rdoColorType_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;
            if (!rdoSelectionColor.Checked && !rdoObjectColor.Checked) return;

            SetColorType(CurrentMode, rdoSelectionColor.Checked);
        }

        // 강조 대상 형상 종류를 바꿉니다.
        private void cmbObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_syncing || cmbObjectType.SelectedItem == null) return;

            SetObjectType(CurrentMode, (VIZCore3DX.NET.Data.SelectionObject3DTypes)cmbObjectType.SelectedItem);
        }

        // X-Ray 투명도를 바꿉니다.
        private void cmbAlphaLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_syncing || cmbAlphaLevel.SelectedItem == null) return;

            vizcore3dx.View.XRay.AlphaLevel = (VIZCore3DX.NET.Data.AlphaLevel)cmbAlphaLevel.SelectedItem;
        }

        // X-Ray 엣지 표시를 켜거나 끕니다.
        private void chkEdgeRendering_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.XRay.EdgeRendering = chkEdgeRendering.Checked;
        }
        #endregion

        #region 3. 적용
        // 뷰에서 선택한 노드를 현재 모드의 강조 대상으로 넣습니다. 모드가 꺼져 있으면 켭니다.
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);
            if (nodes.Count == 0)
            {
                SetStatus("뷰에서 노드를 먼저 선택하세요.");
                return;
            }

            // 핸들러가 Enable 을 켭니다.
            if (!chkEnable.Checked) chkEnable.Checked = true;

            SelectNodes(CurrentMode, nodes, true, chkPivot.Checked);

            // 일반 선택 색이 강조 결과를 덮지 않도록 선택을 풉니다.
            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            RefreshList();
            SetStatus(string.Format("{0} 모드에 {1}개 노드를 적용했습니다.", ModeName(CurrentMode), nodes.Count));
        }
        #endregion

        #region 4. 적용 목록
        // 목록에서 고른 노드만 강조 대상에서 뺍니다.
        private void btnRemove_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = lstNodes.SelectedItems.OfType<VIZCore3DX.NET.Data.Node>().ToList();
            if (nodes.Count == 0)
            {
                SetStatus("목록에서 해제할 노드를 선택하세요.");
                return;
            }

            SelectNodes(CurrentMode, nodes, false, false);
            RefreshList();
            SetStatus(string.Format("{0}개 노드를 해제했습니다.", nodes.Count));
        }

        // 현재 모드의 강조 대상을 다시 읽어옵니다.
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        // 목록 항목을 더블클릭하면 그 노드로 카메라를 이동합니다.
        private void lstNodes_DoubleClick(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.Node node = lstNodes.SelectedItem as VIZCore3DX.NET.Data.Node;
            if (node == null) return;

            vizcore3dx.View.FlyToObject3d(new List<VIZCore3DX.NET.Data.Node> { node });
        }
        #endregion

        #region 5. 정리
        // 현재 모드의 강조 대상을 모두 지웁니다. 모드는 켜진 채로 둡니다.
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearMode(CurrentMode);
            RefreshList();
            SetStatus("현재 모드의 강조를 지웠습니다.");
        }

        // 세 모드를 모두 지우고 끕니다.
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            foreach (FocusMode mode in Enum.GetValues(typeof(FocusMode)))
            {
                ClearMode(mode);
                SetEnable(mode, false);
            }

            _syncing = true;
            chkEnable.Checked = false;
            _syncing = false;

            RefreshList();
            SetStatus("모든 모드를 끄고 지웠습니다.");
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

        private FocusMode CurrentMode => rdoPlastic.Checked ? FocusMode.Plastic : rdoTransparent.Checked ? FocusMode.Transparent : FocusMode.XRay;

        private static string ModeName(FocusMode mode)
        {
            switch (mode)
            {
                case FocusMode.Plastic: return "플라스틱";
                case FocusMode.Transparent: return "반투명";
                default: return "X-Ray";
            }
        }

        // 세 Manager 는 같은 멤버를 갖지만 공통 형식이 없어 switch 로 나눕니다.
        private void SetEnable(FocusMode mode, bool enable)
        {
            switch (mode)
            {
                case FocusMode.Plastic: vizcore3dx.View.Plastic.Enable = enable; break;
                case FocusMode.Transparent: vizcore3dx.View.Transparent.Enable = enable; break;
                default: vizcore3dx.View.XRay.Enable = enable; break;
            }
        }

        private bool GetEnable(FocusMode mode)
        {
            switch (mode)
            {
                case FocusMode.Plastic: return vizcore3dx.View.Plastic.Enable;
                case FocusMode.Transparent: return vizcore3dx.View.Transparent.Enable;
                default: return vizcore3dx.View.XRay.Enable;
            }
        }

        private void SetColorType(FocusMode mode, bool selectionColor)
        {
            switch (mode)
            {
                case FocusMode.Plastic:
                    vizcore3dx.View.Plastic.ColorType = selectionColor ? VIZCore3DX.NET.Data.PlasticColorTypes.SELECTION_COLOR : VIZCore3DX.NET.Data.PlasticColorTypes.OBJECT_COLOR;
                    break;
                case FocusMode.Transparent:
                    vizcore3dx.View.Transparent.ColorType = selectionColor ? VIZCore3DX.NET.Data.TransparentColorTypes.SELECTION_COLOR : VIZCore3DX.NET.Data.TransparentColorTypes.OBJECT_COLOR;
                    break;
                default:
                    vizcore3dx.View.XRay.ColorType = selectionColor ? VIZCore3DX.NET.Data.XRayColorTypes.SELECTION_COLOR : VIZCore3DX.NET.Data.XRayColorTypes.OBJECT_COLOR;
                    break;
            }
        }

        private bool GetIsSelectionColor(FocusMode mode)
        {
            switch (mode)
            {
                case FocusMode.Plastic: return vizcore3dx.View.Plastic.ColorType == VIZCore3DX.NET.Data.PlasticColorTypes.SELECTION_COLOR;
                case FocusMode.Transparent: return vizcore3dx.View.Transparent.ColorType == VIZCore3DX.NET.Data.TransparentColorTypes.SELECTION_COLOR;
                default: return vizcore3dx.View.XRay.ColorType == VIZCore3DX.NET.Data.XRayColorTypes.SELECTION_COLOR;
            }
        }

        private void SetObjectType(FocusMode mode, VIZCore3DX.NET.Data.SelectionObject3DTypes type)
        {
            switch (mode)
            {
                case FocusMode.Plastic: vizcore3dx.View.Plastic.SelectionObject3DType = type; break;
                case FocusMode.Transparent: vizcore3dx.View.Transparent.SelectionObject3DType = type; break;
                default: vizcore3dx.View.XRay.SelectionObject3DType = type; break;
            }
        }

        private VIZCore3DX.NET.Data.SelectionObject3DTypes GetObjectType(FocusMode mode)
        {
            switch (mode)
            {
                case FocusMode.Plastic: return vizcore3dx.View.Plastic.SelectionObject3DType;
                case FocusMode.Transparent: return vizcore3dx.View.Transparent.SelectionObject3DType;
                default: return vizcore3dx.View.XRay.SelectionObject3DType;
            }
        }

        private void SelectNodes(FocusMode mode, List<VIZCore3DX.NET.Data.Node> nodes, bool selection, bool pivot)
        {
            switch (mode)
            {
                case FocusMode.Plastic: vizcore3dx.View.Plastic.Select(nodes, selection, pivot); break;
                case FocusMode.Transparent: vizcore3dx.View.Transparent.Select(nodes, selection, pivot); break;
                default: vizcore3dx.View.XRay.Select(nodes, selection, pivot); break;
            }
        }

        private List<VIZCore3DX.NET.Data.Node> GetNodes(FocusMode mode)
        {
            switch (mode)
            {
                case FocusMode.Plastic: return vizcore3dx.View.Plastic.GetSelectedNode();
                case FocusMode.Transparent: return vizcore3dx.View.Transparent.GetSelectedNode();
                default: return vizcore3dx.View.XRay.GetSelectedNode();
            }
        }

        private void ClearMode(FocusMode mode)
        {
            switch (mode)
            {
                case FocusMode.Plastic: vizcore3dx.View.Plastic.Clear(); break;
                case FocusMode.Transparent: vizcore3dx.View.Transparent.Clear(); break;
                default: vizcore3dx.View.XRay.Clear(); break;
            }
        }

        // 현재 모드의 뷰어 값을 컨트롤에 읽어옵니다. X-Ray 전용 컨트롤은 X-Ray 일 때만 활성화합니다.
        private void ReadModeToControls()
        {
            _syncing = true;
            try
            {
                chkEnable.Checked = GetEnable(CurrentMode);

                bool selectionColor = GetIsSelectionColor(CurrentMode);
                rdoSelectionColor.Checked = selectionColor;
                rdoObjectColor.Checked = !selectionColor;

                cmbObjectType.SelectedItem = GetObjectType(CurrentMode);

                bool xray = CurrentMode == FocusMode.XRay;
                cmbAlphaLevel.Enabled = xray;
                chkEdgeRendering.Enabled = xray;
                lblAlphaLevel.Enabled = xray;
                if (xray)
                {
                    cmbAlphaLevel.SelectedItem = vizcore3dx.View.XRay.AlphaLevel;
                    chkEdgeRendering.Checked = vizcore3dx.View.XRay.EdgeRendering;
                }
            }
            finally
            {
                _syncing = false;
            }
        }

        // 현재 모드가 강조 중인 노드를 목록에 다시 채웁니다.
        private void RefreshList()
        {
            List<VIZCore3DX.NET.Data.Node> nodes = GetNodes(CurrentMode) ?? new List<VIZCore3DX.NET.Data.Node>();

            lstNodes.BeginUpdate();
            try
            {
                lstNodes.Items.Clear();
                lstNodes.DisplayMember = "NodeName";
                lstNodes.Items.AddRange(nodes.ToArray());
            }
            finally
            {
                lstNodes.EndUpdate();
            }

            grpList.Text = string.Format("4. 적용 목록 ({0})", nodes.Count);
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
