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
            splitContainer1.Panel2.Controls.Add(vizcore3dx);
            // MiniView
            vizcore3dx_MiniView = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx_MiniView.Dock = DockStyle.Fill;
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
            vizcore3dx.ToolbarMain.Visible = true;
            vizcore3dx.ToolbarNote.Visible = false;
            vizcore3dx.ToolbarMeasure.Visible = false;
            vizcore3dx.ToolbarSection.Visible = false;
            vizcore3dx.ToolbarSnapshot.Visible = false;

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
    }
}
