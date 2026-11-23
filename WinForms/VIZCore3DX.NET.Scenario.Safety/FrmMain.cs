using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Scenario.Safety
{
    // 시나리오 예제 "현장 안전 — 비상 대피 · 화기 작업 허가 · 낙하물·추락"
    // 1부: 작업 중 폭염 이상 징후 → 가스 누출 → 대피 / 2부: 화기 작업 구역 지정 → 허가자 입장 → 무허가 출입·퇴거 → 용접 불티 화재 → 초기 진화 → 작업 종료 / 3부: 낙하물 → 추락.
    // 집결지와 작업 구역은 Zone 으로 만들고, 사람이 드나드는 것은 Zone 이 알려 줍니다(Zone.OnZoneContentChangedEvent).
    // 카메라는 장면이 바뀔 때 구도를 옮기고, 사람이 걷는 장면에서는 그 사람들을 따라갑니다(방위·거리는 마우스로 조절).
    // 장면의 값(설명·길이·좌표·색)은 ScenarioScript.cs 한 곳에, 재생은 ScenarioRunner.cs 에 있습니다.
    //
    // ── 이 예제에서 SDK 사용을 보려면 ──
    // · 구역(Zone) 만들기와 드나듦 이벤트: SceneEscape(), SceneDesignate(), Zone_OnZoneContentChanged(), OnEnter(), OnLeave()
    // · 구역 안 인원 세기: RefreshHud()
    // · 이펙트(가스 구름·입자·대피 경로선·표식): SceneGasLeak(), SceneEscape(), SceneSparkFire()
    // · 레이캐스트로 설 자리·바닥 찾기: Standable(), FloorAt() (FloorMap.Cast 가 Object3D.Raycast 를 부릅니다)
    // 장면 재생·리본·시계·카메라 연출(ScenarioRunner.cs, ScenarioRibbon.cs, Cues.cs, Shot·Follow 등)과 걷기용 바닥 지도(FloorMap.cs, FloorData.cs)는 연출용이니 건너뛰어도 됩니다.
    // Crew.cs 는 아바타 API(Avatar.Place·SetPosture 등)로 작업자를 놓고 걷게 하므로, 아바타 사용을 보려면 함께 봅니다.
    // 다른 모델에 쓰려면: 좌표(ScenarioScript.cs)·바닥 격자(FloorData.cs)·가리는 부재 번호(HiddenNodes.cs, Node.Index)가 샘플 모델 전용이라 값을 바꿔야 합니다.
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 조작부 — 리본 사용자 탭 "시나리오" (뷰어 초기화 뒤에 만듭니다)
        private ScenarioRibbon _ribbon;

        // 대본과 재생기
        private List<ScenarioShot> _shots;
        private ScenarioRunner _runner;

        // 걷기·작업 동작·도착 뒤 일의 시계 (장면이 바뀌어도 이어 갑니다), 바닥 지도, 작업자
        // 15 ms 마다 시계·걷기·애니메이션·카메라를 진행합니다. 재생기와 무관하게 모델을 연 뒤부터 늘 돕니다.
        private readonly Cues _cues = new Cues();
        private readonly Timer _tick = new Timer();
        private FloorMap _map;
        private Crew _crew;

        // 처음으로 되돌릴 때마다 늘어나는 번호 — 늦게 도착한 이벤트가 지난 재생에 손대지 않게 합니다.
        private int _run;

        // 집결지와 화기 작업 구역(Zone)
        private int _muster = -1, _zone = -1;

        // 작업자 여섯 명: 용접공 A·그라인더공 B 는 허가자, 작업자 C 는 무허가, 화재감시자는 구역 밖
        private Person _welder, _grinder, _intruder, _watch;

        // 폭염 장면: 쓰러지는 작업자 E 와 알아채고 돕는 가장 가까운 작업자
        private Person _sick, _buddy;

        // 불 이펙트를 지우는 동작과 불난 자리
        private readonly List<Action> _fire = new List<Action>();
        private Data.Vector3D _firePos;

        // 3부: 추락하는 작업자 F, 낙하물에 맞는 작업자 G
        private Person _faller, _hurt;

        // 3부: 아래층에서 돌아다니다가 추락한 사람에게 달려오는 작업자들, 떨어지는 자재 노드, 매 틱 움직이는 동작
        private readonly List<Person> _below = new List<Person>();
        private List<Data.Node> _dropNodes;
        private Data.Vector3D _dropOrigin;
        private readonly List<Func<double, bool>> _anims = new List<Func<double, bool>>();
        private Person[] _all = new Person[0];

        // 이펙트 아이디 (0 이면 없음)
        private readonly List<uint> _tapes = new List<uint>();
        private uint _posts, _sign;

        // 장면이 끝났는지 — 번호 버튼이 선행 장면을 기다릴 때 씁니다(걷기·Zone 이벤트로 끝나는 장면).
        private int _mustered, _permittedIn;
        private bool _restDone, _musterDone, _workStarted, _intruderEntered, _resumed, _watcherBack, _headHit;

        // Zone 이벤트를 기다리는 장면 (무허가 출입 감지 · 퇴거 확인 · 구역이 비면 해제)
        private bool _intrudeArmed, _comeOutArmed, _releaseArmed;

        // 3D 뷰에 띄운 문구와, 그 뒤에 붙일 인원 표시 전의 문구
        private uint _hudNote;
        private Size _renderSize;
        private string _hudText;

        // 카메라 구도: 주시점 X·Y·Z, 방위(°, 0 = 주시점의 +X 쪽에서 봄), 고도(°), 거리(mm)
        private double[] _camFrom, _camTo;
        private double _camStart;

        // 구도를 옮기는 시간(초)
        private const double ShotSec = 0.6;
        private double _shotSec = ShotSec;

        private readonly Stopwatch _clock = Stopwatch.StartNew();

        // 따라갈 지점 (null 이면 따라가지 않음). 방위·고도·거리는 마우스로 바꾼 값을 그대로 씀
        private Func<Data.Vector3D> _track;

        private const string Group = Crew.Group;

        public FrmMain()
        {
            InitializeComponent();

            // 대본 목록은 뷰어와 무관하므로 생성자에서 채웁니다.
            _shots = BuildShots();

            _runner = new ScenarioRunner(_shots);
            _runner.ShotStarted += Runner_ShotStarted;

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction — 시연 창 전체가 3D 뷰입니다.
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            this.Controls.Add(vizcore3dx);


            _tick.Interval = 15;
            _tick.Tick += Tick_Tick;

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
        }

        private VIZCore3DX.NET.Manager.EffectManager Effect { get { return vizcore3dx.View.Effect; } }

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
            // 리본 UI 를 기본으로 켜고, 시나리오 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();
            HideViewerUI();
            InitializeRibbon();

            // 사람이 Zone 경계를 넘을 때마다 알려 줍니다.
            vizcore3dx.Zone.OnZoneContentChangedEvent += Zone_OnZoneContentChanged;

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
            ScenarioScript.Working.Play = SceneWorking;
            ScenarioScript.HeatStress.Play = SceneHeatStress;
            ScenarioScript.GasLeak.Play = SceneGasLeak;
            ScenarioScript.Escape.Play = SceneEscape;
            ScenarioScript.Designate.Play = SceneDesignate;
            ScenarioScript.EnterPermitted.Play = SceneEnterPermitted;
            ScenarioScript.Intrude.Play = SceneIntrude;
            ScenarioScript.OrderOut.Play = SceneOrderOut;
            ScenarioScript.ComeOut.Play = SceneComeOut;
            ScenarioScript.SparkFire.Play = SceneSparkFire;
            ScenarioScript.Extinguish.Play = SceneExtinguish;
            ScenarioScript.EndWork.Play = SceneEndWork;
            ScenarioScript.FallingObject.Play = SceneFallingObject;
            ScenarioScript.FallFromEdge.Play = SceneFallFromEdge;

            // 번호 버튼으로 바로 볼 때 먼저 실행할 장면 — 1부는 사람 배치(1)와 가스 누출(3)·대피(4), 2부는 구역 지정(5)·허가자 입장(6)부터 이어집니다.
            // 폭염(2)은 다른 장면의 선행 장면이 아닙니다. 낙하물(13)은 처음 상태에서도 시작할 수 있습니다.
            ScenarioScript.HeatStress.Before = new[] { 1 };
            ScenarioScript.GasLeak.Before = new[] { 1 };
            ScenarioScript.Escape.Before = new[] { 1, 3 };
            ScenarioScript.Designate.Before = new[] { 1, 3, 4 };
            ScenarioScript.EnterPermitted.Before = new[] { 1, 3, 4, 5 };
            ScenarioScript.Intrude.Before = new[] { 1, 3, 4, 5, 6 };
            ScenarioScript.OrderOut.Before = new[] { 1, 3, 4, 5, 6, 7 };
            ScenarioScript.ComeOut.Before = new[] { 1, 3, 4, 5, 6, 7, 8 };
            ScenarioScript.SparkFire.Before = new[] { 1, 3, 4, 5, 6 };
            ScenarioScript.Extinguish.Before = new[] { 1, 3, 4, 5, 6, 10 };
            ScenarioScript.EndWork.Before = new[] { 1, 3, 4, 5, 6, 10, 11 };
            ScenarioScript.FallFromEdge.Before = new[] { 13 };

            // 걷기·Zone 이벤트로 끝나는 장면 — 선행 장면으로 실행할 때 끝날 때까지 기다립니다.
            ScenarioScript.HeatStress.IsDone = () => _restDone;
            ScenarioScript.Escape.IsDone = () => _musterDone;
            ScenarioScript.EnterPermitted.IsDone = () => _workStarted;
            ScenarioScript.Intrude.IsDone = () => _intruderEntered;
            ScenarioScript.ComeOut.IsDone = () => _resumed;
            ScenarioScript.Extinguish.IsDone = () => _watcherBack;
            ScenarioScript.FallingObject.IsDone = () => _headHit;

            return new List<ScenarioShot>
            {
                ScenarioScript.Working, ScenarioScript.HeatStress, ScenarioScript.GasLeak, ScenarioScript.Escape,
                ScenarioScript.Designate, ScenarioScript.EnterPermitted, ScenarioScript.Intrude, ScenarioScript.OrderOut, ScenarioScript.ComeOut,
                ScenarioScript.SparkFire, ScenarioScript.Extinguish, ScenarioScript.EndWork,
                ScenarioScript.FallingObject, ScenarioScript.FallFromEdge,
            };
        }

        // 창을 닫을 때 재생 타이머부터 멈춥니다.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _runner.Reset();
            _tick.Stop();
            if (vizcore3dx != null) vizcore3dx.Zone.OnZoneContentChangedEvent -= Zone_OnZoneContentChanged;
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

        // 모델을 엽니다. 작업 현장 좌표는 샘플 모델 AftSection 에 맞춰 있습니다(ScenarioScript.cs).
        private void Ribbon_OpenModel()
        {
            if (_runner.IsPlaying) return;

            // 지금 장면(작업자·구역·이펙트)을 먼저 지웁니다.
            ClearScene();
            if (vizcore3dx.Model.OpenFileDialog() == false) return;
            if (!SetupModel() || !IsModelReady()) return;

            ShowSite();
            SetStatus("모델을 열었습니다. 재생을 시작하세요.");
        }

        // 연 모델에 바닥 지도·작업자·떨어질 자재를 준비하고, 장면을 가리는 부재를 숨깁니다.
        private bool SetupModel()
        {
            _map = null;
            _dropNodes = null;
            HideViewerUI();
            Crew.EnsurePreset(vizcore3dx);
            _camTo = null;

            // 처음 아바타를 놓을 때 모델·동작을 읽느라 오래 걸리므로, 모델을 열 때 한 번 놓았다 지워 미리 읽어 둠
            vizcore3dx.Avatar.Place(Crew.PresetName, new Data.Vector3D(0, 0, 0), 0);
            vizcore3dx.Avatar.Clear();

            try
            {
                _map = new FloorMap(vizcore3dx, ScenarioScript.Deck);
                _map.Load();

                // 허가받지 않은 사람은 작업 구역을 피해서 걷습니다.
                _crew = new Crew(vizcore3dx, _map, _cues) { InNoGo = (p, margin) => _zone >= 0 && InArea(p, margin) };

                // 사람이 움직일 때마다 Zone 안인지 검사해 OnZoneContentChangedEvent 로 알려 줌
                vizcore3dx.Zone.ContentWatchMode = Data.ContentWatchMode.Auto;
                Data.Node drop = vizcore3dx.Object3D.FromFilter(Data.Object3dFilter.PART).FirstOrDefault(n => n.NodeName == ScenarioScript.DropPart);
                _dropNodes = drop == null ? null : new List<Data.Node> { drop };
                if (_dropNodes != null)
                {
                    Data.BoundBox3D db = vizcore3dx.Object3D.GetBoundBox(_dropNodes);
                    _dropOrigin = new Data.Vector3D((db.MinX + db.MaxX) / 2, (db.MinY + db.MaxY) / 2, (db.MinZ + db.MaxZ) / 2);
                }
                HideBlockers();
            }
            catch (Exception ex)
            {
                _map = null;
                SetStatus("장면을 준비하지 못했습니다: " + ex.Message);
                return false;
            }

            if (!_tick.Enabled) _tick.Start();
            return true;
        }

        // 장면을 가리는 부재(머리 위 갑판·보·배관, 기둥)를 숨김. 목록은 이 모델에 맞춰 미리 계산해 둔 것(HiddenNodes)
        private void HideBlockers()
        {
            var hide = new HashSet<int>(HiddenNodes.Indexes);
            List<Data.Node> nodes = vizcore3dx.Object3D.FromFilter(Data.Object3dFilter.PART).Where(n => hide.Contains(n.Index)).ToList();
            if (nodes.Count > 0) vizcore3dx.Object3D.Show(nodes, false);
        }

        // 처음 구도 — 작업 현장을 앞에서 봅니다.
        private void ShowSite()
        {
            double[] v = ScenarioScript.SiteView;
            CutExact(Center((float)v[0]), v[1], v[2], v[3]);
        }

        #endregion

        #region 3. 재생

        // 첫 장면부터 끝까지 이어서 재생합니다.
        private void Ribbon_PlayAll()
        {
            if (!IsModelOpened() || !IsModelReady()) return;

            ClearScene();
            _runner.PlayAll();
        }

        // 번호 버튼 — 그 버튼의 장면(묶였으면 여러 장면)을 재생합니다. 바로 앞 장면에 이어 누른 것이 아니면 처음 상태로 되돌리고 선행 장면을 실행한 뒤 재생합니다.
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
            SetStatus("장면 : " + shot.Name);
        }

        // 시계·애니메이션·걷기·카메라를 진행합니다. 재생기와 무관하게 늘 돕니다(선행 장면을 준비하는 동안에도 걷기가 이어져야 함).
        private void Tick_Tick(object sender, EventArgs e)
        {
            try
            {
                _cues.Run();
                foreach (Func<double, bool> a in _anims.ToList())
                    if (a(_cues.Now)) _anims.Remove(a);
                if (_crew != null) _crew.Update();
                UpdateCamera();
            }
            catch (Exception ex)
            {
                SetStatus("오류: " + ex.Message);
            }
        }

        #endregion

        #region 5. 정리

        // 어느 장면에서든 처음 상태로 되돌립니다.
        private void Ribbon_Reset()
        {
            ClearScene();
            if (vizcore3dx.Model.IsOpen()) ShowSite();
            SetStatus("처음으로 되돌렸습니다.");
        }

        // 재생을 멈추고 진행 중인 장면·작업자·이펙트·구역을 모두 지웁니다.
        private void ClearScene()
        {
            _runner.Reset();
            if (_ribbon != null) _ribbon.SetCurrent(0);
            _run++;
            _cues.Clear();
            _anims.Clear();
            _track = null;

            _mustered = _permittedIn = 0;
            _restDone = _musterDone = _workStarted = _intruderEntered = _resumed = _watcherBack = _headHit = false;
            _intrudeArmed = _comeOutArmed = _releaseArmed = false;
            _hudText = null;

            if (vizcore3dx.Model.IsOpen()) Clear3D();
            _zone = _muster = -1;
            _all = new Person[0];
            _below.Clear();
            _tapes.Clear();
            _posts = _sign = 0;
            _fire.Clear();
        }

        private void Clear3D()
        {
            vizcore3dx.BeginUpdate();
            try
            {
                if (_dropNodes != null) vizcore3dx.Object3D.Transform.RestoreTransform(_dropNodes);

                // 구역을 먼저 지워 작업자를 지울 때 출입 이벤트가 오지 않게 함
                vizcore3dx.Zone.Clear();
                _zone = _muster = -1;
                if (_crew != null) _crew.Clear();

                // 이 예제가 만든 그룹만 지움
                Effect.ClearParticleEmitters(Group);
                Effect.ClearGasClouds(Group);
                Effect.ClearMarkers(Group);
                Effect.ClearTextLabels(Group);
                Effect.ClearPulseSpheres(Group);
                Effect.ClearPathLines(Group);
                Effect.ClearDataSets(Group);
                ClearHud();
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        #endregion

        #region 장면 — 1부 가스 누출 · 대피

        // ① 작업 중 — 여섯 명이 현장에서 일합니다. 일하지 않는 사람(화재감시자)은 가만히 서 있습니다.
        private void SceneWorking()
        {
            _welder = SpawnAt(ScenarioScript.WelderAt, "Sit 2", "용접공 A");
            _grinder = SpawnAt(ScenarioScript.GrinderAt, "Seeing 30", "그라인더공 B");
            _intruder = SpawnAt(ScenarioScript.IntruderAt, "Seeing 90", "작업자 C");
            Person d = SpawnAt(ScenarioScript.WorkerDAt, "Seeing 30", "작업자 D");
            _sick = SpawnAt(ScenarioScript.WorkerEAt, "Seeing 90", "작업자 E");
            _watch = SpawnAt(ScenarioScript.WatchAt, null, "화재감시자");
            _all = new[] { _welder, _grinder, _intruder, d, _sick, _watch };
            foreach (Person p in _all) p.Speed = ScenarioScript.Part1Speed;

            _crew.WorkLoop(_welder, "Sit 2", "weld", 1.3f);
            _crew.WorkLoop(_grinder, "Seeing 30", "grind", 2.0f);
            _crew.WorkLoop(_intruder, "Seeing 90", "cut", 1.5f);
            _crew.WorkLoop(d, "Seeing 30", "grind", 1.5f);
            _crew.WorkLoop(_sick, "Seeing 90", "weld", 1.0f);

            double[] v = ScenarioScript.SiteView;
            ShotExact(Center((float)v[0]), v[1], v[2], v[3]);
            Report("현장 작업 — 6명 작업 중");
        }

        // 그 자세를 잡아도 앞 부재에 닿지 않는 자리 { X, Y, 방위 } 에 놓음
        private Person SpawnAt(float[] at, string posture, string name)
        {
            return _crew.SpawnFit(at[0], at[1], at[2], posture, name);
        }

        // ② 폭염 이상 징후: 작업자 E 가 쓰러지고, 옆 사람이 알아채 작업을 멈추게 한 뒤 달려가 살피고 그늘로 데려가 쉬게 함
        private void SceneHeatStress()
        {
            Data.Vector3D at = _crew.Pos(_sick);
            _crew.Stop(_sick);
            // 바로 옆에 있던 두 명이 돕고, 그중 가장 가까운 사람이 살피고 그늘로 데려감
            Person[] helpers = _all.Where(p => p != _sick).OrderBy(p => Geo.Dist(_crew.Pos(p), at)).Take(2).ToArray();
            _buddy = helpers[0];
            ShotExact(Geo.Up(at, 600), 180, 22, 10000);
            Report("폭염 — 작업자 E 쓰러짐");

            uint mark = 0;
            _runner.After(ScenarioScript.HeatLieDownAt, () =>
            {
                _crew.Posture(_sick, "Lie Down");
                // 앞으로 쓰러지므로 몸 가운데(발에서 0.8 m 앞) 바로 위에 표시
                mark = Effect.AddMarker(_crew.Ahead(_sick, 800, 700), Data.MarkerIcon.Warning, new Data.MarkerOptions { SizePx = 56, BlinkIntervalMs = 500, Label = "쓰러짐 · 체온 38.5℃", Group = Group });
            });
            _runner.After(ScenarioScript.HeatNoticeAt, () =>
            {
                // 옆 사람이 알아채고 손을 들어 작업 중지를 알림
                foreach (Person p in _all) if (p != _sick) _crew.Stop(p);
                _crew.TurnTo(_buddy, _buddy.Token, at, () => _crew.Posture(_buddy, "Hands Up"));
                Report("   " + _buddy.Name + " 발견 — 작업 중지");
            });
            _runner.After(ScenarioScript.HeatHelpAt, () =>
            {
                // 옆에 있던 두 명이 E 를 넘어가지 않고 한쪽에 나란히 서서 살핌
                Data.Vector3D body = _crew.Ahead(_sick, 800, 0);
                Data.Vector3D[] spots =
                {
                    _map.Snap(body.X + 1100, body.Y - 450),
                    _map.Snap(body.X + 1100, body.Y + 450),
                };
                Report("   옆 작업자 2명이 다가감");
                for (int i = 0; i < helpers.Length; i++)
                {
                    Person h = helpers[i];
                    h.Speed = ScenarioScript.Part1Speed * 1.2f;
                    _crew.Walk(h, spots[i], () => _crew.TurnTo(h, h.Token, body, () =>
                    {
                        h.Speed = ScenarioScript.Part1Speed;
                        _crew.Posture(h, "Seeing 30");
                        if (h != _buddy) return;
                        Report("   " + _buddy.Name + " 상태 확인");

                        // 도착한 뒤의 일은 장면이 바뀌어도 이어지도록 걷기와 같은 시계에 둡니다.
                        _cues.After(ScenarioScript.HeatSitUpAfter, () => _crew.Posture(_sick, null));
                        _cues.After(ScenarioScript.HeatToShadeAfter, () =>
                        {
                            foreach (Person o in helpers) if (o != _buddy) _crew.Posture(o, null);
                            ToShade(at, mark);
                        });
                    }));
                }
            });
        }

        // E 가 일어나 가장 가까운 작업자와 함께 천천히 그늘(현장 선미 쪽 통로)로 가서 앉아 쉼
        private void ToShade(Data.Vector3D at, uint mark)
        {
            Data.Vector3D rest = _map.Snap(ScenarioScript.WorkArea.MinX - 1800, -7400);
            _sick.Speed = _buddy.Speed = ScenarioScript.Part1Speed * 0.6f;
            if (mark != 0) Effect.RemoveMarker(mark);
            _crew.Walk(_buddy, _map.Snap(rest.X + 800, rest.Y - 500), () => _crew.TurnTo(_buddy, _buddy.Token, _crew.Pos(_sick), () => _crew.Posture(_buddy, "Seeing 30")));
            _crew.Walk(_sick, rest, () =>
            {
                _crew.Posture(_sick, "Sit 3");
                Effect.AddTextLabel(Geo.Up(_crew.Pos(_sick), 1800), "휴식 · 수분 보충", new Data.TextLabelOptions { SizePx = 32, TextColor = Color.White, BackColor = ScenarioScript.Green, ExpireMs = 2500, Group = Group });
                Report("   그늘에서 휴식 · 수분 보충");
                _sick.Speed = ScenarioScript.Part1Speed * 0.85f;
                _buddy.Speed = ScenarioScript.Part1Speed;
                _restDone = true;
            });
        }

        // ③ 가스 누출: 현장 옆 배관에서 가스가 새고, 모두 일을 멈춤
        private void SceneGasLeak()
        {
            Data.BoundBox3D area = ScenarioScript.WorkArea;
            Data.Vector3D leak = Geo.Up(_map.Snap(area.MaxX - 1000, area.MaxY + 1300), 1600);
            Effect.AddGasCloud(leak, new Data.GasCloudOptions { MinRadius = 500, MaxRadius = 2400, PeriodMs = 3000, Color = ScenarioScript.GasColor, Opacity = 0.35f, Group = Group });
            Effect.AddParticleEmitter(leak, new Data.ParticleOptions(Data.ParticlePreset.Steam) { Group = Group });
            Effect.AddMarker(Geo.Up(leak, 900), Data.MarkerIcon.Gas, new Data.MarkerOptions { SizePx = 68, BlinkIntervalMs = 400, Label = "가스 누출", Group = Group });
            Effect.AddPulseSphere(leak, new Data.PulseSphereOptions { MinRadius = 300, MaxRadius = 1800, PeriodMs = 600, Color = ScenarioScript.Red, Opacity = 0.6f, ExpireMs = 3000, Group = Group });
            foreach (Person p in _all) _crew.Stop(p);

            Follow();
            ShotExact(new Data.Vector3D((leak.X + area.MinX + 2250) / 2, (leak.Y - 9000) / 2, ScenarioScript.Deck + 1200), 180, 18, 10500);
            Report("가스 누출 — 작업 중지");
        }

        // ④ 대피: 집결지 Zone 과 대피로가 나타나고 모두 집결지로 감. 집결 인원은 Zone 이벤트로 셈
        private void SceneEscape()
        {
            float[] muster0 = ScenarioScript.Muster;
            float gap = ScenarioScript.SlotGap, deck = ScenarioScript.Deck;
            Data.Vector3D muster = _map.Snap(muster0[0], muster0[1]);
            var box = new Data.BoundBox3D(muster.X - 800, muster.Y - gap - 800, deck, muster.X + gap * 2 + 800, muster.Y + 800, deck + 2500);
            _muster = vizcore3dx.Zone.CreateZoneFromBoundBox(box, "집결지");
            vizcore3dx.Zone.SetColor(_muster, ScenarioScript.Green, ScenarioScript.Green);
            vizcore3dx.Zone.SetFaceOpacity(_muster, 0);
            Effect.AddMarker(new Data.Vector3D(muster.X + gap, muster.Y - gap / 2, deck + 2800), Data.MarkerIcon.Check, new Data.MarkerOptions { SizePx = 56, Label = "집결지", Group = Group });

            // 대피로: 현장에서 집결지까지 바닥을 따라 흐르는 화살표
            List<Data.Vector3D> path = FloorMap.Smooth(_map.FindPath(_map.Snap(ScenarioScript.WorkArea.MinX + 600, -9000), muster, new HashSet<Point>(), new HashSet<Point>()));
            Effect.AddPathLine(path.Select(p => Geo.Up(p, 60)).ToList(), new Data.PathLineOptions { Color = ScenarioScript.Green, LineWidth = 6, PatternLengthMm = 700, GapRatio = 0.4f, SpeedMmPerSec = 1400, ShowArrow = true, Group = Group });

            Follow(_all);
            ShotExact(Center(900), 180, 22, 11500);
            Report("대피 — 집결지로 이동");
            _mustered = 0;
            for (int i = 0; i < _all.Length; i++)
            {
                Person p = _all[i];
                _crew.Walk(p, _map.Snap(muster0[0] + (i % 3) * gap, muster0[1] - (i / 3) * gap), () =>
                {
                    if (++_mustered < _all.Length) return;
                    Report("   전원 집결 — 6명");
                    _musterDone = true;
                });
            }
        }

        #endregion

        #region 장면 — 2부 화기 작업 허가

        // ⑤ 작업 구역 지정: 가스를 조치한 뒤 현장을 화기 작업 구역(Zone)으로 지정하고 폴리스 라인을 침
        private void SceneDesignate()
        {
            Effect.ClearGasClouds(Group);
            Effect.ClearParticleEmitters(Group);
            Effect.ClearMarkers(Group);
            Effect.ClearPathLines(Group);
            vizcore3dx.Zone.Delete(_muster);
            _muster = -1;
            Follow();

            foreach (Person p in _all) p.Speed = ScenarioScript.WalkSpeed;
            _zone = vizcore3dx.Zone.CreateZoneFromBoundBox(ScenarioScript.WorkArea, "화기 작업 구역");

            // 구역 안에 선 작업자가 경계면에 가려지지 않게
            vizcore3dx.Zone.SetDepthTestEnabled(_zone, false);

            // 모서리 기둥 4개와 띠, 표지
            float deck = ScenarioScript.Deck;
            var xyz = new List<float>();
            foreach (Data.Vector3D c in Corners(0).Take(4)) xyz.AddRange(new[] { c.X, c.Y, deck, c.X, c.Y, deck + ScenarioScript.TapeHeights.Max() });
            _posts = Effect.AddLineSet(xyz.ToArray(), null, null, new Data.DataSetOptions { Color = ScenarioScript.Yellow, LineWidth = 5f, Group = Group });
            SetLine(false, "화기 작업 구역 · 허가 " + ScenarioScript.PermitNo);

            ShotExact(Center(500), 180, 24, 11500);
            Report("구역 지정 — 화기 작업 허가 " + ScenarioScript.PermitNo);
        }

        // ⑥ 허가자 입장: 두 사람이 구역에 들어가 작업, 화재감시자는 구역 앞에 섬. 입장 확인은 Zone 이벤트(OnEnter)
        private void SceneEnterPermitted()
        {
            Report("허가자 입장 — 용접공 A · 그라인더공 B");
            _permittedIn = 0;
            _welder.AllowNoGo = _grinder.AllowNoGo = true;
            _crew.Walk(_welder, Inside(ScenarioScript.WelderAt[0], ScenarioScript.WelderAt[1]), () => StartWork(_welder));
            _crew.Walk(_grinder, Inside(ScenarioScript.GrinderAt[0], ScenarioScript.GrinderAt[1]), () => StartWork(_grinder));
            _crew.Walk(_watch, _map.Snap(ScenarioScript.WorkArea.MinX - 900, -7600), () => _crew.Turn(_watch, _watch.Token, -90, () => { }));
        }

        private void StartWork(Person p)
        {
            if (p == _welder) _crew.WorkLoop(p, "Sit 2", "weld", 1.3f);
            else _crew.WorkLoop(p, "Seeing 30", "grind", 2.0f);
            if (++_permittedIn < 2) return;
            Report("   화기 작업 시작");
            _workStarted = true;
        }

        // ⑦ 무허가 출입: 작업자 C 가 구역에 들어옴. 들어온 순간은 Zone 이벤트(OnEnter)가 잡음
        private void SceneIntrude()
        {
            _intrudeArmed = true;
            _intruder.AllowNoGo = true;
            Data.Vector3D to = Inside(ScenarioScript.WorkArea.MinX + 1600, -9300);
            _crew.Walk(_intruder, to, () => _crew.TurnTo(_intruder, _intruder.Token, _crew.Pos(_watch), () => { }));
            Report("무허가 출입 — 작업자 C가 구역 쪽으로 이동");
        }

        // ⑧ 퇴거 지시: 경보, 불꽃 작업 중지, 화재감시자가 작업자 C 에게 손을 들어 나가라고 함
        private void SceneOrderOut()
        {
            SetLine(true, "⚠ 무허가 출입 · 작업 중지");
            _crew.Stop(_welder);
            _crew.Stop(_grinder);
            _crew.TurnTo(_watch, _crew.NewToken(_watch), _crew.Pos(_intruder), () => _crew.Posture(_watch, "Hands Up"));
            Follow();
            Report("퇴거 지시 — 화재감시자, 작업 중지");
        }

        // ⑨ 무허가자 퇴거: 작업자 C 만 구역 밖으로 나감. 나간 것은 Zone 이벤트(OnLeave)가 확인하고 작업을 다시 시작함
        private void SceneComeOut()
        {
            _comeOutArmed = true;
            _crew.Walk(_intruder, _map.Snap(ScenarioScript.WorkArea.MinX - 2200, -9800), () =>
            {
                _intruder.AllowNoGo = false;
                _crew.TurnTo(_intruder, _intruder.Token, Center(0), () => { });
            });
            Report("무허가자 퇴거 — 작업자 C가 구역 밖으로");
        }

        // 작업자 C 가 나가면 경보를 풀고 허가자들이 작업을 다시 시작
        private void Resume()
        {
            _crew.Posture(_watch, null);
            _crew.Turn(_watch, _crew.NewToken(_watch), -90, () => { });
            SetLine(false, "화기 작업 구역 · 허가 " + ScenarioScript.PermitNo);
            _crew.WorkLoop(_welder, "Sit 2", "weld", 1.3f);
            _crew.WorkLoop(_grinder, "Seeing 30", "grind", 2.0f);
            // 두 작업자가 기둥에 가리지 않는 쪽에서
            Follow();
            Report("   경보 해제 — 작업 재개");
            _resumed = true;
        }

        // ⑩ 불티 화재: 용접 불티가 옆 가연물에 옮겨붙어 연기 → 불꽃으로 커지고, 화재감시자가 발견해 경보
        private void SceneSparkFire()
        {
            Data.Vector3D wp = _crew.Pos(_welder);
            _firePos = Inside(wp.X + 900, wp.Y + 200);
            Follow();
            ShotExact(Geo.Up(_firePos, 700), 180, 24, 10000);
            Report("불티 화재 — 용접 불티가 가연물에 옮겨붙음");

            // 불티가 튀어 떨어지고 연기가 조금씩 남
            Effect.AddParticleEmitter(Geo.Up(_firePos, 100), new Data.ParticleOptions(Data.ParticlePreset.Sparks) { Direction = new Data.Vector3D(0, 0, 1), ConeAngleDeg = 50, ExpireMs = 1500, Group = Group });
            AddFire(Effect.AddParticleEmitter(Geo.Up(_firePos, 150), new Data.ParticleOptions(Data.ParticlePreset.Smoke) { RatePerSec = 8, Group = Group }), Effect.RemoveParticleEmitter);

            // 불꽃으로 커짐
            _runner.After(ScenarioScript.FlameAt, () =>
            {
                AddFire(Effect.AddPulseSphere(Geo.Up(_firePos, 250), new Data.PulseSphereOptions { MinRadius = 150, MaxRadius = 380, PeriodMs = 450, Color = Color.FromArgb(255, 120, 20), Opacity = 0.75f, Group = Group }), Effect.RemovePulseSphere);
                AddFire(Effect.AddParticleEmitter(Geo.Up(_firePos, 100), new Data.ParticleOptions(Data.ParticlePreset.Sparks) { Direction = new Data.Vector3D(0, 0, 1), ConeAngleDeg = 25, SpeedMinMmPerSec = 300, SpeedMaxMmPerSec = 900, GravityMmPerSec2 = 600, LifetimeMinSec = 0.3f, LifetimeMaxSec = 0.7f, StartColor = Color.FromArgb(255, 220, 80), EndColor = Color.FromArgb(220, 40, 0), Group = Group }), Effect.RemoveParticleEmitter);
                AddFire(Effect.AddParticleEmitter(Geo.Up(_firePos, 600), new Data.ParticleOptions(Data.ParticlePreset.Smoke) { Group = Group }), Effect.RemoveParticleEmitter);
                AddFire(Effect.AddMarker(Geo.Up(_firePos, 1700), Data.MarkerIcon.Fire, new Data.MarkerOptions { SizePx = 60, BlinkIntervalMs = 400, Label = "화재", Group = Group }), Effect.RemoveMarker);
            });

            // 화재감시자가 발견: 경보, 작업 중지
            _runner.After(ScenarioScript.FireAlarmAt, () =>
            {
                SetLine(true, "화재 · 작업 중지");
                _crew.Stop(_welder);
                _crew.Stop(_grinder);
                _crew.TurnTo(_watch, _crew.NewToken(_watch), _firePos, () => _crew.Posture(_watch, "Hands Up"));
                Report("   화재감시자 발견 — 경보 · 작업 중지");
            });
        }

        // ⑪ 초기 진화: 작업자 둘은 구역 밖으로 피하고, 화재감시자가 소화기로 불을 끈 뒤 구역 앞 자리로 돌아감
        private void SceneExtinguish()
        {
            Report("초기 진화 — 작업자 대피 · 화재감시자 소화");
            float minX = ScenarioScript.WorkArea.MinX;
            _welder.AllowNoGo = _grinder.AllowNoGo = _watch.AllowNoGo = true;
            _crew.Walk(_welder, _map.Snap(minX - 3200, -10400), () => _welder.AllowNoGo = false);
            _crew.Walk(_grinder, _map.Snap(minX - 3200, -8800), () => _grinder.AllowNoGo = false);
            _crew.Walk(_watch, _map.Snap(_firePos.X - 2300, _firePos.Y), () => _crew.TurnTo(_watch, _watch.Token, _firePos, () =>
            {
                // 소화약제를 불 쪽으로 뿌림
                _crew.Posture(_watch, "Seeing 30");
                Follow();
                Data.Vector3D from = _crew.Ahead(_watch, 400, 900);
                Data.Vector3D dir = Geo.Norm(new Data.Vector3D(_firePos.X - from.X, _firePos.Y - from.Y, _firePos.Z + 200 - from.Z));
                uint spray = Effect.AddParticleEmitter(from, new Data.ParticleOptions(Data.ParticlePreset.Steam) { Direction = dir, ConeAngleDeg = 14, SpeedMinMmPerSec = 2600, SpeedMaxMmPerSec = 3600, StartColor = Color.White, EndColor = Color.FromArgb(230, 230, 230), Group = Group });
                Data.Vector3D wpos = _crew.Pos(_watch);
                Shot(new Data.Vector3D((wpos.X + _firePos.X) / 2, (wpos.Y + _firePos.Y) / 2, ScenarioScript.Deck + 900), 95, 20, 10000, Geo.Up(wpos, 900), Geo.Up(_firePos, 900));

                // 불꽃이 먼저 잦아들고, 연기는 조금 뒤에 걷힘 (도착한 뒤의 일이라 걷기와 같은 시계에 둡니다)
                _cues.After(ScenarioScript.FlameOutAfter, () => { foreach (Action a in _fire.Skip(1)) a(); });
                _cues.After(ScenarioScript.SmokeOutAfter, () =>
                {
                    if (_fire.Count > 0) _fire[0]();
                    _fire.Clear();
                    Effect.RemoveParticleEmitter(spray);
                    SetLine(false, "진화 완료 · 허가 " + ScenarioScript.PermitNo);
                    Report("   초기 진화 완료");

                    // 화재감시자는 구역 앞 자리로 돌아감
                    _crew.Walk(_watch, _map.Snap(minX - 900, -7600), () =>
                    {
                        _watch.AllowNoGo = false;
                        _watcherBack = true;
                    });
                });
            }));
        }

        // 불 이펙트 하나를 등록 (진화할 때 remove 로 지움)
        private void AddFire(uint id, Func<uint, bool> remove)
        {
            _fire.Add(() => remove(id));
        }

        // ⑫ 작업 종료: 허가자 둘이 나오고, 구역이 비면(OnLeave) 구역과 폴리스 라인을 걷음
        private void SceneEndWork()
        {
            if (vizcore3dx.Zone.GetContents(_zone).Count == 0)
            {
                Report("작업 종료 — 구역 해제");
                _runner.After(ScenarioScript.ReleaseAfter, Release);
                return;
            }
            _releaseArmed = true;
            float minX = ScenarioScript.WorkArea.MinX;
            _welder.AllowNoGo = _grinder.AllowNoGo = true;
            _crew.Walk(_welder, _map.Snap(minX - 1400, -10400), () => _welder.AllowNoGo = false);
            _crew.Walk(_grinder, _map.Snap(minX - 1400, -9200), () => _grinder.AllowNoGo = false);
            Report("작업 종료 — 허가자 퇴장");
        }

        private void Release()
        {
            // 낙하물 장면이 먼저 구역을 걷었으면 할 일이 없습니다.
            if (_zone < 0) return;

            vizcore3dx.Zone.Delete(_zone);
            _zone = -1;
            foreach (uint id in _tapes) Effect.RemovePathLine(id);
            _tapes.Clear();
            Effect.RemoveDataSet(_posts);
            Effect.RemoveTextLabel(_sign);
            _posts = _sign = 0;
            Data.Vector3D done = new Data.Vector3D(ScenarioScript.WorkArea.MinX + 800, -9000, ScenarioScript.Deck + 2600);
            Effect.AddTextLabel(done, "✔ 작업 종료 · 구역 해제", new Data.TextLabelOptions { SizePx = 40, TextColor = Color.White, BackColor = ScenarioScript.Green, Group = Group });

            Follow();
            ShotExact(new Data.Vector3D(ScenarioScript.WorkArea.MinX - 300, -9300, ScenarioScript.Deck + 1200), 180, 22, 11500);
            Report("   구역 해제 — 허가 " + ScenarioScript.PermitNo + " 반납");
        }

        // 폴리스 라인과 구역 색(평소 노랑, 경보 빨강), 표지 글을 바꿈. 경보 중에는 띠가 빠르게 흐름
        private void SetLine(bool alarm, string sign)
        {
            Color color = alarm ? ScenarioScript.Red : ScenarioScript.Yellow;
            vizcore3dx.Zone.SetColor(_zone, color, color);

            foreach (uint id in _tapes) Effect.RemovePathLine(id);
            _tapes.Clear();
            foreach (float h in ScenarioScript.TapeHeights)
                _tapes.Add(Effect.AddPathLine(Corners(h).ToList(), new Data.PathLineOptions { Color = color, LineWidth = 6, PatternLengthMm = 500, GapRatio = 0.5f, SpeedMmPerSec = alarm ? 900 : 0, ShowArrow = false, AlwaysOnTop = false, Group = Group }));

            if (_sign != 0) Effect.RemoveTextLabel(_sign);
            Data.BoundBox3D area = ScenarioScript.WorkArea;
            Data.Vector3D top = new Data.Vector3D(area.MinX, (area.MinY + area.MaxY) / 2, area.MaxZ - 200);
            _sign = Effect.AddTextLabel(top, sign, new Data.TextLabelOptions { SizePx = 40, TextColor = alarm ? Color.White : Color.Black, BackColor = color, BlinkIntervalMs = alarm ? 350 : 0, Group = Group });
        }

        // 구역 바닥 둘레를 한 바퀴 도는 점 (높이 h 만큼 위)
        private static IEnumerable<Data.Vector3D> Corners(float h)
        {
            Data.BoundBox3D area = ScenarioScript.WorkArea;
            float z = ScenarioScript.Deck + h;
            yield return new Data.Vector3D(area.MinX, area.MinY, z);
            yield return new Data.Vector3D(area.MaxX, area.MinY, z);
            yield return new Data.Vector3D(area.MaxX, area.MaxY, z);
            yield return new Data.Vector3D(area.MinX, area.MaxY, z);
            yield return new Data.Vector3D(area.MinX, area.MinY, z);
        }

        #endregion

        #region 장면 — 3부 낙하물 · 추락

        // ⑬ 낙하물: 계단 위 통로(8.63 m)를 지나던 작업자 F 가 통로 끝의 자재를 발로 차고, 자재가 아래 계단참(5.52 m)의 작업자 G 머리에 떨어짐
        private void SceneFallingObject()
        {
            // 2부에 이어 재생하면 2부 현장을 그대로 둔 채 카메라만 옮겨 감. 이 장면부터 볼 때는 처음 상태에서 시작
            bool cont = _all.Length > 0;

            // 이어서 재생할 때 2부의 작업 구역이 남아 있으면 걷어 둠
            _releaseArmed = false;
            if (_zone >= 0)
            {
                vizcore3dx.Zone.Delete(_zone);
                _zone = -1;
                foreach (uint id in _tapes) Effect.RemovePathLine(id);
                _tapes.Clear();
                Effect.RemoveDataSet(_posts);
                Effect.RemoveTextLabel(_sign);
                _posts = _sign = 0;
            }
            if (_dropNodes == null)
            {
                SetStatus("떨어질 자재(" + ScenarioScript.DropPart + ")를 모델에서 찾지 못했습니다.");
                return;
            }

            // 통로 높이, 자재를 통로 끝에 놓아 둠, 아래 계단참 작업자 자리
            float[] dropWalk = ScenarioScript.DropWalk;
            float walk = FloorAt(ScenarioScript.DropStart[0], ScenarioScript.DropStart[1], ScenarioScript.Deck + 500).Z;
            Data.Vector3D block = new Data.Vector3D(ScenarioScript.DropStart[0], ScenarioScript.DropStart[1], walk + (_dropOrigin.Z - ScenarioScript.Deck));
            MoveDrop(block.X, block.Y, block.Z);
            Data.Vector3D edge = new Data.Vector3D(ScenarioScript.DropEdge[0], ScenarioScript.DropEdge[1], block.Z);
            Data.Vector3D below = FloorAt(ScenarioScript.DropBelow[0], ScenarioScript.DropBelow[1], walk - 300);

            _faller = _crew.Spawn(new Data.Vector3D(dropWalk[0], dropWalk[1], walk), -90, "작업자 F");
            // 계단참 안쪽(-X)을 보고 일함. 맞으면 그쪽으로 쓰러져 몸이 계단참 위에 눕게
            _hurt = _crew.Spawn(below, 90, "작업자 G");
            _all = _all.Concat(new[] { _faller, _hurt }).ToArray();
            _crew.WorkLoop(_hurt, "Seeing 90", "grind", 1.0f);

            // 아래층 작업자들은 처음부터 두 지점 사이를 오감
            _below.Clear();
            for (int i = 0; i < ScenarioScript.BelowRoutes.Length; i++)
            {
                float[] r = ScenarioScript.BelowRoutes[i];
                Data.Vector3D a = FloorAt(r[0], r[1], 3800), b = FloorAt(r[2], r[3], 3800);
                if (!Standable(a) || !Standable(b) || !ClearWay(a, b)) continue;
                Person w = _crew.Spawn(a, Geo.Heading(b.X - a.X, b.Y - a.Y), "아래층 작업자 " + (i + 1));
                _below.Add(w);
                Wander(w, _crew.NewToken(w), a, b);
            }

            Data.Vector3D head = Geo.Up(below, 1700);
            _track = null;
            double[] v = ScenarioScript.FallViewStart;
            if (cont) ShotExact(new Data.Vector3D((float)v[0], (float)v[1], (float)v[2]), v[3], v[4], v[5], 1.6);
            else View(v);
            Report("낙하물 — 통로 위 작업자 F · 계단참 작업자 G");

            // F 가 통로를 지나가다 자재를 발로 참
            _runner.After(cont ? ScenarioScript.KickWalkAtContinued : ScenarioScript.KickWalkAt, () =>
            {
                Data.Vector3D to = new Data.Vector3D(dropWalk[2], dropWalk[1], walk);
                vizcore3dx.Avatar.MoveTo(_faller.Id, to, -90, (int)(Math.Abs(dropWalk[2] - dropWalk[0]) / ScenarioScript.WalkSpeed * 1000));
                Animate(t =>
                {
                    if (_crew.Pos(_faller).X < block.X - 200) return false;
                    Kick(block, edge, head);
                    return true;
                });
            });
        }

        // 자재가 통로 끝으로 밀려 포물선으로 떨어져 G 의 머리에 맞고 튕겨 바닥에 떨어짐
        private void Kick(Data.Vector3D block, Data.Vector3D edge, Data.Vector3D head)
        {
            Report("   작업자 F가 통로 끝 자재를 발로 참");
            double slide = Math.Max(0.15, Geo.Dist(block, edge) / 1500.0);

            const double g = 9810, up = 300;
            double hitT = (up + Math.Sqrt(up * up + 2 * g * (edge.Z - head.Z))) / g;
            double vx = (head.X - edge.X) / hitT, vy = (head.Y - edge.Y) / hitT;
            double floorZ = head.Z - 1700;
            bool hit = false;

            Animate(t =>
            {
                double x, y, z;
                if (t < slide)
                {
                    double k = t / slide;
                    x = block.X + (edge.X - block.X) * k;
                    y = block.Y + (edge.Y - block.Y) * k;
                    z = block.Z;
                }
                else
                {
                    double f = t - slide;
                    if (!hit && f >= hitT)
                    {
                        hit = true;
                        HitHead(head);
                    }
                    if (!hit)
                    {
                        x = edge.X + vx * f;
                        y = edge.Y + vy * f;
                        z = edge.Z + up * f - g * f * f / 2;
                    }
                    else
                    {
                        // 머리에 맞고 옆으로 튕겨 바닥에 떨어짐
                        double b = f - hitT;
                        x = head.X + 500 * b;
                        y = head.Y + 700 * b;
                        z = head.Z + 900 * b - g * b * b / 2;
                        if (z <= floorZ + 40) { MoveDrop(x, y, floorZ + 40); return true; }
                    }
                }
                MoveDrop(x, y, z);
                return false;
            });
        }

        private void MoveDrop(double x, double y, double z)
        {
            vizcore3dx.Object3D.Transform.Move(_dropNodes, (float)(x - _dropOrigin.X), (float)(y - _dropOrigin.Y), (float)(z - _dropOrigin.Z), true);
        }

        private void HitHead(Data.Vector3D head)
        {
            _crew.Stop(_hurt);
            Effect.AddPulseSphere(head, new Data.PulseSphereOptions { MinRadius = 100, MaxRadius = 500, PeriodMs = 400, Color = ScenarioScript.Red, Opacity = 0.7f, ExpireMs = 1600, Group = Group });
            _cues.After(0.25, () => _crew.Posture(_hurt, "Kneel"));
            _cues.After(0.8, () => Effect.AddMarker(_crew.Ahead(_hurt, 800, 700), Data.MarkerIcon.Warning, new Data.MarkerOptions { SizePx = 56, BlinkIntervalMs = 500, Label = "낙하물 충돌 · 작업자 G", Group = Group }));
            Report("   작업자 G 머리에 낙하물 충돌 — 쓰러짐");
            _headHit = true;
        }

        // ⑭ 추락: F 가 통로 끝에서 몸을 숙여 아래를 내려다보다 균형을 잃고 떨어짐
        private void SceneFallFromEdge()
        {
            Data.Vector3D p = _crew.Pos(_faller);
            // G 와 겹치지 않게 조금 옆에서, 통로 끝 너머(+Y)를 내려다봄
            Data.Vector3D look = new Data.Vector3D(ScenarioScript.DropEdge[0] + 450, ScenarioScript.DropEdge[1] - 150, p.Z);
            Report("추락 — 작업자 F가 통로 끝에서 아래 확인");
            LookFrom(ScenarioScript.FallEye, new Data.Vector3D(look.X - 200, look.Y + 100, look.Z + 300));
            int ms = (int)(Geo.Dist(p, look) / (ScenarioScript.WalkSpeed * 0.8f) * 1000);
            _crew.TurnTo(_faller, _crew.NewToken(_faller), look, () =>
            {
                vizcore3dx.Avatar.MoveTo(_faller.Id, look, Geo.Heading(look.X - p.X, look.Y - p.Y), ms);
                _cues.After(ms / 1000.0 + 0.3, () => _crew.Turn(_faller, _faller.Token, ScenarioScript.FallHeading, () =>
                {
                    _crew.Posture(_faller, "Seeing 90");
                    _cues.After(2.2, () => Fall(_crew.Pos(_faller)));
                }));
            });
        }

        // 떨어지는 쪽(+Y)을 보고 몸을 숙였다가, 떨어지면서 몸이 돌아 아래층 평평한 바닥에 반듯이 누움. 카메라는 한자리에서 F 를 따라 내려다봄
        private void Fall(Data.Vector3D from)
        {
            Report("   균형을 잃고 추락");
            _crew.NewToken(_faller);

            const double g = 9810, up = 700, vy = 2100;
            double tLand = 1.2;
            for (double t = 0.25; t < 3; t += 0.02)
                if (from.Z + up * t - g * t * t / 2 <= FloorAt(from.X, (float)(from.Y + vy * t), from.Z - 300).Z) { tLand = t; break; }

            bool lying = false;
            Animate(t =>
            {
                double y = from.Y + vy * t, z = from.Z + up * t - g * t * t / 2;
                Data.Vector3D floor = FloorAt(from.X, (float)y, from.Z - 300);
                bool landed = t > 0.25 && z <= floor.Z;
                Data.Vector3D at = landed ? floor : new Data.Vector3D(from.X, (float)y, (float)z);

                // 숙인 자세로 떨어지기 시작해 중간에 몸이 펴지고, 방향도 떨어지는 동안 돌아감
                double k = Math.Min(1, t / tLand);
                if (!lying && k > 0.3) { lying = true; _crew.Posture(_faller, "Lie Down"); }
                vizcore3dx.Avatar.SetPosition(_faller.Id, at, ScenarioScript.FallHeading + (ScenarioScript.LandHeading - ScenarioScript.FallHeading) * (landed ? 1 : k));
                LookFrom(ScenarioScript.FallEye, new Data.Vector3D(at.X - 400, at.Y - 100, at.Z + 700));
                if (landed) Landed(floor);
                return landed;
            });
        }

        private void Landed(Data.Vector3D at)
        {
            Effect.AddPulseSphere(Geo.Up(at, 300), new Data.PulseSphereOptions { MinRadius = 200, MaxRadius = 800, PeriodMs = 500, Color = ScenarioScript.Red, Opacity = 0.6f, ExpireMs = 2000, Group = Group });
            _cues.After(0.8, () => Effect.AddMarker(_crew.Ahead(_faller, 800, 700), Data.MarkerIcon.Warning, new Data.MarkerOptions { SizePx = 56, BlinkIntervalMs = 500, Label = "추락 · 작업자 F", Group = Group }));
            Report("   작업자 F 추락 — 2명 부상");

            // 아래층 작업자들이 달려와 쓰러진 F 둘레에 섬 (몸은 발에서 -X 쪽으로 누워 있음)
            // 설 자리: 몸 둘레에서 부재와 겹치지 않고, 달려오는 길도 막히지 않은 곳
            Data.Vector3D body = new Data.Vector3D(at.X - 800, at.Y, at.Z);
            var taken = new List<Data.Vector3D>();
            double last = 0;
            foreach (Person w in _below)
            {
                int token = _crew.NewToken(w);
                Data.Vector3D from = _crew.Pos(w);
                Data.Vector3D to = null;
                foreach (float radius in new[] { 1200f, 1500f, 1800f, 2200f })
                {
                    for (int k = 0; k < 16 && to == null; k++)
                    {
                        double ang = k * Math.PI / 8;
                        Data.Vector3D c = FloorAt(body.X + radius * (float)Math.Cos(ang), body.Y + radius * (float)Math.Sin(ang), at.Z + 1500);
                        if (Math.Abs(c.Z - at.Z) > 50 || !Standable(c) || !ClearWay(from, c)) continue;
                        if (taken.Any(o => Geo.Dist(o, c) < 900)) continue;

                        // 누운 몸(발 at 에서 -X 로 1.8 m)에서 0.9 m 넘게 떨어진 자리만
                        float nx = Math.Max(at.X - 1800, Math.Min(at.X, c.X));
                        if (Geo.Dist(c, new Data.Vector3D(nx, at.Y, at.Z)) < 900) continue;
                        to = c;
                    }
                    if (to != null) break;
                }
                if (to == null) continue;      // 갈 길이 막힌 사람은 제자리에서 바라봄
                taken.Add(to);

                Data.Vector3D spot = to;
                double sec = Math.Max(0.4, Geo.Dist(from, spot) / ScenarioScript.BelowRun);
                last = Math.Max(last, sec);
                vizcore3dx.Avatar.MoveTo(w.Id, spot, Geo.Heading(spot.X - from.X, spot.Y - from.Y), (int)(sec * 1000));
                _cues.After(sec + 0.2, () => { if (_crew.Live(w, token)) _crew.TurnTo(w, token, body, () => _crew.Posture(w, "Seeing 30")); });
            }
            _cues.After(0.5, () => Report("   아래층 작업자 " + _below.Count + "명이 달려옴"));
            _cues.After(last + 1.5, () => Report("   아래층 작업자 도착 — 구호 시작"));
        }

        // 그 자리에 섰을 때 몸(발목·허리·가슴 높이, 사방 0.4 m)이 부재와 겹치지 않는지
        private bool Standable(Data.Vector3D p)
        {
            Data.Vector3D[] dirs = { new Data.Vector3D(1, 0, 0), new Data.Vector3D(-1, 0, 0), new Data.Vector3D(0, 1, 0), new Data.Vector3D(0, -1, 0) };
            foreach (float h in new[] { 300f, 1000f, 1600f })
                foreach (Data.Vector3D d in dirs)
                    if (_map.Cast(new Data.Vector3D(p.X, p.Y, p.Z + h), d, 400) != null) return false;
            return true;
        }

        // a 에서 b 까지 곧게 갈 때 몸 높이(무릎·가슴)에 걸리는 부재가 없는지
        private bool ClearWay(Data.Vector3D a, Data.Vector3D b)
        {
            float d = Geo.Dist(a, b);
            if (d < 100) return true;
            Data.Vector3D dir = Geo.Norm(new Data.Vector3D(b.X - a.X, b.Y - a.Y, 0));
            foreach (float h in new[] { 500f, 1300f })
                if (_map.Cast(new Data.Vector3D(a.X, a.Y, a.Z + h), dir, d + 300) != null) return false;
            return true;
        }

        // a 에서 b 까지 걸어가 잠깐 섰다가 되돌아오기를 되풀이 (아래층은 바닥 지도가 없어 곧게 걸음)
        private void Wander(Person p, int token, Data.Vector3D a, Data.Vector3D b)
        {
            double sec = Geo.Dist(a, b) / ScenarioScript.BelowWalk;
            vizcore3dx.Avatar.MoveTo(p.Id, b, Geo.Heading(b.X - a.X, b.Y - a.Y), (int)(sec * 1000));
            _cues.After(sec + 0.8, () => { if (_crew.Live(p, token)) Wander(p, token, b, a); });
        }

        // 구도 { 주시점 X, Y, Z, 방위, 고도, 거리 } 로 바로 바꿈
        private void View(double[] v)
        {
            CutExact(new Data.Vector3D((float)v[0], (float)v[1], (float)v[2]), v[3], v[4], v[5]);
        }

        // 눈 자리 eye 에서 at 을 바라봄
        private void LookFrom(float[] eye, Data.Vector3D at)
        {
            double dx = eye[0] - at.X, dy = eye[1] - at.Y, dz = eye[2] - at.Z, d = Math.Sqrt(dx * dx + dy * dy + dz * dz);
            View(new[] { at.X, at.Y, at.Z, Math.Atan2(dy, dx) * 180 / Math.PI, Math.Asin(dz / d) * 180 / Math.PI, d });
        }

        // (x, y) 에서 높이 fromZ 아래로 처음 닿는 바닥
        private Data.Vector3D FloorAt(float x, float y, float fromZ)
        {
            Data.RaycastHit h = _map.Cast(new Data.Vector3D(x, y, fromZ), new Data.Vector3D(0, 0, -1), 9000);
            return h == null ? new Data.Vector3D(x, y, fromZ - 3000) : h.Position;
        }

        // 매 틱 step(경과 초)을 부르고 true 를 돌려주면 멈춤
        private void Animate(Func<double, bool> step)
        {
            double t0 = _cues.Now;
            _anims.Add(now => step(now - t0));
        }

        #endregion

        #region 출입 (Zone 이벤트)

        // 사람이 Zone 경계를 넘을 때마다 불립니다. 들어온 사람은 Entered, 나간 사람은 Exited 에 있습니다.
        // 인원 표시와 그 자리의 표시만 바로 바꾸고, 장면 진행은 그 이벤트를 기다리는 장면(무허가 출입·퇴거·작업 종료)이 있을 때만 합니다.
        private void Zone_OnZoneContentChanged(object sender, VIZCore3DX.NET.Event.EventManager.ContentChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                int run = _run;
                BeginInvoke(new Action(() => { if (run == _run) Zone_OnZoneContentChanged(sender, e); }));
                return;
            }
            if (_crew == null) return;
            foreach (Data.ContentItem item in e.Entered.Where(i => i.ContainerID == _zone)) OnEnter(_crew.Find(item.ContentID));
            foreach (Data.ContentItem item in e.Exited.Where(i => i.ContainerID == _zone)) OnLeave(_crew.Find(item.ContentID));
            if (e.Entered.Any(i => i.ContainerID == _muster)) RefreshHud();
        }

        private void OnEnter(Person p)
        {
            if (p == null) return;
            if (p == _intruder)
            {
                if (!_intrudeArmed) { RefreshHud(); return; }
                _intrudeArmed = false;
                _intruderEntered = true;
                Report("   무허가 출입 감지");
                return;
            }

            if (p == _watch) { RefreshHud(); return; }
            Effect.AddTextLabel(Geo.Up(_crew.Pos(p), 2300), "✔ 허가 확인 · " + p.Name, new Data.TextLabelOptions { SizePx = 34, TextColor = Color.White, BackColor = ScenarioScript.Green, ExpireMs = 2000, Group = Group });
            RefreshHud();
        }

        private void OnLeave(Person p)
        {
            if (_zone < 0) return;
            RefreshHud();
            if (_comeOutArmed && p == _intruder)
            {
                _comeOutArmed = false;
                Resume();
            }
            else if (_releaseArmed && vizcore3dx.Zone.GetContents(_zone).Count == 0)
            {
                _releaseArmed = false;
                Report("   구역 내 잔류 인원 0명");
                _cues.After(ScenarioScript.ReleaseAfter, Release);
            }
        }

        private static bool InArea(Data.Vector3D p, float margin)
        {
            Data.BoundBox3D area = ScenarioScript.WorkArea;
            return p.X > area.MinX - margin && p.X < area.MaxX + margin && p.Y > area.MinY - margin && p.Y < area.MaxY + margin;
        }

        // 구역 가운데 바닥에서 dz 만큼 위
        private static Data.Vector3D Center(float dz)
        {
            Data.BoundBox3D area = ScenarioScript.WorkArea;
            return new Data.Vector3D((area.MinX + area.MaxX) / 2, (area.MinY + area.MaxY) / 2, ScenarioScript.Deck + dz);
        }

        // 구역 안쪽(경계에서 0.6 m 넘게 들어간 곳)에서 (x, y) 에 가장 가까운, 설 수 있는 자리
        private Data.Vector3D Inside(float x, float y)
        {
            Point cell = _map.Cells().Where(c => _map.Clearance(c) >= 2 && InArea(_map.CellPos(c), -600))
                                     .OrderBy(c => Sq(_map.CellPos(c).X - x) + Sq(_map.CellPos(c).Y - y))
                                     .DefaultIfEmpty(_map.ToCell(new Data.Vector3D(x, y, ScenarioScript.Deck))).First();
            return _map.CellPos(cell);
        }

        #endregion

        #region 카메라

        // 지금 카메라에서 새 구도로 부드럽게 옮깁니다. target 과 alsoSee(걸어갈 곳 등)가 모두 트여 보이는 방위·고도를 고르고, 다 막히면 가까이 붙습니다.
        private void Shot(Data.Vector3D target, double az, double el, double dist, params Data.Vector3D[] alsoSee)
        {
            if (_track != null) target = _track();
            _shotSec = ShotSec;
            double[] fit = Fit(new[] { target }.Concat(alsoSee).ToArray(), az, el, dist);
            _camFrom = ReadCamera();
            double daz = fit[0] - _camFrom[3];
            while (daz > 180) daz -= 360;
            while (daz < -180) daz += 360;
            _camTo = new[] { target.X, target.Y, target.Z, _camFrom[3] + daz, fit[1], fit[2] };
            _camStart = _clock.Elapsed.TotalSeconds;
        }

        // 정한 구도 그대로 부드럽게 옮김 (가림 검사로 방향을 돌리지 않음)
        private void ShotExact(Data.Vector3D target, double az, double el, double dist, double sec = ShotSec)
        {
            _shotSec = sec;
            if (_track != null) target = _track();
            _camFrom = ReadCamera();
            double daz = az - _camFrom[3];
            while (daz > 180) daz -= 360;
            while (daz < -180) daz += 360;
            _camTo = new[] { target.X, target.Y, target.Z, _camFrom[3] + daz, el, dist };
            _camStart = _clock.Elapsed.TotalSeconds;
        }

        // 정한 구도 그대로 바로 바꿈 (가림 검사로 방향을 돌리지 않음)
        private void CutExact(Data.Vector3D target, double az, double el, double dist)
        {
            _camTo = null;
            Orbit(new double[] { target.X, target.Y, target.Z, az, el, dist });
        }

        // 카메라가 이 사람들의 가운데를 따라감 (인자가 없으면 멈춤)
        private void Follow(params Person[] people)
        {
            if (people.Length == 0) { _track = null; return; }
            Data.Vector3D last = Center(900);
            _track = () =>
            {
                var live = people.Where(p => !p.Removed).Select(p => _crew.Info(p)).Where(i => i != null).ToList();
                if (live.Count > 0) last = new Data.Vector3D(live.Average(i => i.Position.X), live.Average(i => i.Position.Y), ScenarioScript.Deck + 900);
                return last;
            };
        }

        // 틱마다 부릅니다. 구도를 옮기는 중이거나 따라가는 중일 때만 카메라를 건드립니다.
        private void UpdateCamera()
        {
            if (_camTo == null)
            {
                if (_track != null) FollowPoint(_track());
                return;
            }

            if (_track != null)
            {
                Data.Vector3D g = _track();
                _camTo[0] = g.X; _camTo[1] = g.Y; _camTo[2] = g.Z;
            }
            double k = Math.Min(1, (_clock.Elapsed.TotalSeconds - _camStart) / _shotSec);
            double e = k * k * k * (k * (k * 6 - 15) + 10);
            double[] v = new double[6];
            for (int i = 0; i < 5; i++) v[i] = _camFrom[i] + (_camTo[i] - _camFrom[i]) * e;
            v[5] = Math.Exp(Math.Log(_camFrom[5]) + (Math.Log(_camTo[5]) - Math.Log(_camFrom[5])) * e);
            Orbit(v);
            if (k >= 1) _camTo = null;
        }

        // 주시점만 목표 쪽으로 부드럽게 옮김 (방위·고도·거리는 지금 카메라 그대로)
        private void FollowPoint(Data.Vector3D goal)
        {
            double[] c = ReadCamera();
            c[0] += (goal.X - c[0]) * 0.06;
            c[1] += (goal.Y - c[1]) * 0.06;
            c[2] += (goal.Z - c[2]) * 0.06;
            Orbit(c);
        }

        // 지금 카메라를 주시점·방위·고도·거리로 읽음
        private double[] ReadCamera()
        {
            Data.CameraData c = vizcore3dx.View.GetCameraData();
            double ex = c.EyePosition.X, ey = c.EyePosition.Y, ez = c.EyePosition.Z;
            double dx = c.CameraDirection.X, dy = c.CameraDirection.Y, dz = c.CameraDirection.Z;
            double dl = Math.Sqrt(dx * dx + dy * dy + dz * dz);
            dx /= dl; dy /= dl; dz /= dl;
            double dist = (c.PivotPosition.X - ex) * dx + (c.PivotPosition.Y - ey) * dy + (c.PivotPosition.Z - ez) * dz;
            if (dist < 500) dist = 5000;
            double tx = ex + dx * dist, ty = ey + dy * dist, tz = ez + dz * dist;
            double az = Math.Atan2(ey - ty, ex - tx) * 180 / Math.PI;
            double el = Math.Asin(Math.Max(-1, Math.Min(1, (ez - tz) / dist))) * 180 / Math.PI;
            return new[] { tx, ty, tz, az, el, dist };
        }

        // 트인 구도 찾기: 방위를 돌리고 고도를 낮춰 보고, 다 막히면 가장 멀리 트인 쪽에서 가까이 붙음 → { 방위, 고도, 거리 }
        private double[] Fit(Data.Vector3D[] ts, double az, double el, double dist)
        {
            double[] best = { az, el, 0 };
            foreach (double e in new[] { el, el - 8, el - 15 })
            {
                if (e < 8) continue;
                foreach (double d in new double[] { 0, 25, -25, 50, -50, 80, -80, 120, -120, 180 })
                {
                    double free = ts.Min(t => FreeDist(t, az + d, e, dist));
                    if (free >= dist) return new[] { az + d, e, dist };
                    if (free > best[2] + 300) best = new[] { az + d, e, free };
                }
            }
            return best;
        }

        // 주시점에서 눈 쪽으로 광선을 쏴 막히기 전까지 쓸 수 있는 거리 (주시점 바로 옆 0.6 m 는 무시)
        private double FreeDist(Data.Vector3D t, double az, double el, double dist)
        {
            const float skip = 600f, margin = 400f, min = 2000f;
            double a = az * Math.PI / 180, e = el * Math.PI / 180;
            float dx = (float)(Math.Cos(e) * Math.Cos(a)), dy = (float)(Math.Cos(e) * Math.Sin(a)), dz = (float)Math.Sin(e);
            var ray = new Data.Ray3D(
                new Data.Vector3D(t.X + dx * skip, t.Y + dy * skip, t.Z + dz * skip),
                new Data.Vector3D(dx, dy, dz));
            Data.RaycastHit h = vizcore3dx.Object3D.Raycast(ray, null, new Data.RaycastOptions { MaxDistance = (float)dist - skip });
            if (h == null) return dist;
            double hx = h.Position.X - t.X, hy = h.Position.Y - t.Y, hz = h.Position.Z - t.Z;
            return Math.Max(min, Math.Sqrt(hx * hx + hy * hy + hz * hz) - margin);
        }

        private void Orbit(double[] v)
        {
            double az = v[3] * Math.PI / 180, el = v[4] * Math.PI / 180;
            double ex = v[0] + v[5] * Math.Cos(el) * Math.Cos(az);
            double ey = v[1] + v[5] * Math.Cos(el) * Math.Sin(az);
            double ez = v[2] + v[5] * Math.Sin(el);
            double dx = v[0] - ex, dy = v[1] - ey, dz = v[2] - ez;
            double len = Math.Sqrt(dx * dx + dy * dy + dz * dz);
            dx /= len; dy /= len; dz /= len;

            // 위쪽은 세계 Z 기준 (화면이 기울지 않게)
            double ux = -dz * dx, uy = -dz * dy, uz = 1 - dz * dz;
            double ul = Math.Sqrt(ux * ux + uy * uy + uz * uz);
            Data.CameraData cam = vizcore3dx.View.GetCameraData();
            cam.EyePosition = new Data.Vertex3D((float)ex, (float)ey, (float)ez);
            cam.CameraDirection = new Data.Vertex3D((float)dx, (float)dy, (float)dz);
            cam.PivotPosition = new Data.Vertex3D((float)v[0], (float)v[1], (float)v[2]);
            cam.UpDirection = new Data.Vertex3D((float)(ux / ul), (float)(uy / ul), (float)(uz / ul));
            vizcore3dx.View.SetCameraData(cam);
        }

        #endregion

        #region Helpers

        // 작업 현장이 열린 모델 안에 있고 바닥 지도를 준비했는지 확인합니다.
        private bool IsModelReady()
        {
            if (_map == null) return false;   // 준비에 실패한 사유는 SetupModel 이 상태에 남겼습니다.

            Data.BoundBox3D model = vizcore3dx.Object3D.GetBoundBox(vizcore3dx.Object3D.GetRootNodes());
            if (model != null && model.Contains(ScenarioScript.WorkArea.GetCenter())) return true;

            SetStatus("작업 현장이 모델 밖에 있습니다. 샘플 모델 AftSection 을 열거나 ScenarioScript.cs 의 좌표를 바꿔 주세요.");
            return false;
        }

        // 모델이 열려 있는지 확인하고, 아니면 상태줄에 알립니다.
        private bool IsModelOpened()
        {
            if (vizcore3dx.Model.IsOpen()) return true;

            SetStatus("모델을 먼저 열어 주세요.");
            return false;
        }

        private void SetStatus(string text)
        {
            Text = "VIZCore3DX.NET.Scenario.Safety — " + text;
        }

        // 진행 문구를 3D 뷰 왼쪽 위에 띄웁니다. 집결지·작업 구역이 있으면 그 안의 인원을 뒤에 붙입니다.
        private void Report(string message)
        {
            _hudText = message.Trim();
            RefreshHud();
        }

        // 지금 문구 뒤에 Zone 안의 인원을 붙여 다시 띄웁니다. Zone 이벤트가 올 때마다 부릅니다.
        private void RefreshHud()
        {
            if (_hudText == null) { ClearHud(); return; }

            string count = _muster >= 0 ? string.Format("집결 {0}/{1}명", vizcore3dx.Zone.GetContents(_muster).Count, _all.Length)
                         : _zone >= 0 ? string.Format("구역 안 {0}명 · 허가 2명", vizcore3dx.Zone.GetContents(_zone).Count)
                         : "";
            ShowHud(count.Length == 0 ? _hudText : _hudText + "   (" + count + ")");
        }

        // 3D 뷰 왼쪽 위에 문구 하나를 띄웁니다. 밝은 장면에서도 읽히도록 어두운 상자에 얹은 화면 고정 노트입니다. 이전 문구는 지웁니다.
        private void ShowHud(string text)
        {
            ClearHud();
            Data.NoteCustomStyle style = vizcore3dx.Note.CreateCustomStyle();
            style.BoxFillColor = ScenarioScript.ColorPanel;
            style.BoxStrokeColor = ScenarioScript.ColorAccent;
            style.TextColor = ScenarioScript.HudColor;
            style.TextSize = ScenarioScript.HudTextSize;
            style.TextHorizontalAlignment = Data.HorizontalAlignment.Left;

            // 상자 왼쪽 위 모서리를 여백에 맞춥니다. 상자 크기는 노트와 같은 계산으로 SDK 가 구합니다(기준점 TopLeft).
            Size view = RenderSize();
            float x = ScenarioScript.HudMarginPixels / view.Width;
            float y = ScenarioScript.HudMarginPixels / view.Height;
            _hudNote = vizcore3dx.Note.AddNote2D(text, x, y, style, ContentAlignment.TopLeft);
        }

        // 3D 화면(렌더 영역) 크기 — 처음 한 번 렌더 결과에서 읽어 둡니다.
        private Size RenderSize()
        {
            if (_renderSize.IsEmpty)
            {
                using (Image image = vizcore3dx.View.CaptureRenderImage(true))
                    _renderSize = image == null ? new Size(1684, 821) : image.Size;
            }
            return _renderSize;
        }

        // 3D 뷰 왼쪽 위 문구를 지웁니다.
        private void ClearHud()
        {
            if (_hudNote != 0) vizcore3dx.Note.Delete(new List<uint> { _hudNote });
            _hudNote = 0;
        }

        // 리본과 3D 화면만 남김: 뷰 툴바·모델 트리·속성 패널·상태바 숨김
        private void HideViewerUI()
        {
            vizcore3dx.View.Toolbar.Enable = false;
            vizcore3dx.ModelingControlVisible = false;
            vizcore3dx.ModelTreeVisible = false;
            vizcore3dx.AttributePanelVisible = false;
            vizcore3dx.Statusbar.Visible = false;
        }

        // 홈 탭만 남기고 나머지 툴바(=리본 탭)와 모델 트리 패널의 탭을 숨깁니다.
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

        // 속성 패널은 끕니다. 이 예제는 3D 뷰만 씁니다.
        private void ShowAttributeTabs()
        {
            vizcore3dx.TabAttributeTreeEnabled = false;
            vizcore3dx.TabNodeGroupEnabled = false;
            vizcore3dx.TabProjectionEnabled = false;
            vizcore3dx.TabPmiEnabled = false;
            vizcore3dx.TabEnvironmentEnabled = false;
            vizcore3dx.TabGenericDataEnabled = false;
            vizcore3dx.AttributePanelVisible = false;
        }

        private static float Sq(float v) { return v * v; }

        #endregion
    }
}
