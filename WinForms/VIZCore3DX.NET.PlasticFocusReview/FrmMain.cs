using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.PlasticFocusReview
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        private bool plasticInitializing = false;

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
            plasticInitializing = true;

            chkEnable.Checked = vizcore3dx.View.Plastic.Enable;

            vizcore3dx.View.SelectionColor = Color.Red;

            rdoSelectionColor.Checked = vizcore3dx.View.Plastic.ColorType == VIZCore3DX.NET.Data.PlasticColorTypes.SELECTION_COLOR;
            rdoObjectColor.Checked = vizcore3dx.View.Plastic.ColorType == VIZCore3DX.NET.Data.PlasticColorTypes.OBJECT_COLOR;

            cboSelectionObject3DType.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.SelectionObject3DTypes));
            cboSelectionObject3DType.SelectedItem = vizcore3dx.View.Plastic.SelectionObject3DType;

            chkSetPivot.Checked = true;

            lstPlasticNodes.DisplayMember = "NodeName";

            UpdatePlasticControlState();

            plasticInitializing = false;

            RefreshPlasticNodes();
        }

        #region Model

        private void BtnOpenModel_Click(object sender, EventArgs e)
        {
            vizcore3dx.Model.OpenFileDialog();

            RefreshPlasticNodes();
        }

        #endregion

        #region Plastic

        private void ChkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (plasticInitializing == true) return;

            vizcore3dx.View.Plastic.Enable = chkEnable.Checked;

            UpdatePlasticControlState();

            RefreshPlasticNodes();
        }

        private void RdoSelectionColor_CheckedChanged(object sender, EventArgs e)
        {
            if (plasticInitializing == true) return;
            if (rdoSelectionColor.Checked == false) return;
            if (vizcore3dx.View.Plastic.Enable == false) return;

            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            vizcore3dx.View.Plastic.ColorType = VIZCore3DX.NET.Data.PlasticColorTypes.SELECTION_COLOR;
        }

        private void RdoObjectColor_CheckedChanged(object sender, EventArgs e)
        {
            if (plasticInitializing == true) return;
            if (rdoObjectColor.Checked == false) return;
            if (vizcore3dx.View.Plastic.Enable == false) return;

            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            vizcore3dx.View.Plastic.ColorType = VIZCore3DX.NET.Data.PlasticColorTypes.OBJECT_COLOR;
        }

        private void CboSelectionObject3DType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (plasticInitializing == true) return;
            if (cboSelectionObject3DType.SelectedItem == null) return;
            if (vizcore3dx.View.Plastic.Enable == false) return;

            vizcore3dx.View.Plastic.SelectionObject3DType = (VIZCore3DX.NET.Data.SelectionObject3DTypes)cboSelectionObject3DType.SelectedItem;
        }

        private void BtnApplyPlastic_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.GetSelectedObjects().OfType<VIZCore3DX.NET.Data.Node>().ToList();

            if (nodes.Count == 0)
            {
                MessageBox.Show("모델에서 Plastic으로 검토할 노드를 먼저 선택하세요.", "Plastic Focus Review", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (vizcore3dx.View.Plastic.Enable == false)
            {
                vizcore3dx.View.Plastic.Enable = true;

                plasticInitializing = true;
                chkEnable.Checked = true;
                plasticInitializing = false;

                UpdatePlasticControlState();
            }

            vizcore3dx.View.Plastic.Select(nodes, true, chkSetPivot.Checked);

            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            RefreshPlasticNodes();
        }

        private void BtnRemovePlastic_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = lstPlasticNodes.SelectedItems.Cast<object>().OfType<VIZCore3DX.NET.Data.Node>().ToList();

            if (nodes.Count == 0)
            {
                MessageBox.Show("Plastic 목록에서 해제할 노드를 선택하세요.", "Plastic Focus Review", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            vizcore3dx.View.Plastic.Select(nodes, false, false);

            RefreshPlasticNodes();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            vizcore3dx.View.Plastic.Clear();

            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);

            RefreshPlasticNodes();
        }

        private void RefreshPlasticNodes()
        {
            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.View.Plastic.GetSelectedNode();

            lstPlasticNodes.BeginUpdate();
            lstPlasticNodes.Items.Clear();

            if (nodes != null)
            {
                foreach (VIZCore3DX.NET.Data.Node node in nodes)
                {
                    if (node == null) continue;

                    lstPlasticNodes.Items.Add(node);
                }
            }

            lstPlasticNodes.EndUpdate();

            lblPlasticCount.Text = string.Format("Plastic 노드 : {0}", nodes == null ? 0 : nodes.Count);
        }

        private void UpdatePlasticControlState()
        {
            bool enable = vizcore3dx.View.Plastic.Enable;

            rdoSelectionColor.Enabled = enable;
            rdoObjectColor.Enabled = enable;
            cboSelectionObject3DType.Enabled = enable;
        }

        #endregion
    }
}