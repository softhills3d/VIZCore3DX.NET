namespace VIZCore3DX.NET.Note
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageSceneTree = new System.Windows.Forms.TabPage();
            this.tabPageNote = new System.Windows.Forms.TabPage();
            this.splitContainerRoot = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNote2D = new System.Windows.Forms.Button();
            this.btnSurfaceNote = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnModelTree = new System.Windows.Forms.Button();
            this.btnModelOpen = new System.Windows.Forms.Button();
            this.btnNote3D = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnHideAll = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnDeleteSelection = new System.Windows.Forms.Button();
            this.btnHideSelection = new System.Windows.Forms.Button();
            this.btnHideNonSelection = new System.Windows.Forms.Button();
            this.btnShowNonSelection = new System.Windows.Forms.Button();
            this.btnShowSelection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRoot)).BeginInit();
            this.splitContainerRoot.Panel1.SuspendLayout();
            this.splitContainerRoot.Panel2.SuspendLayout();
            this.splitContainerRoot.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.tabControlMain);
            this.splitContainerMain.Size = new System.Drawing.Size(832, 541);
            this.splitContainerMain.SplitterDistance = 200;
            this.splitContainerMain.TabIndex = 1;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlMain.Controls.Add(this.tabPageSceneTree);
            this.tabControlMain.Controls.Add(this.tabPageNote);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(200, 541);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabPageSceneTree
            // 
            this.tabPageSceneTree.ImageIndex = 0;
            this.tabPageSceneTree.Location = new System.Drawing.Point(4, 4);
            this.tabPageSceneTree.Name = "tabPageSceneTree";
            this.tabPageSceneTree.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSceneTree.Size = new System.Drawing.Size(192, 515);
            this.tabPageSceneTree.TabIndex = 0;
            this.tabPageSceneTree.Text = "씬 트리";
            this.tabPageSceneTree.UseVisualStyleBackColor = true;
            // 
            // tabPageNote
            // 
            this.tabPageNote.ImageIndex = 2;
            this.tabPageNote.Location = new System.Drawing.Point(4, 4);
            this.tabPageNote.Name = "tabPageNote";
            this.tabPageNote.Size = new System.Drawing.Size(192, 515);
            this.tabPageNote.TabIndex = 3;
            this.tabPageNote.Text = "노트";
            this.tabPageNote.UseVisualStyleBackColor = true;
            // 
            // splitContainerRoot
            // 
            this.splitContainerRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRoot.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRoot.Name = "splitContainerRoot";
            // 
            // splitContainerRoot.Panel1
            // 
            this.splitContainerRoot.Panel1.Controls.Add(this.groupBox4);
            this.splitContainerRoot.Panel1.Controls.Add(this.groupBox3);
            this.splitContainerRoot.Panel1.Controls.Add(this.btnNote3D);
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnNote2D);
            this.groupBox2.Controls.Add(this.btnSurfaceNote);
            this.groupBox2.Location = new System.Drawing.Point(3, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 115);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create";
            // 
            // btnNote2D
            // 
            this.btnNote2D.Location = new System.Drawing.Point(9, 51);
            this.btnNote2D.Name = "btnNote2D";
            this.btnNote2D.Size = new System.Drawing.Size(100, 25);
            this.btnNote2D.TabIndex = 3;
            this.btnNote2D.Text = "2D 노트";
            this.btnNote2D.UseVisualStyleBackColor = true;
            this.btnNote2D.Click += new System.EventHandler(this.btnNote2D_Click);
            // 
            // btnSurfaceNote
            // 
            this.btnSurfaceNote.Location = new System.Drawing.Point(9, 20);
            this.btnSurfaceNote.Name = "btnSurfaceNote";
            this.btnSurfaceNote.Size = new System.Drawing.Size(100, 25);
            this.btnSurfaceNote.TabIndex = 2;
            this.btnSurfaceNote.Text = "표면 노트";
            this.btnSurfaceNote.UseVisualStyleBackColor = true;
            this.btnSurfaceNote.Click += new System.EventHandler(this.btnSurfaceNote_Click);
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
            // btnNote3D
            // 
            this.btnNote3D.Location = new System.Drawing.Point(12, 178);
            this.btnNote3D.Name = "btnNote3D";
            this.btnNote3D.Size = new System.Drawing.Size(100, 25);
            this.btnNote3D.TabIndex = 4;
            this.btnNote3D.Text = "3D 노트";
            this.btnNote3D.UseVisualStyleBackColor = true;
            this.btnNote3D.Click += new System.EventHandler(this.btnNote3D_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnHideNonSelection);
            this.groupBox3.Controls.Add(this.btnShowNonSelection);
            this.groupBox3.Controls.Add(this.btnShowSelection);
            this.groupBox3.Controls.Add(this.btnHideSelection);
            this.groupBox3.Controls.Add(this.btnHideAll);
            this.groupBox3.Controls.Add(this.btnShowAll);
            this.groupBox3.Location = new System.Drawing.Point(3, 226);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(114, 209);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Show";
            // 
            // btnHideAll
            // 
            this.btnHideAll.Location = new System.Drawing.Point(9, 51);
            this.btnHideAll.Name = "btnHideAll";
            this.btnHideAll.Size = new System.Drawing.Size(100, 25);
            this.btnHideAll.TabIndex = 3;
            this.btnHideAll.Text = "모두 숨기기";
            this.btnHideAll.UseVisualStyleBackColor = true;
            this.btnHideAll.Click += new System.EventHandler(this.btnHideAll_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(9, 20);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(100, 25);
            this.btnShowAll.TabIndex = 2;
            this.btnShowAll.Text = "모두 보이기";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnDeleteAll);
            this.groupBox4.Controls.Add(this.btnDeleteSelection);
            this.groupBox4.Location = new System.Drawing.Point(4, 451);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(114, 78);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Delete";
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(9, 47);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(100, 25);
            this.btnDeleteAll.TabIndex = 3;
            this.btnDeleteAll.Text = "전체 삭제";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnDeleteSelection
            // 
            this.btnDeleteSelection.Location = new System.Drawing.Point(9, 20);
            this.btnDeleteSelection.Name = "btnDeleteSelection";
            this.btnDeleteSelection.Size = new System.Drawing.Size(100, 25);
            this.btnDeleteSelection.TabIndex = 2;
            this.btnDeleteSelection.Text = "선택 삭제";
            this.btnDeleteSelection.UseVisualStyleBackColor = true;
            this.btnDeleteSelection.Click += new System.EventHandler(this.btnDeleteSelection_Click);
            // 
            // btnHideSelection
            // 
            this.btnHideSelection.Location = new System.Drawing.Point(8, 113);
            this.btnHideSelection.Name = "btnHideSelection";
            this.btnHideSelection.Size = new System.Drawing.Size(100, 25);
            this.btnHideSelection.TabIndex = 4;
            this.btnHideSelection.Text = "선택 숨기기";
            this.btnHideSelection.UseVisualStyleBackColor = true;
            this.btnHideSelection.Click += new System.EventHandler(this.btnHideSelection_Click);
            // 
            // btnHideNonSelection
            // 
            this.btnHideNonSelection.Location = new System.Drawing.Point(9, 175);
            this.btnHideNonSelection.Name = "btnHideNonSelection";
            this.btnHideNonSelection.Size = new System.Drawing.Size(100, 25);
            this.btnHideNonSelection.TabIndex = 5;
            this.btnHideNonSelection.Text = "비선택 숨기기";
            this.btnHideNonSelection.UseVisualStyleBackColor = true;
            this.btnHideNonSelection.Click += new System.EventHandler(this.btnHideNonSelection_Click);
            // 
            // btnShowNonSelection
            // 
            this.btnShowNonSelection.Location = new System.Drawing.Point(9, 144);
            this.btnShowNonSelection.Name = "btnShowNonSelection";
            this.btnShowNonSelection.Size = new System.Drawing.Size(100, 25);
            this.btnShowNonSelection.TabIndex = 7;
            this.btnShowNonSelection.Text = "비선택 보이기";
            this.btnShowNonSelection.UseVisualStyleBackColor = true;
            this.btnShowNonSelection.Click += new System.EventHandler(this.btnShowNonSelection_Click);
            // 
            // btnShowSelection
            // 
            this.btnShowSelection.Location = new System.Drawing.Point(9, 82);
            this.btnShowSelection.Name = "btnShowSelection";
            this.btnShowSelection.Size = new System.Drawing.Size(100, 25);
            this.btnShowSelection.TabIndex = 6;
            this.btnShowSelection.Text = "선택 보이기";
            this.btnShowSelection.UseVisualStyleBackColor = true;
            this.btnShowSelection.Click += new System.EventHandler(this.btnShowSelection_Click);
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
            this.Text = "VIZCore3DX.NET.Note";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.splitContainerRoot.Panel1.ResumeLayout(false);
            this.splitContainerRoot.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRoot)).EndInit();
            this.splitContainerRoot.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerRoot;
        private System.Windows.Forms.Button btnModelTree;
        private System.Windows.Forms.Button btnModelOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNote2D;
        private System.Windows.Forms.Button btnSurfaceNote;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageSceneTree;
        private System.Windows.Forms.TabPage tabPageNote;
        private System.Windows.Forms.Button btnNote3D;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnDeleteSelection;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnHideSelection;
        private System.Windows.Forms.Button btnHideAll;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnShowNonSelection;
        private System.Windows.Forms.Button btnShowSelection;
        private System.Windows.Forms.Button btnHideNonSelection;
    }
}

