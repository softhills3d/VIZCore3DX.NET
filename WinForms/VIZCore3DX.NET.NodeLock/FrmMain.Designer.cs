namespace VIZCore3DX.NET.NodeLock
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
            this.grpNodeLockList = new System.Windows.Forms.GroupBox();
            this.dgvNodeLock = new System.Windows.Forms.DataGridView();
            this.colNodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpNodeLock = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblCountTitle = new System.Windows.Forms.Label();
            this.btnUnlockAll = new System.Windows.Forms.Button();
            this.btnUnlockSelected = new System.Windows.Forms.Button();
            this.btnLockSelected = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.btnOpenModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpNodeLockList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodeLock)).BeginInit();
            this.grpNodeLock.SuspendLayout();
            this.grpModel.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpNodeLockList);
            this.splitContainer1.Panel1.Controls.Add(this.grpNodeLock);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 661);
            this.splitContainer1.SplitterDistance = 394;
            this.splitContainer1.TabIndex = 0;
            // 
            // grpNodeLockList
            // 
            this.grpNodeLockList.Controls.Add(this.dgvNodeLock);
            this.grpNodeLockList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpNodeLockList.Location = new System.Drawing.Point(8, 203);
            this.grpNodeLockList.Name = "grpNodeLockList";
            this.grpNodeLockList.Size = new System.Drawing.Size(378, 450);
            this.grpNodeLockList.TabIndex = 2;
            this.grpNodeLockList.TabStop = false;
            this.grpNodeLockList.Text = "Locked Node List";
            // 
            // dgvNodeLock
            // 
            this.dgvNodeLock.AllowUserToAddRows = false;
            this.dgvNodeLock.AllowUserToDeleteRows = false;
            this.dgvNodeLock.AllowUserToResizeRows = false;
            this.dgvNodeLock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNodeLock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNodeLock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNodeLock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNodeName,
            this.colKind});
            this.dgvNodeLock.Location = new System.Drawing.Point(18, 25);
            this.dgvNodeLock.Name = "dgvNodeLock";
            this.dgvNodeLock.ReadOnly = true;
            this.dgvNodeLock.RowHeadersVisible = false;
            this.dgvNodeLock.RowTemplate.Height = 23;
            this.dgvNodeLock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNodeLock.Size = new System.Drawing.Size(341, 407);
            this.dgvNodeLock.TabIndex = 0;
            // 
            // colNodeName
            // 
            this.colNodeName.FillWeight = 180F;
            this.colNodeName.HeaderText = "Name";
            this.colNodeName.Name = "colNodeName";
            this.colNodeName.ReadOnly = true;
            // 
            // colKind
            // 
            this.colKind.FillWeight = 90F;
            this.colKind.HeaderText = "Kind";
            this.colKind.Name = "colKind";
            this.colKind.ReadOnly = true;
            // 
            // grpNodeLock
            // 
            this.grpNodeLock.Controls.Add(this.checkBox1);
            this.grpNodeLock.Controls.Add(this.lblCount);
            this.grpNodeLock.Controls.Add(this.lblCountTitle);
            this.grpNodeLock.Controls.Add(this.btnUnlockAll);
            this.grpNodeLock.Controls.Add(this.btnUnlockSelected);
            this.grpNodeLock.Controls.Add(this.btnLockSelected);
            this.grpNodeLock.Controls.Add(this.lblDescription);
            this.grpNodeLock.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpNodeLock.Location = new System.Drawing.Point(8, 72);
            this.grpNodeLock.Name = "grpNodeLock";
            this.grpNodeLock.Size = new System.Drawing.Size(378, 131);
            this.grpNodeLock.TabIndex = 1;
            this.grpNodeLock.TabStop = false;
            this.grpNodeLock.Text = "Node Lock";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(18, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(320, 16);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "View에서 선택한 개체만 노드 잠금 목록에 추가됩니다.";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.ckEnable_CheckedChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(66, 103);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(11, 12);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "0";
            // 
            // lblCountTitle
            // 
            this.lblCountTitle.AutoSize = true;
            this.lblCountTitle.Location = new System.Drawing.Point(16, 103);
            this.lblCountTitle.Name = "lblCountTitle";
            this.lblCountTitle.Size = new System.Drawing.Size(46, 12);
            this.lblCountTitle.TabIndex = 4;
            this.lblCountTitle.Text = "Count :";
            // 
            // btnUnlockAll
            // 
            this.btnUnlockAll.Location = new System.Drawing.Point(249, 63);
            this.btnUnlockAll.Name = "btnUnlockAll";
            this.btnUnlockAll.Size = new System.Drawing.Size(110, 23);
            this.btnUnlockAll.TabIndex = 3;
            this.btnUnlockAll.Text = "Unlock All";
            this.btnUnlockAll.UseVisualStyleBackColor = true;
            this.btnUnlockAll.Click += new System.EventHandler(this.BtnUnlockAll_Click);
            // 
            // btnUnlockSelected
            // 
            this.btnUnlockSelected.Location = new System.Drawing.Point(134, 63);
            this.btnUnlockSelected.Name = "btnUnlockSelected";
            this.btnUnlockSelected.Size = new System.Drawing.Size(110, 23);
            this.btnUnlockSelected.TabIndex = 2;
            this.btnUnlockSelected.Text = "Unlock Selected";
            this.btnUnlockSelected.UseVisualStyleBackColor = true;
            this.btnUnlockSelected.Click += new System.EventHandler(this.BtnUnlockSelected_Click);
            // 
            // btnLockSelected
            // 
            this.btnLockSelected.Location = new System.Drawing.Point(18, 63);
            this.btnLockSelected.Name = "btnLockSelected";
            this.btnLockSelected.Size = new System.Drawing.Size(110, 23);
            this.btnLockSelected.TabIndex = 1;
            this.btnLockSelected.Text = "Lock Selected";
            this.btnLockSelected.UseVisualStyleBackColor = true;
            this.btnLockSelected.Click += new System.EventHandler(this.BtnLockSelected_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(58, 27);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 12);
            this.lblDescription.TabIndex = 0;
            // 
            // grpModel
            // 
            this.grpModel.Controls.Add(this.btnOpenModel);
            this.grpModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpModel.Location = new System.Drawing.Point(8, 8);
            this.grpModel.Name = "grpModel";
            this.grpModel.Size = new System.Drawing.Size(378, 64);
            this.grpModel.TabIndex = 0;
            this.grpModel.TabStop = false;
            this.grpModel.Text = "Model";
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Location = new System.Drawing.Point(18, 24);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(120, 23);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "Open Model";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.BtnOpenModel_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.NodeLock";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpNodeLockList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodeLock)).EndInit();
            this.grpNodeLock.ResumeLayout(false);
            this.grpNodeLock.PerformLayout();
            this.grpModel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.GroupBox grpNodeLock;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnLockSelected;
        private System.Windows.Forms.Button btnUnlockSelected;
        private System.Windows.Forms.Button btnUnlockAll;
        private System.Windows.Forms.Label lblCountTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.GroupBox grpNodeLockList;
        private System.Windows.Forms.DataGridView dgvNodeLock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNodeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKind;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}