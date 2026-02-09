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
            TreeNode oldNode = _customModelTree.SelectedNode;
            if (oldNode != null)
            {
                Node dataNode = oldNode.Tag as Node;
                if (dataNode != null)
                {
                    vizcore3dx.Object3D.Select(dataNode, false);
                }
            }
        }

        /// <summary>
        /// 새 노드 선택 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNodeSelected_Select(object sender, TreeViewEventArgs e)
        {
            TreeNode newNode = e.Node;
            if (newNode != null)
            {
                Node dataNode = newNode.Tag as Node;
                if (dataNode != null)
                {
                    vizcore3dx.Object3D.Select(dataNode, true);
                }
            }
        }

        /// <summary>
        /// 체크박스 동기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNodeChecked_Visibility(object sender, TreeViewEventArgs e)
        {
            // 코드 내부에서 변경한 경우 무한 루프 방지를 위해 이벤트 무시
            if (_isUpdatingUI) return;

            TreeNode uiNode = e.Node;
            Node dataNode = uiNode.Tag as Node;

            if (dataNode == null) return;

            _isUpdatingUI = true;

            // 모델 갱신과 UI 갱신이 동시에 일어날 때 3D 뷰어 렌더링을 잠시 멈춤(결과만 렌더링)
            vizcore3dx.BeginUpdate();
            try
            {
                // 사용자 뷰 상의 Node Visible 설정
                vizcore3dx.Object3D.Show(dataNode, uiNode.Checked);

                // 하위 노드들의 체크박스 UI 동기화 (확장된 노드만)
                ReflectVisibilityToChildren(uiNode, uiNode.Checked);
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

                child.Checked = isVisible;

                if (child.Nodes.Count > 0 && child.IsExpanded)
                {
                    ReflectVisibilityToChildren(child, isVisible);
                }
            }
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
    }
}