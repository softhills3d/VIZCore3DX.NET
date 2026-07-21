using System;
using System.Windows.Forms;

namespace VIZCore3DX.NET.CaptureImage
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

            // license 인증
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
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("192.168.100.252", 8901);


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


            // Init. Example
            InitExample();
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
        private void InitExample()
        {
            txtPath.Text = System.IO.Path.Combine(
                System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                , "VIZCore3D.NET"
                );

            if (System.IO.Directory.Exists(txtPath.Text) == false)
                System.IO.Directory.CreateDirectory(txtPath.Text);

            EnableRenderingEffect(true);
        }

        private void EnableRenderingEffect(bool enable)
        {
            vizcore3dx.View.PhongShading = enable;
            vizcore3dx.View.SilhouetteEdge = enable;
            vizcore3dx.View.RealtimeShadow = enable;
            vizcore3dx.View.ShadingEffect = enable;
            vizcore3dx.View.EnvironmentLight = enable;
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            if (string.IsNullOrEmpty(txtPath.Text) == false)
                dlg.SelectedPath = txtPath.Text;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            txtPath.Text = dlg.SelectedPath;

        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (lvImage.Items.Count == 0) return;

            for (int i = 0; i < lvImage.Items.Count; i++)
            {
                ListViewItem lvi = lvImage.Items[i];
                if (lvi.Tag == null) return;

                System.Drawing.Image img = (System.Drawing.Image)lvi.Tag;
                img.Save(
                    string.Format(
                        "{0}\\VIZCore.NET.{1}.{2}.png"
                        , txtPath.Text
                        , i + 1
                        , DateTime.Now.ToString("yyyyMMddHHmmss")
                        )
                    , System.Drawing.Imaging.ImageFormat.Png
                    );
            }

            VIZCore3DX.NET.Utility.ExplorerHelper.ShowPath(txtPath.Text);
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            // ViewManager에서 Background Color 조정. 현재 버전에서는 지원하지 않음

            System.Drawing.Image img = vizcore3dx.View.CaptureImage();


            imgThumb.Images.Add(img);

            ListViewItem lvi = new ListViewItem("", imgThumb.Images.Count - 1);
            lvi.Tag = img;

            lvImage.Items.Add(lvi);

            lvImage.EnsureVisible(lvImage.Items.Count - 1);

        }

        private void btnCaptureAuto_Click(object sender, EventArgs e)
        {
            CaptureAuto(Data.CameraDirection.ISO_PLUS);
            CaptureAuto(Data.CameraDirection.ISO_MINUS);
            CaptureAuto(Data.CameraDirection.X_PLUS);
            CaptureAuto(Data.CameraDirection.X_MINUS);
            CaptureAuto(Data.CameraDirection.Y_PLUS);
            CaptureAuto(Data.CameraDirection.Y_MINUS);
            CaptureAuto(Data.CameraDirection.Z_PLUS);
            CaptureAuto(Data.CameraDirection.Z_MINUS);
        }

        private void CaptureAuto(Data.CameraDirection camera)
        {
            // 작업 시작 전 마우스 커서를 모래시계로 변경
            this.Cursor = Cursors.WaitCursor;

            // 3D 뷰어 화면 갱신을 차단, 리스트뷰 갱신 최적화
            vizcore3dx.BeginUpdate();
            lvImage.BeginUpdate();

            try
            {
                // 카메라 방향 이동
                vizcore3dx.View.MoveCamera(camera);
                Application.DoEvents();
                // 전체 화면 캡쳐
                System.Drawing.Image img = vizcore3dx.View.CaptureImage();
                if (img != null)
                {
                    // 추출한 이미지를 이미지 리스트에 저장
                    imgThumb.Images.Add(img);

                    // 리스트뷰 아이템 생성 및 태그 설정
                    ListViewItem lvi = new ListViewItem("", imgThumb.Images.Count - 1);
                    lvi.Tag = img;

                    lvImage.Items.Add(lvi);
                    lvImage.EnsureVisible(lvImage.Items.Count - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("썸네일 생성 중 오류 발생: " + ex.Message, "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 차단했던 3D 화면 및 리스트뷰 갱신 재시작
                lvImage.EndUpdate();
                vizcore3dx.EndUpdate();

                // 마우스 커서를 원래대로
                this.Cursor = Cursors.Default;
            }
        }
    }
}
