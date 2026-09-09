using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.LockedSelect
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;
        private bool synchronizingVisibleState;

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
            vizcore3dx.Object3D.OnObject3DVisibleChangedEvent += Object3D_OnObject3DVisibleChangedEvent;

            InitializeObjectList();
        }

        #region Locked Select

        private void InitializeObjectList()
        {
            dgvLockedSelect.Rows.Clear();
            UpdateCount();
        }

        private bool ContainsGridNode(VIZCore3DX.NET.Data.Node node)
        {
            if (node == null || node.IsValid == false) return false;

            foreach (DataGridViewRow row in dgvLockedSelect.Rows)
            {
                VIZCore3DX.NET.Data.Node gridNode = row.Tag as VIZCore3DX.NET.Data.Node;

                if (gridNode == null || gridNode.IsValid == false) continue;
                if (gridNode.EntityID == node.EntityID && gridNode.Index == node.Index) return true;
            }

            return false;
        }

        private void AddGridNode(VIZCore3DX.NET.Data.Node node)
        {
            if (node == null || node.IsValid == false) return;
            if (ContainsGridNode(node) == true) return;

            int rowIndex = dgvLockedSelect.Rows.Add(node.NodeName, node.Kind, node.Visible);
            dgvLockedSelect.Rows[rowIndex].Tag = node;
        }

        private List<VIZCore3DX.NET.Data.Node> GetSelectedGridNodes()
        {
            List<VIZCore3DX.NET.Data.Node> nodes = new List<VIZCore3DX.NET.Data.Node>();

            foreach (DataGridViewRow row in dgvLockedSelect.SelectedRows)
            {
                VIZCore3DX.NET.Data.Node node = row.Tag as VIZCore3DX.NET.Data.Node;

                if (node == null || node.IsValid == false) continue;

                nodes.Add(node);
            }

            return nodes;
        }

        private List<VIZCore3DX.NET.Data.Node> GetAllGridNodes()
        {
            List<VIZCore3DX.NET.Data.Node> nodes = new List<VIZCore3DX.NET.Data.Node>();

            foreach (DataGridViewRow row in dgvLockedSelect.Rows)
            {
                VIZCore3DX.NET.Data.Node node = row.Tag as VIZCore3DX.NET.Data.Node;

                if (node == null || node.IsValid == false) continue;

                nodes.Add(node);
            }

            return nodes;
        }

        private void UpdateCount()
        {
            lblCount.Text = dgvLockedSelect.Rows.Count.ToString();
        }

        private void UpdateVisibleRows(List<VIZCore3DX.NET.Data.Node> nodes, bool visible)
        {
            if (nodes == null || nodes.Count == 0) return;

            synchronizingVisibleState = true;
            dgvLockedSelect.SuspendLayout();

            try
            {
                foreach (DataGridViewRow row in dgvLockedSelect.Rows)
                {
                    VIZCore3DX.NET.Data.Node gridNode = row.Tag as VIZCore3DX.NET.Data.Node;

                    if (gridNode == null || gridNode.IsValid == false) continue;

                    foreach (VIZCore3DX.NET.Data.Node node in nodes)
                    {
                        if (node == null || node.IsValid == false) continue;
                        if (gridNode.EntityID != node.EntityID || gridNode.Index != node.Index) continue;

                        bool currentVisible = Convert.ToBoolean(row.Cells[colVisible.Index].Value);

                        if (currentVisible != visible) row.Cells[colVisible.Index].Value = visible;

                        break;
                    }
                }
            }
            finally
            {
                dgvLockedSelect.ResumeLayout();
                synchronizingVisibleState = false;
            }
        }

        private void SetObjectVisible(List<VIZCore3DX.NET.Data.Node> nodes, bool visible)
        {
            if (nodes == null || nodes.Count == 0) return;

            vizcore3dx.BeginUpdate();

            try
            {
                vizcore3dx.Object3D.Show(nodes, visible);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        private void BtnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            InitializeObjectList();
        }

        private void BtnAddSelected_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);

            if (nodes == null || nodes.Count == 0)
            {
                MessageBox.Show("View에서 개체를 선택하세요.", "Locked Select", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> targets = new List<VIZCore3DX.NET.Data.Node>();

            foreach (VIZCore3DX.NET.Data.Node node in nodes)
            {
                if (node == null || node.IsValid == false) continue;
                if (ContainsGridNode(node) == true) continue;

                targets.Add(node);
            }

            if (targets.Count == 0) return;

            vizcore3dx.Object3D.LockedSelect.Add(targets);

            synchronizingVisibleState = true;
            dgvLockedSelect.SuspendLayout();

            try
            {
                foreach (VIZCore3DX.NET.Data.Node node in targets)
                {
                    AddGridNode(node);
                }

                UpdateCount();
                dgvLockedSelect.ClearSelection();
            }
            finally
            {
                dgvLockedSelect.ResumeLayout();
                synchronizingVisibleState = false;
            }
        }

        private void BtnUnlockSelected_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = GetSelectedGridNodes();

            if (nodes.Count == 0) return;

            vizcore3dx.Object3D.LockedSelect.Delete(nodes);
            dgvLockedSelect.SuspendLayout();

            try
            {
                foreach (DataGridViewRow row in dgvLockedSelect.SelectedRows)
                {
                    dgvLockedSelect.Rows.Remove(row);
                }

                UpdateCount();
            }
            finally
            {
                dgvLockedSelect.ResumeLayout();
            }
        }

        private void BtnClearLock_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = GetAllGridNodes();

            if (nodes.Count == 0) return;

            vizcore3dx.Object3D.LockedSelect.Delete(nodes);
            dgvLockedSelect.Rows.Clear();
            UpdateCount();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            SetObjectVisible(GetSelectedGridNodes(), true);
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            SetObjectVisible(GetSelectedGridNodes(), false);
        }

        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            SetObjectVisible(GetAllGridNodes(), true);
        }

        private void BtnHideAll_Click(object sender, EventArgs e)
        {
            SetObjectVisible(GetAllGridNodes(), false);
        }

        private void DgvLockedSelect_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLockedSelect.CurrentCell == null) return;
            if (dgvLockedSelect.IsCurrentCellDirty == false) return;
            if (dgvLockedSelect.CurrentCell.ColumnIndex != colVisible.Index) return;

            dgvLockedSelect.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DgvLockedSelect_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (synchronizingVisibleState == true) return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != colVisible.Index) return;

            DataGridViewRow row = dgvLockedSelect.Rows[e.RowIndex];
            VIZCore3DX.NET.Data.Node node = row.Tag as VIZCore3DX.NET.Data.Node;

            if (node == null || node.IsValid == false) return;

            bool visible = Convert.ToBoolean(row.Cells[colVisible.Index].Value);
            List<VIZCore3DX.NET.Data.Node> nodes = new List<VIZCore3DX.NET.Data.Node> { node };

            SetObjectVisible(nodes, visible);
        }

        private void Object3D_OnObject3DVisibleChangedEvent(object sender, VIZCore3DX.NET.Event.EventManager.Object3DVisibleChangedEventArgs e)
        {
            if (e == null || e.Node == null || e.Node.Count == 0) return;

            List<VIZCore3DX.NET.Data.Node> nodes = new List<VIZCore3DX.NET.Data.Node>(e.Node);
            bool visible = e.Visible;

            if (IsDisposed == true || Disposing == true) return;

            if (InvokeRequired == true)
            {
                BeginInvoke(new Action(() => UpdateVisibleRows(nodes, visible)));
                return;
            }

            UpdateVisibleRows(nodes, visible);
        }

        #endregion
    }
}