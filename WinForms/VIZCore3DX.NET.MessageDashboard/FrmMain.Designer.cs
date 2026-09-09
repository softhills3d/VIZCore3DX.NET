namespace VIZCore3DX.NET.MessageDashboard
{
    partial class FrmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpAllMessages = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnHideAll = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.grpMessageList = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.dgvMessage = new System.Windows.Forms.DataGridView();
            this.colText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTextSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpMessage = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.chkShadow = new System.Windows.Forms.CheckBox();
            this.cboTextSize = new System.Windows.Forms.ComboBox();
            this.lblTextSize = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.lblColor = new System.Windows.Forms.Label();
            this.nudPositionY = new System.Windows.Forms.NumericUpDown();
            this.lblPositionY = new System.Windows.Forms.Label();
            this.nudPositionX = new System.Windows.Forms.NumericUpDown();
            this.lblPositionX = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.colorDialogMessage = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpAllMessages.SuspendLayout();
            this.grpMessageList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessage)).BeginInit();
            this.grpMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionX)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpAllMessages);
            this.splitContainer1.Panel1.Controls.Add(this.grpMessageList);
            this.splitContainer1.Panel1.Controls.Add(this.grpMessage);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 661);
            this.splitContainer1.SplitterDistance = 394;
            this.splitContainer1.TabIndex = 0;
            // 
            // grpAllMessages
            // 
            this.grpAllMessages.Controls.Add(this.btnClear);
            this.grpAllMessages.Controls.Add(this.btnHideAll);
            this.grpAllMessages.Controls.Add(this.btnShowAll);
            this.grpAllMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAllMessages.Location = new System.Drawing.Point(8, 578);
            this.grpAllMessages.Name = "grpAllMessages";
            this.grpAllMessages.Size = new System.Drawing.Size(378, 75);
            this.grpAllMessages.TabIndex = 2;
            this.grpAllMessages.TabStop = false;
            this.grpAllMessages.Text = "All Messages";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(257, 29);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnHideAll
            // 
            this.btnHideAll.Location = new System.Drawing.Point(138, 29);
            this.btnHideAll.Name = "btnHideAll";
            this.btnHideAll.Size = new System.Drawing.Size(102, 23);
            this.btnHideAll.TabIndex = 1;
            this.btnHideAll.Text = "Hide All";
            this.btnHideAll.UseVisualStyleBackColor = true;
            this.btnHideAll.Click += new System.EventHandler(this.BtnHideAll_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(19, 29);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(102, 23);
            this.btnShowAll.TabIndex = 0;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.BtnShowAll_Click);
            // 
            // grpMessageList
            // 
            this.grpMessageList.Controls.Add(this.btnDelete);
            this.grpMessageList.Controls.Add(this.btnHide);
            this.grpMessageList.Controls.Add(this.btnShow);
            this.grpMessageList.Controls.Add(this.dgvMessage);
            this.grpMessageList.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMessageList.Location = new System.Drawing.Point(8, 260);
            this.grpMessageList.Name = "grpMessageList";
            this.grpMessageList.Size = new System.Drawing.Size(378, 318);
            this.grpMessageList.TabIndex = 1;
            this.grpMessageList.TabStop = false;
            this.grpMessageList.Text = "Message List";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(257, 280);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(138, 280);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(102, 23);
            this.btnHide.TabIndex = 2;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.BtnHide_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(19, 280);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(102, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // dgvMessage
            // 
            this.dgvMessage.AllowUserToAddRows = false;
            this.dgvMessage.AllowUserToDeleteRows = false;
            this.dgvMessage.AllowUserToResizeRows = false;
            this.dgvMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMessage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMessage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colText,
            this.colX,
            this.colY,
            this.colTextSize,
            this.colVisible});
            this.dgvMessage.Location = new System.Drawing.Point(19, 25);
            this.dgvMessage.MultiSelect = false;
            this.dgvMessage.Name = "dgvMessage";
            this.dgvMessage.RowHeadersVisible = false;
            this.dgvMessage.RowTemplate.Height = 23;
            this.dgvMessage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMessage.Size = new System.Drawing.Size(340, 243);
            this.dgvMessage.TabIndex = 0;
            this.dgvMessage.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMessage_CellValueChanged);
            this.dgvMessage.CurrentCellDirtyStateChanged += new System.EventHandler(this.DgvMessage_CurrentCellDirtyStateChanged);
            // 
            // colText
            // 
            this.colText.FillWeight = 180F;
            this.colText.HeaderText = "Text";
            this.colText.Name = "colText";
            this.colText.ReadOnly = true;
            // 
            // colX
            // 
            this.colX.FillWeight = 55F;
            this.colX.HeaderText = "X";
            this.colX.Name = "colX";
            this.colX.ReadOnly = true;
            // 
            // colY
            // 
            this.colY.FillWeight = 55F;
            this.colY.HeaderText = "Y";
            this.colY.Name = "colY";
            this.colY.ReadOnly = true;
            // 
            // colTextSize
            // 
            this.colTextSize.FillWeight = 80F;
            this.colTextSize.HeaderText = "Size";
            this.colTextSize.Name = "colTextSize";
            this.colTextSize.ReadOnly = true;
            // 
            // colVisible
            // 
            this.colVisible.FillWeight = 70F;
            this.colVisible.HeaderText = "Visible";
            this.colVisible.Name = "colVisible";
            // 
            // grpMessage
            // 
            this.grpMessage.Controls.Add(this.btnCreate);
            this.grpMessage.Controls.Add(this.chkVisible);
            this.grpMessage.Controls.Add(this.chkShadow);
            this.grpMessage.Controls.Add(this.cboTextSize);
            this.grpMessage.Controls.Add(this.lblTextSize);
            this.grpMessage.Controls.Add(this.btnColor);
            this.grpMessage.Controls.Add(this.pnlColor);
            this.grpMessage.Controls.Add(this.lblColor);
            this.grpMessage.Controls.Add(this.nudPositionY);
            this.grpMessage.Controls.Add(this.lblPositionY);
            this.grpMessage.Controls.Add(this.nudPositionX);
            this.grpMessage.Controls.Add(this.lblPositionX);
            this.grpMessage.Controls.Add(this.lblPosition);
            this.grpMessage.Controls.Add(this.txtMessage);
            this.grpMessage.Controls.Add(this.lblText);
            this.grpMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMessage.Location = new System.Drawing.Point(8, 8);
            this.grpMessage.Name = "grpMessage";
            this.grpMessage.Size = new System.Drawing.Size(378, 252);
            this.grpMessage.TabIndex = 0;
            this.grpMessage.TabStop = false;
            this.grpMessage.Text = "Message";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(266, 216);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(93, 23);
            this.btnCreate.TabIndex = 14;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Checked = true;
            this.chkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisible.Location = new System.Drawing.Point(108, 220);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(62, 16);
            this.chkVisible.TabIndex = 13;
            this.chkVisible.Text = "Visible";
            this.chkVisible.UseVisualStyleBackColor = true;
            // 
            // chkShadow
            // 
            this.chkShadow.AutoSize = true;
            this.chkShadow.Checked = true;
            this.chkShadow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShadow.Location = new System.Drawing.Point(19, 220);
            this.chkShadow.Name = "chkShadow";
            this.chkShadow.Size = new System.Drawing.Size(70, 16);
            this.chkShadow.TabIndex = 12;
            this.chkShadow.Text = "Shadow";
            this.chkShadow.UseVisualStyleBackColor = true;
            // 
            // cboTextSize
            // 
            this.cboTextSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTextSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTextSize.FormattingEnabled = true;
            this.cboTextSize.Location = new System.Drawing.Point(94, 179);
            this.cboTextSize.Name = "cboTextSize";
            this.cboTextSize.Size = new System.Drawing.Size(265, 20);
            this.cboTextSize.TabIndex = 11;
            // 
            // lblTextSize
            // 
            this.lblTextSize.AutoSize = true;
            this.lblTextSize.Location = new System.Drawing.Point(17, 183);
            this.lblTextSize.Name = "lblTextSize";
            this.lblTextSize.Size = new System.Drawing.Size(59, 12);
            this.lblTextSize.TabIndex = 10;
            this.lblTextSize.Text = "Text Size";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(138, 144);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(80, 21);
            this.btnColor.TabIndex = 9;
            this.btnColor.Text = "Select";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.BtnColor_Click);
            // 
            // pnlColor
            // 
            this.pnlColor.BackColor = System.Drawing.Color.Yellow;
            this.pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColor.Location = new System.Drawing.Point(94, 141);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(36, 24);
            this.pnlColor.TabIndex = 8;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(17, 147);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(35, 12);
            this.lblColor.TabIndex = 7;
            this.lblColor.Text = "Color";
            // 
            // nudPositionY
            // 
            this.nudPositionY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPositionY.Location = new System.Drawing.Point(213, 105);
            this.nudPositionY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPositionY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudPositionY.Name = "nudPositionY";
            this.nudPositionY.Size = new System.Drawing.Size(146, 21);
            this.nudPositionY.TabIndex = 6;
            this.nudPositionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPositionY.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblPositionY
            // 
            this.lblPositionY.AutoSize = true;
            this.lblPositionY.Location = new System.Drawing.Point(190, 109);
            this.lblPositionY.Name = "lblPositionY";
            this.lblPositionY.Size = new System.Drawing.Size(13, 12);
            this.lblPositionY.TabIndex = 5;
            this.lblPositionY.Text = "Y";
            // 
            // nudPositionX
            // 
            this.nudPositionX.Location = new System.Drawing.Point(42, 105);
            this.nudPositionX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPositionX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudPositionX.Name = "nudPositionX";
            this.nudPositionX.Size = new System.Drawing.Size(120, 21);
            this.nudPositionX.TabIndex = 4;
            this.nudPositionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPositionX.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblPositionX
            // 
            this.lblPositionX.AutoSize = true;
            this.lblPositionX.Location = new System.Drawing.Point(19, 109);
            this.lblPositionX.Name = "lblPositionX";
            this.lblPositionX.Size = new System.Drawing.Size(13, 12);
            this.lblPositionX.TabIndex = 3;
            this.lblPositionX.Text = "X";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(17, 83);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(50, 12);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "Position";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(19, 46);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(340, 21);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.Text = "VIZCore3DX.NET Message";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(17, 27);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(30, 12);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Text";
            // 
            // colorDialogMessage
            // 
            this.colorDialogMessage.FullOpen = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.MessageDashboard";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpAllMessages.ResumeLayout(false);
            this.grpMessageList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessage)).EndInit();
            this.grpMessage.ResumeLayout(false);
            this.grpMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpMessage;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblPositionX;
        private System.Windows.Forms.NumericUpDown nudPositionX;
        private System.Windows.Forms.Label lblPositionY;
        private System.Windows.Forms.NumericUpDown nudPositionY;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label lblTextSize;
        private System.Windows.Forms.ComboBox cboTextSize;
        private System.Windows.Forms.CheckBox chkShadow;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox grpMessageList;
        private System.Windows.Forms.DataGridView dgvMessage;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox grpAllMessages;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnHideAll;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ColorDialog colorDialogMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTextSize;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colVisible;
    }
}