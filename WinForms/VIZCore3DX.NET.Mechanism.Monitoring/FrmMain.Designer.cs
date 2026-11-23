namespace VIZCore3DX.NET.Mechanism.Monitoring
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpTable = new System.Windows.Forms.GroupBox();
            this.lblTableHint = new System.Windows.Forms.Label();
            this.dgvSamples = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpMonitor = new System.Windows.Forms.GroupBox();
            this.chkGuide = new System.Windows.Forms.CheckBox();
            this.chkAllowDrag = new System.Windows.Forms.CheckBox();
            this.chkLoop = new System.Windows.Forms.CheckBox();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.lblInterval = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.grpDefine = new System.Windows.Forms.GroupBox();
            this.lblDefineHint = new System.Windows.Forms.Label();
            this.btnDefine = new System.Windows.Forms.Button();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.timerSamples = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSamples)).BeginInit();
            this.grpMonitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            this.grpDefine.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpTable);
            this.splitContainer1.Panel1.Controls.Add(this.grpMonitor);
            this.splitContainer1.Panel1.Controls.Add(this.grpDefine);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Controls.Add(this.grpCleanup);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 800);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 0;
            //
            // grpTable
            //
            this.grpTable.Controls.Add(this.lblTableHint);
            this.grpTable.Controls.Add(this.dgvSamples);
            this.grpTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTable.Location = new System.Drawing.Point(8, 336);
            this.grpTable.Name = "grpTable";
            this.grpTable.Size = new System.Drawing.Size(344, 374);
            this.grpTable.TabIndex = 3;
            this.grpTable.TabStop = false;
            this.grpTable.Text = "4. 값 표";
            //
            // lblTableHint
            //
            this.lblTableHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTableHint.Location = new System.Drawing.Point(12, 330);
            this.lblTableHint.Name = "lblTableHint";
            this.lblTableHint.Size = new System.Drawing.Size(320, 32);
            this.lblTableHint.TabIndex = 1;
            this.lblTableHint.Text = "실제 설비 값이 오면 이 표 대신 받은 값을 SetValues 에 넣습니다.";
            //
            // dgvSamples
            //
            this.dgvSamples.AllowUserToResizeRows = false;
            this.dgvSamples.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSamples.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSamples.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSamples.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colInput,
            this.colInspection});
            this.dgvSamples.Location = new System.Drawing.Point(12, 22);
            this.dgvSamples.MultiSelect = false;
            this.dgvSamples.Name = "dgvSamples";
            this.dgvSamples.RowHeadersVisible = false;
            this.dgvSamples.RowTemplate.Height = 23;
            this.dgvSamples.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSamples.Size = new System.Drawing.Size(320, 302);
            this.dgvSamples.TabIndex = 0;
            //
            // colTime
            //
            this.colTime.FillWeight = 70F;
            this.colTime.HeaderText = "시각 (s)";
            this.colTime.Name = "colTime";
            //
            // colInput
            //
            this.colInput.FillWeight = 100F;
            this.colInput.HeaderText = "입력축 (°)";
            this.colInput.Name = "colInput";
            //
            // colInspection
            //
            this.colInspection.FillWeight = 100F;
            this.colInspection.HeaderText = "점검창 (mm)";
            this.colInspection.Name = "colInspection";
            //
            // grpMonitor
            //
            this.grpMonitor.Controls.Add(this.chkGuide);
            this.grpMonitor.Controls.Add(this.chkAllowDrag);
            this.grpMonitor.Controls.Add(this.chkLoop);
            this.grpMonitor.Controls.Add(this.numInterval);
            this.grpMonitor.Controls.Add(this.lblInterval);
            this.grpMonitor.Controls.Add(this.btnStop);
            this.grpMonitor.Controls.Add(this.btnStart);
            this.grpMonitor.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMonitor.Location = new System.Drawing.Point(8, 200);
            this.grpMonitor.Name = "grpMonitor";
            this.grpMonitor.Size = new System.Drawing.Size(344, 136);
            this.grpMonitor.TabIndex = 2;
            this.grpMonitor.TabStop = false;
            this.grpMonitor.Text = "3. 관제";
            //
            // chkGuide
            //
            this.chkGuide.AutoSize = true;
            this.chkGuide.Checked = true;
            this.chkGuide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGuide.Location = new System.Drawing.Point(150, 108);
            this.chkGuide.Name = "chkGuide";
            this.chkGuide.Size = new System.Drawing.Size(96, 16);
            this.chkGuide.TabIndex = 6;
            this.chkGuide.Text = "축·범위 표시";
            this.chkGuide.UseVisualStyleBackColor = true;
            this.chkGuide.CheckedChanged += new System.EventHandler(this.chkGuide_CheckedChanged);
            //
            // chkAllowDrag
            //
            this.chkAllowDrag.AutoSize = true;
            this.chkAllowDrag.Location = new System.Drawing.Point(12, 108);
            this.chkAllowDrag.Name = "chkAllowDrag";
            this.chkAllowDrag.Size = new System.Drawing.Size(120, 16);
            this.chkAllowDrag.TabIndex = 5;
            this.chkAllowDrag.Text = "사용자 끌기 허용";
            this.chkAllowDrag.UseVisualStyleBackColor = true;
            this.chkAllowDrag.CheckedChanged += new System.EventHandler(this.chkAllowDrag_CheckedChanged);
            //
            // chkLoop
            //
            this.chkLoop.AutoSize = true;
            this.chkLoop.Checked = true;
            this.chkLoop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLoop.Location = new System.Drawing.Point(12, 84);
            this.chkLoop.Name = "chkLoop";
            this.chkLoop.Size = new System.Drawing.Size(112, 16);
            this.chkLoop.TabIndex = 4;
            this.chkLoop.Text = "끝나면 처음부터";
            this.chkLoop.UseVisualStyleBackColor = true;
            //
            // numInterval
            //
            this.numInterval.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numInterval.Location = new System.Drawing.Point(80, 53);
            this.numInterval.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numInterval.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(80, 21);
            this.numInterval.TabIndex = 3;
            this.numInterval.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numInterval.ValueChanged += new System.EventHandler(this.numInterval_ValueChanged);
            //
            // lblInterval
            //
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(12, 57);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(61, 12);
            this.lblInterval.TabIndex = 2;
            this.lblInterval.Text = "주기 (ms)";
            //
            // btnStop
            //
            this.btnStop.Location = new System.Drawing.Point(138, 24);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "관제 정지";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            //
            // btnStart
            //
            this.btnStart.Location = new System.Drawing.Point(12, 24);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "관제 시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            //
            // grpDefine
            //
            this.grpDefine.Controls.Add(this.lblDefineHint);
            this.grpDefine.Controls.Add(this.btnDefine);
            this.grpDefine.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDefine.Location = new System.Drawing.Point(8, 104);
            this.grpDefine.Name = "grpDefine";
            this.grpDefine.Size = new System.Drawing.Size(344, 96);
            this.grpDefine.TabIndex = 1;
            this.grpDefine.TabStop = false;
            this.grpDefine.Text = "2. 정의";
            //
            // lblDefineHint
            //
            this.lblDefineHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDefineHint.Location = new System.Drawing.Point(12, 54);
            this.lblDefineHint.Name = "lblDefineHint";
            this.lblDefineHint.Size = new System.Drawing.Size(320, 32);
            this.lblDefineHint.TabIndex = 1;
            this.lblDefineHint.Text = "축(Type = Shaft)마다 회전 조인트와 기어 연동을,\r\n점검창(Inspection Cover)에 위로 열리는 직선 조인트를 만듭니다.";
            //
            // btnDefine
            //
            this.btnDefine.Location = new System.Drawing.Point(12, 24);
            this.btnDefine.Name = "btnDefine";
            this.btnDefine.Size = new System.Drawing.Size(180, 23);
            this.btnDefine.TabIndex = 0;
            this.btnDefine.Text = "속성으로 조인트 정의";
            this.btnDefine.UseVisualStyleBackColor = true;
            this.btnDefine.Click += new System.EventHandler(this.btnDefine_Click);
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
            this.lblModelHint.Text = "샘플 모델 Gearbox.vizx (2단 기어 감속기)를 엽니다.\r\n축·기어·키에 Type 속성이 있는 모델이 필요합니다.";
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
            this.btnClear.Location = new System.Drawing.Point(12, 24);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(180, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "관제 끝내고 정의 지우기";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            // timerSamples
            //
            this.timerSamples.Interval = 200;
            this.timerSamples.Tick += new System.EventHandler(this.timerSamples_Tick);
            //
            // FrmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.Mechanism.Monitoring";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSamples)).EndInit();
            this.grpMonitor.ResumeLayout(false);
            this.grpMonitor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            this.grpDefine.ResumeLayout(false);
            this.grpModel.ResumeLayout(false);
            this.grpCleanup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Label lblModelHint;
        private System.Windows.Forms.GroupBox grpDefine;
        private System.Windows.Forms.Button btnDefine;
        private System.Windows.Forms.Label lblDefineHint;
        private System.Windows.Forms.GroupBox grpMonitor;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.CheckBox chkLoop;
        private System.Windows.Forms.CheckBox chkAllowDrag;
        private System.Windows.Forms.CheckBox chkGuide;
        private System.Windows.Forms.GroupBox grpTable;
        private System.Windows.Forms.DataGridView dgvSamples;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspection;
        private System.Windows.Forms.Label lblTableHint;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer timerSamples;
    }
}
