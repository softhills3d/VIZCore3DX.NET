namespace VIZCore3DX.NET.DecalAnnotation
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelControl = new System.Windows.Forms.Panel();
            this.groupList = new System.Windows.Forms.GroupBox();
            this.tlpListActions = new System.Windows.Forms.TableLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnHideAll = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tlpJson = new System.Windows.Forms.TableLayoutPanel();
            this.btnExportJson = new System.Windows.Forms.Button();
            this.btnImportJson = new System.Windows.Forms.Button();
            this.dgvDecals = new System.Windows.Forms.DataGridView();
            this.lblDecalCount = new System.Windows.Forms.Label();
            this.groupEdit = new System.Windows.Forms.GroupBox();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.chkMovable = new System.Windows.Forms.CheckBox();
            this.chkSelectable = new System.Windows.Forms.CheckBox();
            this.tlpRotate = new System.Windows.Forms.TableLayoutPanel();
            this.btnRotateClockwise = new System.Windows.Forms.Button();
            this.btnRotateCounterClockwise = new System.Windows.Forms.Button();
            this.numRotationStep = new System.Windows.Forms.NumericUpDown();
            this.lblRotationStep = new System.Windows.Forms.Label();
            this.tlpEditVisible = new System.Windows.Forms.TableLayoutPanel();
            this.btnRelocate = new System.Windows.Forms.Button();
            this.btnShowSelected = new System.Windows.Forms.Button();
            this.btnHideSelected = new System.Windows.Forms.Button();
            this.lblSelectedRotation = new System.Windows.Forms.Label();
            this.lblSelectedPosition = new System.Windows.Forms.Label();
            this.lblSelectedInfo = new System.Windows.Forms.Label();
            this.groupCreate = new System.Windows.Forms.GroupBox();
            this.groupArrow = new System.Windows.Forms.GroupBox();
            this.tlpArrowApply = new System.Windows.Forms.TableLayoutPanel();
            this.btnApplyArrowStyle = new System.Windows.Forms.Button();
            this.btnApplyArrowLength = new System.Windows.Forms.Button();
            this.tlpArrowCreate = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddArrow = new System.Windows.Forms.Button();
            this.btnAddArrowTwoPoint = new System.Windows.Forms.Button();
            this.btnAddArrowDialog = new System.Windows.Forms.Button();
            this.chkArrowDoubleHeaded = new System.Windows.Forms.CheckBox();
            this.numArrowThickness = new System.Windows.Forms.NumericUpDown();
            this.lblArrowThickness = new System.Windows.Forms.Label();
            this.numArrowLength = new System.Windows.Forms.NumericUpDown();
            this.lblArrowLength = new System.Windows.Forms.Label();
            this.btnArrowColor = new System.Windows.Forms.Button();
            this.numArrowHeadSize = new System.Windows.Forms.NumericUpDown();
            this.lblArrowHeadSize = new System.Windows.Forms.Label();
            this.cmbArrowHeadKind = new System.Windows.Forms.ComboBox();
            this.lblArrowHeadKind = new System.Windows.Forms.Label();
            this.groupImage = new System.Windows.Forms.GroupBox();
            this.btnCreateImage = new System.Windows.Forms.Button();
            this.numImageAlpha = new System.Windows.Forms.NumericUpDown();
            this.lblImageAlpha = new System.Windows.Forms.Label();
            this.numImageWidth = new System.Windows.Forms.NumericUpDown();
            this.lblImageWidth = new System.Windows.Forms.Label();
            this.numImageHeight = new System.Windows.Forms.NumericUpDown();
            this.lblImageHeight = new System.Windows.Forms.Label();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.txtImageFile = new System.Windows.Forms.TextBox();
            this.groupText = new System.Windows.Forms.GroupBox();
            this.btnCreateText = new System.Windows.Forms.Button();
            this.numTextWidth = new System.Windows.Forms.NumericUpDown();
            this.lblTextWidth = new System.Windows.Forms.Label();
            this.numTextHeight = new System.Windows.Forms.NumericUpDown();
            this.lblTextHeight = new System.Windows.Forms.Label();
            this.btnTextColor = new System.Windows.Forms.Button();
            this.txtDecalText = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.btnFitToView = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRotation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.groupList.SuspendLayout();
            this.tlpListActions.SuspendLayout();
            this.tlpJson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDecals)).BeginInit();
            this.groupEdit.SuspendLayout();
            this.tlpRotate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRotationStep)).BeginInit();
            this.tlpEditVisible.SuspendLayout();
            this.groupCreate.SuspendLayout();
            this.groupArrow.SuspendLayout();
            this.tlpArrowApply.SuspendLayout();
            this.tlpArrowCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numArrowThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArrowLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArrowHeadSize)).BeginInit();
            this.groupImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImageWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImageHeight)).BeginInit();
            this.groupText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTextWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTextHeight)).BeginInit();
            this.tlpTop.SuspendLayout();
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
            this.splitContainer1.Panel1MinSize = 360;
            this.splitContainer1.Size = new System.Drawing.Size(1300, 900);
            this.splitContainer1.SplitterDistance = 440;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelControl
            // 
            this.panelControl.AutoScroll = true;
            this.panelControl.AutoScrollMinSize = new System.Drawing.Size(0, 900);
            this.panelControl.Controls.Add(this.groupList);
            this.panelControl.Controls.Add(this.groupEdit);
            this.panelControl.Controls.Add(this.groupCreate);
            this.panelControl.Controls.Add(this.tlpTop);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(440, 900);
            this.panelControl.TabIndex = 0;
            // 
            // groupList
            // 
            this.groupList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupList.Controls.Add(this.tlpListActions);
            this.groupList.Controls.Add(this.tlpJson);
            this.groupList.Controls.Add(this.dgvDecals);
            this.groupList.Controls.Add(this.lblDecalCount);
            this.groupList.Location = new System.Drawing.Point(10, 682);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(420, 208);
            this.groupList.TabIndex = 4;
            this.groupList.TabStop = false;
            this.groupList.Text = "Decal 목록";
            // 
            // tlpListActions
            // 
            this.tlpListActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpListActions.ColumnCount = 4;
            this.tlpListActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpListActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpListActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpListActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpListActions.Controls.Add(this.btnRefresh, 0, 0);
            this.tlpListActions.Controls.Add(this.btnShowAll, 1, 0);
            this.tlpListActions.Controls.Add(this.btnHideAll, 2, 0);
            this.tlpListActions.Controls.Add(this.btnClear, 3, 0);
            this.tlpListActions.Location = new System.Drawing.Point(7, 166);
            this.tlpListActions.Name = "tlpListActions";
            this.tlpListActions.RowCount = 1;
            this.tlpListActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpListActions.Size = new System.Drawing.Size(406, 34);
            this.tlpListActions.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(95, 28);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowAll.Location = new System.Drawing.Point(104, 3);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(95, 28);
            this.btnShowAll.TabIndex = 1;
            this.btnShowAll.Text = "전체 표시";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnHideAll
            // 
            this.btnHideAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHideAll.Location = new System.Drawing.Point(205, 3);
            this.btnHideAll.Name = "btnHideAll";
            this.btnHideAll.Size = new System.Drawing.Size(95, 28);
            this.btnHideAll.TabIndex = 2;
            this.btnHideAll.Text = "전체 숨김";
            this.btnHideAll.UseVisualStyleBackColor = true;
            this.btnHideAll.Click += new System.EventHandler(this.btnHideAll_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(306, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(97, 28);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "전체 삭제";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tlpJson
            // 
            this.tlpJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpJson.ColumnCount = 2;
            this.tlpJson.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tlpJson.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56F));
            this.tlpJson.Controls.Add(this.btnExportJson, 0, 0);
            this.tlpJson.Controls.Add(this.btnImportJson, 1, 0);
            this.tlpJson.Location = new System.Drawing.Point(113, 18);
            this.tlpJson.Name = "tlpJson";
            this.tlpJson.RowCount = 1;
            this.tlpJson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpJson.Size = new System.Drawing.Size(300, 34);
            this.tlpJson.TabIndex = 1;
            // 
            // btnExportJson
            // 
            this.btnExportJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportJson.Location = new System.Drawing.Point(3, 3);
            this.btnExportJson.Name = "btnExportJson";
            this.btnExportJson.Size = new System.Drawing.Size(126, 28);
            this.btnExportJson.TabIndex = 0;
            this.btnExportJson.Text = "JSON 저장";
            this.btnExportJson.UseVisualStyleBackColor = true;
            this.btnExportJson.Click += new System.EventHandler(this.btnExportJson_Click);
            // 
            // btnImportJson
            // 
            this.btnImportJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportJson.Location = new System.Drawing.Point(135, 3);
            this.btnImportJson.Name = "btnImportJson";
            this.btnImportJson.Size = new System.Drawing.Size(162, 28);
            this.btnImportJson.TabIndex = 1;
            this.btnImportJson.Text = "JSON 불러오기";
            this.btnImportJson.UseVisualStyleBackColor = true;
            this.btnImportJson.Click += new System.EventHandler(this.btnImportJson_Click);
            // 
            // dgvDecals
            // 
            this.dgvDecals.AllowUserToAddRows = false;
            this.dgvDecals.AllowUserToDeleteRows = false;
            this.dgvDecals.AllowUserToResizeRows = false;
            this.dgvDecals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDecals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDecals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDecals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colType,
            this.colContent,
            this.colVisible,
            this.colRotation});
            this.dgvDecals.Location = new System.Drawing.Point(10, 58);
            this.dgvDecals.MultiSelect = false;
            this.dgvDecals.Name = "dgvDecals";
            this.dgvDecals.ReadOnly = true;
            this.dgvDecals.RowHeadersVisible = false;
            this.dgvDecals.RowTemplate.Height = 23;
            this.dgvDecals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDecals.Size = new System.Drawing.Size(400, 102);
            this.dgvDecals.TabIndex = 2;
            this.dgvDecals.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDecals_CellClick);
            this.dgvDecals.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDecals_CellContentClick);
            // 
            // lblDecalCount
            // 
            this.lblDecalCount.AutoSize = true;
            this.lblDecalCount.Location = new System.Drawing.Point(10, 30);
            this.lblDecalCount.Name = "lblDecalCount";
            this.lblDecalCount.Size = new System.Drawing.Size(55, 12);
            this.lblDecalCount.TabIndex = 0;
            this.lblDecalCount.Text = "Decal : 0";
            // 
            // groupEdit
            // 
            this.groupEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupEdit.Controls.Add(this.btnDeleteSelected);
            this.groupEdit.Controls.Add(this.chkMovable);
            this.groupEdit.Controls.Add(this.chkSelectable);
            this.groupEdit.Controls.Add(this.tlpRotate);
            this.groupEdit.Controls.Add(this.numRotationStep);
            this.groupEdit.Controls.Add(this.lblRotationStep);
            this.groupEdit.Controls.Add(this.tlpEditVisible);
            this.groupEdit.Controls.Add(this.lblSelectedRotation);
            this.groupEdit.Controls.Add(this.lblSelectedPosition);
            this.groupEdit.Controls.Add(this.lblSelectedInfo);
            this.groupEdit.Location = new System.Drawing.Point(10, 484);
            this.groupEdit.Name = "groupEdit";
            this.groupEdit.Size = new System.Drawing.Size(420, 190);
            this.groupEdit.TabIndex = 3;
            this.groupEdit.TabStop = false;
            this.groupEdit.Text = "선택 Decal";
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSelected.Location = new System.Drawing.Point(260, 154);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(150, 28);
            this.btnDeleteSelected.TabIndex = 9;
            this.btnDeleteSelected.Text = "선택 Decal 삭제";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // chkMovable
            // 
            this.chkMovable.AutoSize = true;
            this.chkMovable.Location = new System.Drawing.Point(110, 160);
            this.chkMovable.Name = "chkMovable";
            this.chkMovable.Size = new System.Drawing.Size(76, 16);
            this.chkMovable.TabIndex = 8;
            this.chkMovable.Text = "이동 가능";
            this.chkMovable.UseVisualStyleBackColor = true;
            this.chkMovable.CheckedChanged += new System.EventHandler(this.chkMovable_CheckedChanged);
            // 
            // chkSelectable
            // 
            this.chkSelectable.AutoSize = true;
            this.chkSelectable.Location = new System.Drawing.Point(12, 160);
            this.chkSelectable.Name = "chkSelectable";
            this.chkSelectable.Size = new System.Drawing.Size(76, 16);
            this.chkSelectable.TabIndex = 7;
            this.chkSelectable.Text = "선택 가능";
            this.chkSelectable.UseVisualStyleBackColor = true;
            this.chkSelectable.CheckedChanged += new System.EventHandler(this.chkSelectable_CheckedChanged);
            // 
            // tlpRotate
            // 
            this.tlpRotate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpRotate.ColumnCount = 2;
            this.tlpRotate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRotate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRotate.Controls.Add(this.btnRotateClockwise, 0, 0);
            this.tlpRotate.Controls.Add(this.btnRotateCounterClockwise, 1, 0);
            this.tlpRotate.Location = new System.Drawing.Point(183, 114);
            this.tlpRotate.Name = "tlpRotate";
            this.tlpRotate.RowCount = 1;
            this.tlpRotate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRotate.Size = new System.Drawing.Size(230, 34);
            this.tlpRotate.TabIndex = 6;
            // 
            // btnRotateClockwise
            // 
            this.btnRotateClockwise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRotateClockwise.Location = new System.Drawing.Point(3, 3);
            this.btnRotateClockwise.Name = "btnRotateClockwise";
            this.btnRotateClockwise.Size = new System.Drawing.Size(109, 28);
            this.btnRotateClockwise.TabIndex = 0;
            this.btnRotateClockwise.Text = "↻ 시계 회전";
            this.btnRotateClockwise.UseVisualStyleBackColor = true;
            this.btnRotateClockwise.Click += new System.EventHandler(this.btnRotateClockwise_Click);
            // 
            // btnRotateCounterClockwise
            // 
            this.btnRotateCounterClockwise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRotateCounterClockwise.Location = new System.Drawing.Point(118, 3);
            this.btnRotateCounterClockwise.Name = "btnRotateCounterClockwise";
            this.btnRotateCounterClockwise.Size = new System.Drawing.Size(109, 28);
            this.btnRotateCounterClockwise.TabIndex = 1;
            this.btnRotateCounterClockwise.Text = "↺ 반시계 회전";
            this.btnRotateCounterClockwise.UseVisualStyleBackColor = true;
            this.btnRotateCounterClockwise.Click += new System.EventHandler(this.btnRotateCounterClockwise_Click);
            // 
            // numRotationStep
            // 
            this.numRotationStep.DecimalPlaces = 1;
            this.numRotationStep.Location = new System.Drawing.Point(95, 120);
            this.numRotationStep.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numRotationStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRotationStep.Name = "numRotationStep";
            this.numRotationStep.Size = new System.Drawing.Size(80, 21);
            this.numRotationStep.TabIndex = 5;
            this.numRotationStep.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.numRotationStep.ValueChanged += new System.EventHandler(this.numRotationStep_ValueChanged);
            // 
            // lblRotationStep
            // 
            this.lblRotationStep.AutoSize = true;
            this.lblRotationStep.Location = new System.Drawing.Point(10, 124);
            this.lblRotationStep.Name = "lblRotationStep";
            this.lblRotationStep.Size = new System.Drawing.Size(76, 12);
            this.lblRotationStep.TabIndex = 4;
            this.lblRotationStep.Text = "회전 Step (°)";
            // 
            // tlpEditVisible
            // 
            this.tlpEditVisible.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpEditVisible.ColumnCount = 3;
            this.tlpEditVisible.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpEditVisible.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpEditVisible.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpEditVisible.Controls.Add(this.btnRelocate, 0, 0);
            this.tlpEditVisible.Controls.Add(this.btnShowSelected, 1, 0);
            this.tlpEditVisible.Controls.Add(this.btnHideSelected, 2, 0);
            this.tlpEditVisible.Location = new System.Drawing.Point(7, 76);
            this.tlpEditVisible.Name = "tlpEditVisible";
            this.tlpEditVisible.RowCount = 1;
            this.tlpEditVisible.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEditVisible.Size = new System.Drawing.Size(406, 34);
            this.tlpEditVisible.TabIndex = 3;
            // 
            // btnRelocate
            // 
            this.btnRelocate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRelocate.Location = new System.Drawing.Point(3, 3);
            this.btnRelocate.Name = "btnRelocate";
            this.btnRelocate.Size = new System.Drawing.Size(129, 28);
            this.btnRelocate.TabIndex = 0;
            this.btnRelocate.Text = "표면 재지정";
            this.btnRelocate.UseVisualStyleBackColor = true;
            this.btnRelocate.Click += new System.EventHandler(this.btnRelocate_Click);
            // 
            // btnShowSelected
            // 
            this.btnShowSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowSelected.Location = new System.Drawing.Point(138, 3);
            this.btnShowSelected.Name = "btnShowSelected";
            this.btnShowSelected.Size = new System.Drawing.Size(129, 28);
            this.btnShowSelected.TabIndex = 1;
            this.btnShowSelected.Text = "표시";
            this.btnShowSelected.UseVisualStyleBackColor = true;
            this.btnShowSelected.Click += new System.EventHandler(this.btnShowSelected_Click);
            // 
            // btnHideSelected
            // 
            this.btnHideSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHideSelected.Location = new System.Drawing.Point(273, 3);
            this.btnHideSelected.Name = "btnHideSelected";
            this.btnHideSelected.Size = new System.Drawing.Size(130, 28);
            this.btnHideSelected.TabIndex = 2;
            this.btnHideSelected.Text = "숨김";
            this.btnHideSelected.UseVisualStyleBackColor = true;
            this.btnHideSelected.Click += new System.EventHandler(this.btnHideSelected_Click);
            // 
            // lblSelectedRotation
            // 
            this.lblSelectedRotation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedRotation.AutoEllipsis = true;
            this.lblSelectedRotation.Location = new System.Drawing.Point(10, 56);
            this.lblSelectedRotation.Name = "lblSelectedRotation";
            this.lblSelectedRotation.Size = new System.Drawing.Size(400, 17);
            this.lblSelectedRotation.TabIndex = 2;
            this.lblSelectedRotation.Text = "Rotation : -";
            this.lblSelectedRotation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSelectedPosition
            // 
            this.lblSelectedPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedPosition.AutoEllipsis = true;
            this.lblSelectedPosition.Location = new System.Drawing.Point(10, 38);
            this.lblSelectedPosition.Name = "lblSelectedPosition";
            this.lblSelectedPosition.Size = new System.Drawing.Size(400, 17);
            this.lblSelectedPosition.TabIndex = 1;
            this.lblSelectedPosition.Text = "Position : -";
            this.lblSelectedPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSelectedInfo
            // 
            this.lblSelectedInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedInfo.AutoEllipsis = true;
            this.lblSelectedInfo.Location = new System.Drawing.Point(10, 20);
            this.lblSelectedInfo.Name = "lblSelectedInfo";
            this.lblSelectedInfo.Size = new System.Drawing.Size(400, 17);
            this.lblSelectedInfo.TabIndex = 0;
            this.lblSelectedInfo.Text = "선택된 Decal : 없음";
            this.lblSelectedInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupCreate
            // 
            this.groupCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCreate.Controls.Add(this.groupArrow);
            this.groupCreate.Controls.Add(this.groupImage);
            this.groupCreate.Controls.Add(this.groupText);
            this.groupCreate.Location = new System.Drawing.Point(10, 54);
            this.groupCreate.Name = "groupCreate";
            this.groupCreate.Size = new System.Drawing.Size(420, 422);
            this.groupCreate.TabIndex = 2;
            this.groupCreate.TabStop = false;
            this.groupCreate.Text = "Decal 생성";
            // 
            // groupArrow
            // 
            this.groupArrow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupArrow.Controls.Add(this.tlpArrowApply);
            this.groupArrow.Controls.Add(this.tlpArrowCreate);
            this.groupArrow.Controls.Add(this.chkArrowDoubleHeaded);
            this.groupArrow.Controls.Add(this.numArrowThickness);
            this.groupArrow.Controls.Add(this.lblArrowThickness);
            this.groupArrow.Controls.Add(this.numArrowLength);
            this.groupArrow.Controls.Add(this.lblArrowLength);
            this.groupArrow.Controls.Add(this.btnArrowColor);
            this.groupArrow.Controls.Add(this.numArrowHeadSize);
            this.groupArrow.Controls.Add(this.lblArrowHeadSize);
            this.groupArrow.Controls.Add(this.cmbArrowHeadKind);
            this.groupArrow.Controls.Add(this.lblArrowHeadKind);
            this.groupArrow.Location = new System.Drawing.Point(10, 258);
            this.groupArrow.Name = "groupArrow";
            this.groupArrow.Size = new System.Drawing.Size(400, 156);
            this.groupArrow.TabIndex = 2;
            this.groupArrow.TabStop = false;
            this.groupArrow.Text = "Arrow Decal";
            // 
            // tlpArrowApply
            // 
            this.tlpArrowApply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpArrowApply.ColumnCount = 2;
            this.tlpArrowApply.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpArrowApply.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpArrowApply.Controls.Add(this.btnApplyArrowStyle, 0, 0);
            this.tlpArrowApply.Controls.Add(this.btnApplyArrowLength, 1, 0);
            this.tlpArrowApply.Location = new System.Drawing.Point(7, 114);
            this.tlpArrowApply.Name = "tlpArrowApply";
            this.tlpArrowApply.RowCount = 1;
            this.tlpArrowApply.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpArrowApply.Size = new System.Drawing.Size(386, 34);
            this.tlpArrowApply.TabIndex = 11;
            // 
            // btnApplyArrowStyle
            // 
            this.btnApplyArrowStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApplyArrowStyle.Location = new System.Drawing.Point(3, 3);
            this.btnApplyArrowStyle.Name = "btnApplyArrowStyle";
            this.btnApplyArrowStyle.Size = new System.Drawing.Size(187, 28);
            this.btnApplyArrowStyle.TabIndex = 0;
            this.btnApplyArrowStyle.Text = "선택 화살표에 스타일 적용";
            this.btnApplyArrowStyle.UseVisualStyleBackColor = true;
            this.btnApplyArrowStyle.Click += new System.EventHandler(this.btnApplyArrowStyle_Click);
            // 
            // btnApplyArrowLength
            // 
            this.btnApplyArrowLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApplyArrowLength.Location = new System.Drawing.Point(196, 3);
            this.btnApplyArrowLength.Name = "btnApplyArrowLength";
            this.btnApplyArrowLength.Size = new System.Drawing.Size(187, 28);
            this.btnApplyArrowLength.TabIndex = 1;
            this.btnApplyArrowLength.Text = "선택 화살표에 길이 적용";
            this.btnApplyArrowLength.UseVisualStyleBackColor = true;
            this.btnApplyArrowLength.Click += new System.EventHandler(this.btnApplyArrowLength_Click);
            // 
            // tlpArrowCreate
            // 
            this.tlpArrowCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpArrowCreate.ColumnCount = 3;
            this.tlpArrowCreate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpArrowCreate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpArrowCreate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpArrowCreate.Controls.Add(this.btnAddArrow, 0, 0);
            this.tlpArrowCreate.Controls.Add(this.btnAddArrowTwoPoint, 1, 0);
            this.tlpArrowCreate.Controls.Add(this.btnAddArrowDialog, 2, 0);
            this.tlpArrowCreate.Location = new System.Drawing.Point(7, 76);
            this.tlpArrowCreate.Name = "tlpArrowCreate";
            this.tlpArrowCreate.RowCount = 1;
            this.tlpArrowCreate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpArrowCreate.Size = new System.Drawing.Size(386, 34);
            this.tlpArrowCreate.TabIndex = 10;
            // 
            // btnAddArrow
            // 
            this.btnAddArrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddArrow.Location = new System.Drawing.Point(3, 3);
            this.btnAddArrow.Name = "btnAddArrow";
            this.btnAddArrow.Size = new System.Drawing.Size(122, 28);
            this.btnAddArrow.TabIndex = 0;
            this.btnAddArrow.Text = "위치 + 길이 생성";
            this.btnAddArrow.UseVisualStyleBackColor = true;
            this.btnAddArrow.Click += new System.EventHandler(this.btnAddArrow_Click);
            // 
            // btnAddArrowTwoPoint
            // 
            this.btnAddArrowTwoPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddArrowTwoPoint.Location = new System.Drawing.Point(131, 3);
            this.btnAddArrowTwoPoint.Name = "btnAddArrowTwoPoint";
            this.btnAddArrowTwoPoint.Size = new System.Drawing.Size(122, 28);
            this.btnAddArrowTwoPoint.TabIndex = 1;
            this.btnAddArrowTwoPoint.Text = "시작점·끝점 생성";
            this.btnAddArrowTwoPoint.UseVisualStyleBackColor = true;
            this.btnAddArrowTwoPoint.Click += new System.EventHandler(this.btnAddArrowTwoPoint_Click);
            // 
            // btnAddArrowDialog
            // 
            this.btnAddArrowDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddArrowDialog.Location = new System.Drawing.Point(259, 3);
            this.btnAddArrowDialog.Name = "btnAddArrowDialog";
            this.btnAddArrowDialog.Size = new System.Drawing.Size(124, 28);
            this.btnAddArrowDialog.TabIndex = 2;
            this.btnAddArrowDialog.Text = "대화상자로 생성";
            this.btnAddArrowDialog.UseVisualStyleBackColor = true;
            this.btnAddArrowDialog.Click += new System.EventHandler(this.btnAddArrowDialog_Click);
            // 
            // chkArrowDoubleHeaded
            // 
            this.chkArrowDoubleHeaded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkArrowDoubleHeaded.AutoSize = true;
            this.chkArrowDoubleHeaded.Location = new System.Drawing.Point(312, 53);
            this.chkArrowDoubleHeaded.Name = "chkArrowDoubleHeaded";
            this.chkArrowDoubleHeaded.Size = new System.Drawing.Size(64, 16);
            this.chkArrowDoubleHeaded.TabIndex = 9;
            this.chkArrowDoubleHeaded.Text = "양쪽 촉";
            this.chkArrowDoubleHeaded.UseVisualStyleBackColor = true;
            // 
            // numArrowThickness
            // 
            this.numArrowThickness.DecimalPlaces = 1;
            this.numArrowThickness.Location = new System.Drawing.Point(226, 50);
            this.numArrowThickness.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numArrowThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numArrowThickness.Name = "numArrowThickness";
            this.numArrowThickness.Size = new System.Drawing.Size(74, 21);
            this.numArrowThickness.TabIndex = 8;
            this.numArrowThickness.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblArrowThickness
            // 
            this.lblArrowThickness.AutoSize = true;
            this.lblArrowThickness.Location = new System.Drawing.Point(175, 54);
            this.lblArrowThickness.Name = "lblArrowThickness";
            this.lblArrowThickness.Size = new System.Drawing.Size(29, 12);
            this.lblArrowThickness.TabIndex = 7;
            this.lblArrowThickness.Text = "굵기";
            // 
            // numArrowLength
            // 
            this.numArrowLength.DecimalPlaces = 1;
            this.numArrowLength.Location = new System.Drawing.Point(60, 50);
            this.numArrowLength.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numArrowLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numArrowLength.Name = "numArrowLength";
            this.numArrowLength.Size = new System.Drawing.Size(105, 21);
            this.numArrowLength.TabIndex = 6;
            this.numArrowLength.Value = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            // 
            // lblArrowLength
            // 
            this.lblArrowLength.AutoSize = true;
            this.lblArrowLength.Location = new System.Drawing.Point(10, 54);
            this.lblArrowLength.Name = "lblArrowLength";
            this.lblArrowLength.Size = new System.Drawing.Size(29, 12);
            this.lblArrowLength.TabIndex = 5;
            this.lblArrowLength.Text = "길이";
            // 
            // btnArrowColor
            // 
            this.btnArrowColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArrowColor.BackColor = System.Drawing.Color.Red;
            this.btnArrowColor.Location = new System.Drawing.Point(310, 20);
            this.btnArrowColor.Name = "btnArrowColor";
            this.btnArrowColor.Size = new System.Drawing.Size(80, 24);
            this.btnArrowColor.TabIndex = 4;
            this.btnArrowColor.Text = "색상";
            this.btnArrowColor.UseVisualStyleBackColor = false;
            this.btnArrowColor.Click += new System.EventHandler(this.btnArrowColor_Click);
            // 
            // numArrowHeadSize
            // 
            this.numArrowHeadSize.DecimalPlaces = 1;
            this.numArrowHeadSize.Location = new System.Drawing.Point(226, 22);
            this.numArrowHeadSize.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numArrowHeadSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numArrowHeadSize.Name = "numArrowHeadSize";
            this.numArrowHeadSize.Size = new System.Drawing.Size(74, 21);
            this.numArrowHeadSize.TabIndex = 3;
            this.numArrowHeadSize.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // lblArrowHeadSize
            // 
            this.lblArrowHeadSize.AutoSize = true;
            this.lblArrowHeadSize.Location = new System.Drawing.Point(175, 26);
            this.lblArrowHeadSize.Name = "lblArrowHeadSize";
            this.lblArrowHeadSize.Size = new System.Drawing.Size(45, 12);
            this.lblArrowHeadSize.TabIndex = 2;
            this.lblArrowHeadSize.Text = "촉 크기";
            // 
            // cmbArrowHeadKind
            // 
            this.cmbArrowHeadKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArrowHeadKind.FormattingEnabled = true;
            this.cmbArrowHeadKind.Location = new System.Drawing.Point(60, 22);
            this.cmbArrowHeadKind.Name = "cmbArrowHeadKind";
            this.cmbArrowHeadKind.Size = new System.Drawing.Size(105, 20);
            this.cmbArrowHeadKind.TabIndex = 1;
            // 
            // lblArrowHeadKind
            // 
            this.lblArrowHeadKind.AutoSize = true;
            this.lblArrowHeadKind.Location = new System.Drawing.Point(10, 26);
            this.lblArrowHeadKind.Name = "lblArrowHeadKind";
            this.lblArrowHeadKind.Size = new System.Drawing.Size(45, 12);
            this.lblArrowHeadKind.TabIndex = 0;
            this.lblArrowHeadKind.Text = "촉 모양";
            // 
            // groupImage
            // 
            this.groupImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupImage.Controls.Add(this.btnCreateImage);
            this.groupImage.Controls.Add(this.numImageAlpha);
            this.groupImage.Controls.Add(this.lblImageAlpha);
            this.groupImage.Controls.Add(this.numImageWidth);
            this.groupImage.Controls.Add(this.lblImageWidth);
            this.groupImage.Controls.Add(this.numImageHeight);
            this.groupImage.Controls.Add(this.lblImageHeight);
            this.groupImage.Controls.Add(this.btnBrowseImage);
            this.groupImage.Controls.Add(this.txtImageFile);
            this.groupImage.Location = new System.Drawing.Point(10, 139);
            this.groupImage.Name = "groupImage";
            this.groupImage.Size = new System.Drawing.Size(400, 113);
            this.groupImage.TabIndex = 1;
            this.groupImage.TabStop = false;
            this.groupImage.Text = "Image Decal";
            // 
            // btnCreateImage
            // 
            this.btnCreateImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateImage.Location = new System.Drawing.Point(180, 77);
            this.btnCreateImage.Name = "btnCreateImage";
            this.btnCreateImage.Size = new System.Drawing.Size(210, 28);
            this.btnCreateImage.TabIndex = 8;
            this.btnCreateImage.Text = "모델 표면에 Image Decal 생성";
            this.btnCreateImage.UseVisualStyleBackColor = true;
            this.btnCreateImage.Click += new System.EventHandler(this.btnCreateImage_Click);
            // 
            // numImageAlpha
            // 
            this.numImageAlpha.DecimalPlaces = 2;
            this.numImageAlpha.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numImageAlpha.Location = new System.Drawing.Point(90, 81);
            this.numImageAlpha.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numImageAlpha.Name = "numImageAlpha";
            this.numImageAlpha.Size = new System.Drawing.Size(75, 21);
            this.numImageAlpha.TabIndex = 7;
            this.numImageAlpha.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblImageAlpha
            // 
            this.lblImageAlpha.AutoSize = true;
            this.lblImageAlpha.Location = new System.Drawing.Point(10, 85);
            this.lblImageAlpha.Name = "lblImageAlpha";
            this.lblImageAlpha.Size = new System.Drawing.Size(72, 12);
            this.lblImageAlpha.TabIndex = 6;
            this.lblImageAlpha.Text = "Alpha (0~1)";
            // 
            // numImageWidth
            // 
            this.numImageWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numImageWidth.DecimalPlaces = 1;
            this.numImageWidth.Location = new System.Drawing.Point(280, 50);
            this.numImageWidth.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numImageWidth.Name = "numImageWidth";
            this.numImageWidth.Size = new System.Drawing.Size(110, 21);
            this.numImageWidth.TabIndex = 5;
            // 
            // lblImageWidth
            // 
            this.lblImageWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageWidth.AutoSize = true;
            this.lblImageWidth.Location = new System.Drawing.Point(188, 54);
            this.lblImageWidth.Name = "lblImageWidth";
            this.lblImageWidth.Size = new System.Drawing.Size(86, 12);
            this.lblImageWidth.TabIndex = 4;
            this.lblImageWidth.Text = "Width (0=Auto)";
            // 
            // numImageHeight
            // 
            this.numImageHeight.DecimalPlaces = 1;
            this.numImageHeight.Location = new System.Drawing.Point(55, 50);
            this.numImageHeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numImageHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numImageHeight.Name = "numImageHeight";
            this.numImageHeight.Size = new System.Drawing.Size(110, 21);
            this.numImageHeight.TabIndex = 3;
            this.numImageHeight.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // lblImageHeight
            // 
            this.lblImageHeight.AutoSize = true;
            this.lblImageHeight.Location = new System.Drawing.Point(10, 54);
            this.lblImageHeight.Name = "lblImageHeight";
            this.lblImageHeight.Size = new System.Drawing.Size(40, 12);
            this.lblImageHeight.TabIndex = 2;
            this.lblImageHeight.Text = "Height";
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseImage.Location = new System.Drawing.Point(295, 21);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(95, 24);
            this.btnBrowseImage.TabIndex = 1;
            this.btnBrowseImage.Text = "이미지 선택";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // txtImageFile
            // 
            this.txtImageFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImageFile.Location = new System.Drawing.Point(10, 22);
            this.txtImageFile.Name = "txtImageFile";
            this.txtImageFile.ReadOnly = true;
            this.txtImageFile.Size = new System.Drawing.Size(279, 21);
            this.txtImageFile.TabIndex = 0;
            // 
            // groupText
            // 
            this.groupText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupText.Controls.Add(this.btnCreateText);
            this.groupText.Controls.Add(this.numTextWidth);
            this.groupText.Controls.Add(this.lblTextWidth);
            this.groupText.Controls.Add(this.numTextHeight);
            this.groupText.Controls.Add(this.lblTextHeight);
            this.groupText.Controls.Add(this.btnTextColor);
            this.groupText.Controls.Add(this.txtDecalText);
            this.groupText.Controls.Add(this.lblText);
            this.groupText.Location = new System.Drawing.Point(10, 20);
            this.groupText.Name = "groupText";
            this.groupText.Size = new System.Drawing.Size(400, 113);
            this.groupText.TabIndex = 0;
            this.groupText.TabStop = false;
            this.groupText.Text = "Text Decal";
            // 
            // btnCreateText
            // 
            this.btnCreateText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateText.Location = new System.Drawing.Point(10, 77);
            this.btnCreateText.Name = "btnCreateText";
            this.btnCreateText.Size = new System.Drawing.Size(380, 28);
            this.btnCreateText.TabIndex = 7;
            this.btnCreateText.Text = "모델 표면에 Text Decal 생성";
            this.btnCreateText.UseVisualStyleBackColor = true;
            this.btnCreateText.Click += new System.EventHandler(this.btnCreateText_Click);
            // 
            // numTextWidth
            // 
            this.numTextWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTextWidth.DecimalPlaces = 1;
            this.numTextWidth.Location = new System.Drawing.Point(280, 50);
            this.numTextWidth.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numTextWidth.Name = "numTextWidth";
            this.numTextWidth.Size = new System.Drawing.Size(110, 21);
            this.numTextWidth.TabIndex = 6;
            // 
            // lblTextWidth
            // 
            this.lblTextWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextWidth.AutoSize = true;
            this.lblTextWidth.Location = new System.Drawing.Point(188, 54);
            this.lblTextWidth.Name = "lblTextWidth";
            this.lblTextWidth.Size = new System.Drawing.Size(86, 12);
            this.lblTextWidth.TabIndex = 5;
            this.lblTextWidth.Text = "Width (0=Auto)";
            // 
            // numTextHeight
            // 
            this.numTextHeight.DecimalPlaces = 1;
            this.numTextHeight.Location = new System.Drawing.Point(55, 50);
            this.numTextHeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numTextHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTextHeight.Name = "numTextHeight";
            this.numTextHeight.Size = new System.Drawing.Size(110, 21);
            this.numTextHeight.TabIndex = 4;
            this.numTextHeight.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // lblTextHeight
            // 
            this.lblTextHeight.AutoSize = true;
            this.lblTextHeight.Location = new System.Drawing.Point(10, 54);
            this.lblTextHeight.Name = "lblTextHeight";
            this.lblTextHeight.Size = new System.Drawing.Size(40, 12);
            this.lblTextHeight.TabIndex = 3;
            this.lblTextHeight.Text = "Height";
            // 
            // btnTextColor
            // 
            this.btnTextColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTextColor.BackColor = System.Drawing.Color.Red;
            this.btnTextColor.Location = new System.Drawing.Point(295, 21);
            this.btnTextColor.Name = "btnTextColor";
            this.btnTextColor.Size = new System.Drawing.Size(95, 24);
            this.btnTextColor.TabIndex = 2;
            this.btnTextColor.Text = "문자 색상";
            this.btnTextColor.UseVisualStyleBackColor = false;
            this.btnTextColor.Click += new System.EventHandler(this.btnTextColor_Click);
            // 
            // txtDecalText
            // 
            this.txtDecalText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecalText.Location = new System.Drawing.Point(55, 22);
            this.txtDecalText.Name = "txtDecalText";
            this.txtDecalText.Size = new System.Drawing.Size(234, 21);
            this.txtDecalText.TabIndex = 1;
            this.txtDecalText.Text = "DECAL";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(10, 26);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(30, 12);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Text";
            // 
            // tlpTop
            // 
            this.tlpTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpTop.ColumnCount = 2;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpTop.Controls.Add(this.btnOpenModel, 0, 0);
            this.tlpTop.Controls.Add(this.btnFitToView, 1, 0);
            this.tlpTop.Location = new System.Drawing.Point(7, 10);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Size = new System.Drawing.Size(426, 36);
            this.tlpTop.TabIndex = 0;
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenModel.Location = new System.Drawing.Point(3, 3);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(292, 30);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "모델 열기";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // btnFitToView
            // 
            this.btnFitToView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFitToView.Location = new System.Drawing.Point(301, 3);
            this.btnFitToView.Name = "btnFitToView";
            this.btnFitToView.Size = new System.Drawing.Size(122, 30);
            this.btnFitToView.TabIndex = 1;
            this.btnFitToView.Text = "화면 맞춤";
            this.btnFitToView.UseVisualStyleBackColor = true;
            this.btnFitToView.Click += new System.EventHandler(this.btnFitToView_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif|PNG Files|*.png|JPEG Files|*.jpg;*.jpe" +
    "g|Bitmap Files|*.bmp|All Files|*.*";
            this.openFileDialogImage.Title = "Decal 이미지 선택";
            // 
            // colNo
            // 
            this.colNo.FillWeight = 35F;
            this.colNo.HeaderText = "No.";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            // 
            // colType
            // 
            this.colType.FillWeight = 55F;
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            // 
            // colContent
            // 
            this.colContent.FillWeight = 167F;
            this.colContent.HeaderText = "Content";
            this.colContent.Name = "colContent";
            this.colContent.ReadOnly = true;
            // 
            // colVisible
            // 
            this.colVisible.FillWeight = 53F;
            this.colVisible.HeaderText = "표시";
            this.colVisible.Name = "colVisible";
            this.colVisible.ReadOnly = true;
            // 
            // colRotation
            // 
            this.colRotation.FillWeight = 65F;
            this.colRotation.HeaderText = "회전(°)";
            this.colRotation.Name = "colRotation";
            this.colRotation.ReadOnly = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 900);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1100, 760);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.DecalAnnotation";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.groupList.ResumeLayout(false);
            this.groupList.PerformLayout();
            this.tlpListActions.ResumeLayout(false);
            this.tlpJson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDecals)).EndInit();
            this.groupEdit.ResumeLayout(false);
            this.groupEdit.PerformLayout();
            this.tlpRotate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numRotationStep)).EndInit();
            this.tlpEditVisible.ResumeLayout(false);
            this.groupCreate.ResumeLayout(false);
            this.groupArrow.ResumeLayout(false);
            this.groupArrow.PerformLayout();
            this.tlpArrowApply.ResumeLayout(false);
            this.tlpArrowCreate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numArrowThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArrowLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArrowHeadSize)).EndInit();
            this.groupImage.ResumeLayout(false);
            this.groupImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImageWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImageHeight)).EndInit();
            this.groupText.ResumeLayout(false);
            this.groupText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTextWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTextHeight)).EndInit();
            this.tlpTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Button btnFitToView;

        private System.Windows.Forms.GroupBox groupCreate;
        private System.Windows.Forms.GroupBox groupText;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtDecalText;
        private System.Windows.Forms.Button btnTextColor;
        private System.Windows.Forms.Label lblTextHeight;
        private System.Windows.Forms.NumericUpDown numTextHeight;
        private System.Windows.Forms.Label lblTextWidth;
        private System.Windows.Forms.NumericUpDown numTextWidth;
        private System.Windows.Forms.Button btnCreateText;

        private System.Windows.Forms.GroupBox groupImage;
        private System.Windows.Forms.TextBox txtImageFile;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Label lblImageHeight;
        private System.Windows.Forms.NumericUpDown numImageHeight;
        private System.Windows.Forms.Label lblImageWidth;
        private System.Windows.Forms.NumericUpDown numImageWidth;
        private System.Windows.Forms.Label lblImageAlpha;
        private System.Windows.Forms.NumericUpDown numImageAlpha;
        private System.Windows.Forms.Button btnCreateImage;

        private System.Windows.Forms.GroupBox groupEdit;
        private System.Windows.Forms.Label lblSelectedInfo;
        private System.Windows.Forms.Label lblSelectedPosition;
        private System.Windows.Forms.Label lblSelectedRotation;
        private System.Windows.Forms.TableLayoutPanel tlpEditVisible;
        private System.Windows.Forms.Button btnRelocate;
        private System.Windows.Forms.Button btnShowSelected;
        private System.Windows.Forms.Button btnHideSelected;
        private System.Windows.Forms.Label lblRotationStep;
        private System.Windows.Forms.NumericUpDown numRotationStep;
        private System.Windows.Forms.TableLayoutPanel tlpRotate;
        private System.Windows.Forms.Button btnRotateClockwise;
        private System.Windows.Forms.Button btnRotateCounterClockwise;
        private System.Windows.Forms.CheckBox chkSelectable;
        private System.Windows.Forms.CheckBox chkMovable;

        private System.Windows.Forms.GroupBox groupArrow;
        private System.Windows.Forms.Label lblArrowHeadKind;
        private System.Windows.Forms.ComboBox cmbArrowHeadKind;
        private System.Windows.Forms.Label lblArrowHeadSize;
        private System.Windows.Forms.NumericUpDown numArrowHeadSize;
        private System.Windows.Forms.Button btnArrowColor;
        private System.Windows.Forms.Label lblArrowLength;
        private System.Windows.Forms.NumericUpDown numArrowLength;
        private System.Windows.Forms.Label lblArrowThickness;
        private System.Windows.Forms.NumericUpDown numArrowThickness;
        private System.Windows.Forms.CheckBox chkArrowDoubleHeaded;
        private System.Windows.Forms.TableLayoutPanel tlpArrowCreate;
        private System.Windows.Forms.Button btnAddArrow;
        private System.Windows.Forms.Button btnAddArrowTwoPoint;
        private System.Windows.Forms.Button btnAddArrowDialog;
        private System.Windows.Forms.TableLayoutPanel tlpArrowApply;
        private System.Windows.Forms.Button btnApplyArrowStyle;
        private System.Windows.Forms.Button btnApplyArrowLength;

        private System.Windows.Forms.Button btnDeleteSelected;

        private System.Windows.Forms.GroupBox groupList;
        private System.Windows.Forms.Label lblDecalCount;
        private System.Windows.Forms.DataGridView dgvDecals;
        private System.Windows.Forms.TableLayoutPanel tlpListActions;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnHideAll;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TableLayoutPanel tlpJson;
        private System.Windows.Forms.Button btnExportJson;
        private System.Windows.Forms.Button btnImportJson;

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colVisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRotation;
    }
}