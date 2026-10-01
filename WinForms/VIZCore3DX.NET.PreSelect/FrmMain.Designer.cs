namespace VIZCore3DX.NET.PreSelect
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
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.btnClearPreSelection = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.grpSetup = new System.Windows.Forms.GroupBox();
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();
            this.cmbNodeNameTarget = new System.Windows.Forms.ComboBox();
            this.chkNodeNameVisible = new System.Windows.Forms.CheckBox();
            this.numLimit = new System.Windows.Forms.NumericUpDown();
            this.lblLimit = new System.Windows.Forms.Label();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.lblDelay = new System.Windows.Forms.Label();
            this.btnOutlineColor = new System.Windows.Forms.Button();
            this.lblOutlineColor = new System.Windows.Forms.Label();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.grpAction.SuspendLayout();
            this.grpSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpLog);
            this.splitContainer1.Panel1.Controls.Add(this.grpAction);
            this.splitContainer1.Panel1.Controls.Add(this.grpSetup);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Controls.Add(this.grpCleanup);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 800);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 0;
            //
            // grpLog
            //
            this.grpLog.Controls.Add(this.btnClearLog);
            this.grpLog.Controls.Add(this.lstLog);
            this.grpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLog.Location = new System.Drawing.Point(8, 398);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(344, 312);
            this.grpLog.TabIndex = 3;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "4. 이벤트 로그";
            //
            // btnClearLog
            //
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(212, 273);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(120, 23);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "로그 지우기";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            //
            // lstLog
            //
            this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLog.FormattingEnabled = true;
            this.lstLog.HorizontalScrollbar = true;
            this.lstLog.ItemHeight = 12;
            this.lstLog.Location = new System.Drawing.Point(12, 24);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(320, 240);
            this.lstLog.TabIndex = 0;
            //
            // grpAction
            //
            this.grpAction.Controls.Add(this.lblCurrent);
            this.grpAction.Controls.Add(this.btnClearPreSelection);
            this.grpAction.Controls.Add(this.btnLock);
            this.grpAction.Controls.Add(this.btnSelect);
            this.grpAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAction.Location = new System.Drawing.Point(8, 290);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(344, 108);
            this.grpAction.TabIndex = 2;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "3. 동작";
            //
            // lblCurrent
            //
            this.lblCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrent.AutoEllipsis = true;
            this.lblCurrent.Location = new System.Drawing.Point(12, 84);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(320, 16);
            this.lblCurrent.TabIndex = 3;
            this.lblCurrent.Text = "현재: -";
            //
            // btnClearPreSelection
            //
            this.btnClearPreSelection.Location = new System.Drawing.Point(12, 52);
            this.btnClearPreSelection.Name = "btnClearPreSelection";
            this.btnClearPreSelection.Size = new System.Drawing.Size(150, 23);
            this.btnClearPreSelection.TabIndex = 2;
            this.btnClearPreSelection.Text = "사전 선택 지우기";
            this.btnClearPreSelection.UseVisualStyleBackColor = true;
            this.btnClearPreSelection.Click += new System.EventHandler(this.btnClearPreSelection_Click);
            //
            // btnLock
            //
            this.btnLock.Location = new System.Drawing.Point(172, 24);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(160, 23);
            this.btnLock.TabIndex = 1;
            this.btnLock.Text = "잠금";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            //
            // btnSelect
            //
            this.btnSelect.Location = new System.Drawing.Point(12, 24);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(150, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "사전 선택 노드 선택";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            //
            // grpSetup
            //
            this.grpSetup.Controls.Add(this.chkAutoScroll);
            this.grpSetup.Controls.Add(this.cmbNodeNameTarget);
            this.grpSetup.Controls.Add(this.chkNodeNameVisible);
            this.grpSetup.Controls.Add(this.numLimit);
            this.grpSetup.Controls.Add(this.lblLimit);
            this.grpSetup.Controls.Add(this.numDelay);
            this.grpSetup.Controls.Add(this.lblDelay);
            this.grpSetup.Controls.Add(this.btnOutlineColor);
            this.grpSetup.Controls.Add(this.lblOutlineColor);
            this.grpSetup.Controls.Add(this.chkEnable);
            this.grpSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSetup.Location = new System.Drawing.Point(8, 104);
            this.grpSetup.Name = "grpSetup";
            this.grpSetup.Size = new System.Drawing.Size(344, 186);
            this.grpSetup.TabIndex = 1;
            this.grpSetup.TabStop = false;
            this.grpSetup.Text = "2. 설정";
            //
            // chkAutoScroll
            //
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Location = new System.Drawing.Point(12, 160);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(140, 16);
            this.chkAutoScroll.TabIndex = 8;
            this.chkAutoScroll.Text = "모델 트리 자동 스크롤";
            this.chkAutoScroll.UseVisualStyleBackColor = true;
            this.chkAutoScroll.CheckedChanged += new System.EventHandler(this.chkAutoScroll_CheckedChanged);
            //
            // cmbNodeNameTarget
            //
            this.cmbNodeNameTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeNameTarget.FormattingEnabled = true;
            this.cmbNodeNameTarget.Location = new System.Drawing.Point(112, 132);
            this.cmbNodeNameTarget.Name = "cmbNodeNameTarget";
            this.cmbNodeNameTarget.Size = new System.Drawing.Size(220, 20);
            this.cmbNodeNameTarget.TabIndex = 7;
            this.cmbNodeNameTarget.SelectedIndexChanged += new System.EventHandler(this.cmbNodeNameTarget_SelectedIndexChanged);
            //
            // chkNodeNameVisible
            //
            this.chkNodeNameVisible.AutoSize = true;
            this.chkNodeNameVisible.Location = new System.Drawing.Point(12, 134);
            this.chkNodeNameVisible.Name = "chkNodeNameVisible";
            this.chkNodeNameVisible.Size = new System.Drawing.Size(84, 16);
            this.chkNodeNameVisible.TabIndex = 6;
            this.chkNodeNameVisible.Text = "이름 표시";
            this.chkNodeNameVisible.UseVisualStyleBackColor = true;
            this.chkNodeNameVisible.CheckedChanged += new System.EventHandler(this.chkNodeNameVisible_CheckedChanged);
            //
            // numLimit
            //
            this.numLimit.Location = new System.Drawing.Point(112, 104);
            this.numLimit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLimit.Name = "numLimit";
            this.numLimit.Size = new System.Drawing.Size(100, 21);
            this.numLimit.TabIndex = 5;
            this.numLimit.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numLimit.ValueChanged += new System.EventHandler(this.numLimit_ValueChanged);
            //
            // lblLimit
            //
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(12, 108);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(81, 12);
            this.lblLimit.TabIndex = 4;
            this.lblLimit.Text = "최대 블록 개수";
            //
            // numDelay
            //
            this.numDelay.DecimalPlaces = 2;
            this.numDelay.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numDelay.Location = new System.Drawing.Point(112, 76);
            this.numDelay.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(100, 21);
            this.numDelay.TabIndex = 3;
            this.numDelay.ValueChanged += new System.EventHandler(this.numDelay_ValueChanged);
            //
            // lblDelay
            //
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(12, 80);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(81, 12);
            this.lblDelay.TabIndex = 2;
            this.lblDelay.Text = "지연 시간 (초)";
            //
            // btnOutlineColor
            //
            this.btnOutlineColor.Location = new System.Drawing.Point(112, 48);
            this.btnOutlineColor.Name = "btnOutlineColor";
            this.btnOutlineColor.Size = new System.Drawing.Size(100, 23);
            this.btnOutlineColor.TabIndex = 1;
            this.btnOutlineColor.Text = "색 선택...";
            this.btnOutlineColor.UseVisualStyleBackColor = false;
            this.btnOutlineColor.Click += new System.EventHandler(this.btnOutlineColor_Click);
            //
            // lblOutlineColor
            //
            this.lblOutlineColor.AutoSize = true;
            this.lblOutlineColor.Location = new System.Drawing.Point(12, 52);
            this.lblOutlineColor.Name = "lblOutlineColor";
            this.lblOutlineColor.Size = new System.Drawing.Size(57, 12);
            this.lblOutlineColor.TabIndex = 9;
            this.lblOutlineColor.Text = "외곽선 색";
            //
            // chkEnable
            //
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(12, 24);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(96, 16);
            this.chkEnable.TabIndex = 0;
            this.chkEnable.Text = "사전 선택 켜기";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
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
            this.lblModelHint.Text = "모델을 열고 [사전 선택 켜기]를 체크한 뒤\r\n뷰에서 노드 위로 마우스를 움직이면 미리 강조됩니다.";
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
            this.grpCleanup.Controls.Add(this.btnReset);
            this.grpCleanup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCleanup.Location = new System.Drawing.Point(8, 710);
            this.grpCleanup.Name = "grpCleanup";
            this.grpCleanup.Size = new System.Drawing.Size(344, 60);
            this.grpCleanup.TabIndex = 4;
            this.grpCleanup.TabStop = false;
            this.grpCleanup.Text = "5. 정리";
            //
            // btnReset
            //
            this.btnReset.Location = new System.Drawing.Point(12, 24);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(150, 23);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "끄고 정리";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            this.Text = "VIZCore3DX.NET.PreSelect";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpLog.ResumeLayout(false);
            this.grpAction.ResumeLayout(false);
            this.grpSetup.ResumeLayout(false);
            this.grpSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.grpModel.ResumeLayout(false);
            this.grpCleanup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Label lblModelHint;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.GroupBox grpSetup;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.Label lblOutlineColor;
        private System.Windows.Forms.Button btnOutlineColor;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.NumericUpDown numLimit;
        private System.Windows.Forms.CheckBox chkNodeNameVisible;
        private System.Windows.Forms.ComboBox cmbNodeNameTarget;
        private System.Windows.Forms.CheckBox chkAutoScroll;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnClearPreSelection;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblStatus;
    }
}
