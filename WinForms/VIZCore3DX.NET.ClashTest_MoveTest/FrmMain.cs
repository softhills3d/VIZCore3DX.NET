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
        public Dictionary<int, List<VIZCore3DX.NET.Data.ClashTestResultItem>> dicResult = new Dictionary<int, List<VIZCore3DX.NET.Data.ClashTestResultItem>>();

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

            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3D_OnInitializedVIZCore3DX;

            splitContainer2.Panel1.Controls.Add(vizcore3dx);
        }

        private void VIZCore3D_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // License
            // ================================================================

            // 라이선스 파일을 통한 인증
            // vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("192.168.100.252", 8901);


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
            vizcore3dx.ToolbarMain.Visible = true;
            vizcore3dx.ToolbarNote.Visible = false;
            vizcore3dx.ToolbarMeasure.Visible = false;
            vizcore3dx.ToolbarSection.Visible = false;
            vizcore3dx.ToolbarSnapshot.Visible = false;

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
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

            nodesA = nodes;

            nodesA[0].SetColor(Color.Black);

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

            nodesB[0].SetColor(Color.Green);

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

            clash.TestKind = VIZCore3DX.NET.Data.ClashTest.ClashTestKind.GROUP_VS_MOVING_GROUP;

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
        private async void btnStart_Click(object sender, EventArgs e)
        {
            ResultGroupingOptions resultGroupingOptions;

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

            vizcore3dx.Clash.OnClashTestFinishedEvent += Clash_OnClashTestFinishedEvent;
            vizcore3dx.Clash.OnClashMoveTestReportFinished += Clash_OnClashMoveTestReportFinished;

            // 간섭검사 수행
            bool result = await vizcore3dx.Clash.PerformInterferenceCheck(clash.ID, resultGroupingOptions);

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
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (_isClashTestMode) return;

            _isClashTestMode = false;

            vizcore3dx.Clash.ClearResultSymbol();
            clash.GroupB[0].ResetTransform();
            vizcore3dx.Clash.Clear();
            vizcore3dx.View.ResetView();
            cbClashTestId.Items.Clear();

            datagridviewInterferencePath.Rows.Clear();
            datagridviewInterferenceResult.Rows.Clear();

            List<Node> nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.ROOT);
            vizcore3dx.Object3D.Color.RestoreAll();
        }
        
        /// <summary>
        /// Clash Test 완료 이벤트
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void Clash_OnClashTestFinishedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ClashEventArgs e)
        {
            vizcore3dx.Clash.ShowResultSymbol(clash.ID, true, true);
        }

        private void Clash_OnClashMoveTestReportFinished(object sender, VIZCore3DX.NET.Event.EventManager.ClashEventArgs e)
        {
            _nodeNameCache.Clear();

            UpdatePathGridView();

            _isClashTestMode = false;
        }

        /// <summary>
        /// Clash Test Path 그리드 뷰 갱신
        /// </summary>
        /// <param name="pathItems"></param>
        private void UpdatePathGridView()
        {
            datagridviewInterferencePath.AutoGenerateColumns = false;
            datagridviewInterferencePath.Rows.Clear();

            for (int i = 0; i < clash.MoveTest.Count; i++) {
                string[] row = new string[] {
                    clash.MoveTest[i].TestID.ToString(),
                    clash.MoveTest[i].ID.ToString(),
                    clash.MoveTest[i].Distance.ToString(),
                    clash.MoveTest[i].Angle.ToString(),
                    clash.MoveTest[i].Matrix.ToString(),
                    clash.MoveTest[i].MoveTestResult.Count.ToString()
                };

                int rowIndex = datagridviewInterferencePath.Rows.Add(row);

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
        /// Clash Test 결과 그리드 뷰 갱신
        /// </summary>
        /// <param name="pathId"></param>
        private void UpdateResultGridView(object id)
        {
            datagridviewInterferenceResult.Rows.Clear();
            vizcore3dx.Clash.ClearResultSymbol();

            int filterID = (int)id;

            var item = clash.MoveTest.Find(x => x.ID == filterID);

            // 찾는 ID가 없으면 함수 종료
            if (item == null) return;

            clash.GroupB[0].Transform(item.Matrix);

            foreach (var result in item.MoveTestResult)
            {
                bool filter = false;
                string state = "";

                switch (result.ResultKind)
                {
                    case ClashResultKind.CLEARANCE:
                        if (!ckClearance.Checked)
                        {
                            filter = true;
                            continue;
                        }
                        state = "여유";
                        break;

                    case ClashResultKind.PROXIMITY:
                        if (!ckProximity.Checked)
                        {
                            filter = true;
                            continue;
                        }
                        state = "근접";
                        break;

                    case ClashResultKind.CONTACT:
                        if (!ckProximity.Checked)
                        {
                            filter = true;
                            continue;
                        }
                        state = "접촉";
                        break;

                    case ClashResultKind.PENETRATION:
                        if (!ckClash.Checked)
                        {
                            filter = true;
                            continue;
                        }
                        state = "충돌";
                        break;

                    case ClashResultKind.IDENTITY:
                        if (!ckIdentity.Checked)
                        {
                            filter = true;
                            continue;
                        }
                        state = "동일";
                        break;
                }

                if (filter) continue;

                string groupA = GetNodeName(result.NodeA);
                string groupB = GetNodeName(result.NodeB);
                string distance = result.Distance.ToString("0.#######");
                string position = result.Position1.ToString();
                string direction = result.Direction.ToString();

                string[] row = new string[] {
                    gridCount++.ToString(),
                    groupA,
                    groupB,
                    state,
                    distance,
                    position,
                    direction
                };

                datagridviewInterferenceResult.Rows.Add(row);

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

            vizcore3dx.Clash.AddTestPath(clash,
                new Vector3D((float)numDistanceX.Value, (float)numDistanceY.Value, (float)numDistanceZ.Value),
                (float)numDegreeX.Value, (float)numDegreeY.Value, (float)numDegreeZ.Value);

            MessageBox.Show("이동 Path 추가 완료했습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPathClear_Click(object sender, EventArgs e)
        {
            vizcore3dx.Clash.ClearTestPath(clash);

            MessageBox.Show("이동 Path 전체 삭제 완료했습니다.", "VIZCore3DX.NET.ClashTest", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnViewAllResult_Click(object sender, EventArgs e)
        {
            if (clash == null) return;

            clash.GroupB[0].ResetTransform();
            vizcore3dx.Clash.ShowResultSymbol(clash.ID, true, true);
        }
    }
}
