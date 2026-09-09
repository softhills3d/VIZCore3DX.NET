namespace VIZCore3DX.NET.LockedSelect
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
            this.grpLockedList = new System.Windows.Forms.GroupBox();
            this.btnHideAll = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.dgvLockedSelect = new System.Windows.Forms.DataGridView();
            this.colNodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpLockedSelect = new System.Windows.Forms.GroupBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblCountTitle = new System.Windows.Forms.Label();
            this.btnClearLock = new System.Windows.Forms.Button();
            this.btnUnlockSelected = new System.Windows.Forms.Button();
            this.btnAddSelected = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.btnOpenModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpLockedList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLockedSelect)).BeginInit();
            this.grpLockedSelect.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpLockedList);
            this.splitContainer1.Panel1.Controls.Add(this.grpLockedSelect);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 661);
            this.splitContainer1.SplitterDistance = 394;
            this.splitContainer1.TabIndex = 0;

            // 
            // grpLockedList
            // 
            this.grpLockedList.Controls.Add(this.btnHideAll);
            this.grpLockedList.Controls.Add(this.btnShowAll);
            this.grpLockedList.Controls.Add(this.btnHide);
            this.grpLockedList.Controls.Add(this.btnShow);
            this.grpLockedList.Controls.Add(this.dgvLockedSelect);
            this.grpLockedList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLockedList.Location = new System.Drawing.Point(8, 234);
            this.grpLockedList.Name = "grpLockedList";
            this.grpLockedList.Size = new System.Drawing.Size(378, 419);
            this.grpLockedList.TabIndex = 2;
            this.grpLockedList.TabStop = false;
            this.grpLockedList.Text = "Locked Object List";

            // 
            // btnHideAll
            // 
            this.btnHideAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHideAll.Location = new System.Drawing.Point(194, 378);
            this.btnHideAll.Name = "btnHideAll";
            this.btnHideAll.Size = new System.Drawing.Size(165, 23);
            this.btnHideAll.TabIndex = 4;
            this.btnHideAll.Text = "Hide All";
            this.btnHideAll.UseVisualStyleBackColor = true;
            this.btnHideAll.Click += new System.EventHandler(this.BtnHideAll_Click);

            // 
            // btnShowAll
            // 
            this.btnShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowAll.Location = new System.Drawing.Point(18, 378);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(165, 23);
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.BtnShowAll_Click);

            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHide.Location = new System.Drawing.Point(194, 346);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(165, 23);
            this.btnHide.TabIndex = 2;
            this.btnHide.Text = "Hide Selected";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.BtnHide_Click);

            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShow.Location = new System.Drawing.Point(18, 346);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(165, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show Selected";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.BtnShow_Click);

            // 
            // dgvLockedSelect
            // 
            this.dgvLockedSelect.AllowUserToAddRows = false;
            this.dgvLockedSelect.AllowUserToDeleteRows = false;
            this.dgvLockedSelect.AllowUserToResizeRows = false;
            this.dgvLockedSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLockedSelect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLockedSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLockedSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colNodeName, this.colKind, this.colVisible });
            this.dgvLockedSelect.Location = new System.Drawing.Point(18, 25);
            this.dgvLockedSelect.Name = "dgvLockedSelect";
            this.dgvLockedSelect.RowHeadersVisible = false;
            this.dgvLockedSelect.RowTemplate.Height = 23;
            this.dgvLockedSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLockedSelect.Size = new System.Drawing.Size(341, 302);
            this.dgvLockedSelect.TabIndex = 0;
            this.dgvLockedSelect.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLockedSelect_CellValueChanged);
            this.dgvLockedSelect.CurrentCellDirtyStateChanged += new System.EventHandler(this.DgvLockedSelect_CurrentCellDirtyStateChanged);

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
            // colVisible
            // 
            this.colVisible.FillWeight = 70F;
            this.colVisible.HeaderText = "Visible";
            this.colVisible.Name = "colVisible";

            // 
            // grpLockedSelect
            // 
            this.grpLockedSelect.Controls.Add(this.lblCount);
            this.grpLockedSelect.Controls.Add(this.lblCountTitle);
            this.grpLockedSelect.Controls.Add(this.btnClearLock);
            this.grpLockedSelect.Controls.Add(this.btnUnlockSelected);
            this.grpLockedSelect.Controls.Add(this.btnAddSelected);
            this.grpLockedSelect.Controls.Add(this.lblDescription);
            this.grpLockedSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLockedSelect.Location = new System.Drawing.Point(8, 78);
            this.grpLockedSelect.Name = "grpLockedSelect";
            this.grpLockedSelect.Size = new System.Drawing.Size(378, 156);
            this.grpLockedSelect.TabIndex = 1;
            this.grpLockedSelect.TabStop = false;
            this.grpLockedSelect.Text = "Locked Select";

            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(68, 132);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(11, 12);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "0";

            // 
            // lblCountTitle
            // 
            this.lblCountTitle.AutoSize = true;
            this.lblCountTitle.Location = new System.Drawing.Point(18, 132);
            this.lblCountTitle.Name = "lblCountTitle";
            this.lblCountTitle.Size = new System.Drawing.Size(46, 12);
            this.lblCountTitle.TabIndex = 4;
            this.lblCountTitle.Text = "Count :";

            // 
            // btnClearLock
            // 
            this.btnClearLock.Location = new System.Drawing.Point(194, 95);
            this.btnClearLock.Name = "btnClearLock";
            this.btnClearLock.Size = new System.Drawing.Size(165, 23);
            this.btnClearLock.TabIndex = 3;
            this.btnClearLock.Text = "Clear All";
            this.btnClearLock.UseVisualStyleBackColor = true;
            this.btnClearLock.Click += new System.EventHandler(this.BtnClearLock_Click);

            // 
            // btnUnlockSelected
            // 
            this.btnUnlockSelected.Location = new System.Drawing.Point(18, 95);
            this.btnUnlockSelected.Name = "btnUnlockSelected";
            this.btnUnlockSelected.Size = new System.Drawing.Size(165, 23);
            this.btnUnlockSelected.TabIndex = 2;
            this.btnUnlockSelected.Text = "Unlock Selected";
            this.btnUnlockSelected.UseVisualStyleBackColor = true;
            this.btnUnlockSelected.Click += new System.EventHandler(this.BtnUnlockSelected_Click);

            // 
            // btnAddSelected
            // 
            this.btnAddSelected.Location = new System.Drawing.Point(18, 53);
            this.btnAddSelected.Name = "btnAddSelected";
            this.btnAddSelected.Size = new System.Drawing.Size(341, 32);
            this.btnAddSelected.TabIndex = 1;
            this.btnAddSelected.Text = "Add Selected";
            this.btnAddSelected.UseVisualStyleBackColor = true;
            this.btnAddSelected.Click += new System.EventHandler(this.BtnAddSelected_Click);

            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(18, 26);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(256, 12);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "View에서 선택한 개체만 선택 고정 목록에 추가합니다.";

            // 
            // grpModel
            // 
            this.grpModel.Controls.Add(this.btnOpenModel);
            this.grpModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpModel.Location = new System.Drawing.Point(8, 8);
            this.grpModel.Name = "grpModel";
            this.grpModel.Size = new System.Drawing.Size(378, 70);
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
            this.Text = "VIZCore3DX.NET.LockedSelect";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpLockedList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLockedSelect)).EndInit();
            this.grpLockedSelect.ResumeLayout(false);
            this.grpLockedSelect.PerformLayout();
            this.grpModel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.GroupBox grpLockedSelect;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnAddSelected;
        private System.Windows.Forms.Button btnUnlockSelected;
        private System.Windows.Forms.Button btnClearLock;
        private System.Windows.Forms.Label lblCountTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.GroupBox grpLockedList;
        private System.Windows.Forms.DataGridView dgvLockedSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNodeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKind;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colVisible;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnHideAll;
    }
}