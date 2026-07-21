using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.Projection2D
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DXControl vizcore3dx;
        private ResultControl result;

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            // License
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            // 2D 투영 결과 화면 구성
            result = new ResultControl();
            result.SetVIZCore3DX(vizcore3dx);
            result.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(result);
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // 라이선스 서버를 통한 인증
            LicenseResults licenseResult = vizcore3dx.License.LicenseServer("192.168.100.252", 8901);

            if (licenseResult != LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", licenseResult), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeVIZCore3DX();
        }

        private void InitializeVIZCore3DX()
        {
            // 모델 열기 시 화면 갱신을 차단하고 툴바를 설정
            vizcore3dx.BeginUpdate();

            vizcore3dx.ToolbarMain.Visible = true;
            vizcore3dx.ToolbarNote.Visible = false;
            vizcore3dx.ToolbarMeasure.Visible = false;
            vizcore3dx.ToolbarSection.Visible = false;
            vizcore3dx.ToolbarSnapshot.Visible = false;

            vizcore3dx.EndUpdate();
        }

        private void btnProjection2D_Click(object sender, EventArgs e)
        {
            if (vizcore3dx == null || vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 로드해 주세요.");
                return;
            }

            vizcore3dx.ShowWaitForm();

            try
            {
                result.SetData();
            }
            finally
            {
                vizcore3dx.CloseWaitForm();
            }
        }

        private void btnSetModelMatrix_Click(object sender, EventArgs e)
        {
            if (vizcore3dx == null || vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 로드해 주세요.");
                return;
            }

            // 16개 텍스트박스에서 4×4 Matrix 값을 가져옴
            float[] values = new float[16];
            int valueIndex = 0;

            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    string controlName = string.Format("txtM{0}{1}", row, column);
                    TextBox textBox = this.Controls.Find(controlName, true).FirstOrDefault() as TextBox;

                    if (textBox == null)
                    {
                        MessageBox.Show(string.Format("{0} 컨트롤을 찾을 수 없습니다.", controlName));
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(textBox.Text) == true) textBox.Text = "0";

                    float value;

                    if (float.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out value) == false && float.TryParse(textBox.Text, out value) == false)
                    {
                        MessageBox.Show(string.Format("{0} 값이 숫자가 아닙니다.", controlName));
                        textBox.Focus();
                        return;
                    }

                    values[valueIndex++] = value;
                }
            }

            Matrix3D matrix = new Matrix3D(
                values[0], values[1], values[2], values[3],
                values[4], values[5], values[6], values[7],
                values[8], values[9], values[10], values[11],
                values[12], values[13], values[14], values[15]);

            // 전체 모델의 루트 노드에 Matrix를 적용
            List<Node> nodes = vizcore3dx.Object3D.GetRootNodes();

            if (nodes == null || nodes.Count == 0)
            {
                MessageBox.Show("Matrix를 적용할 노드가 없습니다.");
                return;
            }

            vizcore3dx.BeginUpdate();

            try
            {
                vizcore3dx.Object3D.Transform.Transform(nodes, matrix, true);
                vizcore3dx.View.FitToView();
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            result.SetData();
        }

        private void btnPasteMatrix_Click(object sender, EventArgs e)
        {
            if (vizcore3dx == null || vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 로드해 주세요.");
                return;
            }

            CameraData cameraData = vizcore3dx.View.GetCameraData();

            if (cameraData == null)
            {
                MessageBox.Show("카메라 데이터를 가져올 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 카메라의 Pivot, 시선 방향, 위쪽 방향을 기준으로 직교 축을 계산
            Vector3D pivot = new Vector3D(cameraData.PivotPosition);
            Vector3D normal = new Vector3D(cameraData.CameraDirection).GetNormalized();
            Vector3D cameraUp = new Vector3D(cameraData.UpDirection).GetNormalized();
            Vector3D planeX = Vector3D.Cross(cameraUp, normal).GetNormalized();
            Vector3D planeY = Vector3D.Cross(normal, planeX).GetNormalized();

            // 계산한 카메라 축과 Pivot 위치로 변환 Matrix를 생성
            Matrix3D matrix = new Matrix3D();
            matrix.SetAxisTransform(planeX, planeY, normal, true);
            matrix.SetTranslate(pivot, true);

            // 생성된 Matrix 값을 4×4 텍스트박스에 입력
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    TextBox textBox = this.Controls.Find(string.Format("txtM{0}{1}", row, column), true).FirstOrDefault() as TextBox;
                    if (textBox == null) continue;

                    textBox.Text = matrix.Matrix[(row * 4) + column].ToString("F2", CultureInfo.InvariantCulture);
                }
            }

            result.SetData();
        }
    }
}