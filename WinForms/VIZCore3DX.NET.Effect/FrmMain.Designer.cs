namespace VIZCore3DX.NET.Effect
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlEffect = new System.Windows.Forms.TabControl();
            this.tabPageCreate = new System.Windows.Forms.TabPage();
            this.lblCreateResult = new System.Windows.Forms.Label();
            this.btnCreateEffect = new System.Windows.Forms.Button();
            this.groupBoxOsnap = new System.Windows.Forms.GroupBox();
            this.lvPoints = new System.Windows.Forms.ListView();
            this.colPointNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPointType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPointPosition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClearPoints = new System.Windows.Forms.Button();
            this.btnRemovePoint = new System.Windows.Forms.Button();
            this.btnPickPoint = new System.Windows.Forms.Button();
            this.chkSnapCircle = new System.Windows.Forms.CheckBox();
            this.chkSnapLine = new System.Windows.Forms.CheckBox();
            this.chkSnapVertex = new System.Windows.Forms.CheckBox();
            this.chkSnapSurface = new System.Windows.Forms.CheckBox();
            this.lblPointGuide = new System.Windows.Forms.Label();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.lblNoOptions = new System.Windows.Forms.Label();
            this.txtOptionText = new System.Windows.Forms.TextBox();
            this.lblOptionText = new System.Windows.Forms.Label();
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
            this.groupBoxEffectType = new System.Windows.Forms.GroupBox();
            this.cmbEffectType = new System.Windows.Forms.ComboBox();
            this.lblEffectType = new System.Windows.Forms.Label();
            this.tabPageManage = new System.Windows.Forms.TabPage();
            this.groupBoxWelding = new System.Windows.Forms.GroupBox();
            this.btnApplyWeldingSettings = new System.Windows.Forms.Button();
            this.numWeldingSparkCapacity = new System.Windows.Forms.NumericUpDown();
            this.lblWeldingSparkCapacity = new System.Windows.Forms.Label();
            this.chkWeldingSparkBounce = new System.Windows.Forms.CheckBox();
            this.groupBoxSpinner = new System.Windows.Forms.GroupBox();
            this.btnSetSpinnerProgress = new System.Windows.Forms.Button();
            this.chkSpinnerContinuous = new System.Windows.Forms.CheckBox();
            this.numSpinnerProgress = new System.Windows.Forms.NumericUpDown();
            this.lblSpinnerProgress = new System.Windows.Forms.Label();
            this.groupBoxVisible = new System.Windows.Forms.GroupBox();
            this.chkTextLabelVisible = new System.Windows.Forms.CheckBox();
            this.chkMarkerVisible = new System.Windows.Forms.CheckBox();
            this.groupBoxRemove = new System.Windows.Forms.GroupBox();
            this.btnClearType = new System.Windows.Forms.Button();
            this.cmbClearType = new System.Windows.Forms.ComboBox();
            this.lblClearType = new System.Windows.Forms.Label();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.lvEffects = new System.Windows.Forms.ListView();
            this.colEffectId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEffectType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEffectPosition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEffectSummary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblEffectListCount = new System.Windows.Forms.Label();
            this.groupBoxQuery = new System.Windows.Forms.GroupBox();
            this.btnRefreshEffects = new System.Windows.Forms.Button();
            this.cmbQueryType = new System.Windows.Forms.ComboBox();
            this.lblQueryType = new System.Windows.Forms.Label();
            this.cmbQueryMode = new System.Windows.Forms.ComboBox();
            this.lblQueryMode = new System.Windows.Forms.Label();
            this.tabPageStatus = new System.Windows.Forms.TabPage();
            this.splitContainerStatus1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxCount = new System.Windows.Forms.GroupBox();
            this.txtEffectCount = new System.Windows.Forms.TextBox();
            this.splitContainerStatus2 = new System.Windows.Forms.SplitContainer();
            this.groupBoxCapacity = new System.Windows.Forms.GroupBox();
            this.txtEffectCapacity = new System.Windows.Forms.TextBox();
            this.groupBoxEvent = new System.Windows.Forms.GroupBox();
            this.listBoxEvent = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlEffect.SuspendLayout();
            this.tabPageCreate.SuspendLayout();
            this.groupBoxOsnap.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOption3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOption2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOption1)).BeginInit();
            this.groupBoxEffectType.SuspendLayout();
            this.tabPageManage.SuspendLayout();
            this.groupBoxWelding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldingSparkCapacity)).BeginInit();
            this.groupBoxSpinner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpinnerProgress)).BeginInit();
            this.groupBoxVisible.SuspendLayout();
            this.groupBoxRemove.SuspendLayout();
            this.groupBoxQuery.SuspendLayout();
            this.tabPageStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatus1)).BeginInit();
            this.splitContainerStatus1.Panel1.SuspendLayout();
            this.splitContainerStatus1.Panel2.SuspendLayout();
            this.splitContainerStatus1.SuspendLayout();
            this.groupBoxCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatus2)).BeginInit();
            this.splitContainerStatus2.Panel1.SuspendLayout();
            this.splitContainerStatus2.Panel2.SuspendLayout();
            this.splitContainerStatus2.SuspendLayout();
            this.groupBoxCapacity.SuspendLayout();
            this.groupBoxEvent.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.tabControlEffect);
            this.splitContainer1.Panel2MinSize = 570;
            this.splitContainer1.Size = new System.Drawing.Size(1450, 900);
            this.splitContainer1.SplitterDistance = 860;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControlEffect
            // 
            this.tabControlEffect.Controls.Add(this.tabPageCreate);
            this.tabControlEffect.Controls.Add(this.tabPageManage);
            this.tabControlEffect.Controls.Add(this.tabPageStatus);
            this.tabControlEffect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEffect.Location = new System.Drawing.Point(0, 0);
            this.tabControlEffect.Name = "tabControlEffect";
            this.tabControlEffect.SelectedIndex = 0;
            this.tabControlEffect.Size = new System.Drawing.Size(586, 900);
            this.tabControlEffect.TabIndex = 0;
            // 
            // tabPageCreate
            // 
            this.tabPageCreate.AutoScroll = true;
            this.tabPageCreate.Controls.Add(this.lblCreateResult);
            this.tabPageCreate.Controls.Add(this.btnCreateEffect);
            this.tabPageCreate.Controls.Add(this.groupBoxOsnap);
            this.tabPageCreate.Controls.Add(this.groupBoxOptions);
            this.tabPageCreate.Controls.Add(this.groupBoxEffectType);
            this.tabPageCreate.Location = new System.Drawing.Point(4, 22);
            this.tabPageCreate.Name = "tabPageCreate";
            this.tabPageCreate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCreate.Size = new System.Drawing.Size(578, 874);
            this.tabPageCreate.TabIndex = 0;
            this.tabPageCreate.Text = "생성";
            this.tabPageCreate.UseVisualStyleBackColor = true;
            // 
            // groupBoxEffectType
            // 
            this.groupBoxEffectType.Controls.Add(this.cmbEffectType);
            this.groupBoxEffectType.Controls.Add(this.lblEffectType);
            this.groupBoxEffectType.Location = new System.Drawing.Point(10, 10);
            this.groupBoxEffectType.Name = "groupBoxEffectType";
            this.groupBoxEffectType.Size = new System.Drawing.Size(550, 65);
            this.groupBoxEffectType.TabIndex = 0;
            this.groupBoxEffectType.TabStop = false;
            this.groupBoxEffectType.Text = "이펙트 종류";
            // 
            // lblEffectType
            // 
            this.lblEffectType.AutoSize = true;
            this.lblEffectType.Location = new System.Drawing.Point(15, 29);
            this.lblEffectType.Name = "lblEffectType";
            this.lblEffectType.Size = new System.Drawing.Size(29, 12);
            this.lblEffectType.TabIndex = 0;
            this.lblEffectType.Text = "종류";
            // 
            // cmbEffectType
            // 
            this.cmbEffectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEffectType.FormattingEnabled = true;
            this.cmbEffectType.Items.AddRange(new object[] {
            "치수선",
            "가스 확산 구름",
            "지면 투영 링",
            "선 무리",
            "마커",
            "파티클 이미터",
            "흐르는 경로선",
            "점 무리",
            "펄스 외곽선",
            "확산 구",
            "회전 스피너",
            "텍스트 라벨",
            "유증기",
            "용접 불꽃 효과"});
            this.cmbEffectType.Location = new System.Drawing.Point(95, 25);
            this.cmbEffectType.Name = "cmbEffectType";
            this.cmbEffectType.Size = new System.Drawing.Size(435, 20);
            this.cmbEffectType.TabIndex = 1;
            this.cmbEffectType.SelectedIndexChanged += new System.EventHandler(this.cmbEffectType_SelectedIndexChanged);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.lblNoOptions);
            this.groupBoxOptions.Controls.Add(this.txtOptionText);
            this.groupBoxOptions.Controls.Add(this.lblOptionText);
            this.groupBoxOptions.Controls.Add(this.cmbSpecial);
            this.groupBoxOptions.Controls.Add(this.lblSpecial);
            this.groupBoxOptions.Controls.Add(this.chkOption2);
            this.groupBoxOptions.Controls.Add(this.chkOption1);
            this.groupBoxOptions.Controls.Add(this.numOption3);
            this.groupBoxOptions.Controls.Add(this.lblOption3);
            this.groupBoxOptions.Controls.Add(this.numOption2);
            this.groupBoxOptions.Controls.Add(this.lblOption2);
            this.groupBoxOptions.Controls.Add(this.numOption1);
            this.groupBoxOptions.Controls.Add(this.lblOption1);
            this.groupBoxOptions.Controls.Add(this.btnEffectColor);
            this.groupBoxOptions.Controls.Add(this.lblColor);
            this.groupBoxOptions.Location = new System.Drawing.Point(10, 83);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(550, 260);
            this.groupBoxOptions.TabIndex = 1;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "이펙트 특성";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(15, 31);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(29, 12);
            this.lblColor.TabIndex = 0;
            this.lblColor.Text = "색상";
            // 
            // btnEffectColor
            // 
            this.btnEffectColor.Location = new System.Drawing.Point(155, 23);
            this.btnEffectColor.Name = "btnEffectColor";
            this.btnEffectColor.Size = new System.Drawing.Size(375, 28);
            this.btnEffectColor.TabIndex = 1;
            this.btnEffectColor.Text = "색상 선택";
            this.btnEffectColor.UseVisualStyleBackColor = false;
            this.btnEffectColor.Click += new System.EventHandler(this.btnEffectColor_Click);
            // 
            // lblOption1
            // 
            this.lblOption1.AutoSize = true;
            this.lblOption1.Location = new System.Drawing.Point(15, 69);
            this.lblOption1.Name = "lblOption1";
            this.lblOption1.Size = new System.Drawing.Size(41, 12);
            this.lblOption1.TabIndex = 2;
            this.lblOption1.Text = "옵션 1";
            // 
            // numOption1
            // 
            this.numOption1.Location = new System.Drawing.Point(155, 65);
            this.numOption1.Name = "numOption1";
            this.numOption1.Size = new System.Drawing.Size(150, 21);
            this.numOption1.TabIndex = 3;
            // 
            // lblOption2
            // 
            this.lblOption2.AutoSize = true;
            this.lblOption2.Location = new System.Drawing.Point(15, 103);
            this.lblOption2.Name = "lblOption2";
            this.lblOption2.Size = new System.Drawing.Size(41, 12);
            this.lblOption2.TabIndex = 4;
            this.lblOption2.Text = "옵션 2";
            // 
            // numOption2
            // 
            this.numOption2.Location = new System.Drawing.Point(155, 99);
            this.numOption2.Name = "numOption2";
            this.numOption2.Size = new System.Drawing.Size(150, 21);
            this.numOption2.TabIndex = 5;
            // 
            // lblOption3
            // 
            this.lblOption3.AutoSize = true;
            this.lblOption3.Location = new System.Drawing.Point(15, 137);
            this.lblOption3.Name = "lblOption3";
            this.lblOption3.Size = new System.Drawing.Size(41, 12);
            this.lblOption3.TabIndex = 6;
            this.lblOption3.Text = "옵션 3";
            // 
            // numOption3
            // 
            this.numOption3.Location = new System.Drawing.Point(155, 133);
            this.numOption3.Name = "numOption3";
            this.numOption3.Size = new System.Drawing.Size(150, 21);
            this.numOption3.TabIndex = 7;
            // 
            // chkOption1
            // 
            this.chkOption1.AutoSize = true;
            this.chkOption1.Location = new System.Drawing.Point(330, 68);
            this.chkOption1.Name = "chkOption1";
            this.chkOption1.Size = new System.Drawing.Size(60, 16);
            this.chkOption1.TabIndex = 8;
            this.chkOption1.Text = "옵션 1";
            this.chkOption1.UseVisualStyleBackColor = true;
            // 
            // chkOption2
            // 
            this.chkOption2.AutoSize = true;
            this.chkOption2.Location = new System.Drawing.Point(330, 102);
            this.chkOption2.Name = "chkOption2";
            this.chkOption2.Size = new System.Drawing.Size(60, 16);
            this.chkOption2.TabIndex = 9;
            this.chkOption2.Text = "옵션 2";
            this.chkOption2.UseVisualStyleBackColor = true;
            // 
            // lblSpecial
            // 
            this.lblSpecial.AutoSize = true;
            this.lblSpecial.Location = new System.Drawing.Point(15, 174);
            this.lblSpecial.Name = "lblSpecial";
            this.lblSpecial.Size = new System.Drawing.Size(57, 12);
            this.lblSpecial.TabIndex = 10;
            this.lblSpecial.Text = "추가 설정";
            // 
            // cmbSpecial
            // 
            this.cmbSpecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecial.FormattingEnabled = true;
            this.cmbSpecial.Location = new System.Drawing.Point(155, 170);
            this.cmbSpecial.Name = "cmbSpecial";
            this.cmbSpecial.Size = new System.Drawing.Size(375, 20);
            this.cmbSpecial.TabIndex = 11;
            this.cmbSpecial.SelectedIndexChanged += new System.EventHandler(this.cmbSpecial_SelectedIndexChanged);
            // 
            // lblOptionText
            // 
            this.lblOptionText.AutoSize = true;
            this.lblOptionText.Location = new System.Drawing.Point(15, 211);
            this.lblOptionText.Name = "lblOptionText";
            this.lblOptionText.Size = new System.Drawing.Size(57, 12);
            this.lblOptionText.TabIndex = 12;
            this.lblOptionText.Text = "문자열";
            // 
            // txtOptionText
            // 
            this.txtOptionText.Location = new System.Drawing.Point(155, 207);
            this.txtOptionText.Name = "txtOptionText";
            this.txtOptionText.Size = new System.Drawing.Size(375, 21);
            this.txtOptionText.TabIndex = 13;
            // 
            // lblNoOptions
            // 
            this.lblNoOptions.Location = new System.Drawing.Point(15, 30);
            this.lblNoOptions.Name = "lblNoOptions";
            this.lblNoOptions.Size = new System.Drawing.Size(515, 40);
            this.lblNoOptions.TabIndex = 14;
            this.lblNoOptions.Text = "개별 옵션이 없습니다.";
            // 
            // groupBoxOsnap
            // 
            this.groupBoxOsnap.Controls.Add(this.lvPoints);
            this.groupBoxOsnap.Controls.Add(this.btnClearPoints);
            this.groupBoxOsnap.Controls.Add(this.btnRemovePoint);
            this.groupBoxOsnap.Controls.Add(this.btnPickPoint);
            this.groupBoxOsnap.Controls.Add(this.chkSnapCircle);
            this.groupBoxOsnap.Controls.Add(this.chkSnapLine);
            this.groupBoxOsnap.Controls.Add(this.chkSnapVertex);
            this.groupBoxOsnap.Controls.Add(this.chkSnapSurface);
            this.groupBoxOsnap.Controls.Add(this.lblPointGuide);
            this.groupBoxOsnap.Location = new System.Drawing.Point(10, 351);
            this.groupBoxOsnap.Name = "groupBoxOsnap";
            this.groupBoxOsnap.Size = new System.Drawing.Size(550, 390);
            this.groupBoxOsnap.TabIndex = 2;
            this.groupBoxOsnap.TabStop = false;
            this.groupBoxOsnap.Text = "오스냅 위치";
            // 
            // lblPointGuide
            // 
            this.lblPointGuide.Location = new System.Drawing.Point(12, 22);
            this.lblPointGuide.Name = "lblPointGuide";
            this.lblPointGuide.Size = new System.Drawing.Size(518, 34);
            this.lblPointGuide.TabIndex = 0;
            this.lblPointGuide.Text = "오스냅으로 위치를 선택해주세요.";
            // 
            // chkSnapSurface
            // 
            this.chkSnapSurface.AutoSize = true;
            this.chkSnapSurface.Checked = true;
            this.chkSnapSurface.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSnapSurface.Location = new System.Drawing.Point(15, 62);
            this.chkSnapSurface.Name = "chkSnapSurface";
            this.chkSnapSurface.Size = new System.Drawing.Size(48, 16);
            this.chkSnapSurface.TabIndex = 1;
            this.chkSnapSurface.Text = "면";
            this.chkSnapSurface.UseVisualStyleBackColor = true;
            // 
            // chkSnapVertex
            // 
            this.chkSnapVertex.AutoSize = true;
            this.chkSnapVertex.Checked = true;
            this.chkSnapVertex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSnapVertex.Location = new System.Drawing.Point(90, 62);
            this.chkSnapVertex.Name = "chkSnapVertex";
            this.chkSnapVertex.Size = new System.Drawing.Size(48, 16);
            this.chkSnapVertex.TabIndex = 2;
            this.chkSnapVertex.Text = "정점";
            this.chkSnapVertex.UseVisualStyleBackColor = true;
            // 
            // chkSnapLine
            // 
            this.chkSnapLine.AutoSize = true;
            this.chkSnapLine.Checked = true;
            this.chkSnapLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSnapLine.Location = new System.Drawing.Point(165, 62);
            this.chkSnapLine.Name = "chkSnapLine";
            this.chkSnapLine.Size = new System.Drawing.Size(48, 16);
            this.chkSnapLine.TabIndex = 3;
            this.chkSnapLine.Text = "선";
            this.chkSnapLine.UseVisualStyleBackColor = true;
            // 
            // chkSnapCircle
            // 
            this.chkSnapCircle.AutoSize = true;
            this.chkSnapCircle.Checked = true;
            this.chkSnapCircle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSnapCircle.Location = new System.Drawing.Point(240, 62);
            this.chkSnapCircle.Name = "chkSnapCircle";
            this.chkSnapCircle.Size = new System.Drawing.Size(48, 16);
            this.chkSnapCircle.TabIndex = 4;
            this.chkSnapCircle.Text = "원";
            this.chkSnapCircle.UseVisualStyleBackColor = true;
            // 
            // btnPickPoint
            // 
            this.btnPickPoint.Location = new System.Drawing.Point(12, 92);
            this.btnPickPoint.Name = "btnPickPoint";
            this.btnPickPoint.Size = new System.Drawing.Size(168, 30);
            this.btnPickPoint.TabIndex = 5;
            this.btnPickPoint.Text = "오스냅 점 선택";
            this.btnPickPoint.UseVisualStyleBackColor = true;
            this.btnPickPoint.Click += new System.EventHandler(this.btnPickPoint_Click);
            // 
            // btnRemovePoint
            // 
            this.btnRemovePoint.Location = new System.Drawing.Point(191, 92);
            this.btnRemovePoint.Name = "btnRemovePoint";
            this.btnRemovePoint.Size = new System.Drawing.Size(168, 30);
            this.btnRemovePoint.TabIndex = 6;
            this.btnRemovePoint.Text = "선택 점 제거";
            this.btnRemovePoint.UseVisualStyleBackColor = true;
            this.btnRemovePoint.Click += new System.EventHandler(this.btnRemovePoint_Click);
            // 
            // btnClearPoints
            // 
            this.btnClearPoints.Location = new System.Drawing.Point(370, 92);
            this.btnClearPoints.Name = "btnClearPoints";
            this.btnClearPoints.Size = new System.Drawing.Size(160, 30);
            this.btnClearPoints.TabIndex = 7;
            this.btnClearPoints.Text = "점 전체 제거";
            this.btnClearPoints.UseVisualStyleBackColor = true;
            this.btnClearPoints.Click += new System.EventHandler(this.btnClearPoints_Click);
            // 
            // lvPoints
            // 
            this.lvPoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPointNo,
            this.colPointType,
            this.colPointPosition});
            this.lvPoints.FullRowSelect = true;
            this.lvPoints.GridLines = true;
            this.lvPoints.HideSelection = false;
            this.lvPoints.Location = new System.Drawing.Point(12, 134);
            this.lvPoints.MultiSelect = false;
            this.lvPoints.Name = "lvPoints";
            this.lvPoints.Size = new System.Drawing.Size(518, 240);
            this.lvPoints.TabIndex = 8;
            this.lvPoints.UseCompatibleStateImageBehavior = false;
            this.lvPoints.View = System.Windows.Forms.View.Details;
            // 
            // colPointNo
            // 
            this.colPointNo.Text = "순번";
            this.colPointNo.Width = 50;
            // 
            // colPointType
            // 
            this.colPointType.Text = "형상";
            this.colPointType.Width = 110;
            // 
            // colPointPosition
            // 
            this.colPointPosition.Text = "좌표";
            this.colPointPosition.Width = 335;
            // 
            // lblCreateResult
            // 
            this.lblCreateResult.AutoSize = true;
            this.lblCreateResult.Location = new System.Drawing.Point(12, 754);
            this.lblCreateResult.Name = "lblCreateResult";
            this.lblCreateResult.Size = new System.Drawing.Size(85, 12);
            this.lblCreateResult.TabIndex = 3;
            this.lblCreateResult.Text = "생성 결과 : -";
            // 
            // btnCreateEffect
            // 
            this.btnCreateEffect.Location = new System.Drawing.Point(10, 780);
            this.btnCreateEffect.Name = "btnCreateEffect";
            this.btnCreateEffect.Size = new System.Drawing.Size(550, 42);
            this.btnCreateEffect.TabIndex = 4;
            this.btnCreateEffect.Text = "이펙트 생성";
            this.btnCreateEffect.UseVisualStyleBackColor = true;
            this.btnCreateEffect.Click += new System.EventHandler(this.btnCreateEffect_Click);
            // 
            // tabPageManage
            // 
            this.tabPageManage.AutoScroll = true;
            this.tabPageManage.Controls.Add(this.groupBoxWelding);
            this.tabPageManage.Controls.Add(this.groupBoxSpinner);
            this.tabPageManage.Controls.Add(this.groupBoxVisible);
            this.tabPageManage.Controls.Add(this.groupBoxRemove);
            this.tabPageManage.Controls.Add(this.lvEffects);
            this.tabPageManage.Controls.Add(this.lblEffectListCount);
            this.tabPageManage.Controls.Add(this.groupBoxQuery);
            this.tabPageManage.Location = new System.Drawing.Point(4, 22);
            this.tabPageManage.Name = "tabPageManage";
            this.tabPageManage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageManage.Size = new System.Drawing.Size(578, 874);
            this.tabPageManage.TabIndex = 1;
            this.tabPageManage.Text = "조회 / 관리";
            this.tabPageManage.UseVisualStyleBackColor = true;
            // 
            // groupBoxQuery
            // 
            this.groupBoxQuery.Controls.Add(this.btnRefreshEffects);
            this.groupBoxQuery.Controls.Add(this.cmbQueryType);
            this.groupBoxQuery.Controls.Add(this.lblQueryType);
            this.groupBoxQuery.Controls.Add(this.cmbQueryMode);
            this.groupBoxQuery.Controls.Add(this.lblQueryMode);
            this.groupBoxQuery.Location = new System.Drawing.Point(10, 10);
            this.groupBoxQuery.Name = "groupBoxQuery";
            this.groupBoxQuery.Size = new System.Drawing.Size(550, 70);
            this.groupBoxQuery.TabIndex = 0;
            this.groupBoxQuery.TabStop = false;
            this.groupBoxQuery.Text = "이펙트 조회";
            // 
            // lblQueryMode
            // 
            this.lblQueryMode.AutoSize = true;
            this.lblQueryMode.Location = new System.Drawing.Point(12, 30);
            this.lblQueryMode.Name = "lblQueryMode";
            this.lblQueryMode.Size = new System.Drawing.Size(57, 12);
            this.lblQueryMode.TabIndex = 0;
            this.lblQueryMode.Text = "조회 방식";
            // 
            // cmbQueryMode
            // 
            this.cmbQueryMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQueryMode.FormattingEnabled = true;
            this.cmbQueryMode.Items.AddRange(new object[] {
            "전체",
            "종류"});
            this.cmbQueryMode.Location = new System.Drawing.Point(85, 26);
            this.cmbQueryMode.Name = "cmbQueryMode";
            this.cmbQueryMode.Size = new System.Drawing.Size(100, 20);
            this.cmbQueryMode.TabIndex = 1;
            this.cmbQueryMode.SelectedIndexChanged += new System.EventHandler(this.cmbQueryMode_SelectedIndexChanged);
            // 
            // lblQueryType
            // 
            this.lblQueryType.AutoSize = true;
            this.lblQueryType.Location = new System.Drawing.Point(200, 30);
            this.lblQueryType.Name = "lblQueryType";
            this.lblQueryType.Size = new System.Drawing.Size(29, 12);
            this.lblQueryType.TabIndex = 2;
            this.lblQueryType.Text = "종류";
            // 
            // cmbQueryType
            // 
            this.cmbQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQueryType.FormattingEnabled = true;
            this.cmbQueryType.Items.AddRange(new object[] {
            "마커",
            "텍스트 라벨",
            "용접 불꽃 효과",
            "가스 확산 구름",
            "유증기",
            "확산 구",
            "펄스 외곽선",
            "치수선",
            "흐르는 경로선",
            "파티클 이미터",
            "회전 스피너",
            "지면 투영 링",
            "좌표·색 데이터"});
            this.cmbQueryType.Location = new System.Drawing.Point(240, 26);
            this.cmbQueryType.Name = "cmbQueryType";
            this.cmbQueryType.Size = new System.Drawing.Size(195, 20);
            this.cmbQueryType.TabIndex = 3;
            // 
            // btnRefreshEffects
            // 
            this.btnRefreshEffects.Location = new System.Drawing.Point(445, 24);
            this.btnRefreshEffects.Name = "btnRefreshEffects";
            this.btnRefreshEffects.Size = new System.Drawing.Size(90, 25);
            this.btnRefreshEffects.TabIndex = 4;
            this.btnRefreshEffects.Text = "조회";
            this.btnRefreshEffects.UseVisualStyleBackColor = true;
            this.btnRefreshEffects.Click += new System.EventHandler(this.btnRefreshEffects_Click);
            // 
            // lblEffectListCount
            // 
            this.lblEffectListCount.AutoSize = true;
            this.lblEffectListCount.Location = new System.Drawing.Point(12, 90);
            this.lblEffectListCount.Name = "lblEffectListCount";
            this.lblEffectListCount.Size = new System.Drawing.Size(97, 12);
            this.lblEffectListCount.TabIndex = 1;
            this.lblEffectListCount.Text = "조회 결과 : 0개";
            // 
            // lvEffects
            // 
            this.lvEffects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEffectId,
            this.colEffectType,
            this.colEffectPosition,
            this.colEffectSummary});
            this.lvEffects.FullRowSelect = true;
            this.lvEffects.GridLines = true;
            this.lvEffects.HideSelection = false;
            this.lvEffects.Location = new System.Drawing.Point(10, 112);
            this.lvEffects.MultiSelect = false;
            this.lvEffects.Name = "lvEffects";
            this.lvEffects.Size = new System.Drawing.Size(550, 250);
            this.lvEffects.TabIndex = 2;
            this.lvEffects.UseCompatibleStateImageBehavior = false;
            this.lvEffects.View = System.Windows.Forms.View.Details;
            // 
            // colEffectId
            // 
            this.colEffectId.Text = "식별자";
            this.colEffectId.Width = 150;
            // 
            // colEffectType
            // 
            this.colEffectType.Text = "종류";
            this.colEffectType.Width = 120;
            // 
            // colEffectPosition
            // 
            this.colEffectPosition.Text = "위치";
            this.colEffectPosition.Width = 180;
            // 
            // colEffectSummary
            // 
            this.colEffectSummary.Text = "설명";
            this.colEffectSummary.Width = 90;
            // 
            // groupBoxRemove
            // 
            this.groupBoxRemove.Controls.Add(this.btnClearType);
            this.groupBoxRemove.Controls.Add(this.cmbClearType);
            this.groupBoxRemove.Controls.Add(this.lblClearType);
            this.groupBoxRemove.Controls.Add(this.btnClearAll);
            this.groupBoxRemove.Controls.Add(this.btnRemoveSelected);
            this.groupBoxRemove.Location = new System.Drawing.Point(10, 378);
            this.groupBoxRemove.Name = "groupBoxRemove";
            this.groupBoxRemove.Size = new System.Drawing.Size(550, 115);
            this.groupBoxRemove.TabIndex = 3;
            this.groupBoxRemove.TabStop = false;
            this.groupBoxRemove.Text = "이펙트 제거";
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Location = new System.Drawing.Point(12, 25);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(258, 30);
            this.btnRemoveSelected.TabIndex = 0;
            this.btnRemoveSelected.Text = "선택 이펙트 제거";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(280, 25);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(258, 30);
            this.btnClearAll.TabIndex = 1;
            this.btnClearAll.Text = "전체 이펙트 제거";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // lblClearType
            // 
            this.lblClearType.AutoSize = true;
            this.lblClearType.Location = new System.Drawing.Point(12, 78);
            this.lblClearType.Name = "lblClearType";
            this.lblClearType.Size = new System.Drawing.Size(29, 12);
            this.lblClearType.TabIndex = 2;
            this.lblClearType.Text = "종류";
            // 
            // cmbClearType
            // 
            this.cmbClearType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClearType.FormattingEnabled = true;
            this.cmbClearType.Items.AddRange(new object[] {
            "마커",
            "텍스트 라벨",
            "용접 불꽃 효과",
            "가스 확산 구름",
            "유증기",
            "확산 구",
            "펄스 외곽선",
            "치수선",
            "흐르는 경로선",
            "파티클 이미터",
            "회전 스피너",
            "지면 투영 링",
            "좌표·색 데이터"});
            this.cmbClearType.Location = new System.Drawing.Point(60, 74);
            this.cmbClearType.Name = "cmbClearType";
            this.cmbClearType.Size = new System.Drawing.Size(315, 20);
            this.cmbClearType.TabIndex = 3;
            // 
            // btnClearType
            // 
            this.btnClearType.Location = new System.Drawing.Point(385, 72);
            this.btnClearType.Name = "btnClearType";
            this.btnClearType.Size = new System.Drawing.Size(153, 25);
            this.btnClearType.TabIndex = 4;
            this.btnClearType.Text = "선택 종류 전체 제거";
            this.btnClearType.UseVisualStyleBackColor = true;
            this.btnClearType.Click += new System.EventHandler(this.btnClearType_Click);
            // 
            // groupBoxVisible
            // 
            this.groupBoxVisible.Controls.Add(this.chkTextLabelVisible);
            this.groupBoxVisible.Controls.Add(this.chkMarkerVisible);
            this.groupBoxVisible.Location = new System.Drawing.Point(10, 503);
            this.groupBoxVisible.Name = "groupBoxVisible";
            this.groupBoxVisible.Size = new System.Drawing.Size(550, 70);
            this.groupBoxVisible.TabIndex = 4;
            this.groupBoxVisible.TabStop = false;
            this.groupBoxVisible.Text = "표시 여부";
            // 
            // chkMarkerVisible
            // 
            this.chkMarkerVisible.AutoSize = true;
            this.chkMarkerVisible.Checked = true;
            this.chkMarkerVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMarkerVisible.Location = new System.Drawing.Point(20, 32);
            this.chkMarkerVisible.Name = "chkMarkerVisible";
            this.chkMarkerVisible.Size = new System.Drawing.Size(104, 16);
            this.chkMarkerVisible.TabIndex = 0;
            this.chkMarkerVisible.Text = "마커 전체 표시";
            this.chkMarkerVisible.UseVisualStyleBackColor = true;
            this.chkMarkerVisible.CheckedChanged += new System.EventHandler(this.chkMarkerVisible_CheckedChanged);
            // 
            // chkTextLabelVisible
            // 
            this.chkTextLabelVisible.AutoSize = true;
            this.chkTextLabelVisible.Checked = true;
            this.chkTextLabelVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTextLabelVisible.Location = new System.Drawing.Point(190, 32);
            this.chkTextLabelVisible.Name = "chkTextLabelVisible";
            this.chkTextLabelVisible.Size = new System.Drawing.Size(132, 16);
            this.chkTextLabelVisible.TabIndex = 1;
            this.chkTextLabelVisible.Text = "텍스트 라벨 전체 표시";
            this.chkTextLabelVisible.UseVisualStyleBackColor = true;
            this.chkTextLabelVisible.CheckedChanged += new System.EventHandler(this.chkTextLabelVisible_CheckedChanged);
            // 
            // groupBoxSpinner
            // 
            this.groupBoxSpinner.Controls.Add(this.btnSetSpinnerProgress);
            this.groupBoxSpinner.Controls.Add(this.chkSpinnerContinuous);
            this.groupBoxSpinner.Controls.Add(this.numSpinnerProgress);
            this.groupBoxSpinner.Controls.Add(this.lblSpinnerProgress);
            this.groupBoxSpinner.Location = new System.Drawing.Point(10, 583);
            this.groupBoxSpinner.Name = "groupBoxSpinner";
            this.groupBoxSpinner.Size = new System.Drawing.Size(550, 85);
            this.groupBoxSpinner.TabIndex = 5;
            this.groupBoxSpinner.TabStop = false;
            this.groupBoxSpinner.Text = "회전 스피너";
            // 
            // lblSpinnerProgress
            // 
            this.lblSpinnerProgress.AutoSize = true;
            this.lblSpinnerProgress.Location = new System.Drawing.Point(15, 36);
            this.lblSpinnerProgress.Name = "lblSpinnerProgress";
            this.lblSpinnerProgress.Size = new System.Drawing.Size(41, 12);
            this.lblSpinnerProgress.TabIndex = 0;
            this.lblSpinnerProgress.Text = "진행률";
            // 
            // numSpinnerProgress
            // 
            this.numSpinnerProgress.Location = new System.Drawing.Point(75, 32);
            this.numSpinnerProgress.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numSpinnerProgress.Name = "numSpinnerProgress";
            this.numSpinnerProgress.Size = new System.Drawing.Size(75, 21);
            this.numSpinnerProgress.TabIndex = 1;
            this.numSpinnerProgress.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // chkSpinnerContinuous
            // 
            this.chkSpinnerContinuous.AutoSize = true;
            this.chkSpinnerContinuous.Location = new System.Drawing.Point(175, 35);
            this.chkSpinnerContinuous.Name = "chkSpinnerContinuous";
            this.chkSpinnerContinuous.Size = new System.Drawing.Size(76, 16);
            this.chkSpinnerContinuous.TabIndex = 2;
            this.chkSpinnerContinuous.Text = "계속 회전";
            this.chkSpinnerContinuous.UseVisualStyleBackColor = true;
            // 
            // btnSetSpinnerProgress
            // 
            this.btnSetSpinnerProgress.Location = new System.Drawing.Point(390, 28);
            this.btnSetSpinnerProgress.Name = "btnSetSpinnerProgress";
            this.btnSetSpinnerProgress.Size = new System.Drawing.Size(145, 30);
            this.btnSetSpinnerProgress.TabIndex = 3;
            this.btnSetSpinnerProgress.Text = "진행률 변경";
            this.btnSetSpinnerProgress.UseVisualStyleBackColor = true;
            this.btnSetSpinnerProgress.Click += new System.EventHandler(this.btnSetSpinnerProgress_Click);
            // 
            // groupBoxWelding
            // 
            this.groupBoxWelding.Controls.Add(this.btnApplyWeldingSettings);
            this.groupBoxWelding.Controls.Add(this.numWeldingSparkCapacity);
            this.groupBoxWelding.Controls.Add(this.lblWeldingSparkCapacity);
            this.groupBoxWelding.Controls.Add(this.chkWeldingSparkBounce);
            this.groupBoxWelding.Location = new System.Drawing.Point(10, 678);
            this.groupBoxWelding.Name = "groupBoxWelding";
            this.groupBoxWelding.Size = new System.Drawing.Size(550, 125);
            this.groupBoxWelding.TabIndex = 6;
            this.groupBoxWelding.TabStop = false;
            this.groupBoxWelding.Text = "용접 불꽃 효과 설정";
            // 
            // chkWeldingSparkBounce
            // 
            this.chkWeldingSparkBounce.AutoSize = true;
            this.chkWeldingSparkBounce.Location = new System.Drawing.Point(15, 30);
            this.chkWeldingSparkBounce.Name = "chkWeldingSparkBounce";
            this.chkWeldingSparkBounce.Size = new System.Drawing.Size(206, 16);
            this.chkWeldingSparkBounce.TabIndex = 0;
            this.chkWeldingSparkBounce.Text = "바닥에 부딪히면 튕기도록 설정";
            this.chkWeldingSparkBounce.UseVisualStyleBackColor = true;
            // 
            // lblWeldingSparkCapacity
            // 
            this.lblWeldingSparkCapacity.AutoSize = true;
            this.lblWeldingSparkCapacity.Location = new System.Drawing.Point(15, 76);
            this.lblWeldingSparkCapacity.Name = "lblWeldingSparkCapacity";
            this.lblWeldingSparkCapacity.Size = new System.Drawing.Size(173, 12);
            this.lblWeldingSparkCapacity.TabIndex = 1;
            this.lblWeldingSparkCapacity.Text = "등록 가능한 지점 최대 개수";
            // 
            // numWeldingSparkCapacity
            // 
            this.numWeldingSparkCapacity.Location = new System.Drawing.Point(205, 72);
            this.numWeldingSparkCapacity.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numWeldingSparkCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeldingSparkCapacity.Name = "numWeldingSparkCapacity";
            this.numWeldingSparkCapacity.Size = new System.Drawing.Size(80, 21);
            this.numWeldingSparkCapacity.TabIndex = 2;
            this.numWeldingSparkCapacity.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // btnApplyWeldingSettings
            // 
            this.btnApplyWeldingSettings.Location = new System.Drawing.Point(390, 60);
            this.btnApplyWeldingSettings.Name = "btnApplyWeldingSettings";
            this.btnApplyWeldingSettings.Size = new System.Drawing.Size(145, 32);
            this.btnApplyWeldingSettings.TabIndex = 3;
            this.btnApplyWeldingSettings.Text = "설정 적용";
            this.btnApplyWeldingSettings.UseVisualStyleBackColor = true;
            this.btnApplyWeldingSettings.Click += new System.EventHandler(this.btnApplyWeldingSettings_Click);
            // 
            // tabPageStatus
            // 
            this.tabPageStatus.Controls.Add(this.splitContainerStatus1);
            this.tabPageStatus.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatus.Name = "tabPageStatus";
            this.tabPageStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatus.Size = new System.Drawing.Size(578, 874);
            this.tabPageStatus.TabIndex = 2;
            this.tabPageStatus.Text = "상태";
            this.tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // splitContainerStatus1
            // 
            this.splitContainerStatus1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerStatus1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerStatus1.Location = new System.Drawing.Point(3, 3);
            this.splitContainerStatus1.Name = "splitContainerStatus1";
            this.splitContainerStatus1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerStatus1.Panel1
            // 
            this.splitContainerStatus1.Panel1.Controls.Add(this.groupBoxCount);
            // 
            // splitContainerStatus1.Panel2
            // 
            this.splitContainerStatus1.Panel2.Controls.Add(this.splitContainerStatus2);
            this.splitContainerStatus1.Size = new System.Drawing.Size(572, 868);
            this.splitContainerStatus1.SplitterDistance = 265;
            this.splitContainerStatus1.TabIndex = 0;
            // 
            // groupBoxCount
            // 
            this.groupBoxCount.Controls.Add(this.txtEffectCount);
            this.groupBoxCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCount.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCount.Name = "groupBoxCount";
            this.groupBoxCount.Size = new System.Drawing.Size(572, 265);
            this.groupBoxCount.TabIndex = 0;
            this.groupBoxCount.TabStop = false;
            this.groupBoxCount.Text = "현재 이펙트 상태";
            // 
            // txtEffectCount
            // 
            this.txtEffectCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEffectCount.Location = new System.Drawing.Point(3, 17);
            this.txtEffectCount.Multiline = true;
            this.txtEffectCount.Name = "txtEffectCount";
            this.txtEffectCount.ReadOnly = true;
            this.txtEffectCount.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEffectCount.Size = new System.Drawing.Size(566, 245);
            this.txtEffectCount.TabIndex = 0;
            // 
            // splitContainerStatus2
            // 
            this.splitContainerStatus2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerStatus2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerStatus2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerStatus2.Name = "splitContainerStatus2";
            this.splitContainerStatus2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerStatus2.Panel1
            // 
            this.splitContainerStatus2.Panel1.Controls.Add(this.groupBoxCapacity);
            // 
            // splitContainerStatus2.Panel2
            // 
            this.splitContainerStatus2.Panel2.Controls.Add(this.groupBoxEvent);
            this.splitContainerStatus2.Size = new System.Drawing.Size(572, 599);
            this.splitContainerStatus2.SplitterDistance = 270;
            this.splitContainerStatus2.TabIndex = 0;
            // 
            // groupBoxCapacity
            // 
            this.groupBoxCapacity.Controls.Add(this.txtEffectCapacity);
            this.groupBoxCapacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCapacity.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCapacity.Name = "groupBoxCapacity";
            this.groupBoxCapacity.Size = new System.Drawing.Size(572, 270);
            this.groupBoxCapacity.TabIndex = 0;
            this.groupBoxCapacity.TabStop = false;
            this.groupBoxCapacity.Text = "이펙트별 최대 등록 개수";
            // 
            // txtEffectCapacity
            // 
            this.txtEffectCapacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEffectCapacity.Location = new System.Drawing.Point(3, 17);
            this.txtEffectCapacity.Multiline = true;
            this.txtEffectCapacity.Name = "txtEffectCapacity";
            this.txtEffectCapacity.ReadOnly = true;
            this.txtEffectCapacity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEffectCapacity.Size = new System.Drawing.Size(566, 250);
            this.txtEffectCapacity.TabIndex = 0;
            // 
            // groupBoxEvent
            // 
            this.groupBoxEvent.Controls.Add(this.listBoxEvent);
            this.groupBoxEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEvent.Location = new System.Drawing.Point(0, 0);
            this.groupBoxEvent.Name = "groupBoxEvent";
            this.groupBoxEvent.Size = new System.Drawing.Size(572, 325);
            this.groupBoxEvent.TabIndex = 0;
            this.groupBoxEvent.TabStop = false;
            this.groupBoxEvent.Text = "이펙트 추가 / 제거 이벤트";
            // 
            // listBoxEvent
            // 
            this.listBoxEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEvent.FormattingEnabled = true;
            this.listBoxEvent.HorizontalScrollbar = true;
            this.listBoxEvent.IntegralHeight = false;
            this.listBoxEvent.ItemHeight = 12;
            this.listBoxEvent.Location = new System.Drawing.Point(3, 17);
            this.listBoxEvent.Name = "listBoxEvent";
            this.listBoxEvent.ScrollAlwaysVisible = true;
            this.listBoxEvent.Size = new System.Drawing.Size(566, 305);
            this.listBoxEvent.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 900);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1200, 760);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.Effect";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlEffect.ResumeLayout(false);
            this.tabPageCreate.ResumeLayout(false);
            this.tabPageCreate.PerformLayout();
            this.groupBoxOsnap.ResumeLayout(false);
            this.groupBoxOsnap.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOption3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOption2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOption1)).EndInit();
            this.groupBoxEffectType.ResumeLayout(false);
            this.groupBoxEffectType.PerformLayout();
            this.tabPageManage.ResumeLayout(false);
            this.tabPageManage.PerformLayout();
            this.groupBoxWelding.ResumeLayout(false);
            this.groupBoxWelding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldingSparkCapacity)).EndInit();
            this.groupBoxSpinner.ResumeLayout(false);
            this.groupBoxSpinner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpinnerProgress)).EndInit();
            this.groupBoxVisible.ResumeLayout(false);
            this.groupBoxVisible.PerformLayout();
            this.groupBoxRemove.ResumeLayout(false);
            this.groupBoxRemove.PerformLayout();
            this.groupBoxQuery.ResumeLayout(false);
            this.groupBoxQuery.PerformLayout();
            this.tabPageStatus.ResumeLayout(false);
            this.splitContainerStatus1.Panel1.ResumeLayout(false);
            this.splitContainerStatus1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatus1)).EndInit();
            this.splitContainerStatus1.ResumeLayout(false);
            this.groupBoxCount.ResumeLayout(false);
            this.groupBoxCount.PerformLayout();
            this.splitContainerStatus2.Panel1.ResumeLayout(false);
            this.splitContainerStatus2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatus2)).EndInit();
            this.splitContainerStatus2.ResumeLayout(false);
            this.groupBoxCapacity.ResumeLayout(false);
            this.groupBoxCapacity.PerformLayout();
            this.groupBoxEvent.ResumeLayout(false);

            this.cmbEffectType.SelectedIndex = 0;
            this.cmbQueryMode.SelectedIndex = 0;
            this.cmbQueryType.SelectedIndex = 0;
            this.cmbClearType.SelectedIndex = 0;

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlEffect;
        private System.Windows.Forms.TabPage tabPageCreate;
        private System.Windows.Forms.GroupBox groupBoxEffectType;
        private System.Windows.Forms.Label lblEffectType;
        private System.Windows.Forms.ComboBox cmbEffectType;
        private System.Windows.Forms.GroupBox groupBoxOptions;
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
        private System.Windows.Forms.Label lblOptionText;
        private System.Windows.Forms.TextBox txtOptionText;
        private System.Windows.Forms.Label lblNoOptions;
        private System.Windows.Forms.GroupBox groupBoxOsnap;
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
        private System.Windows.Forms.ColumnHeader colPointType;
        private System.Windows.Forms.ColumnHeader colPointPosition;
        private System.Windows.Forms.Label lblCreateResult;
        private System.Windows.Forms.Button btnCreateEffect;

        private System.Windows.Forms.TabPage tabPageManage;
        private System.Windows.Forms.GroupBox groupBoxQuery;
        private System.Windows.Forms.Label lblQueryMode;
        private System.Windows.Forms.ComboBox cmbQueryMode;
        private System.Windows.Forms.Label lblQueryType;
        private System.Windows.Forms.ComboBox cmbQueryType;
        private System.Windows.Forms.Button btnRefreshEffects;
        private System.Windows.Forms.Label lblEffectListCount;
        private System.Windows.Forms.ListView lvEffects;
        private System.Windows.Forms.ColumnHeader colEffectId;
        private System.Windows.Forms.ColumnHeader colEffectType;
        private System.Windows.Forms.ColumnHeader colEffectPosition;
        private System.Windows.Forms.ColumnHeader colEffectSummary;
        private System.Windows.Forms.GroupBox groupBoxRemove;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label lblClearType;
        private System.Windows.Forms.ComboBox cmbClearType;
        private System.Windows.Forms.Button btnClearType;
        private System.Windows.Forms.GroupBox groupBoxVisible;
        private System.Windows.Forms.CheckBox chkMarkerVisible;
        private System.Windows.Forms.CheckBox chkTextLabelVisible;
        private System.Windows.Forms.GroupBox groupBoxSpinner;
        private System.Windows.Forms.Label lblSpinnerProgress;
        private System.Windows.Forms.NumericUpDown numSpinnerProgress;
        private System.Windows.Forms.CheckBox chkSpinnerContinuous;
        private System.Windows.Forms.Button btnSetSpinnerProgress;
        private System.Windows.Forms.GroupBox groupBoxWelding;
        private System.Windows.Forms.CheckBox chkWeldingSparkBounce;
        private System.Windows.Forms.Label lblWeldingSparkCapacity;
        private System.Windows.Forms.NumericUpDown numWeldingSparkCapacity;
        private System.Windows.Forms.Button btnApplyWeldingSettings;

        private System.Windows.Forms.TabPage tabPageStatus;
        private System.Windows.Forms.SplitContainer splitContainerStatus1;
        private System.Windows.Forms.GroupBox groupBoxCount;
        private System.Windows.Forms.TextBox txtEffectCount;
        private System.Windows.Forms.SplitContainer splitContainerStatus2;
        private System.Windows.Forms.GroupBox groupBoxCapacity;
        private System.Windows.Forms.TextBox txtEffectCapacity;
        private System.Windows.Forms.GroupBox groupBoxEvent;
        private System.Windows.Forms.ListBox listBoxEvent;
    }
}