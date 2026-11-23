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
    // 장면 하나 = 메서드 하나(#region 장면), 장면의 설명·길이와 장면에 쓰는 값은 ScenarioScript.cs 한 곳에, 재생은 ScenarioRunner.cs 에 있습니다.
    //
    // ── 이 예제에서 SDK 사용을 보려면 ──
    // · 단면 도면과 3D 단면(Section.InvertDirection(id)): SceneSection(), CutModel()
    // · 도면 좌표 ↔ 3D 좌표(WorldToLocal·LocalToWorld): Runner_Tick(), VisitTourPoint()
    // · 은선 제거 정사영 도면: SceneBlockDrawing()
    // · 닫힌 영역 면적과 치수: SceneClosedAreas(), AddClosedArea(), AddMeasure()
    // · DXF·SVG 내보내기: SceneExport()
    // · 카메라 도착 뒤 이어서 하기: WhenCameraArrives() (View.OnCameraMoveCompletedEvent)
    // 장면 재생·리본(ScenarioRunner.cs, ScenarioRibbon.cs)과 카메라·화면 연출(FrmMain.Demo.cs)은 SDK 사용과 무관하니 건너뛰어도 됩니다.
    // 다른 모델에 쓰려면: 그대로 동작합니다(mm 단위 가정). 블록 장면은 리본 [블록]에 그 모델의 어셈블리 이름을 넣습니다.
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 2D 도면 — 내장 투영 결과 창을 오른쪽 칸에 넣고, 그 안의 뷰어(Viewer)를 받아 오버레이·측정 API 를 씁니다.
        private VIZCore3DX.NET.Dialogs.ProjectionResultDialog _drawingWindow;
        private VIZCore3DX.NET.Controls.ProjectionViewerControl _viewer;

        // 조작부 — 리본 사용자 탭 "시나리오" (뷰어 초기화 뒤에 만듭니다)
        private ScenarioRibbon _ribbon;

        // 블록 이름 — 리본 [블록] 버튼으로 입력합니다.
        private string _blockName;
        private VIZCore3DX.NET.Controls.Ribbon.RibbonButton _blockButton;

        // 대본과 재생기
        private List<ScenarioShot> _shots;
        private ScenarioRunner _runner;

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

        // 카메라가 도착하면 할 일 — View.OnCameraMoveCompletedEvent 가 한 번 실행하고 비웁니다. 장면이 바뀌거나 처음으로 가면 버립니다.
        private Action _onCameraArrived;

        public FrmMain()
        {
            InitializeComponent();

            // 대본 목록은 뷰어와 무관하므로 생성자에서 채웁니다.
            _shots = BuildShots();

            _runner = new ScenarioRunner(_shots);
            _runner.ShotStarted += Runner_ShotStarted;
            _runner.Tick += Runner_Tick;

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction — 왼쪽 칸은 3D 뷰, 오른쪽 칸은 2D 도면
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
            // 리본 UI 를 기본으로 켜고, 사용자 탭 "시나리오"만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();
            InitializeRibbon();
            vizcore3dx.View.OnCameraMoveCompletedEvent += View_OnCameraMoveCompletedEvent;

            OpenDrawingWindow();
            SetStatus("모델을 열어 주세요.");
        }

        // 리본에 사용자 탭 "시나리오"를 만들고, 버튼을 이 폼의 핸들러에 잇습니다.
        private void InitializeRibbon()
        {
            List<string> names = new List<string>();
            for (int i = 0; i < _shots.Count; i++) names.Add(_shots[i].Name);

            _ribbon = new ScenarioRibbon(vizcore3dx, ScenarioScript.SceneLabels, names);
            _ribbon.OpenModel += Ribbon_OpenModel;
            _ribbon.PlayAll += Ribbon_PlayAll;
            _ribbon.Reset += Ribbon_Reset;
            _ribbon.GoScene += Ribbon_GoScene;
            _ribbon.Build();

            // 블록 이름 — 리본에는 글자 입력 칸이 없어, [재생] 그룹 끝에 버튼을 두고 누르면 입력 창을 띄웁니다.
            _blockButton = vizcore3dx.Ribbon.AddButton("scenario.control", "scenario.block", "블록", null,
                VIZCore3DX.NET.Controls.Ribbon.RibbonItemSize.Large, (sender, e) => Ribbon_Block());
            if (_blockButton != null)
            {
                _blockButton.Icon = DrawBlockIcon;
                _blockButton.ToolTipText = "블록 : (없음)";
            }
        }

        // 대본 표의 장면에 장면 메서드를 잇습니다. 이 순서가 재생 순서입니다.
        private List<ScenarioShot> BuildShots()
        {
            ScenarioScript.Section.Play = SceneSection;
            ScenarioScript.LiveMap.Play = SceneLiveMap;
            ScenarioScript.BlockDrawing.Play = SceneBlockDrawing;
            ScenarioScript.ClosedAreas.Play = SceneClosedAreas;
            ScenarioScript.Measure.Play = SceneMeasure;
            ScenarioScript.PointTour.Play = ScenePointTour;
            ScenarioScript.ZoomDetail.Play = SceneZoomDetail;
            ScenarioScript.Export.Play = SceneExport;

            // 번호 버튼으로 바로 볼 때 먼저 실행할 장면 — 02 는 전체 단면 도면(01), 04~08 은 블록 도면(03), 05 는 닫힌 영역(04)을 씁니다.
            ScenarioScript.LiveMap.Before = new[] { 1 };
            ScenarioScript.ClosedAreas.Before = new[] { 3 };
            ScenarioScript.Measure.Before = new[] { 3, 4 };
            ScenarioScript.PointTour.Before = new[] { 3 };
            ScenarioScript.ZoomDetail.Before = new[] { 3 };
            ScenarioScript.Export.Before = new[] { 3 };

            return new List<ScenarioShot>
            {
                ScenarioScript.Section, ScenarioScript.LiveMap, ScenarioScript.BlockDrawing, ScenarioScript.ClosedAreas,
                ScenarioScript.Measure, ScenarioScript.PointTour, ScenarioScript.ZoomDetail, ScenarioScript.Export,
            };
        }

        // 창을 닫을 때 재생 타이머부터 멈춥니다.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _runner.Reset();
            vizcore3dx.View.OnCameraMoveCompletedEvent -= View_OnCameraMoveCompletedEvent;
            base.OnFormClosing(e);
        }

        #endregion

        #region 1. 모델

        // 모델을 엽니다. 장면은 열린 모델의 범위를 기준으로 진행되므로 어떤 모델이든 쓸 수 있습니다.
        private void Ribbon_OpenModel()
        {
            if (_runner.IsPlaying) return;
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            ClearScene();
            SetStatus("모델을 열었습니다. [블록]에 블록 이름을 넣고 재생하세요.");
        }

        #endregion

        #region 2. 설정

        // 블록 도면 장면부터 쓸 어셈블리 이름을 입력받습니다. 바뀌면 처음 상태로 되돌려 다음 재생이 새 블록으로 시작하게 합니다.
        private void Ribbon_Block()
        {
            if (_runner.IsPlaying) return;

            string name = AskText("블록", "블록 도면 장면부터 쓸 어셈블리 이름 (모델 트리의 이름과 똑같이)", _blockName ?? "");
            if (name == null || name.Trim() == (_blockName ?? "").Trim()) return;

            _blockName = name.Trim();
            if (_blockButton != null) _blockButton.ToolTipText = "블록 : " + _blockName;
            ClearScene();
            SetStatus("블록 : " + _blockName);
        }

        #endregion

        #region 3. 장면

        // 첫 장면부터 끝까지 이어서 재생합니다.
        private void Ribbon_PlayAll()
        {
            if (!IsModelOpened() || !IsBlockReady()) return;

            ClearScene();
            PrepareTargets();
            _runner.PlayAll();
        }

        // 번호 버튼 — 그 장면을 재생합니다. 바로 앞 장면에 이어 누른 것이 아니면 처음 상태로 되돌리고 선행 장면을 실행한 뒤 재생합니다.
        private void Ribbon_GoScene(int first, int last)
        {
            if (!IsModelOpened() || !IsBlockReady()) return;

            if (_runner.IsReadyFor(first))
            {
                _runner.PlayFrom(first, last);
                return;
            }

            ClearScene();
            PrepareTargets();
            _runner.Prepare(first, () => _runner.PlayFrom(first, last));
        }

        private void Runner_ShotStarted(ScenarioShot shot)
        {
            _onCameraArrived = null;
            _ribbon.SetCurrent(_runner.Index);
            SetStatus(shot.Name + " — " + shot.Caption);
        }

        // 재생 중 주기적으로 3D 카메라의 위치를 도면 좌표로 바꿔 도면 위 표식을 옮깁니다. 마우스로 카메라를 돌려도 따라옵니다.
        private void Runner_Tick()
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
        private void Ribbon_Reset()
        {
            ClearScene();
            if (vizcore3dx.Model.IsOpen())
            {
                vizcore3dx.View.Projection = Data.Projections.Perspective;
                vizcore3dx.View.FitToView();
            }
            SetStatus("처음으로 되돌렸습니다.");
        }

        // 재생을 멈추고 처음으로 되돌린 뒤, 장면이 만든 도면·표식·3D 표시를 전부 지웁니다.
        private void ClearScene()
        {
            _runner.Reset();
            _onCameraArrived = null;
            if (_ribbon != null) _ribbon.SetCurrent(0);

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
                vizcore3dx.View.Effect.ClearDimensionLines(ScenarioScript.EffectGroup);
                vizcore3dx.View.Effect.ClearMarkers(ScenarioScript.EffectGroup);
                vizcore3dx.View.Effect.ClearPulseOutlines(ScenarioScript.EffectGroup);
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
            Data.Vector3D position = PointInBox(_modelBox, new PointF(0.5f, 0.5f), ScenarioScript.SectionHeight);
            _sectionDrawing = CreateTimed("전체 단면", () => vizcore3dx.Projection.CreateCrossSection(
                _modelParts, ScenarioScript.PlaneNormal, position, ScenarioScript.DrawingColor, ScenarioScript.DrawingThickness, true));
            if (_sectionDrawing == null) return;

            ShowWithOutline(_sectionDrawing, _modelParts, position);
            CutModel(position);
            LookLikeDrawing(_sectionDrawing, _modelBox, 2.0);
        }

        // ② 살아 있는 도면 — 3D 카메라의 위치·시선을 도면 위 표식으로 실시간 표시합니다(Runner_Tick).
        //    카메라가 모델 위 몇 곳을 차례로 날아다니고, 끝난 뒤 마우스로 돌려도 표식이 따라옵니다.
        private void SceneLiveMap()
        {
            if (_sectionDrawing == null) return;

            Data.Vector2 origin = _sectionDrawing.WorldToLocal(new Data.Vector3D(_modelBox.GetCenter()));
            _targetPoint = _viewer.AddOverlayPoint(_sectionDrawing, origin, ScenarioScript.TargetPointColor, 10f, "시선");
            _cameraMarker = _viewer.AddOverlayMarker(_sectionDrawing, origin, 0f, ScenarioScript.CameraMarkerColor, ScenarioScript.MarkerSizePx, "카메라");

            vizcore3dx.View.Projection = Data.Projections.Perspective;

            // 카메라는 모델 밖에서 바라보므로, 카메라 표식이 도면 밖으로 나가지 않게 도면을 카메라 거리만큼 넓혀 봅니다.
            float distance = _modelBox.MaxLength * ScenarioScript.LiveMapDistance;
            RectangleF bounds = LocalBounds(_sectionDrawing, _modelBox);
            float margin = distance * ScenarioScript.LiveMapMargin;
            _viewer.ZoomToBounds(_sectionDrawing,
                new Data.Vector2(bounds.Left - margin, bounds.Top - margin), new Data.Vector2(bounds.Right + margin, bounds.Bottom + margin));

            for (int i = 0; i < ScenarioScript.LiveMapTargets.Length; i++)
            {
                Data.Vector3D target = PointInBox(_modelBox, ScenarioScript.LiveMapTargets[i], ScenarioScript.SectionHeight);
                Data.Vector3D view = ScenarioScript.LiveMapViews[i];
                _runner.After(i * ScenarioScript.LiveMapSecondsPerView,
                    () => FlyCamera(target, view, distance, ScenarioScript.LiveMapSecondsPerView));
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
                _blockParts, ScenarioScript.PlaneNormal, DrawingPlane(), ScenarioScript.DrawingColor, ScenarioScript.DrawingThickness, true, false));
            if (_blockDrawing == null) return;

            _viewer.SetResult(_blockDrawing);
            _viewer.SetResultColor(_blockDrawing, ScenarioScript.DrawingAccent);
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
            _regions = vizcore3dx.Projection.FindClosedRegions(_blockDrawing, ScenarioScript.AreaMinimum);
            watch.Stop();
            SetStatus(string.Format("닫힌 영역 {0:N0} 곳 : {1:0.00} 초", _regions.Count, watch.Elapsed.TotalSeconds));

            int count = Math.Min(_regions.Count, ScenarioScript.AreaCount);
            for (int i = 0; i < count; i++)
            {
                Data.ProjectionEmptyRegion region = _regions[i];
                int order = i;
                _runner.After(0.3 + i * ScenarioScript.AreaStepSeconds, () => AddClosedArea(region, order));
            }
        }

        // ⑤ 치수 — 찾은 영역의 폭(아래 변)·길이(왼쪽 변)와 영역 사이 간격을 2D 에서 재고, 같은 두 점의 3D 치수선을 그립니다.
        //    카메라를 비스듬히 기울여 도면이 블록 위에 떠 있는 모습을 보인 뒤, 천천히 위에서 내려다보는 방향으로 돌아옵니다.
        private void SceneMeasure()
        {
            if (_blockDrawing == null || _regions.Count == 0) return;
            vizcore3dx.View.Effect.ClearTextLabels(ScenarioScript.EffectGroup);   // 3D 면적 글자는 치수선과 겹치므로 지웁니다.
            TiltToFloatingDrawing(2.5);

            List<RectangleF> shapes = _regions.Take(ScenarioScript.MeasureShapeCount).Select(r => r.Bounds).ToList();
            double step = ScenarioScript.MeasureStepSeconds;
            double at = 0.5;
            int order = 0;
            foreach (RectangleF shape in shapes)
            {
                RectangleF area = shape;
                int width = order++, length = order++;
                _runner.After(at, () => AddMeasure(area.Left, area.Bottom, area.Right, area.Bottom, width));
                _runner.After(at + step, () => AddMeasure(area.Left, area.Top, area.Left, area.Bottom, length));
                at += step * 2;
            }

            for (int i = 0; i + 1 < shapes.Count; i++)
            {
                PointF from = Center(shapes[i]);
                PointF to = Center(shapes[i + 1]);
                int gap = order++;
                _runner.After(at, () => AddMeasure(from.X, from.Y, to.X, to.Y, gap));
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
            vizcore3dx.View.Effect.ClearDimensionLines(ScenarioScript.EffectGroup);
            TurnToDrawing(_blockDrawing, _blockBox, 1.5);

            List<Data.Vector2> route = TourRoute();
            _viewer.AddOverlayPolyline(_blockDrawing, route, ScenarioScript.TourColor, 3f);
            for (int i = 0; i < route.Count; i++)
                _viewer.AddOverlayPoint(_blockDrawing, route[i], ScenarioScript.TourColor, 10f, ScenarioScript.TourLabels[i]);
            _tourMarker = _viewer.AddOverlayMarker(_blockDrawing, route[0], 0f, ScenarioScript.CameraMarkerColor, ScenarioScript.MarkerSizePx);

            for (int i = 0; i < route.Count; i++)
            {
                int index = i;
                _runner.After(2.0 + i * ScenarioScript.TourSecondsPerPoint, () => VisitTourPoint(route, index));
            }
        }

        // ⑦ 확대 — 마지막 경로 점 주변을 도면에서 확대하고 격자를 켭니다. 다음 장면에서 전체로 돌아옵니다.
        private void SceneZoomDetail()
        {
            if (_blockDrawing == null) return;

            RectangleF bounds = LocalBounds(_blockDrawing, _blockBox);
            List<Data.Vector2> route = TourRoute();
            Data.Vector2 center = route[route.Count - 1];
            float half = Math.Max(bounds.Width, bounds.Height) * ScenarioScript.ZoomWindow;

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

        // 장면 대상을 정합니다. 모델 전체 = 모든 파트, 블록 = 리본 [블록]에 넣은 이름으로 찾은 어셈블리의 파트.
        private void PrepareTargets()
        {
            _modelParts = vizcore3dx.Object3D.FromFilter(Data.Object3dFilter.PART);
            _modelBox = vizcore3dx.Object3D.GetBoundBox(vizcore3dx.Object3D.GetRootNodes());

            _blockParts = vizcore3dx.Object3D.GetChildObject3d(_block.EntityID, _block.Index, Data.NodeFilterKind.PART);
            if (_blockParts == null || _blockParts.Count == 0) _blockParts = new List<Data.Node> { _block };
            _blockBox = vizcore3dx.Object3D.GetBoundBox(_blockParts);
        }

        // 리본 [블록]에 넣은 이름으로 어셈블리를 찾아 둡니다. 이름이 비었거나 찾지 못하면 장면을 시작하지 않습니다.
        private bool IsBlockReady()
        {
            string name = (_blockName ?? "").Trim();
            if (name.Length == 0)
            {
                SetStatus("[블록]을 눌러 블록 이름을 입력해 주세요.");
                return false;
            }

            List<Data.Node> found = vizcore3dx.Object3D.Find.QuickSearch(name, true, false, false, false);
            if (found == null || found.Count == 0)
            {
                SetStatus("블록을 찾을 수 없습니다 : " + name);
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
                parts, ScenarioScript.PlaneNormal, position, ScenarioScript.DrawingAccent, ScenarioScript.DrawingThickness, true, false);
            if (outline == null)
            {
                _viewer.SetResult(section);
                return;
            }

            // 외곽선은 도면에만 쓰고 3D 뷰에는 그리지 않습니다.
            outline.IsVisible = false;
            _viewer.SetResults(new List<Data.ProjectionItem> { section, outline });
            _viewer.SetResultColor(section, ScenarioScript.DrawingColor);
            _viewer.SetResultColor(outline, ScenarioScript.DrawingAccent);
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
            if (_section == null) _section = vizcore3dx.Section.Add(false, ScenarioScript.SectionAxis);
            if (_section == null) return;

            vizcore3dx.Section.SetSectionPosition(_section.ID, position);
            _section.Enable(true);

            // 남길 쪽을 뒤집습니다. ID 로 그 단면만 뒤집습니다(선택과 무관).
            if (ScenarioScript.SectionInvert) vizcore3dx.Section.InvertDirection(_section.ID);
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

            Color fill = ScenarioScript.AreaColors[order % ScenarioScript.AreaColors.Length];
            _viewer.AddOverlayPolygon(_blockDrawing, outline, fill, Color.FromArgb(255, fill));

            Data.Vector2 center = new Data.Vector2(region.Bounds.X + region.Bounds.Width / 2f, region.Bounds.Y + region.Bounds.Height / 2f);
            string area = (region.Area * ScenarioScript.AreaToSquareMeter).ToString("0.00") + " m²";
            _viewer.AddOverlayText(_blockDrawing, center, area, Color.Black, 13f);

            AddClosedArea3D(outline, center, fill, area);
        }

        // 같은 영역을 3D 뷰에도 그립니다. 도면 좌표를 3D 좌표로 바꿔, 도면 평면 바로 아래에 반투명 면·윤곽선·면적 글자로 얹습니다.
        private void AddClosedArea3D(List<Data.Vector2> outline, Data.Vector2 center, Color fill, string area)
        {
            float top = DrawingPlane().Z - ScenarioScript.AreaLift;

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
            options.Group = ScenarioScript.EffectGroup;
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
            vizcore3dx.View.Effect.ClearTextLabels(ScenarioScript.EffectGroup);
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
            float label = ScenarioScript.MeasureLabelPositions[order % ScenarioScript.MeasureLabelPositions.Length];
            Data.Vector2 start = new Data.Vector2(x1, y1);
            Data.Vector2 end = new Data.Vector2(x2, y2);
            _viewer.AddMeasure(_blockDrawing, start, end, label);

            Data.DimensionLineOptions options = new Data.DimensionLineOptions();
            options.Group = ScenarioScript.EffectGroup;
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
            foreach (PointF ratio in ScenarioScript.TourPoints)
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
            options.Group = ScenarioScript.EffectGroup;
            options.Label = ScenarioScript.TourLabels[index];
            vizcore3dx.View.Effect.AddMarker(world, Data.MarkerIcon.Information, options);

            // 도면과 같은 방향(위)을 유지한 채 그 지점 둘레만 화면에 채웁니다.
            float reach = _blockBox.MaxLength * ScenarioScript.TourZoom * 0.5f;
            vizcore3dx.View.FlyToBoundingBox(world - reach, world + reach, 1.0f, TimeSpan.FromSeconds(ScenarioScript.TourSecondsPerPoint * 0.6));
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
            return new Data.Vector3D(_blockBox.CenterX, _blockBox.CenterY, _blockBox.MaxZ + _blockBox.LengthZ * ScenarioScript.DrawingLift);
        }

        #endregion

        #region 카메라 도착 알림

        // 지금 진행 중인 카메라 이동이 끝나 카메라가 멈추면 next 를 실행합니다.
        private void WhenCameraArrives(Action next)
        {
            _onCameraArrived = next;
        }

        private void View_OnCameraMoveCompletedEvent(object sender, VIZCore3DX.NET.Event.EventManager.CameraMoveCompletedEventArgs e)
        {
            Action next = _onCameraArrived;
            _onCameraArrived = null;
            if (next == null || !IsModelOpened()) return;
            next();
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

        #endregion
    }
}
