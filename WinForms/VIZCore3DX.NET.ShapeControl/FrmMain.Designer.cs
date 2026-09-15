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
            this.pnlViewHost = new System.Windows.Forms.Panel();
            this.pnlOption = new System.Windows.Forms.Panel();
            this.grpCreate = new System.Windows.Forms.GroupBox();
            this.lblShapeType = new System.Windows.Forms.Label();
            this.cmbShapeType = new System.Windows.Forms.ComboBox();
            this.lblCreateMode = new System.Windows.Forms.Label();
            this.cmbCreateMode = new System.Windows.Forms.ComboBox();
            this.btnCreateColor = new System.Windows.Forms.Button();
            this.pnlPoint1 = new System.Windows.Forms.Panel();
            this.lblPoint1Title = new System.Windows.Forms.Label();
            this.lblP1X = new System.Windows.Forms.Label();
            this.numP1X = new System.Windows.Forms.NumericUpDown();
            this.lblP1Y = new System.Windows.Forms.Label();
            this.numP1Y = new System.Windows.Forms.NumericUpDown();
            this.lblP1Z = new System.Windows.Forms.Label();
            this.numP1Z = new System.Windows.Forms.NumericUpDown();
            this.btnPoint1Osnap = new System.Windows.Forms.Button();
            this.pnlPoint2 = new System.Windows.Forms.Panel();
            this.lblPoint2Title = new System.Windows.Forms.Label();
            this.lblP2X = new System.Windows.Forms.Label();
            this.numP2X = new System.Windows.Forms.NumericUpDown();
            this.lblP2Y = new System.Windows.Forms.Label();
            this.numP2Y = new System.Windows.Forms.NumericUpDown();
            this.lblP2Z = new System.Windows.Forms.Label();
            this.numP2Z = new System.Windows.Forms.NumericUpDown();
            this.btnPoint2Osnap = new System.Windows.Forms.Button();
            this.pnlPoint3 = new System.Windows.Forms.Panel();
            this.lblPoint3Title = new System.Windows.Forms.Label();
            this.lblP3X = new System.Windows.Forms.Label();
            this.numP3X = new System.Windows.Forms.NumericUpDown();
            this.lblP3Y = new System.Windows.Forms.Label();
            this.numP3Y = new System.Windows.Forms.NumericUpDown();
            this.lblP3Z = new System.Windows.Forms.Label();
            this.numP3Z = new System.Windows.Forms.NumericUpDown();
            this.btnPoint3Osnap = new System.Windows.Forms.Button();
            this.pnlLineSegments = new System.Windows.Forms.Panel();
            this.dgvLineSegments = new System.Windows.Forms.DataGridView();
            this.colLineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLineSegmentAdd = new System.Windows.Forms.Button();
            this.btnLineSegmentRemove = new System.Windows.Forms.Button();
            this.btnLineSegmentClear = new System.Windows.Forms.Button();
            this.pnlValues = new System.Windows.Forms.Panel();
            this.lblValue1 = new System.Windows.Forms.Label();
            this.numValue1 = new System.Windows.Forms.NumericUpDown();
            this.lblValue2 = new System.Windows.Forms.Label();
            this.numValue2 = new System.Windows.Forms.NumericUpDown();
            this.lblValue3 = new System.Windows.Forms.Label();
            this.numValue3 = new System.Windows.Forms.NumericUpDown();
            this.pnlStroke = new System.Windows.Forms.Panel();
            this.lblStrokeThickness = new System.Windows.Forms.Label();
            this.numStrokeThickness = new System.Windows.Forms.NumericUpDown();
            this.lblStrokePattern = new System.Windows.Forms.Label();
            this.cmbStrokePattern = new System.Windows.Forms.ComboBox();
            this.lblSegmentCount = new System.Windows.Forms.Label();
            this.numSegmentCount = new System.Windows.Forms.NumericUpDown();
            this.lblAxisAnchor = new System.Windows.Forms.Label();
            this.cmbAxisAnchor = new System.Windows.Forms.ComboBox();
            this.pnlRotation = new System.Windows.Forms.Panel();
            this.lblRotation = new System.Windows.Forms.Label();
            this.lblRotX = new System.Windows.Forms.Label();
            this.numRotX = new System.Windows.Forms.NumericUpDown();
            this.lblRotY = new System.Windows.Forms.Label();
            this.numRotY = new System.Windows.Forms.NumericUpDown();
            this.lblRotZ = new System.Windows.Forms.Label();
            this.numRotZ = new System.Windows.Forms.NumericUpDown();
            this.lblRotDegree = new System.Windows.Forms.Label();
            this.numRotDegree = new System.Windows.Forms.NumericUpDown();
            this.lblCreateCategory = new System.Windows.Forms.Label();
            this.txtCreateCategory = new System.Windows.Forms.TextBox();
            this.lblModeInfo = new System.Windows.Forms.Label();
            this.lblCreateHint = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.grpShapeList = new System.Windows.Forms.GroupBox();
            this.lblShapeListInfo = new System.Windows.Forms.Label();
            this.lblSelectedShapeInfo = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvShapes = new System.Windows.Forms.DataGridView();
            this.colShapeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShapeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShapeCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMoveX = new System.Windows.Forms.Label();
            this.numMoveX = new System.Windows.Forms.NumericUpDown();
            this.lblMoveY = new System.Windows.Forms.Label();
            this.numMoveY = new System.Windows.Forms.NumericUpDown();
            this.lblMoveZ = new System.Windows.Forms.Label();
            this.numMoveZ = new System.Windows.Forms.NumericUpDown();
            this.btnMoveOsnap = new System.Windows.Forms.Button();
            this.lblTransformVector = new System.Windows.Forms.Label();
            this.numTransformX = new System.Windows.Forms.NumericUpDown();
            this.numTransformY = new System.Windows.Forms.NumericUpDown();
            this.numTransformZ = new System.Windows.Forms.NumericUpDown();
            this.lblTransformDegree = new System.Windows.Forms.Label();
            this.numTransformDegree = new System.Windows.Forms.NumericUpDown();
            this.btnRotateSelected = new System.Windows.Forms.Button();
            this.btnDirectionSelected = new System.Windows.Forms.Button();
            this.lblManageTarget = new System.Windows.Forms.Label();
            this.cmbManageTarget = new System.Windows.Forms.ComboBox();
            this.lblManageCategory = new System.Windows.Forms.Label();
            this.txtManageCategory = new System.Windows.Forms.TextBox();
            this.btnCategoryCount = new System.Windows.Forms.Button();
            this.btnCategoryApply = new System.Windows.Forms.Button();
            this.btnCategoryClear = new System.Windows.Forms.Button();
            this.btnSelectedDelete = new System.Windows.Forms.Button();
            this.btnCategoryDelete = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.lblCategoryCount = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.chkSelectable = new System.Windows.Forms.CheckBox();
            this.chkHighlightable = new System.Windows.Forms.CheckBox();
            this.chkDepthTest = new System.Windows.Forms.CheckBox();
            this.lblSelectionRadius = new System.Windows.Forms.Label();
            this.numSelectionRadius = new System.Windows.Forms.NumericUpDown();
            this.lblHighlightColor = new System.Windows.Forms.Label();
            this.btnHighlightColor = new System.Windows.Forms.Button();
            this.lblSelectedColor = new System.Windows.Forms.Label();
            this.btnSelectedColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlOption.SuspendLayout();
            this.grpCreate.SuspendLayout();
            this.pnlPoint1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numP1X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1Z)).BeginInit();
            this.pnlPoint2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numP2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2Z)).BeginInit();
            this.pnlPoint3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numP3X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP3Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP3Z)).BeginInit();
            this.pnlLineSegments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineSegments)).BeginInit();
            this.pnlValues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue3)).BeginInit();
            this.pnlStroke.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStrokeThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSegmentCount)).BeginInit();
            this.pnlRotation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRotX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotDegree)).BeginInit();
            this.grpShapeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShapes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransformX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransformY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransformZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransformDegree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectionRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlViewHost
            // 
            this.pnlViewHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewHost.Location = new System.Drawing.Point(0, 0);
            this.pnlViewHost.Name = "pnlViewHost";
            this.pnlViewHost.Size = new System.Drawing.Size(870, 760);
            this.pnlViewHost.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlViewHost);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlOption);
            this.splitContainer1.Size = new System.Drawing.Size(1360, 760);
            this.splitContainer1.SplitterDistance = 870;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnlOption
            // 
            this.pnlOption.Controls.Add(this.grpCreate);
            this.pnlOption.Controls.Add(this.grpShapeList);
            this.pnlOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOption.Location = new System.Drawing.Point(0, 0);
            this.pnlOption.Name = "pnlOption";
            this.pnlOption.Padding = new System.Windows.Forms.Padding(7);
            this.pnlOption.Size = new System.Drawing.Size(486, 760);
            this.pnlOption.TabIndex = 0;
            // 
            // grpCreate
            // 
            this.grpCreate.Controls.Add(this.lblShapeType);
            this.grpCreate.Controls.Add(this.cmbShapeType);
            this.grpCreate.Controls.Add(this.lblCreateMode);
            this.grpCreate.Controls.Add(this.cmbCreateMode);
            this.grpCreate.Controls.Add(this.btnCreateColor);
            this.grpCreate.Controls.Add(this.pnlPoint1);
            this.grpCreate.Controls.Add(this.pnlPoint2);
            this.grpCreate.Controls.Add(this.pnlPoint3);
            this.grpCreate.Controls.Add(this.pnlLineSegments);
            this.grpCreate.Controls.Add(this.pnlValues);
            this.grpCreate.Controls.Add(this.pnlStroke);
            this.grpCreate.Controls.Add(this.pnlRotation);
            this.grpCreate.Controls.Add(this.lblCreateCategory);
            this.grpCreate.Controls.Add(this.txtCreateCategory);
            this.grpCreate.Controls.Add(this.lblModeInfo);
            this.grpCreate.Controls.Add(this.lblCreateHint);
            this.grpCreate.Controls.Add(this.btnCreate);
            this.grpCreate.Location = new System.Drawing.Point(7, 7);
            this.grpCreate.Name = "grpCreate";
            this.grpCreate.Size = new System.Drawing.Size(472, 324);
            this.grpCreate.TabIndex = 0;
            this.grpCreate.TabStop = false;
            this.grpCreate.Text = "1. 형상 생성";
            // 
            // lblShapeType
            // 
            this.lblShapeType.AutoSize = true;
            this.lblShapeType.Location = new System.Drawing.Point(13, 27);
            this.lblShapeType.Name = "lblShapeType";
            this.lblShapeType.Size = new System.Drawing.Size(29, 12);
            this.lblShapeType.TabIndex = 0;
            this.lblShapeType.Text = "형상";
            // 
            // cmbShapeType
            // 
            this.cmbShapeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShapeType.FormattingEnabled = true;
            this.cmbShapeType.Items.AddRange(new object[] {
            "점",
            "선분",
            "선분 집합",
            "폴리라인",
            "원",
            "사각형",
            "삼각형",
            "메시",
            "박스",
            "원통",
            "구",
            "평면",
            "화살표",
            "좌표축",
            "바운딩 박스"});
            this.cmbShapeType.Location = new System.Drawing.Point(50, 23);
            this.cmbShapeType.Name = "cmbShapeType";
            this.cmbShapeType.Size = new System.Drawing.Size(126, 20);
            this.cmbShapeType.TabIndex = 1;
            this.cmbShapeType.SelectedIndex = 0;
            this.cmbShapeType.SelectedIndexChanged += new System.EventHandler(this.cmbShapeType_SelectedIndexChanged);
            // 
            // lblCreateMode
            // 
            this.lblCreateMode.AutoSize = true;
            this.lblCreateMode.Location = new System.Drawing.Point(190, 27);
            this.lblCreateMode.Name = "lblCreateMode";
            this.lblCreateMode.Size = new System.Drawing.Size(29, 12);
            this.lblCreateMode.TabIndex = 2;
            this.lblCreateMode.Text = "방식";
            // 
            // cmbCreateMode
            // 
            this.cmbCreateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCreateMode.FormattingEnabled = true;
            this.cmbCreateMode.Items.AddRange(new object[] {
            "기본",
            "위치·회전",
            "방향 벡터",
            "선택 객체 기준"});
            this.cmbCreateMode.Location = new System.Drawing.Point(228, 23);
            this.cmbCreateMode.Name = "cmbCreateMode";
            this.cmbCreateMode.Size = new System.Drawing.Size(126, 20);
            this.cmbCreateMode.TabIndex = 3;
            this.cmbCreateMode.SelectedIndex = 0;
            this.cmbCreateMode.SelectedIndexChanged += new System.EventHandler(this.cmbCreateMode_SelectedIndexChanged);
            // 
            // btnCreateColor
            // 
            this.btnCreateColor.BackColor = System.Drawing.Color.Orange;
            this.btnCreateColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateColor.Location = new System.Drawing.Point(366, 21);
            this.btnCreateColor.Name = "btnCreateColor";
            this.btnCreateColor.Size = new System.Drawing.Size(90, 24);
            this.btnCreateColor.TabIndex = 4;
            this.btnCreateColor.Text = "색상";
            this.btnCreateColor.UseVisualStyleBackColor = false;
            this.btnCreateColor.Click += new System.EventHandler(this.btnCreateColor_Click);
            // 
            // pnlPoint1
            // 
            this.pnlPoint1.Controls.Add(this.lblPoint1Title);
            this.pnlPoint1.Controls.Add(this.lblP1X);
            this.pnlPoint1.Controls.Add(this.numP1X);
            this.pnlPoint1.Controls.Add(this.lblP1Y);
            this.pnlPoint1.Controls.Add(this.numP1Y);
            this.pnlPoint1.Controls.Add(this.lblP1Z);
            this.pnlPoint1.Controls.Add(this.numP1Z);
            this.pnlPoint1.Controls.Add(this.btnPoint1Osnap);
            this.pnlPoint1.Location = new System.Drawing.Point(10, 52);
            this.pnlPoint1.Name = "pnlPoint1";
            this.pnlPoint1.Size = new System.Drawing.Size(446, 30);
            this.pnlPoint1.TabIndex = 5;
            // 
            // lblPoint1Title
            // 
            this.lblPoint1Title.Location = new System.Drawing.Point(3, 8);
            this.lblPoint1Title.Name = "lblPoint1Title";
            this.lblPoint1Title.Size = new System.Drawing.Size(55, 12);
            this.lblPoint1Title.TabIndex = 0;
            this.lblPoint1Title.Text = "기준점";
            // 
            // lblP1X
            // 
            this.lblP1X.AutoSize = true;
            this.lblP1X.Location = new System.Drawing.Point(62, 8);
            this.lblP1X.Name = "lblP1X";
            this.lblP1X.Size = new System.Drawing.Size(13, 12);
            this.lblP1X.TabIndex = 1;
            this.lblP1X.Text = "X";
            // 
            // numP1X
            // 
            this.numP1X.DecimalPlaces = 3;
            this.numP1X.Location = new System.Drawing.Point(78, 4);
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
            this.numP1X.Size = new System.Drawing.Size(78, 21);
            this.numP1X.TabIndex = 2;
            // 
            // lblP1Y
            // 
            this.lblP1Y.AutoSize = true;
            this.lblP1Y.Location = new System.Drawing.Point(162, 8);
            this.lblP1Y.Name = "lblP1Y";
            this.lblP1Y.Size = new System.Drawing.Size(13, 12);
            this.lblP1Y.TabIndex = 3;
            this.lblP1Y.Text = "Y";
            // 
            // numP1Y
            // 
            this.numP1Y.DecimalPlaces = 3;
            this.numP1Y.Location = new System.Drawing.Point(178, 4);
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
            this.numP1Y.Size = new System.Drawing.Size(78, 21);
            this.numP1Y.TabIndex = 4;
            // 
            // lblP1Z
            // 
            this.lblP1Z.AutoSize = true;
            this.lblP1Z.Location = new System.Drawing.Point(262, 8);
            this.lblP1Z.Name = "lblP1Z";
            this.lblP1Z.Size = new System.Drawing.Size(13, 12);
            this.lblP1Z.TabIndex = 5;
            this.lblP1Z.Text = "Z";
            // 
            // numP1Z
            // 
            this.numP1Z.DecimalPlaces = 3;
            this.numP1Z.Location = new System.Drawing.Point(278, 4);
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
            this.numP1Z.Size = new System.Drawing.Size(78, 21);
            this.numP1Z.TabIndex = 6;
            // 
            // btnPoint1Osnap
            // 
            this.btnPoint1Osnap.Location = new System.Drawing.Point(366, 3);
            this.btnPoint1Osnap.Name = "btnPoint1Osnap";
            this.btnPoint1Osnap.Size = new System.Drawing.Size(76, 23);
            this.btnPoint1Osnap.TabIndex = 7;
            this.btnPoint1Osnap.Text = "Osnap";
            this.btnPoint1Osnap.UseVisualStyleBackColor = true;
            this.btnPoint1Osnap.Click += new System.EventHandler(this.btnPoint1Osnap_Click);
            // 
            // pnlPoint2
            // 
            this.pnlPoint2.Controls.Add(this.lblPoint2Title);
            this.pnlPoint2.Controls.Add(this.lblP2X);
            this.pnlPoint2.Controls.Add(this.numP2X);
            this.pnlPoint2.Controls.Add(this.lblP2Y);
            this.pnlPoint2.Controls.Add(this.numP2Y);
            this.pnlPoint2.Controls.Add(this.lblP2Z);
            this.pnlPoint2.Controls.Add(this.numP2Z);
            this.pnlPoint2.Controls.Add(this.btnPoint2Osnap);
            this.pnlPoint2.Location = new System.Drawing.Point(10, 83);
            this.pnlPoint2.Name = "pnlPoint2";
            this.pnlPoint2.Size = new System.Drawing.Size(446, 30);
            this.pnlPoint2.TabIndex = 6;
            // 
            // lblPoint2Title
            // 
            this.lblPoint2Title.Location = new System.Drawing.Point(3, 8);
            this.lblPoint2Title.Name = "lblPoint2Title";
            this.lblPoint2Title.Size = new System.Drawing.Size(55, 12);
            this.lblPoint2Title.TabIndex = 0;
            this.lblPoint2Title.Text = "보조점";
            // 
            // lblP2X
            // 
            this.lblP2X.AutoSize = true;
            this.lblP2X.Location = new System.Drawing.Point(62, 8);
            this.lblP2X.Name = "lblP2X";
            this.lblP2X.Size = new System.Drawing.Size(13, 12);
            this.lblP2X.TabIndex = 1;
            this.lblP2X.Text = "X";
            // 
            // numP2X
            // 
            this.numP2X.DecimalPlaces = 3;
            this.numP2X.Location = new System.Drawing.Point(78, 4);
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
            this.numP2X.Size = new System.Drawing.Size(78, 21);
            this.numP2X.TabIndex = 2;
            this.numP2X.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblP2Y
            // 
            this.lblP2Y.AutoSize = true;
            this.lblP2Y.Location = new System.Drawing.Point(162, 8);
            this.lblP2Y.Name = "lblP2Y";
            this.lblP2Y.Size = new System.Drawing.Size(13, 12);
            this.lblP2Y.TabIndex = 3;
            this.lblP2Y.Text = "Y";
            // 
            // numP2Y
            // 
            this.numP2Y.DecimalPlaces = 3;
            this.numP2Y.Location = new System.Drawing.Point(178, 4);
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
            this.numP2Y.Size = new System.Drawing.Size(78, 21);
            this.numP2Y.TabIndex = 4;
            // 
            // lblP2Z
            // 
            this.lblP2Z.AutoSize = true;
            this.lblP2Z.Location = new System.Drawing.Point(262, 8);
            this.lblP2Z.Name = "lblP2Z";
            this.lblP2Z.Size = new System.Drawing.Size(13, 12);
            this.lblP2Z.TabIndex = 5;
            this.lblP2Z.Text = "Z";
            // 
            // numP2Z
            // 
            this.numP2Z.DecimalPlaces = 3;
            this.numP2Z.Location = new System.Drawing.Point(278, 4);
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
            this.numP2Z.Size = new System.Drawing.Size(78, 21);
            this.numP2Z.TabIndex = 6;
            // 
            // btnPoint2Osnap
            // 
            this.btnPoint2Osnap.Location = new System.Drawing.Point(366, 3);
            this.btnPoint2Osnap.Name = "btnPoint2Osnap";
            this.btnPoint2Osnap.Size = new System.Drawing.Size(76, 23);
            this.btnPoint2Osnap.TabIndex = 7;
            this.btnPoint2Osnap.Text = "Osnap";
            this.btnPoint2Osnap.UseVisualStyleBackColor = true;
            this.btnPoint2Osnap.Click += new System.EventHandler(this.btnPoint2Osnap_Click);
            // 
            // pnlPoint3
            // 
            this.pnlPoint3.Controls.Add(this.lblPoint3Title);
            this.pnlPoint3.Controls.Add(this.lblP3X);
            this.pnlPoint3.Controls.Add(this.numP3X);
            this.pnlPoint3.Controls.Add(this.lblP3Y);
            this.pnlPoint3.Controls.Add(this.numP3Y);
            this.pnlPoint3.Controls.Add(this.lblP3Z);
            this.pnlPoint3.Controls.Add(this.numP3Z);
            this.pnlPoint3.Controls.Add(this.btnPoint3Osnap);
            this.pnlPoint3.Location = new System.Drawing.Point(10, 114);
            this.pnlPoint3.Name = "pnlPoint3";
            this.pnlPoint3.Size = new System.Drawing.Size(446, 30);
            this.pnlPoint3.TabIndex = 7;
            // 
            // lblPoint3Title
            // 
            this.lblPoint3Title.Location = new System.Drawing.Point(3, 8);
            this.lblPoint3Title.Name = "lblPoint3Title";
            this.lblPoint3Title.Size = new System.Drawing.Size(55, 12);
            this.lblPoint3Title.TabIndex = 0;
            this.lblPoint3Title.Text = "점 3";
            // 
            // lblP3X
            // 
            this.lblP3X.AutoSize = true;
            this.lblP3X.Location = new System.Drawing.Point(62, 8);
            this.lblP3X.Name = "lblP3X";
            this.lblP3X.Size = new System.Drawing.Size(13, 12);
            this.lblP3X.TabIndex = 1;
            this.lblP3X.Text = "X";
            // 
            // numP3X
            // 
            this.numP3X.DecimalPlaces = 3;
            this.numP3X.Location = new System.Drawing.Point(78, 4);
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
            this.numP3X.Size = new System.Drawing.Size(78, 21);
            this.numP3X.TabIndex = 2;
            // 
            // lblP3Y
            // 
            this.lblP3Y.AutoSize = true;
            this.lblP3Y.Location = new System.Drawing.Point(162, 8);
            this.lblP3Y.Name = "lblP3Y";
            this.lblP3Y.Size = new System.Drawing.Size(13, 12);
            this.lblP3Y.TabIndex = 3;
            this.lblP3Y.Text = "Y";
            // 
            // numP3Y
            // 
            this.numP3Y.DecimalPlaces = 3;
            this.numP3Y.Location = new System.Drawing.Point(178, 4);
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
            this.numP3Y.Size = new System.Drawing.Size(78, 21);
            this.numP3Y.TabIndex = 4;
            // 
            // lblP3Z
            // 
            this.lblP3Z.AutoSize = true;
            this.lblP3Z.Location = new System.Drawing.Point(262, 8);
            this.lblP3Z.Name = "lblP3Z";
            this.lblP3Z.Size = new System.Drawing.Size(13, 12);
            this.lblP3Z.TabIndex = 5;
            this.lblP3Z.Text = "Z";
            // 
            // numP3Z
            // 
            this.numP3Z.DecimalPlaces = 3;
            this.numP3Z.Location = new System.Drawing.Point(278, 4);
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
            this.numP3Z.Size = new System.Drawing.Size(78, 21);
            this.numP3Z.TabIndex = 6;
            // 
            // btnPoint3Osnap
            // 
            this.btnPoint3Osnap.Location = new System.Drawing.Point(366, 3);
            this.btnPoint3Osnap.Name = "btnPoint3Osnap";
            this.btnPoint3Osnap.Size = new System.Drawing.Size(76, 23);
            this.btnPoint3Osnap.TabIndex = 7;
            this.btnPoint3Osnap.Text = "Osnap";
            this.btnPoint3Osnap.UseVisualStyleBackColor = true;
            this.btnPoint3Osnap.Click += new System.EventHandler(this.btnPoint3Osnap_Click);
            // 
            // pnlLineSegments
            // 
            this.pnlLineSegments.Controls.Add(this.dgvLineSegments);
            this.pnlLineSegments.Controls.Add(this.btnLineSegmentAdd);
            this.pnlLineSegments.Controls.Add(this.btnLineSegmentRemove);
            this.pnlLineSegments.Controls.Add(this.btnLineSegmentClear);
            this.pnlLineSegments.Location = new System.Drawing.Point(10, 114);
            this.pnlLineSegments.Name = "pnlLineSegments";
            this.pnlLineSegments.Size = new System.Drawing.Size(446, 62);
            this.pnlLineSegments.TabIndex = 8;
            this.pnlLineSegments.Visible = false;
            // 
            // dgvLineSegments
            // 
            this.dgvLineSegments.AllowUserToAddRows = false;
            this.dgvLineSegments.AllowUserToDeleteRows = false;
            this.dgvLineSegments.AllowUserToResizeRows = false;
            this.dgvLineSegments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineSegments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLineNo,
            this.colLineStart,
            this.colLineEnd});
            this.dgvLineSegments.Location = new System.Drawing.Point(0, 0);
            this.dgvLineSegments.MultiSelect = false;
            this.dgvLineSegments.Name = "dgvLineSegments";
            this.dgvLineSegments.ReadOnly = true;
            this.dgvLineSegments.RowHeadersVisible = false;
            this.dgvLineSegments.RowTemplate.Height = 20;
            this.dgvLineSegments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLineSegments.Size = new System.Drawing.Size(340, 62);
            this.dgvLineSegments.TabIndex = 0;
            // 
            // colLineNo
            // 
            this.colLineNo.HeaderText = "No";
            this.colLineNo.Name = "colLineNo";
            this.colLineNo.ReadOnly = true;
            this.colLineNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colLineNo.Width = 38;
            // 
            // colLineStart
            // 
            this.colLineStart.HeaderText = "시작점";
            this.colLineStart.Name = "colLineStart";
            this.colLineStart.ReadOnly = true;
            this.colLineStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colLineStart.Width = 148;
            // 
            // colLineEnd
            // 
            this.colLineEnd.HeaderText = "끝점";
            this.colLineEnd.Name = "colLineEnd";
            this.colLineEnd.ReadOnly = true;
            this.colLineEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colLineEnd.Width = 148;
            // 
            // btnLineSegmentAdd
            // 
            this.btnLineSegmentAdd.Location = new System.Drawing.Point(346, 0);
            this.btnLineSegmentAdd.Name = "btnLineSegmentAdd";
            this.btnLineSegmentAdd.Size = new System.Drawing.Size(96, 19);
            this.btnLineSegmentAdd.TabIndex = 1;
            this.btnLineSegmentAdd.Text = "선분 추가";
            this.btnLineSegmentAdd.UseVisualStyleBackColor = true;
            this.btnLineSegmentAdd.Click += new System.EventHandler(this.btnLineSegmentAdd_Click);
            // 
            // btnLineSegmentRemove
            // 
            this.btnLineSegmentRemove.Location = new System.Drawing.Point(346, 21);
            this.btnLineSegmentRemove.Name = "btnLineSegmentRemove";
            this.btnLineSegmentRemove.Size = new System.Drawing.Size(96, 19);
            this.btnLineSegmentRemove.TabIndex = 2;
            this.btnLineSegmentRemove.Text = "선택 제거";
            this.btnLineSegmentRemove.UseVisualStyleBackColor = true;
            this.btnLineSegmentRemove.Click += new System.EventHandler(this.btnLineSegmentRemove_Click);
            // 
            // btnLineSegmentClear
            // 
            this.btnLineSegmentClear.Location = new System.Drawing.Point(346, 42);
            this.btnLineSegmentClear.Name = "btnLineSegmentClear";
            this.btnLineSegmentClear.Size = new System.Drawing.Size(96, 19);
            this.btnLineSegmentClear.TabIndex = 3;
            this.btnLineSegmentClear.Text = "전체 지우기";
            this.btnLineSegmentClear.UseVisualStyleBackColor = true;
            this.btnLineSegmentClear.Click += new System.EventHandler(this.btnLineSegmentClear_Click);
            // 
            // pnlValues
            // 
            this.pnlValues.Controls.Add(this.lblValue1);
            this.pnlValues.Controls.Add(this.numValue1);
            this.pnlValues.Controls.Add(this.lblValue2);
            this.pnlValues.Controls.Add(this.numValue2);
            this.pnlValues.Controls.Add(this.lblValue3);
            this.pnlValues.Controls.Add(this.numValue3);
            this.pnlValues.Location = new System.Drawing.Point(10, 145);
            this.pnlValues.Name = "pnlValues";
            this.pnlValues.Size = new System.Drawing.Size(446, 31);
            this.pnlValues.TabIndex = 8;
            // 
            // lblValue1
            // 
            this.lblValue1.Location = new System.Drawing.Point(3, 8);
            this.lblValue1.Name = "lblValue1";
            this.lblValue1.Size = new System.Drawing.Size(52, 12);
            this.lblValue1.TabIndex = 0;
            this.lblValue1.Text = "값 1";
            // 
            // numValue1
            // 
            this.numValue1.DecimalPlaces = 2;
            this.numValue1.Location = new System.Drawing.Point(58, 4);
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
            this.numValue1.Size = new System.Drawing.Size(82, 21);
            this.numValue1.TabIndex = 1;
            // 
            // lblValue2
            // 
            this.lblValue2.Location = new System.Drawing.Point(150, 8);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(52, 12);
            this.lblValue2.TabIndex = 2;
            this.lblValue2.Text = "값 2";
            // 
            // numValue2
            // 
            this.numValue2.DecimalPlaces = 2;
            this.numValue2.Location = new System.Drawing.Point(205, 4);
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
            this.numValue2.Size = new System.Drawing.Size(82, 21);
            this.numValue2.TabIndex = 3;
            // 
            // lblValue3
            // 
            this.lblValue3.Location = new System.Drawing.Point(297, 8);
            this.lblValue3.Name = "lblValue3";
            this.lblValue3.Size = new System.Drawing.Size(52, 12);
            this.lblValue3.TabIndex = 4;
            this.lblValue3.Text = "값 3";
            // 
            // numValue3
            // 
            this.numValue3.DecimalPlaces = 2;
            this.numValue3.Location = new System.Drawing.Point(352, 4);
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
            this.numValue3.TabIndex = 5;
            // 
            // pnlStroke
            // 
            this.pnlStroke.Controls.Add(this.lblStrokeThickness);
            this.pnlStroke.Controls.Add(this.numStrokeThickness);
            this.pnlStroke.Controls.Add(this.lblStrokePattern);
            this.pnlStroke.Controls.Add(this.cmbStrokePattern);
            this.pnlStroke.Controls.Add(this.lblSegmentCount);
            this.pnlStroke.Controls.Add(this.numSegmentCount);
            this.pnlStroke.Controls.Add(this.lblAxisAnchor);
            this.pnlStroke.Controls.Add(this.cmbAxisAnchor);
            this.pnlStroke.Location = new System.Drawing.Point(10, 177);
            this.pnlStroke.Name = "pnlStroke";
            this.pnlStroke.Size = new System.Drawing.Size(446, 31);
            this.pnlStroke.TabIndex = 9;
            // 
            // lblStrokeThickness
            // 
            this.lblStrokeThickness.AutoSize = true;
            this.lblStrokeThickness.Location = new System.Drawing.Point(3, 8);
            this.lblStrokeThickness.Name = "lblStrokeThickness";
            this.lblStrokeThickness.Size = new System.Drawing.Size(45, 12);
            this.lblStrokeThickness.TabIndex = 0;
            this.lblStrokeThickness.Text = "선 두께";
            // 
            // numStrokeThickness
            // 
            this.numStrokeThickness.DecimalPlaces = 1;
            this.numStrokeThickness.Location = new System.Drawing.Point(54, 4);
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
            this.numStrokeThickness.Size = new System.Drawing.Size(48, 21);
            this.numStrokeThickness.TabIndex = 1;
            this.numStrokeThickness.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblStrokePattern
            // 
            this.lblStrokePattern.AutoSize = true;
            this.lblStrokePattern.Location = new System.Drawing.Point(111, 8);
            this.lblStrokePattern.Name = "lblStrokePattern";
            this.lblStrokePattern.Size = new System.Drawing.Size(29, 12);
            this.lblStrokePattern.TabIndex = 2;
            this.lblStrokePattern.Text = "패턴";
            // 
            // cmbStrokePattern
            // 
            this.cmbStrokePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStrokePattern.FormattingEnabled = true;
            this.cmbStrokePattern.Items.AddRange(new object[] {
            "Solid",
            "Dashed",
            "Dotted"});
            this.cmbStrokePattern.Location = new System.Drawing.Point(145, 4);
            this.cmbStrokePattern.Name = "cmbStrokePattern";
            this.cmbStrokePattern.Size = new System.Drawing.Size(72, 20);
            this.cmbStrokePattern.TabIndex = 3;
            this.cmbStrokePattern.SelectedIndex = 0;
            // 
            // lblSegmentCount
            // 
            this.lblSegmentCount.AutoSize = true;
            this.lblSegmentCount.Location = new System.Drawing.Point(226, 8);
            this.lblSegmentCount.Name = "lblSegmentCount";
            this.lblSegmentCount.Size = new System.Drawing.Size(29, 12);
            this.lblSegmentCount.TabIndex = 4;
            this.lblSegmentCount.Text = "분할";
            // 
            // numSegmentCount
            // 
            this.numSegmentCount.Location = new System.Drawing.Point(260, 4);
            this.numSegmentCount.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numSegmentCount.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numSegmentCount.Name = "numSegmentCount";
            this.numSegmentCount.Size = new System.Drawing.Size(52, 21);
            this.numSegmentCount.TabIndex = 5;
            this.numSegmentCount.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // lblAxisAnchor
            // 
            this.lblAxisAnchor.AutoSize = true;
            this.lblAxisAnchor.Location = new System.Drawing.Point(320, 8);
            this.lblAxisAnchor.Name = "lblAxisAnchor";
            this.lblAxisAnchor.Size = new System.Drawing.Size(41, 12);
            this.lblAxisAnchor.TabIndex = 6;
            this.lblAxisAnchor.Text = "기준점";
            // 
            // cmbAxisAnchor
            // 
            this.cmbAxisAnchor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAxisAnchor.FormattingEnabled = true;
            this.cmbAxisAnchor.Items.AddRange(new object[] {
            "Min",
            "Center",
            "Max"});
            this.cmbAxisAnchor.Location = new System.Drawing.Point(366, 4);
            this.cmbAxisAnchor.Name = "cmbAxisAnchor";
            this.cmbAxisAnchor.Size = new System.Drawing.Size(76, 20);
            this.cmbAxisAnchor.TabIndex = 7;
            this.cmbAxisAnchor.SelectedIndex = 1;
            // 
            // pnlRotation
            // 
            this.pnlRotation.Controls.Add(this.lblRotation);
            this.pnlRotation.Controls.Add(this.lblRotX);
            this.pnlRotation.Controls.Add(this.numRotX);
            this.pnlRotation.Controls.Add(this.lblRotY);
            this.pnlRotation.Controls.Add(this.numRotY);
            this.pnlRotation.Controls.Add(this.lblRotZ);
            this.pnlRotation.Controls.Add(this.numRotZ);
            this.pnlRotation.Controls.Add(this.lblRotDegree);
            this.pnlRotation.Controls.Add(this.numRotDegree);
            this.pnlRotation.Location = new System.Drawing.Point(10, 209);
            this.pnlRotation.Name = "pnlRotation";
            this.pnlRotation.Size = new System.Drawing.Size(446, 31);
            this.pnlRotation.TabIndex = 10;
            // 
            // lblRotation
            // 
            this.lblRotation.Location = new System.Drawing.Point(3, 8);
            this.lblRotation.Name = "lblRotation";
            this.lblRotation.Size = new System.Drawing.Size(52, 12);
            this.lblRotation.TabIndex = 0;
            this.lblRotation.Text = "회전축";
            // 
            // lblRotX
            // 
            this.lblRotX.AutoSize = true;
            this.lblRotX.Location = new System.Drawing.Point(58, 8);
            this.lblRotX.Name = "lblRotX";
            this.lblRotX.Size = new System.Drawing.Size(13, 12);
            this.lblRotX.TabIndex = 1;
            this.lblRotX.Text = "X";
            // 
            // numRotX
            // 
            this.numRotX.DecimalPlaces = 2;
            this.numRotX.Location = new System.Drawing.Point(74, 4);
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
            this.numRotX.Size = new System.Drawing.Size(52, 21);
            this.numRotX.TabIndex = 2;
            // 
            // lblRotY
            // 
            this.lblRotY.AutoSize = true;
            this.lblRotY.Location = new System.Drawing.Point(132, 8);
            this.lblRotY.Name = "lblRotY";
            this.lblRotY.Size = new System.Drawing.Size(13, 12);
            this.lblRotY.TabIndex = 3;
            this.lblRotY.Text = "Y";
            // 
            // numRotY
            // 
            this.numRotY.DecimalPlaces = 2;
            this.numRotY.Location = new System.Drawing.Point(148, 4);
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
            this.numRotY.Size = new System.Drawing.Size(52, 21);
            this.numRotY.TabIndex = 4;
            // 
            // lblRotZ
            // 
            this.lblRotZ.AutoSize = true;
            this.lblRotZ.Location = new System.Drawing.Point(206, 8);
            this.lblRotZ.Name = "lblRotZ";
            this.lblRotZ.Size = new System.Drawing.Size(13, 12);
            this.lblRotZ.TabIndex = 5;
            this.lblRotZ.Text = "Z";
            // 
            // numRotZ
            // 
            this.numRotZ.DecimalPlaces = 2;
            this.numRotZ.Location = new System.Drawing.Point(222, 4);
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
            this.numRotZ.Size = new System.Drawing.Size(52, 21);
            this.numRotZ.TabIndex = 6;
            this.numRotZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblRotDegree
            // 
            this.lblRotDegree.AutoSize = true;
            this.lblRotDegree.Location = new System.Drawing.Point(286, 8);
            this.lblRotDegree.Name = "lblRotDegree";
            this.lblRotDegree.Size = new System.Drawing.Size(29, 12);
            this.lblRotDegree.TabIndex = 7;
            this.lblRotDegree.Text = "각도";
            // 
            // numRotDegree
            // 
            this.numRotDegree.DecimalPlaces = 1;
            this.numRotDegree.Location = new System.Drawing.Point(320, 4);
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
            this.numRotDegree.Size = new System.Drawing.Size(70, 21);
            this.numRotDegree.TabIndex = 8;
            // 
            // lblCreateCategory
            // 
            this.lblCreateCategory.AutoSize = true;
            this.lblCreateCategory.Location = new System.Drawing.Point(13, 251);
            this.lblCreateCategory.Name = "lblCreateCategory";
            this.lblCreateCategory.Size = new System.Drawing.Size(53, 12);
            this.lblCreateCategory.TabIndex = 11;
            this.lblCreateCategory.Text = "카테고리";
            // 
            // txtCreateCategory
            // 
            this.txtCreateCategory.Location = new System.Drawing.Point(72, 247);
            this.txtCreateCategory.Name = "txtCreateCategory";
            this.txtCreateCategory.Size = new System.Drawing.Size(164, 21);
            this.txtCreateCategory.TabIndex = 12;
            this.txtCreateCategory.Text = "SHAPE_SAMPLE";
            // 
            // lblModeInfo
            // 
            this.lblModeInfo.AutoSize = true;
            this.lblModeInfo.Location = new System.Drawing.Point(247, 251);
            this.lblModeInfo.Name = "lblModeInfo";
            this.lblModeInfo.Size = new System.Drawing.Size(65, 12);
            this.lblModeInfo.TabIndex = 13;
            this.lblModeInfo.Text = "방식 : 기본";
            // 
            // lblCreateHint
            // 
            this.lblCreateHint.AutoEllipsis = true;
            this.lblCreateHint.Location = new System.Drawing.Point(13, 272);
            this.lblCreateHint.Name = "lblCreateHint";
            this.lblCreateHint.Size = new System.Drawing.Size(443, 15);
            this.lblCreateHint.TabIndex = 14;
            this.lblCreateHint.Text = "형상 설명";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(10, 290);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(446, 26);
            this.btnCreate.TabIndex = 15;
            this.btnCreate.Text = "생성";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // grpShapeList
            // 
            this.grpShapeList.Controls.Add(this.lblManageTarget);
            this.grpShapeList.Controls.Add(this.cmbManageTarget);
            this.grpShapeList.Controls.Add(this.lblManageCategory);
            this.grpShapeList.Controls.Add(this.txtManageCategory);
            this.grpShapeList.Controls.Add(this.btnCategoryCount);
            this.grpShapeList.Controls.Add(this.btnRefresh);
            this.grpShapeList.Controls.Add(this.btnCategoryApply);
            this.grpShapeList.Controls.Add(this.btnCategoryClear);
            this.grpShapeList.Controls.Add(this.btnShow);
            this.grpShapeList.Controls.Add(this.btnHide);
            this.grpShapeList.Controls.Add(this.btnSelectedDelete);
            this.grpShapeList.Controls.Add(this.btnCategoryDelete);
            this.grpShapeList.Controls.Add(this.btnClearAll);
            this.grpShapeList.Controls.Add(this.chkSelectable);
            this.grpShapeList.Controls.Add(this.chkHighlightable);
            this.grpShapeList.Controls.Add(this.chkDepthTest);
            this.grpShapeList.Controls.Add(this.lblSelectionRadius);
            this.grpShapeList.Controls.Add(this.numSelectionRadius);
            this.grpShapeList.Controls.Add(this.lblHighlightColor);
            this.grpShapeList.Controls.Add(this.btnHighlightColor);
            this.grpShapeList.Controls.Add(this.lblSelectedColor);
            this.grpShapeList.Controls.Add(this.btnSelectedColor);
            this.grpShapeList.Controls.Add(this.lblCategoryCount);
            this.grpShapeList.Controls.Add(this.lblShapeListInfo);
            this.grpShapeList.Controls.Add(this.dgvShapes);
            this.grpShapeList.Controls.Add(this.lblSelectedShapeInfo);
            this.grpShapeList.Controls.Add(this.lblMoveX);
            this.grpShapeList.Controls.Add(this.numMoveX);
            this.grpShapeList.Controls.Add(this.lblMoveY);
            this.grpShapeList.Controls.Add(this.numMoveY);
            this.grpShapeList.Controls.Add(this.lblMoveZ);
            this.grpShapeList.Controls.Add(this.numMoveZ);
            this.grpShapeList.Controls.Add(this.btnMoveOsnap);
            this.grpShapeList.Controls.Add(this.lblTransformVector);
            this.grpShapeList.Controls.Add(this.numTransformX);
            this.grpShapeList.Controls.Add(this.numTransformY);
            this.grpShapeList.Controls.Add(this.numTransformZ);
            this.grpShapeList.Controls.Add(this.lblTransformDegree);
            this.grpShapeList.Controls.Add(this.numTransformDegree);
            this.grpShapeList.Controls.Add(this.btnRotateSelected);
            this.grpShapeList.Controls.Add(this.btnDirectionSelected);
            this.grpShapeList.Location = new System.Drawing.Point(7, 337);
            this.grpShapeList.Name = "grpShapeList";
            this.grpShapeList.Size = new System.Drawing.Size(472, 414);
            this.grpShapeList.TabIndex = 1;
            this.grpShapeList.TabStop = false;
            this.grpShapeList.Text = "2. 형상 목록 / 대상 관리 / 이동 / 회전";
            // 
            // lblManageTarget
            // 
            this.lblManageTarget.AutoSize = true;
            this.lblManageTarget.Location = new System.Drawing.Point(13, 27);
            this.lblManageTarget.Name = "lblManageTarget";
            this.lblManageTarget.Size = new System.Drawing.Size(53, 12);
            this.lblManageTarget.TabIndex = 0;
            this.lblManageTarget.Text = "적용 대상";
            // 
            // cmbManageTarget
            // 
            this.cmbManageTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManageTarget.FormattingEnabled = true;
            this.cmbManageTarget.Items.AddRange(new object[] {
            "현재 선택",
            "전체"});
            this.cmbManageTarget.Location = new System.Drawing.Point(72, 23);
            this.cmbManageTarget.Name = "cmbManageTarget";
            this.cmbManageTarget.Size = new System.Drawing.Size(92, 20);
            this.cmbManageTarget.TabIndex = 1;
            this.cmbManageTarget.SelectedIndex = 0;
            // 
            // lblManageCategory
            // 
            this.lblManageCategory.AutoSize = true;
            this.lblManageCategory.Location = new System.Drawing.Point(177, 27);
            this.lblManageCategory.Name = "lblManageCategory";
            this.lblManageCategory.Size = new System.Drawing.Size(53, 12);
            this.lblManageCategory.TabIndex = 2;
            this.lblManageCategory.Text = "카테고리";
            // 
            // txtManageCategory
            // 
            this.txtManageCategory.Location = new System.Drawing.Point(236, 23);
            this.txtManageCategory.Name = "txtManageCategory";
            this.txtManageCategory.Size = new System.Drawing.Size(98, 21);
            this.txtManageCategory.TabIndex = 3;
            this.txtManageCategory.Text = "SHAPE_SAMPLE";
            // 
            // btnCategoryCount
            // 
            this.btnCategoryCount.Location = new System.Drawing.Point(340, 21);
            this.btnCategoryCount.Name = "btnCategoryCount";
            this.btnCategoryCount.Size = new System.Drawing.Size(54, 24);
            this.btnCategoryCount.TabIndex = 4;
            this.btnCategoryCount.Text = "조회";
            this.btnCategoryCount.UseVisualStyleBackColor = true;
            this.btnCategoryCount.Click += new System.EventHandler(this.btnCategoryCount_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(400, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(54, 24);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "전체";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCategoryApply
            // 
            this.btnCategoryApply.Location = new System.Drawing.Point(13, 54);
            this.btnCategoryApply.Name = "btnCategoryApply";
            this.btnCategoryApply.Size = new System.Drawing.Size(76, 24);
            this.btnCategoryApply.TabIndex = 6;
            this.btnCategoryApply.Text = "분류 지정";
            this.btnCategoryApply.UseVisualStyleBackColor = true;
            this.btnCategoryApply.Click += new System.EventHandler(this.btnCategoryApply_Click);
            // 
            // btnCategoryClear
            // 
            this.btnCategoryClear.Location = new System.Drawing.Point(95, 54);
            this.btnCategoryClear.Name = "btnCategoryClear";
            this.btnCategoryClear.Size = new System.Drawing.Size(76, 24);
            this.btnCategoryClear.TabIndex = 7;
            this.btnCategoryClear.Text = "분류 해제";
            this.btnCategoryClear.UseVisualStyleBackColor = true;
            this.btnCategoryClear.Click += new System.EventHandler(this.btnCategoryClear_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(177, 54);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(58, 24);
            this.btnShow.TabIndex = 8;
            this.btnShow.Text = "표시";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(241, 54);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(58, 24);
            this.btnHide.TabIndex = 9;
            this.btnHide.Text = "숨김";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnSelectedDelete
            // 
            this.btnSelectedDelete.Location = new System.Drawing.Point(305, 54);
            this.btnSelectedDelete.Name = "btnSelectedDelete";
            this.btnSelectedDelete.Size = new System.Drawing.Size(72, 24);
            this.btnSelectedDelete.TabIndex = 10;
            this.btnSelectedDelete.Text = "선택 삭제";
            this.btnSelectedDelete.UseVisualStyleBackColor = true;
            this.btnSelectedDelete.Click += new System.EventHandler(this.btnSelectedDelete_Click);
            // 
            // btnCategoryDelete
            // 
            this.btnCategoryDelete.Location = new System.Drawing.Point(13, 83);
            this.btnCategoryDelete.Name = "btnCategoryDelete";
            this.btnCategoryDelete.Size = new System.Drawing.Size(76, 24);
            this.btnCategoryDelete.TabIndex = 11;
            this.btnCategoryDelete.Text = "분류 삭제";
            this.btnCategoryDelete.UseVisualStyleBackColor = true;
            this.btnCategoryDelete.Click += new System.EventHandler(this.btnCategoryDelete_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(95, 83);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(76, 24);
            this.btnClearAll.TabIndex = 12;
            this.btnClearAll.Text = "전체 삭제";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // lblCategoryCount
            // 
            this.lblCategoryCount.AutoSize = true;
            this.lblCategoryCount.Location = new System.Drawing.Point(185, 89);
            this.lblCategoryCount.Name = "lblCategoryCount";
            this.lblCategoryCount.Size = new System.Drawing.Size(47, 12);
            this.lblCategoryCount.TabIndex = 11;
            this.lblCategoryCount.Text = "결과 : -";
            // 
            // chkSelectable
            // 
            this.chkSelectable.AutoSize = true;
            this.chkSelectable.Checked = true;
            this.chkSelectable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelectable.Location = new System.Drawing.Point(13, 118);
            this.chkSelectable.Name = "chkSelectable";
            this.chkSelectable.Size = new System.Drawing.Size(76, 16);
            this.chkSelectable.TabIndex = 12;
            this.chkSelectable.Text = "선택 가능";
            this.chkSelectable.UseVisualStyleBackColor = true;
            this.chkSelectable.CheckedChanged += new System.EventHandler(this.chkSelectable_CheckedChanged);
            // 
            // chkHighlightable
            // 
            this.chkHighlightable.AutoSize = true;
            this.chkHighlightable.Checked = true;
            this.chkHighlightable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHighlightable.Location = new System.Drawing.Point(99, 118);
            this.chkHighlightable.Name = "chkHighlightable";
            this.chkHighlightable.Size = new System.Drawing.Size(76, 16);
            this.chkHighlightable.TabIndex = 13;
            this.chkHighlightable.Text = "강조 가능";
            this.chkHighlightable.UseVisualStyleBackColor = true;
            this.chkHighlightable.CheckedChanged += new System.EventHandler(this.chkHighlightable_CheckedChanged);
            // 
            // chkDepthTest
            // 
            this.chkDepthTest.AutoSize = true;
            this.chkDepthTest.Checked = true;
            this.chkDepthTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDepthTest.Location = new System.Drawing.Point(185, 118);
            this.chkDepthTest.Name = "chkDepthTest";
            this.chkDepthTest.Size = new System.Drawing.Size(88, 16);
            this.chkDepthTest.TabIndex = 14;
            this.chkDepthTest.Text = "깊이 테스트";
            this.chkDepthTest.UseVisualStyleBackColor = true;
            this.chkDepthTest.CheckedChanged += new System.EventHandler(this.chkDepthTest_CheckedChanged);
            // 
            // lblSelectionRadius
            // 
            this.lblSelectionRadius.AutoSize = true;
            this.lblSelectionRadius.Location = new System.Drawing.Point(282, 119);
            this.lblSelectionRadius.Name = "lblSelectionRadius";
            this.lblSelectionRadius.Size = new System.Drawing.Size(57, 12);
            this.lblSelectionRadius.TabIndex = 15;
            this.lblSelectionRadius.Text = "선택 반경";
            // 
            // numSelectionRadius
            // 
            this.numSelectionRadius.Location = new System.Drawing.Point(345, 115);
            this.numSelectionRadius.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            this.numSelectionRadius.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSelectionRadius.Name = "numSelectionRadius";
            this.numSelectionRadius.Size = new System.Drawing.Size(48, 21);
            this.numSelectionRadius.TabIndex = 16;
            this.numSelectionRadius.Value = new decimal(new int[] { 6, 0, 0, 0 });
            this.numSelectionRadius.ValueChanged += new System.EventHandler(this.numSelectionRadius_ValueChanged);
            // 
            // lblHighlightColor
            // 
            this.lblHighlightColor.AutoSize = true;
            this.lblHighlightColor.Location = new System.Drawing.Point(13, 149);
            this.lblHighlightColor.Name = "lblHighlightColor";
            this.lblHighlightColor.Size = new System.Drawing.Size(57, 12);
            this.lblHighlightColor.TabIndex = 17;
            this.lblHighlightColor.Text = "강조 색상";
            // 
            // btnHighlightColor
            // 
            this.btnHighlightColor.BackColor = System.Drawing.Color.Yellow;
            this.btnHighlightColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHighlightColor.Location = new System.Drawing.Point(76, 143);
            this.btnHighlightColor.Name = "btnHighlightColor";
            this.btnHighlightColor.Size = new System.Drawing.Size(52, 24);
            this.btnHighlightColor.TabIndex = 18;
            this.btnHighlightColor.Text = "선택";
            this.btnHighlightColor.UseVisualStyleBackColor = false;
            this.btnHighlightColor.Click += new System.EventHandler(this.btnHighlightColor_Click);
            // 
            // lblSelectedColor
            // 
            this.lblSelectedColor.AutoSize = true;
            this.lblSelectedColor.Location = new System.Drawing.Point(148, 149);
            this.lblSelectedColor.Name = "lblSelectedColor";
            this.lblSelectedColor.Size = new System.Drawing.Size(57, 12);
            this.lblSelectedColor.TabIndex = 19;
            this.lblSelectedColor.Text = "선택 색상";
            // 
            // btnSelectedColor
            // 
            this.btnSelectedColor.BackColor = System.Drawing.Color.Red;
            this.btnSelectedColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectedColor.Location = new System.Drawing.Point(211, 143);
            this.btnSelectedColor.Name = "btnSelectedColor";
            this.btnSelectedColor.Size = new System.Drawing.Size(52, 24);
            this.btnSelectedColor.TabIndex = 20;
            this.btnSelectedColor.Text = "선택";
            this.btnSelectedColor.UseVisualStyleBackColor = false;
            this.btnSelectedColor.Click += new System.EventHandler(this.btnSelectedColor_Click);
            // 
            // lblShapeListInfo
            // 
            this.lblShapeListInfo.AutoSize = true;
            this.lblShapeListInfo.Location = new System.Drawing.Point(13, 180);
            this.lblShapeListInfo.Name = "lblShapeListInfo";
            this.lblShapeListInfo.Size = new System.Drawing.Size(75, 12);
            this.lblShapeListInfo.TabIndex = 21;
            this.lblShapeListInfo.Text = "전체 목록 : 0개";
            // 
            // dgvShapes
            // 
            this.dgvShapes.AllowUserToAddRows = false;
            this.dgvShapes.AllowUserToDeleteRows = false;
            this.dgvShapes.AllowUserToResizeRows = false;
            this.dgvShapes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvShapes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShapes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colShapeNo,
            this.colShapeType,
            this.colShapeCategory});
            this.dgvShapes.Location = new System.Drawing.Point(13, 198);
            this.dgvShapes.MultiSelect = false;
            this.dgvShapes.Name = "dgvShapes";
            this.dgvShapes.ReadOnly = true;
            this.dgvShapes.RowHeadersVisible = false;
            this.dgvShapes.RowTemplate.Height = 23;
            this.dgvShapes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShapes.Size = new System.Drawing.Size(443, 96);
            this.dgvShapes.TabIndex = 22;
            this.dgvShapes.SelectionChanged += new System.EventHandler(this.dgvShapes_SelectionChanged);
            // 
            // lblSelectedShapeInfo
            // 
            this.lblSelectedShapeInfo.AutoSize = true;
            this.lblSelectedShapeInfo.Location = new System.Drawing.Point(13, 308);
            this.lblSelectedShapeInfo.Name = "lblSelectedShapeInfo";
            this.lblSelectedShapeInfo.Size = new System.Drawing.Size(81, 12);
            this.lblSelectedShapeInfo.TabIndex = 23;
            this.lblSelectedShapeInfo.Text = "선택 형상 : 없음";
            // 
            // colShapeNo
            // 
            this.colShapeNo.HeaderText = "No.";
            this.colShapeNo.Name = "colShapeNo";
            this.colShapeNo.ReadOnly = true;
            this.colShapeNo.Width = 42;
            // 
            // colShapeType
            // 
            this.colShapeType.HeaderText = "형상";
            this.colShapeType.Name = "colShapeType";
            this.colShapeType.ReadOnly = true;
            this.colShapeType.Width = 150;
            // 
            // colShapeCategory
            // 
            this.colShapeCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colShapeCategory.HeaderText = "카테고리";
            this.colShapeCategory.Name = "colShapeCategory";
            this.colShapeCategory.ReadOnly = true;
            // lblMoveX
            // 
            this.lblMoveX.AutoSize = true;
            this.lblMoveX.Location = new System.Drawing.Point(15, 334);
            this.lblMoveX.Name = "lblMoveX";
            this.lblMoveX.Size = new System.Drawing.Size(13, 12);
            this.lblMoveX.TabIndex = 0;
            this.lblMoveX.Text = "X";
            // 
            // numMoveX
            // 
            this.numMoveX.DecimalPlaces = 3;
            this.numMoveX.Location = new System.Drawing.Point(32, 330);
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
            this.numMoveX.Size = new System.Drawing.Size(78, 21);
            this.numMoveX.TabIndex = 1;
            // 
            // lblMoveY
            // 
            this.lblMoveY.AutoSize = true;
            this.lblMoveY.Location = new System.Drawing.Point(118, 334);
            this.lblMoveY.Name = "lblMoveY";
            this.lblMoveY.Size = new System.Drawing.Size(13, 12);
            this.lblMoveY.TabIndex = 2;
            this.lblMoveY.Text = "Y";
            // 
            // numMoveY
            // 
            this.numMoveY.DecimalPlaces = 3;
            this.numMoveY.Location = new System.Drawing.Point(135, 330);
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
            this.numMoveY.Size = new System.Drawing.Size(78, 21);
            this.numMoveY.TabIndex = 3;
            // 
            // lblMoveZ
            // 
            this.lblMoveZ.AutoSize = true;
            this.lblMoveZ.Location = new System.Drawing.Point(221, 334);
            this.lblMoveZ.Name = "lblMoveZ";
            this.lblMoveZ.Size = new System.Drawing.Size(13, 12);
            this.lblMoveZ.TabIndex = 4;
            this.lblMoveZ.Text = "Z";
            // 
            // numMoveZ
            // 
            this.numMoveZ.DecimalPlaces = 3;
            this.numMoveZ.Location = new System.Drawing.Point(238, 330);
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
            this.numMoveZ.Size = new System.Drawing.Size(78, 21);
            this.numMoveZ.TabIndex = 5;
            // 
            // btnMoveOsnap
            // 
            this.btnMoveOsnap.Location = new System.Drawing.Point(326, 328);
            this.btnMoveOsnap.Name = "btnMoveOsnap";
            this.btnMoveOsnap.Size = new System.Drawing.Size(130, 25);
            this.btnMoveOsnap.TabIndex = 6;
            this.btnMoveOsnap.Text = "Osnap 이동";
            this.btnMoveOsnap.UseVisualStyleBackColor = true;
            this.btnMoveOsnap.Click += new System.EventHandler(this.btnMoveOsnap_Click);
            // 
            // lblTransformVector
            // 
            this.lblTransformVector.AutoSize = true;
            this.lblTransformVector.Location = new System.Drawing.Point(15, 372);
            this.lblTransformVector.Name = "lblTransformVector";
            this.lblTransformVector.Size = new System.Drawing.Size(47, 12);
            this.lblTransformVector.TabIndex = 7;
            this.lblTransformVector.Text = "축/방향";
            // 
            // numTransformX
            // 
            this.numTransformX.DecimalPlaces = 2;
            this.numTransformX.Location = new System.Drawing.Point(70, 368);
            this.numTransformX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTransformX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numTransformX.Name = "numTransformX";
            this.numTransformX.Size = new System.Drawing.Size(48, 21);
            this.numTransformX.TabIndex = 8;
            this.numTransformX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numTransformY
            // 
            this.numTransformY.DecimalPlaces = 2;
            this.numTransformY.Location = new System.Drawing.Point(124, 368);
            this.numTransformY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTransformY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numTransformY.Name = "numTransformY";
            this.numTransformY.Size = new System.Drawing.Size(48, 21);
            this.numTransformY.TabIndex = 9;
            // 
            // numTransformZ
            // 
            this.numTransformZ.DecimalPlaces = 2;
            this.numTransformZ.Location = new System.Drawing.Point(178, 368);
            this.numTransformZ.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTransformZ.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numTransformZ.Name = "numTransformZ";
            this.numTransformZ.Size = new System.Drawing.Size(48, 21);
            this.numTransformZ.TabIndex = 10;
            // 
            // lblTransformDegree
            // 
            this.lblTransformDegree.AutoSize = true;
            this.lblTransformDegree.Location = new System.Drawing.Point(239, 372);
            this.lblTransformDegree.Name = "lblTransformDegree";
            this.lblTransformDegree.Size = new System.Drawing.Size(29, 12);
            this.lblTransformDegree.TabIndex = 11;
            this.lblTransformDegree.Text = "각도";
            // 
            // numTransformDegree
            // 
            this.numTransformDegree.DecimalPlaces = 1;
            this.numTransformDegree.Location = new System.Drawing.Point(274, 368);
            this.numTransformDegree.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numTransformDegree.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numTransformDegree.Name = "numTransformDegree";
            this.numTransformDegree.Size = new System.Drawing.Size(62, 21);
            this.numTransformDegree.TabIndex = 12;
            // 
            // btnRotateSelected
            // 
            this.btnRotateSelected.Location = new System.Drawing.Point(344, 366);
            this.btnRotateSelected.Name = "btnRotateSelected";
            this.btnRotateSelected.Size = new System.Drawing.Size(52, 24);
            this.btnRotateSelected.TabIndex = 13;
            this.btnRotateSelected.Text = "회전";
            this.btnRotateSelected.UseVisualStyleBackColor = true;
            this.btnRotateSelected.Click += new System.EventHandler(this.btnRotateSelected_Click);
            // 
            // btnDirectionSelected
            // 
            this.btnDirectionSelected.Location = new System.Drawing.Point(404, 366);
            this.btnDirectionSelected.Name = "btnDirectionSelected";
            this.btnDirectionSelected.Size = new System.Drawing.Size(52, 24);
            this.btnDirectionSelected.TabIndex = 14;
            this.btnDirectionSelected.Text = "방향";
            this.btnDirectionSelected.UseVisualStyleBackColor = true;
            this.btnDirectionSelected.Click += new System.EventHandler(this.btnDirectionSelected_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 760);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.ShapeControl";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlOption.ResumeLayout(false);
            this.grpCreate.ResumeLayout(false);
            this.grpCreate.PerformLayout();
            this.pnlPoint1.ResumeLayout(false);
            this.pnlPoint1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numP1X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP1Z)).EndInit();
            this.pnlPoint2.ResumeLayout(false);
            this.pnlPoint2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numP2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP2Z)).EndInit();
            this.pnlPoint3.ResumeLayout(false);
            this.pnlPoint3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numP3X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP3Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP3Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineSegments)).EndInit();
            this.pnlLineSegments.ResumeLayout(false);
            this.pnlValues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numValue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue3)).EndInit();
            this.pnlStroke.ResumeLayout(false);
            this.pnlStroke.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStrokeThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSegmentCount)).EndInit();
            this.pnlRotation.ResumeLayout(false);
            this.pnlRotation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRotX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotDegree)).EndInit();
            this.grpShapeList.ResumeLayout(false);
            this.grpShapeList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShapes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransformX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransformY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransformZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransformDegree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectionRadius)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlViewHost;
        private System.Windows.Forms.Panel pnlOption;
        private System.Windows.Forms.GroupBox grpCreate;
        private System.Windows.Forms.Label lblShapeType;
        private System.Windows.Forms.ComboBox cmbShapeType;
        private System.Windows.Forms.Label lblCreateMode;
        private System.Windows.Forms.ComboBox cmbCreateMode;
        private System.Windows.Forms.Button btnCreateColor;
        private System.Windows.Forms.Panel pnlPoint1;
        private System.Windows.Forms.Label lblPoint1Title;
        private System.Windows.Forms.Label lblP1X;
        private System.Windows.Forms.NumericUpDown numP1X;
        private System.Windows.Forms.Label lblP1Y;
        private System.Windows.Forms.NumericUpDown numP1Y;
        private System.Windows.Forms.Label lblP1Z;
        private System.Windows.Forms.NumericUpDown numP1Z;
        private System.Windows.Forms.Button btnPoint1Osnap;
        private System.Windows.Forms.Panel pnlPoint2;
        private System.Windows.Forms.Label lblPoint2Title;
        private System.Windows.Forms.Label lblP2X;
        private System.Windows.Forms.NumericUpDown numP2X;
        private System.Windows.Forms.Label lblP2Y;
        private System.Windows.Forms.NumericUpDown numP2Y;
        private System.Windows.Forms.Label lblP2Z;
        private System.Windows.Forms.NumericUpDown numP2Z;
        private System.Windows.Forms.Button btnPoint2Osnap;
        private System.Windows.Forms.Panel pnlPoint3;
        private System.Windows.Forms.Label lblPoint3Title;
        private System.Windows.Forms.Label lblP3X;
        private System.Windows.Forms.NumericUpDown numP3X;
        private System.Windows.Forms.Label lblP3Y;
        private System.Windows.Forms.NumericUpDown numP3Y;
        private System.Windows.Forms.Label lblP3Z;
        private System.Windows.Forms.NumericUpDown numP3Z;
        private System.Windows.Forms.Button btnPoint3Osnap;
        private System.Windows.Forms.Panel pnlLineSegments;
        private System.Windows.Forms.DataGridView dgvLineSegments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineEnd;
        private System.Windows.Forms.Button btnLineSegmentAdd;
        private System.Windows.Forms.Button btnLineSegmentRemove;
        private System.Windows.Forms.Button btnLineSegmentClear;
        private System.Windows.Forms.Panel pnlValues;
        private System.Windows.Forms.Label lblValue1;
        private System.Windows.Forms.NumericUpDown numValue1;
        private System.Windows.Forms.Label lblValue2;
        private System.Windows.Forms.NumericUpDown numValue2;
        private System.Windows.Forms.Label lblValue3;
        private System.Windows.Forms.NumericUpDown numValue3;
        private System.Windows.Forms.Panel pnlStroke;
        private System.Windows.Forms.Label lblStrokeThickness;
        private System.Windows.Forms.NumericUpDown numStrokeThickness;
        private System.Windows.Forms.Label lblStrokePattern;
        private System.Windows.Forms.ComboBox cmbStrokePattern;
        private System.Windows.Forms.Label lblSegmentCount;
        private System.Windows.Forms.NumericUpDown numSegmentCount;
        private System.Windows.Forms.Label lblAxisAnchor;
        private System.Windows.Forms.ComboBox cmbAxisAnchor;
        private System.Windows.Forms.Panel pnlRotation;
        private System.Windows.Forms.Label lblRotation;
        private System.Windows.Forms.Label lblRotX;
        private System.Windows.Forms.NumericUpDown numRotX;
        private System.Windows.Forms.Label lblRotY;
        private System.Windows.Forms.NumericUpDown numRotY;
        private System.Windows.Forms.Label lblRotZ;
        private System.Windows.Forms.NumericUpDown numRotZ;
        private System.Windows.Forms.Label lblRotDegree;
        private System.Windows.Forms.NumericUpDown numRotDegree;
        private System.Windows.Forms.Label lblCreateCategory;
        private System.Windows.Forms.TextBox txtCreateCategory;
        private System.Windows.Forms.Label lblModeInfo;
        private System.Windows.Forms.Label lblCreateHint;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox grpShapeList;
        private System.Windows.Forms.Label lblShapeListInfo;
        private System.Windows.Forms.Label lblSelectedShapeInfo;
        private System.Windows.Forms.DataGridView dgvShapes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShapeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShapeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShapeCategory;
        private System.Windows.Forms.Label lblMoveX;
        private System.Windows.Forms.NumericUpDown numMoveX;
        private System.Windows.Forms.Label lblMoveY;
        private System.Windows.Forms.NumericUpDown numMoveY;
        private System.Windows.Forms.Label lblMoveZ;
        private System.Windows.Forms.NumericUpDown numMoveZ;
        private System.Windows.Forms.Button btnMoveOsnap;
        private System.Windows.Forms.Label lblTransformVector;
        private System.Windows.Forms.NumericUpDown numTransformX;
        private System.Windows.Forms.NumericUpDown numTransformY;
        private System.Windows.Forms.NumericUpDown numTransformZ;
        private System.Windows.Forms.Label lblTransformDegree;
        private System.Windows.Forms.NumericUpDown numTransformDegree;
        private System.Windows.Forms.Button btnRotateSelected;
        private System.Windows.Forms.Button btnDirectionSelected;
        private System.Windows.Forms.Label lblManageTarget;
        private System.Windows.Forms.ComboBox cmbManageTarget;
        private System.Windows.Forms.Label lblManageCategory;
        private System.Windows.Forms.TextBox txtManageCategory;
        private System.Windows.Forms.Button btnCategoryCount;
        private System.Windows.Forms.Button btnCategoryApply;
        private System.Windows.Forms.Button btnCategoryClear;
        private System.Windows.Forms.Button btnSelectedDelete;
        private System.Windows.Forms.Button btnCategoryDelete;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label lblCategoryCount;
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
        private System.Windows.Forms.Button btnRefresh;
    }
}
