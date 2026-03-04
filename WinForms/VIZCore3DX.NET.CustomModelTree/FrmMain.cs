using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using static VIZCore3DX.NET.Event.EventManager;

namespace VIZCore3DX.NET.CustomModelTree
{
    public partial class FrmMain : Form
    {
        // 더미 노드 키
        private const string DUMMY_NODE_KEY = "DUMMY_NODE";

        // 무한 루프 방지용 (UI 변경 이벤트가 다시 코드를 호출하는 것 방지)
        private bool _isUpdatingUI = false;

        private TreeView _customModelTree;
        private readonly HashSet<TreeNode> _selectedNodes = new HashSet<TreeNode>();
        private TreeNode _selectionAnchorNode = null;
        private bool _suppressTreeSelectSync = false;
        private bool _hasPendingVisibilityRequest = false;
        private TreeNode _pendingVisibilityNode = null;
        private bool _pendingVisibilityChecked = false;

        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        public FrmMain()
        {
            InitializeComponent();
            InitializeVIZCore3DXControl();
        }

        private void InitializeVIZCore3DXControl()
        {
            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
            vizcore3dx.Model.OnModelOpenedEvent += VIZCore3DX_OnModelOpenedEvent;

            splitContainer1.Panel2.Controls.Add(vizcore3dx);
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("192.168.100.252", 8901);

            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            vizcore3dx.BeginUpdate();
            vizcore3dx.ToolbarMain.Visible = true;
            vizcore3dx.ToolbarNote.Visible = false;
            vizcore3dx.ToolbarMeasure.Visible = false;
            vizcore3dx.ToolbarSection.Visible = false;
            vizcore3dx.ToolbarSnapshot.Visible = false;
            vizcore3dx.EndUpdate();
        }

        private void VIZCore3DX_OnModelOpenedEvent(object sender, ModelOpendEventArgs e)
        {
            InitializeCustomModelTree(treePanel);
            LoadRootNode();
        }

        // ====================================================================================
        // Custom Model Tree 생성 및 최적화 설정
        // ====================================================================================
        public void InitializeCustomModelTree(Control targetContainer)
        {
            // 중복 생성 방지
            if (_customModelTree != null) return;

            // 유효한 컨테이너인지 검사
            if (!ValidateContainer(targetContainer))
            {
                MessageBox.Show("Invalid Parent Control.");
                return;
            }

            // 컨트롤 배치 시 불필요한 레이아웃 계산을 일시 중지하여 속도 향상
            targetContainer.SuspendLayout();

            // TreeView Setting
            _customModelTree = new TreeView();
            _customModelTree.Dock = DockStyle.Fill;
            _customModelTree.BorderStyle = BorderStyle.None;
            _customModelTree.ShowLines = true;
            _customModelTree.ShowPlusMinus = true;
            _customModelTree.HideSelection = false;
            _customModelTree.CheckBoxes = true;

            // 대량 노드 렌더링 시 깜빡임(Flicker) 제거를 위한 더블 버퍼링 활성화
            EnableDoubleBuffering(_customModelTree);

            targetContainer.Controls.Add(_customModelTree);
            _customModelTree.BringToFront();

            // 기능별 이벤트 핸들러 연결
            _customModelTree.BeforeExpand += OnNodeExpanding; // 모델 확장 시 로딩
            _customModelTree.BeforeSelect += OnNodeSelecting_Deselect; // 선택 해제 동기화
            _customModelTree.AfterSelect += OnNodeSelected_Select; // 선택 동기화
            _customModelTree.NodeMouseClick += OnNodeMouseClick_MultiSelect; // Ctrl/Shift 멀티 선택
            _customModelTree.MouseDown += OnTreeMouseDown_ClearSelection; // 빈 영역 클릭 시 선택 해제
            _customModelTree.AfterCheck += OnNodeChecked_Visibility; // 체크박스 동기화

            // 레이아웃 계산 재개
            targetContainer.ResumeLayout(false);
        }

