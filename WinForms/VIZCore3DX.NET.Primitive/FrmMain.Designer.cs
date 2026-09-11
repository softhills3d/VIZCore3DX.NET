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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPrimitive.SuspendLayout();
            this.grpPrimitive.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(1184, 661);
            this.splitContainer1.SplitterDistance = 830;
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
            this.tabControl1.Size = new System.Drawing.Size(350, 661);
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
            this.tabPrimitive.Size = new System.Drawing.Size(342, 635);
            this.tabPrimitive.TabIndex = 0;
            this.tabPrimitive.Text = "Primitive";
            this.tabPrimitive.UseVisualStyleBackColor = true;
            // 
            // grpPrimitive
            // 
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
            this.grpPrimitive.Controls.Add(this.lblMoveX);
            this.grpPrimitive.Controls.Add(this.numMoveX);
            this.grpPrimitive.Controls.Add(this.lblMoveY);
            this.grpPrimitive.Controls.Add(this.numMoveY);
            this.grpPrimitive.Controls.Add(this.lblMoveZ);
            this.grpPrimitive.Controls.Add(this.numMoveZ);
            this.grpPrimitive.Location = new System.Drawing.Point(8, 8);
            this.grpPrimitive.Name = "grpPrimitive";
            this.grpPrimitive.Size = new System.Drawing.Size(326, 237);
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
            this.cmbPrimitiveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrimitiveType.FormattingEnabled = true;
            this.cmbPrimitiveType.Items.AddRange(new object[] {
            "Box",
            "Cone",
            "Cylinder",
            "Mesh",
            "Pyramid",
            "RectangularTorus",
            "Sphere",
            "SphericalCap",
            "Torus"});
            this.cmbPrimitiveType.Location = new System.Drawing.Point(90, 24);
            this.cmbPrimitiveType.Name = "cmbPrimitiveType";
            this.cmbPrimitiveType.Size = new System.Drawing.Size(220, 20);
            this.cmbPrimitiveType.TabIndex = 1;
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
            this.txtNodeName.Location = new System.Drawing.Point(90, 58);
            this.txtNodeName.Name = "txtNodeName";
            this.txtNodeName.Size = new System.Drawing.Size(220, 21);
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
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(205, 118);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(29, 12);
            this.lblColor.TabIndex = 7;
            this.lblColor.Text = "색상";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Yellow;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Location = new System.Drawing.Point(250, 111);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(60, 27);
            this.btnColor.TabIndex = 8;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnOsnap
            // 
            this.btnOsnap.Location = new System.Drawing.Point(12, 143);
            this.btnOsnap.Name = "btnOsnap";
            this.btnOsnap.Size = new System.Drawing.Size(298, 25);
            this.btnOsnap.TabIndex = 9;
            this.btnOsnap.Text = "위치 Osnap";
            this.btnOsnap.UseVisualStyleBackColor = true;
            this.btnOsnap.Click += new System.EventHandler(this.btnOsnap_Click);
            // 
            // lblMoveX
            // 
            this.lblMoveX.AutoSize = true;
            this.lblMoveX.Location = new System.Drawing.Point(12, 177);
            this.lblMoveX.Name = "lblMoveX";
            this.lblMoveX.Size = new System.Drawing.Size(48, 12);
            this.lblMoveX.TabIndex = 10;
            this.lblMoveX.Text = "Move X";
            // 
            // numMoveX
            // 
            this.numMoveX.DecimalPlaces = 1;
            this.numMoveX.Location = new System.Drawing.Point(12, 194);
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
            this.numMoveX.Size = new System.Drawing.Size(95, 21);
            this.numMoveX.TabIndex = 11;
            // 
            // lblMoveY
            // 
            this.lblMoveY.AutoSize = true;
            this.lblMoveY.Location = new System.Drawing.Point(121, 177);
            this.lblMoveY.Name = "lblMoveY";
            this.lblMoveY.Size = new System.Drawing.Size(48, 12);
            this.lblMoveY.TabIndex = 12;
            this.lblMoveY.Text = "Move Y";
            // 
            // numMoveY
            // 
            this.numMoveY.DecimalPlaces = 1;
            this.numMoveY.Location = new System.Drawing.Point(121, 194);
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
            this.numMoveY.Size = new System.Drawing.Size(95, 21);
            this.numMoveY.TabIndex = 13;
            // 
            // lblMoveZ
            // 
            this.lblMoveZ.AutoSize = true;
            this.lblMoveZ.Location = new System.Drawing.Point(230, 177);
            this.lblMoveZ.Name = "lblMoveZ";
            this.lblMoveZ.Size = new System.Drawing.Size(48, 12);
            this.lblMoveZ.TabIndex = 14;
            this.lblMoveZ.Text = "Move Z";
            // 
            // numMoveZ
            // 
            this.numMoveZ.DecimalPlaces = 1;
            this.numMoveZ.Location = new System.Drawing.Point(230, 194);
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
            this.numMoveZ.Size = new System.Drawing.Size(80, 21);
            this.numMoveZ.TabIndex = 15;
            // 
            // grpParameter
            // 
            this.grpParameter.Controls.Add(this.lblValue1);
            this.grpParameter.Controls.Add(this.numValue1);
            this.grpParameter.Controls.Add(this.lblValue2);
            this.grpParameter.Controls.Add(this.numValue2);
            this.grpParameter.Controls.Add(this.lblValue3);
            this.grpParameter.Controls.Add(this.numValue3);
            this.grpParameter.Controls.Add(this.lblGuide);
            this.grpParameter.Location = new System.Drawing.Point(8, 251);
            this.grpParameter.Name = "grpParameter";
            this.grpParameter.Size = new System.Drawing.Size(326, 175);
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
            this.numValue1.Size = new System.Drawing.Size(190, 21);
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
            this.numValue2.DecimalPlaces = 1;
            this.numValue2.Location = new System.Drawing.Point(120, 58);
            this.numValue2.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numValue2.Name = "numValue2";
            this.numValue2.Size = new System.Drawing.Size(190, 21);
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
            this.numValue3.DecimalPlaces = 1;
            this.numValue3.Location = new System.Drawing.Point(120, 90);
            this.numValue3.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numValue3.Name = "numValue3";
            this.numValue3.Size = new System.Drawing.Size(190, 21);
            this.numValue3.TabIndex = 5;
            this.numValue3.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lblGuide
            // 
            this.lblGuide.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblGuide.Location = new System.Drawing.Point(12, 128);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(298, 35);
            this.lblGuide.TabIndex = 6;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(8, 432);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(326, 38);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Primitive 생성";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(10, 480);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(75, 12);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "생성 결과 : -";
            // 
            // tabEtc
            // 
            this.tabEtc.Controls.Add(this.grpNode);
            this.tabEtc.Controls.Add(this.grpDialog);
            this.tabEtc.Location = new System.Drawing.Point(4, 22);
            this.tabEtc.Name = "tabEtc";
            this.tabEtc.Padding = new System.Windows.Forms.Padding(3);
            this.tabEtc.Size = new System.Drawing.Size(342, 635);
            this.tabEtc.TabIndex = 1;
            this.tabEtc.Text = "Node / Dialog";
            this.tabEtc.UseVisualStyleBackColor = true;
            // 
            // grpNode
            // 
            this.grpNode.Controls.Add(this.txtAddNodeName);
            this.grpNode.Controls.Add(this.chkNodeAssembly);
            this.grpNode.Controls.Add(this.btnAddNode);
            this.grpNode.Controls.Add(this.lblNodeResult);
            this.grpNode.Location = new System.Drawing.Point(8, 8);
            this.grpNode.Name = "grpNode";
            this.grpNode.Size = new System.Drawing.Size(326, 145);
            this.grpNode.TabIndex = 0;
            this.grpNode.TabStop = false;
            this.grpNode.Text = "AddNode";
            // 
            // txtAddNodeName
            // 
            this.txtAddNodeName.Location = new System.Drawing.Point(12, 25);
            this.txtAddNodeName.Name = "txtAddNodeName";
            this.txtAddNodeName.Size = new System.Drawing.Size(298, 21);
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
            this.btnAddNode.Location = new System.Drawing.Point(12, 82);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(298, 28);
            this.btnAddNode.TabIndex = 2;
            this.btnAddNode.Text = "AddNode 실행";
            this.btnAddNode.UseVisualStyleBackColor = true;
            this.btnAddNode.Click += new System.EventHandler(this.btnAddNode_Click);
            // 
            // lblNodeResult
            // 
            this.lblNodeResult.AutoSize = true;
            this.lblNodeResult.Location = new System.Drawing.Point(12, 121);
            this.lblNodeResult.Name = "lblNodeResult";
            this.lblNodeResult.Size = new System.Drawing.Size(75, 12);
            this.lblNodeResult.TabIndex = 3;
            this.lblNodeResult.Text = "생성 결과 : -";
            // 
            // grpDialog
            // 
            this.grpDialog.Controls.Add(this.cmbDialogPrimitive);
            this.grpDialog.Controls.Add(this.btnShowDialog);
            this.grpDialog.Location = new System.Drawing.Point(8, 163);
            this.grpDialog.Name = "grpDialog";
            this.grpDialog.Size = new System.Drawing.Size(326, 100);
            this.grpDialog.TabIndex = 1;
            this.grpDialog.TabStop = false;
            this.grpDialog.Text = "ShowAddPrimitiveDialog";
            // 
            // cmbDialogPrimitive
            // 
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
            VIZCore3DX.NET.Data.Primitives.RECTANGULAR_TORUS});
            this.cmbDialogPrimitive.Location = new System.Drawing.Point(12, 25);
            this.cmbDialogPrimitive.Name = "cmbDialogPrimitive";
            this.cmbDialogPrimitive.Size = new System.Drawing.Size(298, 20);
            this.cmbDialogPrimitive.TabIndex = 0;
            // 
            // btnShowDialog
            // 
            this.btnShowDialog.Location = new System.Drawing.Point(12, 57);
            this.btnShowDialog.Name = "btnShowDialog";
            this.btnShowDialog.Size = new System.Drawing.Size(298, 28);
            this.btnShowDialog.TabIndex = 1;
            this.btnShowDialog.Text = "ShowAddPrimitiveDialog 실행";
            this.btnShowDialog.UseVisualStyleBackColor = true;
            this.btnShowDialog.Click += new System.EventHandler(this.btnShowDialog_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
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
    }
}
