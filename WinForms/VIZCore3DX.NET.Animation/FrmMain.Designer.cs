namespace VIZCore3DX.NET.Animation
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
            this.groupExport = new System.Windows.Forms.GroupBox();
            this.lblExportStatus = new System.Windows.Forms.Label();
            this.tlpExport = new System.Windows.Forms.TableLayoutPanel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnStopExport = new System.Windows.Forms.Button();
            this.btnOutputFolder = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.txtFilePrefix = new System.Windows.Forms.TextBox();
            this.lblFilePrefix = new System.Windows.Forms.Label();
            this.numFps = new System.Windows.Forms.NumericUpDown();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.lblFps = new System.Windows.Forms.Label();
            this.tlpPlayback = new System.Windows.Forms.TableLayoutPanel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblAnimationInfo = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupExport.SuspendLayout();
            this.tlpExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFps)).BeginInit();
            this.tlpPlayback.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupExport);
            this.splitContainer1.Panel1.Controls.Add(this.tlpPlayback);
            this.splitContainer1.Panel1.Controls.Add(this.lblAnimationInfo);
            this.splitContainer1.Panel1.Controls.Add(this.btnOpenModel);
            this.splitContainer1.Panel1MinSize = 260;
            this.splitContainer1.Size = new System.Drawing.Size(1280, 760);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupExport
            // 
            this.groupExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupExport.Controls.Add(this.lblExportStatus);
            this.groupExport.Controls.Add(this.tlpExport);
            this.groupExport.Controls.Add(this.btnOutputFolder);
            this.groupExport.Controls.Add(this.txtOutputFolder);
            this.groupExport.Controls.Add(this.lblOutputFolder);
            this.groupExport.Controls.Add(this.txtFilePrefix);
            this.groupExport.Controls.Add(this.lblFilePrefix);
            this.groupExport.Controls.Add(this.numFps);
            this.groupExport.Controls.Add(this.lblFps);
            this.groupExport.Controls.Add(this.cbFormat);
            this.groupExport.Controls.Add(this.lblFormat);
            this.groupExport.Location = new System.Drawing.Point(12, 136);
            this.groupExport.Name = "groupExport";
            this.groupExport.Size = new System.Drawing.Size(296, 255);
            this.groupExport.TabIndex = 4;
            this.groupExport.TabStop = false;
            this.groupExport.Text = "내보내기";
            // 
            // lblExportStatus
            // 
            this.lblExportStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExportStatus.AutoEllipsis = true;
            this.lblExportStatus.Location = new System.Drawing.Point(12, 219);
            this.lblExportStatus.Name = "lblExportStatus";
            this.lblExportStatus.Size = new System.Drawing.Size(272, 24);
            this.lblExportStatus.TabIndex = 8;
            this.lblExportStatus.Text = "상태 : 대기";
            this.lblExportStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpExport
            // 
            this.tlpExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpExport.ColumnCount = 2;
            this.tlpExport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpExport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpExport.Controls.Add(this.btnExport, 0, 0);
            this.tlpExport.Controls.Add(this.btnStopExport, 1, 0);
            this.tlpExport.Location = new System.Drawing.Point(9, 176);
            this.tlpExport.Name = "tlpExport";
            this.tlpExport.RowCount = 1;
            this.tlpExport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpExport.Size = new System.Drawing.Size(278, 34);
            this.tlpExport.TabIndex = 7;
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Location = new System.Drawing.Point(3, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(133, 28);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "내보내기";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnStopExport
            // 
            this.btnStopExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStopExport.Enabled = false;
            this.btnStopExport.Location = new System.Drawing.Point(142, 3);
            this.btnStopExport.Name = "btnStopExport";
            this.btnStopExport.Size = new System.Drawing.Size(133, 28);
            this.btnStopExport.TabIndex = 1;
            this.btnStopExport.Text = "중지";
            this.btnStopExport.UseVisualStyleBackColor = true;
            this.btnStopExport.Click += new System.EventHandler(this.btnStopExport_Click);
            // 
            // btnOutputFolder
            // 
            this.btnOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputFolder.Location = new System.Drawing.Point(234, 144);
            this.btnOutputFolder.Name = "btnOutputFolder";
            this.btnOutputFolder.Size = new System.Drawing.Size(50, 23);
            this.btnOutputFolder.TabIndex = 6;
            this.btnOutputFolder.Text = "...";
            this.btnOutputFolder.UseVisualStyleBackColor = true;
            this.btnOutputFolder.Click += new System.EventHandler(this.btnOutputFolder_Click);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFolder.Location = new System.Drawing.Point(12, 145);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.ReadOnly = true;
            this.txtOutputFolder.Size = new System.Drawing.Size(216, 21);
            this.txtOutputFolder.TabIndex = 5;
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Location = new System.Drawing.Point(12, 127);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(57, 12);
            this.lblOutputFolder.TabIndex = 4;
            this.lblOutputFolder.Text = "출력 폴더";
            // 
            // txtFilePrefix
            // 
            this.txtFilePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePrefix.Location = new System.Drawing.Point(95, 92);
            this.txtFilePrefix.Name = "txtFilePrefix";
            this.txtFilePrefix.Size = new System.Drawing.Size(189, 21);
            this.txtFilePrefix.TabIndex = 3;
            this.txtFilePrefix.Text = "frame";
            // 
            // lblFilePrefix
            // 
            this.lblFilePrefix.AutoSize = true;
            this.lblFilePrefix.Location = new System.Drawing.Point(12, 96);
            this.lblFilePrefix.Name = "lblFilePrefix";
            this.lblFilePrefix.Size = new System.Drawing.Size(69, 12);
            this.lblFilePrefix.TabIndex = 2;
            this.lblFilePrefix.Text = "파일 접두어";
            // 
            // numFps
            // 
            this.numFps.Location = new System.Drawing.Point(95, 59);
            this.numFps.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numFps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFps.Name = "numFps";
            this.numFps.Size = new System.Drawing.Size(80, 21);
            this.numFps.TabIndex = 1;
            this.numFps.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // cbFormat
            // 
            this.cbFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Items.AddRange(new object[] {
            "PNG (프레임 시퀀스)",
            "MP4 (동영상)"});
            this.cbFormat.Location = new System.Drawing.Point(95, 26);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(189, 20);
            this.cbFormat.TabIndex = 9;
            this.cbFormat.SelectedIndexChanged += new System.EventHandler(this.cbFormat_SelectedIndexChanged);
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(12, 30);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(29, 12);
            this.lblFormat.TabIndex = 10;
            this.lblFormat.Text = "형식";
            // 
            // lblFps
            // 
            this.lblFps.AutoSize = true;
            this.lblFps.Location = new System.Drawing.Point(12, 63);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(28, 12);
            this.lblFps.TabIndex = 0;
            this.lblFps.Text = "FPS";
            // 
            // tlpPlayback
            // 
            this.tlpPlayback.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPlayback.ColumnCount = 3;
            this.tlpPlayback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpPlayback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpPlayback.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpPlayback.Controls.Add(this.btnPlay, 0, 0);
            this.tlpPlayback.Controls.Add(this.btnPause, 1, 0);
            this.tlpPlayback.Controls.Add(this.btnStop, 2, 0);
            this.tlpPlayback.Location = new System.Drawing.Point(9, 93);
            this.tlpPlayback.Name = "tlpPlayback";
            this.tlpPlayback.RowCount = 1;
            this.tlpPlayback.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlayback.Size = new System.Drawing.Size(302, 38);
            this.tlpPlayback.TabIndex = 2;
            // 
            // btnPlay
            // 
            this.btnPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlay.Location = new System.Drawing.Point(3, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(94, 32);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPause.Location = new System.Drawing.Point(103, 3);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(94, 32);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Location = new System.Drawing.Point(203, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(96, 32);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblAnimationInfo
            // 
            this.lblAnimationInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnimationInfo.AutoEllipsis = true;
            this.lblAnimationInfo.Location = new System.Drawing.Point(12, 52);
            this.lblAnimationInfo.Name = "lblAnimationInfo";
            this.lblAnimationInfo.Size = new System.Drawing.Size(296, 36);
            this.lblAnimationInfo.TabIndex = 1;
            this.lblAnimationInfo.Text = "애니메이션 : 없음";
            this.lblAnimationInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenModel.Location = new System.Drawing.Point(12, 12);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(296, 32);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "Open Model";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.Text = "VIZCore3DX.NET.Animation";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupExport.ResumeLayout(false);
            this.groupExport.PerformLayout();
            this.tlpExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFps)).EndInit();
            this.tlpPlayback.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.TableLayoutPanel tlpPlayback;
        private System.Windows.Forms.Label lblAnimationInfo;
        private System.Windows.Forms.GroupBox groupExport;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.NumericUpDown numFps;
        private System.Windows.Forms.Label lblFilePrefix;
        private System.Windows.Forms.TextBox txtFilePrefix;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnOutputFolder;
        private System.Windows.Forms.TableLayoutPanel tlpExport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnStopExport;
        private System.Windows.Forms.Label lblExportStatus;
        private System.Windows.Forms.ComboBox cbFormat;
        private System.Windows.Forms.Label lblFormat;
    }
}

