namespace VIZCore3DX.NET.ClashTest_MoveTest
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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tlpMovePath = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numDegreeZ = new System.Windows.Forms.NumericUpDown();
            this.numDegreeY = new System.Windows.Forms.NumericUpDown();
            this.numDegreeX = new System.Windows.Forms.NumericUpDown();
            this.numDistanceZ = new System.Windows.Forms.NumericUpDown();
            this.numDistanceY = new System.Windows.Forms.NumericUpDown();
            this.numDistanceX = new System.Windows.Forms.NumericUpDown();
            this.btnPathClear = new System.Windows.Forms.Button();
            this.btnPathAdd = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbResultGroupingPart = new System.Windows.Forms.RadioButton();
            this.rbResultGroupingAssy = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cbClashTestId = new System.Windows.Forms.ComboBox();
            this.ckIdentity = new System.Windows.Forms.CheckBox();
            this.ckClash = new System.Windows.Forms.CheckBox();
            this.ckContact = new System.Windows.Forms.CheckBox();
            this.ckProximity = new System.Windows.Forms.CheckBox();
            this.ckClearance = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tlpModel = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.btnLoadScenario = new System.Windows.Forms.Button();
            this.btnAddModels = new System.Windows.Forms.Button();
            this.btnCloseModel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tlpClash = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tlpGroup = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddGroupB = new System.Windows.Forms.Button();
            this.btnAddGroupA = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numPenetrationTolerance = new System.Windows.Forms.NumericUpDown();
            this.numRangeValue = new System.Windows.Forms.NumericUpDown();
            this.numClearanceValue = new System.Windows.Forms.NumericUpDown();
            this.ckUseRangeValue = new System.Windows.Forms.CheckBox();
            this.ckUseClearanceValue = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.datagridviewInterferencePath = new System.Windows.Forms.DataGridView();
            this.datagridviewInterferenceResult = new System.Windows.Forms.DataGridView();
            this.pathGrid_testid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathGrid_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathGrid_distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathGrid_angle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathGrid_matrix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathGrid_resultCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultGrid_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultGrid_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultGrid_B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultGrid_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultGrid_distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultGrid_position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultGrid_direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewAllResult = new System.Windows.Forms.Button();
            this.groupPathWorkflow = new System.Windows.Forms.GroupBox();
            this.tlpPathFile = new System.Windows.Forms.TableLayoutPanel();
            this.lstTestPaths = new System.Windows.Forms.ListBox();
            this.btnGetTestPaths = new System.Windows.Forms.Button();
            this.btnExportTestPaths = new System.Windows.Forms.Button();
            this.btnImportTestPaths = new System.Windows.Forms.Button();
            this.chkReplaceExisting = new System.Windows.Forms.CheckBox();
            this.lblPlayInterval = new System.Windows.Forms.Label();
            this.numPlayInterval = new System.Windows.Forms.NumericUpDown();
            this.btnPlayTestPaths = new System.Windows.Forms.Button();
            this.btnStopPlayback = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tlpMovePath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDegreeZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDegreeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDegreeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistanceZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistanceY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistanceX)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tlpModel.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tlpClash.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tlpGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPenetrationTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClearanceValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewInterferencePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewInterferenceResult)).BeginInit();
            this.groupPathWorkflow.SuspendLayout();
            this.tlpPathFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayInterval)).BeginInit();
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
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.groupPathWorkflow);
            this.splitContainer1.Panel1.Controls.Add(this.btnViewAllResult);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox7);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(1523, 890);
            this.splitContainer1.SplitterDistance = 390;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.numDegreeZ);
            this.groupBox7.Controls.Add(this.numDegreeY);
            this.groupBox7.Controls.Add(this.numDegreeX);
            this.groupBox7.Controls.Add(this.numDistanceZ);
            this.groupBox7.Controls.Add(this.numDistanceY);
            this.groupBox7.Controls.Add(this.numDistanceX);
            this.groupBox7.Controls.Add(this.tlpMovePath);
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Location = new System.Drawing.Point(12, 362);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(366, 130);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Group B Move Path";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(240, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "Z 각도 :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(126, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "Y 각도 :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "X 각도 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "Z 거리 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "Y 거리 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "X 거리 :";
            // 
            // numDegreeZ
            // 
            this.numDegreeZ.Location = new System.Drawing.Point(292, 54);
            this.numDegreeZ.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numDegreeZ.Name = "numDegreeZ";
            this.numDegreeZ.Size = new System.Drawing.Size(56, 21);
            this.numDegreeZ.TabIndex = 15;
            // 
            // numDegreeY
            // 
            this.numDegreeY.Location = new System.Drawing.Point(178, 54);
            this.numDegreeY.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numDegreeY.Name = "numDegreeY";
            this.numDegreeY.Size = new System.Drawing.Size(56, 21);
            this.numDegreeY.TabIndex = 14;
            // 
            // numDegreeX
            // 
            this.numDegreeX.Location = new System.Drawing.Point(64, 54);
            this.numDegreeX.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numDegreeX.Name = "numDegreeX";
            this.numDegreeX.Size = new System.Drawing.Size(56, 21);
            this.numDegreeX.TabIndex = 13;
            // 
            // numDistanceZ
            // 
            this.numDistanceZ.Location = new System.Drawing.Point(292, 24);
            this.numDistanceZ.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numDistanceZ.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numDistanceZ.Name = "numDistanceZ";
            this.numDistanceZ.Size = new System.Drawing.Size(56, 21);
            this.numDistanceZ.TabIndex = 12;
            // 
            // numDistanceY
            // 
            this.numDistanceY.Location = new System.Drawing.Point(178, 24);
            this.numDistanceY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numDistanceY.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numDistanceY.Name = "numDistanceY";
            this.numDistanceY.Size = new System.Drawing.Size(56, 21);
            this.numDistanceY.TabIndex = 11;
            // 
            // numDistanceX
            // 
            this.numDistanceX.Location = new System.Drawing.Point(64, 24);
            this.numDistanceX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numDistanceX.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numDistanceX.Name = "numDistanceX";
            this.numDistanceX.Size = new System.Drawing.Size(56, 21);
            this.numDistanceX.TabIndex = 10;
            // 
            // btnPathClear
            // 
            this.btnPathClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPathClear.Location = new System.Drawing.Point(177, 3);
            this.btnPathClear.Name = "btnPathClear";
            this.btnPathClear.Size = new System.Drawing.Size(168, 30);
            this.btnPathClear.TabIndex = 3;
            this.btnPathClear.Text = "Clear";
            this.btnPathClear.UseVisualStyleBackColor = true;
            this.btnPathClear.Click += new System.EventHandler(this.btnPathClear_Click);
            // 
            // tlpMovePath
            // 
            this.tlpMovePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMovePath.ColumnCount = 2;
            this.tlpMovePath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMovePath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMovePath.Controls.Add(this.btnPathAdd, 0, 0);
            this.tlpMovePath.Controls.Add(this.btnPathClear, 1, 0);
            this.tlpMovePath.Location = new System.Drawing.Point(9, 84);
            this.tlpMovePath.Name = "tlpMovePath";
            this.tlpMovePath.RowCount = 1;
            this.tlpMovePath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMovePath.Size = new System.Drawing.Size(348, 36);
            this.tlpMovePath.TabIndex = 0;
            // 
            // btnPathAdd
            // 
            this.btnPathAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPathAdd.Location = new System.Drawing.Point(3, 3);
            this.btnPathAdd.Name = "btnPathAdd";
            this.btnPathAdd.Size = new System.Drawing.Size(168, 30);
            this.btnPathAdd.TabIndex = 0;
            this.btnPathAdd.Text = "Add";
            this.btnPathAdd.UseVisualStyleBackColor = true;
            this.btnPathAdd.Click += new System.EventHandler(this.btnPathAdd_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.cbClashTestId);
            this.groupBox5.Controls.Add(this.ckIdentity);
            this.groupBox5.Controls.Add(this.ckClash);
            this.groupBox5.Controls.Add(this.ckContact);
            this.groupBox5.Controls.Add(this.ckProximity);
            this.groupBox5.Controls.Add(this.ckClearance);
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Location = new System.Drawing.Point(12, 500);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(366, 134);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Result Option";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbResultGroupingPart);
            this.groupBox6.Controls.Add(this.rbResultGroupingAssy);
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Location = new System.Drawing.Point(12, 78);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(342, 46);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "결과 그룹 단위";
            // 
            // rbResultGroupingPart
            // 
            this.rbResultGroupingPart.AutoSize = true;
            this.rbResultGroupingPart.Location = new System.Drawing.Point(110, 20);
            this.rbResultGroupingPart.Name = "rbResultGroupingPart";
            this.rbResultGroupingPart.Size = new System.Drawing.Size(47, 16);
            this.rbResultGroupingPart.TabIndex = 1;
            this.rbResultGroupingPart.Text = "파트";
            this.rbResultGroupingPart.UseVisualStyleBackColor = true;
            // 
            // rbResultGroupingAssy
            // 
            this.rbResultGroupingAssy.AutoSize = true;
            this.rbResultGroupingAssy.Checked = true;
            this.rbResultGroupingAssy.Location = new System.Drawing.Point(12, 20);
            this.rbResultGroupingAssy.Name = "rbResultGroupingAssy";
            this.rbResultGroupingAssy.Size = new System.Drawing.Size(71, 16);
            this.rbResultGroupingAssy.TabIndex = 0;
            this.rbResultGroupingAssy.TabStop = true;
            this.rbResultGroupingAssy.Text = "어셈블리";
            this.rbResultGroupingAssy.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "ClashTest ID";
            // 
            // cbClashTestId
            // 
            this.cbClashTestId.FormattingEnabled = true;
            this.cbClashTestId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbClashTestId.Location = new System.Drawing.Point(110, 48);
            this.cbClashTestId.Name = "cbClashTestId";
            this.cbClashTestId.Size = new System.Drawing.Size(244, 20);
            this.cbClashTestId.TabIndex = 6;
            // 
            // ckIdentity
            // 
            this.ckIdentity.AutoSize = true;
            this.ckIdentity.Checked = true;
            this.ckIdentity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIdentity.Location = new System.Drawing.Point(236, 24);
            this.ckIdentity.Name = "ckIdentity";
            this.ckIdentity.Size = new System.Drawing.Size(48, 16);
            this.ckIdentity.TabIndex = 7;
            this.ckIdentity.Text = "동일";
            this.ckIdentity.UseVisualStyleBackColor = true;
            // 
            // ckClash
            // 
            this.ckClash.AutoSize = true;
            this.ckClash.Checked = true;
            this.ckClash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckClash.Location = new System.Drawing.Point(180, 24);
            this.ckClash.Name = "ckClash";
            this.ckClash.Size = new System.Drawing.Size(48, 16);
            this.ckClash.TabIndex = 6;
            this.ckClash.Text = "충돌";
            this.ckClash.UseVisualStyleBackColor = true;
            // 
            // ckContact
            // 
            this.ckContact.AutoSize = true;
            this.ckContact.Checked = true;
            this.ckContact.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckContact.Location = new System.Drawing.Point(124, 24);
            this.ckContact.Name = "ckContact";
            this.ckContact.Size = new System.Drawing.Size(48, 16);
            this.ckContact.TabIndex = 5;
            this.ckContact.Text = "접촉";
            this.ckContact.UseVisualStyleBackColor = true;
            // 
            // ckProximity
            // 
            this.ckProximity.AutoSize = true;
            this.ckProximity.Checked = true;
            this.ckProximity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckProximity.Location = new System.Drawing.Point(68, 24);
            this.ckProximity.Name = "ckProximity";
            this.ckProximity.Size = new System.Drawing.Size(48, 16);
            this.ckProximity.TabIndex = 4;
            this.ckProximity.Text = "근접";
            this.ckProximity.UseVisualStyleBackColor = true;
            // 
            // ckClearance
            // 
            this.ckClearance.AutoSize = true;
            this.ckClearance.Checked = true;
            this.ckClearance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckClearance.Location = new System.Drawing.Point(12, 24);
            this.ckClearance.Name = "ckClearance";
            this.ckClearance.Size = new System.Drawing.Size(48, 16);
            this.ckClearance.TabIndex = 3;
            this.ckClearance.Text = "여유";
            this.ckClearance.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tlpModel);
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 68);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Model";
            //
            // btnLoadScenario
            //
            this.btnLoadScenario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadScenario.Enabled = false;
            this.btnLoadScenario.Location = new System.Drawing.Point(264, 3);
            this.btnLoadScenario.Name = "btnLoadScenario";
            this.btnLoadScenario.Size = new System.Drawing.Size(81, 30);
            this.btnLoadScenario.TabIndex = 3;
            this.btnLoadScenario.Text = "시나리오";
            this.btnLoadScenario.UseVisualStyleBackColor = true;
            this.btnLoadScenario.Click += new System.EventHandler(this.btnLoadScenario_Click);
            //
            // tlpModel
            // 
            this.tlpModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpModel.ColumnCount = 4;
            this.tlpModel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpModel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpModel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpModel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpModel.Controls.Add(this.btnOpenModel, 0, 0);
            this.tlpModel.Controls.Add(this.btnAddModels, 1, 0);
            this.tlpModel.Controls.Add(this.btnCloseModel, 2, 0);
            this.tlpModel.Controls.Add(this.btnLoadScenario, 3, 0);
            this.tlpModel.Location = new System.Drawing.Point(9, 22);
            this.tlpModel.Name = "tlpModel";
            this.tlpModel.RowCount = 1;
            this.tlpModel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpModel.Size = new System.Drawing.Size(348, 36);
            this.tlpModel.TabIndex = 0;
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenModel.Location = new System.Drawing.Point(3, 3);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(110, 30);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "Open";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // btnAddModels
            // 
            this.btnAddModels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddModels.Location = new System.Drawing.Point(119, 3);
            this.btnAddModels.Name = "btnAddModels";
            this.btnAddModels.Size = new System.Drawing.Size(110, 30);
            this.btnAddModels.TabIndex = 1;
            this.btnAddModels.Text = "Add";
            this.btnAddModels.UseVisualStyleBackColor = true;
            this.btnAddModels.Click += new System.EventHandler(this.btnAddModels_Click);
            // 
            // btnCloseModel
            // 
            this.btnCloseModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCloseModel.Location = new System.Drawing.Point(235, 3);
            this.btnCloseModel.Name = "btnCloseModel";
            this.btnCloseModel.Size = new System.Drawing.Size(110, 30);
            this.btnCloseModel.TabIndex = 2;
            this.btnCloseModel.Text = "Close";
            this.btnCloseModel.UseVisualStyleBackColor = true;
            this.btnCloseModel.Click += new System.EventHandler(this.btnCloseModel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tlpClash);
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Location = new System.Drawing.Point(12, 286);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(366, 68);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Clash";
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(90, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Del";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(264, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(81, 30);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Location = new System.Drawing.Point(177, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(81, 30);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tlpClash
            // 
            this.tlpClash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpClash.ColumnCount = 4;
            this.tlpClash.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpClash.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpClash.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpClash.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpClash.Controls.Add(this.btnAdd, 0, 0);
            this.tlpClash.Controls.Add(this.btnDelete, 1, 0);
            this.tlpClash.Controls.Add(this.btnStart, 2, 0);
            this.tlpClash.Controls.Add(this.btnClear, 3, 0);
            this.tlpClash.Location = new System.Drawing.Point(9, 22);
            this.tlpClash.Name = "tlpClash";
            this.tlpClash.RowCount = 1;
            this.tlpClash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClash.Size = new System.Drawing.Size(348, 36);
            this.tlpClash.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tlpGroup);
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(12, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 68);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Group";
            // 
            // btnAddGroupB
            // 
            this.btnAddGroupB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddGroupB.Location = new System.Drawing.Point(177, 3);
            this.btnAddGroupB.Name = "btnAddGroupB";
            this.btnAddGroupB.Size = new System.Drawing.Size(168, 30);
            this.btnAddGroupB.TabIndex = 8;
            this.btnAddGroupB.Text = "Add Group B";
            this.btnAddGroupB.UseVisualStyleBackColor = true;
            this.btnAddGroupB.Click += new System.EventHandler(this.btnAddGroupB_Click);
            // 
            // tlpGroup
            // 
            this.tlpGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpGroup.ColumnCount = 2;
            this.tlpGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGroup.Controls.Add(this.btnAddGroupA, 0, 0);
            this.tlpGroup.Controls.Add(this.btnAddGroupB, 1, 0);
            this.tlpGroup.Location = new System.Drawing.Point(9, 22);
            this.tlpGroup.Name = "tlpGroup";
            this.tlpGroup.RowCount = 1;
            this.tlpGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGroup.Size = new System.Drawing.Size(348, 36);
            this.tlpGroup.TabIndex = 0;
            // 
            // btnAddGroupA
            // 
            this.btnAddGroupA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddGroupA.Location = new System.Drawing.Point(3, 3);
            this.btnAddGroupA.Name = "btnAddGroupA";
            this.btnAddGroupA.Size = new System.Drawing.Size(168, 30);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 114);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
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
            this.numPenetrationTolerance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numPenetrationTolerance.Location = new System.Drawing.Point(140, 82);
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
            this.numPenetrationTolerance.Size = new System.Drawing.Size(214, 21);
            this.numPenetrationTolerance.TabIndex = 6;
            this.numPenetrationTolerance.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147352576});
            // 
            // numRangeValue
            // 
            this.numRangeValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numRangeValue.Location = new System.Drawing.Point(140, 54);
            this.numRangeValue.Name = "numRangeValue";
            this.numRangeValue.Size = new System.Drawing.Size(214, 21);
            this.numRangeValue.TabIndex = 5;
            this.numRangeValue.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numClearanceValue
            // 
            this.numClearanceValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numClearanceValue.Location = new System.Drawing.Point(140, 26);
            this.numClearanceValue.Name = "numClearanceValue";
            this.numClearanceValue.Size = new System.Drawing.Size(214, 21);
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
            this.ckUseRangeValue.Location = new System.Drawing.Point(12, 56);
            this.ckUseRangeValue.Name = "ckUseRangeValue";
            this.ckUseRangeValue.Size = new System.Drawing.Size(96, 16);
            this.ckUseRangeValue.TabIndex = 3;
            this.ckUseRangeValue.Text = "근접허용범위";
            this.ckUseRangeValue.UseVisualStyleBackColor = true;
            // 
            // ckUseClearanceValue
            // 
            this.ckUseClearanceValue.AutoSize = true;
            this.ckUseClearanceValue.Location = new System.Drawing.Point(12, 28);
            this.ckUseClearanceValue.Name = "ckUseClearanceValue";
            this.ckUseClearanceValue.Size = new System.Drawing.Size(96, 16);
            this.ckUseClearanceValue.TabIndex = 2;
            this.ckUseClearanceValue.Text = "여유허용범위";
            this.ckUseClearanceValue.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1129, 890);
            this.splitContainer2.SplitterDistance = 676;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.datagridviewInterferencePath);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.datagridviewInterferenceResult);
            this.splitContainer3.Size = new System.Drawing.Size(449, 890);
            this.splitContainer3.SplitterDistance = 443;
            this.splitContainer3.TabIndex = 2;
            // 
            // datagridviewInterferencePath
            // 
            this.datagridviewInterferencePath.AllowUserToAddRows = false;
            this.datagridviewInterferencePath.AllowUserToDeleteRows = false;
            this.datagridviewInterferencePath.BackgroundColor = System.Drawing.SystemColors.Window;
            this.datagridviewInterferencePath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewInterferencePath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pathGrid_testid,
            this.pathGrid_id,
            this.pathGrid_distance,
            this.pathGrid_angle,
            this.pathGrid_matrix,
            this.pathGrid_resultCount});
            this.datagridviewInterferencePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridviewInterferencePath.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.datagridviewInterferencePath.Location = new System.Drawing.Point(0, 0);
            this.datagridviewInterferencePath.Name = "datagridviewInterferencePath";
            this.datagridviewInterferencePath.RowTemplate.Height = 23;
            this.datagridviewInterferencePath.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridviewInterferencePath.Size = new System.Drawing.Size(449, 443);
            this.datagridviewInterferencePath.TabIndex = 1;
            this.datagridviewInterferencePath.SelectionChanged += new System.EventHandler(this.datagridviewInterferencePath_SelectionChanged);
            // 
            // datagridviewInterferenceResult
            // 
            this.datagridviewInterferenceResult.AllowUserToAddRows = false;
            this.datagridviewInterferenceResult.AllowUserToDeleteRows = false;
            this.datagridviewInterferenceResult.BackgroundColor = System.Drawing.SystemColors.Window;
            this.datagridviewInterferenceResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewInterferenceResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.resultGrid_seq,
            this.resultGrid_A,
            this.resultGrid_B,
            this.resultGrid_state,
            this.resultGrid_distance,
            this.resultGrid_position,
            this.resultGrid_direction});
            this.datagridviewInterferenceResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridviewInterferenceResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.datagridviewInterferenceResult.Location = new System.Drawing.Point(0, 0);
            this.datagridviewInterferenceResult.Name = "datagridviewInterferenceResult";
            this.datagridviewInterferenceResult.RowTemplate.Height = 23;
            this.datagridviewInterferenceResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridviewInterferenceResult.Size = new System.Drawing.Size(449, 443);
            this.datagridviewInterferenceResult.TabIndex = 1;
            // 
            // pathGrid_testid
            // 
            this.pathGrid_testid.HeaderText = "TestID";
            this.pathGrid_testid.Name = "pathGrid_testid";
            this.pathGrid_testid.Width = 50;
            // 
            // pathGrid_id
            // 
            this.pathGrid_id.HeaderText = "Seq";
            this.pathGrid_id.Name = "pathGrid_id";
            this.pathGrid_id.ReadOnly = true;
            this.pathGrid_id.Width = 40;
            // 
            // pathGrid_distance
            // 
            this.pathGrid_distance.HeaderText = "Distance";
            this.pathGrid_distance.Name = "pathGrid_distance";
            this.pathGrid_distance.ReadOnly = true;
            this.pathGrid_distance.Width = 80;
            // 
            // pathGrid_angle
            // 
            this.pathGrid_angle.HeaderText = "Angle";
            this.pathGrid_angle.Name = "pathGrid_angle";
            this.pathGrid_angle.ReadOnly = true;
            this.pathGrid_angle.Width = 80;
            // 
            // pathGrid_matrix
            // 
            this.pathGrid_matrix.HeaderText = "Matrix";
            this.pathGrid_matrix.Name = "pathGrid_matrix";
            this.pathGrid_matrix.ReadOnly = true;
            // 
            // pathGrid_resultCount
            // 
            this.pathGrid_resultCount.HeaderText = "Result Count";
            this.pathGrid_resultCount.Name = "pathGrid_resultCount";
            this.pathGrid_resultCount.Width = 50;
            // 
            // resultGrid_seq
            // 
            this.resultGrid_seq.HeaderText = "No";
            this.resultGrid_seq.Name = "resultGrid_seq";
            this.resultGrid_seq.Width = 40;
            // 
            // resultGrid_A
            // 
            this.resultGrid_A.HeaderText = "GroupA";
            this.resultGrid_A.Name = "resultGrid_A";
            this.resultGrid_A.ReadOnly = true;
            this.resultGrid_A.Width = 50;
            // 
            // resultGrid_B
            // 
            this.resultGrid_B.HeaderText = "GroupB";
            this.resultGrid_B.Name = "resultGrid_B";
            this.resultGrid_B.ReadOnly = true;
            this.resultGrid_B.Width = 50;
            // 
            // resultGrid_state
            // 
            this.resultGrid_state.HeaderText = "State";
            this.resultGrid_state.Name = "resultGrid_state";
            this.resultGrid_state.ReadOnly = true;
            this.resultGrid_state.Width = 50;
            // 
            // resultGrid_distance
            // 
            this.resultGrid_distance.HeaderText = "Distance";
            this.resultGrid_distance.Name = "resultGrid_distance";
            this.resultGrid_distance.ReadOnly = true;
            this.resultGrid_distance.Width = 70;
            // 
            // resultGrid_position
            // 
            this.resultGrid_position.HeaderText = "Position";
            this.resultGrid_position.Name = "resultGrid_position";
            this.resultGrid_position.ReadOnly = true;
            this.resultGrid_position.Width = 70;
            // 
            // resultGrid_direction
            // 
            this.resultGrid_direction.HeaderText = "Direction";
            this.resultGrid_direction.Name = "resultGrid_direction";
            this.resultGrid_direction.ReadOnly = true;
            this.resultGrid_direction.Width = 70;
            // 
            // btnViewAllResult
            // 
            this.btnViewAllResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewAllResult.Location = new System.Drawing.Point(12, 642);
            this.btnViewAllResult.Name = "btnViewAllResult";
            this.btnViewAllResult.Size = new System.Drawing.Size(366, 32);
            this.btnViewAllResult.TabIndex = 10;
            this.btnViewAllResult.Text = "Show All Result";
            this.btnViewAllResult.UseVisualStyleBackColor = true;
            this.btnViewAllResult.Click += new System.EventHandler(this.btnViewAllResult_Click);
            // 
            // groupPathWorkflow
            // 
            this.groupPathWorkflow.Controls.Add(this.btnStopPlayback);
            this.groupPathWorkflow.Controls.Add(this.btnPlayTestPaths);
            this.groupPathWorkflow.Controls.Add(this.numPlayInterval);
            this.groupPathWorkflow.Controls.Add(this.lblPlayInterval);
            this.groupPathWorkflow.Controls.Add(this.chkReplaceExisting);
            this.groupPathWorkflow.Controls.Add(this.tlpPathFile);
            this.groupPathWorkflow.Controls.Add(this.lstTestPaths);
            this.groupPathWorkflow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPathWorkflow.Location = new System.Drawing.Point(12, 682);
            this.groupPathWorkflow.Name = "groupPathWorkflow";
            this.groupPathWorkflow.Size = new System.Drawing.Size(366, 196);
            this.groupPathWorkflow.TabIndex = 11;
            this.groupPathWorkflow.TabStop = false;
            this.groupPathWorkflow.Text = "이동 경로 관리 (조회 / 저장·복원 / 재생)";
            // 
            // lstTestPaths
            // 
            this.lstTestPaths.FormattingEnabled = true;
            this.lstTestPaths.HorizontalScrollbar = true;
            this.lstTestPaths.ItemHeight = 12;
            this.lstTestPaths.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTestPaths.Location = new System.Drawing.Point(12, 22);
            this.lstTestPaths.Name = "lstTestPaths";
            this.lstTestPaths.Size = new System.Drawing.Size(342, 64);
            this.lstTestPaths.TabIndex = 0;
            // 
            // tlpPathFile
            // 
            this.tlpPathFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPathFile.ColumnCount = 3;
            this.tlpPathFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333F));
            this.tlpPathFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333F));
            this.tlpPathFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333F));
            this.tlpPathFile.Controls.Add(this.btnGetTestPaths, 0, 0);
            this.tlpPathFile.Controls.Add(this.btnExportTestPaths, 1, 0);
            this.tlpPathFile.Controls.Add(this.btnImportTestPaths, 2, 0);
            this.tlpPathFile.Location = new System.Drawing.Point(9, 92);
            this.tlpPathFile.Name = "tlpPathFile";
            this.tlpPathFile.RowCount = 1;
            this.tlpPathFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPathFile.Size = new System.Drawing.Size(348, 36);
            this.tlpPathFile.TabIndex = 1;
            // 
            // btnGetTestPaths
            // 
            this.btnGetTestPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetTestPaths.Location = new System.Drawing.Point(3, 3);
            this.btnGetTestPaths.Name = "btnGetTestPaths";
            this.btnGetTestPaths.Size = new System.Drawing.Size(110, 30);
            this.btnGetTestPaths.TabIndex = 1;
            this.btnGetTestPaths.Text = "경로 조회";
            this.btnGetTestPaths.UseVisualStyleBackColor = true;
            this.btnGetTestPaths.Click += new System.EventHandler(this.btnGetTestPaths_Click);
            // 
            // btnExportTestPaths
            // 
            this.btnExportTestPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportTestPaths.Location = new System.Drawing.Point(119, 3);
            this.btnExportTestPaths.Name = "btnExportTestPaths";
            this.btnExportTestPaths.Size = new System.Drawing.Size(110, 30);
            this.btnExportTestPaths.TabIndex = 2;
            this.btnExportTestPaths.Text = "경로 저장";
            this.btnExportTestPaths.UseVisualStyleBackColor = true;
            this.btnExportTestPaths.Click += new System.EventHandler(this.btnExportTestPaths_Click);
            // 
            // btnImportTestPaths
            // 
            this.btnImportTestPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportTestPaths.Location = new System.Drawing.Point(235, 3);
            this.btnImportTestPaths.Name = "btnImportTestPaths";
            this.btnImportTestPaths.Size = new System.Drawing.Size(110, 30);
            this.btnImportTestPaths.TabIndex = 3;
            this.btnImportTestPaths.Text = "경로 불러오기";
            this.btnImportTestPaths.UseVisualStyleBackColor = true;
            this.btnImportTestPaths.Click += new System.EventHandler(this.btnImportTestPaths_Click);
            // 
            // chkReplaceExisting
            // 
            this.chkReplaceExisting.AutoSize = true;
            this.chkReplaceExisting.Checked = true;
            this.chkReplaceExisting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReplaceExisting.Location = new System.Drawing.Point(12, 136);
            this.chkReplaceExisting.Name = "chkReplaceExisting";
            this.chkReplaceExisting.Size = new System.Drawing.Size(212, 16);
            this.chkReplaceExisting.TabIndex = 4;
            this.chkReplaceExisting.Text = "불러오기 시 기존 경로 대체";
            this.chkReplaceExisting.UseVisualStyleBackColor = true;
            // 
            // lblPlayInterval
            // 
            this.lblPlayInterval.AutoSize = true;
            this.lblPlayInterval.Location = new System.Drawing.Point(12, 166);
            this.lblPlayInterval.Name = "lblPlayInterval";
            this.lblPlayInterval.Size = new System.Drawing.Size(81, 12);
            this.lblPlayInterval.TabIndex = 5;
            this.lblPlayInterval.Text = "재생 간격(ms)";
            // 
            // numPlayInterval
            // 
            this.numPlayInterval.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numPlayInterval.Location = new System.Drawing.Point(100, 162);
            this.numPlayInterval.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numPlayInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPlayInterval.Name = "numPlayInterval";
            this.numPlayInterval.Size = new System.Drawing.Size(70, 21);
            this.numPlayInterval.TabIndex = 6;
            this.numPlayInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnPlayTestPaths
            // 
            this.btnPlayTestPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlayTestPaths.Location = new System.Drawing.Point(188, 158);
            this.btnPlayTestPaths.Name = "btnPlayTestPaths";
            this.btnPlayTestPaths.Size = new System.Drawing.Size(80, 28);
            this.btnPlayTestPaths.TabIndex = 7;
            this.btnPlayTestPaths.Text = "재생";
            this.btnPlayTestPaths.UseVisualStyleBackColor = true;
            this.btnPlayTestPaths.Click += new System.EventHandler(this.btnPlayTestPaths_Click);
            // 
            // btnStopPlayback
            // 
            this.btnStopPlayback.Enabled = false;
            this.btnStopPlayback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopPlayback.Location = new System.Drawing.Point(274, 158);
            this.btnStopPlayback.Name = "btnStopPlayback";
            this.btnStopPlayback.Size = new System.Drawing.Size(80, 28);
            this.btnStopPlayback.TabIndex = 8;
            this.btnStopPlayback.Text = "중지";
            this.btnStopPlayback.UseVisualStyleBackColor = true;
            this.btnStopPlayback.Click += new System.EventHandler(this.btnStopPlayback_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1523, 890);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.ClashTest_MoveTest";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.tlpMovePath.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDegreeZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDegreeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDegreeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistanceZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistanceY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistanceX)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tlpModel.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tlpClash.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tlpGroup.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPenetrationTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClearanceValue)).EndInit();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewInterferencePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewInterferenceResult)).EndInit();
            this.groupPathWorkflow.ResumeLayout(false);
            this.tlpPathFile.ResumeLayout(false);
            this.groupPathWorkflow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tlpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Button btnLoadScenario;
        private System.Windows.Forms.Button btnAddModels;
        private System.Windows.Forms.Button btnCloseModel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbClashTestId;
        private System.Windows.Forms.CheckBox ckIdentity;
        private System.Windows.Forms.CheckBox ckClash;
        private System.Windows.Forms.CheckBox ckContact;
        private System.Windows.Forms.CheckBox ckProximity;
        private System.Windows.Forms.CheckBox ckClearance;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tlpClash;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tlpGroup;
        private System.Windows.Forms.Button btnAddGroupB;
        private System.Windows.Forms.Button btnAddGroupA;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPenetrationTolerance;
        private System.Windows.Forms.NumericUpDown numRangeValue;
        private System.Windows.Forms.NumericUpDown numClearanceValue;
        private System.Windows.Forms.CheckBox ckUseRangeValue;
        private System.Windows.Forms.CheckBox ckUseClearanceValue;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView datagridviewInterferencePath;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbResultGroupingPart;
        private System.Windows.Forms.RadioButton rbResultGroupingAssy;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TableLayoutPanel tlpMovePath;
        private System.Windows.Forms.Button btnPathClear;
        private System.Windows.Forms.Button btnPathAdd;
        private System.Windows.Forms.NumericUpDown numDegreeZ;
        private System.Windows.Forms.NumericUpDown numDegreeY;
        private System.Windows.Forms.NumericUpDown numDegreeX;
        private System.Windows.Forms.NumericUpDown numDistanceZ;
        private System.Windows.Forms.NumericUpDown numDistanceY;
        private System.Windows.Forms.NumericUpDown numDistanceX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView datagridviewInterferenceResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathGrid_testid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathGrid_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathGrid_distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathGrid_angle;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathGrid_matrix;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathGrid_resultCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultGrid_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultGrid_A;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultGrid_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultGrid_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultGrid_distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultGrid_position;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultGrid_direction;
        private System.Windows.Forms.Button btnViewAllResult;
        private System.Windows.Forms.GroupBox groupPathWorkflow;
        private System.Windows.Forms.TableLayoutPanel tlpPathFile;
        private System.Windows.Forms.ListBox lstTestPaths;
        private System.Windows.Forms.Button btnGetTestPaths;
        private System.Windows.Forms.Button btnExportTestPaths;
        private System.Windows.Forms.Button btnImportTestPaths;
        private System.Windows.Forms.CheckBox chkReplaceExisting;
        private System.Windows.Forms.Label lblPlayInterval;
        private System.Windows.Forms.NumericUpDown numPlayInterval;
        private System.Windows.Forms.Button btnPlayTestPaths;
        private System.Windows.Forms.Button btnStopPlayback;
    }
}

