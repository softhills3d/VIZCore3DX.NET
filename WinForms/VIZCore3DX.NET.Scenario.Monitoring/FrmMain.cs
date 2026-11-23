using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Scenario.Monitoring
{
    // 시나리오 예제 "기관실 모니터링 — 누수 · 출입 금지 구역 침입"
    // 기관실을 CCTV 2대·레이더·가스 감지기로 감시하다가 누수와 출입 금지 구역 침입을 감지하고,
    // 그 센서 화면을 크게 확대한 뒤 작업자가 가서 조치합니다.
    // 분할 화면 4개(View.SetSubView)에 센서마다 옵저버 시점을 두고, 이펙트는 Effect.SetViewEnabled 로 분할 화면 모두에 표시합니다.
    // 장면의 값(설명·길이·좌표·사람 배치)은 ScenarioScript.cs 한 곳에, 재생은 ScenarioRunner.cs 에 있습니다.
    //
    // ── 이 예제에서 SDK 사용을 보려면 ──
    // · 옵저버 센서(CCTV·레이더·가스 감지기) 배치: PlaceSensors()
    // · 센서가 그 점을 보는지 판정: FirstSeeing()
    // · 분할 화면에 센서 시점 띄우기: ShowSplit(), ShowSingle()
    // · 출입 금지 구역(Zone)과 출입 이벤트: CreateNoGo(), Zone_OnZoneContentChanged()
    // · 분할 화면 모두에 이펙트 표시: InitializeVIZCore3DX()
    // 장면 재생·리본·시계·카메라 연출(ScenarioRunner.cs, ScenarioRibbon.cs, Cues.cs, ZoomTo 등)과 걷기용 바닥 지도(FloorMap.cs, FloorData.cs)는 연출용이니 건너뛰어도 됩니다.
    // Crew.cs 는 아바타 API(Avatar.Place·SetPosture 등)로 작업자를 놓고 걷게 하므로, 아바타 사용을 보려면 함께 봅니다.
    // 다른 모델에 쓰려면: 센서 좌표·출입 금지 구역(ScenarioScript.cs)과 바닥 격자(FloorData.cs)가 샘플 모델 전용이라 값을 바꿔야 합니다.
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 조작부 — 리본 사용자 탭 "시나리오" (뷰어 초기화 뒤에 만듭니다)
        private ScenarioRibbon _ribbon;

        // 대본과 재생기
        private List<ScenarioShot> _shots;
        private ScenarioRunner _runner;

        // 진행 시계 — 장면과 상관없이 계속 도는 타임라인·작업자 걸음·화면 확대·스피너 (모델을 연 뒤 한 번 시작합니다)
        // 걷기가 끝났을 때처럼 장면 밖에서 오는 동작의 지연은 재생기가 아니라 이 타임라인(_cues)에 겁니다.
        private readonly Cues _cues = new Cues();
        private readonly Timer _tick = new Timer();
        private FloorMap _map;
        private Crew _crew;
        private string _setupError;

        // 처음으로 되돌릴 때마다 바뀌는 번호 — 비동기 작업이 끝났을 때 아직 같은 재생인지 확인합니다.
        private int _run;

        // 센서: 분할 화면 i 는 _order[i] 센서의 시점 (0 CAM 1, 1 CAM 2, 2 RADAR 1, 3 GD 1)
        private int _camA = -1, _camB = -1, _radar = -1, _gas = -1;
        private int[] _order;

        // 레이더 자리: 레이더 표식 안에 시점 카메라가 묻히므로 4분할에서 마지막에 들어가 표식을 숨김
        private const int RadarSlot = 2;

        // 정비사가 설 자리, 신호수 자리, 누수를 보는 화면 (CAM 2 고정)
        private Data.Vector3D _techSpot, _signalSpot;
        private int _leakView = 1;

        // 작업자
        private Person _techA, _techB, _signal, _workerC;

        // 진행 상태
        private bool _working, _gasAlarm;
        private bool _intrusionArmed, _intruded, _exited, _escorting, _intruderMarked;

        // 선행 장면이 끝났는지 — 번호 버튼이 선행 장면을 기다릴 때 씁니다.
        private bool _signalArrived, _techArrived, _leakCleared, _signalBack, _intruderZoomed;

        // 이펙트 아이디 (0 이면 없음)
        private uint _jet, _steam, _cloud, _leakMark, _gdPulse, _gdLabel, _spinner;
        private double _spinStart = -1, _spinSec;

        // 출입 금지 구역 Zone 아이디
        private int _noGoZone = -1;
        private bool _zoneHooked;

        // 3D 뷰에 띄운 문구 (장면 안의 문구 + 가스 감지기 상태 · 구역 안 인원)
        private uint _hudNote;
        private string _hudText;
        private string _beat = "";
        private Size _renderSize;

        // 크게 띄운 화면(-1 이면 4분할)과 확대(PTZ): 렌즈 자리는 두고 시선 방향·화각만 보간
        private int _zoomed = -1;
        private Data.CameraData _homeCamera;
        private Data.Vector3D _eye;
        private double[] _ptzFrom, _ptzTo;
        private double _ptzStart, _ptzSec;
        private readonly Stopwatch _clock = Stopwatch.StartNew();

        // 렌즈 효과: 화면 테두리를 어둡게(비네트) 또는 흐리게(블러). 자리마다 정합니다.
        private enum Lens { None, Vignette, Blur }
        private readonly Lens[] _lens = new Lens[4];

        // 4분할에서 화면 자리(0 왼쪽 위, 1 오른쪽 위, 2 왼쪽 아래, 3 오른쪽 아래)에 놓이는 분할 화면 번호
        private static readonly int[] SubViewAt = { 0, 1, 3, 2 };

        // 센서 표식(최대 크기 0.45 m) 밖으로 카메라를 빼는 거리(mm)
        private const float FigureClearMm = 600f;

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
            HideViewerUI();

            // 이펙트는 기본으로 메인 뷰(0)에만 그려지므로 분할 화면 1~3 에도 켭니다. 화면을 나누기 전에 켜 두어도 됩니다.
            for (int i = 1; i <= 3; i++) vizcore3dx.View.Effect.SetViewEnabled(i, true);

            vizcore3dx.Zone.OnZoneContentChangedEvent += Zone_OnZoneContentChanged;
            _zoneHooked = true;

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
            ScenarioScript.Watch.Play = SceneWatch;
            ScenarioScript.Leak.Play = SceneLeak;
            ScenarioScript.LeakZoom.Play = SceneLeakZoom;
            ScenarioScript.DispatchA.Play = SceneDispatchA;
            ScenarioScript.Repair.Play = SceneRepair;
            ScenarioScript.Resume.Play = SceneResume;
            ScenarioScript.Intrusion.Play = SceneIntrusion;
            ScenarioScript.IntruderZoom.Play = SceneIntruderZoom;
            ScenarioScript.Escort.Play = SceneEscort;
            ScenarioScript.AllClear.Play = SceneAllClear;

            // 번호 버튼으로 바로 볼 때 먼저 실행할 장면 — 모든 장면은 작업자를 놓는 01 이, 누수 장면은 02 가, 침입 장면은 07 이 먼저입니다.
            ScenarioScript.Leak.Before = new[] { 1 };
            ScenarioScript.LeakZoom.Before = new[] { 1, 2 };
            ScenarioScript.DispatchA.Before = new[] { 1, 2 };
            ScenarioScript.Repair.Before = new[] { 1, 2, 4 };
            ScenarioScript.Resume.Before = new[] { 1, 2, 4, 5 };
            ScenarioScript.Intrusion.Before = new[] { 1 };
            ScenarioScript.IntruderZoom.Before = new[] { 1, 7 };
            ScenarioScript.Escort.Before = new[] { 1, 7 };
            ScenarioScript.AllClear.Before = new[] { 1, 7, 9 };

            // 걷기·화면 확대·구역 출입은 장면이 끝난 뒤에 이루어지므로, 선행 장면으로 실행할 때 끝날 때까지 기다립니다.
            ScenarioScript.Leak.IsDone = () => _signalArrived;
            ScenarioScript.LeakZoom.IsDone = () => _ptzTo == null;
            ScenarioScript.DispatchA.IsDone = () => _techArrived;
            ScenarioScript.Repair.IsDone = () => _leakCleared;
            ScenarioScript.Resume.IsDone = () => _signalBack;
            ScenarioScript.Intrusion.IsDone = () => _intruded;
            ScenarioScript.IntruderZoom.IsDone = () => _intruderZoomed && _ptzTo == null;
            ScenarioScript.Escort.IsDone = () => _exited;

            return new List<ScenarioShot>
            {
                ScenarioScript.Watch, ScenarioScript.Leak, ScenarioScript.LeakZoom, ScenarioScript.DispatchA, ScenarioScript.Repair,
                ScenarioScript.Resume, ScenarioScript.Intrusion, ScenarioScript.IntruderZoom, ScenarioScript.Escort, ScenarioScript.AllClear,
            };
        }

        // 창을 닫을 때 재생 타이머부터 멈추고 구역 이벤트를 뗍니다.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _tick.Stop();
            _runner.Reset();
            if (_zoneHooked) vizcore3dx.Zone.OnZoneContentChangedEvent -= Zone_OnZoneContentChanged;
            _zoneHooked = false;
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

        // 리본과 3D 화면만 남김: 옆 뷰 툴바·모델 트리·속성 패널·상태바 숨김
        // 분할 화면을 만들면 뷰 툴바가 다시 보이므로 화면을 바꿀 때마다 부릅니다.
        private void HideViewerUI()
        {
            vizcore3dx.View.Toolbar.Enable = false;
            vizcore3dx.ModelingControlVisible = false;
            vizcore3dx.ModelTreeVisible = false;
            vizcore3dx.AttributePanelVisible = false;
            vizcore3dx.Statusbar.Visible = false;
        }

        #endregion

        #region 1. 모델

        // 샘플 선박 모델(선미부)을 열고 센서·출입 금지 구역을 준비합니다.
        private void Ribbon_OpenModel()
        {
            if (_runner.IsPlaying) return;

            ClearScene();
            if (!vizcore3dx.Model.OpenFileDialog()) { SetStatus("모델을 열지 못했습니다."); return; }
            SetupModel();

            if (!IsModelReady()) return;
            SetStatus("준비됐습니다. 전체 재생이나 장면 버튼을 누르세요.");
        }

        // 모델을 연 뒤 한 번: 바닥 지도·센서 4개·출입 금지 구역·렌즈·4분할을 준비하고 진행 시계를 켭니다.
        private void SetupModel()
        {
            _map = null;
            _crew = null;
            _setupError = null;
            HideViewerUI();

            // 누수·센서 자리는 샘플 모델에 맞춘 값이라, 그 자리가 모델 밖이면 준비하지 않습니다.
            Data.BoundBox3D box = vizcore3dx.Object3D.GetBoundBox(vizcore3dx.Object3D.GetRootNodes());
            Data.Vector3D leak = ScenarioScript.LeakPoint;
            if (leak.X < box.MinX || leak.X > box.MaxX || leak.Y < box.MinY || leak.Y > box.MaxY || leak.Z < box.MinZ || leak.Z > box.MaxZ) return;

            Crew.EnsurePreset(vizcore3dx);

            // 처음 아바타를 놓을 때 모델·동작을 읽느라 오래 걸리므로, 모델을 열 때 한 번 놓았다 지워 미리 읽어 둠
            vizcore3dx.Avatar.Place(Crew.PresetName, new Data.Vector3D(0, 0, 0), 0);
            vizcore3dx.Avatar.Clear();

            try
            {
                _map = new FloorMap(vizcore3dx, ScenarioScript.Deck);
                _map.Load();
                _crew = new Crew(vizcore3dx, _map, _cues) { InNoGo = NoGoContains };
                PlaceSensors();
                _order = new[] { _camA, _camB, _radar, _gas };
                _techSpot = _map.Snap(leak.X, leak.Y + ScenarioScript.TechSpotOffsetY);

                // 누수 지점이 보이는 CCTV 는 CAM 2 (미리 확인한 값)
                _leakView = Array.IndexOf(_order, _camB);

                _lens[0] = Lens.Vignette;
                _lens[1] = Lens.Blur;
                ShowSplit(_order, RadarSlot);
                CreateNoGo();
                _tick.Start();
            }
            catch (Exception ex)
            {
                _map = null;
                _setupError = "장면을 준비하지 못했습니다: " + ex.Message;
            }
        }

        // 바닥 지도·센서·구역이 준비됐는지 확인합니다.
        private bool IsModelReady()
        {
            if (_map != null) return true;

            SetStatus(_setupError ?? "누수·센서 자리를 이 모델에서 찾지 못했습니다. 샘플 선박 모델(AftSection_RevA.vizx)을 열거나 ScenarioScript.cs 의 좌표를 바꿔 주세요.");
            return false;
        }

        #endregion

        #region 2. 센서

        private void PlaceSensors()
        {
            vizcore3dx.Observer.Clear();
            _camA = vizcore3dx.Observer.AddSensor(Data.ObserverSensorType.Cctv, ScenarioScript.CamAPosition, ScenarioScript.CamADirection, ScenarioScript.NameCamA, Data.ObserverCctvStyle.Dome, null);
            _camB = vizcore3dx.Observer.AddSensor(Data.ObserverSensorType.Cctv, ScenarioScript.CamBPosition, ScenarioScript.CamBDirection, ScenarioScript.NameCamB, Data.ObserverCctvStyle.Bullet, ScenarioScript.CamBMount);
            _radar = vizcore3dx.Observer.AddSensor(Data.ObserverSensorType.Radar, ScenarioScript.RadarPosition, ScenarioScript.RadarDirection, ScenarioScript.NameRadar, Data.ObserverCctvStyle.Box, ScenarioScript.RadarMount);
            _gas = vizcore3dx.Observer.AddSensor(Data.ObserverSensorType.GasDetector, ScenarioScript.GasPosition, ScenarioScript.GasDirection, ScenarioScript.NameGas, Data.ObserverCctvStyle.Dome, null);
            foreach (int id in new[] { _camA, _camB })
            {
                Data.ObserverItem it = vizcore3dx.Observer.GetItem(id);
                it.HorizontalAngleDeg = ScenarioScript.CctvH;
                it.VerticalAngleDeg = ScenarioScript.CctvV;      // 옵저버 시점 화면의 세로 화각
                it.MaxDistanceMm = ScenarioScript.CctvRange;
                it.EffectiveDistanceMm = ScenarioScript.CctvRange;
            }
            foreach (int id in new[] { _camA, _camB, _radar, _gas }) vizcore3dx.Observer.GetItem(id).SizeMm = ScenarioScript.SensorSizeMm;
            Data.ObserverItem ri = vizcore3dx.Observer.GetItem(_radar);
            ri.HorizontalAngleDeg = ScenarioScript.RadarH;
            ri.VerticalAngleDeg = ScenarioScript.RadarV;
            ri.MaxDistanceMm = ScenarioScript.RadarDistance + ScenarioScript.RadarRangeExtra;
            Data.ObserverItem gi = vizcore3dx.Observer.GetItem(_gas);
            gi.MaxDistanceMm = ScenarioScript.GasRange;
            gi.EffectiveDistanceMm = ScenarioScript.GasRange;

            // 판정 범위는 레이더·가스 감지기만 표시 (CCTV 는 끔)
            vizcore3dx.Observer.ShowRange(_radar);
            vizcore3dx.Observer.ShowRange(_gas);
        }

        // 점 여러 개 중 하나라도 보이는 첫 센서
        private async Task<int> FirstSeeing(int[] ids, params Data.Vector3D[] points)
        {
            foreach (int id in ids)
                foreach (Data.Vector3D p in points)
                    if (await vizcore3dx.Observer.IsPointVisibleAsync(id, p, System.Threading.CancellationToken.None)) return id;
            return -1;
        }

        private string SensorName(int id) { return vizcore3dx.Observer.GetItem(id).Name; }

        // 출입 금지 구역을 Zone 으로 만들고, 작업자가 드나드는 것을 Zone 이 알려 주게 함
        private void CreateNoGo()
        {
            vizcore3dx.Zone.Clear();
            _noGoZone = vizcore3dx.Zone.CreateZoneFromBoundBox(ScenarioScript.NoGo, ScenarioScript.NoGoName);

            // 구역 안에 선 작업자가 경계면에 가려지지 않게
            vizcore3dx.Zone.SetDepthTestEnabled(_noGoZone, false);
            vizcore3dx.Zone.ContentWatchMode = Data.ContentWatchMode.Auto;
            AlertNoGo(false);
        }

        // 평소에는 주황, 경보 중에는 빨강
        private void AlertNoGo(bool alert)
        {
            if (_noGoZone < 0) return;
            Color color = alert ? ScenarioScript.Red : ScenarioScript.Orange;
            vizcore3dx.Zone.SetColor(_noGoZone, color, color);
        }

        // 작업자 C 가 출입 금지 구역에 들어오거나 나간 사실만 기록하고 구역 색을 바꿉니다. 침입 장면(07)이 시작된 뒤에만 반응합니다.
        private void Zone_OnZoneContentChanged(object sender, VIZCore3DX.NET.Event.EventManager.ContentChangedEventArgs e)
        {
            if (InvokeRequired) { BeginInvoke(new Action(() => Zone_OnZoneContentChanged(sender, e))); return; }

            if (_intrusionArmed && _workerC != null)
            {
                if (!_intruded && e.Entered.Any(IsWorkerC)) OnIntrusion();
                else if (_intruded && e.Exited.Any(IsWorkerC)) OnExit();
            }
            RefreshHud();
        }

        private bool IsWorkerC(Data.ContentItem item) { return item.ContainerID == _noGoZone && item.ContentID == _workerC.Id; }

        private bool NoGoContains(Data.Vector3D p, float margin)
        {
            Data.BoundBox3D noGo = ScenarioScript.NoGo;
            return p.X > noGo.MinX - margin && p.X < noGo.MaxX + margin && p.Y > noGo.MinY - margin && p.Y < noGo.MaxY + margin;
        }

        // 레이더 원뿔(거리·반각) 안인지
        private bool InRadar(Data.Vector3D p)
        {
            Data.ObserverItem r = vizcore3dx.Observer.GetItem(_radar);
            double dx = p.X - r.Position.X, dy = p.Y - r.Position.Y, dz = p.Z - r.Position.Z, l = Math.Sqrt(dx * dx + dy * dy + dz * dz);
            Data.Vector3D d = Geo.Norm(r.Direction);
            double angle = Math.Acos(Math.Max(-1, Math.Min(1, (dx * d.X + dy * d.Y + dz * d.Z) / l))) * 180 / Math.PI;
            return l <= r.MaxDistanceMm && angle <= r.HorizontalAngleDeg / 2;
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

        // 진행 시계 — 재생기와 상관없이 계속 돕니다(번호 버튼이 선행 장면의 걷기를 기다리는 동안에도).
        private void Tick_Tick(object sender, EventArgs e)
        {
            try
            {
                _cues.Run();
                if (_crew != null) _crew.Update();
                UpdateZoom();
                UpdateSpinner();
            }
            catch (Exception ex)
            {
                SetStatus("오류: " + ex.Message);
            }
        }

        #endregion

        #region 장면

        // 01 — 평상시: 사람마다 다른 작업을 제자리에서 되풀이하고, 순찰자가 두 지점 사이를 오갑니다. 4분할로 센서 화면을 봅니다.
        private void SceneWatch()
        {
            ClearStage();
            _working = true;

            foreach (WorkerSpot w in ScenarioScript.Workers)
                _crew.WorkLoop(_crew.SpawnFit(w.X, w.Y, w.Heading, w.FitPosture, w.Name), w.WorkPosture, w.Kind, w.Scale);

            _signalSpot = _map.Fit(ScenarioScript.SignalX, ScenarioScript.SignalY, ScenarioScript.SignalHeading, FloorMap.Reach(ScenarioScript.SignalFitPosture));
            _signal = _crew.Spawn(_signalSpot, ScenarioScript.SignalHeading, ScenarioScript.SignalName);
            _crew.SignalLoop(_signal, ScenarioScript.SignalHeading);
            _techA = _crew.SpawnFit(ScenarioScript.TechAX, ScenarioScript.TechAY, ScenarioScript.TechAHeading, ScenarioScript.StandFitPosture, ScenarioScript.TechAName);
            _crew.IdleWork(_techA, ScenarioScript.TechAHeading, false);
            _techB = _crew.SpawnFit(ScenarioScript.TechBX, ScenarioScript.TechBY, ScenarioScript.TechBHeading, ScenarioScript.StandFitPosture, ScenarioScript.TechBName);
            _workerC = _crew.SpawnFit(ScenarioScript.WorkerCX, ScenarioScript.WorkerCY, ScenarioScript.WorkerCHeading, ScenarioScript.StandFitPosture, ScenarioScript.WorkerCName);
            _crew.Posture(_workerC, ScenarioScript.WorkerCPosture);

            // 순찰자: 두 지점 사이를 계속 오감 (출입 금지 구역은 피해 감)
            foreach (Tuple<float, float, float, float, double, string> patrol in ScenarioScript.Patrols)
            {
                Data.Vector3D from = _map.Snap(patrol.Item1, patrol.Item2), to = _map.Snap(patrol.Item3, patrol.Item4);
                Patrol(_crew.Spawn(from, patrol.Item5, patrol.Item6), from, to);
            }

            AlertNoGo(false);
            ShowSplit(_order, RadarSlot);
            Beat(ScenarioScript.TextWatch);
        }

        // from 에 있는 사람이 to 까지 걸어가 잠깐 섰다가 되돌아오기를 되풀이
        private void Patrol(Person p, Data.Vector3D from, Data.Vector3D to)
        {
            _crew.Walk(p, to, () =>
            {
                int token = p.Token;
                _cues.After(ScenarioScript.PatrolPauseSec, () => { if (_crew.Live(p, token)) Patrol(p, to, from); });
            });
        }

        // 02 — 신호수 옆 배관에서 누수 → 신호수가 손을 들어 알리고 물러나 지켜봄 → 가스 감지기 경보
        private void SceneLeak()
        {
            Data.Vector3D leak = ScenarioScript.LeakPoint;

            // 물줄기: 통로 쪽으로 뿜어져 바닥으로 떨어지는 물방울 입자 (AddWaterJet 은 만들 때 화면이 몇 초 멈춰서 쓰지 않음)
            Data.Vector3D toAisle = Geo.Norm(new Data.Vector3D(_techSpot.X - leak.X, _techSpot.Y - leak.Y, 0));
            var water = new Data.ParticleOptions(Data.ParticlePreset.Drip)
            {
                Direction = Geo.Norm(new Data.Vector3D(toAisle.X, toAisle.Y, 0.15f)),
                ConeAngleDeg = 12,
                SpeedMinMmPerSec = 1400,
                SpeedMaxMmPerSec = 2200,
                GravityMmPerSec2 = -9810,
                LifetimeMinSec = 0.5f,
                LifetimeMaxSec = 0.68f,
                StartColor = ScenarioScript.WaterStartColor,
                EndColor = ScenarioScript.WaterEndColor,
                Group = Group,
            };
            water.RatePerSec *= 4;
            _jet = Effect.AddParticleEmitter(leak, water);
            _steam = Effect.AddParticleEmitter(leak, new Data.ParticleOptions(Data.ParticlePreset.Steam) { Group = Group });
            // 가스 구름은 물줄기를 가리지 않게 누수 지점보다 조금 위에
            _cloud = Effect.AddGasCloud(Geo.Up(leak, 900), new Data.GasCloudOptions { MinRadius = 500, MaxRadius = 2200, PeriodMs = 3000, Color = ScenarioScript.GasColor, Opacity = 0.35f, Group = Group });
            Beat(ScenarioScript.TextLeak);

            // 신호수가 손을 들어 알리고, 물러나서 가리키며 지켜봄 (걷기·돌아서기가 끝난 뒤의 동작은 진행 시계에 겁니다)
            int token = _crew.NewToken(_signal);
            _crew.TurnTo(_signal, token, leak, () =>
            {
                _crew.Posture(_signal, "Hands Up");
                _cues.After(ScenarioScript.SignalRaiseSec, () =>
                {
                    if (!_crew.Live(_signal, token)) return;
                    _crew.Walk(_signal, _map.Snap(ScenarioScript.SignalWatchX, ScenarioScript.SignalWatchY), () =>
                    {
                        _signalArrived = true;
                        _crew.WatchLoop(_signal, leak);
                    });
                });
            });

            _runner.After(ScenarioScript.GasAlarmAt, GasAlarm);
        }

        private void GasAlarm()
        {
            Data.Vector3D leak = ScenarioScript.LeakPoint;
            Data.Vector3D at = vizcore3dx.Observer.GetItem(_gas).Position;
            _gdPulse = Effect.AddPulseSphere(at, new Data.PulseSphereOptions { MinRadius = 300, MaxRadius = 1400, PeriodMs = 600, Color = ScenarioScript.Red, Opacity = 0.6f, Group = Group });
            _gdLabel = Effect.AddTextLabel(Geo.Up(at, -1100), ScenarioScript.LabelGas, new Data.TextLabelOptions { SizePx = ScenarioScript.GasLabelSizePx, TextColor = Color.White, BackColor = ScenarioScript.Red, BlinkIntervalMs = 350, Group = Group });
            _leakMark = Effect.AddMarker(Geo.Up(leak, 1000), Data.MarkerIcon.Gas, new Data.MarkerOptions { SizePx = ScenarioScript.MarkerSizePx, BlinkIntervalMs = 400, Label = ScenarioScript.LabelLeak, Group = Group });
            _gasAlarm = true;
            Beat(string.Format(ScenarioScript.TextGasAlarm, Geo.Dist3(at, leak) / 1000));
        }

        // 03 — 누수가 보이는 CCTV(CAM 2) 화면을 크게 띄우고 누수 쪽으로 확대합니다.
        private void SceneLeakZoom()
        {
            string name = SensorName(_order[_leakView]);
            Beat(string.Format(ScenarioScript.TextLeakZoom, name));
            ZoomTo(_leakView, _order[_leakView], ScenarioScript.LeakPoint, ScenarioScript.ZoomFov, ScenarioScript.ZoomSec);
        }

        // 04 — 정비사 A 가 누수 앞으로 달려가 누수 쪽으로 돌아섭니다.
        private void SceneDispatchA()
        {
            Beat(ScenarioScript.TextDispatchA);
            _techA.Speed = ScenarioScript.HurrySpeed;
            _crew.Walk(_techA, _techSpot, () => _crew.TurnTo(_techA, _techA.Token, ScenarioScript.LeakPoint, () =>
            {
                _crew.Posture(_techA, "Hands Half Up");
                _techArrived = true;
            }));
        }

        // 05 — 조치 진행 표시(스피너)가 다 차면 누수 효과를 지우고 조치 완료 표식을 띄웁니다.
        private void SceneRepair()
        {
            Data.Vector3D leak = ScenarioScript.LeakPoint;
            Beat(string.Format(ScenarioScript.TextRepairing, SensorName(_order[_leakView])));
            StartSpinner(Geo.Up(leak, 600), ScenarioScript.RepairSec);

            _runner.After(ScenarioScript.RepairSec, () =>
            {
                StopSpinner();
                ClearLeak();
                _crew.Posture(_techA, "Seeing 30");
                Effect.AddMarker(Geo.Up(leak, 1000), Data.MarkerIcon.Check, new Data.MarkerOptions { SizePx = ScenarioScript.MarkerSizePx, Label = ScenarioScript.LabelRepaired, ExpireMs = 3500, Group = Group });
                _gasAlarm = false;
                _leakCleared = true;
                Beat(ScenarioScript.TextRepaired);
            });
        }

        // 06 — 신호수가 제자리로 돌아가 신호를 이어 가고, 정비사 A 는 그 자리에서 점검합니다. 4분할로 돌아갑니다.
        private void SceneResume()
        {
            _runner.After(ScenarioScript.ResumeSignalAt, () => _crew.Walk(_signal, _signalSpot, () =>
            {
                _signalBack = true;
                _crew.SignalLoop(_signal, ScenarioScript.SignalHeading);
            }));
            _runner.After(ScenarioScript.ResumeTechAt, () =>
            {
                _techA.Speed = ScenarioScript.WalkSpeed;
                Data.Vector3D p = _crew.Pos(_techA);
                _crew.IdleWork(_techA, Geo.Heading(ScenarioScript.LeakPoint.X - p.X, ScenarioScript.LeakPoint.Y - p.Y), false);
            });
            _runner.After(ScenarioScript.ResumeSplitAt, () =>
            {
                ShowSplit(_order, RadarSlot);
                Beat(ScenarioScript.TextResume);
            });
        }

        // 07 — 작업자 C 가 출입 금지 구역에 들어갑니다. 들어간 순간(구역 이벤트) 레이더가 감지해 구역이 빨갛게 바뀝니다.
        private void SceneIntrusion()
        {
            _intrusionArmed = true;
            _intruded = _exited = _escorting = _intruderMarked = false;

            // 작업자 C 쪽 경계에서 1.5 m 쯤 들어간, 레이더에 잡히는 칸
            Data.BoundBox3D noGo = ScenarioScript.NoGo;
            Data.Vector3D cp = _crew.Pos(_workerC);
            float cx = noGo.MinX + ScenarioScript.IntrudeDepth;
            float cy = Math.Max(noGo.MinY + ScenarioScript.IntrudeEdgeMargin, Math.Min(noGo.MaxY - ScenarioScript.IntrudeEdgeMargin, cp.Y));
            Point target = _map.Cells().Where(c => _map.Clearance(c) >= 2 && NoGoContains(_map.CellPos(c), ScenarioScript.IntrudeInnerMargin) && InRadar(Geo.Up(_map.CellPos(c), 1000)))
                                       .OrderBy(c => Sq(_map.CellPos(c).X - cx) + Sq(_map.CellPos(c).Y - cy))
                                       .DefaultIfEmpty(_map.ToCell(new Data.Vector3D(cx, cy, ScenarioScript.Deck))).First();
            _workerC.AllowNoGo = true;
            _crew.Walk(_workerC, _map.CellPos(target), () =>
            {
                _crew.Posture(_workerC, "Seeing 30");
                MarkIntruder();
            });
            Beat(ScenarioScript.TextIntruderMoving);
        }

        // 구역 이벤트 — 작업자 C 가 들어옴: 구역을 빨갛게, 침입 표시, 레이더 펄스
        private void OnIntrusion()
        {
            _intruded = true;
            AlertNoGo(true);
            MarkIntruder();
            Data.Vector3D radarAt = vizcore3dx.Observer.GetItem(_radar).Position;
            Effect.AddPulseSphere(radarAt, new Data.PulseSphereOptions { MinRadius = 250, MaxRadius = 1100, PeriodMs = 500, Color = ScenarioScript.RadarPulseColor, Opacity = 0.6f, ExpireMs = 3000, Group = Group });
            Beat(ScenarioScript.TextIntrusion);
        }

        // 침입 경보 문구·링은 작업자 C 가 멈춰 선 자리에 띄움 (다시 걸으면 함께 지워짐)
        private void MarkIntruder()
        {
            if (!_intruded || _escorting || _intruderMarked || _workerC.Path != null) return;
            _intruderMarked = true;
            Data.Vector3D p = _crew.Pos(_workerC);
            _crew.Own(_workerC, Effect.AddTextLabel(Geo.Up(p, 2300), ScenarioScript.LabelIntrusion, new Data.TextLabelOptions { SizePx = ScenarioScript.LabelSizePx, TextColor = Color.White, BackColor = ScenarioScript.Red, BlinkIntervalMs = 350, Group = Group }), id => Effect.RemoveTextLabel(id));
            _crew.Own(_workerC, Effect.AddGroundRing(p, new Data.GroundRingOptions { RadiusMm = 1100, LineWidth = 4f, Color = ScenarioScript.Red, FloorZ = p.Z, RippleCount = 3, PeriodMs = 800, ShowStem = false, Group = Group }), id => Effect.RemoveGroundRing(id));
        }

        // 08 — 작업자 C 가 보이는 CCTV 를 찾아 그 화면을 크게 띄우고 침입자 쪽으로 확대합니다. 구역 이벤트 전이어도 지금 자리로 확대합니다.
        private async void SceneIntruderZoom()
        {
            int run = _run;
            Data.Vector3D p = _crew.Pos(_workerC);
            int seen = await FirstSeeing(new[] { _camA, _camB }, Geo.Up(p, 1500), Geo.Up(p, 900));
            if (run != _run) return;   // 기다리는 동안 처음으로 되돌린 경우

            int view = Math.Max(0, Array.IndexOf(_order, seen < 0 ? _camA : seen));
            Beat(string.Format(ScenarioScript.TextIntruderZoom, SensorName(_order[view])));
            ZoomTo(view, _order[view], Geo.Up(p, 900), ScenarioScript.ZoomFov, ScenarioScript.ZoomSec);
            _intruderZoomed = true;
        }

        // 09 — 정비사 B 가 구역 밖에서 손짓해 불러내고, 작업자 C 가 구역 밖으로 나갑니다(나간 순간 구역 이벤트).
        private void SceneEscort()
        {
            Beat(ScenarioScript.TextDispatchB);
            Data.BoundBox3D noGo = ScenarioScript.NoGo;
            _techB.Speed = ScenarioScript.HurrySpeed;
            _crew.Walk(_techB, _map.Snap(noGo.MinX - ScenarioScript.EscortOffsetX, ScenarioScript.EscortY), () => _crew.TurnTo(_techB, _techB.Token, _crew.Pos(_workerC), () =>
            {
                _crew.Posture(_techB, "Hands Half Up");
                int tc = _crew.NewToken(_workerC);
                _crew.Posture(_workerC, null);
                _cues.After(ScenarioScript.EscortTurnDelay, () => _crew.TurnTo(_workerC, tc, _crew.Pos(_techB), () => _cues.After(ScenarioScript.EscortWalkDelay, () =>
                {
                    _crew.Posture(_techB, null);
                    _escorting = true;
                    _crew.Walk(_workerC, _map.Snap(noGo.MinX - ScenarioScript.ExitOffsetX, ScenarioScript.ExitY), () =>
                    {
                        // 구역 밖에 멈춰 선 뒤 그 자리에 확인 문구
                        Data.Vector3D q = _crew.Pos(_workerC);
                        _crew.Own(_workerC, Effect.AddTextLabel(Geo.Up(q, 2300), ScenarioScript.LabelExit, new Data.TextLabelOptions { SizePx = ScenarioScript.LabelSizePx, TextColor = Color.White, BackColor = ScenarioScript.Green, ExpireMs = 3000, Group = Group }), id => Effect.RemoveTextLabel(id));
                    });
                })));
            }));
        }

        // 구역 이벤트 — 작업자 C 가 나감: 구역을 주황으로 되돌림
        private void OnExit()
        {
            _exited = true;
            _intrusionArmed = false;
            _workerC.AllowNoGo = false;
            AlertNoGo(false);
            Beat(ScenarioScript.TextExit);
        }

        // 10 — 경보를 해제하고, 작업자 C·정비사 B 는 제자리 점검으로 돌아간 뒤 4분할로 돌아갑니다.
        private void SceneAllClear()
        {
            _intrusionArmed = false;
            _workerC.AllowNoGo = false;
            AlertNoGo(false);
            Beat(ScenarioScript.TextExit);

            _runner.After(ScenarioScript.AllClearIdleAt, () =>
            {
                _techB.Speed = ScenarioScript.WalkSpeed;
                _crew.IdleWork(_workerC, ScenarioScript.WorkerCIdleHeading, false);
                _crew.IdleWork(_techB, ScenarioScript.TechBIdleHeading, false);
            });
            _runner.After(ScenarioScript.AllClearSplitAt, () =>
            {
                ShowSplit(_order, RadarSlot);
                Beat(ScenarioScript.TextAllClear);
            });
        }

        private void ClearLeak()
        {
            if (_jet != 0) Effect.RemoveParticleEmitter(_jet);
            if (_steam != 0) Effect.RemoveParticleEmitter(_steam);
            if (_cloud != 0) Effect.RemoveGasCloud(_cloud);
            if (_leakMark != 0) Effect.RemoveMarker(_leakMark);
            if (_gdPulse != 0) Effect.RemovePulseSphere(_gdPulse);
            if (_gdLabel != 0) Effect.RemoveTextLabel(_gdLabel);
            _jet = _steam = _cloud = _leakMark = _gdPulse = _gdLabel = 0;
        }

        private void StartSpinner(Data.Vector3D at, double sec)
        {
            _spinner = Effect.AddSpinner(at, new Data.SpinnerOptions { SizePx = ScenarioScript.SpinnerSizePx, ThicknessPx = ScenarioScript.SpinnerThicknessPx, Progress = 0, Group = Group });
            _spinStart = _cues.Now;
            _spinSec = sec;
        }

        private void UpdateSpinner()
        {
            if (_spinStart < 0) return;
            float k = (float)Math.Min(1, (_cues.Now - _spinStart) / _spinSec);
            Effect.SetSpinnerProgress(_spinner, k);
            if (k >= 1) StopSpinner();
        }

        private void StopSpinner()
        {
            if (_spinStart < 0) return;
            _spinStart = -1;
            if (_spinner != 0) Effect.RemoveSpinner(_spinner);
            _spinner = 0;
        }

        #endregion

        #region 5. 정리

        // 어느 장면에서든 처음 상태(작업자 없음 · 4분할)로 되돌립니다.
        private void Ribbon_Reset()
        {
            ClearScene();
            if (_map != null) ShowSplit(_order, RadarSlot);
            SetStatus("처음으로 되돌렸습니다.");
        }

        // 재생을 멈추고 작업자·이펙트·문구를 지웁니다.
        private void ClearScene()
        {
            _runner.Reset();
            if (_ribbon != null) _ribbon.SetCurrent(0);
            ClearStage();
        }

        // 진행 중인 작업자·이펙트·예약을 모두 멈추고 지웁니다. 첫 장면도 이것부터 합니다.
        private void ClearStage()
        {
            _run++;
            _cues.Clear();
            _working = _gasAlarm = false;
            _intrusionArmed = _intruded = _exited = _escorting = _intruderMarked = false;
            _signalArrived = _techArrived = _leakCleared = _signalBack = _intruderZoomed = false;
            _spinStart = -1;
            _ptzTo = null;
            _beat = "";
            if (_crew != null) _crew.Clear();
            _jet = _steam = _cloud = _leakMark = _gdPulse = _gdLabel = _spinner = 0;
            if (!vizcore3dx.Model.IsOpen()) return;

            vizcore3dx.BeginUpdate();
            try
            {
                // 이 예제가 만든 그룹만 지움
                Effect.ClearParticleEmitters(Group);
                Effect.ClearGasClouds(Group);
                Effect.ClearMarkers(Group);
                Effect.ClearTextLabels(Group);
                Effect.ClearPulseSpheres(Group);
                Effect.ClearSpinners(Group);
                Effect.ClearGroundRings(Group);
                AlertNoGo(false);
                ClearHud();
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        #endregion

        #region 분할 화면

        // 4분할: 화면 자리마다 그 센서의 옵저버 시점으로 들어갑니다(휠·마우스로 카메라를 움직일 수 없음).
        // sensors 는 자리 순서(0 왼쪽 위, 1 오른쪽 위, 2 왼쪽 아래, 3 오른쪽 아래)입니다.
        // 옵저버 시점은 마지막에 들어간 센서의 표식만 숨기므로, 표식 안에 카메라가 묻히는 자리(lastSlot)를 마지막에 들어갑니다.
        private void ShowSplit(int[] sensors, int lastSlot)
        {
            _ptzTo = null;
            _zoomed = -1;
            if (vizcore3dx.View.GetSubViewCount() != 3) vizcore3dx.View.SetSubView(3);
            foreach (int slot in Enumerable.Range(0, sensors.Length).Where(s => s != lastSlot).Concat(new[] { lastSlot }))
            {
                vizcore3dx.View.SelectActiveView(SubViewAt[slot]);
                vizcore3dx.Observer.EnterView(sensors[slot]);
            }

            // 표식이 숨겨지지 않은 나머지 자리는 카메라를 시선 방향으로 조금 빼서 표식 밖에서 보게 함
            foreach (int slot in Enumerable.Range(0, sensors.Length).Where(s => s != lastSlot))
            {
                vizcore3dx.View.SelectActiveView(SubViewAt[slot]);
                Data.CameraData c = vizcore3dx.View.GetCameraData();
                Data.Vector3D d = Geo.Norm(new Data.Vector3D(c.CameraDirection.X, c.CameraDirection.Y, c.CameraDirection.Z));
                c.EyePosition = new Data.Vertex3D(c.EyePosition.X + d.X * FigureClearMm, c.EyePosition.Y + d.Y * FigureClearMm, c.EyePosition.Z + d.Z * FigureClearMm);
                c.PivotPosition = new Data.Vertex3D(c.PivotPosition.X + d.X * FigureClearMm, c.PivotPosition.Y + d.Y * FigureClearMm, c.PivotPosition.Z + d.Z * FigureClearMm);
                vizcore3dx.View.SetCameraData(c);
            }

            // 화면마다 렌즈 효과(비네트·블러)
            for (int slot = 0; slot < sensors.Length; slot++)
            {
                vizcore3dx.View.SelectActiveView(SubViewAt[slot]);
                ApplyLens(_lens[slot]);
            }
            vizcore3dx.View.SelectActiveView(0);
            HideViewerUI();
            RefreshHud();
        }

        // 지금 활성 뷰에 렌즈 효과를 적용
        private void ApplyLens(Lens lens)
        {
            // 안쪽 강도 0 → 바깥 0.95 로 가장자리로 갈수록 서서히 어두워짐
            if (lens == Lens.Vignette) vizcore3dx.View.SetBorderVignette(0.3f, 0.3f, 0.3f, 0.3f, 0f, 0.95f);
            else if (vizcore3dx.View.BorderVignetteEnabled) vizcore3dx.View.ClearBorderVignette();

            if (lens == Lens.Blur) vizcore3dx.View.SetBorderBlur(0.2f, 0.2f, 0.2f, 0.2f, 16, 0f, 1f);
            else if (vizcore3dx.View.BorderBlurEnabled) vizcore3dx.View.ClearBorderBlur();
        }

        // 그 센서 화면 하나를 크게 띄웁니다(분할을 없애고 메인 뷰를 그 센서 시점으로).
        private void ShowSingle(int index, int sensor)
        {
            _ptzTo = null;
            _zoomed = index;
            if (vizcore3dx.View.GetSubViewCount() != 0) vizcore3dx.View.SetSubView(0);
            vizcore3dx.View.SelectActiveView(0);
            vizcore3dx.Observer.EnterView(sensor);
            ApplyLens(_lens[index]);
            _homeCamera = vizcore3dx.View.GetCameraData();
            HideViewerUI();
            RefreshHud();
        }

        // 크게 띄운 뒤 렌즈 자리는 그대로 두고 대상 쪽으로 고개를 돌리며 화각을 좁힙니다(PTZ 줌).
        private void ZoomTo(int index, int sensor, Data.Vector3D target, double fov, double sec)
        {
            ShowSingle(index, sensor);
            Data.CameraData c = _homeCamera;
            _eye = new Data.Vector3D(c.EyePosition.X, c.EyePosition.Y, c.EyePosition.Z);
            Data.Vector3D d0 = Geo.Norm(new Data.Vector3D(c.CameraDirection.X, c.CameraDirection.Y, c.CameraDirection.Z));
            Data.Vector3D d1 = Geo.Dir(_eye, target);
            _ptzFrom = new double[] { d0.X, d0.Y, d0.Z, c.Fov };
            _ptzTo = new double[] { d1.X, d1.Y, d1.Z, fov };
            _ptzStart = _clock.Elapsed.TotalSeconds;
            _ptzSec = sec;
        }

        // 진행 시계에서 부릅니다.
        private void UpdateZoom()
        {
            if (_ptzTo == null || _zoomed < 0) return;
            double k = Math.Min(1, (_clock.Elapsed.TotalSeconds - _ptzStart) / _ptzSec);
            double e = k * k * k * (k * (k * 6 - 15) + 10);
            double[] v = new double[4];
            for (int i = 0; i < 4; i++) v[i] = _ptzFrom[i] + (_ptzTo[i] - _ptzFrom[i]) * e;
            Data.Vector3D d = Geo.Norm(new Data.Vector3D((float)v[0], (float)v[1], (float)v[2]));

            // 위쪽은 세계 Z 기준 (화면이 기울지 않게)
            double ux = -d.Z * d.X, uy = -d.Z * d.Y, uz = 1 - d.Z * d.Z, ul = Math.Sqrt(ux * ux + uy * uy + uz * uz);
            Data.CameraData c = vizcore3dx.View.GetCameraData();
            c.EyePosition = new Data.Vertex3D(_eye.X, _eye.Y, _eye.Z);
            c.CameraDirection = new Data.Vertex3D(d.X, d.Y, d.Z);
            c.PivotPosition = new Data.Vertex3D(_eye.X + d.X * 5000, _eye.Y + d.Y * 5000, _eye.Z + d.Z * 5000);
            c.UpDirection = new Data.Vertex3D((float)(ux / ul), (float)(uy / ul), (float)(uz / ul));
            c.Fov = (float)v[3];
            vizcore3dx.View.SetCameraData(c);
            if (k >= 1) _ptzTo = null;
        }

        #endregion

        #region Helpers

        private VIZCore3DX.NET.Manager.EffectManager Effect { get { return vizcore3dx.View.Effect; } }

        // 모델이 열려 있는지 확인하고, 아니면 상태줄에 알립니다.
        private bool IsModelOpened()
        {
            if (vizcore3dx.Model.IsOpen()) return true;

            SetStatus("모델을 먼저 열어 주세요.");
            return false;
        }

        private void SetStatus(string text)
        {
            Text = "VIZCore3DX.NET.Scenario.Monitoring — " + text;
        }

        // 장면 안의 문구 — 창 제목줄과 3D 뷰 왼쪽 위 문구의 첫 줄에 띄웁니다.
        private void Beat(string text)
        {
            _beat = text;
            SetStatus(text);
            RefreshHud();
        }

        // 3D 뷰 왼쪽 위 문구: 장면 안의 문구 아래에 가스 감지기 상태와 출입 금지 구역 안 인원을 붙입니다. 감시 중일 때만 띄웁니다.
        private void RefreshHud()
        {
            if (!_working || _noGoZone < 0 || !vizcore3dx.Model.IsOpen()) return;

            string tail = string.Format(ScenarioScript.TextHudTail, _gasAlarm ? ScenarioScript.TextGasOn : ScenarioScript.TextGasOff, vizcore3dx.Zone.GetContents(_noGoZone).Count);
            // 4분할이면 노트가 칸마다 그려지므로 꼬리 한 줄만 띄웁니다(장면 문구는 창 제목에 있습니다).
            bool split = vizcore3dx.View.GetSubViewCount() != 0;
            string text = split || string.IsNullOrEmpty(_beat) ? tail : _beat + "\n" + tail;
            if (text == _hudText) return;
            ShowHud(text);
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
            _hudText = text;
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
            _hudText = null;
        }

        private static float Sq(float v) { return v * v; }

        // 사용자 탭만 남기고 나머지 툴바(=리본 탭)와 모델 트리 패널의 탭을 숨깁니다.
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

        #endregion
    }
}
