namespace VIZCore3DX.NET.SubView
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitViews = new System.Windows.Forms.SplitContainer();
            this.splitLeftViews = new System.Windows.Forms.SplitContainer();
            this.splitRightViews = new System.Windows.Forms.SplitContainer();
            this.splitContainerRoot = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnModelTree = new System.Windows.Forms.Button();
            this.btnModelOpen = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnView2 = new System.Windows.Forms.Button();
            this.btnView1 = new System.Windows.Forms.Button();
            this.btnView3 = new System.Windows.Forms.Button();
            this.btnView4 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCameraX2 = new System.Windows.Forms.Button();
            this.btnCameraX1 = new System.Windows.Forms.Button();
            this.btnCameraISO = new System.Windows.Forms.Button();
            this.btnCameraY1 = new System.Windows.Forms.Button();
            this.btnCameraZ1 = new System.Windows.Forms.Button();
            this.btnCameraY2 = new System.Windows.Forms.Button();
            this.btnCameraZ2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitViews)).BeginInit();
            this.splitViews.Panel1.SuspendLayout();
            this.splitViews.Panel2.SuspendLayout();
            this.splitViews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeftViews)).BeginInit();
            this.splitLeftViews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRightViews)).BeginInit();
            this.splitRightViews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRoot)).BeginInit();
            this.splitContainerRoot.Panel1.SuspendLayout();
            this.splitContainerRoot.Panel2.SuspendLayout();
            this.splitContainerRoot.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitViews);
            this.splitContainerMain.Size = new System.Drawing.Size(832, 541);
            this.splitContainerMain.SplitterDistance = 200;
            this.splitContainerMain.TabIndex = 1;
            // 
            // splitViews
            // 
            this.splitViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitViews.Location = new System.Drawing.Point(0, 0);
            this.splitViews.Name = "splitViews";
            // 
            // splitViews.Panel1
            // 
            this.splitViews.Panel1.Controls.Add(this.splitLeftViews);
            // 
            // splitViews.Panel2
            // 
            this.splitViews.Panel2.Controls.Add(this.splitRightViews);
            this.splitViews.Size = new System.Drawing.Size(628, 541);
            this.splitViews.SplitterDistance = 312;
            this.splitViews.TabIndex = 2;
            // 
            // splitLeftViews
            // 
            this.splitLeftViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLeftViews.Location = new System.Drawing.Point(0, 0);
            this.splitLeftViews.Name = "splitLeftViews";
            this.splitLeftViews.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitLeftViews.Size = new System.Drawing.Size(312, 541);
            this.splitLeftViews.SplitterDistance = 266;
            this.splitLeftViews.TabIndex = 1;
            // 
            // splitRightViews
            // 
            this.splitRightViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRightViews.Location = new System.Drawing.Point(0, 0);
            this.splitRightViews.Name = "splitRightViews";
            this.splitRightViews.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitRightViews.Size = new System.Drawing.Size(312, 541);
            this.splitRightViews.SplitterDistance = 266;
            this.splitRightViews.TabIndex = 0;
            // 
            // splitContainerRoot
            // 
            this.splitContainerRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRoot.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRoot.Name = "splitContainerRoot";
            // 
            // splitContainerRoot.Panel1
            // 
            this.splitContainerRoot.Panel1.Controls.Add(this.groupBox3);
            this.splitContainerRoot.Panel1.Controls.Add(this.groupBox2);
            this.splitContainerRoot.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainerRoot.Panel2
            // 
            this.splitContainerRoot.Panel2.Controls.Add(this.splitContainerMain);
            this.splitContainerRoot.Size = new System.Drawing.Size(956, 541);
            this.splitContainerRoot.SplitterDistance = 120;
            this.splitContainerRoot.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnModelTree);
            this.groupBox1.Controls.Add(this.btnModelOpen);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 78);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Model";
            // 
            // btnModelTree
            // 
            this.btnModelTree.Location = new System.Drawing.Point(9, 47);
            this.btnModelTree.Name = "btnModelTree";
            this.btnModelTree.Size = new System.Drawing.Size(100, 25);
            this.btnModelTree.TabIndex = 3;
            this.btnModelTree.Text = "ModelTree";
            this.btnModelTree.UseVisualStyleBackColor = true;
            this.btnModelTree.Click += new System.EventHandler(this.btnModelTree_Click);
            // 
            // btnModelOpen
            // 
            this.btnModelOpen.Location = new System.Drawing.Point(9, 20);
            this.btnModelOpen.Name = "btnModelOpen";
            this.btnModelOpen.Size = new System.Drawing.Size(100, 25);
            this.btnModelOpen.TabIndex = 2;
            this.btnModelOpen.Text = "Model Open";
            this.btnModelOpen.UseVisualStyleBackColor = true;
            this.btnModelOpen.Click += new System.EventHandler(this.btnModelOpen_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnView4);
            this.groupBox2.Controls.Add(this.btnView3);
            this.groupBox2.Controls.Add(this.btnView2);
            this.groupBox2.Controls.Add(this.btnView1);
            this.groupBox2.Location = new System.Drawing.Point(3, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 146);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sub View";
            // 
            // btnView2
            // 
            this.btnView2.Location = new System.Drawing.Point(9, 51);
            this.btnView2.Name = "btnView2";
            this.btnView2.Size = new System.Drawing.Size(100, 25);
            this.btnView2.TabIndex = 3;
            this.btnView2.Text = "2 분할";
            this.btnView2.UseVisualStyleBackColor = true;
            this.btnView2.Click += new System.EventHandler(this.btnView2_Click);
            // 
            // btnView1
            // 
            this.btnView1.Location = new System.Drawing.Point(9, 20);
            this.btnView1.Name = "btnView1";
            this.btnView1.Size = new System.Drawing.Size(100, 25);
            this.btnView1.TabIndex = 2;
            this.btnView1.Text = "단일 뷰";
            this.btnView1.UseVisualStyleBackColor = true;
            this.btnView1.Click += new System.EventHandler(this.btnView1_Click);
            // 
            // btnView3
            // 
            this.btnView3.Location = new System.Drawing.Point(9, 82);
            this.btnView3.Name = "btnView3";
            this.btnView3.Size = new System.Drawing.Size(100, 25);
            this.btnView3.TabIndex = 4;
            this.btnView3.Text = "3 분할";
            this.btnView3.UseVisualStyleBackColor = true;
            this.btnView3.Click += new System.EventHandler(this.btnView3_Click);
            // 
            // btnView4
            // 
            this.btnView4.Location = new System.Drawing.Point(9, 113);
            this.btnView4.Name = "btnView4";
            this.btnView4.Size = new System.Drawing.Size(100, 25);
            this.btnView4.TabIndex = 5;
            this.btnView4.Text = "4 분할";
            this.btnView4.UseVisualStyleBackColor = true;
            this.btnView4.Click += new System.EventHandler(this.btnView4_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnCameraZ2);
            this.groupBox3.Controls.Add(this.btnCameraZ1);
            this.groupBox3.Controls.Add(this.btnCameraY2);
            this.groupBox3.Controls.Add(this.btnCameraY1);
            this.groupBox3.Controls.Add(this.btnCameraX2);
            this.groupBox3.Controls.Add(this.btnCameraX1);
            this.groupBox3.Controls.Add(this.btnCameraISO);
            this.groupBox3.Location = new System.Drawing.Point(4, 267);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(114, 240);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Camera";
            // 
            // btnCameraX2
            // 
            this.btnCameraX2.Location = new System.Drawing.Point(9, 82);
            this.btnCameraX2.Name = "btnCameraX2";
            this.btnCameraX2.Size = new System.Drawing.Size(100, 25);
            this.btnCameraX2.TabIndex = 5;
            this.btnCameraX2.Text = "X-";
            this.btnCameraX2.UseVisualStyleBackColor = true;
            this.btnCameraX2.Click += new System.EventHandler(this.btnCameraX2_Click);
            // 
            // btnCameraX1
            // 
            this.btnCameraX1.Location = new System.Drawing.Point(9, 51);
            this.btnCameraX1.Name = "btnCameraX1";
            this.btnCameraX1.Size = new System.Drawing.Size(100, 25);
            this.btnCameraX1.TabIndex = 4;
            this.btnCameraX1.Text = "X+";
            this.btnCameraX1.UseVisualStyleBackColor = true;
            this.btnCameraX1.Click += new System.EventHandler(this.btnCameraX1_Click);
            // 
            // btnCameraISO
            // 
            this.btnCameraISO.Location = new System.Drawing.Point(9, 20);
            this.btnCameraISO.Name = "btnCameraISO";
            this.btnCameraISO.Size = new System.Drawing.Size(100, 25);
            this.btnCameraISO.TabIndex = 2;
            this.btnCameraISO.Text = "ISO";
            this.btnCameraISO.UseVisualStyleBackColor = true;
            this.btnCameraISO.Click += new System.EventHandler(this.btnCameraISO_Click);
            // 
            // btnCameraY1
            // 
            this.btnCameraY1.Location = new System.Drawing.Point(9, 113);
            this.btnCameraY1.Name = "btnCameraY1";
            this.btnCameraY1.Size = new System.Drawing.Size(100, 25);
            this.btnCameraY1.TabIndex = 6;
            this.btnCameraY1.Text = "Y+";
            this.btnCameraY1.UseVisualStyleBackColor = true;
            this.btnCameraY1.Click += new System.EventHandler(this.btnCameraY1_Click);
            // 
            // btnCameraZ1
            // 
            this.btnCameraZ1.Location = new System.Drawing.Point(9, 175);
            this.btnCameraZ1.Name = "btnCameraZ1";
            this.btnCameraZ1.Size = new System.Drawing.Size(100, 25);
            this.btnCameraZ1.TabIndex = 8;
            this.btnCameraZ1.Text = "Z+";
            this.btnCameraZ1.UseVisualStyleBackColor = true;
            this.btnCameraZ1.Click += new System.EventHandler(this.btnCameraZ1_Click);
            // 
            // btnCameraY2
            // 
            this.btnCameraY2.Location = new System.Drawing.Point(9, 144);
            this.btnCameraY2.Name = "btnCameraY2";
            this.btnCameraY2.Size = new System.Drawing.Size(100, 25);
            this.btnCameraY2.TabIndex = 7;
            this.btnCameraY2.Text = "Y-";
            this.btnCameraY2.UseVisualStyleBackColor = true;
            this.btnCameraY2.Click += new System.EventHandler(this.btnCameraY2_Click);
            // 
            // btnCameraZ2
            // 
            this.btnCameraZ2.Location = new System.Drawing.Point(9, 206);
            this.btnCameraZ2.Name = "btnCameraZ2";
            this.btnCameraZ2.Size = new System.Drawing.Size(100, 25);
            this.btnCameraZ2.TabIndex = 9;
            this.btnCameraZ2.Text = "Z-";
            this.btnCameraZ2.UseVisualStyleBackColor = true;
            this.btnCameraZ2.Click += new System.EventHandler(this.btnCameraZ2_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 541);
            this.Controls.Add(this.splitContainerRoot);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.SubView";
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitViews.Panel1.ResumeLayout(false);
            this.splitViews.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitViews)).EndInit();
            this.splitViews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitLeftViews)).EndInit();
            this.splitLeftViews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRightViews)).EndInit();
            this.splitRightViews.ResumeLayout(false);
            this.splitContainerRoot.Panel1.ResumeLayout(false);
            this.splitContainerRoot.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRoot)).EndInit();
            this.splitContainerRoot.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerRoot;
        private System.Windows.Forms.Button btnModelTree;
        private System.Windows.Forms.Button btnModelOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitViews;
        private System.Windows.Forms.SplitContainer splitLeftViews;
        private System.Windows.Forms.SplitContainer splitRightViews;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnView2;
        private System.Windows.Forms.Button btnView1;
        private System.Windows.Forms.Button btnView4;
        private System.Windows.Forms.Button btnView3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCameraZ2;
        private System.Windows.Forms.Button btnCameraZ1;
        private System.Windows.Forms.Button btnCameraY2;
        private System.Windows.Forms.Button btnCameraY1;
        private System.Windows.Forms.Button btnCameraX2;
        private System.Windows.Forms.Button btnCameraX1;
        private System.Windows.Forms.Button btnCameraISO;
    }
}

