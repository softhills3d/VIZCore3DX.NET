using System;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.Osnap2DPoint
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DXControl vizcore3dx;

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

        private async void btnShowOsnap_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Object3D.GetNodeCount() <= 0) return;

            // 2D 좌표 확인을 위한 상단 고정 뷰 설정
            vizcore3dx.View.MoveCamera(CameraDirection.Z_PLUS);
            vizcore3dx.View.RotationAngle = 0.0f;
            vizcore3dx.View.EnableAnimation = false;
            vizcore3dx.View.EnableAutoFit = false;
            vizcore3dx.View.SetCameraMode(CameraMode.FixedUpOrbit);

            // 점 스냅만 활성화
            OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();
            osnap.EdgeEndpointSnap = true;
            osnap.EdgeMidpointSnap = true;
            osnap.PlaneSnap = false;
            osnap.LineSnap = false;
            osnap.CircleSnap = false;
            osnap.CircleCenterSnap = false;
            osnap.CylinderSnap = false;
            osnap.CommandText = "Osnap 할 지점을 선택하세요.";

            vizcore3dx.Focus();

            OsnapResult result = await osnap.GetResultAsync();
            if (result?.Position == null) return;

            // 선택 위치의 XY 좌표를 노트로 표시
            Vertex3D surfacePos = result.Position.ToVertex3D();
            Vertex3D notePos = new Vertex3D(surfacePos.X, surfacePos.Y + 500.0f, surfacePos.Z);
            string text = string.Format("{0:F2}, {1:F2}", surfacePos.X, surfacePos.Y);

            vizcore3dx.Note.AddNoteSurface(text, notePos, surfacePos, false);
        }
    }
}