using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.CustomModelTree
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 아직 불러오지 않은 자식 자리에 넣는 임시 노드 텍스트
        private const string DUMMY_NODE_KEY = "DUMMY_NODE";

        // 코드가 체크 상태를 바꾸는 동안에는 체크 이벤트를 뷰어로 되돌려 보내지 않습니다.
        private bool _isUpdatingUI = false;

        // 다중 선택 상태 (선택 노드 집합 + Shift 범위의 기준 노드)
        private readonly HashSet<TreeNode> _selectedNodes = new HashSet<TreeNode>();
        private TreeNode _selectionAnchorNode = null;
        private bool _suppressTreeSelectSync = false;

        // 표시 변경 처리 중 들어온 사용자 체크는 마지막 1건만 보류했다가 이어서 반영합니다.
        private bool _hasPendingVisibilityRequest = false;
        private TreeNode _pendingVisibilityNode = null;
        private bool _pendingVisibilityChecked = false;

        public FrmMain()
        {
            InitializeComponent();

            // 노드가 많을 때 트리 깜빡임을 줄입니다.
            EnableDoubleBuffer(treeModel);

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
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("192.168.100.252", 8901);

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

        // 모델이 열리면 트리를 새로 채우고, 닫히면 닫힌 모델의 노드를 들고 있지 않도록 비웁니다.
        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.Model.OnModelOpenedEvent -= Model_OnModelOpenedEvent;
            vizcore3dx.Model.OnModelOpenedEvent += Model_OnModelOpenedEvent;
            vizcore3dx.Model.OnModelClosedEvent -= Model_OnModelClosedEvent;
            vizcore3dx.Model.OnModelClosedEvent += Model_OnModelClosedEvent;
        }

        // 종료 시 이벤트 구독을 먼저 끊습니다. 자식 컨트롤이 정리된 뒤에 이벤트가 오면 안 됩니다.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            vizcore3dx.Model.OnModelOpenedEvent -= Model_OnModelOpenedEvent;
            vizcore3dx.Model.OnModelClosedEvent -= Model_OnModelClosedEvent;

            base.OnFormClosing(e);
        }

        // 열기·추가 모두 이 이벤트가 오므로 최상위 노드부터 다시 채웁니다.
        private void Model_OnModelOpenedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ModelOpendEventArgs e)
        {
            RunOnUi(LoadRootNodes);
        }

        private void Model_OnModelClosedEvent(object sender, EventArgs e)
        {
            RunOnUi(ClearModelTree);
        }
        #endregion

        #region 1. 모델
        // 모델을 엽니다. 트리는 모델 열림 이벤트에서 채웁니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            SetStatus("모델을 열었습니다.");
        }

        // 여러 파일을 골라 현재 모델에 덧붙입니다. 추가용 대화상자가 없으므로 파일 대화상자를 씁니다.
        private void btnAddModel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = vizcore3dx.Model.OpenFilter;
                dialog.Multiselect = true;
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                vizcore3dx.Model.Add(dialog.FileNames);
                SetStatus(string.Format("모델 {0}개를 추가했습니다.", dialog.FileNames.Length));
            }
        }

        // 모델을 닫습니다. 트리·검색 결과는 모델 닫힘 이벤트에서 비웁니다.
        private void btnCloseModel_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            vizcore3dx.Model.Close();
            SetStatus("모델을 닫았습니다.");
        }
        #endregion

        #region 2. 모델 트리
        // 펼칠 때 처음으로 자식 노드를 불러옵니다(지연 로딩).
        private void treeModel_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (!HasDummyChild(e.Node)) return;

            treeModel.BeginUpdate();
            try
            {
                e.Node.Nodes.Clear();

                VIZCore3DX.NET.Data.Node parent = e.Node.Tag as VIZCore3DX.NET.Data.Node;
                if (parent == null) return;

                e.Node.Nodes.AddRange(CreateChildNodes(parent, e.Node.Checked));
            }
            finally
            {
                treeModel.EndUpdate();
            }
        }

        // 키보드 등으로 포커스 노드가 바뀌면 이전 노드의 선택을 뷰어에서도 해제합니다.
        private void treeModel_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (_suppressTreeSelectSync) return;

            TreeNode oldNode = treeModel.SelectedNode;
            if (oldNode == null || !_selectedNodes.Contains(oldNode)) return;

            SetNodeSelection(oldNode, false);
        }

        // 새 포커스 노드를 뷰어에서도 선택합니다.
        private void treeModel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_suppressTreeSelectSync) return;

            TreeNode newNode = e.Node;
            if (newNode == null || _selectedNodes.Contains(newNode)) return;

            SetNodeSelection(newNode, true);
            _selectionAnchorNode = newNode;
        }

        // 클릭 = 단일 선택, Ctrl = 토글, Shift = 같은 부모 안의 범위 선택입니다. 체크박스 클릭은 표시 변경으로 넘깁니다.
        private void treeModel_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null || e.Node.Text == DUMMY_NODE_KEY) return;

            TreeViewHitTestInfo hitInfo = treeModel.HitTest(e.Location);
            if ((hitInfo.Location & TreeViewHitTestLocations.StateImage) == TreeViewHitTestLocations.StateImage) return;

            bool isCtrl = (ModifierKeys & Keys.Control) == Keys.Control;
            bool isShift = (ModifierKeys & Keys.Shift) == Keys.Shift;

            if (isShift && _selectionAnchorNode != null && IsSameSiblingGroup(_selectionAnchorNode, e.Node))
                ApplyRangeSelection(e.Node);
            else if (isCtrl)
                ApplyToggleSelection(e.Node);
            else
                ApplySingleSelection(e.Node);

            SetStatus(string.Format("선택 : {0}개", _selectedNodes.Count));
        }

        // 트리의 빈 영역을 클릭하면 선택을 모두 해제합니다.
        private void treeModel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            TreeViewHitTestInfo hitInfo = treeModel.HitTest(e.Location);
            if (hitInfo.Node != null || hitInfo.Location != TreeViewHitTestLocations.None) return;

            ExecuteSelectionBatch(() =>
            {
                ClearSelectedNodes();
                _selectionAnchorNode = null;
                SetCurrentSelectedNode(null);
            });
            SetStatus("선택을 해제했습니다.");
        }

        // 체크 = 표시입니다. 처리 중에 들어온 사용자 체크는 마지막 1건만 보류했다가 이어서 반영합니다.
        private void treeModel_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Text == DUMMY_NODE_KEY) return;

            if (_isUpdatingUI)
            {
                if (e.Action != TreeViewAction.Unknown) QueuePendingVisibility(e.Node);
                return;
            }

            TreeNode uiNode = e.Node;
            bool visible = uiNode.Checked;
            do
            {
                ApplyVisibilityChange(uiNode, visible);
            }
            while (TakePendingVisibility(out uiNode, out visible));

            SetStatus(string.Format("{0} : {1}", e.Node.Checked ? "표시" : "숨김", e.Node.Text));
        }
        #endregion

        #region 3. 검색
        // 이름으로 노드를 빠르게 찾아 결과 표에 채웁니다.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                SetStatus("검색어를 입력하세요.");
                return;
            }

            List<VIZCore3DX.NET.Data.Node> foundNodes = vizcore3dx.Object3D.Find.QuickSearch(txtSearch.Text, false);
            FillSearchResults(foundNodes);
            SetStatus(string.Format("검색 결과 : {0}개", dgvResults.Rows.Count));
        }

        // 결과 행을 클릭하면 그 노드만 보이고 선택한 뒤, 트리를 경로대로 펼쳐 같은 노드를 보여 줍니다.
        private void dgvResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            VIZCore3DX.NET.Data.Node targetNode = dgvResults.Rows[e.RowIndex].Tag as VIZCore3DX.NET.Data.Node;
            if (targetNode == null) return;

            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.Object3D.ShowSelection(targetNode);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            UncheckAllLoadedNodesSilently();
            DrillDownAndShowInTree(targetNode);
            SetStatus("검색 노드 : " + targetNode.NodeName);
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

        // 원격 데스크톱에서는 더블 버퍼링이 오히려 느리므로 켜지 않습니다.
        private static void EnableDoubleBuffer(Control control)
        {
            if (SystemInformation.TerminalServerSession) return;

            System.Reflection.PropertyInfo property = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (property != null) property.SetValue(control, true, null);
        }

        // ---- 트리 채우기 ----

        // 최상위 노드만 채우고, 자식은 펼칠 때 불러옵니다.
        private void LoadRootNodes()
        {
            treeModel.BeginUpdate();
            try
            {
                ResetTreeState();
                treeModel.Nodes.Clear();

                List<TreeNode> buffer = new List<TreeNode>();
                foreach (VIZCore3DX.NET.Data.Node node in vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.ROOT))
                    buffer.Add(CreateTreeNode(node));

                treeModel.Nodes.AddRange(buffer.ToArray());
            }
            finally
            {
                treeModel.EndUpdate();
            }

            SetStatus(string.Format("최상위 노드 {0}개를 불러왔습니다.", treeModel.Nodes.Count));
        }

        // 모델이 닫히면 선택 상태·트리·검색 결과를 모두 비웁니다.
        private void ClearModelTree()
        {
            ResetTreeState();
            treeModel.Nodes.Clear();
            dgvResults.Rows.Clear();
            SetStatus("모델이 닫혔습니다.");
        }

        private void ResetTreeState()
        {
            _selectedNodes.Clear();
            _selectionAnchorNode = null;
            _pendingVisibilityNode = null;
            _hasPendingVisibilityRequest = false;
        }

        // 노드 이름(없으면 번호)을 텍스트로, 표시 상태를 체크로 씁니다. 자식이 있으면 임시 노드로 '+' 를 띄웁니다.
        private TreeNode CreateTreeNode(VIZCore3DX.NET.Data.Node dataNode)
        {
            string displayText = !string.IsNullOrEmpty(dataNode.NodeName) ? dataNode.NodeName : "Node " + dataNode.Index.ToString();

            TreeNode treeNode = new TreeNode(displayText);
            treeNode.Tag = dataNode;
            treeNode.Checked = dataNode.Visible;

            if (dataNode.ChildCount > 0) treeNode.Nodes.Add(DUMMY_NODE_KEY);

            return treeNode;
        }

        // 바로 아래 자식만 이름순으로 만듭니다. 부모가 꺼져 있으면 자식도 꺼진 상태로 둡니다.
        private TreeNode[] CreateChildNodes(VIZCore3DX.NET.Data.Node parent, bool parentChecked)
        {
            List<VIZCore3DX.NET.Data.Node> children = vizcore3dx.Object3D.GetChildObject3d(parent, VIZCore3DX.NET.Data.Object3DChildOption.CHILD_ONLY);
            children.Sort((x, y) => string.Compare(x?.NodeName, y?.NodeName, StringComparison.OrdinalIgnoreCase));

            List<TreeNode> buffer = new List<TreeNode>(children.Count);
            foreach (VIZCore3DX.NET.Data.Node child in children)
            {
                TreeNode childNode = CreateTreeNode(child);
                if (!parentChecked) childNode.Checked = false;
                buffer.Add(childNode);
            }
            return buffer.ToArray();
        }

        private static bool HasDummyChild(TreeNode node)
        {
            return node.Nodes.Count == 1 && node.Nodes[0].Text == DUMMY_NODE_KEY;
        }

        // ---- 다중 선택 ----

        // 기존 선택을 지우고 이 노드만 선택합니다.
        private void ApplySingleSelection(TreeNode node)
        {
            ExecuteSelectionBatch(() =>
            {
                ClearSelectedNodes();
                SetNodeSelection(node, true);
                SetCurrentSelectedNode(node);
                _selectionAnchorNode = node;
            });
        }

        // Ctrl 클릭: 이 노드의 선택만 뒤집고 기준 노드로 삼습니다.
        private void ApplyToggleSelection(TreeNode node)
        {
            ExecuteSelectionBatch(() =>
            {
                SetNodeSelection(node, !_selectedNodes.Contains(node));
                SetCurrentSelectedNode(node);
                _selectionAnchorNode = node;
            });
        }

        // Shift 클릭: 기준 노드부터 이 노드까지 형제 범위를 같은 상태로 맞춥니다.
        private void ApplyRangeSelection(TreeNode node)
        {
            ExecuteSelectionBatch(() =>
            {
                bool nextState = !_selectedNodes.Contains(node);
                foreach (TreeNode sibling in GetSiblingRange(_selectionAnchorNode, node))
                    SetNodeSelection(sibling, nextState);
                SetCurrentSelectedNode(node);
            });
        }

        private void ClearSelectedNodes()
        {
            foreach (TreeNode node in new List<TreeNode>(_selectedNodes))
                SetNodeSelection(node, false);
        }

        // 트리 선택 표시와 뷰어 선택 상태를 함께 바꿉니다.
        private void SetNodeSelection(TreeNode node, bool isSelected)
        {
            if (node == null || node.Text == DUMMY_NODE_KEY) return;

            if (_selectedNodes.Contains(node) == isSelected)
            {
                UpdateNodeSelectionVisual(node, isSelected);
                return;
            }

            VIZCore3DX.NET.Data.Node dataNode = node.Tag as VIZCore3DX.NET.Data.Node;
            if (dataNode == null) return;

            vizcore3dx.Object3D.Select(dataNode, isSelected);
            if (isSelected) _selectedNodes.Add(node);
            else _selectedNodes.Remove(node);

            UpdateNodeSelectionVisual(node, isSelected);
        }

        // 여러 노드의 선택을 바꿀 때 트리·뷰를 한 번만 다시 그립니다.
        private void ExecuteSelectionBatch(Action action)
        {
            treeModel.BeginUpdate();
            vizcore3dx.BeginUpdate();
            try
            {
                action();
            }
            finally
            {
                vizcore3dx.EndUpdate();
                treeModel.EndUpdate();
            }
        }

        // 포커스 노드만 옮기고 선택 동기 이벤트는 건너뜁니다.
        private void SetCurrentSelectedNode(TreeNode node)
        {
            _suppressTreeSelectSync = true;
            try
            {
                treeModel.SelectedNode = node;
            }
            finally
            {
                _suppressTreeSelectSync = false;
            }
        }

        private static bool IsSameSiblingGroup(TreeNode a, TreeNode b)
        {
            if (a == null || b == null) return false;
            return a.Parent == b.Parent;
        }

        // 같은 부모 아래에서 시작~끝 노드 범위를 돌려줍니다.
        private IEnumerable<TreeNode> GetSiblingRange(TreeNode startNode, TreeNode endNode)
        {
            TreeNodeCollection collection = (startNode.Parent == null) ? treeModel.Nodes : startNode.Parent.Nodes;
            int startIndex = collection.IndexOf(startNode);
            int endIndex = collection.IndexOf(endNode);
            if (startIndex < 0 || endIndex < 0) yield break;

            int from = Math.Min(startIndex, endIndex);
            int to = Math.Max(startIndex, endIndex);
            for (int i = from; i <= to; i++)
            {
                if (collection[i].Text == DUMMY_NODE_KEY) continue;
                yield return collection[i];
            }
        }

        // 다중 선택은 트리 기본 선택 표시가 하나뿐이므로 배경색으로 표시합니다.
        private void UpdateNodeSelectionVisual(TreeNode node, bool isSelected)
        {
            node.BackColor = isSelected ? SystemColors.Highlight : treeModel.BackColor;
            node.ForeColor = isSelected ? SystemColors.HighlightText : treeModel.ForeColor;
        }

        // ---- 체크 = 표시 ----

        private void QueuePendingVisibility(TreeNode node)
        {
            _pendingVisibilityNode = node;
            _pendingVisibilityChecked = node.Checked;
            _hasPendingVisibilityRequest = true;
        }

        // 보류된 요청이 있으면 꺼내고 지웁니다.
        private bool TakePendingVisibility(out TreeNode node, out bool visible)
        {
            node = _pendingVisibilityNode;
            visible = _pendingVisibilityChecked;
            if (!_hasPendingVisibilityRequest || node == null) return false;

            _pendingVisibilityNode = null;
            _hasPendingVisibilityRequest = false;
            return true;
        }

        // 체크한 노드가 선택에 포함돼 있으면 선택 노드 전체에 같은 표시 상태를 적용합니다.
        private void ApplyVisibilityChange(TreeNode uiNode, bool isVisible)
        {
            if (!(uiNode.Tag is VIZCore3DX.NET.Data.Node)) return;

            _isUpdatingUI = true;
            vizcore3dx.BeginUpdate();
            try
            {
                foreach (TreeNode target in GetVisibilityTargets(uiNode))
                    ApplyVisibilityToTarget(target, uiNode, isVisible);
            }
            finally
            {
                vizcore3dx.EndUpdate();
                _isUpdatingUI = false;
            }
        }

        // 한 노드를 보이거나 숨기고, 불러온 자식·부모의 체크를 맞춥니다.
        private void ApplyVisibilityToTarget(TreeNode target, TreeNode clickedNode, bool isVisible)
        {
            VIZCore3DX.NET.Data.Node targetData = target.Tag as VIZCore3DX.NET.Data.Node;
            if (targetData == null) return;

            if (target != clickedNode && target.Checked != isVisible) target.Checked = isVisible;

            vizcore3dx.Object3D.Show(targetData, isVisible);
            ReflectVisibilityToChildren(target, isVisible);
            UpdateParentCheckState(target);
        }

        private List<TreeNode> GetVisibilityTargets(TreeNode clickedNode)
        {
            if (!_selectedNodes.Contains(clickedNode)) return new List<TreeNode> { clickedNode };

            List<TreeNode> targets = _selectedNodes.Where(node => node != null && node.TreeView == treeModel && node.Text != DUMMY_NODE_KEY).ToList();
            if (targets.Count == 0) targets.Add(clickedNode);
            return targets;
        }

        // 펼쳐서 불러온 자식 노드들의 체크를 부모와 같게 맞춥니다.
        private void ReflectVisibilityToChildren(TreeNode parentNode, bool isVisible)
        {
            foreach (TreeNode child in parentNode.Nodes)
            {
                if (child.Text == DUMMY_NODE_KEY) continue;

                if (child.Checked != isVisible) child.Checked = isVisible;

                if (child.Nodes.Count > 0 && child.IsExpanded) ReflectVisibilityToChildren(child, isVisible);
            }
        }

        // 형제가 모두 체크돼 있을 때만 부모를 체크하도록 최상위까지 거슬러 올라갑니다.
        private void UpdateParentCheckState(TreeNode node)
        {
            for (TreeNode parent = node.Parent; parent != null; parent = parent.Parent)
            {
                bool allChildrenChecked = true;
                foreach (TreeNode child in parent.Nodes)
                {
                    if (child.Text == DUMMY_NODE_KEY) continue;
                    if (!child.Checked) { allChildrenChecked = false; break; }
                }

                if (parent.Checked != allChildrenChecked) parent.Checked = allChildrenChecked;
            }
        }

        // ---- 검색 결과 → 트리 ----

        private void FillSearchResults(List<VIZCore3DX.NET.Data.Node> foundNodes)
        {
            dgvResults.SuspendLayout();
            dgvResults.Rows.Clear();

            if (foundNodes != null)
            {
                foreach (VIZCore3DX.NET.Data.Node node in foundNodes)
                {
                    int rowIndex = dgvResults.Rows.Add(node.NodeName, node.NodePath);
                    dgvResults.Rows[rowIndex].Tag = node;
                }
            }

            dgvResults.ResumeLayout();
        }

        // 결과 노드만 보이게 했으므로, 불러온 트리 노드의 체크를 뷰어에 되돌리지 않고 모두 끕니다.
        private void UncheckAllLoadedNodesSilently()
        {
            _isUpdatingUI = true;
            try
            {
                UncheckAllLoadedNodes(treeModel.Nodes);
            }
            finally
            {
                _isUpdatingUI = false;
            }
        }

        private void UncheckAllLoadedNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text == DUMMY_NODE_KEY) continue;

                if (node.Checked) node.Checked = false;

                if (node.Nodes.Count > 0 && node.IsExpanded) UncheckAllLoadedNodes(node.Nodes);
            }
        }

        // 노드 경로를 따라 트리를 펼치고, 마지막 노드를 선택·체크해 보여 줍니다.
        private void DrillDownAndShowInTree(VIZCore3DX.NET.Data.Node targetNode)
        {
            if (treeModel.Nodes.Count == 0) return;

            string[] segments = SplitNodePath(targetNode);

            treeModel.BeginUpdate();
            try
            {
                TreeNode found = ExpandAlongPath(segments);
                if (found != null) RevealTreeNode(found);
            }
            finally
            {
                treeModel.EndUpdate();
            }
        }

        private static string[] SplitNodePath(VIZCore3DX.NET.Data.Node targetNode)
        {
            string pathString = targetNode.NodePath;
            if (string.IsNullOrEmpty(pathString)) pathString = targetNode.NodeName;

            return pathString.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
        }

        // 경로 조각 중 최상위 트리 노드와 처음 일치하는 위치를 찾습니다(없으면 0).
        private int FindPathStart(string[] segments)
        {
            for (int i = 0; i < segments.Length; i++)
                if (FindNodeByName(treeModel.Nodes, segments[i].Trim()) != null) return i;

            return 0;
        }

        // 경로 조각을 따라 내려가며 중간 노드를 펼칩니다. 이름이 끊기면 거기서 멈춥니다.
        private TreeNode ExpandAlongPath(string[] segments)
        {
            TreeNode currentNode = null;
            TreeNodeCollection collection = treeModel.Nodes;

            for (int i = FindPathStart(segments); i < segments.Length; i++)
            {
                TreeNode foundNode = FindNodeByName(collection, segments[i].Trim());
                if (foundNode == null) break;

                currentNode = foundNode;
                if (i == segments.Length - 1) break;

                if (!foundNode.IsExpanded || HasDummyChild(foundNode)) foundNode.Expand();
                collection = foundNode.Nodes;
            }
            return currentNode;
        }

        // 찾은 노드를 선택하고 스크롤해 보이게 한 뒤, 체크를 켜고 위아래 체크를 맞춥니다.
        private void RevealTreeNode(TreeNode node)
        {
            treeModel.SelectedNode = node;
            node.EnsureVisible();

            _isUpdatingUI = true;
            try
            {
                node.Checked = true;
                ReflectVisibilityToChildren(node, true);
                UpdateParentCheckState(node);
            }
            finally
            {
                _isUpdatingUI = false;
            }

            treeModel.Focus();
        }

        // 노드 이름이 같은 항목을 찾고, 없으면 트리 텍스트로 비교합니다.
        private static TreeNode FindNodeByName(TreeNodeCollection collection, string targetName)
        {
            foreach (TreeNode node in collection)
            {
                VIZCore3DX.NET.Data.Node nodeData = node.Tag as VIZCore3DX.NET.Data.Node;
                if (nodeData != null && nodeData.NodeName == targetName) return node;
                if (node.Text == targetName) return node;
            }
            return null;
        }
        #endregion
    }
}
