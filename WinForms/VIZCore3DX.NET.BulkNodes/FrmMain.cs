using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace VIZCore3DX.NET.BulkNodes
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 마지막 조회 결과 - 노드 목록 (적용 비교에 사용)
        private List<VIZCore3DX.NET.Data.Node> _nodes;

        // 마지막 조회 결과 - (EntityID, Index) 항목 목록 (적용 비교와 정리에 사용)
        private List<(int, int)> _entries;

        public FrmMain()
        {
            InitializeComponent();

            // 뷰어와 무관한 콤보 항목은 생성자에서 채웁니다.
            cmbFilter.Items.AddRange(new object[] { "전체(ALL)", "파트(PART)", "보이는 파트(VISIBLE_PART)", "렌더된 파트(GetRenderedNodes)" });
            cmbFilter.SelectedIndex = 0;
            cmbAction.Items.AddRange(new object[] { "색 지정", "이동", "숨기기", "선택" });
            cmbAction.SelectedIndex = 0;

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
        // 비교에 쓸 모델을 엽니다. 이전 조회 결과는 버립니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            _nodes = null;
            _entries = null;
            vizcore3dx.View.FitToView();
            SetStatus("모델을 열었습니다. 조회 대상을 고르고 조회 시간을 비교하세요.");
        }
        #endregion

        #region 3. 실행
        // 같은 조건으로 노드 목록과 (EntityID, Index) 항목 목록을 조회해 시간과 메모리를 비교합니다.
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            int repeat = (int)numRepeat.Value;
            double nodesMs = 0, entriesMs = 0;
            long nodesMem = 0, entriesMem = 0;

            for (int i = 0; i < repeat; i++)
            {
                long before = SettledMemory();
                Stopwatch watch = Stopwatch.StartNew();
                _nodes = QueryNodes();
                nodesMs += watch.Elapsed.TotalMilliseconds;
                nodesMem += GC.GetTotalMemory(false) - before;

                before = SettledMemory();
                watch = Stopwatch.StartNew();
                _entries = QueryEntries();
                entriesMs += watch.Elapsed.TotalMilliseconds;
                entriesMem += GC.GetTotalMemory(false) - before;
            }

            nodesMs /= repeat;
            entriesMs /= repeat;
            int count = _entries.Count;
            AddRow("조회 " + SelectedFilterName(), nodesMs, entriesMs, count);
            AddRow("조회 메모리(MB)", nodesMem / (double)repeat / (1024 * 1024), entriesMem / (double)repeat / (1024 * 1024), count);

            double saving = nodesMs > 0 ? 1 - entriesMs / nodesMs : 0;
            SetStatus(string.Format("조회 : {0}건, 노드 {1:F0}ms → 항목 {2:F0}ms ({3:P0} 절감)", count, nodesMs, entriesMs, saving));
        }

        // 조회한 목록에 같은 동작을 노드 목록으로 한 번, 항목 목록으로 한 번 적용해 시간을 비교합니다.
        // 노드 목록 결과는 되돌리고 항목 목록 결과만 화면에 남깁니다.
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;
            if (_entries == null || _entries.Count == 0)
            {
                SetStatus("먼저 조회를 실행하세요");
                return;
            }

            double nodesMs, entriesMs;
            vizcore3dx.BeginUpdate();
            try
            {
                switch (cmbAction.SelectedIndex)
                {
                    case 1: ApplyMove(out nodesMs, out entriesMs); break;
                    case 2: ApplyHide(out nodesMs, out entriesMs); break;
                    case 3: ApplySelect(out nodesMs, out entriesMs); break;
                    default: ApplyColor(out nodesMs, out entriesMs); break;
                }
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            string actionName = cmbAction.SelectedItem.ToString();
            AddRow(actionName, nodesMs, entriesMs, _entries.Count);
            SetStatus(string.Format("{0} : {1}건, 노드 {2:F0}ms → 항목 {3:F0}ms", actionName, _entries.Count, nodesMs, entriesMs));
        }
        #endregion

        #region 4. 결과
        // 비교 표를 비웁니다. 화면 상태는 그대로 둡니다.
        private void btnClearRows_Click(object sender, EventArgs e)
        {
            dgvTimes.Rows.Clear();
            SetStatus("표를 비웠습니다.");
        }
        #endregion

        #region 5. 정리
        // 항목 목록으로 적용한 색·이동·숨김·선택을 모두 원래대로 되돌립니다.
        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (RestoreEntries()) SetStatus("원래대로 되돌렸습니다.");
            else SetStatus("되돌릴 조회 결과가 없습니다.");
        }

        // 화면을 되돌리고 표와 조회 결과를 모두 비웁니다.
        private void btnClear_Click(object sender, EventArgs e)
        {
            RestoreEntries();
            dgvTimes.Rows.Clear();
            _nodes = null;
            _entries = null;
            SetStatus("전부 지웠습니다.");
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

        // 표의 단계 이름에 쓸 조회 대상 이름입니다.
        private string SelectedFilterName()
        {
            return cmbFilter.SelectedItem.ToString();
        }

        // 선택한 조회 대상을 노드 목록으로 가져옵니다.
        private List<VIZCore3DX.NET.Data.Node> QueryNodes()
        {
            switch (cmbFilter.SelectedIndex)
            {
                case 1: return vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.PART);
                case 2: return vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.VISIBLE_PART);
                case 3: return vizcore3dx.Object3D.GetRenderedNodes(VIZCore3DX.NET.Data.NodeKind.PART);
                default: return vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.ALL);
            }
        }

        // 선택한 조회 대상을 (EntityID, Index) 항목 목록으로 가져옵니다.
        private List<(int, int)> QueryEntries()
        {
            switch (cmbFilter.SelectedIndex)
            {
                case 1: return vizcore3dx.Object3D.FromFilterEntry(VIZCore3DX.NET.Data.Object3dFilter.PART);
                case 2: return vizcore3dx.Object3D.FromFilterEntry(VIZCore3DX.NET.Data.Object3dFilter.VISIBLE_PART);
                case 3: return vizcore3dx.Object3D.GetRenderedNodesEntry(VIZCore3DX.NET.Data.NodeKind.PART);
                default: return vizcore3dx.Object3D.FromFilterEntry(VIZCore3DX.NET.Data.Object3dFilter.ALL);
            }
        }

        // 이전 결과가 메모리 측정에 섞이지 않도록 GC 를 끝낸 뒤의 사용량을 돌려줍니다.
        private static long SettledMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            return GC.GetTotalMemory(true);
        }

        private static double TimeAction(Action action)
        {
            Stopwatch watch = Stopwatch.StartNew();
            action();
            return watch.Elapsed.TotalMilliseconds;
        }

        // 색 지정 : 노드 목록은 주황으로 칠한 뒤 되돌리고, 항목 목록은 파랑으로 칠해 남깁니다.
        private void ApplyColor(out double nodesMs, out double entriesMs)
        {
            nodesMs = 0;
            if (_nodes != null && _nodes.Count > 0)
            {
                nodesMs = TimeAction(() => vizcore3dx.Object3D.Color.SetColor(_nodes, System.Drawing.Color.FromArgb(255, 120, 0)));
                vizcore3dx.Object3D.Color.RestoreColor(_nodes);
            }
            entriesMs = TimeAction(() => vizcore3dx.Object3D.Color.SetColor(_entries, System.Drawing.Color.FromArgb(0, 120, 255)));
        }

        // 이동 : 입력한 거리만큼 X 방향으로 옮깁니다.
        private void ApplyMove(out double nodesMs, out double entriesMs)
        {
            float distance = (float)numMove.Value;
            nodesMs = TimeAction(() => vizcore3dx.Object3D.Transform.Move(_nodes, distance, 0, 0));
            vizcore3dx.Object3D.Transform.RestoreTransform(_nodes);
            entriesMs = TimeAction(() => vizcore3dx.Object3D.Transform.Move(_entries, distance, 0, 0));
        }

        // 숨기기 : 노드 목록은 숨긴 뒤 다시 보이고, 항목 목록은 숨긴 채로 둡니다.
        private void ApplyHide(out double nodesMs, out double entriesMs)
        {
            nodesMs = TimeAction(() => vizcore3dx.Object3D.Show(_nodes, false));
            vizcore3dx.Object3D.Show(_nodes, true);
            entriesMs = TimeAction(() => vizcore3dx.Object3D.Show(_entries, false));
        }

        // 선택 : 노드 목록은 선택한 뒤 해제하고, 항목 목록은 선택한 채로 둡니다.
        private void ApplySelect(out double nodesMs, out double entriesMs)
        {
            nodesMs = TimeAction(() => vizcore3dx.Object3D.Select(_nodes, true));
            vizcore3dx.Object3D.Select(_nodes, false);
            entriesMs = TimeAction(() => vizcore3dx.Object3D.Select(_entries, true));
        }

        // 항목 목록으로 색·위치·표시·선택을 되돌립니다. 되돌릴 목록이 없으면 false 입니다.
        private bool RestoreEntries()
        {
            if (_entries == null || _entries.Count == 0) return false;

            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.Object3D.Color.RestoreColor(_entries);
                vizcore3dx.Object3D.Transform.RestoreTransform(_entries);
                vizcore3dx.Object3D.Show(_entries, true);
                vizcore3dx.Object3D.Select(_entries, false);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
            return true;
        }

        // 표에 한 줄을 덧붙입니다. 절감은 1 - 항목/노드 입니다.
        private void AddRow(string step, double nodesMs, double entriesMs, int count)
        {
            string saving = nodesMs == 0 ? "-" : (1 - entriesMs / nodesMs).ToString("P0");
            dgvTimes.Rows.Add(step, nodesMs.ToString("F1"), entriesMs.ToString("F1"), saving, count);
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
