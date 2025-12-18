namespace VIZCore3DX.NET.ClashTest
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbClashTestId = new System.Windows.Forms.ComboBox();
            this.ckIdentity = new System.Windows.Forms.CheckBox();
            this.ckClash = new System.Windows.Forms.CheckBox();
            this.ckContact = new System.Windows.Forms.CheckBox();
            this.ckProximity = new System.Windows.Forms.CheckBox();
            this.ckClearance = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddGroupB = new System.Windows.Forms.Button();
            this.btnAddGroupA = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numPenetrationTolerance = new System.Windows.Forms.NumericUpDown();
            this.numRangeValue = new System.Windows.Forms.NumericUpDown();
            this.numClearanceValue = new System.Windows.Forms.NumericUpDown();
            this.ckUseRangeValue = new System.Windows.Forms.CheckBox();
            this.ckUseClearanceValue = new System.Windows.Forms.CheckBox();
            this.cbClashTestKind = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.datagridviewInterferenceResult = new System.Windows.Forms.DataGridView();
            this.group1NodeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPenetrationTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClearanceValue)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewInterferenceResult)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.cbClashTestId);
            this.groupBox5.Controls.Add(this.ckIdentity);
            this.groupBox5.Controls.Add(this.ckClash);
            this.groupBox5.Controls.Add(this.ckContact);
            this.groupBox5.Controls.Add(this.ckProximity);
            this.groupBox5.Controls.Add(this.ckClearance);
            this.groupBox5.Location = new System.Drawing.Point(12, 349);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(355, 106);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Result Option";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "ClashTest ID";
            // 
            // cbClashTestId
            // 
            this.cbClashTestId.FormattingEnabled = true;
            this.cbClashTestId.Location = new System.Drawing.Point(108, 65);
            this.cbClashTestId.Name = "cbClashTestId";
            this.cbClashTestId.Size = new System.Drawing.Size(183, 20);
            this.cbClashTestId.TabIndex = 6;
            this.cbClashTestId.SelectedIndexChanged += new System.EventHandler(this.checkInterferenceStatus_CheckedChanged);
            // 
            // ckIdentity
            // 
            this.ckIdentity.AutoSize = true;
            this.ckIdentity.Checked = true;
            this.ckIdentity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIdentity.Location = new System.Drawing.Point(232, 31);
            this.ckIdentity.Name = "ckIdentity";
            this.ckIdentity.Size = new System.Drawing.Size(48, 16);
            this.ckIdentity.TabIndex = 7;
            this.ckIdentity.Text = "동일";
            this.ckIdentity.UseVisualStyleBackColor = true;
            this.ckIdentity.AppearanceChanged += new System.EventHandler(this.checkInterferenceStatus_CheckedChanged);
            // 
            // ckClash
            // 
            this.ckClash.AutoSize = true;
            this.ckClash.Checked = true;
            this.ckClash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckClash.Location = new System.Drawing.Point(178, 31);
            this.ckClash.Name = "ckClash";
            this.ckClash.Size = new System.Drawing.Size(48, 16);
            this.ckClash.TabIndex = 6;
            this.ckClash.Text = "충돌";
            this.ckClash.UseVisualStyleBackColor = true;
            this.ckClash.CheckedChanged += new System.EventHandler(this.checkInterferenceStatus_CheckedChanged);
            // 
            // ckContact
            // 
            this.ckContact.AutoSize = true;
            this.ckContact.Checked = true;
            this.ckContact.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckContact.Location = new System.Drawing.Point(124, 31);
            this.ckContact.Name = "ckContact";
            this.ckContact.Size = new System.Drawing.Size(48, 16);
            this.ckContact.TabIndex = 5;
            this.ckContact.Text = "접촉";
            this.ckContact.UseVisualStyleBackColor = true;
            this.ckContact.CheckedChanged += new System.EventHandler(this.checkInterferenceStatus_CheckedChanged);
            // 
            // ckProximity
            // 
            this.ckProximity.AutoSize = true;
            this.ckProximity.Checked = true;
            this.ckProximity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckProximity.Location = new System.Drawing.Point(70, 31);
            this.ckProximity.Name = "ckProximity";
            this.ckProximity.Size = new System.Drawing.Size(48, 16);
            this.ckProximity.TabIndex = 4;
            this.ckProximity.Text = "근접";
            this.ckProximity.UseVisualStyleBackColor = true;
            this.ckProximity.CheckedChanged += new System.EventHandler(this.checkInterferenceStatus_CheckedChanged);
            // 
            // ckClearance
            // 
            this.ckClearance.AutoSize = true;
            this.ckClearance.Checked = true;
            this.ckClearance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckClearance.Location = new System.Drawing.Point(21, 31);
            this.ckClearance.Name = "ckClearance";
            this.ckClearance.Size = new System.Drawing.Size(48, 16);
            this.ckClearance.TabIndex = 3;
            this.ckClearance.Text = "여유";
            this.ckClearance.UseVisualStyleBackColor = true;
            this.ckClearance.CheckedChanged += new System.EventHandler(this.checkInterferenceStatus_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDelete);
            this.groupBox4.Controls.Add(this.btnExit);
            this.groupBox4.Controls.Add(this.btnStart);
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Location = new System.Drawing.Point(12, 290);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(355, 53);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Clash";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(99, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(73, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Del";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(257, 20);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(73, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(178, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(73, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(22, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(73, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAddGroupB);
            this.groupBox3.Controls.Add(this.btnAddGroupA);
            this.groupBox3.Location = new System.Drawing.Point(12, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(355, 60);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Group";
            // 
            // btnAddGroupB
            // 
            this.btnAddGroupB.Location = new System.Drawing.Point(201, 24);
            this.btnAddGroupB.Name = "btnAddGroupB";
            this.btnAddGroupB.Size = new System.Drawing.Size(121, 23);
            this.btnAddGroupB.TabIndex = 8;
            this.btnAddGroupB.Text = "Add Group B";
            this.btnAddGroupB.UseVisualStyleBackColor = true;
            this.btnAddGroupB.Click += new System.EventHandler(this.btnAddGroupB_Click);
            // 
            // btnAddGroupA
            // 
            this.btnAddGroupA.Location = new System.Drawing.Point(22, 24);
            this.btnAddGroupA.Name = "btnAddGroupA";
            this.btnAddGroupA.Size = new System.Drawing.Size(121, 23);
            this.btnAddGroupA.TabIndex = 7;
            this.btnAddGroupA.Text = "Add Group A";
            this.btnAddGroupA.UseVisualStyleBackColor = true;
            this.btnAddGroupA.Click += new System.EventHandler(this.btnAddGroupA_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numPenetrationTolerance);
            this.groupBox2.Controls.Add(this.numRangeValue);
            this.groupBox2.Controls.Add(this.numClearanceValue);
            this.groupBox2.Controls.Add(this.ckUseRangeValue);
            this.groupBox2.Controls.Add(this.ckUseClearanceValue);
            this.groupBox2.Controls.Add(this.cbClashTestKind);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 142);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "접촉허용오차";
            // 
            // numPenetrationTolerance
            // 
            this.numPenetrationTolerance.DecimalPlaces = 2;
            this.numPenetrationTolerance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numPenetrationTolerance.Location = new System.Drawing.Point(141, 105);
            this.numPenetrationTolerance.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numPenetrationTolerance.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numPenetrationTolerance.Name = "numPenetrationTolerance";
            this.numPenetrationTolerance.Size = new System.Drawing.Size(120, 21);
            this.numPenetrationTolerance.TabIndex = 6;
            this.numPenetrationTolerance.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147352576});
            // 
            // numRangeValue
            // 
            this.numRangeValue.Location = new System.Drawing.Point(141, 78);
            this.numRangeValue.Name = "numRangeValue";
            this.numRangeValue.Size = new System.Drawing.Size(120, 21);
            this.numRangeValue.TabIndex = 5;
            this.numRangeValue.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numClearanceValue
            // 
            this.numClearanceValue.Location = new System.Drawing.Point(141, 51);
            this.numClearanceValue.Name = "numClearanceValue";
            this.numClearanceValue.Size = new System.Drawing.Size(120, 21);
            this.numClearanceValue.TabIndex = 4;
            this.numClearanceValue.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // ckUseRangeValue
            // 
            this.ckUseRangeValue.AutoSize = true;
            this.ckUseRangeValue.Location = new System.Drawing.Point(22, 79);
            this.ckUseRangeValue.Name = "ckUseRangeValue";
            this.ckUseRangeValue.Size = new System.Drawing.Size(96, 16);
            this.ckUseRangeValue.TabIndex = 3;
            this.ckUseRangeValue.Text = "근접허용범위";
            this.ckUseRangeValue.UseVisualStyleBackColor = true;
            // 
            // ckUseClearanceValue
            // 
            this.ckUseClearanceValue.AutoSize = true;
            this.ckUseClearanceValue.Location = new System.Drawing.Point(22, 52);
            this.ckUseClearanceValue.Name = "ckUseClearanceValue";
            this.ckUseClearanceValue.Size = new System.Drawing.Size(96, 16);
            this.ckUseClearanceValue.TabIndex = 2;
            this.ckUseClearanceValue.Text = "여유허용범위";
            this.ckUseClearanceValue.UseVisualStyleBackColor = true;
            // 
            // cbClashTestKind
            // 
            this.cbClashTestKind.FormattingEnabled = true;
            this.cbClashTestKind.Items.AddRange(new object[] {
            "그룹 검사",
            "장비 검사"});
            this.cbClashTestKind.Location = new System.Drawing.Point(78, 20);
            this.cbClashTestKind.Name = "cbClashTestKind";
            this.cbClashTestKind.Size = new System.Drawing.Size(183, 20);
            this.cbClashTestKind.TabIndex = 1;
            this.cbClashTestKind.SelectedIndexChanged += new System.EventHandler(this.cbClashTestKind_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "검사유형";
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
            this.splitContainer2.Panel2.Controls.Add(this.datagridviewInterferenceResult);
            this.splitContainer2.Size = new System.Drawing.Size(750, 687);
            this.splitContainer2.SplitterDistance = 461;
            this.splitContainer2.TabIndex = 0;
            // 
            // datagridviewInterferenceResult
            // 
            this.datagridviewInterferenceResult.AllowUserToAddRows = false;
            this.datagridviewInterferenceResult.AllowUserToDeleteRows = false;
            this.datagridviewInterferenceResult.BackgroundColor = System.Drawing.SystemColors.Window;
            this.datagridviewInterferenceResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewInterferenceResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.group1NodeType,
            this.Column3,
            this.Column7,
            this.Column6,
            this.Column4,
            this.Column5});
            this.datagridviewInterferenceResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridviewInterferenceResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.datagridviewInterferenceResult.Location = new System.Drawing.Point(0, 0);
            this.datagridviewInterferenceResult.Name = "datagridviewInterferenceResult";
            this.datagridviewInterferenceResult.RowTemplate.Height = 23;
            this.datagridviewInterferenceResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridviewInterferenceResult.Size = new System.Drawing.Size(750, 222);
            this.datagridviewInterferenceResult.TabIndex = 0;
            this.datagridviewInterferenceResult.VirtualMode = true;
            this.datagridviewInterferenceResult.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.datagridviewInterferenceResult_CellValueNeeded);
            this.datagridviewInterferenceResult.SelectionChanged += new System.EventHandler(this.datagridviewInterferenceResult_SelectionChanged);
            // 
            // group1NodeType
            // 
            this.group1NodeType.HeaderText = "Group1";
            this.group1NodeType.Name = "group1NodeType";
            this.group1NodeType.ReadOnly = true;
            this.group1NodeType.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Group2";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "State";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 50;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Distance";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Position";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Direction";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
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
            this.Text = "VIZCore3DX.NET.ClashTest";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPenetrationTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClearanceValue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewInterferenceResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbClashTestKind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddGroupB;
        private System.Windows.Forms.Button btnAddGroupA;
        private System.Windows.Forms.NumericUpDown numPenetrationTolerance;
        private System.Windows.Forms.NumericUpDown numRangeValue;
        private System.Windows.Forms.NumericUpDown numClearanceValue;
        private System.Windows.Forms.CheckBox ckUseRangeValue;
        private System.Windows.Forms.CheckBox ckUseClearanceValue;
        private System.Windows.Forms.DataGridView datagridviewInterferenceResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn group1NodeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox ckIdentity;
        private System.Windows.Forms.CheckBox ckClash;
        private System.Windows.Forms.CheckBox ckContact;
        private System.Windows.Forms.CheckBox ckProximity;
        private System.Windows.Forms.CheckBox ckClearance;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbClashTestId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
    }
}

