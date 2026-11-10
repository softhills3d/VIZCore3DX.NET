namespace VIZCore3DX.NET.Command.Console
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
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.grpRun = new System.Windows.Forms.GroupBox();
            this.btnCatalog = new System.Windows.Forms.Button();
            this.btnContext = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtArguments = new System.Windows.Forms.TextBox();
            this.lblArguments = new System.Windows.Forms.Label();
            this.txtSchema = new System.Windows.Forms.TextBox();
            this.lblSchema = new System.Windows.Forms.Label();
            this.grpCommands = new System.Windows.Forms.GroupBox();
            this.dgvCommands = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkReadOnlyOnly = new System.Windows.Forms.CheckBox();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelGuide = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpResult.SuspendLayout();
            this.grpRun.SuspendLayout();
            this.grpCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommands)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpResult);
            this.splitContainer1.Panel1.Controls.Add(this.grpRun);
            this.splitContainer1.Panel1.Controls.Add(this.grpCommands);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 800);
            this.splitContainer1.SplitterDistance = 460;
            this.splitContainer1.TabIndex = 0;
            //
            // grpResult
            //
            this.grpResult.Controls.Add(this.txtResult);
            this.grpResult.Controls.Add(this.lblResult);
            this.grpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResult.Location = new System.Drawing.Point(8, 560);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(444, 210);
            this.grpResult.TabIndex = 3;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "4. 결과";
            //
            // txtResult
            //
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtResult.Location = new System.Drawing.Point(12, 42);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(420, 156);
            this.txtResult.TabIndex = 1;
            //
            // lblResult
            //
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 22);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(165, 12);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "실행 결과가 여기에 표시됩니다.";
            //
            // grpRun
            //
            this.grpRun.Controls.Add(this.btnCatalog);
            this.grpRun.Controls.Add(this.btnContext);
            this.grpRun.Controls.Add(this.btnExecute);
            this.grpRun.Controls.Add(this.txtArguments);
            this.grpRun.Controls.Add(this.lblArguments);
            this.grpRun.Controls.Add(this.txtSchema);
            this.grpRun.Controls.Add(this.lblSchema);
            this.grpRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRun.Location = new System.Drawing.Point(8, 340);
            this.grpRun.Name = "grpRun";
            this.grpRun.Size = new System.Drawing.Size(444, 220);
            this.grpRun.TabIndex = 2;
            this.grpRun.TabStop = false;
            this.grpRun.Text = "3. 실행";
            //
            // btnCatalog
            //
            this.btnCatalog.Location = new System.Drawing.Point(264, 182);
            this.btnCatalog.Name = "btnCatalog";
            this.btnCatalog.Size = new System.Drawing.Size(120, 28);
            this.btnCatalog.TabIndex = 6;
            this.btnCatalog.Text = "명령 목록 JSON";
            this.btnCatalog.UseVisualStyleBackColor = true;
            this.btnCatalog.Click += new System.EventHandler(this.btnCatalog_Click);
            //
            // btnContext
            //
            this.btnContext.Location = new System.Drawing.Point(138, 182);
            this.btnContext.Name = "btnContext";
            this.btnContext.Size = new System.Drawing.Size(120, 28);
            this.btnContext.TabIndex = 5;
            this.btnContext.Text = "상태 요약 보기";
            this.btnContext.UseVisualStyleBackColor = true;
            this.btnContext.Click += new System.EventHandler(this.btnContext_Click);
            //
            // btnExecute
            //
            this.btnExecute.Location = new System.Drawing.Point(12, 182);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(120, 28);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "명령 실행";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            //
            // txtArguments
            //
            this.txtArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArguments.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtArguments.Location = new System.Drawing.Point(12, 124);
            this.txtArguments.Multiline = true;
            this.txtArguments.Name = "txtArguments";
            this.txtArguments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtArguments.Size = new System.Drawing.Size(420, 50);
            this.txtArguments.TabIndex = 3;
            this.txtArguments.Text = "{}";
            //
            // lblArguments
            //
            this.lblArguments.AutoSize = true;
            this.lblArguments.Location = new System.Drawing.Point(12, 106);
            this.lblArguments.Name = "lblArguments";
            this.lblArguments.Size = new System.Drawing.Size(245, 12);
            this.lblArguments.TabIndex = 2;
            this.lblArguments.Text = "인자 (JSON 개체)   예: {\"name\":\"PIPE\"}";
            //
            // txtSchema
            //
            this.txtSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSchema.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtSchema.Location = new System.Drawing.Point(12, 40);
            this.txtSchema.Multiline = true;
            this.txtSchema.Name = "txtSchema";
            this.txtSchema.ReadOnly = true;
            this.txtSchema.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSchema.Size = new System.Drawing.Size(420, 60);
            this.txtSchema.TabIndex = 1;
            //
            // lblSchema
            //
            this.lblSchema.AutoSize = true;
            this.lblSchema.Location = new System.Drawing.Point(12, 22);
            this.lblSchema.Name = "lblSchema";
            this.lblSchema.Size = new System.Drawing.Size(145, 12);
            this.lblSchema.TabIndex = 0;
            this.lblSchema.Text = "인자 형식 (JSON Schema)";
            //
            // grpCommands
            //
            this.grpCommands.Controls.Add(this.dgvCommands);
            this.grpCommands.Controls.Add(this.chkReadOnlyOnly);
            this.grpCommands.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCommands.Location = new System.Drawing.Point(8, 104);
            this.grpCommands.Name = "grpCommands";
            this.grpCommands.Size = new System.Drawing.Size(444, 236);
            this.grpCommands.TabIndex = 1;
            this.grpCommands.TabStop = false;
            this.grpCommands.Text = "2. 명령";
            //
            // dgvCommands
            //
            this.dgvCommands.AllowUserToAddRows = false;
            this.dgvCommands.AllowUserToDeleteRows = false;
            this.dgvCommands.AllowUserToResizeRows = false;
            this.dgvCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCommands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colKind,
            this.colDescription});
            this.dgvCommands.Location = new System.Drawing.Point(12, 46);
            this.dgvCommands.MultiSelect = false;
            this.dgvCommands.Name = "dgvCommands";
            this.dgvCommands.ReadOnly = true;
            this.dgvCommands.RowHeadersVisible = false;
            this.dgvCommands.RowTemplate.Height = 23;
            this.dgvCommands.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommands.Size = new System.Drawing.Size(420, 178);
            this.dgvCommands.TabIndex = 1;
            this.dgvCommands.SelectionChanged += new System.EventHandler(this.dgvCommands_SelectionChanged);
            //
            // colName
            //
            this.colName.HeaderText = "이름";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
            //
            // colKind
            //
            this.colKind.HeaderText = "구분";
            this.colKind.Name = "colKind";
            this.colKind.ReadOnly = true;
            this.colKind.Width = 64;
            //
            // colDescription
            //
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.HeaderText = "설명";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            //
            // chkReadOnlyOnly
            //
            this.chkReadOnlyOnly.AutoSize = true;
            this.chkReadOnlyOnly.Location = new System.Drawing.Point(12, 22);
            this.chkReadOnlyOnly.Name = "chkReadOnlyOnly";
            this.chkReadOnlyOnly.Size = new System.Drawing.Size(116, 16);
            this.chkReadOnlyOnly.TabIndex = 0;
            this.chkReadOnlyOnly.Text = "조회 명령만 보기";
            this.chkReadOnlyOnly.UseVisualStyleBackColor = true;
            this.chkReadOnlyOnly.CheckedChanged += new System.EventHandler(this.chkReadOnlyOnly_CheckedChanged);
            //
            // grpModel
            //
            this.grpModel.Controls.Add(this.lblModelGuide);
            this.grpModel.Controls.Add(this.btnOpenModel);
            this.grpModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpModel.Location = new System.Drawing.Point(8, 8);
            this.grpModel.Name = "grpModel";
            this.grpModel.Size = new System.Drawing.Size(444, 96);
            this.grpModel.TabIndex = 0;
            this.grpModel.TabStop = false;
            this.grpModel.Text = "1. 모델";
            //
            // lblModelGuide
            //
            this.lblModelGuide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModelGuide.Location = new System.Drawing.Point(12, 56);
            this.lblModelGuide.Name = "lblModelGuide";
            this.lblModelGuide.Size = new System.Drawing.Size(420, 32);
            this.lblModelGuide.TabIndex = 1;
            this.lblModelGuide.Text = "AI·외부 시스템이 보내는 요청을 직접 실행해 보는 콘솔입니다.\r\n모델을 열고 명령(이름 + 인자 JSON)을 골라 실행하세요.";
            //
            // btnOpenModel
            //
            this.btnOpenModel.Location = new System.Drawing.Point(12, 22);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(120, 28);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "모델 열기";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            //
            // lblStatus
            //
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(8, 770);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(444, 22);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // FrmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.Text = "VIZCore3DX.NET.Command.Console";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpResult.ResumeLayout(false);
            this.grpResult.PerformLayout();
            this.grpRun.ResumeLayout(false);
            this.grpRun.PerformLayout();
            this.grpCommands.ResumeLayout(false);
            this.grpCommands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommands)).EndInit();
            this.grpModel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Label lblModelGuide;
        private System.Windows.Forms.GroupBox grpCommands;
        private System.Windows.Forms.CheckBox chkReadOnlyOnly;
        private System.Windows.Forms.DataGridView dgvCommands;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.GroupBox grpRun;
        private System.Windows.Forms.Label lblSchema;
        private System.Windows.Forms.TextBox txtSchema;
        private System.Windows.Forms.Label lblArguments;
        private System.Windows.Forms.TextBox txtArguments;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnContext;
        private System.Windows.Forms.Button btnCatalog;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblStatus;
    }
}
