namespace VIZCore3DX.NET.ClashSweep
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
            this.dgvScreening = new System.Windows.Forms.DataGridView();
            this.colScrTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScrVerdict = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScrFree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScrMaxDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnToMovingTest = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.dgvDirections = new System.Windows.Forms.DataGridView();
            this.colDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlocker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpRun = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRunMany = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.grpSetup = new System.Windows.Forms.GroupBox();
            this.btnInvalidate = new System.Windows.Forms.Button();
            this.chkUseCache = new System.Windows.Forms.CheckBox();
            this.cmbDirections = new System.Windows.Forms.ComboBox();
            this.lblDirections = new System.Windows.Forms.Label();
            this.numSpacing = new System.Windows.Forms.NumericUpDown();
            this.lblSpacing = new System.Windows.Forms.Label();
            this.numMaxDistance = new System.Windows.Forms.NumericUpDown();
            this.lblMaxDistance = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScreening)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).BeginInit();
            this.grpRun.SuspendLayout();
            this.grpSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDistance)).BeginInit();
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
            this.grpResult.Controls.Add(this.dgvScreening);
            this.grpResult.Controls.Add(this.btnToMovingTest);
            this.grpResult.Controls.Add(this.btnShowAll);
            this.grpResult.Controls.Add(this.dgvDirections);
            this.grpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResult.Location = new System.Drawing.Point(8, 316);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(344, 394);
            this.grpResult.TabIndex = 3;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "4. 결과";
            //
            // dgvScreening
            //
            this.dgvScreening.AllowUserToAddRows = false;
            this.dgvScreening.AllowUserToDeleteRows = false;
            this.dgvScreening.AllowUserToResizeRows = false;
            this.dgvScreening.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvScreening.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvScreening.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScreening.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colScrTarget,
            this.colScrVerdict,
            this.colScrFree,
            this.colScrMaxDistance});
            this.dgvScreening.Location = new System.Drawing.Point(10, 206);
            this.dgvScreening.MultiSelect = false;
            this.dgvScreening.Name = "dgvScreening";
            this.dgvScreening.ReadOnly = true;
            this.dgvScreening.RowHeadersVisible = false;
            this.dgvScreening.RowTemplate.Height = 23;
            this.dgvScreening.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvScreening.Size = new System.Drawing.Size(324, 176);
            this.dgvScreening.TabIndex = 3;
            this.dgvScreening.SelectionChanged += new System.EventHandler(this.dgvScreening_SelectionChanged);
            //
            // colScrTarget
            //
            this.colScrTarget.FillWeight = 140F;
            this.colScrTarget.HeaderText = "대상";
            this.colScrTarget.Name = "colScrTarget";
            this.colScrTarget.ReadOnly = true;
            //
            // colScrVerdict
            //
            this.colScrVerdict.FillWeight = 60F;
            this.colScrVerdict.HeaderText = "판정";
            this.colScrVerdict.Name = "colScrVerdict";
            this.colScrVerdict.ReadOnly = true;
            //
            // colScrFree
            //
            this.colScrFree.FillWeight = 60F;
            this.colScrFree.HeaderText = "통과 방향";
            this.colScrFree.Name = "colScrFree";
            this.colScrFree.ReadOnly = true;
            //
            // colScrMaxDistance
            //
            this.colScrMaxDistance.FillWeight = 80F;
            this.colScrMaxDistance.HeaderText = "최대 거리(mm)";
            this.colScrMaxDistance.Name = "colScrMaxDistance";
            this.colScrMaxDistance.ReadOnly = true;
            //
            // btnToMovingTest
            //
            this.btnToMovingTest.Location = new System.Drawing.Point(140, 176);
            this.btnToMovingTest.Name = "btnToMovingTest";
            this.btnToMovingTest.Size = new System.Drawing.Size(180, 23);
            this.btnToMovingTest.TabIndex = 2;
            this.btnToMovingTest.Text = "이동 검사로 넘기기";
            this.btnToMovingTest.UseVisualStyleBackColor = true;
            this.btnToMovingTest.Click += new System.EventHandler(this.btnToMovingTest_Click);
            //
            // btnShowAll
            //
            this.btnShowAll.Location = new System.Drawing.Point(10, 176);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(120, 23);
            this.btnShowAll.TabIndex = 1;
            this.btnShowAll.Text = "전체 방향 표시";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            //
            // dgvDirections
            //
            this.dgvDirections.AllowUserToAddRows = false;
            this.dgvDirections.AllowUserToDeleteRows = false;
            this.dgvDirections.AllowUserToResizeRows = false;
            this.dgvDirections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDirections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDirections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDirections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDirection,
            this.colFree,
            this.colDistance,
            this.colBlocker});
            this.dgvDirections.Location = new System.Drawing.Point(10, 20);
            this.dgvDirections.MultiSelect = false;
            this.dgvDirections.Name = "dgvDirections";
            this.dgvDirections.ReadOnly = true;
            this.dgvDirections.RowHeadersVisible = false;
            this.dgvDirections.RowTemplate.Height = 23;
            this.dgvDirections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDirections.Size = new System.Drawing.Size(324, 150);
            this.dgvDirections.TabIndex = 0;
            this.dgvDirections.SelectionChanged += new System.EventHandler(this.dgvDirections_SelectionChanged);
            //
            // colDirection
            //
            this.colDirection.FillWeight = 80F;
            this.colDirection.HeaderText = "방향";
            this.colDirection.Name = "colDirection";
            this.colDirection.ReadOnly = true;
            //
            // colFree
            //
            this.colFree.FillWeight = 50F;
            this.colFree.HeaderText = "통과";
            this.colFree.Name = "colFree";
            this.colFree.ReadOnly = true;
            //
            // colDistance
            //
            this.colDistance.FillWeight = 70F;
            this.colDistance.HeaderText = "거리(mm)";
            this.colDistance.Name = "colDistance";
            this.colDistance.ReadOnly = true;
            //
            // colBlocker
            //
            this.colBlocker.FillWeight = 140F;
            this.colBlocker.HeaderText = "막는 개체";
            this.colBlocker.Name = "colBlocker";
            this.colBlocker.ReadOnly = true;
            //
            // grpRun
            //
            this.grpRun.Controls.Add(this.progressBar);
            this.grpRun.Controls.Add(this.btnCancel);
            this.grpRun.Controls.Add(this.btnRunMany);
            this.grpRun.Controls.Add(this.btnRun);
            this.grpRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRun.Location = new System.Drawing.Point(8, 224);
            this.grpRun.Name = "grpRun";
            this.grpRun.Size = new System.Drawing.Size(344, 92);
            this.grpRun.TabIndex = 2;
            this.grpRun.TabStop = false;
            this.grpRun.Text = "3. 실행";
            //
            // progressBar
            //
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(10, 52);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(240, 23);
            this.progressBar.TabIndex = 2;
            //
            // btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(254, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnRunMany
            //
            this.btnRunMany.Location = new System.Drawing.Point(174, 20);
            this.btnRunMany.Name = "btnRunMany";
            this.btnRunMany.Size = new System.Drawing.Size(160, 23);
            this.btnRunMany.TabIndex = 1;
            this.btnRunMany.Text = "일괄 검사(스크리닝)";
            this.btnRunMany.UseVisualStyleBackColor = true;
            this.btnRunMany.Click += new System.EventHandler(this.btnRunMany_Click);
            //
            // btnRun
            //
            this.btnRun.Location = new System.Drawing.Point(10, 20);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(160, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "선택 노드 검사";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            //
            // grpSetup
            //
            this.grpSetup.Controls.Add(this.btnInvalidate);
            this.grpSetup.Controls.Add(this.chkUseCache);
            this.grpSetup.Controls.Add(this.cmbDirections);
            this.grpSetup.Controls.Add(this.lblDirections);
            this.grpSetup.Controls.Add(this.numSpacing);
            this.grpSetup.Controls.Add(this.lblSpacing);
            this.grpSetup.Controls.Add(this.numMaxDistance);
            this.grpSetup.Controls.Add(this.lblMaxDistance);
            this.grpSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSetup.Location = new System.Drawing.Point(8, 104);
            this.grpSetup.Name = "grpSetup";
            this.grpSetup.Size = new System.Drawing.Size(344, 120);
            this.grpSetup.TabIndex = 1;
            this.grpSetup.TabStop = false;
            this.grpSetup.Text = "2. 설정";
            //
            // btnInvalidate
            //
            this.btnInvalidate.Location = new System.Drawing.Point(214, 72);
            this.btnInvalidate.Name = "btnInvalidate";
            this.btnInvalidate.Size = new System.Drawing.Size(120, 23);
            this.btnInvalidate.TabIndex = 7;
            this.btnInvalidate.Text = "캐시 무효화";
            this.btnInvalidate.UseVisualStyleBackColor = true;
            this.btnInvalidate.Click += new System.EventHandler(this.btnInvalidate_Click);
            //
            // chkUseCache
            //
            this.chkUseCache.AutoSize = true;
            this.chkUseCache.Checked = true;
            this.chkUseCache.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseCache.Location = new System.Drawing.Point(10, 76);
            this.chkUseCache.Name = "chkUseCache";
            this.chkUseCache.Size = new System.Drawing.Size(116, 16);
            this.chkUseCache.TabIndex = 6;
            this.chkUseCache.Text = "장애물 캐시 사용";
            this.chkUseCache.UseVisualStyleBackColor = true;
            //
            // cmbDirections
            //
            this.cmbDirections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirections.Location = new System.Drawing.Point(100, 46);
            this.cmbDirections.Name = "cmbDirections";
            this.cmbDirections.Size = new System.Drawing.Size(120, 20);
            this.cmbDirections.TabIndex = 5;
            //
            // lblDirections
            //
            this.lblDirections.AutoSize = true;
            this.lblDirections.Location = new System.Drawing.Point(10, 49);
            this.lblDirections.Name = "lblDirections";
            this.lblDirections.Size = new System.Drawing.Size(29, 12);
            this.lblDirections.TabIndex = 4;
            this.lblDirections.Text = "방향";
            //
            // numSpacing
            //
            this.numSpacing.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSpacing.Location = new System.Drawing.Point(270, 20);
            this.numSpacing.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSpacing.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSpacing.Name = "numSpacing";
            this.numSpacing.Size = new System.Drawing.Size(64, 21);
            this.numSpacing.TabIndex = 3;
            this.numSpacing.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            //
            // lblSpacing
            //
            this.lblSpacing.AutoSize = true;
            this.lblSpacing.Location = new System.Drawing.Point(180, 23);
            this.lblSpacing.Name = "lblSpacing";
            this.lblSpacing.Size = new System.Drawing.Size(84, 12);
            this.lblSpacing.TabIndex = 2;
            this.lblSpacing.Text = "표본 간격(mm)";
            //
            // numMaxDistance
            //
            this.numMaxDistance.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numMaxDistance.Location = new System.Drawing.Point(100, 20);
            this.numMaxDistance.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxDistance.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMaxDistance.Name = "numMaxDistance";
            this.numMaxDistance.Size = new System.Drawing.Size(70, 21);
            this.numMaxDistance.TabIndex = 1;
            this.numMaxDistance.ThousandsSeparator = true;
            this.numMaxDistance.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            //
            // lblMaxDistance
            //
            this.lblMaxDistance.AutoSize = true;
            this.lblMaxDistance.Location = new System.Drawing.Point(10, 23);
            this.lblMaxDistance.Name = "lblMaxDistance";
            this.lblMaxDistance.Size = new System.Drawing.Size(84, 12);
            this.lblMaxDistance.TabIndex = 0;
            this.lblMaxDistance.Text = "최대 거리(mm)";
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
            this.lblModelHint.Text = "검사 대상은 뷰에서 선택한 노드입니다.\r\n장비 하나를 선택하면 단일 검사, 여러 개면 일괄 검사입니다.";
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
            this.grpCleanup.Controls.Add(this.btnHide);
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
            this.btnClear.Location = new System.Drawing.Point(114, 22);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "결과 지우기";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnHide
            //
            this.btnHide.Location = new System.Drawing.Point(10, 22);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(100, 23);
            this.btnHide.TabIndex = 0;
            this.btnHide.Text = "표시 지우기";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
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
            this.Text = "VIZCore3DX.NET.ClashSweep";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScreening)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).EndInit();
            this.grpRun.ResumeLayout(false);
            this.grpSetup.ResumeLayout(false);
            this.grpSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDistance)).EndInit();
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
        private System.Windows.Forms.Label lblMaxDistance;
        private System.Windows.Forms.NumericUpDown numMaxDistance;
        private System.Windows.Forms.Label lblSpacing;
        private System.Windows.Forms.NumericUpDown numSpacing;
        private System.Windows.Forms.Label lblDirections;
        private System.Windows.Forms.ComboBox cmbDirections;
        private System.Windows.Forms.CheckBox chkUseCache;
        private System.Windows.Forms.Button btnInvalidate;
        private System.Windows.Forms.GroupBox grpRun;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnRunMany;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.DataGridView dgvDirections;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFree;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlocker;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnToMovingTest;
        private System.Windows.Forms.DataGridView dgvScreening;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScrTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScrVerdict;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScrFree;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScrMaxDistance;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStatus;
    }
}
