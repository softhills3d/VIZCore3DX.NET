namespace VIZCore3DX.NET.Basic
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
            this.splitContainerRoot = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnResetView = new System.Windows.Forms.Button();
            this.btnFitView = new System.Windows.Forms.Button();
            this.btnMoveToObject = new System.Windows.Forms.Button();
            this.btnFlyToObject = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnHideAll = new System.Windows.Forms.Button();
            this.btnHideSelection = new System.Windows.Forms.Button();
            this.btnHideNonSelection = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnModelTree = new System.Windows.Forms.Button();
            this.btnModelOpen = new System.Windows.Forms.Button();
            this.btnPerspectiveView = new System.Windows.Forms.Button();
            this.btnOrthographicView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRoot)).BeginInit();
            this.splitContainerRoot.Panel1.SuspendLayout();
            this.splitContainerRoot.Panel2.SuspendLayout();
            this.splitContainerRoot.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Size = new System.Drawing.Size(832, 541);
            this.splitContainerMain.SplitterDistance = 200;
            this.splitContainerMain.TabIndex = 1;
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
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnOrthographicView);
            this.groupBox3.Controls.Add(this.btnPerspectiveView);
            this.groupBox3.Controls.Add(this.btnResetView);
            this.groupBox3.Controls.Add(this.btnFitView);
            this.groupBox3.Controls.Add(this.btnMoveToObject);
            this.groupBox3.Controls.Add(this.btnFlyToObject);
            this.groupBox3.Location = new System.Drawing.Point(3, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(114, 206);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "View";
            // 
            // btnResetView
            // 
            this.btnResetView.Location = new System.Drawing.Point(8, 20);
            this.btnResetView.Name = "btnResetView";
            this.btnResetView.Size = new System.Drawing.Size(100, 25);
            this.btnResetView.TabIndex = 5;
            this.btnResetView.Text = "초기 화면으로";
            this.btnResetView.UseVisualStyleBackColor = true;
            this.btnResetView.Click += new System.EventHandler(this.btnResetView_Click);
            // 
            // btnFitView
            // 
            this.btnFitView.Location = new System.Drawing.Point(8, 51);
            this.btnFitView.Name = "btnFitView";
            this.btnFitView.Size = new System.Drawing.Size(100, 25);
            this.btnFitView.TabIndex = 4;
            this.btnFitView.Text = "화면에 맞춤";
            this.btnFitView.UseVisualStyleBackColor = true;
            this.btnFitView.Click += new System.EventHandler(this.btnFitView_Click);
            // 
            // btnMoveToObject
            // 
            this.btnMoveToObject.Location = new System.Drawing.Point(8, 82);
            this.btnMoveToObject.Name = "btnMoveToObject";
            this.btnMoveToObject.Size = new System.Drawing.Size(100, 25);
            this.btnMoveToObject.TabIndex = 3;
            this.btnMoveToObject.Text = "개체로 이동";
            this.btnMoveToObject.UseVisualStyleBackColor = true;
            this.btnMoveToObject.Click += new System.EventHandler(this.btnMoveToObject_Click);
            // 
            // btnFlyToObject
            // 
            this.btnFlyToObject.Location = new System.Drawing.Point(8, 113);
            this.btnFlyToObject.Name = "btnFlyToObject";
            this.btnFlyToObject.Size = new System.Drawing.Size(100, 25);
            this.btnFlyToObject.TabIndex = 2;
            this.btnFlyToObject.Text = "개체로 비행";
            this.btnFlyToObject.UseVisualStyleBackColor = true;
            this.btnFlyToObject.Click += new System.EventHandler(this.btnFlyToObject_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnShowAll);
            this.groupBox2.Controls.Add(this.btnHideAll);
            this.groupBox2.Controls.Add(this.btnHideSelection);
            this.groupBox2.Controls.Add(this.btnHideNonSelection);
            this.groupBox2.Location = new System.Drawing.Point(4, 327);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 146);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Show";
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(8, 20);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(100, 25);
            this.btnShowAll.TabIndex = 5;
            this.btnShowAll.Text = "모두 보이기";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnHideAll
            // 
            this.btnHideAll.Location = new System.Drawing.Point(8, 51);
            this.btnHideAll.Name = "btnHideAll";
            this.btnHideAll.Size = new System.Drawing.Size(100, 25);
            this.btnHideAll.TabIndex = 4;
            this.btnHideAll.Text = "모두 숨기기";
            this.btnHideAll.UseVisualStyleBackColor = true;
            this.btnHideAll.Click += new System.EventHandler(this.btnHideAll_Click);
            // 
            // btnHideSelection
            // 
            this.btnHideSelection.Location = new System.Drawing.Point(8, 82);
            this.btnHideSelection.Name = "btnHideSelection";
            this.btnHideSelection.Size = new System.Drawing.Size(100, 25);
            this.btnHideSelection.TabIndex = 3;
            this.btnHideSelection.Text = "선택 숨기기";
            this.btnHideSelection.UseVisualStyleBackColor = true;
            this.btnHideSelection.Click += new System.EventHandler(this.btnHideSelection_Click);
            // 
            // btnHideNonSelection
            // 
            this.btnHideNonSelection.Location = new System.Drawing.Point(8, 113);
            this.btnHideNonSelection.Name = "btnHideNonSelection";
            this.btnHideNonSelection.Size = new System.Drawing.Size(100, 25);
            this.btnHideNonSelection.TabIndex = 2;
            this.btnHideNonSelection.Text = "비선택 숨기기";
            this.btnHideNonSelection.UseVisualStyleBackColor = true;
            this.btnHideNonSelection.Click += new System.EventHandler(this.btnHideNonSelection_Click);
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
            // btnPerspectiveView
            // 
            this.btnPerspectiveView.Location = new System.Drawing.Point(8, 144);
            this.btnPerspectiveView.Name = "btnPerspectiveView";
            this.btnPerspectiveView.Size = new System.Drawing.Size(100, 25);
            this.btnPerspectiveView.TabIndex = 6;
            this.btnPerspectiveView.Text = "원근뷰";
            this.btnPerspectiveView.UseVisualStyleBackColor = true;
            this.btnPerspectiveView.Click += new System.EventHandler(this.btnPerspectiveView_Click);
            // 
            // btnOrthographicView
            // 
            this.btnOrthographicView.Location = new System.Drawing.Point(8, 175);
            this.btnOrthographicView.Name = "btnOrthographicView";
            this.btnOrthographicView.Size = new System.Drawing.Size(100, 25);
            this.btnOrthographicView.TabIndex = 7;
            this.btnOrthographicView.Text = "평행뷰";
            this.btnOrthographicView.UseVisualStyleBackColor = true;
            this.btnOrthographicView.Click += new System.EventHandler(this.btnOrthographicView_Click);
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
            this.Text = "VIZCore3DX.NET.View";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerRoot.Panel1.ResumeLayout(false);
            this.splitContainerRoot.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRoot)).EndInit();
            this.splitContainerRoot.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerRoot;
        private System.Windows.Forms.Button btnModelTree;
        private System.Windows.Forms.Button btnModelOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHideSelection;
        private System.Windows.Forms.Button btnHideNonSelection;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnResetView;
        private System.Windows.Forms.Button btnFitView;
        private System.Windows.Forms.Button btnMoveToObject;
        private System.Windows.Forms.Button btnFlyToObject;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnHideAll;
        private System.Windows.Forms.Button btnPerspectiveView;
        private System.Windows.Forms.Button btnOrthographicView;
    }
}

