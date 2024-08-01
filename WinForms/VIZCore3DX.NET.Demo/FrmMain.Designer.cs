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
            this.btnAddSectionBox = new System.Windows.Forms.Button();
            this.btnUpdateSectionBoxSize = new System.Windows.Forms.Button();
            this.btnClearSection = new System.Windows.Forms.Button();
            this.tpFrame = new System.Windows.Forms.TabPage();
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgView = new System.Windows.Forms.DataGridView();
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
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tpView.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tpUDA.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.groupBox4.Location = new System.Drawing.Point(8, 138);
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
            this.groupBox6.Controls.Add(this.btnAddSectionBox);
            this.groupBox6.Controls.Add(this.btnUpdateSectionBoxSize);
            this.groupBox6.Controls.Add(this.btnClearSection);
            this.groupBox6.Location = new System.Drawing.Point(6, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(430, 123);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Section";
            // 
            // btnAddSectionBox
            // 
            this.btnAddSectionBox.Location = new System.Drawing.Point(38, 34);
            this.btnAddSectionBox.Name = "btnAddSectionBox";
            this.btnAddSectionBox.Size = new System.Drawing.Size(129, 23);
            this.btnAddSectionBox.TabIndex = 0;
            this.btnAddSectionBox.Text = "Add SectionBox";
            this.btnAddSectionBox.UseVisualStyleBackColor = true;
            this.btnAddSectionBox.Click += new System.EventHandler(this.btnAddSectionBox_Click);
            // 
            // btnUpdateSectionBoxSize
            // 
            this.btnUpdateSectionBoxSize.Location = new System.Drawing.Point(38, 76);
            this.btnUpdateSectionBoxSize.Name = "btnUpdateSectionBoxSize";
            this.btnUpdateSectionBoxSize.Size = new System.Drawing.Size(129, 23);
            this.btnUpdateSectionBoxSize.TabIndex = 4;
            this.btnUpdateSectionBoxSize.Text = "BoxSize";
            this.btnUpdateSectionBoxSize.UseVisualStyleBackColor = true;
            this.btnUpdateSectionBoxSize.Click += new System.EventHandler(this.btnUpdateSectionBoxSize_Click);
            // 
            // btnClearSection
            // 
            this.btnClearSection.Location = new System.Drawing.Point(244, 34);
            this.btnClearSection.Name = "btnClearSection";
            this.btnClearSection.Size = new System.Drawing.Size(129, 23);
            this.btnClearSection.TabIndex = 1;
            this.btnClearSection.Text = "Clear";
            this.btnClearSection.UseVisualStyleBackColor = true;
            this.btnClearSection.Click += new System.EventHandler(this.btnClearSection_Click);
            // 
            // tpFrame
            // 
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
            this.groupBox7.Size = new System.Drawing.Size(428, 163);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Grid";
            // 
            // btnGetGridItemsZ
            // 
            this.btnGetGridItemsZ.Location = new System.Drawing.Point(205, 113);
            this.btnGetGridItemsZ.Name = "btnGetGridItemsZ";
            this.btnGetGridItemsZ.Size = new System.Drawing.Size(168, 23);
            this.btnGetGridItemsZ.TabIndex = 5;
            this.btnGetGridItemsZ.Text = "Z - GridItems";
            this.btnGetGridItemsZ.UseVisualStyleBackColor = true;
            this.btnGetGridItemsZ.Click += new System.EventHandler(this.btnGetGridItemsZ_Click);
            // 
            // btnGetGridItemsX
            // 
            this.btnGetGridItemsX.Location = new System.Drawing.Point(205, 33);
            this.btnGetGridItemsX.Name = "btnGetGridItemsX";
            this.btnGetGridItemsX.Size = new System.Drawing.Size(168, 23);
            this.btnGetGridItemsX.TabIndex = 3;
            this.btnGetGridItemsX.Text = "X - GridItems";
            this.btnGetGridItemsX.UseVisualStyleBackColor = true;
            this.btnGetGridItemsX.Click += new System.EventHandler(this.btnGetGridItemsX_Click);
            // 
            // btnHideFrame
            // 
            this.btnHideFrame.Location = new System.Drawing.Point(38, 113);
            this.btnHideFrame.Name = "btnHideFrame";
            this.btnHideFrame.Size = new System.Drawing.Size(91, 23);
            this.btnHideFrame.TabIndex = 2;
            this.btnHideFrame.Text = "Hide";
            this.btnHideFrame.UseVisualStyleBackColor = true;
            this.btnHideFrame.Click += new System.EventHandler(this.btnHideFrame_Click);
            // 
            // btnGetGridItemsY
            // 
            this.btnGetGridItemsY.Location = new System.Drawing.Point(205, 73);
            this.btnGetGridItemsY.Name = "btnGetGridItemsY";
            this.btnGetGridItemsY.Size = new System.Drawing.Size(168, 23);
            this.btnGetGridItemsY.TabIndex = 4;
            this.btnGetGridItemsY.Text = "Y - GridItems";
            this.btnGetGridItemsY.UseVisualStyleBackColor = true;
            this.btnGetGridItemsY.Click += new System.EventHandler(this.btnGetGridItemsY_Click);
            // 
            // btnShowFrame
            // 
            this.btnShowFrame.Location = new System.Drawing.Point(38, 73);
            this.btnShowFrame.Name = "btnShowFrame";
            this.btnShowFrame.Size = new System.Drawing.Size(91, 23);
            this.btnShowFrame.TabIndex = 1;
            this.btnShowFrame.Text = "Show";
            this.btnShowFrame.UseVisualStyleBackColor = true;
            this.btnShowFrame.Click += new System.EventHandler(this.btnShowFrame_Click);
            // 
            // btnOpenFrame
            // 
            this.btnOpenFrame.Location = new System.Drawing.Point(38, 33);
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
            this.groupBox2.Location = new System.Drawing.Point(8, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 527);
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
            this.lvGridResult.Size = new System.Drawing.Size(422, 507);
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
            this.groupBox9.Size = new System.Drawing.Size(430, 215);
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
            this.btnRestoreAlpha.Location = new System.Drawing.Point(240, 133);
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
            this.txtAlphaObjects.Location = new System.Drawing.Point(34, 162);
            this.txtAlphaObjects.Name = "txtAlphaObjects";
            this.txtAlphaObjects.Size = new System.Drawing.Size(150, 21);
            this.txtAlphaObjects.TabIndex = 11;
            // 
            // btnSetAlpha
            // 
            this.btnSetAlpha.Location = new System.Drawing.Point(34, 133);
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
            this.tpFrame.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tpView.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tpUDA.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
    }
}

