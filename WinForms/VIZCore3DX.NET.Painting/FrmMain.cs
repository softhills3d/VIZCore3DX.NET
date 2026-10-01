using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;
using VIZCore3DX.NET.Utility;

namespace VIZCore3DX.NET.Painting
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DXControl vizcore3dx;
        private ColorPaletteHelper palette;

        // 색상 변경에 따른 노드 이벤트 중복 호출 방지
        private bool _isApplyingColor = false;

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DXControl();
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

            InitializeVIZCore3DX();
            InitializeVIZCore3DXEvent();
            SetPaletteColor();
            SetPaletteName();
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
            ShowAttributeTabs();

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }

        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.Object3D.OnNodeEvent += Object3D_OnNodeEvent;
        }

        private void SetPaletteColor()
        {
            btnSelectColor1.BackColor = Color.FromArgb(128, 0, 0);
            btnSelectColor2.BackColor = Color.Black;
            btnSelectColor3.BackColor = Color.FromArgb(255, 239, 187);
        }

        private void SetPaletteName()
        {
            palette = new ColorPaletteHelper();
            List<string> names = palette.GetPaletteNames();

            cbPalette.Items.Clear();

            if (names == null || names.Count == 0)
            {
                cbPalette.Enabled = false;
                return;
            }

            cbPalette.Items.AddRange(names.ToArray());
            cbPalette.SelectedIndex = 0;
            cbPalette.Enabled = true;
        }

        private void Object3D_OnNodeEvent(object sender, EventManager.NodeEventArgs e)
        {
            if (ckSetColorByDefaultColor.Checked == false || _isApplyingColor == true || vizcore3dx.Model.IsOpen() == false) return;

            Color? color = rbColor1.Checked ? btnSelectColor1.BackColor : rbColor2.Checked ? btnSelectColor2.BackColor : rbColor3.Checked ? btnSelectColor3.BackColor : (Color?)null;
            if (color.HasValue == false) return;

            _isApplyingColor = true;

            try
            {
                vizcore3dx.Object3D.Color.SetColor(color.Value);
            }
            finally
            {
                _isApplyingColor = false;
            }
        }


        private void btnSelectColor1_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.AllowFullOpen = true;
                dlg.ShowHelp = true;
                dlg.Color = btnSelectColor1.BackColor;

                if (dlg.ShowDialog() != DialogResult.OK) return;

                btnSelectColor1.BackColor = dlg.Color;
            }
        }

        private void btnSelectColor2_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.AllowFullOpen = true;
                dlg.ShowHelp = true;
                dlg.Color = btnSelectColor2.BackColor;

                if (dlg.ShowDialog() != DialogResult.OK) return;

                btnSelectColor2.BackColor = dlg.Color;
            }
        }

        private void btnSelectColor3_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.AllowFullOpen = true;
                dlg.ShowHelp = true;
                dlg.Color = btnSelectColor3.BackColor;

                if (dlg.ShowDialog() != DialogResult.OK) return;

                btnSelectColor3.BackColor = dlg.Color;
            }
        }

        private void btnSetColor1_Click(object sender, EventArgs e)
        {
            vizcore3dx.Object3D.Color.SetColor(btnSelectColor1.BackColor);
        }

        private void btnSetColor2_Click(object sender, EventArgs e)
        {
            vizcore3dx.Object3D.Color.SetColor(btnSelectColor2.BackColor);
        }

        private void btnSetColor3_Click(object sender, EventArgs e)
        {
            vizcore3dx.Object3D.Color.SetColor(btnSelectColor3.BackColor);
        }

        private void btnSetColorSelectedObject_Click(object sender, EventArgs e)
        {
            List<Node> items = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP);
            if (items == null || items.Count == 0) return;

            if (ckChildren.Checked == true)
            {
                List<Node> children = new List<Node>();

                foreach (Node item in items)
                {
                    List<Node> child = vizcore3dx.Object3D.GetChildObject3d(item, Object3DChildOption.CHILD_ONLY);
                    if (child != null && child.Count > 0) children.AddRange(child);
                }

                SetPaletteColor(children);
            }
            else
            {
                SetPaletteColor(items);
            }
        }

        private void SetPaletteColor(List<Node> items)
        {
            if (items == null || items.Count == 0 || palette == null || cbPalette.SelectedIndex < 0) return;

            palette.SetPaletteIndex(cbPalette.SelectedIndex);
            vizcore3dx.BeginUpdate();

            for (int i = 0; i < items.Count; i++)
                vizcore3dx.Object3D.Color.SetColor(new List<Node> { items[i] }, palette.GetPaletteColor(i).Color1);

            vizcore3dx.EndUpdate();
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
    }
}