        /// <summary>
        /// Root Node 불러오기
        /// </summary>
        public void LoadRootNode()
        {
            if (_customModelTree == null) return;

            _customModelTree.BeginUpdate();
            _selectedNodes.Clear();
            _selectionAnchorNode = null;
            _customModelTree.Nodes.Clear();

            var roots = vizcore3dx.Object3D.FromFilter(Object3dFilter.ROOT);
            List<TreeNode> nodesBuffer = new List<TreeNode>();

            foreach (var node in roots)
            {
                // 불필요한 null 체크 제거 (CreateTreeNode는 항상 객체를 반환함)
                nodesBuffer.Add(CreateTreeNode(node));
            }

            if (nodesBuffer.Count > 0)
            {
                _customModelTree.Nodes.AddRange(nodesBuffer.ToArray());
            }

            _customModelTree.EndUpdate();
        }

        /// <summary>
        /// 노드 생성
        /// </summary>
        /// <param name="dataNode"></param>
        /// <returns></returns>
        private TreeNode CreateTreeNode(Node dataNode)
        {
            string displayText = !string.IsNullOrEmpty(dataNode.NodeName)
                ? dataNode.NodeName
                : "Node " + dataNode.Index.ToString();

            TreeNode customModelTree = new TreeNode(displayText);
            customModelTree.Tag = dataNode; // 트리노드 태그에 데이터 바인딩
            customModelTree.Checked = dataNode.Visible; // 초기 체크 상태 동기화

            // 자식이 있다면 가짜(Dummy) 노드를 넣어 '+' 버튼 활성화
            if (dataNode.ChildCount > 0)
            {
                customModelTree.Nodes.Add(DUMMY_NODE_KEY);
            }

            return customModelTree;
        }

        /// <summary>
        /// 모델 확장 시 로딩 (지연로딩 방법)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNodeExpanding(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode parentNode = e.Node;

            // 더미 노드가 존재한다는 것은 아직 자식 로딩이 안 됐다는 의미
            if (parentNode.Nodes.Count == 1 && parentNode.Nodes[0].Text == DUMMY_NODE_KEY)
            {
                _customModelTree.BeginUpdate(); // 확장 시 깜빡임 방지
                parentNode.Nodes.Clear();       // 더미 삭제

                Node parentData = parentNode.Tag as Node;
                if (parentData == null)
                {
                    _customModelTree.EndUpdate();
                    return;
                }

                // 자식 데이터 가져오기
                List<Node> children = vizcore3dx.Object3D.GetChildObject3d(parentData, Object3DChildOption.CHILD_ONLY);

                children.Sort((x, y) => string.Compare(x?.NodeName, y?.NodeName, StringComparison.OrdinalIgnoreCase));

                List<TreeNode> childNodesBuffer = new List<TreeNode>(children.Count);

                // 부모가 체크 해제 상태라면, 자식도 해제 상태여야 함
                bool isParentUnchecked = (parentNode.Checked == false);

                foreach (var childData in children)
                {
                    TreeNode childNode = CreateTreeNode(childData);

                    if (isParentUnchecked)
                    {
                        childNode.Checked = false;
                    }

                    // 불필요한 null 체크 제거 (CreateTreeNode는 항상 객체를 반환함)
                    childNodesBuffer.Add(childNode);
                }

                // 자식 노드 일괄 추가
                if (childNodesBuffer.Count > 0)
                {
                    parentNode.Nodes.AddRange(childNodesBuffer.ToArray());
                }

                _customModelTree.EndUpdate();
            }
        }

        /// <summary>
        /// 선택 동기화 로직(이전 노드의 선택 해제 처리)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNodeSelecting_Deselect(object sender, TreeViewCancelEventArgs e)
        {
            if (_suppressTreeSelectSync) return;

            TreeNode oldNode = _customModelTree.SelectedNode;
            if (oldNode == null || !_selectedNodes.Contains(oldNode)) return;

            SetNodeSelection(oldNode, false);
        }

        /// <summary>
        /// 새 노드 선택 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNodeSelected_Select(object sender, TreeViewEventArgs e)
        {
            if (_suppressTreeSelectSync) return;

            TreeNode newNode = e.Node;
            if (newNode == null || _selectedNodes.Contains(newNode)) return;

            SetNodeSelection(newNode, true);
            _selectionAnchorNode = newNode;
        }

