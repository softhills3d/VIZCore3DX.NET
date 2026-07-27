using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.Group
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 현재 XRay로 표시 중인 그룹
        private GroupItem currentXRayGroup;

        // 내부 선택 처리 중 노드 이벤트 재실행 방지
        private bool suppressNodeEvent;

        private enum GroupKind
        {
            SELECTION,
            UDA,
            SEARCH
        }

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer2.Panel1.Controls.Add(vizcore3dx);

            // License
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
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
            InitializeVIZCore3DXEvent();
        }

        private void InitializeVIZCore3DX()
        {
            vizcore3dx.BeginUpdate();

            try
            {
                vizcore3dx.ToolbarMain.Visible = true;
                vizcore3dx.ToolbarNote.Visible = false;
                vizcore3dx.ToolbarMeasure.Visible = false;
                vizcore3dx.ToolbarSection.Visible = false;
                vizcore3dx.ToolbarSnapshot.Visible = false;
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.Object3D.OnNodeEvent -= Object3D_OnNodeEvent;
            vizcore3dx.Object3D.OnNodeEvent += Object3D_OnNodeEvent;
        }

        private void Object3D_OnNodeEvent(object sender, EventManager.NodeEventArgs e)
        {
            if (e == null || e.Node == null || suppressNodeEvent == true) return;

            if (e.EventKind == VIZCore3DX.NET.Manager.Object3DManager.NodeEventKind.SELECTION_CHANGED_NODE)
            {
                List<Node> selectedNodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP);

                if (selectedNodes == null || selectedNodes.Count == 0)
                {
                    txtName.Text = "Name";
                    if (currentXRayGroup != null) ClearGroupXRayMode();
                    return;
                }

                txtName.Text = string.Join(", ", selectedNodes.Where(node => node != null).Select(node => node.NodeName));

                if (currentXRayGroup != null) ClearGroupXRayMode();
            }
            else if (e.EventKind == VIZCore3DX.NET.Manager.Object3DManager.NodeEventKind.SELECTION_UNSELECTED_NODE)
            {
                txtName.Text = "Name";

                if (currentXRayGroup != null) ClearGroupXRayMode();
            }
        }

        private void ClearGroupXRayMode()
        {
            try
            {
                suppressNodeEvent = true;

                vizcore3dx.View.XRay.Clear();
                vizcore3dx.View.XRay.Enable = false;
                vizcore3dx.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);
                vizcore3dx.View.SelectionColorEnabled = true;
                vizcore3dx.View.SelectionOutlineEnabled = true;

                currentXRayGroup = null;
                dataGridNode.DataSource = null;

                for (int i = lvGroup.SelectedItems.Count - 1; i >= 0; i--)
                    lvGroup.SelectedItems[i].Selected = false;

                vizcore3dx.View.FitToView();
            }
            finally
            {
                suppressNodeEvent = false;
                vizcore3dx.Update();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string groupName = txtName.Text.Trim();
            if (string.IsNullOrEmpty(groupName)) return;

            GroupKind kind;
            List<Node> nodes;

            if (rbSelection.Checked == true)
            {
                kind = GroupKind.SELECTION;
                nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_ALL);
            }
            else if (rbSearch.Checked == true)
            {
                string keyword = txtKeyword.Text.Trim();
                if (string.IsNullOrEmpty(keyword)) return;

                kind = GroupKind.SEARCH;
                nodes = vizcore3dx.Object3D.Find.QuickSearch(new List<string> { keyword }, false, true, false, false, false);
            }
            else if (rbProperty.Checked == true)
            {
                string propertyKey = txtPropertyKey.Text.Trim();
                string propertyValue = txtPropertyValue.Text.Trim();
                if (string.IsNullOrEmpty(propertyKey) || string.IsNullOrEmpty(propertyValue)) return;

                kind = GroupKind.UDA;

                List<Node> targetNodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.ALL);
                nodes = vizcore3dx.Object3D.UDA.GetNodes(propertyKey, propertyValue, targetNodes, false);

                if (nodes == null || nodes.Count == 0)
                {
                    MessageBox.Show("입력한 Property 조건에 맞는 노드가 없습니다.", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                return;
            }

            if (nodes == null || nodes.Count == 0)
            {
                MessageBox.Show("그룹으로 생성할 노드가 없습니다.", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            GroupItem group = vizcore3dx.Object3D.Group.CreateGroup(groupName);
            if (group == null || group.IsValid == false) return;

            vizcore3dx.Object3D.Group.AddNodes(group, nodes);

            ListViewItem item = new ListViewItem(new string[] { group.Name, kind.ToString(), group.Nodes == null ? "0" : group.Nodes.Count.ToString() });
            item.Tag = group;

            lvGroup.Items.Add(item);
            item.EnsureVisible();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvGroup.SelectedItems.Count == 0) return;

            ListViewItem selectedItem = lvGroup.SelectedItems[0];
            GroupItem group = selectedItem.Tag as GroupItem;
            if (group == null) return;

            if (currentXRayGroup == group) ClearGroupXRayMode();

            vizcore3dx.Object3D.Group.DeleteGroup(group);
            lvGroup.Items.Remove(selectedItem);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearGroupXRayMode();

            vizcore3dx.Object3D.Group.ClearGroup();
            lvGroup.Items.Clear();
        }

        private void lvGroup_DoubleClick(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false || lvGroup.SelectedItems.Count == 0) return;

            GroupItem group = lvGroup.SelectedItems[0].Tag as GroupItem;
            if (group == null) return;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                suppressNodeEvent = true;

                vizcore3dx.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);
                vizcore3dx.View.XRay.Clear();
                vizcore3dx.View.XRay.Enable = false;

                dataGridNode.DataSource = null;
                dataGridNode.DataSource = group.Nodes;

                if (group.Nodes == null || group.Nodes.Count == 0)
                {
                    currentXRayGroup = null;
                    vizcore3dx.View.FitToView();
                    return;
                }

                currentXRayGroup = group;

                vizcore3dx.View.XRay.ColorType = XRayColorTypes.OBJECT_COLOR;
                vizcore3dx.View.XRay.SelectionObject3DType = SelectionObject3DTypes.ALL;
                vizcore3dx.View.XRay.EdgeRendering = true;
                vizcore3dx.View.XRay.Enable = true;
                vizcore3dx.View.XRay.Select(group.Nodes, true, false);

                vizcore3dx.View.SelectionColorEnabled = false;
                vizcore3dx.View.SelectionOutlineEnabled = false;
                vizcore3dx.View.FlyToObject3d(group.Nodes, 1.0f);

                txtName.Text = group.Name;
            }
            finally
            {
                suppressNodeEvent = false;
                this.Cursor = Cursors.Default;
                vizcore3dx.Update();
            }
        }

        private void rbSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSearch.Checked == true) txtName.Text = "Search Node";
        }

        private void rbProperty_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProperty.Checked == true) txtName.Text = "Search Property";
        }
    }
}