using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Mechanism.Monitoring
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 모델 속성 이름 (샘플 모델 Gearbox.vizx 기준)
        private const string UdaCategory = "General";
        private const string UdaType = "Type";
        private const string UdaTeeth = "Teeth";
        private const string UdaMate = "Mate";

        // 기어가 보이도록 숨기는 덮개의 노드 이름
        private const string CoverName = "Upper Cover";

        // 값 표가 움직이는 두 부품의 노드 이름 (입력축 조인트 이름은 축 노드 이름과 같습니다)
        private const string InputShaftName = "Input Shaft";
        private const string InspectionName = "Inspection Cover";

        // 값 표가 움직이는 조인트 ID. 정의 전에는 -1 입니다.
        private int _inputJointId = -1;
        private int _inspectionJointId = -1;

        // 다음에 재생할 값 표의 행
        private int _row;

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            // 값 표는 뷰어와 무관하므로 생성자에서 채웁니다.
            FillSampleTable();
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
            InitializeVIZCore3DXEvent();
        }

        private void InitializeVIZCore3DX()
        {
            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();

            SetStatus("모델을 열어 주세요.");
        }

        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.Model.OnModelClosedEvent -= Model_OnModelClosedEvent;
            vizcore3dx.Model.OnModelClosedEvent += Model_OnModelClosedEvent;

            vizcore3dx.Mechanism.OnMechanismDriveModeChangedEvent -= Mechanism_OnMechanismDriveModeChangedEvent;
            vizcore3dx.Mechanism.OnMechanismDriveModeChangedEvent += Mechanism_OnMechanismDriveModeChangedEvent;

            vizcore3dx.Mechanism.OnMechanismLimitReachedEvent -= Mechanism_OnMechanismLimitReachedEvent;
            vizcore3dx.Mechanism.OnMechanismLimitReachedEvent += Mechanism_OnMechanismLimitReachedEvent;
        }

        // 뷰어가 해제되기 전에 재생을 멈추고 이벤트 구독을 모두 끊습니다.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timerSamples.Stop();

            vizcore3dx.Model.OnModelClosedEvent -= Model_OnModelClosedEvent;
            vizcore3dx.Mechanism.OnMechanismDriveModeChangedEvent -= Mechanism_OnMechanismDriveModeChangedEvent;
            vizcore3dx.Mechanism.OnMechanismLimitReachedEvent -= Mechanism_OnMechanismLimitReachedEvent;

            base.OnFormClosing(e);
        }

        // 모델이 닫히면 조인트·연동 정의도 함께 지워지므로 재생을 멈추고 ID 를 잊습니다.
        private void Model_OnModelClosedEvent(object sender, EventArgs e)
        {
            RunOnUi(ForgetJoints);
        }

        // 구동 모드는 모델 닫기·다른 기능 실행으로도 끝나므로, 끝나면 재생을 멈춥니다.
        private void Mechanism_OnMechanismDriveModeChangedEvent(object sender, VIZCore3DX.NET.Event.EventManager.MechanismDriveModeChangedEventArgs e)
        {
            if (e.IsDriveMode) return;

            RunOnUi(() =>
            {
                timerSamples.Stop();
                SetStatus("구동 모드 종료");
            });
        }

        // 받은 값이 범위(SetLimit) 끝에 닿으면 알려 줍니다. 점검창은 0~60 으로 제한되어 있습니다.
        private void Mechanism_OnMechanismLimitReachedEvent(object sender, VIZCore3DX.NET.Event.EventManager.MechanismLimitReachedEventArgs e)
        {
            int jointId = e.JointID;
            RunOnUi(() => SetStatus("범위 끝 : " + JointName(jointId)));
        }
        #endregion

        #region 1. 모델
        // 모델을 엽니다. 샘플 모델 Gearbox.vizx 를 기준으로 만든 예제입니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            // 리포의 샘플 모델(SampleModels\Gearbox.vizx)이 빌드 때 exe 옆에 복사됩니다. 있으면 바로 열고, 없으면 파일을 고릅니다.
            string sample = System.IO.Path.Combine(Application.StartupPath, "Gearbox.vizx");
            bool opened = System.IO.File.Exists(sample) ? vizcore3dx.Model.Open(sample) : vizcore3dx.Model.OpenFileDialog();
            if (opened == false) return;

            SetStatus("모델을 열었습니다. 조인트를 정의하세요.");
        }
        #endregion

        #region 2. 정의
        // 모델 속성으로 축마다 회전 조인트와 기어 연동을, 점검창에 위로 열리는 직선 조인트를 만듭니다.
        private void btnDefine_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            // 정의는 구동 모드 밖에서만 바꿀 수 있습니다.
            vizcore3dx.Mechanism.ExitDriveMode();
            vizcore3dx.Mechanism.Clear();

            Dictionary<int, int> jointOfNode = AddShaftJoints();
            int couplings = AddGearCouplings(jointOfNode);

            _inputJointId = FindJointId(InputShaftName);
            _inspectionJointId = AddInspectionJoint();

            // 기어가 보이도록 위 덮개를 숨깁니다.
            ShowCover(false);

            if (_inputJointId < 0 || _inspectionJointId < 0)
            {
                SetStatus("입력축 또는 점검창 조인트를 만들지 못했습니다 : " + vizcore3dx.Mechanism.LastOperationResult);
                return;
            }

            SetStatus(string.Format("정의 완료 : 조인트 {0}, 기어 연동 {1}", vizcore3dx.Mechanism.GetJointIDs().Count, couplings));
        }

        // 축(Type = Shaft)마다 회전 조인트를 하나 만듭니다. 같은 조립품의 기어·키가 축과 함께 돕니다.
        private Dictionary<int, int> AddShaftJoints()
        {
            Dictionary<int, int> jointOfNode = new Dictionary<int, int>();

            List<VIZCore3DX.NET.Data.Node> carried = NodesOfType("Gear");
            carried.AddRange(NodesOfType("Key"));

            foreach (VIZCore3DX.NET.Data.Node shaft in NodesOfType("Shaft"))
            {
                List<VIZCore3DX.NET.Data.Node> nodes = new List<VIZCore3DX.NET.Data.Node> { shaft };
                foreach (VIZCore3DX.NET.Data.Node node in carried)
                    if (node.ParentIndex == shaft.ParentIndex) nodes.Add(node);

                // 회전축 : 축 부품의 중심을 지나는 +Y 방향 (이 감속기의 축은 모두 Y 방향입니다)
                VIZCore3DX.NET.Data.Vector3D origin = VIZCore3DX.NET.Data.Vector3D.FromVertex3D(shaft.GetCenter());
                VIZCore3DX.NET.Data.Vector3D direction = new VIZCore3DX.NET.Data.Vector3D(0.0f, 1.0f, 0.0f);

                int jointId = vizcore3dx.Mechanism.AddRevoluteJoint(nodes, origin, direction, shaft.NodeName);
                if (jointId < 0) continue;

                foreach (VIZCore3DX.NET.Data.Node node in nodes) jointOfNode[node.Index] = jointId;
            }

            return jointOfNode;
        }

        // 기어의 Mate(맞물린 상대 기어 이름)와 Teeth(잇수)로 두 축 사이에 기어 연동을 겁니다.
        private int AddGearCouplings(Dictionary<int, int> jointOfNode)
        {
            int count = 0;
            List<VIZCore3DX.NET.Data.Node> gears = NodesOfType("Gear");

            foreach (VIZCore3DX.NET.Data.Node gear in gears)
            {
                string mateName = Uda(gear, UdaMate);
                VIZCore3DX.NET.Data.Node mate = gears.Find(g => g.NodeName == mateName);

                int driver, follower;
                if (mate == null || !jointOfNode.TryGetValue(gear.Index, out driver) || !jointOfNode.TryGetValue(mate.Index, out follower)) continue;

                // 맞물림은 양쪽 기어에 모두 적혀 있으므로 한 번만 겁니다.
                if (IsCoupled(driver, follower)) continue;

                // 한 조인트는 하나만 따라갈 수 있습니다. 거절되면 방향을 바꿔 겁니다(어느 쪽을 돌려도 결과는 같습니다).
                if (vizcore3dx.Mechanism.AddGearCoupling(driver, follower, Teeth(gear), Teeth(mate)) > 0
                    || vizcore3dx.Mechanism.AddGearCoupling(follower, driver, Teeth(mate), Teeth(gear)) > 0)
                    count++;
            }

            return count;
        }

        // 점검창(Inspection Cover)을 위(+Z)로 0~60 만큼 열리는 직선 조인트로 만듭니다. 값은 이동 거리(모델 단위)입니다.
        private int AddInspectionJoint()
        {
            VIZCore3DX.NET.Data.Node cover = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.ALL).Find(n => n.NodeName == InspectionName);
            if (cover == null) return -1;

            VIZCore3DX.NET.Data.Vector3D origin = VIZCore3DX.NET.Data.Vector3D.FromVertex3D(cover.GetCenter());
            VIZCore3DX.NET.Data.Vector3D direction = new VIZCore3DX.NET.Data.Vector3D(0.0f, 0.0f, 1.0f);

            int jointId = vizcore3dx.Mechanism.AddPrismaticJoint(new List<VIZCore3DX.NET.Data.Node> { cover }, origin, direction, InspectionName);
            if (jointId >= 0) vizcore3dx.Mechanism.SetLimit(jointId, 0.0, 60.0);

            return jointId;
        }
        #endregion

        #region 3. 관제
        // 값 표를 주기마다 한 행씩 조인트 값으로 넣기 시작합니다. 기본은 사용자 끌기를 막아 표 값대로만 움직입니다.
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            if (_inputJointId < 0 || _inspectionJointId < 0)
            {
                SetStatus("먼저 2. 정의를 실행하세요");
                return;
            }

            vizcore3dx.Mechanism.IsDragEnabled = chkAllowDrag.Checked;
            vizcore3dx.Mechanism.IsGuideVisible = chkGuide.Checked;

            if (!vizcore3dx.Mechanism.EnterDriveMode())
            {
                SetStatus("구동 모드에 들어가지 못했습니다 : " + vizcore3dx.Mechanism.LastOperationResult);
                return;
            }

            _row = 0;
            timerSamples.Interval = (int)numInterval.Value;
            timerSamples.Start();
            SetStatus("관제를 시작했습니다.");
        }

        // 재생만 멈춥니다. 구동 모드는 유지되므로 부품은 마지막 값의 자세에 그대로 남습니다.
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            timerSamples.Stop();
            SetStatus("관제를 멈췄습니다.");
        }

        // 재생 주기를 바꿉니다. 재생 중에도 바로 반영됩니다.
        private void numInterval_ValueChanged(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            timerSamples.Interval = (int)numInterval.Value;
        }

        // 관제 중에도 사용자가 부품을 잡아 끌 수 있게 할지 정합니다. 끄면 Esc 로도 구동 모드에서 나오지 않습니다.
        private void chkAllowDrag_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            vizcore3dx.Mechanism.IsDragEnabled = chkAllowDrag.Checked;
        }

        // 조인트 축선과 가동 범위 표시를 켜고 끕니다.
        private void chkGuide_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            vizcore3dx.Mechanism.IsGuideVisible = chkGuide.Checked;
        }

        // 값 표에서 한 행을 읽어 조인트 값으로 넣습니다. 실제 설비 값이 오면 이 표 대신 받은 값을 넣습니다.
        private void timerSamples_Tick(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            if (!vizcore3dx.Mechanism.IsDriveMode)
            {
                timerSamples.Stop();
                return;
            }

            DataGridViewRow row = NextSampleRow();
            if (row == null) return;

            double input, inspection;
            if (TryReadSample(row, out input, out inspection) && ApplySample(input, inspection))
            {
                dgvSamples.CurrentCell = row.Cells[0];
                SetStatus(string.Format("시각 {0}s : 입력축 {1:F0}°, 점검창 {2:F0}mm", row.Cells[colTime.Index].Value,
                    vizcore3dx.Mechanism.GetValue(_inputJointId), vizcore3dx.Mechanism.GetValue(_inspectionJointId)));
            }

            _row++;
        }

        // 실제 설비 값은 대개 다른 스레드의 콜백으로 들어옵니다. 그때는 RunOnUi(BeginInvoke)로 값을 화면(UI) 스레드에 넘겨
        // 이 메서드를 부릅니다. Mechanism 호출은 모두 UI 스레드에서 해야 합니다.
        // 두 조인트 값을 한 번에 넣어 화면 갱신과 값 변경 이벤트가 한 번만 일어나게 합니다.
        private bool ApplySample(double inputDeg, double inspectionMm)
        {
            Dictionary<int, double> values = new Dictionary<int, double>();
            values[_inputJointId] = inputDeg;
            values[_inspectionJointId] = inspectionMm;

            if (vizcore3dx.Mechanism.SetValues(values)) return true;

            timerSamples.Stop();
            SetStatus("값 지정 실패 : " + vizcore3dx.Mechanism.LastOperationResult);
            return false;
        }
        #endregion

        #region 4. 값 표
        // 예제용 값 표를 채웁니다. 0.2초 간격 40행 — 입력축은 계속 돌고, 점검창은 중간에 열렸다 닫힙니다.
        private void FillSampleTable()
        {
            for (int i = 0; i < 40; i++)
                dgvSamples.Rows.Add((i * 0.2).ToString("0.0"), i * 30, InspectionAt(i));
        }

        // 행 번호에 따른 점검창 열림(mm) : 0 → 15씩 올라 60 → 유지 → 15씩 내려 0
        private static double InspectionAt(int i)
        {
            if (i < 15) return 0.0;
            if (i <= 18) return (i - 14) * 15.0;
            if (i <= 28) return 60.0;
            if (i <= 32) return (32 - i) * 15.0;
            return 0.0;
        }

        // 재생할 행을 돌려줍니다. 표 끝이면 처음으로 돌아가거나 재생을 멈춥니다. 새 행 입력 줄은 건너뜁니다.
        private DataGridViewRow NextSampleRow()
        {
            if (_row < dgvSamples.Rows.Count && !dgvSamples.Rows[_row].IsNewRow) return dgvSamples.Rows[_row];

            if (!chkLoop.Checked)
            {
                timerSamples.Stop();
                SetStatus("값 표 끝");
                return null;
            }

            _row = 0;
            if (dgvSamples.Rows.Count == 0 || dgvSamples.Rows[0].IsNewRow) return null;
            return dgvSamples.Rows[0];
        }

        // 행의 두 값 칸을 읽습니다. 숫자가 아니면 false 를 돌려주고 그 행은 건너뜁니다.
        private bool TryReadSample(DataGridViewRow row, out double input, out double inspection)
        {
            inspection = 0.0;
            return double.TryParse(Convert.ToString(row.Cells[colInput.Index].Value), out input)
                && double.TryParse(Convert.ToString(row.Cells[colInspection.Index].Value), out inspection);
        }
        #endregion

        #region 5. 정리
        // 관제를 끝내고(구동 모드를 나와 처음 자세로 복원) 조인트·연동 정의를 모두 지웁니다.
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            timerSamples.Stop();
            vizcore3dx.Mechanism.ExitDriveMode();
            vizcore3dx.Mechanism.Clear();
            ShowCover(true);

            ForgetJoints();
            SetStatus("정의를 지웠습니다.");
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

        // 재생을 멈추고 조인트 ID 를 잊습니다.
        private void ForgetJoints()
        {
            timerSamples.Stop();
            _inputJointId = -1;
            _inspectionJointId = -1;
        }

        // 이름이 같은 조인트의 ID. 없으면 -1.
        private int FindJointId(string name)
        {
            foreach (int jointId in vizcore3dx.Mechanism.GetJointIDs())
                if (vizcore3dx.Mechanism.GetJoint(jointId).Name == name) return jointId;

            return -1;
        }

        private string JointName(int jointId)
        {
            VIZCore3DX.NET.Data.MechanismJoint joint = vizcore3dx.Mechanism.GetJoint(jointId);
            return joint != null ? joint.Name : jointId.ToString();
        }

        // Type 속성 값이 일치하는 노드를 찾습니다.
        private List<VIZCore3DX.NET.Data.Node> NodesOfType(string type)
        {
            return vizcore3dx.Object3D.UDA.GetCategoryNameValueNodes(UdaCategory, UdaType, type, true);
        }

        // 노드 속성 값 하나를 읽습니다. 없으면 빈 문자열.
        private static string Uda(VIZCore3DX.NET.Data.Node node, string key)
        {
            string value;
            return node.GetUDA().TryGetValue(key, out value) ? value : "";
        }

        private static int Teeth(VIZCore3DX.NET.Data.Node gear)
        {
            int teeth;
            return int.TryParse(Uda(gear, UdaTeeth), out teeth) ? teeth : 0;
        }

        // 두 조인트 사이에 이미 연동이 있는지 (방향 무관)
        private bool IsCoupled(int jointA, int jointB)
        {
            foreach (int couplingId in vizcore3dx.Mechanism.GetCouplingIDs())
            {
                VIZCore3DX.NET.Data.MechanismCoupling coupling = vizcore3dx.Mechanism.GetCoupling(couplingId);
                if (coupling.DriverID == jointA && coupling.FollowerID == jointB) return true;
                if (coupling.DriverID == jointB && coupling.FollowerID == jointA) return true;
            }

            return false;
        }

        // 위 덮개를 보이거나 숨깁니다.
        private void ShowCover(bool visible)
        {
            VIZCore3DX.NET.Data.Node cover = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.ALL).Find(n => n.NodeName == CoverName);
            if (cover != null) vizcore3dx.Object3D.Show(cover, visible);
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