        /// <summary>
        /// Ctrl/Shift 조합에 따라 트리 노드 멀티 선택을 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNodeMouseClick_MultiSelect(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null || e.Node.Text == DUMMY_NODE_KEY) return;

            TreeViewHitTestInfo hitInfo = _customModelTree.HitTest(e.Location);
            // 체크박스 클릭은 선택 로직이 아니라 가시성 로직으로 처리
            if ((hitInfo.Location & TreeViewHitTestLocations.StateImage) == TreeViewHitTestLocations.StateImage) return;

            bool isCtrl = (ModifierKeys & Keys.Control) == Keys.Control;
            bool isShift = (ModifierKeys & Keys.Shift) == Keys.Shift;

            if (isShift && _selectionAnchorNode != null && IsSameSiblingGroup(_selectionAnchorNode, e.Node))
            {
                ExecuteSelectionBatch(() =>
                {
                    bool nextState = !_selectedNodes.Contains(e.Node);
                    foreach (TreeNode node in GetSiblingRange(_selectionAnchorNode, e.Node))
                    {
                        SetNodeSelection(node, nextState);
                    }
                    SetCurrentSelectedNode(e.Node);
                });
                return;
            }

            if (isCtrl)
            {
                ExecuteSelectionBatch(() =>
                {
                    SetNodeSelection(e.Node, !_selectedNodes.Contains(e.Node));
                    SetCurrentSelectedNode(e.Node);
                    _selectionAnchorNode = e.Node;
                });
                return;
            }

