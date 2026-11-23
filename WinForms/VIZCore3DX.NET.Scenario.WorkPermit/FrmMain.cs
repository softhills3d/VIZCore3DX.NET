using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Scenario.WorkPermit
{
    // 시나리오 예제 "작업 허가(PTW) — 공간으로 확인하는 안전"
    // 작업 장소를 공간(Zone)으로 만들고, 공간끼리의 기하 판정(겹침·거리·포함)으로 위험을 찾아 이펙트로 보여 줍니다.
    // 장면 하나 = 메서드 하나(#region 장면), 장면의 설명·길이와 장면에 쓰는 값은 ScenarioScript.cs 한 곳에, 재생은 ScenarioRunner.cs 에,
    // 대피 계산은 EvacuationSim.cs 에 있습니다.
    //
    // ── 이 예제에서 SDK 사용을 보려면 ──
    // · 공간(Zone) 만들기: AddZone()
    // · 아래 방향 접촉 거리: DownwardGap()
    // · 통로 분석(통과 가능한 구): AnalyzePassageAsync()
    // · 구역 간 최소 거리(화기 반경): ZonesWithinHotWorkRadius()
    // · 점 포함 판정: PlaceKeelWorkers()
    // · 구역 겹침 판정: SceneDropZone()
    // 장면 재생·리본·카메라 연출(ScenarioRunner.cs, ScenarioRibbon.cs, FlyCamera 등)과 대피 계산(EvacuationSim.cs, SDK 호출 없음)은 SDK 사용과 무관하니 건너뛰어도 됩니다.
    // 다른 모델에 쓰려면: ScenarioScript.cs 의 구역 좌표가 샘플 모델 전용이라 그 모델에 맞는 값으로 바꿔야 합니다.
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 조작부 — 리본 사용자 탭 "시나리오" (뷰어 초기화 뒤에 만듭니다)
        private ScenarioRibbon _ribbon;

        // 대본과 재생기
        private List<ScenarioShot> _shots;
        private ScenarioRunner _runner;

        // 모델 전체의 범위
        private Data.BoundBox3D _modelBox;

        // 허가 공간 (공간 ID, 없으면 -1)과 이 시나리오가 만든 공간 전부
        private int _keelZone = -1;
        private int _floorHotZone = -1;
        private int _platformHotZone = -1;
        private int _funnelZone = -1;
        private int _deckZone = -1;
        private int _combustibleZone = -1;
        private int _dropZone = -1;
        private int _musterZone = -1;
        private readonly List<int> _zones = new List<int>();
        // 다면체 구역의 모서리(두 점이 한 선분) — 강조 외곽선을 상자가 아니라 실제 모양대로 그리는 데 씁니다.
        private readonly Dictionary<int, List<Data.Vector3D>> _zoneEdges = new Dictionary<int, List<Data.Vector3D>>();

        // 이 시나리오가 놓은 아바타
        private readonly List<int> _workers = new List<int>();

        // 시나리오가 바꾸기 전의 X-Ray 강조 색 유형 (정리할 때 되돌립니다)
        private Data.XRayColorTypes? _originalXRayColor;

        // 탱크 공간(다면체)의 경계 상자 — 카메라·창·라벨 자리에 씁니다
        private Data.BoundBox3D _keelBox = ScenarioScript.ZoneKeel;

        // 탱크 바닥 판 (01 장면에서 찾아 둠)
        private List<Data.Node> _tankFloor = new List<Data.Node>();

        // 밝게 칠한 탱크 바닥 판과 칠하기 전의 색 (되돌릴 때 그 색으로 다시 칠합니다)
        private readonly List<Data.Node> _recolored = new List<Data.Node>();
        private readonly List<Color> _recoloredColors = new List<Color>();

        // 실내 장면에서 숨긴 노드 (되돌릴 때 다시 보입니다)
        private readonly List<Data.Node> _hidden = new List<Data.Node>();

        // 대피 장면의 옆 구도에서 켠 상자 단면 (없으면 null)
        private Data.SectionItem _section;

        // 대피 시뮬레이션과 그 갱신 타이머
        private EvacuationSim _evacuation;
        private readonly Timer _evacuationTimer = new Timer();
        private Stopwatch _evacuationWatch = new Stopwatch();
        private long _crowdShownMs;

        // 시나리오가 바꾸기 전의 공간 표시 스타일 (정리할 때 되돌립니다)
        private Data.ZoneStyle _originalZoneStyle;

        // 3D 뷰에 띄운 문구
        private Data.MessageItem _hud;

        // 대피 장면의 빠른 재생 표시
        private Data.MessageItem _speedHud;

        public FrmMain()
        {
            InitializeComponent();

            // 대본 목록은 뷰어와 무관하므로 생성자에서 채웁니다.
            _shots = BuildShots();

            _runner = new ScenarioRunner(_shots);
            _runner.ShotStarted += Runner_ShotStarted;

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            this.Controls.Add(vizcore3dx);

            _evacuationTimer.Interval = ScenarioScript.EvacuationTickMs;
            _evacuationTimer.Tick += EvacuationTimer_Tick;

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
        }

        // 대본 표의 장면에 장면 메서드를 잇습니다. 이 순서가 재생 순서입니다.
        private List<ScenarioShot> BuildShots()
        {
            ScenarioScript.Permits.Play = ScenePermits;
            ScenarioScript.TankBelow.Play = SceneTankBelow;
            ScenarioScript.SparkFall.Play = SceneSparkFall;
            ScenarioScript.Headcount.Play = SceneHeadcount;
            ScenarioScript.DropZone.Play = SceneDropZone;
            ScenarioScript.Evacuation.Play = SceneEvacuation;
            ScenarioScript.Outro.Play = SceneOutro;

            // 번호 버튼으로 바로 볼 때 먼저 실행할 장면 — 02~07 은 01 이 만든 허가 공간을 씁니다.
            foreach (ScenarioShot shot in new[] { ScenarioScript.TankBelow, ScenarioScript.SparkFall, ScenarioScript.Headcount,
                ScenarioScript.DropZone, ScenarioScript.Evacuation, ScenarioScript.Outro })
                shot.Before = new[] { 1 };

            return new List<ScenarioShot>
            {
                ScenarioScript.Permits, ScenarioScript.TankBelow, ScenarioScript.SparkFall, ScenarioScript.Headcount,
                ScenarioScript.DropZone, ScenarioScript.Evacuation, ScenarioScript.Outro,
            };
        }

        // 창을 닫을 때 대피 타이머와 재생 타이머부터 멈춥니다.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _evacuationTimer.Stop();
            _runner.Reset();
            base.OnFormClosing(e);
        }

        // 재생 중에도 Esc 로 멈출 수 있게 합니다.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape && _runner.IsPlaying)
            {
                _runner.Reset();
                SetStatus("재생을 중단했습니다.");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region 1. 모델

        // 모델을 엽니다. 작업 구역 좌표는 샘플 모델 선박\AftSection_RevA.vizx 에 맞춰 있습니다(ScenarioScript.cs).
        private void Ribbon_OpenModel()
        {
            if (_runner.IsPlaying) return;
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            ClearScene();
            SetStatus("모델을 열었습니다. [전체 재생]이나 장면 번호를 누르세요.");
        }

        #endregion

        #region 3. 장면

        // 첫 장면부터 끝까지 이어서 재생합니다. 첫 장면 전에 작업 구역이 모델 안에 있는지 확인합니다.
        private void Ribbon_PlayAll()
        {
            if (!IsModelOpened() || !IsModelReady()) return;

            ClearScene();
            _runner.PlayAll();
        }

        // 번호 버튼 — 그 장면을 재생합니다. 바로 앞 장면에 이어 누른 것이 아니면 처음 상태로 되돌리고 선행 장면을 실행한 뒤 재생합니다.
        private void Ribbon_GoScene(int first, int last)
        {
            if (!IsModelOpened() || !IsModelReady()) return;

            if (_runner.IsReadyFor(first))
            {
                _runner.PlayFrom(first, last);
                return;
            }

            ClearScene();
            _runner.Prepare(first, () => _runner.PlayFrom(first, last));
        }

        private void Runner_ShotStarted(ScenarioShot shot)
        {
            _ribbon.SetCurrent(_runner.Index);
            SetStatus(shot.Name + " — " + shot.Caption);
        }

        // 대피 한 틱 — 시뮬레이션을 진행하고 아바타를 다음 위치로 보간 이동시킵니다.
        private void EvacuationTimer_Tick(object sender, EventArgs e)
        {
            if (_evacuation == null) { _evacuationTimer.Stop(); return; }

            _evacuation.Step(ScenarioScript.EvacuationTickMs / 1000.0 * ScenarioScript.TimeScale);
            int arrived = MoveEvacuees();
            ShowQueues();

            int count = _evacuation.Agents.Count;
            ShowHud(string.Format("집결 {0}/{1} · 대피 중 {2}", arrived, count, count - arrived));
            ShowSpeedHud(string.Format(ScenarioScript.SpeedHudText, ScenarioScript.TimeScale, _evacuation.Time));
            if (!_evacuation.IsFinished) return;

            FinishEvacuation(arrived, count);
        }

        #endregion

        #region 5. 정리

        // 어느 장면에서든 처음 상태로 되돌립니다.
        private void Ribbon_Reset()
        {
            ClearScene();
            if (vizcore3dx.Model.IsOpen()) vizcore3dx.View.FitToView();
            SetStatus("처음으로 되돌렸습니다.");
        }

        // 재생을 멈추고 처음으로 되돌린 뒤, 시나리오가 만든 공간·이펙트·3D 표시를 전부 지웁니다.
        private void ClearScene()
        {
            _runner.Reset();
            if (_ribbon != null) _ribbon.SetCurrent(0);

            StopEvacuation();
            if (vizcore3dx.Model.IsOpen()) Clear3D();
            _keelZone = _floorHotZone = _platformHotZone = _funnelZone = _deckZone = _combustibleZone = _dropZone = _musterZone = -1;
            _zones.Clear();
            _zoneEdges.Clear();
            _workers.Clear();
            _hidden.Clear();
            _tankFloor = new List<Data.Node>();
        }

        private void Clear3D()
        {
            vizcore3dx.BeginUpdate();
            try
            {
                // 이 시나리오가 만든 공간만 지웁니다. 진행 중인 통로 분석이 있으면 먼저 멈춥니다.
                if (vizcore3dx.Zone.IsAnalyzing) vizcore3dx.Zone.CancelAnalyzeAsync();
                if (_zones.Count > 0) vizcore3dx.Zone.Delete(new List<int>(_zones));

                // 이 시나리오가 놓은 아바타만 지웁니다.
                RemoveWorkers();

                if (_originalZoneStyle != null) vizcore3dx.Zone.SetStyle(_originalZoneStyle);
                _originalZoneStyle = null;

                ClearEffects(ScenarioScript.Groups);
                vizcore3dx.View.Effect.ClearWeldingSparks();
                vizcore3dx.Shape.Delete(ScenarioScript.StairCategory);

                RestoreModelView();
                ClearHud();
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        // X-Ray 를 끄고, 시나리오가 바꾼 강조 색 유형을 원래대로 되돌립니다.
        private void RestoreXRay()
        {
            vizcore3dx.View.XRay.Clear();
            vizcore3dx.View.XRay.Enable = false;
            if (_originalXRayColor != null) vizcore3dx.View.XRay.ColorType = _originalXRayColor.Value;
            _originalXRayColor = null;
        }

        // 묶음 이름으로 이펙트를 지웁니다. 이펙트는 종류별로 지우므로, 이 시나리오가 쓰는 종류를 모두 부릅니다.
        private void ClearEffects(params string[] groups)
        {
            foreach (string group in groups)
            {
                vizcore3dx.View.Effect.ClearMarkers(group);
                vizcore3dx.View.Effect.ClearTextLabels(group);
                vizcore3dx.View.Effect.ClearPulseOutlines(group);
                vizcore3dx.View.Effect.ClearPulseSpheres(group);
                vizcore3dx.View.Effect.ClearGasClouds(group);
                vizcore3dx.View.Effect.ClearVapors(group);
                vizcore3dx.View.Effect.ClearDimensionLines(group);
                vizcore3dx.View.Effect.ClearPathLines(group);
                vizcore3dx.View.Effect.ClearParticleEmitters(group);
                vizcore3dx.View.Effect.ClearGroundRings(group);
            }
        }

        #endregion

        #region 장면

        // 01 오늘의 작업 허가 — 허가 5건을 실제 구획에 공간으로 올립니다. 정지 허가는 갈색으로 남깁니다.
        private void ScenePermits()
        {
            _modelBox = vizcore3dx.Object3D.GetBoundBox(vizcore3dx.Object3D.GetRootNodes());

            Stopwatch watch = Stopwatch.StartNew();
            CreatePermitZones();
            watch.Stop();

            // 탱크 바닥 판은 모델이 전부 보이는 지금 찾아 둡니다 — 그룹을 숨긴 뒤에는 그 안의 부재가 조회에 잡히지 않습니다.
            _keelBox = vizcore3dx.Zone.GetBoundBox(_keelZone);
            _tankFloor = FindFloorIn(_keelBox);

            int[] permits = { _keelZone, _floorHotZone, _platformHotZone, _funnelZone, _deckZone };
            ShowHud(string.Format("허가 {0}건 · 활성 3 · 요청 1 · 정지 1 · 공간 생성 {1} ms\nP1 탱크·P4 연돌은 둘레의 실제 판에서 찾은 평면으로 닫은 다면체", permits.Length, watch.ElapsedMilliseconds));

            FlyToBox(_modelBox, ScenarioScript.ViewOverview, 2.0);
            for (int i = 0; i < permits.Length; i++)
            {
                int id = permits[i];
                _runner.After(2.0 + i * ScenarioScript.ZoneStepSeconds, () => RevealZone(id));
            }
            _runner.After(2.0 + permits.Length * ScenarioScript.ZoneStepSeconds, ShowPermitsInXRay);
            _runner.After(2.0 + permits.Length * ScenarioScript.ZoneStepSeconds + 4.5, ShowTankSection);
        }

        // 02 도장 중인 탱크 위 화기 — 이중저 탱크 도장 중에 바로 위 플로어 용접을 요청합니다. 아래 방향 접촉과 통로 연결로 인접을 판정해 허가를 보류합니다.
        private async void SceneTankBelow()
        {
            Data.Vector3D from, to;
            double gap = DownwardGap(_floorHotZone, _keelZone, out from, out to);
            ShowHud("P1 이중저 탱크 도장 중 · P2 플로어 용접 허가 요청 — 통로 분석 중");
            ClearEffects(ScenarioScript.GroupStatus);

            Data.BoundBox3D keel = _keelBox;
            Data.BoundBox3D hot = ScenarioScript.ZoneFloorHot;
            FlyToBoxes(keel, hot, ScenarioScript.ViewTankAbove, 2.5);

            // 통로 분석은 형상을 숨기기 전에 합니다 — 숨긴 부재는 장애물에서 빠져 결과가 달라집니다.
            int paintZone = _keelZone;
            Stopwatch watch = Stopwatch.StartNew();
            Data.ZoneAnalysisResult result = await AnalyzePassageAsync(paintZone, gap);
            watch.Stop();

            // 그사이 처음으로 되돌렸으면 그만둡니다.
            if (_keelZone != paintZone || result == null || !result.IsSucceeded) return;

            // X-Ray 대신 실제 형상으로 — 바깥 껍데기를 걷고 탱크 위를 숨겨, 탱크 안과 위 플로어를 함께 봅니다.
            SetCutaway(true, false);
            OpenTankWindow(keel);

            _runner.After(0.5, () => ShowTankVapor(keel));
            _runner.After(2.5, () => ShowHotWorkRequest(hot));
            _runner.After(4.5, () => ShowTankGap(from, to, gap));
            _runner.After(6.5, () => ShowPassageVerdict(hot, gap, result, watch.Elapsed.TotalSeconds));
            _runner.After(10.0, () => Orbit(-25f, 7.0));
        }

        // 03 플랫폼 화기의 불티 — 플랫폼 용접 반경 11 m 안의 다른 작업과 바로 아래 가연물을 찾고, 불티 낙하 경로와 화재 감시 조건을 보입니다.
        private void SceneSparkFall()
        {
            ClearEffects(ScenarioScript.GroupHazard, ScenarioScript.GroupStatus);
            ShowHud("P3 플랫폼 배관 지지대 용접 중");

            Data.BoundBox3D hot = ScenarioScript.ZonePlatformHot;
            _combustibleZone = AddZone(ScenarioScript.ZoneCombustible, ScenarioScript.NameCombustible, ScenarioScript.ColorCombustible);
            vizcore3dx.Zone.SetVisible(_combustibleZone, true);
            List<int> within = ZonesWithinHotWorkRadius();

            Data.Vector3D from, to;
            DownwardGap(_platformHotZone, _combustibleZone, out from, out to);
            FlyToBoxes(hot, ScenarioScript.ZoneCombustible, ScenarioScript.ViewZone, 2.5);

            ScheduleWeldingSparks(hot);
            _runner.After(5.0, () => ShowHotWorkRadius(hot, within.Count));
            for (int i = 0; i < within.Count; i++)
            {
                int id = within[i];
                _runner.After(6.5 + i * 0.7, () => Outline(id, ScenarioScript.ColorAccent, ScenarioScript.GroupHazard));
            }
            _runner.After(9.5, () => ShowSparkPath(from, to));
            _runner.After(12.0, () => ShowFireWatch(hot));
            _runner.After(13.0, () => Orbit(20f, 6.0));
        }

        // 04 밀폐 공간 출입 인원 — 이중저 탱크 도장 허가의 인원과, 위치로 센 실제 인원을 대조합니다.
        private void SceneHeadcount()
        {
            ClearEffects(ScenarioScript.GroupHazard, ScenarioScript.GroupStatus);
            vizcore3dx.View.Effect.ClearWeldingSparks();
            vizcore3dx.Zone.SetVisible(_combustibleZone, false);
            ShowHud(string.Format("P1 이중저 탱크 도장 · 허가 인원 {0}명", ScenarioScript.PermitHeadcount));

            // X-Ray 를 끄고 위쪽 그룹만 걷어 낸 뒤(외판은 남김), 탱크 위(이중저 윗면 ~ 플로어 작업 높이)를 숨겨 안을 들여다볼 창을 냅니다.
            Data.BoundBox3D keel = _keelBox;
            SetCutaway(true, true, ScenarioScript.CutawayGroupsKeepShell);
            OpenTankWindow(keel);

            List<bool> inside = PlaceKeelWorkers();
            int count = inside.FindAll(contained => contained).Count;
            FlyToBoxes(keel, new Data.BoundBox3D(keel.MinX, keel.MinY, keel.MinZ, keel.MaxX, keel.MaxY, 7000f), ScenarioScript.ViewTank, 2.5);

            _runner.After(2.5, () => ShowGasReading(keel));
            ScheduleHeadcountLabels(inside);
            _runner.After(4.5 + ScenarioScript.KeelWorkers.Length * 1.5, () => ShowHeadcountVerdict(keel, count));
            _runner.After(12.0, () => Orbit(20f, 5.0));
        }

        // 05 낙하물과 정지 허가 — 연돌 상부 의장의 낙하물 통제 구역을 만들고, 정지된 허가와 겹치는지 판정합니다.
        private void SceneDropZone()
        {
            ClearEffects(ScenarioScript.GroupHazard, ScenarioScript.GroupStatus);
            RemoveWorkers();
            SetCutaway(false);
            ShowHud("P4 연돌 상부 의장 (고소 작업)");

            Data.BoundBox3D funnel = ScenarioScript.ZoneFunnel;
            float height = funnel.MinZ - ScenarioScript.DropFloor;
            float radius = Math.Max(ScenarioScript.DropMinRadius, height / ScenarioScript.DropRatio);
            Data.BoundBox3D drop = new Data.BoundBox3D(funnel.MinX - radius, funnel.MinY - radius, ScenarioScript.DropFloor, funnel.MaxX + radius, funnel.MaxY + radius, funnel.MinZ);
            _dropZone = AddZone(drop, ScenarioScript.NameDrop, ScenarioScript.ColorAccent);

            bool overlap = vizcore3dx.Zone.IsIntersecting(_dropZone, _deckZone);

            Data.BoundBox3D view = new Data.BoundBox3D(funnel.GetVertexMin(), funnel.GetVertexMax());
            view.AddBox(drop);
            view.AddBox(ScenarioScript.ZoneDeck);
            FlyToBox(view, ScenarioScript.ViewOverview, 2.5);

            _runner.After(2.5, () => ShowDropZone(drop, height, radius));
            _runner.After(5.5, () => ShowDropOverlap(overlap));
            _runner.After(9.0, () => Orbit(-25f, 6.0));
        }

        // 06 화재 · 전원 대피 — 플랫폼 화재. 막힌 길목을 빼고 사람마다 집결지까지 경로를 다시 계산해 움직입니다.
        // 평지 구간은 충돌 보행(Avatar.TraceWalkAsync)으로 장비를 피해 실제로 걷는 경로를 먼저 구하고, 막힌 구간만 직선으로 대체합니다.
        private async void SceneEvacuation()
        {
            ClearEffects(ScenarioScript.GroupHazard, ScenarioScript.GroupStatus);
            vizcore3dx.Zone.SetVisible(_dropZone, false);
            ShowPermitZones(false);   // 대피와 무관한 허가 구역·라벨은 빼고 불이 난 P3 만 남깁니다.

            Data.BoundBox3D fire = ScenarioScript.ZonePlatformHot;
            EvacuationSim evacuation = new EvacuationSim();
            _evacuation = evacuation;
            int blocked = evacuation.BlockNear(fire, ScenarioScript.FireBlockMargin);
            FlyToEvacuationOverview();
            ShowFire(fire);

            // 1) 걷는 구간의 충돌 보행 경로 — 무리 가운데 → 입구, 길목 사이 통로. 외판을 숨기기 전에(바닥이 있을 때) 구합니다.
            string preset = AvatarPreset();
            if (preset == null) return;
            List<KeyValuePair<Data.Vector3D, Data.Vector3D>> legs = EvacuationLegs(evacuation);
            Dictionary<string, List<Data.Vector3D>> traced = await TraceLegsAsync(evacuation, preset, legs);
            if (traced == null) return;

            // 2) 실내를 열고 계단·집결지를 만든 뒤 사람을 배치하고 경로를 그립니다.
            SetCutaway(true, true);
            DrawStairs(evacuation);
            AddMusterZone();
            PlaceEvacuees(evacuation, preset, traced);
            ShowEvacuationRoutes(evacuation, traced);
            ShowHud(string.Format("경보 — {0}명 대피 · 막힌 길목 {1}곳 · 충돌 보행 경로 {2}/{3} 구간 (나머지 직선)", evacuation.Agents.Count, blocked, traced.Count, legs.Count));
            _runner.After(2.0, () => StartEvacuation(evacuation));
            ScheduleClimbShots(evacuation);
        }

        // 07 마무리 — 모델 전체로 물러나며 허가 구역을 다시 모두 보입니다.
        private void SceneOutro()
        {
            StopEvacuation();
            vizcore3dx.Shape.Delete(ScenarioScript.StairCategory);
            ClearEffects(ScenarioScript.GroupFire, ScenarioScript.GroupCrowd);
            ClearHud();
            SetCutaway(false);
            ShowPermitZones(true);
            FlyToBox(_modelBox, ScenarioScript.ViewOverview, 2.5);
            _runner.After(2.5, () => Orbit(ScenarioScript.OrbitDegrees, 5.0));
        }

        #endregion

        #region 장면 도우미

        // 작업 구역이 열린 모델 안에 들어가는지 확인합니다. 구역 좌표는 샘플 모델에서 잰 값이라 다른 모델에서는 맞지 않습니다.
        private bool IsModelReady()
        {
            Data.BoundBox3D model = vizcore3dx.Object3D.GetBoundBox(vizcore3dx.Object3D.GetRootNodes());
            foreach (Data.BoundBox3D zone in new[] { ScenarioScript.ZoneKeel, ScenarioScript.ZoneFloorHot, ScenarioScript.ZonePlatformHot, ScenarioScript.ZoneFunnel, ScenarioScript.ZoneDeck })
            {
                if (model != null && model.Contains(zone.GetCenter())) continue;

                SetStatus("작업 구역이 모델 밖에 있습니다. 샘플 모델 선박\\AftSection_RevA.vizx 를 열거나 ScenarioScript.cs 의 구역 좌표를 바꿔 주세요.");
                return false;
            }
            return true;
        }

        // ---- 01 오늘의 작업 허가 ----

        // 구역이 모두 보인 뒤에 X-Ray 를 켜고 모델을 돕니다. 처음에는 모델 그대로 위에 구역이 하나씩 올라가게 합니다.
        private void ShowPermitsInXRay()
        {
            vizcore3dx.View.XRay.SelectionObject3DType = Data.SelectionObject3DTypes.OPAQUE_OBJECT3D;
            vizcore3dx.View.XRay.Enable = true;
            // 구역 안 부재는 선택 색(빨강) 대신 원래 색으로 또렷하게 — 빨강은 화기 표시에만 씁니다. 정리할 때 되돌립니다.
            if (_originalXRayColor == null) _originalXRayColor = vizcore3dx.View.XRay.ColorType;
            vizcore3dx.View.XRay.ColorType = Data.XRayColorTypes.OBJECT_COLOR;
            Orbit(ScenarioScript.OrbitDegrees, 4.0);
        }

        // 끝으로 탱크를 길이 방향에서 봅니다 — 선저를 따라 기운 쐐기 단면이 보이게.
        private void ShowTankSection()
        {
            FlyToBox(_keelBox, ScenarioScript.ViewTankSection, 2.0);
            Outline(_keelZone, ScenarioScript.ColorAccent, ScenarioScript.GroupStatus);
        }

        // 허가 5건의 공간을 만듭니다. 좌표는 값 표(ScenarioScript.cs)에 있습니다. 처음에는 숨겨 둡니다.
        private void CreatePermitZones()
        {
            // 공간을 선체 너머로도 보이게 합니다(깊이 판정 끔). 정리할 때 원래 스타일로 되돌립니다.
            _originalZoneStyle = vizcore3dx.Zone.Style.Clone();
            Data.ZoneStyle style = vizcore3dx.Zone.Style.Clone();
            style.DepthTestEnabled = false;
            vizcore3dx.Zone.SetStyle(style);

            vizcore3dx.Zone.BeginUpdate();
            try
            {
                // P1·P4 는 둘레의 실제 판에서 찾은 평면으로 닫은 다면체 — 탱크는 앞뒤(X)만, 연돌은 위아래(Z)만 상자 면을 씁니다.
                _keelZone = AddWalledZone(ScenarioScript.ZoneKeel, ScenarioScript.TankSearch, ScenarioScript.TankSeed, AxesYZ, ScenarioScript.NameKeel, ScenarioScript.ColorPaint);
                _floorHotZone = AddZone(ScenarioScript.ZoneFloorHot, ScenarioScript.NameFloorHot, ScenarioScript.ColorHotRequested);
                _platformHotZone = AddZone(ScenarioScript.ZonePlatformHot, ScenarioScript.NamePlatformHot, ScenarioScript.ColorHot);
                Data.BoundBox3D funnel = ScenarioScript.ZoneFunnel;
                float m = ScenarioScript.WallSearchMargin;
                Data.BoundBox3D funnelSearch = new Data.BoundBox3D(funnel.MinX - m, funnel.MinY - m, funnel.MinZ - m, funnel.MaxX + m, funnel.MaxY + m, funnel.MaxZ + m);
                _funnelZone = AddWalledZone(funnel, funnelSearch, new Data.Vector3D(funnel.CenterX, funnel.CenterY, funnel.CenterZ), AxesXY, ScenarioScript.NameFunnel, ScenarioScript.ColorHeight);
                _deckZone = AddZone(ScenarioScript.ZoneDeck, ScenarioScript.NameDeck, ScenarioScript.ColorSuspended);
                vizcore3dx.Zone.SetFaceOpacity(_deckZone, ScenarioScript.SuspendedOpacity);
            }
            finally
            {
                vizcore3dx.Zone.EndUpdate();
            }
        }

        // 판에서 평면을 찾을 방향 묶음 — 탱크는 Y·Z 네 방향, 연돌은 X·Y 네 방향
        private static readonly Data.Vector3D[] AxesYZ = { new Data.Vector3D(0f, 1f, 0f), new Data.Vector3D(0f, -1f, 0f), new Data.Vector3D(0f, 0f, 1f), new Data.Vector3D(0f, 0f, -1f) };
        private static readonly Data.Vector3D[] AxesXY = { new Data.Vector3D(1f, 0f, 0f), new Data.Vector3D(-1f, 0f, 0f), new Data.Vector3D(0f, 1f, 0f), new Data.Vector3D(0f, -1f, 0f) };

        // 둘레의 실제 판에서 찾은 평면으로 닫은 다면체 공간을 만듭니다. seed 에서 여섯 방향을 보되,
        // plateDirections 에 든 방향은 판에서 평면을 찾고 나머지는 상자 면을 씁니다.
        // 어느 방향이든 판을 못 찾으면 그 방향은 상자 면으로 대신하고, 다면체가 닫히지 않으면 상자 그대로 만듭니다.
        private int AddWalledZone(Data.BoundBox3D box, Data.BoundBox3D search, Data.Vector3D seed, Data.Vector3D[] plateDirections, string name, Color color)
        {
            List<WallPlate> plates = FindPlates(search);
            List<Data.Plane3D> planes = new List<Data.Plane3D>();
            List<Data.Vector3D> points = new List<Data.Vector3D>(), normals = new List<Data.Vector3D>();
            foreach (Data.Vector3D direction in new[] { new Data.Vector3D(1f, 0f, 0f), new Data.Vector3D(-1f, 0f, 0f), new Data.Vector3D(0f, 1f, 0f),
                                                        new Data.Vector3D(0f, -1f, 0f), new Data.Vector3D(0f, 0f, 1f), new Data.Vector3D(0f, 0f, -1f) })
            {
                WallPlate wall = Array.Exists(plateDirections, d => d.Dot(direction) > 0.99f) ? PickWall(plates, search, seed, direction) : null;
                // 상자 면 — 그 방향의 상자 끝을 지나는 평면
                Data.Vector3D point = wall != null ? wall.Point
                    : new Data.Vector3D(direction.X > 0f ? box.MaxX : box.MinX, direction.Y > 0f ? box.MaxY : box.MinY, direction.Z > 0f ? box.MaxZ : box.MinZ);
                Data.Vector3D normal = wall != null ? wall.Normal : direction;
                planes.Add(new Data.Plane3D(point, normal));

                // 모서리 계산용 — 법선을 seed 반대쪽(바깥)으로 맞춰 둡니다.
                points.Add(point);
                normals.Add(normal.Dot(point - seed) < 0f ? normal * -1f : normal);
            }

            int id = vizcore3dx.Zone.CreateZoneFromPlanes(planes, seed, name, Data.ZoneClosing.PlanesOnly);
            if (id < 0) return AddZone(box, name, color);

            _zoneEdges[id] = PolyhedronEdges(points, normals);
            _zones.Add(id);
            vizcore3dx.Zone.SetColor(id, color, color);
            vizcore3dx.Zone.SetFaceOpacity(id, ScenarioScript.ZoneOpacity);
            vizcore3dx.Zone.SetVisible(id, false);
            return id;
        }

        // 판 하나 — 넓은 면의 방향·그 면의 넓이 가중 중심·넓이(m², 한쪽 면)
        private class WallPlate
        {
            public Data.Vector3D Point, Normal;
            public double Area;
        }

        // search 상자에 걸친 부재의 형상(삼각형)을 읽어, 넓은 평면을 가진 것만 판으로 돌려줍니다.
        private List<WallPlate> FindPlates(Data.BoundBox3D search)
        {
            List<WallPlate> plates = new List<WallPlate>();
            foreach (Data.Node node in BodiesIn(search))
            {
                WallPlate plate = PlateOf(node.GetTransformedColorTriangleMesh());
                if (plate != null) plates.Add(plate);
            }
            return plates;
        }

        // search 상자에 걸친 부재 가운데 형상이 있는 노드를 모읍니다. 판정용 공간을 잠시 만들었다가 지웁니다.
        private List<Data.Node> BodiesIn(Data.BoundBox3D search)
        {
            List<Data.Node> bodies = new List<Data.Node>();
            int zone = vizcore3dx.Zone.CreateZoneFromBoundBox(search, "search", 0f);
            if (zone < 0) return bodies;

            List<Data.Node> nodes = vizcore3dx.Zone.GetNodesInZone(zone, Data.BoundBoxSearchOption.IncludingPart, false, true);
            vizcore3dx.Zone.Delete(new List<int> { zone });
            if (nodes == null) return bodies;

            // 형상(삼각형)은 Body 노드에만 있습니다 — 조회가 PART 를 돌려주면 그 아래 Body 까지 내려갑니다.
            foreach (Data.Node node in nodes)
            {
                if (node.HasMesh) bodies.Add(node);
                else bodies.AddRange(node.GetChildObject3d(Data.Object3DChildOption.ALL_CHILDREN).FindAll(child => child.HasMesh));
            }
            return bodies;
        }

        // 형상 하나에서 넓은 평면을 찾아 판으로 돌려줍니다. 판이 아니면 null.
        // 판은 앞뒤 두 면의 법선이 반대라 그대로 더하면 0 이 되므로, 가장 큰 삼각형의 법선 쪽으로 부호를 맞춰 더합니다.
        private static WallPlate PlateOf(Data.TriangleMesh mesh)
        {
            if (mesh == null || mesh.IsEmpty) return null;

            double[] largest;
            List<double[]> triangles = Triangles(mesh, out largest);
            if (largest == null) return null;

            double sx = 0, sy = 0, sz = 0, cx = 0, cy = 0, cz = 0, total = 0;
            foreach (double[] t in triangles)
            {
                double dot = t[0] * largest[0] + t[1] * largest[1] + t[2] * largest[2];
                if (Math.Abs(dot) < 0.9) continue;

                double sign = dot < 0.0 ? -1.0 : 1.0;
                total += t[3];
                sx += t[0] * sign * t[3]; sy += t[1] * sign * t[3]; sz += t[2] * sign * t[3];
                cx += t[4] * t[3]; cy += t[5] * t[3]; cz += t[6] * t[3];
            }
            double area2 = total / 2e6;   // mm² 양면 합 → m² 한쪽 면
            double length = Math.Sqrt(sx * sx + sy * sy + sz * sz);
            if (area2 < ScenarioScript.WallMinArea || length <= 0.0) return null;

            return new WallPlate
            {
                Point = new Data.Vector3D(cx / total, cy / total, cz / total),
                Normal = new Data.Vector3D(sx / length, sy / length, sz / length),
                Area = area2,
            };
        }

        // 삼각형마다 법선 xyz · 넓이 · 중심 xyz 를 구합니다. 넓이가 가장 큰 삼각형도 함께 돌려줍니다(없으면 null).
        private static List<double[]> Triangles(Data.TriangleMesh mesh, out double[] largest)
        {
            List<Data.Vertex3D> vertices = mesh.Vertices;
            List<int> indices = mesh.Indices;
            List<double[]> triangles = new List<double[]>();
            largest = null;
            for (int i = 0; i + 2 < indices.Count; i += 3)
            {
                Data.Vertex3D a = vertices[indices[i]], b = vertices[indices[i + 1]], c = vertices[indices[i + 2]];
                double ux = b.X - a.X, uy = b.Y - a.Y, uz = b.Z - a.Z, wx = c.X - a.X, wy = c.Y - a.Y, wz = c.Z - a.Z;
                double nx = uy * wz - uz * wy, ny = uz * wx - ux * wz, nz = ux * wy - uy * wx;
                double area = Math.Sqrt(nx * nx + ny * ny + nz * nz) / 2.0;
                if (area <= 0.0) continue;

                double[] triangle = { nx / (2 * area), ny / (2 * area), nz / (2 * area), area, (a.X + b.X + c.X) / 3.0, (a.Y + b.Y + c.Y) / 3.0, (a.Z + b.Z + c.Z) / 3.0 };
                triangles.Add(triangle);
                if (largest == null || area > largest[3]) largest = triangle;
            }
            return triangles;
        }

        // seed 에서 direction 쪽에 있고, 넓은 면이 direction 과 나란하며(기울기 한도 안), 그 면의 중심이 search 안에 있는 판 가운데 가장 넓은 판. 없으면 null.
        private static WallPlate PickWall(List<WallPlate> plates, Data.BoundBox3D search, Data.Vector3D seed, Data.Vector3D direction)
        {
            WallPlate best = null;
            foreach (WallPlate plate in plates)
            {
                if (Math.Abs(plate.Normal.Dot(direction)) < ScenarioScript.WallMinAlign) continue;
                if ((plate.Point - seed).Dot(direction) <= 0f) continue;
                if (!search.Contains(plate.Point.ToVertex3D())) continue;
                if (best == null || plate.Area > best.Area) best = plate;
            }
            return best;
        }

        // 평면(점 · 바깥 법선)들로 닫힌 다면체의 모서리를 구합니다(두 점이 한 선분). 평면 둘을 함께 지나는 두 꼭짓점이 모서리입니다.
        private static List<Data.Vector3D> PolyhedronEdges(List<Data.Vector3D> points, List<Data.Vector3D> normals)
        {
            List<int> onPlanes;
            List<Data.Vector3D> corners = PolyhedronCorners(points, normals, out onPlanes);

            List<Data.Vector3D> edges = new List<Data.Vector3D>();
            for (int u = 0; u < corners.Count; u++)
                for (int v = u + 1; v < corners.Count; v++)
                {
                    int shared = onPlanes[u] & onPlanes[v], count = 0;
                    for (; shared != 0; shared &= shared - 1) count++;
                    if (count >= 2) { edges.Add(corners[u]); edges.Add(corners[v]); }
                }
            return edges;
        }

        // 세 평면이 만나는 점 가운데 모든 평면의 안쪽인 것이 꼭짓점입니다. 꼭짓점마다 그 점이 놓인 평면들(비트)도 함께 돌려줍니다.
        private static List<Data.Vector3D> PolyhedronCorners(List<Data.Vector3D> points, List<Data.Vector3D> normals, out List<int> onPlanes)
        {
            const float tolerance = 5f;
            List<Data.Vector3D> corners = new List<Data.Vector3D>();
            onPlanes = new List<int>();
            int n = points.Count;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    for (int k = j + 1; k < n; k++)
                    {
                        Data.Vector3D a = normals[i], b = normals[j], c = normals[k];
                        float det = a.Dot(b.Cross(c));
                        if (Math.Abs(det) < 1e-4f) continue;

                        Data.Vector3D p = (b.Cross(c) * a.Dot(points[i]) + c.Cross(a) * b.Dot(points[j]) + a.Cross(b) * c.Dot(points[k])) / det;
                        int mask = PlaneMask(points, normals, p, tolerance);
                        if (mask < 0) continue;

                        int same = corners.FindIndex(q => (q - p).Length() < tolerance);
                        if (same >= 0) onPlanes[same] |= mask;
                        else { corners.Add(p); onPlanes.Add(mask); }
                    }
            return corners;
        }

        // 점 p 가 놓인 평면들(비트)을 구합니다. 어느 한 평면의 바깥이면 -1 입니다.
        private static int PlaneMask(List<Data.Vector3D> points, List<Data.Vector3D> normals, Data.Vector3D p, float tolerance)
        {
            int mask = 0;
            for (int m = 0; m < points.Count; m++)
            {
                float side = normals[m].Dot(p - points[m]);
                if (side > tolerance) return -1;
                if (side > -tolerance) mask |= 1 << m;
            }
            return mask;
        }

        // 공간을 만들어 숨겨 둡니다. 정리할 때 지우도록 목록에 넣습니다.
        private int AddZone(Data.BoundBox3D box, string name, Color color)
        {
            int id = vizcore3dx.Zone.CreateZoneFromBoundBox(box, name, 0f);
            if (id < 0) return id;

            _zones.Add(id);
            vizcore3dx.Zone.SetColor(id, color, color);
            vizcore3dx.Zone.SetFaceOpacity(id, ScenarioScript.ZoneOpacity);
            vizcore3dx.Zone.SetVisible(id, false);
            return id;
        }

        // 허가 구역 5개와 이름 라벨을 모두 보이거나(true), 화기 P3 하나만 남깁니다(false).
        private void ShowPermitZones(bool all)
        {
            ClearEffects(ScenarioScript.GroupLabel);
            foreach (int id in new[] { _keelZone, _floorHotZone, _platformHotZone, _funnelZone, _deckZone })
            {
                if (all || id == _platformHotZone) RevealZone(id);
                else if (id >= 0) vizcore3dx.Zone.SetVisible(id, false);
            }
        }

        // 숨겨 둔 구역을 보이고, 구역 꼭대기에 허가 이름을 띄웁니다.
        private void RevealZone(int id)
        {
            if (id < 0) return;

            vizcore3dx.Zone.SetVisible(id, true);
            Data.ZoneItem item = vizcore3dx.Zone.GetItem(id);
            Data.BoundBox3D box = vizcore3dx.Zone.GetBoundBox(id);
            vizcore3dx.View.Effect.AddTextLabel(new Data.Vector3D(box.CenterX, box.CenterY, box.MaxZ), item.Name,
                new Data.TextLabelOptions { BackColor = item.FaceColor, Group = ScenarioScript.GroupLabel });
        }

        // ---- 02 도장 중인 탱크 위 화기 ----

        // 탱크와 플로어 화기 구역 사이를 사람이 지날 수 있는지(통과 가능한 가장 큰 구) 분석합니다.
        private async Task<Data.ZoneAnalysisResult> AnalyzePassageAsync(int paintZone, double gap)
        {
            Data.ZoneAnalysisOptions options = new Data.ZoneAnalysisOptions
            { Items = Data.ZoneAnalysisItems.MaxSphereRadius, AdjacencyMaxDistance = (float)gap + 1000f, UseObstacleCache = true };
            return await vizcore3dx.Zone.AnalyzeAsync(paintZone, _floorHotZone, options);
        }

        // 도장 중인 탱크에 유증기와 표식을 띄웁니다.
        private void ShowTankVapor(Data.BoundBox3D keel)
        {
            Data.Vector3D source = ScenarioScript.TankSeed;
            vizcore3dx.View.Effect.AddVapor(source, new Data.VaporOptions { Group = ScenarioScript.GroupHazard });
            vizcore3dx.View.Effect.AddMarker(new Data.Vector3D(source.X, source.Y, keel.MaxZ + 300f), Data.MarkerIcon.Gas,
                new Data.MarkerOptions { Label = "도장 중 · 유증기", SizePx = 40, Group = ScenarioScript.GroupHazard });
        }

        // 위 플로어의 용접 허가 요청을 강조합니다.
        private void ShowHotWorkRequest(Data.BoundBox3D hot)
        {
            Outline(_floorHotZone, ScenarioScript.ColorAccent, ScenarioScript.GroupHazard);
            vizcore3dx.View.Effect.AddMarker(new Data.Vector3D(hot.CenterX, hot.CenterY, hot.CenterZ + 300f), Data.MarkerIcon.Warning,
                new Data.MarkerOptions { Label = "용접 허가 요청", Group = ScenarioScript.GroupStatus });
        }

        // 화기 구역에서 아래 탱크까지의 거리를 치수선으로 보입니다.
        private void ShowTankGap(Data.Vector3D from, Data.Vector3D to, double gap)
        {
            vizcore3dx.View.Effect.AddDimensionLine(from, to, new Data.DimensionLineOptions { Color = ScenarioScript.HudColor, TextSizePx = 24, Group = ScenarioScript.GroupHazard });
            ShowHud(string.Format("바로 아래 {0:N0} mm 에 도장 중인 탱크", gap));
        }

        // 통로 분석 결과로 화기 허가를 판정해 보입니다 — 개구로 이어지면 보류, 벽에 막혀 있으면 가능.
        private void ShowPassageVerdict(Data.BoundBox3D hot, double gap, Data.ZoneAnalysisResult result, double seconds)
        {
            bool passage = result.HasPassage;
            ClearEffects(ScenarioScript.GroupStatus);
            vizcore3dx.View.Effect.AddMarker(new Data.Vector3D(hot.CenterX, hot.CenterY, hot.CenterZ + 300f), passage ? Data.MarkerIcon.Prohibition : Data.MarkerIcon.Check,
                new Data.MarkerOptions { Label = passage ? "화기 불가" : "허가 가능", BlinkIntervalMs = passage ? 350 : 0, SizePx = 64, Group = ScenarioScript.GroupStatus });
            vizcore3dx.View.Effect.AddTextLabel(new Data.Vector3D(hot.CenterX, hot.CenterY, hot.MinZ),
                passage ? string.Format("개구로 이어짐 · 통과 가능 구 {0:N0} mm", result.MaxSphereRadius) : "벽에 막힘 · 인접 아님",
                new Data.TextLabelOptions { BackColor = passage ? ScenarioScript.ColorHot : ScenarioScript.ColorSafe, Group = ScenarioScript.GroupStatus });
            ShowHud(string.Format("아래 {0:N0} mm · 통로 {1} · 분석 {2:0.0}초 → 화기 허가 {3}\n{4}",
                gap, passage ? "있음" : "없음", seconds, passage ? "보류" : "가능", ScenarioScript.AdjacentRuleText));
        }

        // 구역 a 에서 아래 방향으로 구역 b 까지의 거리와 그 두 점. 판정이 실패하면 두 상자의 높이 차로 대신합니다.
        private double DownwardGap(int a, int b, out Data.Vector3D from, out Data.Vector3D to)
        {
            Data.ZoneDirectionalContact contact;
            if (vizcore3dx.Zone.GetDirectionalContact(a, b, new Data.Vector3D(0f, 0f, -1f), out contact) && contact != null)
            {
                from = contact.MinPointA;
                to = contact.MinPointB;
                return contact.MinDistance;
            }

            Data.BoundBox3D boxA = vizcore3dx.Zone.GetBoundBox(a);
            Data.BoundBox3D boxB = vizcore3dx.Zone.GetBoundBox(b);
            float x = (Math.Max(boxA.MinX, boxB.MinX) + Math.Min(boxA.MaxX, boxB.MaxX)) * 0.5f;
            float y = (Math.Max(boxA.MinY, boxB.MinY) + Math.Min(boxA.MaxY, boxB.MaxY)) * 0.5f;
            from = new Data.Vector3D(x, y, boxA.MinZ);
            to = new Data.Vector3D(x, y, boxB.MaxZ);
            return boxA.MinZ - boxB.MaxZ;
        }

        // ---- 03 플랫폼 화기의 불티 ----

        // 화기 반경 안 = 화기 구역 경계에서 다른 구역 경계까지의 최소 거리가 반경 이하 (수평·수직 모두)
        private List<int> ZonesWithinHotWorkRadius()
        {
            List<int> within = new List<int>();
            foreach (int id in new[] { _keelZone, _floorHotZone, _funnelZone, _deckZone, _combustibleZone })
                if (vizcore3dx.Zone.GetMinDistance(_platformHotZone, id) <= ScenarioScript.HotWorkRadius) within.Add(id);
            return within;
        }

        // 화기 구역 안에 용접 불꽃을 차례로 띄웁니다. 씨앗을 고정해 불꽃 위치는 매번 같습니다.
        private void ScheduleWeldingSparks(Data.BoundBox3D hot)
        {
            Random random = new Random(7);
            for (int i = 0; i < 12; i++)
            {
                Data.Vector3D p = new Data.Vector3D(Lerp(hot.MinX, hot.MaxX, 0.2f + 0.6f * (float)random.NextDouble()),
                    Lerp(hot.MinY, hot.MaxY, 0.2f + 0.6f * (float)random.NextDouble()), hot.MinZ + 1000f + 800f * (float)random.NextDouble());
                _runner.After(2.5 + i * 0.25, () => vizcore3dx.View.Effect.AddWeldingSpark(p));
            }
        }

        // 화기 반경을 바닥 고리로 보이고, 반경 안에 든 작업·가연물 수를 알립니다.
        private void ShowHotWorkRadius(Data.BoundBox3D hot, int count)
        {
            vizcore3dx.View.Effect.AddGroundRing(new Data.Vector3D(hot.CenterX, hot.CenterY, hot.MinZ), new Data.GroundRingOptions
            { RadiusMm = ScenarioScript.HotWorkRadius, FloorZ = hot.MinZ, Color = ScenarioScript.ColorAccent, Group = ScenarioScript.GroupHazard });
            vizcore3dx.View.Effect.AddTextLabel(new Data.Vector3D(hot.CenterX, hot.CenterY + ScenarioScript.HotWorkRadius, hot.MinZ), ScenarioScript.HotWorkRadiusLabel,
                new Data.TextLabelOptions { BackColor = ScenarioScript.ColorNote, TextColor = ScenarioScript.ColorAccent, Group = ScenarioScript.GroupHazard });
            ShowHud(string.Format("화기 반경 11 m 안 다른 작업·가연물 {0}곳\n{1}", count, ScenarioScript.HotWorkRadiusSource));
        }

        // 그레이팅·개구로 아래층 바닥까지 불티가 떨어지는 경로를 보입니다(낙하 길이는 모델의 층 높이 차).
        private void ShowSparkPath(Data.Vector3D from, Data.Vector3D to)
        {
            vizcore3dx.View.Effect.AddPathLine(new List<Data.Vector3D> { from, to }, new Data.PathLineOptions { Color = ScenarioScript.ColorAccent, LineWidth = 5f, Group = ScenarioScript.GroupHazard });
            vizcore3dx.View.Effect.AddDimensionLine(from, to, new Data.DimensionLineOptions { Color = ScenarioScript.HudColor, TextSizePx = 24, Group = ScenarioScript.GroupHazard });
        }

        // 화재감시자 자리와 감시 조건을 보입니다.
        private void ShowFireWatch(Data.BoundBox3D hot)
        {
            vizcore3dx.View.Effect.AddMarker(new Data.Vector3D(hot.MaxX + 1500f, hot.MinY, hot.MinZ + 1800f), Data.MarkerIcon.Information,
                new Data.MarkerOptions { Label = ScenarioScript.FireWatchLabel, SizePx = 48, Group = ScenarioScript.GroupStatus });
            ShowHud(ScenarioScript.FireWatchText);
        }

        // ---- 04 밀폐 공간 출입 인원 ----

        // 작업자 아바타를 놓고, 위치마다 구역 안인지 판정합니다. 판정 결과를 위치 순서대로 돌려줍니다.
        private List<bool> PlaceKeelWorkers()
        {
            string preset = AvatarPreset();
            List<bool> inside = new List<bool>();
            foreach (Data.Vector3D p in ScenarioScript.KeelWorkers)
            {
                // 발은 경계인 바닥 판에 닿아 있으므로 몸 가운데 높이로 판정합니다.
                bool contained = vizcore3dx.Zone.ContainsPoint(_keelZone, new Data.Vector3D(p.X, p.Y, p.Z + ScenarioScript.WorkerBodyHeight));
                inside.Add(contained);
                if (preset != null) _workers.Add(vizcore3dx.Avatar.Place(preset, p, 90.0));
            }
            return inside;
        }

        // 탱크 옆에 가스 측정값을 띄웁니다.
        private void ShowGasReading(Data.BoundBox3D keel)
        {
            vizcore3dx.View.Effect.AddTextLabel(new Data.Vector3D(keel.MinX - 600f, keel.CenterY, keel.MaxZ + 400f), ScenarioScript.GasReadingLabel,
                new Data.TextLabelOptions { BackColor = ScenarioScript.ColorConfined, Group = ScenarioScript.GroupStatus });
            ShowHud(ScenarioScript.GasReadingText);
        }

        // 작업자마다 차례로 판정 라벨을 붙입니다. 구역 안 인원을 세어 가며 허가 인원을 넘는 사람은 명단 밖 출입자로 표시합니다.
        private void ScheduleHeadcountLabels(List<bool> inside)
        {
            int seen = 0;
            for (int i = 0; i < ScenarioScript.KeelWorkers.Length; i++)
            {
                int n = i;
                _runner.After(4.5 + i * 1.5, () =>
                {
                    if (inside[n]) seen++;
                    ShowHeadcountLabel(ScenarioScript.KeelWorkers[n], inside[n], seen);
                });
            }
        }

        private void ShowHeadcountLabel(Data.Vector3D p, bool inside, int seen)
        {
            bool extra = inside && seen > ScenarioScript.PermitHeadcount;
            string text = !inside ? "구역 밖" : extra ? "명단 밖 출입자" : "허가 명단 " + seen;
            Color color = !inside ? ScenarioScript.ColorNote : extra ? ScenarioScript.ColorHot : ScenarioScript.ColorConfined;
            // 탱크 가운데 위의 허가 이름 라벨과 겹치지 않게 옆으로 뺍니다.
            vizcore3dx.View.Effect.AddTextLabel(new Data.Vector3D(p.X, p.Y + 1500f, p.Z + 2000f), text, new Data.TextLabelOptions { BackColor = color, Group = ScenarioScript.GroupHazard });
        }

        // 허가 인원과 실제 인원을 대조한 결과를 보입니다. 다르면 표식을 깜박이고 구역을 강조합니다.
        private void ShowHeadcountVerdict(Data.BoundBox3D keel, int count)
        {
            bool mismatch = count != ScenarioScript.PermitHeadcount;
            vizcore3dx.View.Effect.AddMarker(new Data.Vector3D(keel.CenterX, keel.CenterY - 3000f, keel.MaxZ + 800f), mismatch ? Data.MarkerIcon.Warning : Data.MarkerIcon.Check,
                new Data.MarkerOptions { Label = string.Format("허가 {0} / 실제 {1}", ScenarioScript.PermitHeadcount, count), BlinkIntervalMs = mismatch ? 400 : 0, SizePx = 64, Group = ScenarioScript.GroupStatus });
            if (mismatch) Outline(_keelZone, ScenarioScript.ColorAccent, ScenarioScript.GroupStatus);
            ShowHud(string.Format("이중저 탱크 허가 {0}명 · 위치로 센 구역 안 인원 {1}명{2}", ScenarioScript.PermitHeadcount, count, mismatch ? " → 명단 밖 출입자, 출입 통제" : ""));
        }

        // 아바타 프리셋 — 라이브러리에 작업자 프리셋이 있으면 그것을, 없으면 내장 작업자 모델을 꺼내 씁니다.
        private string AvatarPreset()
        {
            List<Data.AvatarPresetItem> presets = vizcore3dx.Avatar.Presets;
            if (presets != null && presets.Count > 0)
            {
                foreach (Data.AvatarPresetItem item in presets)
                    if (item.Name.StartsWith("Worker")) return item.Name;
                return presets[0].Name;
            }

            List<string> imported = vizcore3dx.Avatar.ImportBuiltInModels();
            return imported != null && imported.Count > 0 ? imported[0] : null;
        }

        // 이 시나리오가 놓은 아바타를 지웁니다.
        private void RemoveWorkers()
        {
            if (_workers.Count > 0) vizcore3dx.Avatar.Remove(_workers);
            _workers.Clear();
        }

        // ---- 05 낙하물과 정지 허가 ----

        // 낙하물 통제 구역과 그 반경을 보입니다.
        private void ShowDropZone(Data.BoundBox3D drop, float height, float radius)
        {
            vizcore3dx.Zone.SetVisible(_dropZone, true);
            vizcore3dx.View.Effect.AddTextLabel(new Data.Vector3D(drop.MaxX, drop.MinY, drop.MaxZ - 2000f),
                string.Format("낙하물 통제 반경 {0:0.0} m", radius / 1000f),
                new Data.TextLabelOptions { BackColor = ScenarioScript.ColorNote, TextColor = ScenarioScript.ColorAccent, Group = ScenarioScript.GroupHazard });
            ShowHud(string.Format("낙하 높이 {0:0.0} m → 아래 통제 반경 {1:0.0} m\n{2}", height / 1000f, radius / 1000f, ScenarioScript.DropRuleText));
        }

        // 통제 구역이 정지된 허가와 겹치면 그 허가를 강조합니다.
        private void ShowDropOverlap(bool overlap)
        {
            if (!overlap) { ShowHud("낙하물 통제 구역과 겹치는 허가 없음"); return; }
            vizcore3dx.View.Effect.AddPulseOutline(Grow(ScenarioScript.ZoneDeck), PulseOptions(ScenarioScript.ColorAccent, ScenarioScript.GroupHazard));
            vizcore3dx.View.Effect.AddMarker(Above(ScenarioScript.ZoneDeck), Data.MarkerIcon.Prohibition,
                new Data.MarkerOptions { Label = "정지 허가와 겹침", BlinkIntervalMs = 350, SizePx = 56, Group = ScenarioScript.GroupHazard });
            ShowHud("통제 구역이 정지된 P5 와 겹침 → 재개 전에 교차 확인\n정지 허가도 판정에 포함합니다 (HSE HSG250)");
        }

        // ---- 06 화재 · 전원 대피 ----

        // 화재 자리에 표식과 연기·불티를 띄웁니다.
        private void ShowFire(Data.BoundBox3D fire)
        {
            vizcore3dx.View.Effect.AddMarker(Above(fire), Data.MarkerIcon.Fire,
                new Data.MarkerOptions { Label = "화재", BlinkIntervalMs = 250, SizePx = 64, ShowOffscreenIndicator = true, Group = ScenarioScript.GroupFire });
            Data.Vector3D seat = new Data.Vector3D(fire.CenterX, fire.CenterY, fire.MinZ + 500f);
            vizcore3dx.View.Effect.AddParticleEmitter(seat, new Data.ParticleOptions(Data.ParticlePreset.Smoke) { Group = ScenarioScript.GroupFire });
            vizcore3dx.View.Effect.AddParticleEmitter(seat, new Data.ParticleOptions(Data.ParticlePreset.Sparks) { Group = ScenarioScript.GroupFire });
        }

        // 충돌 보행으로 경로를 구할 구간 — 무리 가운데 → 길목 입구, 그리고 길목 사이 통로
        private static List<KeyValuePair<Data.Vector3D, Data.Vector3D>> EvacuationLegs(EvacuationSim evacuation)
        {
            List<KeyValuePair<Data.Vector3D, Data.Vector3D>> legs = new List<KeyValuePair<Data.Vector3D, Data.Vector3D>>();
            foreach (Data.Vector3D center in ScenarioScript.FloorGroups) AddLeg(legs, center, evacuation.EntryFor(center));
            foreach (Data.Vector3D center in ScenarioScript.PlatformGroups) AddLeg(legs, center, evacuation.EntryFor(center));
            legs.AddRange(evacuation.WalkLinks());
            return legs;
        }

        // 구간마다 경로용 아바타 하나를 시작점에 옮겨 충돌 보행을 해 보고, 목표 가까이 닿은 경로만 남깁니다.
        // 그사이 처음으로 되돌렸으면 null 을 돌려줍니다.
        private async Task<Dictionary<string, List<Data.Vector3D>>> TraceLegsAsync(EvacuationSim evacuation, string preset, List<KeyValuePair<Data.Vector3D, Data.Vector3D>> legs)
        {
            ShowHud("충돌 보행으로 대피 경로 계산 중");
            Dictionary<string, List<Data.Vector3D>> traced = new Dictionary<string, List<Data.Vector3D>>();
            int tracer = vizcore3dx.Avatar.Place(preset, legs.Count > 0 ? legs[0].Key : ScenarioScript.NodeMuster, 0.0);
            foreach (KeyValuePair<Data.Vector3D, Data.Vector3D> leg in legs)
            {
                vizcore3dx.Avatar.SetPosition(tracer, leg.Key);
                List<Data.Vector3D> path = await vizcore3dx.Avatar.TraceWalkAsync(tracer, new List<Data.Vector3D> { leg.Value }, ScenarioScript.TraceStep);

                if (_evacuation != evacuation) { vizcore3dx.Avatar.Remove(tracer); return null; }
                if (path.Count < 2) continue;

                Data.Vector3D end = path[path.Count - 1];
                if (Math.Sqrt((end.X - leg.Value.X) * (end.X - leg.Value.X) + (end.Y - leg.Value.Y) * (end.Y - leg.Value.Y)) > ScenarioScript.TraceReach) continue;
                path.Add(leg.Value);
                traced[LegKey(leg.Key, leg.Value)] = path;
            }
            vizcore3dx.Avatar.Remove(tracer);
            return traced;
        }

        private static void AddLeg(List<KeyValuePair<Data.Vector3D, Data.Vector3D>> legs, Data.Vector3D from, Data.Vector3D to)
        {
            if (to != null) legs.Add(new KeyValuePair<Data.Vector3D, Data.Vector3D>(from, to));
        }

        private static string LegKey(Data.Vector3D from, Data.Vector3D to)
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0},{1:0},{2:0}>{3:0},{4:0},{5:0}", from.X, from.Y, from.Z, to.X, to.Y, to.Z);
        }

        // 걷는 구간의 꺾은선 — 길목 사이 통로는 그대로, 무리 안의 사람은 자기 자리에서 무리 가운데의 경로에 합류합니다. 없으면 null(직선).
        private static List<Data.Vector3D> TracedPath(Dictionary<string, List<Data.Vector3D>> traced, Data.Vector3D from, Data.Vector3D to)
        {
            List<Data.Vector3D> path;
            if (traced.TryGetValue(LegKey(from, to), out path)) return new List<Data.Vector3D>(path);

            foreach (Data.Vector3D center in ScenarioScript.FloorGroups.Concat(ScenarioScript.PlatformGroups))
            {
                if (Math.Abs(center.Z - from.Z) > 1f || (center.X - from.X) * (center.X - from.X) + (center.Y - from.Y) * (center.Y - from.Y) > ScenarioScript.GroupSpread * ScenarioScript.GroupSpread * 1.01f) continue;
                if (!traced.TryGetValue(LegKey(center, to), out path)) return null;

                List<Data.Vector3D> joined = new List<Data.Vector3D> { from };
                joined.AddRange(path);
                return joined;
            }
            return null;
        }

        // 집결지 판정 구역을 만듭니다. 면은 그리지 않고 경계선만 남깁니다.
        private void AddMusterZone()
        {
            Data.Vector3D muster = ScenarioScript.NodeMuster;
            float r = ScenarioScript.MusterRadius;
            _musterZone = AddZone(new Data.BoundBox3D(muster.X - r, muster.Y - r, muster.Z - 100f, muster.X + r, muster.Y + r, muster.Z + 2500f), "집결지", ScenarioScript.ColorEvacuation);
            vizcore3dx.Zone.SetFaceOpacity(_musterZone, 0);
        }

        // 사람을 무리 가운데 둘레에 흩어 놓고, 집결지의 자기 자리까지 경로를 정합니다. 씨앗을 고정해 매번 같은 배치입니다.
        private void PlaceEvacuees(EvacuationSim evacuation, string preset, Dictionary<string, List<Data.Vector3D>> traced)
        {
            Data.Vector3D muster = ScenarioScript.NodeMuster;
            Random random = new Random(11);
            int total = ScenarioScript.EvacueesOnFloor + ScenarioScript.EvacueesOnPlatform;
            Func<Data.Vector3D, Data.Vector3D, List<Data.Vector3D>> walkPath = (from, to) => TracedPath(traced, from, to);
            for (int i = 0; i < total; i++)
            {
                Data.Vector3D[] groups = i < ScenarioScript.EvacueesOnFloor ? ScenarioScript.FloorGroups : ScenarioScript.PlatformGroups;
                Data.Vector3D center = groups[i % groups.Length];
                double angle = random.NextDouble() * Math.PI * 2.0, spread = Math.Sqrt(random.NextDouble()) * ScenarioScript.GroupSpread;
                Data.Vector3D p = new Data.Vector3D(center.X + (float)(Math.Cos(angle) * spread), center.Y + (float)(Math.Sin(angle) * spread), center.Z);
                int id = vizcore3dx.Avatar.Place(preset, p, random.NextDouble() * 360.0);
                if (id == 0) continue;
                _workers.Add(id);

                Data.Vector3D slot = new Data.Vector3D(muster.X + (i % 12 - 5.5f) * ScenarioScript.MusterSpacing, muster.Y + (i / 12 - 4.5f) * ScenarioScript.MusterSpacing, muster.Z);
                if (!evacuation.AddAgent(id, p, random, slot, walkPath)) vizcore3dx.Avatar.Remove(id);
            }
        }

        // 막힌 길목·열린 길목·충돌 보행 경로와 집결지 둘레를 그립니다.
        private void ShowEvacuationRoutes(EvacuationSim evacuation, Dictionary<string, List<Data.Vector3D>> traced)
        {
            Data.Vector3D muster = ScenarioScript.NodeMuster;
            foreach (KeyValuePair<string, Data.Vector3D> link in evacuation.BlockedLinks())
                vizcore3dx.View.Effect.AddMarker(link.Value, Data.MarkerIcon.Prohibition,
                    new Data.MarkerOptions { Label = link.Key + " 막힘", BlinkIntervalMs = 350, Group = ScenarioScript.GroupFire });
            foreach (List<Data.Vector3D> route in evacuation.OpenRoutes())
                vizcore3dx.View.Effect.AddPathLine(route, new Data.PathLineOptions { Color = ScenarioScript.ColorEvacuation, LineWidth = 5f, Group = ScenarioScript.GroupFire });
            foreach (List<Data.Vector3D> path in traced.Values)
                vizcore3dx.View.Effect.AddPathLine(path, new Data.PathLineOptions { Color = ScenarioScript.ColorSafe, LineWidth = 3f, Group = ScenarioScript.GroupFire });
            vizcore3dx.View.Effect.AddGroundRing(muster, new Data.GroundRingOptions { RadiusMm = ScenarioScript.MusterRadius, FloorZ = muster.Z, Color = ScenarioScript.ColorEvacuation, Group = ScenarioScript.GroupFire });
        }

        // 대피 시뮬레이션을 시작하고, 사람들이 계단을 올라가는 기둥으로 다가갑니다.
        // 옆 구도에서는 갑판을 되살리고 우현 쪽만 단면으로 잘라 종단면으로 봅니다.
        private void StartEvacuation(EvacuationSim evacuation)
        {
            if (_evacuation != evacuation) return;
            _evacuationWatch = Stopwatch.StartNew();
            _evacuationTimer.Start();
            SetCutaway(true, true, ScenarioScript.CutawayGroupsSection, true);
            FlyToBox(ScenarioScript.ClimbBox, ScenarioScript.ViewClimb, 3.0);
        }

        // 계단을 오르는 동안 가까이 다가갔다가(아래 두 단 → 위 두 단) 다시 물러납니다 — 멀리서만 보면 사람이 걷는지 잘 안 보입니다.
        private void ScheduleClimbShots(EvacuationSim evacuation)
        {
            foreach (KeyValuePair<double, Data.BoundBox3D> shot in ScenarioScript.ClimbShots)
            {
                Data.BoundBox3D box = shot.Value;
                _runner.After(shot.Key, () =>
                {
                    if (_evacuation != evacuation || evacuation.IsFinished) return;
                    FlyToBox(box, ScenarioScript.ViewClimb, ScenarioScript.ClimbShotSeconds);
                });
            }
        }

        // 사람마다 다음 위치로 보간 이동시키고, 집결지에 들어온 사람 수를 돌려줍니다.
        private int MoveEvacuees()
        {
            List<Data.AvatarUpdate> updates = new List<Data.AvatarUpdate>();
            int arrived = 0;
            foreach (EvacuationSim.Agent agent in _evacuation.Agents)
            {
                updates.Add(new Data.AvatarUpdate { ID = agent.AvatarID, Position = agent.Position, HeadingDegrees = agent.Heading, DurationMs = ScenarioScript.EvacuationTickMs });
                if (vizcore3dx.Zone.ContainsPoint(_musterZone, agent.Position)) arrived++;
            }
            vizcore3dx.Avatar.UpdateMany(updates);
            return arrived;
        }

        // 혼잡 — 길목마다 줄 선 사람 수를 1초마다 갱신해 보입니다.
        private void ShowQueues()
        {
            if (_evacuationWatch.ElapsedMilliseconds - _crowdShownMs < 1000) return;

            _crowdShownMs = _evacuationWatch.ElapsedMilliseconds;
            ClearEffects(ScenarioScript.GroupCrowd);
            foreach (KeyValuePair<Data.Vector3D, int> queue in _evacuation.Queues())
                if (queue.Value >= 3)
                    vizcore3dx.View.Effect.AddTextLabel(new Data.Vector3D(queue.Key.X, queue.Key.Y, queue.Key.Z + 2200f), string.Format("대기 {0}명", queue.Value),
                        new Data.TextLabelOptions { BackColor = ScenarioScript.ColorHeight, Group = ScenarioScript.GroupCrowd });
        }

        // 전원이 집결하면 타이머를 멈추고 총 집결 시간을 알린 뒤 집결지까지 물러납니다.
        private void FinishEvacuation(int arrived, int count)
        {
            _evacuationTimer.Stop();
            ClearEffects(ScenarioScript.GroupCrowd);
            ShowHud(string.Format("전원 집결 {0}/{1} · 총 집결 시간 {2:0} s (실제 시간)\n(규정 판정은 500회 반복의 95번째 백분위 — IMO MSC.1/Circ.1533)", arrived, count, _evacuation.Time));
            ClearSpeedHud();
            // 위에서 내려다보는 구도라 단면을 끄고 처음처럼 바깥 껍데기를 걷어 냅니다.
            SetCutaway(true, true);
            FlyToEvacuationOverview();
        }

        private void StopEvacuation()
        {
            _evacuationTimer.Stop();
            _evacuation = null;
            _crowdShownMs = 0;
        }

        // ---- 실내 보기 ----

        // 실내 보기 — 켜면 X-Ray 를 끄고 바깥 껍데기 그룹(값 표)을 숨기고, 끄면 숨긴 노드를 되살려 모델을 원래대로 보입니다(X-Ray 로 돌아가지 않음).
        // 01 장면 뒤로는 X-Ray 대신 실제 형상으로 보여 줍니다. 구역의 반투명 면은 그 안·뒤의 아바타를 가리므로 아바타 장면에서는 faceOff 로 경계선만 남깁니다.
        // groups 는 숨길 그룹(없으면 값 표의 CutawayGroups 전부)이고, section 이면 우현 쪽을 상자 단면으로 잘라 냅니다.
        // 단면은 부를 때마다 먼저 지우므로 section 없이 부르면 단면이 꺼집니다.
        private void SetCutaway(bool on, bool faceOff = false, string[] groups = null, bool section = false)
        {
            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.View.XRay.Clear();
                vizcore3dx.View.XRay.Enable = false;
                foreach (int id in _zones)
                    vizcore3dx.Zone.SetFaceOpacity(id, faceOff ? 0 : id == _deckZone ? ScenarioScript.SuspendedOpacity : ScenarioScript.ZoneOpacity);

                RemoveSection();
                if (on)
                {
                    HideCutawayGroups(groups ?? ScenarioScript.CutawayGroups);
                    if (section) AddCutawaySection();
                }
                else
                {
                    if (_hidden.Count > 0) vizcore3dx.Object3D.Show(_hidden, true);
                    _hidden.Clear();
                    RestoreFloorColor();
                }
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        // 모델 루트 바로 아래의 바깥 껍데기 그룹(ScenarioScript.CutawayGroups) 가운데 names 에 든 것은 숨기고,
        // 앞 장면이 숨겼지만 names 에 없는 것은 되살립니다.
        private void HideCutawayGroups(string[] names)
        {
            List<Data.Node> roots = vizcore3dx.Object3D.FromFilter(Data.Object3dFilter.ROOT);
            List<Data.Node> hide = new List<Data.Node>(), show = new List<Data.Node>();
            if (roots != null && roots.Count > 0)
                foreach (Data.Node node in roots[0].GetChildObject3d(Data.Object3DChildOption.CHILD_ONLY))
                {
                    if (Array.IndexOf(names, node.NodeName) >= 0) hide.Add(node);
                    else if (Array.IndexOf(ScenarioScript.CutawayGroups, node.NodeName) >= 0) show.Add(node);
                }
            if (show.Count > 0) vizcore3dx.Object3D.Show(show, true);
            if (hide.Count > 0) vizcore3dx.Object3D.Show(hide, false);
            _hidden.AddRange(hide);
        }

        // 우현 쪽을 상자 단면으로 잘라 냅니다. 단면 상자 자체는 화면에 보이지 않게 하고 잘린 모양만 남깁니다.
        private void AddCutawaySection()
        {
            _section = vizcore3dx.Section.AddBox(ScenarioScript.CutawaySection);
            vizcore3dx.Section.ShowAll(false);
        }

        // 모델을 원래 모습으로 — X-Ray·숨김·단면·바닥 판 색을 모두 되돌립니다.
        private void RestoreModelView()
        {
            RestoreXRay();
            vizcore3dx.Object3D.Show(Data.Object3DKind.ALL, true);
            RemoveSection();
            RestoreFloorColor();
        }

        // 이 시나리오가 켠 단면을 지웁니다.
        private void RemoveSection()
        {
            if (_section != null) vizcore3dx.Section.Delete(_section);
            _section = null;
        }

        // 탱크 위(이중저 윗면 ~ 플로어 작업 높이)를 숨겨 안을 들여다볼 창을 내고, 외판 그룹과 함께 숨은 탱크 바닥(선저 외판)은 되살립니다.
        // 바닥이 없으면 작업자가 허공에 뜬 것처럼 보이기 때문입니다.
        private void OpenTankWindow(Data.BoundBox3D tank)
        {
            HideInBox(new Data.BoundBox3D(tank.MinX, tank.MinY, tank.MaxZ - 100f, tank.MaxX, tank.MaxY, ScenarioScript.ZoneFloorHot.MaxZ));
            // 바닥 판을 되살리고 밝게 칠합니다 — 원래 색이 배경과 같은 남색이라 그대로는 바닥이 없어 보입니다.
            if (_tankFloor.Count == 0) return;
            vizcore3dx.Object3D.Show(_tankFloor, true);
            // 칠하기 전 색을 기억해 둡니다 — 모델의 색이 파일에 저장된 지정 색이면 RestoreColor 는 그 색까지 지워
            // 판이 원래 보이던 색이 아닌 색으로 바뀝니다.
            foreach (Data.Node node in _tankFloor)
            {
                if (_recolored.Contains(node)) continue;
                _recolored.Add(node);
                _recoloredColors.Add(vizcore3dx.Object3D.Color.GetColor(node));
            }
            vizcore3dx.Object3D.Color.SetColor(_tankFloor, ScenarioScript.ColorTankFloor);
        }

        // 상자에 걸치는 파트를 숨깁니다(들여다볼 창). 판정용 공간을 잠시 만들었다가 지웁니다.
        private void HideInBox(Data.BoundBox3D box)
        {
            int zone = vizcore3dx.Zone.CreateZoneFromBoundBox(box, "window", 0f);
            if (zone < 0) return;

            List<Data.Node> parts = vizcore3dx.Zone.GetNodesInZone(zone, Data.BoundBoxSearchOption.IncludingPart, true, true);
            vizcore3dx.Zone.Delete(new List<int> { zone });
            if (parts == null || parts.Count == 0) return;

            vizcore3dx.Object3D.Show(parts, false);
            _hidden.AddRange(parts);
        }

        // 탱크 범위에 걸친 바닥 판(선저·빌지 외판)을 찾습니다. 옆 외판처럼 위로 높이 솟은 판과 탱크를 덮는 이중저 윗면은 시야를 가리므로 뺍니다.
        private List<Data.Node> FindFloorIn(Data.BoundBox3D box)
        {
            List<Data.Node> floor = new List<Data.Node>();
            int zone = vizcore3dx.Zone.CreateZoneFromBoundBox(box, "floor", 0f);
            if (zone < 0) return floor;

            List<Data.Node> parts = vizcore3dx.Zone.GetNodesInZone(zone, Data.BoundBoxSearchOption.IncludingPart, false, true);
            vizcore3dx.Zone.Delete(new List<int> { zone });
            if (parts == null) return floor;

            foreach (Data.Node part in parts)
            {
                Data.BoundBox3D b = part.GetBoundBox();
                // 누운 판(바닥)만 — 세워진 늑판·거더는 되살리면 안의 작업자를 가립니다.
                if (b != null && b.MaxZ <= box.MaxZ + 500f && b.MinZ < box.MaxZ - 300f && Math.Min(b.LengthX, b.LengthY) > 500f) floor.Add(part);
            }
            return floor;
        }

        // 밝게 칠한 탱크 바닥 판을 칠하기 전의 색으로 다시 칠합니다.
        private void RestoreFloorColor()
        {
            for (int i = 0; i < _recolored.Count; i++)
                vizcore3dx.Object3D.Color.SetColor(new List<Data.Node> { _recolored[i] }, _recoloredColors[i]);
            _recolored.Clear();
            _recoloredColors.Clear();
        }

        // ---- 계단 형상 ----

        // 대피 장면에서 사람이 밟을 곳을 형상으로 그립니다 — 계단 탑(디딤판·계단참), 좌현 경사 사다리의 디딤판, 상갑판 통로 판.
        // 모델의 계단은 프레임뿐이고 실내 장면에서는 상갑판을 숨기므로, 그대로 두면 허공을 걷는 것처럼 보입니다.
        // 불투명 형상이라 깊이 판정을 켜서 앞뒤가 바르게 가려지게 합니다.
        private void DrawStairs(EvacuationSim evacuation)
        {
            List<Data.ShapeItem> shapes = new List<Data.ShapeItem>();
            AddStairTower(shapes);

            // 좌현 경사 사다리 (플로어 → 플랫폼)
            Data.Vector3D low = ScenarioScript.NodeFloorPortLadder, high = ScenarioScript.NodePlatformPortLadder;
            float ladderHalf = ScenarioScript.LadderLaneWidth / 2f;
            AddShape(shapes, StepsMesh(low.X, high.X, low.Y - ladderHalf, low.Y + ladderHalf, low.Z, high.Z, ScenarioScript.LadderSteps), ScenarioScript.ColorStair);

            // 상갑판 통로 판 (계단 출구 → 집결지)
            KeyValuePair<Data.Vector3D, Data.Vector3D> walk = evacuation.ExitWalk();
            MeshData walkway = new MeshData();
            walkway.AddStrip(walk.Key, walk.Value, ScenarioScript.WalkwayWidth / 2f, 60f);
            AddShape(shapes, walkway, ScenarioScript.ColorWalkway);

            if (shapes.Count > 0) vizcore3dx.Shape.DepthTestEnable(true, shapes);
        }

        // 계단 탑 — 단마다 디딤판 줄과 위쪽 끝의 계단참을 그립니다. 홀수 단은 A 줄에서 X0 → X1, 짝수 단은 B 줄에서 X1 → X0 로 되꺾어 오릅니다.
        private void AddStairTower(List<Data.ShapeItem> shapes)
        {
            float[] levels = ScenarioScript.StairLevels;
            float half = ScenarioScript.StairLaneWidth / 2f;
            float x0 = ScenarioScript.StairX0, x1 = ScenarioScript.StairX1, depth = ScenarioScript.LandingDepth;
            float y0 = ScenarioScript.StairLaneA - half, y1 = ScenarioScript.StairLaneB + half;

            for (int i = 1; i < levels.Length; i++)
            {
                bool forward = i % 2 == 1;
                float lane = forward ? ScenarioScript.StairLaneA : ScenarioScript.StairLaneB;
                AddShape(shapes, StepsMesh(forward ? x0 : x1, forward ? x1 : x0, lane - half, lane + half, levels[i - 1], levels[i], ScenarioScript.StairSteps), ScenarioScript.ColorStair);

                // 단 위쪽 끝의 계단참
                MeshData landing = new MeshData();
                landing.AddBox(forward ? x1 : x0 - depth, y0, levels[i] - 60f, forward ? x1 + depth : x0, y1, levels[i]);
                AddShape(shapes, landing, ScenarioScript.ColorStair);
            }
        }

        private void AddShape(List<Data.ShapeItem> shapes, MeshData mesh, Color color)
        {
            Data.ShapeItem.MeshShape shape = vizcore3dx.Shape.CreateMeshShape(mesh.Vertices, mesh.Indices, color);
            if (shape == null) return;

            shape.Category = ScenarioScript.StairCategory;
            shapes.Add(shape);
        }

        // 디딤판 줄 — fromX 에서 toX 로 가며 lowZ 에서 highZ 까지 steps 단을 오릅니다. 단마다 상자 하나.
        private static MeshData StepsMesh(float fromX, float toX, float minY, float maxY, float lowZ, float highZ, int steps)
        {
            MeshData mesh = new MeshData();
            float run = (toX - fromX) / steps, rise = (highZ - lowZ) / steps;
            for (int i = 0; i < steps; i++)
            {
                float a = fromX + run * i, b = fromX + run * (i + 1);
                mesh.AddBox(Math.Min(a, b), minY, lowZ + rise * i - 80f, Math.Max(a, b), maxY, lowZ + rise * (i + 1));
            }
            return mesh;
        }

        // 형상 하나의 정점·삼각형 목록 (상자들을 이어 붙임)
        private class MeshData
        {
            public readonly List<Data.Vertex3D> Vertices = new List<Data.Vertex3D>();
            public readonly List<int> Indices = new List<int>();

            // 축에 나란한 상자
            public void AddBox(float minX, float minY, float minZ, float maxX, float maxY, float maxZ)
            {
                AddPrism(new Data.Vector3D(minX, minY, 0f), new Data.Vector3D(maxX, minY, 0f), new Data.Vector3D(maxX, maxY, 0f), new Data.Vector3D(minX, maxY, 0f), minZ, maxZ);
            }

            // from → to 를 따라 놓인 판 (윗면이 두 점의 높이, 두께 thickness)
            public void AddStrip(Data.Vector3D from, Data.Vector3D to, float halfWidth, float thickness)
            {
                float dx = to.X - from.X, dy = to.Y - from.Y;
                float length = (float)Math.Sqrt(dx * dx + dy * dy);
                if (length < 1f) return;

                float nx = -dy / length * halfWidth, ny = dx / length * halfWidth;   // 진행 방향의 왼쪽
                AddPrism(new Data.Vector3D(from.X - nx, from.Y - ny, 0f), new Data.Vector3D(to.X - nx, to.Y - ny, 0f),
                    new Data.Vector3D(to.X + nx, to.Y + ny, 0f), new Data.Vector3D(from.X + nx, from.Y + ny, 0f), from.Z - thickness, from.Z);
            }

            // 위에서 봐 반시계 방향인 네 모서리를 minZ~maxZ 로 세운 기둥. 면은 바깥을 향합니다.
            private void AddPrism(Data.Vector3D p0, Data.Vector3D p1, Data.Vector3D p2, Data.Vector3D p3, float minZ, float maxZ)
            {
                int n = Vertices.Count;
                foreach (float z in new[] { minZ, maxZ })
                    foreach (Data.Vector3D p in new[] { p0, p1, p2, p3 })
                        Vertices.Add(new Data.Vertex3D(p.X, p.Y, z));

                Indices.AddRange(new[]
                {
                    n, n + 2, n + 1,  n, n + 3, n + 2,                  // 아래
                    n + 4, n + 5, n + 6,  n + 4, n + 6, n + 7,          // 위
                    n, n + 1, n + 5,  n, n + 5, n + 4,                  // 옆 (p0-p1)
                    n + 3, n + 7, n + 6,  n + 3, n + 6, n + 2,          // 옆 (p3-p2)
                    n, n + 4, n + 7,  n, n + 7, n + 3,                  // 옆 (p0-p3)
                    n + 1, n + 2, n + 6,  n + 1, n + 6, n + 5,          // 옆 (p1-p2)
                });
            }
        }

        // ---- 강조 표시 ----

        // 구역을 반짝이는 외곽선으로 강조합니다 — 다면체 구역은 실제 모서리를 따라, 상자 구역은 상자로.
        private void Outline(int id, Color color, string group)
        {
            if (id < 0) return;

            List<Data.Vector3D> edges;
            if (_zoneEdges.TryGetValue(id, out edges) && edges.Count > 0) vizcore3dx.View.Effect.AddPulseOutline(edges, PulseOptions(color, group));
            else vizcore3dx.View.Effect.AddPulseOutline(Grow(vizcore3dx.Zone.GetBoundBox(id)), PulseOptions(color, group));
        }

        private static Data.PulseOutlineOptions PulseOptions(Color color, string group)
        {
            // 기본값은 선체에 가려지므로 항상 위에 그립니다. 선 굵기는 3 이 적당합니다(굵게 하면 번짐이 잘림).
            return new Data.PulseOutlineOptions { Color = color, PeriodMs = 700, LineWidth = 3f, AlwaysOnTop = true, Group = group };
        }

        // 펄스 외곽선이 공간 경계선과 겹치지 않게 상자를 조금 키웁니다.
        private static Data.BoundBox3D Grow(Data.BoundBox3D box)
        {
            float m = Math.Min(Math.Max(box.MaxLength * 0.005f, 50f), 200f);
            return new Data.BoundBox3D(box.MinX - m, box.MinY - m, box.MinZ - m, box.MaxX + m, box.MaxY + m, box.MaxZ + m);
        }

        // 상자 꼭대기 조금 위 (표식 자리)
        private static Data.Vector3D Above(Data.BoundBox3D box)
        {
            return new Data.Vector3D(box.CenterX, box.CenterY, box.MaxZ + 500f);
        }

        private static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }

        #endregion

        #region 카메라

        // box 가 화면에 다 들어오도록 direction 방향에서 seconds 초 동안 이동합니다.
        private void FlyToBox(Data.BoundBox3D box, Data.Vector3D direction, double seconds)
        {
            FlyCamera(new Data.Vector3D(box.GetCenter()), direction, FitDistance(box.MaxLength), seconds);
        }

        // 두 상자가 함께 화면에 들어오도록 direction 방향에서 seconds 초 동안 이동합니다.
        private void FlyToBoxes(Data.BoundBox3D first, Data.BoundBox3D second, Data.Vector3D direction, double seconds)
        {
            Data.BoundBox3D view = new Data.BoundBox3D(first.GetVertexMin(), first.GetVertexMax());
            view.AddBox(second);
            FlyToBox(view, direction, seconds);
        }

        // 화재 구역부터 집결지까지 대피 범위 전체가 보이도록 물러납니다.
        private void FlyToEvacuationOverview()
        {
            Data.Vector3D muster = ScenarioScript.NodeMuster;
            float r = ScenarioScript.MusterRadius;
            Data.BoundBox3D view = new Data.BoundBox3D(10000f, -10000f, 5520f, 30000f, 10000f, 14500f);
            view.AddBox(new Data.BoundBox3D(muster.X - r, muster.Y - r, muster.Z, muster.X + r, muster.Y + r, muster.Z + 2500f));
            FlyToBox(view, ScenarioScript.ViewEvacuation, 2.5);
        }

        // 크기 size 인 대상이 화면에 다 들어오는 카메라 거리를 시야각에서 구합니다.
        private float FitDistance(float size)
        {
            double fov = vizcore3dx.View.FOV;
            if (fov < 1.0 || fov > 120.0) fov = 30.0;

            return (float)(size * 0.5 / Math.Tan(fov * Math.PI / 360.0) * ScenarioScript.FitMargin);
        }

        // target 을 direction 방향으로 distance 만큼 떨어져 바라보도록 seconds 초 동안 이동합니다.
        // 위 방향은 Z 입니다. direction 이 정확히 수직이면 안 됩니다.
        private void FlyCamera(Data.Vector3D target, Data.Vector3D direction, float distance, double seconds)
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
            camera.UpDirection = new Data.Vector3D(0f, 0f, 1f).ToVertex3D();
            vizcore3dx.View.SetCameraData(camera, TimeSpan.FromSeconds(seconds));
        }

        // 지금 보는 지점을 중심으로 수직축 둘레를 degrees 도만큼 seconds 초 동안 돕니다.
        private void Orbit(float degrees, double seconds)
        {
            vizcore3dx.View.OrbitCamera(new Data.Vector3D(0f, 0f, 1f), degrees, TimeSpan.FromSeconds(Math.Max(seconds, 1.0)));
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

        // 상태 문구를 창 제목줄에 적습니다.
        private void SetStatus(string text)
        {
            Text = "VIZCore3DX.NET.Scenario.WorkPermit — " + text;
        }

        // 3D 뷰 왼쪽 위에 문구 하나를 띄웁니다. 이전 문구는 지웁니다.
        private void ShowHud(string text)
        {
            if (_hud != null) vizcore3dx.View.Message.Delete(_hud);
            _hud = vizcore3dx.View.Message.Create(text, ScenarioScript.HudPosition, ScenarioScript.HudColor, Data.TextSizeType.Size_24, true, true);
        }

        // 3D 뷰 왼쪽 위 문구를 지웁니다. 빠른 재생 표시도 함께 지웁니다.
        private void ClearHud()
        {
            if (_hud != null) vizcore3dx.View.Message.Delete(_hud);
            _hud = null;
            ClearSpeedHud();
        }

        // 안내 문구 아래에 빠른 재생 표시를 크게 띄웁니다.
        private void ShowSpeedHud(string text)
        {
            if (_speedHud != null) vizcore3dx.View.Message.Delete(_speedHud);
            _speedHud = vizcore3dx.View.Message.Create(text, ScenarioScript.SpeedHudPosition, ScenarioScript.ColorAccent, Data.TextSizeType.Size_24, true, true);
        }

        private void ClearSpeedHud()
        {
            if (_speedHud != null) vizcore3dx.View.Message.Delete(_speedHud);
            _speedHud = null;
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
