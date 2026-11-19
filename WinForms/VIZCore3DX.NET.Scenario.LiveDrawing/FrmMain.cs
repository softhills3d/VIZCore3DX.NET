using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Scenario.LiveDrawing
{
    // 시나리오 예제 "살아 있는 도면"
    // 3D 모델에서 2D 도면을 만들고, 그 도면을 3D 뷰와 같은 좌표를 쓰는 지도로 쓰는 흐름을 장면 순서대로 보여 줍니다.
    // 장면 하나 = 메서드 하나(#region 장면), 장면에 쓰는 값은 SceneValues.cs 한 곳에 있습니다.
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 2D 도면 — 내장 투영 결과 창을 오른쪽 칸에 넣고, 그 안의 뷰어(Viewer)를 받아 오버레이·측정 API 를 씁니다.
        private VIZCore3DX.NET.Dialogs.ProjectionResultDialog _drawingWindow;
        private VIZCore3DX.NET.Controls.ProjectionViewerControl _viewer;

        // 장면 목록(이름, 장면 메서드)과 다음에 진행할 장면 번호
        private readonly List<KeyValuePair<string, Action>> _scenes = new List<KeyValuePair<string, Action>>();
        private int _next;

        // 장면 안의 동작을 시간 순서로 실행하는 타이머
        private readonly SceneTimeline _timeline = new SceneTimeline();

        // 장면 대상 — 모델 전체와 블록 하나
        private List<Data.Node> _modelParts;
        private Data.BoundBox3D _modelBox;
        private Data.Node _block;
        private List<Data.Node> _blockParts;
        private Data.BoundBox3D _blockBox;

        // 만든 도면
        private Data.ProjectionItem _sectionDrawing;
        private Data.ProjectionItem _blockDrawing;

        // 3D 모델을 도면과 같은 평면으로 자르는 단면
        private Data.SectionItem _section;

        // 도면에서 찾은 닫힌 영역(넓은 순서) — 면적 장면이 찾고 치수 장면이 이어서 씁니다.
        private List<Data.ProjectionEmptyRegion> _regions = new List<Data.ProjectionEmptyRegion>();

        // 닫힌 영역을 3D 뷰에 그린 형상 (지울 때 씁니다)
        private readonly List<Data.ShapeItem> _shapes = new List<Data.ShapeItem>();

        // 도면 위 표식 (0 이면 없음)
        private int _cameraMarker;
        private int _targetPoint;
        private int _tourMarker;

        public FrmMain()
        {
            InitializeComponent();

            // 장면 목록은 뷰어와 무관하므로 생성자에서 채웁니다.
            InitializeScenes();
            _timeline.Tick += Timeline_Tick;

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction — 가운데 칸은 3D 뷰, 오른쪽 칸은 2D 도면
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer2.Panel1.Controls.Add(vizcore3dx);

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
        }

        #region Initialize

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
        }

        private void InitializeVIZCore3DX()
        {
            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();

            OpenDrawingWindow();
            SetStatus("모델을 열어 주세요.");
        }

        // 장면 이름과 장면 메서드를 순서대로 등록합니다. 이 순서가 진행 순서입니다.
        private void InitializeScenes()
        {
            _scenes.Add(new KeyValuePair<string, Action>("① 전체 단면 — 3D 를 자르고 같은 평면의 도면 만들기", SceneSection));
            _scenes.Add(new KeyValuePair<string, Action>("② 살아 있는 도면 — 3D 카메라를 도면 위 표식으로", SceneLiveMap));
            _scenes.Add(new KeyValuePair<string, Action>("③ 블록 도면 — 가려진 선을 지운 도면", SceneBlockDrawing));
            _scenes.Add(new KeyValuePair<string, Action>("④ 닫힌 영역 면적 — 2D 와 3D 에 함께 칠하기", SceneClosedAreas));
            _scenes.Add(new KeyValuePair<string, Action>("⑤ 치수 — 2D 측정과 같은 값의 3D 치수선", SceneMeasure));
            _scenes.Add(new KeyValuePair<string, Action>("⑥ 도면 점 → 3D — 도면 위 경로로 카메라 이동", ScenePointTour));
            _scenes.Add(new KeyValuePair<string, Action>("⑦ 확대 — 도면의 한 부분을 자세히", SceneZoomDetail));
            _scenes.Add(new KeyValuePair<string, Action>("⑧ 내보내기 — DXF · SVG", SceneExport));

            foreach (KeyValuePair<string, Action> scene in _scenes)
                lstScenes.Items.Add(scene.Key);
        }

        // 창을 닫을 때 장면 타이머부터 멈춥니다.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _timeline.Stop();
            base.OnFormClosing(e);
        }

        #endregion

        #region 1. 모델

        // 모델을 엽니다. 장면은 열린 모델의 범위를 기준으로 진행되므로 어떤 모델이든 쓸 수 있습니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            ClearScene();
            SetStatus("모델을 열었습니다. 블록 이름을 넣고 [다음 장면]을 누르세요.");
        }

        #endregion

        #region 3. 장면

        // 다음 장면을 진행합니다. 첫 장면 전에 블록을 찾아 두고, 장면마다 이전 장면의 예약 동작은 취소합니다.
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;
            if (_next >= _scenes.Count) { SetStatus("마지막 장면입니다. [처음으로]를 누르세요."); return; }

            if (_next == 0)
            {
                if (!IsBlockReady()) return;
                PrepareTargets();
            }

            _timeline.Clear();
            lstScenes.SelectedIndex = _next;
            _scenes[_next++].Value();
        }

        // 타이머가 돌 때마다 3D 카메라의 위치를 도면 좌표로 바꿔 도면 위 표식을 옮깁니다. 마우스로 카메라를 돌려도 따라옵니다.
        private void Timeline_Tick()
        {
            if (_cameraMarker == 0 || _sectionDrawing == null) return;

            Data.CameraData camera = vizcore3dx.View.GetCameraData();
            if (camera == null) return;

            // 3D 좌표 → 도면 좌표
            Data.Vector2 eye = _sectionDrawing.WorldToLocal(new Data.Vector3D(camera.EyePosition));
            Data.Vector2 target = _sectionDrawing.WorldToLocal(new Data.Vector3D(camera.PivotPosition));
            if ((object)eye == null || (object)target == null) return;

            float heading = (float)(Math.Atan2(target.Y - eye.Y, target.X - eye.X) * 180.0 / Math.PI);
            _viewer.SetOverlayPosition(_cameraMarker, eye, heading);
            _viewer.SetOverlayPosition(_targetPoint, target);
        }

        #endregion

        #region 5. 정리

        // 어느 장면에서든 처음 상태로 되돌립니다.
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearScene();
            if (vizcore3dx.Model.IsOpen())
            {
                vizcore3dx.View.Projection = Data.Projections.Perspective;
                vizcore3dx.View.FitToView();
            }
            SetStatus("처음으로 되돌렸습니다.");
        }

        // 장면 진행을 처음으로 되돌리고, 장면이 만든 도면·표식·3D 표시를 전부 지웁니다.
        private void ClearScene()
        {
            _timeline.Clear();
            _next = 0;
            lstScenes.SelectedIndex = -1;

            _cameraMarker = _targetPoint = _tourMarker = 0;
            _sectionDrawing = _blockDrawing = null;
            _regions.Clear();

            // 도면 창을 새로 띄워 빈 도면으로 되돌립니다. 표식·측정은 이전 창과 함께 사라집니다.
            OpenDrawingWindow();

            if (vizcore3dx.Model.IsOpen()) Clear3D();
        }

        private void Clear3D()
        {
            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.Projection.Clear();
                vizcore3dx.View.Effect.ClearDimensionLines(SceneValues.EffectGroup);
                vizcore3dx.View.Effect.ClearMarkers(SceneValues.EffectGroup);
                vizcore3dx.View.Effect.ClearPulseOutlines(SceneValues.EffectGroup);
                vizcore3dx.View.XRay.Enable = false;
                vizcore3dx.Object3D.Show(Data.Object3DKind.ALL, true);
                ClearAreas3D();

                if (_section != null) vizcore3dx.Section.Delete(_section);
                _section = null;
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        #endregion

        #region 장면

        // ① 전체 단면 — 모델 전체를 수평으로 잘라 도면을 만들고, 3D 모델도 같은 평면으로 자릅니다.
        //    단면 도면에는 같은 평면의 외곽선을 겹치고, 3D 카메라는 평행 투영으로 도면과 같은 방향에 놓습니다.
        private void SceneSection()
        {
            Data.Vector3D position = PointInBox(_modelBox, new PointF(0.5f, 0.5f), SceneValues.SectionHeight);
            _sectionDrawing = CreateTimed("전체 단면", () => vizcore3dx.Projection.CreateCrossSection(
                _modelParts, SceneValues.PlaneNormal, position, SceneValues.DrawingColor, SceneValues.DrawingThickness, true));
            if (_sectionDrawing == null) return;

            ShowWithOutline(_sectionDrawing, _modelParts, position);
            CutModel(position);
            LookLikeDrawing(_sectionDrawing, _modelBox, 2.0);
        }

        // ② 살아 있는 도면 — 3D 카메라의 위치·시선을 도면 위 표식으로 실시간 표시합니다(Timeline_Tick).
        //    카메라가 모델 위 몇 곳을 차례로 날아다니고, 끝난 뒤 마우스로 돌려도 표식이 따라옵니다.
        private void SceneLiveMap()
        {
            if (_sectionDrawing == null) return;

            Data.Vector2 origin = _sectionDrawing.WorldToLocal(new Data.Vector3D(_modelBox.GetCenter()));
            _targetPoint = _viewer.AddOverlayPoint(_sectionDrawing, origin, SceneValues.TargetPointColor, 10f, "시선");
            _cameraMarker = _viewer.AddOverlayMarker(_sectionDrawing, origin, 0f, SceneValues.CameraMarkerColor, SceneValues.MarkerSizePx, "카메라");

            vizcore3dx.View.Projection = Data.Projections.Perspective;

            // 카메라는 모델 밖에서 바라보므로, 카메라 표식이 도면 밖으로 나가지 않게 도면을 카메라 거리만큼 넓혀 봅니다.
            float distance = _modelBox.MaxLength * SceneValues.LiveMapDistance;
            RectangleF bounds = LocalBounds(_sectionDrawing, _modelBox);
            float margin = distance * SceneValues.LiveMapMargin;
            _viewer.ZoomToBounds(_sectionDrawing,
                new Data.Vector2(bounds.Left - margin, bounds.Top - margin), new Data.Vector2(bounds.Right + margin, bounds.Bottom + margin));

            for (int i = 0; i < SceneValues.LiveMapTargets.Length; i++)
            {
                Data.Vector3D target = PointInBox(_modelBox, SceneValues.LiveMapTargets[i], SceneValues.SectionHeight);
                Data.Vector3D view = SceneValues.LiveMapViews[i];
                _timeline.After(i * SceneValues.LiveMapSecondsPerView,
                    () => FlyCamera(target, view, distance, SceneValues.LiveMapSecondsPerView));
            }
            SetStatus("3D 카메라를 움직이면 도면 위 표식이 따라갑니다.");
        }

        // ③ 블록 도면 — 블록만 불투명하게 남기고(X-Ray), 가려진 선을 지운 정사영 도면을 만듭니다.
        //    도면 평면은 블록 위에 띄워 두고, 선 색과 격자를 바꿔 보입니다.
        private void SceneBlockDrawing()
        {
            _cameraMarker = 0;
            if (_sectionDrawing != null) _sectionDrawing.IsVisible = false;
            if (_section != null) _section.Enable(false);
            vizcore3dx.View.XRay.Enable = true;
            vizcore3dx.View.XRay.Select(_blockParts, true);

            _blockDrawing = CreateTimed("블록 도면(은선 제거)", () => vizcore3dx.Projection.CreateOrthographic(
                _blockParts, SceneValues.PlaneNormal, DrawingPlane(), SceneValues.DrawingColor, SceneValues.DrawingThickness, true, false));
            if (_blockDrawing == null) return;

            _viewer.SetResult(_blockDrawing);
            _viewer.SetResultColor(_blockDrawing, SceneValues.DrawingAccent);
            _viewer.IsGridVisible = true;
            LookLikeDrawing(_blockDrawing, _blockBox, 2.0);
        }

        // ④ 닫힌 영역 면적 — 도면의 선으로 둘러싸인 영역을 찾아 넓은 순서로 2D 에 색칠하고 면적을 적습니다.
        //    같은 영역을 3D 뷰의 블록 위에도 같은 색으로 얹습니다. 3D 는 블록만 남기고 나머지를 숨깁니다.
        private void SceneClosedAreas()
        {
            if (_blockDrawing == null) return;
            _viewer.IsGridVisible = false;
            IsolateBlock();

            Stopwatch watch = Stopwatch.StartNew();
            _regions = vizcore3dx.Projection.FindClosedRegions(_blockDrawing, SceneValues.AreaMinimum);
            watch.Stop();
            SetStatus(string.Format("닫힌 영역 {0:N0} 곳 : {1:0.00} 초", _regions.Count, watch.Elapsed.TotalSeconds));

            int count = Math.Min(_regions.Count, SceneValues.AreaCount);
            for (int i = 0; i < count; i++)
            {
                Data.ProjectionEmptyRegion region = _regions[i];
                int order = i;
                _timeline.After(0.3 + i * SceneValues.AreaStepSeconds, () => AddClosedArea(region, order));
            }
        }

        // ⑤ 치수 — 찾은 영역의 폭(아래 변)·길이(왼쪽 변)와 영역 사이 간격을 2D 에서 재고, 같은 두 점의 3D 치수선을 그립니다.
        //    카메라를 비스듬히 기울여 도면이 블록 위에 떠 있는 모습을 보인 뒤, 천천히 위에서 내려다보는 방향으로 돌아옵니다.
        private void SceneMeasure()
        {
            if (_blockDrawing == null || _regions.Count == 0) return;
            vizcore3dx.View.Effect.ClearTextLabels(SceneValues.EffectGroup);   // 3D 면적 글자는 치수선과 겹치므로 지웁니다.
            TiltToFloatingDrawing(2.5);

            List<RectangleF> shapes = _regions.Take(SceneValues.MeasureShapeCount).Select(r => r.Bounds).ToList();
            double step = SceneValues.MeasureStepSeconds;
            double at = 0.5;
            int order = 0;
            foreach (RectangleF shape in shapes)
            {
                RectangleF area = shape;
                int width = order++, length = order++;
                _timeline.After(at, () => AddMeasure(area.Left, area.Bottom, area.Right, area.Bottom, width));
                _timeline.After(at + step, () => AddMeasure(area.Left, area.Top, area.Left, area.Bottom, length));
                at += step * 2;
            }

            for (int i = 0; i + 1 < shapes.Count; i++)
            {
                PointF from = Center(shapes[i]);
                PointF to = Center(shapes[i + 1]);
                int gap = order++;
                _timeline.After(at, () => AddMeasure(from.X, from.Y, to.X, to.Y, gap));
                at += step;
            }
        }

        // ⑥ 도면 점 → 3D — 도면 위 경로의 점을 차례로 3D 좌표로 바꿔, 그 자리에 표식을 세우고 카메라를 보냅니다.
        private void ScenePointTour()
        {
            if (_blockDrawing == null) return;
            _viewer.ClearOverlays();
            _viewer.ClearMeasures();
            _viewer.FitToView();
            ClearAreas3D();
            vizcore3dx.View.Effect.ClearDimensionLines(SceneValues.EffectGroup);
            TurnToDrawing(_blockDrawing, _blockBox, 1.5);

            List<Data.Vector2> route = TourRoute();
            _viewer.AddOverlayPolyline(_blockDrawing, route, SceneValues.TourColor, 3f);
            for (int i = 0; i < route.Count; i++)
                _viewer.AddOverlayPoint(_blockDrawing, route[i], SceneValues.TourColor, 10f, SceneValues.TourLabels[i]);
            _tourMarker = _viewer.AddOverlayMarker(_blockDrawing, route[0], 0f, SceneValues.CameraMarkerColor, SceneValues.MarkerSizePx);

            for (int i = 0; i < route.Count; i++)
            {
                int index = i;
                _timeline.After(2.0 + i * SceneValues.TourSecondsPerPoint, () => VisitTourPoint(route, index));
            }
        }

        // ⑦ 확대 — 마지막 경로 점 주변을 도면에서 확대하고 격자를 켭니다. 다음 장면에서 전체로 돌아옵니다.
        private void SceneZoomDetail()
        {
            if (_blockDrawing == null) return;

            RectangleF bounds = LocalBounds(_blockDrawing, _blockBox);
            List<Data.Vector2> route = TourRoute();
            Data.Vector2 center = route[route.Count - 1];
            float half = Math.Max(bounds.Width, bounds.Height) * SceneValues.ZoomWindow;

            _viewer.IsGridVisible = true;
            _viewer.ZoomToBounds(_blockDrawing, new Data.Vector2(center.X - half, center.Y - half), new Data.Vector2(center.X + half, center.Y + half));
        }

        // ⑧ 내보내기 — 블록 도면을 DXF 와 SVG 파일로 저장합니다(실행 파일 폴더).
        private void SceneExport()
        {
            if (_blockDrawing == null) return;
            _viewer.IsGridVisible = false;
            _viewer.FitToView();

            string dxf = Path.Combine(Application.StartupPath, "Scenario.LiveDrawing.dxf");
            string svg = Path.Combine(Application.StartupPath, "Scenario.LiveDrawing.svg");
            bool saved = vizcore3dx.Projection.ExportDxf(_blockDrawing, dxf) && vizcore3dx.Projection.ExportSvg(_blockDrawing, svg);

            LookLikeDrawing(_blockDrawing, _blockBox, 1.0);
            SetStatus(saved ? "내보내기 : " + dxf : "내보내기 실패 : " + vizcore3dx.Projection.LastOperationResult);
        }

        #endregion

        #region 장면 도우미

        // 장면 대상을 정합니다. 모델 전체 = 모든 파트, 블록 = 설정 그룹에서 이름으로 찾은 어셈블리의 파트.
        private void PrepareTargets()
        {
            _modelParts = vizcore3dx.Object3D.FromFilter(Data.Object3dFilter.PART);
            _modelBox = vizcore3dx.Object3D.GetBoundBox(vizcore3dx.Object3D.GetRootNodes());

            _blockParts = vizcore3dx.Object3D.GetChildObject3d(_block.EntityID, _block.Index, Data.NodeFilterKind.PART);
            if (_blockParts == null || _blockParts.Count == 0) _blockParts = new List<Data.Node> { _block };
            _blockBox = vizcore3dx.Object3D.GetBoundBox(_blockParts);
        }

        // 설정 그룹의 "블록 이름"으로 어셈블리를 찾아 둡니다. 이름이 비었거나 찾지 못하면 장면을 시작하지 않습니다.
        private bool IsBlockReady()
        {
            string name = txtBlockName.Text.Trim();
            if (name.Length == 0)
            {
                SetStatus("블록 이름을 입력해 주세요.");
                txtBlockName.Focus();
                return false;
            }

            List<Data.Node> found = vizcore3dx.Object3D.Find.QuickSearch(name, true, false, false, false);
            if (found == null || found.Count == 0)
            {
                SetStatus("블록을 찾을 수 없습니다 : " + name);
                txtBlockName.Focus();
                return false;
            }

            _block = found[0];
            return true;
        }

        // 내장 투영 결과 창을 테두리 없이 오른쪽 칸에 넣고, 그 안의 뷰어를 받아 둡니다. (내장 창이라 리본 테마를 그대로 따릅니다)
        // 이전 창이 있으면 닫고 빈 도면으로 새로 띄웁니다.
        private void OpenDrawingWindow()
        {
            if (_drawingWindow != null) _drawingWindow.Close();

            _drawingWindow = new VIZCore3DX.NET.Dialogs.ProjectionResultDialog(new List<Data.ProjectionItem>(), vizcore3dx);
            _drawingWindow.TopMost = false;
            _drawingWindow.TopLevel = false;
            _drawingWindow.FormBorderStyle = FormBorderStyle.None;
            _drawingWindow.Dock = DockStyle.Fill;

            splitContainer2.Panel2.Controls.Add(_drawingWindow);
            _drawingWindow.Show();
            _viewer = _drawingWindow.Viewer;
        }

        // 단면 도면에 같은 평면의 외곽선을 겹쳐 보여 줍니다. 단면만으로는 대상의 윤곽이 드러나지 않기 때문입니다.
        private void ShowWithOutline(Data.ProjectionItem section, List<Data.Node> parts, Data.Vector3D position)
        {
            Data.ProjectionItem outline = vizcore3dx.Projection.CreateOutline(
                parts, SceneValues.PlaneNormal, position, SceneValues.DrawingAccent, SceneValues.DrawingThickness, true, false);
            if (outline == null)
            {
                _viewer.SetResult(section);
                return;
            }

            // 외곽선은 도면에만 쓰고 3D 뷰에는 그리지 않습니다.
            outline.IsVisible = false;
            _viewer.SetResults(new List<Data.ProjectionItem> { section, outline });
            _viewer.SetResultColor(section, SceneValues.DrawingColor);
            _viewer.SetResultColor(outline, SceneValues.DrawingAccent);
        }

        // 3D 뷰에 블록만 남기고 나머지를 숨깁니다.
        private void IsolateBlock()
        {
            vizcore3dx.View.XRay.Enable = false;
            vizcore3dx.Object3D.ShowSelection(_blockParts);
        }

        // 3D 모델을 도면과 같은 평면으로 실제로 자릅니다.
        private void CutModel(Data.Vector3D position)
        {
            if (_section == null) _section = vizcore3dx.Section.Add(false, SceneValues.SectionAxis);
            if (_section == null) return;

            vizcore3dx.Section.SetSectionPosition(_section.ID, position);
            _section.Enable(true);

            // 남길 쪽 뒤집기는 단면을 켠 다음, 그 단면만 선택한 상태에서 해야 적용됩니다.
            if (SceneValues.SectionInvert)
            {
                vizcore3dx.Section.Deselect();
                vizcore3dx.Section.Select(_section);
                vizcore3dx.Section.InvertDirection();
            }
            vizcore3dx.Section.Deselect();

            // 단면 평면 표시는 숨깁니다. 자르는 효과는 그대로 남습니다.
            _section.Show(false);
        }

        // 도면을 만들고 걸린 시간을 상태줄에 적습니다.
        private Data.ProjectionItem CreateTimed(string title, Func<Data.ProjectionItem> create)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Data.ProjectionItem item = create();
            watch.Stop();

            if (item == null)
            {
                SetStatus("도면 생성 실패 : " + vizcore3dx.Projection.LastOperationResult);
                return null;
            }

            SetStatus(string.Format("{0} : {1:0.00} 초", title, watch.Elapsed.TotalSeconds));
            return item;
        }

        // 닫힌 영역 하나를 도면 위에 색칠하고 가운데에 면적을 적은 뒤, 3D 에도 같은 영역을 그립니다.
        private void AddClosedArea(Data.ProjectionEmptyRegion region, int order)
        {
            // 윤곽은 바깥 고리가 먼저 순서대로 들어 있습니다. 고리가 첫 점으로 돌아오는 데까지만 씁니다(안쪽 구멍은 뺌).
            List<Data.Vector2> outline = new List<Data.Vector2>();
            for (int i = 0; i < region.OutlineStart.Count; i++)
            {
                outline.Add(new Data.Vector2(region.OutlineStart[i].X, region.OutlineStart[i].Y));
                if (region.OutlineEnd[i] == region.OutlineStart[0]) break;
            }
            if (outline.Count < 3) return;

            Color fill = SceneValues.AreaColors[order % SceneValues.AreaColors.Length];
            _viewer.AddOverlayPolygon(_blockDrawing, outline, fill, Color.FromArgb(255, fill));

            Data.Vector2 center = new Data.Vector2(region.Bounds.X + region.Bounds.Width / 2f, region.Bounds.Y + region.Bounds.Height / 2f);
            string area = (region.Area * SceneValues.AreaToSquareMeter).ToString("0.00") + " m²";
            _viewer.AddOverlayText(_blockDrawing, center, area, Color.Black, 13f);

            AddClosedArea3D(outline, center, fill, area);
        }

        // 같은 영역을 3D 뷰에도 그립니다. 도면 좌표를 3D 좌표로 바꿔, 도면 평면 바로 아래에 반투명 면·윤곽선·면적 글자로 얹습니다.
        private void AddClosedArea3D(List<Data.Vector2> outline, Data.Vector2 center, Color fill, string area)
        {
            float top = DrawingPlane().Z - SceneValues.AreaLift;

            List<Data.Vertex3D> vertices = new List<Data.Vertex3D>();
            List<Data.Vector3D> border = new List<Data.Vector3D>();
            foreach (Data.Vector2 point in outline)
            {
                Data.Vector3D world = _blockDrawing.LocalToWorld(point);
                vertices.Add(new Data.Vertex3D(world.X, world.Y, top));
                border.Add(new Data.Vector3D(world.X, world.Y, top));
            }
            border.Add(border[0]);

            // 색의 알파 값이 그대로 반투명도가 됩니다.
            KeepShape(vizcore3dx.Shape.CreateMeshShape(vertices, Triangulate(outline), fill));
            KeepShape(vizcore3dx.Shape.CreatePolylineShape(border, 2f, Data.StrokePattern.Solid, Color.FromArgb(255, fill)));

            Data.Vector3D label = _blockDrawing.LocalToWorld(center);
            Data.TextLabelOptions options = new Data.TextLabelOptions();
            options.Group = SceneValues.EffectGroup;
            vizcore3dx.View.Effect.AddTextLabel(new Data.Vector3D(label.X, label.Y, top), area, options);
        }

        private void KeepShape(Data.ShapeItem shape)
        {
            if (shape != null) _shapes.Add(shape);
        }

        // 3D 뷰에 그린 영역(면·윤곽선·면적 글자)을 지웁니다.
        private void ClearAreas3D()
        {
            if (_shapes.Count > 0) vizcore3dx.Shape.Delete(_shapes);
            _shapes.Clear();
            vizcore3dx.View.Effect.ClearTextLabels(SceneValues.EffectGroup);
        }

        // 다각형(도면 좌표)을 삼각형으로 나눕니다. 볼록한 꼭짓점 중 안에 다른 점이 없는 것("귀")을 하나씩 잘라 냅니다.
        // 어느 쪽에서 봐도 보이도록 삼각형마다 앞뒤 두 방향을 모두 넣습니다.
        private static List<int> Triangulate(List<Data.Vector2> points)
        {
            List<int> indices = new List<int>();
            List<int> rest = new List<int>();
            double area = 0.0;
            for (int i = 0; i < points.Count; i++)
            {
                rest.Add(i);
                area += Cross(points[0], points[i], points[(i + 1) % points.Count]);
            }
            double sign = area >= 0.0 ? 1.0 : -1.0;

            int ear = 0;
            while (rest.Count >= 3 && ear >= 0)
            {
                ear = FindEar(points, rest, sign);
                if (ear < 0) break;

                int a = rest[(ear + rest.Count - 1) % rest.Count], b = rest[ear], c = rest[(ear + 1) % rest.Count];
                indices.AddRange(new[] { a, b, c, a, c, b });
                rest.RemoveAt(ear);
            }
            return indices;
        }

        // 잘라 낼 수 있는 꼭짓점의 위치를 찾습니다. 없으면 -1.
        private static int FindEar(List<Data.Vector2> points, List<int> rest, double sign)
        {
            for (int i = 0; i < rest.Count; i++)
            {
                Data.Vector2 a = points[rest[(i + rest.Count - 1) % rest.Count]];
                Data.Vector2 b = points[rest[i]];
                Data.Vector2 c = points[rest[(i + 1) % rest.Count]];
                if (Cross(a, b, c) * sign <= 0.0) continue;

                bool blocked = false;
                foreach (int index in rest)
                {
                    Data.Vector2 p = points[index];
                    if (ReferenceEquals(p, a) || ReferenceEquals(p, b) || ReferenceEquals(p, c)) continue;
                    if (Cross(a, b, p) * sign >= 0.0 && Cross(b, c, p) * sign >= 0.0 && Cross(c, a, p) * sign >= 0.0) { blocked = true; break; }
                }
                if (blocked == false) return i;
            }
            return -1;
        }

        // 세 점이 도는 방향 (양수 = 반시계, 도면 좌표 기준)
        private static double Cross(Data.Vector2 a, Data.Vector2 b, Data.Vector2 c)
        {
            return ((double)b.X - a.X) * ((double)c.Y - a.Y) - ((double)b.Y - a.Y) * ((double)c.X - a.X);
        }

        // 도면의 두 점 사이를 뷰어의 측정으로 재고, 같은 두 점을 3D 좌표로 바꿔 3D 치수선도 그립니다.
        // 거리 글자는 측정 순번마다 선 위의 자리를 달리해 가까운 측정끼리 겹치지 않게 합니다.
        private void AddMeasure(float x1, float y1, float x2, float y2, int order)
        {
            float label = SceneValues.MeasureLabelPositions[order % SceneValues.MeasureLabelPositions.Length];
            Data.Vector2 start = new Data.Vector2(x1, y1);
            Data.Vector2 end = new Data.Vector2(x2, y2);
            _viewer.AddMeasure(_blockDrawing, start, end, label);

            Data.DimensionLineOptions options = new Data.DimensionLineOptions();
            options.Group = SceneValues.EffectGroup;
            options.TextPosition = label;
            options.Decimals = 2;   // 2D 측정과 같은 자릿수로 적습니다 (기본은 정수로 반올림)
            vizcore3dx.View.Effect.AddDimensionLine(_blockDrawing.LocalToWorld(start), _blockDrawing.LocalToWorld(end), options);
        }

        private static PointF Center(RectangleF area)
        {
            return new PointF(area.Left + area.Width / 2f, area.Top + area.Height / 2f);
        }

        // 값 표의 비율 값을 블록 도면 위의 좌표로 바꿉니다.
        private List<Data.Vector2> TourRoute()
        {
            RectangleF bounds = LocalBounds(_blockDrawing, _blockBox);
            List<Data.Vector2> route = new List<Data.Vector2>();
            foreach (PointF ratio in SceneValues.TourPoints)
                route.Add(new Data.Vector2(bounds.Left + bounds.Width * ratio.X, bounds.Top + bounds.Height * ratio.Y));
            return route;
        }

        // 도면 위 경로 점 하나를 방문합니다. 표식을 옮기고, 같은 점의 3D 위치에 표식을 세운 뒤 카메라를 보냅니다.
        private void VisitTourPoint(List<Data.Vector2> route, int index)
        {
            Data.Vector2 point = route[index];
            Data.Vector2 next = route[Math.Min(index + 1, route.Count - 1)];
            float heading = (float)(Math.Atan2(next.Y - point.Y, next.X - point.X) * 180.0 / Math.PI);
            _viewer.SetOverlayPosition(_tourMarker, point, heading);

            // 도면 좌표 → 3D 좌표
            Data.Vector3D world = _blockDrawing.LocalToWorld(point);
            if (world == null) return;

            Data.MarkerOptions options = new Data.MarkerOptions();
            options.Group = SceneValues.EffectGroup;
            options.Label = SceneValues.TourLabels[index];
            vizcore3dx.View.Effect.AddMarker(world, Data.MarkerIcon.Information, options);

            // 도면과 같은 방향(위)을 유지한 채 그 지점 둘레만 화면에 채웁니다.
            float reach = _blockBox.MaxLength * SceneValues.TourZoom * 0.5f;
            vizcore3dx.View.FlyToBoundingBox(world - reach, world + reach, 1.0f, TimeSpan.FromSeconds(SceneValues.TourSecondsPerPoint * 0.6));
        }

        // 3D 경계 상자의 여덟 꼭짓점을 도면 좌표로 옮겨 도면 위 범위를 구합니다.
        private RectangleF LocalBounds(Data.ProjectionItem item, Data.BoundBox3D box)
        {
            float minX = float.MaxValue, minY = float.MaxValue, maxX = float.MinValue, maxY = float.MinValue;
            for (int i = 0; i < 8; i++)
            {
                Data.Vector3D corner = new Data.Vector3D(
                    (i & 1) == 0 ? box.MinX : box.MaxX, (i & 2) == 0 ? box.MinY : box.MaxY, (i & 4) == 0 ? box.MinZ : box.MaxZ);
                Data.Vector2 local = item.WorldToLocal(corner);
                if ((object)local == null) continue;

                minX = Math.Min(minX, local.X);
                minY = Math.Min(minY, local.Y);
                maxX = Math.Max(maxX, local.X);
                maxY = Math.Max(maxY, local.Y);
            }
            return RectangleF.FromLTRB(minX, minY, maxX, maxY);
        }

        // 상자 안의 한 점 — 가로·세로는 비율(0~1), 높이도 비율
        private Data.Vector3D PointInBox(Data.BoundBox3D box, PointF ratio, float height)
        {
            return new Data.Vector3D(box.MinX + box.LengthX * ratio.X, box.MinY + box.LengthY * ratio.Y, box.MinZ + box.LengthZ * height);
        }

        // 블록 도면을 만드는 평면의 위치 — 블록 꼭대기 위에 띄웁니다. 3D 에서 도면 선·치수선·영역이 장비 위에 떠 보입니다.
        private Data.Vector3D DrawingPlane()
        {
            return new Data.Vector3D(_blockBox.CenterX, _blockBox.CenterY, _blockBox.MaxZ + _blockBox.LengthZ * SceneValues.DrawingLift);
        }

        #endregion

        #region 카메라

        // 3D 뷰를 도면과 똑같이 보이게 합니다. 평행 투영으로 바꾸고 도면의 오른쪽·위쪽이 화면의 오른쪽·위쪽이 되게 돌린 다음,
        // box 가 화면에 들어오도록 맞춥니다. (평행 투영에서는 거리가 아니라 맞춤으로 크기를 정합니다)
        private void LookLikeDrawing(Data.ProjectionItem item, Data.BoundBox3D box, double seconds)
        {
            Data.Vector3D up = TurnToDrawing(item, box, seconds);

            // 화면 위쪽으로 상자를 조금 늘려 맞춰, 대상이 리본 바로 아래에 붙지 않게 합니다.
            Data.Vector3D min = new Data.Vector3D(box.GetVertexMin());
            Data.Vector3D max = new Data.Vector3D(box.GetVertexMax());
            Data.Vector3D room = up * (box.MaxLength * SceneValues.TopRoom);
            Data.Vector3D low = new Data.Vector3D(Math.Min(min.X, min.X + room.X), Math.Min(min.Y, min.Y + room.Y), Math.Min(min.Z, min.Z + room.Z));
            Data.Vector3D high = new Data.Vector3D(Math.Max(max.X, max.X + room.X), Math.Max(max.Y, max.Y + room.Y), Math.Max(max.Z, max.Z + room.Z));
            _timeline.After(seconds + 0.1, () => vizcore3dx.View.FlyToBoundingBox(low, high, 1.0f, TimeSpan.FromSeconds(1.0)));
        }

        // 평행 투영으로 바꾸고, 도면의 오른쪽·위쪽이 화면의 오른쪽·위쪽이 되게 카메라를 돌립니다. 화면 위쪽 방향을 돌려줍니다.
        private Data.Vector3D TurnToDrawing(Data.ProjectionItem item, Data.BoundBox3D box, double seconds)
        {
            vizcore3dx.View.Projection = Data.Projections.Orthographic;

            Data.Vector3D view, up;
            DrawingAxes(item, out view, out up);
            FlyCamera(new Data.Vector3D(box.GetCenter()), view, FitDistance(box.MaxLength), seconds, up);
            return up;
        }

        // 원근 투영으로 바꾸고 카메라를 비스듬히 기울여 블록 도면이 블록 위 허공에 떠 있는 모습을 보인 뒤,
        // 잠시 머물렀다가 천천히 위에서 내려다보는 방향(도면과 같은 화면)으로 돌아옵니다.
        private void TiltToFloatingDrawing(double seconds)
        {
            vizcore3dx.View.Projection = Data.Projections.Perspective;
            Data.Vector3D between = new Data.Vector3D(_blockBox.CenterX, _blockBox.CenterY, (_blockBox.CenterZ + DrawingPlane().Z) * 0.5f);

            // 바라보는 지점을 화면 오른쪽으로 옮기면 블록이 화면 왼쪽으로 옵니다(오른쪽 도구 모음에 가리지 않게).
            Data.Vector3D right = Data.Vector3D.Cross(SceneValues.ViewFloating, new Data.Vector3D(0f, 0f, 1f)).GetNormalized();
            Data.Vector3D target = between + right * (_blockBox.MaxLength * SceneValues.FloatingShift);
            FlyCamera(target, SceneValues.ViewFloating, FitDistance(_blockBox.MaxLength) * SceneValues.FloatingZoom, seconds);

            _timeline.After(SceneValues.FloatingHoldSeconds, () => ReturnToDrawing(SceneValues.FloatingReturnSeconds));
        }

        // 기울였던 카메라를 seconds 초 동안 천천히 도면과 같은 방향으로 되돌리고, 다 돌아오면 평행 투영으로 맞춥니다.
        private void ReturnToDrawing(double seconds)
        {
            Data.Vector3D view, up;
            DrawingAxes(_blockDrawing, out view, out up);
            FlyCamera(new Data.Vector3D(_blockBox.GetCenter()), view, FitDistance(_blockBox.MaxLength), seconds, up);
            _timeline.After(seconds + 0.2, () => LookLikeDrawing(_blockDrawing, _blockBox, 0.5));
        }

        // 도면을 정면으로 보는 3D 시선과 위 방향을 구합니다.
        private void DrawingAxes(Data.ProjectionItem item, out Data.Vector3D view, out Data.Vector3D up)
        {
            // 도면 좌표의 두 축이 3D 에서 어느 방향인지 읽습니다. 뷰어는 도면의 +Y 를 화면 아래로 그리므로 화면 위쪽은 -Y 입니다.
            Data.Vector3D origin = item.LocalToWorld(new Data.Vector2(0f, 0f));
            Data.Vector3D right = (item.LocalToWorld(new Data.Vector2(1000f, 0f)) - origin).GetNormalized();
            up = (origin - item.LocalToWorld(new Data.Vector2(0f, 1000f))).GetNormalized();

            // 시선 = 위 × 오른쪽. 위 방향은 시선에 직교하는 이 값을 그대로 카메라에 넘깁니다.
            view = up.Cross(right);
        }

        // 크기 size 인 대상이 화면에 다 들어오는 카메라 거리를 시야각에서 구합니다.
        private float FitDistance(float size)
        {
            double fov = vizcore3dx.View.FOV;
            if (fov < 1.0 || fov > 120.0) fov = 30.0;

            return (float)(size * 0.5 / Math.Tan(fov * Math.PI / 360.0) * SceneValues.FitMargin);
        }

        // target 을 direction 방향으로 distance 만큼 떨어져 바라보도록 seconds 초 동안 이동합니다.
        // up 을 주지 않으면 Z 를 위로 삼습니다. 이때 direction 이 정확히 수직이면 안 됩니다.
        private void FlyCamera(Data.Vector3D target, Data.Vector3D direction, float distance, double seconds, Data.Vector3D up = null)
        {
            Data.CameraData camera = vizcore3dx.View.GetCameraData();
            if (camera == null) return;

            // 시선 방향 값의 부호는 지금 카메라가 쓰는 규칙을 그대로 따릅니다.
            Data.Vector3D current = new Data.Vector3D(camera.PivotPosition) - new Data.Vector3D(camera.EyePosition);
            float sign = current.Dot(new Data.Vector3D(camera.CameraDirection)) < 0f ? -1f : 1f;

            Data.Vector3D view = direction.GetNormalized();
            camera.PivotPosition = target.ToVertex3D();
            camera.EyePosition = (target - view * distance).ToVertex3D();
            camera.CameraDirection = (view * sign).ToVertex3D();

            // 위 방향은 시선에 직교해야 합니다. SetCameraData 가 시선에 맞게 다시 보정합니다.
            camera.UpDirection = (up ?? new Data.Vector3D(0f, 0f, 1f)).ToVertex3D();
            vizcore3dx.View.SetCameraData(camera, TimeSpan.FromSeconds(seconds));
        }

        #endregion

        #region Helpers

        // 모델이 열려 있는지 확인하고, 아니면 상태줄에 알립니다.
        private bool IsModelOpened()
        {
            if (vizcore3dx.Model.IsOpen()) return true;

            SetStatus("모델을 먼저 열어 주세요.");
            return false;
        }

        private void SetStatus(string text)
        {
            lblStatus.Text = text;
        }

        // 지정한 탭만 남기고 나머지 툴바(=리본 탭)와 모델 트리 패널의 같은 탭을 숨깁니다. 홈 탭·모델 트리는 항상 표시합니다.
        private void ShowRibbonTabs(params VIZCore3DX.NET.Data.ToolbarKind[] keep)
        {
            foreach (VIZCore3DX.NET.Data.ToolbarKind kind in Enum.GetValues(typeof(VIZCore3DX.NET.Data.ToolbarKind)))
                vizcore3dx.Toolbar.SetVisible(kind, kind == VIZCore3DX.NET.Data.ToolbarKind.Main || Array.IndexOf(keep, kind) >= 0);

            // 남길 탭은 먼저 켜고(설정 파일로 꺼져 있을 수 있음), 그 다음 모델 트리를 뺀 나머지를 끕니다. 내장 탭 이름은 "tabPage" + 툴바 종류입니다.
            foreach (VIZCore3DX.NET.Data.ToolbarKind kind in keep)
                vizcore3dx.Panel.SetTabVisible(VIZCore3DX.NET.Data.PanelKind.ModelTree, "tabPage" + kind, true);

            foreach (string name in vizcore3dx.Panel.GetTabNames(VIZCore3DX.NET.Data.PanelKind.ModelTree))
            {
                if (name == "tabPageSceneTree") continue;
                bool show = Array.Exists(keep, kind => name == "tabPage" + kind);
                vizcore3dx.Panel.SetTabVisible(VIZCore3DX.NET.Data.PanelKind.ModelTree, name, show);
            }
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
