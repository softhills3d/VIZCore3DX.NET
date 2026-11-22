using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Mechanism.Drive
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

        // 표의 행 순서와 같은 조인트 ID
        private readonly List<int> _rowIds = new List<int>();

        // 이벤트로 체크 상태를 맞추는 동안 CheckedChanged 가 다시 모드를 바꾸지 않게 막습니다.
        private bool _syncing;

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

            vizcore3dx.Mechanism.OnMechanismValueChangedEvent -= Mechanism_OnMechanismValueChangedEvent;
            vizcore3dx.Mechanism.OnMechanismValueChangedEvent += Mechanism_OnMechanismValueChangedEvent;

            vizcore3dx.Mechanism.OnMechanismDriveModeChangedEvent -= Mechanism_OnMechanismDriveModeChangedEvent;
            vizcore3dx.Mechanism.OnMechanismDriveModeChangedEvent += Mechanism_OnMechanismDriveModeChangedEvent;

            vizcore3dx.Mechanism.OnMechanismDragStartedEvent -= Mechanism_OnMechanismDragStartedEvent;
            vizcore3dx.Mechanism.OnMechanismDragStartedEvent += Mechanism_OnMechanismDragStartedEvent;

            vizcore3dx.Mechanism.OnMechanismDragFinishedEvent -= Mechanism_OnMechanismDragFinishedEvent;
            vizcore3dx.Mechanism.OnMechanismDragFinishedEvent += Mechanism_OnMechanismDragFinishedEvent;
        }

        // 뷰어가 해제되기 전에 이벤트 구독을 모두 끊습니다.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            vizcore3dx.Model.OnModelClosedEvent -= Model_OnModelClosedEvent;
            vizcore3dx.Mechanism.OnMechanismValueChangedEvent -= Mechanism_OnMechanismValueChangedEvent;
            vizcore3dx.Mechanism.OnMechanismDriveModeChangedEvent -= Mechanism_OnMechanismDriveModeChangedEvent;
            vizcore3dx.Mechanism.OnMechanismDragStartedEvent -= Mechanism_OnMechanismDragStartedEvent;
            vizcore3dx.Mechanism.OnMechanismDragFinishedEvent -= Mechanism_OnMechanismDragFinishedEvent;

            base.OnFormClosing(e);
        }

        // 모델이 닫히면 조인트·연동 정의도 함께 지워지므로 표를 비웁니다.
        private void Model_OnModelClosedEvent(object sender, EventArgs e)
        {
            RunOnUi(ClearJointTable);
        }

        // 값이 바뀐 조인트가 Values 에 담겨 옵니다. 연동으로 따라 움직인 조인트도 포함됩니다.
        private void Mechanism_OnMechanismValueChangedEvent(object sender, VIZCore3DX.NET.Event.EventManager.MechanismValueChangedEventArgs e)
        {
            RunOnUi(RefreshValues);
        }

        // 구동 모드는 Esc·리본의 "구동 모드" 항목으로도 바뀌므로 이벤트로 체크 상태를 맞춥니다.
        private void Mechanism_OnMechanismDriveModeChangedEvent(object sender, VIZCore3DX.NET.Event.EventManager.MechanismDriveModeChangedEventArgs e)
        {
            RunOnUi(SyncDriveMode);
        }

        private void Mechanism_OnMechanismDragStartedEvent(object sender, VIZCore3DX.NET.Event.EventManager.MechanismDragStartedEventArgs e)
        {
            int jointId = e.JointID;
            RunOnUi(() => SetStatus("끌기 시작 : " + JointName(jointId)));
        }

        private void Mechanism_OnMechanismDragFinishedEvent(object sender, VIZCore3DX.NET.Event.EventManager.MechanismDragFinishedEventArgs e)
        {
            string text = (e.IsCanceled ? "끌기 취소 : " : "끌기 끝 : ") + JointName(e.JointID);
            RunOnUi(() => SetStatus(text));
        }
        #endregion

        #region 1. 모델
        // 모델을 엽니다. 샘플 모델 Gearbox.vizx 를 기준으로 만든 예제입니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            SetStatus("모델을 열었습니다. 조인트를 정의하세요.");
        }
        #endregion

        #region 2. 정의
        // 모델 속성을 읽어 축마다 회전 조인트를, 맞물린 기어마다 기어 연동을 만듭니다.
        private void btnDefine_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            // 정의는 구동 모드 밖에서만 바꿀 수 있습니다.
            vizcore3dx.Mechanism.ExitDriveMode();
            vizcore3dx.Mechanism.Clear();

            Dictionary<int, int> jointOfNode = AddShaftJoints();
            int couplings = AddGearCouplings(jointOfNode);

            // 기어가 보이도록 위 덮개를 숨깁니다.
            ShowCover(false);

            RefreshJoints();
            SetStatus(string.Format("정의 완료 : 조인트 {0}, 기어 연동 {1}", _rowIds.Count, couplings));
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
        #endregion

        #region 3. 구동
        // 구동 모드를 켜면 뷰에서 부품을 마우스 왼쪽 버튼으로 잡아 돌릴 수 있습니다. 끄면 처음 자세로 돌아갑니다.
        private void chkDriveMode_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            if (IsModelOpened())
            {
                if (chkDriveMode.Checked) EnsureDriveMode();
                else vizcore3dx.Mechanism.ExitDriveMode();
            }

            SyncDriveMode();
        }

        // 표에서 고른 조인트에 값(도)을 지정합니다. 연동된 조인트가 비율대로 따라 움직입니다.
        private void btnSetValue_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;
            if (!EnsureDriveMode()) return;

            int jointId = SelectedJointId();
            if (jointId < 0) return;

            double value = (double)numValue.Value;
            if (vizcore3dx.Mechanism.SetValue(jointId, value))
                SetStatus(string.Format("값 지정 : {0} = {1:F1}°", JointName(jointId), value));
            else
                SetStatus("값 지정 실패 : " + vizcore3dx.Mechanism.LastOperationResult);
        }

        // 구동 모드를 유지한 채 모든 조인트를 처음 자세(값 0)로 되돌립니다.
        private void btnResetPose_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;
            if (!vizcore3dx.Mechanism.IsDriveMode) return;

            vizcore3dx.Mechanism.StopAutoDrive();
            vizcore3dx.Mechanism.ResetPose();
            SetStatus("처음 자세로 되돌렸습니다.");
        }

        // 표에서 고른 조인트를 4초에 한 바퀴씩 계속 돌립니다. 부품을 잡거나 Esc 를 누르면 멈춥니다.
        private void btnAutoDrive_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;
            if (!EnsureDriveMode()) return;

            int jointId = SelectedJointId();
            if (jointId < 0) return;

            if (vizcore3dx.Mechanism.StartAutoDrive(jointId, 0.0, 360.0, 4.0, VIZCore3DX.NET.Data.MechanismAutoDriveMode.Loop))
                SetStatus("자동 구동 : " + JointName(jointId));
            else
                SetStatus("자동 구동 실패 : " + vizcore3dx.Mechanism.LastOperationResult);
        }

        // 자동 구동을 멈춥니다. 조인트는 멈춘 값에 그대로 남습니다.
        private void btnStopAutoDrive_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            vizcore3dx.Mechanism.StopAutoDrive();
            SetStatus("자동 구동을 멈췄습니다.");
        }

        // 끌기 스냅(15도 단위)과 축·현재 값 표시를 켜고 끕니다. 범위(SetLimit)를 건 조인트는 가동 범위도 함께 그려집니다.
        private void chkOption_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            ApplyOptions();
        }
        #endregion

        #region 4. 결과
        // 정의된 조인트와 연동을 표에 다시 채웁니다.
        private void RefreshJoints()
        {
            ClearJointTable();

            foreach (int jointId in vizcore3dx.Mechanism.GetJointIDs())
            {
                VIZCore3DX.NET.Data.MechanismJoint joint = vizcore3dx.Mechanism.GetJoint(jointId);

                _rowIds.Add(jointId);
                dgvJoints.Rows.Add(joint.Name, joint.Nodes.Count, joint.Value.ToString("F1"), CouplingText(jointId));
            }
        }

        // 값 열만 현재 값으로 갱신합니다.
        private void RefreshValues()
        {
            if (!vizcore3dx.Model.IsOpen()) return;

            for (int i = 0; i < _rowIds.Count; i++)
                dgvJoints.Rows[i].Cells[colValue.Index].Value = vizcore3dx.Mechanism.GetValue(_rowIds[i]).ToString("F1");
        }

        // 이 조인트가 따라가는 조인트와 비율을 문구로 만듭니다. 외접 기어는 반대로 돌므로 비율이 음수입니다.
        private string CouplingText(int jointId)
        {
            foreach (int couplingId in vizcore3dx.Mechanism.GetCouplingIDs())
            {
                VIZCore3DX.NET.Data.MechanismCoupling coupling = vizcore3dx.Mechanism.GetCoupling(couplingId);
                if (coupling.FollowerID == jointId)
                    return string.Format("{0} × {1:F3}", JointName(coupling.DriverID), coupling.Ratio);
            }

            return "";
        }
        #endregion

        #region 5. 정리
        // 구동 모드를 끝내고(처음 자세로 복원) 조인트·연동 정의를 모두 지웁니다.
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            vizcore3dx.Mechanism.ExitDriveMode();
            vizcore3dx.Mechanism.Clear();
            ShowCover(true);

            RefreshJoints();
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

        // 구동 모드가 아니면 들어갑니다. 값 지정·자동 구동은 구동 모드에서만 됩니다.
        private bool EnsureDriveMode()
        {
            if (vizcore3dx.Mechanism.IsDriveMode) return true;

            ApplyOptions();
            if (vizcore3dx.Mechanism.EnterDriveMode()) return true;

            SetStatus(string.Format("구동 모드에 들어가지 못했습니다({0}). 먼저 조인트를 정의하세요.", vizcore3dx.Mechanism.LastOperationResult));
            return false;
        }

        // 체크 상자의 값을 끌기 스냅과 표시 여부에 반영합니다. 스냅은 마우스 끌기에만 적용됩니다.
        private void ApplyOptions()
        {
            vizcore3dx.Mechanism.AngleSnap = chkSnap.Checked ? 15.0 : 0.0;
            vizcore3dx.Mechanism.IsGuideVisible = chkGuide.Checked;
        }

        // 체크 상자와 값 열을 실제 구동 모드 상태에 맞춥니다.
        private void SyncDriveMode()
        {
            _syncing = true;
            chkDriveMode.Checked = vizcore3dx.Mechanism.IsDriveMode;
            _syncing = false;

            RefreshValues();
        }

        private void ClearJointTable()
        {
            dgvJoints.Rows.Clear();
            _rowIds.Clear();
        }

        // 표에서 고른 조인트의 ID. 고른 행이 없으면 첫 조인트를 씁니다.
        private int SelectedJointId()
        {
            if (_rowIds.Count == 0)
            {
                SetStatus("먼저 조인트를 정의하세요.");
                return -1;
            }

            int row = dgvJoints.CurrentRow != null ? dgvJoints.CurrentRow.Index : 0;
            return _rowIds[row];
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
