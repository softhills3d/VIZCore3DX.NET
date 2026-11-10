namespace VIZCore3DX.NET.Command.Mcp
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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.grpServer = new System.Windows.Forms.GroupBox();
            this.txtRegister = new System.Windows.Forms.TextBox();
            this.lblRegister = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.chkReadOnlyOnly = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblPort = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelGuide = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.grpServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.grpModel.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpServer);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 800);
            this.splitContainer1.SplitterDistance = 460;
            this.splitContainer1.TabIndex = 0;
            //
            // grpLog
            //
            this.grpLog.Controls.Add(this.btnClearLog);
            this.grpLog.Controls.Add(this.txtLog);
            this.grpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLog.Location = new System.Drawing.Point(8, 294);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(444, 476);
            this.grpLog.TabIndex = 2;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "3. 요청 기록";
            //
            // btnClearLog
            //
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearLog.Location = new System.Drawing.Point(12, 436);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(120, 28);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "기록 지우기";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            //
            // txtLog
            //
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtLog.Location = new System.Drawing.Point(12, 22);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(420, 406);
            this.txtLog.TabIndex = 0;
            //
            // grpServer
            //
            this.grpServer.Controls.Add(this.txtRegister);
            this.grpServer.Controls.Add(this.lblRegister);
            this.grpServer.Controls.Add(this.txtUrl);
            this.grpServer.Controls.Add(this.lblUrl);
            this.grpServer.Controls.Add(this.chkReadOnlyOnly);
            this.grpServer.Controls.Add(this.btnStop);
            this.grpServer.Controls.Add(this.btnStart);
            this.grpServer.Controls.Add(this.numPort);
            this.grpServer.Controls.Add(this.lblPort);
            this.grpServer.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpServer.Location = new System.Drawing.Point(8, 104);
            this.grpServer.Name = "grpServer";
            this.grpServer.Size = new System.Drawing.Size(444, 190);
            this.grpServer.TabIndex = 1;
            this.grpServer.TabStop = false;
            this.grpServer.Text = "2. 서버";
            //
            // txtRegister
            //
            this.txtRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegister.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtRegister.Location = new System.Drawing.Point(12, 152);
            this.txtRegister.Name = "txtRegister";
            this.txtRegister.ReadOnly = true;
            this.txtRegister.Size = new System.Drawing.Size(420, 22);
            this.txtRegister.TabIndex = 8;
            //
            // lblRegister
            //
            this.lblRegister.AutoSize = true;
            this.lblRegister.Location = new System.Drawing.Point(12, 134);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(125, 12);
            this.lblRegister.TabIndex = 7;
            this.lblRegister.Text = "등록 예 (Claude Code)";
            //
            // txtUrl
            //
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtUrl.Location = new System.Drawing.Point(12, 104);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.ReadOnly = true;
            this.txtUrl.Size = new System.Drawing.Size(420, 22);
            this.txtUrl.TabIndex = 6;
            //
            // lblUrl
            //
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(12, 86);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(53, 12);
            this.lblUrl.TabIndex = 5;
            this.lblUrl.Text = "접속 주소";
            //
            // chkReadOnlyOnly
            //
            this.chkReadOnlyOnly.AutoSize = true;
            this.chkReadOnlyOnly.Location = new System.Drawing.Point(12, 60);
            this.chkReadOnlyOnly.Name = "chkReadOnlyOnly";
            this.chkReadOnlyOnly.Size = new System.Drawing.Size(208, 16);
            this.chkReadOnlyOnly.TabIndex = 4;
            this.chkReadOnlyOnly.Text = "조회 명령만 공개 (변경 명령 거절)";
            this.chkReadOnlyOnly.UseVisualStyleBackColor = true;
            this.chkReadOnlyOnly.CheckedChanged += new System.EventHandler(this.chkReadOnlyOnly_CheckedChanged);
            //
            // btnStop
            //
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(332, 22);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 28);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "서버 정지";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            //
            // btnStart
            //
            this.btnStart.Location = new System.Drawing.Point(226, 22);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 28);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "서버 시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            //
            // numPort
            //
            this.numPort.Location = new System.Drawing.Point(50, 26);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(80, 21);
            this.numPort.TabIndex = 1;
            this.numPort.Value = new decimal(new int[] {
            8765,
            0,
            0,
            0});
            this.numPort.ValueChanged += new System.EventHandler(this.numPort_ValueChanged);
            //
            // lblPort
            //
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 30);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 12);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "포트";
            //
            // grpModel
            //
            this.grpModel.Controls.Add(this.lblModelGuide);
            this.grpModel.Controls.Add(this.btnOpenModel);
            this.grpModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpModel.Location = new System.Drawing.Point(8, 8);
            this.grpModel.Name = "grpModel";
            this.grpModel.Size = new System.Drawing.Size(444, 96);
            this.grpModel.TabIndex = 0;
            this.grpModel.TabStop = false;
            this.grpModel.Text = "1. 모델";
            //
            // lblModelGuide
            //
            this.lblModelGuide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModelGuide.Location = new System.Drawing.Point(12, 56);
            this.lblModelGuide.Name = "lblModelGuide";
            this.lblModelGuide.Size = new System.Drawing.Size(420, 32);
            this.lblModelGuide.TabIndex = 1;
            this.lblModelGuide.Text = "AI 클라이언트(MCP)가 보내는 요청을 뷰어 명령으로 실행하는 예제입니다.\r\n모델을 열고 서버를 시작한 뒤 AI 클라이언트에 주소를 등록하세요.";
            //
            // btnOpenModel
            //
            this.btnOpenModel.Location = new System.Drawing.Point(12, 22);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(120, 28);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "모델 열기";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            //
            // lblStatus
            //
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(8, 770);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(444, 22);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // FrmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.Text = "VIZCore3DX.NET.Command.Mcp";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpLog.ResumeLayout(false);
            this.grpLog.PerformLayout();
            this.grpServer.ResumeLayout(false);
            this.grpServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.grpModel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Label lblModelGuide;
        private System.Windows.Forms.GroupBox grpServer;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox chkReadOnlyOnly;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.TextBox txtRegister;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Label lblStatus;
    }
}
