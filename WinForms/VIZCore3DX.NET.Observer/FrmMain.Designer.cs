namespace VIZCore3DX.NET.Observer
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
            this.grpList = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnToggleVisible = new System.Windows.Forms.Button();
            this.btnMoveCamera = new System.Windows.Forms.Button();
            this.dgvObservers = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpAdd = new System.Windows.Forms.GroupBox();
            this.btnAddFromCamera = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.numConeAngle = new System.Windows.Forms.NumericUpDown();
            this.lblConeAngle = new System.Windows.Forms.Label();
            this.numAngularStep = new System.Windows.Forms.NumericUpDown();
            this.lblAngularStep = new System.Windows.Forms.Label();
            this.numMaxDistance = new System.Windows.Forms.NumericUpDown();
            this.lblMaxDistance = new System.Windows.Forms.Label();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.lblDirection = new System.Windows.Forms.Label();
            this.numPosZ = new System.Windows.Forms.NumericUpDown();
            this.numPosY = new System.Windows.Forms.NumericUpDown();
            this.numPosX = new System.Windows.Forms.NumericUpDown();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpAnalyze = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.chkRays = new System.Windows.Forms.CheckBox();
            this.numDistance = new System.Windows.Forms.NumericUpDown();
            this.lblDistance = new System.Windows.Forms.Label();
            this.chkRange = new System.Windows.Forms.CheckBox();
            this.numCone = new System.Windows.Forms.NumericUpDown();
            this.lblCone = new System.Windows.Forms.Label();
            this.numStep = new System.Windows.Forms.NumericUpDown();
            this.lblStep = new System.Windows.Forms.Label();
            this.btnHideResult = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.grpFile = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObservers)).BeginInit();
            this.grpAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConeAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAngularStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).BeginInit();
            this.grpModel.SuspendLayout();
            this.grpAnalyze.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStep)).BeginInit();
            this.grpFile.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpList);
            this.splitContainer1.Panel1.Controls.Add(this.grpAdd);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Controls.Add(this.grpAnalyze);
            this.splitContainer1.Panel1.Controls.Add(this.grpFile);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 800);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 0;
            //
            // grpList
            //
            this.grpList.Controls.Add(this.btnDelete);
            this.grpList.Controls.Add(this.btnToggleVisible);
            this.grpList.Controls.Add(this.btnMoveCamera);
            this.grpList.Controls.Add(this.dgvObservers);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Location = new System.Drawing.Point(8, 318);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(344, 244);
            this.grpList.TabIndex = 2;
            this.grpList.TabStop = false;
            this.grpList.Text = "3. 목록";
            //
            // btnDelete
            //
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(220, 208);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnToggleVisible
            //
            this.btnToggleVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToggleVisible.Location = new System.Drawing.Point(116, 208);
            this.btnToggleVisible.Name = "btnToggleVisible";
            this.btnToggleVisible.Size = new System.Drawing.Size(100, 23);
            this.btnToggleVisible.TabIndex = 2;
            this.btnToggleVisible.Text = "보이기/숨기기";
            this.btnToggleVisible.UseVisualStyleBackColor = true;
            this.btnToggleVisible.Click += new System.EventHandler(this.btnToggleVisible_Click);
            //
            // btnMoveCamera
            //
            this.btnMoveCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveCamera.Location = new System.Drawing.Point(12, 208);
            this.btnMoveCamera.Name = "btnMoveCamera";
            this.btnMoveCamera.Size = new System.Drawing.Size(100, 23);
            this.btnMoveCamera.TabIndex = 1;
            this.btnMoveCamera.Text = "카메라 이동";
            this.btnMoveCamera.UseVisualStyleBackColor = true;
            this.btnMoveCamera.Click += new System.EventHandler(this.btnMoveCamera_Click);
            //
            // dgvObservers
            //
            this.dgvObservers.AllowUserToAddRows = false;
            this.dgvObservers.AllowUserToDeleteRows = false;
            this.dgvObservers.AllowUserToResizeRows = false;
            this.dgvObservers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvObservers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvObservers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObservers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colPosition,
            this.colSight,
            this.colVisible});
            this.dgvObservers.Location = new System.Drawing.Point(12, 24);
            this.dgvObservers.MultiSelect = true;
            this.dgvObservers.Name = "dgvObservers";
            this.dgvObservers.ReadOnly = true;
            this.dgvObservers.RowHeadersVisible = false;
            this.dgvObservers.RowTemplate.Height = 23;
            this.dgvObservers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvObservers.Size = new System.Drawing.Size(320, 176);
            this.dgvObservers.TabIndex = 0;
            this.dgvObservers.SelectionChanged += new System.EventHandler(this.dgvObservers_SelectionChanged);
            //
            // colId
            //
            this.colId.FillWeight = 30F;
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            //
            // colName
            //
            this.colName.FillWeight = 80F;
            this.colName.HeaderText = "이름";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            //
            // colPosition
            //
            this.colPosition.FillWeight = 120F;
            this.colPosition.HeaderText = "위치(mm)";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            //
            // colSight
            //
            this.colSight.FillWeight = 90F;
            this.colSight.HeaderText = "시야";
            this.colSight.Name = "colSight";
            this.colSight.ReadOnly = true;
            //
            // colVisible
            //
            this.colVisible.FillWeight = 45F;
            this.colVisible.HeaderText = "표식";
            this.colVisible.Name = "colVisible";
            this.colVisible.ReadOnly = true;
            //
            // grpAdd
            //
            this.grpAdd.Controls.Add(this.btnAddFromCamera);
            this.grpAdd.Controls.Add(this.btnAdd);
            this.grpAdd.Controls.Add(this.numConeAngle);
            this.grpAdd.Controls.Add(this.lblConeAngle);
            this.grpAdd.Controls.Add(this.numAngularStep);
            this.grpAdd.Controls.Add(this.lblAngularStep);
            this.grpAdd.Controls.Add(this.numMaxDistance);
            this.grpAdd.Controls.Add(this.lblMaxDistance);
            this.grpAdd.Controls.Add(this.cmbDirection);
            this.grpAdd.Controls.Add(this.lblDirection);
            this.grpAdd.Controls.Add(this.numPosZ);
            this.grpAdd.Controls.Add(this.numPosY);
            this.grpAdd.Controls.Add(this.numPosX);
            this.grpAdd.Controls.Add(this.lblPosition);
            this.grpAdd.Controls.Add(this.txtName);
            this.grpAdd.Controls.Add(this.lblName);
            this.grpAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAdd.Location = new System.Drawing.Point(8, 104);
            this.grpAdd.Name = "grpAdd";
            this.grpAdd.Size = new System.Drawing.Size(344, 214);
            this.grpAdd.TabIndex = 1;
            this.grpAdd.TabStop = false;
            this.grpAdd.Text = "2. 옵저버 추가";
            //
            // btnAddFromCamera
            //
            this.btnAddFromCamera.Location = new System.Drawing.Point(168, 172);
            this.btnAddFromCamera.Name = "btnAddFromCamera";
            this.btnAddFromCamera.Size = new System.Drawing.Size(166, 23);
            this.btnAddFromCamera.TabIndex = 15;
            this.btnAddFromCamera.Text = "카메라 위치에 추가";
            this.btnAddFromCamera.UseVisualStyleBackColor = true;
            this.btnAddFromCamera.Click += new System.EventHandler(this.btnAddFromCamera_Click);
            //
            // btnAdd
            //
            this.btnAdd.Location = new System.Drawing.Point(12, 172);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 23);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "좌표에 추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // numConeAngle
            //
            this.numConeAngle.Location = new System.Drawing.Point(234, 136);
            this.numConeAngle.Maximum = new decimal(new int[] {
            179,
            0,
            0,
            0});
            this.numConeAngle.Name = "numConeAngle";
            this.numConeAngle.Size = new System.Drawing.Size(60, 21);
            this.numConeAngle.TabIndex = 13;
            //
            // lblConeAngle
            //
            this.lblConeAngle.AutoSize = true;
            this.lblConeAngle.Location = new System.Drawing.Point(180, 140);
            this.lblConeAngle.Name = "lblConeAngle";
            this.lblConeAngle.Size = new System.Drawing.Size(48, 12);
            this.lblConeAngle.TabIndex = 12;
            this.lblConeAngle.Text = "원뿔(°)";
            //
            // numAngularStep
            //
            this.numAngularStep.DecimalPlaces = 1;
            this.numAngularStep.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numAngularStep.Location = new System.Drawing.Point(110, 136);
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
            this.numAngularStep.Size = new System.Drawing.Size(60, 21);
            this.numAngularStep.TabIndex = 11;
            this.numAngularStep.Value = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            //
            // lblAngularStep
            //
            this.lblAngularStep.AutoSize = true;
            this.lblAngularStep.Location = new System.Drawing.Point(12, 140);
            this.lblAngularStep.Name = "lblAngularStep";
            this.lblAngularStep.Size = new System.Drawing.Size(76, 12);
            this.lblAngularStep.TabIndex = 10;
            this.lblAngularStep.Text = "각도 간격(°)";
            //
            // numMaxDistance
            //
            this.numMaxDistance.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMaxDistance.Location = new System.Drawing.Point(110, 108);
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
            this.numMaxDistance.TabIndex = 9;
            this.numMaxDistance.ThousandsSeparator = true;
            this.numMaxDistance.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            //
            // lblMaxDistance
            //
            this.lblMaxDistance.AutoSize = true;
            this.lblMaxDistance.Location = new System.Drawing.Point(12, 112);
            this.lblMaxDistance.Name = "lblMaxDistance";
            this.lblMaxDistance.Size = new System.Drawing.Size(84, 12);
            this.lblMaxDistance.TabIndex = 8;
            this.lblMaxDistance.Text = "최대 거리(mm)";
            //
            // cmbDirection
            //
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.Location = new System.Drawing.Point(90, 80);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(60, 20);
            this.cmbDirection.TabIndex = 7;
            //
            // lblDirection
            //
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(12, 84);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(29, 12);
            this.lblDirection.TabIndex = 6;
            this.lblDirection.Text = "방향";
            //
            // numPosZ
            //
            this.numPosZ.Location = new System.Drawing.Point(254, 52);
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
            this.numPosZ.TabIndex = 5;
            //
            // numPosY
            //
            this.numPosY.Location = new System.Drawing.Point(172, 52);
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
            this.numPosY.TabIndex = 4;
            //
            // numPosX
            //
            this.numPosX.Location = new System.Drawing.Point(90, 52);
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
            this.numPosX.TabIndex = 3;
            //
            // lblPosition
            //
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(12, 56);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(60, 12);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "위치(mm)";
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(90, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(244, 21);
            this.txtName.TabIndex = 1;
            //
            // lblName
            //
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 28);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "이름";
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
            this.lblModelHint.Text = "옵저버 표식은 모델이 열린 뒤에 그려집니다.\r\n뷰에서 표식을 우클릭하면 선택됩니다.";
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
            // grpAnalyze
            //
            this.grpAnalyze.Controls.Add(this.chkRange);
            this.grpAnalyze.Controls.Add(this.numCone);
            this.grpAnalyze.Controls.Add(this.lblCone);
            this.grpAnalyze.Controls.Add(this.numStep);
            this.grpAnalyze.Controls.Add(this.lblStep);
            this.grpAnalyze.Controls.Add(this.chkRays);
            this.grpAnalyze.Controls.Add(this.numDistance);
            this.grpAnalyze.Controls.Add(this.lblDistance);
            this.grpAnalyze.Controls.Add(this.progressBar);
            this.grpAnalyze.Controls.Add(this.btnHideResult);
            this.grpAnalyze.Controls.Add(this.btnCancel);
            this.grpAnalyze.Controls.Add(this.btnAnalyze);
            this.grpAnalyze.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpAnalyze.Location = new System.Drawing.Point(8, 562);
            this.grpAnalyze.Name = "grpAnalyze";
            this.grpAnalyze.Size = new System.Drawing.Size(344, 148);
            this.grpAnalyze.TabIndex = 3;
            this.grpAnalyze.TabStop = false;
            this.grpAnalyze.Text = "4. 분석";
            //
            // progressBar
            //
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 112);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(320, 18);
            this.progressBar.TabIndex = 3;
            //
            // btnHideResult
            //
            this.btnHideResult.Location = new System.Drawing.Point(220, 80);
            this.btnHideResult.Name = "btnHideResult";
            this.btnHideResult.Size = new System.Drawing.Size(100, 23);
            this.btnHideResult.TabIndex = 2;
            this.btnHideResult.Text = "결과 지움";
            this.btnHideResult.UseVisualStyleBackColor = true;
            this.btnHideResult.Click += new System.EventHandler(this.btnHideResult_Click);
            //
            // btnCancel
            //
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(116, 80);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnAnalyze
            //
            this.btnAnalyze.Location = new System.Drawing.Point(12, 80);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(100, 23);
            this.btnAnalyze.TabIndex = 0;
            this.btnAnalyze.Text = "시야 분석";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            //
            // chkRays
            //
            this.chkRays.AutoSize = true;
            this.chkRays.Checked = true;
            this.chkRays.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRays.Location = new System.Drawing.Point(180, 54);
            this.chkRays.Name = "chkRays";
            this.chkRays.Size = new System.Drawing.Size(72, 16);
            this.chkRays.TabIndex = 5;
            this.chkRays.Text = "광선 표시";
            this.chkRays.UseVisualStyleBackColor = true;
            this.chkRays.CheckedChanged += new System.EventHandler(this.chkRays_CheckedChanged);
            //
            // numDistance
            //
            this.numDistance.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDistance.Location = new System.Drawing.Point(110, 24);
            this.numDistance.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numDistance.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numDistance.Name = "numDistance";
            this.numDistance.Size = new System.Drawing.Size(90, 21);
            this.numDistance.TabIndex = 4;
            this.numDistance.ThousandsSeparator = true;
            this.numDistance.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            //
            // chkRange
            //
            this.chkRange.AutoSize = true;
            this.chkRange.Location = new System.Drawing.Point(256, 54);
            this.chkRange.Name = "chkRange";
            this.chkRange.Size = new System.Drawing.Size(72, 16);
            this.chkRange.TabIndex = 9;
            this.chkRange.Text = "범위 표시";
            this.chkRange.UseVisualStyleBackColor = true;
            this.chkRange.CheckedChanged += new System.EventHandler(this.chkRange_CheckedChanged);
            //
            // numCone
            //
            this.numCone.Location = new System.Drawing.Point(110, 52);
            this.numCone.Maximum = new decimal(new int[] {
            179,
            0,
            0,
            0});
            this.numCone.Name = "numCone";
            this.numCone.Size = new System.Drawing.Size(60, 21);
            this.numCone.TabIndex = 8;
            //
            // lblCone
            //
            this.lblCone.AutoSize = true;
            this.lblCone.Location = new System.Drawing.Point(12, 56);
            this.lblCone.Name = "lblCone";
            this.lblCone.Size = new System.Drawing.Size(84, 12);
            this.lblCone.TabIndex = 7;
            this.lblCone.Text = "원뿔 반각(°)";
            //
            // numStep
            //
            this.numStep.DecimalPlaces = 1;
            this.numStep.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numStep.Location = new System.Drawing.Point(254, 24);
            this.numStep.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numStep.Name = "numStep";
            this.numStep.Size = new System.Drawing.Size(60, 21);
            this.numStep.TabIndex = 11;
            this.numStep.Value = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            //
            // lblStep
            //
            this.lblStep.AutoSize = true;
            this.lblStep.Location = new System.Drawing.Point(206, 28);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(45, 12);
            this.lblStep.TabIndex = 10;
            this.lblStep.Text = "간격(°)";
            //
            // lblDistance
            //
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(12, 28);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(84, 12);
            this.lblDistance.TabIndex = 6;
            this.lblDistance.Text = "최대 거리(mm)";
            //
            // grpFile
            //
            this.grpFile.Controls.Add(this.btnClear);
            this.grpFile.Controls.Add(this.btnImport);
            this.grpFile.Controls.Add(this.btnExport);
            this.grpFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpFile.Location = new System.Drawing.Point(8, 710);
            this.grpFile.Name = "grpFile";
            this.grpFile.Size = new System.Drawing.Size(344, 60);
            this.grpFile.TabIndex = 4;
            this.grpFile.TabStop = false;
            this.grpFile.Text = "5. 파일·정리";
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(220, 24);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "전체 삭제";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnImport
            //
            this.btnImport.Location = new System.Drawing.Point(116, 24);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "가져오기";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            //
            // btnExport
            //
            this.btnExport.Location = new System.Drawing.Point(12, 24);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "내보내기";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            this.Text = "VIZCore3DX.NET.Observer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObservers)).EndInit();
            this.grpAdd.ResumeLayout(false);
            this.grpAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConeAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAngularStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).EndInit();
            this.grpModel.ResumeLayout(false);
            this.grpModel.PerformLayout();
            this.grpAnalyze.ResumeLayout(false);
            this.grpAnalyze.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStep)).EndInit();
            this.grpFile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Label lblModelHint;
        private System.Windows.Forms.GroupBox grpAdd;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.NumericUpDown numPosX;
        private System.Windows.Forms.NumericUpDown numPosY;
        private System.Windows.Forms.NumericUpDown numPosZ;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.Label lblMaxDistance;
        private System.Windows.Forms.NumericUpDown numMaxDistance;
        private System.Windows.Forms.Label lblAngularStep;
        private System.Windows.Forms.NumericUpDown numAngularStep;
        private System.Windows.Forms.Label lblConeAngle;
        private System.Windows.Forms.NumericUpDown numConeAngle;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddFromCamera;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvObservers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisible;
        private System.Windows.Forms.Button btnMoveCamera;
        private System.Windows.Forms.Button btnToggleVisible;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox grpAnalyze;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnHideResult;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.NumericUpDown numDistance;
        private System.Windows.Forms.CheckBox chkRays;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.NumericUpDown numStep;
        private System.Windows.Forms.Label lblCone;
        private System.Windows.Forms.NumericUpDown numCone;
        private System.Windows.Forms.CheckBox chkRange;
        private System.Windows.Forms.GroupBox grpFile;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStatus;
    }
}
