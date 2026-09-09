namespace VIZCore3DX.NET.GroupExplode
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
            this.grpExplode = new System.Windows.Forms.GroupBox();
            this.lblExplodeStatus = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnFocusExplode = new System.Windows.Forms.Button();
            this.btnSequentialAnimation = new System.Windows.Forms.Button();
            this.btnDirectionalAnimation = new System.Windows.Forms.Button();
            this.btnRadialAnimation = new System.Windows.Forms.Button();
            this.chkAutoRestore = new System.Windows.Forms.CheckBox();
            this.numHoldSeconds = new System.Windows.Forms.NumericUpDown();
            this.lblHoldSeconds = new System.Windows.Forms.Label();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.lblDuration = new System.Windows.Forms.Label();
            this.numDirectionZ = new System.Windows.Forms.NumericUpDown();
            this.numDirectionY = new System.Windows.Forms.NumericUpDown();
            this.numDirectionX = new System.Windows.Forms.NumericUpDown();
            this.lblDirectionZ = new System.Windows.Forms.Label();
            this.lblDirectionY = new System.Windows.Forms.Label();
            this.lblDirectionX = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.numLevelDecay = new System.Windows.Forms.NumericUpDown();
            this.lblLevelDecay = new System.Windows.Forms.Label();
            this.numDistanceRatio = new System.Windows.Forms.NumericUpDown();
            this.lblDistanceRatio = new System.Windows.Forms.Label();
            this.rdoDirectional = new System.Windows.Forms.RadioButton();
            this.rdoRadial = new System.Windows.Forms.RadioButton();
            this.lblExplodeMode = new System.Windows.Forms.Label();
            this.grpGroup = new System.Windows.Forms.GroupBox();
            this.btnClearGroups = new System.Windows.Forms.Button();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.lblGroupCount = new System.Windows.Forms.Label();
            this.tvGroups = new System.Windows.Forms.TreeView();
            this.lblSelectedGroup = new System.Windows.Forms.Label();
            this.lblGroupList = new System.Windows.Forms.Label();
            this.chkGroupSelection = new System.Windows.Forms.CheckBox();
            this.numMaxDepth = new System.Windows.Forms.NumericUpDown();
            this.lblMaxDepth = new System.Windows.Forms.Label();
            this.btnCreateHierarchicalGroups = new System.Windows.Forms.Button();
            this.btnCreateFlatGroups = new System.Windows.Forms.Button();
            this.btnMoveSelectedNodes = new System.Windows.Forms.Button();
            this.btnRemoveSelectedNodes = new System.Windows.Forms.Button();
            this.btnAddSelectedNodes = new System.Windows.Forms.Button();
            this.btnAddChildGroup = new System.Windows.Forms.Button();
            this.btnAddRootGroup = new System.Windows.Forms.Button();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpExplode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHoldSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDirectionZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDirectionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDirectionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLevelDecay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistanceRatio)).BeginInit();
            this.grpGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDepth)).BeginInit();
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
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.grpExplode);
            this.splitContainer1.Panel1.Controls.Add(this.grpGroup);
            this.splitContainer1.Panel1.Controls.Add(this.btnOpenModel);
            this.splitContainer1.Panel1MinSize = 360;
            this.splitContainer1.Size = new System.Drawing.Size(1200, 700);
            this.splitContainer1.SplitterDistance = 390;
            this.splitContainer1.TabIndex = 0;
            // 
            // grpExplode
            // 
            this.grpExplode.Controls.Add(this.lblExplodeStatus);
            this.grpExplode.Controls.Add(this.btnRestore);
            this.grpExplode.Controls.Add(this.btnFocusExplode);
            this.grpExplode.Controls.Add(this.btnSequentialAnimation);
            this.grpExplode.Controls.Add(this.btnDirectionalAnimation);
            this.grpExplode.Controls.Add(this.btnRadialAnimation);
            this.grpExplode.Controls.Add(this.chkAutoRestore);
            this.grpExplode.Controls.Add(this.numHoldSeconds);
            this.grpExplode.Controls.Add(this.lblHoldSeconds);
            this.grpExplode.Controls.Add(this.numDuration);
            this.grpExplode.Controls.Add(this.lblDuration);
            this.grpExplode.Controls.Add(this.numDirectionZ);
            this.grpExplode.Controls.Add(this.numDirectionY);
            this.grpExplode.Controls.Add(this.numDirectionX);
            this.grpExplode.Controls.Add(this.lblDirectionZ);
            this.grpExplode.Controls.Add(this.lblDirectionY);
            this.grpExplode.Controls.Add(this.lblDirectionX);
            this.grpExplode.Controls.Add(this.lblDirection);
            this.grpExplode.Controls.Add(this.numLevelDecay);
            this.grpExplode.Controls.Add(this.lblLevelDecay);
            this.grpExplode.Controls.Add(this.numDistanceRatio);
            this.grpExplode.Controls.Add(this.lblDistanceRatio);
            this.grpExplode.Controls.Add(this.rdoDirectional);
            this.grpExplode.Controls.Add(this.rdoRadial);
            this.grpExplode.Controls.Add(this.lblExplodeMode);
            this.grpExplode.Location = new System.Drawing.Point(12, 530);
            this.grpExplode.Name = "grpExplode";
            this.grpExplode.Size = new System.Drawing.Size(348, 295);
            this.grpExplode.TabIndex = 2;
            this.grpExplode.TabStop = false;
            this.grpExplode.Text = "분해";
            // 
            // lblExplodeStatus
            // 
            this.lblExplodeStatus.AutoSize = true;
            this.lblExplodeStatus.Location = new System.Drawing.Point(180, 278);
            this.lblExplodeStatus.Name = "lblExplodeStatus";
            this.lblExplodeStatus.Size = new System.Drawing.Size(89, 12);
            this.lblExplodeStatus.TabIndex = 24;
            this.lblExplodeStatus.Text = "활성화 : 아니오";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(14, 272);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(156, 23);
            this.btnRestore.TabIndex = 23;
            this.btnRestore.Text = "원래 상태로 복원";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.BtnRestore_Click);
            // 
            // btnFocusExplode
            // 
            this.btnFocusExplode.Location = new System.Drawing.Point(180, 238);
            this.btnFocusExplode.Name = "btnFocusExplode";
            this.btnFocusExplode.Size = new System.Drawing.Size(156, 28);
            this.btnFocusExplode.TabIndex = 22;
            this.btnFocusExplode.Text = "선택 Node 중심 분해";
            this.btnFocusExplode.UseVisualStyleBackColor = true;
            this.btnFocusExplode.Click += new System.EventHandler(this.BtnFocusExplode_Click);
            // 
            // btnSequentialAnimation
            // 
            this.btnSequentialAnimation.Location = new System.Drawing.Point(14, 238);
            this.btnSequentialAnimation.Name = "btnSequentialAnimation";
            this.btnSequentialAnimation.Size = new System.Drawing.Size(156, 28);
            this.btnSequentialAnimation.TabIndex = 21;
            this.btnSequentialAnimation.Text = "계층 순차 분해";
            this.btnSequentialAnimation.UseVisualStyleBackColor = true;
            this.btnSequentialAnimation.Click += new System.EventHandler(this.BtnSequentialAnimation_Click);
            // 
            // btnDirectionalAnimation
            // 
            this.btnDirectionalAnimation.Location = new System.Drawing.Point(180, 204);
            this.btnDirectionalAnimation.Name = "btnDirectionalAnimation";
            this.btnDirectionalAnimation.Size = new System.Drawing.Size(156, 28);
            this.btnDirectionalAnimation.TabIndex = 20;
            this.btnDirectionalAnimation.Text = "방향 지정 분해";
            this.btnDirectionalAnimation.UseVisualStyleBackColor = true;
            this.btnDirectionalAnimation.Click += new System.EventHandler(this.BtnDirectionalAnimation_Click);
            // 
            // btnRadialAnimation
            // 
            this.btnRadialAnimation.Location = new System.Drawing.Point(14, 204);
            this.btnRadialAnimation.Name = "btnRadialAnimation";
            this.btnRadialAnimation.Size = new System.Drawing.Size(156, 28);
            this.btnRadialAnimation.TabIndex = 19;
            this.btnRadialAnimation.Text = "방사형 분해";
            this.btnRadialAnimation.UseVisualStyleBackColor = true;
            this.btnRadialAnimation.Click += new System.EventHandler(this.BtnRadialAnimation_Click);
            // 
            // chkAutoRestore
            // 
            this.chkAutoRestore.AutoSize = true;
            this.chkAutoRestore.Location = new System.Drawing.Point(14, 177);
            this.chkAutoRestore.Name = "chkAutoRestore";
            this.chkAutoRestore.Size = new System.Drawing.Size(252, 16);
            this.chkAutoRestore.TabIndex = 18;
            this.chkAutoRestore.Text = "애니메이션 완료 후 원래 상태로 자동 복원";
            this.chkAutoRestore.UseVisualStyleBackColor = true;
            // 
            // numHoldSeconds
            // 
            this.numHoldSeconds.DecimalPlaces = 2;
            this.numHoldSeconds.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numHoldSeconds.Location = new System.Drawing.Point(261, 144);
            this.numHoldSeconds.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHoldSeconds.Name = "numHoldSeconds";
            this.numHoldSeconds.Size = new System.Drawing.Size(48, 21);
            this.numHoldSeconds.TabIndex = 17;
            this.numHoldSeconds.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // lblHoldSeconds
            // 
            this.lblHoldSeconds.AutoSize = true;
            this.lblHoldSeconds.Location = new System.Drawing.Point(198, 148);
            this.lblHoldSeconds.Name = "lblHoldSeconds";
            this.lblHoldSeconds.Size = new System.Drawing.Size(57, 12);
            this.lblHoldSeconds.TabIndex = 16;
            this.lblHoldSeconds.Text = "단계 유지";
            // 
            // numDuration
            // 
            this.numDuration.DecimalPlaces = 2;
            this.numDuration.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numDuration.Location = new System.Drawing.Point(129, 144);
            this.numDuration.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(60, 21);
            this.numDuration.TabIndex = 15;
            this.numDuration.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(12, 148);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(115, 12);
            this.lblDuration.TabIndex = 14;
            this.lblDuration.Text = "애니메이션 시간(초)";
            // 
            // numDirectionZ
            // 
            this.numDirectionZ.DecimalPlaces = 1;
            this.numDirectionZ.Enabled = false;
            this.numDirectionZ.Location = new System.Drawing.Point(261, 112);
            this.numDirectionZ.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numDirectionZ.Name = "numDirectionZ";
            this.numDirectionZ.Size = new System.Drawing.Size(48, 21);
            this.numDirectionZ.TabIndex = 13;
            this.numDirectionZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numDirectionY
            // 
            this.numDirectionY.DecimalPlaces = 1;
            this.numDirectionY.Enabled = false;
            this.numDirectionY.Location = new System.Drawing.Point(185, 112);
            this.numDirectionY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numDirectionY.Name = "numDirectionY";
            this.numDirectionY.Size = new System.Drawing.Size(48, 21);
            this.numDirectionY.TabIndex = 11;
            // 
            // numDirectionX
            // 
            this.numDirectionX.DecimalPlaces = 1;
            this.numDirectionX.Enabled = false;
            this.numDirectionX.Location = new System.Drawing.Point(109, 112);
            this.numDirectionX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numDirectionX.Name = "numDirectionX";
            this.numDirectionX.Size = new System.Drawing.Size(48, 21);
            this.numDirectionX.TabIndex = 9;
            // 
            // lblDirectionZ
            // 
            this.lblDirectionZ.AutoSize = true;
            this.lblDirectionZ.Location = new System.Drawing.Point(243, 116);
            this.lblDirectionZ.Name = "lblDirectionZ";
            this.lblDirectionZ.Size = new System.Drawing.Size(13, 12);
            this.lblDirectionZ.TabIndex = 12;
            this.lblDirectionZ.Text = "Z";
            // 
            // lblDirectionY
            // 
            this.lblDirectionY.AutoSize = true;
            this.lblDirectionY.Location = new System.Drawing.Point(167, 116);
            this.lblDirectionY.Name = "lblDirectionY";
            this.lblDirectionY.Size = new System.Drawing.Size(13, 12);
            this.lblDirectionY.TabIndex = 10;
            this.lblDirectionY.Text = "Y";
            // 
            // lblDirectionX
            // 
            this.lblDirectionX.AutoSize = true;
            this.lblDirectionX.Location = new System.Drawing.Point(91, 116);
            this.lblDirectionX.Name = "lblDirectionX";
            this.lblDirectionX.Size = new System.Drawing.Size(13, 12);
            this.lblDirectionX.TabIndex = 8;
            this.lblDirectionX.Text = "X";
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(12, 116);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(57, 12);
            this.lblDirection.TabIndex = 7;
            this.lblDirection.Text = "분해 방향";
            // 
            // numLevelDecay
            // 
            this.numLevelDecay.DecimalPlaces = 2;
            this.numLevelDecay.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.numLevelDecay.Location = new System.Drawing.Point(111, 83);
            this.numLevelDecay.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLevelDecay.Name = "numLevelDecay";
            this.numLevelDecay.Size = new System.Drawing.Size(70, 21);
            this.numLevelDecay.TabIndex = 6;
            this.numLevelDecay.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // lblLevelDecay
            // 
            this.lblLevelDecay.AutoSize = true;
            this.lblLevelDecay.Location = new System.Drawing.Point(12, 87);
            this.lblLevelDecay.Name = "lblLevelDecay";
            this.lblLevelDecay.Size = new System.Drawing.Size(97, 12);
            this.lblLevelDecay.TabIndex = 5;
            this.lblLevelDecay.Text = "계층 거리 감소율";
            // 
            // numDistanceRatio
            // 
            this.numDistanceRatio.DecimalPlaces = 2;
            this.numDistanceRatio.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.numDistanceRatio.Location = new System.Drawing.Point(111, 54);
            this.numDistanceRatio.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numDistanceRatio.Name = "numDistanceRatio";
            this.numDistanceRatio.Size = new System.Drawing.Size(70, 21);
            this.numDistanceRatio.TabIndex = 4;
            this.numDistanceRatio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDistanceRatio
            // 
            this.lblDistanceRatio.AutoSize = true;
            this.lblDistanceRatio.Location = new System.Drawing.Point(12, 58);
            this.lblDistanceRatio.Name = "lblDistanceRatio";
            this.lblDistanceRatio.Size = new System.Drawing.Size(85, 12);
            this.lblDistanceRatio.TabIndex = 3;
            this.lblDistanceRatio.Text = "분해 거리 비율";
            // 
            // rdoDirectional
            // 
            this.rdoDirectional.AutoSize = true;
            this.rdoDirectional.Location = new System.Drawing.Point(171, 26);
            this.rdoDirectional.Name = "rdoDirectional";
            this.rdoDirectional.Size = new System.Drawing.Size(75, 16);
            this.rdoDirectional.TabIndex = 2;
            this.rdoDirectional.Text = "방향 지정";
            this.rdoDirectional.UseVisualStyleBackColor = true;
            this.rdoDirectional.CheckedChanged += new System.EventHandler(this.RdoExplodeMode_CheckedChanged);
            // 
            // rdoRadial
            // 
            this.rdoRadial.AutoSize = true;
            this.rdoRadial.Checked = true;
            this.rdoRadial.Location = new System.Drawing.Point(94, 26);
            this.rdoRadial.Name = "rdoRadial";
            this.rdoRadial.Size = new System.Drawing.Size(59, 16);
            this.rdoRadial.TabIndex = 1;
            this.rdoRadial.TabStop = true;
            this.rdoRadial.Text = "방사형";
            this.rdoRadial.UseVisualStyleBackColor = true;
            this.rdoRadial.CheckedChanged += new System.EventHandler(this.RdoExplodeMode_CheckedChanged);
            // 
            // lblExplodeMode
            // 
            this.lblExplodeMode.AutoSize = true;
            this.lblExplodeMode.Location = new System.Drawing.Point(12, 28);
            this.lblExplodeMode.Name = "lblExplodeMode";
            this.lblExplodeMode.Size = new System.Drawing.Size(57, 12);
            this.lblExplodeMode.TabIndex = 0;
            this.lblExplodeMode.Text = "분해 방식";
            // 
            // grpGroup
            // 
            this.grpGroup.Controls.Add(this.btnClearGroups);
            this.grpGroup.Controls.Add(this.btnDeleteGroup);
            this.grpGroup.Controls.Add(this.lblGroupCount);
            this.grpGroup.Controls.Add(this.tvGroups);
            this.grpGroup.Controls.Add(this.lblSelectedGroup);
            this.grpGroup.Controls.Add(this.lblGroupList);
            this.grpGroup.Controls.Add(this.chkGroupSelection);
            this.grpGroup.Controls.Add(this.numMaxDepth);
            this.grpGroup.Controls.Add(this.lblMaxDepth);
            this.grpGroup.Controls.Add(this.btnCreateHierarchicalGroups);
            this.grpGroup.Controls.Add(this.btnCreateFlatGroups);
            this.grpGroup.Controls.Add(this.btnMoveSelectedNodes);
            this.grpGroup.Controls.Add(this.btnRemoveSelectedNodes);
            this.grpGroup.Controls.Add(this.btnAddSelectedNodes);
            this.grpGroup.Controls.Add(this.btnAddChildGroup);
            this.grpGroup.Controls.Add(this.btnAddRootGroup);
            this.grpGroup.Controls.Add(this.txtGroupName);
            this.grpGroup.Controls.Add(this.lblGroupName);
            this.grpGroup.Location = new System.Drawing.Point(12, 46);
            this.grpGroup.Name = "grpGroup";
            this.grpGroup.Size = new System.Drawing.Size(348, 478);
            this.grpGroup.TabIndex = 1;
            this.grpGroup.TabStop = false;
            this.grpGroup.Text = "그룹";
            // 
            // btnClearGroups
            // 
            this.btnClearGroups.Location = new System.Drawing.Point(180, 435);
            this.btnClearGroups.Name = "btnClearGroups";
            this.btnClearGroups.Size = new System.Drawing.Size(156, 28);
            this.btnClearGroups.TabIndex = 17;
            this.btnClearGroups.Text = "모든 그룹 삭제";
            this.btnClearGroups.UseVisualStyleBackColor = true;
            this.btnClearGroups.Click += new System.EventHandler(this.BtnClearGroups_Click);
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Location = new System.Drawing.Point(12, 435);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(156, 28);
            this.btnDeleteGroup.TabIndex = 16;
            this.btnDeleteGroup.Text = "선택 그룹 삭제";
            this.btnDeleteGroup.UseVisualStyleBackColor = true;
            this.btnDeleteGroup.Click += new System.EventHandler(this.BtnDeleteGroup_Click);
            // 
            // lblGroupCount
            // 
            this.lblGroupCount.AutoSize = true;
            this.lblGroupCount.Location = new System.Drawing.Point(10, 415);
            this.lblGroupCount.Name = "lblGroupCount";
            this.lblGroupCount.Size = new System.Drawing.Size(171, 12);
            this.lblGroupCount.TabIndex = 15;
            this.lblGroupCount.Text = "최상위 그룹 : 0 / 전체 그룹 : 0";
            // 
            // tvGroups
            // 
            this.tvGroups.HideSelection = false;
            this.tvGroups.Location = new System.Drawing.Point(12, 248);
            this.tvGroups.Name = "tvGroups";
            this.tvGroups.Size = new System.Drawing.Size(324, 158);
            this.tvGroups.TabIndex = 14;
            this.tvGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvGroups_AfterSelect);
            // 
            // lblSelectedGroup
            // 
            this.lblSelectedGroup.AutoSize = true;
            this.lblSelectedGroup.Location = new System.Drawing.Point(78, 230);
            this.lblSelectedGroup.Name = "lblSelectedGroup";
            this.lblSelectedGroup.Size = new System.Drawing.Size(93, 12);
            this.lblSelectedGroup.TabIndex = 13;
            this.lblSelectedGroup.Text = "선택 그룹 : 없음";
            // 
            // lblGroupList
            // 
            this.lblGroupList.AutoSize = true;
            this.lblGroupList.Location = new System.Drawing.Point(10, 230);
            this.lblGroupList.Name = "lblGroupList";
            this.lblGroupList.Size = new System.Drawing.Size(57, 12);
            this.lblGroupList.TabIndex = 12;
            this.lblGroupList.Text = "그룹 목록";
            // 
            // chkGroupSelection
            // 
            this.chkGroupSelection.AutoSize = true;
            this.chkGroupSelection.Location = new System.Drawing.Point(180, 197);
            this.chkGroupSelection.Name = "chkGroupSelection";
            this.chkGroupSelection.Size = new System.Drawing.Size(144, 16);
            this.chkGroupSelection.TabIndex = 11;
            this.chkGroupSelection.Text = "뷰에서 그룹 단위 선택";
            this.chkGroupSelection.UseVisualStyleBackColor = true;
            this.chkGroupSelection.CheckedChanged += new System.EventHandler(this.ChkGroupSelection_CheckedChanged);
            // 
            // numMaxDepth
            // 
            this.numMaxDepth.Location = new System.Drawing.Point(87, 195);
            this.numMaxDepth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMaxDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxDepth.Name = "numMaxDepth";
            this.numMaxDepth.Size = new System.Drawing.Size(55, 21);
            this.numMaxDepth.TabIndex = 10;
            this.numMaxDepth.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblMaxDepth
            // 
            this.lblMaxDepth.AutoSize = true;
            this.lblMaxDepth.Location = new System.Drawing.Point(12, 199);
            this.lblMaxDepth.Name = "lblMaxDepth";
            this.lblMaxDepth.Size = new System.Drawing.Size(73, 12);
            this.lblMaxDepth.TabIndex = 9;
            this.lblMaxDepth.Text = "최대 계층 수";
            // 
            // btnCreateHierarchicalGroups
            // 
            this.btnCreateHierarchicalGroups.Location = new System.Drawing.Point(180, 158);
            this.btnCreateHierarchicalGroups.Name = "btnCreateHierarchicalGroups";
            this.btnCreateHierarchicalGroups.Size = new System.Drawing.Size(156, 28);
            this.btnCreateHierarchicalGroups.TabIndex = 8;
            this.btnCreateHierarchicalGroups.Text = "계층 자동 그룹";
            this.btnCreateHierarchicalGroups.UseVisualStyleBackColor = true;
            this.btnCreateHierarchicalGroups.Click += new System.EventHandler(this.BtnCreateHierarchicalGroups_Click);
            // 
            // btnCreateFlatGroups
            // 
            this.btnCreateFlatGroups.Location = new System.Drawing.Point(12, 158);
            this.btnCreateFlatGroups.Name = "btnCreateFlatGroups";
            this.btnCreateFlatGroups.Size = new System.Drawing.Size(156, 28);
            this.btnCreateFlatGroups.TabIndex = 7;
            this.btnCreateFlatGroups.Text = "평면 자동 그룹";
            this.btnCreateFlatGroups.UseVisualStyleBackColor = true;
            this.btnCreateFlatGroups.Click += new System.EventHandler(this.BtnCreateFlatGroups_Click);
            // 
            // btnMoveSelectedNodes
            // 
            this.btnMoveSelectedNodes.Location = new System.Drawing.Point(12, 124);
            this.btnMoveSelectedNodes.Name = "btnMoveSelectedNodes";
            this.btnMoveSelectedNodes.Size = new System.Drawing.Size(324, 28);
            this.btnMoveSelectedNodes.TabIndex = 6;
            this.btnMoveSelectedNodes.Text = "선택 Node 그룹으로 이동";
            this.btnMoveSelectedNodes.UseVisualStyleBackColor = true;
            this.btnMoveSelectedNodes.Click += new System.EventHandler(this.BtnMoveSelectedNodes_Click);
            // 
            // btnRemoveSelectedNodes
            // 
            this.btnRemoveSelectedNodes.Location = new System.Drawing.Point(180, 90);
            this.btnRemoveSelectedNodes.Name = "btnRemoveSelectedNodes";
            this.btnRemoveSelectedNodes.Size = new System.Drawing.Size(156, 28);
            this.btnRemoveSelectedNodes.TabIndex = 5;
            this.btnRemoveSelectedNodes.Text = "선택 Node 그룹에서 제거";
            this.btnRemoveSelectedNodes.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedNodes.Click += new System.EventHandler(this.BtnRemoveSelectedNodes_Click);
            // 
            // btnAddSelectedNodes
            // 
            this.btnAddSelectedNodes.Location = new System.Drawing.Point(12, 90);
            this.btnAddSelectedNodes.Name = "btnAddSelectedNodes";
            this.btnAddSelectedNodes.Size = new System.Drawing.Size(156, 28);
            this.btnAddSelectedNodes.TabIndex = 4;
            this.btnAddSelectedNodes.Text = "선택 Node 그룹에 추가";
            this.btnAddSelectedNodes.UseVisualStyleBackColor = true;
            this.btnAddSelectedNodes.Click += new System.EventHandler(this.BtnAddSelectedNodes_Click);
            // 
            // btnAddChildGroup
            // 
            this.btnAddChildGroup.Location = new System.Drawing.Point(180, 56);
            this.btnAddChildGroup.Name = "btnAddChildGroup";
            this.btnAddChildGroup.Size = new System.Drawing.Size(156, 28);
            this.btnAddChildGroup.TabIndex = 3;
            this.btnAddChildGroup.Text = "선택 그룹 아래 추가";
            this.btnAddChildGroup.UseVisualStyleBackColor = true;
            this.btnAddChildGroup.Click += new System.EventHandler(this.BtnAddChildGroup_Click);
            // 
            // btnAddRootGroup
            // 
            this.btnAddRootGroup.Location = new System.Drawing.Point(12, 56);
            this.btnAddRootGroup.Name = "btnAddRootGroup";
            this.btnAddRootGroup.Size = new System.Drawing.Size(156, 28);
            this.btnAddRootGroup.TabIndex = 2;
            this.btnAddRootGroup.Text = "최상위 그룹 추가";
            this.btnAddRootGroup.UseVisualStyleBackColor = true;
            this.btnAddRootGroup.Click += new System.EventHandler(this.BtnAddRootGroup_Click);
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(78, 24);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(258, 21);
            this.txtGroupName.TabIndex = 1;
            this.txtGroupName.Text = "Group 1";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(10, 28);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(57, 12);
            this.lblGroupName.TabIndex = 0;
            this.lblGroupName.Text = "그룹 이름";
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Location = new System.Drawing.Point(12, 12);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(348, 28);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "모델 불러오기";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.BtnOpenModel_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET - Group Explode";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpExplode.ResumeLayout(false);
            this.grpExplode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHoldSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDirectionZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDirectionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDirectionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLevelDecay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistanceRatio)).EndInit();
            this.grpGroup.ResumeLayout(false);
            this.grpGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDepth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.GroupBox grpGroup;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Button btnAddRootGroup;
        private System.Windows.Forms.Button btnAddChildGroup;
        private System.Windows.Forms.Button btnAddSelectedNodes;
        private System.Windows.Forms.Button btnRemoveSelectedNodes;
        private System.Windows.Forms.Button btnMoveSelectedNodes;
        private System.Windows.Forms.Button btnCreateFlatGroups;
        private System.Windows.Forms.Button btnCreateHierarchicalGroups;
        private System.Windows.Forms.Label lblMaxDepth;
        private System.Windows.Forms.NumericUpDown numMaxDepth;
        private System.Windows.Forms.CheckBox chkGroupSelection;
        private System.Windows.Forms.Label lblGroupList;
        private System.Windows.Forms.Label lblSelectedGroup;
        private System.Windows.Forms.TreeView tvGroups;
        private System.Windows.Forms.Label lblGroupCount;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.Button btnClearGroups;
        private System.Windows.Forms.GroupBox grpExplode;
        private System.Windows.Forms.Label lblExplodeMode;
        private System.Windows.Forms.RadioButton rdoRadial;
        private System.Windows.Forms.RadioButton rdoDirectional;
        private System.Windows.Forms.Label lblDistanceRatio;
        private System.Windows.Forms.NumericUpDown numDistanceRatio;
        private System.Windows.Forms.Label lblLevelDecay;
        private System.Windows.Forms.NumericUpDown numLevelDecay;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Label lblDirectionX;
        private System.Windows.Forms.NumericUpDown numDirectionX;
        private System.Windows.Forms.Label lblDirectionY;
        private System.Windows.Forms.NumericUpDown numDirectionY;
        private System.Windows.Forms.Label lblDirectionZ;
        private System.Windows.Forms.NumericUpDown numDirectionZ;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Label lblHoldSeconds;
        private System.Windows.Forms.NumericUpDown numHoldSeconds;
        private System.Windows.Forms.CheckBox chkAutoRestore;
        private System.Windows.Forms.Button btnRadialAnimation;
        private System.Windows.Forms.Button btnDirectionalAnimation;
        private System.Windows.Forms.Button btnSequentialAnimation;
        private System.Windows.Forms.Button btnFocusExplode;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label lblExplodeStatus;
    }
}