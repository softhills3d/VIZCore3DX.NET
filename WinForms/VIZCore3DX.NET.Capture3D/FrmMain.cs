using System;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.Capture3D
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx_MiniView;
        public FrmMain()
        {
            InitializeComponent();
            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            // 저장된 사용자 설정(UserSetting.ini)을 무시하고 항상 기본 설정으로 시작 (컨트롤 Load 전에 설정)
            vizcore3dx.LoadSavedSettingOnStartup = false;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);
            // MiniView
            vizcore3dx_MiniView = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx_MiniView.Dock = DockStyle.Fill;
            vizcore3dx_MiniView.LoadSavedSettingOnStartup = false;
            groupBox2.Controls.Add(vizcore3dx_MiniView);

            //License
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
            vizcore3dx_MiniView.OnInitializedVIZCore3DX += VIZCore3DX_MiniView_OnInitializedVIZCore3DX;
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
        }
        private void VIZCore3DX_MiniView_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================
            // 라이선스 파일을 통한 인증
            //vizcore3dx_MiniView.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx_MiniView.License.LicenseServer("127.0.0.1", 8901);

            // ================================================================
            // License
            // ================================================================
            // VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx_MiniView.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");
            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("MINI LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 미니 뷰는 화면만 표시 (리본 / 툴바 / 상태바 숨김)
            vizcore3dx_MiniView.RibbonMode = false;
            vizcore3dx_MiniView.View.Toolbar.Enable = false;           // 화면 안 세로 뷰 툴바 (홈 / 확대 / 이동 / 회전 / 설정)
            vizcore3dx_MiniView.ModelingControlVisible = false;        // 모델링 컨트롤 패널 (우측 하단 X 로고)
            vizcore3dx_MiniView.ToolbarMain.Visible = false;
            vizcore3dx_MiniView.ToolbarNote.Visible = false;
            vizcore3dx_MiniView.ToolbarMeasure.Visible = false;
            vizcore3dx_MiniView.ToolbarSection.Visible = false;
            vizcore3dx_MiniView.ToolbarSnapshot.Visible = false;
            vizcore3dx_MiniView.Statusbar.Visible = false;
            vizcore3dx_MiniView.View.PreSelect.Enable = false;
            vizcore3dx_MiniView.EnableProgressForm = false;
            vizcore3dx_MiniView.EnableWaitForm = false;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            CameraData camera = vizcore3dx.View.GetCameraData();
            if (camera == null) return;

            CameraItem item = new CameraItem
            {
                Camera = camera
            };

            AddCameraItem(item);
        }

        private void AddCameraItem(CameraItem item)
        {
            if (item == null) return;
            if (item.Camera == null) return;

            ListViewItem lvi = new ListViewItem(new string[]{
                string.Format("{0:F4},{1:F4},{2:F4}",item.Camera.CameraDirection.X,item.Camera.CameraDirection.Y,item.Camera.CameraDirection.Z),item.Camera.Zoom.ToString()

            });

            lvi.Tag = item;
            lvList.Items.Add(lvi);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (lvList.SelectedItems.Count == 0) return;

            CameraItem item = lvList.SelectedItems[0].Tag as CameraItem;
            if (item == null) return;
            if (item.Camera == null) return;

            if (OpenMainModelToMiniView() == false) return;

            vizcore3dx_MiniView.View.SetCameraData(item.Camera);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lvList.Items.Clear();
        }

        private void lvList_DoubleClick(object sender, EventArgs e)
        {
            if (lvList.SelectedItems.Count == 0) return;

            CameraItem item = lvList.SelectedItems[0].Tag as CameraItem;
            if (item == null) return;
            if (item.Camera == null) return;

            // 메인뷰 카메라 복원
            vizcore3dx.View.SetCameraData(item.Camera);

            // 미니뷰에 같은 모델 열고 같은 카메라 적용
            if (OpenMainModelToMiniView() == false) return;

            vizcore3dx_MiniView.View.SetCameraData(item.Camera);

        }

        private bool OpenMainModelToMiniView()
        {
            if (vizcore3dx.Model.IsOpen() == false) return false;
            if (vizcore3dx.Model.Files == null) return false;
            if (vizcore3dx.Model.Files.Count == 0) return false;

            if (vizcore3dx_MiniView.Model.IsOpen() == false)
            {
                vizcore3dx_MiniView.Model.Open(vizcore3dx.Model.Files[0]);
            }

            return true;
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
