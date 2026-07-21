using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.CustomAxisRotation
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        private Vertex3D v1 = null;
        private Vertex3D v2 = null;
        private float angle = 0.0f;

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

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = vizcore3dx.Model.OpenFilter;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            // 기존 모델 닫기
            if (vizcore3dx.Model.IsOpen() == true) vizcore3dx.Model.Close();

            // 모델 열기
            bool result = vizcore3dx.Model.Open(dlg.FileName);

            if (result == false)
            {
                MessageBox.Show("모델 열기 실패");
                return;
            }

            vizcore3dx.View.FitToView();

        }

        private async void btnShowOsnap_Click(object sender, EventArgs e)
        {
            if (vizcore3dx == null || vizcore3dx.Model.IsOpen() == false) return;

            OsnapController osnap1 = vizcore3dx.GeometryUtility.Osnap();
            if (osnap1 == null) return;

            osnap1.CommandText = "회전축 첫 번째 점 선택";
            OsnapResult r1 = await osnap1.GetResultAsync();
            if (r1 == null) return;

            v1 = new Vertex3D(r1.Position.X, r1.Position.Y, r1.Position.Z);
            txtV1.Text = $"{v1.X}, {v1.Y}, {v1.Z}";

            OsnapController osnap2 = vizcore3dx.GeometryUtility.Osnap();
            if (osnap2 == null) return;

            osnap2.CommandText = "회전축 두 번째 점 선택";
            OsnapResult r2 = await osnap2.GetResultAsync();
            if (r2 == null) return;

            v2 = new Vertex3D(r2.Position.X, r2.Position.Y, r2.Position.Z);
            txtV2.Text = $"{v2.X}, {v2.Y}, {v2.Z}";
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            timerAnimation.Enabled = false;

            txtV1.Text = String.Empty;
            txtV2.Text = String.Empty;

            v1 = null;
            v2 = null;

            angle = 0.0f;
            totalAngle = 0;
        }

        private int totalAngle = 0;

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (vizcore3dx == null || vizcore3dx.Model.IsOpen() == false) return;
            if (v1 == null || v2 == null) return;

            int start = Convert.ToInt32(txtStart.Text);
            int end = Convert.ToInt32(txtEnd.Text);

            angle = start;
            totalAngle = end;

            timerAnimation.Enabled = true;
        }
        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            timerAnimation.Enabled = false;

            if (v1 == null || v2 == null) return;

            if (angle >= totalAngle) return;

            List<Node> nodes = vizcore3dx.Object3D.GetRootNodes();
            if (nodes == null || nodes.Count == 0) return;

            vizcore3dx.BeginUpdate();

            try
            {
                vizcore3dx.Object3D.Transform.Rotate(nodes, v1, v2, angle % 360.0f, false);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            angle += 3.0f;

            timerAnimation.Enabled = true;
        }
    }
}
