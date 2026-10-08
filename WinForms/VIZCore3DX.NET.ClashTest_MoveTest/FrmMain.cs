using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using static VIZCore3DX.NET.Data.ClashTestResultItem;
using static VIZCore3DX.NET.Manager.ClashManager;

namespace VIZCore3DX.NET.ClashTest_MoveTest
{
    public partial class FrmMain : Form
    {
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        /// <summary>
        /// Clash test
        /// </summary>
        VIZCore3DX.NET.Data.ClashTest clash { get; set; }

        /// <summary>
        /// 노드 이름 캐시
        /// </summary>
        private Dictionary<Node, string> _nodeNameCache = new Dictionary<Node, string>();

        /// <summary>
        /// Clash Test 진행 중 여부
        /// </summary>
        private bool _isClashTestMode = false;

        /// <summary>
        /// Group A, B 노드 리스트
        /// </summary>
        List<Data.Node> nodesA = new List<Data.Node>();
        List<Data.Node> nodesB = new List<Data.Node>();

        /// <summary>
        /// 테스트 ID, 이동 간섭 Path Dictionary
        /// </summary>
        public Dictionary<int, List<VIZCore3DX.NET.Data.ClashMoveTestItem>> dicPath = new Dictionary<int, List<VIZCore3DX.NET.Data.ClashMoveTestItem>>();

        /// <summary>
        /// 테스트 ID, 간섭 결과 Dictionary
        /// </summary>

        /// <summary>
        /// 그리드 뷰 순번
        /// </summary>
        private int gridCount;

        public FrmMain()
        {
            InitializeComponent();

            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;

            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            splitContainer2.Panel1.Controls.Add(vizcore3dx);
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================
            // 라이선스 파일을 통한 인증
            //vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("127.0.0.1", 8901);

            // ================================================================
            // License
            // ================================================================
            // VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");
            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeVIZCore3DX();
        }

        private void InitializeVIZCore3DX()
        {
            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 차단
            // ================================================================
            vizcore3dx.BeginUpdate();

            // ================================================================
            // 설정 - 툴바
            // ================================================================

            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();

            // 모델 열기 / 닫기 : 테스트 시나리오 버튼 활성화 갱신
            vizcore3dx.Model.OnModelOpenedEvent += Model_OnModelChanged;
            vizcore3dx.Model.OnModelClosedEvent += Model_OnModelChanged;

            // 시나리오 버튼 안내 (primitiveCrane.vizx 를 열었을 때만 활성화)
            new ToolTip().SetToolTip(btnLoadScenario, "primitiveCrane.vizx 모델(Animation 예제의 크레인 모델)을 열면 활성화됩니다.");
        }

        // ================================================================
        // 테스트 시나리오 (primitiveCrane.vizx 전용)
        // ================================================================
        private const string ScenarioModelName = "primitiveCrane.vizx";

        private void Model_OnModelChanged(object sender, EventArgs e)
        {
            if (InvokeRequired == true)
            {
                BeginInvoke(new Action(UpdateScenarioButton));
                return;
            }

            UpdateScenarioButton();
        }

