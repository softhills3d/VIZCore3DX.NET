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

            // 모델을 닫거나 새 모델로 바꾸면 캡처 목록 비우기
            vizcore3dx.Model.OnModelClosedEvent += Model_OnModelClosedEvent;
        }

        private void Model_OnModelClosedEvent(object sender, EventArgs e)
        {
            if (InvokeRequired == true)
            {
                BeginInvoke(new Action(ClearImages));
                return;
            }

            ClearImages();
        }

        private void ClearImages()
        {
            lvImage.Items.Clear();
            imgThumb.Images.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvImage.SelectedItems.Count == 0) return;

            foreach (ListViewItem lvi in lvImage.SelectedItems)
                lvImage.Items.Remove(lvi);

            // 썸네일 번호가 어긋나지 않도록 남은 항목으로 이미지 목록을 다시 구성
            imgThumb.Images.Clear();
            foreach (ListViewItem lvi in lvImage.Items)
            {
                imgThumb.Images.Add((System.Drawing.Image)lvi.Tag);
                lvi.ImageIndex = imgThumb.Images.Count - 1;
            }
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

            System.Drawing.Image img = vizcore3dx.View.CaptureImage();


            imgThumb.Images.Add(img);

            ListViewItem lvi = new ListViewItem("", imgThumb.Images.Count - 1);
            lvi.Tag = img;

            lvImage.Items.Add(lvi);

            lvImage.EnsureVisible(lvImage.Items.Count - 1);

        }

        private void btnCaptureRender_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            // 렌더 요청 : 창이 다른 창에 가려져 있어도 렌더 버퍼를 최신 상태로 갱신
            vizcore3dx.View.RequestRender();

            // 렌더 버퍼에서 직접 캡처 (오버레이 포함 여부 지정)
            System.Drawing.Image img = vizcore3dx.View.CaptureRenderImage(chkIncludeOverlay.Checked);
            if (img == null)
            {
                MessageBox.Show("렌더 버퍼 캡처에 실패했습니다.", "VIZCore3DX.NET.CaptureImage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddCaptureImage(img);
        }

        private void AddCaptureImage(System.Drawing.Image img)
        {
            imgThumb.Images.Add(img);

            ListViewItem lvi = new ListViewItem("", imgThumb.Images.Count - 1);
            lvi.Tag = img;

            lvImage.Items.Add(lvi);
            lvImage.EnsureVisible(lvImage.Items.Count - 1);
        }

        private void btnCaptureAuto_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            // 카메라 이동 애니메이션(기본 0.5초)이 끝나기 전에 캡처되어 이전 방향이 찍히지 않도록 애니메이션 끄기
            bool animation = vizcore3dx.View.EnableAnimation;
            vizcore3dx.View.EnableAnimation = false;

            try
            {
                CaptureAutoDirections();
            }
            finally
            {
                vizcore3dx.View.EnableAnimation = animation;
            }
        }

        private void CaptureAutoDirections()
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

            // 리스트뷰 갱신 최적화 (3D 화면은 캡처해야 하므로 갱신을 막지 않음)
            lvImage.BeginUpdate();

            try
            {
                // 카메라 방향 이동
                vizcore3dx.View.MoveCamera(camera);

                // 이동한 카메라로 즉시 다시 그린 뒤 캡처
                vizcore3dx.View.RequestRender();
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
                // 리스트뷰 갱신 재시작
                lvImage.EndUpdate();

                // 마우스 커서를 원래대로
                this.Cursor = Cursors.Default;
            }
        }
    }
}
