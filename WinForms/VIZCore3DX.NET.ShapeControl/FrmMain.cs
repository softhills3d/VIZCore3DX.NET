using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.ShapeControl
{
    public partial class FrmMain : Form
    {
        // 만들 형상 종류
        private enum ShapeKind { Point, LineSegment, LineSegments, Polyline, Circle, Rectangle, Triangle, Mesh, Cube, Cylinder, Sphere, Plane, Arrow, Axis, BoundingBox }

        // 생성 방식 : 기본 / 위치·회전 / 방향 벡터 / 선택 객체 기준
        private enum CreateMode { Default, PositionRotation, DirectionVector, SelectedNodes }

        // 히트맵 스칼라 값 : X·Y·Z 좌표 또는 기준점까지의 거리
        private enum HeatmapSource { X, Y, Z, DistanceToPoint }

        // 목록 관리 대상 : 현재 선택 / 전체
        private enum ManageTarget { Selected, All }

        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 목록이나 뷰에서 고른 형상
        private List<VIZCore3DX.NET.Data.ShapeItem> _selectedShapes = new List<VIZCore3DX.NET.Data.ShapeItem>();

        // 만든 형상을 옮길 위치. 기본은 첫 번째 점이고, 형상별 생성 메서드가 바꿀 수 있습니다.
        private VIZCore3DX.NET.Data.Vector3D _createPosition;

        // 목록 갱신 중에는 선택 변경을 처리하지 않습니다.
        private bool _syncing;

        // 코드가 위치 칸을 채우는 중에는 형상을 옮기지 않습니다.
        private bool _fillingMovePosition;

        public FrmMain()
        {
            InitializeComponent();

            // 뷰어와 무관한 콤보 항목은 생성자에서 채웁니다.
            cmbCreateMode.DataSource = Enum.GetValues(typeof(CreateMode));
            cmbShapeType.DataSource = Enum.GetValues(typeof(ShapeKind));
            cmbStrokePattern.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.StrokePattern));
            cmbAxisAnchor.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.AxisAnchor));
            cmbAxisAnchor.SelectedItem = VIZCore3DX.NET.Data.AxisAnchor.Center;
            cmbHeatmapSource.DataSource = Enum.GetValues(typeof(HeatmapSource));
            cmbHeatmapSource.SelectedItem = HeatmapSource.Z;
            cmbManageTarget.DataSource = Enum.GetValues(typeof(ManageTarget));

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer2.Panel1.Controls.Add(vizcore3dx);

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
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

            InitializeVIZCore3DX();
            InitializeVIZCore3DXEvent();
        }

        private void InitializeVIZCore3DX()
        {
            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();

            // 형상 선택 반경·강조 색·선택 색과 선택 가능 여부를 화면 값에 맞춥니다.
            vizcore3dx.Shape.ShapeSelectionRadius = (uint)numSelectionRadius.Value;
            vizcore3dx.Shape.ShapeHighlightedStrokeColor = btnHighlightColor.BackColor;
            vizcore3dx.Shape.ShapeSelectedStrokeColor = btnSelectedColor.BackColor;
            vizcore3dx.Shape.Selectable(chkSelectable.Checked);

            ConfigureCreateUI(SelectedKind(), SelectedMode());
            UpdateHeatmapUI();
            RefreshList();

            SetStatus("모델을 열어 주세요.");
        }

        // 뷰에서 형상을 클릭하거나 선택을 풀면 통지가 옵니다.
        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.Shape.OnShapeSelectedEvent -= Shape_OnShapeSelectedEvent;
            vizcore3dx.Shape.OnShapeSelectedEvent += Shape_OnShapeSelectedEvent;
            vizcore3dx.Shape.OnShapeDeselectedEvent -= Shape_OnShapeDeselectedEvent;
            vizcore3dx.Shape.OnShapeDeselectedEvent += Shape_OnShapeDeselectedEvent;
        }

        // 종료 시 이벤트 구독을 먼저 끊습니다. 자식 컨트롤이 정리된 뒤에 이벤트가 오면 안 됩니다.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            vizcore3dx.Shape.OnShapeSelectedEvent -= Shape_OnShapeSelectedEvent;
            vizcore3dx.Shape.OnShapeDeselectedEvent -= Shape_OnShapeDeselectedEvent;

            base.OnFormClosing(e);
        }

        // 뷰에서 고른 형상을 이동·회전 대상으로 삼습니다.
        private void Shape_OnShapeSelectedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ShapeSelectionEventArgs e)
        {
            if (e.Shapes == null || e.Shapes.Count == 0) return;

            List<VIZCore3DX.NET.Data.ShapeItem> shapes = e.Shapes.Where(x => x != null).ToList();
            RunOnUi(() => SetSelectedShapes(shapes));
        }

        private void Shape_OnShapeDeselectedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ShapeSelectionEventArgs e)
        {
            RunOnUi(() => SetSelectedShapes(new List<VIZCore3DX.NET.Data.ShapeItem>()));
        }

        #region 1. 모델
        // 형상을 함께 볼 모델을 엽니다. 형상은 모델 없이도 만들 수 있습니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            RefreshList();
            SetStatus("모델을 열었습니다.");
        }
        #endregion

        #region 2. 형상 설정
        // 종류를 바꾸면 입력 칸의 이름·기본값·사용 여부가 바뀝니다.
        private void cmbShapeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCreateUI();
        }

        // 방식(기본·위치·회전·방향 벡터·선택 객체 기준)에 따라 쓰는 입력이 달라집니다.
        private void cmbCreateMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCreateUI();
        }

        // 뷰에서 점을 찍어 첫 번째 점 좌표를 채웁니다.
        private async void btnPoint1Osnap_Click(object sender, EventArgs e)
        {
            await PickPoint(lblPoint1.Text + " 위치를 선택하세요.", numP1X, numP1Y, numP1Z);
        }

        // 뷰에서 점을 찍어 두 번째 점 좌표를 채웁니다.
        private async void btnPoint2Osnap_Click(object sender, EventArgs e)
        {
            await PickPoint(lblPoint2.Text + " 위치를 선택하세요.", numP2X, numP2Y, numP2Z);
        }

        // 뷰에서 점을 찍어 세 번째 점 좌표를 채웁니다.
        private async void btnPoint3Osnap_Click(object sender, EventArgs e)
        {
            await PickPoint(lblPoint3.Text + " 위치를 선택하세요.", numP3X, numP3Y, numP3Z);
        }

        // 새로 만들 형상의 색을 고릅니다.
        private void btnCreateColor_Click(object sender, EventArgs e)
        {
            SelectColor(btnCreateColor);
        }
        #endregion

        #region 3. 생성
        // 고른 종류의 형상을 원점 기준으로 만든 뒤 위치·회전·카테고리를 적용합니다.
        private void btnCreate_Click(object sender, EventArgs e)
        {
            ShapeKind kind = SelectedKind();
            _createPosition = Point1();

            List<VIZCore3DX.NET.Data.ShapeItem> created;
            vizcore3dx.BeginUpdate();
            try
            {
                created = CreateShape(kind);
                if (created != null && created.Count > 0) ApplyPlacement(created);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            if (created == null || created.Count == 0) return;

            RefreshList();
            SetStatus(string.Format("생성 : {0} {1}개", kind, created.Count));
        }
        #endregion

        #region 4. 히트맵
        // 기준점 거리 방식에서만 기준점 입력을 씁니다.
        private void cmbHeatmapSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateHeatmapUI();
        }

        // 뷰에서 점을 찍어 히트맵 기준점을 채웁니다.
        private async void btnHeatmapPointOsnap_Click(object sender, EventArgs e)
        {
            await PickPoint("히트맵 기준점을 선택하세요.", numHeatmapX, numHeatmapY, numHeatmapZ);
        }

        // 선택한 노드의 정점마다 스칼라 값을 계산해 색으로 칠한 형상을 만듭니다.
        private void btnHeatmapCreate_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);
            if (nodes.Count == 0) { SetStatus("히트맵을 만들 노드를 뷰에서 선택하세요."); return; }

            string category = txtHeatmapCategory.Text.Trim();
            if (category.Length == 0) { SetStatus("히트맵 카테고리를 입력하세요."); return; }

            VIZCore3DX.NET.Data.HeatmapResult result;

            // 같은 카테고리의 이전 히트맵을 지우고 새로 만듭니다.
            using (vizcore3dx.BeginUpdateScope())
            {
                vizcore3dx.Shape.Delete(category);
                result = vizcore3dx.Shape.CreateHeatmap(nodes, HeatmapScalar(), category);
            }

            RefreshList();

            if (result == null || result.Shapes == null || result.Shapes.Count == 0) { SetStatus("히트맵을 만들지 못했습니다 : " + FailureReason()); return; }

            SetStatus(string.Format("히트맵 : 형상 {0}개 / 정점 {1}개 / 최소 {2:0.###} / 최대 {3:0.###}{4}", result.Shapes.Count, result.VertexCount, result.Minimum, result.Maximum, result.Truncated ? " (상한 초과로 일부 생략)" : string.Empty));
        }

        // 히트맵 카테고리의 형상을 지웁니다.
        private void btnHeatmapClear_Click(object sender, EventArgs e)
        {
            string category = txtHeatmapCategory.Text.Trim();
            if (category.Length == 0) { SetStatus("히트맵 카테고리를 입력하세요."); return; }

            vizcore3dx.Shape.Delete(category);
            RefreshList();
            SetStatus(string.Format("히트맵 삭제 : {0}", category));
        }
        #endregion

        #region 5. 정리
        // 형상을 전부 지웁니다.
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            vizcore3dx.Shape.Clear();
            RefreshList();
            SetStatus("형상을 모두 삭제했습니다.");
        }
        #endregion

        #region 형상 목록·관리
        // 목록을 전체 형상으로 다시 채웁니다.
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
            SetStatus(string.Format("전체 목록 : {0}개", dgvShapes.Rows.Count));
        }

        // 목록에서 고른 행들을 관리 대상으로 삼습니다.
        private void dgvShapes_SelectionChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            List<VIZCore3DX.NET.Data.ShapeItem> shapes = new List<VIZCore3DX.NET.Data.ShapeItem>();
            foreach (DataGridViewRow row in dgvShapes.Rows)
                if (row.Selected && row.Tag is VIZCore3DX.NET.Data.ShapeItem) shapes.Add((VIZCore3DX.NET.Data.ShapeItem)row.Tag);

            SetSelectedShapes(shapes);
        }

        // 카테고리로 형상을 찾아 목록에 그 결과만 보입니다.
        private void btnCategoryFind_Click(object sender, EventArgs e)
        {
            string category = txtManageCategory.Text.Trim();
            if (category.Length == 0) { SetStatus("조회할 카테고리를 입력하세요."); return; }

            List<VIZCore3DX.NET.Data.ShapeItem> shapes = vizcore3dx.Shape.FromCategory(category);
            ShowShapes(shapes);
            SetStatus(string.Format("조회 결과 - {0} : {1}개", category, shapes.Count));
        }

        // 대상 형상에 카테고리를 붙입니다.
        private void btnCategoryApply_Click(object sender, EventArgs e)
        {
            string category = txtManageCategory.Text.Trim();
            if (category.Length == 0) { SetStatus("지정할 카테고리를 입력하세요."); return; }

            List<VIZCore3DX.NET.Data.ShapeItem> shapes = ManageShapes();
            if (shapes.Count == 0) { SetStatus("적용할 형상을 선택하세요."); return; }

            vizcore3dx.Shape.AddCategory(shapes, category);
            RefreshList();
            SetStatus(string.Format("분류 지정 : {0}개", shapes.Count));
        }

        // 대상 형상의 카테고리를 뗍니다.
        private void btnCategoryClear_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.ShapeItem> shapes = ManageShapes();
            if (shapes.Count == 0) { SetStatus("적용할 형상을 선택하세요."); return; }

            vizcore3dx.Shape.DeleteCategory(shapes);
            RefreshList();
            SetStatus(string.Format("분류 해제 : {0}개", shapes.Count));
        }

        // 카테고리에 속한 형상을 지웁니다.
        private void btnCategoryDelete_Click(object sender, EventArgs e)
        {
            string category = txtManageCategory.Text.Trim();
            if (category.Length == 0) { SetStatus("삭제할 카테고리를 입력하세요."); return; }

            vizcore3dx.Shape.Delete(category);
            RefreshList();
            SetStatus(string.Format("분류 삭제 : {0}", category));
        }

        // 대상 형상을 보입니다.
        private void btnShow_Click(object sender, EventArgs e)
        {
            SetVisible(true);
        }

        // 대상 형상을 숨깁니다.
        private void btnHide_Click(object sender, EventArgs e)
        {
            SetVisible(false);
        }

        // 대상 형상을 뷰에서 클릭해 고를 수 있는지 정합니다.
        private void chkSelectable_CheckedChanged(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.ShapeItem> targets = Targets();
            if (targets == null) vizcore3dx.Shape.Selectable(chkSelectable.Checked);
            else vizcore3dx.Shape.Selectable(chkSelectable.Checked, targets);
            SetStatus(string.Format("선택 가능 {0} : {1}", chkSelectable.Checked ? "켬" : "끔", TargetLabel(targets)));
        }

        // 대상 형상에 마우스를 올렸을 때 강조할지 정합니다.
        private void chkHighlightable_CheckedChanged(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.ShapeItem> targets = Targets();
            if (targets == null) vizcore3dx.Shape.SetHighlightable(chkHighlightable.Checked);
            else vizcore3dx.Shape.SetHighlightable(targets, chkHighlightable.Checked);
            SetStatus(string.Format("강조 가능 {0} : {1}", chkHighlightable.Checked ? "켬" : "끔", TargetLabel(targets)));
        }

        // 끄면 대상 형상이 모델에 가려지지 않고 항상 앞에 보입니다.
        private void chkDepthTest_CheckedChanged(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.ShapeItem> targets = Targets();
            if (targets == null) vizcore3dx.Shape.DepthTestEnable(chkDepthTest.Checked);
            else vizcore3dx.Shape.DepthTestEnable(chkDepthTest.Checked, targets);
            SetStatus(string.Format("깊이 테스트 {0} : {1}", chkDepthTest.Checked ? "켬" : "끔", TargetLabel(targets)));
        }

        // 뷰에서 형상을 클릭으로 고를 때의 픽셀 반경입니다.
        private void numSelectionRadius_ValueChanged(object sender, EventArgs e)
        {
            vizcore3dx.Shape.ShapeSelectionRadius = (uint)numSelectionRadius.Value;
        }

        // 마우스를 올린 형상의 외곽선 색을 바꿉니다.
        private void btnHighlightColor_Click(object sender, EventArgs e)
        {
            Color? color = SelectColor(btnHighlightColor);
            if (color.HasValue) vizcore3dx.Shape.ShapeHighlightedStrokeColor = color.Value;
        }

        // 선택한 형상의 외곽선 색을 바꿉니다.
        private void btnSelectedColor_Click(object sender, EventArgs e)
        {
            Color? color = SelectColor(btnSelectedColor);
            if (color.HasValue) vizcore3dx.Shape.ShapeSelectedStrokeColor = color.Value;
        }

        // 뷰에서 찍은 점으로 선택 형상을 옮깁니다. 여러 개면 첫 형상의 이동량만큼 함께 옮깁니다.
        private async void btnMoveOsnap_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.ShapeItem> targets = _selectedShapes.Where(x => x != null).ToList();
            if (targets.Count == 0) { SetStatus("형상 목록에서 이동할 형상을 선택하세요."); return; }

            VIZCore3DX.NET.Data.OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();
            osnap.CommandText = "이동할 위치를 선택하세요.";
            VIZCore3DX.NET.Data.OsnapResult result = await osnap.GetResultAsync();
            if (result == null) return;

            VIZCore3DX.NET.Data.Vector3D current = targets[0].Position ?? Zero();
            VIZCore3DX.NET.Data.Vector3D move = result.Position - current;
            MoveShapes(targets, move);

            _selectedShapes = targets;
            ShowMovePosition(targets[0].Position);
            SetStatus(string.Format("이동 : {0}개", targets.Count));
        }

        // 위치 칸을 바꾸면 선택 형상을 그 위치로 옮깁니다. 여러 개면 첫 형상의 이동량만큼 함께 옮깁니다.
        private void numMove_ValueChanged(object sender, EventArgs e)
        {
            if (_fillingMovePosition) return;

            List<VIZCore3DX.NET.Data.ShapeItem> targets = _selectedShapes.Where(x => x != null).ToList();
            if (targets.Count == 0) return;

            VIZCore3DX.NET.Data.Vector3D current = targets[0].Position ?? Zero();
            MoveShapes(targets, ReadPoint(numMoveX, numMoveY, numMoveZ) - current);
            SetStatus(string.Format("이동 : {0}개", targets.Count));
        }

        // 선택 형상을 축·각도만큼 회전합니다.
        private void btnRotateSelected_Click(object sender, EventArgs e)
        {
            if (_selectedShapes.Count == 0) { SetStatus("형상 목록에서 형상을 선택하세요."); return; }

            VIZCore3DX.NET.Data.Vector3D axis = ReadPoint(numAxisX, numAxisY, numAxisZ);
            vizcore3dx.Shape.SetRotation(_selectedShapes, VIZCore3DX.NET.Data.Quaternion.FromAxisAngle(axis, VIZCore3DX.NET.Utility.AngleFormatHelper.DegreesToRadians((double)numAngle.Value)));
            SetStatus(string.Format("회전 : {0}개", _selectedShapes.Count));
        }

        // 선택 형상이 입력한 방향을 바라보게 합니다.
        private void btnDirectionSelected_Click(object sender, EventArgs e)
        {
            if (_selectedShapes.Count == 0) { SetStatus("형상 목록에서 형상을 선택하세요."); return; }

            vizcore3dx.Shape.SetRotation(_selectedShapes, ReadPoint(numAxisX, numAxisY, numAxisZ));
            SetStatus(string.Format("방향 지정 : {0}개", _selectedShapes.Count));
        }

        // 선택 형상을 지웁니다.
        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (_selectedShapes.Count == 0) { SetStatus("삭제할 형상을 목록에서 선택하세요."); return; }

            int count = _selectedShapes.Count;
            vizcore3dx.Shape.Delete(_selectedShapes);
            RefreshList();
            SetStatus(string.Format("삭제 : {0}개", count));
        }
        #endregion

        #region 선분 집합 입력
        // 첫 번째 점 → 두 번째 점을 선분 하나로 등록합니다. 선분 집합 형상을 만들 때 씁니다.
        private void btnLineSegmentAdd_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.Vector3D start = Point1();
            VIZCore3DX.NET.Data.Vector3D end = Point2();
            if (start == end) { SetStatus("선분의 시작점과 끝점은 같을 수 없습니다."); return; }

            VIZCore3DX.NET.Data.Line3D line = new VIZCore3DX.NET.Data.Line3D
            {
                Start3D = new VIZCore3DX.NET.Data.Vertex3D(start.X, start.Y, start.Z),
                End3D = new VIZCore3DX.NET.Data.Vertex3D(end.X, end.Y, end.Z)
            };

            int row = dgvLineSegments.Rows.Add(FormatPoint(start), FormatPoint(end));
            dgvLineSegments.Rows[row].Tag = line;
            dgvLineSegments.ClearSelection();
            dgvLineSegments.Rows[row].Selected = true;
            SetStatus(string.Format("선분 등록 : {0}개", dgvLineSegments.Rows.Count));
        }

        // 고른 선분을 등록에서 뺍니다.
        private void btnLineSegmentRemove_Click(object sender, EventArgs e)
        {
            if (dgvLineSegments.SelectedRows.Count == 0) return;

            dgvLineSegments.Rows.Remove(dgvLineSegments.SelectedRows[0]);
            SetStatus(string.Format("선분 등록 : {0}개", dgvLineSegments.Rows.Count));
        }

        // 등록한 선분을 모두 지웁니다.
        private void btnLineSegmentClear_Click(object sender, EventArgs e)
        {
            dgvLineSegments.Rows.Clear();
            SetStatus("등록한 선분을 모두 지웠습니다.");
        }
        #endregion

        #region 형상 설정 화면
        private void UpdateCreateUI()
        {
            if (cmbShapeType.SelectedItem == null || cmbCreateMode.SelectedItem == null) return;

            ConfigureCreateUI(SelectedKind(), SelectedMode());
        }

        // 입력 칸을 기본 상태로 되돌린 뒤 종류별 설정을 덧입힙니다.
        private void ConfigureCreateUI(ShapeKind kind, CreateMode mode)
        {
            // 선분 집합은 기본 방식만 지원합니다.
            if (kind == ShapeKind.LineSegments && mode != CreateMode.Default) { cmbCreateMode.SelectedItem = CreateMode.Default; mode = CreateMode.Default; }

            cmbCreateMode.Enabled = kind != ShapeKind.LineSegments;
            ResetCreateUI(UsesRotation(kind, mode));

            switch (kind)
            {
                case ShapeKind.Point: ConfigurePoint(); break;
                case ShapeKind.LineSegment: ConfigureLineSegment(mode); break;
                case ShapeKind.LineSegments: ConfigureLineSegments(); break;
                case ShapeKind.Polyline: ConfigurePolygon("폴리라인 : 세 점을 순서대로 연결"); break;
                case ShapeKind.Circle: ConfigureCircle(mode); break;
                case ShapeKind.Rectangle: ConfigureRectangle(mode); break;
                case ShapeKind.Triangle: ConfigurePolygon("삼각형 : 세 꼭짓점으로 생성"); break;
                case ShapeKind.Mesh: ConfigureMesh(); break;
                case ShapeKind.Cube: ConfigureCube(mode); break;
                case ShapeKind.Cylinder: ConfigureCylinder(mode); break;
                case ShapeKind.Sphere: ConfigureSphere(mode); break;
                case ShapeKind.Plane: ConfigurePlane(mode); break;
                case ShapeKind.Arrow: ConfigureArrow(); break;
                case ShapeKind.Axis: ConfigureAxis(); break;
                case ShapeKind.BoundingBox: ConfigureBoundingBox(mode); break;
            }

            // 법선은 위치가 아니므로 Osnap 으로 고르지 않습니다.
            if (kind == ShapeKind.Circle || kind == ShapeKind.Plane) btnPoint2Osnap.Enabled = false;
        }

        private void ResetCreateUI(bool rotation)
        {
            SetPoint1("기준점", true);
            SetPoint2("보조점", false);
            SetPoint3("세 번째 점", false);
            SetValue1("값 1", 1000, true);
            SetValue2("값 2", 1000, false);
            SetValue3("값 3", 1000, false);
            SetCreateOptions(false, false, false);
            lblRotation.Enabled = numRotX.Enabled = numRotY.Enabled = numRotZ.Enabled = rotation;
            lblRotDegree.Enabled = numRotDegree.Enabled = rotation;
        }

        private void ConfigurePoint()
        {
            SetPoint1("위치", true);
            SetValue1("점 크기", 6, true);
            lblCreateHint.Text = "점 : 위치 + 화면 픽셀 크기(4~10) + 색상";
        }

        private void ConfigureLineSegment(CreateMode mode)
        {
            bool placed = mode == CreateMode.PositionRotation;
            SetPoint1(placed ? "배치 위치" : "시작점", true);
            SetPoint2("끝점", !placed);
            SetValue1("길이", 5000, true);
            SetCreateOptions(true, false, false);
            lblCreateHint.Text = placed ? "선분 : +X 방향 기본 선분을 위치·회전으로 배치" : "선분 : 시작점 → 끝점";
        }

        private void ConfigureLineSegments()
        {
            SetPoint1("시작점", true);
            SetPoint2("끝점", true);
            DisableValues();
            SetCreateOptions(true, false, false);
            lblCreateHint.Text = "선분 집합 : 시작점·끝점으로 '선분 집합 입력'에 선분을 여러 개 등록한 뒤 하나의 형상으로 생성";
        }

        // 폴리라인·삼각형은 세 점을 씁니다.
        private void ConfigurePolygon(string hint)
        {
            SetPoint1("점 1", true);
            SetPoint2("점 2", true);
            SetPoint3("점 3", true);
            DisableValues();
            SetCreateOptions(true, false, false);
            lblCreateHint.Text = hint;
        }

        private void ConfigureCircle(CreateMode mode)
        {
            bool placed = mode == CreateMode.PositionRotation;
            SetPoint1(placed ? "배치 위치" : "중심", true);
            SetPoint2("법선", !placed);
            SetValue1("반지름", 2000, true);
            SetCreateOptions(true, true, false);
            lblCreateHint.Text = placed ? "원 : XY 기본 원을 위치·회전으로 배치" : "원 : 중심 + 법선 + 반지름";
        }

        private void ConfigureRectangle(CreateMode mode)
        {
            SetPoint1(mode == CreateMode.PositionRotation ? "배치 위치" : "중심", true);
            SetValue1("너비", 5000, true);
            SetValue2("높이", 3000, true);
            SetCreateOptions(true, false, false);
            lblCreateHint.Text = "사각형 : XY 평면 기준, 너비/높이 지정";
        }

        private void ConfigureMesh()
        {
            SetPoint1("기준 위치", true);
            DisableValues();
            lblCreateHint.Text = "메시 : 정점/인덱스 목록으로 작은 피라미드 생성";
        }

        private void ConfigureCube(CreateMode mode)
        {
            bool input = mode != CreateMode.SelectedNodes;
            SetPoint1("위치", input);
            SetValue1("X 크기", 3000, input);
            SetValue2("Y 크기", 3000, input);
            SetValue3("Z 크기", 3000, input);
            SetCreateOptions(false, false, mode == CreateMode.Default);
            lblCreateHint.Text = input ? "박스 : 크기 + 위치 지정" : "박스 : 선택 객체의 BoundBox 크기에 맞춰 생성";
        }

        private void ConfigureCylinder(CreateMode mode)
        {
            bool input = mode != CreateMode.SelectedNodes;
            SetPoint1("위치", input);
            SetPoint2("방향", mode == CreateMode.DirectionVector);
            SetValue1("반지름", 1000, input);
            SetValue2("높이", 5000, input);
            SetCreateOptions(false, true, mode == CreateMode.Default);
            lblCreateHint.Text = mode == CreateMode.DirectionVector ? "원통 : 위치에서 지정 방향으로 생성" : mode == CreateMode.SelectedNodes ? "원통 : 선택 객체의 BoundBox 기준 생성" : "원통 : 반지름/높이/분할 지정";
        }

        private void ConfigureSphere(CreateMode mode)
        {
            bool input = mode != CreateMode.SelectedNodes;
            SetPoint1("위치", input);
            SetValue1("반지름", 2000, input);
            SetCreateOptions(false, true, mode == CreateMode.Default);
            lblCreateHint.Text = input ? "구 : 반지름 + 위치 지정" : "구 : 선택 객체의 BoundBox 기준 생성";
        }

        private void ConfigurePlane(CreateMode mode)
        {
            SetPoint1("위치", true);
            SetPoint2("법선", mode == CreateMode.DirectionVector);
            SetValue1("너비", 5000, true);
            SetValue2("높이", 3000, true);
            lblCreateHint.Text = mode == CreateMode.DirectionVector ? "평면 : 위치 + 법선으로 방향 지정" : "평면 : XY 기준 또는 위치·회전 배치";
        }

        private void ConfigureArrow()
        {
            SetPoint1("시작점", true);
            SetPoint2("끝점", true);
            SetValue1("몸통 반지름", 150, true);
            lblCreateHint.Text = "화살표 : 시작점 → 끝점";
        }

        private void ConfigureAxis()
        {
            SetPoint1("원점", true);
            SetValue1("축 길이", 5000, true);
            SetValue2("몸통 반지름", 150, true);
            lblCreateHint.Text = "좌표축 : X=빨강(+X), Y=초록(+Y), Z=파랑(+Z)";
        }

        private void ConfigureBoundingBox(CreateMode mode)
        {
            bool input = mode != CreateMode.SelectedNodes;
            SetPoint1("최솟값", input);
            SetPoint2("최댓값", input);
            DisableValues();
            SetCreateOptions(true, false, false);
            lblCreateHint.Text = input ? "바운딩 박스 : Min/Max 좌표 직접 지정" : "바운딩 박스 : 선택 객체 영역으로 생성";
        }

        // 위치·회전 방식에서 회전 입력을 쓰는 종류입니다.
        private static bool UsesRotation(ShapeKind kind, CreateMode mode)
        {
            if (mode != CreateMode.PositionRotation) return false;

            switch (kind)
            {
                case ShapeKind.LineSegment:
                case ShapeKind.Polyline:
                case ShapeKind.Circle:
                case ShapeKind.Rectangle:
                case ShapeKind.Triangle:
                case ShapeKind.Cube:
                case ShapeKind.Cylinder:
                case ShapeKind.Sphere:
                case ShapeKind.Plane:
                    return true;
                default:
                    return false;
            }
        }

        private void SetPoint1(string text, bool enabled)
        {
            SetPointRow(lblPoint1, numP1X, numP1Y, numP1Z, btnPoint1Osnap, text, enabled);
        }

        private void SetPoint2(string text, bool enabled)
        {
            SetPointRow(lblPoint2, numP2X, numP2Y, numP2Z, btnPoint2Osnap, text, enabled);
        }

        private void SetPoint3(string text, bool enabled)
        {
            SetPointRow(lblPoint3, numP3X, numP3Y, numP3Z, btnPoint3Osnap, text, enabled);
        }

        private static void SetPointRow(Label title, NumericUpDown x, NumericUpDown y, NumericUpDown z, Button osnap, string text, bool enabled)
        {
            title.Text = text;
            title.Enabled = x.Enabled = y.Enabled = z.Enabled = osnap.Enabled = enabled;
        }

        private void SetValue1(string text, decimal value, bool enabled)
        {
            SetValueRow(lblValue1, numValue1, text, value, enabled);
        }

        private void SetValue2(string text, decimal value, bool enabled)
        {
            SetValueRow(lblValue2, numValue2, text, value, enabled);
        }

        private void SetValue3(string text, decimal value, bool enabled)
        {
            SetValueRow(lblValue3, numValue3, text, value, enabled);
        }

        private static void SetValueRow(Label label, NumericUpDown num, string text, decimal value, bool enabled)
        {
            label.Text = text;
            num.Value = Math.Max(num.Minimum, Math.Min(num.Maximum, value));
            label.Enabled = num.Enabled = enabled;
        }

        private void DisableValues()
        {
            lblValue1.Enabled = numValue1.Enabled = false;
            lblValue2.Enabled = numValue2.Enabled = false;
            lblValue3.Enabled = numValue3.Enabled = false;
        }

        private void SetCreateOptions(bool stroke, bool segment, bool anchor)
        {
            lblStrokeThickness.Enabled = numStrokeThickness.Enabled = stroke;
            lblStrokePattern.Enabled = cmbStrokePattern.Enabled = stroke;
            lblSegmentCount.Enabled = numSegmentCount.Enabled = segment;
            lblAxisAnchor.Enabled = cmbAxisAnchor.Enabled = anchor;
        }

        private void UpdateHeatmapUI()
        {
            bool usePoint = Equals(cmbHeatmapSource.SelectedItem, HeatmapSource.DistanceToPoint);

            lblHeatmapPoint.Enabled = usePoint;
            numHeatmapX.Enabled = numHeatmapY.Enabled = numHeatmapZ.Enabled = usePoint;
            btnHeatmapPointOsnap.Enabled = usePoint;
        }
        #endregion

        #region 형상 생성
        // 종류별 생성 메서드로 나눕니다. 형상은 원점 기준으로 만들고 위치는 ApplyPlacement 가 옮깁니다.
        private List<VIZCore3DX.NET.Data.ShapeItem> CreateShape(ShapeKind kind)
        {
            CreateMode mode = SelectedMode();

            switch (kind)
            {
                case ShapeKind.Point: return Single(CreatePoint());
                case ShapeKind.LineSegment: return Single(CreateLineSegment(mode));
                case ShapeKind.LineSegments: return Single(CreateLineSegments());
                case ShapeKind.Polyline: return Single(CreatePolyline());
                case ShapeKind.Circle: return Single(CreateCircle(mode));
                case ShapeKind.Rectangle: return Single(CreateRectangle());
                case ShapeKind.Triangle: return Single(CreateTriangle());
                case ShapeKind.Mesh: return Single(CreateMesh());
                case ShapeKind.Cube: return Single(CreateCube(mode));
                case ShapeKind.Cylinder: return Single(CreateCylinder(mode));
                case ShapeKind.Sphere: return Single(CreateSphere(mode));
                case ShapeKind.Plane: return Single(CreatePlane());
                case ShapeKind.Arrow: return Single(CreateArrow());
                case ShapeKind.Axis: return CreateAxis();
                case ShapeKind.BoundingBox: return Single(CreateBoundingBox(mode));
                default: return null;
            }
        }

        // 만든 형상을 위치로 옮기고, 방식에 따라 회전·방향을 적용한 뒤 카테고리를 붙입니다.
        private void ApplyPlacement(List<VIZCore3DX.NET.Data.ShapeItem> created)
        {
            ShapeKind kind = SelectedKind();
            CreateMode mode = SelectedMode();

            vizcore3dx.Shape.SetPosition(created, _createPosition);

            if (UsesRotation(kind, mode)) vizcore3dx.Shape.SetRotation(created, Rotation());
            else if (mode == CreateMode.DirectionVector && (kind == ShapeKind.Cylinder || kind == ShapeKind.Plane)) vizcore3dx.Shape.SetRotation(created, Point2());

            string category = txtCreateCategory.Text.Trim();
            if (category.Length > 0) vizcore3dx.Shape.AddCategory(created, category);
        }

        private VIZCore3DX.NET.Data.ShapeItem CreatePoint()
        {
            // 점 크기는 화면 픽셀 4~10 입니다.
            float size = Math.Max(4f, Math.Min(10f, (float)numValue1.Value));
            return vizcore3dx.Shape.CreatePointShape(Zero(), size, btnCreateColor.BackColor);
        }

        private VIZCore3DX.NET.Data.ShapeItem CreateLineSegment(CreateMode mode)
        {
            VIZCore3DX.NET.Data.Vector3D end = mode == CreateMode.PositionRotation ? new VIZCore3DX.NET.Data.Vector3D((float)numValue1.Value, 0f, 0f) : FromPoint1(Point2());
            if (end.IsZero()) { SetStatus("선분의 시작점과 끝점은 같을 수 없습니다."); return null; }

            VIZCore3DX.NET.Data.Line3D line = new VIZCore3DX.NET.Data.Line3D { Start3D = Origin(), End3D = new VIZCore3DX.NET.Data.Vertex3D(end.X, end.Y, end.Z) };
            return vizcore3dx.Shape.CreateLineSegmentShape(line, Thickness(), Pattern(), btnCreateColor.BackColor);
        }

        // 등록한 선분들을 첫 선분의 시작점 기준으로 옮겨 하나의 형상으로 만듭니다.
        private VIZCore3DX.NET.Data.ShapeItem CreateLineSegments()
        {
            List<VIZCore3DX.NET.Data.Line3D> segments = new List<VIZCore3DX.NET.Data.Line3D>();
            foreach (DataGridViewRow row in dgvLineSegments.Rows)
                if (row.Tag is VIZCore3DX.NET.Data.Line3D) segments.Add((VIZCore3DX.NET.Data.Line3D)row.Tag);

            if (segments.Count == 0) { SetStatus("생성할 선분을 먼저 등록하세요."); return null; }

            VIZCore3DX.NET.Data.Vertex3D origin = segments[0].Start3D;
            _createPosition = new VIZCore3DX.NET.Data.Vector3D(origin.X, origin.Y, origin.Z);

            List<VIZCore3DX.NET.Data.Line3D> local = segments.Select(line => new VIZCore3DX.NET.Data.Line3D
            {
                Start3D = line.Start3D - origin,
                End3D = line.End3D - origin
            }).ToList();

            return vizcore3dx.Shape.CreateLineSegmentsShape(local, Thickness(), Pattern(), btnCreateColor.BackColor);
        }

        private VIZCore3DX.NET.Data.ShapeItem CreatePolyline()
        {
            List<VIZCore3DX.NET.Data.Vector3D> points = new List<VIZCore3DX.NET.Data.Vector3D> { Zero(), FromPoint1(Point2()), FromPoint1(Point3()) };
            return vizcore3dx.Shape.CreatePolylineShape(points, Thickness(), Pattern(), btnCreateColor.BackColor);
        }

        private VIZCore3DX.NET.Data.ShapeItem CreateCircle(CreateMode mode)
        {
            VIZCore3DX.NET.Data.Vector3D normal = mode == CreateMode.PositionRotation ? new VIZCore3DX.NET.Data.Vector3D(0f, 0f, 1f) : Point2();
            VIZCore3DX.NET.Data.CircleData circle = new VIZCore3DX.NET.Data.CircleData { Center = Origin(), Normal = normal, Radius = (float)numValue1.Value };
            return vizcore3dx.Shape.CreateCircleShape(circle, SegmentCount(), Thickness(), Pattern(), btnCreateColor.BackColor);
        }

        private VIZCore3DX.NET.Data.ShapeItem CreateRectangle()
        {
            VIZCore3DX.NET.Data.Rectangle3D rectangle = new VIZCore3DX.NET.Data.Rectangle3D
            {
                Center = Origin(),
                UAxis = new VIZCore3DX.NET.Data.Vector3D(1f, 0f, 0f),
                VAxis = new VIZCore3DX.NET.Data.Vector3D(0f, 1f, 0f),
                Width = (float)numValue1.Value,
                Height = (float)numValue2.Value
            };
            return vizcore3dx.Shape.CreateRectangleShape(rectangle, Thickness(), Pattern(), btnCreateColor.BackColor);
        }

        private VIZCore3DX.NET.Data.ShapeItem CreateTriangle()
        {
            VIZCore3DX.NET.Data.Vector3D p2 = FromPoint1(Point2());
            VIZCore3DX.NET.Data.Vector3D p3 = FromPoint1(Point3());
            VIZCore3DX.NET.Data.Triangle3D triangle = new VIZCore3DX.NET.Data.Triangle3D
            {
                Point1 = Origin(),
                Point2 = new VIZCore3DX.NET.Data.Vertex3D(p2.X, p2.Y, p2.Z),
                Point3 = new VIZCore3DX.NET.Data.Vertex3D(p3.X, p3.Y, p3.Z)
            };
            return vizcore3dx.Shape.CreateTriangleShape(triangle, Thickness(), Pattern(), btnCreateColor.BackColor);
        }

        // 정점 5개·삼각형 6개로 작은 피라미드를 만듭니다.
        private VIZCore3DX.NET.Data.ShapeItem CreateMesh()
        {
            List<VIZCore3DX.NET.Data.Vertex3D> vertices = new List<VIZCore3DX.NET.Data.Vertex3D>
            {
                new VIZCore3DX.NET.Data.Vertex3D(0f, 0f, 0f),
                new VIZCore3DX.NET.Data.Vertex3D(2000f, 0f, 0f),
                new VIZCore3DX.NET.Data.Vertex3D(2000f, 2000f, 0f),
                new VIZCore3DX.NET.Data.Vertex3D(0f, 2000f, 0f),
                new VIZCore3DX.NET.Data.Vertex3D(1000f, 1000f, 2500f)
            };
            List<int> indices = new List<int> { 0, 2, 1, 0, 3, 2, 0, 1, 4, 1, 2, 4, 2, 3, 4, 3, 0, 4 };
            return vizcore3dx.Shape.CreateMeshShape(vertices, indices, btnCreateColor.BackColor);
        }

        private VIZCore3DX.NET.Data.ShapeItem CreateCube(CreateMode mode)
        {
            if (mode == CreateMode.SelectedNodes)
            {
                VIZCore3DX.NET.Data.BoundBox3D bb;
                if (!TryGetSelectedBoundBox(out bb)) return null;

                _createPosition = Center(bb);
                VIZCore3DX.NET.Data.Vector3D size = new VIZCore3DX.NET.Data.Vector3D(bb.LengthX, bb.LengthY, bb.LengthZ);
                return vizcore3dx.Shape.CreateCubeShape(size, btnCreateColor.BackColor, VIZCore3DX.NET.Data.AxisAnchor.Center, Zero());
            }

            VIZCore3DX.NET.Data.Vector3D input = new VIZCore3DX.NET.Data.Vector3D((float)numValue1.Value, (float)numValue2.Value, (float)numValue3.Value);
            return vizcore3dx.Shape.CreateCubeShape(input, btnCreateColor.BackColor, AnchorFor(mode), Zero());
        }

        private VIZCore3DX.NET.Data.ShapeItem CreateCylinder(CreateMode mode)
        {
            // 원통 분할은 8 이상입니다.
            ushort segments = Math.Max((ushort)8, SegmentCount());
            float radius = (float)numValue1.Value;
            float height = (float)numValue2.Value;

            if (mode == CreateMode.SelectedNodes)
            {
                VIZCore3DX.NET.Data.BoundBox3D bb;
                if (!TryGetSelectedBoundBox(out bb)) return null;

                _createPosition = Center(bb);
                radius = bb.MaxLengthXY / 2f;
                height = bb.LengthZ;
            }

            return vizcore3dx.Shape.CreateCylinderShape(radius, height, btnCreateColor.BackColor, AnchorFor(mode), Zero(), segments);
        }

        private VIZCore3DX.NET.Data.ShapeItem CreateSphere(CreateMode mode)
        {
            float radius = (float)numValue1.Value;

            if (mode == CreateMode.SelectedNodes)
            {
                VIZCore3DX.NET.Data.BoundBox3D bb;
                if (!TryGetSelectedBoundBox(out bb)) return null;

                _createPosition = Center(bb);
                radius = bb.MaxLength / 2f;
            }

            return vizcore3dx.Shape.CreateSphereShape(radius, btnCreateColor.BackColor, AnchorFor(mode), Zero(), SegmentCount());
        }

        private VIZCore3DX.NET.Data.ShapeItem CreatePlane()
        {
            return vizcore3dx.Shape.CreatePlaneShape((float)numValue1.Value, (float)numValue2.Value, btnCreateColor.BackColor, Zero());
        }

        private VIZCore3DX.NET.Data.ShapeItem CreateArrow()
        {
            VIZCore3DX.NET.Data.Vector3D end = FromPoint1(Point2());
            if (end.IsZero()) { SetStatus("화살표의 시작점과 끝점은 같을 수 없습니다."); return null; }

            return vizcore3dx.Shape.CreateArrowShape(Zero(), end, (float)numValue1.Value, btnCreateColor.BackColor);
        }

        // 좌표축은 X·Y·Z 화살표 세 개로 만들어집니다.
        private List<VIZCore3DX.NET.Data.ShapeItem> CreateAxis()
        {
            List<VIZCore3DX.NET.Data.ShapeItem.MeshShape> axes = vizcore3dx.Shape.CreateAxisShape(Zero(), (float)numValue1.Value, (float)numValue2.Value);
            return axes == null ? null : axes.Cast<VIZCore3DX.NET.Data.ShapeItem>().ToList();
        }

        private VIZCore3DX.NET.Data.ShapeItem CreateBoundingBox(CreateMode mode)
        {
            if (mode == CreateMode.SelectedNodes)
            {
                VIZCore3DX.NET.Data.BoundBox3D bb;
                if (!TryGetSelectedBoundBox(out bb)) return null;

                float hx = bb.LengthX / 2f;
                float hy = bb.LengthY / 2f;
                float hz = bb.LengthZ / 2f;
                _createPosition = Center(bb);
                return vizcore3dx.Shape.CreateBoundingBoxShape(new VIZCore3DX.NET.Data.Vertex3D(-hx, -hy, -hz), new VIZCore3DX.NET.Data.Vertex3D(hx, hy, hz), Thickness(), Pattern(), btnCreateColor.BackColor);
            }

            VIZCore3DX.NET.Data.Vector3D d = FromPoint1(Point2());
            VIZCore3DX.NET.Data.Vertex3D min = new VIZCore3DX.NET.Data.Vertex3D(Math.Min(0f, d.X), Math.Min(0f, d.Y), Math.Min(0f, d.Z));
            VIZCore3DX.NET.Data.Vertex3D max = new VIZCore3DX.NET.Data.Vertex3D(Math.Max(0f, d.X), Math.Max(0f, d.Y), Math.Max(0f, d.Z));
            return vizcore3dx.Shape.CreateBoundingBoxShape(min, max, Thickness(), Pattern(), btnCreateColor.BackColor);
        }
        #endregion

        #region Helpers
        // 모델이 열려 있지 않으면 상태 문구를 남기고 false 를 돌려줍니다.
        private bool IsModelOpened()
        {
            if (vizcore3dx.Model.IsOpen()) return true;

            SetStatus("먼저 모델을 여세요.");
            return false;
        }

        private void SetStatus(string message)
        {
            lblStatus.Text = message;
        }

        private void RunOnUi(Action action)
        {
            if (InvokeRequired) BeginInvoke(action);
            else action();
        }

        private ShapeKind SelectedKind()
        {
            return (ShapeKind)cmbShapeType.SelectedItem;
        }

        private CreateMode SelectedMode()
        {
            return (CreateMode)cmbCreateMode.SelectedItem;
        }

        // 전체 대상이면 null, 아니면 고른 형상을 돌려줍니다. null 이면 목록 인자가 없는 호출을 씁니다.
        private List<VIZCore3DX.NET.Data.ShapeItem> Targets()
        {
            return Equals(cmbManageTarget.SelectedItem, ManageTarget.All) ? null : _selectedShapes;
        }

        // 목록 인자가 꼭 필요한 호출(카테고리 지정·해제)에 넘길 형상입니다.
        private List<VIZCore3DX.NET.Data.ShapeItem> ManageShapes()
        {
            return Targets() ?? vizcore3dx.Shape.Shapes;
        }

        private static string TargetLabel(List<VIZCore3DX.NET.Data.ShapeItem> targets)
        {
            return targets == null ? "전체" : string.Format("{0}개", targets.Count);
        }

        private void SetVisible(bool visible)
        {
            List<VIZCore3DX.NET.Data.ShapeItem> targets = Targets();
            if (targets == null) vizcore3dx.Shape.Show(visible);
            else vizcore3dx.Shape.Show(visible, targets);
            SetStatus(string.Format("{0} : {1}", visible ? "표시" : "숨김", TargetLabel(targets)));
        }

        // 고른 형상을 기억하고, 첫 형상의 위치를 이동 칸에 보입니다.
        private void SetSelectedShapes(List<VIZCore3DX.NET.Data.ShapeItem> shapes)
        {
            _selectedShapes = shapes;
            if (shapes.Count > 0 && shapes[0].Position != null) ShowMovePosition(shapes[0].Position);

            SetStatus(shapes.Count == 0 ? "선택 형상 : 없음" : string.Format("선택 형상 : {0} ({1}개)", TypeName(shapes[0]), shapes.Count));
        }

        // 형상마다 같은 이동량을 더합니다. 뷰 잠금으로 형상마다 다시 그리지 않게 합니다.
        private void MoveShapes(List<VIZCore3DX.NET.Data.ShapeItem> shapes, VIZCore3DX.NET.Data.Vector3D move)
        {
            vizcore3dx.BeginUpdate();
            try
            {
                foreach (VIZCore3DX.NET.Data.ShapeItem shape in shapes)
                {
                    VIZCore3DX.NET.Data.Vector3D position = shape.Position ?? Zero();
                    vizcore3dx.Shape.SetPosition(shape, position + move);
                }
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        private void RefreshList()
        {
            ShowShapes(vizcore3dx.Shape.Shapes);
        }

        // 형상 목록을 표에 채웁니다. 표를 다시 채우면 고른 형상은 비워집니다.
        private void ShowShapes(List<VIZCore3DX.NET.Data.ShapeItem> shapes)
        {
            _syncing = true;
            try
            {
                dgvShapes.Rows.Clear();
                if (shapes != null)
                    for (int i = 0; i < shapes.Count; i++)
                    {
                        if (shapes[i] == null) continue;

                        int row = dgvShapes.Rows.Add(i + 1, TypeName(shapes[i]), string.IsNullOrEmpty(shapes[i].Category) ? "-" : shapes[i].Category);
                        dgvShapes.Rows[row].Tag = shapes[i];
                    }
                dgvShapes.ClearSelection();
            }
            finally
            {
                _syncing = false;
            }

            _selectedShapes = new List<VIZCore3DX.NET.Data.ShapeItem>();
        }

        private static string TypeName(VIZCore3DX.NET.Data.ShapeItem shape)
        {
            string name = shape.GetType().Name;
            return name.EndsWith("Shape") ? name.Substring(0, name.Length - 5) : name;
        }

        // 뷰에서 점을 찍어 좌표 칸 세 개를 채웁니다.
        private async System.Threading.Tasks.Task PickPoint(string command, NumericUpDown x, NumericUpDown y, NumericUpDown z)
        {
            if (!IsModelOpened()) return;

            VIZCore3DX.NET.Data.OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();
            osnap.CommandText = command;
            VIZCore3DX.NET.Data.OsnapResult result = await osnap.GetResultAsync();
            if (result != null) SetPositionValue(x, y, z, result.Position);
        }

        // 좌표를 칸의 범위 안으로 맞춰 넣습니다.
        // 형상을 옮기지 않고 위치 칸에 값만 보입니다.
        private void ShowMovePosition(VIZCore3DX.NET.Data.Vector3D position)
        {
            _fillingMovePosition = true;
            try
            {
                SetPositionValue(numMoveX, numMoveY, numMoveZ, position);
            }
            finally
            {
                _fillingMovePosition = false;
            }
        }

        private static void SetPositionValue(NumericUpDown x, NumericUpDown y, NumericUpDown z, VIZCore3DX.NET.Data.Vector3D position)
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
                if (dialog.ShowDialog(this) != DialogResult.OK) return null;

                button.BackColor = dialog.Color;
                return dialog.Color;
            }
        }

        // 선택 노드의 경계상자를 구합니다. 모델이 없거나 선택이 없으면 false 입니다.
        private bool TryGetSelectedBoundBox(out VIZCore3DX.NET.Data.BoundBox3D boundBox)
        {
            boundBox = null;
            if (!IsModelOpened()) return false;

            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);
            if (nodes.Count > 0) boundBox = vizcore3dx.Object3D.GetBoundBox(nodes);
            if (boundBox == null) SetStatus("뷰에서 노드를 먼저 선택하세요.");
            return boundBox != null;
        }

        // 정점마다 계산할 스칼라 함수를 돌려줍니다.
        private Func<VIZCore3DX.NET.Data.Vertex3D, double> HeatmapScalar()
        {
            switch ((HeatmapSource)cmbHeatmapSource.SelectedItem)
            {
                case HeatmapSource.X: return v => v.X;
                case HeatmapSource.Y: return v => v.Y;
                case HeatmapSource.DistanceToPoint: return DistanceFrom((double)numHeatmapX.Value, (double)numHeatmapY.Value, (double)numHeatmapZ.Value);
                default: return v => v.Z;
            }
        }

        private static Func<VIZCore3DX.NET.Data.Vertex3D, double> DistanceFrom(double px, double py, double pz)
        {
            return v => Math.Sqrt((v.X - px) * (v.X - px) + (v.Y - py) * (v.Y - py) + (v.Z - pz) * (v.Z - pz));
        }

        private string FailureReason()
        {
            VIZCore3DX.NET.Data.OperationStatus status = vizcore3dx.Shape.LastOperationStatus;
            return status == null ? "-" : status.Result.ToString();
        }

        private static List<VIZCore3DX.NET.Data.ShapeItem> Single(VIZCore3DX.NET.Data.ShapeItem shape)
        {
            return shape == null ? null : new List<VIZCore3DX.NET.Data.ShapeItem> { shape };
        }

        private VIZCore3DX.NET.Data.Vector3D Point1()
        {
            return ReadPoint(numP1X, numP1Y, numP1Z);
        }

        private VIZCore3DX.NET.Data.Vector3D Point2()
        {
            return ReadPoint(numP2X, numP2Y, numP2Z);
        }

        private VIZCore3DX.NET.Data.Vector3D Point3()
        {
            return ReadPoint(numP3X, numP3Y, numP3Z);
        }

        private static VIZCore3DX.NET.Data.Vector3D ReadPoint(NumericUpDown x, NumericUpDown y, NumericUpDown z)
        {
            return new VIZCore3DX.NET.Data.Vector3D((float)x.Value, (float)y.Value, (float)z.Value);
        }

        // 첫 번째 점을 원점으로 본 상대 좌표입니다.
        private VIZCore3DX.NET.Data.Vector3D FromPoint1(VIZCore3DX.NET.Data.Vector3D p)
        {
            return p - Point1();
        }

        private static VIZCore3DX.NET.Data.Vector3D Center(VIZCore3DX.NET.Data.BoundBox3D bb)
        {
            return new VIZCore3DX.NET.Data.Vector3D(bb.GetCenter());
        }

        private static VIZCore3DX.NET.Data.Vector3D Zero()
        {
            return new VIZCore3DX.NET.Data.Vector3D(0f, 0f, 0f);
        }

        private static VIZCore3DX.NET.Data.Vertex3D Origin()
        {
            return new VIZCore3DX.NET.Data.Vertex3D(0f, 0f, 0f);
        }

        private static string FormatPoint(VIZCore3DX.NET.Data.Vector3D p)
        {
            return string.Format("{0:0.###}, {1:0.###}, {2:0.###}", p.X, p.Y, p.Z);
        }

        // 선 두께는 1~10 입니다.
        private float Thickness()
        {
            return Math.Max(1f, Math.Min(10f, (float)numStrokeThickness.Value));
        }

        // 분할 수는 4~128 입니다.
        private ushort SegmentCount()
        {
            return (ushort)Math.Max(4m, Math.Min(128m, numSegmentCount.Value));
        }

        private VIZCore3DX.NET.Data.StrokePattern Pattern()
        {
            return (VIZCore3DX.NET.Data.StrokePattern)cmbStrokePattern.SelectedItem;
        }

        // 기본 방식에서만 기준점 콤보를 쓰고, 나머지 방식은 중심 기준입니다.
        private VIZCore3DX.NET.Data.AxisAnchor AnchorFor(CreateMode mode)
        {
            return mode == CreateMode.Default ? (VIZCore3DX.NET.Data.AxisAnchor)cmbAxisAnchor.SelectedItem : VIZCore3DX.NET.Data.AxisAnchor.Center;
        }

        private VIZCore3DX.NET.Data.Quaternion Rotation()
        {
            VIZCore3DX.NET.Data.Vector3D axis = ReadPoint(numRotX, numRotY, numRotZ);
            return VIZCore3DX.NET.Data.Quaternion.FromAxisAngle(axis, VIZCore3DX.NET.Utility.AngleFormatHelper.DegreesToRadians((double)numRotDegree.Value));
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
        #endregion
    }
}
