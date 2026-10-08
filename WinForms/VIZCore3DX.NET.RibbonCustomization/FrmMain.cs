using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace VIZCore3DX.NET.RibbonCustomization
{
    public partial class FrmMain : Form
    {
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        private const string DefaultCustomTabName = "custom";

        private enum RibbonNodeType
        {
            Tab,
            Group,
            Item
        }

        private class RibbonNodeData
        {
            public RibbonNodeType Type;
            public string Name;

            public RibbonNodeData(RibbonNodeType type, string name)
            {
                Type = type;
                Name = name;
            }
        }

        private class RibbonGroupOrigin
        {
            public string TabName;
            public string GroupName;
            public int Index;
            public string Text;
            public bool Visible;

            public RibbonGroupOrigin(string tabName, string groupName, int index, string text, bool visible)
            {
                TabName = tabName;
                GroupName = groupName;
                Index = index;
                Text = text;
                Visible = visible;
            }
        }

        private class RibbonItemOrigin
        {
            public string TabName;
            public string GroupName;
            public int Index;
            public string Text;
            public bool Visible;
            public bool HasSize;
            public VIZCore3DX.NET.Controls.Ribbon.RibbonItemSize Size;

            public RibbonItemOrigin(string tabName, string groupName, int index, string text, bool visible, bool hasSize, VIZCore3DX.NET.Controls.Ribbon.RibbonItemSize size)
            {
                TabName = tabName;
                GroupName = groupName;
                Index = index;
                Text = text;
                Visible = visible;
                HasSize = hasSize;
                Size = size;
            }
        }

        private readonly HashSet<string> customTabNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly List<string> originalTabOrder = new List<string>();
        private readonly List<string> originalQuickAccessItems = new List<string>();
        private int customButtonIndex = 1;
        private readonly Dictionary<string, RibbonGroupOrigin> groupOrigins = new Dictionary<string, RibbonGroupOrigin>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, RibbonItemOrigin> itemOrigins = new Dictionary<string, RibbonItemOrigin>(StringComparer.OrdinalIgnoreCase);

        private string selectedRibbonName = string.Empty;
        private RibbonNodeType selectedRibbonType = RibbonNodeType.Tab;
        private int customTabIndex = 1;

        public FrmMain()
        {
            InitializeComponent();

            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

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
            vizcore3dx.RibbonMode = true;
            chkRibbonMode.Checked = true;

            InitializeRibbonTheme();
            CaptureOriginalRibbonState();
            InitializeCustomRibbon();
            HideDefaultTabs();
            RefreshRibbonTrees();

            vizcore3dx.Ribbon.SelectTab(DefaultCustomTabName);
        }

        private void InitializeRibbonTheme()
        {
            cmbRibbonTheme.Items.Clear();

            foreach (object value in Enum.GetValues(typeof(VIZCore3DX.NET.Controls.Ribbon.RibbonTheme))) cmbRibbonTheme.Items.Add(value);

            cmbRibbonTheme.SelectedItem = vizcore3dx.RibbonTheme;
        }

        private void CaptureOriginalRibbonState()
        {
            groupOrigins.Clear();
            itemOrigins.Clear();

            // 탭 순서 / 빠른 실행 목록 (구성 초기화 시 복원)
            originalTabOrder.Clear();
            originalTabOrder.AddRange(vizcore3dx.Ribbon.GetTabNames());
            originalQuickAccessItems.Clear();
            originalQuickAccessItems.AddRange(vizcore3dx.Ribbon.GetQuickAccessItems());

            foreach (string tabName in vizcore3dx.Ribbon.GetTabNames())
            {
                List<string> groupNames = vizcore3dx.Ribbon.GetGroupNames(tabName);

                for (int groupIndex = 0; groupIndex < groupNames.Count; groupIndex++)
                {
                    string groupName = groupNames[groupIndex];

                    if (!groupOrigins.ContainsKey(groupName)) groupOrigins.Add(groupName, new RibbonGroupOrigin(tabName, groupName, groupIndex, vizcore3dx.Ribbon.GetGroupText(groupName), vizcore3dx.Ribbon.GetGroupVisible(groupName)));

                    List<string> itemNames = vizcore3dx.Ribbon.GetGroupItemNames(groupName);

                    for (int itemIndex = 0; itemIndex < itemNames.Count; itemIndex++)
                    {
                        string itemName = itemNames[itemIndex];

                        if (itemOrigins.ContainsKey(itemName)) continue;

                        VIZCore3DX.NET.Controls.Ribbon.RibbonItemSize size;
                        bool hasSize = vizcore3dx.Ribbon.GetItemSize(itemName, out size);

                        itemOrigins.Add(itemName, new RibbonItemOrigin(tabName, groupName, itemIndex, vizcore3dx.Ribbon.GetItemText(itemName), vizcore3dx.Ribbon.GetItemVisible(itemName), hasSize, size));
                    }
                }
            }
        }

        private void InitializeCustomRibbon()
        {
            customTabNames.Clear();
            customTabNames.Add(DefaultCustomTabName);

            if (!vizcore3dx.Ribbon.GetTabNames().Contains(DefaultCustomTabName)) vizcore3dx.Ribbon.AddTab(DefaultCustomTabName, "사용자 정의");

            vizcore3dx.Ribbon.SetTabVisible(DefaultCustomTabName, true);
        }

        private void HideDefaultTabs()
        {
            vizcore3dx.Ribbon.BeginUpdate();

            try
            {
                foreach (string tabName in vizcore3dx.Ribbon.GetTabNames()) vizcore3dx.Ribbon.SetTabVisible(tabName, customTabNames.Contains(tabName));
            }
            finally
            {
                vizcore3dx.Ribbon.EndUpdate();
            }

            vizcore3dx.Ribbon.SelectTab(DefaultCustomTabName);
        }

        private void ShowDefaultTabs()
        {
            vizcore3dx.Ribbon.BeginUpdate();

            try
            {
                foreach (string tabName in vizcore3dx.Ribbon.GetTabNames()) vizcore3dx.Ribbon.SetTabVisible(tabName, true);
            }
            finally
            {
                vizcore3dx.Ribbon.EndUpdate();
            }

            RefreshRibbonTrees();
        }

        private void RefreshRibbonTrees()
        {
            RefreshAvailableTree();
            RefreshCustomTree();
            UpdateButtons();
        }

        private void RefreshAvailableTree()
        {
            string selectedName = GetSelectedNodeName(treeAvailable);

            treeAvailable.BeginUpdate();

            try
            {
                treeAvailable.Nodes.Clear();

                foreach (string tabName in vizcore3dx.Ribbon.GetTabNames())
                {
                    if (customTabNames.Contains(tabName)) continue;

                    TreeNode tabNode = CreateTabNode(tabName);

                    foreach (string groupName in vizcore3dx.Ribbon.GetGroupNames(tabName))
                    {
                        TreeNode groupNode = CreateGroupNode(groupName);

                        foreach (string itemName in vizcore3dx.Ribbon.GetGroupItemNames(groupName)) groupNode.Nodes.Add(CreateItemNode(itemName));

                        tabNode.Nodes.Add(groupNode);
                    }

                    treeAvailable.Nodes.Add(tabNode);
                }

                treeAvailable.CollapseAll();
            }
            finally
            {
                treeAvailable.EndUpdate();
            }

            SelectTreeNode(treeAvailable, selectedName);
        }

        private void RefreshCustomTree()
        {
            string selectedName = GetSelectedNodeName(treeCustom);

            treeCustom.BeginUpdate();

            try
            {
                treeCustom.Nodes.Clear();

                foreach (string tabName in vizcore3dx.Ribbon.GetTabNames())
                {
                    if (!customTabNames.Contains(tabName)) continue;

                    TreeNode tabNode = CreateTabNode(tabName);

                    foreach (string groupName in vizcore3dx.Ribbon.GetGroupNames(tabName))
                    {
                        TreeNode groupNode = CreateGroupNode(groupName);

                        foreach (string itemName in vizcore3dx.Ribbon.GetGroupItemNames(groupName)) groupNode.Nodes.Add(CreateItemNode(itemName));

                        tabNode.Nodes.Add(groupNode);
                    }

                    treeCustom.Nodes.Add(tabNode);
                }

                treeCustom.ExpandAll();
            }
            finally
            {
                treeCustom.EndUpdate();
            }

            SelectTreeNode(treeCustom, selectedName);
        }

        private TreeNode CreateTabNode(string tabName)
        {
            string text = GetTabTextLocal(tabName);

            if (string.IsNullOrEmpty(text)) text = tabName;
            if (!vizcore3dx.Ribbon.GetTabVisible(tabName)) text += " (숨김)";

            TreeNode node = new TreeNode(text);
            node.Name = tabName;
            node.Tag = new RibbonNodeData(RibbonNodeType.Tab, tabName);

            return node;
        }

        private TreeNode CreateGroupNode(string groupName)
        {
            string text = vizcore3dx.Ribbon.GetGroupText(groupName);

            if (string.IsNullOrEmpty(text)) text = groupName;
            if (!vizcore3dx.Ribbon.GetGroupVisible(groupName)) text += " (숨김)";

            TreeNode node = new TreeNode(text);
            node.Name = groupName;
            node.Tag = new RibbonNodeData(RibbonNodeType.Group, groupName);

            return node;
        }

        private TreeNode CreateItemNode(string itemName)
        {
            string text = vizcore3dx.Ribbon.GetItemText(itemName);

            if (string.IsNullOrEmpty(text)) text = itemName;

            text = text.Replace("\r", " ").Replace("\n", " ");

            if (!vizcore3dx.Ribbon.GetItemVisible(itemName)) text += " (숨김)";

            TreeNode node = new TreeNode(text);
            node.Name = itemName;
            node.Tag = new RibbonNodeData(RibbonNodeType.Item, itemName);

            return node;
        }

        private string GetSelectedNodeName(TreeView tree)
        {
            if (tree.SelectedNode == null) return string.Empty;

            RibbonNodeData data = tree.SelectedNode.Tag as RibbonNodeData;

            return data != null ? data.Name : string.Empty;
        }

        private void SelectTreeNode(TreeView tree, string name)
        {
            if (string.IsNullOrEmpty(name)) return;

            TreeNode[] nodes = tree.Nodes.Find(name, true);

            if (nodes.Length == 0) return;

            TreeNode node = nodes[0];
            TreeNode parent = node.Parent;

            while (parent != null)
            {
                parent.Expand();
                parent = parent.Parent;
            }

            tree.SelectedNode = node;
            node.EnsureVisible();
        }

        private void treeAvailable_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadSelectedRibbonItem(e.Node);
            UpdateButtons();
        }

        private void treeCustom_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadSelectedRibbonItem(e.Node);
            UpdateButtons();
        }

        private void LoadSelectedRibbonItem(TreeNode node)
        {
            if (node == null) return;

            RibbonNodeData data = node.Tag as RibbonNodeData;

            if (data == null) return;

            selectedRibbonName = data.Name;
            selectedRibbonType = data.Type;

            txtSelectedName.Text = data.Name;
            txtSelectedParent.Text = string.Empty;
            txtSelectedText.Text = string.Empty;

            rdoVisible.Checked = false;
            rdoHidden.Checked = false;
            rdoLarge.Checked = false;
            rdoSmall.Checked = false;

            txtSelectedText.Enabled = false;
            rdoLarge.Enabled = false;
            rdoSmall.Enabled = false;
            btnApplySelected.Enabled = true;

            if (data.Type == RibbonNodeType.Tab)
            {
                lblSelectedTypeValue.Text = "탭";
                txtSelectedParent.Text = "-";
                txtSelectedText.Text = GetTabTextLocal(data.Name);
                rdoVisible.Checked = vizcore3dx.Ribbon.GetTabVisible(data.Name);
                rdoHidden.Checked = !rdoVisible.Checked;
                return;
            }

            if (data.Type == RibbonNodeType.Group)
            {
                lblSelectedTypeValue.Text = "그룹";
                txtSelectedParent.Text = vizcore3dx.Ribbon.GetParentTabName(data.Name);
                txtSelectedText.Text = vizcore3dx.Ribbon.GetGroupText(data.Name);
                txtSelectedText.Enabled = true;
                rdoVisible.Checked = vizcore3dx.Ribbon.GetGroupVisible(data.Name);
                rdoHidden.Checked = !rdoVisible.Checked;
                return;
            }

            lblSelectedTypeValue.Text = "기능";
            txtSelectedParent.Text = vizcore3dx.Ribbon.GetParentGroupName(data.Name);
            txtSelectedText.Text = vizcore3dx.Ribbon.GetItemText(data.Name).Replace("\r", " ").Replace("\n", " ");
            txtSelectedText.Enabled = true;
            rdoVisible.Checked = vizcore3dx.Ribbon.GetItemVisible(data.Name);
            rdoHidden.Checked = !rdoVisible.Checked;
            rdoLarge.Enabled = true;
            rdoSmall.Enabled = true;

            VIZCore3DX.NET.Controls.Ribbon.RibbonItemSize size;

            if (!vizcore3dx.Ribbon.GetItemSize(data.Name, out size)) return;

            rdoLarge.Checked = size == VIZCore3DX.NET.Controls.Ribbon.RibbonItemSize.Large;
            rdoSmall.Checked = size == VIZCore3DX.NET.Controls.Ribbon.RibbonItemSize.Small;
        }

        private void btnApplySelected_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedRibbonName)) return;

            bool result = true;

            if (selectedRibbonType == RibbonNodeType.Tab)
            {
                result = vizcore3dx.Ribbon.SetTabVisible(selectedRibbonName, rdoVisible.Checked);
            }
            else if (selectedRibbonType == RibbonNodeType.Group)
            {
                result &= vizcore3dx.Ribbon.SetGroupText(selectedRibbonName, txtSelectedText.Text);
                result &= vizcore3dx.Ribbon.SetGroupVisible(selectedRibbonName, rdoVisible.Checked);
            }
            else
            {
                result &= vizcore3dx.Ribbon.SetItemText(selectedRibbonName, txtSelectedText.Text);
                result &= vizcore3dx.Ribbon.SetItemVisible(selectedRibbonName, rdoVisible.Checked);

                if (rdoLarge.Checked) result &= vizcore3dx.Ribbon.SetItemSize(selectedRibbonName, VIZCore3DX.NET.Controls.Ribbon.RibbonItemSize.Large);
                if (rdoSmall.Checked) result &= vizcore3dx.Ribbon.SetItemSize(selectedRibbonName, VIZCore3DX.NET.Controls.Ribbon.RibbonItemSize.Small);
            }

            if (!result) MessageBox.Show("리본 설정을 적용하지 못했습니다.", "리본 설정", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            RefreshRibbonTrees();
            SelectTreeNode(treeAvailable, selectedRibbonName);
            SelectTreeNode(treeCustom, selectedRibbonName);
        }

        private void btnMoveToCustom_Click(object sender, EventArgs e)
        {
            if (treeAvailable.SelectedNode == null)
            {
                MessageBox.Show("이동할 기능을 선택하세요.", "리본 구성", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RibbonNodeData source = treeAvailable.SelectedNode.Tag as RibbonNodeData;

            if (source == null || source.Type != RibbonNodeType.Item)
            {
                MessageBox.Show("기능 항목을 선택하세요.", "리본 구성", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string targetGroupName = GetSelectedCustomGroupName();

            if (string.IsNullOrEmpty(targetGroupName))
            {
                MessageBox.Show("오른쪽에서 기능을 넣을 그룹을 선택하세요.", "리본 구성", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!vizcore3dx.Ribbon.MoveItem(source.Name, targetGroupName))
            {
                MessageBox.Show("기능을 이동하지 못했습니다.", "리본 구성", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vizcore3dx.Ribbon.SetGroupVisible(targetGroupName, true);
            vizcore3dx.Ribbon.SetItemVisible(source.Name, true);

            string targetTabName = vizcore3dx.Ribbon.GetParentTabName(targetGroupName);

            if (!string.IsNullOrEmpty(targetTabName))
            {
                vizcore3dx.Ribbon.SetTabVisible(targetTabName, true);
                vizcore3dx.Ribbon.SelectTab(targetTabName);
            }

            RefreshRibbonTrees();
            SelectTreeNode(treeCustom, source.Name);
        }

        private void btnRestoreItem_Click(object sender, EventArgs e)
        {
            if (treeCustom.SelectedNode == null)
            {
                MessageBox.Show("원래 위치로 돌릴 기능을 선택하세요.", "리본 구성", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RibbonNodeData data = treeCustom.SelectedNode.Tag as RibbonNodeData;

            if (data == null || data.Type != RibbonNodeType.Item)
            {
                MessageBox.Show("기능 항목을 선택하세요.", "리본 구성", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RibbonItemOrigin origin;

            if (!itemOrigins.TryGetValue(data.Name, out origin))
            {
                MessageBox.Show("원래 위치 정보가 없는 기능입니다.", "리본 구성", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!vizcore3dx.Ribbon.MoveItem(data.Name, origin.GroupName, origin.Index))
            {
                MessageBox.Show("기능을 원래 위치로 돌리지 못했습니다.", "리본 구성", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RefreshRibbonTrees();
            SelectTreeNode(treeAvailable, data.Name);
        }

        private string GetSelectedCustomGroupName()
        {
            if (treeCustom.SelectedNode == null) return string.Empty;

            TreeNode node = treeCustom.SelectedNode;
            RibbonNodeData data = node.Tag as RibbonNodeData;

            if (data == null) return string.Empty;
            if (data.Type == RibbonNodeType.Group) return data.Name;

            if (data.Type == RibbonNodeType.Item && node.Parent != null)
            {
                RibbonNodeData parent = node.Parent.Tag as RibbonNodeData;

                if (parent != null && parent.Type == RibbonNodeType.Group) return parent.Name;
            }

            return string.Empty;
        }

        private string GetSelectedCustomTabName()
        {
            if (treeCustom.SelectedNode == null) return string.Empty;

            TreeNode node = treeCustom.SelectedNode;

            while (node != null)
            {
                RibbonNodeData data = node.Tag as RibbonNodeData;

                if (data != null && data.Type == RibbonNodeType.Tab) return data.Name;

                node = node.Parent;
            }

            return string.Empty;
        }

        private void UpdateButtons()
        {
            btnMoveToCustom.Enabled = false;
            btnRestoreItem.Enabled = false;
            btnAddGroup.Enabled = false;

            if (treeAvailable.SelectedNode != null)
            {
                RibbonNodeData data = treeAvailable.SelectedNode.Tag as RibbonNodeData;

                if (data != null && data.Type == RibbonNodeType.Item && !string.IsNullOrEmpty(GetSelectedCustomGroupName())) btnMoveToCustom.Enabled = true;
            }

            if (treeCustom.SelectedNode == null) return;

            RibbonNodeData customData = treeCustom.SelectedNode.Tag as RibbonNodeData;

            if (customData != null && customData.Type == RibbonNodeType.Item && itemOrigins.ContainsKey(customData.Name)) btnRestoreItem.Enabled = true;
            if (!string.IsNullOrEmpty(GetSelectedCustomTabName())) btnAddGroup.Enabled = true;
        }

        private void btnAddTab_Click(object sender, EventArgs e)
        {
            string text = txtNewRibbonName.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("추가할 탭의 표시 이름을 입력하세요.", "탭 추가", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string name = GetNextCustomTabName();
            VIZCore3DX.NET.Controls.Ribbon.RibbonTab tab = vizcore3dx.Ribbon.AddTab(name, text);

            if (tab == null)
            {
                MessageBox.Show("탭을 추가하지 못했습니다.", "탭 추가", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            customTabNames.Add(name);
            vizcore3dx.Ribbon.SetTabVisible(name, true);
            vizcore3dx.Ribbon.SelectTab(name);

            txtNewRibbonName.Clear();

            RefreshRibbonTrees();
            SelectTreeNode(treeCustom, name);
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            string tabName = GetSelectedCustomTabName();

            if (string.IsNullOrEmpty(tabName))
            {
                MessageBox.Show("그룹을 추가할 탭을 선택하세요.", "그룹 추가", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string text = txtNewRibbonName.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("추가할 그룹의 표시 이름을 입력하세요.", "그룹 추가", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string name = GetNextGroupName(tabName);
            VIZCore3DX.NET.Controls.Ribbon.RibbonGroup group = vizcore3dx.Ribbon.AddGroup(tabName, name, text);

            if (group == null)
            {
                MessageBox.Show("그룹을 추가하지 못했습니다.", "그룹 추가", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vizcore3dx.Ribbon.SetGroupVisible(name, true);
            vizcore3dx.Ribbon.SetTabVisible(tabName, true);

            txtNewRibbonName.Clear();

            RefreshRibbonTrees();
            SelectTreeNode(treeCustom, name);
        }

        private string GetNextCustomTabName()
        {
            while (true)
            {
                string name = string.Format("custom.tab{0}", customTabIndex);

                customTabIndex++;

                if (!RibbonNameExists(name)) return name;
            }
        }

        private string GetNextGroupName(string tabName)
        {
            int index = 1;

            while (true)
            {
                string name = string.Format("{0}.group{1}", tabName, index);

                if (!RibbonNameExists(name)) return name;

                index++;
            }
        }

        private bool RibbonNameExists(string name)
        {
            foreach (string tabName in vizcore3dx.Ribbon.GetTabNames())
            {
                if (string.Equals(tabName, name, StringComparison.OrdinalIgnoreCase)) return true;

                foreach (string groupName in vizcore3dx.Ribbon.GetGroupNames(tabName))
                {
                    if (string.Equals(groupName, name, StringComparison.OrdinalIgnoreCase)) return true;

                    foreach (string itemName in vizcore3dx.Ribbon.GetGroupItemNames(groupName))
                    {
                        if (string.Equals(itemName, name, StringComparison.OrdinalIgnoreCase)) return true;
                    }
                }
            }

            return false;
        }

        private void btnShowDefaultTabs_Click(object sender, EventArgs e)
        {
            ShowDefaultTabs();
        }

        private void btnHideDefaultTabs_Click(object sender, EventArgs e)
        {
            HideDefaultTabs();
            RefreshRibbonTrees();
        }

        private void btnResetRibbon_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("사용자 정의 리본 구성을 처음 상태로 되돌리시겠습니까?", "리본 구성 초기화", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            ResetRibbonConfiguration();
        }

        private void ResetRibbonConfiguration()
        {
            RestoreOriginalTabOrder();
            vizcore3dx.Ribbon.SetQuickAccessItems(new List<string>(originalQuickAccessItems));
            RestoreOriginalGroups();
            RestoreOriginalItems();
            RestoreOriginalProperties();
            RemoveCustomRibbonStructures();

            customTabNames.Clear();
            customTabNames.Add(DefaultCustomTabName);
            customTabIndex = 1;

            if (!vizcore3dx.Ribbon.GetTabNames().Contains(DefaultCustomTabName)) vizcore3dx.Ribbon.AddTab(DefaultCustomTabName, "사용자 정의");

            vizcore3dx.Ribbon.SetTabVisible(DefaultCustomTabName, true);

            HideDefaultTabs();
            ClearSelectedItem();
            RefreshRibbonTrees();
            SelectTreeNode(treeCustom, DefaultCustomTabName);

            MessageBox.Show("리본 구성을 처음 상태로 되돌렸습니다.", "리본 구성 초기화", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RestoreOriginalTabOrder()
        {
            for (int i = 0; i < originalTabOrder.Count; i++)
                vizcore3dx.Ribbon.MoveTab(originalTabOrder[i], i);
        }

        // ================================================================
        // 탭 순서 변경 : MoveTab
        // ================================================================
        private void btnMoveTabLeft_Click(object sender, EventArgs e)
        {
            MoveSelectedTab(-1);
        }

        private void btnMoveTabRight_Click(object sender, EventArgs e)
        {
            MoveSelectedTab(1);
        }

        private void MoveSelectedTab(int offset)
        {
            if (selectedRibbonType != RibbonNodeType.Tab || string.IsNullOrEmpty(selectedRibbonName))
            {
                MessageBox.Show("순서를 바꿀 탭을 선택하세요.", "탭 순서", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<string> tabNames = vizcore3dx.Ribbon.GetTabNames();
            int index = tabNames.IndexOf(selectedRibbonName) + offset;
            if (index < 0 || index >= tabNames.Count) return;

            string name = selectedRibbonName;
            vizcore3dx.Ribbon.MoveTab(name, index);

            RefreshRibbonTrees();
            SelectTreeNode(treeCustom, name);
        }

        // ================================================================
        // 빠른 실행 도구 모음 : AddQuickAccessItem / RemoveQuickAccessItem / ShowQuickAccessDialog
        // ================================================================
        private void btnAddQuickAccess_Click(object sender, EventArgs e)
        {
            if (selectedRibbonType != RibbonNodeType.Item || string.IsNullOrEmpty(selectedRibbonName))
            {
                MessageBox.Show("빠른 실행에 추가할 기능을 선택하세요.", "빠른 실행", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (vizcore3dx.Ribbon.AddQuickAccessItem(selectedRibbonName) == false)
                MessageBox.Show("빠른 실행에 추가하지 못했습니다.", "빠른 실행", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnRemoveQuickAccess_Click(object sender, EventArgs e)
        {
            if (selectedRibbonType != RibbonNodeType.Item || string.IsNullOrEmpty(selectedRibbonName)) return;

            if (vizcore3dx.Ribbon.GetQuickAccessItems().Contains(selectedRibbonName) == false)
            {
                MessageBox.Show("빠른 실행에 등록되지 않은 기능입니다.", "빠른 실행", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            vizcore3dx.Ribbon.RemoveQuickAccessItem(selectedRibbonName);
        }

        private void btnQuickAccessDialog_Click(object sender, EventArgs e)
        {
            // 확인 시 적용되고 사용자 설정 파일에 저장됨
            vizcore3dx.Ribbon.ShowQuickAccessDialog();
        }

        // ================================================================
        // 사용자 정의 버튼 추가 : AddButton
        // ================================================================
        private void btnAddButton_Click(object sender, EventArgs e)
        {
            string groupName = GetSelectedCustomGroupName();

            if (string.IsNullOrEmpty(groupName))
            {
                MessageBox.Show("버튼을 추가할 사용자 정의 그룹을 선택하세요.", "버튼 추가", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string text = txtNewRibbonName.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("추가할 버튼의 표시 이름을 입력하세요.", "버튼 추가", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string name = string.Format("{0}.button{1}", groupName, customButtonIndex++);

            // 클릭 시 동작은 호스트(예제)에서 지정
            object button = vizcore3dx.Ribbon.AddButton(groupName, name, text, null, VIZCore3DX.NET.Controls.Ribbon.RibbonItemSize.Large,
                (s, args) => MessageBox.Show(string.Format("[{0}] 버튼을 눌렀습니다.", text), "사용자 정의 버튼", MessageBoxButtons.OK, MessageBoxIcon.Information));

            if (button == null)
            {
                MessageBox.Show("버튼을 추가하지 못했습니다.", "버튼 추가", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtNewRibbonName.Clear();

            RefreshRibbonTrees();
            SelectTreeNode(treeCustom, name);
        }

        private void RestoreOriginalGroups()
        {
            List<RibbonGroupOrigin> origins = new List<RibbonGroupOrigin>(groupOrigins.Values);

            origins.Sort(delegate (RibbonGroupOrigin x, RibbonGroupOrigin y)
            {
                int tabCompare = string.Compare(x.TabName, y.TabName, StringComparison.OrdinalIgnoreCase);

                if (tabCompare != 0) return tabCompare;

                return x.Index.CompareTo(y.Index);
            });

            foreach (RibbonGroupOrigin origin in origins)
            {
                string currentTab = vizcore3dx.Ribbon.GetParentTabName(origin.GroupName);

                if (string.IsNullOrEmpty(currentTab)) continue;
                if (currentTab == origin.TabName && vizcore3dx.Ribbon.GetGroupNames(origin.TabName).IndexOf(origin.GroupName) == origin.Index) continue;

                vizcore3dx.Ribbon.MoveGroup(origin.GroupName, origin.TabName, origin.Index);
            }
        }

        private void RestoreOriginalItems()
        {
            foreach (KeyValuePair<string, RibbonItemOrigin> pair in GetOrderedOriginalItems())
            {
                string itemName = pair.Key;
                RibbonItemOrigin origin = pair.Value;
                string currentGroup = vizcore3dx.Ribbon.GetParentGroupName(itemName);

                if (string.IsNullOrEmpty(currentGroup)) continue;

                int currentIndex = vizcore3dx.Ribbon.GetGroupItemNames(origin.GroupName).IndexOf(itemName);

                if (currentGroup == origin.GroupName && currentIndex == origin.Index) continue;

                vizcore3dx.Ribbon.MoveItem(itemName, origin.GroupName, origin.Index);
            }
        }

        private List<KeyValuePair<string, RibbonItemOrigin>> GetOrderedOriginalItems()
        {
            List<KeyValuePair<string, RibbonItemOrigin>> items = new List<KeyValuePair<string, RibbonItemOrigin>>(itemOrigins);

            items.Sort(delegate (KeyValuePair<string, RibbonItemOrigin> x, KeyValuePair<string, RibbonItemOrigin> y)
            {
                int groupCompare = string.Compare(x.Value.GroupName, y.Value.GroupName, StringComparison.OrdinalIgnoreCase);

                if (groupCompare != 0) return groupCompare;

                return x.Value.Index.CompareTo(y.Value.Index);
            });

            return items;
        }

        private void RestoreOriginalProperties()
        {
            foreach (KeyValuePair<string, RibbonGroupOrigin> pair in groupOrigins)
            {
                vizcore3dx.Ribbon.SetGroupText(pair.Key, pair.Value.Text);
                vizcore3dx.Ribbon.SetGroupVisible(pair.Key, pair.Value.Visible);
            }

            foreach (KeyValuePair<string, RibbonItemOrigin> pair in itemOrigins)
            {
                vizcore3dx.Ribbon.SetItemText(pair.Key, pair.Value.Text);
                vizcore3dx.Ribbon.SetItemVisible(pair.Key, pair.Value.Visible);

                if (pair.Value.HasSize) vizcore3dx.Ribbon.SetItemSize(pair.Key, pair.Value.Size);
            }
        }

        private void RemoveCustomRibbonStructures()
        {
            object ribbon = GetRibbonControlLocal();
            IList tabs = GetCollectionLocal(ribbon, "Tabs");

            if (tabs == null) return;

            object defaultCustomTab = FindTabLocal(DefaultCustomTabName);

            if (defaultCustomTab != null)
            {
                IList groups = GetCollectionLocal(defaultCustomTab, "Groups");

                if (groups != null) groups.Clear();
            }

            for (int i = tabs.Count - 1; i >= 0; i--)
            {
                object tab = tabs[i];
                string tabName = GetObjectNameLocal(tab);

                if (!customTabNames.Contains(tabName)) continue;
                if (string.Equals(tabName, DefaultCustomTabName, StringComparison.OrdinalIgnoreCase)) continue;

                tabs.RemoveAt(i);
            }

            RefreshRibbonLayoutLocal();
        }

        private void ClearSelectedItem()
        {
            selectedRibbonName = string.Empty;
            lblSelectedTypeValue.Text = "-";
            txtSelectedParent.Clear();
            txtSelectedName.Clear();
            txtSelectedText.Clear();
            txtSelectedText.Enabled = false;
            rdoVisible.Checked = false;
            rdoHidden.Checked = false;
            rdoLarge.Checked = false;
            rdoSmall.Checked = false;
            btnApplySelected.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshRibbonTrees();
        }

        private void chkRibbonMode_CheckedChanged(object sender, EventArgs e)
        {
            if (vizcore3dx == null) return;

            vizcore3dx.RibbonMode = chkRibbonMode.Checked;
        }

        private void cmbRibbonTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vizcore3dx == null || cmbRibbonTheme.SelectedItem == null) return;

            vizcore3dx.RibbonTheme = (VIZCore3DX.NET.Controls.Ribbon.RibbonTheme)cmbRibbonTheme.SelectedItem;
        }

        #region 공개 API가 없는 기능 (사용자 정의 탭 제거 / 탭 표시 텍스트 조회)

        private object GetRibbonControlLocal()
        {
            return FindRibbonControlRecursive(vizcore3dx);
        }

        private object FindRibbonControlRecursive(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control.GetType().FullName == "VIZCore3DX.NET.Controls.Ribbon.RibbonControl") return control;

                object result = FindRibbonControlRecursive(control);

                if (result != null) return result;
            }

            return null;
        }

        private IList GetCollectionLocal(object target, string propertyName)
        {
            if (target == null) return null;

            PropertyInfo property = target.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (property == null) return null;

            return property.GetValue(target, null) as IList;
        }

        private string GetObjectNameLocal(object target)
        {
            if (target == null) return string.Empty;

            PropertyInfo property = target.GetType().GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (property == null) return string.Empty;

            object value = property.GetValue(target, null);

            return value != null ? value.ToString() : string.Empty;
        }

        private string GetObjectTextLocal(object target)
        {
            if (target == null) return string.Empty;

            PropertyInfo property = target.GetType().GetProperty("Text", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (property == null) return string.Empty;

            object value = property.GetValue(target, null);

            return value != null ? value.ToString() : string.Empty;
        }

        private object FindTabLocal(string tabName)
        {
            object ribbon = GetRibbonControlLocal();
            IList tabs = GetCollectionLocal(ribbon, "Tabs");

            if (tabs == null) return null;

            foreach (object tab in tabs)
            {
                if (string.Equals(GetObjectNameLocal(tab), tabName, StringComparison.OrdinalIgnoreCase)) return tab;
            }

            return null;
        }

        private string GetTabTextLocal(string tabName)
        {
            return GetObjectTextLocal(FindTabLocal(tabName));
        }

        private void RefreshRibbonLayoutLocal()
        {
            object ribbon = GetRibbonControlLocal();

            if (ribbon == null) return;

            MethodInfo method = ribbon.GetType().GetMethod("RefreshLayout", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (method != null) method.Invoke(ribbon, null);
        }

        #endregion
    }
}