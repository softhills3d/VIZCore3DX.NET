using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.Osnap
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
            //LicenseResults result = vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            LicenseResults result = vizcore3dx.License.LicenseServer("192.168.100.252", 8901);

            // ================================================================
            // License
            // ================================================================
            if (result != LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();

            // 스냅 옵션 설정
            osnap.PlaneSnap = ckSurface.Checked;
            osnap.EdgeEndpointSnap = ckVertex.Checked;
            osnap.EdgeMidpointSnap = ckVertex.Checked;
            osnap.LineSnap = ckLine.Checked;
            osnap.CircleSnap = ckCircle.Checked;
            osnap.CircleCenterSnap = ckCircle.Checked;
            osnap.CylinderSnap = ckCircle.Checked;
            osnap.CommandText = "측정할 요소를 선택하세요.";

            vizcore3dx.Focus();

            // 사용자가 화면에서 선택할 때까지 대기
            OsnapResult result = await osnap.GetResultAsync();
            if (result == null || result.Position == null) return;

            Vector3D point = result.Position;
            Vector3D start = null;
            Vector3D end = null;
            Vector3D center = null;
            Vector3D normal = null;

            // 선택한 형상 정보 조회
            switch (result.Type)
            {
                case GeometryType.Line:
                    if (result.Line == null) break;

                    start = result.Line.Start3D.ToVector3D();
                    end = result.Line.End3D.ToVector3D();
                    center = result.Line.Center;
                    break;

                case GeometryType.Facet:
                    if (result.Facet == null) break;

                    start = point;
                    end = point;
                    center = point;
                    normal = result.Facet.Normal;
                    break;

                case GeometryType.Circle:
                    if (result.Circle == null) break;

                    center = result.Circle.Center.ToVector3D();
                    start = center;
                    end = center;
                    normal = result.Circle.Normal;
                    break;

                case GeometryType.Point:
                    if (result.Point == null) break;

                    center = new Vector3D(result.Point);
                    start = center;
                    end = center;
                    break;
            }

            // 선택 결과를 목록에 표시
            lvOsnap.BeginUpdate();
            lvOsnap.Items.Add(new ListViewItem(new string[]
            {
                result.Type.ToString(),
                point?.ToString() ?? string.Empty,
                start?.ToString() ?? string.Empty,
                end?.ToString() ?? string.Empty,
                center?.ToString() ?? string.Empty,
                normal?.ToString() ?? string.Empty
            }));
            lvOsnap.EndUpdate();

            if (ckAddNote.Checked == false) return;

            // 선택 위치에 노트 생성
            Vertex3D surfacePt = point.ToVertex3D();
            Vertex3D notePt = new Vertex3D(point.X + 100.0f, point.Y + 100.0f, point.Z + 100.0f);

            vizcore3dx.Note.AddNoteSurface(point.ToString(), notePt, surfacePt, false);
        }
    }
}