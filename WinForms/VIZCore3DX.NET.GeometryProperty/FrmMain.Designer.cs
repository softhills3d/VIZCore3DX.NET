namespace VIZCore3DX.NET.GeometryProperty
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSelected = new System.Windows.Forms.TabPage();
            this.splitContainerProperty = new System.Windows.Forms.SplitContainer();
            this.grpReturnType = new System.Windows.Forms.GroupBox();
            this.rdoGetMeshGeometry = new System.Windows.Forms.RadioButton();
            this.rdoGetGeometry = new System.Windows.Forms.RadioButton();
            this.rdoGetCenterOfVolume = new System.Windows.Forms.RadioButton();
            this.rdoGetVolume = new System.Windows.Forms.RadioButton();
            this.rdoGetSurfaceArea = new System.Windows.Forms.RadioButton();
            this.rdoFromSelectedObject3D = new System.Windows.Forms.RadioButton();
            this.geometryPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.tabPageShape = new System.Windows.Forms.TabPage();
            this.lvShapeGroup = new System.Windows.Forms.ListView();
            this.colShapeCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShapeTriangle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShapeVolume = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShapeArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShapeSignature = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblShapeInfo = new System.Windows.Forms.Label();
            this.pnlShapeTop = new System.Windows.Forms.Panel();
            this.btnShapeStatistics = new System.Windows.Forms.Button();
            this.chkShapeSelectedOnly = new System.Windows.Forms.CheckBox();
            this.tabPageRanking = new System.Windows.Forms.TabPage();
            this.lvRanking = new System.Windows.Forms.ListView();
            this.colRank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRankName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRankValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRankIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblRankInfo = new System.Windows.Forms.Label();
            this.pnlRankTop = new System.Windows.Forms.Panel();
            this.lblRankMetric = new System.Windows.Forms.Label();
            this.cmbRankMetric = new System.Windows.Forms.ComboBox();
            this.lblRankTopN = new System.Windows.Forms.Label();
            this.numRankTopN = new System.Windows.Forms.NumericUpDown();
            this.chkDescending = new System.Windows.Forms.CheckBox();
            this.chkRankSelectedOnly = new System.Windows.Forms.CheckBox();
            this.btnRanking = new System.Windows.Forms.Button();
            this.tabPageAxis = new System.Windows.Forms.TabPage();
            this.lvAxisBand = new System.Windows.Forms.ListView();
            this.colBand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBandFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBandTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBandCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAxisInfo = new System.Windows.Forms.Label();
            this.pnlAxisTop = new System.Windows.Forms.Panel();
            this.lblAxis = new System.Windows.Forms.Label();
            this.cmbAxis = new System.Windows.Forms.ComboBox();
            this.lblBandCount = new System.Windows.Forms.Label();
            this.numBandCount = new System.Windows.Forms.NumericUpDown();
            this.chkAxisVisibleOnly = new System.Windows.Forms.CheckBox();
            this.btnAxisDistribution = new System.Windows.Forms.Button();
            this.tabPageDefault = new System.Windows.Forms.TabPage();
            this.groupDefaultProperty = new System.Windows.Forms.GroupBox();
            this.chkKindColor = new System.Windows.Forms.CheckBox();
            this.chkKindSurfaceArea = new System.Windows.Forms.CheckBox();
            this.chkKindVolume = new System.Windows.Forms.CheckBox();
            this.chkKindCenterOfVolume = new System.Windows.Forms.CheckBox();
            this.chkKindTriangleCount = new System.Windows.Forms.CheckBox();
            this.chkDefaultSelectedOnly = new System.Windows.Forms.CheckBox();
            this.btnLoadDefaultProperties = new System.Windows.Forms.Button();
            this.lblDefaultInfo = new System.Windows.Forms.Label();
            this.lvDefaultResult = new System.Windows.Forms.ListView();
            this.colDefName = new System.Windows.Forms.ColumnHeader();
            this.colDefColor = new System.Windows.Forms.ColumnHeader();
            this.colDefVolume = new System.Windows.Forms.ColumnHeader();
            this.colDefArea = new System.Windows.Forms.ColumnHeader();
            this.colDefCenter = new System.Windows.Forms.ColumnHeader();
            this.colDefTriangle = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageSelected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerProperty)).BeginInit();
            this.splitContainerProperty.Panel1.SuspendLayout();
            this.splitContainerProperty.Panel2.SuspendLayout();
            this.splitContainerProperty.SuspendLayout();
            this.grpReturnType.SuspendLayout();
            this.tabPageShape.SuspendLayout();
            this.pnlShapeTop.SuspendLayout();
            this.tabPageRanking.SuspendLayout();
            this.pnlRankTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRankTopN)).BeginInit();
            this.tabPageAxis.SuspendLayout();
            this.pnlAxisTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBandCount)).BeginInit();
            this.tabPageDefault.SuspendLayout();
            this.groupDefaultProperty.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(1280, 760);
            this.splitContainer1.SplitterDistance = 876;
            this.splitContainer1.TabIndex = 0;

            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSelected);
            this.tabControl1.Controls.Add(this.tabPageShape);
            this.tabControl1.Controls.Add(this.tabPageRanking);
            this.tabControl1.Controls.Add(this.tabPageAxis);
            this.tabControl1.Controls.Add(this.tabPageDefault);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(400, 760);
            this.tabControl1.TabIndex = 0;

            // 
            // tabPageSelected
            // 
            this.tabPageSelected.Controls.Add(this.splitContainerProperty);
            this.tabPageSelected.Location = new System.Drawing.Point(4, 22);
            this.tabPageSelected.Name = "tabPageSelected";
            this.tabPageSelected.Size = new System.Drawing.Size(392, 734);
            this.tabPageSelected.TabIndex = 0;
            this.tabPageSelected.Text = "선택 개체";
            this.tabPageSelected.UseVisualStyleBackColor = true;

            // 
            // splitContainerProperty
            // 
            this.splitContainerProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerProperty.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerProperty.Location = new System.Drawing.Point(0, 0);
            this.splitContainerProperty.Name = "splitContainerProperty";
            this.splitContainerProperty.Orientation = System.Windows.Forms.Orientation.Horizontal;

            // 
            // splitContainerProperty.Panel1
            // 
            this.splitContainerProperty.Panel1.Controls.Add(this.grpReturnType);

            // 
            // splitContainerProperty.Panel2
            // 
            this.splitContainerProperty.Panel2.Controls.Add(this.geometryPropertyGrid);
            this.splitContainerProperty.Size = new System.Drawing.Size(392, 734);
            this.splitContainerProperty.SplitterDistance = 125;
            this.splitContainerProperty.TabIndex = 0;

            // 
            // grpReturnType
            // 
            this.grpReturnType.Controls.Add(this.rdoGetMeshGeometry);
            this.grpReturnType.Controls.Add(this.rdoGetGeometry);
            this.grpReturnType.Controls.Add(this.rdoGetCenterOfVolume);
            this.grpReturnType.Controls.Add(this.rdoGetVolume);
            this.grpReturnType.Controls.Add(this.rdoGetSurfaceArea);
            this.grpReturnType.Controls.Add(this.rdoFromSelectedObject3D);
            this.grpReturnType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReturnType.Location = new System.Drawing.Point(0, 0);
            this.grpReturnType.Name = "grpReturnType";
            this.grpReturnType.Padding = new System.Windows.Forms.Padding(8);
            this.grpReturnType.Size = new System.Drawing.Size(392, 125);
            this.grpReturnType.TabIndex = 0;
            this.grpReturnType.TabStop = false;
            this.grpReturnType.Text = "Geometry Property";

            // 
            // rdoFromSelectedObject3D
            // 
            this.rdoFromSelectedObject3D.AutoSize = true;
            this.rdoFromSelectedObject3D.Checked = true;
            this.rdoFromSelectedObject3D.Location = new System.Drawing.Point(12, 22);
            this.rdoFromSelectedObject3D.Name = "rdoFromSelectedObject3D";
            this.rdoFromSelectedObject3D.Size = new System.Drawing.Size(154, 16);
            this.rdoFromSelectedObject3D.TabIndex = 0;
            this.rdoFromSelectedObject3D.TabStop = true;
            this.rdoFromSelectedObject3D.Text = "FromSelectedObject3D";
            this.rdoFromSelectedObject3D.UseVisualStyleBackColor = true;
            this.rdoFromSelectedObject3D.CheckedChanged += new System.EventHandler(this.GeometryReturnType_CheckedChanged);

            // 
            // rdoGetSurfaceArea
            // 
            this.rdoGetSurfaceArea.AutoSize = true;
            this.rdoGetSurfaceArea.Location = new System.Drawing.Point(12, 46);
            this.rdoGetSurfaceArea.Name = "rdoGetSurfaceArea";
            this.rdoGetSurfaceArea.Size = new System.Drawing.Size(111, 16);
            this.rdoGetSurfaceArea.TabIndex = 1;
            this.rdoGetSurfaceArea.Text = "GetSurfaceArea";
            this.rdoGetSurfaceArea.UseVisualStyleBackColor = true;
            this.rdoGetSurfaceArea.CheckedChanged += new System.EventHandler(this.GeometryReturnType_CheckedChanged);

            // 
            // rdoGetVolume
            // 
            this.rdoGetVolume.AutoSize = true;
            this.rdoGetVolume.Location = new System.Drawing.Point(143, 46);
            this.rdoGetVolume.Name = "rdoGetVolume";
            this.rdoGetVolume.Size = new System.Drawing.Size(84, 16);
            this.rdoGetVolume.TabIndex = 2;
            this.rdoGetVolume.Text = "GetVolume";
            this.rdoGetVolume.UseVisualStyleBackColor = true;
            this.rdoGetVolume.CheckedChanged += new System.EventHandler(this.GeometryReturnType_CheckedChanged);

            // 
            // rdoGetCenterOfVolume
            // 
            this.rdoGetCenterOfVolume.AutoSize = true;
            this.rdoGetCenterOfVolume.Location = new System.Drawing.Point(12, 70);
            this.rdoGetCenterOfVolume.Name = "rdoGetCenterOfVolume";
            this.rdoGetCenterOfVolume.Size = new System.Drawing.Size(133, 16);
            this.rdoGetCenterOfVolume.TabIndex = 3;
            this.rdoGetCenterOfVolume.Text = "GetCenterOfVolume";
            this.rdoGetCenterOfVolume.UseVisualStyleBackColor = true;
            this.rdoGetCenterOfVolume.CheckedChanged += new System.EventHandler(this.GeometryReturnType_CheckedChanged);

            // 
            // rdoGetGeometry
            // 
            this.rdoGetGeometry.AutoSize = true;
            this.rdoGetGeometry.Location = new System.Drawing.Point(12, 94);
            this.rdoGetGeometry.Name = "rdoGetGeometry";
            this.rdoGetGeometry.Size = new System.Drawing.Size(94, 16);
            this.rdoGetGeometry.TabIndex = 4;
            this.rdoGetGeometry.Text = "GetGeometry";
            this.rdoGetGeometry.UseVisualStyleBackColor = true;
            this.rdoGetGeometry.CheckedChanged += new System.EventHandler(this.GeometryReturnType_CheckedChanged);

            // 
            // rdoGetMeshGeometry
            // 
            this.rdoGetMeshGeometry.AutoSize = true;
            this.rdoGetMeshGeometry.Location = new System.Drawing.Point(143, 94);
            this.rdoGetMeshGeometry.Name = "rdoGetMeshGeometry";
            this.rdoGetMeshGeometry.Size = new System.Drawing.Size(124, 16);
            this.rdoGetMeshGeometry.TabIndex = 5;
            this.rdoGetMeshGeometry.Text = "GetMeshGeometry";
            this.rdoGetMeshGeometry.UseVisualStyleBackColor = true;
            this.rdoGetMeshGeometry.CheckedChanged += new System.EventHandler(this.GeometryReturnType_CheckedChanged);

            // 
            // geometryPropertyGrid
            // 
            this.geometryPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geometryPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.geometryPropertyGrid.Name = "geometryPropertyGrid";
            this.geometryPropertyGrid.Size = new System.Drawing.Size(392, 605);
            this.geometryPropertyGrid.TabIndex = 0;

            // 
            // tabPageShape
            // 
            this.tabPageShape.Controls.Add(this.lvShapeGroup);
            this.tabPageShape.Controls.Add(this.lblShapeInfo);
            this.tabPageShape.Controls.Add(this.pnlShapeTop);
            this.tabPageShape.Location = new System.Drawing.Point(4, 22);
            this.tabPageShape.Name = "tabPageShape";
            this.tabPageShape.Size = new System.Drawing.Size(392, 734);
            this.tabPageShape.TabIndex = 1;
            this.tabPageShape.Text = "동일 형상";
            this.tabPageShape.UseVisualStyleBackColor = true;

            // 
            // pnlShapeTop
            // 
            this.pnlShapeTop.Controls.Add(this.btnShapeStatistics);
            this.pnlShapeTop.Controls.Add(this.chkShapeSelectedOnly);
            this.pnlShapeTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlShapeTop.Location = new System.Drawing.Point(0, 0);
            this.pnlShapeTop.Name = "pnlShapeTop";
            this.pnlShapeTop.Size = new System.Drawing.Size(392, 40);
            this.pnlShapeTop.TabIndex = 0;

            // 
            // btnShapeStatistics
            // 
            this.btnShapeStatistics.Location = new System.Drawing.Point(6, 6);
            this.btnShapeStatistics.Name = "btnShapeStatistics";
            this.btnShapeStatistics.Size = new System.Drawing.Size(120, 28);
            this.btnShapeStatistics.TabIndex = 0;
            this.btnShapeStatistics.Text = "형상 통계 조회";
            this.btnShapeStatistics.UseVisualStyleBackColor = true;
            this.btnShapeStatistics.Click += new System.EventHandler(this.btnShapeStatistics_Click);

            // 
            // chkShapeSelectedOnly
            // 
            this.chkShapeSelectedOnly.AutoSize = true;
            this.chkShapeSelectedOnly.Location = new System.Drawing.Point(134, 12);
            this.chkShapeSelectedOnly.Name = "chkShapeSelectedOnly";
            this.chkShapeSelectedOnly.Size = new System.Drawing.Size(88, 16);
            this.chkShapeSelectedOnly.TabIndex = 1;
            this.chkShapeSelectedOnly.Text = "선택 개체만";
            this.chkShapeSelectedOnly.UseVisualStyleBackColor = true;

            // 
            // lvShapeGroup
            // 
            this.lvShapeGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colShapeCount,
            this.colShapeTriangle,
            this.colShapeVolume,
            this.colShapeArea,
            this.colShapeSignature});
            this.lvShapeGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShapeGroup.FullRowSelect = true;
            this.lvShapeGroup.GridLines = true;
            this.lvShapeGroup.HideSelection = false;
            this.lvShapeGroup.Location = new System.Drawing.Point(0, 40);
            this.lvShapeGroup.MultiSelect = false;
            this.lvShapeGroup.Name = "lvShapeGroup";
            this.lvShapeGroup.Size = new System.Drawing.Size(392, 672);
            this.lvShapeGroup.TabIndex = 1;
            this.lvShapeGroup.UseCompatibleStateImageBehavior = false;
            this.lvShapeGroup.View = System.Windows.Forms.View.Details;
            this.lvShapeGroup.DoubleClick += new System.EventHandler(this.lvShapeGroup_DoubleClick);

            // 
            // colShapeCount
            // 
            this.colShapeCount.Text = "개수";
            this.colShapeCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colShapeCount.Width = 50;

            // 
            // colShapeTriangle
            // 
            this.colShapeTriangle.Text = "삼각형 수";
            this.colShapeTriangle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colShapeTriangle.Width = 75;

            // 
            // colShapeVolume
            // 
            this.colShapeVolume.Text = "부피";
            this.colShapeVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colShapeVolume.Width = 75;

            // 
            // colShapeArea
            // 
            this.colShapeArea.Text = "표면적";
            this.colShapeArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colShapeArea.Width = 75;

            // 
            // colShapeSignature
            // 
            this.colShapeSignature.Text = "Signature";
            this.colShapeSignature.Width = 150;

            // 
            // lblShapeInfo
            // 
            this.lblShapeInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblShapeInfo.Location = new System.Drawing.Point(0, 712);
            this.lblShapeInfo.Name = "lblShapeInfo";
            this.lblShapeInfo.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblShapeInfo.Size = new System.Drawing.Size(392, 22);
            this.lblShapeInfo.TabIndex = 2;
            this.lblShapeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // tabPageRanking
            // 
            this.tabPageRanking.Controls.Add(this.lvRanking);
            this.tabPageRanking.Controls.Add(this.lblRankInfo);
            this.tabPageRanking.Controls.Add(this.pnlRankTop);
            this.tabPageRanking.Location = new System.Drawing.Point(4, 22);
            this.tabPageRanking.Name = "tabPageRanking";
            this.tabPageRanking.Size = new System.Drawing.Size(392, 734);
            this.tabPageRanking.TabIndex = 2;
            this.tabPageRanking.Text = "순위";
            this.tabPageRanking.UseVisualStyleBackColor = true;

            // 
            // pnlRankTop
            // 
            this.pnlRankTop.Controls.Add(this.lblRankMetric);
            this.pnlRankTop.Controls.Add(this.cmbRankMetric);
            this.pnlRankTop.Controls.Add(this.lblRankTopN);
            this.pnlRankTop.Controls.Add(this.numRankTopN);
            this.pnlRankTop.Controls.Add(this.chkDescending);
            this.pnlRankTop.Controls.Add(this.chkRankSelectedOnly);
            this.pnlRankTop.Controls.Add(this.btnRanking);
            this.pnlRankTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRankTop.Location = new System.Drawing.Point(0, 0);
            this.pnlRankTop.Name = "pnlRankTop";
            this.pnlRankTop.Size = new System.Drawing.Size(392, 100);
            this.pnlRankTop.TabIndex = 0;

            // 
            // lblRankMetric
            // 
            this.lblRankMetric.AutoSize = true;
            this.lblRankMetric.Location = new System.Drawing.Point(8, 12);
            this.lblRankMetric.Name = "lblRankMetric";
            this.lblRankMetric.Size = new System.Drawing.Size(29, 12);
            this.lblRankMetric.TabIndex = 0;
            this.lblRankMetric.Text = "지표";

            // 
            // cmbRankMetric
            // 
            this.cmbRankMetric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRankMetric.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRankMetric.FormattingEnabled = true;
            this.cmbRankMetric.Location = new System.Drawing.Point(50, 8);
            this.cmbRankMetric.Name = "cmbRankMetric";
            this.cmbRankMetric.Size = new System.Drawing.Size(334, 20);
            this.cmbRankMetric.TabIndex = 1;

            // 
            // lblRankTopN
            // 
            this.lblRankTopN.AutoSize = true;
            this.lblRankTopN.Location = new System.Drawing.Point(8, 40);
            this.lblRankTopN.Name = "lblRankTopN";
            this.lblRankTopN.Size = new System.Drawing.Size(41, 12);
            this.lblRankTopN.TabIndex = 2;
            this.lblRankTopN.Text = "상위 N";

            // 
            // numRankTopN
            // 
            this.numRankTopN.Location = new System.Drawing.Point(50, 36);
            this.numRankTopN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRankTopN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRankTopN.Name = "numRankTopN";
            this.numRankTopN.Size = new System.Drawing.Size(60, 21);
            this.numRankTopN.TabIndex = 3;
            this.numRankTopN.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});

            // 
            // chkDescending
            // 
            this.chkDescending.AutoSize = true;
            this.chkDescending.Checked = true;
            this.chkDescending.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDescending.Location = new System.Drawing.Point(122, 38);
            this.chkDescending.Name = "chkDescending";
            this.chkDescending.Size = new System.Drawing.Size(72, 16);
            this.chkDescending.TabIndex = 4;
            this.chkDescending.Text = "내림차순";
            this.chkDescending.UseVisualStyleBackColor = true;

            // 
            // chkRankSelectedOnly
            // 
            this.chkRankSelectedOnly.AutoSize = true;
            this.chkRankSelectedOnly.Location = new System.Drawing.Point(10, 70);
            this.chkRankSelectedOnly.Name = "chkRankSelectedOnly";
            this.chkRankSelectedOnly.Size = new System.Drawing.Size(88, 16);
            this.chkRankSelectedOnly.TabIndex = 5;
            this.chkRankSelectedOnly.Text = "선택 개체만";
            this.chkRankSelectedOnly.UseVisualStyleBackColor = true;

            // 
            // btnRanking
            // 
            this.btnRanking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRanking.Location = new System.Drawing.Point(284, 64);
            this.btnRanking.Name = "btnRanking";
            this.btnRanking.Size = new System.Drawing.Size(100, 28);
            this.btnRanking.TabIndex = 6;
            this.btnRanking.Text = "순위 조회";
            this.btnRanking.UseVisualStyleBackColor = true;
            this.btnRanking.Click += new System.EventHandler(this.btnRanking_Click);

            // 
            // lvRanking
            // 
            this.lvRanking.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRank,
            this.colRankName,
            this.colRankValue,
            this.colRankIndex});
            this.lvRanking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRanking.FullRowSelect = true;
            this.lvRanking.GridLines = true;
            this.lvRanking.HideSelection = false;
            this.lvRanking.Location = new System.Drawing.Point(0, 100);
            this.lvRanking.MultiSelect = false;
            this.lvRanking.Name = "lvRanking";
            this.lvRanking.Size = new System.Drawing.Size(392, 612);
            this.lvRanking.TabIndex = 1;
            this.lvRanking.UseCompatibleStateImageBehavior = false;
            this.lvRanking.View = System.Windows.Forms.View.Details;
            this.lvRanking.DoubleClick += new System.EventHandler(this.lvRanking_DoubleClick);

            // 
            // colRank
            // 
            this.colRank.Text = "순위";
            this.colRank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRank.Width = 45;

            // 
            // colRankName
            // 
            this.colRankName.Text = "Name";
            this.colRankName.Width = 150;

            // 
            // colRankValue
            // 
            this.colRankValue.Text = "값";
            this.colRankValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRankValue.Width = 90;

            // 
            // colRankIndex
            // 
            this.colRankIndex.Text = "IDX";
            this.colRankIndex.Width = 60;

            // 
            // lblRankInfo
            // 
            this.lblRankInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblRankInfo.Location = new System.Drawing.Point(0, 712);
            this.lblRankInfo.Name = "lblRankInfo";
            this.lblRankInfo.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblRankInfo.Size = new System.Drawing.Size(392, 22);
            this.lblRankInfo.TabIndex = 2;
            this.lblRankInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // tabPageAxis
            // 
            this.tabPageAxis.Controls.Add(this.lvAxisBand);
            this.tabPageAxis.Controls.Add(this.lblAxisInfo);
            this.tabPageAxis.Controls.Add(this.pnlAxisTop);
            this.tabPageAxis.Location = new System.Drawing.Point(4, 22);
            this.tabPageAxis.Name = "tabPageAxis";
            this.tabPageAxis.Size = new System.Drawing.Size(392, 734);
            this.tabPageAxis.TabIndex = 3;
            this.tabPageAxis.Text = "축 분포";
            this.tabPageAxis.UseVisualStyleBackColor = true;

            // 
            // pnlAxisTop
            // 
            this.pnlAxisTop.Controls.Add(this.lblAxis);
            this.pnlAxisTop.Controls.Add(this.cmbAxis);
            this.pnlAxisTop.Controls.Add(this.lblBandCount);
            this.pnlAxisTop.Controls.Add(this.numBandCount);
            this.pnlAxisTop.Controls.Add(this.chkAxisVisibleOnly);
            this.pnlAxisTop.Controls.Add(this.btnAxisDistribution);
            this.pnlAxisTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAxisTop.Location = new System.Drawing.Point(0, 0);
            this.pnlAxisTop.Name = "pnlAxisTop";
            this.pnlAxisTop.Size = new System.Drawing.Size(392, 72);
            this.pnlAxisTop.TabIndex = 0;

            // 
            // lblAxis
            // 
            this.lblAxis.AutoSize = true;
            this.lblAxis.Location = new System.Drawing.Point(8, 12);
            this.lblAxis.Name = "lblAxis";
            this.lblAxis.Size = new System.Drawing.Size(17, 12);
            this.lblAxis.TabIndex = 0;
            this.lblAxis.Text = "축";

            // 
            // cmbAxis
            // 
            this.cmbAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAxis.FormattingEnabled = true;
            this.cmbAxis.Location = new System.Drawing.Point(50, 8);
            this.cmbAxis.Name = "cmbAxis";
            this.cmbAxis.Size = new System.Drawing.Size(80, 20);
            this.cmbAxis.TabIndex = 1;

            // 
            // lblBandCount
            // 
            this.lblBandCount.AutoSize = true;
            this.lblBandCount.Location = new System.Drawing.Point(142, 12);
            this.lblBandCount.Name = "lblBandCount";
            this.lblBandCount.Size = new System.Drawing.Size(45, 12);
            this.lblBandCount.TabIndex = 2;
            this.lblBandCount.Text = "구간 수";

            // 
            // numBandCount
            // 
            this.numBandCount.Location = new System.Drawing.Point(196, 8);
            this.numBandCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBandCount.Name = "numBandCount";
            this.numBandCount.Size = new System.Drawing.Size(60, 21);
            this.numBandCount.TabIndex = 3;
            this.numBandCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});

            // 
            // chkAxisVisibleOnly
            // 
            this.chkAxisVisibleOnly.AutoSize = true;
            this.chkAxisVisibleOnly.Location = new System.Drawing.Point(10, 42);
            this.chkAxisVisibleOnly.Name = "chkAxisVisibleOnly";
            this.chkAxisVisibleOnly.Size = new System.Drawing.Size(100, 16);
            this.chkAxisVisibleOnly.TabIndex = 4;
            this.chkAxisVisibleOnly.Text = "보이는 개체만";
            this.chkAxisVisibleOnly.UseVisualStyleBackColor = true;

            // 
            // btnAxisDistribution
            // 
            this.btnAxisDistribution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAxisDistribution.Location = new System.Drawing.Point(284, 36);
            this.btnAxisDistribution.Name = "btnAxisDistribution";
            this.btnAxisDistribution.Size = new System.Drawing.Size(100, 28);
            this.btnAxisDistribution.TabIndex = 5;
            this.btnAxisDistribution.Text = "분포 조회";
            this.btnAxisDistribution.UseVisualStyleBackColor = true;
            this.btnAxisDistribution.Click += new System.EventHandler(this.btnAxisDistribution_Click);

            // 
            // lvAxisBand
            // 
            this.lvAxisBand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBand,
            this.colBandFrom,
            this.colBandTo,
            this.colBandCount});
            this.lvAxisBand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAxisBand.FullRowSelect = true;
            this.lvAxisBand.GridLines = true;
            this.lvAxisBand.HideSelection = false;
            this.lvAxisBand.Location = new System.Drawing.Point(0, 72);
            this.lvAxisBand.Name = "lvAxisBand";
            this.lvAxisBand.Size = new System.Drawing.Size(392, 640);
            this.lvAxisBand.TabIndex = 1;
            this.lvAxisBand.UseCompatibleStateImageBehavior = false;
            this.lvAxisBand.View = System.Windows.Forms.View.Details;

            // 
            // colBand
            // 
            this.colBand.Text = "구간";
            this.colBand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colBand.Width = 45;

            // 
            // colBandFrom
            // 
            this.colBandFrom.Text = "From";
            this.colBandFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colBandFrom.Width = 100;

            // 
            // colBandTo
            // 
            this.colBandTo.Text = "To";
            this.colBandTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colBandTo.Width = 100;

            // 
            // colBandCount
            // 
            this.colBandCount.Text = "노드 수";
            this.colBandCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colBandCount.Width = 70;

            // 
            // lblAxisInfo
            // 
            this.lblAxisInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAxisInfo.Location = new System.Drawing.Point(0, 712);
            this.lblAxisInfo.Name = "lblAxisInfo";
            this.lblAxisInfo.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblAxisInfo.Size = new System.Drawing.Size(392, 22);
            this.lblAxisInfo.TabIndex = 2;
            this.lblAxisInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // tabPageDefault
            // 
            this.tabPageDefault.Controls.Add(this.lvDefaultResult);
            this.tabPageDefault.Controls.Add(this.lblDefaultInfo);
            this.tabPageDefault.Controls.Add(this.groupDefaultProperty);
            this.tabPageDefault.Location = new System.Drawing.Point(4, 22);
            this.tabPageDefault.Name = "tabPageDefault";
            this.tabPageDefault.Size = new System.Drawing.Size(392, 734);
            this.tabPageDefault.TabIndex = 4;
            this.tabPageDefault.Text = "기본 특성 로드";
            this.tabPageDefault.UseVisualStyleBackColor = true;

            // 
            // groupDefaultProperty
            // 
            this.groupDefaultProperty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDefaultProperty.Controls.Add(this.chkKindColor);
            this.groupDefaultProperty.Controls.Add(this.chkKindSurfaceArea);
            this.groupDefaultProperty.Controls.Add(this.chkKindVolume);
            this.groupDefaultProperty.Controls.Add(this.chkKindCenterOfVolume);
            this.groupDefaultProperty.Controls.Add(this.chkKindTriangleCount);
            this.groupDefaultProperty.Controls.Add(this.chkDefaultSelectedOnly);
            this.groupDefaultProperty.Controls.Add(this.btnLoadDefaultProperties);
            this.groupDefaultProperty.Location = new System.Drawing.Point(6, 6);
            this.groupDefaultProperty.Name = "groupDefaultProperty";
            this.groupDefaultProperty.Size = new System.Drawing.Size(380, 174);
            this.groupDefaultProperty.TabIndex = 0;
            this.groupDefaultProperty.TabStop = false;
            this.groupDefaultProperty.Text = "LoadNodeDefaultProperties";

            // 
            // chkKindColor
            // 
            this.chkKindColor.AutoSize = true;
            this.chkKindColor.Location = new System.Drawing.Point(12, 22);
            this.chkKindColor.Name = "chkKindColor";
            this.chkKindColor.Size = new System.Drawing.Size(92, 16);
            this.chkKindColor.TabIndex = 0;
            this.chkKindColor.Text = "색상 (Color)";
            this.chkKindColor.UseVisualStyleBackColor = true;

            // 
            // chkKindSurfaceArea
            // 
            this.chkKindSurfaceArea.AutoSize = true;
            this.chkKindSurfaceArea.Checked = true;
            this.chkKindSurfaceArea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKindSurfaceArea.Location = new System.Drawing.Point(12, 44);
            this.chkKindSurfaceArea.Name = "chkKindSurfaceArea";
            this.chkKindSurfaceArea.Size = new System.Drawing.Size(140, 16);
            this.chkKindSurfaceArea.TabIndex = 1;
            this.chkKindSurfaceArea.Text = "표면적 (SurfaceArea)";
            this.chkKindSurfaceArea.UseVisualStyleBackColor = true;

            // 
            // chkKindVolume
            // 
            this.chkKindVolume.AutoSize = true;
            this.chkKindVolume.Checked = true;
            this.chkKindVolume.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKindVolume.Location = new System.Drawing.Point(12, 66);
            this.chkKindVolume.Name = "chkKindVolume";
            this.chkKindVolume.Size = new System.Drawing.Size(104, 16);
            this.chkKindVolume.TabIndex = 2;
            this.chkKindVolume.Text = "부피 (Volume)";
            this.chkKindVolume.UseVisualStyleBackColor = true;

            // 
            // chkKindCenterOfVolume
            // 
            this.chkKindCenterOfVolume.AutoSize = true;
            this.chkKindCenterOfVolume.Location = new System.Drawing.Point(12, 88);
            this.chkKindCenterOfVolume.Name = "chkKindCenterOfVolume";
            this.chkKindCenterOfVolume.Size = new System.Drawing.Size(172, 16);
            this.chkKindCenterOfVolume.TabIndex = 3;
            this.chkKindCenterOfVolume.Text = "부피 중심 (CenterOfVolume)";
            this.chkKindCenterOfVolume.UseVisualStyleBackColor = true;

            // 
            // chkKindTriangleCount
            // 
            this.chkKindTriangleCount.AutoSize = true;
            this.chkKindTriangleCount.Location = new System.Drawing.Point(12, 110);
            this.chkKindTriangleCount.Name = "chkKindTriangleCount";
            this.chkKindTriangleCount.Size = new System.Drawing.Size(164, 16);
            this.chkKindTriangleCount.TabIndex = 4;
            this.chkKindTriangleCount.Text = "삼각형 수 (TriangleCount)";
            this.chkKindTriangleCount.UseVisualStyleBackColor = true;

            // 
            // chkDefaultSelectedOnly
            // 
            this.chkDefaultSelectedOnly.AutoSize = true;
            this.chkDefaultSelectedOnly.Location = new System.Drawing.Point(12, 142);
            this.chkDefaultSelectedOnly.Name = "chkDefaultSelectedOnly";
            this.chkDefaultSelectedOnly.Size = new System.Drawing.Size(88, 16);
            this.chkDefaultSelectedOnly.TabIndex = 5;
            this.chkDefaultSelectedOnly.Text = "선택 개체만";
            this.chkDefaultSelectedOnly.UseVisualStyleBackColor = true;

            // 
            // btnLoadDefaultProperties
            // 
            this.btnLoadDefaultProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadDefaultProperties.Location = new System.Drawing.Point(270, 136);
            this.btnLoadDefaultProperties.Name = "btnLoadDefaultProperties";
            this.btnLoadDefaultProperties.Size = new System.Drawing.Size(100, 28);
            this.btnLoadDefaultProperties.TabIndex = 6;
            this.btnLoadDefaultProperties.Text = "특성 로드";
            this.btnLoadDefaultProperties.UseVisualStyleBackColor = true;
            this.btnLoadDefaultProperties.Click += new System.EventHandler(this.btnLoadDefaultProperties_Click);

            // 
            // lvDefaultResult
            // 
            this.lvDefaultResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDefaultResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDefName,
            this.colDefColor,
            this.colDefArea,
            this.colDefVolume,
            this.colDefCenter,
            this.colDefTriangle});
            this.lvDefaultResult.FullRowSelect = true;
            this.lvDefaultResult.GridLines = true;
            this.lvDefaultResult.HideSelection = false;
            this.lvDefaultResult.Location = new System.Drawing.Point(6, 234);
            this.lvDefaultResult.Name = "lvDefaultResult";
            this.lvDefaultResult.Size = new System.Drawing.Size(380, 494);
            this.lvDefaultResult.TabIndex = 2;
            this.lvDefaultResult.UseCompatibleStateImageBehavior = false;
            this.lvDefaultResult.View = System.Windows.Forms.View.Details;
            // 
            // colDefName
            // 
            this.colDefName.Text = "Node";
            this.colDefName.Width = 110;
            // 
            // colDefColor
            // 
            this.colDefColor.Text = "Color";
            this.colDefColor.Width = 80;
            // 
            // colDefVolume
            // 
            this.colDefVolume.Text = "Volume";
            this.colDefVolume.Width = 70;
            // 
            // colDefArea
            // 
            this.colDefArea.Text = "Surface Area";
            this.colDefArea.Width = 70;
            // 
            // colDefCenter
            // 
            this.colDefCenter.Text = "Volume Center";
            this.colDefCenter.Width = 90;
            // 
            // colDefTriangle
            // 
            this.colDefTriangle.Text = "Triangles";
            this.colDefTriangle.Width = 60;
            // 
            // lblDefaultInfo
            // 
            this.lblDefaultInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDefaultInfo.Location = new System.Drawing.Point(8, 188);
            this.lblDefaultInfo.Name = "lblDefaultInfo";
            this.lblDefaultInfo.Size = new System.Drawing.Size(378, 40);
            this.lblDefaultInfo.TabIndex = 1;
            this.lblDefaultInfo.Text = "필요한 특성 종류만 지정하여 노드 기본 특성을 로드합니다.";

            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.GeometryProperty";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageSelected.ResumeLayout(false);
            this.splitContainerProperty.Panel1.ResumeLayout(false);
            this.splitContainerProperty.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerProperty)).EndInit();
            this.splitContainerProperty.ResumeLayout(false);
            this.grpReturnType.ResumeLayout(false);
            this.grpReturnType.PerformLayout();
            this.tabPageShape.ResumeLayout(false);
            this.pnlShapeTop.ResumeLayout(false);
            this.pnlShapeTop.PerformLayout();
            this.tabPageRanking.ResumeLayout(false);
            this.pnlRankTop.ResumeLayout(false);
            this.pnlRankTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRankTopN)).EndInit();
            this.tabPageAxis.ResumeLayout(false);
            this.pnlAxisTop.ResumeLayout(false);
            this.pnlAxisTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBandCount)).EndInit();
            this.tabPageDefault.ResumeLayout(false);
            this.groupDefaultProperty.ResumeLayout(false);
            this.groupDefaultProperty.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSelected;

        // 우측 영역을 조회 방식 / 결과 영역으로 분할
        private System.Windows.Forms.SplitContainer splitContainerProperty;
        private System.Windows.Forms.GroupBox grpReturnType;
        private System.Windows.Forms.RadioButton rdoFromSelectedObject3D;
        private System.Windows.Forms.RadioButton rdoGetSurfaceArea;
        private System.Windows.Forms.RadioButton rdoGetVolume;
        private System.Windows.Forms.RadioButton rdoGetCenterOfVolume;
        private System.Windows.Forms.RadioButton rdoGetGeometry;
        private System.Windows.Forms.RadioButton rdoGetMeshGeometry;

        private System.Windows.Forms.PropertyGrid geometryPropertyGrid;

        // 동일 형상 통계
        private System.Windows.Forms.TabPage tabPageShape;
        private System.Windows.Forms.Panel pnlShapeTop;
        private System.Windows.Forms.Button btnShapeStatistics;
        private System.Windows.Forms.CheckBox chkShapeSelectedOnly;
        private System.Windows.Forms.ListView lvShapeGroup;
        private System.Windows.Forms.ColumnHeader colShapeCount;
        private System.Windows.Forms.ColumnHeader colShapeTriangle;
        private System.Windows.Forms.ColumnHeader colShapeVolume;
        private System.Windows.Forms.ColumnHeader colShapeArea;
        private System.Windows.Forms.ColumnHeader colShapeSignature;
        private System.Windows.Forms.Label lblShapeInfo;

        // 기하 지표 순위
        private System.Windows.Forms.TabPage tabPageRanking;
        private System.Windows.Forms.Panel pnlRankTop;
        private System.Windows.Forms.Label lblRankMetric;
        private System.Windows.Forms.ComboBox cmbRankMetric;
        private System.Windows.Forms.Label lblRankTopN;
        private System.Windows.Forms.NumericUpDown numRankTopN;
        private System.Windows.Forms.CheckBox chkDescending;
        private System.Windows.Forms.CheckBox chkRankSelectedOnly;
        private System.Windows.Forms.Button btnRanking;
        private System.Windows.Forms.ListView lvRanking;
        private System.Windows.Forms.ColumnHeader colRank;
        private System.Windows.Forms.ColumnHeader colRankName;
        private System.Windows.Forms.ColumnHeader colRankValue;
        private System.Windows.Forms.ColumnHeader colRankIndex;
        private System.Windows.Forms.Label lblRankInfo;

        // 축 방향 분포
        private System.Windows.Forms.TabPage tabPageAxis;
        private System.Windows.Forms.Panel pnlAxisTop;
        private System.Windows.Forms.Label lblAxis;
        private System.Windows.Forms.ComboBox cmbAxis;
        private System.Windows.Forms.Label lblBandCount;
        private System.Windows.Forms.NumericUpDown numBandCount;
        private System.Windows.Forms.CheckBox chkAxisVisibleOnly;
        private System.Windows.Forms.Button btnAxisDistribution;
        private System.Windows.Forms.ListView lvAxisBand;
        private System.Windows.Forms.ColumnHeader colBand;
        private System.Windows.Forms.ColumnHeader colBandFrom;
        private System.Windows.Forms.ColumnHeader colBandTo;
        private System.Windows.Forms.ColumnHeader colBandCount;
        private System.Windows.Forms.Label lblAxisInfo;

        // 노드 기본 특성 로드
        private System.Windows.Forms.TabPage tabPageDefault;
        private System.Windows.Forms.GroupBox groupDefaultProperty;
        private System.Windows.Forms.CheckBox chkKindColor;
        private System.Windows.Forms.CheckBox chkKindSurfaceArea;
        private System.Windows.Forms.CheckBox chkKindVolume;
        private System.Windows.Forms.CheckBox chkKindCenterOfVolume;
        private System.Windows.Forms.CheckBox chkKindTriangleCount;
        private System.Windows.Forms.CheckBox chkDefaultSelectedOnly;
        private System.Windows.Forms.Button btnLoadDefaultProperties;
        private System.Windows.Forms.Label lblDefaultInfo;
        private System.Windows.Forms.ListView lvDefaultResult;
        private System.Windows.Forms.ColumnHeader colDefName;
        private System.Windows.Forms.ColumnHeader colDefColor;
        private System.Windows.Forms.ColumnHeader colDefVolume;
        private System.Windows.Forms.ColumnHeader colDefArea;
        private System.Windows.Forms.ColumnHeader colDefCenter;
        private System.Windows.Forms.ColumnHeader colDefTriangle;
    }
}