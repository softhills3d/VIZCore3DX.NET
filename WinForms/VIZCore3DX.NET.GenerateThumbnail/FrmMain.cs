using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VIZCore3DX.NET.GenerateThumbnail
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;
        private ImageList imageList;

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            // license 인증
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            imageList = new ImageList();
            imageList.ImageSize = new Size(128, 128);
            lvThumbnail.LargeImageList = imageList;
            imageList.ColorDepth = ColorDepth.Depth32Bit;
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Filter = vizcore3dx.Model.OpenFilter;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            GenerateThumbnail(dlg.FileNames);
        }

        private void GenerateThumbnail(string[] fileNames)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                foreach (string item in fileNames)
                {
                    // 다음 파일 준비
                    vizcore3dx.Model.Close();

                    // 모델 열기
                    vizcore3dx.Model.Open(item);

                    // 화면 맞춤
                    vizcore3dx.View.FitToView();

                    // 렌더링 완료 대기
                    Application.DoEvents();

                    // 캡처
                    Image img = vizcore3dx.View.CaptureImage();

                    if (img == null)
                    {
                        Console.WriteLine("CAPTURE FAIL");
                        continue;
                    }

                    // ImageList에 바로 추가
                    imageList.Images.Add(img);

                    // 리스트뷰 아이템 생성
                    ListViewItem lvi = new ListViewItem(
                        Path.GetFileNameWithoutExtension(item).ToUpper(),
                        imageList.Images.Count - 1
                    );

                    lvi.Tag = item;

                    lvThumbnail.Items.Add(lvi);

                    // 이미지 해제
                    img.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("썸네일 생성 중 오류 발생 : " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void lvThumbnail_DoubleClick(object sender, EventArgs e)
        {
            if (lvThumbnail.SelectedItems.Count == 0) return;

            ListViewItem lvi = lvThumbnail.SelectedItems[0];
            string file = (string)lvi.Tag;

            if (File.Exists(file) == false) return;

            vizcore3dx.Model.Open(file);
        }
    }
}