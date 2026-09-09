using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.GroupExplode
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

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
            vizcore3dx.Object3D.Group.EnableGroupSelection(chkGroupSelection.Checked);

            UpdateGroupSelectionUI();
            UpdateExplodeModeUI();
            RefreshGroupTree(null);
            UpdateExplodeStatus();
        }

        #region Model

        private void BtnOpenModel_Click(object sender, EventArgs e)
        {
            RestoreExplode();

            vizcore3dx.Object3D.Group.ClearGroup();
            vizcore3dx.Model.OpenFileDialog();

            txtGroupName.Text = "Group 1";

            RefreshGroupTree(null);
            UpdateExplodeStatus();
        }

        #endregion

        #region Group

        private void BtnAddRootGroup_Click(object sender, EventArgs e)
        {
            string name = txtGroupName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("그룹 이름을 입력하세요.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsDuplicateGroupName(name) == true)
            {
                MessageBox.Show("같은 이름의 그룹이 이미 존재합니다.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            VIZCore3DX.NET.Data.GroupItem group = vizcore3dx.Object3D.Group.CreateGroup(name);

            if (group == null)
            {
                MessageBox.Show("그룹을 생성하지 못했습니다.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtGroupName.Text = GetNextGroupName();

            RefreshGroupTree(group);
        }

        private void BtnAddChildGroup_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.GroupItem parentGroup = GetSelectedTreeGroup();

            if (parentGroup == null)
            {
                MessageBox.Show("하위 그룹을 추가할 부모 그룹을 선택하세요.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string name = txtGroupName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("그룹 이름을 입력하세요.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsDuplicateGroupName(name) == true)
            {
                MessageBox.Show("같은 이름의 그룹이 이미 존재합니다.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            VIZCore3DX.NET.Data.GroupItem childGroup = vizcore3dx.Object3D.Group.CreateChildGroup(parentGroup, name);

            if (childGroup == null)
            {
                MessageBox.Show("하위 그룹을 생성하지 못했습니다.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtGroupName.Text = GetNextGroupName();

            RefreshGroupTree(childGroup);
        }

        private void BtnAddSelectedNodes_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.GroupItem targetGroup = GetSelectedTreeGroup();

            if (targetGroup == null)
            {
                MessageBox.Show("Node를 추가할 그룹을 선택하세요.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> selectedNodes = vizcore3dx.Object3D.GetSelectedObjects().OfType<VIZCore3DX.NET.Data.Node>().ToList();

            if (selectedNodes.Count == 0)
            {
                MessageBox.Show("모델에서 추가할 Node를 선택하세요.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> addNodes = new List<VIZCore3DX.NET.Data.Node>();
            foreach (VIZCore3DX.NET.Data.Node node in selectedNodes)
            {
                if (node == null) continue;

                VIZCore3DX.NET.Data.GroupItem currentGroup = vizcore3dx.Object3D.Group.FindContainingGroup(node);

                if (currentGroup != null)
                {
                    continue;
                }

                addNodes.Add(node);
            }

            if (addNodes.Count > 0) vizcore3dx.Object3D.Group.AddNodes(targetGroup, addNodes);

            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            RefreshGroupTree(targetGroup);

        }

        private void BtnRemoveSelectedNodes_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.GroupItem group = GetSelectedTreeGroup();

            if (group == null)
            {
                MessageBox.Show("Node를 제거할 그룹을 선택하세요.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> selectedNodes = vizcore3dx.Object3D.GetSelectedObjects().OfType<VIZCore3DX.NET.Data.Node>().ToList();

            if (selectedNodes.Count == 0)
            {
                MessageBox.Show("모델에서 제거할 Node를 선택하세요.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> removeNodes = new List<VIZCore3DX.NET.Data.Node>();

            foreach (VIZCore3DX.NET.Data.Node node in selectedNodes)
            {
                if (node == null) continue;
                if (group.Nodes == null || group.Nodes.Contains(node) == false) continue;

                removeNodes.Add(node);
            }

            if (removeNodes.Count == 0)
            {
                MessageBox.Show("선택한 Node가 현재 그룹에 포함되어 있지 않습니다.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            vizcore3dx.Object3D.Group.RemoveNodes(group, removeNodes);
            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            RefreshGroupTree(group);
        }

        private void BtnMoveSelectedNodes_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.GroupItem targetGroup = GetSelectedTreeGroup();

            if (targetGroup == null)
            {
                MessageBox.Show("Node를 이동할 대상 그룹을 선택하세요.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> selectedNodes = vizcore3dx.Object3D.GetSelectedObjects().OfType<VIZCore3DX.NET.Data.Node>().ToList();

            if (selectedNodes.Count == 0)
            {
                MessageBox.Show("모델에서 이동할 Node를 선택하세요.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> moveNodes = new List<VIZCore3DX.NET.Data.Node>();
            int sameGroupCount = 0;
            int noGroupCount = 0;

            foreach (VIZCore3DX.NET.Data.Node node in selectedNodes)
            {
                if (node == null) continue;

                if (vizcore3dx.Object3D.Group.ContainsNode(targetGroup, node) == true)
                {
                    sameGroupCount++;
                    continue;
                }

                VIZCore3DX.NET.Data.GroupItem currentGroup = vizcore3dx.Object3D.Group.FindContainingGroup(node);

                if (currentGroup == null)
                {
                    noGroupCount++;
                    continue;
                }

                vizcore3dx.Object3D.Group.RemoveNode(currentGroup, node);
                moveNodes.Add(node);
            }

            if (moveNodes.Count > 0) vizcore3dx.Object3D.Group.AddNodes(targetGroup, moveNodes);

            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            RefreshGroupTree(targetGroup);

            if (moveNodes.Count == 0 && sameGroupCount > 0 && noGroupCount == 0)
            {
                MessageBox.Show("선택한 Node가 이미 대상 그룹에 포함되어 있습니다.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (noGroupCount > 0) MessageBox.Show(string.Format("그룹에 포함되어 있지 않은 Node {0}개는 이동하지 않았습니다.\r\n새로 추가하려면 '선택 Node 그룹에 추가'를 사용하세요.", noGroupCount), "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCreateFlatGroups_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("현재 그룹을 모두 삭제하고 모델 전체 기준으로 평면 그룹을 생성할까요?", "Group Explode", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            RestoreExplode();

            vizcore3dx.Object3D.Group.ClearGroup();
            vizcore3dx.Object3D.Group.CreateFlatGroups();

            txtGroupName.Text = GetNextGroupName();

            RefreshGroupTree(null);
        }

        private void BtnCreateHierarchicalGroups_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("현재 그룹을 모두 삭제하고 모델 전체 기준으로 계층 그룹을 생성할까요?", "Group Explode", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            RestoreExplode();

            vizcore3dx.Object3D.Group.ClearGroup();
            vizcore3dx.Object3D.Group.CreateHierarchicalGroups((int)numMaxDepth.Value);

            txtGroupName.Text = GetNextGroupName();

            RefreshGroupTree(null);
        }

        private void BtnDeleteGroup_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.GroupItem group = GetSelectedTreeGroup();

            if (group == null)
            {
                MessageBox.Show("삭제할 그룹을 선택하세요.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RestoreExplode();

            vizcore3dx.Object3D.Group.DeleteGroup(group);

            txtGroupName.Text = GetNextGroupName();

            RefreshGroupTree(null);
        }

        private void BtnClearGroups_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Object3D.Group.AllGroups == null || vizcore3dx.Object3D.Group.AllGroups.Count == 0)
            {
                txtGroupName.Text = "Group 1";
                return;
            }

            DialogResult result = MessageBox.Show("모든 그룹을 삭제할까요?", "Group Explode", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            RestoreExplode();

            vizcore3dx.Object3D.Group.ClearGroup();

            txtGroupName.Text = "Group 1";

            RefreshGroupTree(null);
        }

        private void ChkGroupSelection_CheckedChanged(object sender, EventArgs e)
        {
            if (vizcore3dx == null) return;

            vizcore3dx.Object3D.Group.EnableGroupSelection(chkGroupSelection.Checked);

            UpdateGroupSelectionUI();
        }

        private void UpdateGroupSelectionUI()
        {
            bool enabled = chkGroupSelection.Checked == false;

            btnAddSelectedNodes.Enabled = enabled;
            btnRemoveSelectedNodes.Enabled = enabled;
            btnMoveSelectedNodes.Enabled = enabled;
        }

        private void TvGroups_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
            {
                lblSelectedGroup.Text = "선택 그룹 : 없음";
                return;
            }

            VIZCore3DX.NET.Data.GroupItem group = e.Node.Tag as VIZCore3DX.NET.Data.GroupItem;

            if (group != null)
            {
                int nodeCount = group.Nodes == null ? 0 : group.Nodes.Count;
                int childCount = group.Groups == null ? 0 : group.Groups.Count;

                lblSelectedGroup.Text = string.Format("선택 그룹 : {0} / Depth : {1} / Node : {2} / 하위 : {3}", group.Name, group.Depth, nodeCount, childCount);
                return;
            }

            VIZCore3DX.NET.Data.Node node = e.Node.Tag as VIZCore3DX.NET.Data.Node;

            if (node != null)
            {
                lblSelectedGroup.Text = string.Format("선택 Node : {0}", node.NodeName);
                return;
            }

            lblSelectedGroup.Text = "선택 그룹 : 없음";
        }

        private VIZCore3DX.NET.Data.GroupItem GetSelectedTreeGroup()
        {
            if (tvGroups.SelectedNode == null) return null;

            return tvGroups.SelectedNode.Tag as VIZCore3DX.NET.Data.GroupItem;
        }

        private bool IsDuplicateGroupName(string name)
        {
            if (vizcore3dx.Object3D.Group.AllGroups == null) return false;

            return vizcore3dx.Object3D.Group.AllGroups.Any(group => group != null && string.Equals(group.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        private string GetNextGroupName()
        {
            int index = 1;

            while (IsDuplicateGroupName(string.Format("Group {0}", index)) == true) index++;

            return string.Format("Group {0}", index);
        }

        private void RefreshGroupTree(VIZCore3DX.NET.Data.GroupItem selectGroup)
        {
            tvGroups.BeginUpdate();
            tvGroups.Nodes.Clear();

            List<VIZCore3DX.NET.Data.GroupItem> groups = vizcore3dx.Object3D.Group.Groups;

            if (groups != null)
            {
                foreach (VIZCore3DX.NET.Data.GroupItem group in groups)
                {
                    if (group == null) continue;

                    tvGroups.Nodes.Add(CreateGroupTreeNode(group));
                }
            }

            tvGroups.ExpandAll();
            tvGroups.EndUpdate();

            int rootCount = vizcore3dx.Object3D.Group.Groups == null ? 0 : vizcore3dx.Object3D.Group.Groups.Count;
            int allCount = vizcore3dx.Object3D.Group.AllGroups == null ? 0 : vizcore3dx.Object3D.Group.AllGroups.Count;

            lblGroupCount.Text = string.Format("최상위 그룹 : {0} / 전체 그룹 : {1}", rootCount, allCount);

            if (selectGroup != null)
            {
                SelectTreeGroup(tvGroups.Nodes, selectGroup);
            }
            else
            {
                tvGroups.SelectedNode = null;
                lblSelectedGroup.Text = "선택 그룹 : 없음";
            }
        }

        private TreeNode CreateGroupTreeNode(VIZCore3DX.NET.Data.GroupItem group)
        {
            int nodeCount = group.Nodes == null ? 0 : group.Nodes.Count;
            int childCount = group.Groups == null ? 0 : group.Groups.Count;

            string text = string.Format("{0} (Depth {1}", group.Name, group.Depth);

            if (nodeCount > 0) text = string.Format("{0}, Node {1}", text, nodeCount);
            if (childCount > 0) text = string.Format("{0}, 하위 {1}개", text, childCount);

            text = string.Format("{0})", text);

            TreeNode groupTreeNode = new TreeNode(text);
            groupTreeNode.Tag = group;

            if (group.Groups != null)
            {
                foreach (VIZCore3DX.NET.Data.GroupItem childGroup in group.Groups)
                {
                    if (childGroup == null) continue;

                    groupTreeNode.Nodes.Add(CreateGroupTreeNode(childGroup));
                }
            }

            if (group.Nodes != null)
            {
                foreach (VIZCore3DX.NET.Data.Node node in group.Nodes)
                {
                    if (node == null) continue;

                    TreeNode nodeTreeNode = new TreeNode(string.IsNullOrEmpty(node.NodeName) == true ? "Node" : node.NodeName);
                    nodeTreeNode.Tag = node;

                    groupTreeNode.Nodes.Add(nodeTreeNode);
                }
            }

            return groupTreeNode;
        }

        private bool SelectTreeGroup(TreeNodeCollection treeNodes, VIZCore3DX.NET.Data.GroupItem group)
        {
            foreach (TreeNode treeNode in treeNodes)
            {
                VIZCore3DX.NET.Data.GroupItem treeGroup = treeNode.Tag as VIZCore3DX.NET.Data.GroupItem;

                if (treeGroup != null && ReferenceEquals(treeGroup, group) == true)
                {
                    tvGroups.SelectedNode = treeNode;
                    treeNode.EnsureVisible();
                    return true;
                }

                if (SelectTreeGroup(treeNode.Nodes, group) == true) return true;
            }

            return false;
        }

        #endregion

        #region Explode

        private VIZCore3DX.NET.Data.ExplodeSetting GetExplodeSetting()
        {
            VIZCore3DX.NET.Data.ExplodeSetting setting = new VIZCore3DX.NET.Data.ExplodeSetting();

            setting.Mode = rdoDirectional.Checked == true ? VIZCore3DX.NET.Data.ExplodeMode.Directional : VIZCore3DX.NET.Data.ExplodeMode.Radial;
            setting.DistanceRatio = (float)numDistanceRatio.Value;
            setting.LevelDistanceDecay = (float)numLevelDecay.Value;
            setting.Direction = new VIZCore3DX.NET.Data.Vector3D((float)numDirectionX.Value, (float)numDirectionY.Value, (float)numDirectionZ.Value);

            return setting;
        }

        private void RdoExplodeMode_CheckedChanged(object sender, EventArgs e)
        {
            UpdateExplodeModeUI();
        }

        private void UpdateExplodeModeUI()
        {
            bool enabled = rdoDirectional.Checked;

            numDirectionX.Enabled = enabled;
            numDirectionY.Enabled = enabled;
            numDirectionZ.Enabled = enabled;
        }

        private async void BtnRadialAnimation_Click(object sender, EventArgs e)
        {
            if (CheckAnimation() == false) return;

            PrepareExplode();
            SetAnimationControlsEnabled(false);

            try
            {
                VIZCore3DX.NET.Data.ExplodeSetting setting = GetExplodeSetting();
                setting.Mode = VIZCore3DX.NET.Data.ExplodeMode.Radial;

                await vizcore3dx.Object3D.Explode.AnimateExplodeRadial(0.0f, 1.0f, (float)numDuration.Value, setting, chkAutoRestore.Checked);
            }
            finally
            {
                SetAnimationControlsEnabled(true);
                UpdateExplodeStatus();
            }
        }

        private async void BtnDirectionalAnimation_Click(object sender, EventArgs e)
        {
            if (CheckAnimation() == false) return;

            if (numDirectionX.Value == 0M && numDirectionY.Value == 0M && numDirectionZ.Value == 0M)
            {
                MessageBox.Show("방향 지정 분해에서는 X, Y, Z가 모두 0일 수 없습니다.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PrepareExplode();
            SetAnimationControlsEnabled(false);

            try
            {
                VIZCore3DX.NET.Data.ExplodeSetting setting = GetExplodeSetting();
                setting.Mode = VIZCore3DX.NET.Data.ExplodeMode.Directional;

                VIZCore3DX.NET.Data.Vector3D direction = new VIZCore3DX.NET.Data.Vector3D((float)numDirectionX.Value, (float)numDirectionY.Value, (float)numDirectionZ.Value);

                await vizcore3dx.Object3D.Explode.AnimateExplodeDirectional(0.0f, 1.0f, (float)numDuration.Value, direction, setting, chkAutoRestore.Checked);
            }
            finally
            {
                SetAnimationControlsEnabled(true);
                UpdateExplodeStatus();
            }
        }

        private async void BtnSequentialAnimation_Click(object sender, EventArgs e)
        {
            if (CheckAnimation() == false) return;

            uint maxDepth = 0;

            foreach (VIZCore3DX.NET.Data.GroupItem group in vizcore3dx.Object3D.Group.AllGroups)
            {
                if (group == null) continue;
                if (group.Nodes == null || group.Nodes.Count == 0) continue;

                if (group.Depth > maxDepth) maxDepth = group.Depth;
            }

            if (maxDepth == 0)
            {
                MessageBox.Show("실제 Node가 포함된 하위 그룹이 없습니다.\r\n계층 순차 분해를 확인하려면 Depth 1 이상의 그룹에 Node를 추가하세요.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PrepareExplode();
            SetAnimationControlsEnabled(false);

            try
            {
                VIZCore3DX.NET.Data.ExplodeSetting setting = GetExplodeSetting();

                await vizcore3dx.Object3D.Explode.AnimateExplodeSequential((float)numDuration.Value, (float)numHoldSeconds.Value, setting, chkAutoRestore.Checked);
            }
            finally
            {
                SetAnimationControlsEnabled(true);
                UpdateExplodeStatus();
            }
        }

        private async void BtnFocusExplode_Click(object sender, EventArgs e)
        {
            if (CheckAnimation() == false) return;

            if (chkGroupSelection.Checked == true)
            {
                MessageBox.Show("선택 Node 중심 분해를 사용하려면 '뷰에서 그룹 단위 선택'을 먼저 해제하세요.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.GetSelectedObjects().OfType<VIZCore3DX.NET.Data.Node>().ToList();

            if (nodes.Count == 0)
            {
                MessageBox.Show("모델에서 중심으로 확인할 Node를 선택하세요.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PrepareExplode();
            SetAnimationControlsEnabled(false);

            try
            {
                await vizcore3dx.Object3D.Explode.FocusExplode(nodes, (float)numDuration.Value, GetExplodeSetting(), chkAutoRestore.Checked);
            }
            finally
            {
                SetAnimationControlsEnabled(true);
                UpdateExplodeStatus();
            }
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            RestoreExplode();

            UpdateExplodeStatus();
        }

        private void PrepareExplode()
        {
            if (vizcore3dx.Object3D.Explode.IsActive == true)
            {
                vizcore3dx.Object3D.Explode.Restore();
                vizcore3dx.Object3D.Explode.Deactivate(false);
            }

            if (vizcore3dx.View.XRay.Enable == true) vizcore3dx.View.XRay.Enable = false;
        }

        private void RestoreExplode()
        {
            if (vizcore3dx == null || vizcore3dx.Object3D == null || vizcore3dx.Object3D.Explode == null) return;
            if (vizcore3dx.Object3D.Explode.IsAnimating == true) return;

            if (vizcore3dx.Object3D.Explode.IsActive == true)
            {
                vizcore3dx.Object3D.Explode.Restore();
                vizcore3dx.Object3D.Explode.Deactivate(true);
            }

            if (vizcore3dx.View.XRay.Enable == true) vizcore3dx.View.XRay.Enable = false;
        }

        private bool CheckGroups()
        {
            if (vizcore3dx.Object3D.Group.AllGroups == null || vizcore3dx.Object3D.Group.AllGroups.Count == 0)
            {
                MessageBox.Show("분해할 그룹이 없습니다. 먼저 그룹을 생성하세요.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            foreach (VIZCore3DX.NET.Data.GroupItem group in vizcore3dx.Object3D.Group.AllGroups)
            {
                if (group == null) continue;
                if (group.Nodes != null && group.Nodes.Count > 0) return true;
            }

            MessageBox.Show("그룹은 존재하지만 포함된 Node가 없습니다.\r\n분해할 Node를 그룹에 추가하세요.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return false;
        }

        private bool CheckAnimation()
        {
            if (CheckGroups() == false) return false;

            if (vizcore3dx.Object3D.Explode.IsAnimating == true)
            {
                MessageBox.Show("현재 분해 애니메이션이 실행 중입니다.", "Group Explode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void UpdateExplodeStatus()
        {
            lblExplodeStatus.Text = string.Format("활성화 : {0} / 실행 중 : {1}", vizcore3dx.Object3D.Explode.IsActive == true ? "예" : "아니오", vizcore3dx.Object3D.Explode.IsAnimating == true ? "예" : "아니오");
        }

        private void SetAnimationControlsEnabled(bool enabled)
        {
            btnRadialAnimation.Enabled = enabled;
            btnDirectionalAnimation.Enabled = enabled;
            btnSequentialAnimation.Enabled = enabled;
            btnFocusExplode.Enabled = enabled;
            btnRestore.Enabled = enabled;
            grpGroup.Enabled = enabled;
        }

        #endregion
    }
}