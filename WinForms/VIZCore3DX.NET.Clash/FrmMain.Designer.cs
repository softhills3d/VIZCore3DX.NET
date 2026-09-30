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
            this.tlpClash = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tlpGroup = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddGroupB = new System.Windows.Forms.Button();
            this.btnAddGroupA = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numPenetration = new System.Windows.Forms.NumericUpDown();
            this.numRangeValue = new System.Windows.Forms.NumericUpDown();
            this.numClearanceValue = new System.Windows.Forms.NumericUpDown();
            this.ckUseRangeValue = new System.Windows.Forms.CheckBox();
            this.ckUseClearanceValue = new System.Windows.Forms.CheckBox();
            this.cbClashTestKind = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.tlpOpen = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoadScenario = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.colIdA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group1NodeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupReport = new System.Windows.Forms.GroupBox();
            this.tlpReportExport = new System.Windows.Forms.TableLayoutPanel();
            this.lblReportGrouping = new System.Windows.Forms.Label();
            this.cmbReportGrouping = new System.Windows.Forms.ComboBox();
            this.chkCaptureImages = new System.Windows.Forms.CheckBox();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.btnExportHtml = new System.Windows.Forms.Button();
            this.lblReportStatus = new System.Windows.Forms.Label();
            this.btnStopReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tlpClash.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tlpGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPenetration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClearanceValue)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tlpOpen.SuspendLayout();
            this.groupReport.SuspendLayout();
            this.tlpReportExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupReport);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(1280, 760);
            this.splitContainer1.SplitterDistance = 380;
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
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Location = new System.Drawing.Point(12, 384);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(356, 86);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Result Option";
            // 
            // groupReport
            // 
            this.groupReport.Controls.Add(this.btnStopReport);
            this.groupReport.Controls.Add(this.lblReportStatus);
            this.groupReport.Controls.Add(this.tlpReportExport);
            this.groupReport.Controls.Add(this.chkCaptureImages);
            this.groupReport.Controls.Add(this.cmbReportGrouping);
            this.groupReport.Controls.Add(this.lblReportGrouping);
            this.groupReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupReport.Location = new System.Drawing.Point(12, 478);
            this.groupReport.Name = "groupReport";
            this.groupReport.Size = new System.Drawing.Size(356, 154);
            this.groupReport.TabIndex = 6;
            this.groupReport.TabStop = false;
            this.groupReport.Text = "결과 리포트 (CSV / HTML)";
            // 
            // lblReportGrouping
            // 
            this.lblReportGrouping.AutoSize = true;
            this.lblReportGrouping.Location = new System.Drawing.Point(12, 28);
            this.lblReportGrouping.Name = "lblReportGrouping";
            this.lblReportGrouping.Size = new System.Drawing.Size(81, 12);
            this.lblReportGrouping.TabIndex = 0;
            this.lblReportGrouping.Text = "결과 그룹 단위";
            // 
            // cmbReportGrouping
            // 
            this.cmbReportGrouping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportGrouping.FormattingEnabled = true;
            this.cmbReportGrouping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbReportGrouping.Location = new System.Drawing.Point(110, 24);
            this.cmbReportGrouping.Name = "cmbReportGrouping";
            this.cmbReportGrouping.Size = new System.Drawing.Size(234, 20);
            this.cmbReportGrouping.TabIndex = 1;
            // 
            // chkCaptureImages
            // 
            this.chkCaptureImages.AutoSize = true;
            this.chkCaptureImages.Checked = true;
            this.chkCaptureImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCaptureImages.Location = new System.Drawing.Point(12, 54);
            this.chkCaptureImages.Name = "chkCaptureImages";
            this.chkCaptureImages.Size = new System.Drawing.Size(212, 16);
            this.chkCaptureImages.TabIndex = 2;
            this.chkCaptureImages.Text = "HTML에 간섭 위치 캡처 이미지 포함";
            this.chkCaptureImages.UseVisualStyleBackColor = true;
            // 
            // tlpReportExport
            // 
            this.tlpReportExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpReportExport.ColumnCount = 2;
            this.tlpReportExport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpReportExport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpReportExport.Controls.Add(this.btnExportCsv, 0, 0);
            this.tlpReportExport.Controls.Add(this.btnExportHtml, 1, 0);
            this.tlpReportExport.Location = new System.Drawing.Point(9, 76);
            this.tlpReportExport.Name = "tlpReportExport";
            this.tlpReportExport.RowCount = 1;
            this.tlpReportExport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpReportExport.Size = new System.Drawing.Size(338, 36);
            this.tlpReportExport.TabIndex = 3;
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportCsv.Location = new System.Drawing.Point(3, 3);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(163, 30);
            this.btnExportCsv.TabIndex = 3;
            this.btnExportCsv.Text = "결과 CSV 내보내기";
            this.btnExportCsv.UseVisualStyleBackColor = true;
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            // 
            // btnExportHtml
            // 
            this.btnExportHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportHtml.Location = new System.Drawing.Point(172, 3);
            this.btnExportHtml.Name = "btnExportHtml";
            this.btnExportHtml.Size = new System.Drawing.Size(163, 30);
            this.btnExportHtml.TabIndex = 4;
            this.btnExportHtml.Text = "HTML 리포트 내보내기";
            this.btnExportHtml.UseVisualStyleBackColor = true;
            this.btnExportHtml.Click += new System.EventHandler(this.btnExportHtml_Click);
            // 
            // lblReportStatus
            // 
            this.lblReportStatus.AutoEllipsis = true;
            this.lblReportStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReportStatus.Location = new System.Drawing.Point(12, 120);
            this.lblReportStatus.Name = "lblReportStatus";
            this.lblReportStatus.Size = new System.Drawing.Size(244, 20);
            this.lblReportStatus.TabIndex = 5;
            this.lblReportStatus.Text = "상태 : 대기";
            this.lblReportStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStopReport
            // 
            this.btnStopReport.Enabled = false;
            this.btnStopReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopReport.Location = new System.Drawing.Point(264, 116);
            this.btnStopReport.Name = "btnStopReport";
            this.btnStopReport.Size = new System.Drawing.Size(80, 28);
            this.btnStopReport.TabIndex = 6;
            this.btnStopReport.Text = "중지";
            this.btnStopReport.UseVisualStyleBackColor = true;
            this.btnStopReport.Click += new System.EventHandler(this.btnStopReport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
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
            this.cbClashTestId.Location = new System.Drawing.Point(110, 54);
            this.cbClashTestId.Name = "cbClashTestId";
            this.cbClashTestId.Size = new System.Drawing.Size(234, 20);
            this.cbClashTestId.TabIndex = 6;
            this.cbClashTestId.SelectedIndexChanged += new System.EventHandler(this.ckResultKind_CheckedChanged);
            // 
            // ckIdentity
            // 
            this.ckIdentity.AutoSize = true;
            this.ckIdentity.Checked = true;
            this.ckIdentity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIdentity.Location = new System.Drawing.Point(236, 26);
            this.ckIdentity.Name = "ckIdentity";
            this.ckIdentity.Size = new System.Drawing.Size(48, 16);
            this.ckIdentity.TabIndex = 7;
            this.ckIdentity.Text = "동일";
            this.ckIdentity.UseVisualStyleBackColor = true;
            this.ckIdentity.AppearanceChanged += new System.EventHandler(this.ckResultKind_CheckedChanged);
            // 
            // ckClash
            // 
            this.ckClash.AutoSize = true;
            this.ckClash.Checked = true;
            this.ckClash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckClash.Location = new System.Drawing.Point(180, 26);
            this.ckClash.Name = "ckClash";
            this.ckClash.Size = new System.Drawing.Size(48, 16);
            this.ckClash.TabIndex = 6;
            this.ckClash.Text = "충돌";
            this.ckClash.UseVisualStyleBackColor = true;
            this.ckClash.CheckedChanged += new System.EventHandler(this.ckResultKind_CheckedChanged);
            // 
            // ckContact
            // 
            this.ckContact.AutoSize = true;
            this.ckContact.Checked = true;
            this.ckContact.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckContact.Location = new System.Drawing.Point(124, 26);
            this.ckContact.Name = "ckContact";
            this.ckContact.Size = new System.Drawing.Size(48, 16);
            this.ckContact.TabIndex = 5;
            this.ckContact.Text = "접촉";
            this.ckContact.UseVisualStyleBackColor = true;
            this.ckContact.CheckedChanged += new System.EventHandler(this.ckResultKind_CheckedChanged);
            // 
            // ckProximity
            // 
            this.ckProximity.AutoSize = true;
            this.ckProximity.Checked = true;
            this.ckProximity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckProximity.Location = new System.Drawing.Point(68, 26);
            this.ckProximity.Name = "ckProximity";
            this.ckProximity.Size = new System.Drawing.Size(48, 16);
            this.ckProximity.TabIndex = 4;
            this.ckProximity.Text = "근접";
            this.ckProximity.UseVisualStyleBackColor = true;
            this.ckProximity.CheckedChanged += new System.EventHandler(this.ckResultKind_CheckedChanged);
            // 
            // ckClearance
            // 
            this.ckClearance.AutoSize = true;
            this.ckClearance.Checked = true;
            this.ckClearance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckClearance.Location = new System.Drawing.Point(12, 26);
            this.ckClearance.Name = "ckClearance";
            this.ckClearance.Size = new System.Drawing.Size(48, 16);
            this.ckClearance.TabIndex = 3;
            this.ckClearance.Text = "여유";
            this.ckClearance.UseVisualStyleBackColor = true;
            this.ckClearance.CheckedChanged += new System.EventHandler(this.ckResultKind_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tlpClash);
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Location = new System.Drawing.Point(12, 308);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(356, 68);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Clash";
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(87, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Del";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(256, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 30);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Location = new System.Drawing.Point(172, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(78, 30);
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
            this.tlpClash.Controls.Add(this.btnExit, 3, 0);
            this.tlpClash.Location = new System.Drawing.Point(9, 22);
            this.tlpClash.Name = "tlpClash";
            this.tlpClash.RowCount = 1;
            this.tlpClash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClash.Size = new System.Drawing.Size(338, 36);
            this.tlpClash.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(78, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tlpGroup);
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Location = new System.Drawing.Point(12, 232);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 68);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Group";
            // 
            // btnAddGroupB
            // 
            this.btnAddGroupB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddGroupB.Location = new System.Drawing.Point(172, 3);
            this.btnAddGroupB.Name = "btnAddGroupB";
            this.btnAddGroupB.Size = new System.Drawing.Size(163, 30);
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
            this.tlpGroup.Size = new System.Drawing.Size(338, 36);
            this.tlpGroup.TabIndex = 0;
            // 
            // btnAddGroupA
            // 
            this.btnAddGroupA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddGroupA.Location = new System.Drawing.Point(3, 3);
            this.btnAddGroupA.Name = "btnAddGroupA";
            this.btnAddGroupA.Size = new System.Drawing.Size(163, 30);
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
            this.groupBox2.Controls.Add(this.numPenetration);
            this.groupBox2.Controls.Add(this.numRangeValue);
            this.groupBox2.Controls.Add(this.numClearanceValue);
            this.groupBox2.Controls.Add(this.ckUseRangeValue);
            this.groupBox2.Controls.Add(this.ckUseClearanceValue);
            this.groupBox2.Controls.Add(this.cbClashTestKind);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 144);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "접촉허용오차";
            // 
            // numPenetration
            // 
            this.numPenetration.DecimalPlaces = 2;
            this.numPenetration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numPenetration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numPenetration.Location = new System.Drawing.Point(140, 110);
            this.numPenetration.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numPenetration.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numPenetration.Name = "numPenetration";
            this.numPenetration.Size = new System.Drawing.Size(204, 21);
            this.numPenetration.TabIndex = 6;
            this.numPenetration.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147352576});
            // 
            // numRangeValue
            // 
            this.numRangeValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numRangeValue.Location = new System.Drawing.Point(140, 82);
            this.numRangeValue.Name = "numRangeValue";
            this.numRangeValue.Size = new System.Drawing.Size(204, 21);
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
            this.numClearanceValue.Location = new System.Drawing.Point(140, 54);
            this.numClearanceValue.Name = "numClearanceValue";
            this.numClearanceValue.Size = new System.Drawing.Size(204, 21);
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
            this.ckUseRangeValue.Location = new System.Drawing.Point(12, 84);
            this.ckUseRangeValue.Name = "ckUseRangeValue";
            this.ckUseRangeValue.Size = new System.Drawing.Size(96, 16);
            this.ckUseRangeValue.TabIndex = 3;
            this.ckUseRangeValue.Text = "근접허용범위";
            this.ckUseRangeValue.UseVisualStyleBackColor = true;
            // 
            // ckUseClearanceValue
            // 
            this.ckUseClearanceValue.AutoSize = true;
            this.ckUseClearanceValue.Location = new System.Drawing.Point(12, 56);
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
            this.cbClashTestKind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbClashTestKind.Location = new System.Drawing.Point(110, 24);
            this.cbClashTestKind.Name = "cbClashTestKind";
            this.cbClashTestKind.Size = new System.Drawing.Size(234, 20);
            this.cbClashTestKind.TabIndex = 1;
            this.cbClashTestKind.SelectedIndexChanged += new System.EventHandler(this.cbClashTestKind_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "검사유형";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tlpOpen);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Open";
            //
            // tlpOpen
            //
            this.tlpOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpOpen.ColumnCount = 2;
            this.tlpOpen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOpen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOpen.Controls.Add(this.btnOpenModel, 0, 0);
            this.tlpOpen.Controls.Add(this.btnLoadScenario, 1, 0);
            this.tlpOpen.Location = new System.Drawing.Point(9, 17);
            this.tlpOpen.Name = "tlpOpen";
            this.tlpOpen.RowCount = 1;
            this.tlpOpen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOpen.Size = new System.Drawing.Size(338, 36);
            this.tlpOpen.TabIndex = 0;
            //
            // btnLoadScenario
            //
            this.btnLoadScenario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadScenario.Enabled = false;
            this.btnLoadScenario.Location = new System.Drawing.Point(172, 3);
            this.btnLoadScenario.Name = "btnLoadScenario";
            this.btnLoadScenario.Size = new System.Drawing.Size(163, 30);
            this.btnLoadScenario.TabIndex = 1;
            this.btnLoadScenario.Text = "시나리오 불러오기";
            this.btnLoadScenario.UseVisualStyleBackColor = true;
            this.btnLoadScenario.Click += new System.EventHandler(this.btnLoadScenario_Click);
            //
            // btnOpenModel
            // 
            this.btnOpenModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenModel.Location = new System.Drawing.Point(3, 3);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(163, 30);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "Model";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvResult);
            this.splitContainer2.Size = new System.Drawing.Size(896, 760);
            this.splitContainer2.SplitterDistance = 496;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdA,
            this.group1NodeType,
            this.colIdB,
            this.Column3,
            this.Column7,
            this.Column6,
            this.Column4,
            this.Column5});
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvResult.Location = new System.Drawing.Point(0, 0);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(896, 260);
            this.dgvResult.TabIndex = 0;
            this.dgvResult.VirtualMode = true;
            this.dgvResult.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvResult_CellValueNeeded);
            this.dgvResult.SelectionChanged += new System.EventHandler(this.dgvResult_SelectionChanged);
            // 
            // colIdA
            // 
            this.colIdA.HeaderText = "ID1";
            this.colIdA.Name = "colIdA";
            this.colIdA.ReadOnly = true;
            this.colIdA.Width = 50;
            // 
            // group1NodeType
            // 
            this.group1NodeType.HeaderText = "Group1";
            this.group1NodeType.Name = "group1NodeType";
            this.group1NodeType.ReadOnly = true;
            this.group1NodeType.Width = 70;
            // 
            // colIdB
            // 
            this.colIdB.HeaderText = "ID2";
            this.colIdB.Name = "colIdB";
            this.colIdB.ReadOnly = true;
            this.colIdB.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Group2";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 70;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "State";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 70;
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
            this.Column4.Width = 220;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Direction";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 220;
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
            this.Text = "VIZCore3DX.NET.ClashTest";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tlpClash.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tlpGroup.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPenetration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRangeValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClearanceValue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tlpOpen.ResumeLayout(false);
            this.groupReport.ResumeLayout(false);
            this.tlpReportExport.ResumeLayout(false);
            this.groupReport.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.TableLayoutPanel tlpOpen;
        private System.Windows.Forms.Button btnLoadScenario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbClashTestKind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddGroupB;
        private System.Windows.Forms.Button btnAddGroupA;
        private System.Windows.Forms.NumericUpDown numPenetration;
        private System.Windows.Forms.NumericUpDown numRangeValue;
        private System.Windows.Forms.NumericUpDown numClearanceValue;
        private System.Windows.Forms.CheckBox ckUseRangeValue;
        private System.Windows.Forms.CheckBox ckUseClearanceValue;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdA;
        private System.Windows.Forms.DataGridViewTextBoxColumn group1NodeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tlpClash;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tlpGroup;
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
        private System.Windows.Forms.GroupBox groupReport;
        private System.Windows.Forms.TableLayoutPanel tlpReportExport;
        private System.Windows.Forms.Label lblReportGrouping;
        private System.Windows.Forms.ComboBox cmbReportGrouping;
        private System.Windows.Forms.CheckBox chkCaptureImages;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.Button btnExportHtml;
        private System.Windows.Forms.Label lblReportStatus;
        private System.Windows.Forms.Button btnStopReport;
    }
}

