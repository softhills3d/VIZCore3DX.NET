namespace VIZCore3DX.NET.SelectionBox
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
            this.panelControl = new System.Windows.Forms.Panel();
            this.lblBasicTitle = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.chkManipulator = new System.Windows.Forms.CheckBox();
            this.chkNameVisible = new System.Windows.Forms.CheckBox();
            this.lblSizeTitle = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.numMinX = new System.Windows.Forms.NumericUpDown();
            this.numMinY = new System.Windows.Forms.NumericUpDown();
            this.numMinZ = new System.Windows.Forms.NumericUpDown();
            this.numMaxX = new System.Windows.Forms.NumericUpDown();
            this.numMaxY = new System.Windows.Forms.NumericUpDown();
            this.numMaxZ = new System.Windows.Forms.NumericUpDown();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnSetSize = new System.Windows.Forms.Button();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.lstSelectionBoxes = new System.Windows.Forms.ListBox();
            this.txtSelectionBoxTitle = new System.Windows.Forms.TextBox();
            this.btnSetTitle = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblEditTitle = new System.Windows.Forms.Label();
            this.cmbAxis = new System.Windows.Forms.ComboBox();
            this.chkGroupAxis = new System.Windows.Forms.CheckBox();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.btnUngroup = new System.Windows.Forms.Button();
            this.lblObjectTitle = new System.Windows.Forms.Label();
            this.lblSearchOption = new System.Windows.Forms.Label();
            this.cmbSearchOption = new System.Windows.Forms.ComboBox();
            this.chkVisibleOnly = new System.Windows.Forms.CheckBox();
            this.rdoPart = new System.Windows.Forms.RadioButton();
            this.rdoAssembly = new System.Windows.Forms.RadioButton();
            this.btnGetObjects = new System.Windows.Forms.Button();
            this.lstObjects = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblLinkedCreateTitle = new System.Windows.Forms.Label();
            this.lblMargin = new System.Windows.Forms.Label();
            this.numMargin = new System.Windows.Forms.NumericUpDown();
            this.btnCreateFromSelected = new System.Windows.Forms.Button();
            this.lblOsnapTitle = new System.Windows.Forms.Label();
            this.chkEdgeEndpointSnap = new System.Windows.Forms.CheckBox();
            this.chkEdgeMidpointSnap = new System.Windows.Forms.CheckBox();
            this.chkLineSnap = new System.Windows.Forms.CheckBox();
            this.chkCircleSnap = new System.Windows.Forms.CheckBox();
            this.chkCircleCenterSnap = new System.Windows.Forms.CheckBox();
            this.chkCylinderSnap = new System.Windows.Forms.CheckBox();
            this.chkPlaneSnap = new System.Windows.Forms.CheckBox();
            this.btnPickOsnap = new System.Windows.Forms.Button();
            this.btnCancelOsnap = new System.Windows.Forms.Button();
            this.lblLengthX = new System.Windows.Forms.Label();
            this.lblLengthY = new System.Windows.Forms.Label();
            this.lblLengthZ = new System.Windows.Forms.Label();
            this.numLengthX = new System.Windows.Forms.NumericUpDown();
            this.numLengthY = new System.Windows.Forms.NumericUpDown();
            this.numLengthZ = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthZ)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(1400, 850);
            this.splitContainer1.SplitterDistance = 480;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelControl
            // 
            this.panelControl.AutoScroll = true;
            this.panelControl.Controls.Add(this.lblBasicTitle);
            this.panelControl.Controls.Add(this.btnOpenModel);
            this.panelControl.Controls.Add(this.chkManipulator);
            this.panelControl.Controls.Add(this.chkNameVisible);
            this.panelControl.Controls.Add(this.lblSizeTitle);
            this.panelControl.Controls.Add(this.lblX);
            this.panelControl.Controls.Add(this.lblY);
            this.panelControl.Controls.Add(this.lblZ);
            this.panelControl.Controls.Add(this.lblMin);
            this.panelControl.Controls.Add(this.lblMax);
            this.panelControl.Controls.Add(this.numMinX);
            this.panelControl.Controls.Add(this.numMinY);
            this.panelControl.Controls.Add(this.numMinZ);
            this.panelControl.Controls.Add(this.numMaxX);
            this.panelControl.Controls.Add(this.numMaxY);
            this.panelControl.Controls.Add(this.numMaxZ);
            this.panelControl.Controls.Add(this.btnCreate);
            this.panelControl.Controls.Add(this.btnSetSize);
            this.panelControl.Controls.Add(this.lblListTitle);
            this.panelControl.Controls.Add(this.lstSelectionBoxes);
            this.panelControl.Controls.Add(this.txtSelectionBoxTitle);
            this.panelControl.Controls.Add(this.btnSetTitle);
            this.panelControl.Controls.Add(this.btnDelete);
            this.panelControl.Controls.Add(this.btnClear);
            this.panelControl.Controls.Add(this.lblEditTitle);
            this.panelControl.Controls.Add(this.cmbAxis);
            this.panelControl.Controls.Add(this.chkGroupAxis);
            this.panelControl.Controls.Add(this.btnDivide);
            this.panelControl.Controls.Add(this.btnMerge);
            this.panelControl.Controls.Add(this.btnGroup);
            this.panelControl.Controls.Add(this.btnUngroup);
            this.panelControl.Controls.Add(this.lblObjectTitle);
            this.panelControl.Controls.Add(this.lblSearchOption);
            this.panelControl.Controls.Add(this.cmbSearchOption);
            this.panelControl.Controls.Add(this.chkVisibleOnly);
            this.panelControl.Controls.Add(this.rdoPart);
            this.panelControl.Controls.Add(this.rdoAssembly);
            this.panelControl.Controls.Add(this.btnGetObjects);
            this.panelControl.Controls.Add(this.lstObjects);
            this.panelControl.Controls.Add(this.lblStatus);
            this.panelControl.Controls.Add(this.lblLinkedCreateTitle);
            this.panelControl.Controls.Add(this.lblMargin);
            this.panelControl.Controls.Add(this.numMargin);
            this.panelControl.Controls.Add(this.btnCreateFromSelected);
            this.panelControl.Controls.Add(this.lblOsnapTitle);
            this.panelControl.Controls.Add(this.chkEdgeEndpointSnap);
            this.panelControl.Controls.Add(this.chkEdgeMidpointSnap);
            this.panelControl.Controls.Add(this.chkLineSnap);
            this.panelControl.Controls.Add(this.chkCircleSnap);
            this.panelControl.Controls.Add(this.chkCircleCenterSnap);
            this.panelControl.Controls.Add(this.chkCylinderSnap);
            this.panelControl.Controls.Add(this.chkPlaneSnap);
            this.panelControl.Controls.Add(this.btnPickOsnap);
            this.panelControl.Controls.Add(this.btnCancelOsnap);
            this.panelControl.Controls.Add(this.lblLengthX);
            this.panelControl.Controls.Add(this.lblLengthY);
            this.panelControl.Controls.Add(this.lblLengthZ);
            this.panelControl.Controls.Add(this.numLengthX);
            this.panelControl.Controls.Add(this.numLengthY);
            this.panelControl.Controls.Add(this.numLengthZ);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(480, 850);
            this.panelControl.TabIndex = 0;
            // 
            // lblBasicTitle
            // 
            this.lblBasicTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblBasicTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBasicTitle.Location = new System.Drawing.Point(10, 15);
            this.lblBasicTitle.Name = "lblBasicTitle";
            this.lblBasicTitle.Size = new System.Drawing.Size(445, 24);
            this.lblBasicTitle.TabIndex = 0;
            this.lblBasicTitle.Text = "기본 기능";
            this.lblBasicTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Location = new System.Drawing.Point(20, 50);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(130, 32);
            this.btnOpenModel.TabIndex = 1;
            this.btnOpenModel.Text = "모델 열기";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // chkManipulator
            // 
            this.chkManipulator.AutoSize = true;
            this.chkManipulator.Checked = true;
            this.chkManipulator.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManipulator.Location = new System.Drawing.Point(165, 58);
            this.chkManipulator.Name = "chkManipulator";
            this.chkManipulator.Size = new System.Drawing.Size(118, 16);
            this.chkManipulator.TabIndex = 2;
            this.chkManipulator.Text = "Manipulator 사용";
            this.chkManipulator.UseVisualStyleBackColor = true;
            this.chkManipulator.CheckedChanged += new System.EventHandler(this.chkManipulator_CheckedChanged);
            // 
            // chkNameVisible
            // 
            this.chkNameVisible.AutoSize = true;
            this.chkNameVisible.Checked = true;
            this.chkNameVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNameVisible.Location = new System.Drawing.Point(305, 58);
            this.chkNameVisible.Name = "chkNameVisible";
            this.chkNameVisible.Size = new System.Drawing.Size(102, 16);
            this.chkNameVisible.TabIndex = 3;
            this.chkNameVisible.Text = "Box 이름 표시";
            this.chkNameVisible.UseVisualStyleBackColor = true;
            this.chkNameVisible.CheckedChanged += new System.EventHandler(this.chkNameVisible_CheckedChanged);
            // 
            // lblSizeTitle
            // 
            this.lblSizeTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblSizeTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSizeTitle.Location = new System.Drawing.Point(10, 95);
            this.lblSizeTitle.Name = "lblSizeTitle";
            this.lblSizeTitle.Size = new System.Drawing.Size(445, 24);
            this.lblSizeTitle.TabIndex = 4;
            this.lblSizeTitle.Text = "위치 및 크기 (Min / Max)";
            this.lblSizeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(118, 130);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(13, 12);
            this.lblX.TabIndex = 5;
            this.lblX.Text = "X";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(228, 130);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(13, 12);
            this.lblY.TabIndex = 6;
            this.lblY.Text = "Y";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(338, 130);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(13, 12);
            this.lblZ.TabIndex = 7;
            this.lblZ.Text = "Z";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(20, 160);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(26, 12);
            this.lblMin.TabIndex = 8;
            this.lblMin.Text = "Min";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(20, 200);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(30, 12);
            this.lblMax.TabIndex = 9;
            this.lblMax.Text = "Max";
            // 
            // numMinX
            // 
            this.numMinX.DecimalPlaces = 3;
            this.numMinX.Location = new System.Drawing.Point(75, 155);
            this.numMinX.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMinX.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numMinX.Name = "numMinX";
            this.numMinX.Size = new System.Drawing.Size(100, 21);
            this.numMinX.TabIndex = 10;
            // 
            // numMinY
            // 
            this.numMinY.DecimalPlaces = 3;
            this.numMinY.Location = new System.Drawing.Point(185, 155);
            this.numMinY.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMinY.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numMinY.Name = "numMinY";
            this.numMinY.Size = new System.Drawing.Size(100, 21);
            this.numMinY.TabIndex = 11;
            // 
            // numMinZ
            // 
            this.numMinZ.DecimalPlaces = 3;
            this.numMinZ.Location = new System.Drawing.Point(295, 155);
            this.numMinZ.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMinZ.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numMinZ.Name = "numMinZ";
            this.numMinZ.Size = new System.Drawing.Size(100, 21);
            this.numMinZ.TabIndex = 12;
            // 
            // numMaxX
            // 
            this.numMaxX.DecimalPlaces = 3;
            this.numMaxX.Location = new System.Drawing.Point(75, 195);
            this.numMaxX.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMaxX.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numMaxX.Name = "numMaxX";
            this.numMaxX.Size = new System.Drawing.Size(100, 21);
            this.numMaxX.TabIndex = 13;
            this.numMaxX.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // numMaxY
            // 
            this.numMaxY.DecimalPlaces = 3;
            this.numMaxY.Location = new System.Drawing.Point(185, 195);
            this.numMaxY.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMaxY.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numMaxY.Name = "numMaxY";
            this.numMaxY.Size = new System.Drawing.Size(100, 21);
            this.numMaxY.TabIndex = 14;
            this.numMaxY.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // numMaxZ
            // 
            this.numMaxZ.DecimalPlaces = 3;
            this.numMaxZ.Location = new System.Drawing.Point(295, 195);
            this.numMaxZ.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMaxZ.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numMaxZ.Name = "numMaxZ";
            this.numMaxZ.Size = new System.Drawing.Size(100, 21);
            this.numMaxZ.TabIndex = 15;
            this.numMaxZ.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(20, 230);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(205, 32);
            this.btnCreate.TabIndex = 16;
            this.btnCreate.Text = "Selection Box 생성";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSetSize
            // 
            this.btnSetSize.Location = new System.Drawing.Point(235, 230);
            this.btnSetSize.Name = "btnSetSize";
            this.btnSetSize.Size = new System.Drawing.Size(220, 32);
            this.btnSetSize.TabIndex = 17;
            this.btnSetSize.Text = "선택 Box 위치/크기 적용";
            this.btnSetSize.UseVisualStyleBackColor = true;
            this.btnSetSize.Click += new System.EventHandler(this.btnSetSize_Click);
            // 
            // lblListTitle
            // 
            this.lblListTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblListTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblListTitle.Location = new System.Drawing.Point(10, 425);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(445, 24);
            this.lblListTitle.TabIndex = 18;
            this.lblListTitle.Text = "Selection Box 목록 (여러 항목 선택 가능)";
            this.lblListTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstSelectionBoxes
            // 
            this.lstSelectionBoxes.FormattingEnabled = true;
            this.lstSelectionBoxes.ItemHeight = 12;
            this.lstSelectionBoxes.Location = new System.Drawing.Point(20, 460);
            this.lstSelectionBoxes.Name = "lstSelectionBoxes";
            this.lstSelectionBoxes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSelectionBoxes.Size = new System.Drawing.Size(435, 100);
            this.lstSelectionBoxes.TabIndex = 19;
            this.lstSelectionBoxes.SelectedIndexChanged += new System.EventHandler(this.lstSelectionBoxes_SelectedIndexChanged);
            this.lstSelectionBoxes.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstSelectionBoxes_Format);
            // 
            // txtSelectionBoxTitle
            // 
            this.txtSelectionBoxTitle.Location = new System.Drawing.Point(20, 570);
            this.txtSelectionBoxTitle.Name = "txtSelectionBoxTitle";
            this.txtSelectionBoxTitle.Size = new System.Drawing.Size(285, 21);
            this.txtSelectionBoxTitle.TabIndex = 20;
            // 
            // btnSetTitle
            // 
            this.btnSetTitle.Location = new System.Drawing.Point(315, 566);
            this.btnSetTitle.Name = "btnSetTitle";
            this.btnSetTitle.Size = new System.Drawing.Size(140, 30);
            this.btnSetTitle.TabIndex = 21;
            this.btnSetTitle.Text = "선택 Box 이름 변경";
            this.btnSetTitle.UseVisualStyleBackColor = true;
            this.btnSetTitle.Click += new System.EventHandler(this.btnSetTitle_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(20, 605);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(205, 30);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "선택 삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(235, 605);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(220, 30);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "전체 삭제";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblEditTitle
            // 
            this.lblEditTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblEditTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEditTitle.Location = new System.Drawing.Point(10, 650);
            this.lblEditTitle.Name = "lblEditTitle";
            this.lblEditTitle.Size = new System.Drawing.Size(445, 24);
            this.lblEditTitle.TabIndex = 24;
            this.lblEditTitle.Text = "Divide / Merge / Group";
            this.lblEditTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbAxis
            // 
            this.cmbAxis.DataSource = System.Enum.GetValues(typeof(VIZCore3DX.NET.Data.Axis));
            this.cmbAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAxis.FormattingEnabled = true;
            this.cmbAxis.Location = new System.Drawing.Point(20, 685);
            this.cmbAxis.Name = "cmbAxis";
            this.cmbAxis.Size = new System.Drawing.Size(205, 20);
            this.cmbAxis.TabIndex = 25;
            // 
            // chkGroupAxis
            // 
            this.chkGroupAxis.AutoSize = true;
            this.chkGroupAxis.Location = new System.Drawing.Point(245, 687);
            this.chkGroupAxis.Name = "chkGroupAxis";
            this.chkGroupAxis.Size = new System.Drawing.Size(102, 16);
            this.chkGroupAxis.TabIndex = 26;
            this.chkGroupAxis.Text = "Group 축 지정";
            this.chkGroupAxis.UseVisualStyleBackColor = true;
            // 
            // btnDivide
            // 
            this.btnDivide.Location = new System.Drawing.Point(20, 715);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(100, 30);
            this.btnDivide.TabIndex = 27;
            this.btnDivide.Text = "Divide";
            this.btnDivide.UseVisualStyleBackColor = true;
            this.btnDivide.Click += new System.EventHandler(this.btnDivide_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(130, 715);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(100, 30);
            this.btnMerge.TabIndex = 28;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(240, 715);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(100, 30);
            this.btnGroup.TabIndex = 29;
            this.btnGroup.Text = "Group";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // btnUngroup
            // 
            this.btnUngroup.Location = new System.Drawing.Point(350, 715);
            this.btnUngroup.Name = "btnUngroup";
            this.btnUngroup.Size = new System.Drawing.Size(105, 30);
            this.btnUngroup.TabIndex = 30;
            this.btnUngroup.Text = "Ungroup";
            this.btnUngroup.UseVisualStyleBackColor = true;
            this.btnUngroup.Click += new System.EventHandler(this.btnUngroup_Click);
            // 
            // lblObjectTitle
            // 
            this.lblObjectTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblObjectTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblObjectTitle.Location = new System.Drawing.Point(10, 760);
            this.lblObjectTitle.Name = "lblObjectTitle";
            this.lblObjectTitle.Size = new System.Drawing.Size(445, 24);
            this.lblObjectTitle.TabIndex = 31;
            this.lblObjectTitle.Text = "Box 내부 Object 조회";
            this.lblObjectTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSearchOption
            // 
            this.lblSearchOption.AutoSize = true;
            this.lblSearchOption.Location = new System.Drawing.Point(20, 800);
            this.lblSearchOption.Name = "lblSearchOption";
            this.lblSearchOption.Size = new System.Drawing.Size(85, 12);
            this.lblSearchOption.TabIndex = 32;
            this.lblSearchOption.Text = "포함 검색 옵션";
            // 
            // cmbSearchOption
            // 
            this.cmbSearchOption.DataSource = System.Enum.GetValues(typeof(VIZCore3DX.NET.Data.BoundBoxSearchOption));
            this.cmbSearchOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchOption.FormattingEnabled = true;
            this.cmbSearchOption.Location = new System.Drawing.Point(120, 795);
            this.cmbSearchOption.Name = "cmbSearchOption";
            this.cmbSearchOption.Size = new System.Drawing.Size(335, 20);
            this.cmbSearchOption.TabIndex = 33;
            // 
            // chkVisibleOnly
            // 
            this.chkVisibleOnly.AutoSize = true;
            this.chkVisibleOnly.Checked = true;
            this.chkVisibleOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisibleOnly.Location = new System.Drawing.Point(20, 830);
            this.chkVisibleOnly.Name = "chkVisibleOnly";
            this.chkVisibleOnly.Size = new System.Drawing.Size(92, 16);
            this.chkVisibleOnly.TabIndex = 34;
            this.chkVisibleOnly.Text = "Visible Only";
            this.chkVisibleOnly.UseVisualStyleBackColor = true;
            // 
            // rdoPart
            // 
            this.rdoPart.AutoSize = true;
            this.rdoPart.Checked = true;
            this.rdoPart.Location = new System.Drawing.Point(130, 830);
            this.rdoPart.Name = "rdoPart";
            this.rdoPart.Size = new System.Drawing.Size(45, 16);
            this.rdoPart.TabIndex = 35;
            this.rdoPart.TabStop = true;
            this.rdoPart.Text = "Part";
            this.rdoPart.UseVisualStyleBackColor = true;
            // 
            // rdoAssembly
            // 
            this.rdoAssembly.AutoSize = true;
            this.rdoAssembly.Location = new System.Drawing.Point(200, 830);
            this.rdoAssembly.Name = "rdoAssembly";
            this.rdoAssembly.Size = new System.Drawing.Size(80, 16);
            this.rdoAssembly.TabIndex = 36;
            this.rdoAssembly.Text = "Assembly";
            this.rdoAssembly.UseVisualStyleBackColor = true;
            // 
            // btnGetObjects
            // 
            this.btnGetObjects.Location = new System.Drawing.Point(345, 825);
            this.btnGetObjects.Name = "btnGetObjects";
            this.btnGetObjects.Size = new System.Drawing.Size(110, 28);
            this.btnGetObjects.TabIndex = 37;
            this.btnGetObjects.Text = "Object 조회";
            this.btnGetObjects.UseVisualStyleBackColor = true;
            this.btnGetObjects.Click += new System.EventHandler(this.btnGetObjects_Click);
            // 
            // lstObjects
            // 
            this.lstObjects.FormattingEnabled = true;
            this.lstObjects.HorizontalScrollbar = true;
            this.lstObjects.ItemHeight = 12;
            this.lstObjects.Location = new System.Drawing.Point(20, 860);
            this.lstObjects.Name = "lstObjects";
            this.lstObjects.Size = new System.Drawing.Size(435, 88);
            this.lstObjects.TabIndex = 38;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Location = new System.Drawing.Point(20, 960);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(6);
            this.lblStatus.Size = new System.Drawing.Size(435, 55);
            this.lblStatus.TabIndex = 39;
            this.lblStatus.Text = "초기화 중입니다.";
            // 
            // lblLinkedCreateTitle
            // 
            this.lblLinkedCreateTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblLinkedCreateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLinkedCreateTitle.Location = new System.Drawing.Point(10, 1030);
            this.lblLinkedCreateTitle.Name = "lblLinkedCreateTitle";
            this.lblLinkedCreateTitle.Size = new System.Drawing.Size(445, 24);
            this.lblLinkedCreateTitle.TabIndex = 40;
            this.lblLinkedCreateTitle.Text = "선택한 모델 객체 범위로 생성";
            this.lblLinkedCreateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMargin
            // 
            this.lblMargin.AutoSize = true;
            this.lblMargin.Location = new System.Drawing.Point(20, 1071);
            this.lblMargin.Name = "lblMargin";
            this.lblMargin.Size = new System.Drawing.Size(57, 12);
            this.lblMargin.TabIndex = 41;
            this.lblMargin.Text = "여유 거리";
            // 
            // numMargin
            // 
            this.numMargin.DecimalPlaces = 3;
            this.numMargin.Location = new System.Drawing.Point(90, 1066);
            this.numMargin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMargin.Name = "numMargin";
            this.numMargin.Size = new System.Drawing.Size(115, 21);
            this.numMargin.TabIndex = 42;
            // 
            // btnCreateFromSelected
            // 
            this.btnCreateFromSelected.Location = new System.Drawing.Point(220, 1062);
            this.btnCreateFromSelected.Name = "btnCreateFromSelected";
            this.btnCreateFromSelected.Size = new System.Drawing.Size(235, 30);
            this.btnCreateFromSelected.TabIndex = 43;
            this.btnCreateFromSelected.Text = "선택 Object BoundBox로 생성";
            this.btnCreateFromSelected.UseVisualStyleBackColor = true;
            this.btnCreateFromSelected.Click += new System.EventHandler(this.btnCreateFromSelected_Click);
            // 
            // lblOsnapTitle
            // 
            this.lblOsnapTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblOsnapTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOsnapTitle.Location = new System.Drawing.Point(10, 275);
            this.lblOsnapTitle.Name = "lblOsnapTitle";
            this.lblOsnapTitle.Size = new System.Drawing.Size(445, 24);
            this.lblOsnapTitle.TabIndex = 44;
            this.lblOsnapTitle.Text = "Osnap 위치를 중심으로 생성";
            this.lblOsnapTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEdgeEndpointSnap
            // 
            this.chkEdgeEndpointSnap.AutoSize = true;
            this.chkEdgeEndpointSnap.Checked = true;
            this.chkEdgeEndpointSnap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEdgeEndpointSnap.Location = new System.Drawing.Point(20, 313);
            this.chkEdgeEndpointSnap.Name = "chkEdgeEndpointSnap";
            this.chkEdgeEndpointSnap.Size = new System.Drawing.Size(48, 16);
            this.chkEdgeEndpointSnap.TabIndex = 45;
            this.chkEdgeEndpointSnap.Text = "끝점";
            this.chkEdgeEndpointSnap.UseVisualStyleBackColor = true;
            // 
            // chkEdgeMidpointSnap
            // 
            this.chkEdgeMidpointSnap.AutoSize = true;
            this.chkEdgeMidpointSnap.Checked = true;
            this.chkEdgeMidpointSnap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEdgeMidpointSnap.Location = new System.Drawing.Point(85, 313);
            this.chkEdgeMidpointSnap.Name = "chkEdgeMidpointSnap";
            this.chkEdgeMidpointSnap.Size = new System.Drawing.Size(48, 16);
            this.chkEdgeMidpointSnap.TabIndex = 46;
            this.chkEdgeMidpointSnap.Text = "중점";
            this.chkEdgeMidpointSnap.UseVisualStyleBackColor = true;
            // 
            // chkLineSnap
            // 
            this.chkLineSnap.AutoSize = true;
            this.chkLineSnap.Checked = true;
            this.chkLineSnap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLineSnap.Location = new System.Drawing.Point(150, 313);
            this.chkLineSnap.Name = "chkLineSnap";
            this.chkLineSnap.Size = new System.Drawing.Size(36, 16);
            this.chkLineSnap.TabIndex = 47;
            this.chkLineSnap.Text = "선";
            this.chkLineSnap.UseVisualStyleBackColor = true;
            // 
            // chkCircleSnap
            // 
            this.chkCircleSnap.AutoSize = true;
            this.chkCircleSnap.Checked = true;
            this.chkCircleSnap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCircleSnap.Location = new System.Drawing.Point(205, 313);
            this.chkCircleSnap.Name = "chkCircleSnap";
            this.chkCircleSnap.Size = new System.Drawing.Size(36, 16);
            this.chkCircleSnap.TabIndex = 48;
            this.chkCircleSnap.Text = "원";
            this.chkCircleSnap.UseVisualStyleBackColor = true;
            // 
            // chkCircleCenterSnap
            // 
            this.chkCircleCenterSnap.AutoSize = true;
            this.chkCircleCenterSnap.Checked = true;
            this.chkCircleCenterSnap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCircleCenterSnap.Location = new System.Drawing.Point(260, 313);
            this.chkCircleCenterSnap.Name = "chkCircleCenterSnap";
            this.chkCircleCenterSnap.Size = new System.Drawing.Size(64, 16);
            this.chkCircleCenterSnap.TabIndex = 49;
            this.chkCircleCenterSnap.Text = "원 중심";
            this.chkCircleCenterSnap.UseVisualStyleBackColor = true;
            // 
            // chkCylinderSnap
            // 
            this.chkCylinderSnap.AutoSize = true;
            this.chkCylinderSnap.Checked = true;
            this.chkCylinderSnap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCylinderSnap.Location = new System.Drawing.Point(345, 313);
            this.chkCylinderSnap.Name = "chkCylinderSnap";
            this.chkCylinderSnap.Size = new System.Drawing.Size(48, 16);
            this.chkCylinderSnap.TabIndex = 50;
            this.chkCylinderSnap.Text = "원통";
            this.chkCylinderSnap.UseVisualStyleBackColor = true;
            // 
            // chkPlaneSnap
            // 
            this.chkPlaneSnap.AutoSize = true;
            this.chkPlaneSnap.Checked = true;
            this.chkPlaneSnap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPlaneSnap.Location = new System.Drawing.Point(410, 313);
            this.chkPlaneSnap.Name = "chkPlaneSnap";
            this.chkPlaneSnap.Size = new System.Drawing.Size(36, 16);
            this.chkPlaneSnap.TabIndex = 51;
            this.chkPlaneSnap.Text = "면";
            this.chkPlaneSnap.UseVisualStyleBackColor = true;
            // 
            // btnPickOsnap
            // 
            this.btnPickOsnap.Location = new System.Drawing.Point(20, 370);
            this.btnPickOsnap.Name = "btnPickOsnap";
            this.btnPickOsnap.Size = new System.Drawing.Size(270, 30);
            this.btnPickOsnap.TabIndex = 52;
            this.btnPickOsnap.Text = "Osnap으로 위치 설정";
            this.btnPickOsnap.UseVisualStyleBackColor = true;
            this.btnPickOsnap.Click += new System.EventHandler(this.btnPickOsnap_Click);
            // 
            // btnCancelOsnap
            // 
            this.btnCancelOsnap.Location = new System.Drawing.Point(300, 370);
            this.btnCancelOsnap.Name = "btnCancelOsnap";
            this.btnCancelOsnap.Size = new System.Drawing.Size(155, 30);
            this.btnCancelOsnap.TabIndex = 53;
            this.btnCancelOsnap.Text = "Osnap 취소";
            this.btnCancelOsnap.UseVisualStyleBackColor = true;
            this.btnCancelOsnap.Click += new System.EventHandler(this.btnCancelOsnap_Click);
            // 
            // lblLengthX
            // 
            this.lblLengthX.AutoSize = true;
            this.lblLengthX.Location = new System.Drawing.Point(20, 343);
            this.lblLengthX.Name = "lblLengthX";
            this.lblLengthX.Size = new System.Drawing.Size(41, 12);
            this.lblLengthX.TabIndex = 54;
            this.lblLengthX.Text = "크기 X";
            // 
            // lblLengthY
            // 
            this.lblLengthY.AutoSize = true;
            this.lblLengthY.Location = new System.Drawing.Point(165, 343);
            this.lblLengthY.Name = "lblLengthY";
            this.lblLengthY.Size = new System.Drawing.Size(41, 12);
            this.lblLengthY.TabIndex = 55;
            this.lblLengthY.Text = "크기 Y";
            // 
            // lblLengthZ
            // 
            this.lblLengthZ.AutoSize = true;
            this.lblLengthZ.Location = new System.Drawing.Point(310, 343);
            this.lblLengthZ.Name = "lblLengthZ";
            this.lblLengthZ.Size = new System.Drawing.Size(41, 12);
            this.lblLengthZ.TabIndex = 56;
            this.lblLengthZ.Text = "크기 Z";
            // 
            // numLengthX
            // 
            this.numLengthX.DecimalPlaces = 3;
            this.numLengthX.Location = new System.Drawing.Point(65, 338);
            this.numLengthX.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numLengthX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numLengthX.Name = "numLengthX";
            this.numLengthX.Size = new System.Drawing.Size(90, 21);
            this.numLengthX.TabIndex = 57;
            this.numLengthX.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // numLengthY
            // 
            this.numLengthY.DecimalPlaces = 3;
            this.numLengthY.Location = new System.Drawing.Point(210, 338);
            this.numLengthY.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numLengthY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numLengthY.Name = "numLengthY";
            this.numLengthY.Size = new System.Drawing.Size(90, 21);
            this.numLengthY.TabIndex = 58;
            this.numLengthY.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // numLengthZ
            // 
            this.numLengthZ.DecimalPlaces = 3;
            this.numLengthZ.Location = new System.Drawing.Point(355, 338);
            this.numLengthZ.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numLengthZ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numLengthZ.Name = "numLengthZ";
            this.numLengthZ.Size = new System.Drawing.Size(100, 21);
            this.numLengthZ.TabIndex = 59;
            this.numLengthZ.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 850);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1200, 760);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET - SelectionBox";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthZ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Label lblBasicTitle;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.CheckBox chkManipulator;
        private System.Windows.Forms.CheckBox chkNameVisible;
        private System.Windows.Forms.Label lblSizeTitle;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.NumericUpDown numMinX;
        private System.Windows.Forms.NumericUpDown numMinY;
        private System.Windows.Forms.NumericUpDown numMinZ;
        private System.Windows.Forms.NumericUpDown numMaxX;
        private System.Windows.Forms.NumericUpDown numMaxY;
        private System.Windows.Forms.NumericUpDown numMaxZ;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnSetSize;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.ListBox lstSelectionBoxes;
        private System.Windows.Forms.TextBox txtSelectionBoxTitle;
        private System.Windows.Forms.Button btnSetTitle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblEditTitle;
        private System.Windows.Forms.ComboBox cmbAxis;
        private System.Windows.Forms.CheckBox chkGroupAxis;
        private System.Windows.Forms.Button btnDivide;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.Button btnUngroup;
        private System.Windows.Forms.Label lblObjectTitle;
        private System.Windows.Forms.Label lblSearchOption;
        private System.Windows.Forms.ComboBox cmbSearchOption;
        private System.Windows.Forms.CheckBox chkVisibleOnly;
        private System.Windows.Forms.RadioButton rdoPart;
        private System.Windows.Forms.RadioButton rdoAssembly;
        private System.Windows.Forms.Button btnGetObjects;
        private System.Windows.Forms.ListBox lstObjects;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblLinkedCreateTitle;
        private System.Windows.Forms.Label lblMargin;
        private System.Windows.Forms.NumericUpDown numMargin;
        private System.Windows.Forms.Button btnCreateFromSelected;
        private System.Windows.Forms.Label lblOsnapTitle;
        private System.Windows.Forms.CheckBox chkEdgeEndpointSnap;
        private System.Windows.Forms.CheckBox chkEdgeMidpointSnap;
        private System.Windows.Forms.CheckBox chkLineSnap;
        private System.Windows.Forms.CheckBox chkCircleSnap;
        private System.Windows.Forms.CheckBox chkCircleCenterSnap;
        private System.Windows.Forms.CheckBox chkCylinderSnap;
        private System.Windows.Forms.CheckBox chkPlaneSnap;
        private System.Windows.Forms.Button btnPickOsnap;
        private System.Windows.Forms.Button btnCancelOsnap;
        private System.Windows.Forms.Label lblLengthX;
        private System.Windows.Forms.Label lblLengthY;
        private System.Windows.Forms.Label lblLengthZ;
        private System.Windows.Forms.NumericUpDown numLengthX;
        private System.Windows.Forms.NumericUpDown numLengthY;
        private System.Windows.Forms.NumericUpDown numLengthZ;
    }
}
