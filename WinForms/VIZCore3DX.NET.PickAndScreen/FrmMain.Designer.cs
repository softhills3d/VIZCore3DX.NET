namespace VIZCore3DX.NET.PickAndScreen
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
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.dgvHits = new System.Windows.Forms.DataGridView();
            this.colHitNode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHits = new System.Windows.Forms.Label();
            this.dgvPick = new System.Windows.Forms.DataGridView();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNextPick = new System.Windows.Forms.Button();
            this.lblPick = new System.Windows.Forms.Label();
            this.grpRun = new System.Windows.Forms.GroupBox();
            this.btnScreenAll = new System.Windows.Forms.Button();
            this.btnScreenRect = new System.Windows.Forms.Button();
            this.btnCenterRect = new System.Windows.Forms.Button();
            this.numY2 = new System.Windows.Forms.NumericUpDown();
            this.lblY2 = new System.Windows.Forms.Label();
            this.numX2 = new System.Windows.Forms.NumericUpDown();
            this.lblX2 = new System.Windows.Forms.Label();
            this.numY1 = new System.Windows.Forms.NumericUpDown();
            this.lblY1 = new System.Windows.Forms.Label();
            this.numX1 = new System.Windows.Forms.NumericUpDown();
            this.lblX1 = new System.Windows.Forms.Label();
            this.grpSetup = new System.Windows.Forms.GroupBox();
            this.chkShowRay = new System.Windows.Forms.CheckBox();
            this.chkShowArea = new System.Windows.Forms.CheckBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.chkFullContains = new System.Windows.Forms.CheckBox();
            this.chkFrontOnly = new System.Windows.Forms.CheckBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPick)).BeginInit();
            this.grpRun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX1)).BeginInit();
            this.grpSetup.SuspendLayout();
            this.grpModel.SuspendLayout();
            this.grpCleanup.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpResult);
            this.splitContainer1.Panel1.Controls.Add(this.grpRun);
            this.splitContainer1.Panel1.Controls.Add(this.grpSetup);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Controls.Add(this.grpCleanup);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 800);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 0;
            //
            // grpResult
            //
            this.grpResult.Controls.Add(this.dgvHits);
            this.grpResult.Controls.Add(this.lblHits);
            this.grpResult.Controls.Add(this.dgvPick);
            this.grpResult.Controls.Add(this.btnNextPick);
            this.grpResult.Controls.Add(this.lblPick);
            this.grpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResult.Location = new System.Drawing.Point(8, 374);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(344, 336);
            this.grpResult.TabIndex = 3;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "4. 결과";
            //
            // dgvHits
            //
            this.dgvHits.AllowUserToAddRows = false;
            this.dgvHits.AllowUserToDeleteRows = false;
            this.dgvHits.AllowUserToResizeRows = false;
            this.dgvHits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHitNode,
            this.colDistance,
            this.colPosition});
            this.dgvHits.Location = new System.Drawing.Point(12, 186);
            this.dgvHits.MultiSelect = false;
            this.dgvHits.Name = "dgvHits";
            this.dgvHits.ReadOnly = true;
            this.dgvHits.RowHeadersVisible = false;
            this.dgvHits.RowTemplate.Height = 23;
            this.dgvHits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHits.Size = new System.Drawing.Size(320, 138);
            this.dgvHits.TabIndex = 4;
            this.dgvHits.SelectionChanged += new System.EventHandler(this.dgvHits_SelectionChanged);
            //
            // colHitNode
            //
            this.colHitNode.FillWeight = 140F;
            this.colHitNode.HeaderText = "노드";
            this.colHitNode.Name = "colHitNode";
            this.colHitNode.ReadOnly = true;
            //
            // colDistance
            //
            this.colDistance.FillWeight = 60F;
            this.colDistance.HeaderText = "거리";
            this.colDistance.Name = "colDistance";
            this.colDistance.ReadOnly = true;
            //
            // colPosition
            //
            this.colPosition.FillWeight = 130F;
            this.colPosition.HeaderText = "위치";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            //
            // lblHits
            //
            this.lblHits.AutoSize = true;
            this.lblHits.Location = new System.Drawing.Point(12, 168);
            this.lblHits.Name = "lblHits";
            this.lblHits.Size = new System.Drawing.Size(180, 12);
            this.lblHits.TabIndex = 3;
            this.lblHits.Text = "광선 충돌 (카메라 → 지점) : 0 개";
            //
            // dgvPick
            //
            this.dgvPick.AllowUserToAddRows = false;
            this.dgvPick.AllowUserToDeleteRows = false;
            this.dgvPick.AllowUserToResizeRows = false;
            this.dgvPick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPick.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPick.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPick.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colType,
            this.colObject,
            this.colOrder});
            this.dgvPick.Location = new System.Drawing.Point(12, 48);
            this.dgvPick.MultiSelect = false;
            this.dgvPick.Name = "dgvPick";
            this.dgvPick.ReadOnly = true;
            this.dgvPick.RowHeadersVisible = false;
            this.dgvPick.RowTemplate.Height = 23;
            this.dgvPick.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPick.Size = new System.Drawing.Size(320, 110);
            this.dgvPick.TabIndex = 2;
            this.dgvPick.SelectionChanged += new System.EventHandler(this.dgvPick_SelectionChanged);
            //
            // colType
            //
            this.colType.FillWeight = 70F;
            this.colType.HeaderText = "종류";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            //
            // colObject
            //
            this.colObject.FillWeight = 160F;
            this.colObject.HeaderText = "개체";
            this.colObject.Name = "colObject";
            this.colObject.ReadOnly = true;
            //
            // colOrder
            //
            this.colOrder.FillWeight = 30F;
            this.colOrder.HeaderText = "#";
            this.colOrder.Name = "colOrder";
            this.colOrder.ReadOnly = true;
            //
            // btnNextPick
            //
            this.btnNextPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPick.Location = new System.Drawing.Point(212, 20);
            this.btnNextPick.Name = "btnNextPick";
            this.btnNextPick.Size = new System.Drawing.Size(120, 23);
            this.btnNextPick.TabIndex = 1;
            this.btnNextPick.Text = "다음 개체(순환)";
            this.btnNextPick.UseVisualStyleBackColor = true;
            this.btnNextPick.Click += new System.EventHandler(this.btnNextPick_Click);
            //
            // lblPick
            //
            this.lblPick.AutoSize = true;
            this.lblPick.Location = new System.Drawing.Point(12, 26);
            this.lblPick.Name = "lblPick";
            this.lblPick.Size = new System.Drawing.Size(160, 12);
            this.lblPick.TabIndex = 0;
            this.lblPick.Text = "픽 결과 (우클릭 지점) : 0 개";
            //
            // grpRun
            //
            this.grpRun.Controls.Add(this.lblArea);
            this.grpRun.Controls.Add(this.btnScreenAll);
            this.grpRun.Controls.Add(this.btnScreenRect);
            this.grpRun.Controls.Add(this.btnCenterRect);
            this.grpRun.Controls.Add(this.numY2);
            this.grpRun.Controls.Add(this.lblY2);
            this.grpRun.Controls.Add(this.numX2);
            this.grpRun.Controls.Add(this.lblX2);
            this.grpRun.Controls.Add(this.numY1);
            this.grpRun.Controls.Add(this.lblY1);
            this.grpRun.Controls.Add(this.numX1);
            this.grpRun.Controls.Add(this.lblX1);
            this.grpRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRun.Location = new System.Drawing.Point(8, 254);
            this.grpRun.Name = "grpRun";
            this.grpRun.Size = new System.Drawing.Size(344, 120);
            this.grpRun.TabIndex = 2;
            this.grpRun.TabStop = false;
            this.grpRun.Text = "3. 영역 조회";
            //
            // btnScreenAll
            //
            this.btnScreenAll.Location = new System.Drawing.Point(224, 54);
            this.btnScreenAll.Name = "btnScreenAll";
            this.btnScreenAll.Size = new System.Drawing.Size(108, 23);
            this.btnScreenAll.TabIndex = 10;
            this.btnScreenAll.Text = "전체 화면 조회";
            this.btnScreenAll.UseVisualStyleBackColor = true;
            this.btnScreenAll.Click += new System.EventHandler(this.btnScreenAll_Click);
            //
            // btnScreenRect
            //
            this.btnScreenRect.Location = new System.Drawing.Point(136, 54);
            this.btnScreenRect.Name = "btnScreenRect";
            this.btnScreenRect.Size = new System.Drawing.Size(84, 23);
            this.btnScreenRect.TabIndex = 9;
            this.btnScreenRect.Text = "영역 조회";
            this.btnScreenRect.UseVisualStyleBackColor = true;
            this.btnScreenRect.Click += new System.EventHandler(this.btnScreenRect_Click);
            //
            // btnCenterRect
            //
            this.btnCenterRect.Location = new System.Drawing.Point(12, 54);
            this.btnCenterRect.Name = "btnCenterRect";
            this.btnCenterRect.Size = new System.Drawing.Size(120, 23);
            this.btnCenterRect.TabIndex = 8;
            this.btnCenterRect.Text = "중앙 절반 채우기";
            this.btnCenterRect.UseVisualStyleBackColor = true;
            this.btnCenterRect.Click += new System.EventHandler(this.btnCenterRect_Click);
            //
            // numY2
            //
            this.numY2.Location = new System.Drawing.Point(272, 24);
            this.numY2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numY2.Name = "numY2";
            this.numY2.Size = new System.Drawing.Size(60, 21);
            this.numY2.TabIndex = 7;
            //
            // lblY2
            //
            this.lblY2.AutoSize = true;
            this.lblY2.Location = new System.Drawing.Point(252, 28);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(18, 12);
            this.lblY2.TabIndex = 6;
            this.lblY2.Text = "Y2";
            //
            // numX2
            //
            this.numX2.Location = new System.Drawing.Point(192, 24);
            this.numX2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numX2.Name = "numX2";
            this.numX2.Size = new System.Drawing.Size(56, 21);
            this.numX2.TabIndex = 5;
            //
            // lblX2
            //
            this.lblX2.AutoSize = true;
            this.lblX2.Location = new System.Drawing.Point(172, 28);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(18, 12);
            this.lblX2.TabIndex = 4;
            this.lblX2.Text = "X2";
            //
            // numY1
            //
            this.numY1.Location = new System.Drawing.Point(112, 24);
            this.numY1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numY1.Name = "numY1";
            this.numY1.Size = new System.Drawing.Size(56, 21);
            this.numY1.TabIndex = 3;
            //
            // lblY1
            //
            this.lblY1.AutoSize = true;
            this.lblY1.Location = new System.Drawing.Point(92, 28);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(18, 12);
            this.lblY1.TabIndex = 2;
            this.lblY1.Text = "Y1";
            //
            // numX1
            //
            this.numX1.Location = new System.Drawing.Point(32, 24);
            this.numX1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numX1.Name = "numX1";
            this.numX1.Size = new System.Drawing.Size(56, 21);
            this.numX1.TabIndex = 1;
            //
            // lblX1
            //
            this.lblX1.AutoSize = true;
            this.lblX1.Location = new System.Drawing.Point(12, 28);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(18, 12);
            this.lblX1.TabIndex = 0;
            this.lblX1.Text = "X1";
            //
            // grpSetup
            //
            this.grpSetup.Controls.Add(this.chkShowArea);
            this.grpSetup.Controls.Add(this.chkShowRay);
            this.grpSetup.Controls.Add(this.chkFullContains);
            this.grpSetup.Controls.Add(this.chkFrontOnly);
            this.grpSetup.Controls.Add(this.cmbFilter);
            this.grpSetup.Controls.Add(this.lblFilter);
            this.grpSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSetup.Location = new System.Drawing.Point(8, 104);
            this.grpSetup.Name = "grpSetup";
            this.grpSetup.Size = new System.Drawing.Size(344, 150);
            this.grpSetup.TabIndex = 1;
            this.grpSetup.TabStop = false;
            this.grpSetup.Text = "2. 설정";
            //
            // chkShowRay
            //
            this.chkShowRay.AutoSize = true;
            this.chkShowRay.Checked = true;
            this.chkShowRay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowRay.Location = new System.Drawing.Point(12, 96);
            this.chkShowRay.Name = "chkShowRay";
            this.chkShowRay.Size = new System.Drawing.Size(116, 16);
            this.chkShowRay.TabIndex = 4;
            this.chkShowRay.Text = "광선·충돌점 표시";
            this.chkShowRay.UseVisualStyleBackColor = true;
            this.chkShowRay.CheckedChanged += new System.EventHandler(this.chkShowRay_CheckedChanged);
            //
            // chkShowArea
            //
            this.chkShowArea.AutoSize = true;
            this.chkShowArea.Checked = true;
            this.chkShowArea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowArea.Location = new System.Drawing.Point(12, 118);
            this.chkShowArea.Name = "chkShowArea";
            this.chkShowArea.Size = new System.Drawing.Size(104, 16);
            this.chkShowArea.TabIndex = 5;
            this.chkShowArea.Text = "조회 영역 표시";
            this.chkShowArea.UseVisualStyleBackColor = true;
            this.chkShowArea.CheckedChanged += new System.EventHandler(this.chkShowArea_CheckedChanged);
            //
            // lblArea
            //
            this.lblArea.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArea.Location = new System.Drawing.Point(12, 84);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(320, 24);
            this.lblArea.TabIndex = 11;
            this.lblArea.Text = "영역 조회 결과 : -";
            this.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // chkFullContains
            //
            this.chkFullContains.AutoSize = true;
            this.chkFullContains.Location = new System.Drawing.Point(12, 74);
            this.chkFullContains.Name = "chkFullContains";
            this.chkFullContains.Size = new System.Drawing.Size(184, 16);
            this.chkFullContains.TabIndex = 3;
            this.chkFullContains.Text = "영역에 완전히 포함된 개체만";
            this.chkFullContains.UseVisualStyleBackColor = true;
            this.chkFullContains.CheckedChanged += new System.EventHandler(this.chkFullContains_CheckedChanged);
            //
            // chkFrontOnly
            //
            this.chkFrontOnly.AutoSize = true;
            this.chkFrontOnly.Location = new System.Drawing.Point(12, 52);
            this.chkFrontOnly.Name = "chkFrontOnly";
            this.chkFrontOnly.Size = new System.Drawing.Size(220, 16);
            this.chkFrontOnly.TabIndex = 2;
            this.chkFrontOnly.Text = "가려진 개체 제외(FrontObjectOnly)";
            this.chkFrontOnly.UseVisualStyleBackColor = true;
            this.chkFrontOnly.CheckedChanged += new System.EventHandler(this.chkFrontOnly_CheckedChanged);
            //
            // cmbFilter
            //
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFilter.Location = new System.Drawing.Point(80, 24);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(252, 20);
            this.cmbFilter.TabIndex = 1;
            //
            // lblFilter
            //
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(12, 28);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(41, 12);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "픽 대상";
            //
            // grpModel
            //
            this.grpModel.Controls.Add(this.lblModelHint);
            this.grpModel.Controls.Add(this.btnOpenModel);
            this.grpModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpModel.Location = new System.Drawing.Point(8, 8);
            this.grpModel.Name = "grpModel";
            this.grpModel.Size = new System.Drawing.Size(344, 96);
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
            this.lblModelHint.Size = new System.Drawing.Size(320, 32);
            this.lblModelHint.TabIndex = 1;
            this.lblModelHint.Text = "모델을 열고 3D 뷰에서 마우스 오른쪽 버튼을 누르면\r\n그 지점의 개체와 광선 충돌 결과가 4. 결과에 표시됩니다.";
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
            this.grpCleanup.Controls.Add(this.btnClearSelection);
            this.grpCleanup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCleanup.Location = new System.Drawing.Point(8, 710);
            this.grpCleanup.Name = "grpCleanup";
            this.grpCleanup.Size = new System.Drawing.Size(344, 60);
            this.grpCleanup.TabIndex = 4;
            this.grpCleanup.TabStop = false;
            this.grpCleanup.Text = "5. 정리";
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(174, 24);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(158, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "결과 지우기";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnClearSelection
            //
            this.btnClearSelection.Location = new System.Drawing.Point(12, 24);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(158, 23);
            this.btnClearSelection.TabIndex = 0;
            this.btnClearSelection.Text = "선택 해제";
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            //
            // lblStatus
            //
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(8, 770);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(344, 22);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // FrmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.PickAndScreen";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpResult.ResumeLayout(false);
            this.grpResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPick)).EndInit();
            this.grpRun.ResumeLayout(false);
            this.grpRun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX1)).EndInit();
            this.grpSetup.ResumeLayout(false);
            this.grpSetup.PerformLayout();
            this.grpModel.ResumeLayout(false);
            this.grpModel.PerformLayout();
            this.grpCleanup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Label lblModelHint;
        private System.Windows.Forms.GroupBox grpSetup;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.CheckBox chkFrontOnly;
        private System.Windows.Forms.CheckBox chkFullContains;
        private System.Windows.Forms.CheckBox chkShowRay;
        private System.Windows.Forms.CheckBox chkShowArea;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.GroupBox grpRun;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.NumericUpDown numX1;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.NumericUpDown numY1;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.NumericUpDown numX2;
        private System.Windows.Forms.Label lblY2;
        private System.Windows.Forms.NumericUpDown numY2;
        private System.Windows.Forms.Button btnCenterRect;
        private System.Windows.Forms.Button btnScreenRect;
        private System.Windows.Forms.Button btnScreenAll;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.Label lblPick;
        private System.Windows.Forms.Button btnNextPick;
        private System.Windows.Forms.DataGridView dgvPick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrder;
        private System.Windows.Forms.Label lblHits;
        private System.Windows.Forms.DataGridView dgvHits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHitNode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.Button btnClearSelection;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStatus;
    }
}
