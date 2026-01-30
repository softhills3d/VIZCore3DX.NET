namespace VIZCore3DX.NET.SearchSpace
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
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSetBoundbox = new System.Windows.Forms.Button();
            this.numMaxZ = new System.Windows.Forms.NumericUpDown();
            this.numMaxY = new System.Windows.Forms.NumericUpDown();
            this.numMaxX = new System.Windows.Forms.NumericUpDown();
            this.numMinZ = new System.Windows.Forms.NumericUpDown();
            this.numMinY = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numMinX = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckIncludingPartOnly = new System.Windows.Forms.CheckBox();
            this.ckFullyContained = new System.Windows.Forms.CheckBox();
            this.ckIncludingPart = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gvResult = new System.Windows.Forms.DataGridView();
            this.group1NodeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinX)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1130, 687);
            this.splitContainer1.SplitterDistance = 376;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnExport);
            this.groupBox4.Controls.Add(this.btnSearch);
            this.groupBox4.Location = new System.Drawing.Point(12, 490);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(355, 74);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search / Export";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(202, 29);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(129, 23);
            this.btnExport.TabIndex = 32;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(17, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSetBoundbox);
            this.groupBox3.Controls.Add(this.numMaxZ);
            this.groupBox3.Controls.Add(this.numMaxY);
            this.groupBox3.Controls.Add(this.numMaxX);
            this.groupBox3.Controls.Add(this.numMinZ);
            this.groupBox3.Controls.Add(this.numMinY);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.numMinX);
            this.groupBox3.Location = new System.Drawing.Point(12, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(355, 306);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Boundbox";
            // 
            // btnSetBoundbox
            // 
            this.btnSetBoundbox.Location = new System.Drawing.Point(17, 258);
            this.btnSetBoundbox.Name = "btnSetBoundbox";
            this.btnSetBoundbox.Size = new System.Drawing.Size(314, 23);
            this.btnSetBoundbox.TabIndex = 31;
            this.btnSetBoundbox.Text = "Set BoundBox";
            this.btnSetBoundbox.UseVisualStyleBackColor = true;
            this.btnSetBoundbox.Click += new System.EventHandler(this.btnSetBoundbox_Click);
            // 
            // numMaxZ
            // 
            this.numMaxZ.DecimalPlaces = 2;
            this.numMaxZ.Location = new System.Drawing.Point(60, 215);
            this.numMaxZ.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numMaxZ.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.numMaxZ.Name = "numMaxZ";
            this.numMaxZ.Size = new System.Drawing.Size(271, 21);
            this.numMaxZ.TabIndex = 30;
            // 
            // numMaxY
            // 
            this.numMaxY.DecimalPlaces = 2;
            this.numMaxY.Location = new System.Drawing.Point(60, 190);
            this.numMaxY.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numMaxY.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.numMaxY.Name = "numMaxY";
            this.numMaxY.Size = new System.Drawing.Size(271, 21);
            this.numMaxY.TabIndex = 29;
            // 
            // numMaxX
            // 
            this.numMaxX.DecimalPlaces = 2;
            this.numMaxX.Location = new System.Drawing.Point(60, 165);
            this.numMaxX.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numMaxX.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.numMaxX.Name = "numMaxX";
            this.numMaxX.Size = new System.Drawing.Size(271, 21);
            this.numMaxX.TabIndex = 28;
            // 
            // numMinZ
            // 
            this.numMinZ.DecimalPlaces = 2;
            this.numMinZ.Location = new System.Drawing.Point(60, 102);
            this.numMinZ.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numMinZ.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.numMinZ.Name = "numMinZ";
            this.numMinZ.Size = new System.Drawing.Size(271, 21);
            this.numMinZ.TabIndex = 27;
            // 
            // numMinY
            // 
            this.numMinY.DecimalPlaces = 2;
            this.numMinY.Location = new System.Drawing.Point(60, 77);
            this.numMinY.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numMinY.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.numMinY.Name = "numMinY";
            this.numMinY.Size = new System.Drawing.Size(271, 21);
            this.numMinY.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "Y : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "X : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "Z : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "Y : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "Min.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "X : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "Z : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "Max.";
            // 
            // numMinX
            // 
            this.numMinX.DecimalPlaces = 2;
            this.numMinX.Location = new System.Drawing.Point(60, 52);
            this.numMinX.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numMinX.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.numMinX.Name = "numMinX";
            this.numMinX.Size = new System.Drawing.Size(271, 21);
            this.numMinX.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ckIncludingPartOnly);
            this.groupBox2.Controls.Add(this.ckFullyContained);
            this.groupBox2.Controls.Add(this.ckIncludingPart);
            this.groupBox2.Location = new System.Drawing.Point(12, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 96);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option";
            // 
            // ckIncludingPartOnly
            // 
            this.ckIncludingPartOnly.AutoSize = true;
            this.ckIncludingPartOnly.Location = new System.Drawing.Point(20, 67);
            this.ckIncludingPartOnly.Name = "ckIncludingPartOnly";
            this.ckIncludingPartOnly.Size = new System.Drawing.Size(88, 16);
            this.ckIncludingPartOnly.TabIndex = 12;
            this.ckIncludingPartOnly.Text = "걸친 개체만";
            this.ckIncludingPartOnly.UseVisualStyleBackColor = true;
            this.ckIncludingPartOnly.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // ckFullyContained
            // 
            this.ckFullyContained.AutoSize = true;
            this.ckFullyContained.Checked = true;
            this.ckFullyContained.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckFullyContained.Location = new System.Drawing.Point(21, 23);
            this.ckFullyContained.Name = "ckFullyContained";
            this.ckFullyContained.Size = new System.Drawing.Size(140, 16);
            this.ckFullyContained.TabIndex = 11;
            this.ckFullyContained.Text = "완전히 포함된 개체만";
            this.ckFullyContained.UseVisualStyleBackColor = true;
            this.ckFullyContained.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // ckIncludingPart
            // 
            this.ckIncludingPart.AutoSize = true;
            this.ckIncludingPart.Location = new System.Drawing.Point(21, 45);
            this.ckIncludingPart.Name = "ckIncludingPart";
            this.ckIncludingPart.Size = new System.Drawing.Size(104, 16);
            this.ckIncludingPart.TabIndex = 10;
            this.ckIncludingPart.Text = "걸친 개체 포함";
            this.ckIncludingPart.UseVisualStyleBackColor = true;
            this.ckIncludingPart.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnOpenModel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Open";
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Location = new System.Drawing.Point(33, 20);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(75, 23);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "Model";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gvResult);
            this.splitContainer2.Size = new System.Drawing.Size(750, 687);
            this.splitContainer2.SplitterDistance = 461;
            this.splitContainer2.TabIndex = 0;
            // 
            // gvResult
            // 
            this.gvResult.AllowUserToAddRows = false;
            this.gvResult.AllowUserToDeleteRows = false;
            this.gvResult.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.group1NodeType,
            this.Column3,
            this.Column1});
            this.gvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvResult.Location = new System.Drawing.Point(0, 0);
            this.gvResult.Name = "gvResult";
            this.gvResult.RowTemplate.Height = 23;
            this.gvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvResult.Size = new System.Drawing.Size(750, 222);
            this.gvResult.TabIndex = 0;
            this.gvResult.VirtualMode = true;
            this.gvResult.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.gvResult_CellValueChanged);
            this.gvResult.SelectionChanged += new System.EventHandler(this.gvResult_SelectionChanged);
            // 
            // group1NodeType
            // 
            this.group1NodeType.HeaderText = "Entity ID";
            this.group1NodeType.Name = "group1NodeType";
            this.group1NodeType.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Index";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 150F;
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 687);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.SearchSpace";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numMinX;
        private System.Windows.Forms.DataGridView gvResult;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox ckIncludingPartOnly;
        private System.Windows.Forms.CheckBox ckFullyContained;
        private System.Windows.Forms.CheckBox ckIncludingPart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numMaxZ;
        private System.Windows.Forms.NumericUpDown numMaxY;
        private System.Windows.Forms.NumericUpDown numMaxX;
        private System.Windows.Forms.NumericUpDown numMinZ;
        private System.Windows.Forms.NumericUpDown numMinY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSetBoundbox;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn group1NodeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}

