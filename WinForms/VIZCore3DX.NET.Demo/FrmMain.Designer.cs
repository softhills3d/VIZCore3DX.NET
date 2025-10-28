namespace VIZCore3DX.NET.Demo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpModel = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnModelBoundBox = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.btnAddModels = new System.Windows.Forms.Button();
            this.btnCloseModel = new System.Windows.Forms.Button();
            this.tpObjects = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAllObjects = new System.Windows.Forms.Button();
            this.btnSelectedTopObjects = new System.Windows.Forms.Button();
            this.btnSelectedAllObjects = new System.Windows.Forms.Button();
            this.tpSection = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtCenterPosition = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSectionZ = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSectionY = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSectionX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSectionSubID = new System.Windows.Forms.ComboBox();
            this.cbSectionID = new System.Windows.Forms.ComboBox();
            this.btnSetCenter = new System.Windows.Forms.Button();
            this.btnGetCenter = new System.Windows.Forms.Button();
            this.ckShowHandle = new System.Windows.Forms.CheckBox();
            this.btnAddSectionBox = new System.Windows.Forms.Button();
            this.btnUpdateSectionBoxSize = new System.Windows.Forms.Button();
            this.btnClearSection = new System.Windows.Forms.Button();
            this.tpFrame = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.ckGridLabelZ = new System.Windows.Forms.CheckBox();
            this.ckGridLabelY = new System.Windows.Forms.CheckBox();
            this.ckGridLabelX = new System.Windows.Forms.CheckBox();
            this.btnGridHideNum = new System.Windows.Forms.Button();
            this.btnGridShowNum = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnGridColor = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnGetGridItemsZ = new System.Windows.Forms.Button();
            this.btnGetGridItemsX = new System.Windows.Forms.Button();
            this.btnHideFrame = new System.Windows.Forms.Button();
            this.btnGetGridItemsY = new System.Windows.Forms.Button();
            this.btnShowFrame = new System.Windows.Forms.Button();
            this.btnOpenFrame = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvGridResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpView = new System.Windows.Forms.TabPage();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtViewBounboxMinZ = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtViewBounboxMinY = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtViewBounboxMinX = new System.Windows.Forms.TextBox();
            this.btnViewGetBoundBox = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.numZoomRatio = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ckEnableSelectionMouseRButtonUp = new System.Windows.Forms.CheckBox();
            this.ckEnableSelection = new System.Windows.Forms.CheckBox();
            this.ckEnableParentSelection = new System.Windows.Forms.CheckBox();
            this.ckEnableDoubleClickFocusAndFit = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnSetColor = new System.Windows.Forms.Button();
            this.txtColorObjects = new System.Windows.Forms.TextBox();
            this.btnRestoreAlpha = new System.Windows.Forms.Button();
            this.btnRestoreColor = new System.Windows.Forms.Button();
            this.txtAlphaObjects = new System.Windows.Forms.TextBox();
            this.btnSetAlpha = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnXrayClearObjects = new System.Windows.Forms.Button();
            this.btnXrayEnable = new System.Windows.Forms.Button();
            this.btnXrayDisable = new System.Windows.Forms.Button();
            this.btnXrayColor1 = new System.Windows.Forms.Button();
            this.btnXrayColor2 = new System.Windows.Forms.Button();
            this.btnXraySelectObjects = new System.Windows.Forms.Button();
            this.txtXrayObjects = new System.Windows.Forms.TextBox();
            this.tpUDA = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUDAInfo = new System.Windows.Forms.Button();
            this.txtUDA1 = new System.Windows.Forms.TextBox();
            this.txtUDAValue1 = new System.Windows.Forms.TextBox();
            this.btnUDAKeys = new System.Windows.Forms.Button();
            this.txtUDAKey1 = new System.Windows.Forms.TextBox();
            this.txtUDAKey = new System.Windows.Forms.TextBox();
            this.btnUDANodes = new System.Windows.Forms.Button();
            this.btnUDAValues = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvUDAResult = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpNote = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numNoteBoxStrokeAlpha = new System.Windows.Forms.NumericUpDown();
            this.btnNoteBoxStrokeColor = new System.Windows.Forms.Button();
            this.ckNoteBackgroundTransparent = new System.Windows.Forms.CheckBox();
            this.btnNoteBoxFillColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numNoteBoxFillAlpha = new System.Windows.Forms.NumericUpDown();
            this.tpModelTree = new System.Windows.Forms.TabPage();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.btnModelTreeFocus = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtModelTreeIndex = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.btnViewBoxZoom = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtViewBounboxMaxZ = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtViewBounboxMaxY = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtViewBounboxMaxX = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpModel.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tpObjects.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tpSection.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tpFrame.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tpView.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZoomRatio)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tpUDA.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpNote.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNoteBoxStrokeAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNoteBoxFillAlpha)).BeginInit();
            this.tpModelTree.SuspendLayout();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.tcMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1351, 734);
            this.splitContainer1.SplitterDistance = 450;
            this.splitContainer1.TabIndex = 0;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpModel);
            this.tcMain.Controls.Add(this.tpObjects);
            this.tcMain.Controls.Add(this.tpSection);
            this.tcMain.Controls.Add(this.tpFrame);
            this.tcMain.Controls.Add(this.tpView);
            this.tcMain.Controls.Add(this.tpUDA);
            this.tcMain.Controls.Add(this.tpNote);
            this.tcMain.Controls.Add(this.tpModelTree);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(450, 734);
            this.tcMain.TabIndex = 0;
            // 
            // tpModel
            // 
            this.tpModel.Controls.Add(this.groupBox4);
            this.tpModel.Controls.Add(this.groupBox3);
            this.tpModel.Location = new System.Drawing.Point(4, 22);
            this.tpModel.Name = "tpModel";
            this.tpModel.Padding = new System.Windows.Forms.Padding(3);
            this.tpModel.Size = new System.Drawing.Size(442, 708);
            this.tpModel.TabIndex = 0;
            this.tpModel.Text = "Model";
            this.tpModel.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnModelBoundBox);
            this.groupBox4.Location = new System.Drawing.Point(8, 117);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(428, 100);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "BoundBox";
            // 
            // btnModelBoundBox
            // 
            this.btnModelBoundBox.Location = new System.Drawing.Point(25, 41);
            this.btnModelBoundBox.Name = "btnModelBoundBox";
            this.btnModelBoundBox.Size = new System.Drawing.Size(101, 23);
            this.btnModelBoundBox.TabIndex = 3;
            this.btnModelBoundBox.Text = "BoundBox";
            this.btnModelBoundBox.UseVisualStyleBackColor = true;
            this.btnModelBoundBox.Click += new System.EventHandler(this.btnModelBoundBox_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnOpenModel);
            this.groupBox3.Controls.Add(this.btnAddModels);
            this.groupBox3.Controls.Add(this.btnCloseModel);
            this.groupBox3.Location = new System.Drawing.Point(8, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(428, 95);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Model";
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Location = new System.Drawing.Point(25, 38);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(101, 23);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "Open";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // btnAddModels
            // 
            this.btnAddModels.Location = new System.Drawing.Point(160, 38);
            this.btnAddModels.Name = "btnAddModels";
            this.btnAddModels.Size = new System.Drawing.Size(101, 23);
            this.btnAddModels.TabIndex = 1;
            this.btnAddModels.Text = "Add";
            this.btnAddModels.UseVisualStyleBackColor = true;
            this.btnAddModels.Click += new System.EventHandler(this.btnAddModels_Click);
            // 
            // btnCloseModel
            // 
            this.btnCloseModel.Location = new System.Drawing.Point(295, 38);
            this.btnCloseModel.Name = "btnCloseModel";
            this.btnCloseModel.Size = new System.Drawing.Size(101, 23);
            this.btnCloseModel.TabIndex = 2;
            this.btnCloseModel.Text = "Close";
            this.btnCloseModel.UseVisualStyleBackColor = true;
            this.btnCloseModel.Click += new System.EventHandler(this.btnCloseModel_Click);
            // 
            // tpObjects
            // 
            this.tpObjects.Controls.Add(this.groupBox5);
            this.tpObjects.Location = new System.Drawing.Point(4, 22);
            this.tpObjects.Name = "tpObjects";
            this.tpObjects.Padding = new System.Windows.Forms.Padding(3);
            this.tpObjects.Size = new System.Drawing.Size(442, 708);
            this.tpObjects.TabIndex = 1;
            this.tpObjects.Text = "Object";
            this.tpObjects.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAllObjects);
            this.groupBox5.Controls.Add(this.btnSelectedTopObjects);
            this.groupBox5.Controls.Add(this.btnSelectedAllObjects);
            this.groupBox5.Location = new System.Drawing.Point(6, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(428, 100);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Select";
            // 
            // btnAllObjects
            // 
            this.btnAllObjects.Location = new System.Drawing.Point(20, 42);
            this.btnAllObjects.Name = "btnAllObjects";
            this.btnAllObjects.Size = new System.Drawing.Size(113, 23);
            this.btnAllObjects.TabIndex = 0;
            this.btnAllObjects.Text = "All";
            this.btnAllObjects.UseVisualStyleBackColor = true;
            this.btnAllObjects.Click += new System.EventHandler(this.btnAllObjects_Click);
            // 
            // btnSelectedTopObjects
            // 
            this.btnSelectedTopObjects.Location = new System.Drawing.Point(294, 42);
            this.btnSelectedTopObjects.Name = "btnSelectedTopObjects";
            this.btnSelectedTopObjects.Size = new System.Drawing.Size(113, 23);
            this.btnSelectedTopObjects.TabIndex = 2;
            this.btnSelectedTopObjects.Text = "Selected Top";
            this.btnSelectedTopObjects.UseVisualStyleBackColor = true;
            this.btnSelectedTopObjects.Click += new System.EventHandler(this.btnSelectedTopObjects_Click);
            // 
            // btnSelectedAllObjects
            // 
            this.btnSelectedAllObjects.Location = new System.Drawing.Point(157, 42);
            this.btnSelectedAllObjects.Name = "btnSelectedAllObjects";
            this.btnSelectedAllObjects.Size = new System.Drawing.Size(113, 23);
            this.btnSelectedAllObjects.TabIndex = 1;
            this.btnSelectedAllObjects.Text = "Selected All";
            this.btnSelectedAllObjects.UseVisualStyleBackColor = true;
            this.btnSelectedAllObjects.Click += new System.EventHandler(this.btnSelectedAllObjects_Click);
            // 
            // tpSection
            // 
            this.tpSection.Controls.Add(this.groupBox6);
            this.tpSection.Location = new System.Drawing.Point(4, 22);
            this.tpSection.Name = "tpSection";
            this.tpSection.Padding = new System.Windows.Forms.Padding(3);
            this.tpSection.Size = new System.Drawing.Size(442, 708);
            this.tpSection.TabIndex = 2;
            this.tpSection.Text = "Section";
            this.tpSection.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtCenterPosition);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.txtSectionZ);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.txtSectionY);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.txtSectionX);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.cbSectionSubID);
            this.groupBox6.Controls.Add(this.cbSectionID);
            this.groupBox6.Controls.Add(this.btnSetCenter);
            this.groupBox6.Controls.Add(this.btnGetCenter);
            this.groupBox6.Controls.Add(this.ckShowHandle);
            this.groupBox6.Controls.Add(this.btnAddSectionBox);
            this.groupBox6.Controls.Add(this.btnUpdateSectionBoxSize);
            this.groupBox6.Controls.Add(this.btnClearSection);
            this.groupBox6.Location = new System.Drawing.Point(6, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(430, 408);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Section";
            // 
            // txtCenterPosition
            // 
            this.txtCenterPosition.Location = new System.Drawing.Point(110, 293);
            this.txtCenterPosition.Name = "txtCenterPosition";
            this.txtCenterPosition.Size = new System.Drawing.Size(100, 21);
            this.txtCenterPosition.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 296);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "Position :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "Z :";
            // 
            // txtSectionZ
            // 
            this.txtSectionZ.Location = new System.Drawing.Point(83, 245);
            this.txtSectionZ.Name = "txtSectionZ";
            this.txtSectionZ.Size = new System.Drawing.Size(299, 21);
            this.txtSectionZ.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 221);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "Y :";
            // 
            // txtSectionY
            // 
            this.txtSectionY.Location = new System.Drawing.Point(83, 218);
            this.txtSectionY.Name = "txtSectionY";
            this.txtSectionY.Size = new System.Drawing.Size(299, 21);
            this.txtSectionY.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "X :";
            // 
            // txtSectionX
            // 
            this.txtSectionX.Location = new System.Drawing.Point(83, 191);
            this.txtSectionX.Name = "txtSectionX";
            this.txtSectionX.Size = new System.Drawing.Size(299, 21);
            this.txtSectionX.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(241, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "Sub ID :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "ID :";
            // 
            // cbSectionSubID
            // 
            this.cbSectionSubID.FormattingEnabled = true;
            this.cbSectionSubID.Location = new System.Drawing.Point(297, 125);
            this.cbSectionSubID.Name = "cbSectionSubID";
            this.cbSectionSubID.Size = new System.Drawing.Size(85, 20);
            this.cbSectionSubID.TabIndex = 9;
            // 
            // cbSectionID
            // 
            this.cbSectionID.FormattingEnabled = true;
            this.cbSectionID.Location = new System.Drawing.Point(83, 125);
            this.cbSectionID.Name = "cbSectionID";
            this.cbSectionID.Size = new System.Drawing.Size(85, 20);
            this.cbSectionID.TabIndex = 8;
            // 
            // btnSetCenter
            // 
            this.btnSetCenter.Location = new System.Drawing.Point(253, 291);
            this.btnSetCenter.Name = "btnSetCenter";
            this.btnSetCenter.Size = new System.Drawing.Size(129, 23);
            this.btnSetCenter.TabIndex = 7;
            this.btnSetCenter.Text = "Set Center";
            this.btnSetCenter.UseVisualStyleBackColor = true;
            this.btnSetCenter.Click += new System.EventHandler(this.btnSetCenter_Click);
            // 
            // btnGetCenter
            // 
            this.btnGetCenter.Location = new System.Drawing.Point(36, 162);
            this.btnGetCenter.Name = "btnGetCenter";
            this.btnGetCenter.Size = new System.Drawing.Size(346, 23);
            this.btnGetCenter.TabIndex = 6;
            this.btnGetCenter.Text = "Get Center";
            this.btnGetCenter.UseVisualStyleBackColor = true;
            this.btnGetCenter.Click += new System.EventHandler(this.btnGetCenter_Click);
            // 
            // ckShowHandle
            // 
            this.ckShowHandle.AutoSize = true;
            this.ckShowHandle.Location = new System.Drawing.Point(253, 65);
            this.ckShowHandle.Name = "ckShowHandle";
            this.ckShowHandle.Size = new System.Drawing.Size(99, 16);
            this.ckShowHandle.TabIndex = 5;
            this.ckShowHandle.Text = "Show Handle";
            this.ckShowHandle.UseVisualStyleBackColor = true;
            this.ckShowHandle.CheckedChanged += new System.EventHandler(this.ckShowHandle_CheckedChanged);
            // 
            // btnAddSectionBox
            // 
            this.btnAddSectionBox.Location = new System.Drawing.Point(36, 29);
            this.btnAddSectionBox.Name = "btnAddSectionBox";
            this.btnAddSectionBox.Size = new System.Drawing.Size(129, 23);
            this.btnAddSectionBox.TabIndex = 0;
            this.btnAddSectionBox.Text = "Add SectionBox";
            this.btnAddSectionBox.UseVisualStyleBackColor = true;
            this.btnAddSectionBox.Click += new System.EventHandler(this.btnAddSectionBox_Click);
            // 
            // btnUpdateSectionBoxSize
            // 
            this.btnUpdateSectionBoxSize.Location = new System.Drawing.Point(253, 29);
            this.btnUpdateSectionBoxSize.Name = "btnUpdateSectionBoxSize";
            this.btnUpdateSectionBoxSize.Size = new System.Drawing.Size(129, 23);
            this.btnUpdateSectionBoxSize.TabIndex = 4;
            this.btnUpdateSectionBoxSize.Text = "BoxSize";
            this.btnUpdateSectionBoxSize.UseVisualStyleBackColor = true;
            this.btnUpdateSectionBoxSize.Click += new System.EventHandler(this.btnUpdateSectionBoxSize_Click);
            // 
            // btnClearSection
            // 
            this.btnClearSection.Location = new System.Drawing.Point(36, 58);
            this.btnClearSection.Name = "btnClearSection";
            this.btnClearSection.Size = new System.Drawing.Size(129, 23);
            this.btnClearSection.TabIndex = 1;
            this.btnClearSection.Text = "Clear";
            this.btnClearSection.UseVisualStyleBackColor = true;
            this.btnClearSection.Click += new System.EventHandler(this.btnClearSection_Click);
            // 
            // tpFrame
            // 
            this.tpFrame.Controls.Add(this.groupBox12);
            this.tpFrame.Controls.Add(this.groupBox11);
            this.tpFrame.Controls.Add(this.groupBox7);
            this.tpFrame.Controls.Add(this.groupBox2);
            this.tpFrame.Location = new System.Drawing.Point(4, 22);
            this.tpFrame.Name = "tpFrame";
            this.tpFrame.Padding = new System.Windows.Forms.Padding(3);
            this.tpFrame.Size = new System.Drawing.Size(442, 708);
            this.tpFrame.TabIndex = 3;
            this.tpFrame.Text = "Grid";
            this.tpFrame.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.ckGridLabelZ);
            this.groupBox12.Controls.Add(this.ckGridLabelY);
            this.groupBox12.Controls.Add(this.ckGridLabelX);
            this.groupBox12.Controls.Add(this.btnGridHideNum);
            this.groupBox12.Controls.Add(this.btnGridShowNum);
            this.groupBox12.Location = new System.Drawing.Point(8, 220);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(428, 128);
            this.groupBox12.TabIndex = 9;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "VIsible";
            // 
            // ckGridLabelZ
            // 
            this.ckGridLabelZ.AutoSize = true;
            this.ckGridLabelZ.Checked = true;
            this.ckGridLabelZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckGridLabelZ.Location = new System.Drawing.Point(243, 78);
            this.ckGridLabelZ.Name = "ckGridLabelZ";
            this.ckGridLabelZ.Size = new System.Drawing.Size(118, 16);
            this.ckGridLabelZ.TabIndex = 8;
            this.ckGridLabelZ.Text = "Z GridLine Label";
            this.ckGridLabelZ.UseVisualStyleBackColor = true;
            this.ckGridLabelZ.CheckedChanged += new System.EventHandler(this.ckGridLabelZ_CheckedChanged);
            // 
            // ckGridLabelY
            // 
            this.ckGridLabelY.AutoSize = true;
            this.ckGridLabelY.Checked = true;
            this.ckGridLabelY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckGridLabelY.Location = new System.Drawing.Point(243, 56);
            this.ckGridLabelY.Name = "ckGridLabelY";
            this.ckGridLabelY.Size = new System.Drawing.Size(118, 16);
            this.ckGridLabelY.TabIndex = 7;
            this.ckGridLabelY.Text = "Y GridLine Label";
            this.ckGridLabelY.UseVisualStyleBackColor = true;
            this.ckGridLabelY.CheckedChanged += new System.EventHandler(this.ckGridLabelY_CheckedChanged);
            // 
            // ckGridLabelX
            // 
            this.ckGridLabelX.AutoSize = true;
            this.ckGridLabelX.Checked = true;
            this.ckGridLabelX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckGridLabelX.Location = new System.Drawing.Point(243, 34);
            this.ckGridLabelX.Name = "ckGridLabelX";
            this.ckGridLabelX.Size = new System.Drawing.Size(118, 16);
            this.ckGridLabelX.TabIndex = 6;
            this.ckGridLabelX.Text = "X GridLine Label";
            this.ckGridLabelX.UseVisualStyleBackColor = true;
            this.ckGridLabelX.CheckedChanged += new System.EventHandler(this.ckGridLabelX_CheckedChanged);
            // 
            // btnGridHideNum
            // 
            this.btnGridHideNum.Location = new System.Drawing.Point(34, 59);
            this.btnGridHideNum.Name = "btnGridHideNum";
            this.btnGridHideNum.Size = new System.Drawing.Size(128, 23);
            this.btnGridHideNum.TabIndex = 5;
            this.btnGridHideNum.Text = "Hide Number";
            this.btnGridHideNum.UseVisualStyleBackColor = true;
            this.btnGridHideNum.Click += new System.EventHandler(this.btnGridHideNum_Click);
            // 
            // btnGridShowNum
            // 
            this.btnGridShowNum.Location = new System.Drawing.Point(34, 30);
            this.btnGridShowNum.Name = "btnGridShowNum";
            this.btnGridShowNum.Size = new System.Drawing.Size(128, 23);
            this.btnGridShowNum.TabIndex = 1;
            this.btnGridShowNum.Text = "Show Number";
            this.btnGridShowNum.UseVisualStyleBackColor = true;
            this.btnGridShowNum.Click += new System.EventHandler(this.btnGridShowNum_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnGridColor);
            this.groupBox11.Location = new System.Drawing.Point(8, 139);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(428, 75);
            this.groupBox11.TabIndex = 8;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Option";
            // 
            // btnGridColor
            // 
            this.btnGridColor.Location = new System.Drawing.Point(34, 31);
            this.btnGridColor.Name = "btnGridColor";
            this.btnGridColor.Size = new System.Drawing.Size(91, 23);
            this.btnGridColor.TabIndex = 0;
            this.btnGridColor.Text = "Grid Color";
            this.btnGridColor.UseVisualStyleBackColor = true;
            this.btnGridColor.Click += new System.EventHandler(this.btnGridColor_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnGetGridItemsZ);
            this.groupBox7.Controls.Add(this.btnGetGridItemsX);
            this.groupBox7.Controls.Add(this.btnHideFrame);
            this.groupBox7.Controls.Add(this.btnGetGridItemsY);
            this.groupBox7.Controls.Add(this.btnShowFrame);
            this.groupBox7.Controls.Add(this.btnOpenFrame);
            this.groupBox7.Location = new System.Drawing.Point(8, 7);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(428, 126);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Grid";
            // 
            // btnGetGridItemsZ
            // 
            this.btnGetGridItemsZ.Location = new System.Drawing.Point(207, 81);
            this.btnGetGridItemsZ.Name = "btnGetGridItemsZ";
            this.btnGetGridItemsZ.Size = new System.Drawing.Size(170, 23);
            this.btnGetGridItemsZ.TabIndex = 5;
            this.btnGetGridItemsZ.Text = "Z - GridItems";
            this.btnGetGridItemsZ.UseVisualStyleBackColor = true;
            this.btnGetGridItemsZ.Click += new System.EventHandler(this.btnGetGridItemsZ_Click);
            // 
            // btnGetGridItemsX
            // 
            this.btnGetGridItemsX.Location = new System.Drawing.Point(207, 23);
            this.btnGetGridItemsX.Name = "btnGetGridItemsX";
            this.btnGetGridItemsX.Size = new System.Drawing.Size(170, 23);
            this.btnGetGridItemsX.TabIndex = 3;
            this.btnGetGridItemsX.Text = "X - GridItems";
            this.btnGetGridItemsX.UseVisualStyleBackColor = true;
            this.btnGetGridItemsX.Click += new System.EventHandler(this.btnGetGridItemsX_Click);
            // 
            // btnHideFrame
            // 
            this.btnHideFrame.Location = new System.Drawing.Point(34, 81);
            this.btnHideFrame.Name = "btnHideFrame";
            this.btnHideFrame.Size = new System.Drawing.Size(91, 23);
            this.btnHideFrame.TabIndex = 2;
            this.btnHideFrame.Text = "Hide";
            this.btnHideFrame.UseVisualStyleBackColor = true;
            this.btnHideFrame.Click += new System.EventHandler(this.btnHideFrame_Click);
            // 
            // btnGetGridItemsY
            // 
            this.btnGetGridItemsY.Location = new System.Drawing.Point(207, 52);
            this.btnGetGridItemsY.Name = "btnGetGridItemsY";
            this.btnGetGridItemsY.Size = new System.Drawing.Size(170, 23);
            this.btnGetGridItemsY.TabIndex = 4;
            this.btnGetGridItemsY.Text = "Y - GridItems";
            this.btnGetGridItemsY.UseVisualStyleBackColor = true;
            this.btnGetGridItemsY.Click += new System.EventHandler(this.btnGetGridItemsY_Click);
            // 
            // btnShowFrame
            // 
            this.btnShowFrame.Location = new System.Drawing.Point(34, 52);
            this.btnShowFrame.Name = "btnShowFrame";
            this.btnShowFrame.Size = new System.Drawing.Size(91, 23);
            this.btnShowFrame.TabIndex = 1;
            this.btnShowFrame.Text = "Show";
            this.btnShowFrame.UseVisualStyleBackColor = true;
            this.btnShowFrame.Click += new System.EventHandler(this.btnShowFrame_Click);
            // 
            // btnOpenFrame
            // 
            this.btnOpenFrame.Location = new System.Drawing.Point(34, 23);
            this.btnOpenFrame.Name = "btnOpenFrame";
            this.btnOpenFrame.Size = new System.Drawing.Size(91, 23);
            this.btnOpenFrame.TabIndex = 0;
            this.btnOpenFrame.Text = "Open";
            this.btnOpenFrame.UseVisualStyleBackColor = true;
            this.btnOpenFrame.Click += new System.EventHandler(this.btnOpenFrame_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvGridResult);
            this.groupBox2.Location = new System.Drawing.Point(8, 354);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 346);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // lvGridResult
            // 
            this.lvGridResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvGridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGridResult.GridLines = true;
            this.lvGridResult.HideSelection = false;
            this.lvGridResult.Location = new System.Drawing.Point(3, 17);
            this.lvGridResult.Name = "lvGridResult";
            this.lvGridResult.Size = new System.Drawing.Size(422, 326);
            this.lvGridResult.TabIndex = 6;
            this.lvGridResult.UseCompatibleStateImageBehavior = false;
            this.lvGridResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Grid ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Axis";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Label";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Offset";
            // 
            // tpView
            // 
            this.tpView.Controls.Add(this.groupBox16);
            this.tpView.Controls.Add(this.groupBox14);
            this.tpView.Controls.Add(this.groupBox9);
            this.tpView.Controls.Add(this.groupBox8);
            this.tpView.Location = new System.Drawing.Point(4, 22);
            this.tpView.Name = "tpView";
            this.tpView.Padding = new System.Windows.Forms.Padding(3);
            this.tpView.Size = new System.Drawing.Size(442, 708);
            this.tpView.TabIndex = 4;
            this.tpView.Text = "View";
            this.tpView.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.label20);
            this.groupBox16.Controls.Add(this.label19);
            this.groupBox16.Controls.Add(this.label16);
            this.groupBox16.Controls.Add(this.txtViewBounboxMaxZ);
            this.groupBox16.Controls.Add(this.label17);
            this.groupBox16.Controls.Add(this.txtViewBounboxMaxY);
            this.groupBox16.Controls.Add(this.label18);
            this.groupBox16.Controls.Add(this.txtViewBounboxMaxX);
            this.groupBox16.Controls.Add(this.btnViewBoxZoom);
            this.groupBox16.Controls.Add(this.label13);
            this.groupBox16.Controls.Add(this.txtViewBounboxMinZ);
            this.groupBox16.Controls.Add(this.label14);
            this.groupBox16.Controls.Add(this.txtViewBounboxMinY);
            this.groupBox16.Controls.Add(this.label15);
            this.groupBox16.Controls.Add(this.txtViewBounboxMinX);
            this.groupBox16.Controls.Add(this.btnViewGetBoundBox);
            this.groupBox16.Location = new System.Drawing.Point(6, 559);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(430, 141);
            this.groupBox16.TabIndex = 16;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Box Zoom";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 12);
            this.label13.TabIndex = 23;
            this.label13.Text = "Z :";
            // 
            // txtViewBounboxMinZ
            // 
            this.txtViewBounboxMinZ.Location = new System.Drawing.Point(42, 101);
            this.txtViewBounboxMinZ.Name = "txtViewBounboxMinZ";
            this.txtViewBounboxMinZ.Size = new System.Drawing.Size(107, 21);
            this.txtViewBounboxMinZ.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 12);
            this.label14.TabIndex = 21;
            this.label14.Text = "Y :";
            // 
            // txtViewBounboxMinY
            // 
            this.txtViewBounboxMinY.Location = new System.Drawing.Point(42, 74);
            this.txtViewBounboxMinY.Name = "txtViewBounboxMinY";
            this.txtViewBounboxMinY.Size = new System.Drawing.Size(107, 21);
            this.txtViewBounboxMinY.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 12);
            this.label15.TabIndex = 19;
            this.label15.Text = "X :";
            // 
            // txtViewBounboxMinX
            // 
            this.txtViewBounboxMinX.Location = new System.Drawing.Point(42, 45);
            this.txtViewBounboxMinX.Name = "txtViewBounboxMinX";
            this.txtViewBounboxMinX.Size = new System.Drawing.Size(107, 21);
            this.txtViewBounboxMinX.TabIndex = 18;
            // 
            // btnViewGetBoundBox
            // 
            this.btnViewGetBoundBox.Location = new System.Drawing.Point(309, 45);
            this.btnViewGetBoundBox.Name = "btnViewGetBoundBox";
            this.btnViewGetBoundBox.Size = new System.Drawing.Size(110, 23);
            this.btnViewGetBoundBox.TabIndex = 7;
            this.btnViewGetBoundBox.Text = "Get BoundBox";
            this.btnViewGetBoundBox.UseVisualStyleBackColor = true;
            this.btnViewGetBoundBox.Click += new System.EventHandler(this.btnViewGetBoundBox_Click);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.numZoomRatio);
            this.groupBox14.Controls.Add(this.label5);
            this.groupBox14.Controls.Add(this.ckEnableSelectionMouseRButtonUp);
            this.groupBox14.Controls.Add(this.ckEnableSelection);
            this.groupBox14.Controls.Add(this.ckEnableParentSelection);
            this.groupBox14.Controls.Add(this.ckEnableDoubleClickFocusAndFit);
            this.groupBox14.Location = new System.Drawing.Point(6, 431);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(430, 122);
            this.groupBox14.TabIndex = 15;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Option";
            // 
            // numZoomRatio
            // 
            this.numZoomRatio.Location = new System.Drawing.Point(106, 88);
            this.numZoomRatio.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numZoomRatio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numZoomRatio.Name = "numZoomRatio";
            this.numZoomRatio.Size = new System.Drawing.Size(120, 21);
            this.numZoomRatio.TabIndex = 5;
            this.numZoomRatio.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numZoomRatio.ValueChanged += new System.EventHandler(this.numZoomRatio_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Zoom Ratio : ";
            // 
            // ckEnableSelectionMouseRButtonUp
            // 
            this.ckEnableSelectionMouseRButtonUp.AutoSize = true;
            this.ckEnableSelectionMouseRButtonUp.Checked = true;
            this.ckEnableSelectionMouseRButtonUp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckEnableSelectionMouseRButtonUp.Location = new System.Drawing.Point(195, 59);
            this.ckEnableSelectionMouseRButtonUp.Name = "ckEnableSelectionMouseRButtonUp";
            this.ckEnableSelectionMouseRButtonUp.Size = new System.Drawing.Size(224, 16);
            this.ckEnableSelectionMouseRButtonUp.TabIndex = 3;
            this.ckEnableSelectionMouseRButtonUp.Text = "Enable Selection MouseRButton Up";
            this.ckEnableSelectionMouseRButtonUp.UseVisualStyleBackColor = true;
            this.ckEnableSelectionMouseRButtonUp.CheckedChanged += new System.EventHandler(this.ckEnableSelectionMouseRButtonUp_CheckedChanged);
            // 
            // ckEnableSelection
            // 
            this.ckEnableSelection.AutoSize = true;
            this.ckEnableSelection.Checked = true;
            this.ckEnableSelection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckEnableSelection.Location = new System.Drawing.Point(20, 59);
            this.ckEnableSelection.Name = "ckEnableSelection";
            this.ckEnableSelection.Size = new System.Drawing.Size(119, 16);
            this.ckEnableSelection.TabIndex = 2;
            this.ckEnableSelection.Text = "Enable Selection";
            this.ckEnableSelection.UseVisualStyleBackColor = true;
            this.ckEnableSelection.CheckedChanged += new System.EventHandler(this.ckEnableSelection_CheckedChanged);
            // 
            // ckEnableParentSelection
            // 
            this.ckEnableParentSelection.AutoSize = true;
            this.ckEnableParentSelection.Checked = true;
            this.ckEnableParentSelection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckEnableParentSelection.Location = new System.Drawing.Point(20, 30);
            this.ckEnableParentSelection.Name = "ckEnableParentSelection";
            this.ckEnableParentSelection.Size = new System.Drawing.Size(155, 16);
            this.ckEnableParentSelection.TabIndex = 1;
            this.ckEnableParentSelection.Text = "Enable ParentSelection";
            this.ckEnableParentSelection.UseVisualStyleBackColor = true;
            this.ckEnableParentSelection.CheckedChanged += new System.EventHandler(this.ckEnableParentSelection_CheckedChanged);
            // 
            // ckEnableDoubleClickFocusAndFit
            // 
            this.ckEnableDoubleClickFocusAndFit.Location = new System.Drawing.Point(195, 30);
            this.ckEnableDoubleClickFocusAndFit.Name = "ckEnableDoubleClickFocusAndFit";
            this.ckEnableDoubleClickFocusAndFit.Size = new System.Drawing.Size(216, 16);
            this.ckEnableDoubleClickFocusAndFit.TabIndex = 0;
            this.ckEnableDoubleClickFocusAndFit.Text = "Enable DoubleClick Focus And Fit";
            this.ckEnableDoubleClickFocusAndFit.UseVisualStyleBackColor = true;
            this.ckEnableDoubleClickFocusAndFit.CheckedChanged += new System.EventHandler(this.ckEnableDoubleClickFocusAndFit_CheckedChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnSetColor);
            this.groupBox9.Controls.Add(this.txtColorObjects);
            this.groupBox9.Controls.Add(this.btnRestoreAlpha);
            this.groupBox9.Controls.Add(this.btnRestoreColor);
            this.groupBox9.Controls.Add(this.txtAlphaObjects);
            this.groupBox9.Controls.Add(this.btnSetAlpha);
            this.groupBox9.Location = new System.Drawing.Point(6, 254);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(430, 171);
            this.groupBox9.TabIndex = 14;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Color";
            // 
            // btnSetColor
            // 
            this.btnSetColor.Location = new System.Drawing.Point(34, 34);
            this.btnSetColor.Name = "btnSetColor";
            this.btnSetColor.Size = new System.Drawing.Size(150, 23);
            this.btnSetColor.TabIndex = 6;
            this.btnSetColor.Text = "Set Color";
            this.btnSetColor.UseVisualStyleBackColor = true;
            this.btnSetColor.Click += new System.EventHandler(this.btnSetColor_Click);
            // 
            // txtColorObjects
            // 
            this.txtColorObjects.Location = new System.Drawing.Point(34, 63);
            this.txtColorObjects.Name = "txtColorObjects";
            this.txtColorObjects.Size = new System.Drawing.Size(150, 21);
            this.txtColorObjects.TabIndex = 8;
            // 
            // btnRestoreAlpha
            // 
            this.btnRestoreAlpha.Location = new System.Drawing.Point(240, 104);
            this.btnRestoreAlpha.Name = "btnRestoreAlpha";
            this.btnRestoreAlpha.Size = new System.Drawing.Size(150, 23);
            this.btnRestoreAlpha.TabIndex = 12;
            this.btnRestoreAlpha.Text = "Restore Alpha";
            this.btnRestoreAlpha.UseVisualStyleBackColor = true;
            this.btnRestoreAlpha.Click += new System.EventHandler(this.btnRestoreAlpha_Click);
            // 
            // btnRestoreColor
            // 
            this.btnRestoreColor.Location = new System.Drawing.Point(240, 34);
            this.btnRestoreColor.Name = "btnRestoreColor";
            this.btnRestoreColor.Size = new System.Drawing.Size(150, 23);
            this.btnRestoreColor.TabIndex = 9;
            this.btnRestoreColor.Text = "Restore Color";
            this.btnRestoreColor.UseVisualStyleBackColor = true;
            this.btnRestoreColor.Click += new System.EventHandler(this.btnRestoreColor_Click);
            // 
            // txtAlphaObjects
            // 
            this.txtAlphaObjects.Location = new System.Drawing.Point(34, 133);
            this.txtAlphaObjects.Name = "txtAlphaObjects";
            this.txtAlphaObjects.Size = new System.Drawing.Size(150, 21);
            this.txtAlphaObjects.TabIndex = 11;
            // 
            // btnSetAlpha
            // 
            this.btnSetAlpha.Location = new System.Drawing.Point(34, 104);
            this.btnSetAlpha.Name = "btnSetAlpha";
            this.btnSetAlpha.Size = new System.Drawing.Size(150, 23);
            this.btnSetAlpha.TabIndex = 10;
            this.btnSetAlpha.Text = "Set Alpha";
            this.btnSetAlpha.UseVisualStyleBackColor = true;
            this.btnSetAlpha.Click += new System.EventHandler(this.btnSetAlpha_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnXrayClearObjects);
            this.groupBox8.Controls.Add(this.btnXrayEnable);
            this.groupBox8.Controls.Add(this.btnXrayDisable);
            this.groupBox8.Controls.Add(this.btnXrayColor1);
            this.groupBox8.Controls.Add(this.btnXrayColor2);
            this.groupBox8.Controls.Add(this.btnXraySelectObjects);
            this.groupBox8.Controls.Add(this.txtXrayObjects);
            this.groupBox8.Location = new System.Drawing.Point(6, 16);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(430, 217);
            this.groupBox8.TabIndex = 13;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Xray";
            // 
            // btnXrayClearObjects
            // 
            this.btnXrayClearObjects.Location = new System.Drawing.Point(240, 138);
            this.btnXrayClearObjects.Name = "btnXrayClearObjects";
            this.btnXrayClearObjects.Size = new System.Drawing.Size(150, 23);
            this.btnXrayClearObjects.TabIndex = 5;
            this.btnXrayClearObjects.Text = "Xray - Clear";
            this.btnXrayClearObjects.UseVisualStyleBackColor = true;
            this.btnXrayClearObjects.Click += new System.EventHandler(this.btnXrayClearObjects_Click);
            // 
            // btnXrayEnable
            // 
            this.btnXrayEnable.Location = new System.Drawing.Point(34, 32);
            this.btnXrayEnable.Name = "btnXrayEnable";
            this.btnXrayEnable.Size = new System.Drawing.Size(150, 23);
            this.btnXrayEnable.TabIndex = 0;
            this.btnXrayEnable.Text = "Xray - Enable";
            this.btnXrayEnable.UseVisualStyleBackColor = true;
            this.btnXrayEnable.Click += new System.EventHandler(this.btnXrayEnable_Click);
            // 
            // btnXrayDisable
            // 
            this.btnXrayDisable.Location = new System.Drawing.Point(240, 32);
            this.btnXrayDisable.Name = "btnXrayDisable";
            this.btnXrayDisable.Size = new System.Drawing.Size(150, 23);
            this.btnXrayDisable.TabIndex = 1;
            this.btnXrayDisable.Text = "Xray - Disable";
            this.btnXrayDisable.UseVisualStyleBackColor = true;
            this.btnXrayDisable.Click += new System.EventHandler(this.btnXrayDisable_Click);
            // 
            // btnXrayColor1
            // 
            this.btnXrayColor1.Location = new System.Drawing.Point(34, 80);
            this.btnXrayColor1.Name = "btnXrayColor1";
            this.btnXrayColor1.Size = new System.Drawing.Size(150, 23);
            this.btnXrayColor1.TabIndex = 2;
            this.btnXrayColor1.Text = "Xray - SelectionColor";
            this.btnXrayColor1.UseVisualStyleBackColor = true;
            this.btnXrayColor1.Click += new System.EventHandler(this.btnXrayColor1_Click);
            // 
            // btnXrayColor2
            // 
            this.btnXrayColor2.Location = new System.Drawing.Point(240, 80);
            this.btnXrayColor2.Name = "btnXrayColor2";
            this.btnXrayColor2.Size = new System.Drawing.Size(150, 23);
            this.btnXrayColor2.TabIndex = 3;
            this.btnXrayColor2.Text = "Xray - Original Color";
            this.btnXrayColor2.UseVisualStyleBackColor = true;
            this.btnXrayColor2.Click += new System.EventHandler(this.btnXrayColor2_Click);
            // 
            // btnXraySelectObjects
            // 
            this.btnXraySelectObjects.Location = new System.Drawing.Point(34, 138);
            this.btnXraySelectObjects.Name = "btnXraySelectObjects";
            this.btnXraySelectObjects.Size = new System.Drawing.Size(150, 23);
            this.btnXraySelectObjects.TabIndex = 4;
            this.btnXraySelectObjects.Text = "Xray - Objects";
            this.btnXraySelectObjects.UseVisualStyleBackColor = true;
            this.btnXraySelectObjects.Click += new System.EventHandler(this.btnXraySelectObjects_Click);
            // 
            // txtXrayObjects
            // 
            this.txtXrayObjects.Location = new System.Drawing.Point(34, 165);
            this.txtXrayObjects.Name = "txtXrayObjects";
            this.txtXrayObjects.Size = new System.Drawing.Size(150, 21);
            this.txtXrayObjects.TabIndex = 7;
            // 
            // tpUDA
            // 
            this.tpUDA.Controls.Add(this.groupBox10);
            this.tpUDA.Controls.Add(this.groupBox1);
            this.tpUDA.Location = new System.Drawing.Point(4, 22);
            this.tpUDA.Name = "tpUDA";
            this.tpUDA.Padding = new System.Windows.Forms.Padding(3);
            this.tpUDA.Size = new System.Drawing.Size(442, 708);
            this.tpUDA.TabIndex = 5;
            this.tpUDA.Text = "UDA";
            this.tpUDA.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label2);
            this.groupBox10.Controls.Add(this.label1);
            this.groupBox10.Controls.Add(this.btnUDAInfo);
            this.groupBox10.Controls.Add(this.txtUDA1);
            this.groupBox10.Controls.Add(this.txtUDAValue1);
            this.groupBox10.Controls.Add(this.btnUDAKeys);
            this.groupBox10.Controls.Add(this.txtUDAKey1);
            this.groupBox10.Controls.Add(this.txtUDAKey);
            this.groupBox10.Controls.Add(this.btnUDANodes);
            this.groupBox10.Controls.Add(this.btnUDAValues);
            this.groupBox10.Location = new System.Drawing.Point(8, 7);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(425, 244);
            this.groupBox10.TabIndex = 13;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "UDA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "Value :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "Key :";
            // 
            // btnUDAInfo
            // 
            this.btnUDAInfo.Location = new System.Drawing.Point(189, 32);
            this.btnUDAInfo.Name = "btnUDAInfo";
            this.btnUDAInfo.Size = new System.Drawing.Size(210, 23);
            this.btnUDAInfo.TabIndex = 4;
            this.btnUDAInfo.Text = "지정된 노드의 속성 목록";
            this.btnUDAInfo.UseVisualStyleBackColor = true;
            this.btnUDAInfo.Click += new System.EventHandler(this.btnUDAInfo_Click);
            // 
            // txtUDA1
            // 
            this.txtUDA1.Location = new System.Drawing.Point(20, 34);
            this.txtUDA1.Name = "txtUDA1";
            this.txtUDA1.Size = new System.Drawing.Size(137, 21);
            this.txtUDA1.TabIndex = 5;
            // 
            // txtUDAValue1
            // 
            this.txtUDAValue1.Location = new System.Drawing.Point(63, 203);
            this.txtUDAValue1.Name = "txtUDAValue1";
            this.txtUDAValue1.Size = new System.Drawing.Size(94, 21);
            this.txtUDAValue1.TabIndex = 11;
            // 
            // btnUDAKeys
            // 
            this.btnUDAKeys.Location = new System.Drawing.Point(189, 80);
            this.btnUDAKeys.Name = "btnUDAKeys";
            this.btnUDAKeys.Size = new System.Drawing.Size(210, 23);
            this.btnUDAKeys.TabIndex = 6;
            this.btnUDAKeys.Text = "전체 키 목록";
            this.btnUDAKeys.UseVisualStyleBackColor = true;
            this.btnUDAKeys.Click += new System.EventHandler(this.btnUDAKeys_Click);
            // 
            // txtUDAKey1
            // 
            this.txtUDAKey1.Location = new System.Drawing.Point(63, 176);
            this.txtUDAKey1.Name = "txtUDAKey1";
            this.txtUDAKey1.Size = new System.Drawing.Size(94, 21);
            this.txtUDAKey1.TabIndex = 10;
            // 
            // txtUDAKey
            // 
            this.txtUDAKey.Location = new System.Drawing.Point(20, 128);
            this.txtUDAKey.Name = "txtUDAKey";
            this.txtUDAKey.Size = new System.Drawing.Size(137, 21);
            this.txtUDAKey.TabIndex = 8;
            // 
            // btnUDANodes
            // 
            this.btnUDANodes.Location = new System.Drawing.Point(189, 201);
            this.btnUDANodes.Name = "btnUDANodes";
            this.btnUDANodes.Size = new System.Drawing.Size(210, 23);
            this.btnUDANodes.TabIndex = 9;
            this.btnUDANodes.Text = "특정 키와 값의 노드 목록";
            this.btnUDANodes.UseVisualStyleBackColor = true;
            this.btnUDANodes.Click += new System.EventHandler(this.btnUDANodes_Click);
            // 
            // btnUDAValues
            // 
            this.btnUDAValues.Location = new System.Drawing.Point(189, 128);
            this.btnUDAValues.Name = "btnUDAValues";
            this.btnUDAValues.Size = new System.Drawing.Size(210, 23);
            this.btnUDAValues.TabIndex = 7;
            this.btnUDAValues.Text = "특정 키의 값 목록";
            this.btnUDAValues.UseVisualStyleBackColor = true;
            this.btnUDAValues.Click += new System.EventHandler(this.btnUDAValues_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvUDAResult);
            this.groupBox1.Location = new System.Drawing.Point(8, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 443);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // lvUDAResult
            // 
            this.lvUDAResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lvUDAResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvUDAResult.GridLines = true;
            this.lvUDAResult.HideSelection = false;
            this.lvUDAResult.Location = new System.Drawing.Point(3, 17);
            this.lvUDAResult.Name = "lvUDAResult";
            this.lvUDAResult.Size = new System.Drawing.Size(422, 423);
            this.lvUDAResult.TabIndex = 12;
            this.lvUDAResult.UseCompatibleStateImageBehavior = false;
            this.lvUDAResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Key";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Value";
            // 
            // tpNote
            // 
            this.tpNote.Controls.Add(this.groupBox13);
            this.tpNote.Location = new System.Drawing.Point(4, 22);
            this.tpNote.Name = "tpNote";
            this.tpNote.Padding = new System.Windows.Forms.Padding(3);
            this.tpNote.Size = new System.Drawing.Size(442, 708);
            this.tpNote.TabIndex = 6;
            this.tpNote.Text = "Note";
            this.tpNote.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.label4);
            this.groupBox13.Controls.Add(this.numNoteBoxStrokeAlpha);
            this.groupBox13.Controls.Add(this.btnNoteBoxStrokeColor);
            this.groupBox13.Controls.Add(this.ckNoteBackgroundTransparent);
            this.groupBox13.Controls.Add(this.btnNoteBoxFillColor);
            this.groupBox13.Controls.Add(this.label3);
            this.groupBox13.Controls.Add(this.numNoteBoxFillAlpha);
            this.groupBox13.Location = new System.Drawing.Point(6, 6);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(430, 133);
            this.groupBox13.TabIndex = 0;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Color";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Box Stroke 투명도 :";
            // 
            // numNoteBoxStrokeAlpha
            // 
            this.numNoteBoxStrokeAlpha.Location = new System.Drawing.Point(290, 59);
            this.numNoteBoxStrokeAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numNoteBoxStrokeAlpha.Name = "numNoteBoxStrokeAlpha";
            this.numNoteBoxStrokeAlpha.Size = new System.Drawing.Size(102, 21);
            this.numNoteBoxStrokeAlpha.TabIndex = 5;
            // 
            // btnNoteBoxStrokeColor
            // 
            this.btnNoteBoxStrokeColor.Location = new System.Drawing.Point(22, 56);
            this.btnNoteBoxStrokeColor.Name = "btnNoteBoxStrokeColor";
            this.btnNoteBoxStrokeColor.Size = new System.Drawing.Size(75, 23);
            this.btnNoteBoxStrokeColor.TabIndex = 4;
            this.btnNoteBoxStrokeColor.Text = "Color";
            this.btnNoteBoxStrokeColor.UseVisualStyleBackColor = true;
            this.btnNoteBoxStrokeColor.Click += new System.EventHandler(this.btnNoteBoxStrokeColor_Click);
            // 
            // ckNoteBackgroundTransparent
            // 
            this.ckNoteBackgroundTransparent.AutoSize = true;
            this.ckNoteBackgroundTransparent.Location = new System.Drawing.Point(22, 97);
            this.ckNoteBackgroundTransparent.Name = "ckNoteBackgroundTransparent";
            this.ckNoteBackgroundTransparent.Size = new System.Drawing.Size(88, 16);
            this.ckNoteBackgroundTransparent.TabIndex = 3;
            this.ckNoteBackgroundTransparent.Text = "배경색 없음";
            this.ckNoteBackgroundTransparent.UseVisualStyleBackColor = true;
            this.ckNoteBackgroundTransparent.CheckedChanged += new System.EventHandler(this.ckNoteBackgroundTransparent_CheckedChanged);
            // 
            // btnNoteBoxFillColor
            // 
            this.btnNoteBoxFillColor.Location = new System.Drawing.Point(22, 27);
            this.btnNoteBoxFillColor.Name = "btnNoteBoxFillColor";
            this.btnNoteBoxFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnNoteBoxFillColor.TabIndex = 2;
            this.btnNoteBoxFillColor.Text = "Color";
            this.btnNoteBoxFillColor.UseVisualStyleBackColor = true;
            this.btnNoteBoxFillColor.Click += new System.EventHandler(this.btnNoteBoxFillColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Box Fill 투명도 :";
            // 
            // numNoteBoxFillAlpha
            // 
            this.numNoteBoxFillAlpha.Location = new System.Drawing.Point(290, 23);
            this.numNoteBoxFillAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numNoteBoxFillAlpha.Name = "numNoteBoxFillAlpha";
            this.numNoteBoxFillAlpha.Size = new System.Drawing.Size(102, 21);
            this.numNoteBoxFillAlpha.TabIndex = 0;
            // 
            // tpModelTree
            // 
            this.tpModelTree.Controls.Add(this.groupBox15);
            this.tpModelTree.Location = new System.Drawing.Point(4, 22);
            this.tpModelTree.Name = "tpModelTree";
            this.tpModelTree.Padding = new System.Windows.Forms.Padding(3);
            this.tpModelTree.Size = new System.Drawing.Size(442, 708);
            this.tpModelTree.TabIndex = 7;
            this.tpModelTree.Text = "ModelTree";
            this.tpModelTree.UseVisualStyleBackColor = true;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.btnModelTreeFocus);
            this.groupBox15.Controls.Add(this.label12);
            this.groupBox15.Controls.Add(this.txtModelTreeIndex);
            this.groupBox15.Location = new System.Drawing.Point(6, 6);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(430, 100);
            this.groupBox15.TabIndex = 0;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "ModelTree";
            // 
            // btnModelTreeFocus
            // 
            this.btnModelTreeFocus.Location = new System.Drawing.Point(286, 40);
            this.btnModelTreeFocus.Name = "btnModelTreeFocus";
            this.btnModelTreeFocus.Size = new System.Drawing.Size(83, 23);
            this.btnModelTreeFocus.TabIndex = 2;
            this.btnModelTreeFocus.Text = "Focus";
            this.btnModelTreeFocus.UseVisualStyleBackColor = true;
            this.btnModelTreeFocus.Click += new System.EventHandler(this.btnModelTreeFocus_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(59, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "Index :";
            // 
            // txtModelTreeIndex
            // 
            this.txtModelTreeIndex.Location = new System.Drawing.Point(109, 40);
            this.txtModelTreeIndex.Name = "txtModelTreeIndex";
            this.txtModelTreeIndex.Size = new System.Drawing.Size(171, 21);
            this.txtModelTreeIndex.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgView);
            this.splitContainer2.Size = new System.Drawing.Size(897, 734);
            this.splitContainer2.SplitterDistance = 539;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgView.Location = new System.Drawing.Point(0, 0);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.RowTemplate.Height = 23;
            this.dgView.Size = new System.Drawing.Size(897, 191);
            this.dgView.TabIndex = 0;
            // 
            // btnViewBoxZoom
            // 
            this.btnViewBoxZoom.Location = new System.Drawing.Point(309, 101);
            this.btnViewBoxZoom.Name = "btnViewBoxZoom";
            this.btnViewBoxZoom.Size = new System.Drawing.Size(110, 23);
            this.btnViewBoxZoom.TabIndex = 24;
            this.btnViewBoxZoom.Text = "Box Zoom";
            this.btnViewBoxZoom.UseVisualStyleBackColor = true;
            this.btnViewBoxZoom.Click += new System.EventHandler(this.btnViewBoxZoom_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(155, 104);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 12);
            this.label16.TabIndex = 30;
            this.label16.Text = "Z :";
            // 
            // txtViewBounboxMaxZ
            // 
            this.txtViewBounboxMaxZ.Location = new System.Drawing.Point(182, 101);
            this.txtViewBounboxMaxZ.Name = "txtViewBounboxMaxZ";
            this.txtViewBounboxMaxZ.Size = new System.Drawing.Size(107, 21);
            this.txtViewBounboxMaxZ.TabIndex = 29;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(155, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 12);
            this.label17.TabIndex = 28;
            this.label17.Text = "Y :";
            // 
            // txtViewBounboxMaxY
            // 
            this.txtViewBounboxMaxY.Location = new System.Drawing.Point(182, 74);
            this.txtViewBounboxMaxY.Name = "txtViewBounboxMaxY";
            this.txtViewBounboxMaxY.Size = new System.Drawing.Size(107, 21);
            this.txtViewBounboxMaxY.TabIndex = 27;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(155, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 12);
            this.label18.TabIndex = 26;
            this.label18.Text = "X :";
            // 
            // txtViewBounboxMaxX
            // 
            this.txtViewBounboxMaxX.Location = new System.Drawing.Point(182, 45);
            this.txtViewBounboxMaxX.Name = "txtViewBounboxMaxX";
            this.txtViewBounboxMaxX.Size = new System.Drawing.Size(107, 21);
            this.txtViewBounboxMaxX.TabIndex = 25;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(81, 27);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(28, 12);
            this.label19.TabIndex = 31;
            this.label19.Text = "MIN";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(217, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 12);
            this.label20.TabIndex = 32;
            this.label20.Text = "MAX";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 734);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.Demo";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tpModel.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tpObjects.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tpSection.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tpFrame.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tpView.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZoomRatio)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tpUDA.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tpNote.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNoteBoxStrokeAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNoteBoxFillAlpha)).EndInit();
            this.tpModelTree.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpModel;
        private System.Windows.Forms.TabPage tpObjects;
        private System.Windows.Forms.Button btnCloseModel;
        private System.Windows.Forms.Button btnAddModels;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.TabPage tpSection;
        private System.Windows.Forms.TabPage tpFrame;
        private System.Windows.Forms.TabPage tpView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Button btnAllObjects;
        private System.Windows.Forms.Button btnSelectedAllObjects;
        private System.Windows.Forms.Button btnSelectedTopObjects;
        private System.Windows.Forms.Button btnAddSectionBox;
        private System.Windows.Forms.Button btnClearSection;
        private System.Windows.Forms.Button btnOpenFrame;
        private System.Windows.Forms.Button btnHideFrame;
        private System.Windows.Forms.Button btnShowFrame;
        private System.Windows.Forms.Button btnGetGridItemsZ;
        private System.Windows.Forms.Button btnGetGridItemsY;
        private System.Windows.Forms.Button btnGetGridItemsX;
        private System.Windows.Forms.Button btnModelBoundBox;
        private System.Windows.Forms.Button btnUpdateSectionBoxSize;
        private System.Windows.Forms.Button btnXrayDisable;
        private System.Windows.Forms.Button btnXrayEnable;
        private System.Windows.Forms.Button btnXrayColor1;
        private System.Windows.Forms.Button btnXrayColor2;
        private System.Windows.Forms.Button btnXrayClearObjects;
        private System.Windows.Forms.Button btnXraySelectObjects;
        private System.Windows.Forms.TextBox txtXrayObjects;
        private System.Windows.Forms.Button btnSetColor;
        private System.Windows.Forms.Button btnRestoreColor;
        private System.Windows.Forms.TextBox txtColorObjects;
        private System.Windows.Forms.Button btnRestoreAlpha;
        private System.Windows.Forms.TextBox txtAlphaObjects;
        private System.Windows.Forms.Button btnSetAlpha;
        private System.Windows.Forms.TabPage tpUDA;
        private System.Windows.Forms.Button btnUDAInfo;
        private System.Windows.Forms.TextBox txtUDA1;
        private System.Windows.Forms.Button btnUDAKeys;
        private System.Windows.Forms.TextBox txtUDAKey;
        private System.Windows.Forms.Button btnUDAValues;
        private System.Windows.Forms.TextBox txtUDAValue1;
        private System.Windows.Forms.TextBox txtUDAKey1;
        private System.Windows.Forms.Button btnUDANodes;
        private System.Windows.Forms.ListView lvGridResult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvUDAResult;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnGridColor;
        private System.Windows.Forms.Button btnGridShowNum;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.CheckBox ckGridLabelZ;
        private System.Windows.Forms.CheckBox ckGridLabelY;
        private System.Windows.Forms.CheckBox ckGridLabelX;
        private System.Windows.Forms.Button btnGridHideNum;
        private System.Windows.Forms.TabPage tpNote;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button btnNoteBoxFillColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numNoteBoxFillAlpha;
        private System.Windows.Forms.CheckBox ckNoteBackgroundTransparent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numNoteBoxStrokeAlpha;
        private System.Windows.Forms.Button btnNoteBoxStrokeColor;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.CheckBox ckEnableSelectionMouseRButtonUp;
        private System.Windows.Forms.CheckBox ckEnableSelection;
        private System.Windows.Forms.CheckBox ckEnableParentSelection;
        private System.Windows.Forms.CheckBox ckEnableDoubleClickFocusAndFit;
        private System.Windows.Forms.NumericUpDown numZoomRatio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ckShowHandle;
        private System.Windows.Forms.Button btnSetCenter;
        private System.Windows.Forms.Button btnGetCenter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSectionSubID;
        private System.Windows.Forms.ComboBox cbSectionID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSectionZ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSectionY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSectionX;
        private System.Windows.Forms.TextBox txtCenterPosition;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tpModelTree;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Button btnModelTreeFocus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtModelTreeIndex;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtViewBounboxMinZ;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtViewBounboxMinY;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtViewBounboxMinX;
        private System.Windows.Forms.Button btnViewGetBoundBox;
        private System.Windows.Forms.Button btnViewBoxZoom;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtViewBounboxMaxZ;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtViewBounboxMaxY;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtViewBounboxMaxX;
    }
}

