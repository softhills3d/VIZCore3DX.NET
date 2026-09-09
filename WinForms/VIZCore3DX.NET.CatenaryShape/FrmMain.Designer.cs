namespace VIZCore3DX.NET.CatenaryShape
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelControl = new System.Windows.Forms.Panel();
            this.dgvPoints = new System.Windows.Forms.DataGridView();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPointCount = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnFitToView = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupDisplay = new System.Windows.Forms.GroupBox();
            this.chkClearBeforeCreate = new System.Windows.Forms.CheckBox();
            this.btnCreateTube = new System.Windows.Forms.Button();
            this.btnCreateLine = new System.Windows.Forms.Button();
            this.btnShapeColor = new System.Windows.Forms.Button();
            this.lblColor = new System.Windows.Forms.Label();
            this.numTubeRadius = new System.Windows.Forms.NumericUpDown();
            this.lblTubeRadius = new System.Windows.Forms.Label();
            this.numLineThickness = new System.Windows.Forms.NumericUpDown();
            this.lblLineThickness = new System.Windows.Forms.Label();
            this.groupCondition = new System.Windows.Forms.GroupBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.numSamples = new System.Windows.Forms.NumericUpDown();
            this.lblSamples = new System.Windows.Forms.Label();
            this.numLengthFactor = new System.Windows.Forms.NumericUpDown();
            this.lblLengthFactor = new System.Windows.Forms.Label();
            this.btnPickP1P2 = new System.Windows.Forms.Button();
            this.lblP2Status = new System.Windows.Forms.Label();
            this.lblP1Status = new System.Windows.Forms.Label();
            this.btnPickP2 = new System.Windows.Forms.Button();
            this.btnPickP1 = new System.Windows.Forms.Button();
            this.numP2Z = new System.Windows.Forms.NumericUpDown();
            this.numP2Y = new System.Windows.Forms.NumericUpDown();
            this.numP2X = new System.Windows.Forms.NumericUpDown();
            this.numP1Z = new System.Windows.Forms.NumericUpDown();
            this.numP1Y = new System.Windows.Forms.NumericUpDown();
            this.numP1X = new System.Windows.Forms.NumericUpDown();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblP2 = new System.Windows.Forms.Label();
            this.lblP1 = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.groupDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTubeRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineThickness)).BeginInit();
            this.groupCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1X)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.panelControl);
            this.splitContainer1.Size = new System.Drawing.Size(1200, 720);
            this.splitContainer1.SplitterDistance = 370;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelControl
            // 
            this.panelControl.AutoScroll = true;
            this.panelControl.Controls.Add(this.dgvPoints);
            this.panelControl.Controls.Add(this.lblPointCount);
            this.panelControl.Controls.Add(this.panelButtons);
            this.panelControl.Controls.Add(this.groupDisplay);
            this.panelControl.Controls.Add(this.groupCondition);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(370, 720);
            this.panelControl.TabIndex = 0;
            // 
            // dgvPoints
            // 
            this.dgvPoints.AllowUserToAddRows = false;
            this.dgvPoints.AllowUserToDeleteRows = false;
            this.dgvPoints.AllowUserToResizeRows = false;
            this.dgvPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPoints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.colX,
            this.colY,
            this.colZ});
            this.dgvPoints.Location = new System.Drawing.Point(10, 586);
            this.dgvPoints.MultiSelect = false;
            this.dgvPoints.Name = "dgvPoints";
            this.dgvPoints.ReadOnly = true;
            this.dgvPoints.RowHeadersVisible = false;
            this.dgvPoints.RowTemplate.Height = 23;
            this.dgvPoints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPoints.Size = new System.Drawing.Size(350, 124);
            this.dgvPoints.TabIndex = 4;
            // 
            // colIndex
            // 
            this.colIndex.FillWeight = 45F;
            this.colIndex.HeaderText = "No.";
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            // 
            // colX
            // 
            this.colX.HeaderText = "X";
            this.colX.Name = "colX";
            this.colX.ReadOnly = true;
            // 
            // colY
            // 
            this.colY.HeaderText = "Y";
            this.colY.Name = "colY";
            this.colY.ReadOnly = true;
            // 
            // colZ
            // 
            this.colZ.HeaderText = "Z";
            this.colZ.Name = "colZ";
            this.colZ.ReadOnly = true;
            // 
            // lblPointCount
            // 
            this.lblPointCount.AutoSize = true;
            this.lblPointCount.Location = new System.Drawing.Point(12, 568);
            this.lblPointCount.Name = "lblPointCount";
            this.lblPointCount.Size = new System.Drawing.Size(91, 12);
            this.lblPointCount.TabIndex = 3;
            this.lblPointCount.Text = "계산된 Point : 0";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnFitToView);
            this.panelButtons.Controls.Add(this.btnClear);
            this.panelButtons.Location = new System.Drawing.Point(10, 526);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(350, 36);
            this.panelButtons.TabIndex = 2;
            // 
            // btnFitToView
            // 
            this.btnFitToView.Location = new System.Drawing.Point(180, 2);
            this.btnFitToView.Name = "btnFitToView";
            this.btnFitToView.Size = new System.Drawing.Size(170, 30);
            this.btnFitToView.TabIndex = 1;
            this.btnFitToView.Text = "화면 맞춤";
            this.btnFitToView.UseVisualStyleBackColor = true;
            this.btnFitToView.Click += new System.EventHandler(this.btnFitToView_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(0, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(170, 30);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Shape 전체 삭제";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupDisplay
            // 
            this.groupDisplay.Controls.Add(this.chkClearBeforeCreate);
            this.groupDisplay.Controls.Add(this.btnCreateTube);
            this.groupDisplay.Controls.Add(this.btnCreateLine);
            this.groupDisplay.Controls.Add(this.btnShapeColor);
            this.groupDisplay.Controls.Add(this.lblColor);
            this.groupDisplay.Controls.Add(this.numTubeRadius);
            this.groupDisplay.Controls.Add(this.lblTubeRadius);
            this.groupDisplay.Controls.Add(this.numLineThickness);
            this.groupDisplay.Controls.Add(this.lblLineThickness);
            this.groupDisplay.Location = new System.Drawing.Point(10, 359);
            this.groupDisplay.Name = "groupDisplay";
            this.groupDisplay.Size = new System.Drawing.Size(350, 161);
            this.groupDisplay.TabIndex = 1;
            this.groupDisplay.TabStop = false;
            this.groupDisplay.Text = "표현";
            // 
            // chkClearBeforeCreate
            // 
            this.chkClearBeforeCreate.AutoSize = true;
            this.chkClearBeforeCreate.Checked = true;
            this.chkClearBeforeCreate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClearBeforeCreate.Location = new System.Drawing.Point(186, 139);
            this.chkClearBeforeCreate.Name = "chkClearBeforeCreate";
            this.chkClearBeforeCreate.Size = new System.Drawing.Size(160, 16);
            this.chkClearBeforeCreate.TabIndex = 8;
            this.chkClearBeforeCreate.Text = "생성 전 기존 Shape 삭제";
            this.chkClearBeforeCreate.UseVisualStyleBackColor = true;
            this.chkClearBeforeCreate.Visible = false;
            // 
            // btnCreateTube
            // 
            this.btnCreateTube.Location = new System.Drawing.Point(185, 107);
            this.btnCreateTube.Name = "btnCreateTube";
            this.btnCreateTube.Size = new System.Drawing.Size(145, 28);
            this.btnCreateTube.TabIndex = 7;
            this.btnCreateTube.Text = "Tube 생성";
            this.btnCreateTube.UseVisualStyleBackColor = true;
            this.btnCreateTube.Click += new System.EventHandler(this.btnCreateTube_Click);
            // 
            // btnCreateLine
            // 
            this.btnCreateLine.Location = new System.Drawing.Point(20, 107);
            this.btnCreateLine.Name = "btnCreateLine";
            this.btnCreateLine.Size = new System.Drawing.Size(145, 28);
            this.btnCreateLine.TabIndex = 6;
            this.btnCreateLine.Text = "Line 생성";
            this.btnCreateLine.UseVisualStyleBackColor = true;
            this.btnCreateLine.Click += new System.EventHandler(this.btnCreateLine_Click);
            // 
            // btnShapeColor
            // 
            this.btnShapeColor.BackColor = System.Drawing.Color.Orange;
            this.btnShapeColor.Location = new System.Drawing.Point(184, 78);
            this.btnShapeColor.Name = "btnShapeColor";
            this.btnShapeColor.Size = new System.Drawing.Size(146, 24);
            this.btnShapeColor.TabIndex = 5;
            this.btnShapeColor.Text = "색상 선택";
            this.btnShapeColor.UseVisualStyleBackColor = false;
            this.btnShapeColor.Click += new System.EventHandler(this.btnShapeColor_Click);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(20, 83);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(69, 12);
            this.lblColor.TabIndex = 4;
            this.lblColor.Text = "Shape 색상";
            // 
            // numTubeRadius
            // 
            this.numTubeRadius.DecimalPlaces = 1;
            this.numTubeRadius.Location = new System.Drawing.Point(184, 51);
            this.numTubeRadius.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numTubeRadius.Name = "numTubeRadius";
            this.numTubeRadius.Size = new System.Drawing.Size(146, 21);
            this.numTubeRadius.TabIndex = 3;
            this.numTubeRadius.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblTubeRadius
            // 
            this.lblTubeRadius.AutoSize = true;
            this.lblTubeRadius.Location = new System.Drawing.Point(20, 55);
            this.lblTubeRadius.Name = "lblTubeRadius";
            this.lblTubeRadius.Size = new System.Drawing.Size(128, 12);
            this.lblTubeRadius.TabIndex = 2;
            this.lblTubeRadius.Text = "Tube Radius (0=Auto)";
            // 
            // numLineThickness
            // 
            this.numLineThickness.DecimalPlaces = 1;
            this.numLineThickness.Location = new System.Drawing.Point(184, 23);
            this.numLineThickness.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLineThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLineThickness.Name = "numLineThickness";
            this.numLineThickness.Size = new System.Drawing.Size(146, 21);
            this.numLineThickness.TabIndex = 1;
            this.numLineThickness.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblLineThickness
            // 
            this.lblLineThickness.AutoSize = true;
            this.lblLineThickness.Location = new System.Drawing.Point(20, 27);
            this.lblLineThickness.Name = "lblLineThickness";
            this.lblLineThickness.Size = new System.Drawing.Size(92, 12);
            this.lblLineThickness.TabIndex = 0;
            this.lblLineThickness.Text = "Line Thickness";
            // 
            // groupCondition
            // 
            this.groupCondition.Controls.Add(this.btnCalculate);
            this.groupCondition.Controls.Add(this.numSamples);
            this.groupCondition.Controls.Add(this.lblSamples);
            this.groupCondition.Controls.Add(this.numLengthFactor);
            this.groupCondition.Controls.Add(this.lblLengthFactor);
            this.groupCondition.Controls.Add(this.btnPickP1P2);
            this.groupCondition.Controls.Add(this.lblP2Status);
            this.groupCondition.Controls.Add(this.lblP1Status);
            this.groupCondition.Controls.Add(this.btnPickP2);
            this.groupCondition.Controls.Add(this.btnPickP1);
            this.groupCondition.Controls.Add(this.numP2Z);
            this.groupCondition.Controls.Add(this.numP2Y);
            this.groupCondition.Controls.Add(this.numP2X);
            this.groupCondition.Controls.Add(this.numP1Z);
            this.groupCondition.Controls.Add(this.numP1Y);
            this.groupCondition.Controls.Add(this.numP1X);
            this.groupCondition.Controls.Add(this.lblZ);
            this.groupCondition.Controls.Add(this.lblY);
            this.groupCondition.Controls.Add(this.lblX);
            this.groupCondition.Controls.Add(this.lblP2);
            this.groupCondition.Controls.Add(this.lblP1);
            this.groupCondition.Controls.Add(this.btnOpenModel);
            this.groupCondition.Location = new System.Drawing.Point(10, 8);
            this.groupCondition.Name = "groupCondition";
            this.groupCondition.Size = new System.Drawing.Size(350, 350);
            this.groupCondition.TabIndex = 0;
            this.groupCondition.TabStop = false;
            this.groupCondition.Text = "Catenary 조건";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(20, 312);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(310, 28);
            this.btnCalculate.TabIndex = 21;
            this.btnCalculate.Text = "Catenary Point 계산";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // numSamples
            // 
            this.numSamples.Location = new System.Drawing.Point(184, 282);
            this.numSamples.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numSamples.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numSamples.Name = "numSamples";
            this.numSamples.Size = new System.Drawing.Size(146, 21);
            this.numSamples.TabIndex = 20;
            this.numSamples.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblSamples
            // 
            this.lblSamples.AutoSize = true;
            this.lblSamples.Location = new System.Drawing.Point(20, 286);
            this.lblSamples.Name = "lblSamples";
            this.lblSamples.Size = new System.Drawing.Size(85, 12);
            this.lblSamples.TabIndex = 19;
            this.lblSamples.Text = "Sample Count";
            // 
            // numLengthFactor
            // 
            this.numLengthFactor.DecimalPlaces = 2;
            this.numLengthFactor.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.numLengthFactor.Location = new System.Drawing.Point(184, 254);
            this.numLengthFactor.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLengthFactor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLengthFactor.Name = "numLengthFactor";
            this.numLengthFactor.Size = new System.Drawing.Size(146, 21);
            this.numLengthFactor.TabIndex = 18;
            this.numLengthFactor.Value = new decimal(new int[] {
            120,
            0,
            0,
            131072});
            // 
            // lblLengthFactor
            // 
            this.lblLengthFactor.AutoSize = true;
            this.lblLengthFactor.Location = new System.Drawing.Point(20, 258);
            this.lblLengthFactor.Name = "lblLengthFactor";
            this.lblLengthFactor.Size = new System.Drawing.Size(82, 12);
            this.lblLengthFactor.TabIndex = 17;
            this.lblLengthFactor.Text = "Length Factor";
            // 
            // btnPickP1P2
            // 
            this.btnPickP1P2.Location = new System.Drawing.Point(20, 216);
            this.btnPickP1P2.Name = "btnPickP1P2";
            this.btnPickP1P2.Size = new System.Drawing.Size(310, 28);
            this.btnPickP1P2.TabIndex = 16;
            this.btnPickP1P2.Text = "P1 → P2 연속 Osnap 지정";
            this.btnPickP1P2.UseVisualStyleBackColor = true;
            this.btnPickP1P2.Click += new System.EventHandler(this.btnPickP1P2_Click);
            // 
            // lblP2Status
            // 
            this.lblP2Status.Location = new System.Drawing.Point(184, 195);
            this.lblP2Status.Name = "lblP2Status";
            this.lblP2Status.Size = new System.Drawing.Size(146, 15);
            this.lblP2Status.TabIndex = 15;
            this.lblP2Status.Text = "P2 : 직접 입력";
            this.lblP2Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblP1Status
            // 
            this.lblP1Status.Location = new System.Drawing.Point(48, 195);
            this.lblP1Status.Name = "lblP1Status";
            this.lblP1Status.Size = new System.Drawing.Size(120, 15);
            this.lblP1Status.TabIndex = 14;
            this.lblP1Status.Text = "P1 : 직접 입력";
            this.lblP1Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPickP2
            // 
            this.btnPickP2.Location = new System.Drawing.Point(184, 164);
            this.btnPickP2.Name = "btnPickP2";
            this.btnPickP2.Size = new System.Drawing.Size(146, 27);
            this.btnPickP2.TabIndex = 13;
            this.btnPickP2.Text = "P2 Osnap 지정";
            this.btnPickP2.UseVisualStyleBackColor = true;
            this.btnPickP2.Click += new System.EventHandler(this.btnPickP2_Click);
            // 
            // btnPickP1
            // 
            this.btnPickP1.Location = new System.Drawing.Point(48, 164);
            this.btnPickP1.Name = "btnPickP1";
            this.btnPickP1.Size = new System.Drawing.Size(120, 27);
            this.btnPickP1.TabIndex = 12;
            this.btnPickP1.Text = "P1 Osnap 지정";
            this.btnPickP1.UseVisualStyleBackColor = true;
            this.btnPickP1.Click += new System.EventHandler(this.btnPickP1_Click);
            // 
            // numP2Z
            // 
            this.numP2Z.DecimalPlaces = 2;
            this.numP2Z.Location = new System.Drawing.Point(184, 134);
            this.numP2Z.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numP2Z.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numP2Z.Name = "numP2Z";
            this.numP2Z.Size = new System.Drawing.Size(146, 21);
            this.numP2Z.TabIndex = 11;
            this.numP2Z.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numP2Y
            // 
            this.numP2Y.DecimalPlaces = 2;
            this.numP2Y.Location = new System.Drawing.Point(184, 106);
            this.numP2Y.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numP2Y.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numP2Y.Name = "numP2Y";
            this.numP2Y.Size = new System.Drawing.Size(146, 21);
            this.numP2Y.TabIndex = 10;
            // 
            // numP2X
            // 
            this.numP2X.DecimalPlaces = 2;
            this.numP2X.Location = new System.Drawing.Point(184, 78);
            this.numP2X.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numP2X.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numP2X.Name = "numP2X";
            this.numP2X.Size = new System.Drawing.Size(146, 21);
            this.numP2X.TabIndex = 9;
            this.numP2X.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // numP1Z
            // 
            this.numP1Z.DecimalPlaces = 2;
            this.numP1Z.Location = new System.Drawing.Point(48, 134);
            this.numP1Z.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numP1Z.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numP1Z.Name = "numP1Z";
            this.numP1Z.Size = new System.Drawing.Size(120, 21);
            this.numP1Z.TabIndex = 8;
            this.numP1Z.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numP1Y
            // 
            this.numP1Y.DecimalPlaces = 2;
            this.numP1Y.Location = new System.Drawing.Point(48, 106);
            this.numP1Y.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numP1Y.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numP1Y.Name = "numP1Y";
            this.numP1Y.Size = new System.Drawing.Size(120, 21);
            this.numP1Y.TabIndex = 7;
            // 
            // numP1X
            // 
            this.numP1X.DecimalPlaces = 2;
            this.numP1X.Location = new System.Drawing.Point(48, 78);
            this.numP1X.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numP1X.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numP1X.Name = "numP1X";
            this.numP1X.Size = new System.Drawing.Size(120, 21);
            this.numP1X.TabIndex = 6;
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(20, 138);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(13, 12);
            this.lblZ.TabIndex = 5;
            this.lblZ.Text = "Z";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(20, 110);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(13, 12);
            this.lblY.TabIndex = 4;
            this.lblY.Text = "Y";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(20, 82);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(13, 12);
            this.lblX.TabIndex = 3;
            this.lblX.Text = "X";
            // 
            // lblP2
            // 
            this.lblP2.Location = new System.Drawing.Point(184, 59);
            this.lblP2.Name = "lblP2";
            this.lblP2.Size = new System.Drawing.Size(146, 16);
            this.lblP2.TabIndex = 2;
            this.lblP2.Text = "끝점 P2";
            this.lblP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblP1
            // 
            this.lblP1.Location = new System.Drawing.Point(48, 59);
            this.lblP1.Name = "lblP1";
            this.lblP1.Size = new System.Drawing.Size(120, 16);
            this.lblP1.TabIndex = 1;
            this.lblP1.Text = "시작점 P1";
            this.lblP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Location = new System.Drawing.Point(20, 22);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(310, 28);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "모델 열기";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.CatenaryShape";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.groupDisplay.ResumeLayout(false);
            this.groupDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTubeRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineThickness)).EndInit();
            this.groupCondition.ResumeLayout(false);
            this.groupCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1X)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.GroupBox groupCondition;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Label lblP1;
        private System.Windows.Forms.Label lblP2;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.NumericUpDown numP1X;
        private System.Windows.Forms.NumericUpDown numP1Y;
        private System.Windows.Forms.NumericUpDown numP1Z;
        private System.Windows.Forms.NumericUpDown numP2X;
        private System.Windows.Forms.NumericUpDown numP2Y;
        private System.Windows.Forms.NumericUpDown numP2Z;
        private System.Windows.Forms.Button btnPickP1;
        private System.Windows.Forms.Button btnPickP2;
        private System.Windows.Forms.Label lblP1Status;
        private System.Windows.Forms.Label lblP2Status;
        private System.Windows.Forms.Button btnPickP1P2;
        private System.Windows.Forms.Label lblLengthFactor;
        private System.Windows.Forms.NumericUpDown numLengthFactor;
        private System.Windows.Forms.Label lblSamples;
        private System.Windows.Forms.NumericUpDown numSamples;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.GroupBox groupDisplay;
        private System.Windows.Forms.Label lblLineThickness;
        private System.Windows.Forms.NumericUpDown numLineThickness;
        private System.Windows.Forms.Label lblTubeRadius;
        private System.Windows.Forms.NumericUpDown numTubeRadius;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Button btnShapeColor;
        private System.Windows.Forms.Button btnCreateLine;
        private System.Windows.Forms.Button btnCreateTube;
        private System.Windows.Forms.CheckBox chkClearBeforeCreate;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFitToView;
        private System.Windows.Forms.Label lblPointCount;
        private System.Windows.Forms.DataGridView dgvPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colZ;
    }
}
