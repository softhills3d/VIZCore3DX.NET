namespace VIZCore3DX.NET.DemoLauncher
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.splMain = new System.Windows.Forms.SplitContainer();
            this.tvList = new System.Windows.Forms.TreeView();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.lvGrid = new System.Windows.Forms.ListView();
            this.lblDesc = new System.Windows.Forms.Label();
            this.pnlFoot = new System.Windows.Forms.Panel();
            this.lblState = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.pnlGap = new System.Windows.Forms.Panel();
            this.btnRun = new System.Windows.Forms.Button();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel1.SuspendLayout();
            this.splMain.Panel2.SuspendLayout();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.pnlFoot.SuspendLayout();
            this.pnlHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(12, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.pnlTop.Size = new System.Drawing.Size(1209, 32);
            this.pnlTop.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(40, 6);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1169, 21);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSearch.Location = new System.Drawing.Point(0, 6);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(40, 20);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "검색";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblCount);
            this.pnlBottom.Controls.Add(this.btnExit);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(12, 549);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlBottom.Size = new System.Drawing.Size(1209, 34);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblCount
            // 
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCount.Location = new System.Drawing.Point(0, 5);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(1079, 24);
            this.lblCount.TabIndex = 0;
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.Enabled = false;
            this.btnExit.Location = new System.Drawing.Point(1079, 5);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(130, 24);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "실행 창 종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // splMain
            // 
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.Location = new System.Drawing.Point(12, 32);
            this.splMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splMain.Name = "splMain";
            // 
            // splMain.Panel1
            // 
            this.splMain.Panel1.Controls.Add(this.tvList);
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.Controls.Add(this.pbPreview);
            this.splMain.Panel2.Controls.Add(this.lvGrid);
            this.splMain.Panel2.Controls.Add(this.lblDesc);
            this.splMain.Panel2.Controls.Add(this.pnlFoot);
            this.splMain.Panel2.Controls.Add(this.pnlHead);
            this.splMain.Panel2.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.splMain.Size = new System.Drawing.Size(1209, 517);
            this.splMain.SplitterDistance = 432;
            this.splMain.TabIndex = 0;
            // 
            // tvList
            // 
            this.tvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvList.HideSelection = false;
            this.tvList.Location = new System.Drawing.Point(0, 0);
            this.tvList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tvList.Name = "tvList";
            this.tvList.ShowNodeToolTips = true;
            this.tvList.Size = new System.Drawing.Size(432, 517);
            this.tvList.TabIndex = 0;
            this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
            // 
            // pbPreview
            // 
            this.pbPreview.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.Location = new System.Drawing.Point(16, 61);
            this.pbPreview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(757, 323);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            this.pbPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pbPreview_Paint);
            // 
            // lvGrid
            // 
            this.lvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGrid.HideSelection = false;
            this.lvGrid.Location = new System.Drawing.Point(16, 61);
            this.lvGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvGrid.MultiSelect = false;
            this.lvGrid.Name = "lvGrid";
            this.lvGrid.ShowItemToolTips = true;
            this.lvGrid.Size = new System.Drawing.Size(757, 323);
            this.lvGrid.TabIndex = 1;
            this.lvGrid.UseCompatibleStateImageBehavior = false;
            this.lvGrid.Visible = false;
            this.lvGrid.ItemActivate += new System.EventHandler(this.lvGrid_ItemActivate);
            this.lvGrid.Click += new System.EventHandler(this.lvGrid_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDesc.Location = new System.Drawing.Point(16, 384);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblDesc.Size = new System.Drawing.Size(757, 88);
            this.lblDesc.TabIndex = 2;
            // 
            // pnlFoot
            // 
            this.pnlFoot.Controls.Add(this.lblState);
            this.pnlFoot.Controls.Add(this.btnCapture);
            this.pnlFoot.Controls.Add(this.pnlGap);
            this.pnlFoot.Controls.Add(this.btnRun);
            this.pnlFoot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFoot.Location = new System.Drawing.Point(16, 472);
            this.pnlFoot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlFoot.Name = "pnlFoot";
            this.pnlFoot.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.pnlFoot.Size = new System.Drawing.Size(757, 45);
            this.pnlFoot.TabIndex = 3;
            // 
            // lblState
            // 
            this.lblState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblState.Location = new System.Drawing.Point(0, 6);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(479, 33);
            this.lblState.TabIndex = 0;
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCapture
            // 
            this.btnCapture.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCapture.Enabled = false;
            this.btnCapture.Location = new System.Drawing.Point(479, 6);
            this.btnCapture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(150, 33);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "실행 중 화면 캡처";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // pnlGap
            // 
            this.pnlGap.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlGap.Location = new System.Drawing.Point(629, 6);
            this.pnlGap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlGap.Name = "pnlGap";
            this.pnlGap.Size = new System.Drawing.Size(8, 33);
            this.pnlGap.TabIndex = 2;
            // 
            // btnRun
            // 
            this.btnRun.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRun.Enabled = false;
            this.btnRun.Location = new System.Drawing.Point(637, 6);
            this.btnRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(120, 33);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "실행";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // pnlHead
            // 
            this.pnlHead.Controls.Add(this.lblName);
            this.pnlHead.Controls.Add(this.lblCategory);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(16, 0);
            this.pnlHead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(757, 61);
            this.pnlHead.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(0, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(757, 39);
            this.lblName.TabIndex = 0;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCategory
            // 
            this.lblCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCategory.ForeColor = System.Drawing.Color.DimGray;
            this.lblCategory.Location = new System.Drawing.Point(0, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblCategory.Size = new System.Drawing.Size(757, 22);
            this.lblCategory.TabIndex = 1;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 583);
            this.Controls.Add(this.splMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET 통합 Demo";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.splMain.Panel1.ResumeLayout(false);
            this.splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.pnlFoot.ResumeLayout(false);
            this.pnlHead.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.SplitContainer splMain;
        private System.Windows.Forms.TreeView tvList;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.ListView lvGrid;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Panel pnlFoot;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Panel pnlGap;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblName;
    }
}
