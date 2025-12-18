using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
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

            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3D_OnInitializedVIZCore3D;

            splitContainer2.Panel1.Controls.Add(vizcore3dx);

            InitializeVIZCore3DXEvent();

        }

        private void VIZCore3D_OnInitializedVIZCore3D(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================
            // 라이선스 파일을 통한 인증
            //vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            //vizcore3dx.License.LicenseServer("127.0.0.1", 8901);


            // ================================================================
            // License
            // ================================================================
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");
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
            vizcore3dx.ToolbarMain.Visible = true;
            vizcore3dx.ToolbarNote.Visible = false;
            vizcore3dx.ToolbarMeasure.Visible = false;
            vizcore3dx.ToolbarSection.Visible = false;
            vizcore3dx.ToolbarSnapshot.Visible = false;

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();

            cbClashTestKind.SelectedIndex = 0;
        }

        private void InitializeVIZCore3DXEvent()
        {
            // Clash Test 완료 이벤트
            vizcore3dx.Clash.OnClashTestFinishedEvent += Clash_OnClashTestFinishedEvent;
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
        /// Cash Test 그룹 A 설정
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

            MessageBox.Show("선택된 모델을 그룹에 설정 하였습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            MessageBox.Show("선택된 모델을 그룹에 설정 하였습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            clash.PenetrationTolerance = (float)numPenetrationTolerance.Value;

            vizcore3dx.Clash.IsAssembly = true; // True : Assembly, False : Part

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

            MessageBox.Show(
                string.Format("Clash Test Completed. : {0} / {1}"
                , e.ID
                , clash.ElapsedTimeString)
                , "VIZCore3DX.NET.ClashTest"
                , MessageBoxButtons.OK, MessageBoxIcon.Information
                );

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
        }

        /// <summary>
        /// Clash Test 결과 리스트 갱신
        /// </summary>
        /// <param name="resultItems"></param>
        private void UpdateResultList(List<VIZCore3DX.NET.Data.ClashTestResultItem> resultItems)
        {
            _isResultUpdating = true;

            datagridviewInterferenceResult.SuspendLayout();
            datagridviewInterferenceResult.Rows.Clear();

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

            datagridviewInterferenceResult.RowCount = _filteredResultItems.Count;

            datagridviewInterferenceResult.ClearSelection();
            datagridviewInterferenceResult.CurrentCell = null;
            datagridviewInterferenceResult.ResumeLayout();

            _isResultUpdating = false;
        }

        /// <summary>
        /// Clash Test 결과 리스트의 셀 값
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void datagridviewInterferenceResult_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (_filteredResultItems.Count == 0)
                return;

            if (_isResultUpdating)
                return;

            var resultItem = _filteredResultItems[e.RowIndex];
            switch (e.ColumnIndex)
            {
                case 0:
                    e.Value = GetNodeName(resultItem.NodeA);
                    break;

                case 1:
                    e.Value = GetNodeName(resultItem.NodeB);
                    break;

                case 2:
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

                case 3:
                    e.Value = resultItem.Distance.ToString("0.#######");
                    break;

                case 4:
                    e.Value = resultItem.Position1.ToString();
                    break;

                case 5:
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
        private void checkInterferenceStatus_CheckedChanged(object sender, EventArgs e)
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

        private void datagridviewInterferenceResult_SelectionChanged(object sender, EventArgs e)
        {
            if (datagridviewInterferenceResult.SelectedRows.Count == 0) return;

            if (_isResultUpdating)
                return;

            int rowIndex = datagridviewInterferenceResult.SelectedRows[0].Index;

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
    }
}
