namespace VIZCore3DX.NET.Primitive
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPrimitive = new System.Windows.Forms.TabPage();
            this.grpPrimitive = new System.Windows.Forms.GroupBox();
            this.lblPrimitiveType = new System.Windows.Forms.Label();
            this.cmbPrimitiveType = new System.Windows.Forms.ComboBox();
            this.lblNodeName = new System.Windows.Forms.Label();
            this.txtNodeName = new System.Windows.Forms.TextBox();
            this.chkCreateAssembly = new System.Windows.Forms.CheckBox();
            this.lblAxisAnchor = new System.Windows.Forms.Label();
            this.cmbAxisAnchor = new System.Windows.Forms.ComboBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnOsnap = new System.Windows.Forms.Button();
            this.lblMoveX = new System.Windows.Forms.Label();
            this.numMoveX = new System.Windows.Forms.NumericUpDown();
            this.lblMoveY = new System.Windows.Forms.Label();
            this.numMoveY = new System.Windows.Forms.NumericUpDown();
            this.lblMoveZ = new System.Windows.Forms.Label();
            this.numMoveZ = new System.Windows.Forms.NumericUpDown();
            this.tlpMove = new System.Windows.Forms.TableLayoutPanel();
            this.grpParameter = new System.Windows.Forms.GroupBox();
            this.lblValue1 = new System.Windows.Forms.Label();
            this.numValue1 = new System.Windows.Forms.NumericUpDown();
            this.lblValue2 = new System.Windows.Forms.Label();
            this.numValue2 = new System.Windows.Forms.NumericUpDown();
            this.lblValue3 = new System.Windows.Forms.Label();
            this.numValue3 = new System.Windows.Forms.NumericUpDown();
            this.lblGuide = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.tabEtc = new System.Windows.Forms.TabPage();
            this.grpNode = new System.Windows.Forms.GroupBox();
            this.txtAddNodeName = new System.Windows.Forms.TextBox();
            this.chkNodeAssembly = new System.Windows.Forms.CheckBox();
            this.btnAddNode = new System.Windows.Forms.Button();
            this.lblNodeResult = new System.Windows.Forms.Label();
            this.grpDialog = new System.Windows.Forms.GroupBox();
            this.cmbDialogPrimitive = new System.Windows.Forms.ComboBox();
            this.btnShowDialog = new System.Windows.Forms.Button();
            this.grpRootNode = new System.Windows.Forms.GroupBox();
            this.txtRootNodeName = new System.Windows.Forms.TextBox();
            this.btnAddRootNode = new System.Windows.Forms.Button();
            this.lblRootNodeResult = new System.Windows.Forms.Label();
            this.grpMeshFile = new System.Windows.Forms.GroupBox();
            this.lblMeshFile = new System.Windows.Forms.Label();
            this.txtMeshFile = new System.Windows.Forms.TextBox();
            this.btnBrowseMeshFile = new System.Windows.Forms.Button();
            this.lblMeshNodeName = new System.Windows.Forms.Label();
            this.txtMeshNodeName = new System.Windows.Forms.TextBox();
            this.lblMeshColor = new System.Windows.Forms.Label();
            this.btnMeshColor = new System.Windows.Forms.Button();
            this.lblMeshGuide = new System.Windows.Forms.Label();
            this.btnAddMeshFile = new System.Windows.Forms.Button();
            this.lblMeshFileResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPrimitive.SuspendLayout();
            this.grpPrimitive.SuspendLayout();
            this.tlpMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveZ)).BeginInit();
            this.grpParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue3)).BeginInit();
            this.tabEtc.SuspendLayout();
            this.grpNode.SuspendLayout();
            this.grpDialog.SuspendLayout();
            this.grpRootNode.SuspendLayout();
            this.grpMeshFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(1280, 760);
            this.splitContainer1.SplitterDistance = 896;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPrimitive);
            this.tabControl1.Controls.Add(this.tabEtc);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(380, 760);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPrimitive
            // 
            this.tabPrimitive.Controls.Add(this.grpPrimitive);
            this.tabPrimitive.Controls.Add(this.grpParameter);
            this.tabPrimitive.Controls.Add(this.btnCreate);
            this.tabPrimitive.Controls.Add(this.lblResult);
            this.tabPrimitive.Location = new System.Drawing.Point(4, 22);
            this.tabPrimitive.Name = "tabPrimitive";
            this.tabPrimitive.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrimitive.Size = new System.Drawing.Size(372, 734);
            this.tabPrimitive.TabIndex = 0;
            this.tabPrimitive.Text = "Primitive";
            this.tabPrimitive.UseVisualStyleBackColor = true;
            // 
            // grpPrimitive
            // 
            this.grpPrimitive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPrimitive.Controls.Add(this.lblPrimitiveType);
            this.grpPrimitive.Controls.Add(this.cmbPrimitiveType);
            this.grpPrimitive.Controls.Add(this.lblNodeName);
            this.grpPrimitive.Controls.Add(this.txtNodeName);
            this.grpPrimitive.Controls.Add(this.chkCreateAssembly);
            this.grpPrimitive.Controls.Add(this.lblAxisAnchor);
            this.grpPrimitive.Controls.Add(this.cmbAxisAnchor);
            this.grpPrimitive.Controls.Add(this.lblColor);
            this.grpPrimitive.Controls.Add(this.btnColor);
            this.grpPrimitive.Controls.Add(this.btnOsnap);
            this.grpPrimitive.Controls.Add(this.tlpMove);
            this.grpPrimitive.Location = new System.Drawing.Point(8, 8);
            this.grpPrimitive.Name = "grpPrimitive";
            this.grpPrimitive.Size = new System.Drawing.Size(356, 237);
            this.grpPrimitive.TabIndex = 0;
            this.grpPrimitive.TabStop = false;
            this.grpPrimitive.Text = "Primitive";
            // 
            // lblPrimitiveType
            // 
            this.lblPrimitiveType.AutoSize = true;
            this.lblPrimitiveType.Location = new System.Drawing.Point(12, 28);
            this.lblPrimitiveType.Name = "lblPrimitiveType";
            this.lblPrimitiveType.Size = new System.Drawing.Size(29, 12);
            this.lblPrimitiveType.TabIndex = 0;
            this.lblPrimitiveType.Text = "종류";
            // 
            // cmbPrimitiveType
            // 
            this.cmbPrimitiveType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrimitiveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrimitiveType.FormattingEnabled = true;
            this.cmbPrimitiveType.Items.AddRange(new object[] {
            "Box",
            "Cone",
            "Cylinder",
            "Hemisphere",
            "Mesh",
            "Pyramid",
            "RectangularTorus",
            "Sphere",
            "SphericalCap",
            "Spheroid",
            "Torus"});
            this.cmbPrimitiveType.Location = new System.Drawing.Point(90, 24);
            this.cmbPrimitiveType.Name = "cmbPrimitiveType";
            this.cmbPrimitiveType.Size = new System.Drawing.Size(250, 20);
            this.cmbPrimitiveType.TabIndex = 1;
            this.cmbPrimitiveType.SelectedIndex = 0;
            this.cmbPrimitiveType.SelectedIndexChanged += new System.EventHandler(this.cmbPrimitiveType_SelectedIndexChanged);
            // 
            // lblNodeName
            // 
            this.lblNodeName.AutoSize = true;
            this.lblNodeName.Location = new System.Drawing.Point(12, 62);
            this.lblNodeName.Name = "lblNodeName";
            this.lblNodeName.Size = new System.Drawing.Size(57, 12);
            this.lblNodeName.TabIndex = 2;
            this.lblNodeName.Text = "노드 이름";
            // 
            // txtNodeName
            // 
            this.txtNodeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNodeName.Location = new System.Drawing.Point(90, 58);
            this.txtNodeName.Name = "txtNodeName";
            this.txtNodeName.Size = new System.Drawing.Size(250, 21);
            this.txtNodeName.TabIndex = 3;
            this.txtNodeName.Text = "Primitive Box";
            // 
            // chkCreateAssembly
            // 
            this.chkCreateAssembly.AutoSize = true;
            this.chkCreateAssembly.Checked = true;
            this.chkCreateAssembly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreateAssembly.Location = new System.Drawing.Point(90, 91);
            this.chkCreateAssembly.Name = "chkCreateAssembly";
            this.chkCreateAssembly.Size = new System.Drawing.Size(109, 16);
            this.chkCreateAssembly.TabIndex = 4;
            this.chkCreateAssembly.Text = "Assembly 생성";
            this.chkCreateAssembly.UseVisualStyleBackColor = true;
            // 
            // lblAxisAnchor
            // 
            this.lblAxisAnchor.AutoSize = true;
            this.lblAxisAnchor.Location = new System.Drawing.Point(12, 118);
            this.lblAxisAnchor.Name = "lblAxisAnchor";
            this.lblAxisAnchor.Size = new System.Drawing.Size(74, 12);
            this.lblAxisAnchor.TabIndex = 5;
            this.lblAxisAnchor.Text = "Axis Anchor";
            // 
            // cmbAxisAnchor
            // 
            this.cmbAxisAnchor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAxisAnchor.FormattingEnabled = true;
            this.cmbAxisAnchor.Items.AddRange(new object[] {
            VIZCore3DX.NET.Data.AxisAnchor.Min,
            VIZCore3DX.NET.Data.AxisAnchor.Center,
            VIZCore3DX.NET.Data.AxisAnchor.Max});
            this.cmbAxisAnchor.Location = new System.Drawing.Point(90, 114);
            this.cmbAxisAnchor.Name = "cmbAxisAnchor";
            this.cmbAxisAnchor.Size = new System.Drawing.Size(100, 20);
            this.cmbAxisAnchor.TabIndex = 6;
            this.cmbAxisAnchor.SelectedIndex = 1;
            // 
            // lblColor
            // 
            this.lblColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(235, 118);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(29, 12);
            this.lblColor.TabIndex = 7;
            this.lblColor.Text = "색상";
            // 
            // btnColor
            // 
            this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColor.BackColor = System.Drawing.Color.Yellow;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Location = new System.Drawing.Point(280, 111);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(60, 27);
            this.btnColor.TabIndex = 8;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnOsnap
            // 
            this.btnOsnap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOsnap.Location = new System.Drawing.Point(12, 143);
            this.btnOsnap.Name = "btnOsnap";
            this.btnOsnap.Size = new System.Drawing.Size(328, 25);
            this.btnOsnap.TabIndex = 9;
            this.btnOsnap.Text = "위치 Osnap";
            this.btnOsnap.UseVisualStyleBackColor = true;
            this.btnOsnap.Click += new System.EventHandler(this.btnOsnap_Click);
            // 
            // tlpMove
            // 
            this.tlpMove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMove.ColumnCount = 3;
            this.tlpMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpMove.Controls.Add(this.lblMoveX, 0, 0);
            this.tlpMove.Controls.Add(this.lblMoveY, 1, 0);
            this.tlpMove.Controls.Add(this.lblMoveZ, 2, 0);
            this.tlpMove.Controls.Add(this.numMoveX, 0, 1);
            this.tlpMove.Controls.Add(this.numMoveY, 1, 1);
            this.tlpMove.Controls.Add(this.numMoveZ, 2, 1);
            this.tlpMove.Location = new System.Drawing.Point(9, 172);
            this.tlpMove.Name = "tlpMove";
            this.tlpMove.RowCount = 2;
            this.tlpMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMove.Size = new System.Drawing.Size(334, 50);
            this.tlpMove.TabIndex = 10;
            // 
            // lblMoveX
            // 
            this.lblMoveX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMoveX.AutoSize = true;
            this.lblMoveX.Location = new System.Drawing.Point(3, 5);
            this.lblMoveX.Name = "lblMoveX";
            this.lblMoveX.Size = new System.Drawing.Size(48, 12);
            this.lblMoveX.TabIndex = 0;
            this.lblMoveX.Text = "Move X";
            // 
            // numMoveX
            // 
            this.numMoveX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numMoveX.DecimalPlaces = 1;
            this.numMoveX.Location = new System.Drawing.Point(3, 24);
            this.numMoveX.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMoveX.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.numMoveX.Name = "numMoveX";
            this.numMoveX.Size = new System.Drawing.Size(105, 21);
            this.numMoveX.TabIndex = 3;
            // 
            // lblMoveY
            // 
            this.lblMoveY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMoveY.AutoSize = true;
            this.lblMoveY.Location = new System.Drawing.Point(114, 5);
            this.lblMoveY.Name = "lblMoveY";
            this.lblMoveY.Size = new System.Drawing.Size(48, 12);
            this.lblMoveY.TabIndex = 1;
            this.lblMoveY.Text = "Move Y";
            // 
            // numMoveY
            // 
            this.numMoveY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numMoveY.DecimalPlaces = 1;
            this.numMoveY.Location = new System.Drawing.Point(114, 24);
            this.numMoveY.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMoveY.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.numMoveY.Name = "numMoveY";
            this.numMoveY.Size = new System.Drawing.Size(105, 21);
            this.numMoveY.TabIndex = 4;
            // 
            // lblMoveZ
            // 
            this.lblMoveZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMoveZ.AutoSize = true;
            this.lblMoveZ.Location = new System.Drawing.Point(225, 5);
            this.lblMoveZ.Name = "lblMoveZ";
            this.lblMoveZ.Size = new System.Drawing.Size(48, 12);
            this.lblMoveZ.TabIndex = 2;
            this.lblMoveZ.Text = "Move Z";
            // 
            // numMoveZ
            // 
            this.numMoveZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numMoveZ.DecimalPlaces = 1;
            this.numMoveZ.Location = new System.Drawing.Point(225, 24);
            this.numMoveZ.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMoveZ.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.numMoveZ.Name = "numMoveZ";
            this.numMoveZ.Size = new System.Drawing.Size(105, 21);
            this.numMoveZ.TabIndex = 5;
            // 
            // grpParameter
            // 
            this.grpParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpParameter.Controls.Add(this.lblValue1);
            this.grpParameter.Controls.Add(this.numValue1);
            this.grpParameter.Controls.Add(this.lblValue2);
            this.grpParameter.Controls.Add(this.numValue2);
            this.grpParameter.Controls.Add(this.lblValue3);
            this.grpParameter.Controls.Add(this.numValue3);
            this.grpParameter.Controls.Add(this.lblGuide);
            this.grpParameter.Location = new System.Drawing.Point(8, 251);
            this.grpParameter.Name = "grpParameter";
            this.grpParameter.Size = new System.Drawing.Size(356, 175);
            this.grpParameter.TabIndex = 1;
            this.grpParameter.TabStop = false;
            this.grpParameter.Text = "파라미터";
            // 
            // lblValue1
            // 
            this.lblValue1.AutoSize = true;
            this.lblValue1.Location = new System.Drawing.Point(12, 30);
            this.lblValue1.Name = "lblValue1";
            this.lblValue1.Size = new System.Drawing.Size(42, 12);
            this.lblValue1.TabIndex = 0;
            this.lblValue1.Text = "Size X";
            // 
            // numValue1
            // 
            this.numValue1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numValue1.DecimalPlaces = 1;
            this.numValue1.Location = new System.Drawing.Point(120, 26);
            this.numValue1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numValue1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numValue1.Name = "numValue1";
            this.numValue1.Size = new System.Drawing.Size(220, 21);
            this.numValue1.TabIndex = 1;
            this.numValue1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lblValue2
            // 
            this.lblValue2.AutoSize = true;
            this.lblValue2.Location = new System.Drawing.Point(12, 62);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(42, 12);
            this.lblValue2.TabIndex = 2;
            this.lblValue2.Text = "Size Y";
            // 
            // numValue2
            // 
            this.numValue2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numValue2.DecimalPlaces = 1;
            this.numValue2.Location = new System.Drawing.Point(120, 58);
            this.numValue2.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numValue2.Name = "numValue2";
            this.numValue2.Size = new System.Drawing.Size(220, 21);
            this.numValue2.TabIndex = 3;
            this.numValue2.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lblValue3
            // 
            this.lblValue3.AutoSize = true;
            this.lblValue3.Location = new System.Drawing.Point(12, 94);
            this.lblValue3.Name = "lblValue3";
            this.lblValue3.Size = new System.Drawing.Size(42, 12);
            this.lblValue3.TabIndex = 4;
            this.lblValue3.Text = "Size Z";
            // 
            // numValue3
            // 
            this.numValue3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numValue3.DecimalPlaces = 1;
            this.numValue3.Location = new System.Drawing.Point(120, 90);
            this.numValue3.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numValue3.Name = "numValue3";
            this.numValue3.Size = new System.Drawing.Size(220, 21);
            this.numValue3.TabIndex = 5;
            this.numValue3.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lblGuide
            // 
            this.lblGuide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGuide.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblGuide.Location = new System.Drawing.Point(12, 128);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(328, 35);
            this.lblGuide.TabIndex = 6;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(8, 432);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(356, 32);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Primitive 생성";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.AutoEllipsis = true;
            this.lblResult.Location = new System.Drawing.Point(10, 480);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(354, 20);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "생성 결과 : -";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabEtc
            // 
            this.tabEtc.Controls.Add(this.grpNode);
            this.tabEtc.Controls.Add(this.grpDialog);
            this.tabEtc.Controls.Add(this.grpRootNode);
            this.tabEtc.Controls.Add(this.grpMeshFile);
            this.tabEtc.Location = new System.Drawing.Point(4, 22);
            this.tabEtc.Name = "tabEtc";
            this.tabEtc.Padding = new System.Windows.Forms.Padding(3);
            this.tabEtc.Size = new System.Drawing.Size(372, 734);
            this.tabEtc.TabIndex = 1;
            this.tabEtc.Text = "Node / Dialog / File";
            this.tabEtc.UseVisualStyleBackColor = true;
            // 
            // grpNode
            // 
            this.grpNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNode.Controls.Add(this.txtAddNodeName);
            this.grpNode.Controls.Add(this.chkNodeAssembly);
            this.grpNode.Controls.Add(this.btnAddNode);
            this.grpNode.Controls.Add(this.lblNodeResult);
            this.grpNode.Location = new System.Drawing.Point(8, 8);
            this.grpNode.Name = "grpNode";
            this.grpNode.Size = new System.Drawing.Size(356, 145);
            this.grpNode.TabIndex = 0;
            this.grpNode.TabStop = false;
            this.grpNode.Text = "AddNode";
            // 
            // txtAddNodeName
            // 
            this.txtAddNodeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddNodeName.Location = new System.Drawing.Point(12, 25);
            this.txtAddNodeName.Name = "txtAddNodeName";
            this.txtAddNodeName.Size = new System.Drawing.Size(328, 21);
            this.txtAddNodeName.TabIndex = 0;
            this.txtAddNodeName.Text = "Primitive Node";
            // 
            // chkNodeAssembly
            // 
            this.chkNodeAssembly.AutoSize = true;
            this.chkNodeAssembly.Checked = true;
            this.chkNodeAssembly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNodeAssembly.Location = new System.Drawing.Point(12, 57);
            this.chkNodeAssembly.Name = "chkNodeAssembly";
            this.chkNodeAssembly.Size = new System.Drawing.Size(109, 16);
            this.chkNodeAssembly.TabIndex = 1;
            this.chkNodeAssembly.Text = "Assembly 생성";
            this.chkNodeAssembly.UseVisualStyleBackColor = true;
            // 
            // btnAddNode
            // 
            this.btnAddNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNode.Location = new System.Drawing.Point(12, 82);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(328, 28);
            this.btnAddNode.TabIndex = 2;
            this.btnAddNode.Text = "AddNode 실행";
            this.btnAddNode.UseVisualStyleBackColor = true;
            this.btnAddNode.Click += new System.EventHandler(this.btnAddNode_Click);
            // 
            // lblNodeResult
            // 
            this.lblNodeResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNodeResult.AutoEllipsis = true;
            this.lblNodeResult.Location = new System.Drawing.Point(12, 121);
            this.lblNodeResult.Name = "lblNodeResult";
            this.lblNodeResult.Size = new System.Drawing.Size(328, 20);
            this.lblNodeResult.TabIndex = 3;
            this.lblNodeResult.Text = "생성 결과 : -";
            this.lblNodeResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpDialog
            // 
            this.grpDialog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDialog.Controls.Add(this.cmbDialogPrimitive);
            this.grpDialog.Controls.Add(this.btnShowDialog);
            this.grpDialog.Location = new System.Drawing.Point(8, 163);
            this.grpDialog.Name = "grpDialog";
            this.grpDialog.Size = new System.Drawing.Size(356, 100);
            this.grpDialog.TabIndex = 1;
            this.grpDialog.TabStop = false;
            this.grpDialog.Text = "ShowAddPrimitiveDialog";
            // 
            // cmbDialogPrimitive
            // 
            this.cmbDialogPrimitive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDialogPrimitive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDialogPrimitive.FormattingEnabled = true;
            this.cmbDialogPrimitive.Items.AddRange(new object[] {
            VIZCore3DX.NET.Data.Primitives.BOX,
            VIZCore3DX.NET.Data.Primitives.CYLINDER,
            VIZCore3DX.NET.Data.Primitives.CONE,
            VIZCore3DX.NET.Data.Primitives.SPHERE,
            VIZCore3DX.NET.Data.Primitives.CIRCULAR_TORUS,
            VIZCore3DX.NET.Data.Primitives.SLOPE_BOTTOM_CYLINDER,
            VIZCore3DX.NET.Data.Primitives.PYRAMID,
            VIZCore3DX.NET.Data.Primitives.SPHEROID,
            VIZCore3DX.NET.Data.Primitives.RECTANGULAR_TORUS,
            VIZCore3DX.NET.Data.Primitives.HEMISPHERE});
            this.cmbDialogPrimitive.Location = new System.Drawing.Point(12, 25);
            this.cmbDialogPrimitive.Name = "cmbDialogPrimitive";
            this.cmbDialogPrimitive.Size = new System.Drawing.Size(328, 20);
            this.cmbDialogPrimitive.TabIndex = 0;
            this.cmbDialogPrimitive.SelectedIndex = 0;
            // 
            // btnShowDialog
            // 
            this.btnShowDialog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowDialog.Location = new System.Drawing.Point(12, 57);
            this.btnShowDialog.Name = "btnShowDialog";
            this.btnShowDialog.Size = new System.Drawing.Size(328, 28);
            this.btnShowDialog.TabIndex = 1;
            this.btnShowDialog.Text = "ShowAddPrimitiveDialog 실행";
            this.btnShowDialog.UseVisualStyleBackColor = true;
            this.btnShowDialog.Click += new System.EventHandler(this.btnShowDialog_Click);
            // 
            // grpRootNode
            // 
            this.grpRootNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRootNode.Controls.Add(this.txtRootNodeName);
            this.grpRootNode.Controls.Add(this.btnAddRootNode);
            this.grpRootNode.Controls.Add(this.lblRootNodeResult);
            this.grpRootNode.Location = new System.Drawing.Point(8, 271);
            this.grpRootNode.Name = "grpRootNode";
            this.grpRootNode.Size = new System.Drawing.Size(356, 120);
            this.grpRootNode.TabIndex = 2;
            this.grpRootNode.TabStop = false;
            this.grpRootNode.Text = "AddRootNode (빈 씬에 루트 생성)";
            // 
            // txtRootNodeName
            // 
            this.txtRootNodeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRootNodeName.Location = new System.Drawing.Point(12, 24);
            this.txtRootNodeName.Name = "txtRootNodeName";
            this.txtRootNodeName.Size = new System.Drawing.Size(328, 21);
            this.txtRootNodeName.TabIndex = 0;
            this.txtRootNodeName.Text = "Primitive Root";
            // 
            // btnAddRootNode
            // 
            this.btnAddRootNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRootNode.Location = new System.Drawing.Point(12, 54);
            this.btnAddRootNode.Name = "btnAddRootNode";
            this.btnAddRootNode.Size = new System.Drawing.Size(328, 28);
            this.btnAddRootNode.TabIndex = 1;
            this.btnAddRootNode.Text = "AddRootNode 실행";
            this.btnAddRootNode.UseVisualStyleBackColor = true;
            this.btnAddRootNode.Click += new System.EventHandler(this.btnAddRootNode_Click);
            // 
            // lblRootNodeResult
            // 
            this.lblRootNodeResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRootNodeResult.AutoEllipsis = true;
            this.lblRootNodeResult.Location = new System.Drawing.Point(12, 88);
            this.lblRootNodeResult.Name = "lblRootNodeResult";
            this.lblRootNodeResult.Size = new System.Drawing.Size(328, 20);
            this.lblRootNodeResult.TabIndex = 2;
            this.lblRootNodeResult.Text = "생성 결과 : -";
            this.lblRootNodeResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpMeshFile
            // 
            this.grpMeshFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMeshFile.Controls.Add(this.lblMeshFile);
            this.grpMeshFile.Controls.Add(this.txtMeshFile);
            this.grpMeshFile.Controls.Add(this.btnBrowseMeshFile);
            this.grpMeshFile.Controls.Add(this.lblMeshNodeName);
            this.grpMeshFile.Controls.Add(this.txtMeshNodeName);
            this.grpMeshFile.Controls.Add(this.lblMeshColor);
            this.grpMeshFile.Controls.Add(this.btnMeshColor);
            this.grpMeshFile.Controls.Add(this.lblMeshGuide);
            this.grpMeshFile.Controls.Add(this.btnAddMeshFile);
            this.grpMeshFile.Controls.Add(this.lblMeshFileResult);
            this.grpMeshFile.Location = new System.Drawing.Point(8, 399);
            this.grpMeshFile.Name = "grpMeshFile";
            this.grpMeshFile.Size = new System.Drawing.Size(356, 232);
            this.grpMeshFile.TabIndex = 3;
            this.grpMeshFile.TabStop = false;
            this.grpMeshFile.Text = "AddPrimitiveMeshFromFile";
            // 
            // lblMeshFile
            // 
            this.lblMeshFile.AutoSize = true;
            this.lblMeshFile.Location = new System.Drawing.Point(12, 28);
            this.lblMeshFile.Name = "lblMeshFile";
            this.lblMeshFile.Size = new System.Drawing.Size(29, 12);
            this.lblMeshFile.TabIndex = 0;
            this.lblMeshFile.Text = "파일";
            // 
            // txtMeshFile
            // 
            this.txtMeshFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMeshFile.Location = new System.Drawing.Point(80, 24);
            this.txtMeshFile.Name = "txtMeshFile";
            this.txtMeshFile.ReadOnly = true;
            this.txtMeshFile.Size = new System.Drawing.Size(194, 21);
            this.txtMeshFile.TabIndex = 1;
            // 
            // btnBrowseMeshFile
            // 
            this.btnBrowseMeshFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseMeshFile.Location = new System.Drawing.Point(280, 22);
            this.btnBrowseMeshFile.Name = "btnBrowseMeshFile";
            this.btnBrowseMeshFile.Size = new System.Drawing.Size(60, 25);
            this.btnBrowseMeshFile.TabIndex = 2;
            this.btnBrowseMeshFile.Text = "찾기";
            this.btnBrowseMeshFile.UseVisualStyleBackColor = true;
            this.btnBrowseMeshFile.Click += new System.EventHandler(this.btnBrowseMeshFile_Click);
            // 
            // lblMeshNodeName
            // 
            this.lblMeshNodeName.AutoSize = true;
            this.lblMeshNodeName.Location = new System.Drawing.Point(12, 60);
            this.lblMeshNodeName.Name = "lblMeshNodeName";
            this.lblMeshNodeName.Size = new System.Drawing.Size(57, 12);
            this.lblMeshNodeName.TabIndex = 3;
            this.lblMeshNodeName.Text = "노드 이름";
            // 
            // txtMeshNodeName
            // 
            this.txtMeshNodeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMeshNodeName.Location = new System.Drawing.Point(80, 56);
            this.txtMeshNodeName.Name = "txtMeshNodeName";
            this.txtMeshNodeName.Size = new System.Drawing.Size(260, 21);
            this.txtMeshNodeName.TabIndex = 4;
            this.txtMeshNodeName.Text = "Mesh File";
            // 
            // lblMeshColor
            // 
            this.lblMeshColor.AutoSize = true;
            this.lblMeshColor.Location = new System.Drawing.Point(12, 91);
            this.lblMeshColor.Name = "lblMeshColor";
            this.lblMeshColor.Size = new System.Drawing.Size(57, 12);
            this.lblMeshColor.TabIndex = 5;
            this.lblMeshColor.Text = "기본 색상";
            // 
            // btnMeshColor
            // 
            this.btnMeshColor.BackColor = System.Drawing.Color.LightGray;
            this.btnMeshColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeshColor.Location = new System.Drawing.Point(80, 85);
            this.btnMeshColor.Name = "btnMeshColor";
            this.btnMeshColor.Size = new System.Drawing.Size(60, 25);
            this.btnMeshColor.TabIndex = 6;
            this.btnMeshColor.UseVisualStyleBackColor = false;
            this.btnMeshColor.Click += new System.EventHandler(this.btnMeshColor_Click);
            // 
            // lblMeshGuide
            // 
            this.lblMeshGuide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMeshGuide.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblMeshGuide.Location = new System.Drawing.Point(12, 120);
            this.lblMeshGuide.Name = "lblMeshGuide";
            this.lblMeshGuide.Size = new System.Drawing.Size(328, 40);
            this.lblMeshGuide.TabIndex = 7;
            this.lblMeshGuide.Text = "지원 형식 : STL(ASCII/Binary), OBJ, PLY(ASCII)\r\n기본 색상은 정점 색상이 없는 파일에 적용됩니다.\r\n위치는 Primitive 탭의 Move X/Y/Z 값을 사용합니다.";
            // 
            // btnAddMeshFile
            // 
            this.btnAddMeshFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMeshFile.Location = new System.Drawing.Point(12, 166);
            this.btnAddMeshFile.Name = "btnAddMeshFile";
            this.btnAddMeshFile.Size = new System.Drawing.Size(328, 28);
            this.btnAddMeshFile.TabIndex = 8;
            this.btnAddMeshFile.Text = "AddPrimitiveMeshFromFile 실행";
            this.btnAddMeshFile.UseVisualStyleBackColor = true;
            this.btnAddMeshFile.Click += new System.EventHandler(this.btnAddMeshFile_Click);
            // 
            // lblMeshFileResult
            // 
            this.lblMeshFileResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMeshFileResult.AutoEllipsis = true;
            this.lblMeshFileResult.Location = new System.Drawing.Point(12, 200);
            this.lblMeshFileResult.Name = "lblMeshFileResult";
            this.lblMeshFileResult.Size = new System.Drawing.Size(328, 20);
            this.lblMeshFileResult.TabIndex = 9;
            this.lblMeshFileResult.Text = "생성 결과 : -";
            this.lblMeshFileResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.Primitive";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPrimitive.ResumeLayout(false);
            this.tabPrimitive.PerformLayout();
            this.grpPrimitive.ResumeLayout(false);
            this.grpPrimitive.PerformLayout();
            this.tlpMove.ResumeLayout(false);
            this.tlpMove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveZ)).EndInit();
            this.grpParameter.ResumeLayout(false);
            this.grpParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue3)).EndInit();
            this.tabEtc.ResumeLayout(false);
            this.grpNode.ResumeLayout(false);
            this.grpNode.PerformLayout();
            this.grpDialog.ResumeLayout(false);
            this.grpRootNode.ResumeLayout(false);
            this.grpRootNode.PerformLayout();
            this.grpMeshFile.ResumeLayout(false);
            this.grpMeshFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPrimitive;
        private System.Windows.Forms.GroupBox grpPrimitive;
        private System.Windows.Forms.Label lblPrimitiveType;
        private System.Windows.Forms.ComboBox cmbPrimitiveType;
        private System.Windows.Forms.Label lblNodeName;
        private System.Windows.Forms.TextBox txtNodeName;
        private System.Windows.Forms.CheckBox chkCreateAssembly;
        private System.Windows.Forms.Label lblAxisAnchor;
        private System.Windows.Forms.ComboBox cmbAxisAnchor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnOsnap;
        private System.Windows.Forms.Label lblMoveX;
        private System.Windows.Forms.NumericUpDown numMoveX;
        private System.Windows.Forms.Label lblMoveY;
        private System.Windows.Forms.NumericUpDown numMoveY;
        private System.Windows.Forms.Label lblMoveZ;
        private System.Windows.Forms.NumericUpDown numMoveZ;
        private System.Windows.Forms.TableLayoutPanel tlpMove;
        private System.Windows.Forms.GroupBox grpParameter;
        private System.Windows.Forms.Label lblValue1;
        private System.Windows.Forms.NumericUpDown numValue1;
        private System.Windows.Forms.Label lblValue2;
        private System.Windows.Forms.NumericUpDown numValue2;
        private System.Windows.Forms.Label lblValue3;
        private System.Windows.Forms.NumericUpDown numValue3;
        private System.Windows.Forms.Label lblGuide;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TabPage tabEtc;
        private System.Windows.Forms.GroupBox grpNode;
        private System.Windows.Forms.TextBox txtAddNodeName;
        private System.Windows.Forms.CheckBox chkNodeAssembly;
        private System.Windows.Forms.Button btnAddNode;
        private System.Windows.Forms.Label lblNodeResult;
        private System.Windows.Forms.GroupBox grpDialog;
        private System.Windows.Forms.ComboBox cmbDialogPrimitive;
        private System.Windows.Forms.Button btnShowDialog;
        private System.Windows.Forms.GroupBox grpRootNode;
        private System.Windows.Forms.TextBox txtRootNodeName;
        private System.Windows.Forms.Button btnAddRootNode;
        private System.Windows.Forms.Label lblRootNodeResult;
        private System.Windows.Forms.GroupBox grpMeshFile;
        private System.Windows.Forms.Label lblMeshFile;
        private System.Windows.Forms.TextBox txtMeshFile;
        private System.Windows.Forms.Button btnBrowseMeshFile;
        private System.Windows.Forms.Label lblMeshNodeName;
        private System.Windows.Forms.TextBox txtMeshNodeName;
        private System.Windows.Forms.Label lblMeshColor;
        private System.Windows.Forms.Button btnMeshColor;
        private System.Windows.Forms.Label lblMeshGuide;
        private System.Windows.Forms.Button btnAddMeshFile;
        private System.Windows.Forms.Label lblMeshFileResult;
    }
}
