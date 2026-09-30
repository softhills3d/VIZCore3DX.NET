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
            this.groupVideoExport = new System.Windows.Forms.GroupBox();
            this.lblVideoInfo = new System.Windows.Forms.Label();
            this.tlpVideoExport = new System.Windows.Forms.TableLayoutPanel();
            this.btnRecordVideo = new System.Windows.Forms.Button();
            this.btnStopVideo = new System.Windows.Forms.Button();
            this.lblVideoStatus = new System.Windows.Forms.Label();
            this.groupFrameExport = new System.Windows.Forms.GroupBox();
            this.lblFrameStatus = new System.Windows.Forms.Label();
            this.tlpFrameExport = new System.Windows.Forms.TableLayoutPanel();
            this.btnExportFrames = new System.Windows.Forms.Button();
            this.btnStopFrameExport = new System.Windows.Forms.Button();
            this.btnOutputFolder = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.txtFilePrefix = new System.Windows.Forms.TextBox();
            this.lblFilePrefix = new System.Windows.Forms.Label();
            this.numFps = new System.Windows.Forms.NumericUpDown();
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
            this.groupVideoExport.SuspendLayout();
            this.tlpVideoExport.SuspendLayout();
            this.groupFrameExport.SuspendLayout();
            this.tlpFrameExport.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupFrameExport);
            this.splitContainer1.Panel1.Controls.Add(this.groupVideoExport);
            this.splitContainer1.Panel1.Controls.Add(this.tlpPlayback);
            this.splitContainer1.Panel1.Controls.Add(this.lblAnimationInfo);
            this.splitContainer1.Panel1.Controls.Add(this.btnOpenModel);
            this.splitContainer1.Panel1MinSize = 260;
            this.splitContainer1.Size = new System.Drawing.Size(1280, 760);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupVideoExport
            // 
            this.groupVideoExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupVideoExport.Controls.Add(this.lblVideoStatus);
            this.groupVideoExport.Controls.Add(this.tlpVideoExport);
            this.groupVideoExport.Controls.Add(this.lblVideoInfo);
            this.groupVideoExport.Location = new System.Drawing.Point(12, 136);
            this.groupVideoExport.Name = "groupVideoExport";
            this.groupVideoExport.Size = new System.Drawing.Size(296, 132);
            this.groupVideoExport.TabIndex = 3;
            this.groupVideoExport.TabStop = false;
            this.groupVideoExport.Text = "동영상 저장 (MP4)";
            // 
            // lblVideoInfo
            // 
            this.lblVideoInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVideoInfo.Location = new System.Drawing.Point(12, 22);
            this.lblVideoInfo.Name = "lblVideoInfo";
            this.lblVideoInfo.Size = new System.Drawing.Size(272, 30);
            this.lblVideoInfo.TabIndex = 0;
            this.lblVideoInfo.Text = "애니메이션을 처음부터 끝까지 재생하며\r\n3D 화면을 MP4 파일로 녹화합니다.";
            this.lblVideoInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpVideoExport
            // 
            this.tlpVideoExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpVideoExport.ColumnCount = 2;
            this.tlpVideoExport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVideoExport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVideoExport.Controls.Add(this.btnRecordVideo, 0, 0);
            this.tlpVideoExport.Controls.Add(this.btnStopVideo, 1, 0);
            this.tlpVideoExport.Location = new System.Drawing.Point(9, 58);
            this.tlpVideoExport.Name = "tlpVideoExport";
            this.tlpVideoExport.RowCount = 1;
            this.tlpVideoExport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVideoExport.Size = new System.Drawing.Size(278, 34);
            this.tlpVideoExport.TabIndex = 1;
            // 
            // btnRecordVideo
            // 
            this.btnRecordVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecordVideo.Location = new System.Drawing.Point(3, 3);
            this.btnRecordVideo.Name = "btnRecordVideo";
            this.btnRecordVideo.Size = new System.Drawing.Size(133, 28);
            this.btnRecordVideo.TabIndex = 0;
            this.btnRecordVideo.Text = "MP4 녹화 저장";
            this.btnRecordVideo.UseVisualStyleBackColor = true;
            this.btnRecordVideo.Click += new System.EventHandler(this.btnRecordVideo_Click);
            // 
            // btnStopVideo
            // 
            this.btnStopVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStopVideo.Enabled = false;
            this.btnStopVideo.Location = new System.Drawing.Point(142, 3);
            this.btnStopVideo.Name = "btnStopVideo";
            this.btnStopVideo.Size = new System.Drawing.Size(133, 28);
            this.btnStopVideo.TabIndex = 1;
            this.btnStopVideo.Text = "녹화 중지";
            this.btnStopVideo.UseVisualStyleBackColor = true;
            this.btnStopVideo.Click += new System.EventHandler(this.btnStopVideo_Click);
            // 
            // lblVideoStatus
            // 
            this.lblVideoStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVideoStatus.AutoEllipsis = true;
            this.lblVideoStatus.Location = new System.Drawing.Point(12, 98);
            this.lblVideoStatus.Name = "lblVideoStatus";
            this.lblVideoStatus.Size = new System.Drawing.Size(272, 24);
            this.lblVideoStatus.TabIndex = 2;
            this.lblVideoStatus.Text = "상태 : 대기";
            this.lblVideoStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupFrameExport
            // 
            this.groupFrameExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupFrameExport.Controls.Add(this.lblFrameStatus);
            this.groupFrameExport.Controls.Add(this.tlpFrameExport);
            this.groupFrameExport.Controls.Add(this.btnOutputFolder);
            this.groupFrameExport.Controls.Add(this.txtOutputFolder);
            this.groupFrameExport.Controls.Add(this.lblOutputFolder);
            this.groupFrameExport.Controls.Add(this.txtFilePrefix);
            this.groupFrameExport.Controls.Add(this.lblFilePrefix);
            this.groupFrameExport.Controls.Add(this.numFps);
            this.groupFrameExport.Controls.Add(this.lblFps);
            this.groupFrameExport.Location = new System.Drawing.Point(12, 276);
            this.groupFrameExport.Name = "groupFrameExport";
            this.groupFrameExport.Size = new System.Drawing.Size(296, 222);
            this.groupFrameExport.TabIndex = 4;
            this.groupFrameExport.TabStop = false;
            this.groupFrameExport.Text = "프레임 시퀀스 내보내기 (PNG)";
            // 
            // lblFrameStatus
            // 
            this.lblFrameStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFrameStatus.AutoEllipsis = true;
            this.lblFrameStatus.Location = new System.Drawing.Point(12, 186);
            this.lblFrameStatus.Name = "lblFrameStatus";
            this.lblFrameStatus.Size = new System.Drawing.Size(272, 24);
            this.lblFrameStatus.TabIndex = 8;
            this.lblFrameStatus.Text = "상태 : 대기";
            this.lblFrameStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpFrameExport
            // 
            this.tlpFrameExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFrameExport.ColumnCount = 2;
            this.tlpFrameExport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFrameExport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFrameExport.Controls.Add(this.btnExportFrames, 0, 0);
            this.tlpFrameExport.Controls.Add(this.btnStopFrameExport, 1, 0);
            this.tlpFrameExport.Location = new System.Drawing.Point(9, 143);
            this.tlpFrameExport.Name = "tlpFrameExport";
            this.tlpFrameExport.RowCount = 1;
            this.tlpFrameExport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFrameExport.Size = new System.Drawing.Size(278, 34);
            this.tlpFrameExport.TabIndex = 7;
            // 
            // btnExportFrames
            // 
            this.btnExportFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportFrames.Location = new System.Drawing.Point(3, 3);
            this.btnExportFrames.Name = "btnExportFrames";
            this.btnExportFrames.Size = new System.Drawing.Size(133, 28);
            this.btnExportFrames.TabIndex = 0;
            this.btnExportFrames.Text = "내보내기";
            this.btnExportFrames.UseVisualStyleBackColor = true;
            this.btnExportFrames.Click += new System.EventHandler(this.btnExportFrames_Click);
            // 
            // btnStopFrameExport
            // 
            this.btnStopFrameExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStopFrameExport.Enabled = false;
            this.btnStopFrameExport.Location = new System.Drawing.Point(142, 3);
            this.btnStopFrameExport.Name = "btnStopFrameExport";
            this.btnStopFrameExport.Size = new System.Drawing.Size(133, 28);
            this.btnStopFrameExport.TabIndex = 1;
            this.btnStopFrameExport.Text = "중지";
            this.btnStopFrameExport.UseVisualStyleBackColor = true;
            this.btnStopFrameExport.Click += new System.EventHandler(this.btnStopFrameExport_Click);
            // 
            // btnOutputFolder
            // 
            this.btnOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputFolder.Location = new System.Drawing.Point(234, 111);
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
            this.txtOutputFolder.Location = new System.Drawing.Point(12, 112);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.ReadOnly = true;
            this.txtOutputFolder.Size = new System.Drawing.Size(216, 21);
            this.txtOutputFolder.TabIndex = 5;
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Location = new System.Drawing.Point(12, 94);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(57, 12);
            this.lblOutputFolder.TabIndex = 4;
            this.lblOutputFolder.Text = "출력 폴더";
            // 
            // txtFilePrefix
            // 
            this.txtFilePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePrefix.Location = new System.Drawing.Point(95, 59);
            this.txtFilePrefix.Name = "txtFilePrefix";
            this.txtFilePrefix.Size = new System.Drawing.Size(189, 21);
            this.txtFilePrefix.TabIndex = 3;
            this.txtFilePrefix.Text = "frame";
            // 
            // lblFilePrefix
            // 
            this.lblFilePrefix.AutoSize = true;
            this.lblFilePrefix.Location = new System.Drawing.Point(12, 63);
            this.lblFilePrefix.Name = "lblFilePrefix";
            this.lblFilePrefix.Size = new System.Drawing.Size(69, 12);
            this.lblFilePrefix.TabIndex = 2;
            this.lblFilePrefix.Text = "파일 접두어";
            // 
            // numFps
            // 
            this.numFps.Location = new System.Drawing.Point(95, 26);
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
            // lblFps
            // 
            this.lblFps.AutoSize = true;
            this.lblFps.Location = new System.Drawing.Point(12, 30);
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
            this.groupVideoExport.ResumeLayout(false);
            this.tlpVideoExport.ResumeLayout(false);
            this.groupFrameExport.ResumeLayout(false);
            this.groupFrameExport.PerformLayout();
            this.tlpFrameExport.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupVideoExport;
        private System.Windows.Forms.Label lblVideoInfo;
        private System.Windows.Forms.TableLayoutPanel tlpVideoExport;
        private System.Windows.Forms.Button btnRecordVideo;
        private System.Windows.Forms.Button btnStopVideo;
        private System.Windows.Forms.Label lblVideoStatus;
        private System.Windows.Forms.GroupBox groupFrameExport;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.NumericUpDown numFps;
        private System.Windows.Forms.Label lblFilePrefix;
        private System.Windows.Forms.TextBox txtFilePrefix;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnOutputFolder;
        private System.Windows.Forms.TableLayoutPanel tlpFrameExport;
        private System.Windows.Forms.Button btnExportFrames;
        private System.Windows.Forms.Button btnStopFrameExport;
        private System.Windows.Forms.Label lblFrameStatus;
    }
}

