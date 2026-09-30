namespace VIZCore3DX.NET.UDA
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
            this.lvAttribute = new System.Windows.Forms.ListView();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAttribute = new System.Windows.Forms.TabPage();
            this.tabPageTree = new System.Windows.Forms.TabPage();
            this.tvUdaTree = new System.Windows.Forms.TreeView();
            this.lblTreeInfo = new System.Windows.Forms.Label();
            this.pnlTreeTop = new System.Windows.Forms.Panel();
            this.tlpTreeButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetTree = new System.Windows.Forms.Button();
            this.btnExportTree = new System.Windows.Forms.Button();
            this.btnExportMatrix = new System.Windows.Forms.Button();
            this.chkMatrixSelectedOnly = new System.Windows.Forms.CheckBox();
            this.tabPageDistribution = new System.Windows.Forms.TabPage();
            this.lvDistribution = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblDistInfo = new System.Windows.Forms.Label();
            this.pnlDistTop = new System.Windows.Forms.Panel();
            this.lblDistCategory = new System.Windows.Forms.Label();
            this.cmbDistCategory = new System.Windows.Forms.ComboBox();
            this.lblDistName = new System.Windows.Forms.Label();
            this.cmbDistName = new System.Windows.Forms.ComboBox();
            this.lblTopN = new System.Windows.Forms.Label();
            this.numTopN = new System.Windows.Forms.NumericUpDown();
            this.btnRefreshCategory = new System.Windows.Forms.Button();
            this.btnGetDistribution = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageAttribute.SuspendLayout();
            this.tabPageTree.SuspendLayout();
            this.pnlTreeTop.SuspendLayout();
            this.tlpTreeButtons.SuspendLayout();
            this.tabPageDistribution.SuspendLayout();
            this.pnlDistTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTopN)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1280, 760);
            this.splitContainer1.SplitterDistance = 876;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAttribute);
            this.tabControl1.Controls.Add(this.tabPageTree);
            this.tabControl1.Controls.Add(this.tabPageDistribution);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(400, 760);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageAttribute
            // 
            this.tabPageAttribute.Controls.Add(this.lvAttribute);
            this.tabPageAttribute.Location = new System.Drawing.Point(4, 22);
            this.tabPageAttribute.Name = "tabPageAttribute";
            this.tabPageAttribute.Size = new System.Drawing.Size(392, 734);
            this.tabPageAttribute.TabIndex = 0;
            this.tabPageAttribute.Text = "선택 개체 속성";
            this.tabPageAttribute.UseVisualStyleBackColor = true;
            // 
            // lvAttribute
            // 
            this.lvAttribute.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvAttribute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAttribute.FullRowSelect = true;
            this.lvAttribute.GridLines = true;
            this.lvAttribute.HideSelection = false;
            this.lvAttribute.Location = new System.Drawing.Point(0, 0);
            this.lvAttribute.Name = "lvAttribute";
            this.lvAttribute.Size = new System.Drawing.Size(392, 734);
            this.lvAttribute.TabIndex = 0;
            this.lvAttribute.UseCompatibleStateImageBehavior = false;
            this.lvAttribute.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Key";
            this.columnHeader1.Width = 170;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 200;
            // 
            // tabPageTree
            // 
            this.tabPageTree.Controls.Add(this.tvUdaTree);
            this.tabPageTree.Controls.Add(this.lblTreeInfo);
            this.tabPageTree.Controls.Add(this.pnlTreeTop);
            this.tabPageTree.Location = new System.Drawing.Point(4, 22);
            this.tabPageTree.Name = "tabPageTree";
            this.tabPageTree.Size = new System.Drawing.Size(392, 734);
            this.tabPageTree.TabIndex = 1;
            this.tabPageTree.Text = "속성 트리";
            this.tabPageTree.UseVisualStyleBackColor = true;
            // 
            // tvUdaTree
            // 
            this.tvUdaTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvUdaTree.HideSelection = false;
            this.tvUdaTree.Location = new System.Drawing.Point(0, 84);
            this.tvUdaTree.Name = "tvUdaTree";
            this.tvUdaTree.Size = new System.Drawing.Size(392, 628);
            this.tvUdaTree.TabIndex = 1;
            this.tvUdaTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvUdaTree_NodeMouseDoubleClick);
            // 
            // lblTreeInfo
            // 
            this.lblTreeInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTreeInfo.Location = new System.Drawing.Point(0, 712);
            this.lblTreeInfo.Name = "lblTreeInfo";
            this.lblTreeInfo.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblTreeInfo.Size = new System.Drawing.Size(392, 22);
            this.lblTreeInfo.TabIndex = 2;
            this.lblTreeInfo.Text = "카테고리 > 키 (값 종류 수) > 값 (노드 수)";
            this.lblTreeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTreeTop
            // 
            this.pnlTreeTop.Controls.Add(this.tlpTreeButtons);
            this.pnlTreeTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTreeTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTreeTop.Name = "pnlTreeTop";
            this.pnlTreeTop.Size = new System.Drawing.Size(392, 84);
            this.pnlTreeTop.TabIndex = 0;
            // 
            // tlpTreeButtons
            // 
            this.tlpTreeButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpTreeButtons.ColumnCount = 2;
            this.tlpTreeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTreeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTreeButtons.Controls.Add(this.btnGetTree, 0, 0);
            this.tlpTreeButtons.Controls.Add(this.btnExportTree, 1, 0);
            this.tlpTreeButtons.Controls.Add(this.btnExportMatrix, 0, 1);
            this.tlpTreeButtons.Controls.Add(this.chkMatrixSelectedOnly, 1, 1);
            this.tlpTreeButtons.Location = new System.Drawing.Point(5, 6);
            this.tlpTreeButtons.Name = "tlpTreeButtons";
            this.tlpTreeButtons.RowCount = 2;
            this.tlpTreeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTreeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTreeButtons.Size = new System.Drawing.Size(382, 72);
            this.tlpTreeButtons.TabIndex = 0;
            // 
            // btnGetTree
            // 
            this.btnGetTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetTree.Location = new System.Drawing.Point(3, 3);
            this.btnGetTree.Name = "btnGetTree";
            this.btnGetTree.Size = new System.Drawing.Size(185, 30);
            this.btnGetTree.TabIndex = 0;
            this.btnGetTree.Text = "트리 조회";
            this.btnGetTree.UseVisualStyleBackColor = true;
            this.btnGetTree.Click += new System.EventHandler(this.btnGetTree_Click);
            // 
            // btnExportTree
            // 
            this.btnExportTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportTree.Location = new System.Drawing.Point(194, 3);
            this.btnExportTree.Name = "btnExportTree";
            this.btnExportTree.Size = new System.Drawing.Size(185, 30);
            this.btnExportTree.TabIndex = 1;
            this.btnExportTree.Text = "트리 내보내기";
            this.btnExportTree.UseVisualStyleBackColor = true;
            this.btnExportTree.Click += new System.EventHandler(this.btnExportTree_Click);
            // 
            // btnExportMatrix
            // 
            this.btnExportMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportMatrix.Location = new System.Drawing.Point(3, 39);
            this.btnExportMatrix.Name = "btnExportMatrix";
            this.btnExportMatrix.Size = new System.Drawing.Size(185, 30);
            this.btnExportMatrix.TabIndex = 2;
            this.btnExportMatrix.Text = "매트릭스 내보내기";
            this.btnExportMatrix.UseVisualStyleBackColor = true;
            this.btnExportMatrix.Click += new System.EventHandler(this.btnExportMatrix_Click);
            // 
            // chkMatrixSelectedOnly
            // 
            this.chkMatrixSelectedOnly.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkMatrixSelectedOnly.AutoSize = true;
            this.chkMatrixSelectedOnly.Location = new System.Drawing.Point(200, 46);
            this.chkMatrixSelectedOnly.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.chkMatrixSelectedOnly.Name = "chkMatrixSelectedOnly";
            this.chkMatrixSelectedOnly.Size = new System.Drawing.Size(88, 16);
            this.chkMatrixSelectedOnly.TabIndex = 3;
            this.chkMatrixSelectedOnly.Text = "선택 개체만";
            this.chkMatrixSelectedOnly.UseVisualStyleBackColor = true;
            // 
            // tabPageDistribution
            // 
            this.tabPageDistribution.Controls.Add(this.lvDistribution);
            this.tabPageDistribution.Controls.Add(this.lblDistInfo);
            this.tabPageDistribution.Controls.Add(this.pnlDistTop);
            this.tabPageDistribution.Location = new System.Drawing.Point(4, 22);
            this.tabPageDistribution.Name = "tabPageDistribution";
            this.tabPageDistribution.Size = new System.Drawing.Size(392, 734);
            this.tabPageDistribution.TabIndex = 2;
            this.tabPageDistribution.Text = "값 분포";
            this.tabPageDistribution.UseVisualStyleBackColor = true;
            // 
            // lvDistribution
            // 
            this.lvDistribution.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvDistribution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDistribution.FullRowSelect = true;
            this.lvDistribution.GridLines = true;
            this.lvDistribution.HideSelection = false;
            this.lvDistribution.Location = new System.Drawing.Point(0, 108);
            this.lvDistribution.MultiSelect = false;
            this.lvDistribution.Name = "lvDistribution";
            this.lvDistribution.Size = new System.Drawing.Size(392, 604);
            this.lvDistribution.TabIndex = 1;
            this.lvDistribution.UseCompatibleStateImageBehavior = false;
            this.lvDistribution.View = System.Windows.Forms.View.Details;
            this.lvDistribution.DoubleClick += new System.EventHandler(this.lvDistribution_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "값";
            this.columnHeader3.Width = 205;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "노드 수";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "비율 (%)";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 80;
            // 
            // lblDistInfo
            // 
            this.lblDistInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDistInfo.Location = new System.Drawing.Point(0, 712);
            this.lblDistInfo.Name = "lblDistInfo";
            this.lblDistInfo.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblDistInfo.Size = new System.Drawing.Size(392, 22);
            this.lblDistInfo.TabIndex = 2;
            this.lblDistInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDistTop
            // 
            this.pnlDistTop.Controls.Add(this.lblDistCategory);
            this.pnlDistTop.Controls.Add(this.cmbDistCategory);
            this.pnlDistTop.Controls.Add(this.lblDistName);
            this.pnlDistTop.Controls.Add(this.cmbDistName);
            this.pnlDistTop.Controls.Add(this.lblTopN);
            this.pnlDistTop.Controls.Add(this.numTopN);
            this.pnlDistTop.Controls.Add(this.btnRefreshCategory);
            this.pnlDistTop.Controls.Add(this.btnGetDistribution);
            this.pnlDistTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDistTop.Location = new System.Drawing.Point(0, 0);
            this.pnlDistTop.Name = "pnlDistTop";
            this.pnlDistTop.Size = new System.Drawing.Size(392, 108);
            this.pnlDistTop.TabIndex = 0;
            // 
            // lblDistCategory
            // 
            this.lblDistCategory.AutoSize = true;
            this.lblDistCategory.Location = new System.Drawing.Point(8, 14);
            this.lblDistCategory.Name = "lblDistCategory";
            this.lblDistCategory.Size = new System.Drawing.Size(53, 12);
            this.lblDistCategory.TabIndex = 0;
            this.lblDistCategory.Text = "카테고리";
            // 
            // cmbDistCategory
            // 
            this.cmbDistCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDistCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistCategory.FormattingEnabled = true;
            this.cmbDistCategory.Location = new System.Drawing.Point(75, 10);
            this.cmbDistCategory.Name = "cmbDistCategory";
            this.cmbDistCategory.Size = new System.Drawing.Size(203, 20);
            this.cmbDistCategory.TabIndex = 1;
            this.cmbDistCategory.SelectedIndexChanged += new System.EventHandler(this.cmbDistCategory_SelectedIndexChanged);
            // 
            // lblDistName
            // 
            this.lblDistName.AutoSize = true;
            this.lblDistName.Location = new System.Drawing.Point(8, 46);
            this.lblDistName.Name = "lblDistName";
            this.lblDistName.Size = new System.Drawing.Size(57, 12);
            this.lblDistName.TabIndex = 2;
            this.lblDistName.Text = "속성 이름";
            // 
            // cmbDistName
            // 
            this.cmbDistName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDistName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistName.FormattingEnabled = true;
            this.cmbDistName.Location = new System.Drawing.Point(75, 42);
            this.cmbDistName.Name = "cmbDistName";
            this.cmbDistName.Size = new System.Drawing.Size(309, 20);
            this.cmbDistName.TabIndex = 3;
            // 
            // lblTopN
            // 
            this.lblTopN.AutoSize = true;
            this.lblTopN.Location = new System.Drawing.Point(8, 80);
            this.lblTopN.Name = "lblTopN";
            this.lblTopN.Size = new System.Drawing.Size(41, 12);
            this.lblTopN.TabIndex = 4;
            this.lblTopN.Text = "상위 N";
            // 
            // numTopN
            // 
            this.numTopN.Location = new System.Drawing.Point(75, 76);
            this.numTopN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTopN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTopN.Name = "numTopN";
            this.numTopN.Size = new System.Drawing.Size(80, 21);
            this.numTopN.TabIndex = 5;
            this.numTopN.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // btnRefreshCategory
            // 
            this.btnRefreshCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshCategory.Location = new System.Drawing.Point(284, 6);
            this.btnRefreshCategory.Name = "btnRefreshCategory";
            this.btnRefreshCategory.Size = new System.Drawing.Size(100, 28);
            this.btnRefreshCategory.TabIndex = 6;
            this.btnRefreshCategory.Text = "카테고리 갱신";
            this.btnRefreshCategory.UseVisualStyleBackColor = true;
            this.btnRefreshCategory.Click += new System.EventHandler(this.btnRefreshCategory_Click);
            // 
            // btnGetDistribution
            // 
            this.btnGetDistribution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetDistribution.Location = new System.Drawing.Point(284, 72);
            this.btnGetDistribution.Name = "btnGetDistribution";
            this.btnGetDistribution.Size = new System.Drawing.Size(100, 28);
            this.btnGetDistribution.TabIndex = 7;
            this.btnGetDistribution.Text = "분포 조회";
            this.btnGetDistribution.UseVisualStyleBackColor = true;
            this.btnGetDistribution.Click += new System.EventHandler(this.btnGetDistribution_Click);
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
            this.Text = "VIZCore3DX.NET.UDA";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageAttribute.ResumeLayout(false);
            this.tabPageTree.ResumeLayout(false);
            this.pnlTreeTop.ResumeLayout(false);
            this.tlpTreeButtons.ResumeLayout(false);
            this.tlpTreeButtons.PerformLayout();
            this.tabPageDistribution.ResumeLayout(false);
            this.pnlDistTop.ResumeLayout(false);
            this.pnlDistTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTopN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvAttribute;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAttribute;
        private System.Windows.Forms.TabPage tabPageTree;
        private System.Windows.Forms.TreeView tvUdaTree;
        private System.Windows.Forms.Label lblTreeInfo;
        private System.Windows.Forms.Panel pnlTreeTop;
        private System.Windows.Forms.TableLayoutPanel tlpTreeButtons;
        private System.Windows.Forms.Button btnGetTree;
        private System.Windows.Forms.Button btnExportTree;
        private System.Windows.Forms.Button btnExportMatrix;
        private System.Windows.Forms.CheckBox chkMatrixSelectedOnly;
        private System.Windows.Forms.TabPage tabPageDistribution;
        private System.Windows.Forms.ListView lvDistribution;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lblDistInfo;
        private System.Windows.Forms.Panel pnlDistTop;
        private System.Windows.Forms.Label lblDistCategory;
        private System.Windows.Forms.ComboBox cmbDistCategory;
        private System.Windows.Forms.Label lblDistName;
        private System.Windows.Forms.ComboBox cmbDistName;
        private System.Windows.Forms.Label lblTopN;
        private System.Windows.Forms.NumericUpDown numTopN;
        private System.Windows.Forms.Button btnRefreshCategory;
        private System.Windows.Forms.Button btnGetDistribution;
    }
}

