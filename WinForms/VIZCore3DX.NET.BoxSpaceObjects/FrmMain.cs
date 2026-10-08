using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static VIZCore3DX.NET.Event.EventManager;

namespace VIZCore3DX.NET.BoxSpaceObjects
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DXControl vizcore3dx;
        private int SelectionBox = -1;

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(vizcore3dx);

            // License
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

            if (result != Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            ShowRibbonTabs(VIZCore3DX.NET.Data.ToolbarKind.SelectionBox);
            ShowAttributeTabs();

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }

        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.SelectionBox.OnSelectionBoxSelectedEvent -= SelectionBox_OnSelected;
            vizcore3dx.SelectionBox.OnSelectionBoxSelectedEvent += SelectionBox_OnSelected;

            vizcore3dx.SelectionBox.OnSelectionBoxDeselectedEvent -= SelectionBox_DeSelected;
            vizcore3dx.SelectionBox.OnSelectionBoxDeselectedEvent += SelectionBox_DeSelected;
        }

        private void SelectionBox_DeSelected(object sender, SelectionBoxEventArgs e)
        {
            // 선택 해제되면 핸들 비활성화
            vizcore3dx.SelectionBox.IsManipulatorEnabled = false;
        }

        private void SelectionBox_OnSelected(object sender, SelectionBoxEventArgs e)
        {
            // 핸들 활성화
            vizcore3dx.SelectionBox.IsManipulatorEnabled = true;
        }

        private void btnAddBox_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            Data.BoundBox3D box = vizcore3dx.Model.BoundBox;

            vizcore3dx.SelectionBox.Clear();

            // 핸들은 선택 전에 미리 활성화
            vizcore3dx.SelectionBox.IsManipulatorEnabled = true;

            SelectionBox = vizcore3dx.SelectionBox.Add(
                box,
                vizcore3dx.SelectionBox.GetTransparencyColor(Color.White, 80),
                vizcore3dx.SelectionBox.DefaultSelectionBoxStrokeColor,
                string.Empty
            );

            // 생성한 선택상자를 선택 상태로 설정해야 핸들이 표시됨
            vizcore3dx.SelectionBox.Select(true);
        }

        private void btnGetZoneObjects_Click(object sender, EventArgs e)
        {
            if (SelectionBox == -1 || cbFilter.SelectedIndex == -1) return;

            // 선택상자가 리본에서 삭제되었거나 모델을 닫은 경우
            var item = vizcore3dx.SelectionBox.GetItem(SelectionBox);
            if (item == null)
            {
                SelectionBox = -1;
                MessageBox.Show("선택상자가 없습니다. 상자를 다시 추가해 주세요.", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Data.BoundBox3D box = item.BoundBox;
            Data.BoundBoxSearchOption option = (Data.BoundBoxSearchOption)cbFilter.SelectedIndex;
            List<Data.Node> items = vizcore3dx.Object3D.FromZone(box, option) ?? new List<Data.Node>();

            dataGridNode.DataSource = items;
            gbObjects.Text = string.Format("Objects - {0:N0}", items.Count);
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