namespace VIZCore3DX.NET.FrameEditor
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
            this.grpOpen = new System.Windows.Forms.GroupBox();
            this.tblOpen = new System.Windows.Forms.TableLayoutPanel();
            this.btnModelOpen = new System.Windows.Forms.Button();
            this.grpFrame = new System.Windows.Forms.GroupBox();
            this.cmbFrame = new System.Windows.Forms.ComboBox();
            this.tblFrame = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabFrame = new System.Windows.Forms.TabPage();
            this.grpSpace = new System.Windows.Forms.GroupBox();
            this.lblSpaceMode = new System.Windows.Forms.Label();
            this.cmbSpaceMode = new System.Windows.Forms.ComboBox();
            this.lblSpaceMin = new System.Windows.Forms.Label();
            this.lblSpaceMax = new System.Windows.Forms.Label();
            this.lblMargin = new System.Windows.Forms.Label();
            this.lblMinX = new System.Windows.Forms.Label();
            this.numMinX = new System.Windows.Forms.NumericUpDown();
            this.lblMinY = new System.Windows.Forms.Label();
            this.numMinY = new System.Windows.Forms.NumericUpDown();
            this.lblMinZ = new System.Windows.Forms.Label();
            this.numMinZ = new System.Windows.Forms.NumericUpDown();
            this.lblMaxX = new System.Windows.Forms.Label();
            this.numMaxX = new System.Windows.Forms.NumericUpDown();
            this.lblMaxY = new System.Windows.Forms.Label();
            this.numMaxY = new System.Windows.Forms.NumericUpDown();
            this.lblMaxZ = new System.Windows.Forms.Label();
            this.numMaxZ = new System.Windows.Forms.NumericUpDown();
            this.lblMarginX = new System.Windows.Forms.Label();
            this.numMarginX = new System.Windows.Forms.NumericUpDown();
            this.lblMarginY = new System.Windows.Forms.Label();
            this.numMarginY = new System.Windows.Forms.NumericUpDown();
            this.lblMarginZ = new System.Windows.Forms.Label();
            this.numMarginZ = new System.Windows.Forms.NumericUpDown();
            this.lblMarginType = new System.Windows.Forms.Label();
            this.cmbMarginType = new System.Windows.Forms.ComboBox();
            this.lblMarginHint = new System.Windows.Forms.Label();
            this.grpPlane = new System.Windows.Forms.GroupBox();
            this.chkXY = new System.Windows.Forms.CheckBox();
            this.chkYZ = new System.Windows.Forms.CheckBox();
            this.chkZX = new System.Windows.Forms.CheckBox();
            this.lblPlaneColor = new System.Windows.Forms.Label();
            this.btnPlaneColor = new System.Windows.Forms.Button();
            this.lblPlanePattern = new System.Windows.Forms.Label();
            this.cmbPlanePattern = new System.Windows.Forms.ComboBox();
            this.lblPlaneThickness = new System.Windows.Forms.Label();
            this.numPlaneThickness = new System.Windows.Forms.NumericUpDown();
            this.btnApplyFrame = new System.Windows.Forms.Button();
            this.tabAxis = new System.Windows.Forms.TabPage();
            this.grpAxisSelect = new System.Windows.Forms.GroupBox();
            this.rdoAxisX = new System.Windows.Forms.RadioButton();
            this.rdoAxisY = new System.Windows.Forms.RadioButton();
            this.rdoAxisZ = new System.Windows.Forms.RadioButton();
            this.grpAxis = new System.Windows.Forms.GroupBox();
            this.lblAxisLabel = new System.Windows.Forms.Label();
            this.txtAxisLabel = new System.Windows.Forms.TextBox();
            this.chkLineEnabled = new System.Windows.Forms.CheckBox();
            this.lblLabelType = new System.Windows.Forms.Label();
            this.cmbLabelType = new System.Windows.Forms.ComboBox();
            this.lblTextColor = new System.Windows.Forms.Label();
            this.btnTextColor = new System.Windows.Forms.Button();
            this.lblStrokeColor = new System.Windows.Forms.Label();
            this.btnStrokeColor = new System.Windows.Forms.Button();
            this.lblStrokePattern = new System.Windows.Forms.Label();
            this.cmbStrokePattern = new System.Windows.Forms.ComboBox();
            this.lblStrokeThickness = new System.Windows.Forms.Label();
            this.numStrokeThickness = new System.Windows.Forms.NumericUpDown();
            this.btnApplyAxis = new System.Windows.Forms.Button();
            this.tabLine = new System.Windows.Forms.TabPage();
            this.lblLineAxis = new System.Windows.Forms.Label();
            this.cmbLineAxis = new System.Windows.Forms.ComboBox();
            this.chkAllAxis = new System.Windows.Forms.CheckBox();
            this.cmbAllAxisMode = new System.Windows.Forms.ComboBox();
            this.dgvLine = new System.Windows.Forms.DataGridView();
            this.lblDivision = new System.Windows.Forms.Label();
            this.numDivision = new System.Windows.Forms.NumericUpDown();
            this.btnLineGenerate = new System.Windows.Forms.Button();
            this.lblNewOffset = new System.Windows.Forms.Label();
            this.numNewOffset = new System.Windows.Forms.NumericUpDown();
            this.btnLineAdd = new System.Windows.Forms.Button();
            this.btnLineRemove = new System.Windows.Forms.Button();
            this.btnLineClear = new System.Windows.Forms.Button();
            this.btnApplyLine = new System.Windows.Forms.Button();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOffset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlaneThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStrokeThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDivision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNewOffset)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpOpen.SuspendLayout();
            this.tblOpen.SuspendLayout();
            this.grpFrame.SuspendLayout();
            this.tblFrame.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabFrame.SuspendLayout();
            this.grpSpace.SuspendLayout();
            this.grpPlane.SuspendLayout();
            this.tabAxis.SuspendLayout();
            this.grpAxisSelect.SuspendLayout();
            this.grpAxis.SuspendLayout();
            this.tabLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // splitContainer1.Panel1
            this.splitContainer1.Panel1.Controls.Add(this.grpOpen);
            this.splitContainer1.Panel1.Controls.Add(this.grpFrame);
            this.splitContainer1.Panel1.Controls.Add(this.tabMain);
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Size = new System.Drawing.Size(1280, 760);
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 0;
            // 
            // grpOpen
            // 
            this.grpOpen.Controls.Add(this.tblOpen);
            this.grpOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOpen.Location = new System.Drawing.Point(8, 8);
            this.grpOpen.Size = new System.Drawing.Size(384, 52);
            this.grpOpen.TabStop = false;
            this.grpOpen.Text = "Open";
            this.grpOpen.TabIndex = 0;
            // 
            // tblOpen
            // 
            this.tblOpen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0F));
            this.tblOpen.Controls.Add(this.btnModelOpen, 0, 0);
            this.tblOpen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblOpen.Location = new System.Drawing.Point(3, 17);
            this.tblOpen.Size = new System.Drawing.Size(378, 32);
            this.tblOpen.ColumnCount = 1;
            this.tblOpen.RowCount = 1;
            this.tblOpen.TabIndex = 0;
            // 
            // btnModelOpen
            // 
            this.btnModelOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnModelOpen.Location = new System.Drawing.Point(3, 3);
            this.btnModelOpen.Size = new System.Drawing.Size(372, 26);
            this.btnModelOpen.UseVisualStyleBackColor = true;
            this.btnModelOpen.Text = "Model Open";
            this.btnModelOpen.TabIndex = 0;
            this.btnModelOpen.Click += new System.EventHandler(this.btnModelOpen_Click);
            // 
            // grpFrame
            // 
            this.grpFrame.Controls.Add(this.cmbFrame);
            this.grpFrame.Controls.Add(this.tblFrame);
            this.grpFrame.Controls.Add(this.chkVisible);
            this.grpFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFrame.Location = new System.Drawing.Point(8, 66);
            this.grpFrame.Size = new System.Drawing.Size(384, 118);
            this.grpFrame.TabStop = false;
            this.grpFrame.Text = "Frame";
            this.grpFrame.TabIndex = 1;
            // 
            // cmbFrame
            // 
            this.cmbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFrame.Location = new System.Drawing.Point(10, 20);
            this.cmbFrame.Size = new System.Drawing.Size(364, 20);
            this.cmbFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrame.FormattingEnabled = true;
            this.cmbFrame.TabIndex = 0;
            // 
            // tblFrame
            // 
            this.tblFrame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblFrame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblFrame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblFrame.Controls.Add(this.btnCreate, 0, 0);
            this.tblFrame.Controls.Add(this.btnImport, 1, 0);
            this.tblFrame.Controls.Add(this.btnExport, 2, 0);
            this.tblFrame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tblFrame.Location = new System.Drawing.Point(10, 48);
            this.tblFrame.Size = new System.Drawing.Size(364, 28);
            this.tblFrame.ColumnCount = 3;
            this.tblFrame.RowCount = 1;
            this.tblFrame.TabIndex = 1;
            // 
            // btnCreate
            // 
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreate.Location = new System.Drawing.Point(3, 3);
            this.btnCreate.Size = new System.Drawing.Size(115, 22);
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Text = "Create";
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnImport
            // 
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImport.Location = new System.Drawing.Point(125, 3);
            this.btnImport.Size = new System.Drawing.Size(115, 22);
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Text = "Import";
            this.btnImport.TabIndex = 1;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Location = new System.Drawing.Point(247, 3);
            this.btnExport.Size = new System.Drawing.Size(114, 22);
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Text = "Export";
            this.btnExport.TabIndex = 2;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // chkVisible
            // 
            this.chkVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.chkVisible.Location = new System.Drawing.Point(12, 86);
            this.chkVisible.Size = new System.Drawing.Size(80, 16);
            this.chkVisible.AutoSize = true;
            this.chkVisible.UseVisualStyleBackColor = true;
            this.chkVisible.Checked = true;
            this.chkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisible.Text = "Visible";
            this.chkVisible.TabIndex = 2;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabFrame);
            this.tabMain.Controls.Add(this.tabAxis);
            this.tabMain.Controls.Add(this.tabLine);
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Location = new System.Drawing.Point(8, 190);
            this.tabMain.Size = new System.Drawing.Size(384, 540);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.TabIndex = 2;
            // 
            // tabFrame
            // 
            this.tabFrame.Controls.Add(this.grpSpace);
            this.tabFrame.Controls.Add(this.grpPlane);
            this.tabFrame.Controls.Add(this.btnApplyFrame);
            this.tabFrame.Location = new System.Drawing.Point(4, 22);
            this.tabFrame.Size = new System.Drawing.Size(376, 514);
            this.tabFrame.UseVisualStyleBackColor = true;
            this.tabFrame.Text = "Frame";
            this.tabFrame.TabIndex = 0;
            // 
            // grpSpace
            // 
            this.grpSpace.Controls.Add(this.lblSpaceMode);
            this.grpSpace.Controls.Add(this.cmbSpaceMode);
            this.grpSpace.Controls.Add(this.lblSpaceMin);
            this.grpSpace.Controls.Add(this.lblSpaceMax);
            this.grpSpace.Controls.Add(this.lblMargin);
            this.grpSpace.Controls.Add(this.lblMinX);
            this.grpSpace.Controls.Add(this.numMinX);
            this.grpSpace.Controls.Add(this.lblMinY);
            this.grpSpace.Controls.Add(this.numMinY);
            this.grpSpace.Controls.Add(this.lblMinZ);
            this.grpSpace.Controls.Add(this.numMinZ);
            this.grpSpace.Controls.Add(this.lblMaxX);
            this.grpSpace.Controls.Add(this.numMaxX);
            this.grpSpace.Controls.Add(this.lblMaxY);
            this.grpSpace.Controls.Add(this.numMaxY);
            this.grpSpace.Controls.Add(this.lblMaxZ);
            this.grpSpace.Controls.Add(this.numMaxZ);
            this.grpSpace.Controls.Add(this.lblMarginX);
            this.grpSpace.Controls.Add(this.numMarginX);
            this.grpSpace.Controls.Add(this.lblMarginY);
            this.grpSpace.Controls.Add(this.numMarginY);
            this.grpSpace.Controls.Add(this.lblMarginZ);
            this.grpSpace.Controls.Add(this.numMarginZ);
            this.grpSpace.Controls.Add(this.lblMarginType);
            this.grpSpace.Controls.Add(this.cmbMarginType);
            this.grpSpace.Controls.Add(this.lblMarginHint);
            this.grpSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSpace.Location = new System.Drawing.Point(6, 6);
            this.grpSpace.Size = new System.Drawing.Size(362, 196);
            this.grpSpace.TabStop = false;
            this.grpSpace.Text = "Space / Margin";
            this.grpSpace.TabIndex = 0;
            // 
            // lblSpaceMode
            // 
            this.lblSpaceMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSpaceMode.Location = new System.Drawing.Point(10, 26);
            this.lblSpaceMode.Size = new System.Drawing.Size(90, 12);
            this.lblSpaceMode.AutoSize = true;
            this.lblSpaceMode.Text = "Space Mode";
            this.lblSpaceMode.TabIndex = 0;
            // 
            // cmbSpaceMode
            // 
            this.cmbSpaceMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSpaceMode.Location = new System.Drawing.Point(110, 22);
            this.cmbSpaceMode.Size = new System.Drawing.Size(240, 20);
            this.cmbSpaceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpaceMode.FormattingEnabled = true;
            this.cmbSpaceMode.TabIndex = 1;
            // 
            // lblSpaceMin
            // 
            this.lblSpaceMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSpaceMin.Location = new System.Drawing.Point(10, 54);
            this.lblSpaceMin.Size = new System.Drawing.Size(90, 12);
            this.lblSpaceMin.AutoSize = true;
            this.lblSpaceMin.Text = "Space Min";
            this.lblSpaceMin.TabIndex = 2;
            // 
            // lblSpaceMax
            // 
            this.lblSpaceMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSpaceMax.Location = new System.Drawing.Point(10, 82);
            this.lblSpaceMax.Size = new System.Drawing.Size(90, 12);
            this.lblSpaceMax.AutoSize = true;
            this.lblSpaceMax.Text = "Space Max";
            this.lblSpaceMax.TabIndex = 3;
            // 
            // lblMargin
            // 
            this.lblMargin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMargin.Location = new System.Drawing.Point(10, 138);
            this.lblMargin.Size = new System.Drawing.Size(90, 12);
            this.lblMargin.AutoSize = true;
            this.lblMargin.Text = "Margin";
            this.lblMargin.TabIndex = 4;
            // 
            // lblMinX
            // 
            this.lblMinX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMinX.Location = new System.Drawing.Point(98, 54);
            this.lblMinX.Size = new System.Drawing.Size(12, 12);
            this.lblMinX.AutoSize = true;
            this.lblMinX.Text = "X";
            this.lblMinX.TabIndex = 5;
            // 
            // numMinX
            // 
            this.numMinX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.numMinX.Location = new System.Drawing.Point(112, 50);
            this.numMinX.Size = new System.Drawing.Size(64, 21);
            this.numMinX.DecimalPlaces = 1;
            this.numMinX.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
            this.numMinX.Minimum = new decimal(new int[] {1000000, 0, 0, -2147483648});
            this.numMinX.Value = new decimal(new int[] {0, 0, 0, 0});
            this.numMinX.TabIndex = 6;
            // 
            // lblMinY
            // 
            this.lblMinY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMinY.Location = new System.Drawing.Point(184, 54);
            this.lblMinY.Size = new System.Drawing.Size(12, 12);
            this.lblMinY.AutoSize = true;
            this.lblMinY.Text = "Y";
            this.lblMinY.TabIndex = 7;
            // 
            // numMinY
            // 
            this.numMinY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.numMinY.Location = new System.Drawing.Point(198, 50);
            this.numMinY.Size = new System.Drawing.Size(64, 21);
            this.numMinY.DecimalPlaces = 1;
            this.numMinY.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
            this.numMinY.Minimum = new decimal(new int[] {1000000, 0, 0, -2147483648});
            this.numMinY.Value = new decimal(new int[] {0, 0, 0, 0});
            this.numMinY.TabIndex = 8;
            // 
            // lblMinZ
            // 
            this.lblMinZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMinZ.Location = new System.Drawing.Point(270, 54);
            this.lblMinZ.Size = new System.Drawing.Size(12, 12);
            this.lblMinZ.AutoSize = true;
            this.lblMinZ.Text = "Z";
            this.lblMinZ.TabIndex = 9;
            // 
            // numMinZ
            // 
            this.numMinZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.numMinZ.Location = new System.Drawing.Point(284, 50);
            this.numMinZ.Size = new System.Drawing.Size(64, 21);
            this.numMinZ.DecimalPlaces = 1;
            this.numMinZ.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
            this.numMinZ.Minimum = new decimal(new int[] {1000000, 0, 0, -2147483648});
            this.numMinZ.Value = new decimal(new int[] {0, 0, 0, 0});
            this.numMinZ.TabIndex = 10;
            // 
            // lblMaxX
            // 
            this.lblMaxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMaxX.Location = new System.Drawing.Point(98, 82);
            this.lblMaxX.Size = new System.Drawing.Size(12, 12);
            this.lblMaxX.AutoSize = true;
            this.lblMaxX.Text = "X";
            this.lblMaxX.TabIndex = 11;
            // 
            // numMaxX
            // 
            this.numMaxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.numMaxX.Location = new System.Drawing.Point(112, 78);
            this.numMaxX.Size = new System.Drawing.Size(64, 21);
            this.numMaxX.DecimalPlaces = 1;
            this.numMaxX.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
            this.numMaxX.Minimum = new decimal(new int[] {1000000, 0, 0, -2147483648});
            this.numMaxX.Value = new decimal(new int[] {0, 0, 0, 0});
            this.numMaxX.TabIndex = 12;
            // 
            // lblMaxY
            // 
            this.lblMaxY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMaxY.Location = new System.Drawing.Point(184, 82);
            this.lblMaxY.Size = new System.Drawing.Size(12, 12);
            this.lblMaxY.AutoSize = true;
            this.lblMaxY.Text = "Y";
            this.lblMaxY.TabIndex = 13;
            // 
            // numMaxY
            // 
            this.numMaxY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.numMaxY.Location = new System.Drawing.Point(198, 78);
            this.numMaxY.Size = new System.Drawing.Size(64, 21);
            this.numMaxY.DecimalPlaces = 1;
            this.numMaxY.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
            this.numMaxY.Minimum = new decimal(new int[] {1000000, 0, 0, -2147483648});
            this.numMaxY.Value = new decimal(new int[] {0, 0, 0, 0});
            this.numMaxY.TabIndex = 14;
            // 
            // lblMaxZ
            // 
            this.lblMaxZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMaxZ.Location = new System.Drawing.Point(270, 82);
            this.lblMaxZ.Size = new System.Drawing.Size(12, 12);
            this.lblMaxZ.AutoSize = true;
            this.lblMaxZ.Text = "Z";
            this.lblMaxZ.TabIndex = 15;
            // 
            // numMaxZ
            // 
            this.numMaxZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.numMaxZ.Location = new System.Drawing.Point(284, 78);
            this.numMaxZ.Size = new System.Drawing.Size(64, 21);
            this.numMaxZ.DecimalPlaces = 1;
            this.numMaxZ.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
            this.numMaxZ.Minimum = new decimal(new int[] {1000000, 0, 0, -2147483648});
            this.numMaxZ.Value = new decimal(new int[] {0, 0, 0, 0});
            this.numMaxZ.TabIndex = 16;
            // 
            // lblMarginX
            // 
            this.lblMarginX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMarginX.Location = new System.Drawing.Point(98, 138);
            this.lblMarginX.Size = new System.Drawing.Size(12, 12);
            this.lblMarginX.AutoSize = true;
            this.lblMarginX.Text = "X";
            this.lblMarginX.TabIndex = 17;
            // 
            // numMarginX
            // 
            this.numMarginX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.numMarginX.Location = new System.Drawing.Point(112, 134);
            this.numMarginX.Size = new System.Drawing.Size(64, 21);
            this.numMarginX.DecimalPlaces = 1;
            this.numMarginX.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
            this.numMarginX.Minimum = new decimal(new int[] {0, 0, 0, 0});
            this.numMarginX.Value = new decimal(new int[] {0, 0, 0, 0});
            this.numMarginX.TabIndex = 18;
            // 
            // lblMarginY
            // 
            this.lblMarginY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMarginY.Location = new System.Drawing.Point(184, 138);
            this.lblMarginY.Size = new System.Drawing.Size(12, 12);
            this.lblMarginY.AutoSize = true;
            this.lblMarginY.Text = "Y";
            this.lblMarginY.TabIndex = 19;
            // 
            // numMarginY
            // 
            this.numMarginY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.numMarginY.Location = new System.Drawing.Point(198, 134);
            this.numMarginY.Size = new System.Drawing.Size(64, 21);
            this.numMarginY.DecimalPlaces = 1;
            this.numMarginY.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
            this.numMarginY.Minimum = new decimal(new int[] {0, 0, 0, 0});
            this.numMarginY.Value = new decimal(new int[] {0, 0, 0, 0});
            this.numMarginY.TabIndex = 20;
            // 
            // lblMarginZ
            // 
            this.lblMarginZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMarginZ.Location = new System.Drawing.Point(270, 138);
            this.lblMarginZ.Size = new System.Drawing.Size(12, 12);
            this.lblMarginZ.AutoSize = true;
            this.lblMarginZ.Text = "Z";
            this.lblMarginZ.TabIndex = 21;
            // 
            // numMarginZ
            // 
            this.numMarginZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.numMarginZ.Location = new System.Drawing.Point(284, 134);
            this.numMarginZ.Size = new System.Drawing.Size(64, 21);
            this.numMarginZ.DecimalPlaces = 1;
            this.numMarginZ.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
            this.numMarginZ.Minimum = new decimal(new int[] {0, 0, 0, 0});
            this.numMarginZ.Value = new decimal(new int[] {0, 0, 0, 0});
            this.numMarginZ.TabIndex = 22;
            // 
            // lblMarginType
            // 
            this.lblMarginType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMarginType.Location = new System.Drawing.Point(10, 110);
            this.lblMarginType.Size = new System.Drawing.Size(90, 12);
            this.lblMarginType.AutoSize = true;
            this.lblMarginType.Text = "Margin Type";
            this.lblMarginType.TabIndex = 23;
            // 
            // cmbMarginType
            // 
            this.cmbMarginType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMarginType.Location = new System.Drawing.Point(110, 106);
            this.cmbMarginType.Size = new System.Drawing.Size(240, 20);
            this.cmbMarginType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarginType.FormattingEnabled = true;
            this.cmbMarginType.TabIndex = 24;
            // 
            // lblMarginHint
            // 
            this.lblMarginHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMarginHint.Location = new System.Drawing.Point(10, 168);
            this.lblMarginHint.AutoSize = true;
            this.lblMarginHint.Text = "Fixed: Length / Ratio: 0.0 ~ 1.0";
            this.lblMarginHint.TabIndex = 25;
            // 
            // grpPlane
            // 
            this.grpPlane.Controls.Add(this.chkXY);
            this.grpPlane.Controls.Add(this.chkYZ);
            this.grpPlane.Controls.Add(this.chkZX);
            this.grpPlane.Controls.Add(this.lblPlaneColor);
            this.grpPlane.Controls.Add(this.btnPlaneColor);
            this.grpPlane.Controls.Add(this.lblPlanePattern);
            this.grpPlane.Controls.Add(this.cmbPlanePattern);
            this.grpPlane.Controls.Add(this.lblPlaneThickness);
            this.grpPlane.Controls.Add(this.numPlaneThickness);
            this.grpPlane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPlane.Location = new System.Drawing.Point(6, 208);
            this.grpPlane.Size = new System.Drawing.Size(362, 152);
            this.grpPlane.TabStop = false;
            this.grpPlane.Text = "Plane";
            this.grpPlane.TabIndex = 1;
            // 
            // chkXY
            // 
            this.chkXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXY.Location = new System.Drawing.Point(12, 24);
            this.chkXY.Size = new System.Drawing.Size(80, 16);
            this.chkXY.AutoSize = true;
            this.chkXY.UseVisualStyleBackColor = true;
            this.chkXY.Checked = true;
            this.chkXY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXY.Text = "XY";
            this.chkXY.TabIndex = 0;
            // 
            // chkYZ
            // 
            this.chkYZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.chkYZ.Location = new System.Drawing.Point(72, 24);
            this.chkYZ.Size = new System.Drawing.Size(80, 16);
            this.chkYZ.AutoSize = true;
            this.chkYZ.UseVisualStyleBackColor = true;
            this.chkYZ.Checked = true;
            this.chkYZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkYZ.Text = "YZ";
            this.chkYZ.TabIndex = 1;
            // 
            // chkZX
            // 
            this.chkZX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.chkZX.Location = new System.Drawing.Point(132, 24);
            this.chkZX.Size = new System.Drawing.Size(80, 16);
            this.chkZX.AutoSize = true;
            this.chkZX.UseVisualStyleBackColor = true;
            this.chkZX.Checked = true;
            this.chkZX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkZX.Text = "ZX";
            this.chkZX.TabIndex = 2;
            // 
            // lblPlaneColor
            // 
            this.lblPlaneColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPlaneColor.Location = new System.Drawing.Point(10, 54);
            this.lblPlaneColor.Size = new System.Drawing.Size(90, 12);
            this.lblPlaneColor.AutoSize = true;
            this.lblPlaneColor.Text = "Color";
            this.lblPlaneColor.TabIndex = 3;
            // 
            // btnPlaneColor
            // 
            this.btnPlaneColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlaneColor.Location = new System.Drawing.Point(110, 50);
            this.btnPlaneColor.Size = new System.Drawing.Size(80, 21);
            this.btnPlaneColor.BackColor = System.Drawing.Color.Gray;
            this.btnPlaneColor.UseVisualStyleBackColor = false;
            this.btnPlaneColor.TabIndex = 4;
            this.btnPlaneColor.Click += new System.EventHandler(this.btnPlaneColor_Click);
            // 
            // lblPlanePattern
            // 
            this.lblPlanePattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPlanePattern.Location = new System.Drawing.Point(10, 82);
            this.lblPlanePattern.Size = new System.Drawing.Size(90, 12);
            this.lblPlanePattern.AutoSize = true;
            this.lblPlanePattern.Text = "Pattern";
            this.lblPlanePattern.TabIndex = 5;
            // 
            // cmbPlanePattern
            // 
            this.cmbPlanePattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPlanePattern.Location = new System.Drawing.Point(110, 78);
            this.cmbPlanePattern.Size = new System.Drawing.Size(240, 20);
            this.cmbPlanePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanePattern.FormattingEnabled = true;
            this.cmbPlanePattern.TabIndex = 6;
            // 
            // lblPlaneThickness
            // 
            this.lblPlaneThickness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPlaneThickness.Location = new System.Drawing.Point(10, 110);
            this.lblPlaneThickness.Size = new System.Drawing.Size(90, 12);
            this.lblPlaneThickness.AutoSize = true;
            this.lblPlaneThickness.Text = "Thickness";
            this.lblPlaneThickness.TabIndex = 7;
            // 
            // numPlaneThickness
            // 
            this.numPlaneThickness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.numPlaneThickness.Location = new System.Drawing.Point(110, 106);
            this.numPlaneThickness.Size = new System.Drawing.Size(100, 21);
            this.numPlaneThickness.DecimalPlaces = 1;
            this.numPlaneThickness.Maximum = new decimal(new int[] {100, 0, 0, 0});
            this.numPlaneThickness.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numPlaneThickness.Value = new decimal(new int[] {1, 0, 0, 0});
            this.numPlaneThickness.TabIndex = 8;
            // 
            // btnApplyFrame
            // 
            this.btnApplyFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyFrame.Location = new System.Drawing.Point(266, 478);
            this.btnApplyFrame.Size = new System.Drawing.Size(100, 28);
            this.btnApplyFrame.UseVisualStyleBackColor = true;
            this.btnApplyFrame.Text = "Apply";
            this.btnApplyFrame.TabIndex = 2;
            this.btnApplyFrame.Click += new System.EventHandler(this.btnApplyFrame_Click);
            // 
            // tabAxis
            // 
            this.tabAxis.Controls.Add(this.grpAxisSelect);
            this.tabAxis.Controls.Add(this.grpAxis);
            this.tabAxis.Controls.Add(this.btnApplyAxis);
            this.tabAxis.Location = new System.Drawing.Point(4, 22);
            this.tabAxis.Size = new System.Drawing.Size(376, 514);
            this.tabAxis.UseVisualStyleBackColor = true;
            this.tabAxis.Text = "Axis";
            this.tabAxis.TabIndex = 1;
            // 
            // grpAxisSelect
            // 
            this.grpAxisSelect.Controls.Add(this.rdoAxisX);
            this.grpAxisSelect.Controls.Add(this.rdoAxisY);
            this.grpAxisSelect.Controls.Add(this.rdoAxisZ);
            this.grpAxisSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAxisSelect.Location = new System.Drawing.Point(6, 6);
            this.grpAxisSelect.Size = new System.Drawing.Size(362, 48);
            this.grpAxisSelect.TabStop = false;
            this.grpAxisSelect.Text = "Axis";
            this.grpAxisSelect.TabIndex = 0;
            // 
            // rdoAxisX
            // 
            this.rdoAxisX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoAxisX.Location = new System.Drawing.Point(16, 22);
            this.rdoAxisX.Size = new System.Drawing.Size(50, 16);
            this.rdoAxisX.AutoSize = true;
            this.rdoAxisX.UseVisualStyleBackColor = true;
            this.rdoAxisX.Checked = true;
            this.rdoAxisX.TabStop = true;
            this.rdoAxisX.Text = "X (Section)";
            this.rdoAxisX.TabIndex = 0;
            // 
            // rdoAxisY
            // 
            this.rdoAxisY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoAxisY.Location = new System.Drawing.Point(112, 22);
            this.rdoAxisY.Size = new System.Drawing.Size(50, 16);
            this.rdoAxisY.AutoSize = true;
            this.rdoAxisY.UseVisualStyleBackColor = true;
            this.rdoAxisY.Text = "Y (Elevation)";
            this.rdoAxisY.TabIndex = 1;
            // 
            // rdoAxisZ
            // 
            this.rdoAxisZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoAxisZ.Location = new System.Drawing.Point(224, 22);
            this.rdoAxisZ.Size = new System.Drawing.Size(50, 16);
            this.rdoAxisZ.AutoSize = true;
            this.rdoAxisZ.UseVisualStyleBackColor = true;
            this.rdoAxisZ.Text = "Z (Plan)";
            this.rdoAxisZ.TabIndex = 2;
            // 
            // grpAxis
            // 
            this.grpAxis.Controls.Add(this.lblAxisLabel);
            this.grpAxis.Controls.Add(this.txtAxisLabel);
            this.grpAxis.Controls.Add(this.chkLineEnabled);
            this.grpAxis.Controls.Add(this.lblLabelType);
            this.grpAxis.Controls.Add(this.cmbLabelType);
            this.grpAxis.Controls.Add(this.lblTextColor);
            this.grpAxis.Controls.Add(this.btnTextColor);
            this.grpAxis.Controls.Add(this.lblStrokeColor);
            this.grpAxis.Controls.Add(this.btnStrokeColor);
            this.grpAxis.Controls.Add(this.lblStrokePattern);
            this.grpAxis.Controls.Add(this.cmbStrokePattern);
            this.grpAxis.Controls.Add(this.lblStrokeThickness);
            this.grpAxis.Controls.Add(this.numStrokeThickness);
            this.grpAxis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAxis.Location = new System.Drawing.Point(6, 60);
            this.grpAxis.Size = new System.Drawing.Size(362, 226);
            this.grpAxis.TabStop = false;
            this.grpAxis.Text = "Axis Option";
            this.grpAxis.TabIndex = 1;
            // 
            // lblAxisLabel
            // 
            this.lblAxisLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAxisLabel.Location = new System.Drawing.Point(10, 28);
            this.lblAxisLabel.Size = new System.Drawing.Size(90, 12);
            this.lblAxisLabel.AutoSize = true;
            this.lblAxisLabel.Text = "Label";
            this.lblAxisLabel.TabIndex = 0;
            // 
            // txtAxisLabel
            // 
            this.txtAxisLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAxisLabel.Location = new System.Drawing.Point(110, 24);
            this.txtAxisLabel.Size = new System.Drawing.Size(240, 21);
            this.txtAxisLabel.TabIndex = 1;
            // 
            // chkLineEnabled
            // 
            this.chkLineEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.chkLineEnabled.Location = new System.Drawing.Point(112, 54);
            this.chkLineEnabled.Size = new System.Drawing.Size(80, 16);
            this.chkLineEnabled.AutoSize = true;
            this.chkLineEnabled.UseVisualStyleBackColor = true;
            this.chkLineEnabled.Checked = true;
            this.chkLineEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLineEnabled.Text = "Frame Line Enabled";
            this.chkLineEnabled.TabIndex = 2;
            // 
            // lblLabelType
            // 
            this.lblLabelType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLabelType.Location = new System.Drawing.Point(10, 82);
            this.lblLabelType.Size = new System.Drawing.Size(90, 12);
            this.lblLabelType.AutoSize = true;
            this.lblLabelType.Text = "Label Type";
            this.lblLabelType.TabIndex = 3;
            // 
            // cmbLabelType
            // 
            this.cmbLabelType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLabelType.Location = new System.Drawing.Point(110, 78);
            this.cmbLabelType.Size = new System.Drawing.Size(240, 20);
            this.cmbLabelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelType.FormattingEnabled = true;
            this.cmbLabelType.TabIndex = 4;
            // 
            // lblTextColor
            // 
            this.lblTextColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTextColor.Location = new System.Drawing.Point(10, 110);
            this.lblTextColor.Size = new System.Drawing.Size(90, 12);
            this.lblTextColor.AutoSize = true;
            this.lblTextColor.Text = "Text Color";
            this.lblTextColor.TabIndex = 5;
            // 
            // btnTextColor
            // 
            this.btnTextColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTextColor.Location = new System.Drawing.Point(110, 106);
            this.btnTextColor.Size = new System.Drawing.Size(80, 21);
            this.btnTextColor.BackColor = System.Drawing.Color.Black;
            this.btnTextColor.UseVisualStyleBackColor = false;
            this.btnTextColor.TabIndex = 6;
            this.btnTextColor.Click += new System.EventHandler(this.btnTextColor_Click);
            // 
            // lblStrokeColor
            // 
            this.lblStrokeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStrokeColor.Location = new System.Drawing.Point(10, 138);
            this.lblStrokeColor.Size = new System.Drawing.Size(90, 12);
            this.lblStrokeColor.AutoSize = true;
            this.lblStrokeColor.Text = "Line Color";
            this.lblStrokeColor.TabIndex = 7;
            // 
            // btnStrokeColor
            // 
            this.btnStrokeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStrokeColor.Location = new System.Drawing.Point(110, 134);
            this.btnStrokeColor.Size = new System.Drawing.Size(80, 21);
            this.btnStrokeColor.BackColor = System.Drawing.Color.Red;
            this.btnStrokeColor.UseVisualStyleBackColor = false;
            this.btnStrokeColor.TabIndex = 8;
            this.btnStrokeColor.Click += new System.EventHandler(this.btnStrokeColor_Click);
            // 
            // lblStrokePattern
            // 
            this.lblStrokePattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStrokePattern.Location = new System.Drawing.Point(10, 166);
            this.lblStrokePattern.Size = new System.Drawing.Size(90, 12);
            this.lblStrokePattern.AutoSize = true;
            this.lblStrokePattern.Text = "Line Pattern";
            this.lblStrokePattern.TabIndex = 9;
            // 
            // cmbStrokePattern
            // 
            this.cmbStrokePattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStrokePattern.Location = new System.Drawing.Point(110, 162);
            this.cmbStrokePattern.Size = new System.Drawing.Size(240, 20);
            this.cmbStrokePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStrokePattern.FormattingEnabled = true;
            this.cmbStrokePattern.TabIndex = 10;
            // 
            // lblStrokeThickness
            // 
            this.lblStrokeThickness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStrokeThickness.Location = new System.Drawing.Point(10, 194);
            this.lblStrokeThickness.Size = new System.Drawing.Size(90, 12);
            this.lblStrokeThickness.AutoSize = true;
            this.lblStrokeThickness.Text = "Line Thickness";
            this.lblStrokeThickness.TabIndex = 11;
            // 
            // numStrokeThickness
            // 
            this.numStrokeThickness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.numStrokeThickness.Location = new System.Drawing.Point(110, 190);
            this.numStrokeThickness.Size = new System.Drawing.Size(100, 21);
            this.numStrokeThickness.DecimalPlaces = 1;
            this.numStrokeThickness.Maximum = new decimal(new int[] {100, 0, 0, 0});
            this.numStrokeThickness.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numStrokeThickness.Value = new decimal(new int[] {1, 0, 0, 0});
            this.numStrokeThickness.TabIndex = 12;
            // 
            // btnApplyAxis
            // 
            this.btnApplyAxis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyAxis.Location = new System.Drawing.Point(266, 478);
            this.btnApplyAxis.Size = new System.Drawing.Size(100, 28);
            this.btnApplyAxis.UseVisualStyleBackColor = true;
            this.btnApplyAxis.Text = "Apply";
            this.btnApplyAxis.TabIndex = 2;
            this.btnApplyAxis.Click += new System.EventHandler(this.btnApplyAxis_Click);
            // 
            // tabLine
            // 
            this.tabLine.Controls.Add(this.lblLineAxis);
            this.tabLine.Controls.Add(this.cmbLineAxis);
            this.tabLine.Controls.Add(this.chkAllAxis);
            this.tabLine.Controls.Add(this.cmbAllAxisMode);
            this.tabLine.Controls.Add(this.dgvLine);
            this.tabLine.Controls.Add(this.lblDivision);
            this.tabLine.Controls.Add(this.numDivision);
            this.tabLine.Controls.Add(this.btnLineGenerate);
            this.tabLine.Controls.Add(this.lblNewOffset);
            this.tabLine.Controls.Add(this.numNewOffset);
            this.tabLine.Controls.Add(this.btnLineAdd);
            this.tabLine.Controls.Add(this.btnLineRemove);
            this.tabLine.Controls.Add(this.btnLineClear);
            this.tabLine.Controls.Add(this.btnApplyLine);
            this.tabLine.Location = new System.Drawing.Point(4, 22);
            this.tabLine.Size = new System.Drawing.Size(376, 514);
            this.tabLine.UseVisualStyleBackColor = true;
            this.tabLine.Text = "Line";
            this.tabLine.TabIndex = 2;
            // 
            // lblLineAxis
            // 
            this.lblLineAxis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLineAxis.Location = new System.Drawing.Point(8, 14);
            this.lblLineAxis.Size = new System.Drawing.Size(40, 12);
            this.lblLineAxis.AutoSize = true;
            this.lblLineAxis.Text = "Axis";
            this.lblLineAxis.TabIndex = 0;
            // 
            // cmbLineAxis
            // 
            this.cmbLineAxis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbLineAxis.Location = new System.Drawing.Point(52, 10);
            this.cmbLineAxis.Size = new System.Drawing.Size(120, 20);
            this.cmbLineAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLineAxis.FormattingEnabled = true;
            this.cmbLineAxis.TabIndex = 1;
            // 
            // chkAllAxis
            // 
            this.chkAllAxis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAllAxis.Location = new System.Drawing.Point(184, 12);
            this.chkAllAxis.Size = new System.Drawing.Size(80, 16);
            this.chkAllAxis.AutoSize = true;
            this.chkAllAxis.UseVisualStyleBackColor = true;
            this.chkAllAxis.Text = "All Axis";
            this.chkAllAxis.TabIndex = 2;
            // 
            // cmbAllAxisMode
            // 
            this.cmbAllAxisMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbAllAxisMode.Location = new System.Drawing.Point(256, 10);
            this.cmbAllAxisMode.Size = new System.Drawing.Size(112, 20);
            this.cmbAllAxisMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllAxisMode.FormattingEnabled = true;
            this.cmbAllAxisMode.TabIndex = 3;
            // 
            // dgvLine
            // 
            this.dgvLine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colOffset,
            this.colLabel});
            this.dgvLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLine.Location = new System.Drawing.Point(8, 40);
            this.dgvLine.Size = new System.Drawing.Size(360, 354);
            this.dgvLine.AllowUserToAddRows = false;
            this.dgvLine.AllowUserToDeleteRows = false;
            this.dgvLine.AllowUserToResizeRows = false;
            this.dgvLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLine.MultiSelect = false;
            this.dgvLine.RowHeadersVisible = false;
            this.dgvLine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLine.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLine.TabIndex = 4;
            // 
            // lblDivision
            // 
            this.lblDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDivision.Location = new System.Drawing.Point(8, 406);
            this.lblDivision.Size = new System.Drawing.Size(55, 12);
            this.lblDivision.AutoSize = true;
            this.lblDivision.Text = "Divisions";
            this.lblDivision.TabIndex = 5;
            // 
            // numDivision
            // 
            this.numDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numDivision.Location = new System.Drawing.Point(70, 402);
            this.numDivision.Size = new System.Drawing.Size(70, 21);
            this.numDivision.DecimalPlaces = 0;
            this.numDivision.Maximum = new decimal(new int[] {1000, 0, 0, 0});
            this.numDivision.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numDivision.Value = new decimal(new int[] {10, 0, 0, 0});
            this.numDivision.TabIndex = 6;
            // 
            // btnLineGenerate
            // 
            this.btnLineGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLineGenerate.Location = new System.Drawing.Point(150, 400);
            this.btnLineGenerate.Size = new System.Drawing.Size(100, 24);
            this.btnLineGenerate.UseVisualStyleBackColor = true;
            this.btnLineGenerate.Text = "Generate";
            this.btnLineGenerate.TabIndex = 7;
            this.btnLineGenerate.Click += new System.EventHandler(this.btnLineGenerate_Click);
            // 
            // lblNewOffset
            // 
            this.lblNewOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNewOffset.Location = new System.Drawing.Point(8, 442);
            this.lblNewOffset.Size = new System.Drawing.Size(40, 12);
            this.lblNewOffset.AutoSize = true;
            this.lblNewOffset.Text = "Offset";
            this.lblNewOffset.TabIndex = 8;
            // 
            // numNewOffset
            // 
            this.numNewOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numNewOffset.Location = new System.Drawing.Point(52, 438);
            this.numNewOffset.Size = new System.Drawing.Size(100, 21);
            this.numNewOffset.DecimalPlaces = 1;
            this.numNewOffset.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
            this.numNewOffset.Minimum = new decimal(new int[] {1000000, 0, 0, -2147483648});
            this.numNewOffset.Value = new decimal(new int[] {0, 0, 0, 0});
            this.numNewOffset.TabIndex = 9;
            // 
            // btnLineAdd
            // 
            this.btnLineAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLineAdd.Location = new System.Drawing.Point(160, 436);
            this.btnLineAdd.Size = new System.Drawing.Size(64, 24);
            this.btnLineAdd.UseVisualStyleBackColor = true;
            this.btnLineAdd.Text = "Add";
            this.btnLineAdd.TabIndex = 10;
            this.btnLineAdd.Click += new System.EventHandler(this.btnLineAdd_Click);
            // 
            // btnLineRemove
            // 
            this.btnLineRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLineRemove.Location = new System.Drawing.Point(230, 436);
            this.btnLineRemove.Size = new System.Drawing.Size(64, 24);
            this.btnLineRemove.UseVisualStyleBackColor = true;
            this.btnLineRemove.Text = "Remove";
            this.btnLineRemove.TabIndex = 11;
            this.btnLineRemove.Click += new System.EventHandler(this.btnLineRemove_Click);
            // 
            // btnLineClear
            // 
            this.btnLineClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLineClear.Location = new System.Drawing.Point(300, 436);
            this.btnLineClear.Size = new System.Drawing.Size(64, 24);
            this.btnLineClear.UseVisualStyleBackColor = true;
            this.btnLineClear.Text = "Clear";
            this.btnLineClear.TabIndex = 12;
            this.btnLineClear.Click += new System.EventHandler(this.btnLineClear_Click);
            // 
            // btnApplyLine
            // 
            this.btnApplyLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyLine.Location = new System.Drawing.Point(266, 478);
            this.btnApplyLine.Size = new System.Drawing.Size(100, 28);
            this.btnApplyLine.UseVisualStyleBackColor = true;
            this.btnApplyLine.Text = "Apply";
            this.btnApplyLine.TabIndex = 13;
            this.btnApplyLine.Click += new System.EventHandler(this.btnApplyLine_Click);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colId.Width = 60;
            // 
            // colOffset
            // 
            this.colOffset.HeaderText = "Offset";
            this.colOffset.Name = "colOffset";
            this.colOffset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colOffset.Width = 100;
            // 
            // colLabel
            // 
            this.colLabel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLabel.HeaderText = "Custom Label";
            this.colLabel.Name = "colLabel";
            this.colLabel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "VIZCore3DX.NET.FrameEditor";
            this.tabLine.ResumeLayout(false);
            this.grpAxis.ResumeLayout(false);
            this.grpAxisSelect.ResumeLayout(false);
            this.tabAxis.ResumeLayout(false);
            this.grpPlane.ResumeLayout(false);
            this.grpSpace.ResumeLayout(false);
            this.tabFrame.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tblFrame.ResumeLayout(false);
            this.grpFrame.ResumeLayout(false);
            this.tblOpen.ResumeLayout(false);
            this.grpOpen.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numNewOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDivision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStrokeThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlaneThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpOpen;
        private System.Windows.Forms.TableLayoutPanel tblOpen;
        private System.Windows.Forms.Button btnModelOpen;
        private System.Windows.Forms.GroupBox grpFrame;
        private System.Windows.Forms.ComboBox cmbFrame;
        private System.Windows.Forms.TableLayoutPanel tblFrame;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabFrame;
        private System.Windows.Forms.GroupBox grpSpace;
        private System.Windows.Forms.Label lblSpaceMode;
        private System.Windows.Forms.ComboBox cmbSpaceMode;
        private System.Windows.Forms.Label lblSpaceMin;
        private System.Windows.Forms.Label lblSpaceMax;
        private System.Windows.Forms.Label lblMargin;
        private System.Windows.Forms.Label lblMinX;
        private System.Windows.Forms.NumericUpDown numMinX;
        private System.Windows.Forms.Label lblMinY;
        private System.Windows.Forms.NumericUpDown numMinY;
        private System.Windows.Forms.Label lblMinZ;
        private System.Windows.Forms.NumericUpDown numMinZ;
        private System.Windows.Forms.Label lblMaxX;
        private System.Windows.Forms.NumericUpDown numMaxX;
        private System.Windows.Forms.Label lblMaxY;
        private System.Windows.Forms.NumericUpDown numMaxY;
        private System.Windows.Forms.Label lblMaxZ;
        private System.Windows.Forms.NumericUpDown numMaxZ;
        private System.Windows.Forms.Label lblMarginX;
        private System.Windows.Forms.NumericUpDown numMarginX;
        private System.Windows.Forms.Label lblMarginY;
        private System.Windows.Forms.NumericUpDown numMarginY;
        private System.Windows.Forms.Label lblMarginZ;
        private System.Windows.Forms.NumericUpDown numMarginZ;
        private System.Windows.Forms.Label lblMarginType;
        private System.Windows.Forms.ComboBox cmbMarginType;
        private System.Windows.Forms.Label lblMarginHint;
        private System.Windows.Forms.GroupBox grpPlane;
        private System.Windows.Forms.CheckBox chkXY;
        private System.Windows.Forms.CheckBox chkYZ;
        private System.Windows.Forms.CheckBox chkZX;
        private System.Windows.Forms.Label lblPlaneColor;
        private System.Windows.Forms.Button btnPlaneColor;
        private System.Windows.Forms.Label lblPlanePattern;
        private System.Windows.Forms.ComboBox cmbPlanePattern;
        private System.Windows.Forms.Label lblPlaneThickness;
        private System.Windows.Forms.NumericUpDown numPlaneThickness;
        private System.Windows.Forms.Button btnApplyFrame;
        private System.Windows.Forms.TabPage tabAxis;
        private System.Windows.Forms.GroupBox grpAxisSelect;
        private System.Windows.Forms.RadioButton rdoAxisX;
        private System.Windows.Forms.RadioButton rdoAxisY;
        private System.Windows.Forms.RadioButton rdoAxisZ;
        private System.Windows.Forms.GroupBox grpAxis;
        private System.Windows.Forms.Label lblAxisLabel;
        private System.Windows.Forms.TextBox txtAxisLabel;
        private System.Windows.Forms.CheckBox chkLineEnabled;
        private System.Windows.Forms.Label lblLabelType;
        private System.Windows.Forms.ComboBox cmbLabelType;
        private System.Windows.Forms.Label lblTextColor;
        private System.Windows.Forms.Button btnTextColor;
        private System.Windows.Forms.Label lblStrokeColor;
        private System.Windows.Forms.Button btnStrokeColor;
        private System.Windows.Forms.Label lblStrokePattern;
        private System.Windows.Forms.ComboBox cmbStrokePattern;
        private System.Windows.Forms.Label lblStrokeThickness;
        private System.Windows.Forms.NumericUpDown numStrokeThickness;
        private System.Windows.Forms.Button btnApplyAxis;
        private System.Windows.Forms.TabPage tabLine;
        private System.Windows.Forms.Label lblLineAxis;
        private System.Windows.Forms.ComboBox cmbLineAxis;
        private System.Windows.Forms.CheckBox chkAllAxis;
        private System.Windows.Forms.ComboBox cmbAllAxisMode;
        private System.Windows.Forms.DataGridView dgvLine;
        private System.Windows.Forms.Label lblDivision;
        private System.Windows.Forms.NumericUpDown numDivision;
        private System.Windows.Forms.Button btnLineGenerate;
        private System.Windows.Forms.Label lblNewOffset;
        private System.Windows.Forms.NumericUpDown numNewOffset;
        private System.Windows.Forms.Button btnLineAdd;
        private System.Windows.Forms.Button btnLineRemove;
        private System.Windows.Forms.Button btnLineClear;
        private System.Windows.Forms.Button btnApplyLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOffset;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLabel;
    }
}
