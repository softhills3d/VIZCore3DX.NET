using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace VIZCore3DX.NET.ClashSweep
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 단일 검사 결과 (4. 결과의 방향 표와 같은 순서)
        private VIZCore3DX.NET.Data.ClashSweepResult _result;

        // 일괄 검사 결과 (4. 결과의 스크리닝 표와 같은 순서)
        private List<VIZCore3DX.NET.Data.ClashSweepResult> _screening;

        // 실행 중인 검사의 취소 토큰
        private CancellationTokenSource _cts;

        public FrmMain()
        {
            InitializeComponent();

            // 뷰어와 무관한 콤보 항목은 생성자에서 채웁니다.
            cmbDirections.Items.AddRange(new object[] { "축 6방향", "축 26방향", "구면" });
            cmbDirections.SelectedIndex = 0;

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
        }

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
            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();

            SetStatus("모델을 열어 주세요.");
        }

        #region 1. 모델
        // 검사할 모델을 엽니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            SetStatus("모델을 열었습니다. 검사할 장비를 뷰에서 선택하세요.");
        }
        #endregion

        #region 2. 설정
        // 개체를 옮기거나 숨긴 뒤에는 장애물 캐시를 무효화해야 다음 검사에 반영됩니다.
        private void btnInvalidate_Click(object sender, EventArgs e)
        {
            vizcore3dx.Clash.Sweep.InvalidateObstacles();
            SetStatus("장애물 캐시를 무효화했습니다. 다음 검사에서 장애물을 다시 추출합니다.");
        }
        #endregion

        #region 3. 실행
        // 선택한 노드를 하나의 이동체로 보고, 방향마다 얼마나 빠질 수 있는지 검사합니다.
        private async void btnRun_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;
            if (vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP).Count == 0)
            {
                SetStatus("먼저 검사할 노드를 선택하세요.");
                return;
            }

            VIZCore3DX.NET.Data.ClashSweepOptions options = BuildOptions();
            SetRunning(true);
            _cts = new CancellationTokenSource();
            try
            {
                _result = await vizcore3dx.Clash.Sweep.RunSelectedAsync(options, new Progress<int>(v => progressBar.Value = Math.Max(0, Math.Min(100, v))), _cts.Token);
            }
            finally
            {
                _cts.Dispose();
                _cts = null;
                SetRunning(false);
            }

            _screening = null;
            dgvScreening.Rows.Clear();

            if (!_result.IsSucceeded)
            {
                SetStatus("검사 실패 : " + (_result.IsCanceled ? "취소됨" : vizcore3dx.Clash.Sweep.LastOperationResult.ToString()));
                return;
            }

            // 표를 먼저 채워야 행 자동 선택이 전체 방향 표시를 덮어쓰지 않습니다.
            FillDirections();
            vizcore3dx.Clash.Sweep.Show(_result);
            FlyToResult();
            SetStatus(string.Format("검사 완료 : 통과 {0}/{1}, 장애물 {2}, {3:F1}초, 판정 {4}",
                _result.FreeDirections.Count, _result.Directions.Count, _result.ObstacleNodeCount, _result.ElapsedSeconds, vizcore3dx.Clash.Sweep.GetVerdict(_result)));
        }

        // 선택한 장비를 하나씩 따로 검사해, 어느 장비가 막혀 있는지 판정 색으로 한눈에 보여 줍니다.
        private async void btnRunMany_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            List<VIZCore3DX.NET.Data.Node> selected = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);
            if (selected.Count < 2)
            {
                SetStatus("장비를 두 개 이상 선택하세요.");
                return;
            }

            // 노드마다 자기만 담은 묶음을 만들어 각각 따로 검사합니다.
            List<List<VIZCore3DX.NET.Data.Node>> groups = new List<List<VIZCore3DX.NET.Data.Node>>();
            foreach (VIZCore3DX.NET.Data.Node node in selected)
                groups.Add(new List<VIZCore3DX.NET.Data.Node> { node });

            VIZCore3DX.NET.Data.ClashSweepOptions options = BuildOptions();
            SetRunning(true);
            _cts = new CancellationTokenSource();
            try
            {
                _screening = await vizcore3dx.Clash.Sweep.RunManyAsync(groups, options, new Progress<int>(v => progressBar.Value = Math.Max(0, Math.Min(100, v))), _cts.Token);
            }
            finally
            {
                _cts.Dispose();
                _cts = null;
                SetRunning(false);
            }

            _result = null;
            dgvDirections.Rows.Clear();

            if (_screening.Count == 0)
            {
                SetStatus("일괄 검사 실패 : " + vizcore3dx.Clash.Sweep.LastOperationResult);
                return;
            }

            FillScreening();
            vizcore3dx.Clash.Sweep.ShowScreening(_screening);
            SetStatus(ScreeningSummary());
        }

        // 진행 중인 검사를 취소합니다. 취소된 결과는 IsCanceled 가 true 입니다.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            vizcore3dx.Clash.Sweep.CancelAsync();
        }
        #endregion

        #region 4. 결과
        // 방향 표에서 고른 방향 하나만 강조해 표시합니다.
        private void dgvDirections_SelectionChanged(object sender, EventArgs e)
        {
            if (_result == null || dgvDirections.SelectedRows.Count == 0) return;

            int index = dgvDirections.SelectedRows[0].Index;
            if (index >= _result.Directions.Count) return;

            vizcore3dx.Clash.Sweep.Show(_result, index);
        }

        // 단일 검사 결과의 모든 방향을 다시 표시합니다.
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            if (_result == null)
            {
                SetStatus("먼저 선택 노드 검사를 실행하세요.");
                return;
            }

            vizcore3dx.Clash.Sweep.Show(_result);
            SetStatus("전체 방향을 표시했습니다.");
        }

        // 고른 방향(없으면 가장 멀리 빠지는 방향)을 이동 간섭 검사로 만들어 실제 경로로 확인합니다.
        private async void btnToMovingTest_Click(object sender, EventArgs e)
        {
            if (_result == null)
            {
                SetStatus("먼저 선택 노드 검사를 실행하세요.");
                return;
            }

            int index;
            if (dgvDirections.SelectedRows.Count > 0)
            {
                index = dgvDirections.SelectedRows[0].Index;
            }
            else
            {
                if (_result.BestDirection == null)
                {
                    SetStatus("통과 방향이 없습니다.");
                    return;
                }
                index = _result.Directions.IndexOf(_result.BestDirection);
            }

            await RunMovingTestAsync(index);
        }

        // 스크리닝 표에서 고른 장비 하나의 검사 결과를 방향별로 표시합니다.
        private void dgvScreening_SelectionChanged(object sender, EventArgs e)
        {
            if (_screening == null || dgvScreening.SelectedRows.Count == 0) return;

            int index = dgvScreening.SelectedRows[0].Index;
            if (index >= _screening.Count) return;

            vizcore3dx.Clash.Sweep.Show(_screening[index]);
        }
        #endregion

        #region 5. 정리
        // 화면의 검사 표시를 지웁니다. 결과 표는 남습니다.
        private void btnHide_Click(object sender, EventArgs e)
        {
            vizcore3dx.Clash.Sweep.Hide();
            SetStatus("표시를 지웠습니다.");
        }

        // 표시를 지우고 결과 표를 비웁니다.
        private void btnClear_Click(object sender, EventArgs e)
        {
            vizcore3dx.Clash.Sweep.Hide();
            _result = null;
            _screening = null;
            dgvDirections.Rows.Clear();
            dgvScreening.Rows.Clear();
            SetStatus("결과를 지웠습니다.");
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

        // 검사 중에는 실행 버튼과 설정을 잠그고 취소 버튼만 엽니다.
        private void SetRunning(bool running)
        {
            btnRun.Enabled = !running;
            btnRunMany.Enabled = !running;
            btnCancel.Enabled = running;
            grpSetup.Enabled = !running;
            if (!running) progressBar.Value = 0;
        }

        // 화면 입력을 검사 옵션으로 옮깁니다.
        private VIZCore3DX.NET.Data.ClashSweepOptions BuildOptions()
        {
            VIZCore3DX.NET.Data.ClashSweepOptions options = new VIZCore3DX.NET.Data.ClashSweepOptions();
            options.MaxDistanceMm = (double)numMaxDistance.Value;
            options.SampleSpacingMm = (double)numSpacing.Value;
            options.UseObstacleCache = chkUseCache.Checked;

            switch (cmbDirections.SelectedIndex)
            {
                case 1: options.Directions = VIZCore3DX.NET.Data.ClashSweepDirectionSet.Axis26; break;
                case 2: options.Directions = VIZCore3DX.NET.Data.ClashSweepDirectionSet.Sphere; break;
                default: options.Directions = VIZCore3DX.NET.Data.ClashSweepDirectionSet.Axis6; break;
            }

            return options;
        }

        // 방향별 통과 여부·거리·막는 개체를 방향 표에 채웁니다.
        private void FillDirections()
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>(_result.Directions.Count);
            foreach (VIZCore3DX.NET.Data.ClashSweepDirectionResult direction in _result.Directions)
            {
                string blocker = "";
                if (direction.Blockers.Count > 0)
                {
                    blocker = direction.Blockers[0].Node.NodeName;
                    if (direction.Blockers.Count > 1) blocker += " 외 " + (direction.Blockers.Count - 1);
                }

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvDirections, DirectionText(direction.Direction), direction.IsFree ? "통과" : "막힘", direction.DistanceMm.ToString("F0"), blocker);
                rows.Add(row);
            }

            dgvDirections.Rows.Clear();
            dgvDirections.Rows.AddRange(rows.ToArray());
            dgvDirections.ClearSelection();
        }

        // 장비별 판정·통과 방향 수·최대 통과 거리를 스크리닝 표에 채웁니다.
        private void FillScreening()
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>(_screening.Count);
            foreach (VIZCore3DX.NET.Data.ClashSweepResult result in _screening)
            {
                string name = result.Targets.Count > 0 ? result.Targets[0].NodeName : "-";

                double max = -1;
                foreach (VIZCore3DX.NET.Data.ClashSweepDirectionResult direction in result.FreeDirections)
                    max = Math.Max(max, direction.DistanceMm);

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvScreening, name, vizcore3dx.Clash.Sweep.GetVerdict(result), result.FreeDirections.Count, max < 0 ? "-" : max.ToString("F0"));
                rows.Add(row);
            }

            dgvScreening.Rows.Clear();
            dgvScreening.Rows.AddRange(rows.ToArray());
            dgvScreening.ClearSelection();
        }

        // 일괄 검사 결과를 판정별로 세어 상태 문구를 만듭니다.
        private string ScreeningSummary()
        {
            int open = 0, partial = 0, blocked = 0;
            double seconds = 0;
            foreach (VIZCore3DX.NET.Data.ClashSweepResult result in _screening)
            {
                switch (vizcore3dx.Clash.Sweep.GetVerdict(result))
                {
                    case VIZCore3DX.NET.Data.ClashSweepVerdict.Open: open++; break;
                    case VIZCore3DX.NET.Data.ClashSweepVerdict.Partial: partial++; break;
                    default: blocked++; break;
                }
                seconds += result.ElapsedSeconds;
            }

            return string.Format("일괄 검사 : 통과 {0}, 부분 {1}, 막힘 {2}, {3:F1}초", open, partial, blocked, seconds);
        }

        // 축 방향이면 "+X" 같은 이름으로, 아니면 성분 값으로 보여 줍니다.
        private static string DirectionText(VIZCore3DX.NET.Data.Vector3D d)
        {
            if (IsUnitAxis(d.X, d.Y, d.Z)) return d.X > 0 ? "+X" : "-X";
            if (IsUnitAxis(d.Y, d.X, d.Z)) return d.Y > 0 ? "+Y" : "-Y";
            if (IsUnitAxis(d.Z, d.X, d.Y)) return d.Z > 0 ? "+Z" : "-Z";

            return string.Format("({0:F2},{1:F2},{2:F2})", d.X, d.Y, d.Z);
        }

        // 첫 성분이 ±1 이고 나머지 두 성분이 0 인지 확인합니다.
        private static bool IsUnitAxis(float main, float other1, float other2)
        {
            return Math.Abs(Math.Abs(main) - 1) < 0.001 && Math.Abs(other1) < 0.001 && Math.Abs(other2) < 0.001;
        }

        // 대상 상자를 최대 거리만큼 사방으로 넓힌 영역으로 카메라를 옮겨, 빠지는 경로 전체가 보이게 합니다.
        private void FlyToResult()
        {
            VIZCore3DX.NET.Data.BoundBox3D box = _result.TargetBoundBox;
            if (box == null) return;

            float m = (float)numMaxDistance.Value;
            vizcore3dx.View.FlyToBoundingBox(
                new VIZCore3DX.NET.Data.Vertex3D(box.MinX - m, box.MinY - m, box.MinZ - m),
                new VIZCore3DX.NET.Data.Vertex3D(box.MaxX + m, box.MaxY + m, box.MaxZ + m));
        }

        // 고른 방향을 이동 간섭 검사로 만들어 간섭 검사 후 경로를 재생하고, 원위치로 되돌립니다.
        private async System.Threading.Tasks.Task RunMovingTestAsync(int index)
        {
            // ToMovingTest 는 간섭 검사의 조립체 단위 설정(IsAssembly)을 덮어쓰므로, 호출 전 값을 기억했다가 되돌립니다.
            bool keepAssembly = vizcore3dx.Clash.IsAssembly;
            VIZCore3DX.NET.Data.ClashTest test = vizcore3dx.Clash.Sweep.ToMovingTest(_result, index, (double)numSpacing.Value * 2);
            vizcore3dx.Clash.IsAssembly = keepAssembly;

            if (test == null)
            {
                SetStatus("이동 검사 생성 실패 : " + vizcore3dx.Clash.Sweep.LastOperationResult);
                return;
            }

            vizcore3dx.Clash.RestoreTestPathPosition(test);
            await vizcore3dx.Clash.PerformInterferenceCheck(test.ID, VIZCore3DX.NET.Manager.ClashManager.ResultGroupingOptions.PART);

            int clashSteps = 0;
            foreach (VIZCore3DX.NET.Data.ClashMoveTestItem step in test.MoveTest)
                if (step.MoveTestResult.Count > 0) clashSteps++;

            await vizcore3dx.Clash.PlayTestPathsAsync(test, 100);
            vizcore3dx.Clash.RestoreTestPathPosition(test);

            SetStatus(string.Format("이동 검사 : 단계 {0} 중 간섭 {1}", test.MoveTest.Count, clashSteps));
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
        #endregion
    }
}
