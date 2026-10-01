namespace VIZCore3DX.NET.SearchSet
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
            this.btnFly = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblStrategy = new System.Windows.Forms.Label();
            this.grpRun = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRemoveSet = new System.Windows.Forms.Button();
            this.btnRunSet = new System.Windows.Forms.Button();
            this.cmbSets = new System.Windows.Forms.ComboBox();
            this.btnSaveSet = new System.Windows.Forms.Button();
            this.txtSetName = new System.Windows.Forms.TextBox();
            this.lblSetName = new System.Windows.Forms.Label();
            this.btnRunCondition = new System.Windows.Forms.Button();
            this.btnRegexSearch = new System.Windows.Forms.Button();
            this.btnQuickSearch = new System.Windows.Forms.Button();
            this.grpSetup = new System.Windows.Forms.GroupBox();
            this.chkVisibleOnly = new System.Windows.Forms.CheckBox();
            this.chkBody = new System.Windows.Forms.CheckBox();
            this.chkPart = new System.Windows.Forms.CheckBox();
            this.chkAssembly = new System.Windows.Forms.CheckBox();
            this.chkCaseSensitive = new System.Windows.Forms.CheckBox();
            this.cmbMatch = new System.Windows.Forms.ComboBox();
            this.lblMatch = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnClearResults = new System.Windows.Forms.Button();
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.grpRun.SuspendLayout();
            this.grpSetup.SuspendLayout();
            this.grpModel.SuspendLayout();
            this.grpCleanup.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpSetup);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Controls.Add(this.grpCleanup);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 800);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 0;
            //
            // grpResult
            //
            this.grpResult.Controls.Add(this.btnFly);
            this.grpResult.Controls.Add(this.btnSelectAll);
            this.grpResult.Controls.Add(this.dgvResults);
            this.grpResult.Controls.Add(this.lblStrategy);
            this.grpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResult.Location = new System.Drawing.Point(8, 404);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(344, 306);
            this.grpResult.TabIndex = 3;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "4. 결과";
            //
            // btnFly
            //
            this.btnFly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFly.Location = new System.Drawing.Point(136, 271);
            this.btnFly.Name = "btnFly";
            this.btnFly.Size = new System.Drawing.Size(120, 23);
            this.btnFly.TabIndex = 3;
            this.btnFly.Text = "카메라 이동";
            this.btnFly.UseVisualStyleBackColor = true;
            this.btnFly.Click += new System.EventHandler(this.btnFly_Click);
            //
            // btnSelectAll
            //
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(12, 271);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(120, 23);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "결과 전체 선택";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            //
            // dgvResults
            //
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colKind,
            this.colIndex});
            this.dgvResults.Location = new System.Drawing.Point(12, 40);
            this.dgvResults.MultiSelect = true;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.RowTemplate.Height = 23;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(320, 225);
            this.dgvResults.TabIndex = 1;
            this.dgvResults.SelectionChanged += new System.EventHandler(this.dgvResults_SelectionChanged);
            //
            // colName
            //
            this.colName.FillWeight = 200F;
            this.colName.HeaderText = "이름";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            //
            // colKind
            //
            this.colKind.FillWeight = 70F;
            this.colKind.HeaderText = "종류";
            this.colKind.Name = "colKind";
            this.colKind.ReadOnly = true;
            //
            // colIndex
            //
            this.colIndex.FillWeight = 60F;
            this.colIndex.HeaderText = "Index";
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            //
            // lblStrategy
            //
            this.lblStrategy.AutoSize = true;
            this.lblStrategy.Location = new System.Drawing.Point(12, 22);
            this.lblStrategy.Name = "lblStrategy";
            this.lblStrategy.Size = new System.Drawing.Size(76, 12);
            this.lblStrategy.TabIndex = 0;
            this.lblStrategy.Text = "검색 방식 : -";
            //
            // grpRun
            //
            this.grpRun.Controls.Add(this.btnImport);
            this.grpRun.Controls.Add(this.btnExport);
            this.grpRun.Controls.Add(this.btnRemoveSet);
            this.grpRun.Controls.Add(this.btnRunSet);
            this.grpRun.Controls.Add(this.cmbSets);
            this.grpRun.Controls.Add(this.btnSaveSet);
            this.grpRun.Controls.Add(this.txtSetName);
            this.grpRun.Controls.Add(this.lblSetName);
            this.grpRun.Controls.Add(this.btnRunCondition);
            this.grpRun.Controls.Add(this.btnRegexSearch);
            this.grpRun.Controls.Add(this.btnQuickSearch);
            this.grpRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRun.Location = new System.Drawing.Point(8, 274);
            this.grpRun.Name = "grpRun";
            this.grpRun.Size = new System.Drawing.Size(344, 130);
            this.grpRun.TabIndex = 2;
            this.grpRun.TabStop = false;
            this.grpRun.Text = "3. 실행";
            //
            // btnImport
            //
            this.btnImport.Location = new System.Drawing.Point(120, 95);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(104, 23);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "불러오기…";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            //
            // btnExport
            //
            this.btnExport.Location = new System.Drawing.Point(12, 95);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(104, 23);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "내보내기…";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            //
            // btnRemoveSet
            //
            this.btnRemoveSet.Enabled = false;
            this.btnRemoveSet.Location = new System.Drawing.Point(282, 70);
            this.btnRemoveSet.Name = "btnRemoveSet";
            this.btnRemoveSet.Size = new System.Drawing.Size(50, 23);
            this.btnRemoveSet.TabIndex = 8;
            this.btnRemoveSet.Text = "삭제";
            this.btnRemoveSet.UseVisualStyleBackColor = true;
            this.btnRemoveSet.Click += new System.EventHandler(this.btnRemoveSet_Click);
            //
            // btnRunSet
            //
            this.btnRunSet.Enabled = false;
            this.btnRunSet.Location = new System.Drawing.Point(228, 70);
            this.btnRunSet.Name = "btnRunSet";
            this.btnRunSet.Size = new System.Drawing.Size(50, 23);
            this.btnRunSet.TabIndex = 7;
            this.btnRunSet.Text = "실행";
            this.btnRunSet.UseVisualStyleBackColor = true;
            this.btnRunSet.Click += new System.EventHandler(this.btnRunSet_Click);
            //
            // cmbSets
            //
            this.cmbSets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSets.Location = new System.Drawing.Point(12, 71);
            this.cmbSets.Name = "cmbSets";
            this.cmbSets.Size = new System.Drawing.Size(212, 20);
            this.cmbSets.TabIndex = 6;
            this.cmbSets.SelectedIndexChanged += new System.EventHandler(this.cmbSets_SelectedIndexChanged);
            //
            // btnSaveSet
            //
            this.btnSaveSet.Location = new System.Drawing.Point(228, 45);
            this.btnSaveSet.Name = "btnSaveSet";
            this.btnSaveSet.Size = new System.Drawing.Size(104, 23);
            this.btnSaveSet.TabIndex = 5;
            this.btnSaveSet.Text = "저장";
            this.btnSaveSet.UseVisualStyleBackColor = true;
            this.btnSaveSet.Click += new System.EventHandler(this.btnSaveSet_Click);
            //
            // txtSetName
            //
            this.txtSetName.Location = new System.Drawing.Point(80, 46);
            this.txtSetName.Name = "txtSetName";
            this.txtSetName.Size = new System.Drawing.Size(144, 21);
            this.txtSetName.TabIndex = 4;
            //
            // lblSetName
            //
            this.lblSetName.AutoSize = true;
            this.lblSetName.Location = new System.Drawing.Point(12, 50);
            this.lblSetName.Name = "lblSetName";
            this.lblSetName.Size = new System.Drawing.Size(53, 12);
            this.lblSetName.TabIndex = 3;
            this.lblSetName.Text = "세트 이름";
            //
            // btnRunCondition
            //
            this.btnRunCondition.Location = new System.Drawing.Point(228, 20);
            this.btnRunCondition.Name = "btnRunCondition";
            this.btnRunCondition.Size = new System.Drawing.Size(104, 23);
            this.btnRunCondition.TabIndex = 2;
            this.btnRunCondition.Text = "조건으로 검색";
            this.btnRunCondition.UseVisualStyleBackColor = true;
            this.btnRunCondition.Click += new System.EventHandler(this.btnRunCondition_Click);
            //
            // btnRegexSearch
            //
            this.btnRegexSearch.Location = new System.Drawing.Point(120, 20);
            this.btnRegexSearch.Name = "btnRegexSearch";
            this.btnRegexSearch.Size = new System.Drawing.Size(104, 23);
            this.btnRegexSearch.TabIndex = 1;
            this.btnRegexSearch.Text = "정규식 검색";
            this.btnRegexSearch.UseVisualStyleBackColor = true;
            this.btnRegexSearch.Click += new System.EventHandler(this.btnRegexSearch_Click);
            //
            // btnQuickSearch
            //
            this.btnQuickSearch.Location = new System.Drawing.Point(12, 20);
            this.btnQuickSearch.Name = "btnQuickSearch";
            this.btnQuickSearch.Size = new System.Drawing.Size(104, 23);
            this.btnQuickSearch.TabIndex = 0;
            this.btnQuickSearch.Text = "빠른 검색";
            this.btnQuickSearch.UseVisualStyleBackColor = true;
            this.btnQuickSearch.Click += new System.EventHandler(this.btnQuickSearch_Click);
            //
            // grpSetup
            //
            this.grpSetup.Controls.Add(this.chkVisibleOnly);
            this.grpSetup.Controls.Add(this.chkBody);
            this.grpSetup.Controls.Add(this.chkPart);
            this.grpSetup.Controls.Add(this.chkAssembly);
            this.grpSetup.Controls.Add(this.chkCaseSensitive);
            this.grpSetup.Controls.Add(this.cmbMatch);
            this.grpSetup.Controls.Add(this.lblMatch);
            this.grpSetup.Controls.Add(this.txtName);
            this.grpSetup.Controls.Add(this.lblName);
            this.grpSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSetup.Location = new System.Drawing.Point(8, 104);
            this.grpSetup.Name = "grpSetup";
            this.grpSetup.Size = new System.Drawing.Size(344, 170);
            this.grpSetup.TabIndex = 1;
            this.grpSetup.TabStop = false;
            this.grpSetup.Text = "2. 검색 조건";
            //
            // chkVisibleOnly
            //
            this.chkVisibleOnly.AutoSize = true;
            this.chkVisibleOnly.Location = new System.Drawing.Point(12, 124);
            this.chkVisibleOnly.Name = "chkVisibleOnly";
            this.chkVisibleOnly.Size = new System.Drawing.Size(100, 16);
            this.chkVisibleOnly.TabIndex = 8;
            this.chkVisibleOnly.Text = "보이는 노드만";
            this.chkVisibleOnly.UseVisualStyleBackColor = true;
            //
            // chkBody
            //
            this.chkBody.AutoSize = true;
            this.chkBody.Location = new System.Drawing.Point(160, 98);
            this.chkBody.Name = "chkBody";
            this.chkBody.Size = new System.Drawing.Size(48, 16);
            this.chkBody.TabIndex = 7;
            this.chkBody.Text = "바디";
            this.chkBody.UseVisualStyleBackColor = true;
            //
            // chkPart
            //
            this.chkPart.AutoSize = true;
            this.chkPart.Checked = true;
            this.chkPart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPart.Location = new System.Drawing.Point(96, 98);
            this.chkPart.Name = "chkPart";
            this.chkPart.Size = new System.Drawing.Size(48, 16);
            this.chkPart.TabIndex = 6;
            this.chkPart.Text = "파트";
            this.chkPart.UseVisualStyleBackColor = true;
            //
            // chkAssembly
            //
            this.chkAssembly.AutoSize = true;
            this.chkAssembly.Checked = true;
            this.chkAssembly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAssembly.Location = new System.Drawing.Point(12, 98);
            this.chkAssembly.Name = "chkAssembly";
            this.chkAssembly.Size = new System.Drawing.Size(72, 16);
            this.chkAssembly.TabIndex = 5;
            this.chkAssembly.Text = "어셈블리";
            this.chkAssembly.UseVisualStyleBackColor = true;
            //
            // chkCaseSensitive
            //
            this.chkCaseSensitive.AutoSize = true;
            this.chkCaseSensitive.Location = new System.Drawing.Point(210, 70);
            this.chkCaseSensitive.Name = "chkCaseSensitive";
            this.chkCaseSensitive.Size = new System.Drawing.Size(100, 16);
            this.chkCaseSensitive.TabIndex = 4;
            this.chkCaseSensitive.Text = "대/소문자 구분";
            this.chkCaseSensitive.UseVisualStyleBackColor = true;
            //
            // cmbMatch
            //
            this.cmbMatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMatch.Location = new System.Drawing.Point(80, 68);
            this.cmbMatch.Name = "cmbMatch";
            this.cmbMatch.Size = new System.Drawing.Size(110, 20);
            this.cmbMatch.TabIndex = 3;
            //
            // lblMatch
            //
            this.lblMatch.AutoSize = true;
            this.lblMatch.Location = new System.Drawing.Point(12, 72);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(53, 12);
            this.lblMatch.TabIndex = 2;
            this.lblMatch.Text = "일치 방식";
            //
            // txtName
            //
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(12, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(320, 21);
            this.txtName.TabIndex = 1;
            //
            // lblName
            //
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(160, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "검색어(여러 개는 | 로 구분)";
            //
            // grpModel
            //
            this.grpModel.Controls.Add(this.lblModelHint);
            this.grpModel.Controls.Add(this.btnOpenModel);
            this.grpModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpModel.Location = new System.Drawing.Point(8, 8);
            this.grpModel.Name = "grpModel";
            this.grpModel.Size = new System.Drawing.Size(344, 96);
            this.grpModel.TabIndex = 0;
            this.grpModel.TabStop = false;
            this.grpModel.Text = "1. 모델";
            //
            // lblModelHint
            //
            this.lblModelHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModelHint.Location = new System.Drawing.Point(12, 54);
            this.lblModelHint.Name = "lblModelHint";
            this.lblModelHint.Size = new System.Drawing.Size(320, 32);
            this.lblModelHint.TabIndex = 1;
            this.lblModelHint.Text = "모델을 열고 검색 조건을 입력한 뒤\r\n3. 실행에서 검색하거나 저장 검색 세트로 보관합니다.";
            //
            // btnOpenModel
            //
            this.btnOpenModel.Location = new System.Drawing.Point(12, 24);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(120, 23);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "모델 열기";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            //
            // grpCleanup
            //
            this.grpCleanup.Controls.Add(this.btnClearResults);
            this.grpCleanup.Controls.Add(this.btnClearSelection);
            this.grpCleanup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCleanup.Location = new System.Drawing.Point(8, 710);
            this.grpCleanup.Name = "grpCleanup";
            this.grpCleanup.Size = new System.Drawing.Size(344, 60);
            this.grpCleanup.TabIndex = 4;
            this.grpCleanup.TabStop = false;
            this.grpCleanup.Text = "5. 정리";
            //
            // btnClearResults
            //
            this.btnClearResults.Location = new System.Drawing.Point(116, 24);
            this.btnClearResults.Name = "btnClearResults";
            this.btnClearResults.Size = new System.Drawing.Size(100, 23);
            this.btnClearResults.TabIndex = 1;
            this.btnClearResults.Text = "결과 지우기";
            this.btnClearResults.UseVisualStyleBackColor = true;
            this.btnClearResults.Click += new System.EventHandler(this.btnClearResults_Click);
            //
            // btnClearSelection
            //
            this.btnClearSelection.Location = new System.Drawing.Point(12, 24);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(100, 23);
            this.btnClearSelection.TabIndex = 0;
            this.btnClearSelection.Text = "선택 해제";
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            //
            // lblStatus
            //
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(8, 770);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(344, 22);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // FrmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.SearchSet";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpResult.ResumeLayout(false);
            this.grpResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.grpRun.ResumeLayout(false);
            this.grpRun.PerformLayout();
            this.grpSetup.ResumeLayout(false);
            this.grpSetup.PerformLayout();
            this.grpModel.ResumeLayout(false);
            this.grpModel.PerformLayout();
            this.grpCleanup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Label lblModelHint;
        private System.Windows.Forms.GroupBox grpSetup;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblMatch;
        private System.Windows.Forms.ComboBox cmbMatch;
        private System.Windows.Forms.CheckBox chkCaseSensitive;
        private System.Windows.Forms.CheckBox chkAssembly;
        private System.Windows.Forms.CheckBox chkPart;
        private System.Windows.Forms.CheckBox chkBody;
        private System.Windows.Forms.CheckBox chkVisibleOnly;
        private System.Windows.Forms.GroupBox grpRun;
        private System.Windows.Forms.Button btnQuickSearch;
        private System.Windows.Forms.Button btnRegexSearch;
        private System.Windows.Forms.Button btnRunCondition;
        private System.Windows.Forms.Label lblSetName;
        private System.Windows.Forms.TextBox txtSetName;
        private System.Windows.Forms.Button btnSaveSet;
        private System.Windows.Forms.ComboBox cmbSets;
        private System.Windows.Forms.Button btnRunSet;
        private System.Windows.Forms.Button btnRemoveSet;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.Label lblStrategy;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnFly;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.Button btnClearSelection;
        private System.Windows.Forms.Button btnClearResults;
        private System.Windows.Forms.Label lblStatus;
    }
}
