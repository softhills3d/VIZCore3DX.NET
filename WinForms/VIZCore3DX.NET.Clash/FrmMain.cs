using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using static VIZCore3DX.NET.Data.ClashTest;
using static VIZCore3DX.NET.Data.ClashTestResultItem;

namespace VIZCore3DX.NET.ClashTest
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// VIZCore3DX.NET Control
        /// </summary>
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        /// <summary>
        /// Clash test
        /// </summary>
        VIZCore3DX.NET.Data.ClashTest clash { get; set; }

        /// <summary>
        /// 필터링 된 결과 리스트
        /// </summary>
        private List<ClashTestResultItem> _filteredResultItems = new List<ClashTestResultItem>();

        /// <summary>
        /// 노드 이름 캐시
        /// </summary>
        private Dictionary<Node, string> _nodeNameCache = new Dictionary<Node, string>();

        /// <summary>
        /// 결과 리스트 갱신 중 여부
        /// </summary>
        private bool _isResultUpdating = false;

        /// <summary>
        /// Clash Test 진행 중 여부
        /// </summary>
        private bool _isClashTestMode = false;

        /// <summary>
        /// Clash Test 결과 리스트
        /// </summary>
        List<VIZCore3DX.NET.Data.ClashTestResultItem> resultItems = new List<VIZCore3DX.NET.Data.ClashTestResultItem>();

        /// <summary>
        /// Group A, B 노드 리스트
        /// </summary>
        List<Data.Node> nodesA = new List<Data.Node>();
        List<Data.Node> nodesB = new List<Data.Node>();

        /// <summary>
        /// 테스트 ID, 간섭 결과 Dictionary
        /// </summary>
        public Dictionary<int, List<VIZCore3DX.NET.Data.ClashTestResultItem>> dicResult = new Dictionary<int, List<VIZCore3DX.NET.Data.ClashTestResultItem>>();

        public FrmMain()
        {
            InitializeComponent();

            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;

            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            splitContainer2.Panel1.Controls.Add(vizcore3dx);

            InitializeVIZCore3DXEvent();

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
            //InitializeVIZCore3DXEvent();
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

            cbClashTestKind.SelectedIndex = 0;

            // 결과 리포트 그룹 단위 (PART / ASSEMBLY)
            cmbReportGrouping.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Manager.ClashManager.ResultGroupingOptions));
            cmbReportGrouping.SelectedItem = VIZCore3DX.NET.Manager.ClashManager.ResultGroupingOptions.PART;
        }

        private void InitializeVIZCore3DXEvent()
        {
            // Clash Test 완료 이벤트
            vizcore3dx.Clash.OnClashTestFinishedEvent += Clash_OnClashTestFinishedEvent;

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
            bool enable = false;

            if (vizcore3dx.Model.IsOpen() == true && vizcore3dx.Model.Files != null)
            {
                foreach (string file in vizcore3dx.Model.Files)
                {
                    if (string.Equals(System.IO.Path.GetFileName(file), ScenarioModelName, StringComparison.OrdinalIgnoreCase)) enable = true;
                }
            }

            btnLoadScenario.Enabled = enable;
        }

        /// <summary>
        /// 테스트 시나리오 불러오기 : 장비 검사, 그룹 A = Boom Section 3 (Boom Head / Boom Section 2 / Boom Section 1 과 간섭)
        /// </summary>
        private void btnLoadScenario_Click(object sender, EventArgs e)
        {
            List<Node> groupA = new List<Node>();

            foreach (Node node in vizcore3dx.Object3D.FromFilter(Object3dFilter.PART))
            {
                if (node.NodeName == "Boom Section 3") groupA.Add(node);
            }

            if (groupA.Count == 0)
            {
                MessageBox.Show("시나리오 대상 노드(Boom Section 3)를 찾을 수 없습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 이전 검사가 남아 있으면 종료 (검사 진행 상태 초기화)
            if (_isClashTestMode) btnExit_Click(sender, e);

            // 장비 검사 : 그룹 A 와 나머지 전체 모델 간 간섭
            cbClashTestKind.SelectedIndex = 1;
            nodesA = groupA;
            nodesB = new List<Node>();

            // 간섭 검사 추가 후 바로 실행
            btnAdd_Click(sender, e);
            if (clash == null || cbClashTestId.Items.Contains(clash.ID) == false) return;

            btnStart_Click(sender, e);
        }

        /// <summary>
        /// 모델 열기
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            // 모델 다이얼로그 통해 열기
            vizcore3dx.Model.OpenFileDialog();
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

            nodesA = nodes;

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

            nodesB = nodes;

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
            clash = new VIZCore3DX.NET.Data.ClashTest();

            if (cbClashTestKind.SelectedIndex == 0)
            {
                clash.TestKind = VIZCore3DX.NET.Data.ClashTest.ClashTestKind.GROUP_VS_GROUP;
            }
            else if (cbClashTestKind.SelectedIndex == 1)
            {
                clash.TestKind = VIZCore3DX.NET.Data.ClashTest.ClashTestKind.SELECTED_MODEL_VS_OTHER;
            }

            clash.GroupA.AddRange(nodesA);
            clash.GroupB.AddRange(nodesB);

            clash.UseClearanceValue = ckUseClearanceValue.Checked;
            clash.ClearanceValue = (float)numClearanceValue.Value;
            clash.UseRangeValue = ckUseRangeValue.Checked;
            clash.RangeValue = (float)numRangeValue.Value;
            clash.PenetrationTolerance = (float)numPenetration.Value;

            vizcore3dx.Clash.IsAssembly = true; // True : Assembly, False : Part

            switch (clash.TestKind)
            {
                case ClashTestKind.GROUP_VS_GROUP:
                    {
                        if (clash.GroupA.Count == 0 || clash.GroupB.Count == 0)     // GroupA, GroupB 둘다 지정해야함.
                        {
                            MessageBox.Show("간섭검사 그룹이 설정되지 않았습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    break;
                case ClashTestKind.SELECTED_MODEL_VS_OTHER:
                    {
                        if (clash.GroupA.Count == 0)        // GroupA 지정 해야함. GroupB 는 코어 내부에서 GroupA 이외의 노드들로 지정됨.
                        {
                            MessageBox.Show("간섭검사 그룹이 설정되지 않았습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    break;
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
            if (dicResult.Count == 0) return;

            foreach (var dic in dicResult)
            {
                if (dic.Key == Convert.ToInt32(cbClashTestId.SelectedItem))
                {
                    dicResult.Remove(dic.Key);
                    break;
                }
            }

            foreach (var item in vizcore3dx.Clash.Items)
            {
                if (item.ID == Convert.ToInt32(cbClashTestId.SelectedItem))
                {
                    vizcore3dx.Clash.Delete(item);
                    break;
                }
            }

            int bNum = Convert.ToInt32(cbClashTestId.SelectedIndex) - 1;

            cbClashTestId.Items.Remove(cbClashTestId.SelectedItem);

            // Clash Test가 모두 삭제되었을 경우
            if (bNum < 0)
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
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!cbClashTestId.Items.Contains(clash.ID)) return;

            vizcore3dx.Clash.ClearResultSymbol();

            if (_isClashTestMode)
            {
                MessageBox.Show("간섭검사 진행 중에는 실행할 수 없습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isClashTestMode = true;

            _nodeNameCache.Clear();

            // 간섭검사 수행
            bool result = vizcore3dx.Clash.PerformInterferenceCheck(clash.ID);

            if (result == false)
            {
                MessageBox.Show("간섭검사 수행에 실패하였습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Clash Test 종료
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!_isClashTestMode) return;

            _isClashTestMode = false;

            vizcore3dx.Clash.ClearResultSymbol();
            vizcore3dx.View.ResetView();

            List<Node> nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.ROOT);
            vizcore3dx.Object3D.Color.RestoreAll();
        }


        private void cbClashTestKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClashTestKind.SelectedIndex == 0)
            {
                btnAddGroupB.Enabled = true;
            }
            else if (cbClashTestKind.SelectedIndex == 1)
            {
                btnAddGroupB.Enabled = false;
            }
        }


        /// <summary>
        /// Clash Test 완료 이벤트
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void Clash_OnClashTestFinishedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ClashEventArgs e)
        {
            _nodeNameCache.Clear();

            bool resultDataKind = false; // True : Assembly, False : Part

            {
                resultItems = vizcore3dx.Clash.GetResultItem(
                    clash
                    , resultDataKind == true
                    ? VIZCore3DX.NET.Manager.ClashManager.ResultGroupingOptions.ASSEMBLY
                    : VIZCore3DX.NET.Manager.ClashManager.ResultGroupingOptions.PART
                    );
            }

            vizcore3dx.Clash.ShowResultSymbol(clash.ID, Color.FromArgb(20, 225, 0, 0), Color.FromArgb(50, 0, 0, 225), true, true, true);

            if (!dicResult.ContainsKey(e.ID))
            {
                dicResult.Add(e.ID, resultItems);
            }

            UpdateResultList(resultItems);

            // 결과 건수 표시 (0건이면 그룹 설정을 확인하도록 안내)
            string message = resultItems.Count == 0
                ? string.Format("Clash Test Completed. (ID : {0} / {1})\n\n간섭 결과가 없습니다. 그룹 설정을 확인하세요.", e.ID, clash.ElapsedTimeString)
                : string.Format("Clash Test Completed. (ID : {0} / {1})\n\n결과 : {2:N0}건", e.ID, clash.ElapsedTimeString, resultItems.Count);

            MessageBox.Show(message, "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Clash Test 결과 리스트 갱신
        /// </summary>
        /// <param name="resultItems"></param>
        private void UpdateResultList(List<VIZCore3DX.NET.Data.ClashTestResultItem> resultItems)
        {
            _isResultUpdating = true;

            dgvResult.SuspendLayout();
            dgvResult.Rows.Clear();

            _filteredResultItems.Clear();

            foreach (var item in resultItems)
            {
                switch (item.ResultKind)
                {
                    case ClashResultKind.CLEARANCE:
                        if (!ckClearance.Checked)
                            continue;
                        break;

                    case ClashResultKind.PROXIMITY:
                        if (!ckProximity.Checked)
                            continue;
                        break;

                    case ClashResultKind.CONTACT:
                        if (!ckContact.Checked)
                            continue;
                        break;

                    case ClashResultKind.PENETRATION:
                        if (!ckClash.Checked)
                            continue;
                        break;

                    case ClashResultKind.IDENTITY:
                        if (!ckIdentity.Checked)
                            continue;
                        break;
                }

                _filteredResultItems.Add(item);
            }

            dgvResult.RowCount = _filteredResultItems.Count;

            dgvResult.ClearSelection();
            dgvResult.CurrentCell = null;
            dgvResult.ResumeLayout();

            _isResultUpdating = false;
        }

        /// <summary>
        /// Clash Test 결과 리스트의 셀 값
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void dgvResult_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (_filteredResultItems.Count == 0)
                return;

            if (_isResultUpdating)
                return;

            var resultItem = _filteredResultItems[e.RowIndex];
            switch (e.ColumnIndex)
            {
                case 0:
                    e.Value = resultItem.NodeIndexA;
                    break;

                case 1:
                    e.Value = GetNodeName(resultItem.NodeA);
                    break;

                case 2:
                    e.Value = resultItem.NodeIndexB;
                    break;

                case 3:
                    e.Value = GetNodeName(resultItem.NodeB);
                    break;

                case 4:
                    switch (resultItem.ResultKind)
                    {
                        case ClashResultKind.CLEARANCE:
                            e.Value = "여유";
                            break;

                        case ClashResultKind.PROXIMITY:
                            e.Value = "근접";
                            break;

                        case ClashResultKind.CONTACT:
                            e.Value = "접촉";
                            break;

                        case ClashResultKind.PENETRATION:
                            e.Value = "충돌";
                            break;

                        case ClashResultKind.IDENTITY:
                            e.Value = "동일";
                            break;
                    }
                    break;

                case 5:
                    e.Value = resultItem.Distance.ToString("0.#######");
                    break;

                case 6:
                    e.Value = resultItem.Position1.ToString();
                    break;

                case 7:
                    e.Value = resultItem.Direction.ToString();
                    break;
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

        /// <summary>
        /// 선택된 Clash Test ID 결과 리스트 상에 갱신 
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void ckResultKind_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var dic in dicResult)
            {
                if (dic.Key == Convert.ToInt32(cbClashTestId.SelectedItem))
                {
                    UpdateResultList(dic.Value);
                    return;
                }
            }

        }

        private void dgvResult_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count == 0) return;

            if (_isResultUpdating)
                return;

            int rowIndex = dgvResult.SelectedRows[0].Index;

            if (rowIndex >= 0 && rowIndex < _filteredResultItems.Count)
            {
                ClashTestResultItem item = _filteredResultItems[rowIndex] as ClashTestResultItem;

                if (item != null)
                {
                    //vizcore3dx.View.ResetView();
                    vizcore3dx.Clash.ClearResultSymbol();
                    vizcore3dx.Clash.ShowResultSymbol(clash.ID, item, Color.FromArgb(100, 255, 0, 0), Color.FromArgb(100, 0, 0255), true, true, true);
                    vizcore3dx.View.FlyToBoundingBox(item.Position1, item.Position2);
                }
            }
        }

        // ================================================================
        // 결과 리포트 : ExportResultCsv / ExportReportHtmlAsync / StopReportExport
        // ================================================================

        /// <summary>
        /// 결과 리포트 대상 Clash Test 반환 (ClashTest ID 콤보 박스 선택 항목)
        /// </summary>
        /// <returns>Clash Test (없으면 null)</returns>
        private VIZCore3DX.NET.Data.ClashTest GetReportTarget()
        {
            if (cbClashTestId.SelectedItem == null)
            {
                MessageBox.Show("ClashTest ID를 선택해 주세요.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            VIZCore3DX.NET.Data.ClashTest item = vizcore3dx.Clash.GetClashTest(Convert.ToInt32(cbClashTestId.SelectedItem));
            if (item == null)
            {
                MessageBox.Show("선택한 간섭검사를 찾을 수 없습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (dicResult.ContainsKey(item.ID) == false)
            {
                MessageBox.Show("간섭검사를 먼저 수행해 주세요.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        /// 리포트 내보내기 진행 중 UI 상태 변경
        /// </summary>
        /// <param name="exporting">진행 중 여부</param>
        private void SetReportExporting(bool exporting)
        {
            btnExportCsv.Enabled = !exporting;
            btnExportHtml.Enabled = !exporting;
            cmbReportGrouping.Enabled = !exporting;
            chkCaptureImages.Enabled = !exporting;
            btnStopReport.Enabled = exporting;
        }

        /// <summary>
        /// 결과 표 CSV 내보내기
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.ClashTest item = GetReportTarget();
            if (item == null) return;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "CSV (*.csv)|*.csv";
            dlg.FileName = string.Format("ClashResult_{0}.csv", item.ID);
            if (dlg.ShowDialog() != DialogResult.OK) return;

            VIZCore3DX.NET.Manager.ClashManager.ResultGroupingOptions option = (VIZCore3DX.NET.Manager.ClashManager.ResultGroupingOptions)cmbReportGrouping.SelectedItem;

            bool result = vizcore3dx.Clash.ExportResultCsv(item, dlg.FileName, option);
            if (result == false)
            {
                lblReportStatus.Text = "상태 : CSV 내보내기 실패";
                ShowOperationFailed("결과 CSV 내보내기에 실패하였습니다.");
                return;
            }

            lblReportStatus.Text = "상태 : CSV 내보내기 완료";
            MessageBox.Show(string.Format("결과 CSV 내보내기 완료\n\n{0}", dlg.FileName), "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 간섭 위치 캡처 이미지를 내장한 HTML 리포트 내보내기 (비동기)
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private async void btnExportHtml_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.ClashTest item = GetReportTarget();
            if (item == null) return;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "HTML (*.html)|*.html";
            dlg.FileName = string.Format("ClashReport_{0}.html", item.ID);
            if (dlg.ShowDialog() != DialogResult.OK) return;

            VIZCore3DX.NET.Manager.ClashManager.ResultGroupingOptions option = (VIZCore3DX.NET.Manager.ClashManager.ResultGroupingOptions)cmbReportGrouping.SelectedItem;

            SetReportExporting(true);
            lblReportStatus.Text = "상태 : HTML 리포트 내보내는 중...";

            bool result = false;
            try
            {
                // captureImages : true 이면 각 간섭 위치를 캡처하여 HTML에 내장
                result = await vizcore3dx.Clash.ExportReportHtmlAsync(item, dlg.FileName, option, chkCaptureImages.Checked);
            }
            finally
            {
                SetReportExporting(false);
            }

            if (result == false)
            {
                lblReportStatus.Text = "상태 : HTML 리포트 중지 또는 실패";
                ShowOperationFailed("HTML 리포트 내보내기가 중지되었거나 실패하였습니다.");
                return;
            }

            lblReportStatus.Text = "상태 : HTML 리포트 완료";
            MessageBox.Show(string.Format("HTML 리포트 내보내기 완료\n\n{0}", dlg.FileName), "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// HTML 리포트 내보내기 중지
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnStopReport_Click(object sender, EventArgs e)
        {
            vizcore3dx.Clash.StopReportExport();
            lblReportStatus.Text = "상태 : 중지 요청";
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
