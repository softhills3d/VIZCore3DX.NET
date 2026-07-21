namespace VIZCore3DX.NET.SelectParentAssembly
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckShow_Selection_Only = new System.Windows.Forms.CheckBox();
            this.ckSelected_Object = new System.Windows.Forms.RadioButton();
            this.ckWhole_Model = new System.Windows.Forms.RadioButton();
            this.ckPart_Node = new System.Windows.Forms.RadioButton();
            this.ckAssembly = new System.Windows.Forms.RadioButton();
            this.ckEnable = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(984, 561);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(317, 561);
            this.splitContainer2.SplitterDistance = 192;
            this.splitContainer2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ckShow_Selection_Only);
            this.groupBox1.Controls.Add(this.ckSelected_Object);
            this.groupBox1.Controls.Add(this.ckWhole_Model);
            this.groupBox1.Controls.Add(this.ckPart_Node);
            this.groupBox1.Controls.Add(this.ckAssembly);
            this.groupBox1.Controls.Add(this.ckEnable);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 176);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection";
            // 
            // ckShow_Selection_Only
            // 
            this.ckShow_Selection_Only.AutoSize = true;
            this.ckShow_Selection_Only.Location = new System.Drawing.Point(32, 135);
            this.ckShow_Selection_Only.Name = "ckShow_Selection_Only";
            this.ckShow_Selection_Only.Size = new System.Drawing.Size(142, 16);
            this.ckShow_Selection_Only.TabIndex = 15;
            this.ckShow_Selection_Only.Text = "Show Selection Only";
            this.ckShow_Selection_Only.UseVisualStyleBackColor = true;
            // 
            // ckSelected_Object
            // 
            this.ckSelected_Object.AutoSize = true;
            this.ckSelected_Object.Location = new System.Drawing.Point(47, 47);
            this.ckSelected_Object.Name = "ckSelected_Object";
            this.ckSelected_Object.Size = new System.Drawing.Size(112, 16);
            this.ckSelected_Object.TabIndex = 14;
            this.ckSelected_Object.TabStop = true;
            this.ckSelected_Object.Text = "Selected Object";
            this.ckSelected_Object.UseVisualStyleBackColor = true;
            // 
            // ckWhole_Model
            // 
            this.ckWhole_Model.AutoSize = true;
            this.ckWhole_Model.Location = new System.Drawing.Point(47, 113);
            this.ckWhole_Model.Name = "ckWhole_Model";
            this.ckWhole_Model.Size = new System.Drawing.Size(96, 16);
            this.ckWhole_Model.TabIndex = 13;
            this.ckWhole_Model.TabStop = true;
            this.ckWhole_Model.Text = "Whole Model";
            this.ckWhole_Model.UseVisualStyleBackColor = true;
            // 
            // ckPart_Node
            // 
            this.ckPart_Node.AutoSize = true;
            this.ckPart_Node.Location = new System.Drawing.Point(47, 69);
            this.ckPart_Node.Name = "ckPart_Node";
            this.ckPart_Node.Size = new System.Drawing.Size(98, 16);
            this.ckPart_Node.TabIndex = 12;
            this.ckPart_Node.TabStop = true;
            this.ckPart_Node.Text = "Selected Part";
            this.ckPart_Node.UseVisualStyleBackColor = true;
            // 
            // ckAssembly
            // 
            this.ckAssembly.AutoSize = true;
            this.ckAssembly.Location = new System.Drawing.Point(47, 91);
            this.ckAssembly.Name = "ckAssembly";
            this.ckAssembly.Size = new System.Drawing.Size(133, 16);
            this.ckAssembly.TabIndex = 11;
            this.ckAssembly.TabStop = true;
            this.ckAssembly.Text = "Selected Assembly";
            this.ckAssembly.UseVisualStyleBackColor = true;
            // 
            // ckEnable
            // 
            this.ckEnable.AutoSize = true;
            this.ckEnable.Checked = true;
            this.ckEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckEnable.Location = new System.Drawing.Point(32, 25);
            this.ckEnable.Name = "ckEnable";
            this.ckEnable.Size = new System.Drawing.Size(63, 16);
            this.ckEnable.TabIndex = 0;
            this.ckEnable.Text = "Enable";
            this.ckEnable.UseVisualStyleBackColor = true;
            this.ckEnable.CheckedChanged += new System.EventHandler(this.ckEnable_CheckedChanged);
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
            this.Text = "VIZCore3DX.NET.SelectParentAssembly";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckShow_Selection_Only;
        private System.Windows.Forms.RadioButton ckSelected_Object;
        private System.Windows.Forms.RadioButton ckWhole_Model;
        private System.Windows.Forms.RadioButton ckPart_Node;
        private System.Windows.Forms.RadioButton ckAssembly;
        private System.Windows.Forms.CheckBox ckEnable;
    }
}

