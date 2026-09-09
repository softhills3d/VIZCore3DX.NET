using System;
using System.Drawing;
using System.Windows.Forms;

namespace VIZCore3DX.NET.MessageDashboard
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        private bool messageListRefreshing = false;

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

            InitializeMessageDashboard();
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================
            // 라이선스 파일을 통한 인증
            //vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("192.168.100.252", 8901);

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
        }

        private void InitializeVIZCore3DX()
        {
            messageListRefreshing = true;

            dgvMessage.SuspendLayout();
            dgvMessage.Rows.Clear();

            if (vizcore3dx != null && vizcore3dx.View != null && vizcore3dx.View.Message != null && vizcore3dx.View.Message.Messages != null)
            {
                foreach (VIZCore3DX.NET.Data.MessageItem message in vizcore3dx.View.Message.Messages)
                {
                    if (message == null || message.IsValid == false) continue;

                    AddMessageRow(message, message.IsVisible);
                }
            }

            dgvMessage.ClearSelection();
            dgvMessage.ResumeLayout();

            messageListRefreshing = false;
        }

        #region Message Dashboard

        private void InitializeMessageDashboard()
        {
            cboTextSize.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.TextSizeType));
            cboTextSize.SelectedItem = VIZCore3DX.NET.Data.TextSizeType.Size_24;
            pnlColor.BackColor = Color.Yellow;
        }

        private DataGridViewRow AddMessageRow(VIZCore3DX.NET.Data.MessageItem message, bool visible)
        {
            if (message == null || message.IsValid == false) return null;

            int rowIndex = dgvMessage.Rows.Add(message.Text, message.Position.X, message.Position.Y, message.TextSize, visible);
            DataGridViewRow row = dgvMessage.Rows[rowIndex];
            row.Tag = message;

            return row;
        }

        private DataGridViewRow GetSelectedMessageRow()
        {
            if (dgvMessage.SelectedRows.Count == 0) return null;

            return dgvMessage.SelectedRows[0];
        }

        private VIZCore3DX.NET.Data.MessageItem GetMessage(DataGridViewRow row)
        {
            if (row == null) return null;

            VIZCore3DX.NET.Data.MessageItem message = row.Tag as VIZCore3DX.NET.Data.MessageItem;

            if (message == null || message.IsValid == false) return null;

            return message;
        }

        private void SetVisibleCell(DataGridViewRow row, bool visible)
        {
            if (row == null) return;

            messageListRefreshing = true;
            row.Cells[colVisible.Index].Value = visible;
            messageListRefreshing = false;
        }

        private void SetAllVisibleCells(bool visible)
        {
            messageListRefreshing = true;
            dgvMessage.SuspendLayout();

            foreach (DataGridViewRow row in dgvMessage.Rows) row.Cells[colVisible.Index].Value = visible;

            dgvMessage.ResumeLayout();
            messageListRefreshing = false;
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            colorDialogMessage.Color = pnlColor.BackColor;

            if (colorDialogMessage.ShowDialog(this) != DialogResult.OK) return;

            pnlColor.BackColor = colorDialogMessage.Color;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            string text = txtMessage.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("메시지를 입력하세요.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMessage.Focus();
                return;
            }

            VIZCore3DX.NET.Data.Vector2 position = new VIZCore3DX.NET.Data.Vector2((float)nudPositionX.Value, (float)nudPositionY.Value);
            VIZCore3DX.NET.Data.TextSizeType textSize = (VIZCore3DX.NET.Data.TextSizeType)cboTextSize.SelectedItem;
            VIZCore3DX.NET.Data.MessageItem message = vizcore3dx.View.Message.Create(text, position, pnlColor.BackColor, textSize, chkShadow.Checked, chkVisible.Checked);

            if (message == null || message.IsValid == false) return;

            messageListRefreshing = true;
            DataGridViewRow row = AddMessageRow(message, chkVisible.Checked);
            messageListRefreshing = false;

            dgvMessage.ClearSelection();

            if (row != null) row.Selected = true;
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = GetSelectedMessageRow();
            VIZCore3DX.NET.Data.MessageItem message = GetMessage(row);

            if (message == null) return;

            vizcore3dx.View.Message.Show(message, true);

            SetVisibleCell(row, true);
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = GetSelectedMessageRow();
            VIZCore3DX.NET.Data.MessageItem message = GetMessage(row);

            if (message == null) return;

            vizcore3dx.View.Message.Show(message, false);

            SetVisibleCell(row, false);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = GetSelectedMessageRow();
            VIZCore3DX.NET.Data.MessageItem message = GetMessage(row);

            if (message == null) return;

            vizcore3dx.View.Message.Delete(message);

            messageListRefreshing = true;
            dgvMessage.Rows.Remove(row);
            messageListRefreshing = false;
        }

        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            if (dgvMessage.Rows.Count == 0) return;

            vizcore3dx.View.Message.ShowAll();

            SetAllVisibleCells(true);
        }

        private void BtnHideAll_Click(object sender, EventArgs e)
        {
            if (dgvMessage.Rows.Count == 0) return;

            vizcore3dx.View.Message.HideAll();

            SetAllVisibleCells(false);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (dgvMessage.Rows.Count == 0) return;

            vizcore3dx.View.Message.Clear();

            messageListRefreshing = true;
            dgvMessage.Rows.Clear();
            messageListRefreshing = false;
        }

        private void DgvMessage_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvMessage.CurrentCell == null) return;
            if (dgvMessage.CurrentCell.ColumnIndex != colVisible.Index) return;
            if (dgvMessage.IsCurrentCellDirty == false) return;

            dgvMessage.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DgvMessage_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (messageListRefreshing == true) return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != colVisible.Index) return;

            DataGridViewRow row = dgvMessage.Rows[e.RowIndex];
            VIZCore3DX.NET.Data.MessageItem message = GetMessage(row);

            if (message == null) return;

            bool visible = Convert.ToBoolean(row.Cells[colVisible.Index].Value);

            vizcore3dx.View.Message.Show(message, visible);
        }

        #endregion
    }
}