namespace VIZCore3DX.NET.FileQuery
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
            this.btnSelectNodes = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.colResultName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultNodes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpRun = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbTarget = new System.Windows.Forms.ComboBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.chkShowArea = new System.Windows.Forms.CheckBox();
            this.btnAreaFromModel = new System.Windows.Forms.Button();
            this.numMaxZ = new System.Windows.Forms.NumericUpDown();
            this.numMaxY = new System.Windows.Forms.NumericUpDown();
            this.numMaxX = new System.Windows.Forms.NumericUpDown();
            this.lblMax = new System.Windows.Forms.Label();
            this.numMinZ = new System.Windows.Forms.NumericUpDown();
            this.numMinY = new System.Windows.Forms.NumericUpDown();
            this.numMinX = new System.Windows.Forms.NumericUpDown();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.grpFiles = new System.Windows.Forms.GroupBox();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileNodes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveFiles = new System.Windows.Forms.Button();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnHideArea = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.grpRun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinX)).BeginInit();
            this.grpFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpFiles);
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
            this.grpResult.Controls.Add(this.btnSelectNodes);
            this.grpResult.Controls.Add(this.btnLoad);
            this.grpResult.Controls.Add(this.dgvResults);
            this.grpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResult.Location = new System.Drawing.Point(8, 480);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(344, 230);
            this.grpResult.TabIndex = 3;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "4. 결과";
            //
            // btnSelectNodes
            //
            this.btnSelectNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectNodes.Location = new System.Drawing.Point(136, 176);
            this.btnSelectNodes.Name = "btnSelectNodes";
            this.btnSelectNodes.Size = new System.Drawing.Size(100, 23);
            this.btnSelectNodes.TabIndex = 2;
            this.btnSelectNodes.Text = "노드 선택";
            this.btnSelectNodes.UseVisualStyleBackColor = true;
            this.btnSelectNodes.Click += new System.EventHandler(this.btnSelectNodes_Click);
            //
            // btnLoad
            //
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoad.Location = new System.Drawing.Point(10, 176);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "선택 파일 열기";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
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
            this.colResultName,
            this.colResultFormat,
            this.colResultNodes});
            this.dgvResults.Location = new System.Drawing.Point(10, 20);
            this.dgvResults.MultiSelect = true;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.RowTemplate.Height = 23;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(324, 150);
            this.dgvResults.TabIndex = 0;
            //
            // colResultName
            //
            this.colResultName.FillWeight = 160F;
            this.colResultName.HeaderText = "파일";
            this.colResultName.Name = "colResultName";
            this.colResultName.ReadOnly = true;
            //
            // colResultFormat
            //
            this.colResultFormat.FillWeight = 50F;
            this.colResultFormat.HeaderText = "형식";
            this.colResultFormat.Name = "colResultFormat";
            this.colResultFormat.ReadOnly = true;
            //
            // colResultNodes
            //
            this.colResultNodes.FillWeight = 60F;
            this.colResultNodes.HeaderText = "노드 수";
            this.colResultNodes.Name = "colResultNodes";
            this.colResultNodes.ReadOnly = true;
            //
            // grpRun
            //
            this.grpRun.Controls.Add(this.btnSearch);
            this.grpRun.Controls.Add(this.cmbTarget);
            this.grpRun.Controls.Add(this.lblTarget);
            this.grpRun.Controls.Add(this.chkShowArea);
            this.grpRun.Controls.Add(this.btnAreaFromModel);
            this.grpRun.Controls.Add(this.numMaxZ);
            this.grpRun.Controls.Add(this.numMaxY);
            this.grpRun.Controls.Add(this.numMaxX);
            this.grpRun.Controls.Add(this.lblMax);
            this.grpRun.Controls.Add(this.numMinZ);
            this.grpRun.Controls.Add(this.numMinY);
            this.grpRun.Controls.Add(this.numMinX);
            this.grpRun.Controls.Add(this.lblMin);
            this.grpRun.Controls.Add(this.lblArea);
            this.grpRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRun.Location = new System.Drawing.Point(8, 304);
            this.grpRun.Name = "grpRun";
            this.grpRun.Size = new System.Drawing.Size(344, 176);
            this.grpRun.TabIndex = 2;
            this.grpRun.TabStop = false;
            this.grpRun.Text = "3. 영역 검색";
            //
            // btnSearch
            //
            this.btnSearch.Location = new System.Drawing.Point(234, 104);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // cmbTarget
            //
            this.cmbTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarget.Location = new System.Drawing.Point(50, 105);
            this.cmbTarget.Name = "cmbTarget";
            this.cmbTarget.Size = new System.Drawing.Size(100, 20);
            this.cmbTarget.TabIndex = 12;
            //
            // lblTarget
            //
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(10, 108);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(29, 12);
            this.lblTarget.TabIndex = 11;
            this.lblTarget.Text = "대상";
            //
            // chkShowArea
            //
            this.chkShowArea.AutoSize = true;
            this.chkShowArea.Location = new System.Drawing.Point(150, 78);
            this.chkShowArea.Name = "chkShowArea";
            this.chkShowArea.Size = new System.Drawing.Size(72, 16);
            this.chkShowArea.TabIndex = 10;
            this.chkShowArea.Text = "영역 표시";
            this.chkShowArea.UseVisualStyleBackColor = true;
            this.chkShowArea.CheckedChanged += new System.EventHandler(this.chkShowArea_CheckedChanged);
            //
            // btnAreaFromModel
            //
            this.btnAreaFromModel.Location = new System.Drawing.Point(10, 74);
            this.btnAreaFromModel.Name = "btnAreaFromModel";
            this.btnAreaFromModel.Size = new System.Drawing.Size(130, 23);
            this.btnAreaFromModel.TabIndex = 9;
            this.btnAreaFromModel.Text = "모델 상자로 채우기";
            this.btnAreaFromModel.UseVisualStyleBackColor = true;
            this.btnAreaFromModel.Click += new System.EventHandler(this.btnAreaFromModel_Click);
            //
            // numMaxZ
            //
            this.numMaxZ.Location = new System.Drawing.Point(254, 46);
            this.numMaxZ.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numMaxZ.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numMaxZ.Name = "numMaxZ";
            this.numMaxZ.Size = new System.Drawing.Size(80, 21);
            this.numMaxZ.TabIndex = 8;
            this.numMaxZ.ValueChanged += new System.EventHandler(this.area_Changed);
            //
            // numMaxY
            //
            this.numMaxY.Location = new System.Drawing.Point(172, 46);
            this.numMaxY.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numMaxY.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numMaxY.Name = "numMaxY";
            this.numMaxY.Size = new System.Drawing.Size(80, 21);
            this.numMaxY.TabIndex = 7;
            this.numMaxY.ValueChanged += new System.EventHandler(this.area_Changed);
            //
            // numMaxX
            //
            this.numMaxX.Location = new System.Drawing.Point(90, 46);
            this.numMaxX.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numMaxX.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numMaxX.Name = "numMaxX";
            this.numMaxX.Size = new System.Drawing.Size(80, 21);
            this.numMaxX.TabIndex = 6;
            this.numMaxX.ValueChanged += new System.EventHandler(this.area_Changed);
            //
            // lblMax
            //
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(62, 49);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(29, 12);
            this.lblMax.TabIndex = 5;
            this.lblMax.Text = "최대";
            //
            // numMinZ
            //
            this.numMinZ.Location = new System.Drawing.Point(254, 20);
            this.numMinZ.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numMinZ.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numMinZ.Name = "numMinZ";
            this.numMinZ.Size = new System.Drawing.Size(80, 21);
            this.numMinZ.TabIndex = 4;
            this.numMinZ.ValueChanged += new System.EventHandler(this.area_Changed);
            //
            // numMinY
            //
            this.numMinY.Location = new System.Drawing.Point(172, 20);
            this.numMinY.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numMinY.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numMinY.Name = "numMinY";
            this.numMinY.Size = new System.Drawing.Size(80, 21);
            this.numMinY.TabIndex = 3;
            this.numMinY.ValueChanged += new System.EventHandler(this.area_Changed);
            //
            // numMinX
            //
            this.numMinX.Location = new System.Drawing.Point(90, 20);
            this.numMinX.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numMinX.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numMinX.Name = "numMinX";
            this.numMinX.Size = new System.Drawing.Size(80, 21);
            this.numMinX.TabIndex = 2;
            this.numMinX.ValueChanged += new System.EventHandler(this.area_Changed);
            //
            // lblMin
            //
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(62, 23);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(29, 12);
            this.lblMin.TabIndex = 1;
            this.lblMin.Text = "최소";
            //
            // lblArea
            //
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(8, 36);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(54, 12);
            this.lblArea.TabIndex = 0;
            this.lblArea.Text = "영역 (mm)";
            //
            // grpFiles
            //
            this.grpFiles.Controls.Add(this.dgvFiles);
            this.grpFiles.Controls.Add(this.btnRemoveFiles);
            this.grpFiles.Controls.Add(this.btnAddFiles);
            this.grpFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFiles.Location = new System.Drawing.Point(8, 104);
            this.grpFiles.Name = "grpFiles";
            this.grpFiles.Size = new System.Drawing.Size(344, 200);
            this.grpFiles.TabIndex = 1;
            this.grpFiles.TabStop = false;
            this.grpFiles.Text = "2. 파일";
            //
            // dgvFiles
            //
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AllowUserToResizeRows = false;
            this.dgvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFileName,
            this.colFileFormat,
            this.colFileNodes,
            this.colFileSize});
            this.dgvFiles.Location = new System.Drawing.Point(10, 50);
            this.dgvFiles.MultiSelect = false;
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.RowTemplate.Height = 23;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(324, 138);
            this.dgvFiles.TabIndex = 2;
            //
            // colFileName
            //
            this.colFileName.FillWeight = 160F;
            this.colFileName.HeaderText = "파일";
            this.colFileName.Name = "colFileName";
            this.colFileName.ReadOnly = true;
            //
            // colFileFormat
            //
            this.colFileFormat.FillWeight = 50F;
            this.colFileFormat.HeaderText = "형식";
            this.colFileFormat.Name = "colFileFormat";
            this.colFileFormat.ReadOnly = true;
            //
            // colFileNodes
            //
            this.colFileNodes.FillWeight = 60F;
            this.colFileNodes.HeaderText = "노드 수";
            this.colFileNodes.Name = "colFileNodes";
            this.colFileNodes.ReadOnly = true;
            //
            // colFileSize
            //
            this.colFileSize.FillWeight = 60F;
            this.colFileSize.HeaderText = "크기(m)";
            this.colFileSize.Name = "colFileSize";
            this.colFileSize.ReadOnly = true;
            //
            // btnRemoveFiles
            //
            this.btnRemoveFiles.Location = new System.Drawing.Point(116, 20);
            this.btnRemoveFiles.Name = "btnRemoveFiles";
            this.btnRemoveFiles.Size = new System.Drawing.Size(100, 23);
            this.btnRemoveFiles.TabIndex = 1;
            this.btnRemoveFiles.Text = "목록 비우기";
            this.btnRemoveFiles.UseVisualStyleBackColor = true;
            this.btnRemoveFiles.Click += new System.EventHandler(this.btnRemoveFiles_Click);
            //
            // btnAddFiles
            //
            this.btnAddFiles.Location = new System.Drawing.Point(10, 20);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(100, 23);
            this.btnAddFiles.TabIndex = 0;
            this.btnAddFiles.Text = "파일 추가...";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
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
            this.lblModelHint.Location = new System.Drawing.Point(10, 52);
            this.lblModelHint.Name = "lblModelHint";
            this.lblModelHint.Size = new System.Drawing.Size(320, 32);
            this.lblModelHint.TabIndex = 1;
            this.lblModelHint.Text = "모델을 열지 않아도 파일 조회는 됩니다.\r\n모델이 열려 있으면 그 상자가 검색 영역의 기본값입니다.";
            //
            // btnOpenModel
            //
            this.btnOpenModel.Location = new System.Drawing.Point(10, 20);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(120, 23);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "모델 열기";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            //
            // grpCleanup
            //
            this.grpCleanup.Controls.Add(this.btnClear);
            this.grpCleanup.Controls.Add(this.btnHideArea);
            this.grpCleanup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCleanup.Location = new System.Drawing.Point(8, 710);
            this.grpCleanup.Name = "grpCleanup";
            this.grpCleanup.Size = new System.Drawing.Size(344, 60);
            this.grpCleanup.TabIndex = 4;
            this.grpCleanup.TabStop = false;
            this.grpCleanup.Text = "5. 정리";
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(136, 22);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "전부 지우기";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnHideArea
            //
            this.btnHideArea.Location = new System.Drawing.Point(10, 22);
            this.btnHideArea.Name = "btnHideArea";
            this.btnHideArea.Size = new System.Drawing.Size(120, 23);
            this.btnHideArea.TabIndex = 0;
            this.btnHideArea.Text = "영역 표시 지우기";
            this.btnHideArea.UseVisualStyleBackColor = true;
            this.btnHideArea.Click += new System.EventHandler(this.btnHideArea_Click);
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
            this.Text = "VIZCore3DX.NET.FileQuery";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.grpRun.ResumeLayout(false);
            this.grpRun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinX)).EndInit();
            this.grpFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.grpModel.ResumeLayout(false);
            this.grpCleanup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Label lblModelHint;
        private System.Windows.Forms.GroupBox grpFiles;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Button btnRemoveFiles;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileNodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileSize;
        private System.Windows.Forms.GroupBox grpRun;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.NumericUpDown numMinX;
        private System.Windows.Forms.NumericUpDown numMinY;
        private System.Windows.Forms.NumericUpDown numMinZ;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.NumericUpDown numMaxX;
        private System.Windows.Forms.NumericUpDown numMaxY;
        private System.Windows.Forms.NumericUpDown numMaxZ;
        private System.Windows.Forms.Button btnAreaFromModel;
        private System.Windows.Forms.CheckBox chkShowArea;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.ComboBox cmbTarget;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultNodes;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSelectNodes;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.Button btnHideArea;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStatus;
    }
}
