namespace VIZCore3DX.NET.SectionMoveByOsnap
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
            this.btnCreate_Section = new System.Windows.Forms.Button();
            this.bntClear_Section = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSection_Position = new System.Windows.Forms.Button();
            this.btnZ_Axis = new System.Windows.Forms.Button();
            this.btnY_Axis = new System.Windows.Forms.Button();
            this.btnX_Axis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(984, 561);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.bntClear_Section);
            this.groupBox1.Controls.Add(this.btnCreate_Section);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 87);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Section Plane";
            // 
            // btnCreate_Section
            // 
            this.btnCreate_Section.Location = new System.Drawing.Point(20, 20);
            this.btnCreate_Section.Name = "btnCreate_Section";
            this.btnCreate_Section.Size = new System.Drawing.Size(169, 23);
            this.btnCreate_Section.TabIndex = 0;
            this.btnCreate_Section.Text = "Create Section";
            this.btnCreate_Section.UseVisualStyleBackColor = true;
            this.btnCreate_Section.Click += new System.EventHandler(this.btnCreate_Section_Click);
            // 
            // bntClear_Section
            // 
            this.bntClear_Section.Location = new System.Drawing.Point(20, 49);
            this.bntClear_Section.Name = "bntClear_Section";
            this.bntClear_Section.Size = new System.Drawing.Size(169, 23);
            this.bntClear_Section.TabIndex = 2;
            this.bntClear_Section.Text = "Clear Section";
            this.bntClear_Section.UseVisualStyleBackColor = true;
            this.bntClear_Section.Click += new System.EventHandler(this.bntSection_Clear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSection_Position);
            this.groupBox2.Location = new System.Drawing.Point(12, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 57);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Section Position";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnZ_Axis);
            this.groupBox3.Controls.Add(this.btnY_Axis);
            this.groupBox3.Controls.Add(this.btnX_Axis);
            this.groupBox3.Location = new System.Drawing.Point(12, 168);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 114);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Section Direction";
            // 
            // btnSection_Position
            // 
            this.btnSection_Position.Location = new System.Drawing.Point(20, 20);
            this.btnSection_Position.Name = "btnSection_Position";
            this.btnSection_Position.Size = new System.Drawing.Size(169, 23);
            this.btnSection_Position.TabIndex = 4;
            this.btnSection_Position.Text = "Move Section To Snap";
            this.btnSection_Position.UseVisualStyleBackColor = true;
            this.btnSection_Position.Click += new System.EventHandler(this.btnSection_Position_Click);
            // 
            // btnZ_Axis
            // 
            this.btnZ_Axis.Location = new System.Drawing.Point(20, 78);
            this.btnZ_Axis.Name = "btnZ_Axis";
            this.btnZ_Axis.Size = new System.Drawing.Size(169, 23);
            this.btnZ_Axis.TabIndex = 5;
            this.btnZ_Axis.Text = "Z Axis";
            this.btnZ_Axis.UseVisualStyleBackColor = true;
            this.btnZ_Axis.Click += new System.EventHandler(this.btnZ_Axis_Click);
            // 
            // btnY_Axis
            // 
            this.btnY_Axis.Location = new System.Drawing.Point(20, 49);
            this.btnY_Axis.Name = "btnY_Axis";
            this.btnY_Axis.Size = new System.Drawing.Size(169, 23);
            this.btnY_Axis.TabIndex = 4;
            this.btnY_Axis.Text = "Y Axis\n";
            this.btnY_Axis.UseVisualStyleBackColor = true;
            this.btnY_Axis.Click += new System.EventHandler(this.btnY_Axis_Click);
            // 
            // btnX_Axis
            // 
            this.btnX_Axis.Location = new System.Drawing.Point(20, 20);
            this.btnX_Axis.Name = "btnX_Axis";
            this.btnX_Axis.Size = new System.Drawing.Size(169, 23);
            this.btnX_Axis.TabIndex = 3;
            this.btnX_Axis.Text = "X Axis";
            this.btnX_Axis.UseVisualStyleBackColor = true;
            this.btnX_Axis.Click += new System.EventHandler(this.btnX_Axis_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.SectionMoveByOsnap";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreate_Section;
        private System.Windows.Forms.Button bntClear_Section;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnZ_Axis;
        private System.Windows.Forms.Button btnY_Axis;
        private System.Windows.Forms.Button btnX_Axis;
        private System.Windows.Forms.Button btnSection_Position;
    }
}

