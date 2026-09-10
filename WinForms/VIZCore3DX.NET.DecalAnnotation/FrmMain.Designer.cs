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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnHideAll = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvDecals = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArrow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRotation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDecalCount = new System.Windows.Forms.Label();
            this.groupEdit = new System.Windows.Forms.GroupBox();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.groupArrow = new System.Windows.Forms.GroupBox();
            this.btnDeleteArrow = new System.Windows.Forms.Button();
            this.btnSetArrow = new System.Windows.Forms.Button();
            this.btnAddArrow = new System.Windows.Forms.Button();
            this.btnArrowColor = new System.Windows.Forms.Button();
            this.numArrowSize = new System.Windows.Forms.NumericUpDown();
            this.lblArrowSize = new System.Windows.Forms.Label();
            this.cmbArrowSizeType = new System.Windows.Forms.ComboBox();
            this.lblArrowType = new System.Windows.Forms.Label();
            this.chkMovable = new System.Windows.Forms.CheckBox();
            this.chkSelectable = new System.Windows.Forms.CheckBox();
            this.btnRotateCounterClockwise = new System.Windows.Forms.Button();
            this.btnRotateClockwise = new System.Windows.Forms.Button();
            this.numRotationStep = new System.Windows.Forms.NumericUpDown();
            this.lblRotationStep = new System.Windows.Forms.Label();
            this.btnHideSelected = new System.Windows.Forms.Button();
            this.btnShowSelected = new System.Windows.Forms.Button();
            this.btnRelocate = new System.Windows.Forms.Button();
            this.lblSelectedRotation = new System.Windows.Forms.Label();
            this.lblSelectedPosition = new System.Windows.Forms.Label();
            this.lblSelectedInfo = new System.Windows.Forms.Label();
            this.groupCreate = new System.Windows.Forms.GroupBox();
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
            this.btnFitToView = new System.Windows.Forms.Button();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.groupList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDecals)).BeginInit();
            this.groupEdit.SuspendLayout();
            this.groupArrow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numArrowSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotationStep)).BeginInit();
            this.groupCreate.SuspendLayout();
            this.groupImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImageWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImageHeight)).BeginInit();
            this.groupText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTextWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTextHeight)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(1300, 900);
            this.splitContainer1.SplitterDistance = 440;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelControl
            // 
            this.panelControl.AutoScroll = true;
            this.panelControl.Controls.Add(this.groupList);
            this.panelControl.Controls.Add(this.groupEdit);
            this.panelControl.Controls.Add(this.groupCreate);
            this.panelControl.Controls.Add(this.btnFitToView);
            this.panelControl.Controls.Add(this.btnOpenModel);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(440, 900);
            this.panelControl.TabIndex = 0;
            // 
            // groupList
            // 
            this.groupList.Controls.Add(this.btnClear);
            this.groupList.Controls.Add(this.btnHideAll);
            this.groupList.Controls.Add(this.btnShowAll);
            this.groupList.Controls.Add(this.btnRefresh);
            this.groupList.Controls.Add(this.dgvDecals);
            this.groupList.Controls.Add(this.lblDecalCount);
            this.groupList.Location = new System.Drawing.Point(9, 682);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(420, 205);
            this.groupList.TabIndex = 4;
            this.groupList.TabStop = false;
            this.groupList.Text = "Decal 목록";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(316, 165);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 28);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "전체 삭제";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnHideAll
            // 
            this.btnHideAll.Location = new System.Drawing.Point(214, 165);
            this.btnHideAll.Name = "btnHideAll";
            this.btnHideAll.Size = new System.Drawing.Size(92, 28);
            this.btnHideAll.TabIndex = 4;
            this.btnHideAll.Text = "전체 숨김";
            this.btnHideAll.UseVisualStyleBackColor = true;
            this.btnHideAll.Click += new System.EventHandler(this.btnHideAll_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(112, 165);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(92, 28);
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Text = "전체 표시";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(10, 165);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 28);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvDecals
            // 
            this.dgvDecals.AllowUserToAddRows = false;
            this.dgvDecals.AllowUserToDeleteRows = false;
            this.dgvDecals.AllowUserToResizeRows = false;
            this.dgvDecals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDecals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDecals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colType,
            this.colContent,
            this.colVisible,
            this.colArrow,
            this.colRotation});
            this.dgvDecals.Location = new System.Drawing.Point(10, 40);
            this.dgvDecals.MultiSelect = false;
            this.dgvDecals.Name = "dgvDecals";
            this.dgvDecals.ReadOnly = true;
            this.dgvDecals.RowHeadersVisible = false;
            this.dgvDecals.RowTemplate.Height = 23;
            this.dgvDecals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDecals.Size = new System.Drawing.Size(400, 115);
            this.dgvDecals.TabIndex = 1;
            this.dgvDecals.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDecals_CellClick);
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
            this.colContent.FillWeight = 120F;
            this.colContent.HeaderText = "Content";
            this.colContent.Name = "colContent";
            this.colContent.ReadOnly = true;
            // 
            // colVisible
            // 
            this.colVisible.FillWeight = 50F;
            this.colVisible.HeaderText = "표시";
            this.colVisible.Name = "colVisible";
            this.colVisible.ReadOnly = true;
            // 
            // colArrow
            // 
            this.colArrow.FillWeight = 50F;
            this.colArrow.HeaderText = "Arrow";
            this.colArrow.Name = "colArrow";
            this.colArrow.ReadOnly = true;
            // 
            // colRotation
            // 
            this.colRotation.FillWeight = 65F;
            this.colRotation.HeaderText = "회전(°)";
            this.colRotation.Name = "colRotation";
            this.colRotation.ReadOnly = true;
            // 
            // lblDecalCount
            // 
            this.lblDecalCount.AutoSize = true;
            this.lblDecalCount.Location = new System.Drawing.Point(10, 22);
            this.lblDecalCount.Name = "lblDecalCount";
            this.lblDecalCount.Size = new System.Drawing.Size(55, 12);
            this.lblDecalCount.TabIndex = 0;
            this.lblDecalCount.Text = "Decal : 0";
            // 
            // groupEdit
            // 
            this.groupEdit.Controls.Add(this.btnDeleteSelected);
            this.groupEdit.Controls.Add(this.groupArrow);
            this.groupEdit.Controls.Add(this.chkMovable);
            this.groupEdit.Controls.Add(this.chkSelectable);
            this.groupEdit.Controls.Add(this.btnRotateCounterClockwise);
            this.groupEdit.Controls.Add(this.btnRotateClockwise);
            this.groupEdit.Controls.Add(this.numRotationStep);
            this.groupEdit.Controls.Add(this.lblRotationStep);
            this.groupEdit.Controls.Add(this.btnHideSelected);
            this.groupEdit.Controls.Add(this.btnShowSelected);
            this.groupEdit.Controls.Add(this.btnRelocate);
            this.groupEdit.Controls.Add(this.lblSelectedRotation);
            this.groupEdit.Controls.Add(this.lblSelectedPosition);
            this.groupEdit.Controls.Add(this.lblSelectedInfo);
            this.groupEdit.Location = new System.Drawing.Point(10, 349);
            this.groupEdit.Name = "groupEdit";
            this.groupEdit.Size = new System.Drawing.Size(420, 325);
            this.groupEdit.TabIndex = 3;
            this.groupEdit.TabStop = false;
            this.groupEdit.Text = "선택 Decal";
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(10, 288);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(400, 28);
            this.btnDeleteSelected.TabIndex = 13;
            this.btnDeleteSelected.Text = "선택 Decal 삭제";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // groupArrow
            // 
            this.groupArrow.Controls.Add(this.btnDeleteArrow);
            this.groupArrow.Controls.Add(this.btnSetArrow);
            this.groupArrow.Controls.Add(this.btnAddArrow);
            this.groupArrow.Controls.Add(this.btnArrowColor);
            this.groupArrow.Controls.Add(this.numArrowSize);
            this.groupArrow.Controls.Add(this.lblArrowSize);
            this.groupArrow.Controls.Add(this.cmbArrowSizeType);
            this.groupArrow.Controls.Add(this.lblArrowType);
            this.groupArrow.Location = new System.Drawing.Point(10, 172);
            this.groupArrow.Name = "groupArrow";
            this.groupArrow.Size = new System.Drawing.Size(400, 110);
            this.groupArrow.TabIndex = 12;
            this.groupArrow.TabStop = false;
            this.groupArrow.Text = "Arrow";
            // 
            // btnDeleteArrow
            // 
            this.btnDeleteArrow.Location = new System.Drawing.Point(270, 60);
            this.btnDeleteArrow.Name = "btnDeleteArrow";
            this.btnDeleteArrow.Size = new System.Drawing.Size(120, 28);
            this.btnDeleteArrow.TabIndex = 7;
            this.btnDeleteArrow.Text = "화살표 삭제";
            this.btnDeleteArrow.UseVisualStyleBackColor = true;
            this.btnDeleteArrow.Click += new System.EventHandler(this.btnDeleteArrow_Click);
            // 
            // btnSetArrow
            // 
            this.btnSetArrow.Location = new System.Drawing.Point(140, 60);
            this.btnSetArrow.Name = "btnSetArrow";
            this.btnSetArrow.Size = new System.Drawing.Size(120, 28);
            this.btnSetArrow.TabIndex = 6;
            this.btnSetArrow.Text = "끝점 재설정";
            this.btnSetArrow.UseVisualStyleBackColor = true;
            this.btnSetArrow.Click += new System.EventHandler(this.btnSetArrow_Click);
            // 
            // btnAddArrow
            // 
            this.btnAddArrow.Location = new System.Drawing.Point(10, 60);
            this.btnAddArrow.Name = "btnAddArrow";
            this.btnAddArrow.Size = new System.Drawing.Size(120, 28);
            this.btnAddArrow.TabIndex = 5;
            this.btnAddArrow.Text = "화살표 생성";
            this.btnAddArrow.UseVisualStyleBackColor = true;
            this.btnAddArrow.Click += new System.EventHandler(this.btnAddArrow_Click);
            // 
            // btnArrowColor
            // 
            this.btnArrowColor.BackColor = System.Drawing.Color.Red;
            this.btnArrowColor.Location = new System.Drawing.Point(285, 21);
            this.btnArrowColor.Name = "btnArrowColor";
            this.btnArrowColor.Size = new System.Drawing.Size(105, 24);
            this.btnArrowColor.TabIndex = 4;
            this.btnArrowColor.Text = "화살표 색상";
            this.btnArrowColor.UseVisualStyleBackColor = false;
            this.btnArrowColor.Click += new System.EventHandler(this.btnArrowColor_Click);
            // 
            // numArrowSize
            // 
            this.numArrowSize.DecimalPlaces = 2;
            this.numArrowSize.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numArrowSize.Location = new System.Drawing.Point(190, 23);
            this.numArrowSize.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            131072});
            this.numArrowSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numArrowSize.Name = "numArrowSize";
            this.numArrowSize.Size = new System.Drawing.Size(80, 21);
            this.numArrowSize.TabIndex = 3;
            this.numArrowSize.Value = new decimal(new int[] {
            15,
            0,
            0,
            131072});
            // 
            // lblArrowSize
            // 
            this.lblArrowSize.AutoSize = true;
            this.lblArrowSize.Location = new System.Drawing.Point(155, 27);
            this.lblArrowSize.Name = "lblArrowSize";
            this.lblArrowSize.Size = new System.Drawing.Size(30, 12);
            this.lblArrowSize.TabIndex = 2;
            this.lblArrowSize.Text = "Size";
            // 
            // cmbArrowSizeType
            // 
            this.cmbArrowSizeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArrowSizeType.FormattingEnabled = true;
            this.cmbArrowSizeType.Items.AddRange(new object[] {
            "Ratio",
            "Fixed"});
            this.cmbArrowSizeType.Location = new System.Drawing.Point(50, 23);
            this.cmbArrowSizeType.Name = "cmbArrowSizeType";
            this.cmbArrowSizeType.Size = new System.Drawing.Size(90, 20);
            this.cmbArrowSizeType.TabIndex = 1;
            this.cmbArrowSizeType.SelectedIndexChanged += new System.EventHandler(this.cmbArrowSizeType_SelectedIndexChanged);
            // 
            // lblArrowType
            // 
            this.lblArrowType.AutoSize = true;
            this.lblArrowType.Location = new System.Drawing.Point(10, 27);
            this.lblArrowType.Name = "lblArrowType";
            this.lblArrowType.Size = new System.Drawing.Size(34, 12);
            this.lblArrowType.TabIndex = 0;
            this.lblArrowType.Text = "Type";
            // 
            // chkMovable
            // 
            this.chkMovable.AutoSize = true;
            this.chkMovable.Location = new System.Drawing.Point(125, 149);
            this.chkMovable.Name = "chkMovable";
            this.chkMovable.Size = new System.Drawing.Size(76, 16);
            this.chkMovable.TabIndex = 11;
            this.chkMovable.Text = "이동 가능";
            this.chkMovable.UseVisualStyleBackColor = true;
            this.chkMovable.CheckedChanged += new System.EventHandler(this.chkMovable_CheckedChanged);
            // 
            // chkSelectable
            // 
            this.chkSelectable.AutoSize = true;
            this.chkSelectable.Location = new System.Drawing.Point(12, 149);
            this.chkSelectable.Name = "chkSelectable";
            this.chkSelectable.Size = new System.Drawing.Size(76, 16);
            this.chkSelectable.TabIndex = 10;
            this.chkSelectable.Text = "선택 가능";
            this.chkSelectable.UseVisualStyleBackColor = true;
            this.chkSelectable.CheckedChanged += new System.EventHandler(this.chkSelectable_CheckedChanged);
            // 
            // btnRotateCounterClockwise
            // 
            this.btnRotateCounterClockwise.Location = new System.Drawing.Point(305, 114);
            this.btnRotateCounterClockwise.Name = "btnRotateCounterClockwise";
            this.btnRotateCounterClockwise.Size = new System.Drawing.Size(105, 26);
            this.btnRotateCounterClockwise.TabIndex = 9;
            this.btnRotateCounterClockwise.Text = "↺ 반시계 회전";
            this.btnRotateCounterClockwise.UseVisualStyleBackColor = true;
            this.btnRotateCounterClockwise.Click += new System.EventHandler(this.btnRotateCounterClockwise_Click);
            // 
            // btnRotateClockwise
            // 
            this.btnRotateClockwise.Location = new System.Drawing.Point(195, 114);
            this.btnRotateClockwise.Name = "btnRotateClockwise";
            this.btnRotateClockwise.Size = new System.Drawing.Size(100, 26);
            this.btnRotateClockwise.TabIndex = 8;
            this.btnRotateClockwise.Text = "↻ 시계 회전";
            this.btnRotateClockwise.UseVisualStyleBackColor = true;
            this.btnRotateClockwise.Click += new System.EventHandler(this.btnRotateClockwise_Click);
            // 
            // numRotationStep
            // 
            this.numRotationStep.DecimalPlaces = 1;
            this.numRotationStep.Location = new System.Drawing.Point(100, 116);
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
            this.numRotationStep.TabIndex = 7;
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
            this.lblRotationStep.Location = new System.Drawing.Point(10, 120);
            this.lblRotationStep.Name = "lblRotationStep";
            this.lblRotationStep.Size = new System.Drawing.Size(76, 12);
            this.lblRotationStep.TabIndex = 6;
            this.lblRotationStep.Text = "회전 Step (°)";
            // 
            // btnHideSelected
            // 
            this.btnHideSelected.Location = new System.Drawing.Point(280, 80);
            this.btnHideSelected.Name = "btnHideSelected";
            this.btnHideSelected.Size = new System.Drawing.Size(130, 28);
            this.btnHideSelected.TabIndex = 5;
            this.btnHideSelected.Text = "숨김";
            this.btnHideSelected.UseVisualStyleBackColor = true;
            this.btnHideSelected.Click += new System.EventHandler(this.btnHideSelected_Click);
            // 
            // btnShowSelected
            // 
            this.btnShowSelected.Location = new System.Drawing.Point(145, 80);
            this.btnShowSelected.Name = "btnShowSelected";
            this.btnShowSelected.Size = new System.Drawing.Size(125, 28);
            this.btnShowSelected.TabIndex = 4;
            this.btnShowSelected.Text = "표시";
            this.btnShowSelected.UseVisualStyleBackColor = true;
            this.btnShowSelected.Click += new System.EventHandler(this.btnShowSelected_Click);
            // 
            // btnRelocate
            // 
            this.btnRelocate.Location = new System.Drawing.Point(10, 80);
            this.btnRelocate.Name = "btnRelocate";
            this.btnRelocate.Size = new System.Drawing.Size(125, 28);
            this.btnRelocate.TabIndex = 3;
            this.btnRelocate.Text = "표면 재지정";
            this.btnRelocate.UseVisualStyleBackColor = true;
            this.btnRelocate.Click += new System.EventHandler(this.btnRelocate_Click);
            // 
            // lblSelectedRotation
            // 
            this.lblSelectedRotation.AutoEllipsis = true;
            this.lblSelectedRotation.Location = new System.Drawing.Point(10, 58);
            this.lblSelectedRotation.Name = "lblSelectedRotation";
            this.lblSelectedRotation.Size = new System.Drawing.Size(400, 17);
            this.lblSelectedRotation.TabIndex = 2;
            this.lblSelectedRotation.Text = "Rotation : -";
            // 
            // lblSelectedPosition
            // 
            this.lblSelectedPosition.AutoEllipsis = true;
            this.lblSelectedPosition.Location = new System.Drawing.Point(10, 40);
            this.lblSelectedPosition.Name = "lblSelectedPosition";
            this.lblSelectedPosition.Size = new System.Drawing.Size(400, 17);
            this.lblSelectedPosition.TabIndex = 1;
            this.lblSelectedPosition.Text = "Position : -";
            // 
            // lblSelectedInfo
            // 
            this.lblSelectedInfo.AutoEllipsis = true;
            this.lblSelectedInfo.Location = new System.Drawing.Point(10, 22);
            this.lblSelectedInfo.Name = "lblSelectedInfo";
            this.lblSelectedInfo.Size = new System.Drawing.Size(400, 17);
            this.lblSelectedInfo.TabIndex = 0;
            this.lblSelectedInfo.Text = "선택된 Decal : 없음";
            // 
            // groupCreate
            // 
            this.groupCreate.Controls.Add(this.groupImage);
            this.groupCreate.Controls.Add(this.groupText);
            this.groupCreate.Location = new System.Drawing.Point(10, 50);
            this.groupCreate.Name = "groupCreate";
            this.groupCreate.Size = new System.Drawing.Size(420, 290);
            this.groupCreate.TabIndex = 2;
            this.groupCreate.TabStop = false;
            this.groupCreate.Text = "Decal 생성";
            // 
            // groupImage
            // 
            this.groupImage.Controls.Add(this.btnCreateImage);
            this.groupImage.Controls.Add(this.numImageAlpha);
            this.groupImage.Controls.Add(this.lblImageAlpha);
            this.groupImage.Controls.Add(this.numImageWidth);
            this.groupImage.Controls.Add(this.lblImageWidth);
            this.groupImage.Controls.Add(this.numImageHeight);
            this.groupImage.Controls.Add(this.lblImageHeight);
            this.groupImage.Controls.Add(this.btnBrowseImage);
            this.groupImage.Controls.Add(this.txtImageFile);
            this.groupImage.Location = new System.Drawing.Point(10, 140);
            this.groupImage.Name = "groupImage";
            this.groupImage.Size = new System.Drawing.Size(400, 140);
            this.groupImage.TabIndex = 1;
            this.groupImage.TabStop = false;
            this.groupImage.Text = "Image Decal";
            // 
            // btnCreateImage
            // 
            this.btnCreateImage.Location = new System.Drawing.Point(190, 80);
            this.btnCreateImage.Name = "btnCreateImage";
            this.btnCreateImage.Size = new System.Drawing.Size(200, 28);
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
            this.numImageAlpha.Location = new System.Drawing.Point(95, 81);
            this.numImageAlpha.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numImageAlpha.Name = "numImageAlpha";
            this.numImageAlpha.Size = new System.Drawing.Size(80, 21);
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
            this.numImageWidth.DecimalPlaces = 1;
            this.numImageWidth.Location = new System.Drawing.Point(280, 53);
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
            this.lblImageWidth.AutoSize = true;
            this.lblImageWidth.Location = new System.Drawing.Point(190, 57);
            this.lblImageWidth.Name = "lblImageWidth";
            this.lblImageWidth.Size = new System.Drawing.Size(86, 12);
            this.lblImageWidth.TabIndex = 4;
            this.lblImageWidth.Text = "Width (0=Auto)";
            // 
            // numImageHeight
            // 
            this.numImageHeight.DecimalPlaces = 1;
            this.numImageHeight.Location = new System.Drawing.Point(55, 53);
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
            this.lblImageHeight.Location = new System.Drawing.Point(10, 57);
            this.lblImageHeight.Name = "lblImageHeight";
            this.lblImageHeight.Size = new System.Drawing.Size(40, 12);
            this.lblImageHeight.TabIndex = 2;
            this.lblImageHeight.Text = "Height";
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Location = new System.Drawing.Point(305, 21);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(85, 23);
            this.btnBrowseImage.TabIndex = 1;
            this.btnBrowseImage.Text = "이미지 선택";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // txtImageFile
            // 
            this.txtImageFile.Location = new System.Drawing.Point(10, 22);
            this.txtImageFile.Name = "txtImageFile";
            this.txtImageFile.ReadOnly = true;
            this.txtImageFile.Size = new System.Drawing.Size(285, 21);
            this.txtImageFile.TabIndex = 0;
            // 
            // groupText
            // 
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
            this.groupText.Size = new System.Drawing.Size(400, 115);
            this.groupText.TabIndex = 0;
            this.groupText.TabStop = false;
            this.groupText.Text = "Text Decal";
            // 
            // btnCreateText
            // 
            this.btnCreateText.Location = new System.Drawing.Point(10, 80);
            this.btnCreateText.Name = "btnCreateText";
            this.btnCreateText.Size = new System.Drawing.Size(380, 27);
            this.btnCreateText.TabIndex = 7;
            this.btnCreateText.Text = "모델 표면에 Text Decal 생성";
            this.btnCreateText.UseVisualStyleBackColor = true;
            this.btnCreateText.Click += new System.EventHandler(this.btnCreateText_Click);
            // 
            // numTextWidth
            // 
            this.numTextWidth.DecimalPlaces = 1;
            this.numTextWidth.Location = new System.Drawing.Point(280, 54);
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
            this.lblTextWidth.AutoSize = true;
            this.lblTextWidth.Location = new System.Drawing.Point(190, 58);
            this.lblTextWidth.Name = "lblTextWidth";
            this.lblTextWidth.Size = new System.Drawing.Size(86, 12);
            this.lblTextWidth.TabIndex = 5;
            this.lblTextWidth.Text = "Width (0=Auto)";
            // 
            // numTextHeight
            // 
            this.numTextHeight.DecimalPlaces = 1;
            this.numTextHeight.Location = new System.Drawing.Point(55, 54);
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
            this.lblTextHeight.Location = new System.Drawing.Point(10, 58);
            this.lblTextHeight.Name = "lblTextHeight";
            this.lblTextHeight.Size = new System.Drawing.Size(40, 12);
            this.lblTextHeight.TabIndex = 3;
            this.lblTextHeight.Text = "Height";
            // 
            // btnTextColor
            // 
            this.btnTextColor.BackColor = System.Drawing.Color.Red;
            this.btnTextColor.Location = new System.Drawing.Point(295, 22);
            this.btnTextColor.Name = "btnTextColor";
            this.btnTextColor.Size = new System.Drawing.Size(95, 24);
            this.btnTextColor.TabIndex = 2;
            this.btnTextColor.Text = "문자 색상";
            this.btnTextColor.UseVisualStyleBackColor = false;
            this.btnTextColor.Click += new System.EventHandler(this.btnTextColor_Click);
            // 
            // txtDecalText
            // 
            this.txtDecalText.Location = new System.Drawing.Point(55, 23);
            this.txtDecalText.Name = "txtDecalText";
            this.txtDecalText.Size = new System.Drawing.Size(230, 21);
            this.txtDecalText.TabIndex = 1;
            this.txtDecalText.Text = "DECAL";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(10, 27);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(30, 12);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Text";
            // 
            // btnFitToView
            // 
            this.btnFitToView.Location = new System.Drawing.Point(320, 10);
            this.btnFitToView.Name = "btnFitToView";
            this.btnFitToView.Size = new System.Drawing.Size(110, 30);
            this.btnFitToView.TabIndex = 1;
            this.btnFitToView.Text = "화면 맞춤";
            this.btnFitToView.UseVisualStyleBackColor = true;
            this.btnFitToView.Click += new System.EventHandler(this.btnFitToView_Click);
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Location = new System.Drawing.Point(10, 10);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(300, 30);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "모델 열기";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDecals)).EndInit();
            this.groupEdit.ResumeLayout(false);
            this.groupEdit.PerformLayout();
            this.groupArrow.ResumeLayout(false);
            this.groupArrow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numArrowSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotationStep)).EndInit();
            this.groupCreate.ResumeLayout(false);
            this.groupImage.ResumeLayout(false);
            this.groupImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImageWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImageHeight)).EndInit();
            this.groupText.ResumeLayout(false);
            this.groupText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTextWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTextHeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelControl;
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
        private System.Windows.Forms.Button btnRelocate;
        private System.Windows.Forms.Button btnShowSelected;
        private System.Windows.Forms.Button btnHideSelected;
        private System.Windows.Forms.Label lblRotationStep;
        private System.Windows.Forms.NumericUpDown numRotationStep;
        private System.Windows.Forms.Button btnRotateClockwise;
        private System.Windows.Forms.Button btnRotateCounterClockwise;
        private System.Windows.Forms.CheckBox chkSelectable;
        private System.Windows.Forms.CheckBox chkMovable;

        private System.Windows.Forms.GroupBox groupArrow;
        private System.Windows.Forms.Label lblArrowType;
        private System.Windows.Forms.ComboBox cmbArrowSizeType;
        private System.Windows.Forms.Label lblArrowSize;
        private System.Windows.Forms.NumericUpDown numArrowSize;
        private System.Windows.Forms.Button btnArrowColor;
        private System.Windows.Forms.Button btnAddArrow;
        private System.Windows.Forms.Button btnSetArrow;
        private System.Windows.Forms.Button btnDeleteArrow;

        private System.Windows.Forms.Button btnDeleteSelected;

        private System.Windows.Forms.GroupBox groupList;
        private System.Windows.Forms.Label lblDecalCount;
        private System.Windows.Forms.DataGridView dgvDecals;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRotation;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnHideAll;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
    }
}