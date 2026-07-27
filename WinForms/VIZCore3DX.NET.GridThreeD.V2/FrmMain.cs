using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.GridThreeD.V2
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        private BoundBox3D BoundBox { get; set; }

        // 현재 회전 누적 각도. 타이머 Tick마다 갱신됨.
        private float Block_Rotate_Angle = 0.0f;

        // 회전 대상 노드
        private List<Node> RotateNodes;

        // 회전축을 만들기 위한 두 점.
        private Vertex3D RotateV1;
        private Vertex3D RotateV2;

        // 애니메이션 설정값은 코드 중간에 숫자로 박지 말고 상수로 분리
        private const string BlockNodeName = "GRID_S";
        private const float RotateStepDegree = -5.0f;   // Tick 1회당 회전 각도
        private const float RotateEndDegree = -180.0f;  // 최종 회전 각도

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            //Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            // 타이머 이벤트가 디자이너에서 이미 연결되어 있다면 중복 연결하지 않아도 됨.
            timerAnimation.Tick -= timerAnimation_Tick;
            timerAnimation.Tick += timerAnimation_Tick;

            // 너무 빠르게 돌면 화면 렌더링이 끊겨 보일 수 있음. 필요하면 30~100 사이로 조절.
            timerAnimation.Interval = 50;
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

        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            StopBlockAnimation();

            if (vizcore3dx.Model.IsOpen() == true)
                vizcore3dx.Model.Close();

            string basePath = string.Format("C:\\project\\VIZCore3DX.NET-main\\bin\\Debug", vizcore3dx.GetEntryAssemblyPath());

            string gridPPath = Path.Combine(basePath, "GRID_P.vizx");
            string gridSPath = Path.Combine(basePath, "GRID_S.vizx");

            // 파일이 없으면 Model.Add 전에 바로 중단.
            if (File.Exists(gridPPath) == false)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Multiselect = false; dlg.Filter = vizcore3dx.Model.OpenFilter;
                dlg.Title = "GRID_P.vizx 파일을 선택해 주세요.";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                gridPPath = dlg.FileName;

                if (File.Exists(gridSPath) == false)
                {
                    MessageBox.Show("GRID_P.vizx 파일을 찾을 수 없습니다.\n\n" + gridPPath, "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (File.Exists(gridSPath) == false)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Multiselect = false; dlg.Filter = vizcore3dx.Model.OpenFilter;
                dlg.Title = "GRID_S.vizx 파일을 선택해 주세요.";
                if (dlg.ShowDialog() != DialogResult.OK) return;
                gridSPath = dlg.FileName;

                if (File.Exists(gridSPath) == false)
                {
                    MessageBox.Show("GRID_S.vizx 파일을 찾을 수 없습니다.\n\n" + gridSPath, "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            List<string> paths = new List<string>();
            paths.Add(gridPPath);
            paths.Add(gridSPath);

            bool result = vizcore3dx.Model.Add(paths.ToArray(), true);
            if (result == false || vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델 로드에 실패했습니다.", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BoundBox = vizcore3dx.Model.BoundBox;

            if (BoundBox == null || BoundBox.IsValid() == false)
            {
                MessageBox.Show("모델 BoundBox 정보를 가져올 수 없습니다.", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            if (BoundBox == null || BoundBox.IsValid() == false)
            {
                MessageBox.Show("모델 BoundBox 정보가 없습니다.", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RotateNodes = vizcore3dx.Object3D.Find.QuickSearch(BlockNodeName, true);

            if (RotateNodes == null || RotateNodes.Count == 0)
            {
                MessageBox.Show(BlockNodeName + " 노드를 찾을 수 없습니다.", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float centerY = BoundBox.MinY + (BoundBox.LengthY * 0.5f);

            RotateV1 = new Vertex3D(BoundBox.MinX, centerY, BoundBox.MinZ);
            RotateV2 = new Vertex3D(BoundBox.MaxX, centerY, BoundBox.MinZ);

            Block_Rotate_Angle = 0.0f;

            vizcore3dx.View.SetRenderMode(RenderModes.SMOOTH);

            StartBlockAnimation();
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            if (RotateNodes == null || RotateNodes.Count == 0 || RotateV1 == null || RotateV2 == null)
            {
                StopBlockAnimation();
                return;
            }

            float nextAngle = Block_Rotate_Angle + RotateStepDegree;

            if (nextAngle < RotateEndDegree) nextAngle = RotateEndDegree;

            Block_Rotate_Angle = nextAngle;

            vizcore3dx.BeginUpdate();

            try
            {
                vizcore3dx.Object3D.Transform.Rotate(RotateNodes, RotateV1, RotateV2, Block_Rotate_Angle, true);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            if (Block_Rotate_Angle <= RotateEndDegree) StopBlockAnimation();
        }
        private void StartBlockAnimation()
        {
            timerAnimation.Enabled = true;
        }

        private void StopBlockAnimation()
        {
            timerAnimation.Enabled = false;
        }

    }
}