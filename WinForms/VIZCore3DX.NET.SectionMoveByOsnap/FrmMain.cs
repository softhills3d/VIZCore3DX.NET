using System;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.SectionMoveByOsnap
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
            vizcore3dx.ToolbarSection.Visible = true;
            vizcore3dx.ToolbarSnapshot.Visible = false;
            vizcore3dx.ToolbarDecal.Visible = false;
            vizcore3dx.ToolbarPrimitive.Visible = false;


            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }

        private void btnCreate_Section_Click(object sender, EventArgs e)
        {
            if (!vizcore3dx.Model.IsOpen()) return;
            vizcore3dx.Section.Clear();
            VIZCore3DX.NET.Data.SectionItem section = vizcore3dx.Section.Add();
        }

        private void bntSection_Clear_Click(object sender, EventArgs e)
        {
            if (!vizcore3dx.Model.IsOpen()) return;
            vizcore3dx.Section.Clear();
        }

        private async void btnSection_Position_Click(object sender, EventArgs e)
        {
            if (!vizcore3dx.Model.IsOpen() || vizcore3dx.Section.Sections == null) return;
            Data.OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();
            osnap.CommandText = "이동 할 지점을 선택하세요.";

            Data.OsnapResult position = await osnap.GetResultAsync();

            // 선택한 Osnap 위치로 Section Plane 위치 이동
            vizcore3dx.Section.SetSectionPosition(vizcore3dx.Section.Sections[0].ID, position.Position);
        }

        private void btnX_Axis_Click(object sender, EventArgs e)
        {
            if (!vizcore3dx.Model.IsOpen() || vizcore3dx.Section.Sections == null) return;
            vizcore3dx.Section.SetSectionDirection(vizcore3dx.Section.Sections[0].ID, Data.SectionPlaneDirectionType.XPlus);
        }

        private void btnY_Axis_Click(object sender, EventArgs e)
        {
            if (!vizcore3dx.Model.IsOpen() || vizcore3dx.Section.Sections == null) return;
            vizcore3dx.Section.SetSectionDirection(vizcore3dx.Section.Sections[0].ID, Data.SectionPlaneDirectionType.YPlus);
        }

        private void btnZ_Axis_Click(object sender, EventArgs e)
        {
            if (!vizcore3dx.Model.IsOpen() || vizcore3dx.Section.Sections == null) return;
            vizcore3dx.Section.SetSectionDirection(vizcore3dx.Section.Sections[0].ID, Data.SectionPlaneDirectionType.ZPlus);

        }
    }
}
