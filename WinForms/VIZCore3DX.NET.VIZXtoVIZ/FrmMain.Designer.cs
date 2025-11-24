namespace VIZCore3DX.NET.VIZXtoVIZ
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
            this.cbViewCmd = new System.Windows.Forms.CheckBox();
            this.cbSnapshotCheck = new System.Windows.Forms.CheckBox();
            this.btnSetConvertPath = new System.Windows.Forms.Button();
            this.convertPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.btnAddModels = new System.Windows.Forms.Button();
            this.btnCloseModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(1130, 687);
            this.splitContainer1.SplitterDistance = 376;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbViewCmd);
            this.groupBox1.Controls.Add(this.cbSnapshotCheck);
            this.groupBox1.Controls.Add(this.btnSetConvertPath);
            this.groupBox1.Controls.Add(this.convertPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnConvert);
            this.groupBox1.Location = new System.Drawing.Point(12, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 562);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VIZX to VIZ";
            // 
            // cbViewCmd
            // 
            this.cbViewCmd.AutoSize = true;
            this.cbViewCmd.Location = new System.Drawing.Point(174, 118);
            this.cbViewCmd.Name = "cbViewCmd";
            this.cbViewCmd.Size = new System.Drawing.Size(147, 16);
            this.cbViewCmd.TabIndex = 8;
            this.cbViewCmd.Text = "Check CMD Progress";
            this.cbViewCmd.UseVisualStyleBackColor = true;
            // 
            // cbSnapshotCheck
            // 
            this.cbSnapshotCheck.AutoSize = true;
            this.cbSnapshotCheck.Location = new System.Drawing.Point(15, 118);
            this.cbSnapshotCheck.Name = "cbSnapshotCheck";
            this.cbSnapshotCheck.Size = new System.Drawing.Size(123, 16);
            this.cbSnapshotCheck.TabIndex = 7;
            this.cbSnapshotCheck.Text = "Split by Snapshot";
            this.cbSnapshotCheck.UseVisualStyleBackColor = true;
            // 
            // btnSetConvertPath
            // 
            this.btnSetConvertPath.Location = new System.Drawing.Point(15, 29);
            this.btnSetConvertPath.Name = "btnSetConvertPath";
            this.btnSetConvertPath.Size = new System.Drawing.Size(157, 23);
            this.btnSetConvertPath.TabIndex = 3;
            this.btnSetConvertPath.Text = "Set Convert Path";
            this.btnSetConvertPath.UseVisualStyleBackColor = true;
            this.btnSetConvertPath.Click += new System.EventHandler(this.btnSetConvertPath_Click);
            // 
            // convertPath
            // 
            this.convertPath.Location = new System.Drawing.Point(123, 69);
            this.convertPath.Name = "convertPath";
            this.convertPath.ReadOnly = true;
            this.convertPath.Size = new System.Drawing.Size(220, 21);
            this.convertPath.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Convert File Path:";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(15, 140);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(157, 23);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnOpenModel);
            this.groupBox3.Controls.Add(this.btnAddModels);
            this.groupBox3.Controls.Add(this.btnCloseModel);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(355, 95);
            this.groupBox3.TabIndex = 5;
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
            this.Text = "VIZCore3DX.NET.VIZXtoVIZ";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox convertPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetConvertPath;
        private System.Windows.Forms.CheckBox cbSnapshotCheck;
        private System.Windows.Forms.CheckBox cbViewCmd;
    }
}

