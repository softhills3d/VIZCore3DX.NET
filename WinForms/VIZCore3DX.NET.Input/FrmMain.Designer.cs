namespace VIZCore3DX.NET.Input
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
            this.panelSetting = new System.Windows.Forms.Panel();
            this.btnApplyInputSetting = new System.Windows.Forms.Button();
            this.groupBoxInputDecision = new System.Windows.Forms.GroupBox();
            this.chkWheelDirectionInverted = new System.Windows.Forms.CheckBox();
            this.numClickTolerance = new System.Windows.Forms.NumericUpDown();
            this.lblClickTolerance = new System.Windows.Forms.Label();
            this.numLongPressDuration = new System.Windows.Forms.NumericUpDown();
            this.lblLongPressDuration = new System.Windows.Forms.Label();
            this.numClickDuration = new System.Windows.Forms.NumericUpDown();
            this.lblClickDuration = new System.Windows.Forms.Label();
            this.groupBoxMovement = new System.Windows.Forms.GroupBox();
            this.numFlySpeedBoostScale = new System.Windows.Forms.NumericUpDown();
            this.lblFlySpeedBoostScale = new System.Windows.Forms.Label();
            this.numFlySpeedRatio = new System.Windows.Forms.NumericUpDown();
            this.lblFlySpeedRatio = new System.Windows.Forms.Label();
            this.numWalkSpeedBoostScale = new System.Windows.Forms.NumericUpDown();
            this.lblWalkSpeedBoostScale = new System.Windows.Forms.Label();
            this.numWalkSpeedRatio = new System.Windows.Forms.NumericUpDown();
            this.lblWalkSpeedRatio = new System.Windows.Forms.Label();
            this.groupBoxSensitivity = new System.Windows.Forms.GroupBox();
            this.numLookSensitivity = new System.Windows.Forms.NumericUpDown();
            this.lblLookSensitivity = new System.Windows.Forms.Label();
            this.numRollSensitivity = new System.Windows.Forms.NumericUpDown();
            this.lblRollSensitivity = new System.Windows.Forms.Label();
            this.numZoomDragSensitivity = new System.Windows.Forms.NumericUpDown();
            this.lblZoomDragSensitivity = new System.Windows.Forms.Label();
            this.numPanSensitivity = new System.Windows.Forms.NumericUpDown();
            this.lblPanSensitivity = new System.Windows.Forms.Label();
            this.numOrbitSensitivity = new System.Windows.Forms.NumericUpDown();
            this.lblOrbitSensitivity = new System.Windows.Forms.Label();
            this.groupBoxComparison = new System.Windows.Forms.GroupBox();
            this.dgvComparison = new System.Windows.Forms.DataGridView();
            this.colSettingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfileValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDifference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxProfile = new System.Windows.Forms.GroupBox();
            this.cmbPreset = new System.Windows.Forms.ComboBox();
            this.lblPreset = new System.Windows.Forms.Label();
            this.btnRestoreDefault = new System.Windows.Forms.Button();
            this.btnSaveUserProfile = new System.Windows.Forms.Button();
            this.cmbProfile = new System.Windows.Forms.ComboBox();
            this.lblProfile = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelSetting.SuspendLayout();
            this.groupBoxInputDecision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClickTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLongPressDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClickDuration)).BeginInit();
            this.groupBoxMovement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFlySpeedBoostScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFlySpeedRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkSpeedBoostScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkSpeedRatio)).BeginInit();
            this.groupBoxSensitivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLookSensitivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRollSensitivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZoomDragSensitivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPanSensitivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOrbitSensitivity)).BeginInit();
            this.groupBoxComparison.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComparison)).BeginInit();
            this.groupBoxProfile.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.panelSetting);
            this.splitContainer1.Panel2MinSize = 620;
            this.splitContainer1.Size = new System.Drawing.Size(1500, 900);
            this.splitContainer1.SplitterDistance = 860;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelSetting
            // 
            this.panelSetting.AutoScroll = true;
            this.panelSetting.Controls.Add(this.btnApplyInputSetting);
            this.panelSetting.Controls.Add(this.groupBoxInputDecision);
            this.panelSetting.Controls.Add(this.groupBoxMovement);
            this.panelSetting.Controls.Add(this.groupBoxSensitivity);
            this.panelSetting.Controls.Add(this.groupBoxComparison);
            this.panelSetting.Controls.Add(this.groupBoxProfile);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetting.Location = new System.Drawing.Point(0, 0);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(636, 900);
            this.panelSetting.TabIndex = 0;
            // 
            // btnApplyInputSetting
            // 
            this.btnApplyInputSetting.Location = new System.Drawing.Point(10, 767);
            this.btnApplyInputSetting.Name = "btnApplyInputSetting";
            this.btnApplyInputSetting.Size = new System.Drawing.Size(600, 42);
            this.btnApplyInputSetting.TabIndex = 6;
            this.btnApplyInputSetting.Text = "현재 조작 설정 적용";
            this.btnApplyInputSetting.UseVisualStyleBackColor = true;
            this.btnApplyInputSetting.Click += new System.EventHandler(this.btnApplyInputSetting_Click);
            // 
            // groupBoxInputDecision
            // 
            this.groupBoxInputDecision.Controls.Add(this.chkWheelDirectionInverted);
            this.groupBoxInputDecision.Controls.Add(this.numClickTolerance);
            this.groupBoxInputDecision.Controls.Add(this.lblClickTolerance);
            this.groupBoxInputDecision.Controls.Add(this.numLongPressDuration);
            this.groupBoxInputDecision.Controls.Add(this.lblLongPressDuration);
            this.groupBoxInputDecision.Controls.Add(this.numClickDuration);
            this.groupBoxInputDecision.Controls.Add(this.lblClickDuration);
            this.groupBoxInputDecision.Location = new System.Drawing.Point(10, 649);
            this.groupBoxInputDecision.Name = "groupBoxInputDecision";
            this.groupBoxInputDecision.Size = new System.Drawing.Size(600, 108);
            this.groupBoxInputDecision.TabIndex = 5;
            this.groupBoxInputDecision.TabStop = false;
            this.groupBoxInputDecision.Text = "입력 판정";
            // 
            // chkWheelDirectionInverted
            // 
            this.chkWheelDirectionInverted.AutoSize = true;
            this.chkWheelDirectionInverted.Location = new System.Drawing.Point(317, 70);
            this.chkWheelDirectionInverted.Name = "chkWheelDirectionInverted";
            this.chkWheelDirectionInverted.Size = new System.Drawing.Size(92, 16);
            this.chkWheelDirectionInverted.TabIndex = 6;
            this.chkWheelDirectionInverted.Text = "휠 방향 반전";
            this.chkWheelDirectionInverted.UseVisualStyleBackColor = true;
            // 
            // numClickTolerance
            // 
            this.numClickTolerance.Location = new System.Drawing.Point(160, 68);
            this.numClickTolerance.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numClickTolerance.Name = "numClickTolerance";
            this.numClickTolerance.Size = new System.Drawing.Size(110, 21);
            this.numClickTolerance.TabIndex = 5;
            // 
            // lblClickTolerance
            // 
            this.lblClickTolerance.AutoSize = true;
            this.lblClickTolerance.Location = new System.Drawing.Point(18, 72);
            this.lblClickTolerance.Name = "lblClickTolerance";
            this.lblClickTolerance.Size = new System.Drawing.Size(137, 12);
            this.lblClickTolerance.TabIndex = 4;
            this.lblClickTolerance.Text = "클릭 이동 허용 거리(px)";
            // 
            // numLongPressDuration
            // 
            this.numLongPressDuration.Location = new System.Drawing.Point(470, 26);
            this.numLongPressDuration.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numLongPressDuration.Name = "numLongPressDuration";
            this.numLongPressDuration.Size = new System.Drawing.Size(110, 21);
            this.numLongPressDuration.TabIndex = 3;
            // 
            // lblLongPressDuration
            // 
            this.lblLongPressDuration.AutoSize = true;
            this.lblLongPressDuration.Location = new System.Drawing.Point(315, 30);
            this.lblLongPressDuration.Name = "lblLongPressDuration";
            this.lblLongPressDuration.Size = new System.Drawing.Size(113, 12);
            this.lblLongPressDuration.TabIndex = 2;
            this.lblLongPressDuration.Text = "길게 누름 시간(ms)";
            // 
            // numClickDuration
            // 
            this.numClickDuration.Location = new System.Drawing.Point(160, 26);
            this.numClickDuration.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numClickDuration.Name = "numClickDuration";
            this.numClickDuration.Size = new System.Drawing.Size(110, 21);
            this.numClickDuration.TabIndex = 1;
            // 
            // lblClickDuration
            // 
            this.lblClickDuration.AutoSize = true;
            this.lblClickDuration.Location = new System.Drawing.Point(18, 30);
            this.lblClickDuration.Name = "lblClickDuration";
            this.lblClickDuration.Size = new System.Drawing.Size(113, 12);
            this.lblClickDuration.TabIndex = 0;
            this.lblClickDuration.Text = "클릭 최대 시간(ms)";
            // 
            // groupBoxMovement
            // 
            this.groupBoxMovement.Controls.Add(this.numFlySpeedBoostScale);
            this.groupBoxMovement.Controls.Add(this.lblFlySpeedBoostScale);
            this.groupBoxMovement.Controls.Add(this.numFlySpeedRatio);
            this.groupBoxMovement.Controls.Add(this.lblFlySpeedRatio);
            this.groupBoxMovement.Controls.Add(this.numWalkSpeedBoostScale);
            this.groupBoxMovement.Controls.Add(this.lblWalkSpeedBoostScale);
            this.groupBoxMovement.Controls.Add(this.numWalkSpeedRatio);
            this.groupBoxMovement.Controls.Add(this.lblWalkSpeedRatio);
            this.groupBoxMovement.Location = new System.Drawing.Point(10, 540);
            this.groupBoxMovement.Name = "groupBoxMovement";
            this.groupBoxMovement.Size = new System.Drawing.Size(600, 103);
            this.groupBoxMovement.TabIndex = 4;
            this.groupBoxMovement.TabStop = false;
            this.groupBoxMovement.Text = "이동 속도";
            // 
            // numFlySpeedBoostScale
            // 
            this.numFlySpeedBoostScale.DecimalPlaces = 3;
            this.numFlySpeedBoostScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numFlySpeedBoostScale.Location = new System.Drawing.Point(470, 66);
            this.numFlySpeedBoostScale.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numFlySpeedBoostScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numFlySpeedBoostScale.Name = "numFlySpeedBoostScale";
            this.numFlySpeedBoostScale.Size = new System.Drawing.Size(110, 21);
            this.numFlySpeedBoostScale.TabIndex = 7;
            // 
            // lblFlySpeedBoostScale
            // 
            this.lblFlySpeedBoostScale.AutoSize = true;
            this.lblFlySpeedBoostScale.Location = new System.Drawing.Point(315, 70);
            this.lblFlySpeedBoostScale.Name = "lblFlySpeedBoostScale";
            this.lblFlySpeedBoostScale.Size = new System.Drawing.Size(97, 12);
            this.lblFlySpeedBoostScale.TabIndex = 6;
            this.lblFlySpeedBoostScale.Text = "비행 부스트 배율";
            // 
            // numFlySpeedRatio
            // 
            this.numFlySpeedRatio.DecimalPlaces = 3;
            this.numFlySpeedRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numFlySpeedRatio.Location = new System.Drawing.Point(160, 66);
            this.numFlySpeedRatio.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numFlySpeedRatio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numFlySpeedRatio.Name = "numFlySpeedRatio";
            this.numFlySpeedRatio.Size = new System.Drawing.Size(110, 21);
            this.numFlySpeedRatio.TabIndex = 5;
            // 
            // lblFlySpeedRatio
            // 
            this.lblFlySpeedRatio.AutoSize = true;
            this.lblFlySpeedRatio.Location = new System.Drawing.Point(18, 70);
            this.lblFlySpeedRatio.Name = "lblFlySpeedRatio";
            this.lblFlySpeedRatio.Size = new System.Drawing.Size(85, 12);
            this.lblFlySpeedRatio.TabIndex = 4;
            this.lblFlySpeedRatio.Text = "비행 속도 배율";
            // 
            // numWalkSpeedBoostScale
            // 
            this.numWalkSpeedBoostScale.DecimalPlaces = 3;
            this.numWalkSpeedBoostScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numWalkSpeedBoostScale.Location = new System.Drawing.Point(470, 26);
            this.numWalkSpeedBoostScale.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numWalkSpeedBoostScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numWalkSpeedBoostScale.Name = "numWalkSpeedBoostScale";
            this.numWalkSpeedBoostScale.Size = new System.Drawing.Size(110, 21);
            this.numWalkSpeedBoostScale.TabIndex = 3;
            // 
            // lblWalkSpeedBoostScale
            // 
            this.lblWalkSpeedBoostScale.AutoSize = true;
            this.lblWalkSpeedBoostScale.Location = new System.Drawing.Point(315, 30);
            this.lblWalkSpeedBoostScale.Name = "lblWalkSpeedBoostScale";
            this.lblWalkSpeedBoostScale.Size = new System.Drawing.Size(97, 12);
            this.lblWalkSpeedBoostScale.TabIndex = 2;
            this.lblWalkSpeedBoostScale.Text = "보행 부스트 배율";
            // 
            // numWalkSpeedRatio
            // 
            this.numWalkSpeedRatio.DecimalPlaces = 3;
            this.numWalkSpeedRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numWalkSpeedRatio.Location = new System.Drawing.Point(160, 26);
            this.numWalkSpeedRatio.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numWalkSpeedRatio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numWalkSpeedRatio.Name = "numWalkSpeedRatio";
            this.numWalkSpeedRatio.Size = new System.Drawing.Size(110, 21);
            this.numWalkSpeedRatio.TabIndex = 1;
            // 
            // lblWalkSpeedRatio
            // 
            this.lblWalkSpeedRatio.AutoSize = true;
            this.lblWalkSpeedRatio.Location = new System.Drawing.Point(18, 30);
            this.lblWalkSpeedRatio.Name = "lblWalkSpeedRatio";
            this.lblWalkSpeedRatio.Size = new System.Drawing.Size(85, 12);
            this.lblWalkSpeedRatio.TabIndex = 0;
            this.lblWalkSpeedRatio.Text = "보행 속도 배율";
            // 
            // groupBoxSensitivity
            // 
            this.groupBoxSensitivity.Controls.Add(this.numLookSensitivity);
            this.groupBoxSensitivity.Controls.Add(this.lblLookSensitivity);
            this.groupBoxSensitivity.Controls.Add(this.numRollSensitivity);
            this.groupBoxSensitivity.Controls.Add(this.lblRollSensitivity);
            this.groupBoxSensitivity.Controls.Add(this.numZoomDragSensitivity);
            this.groupBoxSensitivity.Controls.Add(this.lblZoomDragSensitivity);
            this.groupBoxSensitivity.Controls.Add(this.numPanSensitivity);
            this.groupBoxSensitivity.Controls.Add(this.lblPanSensitivity);
            this.groupBoxSensitivity.Controls.Add(this.numOrbitSensitivity);
            this.groupBoxSensitivity.Controls.Add(this.lblOrbitSensitivity);
            this.groupBoxSensitivity.Location = new System.Drawing.Point(10, 394);
            this.groupBoxSensitivity.Name = "groupBoxSensitivity";
            this.groupBoxSensitivity.Size = new System.Drawing.Size(600, 140);
            this.groupBoxSensitivity.TabIndex = 3;
            this.groupBoxSensitivity.TabStop = false;
            this.groupBoxSensitivity.Text = "조작 감도";
            // 
            // numLookSensitivity
            // 
            this.numLookSensitivity.DecimalPlaces = 3;
            this.numLookSensitivity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numLookSensitivity.Location = new System.Drawing.Point(160, 106);
            this.numLookSensitivity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLookSensitivity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numLookSensitivity.Name = "numLookSensitivity";
            this.numLookSensitivity.Size = new System.Drawing.Size(110, 21);
            this.numLookSensitivity.TabIndex = 9;
            // 
            // lblLookSensitivity
            // 
            this.lblLookSensitivity.AutoSize = true;
            this.lblLookSensitivity.Location = new System.Drawing.Point(18, 110);
            this.lblLookSensitivity.Name = "lblLookSensitivity";
            this.lblLookSensitivity.Size = new System.Drawing.Size(85, 12);
            this.lblLookSensitivity.TabIndex = 8;
            this.lblLookSensitivity.Text = "시선 회전 감도";
            // 
            // numRollSensitivity
            // 
            this.numRollSensitivity.DecimalPlaces = 3;
            this.numRollSensitivity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numRollSensitivity.Location = new System.Drawing.Point(470, 66);
            this.numRollSensitivity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRollSensitivity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numRollSensitivity.Name = "numRollSensitivity";
            this.numRollSensitivity.Size = new System.Drawing.Size(110, 21);
            this.numRollSensitivity.TabIndex = 7;
            // 
            // lblRollSensitivity
            // 
            this.lblRollSensitivity.AutoSize = true;
            this.lblRollSensitivity.Location = new System.Drawing.Point(315, 70);
            this.lblRollSensitivity.Name = "lblRollSensitivity";
            this.lblRollSensitivity.Size = new System.Drawing.Size(97, 12);
            this.lblRollSensitivity.TabIndex = 6;
            this.lblRollSensitivity.Text = "화면 기울임 감도";
            // 
            // numZoomDragSensitivity
            // 
            this.numZoomDragSensitivity.DecimalPlaces = 3;
            this.numZoomDragSensitivity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numZoomDragSensitivity.Location = new System.Drawing.Point(160, 66);
            this.numZoomDragSensitivity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numZoomDragSensitivity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numZoomDragSensitivity.Name = "numZoomDragSensitivity";
            this.numZoomDragSensitivity.Size = new System.Drawing.Size(110, 21);
            this.numZoomDragSensitivity.TabIndex = 5;
            // 
            // lblZoomDragSensitivity
            // 
            this.lblZoomDragSensitivity.AutoSize = true;
            this.lblZoomDragSensitivity.Location = new System.Drawing.Point(18, 70);
            this.lblZoomDragSensitivity.Name = "lblZoomDragSensitivity";
            this.lblZoomDragSensitivity.Size = new System.Drawing.Size(127, 12);
            this.lblZoomDragSensitivity.TabIndex = 4;
            this.lblZoomDragSensitivity.Text = "드래그 확대/축소 감도";
            // 
            // numPanSensitivity
            // 
            this.numPanSensitivity.DecimalPlaces = 3;
            this.numPanSensitivity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numPanSensitivity.Location = new System.Drawing.Point(470, 26);
            this.numPanSensitivity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPanSensitivity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numPanSensitivity.Name = "numPanSensitivity";
            this.numPanSensitivity.Size = new System.Drawing.Size(110, 21);
            this.numPanSensitivity.TabIndex = 3;
            // 
            // lblPanSensitivity
            // 
            this.lblPanSensitivity.AutoSize = true;
            this.lblPanSensitivity.Location = new System.Drawing.Point(315, 30);
            this.lblPanSensitivity.Name = "lblPanSensitivity";
            this.lblPanSensitivity.Size = new System.Drawing.Size(85, 12);
            this.lblPanSensitivity.TabIndex = 2;
            this.lblPanSensitivity.Text = "화면 이동 감도";
            // 
            // numOrbitSensitivity
            // 
            this.numOrbitSensitivity.DecimalPlaces = 3;
            this.numOrbitSensitivity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numOrbitSensitivity.Location = new System.Drawing.Point(160, 26);
            this.numOrbitSensitivity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numOrbitSensitivity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numOrbitSensitivity.Name = "numOrbitSensitivity";
            this.numOrbitSensitivity.Size = new System.Drawing.Size(110, 21);
            this.numOrbitSensitivity.TabIndex = 1;
            // 
            // lblOrbitSensitivity
            // 
            this.lblOrbitSensitivity.AutoSize = true;
            this.lblOrbitSensitivity.Location = new System.Drawing.Point(18, 30);
            this.lblOrbitSensitivity.Name = "lblOrbitSensitivity";
            this.lblOrbitSensitivity.Size = new System.Drawing.Size(57, 12);
            this.lblOrbitSensitivity.TabIndex = 0;
            this.lblOrbitSensitivity.Text = "회전 감도";
            // 
            // groupBoxComparison
            // 
            this.groupBoxComparison.Controls.Add(this.dgvComparison);
            this.groupBoxComparison.Location = new System.Drawing.Point(10, 123);
            this.groupBoxComparison.Name = "groupBoxComparison";
            this.groupBoxComparison.Size = new System.Drawing.Size(600, 265);
            this.groupBoxComparison.TabIndex = 2;
            this.groupBoxComparison.TabStop = false;
            this.groupBoxComparison.Text = "현재 설정 / 선택 프로필 비교";
            // 
            // dgvComparison
            // 
            this.dgvComparison.AllowUserToAddRows = false;
            this.dgvComparison.AllowUserToDeleteRows = false;
            this.dgvComparison.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComparison.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComparison.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSettingName,
            this.colCurrentValue,
            this.colProfileValue,
            this.colDifference});
            this.dgvComparison.Location = new System.Drawing.Point(15, 25);
            this.dgvComparison.Name = "dgvComparison";
            this.dgvComparison.ReadOnly = true;
            this.dgvComparison.RowHeadersVisible = false;
            this.dgvComparison.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComparison.Size = new System.Drawing.Size(565, 220);
            this.dgvComparison.TabIndex = 0;
            // 
            // colSettingName
            // 
            this.colSettingName.HeaderText = "항목";
            this.colSettingName.Name = "colSettingName";
            this.colSettingName.ReadOnly = true;
            // 
            // colCurrentValue
            // 
            this.colCurrentValue.HeaderText = "현재 값";
            this.colCurrentValue.Name = "colCurrentValue";
            this.colCurrentValue.ReadOnly = true;
            // 
            // colProfileValue
            // 
            this.colProfileValue.HeaderText = "프로필 값";
            this.colProfileValue.Name = "colProfileValue";
            this.colProfileValue.ReadOnly = true;
            // 
            // colDifference
            // 
            this.colDifference.HeaderText = "차이";
            this.colDifference.Name = "colDifference";
            this.colDifference.ReadOnly = true;
            // 
            // groupBoxProfile
            // 
            this.groupBoxProfile.Controls.Add(this.cmbPreset);
            this.groupBoxProfile.Controls.Add(this.lblPreset);
            this.groupBoxProfile.Controls.Add(this.btnRestoreDefault);
            this.groupBoxProfile.Controls.Add(this.btnSaveUserProfile);
            this.groupBoxProfile.Controls.Add(this.cmbProfile);
            this.groupBoxProfile.Controls.Add(this.lblProfile);
            this.groupBoxProfile.Location = new System.Drawing.Point(10, 10);
            this.groupBoxProfile.Name = "groupBoxProfile";
            this.groupBoxProfile.Size = new System.Drawing.Size(600, 107);
            this.groupBoxProfile.TabIndex = 1;
            this.groupBoxProfile.TabStop = false;
            this.groupBoxProfile.Text = "조작 프로필";
            // 
            // cmbPreset
            // 
            this.cmbPreset.DataSource = System.Enum.GetValues(typeof(VIZCore3DX.NET.Data.InputPreset));
            this.cmbPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPreset.FormattingEnabled = true;
            this.cmbPreset.Location = new System.Drawing.Point(376, 26);
            this.cmbPreset.Name = "cmbPreset";
            this.cmbPreset.Size = new System.Drawing.Size(195, 20);
            this.cmbPreset.TabIndex = 3;
            // 
            // lblPreset
            // 
            this.lblPreset.AutoSize = true;
            this.lblPreset.Location = new System.Drawing.Point(329, 29);
            this.lblPreset.Name = "lblPreset";
            this.lblPreset.Size = new System.Drawing.Size(41, 12);
            this.lblPreset.TabIndex = 2;
            this.lblPreset.Text = "프리셋";
            // 
            // btnRestoreDefault
            // 
            this.btnRestoreDefault.Location = new System.Drawing.Point(305, 61);
            this.btnRestoreDefault.Name = "btnRestoreDefault";
            this.btnRestoreDefault.Size = new System.Drawing.Size(275, 32);
            this.btnRestoreDefault.TabIndex = 6;
            this.btnRestoreDefault.Text = "기본값 복원";
            this.btnRestoreDefault.UseVisualStyleBackColor = true;
            this.btnRestoreDefault.Click += new System.EventHandler(this.btnRestoreDefault_Click);
            // 
            // btnSaveUserProfile
            // 
            this.btnSaveUserProfile.Location = new System.Drawing.Point(20, 61);
            this.btnSaveUserProfile.Name = "btnSaveUserProfile";
            this.btnSaveUserProfile.Size = new System.Drawing.Size(275, 32);
            this.btnSaveUserProfile.TabIndex = 5;
            this.btnSaveUserProfile.Text = "현재 입력값 → 사용자 설정 저장";
            this.btnSaveUserProfile.UseVisualStyleBackColor = true;
            this.btnSaveUserProfile.Click += new System.EventHandler(this.btnSaveUserProfile_Click);
            // 
            // cmbProfile
            // 
            this.cmbProfile.DisplayMember = "Name";
            this.cmbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfile.FormattingEnabled = true;
            this.cmbProfile.Location = new System.Drawing.Point(70, 26);
            this.cmbProfile.Name = "cmbProfile";
            this.cmbProfile.Size = new System.Drawing.Size(190, 20);
            this.cmbProfile.TabIndex = 1;
            this.cmbProfile.SelectedIndexChanged += new System.EventHandler(this.cmbProfile_SelectedIndexChanged);
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Location = new System.Drawing.Point(18, 30);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(41, 12);
            this.lblProfile.TabIndex = 0;
            this.lblProfile.Text = "프로필";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 900);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1250, 760);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.Input";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelSetting.ResumeLayout(false);
            this.groupBoxInputDecision.ResumeLayout(false);
            this.groupBoxInputDecision.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClickTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLongPressDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClickDuration)).EndInit();
            this.groupBoxMovement.ResumeLayout(false);
            this.groupBoxMovement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFlySpeedBoostScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFlySpeedRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkSpeedBoostScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkSpeedRatio)).EndInit();
            this.groupBoxSensitivity.ResumeLayout(false);
            this.groupBoxSensitivity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLookSensitivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRollSensitivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZoomDragSensitivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPanSensitivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOrbitSensitivity)).EndInit();
            this.groupBoxComparison.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComparison)).EndInit();
            this.groupBoxProfile.ResumeLayout(false);
            this.groupBoxProfile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.GroupBox groupBoxProfile;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.ComboBox cmbProfile;
        private System.Windows.Forms.Label lblPreset;
        private System.Windows.Forms.ComboBox cmbPreset;
        private System.Windows.Forms.Button btnSaveUserProfile;
        private System.Windows.Forms.Button btnRestoreDefault;
        private System.Windows.Forms.GroupBox groupBoxComparison;
        private System.Windows.Forms.DataGridView dgvComparison;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSettingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfileValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDifference;
        private System.Windows.Forms.GroupBox groupBoxSensitivity;
        private System.Windows.Forms.Label lblOrbitSensitivity;
        private System.Windows.Forms.NumericUpDown numOrbitSensitivity;
        private System.Windows.Forms.Label lblPanSensitivity;
        private System.Windows.Forms.NumericUpDown numPanSensitivity;
        private System.Windows.Forms.Label lblZoomDragSensitivity;
        private System.Windows.Forms.NumericUpDown numZoomDragSensitivity;
        private System.Windows.Forms.Label lblRollSensitivity;
        private System.Windows.Forms.NumericUpDown numRollSensitivity;
        private System.Windows.Forms.Label lblLookSensitivity;
        private System.Windows.Forms.NumericUpDown numLookSensitivity;
        private System.Windows.Forms.GroupBox groupBoxMovement;
        private System.Windows.Forms.Label lblWalkSpeedRatio;
        private System.Windows.Forms.NumericUpDown numWalkSpeedRatio;
        private System.Windows.Forms.Label lblWalkSpeedBoostScale;
        private System.Windows.Forms.NumericUpDown numWalkSpeedBoostScale;
        private System.Windows.Forms.Label lblFlySpeedRatio;
        private System.Windows.Forms.NumericUpDown numFlySpeedRatio;
        private System.Windows.Forms.Label lblFlySpeedBoostScale;
        private System.Windows.Forms.NumericUpDown numFlySpeedBoostScale;
        private System.Windows.Forms.GroupBox groupBoxInputDecision;
        private System.Windows.Forms.Label lblClickDuration;
        private System.Windows.Forms.NumericUpDown numClickDuration;
        private System.Windows.Forms.Label lblLongPressDuration;
        private System.Windows.Forms.NumericUpDown numLongPressDuration;
        private System.Windows.Forms.Label lblClickTolerance;
        private System.Windows.Forms.NumericUpDown numClickTolerance;
        private System.Windows.Forms.CheckBox chkWheelDirectionInverted;
        private System.Windows.Forms.Button btnApplyInputSetting;
    }
}
