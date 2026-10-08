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

            // 측정 생성 / 삭제 시 측정 개수 갱신
            vizcore3dx.Measure.OnMeasureCreated += Measure_OnMeasureChanged;
            vizcore3dx.Measure.OnMeasureDeleted += Measure_OnMeasureChanged;
        }

        private void Measure_OnMeasureChanged(object sender, VIZCore3DX.NET.Event.EventManager.MeasureEventArgs e)
        {
            UpdateMeasureCount();
        }

        private void UpdateMeasureCount()
        {
            lblMeasureCount.Text = string.Format("측정 개수 : {0}", vizcore3dx.Measure.GetCount());
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

                // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
                vizcore3dx.RibbonMode = true;
                ShowRibbonTabs(VIZCore3DX.NET.Data.ToolbarKind.Measure);
                ShowAttributeTabs();

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
            vizcore3dx.Model.OpenFileDialog();
        }

        private void btnOpenFrame_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "프레임 파일 (*.dmp;*.xml)|*.dmp;*.xml|모든 파일 (*.*)|*.*";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            // 확장자로 열기 방식을 나눕니다. .dmp 는 Tribon 좌표계, 그 밖(Export 로 저장한 .xml 등)은 Import.
            string ext = System.IO.Path.GetExtension(dlg.FileName).ToLower();
            bool result = ext == ".dmp" ? vizcore3dx.Frame.OpenTribon(dlg.FileName) : vizcore3dx.Frame.Import(dlg.FileName);

            // Import 가 읽지 못한 .xml 은 구 형식(/Frame/Grid)일 수 있어 Tribon 열기로 한 번 더 시도합니다.
            if (result == false && ext == ".xml") result = vizcore3dx.Frame.OpenTribon(dlg.FileName);

            if (result == false)
            {
                MessageBox.Show(string.Format("프레임을 불러오지 못했습니다. ({0})", vizcore3dx.Frame.LastOperationResult), "VIZCore3DX.NET.MeasureFrame", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vizcore3dx.Frame.Visible = true;
        }

        private async void btnShowOsnap_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            var osnap = vizcore3dx.GeometryUtility.Osnap();

            if (osnap == null) return;

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

            if (result == null || result.Position == null) return;

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

                if (baseFrame == null) return;

                Vertex3D v = ReadPosition();
                if (v == null) return;
                NoteCustomStyle textOnlyStyle = CreateTextOnlyNoteStyle();

                FrameSnapResult xSnap = vizcore3dx.Frame.GetSnap(Axis.X, (float)v.X);
                FrameSnapResult ySnap = vizcore3dx.Frame.GetSnap(Axis.Y, (float)v.Y);
                FrameSnapResult zSnap = vizcore3dx.Frame.GetSnap(Axis.Z, (float)v.Z);

                if (xSnap == null || ySnap == null || zSnap == null) return;

                float xFramePos = xSnap.LineOffset;
                float yFramePos = ySnap.LineOffset;
                float zFramePos = zSnap.LineOffset;

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
                        Math.Abs(yFramePos - (float)v.Y).ToString("0"),
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
                        Math.Abs(zFramePos - (float)v.Z).ToString("0"),
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

        // X / Y / Z 입력값을 좌표로 변환 (숫자가 아니면 안내 후 null)
        private Vertex3D ReadPosition()
        {
            float x, y, z;
            if (float.TryParse(txtX.Text, out x) == false || float.TryParse(txtY.Text, out y) == false || float.TryParse(txtZ.Text, out z) == false)
            {
                MessageBox.Show("X / Y / Z 좌표를 숫자로 입력하세요.", "VIZCore3DX.NET.MeasureFrame", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            return new Vertex3D(x, y, z);
        }

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

        // ================================================================
        // 측정 목록 내보내기 / 문자열 저장·복원
        // ================================================================
        private void btnAddDistance_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false || vizcore3dx.Frame.HasFrame == false) return;

            // 입력한 위치에서 축별로 가장 가까운 프레임 라인까지의 거리 측정을 생성
            FrameItem baseFrame = vizcore3dx.Frame.GetFrame(-1);

            if (baseFrame == null) return;

            Vertex3D v = ReadPosition();
            if (v == null) return;
            Vector3D position = v.ToVector3D();

            FrameSnapResult xSnap = vizcore3dx.Frame.GetSnap(Axis.X, (float)v.X);
            FrameSnapResult ySnap = vizcore3dx.Frame.GetSnap(Axis.Y, (float)v.Y);
            FrameSnapResult zSnap = vizcore3dx.Frame.GetSnap(Axis.Z, (float)v.Z);

            if (xSnap == null || ySnap == null || zSnap == null) return;

            float xFramePos = xSnap.LineOffset;
            float yFramePos = ySnap.LineOffset;
            float zFramePos = zSnap.LineOffset;

            // 프레임 라인 위에 있는 축(거리 0)은 생성하지 않음
            if (xFramePos != (float)v.X)
                vizcore3dx.Measure.AddDistanceAxialDirectionX(position, new Vector3D(xFramePos, v.Y, v.Z), 500.0f);

            if (yFramePos != (float)v.Y)
                vizcore3dx.Measure.AddDistanceAxialDirectionY(position, new Vector3D(v.X, yFramePos, v.Z), 500.0f);

            if (zFramePos != (float)v.Z)
                vizcore3dx.Measure.AddDistanceAxialDirectionZ(position, new Vector3D(v.X, v.Y, zFramePos), 500.0f);
        }

        private void btnClearMeasure_Click(object sender, EventArgs e)
        {
            vizcore3dx.Measure.Clear();
            UpdateMeasureCount();
        }

        private void btnExportMeasureCsv_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Measure.GetCount() == 0)
            {
                MessageBox.Show("내보낼 측정이 없습니다.", "VIZCore3DX.NET.MeasureFrame", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "CSV (*.csv)|*.csv";
            dlg.FileName = "Measures.csv";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            // 측정 목록을 CSV 파일로 내보내기
            if (vizcore3dx.Measure.ExportCsv(dlg.FileName) == false)
            {
                ShowLastOperationStatus("측정 목록을 CSV로 내보내지 못했습니다.");
                return;
            }

            MessageBox.Show("측정 목록을 CSV로 내보냈습니다.\n\n" + dlg.FileName, "VIZCore3DX.NET.MeasureFrame", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMeasureToJson_Click(object sender, EventArgs e)
        {
            // 측정 목록을 JSON 문자열로 변환
            string json = vizcore3dx.Measure.ToJson();
            if (string.IsNullOrEmpty(json))
            {
                ShowLastOperationStatus("측정 목록을 JSON 문자열로 변환하지 못했습니다.");
                return;
            }

            txtMeasureJson.Text = json;
        }

        private void btnMeasureFromJson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMeasureJson.Text)) return;

            bool result;

            using (vizcore3dx.BeginUpdateScope())
            {
                // 기존 측정 삭제 후 JSON 문자열로부터 측정 목록 복원
                if (chkClearBeforeFromJson.Checked == true) vizcore3dx.Measure.Clear();

                result = vizcore3dx.Measure.FromJson(txtMeasureJson.Text);
            }

            UpdateMeasureCount();

            if (result == false) ShowLastOperationStatus("JSON 문자열로부터 측정을 복원하지 못했습니다.");
        }

        private void ShowLastOperationStatus(string message)
        {
            OperationStatus status = vizcore3dx.Measure.LastOperationStatus;
            if (status != null && status.Result == OperationResult.OperationCancelled) return;

            string reason = status == null ? "-" : status.Result.ToString();
            MessageBox.Show(string.Format("{0}\n\n사유 : {1}", message, reason), "VIZCore3DX.NET.MeasureFrame", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // 지정한 탭만 남기고 나머지 툴바(=리본 탭)와 모델 트리 패널의 같은 탭을 숨깁니다. 홈 탭·모델 트리는 항상 표시합니다.
        private void ShowRibbonTabs(params VIZCore3DX.NET.Data.ToolbarKind[] keep)
        {
            foreach (VIZCore3DX.NET.Data.ToolbarKind kind in Enum.GetValues(typeof(VIZCore3DX.NET.Data.ToolbarKind)))
                vizcore3dx.Toolbar.SetVisible(kind, kind == VIZCore3DX.NET.Data.ToolbarKind.Main || Array.IndexOf(keep, kind) >= 0);

            vizcore3dx.TabSnapshotEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Snapshot) >= 0;
            vizcore3dx.TabNotetEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Note) >= 0;
            vizcore3dx.TabMeasureEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Measure) >= 0;
            vizcore3dx.TabSectionEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Section) >= 0;
            vizcore3dx.TabDecalEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Decal) >= 0;
            vizcore3dx.TabSelectionBoxEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.SelectionBox) >= 0;
            vizcore3dx.TabZoneEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Zone) >= 0;
            vizcore3dx.TabEffectEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Effect) >= 0;
            vizcore3dx.TabObserverEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Observer) >= 0;
        }

        // 속성 패널은 노드 특성·노드 속성만 기본으로 남기고, 예제가 다루는 탭만 켭니다.
        private void ShowAttributeTabs(bool attributeTree = false, bool nodeGroup = false, bool projection = false, bool pmi = false)
        {
            vizcore3dx.TabAttributeTreeEnabled = attributeTree;
            vizcore3dx.TabNodeGroupEnabled = nodeGroup;
            vizcore3dx.TabProjectionEnabled = projection;
            vizcore3dx.TabPmiEnabled = pmi;
            vizcore3dx.TabEnvironmentEnabled = false;
            vizcore3dx.TabGenericDataEnabled = false;
            vizcore3dx.AttributePanelVisible = attributeTree || nodeGroup || projection || pmi;
        }
    }
}