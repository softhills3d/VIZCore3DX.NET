using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.MeasureFrame
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

            // License
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
            string path = @"C:\project\VIZCore3DX.NET-main\bin\Debug\H1195_V303.vizx";

            if (System.IO.File.Exists(path) == true)
                vizcore3dx.Model.Open(path);
            else
                vizcore3dx.Model.OpenFileDialog();
        }

        private void btnOpenFrame_Click(object sender, EventArgs e)
        {
            // DMP 파일 경로를 지정 열기 미존재
            string path = @"C:\project\VIZCore3DX.NET-main\bin\Debug\H1195.DMP";
            bool result;

            if (System.IO.File.Exists(path) == true)
                result = vizcore3dx.Frame.OpenTribon(path);
            else
                result = vizcore3dx.Frame.OpenTribonFileDialog();

            if (result == false) return;

            vizcore3dx.Frame.Visible = true;
        }

        private async void btnShowOsnap_Click(object sender, EventArgs e)
        {
            var osnap = vizcore3dx.GeometryUtility.Osnap();
            osnap.CircleCenterSnap = true;   // 원 중심점 스냅 - "점"
            osnap.CircleSnap = false;        // 원 스냅
            osnap.CylinderSnap = false;      // 원통 스냅
            osnap.EdgeEndpointSnap = true;   // 모서리 끝점 스냅 - "점"
            osnap.EdgeMidpointSnap = true;   // 모서리 중간점 스냅 - "점"
            osnap.LineSnap = false;          // 모서리(라인) 스냅
            osnap.PlaneSnap = false;         // 평면 스냅

            vizcore3dx.Focus();

            // 여기서 사용자가 화면에서 Osnap 선택할 때까지 기다림
            OsnapResult result = await osnap.GetResultAsync();

            txtX.Text = result.Position.X.ToString();
            txtY.Text = result.Position.Y.ToString();
            txtZ.Text = result.Position.Z.ToString();
        }

        private void btnShowFrame_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false || vizcore3dx.Frame.HasFrame == false) return;

            vizcore3dx.BeginUpdate();

            try
            {
                // 현재 Frame 정보
                FrameItem baseFrame = vizcore3dx.Frame.GetFrame(-1);
                Vertex3D v = new Vertex3D(txtX.Text, txtY.Text, txtZ.Text);
                NoteCustomStyle textOnlyStyle = CreateTextOnlyNoteStyle();

                FrameSnapResult xSnap = vizcore3dx.Frame.GetSnap(Axis.X, (float)v.X);
                FrameSnapResult ySnap = vizcore3dx.Frame.GetSnap(Axis.Y, (float)v.Y);
                FrameSnapResult zSnap = vizcore3dx.Frame.GetSnap(Axis.Z, (float)v.Z);

                float xFramePos = baseFrame.XAxis.GetFrameLines().First(x => x.ID == xSnap.LineID).Offset;
                float yFramePos = baseFrame.YAxis.GetFrameLines().First(x => x.ID == ySnap.LineID).Offset;
                float zFramePos = baseFrame.ZAxis.GetFrameLines().First(x => x.ID == zSnap.LineID).Offset;

                // X
                {
                    vizcore3dx.Shape.CreateLineSegmentShape(
                        new Line3D()
                        {
                            Start3D = new Vertex3D(v.X, v.Y, v.Z),
                            End3D = new Vertex3D(v.X, v.Y - 2000.0f, v.Z)
                        },
                        4.0f,
                        StrokePattern.Dashed,
                        Color.Red);

                    vizcore3dx.Shape.CreateLineSegmentShape(
                        new Line3D()
                        {
                            Start3D = new Vertex3D(xFramePos, v.Y, v.Z),
                            End3D = new Vertex3D(xFramePos, v.Y - 2000.0f, v.Z)
                        },
                        4.0f,
                        StrokePattern.Dashed,
                        Color.Red);

                    vizcore3dx.Shape.CreateArrowShape(
                        new Vector3D(v.X, v.Y - 1000.0f, v.Z),
                        new Vector3D(xFramePos, v.Y - 1000.0f, v.Z),
                        5.0f,
                        Color.Yellow);

                    vizcore3dx.Note.AddNoteSurface(
                        Math.Abs(xFramePos - (float)v.X).ToString("0"),
                        (v.X + xFramePos) / 2, v.Y - 950.0f, v.Z,
                        (v.X + xFramePos) / 2, v.Y - 950.0f, v.Z,
                        textOnlyStyle);

                    vizcore3dx.Note.AddNoteSurface(
                        $"(X) {xSnap.AxisLabel}{xSnap.LineID}",
                        xFramePos, v.Y - 2050.0f, v.Z,
                        xFramePos, v.Y - 2050.0f, v.Z,
                        textOnlyStyle);
                }

                // Y
                {
                    vizcore3dx.Shape.CreateLineSegmentShape(
                        new Line3D()
                        {
                            Start3D = new Vertex3D(v.X, v.Y, v.Z),
                            End3D = new Vertex3D(v.X - 2000.0f, v.Y, v.Z)
                        },
                        4.0f,
                        StrokePattern.Dashed,
                        Color.Black);

                    vizcore3dx.Shape.CreateLineSegmentShape(
                        new Line3D()
                        {
                            Start3D = new Vertex3D(v.X, yFramePos, v.Z),
                            End3D = new Vertex3D(v.X - 2000.0f, yFramePos, v.Z)
                        },
                        4.0f,
                        StrokePattern.Dashed,
                        Color.Black);

                    vizcore3dx.Shape.CreateArrowShape(
                        new Vector3D(v.X - 1000.0f, v.Y, v.Z),
                        new Vector3D(v.X - 1000.0f, yFramePos, v.Z),
                        5.0f,
                        Color.Yellow);

                    vizcore3dx.Note.AddNoteSurface(
                        Math.Abs(yFramePos - v.Y).ToString(),
                        v.X - 950.0f, (v.Y + yFramePos) / 2, v.Z,
                        v.X - 950.0f, (v.Y + yFramePos) / 2, v.Z,
                        textOnlyStyle);

                    vizcore3dx.Note.AddNoteSurface(
                        $"(Y) {ySnap.AxisLabel}{ySnap.LineID}",
                        v.X - 2050.0f, yFramePos, v.Z,
                        v.X - 2050.0f, yFramePos, v.Z,
                        textOnlyStyle);
                }

                // Z
                {
                    vizcore3dx.Shape.CreateLineSegmentShape(
                        new Line3D()
                        {
                            Start3D = new Vertex3D(v.X, v.Y, zFramePos),
                            End3D = new Vertex3D(v.X, v.Y - 2000.0f, zFramePos)
                        },
                        4.0f,
                        StrokePattern.Dashed,
                        Color.Blue);

                    vizcore3dx.Shape.CreateArrowShape(
                        new Vector3D(v.X, v.Y - 800.0f, v.Z),
                        new Vector3D(v.X, v.Y - 800.0f, zFramePos),
                        5.0f,
                        Color.Yellow);

                    vizcore3dx.Note.AddNoteSurface(
                        (zFramePos - v.Z).ToString(),
                        v.X, v.Y - 750.0f, (v.Z + zFramePos) / 2,
                        v.X, v.Y - 750.0f, (v.Z + zFramePos) / 2,
                        textOnlyStyle);

                    vizcore3dx.Note.AddNoteSurface(
                        $"(Z) {zSnap.AxisLabel}{zSnap.LineID}",
                        v.X, v.Y - 2050.0f, zFramePos,
                        v.X, v.Y - 2050.0f, zFramePos,
                        textOnlyStyle);
                }

                string xFrame = $"{xSnap.AxisLabel}{xSnap.LineID}{(xSnap.OffsetDifference >= 0 ? "+" : "")}{Math.Round(xSnap.OffsetDifference)} mm";
                string yFrame = $"{ySnap.AxisLabel}{ySnap.LineID}{(ySnap.OffsetDifference >= 0 ? "+" : "")}{Math.Round(ySnap.OffsetDifference)} mm";
                string zFrame = $"{zSnap.AxisLabel}{zSnap.LineID}{(zSnap.OffsetDifference >= 0 ? "+" : "")}{Math.Round(zSnap.OffsetDifference)} mm";

                vizcore3dx.Note.AddNoteSurface(
                    $"좌표\r\nX = {xFrame}\r\nY = {yFrame}\r\nZ = {zFrame}",
                    new Vertex3D(v.X + 500.0f, v.Y + 500.0f, v.Z),
                    v,
                    false);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        } // btnShowFrame_Click

        private NoteCustomStyle CreateTextOnlyNoteStyle()
        {
            NoteCustomStyle style = vizcore3dx.Note.CreateCustomStyle();

            // 박스 제거
            style.BoxFillColor = Color.Transparent;
            style.BoxStrokeColor = Color.Transparent;

            // 글씨만 표시
            style.TextColor = Color.Black;
            style.TextSize = TextSizeType.Size_18;

            // 지시선 제거
            style.LineStrokeColor = Color.Transparent;
            style.LineStrokeThickness = 0.0f;

            // 심벌 제거
            style.SymbolFillColor = Color.Transparent;
            style.SymbolStrokeColor = Color.Transparent;
            style.SymbolTextColor = Color.Transparent;
            style.SymbolSize = 0.0f;

            // 화살표 제거
            style.ArrowColor = Color.Transparent;
            style.ArrowHeadSize = 0.0f;

            return style;
        }
    }
}