namespace VIZCore3DX.NET.Command.Chat
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
            this.grpChat = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.grpProvider = new System.Windows.Forms.GroupBox();
            this.chkReadOnlyOnly = new System.Windows.Forms.CheckBox();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtEndpoint = new System.Windows.Forms.TextBox();
            this.lblEndpoint = new System.Windows.Forms.Label();
            this.cmbProvider = new System.Windows.Forms.ComboBox();
            this.lblProvider = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelGuide = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpChat.SuspendLayout();
            this.grpProvider.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpChat);
            this.splitContainer1.Panel1.Controls.Add(this.grpProvider);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 800);
            this.splitContainer1.SplitterDistance = 460;
            this.splitContainer1.TabIndex = 0;
            //
            // grpChat
            //
            this.grpChat.Controls.Add(this.btnReset);
            this.grpChat.Controls.Add(this.btnSend);
            this.grpChat.Controls.Add(this.txtInput);
            this.grpChat.Controls.Add(this.txtChat);
            this.grpChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChat.Location = new System.Drawing.Point(8, 274);
            this.grpChat.Name = "grpChat";
            this.grpChat.Size = new System.Drawing.Size(444, 496);
            this.grpChat.TabIndex = 2;
            this.grpChat.TabStop = false;
            this.grpChat.Text = "3. 대화";
            //
            // btnReset
            //
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.Location = new System.Drawing.Point(138, 456);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 28);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "대화 초기화";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            //
            // btnSend
            //
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSend.Location = new System.Drawing.Point(12, 456);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(120, 28);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "보내기";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            //
            // txtInput
            //
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(12, 386);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(420, 60);
            this.txtInput.TabIndex = 1;
            //
            // txtChat
            //
            this.txtChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChat.BackColor = System.Drawing.SystemColors.Window;
            this.txtChat.Location = new System.Drawing.Point(12, 22);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(420, 356);
            this.txtChat.TabIndex = 0;
            //
            // grpProvider
            //
            this.grpProvider.Controls.Add(this.chkReadOnlyOnly);
            this.grpProvider.Controls.Add(this.txtApiKey);
            this.grpProvider.Controls.Add(this.lblApiKey);
            this.grpProvider.Controls.Add(this.txtModel);
            this.grpProvider.Controls.Add(this.lblModel);
            this.grpProvider.Controls.Add(this.txtEndpoint);
            this.grpProvider.Controls.Add(this.lblEndpoint);
            this.grpProvider.Controls.Add(this.cmbProvider);
            this.grpProvider.Controls.Add(this.lblProvider);
            this.grpProvider.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpProvider.Location = new System.Drawing.Point(8, 104);
            this.grpProvider.Name = "grpProvider";
            this.grpProvider.Size = new System.Drawing.Size(444, 170);
            this.grpProvider.TabIndex = 1;
            this.grpProvider.TabStop = false;
            this.grpProvider.Text = "2. AI 연결";
            //
            // chkReadOnlyOnly
            //
            this.chkReadOnlyOnly.AutoSize = true;
            this.chkReadOnlyOnly.Location = new System.Drawing.Point(80, 138);
            this.chkReadOnlyOnly.Name = "chkReadOnlyOnly";
            this.chkReadOnlyOnly.Size = new System.Drawing.Size(208, 16);
            this.chkReadOnlyOnly.TabIndex = 8;
            this.chkReadOnlyOnly.Text = "조회 명령만 허용 (변경 명령 숨김)";
            this.chkReadOnlyOnly.UseVisualStyleBackColor = true;
            //
            // txtApiKey
            //
            this.txtApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApiKey.Location = new System.Drawing.Point(80, 106);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(352, 21);
            this.txtApiKey.TabIndex = 7;
            this.txtApiKey.UseSystemPasswordChar = true;
            //
            // lblApiKey
            //
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Location = new System.Drawing.Point(12, 110);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(39, 12);
            this.lblApiKey.TabIndex = 6;
            this.lblApiKey.Text = "API 키";
            //
            // txtModel
            //
            this.txtModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModel.Location = new System.Drawing.Point(80, 78);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(352, 21);
            this.txtModel.TabIndex = 5;
            //
            // lblModel
            //
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(12, 82);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(29, 12);
            this.lblModel.TabIndex = 4;
            this.lblModel.Text = "모델";
            //
            // txtEndpoint
            //
            this.txtEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndpoint.Location = new System.Drawing.Point(80, 50);
            this.txtEndpoint.Name = "txtEndpoint";
            this.txtEndpoint.Size = new System.Drawing.Size(352, 21);
            this.txtEndpoint.TabIndex = 3;
            //
            // lblEndpoint
            //
            this.lblEndpoint.AutoSize = true;
            this.lblEndpoint.Location = new System.Drawing.Point(12, 54);
            this.lblEndpoint.Name = "lblEndpoint";
            this.lblEndpoint.Size = new System.Drawing.Size(29, 12);
            this.lblEndpoint.TabIndex = 2;
            this.lblEndpoint.Text = "주소";
            //
            // cmbProvider
            //
            this.cmbProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvider.FormattingEnabled = true;
            this.cmbProvider.Location = new System.Drawing.Point(80, 22);
            this.cmbProvider.Name = "cmbProvider";
            this.cmbProvider.Size = new System.Drawing.Size(200, 20);
            this.cmbProvider.TabIndex = 1;
            this.cmbProvider.SelectedIndexChanged += new System.EventHandler(this.cmbProvider_SelectedIndexChanged);
            //
            // lblProvider
            //
            this.lblProvider.AutoSize = true;
            this.lblProvider.Location = new System.Drawing.Point(12, 26);
            this.lblProvider.Name = "lblProvider";
            this.lblProvider.Size = new System.Drawing.Size(41, 12);
            this.lblProvider.TabIndex = 0;
            this.lblProvider.Text = "공급자";
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
            this.lblModelGuide.Text = "AI(LLM)와 대화하며 뷰어를 조작하는 예제입니다.\r\n모델을 열고 AI 연결 정보를 입력한 뒤 요청을 보내 보세요.";
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
            this.Text = "VIZCore3DX.NET.Command.Chat";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpChat.ResumeLayout(false);
            this.grpChat.PerformLayout();
            this.grpProvider.ResumeLayout(false);
            this.grpProvider.PerformLayout();
            this.grpModel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Label lblModelGuide;
        private System.Windows.Forms.GroupBox grpProvider;
        private System.Windows.Forms.Label lblProvider;
        private System.Windows.Forms.ComboBox cmbProvider;
        private System.Windows.Forms.Label lblEndpoint;
        private System.Windows.Forms.TextBox txtEndpoint;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.CheckBox chkReadOnlyOnly;
        private System.Windows.Forms.GroupBox grpChat;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblStatus;
    }
}
