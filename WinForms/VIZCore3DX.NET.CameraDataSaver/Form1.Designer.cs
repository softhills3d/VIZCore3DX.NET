namespace VIZCore3DX.NET.CameraDataSaver
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numCameraMoveTime = new System.Windows.Forms.NumericUpDown();
            this.btnActionLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCameraLoad = new System.Windows.Forms.Button();
            this.btnCameraSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraMoveTime)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1043, 742);
            this.splitContainer1.SplitterDistance = 347;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnCameraLoad);
            this.groupBox1.Controls.Add(this.btnCameraSave);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 717);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera Control";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numCameraMoveTime);
            this.groupBox2.Controls.Add(this.btnActionLoad);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 66);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // numCameraMoveTime
            // 
            this.numCameraMoveTime.Location = new System.Drawing.Point(84, 30);
            this.numCameraMoveTime.Name = "numCameraMoveTime";
            this.numCameraMoveTime.Size = new System.Drawing.Size(48, 21);
            this.numCameraMoveTime.TabIndex = 2;
            // 
            // btnActionLoad
            // 
            this.btnActionLoad.Location = new System.Drawing.Point(138, 28);
            this.btnActionLoad.Name = "btnActionLoad";
            this.btnActionLoad.Size = new System.Drawing.Size(107, 23);
            this.btnActionLoad.TabIndex = 0;
            this.btnActionLoad.Text = "Action Load";
            this.btnActionLoad.UseVisualStyleBackColor = true;
            this.btnActionLoad.Click += new System.EventHandler(this.btnActionLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "MoveTime";
            // 
            // btnCameraLoad
            // 
            this.btnCameraLoad.Location = new System.Drawing.Point(144, 20);
            this.btnCameraLoad.Name = "btnCameraLoad";
            this.btnCameraLoad.Size = new System.Drawing.Size(107, 23);
            this.btnCameraLoad.TabIndex = 0;
            this.btnCameraLoad.Text = "Camera Load";
            this.btnCameraLoad.UseVisualStyleBackColor = true;
            this.btnCameraLoad.Click += new System.EventHandler(this.btnCameraLoad_Click);
            // 
            // btnCameraSave
            // 
            this.btnCameraSave.Location = new System.Drawing.Point(20, 20);
            this.btnCameraSave.Name = "btnCameraSave";
            this.btnCameraSave.Size = new System.Drawing.Size(107, 23);
            this.btnCameraSave.TabIndex = 0;
            this.btnCameraSave.Text = "Camera Save";
            this.btnCameraSave.UseVisualStyleBackColor = true;
            this.btnCameraSave.Click += new System.EventHandler(this.btnCameraSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 742);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.CameraDataSaver";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraMoveTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCameraSave;
        private System.Windows.Forms.Button btnCameraLoad;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numCameraMoveTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActionLoad;
    }
}

