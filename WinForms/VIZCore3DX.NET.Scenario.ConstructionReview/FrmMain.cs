using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Scenario.ConstructionReview
{
    // 시나리오 예제 "철골 10층 시공 검토 — 4D 순서 · 전수 간섭 · 교차선"
    // 모델 트리의 층·공정 묶음으로 4D 시공 순서(가시성 애니메이션)를 만들고, 전체 간섭 검사로 관통을 찾아 X-Ray·교차선·단면으로 보여 줍니다.
    // 장면 하나 = 메서드 하나(#region 장면), 장면의 설명·길이와 장면에 쓰는 값(이름 규칙·속성 키·카메라)은 ScenarioScript.cs 한 곳에,
    // 재생은 ScenarioRunner.cs 에 있습니다.
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 조작부 — 리본 사용자 탭 "시나리오" (뷰어 초기화 뒤에 만듭니다)
        private ScenarioRibbon _ribbon;

        // 대본과 재생기
        private List<ScenarioShot> _shots;
        private ScenarioRunner _runner;

        // 모델을 여는 데 걸린 시간(초)과 파트 수
        private double _openSeconds;
        private int _partCount;

        // 기초 · 4D 단계(층 × 공정 + 지붕)
        private Data.Node _foundation;
        private readonly List<Stage> _stages = new List<Stage>();
        private DateTime _firstStart;

        // 이름 → 노드 (샘플 모델은 모든 노드 이름이 유일합니다). 속성 조회·간섭 결과가 주는 노드 대신 이 노드를 씁니다.
        private readonly Dictionary<string, Data.Node> _byName = new Dictionary<string, Data.Node>();

        // 관통 장면에 붙인 노트
        private readonly List<uint> _notes = new List<uint>();

        // 시나리오가 바꾸기 전의 X-Ray 강조 색 유형
        private Data.XRayColorTypes? _originalXRayColor;
        private DateTime _lastStart;

        // 4D 한 단계 = 작업 패키지 하나. 나타나는 시각은 공정표 착수일(Schedule/PlannedStart)에서 정합니다.
        private class Stage
        {
            public Data.Node Node;
            public int Seq;
            public DateTime Start;
            public string Activity;
            public double At;
            public bool DropIn;
        }

        // 4D 시공 순서 애니메이션과 지금 화면에 띄운 단계 번호
        private Data.Animation _sequence;
        private int _shownStage = -1;
        private bool _sequencePlaying;

        // 간섭 검사와 그 결과 (관통만, 보여 줄 순서로)
        private Data.ClashTest _clashTest;
        private Data.ClashTest _clashTestB;

        // 검사가 끝났는지 — 번호 버튼으로 뒤 장면을 볼 때 선행 장면의 검사가 끝날 때까지 기다리는 데 씁니다.
        private bool _clashChecked;
        private bool _revBChecked;

        // 연 모델 파일 · 최상위 노드(Rev A · 더해 연 Rev B) · 부품 인덱스
        private string _modelPath;
        private Data.Node _rootA;
        private Data.Node _rootB;
        private HashSet<int> _partIndex = new HashSet<int>();

        // 공종별 보기에서 칠한·숨긴 부품 · 층 단면을 내리는 타이머 · 층 바닥 높이
        private List<Data.Node> _basicsColored;
        private List<Data.Node> _basicsHidden;
        private readonly Timer _sweepTimer = new Timer();
        private EventHandler _sweepTick;
        private string _sweepLevel;
        private List<Tuple<string, float>> _levelElevations;

        // 공정 현황에서 칠한 부품 · 설계 변경 비교 결과(바뀐 부재 수)
        private List<Data.Node> _statusColored;
        private int _revBChanged;
        private readonly Stopwatch _clashWatch = new Stopwatch();

        // 간섭 결과 전체 · 가까이 볼 곳(결과, 먼저 부를 부재, 상대 부재) · 결과 부재의 속성(이름으로 한 번만 읽음)
        private readonly List<Data.ClashTestResultItem> _clashes = new List<Data.ClashTestResultItem>();
        private readonly List<Tuple<Data.ClashTestResultItem, Data.Node, Data.Node>> _focus = new List<Tuple<Data.ClashTestResultItem, Data.Node, Data.Node>>();
        private readonly Dictionary<string, Dictionary<string, string>> _clashUda = new Dictionary<string, Dictionary<string, string>>();

        // 단면 (정리할 때 지웁니다)
        private Data.SectionItem _section;
        private bool? _originalCapFill;

        // 3D 뷰에 띄운 문구
        private uint _hudNote;
        private Size _renderSize;

        // 실내 장면에서 소환한 아바타
        private int _avatarID;

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

            vizcore3dx.Clash.OnClashTestFinishedEvent += Clash_OnClashTestFinishedEvent;

            // 진행 창(간섭 검사 등)을 띄우지 않습니다. 진행 상황은 3D 뷰 왼쪽 위 문구로 보입니다.
            vizcore3dx.EnableProgressForm = false;
            _runner.Tick += Runner_Tick;

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
            ScenarioScript.Intro.Play = SceneIntro;
            ScenarioScript.Sequence.Play = SceneSequence;
            ScenarioScript.Discipline.Play = SceneDiscipline;
            ScenarioScript.SectionSweep.Play = SceneSectionSweep;
            ScenarioScript.Walk.Play = SceneWalk;
            ScenarioScript.Progress.Play = SceneProgress;
            ScenarioScript.Clash.Play = SceneClash;
            ScenarioScript.ClashSummary.Play = SceneClashSummary;
            ScenarioScript.Penetration1.Play = () => ScenePenetration(0);
            ScenarioScript.Penetration2.Play = () => ScenePenetration(1);
            ScenarioScript.Penetration3.Play = () => ScenePenetration(2);
            ScenarioScript.Sleeve.Play = SceneSleeve;
            ScenarioScript.RevB.Play = SceneRevB;
            ScenarioScript.Outro.Play = SceneOutro;

            // 번호 버튼으로 바로 볼 때 먼저 실행할 장면 — 08~12 는 전체 간섭 검사(07) 결과를, 14 는 07 과 Rev B(13)가 남긴 화면을 씁니다.
            foreach (ScenarioShot shot in new[] { ScenarioScript.ClashSummary, ScenarioScript.Penetration1, ScenarioScript.Penetration2,
                ScenarioScript.Penetration3, ScenarioScript.Sleeve })
                shot.Before = new[] { 7 };
            ScenarioScript.Outro.Before = new[] { 7, 13 };

            // 간섭 검사는 비동기라, 선행 장면으로 실행할 때 끝날 때까지 기다립니다(검사를 만들지 못했으면 바로 넘어갑니다).
            ScenarioScript.Clash.IsDone = () => _clashTest == null || _clashChecked;
            ScenarioScript.RevB.IsDone = () => _clashTestB == null || _revBChecked;

            return new List<ScenarioShot>
            {
                ScenarioScript.Intro, ScenarioScript.Sequence, ScenarioScript.Discipline, ScenarioScript.SectionSweep, ScenarioScript.Walk, ScenarioScript.Progress, ScenarioScript.Clash,
                ScenarioScript.ClashSummary, ScenarioScript.Penetration1, ScenarioScript.Penetration2, ScenarioScript.Penetration3,
                ScenarioScript.Sleeve, ScenarioScript.RevB, ScenarioScript.Outro,
            };
        }

        // 창을 닫을 때 재생 타이머와 단면 타이머부터 멈추고, 간섭 검사 완료 이벤트를 해제합니다.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _runner.Reset();
            _sweepTimer.Stop();
            vizcore3dx.Clash.OnClashTestFinishedEvent -= Clash_OnClashTestFinishedEvent;
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

        // 모델을 열고 4D 시공 순서를 미리 만듭니다(수 초). 여는 데 걸린 시간은 첫 장면 문구에, 연 파일의 폴더는 Rev B 장면에 씁니다.
        // 샘플 모델 건축\Building_RevA.vizx 를 엽니다. 같은 폴더의 Building_RevB.vizx 를 비교에 씁니다(ScenarioScript.cs).
        private void Ribbon_OpenModel()
        {
            if (_runner.IsPlaying) return;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "VIZCore3DX 모델 (*.vizx)|*.vizx|모든 파일 (*.*)|*.*";
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                if (!OpenModel(dialog.FileName)) { ClearScene(); SetStatus("모델을 열 수 없습니다."); return; }
            }

            ClearScene();
            if (!IsModelReady()) return;
            SetStatus(string.Format("모델을 열고 4D 순서 {0}단계를 만들었습니다. [전체 재생]이나 장면 번호를 누르세요.", _stages.Count));
        }

        // 모델을 열고 걸린 시간을 잰 뒤, 층·공정 묶음을 찾아 4D 순서를 만듭니다.
        private bool OpenModel(string path)
        {
            if (File.Exists(path) == false) return false;
            if (vizcore3dx.Model.IsOpen()) vizcore3dx.Model.Close();
            _sequence = null;
            _clashTest = null;
            _clashTestB = null;
            _rootB = null;
            _statusColored = null;
            _basicsColored = null;
            _basicsHidden = null;
            _levelElevations = null;
            _modelPath = path;
            _section = null;
            _clashes.Clear();
            _focus.Clear();
            _clashUda.Clear();

            Stopwatch watch = Stopwatch.StartNew();
            bool opened = vizcore3dx.Model.Open(path);
            _openSeconds = watch.Elapsed.TotalSeconds;
            if (!opened) return false;

            _partIndex = new HashSet<int>(vizcore3dx.Object3D.FromFilter(Data.Object3dFilter.PART).Select(n => n.Index));
            _partCount = _partIndex.Count;
            _rootA = vizcore3dx.Object3D.GetRootNodes().FirstOrDefault();
            FindStages();
            if (_stages.Count > 0) BuildSequence();
            return true;
        }

        // 속성 Type=Work Package 인 노드(작업 패키지)를 모아 설치 순서(InstallSeq)로 줄 세우고, 착수일을 재생 시각으로 바꿉니다.
        // 기초 층 작업은 첫 장면부터 보이므로 뺍니다.
        private void FindStages()
        {
            _stages.Clear();

            List<Data.Node> all = vizcore3dx.Object3D.FromFilter(Data.Object3dFilter.ALL);
            _byName.Clear();
            foreach (Data.Node n in all)
                if (!_byName.ContainsKey(n.NodeName)) _byName.Add(n.NodeName, n);
            _foundation = ByName(ScenarioScript.NameFoundation);

            foreach (Data.Node found in vizcore3dx.Object3D.UDA.GetCategoryNameValueNodes(ScenarioScript.UdaCategory, ScenarioScript.UdaType, ScenarioScript.TypeWorkPackage))
            {
                Data.Node node = ByName(found.NodeName);
                if (node == null) continue;
                Dictionary<string, string> uda = node.GetUDA();
                if (Value(uda, ScenarioScript.UdaLevel) == ScenarioScript.LevelFoundation) continue;

                int seq;
                DateTime start;
                if (!int.TryParse(Value(uda, ScenarioScript.UdaInstallSeq), out seq)) continue;
                if (!DateTime.TryParseExact(Value(uda, ScenarioScript.UdaPlannedStart), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out start)) continue;

                string activity = Value(uda, ScenarioScript.UdaActivity);
                _stages.Add(new Stage { Node = node, Seq = seq, Start = start, Activity = activity, DropIn = activity.EndsWith(ScenarioScript.DropInActivitySuffix) });
            }
            if (_stages.Count == 0) return;

            _stages.Sort((a, b) => a.Seq.CompareTo(b.Seq));
            _firstStart = _stages.Min(st => st.Start);
            _lastStart = _stages.Max(st => st.Start);
            double days = Math.Max((_lastStart - _firstStart).TotalDays, 1.0);
            foreach (Stage stage in _stages)
                stage.At = ScenarioScript.SequenceLead + (stage.Start - _firstStart).TotalDays / days * ScenarioScript.SequenceSeconds;
        }

        // 4D 순서 — 작업 패키지마다 처음엔 숨겼다가 착수일이 되면 보입니다. 기둥은 위에 올려 뒀다가 제자리로 꽂힙니다.
        // 120여 개를 만드는 데 몇 초 걸리므로 재생 전에(모델을 열 때) 만듭니다(그동안 화면이 멈춥니다).
        private void BuildSequence()
        {
            _sequence = vizcore3dx.Animation.CreateAnimation("ConstructionSequence");
            _sequence.Activate();

            // Duration 을 직접 주지 않으면 0 초라 Play 가 바로 끝납니다.
            _sequence.Duration = TimeSpan.FromSeconds(_stages.Max(st => st.At) + ScenarioScript.DropSeconds + 0.5);

            foreach (Stage stage in _stages)
            {
                Data.AnimationGroup group = _sequence.CreateGroup(stage.Node.NodeName);
                group.AddNode(stage.Node);

                TimeSpan at = TimeSpan.FromSeconds(stage.At);
                group.CreateVisibilityAction(TimeSpan.Zero, false);
                group.CreateVisibilityAction(at, true);

                // 같은 노드를 다른 그룹에 넣어 따로 올리면 적용되지 않습니다 — 한 그룹 안에서 올렸다 내립니다.
                if (!stage.DropIn) continue;
                group.CreateTranslationAction(TimeSpan.Zero, TimeSpan.FromSeconds(ScenarioScript.LiftSeconds), new Data.Vector3D(0f, 0f, 1f), ScenarioScript.DropHeight);
                group.CreateTranslationAction(at, TimeSpan.FromSeconds(ScenarioScript.DropSeconds), new Data.Vector3D(0f, 0f, -1f), ScenarioScript.DropHeight);
            }
        }

        private static string Value(Dictionary<string, string> uda, string key)
        {
            string value;
            return uda != null && uda.TryGetValue(key, out value) ? value : "";
        }

        private static string Uda(Data.Node node, string key)
        {
            return node == null ? "" : Value(node.GetUDA(), key);
        }

        private Data.Node ByName(string name)
        {
            Data.Node node;
            return name != null && _byName.TryGetValue(name, out node) ? node : null;
        }

        #endregion

        #region 3. 장면

        // 첫 장면부터 끝까지 이어서 재생합니다. 첫 장면 전에 건물·4D 단계가 모델에 있는지 확인합니다.
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

        // 4D 재생 중에는 지금 단계(층 · 공정)를 왼쪽 위에 띄웁니다. 애니메이션에 진행 이벤트가 없어 재생 시간을 읽습니다.
        private void Runner_Tick()
        {
            if (!_sequencePlaying || _sequence == null || _stages.Count == 0) return;

            // 지금까지 나타난 작업 중 마지막 것과, 재생 시각을 공정표 날짜로 되돌린 값을 띄웁니다.
            double t = _sequence.PlaybackTime.TotalSeconds;
            int stage = _stages.FindLastIndex(st => st.At <= t);
            if (stage < 0 || stage == _shownStage) return;

            _shownStage = stage;
            double days = (_lastStart - _firstStart).TotalDays;
            DateTime date = _firstStart.AddDays(Math.Max(0.0, t - ScenarioScript.SequenceLead) / ScenarioScript.SequenceSeconds * days);
            if (date > _lastStart) date = _lastStart;
            ShowHud(string.Format("{0:yyyy-MM-dd} · {1}", date, _stages[stage].Activity));
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

        // 재생을 멈추고 처음으로 되돌린 뒤 간섭 검사·단면·X-Ray 를 지웁니다. 4D 순서는 지우지 않고 처음(기초만 보이는 상태)으로 되돌립니다.
        // 진행 중인 간섭 검사는 검사를 지워 두면 완료 이벤트에서 ID 가 맞지 않아 무시됩니다.
        private void ClearScene()
        {
            _runner.Reset();
            if (_ribbon != null) _ribbon.SetCurrent(0);

            if (vizcore3dx.Model.IsOpen()) Clear3D();
            _clashes.Clear();
            _focus.Clear();
            _clashUda.Clear();
            _shownStage = -1;
            _sequencePlaying = false;
            _clashChecked = false;
            _revBChecked = false;
        }

        private void Clear3D()
        {
            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.Clash.ClearResultSymbol();
                if (_clashTest != null) vizcore3dx.Clash.Delete(_clashTest);
                _clashTest = null;
                if (_clashTestB != null) vizcore3dx.Clash.Delete(_clashTestB);
                _clashTestB = null;

                // 더해 연 Rev B 를 지우고 공정 현황 색을 걷습니다.
                vizcore3dx.Compare.Reset();
                if (_rootB != null) vizcore3dx.Object3D.Delete(new List<Data.Node> { _rootB });
                _rootB = null;
                EndProgress();
                EndBasics();
                EndWalk();

                RemoveSection();
                ClearNotes();
                vizcore3dx.View.XRay.Clear();
                vizcore3dx.View.XRay.Enable = false;
                if (_originalXRayColor != null) vizcore3dx.View.XRay.ColorType = _originalXRayColor.Value;
                _originalXRayColor = null;

                if (_sequence != null)
                {
                    if (!_sequence.IsActive) _sequence.Activate();
                    _sequence.Stop();
                }
                ShowFoundationOnly();
                ClearHud();
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        #endregion

        #region 장면

        // 01 철골 10층 — 기초만 남기고 높은 곳에서 건물 전체 자리를 내려다봅니다.
        private void SceneIntro()
        {
            ShowFoundationOnly();
            ShowHud(string.Format("부품 {0:#,0} · 열기 {1:0.0}초", _partCount, _openSeconds));
            FlyToBox(_foundation.GetBoundBox(), ScenarioScript.ViewAerial, 1.5, ScenarioScript.IntroZoom);
            _runner.After(1.5, () => Orbit(ScenarioScript.IntroOrbitDegrees, ScenarioScript.IntroOrbitSeconds));
        }

        // 02 4D 시공 순서 — 4D 순서를 재생하며 건물을 천천히 돕니다. 지금 단계는 Runner_Tick 이 왼쪽 위에 띄웁니다.
        private void SceneSequence()
        {
            if (_sequence == null) return;

            _shownStage = -1;
            if (!_sequence.IsActive) _sequence.Activate();
            _sequence.PlaybackTime = TimeSpan.Zero;
            _sequence.Play();
            _sequencePlaying = true;
            FlyToBox(ModelBox(), ScenarioScript.ViewAerial, 3.0, ScenarioScript.BuildingZoom);
            _runner.After(3.0, () => Orbit(ScenarioScript.SequenceOrbitDegrees, ScenarioScript.SequenceOrbitSeconds));
        }

        // 07 전체 간섭 검사 — 4D 순서를 끝내고 전체 부품의 간섭을 검사합니다. 결과는 검사 완료 이벤트에서 받습니다.
        private void SceneClash()
        {
            _sequencePlaying = false;
            ClearHud();

            // 애니메이션이 옮긴 위치로 검사하지 않도록 비활성으로 돌립니다(기둥이 내려간 채로 검사하면 관통이 잘못 잡힙니다). 비활성은 시작 전 보이기 상태로 돌아가므로 전부 다시 보입니다.
            Batch(() =>
            {
                EndProgress();
                if (_sequence != null && _sequence.IsActive) _sequence.Deactivate();
                vizcore3dx.Object3D.Show(Data.Object3DKind.ALL, true);
            });

            List<Data.Node> parts = vizcore3dx.Object3D.FromFilter(Data.Object3dFilter.PART);
            _clashTest = vizcore3dx.Clash.CreateSelectionTest(Data.ClashTest.ClashTestKind.SELECTED_MODEL, parts, false, 0f, 0f, 0f);
            if (_clashTest == null) { ShowHud("간섭 검사를 만들 수 없습니다"); return; }

            ShowHud(string.Format("{0:#,0} 부품 간섭 검사 중…", parts.Count));
            FlyToBox(ModelBox(), ScenarioScript.ViewAerial, 1.0, ScenarioScript.BuildingZoom);
            _runner.After(1.0, () => Orbit(ScenarioScript.ClashOrbitDegrees, ScenarioScript.ClashOrbitSeconds));
            _clashWatch.Restart();
            vizcore3dx.Clash.PerformInterferenceCheck(_clashTest.ID);
        }

        // 간섭 검사가 끝나면 결과 기호를 전부 띄우고, 가까이 볼 곳을 유형마다 하나씩 고릅니다.
        private void Clash_OnClashTestFinishedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ClashEventArgs e)
        {
            if (InvokeRequired) { BeginInvoke(new Action(() => Clash_OnClashTestFinishedEvent(sender, e))); return; }
            if (_clashTestB != null && e.ID == _clashTestB.ID) { OnRevBChecked(); return; }
            if (_clashTest == null || e.ID != _clashTest.ID) return;

            double seconds = _clashWatch.Elapsed.TotalSeconds;
            List<Data.ClashTestResultItem> items = vizcore3dx.Clash.GetResultItem(_clashTest, Manager.ClashManager.ResultGroupingOptions.PART) ?? new List<Data.ClashTestResultItem>();

            _clashes.Clear();
            _clashes.AddRange(items);
            _focus.Clear();
            foreach (string[] types in ScenarioScript.FocusTypes)
            {
                Tuple<Data.ClashTestResultItem, Data.Node, Data.Node> hit = _clashes.Select(i => Ordered(i, types)).Where(t => t != null)
                    .OrderBy(t => Value(ClashUda(t.Item2.NodeName), ScenarioScript.UdaLevel)).FirstOrDefault();
                if (hit != null) _focus.Add(hit);
            }

            ShowHud(string.Format("간섭 검사 {0:0.0}초 · 간섭 {1}건", seconds, _clashes.Count));
            vizcore3dx.Clash.ShowResultSymbol(_clashTest.ID, true, false);
            _clashChecked = true;
        }

        // 08 공종 쌍별 집계 — 결과 기호를 전부 띄운 채 간섭 부재만 또렷하게 남기고, 공종 쌍별 · 층별 건수를 띄웁니다.
        // 공종은 두 부재의 속성(General/Discipline)에서 읽습니다.
        private void SceneClashSummary()
        {
            if (_clashes.Count == 0) { ShowHud("간섭 결과가 없습니다"); return; }

            List<string> pairs = _clashes.GroupBy(PairName).OrderByDescending(g => g.Count()).ThenBy(g => g.Key)
                .Select(g => string.Format("{0} {1}", g.Key, g.Count())).ToList();
            var levels = _clashes.GroupBy(i => Value(ClashUda(i.NodeNameA), ScenarioScript.UdaLevel)).OrderByDescending(g => g.Count()).ThenBy(g => g.Key).ToList();
            ShowHud(string.Format("간섭 {0}건 · 공종 쌍 {1}가지 · {2}개 층", _clashes.Count, pairs.Count, levels.Count));

            List<Data.Node> nodes = _clashes.SelectMany(i => new[] { ByName(i.NodeNameA), ByName(i.NodeNameB) }).Where(n => n != null)
                .GroupBy(n => n.Index).Select(g => g.First()).ToList();
            Batch(() =>
            {
                vizcore3dx.View.XRay.Clear();
                vizcore3dx.View.XRay.Enable = true;
                if (_originalXRayColor == null) _originalXRayColor = vizcore3dx.View.XRay.ColorType;
                vizcore3dx.View.XRay.ColorType = Data.XRayColorTypes.OBJECT_COLOR;
                vizcore3dx.View.XRay.Select(nodes, true);
                vizcore3dx.Clash.ShowResultSymbol(_clashTest.ID, true, false);
            });

            FlyToBox(ModelBox(), ScenarioScript.ViewSide, 2.0, ScenarioScript.SummaryZoom);
            _runner.After(2.0, () => Orbit(ScenarioScript.SummaryOrbitDegrees, ScenarioScript.SummaryOrbitSeconds));
            _runner.After(ScenarioScript.SummaryLevelsAt, () =>
                ShowHud("많은 층 — " + string.Join(" · ", levels.Take(4).Select(g => string.Format("{0} {1}건", g.Key, g.Count())))));
        }

        // 09~11 간섭 1~3 — 간섭 하나를 X-Ray 로 두 부재만 남겨 보이고, 교차선과 함께 그 자리로 갑니다.
        private void ScenePenetration(int index)
        {
            if (index >= _focus.Count) { ShowHud("간섭 결과가 없습니다"); return; }

            Data.ClashTestResultItem item = _focus[index].Item1;
            Data.Node first = _focus[index].Item2;
            Data.Node second = _focus[index].Item3;
            Dictionary<string, string> a = ClashUda(first.NodeName);
            Dictionary<string, string> b = ClashUda(second.NodeName);
            string nameA = PartName(a);
            string nameB = PartName(b);

            ShowHud(string.Format("{0} ↔ {1}", first.NodeName, second.NodeName));

            // 두 부재의 속성(모델에 들어 있는 값)을 노트 한 장으로 — 어느 공종이 언제 설치했는지까지.
            string text = string.Format("{0}  {1} {2}\n{3}  {4} {5}\n{6} 설치 {7} · {8}\n{9} 설치 {10} · {11}",
                first.NodeName, nameA, Value(a, ScenarioScript.UdaSection),
                second.NodeName, nameB, Value(b, ScenarioScript.UdaSection),
                DisciplineName(a), Value(a, ScenarioScript.UdaPlannedStart), Value(a, ScenarioScript.UdaStatus),
                DisciplineName(b), Value(b, ScenarioScript.UdaPlannedStart), Value(b, ScenarioScript.UdaStatus));
            Data.BoundBox3D overlap = Overlap(first.GetBoundBox(), second.GetBoundBox(), 0f);
            Batch(() =>
            {
                FocusPenetration(item, first, second, index);
                ClearNotes();
                _notes.Add(AddStyledNote(text, new Data.Vector3D(overlap.CenterX, overlap.CenterY, overlap.MaxZ + ScenarioScript.NoteLift)));
            });
        }

        // 12 관통부 확대 — 마지막으로 본 관통부를 상자 단면으로 잘라 가까이 봅니다. 교차선이 슬리브를 넣을 자리입니다.
        private void SceneSleeve()
        {
            if (_focus.Count == 0) return;

            // 두 부재 경계 상자가 겹치는 부분 + 여유
            Data.BoundBox3D box = Overlap(_focus.Last().Item2.GetBoundBox(), _focus.Last().Item3.GetBoundBox(), ScenarioScript.SleeveBoxMargin);
            ShowHud("관통부 상자 단면 — 교차선 = 슬리브 위치");

            Batch(() =>
            {
                ClearNotes();
                RemoveSection();
                if (_originalCapFill == null) _originalCapFill = vizcore3dx.Section.IsCapFillEnabled;
                vizcore3dx.Section.IsCapFillEnabled = true;
                _section = vizcore3dx.Section.AddBox(box);
            });

            FlyCamera(new Data.Vector3D(box.GetCenter()), ScenarioScript.ViewSleeve, ScenarioScript.SleeveViewDistance, 2.0);
            _runner.After(2.0, () => Orbit(ScenarioScript.SleeveOrbitDegrees, ScenarioScript.SleeveOrbitSeconds));
        }

        // 03 공종별 보기 — 공종(General/Discipline) 속성으로 색을 나누고 안쪽을 덮는 외장(건축)을 숨긴 뒤, 구조도 숨겨 설비만 남깁니다.
        private void SceneDiscipline()
        {
            _sequencePlaying = false;
            ClearHud();

            List<List<Data.Node>> groups = ScenarioScript.Disciplines.Select(d => GeneralParts(ScenarioScript.UdaDiscipline, d.Item1)).ToList();
            ShowHud("공종별 색 — " + string.Join(" · ", ScenarioScript.Disciplines.Where(d => d.Item4 > 0).Select(d => d.Item2)) + " (외장 숨김)");

            _basicsColored = groups.SelectMany(g => g).ToList();
            _basicsHidden = groups.Where((g, i) => ScenarioScript.Disciplines[i].Item4 == 0).SelectMany(g => g).ToList();
            Batch(() =>
            {
                // 4D 를 비활성으로 돌려 모든 부재가 원래대로 보이게 한 뒤 칠합니다(애니메이션이 살아 있으면 숨김이 덮어써질 수 있음).
                if (_sequence != null && _sequence.IsActive) _sequence.Deactivate();
                vizcore3dx.Object3D.Show(Data.Object3DKind.ALL, true);
                for (int i = 0; i < groups.Count; i++)
                    vizcore3dx.Object3D.Color.SetColor(groups[i], ScenarioScript.Disciplines[i].Item3);
                vizcore3dx.Object3D.Show(_basicsHidden, false);
            });
            FlyToBox(ModelBox(), ScenarioScript.ViewAerial, 1.5, ScenarioScript.BuildingZoom);
            _runner.After(1.5, () => Orbit(ScenarioScript.DisciplineOrbitDegrees, ScenarioScript.DisciplineIsolateAt - 1.5));

            // 잠시 뒤 구조도 숨겨 설비(기계·소방·전기)만 남기고 다가갑니다.
            _runner.After(ScenarioScript.DisciplineIsolateAt, () =>
            {
                List<Data.Node> more = groups.Where((g, i) => ScenarioScript.Disciplines[i].Item4 == 1).SelectMany(g => g).ToList();
                _basicsHidden.AddRange(more);
                Batch(() => vizcore3dx.Object3D.Show(more, false));
                List<Data.Node> mep = groups.Where((g, i) => ScenarioScript.Disciplines[i].Item4 == 2).SelectMany(g => g).ToList();
                ShowHud(string.Format("설비만 · 기계 · 소방 · 전기 {0:#,0} 부재", mep.Count));
                if (mep.Count > 0) FlyToBox(vizcore3dx.Object3D.GetBoundBox(mep), ScenarioScript.ViewAerial, 2.0, ScenarioScript.MepZoom);
            });
        }

        // 04 층 단면 — 수평 단면이 옥상에서 아래층으로 내려가며 층마다 속을 보여 줍니다(잘린 면 채움).
        private void SceneSectionSweep()
        {
            ClearHud();
            Data.BoundBox3D model = ModelBox();
            float top = model.MaxZ + 500f;
            float bottom = LevelElevation(ScenarioScript.SweepStopLevel) + ScenarioScript.SweepCutAbove;
            ShowHud("층 단면 — 옥상부터");

            Batch(() =>
            {
                EndBasics();
                RemoveSection();
                if (_originalCapFill == null) _originalCapFill = vizcore3dx.Section.IsCapFillEnabled;
                vizcore3dx.Section.IsCapFillEnabled = true;
                _section = vizcore3dx.Section.Add(false, Data.Axis.Z);
                if (_section == null) return;

                // 뒤집기는 이 순서여야 적용됩니다(아래쪽을 남김) : Add → SetSectionPosition → Enable → Deselect → Select → InvertDirection → Deselect
                vizcore3dx.Section.SetSectionPosition(_section.ID, new Data.Vector3D(model.CenterX, model.CenterY, top));
                vizcore3dx.Section.Enable(true);
                vizcore3dx.Section.Deselect();
                vizcore3dx.Section.Select(_section);
                vizcore3dx.Section.InvertDirection();
                vizcore3dx.Section.Deselect();
                _section.Show(false);
            });
            if (_section == null) return;

            FlyToBox(model, ScenarioScript.ViewPlan, 1.5, ScenarioScript.SweepZoom);

            // 단면과 함께 카메라도 멈출 층 높이까지 내려갑니다(한 번의 긴 이동).
            float planSize = Math.Max(model.LengthX, model.LengthY);
            _runner.After(ScenarioScript.ReadPause, () =>
                FlyCamera(new Data.Vector3D(model.CenterX, model.CenterY, bottom), ScenarioScript.ViewPlan, FitDistance(planSize) * ScenarioScript.SweepZoom, ScenarioScript.SweepSeconds));

            // 단면 높이를 시간에 맞춰 내립니다. 지나가는 층 이름을 문구에 띄웁니다.
            Stopwatch watch = Stopwatch.StartNew();
            double seconds = ScenarioScript.SweepSeconds;
            _sweepTimer.Stop();
            _sweepTimer.Interval = 30;
            _sweepTick = (s, e) =>
            {
                if (_section == null) { _sweepTimer.Stop(); return; }
                double t = Math.Min(1.0, Math.Max(0.0, (watch.Elapsed.TotalSeconds - ScenarioScript.ReadPause) / seconds));
                float z = (float)(top + (bottom - top) * t);
                vizcore3dx.Section.SetSectionPosition(_section.ID, new Data.Vector3D(model.CenterX, model.CenterY, z));
                string level = LevelAt(z);
                if (level != _sweepLevel) { _sweepLevel = level; ShowHud(string.Format("층 단면 — {0}", level)); }
                if (t >= 1.0) _sweepTimer.Stop();
            };
            _sweepTimer.Tick -= SweepTimer_Tick;
            _sweepTimer.Tick += SweepTimer_Tick;
            _sweepLevel = null;
            _sweepTimer.Start();
        }

        // 단면 타이머 한 틱 — 층 단면 장면이 정한 단면 이동을 실행합니다.
        private void SweepTimer_Tick(object sender, EventArgs e)
        {
            if (_sweepTick != null) _sweepTick(sender, e);
        }

        // 공종 색·숨김을 되돌리고 단면 이동을 멈춥니다.
        private void EndBasics()
        {
            _sweepTimer.Stop();
            if (_basicsColored != null) vizcore3dx.Object3D.Color.RestoreColor(_basicsColored);
            _basicsColored = null;
            if (_basicsHidden != null) vizcore3dx.Object3D.Show(_basicsHidden, true);
            _basicsHidden = null;
        }

        // 속성 General/key 가 value 인 부품
        private List<Data.Node> GeneralParts(string key, string value)
        {
            return vizcore3dx.Object3D.UDA.GetCategoryNameValueNodes(ScenarioScript.UdaCategory, key, value)
                .Where(n => _partIndex.Contains(n.Index)).ToList();
        }

        // 층 노드의 바닥 높이(속성 Elevation(mm)). 없으면 경계 상자 아래.
        private float LevelElevation(string level)
        {
            Data.Node node = ByName(level);
            if (node == null) return 0f;
            float value;
            return float.TryParse(Value(node.GetUDA(), ScenarioScript.UdaElevation), out value) ? value : node.GetBoundBox().MinZ;
        }

        // 높이 z 가 들어 있는 층 이름 (가장 높은 "바닥 ≤ z" 층)
        private string LevelAt(float z)
        {
            if (_levelElevations == null)
                _levelElevations = ScenarioScript.Levels.Select(l => Tuple.Create(l, LevelElevation(l))).OrderBy(t => t.Item2).ToList();
            Tuple<string, float> hit = _levelElevations.LastOrDefault(t => t.Item2 <= z);
            return hit == null ? _levelElevations.First().Item1 : hit.Item1;
        }

        // 05 실내 1인칭 — 층 안으로 들어가 사람 눈높이에서 봅니다. 아바타(작업자)를 소환해 뒤에서 따라가며 걷다가 1인칭으로 넘어갑니다.
        // 아바타 모드(키 조작)에는 들어가지 않고, 카메라만 아바타를 따라가게(Follow) 한 채 MoveTo 로 걷게 합니다.
        private void SceneWalk()
        {
            ClearHud();
            Batch(() =>
            {
                EndBasics();
                RemoveSection();
            });

            string preset = AvatarPreset();
            Data.Node level = ByName(ScenarioScript.WalkLevel);
            if (preset == null || level == null) { ShowHud("아바타를 소환할 수 없습니다"); return; }

            Data.BoundBox3D box = level.GetBoundBox();
            float floor = LevelElevation(ScenarioScript.WalkLevel);
            Data.Vector3D start = new Data.Vector3D(box.MinX + box.LengthX * ScenarioScript.WalkStartRatioX, box.MinY + box.LengthY * ScenarioScript.WalkStartRatioY, floor);
            Data.Vector3D end = new Data.Vector3D(start.X + ScenarioScript.WalkDistance, start.Y, floor);
            ShowHud(string.Format("{0} 실내 — 작업자 시점", ScenarioScript.WalkLevel));

            // 소환(처음 한 번은 모델을 읽느라 잠깐 걸림) → 뒤에서 따라가며 걷기 → 1인칭
            _runner.After(0.3, () =>
            {
                _avatarID = vizcore3dx.Avatar.Place(preset, start, ScenarioScript.WalkHeading);
                if (_avatarID == 0) { ShowHud("아바타를 소환할 수 없습니다"); return; }

                vizcore3dx.Avatar.Follow(_avatarID, Data.AvatarViewpoint.ThirdPerson);
                vizcore3dx.Avatar.MoveTo(_avatarID, end, ScenarioScript.WalkHeading, (int)(ScenarioScript.WalkSeconds * 1000));
                _runner.After(ScenarioScript.WalkFirstPersonAt, () =>
                {
                    if (_avatarID == 0) return;
                    vizcore3dx.Avatar.Follow(_avatarID, Data.AvatarViewpoint.FirstPerson);
                    ShowHud("1인칭 — 천장 속 배관 · 덕트 · 스프링클러");
                });
            });
        }

        // 기본 작업자 프리셋 이름. 프리셋이 하나도 없으면 내장 모델을 꺼내 만듭니다.
        private string AvatarPreset()
        {
            List<Data.AvatarPresetItem> presets = vizcore3dx.Avatar.Presets;
            if (presets == null || presets.Count == 0)
            {
                vizcore3dx.Avatar.ImportBuiltInModels();
                presets = vizcore3dx.Avatar.Presets;
            }
            if (presets == null || presets.Count == 0) return null;

            Data.AvatarPresetItem worker = presets.FirstOrDefault(p => p.Name == ScenarioScript.AvatarPresetName);
            return (worker ?? presets[0]).Name;
        }

        // 소환한 아바타를 지웁니다(따라가기는 함께 풀림).
        private void EndWalk()
        {
            if (_avatarID != 0) vizcore3dx.Avatar.Remove(new List<int> { _avatarID });
            _avatarID = 0;
        }

        // 06 기준일 공정 현황 — 4D 가 끝난 건물에 기준일 실적을 칠합니다. 완료 = 초록 · 진행 = 주황 · 미착수 = X-Ray 로 비침.
        // 상태는 속성(Schedule/Status) 검색으로 받습니다(작업 패키지 아래 모든 노드에 같은 값이 있어 부품만 셉니다).
        private void SceneProgress()
        {
            _sequencePlaying = false;
            ClearHud();

            Dictionary<string, string> building = ByName(ScenarioScript.NameBuilding) == null ? new Dictionary<string, string>() : ByName(ScenarioScript.NameBuilding).GetUDA();
            string dataDate = Value(building, ScenarioScript.UdaDataDate);
            List<Data.Node> done = StatusParts(ScenarioScript.StatusCompleted);
            List<Data.Node> doing = StatusParts(ScenarioScript.StatusInProgress);
            List<Data.Node> todo = StatusParts(ScenarioScript.StatusNotStarted);
            ShowHud(string.Format("기준일 {0} · 완료 {1:#,0} · 진행 {2:#,0} · 미착수 {3:#,0}", dataDate, done.Count, doing.Count, todo.Count));

            _statusColored = done.Concat(doing).ToList();
            Batch(() =>
            {
                EndWalk();
                EndBasics();
                RemoveSection();
                vizcore3dx.Object3D.Color.SetColor(done, ScenarioScript.ColorDone);
                vizcore3dx.Object3D.Color.SetColor(doing, ScenarioScript.ColorDoing);
                vizcore3dx.View.XRay.Clear();
                vizcore3dx.View.XRay.Enable = true;
                if (_originalXRayColor == null) _originalXRayColor = vizcore3dx.View.XRay.ColorType;
                vizcore3dx.View.XRay.ColorType = Data.XRayColorTypes.OBJECT_COLOR;
                vizcore3dx.View.XRay.Select(_statusColored, true);
            });

            FlyToBox(ModelBox(), ScenarioScript.ViewAerial, 1.5, ScenarioScript.BuildingZoom);

            // 잠시 뒤 지금 짓고 있는 층으로 다가갑니다.
            if (doing.Count == 0) return;
            string levels = string.Join("·", doing.Select(n => n.NodeName.Split('-')[0]).Distinct().OrderBy(s => s));
            _runner.After(ScenarioScript.ProgressFocusAt, () =>
            {
                ShowHud(string.Format("진행 중 {0:#,0} · {1} 층 작업", doing.Count, levels));
                FlyToBox(vizcore3dx.Object3D.GetBoundBox(doing), ScenarioScript.ViewAerial, 2.0, ScenarioScript.ProgressZoom);
                _runner.After(2.0, () => Orbit(ScenarioScript.ProgressOrbitDegrees, ScenarioScript.ProgressOrbitSeconds));
            });
        }

        // 속성 Schedule/Status 가 status 인 부품
        private List<Data.Node> StatusParts(string status)
        {
            return vizcore3dx.Object3D.UDA.GetCategoryNameValueNodes(ScenarioScript.UdaScheduleCategory, ScenarioScript.UdaStatus, status)
                .Where(n => _partIndex.Contains(n.Index)).ToList();
        }

        // 공정 현황의 색·X-Ray 를 걷습니다.
        private void EndProgress()
        {
            if (_statusColored != null) vizcore3dx.Object3D.Color.RestoreColor(_statusColored);
            _statusColored = null;
            vizcore3dx.View.XRay.Clear();
            vizcore3dx.View.XRay.Enable = false;
        }

        // 13 설계 변경 Rev B — 설계 변경(Rev B)을 같은 화면에 열어 Rev A 와 비교하고, Rev B 만으로 다시 간섭 검사합니다.
        // ① Model.Add 로 Rev B 를 더함(같은 좌표에 겹쳐 열림) ② Compare 로 바뀐 부재만 색으로(같은 부재는 거의 투명) ③ Rev A 를 숨기고 재검사.
        // Rev B 파일은 [모델 열기]로 연 파일과 같은 폴더에서 찾습니다.
        private void SceneRevB()
        {
            ClearHud();
            Batch(() =>
            {
                ClearNotes();
                vizcore3dx.Clash.ClearResultSymbol();
                RemoveSection();
                vizcore3dx.View.XRay.Clear();
                vizcore3dx.View.XRay.Enable = false;
            });

            string revB = _modelPath == null ? null : Path.Combine(Path.GetDirectoryName(_modelPath), ScenarioScript.RevBFileName);
            if (revB == null || !File.Exists(revB))
            {
                ShowHud("Rev B 파일이 없습니다 : " + ScenarioScript.RevBFileName);
                SetStatus(string.Format("{0} 를 연 모델과 같은 폴더에 두어야 합니다. 이 장면을 건너뜁니다.", ScenarioScript.RevBFileName));
                return;
            }
            ShowHud("설계 변경 Rev B 열기…");
            FlyToBox(ModelBox(), ScenarioScript.ViewAerial, 1.0, ScenarioScript.BuildingZoom);

            // 문구가 그려진 뒤 엽니다(여는 동안 화면이 멈춥니다).
            _runner.After(ScenarioScript.ReadPause, () =>
            {
                Stopwatch watch = Stopwatch.StartNew();
                if (!vizcore3dx.Model.Add(new List<string> { revB })) { ShowHud("Rev B 를 열 수 없습니다"); return; }
                double addSeconds = watch.Elapsed.TotalSeconds;
                List<Data.Node> roots = vizcore3dx.Object3D.GetRootNodes();
                _rootB = roots.Last();

                watch.Restart();
                vizcore3dx.Compare.Reset();
                Data.CompareResult result = vizcore3dx.Compare.Compare(Data.NodeCompareType.BodyNodeBoundingBox, _rootA, _rootB);
                double compareSeconds = watch.Elapsed.TotalSeconds;
                if (result == null) { ShowHud("비교 실패"); return; }

                List<Data.Node> onlyB = result.Node2ExclusiveChildren.ToList();
                _revBChanged = onlyB.Count;

                vizcore3dx.Compare.ShowResult(ScenarioScript.ColorRevA, ScenarioScript.ColorRevB, ScenarioScript.ColorRevSame);
                ShowHud(string.Format("Rev B 열기 {0:0.0}초 · 비교 {1:0.00}초 · 바뀐 부재 {2:#,0}개", addSeconds, compareSeconds, _revBChanged));

                // 건물 전체에서 바뀐 곳을 본 뒤, 바뀐 설비가 몰린 위쪽 층으로 다가가 돕니다.
                Data.BoundBox3D model = ModelBox();
                List<Data.Node> upper = onlyB.Where(n => n.GetBoundBox().CenterZ > model.CenterZ).ToList();
                _runner.After(ScenarioScript.RevBUpperAt, () =>
                {
                    ShowHud(ScenarioScript.RevBChangeNote);
                    if (upper.Count > 0) FlyToBox(vizcore3dx.Object3D.GetBoundBox(upper), ScenarioScript.ViewAerial, 2.0, ScenarioScript.RevBUpperZoom);
                    _runner.After(2.0,() => Orbit(ScenarioScript.RevBOrbitDegrees, ScenarioScript.RevBCompareHold - ScenarioScript.RevBUpperAt - 2.5));
                });

                // 비교 결과를 보인 뒤, Rev A 를 숨기고 Rev B 만으로 다시 검사합니다.
                _runner.After(ScenarioScript.RevBCompareHold, () =>
                {
                    Batch(() =>
                    {
                        vizcore3dx.Compare.Reset();
                        vizcore3dx.Object3D.Show(new List<Data.Node> { _rootA }, false);
                    });
                    List<Data.Node> parts = vizcore3dx.Object3D.FromFilter(Data.Object3dFilter.VISIBLE_PART);
                    _clashTestB = vizcore3dx.Clash.CreateSelectionTest(Data.ClashTest.ClashTestKind.SELECTED_MODEL, parts, false, 0f, 0f, 0f);
                    if (_clashTestB == null) { ShowHud("간섭 검사를 만들 수 없습니다"); return; }

                    ShowHud(string.Format("Rev B {0:#,0} 부품 재검사 중…", parts.Count));
                    FlyToBox(ModelBox(), ScenarioScript.ViewAerial, 1.5, ScenarioScript.BuildingZoom);
                    _clashWatch.Restart();
                    vizcore3dx.Clash.PerformInterferenceCheck(_clashTestB.ID);
                });
            });
        }

        // Rev B 재검사가 끝나면 줄어든 건수를 띄우고, 남은 간섭의 기호와 부재만 또렷하게 남깁니다.
        private void OnRevBChecked()
        {
            _revBChecked = true;
            double seconds = _clashWatch.Elapsed.TotalSeconds;
            List<Data.ClashTestResultItem> items = vizcore3dx.Clash.GetResultItem(_clashTestB, Manager.ClashManager.ResultGroupingOptions.PART) ?? new List<Data.ClashTestResultItem>();
            // 화면 고정 노트 글꼴에는 ✓·✗ 기호가 없어 네모로 나옵니다 — 말로 씁니다.
            ShowHud(items.Count == 0
                ? string.Format("Rev B 재검사 {0:0.0}초 · 간섭 {1}건 → 0건 — 통과", seconds, _clashes.Count)
                : string.Format("Rev B 재검사 {0:0.0}초 · 간섭 {1}건 → {2}건 남음", seconds, _clashes.Count, items.Count));
            if (items.Count == 0) return;

            List<Data.Node> nodes = items.SelectMany(i => new[] { i.NodeA, i.NodeB }).Where(n => n != null).ToList();
            Batch(() =>
            {
                vizcore3dx.View.XRay.Clear();
                vizcore3dx.View.XRay.Enable = true;
                if (_originalXRayColor == null) _originalXRayColor = vizcore3dx.View.XRay.ColorType;
                vizcore3dx.View.XRay.ColorType = Data.XRayColorTypes.OBJECT_COLOR;
                vizcore3dx.View.XRay.Select(nodes, true);
                vizcore3dx.Clash.ShowResultSymbol(_clashTestB.ID, true, false);
            });
            FlyToBox(ModelBox(), ScenarioScript.ViewSide, 2.0, ScenarioScript.RevBRemainZoom);
        }

        // 14 마무리 — 결과 표시·단면·X-Ray 를 걷고, 건물 전체로 물러나며 돕니다.
        private void SceneOutro()
        {
            ClearHud();
            Batch(() =>
            {
                ClearNotes();
                vizcore3dx.Clash.ClearResultSymbol();
                RemoveSection();
                vizcore3dx.View.XRay.Clear();
                vizcore3dx.View.XRay.Enable = false;
            });

            FlyToBox(ModelBox(), ScenarioScript.ViewAerial, 2.0, ScenarioScript.BuildingZoom);
            _runner.After(2.0, () => Orbit(ScenarioScript.OutroOrbitDegrees, ScenarioScript.OutroOrbitSeconds));
        }

        #endregion

        #region 장면 도우미

        // 건물·기초와 4D 단계가 열린 모델에 있는지 확인합니다.
        private bool IsModelReady()
        {
            if (_foundation != null && _stages.Count > 0 && _sequence != null) return true;

            SetStatus(string.Format("'{0}' 노드나 속성 {1}={2} 인 작업 패키지(설치 순서·착수일 포함)를 찾지 못했습니다. 샘플 모델 건축\\Building_RevA.vizx 를 열거나 ScenarioScript.cs 의 이름·속성 키를 바꿔 주세요.",
                ScenarioScript.NameFoundation, ScenarioScript.UdaType, ScenarioScript.TypeWorkPackage));
            return false;
        }

        // 기초만 보이는 상태 — 모델은 전부 보이게 두고, 4D 를 0초로 돌려 작업 패키지를 숨깁니다(기초는 4D 에 없어 그대로 보임).
        // Object3D.Show(ALL, false) 로 먼저 숨기면 4D 재생이 끝나도 위층 작업이 보이지 않습니다 — 숨김은 4D 에만 맡깁니다.
        private void ShowFoundationOnly()
        {
            if (_foundation == null || _sequence == null) return;

            vizcore3dx.Object3D.Show(Data.Object3DKind.ALL, true);
            if (!_sequence.IsActive) _sequence.Activate();
            _sequence.PlaybackTime = TimeSpan.Zero;
        }

        // 여러 상태(단면·숨김·X-Ray·노트 등)를 한꺼번에 바꿀 때 — 중간 과정이 화면에 그려지지 않게 렌더링을 묶습니다.
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

        private Data.BoundBox3D ModelBox()
        {
            return vizcore3dx.Object3D.GetBoundBox(vizcore3dx.Object3D.GetRootNodes());
        }

        // X-Ray 로 두 부재만 또렷하게 남기고, 교차선을 그리며 결과 위치로 갑니다. 정보 창은 띄우지 않습니다.
        private void FocusPenetration(Data.ClashTestResultItem item, Data.Node first, Data.Node second, int index)
        {
            vizcore3dx.Clash.ClearResultSymbol();
            vizcore3dx.View.XRay.Clear();
            vizcore3dx.View.XRay.Enable = true;

            // 강조는 선택색(빨강) 대신 부재 본래 색으로 — 두 부재가 화면을 빨갛게 덮지 않게 합니다.
            if (_originalXRayColor == null) _originalXRayColor = vizcore3dx.View.XRay.ColorType;
            vizcore3dx.View.XRay.ColorType = Data.XRayColorTypes.OBJECT_COLOR;
            vizcore3dx.View.XRay.Select(new List<Data.Node> { first, second }, true);

            vizcore3dx.Clash.IntersectionLineStrokeThickness = ScenarioScript.IntersectionLineThickness;
            vizcore3dx.Clash.FocusResult(_clashTest.ID, item, true, false, true);

            // FocusResult 의 카메라는 너무 가까워(부재가 화면을 채움) 관통부가 보이는 거리로 다시 잡습니다.
            Data.BoundBox3D overlap = Overlap(first.GetBoundBox(), second.GetBoundBox(), 0f);
            Data.Vector3D center = new Data.Vector3D(overlap.CenterX, overlap.CenterY, overlap.CenterZ);
            // 장면마다 시선을 조금씩 돌려 같은 구도가 반복되지 않게 합니다.
            float angle = ScenarioScript.PenetrationAngles[index % ScenarioScript.PenetrationAngles.Length];
            Data.Vector3D direction = RotateZ(ScenarioScript.ViewPenetration, angle);
            _runner.After(0.1, () => FlyCamera(center, direction, ScenarioScript.FocusViewDistances[index % ScenarioScript.FocusViewDistances.Length], 1.2));
        }

        private void RemoveSection()
        {
            if (_section != null) vizcore3dx.Section.Clear();
            _section = null;

            if (_originalCapFill != null) vizcore3dx.Section.IsCapFillEnabled = _originalCapFill.Value;
            _originalCapFill = null;
        }

        // 결과 부재의 속성 — 이름으로 한 번만 읽어 둡니다(집계 · 노트가 같은 값을 여러 번 씁니다).
        private Dictionary<string, string> ClashUda(string name)
        {
            Dictionary<string, string> uda;
            if (_clashUda.TryGetValue(name ?? "", out uda)) return uda;

            Data.Node node = ByName(name);
            uda = node == null ? new Dictionary<string, string>() : node.GetUDA();
            _clashUda[name ?? ""] = uda;
            return uda;
        }

        // 결과의 두 부재를 (Type 이 types[0] 인 부재, types[1] 인 부재) 순서로 돌려줍니다. 맞지 않으면 null.
        private Tuple<Data.ClashTestResultItem, Data.Node, Data.Node> Ordered(Data.ClashTestResultItem item, string[] types)
        {
            string typeA = Value(ClashUda(item.NodeNameA), ScenarioScript.UdaType);
            string typeB = Value(ClashUda(item.NodeNameB), ScenarioScript.UdaType);
            Data.Node a = ByName(item.NodeNameA);
            Data.Node b = ByName(item.NodeNameB);
            if (a == null || b == null) return null;
            if (typeA == types[0] && typeB == types[1]) return Tuple.Create(item, a, b);
            if (typeB == types[0] && typeA == types[1]) return Tuple.Create(item, b, a);
            return null;
        }

        // 공종 이름 (속성 Discipline → 화면 이름)
        private static string DisciplineName(Dictionary<string, string> uda)
        {
            string value = Value(uda, ScenarioScript.UdaDiscipline);
            string name;
            return ScenarioScript.DisciplineNames.TryGetValue(value, out name) ? name : value;
        }

        // 부재 이름 (속성 Type → 화면 이름, 배관은 계통 System 으로 더 자세히)
        private static string PartName(Dictionary<string, string> uda)
        {
            string type = Value(uda, ScenarioScript.UdaType);
            string name;
            if (type == ScenarioScript.TypePipe && ScenarioScript.PipeNames.TryGetValue(Value(uda, ScenarioScript.UdaSystem), out name)) return name;
            return ScenarioScript.TypeNames.TryGetValue(type, out name) ? name : type;
        }

        // 결과 한 건의 공종 쌍 이름 — 순서와 무관하게 같은 쌍은 같은 이름이 됩니다.
        private string PairName(Data.ClashTestResultItem item)
        {
            string a = DisciplineName(ClashUda(item.NodeNameA));
            string b = DisciplineName(ClashUda(item.NodeNameB));
            return string.CompareOrdinal(a, b) <= 0 ? a + "↔" + b : b + "↔" + a;
        }

        // 두 경계 상자가 겹치는 부분에 margin 만큼 여유를 둔 상자
        private static Data.BoundBox3D Overlap(Data.BoundBox3D a, Data.BoundBox3D b, float margin)
        {
            return new Data.BoundBox3D(
                Math.Max(a.MinX, b.MinX) - margin, Math.Max(a.MinY, b.MinY) - margin, Math.Max(a.MinZ, b.MinZ) - margin,
                Math.Min(a.MaxX, b.MaxX) + margin, Math.Min(a.MaxY, b.MaxY) + margin, Math.Min(a.MaxZ, b.MaxZ) + margin);
        }

        // 어두운 상자 · 흰 글씨 · 주황 선의 3D 노트를 붙이고 ID 를 돌려줍니다.
        private uint AddStyledNote(string text, Data.Vector3D at)
        {
            Data.NoteCustomStyle style = vizcore3dx.Note.CreateCustomStyle();
            style.BoxFillColor = ScenarioScript.ColorPanel;
            style.BoxStrokeColor = ScenarioScript.ColorAccent;
            style.TextColor = ScenarioScript.ColorText;
            style.TextSize = ScenarioScript.LabelTextSize;
            style.TextHorizontalAlignment = Data.HorizontalAlignment.Left;
            style.LineStrokeColor = ScenarioScript.ColorAccent;
            style.LineStrokeThickness = ScenarioScript.LineThickness;
            style.ArrowColor = ScenarioScript.ColorAccent;
            style.ArrowHeadSize = ScenarioScript.ArrowHeadSize;
            return vizcore3dx.Note.AddNote3D(text, at.X, at.Y, at.Z, style);
        }

        private void ClearNotes()
        {
            if (_notes.Count > 0) vizcore3dx.Note.Delete(new List<uint>(_notes));
            _notes.Clear();
        }

        #endregion

        #region 카메라

        // box 가 화면에 다 들어오도록 direction 방향에서 seconds 초 동안 이동합니다. zoom 이 1 보다 크면 그만큼 더 물러납니다.
        private void FlyToBox(Data.BoundBox3D box, Data.Vector3D direction, double seconds, float zoom = 1f)
        {
            FlyCamera(new Data.Vector3D(box.GetCenter()), direction, FitDistance(box.MaxLength) * zoom, seconds);
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

        private void SetStatus(string text)
        {
            Text = "VIZCore3DX.NET.Scenario.ConstructionReview — " + text;
        }

        // 3D 뷰 왼쪽 위에 문구 하나를 띄웁니다. 밝은 장면(X-Ray·단면)에서도 읽히도록 어두운 상자에 얹은 화면 고정 노트입니다. 이전 문구는 지웁니다.
        private void ShowHud(string text)
        {
            ClearHud();
            Data.NoteCustomStyle style = vizcore3dx.Note.CreateCustomStyle();
            style.BoxFillColor = ScenarioScript.ColorPanel;
            style.BoxStrokeColor = ScenarioScript.ColorAccent;
            style.TextColor = ScenarioScript.HudColor;
            style.TextSize = ScenarioScript.HudTextSize;
            style.TextHorizontalAlignment = Data.HorizontalAlignment.Left;

            // 화면 고정 노트는 좌표(화면 비율)가 상자 가운데이고, 화면 밖으로 나간 부분은 잘립니다 — 글자 폭을 재서 왼쪽 끝을 여백에 맞춥니다.
            Size view = RenderSize();
            Size textSize;
            using (Font font = new Font(ScenarioScript.HudFontName, ScenarioScript.HudFontPixels, FontStyle.Bold, GraphicsUnit.Pixel))
                textSize = TextRenderer.MeasureText(text, font);
            float x = (ScenarioScript.HudMarginPixels + (textSize.Width + ScenarioScript.HudPaddingPixels) * 0.5f) / view.Width;
            float y = (ScenarioScript.HudMarginPixels + ScenarioScript.HudBoxHeightPixels * 0.5f) / view.Height;
            _hudNote = vizcore3dx.Note.AddNote2D(text, x, y, style);
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

        // 시선 방향을 수직축(Z) 둘레로 degrees 도 돌립니다.
        private static Data.Vector3D RotateZ(Data.Vector3D v, float degrees)
        {
            double a = degrees * Math.PI / 180.0;
            return new Data.Vector3D((float)(v.X * Math.Cos(a) - v.Y * Math.Sin(a)), (float)(v.X * Math.Sin(a) + v.Y * Math.Cos(a)), v.Z);
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
