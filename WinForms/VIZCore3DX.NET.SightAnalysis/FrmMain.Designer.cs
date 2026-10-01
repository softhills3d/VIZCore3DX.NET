namespace VIZCore3DX.NET.SightAnalysis
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
            this.dgvNodes = new System.Windows.Forms.DataGridView();
            this.colNodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNodeKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNodeHits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNodeRatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkRays = new System.Windows.Forms.CheckBox();
            this.btnUnion = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHidden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeconds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpRun = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.grpSetup = new System.Windows.Forms.GroupBox();
            this.chkUseCache = new System.Windows.Forms.CheckBox();
            this.chkRange = new System.Windows.Forms.CheckBox();
            this.numConeAngle = new System.Windows.Forms.NumericUpDown();
            this.lblConeAngle = new System.Windows.Forms.Label();
            this.cmbConeDirection = new System.Windows.Forms.ComboBox();
            this.chkCone = new System.Windows.Forms.CheckBox();
            this.numAngularStep = new System.Windows.Forms.NumericUpDown();
            this.lblAngularStep = new System.Windows.Forms.Label();
            this.numMaxDistance = new System.Windows.Forms.NumericUpDown();
            this.lblMaxDistance = new System.Windows.Forms.Label();
            this.btnDemoWall = new System.Windows.Forms.Button();
            this.btnCenter = new System.Windows.Forms.Button();
            this.numPosZ = new System.Windows.Forms.NumericUpDown();
            this.numPosY = new System.Windows.Forms.NumericUpDown();
            this.numPosX = new System.Windows.Forms.NumericUpDown();
            this.lblPosition = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnDeleteWall = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.grpRun.SuspendLayout();
            this.grpSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConeAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAngularStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).BeginInit();
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
            this.grpResult.Controls.Add(this.chkRays);
            this.grpResult.Controls.Add(this.dgvNodes);
            this.grpResult.Controls.Add(this.btnUnion);
            this.grpResult.Controls.Add(this.btnShow);
            this.grpResult.Controls.Add(this.dgvResults);
            this.grpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResult.Location = new System.Drawing.Point(8, 410);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(344, 300);
            this.grpResult.TabIndex = 3;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "4. 결과";
            //
            // dgvNodes
            //
            this.dgvNodes.AllowUserToAddRows = false;
            this.dgvNodes.AllowUserToDeleteRows = false;
            this.dgvNodes.AllowUserToResizeRows = false;
            this.dgvNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNodeName,
            this.colNodeKind,
            this.colNodeHits,
            this.colNodeRatio});
            this.dgvNodes.Location = new System.Drawing.Point(12, 184);
            this.dgvNodes.Name = "dgvNodes";
            this.dgvNodes.ReadOnly = true;
            this.dgvNodes.RowHeadersVisible = false;
            this.dgvNodes.RowTemplate.Height = 23;
            this.dgvNodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNodes.Size = new System.Drawing.Size(320, 104);
            this.dgvNodes.TabIndex = 3;
            //
            // colNodeName
            //
            this.colNodeName.FillWeight = 160F;
            this.colNodeName.HeaderText = "개체";
            this.colNodeName.Name = "colNodeName";
            this.colNodeName.ReadOnly = true;
            //
            // colNodeKind
            //
            this.colNodeKind.FillWeight = 60F;
            this.colNodeKind.HeaderText = "구분";
            this.colNodeKind.Name = "colNodeKind";
            this.colNodeKind.ReadOnly = true;
            //
            // colNodeHits
            //
            this.colNodeHits.FillWeight = 60F;
            this.colNodeHits.HeaderText = "히트";
            this.colNodeHits.Name = "colNodeHits";
            this.colNodeHits.ReadOnly = true;
            //
            // colNodeRatio
            //
            this.colNodeRatio.FillWeight = 70F;
            this.colNodeRatio.HeaderText = "비율";
            this.colNodeRatio.Name = "colNodeRatio";
            this.colNodeRatio.ReadOnly = true;
            //
            // chkRays
            //
            this.chkRays.AutoSize = true;
            this.chkRays.Checked = true;
            this.chkRays.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRays.Location = new System.Drawing.Point(262, 156);
            this.chkRays.Name = "chkRays";
            this.chkRays.Size = new System.Drawing.Size(72, 16);
            this.chkRays.TabIndex = 4;
            this.chkRays.Text = "광선 표시";
            this.chkRays.UseVisualStyleBackColor = true;
            this.chkRays.CheckedChanged += new System.EventHandler(this.chkRays_CheckedChanged);
            //
            // btnUnion
            //
            this.btnUnion.Location = new System.Drawing.Point(136, 152);
            this.btnUnion.Name = "btnUnion";
            this.btnUnion.Size = new System.Drawing.Size(120, 23);
            this.btnUnion.TabIndex = 2;
            this.btnUnion.Text = "합집합 표시";
            this.btnUnion.UseVisualStyleBackColor = true;
            this.btnUnion.Click += new System.EventHandler(this.btnUnion_Click);
            //
            // btnShow
            //
            this.btnShow.Location = new System.Drawing.Point(12, 152);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(120, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "선택 결과 표시";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            //
            // dgvResults
            //
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colRays,
            this.colHits,
            this.colVisible,
            this.colHidden,
            this.colSeconds});
            this.dgvResults.Location = new System.Drawing.Point(12, 24);
            this.dgvResults.MultiSelect = true;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.RowTemplate.Height = 23;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(320, 120);
            this.dgvResults.TabIndex = 0;
            this.dgvResults.SelectionChanged += new System.EventHandler(this.dgvResults_SelectionChanged);
            //
            // colNo
            //
            this.colNo.FillWeight = 30F;
            this.colNo.HeaderText = "#";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            //
            // colRays
            //
            this.colRays.FillWeight = 70F;
            this.colRays.HeaderText = "광선";
            this.colRays.Name = "colRays";
            this.colRays.ReadOnly = true;
            //
            // colHits
            //
            this.colHits.FillWeight = 70F;
            this.colHits.HeaderText = "히트";
            this.colHits.Name = "colHits";
            this.colHits.ReadOnly = true;
            //
            // colVisible
            //
            this.colVisible.FillWeight = 50F;
            this.colVisible.HeaderText = "보임";
            this.colVisible.Name = "colVisible";
            this.colVisible.ReadOnly = true;
            //
            // colHidden
            //
            this.colHidden.FillWeight = 50F;
            this.colHidden.HeaderText = "사각";
            this.colHidden.Name = "colHidden";
            this.colHidden.ReadOnly = true;
            //
            // colSeconds
            //
            this.colSeconds.FillWeight = 60F;
            this.colSeconds.HeaderText = "초";
            this.colSeconds.Name = "colSeconds";
            this.colSeconds.ReadOnly = true;
            //
            // grpRun
            //
            this.grpRun.Controls.Add(this.progressBar);
            this.grpRun.Controls.Add(this.btnCancel);
            this.grpRun.Controls.Add(this.btnRun);
            this.grpRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRun.Location = new System.Drawing.Point(8, 318);
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
            this.progressBar.Location = new System.Drawing.Point(12, 56);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(320, 18);
            this.progressBar.TabIndex = 2;
            //
            // btnCancel
            //
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(136, 24);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnRun
            //
            this.btnRun.Location = new System.Drawing.Point(12, 24);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(120, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "분석";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            //
            // grpSetup
            //
            this.grpSetup.Controls.Add(this.chkRange);
            this.grpSetup.Controls.Add(this.chkUseCache);
            this.grpSetup.Controls.Add(this.numConeAngle);
            this.grpSetup.Controls.Add(this.lblConeAngle);
            this.grpSetup.Controls.Add(this.cmbConeDirection);
            this.grpSetup.Controls.Add(this.chkCone);
            this.grpSetup.Controls.Add(this.numAngularStep);
            this.grpSetup.Controls.Add(this.lblAngularStep);
            this.grpSetup.Controls.Add(this.numMaxDistance);
            this.grpSetup.Controls.Add(this.lblMaxDistance);
            this.grpSetup.Controls.Add(this.btnDemoWall);
            this.grpSetup.Controls.Add(this.btnCenter);
            this.grpSetup.Controls.Add(this.numPosZ);
            this.grpSetup.Controls.Add(this.numPosY);
            this.grpSetup.Controls.Add(this.numPosX);
            this.grpSetup.Controls.Add(this.lblPosition);
            this.grpSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSetup.Location = new System.Drawing.Point(8, 104);
            this.grpSetup.Name = "grpSetup";
            this.grpSetup.Size = new System.Drawing.Size(344, 214);
            this.grpSetup.TabIndex = 1;
            this.grpSetup.TabStop = false;
            this.grpSetup.Text = "2. 설정";
            //
            // chkRange
            //
            this.chkRange.AutoSize = true;
            this.chkRange.Location = new System.Drawing.Point(288, 147);
            this.chkRange.Name = "chkRange";
            this.chkRange.Size = new System.Drawing.Size(44, 16);
            this.chkRange.TabIndex = 15;
            this.chkRange.Text = "표시";
            this.chkRange.UseVisualStyleBackColor = true;
            this.chkRange.CheckedChanged += new System.EventHandler(this.chkRange_CheckedChanged);
            //
            // chkUseCache
            //
            this.chkUseCache.AutoSize = true;
            this.chkUseCache.Checked = true;
            this.chkUseCache.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseCache.Location = new System.Drawing.Point(12, 180);
            this.chkUseCache.Name = "chkUseCache";
            this.chkUseCache.Size = new System.Drawing.Size(280, 16);
            this.chkUseCache.TabIndex = 14;
            this.chkUseCache.Text = "장애물 캐시 재사용 (개체를 옮기거나 지운 뒤에는 해제)";
            this.chkUseCache.UseVisualStyleBackColor = true;
            //
            // numConeAngle
            //
            this.numConeAngle.Enabled = false;
            this.numConeAngle.Location = new System.Drawing.Point(226, 145);
            this.numConeAngle.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numConeAngle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numConeAngle.Name = "numConeAngle";
            this.numConeAngle.Size = new System.Drawing.Size(56, 21);
            this.numConeAngle.ValueChanged += new System.EventHandler(this.setup_Changed);
            this.numConeAngle.TabIndex = 13;
            this.numConeAngle.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            //
            // lblConeAngle
            //
            this.lblConeAngle.AutoSize = true;
            this.lblConeAngle.Location = new System.Drawing.Point(176, 149);
            this.lblConeAngle.Name = "lblConeAngle";
            this.lblConeAngle.Size = new System.Drawing.Size(48, 12);
            this.lblConeAngle.TabIndex = 12;
            this.lblConeAngle.Text = "각도(°)";
            //
            // cmbConeDirection
            //
            this.cmbConeDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConeDirection.Enabled = false;
            this.cmbConeDirection.Location = new System.Drawing.Point(110, 145);
            this.cmbConeDirection.Name = "cmbConeDirection";
            this.cmbConeDirection.Size = new System.Drawing.Size(60, 20);
            this.cmbConeDirection.TabIndex = 11;
            this.cmbConeDirection.SelectedIndexChanged += new System.EventHandler(this.setup_Changed);
            //
            // chkCone
            //
            this.chkCone.AutoSize = true;
            this.chkCone.Location = new System.Drawing.Point(12, 147);
            this.chkCone.Name = "chkCone";
            this.chkCone.Size = new System.Drawing.Size(84, 16);
            this.chkCone.TabIndex = 10;
            this.chkCone.Text = "원뿔 시야";
            this.chkCone.UseVisualStyleBackColor = true;
            this.chkCone.CheckedChanged += new System.EventHandler(this.chkCone_CheckedChanged);
            //
            // numAngularStep
            //
            this.numAngularStep.DecimalPlaces = 1;
            this.numAngularStep.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numAngularStep.Location = new System.Drawing.Point(110, 114);
            this.numAngularStep.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numAngularStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numAngularStep.Name = "numAngularStep";
            this.numAngularStep.Size = new System.Drawing.Size(100, 21);
            this.numAngularStep.TabIndex = 9;
            this.numAngularStep.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            //
            // lblAngularStep
            //
            this.lblAngularStep.AutoSize = true;
            this.lblAngularStep.Location = new System.Drawing.Point(12, 118);
            this.lblAngularStep.Name = "lblAngularStep";
            this.lblAngularStep.Size = new System.Drawing.Size(76, 12);
            this.lblAngularStep.TabIndex = 8;
            this.lblAngularStep.Text = "각도 간격(°)";
            //
            // numMaxDistance
            //
            this.numMaxDistance.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMaxDistance.Location = new System.Drawing.Point(110, 86);
            this.numMaxDistance.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMaxDistance.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxDistance.Name = "numMaxDistance";
            this.numMaxDistance.Size = new System.Drawing.Size(100, 21);
            this.numMaxDistance.TabIndex = 7;
            this.numMaxDistance.ThousandsSeparator = true;
            this.numMaxDistance.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numMaxDistance.ValueChanged += new System.EventHandler(this.setup_Changed);
            //
            // lblMaxDistance
            //
            this.lblMaxDistance.AutoSize = true;
            this.lblMaxDistance.Location = new System.Drawing.Point(12, 90);
            this.lblMaxDistance.Name = "lblMaxDistance";
            this.lblMaxDistance.Size = new System.Drawing.Size(84, 12);
            this.lblMaxDistance.TabIndex = 6;
            this.lblMaxDistance.Text = "최대 거리(mm)";
            //
            // btnDemoWall
            //
            this.btnDemoWall.Location = new System.Drawing.Point(214, 52);
            this.btnDemoWall.Name = "btnDemoWall";
            this.btnDemoWall.Size = new System.Drawing.Size(120, 23);
            this.btnDemoWall.TabIndex = 5;
            this.btnDemoWall.Text = "시연 벽 생성";
            this.btnDemoWall.UseVisualStyleBackColor = true;
            this.btnDemoWall.Click += new System.EventHandler(this.btnDemoWall_Click);
            //
            // btnCenter
            //
            this.btnCenter.Location = new System.Drawing.Point(90, 52);
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.Size = new System.Drawing.Size(120, 23);
            this.btnCenter.TabIndex = 4;
            this.btnCenter.Text = "모델 중심으로";
            this.btnCenter.UseVisualStyleBackColor = true;
            this.btnCenter.Click += new System.EventHandler(this.btnCenter_Click);
            //
            // numPosZ
            //
            this.numPosZ.Location = new System.Drawing.Point(254, 24);
            this.numPosZ.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numPosZ.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numPosZ.Name = "numPosZ";
            this.numPosZ.Size = new System.Drawing.Size(80, 21);
            this.numPosZ.TabIndex = 3;
            this.numPosZ.ValueChanged += new System.EventHandler(this.setup_Changed);
            //
            // numPosY
            //
            this.numPosY.Location = new System.Drawing.Point(172, 24);
            this.numPosY.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numPosY.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numPosY.Name = "numPosY";
            this.numPosY.Size = new System.Drawing.Size(80, 21);
            this.numPosY.TabIndex = 2;
            this.numPosY.ValueChanged += new System.EventHandler(this.setup_Changed);
            //
            // numPosX
            //
            this.numPosX.Location = new System.Drawing.Point(90, 24);
            this.numPosX.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numPosX.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numPosX.Name = "numPosX";
            this.numPosX.Size = new System.Drawing.Size(80, 21);
            this.numPosX.TabIndex = 1;
            this.numPosX.ValueChanged += new System.EventHandler(this.setup_Changed);
            //
            // lblPosition
            //
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(12, 28);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(60, 12);
            this.lblPosition.TabIndex = 0;
            this.lblPosition.Text = "위치(mm)";
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
            this.lblModelHint.Text = "메시 모델을 권장합니다.\r\n첫 분석은 장애물 추출로 시간이 걸립니다.";
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
            this.grpCleanup.Controls.Add(this.btnDeleteWall);
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
            // btnDeleteWall
            //
            this.btnDeleteWall.Location = new System.Drawing.Point(220, 24);
            this.btnDeleteWall.Name = "btnDeleteWall";
            this.btnDeleteWall.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteWall.TabIndex = 2;
            this.btnDeleteWall.Text = "시연 벽 삭제";
            this.btnDeleteWall.UseVisualStyleBackColor = true;
            this.btnDeleteWall.Click += new System.EventHandler(this.btnDeleteWall_Click);
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(116, 24);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "결과 비움";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnHide
            //
            this.btnHide.Location = new System.Drawing.Point(12, 24);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(100, 23);
            this.btnHide.TabIndex = 0;
            this.btnHide.Text = "표식 숨김";
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
            this.Text = "VIZCore3DX.NET.SightAnalysis";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpResult.ResumeLayout(false);
            this.grpResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.grpRun.ResumeLayout(false);
            this.grpSetup.ResumeLayout(false);
            this.grpSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConeAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAngularStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).EndInit();
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
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.NumericUpDown numPosX;
        private System.Windows.Forms.NumericUpDown numPosY;
        private System.Windows.Forms.NumericUpDown numPosZ;
        private System.Windows.Forms.Button btnCenter;
        private System.Windows.Forms.Button btnDemoWall;
        private System.Windows.Forms.Label lblMaxDistance;
        private System.Windows.Forms.NumericUpDown numMaxDistance;
        private System.Windows.Forms.Label lblAngularStep;
        private System.Windows.Forms.NumericUpDown numAngularStep;
        private System.Windows.Forms.CheckBox chkCone;
        private System.Windows.Forms.ComboBox cmbConeDirection;
        private System.Windows.Forms.Label lblConeAngle;
        private System.Windows.Forms.NumericUpDown numConeAngle;
        private System.Windows.Forms.CheckBox chkUseCache;
        private System.Windows.Forms.CheckBox chkRange;
        private System.Windows.Forms.GroupBox grpRun;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHidden;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeconds;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnUnion;
        private System.Windows.Forms.CheckBox chkRays;
        private System.Windows.Forms.DataGridView dgvNodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNodeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNodeKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNodeHits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNodeRatio;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDeleteWall;
        private System.Windows.Forms.Label lblStatus;
    }
}