        private void UpdateScenarioButton()
        {
            btnLoadScenario.Enabled = vizcore3dx.Model.IsOpen() == true && vizcore3dx.Model.Files != null
                && vizcore3dx.Model.Files.Any(x => string.Equals(Path.GetFileName(x), ScenarioModelName, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// 테스트 시나리오 선택 메뉴 표시
        /// </summary>
        private void btnLoadScenario_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            // (표시 이름, 그룹 A, 그룹 A 가 파트인지, 이동 그룹 B, 이동량) : 경로는 이동량 x 3 회
            menu.Items.Add("1. 바퀴 상승 → 차대 충돌 (Wheels +Z 300 x 3)", null, (s, args) => LoadScenario("Chassis", false, "Wheels", new Vector3D(0.0f, 0.0f, 300.0f)));
            menu.Items.Add("2. 캐빈 하강 → 차대 프레임 충돌 (Cabin -Z 800 x 3)", null, (s, args) => LoadScenario("Chassis Frame", true, "Cabin", new Vector3D(0.0f, 0.0f, -800.0f)));
            menu.Items.Add("3. 탱크 이동 → 크레인 (Tanks -Y 4000 x 3)", null, (s, args) => LoadScenario("Truck Crane", false, "Tanks", new Vector3D(0.0f, -4000.0f, 0.0f)));

            menu.Show(btnLoadScenario, 0, btnLoadScenario.Height);
        }

        /// <summary>
        /// 테스트 시나리오 불러오기 : 그룹 A / 이동 그룹 B(어셈블리) 지정, 이동 간섭 검사 추가, 이동 경로 3 개 추가
        /// </summary>
        private void LoadScenario(string groupAName, bool groupAIsPart, string groupBName, Vector3D move)
        {
            List<Node> parts = vizcore3dx.Object3D.FromFilter(Object3dFilter.PART);
            List<Node> assemblies = vizcore3dx.Object3D.FromFilter(Object3dFilter.ASSEMBLY);

            List<Node> groupA = (groupAIsPart ? parts : assemblies).Where(x => x.NodeName == groupAName).Take(1).ToList();
            List<Node> groupB = assemblies.Where(x => x.NodeName == groupBName).Take(1).ToList();

            if (groupA.Count == 0 || groupB.Count == 0)
            {
                MessageBox.Show(string.Format("시나리오 대상 노드({0} / {1})를 찾을 수 없습니다.", groupAName, groupBName), "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            nodesA = groupA;
            nodesB = groupB;

            // 이동 간섭 검사 추가
            btnAdd_Click(btnLoadScenario, EventArgs.Empty);
            if (clash == null || cbClashTestId.Items.Contains(clash.ID) == false) return;

            // 이동 경로 추가 (경로마다 이동량만큼 누적 이동)
            for (int i = 0; i < 3; i++)
                vizcore3dx.Clash.AddTestPath(clash, move, 0.0f, 0.0f, 0.0f);

            UpdateTestPathList(clash);

            // 이동 간섭 검사 바로 실행 (완료 시 결과가 있는 첫 경로가 선택되어 결과 목록에 표시)
            btnStart_Click(btnLoadScenario, EventArgs.Empty);
        }

        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore3dx.Model.OpenFilter;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Model.Open(dlg.FileName);
        }

        private void btnAddModels_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore3dx.Model.OpenFilter;
            dlg.Multiselect = true;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Model.Add(dlg.FileNames);
        }

        private void btnCloseModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Model.Close();
        }

        /// <summary>
        /// Clash Test 그룹 A 설정
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnAddGroupA_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.FromFilter(Data.Object3dFilter.SELECTED_TOP);

            if (nodes.Count == 0)
            {
                MessageBox.Show("선택된 항목이 없습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 여기서 지정한 nodesA는 간섭 검사 추가 시 GroupA에 할당됩니다.
            nodesA = nodes;

            nodesA[0].SetColor(Color.Black);

            MessageBox.Show("선택된 모델을 그룹에 설정하였습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vizcore3dx.Object3D.Select(Data.Object3dSelectionModes.DESELECT_ALL);
        }

        /// <summary>
        /// Clash Test 그룹 B 설정
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnAddGroupB_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.FromFilter(Data.Object3dFilter.SELECTED_TOP);

            if (nodes.Count == 0)
            {
                MessageBox.Show("선택된 항목이 없습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 여기서 지정한 nodesB는 간섭 검사 추가 시 GroupB에 할당됩니다.
            nodesB = nodes;

            nodesB[0].SetColor(Color.Green);

            MessageBox.Show("선택된 모델을 그룹에 설정하였습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Information);

            vizcore3dx.Object3D.Select(Data.Object3dSelectionModes.DESELECT_ALL);
        }

        /// <summary>
        /// Clash Test 추가
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 간섭 검사 추가
            clash = new VIZCore3DX.NET.Data.ClashTest();

            // 이동 간섭이므로 GROUP_VS_MOVING_GROUP으로 간섭 종류 설정
            clash.TestKind = VIZCore3DX.NET.Data.ClashTest.ClashTestKind.GROUP_VS_MOVING_GROUP;

            // GroupA와 GroupB(이동할 그룹) 설정
            clash.GroupA.AddRange(nodesA);
            clash.GroupB.AddRange(nodesB);

            // 이동 간섭 옵션들에 따라 설정
            clash.UseClearanceValue = ckUseClearanceValue.Checked;
            clash.ClearanceValue = (float)numClearanceValue.Value;
            clash.UseRangeValue = ckUseRangeValue.Checked;
            clash.RangeValue = (float)numRangeValue.Value;
            clash.PenetrationTolerance = (float)numPenetrationTolerance.Value;

            // 결과 유형이 파트인지 어셈블리인지 설정
            vizcore3dx.Clash.IsAssembly = false; // True : Assembly, False : Part

            if (clash.GroupA.Count == 0 || clash.GroupB.Count == 0)
            {
                MessageBox.Show("간섭검사 그룹이 설정되지 않았습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool result = vizcore3dx.Clash.Add(clash);

            if (result == false)
            {
                MessageBox.Show("간섭검사 추가에 실패하였습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!cbClashTestId.Items.Contains(clash.ID))
            {
                cbClashTestId.Items.Add(clash.ID);
                MessageBox.Show("간섭검사 추가에 성공하였습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cbClashTestId.SelectedIndex = cbClashTestId.Items.Count - 1;
            }
        }

        /// <summary>
        /// Clash Test 삭제
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbClashTestId.Items.Count == 0) return;
            if (cbClashTestId.SelectedItem == null) return;
            if (_isClashTestMode) return;

            // 선택한 간섭검사 삭제
            int id = Convert.ToInt32(cbClashTestId.SelectedItem);

            // 삭제 대상이 현재 표시 중인 검사이면 이동 그룹 위치와 결과 목록 초기화
            if (clash != null && clash.ID == id)
            {
                RestoreGroupBTransform();
                datagridviewInterferencePath.Rows.Clear();
                datagridviewInterferenceResult.Rows.Clear();
                lstTestPaths.Items.Clear();
            }

            foreach (var item in vizcore3dx.Clash.Items)
            {
                if (item.ID == id)
                {
                    vizcore3dx.Clash.Delete(item);
                    break;
                }
            }

            if (clash != null && clash.ID == id) clash = null;

            int bNum = Math.Max(0, cbClashTestId.SelectedIndex - 1);

            cbClashTestId.Items.Remove(cbClashTestId.SelectedItem);

            // Clash Test가 모두 삭제되었을 경우
            if (cbClashTestId.Items.Count == 0)
            {
                cbClashTestId.Text = "";

                _isClashTestMode = false;

                vizcore3dx.Clash.ClearResultSymbol();
                vizcore3dx.View.ResetView();

                List<Node> nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.ROOT);
                vizcore3dx.Object3D.Color.RestoreAll();
            }
            else
            {
                cbClashTestId.SelectedIndex = bNum;
            }
        }

        /// <summary>
        /// Clash Test 시작
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private async void btnStart_Click(object sender, EventArgs e)
        {
            // 간섭검사 결과를 그룹화하기 위한 옵션 ( 파트 or 어셈블리 )
            ResultGroupingOptions resultGroupingOptions;

            // 콤보에서 선택한 ID 의 간섭검사 수행
            if (cbClashTestId.SelectedItem != null && _isClashTestMode == false)
            {
                VIZCore3DX.NET.Data.ClashTest selected = vizcore3dx.Clash.GetClashTest(Convert.ToInt32(cbClashTestId.SelectedItem));
                if (selected != null && selected != clash)
                {
                    RestoreGroupBTransform();
                    clash = selected;
                }
            }

            if (clash == null) return;
            if (!cbClashTestId.Items.Contains(clash.ID)) return;
            if (clash.MoveTest == null) return;

            vizcore3dx.Clash.ClearResultSymbol();

            if (_isClashTestMode)
            {
                MessageBox.Show("간섭검사 진행 중에는 실행할 수 없습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isClashTestMode = true;

            _nodeNameCache.Clear();

            if (rbResultGroupingAssy.Checked) resultGroupingOptions = ResultGroupingOptions.ASSEMBLY;
            else resultGroupingOptions = ResultGroupingOptions.PART;

            // 이동 간섭 검사가 끝났을 때 실행하는 이벤트 ( 결과 보여주기 등 ) - 실행마다 중복 구독되지 않도록 먼저 해제
            vizcore3dx.Clash.OnClashMoveTestReportFinished -= Clash_OnClashMoveTestReportFinished;
            vizcore3dx.Clash.OnClashMoveTestReportFinished += Clash_OnClashMoveTestReportFinished;

            // 간섭검사 수행
            bool result = await vizcore3dx.Clash.PerformInterferenceCheck(clash.ID, resultGroupingOptions);

            if (result == false)
            {
                _isClashTestMode = false;
                MessageBox.Show("간섭검사 수행에 실패하였습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Clash Test Clear
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (_isClashTestMode) return;

            _isClashTestMode = false;

            vizcore3dx.Clash.ClearResultSymbol();
            RestoreGroupBTransform();
            vizcore3dx.Clash.Clear();
            vizcore3dx.View.ResetView();
            cbClashTestId.Items.Clear();
            clash = null;

            datagridviewInterferencePath.Rows.Clear();
            datagridviewInterferenceResult.Rows.Clear();
            lstTestPaths.Items.Clear();

            List<Node> nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.ROOT);
            vizcore3dx.Object3D.Color.RestoreAll();
        }
        
        /// <summary>
        /// 이동 간섭 최종 완료 이벤트
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void Clash_OnClashMoveTestReportFinished(object sender, VIZCore3DX.NET.Event.EventManager.ClashEventArgs e)
        {
            // 이동 간섭 검사가 완료되면 결과를 보여줍니다.
            vizcore3dx.Clash.ShowResultSymbol(clash.ID, true, true);

            _nodeNameCache.Clear();

            // 이동 간섭 검사 경로를 그리드 뷰에 넣어줍니다.
            UpdatePathGridView();

            // 결과가 있는 첫 번째 경로를 선택하여 아래 결과 목록에 표시
            foreach (DataGridViewRow row in datagridviewInterferencePath.Rows)
            {
                if (Convert.ToInt32(row.Cells[row.Cells.Count - 1].Value) == 0) continue;

                datagridviewInterferencePath.ClearSelection();
                row.Selected = true;
                break;
            }

            // 간섭검사가 끝났으므로 false로 변경
            _isClashTestMode = false;
        }

        /// <summary>
        /// Clash Test Path 그리드 뷰 갱신
        /// </summary>
        private void UpdatePathGridView()
        {
            // 이동 경로 데이터 그리드 뷰 설정
            datagridviewInterferencePath.AutoGenerateColumns = false;
            datagridviewInterferencePath.Rows.Clear();

            // 이동 경로를 문자열 배열에 추가
            for (int i = 0; i < clash.MoveTest.Count; i++) {
                string[] row = new string[] {
                    clash.MoveTest[i].TestID.ToString(),
                    clash.MoveTest[i].ID.ToString(),
                    clash.MoveTest[i].Distance.ToString(),
                    clash.MoveTest[i].Angle.ToString(),
                    clash.MoveTest[i].Matrix.ToString(),
                    clash.MoveTest[i].MoveTestResult.Count.ToString()
                };

                // 이동 경로 그리드뷰에 해당 배열 삽입
                int rowIndex = datagridviewInterferencePath.Rows.Add(row);

                // 이동 경로 순번(ID)을 가져올 수 있게 Tag에 해당 ID를 등록
                datagridviewInterferencePath.Rows[rowIndex].Tag = clash.MoveTest[i].ID;
            }
        }
        private void datagridviewInterferencePath_SelectionChanged(object sender, EventArgs e)
        {
            gridCount = 1;
            // 선택된 행이 하나라도 있는지 확인
            if (datagridviewInterferencePath.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = datagridviewInterferencePath.SelectedRows[0];

                // Tag에 저장해둔 ID 값을 가져옴 (null 체크 필요)
                if (selectedRow.Tag != null)
                {
                    var selectedID = selectedRow.Tag;

                    UpdateResultGridView(selectedID);
                }
            }
        }

        /// <summary>
        /// 선택된 경로에 알맞은 결과 그리드 뷰 갱신
        /// </summary>
        /// <param name="id">이동 경로 ID</param>
        private void UpdateResultGridView(object id)
        {
            // 결과 데이터 그리드 뷰 설정
            datagridviewInterferenceResult.Rows.Clear();
            vizcore3dx.Clash.ClearResultSymbol();

            int filterID = (int)id;

            // 선택된 경로에 맞는 결과 데이터를 찾아서 item 변수에 넣어줍니다.
            var item = clash.MoveTest.Find(x => x.ID == filterID);

            // 찾는 ID가 없으면 함수 종료
            if (item == null) return;

            // 선택된 이동 경로 항목의 위치로 Group B를 이동
            clash.GroupB[0].Transform(item.Matrix, true);   // true : 모델 초기 상태 기준 (경로를 바꿔도 이동 / 회전이 누적되지 않음)

            // 간섭검사 결과 명칭을 치환
            foreach (var result in item.MoveTestResult)
            {
                string state = "";

                switch (result.ResultKind)
                {
                    case ClashResultKind.CLEARANCE:
                        if (!ckClearance.Checked) continue;
                        state = "여유";
                        break;

                    case ClashResultKind.PROXIMITY:
                        if (!ckProximity.Checked) continue;
                        state = "근접";
                        break;

                    case ClashResultKind.CONTACT:
                        if (!ckContact.Checked) continue;
                        state = "접촉";
                        break;

                    case ClashResultKind.PENETRATION:
                        if (!ckClash.Checked) continue;
                        state = "충돌";
                        break;

                    case ClashResultKind.IDENTITY:
                        if (!ckIdentity.Checked) continue;
                        state = "동일";
                        break;
                }

                // 이동 경로 항목에 대한 결과 값들을 담을 변수
                string groupA = GetNodeName(result.NodeA);
                string groupB = GetNodeName(result.NodeB);
                string distance = result.Distance.ToString("0.#######");
                string position = result.Position1.ToString();
                string direction = result.Direction.ToString();

                // 결과값들을 담을 문자열 배열
                string[] row = new string[] {
                    gridCount++.ToString(),
                    groupA,
                    groupB,
                    state,
                    distance,
                    position,
                    direction
                };

                // 알맞은 결과값들을 데이터 그리드에 삽입
                datagridviewInterferenceResult.Rows.Add(row);
            }

            // 선택된 이동 경로에 저장된 결과 심볼을 보여줌
            foreach (var result in item.MoveTestResult)
            {
                vizcore3dx.Clash.ShowResultSymbol(clash.ID, result, true, true);
            }
        }

        /// <summary>
        /// 노드 이름 반환
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string GetNodeName(Node node)
        {
            if (_nodeNameCache.ContainsKey(node))
                return _nodeNameCache[node];

            if (node.Kind == NodeKind.BODY)
                _nodeNameCache[node] = node.GetParent().NodeName + "-Body";
            else
                _nodeNameCache[node] = node.NodeName;

            return _nodeNameCache[node];
        }

        private void btnPathAdd_Click(object sender, EventArgs e)
        {
            if (clash == null) return;

            // 이동 검사 경로를 설정합니다.
            vizcore3dx.Clash.AddTestPath(clash,
                new Vector3D((float)numDistanceX.Value, (float)numDistanceY.Value, (float)numDistanceZ.Value),
                (float)numDegreeX.Value, (float)numDegreeY.Value, (float)numDegreeZ.Value);

            UpdateTestPathList(clash);

            MessageBox.Show("이동 Path 추가 완료했습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPathClear_Click(object sender, EventArgs e)
        {
            if (clash == null) return;

            // 이동 검사 경로를 Clear 합니다.
            vizcore3dx.Clash.ClearTestPath(clash);

            UpdateTestPathList(clash);

            MessageBox.Show("이동 Path 전체 삭제 완료했습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 이동 그룹(Group B)의 이동 / 회전을 원래 상태로 초기화
        /// </summary>
        private void RestoreGroupBTransform()
        {
            if (clash == null || clash.GroupB == null || clash.GroupB.Count == 0) return;

            vizcore3dx.Object3D.Transform.RestoreTransform(new List<Node>(clash.GroupB));
        }

        private void btnViewAllResult_Click(object sender, EventArgs e)
        {
            if (clash == null) return;

            // Group B의 위치를 초기화
            RestoreGroupBTransform();
            // 선택한 ID에 해당하는 간섭검사 결과를 보여줍니다.
            vizcore3dx.Clash.ShowResultSymbol(clash.ID, true, true);
        }

        // ================================================================
        // 이동 경로 워크플로 : GetTestPaths / ExportTestPaths / ImportTestPaths / PlayTestPathsAsync / StopTestPathPlayback
        // ================================================================

        /// <summary>
        /// 이동 경로 대상 Clash Test 반환 (ClashTest ID 콤보 박스 선택 항목, 없으면 마지막 추가 항목)
        /// </summary>
        /// <returns>Clash Test (없으면 null)</returns>
        private VIZCore3DX.NET.Data.ClashTest GetPathTarget()
        {
            VIZCore3DX.NET.Data.ClashTest item = clash;
            if (cbClashTestId.SelectedItem != null) item = vizcore3dx.Clash.GetClashTest(Convert.ToInt32(cbClashTestId.SelectedItem));

            if (item == null)
            {
                MessageBox.Show("간섭검사를 먼저 추가해 주세요.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return item;
        }

        /// <summary>
        /// 실패 사유(LastOperationStatus) 표시
        /// </summary>
        /// <param name="message">메시지</param>
        private void ShowOperationFailed(string message)
        {
            VIZCore3DX.NET.Data.OperationStatus status = vizcore3dx.Clash.LastOperationStatus;
            string reason = status == null ? "알 수 없음" : status.ToString();

            MessageBox.Show(string.Format("{0}\n\n사유 : {1}", message, reason), "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 이동 경로 목록 갱신 (GetTestPaths)
        /// </summary>
        /// <param name="item">Clash Test</param>
        private void UpdateTestPathList(VIZCore3DX.NET.Data.ClashTest item)
        {
            lstTestPaths.BeginUpdate();
            lstTestPaths.Items.Clear();

            List<ClashMoveTestItem> paths = item == null ? null : vizcore3dx.Clash.GetTestPaths(item);
            if (paths != null)
            {
                foreach (ClashMoveTestItem path in paths)
                    lstTestPaths.Items.Add(string.Format("[{0}] 이동 : {1} / 회전 : {2}", path.ID, path.Distance, path.Angle));
            }

            lstTestPaths.EndUpdate();
        }

        /// <summary>
        /// 재생 중 UI 상태 변경
        /// </summary>
        /// <param name="playing">재생 중 여부</param>
        private void SetPathPlaying(bool playing)
        {
            btnPlayTestPaths.Enabled = !playing;
            btnStopPlayback.Enabled = playing;
            btnGetTestPaths.Enabled = !playing;
            btnExportTestPaths.Enabled = !playing;
            btnImportTestPaths.Enabled = !playing;
            numPlayInterval.Enabled = !playing;
        }

        private void btnGetTestPaths_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.ClashTest item = GetPathTarget();
            if (item == null) return;

            UpdateTestPathList(item);
        }

        private void btnExportTestPaths_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.ClashTest item = GetPathTarget();
            if (item == null) return;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "이동 경로 파일 (*.json)|*.json|모든 파일 (*.*)|*.*";
            dlg.FileName = string.Format("ClashTestPath_{0}.json", item.ID);
            if (dlg.ShowDialog() != DialogResult.OK) return;

            // 이동 경로를 파일로 저장
            bool result = vizcore3dx.Clash.ExportTestPaths(item, dlg.FileName);
            if (result == false)
            {
                ShowOperationFailed("이동 경로 저장에 실패하였습니다.");
                return;
            }

            MessageBox.Show(string.Format("이동 경로 저장 완료\n\n{0}", dlg.FileName), "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImportTestPaths_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.ClashTest item = GetPathTarget();
            if (item == null) return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "이동 경로 파일 (*.json)|*.json|모든 파일 (*.*)|*.*";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            // replaceExisting : true 이면 기존 경로를 지우고 파일의 경로로 대체, false 이면 뒤에 추가
            bool result = vizcore3dx.Clash.ImportTestPaths(item, dlg.FileName, chkReplaceExisting.Checked);
            UpdateTestPathList(item);

            if (result == false)
            {
                ShowOperationFailed("이동 경로 불러오기에 실패하였습니다.");
                return;
            }

            MessageBox.Show(string.Format("이동 경로 불러오기 완료 : {0}건", lstTestPaths.Items.Count), "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnPlayTestPaths_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.ClashTest item = GetPathTarget();
            if (item == null) return;

            List<ClashMoveTestItem> paths = vizcore3dx.Clash.GetTestPaths(item);
            if (paths == null || paths.Count == 0)
            {
                MessageBox.Show("재생할 이동 경로가 없습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetPathPlaying(true);

            bool result = false;
            try
            {
                // 이동 경로를 스텝 단위로 재생 (intervalMs : 스텝 간 대기 시간)
                result = await vizcore3dx.Clash.PlayTestPathsAsync(item, (int)numPlayInterval.Value);
            }
            finally
            {
                SetPathPlaying(false);
            }

            if (result == false) ShowOperationFailed("이동 경로 재생이 중지되었거나 실패하였습니다.");
        }

        private void btnStopPlayback_Click(object sender, EventArgs e)
        {
            // 이동 경로 재생 중지
            vizcore3dx.Clash.StopTestPathPlayback();
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
    }
}
