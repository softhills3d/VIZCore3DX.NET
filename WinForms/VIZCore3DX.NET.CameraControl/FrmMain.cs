using System;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.CameraControl
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

        private void btnBackupCamera_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            CameraData cam = vizcore3dx.View.GetCameraData();
            if (cam == null) return;

            CameraItem item = new CameraItem
            {
                EyePosition = cam.EyePosition,
                PivotPosition = cam.PivotPosition,
                CameraDirection = cam.CameraDirection,
                UpDirection = cam.UpDirection,
                Zoom = cam.Zoom,
                Snapshot = vizcore3dx.View.CaptureImage()
            };

            AddCameraItem(item);

        }

        private void AddCameraItem(CameraItem camera)
        {
            ListViewItem lvi = new ListViewItem(new string[] {
                camera.Zoom.ToString(),
                string.Format(
                    "{0:F4}, {1:F4}, {2:F4}",
                    camera.CameraDirection.X,
                    camera.CameraDirection.Y,
                    camera.CameraDirection.Z
                    )
            });

            lvi.Tag = camera;
            lvCamera.Items.Add(lvi);

            pbSnapshot.Image = camera.Snapshot;
        }

        private void lvCamera_DoubleClick(object sender, EventArgs e)
        {
            if (lvCamera.SelectedItems.Count == 0) return;
            if ((lvCamera.SelectedItems[0].Tag is CameraItem item) == false) return;

            CameraData cam = vizcore3dx.View.GetCameraData();
            if (cam == null) return;

            cam.EyePosition = item.EyePosition;
            cam.PivotPosition = item.PivotPosition;
            cam.CameraDirection = item.CameraDirection;
            cam.UpDirection = item.UpDirection;
            cam.Zoom = item.Zoom;
            cam.ProjectionType = item.ProjectionType;

            vizcore3dx.View.SetCameraData(cam);
            pbSnapshot.Image = item.Snapshot;

            if (ckFitToView.Checked == true)
                vizcore3dx.View.FitToView();

        }
    }
}
