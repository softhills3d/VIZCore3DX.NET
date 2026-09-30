namespace VIZCore3DX.NET.CaptureImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tlpCapture = new System.Windows.Forms.TableLayoutPanel();
            this.btnCaptureAuto = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.groupRenderCapture = new System.Windows.Forms.GroupBox();
            this.lblRenderCaptureHint = new System.Windows.Forms.Label();
            this.chkIncludeOverlay = new System.Windows.Forms.CheckBox();
            this.btnCaptureRender = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lvImage = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgThumb = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tlpCapture.SuspendLayout();
            this.groupRenderCapture.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.lvImage);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupRenderCapture);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1318, 812);
            this.splitContainer1.SplitterDistance = 974;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tlpCapture);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 68);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Capture";
            // 
            // tlpCapture
            // 
            this.tlpCapture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpCapture.ColumnCount = 3;
            this.tlpCapture.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCapture.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCapture.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpCapture.Controls.Add(this.btnCapture, 0, 0);
            this.tlpCapture.Controls.Add(this.btnCaptureAuto, 1, 0);
            this.tlpCapture.Controls.Add(this.btnDelete, 2, 0);
            this.tlpCapture.Location = new System.Drawing.Point(9, 22);
            this.tlpCapture.Name = "tlpCapture";
            this.tlpCapture.RowCount = 1;
            this.tlpCapture.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCapture.Size = new System.Drawing.Size(298, 36);
            this.tlpCapture.TabIndex = 0;
            // 
            // btnCaptureAuto
            // 
            this.btnCaptureAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCaptureAuto.Location = new System.Drawing.Point(102, 3);
            this.btnCaptureAuto.Name = "btnCaptureAuto";
            this.btnCaptureAuto.Size = new System.Drawing.Size(93, 30);
            this.btnCaptureAuto.TabIndex = 1;
            this.btnCaptureAuto.Text = "Auto";
            this.btnCaptureAuto.UseVisualStyleBackColor = true;
            this.btnCaptureAuto.Click += new System.EventHandler(this.btnCaptureAuto_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(201, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCapture.Location = new System.Drawing.Point(3, 3);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(93, 30);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Text = "Current";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // groupRenderCapture
            // 
            this.groupRenderCapture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupRenderCapture.Controls.Add(this.lblRenderCaptureHint);
            this.groupRenderCapture.Controls.Add(this.chkIncludeOverlay);
            this.groupRenderCapture.Controls.Add(this.btnCaptureRender);
            this.groupRenderCapture.Location = new System.Drawing.Point(12, 88);
            this.groupRenderCapture.Name = "groupRenderCapture";
            this.groupRenderCapture.Size = new System.Drawing.Size(316, 90);
            this.groupRenderCapture.TabIndex = 5;
            this.groupRenderCapture.TabStop = false;
            this.groupRenderCapture.Text = "렌더 버퍼 캡처";
            // 
            // lblRenderCaptureHint
            // 
            this.lblRenderCaptureHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRenderCaptureHint.AutoEllipsis = true;
            this.lblRenderCaptureHint.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblRenderCaptureHint.Location = new System.Drawing.Point(12, 62);
            this.lblRenderCaptureHint.Name = "lblRenderCaptureHint";
            this.lblRenderCaptureHint.Size = new System.Drawing.Size(292, 18);
            this.lblRenderCaptureHint.TabIndex = 2;
            this.lblRenderCaptureHint.Text = "창이 가려져 있어도 렌더 버퍼에서 캡처";
            this.lblRenderCaptureHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIncludeOverlay
            // 
            this.chkIncludeOverlay.AutoSize = true;
            this.chkIncludeOverlay.Location = new System.Drawing.Point(136, 31);
            this.chkIncludeOverlay.Name = "chkIncludeOverlay";
            this.chkIncludeOverlay.Size = new System.Drawing.Size(96, 16);
            this.chkIncludeOverlay.TabIndex = 1;
            this.chkIncludeOverlay.Text = "오버레이 포함";
            this.chkIncludeOverlay.UseVisualStyleBackColor = true;
            // 
            // btnCaptureRender
            // 
            this.btnCaptureRender.Location = new System.Drawing.Point(12, 25);
            this.btnCaptureRender.Name = "btnCaptureRender";
            this.btnCaptureRender.Size = new System.Drawing.Size(110, 28);
            this.btnCaptureRender.TabIndex = 0;
            this.btnCaptureRender.Text = "렌더 캡처";
            this.btnCaptureRender.UseVisualStyleBackColor = true;
            this.btnCaptureRender.Click += new System.EventHandler(this.btnCaptureRender_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSelectPath);
            this.groupBox1.Controls.Add(this.btnSaveFile);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 94);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export";
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectPath.Location = new System.Drawing.Point(234, 24);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(70, 23);
            this.btnSelectPath.TabIndex = 2;
            this.btnSelectPath.Text = "Select";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFile.Location = new System.Drawing.Point(12, 55);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(292, 28);
            this.btnSaveFile.TabIndex = 3;
            this.btnSaveFile.Text = "Export";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(12, 25);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(216, 21);
            this.txtPath.TabIndex = 1;
            // 
            // lvImage
            // 
            this.lvImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvImage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvImage.FullRowSelect = true;
            this.lvImage.GridLines = true;
            this.lvImage.HideSelection = false;
            this.lvImage.LargeImageList = this.imgThumb;
            this.lvImage.Location = new System.Drawing.Point(12, 288);
            this.lvImage.Name = "lvImage";
            this.lvImage.ShowGroups = false;
            this.lvImage.Size = new System.Drawing.Size(316, 512);
            this.lvImage.SmallImageList = this.imgThumb;
            this.lvImage.TabIndex = 3;
            this.lvImage.UseCompatibleStateImageBehavior = false;
            this.lvImage.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Image";
            this.columnHeader1.Width = 278;
            // 
            // imgThumb
            // 
            this.imgThumb.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgThumb.ImageSize = new System.Drawing.Size(200, 128);
            this.imgThumb.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 812);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.CaptureImage";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tlpCapture.ResumeLayout(false);
            this.groupRenderCapture.ResumeLayout(false);
            this.groupRenderCapture.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tlpCapture;
        private System.Windows.Forms.Button btnCaptureAuto;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.ListView lvImage;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imgThumb;
        private System.Windows.Forms.GroupBox groupRenderCapture;
        private System.Windows.Forms.Button btnCaptureRender;
        private System.Windows.Forms.CheckBox chkIncludeOverlay;
        private System.Windows.Forms.Label lblRenderCaptureHint;
    }
}

