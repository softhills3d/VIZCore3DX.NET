using System;
using System.Windows.Forms;

namespace VIZCore3DX.NET.MessageDashboard
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        public FrmMain()
        {
            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            InitializeComponent();
            InitializeMessageDashboard();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            splitContainer1.Panel2.Controls.Add(vizcore3dx);
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
            //VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");
            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();

            RefreshMessageList();
        }

        #region Message Dashboard

        private void InitializeMessageDashboard()
        {
            cboTextSize.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.TextSizeType));
            cboTextSize.SelectedItem = VIZCore3DX.NET.Data.TextSizeType.Size_24;
        }

        private void RefreshMessageList()
        {
            dgvMessage.SuspendLayout();
            dgvMessage.Rows.Clear();

            if (vizcore3dx.View.Message.Messages != null)
            {
                foreach (VIZCore3DX.NET.Data.MessageItem message in vizcore3dx.View.Message.Messages)
                {
                    if (message == null || message.IsValid == false) continue;

                    AddMessageRow(message);
                }
            }

            dgvMessage.ClearSelection();
            dgvMessage.ResumeLayout();
        }

        private DataGridViewRow AddMessageRow(VIZCore3DX.NET.Data.MessageItem message)
        {
            if (message == null || message.IsValid == false) return null;

            int rowIndex = dgvMessage.Rows.Add(message.Text, message.Position.X, message.Position.Y, message.TextSize, message.IsVisible);
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

        private void SetAllVisibleCells(bool visible)
        {
            foreach (DataGridViewRow row in dgvMessage.Rows) row.Cells[colVisible.Index].Value = visible;
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

            DataGridViewRow row = AddMessageRow(message);

            dgvMessage.ClearSelection();

            if (row != null) row.Selected = true;
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = GetSelectedMessageRow();
            VIZCore3DX.NET.Data.MessageItem message = GetMessage(row);

            if (message == null) return;

            vizcore3dx.View.Message.Show(message, true);
            row.Cells[colVisible.Index].Value = true;
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = GetSelectedMessageRow();
            VIZCore3DX.NET.Data.MessageItem message = GetMessage(row);

            if (message == null) return;

            vizcore3dx.View.Message.Show(message, false);
            row.Cells[colVisible.Index].Value = false;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = GetSelectedMessageRow();
            VIZCore3DX.NET.Data.MessageItem message = GetMessage(row);

            if (message == null) return;

            vizcore3dx.View.Message.Delete(message);
            dgvMessage.Rows.Remove(row);
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
            dgvMessage.Rows.Clear();
        }

        private void DgvMessage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != colVisible.Index) return;

            DataGridViewRow row = dgvMessage.Rows[e.RowIndex];
            VIZCore3DX.NET.Data.MessageItem message = GetMessage(row);

            if (message == null) return;

            bool visible = !Convert.ToBoolean(row.Cells[colVisible.Index].Value);

            vizcore3dx.View.Message.Show(message, visible);
            row.Cells[colVisible.Index].Value = visible;
        }

        #endregion

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
    }
}