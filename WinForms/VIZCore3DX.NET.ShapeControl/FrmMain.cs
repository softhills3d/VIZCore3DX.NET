using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.ShapeControl
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;
        private List<ShapeItem> selectedShapes = new List<ShapeItem>();

        public FrmMain()
        {
            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            InitializeComponent();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            pnlViewHost.Controls.Add(vizcore3dx);
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================

            // 라이선스 파일을 통한 인증
            //VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("127.0.0.1", 8901);

            // ================================================================
            // License
            // ================================================================

            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Toolbar
            vizcore3dx.BeginUpdate();

            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();

            vizcore3dx.EndUpdate();

            // Shape Event
            vizcore3dx.Shape.OnShapeSelectedEvent += Shape_OnShapeSelectedEvent;
            vizcore3dx.Shape.OnShapeDeselectedEvent += Shape_OnShapeDeselectedEvent;

            // Shape Setting
            vizcore3dx.Shape.ShapeSelectionRadius = (uint)numSelectionRadius.Value;
            vizcore3dx.Shape.ShapeHighlightedStrokeColor = btnHighlightColor.BackColor;
            vizcore3dx.Shape.ShapeSelectedStrokeColor = btnSelectedColor.BackColor;
            vizcore3dx.Shape.Selectable(chkSelectable.Checked);

            UpdateCreateUI();
            UpdateHeatmapUI();
            UpdateShapeList(vizcore3dx.Shape.Shapes, "전체 목록");
        }

        private void Shape_OnShapeSelectedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ShapeSelectionEventArgs e)
        {
            if (e.Shapes == null || e.Shapes.Count == 0) return;

            selectedShapes = e.Shapes.Where(x => x != null).ToList();
            if (selectedShapes.Count == 1 && selectedShapes[0].Position != null) SetPositionValue(numMoveX, numMoveY, numMoveZ, selectedShapes[0].Position);
            UpdateStatus();
        }

        private void Shape_OnShapeDeselectedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ShapeSelectionEventArgs e)
        {
            selectedShapes.Clear();
            UpdateStatus();
        }

        private void cmbShapeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCreateUI();
        }

        private void cmbCreateMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCreateUI();
        }

        private void SetValueEnabled(bool value1, bool value2, bool value3)
        {
            lblValue1.Enabled = numValue1.Enabled = value1;
            lblValue2.Enabled = numValue2.Enabled = value2;
            lblValue3.Enabled = numValue3.Enabled = value3;
        }

        private void SetCreateOptions(bool stroke, bool segment, bool anchor)
        {
            pnlStroke.Enabled = stroke || segment || anchor;
            lblStrokeThickness.Enabled = numStrokeThickness.Enabled = stroke;
            lblStrokePattern.Enabled = cmbStrokePattern.Enabled = stroke;
            lblSegmentCount.Enabled = numSegmentCount.Enabled = segment;
            lblAxisAnchor.Enabled = cmbAxisAnchor.Enabled = anchor;
        }

        private async Task SetOsnapPosition(string command, NumericUpDown x, NumericUpDown y, NumericUpDown z)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();
            osnap.CommandText = command;
            OsnapResult result = await osnap.GetResultAsync();
            if (result != null) SetPositionValue(x, y, z, result.Position);
        }

        private void SetPositionValue(NumericUpDown x, NumericUpDown y, NumericUpDown z, Vector3D position)
        {
            x.Value = Math.Max(x.Minimum, Math.Min(x.Maximum, (decimal)position.X));
            y.Value = Math.Max(y.Minimum, Math.Min(y.Maximum, (decimal)position.Y));
            z.Value = Math.Max(z.Minimum, Math.Min(z.Maximum, (decimal)position.Z));
        }

        private Color? SelectColor(Button button)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = button.BackColor;
                if (dialog.ShowDialog() != DialogResult.OK) return null;
                button.BackColor = dialog.Color;
                return dialog.Color;
            }
        }

        private bool TryGetSelectedBoundBox(out BoundBox3D boundBox)
        {
            List<Node> nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP);
            boundBox = nodes.Count == 0 ? null : vizcore3dx.Object3D.GetBoundBox(nodes);
            return boundBox != null;
        }

        private void UpdateCreateUI()
        {
            string type = cmbShapeType.Text;

            if (type == "선분 집합" && cmbCreateMode.SelectedIndex != 0) cmbCreateMode.SelectedIndex = 0;

            string mode = cmbCreateMode.Text;

            cmbCreateMode.Enabled = type != "선분 집합";
            pnlLineSegments.Visible = false;
            pnlPoint3.Visible = true;
            pnlValues.Visible = true;

            lblPoint1Title.Text = "기준점";
            lblPoint2Title.Text = "보조점";
            lblPoint3Title.Text = "세 번째 점";
            lblValue1.Text = "값 1";
            lblValue2.Text = "값 2";
            lblValue3.Text = "값 3";

            pnlPoint1.Enabled = true;
            pnlPoint2.Enabled = false;
            pnlPoint3.Enabled = false;
            pnlValues.Enabled = true;
            pnlRotation.Enabled = mode == "위치·회전" && new[] { "선분", "폴리라인", "원", "사각형", "삼각형", "박스", "원통", "구", "평면" }.Contains(type);

            SetValueEnabled(true, false, false);
            SetCreateOptions(false, false, false);

            numValue1.Value = 1000;
            numValue2.Value = 1000;
            numValue3.Value = 1000;

            switch (type)
            {
                case "점":
                    lblPoint1Title.Text = "위치";
                    lblValue1.Text = "점 크기";
                    numValue1.Value = 6;
                    lblCreateHint.Text = "점 : 위치 + 화면 픽셀 크기(4~10) + 색상";
                    break;

                case "선분":
                    lblPoint1Title.Text = mode == "위치·회전" ? "배치 위치" : "시작점";
                    lblPoint2Title.Text = "끝점";
                    pnlPoint2.Enabled = mode != "위치·회전";
                    lblValue1.Text = "길이";
                    numValue1.Value = 5000;
                    SetCreateOptions(true, false, false);
                    lblCreateHint.Text = mode == "위치·회전" ? "선분 : +X 방향 기본 선분을 위치·회전으로 배치" : "선분 : 시작점 → 끝점";
                    break;

                case "선분 집합":
                    lblPoint1Title.Text = "시작점";
                    lblPoint2Title.Text = "끝점";
                    pnlPoint2.Enabled = true;
                    pnlPoint3.Visible = false;
                    pnlValues.Visible = false;
                    pnlLineSegments.Visible = true;
                    SetCreateOptions(true, false, false);
                    lblCreateHint.Text = "선분 집합 : 시작점/끝점을 지정해 선분을 여러 개 등록한 뒤 하나의 Shape로 생성";
                    break;

                case "폴리라인":
                case "삼각형":
                    lblPoint1Title.Text = "점 1";
                    lblPoint2Title.Text = "점 2";
                    lblPoint3Title.Text = "점 3";
                    pnlPoint2.Enabled = true;
                    pnlPoint3.Enabled = true;
                    pnlValues.Enabled = false;
                    SetCreateOptions(true, false, false);
                    lblCreateHint.Text = type == "폴리라인" ? "폴리라인 : 세 점을 순서대로 연결" : "삼각형 : 세 꼭짓점으로 생성";
                    break;

                case "원":
                    lblPoint1Title.Text = mode == "위치·회전" ? "배치 위치" : "중심";
                    lblPoint2Title.Text = "법선";
                    pnlPoint2.Enabled = mode != "위치·회전";
                    lblValue1.Text = "반지름";
                    numValue1.Value = 2000;
                    SetCreateOptions(true, true, false);
                    lblCreateHint.Text = mode == "위치·회전" ? "원 : XY 기본 원을 위치·회전으로 배치" : "원 : 중심 + 법선 + 반지름";
                    break;

                case "사각형":
                    lblPoint1Title.Text = mode == "위치·회전" ? "배치 위치" : "중심";
                    lblValue1.Text = "너비";
                    lblValue2.Text = "높이";
                    numValue1.Value = 5000;
                    numValue2.Value = 3000;
                    SetValueEnabled(true, true, false);
                    SetCreateOptions(true, false, false);
                    lblCreateHint.Text = "사각형 : XY 평면 기준, 너비/높이 지정";
                    break;

                case "메시":
                    lblPoint1Title.Text = "기준 위치";
                    pnlValues.Enabled = false;
                    lblCreateHint.Text = "메시 : 정점/인덱스 목록으로 작은 피라미드 생성";
                    break;

                case "박스":
                    lblPoint1Title.Text = "위치";
                    lblValue1.Text = "X 크기";
                    lblValue2.Text = "Y 크기";
                    lblValue3.Text = "Z 크기";
                    numValue1.Value = numValue2.Value = numValue3.Value = 3000;
                    SetValueEnabled(true, true, true);
                    SetCreateOptions(false, false, mode == "기본");
                    if (mode == "선택 객체 기준") pnlPoint1.Enabled = pnlValues.Enabled = false;
                    lblCreateHint.Text = mode == "선택 객체 기준" ? "박스 : 선택 객체의 BoundBox 크기에 맞춰 생성" : "박스 : 크기 + 위치 지정";
                    break;

                case "원통":
                    lblPoint1Title.Text = "위치";
                    lblPoint2Title.Text = "방향";
                    lblValue1.Text = "반지름";
                    lblValue2.Text = "높이";
                    numValue1.Value = 1000;
                    numValue2.Value = 5000;
                    SetValueEnabled(true, true, false);
                    SetCreateOptions(false, true, mode == "기본");
                    pnlPoint2.Enabled = mode == "방향 벡터";
                    if (mode == "선택 객체 기준") pnlPoint1.Enabled = pnlValues.Enabled = false;
                    lblCreateHint.Text = mode == "방향 벡터" ? "원통 : 위치에서 지정 방향으로 생성" : mode == "선택 객체 기준" ? "원통 : 선택 객체의 BoundBox 기준 생성" : "원통 : 반지름/높이/분할 지정";
                    break;

                case "구":
                    lblPoint1Title.Text = "위치";
                    lblValue1.Text = "반지름";
                    numValue1.Value = 2000;
                    SetCreateOptions(false, true, mode == "기본");
                    if (mode == "선택 객체 기준") pnlPoint1.Enabled = pnlValues.Enabled = false;
                    lblCreateHint.Text = mode == "선택 객체 기준" ? "구 : 선택 객체의 BoundBox 기준 생성" : "구 : 반지름 + 위치 지정";
                    break;

                case "평면":
                    lblPoint1Title.Text = "위치";
                    lblPoint2Title.Text = "법선";
                    lblValue1.Text = "너비";
                    lblValue2.Text = "높이";
                    numValue1.Value = 5000;
                    numValue2.Value = 3000;
                    SetValueEnabled(true, true, false);
                    pnlPoint2.Enabled = mode == "방향 벡터";
                    lblCreateHint.Text = mode == "방향 벡터" ? "평면 : 위치 + 법선으로 방향 지정" : "평면 : XY 기준 또는 위치·회전 배치";
                    break;

                case "화살표":
                    lblPoint1Title.Text = "시작점";
                    lblPoint2Title.Text = "끝점";
                    pnlPoint2.Enabled = true;
                    lblValue1.Text = "몸통 반지름";
                    numValue1.Value = 150;
                    lblCreateHint.Text = "화살표 : 시작점 → 끝점";
                    break;

                case "좌표축":
                    lblPoint1Title.Text = "원점";
                    lblValue1.Text = "축 길이";
                    lblValue2.Text = "몸통 반지름";
                    numValue1.Value = 5000;
                    numValue2.Value = 150;
                    SetValueEnabled(true, true, false);
                    lblCreateHint.Text = "좌표축 : X=빨강(+X), Y=초록(+Y), Z=파랑(+Z)";
                    break;

                case "바운딩 박스":
                    lblPoint1Title.Text = "최솟값";
                    lblPoint2Title.Text = "최댓값";
                    pnlPoint2.Enabled = mode != "선택 객체 기준";
                    pnlValues.Enabled = false;
                    SetCreateOptions(true, false, false);
                    if (mode == "선택 객체 기준") pnlPoint1.Enabled = false;
                    lblCreateHint.Text = mode == "선택 객체 기준" ? "바운딩 박스 : 선택 객체 영역으로 생성" : "바운딩 박스 : Min/Max 좌표 직접 지정";
                    break;
            }

            btnPoint1Osnap.Enabled = pnlPoint1.Enabled;
            btnPoint2Osnap.Enabled = pnlPoint2.Enabled;
            btnPoint3Osnap.Enabled = pnlPoint3.Enabled;

            if (lblPoint2Title.Text == "법선") btnPoint2Osnap.Enabled = false;

            lblModeInfo.Text = "방식 : " + mode;
        }

        private async void btnPoint1Osnap_Click(object sender, EventArgs e)
        {
            await SetOsnapPosition(lblPoint1Title.Text + " 위치를 선택하세요.", numP1X, numP1Y, numP1Z);
        }

        private async void btnPoint2Osnap_Click(object sender, EventArgs e)
        {
            await SetOsnapPosition(lblPoint2Title.Text + " 위치를 선택하세요.", numP2X, numP2Y, numP2Z);
        }

        private async void btnPoint3Osnap_Click(object sender, EventArgs e)
        {
            await SetOsnapPosition(lblPoint3Title.Text + " 위치를 선택하세요.", numP3X, numP3Y, numP3Z);
        }

        private void btnLineSegmentAdd_Click(object sender, EventArgs e)
        {
            Vector3D start = new Vector3D((float)numP1X.Value, (float)numP1Y.Value, (float)numP1Z.Value);
            Vector3D end = new Vector3D((float)numP2X.Value, (float)numP2Y.Value, (float)numP2Z.Value);

            if (start.X == end.X && start.Y == end.Y && start.Z == end.Z)
            {
                MessageBox.Show("선분의 시작점과 끝점은 같을 수 없습니다.", "VIZCore3DX.NET.ShapeControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Line3D line = new Line3D
            {
                Start3D = new Vertex3D(start.X, start.Y, start.Z),
                End3D = new Vertex3D(end.X, end.Y, end.Z)
            };

            int rowIndex = dgvLineSegments.Rows.Add(dgvLineSegments.Rows.Count + 1, string.Format("{0:0.###}, {1:0.###}, {2:0.###}", start.X, start.Y, start.Z), string.Format("{0:0.###}, {1:0.###}, {2:0.###}", end.X, end.Y, end.Z));
            dgvLineSegments.Rows[rowIndex].Tag = line;
            dgvLineSegments.ClearSelection();
            dgvLineSegments.Rows[rowIndex].Selected = true;
        }

        private void btnLineSegmentRemove_Click(object sender, EventArgs e)
        {
            if (dgvLineSegments.SelectedRows.Count == 0) return;

            dgvLineSegments.Rows.Remove(dgvLineSegments.SelectedRows[0]);

            for (int i = 0; i < dgvLineSegments.Rows.Count; i++) dgvLineSegments.Rows[i].Cells[0].Value = i + 1;
        }

        private void btnLineSegmentClear_Click(object sender, EventArgs e)
        {
            dgvLineSegments.Rows.Clear();
        }

        private void btnCreateColor_Click(object sender, EventArgs e)
        {
            SelectColor(btnCreateColor);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string type = cmbShapeType.Text;
            string mode = cmbCreateMode.Text;
            string category = txtCreateCategory.Text.Trim();
            Color color = btnCreateColor.BackColor;

            Vector3D p1 = new Vector3D((float)numP1X.Value, (float)numP1Y.Value, (float)numP1Z.Value);
            Vector3D p2 = new Vector3D((float)numP2X.Value, (float)numP2Y.Value, (float)numP2Z.Value);
            Vector3D p3 = new Vector3D((float)numP3X.Value, (float)numP3Y.Value, (float)numP3Z.Value);
            float value1 = (float)numValue1.Value;
            float value2 = (float)numValue2.Value;
            float value3 = (float)numValue3.Value;
            float strokeThickness = (float)numStrokeThickness.Value;
            ushort segmentCount = (ushort)numSegmentCount.Value;

            StrokePattern strokePattern;
            if (!Enum.TryParse(cmbStrokePattern.Text, out strokePattern)) strokePattern = StrokePattern.Solid;

            AxisAnchor axisAnchor;
            if (!Enum.TryParse(cmbAxisAnchor.Text, out axisAnchor)) axisAnchor = AxisAnchor.Center;

            Vector3D rotationAxis = new Vector3D((float)numRotX.Value, (float)numRotY.Value, (float)numRotZ.Value);
            Quaternion rotation = Quaternion.FromAxisAngle(rotationAxis, (float)((double)numRotDegree.Value * Math.PI / 180.0));

            ShapeItem shape = null;
            List<ShapeItem> created = new List<ShapeItem>();
            Vector3D position = p1;

            if (strokeThickness < 1f) strokeThickness = 1f;
            if (strokeThickness > 10f) strokeThickness = 10f;
            if (segmentCount < 4) segmentCount = 4;
            if (segmentCount > 128) segmentCount = 128;

            switch (type)
            {
                case "점":
                    if (value1 < 4f) value1 = 4f;
                    if (value1 > 10f) value1 = 10f;
                    shape = vizcore3dx.Shape.CreatePointShape(new Vector3D(0f, 0f, 0f), value1, color);
                    break;

                case "선분":
                    {
                        Vector3D end = mode == "위치·회전" ? new Vector3D(value1, 0f, 0f) : new Vector3D(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);

                        if (end.X == 0f && end.Y == 0f && end.Z == 0f)
                        {
                            MessageBox.Show("선분의 시작점과 끝점은 같을 수 없습니다.", "VIZCore3DX.NET.ShapeControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        shape = vizcore3dx.Shape.CreateLineSegmentShape(new Line3D { Start3D = new Vertex3D(0f, 0f, 0f), End3D = new Vertex3D(end.X, end.Y, end.Z) }, strokeThickness, strokePattern, color);
                        break;
                    }

                case "선분 집합":
                    {
                        List<Line3D> segments = new List<Line3D>();

                        foreach (DataGridViewRow row in dgvLineSegments.Rows)
                        {
                            if (row.Tag is Line3D) segments.Add((Line3D)row.Tag);
                        }

                        if (segments.Count == 0)
                        {
                            MessageBox.Show("생성할 선분을 먼저 등록해주세요.", "VIZCore3DX.NET.ShapeControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        Vertex3D origin = segments[0].Start3D;
                        position = new Vector3D(origin.X, origin.Y, origin.Z);

                        List<Line3D> localSegments = segments.Select(line => new Line3D
                        {
                            Start3D = new Vertex3D(line.Start3D.X - origin.X, line.Start3D.Y - origin.Y, line.Start3D.Z - origin.Z),
                            End3D = new Vertex3D(line.End3D.X - origin.X, line.End3D.Y - origin.Y, line.End3D.Z - origin.Z)
                        }).ToList();

                        shape = vizcore3dx.Shape.CreateLineSegmentsShape(localSegments, strokeThickness, strokePattern, color);
                        break;
                    }

                case "폴리라인":
                    shape = vizcore3dx.Shape.CreatePolylineShape(new List<Vector3D>
                    {
                        new Vector3D(0f, 0f, 0f),
                        new Vector3D(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z),
                        new Vector3D(p3.X - p1.X, p3.Y - p1.Y, p3.Z - p1.Z)
                    }, strokeThickness, strokePattern, color);
                    break;

                case "원":
                    shape = vizcore3dx.Shape.CreateCircleShape(new CircleData { Center = new Vertex3D(0f, 0f, 0f), Normal = mode == "위치·회전" ? new Vector3D(0f, 0f, 1f) : p2, Radius = value1 }, segmentCount, strokeThickness, strokePattern, color);
                    break;

                case "사각형":
                    shape = vizcore3dx.Shape.CreateRectangleShape(new Rectangle3D { Center = new Vertex3D(0f, 0f, 0f), UAxis = new Vector3D(1f, 0f, 0f), VAxis = new Vector3D(0f, 1f, 0f), Width = value1, Height = value2 }, strokeThickness, strokePattern, color);
                    break;

                case "삼각형":
                    shape = vizcore3dx.Shape.CreateTriangleShape(new Triangle3D
                    {
                        Point1 = new Vertex3D(0f, 0f, 0f),
                        Point2 = new Vertex3D(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z),
                        Point3 = new Vertex3D(p3.X - p1.X, p3.Y - p1.Y, p3.Z - p1.Z)
                    }, strokeThickness, strokePattern, color);
                    break;

                case "메시":
                    shape = vizcore3dx.Shape.CreateMeshShape(new List<Vertex3D>
                    {
                        new Vertex3D(0f, 0f, 0f),
                        new Vertex3D(2000f, 0f, 0f),
                        new Vertex3D(2000f, 2000f, 0f),
                        new Vertex3D(0f, 2000f, 0f),
                        new Vertex3D(1000f, 1000f, 2500f)
                    }, new List<int> { 0, 2, 1, 0, 3, 2, 0, 1, 4, 1, 2, 4, 2, 3, 4, 3, 0, 4 }, color);
                    break;

                case "박스":
                    {
                        if (mode == "선택 객체 기준")
                        {
                            BoundBox3D bb;
                            if (!TryGetSelectedBoundBox(out bb)) break;

                            position = new Vector3D(bb.CenterX, bb.CenterY, bb.CenterZ);
                            shape = vizcore3dx.Shape.CreateCubeShape(new Vector3D(bb.MaxX - bb.MinX, bb.MaxY - bb.MinY, bb.MaxZ - bb.MinZ), color, AxisAnchor.Center, new Vector3D(0f, 0f, 0f));
                        }
                        else shape = vizcore3dx.Shape.CreateCubeShape(new Vector3D(value1, value2, value3), color, mode == "기본" ? axisAnchor : AxisAnchor.Center, new Vector3D(0f, 0f, 0f));

                        break;
                    }

                case "원통":
                    {
                        if (segmentCount < 8) segmentCount = 8;

                        if (mode == "선택 객체 기준")
                        {
                            BoundBox3D bb;
                            if (!TryGetSelectedBoundBox(out bb)) break;

                            position = new Vector3D(bb.CenterX, bb.CenterY, bb.CenterZ);
                            value1 = Math.Max(bb.MaxX - bb.MinX, bb.MaxY - bb.MinY) / 2f;
                            value2 = bb.MaxZ - bb.MinZ;
                        }

                        shape = vizcore3dx.Shape.CreateCylinderShape(value1, value2, color, mode == "기본" ? axisAnchor : AxisAnchor.Center, new Vector3D(0f, 0f, 0f), segmentCount);
                        break;
                    }

                case "구":
                    {
                        if (mode == "선택 객체 기준")
                        {
                            BoundBox3D bb;
                            if (!TryGetSelectedBoundBox(out bb)) break;

                            position = new Vector3D(bb.CenterX, bb.CenterY, bb.CenterZ);
                            value1 = Math.Max(Math.Max(bb.MaxX - bb.MinX, bb.MaxY - bb.MinY), bb.MaxZ - bb.MinZ) / 2f;
                        }

                        shape = vizcore3dx.Shape.CreateSphereShape(value1, color, mode == "기본" ? axisAnchor : AxisAnchor.Center, new Vector3D(0f, 0f, 0f), segmentCount);
                        break;
                    }

                case "평면":
                    shape = vizcore3dx.Shape.CreatePlaneShape(value1, value2, color, new Vector3D(0f, 0f, 0f));
                    break;

                case "화살표":
                    {
                        Vector3D end = new Vector3D(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);

                        if (end.X == 0f && end.Y == 0f && end.Z == 0f)
                        {
                            MessageBox.Show("화살표의 시작점과 끝점은 같을 수 없습니다.", "VIZCore3DX.NET.ShapeControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        shape = vizcore3dx.Shape.CreateArrowShape(new Vector3D(0f, 0f, 0f), end, value1, color);
                        break;
                    }

                case "좌표축":
                    {
                        List<ShapeItem.MeshShape> axes = vizcore3dx.Shape.CreateAxisShape(new Vector3D(0f, 0f, 0f), value1, value2);
                        if (axes != null) created.AddRange(axes.Cast<ShapeItem>());
                        break;
                    }

                case "바운딩 박스":
                    {
                        if (mode == "선택 객체 기준")
                        {
                            BoundBox3D bb;
                            if (!TryGetSelectedBoundBox(out bb)) break;

                            float x = (bb.MaxX - bb.MinX) / 2f;
                            float y = (bb.MaxY - bb.MinY) / 2f;
                            float z = (bb.MaxZ - bb.MinZ) / 2f;
                            position = new Vector3D(bb.CenterX, bb.CenterY, bb.CenterZ);
                            shape = vizcore3dx.Shape.CreateBoundingBoxShape(new Vertex3D(-x, -y, -z), new Vertex3D(x, y, z), strokeThickness, strokePattern, color);
                        }
                        else
                        {
                            float x = p2.X - p1.X;
                            float y = p2.Y - p1.Y;
                            float z = p2.Z - p1.Z;
                            shape = vizcore3dx.Shape.CreateBoundingBoxShape(new Vertex3D(Math.Min(0f, x), Math.Min(0f, y), Math.Min(0f, z)), new Vertex3D(Math.Max(0f, x), Math.Max(0f, y), Math.Max(0f, z)), strokeThickness, strokePattern, color);
                        }

                        break;
                    }
            }

            if (shape != null) created.Add(shape);
            if (created.Count == 0) return;

            vizcore3dx.Shape.SetPosition(created, position);

            if (pnlRotation.Enabled) vizcore3dx.Shape.SetRotation(created, rotation);
            else if (mode == "방향 벡터" && (type == "원통" || type == "평면")) vizcore3dx.Shape.SetRotation(created, p2);

            if (category.Length > 0) vizcore3dx.Shape.AddCategory(created, category);
            UpdateShapeList();
        }

        private async void btnMoveOsnap_Click(object sender, EventArgs e)
        {
            List<ShapeItem> targets = selectedShapes.Where(x => x != null).ToList();
            if (targets.Count == 0)
            {
                MessageBox.Show("형상 목록에서 이동할 형상을 선택해주세요.", "VIZCore3DX.NET.ShapeControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();
            osnap.CommandText = "이동할 위치를 선택하세요.";
            OsnapResult result = await osnap.GetResultAsync();
            if (result == null) return;

            Vector3D target = new Vector3D(result.Position.X, result.Position.Y, result.Position.Z);
            Vector3D current = targets[0].Position ?? new Vector3D(0f, 0f, 0f);
            Vector3D move = new Vector3D(target.X - current.X, target.Y - current.Y, target.Z - current.Z);

            foreach (ShapeItem shape in targets)
            {
                Vector3D position = shape.Position ?? new Vector3D(0f, 0f, 0f);
                vizcore3dx.Shape.SetPosition(shape, new Vector3D(position.X + move.X, position.Y + move.Y, position.Z + move.Z));
            }

            selectedShapes = targets;
            SetPositionValue(numMoveX, numMoveY, numMoveZ, targets[0].Position);
        }

        private void dgvShapes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvShapes.SelectedRows.Count == 0)
            {
                selectedShapes.Clear();
                UpdateStatus();
                return;
            }

            ShapeItem shape = dgvShapes.SelectedRows[0].Tag as ShapeItem;
            if (shape == null) return;

            selectedShapes = new List<ShapeItem> { shape };
            if (shape.Position != null) SetPositionValue(numMoveX, numMoveY, numMoveZ, shape.Position);
            UpdateStatus();
        }

        private void UpdateShapeList()
        {
            UpdateShapeList(vizcore3dx.Shape.Shapes, "전체 목록");
        }

        private void UpdateShapeList(List<ShapeItem> shapes, string title)
        {
            dgvShapes.SelectionChanged -= dgvShapes_SelectionChanged;
            dgvShapes.Rows.Clear();
            selectedShapes.Clear();

            if (shapes == null) shapes = new List<ShapeItem>();

            for (int i = 0; i < shapes.Count; i++)
            {
                ShapeItem shape = shapes[i];
                if (shape == null) continue;

                string typeName = shape.GetType().Name;
                if (typeName.EndsWith("Shape")) typeName = typeName.Substring(0, typeName.Length - 5);

                int rowIndex = dgvShapes.Rows.Add(i + 1, typeName, string.IsNullOrEmpty(shape.Category) ? "-" : shape.Category);
                dgvShapes.Rows[rowIndex].Tag = shape;
            }

            dgvShapes.ClearSelection();
            dgvShapes.SelectionChanged += dgvShapes_SelectionChanged;
            lblShapeListInfo.Text = string.Format("{0} : {1}개", title, dgvShapes.Rows.Count);
            UpdateStatus();
        }

        private void btnRotateSelected_Click(object sender, EventArgs e)
        {
            if (selectedShapes.Count == 0) return;

            Vector3D axis = new Vector3D((float)numTransformX.Value, (float)numTransformY.Value, (float)numTransformZ.Value);
            vizcore3dx.Shape.SetRotation(selectedShapes, Quaternion.FromAxisAngle(axis, (float)((double)numTransformDegree.Value * Math.PI / 180.0)));
        }

        private void btnDirectionSelected_Click(object sender, EventArgs e)
        {
            if (selectedShapes.Count == 0) return;

            vizcore3dx.Shape.SetRotation(selectedShapes, new Vector3D((float)numTransformX.Value, (float)numTransformY.Value, (float)numTransformZ.Value));
        }

        private void btnCategoryCount_Click(object sender, EventArgs e)
        {
            string category = txtManageCategory.Text.Trim();

            if (category.Length == 0)
            {
                MessageBox.Show("조회할 카테고리를 입력해주세요.", "VIZCore3DX.NET.ShapeControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<ShapeItem> shapes = vizcore3dx.Shape.FromCategory(category);
            lblCategoryCount.Text = string.Format("결과 : {0}개", shapes.Count);
            UpdateShapeList(shapes, string.Format("조회 결과 - {0}", category));
        }

        private void btnCategoryApply_Click(object sender, EventArgs e)
        {
            string category = txtManageCategory.Text.Trim();

            if (category.Length == 0)
            {
                MessageBox.Show("지정할 카테고리를 입력해주세요.", "VIZCore3DX.NET.ShapeControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<ShapeItem> shapes = GetManageTargets();
            if (shapes.Count == 0)
            {
                MessageBox.Show("적용할 형상을 선택해주세요.", "VIZCore3DX.NET.ShapeControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            vizcore3dx.Shape.AddCategory(shapes, category);
            lblCategoryCount.Text = string.Format("적용 : {0}개", shapes.Count);
            UpdateShapeList();
        }

        private void btnCategoryClear_Click(object sender, EventArgs e)
        {
            List<ShapeItem> shapes = GetManageTargets();
            if (shapes.Count == 0)
            {
                MessageBox.Show("적용할 형상을 선택해주세요.", "VIZCore3DX.NET.ShapeControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            vizcore3dx.Shape.DeleteCategory(shapes);
            lblCategoryCount.Text = string.Format("해제 : {0}개", shapes.Count);
            UpdateShapeList();
        }

        private void btnSelectedDelete_Click(object sender, EventArgs e)
        {
            if (selectedShapes.Count == 0)
            {
                MessageBox.Show("삭제할 형상을 목록에서 선택해주세요.", "VIZCore3DX.NET.ShapeControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            vizcore3dx.Shape.Delete(selectedShapes);
            selectedShapes.Clear();
            UpdateShapeList();
        }

        private void btnCategoryDelete_Click(object sender, EventArgs e)
        {
            string category = txtManageCategory.Text.Trim();

            if (category.Length == 0)
            {
                MessageBox.Show("삭제할 카테고리를 입력해주세요.", "VIZCore3DX.NET.ShapeControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            vizcore3dx.Shape.Delete(category);
            selectedShapes.Clear();
            UpdateShapeList();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            vizcore3dx.Shape.Clear();
            selectedShapes.Clear();
            UpdateShapeList();
        }

        private void SetManageVisible(bool visible)
        {
            if (cmbManageTarget.Text == "전체") vizcore3dx.Shape.Show(visible);
            else vizcore3dx.Shape.Show(visible, GetManageTargets());
        }

        private List<ShapeItem> GetManageTargets()
        {
            if (cmbManageTarget.Text == "전체") return vizcore3dx.Shape.Shapes;
            return selectedShapes.Where(x => x != null).ToList();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            SetManageVisible(true);
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            SetManageVisible(false);
        }

        private void chkSelectable_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbManageTarget.Text == "전체") vizcore3dx.Shape.Selectable(chkSelectable.Checked);
            else vizcore3dx.Shape.Selectable(chkSelectable.Checked, GetManageTargets());
        }

        private void chkHighlightable_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbManageTarget.Text == "전체") vizcore3dx.Shape.SetHighlightable(chkHighlightable.Checked);
            else vizcore3dx.Shape.SetHighlightable(GetManageTargets(), chkHighlightable.Checked);
        }

        private void chkDepthTest_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbManageTarget.Text == "전체") vizcore3dx.Shape.DepthTestEnable(chkDepthTest.Checked);
            else vizcore3dx.Shape.DepthTestEnable(chkDepthTest.Checked, GetManageTargets());
        }

        private void numSelectionRadius_ValueChanged(object sender, EventArgs e)
        {
            vizcore3dx.Shape.ShapeSelectionRadius = (uint)numSelectionRadius.Value;
        }

        private void btnHighlightColor_Click(object sender, EventArgs e)
        {
            Color? color = SelectColor(btnHighlightColor);
            if (color.HasValue) vizcore3dx.Shape.ShapeHighlightedStrokeColor = color.Value;
        }

        private void btnSelectedColor_Click(object sender, EventArgs e)
        {
            Color? color = SelectColor(btnSelectedColor);
            if (color.HasValue) vizcore3dx.Shape.ShapeSelectedStrokeColor = color.Value;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblCategoryCount.Text = "결과 : -";
            UpdateShapeList();
        }

        private void cmbHeatmapSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateHeatmapUI();
        }

        private void UpdateHeatmapUI()
        {
            // 기준점 거리 방식에서만 기준점 입력을 사용합니다.
            bool usePoint = cmbHeatmapSource.SelectedIndex == 3;

            lblHeatmapPoint.Enabled = usePoint;
            lblHeatmapX.Enabled = numHeatmapX.Enabled = usePoint;
            lblHeatmapY.Enabled = numHeatmapY.Enabled = usePoint;
            lblHeatmapZ.Enabled = numHeatmapZ.Enabled = usePoint;
            btnHeatmapPointOsnap.Enabled = usePoint;
        }

        private async void btnHeatmapPointOsnap_Click(object sender, EventArgs e)
        {
            await SetOsnapPosition("히트맵 기준점을 선택하세요.", numHeatmapX, numHeatmapY, numHeatmapZ);
        }

        private Func<Vertex3D, double> GetHeatmapScalar()
        {
            // 정점마다 계산할 스칼라 함수를 반환합니다.
            switch (cmbHeatmapSource.SelectedIndex)
            {
                case 0:
                    return v => v.X;

                case 1:
                    return v => v.Y;

                case 3:
                    {
                        double px = (double)numHeatmapX.Value;
                        double py = (double)numHeatmapY.Value;
                        double pz = (double)numHeatmapZ.Value;
                        return v => Math.Sqrt((v.X - px) * (v.X - px) + (v.Y - py) * (v.Y - py) + (v.Z - pz) * (v.Z - pz));
                    }

                default:
                    return v => v.Z;
            }
        }

        private void btnHeatmapCreate_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            List<Node> nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP);
            if (nodes.Count == 0)
            {
                MessageBox.Show("히트맵을 생성할 노드를 선택해주세요.", "VIZCore3DX.NET.ShapeControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string category = txtHeatmapCategory.Text.Trim();
            if (category.Length == 0)
            {
                MessageBox.Show("히트맵 카테고리를 입력해주세요.", "VIZCore3DX.NET.ShapeControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            HeatmapResult result;

            // 같은 카테고리의 이전 히트맵을 지우고 새로 생성합니다.
            using (vizcore3dx.BeginUpdateScope())
            {
                vizcore3dx.Shape.Delete(category);
                result = vizcore3dx.Shape.CreateHeatmap(nodes, GetHeatmapScalar(), category);
            }

            if (result == null || result.Shapes == null || result.Shapes.Count == 0)
            {
                lblHeatmapResult.Text = "결과 : 실패";
                ShowShapeOperationFailure("히트맵을 생성하지 못했습니다.");
                UpdateShapeList();
                return;
            }

            UpdateShapeList();
            lblHeatmapResult.Text = string.Format("결과 : 형상 {0}개 / 정점 {1}개 / 최소 {2:0.###} / 최대 {3:0.###}{4}", result.Shapes.Count, result.VertexCount, result.Minimum, result.Maximum, result.Truncated ? " (상한 초과로 일부 생략)" : string.Empty);
        }

        private void btnHeatmapClear_Click(object sender, EventArgs e)
        {
            string category = txtHeatmapCategory.Text.Trim();
            if (category.Length == 0) return;

            vizcore3dx.Shape.Delete(category);
            lblHeatmapResult.Text = "결과 : -";
            UpdateShapeList();
        }

        private void ShowShapeOperationFailure(string message)
        {
            OperationStatus status = vizcore3dx.Shape.LastOperationStatus;
            string detail = status == null ? string.Empty : string.Format("\n원인 : {0}", status.Result);

            MessageBox.Show(message + detail, "VIZCore3DX.NET.ShapeControl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void UpdateStatus()
        {
            if (selectedShapes.Count == 0) lblSelectedShapeInfo.Text = "선택 형상 : 없음";
            else
            {
                string typeName = selectedShapes[0].GetType().Name;
                if (typeName.EndsWith("Shape")) typeName = typeName.Substring(0, typeName.Length - 5);
                lblSelectedShapeInfo.Text = string.Format("선택 형상 : {0}", typeName);
            }
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
