using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.RotateModel
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DXControl vizcore3dx;

        // 트랙바 이벤트 중복 등록 방지
        private bool trackBarEventEnabled = true;

        private int XOffset = 0;
        private int YOffset = 0;
        private int ZOffset = 0;

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DXControl();
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
            LicenseResults result = vizcore3dx.License.LicenseServer("192.168.100.252", 8901);

            // ================================================================
            // License
            // ================================================================
            // LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");
            if (result != LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 모델 로드
            InitializeVIZCore3DX();
            InitializeVIZCore3DXEvent();
        }

        private void InitializeVIZCore3DX()
        {
            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 차단
            // ================================================================
            vizcore3dx.BeginUpdate();

            try
            {
                // ================================================================
                // 설정 - 툴바
                // ================================================================
                vizcore3dx.ToolbarMain.Visible = true;
                vizcore3dx.ToolbarNote.Visible = false;
                vizcore3dx.ToolbarMeasure.Visible = false;
                vizcore3dx.ToolbarSection.Visible = false;
                vizcore3dx.ToolbarSnapshot.Visible = false;
            }
            finally
            {
                // ================================================================
                // 모델 열기 시, 3D 화면 Rendering 재시작
                // ================================================================
                vizcore3dx.EndUpdate();
            }
        }

        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.View.OnViewDefaultMouseDownEvent += View_OnViewDefaultMouseDownEvent;
            vizcore3dx.View.OnViewDefaultMouseMoveEvent += View_OnViewDefaultMouseMoveEvent;
            vizcore3dx.View.OnViewDefaultMouseUpEvent += View_OnViewDefaultMouseUpEvent;
        }

        private void AddEventHandler(bool enable)
        {
            if (enable == trackBarEventEnabled) return;

            if (enable == true)
            {
                tbX.Scroll += tbX_Scroll;
                tbY.Scroll += tbY_Scroll;
                tbZ.Scroll += tbZ_Scroll;
            }
            else
            {
                tbX.Scroll -= tbX_Scroll;
                tbY.Scroll -= tbY_Scroll;
                tbZ.Scroll -= tbZ_Scroll;
            }

            trackBarEventEnabled = enable;
        }

        private void View_OnViewDefaultMouseDownEvent(object sender, MouseEventArgs e)
        {
            AddEventHandler(false);
        }
        private void View_OnViewDefaultMouseMoveEvent(object sender, MouseEventArgs e)
        {
            CameraData cameraData = vizcore3dx.View.GetCameraData();
            if (cameraData == null) return;

            // 현재 카메라의 시선 방향과 위쪽 방향을 기준으로 직교 축 계산
            Vector3D normal = new Vector3D(cameraData.CameraDirection).GetNormalized();
            Vector3D cameraUp = new Vector3D(cameraData.UpDirection).GetNormalized();
            Vector3D planeX = Vector3D.Cross(cameraUp, normal).GetNormalized();
            Vector3D planeY = Vector3D.Cross(normal, planeX).GetNormalized();

            // 카메라 회전 방향만 Matrix로 구성
            Matrix3D matrix = new Matrix3D();
            matrix.SetAxisTransform(planeX, planeY, normal, true);

            // Matrix에서 X/Y/Z 회전각 추출
            Vector3D rotation = matrix.GetRotation();

            int x = Convert.ToInt32(rotation.X);
            int y = Convert.ToInt32(rotation.Y);
            int z = Convert.ToInt32(rotation.Z);

            // 각도를 0~359 범위로 변환
            x = ((x % 360) + 360) % 360;
            y = ((y % 360) + 360) % 360;
            z = ((z % 360) + 360) % 360;

            // TrackBar 범위를 벗어나지 않도록 제한
            x = Math.Max(tbX.Minimum, Math.Min(tbX.Maximum, x));
            y = Math.Max(tbY.Minimum, Math.Min(tbY.Maximum, y));
            z = Math.Max(tbZ.Minimum, Math.Min(tbZ.Maximum, z));

            tbX.Value = x;
            tbY.Value = y;
            tbZ.Value = z;

            XOffset = x;
            YOffset = y;
            ZOffset = z;

            txtX.Text = x.ToString();
            txtY.Text = y.ToString();
            txtZ.Text = z.ToString();
        }

        private void View_OnViewDefaultMouseUpEvent(object sender, MouseEventArgs e)
        {
            AddEventHandler(true);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string path = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\SAMPLE.vizx"));

            if (File.Exists(path) == true)
            {
                txtPath.Text = path;

                txtMatrix.Text = "0.957904591,-0.000000000,-0.287086738,0.000000000,-0.283075368,0.166583667,-0.944520099,0.000000000,0.047823961,0.986027323,0.159571259,0.000000000,-178018.006091000,-812.822710430,66890.223468829,1.000000000";
            }
            else
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "VIZX (*.vizx)|*.vizx";
                    if (dlg.ShowDialog() != DialogResult.OK) return;

                    txtPath.Text = dlg.FileName;
                }
            }

            if (File.Exists(txtPath.Text) == false)
            {
                MessageBox.Show("모델 파일을 찾을 수 없습니다.");
                return;
            }

            vizcore3dx.Model.Open(txtPath.Text);

            List<Node> roots = vizcore3dx.Object3D.GetRootNodes();
            string matrix = txtMatrix.Text;

            if (roots == null || roots.Count == 0)
            {
                MessageBox.Show("Matrix를 적용할 루트 노드가 없습니다.");
                return;
            }

            if (String.IsNullOrEmpty(matrix) == false)
            {
                Matrix3D m;

                try
                {
                    m = Matrix3D.FromString(matrix, ",");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Matrix 값을 변환할 수 없습니다.\r\n\r\n{0}", ex.Message));
                    return;
                }

                if (m == null)
                {
                    MessageBox.Show("Matrix 값을 변환할 수 없습니다.");
                    return;
                }

                vizcore3dx.BeginUpdate();

                try
                {
                    foreach (Node root in roots)
                    {
                        root.Transform(m, true);
                    }
                }
                finally
                {
                    vizcore3dx.EndUpdate();
                }
            }

            vizcore3dx.View.MoveCamera(CameraDirection.Z_PLUS);
            vizcore3dx.View.FitToView();

            XOffset = tbX.Value;
            YOffset = tbY.Value;
            ZOffset = tbZ.Value;

            txtX.Text = tbX.Value.ToString();
            txtY.Text = tbY.Value.ToString();
            txtZ.Text = tbZ.Value.ToString();
        }

        private void tbX_Scroll(object sender, EventArgs e)
        {
            RotateNode();
        }

        private void tbY_Scroll(object sender, EventArgs e)
        {
            RotateNode();
        }

        private void tbZ_Scroll(object sender, EventArgs e)
        {
            RotateNode();
        }

        private void RotateNode()
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            int x = tbX.Value - XOffset;
            int y = tbY.Value - YOffset;
            int z = tbZ.Value - ZOffset;

            XOffset = tbX.Value;
            YOffset = tbY.Value;
            ZOffset = tbZ.Value;

            txtX.Text = tbX.Value.ToString();
            txtY.Text = tbY.Value.ToString();
            txtZ.Text = tbZ.Value.ToString();

            vizcore3dx.View.RotateCameraByAxis(x, y, z);
        }
    }
}