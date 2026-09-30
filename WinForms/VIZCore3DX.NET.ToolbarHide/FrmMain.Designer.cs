namespace VIZCore3DX.NET.ToolbarHide
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
            this.cbToolbarList = new System.Windows.Forms.ComboBox();
            this.tlpShowHide = new System.Windows.Forms.TableLayoutPanel();
            this.btnToolbarShow = new System.Windows.Forms.Button();
            this.btnToolbarHide = new System.Windows.Forms.Button();
            this.lvToolbar = new System.Windows.Forms.ListView();
            this.btnGetToolbarList = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tlpModel = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.btnAddModels = new System.Windows.Forms.Button();
            this.btnCloseModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tlpShowHide.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tlpModel.SuspendLayout();
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
            this.splitContainer1.Panel1MinSize = 280;
            this.splitContainer1.Size = new System.Drawing.Size(1280, 760);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbToolbarList);
            this.groupBox1.Controls.Add(this.btnGetToolbarList);
            this.groupBox1.Controls.Add(this.lvToolbar);
            this.groupBox1.Controls.Add(this.tlpShowHide);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 652);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Toolbar Setting";
            // 
            // cbToolbarList
            // 
            this.cbToolbarList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbToolbarList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbToolbarList.FormattingEnabled = true;
            this.cbToolbarList.Location = new System.Drawing.Point(12, 24);
            this.cbToolbarList.Name = "cbToolbarList";
            this.cbToolbarList.Size = new System.Drawing.Size(332, 20);
            this.cbToolbarList.TabIndex = 0;
            // 
            // btnGetToolbarList
            // 
            this.btnGetToolbarList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetToolbarList.Location = new System.Drawing.Point(12, 52);
            this.btnGetToolbarList.Name = "btnGetToolbarList";
            this.btnGetToolbarList.Size = new System.Drawing.Size(332, 30);
            this.btnGetToolbarList.TabIndex = 1;
            this.btnGetToolbarList.Text = "Get Toolbar List";
            this.btnGetToolbarList.UseVisualStyleBackColor = true;
            this.btnGetToolbarList.Click += new System.EventHandler(this.btnGetToolbarList_Click);
            // 
            // lvToolbar
            // 
            this.lvToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvToolbar.HideSelection = false;
            this.lvToolbar.Location = new System.Drawing.Point(12, 90);
            this.lvToolbar.Name = "lvToolbar";
            this.lvToolbar.Size = new System.Drawing.Size(332, 504);
            this.lvToolbar.TabIndex = 2;
            this.lvToolbar.UseCompatibleStateImageBehavior = false;
            // 
            // tlpShowHide
            // 
            this.tlpShowHide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpShowHide.ColumnCount = 2;
            this.tlpShowHide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpShowHide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpShowHide.Controls.Add(this.btnToolbarShow, 0, 0);
            this.tlpShowHide.Controls.Add(this.btnToolbarHide, 1, 0);
            this.tlpShowHide.Location = new System.Drawing.Point(9, 599);
            this.tlpShowHide.Name = "tlpShowHide";
            this.tlpShowHide.RowCount = 1;
            this.tlpShowHide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShowHide.Size = new System.Drawing.Size(338, 38);
            this.tlpShowHide.TabIndex = 3;
            // 
            // btnToolbarShow
            // 
            this.btnToolbarShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToolbarShow.Location = new System.Drawing.Point(3, 3);
            this.btnToolbarShow.Name = "btnToolbarShow";
            this.btnToolbarShow.Size = new System.Drawing.Size(163, 32);
            this.btnToolbarShow.TabIndex = 0;
            this.btnToolbarShow.Text = "Show Selected";
            this.btnToolbarShow.UseVisualStyleBackColor = true;
            this.btnToolbarShow.Click += new System.EventHandler(this.btnToolbarShow_Click);
            // 
            // btnToolbarHide
            // 
            this.btnToolbarHide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToolbarHide.Location = new System.Drawing.Point(172, 3);
            this.btnToolbarHide.Name = "btnToolbarHide";
            this.btnToolbarHide.Size = new System.Drawing.Size(163, 32);
            this.btnToolbarHide.TabIndex = 1;
            this.btnToolbarHide.Text = "Hide Selected";
            this.btnToolbarHide.UseVisualStyleBackColor = true;
            this.btnToolbarHide.Click += new System.EventHandler(this.btnToolbarHide_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tlpModel);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 76);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Model";
            // 
            // tlpModel
            // 
            this.tlpModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpModel.ColumnCount = 3;
            this.tlpModel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpModel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpModel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpModel.Controls.Add(this.btnOpenModel, 0, 0);
            this.tlpModel.Controls.Add(this.btnAddModels, 1, 0);
            this.tlpModel.Controls.Add(this.btnCloseModel, 2, 0);
            this.tlpModel.Location = new System.Drawing.Point(9, 24);
            this.tlpModel.Name = "tlpModel";
            this.tlpModel.RowCount = 1;
            this.tlpModel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpModel.Size = new System.Drawing.Size(338, 38);
            this.tlpModel.TabIndex = 0;
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenModel.Location = new System.Drawing.Point(3, 3);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(106, 32);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "Open";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // btnAddModels
            // 
            this.btnAddModels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddModels.Location = new System.Drawing.Point(115, 3);
            this.btnAddModels.Name = "btnAddModels";
            this.btnAddModels.Size = new System.Drawing.Size(106, 32);
            this.btnAddModels.TabIndex = 1;
            this.btnAddModels.Text = "Add";
            this.btnAddModels.UseVisualStyleBackColor = true;
            this.btnAddModels.Click += new System.EventHandler(this.btnAddModels_Click);
            // 
            // btnCloseModel
            // 
            this.btnCloseModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCloseModel.Location = new System.Drawing.Point(227, 3);
            this.btnCloseModel.Name = "btnCloseModel";
            this.btnCloseModel.Size = new System.Drawing.Size(108, 32);
            this.btnCloseModel.TabIndex = 2;
            this.btnCloseModel.Text = "Close";
            this.btnCloseModel.UseVisualStyleBackColor = true;
            this.btnCloseModel.Click += new System.EventHandler(this.btnCloseModel_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.ToolbarHide";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tlpShowHide.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tlpModel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tlpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Button btnAddModels;
        private System.Windows.Forms.Button btnCloseModel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGetToolbarList;
        private System.Windows.Forms.ListView lvToolbar;
        private System.Windows.Forms.TableLayoutPanel tlpShowHide;
        private System.Windows.Forms.Button btnToolbarShow;
        private System.Windows.Forms.Button btnToolbarHide;
        private System.Windows.Forms.ComboBox cbToolbarList;
    }
}

