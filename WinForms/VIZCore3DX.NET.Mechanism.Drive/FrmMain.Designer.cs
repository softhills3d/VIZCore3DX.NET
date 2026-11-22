namespace VIZCore3DX.NET.Mechanism.Drive
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
            this.dgvJoints = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoupling = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDrive = new System.Windows.Forms.GroupBox();
            this.chkGuide = new System.Windows.Forms.CheckBox();
            this.chkSnap = new System.Windows.Forms.CheckBox();
            this.btnStopAutoDrive = new System.Windows.Forms.Button();
            this.btnAutoDrive = new System.Windows.Forms.Button();
            this.btnResetPose = new System.Windows.Forms.Button();
            this.btnSetValue = new System.Windows.Forms.Button();
            this.numValue = new System.Windows.Forms.NumericUpDown();
            this.lblValue = new System.Windows.Forms.Label();
            this.chkDriveMode = new System.Windows.Forms.CheckBox();
            this.grpDefine = new System.Windows.Forms.GroupBox();
            this.lblDefineHint = new System.Windows.Forms.Label();
            this.btnDefine = new System.Windows.Forms.Button();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJoints)).BeginInit();
            this.grpDrive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpResult);
            this.splitContainer1.Panel1.Controls.Add(this.grpDrive);
            this.splitContainer1.Panel1.Controls.Add(this.grpDefine);
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
            this.grpResult.Controls.Add(this.dgvJoints);
            this.grpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResult.Location = new System.Drawing.Point(8, 342);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(344, 368);
            this.grpResult.TabIndex = 3;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "4. 결과";
            //
            // dgvJoints
            //
            this.dgvJoints.AllowUserToAddRows = false;
            this.dgvJoints.AllowUserToDeleteRows = false;
            this.dgvJoints.AllowUserToResizeRows = false;
            this.dgvJoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvJoints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colParts,
            this.colValue,
            this.colCoupling});
            this.dgvJoints.Location = new System.Drawing.Point(12, 22);
            this.dgvJoints.MultiSelect = false;
            this.dgvJoints.Name = "dgvJoints";
            this.dgvJoints.ReadOnly = true;
            this.dgvJoints.RowHeadersVisible = false;
            this.dgvJoints.RowTemplate.Height = 23;
            this.dgvJoints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJoints.Size = new System.Drawing.Size(320, 334);
            this.dgvJoints.TabIndex = 0;
            //
            // colName
            //
            this.colName.FillWeight = 110F;
            this.colName.HeaderText = "조인트";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            //
            // colParts
            //
            this.colParts.FillWeight = 40F;
            this.colParts.HeaderText = "부품";
            this.colParts.Name = "colParts";
            this.colParts.ReadOnly = true;
            //
            // colValue
            //
            this.colValue.FillWeight = 60F;
            this.colValue.HeaderText = "값(°)";
            this.colValue.Name = "colValue";
            this.colValue.ReadOnly = true;
            //
            // colCoupling
            //
            this.colCoupling.FillWeight = 130F;
            this.colCoupling.HeaderText = "따라가는 축 × 비율";
            this.colCoupling.Name = "colCoupling";
            this.colCoupling.ReadOnly = true;
            //
            // grpDrive
            //
            this.grpDrive.Controls.Add(this.chkGuide);
            this.grpDrive.Controls.Add(this.chkSnap);
            this.grpDrive.Controls.Add(this.btnStopAutoDrive);
            this.grpDrive.Controls.Add(this.btnAutoDrive);
            this.grpDrive.Controls.Add(this.btnResetPose);
            this.grpDrive.Controls.Add(this.btnSetValue);
            this.grpDrive.Controls.Add(this.numValue);
            this.grpDrive.Controls.Add(this.lblValue);
            this.grpDrive.Controls.Add(this.chkDriveMode);
            this.grpDrive.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDrive.Location = new System.Drawing.Point(8, 200);
            this.grpDrive.Name = "grpDrive";
            this.grpDrive.Size = new System.Drawing.Size(344, 142);
            this.grpDrive.TabIndex = 2;
            this.grpDrive.TabStop = false;
            this.grpDrive.Text = "3. 구동";
            //
            // chkGuide
            //
            this.chkGuide.AutoSize = true;
            this.chkGuide.Checked = true;
            this.chkGuide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGuide.Location = new System.Drawing.Point(150, 114);
            this.chkGuide.Name = "chkGuide";
            this.chkGuide.Size = new System.Drawing.Size(126, 16);
            this.chkGuide.TabIndex = 8;
            this.chkGuide.Text = "축·현재 값 표시";
            this.chkGuide.UseVisualStyleBackColor = true;
            this.chkGuide.CheckedChanged += new System.EventHandler(this.chkOption_CheckedChanged);
            //
            // chkSnap
            //
            this.chkSnap.AutoSize = true;
            this.chkSnap.Location = new System.Drawing.Point(12, 114);
            this.chkSnap.Name = "chkSnap";
            this.chkSnap.Size = new System.Drawing.Size(108, 16);
            this.chkSnap.TabIndex = 7;
            this.chkSnap.Text = "끌기 15° 스냅";
            this.chkSnap.UseVisualStyleBackColor = true;
            this.chkSnap.CheckedChanged += new System.EventHandler(this.chkOption_CheckedChanged);
            //
            // btnStopAutoDrive
            //
            this.btnStopAutoDrive.Location = new System.Drawing.Point(138, 80);
            this.btnStopAutoDrive.Name = "btnStopAutoDrive";
            this.btnStopAutoDrive.Size = new System.Drawing.Size(120, 23);
            this.btnStopAutoDrive.TabIndex = 6;
            this.btnStopAutoDrive.Text = "자동 구동 정지";
            this.btnStopAutoDrive.UseVisualStyleBackColor = true;
            this.btnStopAutoDrive.Click += new System.EventHandler(this.btnStopAutoDrive_Click);
            //
            // btnAutoDrive
            //
            this.btnAutoDrive.Location = new System.Drawing.Point(12, 80);
            this.btnAutoDrive.Name = "btnAutoDrive";
            this.btnAutoDrive.Size = new System.Drawing.Size(120, 23);
            this.btnAutoDrive.TabIndex = 5;
            this.btnAutoDrive.Text = "자동 구동 (반복)";
            this.btnAutoDrive.UseVisualStyleBackColor = true;
            this.btnAutoDrive.Click += new System.EventHandler(this.btnAutoDrive_Click);
            //
            // btnResetPose
            //
            this.btnResetPose.Location = new System.Drawing.Point(238, 50);
            this.btnResetPose.Name = "btnResetPose";
            this.btnResetPose.Size = new System.Drawing.Size(94, 23);
            this.btnResetPose.TabIndex = 4;
            this.btnResetPose.Text = "처음 자세로";
            this.btnResetPose.UseVisualStyleBackColor = true;
            this.btnResetPose.Click += new System.EventHandler(this.btnResetPose_Click);
            //
            // btnSetValue
            //
            this.btnSetValue.Location = new System.Drawing.Point(150, 50);
            this.btnSetValue.Name = "btnSetValue";
            this.btnSetValue.Size = new System.Drawing.Size(82, 23);
            this.btnSetValue.TabIndex = 3;
            this.btnSetValue.Text = "값 지정";
            this.btnSetValue.UseVisualStyleBackColor = true;
            this.btnSetValue.Click += new System.EventHandler(this.btnSetValue_Click);
            //
            // numValue
            //
            this.numValue.DecimalPlaces = 1;
            this.numValue.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numValue.Location = new System.Drawing.Point(64, 51);
            this.numValue.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numValue.Minimum = new decimal(new int[] {
            3600,
            0,
            0,
            -2147483648});
            this.numValue.Name = "numValue";
            this.numValue.Size = new System.Drawing.Size(80, 21);
            this.numValue.TabIndex = 2;
            this.numValue.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            //
            // lblValue
            //
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(12, 55);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(46, 12);
            this.lblValue.TabIndex = 1;
            this.lblValue.Text = "값 (°)";
            //
            // chkDriveMode
            //
            this.chkDriveMode.AutoSize = true;
            this.chkDriveMode.Location = new System.Drawing.Point(12, 24);
            this.chkDriveMode.Name = "chkDriveMode";
            this.chkDriveMode.Size = new System.Drawing.Size(280, 16);
            this.chkDriveMode.TabIndex = 0;
            this.chkDriveMode.Text = "구동 모드 (뷰에서 부품을 잡아 돌립니다)";
            this.chkDriveMode.UseVisualStyleBackColor = true;
            this.chkDriveMode.CheckedChanged += new System.EventHandler(this.chkDriveMode_CheckedChanged);
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
            this.lblDefineHint.Text = "축(Type = Shaft)마다 회전 조인트를 만들고,\r\n기어의 Teeth·Mate 속성으로 기어 연동을 겁니다.";
            //
            // btnDefine
            //
            this.btnDefine.Location = new System.Drawing.Point(12, 24);
            this.btnDefine.Name = "btnDefine";
            this.btnDefine.Size = new System.Drawing.Size(180, 23);
            this.btnDefine.TabIndex = 0;
            this.btnDefine.Text = "속성으로 조인트·연동 정의";
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
            this.btnClear.Text = "구동 끝내고 정의 지우기";
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
            // FrmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.Mechanism.Drive";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJoints)).EndInit();
            this.grpDrive.ResumeLayout(false);
            this.grpDrive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).EndInit();
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
        private System.Windows.Forms.GroupBox grpDrive;
        private System.Windows.Forms.CheckBox chkDriveMode;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.NumericUpDown numValue;
        private System.Windows.Forms.Button btnSetValue;
        private System.Windows.Forms.Button btnResetPose;
        private System.Windows.Forms.Button btnAutoDrive;
        private System.Windows.Forms.Button btnStopAutoDrive;
        private System.Windows.Forms.CheckBox chkSnap;
        private System.Windows.Forms.CheckBox chkGuide;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.DataGridView dgvJoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoupling;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStatus;
    }
}
