namespace VIZCore3DX.NET.Zone
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
            this.grpFile = new System.Windows.Forms.GroupBox();
            this.btnImportReplace = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.grpInteract = new System.Windows.Forms.GroupBox();
            this.btnOverlaps = new System.Windows.Forms.Button();
            this.btnApplyStyle = new System.Windows.Forms.Button();
            this.numOpacity = new System.Windows.Forms.NumericUpDown();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.chkDeleteSources = new System.Windows.Forms.CheckBox();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.btnUnion = new System.Windows.Forms.Button();
            this.btnFit = new System.Windows.Forms.Button();
            this.btnIsolateNodes = new System.Windows.Forms.Button();
            this.btnSelectNodes = new System.Windows.Forms.Button();
            this.cmbOption = new System.Windows.Forms.ComboBox();
            this.lblOption = new System.Windows.Forms.Label();
            this.chkFollow = new System.Windows.Forms.CheckBox();
            this.chkFaceDrag = new System.Windows.Forms.CheckBox();
            this.chkViewPicking = new System.Windows.Forms.CheckBox();
            this.grpCreate = new System.Windows.Forms.GroupBox();
            this.btnFromSelectionBox = new System.Windows.Forms.Button();
            this.btnFromNodes = new System.Windows.Forms.Button();
            this.btnCreateGrid = new System.Windows.Forms.Button();
            this.numGridY = new System.Windows.Forms.NumericUpDown();
            this.lblGridX = new System.Windows.Forms.Label();
            this.numGridX = new System.Windows.Forms.NumericUpDown();
            this.lblGrid = new System.Windows.Forms.Label();
            this.numMargin = new System.Windows.Forms.NumericUpDown();
            this.lblMargin = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnHideAll = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.grpZones = new System.Windows.Forms.GroupBox();
            this.btnToggleVisible = new System.Windows.Forms.Button();
            this.dgvZones = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpOverlaps = new System.Windows.Forms.GroupBox();
            this.dgvOverlaps = new System.Windows.Forms.DataGridView();
            this.colA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOverlapVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpFile.SuspendLayout();
            this.grpInteract.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).BeginInit();
            this.grpCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGridY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGridX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMargin)).BeginInit();
            this.grpModel.SuspendLayout();
            this.grpCleanup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.grpZones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).BeginInit();
            this.grpOverlaps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverlaps)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpFile);
            this.splitContainer1.Panel1.Controls.Add(this.grpInteract);
            this.splitContainer1.Panel1.Controls.Add(this.grpCreate);
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
            // grpFile
            //
            this.grpFile.Controls.Add(this.btnImportReplace);
            this.grpFile.Controls.Add(this.btnImport);
            this.grpFile.Controls.Add(this.btnExport);
            this.grpFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFile.Location = new System.Drawing.Point(8, 492);
            this.grpFile.Name = "grpFile";
            this.grpFile.Size = new System.Drawing.Size(360, 60);
            this.grpFile.TabIndex = 3;
            this.grpFile.TabStop = false;
            this.grpFile.Text = "4. 파일";
            //
            // btnImportReplace
            //
            this.btnImportReplace.Location = new System.Drawing.Point(240, 24);
            this.btnImportReplace.Name = "btnImportReplace";
            this.btnImportReplace.Size = new System.Drawing.Size(108, 23);
            this.btnImportReplace.TabIndex = 2;
            this.btnImportReplace.Text = "불러오기(교체)";
            this.btnImportReplace.UseVisualStyleBackColor = true;
            this.btnImportReplace.Click += new System.EventHandler(this.btnImportReplace_Click);
            //
            // btnImport
            //
            this.btnImport.Location = new System.Drawing.Point(126, 24);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(108, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "불러오기(추가)";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            //
            // btnExport
            //
            this.btnExport.Location = new System.Drawing.Point(12, 24);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(108, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "내보내기";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            //
            // grpInteract
            //
            this.grpInteract.Controls.Add(this.btnOverlaps);
            this.grpInteract.Controls.Add(this.btnApplyStyle);
            this.grpInteract.Controls.Add(this.numOpacity);
            this.grpInteract.Controls.Add(this.lblOpacity);
            this.grpInteract.Controls.Add(this.btnColor);
            this.grpInteract.Controls.Add(this.chkDeleteSources);
            this.grpInteract.Controls.Add(this.btnSubtract);
            this.grpInteract.Controls.Add(this.btnUnion);
            this.grpInteract.Controls.Add(this.btnFit);
            this.grpInteract.Controls.Add(this.btnIsolateNodes);
            this.grpInteract.Controls.Add(this.btnSelectNodes);
            this.grpInteract.Controls.Add(this.cmbOption);
            this.grpInteract.Controls.Add(this.lblOption);
            this.grpInteract.Controls.Add(this.chkFollow);
            this.grpInteract.Controls.Add(this.chkFaceDrag);
            this.grpInteract.Controls.Add(this.chkViewPicking);
            this.grpInteract.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInteract.Location = new System.Drawing.Point(8, 256);
            this.grpInteract.Name = "grpInteract";
            this.grpInteract.Size = new System.Drawing.Size(360, 236);
            this.grpInteract.TabIndex = 2;
            this.grpInteract.TabStop = false;
            this.grpInteract.Text = "3. 조작";
            //
            // btnOverlaps
            //
            this.btnOverlaps.Location = new System.Drawing.Point(12, 200);
            this.btnOverlaps.Name = "btnOverlaps";
            this.btnOverlaps.Size = new System.Drawing.Size(108, 23);
            this.btnOverlaps.TabIndex = 15;
            this.btnOverlaps.Text = "겹침 검사";
            this.btnOverlaps.UseVisualStyleBackColor = true;
            this.btnOverlaps.Click += new System.EventHandler(this.btnOverlaps_Click);
            //
            // btnApplyStyle
            //
            this.btnApplyStyle.Location = new System.Drawing.Point(264, 168);
            this.btnApplyStyle.Name = "btnApplyStyle";
            this.btnApplyStyle.Size = new System.Drawing.Size(84, 23);
            this.btnApplyStyle.TabIndex = 14;
            this.btnApplyStyle.Text = "스타일 적용";
            this.btnApplyStyle.UseVisualStyleBackColor = true;
            this.btnApplyStyle.Click += new System.EventHandler(this.btnApplyStyle_Click);
            //
            // numOpacity
            //
            this.numOpacity.Location = new System.Drawing.Point(206, 169);
            this.numOpacity.Name = "numOpacity";
            this.numOpacity.Size = new System.Drawing.Size(50, 21);
            this.numOpacity.TabIndex = 13;
            this.numOpacity.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            //
            // lblOpacity
            //
            this.lblOpacity.AutoSize = true;
            this.lblOpacity.Location = new System.Drawing.Point(126, 173);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new System.Drawing.Size(77, 12);
            this.lblOpacity.TabIndex = 12;
            this.lblOpacity.Text = "면 불투명도";
            //
            // btnColor
            //
            this.btnColor.Location = new System.Drawing.Point(12, 168);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(108, 23);
            this.btnColor.TabIndex = 11;
            this.btnColor.Text = "색 지정";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // chkDeleteSources
            //
            this.chkDeleteSources.AutoSize = true;
            this.chkDeleteSources.Location = new System.Drawing.Point(240, 140);
            this.chkDeleteSources.Name = "chkDeleteSources";
            this.chkDeleteSources.Size = new System.Drawing.Size(76, 16);
            this.chkDeleteSources.TabIndex = 10;
            this.chkDeleteSources.Text = "원본 삭제";
            this.chkDeleteSources.UseVisualStyleBackColor = true;
            //
            // btnSubtract
            //
            this.btnSubtract.Location = new System.Drawing.Point(126, 136);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(108, 23);
            this.btnSubtract.TabIndex = 9;
            this.btnSubtract.Text = "차집합(A − B)";
            this.btnSubtract.UseVisualStyleBackColor = true;
            this.btnSubtract.Click += new System.EventHandler(this.btnSubtract_Click);
            //
            // btnUnion
            //
            this.btnUnion.Location = new System.Drawing.Point(12, 136);
            this.btnUnion.Name = "btnUnion";
            this.btnUnion.Size = new System.Drawing.Size(108, 23);
            this.btnUnion.TabIndex = 8;
            this.btnUnion.Text = "합집합";
            this.btnUnion.UseVisualStyleBackColor = true;
            this.btnUnion.Click += new System.EventHandler(this.btnUnion_Click);
            //
            // btnFit
            //
            this.btnFit.Location = new System.Drawing.Point(240, 104);
            this.btnFit.Name = "btnFit";
            this.btnFit.Size = new System.Drawing.Size(108, 23);
            this.btnFit.TabIndex = 7;
            this.btnFit.Text = "공간에 맞춤";
            this.btnFit.UseVisualStyleBackColor = true;
            this.btnFit.Click += new System.EventHandler(this.btnFit_Click);
            //
            // btnIsolateNodes
            //
            this.btnIsolateNodes.Location = new System.Drawing.Point(126, 104);
            this.btnIsolateNodes.Name = "btnIsolateNodes";
            this.btnIsolateNodes.Size = new System.Drawing.Size(108, 23);
            this.btnIsolateNodes.TabIndex = 6;
            this.btnIsolateNodes.Text = "개체 단독 표시";
            this.btnIsolateNodes.UseVisualStyleBackColor = true;
            this.btnIsolateNodes.Click += new System.EventHandler(this.btnIsolateNodes_Click);
            //
            // btnSelectNodes
            //
            this.btnSelectNodes.Location = new System.Drawing.Point(12, 104);
            this.btnSelectNodes.Name = "btnSelectNodes";
            this.btnSelectNodes.Size = new System.Drawing.Size(108, 23);
            this.btnSelectNodes.TabIndex = 5;
            this.btnSelectNodes.Text = "개체 선택";
            this.btnSelectNodes.UseVisualStyleBackColor = true;
            this.btnSelectNodes.Click += new System.EventHandler(this.btnSelectNodes_Click);
            //
            // cmbOption
            //
            this.cmbOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOption.Location = new System.Drawing.Point(90, 76);
            this.cmbOption.Name = "cmbOption";
            this.cmbOption.Size = new System.Drawing.Size(144, 20);
            this.cmbOption.TabIndex = 4;
            //
            // lblOption
            //
            this.lblOption.AutoSize = true;
            this.lblOption.Location = new System.Drawing.Point(12, 80);
            this.lblOption.Name = "lblOption";
            this.lblOption.Size = new System.Drawing.Size(57, 12);
            this.lblOption.TabIndex = 3;
            this.lblOption.Text = "개체 판정";
            //
            // chkFollow
            //
            this.chkFollow.AutoSize = true;
            this.chkFollow.Checked = true;
            this.chkFollow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFollow.Location = new System.Drawing.Point(12, 48);
            this.chkFollow.Name = "chkFollow";
            this.chkFollow.Size = new System.Drawing.Size(124, 16);
            this.chkFollow.TabIndex = 2;
            this.chkFollow.Text = "선택 시 카메라 이동";
            this.chkFollow.UseVisualStyleBackColor = true;
            //
            // chkFaceDrag
            //
            this.chkFaceDrag.AutoSize = true;
            this.chkFaceDrag.Location = new System.Drawing.Point(180, 24);
            this.chkFaceDrag.Name = "chkFaceDrag";
            this.chkFaceDrag.Size = new System.Drawing.Size(88, 16);
            this.chkFaceDrag.TabIndex = 1;
            this.chkFaceDrag.Text = "경계면 끌기";
            this.chkFaceDrag.UseVisualStyleBackColor = true;
            this.chkFaceDrag.CheckedChanged += new System.EventHandler(this.chkFaceDrag_CheckedChanged);
            //
            // chkViewPicking
            //
            this.chkViewPicking.AutoSize = true;
            this.chkViewPicking.Checked = true;
            this.chkViewPicking.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewPicking.Location = new System.Drawing.Point(12, 24);
            this.chkViewPicking.Name = "chkViewPicking";
            this.chkViewPicking.Size = new System.Drawing.Size(124, 16);
            this.chkViewPicking.TabIndex = 0;
            this.chkViewPicking.Text = "뷰 클릭으로 선택";
            this.chkViewPicking.UseVisualStyleBackColor = true;
            this.chkViewPicking.CheckedChanged += new System.EventHandler(this.chkViewPicking_CheckedChanged);
            //
            // grpCreate
            //
            this.grpCreate.Controls.Add(this.btnFromSelectionBox);
            this.grpCreate.Controls.Add(this.btnFromNodes);
            this.grpCreate.Controls.Add(this.btnCreateGrid);
            this.grpCreate.Controls.Add(this.numGridY);
            this.grpCreate.Controls.Add(this.lblGridX);
            this.grpCreate.Controls.Add(this.numGridX);
            this.grpCreate.Controls.Add(this.lblGrid);
            this.grpCreate.Controls.Add(this.numMargin);
            this.grpCreate.Controls.Add(this.lblMargin);
            this.grpCreate.Controls.Add(this.txtName);
            this.grpCreate.Controls.Add(this.lblName);
            this.grpCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCreate.Location = new System.Drawing.Point(8, 104);
            this.grpCreate.Name = "grpCreate";
            this.grpCreate.Size = new System.Drawing.Size(360, 152);
            this.grpCreate.TabIndex = 1;
            this.grpCreate.TabStop = false;
            this.grpCreate.Text = "2. 생성";
            //
            // btnFromSelectionBox
            //
            this.btnFromSelectionBox.Location = new System.Drawing.Point(180, 112);
            this.btnFromSelectionBox.Name = "btnFromSelectionBox";
            this.btnFromSelectionBox.Size = new System.Drawing.Size(168, 23);
            this.btnFromSelectionBox.TabIndex = 10;
            this.btnFromSelectionBox.Text = "선택 상자로 생성";
            this.btnFromSelectionBox.UseVisualStyleBackColor = true;
            this.btnFromSelectionBox.Click += new System.EventHandler(this.btnFromSelectionBox_Click);
            //
            // btnFromNodes
            //
            this.btnFromNodes.Location = new System.Drawing.Point(12, 112);
            this.btnFromNodes.Name = "btnFromNodes";
            this.btnFromNodes.Size = new System.Drawing.Size(160, 23);
            this.btnFromNodes.TabIndex = 9;
            this.btnFromNodes.Text = "선택 노드로 생성";
            this.btnFromNodes.UseVisualStyleBackColor = true;
            this.btnFromNodes.Click += new System.EventHandler(this.btnFromNodes_Click);
            //
            // btnCreateGrid
            //
            this.btnCreateGrid.Location = new System.Drawing.Point(216, 80);
            this.btnCreateGrid.Name = "btnCreateGrid";
            this.btnCreateGrid.Size = new System.Drawing.Size(132, 23);
            this.btnCreateGrid.TabIndex = 8;
            this.btnCreateGrid.Text = "모델을 나눠 생성";
            this.btnCreateGrid.UseVisualStyleBackColor = true;
            this.btnCreateGrid.Click += new System.EventHandler(this.btnCreateGrid_Click);
            //
            // numGridY
            //
            this.numGridY.Location = new System.Drawing.Point(160, 81);
            this.numGridY.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numGridY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGridY.Name = "numGridY";
            this.numGridY.Size = new System.Drawing.Size(50, 21);
            this.numGridY.TabIndex = 7;
            this.numGridY.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            //
            // lblGridX
            //
            this.lblGridX.AutoSize = true;
            this.lblGridX.Location = new System.Drawing.Point(144, 85);
            this.lblGridX.Name = "lblGridX";
            this.lblGridX.Size = new System.Drawing.Size(11, 12);
            this.lblGridX.TabIndex = 6;
            this.lblGridX.Text = "×";
            //
            // numGridX
            //
            this.numGridX.Location = new System.Drawing.Point(90, 81);
            this.numGridX.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numGridX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGridX.Name = "numGridX";
            this.numGridX.Size = new System.Drawing.Size(50, 21);
            this.numGridX.TabIndex = 5;
            this.numGridX.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            //
            // lblGrid
            //
            this.lblGrid.AutoSize = true;
            this.lblGrid.Location = new System.Drawing.Point(12, 85);
            this.lblGrid.Name = "lblGrid";
            this.lblGrid.Size = new System.Drawing.Size(65, 12);
            this.lblGrid.TabIndex = 4;
            this.lblGrid.Text = "분할(X × Y)";
            //
            // numMargin
            //
            this.numMargin.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMargin.Location = new System.Drawing.Point(90, 52);
            this.numMargin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMargin.Name = "numMargin";
            this.numMargin.Size = new System.Drawing.Size(80, 21);
            this.numMargin.TabIndex = 3;
            this.numMargin.ThousandsSeparator = true;
            //
            // lblMargin
            //
            this.lblMargin.AutoSize = true;
            this.lblMargin.Location = new System.Drawing.Point(12, 56);
            this.lblMargin.Name = "lblMargin";
            this.lblMargin.Size = new System.Drawing.Size(60, 12);
            this.lblMargin.TabIndex = 2;
            this.lblMargin.Text = "여유(mm)";
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(90, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(258, 21);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Zone";
            //
            // lblName
            //
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 28);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "이름";
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
            this.lblModelHint.Size = new System.Drawing.Size(336, 32);
            this.lblModelHint.TabIndex = 1;
            this.lblModelHint.Text = "뷰에서 공간을 클릭하면 오른쪽 목록에서 선택됩니다.\r\n공간 이름은 목록의 이름 칸에서 직접 고칠 수 있습니다.";
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
            this.grpCleanup.Controls.Add(this.btnClear);
            this.grpCleanup.Controls.Add(this.btnDelete);
            this.grpCleanup.Controls.Add(this.btnHideAll);
            this.grpCleanup.Controls.Add(this.btnShowAll);
            this.grpCleanup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCleanup.Location = new System.Drawing.Point(8, 710);
            this.grpCleanup.Name = "grpCleanup";
            this.grpCleanup.Size = new System.Drawing.Size(360, 60);
            this.grpCleanup.TabIndex = 4;
            this.grpCleanup.TabStop = false;
            this.grpCleanup.Text = "5. 정리";
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(270, 24);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "전체 삭제";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(184, 24);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "선택 삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnHideAll
            //
            this.btnHideAll.Location = new System.Drawing.Point(98, 24);
            this.btnHideAll.Name = "btnHideAll";
            this.btnHideAll.Size = new System.Drawing.Size(80, 23);
            this.btnHideAll.TabIndex = 1;
            this.btnHideAll.Text = "모두 숨김";
            this.btnHideAll.UseVisualStyleBackColor = true;
            this.btnHideAll.Click += new System.EventHandler(this.btnHideAll_Click);
            //
            // btnShowAll
            //
            this.btnShowAll.Location = new System.Drawing.Point(12, 24);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(80, 23);
            this.btnShowAll.TabIndex = 0;
            this.btnShowAll.Text = "모두 보임";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
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
            this.splitContainer3.Panel1.Controls.Add(this.grpZones);
            //
            // splitContainer3.Panel2
            //
            this.splitContainer3.Panel2.Controls.Add(this.grpOverlaps);
            this.splitContainer3.Size = new System.Drawing.Size(376, 800);
            this.splitContainer3.SplitterDistance = 480;
            this.splitContainer3.TabIndex = 0;
            //
            // grpZones
            //
            this.grpZones.Controls.Add(this.btnToggleVisible);
            this.grpZones.Controls.Add(this.dgvZones);
            this.grpZones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpZones.Location = new System.Drawing.Point(0, 0);
            this.grpZones.Name = "grpZones";
            this.grpZones.Size = new System.Drawing.Size(376, 480);
            this.grpZones.TabIndex = 0;
            this.grpZones.TabStop = false;
            this.grpZones.Text = "공간 목록 (여러 행 선택 가능)";
            //
            // btnToggleVisible
            //
            this.btnToggleVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToggleVisible.Location = new System.Drawing.Point(12, 444);
            this.btnToggleVisible.Name = "btnToggleVisible";
            this.btnToggleVisible.Size = new System.Drawing.Size(100, 23);
            this.btnToggleVisible.TabIndex = 1;
            this.btnToggleVisible.Text = "보이기/숨기기";
            this.btnToggleVisible.UseVisualStyleBackColor = true;
            this.btnToggleVisible.Click += new System.EventHandler(this.btnToggleVisible_Click);
            //
            // dgvZones
            //
            this.dgvZones.AllowUserToAddRows = false;
            this.dgvZones.AllowUserToDeleteRows = false;
            this.dgvZones.AllowUserToResizeRows = false;
            this.dgvZones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvZones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvZones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colVolume,
            this.colSize,
            this.colVisible});
            this.dgvZones.Location = new System.Drawing.Point(12, 24);
            this.dgvZones.MultiSelect = true;
            this.dgvZones.Name = "dgvZones";
            this.dgvZones.RowHeadersVisible = false;
            this.dgvZones.RowTemplate.Height = 23;
            this.dgvZones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvZones.Size = new System.Drawing.Size(352, 412);
            this.dgvZones.TabIndex = 0;
            this.dgvZones.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvZones_CellEndEdit);
            this.dgvZones.SelectionChanged += new System.EventHandler(this.dgvZones_SelectionChanged);
            //
            // colId
            //
            this.colId.FillWeight = 30F;
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            //
            // colName
            //
            this.colName.FillWeight = 90F;
            this.colName.HeaderText = "이름";
            this.colName.Name = "colName";
            //
            // colVolume
            //
            this.colVolume.FillWeight = 60F;
            this.colVolume.HeaderText = "체적(m³)";
            this.colVolume.Name = "colVolume";
            this.colVolume.ReadOnly = true;
            //
            // colSize
            //
            this.colSize.FillWeight = 120F;
            this.colSize.HeaderText = "크기(mm)";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            //
            // colVisible
            //
            this.colVisible.FillWeight = 45F;
            this.colVisible.HeaderText = "표시";
            this.colVisible.Name = "colVisible";
            this.colVisible.ReadOnly = true;
            //
            // grpOverlaps
            //
            this.grpOverlaps.Controls.Add(this.dgvOverlaps);
            this.grpOverlaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOverlaps.Location = new System.Drawing.Point(0, 0);
            this.grpOverlaps.Name = "grpOverlaps";
            this.grpOverlaps.Size = new System.Drawing.Size(376, 316);
            this.grpOverlaps.TabIndex = 0;
            this.grpOverlaps.TabStop = false;
            this.grpOverlaps.Text = "겹침 (더블클릭 → 두 공간 선택)";
            //
            // dgvOverlaps
            //
            this.dgvOverlaps.AllowUserToAddRows = false;
            this.dgvOverlaps.AllowUserToDeleteRows = false;
            this.dgvOverlaps.AllowUserToResizeRows = false;
            this.dgvOverlaps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOverlaps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOverlaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverlaps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colA,
            this.colB,
            this.colOverlapVolume});
            this.dgvOverlaps.Location = new System.Drawing.Point(12, 24);
            this.dgvOverlaps.MultiSelect = false;
            this.dgvOverlaps.Name = "dgvOverlaps";
            this.dgvOverlaps.ReadOnly = true;
            this.dgvOverlaps.RowHeadersVisible = false;
            this.dgvOverlaps.RowTemplate.Height = 23;
            this.dgvOverlaps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOverlaps.Size = new System.Drawing.Size(352, 280);
            this.dgvOverlaps.TabIndex = 0;
            this.dgvOverlaps.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOverlaps_CellDoubleClick);
            //
            // colA
            //
            this.colA.FillWeight = 100F;
            this.colA.HeaderText = "공간 A";
            this.colA.Name = "colA";
            this.colA.ReadOnly = true;
            //
            // colB
            //
            this.colB.FillWeight = 100F;
            this.colB.HeaderText = "공간 B";
            this.colB.Name = "colB";
            this.colB.ReadOnly = true;
            //
            // colOverlapVolume
            //
            this.colOverlapVolume.FillWeight = 80F;
            this.colOverlapVolume.HeaderText = "겹침 체적(m³)";
            this.colOverlapVolume.Name = "colOverlapVolume";
            this.colOverlapVolume.ReadOnly = true;
            //
            // FrmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.Zone";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpFile.ResumeLayout(false);
            this.grpInteract.ResumeLayout(false);
            this.grpInteract.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).EndInit();
            this.grpCreate.ResumeLayout(false);
            this.grpCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGridY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGridX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMargin)).EndInit();
            this.grpModel.ResumeLayout(false);
            this.grpCleanup.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.grpZones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).EndInit();
            this.grpOverlaps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverlaps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Label lblModelHint;
        private System.Windows.Forms.GroupBox grpCreate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblMargin;
        private System.Windows.Forms.NumericUpDown numMargin;
        private System.Windows.Forms.Label lblGrid;
        private System.Windows.Forms.NumericUpDown numGridX;
        private System.Windows.Forms.Label lblGridX;
        private System.Windows.Forms.NumericUpDown numGridY;
        private System.Windows.Forms.Button btnCreateGrid;
        private System.Windows.Forms.Button btnFromNodes;
        private System.Windows.Forms.Button btnFromSelectionBox;
        private System.Windows.Forms.GroupBox grpInteract;
        private System.Windows.Forms.CheckBox chkViewPicking;
        private System.Windows.Forms.CheckBox chkFaceDrag;
        private System.Windows.Forms.CheckBox chkFollow;
        private System.Windows.Forms.Label lblOption;
        private System.Windows.Forms.ComboBox cmbOption;
        private System.Windows.Forms.Button btnSelectNodes;
        private System.Windows.Forms.Button btnIsolateNodes;
        private System.Windows.Forms.Button btnFit;
        private System.Windows.Forms.Button btnUnion;
        private System.Windows.Forms.Button btnSubtract;
        private System.Windows.Forms.CheckBox chkDeleteSources;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label lblOpacity;
        private System.Windows.Forms.NumericUpDown numOpacity;
        private System.Windows.Forms.Button btnApplyStyle;
        private System.Windows.Forms.Button btnOverlaps;
        private System.Windows.Forms.GroupBox grpFile;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnImportReplace;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnHideAll;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox grpZones;
        private System.Windows.Forms.DataGridView dgvZones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisible;
        private System.Windows.Forms.Button btnToggleVisible;
        private System.Windows.Forms.GroupBox grpOverlaps;
        private System.Windows.Forms.DataGridView dgvOverlaps;
        private System.Windows.Forms.DataGridViewTextBoxColumn colA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOverlapVolume;
    }
}
