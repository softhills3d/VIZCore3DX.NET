namespace VIZCore3DX.NET.ShapeControl
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
            this.grpHeatmap = new System.Windows.Forms.GroupBox();
            this.btnHeatmapClear = new System.Windows.Forms.Button();
            this.btnHeatmapCreate = new System.Windows.Forms.Button();
            this.txtHeatmapCategory = new System.Windows.Forms.TextBox();
            this.lblHeatmapCategory = new System.Windows.Forms.Label();
            this.btnHeatmapPointOsnap = new System.Windows.Forms.Button();
            this.numHeatmapZ = new System.Windows.Forms.NumericUpDown();
            this.numHeatmapY = new System.Windows.Forms.NumericUpDown();
            this.numHeatmapX = new System.Windows.Forms.NumericUpDown();
            this.lblHeatmapPoint = new System.Windows.Forms.Label();
            this.cmbHeatmapSource = new System.Windows.Forms.ComboBox();
            this.lblHeatmapSource = new System.Windows.Forms.Label();
            this.grpRun = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.grpSetup = new System.Windows.Forms.GroupBox();
            this.lblCreateHint = new System.Windows.Forms.Label();
            this.numRotDegree = new System.Windows.Forms.NumericUpDown();
            this.lblRotDegree = new System.Windows.Forms.Label();
            this.numRotZ = new System.Windows.Forms.NumericUpDown();
            this.numRotY = new System.Windows.Forms.NumericUpDown();
            this.numRotX = new System.Windows.Forms.NumericUpDown();
            this.lblRotation = new System.Windows.Forms.Label();
            this.btnCreateColor = new System.Windows.Forms.Button();
            this.cmbAxisAnchor = new System.Windows.Forms.ComboBox();
            this.lblAxisAnchor = new System.Windows.Forms.Label();
            this.numSegmentCount = new System.Windows.Forms.NumericUpDown();
            this.lblSegmentCount = new System.Windows.Forms.Label();
            this.cmbStrokePattern = new System.Windows.Forms.ComboBox();
            this.lblStrokePattern = new System.Windows.Forms.Label();
            this.numStrokeThickness = new System.Windows.Forms.NumericUpDown();
            this.lblStrokeThickness = new System.Windows.Forms.Label();
            this.txtCreateCategory = new System.Windows.Forms.TextBox();
            this.lblCreateCategory = new System.Windows.Forms.Label();
            this.numValue3 = new System.Windows.Forms.NumericUpDown();
            this.lblValue3 = new System.Windows.Forms.Label();
            this.numValue2 = new System.Windows.Forms.NumericUpDown();
            this.lblValue2 = new System.Windows.Forms.Label();
            this.numValue1 = new System.Windows.Forms.NumericUpDown();
            this.lblValue1 = new System.Windows.Forms.Label();
            this.btnPoint3Osnap = new System.Windows.Forms.Button();
            this.numP3Z = new System.Windows.Forms.NumericUpDown();
            this.numP3Y = new System.Windows.Forms.NumericUpDown();
            this.numP3X = new System.Windows.Forms.NumericUpDown();
            this.lblPoint3 = new System.Windows.Forms.Label();
            this.btnPoint2Osnap = new System.Windows.Forms.Button();
            this.numP2Z = new System.Windows.Forms.NumericUpDown();
            this.numP2Y = new System.Windows.Forms.NumericUpDown();
            this.numP2X = new System.Windows.Forms.NumericUpDown();
            this.lblPoint2 = new System.Windows.Forms.Label();
            this.btnPoint1Osnap = new System.Windows.Forms.Button();
            this.numP1Z = new System.Windows.Forms.NumericUpDown();
            this.numP1Y = new System.Windows.Forms.NumericUpDown();
            this.numP1X = new System.Windows.Forms.NumericUpDown();
            this.lblPoint1 = new System.Windows.Forms.Label();
            this.cmbCreateMode = new System.Windows.Forms.ComboBox();
            this.lblCreateMode = new System.Windows.Forms.Label();
            this.cmbShapeType = new System.Windows.Forms.ComboBox();
            this.lblShapeType = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnDirectionSelected = new System.Windows.Forms.Button();
            this.btnRotateSelected = new System.Windows.Forms.Button();
            this.numAngle = new System.Windows.Forms.NumericUpDown();
            this.lblAngle = new System.Windows.Forms.Label();
            this.numAxisZ = new System.Windows.Forms.NumericUpDown();
            this.numAxisY = new System.Windows.Forms.NumericUpDown();
            this.numAxisX = new System.Windows.Forms.NumericUpDown();
            this.lblAxis = new System.Windows.Forms.Label();
            this.btnMoveOsnap = new System.Windows.Forms.Button();
            this.numMoveZ = new System.Windows.Forms.NumericUpDown();
            this.numMoveY = new System.Windows.Forms.NumericUpDown();
            this.numMoveX = new System.Windows.Forms.NumericUpDown();
            this.lblMove = new System.Windows.Forms.Label();
            this.btnSelectedColor = new System.Windows.Forms.Button();
            this.lblSelectedColor = new System.Windows.Forms.Label();
            this.btnHighlightColor = new System.Windows.Forms.Button();
            this.lblHighlightColor = new System.Windows.Forms.Label();
            this.numSelectionRadius = new System.Windows.Forms.NumericUpDown();
            this.lblSelectionRadius = new System.Windows.Forms.Label();
            this.chkDepthTest = new System.Windows.Forms.CheckBox();
            this.chkHighlightable = new System.Windows.Forms.CheckBox();
            this.chkSelectable = new System.Windows.Forms.CheckBox();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnCategoryDelete = new System.Windows.Forms.Button();
            this.btnCategoryClear = new System.Windows.Forms.Button();
            this.btnCategoryApply = new System.Windows.Forms.Button();
            this.btnCategoryFind = new System.Windows.Forms.Button();
            this.txtManageCategory = new System.Windows.Forms.TextBox();
            this.lblManageCategory = new System.Windows.Forms.Label();
            this.dgvShapes = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbManageTarget = new System.Windows.Forms.ComboBox();
            this.lblManageTarget = new System.Windows.Forms.Label();
            this.grpSegments = new System.Windows.Forms.GroupBox();
            this.btnLineSegmentClear = new System.Windows.Forms.Button();
            this.btnLineSegmentRemove = new System.Windows.Forms.Button();
            this.btnLineSegmentAdd = new System.Windows.Forms.Button();
            this.dgvLineSegments = new System.Windows.Forms.DataGridView();
            this.colLineStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpHeatmap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeatmapZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeatmapY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeatmapX)).BeginInit();
            this.grpRun.SuspendLayout();
            this.grpSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRotDegree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSegmentCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStrokeThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP3Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP3Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP3X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1X)).BeginInit();
            this.grpModel.SuspendLayout();
            this.grpCleanup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAxisZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAxisY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAxisX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectionRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShapes)).BeginInit();
            this.grpSegments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineSegments)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpHeatmap);
            this.splitContainer1.Panel1.Controls.Add(this.grpRun);
            this.splitContainer1.Panel1.Controls.Add(this.grpSetup);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Controls.Add(this.grpCleanup);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            //
            // splitContainer1.Panel2
            //
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 800);
            this.splitContainer1.SplitterDistance = 376;
            this.splitContainer1.TabIndex = 0;
            //
            // grpHeatmap
            //
            this.grpHeatmap.Controls.Add(this.btnHeatmapClear);
            this.grpHeatmap.Controls.Add(this.btnHeatmapCreate);
            this.grpHeatmap.Controls.Add(this.txtHeatmapCategory);
            this.grpHeatmap.Controls.Add(this.lblHeatmapCategory);
            this.grpHeatmap.Controls.Add(this.btnHeatmapPointOsnap);
            this.grpHeatmap.Controls.Add(this.numHeatmapZ);
            this.grpHeatmap.Controls.Add(this.numHeatmapY);
            this.grpHeatmap.Controls.Add(this.numHeatmapX);
            this.grpHeatmap.Controls.Add(this.lblHeatmapPoint);
            this.grpHeatmap.Controls.Add(this.cmbHeatmapSource);
            this.grpHeatmap.Controls.Add(this.lblHeatmapSource);
            this.grpHeatmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHeatmap.Location = new System.Drawing.Point(8, 480);
            this.grpHeatmap.Name = "grpHeatmap";
            this.grpHeatmap.Size = new System.Drawing.Size(360, 230);
            this.grpHeatmap.TabIndex = 3;
            this.grpHeatmap.TabStop = false;
            this.grpHeatmap.Text = "4. 히트맵";
            //
            // btnHeatmapClear
            //
            this.btnHeatmapClear.Location = new System.Drawing.Point(184, 108);
            this.btnHeatmapClear.Name = "btnHeatmapClear";
            this.btnHeatmapClear.Size = new System.Drawing.Size(164, 23);
            this.btnHeatmapClear.TabIndex = 10;
            this.btnHeatmapClear.Text = "히트맵 삭제";
            this.btnHeatmapClear.UseVisualStyleBackColor = true;
            this.btnHeatmapClear.Click += new System.EventHandler(this.btnHeatmapClear_Click);
            //
            // btnHeatmapCreate
            //
            this.btnHeatmapCreate.Location = new System.Drawing.Point(12, 108);
            this.btnHeatmapCreate.Name = "btnHeatmapCreate";
            this.btnHeatmapCreate.Size = new System.Drawing.Size(166, 23);
            this.btnHeatmapCreate.TabIndex = 9;
            this.btnHeatmapCreate.Text = "히트맵 생성 (선택 노드)";
            this.btnHeatmapCreate.UseVisualStyleBackColor = true;
            this.btnHeatmapCreate.Click += new System.EventHandler(this.btnHeatmapCreate_Click);
            //
            // txtHeatmapCategory
            //
            this.txtHeatmapCategory.Location = new System.Drawing.Point(84, 81);
            this.txtHeatmapCategory.Name = "txtHeatmapCategory";
            this.txtHeatmapCategory.Size = new System.Drawing.Size(120, 21);
            this.txtHeatmapCategory.TabIndex = 8;
            this.txtHeatmapCategory.Text = "HEATMAP";
            //
            // lblHeatmapCategory
            //
            this.lblHeatmapCategory.AutoSize = true;
            this.lblHeatmapCategory.Location = new System.Drawing.Point(12, 85);
            this.lblHeatmapCategory.Name = "lblHeatmapCategory";
            this.lblHeatmapCategory.Size = new System.Drawing.Size(53, 12);
            this.lblHeatmapCategory.TabIndex = 7;
            this.lblHeatmapCategory.Text = "카테고리";
            //
            // btnHeatmapPointOsnap
            //
            this.btnHeatmapPointOsnap.Location = new System.Drawing.Point(284, 52);
            this.btnHeatmapPointOsnap.Name = "btnHeatmapPointOsnap";
            this.btnHeatmapPointOsnap.Size = new System.Drawing.Size(64, 23);
            this.btnHeatmapPointOsnap.TabIndex = 6;
            this.btnHeatmapPointOsnap.Text = "Osnap";
            this.btnHeatmapPointOsnap.UseVisualStyleBackColor = true;
            this.btnHeatmapPointOsnap.Click += new System.EventHandler(this.btnHeatmapPointOsnap_Click);
            //
            // numHeatmapZ
            //
            this.numHeatmapZ.DecimalPlaces = 3;
            this.numHeatmapZ.Location = new System.Drawing.Point(216, 53);
            this.numHeatmapZ.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numHeatmapZ.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numHeatmapZ.Name = "numHeatmapZ";
            this.numHeatmapZ.Size = new System.Drawing.Size(62, 21);
            this.numHeatmapZ.TabIndex = 5;
            //
            // numHeatmapY
            //
            this.numHeatmapY.DecimalPlaces = 3;
            this.numHeatmapY.Location = new System.Drawing.Point(150, 53);
            this.numHeatmapY.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numHeatmapY.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numHeatmapY.Name = "numHeatmapY";
            this.numHeatmapY.Size = new System.Drawing.Size(62, 21);
            this.numHeatmapY.TabIndex = 4;
            //
            // numHeatmapX
            //
            this.numHeatmapX.DecimalPlaces = 3;
            this.numHeatmapX.Location = new System.Drawing.Point(84, 53);
            this.numHeatmapX.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numHeatmapX.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numHeatmapX.Name = "numHeatmapX";
            this.numHeatmapX.Size = new System.Drawing.Size(62, 21);
            this.numHeatmapX.TabIndex = 3;
            //
            // lblHeatmapPoint
            //
            this.lblHeatmapPoint.AutoSize = true;
            this.lblHeatmapPoint.Location = new System.Drawing.Point(12, 57);
            this.lblHeatmapPoint.Name = "lblHeatmapPoint";
            this.lblHeatmapPoint.Size = new System.Drawing.Size(41, 12);
            this.lblHeatmapPoint.TabIndex = 2;
            this.lblHeatmapPoint.Text = "기준점";
            //
            // cmbHeatmapSource
            //
            this.cmbHeatmapSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHeatmapSource.Location = new System.Drawing.Point(84, 24);
            this.cmbHeatmapSource.Name = "cmbHeatmapSource";
            this.cmbHeatmapSource.Size = new System.Drawing.Size(120, 20);
            this.cmbHeatmapSource.TabIndex = 1;
            this.cmbHeatmapSource.SelectedIndexChanged += new System.EventHandler(this.cmbHeatmapSource_SelectedIndexChanged);
            //
            // lblHeatmapSource
            //
            this.lblHeatmapSource.AutoSize = true;
            this.lblHeatmapSource.Location = new System.Drawing.Point(12, 28);
            this.lblHeatmapSource.Name = "lblHeatmapSource";
            this.lblHeatmapSource.Size = new System.Drawing.Size(57, 12);
            this.lblHeatmapSource.TabIndex = 0;
            this.lblHeatmapSource.Text = "스칼라 값";
            //
            // grpRun
            //
            this.grpRun.Controls.Add(this.btnCreate);
            this.grpRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRun.Location = new System.Drawing.Point(8, 420);
            this.grpRun.Name = "grpRun";
            this.grpRun.Size = new System.Drawing.Size(360, 60);
            this.grpRun.TabIndex = 2;
            this.grpRun.TabStop = false;
            this.grpRun.Text = "3. 생성";
            //
            // btnCreate
            //
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(12, 24);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(336, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "생성";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            //
            // grpSetup
            //
            this.grpSetup.Controls.Add(this.lblCreateHint);
            this.grpSetup.Controls.Add(this.numRotDegree);
            this.grpSetup.Controls.Add(this.lblRotDegree);
            this.grpSetup.Controls.Add(this.numRotZ);
            this.grpSetup.Controls.Add(this.numRotY);
            this.grpSetup.Controls.Add(this.numRotX);
            this.grpSetup.Controls.Add(this.lblRotation);
            this.grpSetup.Controls.Add(this.btnCreateColor);
            this.grpSetup.Controls.Add(this.cmbAxisAnchor);
            this.grpSetup.Controls.Add(this.lblAxisAnchor);
            this.grpSetup.Controls.Add(this.numSegmentCount);
            this.grpSetup.Controls.Add(this.lblSegmentCount);
            this.grpSetup.Controls.Add(this.cmbStrokePattern);
            this.grpSetup.Controls.Add(this.lblStrokePattern);
            this.grpSetup.Controls.Add(this.numStrokeThickness);
            this.grpSetup.Controls.Add(this.lblStrokeThickness);
            this.grpSetup.Controls.Add(this.txtCreateCategory);
            this.grpSetup.Controls.Add(this.lblCreateCategory);
            this.grpSetup.Controls.Add(this.numValue3);
            this.grpSetup.Controls.Add(this.lblValue3);
            this.grpSetup.Controls.Add(this.numValue2);
            this.grpSetup.Controls.Add(this.lblValue2);
            this.grpSetup.Controls.Add(this.numValue1);
            this.grpSetup.Controls.Add(this.lblValue1);
            this.grpSetup.Controls.Add(this.btnPoint3Osnap);
            this.grpSetup.Controls.Add(this.numP3Z);
            this.grpSetup.Controls.Add(this.numP3Y);
            this.grpSetup.Controls.Add(this.numP3X);
            this.grpSetup.Controls.Add(this.lblPoint3);
            this.grpSetup.Controls.Add(this.btnPoint2Osnap);
            this.grpSetup.Controls.Add(this.numP2Z);
            this.grpSetup.Controls.Add(this.numP2Y);
            this.grpSetup.Controls.Add(this.numP2X);
            this.grpSetup.Controls.Add(this.lblPoint2);
            this.grpSetup.Controls.Add(this.btnPoint1Osnap);
            this.grpSetup.Controls.Add(this.numP1Z);
            this.grpSetup.Controls.Add(this.numP1Y);
            this.grpSetup.Controls.Add(this.numP1X);
            this.grpSetup.Controls.Add(this.lblPoint1);
            this.grpSetup.Controls.Add(this.cmbCreateMode);
            this.grpSetup.Controls.Add(this.lblCreateMode);
            this.grpSetup.Controls.Add(this.cmbShapeType);
            this.grpSetup.Controls.Add(this.lblShapeType);
            this.grpSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSetup.Location = new System.Drawing.Point(8, 104);
            this.grpSetup.Name = "grpSetup";
            this.grpSetup.Size = new System.Drawing.Size(360, 316);
            this.grpSetup.TabIndex = 1;
            this.grpSetup.TabStop = false;
            this.grpSetup.Text = "2. 형상 설정";
            //
            // lblCreateHint
            //
            this.lblCreateHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreateHint.Location = new System.Drawing.Point(12, 276);
            this.lblCreateHint.Name = "lblCreateHint";
            this.lblCreateHint.Size = new System.Drawing.Size(336, 32);
            this.lblCreateHint.TabIndex = 42;
            //
            // numRotDegree
            //
            this.numRotDegree.DecimalPlaces = 1;
            this.numRotDegree.Location = new System.Drawing.Point(276, 249);
            this.numRotDegree.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numRotDegree.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numRotDegree.Name = "numRotDegree";
            this.numRotDegree.Size = new System.Drawing.Size(72, 21);
            this.numRotDegree.TabIndex = 41;
            //
            // lblRotDegree
            //
            this.lblRotDegree.AutoSize = true;
            this.lblRotDegree.Location = new System.Drawing.Point(242, 253);
            this.lblRotDegree.Name = "lblRotDegree";
            this.lblRotDegree.Size = new System.Drawing.Size(29, 12);
            this.lblRotDegree.TabIndex = 40;
            this.lblRotDegree.Text = "각도";
            //
            // numRotZ
            //
            this.numRotZ.DecimalPlaces = 2;
            this.numRotZ.Location = new System.Drawing.Point(180, 249);
            this.numRotZ.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRotZ.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numRotZ.Name = "numRotZ";
            this.numRotZ.Size = new System.Drawing.Size(56, 21);
            this.numRotZ.TabIndex = 39;
            this.numRotZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // numRotY
            //
            this.numRotY.DecimalPlaces = 2;
            this.numRotY.Location = new System.Drawing.Point(120, 249);
            this.numRotY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRotY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numRotY.Name = "numRotY";
            this.numRotY.Size = new System.Drawing.Size(56, 21);
            this.numRotY.TabIndex = 38;
            //
            // numRotX
            //
            this.numRotX.DecimalPlaces = 2;
            this.numRotX.Location = new System.Drawing.Point(60, 249);
            this.numRotX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRotX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numRotX.Name = "numRotX";
            this.numRotX.Size = new System.Drawing.Size(56, 21);
            this.numRotX.TabIndex = 37;
            //
            // lblRotation
            //
            this.lblRotation.AutoSize = true;
            this.lblRotation.Location = new System.Drawing.Point(12, 253);
            this.lblRotation.Name = "lblRotation";
            this.lblRotation.Size = new System.Drawing.Size(41, 12);
            this.lblRotation.TabIndex = 36;
            this.lblRotation.Text = "회전축";
            //
            // btnCreateColor
            //
            this.btnCreateColor.BackColor = System.Drawing.Color.Orange;
            this.btnCreateColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateColor.Location = new System.Drawing.Point(136, 220);
            this.btnCreateColor.Name = "btnCreateColor";
            this.btnCreateColor.Size = new System.Drawing.Size(80, 23);
            this.btnCreateColor.TabIndex = 35;
            this.btnCreateColor.Text = "색상";
            this.btnCreateColor.UseVisualStyleBackColor = false;
            this.btnCreateColor.Click += new System.EventHandler(this.btnCreateColor_Click);
            //
            // cmbAxisAnchor
            //
            this.cmbAxisAnchor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAxisAnchor.Location = new System.Drawing.Point(48, 221);
            this.cmbAxisAnchor.Name = "cmbAxisAnchor";
            this.cmbAxisAnchor.Size = new System.Drawing.Size(80, 20);
            this.cmbAxisAnchor.TabIndex = 34;
            //
            // lblAxisAnchor
            //
            this.lblAxisAnchor.AutoSize = true;
            this.lblAxisAnchor.Location = new System.Drawing.Point(12, 225);
            this.lblAxisAnchor.Name = "lblAxisAnchor";
            this.lblAxisAnchor.Size = new System.Drawing.Size(29, 12);
            this.lblAxisAnchor.TabIndex = 33;
            this.lblAxisAnchor.Text = "기준";
            //
            // numSegmentCount
            //
            this.numSegmentCount.Location = new System.Drawing.Point(264, 193);
            this.numSegmentCount.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numSegmentCount.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numSegmentCount.Name = "numSegmentCount";
            this.numSegmentCount.Size = new System.Drawing.Size(52, 21);
            this.numSegmentCount.TabIndex = 32;
            this.numSegmentCount.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            //
            // lblSegmentCount
            //
            this.lblSegmentCount.AutoSize = true;
            this.lblSegmentCount.Location = new System.Drawing.Point(230, 197);
            this.lblSegmentCount.Name = "lblSegmentCount";
            this.lblSegmentCount.Size = new System.Drawing.Size(29, 12);
            this.lblSegmentCount.TabIndex = 31;
            this.lblSegmentCount.Text = "분할";
            //
            // cmbStrokePattern
            //
            this.cmbStrokePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStrokePattern.Location = new System.Drawing.Point(142, 193);
            this.cmbStrokePattern.Name = "cmbStrokePattern";
            this.cmbStrokePattern.Size = new System.Drawing.Size(80, 20);
            this.cmbStrokePattern.TabIndex = 30;
            //
            // lblStrokePattern
            //
            this.lblStrokePattern.AutoSize = true;
            this.lblStrokePattern.Location = new System.Drawing.Point(108, 197);
            this.lblStrokePattern.Name = "lblStrokePattern";
            this.lblStrokePattern.Size = new System.Drawing.Size(29, 12);
            this.lblStrokePattern.TabIndex = 29;
            this.lblStrokePattern.Text = "패턴";
            //
            // numStrokeThickness
            //
            this.numStrokeThickness.DecimalPlaces = 1;
            this.numStrokeThickness.Location = new System.Drawing.Point(48, 193);
            this.numStrokeThickness.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numStrokeThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStrokeThickness.Name = "numStrokeThickness";
            this.numStrokeThickness.Size = new System.Drawing.Size(52, 21);
            this.numStrokeThickness.TabIndex = 28;
            this.numStrokeThickness.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            //
            // lblStrokeThickness
            //
            this.lblStrokeThickness.AutoSize = true;
            this.lblStrokeThickness.Location = new System.Drawing.Point(12, 197);
            this.lblStrokeThickness.Name = "lblStrokeThickness";
            this.lblStrokeThickness.Size = new System.Drawing.Size(29, 12);
            this.lblStrokeThickness.TabIndex = 27;
            this.lblStrokeThickness.Text = "두께";
            //
            // txtCreateCategory
            //
            this.txtCreateCategory.Location = new System.Drawing.Point(244, 165);
            this.txtCreateCategory.Name = "txtCreateCategory";
            this.txtCreateCategory.Size = new System.Drawing.Size(104, 21);
            this.txtCreateCategory.TabIndex = 26;
            this.txtCreateCategory.Text = "SHAPE_SAMPLE";
            //
            // lblCreateCategory
            //
            this.lblCreateCategory.AutoSize = true;
            this.lblCreateCategory.Location = new System.Drawing.Point(184, 169);
            this.lblCreateCategory.Name = "lblCreateCategory";
            this.lblCreateCategory.Size = new System.Drawing.Size(53, 12);
            this.lblCreateCategory.TabIndex = 25;
            this.lblCreateCategory.Text = "카테고리";
            //
            // numValue3
            //
            this.numValue3.DecimalPlaces = 2;
            this.numValue3.Location = new System.Drawing.Point(84, 165);
            this.numValue3.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numValue3.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numValue3.Name = "numValue3";
            this.numValue3.Size = new System.Drawing.Size(90, 21);
            this.numValue3.TabIndex = 24;
            this.numValue3.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            //
            // lblValue3
            //
            this.lblValue3.Location = new System.Drawing.Point(12, 169);
            this.lblValue3.Name = "lblValue3";
            this.lblValue3.Size = new System.Drawing.Size(70, 12);
            this.lblValue3.TabIndex = 23;
            this.lblValue3.Text = "값 3";
            //
            // numValue2
            //
            this.numValue2.DecimalPlaces = 2;
            this.numValue2.Location = new System.Drawing.Point(258, 137);
            this.numValue2.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numValue2.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numValue2.Name = "numValue2";
            this.numValue2.Size = new System.Drawing.Size(90, 21);
            this.numValue2.TabIndex = 22;
            this.numValue2.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            //
            // lblValue2
            //
            this.lblValue2.Location = new System.Drawing.Point(184, 141);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(70, 12);
            this.lblValue2.TabIndex = 21;
            this.lblValue2.Text = "값 2";
            //
            // numValue1
            //
            this.numValue1.DecimalPlaces = 2;
            this.numValue1.Location = new System.Drawing.Point(84, 137);
            this.numValue1.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numValue1.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numValue1.Name = "numValue1";
            this.numValue1.Size = new System.Drawing.Size(90, 21);
            this.numValue1.TabIndex = 20;
            this.numValue1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            //
            // lblValue1
            //
            this.lblValue1.Location = new System.Drawing.Point(12, 141);
            this.lblValue1.Name = "lblValue1";
            this.lblValue1.Size = new System.Drawing.Size(70, 12);
            this.lblValue1.TabIndex = 19;
            this.lblValue1.Text = "값 1";
            //
            // btnPoint3Osnap
            //
            this.btnPoint3Osnap.Location = new System.Drawing.Point(284, 108);
            this.btnPoint3Osnap.Name = "btnPoint3Osnap";
            this.btnPoint3Osnap.Size = new System.Drawing.Size(64, 23);
            this.btnPoint3Osnap.TabIndex = 18;
            this.btnPoint3Osnap.Text = "Osnap";
            this.btnPoint3Osnap.UseVisualStyleBackColor = true;
            this.btnPoint3Osnap.Click += new System.EventHandler(this.btnPoint3Osnap_Click);
            //
            // numP3Z
            //
            this.numP3Z.DecimalPlaces = 3;
            this.numP3Z.Location = new System.Drawing.Point(212, 109);
            this.numP3Z.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numP3Z.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numP3Z.Name = "numP3Z";
            this.numP3Z.Size = new System.Drawing.Size(66, 21);
            this.numP3Z.TabIndex = 17;
            //
            // numP3Y
            //
            this.numP3Y.DecimalPlaces = 3;
            this.numP3Y.Location = new System.Drawing.Point(142, 109);
            this.numP3Y.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numP3Y.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numP3Y.Name = "numP3Y";
            this.numP3Y.Size = new System.Drawing.Size(66, 21);
            this.numP3Y.TabIndex = 16;
            //
            // numP3X
            //
            this.numP3X.DecimalPlaces = 3;
            this.numP3X.Location = new System.Drawing.Point(72, 109);
            this.numP3X.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numP3X.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numP3X.Name = "numP3X";
            this.numP3X.Size = new System.Drawing.Size(66, 21);
            this.numP3X.TabIndex = 15;
            //
            // lblPoint3
            //
            this.lblPoint3.Location = new System.Drawing.Point(12, 113);
            this.lblPoint3.Name = "lblPoint3";
            this.lblPoint3.Size = new System.Drawing.Size(58, 12);
            this.lblPoint3.TabIndex = 14;
            this.lblPoint3.Text = "세 번째 점";
            //
            // btnPoint2Osnap
            //
            this.btnPoint2Osnap.Location = new System.Drawing.Point(284, 80);
            this.btnPoint2Osnap.Name = "btnPoint2Osnap";
            this.btnPoint2Osnap.Size = new System.Drawing.Size(64, 23);
            this.btnPoint2Osnap.TabIndex = 13;
            this.btnPoint2Osnap.Text = "Osnap";
            this.btnPoint2Osnap.UseVisualStyleBackColor = true;
            this.btnPoint2Osnap.Click += new System.EventHandler(this.btnPoint2Osnap_Click);
            //
            // numP2Z
            //
            this.numP2Z.DecimalPlaces = 3;
            this.numP2Z.Location = new System.Drawing.Point(212, 81);
            this.numP2Z.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numP2Z.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numP2Z.Name = "numP2Z";
            this.numP2Z.Size = new System.Drawing.Size(66, 21);
            this.numP2Z.TabIndex = 12;
            //
            // numP2Y
            //
            this.numP2Y.DecimalPlaces = 3;
            this.numP2Y.Location = new System.Drawing.Point(142, 81);
            this.numP2Y.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numP2Y.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numP2Y.Name = "numP2Y";
            this.numP2Y.Size = new System.Drawing.Size(66, 21);
            this.numP2Y.TabIndex = 11;
            //
            // numP2X
            //
            this.numP2X.DecimalPlaces = 3;
            this.numP2X.Location = new System.Drawing.Point(72, 81);
            this.numP2X.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numP2X.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numP2X.Name = "numP2X";
            this.numP2X.Size = new System.Drawing.Size(66, 21);
            this.numP2X.TabIndex = 10;
            this.numP2X.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // lblPoint2
            //
            this.lblPoint2.Location = new System.Drawing.Point(12, 85);
            this.lblPoint2.Name = "lblPoint2";
            this.lblPoint2.Size = new System.Drawing.Size(58, 12);
            this.lblPoint2.TabIndex = 9;
            this.lblPoint2.Text = "보조점";
            //
            // btnPoint1Osnap
            //
            this.btnPoint1Osnap.Location = new System.Drawing.Point(284, 52);
            this.btnPoint1Osnap.Name = "btnPoint1Osnap";
            this.btnPoint1Osnap.Size = new System.Drawing.Size(64, 23);
            this.btnPoint1Osnap.TabIndex = 8;
            this.btnPoint1Osnap.Text = "Osnap";
            this.btnPoint1Osnap.UseVisualStyleBackColor = true;
            this.btnPoint1Osnap.Click += new System.EventHandler(this.btnPoint1Osnap_Click);
            //
            // numP1Z
            //
            this.numP1Z.DecimalPlaces = 3;
            this.numP1Z.Location = new System.Drawing.Point(212, 53);
            this.numP1Z.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numP1Z.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numP1Z.Name = "numP1Z";
            this.numP1Z.Size = new System.Drawing.Size(66, 21);
            this.numP1Z.TabIndex = 7;
            //
            // numP1Y
            //
            this.numP1Y.DecimalPlaces = 3;
            this.numP1Y.Location = new System.Drawing.Point(142, 53);
            this.numP1Y.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numP1Y.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numP1Y.Name = "numP1Y";
            this.numP1Y.Size = new System.Drawing.Size(66, 21);
            this.numP1Y.TabIndex = 6;
            //
            // numP1X
            //
            this.numP1X.DecimalPlaces = 3;
            this.numP1X.Location = new System.Drawing.Point(72, 53);
            this.numP1X.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numP1X.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numP1X.Name = "numP1X";
            this.numP1X.Size = new System.Drawing.Size(66, 21);
            this.numP1X.TabIndex = 5;
            //
            // lblPoint1
            //
            this.lblPoint1.Location = new System.Drawing.Point(12, 57);
            this.lblPoint1.Name = "lblPoint1";
            this.lblPoint1.Size = new System.Drawing.Size(58, 12);
            this.lblPoint1.TabIndex = 4;
            this.lblPoint1.Text = "기준점";
            //
            // cmbCreateMode
            //
            this.cmbCreateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCreateMode.Location = new System.Drawing.Point(206, 24);
            this.cmbCreateMode.Name = "cmbCreateMode";
            this.cmbCreateMode.Size = new System.Drawing.Size(142, 20);
            this.cmbCreateMode.TabIndex = 3;
            this.cmbCreateMode.SelectedIndexChanged += new System.EventHandler(this.cmbCreateMode_SelectedIndexChanged);
            //
            // lblCreateMode
            //
            this.lblCreateMode.AutoSize = true;
            this.lblCreateMode.Location = new System.Drawing.Point(170, 28);
            this.lblCreateMode.Name = "lblCreateMode";
            this.lblCreateMode.Size = new System.Drawing.Size(29, 12);
            this.lblCreateMode.TabIndex = 2;
            this.lblCreateMode.Text = "방식";
            //
            // cmbShapeType
            //
            this.cmbShapeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShapeType.Location = new System.Drawing.Point(48, 24);
            this.cmbShapeType.Name = "cmbShapeType";
            this.cmbShapeType.Size = new System.Drawing.Size(112, 20);
            this.cmbShapeType.TabIndex = 1;
            this.cmbShapeType.SelectedIndexChanged += new System.EventHandler(this.cmbShapeType_SelectedIndexChanged);
            //
            // lblShapeType
            //
            this.lblShapeType.AutoSize = true;
            this.lblShapeType.Location = new System.Drawing.Point(12, 28);
            this.lblShapeType.Name = "lblShapeType";
            this.lblShapeType.Size = new System.Drawing.Size(29, 12);
            this.lblShapeType.TabIndex = 0;
            this.lblShapeType.Text = "형상";
            //
            // grpModel
            //
            this.grpModel.Controls.Add(this.lblModelHint);
            this.grpModel.Controls.Add(this.btnOpenModel);
            this.grpModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpModel.Location = new System.Drawing.Point(8, 8);
            this.grpModel.Name = "grpModel";
            this.grpModel.Size = new System.Drawing.Size(360, 96);
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
            this.lblModelHint.Text = "모델을 연 뒤 형상을 만들고 목록에서 관리합니다.\r\n히트맵과 \'선택 객체 기준\' 생성은 선택한 노드를 씁니다.";
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
            this.grpCleanup.Controls.Add(this.btnClearAll);
            this.grpCleanup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCleanup.Location = new System.Drawing.Point(8, 710);
            this.grpCleanup.Name = "grpCleanup";
            this.grpCleanup.Size = new System.Drawing.Size(360, 60);
            this.grpCleanup.TabIndex = 4;
            this.grpCleanup.TabStop = false;
            this.grpCleanup.Text = "5. 정리";
            //
            // btnClearAll
            //
            this.btnClearAll.Location = new System.Drawing.Point(12, 24);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(120, 23);
            this.btnClearAll.TabIndex = 0;
            this.btnClearAll.Text = "전체 삭제";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            //
            // lblStatus
            //
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(8, 770);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(360, 22);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // splitContainer2
            //
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            //
            // splitContainer2.Panel2
            //
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1020, 800);
            this.splitContainer2.SplitterDistance = 640;
            this.splitContainer2.TabIndex = 0;
            //
            // splitContainer3
            //
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            // splitContainer3.Panel1
            //
            this.splitContainer3.Panel1.Controls.Add(this.grpList);
            //
            // splitContainer3.Panel2
            //
            this.splitContainer3.Panel2.Controls.Add(this.grpSegments);
            this.splitContainer3.Size = new System.Drawing.Size(376, 800);
            this.splitContainer3.SplitterDistance = 560;
            this.splitContainer3.TabIndex = 0;
            //
            // grpList
            //
            this.grpList.Controls.Add(this.btnDeleteSelected);
            this.grpList.Controls.Add(this.btnDirectionSelected);
            this.grpList.Controls.Add(this.btnRotateSelected);
            this.grpList.Controls.Add(this.numAngle);
            this.grpList.Controls.Add(this.lblAngle);
            this.grpList.Controls.Add(this.numAxisZ);
            this.grpList.Controls.Add(this.numAxisY);
            this.grpList.Controls.Add(this.numAxisX);
            this.grpList.Controls.Add(this.lblAxis);
            this.grpList.Controls.Add(this.btnMoveOsnap);
            this.grpList.Controls.Add(this.numMoveZ);
            this.grpList.Controls.Add(this.numMoveY);
            this.grpList.Controls.Add(this.numMoveX);
            this.grpList.Controls.Add(this.lblMove);
            this.grpList.Controls.Add(this.btnSelectedColor);
            this.grpList.Controls.Add(this.lblSelectedColor);
            this.grpList.Controls.Add(this.btnHighlightColor);
            this.grpList.Controls.Add(this.lblHighlightColor);
            this.grpList.Controls.Add(this.numSelectionRadius);
            this.grpList.Controls.Add(this.lblSelectionRadius);
            this.grpList.Controls.Add(this.chkDepthTest);
            this.grpList.Controls.Add(this.chkHighlightable);
            this.grpList.Controls.Add(this.chkSelectable);
            this.grpList.Controls.Add(this.btnHide);
            this.grpList.Controls.Add(this.btnShow);
            this.grpList.Controls.Add(this.btnCategoryDelete);
            this.grpList.Controls.Add(this.btnCategoryClear);
            this.grpList.Controls.Add(this.btnCategoryApply);
            this.grpList.Controls.Add(this.btnCategoryFind);
            this.grpList.Controls.Add(this.txtManageCategory);
            this.grpList.Controls.Add(this.lblManageCategory);
            this.grpList.Controls.Add(this.dgvShapes);
            this.grpList.Controls.Add(this.btnRefresh);
            this.grpList.Controls.Add(this.cmbManageTarget);
            this.grpList.Controls.Add(this.lblManageTarget);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Location = new System.Drawing.Point(0, 0);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(376, 560);
            this.grpList.TabIndex = 0;
            this.grpList.TabStop = false;
            this.grpList.Text = "형상 목록·관리 (여러 행 선택 가능)";
            //
            // btnDeleteSelected
            //
            this.btnDeleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteSelected.Location = new System.Drawing.Point(264, 525);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteSelected.TabIndex = 34;
            this.btnDeleteSelected.Text = "선택 삭제";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            //
            // btnDirectionSelected
            //
            this.btnDirectionSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDirectionSelected.Location = new System.Drawing.Point(98, 525);
            this.btnDirectionSelected.Name = "btnDirectionSelected";
            this.btnDirectionSelected.Size = new System.Drawing.Size(80, 23);
            this.btnDirectionSelected.TabIndex = 33;
            this.btnDirectionSelected.Text = "방향 지정";
            this.btnDirectionSelected.UseVisualStyleBackColor = true;
            this.btnDirectionSelected.Click += new System.EventHandler(this.btnDirectionSelected_Click);
            //
            // btnRotateSelected
            //
            this.btnRotateSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRotateSelected.Location = new System.Drawing.Point(12, 525);
            this.btnRotateSelected.Name = "btnRotateSelected";
            this.btnRotateSelected.Size = new System.Drawing.Size(80, 23);
            this.btnRotateSelected.TabIndex = 32;
            this.btnRotateSelected.Text = "회전";
            this.btnRotateSelected.UseVisualStyleBackColor = true;
            this.btnRotateSelected.Click += new System.EventHandler(this.btnRotateSelected_Click);
            //
            // numAngle
            //
            this.numAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numAngle.DecimalPlaces = 1;
            this.numAngle.Location = new System.Drawing.Point(278, 498);
            this.numAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numAngle.Name = "numAngle";
            this.numAngle.Size = new System.Drawing.Size(86, 21);
            this.numAngle.TabIndex = 31;
            //
            // lblAngle
            //
            this.lblAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAngle.AutoSize = true;
            this.lblAngle.Location = new System.Drawing.Point(244, 502);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(29, 12);
            this.lblAngle.TabIndex = 30;
            this.lblAngle.Text = "각도";
            //
            // numAxisZ
            //
            this.numAxisZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numAxisZ.DecimalPlaces = 2;
            this.numAxisZ.Location = new System.Drawing.Point(180, 498);
            this.numAxisZ.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numAxisZ.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numAxisZ.Name = "numAxisZ";
            this.numAxisZ.Size = new System.Drawing.Size(56, 21);
            this.numAxisZ.TabIndex = 29;
            //
            // numAxisY
            //
            this.numAxisY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numAxisY.DecimalPlaces = 2;
            this.numAxisY.Location = new System.Drawing.Point(120, 498);
            this.numAxisY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numAxisY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numAxisY.Name = "numAxisY";
            this.numAxisY.Size = new System.Drawing.Size(56, 21);
            this.numAxisY.TabIndex = 28;
            //
            // numAxisX
            //
            this.numAxisX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numAxisX.DecimalPlaces = 2;
            this.numAxisX.Location = new System.Drawing.Point(60, 498);
            this.numAxisX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numAxisX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numAxisX.Name = "numAxisX";
            this.numAxisX.Size = new System.Drawing.Size(56, 21);
            this.numAxisX.TabIndex = 27;
            this.numAxisX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // lblAxis
            //
            this.lblAxis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAxis.AutoSize = true;
            this.lblAxis.Location = new System.Drawing.Point(12, 502);
            this.lblAxis.Name = "lblAxis";
            this.lblAxis.Size = new System.Drawing.Size(47, 12);
            this.lblAxis.TabIndex = 26;
            this.lblAxis.Text = "축/방향";
            //
            // btnMoveOsnap
            //
            this.btnMoveOsnap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveOsnap.Location = new System.Drawing.Point(272, 469);
            this.btnMoveOsnap.Name = "btnMoveOsnap";
            this.btnMoveOsnap.Size = new System.Drawing.Size(94, 23);
            this.btnMoveOsnap.TabIndex = 25;
            this.btnMoveOsnap.Text = "Osnap 이동";
            this.btnMoveOsnap.UseVisualStyleBackColor = true;
            this.btnMoveOsnap.Click += new System.EventHandler(this.btnMoveOsnap_Click);
            //
            // numMoveZ
            //
            this.numMoveZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numMoveZ.DecimalPlaces = 3;
            this.numMoveZ.Location = new System.Drawing.Point(196, 470);
            this.numMoveZ.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numMoveZ.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numMoveZ.Name = "numMoveZ";
            this.numMoveZ.Size = new System.Drawing.Size(70, 21);
            this.numMoveZ.TabIndex = 24;
            this.numMoveZ.ValueChanged += new System.EventHandler(this.numMove_ValueChanged);
            //
            // numMoveY
            //
            this.numMoveY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numMoveY.DecimalPlaces = 3;
            this.numMoveY.Location = new System.Drawing.Point(122, 470);
            this.numMoveY.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numMoveY.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numMoveY.Name = "numMoveY";
            this.numMoveY.Size = new System.Drawing.Size(70, 21);
            this.numMoveY.TabIndex = 23;
            this.numMoveY.ValueChanged += new System.EventHandler(this.numMove_ValueChanged);
            //
            // numMoveX
            //
            this.numMoveX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numMoveX.DecimalPlaces = 3;
            this.numMoveX.Location = new System.Drawing.Point(48, 470);
            this.numMoveX.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numMoveX.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numMoveX.Name = "numMoveX";
            this.numMoveX.Size = new System.Drawing.Size(70, 21);
            this.numMoveX.TabIndex = 22;
            this.numMoveX.ValueChanged += new System.EventHandler(this.numMove_ValueChanged);
            //
            // lblMove
            //
            this.lblMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMove.AutoSize = true;
            this.lblMove.Location = new System.Drawing.Point(12, 474);
            this.lblMove.Name = "lblMove";
            this.lblMove.Size = new System.Drawing.Size(29, 12);
            this.lblMove.TabIndex = 21;
            this.lblMove.Text = "위치";
            //
            // btnSelectedColor
            //
            this.btnSelectedColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectedColor.BackColor = System.Drawing.Color.Red;
            this.btnSelectedColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectedColor.Location = new System.Drawing.Point(200, 441);
            this.btnSelectedColor.Name = "btnSelectedColor";
            this.btnSelectedColor.Size = new System.Drawing.Size(60, 23);
            this.btnSelectedColor.TabIndex = 20;
            this.btnSelectedColor.Text = "선택";
            this.btnSelectedColor.UseVisualStyleBackColor = false;
            this.btnSelectedColor.Click += new System.EventHandler(this.btnSelectedColor_Click);
            //
            // lblSelectedColor
            //
            this.lblSelectedColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectedColor.AutoSize = true;
            this.lblSelectedColor.Location = new System.Drawing.Point(140, 446);
            this.lblSelectedColor.Name = "lblSelectedColor";
            this.lblSelectedColor.Size = new System.Drawing.Size(57, 12);
            this.lblSelectedColor.TabIndex = 19;
            this.lblSelectedColor.Text = "선택 색상";
            //
            // btnHighlightColor
            //
            this.btnHighlightColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHighlightColor.BackColor = System.Drawing.Color.Yellow;
            this.btnHighlightColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHighlightColor.Location = new System.Drawing.Point(72, 441);
            this.btnHighlightColor.Name = "btnHighlightColor";
            this.btnHighlightColor.Size = new System.Drawing.Size(60, 23);
            this.btnHighlightColor.TabIndex = 18;
            this.btnHighlightColor.Text = "선택";
            this.btnHighlightColor.UseVisualStyleBackColor = false;
            this.btnHighlightColor.Click += new System.EventHandler(this.btnHighlightColor_Click);
            //
            // lblHighlightColor
            //
            this.lblHighlightColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHighlightColor.AutoSize = true;
            this.lblHighlightColor.Location = new System.Drawing.Point(12, 446);
            this.lblHighlightColor.Name = "lblHighlightColor";
            this.lblHighlightColor.Size = new System.Drawing.Size(57, 12);
            this.lblHighlightColor.TabIndex = 17;
            this.lblHighlightColor.Text = "강조 색상";
            //
            // numSelectionRadius
            //
            this.numSelectionRadius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numSelectionRadius.Location = new System.Drawing.Point(200, 414);
            this.numSelectionRadius.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numSelectionRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSelectionRadius.Name = "numSelectionRadius";
            this.numSelectionRadius.Size = new System.Drawing.Size(50, 21);
            this.numSelectionRadius.TabIndex = 16;
            this.numSelectionRadius.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numSelectionRadius.ValueChanged += new System.EventHandler(this.numSelectionRadius_ValueChanged);
            //
            // lblSelectionRadius
            //
            this.lblSelectionRadius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectionRadius.AutoSize = true;
            this.lblSelectionRadius.Location = new System.Drawing.Point(140, 418);
            this.lblSelectionRadius.Name = "lblSelectionRadius";
            this.lblSelectionRadius.Size = new System.Drawing.Size(57, 12);
            this.lblSelectionRadius.TabIndex = 15;
            this.lblSelectionRadius.Text = "선택 반경";
            //
            // chkDepthTest
            //
            this.chkDepthTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDepthTest.AutoSize = true;
            this.chkDepthTest.Checked = true;
            this.chkDepthTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDepthTest.Location = new System.Drawing.Point(12, 416);
            this.chkDepthTest.Name = "chkDepthTest";
            this.chkDepthTest.Size = new System.Drawing.Size(88, 16);
            this.chkDepthTest.TabIndex = 14;
            this.chkDepthTest.Text = "깊이 테스트";
            this.chkDepthTest.UseVisualStyleBackColor = true;
            this.chkDepthTest.CheckedChanged += new System.EventHandler(this.chkDepthTest_CheckedChanged);
            //
            // chkHighlightable
            //
            this.chkHighlightable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkHighlightable.AutoSize = true;
            this.chkHighlightable.Checked = true;
            this.chkHighlightable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHighlightable.Location = new System.Drawing.Point(230, 388);
            this.chkHighlightable.Name = "chkHighlightable";
            this.chkHighlightable.Size = new System.Drawing.Size(76, 16);
            this.chkHighlightable.TabIndex = 13;
            this.chkHighlightable.Text = "강조 가능";
            this.chkHighlightable.UseVisualStyleBackColor = true;
            this.chkHighlightable.CheckedChanged += new System.EventHandler(this.chkHighlightable_CheckedChanged);
            //
            // chkSelectable
            //
            this.chkSelectable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSelectable.AutoSize = true;
            this.chkSelectable.Checked = true;
            this.chkSelectable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelectable.Location = new System.Drawing.Point(140, 388);
            this.chkSelectable.Name = "chkSelectable";
            this.chkSelectable.Size = new System.Drawing.Size(76, 16);
            this.chkSelectable.TabIndex = 12;
            this.chkSelectable.Text = "선택 가능";
            this.chkSelectable.UseVisualStyleBackColor = true;
            this.chkSelectable.CheckedChanged += new System.EventHandler(this.chkSelectable_CheckedChanged);
            //
            // btnHide
            //
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHide.Location = new System.Drawing.Point(74, 385);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(56, 23);
            this.btnHide.TabIndex = 11;
            this.btnHide.Text = "숨김";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            //
            // btnShow
            //
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShow.Location = new System.Drawing.Point(12, 385);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(56, 23);
            this.btnShow.TabIndex = 10;
            this.btnShow.Text = "표시";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            //
            // btnCategoryDelete
            //
            this.btnCategoryDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCategoryDelete.Location = new System.Drawing.Point(248, 357);
            this.btnCategoryDelete.Name = "btnCategoryDelete";
            this.btnCategoryDelete.Size = new System.Drawing.Size(116, 23);
            this.btnCategoryDelete.TabIndex = 9;
            this.btnCategoryDelete.Text = "분류 삭제";
            this.btnCategoryDelete.UseVisualStyleBackColor = true;
            this.btnCategoryDelete.Click += new System.EventHandler(this.btnCategoryDelete_Click);
            //
            // btnCategoryClear
            //
            this.btnCategoryClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCategoryClear.Location = new System.Drawing.Point(130, 357);
            this.btnCategoryClear.Name = "btnCategoryClear";
            this.btnCategoryClear.Size = new System.Drawing.Size(112, 23);
            this.btnCategoryClear.TabIndex = 8;
            this.btnCategoryClear.Text = "분류 해제";
            this.btnCategoryClear.UseVisualStyleBackColor = true;
            this.btnCategoryClear.Click += new System.EventHandler(this.btnCategoryClear_Click);
            //
            // btnCategoryApply
            //
            this.btnCategoryApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCategoryApply.Location = new System.Drawing.Point(12, 357);
            this.btnCategoryApply.Name = "btnCategoryApply";
            this.btnCategoryApply.Size = new System.Drawing.Size(112, 23);
            this.btnCategoryApply.TabIndex = 7;
            this.btnCategoryApply.Text = "분류 지정";
            this.btnCategoryApply.UseVisualStyleBackColor = true;
            this.btnCategoryApply.Click += new System.EventHandler(this.btnCategoryApply_Click);
            //
            // btnCategoryFind
            //
            this.btnCategoryFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCategoryFind.Location = new System.Drawing.Point(248, 329);
            this.btnCategoryFind.Name = "btnCategoryFind";
            this.btnCategoryFind.Size = new System.Drawing.Size(116, 23);
            this.btnCategoryFind.TabIndex = 6;
            this.btnCategoryFind.Text = "카테고리 조회";
            this.btnCategoryFind.UseVisualStyleBackColor = true;
            this.btnCategoryFind.Click += new System.EventHandler(this.btnCategoryFind_Click);
            //
            // txtManageCategory
            //
            this.txtManageCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtManageCategory.Location = new System.Drawing.Point(72, 330);
            this.txtManageCategory.Name = "txtManageCategory";
            this.txtManageCategory.Size = new System.Drawing.Size(170, 21);
            this.txtManageCategory.TabIndex = 5;
            this.txtManageCategory.Text = "SHAPE_SAMPLE";
            //
            // lblManageCategory
            //
            this.lblManageCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblManageCategory.AutoSize = true;
            this.lblManageCategory.Location = new System.Drawing.Point(12, 334);
            this.lblManageCategory.Name = "lblManageCategory";
            this.lblManageCategory.Size = new System.Drawing.Size(53, 12);
            this.lblManageCategory.TabIndex = 4;
            this.lblManageCategory.Text = "카테고리";
            //
            // dgvShapes
            //
            this.dgvShapes.AllowUserToAddRows = false;
            this.dgvShapes.AllowUserToDeleteRows = false;
            this.dgvShapes.AllowUserToResizeRows = false;
            this.dgvShapes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShapes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShapes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShapes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colType,
            this.colCategory});
            this.dgvShapes.Location = new System.Drawing.Point(12, 52);
            this.dgvShapes.MultiSelect = true;
            this.dgvShapes.Name = "dgvShapes";
            this.dgvShapes.ReadOnly = true;
            this.dgvShapes.RowHeadersVisible = false;
            this.dgvShapes.RowTemplate.Height = 23;
            this.dgvShapes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShapes.Size = new System.Drawing.Size(352, 271);
            this.dgvShapes.TabIndex = 3;
            this.dgvShapes.SelectionChanged += new System.EventHandler(this.dgvShapes_SelectionChanged);
            //
            // colNo
            //
            this.colNo.FillWeight = 30F;
            this.colNo.HeaderText = "No";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            //
            // colType
            //
            this.colType.FillWeight = 90F;
            this.colType.HeaderText = "형상";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            //
            // colCategory
            //
            this.colCategory.FillWeight = 100F;
            this.colCategory.HeaderText = "카테고리";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            //
            // btnRefresh
            //
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(264, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "전체 목록";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // cmbManageTarget
            //
            this.cmbManageTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManageTarget.Location = new System.Drawing.Point(48, 24);
            this.cmbManageTarget.Name = "cmbManageTarget";
            this.cmbManageTarget.Size = new System.Drawing.Size(100, 20);
            this.cmbManageTarget.TabIndex = 1;
            //
            // lblManageTarget
            //
            this.lblManageTarget.AutoSize = true;
            this.lblManageTarget.Location = new System.Drawing.Point(12, 28);
            this.lblManageTarget.Name = "lblManageTarget";
            this.lblManageTarget.Size = new System.Drawing.Size(29, 12);
            this.lblManageTarget.TabIndex = 0;
            this.lblManageTarget.Text = "대상";
            //
            // grpSegments
            //
            this.grpSegments.Controls.Add(this.btnLineSegmentClear);
            this.grpSegments.Controls.Add(this.btnLineSegmentRemove);
            this.grpSegments.Controls.Add(this.btnLineSegmentAdd);
            this.grpSegments.Controls.Add(this.dgvLineSegments);
            this.grpSegments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSegments.Location = new System.Drawing.Point(0, 0);
            this.grpSegments.Name = "grpSegments";
            this.grpSegments.Size = new System.Drawing.Size(376, 236);
            this.grpSegments.TabIndex = 0;
            this.grpSegments.TabStop = false;
            this.grpSegments.Text = "선분 집합 입력 (LineSegments 생성에 사용)";
            //
            // btnLineSegmentClear
            //
            this.btnLineSegmentClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLineSegmentClear.Location = new System.Drawing.Point(248, 201);
            this.btnLineSegmentClear.Name = "btnLineSegmentClear";
            this.btnLineSegmentClear.Size = new System.Drawing.Size(116, 23);
            this.btnLineSegmentClear.TabIndex = 3;
            this.btnLineSegmentClear.Text = "전체 지우기";
            this.btnLineSegmentClear.UseVisualStyleBackColor = true;
            this.btnLineSegmentClear.Click += new System.EventHandler(this.btnLineSegmentClear_Click);
            //
            // btnLineSegmentRemove
            //
            this.btnLineSegmentRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLineSegmentRemove.Location = new System.Drawing.Point(134, 201);
            this.btnLineSegmentRemove.Name = "btnLineSegmentRemove";
            this.btnLineSegmentRemove.Size = new System.Drawing.Size(108, 23);
            this.btnLineSegmentRemove.TabIndex = 2;
            this.btnLineSegmentRemove.Text = "선택 제거";
            this.btnLineSegmentRemove.UseVisualStyleBackColor = true;
            this.btnLineSegmentRemove.Click += new System.EventHandler(this.btnLineSegmentRemove_Click);
            //
            // btnLineSegmentAdd
            //
            this.btnLineSegmentAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLineSegmentAdd.Location = new System.Drawing.Point(12, 201);
            this.btnLineSegmentAdd.Name = "btnLineSegmentAdd";
            this.btnLineSegmentAdd.Size = new System.Drawing.Size(116, 23);
            this.btnLineSegmentAdd.TabIndex = 1;
            this.btnLineSegmentAdd.Text = "추가 (점1 → 점2)";
            this.btnLineSegmentAdd.UseVisualStyleBackColor = true;
            this.btnLineSegmentAdd.Click += new System.EventHandler(this.btnLineSegmentAdd_Click);
            //
            // dgvLineSegments
            //
            this.dgvLineSegments.AllowUserToAddRows = false;
            this.dgvLineSegments.AllowUserToDeleteRows = false;
            this.dgvLineSegments.AllowUserToResizeRows = false;
            this.dgvLineSegments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLineSegments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLineSegments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineSegments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLineStart,
            this.colLineEnd});
            this.dgvLineSegments.Location = new System.Drawing.Point(12, 24);
            this.dgvLineSegments.MultiSelect = false;
            this.dgvLineSegments.Name = "dgvLineSegments";
            this.dgvLineSegments.ReadOnly = true;
            this.dgvLineSegments.RowHeadersVisible = false;
            this.dgvLineSegments.RowTemplate.Height = 23;
            this.dgvLineSegments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLineSegments.Size = new System.Drawing.Size(352, 171);
            this.dgvLineSegments.TabIndex = 0;
            //
            // colLineStart
            //
            this.colLineStart.HeaderText = "시작";
            this.colLineStart.Name = "colLineStart";
            this.colLineStart.ReadOnly = true;
            //
            // colLineEnd
            //
            this.colLineEnd.HeaderText = "끝";
            this.colLineEnd.Name = "colLineEnd";
            this.colLineEnd.ReadOnly = true;
            //
            // FrmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.ShapeControl";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpHeatmap.ResumeLayout(false);
            this.grpHeatmap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeatmapZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeatmapY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeatmapX)).EndInit();
            this.grpRun.ResumeLayout(false);
            this.grpSetup.ResumeLayout(false);
            this.grpSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRotDegree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSegmentCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStrokeThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP3Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP3Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP3X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1X)).EndInit();
            this.grpModel.ResumeLayout(false);
            this.grpCleanup.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            this.grpList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAxisZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAxisY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAxisX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectionRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShapes)).EndInit();
            this.grpSegments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineSegments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Label lblModelHint;
        private System.Windows.Forms.GroupBox grpSetup;
        private System.Windows.Forms.Label lblShapeType;
        private System.Windows.Forms.ComboBox cmbShapeType;
        private System.Windows.Forms.Label lblCreateMode;
        private System.Windows.Forms.ComboBox cmbCreateMode;
        private System.Windows.Forms.Label lblPoint1;
        private System.Windows.Forms.NumericUpDown numP1X;
        private System.Windows.Forms.NumericUpDown numP1Y;
        private System.Windows.Forms.NumericUpDown numP1Z;
        private System.Windows.Forms.Button btnPoint1Osnap;
        private System.Windows.Forms.Label lblPoint2;
        private System.Windows.Forms.NumericUpDown numP2X;
        private System.Windows.Forms.NumericUpDown numP2Y;
        private System.Windows.Forms.NumericUpDown numP2Z;
        private System.Windows.Forms.Button btnPoint2Osnap;
        private System.Windows.Forms.Label lblPoint3;
        private System.Windows.Forms.NumericUpDown numP3X;
        private System.Windows.Forms.NumericUpDown numP3Y;
        private System.Windows.Forms.NumericUpDown numP3Z;
        private System.Windows.Forms.Button btnPoint3Osnap;
        private System.Windows.Forms.Label lblValue1;
        private System.Windows.Forms.NumericUpDown numValue1;
        private System.Windows.Forms.Label lblValue2;
        private System.Windows.Forms.NumericUpDown numValue2;
        private System.Windows.Forms.Label lblValue3;
        private System.Windows.Forms.NumericUpDown numValue3;
        private System.Windows.Forms.Label lblCreateCategory;
        private System.Windows.Forms.TextBox txtCreateCategory;
        private System.Windows.Forms.Label lblStrokeThickness;
        private System.Windows.Forms.NumericUpDown numStrokeThickness;
        private System.Windows.Forms.Label lblStrokePattern;
        private System.Windows.Forms.ComboBox cmbStrokePattern;
        private System.Windows.Forms.Label lblSegmentCount;
        private System.Windows.Forms.NumericUpDown numSegmentCount;
        private System.Windows.Forms.Label lblAxisAnchor;
        private System.Windows.Forms.ComboBox cmbAxisAnchor;
        private System.Windows.Forms.Button btnCreateColor;
        private System.Windows.Forms.Label lblRotation;
        private System.Windows.Forms.NumericUpDown numRotX;
        private System.Windows.Forms.NumericUpDown numRotY;
        private System.Windows.Forms.NumericUpDown numRotZ;
        private System.Windows.Forms.Label lblRotDegree;
        private System.Windows.Forms.NumericUpDown numRotDegree;
        private System.Windows.Forms.Label lblCreateHint;
        private System.Windows.Forms.GroupBox grpRun;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox grpHeatmap;
        private System.Windows.Forms.Label lblHeatmapSource;
        private System.Windows.Forms.ComboBox cmbHeatmapSource;
        private System.Windows.Forms.Label lblHeatmapPoint;
        private System.Windows.Forms.NumericUpDown numHeatmapX;
        private System.Windows.Forms.NumericUpDown numHeatmapY;
        private System.Windows.Forms.NumericUpDown numHeatmapZ;
        private System.Windows.Forms.Button btnHeatmapPointOsnap;
        private System.Windows.Forms.Label lblHeatmapCategory;
        private System.Windows.Forms.TextBox txtHeatmapCategory;
        private System.Windows.Forms.Button btnHeatmapCreate;
        private System.Windows.Forms.Button btnHeatmapClear;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.Label lblManageTarget;
        private System.Windows.Forms.ComboBox cmbManageTarget;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvShapes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.Label lblManageCategory;
        private System.Windows.Forms.TextBox txtManageCategory;
        private System.Windows.Forms.Button btnCategoryFind;
        private System.Windows.Forms.Button btnCategoryApply;
        private System.Windows.Forms.Button btnCategoryClear;
        private System.Windows.Forms.Button btnCategoryDelete;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.CheckBox chkSelectable;
        private System.Windows.Forms.CheckBox chkHighlightable;
        private System.Windows.Forms.CheckBox chkDepthTest;
        private System.Windows.Forms.Label lblSelectionRadius;
        private System.Windows.Forms.NumericUpDown numSelectionRadius;
        private System.Windows.Forms.Label lblHighlightColor;
        private System.Windows.Forms.Button btnHighlightColor;
        private System.Windows.Forms.Label lblSelectedColor;
        private System.Windows.Forms.Button btnSelectedColor;
        private System.Windows.Forms.Label lblMove;
        private System.Windows.Forms.NumericUpDown numMoveX;
        private System.Windows.Forms.NumericUpDown numMoveY;
        private System.Windows.Forms.NumericUpDown numMoveZ;
        private System.Windows.Forms.Button btnMoveOsnap;
        private System.Windows.Forms.Label lblAxis;
        private System.Windows.Forms.NumericUpDown numAxisX;
        private System.Windows.Forms.NumericUpDown numAxisY;
        private System.Windows.Forms.NumericUpDown numAxisZ;
        private System.Windows.Forms.Label lblAngle;
        private System.Windows.Forms.NumericUpDown numAngle;
        private System.Windows.Forms.Button btnRotateSelected;
        private System.Windows.Forms.Button btnDirectionSelected;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.GroupBox grpSegments;
        private System.Windows.Forms.DataGridView dgvLineSegments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineEnd;
        private System.Windows.Forms.Button btnLineSegmentAdd;
        private System.Windows.Forms.Button btnLineSegmentRemove;
        private System.Windows.Forms.Button btnLineSegmentClear;
    }
}
