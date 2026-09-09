using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.NodeLock
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
            vizcore3dx.Object3D.NodeLock.Enable = false;
            vizcore3dx.Object3D.NodeLock.OnNodeLockChangedEvent += NodeLock_OnNodeLockChangedEvent;

            UpdateNodeLockList();
        }

        #region Node Lock
        private void ckEnable_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.Object3D.NodeLock.Enable = checkBox1.Checked;
        }

        private void UpdateNodeLockList()
        {
            dgvNodeLock.SuspendLayout();
            dgvNodeLock.Rows.Clear();

            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.NodeLock.List();

            if (nodes != null)
            {
                foreach (VIZCore3DX.NET.Data.Node node in nodes)
                {
                    if (node == null || node.IsValid == false) continue;

                    int rowIndex = dgvNodeLock.Rows.Add(node.NodeName, node.Kind);
                    dgvNodeLock.Rows[rowIndex].Tag = node;
                }
            }

            lblCount.Text = dgvNodeLock.Rows.Count.ToString();

            dgvNodeLock.ClearSelection();
            dgvNodeLock.ResumeLayout();
        }

        private List<VIZCore3DX.NET.Data.Node> GetSelectedGridNodes()
        {
            List<VIZCore3DX.NET.Data.Node> nodes = new List<VIZCore3DX.NET.Data.Node>();

            foreach (DataGridViewRow row in dgvNodeLock.SelectedRows)
            {
                VIZCore3DX.NET.Data.Node node = row.Tag as VIZCore3DX.NET.Data.Node;

                if (node == null || node.IsValid == false) continue;

                nodes.Add(node);
            }

            return nodes;
        }

        private void BtnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            UpdateNodeLockList();
        }

        private void BtnLockSelected_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);

            if (nodes == null || nodes.Count == 0)
            {
                MessageBox.Show("View에서 개체를 선택하세요.", "Node Lock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            vizcore3dx.Object3D.NodeLock.Lock(nodes);
        }

        private void BtnUnlockSelected_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = GetSelectedGridNodes();

            if (nodes.Count == 0) return;

            vizcore3dx.Object3D.NodeLock.Unlock(nodes);
        }

        private void BtnUnlockAll_Click(object sender, EventArgs e)
        {
            vizcore3dx.Object3D.NodeLock.Clear();
        }

        private void NodeLock_OnNodeLockChangedEvent(object sender, EventArgs e)
        {
            if (InvokeRequired == true)
            {
                BeginInvoke(new Action(UpdateNodeLockList));
                return;
            }

            UpdateNodeLockList();
        }

        #endregion

    }
}