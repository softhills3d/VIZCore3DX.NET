using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Scenario.GearboxMaintenance
{
    // 시나리오 예제 "감속기 정비 — 인출 방향 · 탑재 경로 · 치수 검증을 화면 하나에서"
    // 돌던 기어열을 멈추고, 정비 순서를 애니메이션으로 재생하고, 방향 스윕으로 출력축을 뺄 방향을 찾고,
    // 이동 간섭 검사로 다시 넣는 경로를 확인한 뒤, 단면·측정으로 치수를 검증하고 다시 돌립니다.
    // 장면 하나 = 메서드 하나(#region 장면), 장면의 설명·길이와 장면에 쓰는 값(부품 이름·속성 키·거리·시간)은 ScenarioScript.cs 한 곳에,
    // 재생은 ScenarioRunner.cs 에 있습니다.
    //
    // ── 이 예제에서 SDK 사용을 보려면 ──
    // · 분해 순서 애니메이션: SceneOpenCover(), AddUnscrewGroups()
    // · 방향 스윕(뺄 수 있는 방향 찾기): SceneSweep(), SweepOptions()
    // · 이동 간섭 검사(넣는 경로 확인): CreateLowerPathTest(), SceneMount(), Clash_OnClashMoveTestReportFinished()
    // · 단면(한 단면만 뒤집기): AddSectionKeepBelow() (Section.InvertDirection(id))
    // · 측정·최소 거리(문구 띄우기): SceneVerify(), AddAxialDistance(), ShowMeshGap()
    // · 카메라 도착 뒤 이어서 하기: WhenCameraArrives() (View.OnCameraMoveCompletedEvent)
    // · 폼 상태 없이 복사해 쓸 도우미는 #region SDK 기법 에 모아 두었습니다.
    // 장면 재생·리본(ScenarioRunner.cs, ScenarioRibbon.cs)과 카메라·문구 연출(FrmMain.Demo.cs)은 SDK 사용과 무관하니 건너뛰어도 됩니다.
    // 다른 모델에 쓰려면: ScenarioScript.cs 의 부품 이름·속성 키를 그 모델에 맞게 바꿉니다(IsModelReady 가 확인합니다).
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 조작부 — 리본 사용자 탭 "시나리오" (뷰어 초기화 뒤에 만듭니다)
        private ScenarioRibbon _ribbon;

        // 대본과 재생기
        private List<ScenarioShot> _shots;
        private ScenarioRunner _runner;

        // 이름으로 찾은 부품
        private List<Data.Node> _allNodes = new List<Data.Node>();
        private readonly Dictionary<string, Data.Node> _byName = new Dictionary<string, Data.Node>();
        private readonly Dictionary<int, Data.Node> _byIndex = new Dictionary<int, Data.Node>();
        private readonly Dictionary<string, HashSet<int>> _typeIndex = new Dictionary<string, HashSet<int>>();

        // 정비 순서 애니메이션 · 기어열 회전 애니메이션 · 방향 스윕 결과
        private Data.Animation _animation;
        private Data.Animation _spin;
        private Data.Animation _explode;
        private Data.ClashSweepResult _sweep;

        // 처음으로 되돌린 횟수 — 방향 검사를 기다리는 동안 처음으로 되돌렸으면 늦게 온 결과를 버립니다.
        private int _sweepRun;

        // 탑재 경로 이동 간섭 검사 — 캡 볼트를 끼운 채 / 뺀 채 · 빨갛게 칠한 관통 부품
        private Data.ClashTest _mountTry;
        private Data.ClashTest _mountRetry;
        private List<Data.Node> _clashMarked;

        // 탑재 장면이 진행 중인지 — 다음 장면으로 넘어간 뒤 늦게 끝난 검사 결과는 무시합니다.
        private bool _mountActive;

        // 애니메이션 시각 — 커버를 치운 뒤 멈추는 시각, 출력축 인출을 이어 붙이는 시각 (볼트 조 수에 따라 정해짐)
        private double _pauseAt;
        private double _capStart;
        private double _shaftPullStart;

        // 단면 (정리할 때 지웁니다)
        private Data.SectionItem _section;
        private bool? _originalCapFill;

        // 숨긴 하우징 (맞물림부를 들여다보려고)
        private bool _housingHidden;

        // 시나리오가 바꾸기 전의 실루엣 외곽선 상태 · X-Ray 색 · 방향 스윕 표시 스타일
        private bool? _originalSilhouette;
        private Data.XRayColorTypes? _originalXRayColor;
        private Data.ClashSweepStyle _originalSweepStyle;

        // 카메라가 도착하면 할 일 — View.OnCameraMoveCompletedEvent 가 한 번 실행하고 비웁니다. 장면이 바뀌거나 처음으로 가면 버립니다.
        private Action _onCameraArrived;

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

            vizcore3dx.Clash.OnClashMoveTestReportFinished += Clash_OnClashMoveTestReportFinished;
            vizcore3dx.View.OnCameraMoveCompletedEvent += View_OnCameraMoveCompletedEvent;

            // 장면 중에 진행 창(간섭 검사 등)이 3D 뷰를 가리지 않게 합니다 — 이동 간섭 검사는 단계마다 진행 창을 띄웁니다.
            vizcore3dx.EnableProgressForm = false;

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
            ScenarioScript.Running.Play = SceneRunning;
            ScenarioScript.OpenCover.Play = SceneOpenCover;
            ScenarioScript.Sweep.Play = SceneSweep;
            ScenarioScript.PullOut.Play = ScenePullOut;
            ScenarioScript.Explode.Play = SceneExplode;
            ScenarioScript.Mount.Play = SceneMount;
            ScenarioScript.Verify.Play = SceneVerify;
            ScenarioScript.Restart.Play = SceneRestart;

            // 번호 버튼으로 바로 볼 때 먼저 실행할 장면 — 인출 방향(03)은 커버를 연 상태(02), 인출(04)은 방향 검사 결과(03)를 씁니다.
            ScenarioScript.Sweep.Before = new[] { 2 };
            ScenarioScript.PullOut.Before = new[] { 2, 3 };
            ScenarioScript.Explode.Before = new[] { 2, 3, 4 };
            ScenarioScript.Mount.Before = new[] { 2 };
            ScenarioScript.Verify.Before = new[] { 2 };

            // 방향 검사는 비동기라, 선행 장면으로 실행할 때 결과가 나올 때까지 기다립니다.
            ScenarioScript.Sweep.IsDone = () => _sweep != null;

            return new List<ScenarioShot>
            {
                ScenarioScript.Running, ScenarioScript.OpenCover, ScenarioScript.Sweep, ScenarioScript.PullOut,
                ScenarioScript.Explode, ScenarioScript.Mount, ScenarioScript.Verify, ScenarioScript.Restart,
            };
        }

        // 창을 닫을 때 재생 타이머를 멈추고 이벤트 구독부터 해제합니다.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _runner.Reset();
            vizcore3dx.Clash.OnClashMoveTestReportFinished -= Clash_OnClashMoveTestReportFinished;
            vizcore3dx.View.OnCameraMoveCompletedEvent -= View_OnCameraMoveCompletedEvent;
            base.OnFormClosing(e);
        }

        #endregion

        #region 1. 모델

        // 모델을 엽니다. 장면이 쓰는 부품 이름·속성은 샘플 모델에 맞춰 있습니다(ScenarioScript.cs).
        private void Ribbon_OpenModel()
        {
            if (_runner.IsPlaying) return;

            // 리포의 샘플 모델(SampleModels\Gearbox.vizx)이 빌드 때 exe 옆에 복사됩니다. 있으면 바로 열고, 없으면 파일을 고릅니다.
            string sample = System.IO.Path.Combine(Application.StartupPath, "Gearbox.vizx");
            bool opened = System.IO.File.Exists(sample) ? vizcore3dx.Model.Open(sample) : vizcore3dx.Model.OpenFileDialog();
            if (opened == false) return;

            IndexNodes();
            ClearScene();
            if (IsModelReady()) SetStatus("모델을 열었습니다. [전체 재생]이나 장면 번호를 누르세요.");
        }

        // 열린 모델의 부품을 이름·번호로 찾아 둡니다. 이전 모델에서 만든 애니메이션·검사·단면은 버립니다.
        private void IndexNodes()
        {
            _allNodes = vizcore3dx.Object3D.FromFilter(Data.Object3dFilter.ALL);
            _byName.Clear();
            _byIndex.Clear();
            _typeIndex.Clear();
            _housingHidden = false;
            _animation = null;
            _spin = null;
            _explode = null;
            _mountTry = null;
            _mountRetry = null;
            _clashMarked = null;
            _section = null;
            foreach (Data.Node node in _allNodes)
            {
                // 같은 이름이 여럿이면(BearingCap_A 등) 처음 것만 둡니다. 이 예제가 쓰는 이름은 모두 하나뿐입니다.
                if (!_byName.ContainsKey(node.NodeName)) _byName.Add(node.NodeName, node);
                _byIndex[node.Index] = node;
            }
        }

        #endregion

        #region 3. 장면

        // 첫 장면부터 끝까지 이어서 재생합니다. 첫 장면 전에 장면이 쓰는 부품이 모델에 있는지 확인합니다.
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
            _onCameraArrived = null;
            _ribbon.SetCurrent(_runner.Index);
            SetStatus(shot.Name + " — " + shot.Caption);
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

        // 재생을 멈추고 처음으로 되돌린 뒤, 시나리오가 만든 애니메이션·스윕 표시·이동 간섭 검사·단면·측정을 전부 지웁니다.
        private void ClearScene()
        {
            _runner.Reset();
            _onCameraArrived = null;
            if (_ribbon != null) _ribbon.SetCurrent(0);

            _mountActive = false;
            if (vizcore3dx.Model.IsOpen()) Clear3D();
            _sweep = null;
            _sweepRun++;
        }

        private void Clear3D()
        {
            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.Clash.Sweep.Hide();
                DeleteAnimation();
                DeleteSpin();
                EndExplode();

                if (_clashMarked != null) vizcore3dx.Object3D.Color.RestoreColor(_clashMarked);
                _clashMarked = null;
                foreach (Data.ClashTest test in new[] { _mountTry, _mountRetry }.Where(t => t != null))
                {
                    vizcore3dx.Clash.RestoreTestPathPosition(test);
                    vizcore3dx.Clash.Delete(test);
                }
                _mountTry = null;
                _mountRetry = null;
                vizcore3dx.Object3D.Transform.RestoreTransformAll();

                RemoveSection();
                vizcore3dx.Measure.Clear();

                vizcore3dx.Object3D.Show(Data.Object3DKind.ALL, true);
                _housingHidden = false;
                vizcore3dx.View.XRay.Clear();
                vizcore3dx.View.XRay.Enable = false;
                if (_originalXRayColor != null) vizcore3dx.View.XRay.ColorType = _originalXRayColor.Value;
                _originalXRayColor = null;
                if (_originalSilhouette != null) vizcore3dx.View.SilhouetteEdge = _originalSilhouette.Value;
                _originalSilhouette = null;
                RestoreSweepStyle();

                ClearHud();
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        #endregion

        #region 장면

        // 01 운전 — 하우징을 X-Ray 로 비춰 기어열이 도는 모습을 보이다가 서서히 멈춥니다. 회전수·감속비는 모델 속성과 잇수에서 읽습니다.
        private void SceneRunning()
        {
            if (_originalSilhouette == null) _originalSilhouette = vizcore3dx.View.SilhouetteEdge;
            vizcore3dx.View.SilhouetteEdge = true;

            Data.Node reducer = Node(ScenarioScript.NameReducer);
            double ratio = 1.0 / Math.Abs(ShaftSpeeds().Last());
            ShowHud(string.Format("운전 중 · {0} → {1} rpm · 감속비 {2:0.00}", Uda(reducer, ScenarioScript.UdaInputSpeed), Uda(reducer, ScenarioScript.UdaOutputSpeed), ratio));

            Batch(() =>
            {
                ShowGearTrain(true);
                StartSpin(false, ScenarioScript.RunningSeconds - ScenarioScript.SpinRampSeconds - 0.5, true);
            });

            FlyToBox(ModelBox(), ScenarioScript.ViewIntro, 0.8, ScenarioScript.IntroZoom);
            WhenCameraArrives(() => Orbit(ScenarioScript.IntroOrbitDegrees, ScenarioScript.RunningSeconds - 1.0));
            _runner.After(ScenarioScript.RunningSeconds - ScenarioScript.SpinRampSeconds - 0.5, () => ShowHud("정지 · 정비 시작"));
        }

        // 02 상부 커버 열기 — 플랜지 볼트를 한 조씩 풉니다(너트가 돌며 내려가고, 이어서 볼트가 돌며 올라간 뒤 치움). 그다음 커버(점검 덮개·아이볼트 포함)를 들어 뒤로 치우고, 그 시점에서 멈춰 둡니다.
        // 볼트·너트·와셔는 이름이 아니라 속성(General/Type)으로 가립니다. 카메라 쪽(+X) 줄부터 풉니다.
        private void SceneOpenCover()
        {
            ClearHud();
            Batch(() =>
            {
                DeleteSpin();
                ShowGearTrain(false);
            });

            Data.Node flangeBolts = Node(ScenarioScript.NameFlangeBolts);
            List<Data.Node> sets = _allNodes.Where(n => n.ParentIndex == flangeBolts.Index).ToList();
            float middleX = ModelBox().CenterX;
            sets = sets.OrderBy(n => n.GetBoundBox().CenterX > middleX ? 0 : 1).ThenBy(n => n.GetBoundBox().CenterY).ToList();

            // 카메라 쪽(+X) 플랜지 줄 볼트를 가까이서 봅니다. 그 줄부터 풉니다.
            Data.BoundBox3D front = vizcore3dx.Object3D.GetBoundBox(sets.Where(n => n.GetBoundBox().CenterX > middleX).ToList());
            FlyToBox(front, ScenarioScript.ViewBolts, 1.0, ScenarioScript.BoltsZoom);

            DeleteAnimation();
            _animation = vizcore3dx.Animation.CreateAnimation("GearboxMaintenance");
            _animation.Activate();

            double unscrewEnd = 0;
            for (int i = 0; i < sets.Count; i++)
                unscrewEnd = Math.Max(unscrewEnd, AddUnscrewGroups(sets[i], i * ScenarioScript.UnscrewStagger));

            double lidLift = unscrewEnd + 0.1;
            AddLidGroup(lidLift);
            PlanPullOut(lidLift);

            ShowHud(string.Format("플랜지 볼트 {0}조 · 체결 {1} N·m", sets.Count, Uda(flangeBolts, ScenarioScript.UdaTorque)));
            ScheduleOpenCover(lidLift);
        }

        // 볼트 조 하나를 푸는 그룹을 더합니다 — t0 초부터 너트가 돌며 내려가고, 이어서 볼트가 돌며 올라간 뒤 숨깁니다. 끝나는 시각을 돌려줍니다(볼트가 없으면 0).
        private double AddUnscrewGroups(Data.Node set, double t0)
        {
            List<Data.Node> parts = _allNodes.Where(n => n.ParentIndex == set.Index).ToList();
            Data.Node bolt = parts.FirstOrDefault(n => IsType(n, ScenarioScript.TypeBolt));
            if (bolt == null) return 0;

            Data.Vector3D up = new Data.Vector3D(0f, 0f, 1f);
            float turns = (float)(Math.PI * 2.0 * ScenarioScript.UnscrewTurns);

            // 볼트 머리 쪽 와셔는 볼트와, 너트 쪽 와셔는 너트와 함께 움직입니다. 어느 쪽인지는 높이로 가립니다.
            Data.BoundBox3D boltBox = bolt.GetBoundBox();
            Data.Vector3D axis = new Data.Vector3D(boltBox.CenterX, boltBox.CenterY, boltBox.CenterZ);
            List<Data.Node> headSide = parts.Where(n => n == bolt || (IsType(n, ScenarioScript.TypeWasher) && n.GetBoundBox().CenterZ > boltBox.CenterZ)).ToList();
            List<Data.Node> nutSide = parts.Where(n => !headSide.Contains(n) && (IsType(n, ScenarioScript.TypeNut) || IsType(n, ScenarioScript.TypeWasher))).ToList();

            double t1 = t0 + ScenarioScript.NutSeconds;
            double t2 = t1 + ScenarioScript.BoltSeconds;

            // 회전축이 이동 방향(Z)과 같아 한 그룹에 회전·이동을 함께 줘도 축이 흔들리지 않습니다.
            Data.AnimationGroup nutGroup = _animation.CreateGroup(set.NodeName + " Nut");
            nutGroup.AddNodes(nutSide);
            nutGroup.CreateRotationAction(Sec(t0), Sec(ScenarioScript.NutSeconds), axis, up, -turns);
            nutGroup.CreateTranslationAction(Sec(t0), Sec(ScenarioScript.NutSeconds), new Data.Vector3D(0f, 0f, -1f), ScenarioScript.NutDrop);
            nutGroup.CreateVisibilityAction(Sec(t2 + ScenarioScript.HideAfter), false);

            Data.AnimationGroup boltGroup = _animation.CreateGroup(set.NodeName + " Bolt");
            boltGroup.AddNodes(headSide);
            boltGroup.CreateRotationAction(Sec(t1), Sec(ScenarioScript.BoltSeconds), axis, up, turns);
            boltGroup.CreateTranslationAction(Sec(t1), Sec(ScenarioScript.BoltSeconds), up, ScenarioScript.BoltRise);
            boltGroup.CreateVisibilityAction(Sec(t2 + ScenarioScript.HideAfter), false);

            return t2 + ScenarioScript.HideAfter;
        }

        // 커버(점검 덮개·아이볼트 포함)를 lidLift 초부터 들어 올린 뒤 뒤로 치우는 그룹을 더합니다.
        private void AddLidGroup(double lidLift)
        {
            double lidAside = lidLift + ScenarioScript.LidLiftSeconds;
            Data.AnimationGroup lidGroup = _animation.CreateGroup("Lid");
            lidGroup.AddNodes(Nodes(ScenarioScript.NameLidParts));
            lidGroup.CreateTranslationAction(Sec(lidLift), Sec(ScenarioScript.LidLiftSeconds), new Data.Vector3D(0f, 0f, 1f), ScenarioScript.LidLift);
            lidGroup.CreateTranslationAction(Sec(lidAside), Sec(ScenarioScript.LidAsideSeconds), ScenarioScript.LidAsideDirection, ScenarioScript.LidAside);
        }

        // 커버를 치운 뒤 멈추는 시각과, 04 에서 캡 볼트를 하나씩 뺀 뒤 축을 드는 시각을 볼트 조 수로 미리 정합니다.
        private void PlanPullOut(double lidLift)
        {
            double lidAside = lidLift + ScenarioScript.LidLiftSeconds;
            _pauseAt = lidAside + ScenarioScript.LidAsideSeconds + 0.2;
            int capSets = CapBoltSets().Count;
            _capStart = _pauseAt + 0.1;
            _shaftPullStart = _capStart + Math.Max(capSets - 1, 0) * ScenarioScript.UnscrewStagger + ScenarioScript.BoltSeconds + ScenarioScript.HideAfter + ScenarioScript.CapRemovedHold;

            // ★Duration 을 직접 주지 않으면 0 초라 Play 가 바로 끝납니다. 04 의 출력축 인출까지 들어가게 여기서 한 번에 잡습니다.
            _animation.Duration = Sec(_shaftPullStart + ScenarioScript.ShaftPullSeconds + 0.5);
        }

        // 문구를 읽을 시간 뒤에 볼트 풀기를 재생하고, 커버를 들 때 물러났다가, 커버를 치운 시점에서 멈춥니다.
        private void ScheduleOpenCover(double lidLift)
        {
            _runner.After(ScenarioScript.ReadPause, () =>
            {
                _animation.PlaybackTime = TimeSpan.Zero;
                _animation.Play();
            });

            // 볼트를 다 풀면 모델 전체로 물러나 커버를 들어 뒤로 치우는 모습을 봅니다.
            _runner.After(ScenarioScript.ReadPause + lidLift - 0.3, () => FlyToBox(LidPathBox(), ScenarioScript.ViewWork, 1.5, ScenarioScript.LidZoom));

            // 04 에서 출력축 인출을 이어 붙이도록, 커버를 치운 시점에서 멈춥니다.
            _runner.After(ScenarioScript.ReadPause + _pauseAt, () => { if (_animation != null) _animation.Pause(); });
        }

        // 03 인출 방향 검사 — 출력축 조립품을 6방향으로 밀어 봅니다. 커버를 옮겼으니 장애물을 다시 읽게 합니다.
        private async void SceneSweep()
        {
            Data.Node shaft = Node(ScenarioScript.NameOutputShaftAssy);
            if (_animation != null) _animation.Pause();
            ShowHud("출력축 6방향 검사 중…");

            // 통과 방향 볼륨(최대 거리만큼 뻗음)까지 들어오게 맞춥니다.
            FlyToBox(SweepViewBox(shaft), ScenarioScript.ViewSweep, 1.2, ScenarioScript.SweepZoom);

            // ★커버를 애니메이션으로 옮긴 뒤에는 장애물 캐시를 비워야 옮긴 위치로 검사합니다(안 비우면 커버가 제자리에 있는 결과).
            vizcore3dx.Clash.Sweep.InvalidateObstacles();
            ApplySweepStyle();

            int run = _sweepRun;
            Stopwatch watch = Stopwatch.StartNew();
            Data.ClashSweepResult result = await vizcore3dx.Clash.Sweep.RunAsync(new List<Data.Node> { shaft }, SweepOptions());
            double seconds = watch.Elapsed.TotalSeconds;

            // 그사이 처음으로 되돌렸으면 그만둡니다.
            if (run != _sweepRun) return;
            if (result == null || !result.IsSucceeded) { ShowHud("방향 검사 실패"); return; }

            _sweep = result;
            vizcore3dx.Clash.Sweep.Show(result);

            int directions = result.Directions == null ? 0 : result.Directions.Count;
            int free = result.FreeDirections == null ? 0 : result.FreeDirections.Count;
            ShowHud(string.Format("{0}방향 검사 {1:0.0}초 · 통과 {2}방향", directions, seconds, free));
            Orbit(ScenarioScript.SweepOrbitDegrees, ScenarioScript.SweepOrbitSeconds);
        }

        // 04 출력축 인출 — 통과한 방향만 남겨 보이고, 출력축 가까이 다가가 베어링 캡 볼트를 하나씩 풀어 뺀 뒤, 출력축(기어 포함)을 천천히 들어 올립니다.
        // 같은 애니메이션(02 에서 멈춘 지점)에 이어 붙입니다. 캡 볼트는 축 방향(Y)으로 박혀 있어 Y 축으로 돌며 바깥쪽으로 빠집니다.
        private void ScenePullOut()
        {
            Data.Node shaft = Node(ScenarioScript.NameOutputShaftAssy);
            if (_sweep == null || _animation == null || _sweep.FreeDirections == null || _sweep.FreeDirections.Count == 0) { ShowHud("통과 방향이 없습니다"); return; }

            // 통과 방향이 여럿이면 위쪽(크레인으로 들어 올리는 방향)을 고릅니다.
            Data.ClashSweepDirectionResult best = _sweep.FreeDirections.OrderByDescending(d => d.Direction.Z).First();
            vizcore3dx.Clash.Sweep.Show(_sweep, _sweep.Directions.IndexOf(best));

            List<Data.Node> capBolts = CapBoltSets();
            string name = DirectionName(best.Direction);
            ShowHud(string.Format("{0} 통과 · 캡 볼트 {1}개 분리 후 인출", name, capBolts.Count));

            // 축이 올라갈 길까지 들어오게 출력축 가까이 다가갑니다.
            Data.BoundBox3D shaftBox = shaft.GetBoundBox();
            Data.BoundBox3D pullBox = new Data.BoundBox3D(shaftBox.MinX, shaftBox.MinY, shaftBox.MinZ, shaftBox.MaxX, shaftBox.MaxY, shaftBox.MaxZ + ScenarioScript.ShaftPull);
            FlyToBox(pullBox, ScenarioScript.ViewMount, 1.5, ScenarioScript.PullZoom);

            AddCapBoltGroups(capBolts, shaftBox);

            // 볼트가 다 빠지면 잠시 뒤 출력축을 들어 올립니다(시각은 02 에서 정함).
            // ★캡 볼트는 출력축 조립품 아래에 있어, 조립품 노드를 통째로 넣으면 캡 볼트 그룹과 겹쳐 두 그룹 다 움직이지 않았다 — 캡 볼트를 뺀 부품만 넣습니다.
            List<Data.Node> lift = _allNodes.Where(n => n.Kind == Data.NodeKind.PART && IsUnder(n, shaft) && !capBolts.Any(c => IsUnder(n, c))).ToList();
            Data.AnimationGroup shaftGroup = _animation.CreateGroup("OutputShaft");
            shaftGroup.AddNodes(lift);
            shaftGroup.CreateTranslationAction(Sec(_shaftPullStart), Sec(ScenarioScript.ShaftPullSeconds), best.Direction, ScenarioScript.ShaftPull);

            _runner.After(ScenarioScript.ReadPause, () =>
            {
                vizcore3dx.Clash.Sweep.Hide();
                _animation.Play();
            });
            _runner.After(ScenarioScript.ReadPause + (_shaftPullStart - _pauseAt), () =>
                ShowHud(string.Format("출력축 인출 · {0} {1:0} mm", name, ScenarioScript.ShaftPull)));
        }

        // 캡 볼트 조(볼트 + 와셔)를 카메라 쪽(−Y) 캡부터 하나씩 — 돌면서 바깥쪽으로 빠진 뒤 숨기는 그룹을 더합니다.
        private void AddCapBoltGroups(List<Data.Node> capBolts, Data.BoundBox3D shaftBox)
        {
            float turns = (float)(Math.PI * 2.0 * ScenarioScript.UnscrewTurns);
            double start = _capStart;
            List<Data.Node> ordered = capBolts.OrderBy(n => n.GetBoundBox().CenterY).ToList();
            for (int i = 0; i < ordered.Count; i++)
            {
                Data.BoundBox3D box = ordered[i].GetBoundBox();
                Data.Vector3D center = new Data.Vector3D(box.CenterX, box.CenterY, box.CenterZ);
                Data.Vector3D outward = new Data.Vector3D(0f, box.CenterY < shaftBox.CenterY ? -1f : 1f, 0f);
                double t0 = start + i * ScenarioScript.UnscrewStagger;

                Data.AnimationGroup group = _animation.CreateGroup(ordered[i].NodeName);
                group.AddNode(ordered[i]);
                group.CreateRotationAction(Sec(t0), Sec(ScenarioScript.BoltSeconds), center, outward, turns);
                group.CreateTranslationAction(Sec(t0), Sec(ScenarioScript.BoltSeconds), outward, ScenarioScript.CapBoltBackOut);
                group.CreateVisibilityAction(Sec(t0 + ScenarioScript.BoltSeconds + ScenarioScript.HideAfter), false);
            }
        }

        // 05 전체 분해 — 점검용 전개도. 자동 분해(중심에서 사방으로)는 어지러워, 부품마다 방향을 정해 애니메이션으로 펼칩니다.
        // ① 플랜지 볼트는 위로·너트는 아래로 따로 빠지고(와셔는 그 사이), 커버·점검 덮개·아이볼트가 층층이 위로
        // ② 축 조립품 3개를 들어 올리고 ③ 축 방향(Y)으로 캡 볼트 → 캡 → 베어링 순서로 바깥쪽에 펼칩니다(축·기어·키는 그대로).
        // ★한 부품이 두 그룹에 들어가면(부모·자식 겹침 포함) 그룹이 움직이지 않습니다 — 부품마다 그룹 하나, 이동은 그 그룹에 이어 붙입니다.
        private void SceneExplode()
        {
            ClearHud();
            int groups = 0;
            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.Clash.Sweep.Hide();
                DeleteAnimation();
                vizcore3dx.Object3D.Transform.RestoreTransformAll();

                _explode = vizcore3dx.Animation.CreateAnimation("ExplodedView");
                _explode.Activate();
                double t1 = 0, t2 = ScenarioScript.ExplodePhaseSeconds, t3 = t2 * 2;
                double d = ScenarioScript.ExplodePhaseSeconds * 0.8;

                ExplodeFlangeBolts(ref groups, t1, d);
                ExplodeLid(ref groups, t1, d);
                foreach (Data.Node assembly in Nodes(ScenarioScript.NameShaftAssemblies))
                    ExplodeShaftAssembly(assembly, ref groups, t2, t3, d);

                _explode.Duration = Sec(t3 + d + 0.5);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            ShowHud(string.Format("점검을 위해 전체 분해 · 부품 묶음 {0}개", groups));

            FlyToBox(ExplodedBox(), ScenarioScript.ViewWork, 1.2, ScenarioScript.ExplodeZoom);
            WhenCameraArrives(() => Orbit(ScenarioScript.ExplodeOrbitDegrees, ScenarioScript.ExplodeOrbitSeconds));
            _runner.After(ScenarioScript.ReadPause, () =>
            {
                _explode.PlaybackTime = TimeSpan.Zero;
                _explode.Play();
            });
        }

        // ① 플랜지 볼트 조 — 볼트·머리 쪽 와셔는 위로, 너트·너트 쪽 와셔는 아래로
        private void ExplodeFlangeBolts(ref int groups, double t1, double d)
        {
            Data.Vector3D up = new Data.Vector3D(0f, 0f, 1f);
            Data.Vector3D down = new Data.Vector3D(0f, 0f, -1f);
            foreach (Data.Node set in Children(Node(ScenarioScript.NameFlangeBolts)))
            {
                List<Data.Node> parts = Parts(set);
                Data.Node bolt = parts.FirstOrDefault(n => IsType(n, ScenarioScript.TypeBolt));
                if (bolt == null) continue;
                float boltZ = bolt.GetBoundBox().CenterZ;
                foreach (Data.Node part in parts)
                {
                    bool headSide = part == bolt || (IsType(part, ScenarioScript.TypeWasher) && part.GetBoundBox().CenterZ > boltZ);
                    float distance = part == bolt ? ScenarioScript.ExplodeBoltUp
                        : headSide ? ScenarioScript.ExplodeBoltUp - ScenarioScript.ExplodeWasherGap
                        : IsType(part, ScenarioScript.TypeNut) ? ScenarioScript.ExplodeNutDown
                        : ScenarioScript.ExplodeNutDown - ScenarioScript.ExplodeWasherGap;
                    Move(new List<Data.Node> { part }, groups++, t1, d, headSide ? up : down, distance);
                }
            }
        }

        // ① 커버 · 점검 덮개 · 아이볼트 · 맞춤 핀 — 층층이 위로
        private void ExplodeLid(ref int groups, double t1, double d)
        {
            Data.Vector3D up = new Data.Vector3D(0f, 0f, 1f);
            Move(Parts(Node(ScenarioScript.NameLidParts[0])), groups++, t1 + 0.3, d, up, ScenarioScript.ExplodeCoverUp);
            for (int i = 1; i < ScenarioScript.NameLidParts.Length; i++)
                Move(Parts(Node(ScenarioScript.NameLidParts[i])), groups++, t1 + 0.3, d, up, ScenarioScript.ExplodeCoverUp + ScenarioScript.ExplodeLidPartsUp);
            foreach (string pin in ScenarioScript.NameDowelPins)
                if (Node(pin) != null) Move(Parts(Node(pin)), groups++, t1 + 0.3, d, up, ScenarioScript.ExplodeDowelUp);
        }

        // ②·③ 축 조립품 — 부품 묶음마다 그룹 하나에 "들어 올리기 → 축 방향 펼치기" 를 이어 붙입니다.
        private void ExplodeShaftAssembly(Data.Node assembly, ref int groups, double t2, double t3, double d)
        {
            float centerY = assembly.GetBoundBox().CenterY;
            List<Data.Node> moved = new List<Data.Node>();
            foreach (Data.Node child in Children(assembly))
            {
                if (IsType(child, ScenarioScript.TypeBearing))
                {
                    moved.AddRange(ExplodeAxial(Parts(child), centerY, ScenarioScript.ExplodeBearingOut, groups++, t2, t3, d));
                }
                else if (Children(child).Count > 0)
                {
                    // 베어링 캡 조립품 — 캡·오일실은 한 묶음, 캡 볼트 조는 볼트와 와셔를 따로
                    List<Data.Node> boltSets = Children(child).Where(c => Children(c).Count > 0).ToList();
                    List<Data.Node> cap = Parts(child).Where(p => !boltSets.Any(s => IsUnder(p, s))).ToList();
                    moved.AddRange(ExplodeAxial(cap, centerY, ScenarioScript.ExplodeCapOut, groups++, t2, t3, d));
                    foreach (Data.Node set in boltSets)
                        foreach (Data.Node part in Parts(set))
                        {
                            float distance = IsType(part, ScenarioScript.TypeBolt) ? ScenarioScript.ExplodeCapBoltOut : ScenarioScript.ExplodeCapBoltOut - ScenarioScript.ExplodeWasherGap;
                            moved.AddRange(ExplodeAxial(new List<Data.Node> { part }, centerY, distance, groups++, t2, t3, d));
                        }
                }
            }

            // 남은 부품(축·기어·키)은 들어 올리기만
            List<Data.Node> core = Parts(assembly).Where(p => !moved.Contains(p)).ToList();
            Move(core, groups++, t2, d, new Data.Vector3D(0f, 0f, 1f), ScenarioScript.ExplodeShaftUp);
        }

        // 부품들을 한 그룹으로 묶어 start 초부터 seconds 동안 direction 으로 distance 만큼 옮깁니다.
        private Data.AnimationGroup Move(List<Data.Node> parts, int index, double start, double seconds, Data.Vector3D direction, float distance)
        {
            if (parts.Count == 0) return null;
            Data.AnimationGroup group = _explode.CreateGroup("Explode " + index);
            group.AddNodes(parts);
            group.CreateTranslationAction(Sec(start), Sec(seconds), direction, distance);
            return group;
        }

        // 축 조립품의 부품 묶음 — t2 에 축과 함께 들어 올린 뒤, t3 에 조립품 중심에서 먼 쪽(±Y)으로 distance 만큼 펼칩니다.
        private List<Data.Node> ExplodeAxial(List<Data.Node> parts, float centerY, float distance, int index, double t2, double t3, double seconds)
        {
            Data.AnimationGroup group = Move(parts, index, t2, seconds, new Data.Vector3D(0f, 0f, 1f), ScenarioScript.ExplodeShaftUp);
            if (group == null) return parts;
            float side = vizcore3dx.Object3D.GetBoundBox(parts).CenterY < centerY ? -1f : 1f;
            group.CreateTranslationAction(Sec(t3), Sec(seconds), new Data.Vector3D(0f, side, 0f), distance);
            return parts;
        }

        // 전개도가 다 들어오는 범위 — 위로는 볼트·커버까지, 아래로는 너트까지, 옆으로는 축 방향 부품까지
        private Data.BoundBox3D ExplodedBox()
        {
            Data.BoundBox3D m = ModelBox();
            float side = ScenarioScript.ExplodeCapBoltOut;
            return new Data.BoundBox3D(m.MinX, m.MinY - side, m.MinZ - ScenarioScript.ExplodeNutDown, m.MaxX, m.MaxY + side, m.MaxZ + ScenarioScript.ExplodeCoverUp + ScenarioScript.ExplodeLidPartsUp);
        }

        // 노드 바로 아래 자식
        private List<Data.Node> Children(Data.Node node)
        {
            return node == null ? new List<Data.Node>() : _allNodes.Where(n => n.ParentIndex == node.Index && n.Index != node.Index).ToList();
        }

        // 노드 아래의 부품(노드가 부품이면 자기 자신)
        private List<Data.Node> Parts(Data.Node node)
        {
            if (node == null) return new List<Data.Node>();
            if (node.Kind == Data.NodeKind.PART) return new List<Data.Node> { node };
            return _allNodes.Where(n => n.Kind == Data.NodeKind.PART && IsUnder(n, node)).ToList();
        }

        // 전개도 애니메이션을 지웁니다 — 비활성으로 돌리면 모든 부품이 제자리로 돌아옵니다.
        private void EndExplode()
        {
            if (_explode == null) return;

            _explode.Stop();
            _explode.Deactivate();
            vizcore3dx.Animation.DeleteAnimation(_explode);
            _explode = null;
        }

        // 06 탑재 경로 검사 — 출력축을 인출한 높이에서 다시 내려 안착시키는 경로를 단계마다 간섭 검사합니다(검사하는 동안 축이 실제로 내려갑니다).
        // 처음엔 캡 볼트를 끼운 채 → 안착 직전에 볼트가 하우징을 관통 → 볼트를 빼고 다시 → 간섭 0 으로 안착, 그 뒤 볼트 체결.
        private void SceneMount()
        {
            ClearHud();
            vizcore3dx.Clash.Sweep.Hide();

            vizcore3dx.BeginUpdate();
            try
            {
                // 애니메이션을 비활성으로 돌리면 모든 부품이 제자리로 돌아옵니다. 커버는 치워 둔 자리로, 플랜지 볼트는 숨긴 채로 되돌립니다.
                // ★이동 간섭 검사는 노드 위치를 직접 옮기므로 애니메이션이 살아 있으면 안 됩니다(분해와 같은 이유).
                DeleteAnimation();
                EndExplode();
                Data.Vector3D aside = ScenarioScript.LidAsideDirection * ScenarioScript.LidAside;
                vizcore3dx.Object3D.Transform.Move(Nodes(ScenarioScript.NameLidParts), aside.X, aside.Y, aside.Z + ScenarioScript.LidLift, true);
                vizcore3dx.Object3D.Show(Node(ScenarioScript.NameFlangeBolts), false);

                _mountTry = CreateMountTest();
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
            if (_mountTry == null) { ShowHud("이동 간섭 검사를 만들 수 없습니다"); return; }

            _mountActive = true;
            int steps = vizcore3dx.Clash.GetTestPaths(_mountTry).Count;
            ShowHud(string.Format("탑재 경로 {0}단계 이동 간섭 검사 · 캡 볼트 끼운 채", steps));
            FlyToBox(MountViewBox(), ScenarioScript.ViewMount, 1.0, ScenarioScript.MountZoom);
            _runner.After(ScenarioScript.ReadPause, () => vizcore3dx.Clash.PerformInterferenceCheck(_mountTry.ID, Manager.ClashManager.ResultGroupingOptions.PART));
        }

        // 이동 간섭 검사가 끝나면 — 첫 검사는 관통 단계에서 멈춰 볼트를 빨갛게 보이고, 다시 한 검사는 안착 뒤 볼트를 체결합니다.
        private void Clash_OnClashMoveTestReportFinished(object sender, VIZCore3DX.NET.Event.EventManager.ClashEventArgs e)
        {
            if (InvokeRequired) { BeginInvoke(new Action(() => Clash_OnClashMoveTestReportFinished(sender, e))); return; }
            if (!_mountActive) return;

            if (_mountTry != null && e.ID == _mountTry.ID) OnMountTryChecked();
            else if (_mountRetry != null && e.ID == _mountRetry.ID) OnMountRetryChecked();
        }

        private void OnMountTryChecked()
        {
            List<Data.ClashMoveTestItem> paths = vizcore3dx.Clash.GetTestPaths(_mountTry);
            Data.ClashMoveTestItem bad = null;
            List<Data.ClashTestResultItem> hits = new List<Data.ClashTestResultItem>();
            foreach (Data.ClashMoveTestItem path in paths)
            {
                hits = Penetrations(_mountTry, path);
                if (hits.Count > 0) { bad = path; break; }
            }
            if (bad == null) { OnMountRetryChecked(); return; }

            // 관통한 단계로 축을 되돌려 두고, 관통한 부품(축 쪽)을 빨갛게 칠합니다.
            Data.Node shaft = Node(ScenarioScript.NameOutputShaftAssy);
            _clashMarked = hits.Select(h => IsUnder(Node(h.NodeNameA), shaft) ? Node(h.NodeNameA) : Node(h.NodeNameB))
                .Where(n => n != null).GroupBy(n => n.Index).Select(g => g.First()).ToList();
            Batch(() =>
            {
                vizcore3dx.Clash.ApplyTestPath(_mountTry, bad.ID);
                vizcore3dx.Object3D.Color.SetColor(_clashMarked, ScenarioScript.ColorClash);
                ShowPenetration(shaft);
            });

            // 단계 b 의 높이 = 인출 높이 − 그때까지 내린 거리
            int index = paths.IndexOf(bad);
            float above = ScenarioScript.ShaftPull - ScenarioScript.MountPath.Take(index).Sum();
            double depth = hits.Max(h => Math.Abs(h.Distance));
            ShowHud(string.Format("✗ 안착 {0:0} mm 앞 · 캡 볼트 {1}개 ↔ 하우징 관통 {2:0.0} mm", above, _clashMarked.Count, depth));

            // 카메라 쪽(−Y) 캡의 볼트로 다가갑니다.
            Data.BoundBox3D shaftBox = shaft.GetBoundBox();
            List<Data.Node> near = _clashMarked.Where(n => n.GetBoundBox().CenterY < shaftBox.CenterY).ToList();
            Data.BoundBox3D focus = vizcore3dx.Object3D.GetBoundBox(near.Count > 0 ? near : _clashMarked);
            FlyCamera(new Data.Vector3D(focus.GetCenter()), ScenarioScript.ViewMount, ScenarioScript.ClashViewDistance, 1.0);

            // 잠시 보여 준 뒤 볼트를 빼고 같은 경로로 다시 검사합니다.
            _runner.After(ScenarioScript.MountHoldSeconds, RetryMountWithoutCapBolts);
        }

        // 하우징 벽 속으로 들어간 볼트가 보이도록 X-Ray 로 출력축과 관통 볼트만 제 색으로 남깁니다.
        private void ShowPenetration(Data.Node shaft)
        {
            vizcore3dx.View.XRay.Clear();
            vizcore3dx.View.XRay.Enable = true;
            if (_originalXRayColor == null) _originalXRayColor = vizcore3dx.View.XRay.ColorType;
            vizcore3dx.View.XRay.ColorType = Data.XRayColorTypes.OBJECT_COLOR;
            vizcore3dx.View.XRay.Select(new List<Data.Node> { shaft }, true);
        }

        // 칠한 색을 걷고 축을 제자리로 되돌린 뒤, 캡 볼트를 빼고(숨겨) 같은 경로로 다시 검사합니다.
        private void RetryMountWithoutCapBolts()
        {
            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.Object3D.Color.RestoreColor(_clashMarked);
                _clashMarked = null;
                ShowGearTrain(false);
                vizcore3dx.Clash.RestoreTestPathPosition(_mountTry);
                vizcore3dx.Object3D.Show(CapBoltSets(), false);
                _mountRetry = CreateMountTest();
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
            if (_mountRetry == null) return;

            ShowHud("캡 볼트를 빼고 다시 검사");
            FlyToBox(MountViewBox(), ScenarioScript.ViewMount, 0.8, ScenarioScript.MountZoom);
            _runner.After(ScenarioScript.ReadPause, () => vizcore3dx.Clash.PerformInterferenceCheck(_mountRetry.ID, Manager.ClashManager.ResultGroupingOptions.PART));
        }

        private void OnMountRetryChecked()
        {
            Data.ClashTest test = _mountRetry ?? _mountTry;
            List<Data.ClashMoveTestItem> paths = vizcore3dx.Clash.GetTestPaths(test);
            int hits = paths.Sum(p => Penetrations(test, p).Count);

            // 안착 위치로 두고, 캡 볼트를 다시 끼웁니다(안착 뒤 체결).
            Batch(EndMount);
            ShowHud(hits == 0
                ? string.Format("✓ {0}단계 간섭 0 · 안착 후 캡 볼트 체결", paths.Count)
                : string.Format("✗ {0}단계 중 관통 {1}건", paths.Count, hits));
        }

        // 탑재 장면을 마무리합니다 — 칠한 색·X-Ray 를 걷고, 축을 안착 위치에, 캡 볼트를 제자리에 둡니다. 검사가 늦어도 다음 장면이 깨끗하게 시작하도록 다음 장면에서도 부릅니다.
        private void EndMount()
        {
            if (_clashMarked != null) vizcore3dx.Object3D.Color.RestoreColor(_clashMarked);
            _clashMarked = null;
            ShowGearTrain(false);

            Data.ClashTest test = _mountRetry ?? _mountTry;
            if (test != null) vizcore3dx.Clash.RestoreTestPathPosition(test);
            vizcore3dx.Object3D.Show(CapBoltSets(), true);
        }

        // 07 조립 검증 — 축 높이에서 잘라 축간 거리를 재서 설계값과 견주고, 이어서 하우징을 숨겨 맞물림 틈을 가까이 봅니다.
        private void SceneVerify()
        {
            ClearHud();
            _mountActive = false;

            List<Data.Node> shafts = Nodes(ScenarioScript.NameShafts);
            Data.BoundBox3D input = shafts[0].GetBoundBox();
            Data.BoundBox3D middle = shafts[1].GetBoundBox();
            Data.BoundBox3D output = shafts[2].GetBoundBox();

            // 축은 모델 Y 방향이라 경계 상자 중심의 X·Z 가 축 중심입니다.
            Data.Vector3D a = new Data.Vector3D(input.CenterX, middle.CenterY, input.CenterZ);
            Data.Vector3D b = new Data.Vector3D(middle.CenterX, middle.CenterY, middle.CenterZ);
            Data.Vector3D c = new Data.Vector3D(output.CenterX, middle.CenterY, output.CenterZ);
            Batch(() =>
            {
                EndMount();
                CutAtShaftHeight(input.CenterZ);
                AddAxialDistance(a, b);
                AddAxialDistance(b, c);
            });
            ShowCenterDistance(Math.Abs(b.X - a.X), Math.Abs(c.X - b.X));

            // 맞물림 틈은 미리 재 둡니다.
            Data.Node gearNode = Node(ScenarioScript.NameMeshGear);
            Data.Node pinionNode = Node(Uda(gearNode, ScenarioScript.UdaMate));
            Data.Vector3D p1, p2;
            double gap = vizcore3dx.Object3D.GeometryProperty.GetMinimumDistance(new List<Data.Node> { pinionNode }, new List<Data.Node> { gearNode }, out p1, out p2);

            // 기어열만 화면에 차도록 축 세 개의 범위로 맞춥니다.
            FlyToBox(vizcore3dx.Object3D.GetBoundBox(shafts), ScenarioScript.ViewSection, 1.5, ScenarioScript.SectionZoom);
            if (double.IsNaN(gap) || p1 == null || p2 == null) return;

            _runner.After(ScenarioScript.VerifyMeshAt, () => ShowMeshGap(pinionNode, gearNode, gap, (p1 + p2) * 0.5f));
        }

        // 잰 축간 거리를 설계 중심거리(감속기 속성 값 "122.5 / 160")와 견줘 보입니다. 둘 다 0.1 mm 안이면 일치로 봅니다.
        private void ShowCenterDistance(double first, double second)
        {
            string design = Uda(Node(ScenarioScript.NameReducer), ScenarioScript.UdaCenterDistance);
            double[] designs = design.Split('/').Select(s => { double v; return double.TryParse(s.Trim(), out v) ? v : double.NaN; }).ToArray();
            bool same = designs.Length == 2 && Math.Abs(designs[0] - first) < 0.1 && Math.Abs(designs[1] - second) < 0.1;
            ShowHud(string.Format("축간 거리 {0:0.0} / {1:0.0} mm · 설계 {2} {3}", first, second, design, same ? "✓ 일치" : "✗ 다름"));
        }

        // 단면 절단면은 맞물림부를 가리므로 걷고, 하우징을 숨겨 기어 한 쌍의 맞물림 틈을 재서 가까이 봅니다.
        private void ShowMeshGap(Data.Node pinionNode, Data.Node gearNode, double gap, Data.Vector3D mesh)
        {
            Batch(() =>
            {
                RemoveSection();
                vizcore3dx.Measure.Clear();
                ShowHousing(false);

                // 문구를 위로 띄우면 엔진이 지시선을 그립니다.
                Data.MeasureItem item = vizcore3dx.Measure.AddMinimumDistance(new List<Data.Node> { pinionNode }, new List<Data.Node> { gearNode }, new Data.Vector3D(0f, 0f, ScenarioScript.DimensionLift));
                if (item != null) StyleMeasure(item.ID, 2, ScenarioScript.KeyLabelTextSize);
            });
            ShowHud(string.Format("{0} ↔ {1} 맞물림 틈 {2:0.00} mm {3}", pinionNode.NodeName, gearNode.NodeName, gap, gap > 0 ? "✓ 간섭 없음" : "✗ 간섭"));

            FlyCamera(mesh, ScenarioScript.ViewMesh, ScenarioScript.MeshViewDistance, 2.0);
        }

        // 08 재가동 — 측정을 지우고 커버·볼트를 제자리로 되돌린 뒤, 기어열을 다시 돌리며 물러납니다.
        private void SceneRestart()
        {
            ClearHud();
            Batch(() =>
            {
                RemoveSection();
                vizcore3dx.Measure.Clear();
                vizcore3dx.Object3D.Transform.RestoreTransform(Nodes(ScenarioScript.NameLidParts));
                ShowHousing(true);
                vizcore3dx.Object3D.Show(Node(ScenarioScript.NameFlangeBolts), true);
                ShowGearTrain(true);
                StartSpin(true, ScenarioScript.RestartSpinSeconds, false);
            });
            Data.Node reducer = Node(ScenarioScript.NameReducer);
            _runner.After(1.0, () => ShowHud(string.Format("재가동 · 출력 {0} rpm", Uda(reducer, ScenarioScript.UdaOutputSpeed))));

            FlyToBox(ModelBox(), ScenarioScript.ViewIntro, 1.5, ScenarioScript.OutroZoom);
            WhenCameraArrives(() => Orbit(ScenarioScript.OutroOrbitDegrees, ScenarioScript.OutroOrbitSeconds));
        }

        #endregion

        #region 기어 돌리기 · 탑재 검사

        // 축 조립품마다 회전 속도 비(입력 = 1)를 구합니다. 이웃한 두 축에서 맞물린 기어 한 쌍(속성 Mate)의 잇수 비로 정해지고, 맞물릴 때마다 방향이 바뀝니다.
        private List<double> ShaftSpeeds()
        {
            List<Data.Node> assemblies = Nodes(ScenarioScript.NameShaftAssemblies);
            List<Data.Node> gears = GearsWithMate();
            List<double> speeds = new List<double> { 1.0 };
            for (int i = 0; i + 1 < assemblies.Count; i++)
            {
                Data.Node driver = gears.FirstOrDefault(g => IsUnder(g, assemblies[i]) && IsUnder(Node(Uda(g, ScenarioScript.UdaMate)), assemblies[i + 1]));
                double ratio = driver == null ? 1.0 : (double)Teeth(driver) / Teeth(Node(Uda(driver, ScenarioScript.UdaMate)));
                speeds.Add(-speeds[i] * ratio);
            }
            return speeds;
        }

        // 기어열을 축 둘레로 돌리는 애니메이션을 만들어 재생합니다. rampUp 이면 서서히 돌기 시작하고, rampDown 이면 hold 초 뒤 서서히 멈춥니다.
        // 회전 동작은 일정 속도라, 빨라지고 느려지는 구간은 짧은 조각으로 나눠 조각마다 각도를 줄이거나 늘립니다.
        private void StartSpin(bool rampUp, double hold, bool rampDown)
        {
            DeleteSpin();
            List<Data.Node> assemblies = Nodes(ScenarioScript.NameShaftAssemblies);
            List<double> speeds = ShaftSpeeds();

            // 조각 목록 (길이 초, 속도 배율)
            List<Tuple<double, double>> pieces = new List<Tuple<double, double>>();
            double piece = ScenarioScript.SpinRampSeconds / ScenarioScript.SpinRampSteps;
            if (rampUp) for (int k = 1; k <= ScenarioScript.SpinRampSteps; k++) pieces.Add(Tuple.Create(piece, (k - 0.5) / ScenarioScript.SpinRampSteps));
            pieces.Add(Tuple.Create(hold, 1.0));
            if (rampDown) for (int k = ScenarioScript.SpinRampSteps; k >= 1; k--) pieces.Add(Tuple.Create(piece, (k - 0.5) / ScenarioScript.SpinRampSteps));

            _spin = vizcore3dx.Animation.CreateAnimation("GearTrain");
            _spin.Activate();
            Data.Vector3D axis = new Data.Vector3D(0f, 1f, 0f);
            for (int i = 0; i < assemblies.Count; i++)
            {
                // 회전 중심은 축 조립품 상자 중심(축선 위)입니다. 도는 부품(축·기어·키)만 돌립니다.
                Data.BoundBox3D box = assemblies[i].GetBoundBox();
                Data.Vector3D center = new Data.Vector3D(box.CenterX, box.CenterY, box.CenterZ);
                Data.AnimationGroup group = _spin.CreateGroup(assemblies[i].NodeName);
                group.AddNodes(SpinParts(assemblies[i]));

                double t = 0;
                foreach (Tuple<double, double> p in pieces)
                {
                    float angle = (float)(2.0 * Math.PI * ScenarioScript.SpinInputTurnsPerSecond * speeds[i] * p.Item2 * p.Item1);
                    group.CreateRotationAction(Sec(t), Sec(p.Item1), center, axis, angle);
                    t += p.Item1;
                }
            }
            _spin.Duration = Sec(pieces.Sum(p => p.Item1));
            _spin.PlaybackTime = TimeSpan.Zero;
            _spin.Play();
        }

        // 축 조립품 아래에서 실제로 도는 부품 (속성 Type 이 SpinTypes 중 하나)
        private List<Data.Node> SpinParts(Data.Node assembly)
        {
            return _allNodes.Where(n => IsUnder(n, assembly) && ScenarioScript.SpinTypes.Any(t => IsType(n, t))).ToList();
        }

        private void DeleteSpin()
        {
            if (_spin == null) return;

            _spin.Stop();
            _spin.Deactivate();
            vizcore3dx.Animation.DeleteAnimation(_spin);
            _spin = null;
        }

        // 하우징을 X-Ray 로 비추고 기어열(축 조립품)만 제 색으로 보이거나, X-Ray 를 끕니다.
        private void ShowGearTrain(bool visible)
        {
            vizcore3dx.View.XRay.Clear();
            vizcore3dx.View.XRay.Enable = visible;
            if (!visible) return;

            if (_originalXRayColor == null) _originalXRayColor = vizcore3dx.View.XRay.ColorType;
            vizcore3dx.View.XRay.ColorType = Data.XRayColorTypes.OBJECT_COLOR;
            vizcore3dx.View.XRay.Select(Nodes(ScenarioScript.NameShaftAssemblies), true);
        }

        // 출력축을 인출한 높이(ShaftPull)에서 MountPath 씩 내려 안착하는 이동 간섭 검사를 만들고, 축을 맨 위 단계에 둡니다.
        // 고정 쪽은 보이는 부품 중 출력축 조립품을 뺀 전부입니다. ★숨긴 부품은 검사에서 빠집니다(캡 볼트를 숨기면 간섭 0).
        private Data.ClashTest CreateMountTest()
        {
            Data.Node shaft = Node(ScenarioScript.NameOutputShaftAssy);
            List<Data.Node> fixedParts = vizcore3dx.Object3D.FromFilter(Data.Object3dFilter.VISIBLE_PART).Where(n => !IsUnder(n, shaft)).ToList();
            return CreateLowerPathTest(vizcore3dx, fixedParts, shaft, ScenarioScript.ShaftPull, ScenarioScript.MountPath);
        }

        // 이동 경로 한 단계의 관통 결과
        private List<Data.ClashTestResultItem> Penetrations(Data.ClashTest test, Data.ClashMoveTestItem path)
        {
            List<Data.ClashTestResultItem> items = vizcore3dx.Clash.GetResultItem(test, path.ID, Manager.ClashManager.ResultGroupingOptions.PART) ?? new List<Data.ClashTestResultItem>();
            return items.Where(i => i.ResultKind == Data.ClashTestResultItem.ClashResultKind.PENETRATION).ToList();
        }

        // 출력축 베어링 캡을 하우징에 고정하는 볼트 조(볼트 + 와셔)
        private List<Data.Node> CapBoltSets()
        {
            Data.Node shaft = Node(ScenarioScript.NameOutputShaftAssy);
            return _allNodes.Where(n => IsType(n, ScenarioScript.TypeBolt) && IsUnder(n, shaft))
                .Select(n => _byIndex[n.ParentIndex]).GroupBy(n => n.Index).Select(g => g.First()).ToList();
        }

        // 인출한 축(맨 위 단계)과 아래 기어열이 함께 들어오는 범위 — 하우징 상자는 치워 둔 커버까지 품어 너무 커서 쓰지 않습니다.
        private Data.BoundBox3D MountViewBox()
        {
            return vizcore3dx.Object3D.GetBoundBox(Nodes(ScenarioScript.NameShaftAssemblies));
        }

        // node 가 root 아래(또는 root 자신)인지
        private bool IsUnder(Data.Node node, Data.Node root)
        {
            if (node == null || root == null) return false;
            for (Data.Node n = node; n != null; )
            {
                if (n.Index == root.Index) return true;
                Data.Node parent;
                n = _byIndex.TryGetValue(n.ParentIndex, out parent) ? parent : null;
            }
            return false;
        }

        #endregion

        #region 장면 도우미

        // 장면이 쓰는 부품이 열린 모델에 모두 있는지 확인합니다. 이름은 정확히 일치해야 합니다.
        private bool IsModelReady()
        {
            List<string> names = new List<string> { ScenarioScript.NameReducer, ScenarioScript.NameFlangeBolts, ScenarioScript.NameOutputShaftAssy, ScenarioScript.NameMeshGear };
            names.AddRange(ScenarioScript.NameLidParts);
            names.Add(ScenarioScript.NameHousing);
            names.AddRange(ScenarioScript.NameShafts);
            names.AddRange(ScenarioScript.NameShaftAssemblies);

            string missing = names.FirstOrDefault(n => !_byName.ContainsKey(n));
            if (missing == null && !_byName.ContainsKey(Uda(_byName[ScenarioScript.NameMeshGear], ScenarioScript.UdaMate))) missing = ScenarioScript.NameMeshGear + " 의 속성 " + ScenarioScript.UdaMate;
            if (missing == null) return true;

            SetStatus(string.Format("부품 '{0}' 이 모델에 없습니다. 샘플 모델 Gearbox.vizx 를 열거나 ScenarioScript.cs 의 부품 이름을 바꿔 주세요.", missing));
            return false;
        }

        private Data.Node Node(string name)
        {
            Data.Node node;
            return name != null && _byName.TryGetValue(name, out node) ? node : null;
        }

        private List<Data.Node> Nodes(params string[] names)
        {
            return names.Select(n => _byName[n]).ToList();
        }

        private Data.BoundBox3D ModelBox()
        {
            return vizcore3dx.Object3D.GetBoundBox(vizcore3dx.Object3D.GetRootNodes());
        }

        // 애니메이션을 멈추고 비활성으로 돌린 뒤 지웁니다. 비활성으로 돌리면 애니메이션이 옮긴 부품이 제자리로 돌아옵니다.
        private void DeleteAnimation()
        {
            if (_animation == null) return;

            _animation.Stop();
            _animation.Deactivate();
            vizcore3dx.Animation.DeleteAnimation(_animation);
            _animation = null;
        }

        // 하우징 조립품 전체(케이스·커버·볼트·부속)를 보이거나 숨깁니다 (맞물림부를 들여다볼 때).
        private void ShowHousing(bool visible)
        {
            if (_housingHidden == !visible) return;
            if (_byName.Count == 0) return;

            vizcore3dx.Object3D.Show(Node(ScenarioScript.NameHousing), visible);
            _housingHidden = !visible;
        }

        // 축 높이에서 수평으로 자르고 아래쪽을 남깁니다. 잘린 면은 채웁니다(부품 수가 적어 느려지지 않습니다).
        private void CutAtShaftHeight(float z)
        {
            RemoveSection();

            if (_originalCapFill == null) _originalCapFill = vizcore3dx.Section.IsCapFillEnabled;
            vizcore3dx.Section.IsCapFillEnabled = true;

            Data.BoundBox3D model = ModelBox();
            _section = AddSectionKeepBelow(vizcore3dx, new Data.Vector3D(model.CenterX, model.CenterY, z));
        }

        private void RemoveSection()
        {
            if (_section != null) vizcore3dx.Section.Clear();
            _section = null;

            if (_originalCapFill != null) vizcore3dx.Section.IsCapFillEnabled = _originalCapFill.Value;
            _originalCapFill = null;
        }

        // 두 축 중심 사이 X 방향 거리를 잽니다. 글자는 두 점 가운데 위쪽에 둡니다.
        private void AddAxialDistance(Data.Vector3D from, Data.Vector3D to)
        {
            Data.Vector3D text = (from + to) * 0.5f + new Data.Vector3D(0f, 0f, ScenarioScript.DimensionLift);
            uint id;
            if (vizcore3dx.Measure.AddDistanceAxialDirection(Data.AxisDistanceDirection.X, text, from, to, out id)) StyleMeasure(id, 1);
        }

        // 측정 하나의 표시 스타일을 바꿉니다(전역 설정은 건드리지 않음) — 어두운 상자 · 흰 글씨 · 강조색 선.
        private void StyleMeasure(uint id, byte decimals, Data.TextSizeType textSize = ScenarioScript.LabelTextSize)
        {
            Data.MeasureCustomStyle style = vizcore3dx.Measure.GetStyle(id);
            if (style == null) return;

            style.BoxFillColor = ScenarioScript.ColorPanel;
            style.BoxStrokeColor = ScenarioScript.ColorAccent;
            style.TextColor = ScenarioScript.ColorText;
            style.TextSize = textSize;
            style.LineStrokeColor = ScenarioScript.ColorAccent;
            style.LineStrokeThickness = ScenarioScript.LineThickness;
            style.ArrowColor = ScenarioScript.ColorAccent;
            style.ArrowHeadSize = ScenarioScript.ArrowHeadSize;
            style.DecimalPlace = decimals;
            style.IsTypeEnabled = false;
            style.IsUnitEnabled = true;
            vizcore3dx.Measure.SetStyle(id, style);
        }

        // 방향 스윕 표시를 옅게 — 통과 볼륨이 화면을 덮지 않게 투명도를 낮추고 근접 개체 색칠은 끕니다. 바꾸기 전 값은 정리할 때 되돌립니다.
        private void ApplySweepStyle()
        {
            Data.ClashSweepStyle style = vizcore3dx.Clash.Sweep.Style;
            if (_originalSweepStyle == null) _originalSweepStyle = style.Clone();

            style.VolumeOpacity = ScenarioScript.SweepVolumeOpacity;
            style.FreeColor = ScenarioScript.SweepFreeColor;
            style.BlockedColor = ScenarioScript.SweepBlockedColor;
            style.ShowNearMiss = false;
            style.ShowArrow = true;
        }

        private void RestoreSweepStyle()
        {
            if (_originalSweepStyle == null) return;

            Data.ClashSweepStyle style = vizcore3dx.Clash.Sweep.Style;
            style.VolumeOpacity = _originalSweepStyle.VolumeOpacity;
            style.FreeColor = _originalSweepStyle.FreeColor;
            style.BlockedColor = _originalSweepStyle.BlockedColor;
            style.ShowNearMiss = _originalSweepStyle.ShowNearMiss;
            style.ShowArrow = _originalSweepStyle.ShowArrow;
            _originalSweepStyle = null;
        }

        // 커버를 들어 뒤로 치우는 길까지 들어오는 범위
        private Data.BoundBox3D LidPathBox()
        {
            Data.BoundBox3D m = ModelBox();
            Data.Vector3D d = ScenarioScript.LidAsideDirection * ScenarioScript.LidAside;
            return new Data.BoundBox3D(
                Math.Min(m.MinX, m.MinX + d.X), Math.Min(m.MinY, m.MinY + d.Y), m.MinZ,
                Math.Max(m.MaxX, m.MaxX + d.X), Math.Max(m.MaxY, m.MaxY + d.Y), m.MaxZ + ScenarioScript.LidLift);
        }

        // 방향 스윕 볼륨(최대 거리만큼 뻗음)이 들어오는 범위 — 대상 위쪽으로만 늘립니다(통과 방향이 위라서).
        private Data.BoundBox3D SweepViewBox(Data.Node target)
        {
            Data.BoundBox3D m = ModelBox();
            Data.BoundBox3D t = target.GetBoundBox();
            return new Data.BoundBox3D(m.MinX, m.MinY, m.MinZ, m.MaxX, m.MaxY, (float)Math.Max(m.MaxZ, t.MaxZ + ScenarioScript.SweepMaxDistance * 0.6));
        }

        // 여러 상태(단면·숨김·X-Ray·애니메이션 등)를 한꺼번에 바꿀 때 — 중간 과정이 화면에 그려지지 않게 렌더링을 묶습니다.
        private void Batch(Action change)
        {
            vizcore3dx.BeginUpdate();
            try
            {
                change();
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        // 노드 속성 값 하나를 읽습니다. 없으면 빈 문자열.
        private static string Uda(Data.Node node, string key)
        {
            string value;
            return node != null && node.GetUDA().TryGetValue(key, out value) ? value : "";
        }

        // 속성 Type 이 type 인지 — 종류마다 한 번만 속성 검색으로 노드 목록을 받아 둡니다.
        // (부품마다 GetUDA 를 부르면 분해 장면을 만드는 동안 화면이 3초 넘게 멈췄다)
        private bool IsType(Data.Node node, string type)
        {
            if (node == null) return false;

            HashSet<int> indices;
            if (!_typeIndex.TryGetValue(type, out indices))
            {
                indices = new HashSet<int>(vizcore3dx.Object3D.UDA.GetCategoryNameValueNodes(ScenarioScript.UdaCategory, ScenarioScript.UdaType, type).Select(n => n.Index));
                _typeIndex[type] = indices;
            }
            return indices.Contains(node.Index);
        }

        // 잇수 속성 (없으면 0)
        private static int Teeth(Data.Node gear)
        {
            int teeth;
            return int.TryParse(Uda(gear, ScenarioScript.UdaTeeth), out teeth) ? teeth : 0;
        }

        // 속성 Type=Gear 이고 상대 기어(Mate)가 모델에 있는 기어들
        private List<Data.Node> GearsWithMate()
        {
            return vizcore3dx.Object3D.UDA.GetCategoryNameValueNodes(ScenarioScript.UdaCategory, ScenarioScript.UdaType, ScenarioScript.TypeGear)
                .Where(g => _byName.ContainsKey(Uda(g, ScenarioScript.UdaMate))).ToList();
        }

        private static TimeSpan Sec(double seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        // 축 방향을 "+Z" 같은 글자로 바꿉니다. 축 방향이 아니면 성분을 그대로 씁니다.
        private static string DirectionName(Data.Vector3D d)
        {
            if (Math.Abs(d.X) > 0.99f) return d.X > 0 ? "+X" : "−X";
            if (Math.Abs(d.Y) > 0.99f) return d.Y > 0 ? "+Y" : "−Y";
            if (Math.Abs(d.Z) > 0.99f) return d.Z > 0 ? "+Z" : "−Z";
            return string.Format("({0:0.00}, {1:0.00}, {2:0.00})", d.X, d.Y, d.Z);
        }

        #endregion

        #region SDK 기법 — 폼 상태 없이 복사해 쓸 수 있는 도우미

        // 방향 스윕 옵션 — 최대 거리·표본 수·맞닿음 허용 거리
        private static Data.ClashSweepOptions SweepOptions()
        {
            Data.ClashSweepOptions options = new Data.ClashSweepOptions();
            options.MaxDistanceMm = ScenarioScript.SweepMaxDistance;
            options.MaxSampleCount = ScenarioScript.SweepMaxSamples;

            // ★기본 접촉 허용(5 mm)이면 베어링이 끼워진 하우징이 "맞닿은 부품"으로 빠져 ±X 가 거짓 통과로 나옵니다 — 0.1 mm 로 줄이면 +Z 만 통과합니다.
            options.ContactToleranceMm = ScenarioScript.SweepContactTolerance;
            return options;
        }

        // moving 을 lift 만큼 올린 뒤 steps 씩 내려 안착하는 이동 간섭 검사를 만들고, 맨 위 단계에 둡니다. 만들지 못하면 null 을 돌려줍니다.
        private static Data.ClashTest CreateLowerPathTest(VIZCore3DX.NET.VIZCore3DXControl vizcore3dx, List<Data.Node> fixedParts, Data.Node moving, float lift, float[] steps)
        {
            Data.ClashTest test = vizcore3dx.Clash.CreateMovingTest(fixedParts, new List<Data.Node> { moving }, false, 0f, 0f, 0f);
            if (test == null) return null;

            // 경로를 더하는 동안 축이 실제로 움직입니다 — 올렸다 다 내리면 안착 위치로 돌아옵니다.
            vizcore3dx.Clash.AddTestPath(test, new Data.Vector3D(0f, 0f, lift), 0f, 0f, 0f);
            foreach (float step in steps)
                vizcore3dx.Clash.AddTestPath(test, new Data.Vector3D(0f, 0f, -step), 0f, 0f, 0f);

            vizcore3dx.Clash.ApplyTestPath(test, vizcore3dx.Clash.GetTestPaths(test)[0].ID);
            return test;
        }

        // position 높이에서 수평(Z)으로 자르고 아래쪽을 남기는 단면을 만듭니다. 자르는 평면의 사각형은 숨깁니다. 만들지 못하면 null 을 돌려줍니다.
        private static Data.SectionItem AddSectionKeepBelow(VIZCore3DX.NET.VIZCore3DXControl vizcore3dx, Data.Vector3D position)
        {
            Data.SectionItem section = vizcore3dx.Section.Add(false, Data.Axis.Z);
            if (section == null) return null;

            vizcore3dx.Section.SetSectionPosition(section.ID, position);
            vizcore3dx.Section.Enable(true);

            // 이 단면만 뒤집어 아래쪽을 남깁니다(선택과 무관).
            vizcore3dx.Section.InvertDirection(section.ID);
            vizcore3dx.Section.Deselect();

            // 자르는 평면의 사각형은 숨기고 절단만 남깁니다.
            section.Show(false);
            return section;
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
            if (next == null || !vizcore3dx.Model.IsOpen()) return;
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
