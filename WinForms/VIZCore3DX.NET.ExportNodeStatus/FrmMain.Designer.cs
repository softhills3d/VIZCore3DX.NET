namespace VIZCore3DX.NET.ExportNodeStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbIncludeMarkup = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImportStatus = new System.Windows.Forms.Button();
            this.btnExportStatus = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnPart = new System.Windows.Forms.Button();
            this.btnPlate = new System.Windows.Forms.Button();
            this.btnValve = new System.Windows.Forms.Button();
            this.btnPipe = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddReview = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.btnAddModels = new System.Windows.Forms.Button();
            this.btnCloseModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(1130, 687);
            this.splitContainer1.SplitterDistance = 376;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbIncludeMarkup);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnImportStatus);
            this.groupBox1.Controls.Add(this.btnExportStatus);
            this.groupBox1.Location = new System.Drawing.Point(12, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 133);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Node Status";
            // 
            // cbIncludeMarkup
            // 
            this.cbIncludeMarkup.AutoSize = true;
            this.cbIncludeMarkup.Checked = true;
            this.cbIncludeMarkup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIncludeMarkup.Location = new System.Drawing.Point(229, 69);
            this.cbIncludeMarkup.Name = "cbIncludeMarkup";
            this.cbIncludeMarkup.Size = new System.Drawing.Size(111, 16);
            this.cbIncludeMarkup.TabIndex = 6;
            this.cbIncludeMarkup.Text = "Include Markup";
            this.cbIncludeMarkup.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(58, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(282, 21);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "C:\\Temp\\node_status.vizxs";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Path:";
            // 
            // btnImportStatus
            // 
            this.btnImportStatus.Location = new System.Drawing.Point(16, 81);
            this.btnImportStatus.Name = "btnImportStatus";
            this.btnImportStatus.Size = new System.Drawing.Size(198, 23);
            this.btnImportStatus.TabIndex = 3;
            this.btnImportStatus.Text = "Import (Compare && Apply)";
            this.btnImportStatus.UseVisualStyleBackColor = true;
            this.btnImportStatus.Click += new System.EventHandler(this.btnImportStatus_Click);
            // 
            // btnExportStatus
            // 
            this.btnExportStatus.Location = new System.Drawing.Point(16, 52);
            this.btnExportStatus.Name = "btnExportStatus";
            this.btnExportStatus.Size = new System.Drawing.Size(198, 23);
            this.btnExportStatus.TabIndex = 2;
            this.btnExportStatus.Text = "Export Node Status";
            this.btnExportStatus.UseVisualStyleBackColor = true;
            this.btnExportStatus.Click += new System.EventHandler(this.btnExportStatus_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtLog);
            this.groupBox2.Location = new System.Drawing.Point(12, 439);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 236);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 17);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(349, 216);
            this.txtLog.TabIndex = 0;
            this.txtLog.WordWrap = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btnAddReview);
            this.groupBox4.Location = new System.Drawing.Point(12, 99);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(355, 195);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Review";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnPart);
            this.groupBox5.Controls.Add(this.btnPlate);
            this.groupBox5.Controls.Add(this.btnValve);
            this.groupBox5.Controls.Add(this.btnPipe);
            this.groupBox5.Location = new System.Drawing.Point(16, 85);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(324, 95);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Node Visible Control (UDA)";
            // 
            // btnPart
            // 
            this.btnPart.Location = new System.Drawing.Point(180, 60);
            this.btnPart.Name = "btnPart";
            this.btnPart.Size = new System.Drawing.Size(111, 23);
            this.btnPart.TabIndex = 3;
            this.btnPart.Text = "PART";
            this.btnPart.UseVisualStyleBackColor = true;
            this.btnPart.Click += new System.EventHandler(this.btnUdaToggle_Click);
            // 
            // btnPlate
            // 
            this.btnPlate.Location = new System.Drawing.Point(25, 60);
            this.btnPlate.Name = "btnPlate";
            this.btnPlate.Size = new System.Drawing.Size(111, 23);
            this.btnPlate.TabIndex = 2;
            this.btnPlate.Text = "PLATE";
            this.btnPlate.UseVisualStyleBackColor = true;
            this.btnPlate.Click += new System.EventHandler(this.btnUdaToggle_Click);
            // 
            // btnValve
            // 
            this.btnValve.Location = new System.Drawing.Point(180, 31);
            this.btnValve.Name = "btnValve";
            this.btnValve.Size = new System.Drawing.Size(111, 23);
            this.btnValve.TabIndex = 1;
            this.btnValve.Text = "VALVE";
            this.btnValve.UseVisualStyleBackColor = true;
            this.btnValve.Click += new System.EventHandler(this.btnUdaToggle_Click);
            // 
            // btnPipe
            // 
            this.btnPipe.Location = new System.Drawing.Point(25, 31);
            this.btnPipe.Name = "btnPipe";
            this.btnPipe.Size = new System.Drawing.Size(111, 23);
            this.btnPipe.TabIndex = 0;
            this.btnPipe.Text = "PIPE";
            this.btnPipe.UseVisualStyleBackColor = true;
            this.btnPipe.Click += new System.EventHandler(this.btnUdaToggle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(19, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "(Object : Note, Measure, Section, Snapshot, Decal)";
            // 
            // btnAddReview
            // 
            this.btnAddReview.Location = new System.Drawing.Point(16, 24);
            this.btnAddReview.Name = "btnAddReview";
            this.btnAddReview.Size = new System.Drawing.Size(325, 23);
            this.btnAddReview.TabIndex = 0;
            this.btnAddReview.Text = "Add Review Object";
            this.btnAddReview.UseVisualStyleBackColor = true;
            this.btnAddReview.Click += new System.EventHandler(this.btnAddReview_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnOpenModel);
            this.groupBox3.Controls.Add(this.btnAddModels);
            this.groupBox3.Controls.Add(this.btnCloseModel);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(355, 81);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Model";
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Location = new System.Drawing.Point(15, 38);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(101, 23);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "Open";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // btnAddModels
            // 
            this.btnAddModels.Location = new System.Drawing.Point(126, 38);
            this.btnAddModels.Name = "btnAddModels";
            this.btnAddModels.Size = new System.Drawing.Size(101, 23);
            this.btnAddModels.TabIndex = 1;
            this.btnAddModels.Text = "Add";
            this.btnAddModels.UseVisualStyleBackColor = true;
            this.btnAddModels.Click += new System.EventHandler(this.btnAddModels_Click);
            // 
            // btnCloseModel
            // 
            this.btnCloseModel.Location = new System.Drawing.Point(239, 38);
            this.btnCloseModel.Name = "btnCloseModel";
            this.btnCloseModel.Size = new System.Drawing.Size(101, 23);
            this.btnCloseModel.TabIndex = 2;
            this.btnCloseModel.Text = "Close";
            this.btnCloseModel.UseVisualStyleBackColor = true;
            this.btnCloseModel.Click += new System.EventHandler(this.btnCloseModel_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 687);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.ExportNodeStatus";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Button btnAddModels;
        private System.Windows.Forms.Button btnCloseModel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImportStatus;
        private System.Windows.Forms.Button btnExportStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAddReview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnPart;
        private System.Windows.Forms.Button btnPlate;
        private System.Windows.Forms.Button btnValve;
        private System.Windows.Forms.Button btnPipe;
        private System.Windows.Forms.CheckBox cbIncludeMarkup;
    }
}
