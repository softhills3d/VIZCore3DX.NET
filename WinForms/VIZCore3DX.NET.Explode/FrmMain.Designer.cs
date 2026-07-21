namespace VIZCore3DX.NET.Explode
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbGroupLevel = new System.Windows.Forms.ComboBox();
            this.btnClearGroup = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRestoreAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExplode = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAxis = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLevelDistanceDecay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExplodeProgress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDistanceRatio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1334, 689);
            this.splitContainer1.SplitterDistance = 385;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cbGroupLevel);
            this.groupBox4.Controls.Add(this.btnClearGroup);
            this.groupBox4.Controls.Add(this.btnAddGroup);
            this.groupBox4.Location = new System.Drawing.Point(12, 157);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(359, 100);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Group";
            // 
            // cbGroupLevel
            // 
            this.cbGroupLevel.FormattingEnabled = true;
            this.cbGroupLevel.Items.AddRange(new object[] {
            "FLAT LEVEL 1",
            "FLAT LEVEL 2",
            "FLAT LEVEL 3",
            "FLAT LEVEL 4",
            "FLAT LEVEL 5",
            "HIERARCHICAL LEVEL 1",
            "HIERARCHICAL  LEVEL 2",
            "HIERARCHICAL  LEVEL 3",
            "HIERARCHICAL  LEVEL 4"});
            this.cbGroupLevel.Location = new System.Drawing.Point(49, 24);
            this.cbGroupLevel.Name = "cbGroupLevel";
            this.cbGroupLevel.Size = new System.Drawing.Size(173, 20);
            this.cbGroupLevel.TabIndex = 2;
            this.cbGroupLevel.Text = "FLAT or HIERARCHICAL";
            // 
            // btnClearGroup
            // 
            this.btnClearGroup.Location = new System.Drawing.Point(147, 60);
            this.btnClearGroup.Name = "btnClearGroup";
            this.btnClearGroup.Size = new System.Drawing.Size(75, 23);
            this.btnClearGroup.TabIndex = 1;
            this.btnClearGroup.Text = "Clear";
            this.btnClearGroup.UseVisualStyleBackColor = true;
            this.btnClearGroup.Click += new System.EventHandler(this.btnClearGroup_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(49, 60);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(75, 23);
            this.btnAddGroup.TabIndex = 0;
            this.btnAddGroup.Text = "Add Group";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnRestoreAll);
            this.groupBox3.Location = new System.Drawing.Point(12, 353);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(359, 60);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Restore";
            // 
            // btnRestoreAll
            // 
            this.btnRestoreAll.Location = new System.Drawing.Point(49, 21);
            this.btnRestoreAll.Name = "btnRestoreAll";
            this.btnRestoreAll.Size = new System.Drawing.Size(275, 23);
            this.btnRestoreAll.TabIndex = 3;
            this.btnRestoreAll.Text = "All";
            this.btnRestoreAll.UseVisualStyleBackColor = true;
            this.btnRestoreAll.Click += new System.EventHandler(this.btnRestoreAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnExplode);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbAxis);
            this.groupBox2.Location = new System.Drawing.Point(12, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Explode";
            // 
            // btnExplode
            // 
            this.btnExplode.Location = new System.Drawing.Point(224, 32);
            this.btnExplode.Name = "btnExplode";
            this.btnExplode.Size = new System.Drawing.Size(100, 23);
            this.btnExplode.TabIndex = 5;
            this.btnExplode.Text = "Explode";
            this.btnExplode.UseVisualStyleBackColor = true;
            this.btnExplode.Click += new System.EventHandler(this.btnExplode_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Axis";
            // 
            // cbAxis
            // 
            this.cbAxis.FormattingEnabled = true;
            this.cbAxis.Items.AddRange(new object[] {
            "X+",
            "X-",
            "Y+",
            "Y-",
            "Z+",
            "Z-",
            "XYZ"});
            this.cbAxis.Location = new System.Drawing.Point(92, 32);
            this.cbAxis.Name = "cbAxis";
            this.cbAxis.Size = new System.Drawing.Size(121, 20);
            this.cbAxis.TabIndex = 0;
            this.cbAxis.Text = "XYZ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtLevelDistanceDecay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtExplodeProgress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDistanceRatio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Property";
            // 
            // txtLevelDistanceDecay
            // 
            this.txtLevelDistanceDecay.Location = new System.Drawing.Point(224, 102);
            this.txtLevelDistanceDecay.Name = "txtLevelDistanceDecay";
            this.txtLevelDistanceDecay.Size = new System.Drawing.Size(100, 21);
            this.txtLevelDistanceDecay.TabIndex = 6;
            this.txtLevelDistanceDecay.Text = "0.5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Level Distance Decay";
            // 
            // txtExplodeProgress
            // 
            this.txtExplodeProgress.Location = new System.Drawing.Point(224, 60);
            this.txtExplodeProgress.Name = "txtExplodeProgress";
            this.txtExplodeProgress.Size = new System.Drawing.Size(100, 21);
            this.txtExplodeProgress.TabIndex = 3;
            this.txtExplodeProgress.Text = "0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "ExplodeProgress";
            // 
            // txtDistanceRatio
            // 
            this.txtDistanceRatio.Location = new System.Drawing.Point(224, 22);
            this.txtDistanceRatio.Name = "txtDistanceRatio";
            this.txtDistanceRatio.Size = new System.Drawing.Size(100, 21);
            this.txtDistanceRatio.TabIndex = 1;
            this.txtDistanceRatio.Text = "0.5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distance Ratio";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 689);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.Explode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbGroupLevel;
        private System.Windows.Forms.Button btnClearGroup;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRestoreAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExplode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbAxis;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtExplodeProgress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDistanceRatio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLevelDistanceDecay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddGroup;
    }
}

