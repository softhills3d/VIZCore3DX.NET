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
            this.tlpFocus = new System.Windows.Forms.TableLayoutPanel();
            this.tlpEdit = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDelete = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLength = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCreate = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSize = new System.Windows.Forms.TableLayoutPanel();
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
            this.lblJsonFocusTitle = new System.Windows.Forms.Label();
            this.btnExportJson = new System.Windows.Forms.Button();
            this.btnImportJson = new System.Windows.Forms.Button();
            this.chkReplaceExisting = new System.Windows.Forms.CheckBox();
            this.btnEnterFocusMode = new System.Windows.Forms.Button();
            this.btnExitFocusMode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.tlpFocus.SuspendLayout();
            this.tlpEdit.SuspendLayout();
            this.tlpDelete.SuspendLayout();
            this.tlpLength.SuspendLayout();
            this.tlpCreate.SuspendLayout();
            this.tlpSize.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(1400, 900);
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
            this.panelControl.Controls.Add(this.tlpSize);
            this.panelControl.Controls.Add(this.tlpCreate);
            this.panelControl.Controls.Add(this.lblListTitle);
            this.panelControl.Controls.Add(this.lstSelectionBoxes);
            this.panelControl.Controls.Add(this.txtSelectionBoxTitle);
            this.panelControl.Controls.Add(this.btnSetTitle);
            this.panelControl.Controls.Add(this.tlpDelete);
            this.panelControl.Controls.Add(this.lblEditTitle);
            this.panelControl.Controls.Add(this.cmbAxis);
            this.panelControl.Controls.Add(this.chkGroupAxis);
            this.panelControl.Controls.Add(this.tlpEdit);
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
            this.panelControl.Controls.Add(this.tlpLength);
            this.panelControl.Controls.Add(this.lblJsonFocusTitle);
            this.panelControl.Controls.Add(this.btnExportJson);
            this.panelControl.Controls.Add(this.btnImportJson);
            this.panelControl.Controls.Add(this.chkReplaceExisting);
            this.panelControl.Controls.Add(this.tlpFocus);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(480, 900);
            this.panelControl.TabIndex = 0;
            // 
            // lblBasicTitle
            // 
            this.lblBasicTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBasicTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblBasicTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBasicTitle.Location = new System.Drawing.Point(10, 12);
            this.lblBasicTitle.Name = "lblBasicTitle";
            this.lblBasicTitle.Size = new System.Drawing.Size(445, 24);
            this.lblBasicTitle.TabIndex = 0;
            this.lblBasicTitle.Text = "기본 기능";
            this.lblBasicTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Location = new System.Drawing.Point(20, 46);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(130, 30);
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
            this.chkManipulator.Location = new System.Drawing.Point(165, 53);
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
            this.chkNameVisible.Location = new System.Drawing.Point(305, 53);
            this.chkNameVisible.Name = "chkNameVisible";
            this.chkNameVisible.Size = new System.Drawing.Size(102, 16);
            this.chkNameVisible.TabIndex = 3;
            this.chkNameVisible.Text = "Box 이름 표시";
            this.chkNameVisible.UseVisualStyleBackColor = true;
            this.chkNameVisible.CheckedChanged += new System.EventHandler(this.chkNameVisible_CheckedChanged);
            // 
            // lblSizeTitle
            // 
            this.lblSizeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSizeTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblSizeTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSizeTitle.Location = new System.Drawing.Point(10, 90);
            this.lblSizeTitle.Name = "lblSizeTitle";
            this.lblSizeTitle.Size = new System.Drawing.Size(445, 24);
            this.lblSizeTitle.TabIndex = 4;
            this.lblSizeTitle.Text = "위치 및 크기 (Min / Max)";
            this.lblSizeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpSize
            // 
            this.tlpSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpSize.ColumnCount = 4;
            this.tlpSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpSize.Controls.Add(this.lblX, 1, 0);
            this.tlpSize.Controls.Add(this.lblY, 2, 0);
            this.tlpSize.Controls.Add(this.lblZ, 3, 0);
            this.tlpSize.Controls.Add(this.lblMin, 0, 1);
            this.tlpSize.Controls.Add(this.numMinX, 1, 1);
            this.tlpSize.Controls.Add(this.numMinY, 2, 1);
            this.tlpSize.Controls.Add(this.numMinZ, 3, 1);
            this.tlpSize.Controls.Add(this.lblMax, 0, 2);
            this.tlpSize.Controls.Add(this.numMaxX, 1, 2);
            this.tlpSize.Controls.Add(this.numMaxY, 2, 2);
            this.tlpSize.Controls.Add(this.numMaxZ, 3, 2);
            this.tlpSize.Location = new System.Drawing.Point(17, 122);
            this.tlpSize.Name = "tlpSize";
            this.tlpSize.RowCount = 3;
            this.tlpSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpSize.Size = new System.Drawing.Size(441, 76);
            this.tlpSize.TabIndex = 5;
            // 
            // lblX
            // 
            this.lblX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(58, 4);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(13, 12);
            this.lblX.TabIndex = 0;
            this.lblX.Text = "X";
            // 
            // lblY
            // 
            this.lblY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(187, 4);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(13, 12);
            this.lblY.TabIndex = 1;
            this.lblY.Text = "Y";
            // 
            // lblZ
            // 
            this.lblZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(315, 4);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(13, 12);
            this.lblZ.TabIndex = 2;
            this.lblZ.Text = "Z";
            // 
            // lblMin
            // 
            this.lblMin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(3, 28);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(26, 12);
            this.lblMin.TabIndex = 3;
            this.lblMin.Text = "Min";
            // 
            // lblMax
            // 
            this.lblMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(3, 56);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(30, 12);
            this.lblMax.TabIndex = 7;
            this.lblMax.Text = "Max";
            // 
            // numMinX
            // 
            this.numMinX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numMinX.DecimalPlaces = 3;
            this.numMinX.Location = new System.Drawing.Point(58, 23);
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
            this.numMinX.Size = new System.Drawing.Size(123, 21);
            this.numMinX.TabIndex = 4;
            // 
            // numMinY
            // 
            this.numMinY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numMinY.DecimalPlaces = 3;
            this.numMinY.Location = new System.Drawing.Point(187, 23);
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
            this.numMinY.Size = new System.Drawing.Size(122, 21);
            this.numMinY.TabIndex = 5;
            // 
            // numMinZ
            // 
            this.numMinZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numMinZ.DecimalPlaces = 3;
            this.numMinZ.Location = new System.Drawing.Point(315, 23);
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
            this.numMinZ.Size = new System.Drawing.Size(123, 21);
            this.numMinZ.TabIndex = 6;
            // 
            // numMaxX
            // 
            this.numMaxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numMaxX.DecimalPlaces = 3;
            this.numMaxX.Location = new System.Drawing.Point(58, 51);
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
            this.numMaxX.Size = new System.Drawing.Size(123, 21);
            this.numMaxX.TabIndex = 8;
            this.numMaxX.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // numMaxY
            // 
            this.numMaxY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numMaxY.DecimalPlaces = 3;
            this.numMaxY.Location = new System.Drawing.Point(187, 51);
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
            this.numMaxY.Size = new System.Drawing.Size(122, 21);
            this.numMaxY.TabIndex = 9;
            this.numMaxY.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // numMaxZ
            // 
            this.numMaxZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numMaxZ.DecimalPlaces = 3;
            this.numMaxZ.Location = new System.Drawing.Point(315, 51);
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
            this.numMaxZ.Size = new System.Drawing.Size(123, 21);
            this.numMaxZ.TabIndex = 10;
            this.numMaxZ.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // tlpCreate
            // 
            this.tlpCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpCreate.ColumnCount = 2;
            this.tlpCreate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCreate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCreate.Controls.Add(this.btnCreate, 0, 0);
            this.tlpCreate.Controls.Add(this.btnSetSize, 1, 0);
            this.tlpCreate.Location = new System.Drawing.Point(17, 204);
            this.tlpCreate.Name = "tlpCreate";
            this.tlpCreate.RowCount = 1;
            this.tlpCreate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCreate.Size = new System.Drawing.Size(441, 36);
            this.tlpCreate.TabIndex = 16;
            // 
            // btnCreate
            // 
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreate.Location = new System.Drawing.Point(3, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(214, 30);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Selection Box 생성";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSetSize
            // 
            this.btnSetSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetSize.Location = new System.Drawing.Point(223, 3);
            this.btnSetSize.Name = "btnSetSize";
            this.btnSetSize.Size = new System.Drawing.Size(215, 30);
            this.btnSetSize.TabIndex = 1;
            this.btnSetSize.Text = "선택 Box 위치/크기 적용";
            this.btnSetSize.UseVisualStyleBackColor = true;
            this.btnSetSize.Click += new System.EventHandler(this.btnSetSize_Click);
            // 
            // lblListTitle
            // 
            this.lblListTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblListTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblListTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblListTitle.Location = new System.Drawing.Point(10, 394);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(445, 24);
            this.lblListTitle.TabIndex = 18;
            this.lblListTitle.Text = "Selection Box 목록 (여러 항목 선택 가능)";
            this.lblListTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstSelectionBoxes
            // 
            this.lstSelectionBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSelectionBoxes.FormattingEnabled = true;
            this.lstSelectionBoxes.ItemHeight = 12;
            this.lstSelectionBoxes.Location = new System.Drawing.Point(20, 428);
            this.lstSelectionBoxes.Name = "lstSelectionBoxes";
            this.lstSelectionBoxes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSelectionBoxes.Size = new System.Drawing.Size(435, 100);
            this.lstSelectionBoxes.TabIndex = 19;
            this.lstSelectionBoxes.SelectedIndexChanged += new System.EventHandler(this.lstSelectionBoxes_SelectedIndexChanged);
            this.lstSelectionBoxes.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstSelectionBoxes_Format);
            // 
            // txtSelectionBoxTitle
            // 
            this.txtSelectionBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectionBoxTitle.Location = new System.Drawing.Point(20, 541);
            this.txtSelectionBoxTitle.Name = "txtSelectionBoxTitle";
            this.txtSelectionBoxTitle.Size = new System.Drawing.Size(289, 21);
            this.txtSelectionBoxTitle.TabIndex = 20;
            // 
            // btnSetTitle
            // 
            this.btnSetTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetTitle.Location = new System.Drawing.Point(315, 536);
            this.btnSetTitle.Name = "btnSetTitle";
            this.btnSetTitle.Size = new System.Drawing.Size(140, 30);
            this.btnSetTitle.TabIndex = 21;
            this.btnSetTitle.Text = "선택 Box 이름 변경";
            this.btnSetTitle.UseVisualStyleBackColor = true;
            this.btnSetTitle.Click += new System.EventHandler(this.btnSetTitle_Click);
            // 
            // tlpDelete
            // 
            this.tlpDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDelete.ColumnCount = 2;
            this.tlpDelete.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDelete.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDelete.Controls.Add(this.btnDelete, 0, 0);
            this.tlpDelete.Controls.Add(this.btnClear, 1, 0);
            this.tlpDelete.Location = new System.Drawing.Point(17, 572);
            this.tlpDelete.Name = "tlpDelete";
            this.tlpDelete.RowCount = 1;
            this.tlpDelete.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDelete.Size = new System.Drawing.Size(441, 36);
            this.tlpDelete.TabIndex = 22;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(3, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(214, 30);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "선택 삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(223, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(215, 30);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "전체 삭제";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblEditTitle
            // 
            this.lblEditTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEditTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblEditTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEditTitle.Location = new System.Drawing.Point(10, 622);
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
            this.cmbAxis.Location = new System.Drawing.Point(20, 656);
            this.cmbAxis.Name = "cmbAxis";
            this.cmbAxis.Size = new System.Drawing.Size(205, 20);
            this.cmbAxis.TabIndex = 25;
            // 
            // chkGroupAxis
            // 
            this.chkGroupAxis.AutoSize = true;
            this.chkGroupAxis.Location = new System.Drawing.Point(245, 658);
            this.chkGroupAxis.Name = "chkGroupAxis";
            this.chkGroupAxis.Size = new System.Drawing.Size(102, 16);
            this.chkGroupAxis.TabIndex = 26;
            this.chkGroupAxis.Text = "Group 축 지정";
            this.chkGroupAxis.UseVisualStyleBackColor = true;
            // 
            // tlpEdit
            // 
            this.tlpEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpEdit.ColumnCount = 4;
            this.tlpEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpEdit.Controls.Add(this.btnDivide, 0, 0);
            this.tlpEdit.Controls.Add(this.btnMerge, 1, 0);
            this.tlpEdit.Controls.Add(this.btnGroup, 2, 0);
            this.tlpEdit.Controls.Add(this.btnUngroup, 3, 0);
            this.tlpEdit.Location = new System.Drawing.Point(17, 684);
            this.tlpEdit.Name = "tlpEdit";
            this.tlpEdit.RowCount = 1;
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEdit.Size = new System.Drawing.Size(441, 36);
            this.tlpEdit.TabIndex = 27;
            // 
            // btnDivide
            // 
            this.btnDivide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDivide.Location = new System.Drawing.Point(3, 3);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(104, 30);
            this.btnDivide.TabIndex = 0;
            this.btnDivide.Text = "Divide";
            this.btnDivide.UseVisualStyleBackColor = true;
            this.btnDivide.Click += new System.EventHandler(this.btnDivide_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMerge.Location = new System.Drawing.Point(113, 3);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(104, 30);
            this.btnMerge.TabIndex = 1;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGroup.Location = new System.Drawing.Point(223, 3);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(105, 30);
            this.btnGroup.TabIndex = 2;
            this.btnGroup.Text = "Group";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // btnUngroup
            // 
            this.btnUngroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUngroup.Location = new System.Drawing.Point(334, 3);
            this.btnUngroup.Name = "btnUngroup";
            this.btnUngroup.Size = new System.Drawing.Size(104, 30);
            this.btnUngroup.TabIndex = 3;
            this.btnUngroup.Text = "Ungroup";
            this.btnUngroup.UseVisualStyleBackColor = true;
            this.btnUngroup.Click += new System.EventHandler(this.btnUngroup_Click);
            // 
            // lblObjectTitle
            // 
            this.lblObjectTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblObjectTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblObjectTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblObjectTitle.Location = new System.Drawing.Point(10, 734);
            this.lblObjectTitle.Name = "lblObjectTitle";
            this.lblObjectTitle.Size = new System.Drawing.Size(445, 24);
            this.lblObjectTitle.TabIndex = 31;
            this.lblObjectTitle.Text = "Box 내부 Object 조회";
            this.lblObjectTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSearchOption
            // 
            this.lblSearchOption.AutoSize = true;
            this.lblSearchOption.Location = new System.Drawing.Point(20, 772);
            this.lblSearchOption.Name = "lblSearchOption";
            this.lblSearchOption.Size = new System.Drawing.Size(85, 12);
            this.lblSearchOption.TabIndex = 32;
            this.lblSearchOption.Text = "포함 검색 옵션";
            // 
            // cmbSearchOption
            // 
            this.cmbSearchOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSearchOption.DataSource = System.Enum.GetValues(typeof(VIZCore3DX.NET.Data.BoundBoxSearchOption));
            this.cmbSearchOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchOption.FormattingEnabled = true;
            this.cmbSearchOption.Location = new System.Drawing.Point(120, 768);
            this.cmbSearchOption.Name = "cmbSearchOption";
            this.cmbSearchOption.Size = new System.Drawing.Size(335, 20);
            this.cmbSearchOption.TabIndex = 33;
            // 
            // chkVisibleOnly
            // 
            this.chkVisibleOnly.AutoSize = true;
            this.chkVisibleOnly.Checked = true;
            this.chkVisibleOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisibleOnly.Location = new System.Drawing.Point(20, 803);
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
            this.rdoPart.Location = new System.Drawing.Point(130, 803);
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
            this.rdoAssembly.Location = new System.Drawing.Point(200, 803);
            this.rdoAssembly.Name = "rdoAssembly";
            this.rdoAssembly.Size = new System.Drawing.Size(80, 16);
            this.rdoAssembly.TabIndex = 36;
            this.rdoAssembly.Text = "Assembly";
            this.rdoAssembly.UseVisualStyleBackColor = true;
            // 
            // btnGetObjects
            // 
            this.btnGetObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetObjects.Location = new System.Drawing.Point(345, 796);
            this.btnGetObjects.Name = "btnGetObjects";
            this.btnGetObjects.Size = new System.Drawing.Size(110, 28);
            this.btnGetObjects.TabIndex = 37;
            this.btnGetObjects.Text = "Object 조회";
            this.btnGetObjects.UseVisualStyleBackColor = true;
            this.btnGetObjects.Click += new System.EventHandler(this.btnGetObjects_Click);
            // 
            // lstObjects
            // 
            this.lstObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lstObjects.FormattingEnabled = true;
            this.lstObjects.HorizontalScrollbar = true;
            this.lstObjects.ItemHeight = 12;
            this.lstObjects.Location = new System.Drawing.Point(20, 832);
            this.lstObjects.Name = "lstObjects";
            this.lstObjects.Size = new System.Drawing.Size(435, 88);
            this.lstObjects.TabIndex = 38;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Location = new System.Drawing.Point(20, 928);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(6);
            this.lblStatus.Size = new System.Drawing.Size(435, 55);
            this.lblStatus.TabIndex = 39;
            this.lblStatus.Text = "초기화 중입니다.";
            // 
            // lblLinkedCreateTitle
            // 
            this.lblLinkedCreateTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLinkedCreateTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblLinkedCreateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLinkedCreateTitle.Location = new System.Drawing.Point(10, 997);
            this.lblLinkedCreateTitle.Name = "lblLinkedCreateTitle";
            this.lblLinkedCreateTitle.Size = new System.Drawing.Size(445, 24);
            this.lblLinkedCreateTitle.TabIndex = 40;
            this.lblLinkedCreateTitle.Text = "선택한 모델 객체 범위로 생성";
            this.lblLinkedCreateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMargin
            // 
            this.lblMargin.AutoSize = true;
            this.lblMargin.Location = new System.Drawing.Point(20, 1040);
            this.lblMargin.Name = "lblMargin";
            this.lblMargin.Size = new System.Drawing.Size(57, 12);
            this.lblMargin.TabIndex = 41;
            this.lblMargin.Text = "여유 거리";
            // 
            // numMargin
            // 
            this.numMargin.DecimalPlaces = 3;
            this.numMargin.Location = new System.Drawing.Point(90, 1035);
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
            this.btnCreateFromSelected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateFromSelected.Location = new System.Drawing.Point(220, 1031);
            this.btnCreateFromSelected.Name = "btnCreateFromSelected";
            this.btnCreateFromSelected.Size = new System.Drawing.Size(235, 30);
            this.btnCreateFromSelected.TabIndex = 43;
            this.btnCreateFromSelected.Text = "선택 Object BoundBox로 생성";
            this.btnCreateFromSelected.UseVisualStyleBackColor = true;
            this.btnCreateFromSelected.Click += new System.EventHandler(this.btnCreateFromSelected_Click);
            // 
            // lblOsnapTitle
            // 
            this.lblOsnapTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOsnapTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblOsnapTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOsnapTitle.Location = new System.Drawing.Point(10, 254);
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
            this.chkEdgeEndpointSnap.Location = new System.Drawing.Point(20, 290);
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
            this.chkEdgeMidpointSnap.Location = new System.Drawing.Point(85, 290);
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
            this.chkLineSnap.Location = new System.Drawing.Point(150, 290);
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
            this.chkCircleSnap.Location = new System.Drawing.Point(205, 290);
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
            this.chkCircleCenterSnap.Location = new System.Drawing.Point(260, 290);
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
            this.chkCylinderSnap.Location = new System.Drawing.Point(345, 290);
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
            this.chkPlaneSnap.Location = new System.Drawing.Point(410, 290);
            this.chkPlaneSnap.Name = "chkPlaneSnap";
            this.chkPlaneSnap.Size = new System.Drawing.Size(36, 16);
            this.chkPlaneSnap.TabIndex = 51;
            this.chkPlaneSnap.Text = "면";
            this.chkPlaneSnap.UseVisualStyleBackColor = true;
            // 
            // btnPickOsnap
            // 
            this.btnPickOsnap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickOsnap.Location = new System.Drawing.Point(20, 350);
            this.btnPickOsnap.Name = "btnPickOsnap";
            this.btnPickOsnap.Size = new System.Drawing.Size(289, 30);
            this.btnPickOsnap.TabIndex = 52;
            this.btnPickOsnap.Text = "Osnap으로 위치 설정";
            this.btnPickOsnap.UseVisualStyleBackColor = true;
            this.btnPickOsnap.Click += new System.EventHandler(this.btnPickOsnap_Click);
            // 
            // btnCancelOsnap
            // 
            this.btnCancelOsnap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelOsnap.Location = new System.Drawing.Point(315, 350);
            this.btnCancelOsnap.Name = "btnCancelOsnap";
            this.btnCancelOsnap.Size = new System.Drawing.Size(140, 30);
            this.btnCancelOsnap.TabIndex = 53;
            this.btnCancelOsnap.Text = "Osnap 취소";
            this.btnCancelOsnap.UseVisualStyleBackColor = true;
            this.btnCancelOsnap.Click += new System.EventHandler(this.btnCancelOsnap_Click);
            // 
            // tlpLength
            // 
            this.tlpLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpLength.ColumnCount = 6;
            this.tlpLength.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpLength.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLength.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpLength.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLength.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpLength.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpLength.Controls.Add(this.lblLengthX, 0, 0);
            this.tlpLength.Controls.Add(this.numLengthX, 1, 0);
            this.tlpLength.Controls.Add(this.lblLengthY, 2, 0);
            this.tlpLength.Controls.Add(this.numLengthY, 3, 0);
            this.tlpLength.Controls.Add(this.lblLengthZ, 4, 0);
            this.tlpLength.Controls.Add(this.numLengthZ, 5, 0);
            this.tlpLength.Location = new System.Drawing.Point(17, 314);
            this.tlpLength.Name = "tlpLength";
            this.tlpLength.RowCount = 1;
            this.tlpLength.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLength.Size = new System.Drawing.Size(441, 28);
            this.tlpLength.TabIndex = 52;
            // 
            // lblLengthX
            // 
            this.lblLengthX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLengthX.AutoSize = true;
            this.lblLengthX.Location = new System.Drawing.Point(3, 8);
            this.lblLengthX.Name = "lblLengthX";
            this.lblLengthX.Size = new System.Drawing.Size(41, 12);
            this.lblLengthX.TabIndex = 0;
            this.lblLengthX.Text = "크기 X";
            // 
            // lblLengthY
            // 
            this.lblLengthY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLengthY.AutoSize = true;
            this.lblLengthY.Location = new System.Drawing.Point(150, 8);
            this.lblLengthY.Name = "lblLengthY";
            this.lblLengthY.Size = new System.Drawing.Size(41, 12);
            this.lblLengthY.TabIndex = 2;
            this.lblLengthY.Text = "크기 Y";
            // 
            // lblLengthZ
            // 
            this.lblLengthZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLengthZ.AutoSize = true;
            this.lblLengthZ.Location = new System.Drawing.Point(297, 8);
            this.lblLengthZ.Name = "lblLengthZ";
            this.lblLengthZ.Size = new System.Drawing.Size(41, 12);
            this.lblLengthZ.TabIndex = 4;
            this.lblLengthZ.Text = "크기 Z";
            // 
            // numLengthX
            // 
            this.numLengthX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numLengthX.DecimalPlaces = 3;
            this.numLengthX.Location = new System.Drawing.Point(51, 3);
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
            this.numLengthX.Size = new System.Drawing.Size(93, 21);
            this.numLengthX.TabIndex = 1;
            this.numLengthX.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // numLengthY
            // 
            this.numLengthY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numLengthY.DecimalPlaces = 3;
            this.numLengthY.Location = new System.Drawing.Point(198, 3);
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
            this.numLengthY.Size = new System.Drawing.Size(93, 21);
            this.numLengthY.TabIndex = 3;
            this.numLengthY.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // numLengthZ
            // 
            this.numLengthZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numLengthZ.DecimalPlaces = 3;
            this.numLengthZ.Location = new System.Drawing.Point(345, 3);
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
            this.numLengthZ.Size = new System.Drawing.Size(93, 21);
            this.numLengthZ.TabIndex = 5;
            this.numLengthZ.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // lblJsonFocusTitle
            // 
            this.lblJsonFocusTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblJsonFocusTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblJsonFocusTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJsonFocusTitle.Location = new System.Drawing.Point(10, 1075);
            this.lblJsonFocusTitle.Name = "lblJsonFocusTitle";
            this.lblJsonFocusTitle.Size = new System.Drawing.Size(445, 24);
            this.lblJsonFocusTitle.TabIndex = 60;
            this.lblJsonFocusTitle.Text = "JSON 저장 / 복원 및 집중 모드";
            this.lblJsonFocusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExportJson
            // 
            this.btnExportJson.Location = new System.Drawing.Point(20, 1109);
            this.btnExportJson.Name = "btnExportJson";
            this.btnExportJson.Size = new System.Drawing.Size(130, 30);
            this.btnExportJson.TabIndex = 61;
            this.btnExportJson.Text = "JSON 내보내기";
            this.btnExportJson.UseVisualStyleBackColor = true;
            this.btnExportJson.Click += new System.EventHandler(this.btnExportJson_Click);
            // 
            // btnImportJson
            // 
            this.btnImportJson.Location = new System.Drawing.Point(160, 1109);
            this.btnImportJson.Name = "btnImportJson";
            this.btnImportJson.Size = new System.Drawing.Size(130, 30);
            this.btnImportJson.TabIndex = 62;
            this.btnImportJson.Text = "JSON 가져오기";
            this.btnImportJson.UseVisualStyleBackColor = true;
            this.btnImportJson.Click += new System.EventHandler(this.btnImportJson_Click);
            // 
            // chkReplaceExisting
            // 
            this.chkReplaceExisting.AutoSize = true;
            this.chkReplaceExisting.Checked = true;
            this.chkReplaceExisting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReplaceExisting.Location = new System.Drawing.Point(305, 1116);
            this.chkReplaceExisting.Name = "chkReplaceExisting";
            this.chkReplaceExisting.Size = new System.Drawing.Size(128, 16);
            this.chkReplaceExisting.TabIndex = 63;
            this.chkReplaceExisting.Text = "기존 Box 대체";
            this.chkReplaceExisting.UseVisualStyleBackColor = true;
            // 
            // tlpFocus
            // 
            this.tlpFocus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFocus.ColumnCount = 2;
            this.tlpFocus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFocus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFocus.Controls.Add(this.btnEnterFocusMode, 0, 0);
            this.tlpFocus.Controls.Add(this.btnExitFocusMode, 1, 0);
            this.tlpFocus.Location = new System.Drawing.Point(17, 1145);
            this.tlpFocus.Name = "tlpFocus";
            this.tlpFocus.RowCount = 1;
            this.tlpFocus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFocus.Size = new System.Drawing.Size(441, 36);
            this.tlpFocus.TabIndex = 64;
            // 
            // btnEnterFocusMode
            // 
            this.btnEnterFocusMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnterFocusMode.Location = new System.Drawing.Point(3, 3);
            this.btnEnterFocusMode.Name = "btnEnterFocusMode";
            this.btnEnterFocusMode.Size = new System.Drawing.Size(214, 30);
            this.btnEnterFocusMode.TabIndex = 0;
            this.btnEnterFocusMode.Text = "선택 Box 집중 모드";
            this.btnEnterFocusMode.UseVisualStyleBackColor = true;
            this.btnEnterFocusMode.Click += new System.EventHandler(this.btnEnterFocusMode_Click);
            // 
            // btnExitFocusMode
            // 
            this.btnExitFocusMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExitFocusMode.Location = new System.Drawing.Point(223, 3);
            this.btnExitFocusMode.Name = "btnExitFocusMode";
            this.btnExitFocusMode.Size = new System.Drawing.Size(215, 30);
            this.btnExitFocusMode.TabIndex = 1;
            this.btnExitFocusMode.Text = "집중 모드 해제";
            this.btnExitFocusMode.UseVisualStyleBackColor = true;
            this.btnExitFocusMode.Click += new System.EventHandler(this.btnExitFocusMode_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 900);
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
            this.tlpFocus.ResumeLayout(false);
            this.tlpEdit.ResumeLayout(false);
            this.tlpDelete.ResumeLayout(false);
            this.tlpLength.ResumeLayout(false);
            this.tlpLength.PerformLayout();
            this.tlpCreate.ResumeLayout(false);
            this.tlpSize.ResumeLayout(false);
            this.tlpSize.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tlpFocus;
        private System.Windows.Forms.TableLayoutPanel tlpEdit;
        private System.Windows.Forms.TableLayoutPanel tlpDelete;
        private System.Windows.Forms.TableLayoutPanel tlpLength;
        private System.Windows.Forms.TableLayoutPanel tlpCreate;
        private System.Windows.Forms.TableLayoutPanel tlpSize;
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
        private System.Windows.Forms.Label lblJsonFocusTitle;
        private System.Windows.Forms.Button btnExportJson;
        private System.Windows.Forms.Button btnImportJson;
        private System.Windows.Forms.CheckBox chkReplaceExisting;
        private System.Windows.Forms.Button btnEnterFocusMode;
        private System.Windows.Forms.Button btnExitFocusMode;
    }
}