            ApplySingleSelection(e.Node);
        }

        /// <summary>
        /// 트리의 빈 영역을 클릭하면 현재 선택을 모두 해제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeMouseDown_ClearSelection(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            TreeViewHitTestInfo hitInfo = _customModelTree.HitTest(e.Location);
            if (hitInfo.Node != null || hitInfo.Location != TreeViewHitTestLocations.None) return;

            ExecuteSelectionBatch(() =>
            {
                ClearSelectedNodes();
                _selectionAnchorNode = null;

                _suppressTreeSelectSync = true;
                try
                {
                    _customModelTree.SelectedNode = null;
                }
                finally
                {
                    _suppressTreeSelectSync = false;
                }
            });
        }

        /// <summary>
        /// 체크박스 동기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNodeChecked_Visibility(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Text == DUMMY_NODE_KEY) return;

            // 처리 중 발생한 사용자 입력은 마지막 요청 1건만 보류하여 순차 반영
            if (_isUpdatingUI)
            {
                if (e.Action != TreeViewAction.Unknown)
                {
                    _pendingVisibilityNode = e.Node;
                    _pendingVisibilityChecked = e.Node.Checked;
                    _hasPendingVisibilityRequest = true;
                }
                return;
            }

            TreeNode uiNode = e.Node;
            bool visible = uiNode.Checked;
            while (uiNode != null)
            {
                ApplyVisibilityChange(uiNode, visible);

                if (!_hasPendingVisibilityRequest) break;
                uiNode = _pendingVisibilityNode;
                visible = _pendingVisibilityChecked;
                _pendingVisibilityNode = null;
                _hasPendingVisibilityRequest = false;
            }
        }

        private void ApplyVisibilityChange(TreeNode uiNode, bool isVisible)
        {
            Node dataNode = uiNode.Tag as Node;
            if (dataNode == null) return;

            _isUpdatingUI = true;
            vizcore3dx.BeginUpdate();
            try
            {
                List<TreeNode> targets = GetVisibilityTargets(uiNode);
                foreach (TreeNode target in targets)
                {
                    Node targetData = target.Tag as Node;
                    if (targetData == null) continue;

                    if (target != uiNode && target.Checked != isVisible)
                    {
                        target.Checked = isVisible;
                    }

                    vizcore3dx.Object3D.Show(targetData, isVisible);
                    ReflectVisibilityToChildren(target, isVisible);
                    UpdateParentCheckState(target);
                }
            }
            finally
            {
                vizcore3dx.EndUpdate();
                _isUpdatingUI = false;
            }
        }

        /// <summary>
        /// 현재 화면에 로딩된 자식 노드들의 체크 상태를 부모와 동일하게 변경
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="isVisible"></param>
        private void ReflectVisibilityToChildren(TreeNode parentNode, bool isVisible)
        {
            foreach (TreeNode child in parentNode.Nodes)
            {
                if (child.Text == DUMMY_NODE_KEY) continue;

                if (child.Checked != isVisible)
                {
                    child.Checked = isVisible;
                }

                if (child.Nodes.Count > 0 && child.IsExpanded)
                {
                    ReflectVisibilityToChildren(child, isVisible);
                }
            }
        }

        /// <summary>
        /// 자식 노드들의 상태를 취합하여 부모 노드의 체크 상태를 갱신 (역방향 동기화)
        /// </summary>
        /// <param name="node"></param>
        private void UpdateParentCheckState(TreeNode node)
        {
            TreeNode parent = node.Parent;

            // 최상위 루트 노드까지 계속 타고 올라감
            while (parent != null)
            {
                bool allChildrenChecked = true;

                // 형제 노드들 검사
                foreach (TreeNode child in parent.Nodes)
                {
                    if (child.Text == DUMMY_NODE_KEY) continue; // 더미는 무시

                    if (!child.Checked)
                    {
                        allChildrenChecked = false;
                        break;
                    }
                }

                // 부모의 UI 상태가 바뀌어야 한다면 갱신
                if (parent.Checked != allChildrenChecked)
                {
                    parent.Checked = allChildrenChecked;
                }

                parent = parent.Parent; // 한 단계 위로
            }
        }

        /// <summary>
        /// 단일 선택 모드로 전환 (기존 선택 해제 후 현재 노드만 선택)
        /// </summary>
        /// <param name="node"></param>
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

        /// <summary>
        /// 현재 멀티 선택된 노드들을 모두 해제
        /// </summary>
        private void ClearSelectedNodes()
        {
            foreach (TreeNode node in new List<TreeNode>(_selectedNodes))
            {
                SetNodeSelection(node, false);
            }
        }

        /// <summary>
        /// 트리 선택 상태와 3D 선택 상태를 동기화
        /// </summary>
        /// <param name="node"></param>
        /// <param name="isSelected"></param>
        private void SetNodeSelection(TreeNode node, bool isSelected)
        {
            if (node == null || node.Text == DUMMY_NODE_KEY) return;
            bool alreadySelected = _selectedNodes.Contains(node);
            if (alreadySelected == isSelected)
            {
                UpdateNodeSelectionVisual(node, isSelected);
                return;
            }

            Node dataNode = node.Tag as Node;
            if (dataNode == null) return;

            vizcore3dx.Object3D.Select(dataNode, isSelected);
            if (isSelected)
            {
                _selectedNodes.Add(node);
            }
            else
            {
                _selectedNodes.Remove(node);
            }

            UpdateNodeSelectionVisual(node, isSelected);
        }

        /// <summary>
        /// 여러개의 노드 선택 변경 시 트리/뷰어 갱신을 배치 처리
        /// </summary>
        /// <param name="action"></param>
        private void ExecuteSelectionBatch(Action action)
        {
            if (action == null) return;

            _customModelTree.BeginUpdate();
            vizcore3dx.BeginUpdate();
            try
            {
                action();
            }
            finally
            {
                vizcore3dx.EndUpdate();
                _customModelTree.EndUpdate();
            }
        }

        /// <summary>
        /// TreeView의 현재 포커스 노드를 안전하게 갱신
        /// </summary>
        /// <param name="node"></param>
        private void SetCurrentSelectedNode(TreeNode node)
        {
            _suppressTreeSelectSync = true;
            try
            {
                _customModelTree.SelectedNode = node;
            }
            finally
            {
                _suppressTreeSelectSync = false;
            }
        }

        /// <summary>
        /// 두 노드가 같은 부모(형제 그룹)인지 판별
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool IsSameSiblingGroup(TreeNode a, TreeNode b)
        {
            if (a == null || b == null) return false;
            return a.Parent == b.Parent;
        }

        /// <summary>
        /// 같은 형제 그룹에서 시작~끝 노드 범위를 반환
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="endNode"></param>
        /// <returns></returns>
        private IEnumerable<TreeNode> GetSiblingRange(TreeNode startNode, TreeNode endNode)
        {
            TreeNodeCollection collection = (startNode.Parent == null) ? _customModelTree.Nodes : startNode.Parent.Nodes;
            int startIndex = collection.IndexOf(startNode);
            int endIndex = collection.IndexOf(endNode);

            if (startIndex < 0 || endIndex < 0) yield break;
            if (startIndex > endIndex)
            {
                int temp = startIndex;
                startIndex = endIndex;
                endIndex = temp;
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                TreeNode node = collection[i];
                if (node.Text == DUMMY_NODE_KEY) continue;
                yield return node;
            }
        }

        /// <summary>
        /// 멀티 선택 상태를 트리 UI 색상으로 표시
        /// </summary>
        /// <param name="node"></param>
        /// <param name="isSelected"></param>
        private void UpdateNodeSelectionVisual(TreeNode node, bool isSelected)
        {
            if (node == null) return;

            node.BackColor = isSelected ? System.Drawing.SystemColors.Highlight : _customModelTree.BackColor;
            node.ForeColor = isSelected ? System.Drawing.SystemColors.HighlightText : _customModelTree.ForeColor;
        }

        /// <summary>
        /// 체크박스 클릭 시 가시성 적용 대상 노드 집합을 계산
        /// </summary>
        /// <param name="clickedNode"></param>
        /// <returns></returns>
        private List<TreeNode> GetVisibilityTargets(TreeNode clickedNode)
        {
            if (_selectedNodes.Count == 0 || !_selectedNodes.Contains(clickedNode))
            {
                return new List<TreeNode> { clickedNode };
            }

            List<TreeNode> targets = new List<TreeNode>(_selectedNodes.Count);
            foreach (TreeNode node in _selectedNodes)
            {
                if (node == null || node.TreeView != _customModelTree) continue;
                if (node.Text == DUMMY_NODE_KEY) continue;
                targets.Add(node);
            }

            if (targets.Count == 0)
            {
                targets.Add(clickedNode);
            }

            return targets;
        }

        /// <summary>
        /// 컨트롤이 패널종류인지 유효성 검사
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        private bool ValidateContainer(Control ctrl)
        {
            if (ctrl == null || ctrl.IsDisposed) return false;

            return (ctrl is Panel ||
                    ctrl is SplitterPanel ||
                    ctrl is GroupBox ||
                    ctrl is TabPage ||
                    ctrl is UserControl);
        }

        private void EnableDoubleBuffering(Control control)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession) return;

            PropertyInfo aProp = typeof(Control).GetProperty("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance);

            if (aProp != null)
            {
                aProp.SetValue(control, true, null);
            }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNode.Text))
            {
                MessageBox.Show("검색어를 입력하세요.");
                return;
            }

            List<Node> foundNodes = vizcore3dx.Object3D.Find.QuickSearch(tbNode.Text, false);

            if (foundNodes.Count == 0)
            {
                return;
            }
            else
            {
                nodeGridView.SuspendLayout();
                nodeGridView.Rows.Clear();

                foreach (Node node in foundNodes)
                {
                    int rowIndex = nodeGridView.Rows.Add(node.NodeName, node.NodePath);

                    nodeGridView.Rows[rowIndex].Tag = node;
                }

                nodeGridView.ResumeLayout();
            }
        }

        private void nodeGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Node targetNode = nodeGridView.Rows[e.RowIndex].Tag as Node;

            if (targetNode == null) return;

            vizcore3dx.BeginUpdate();
            vizcore3dx.Object3D.ShowSelection(targetNode);
            vizcore3dx.EndUpdate();

            _isUpdatingUI = true;
            try
            {
                UncheckAllLoadedNodes(_customModelTree.Nodes);
            }
            finally
            {
                _isUpdatingUI = false;
            }

            DrillDownAndShowInTree(targetNode);
        }

        /// <summary>
        /// 경로를 따라 트리뷰를 확장하고, 최종 노드를 선택 및 체크함
        /// </summary>
        /// <param name="targetNode"></param>
        private void DrillDownAndShowInTree(Node targetNode)
        {
            if (_customModelTree.Nodes.Count == 0) return;

            string pathString = targetNode.NodePath;
            if (string.IsNullOrEmpty(pathString)) pathString = targetNode.NodeName;

            string[] pathSegments = pathString.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

            TreeNode currentNode = null;
            TreeNodeCollection currentCollection = _customModelTree.Nodes;

            _customModelTree.BeginUpdate();

            try
            {
                int startIndex = 0;
                for (int i = 0; i < pathSegments.Length; i++)
                {
                    if (FindNodeByName(currentCollection, pathSegments[i].Trim()) != null)
                    {
                        startIndex = i;
                        break;
                    }
                }

                // 일치하는 시작점부터 트리를 타고 내려감 (Drill-Down)
                for (int i = startIndex; i < pathSegments.Length; i++)
                {
                    string segmentName = pathSegments[i].Trim();
                    TreeNode foundNode = FindNodeByName(currentCollection, segmentName);

                    if (foundNode != null)
                    {
                        currentNode = foundNode;

                        // 마지막 타겟 노드가 아니면 자식을 강제로 펼침
                        if (i < pathSegments.Length - 1)
                        {
                            if (!foundNode.IsExpanded || (foundNode.Nodes.Count == 1 && foundNode.Nodes[0].Text == DUMMY_NODE_KEY))
                            {
                                foundNode.Expand();
                            }
                            // 다음 뎁스 탐색을 위해 컬렉션 갱신
                            currentCollection = foundNode.Nodes;
                        }
                    }
                    else
                    {
                        // 중간에 이름이 달라 경로가 끊긴 경우 탐색 중단
                        break;
                    }
                }

                // 최종 타겟(currentNode) UI 동기화 처리
                if (currentNode != null)
                {
                    // 트리에서 선택 (파란색 하이라이트) 및 스크롤 이동
                    _customModelTree.SelectedNode = currentNode;
                    currentNode.EnsureVisible();

                    _isUpdatingUI = true;
                    try
                    {
                        // UI 체크박스 켜기
                        currentNode.Checked = true;

                        // 위아래 트리 UI 연동 (검색으로 켰을 때도 완벽하게 부모/자식 체크박스 갱신)
                        ReflectVisibilityToChildren(currentNode, true);
                        UpdateParentCheckState(currentNode);
                    }
                    finally
                    {
                        _isUpdatingUI = false;
                    }

                    _customModelTree.Focus(); // 트리에 포커스를 줘야 파란색 선택 줄이 잘 보임
                }
            }
            finally
            {
                _customModelTree.EndUpdate();
            }
        }

        /// <summary>
        /// 컬렉션 내에서 NodeName(또는 Text)이 일치하는 노드 찾기
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="targetName"></param>
        /// <returns></returns>
        private TreeNode FindNodeByName(TreeNodeCollection collection, string targetName)
        {
            foreach (TreeNode node in collection)
            {
                Node nodeData = node.Tag as Node;
                // Tag의 NodeName 비교가 가장 정확함
                if (nodeData != null && nodeData.NodeName == targetName)
                {
                    return node;
                }
                // 차선책으로 UI 텍스트 비교
                if (node.Text == targetName)
                {
                    return node;
                }
            }
            return null;
        }

        /// <summary>
        /// 현재 화면에 로딩된 모든 트리 노드의 체크를 해제합니다. (UI만 동기화)
        /// </summary>
        private void UncheckAllLoadedNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text == DUMMY_NODE_KEY) continue;

                if (node.Checked)
                {
                    node.Checked = false;
                }

                // 펼쳐져 있는(로딩된) 자식들도 재귀적으로 모두 해제
                if (node.Nodes.Count > 0 && node.IsExpanded)
                {
                    UncheckAllLoadedNodes(node.Nodes);
                }
            }
        }
    }
}

