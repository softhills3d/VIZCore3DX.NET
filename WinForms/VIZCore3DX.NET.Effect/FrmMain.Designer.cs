namespace VIZCore3DX.NET.Effect
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
            this.grpPoints = new System.Windows.Forms.GroupBox();
            this.lvPoints = new System.Windows.Forms.ListView();
            this.colPointNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPointPosition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPointSnap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClearPoints = new System.Windows.Forms.Button();
            this.btnRemovePoint = new System.Windows.Forms.Button();
            this.btnPickPoint = new System.Windows.Forms.Button();
            this.chkSnapCircle = new System.Windows.Forms.CheckBox();
            this.chkSnapLine = new System.Windows.Forms.CheckBox();
            this.chkSnapVertex = new System.Windows.Forms.CheckBox();
            this.chkSnapSurface = new System.Windows.Forms.CheckBox();
            this.lblPointGuide = new System.Windows.Forms.Label();
            this.grpSetup = new System.Windows.Forms.GroupBox();
            this.lblNoOptions = new System.Windows.Forms.Label();
            this.txtOptionText = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.cmbSpecial = new System.Windows.Forms.ComboBox();
            this.lblSpecial = new System.Windows.Forms.Label();
            this.chkOption2 = new System.Windows.Forms.CheckBox();
            this.chkOption1 = new System.Windows.Forms.CheckBox();
            this.numOption3 = new System.Windows.Forms.NumericUpDown();
            this.lblOption3 = new System.Windows.Forms.Label();
            this.numOption2 = new System.Windows.Forms.NumericUpDown();
            this.lblOption2 = new System.Windows.Forms.Label();
            this.numOption1 = new System.Windows.Forms.NumericUpDown();
            this.lblOption1 = new System.Windows.Forms.Label();
            this.btnEffectColor = new System.Windows.Forms.Button();
            this.lblColor = new System.Windows.Forms.Label();
            this.cmbEffectType = new System.Windows.Forms.ComboBox();
            this.lblEffectType = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpRun = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnClearType = new System.Windows.Forms.Button();
            this.cmbClearType = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.btnApplyWeldingSettings = new System.Windows.Forms.Button();
            this.numWeldingCapacity = new System.Windows.Forms.NumericUpDown();
            this.lblWeldingCapacity = new System.Windows.Forms.Label();
            this.chkWeldingBounce = new System.Windows.Forms.CheckBox();
            this.btnSetSpinnerProgress = new System.Windows.Forms.Button();
            this.chkSpinnerContinuous = new System.Windows.Forms.CheckBox();
            this.numSpinnerProgress = new System.Windows.Forms.NumericUpDown();
            this.lblSpinnerProgress = new System.Windows.Forms.Label();
            this.chkTextLabelVisible = new System.Windows.Forms.CheckBox();
            this.chkMarkerVisible = new System.Windows.Forms.CheckBox();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.lvEffects = new System.Windows.Forms.ListView();
            this.colEffectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEffectType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEffectPosition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEffectSummary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefreshEffects = new System.Windows.Forms.Button();
            this.cmbQueryType = new System.Windows.Forms.ComboBox();
            this.cmbQueryMode = new System.Windows.Forms.ComboBox();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.txtEffectCount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpPoints.SuspendLayout();
            this.grpSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOption3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOption2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOption1)).BeginInit();
            this.grpModel.SuspendLayout();
            this.grpRun.SuspendLayout();
            this.grpCleanup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldingCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpinnerProgress)).BeginInit();
            this.grpStatus.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpPoints);
            this.splitContainer1.Panel1.Controls.Add(this.grpSetup);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Controls.Add(this.grpRun);
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
            // grpPoints
            //
            this.grpPoints.Controls.Add(this.lvPoints);
            this.grpPoints.Controls.Add(this.btnClearPoints);
            this.grpPoints.Controls.Add(this.btnRemovePoint);
            this.grpPoints.Controls.Add(this.btnPickPoint);
            this.grpPoints.Controls.Add(this.chkSnapCircle);
            this.grpPoints.Controls.Add(this.chkSnapLine);
            this.grpPoints.Controls.Add(this.chkSnapVertex);
            this.grpPoints.Controls.Add(this.chkSnapSurface);
            this.grpPoints.Controls.Add(this.lblPointGuide);
            this.grpPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPoints.Location = new System.Drawing.Point(8, 356);
            this.grpPoints.Name = "grpPoints";
            this.grpPoints.Size = new System.Drawing.Size(360, 264);
            this.grpPoints.TabIndex = 2;
            this.grpPoints.TabStop = false;
            this.grpPoints.Text = "3. 위치";
            //
            // lvPoints
            //
            this.lvPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPointNo,
            this.colPointPosition,
            this.colPointSnap});
            this.lvPoints.FullRowSelect = true;
            this.lvPoints.GridLines = true;
            this.lvPoints.HideSelection = false;
            this.lvPoints.Location = new System.Drawing.Point(12, 104);
            this.lvPoints.MultiSelect = false;
            this.lvPoints.Name = "lvPoints";
            this.lvPoints.Size = new System.Drawing.Size(336, 148);
            this.lvPoints.TabIndex = 8;
            this.lvPoints.UseCompatibleStateImageBehavior = false;
            this.lvPoints.View = System.Windows.Forms.View.Details;
            //
            // colPointNo
            //
            this.colPointNo.Text = "번호";
            this.colPointNo.Width = 40;
            //
            // colPointPosition
            //
            this.colPointPosition.Text = "위치";
            this.colPointPosition.Width = 210;
            //
            // colPointSnap
            //
            this.colPointSnap.Text = "스냅";
            this.colPointSnap.Width = 80;
            //
            // btnClearPoints
            //
            this.btnClearPoints.Location = new System.Drawing.Point(244, 74);
            this.btnClearPoints.Name = "btnClearPoints";
            this.btnClearPoints.Size = new System.Drawing.Size(104, 23);
            this.btnClearPoints.TabIndex = 7;
            this.btnClearPoints.Text = "점 모두 지우기";
            this.btnClearPoints.UseVisualStyleBackColor = true;
            this.btnClearPoints.Click += new System.EventHandler(this.btnClearPoints_Click);
            //
            // btnRemovePoint
            //
            this.btnRemovePoint.Location = new System.Drawing.Point(138, 74);
            this.btnRemovePoint.Name = "btnRemovePoint";
            this.btnRemovePoint.Size = new System.Drawing.Size(100, 23);
            this.btnRemovePoint.TabIndex = 6;
            this.btnRemovePoint.Text = "선택 점 제거";
            this.btnRemovePoint.UseVisualStyleBackColor = true;
            this.btnRemovePoint.Click += new System.EventHandler(this.btnRemovePoint_Click);
            //
            // btnPickPoint
            //
            this.btnPickPoint.Location = new System.Drawing.Point(12, 74);
            this.btnPickPoint.Name = "btnPickPoint";
            this.btnPickPoint.Size = new System.Drawing.Size(120, 23);
            this.btnPickPoint.TabIndex = 5;
            this.btnPickPoint.Text = "위치 집기";
            this.btnPickPoint.UseVisualStyleBackColor = true;
            this.btnPickPoint.Click += new System.EventHandler(this.btnPickPoint_Click);
            //
            // chkSnapCircle
            //
            this.chkSnapCircle.AutoSize = true;
            this.chkSnapCircle.Checked = true;
            this.chkSnapCircle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSnapCircle.Location = new System.Drawing.Point(198, 52);
            this.chkSnapCircle.Name = "chkSnapCircle";
            this.chkSnapCircle.Size = new System.Drawing.Size(36, 16);
            this.chkSnapCircle.TabIndex = 4;
            this.chkSnapCircle.Text = "원";
            this.chkSnapCircle.UseVisualStyleBackColor = true;
            //
            // chkSnapLine
            //
            this.chkSnapLine.AutoSize = true;
            this.chkSnapLine.Checked = true;
            this.chkSnapLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSnapLine.Location = new System.Drawing.Point(140, 52);
            this.chkSnapLine.Name = "chkSnapLine";
            this.chkSnapLine.Size = new System.Drawing.Size(36, 16);
            this.chkSnapLine.TabIndex = 3;
            this.chkSnapLine.Text = "선";
            this.chkSnapLine.UseVisualStyleBackColor = true;
            //
            // chkSnapVertex
            //
            this.chkSnapVertex.AutoSize = true;
            this.chkSnapVertex.Checked = true;
            this.chkSnapVertex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSnapVertex.Location = new System.Drawing.Point(70, 52);
            this.chkSnapVertex.Name = "chkSnapVertex";
            this.chkSnapVertex.Size = new System.Drawing.Size(48, 16);
            this.chkSnapVertex.TabIndex = 2;
            this.chkSnapVertex.Text = "정점";
            this.chkSnapVertex.UseVisualStyleBackColor = true;
            //
            // chkSnapSurface
            //
            this.chkSnapSurface.AutoSize = true;
            this.chkSnapSurface.Checked = true;
            this.chkSnapSurface.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSnapSurface.Location = new System.Drawing.Point(12, 52);
            this.chkSnapSurface.Name = "chkSnapSurface";
            this.chkSnapSurface.Size = new System.Drawing.Size(36, 16);
            this.chkSnapSurface.TabIndex = 1;
            this.chkSnapSurface.Text = "면";
            this.chkSnapSurface.UseVisualStyleBackColor = true;
            //
            // lblPointGuide
            //
            this.lblPointGuide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPointGuide.Location = new System.Drawing.Point(12, 20);
            this.lblPointGuide.Name = "lblPointGuide";
            this.lblPointGuide.Size = new System.Drawing.Size(336, 30);
            this.lblPointGuide.TabIndex = 0;
            this.lblPointGuide.Text = "오스냅으로 위치를 고르세요.";
            this.lblPointGuide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // grpSetup
            //
            this.grpSetup.Controls.Add(this.lblNoOptions);
            this.grpSetup.Controls.Add(this.txtOptionText);
            this.grpSetup.Controls.Add(this.lblText);
            this.grpSetup.Controls.Add(this.cmbSpecial);
            this.grpSetup.Controls.Add(this.lblSpecial);
            this.grpSetup.Controls.Add(this.chkOption2);
            this.grpSetup.Controls.Add(this.chkOption1);
            this.grpSetup.Controls.Add(this.numOption3);
            this.grpSetup.Controls.Add(this.lblOption3);
            this.grpSetup.Controls.Add(this.numOption2);
            this.grpSetup.Controls.Add(this.lblOption2);
            this.grpSetup.Controls.Add(this.numOption1);
            this.grpSetup.Controls.Add(this.lblOption1);
            this.grpSetup.Controls.Add(this.btnEffectColor);
            this.grpSetup.Controls.Add(this.lblColor);
            this.grpSetup.Controls.Add(this.cmbEffectType);
            this.grpSetup.Controls.Add(this.lblEffectType);
            this.grpSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSetup.Location = new System.Drawing.Point(8, 104);
            this.grpSetup.Name = "grpSetup";
            this.grpSetup.Size = new System.Drawing.Size(360, 252);
            this.grpSetup.TabIndex = 1;
            this.grpSetup.TabStop = false;
            this.grpSetup.Text = "2. 종류·옵션";
            //
            // lblNoOptions
            //
            this.lblNoOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoOptions.Location = new System.Drawing.Point(12, 80);
            this.lblNoOptions.Name = "lblNoOptions";
            this.lblNoOptions.Size = new System.Drawing.Size(336, 32);
            this.lblNoOptions.TabIndex = 16;
            this.lblNoOptions.Text = "개별 옵션이 없습니다.";
            //
            // txtOptionText
            //
            this.txtOptionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOptionText.Location = new System.Drawing.Point(100, 220);
            this.txtOptionText.Name = "txtOptionText";
            this.txtOptionText.Size = new System.Drawing.Size(248, 21);
            this.txtOptionText.TabIndex = 15;
            //
            // lblText
            //
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(12, 224);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(41, 12);
            this.lblText.TabIndex = 14;
            this.lblText.Text = "문자열";
            //
            // cmbSpecial
            //
            this.cmbSpecial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSpecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecial.Location = new System.Drawing.Point(100, 192);
            this.cmbSpecial.Name = "cmbSpecial";
            this.cmbSpecial.Size = new System.Drawing.Size(248, 20);
            this.cmbSpecial.TabIndex = 13;
            this.cmbSpecial.SelectedIndexChanged += new System.EventHandler(this.cmbSpecial_SelectedIndexChanged);
            //
            // lblSpecial
            //
            this.lblSpecial.AutoSize = true;
            this.lblSpecial.Location = new System.Drawing.Point(12, 196);
            this.lblSpecial.Name = "lblSpecial";
            this.lblSpecial.Size = new System.Drawing.Size(57, 12);
            this.lblSpecial.TabIndex = 12;
            this.lblSpecial.Text = "추가 설정";
            //
            // chkOption2
            //
            this.chkOption2.AutoSize = true;
            this.chkOption2.Location = new System.Drawing.Point(180, 166);
            this.chkOption2.Name = "chkOption2";
            this.chkOption2.Size = new System.Drawing.Size(60, 16);
            this.chkOption2.TabIndex = 11;
            this.chkOption2.Text = "옵션 2";
            this.chkOption2.UseVisualStyleBackColor = true;
            //
            // chkOption1
            //
            this.chkOption1.AutoSize = true;
            this.chkOption1.Location = new System.Drawing.Point(12, 166);
            this.chkOption1.Name = "chkOption1";
            this.chkOption1.Size = new System.Drawing.Size(60, 16);
            this.chkOption1.TabIndex = 10;
            this.chkOption1.Text = "옵션 1";
            this.chkOption1.UseVisualStyleBackColor = true;
            //
            // numOption3
            //
            this.numOption3.DecimalPlaces = 1;
            this.numOption3.Location = new System.Drawing.Point(150, 136);
            this.numOption3.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numOption3.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numOption3.Name = "numOption3";
            this.numOption3.Size = new System.Drawing.Size(100, 21);
            this.numOption3.TabIndex = 9;
            this.numOption3.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            //
            // lblOption3
            //
            this.lblOption3.AutoSize = true;
            this.lblOption3.Location = new System.Drawing.Point(12, 140);
            this.lblOption3.Name = "lblOption3";
            this.lblOption3.Size = new System.Drawing.Size(41, 12);
            this.lblOption3.TabIndex = 8;
            this.lblOption3.Text = "옵션 3";
            //
            // numOption2
            //
            this.numOption2.DecimalPlaces = 1;
            this.numOption2.Location = new System.Drawing.Point(150, 108);
            this.numOption2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numOption2.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numOption2.Name = "numOption2";
            this.numOption2.Size = new System.Drawing.Size(100, 21);
            this.numOption2.TabIndex = 7;
            this.numOption2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            //
            // lblOption2
            //
            this.lblOption2.AutoSize = true;
            this.lblOption2.Location = new System.Drawing.Point(12, 112);
            this.lblOption2.Name = "lblOption2";
            this.lblOption2.Size = new System.Drawing.Size(41, 12);
            this.lblOption2.TabIndex = 6;
            this.lblOption2.Text = "옵션 2";
            //
            // numOption1
            //
            this.numOption1.DecimalPlaces = 1;
            this.numOption1.Location = new System.Drawing.Point(150, 80);
            this.numOption1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numOption1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numOption1.Name = "numOption1";
            this.numOption1.Size = new System.Drawing.Size(100, 21);
            this.numOption1.TabIndex = 5;
            this.numOption1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            //
            // lblOption1
            //
            this.lblOption1.AutoSize = true;
            this.lblOption1.Location = new System.Drawing.Point(12, 84);
            this.lblOption1.Name = "lblOption1";
            this.lblOption1.Size = new System.Drawing.Size(41, 12);
            this.lblOption1.TabIndex = 4;
            this.lblOption1.Text = "옵션 1";
            //
            // btnEffectColor
            //
            this.btnEffectColor.Location = new System.Drawing.Point(100, 51);
            this.btnEffectColor.Name = "btnEffectColor";
            this.btnEffectColor.Size = new System.Drawing.Size(120, 23);
            this.btnEffectColor.TabIndex = 3;
            this.btnEffectColor.Text = "색 선택";
            this.btnEffectColor.UseVisualStyleBackColor = false;
            this.btnEffectColor.Click += new System.EventHandler(this.btnEffectColor_Click);
            //
            // lblColor
            //
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(12, 56);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(29, 12);
            this.lblColor.TabIndex = 2;
            this.lblColor.Text = "색상";
            //
            // cmbEffectType
            //
            this.cmbEffectType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEffectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEffectType.Location = new System.Drawing.Point(100, 24);
            this.cmbEffectType.Name = "cmbEffectType";
            this.cmbEffectType.Size = new System.Drawing.Size(248, 20);
            this.cmbEffectType.TabIndex = 1;
            this.cmbEffectType.SelectedIndexChanged += new System.EventHandler(this.cmbEffectType_SelectedIndexChanged);
            //
            // lblEffectType
            //
            this.lblEffectType.AutoSize = true;
            this.lblEffectType.Location = new System.Drawing.Point(12, 28);
            this.lblEffectType.Name = "lblEffectType";
            this.lblEffectType.Size = new System.Drawing.Size(29, 12);
            this.lblEffectType.TabIndex = 0;
            this.lblEffectType.Text = "종류";
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
            this.lblModelHint.Size = new System.Drawing.Size(320, 32);
            this.lblModelHint.TabIndex = 1;
            this.lblModelHint.Text = "모델을 연 뒤 효과 종류와 위치를 고르고 생성합니다.\r\n위치는 뷰에서 오스냅으로 집습니다.";
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
            // grpRun
            //
            this.grpRun.Controls.Add(this.btnCreate);
            this.grpRun.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpRun.Location = new System.Drawing.Point(8, 620);
            this.grpRun.Name = "grpRun";
            this.grpRun.Size = new System.Drawing.Size(360, 60);
            this.grpRun.TabIndex = 3;
            this.grpRun.TabStop = false;
            this.grpRun.Text = "4. 생성";
            //
            // btnCreate
            //
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(12, 24);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(336, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "효과 생성";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            //
            // grpCleanup
            //
            this.grpCleanup.Controls.Add(this.btnClearAll);
            this.grpCleanup.Controls.Add(this.btnClearType);
            this.grpCleanup.Controls.Add(this.cmbClearType);
            this.grpCleanup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCleanup.Location = new System.Drawing.Point(8, 680);
            this.grpCleanup.Name = "grpCleanup";
            this.grpCleanup.Size = new System.Drawing.Size(360, 90);
            this.grpCleanup.TabIndex = 4;
            this.grpCleanup.TabStop = false;
            this.grpCleanup.Text = "5. 정리";
            //
            // btnClearAll
            //
            this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearAll.Location = new System.Drawing.Point(12, 54);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(336, 23);
            this.btnClearAll.TabIndex = 2;
            this.btnClearAll.Text = "모든 효과 지우기";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            //
            // btnClearType
            //
            this.btnClearType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearType.Location = new System.Drawing.Point(246, 23);
            this.btnClearType.Name = "btnClearType";
            this.btnClearType.Size = new System.Drawing.Size(102, 23);
            this.btnClearType.TabIndex = 1;
            this.btnClearType.Text = "종류 지우기";
            this.btnClearType.UseVisualStyleBackColor = true;
            this.btnClearType.Click += new System.EventHandler(this.btnClearType_Click);
            //
            // cmbClearType
            //
            this.cmbClearType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbClearType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClearType.Location = new System.Drawing.Point(12, 24);
            this.cmbClearType.Name = "cmbClearType";
            this.cmbClearType.Size = new System.Drawing.Size(228, 20);
            this.cmbClearType.TabIndex = 0;
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
            this.splitContainer3.Panel1.Controls.Add(this.grpList);
            //
            // splitContainer3.Panel2
            //
            this.splitContainer3.Panel2.Controls.Add(this.grpStatus);
            this.splitContainer3.Size = new System.Drawing.Size(376, 800);
            this.splitContainer3.SplitterDistance = 480;
            this.splitContainer3.TabIndex = 0;
            //
            // grpList
            //
            this.grpList.Controls.Add(this.btnApplyWeldingSettings);
            this.grpList.Controls.Add(this.numWeldingCapacity);
            this.grpList.Controls.Add(this.lblWeldingCapacity);
            this.grpList.Controls.Add(this.chkWeldingBounce);
            this.grpList.Controls.Add(this.btnSetSpinnerProgress);
            this.grpList.Controls.Add(this.chkSpinnerContinuous);
            this.grpList.Controls.Add(this.numSpinnerProgress);
            this.grpList.Controls.Add(this.lblSpinnerProgress);
            this.grpList.Controls.Add(this.chkTextLabelVisible);
            this.grpList.Controls.Add(this.chkMarkerVisible);
            this.grpList.Controls.Add(this.btnRemoveSelected);
            this.grpList.Controls.Add(this.lvEffects);
            this.grpList.Controls.Add(this.btnRefreshEffects);
            this.grpList.Controls.Add(this.cmbQueryType);
            this.grpList.Controls.Add(this.cmbQueryMode);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Location = new System.Drawing.Point(0, 0);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(376, 480);
            this.grpList.TabIndex = 0;
            this.grpList.TabStop = false;
            this.grpList.Text = "효과 목록";
            //
            // btnApplyWeldingSettings
            //
            this.btnApplyWeldingSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApplyWeldingSettings.Location = new System.Drawing.Point(264, 445);
            this.btnApplyWeldingSettings.Name = "btnApplyWeldingSettings";
            this.btnApplyWeldingSettings.Size = new System.Drawing.Size(100, 23);
            this.btnApplyWeldingSettings.TabIndex = 14;
            this.btnApplyWeldingSettings.Text = "용접 설정 적용";
            this.btnApplyWeldingSettings.UseVisualStyleBackColor = true;
            this.btnApplyWeldingSettings.Click += new System.EventHandler(this.btnApplyWeldingSettings_Click);
            //
            // numWeldingCapacity
            //
            this.numWeldingCapacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numWeldingCapacity.Location = new System.Drawing.Point(160, 446);
            this.numWeldingCapacity.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numWeldingCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeldingCapacity.Name = "numWeldingCapacity";
            this.numWeldingCapacity.Size = new System.Drawing.Size(56, 21);
            this.numWeldingCapacity.TabIndex = 13;
            this.numWeldingCapacity.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            //
            // lblWeldingCapacity
            //
            this.lblWeldingCapacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWeldingCapacity.AutoSize = true;
            this.lblWeldingCapacity.Location = new System.Drawing.Point(96, 450);
            this.lblWeldingCapacity.Name = "lblWeldingCapacity";
            this.lblWeldingCapacity.Size = new System.Drawing.Size(53, 12);
            this.lblWeldingCapacity.TabIndex = 12;
            this.lblWeldingCapacity.Text = "최대 지점";
            //
            // chkWeldingBounce
            //
            this.chkWeldingBounce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkWeldingBounce.AutoSize = true;
            this.chkWeldingBounce.Location = new System.Drawing.Point(12, 449);
            this.chkWeldingBounce.Name = "chkWeldingBounce";
            this.chkWeldingBounce.Size = new System.Drawing.Size(76, 16);
            this.chkWeldingBounce.TabIndex = 11;
            this.chkWeldingBounce.Text = "바닥 튕김";
            this.chkWeldingBounce.UseVisualStyleBackColor = true;
            //
            // btnSetSpinnerProgress
            //
            this.btnSetSpinnerProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetSpinnerProgress.Location = new System.Drawing.Point(264, 416);
            this.btnSetSpinnerProgress.Name = "btnSetSpinnerProgress";
            this.btnSetSpinnerProgress.Size = new System.Drawing.Size(100, 23);
            this.btnSetSpinnerProgress.TabIndex = 10;
            this.btnSetSpinnerProgress.Text = "진행률 적용";
            this.btnSetSpinnerProgress.UseVisualStyleBackColor = true;
            this.btnSetSpinnerProgress.Click += new System.EventHandler(this.btnSetSpinnerProgress_Click);
            //
            // chkSpinnerContinuous
            //
            this.chkSpinnerContinuous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSpinnerContinuous.AutoSize = true;
            this.chkSpinnerContinuous.Location = new System.Drawing.Point(142, 419);
            this.chkSpinnerContinuous.Name = "chkSpinnerContinuous";
            this.chkSpinnerContinuous.Size = new System.Drawing.Size(76, 16);
            this.chkSpinnerContinuous.TabIndex = 9;
            this.chkSpinnerContinuous.Text = "계속 회전";
            this.chkSpinnerContinuous.UseVisualStyleBackColor = true;
            //
            // numSpinnerProgress
            //
            this.numSpinnerProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numSpinnerProgress.Location = new System.Drawing.Point(78, 417);
            this.numSpinnerProgress.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numSpinnerProgress.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numSpinnerProgress.Name = "numSpinnerProgress";
            this.numSpinnerProgress.Size = new System.Drawing.Size(56, 21);
            this.numSpinnerProgress.TabIndex = 8;
            this.numSpinnerProgress.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            //
            // lblSpinnerProgress
            //
            this.lblSpinnerProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSpinnerProgress.AutoSize = true;
            this.lblSpinnerProgress.Location = new System.Drawing.Point(12, 421);
            this.lblSpinnerProgress.Name = "lblSpinnerProgress";
            this.lblSpinnerProgress.Size = new System.Drawing.Size(60, 12);
            this.lblSpinnerProgress.TabIndex = 7;
            this.lblSpinnerProgress.Text = "진행률(%)";
            //
            // chkTextLabelVisible
            //
            this.chkTextLabelVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTextLabelVisible.AutoSize = true;
            this.chkTextLabelVisible.Checked = true;
            this.chkTextLabelVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTextLabelVisible.Location = new System.Drawing.Point(214, 391);
            this.chkTextLabelVisible.Name = "chkTextLabelVisible";
            this.chkTextLabelVisible.Size = new System.Drawing.Size(112, 16);
            this.chkTextLabelVisible.TabIndex = 6;
            this.chkTextLabelVisible.Text = "텍스트 라벨 표시";
            this.chkTextLabelVisible.UseVisualStyleBackColor = true;
            this.chkTextLabelVisible.CheckedChanged += new System.EventHandler(this.chkTextLabelVisible_CheckedChanged);
            //
            // chkMarkerVisible
            //
            this.chkMarkerVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkMarkerVisible.AutoSize = true;
            this.chkMarkerVisible.Checked = true;
            this.chkMarkerVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMarkerVisible.Location = new System.Drawing.Point(124, 391);
            this.chkMarkerVisible.Name = "chkMarkerVisible";
            this.chkMarkerVisible.Size = new System.Drawing.Size(76, 16);
            this.chkMarkerVisible.TabIndex = 5;
            this.chkMarkerVisible.Text = "마커 표시";
            this.chkMarkerVisible.UseVisualStyleBackColor = true;
            this.chkMarkerVisible.CheckedChanged += new System.EventHandler(this.chkMarkerVisible_CheckedChanged);
            //
            // btnRemoveSelected
            //
            this.btnRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveSelected.Location = new System.Drawing.Point(12, 387);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(100, 23);
            this.btnRemoveSelected.TabIndex = 4;
            this.btnRemoveSelected.Text = "선택 효과 제거";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            //
            // lvEffects
            //
            this.lvEffects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvEffects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEffectName,
            this.colEffectType,
            this.colEffectPosition,
            this.colEffectSummary});
            this.lvEffects.FullRowSelect = true;
            this.lvEffects.GridLines = true;
            this.lvEffects.HideSelection = false;
            this.lvEffects.Location = new System.Drawing.Point(12, 52);
            this.lvEffects.MultiSelect = false;
            this.lvEffects.Name = "lvEffects";
            this.lvEffects.Size = new System.Drawing.Size(352, 327);
            this.lvEffects.TabIndex = 3;
            this.lvEffects.UseCompatibleStateImageBehavior = false;
            this.lvEffects.View = System.Windows.Forms.View.Details;
            //
            // colEffectName
            //
            this.colEffectName.Text = "이름";
            this.colEffectName.Width = 100;
            //
            // colEffectType
            //
            this.colEffectType.Text = "종류";
            this.colEffectType.Width = 80;
            //
            // colEffectPosition
            //
            this.colEffectPosition.Text = "위치";
            this.colEffectPosition.Width = 100;
            //
            // colEffectSummary
            //
            this.colEffectSummary.Text = "요약";
            this.colEffectSummary.Width = 100;
            //
            // btnRefreshEffects
            //
            this.btnRefreshEffects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshEffects.Location = new System.Drawing.Point(274, 23);
            this.btnRefreshEffects.Name = "btnRefreshEffects";
            this.btnRefreshEffects.Size = new System.Drawing.Size(90, 23);
            this.btnRefreshEffects.TabIndex = 2;
            this.btnRefreshEffects.Text = "조회";
            this.btnRefreshEffects.UseVisualStyleBackColor = true;
            this.btnRefreshEffects.Click += new System.EventHandler(this.btnRefreshEffects_Click);
            //
            // cmbQueryType
            //
            this.cmbQueryType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQueryType.Enabled = false;
            this.cmbQueryType.Location = new System.Drawing.Point(98, 24);
            this.cmbQueryType.Name = "cmbQueryType";
            this.cmbQueryType.Size = new System.Drawing.Size(170, 20);
            this.cmbQueryType.TabIndex = 1;
            //
            // cmbQueryMode
            //
            this.cmbQueryMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQueryMode.Location = new System.Drawing.Point(12, 24);
            this.cmbQueryMode.Name = "cmbQueryMode";
            this.cmbQueryMode.Size = new System.Drawing.Size(80, 20);
            this.cmbQueryMode.TabIndex = 0;
            this.cmbQueryMode.SelectedIndexChanged += new System.EventHandler(this.cmbQueryMode_SelectedIndexChanged);
            //
            // grpStatus
            //
            this.grpStatus.Controls.Add(this.lstEvents);
            this.grpStatus.Controls.Add(this.txtEffectCount);
            this.grpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStatus.Location = new System.Drawing.Point(0, 0);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(376, 316);
            this.grpStatus.TabIndex = 0;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "상태·이벤트";
            //
            // lstEvents
            //
            this.lstEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEvents.HorizontalScrollbar = true;
            this.lstEvents.IntegralHeight = false;
            this.lstEvents.ItemHeight = 12;
            this.lstEvents.Location = new System.Drawing.Point(190, 24);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(174, 280);
            this.lstEvents.TabIndex = 1;
            //
            // txtEffectCount
            //
            this.txtEffectCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEffectCount.Location = new System.Drawing.Point(12, 24);
            this.txtEffectCount.Multiline = true;
            this.txtEffectCount.Name = "txtEffectCount";
            this.txtEffectCount.ReadOnly = true;
            this.txtEffectCount.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEffectCount.Size = new System.Drawing.Size(172, 280);
            this.txtEffectCount.TabIndex = 0;
            this.txtEffectCount.WordWrap = false;
            //
            // FrmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.Effect";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpPoints.ResumeLayout(false);
            this.grpPoints.PerformLayout();
            this.grpSetup.ResumeLayout(false);
            this.grpSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOption3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOption2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOption1)).EndInit();
            this.grpModel.ResumeLayout(false);
            this.grpRun.ResumeLayout(false);
            this.grpCleanup.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            this.grpList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldingCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpinnerProgress)).EndInit();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Label lblModelHint;
        private System.Windows.Forms.GroupBox grpSetup;
        private System.Windows.Forms.Label lblEffectType;
        private System.Windows.Forms.ComboBox cmbEffectType;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Button btnEffectColor;
        private System.Windows.Forms.Label lblOption1;
        private System.Windows.Forms.NumericUpDown numOption1;
        private System.Windows.Forms.Label lblOption2;
        private System.Windows.Forms.NumericUpDown numOption2;
        private System.Windows.Forms.Label lblOption3;
        private System.Windows.Forms.NumericUpDown numOption3;
        private System.Windows.Forms.CheckBox chkOption1;
        private System.Windows.Forms.CheckBox chkOption2;
        private System.Windows.Forms.Label lblSpecial;
        private System.Windows.Forms.ComboBox cmbSpecial;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtOptionText;
        private System.Windows.Forms.Label lblNoOptions;
        private System.Windows.Forms.GroupBox grpPoints;
        private System.Windows.Forms.Label lblPointGuide;
        private System.Windows.Forms.CheckBox chkSnapSurface;
        private System.Windows.Forms.CheckBox chkSnapVertex;
        private System.Windows.Forms.CheckBox chkSnapLine;
        private System.Windows.Forms.CheckBox chkSnapCircle;
        private System.Windows.Forms.Button btnPickPoint;
        private System.Windows.Forms.Button btnRemovePoint;
        private System.Windows.Forms.Button btnClearPoints;
        private System.Windows.Forms.ListView lvPoints;
        private System.Windows.Forms.ColumnHeader colPointNo;
        private System.Windows.Forms.ColumnHeader colPointPosition;
        private System.Windows.Forms.ColumnHeader colPointSnap;
        private System.Windows.Forms.GroupBox grpRun;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.ComboBox cmbClearType;
        private System.Windows.Forms.Button btnClearType;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.ComboBox cmbQueryMode;
        private System.Windows.Forms.ComboBox cmbQueryType;
        private System.Windows.Forms.Button btnRefreshEffects;
        private System.Windows.Forms.ListView lvEffects;
        private System.Windows.Forms.ColumnHeader colEffectName;
        private System.Windows.Forms.ColumnHeader colEffectType;
        private System.Windows.Forms.ColumnHeader colEffectPosition;
        private System.Windows.Forms.ColumnHeader colEffectSummary;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.CheckBox chkMarkerVisible;
        private System.Windows.Forms.CheckBox chkTextLabelVisible;
        private System.Windows.Forms.Label lblSpinnerProgress;
        private System.Windows.Forms.NumericUpDown numSpinnerProgress;
        private System.Windows.Forms.CheckBox chkSpinnerContinuous;
        private System.Windows.Forms.Button btnSetSpinnerProgress;
        private System.Windows.Forms.CheckBox chkWeldingBounce;
        private System.Windows.Forms.Label lblWeldingCapacity;
        private System.Windows.Forms.NumericUpDown numWeldingCapacity;
        private System.Windows.Forms.Button btnApplyWeldingSettings;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.TextBox txtEffectCount;
        private System.Windows.Forms.ListBox lstEvents;
    }
}
