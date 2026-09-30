namespace VIZCore3DX.NET.Frame
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lvFrameLine = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClearFrameLines = new System.Windows.Forms.Button();
            this.btnToggleFrameLineEnabled = new System.Windows.Forms.Button();
            this.rbZAxis = new System.Windows.Forms.RadioButton();
            this.rbYAxis = new System.Windows.Forms.RadioButton();
            this.rbXAxis = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnToggleZXPlaneEnabled = new System.Windows.Forms.Button();
            this.btnToggleYZPlaneEnabled = new System.Windows.Forms.Button();
            this.btnToggleXYPlaneEnabled = new System.Windows.Forms.Button();
            this.btnToggleFrameIsVisible = new System.Windows.Forms.Button();
            this.lvFrame = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnHasFrame = new System.Windows.Forms.Button();
            this.btnImportFrame = new System.Windows.Forms.Button();
            this.btnExportFrame = new System.Windows.Forms.Button();
            this.btnCreateFrame = new System.Windows.Forms.Button();
            this.btnOpenTribonFrame = new System.Windows.Forms.Button();
            this.btnOpenAMFrame = new System.Windows.Forms.Button();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.btnShowAllFrames = new System.Windows.Forms.Button();
            this.btnHideAllFrames = new System.Windows.Forms.Button();
            this.btnFrameLineColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btnOpenModel);
            this.splitContainer1.Size = new System.Drawing.Size(1280, 836);
            this.splitContainer1.SplitterDistance = 340;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lvFrameLine);
            this.groupBox4.Location = new System.Drawing.Point(12, 499);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(318, 204);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Frame Line List";
            // 
            // lvFrameLine
            // 
            this.lvFrameLine.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvFrameLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFrameLine.HideSelection = false;
            this.lvFrameLine.Location = new System.Drawing.Point(3, 17);
            this.lvFrameLine.Name = "lvFrameLine";
            this.lvFrameLine.Size = new System.Drawing.Size(312, 184);
            this.lvFrameLine.TabIndex = 0;
            this.lvFrameLine.UseCompatibleStateImageBehavior = false;
            this.lvFrameLine.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 57;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Offset";
            this.columnHeader3.Width = 99;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "CustomLabel";
            this.columnHeader4.Width = 130;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnClearFrameLines);
            this.groupBox3.Controls.Add(this.btnToggleFrameLineEnabled);
            this.groupBox3.Controls.Add(this.rbZAxis);
            this.groupBox3.Controls.Add(this.rbYAxis);
            this.groupBox3.Controls.Add(this.rbXAxis);
            this.groupBox3.Location = new System.Drawing.Point(12, 390);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 103);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Frame Axis List";
            // 
            // btnClearFrameLines
            // 
            this.btnClearFrameLines.Location = new System.Drawing.Point(6, 71);
            this.btnClearFrameLines.Name = "btnClearFrameLines";
            this.btnClearFrameLines.Size = new System.Drawing.Size(117, 23);
            this.btnClearFrameLines.TabIndex = 4;
            this.btnClearFrameLines.Text = "ClearFrameLines";
            this.btnClearFrameLines.UseVisualStyleBackColor = true;
            this.btnClearFrameLines.Click += new System.EventHandler(this.btnClearFrameLines_Click);
            // 
            // btnToggleFrameLineEnabled
            // 
            this.btnToggleFrameLineEnabled.Location = new System.Drawing.Point(6, 42);
            this.btnToggleFrameLineEnabled.Name = "btnToggleFrameLineEnabled";
            this.btnToggleFrameLineEnabled.Size = new System.Drawing.Size(231, 23);
            this.btnToggleFrameLineEnabled.TabIndex = 3;
            this.btnToggleFrameLineEnabled.Text = "Toggle IsFrameLineEnabled";
            this.btnToggleFrameLineEnabled.UseVisualStyleBackColor = true;
            this.btnToggleFrameLineEnabled.Click += new System.EventHandler(this.btnToggleFrameLineEnabled_Click);
            // 
            // rbZAxis
            // 
            this.rbZAxis.AutoSize = true;
            this.rbZAxis.Location = new System.Drawing.Point(177, 20);
            this.rbZAxis.Name = "rbZAxis";
            this.rbZAxis.Size = new System.Drawing.Size(60, 16);
            this.rbZAxis.TabIndex = 2;
            this.rbZAxis.Text = "Z Axis";
            this.rbZAxis.UseVisualStyleBackColor = true;
            this.rbZAxis.Click += new System.EventHandler(this.rbZAxis_Click);
            // 
            // rbYAxis
            // 
            this.rbYAxis.AutoSize = true;
            this.rbYAxis.Location = new System.Drawing.Point(96, 20);
            this.rbYAxis.Name = "rbYAxis";
            this.rbYAxis.Size = new System.Drawing.Size(60, 16);
            this.rbYAxis.TabIndex = 1;
            this.rbYAxis.Text = "Y Axis";
            this.rbYAxis.UseVisualStyleBackColor = true;
            this.rbYAxis.Click += new System.EventHandler(this.rbYAxis_Click);
            // 
            // rbXAxis
            // 
            this.rbXAxis.AutoSize = true;
            this.rbXAxis.Checked = true;
            this.rbXAxis.Location = new System.Drawing.Point(7, 20);
            this.rbXAxis.Name = "rbXAxis";
            this.rbXAxis.Size = new System.Drawing.Size(60, 16);
            this.rbXAxis.TabIndex = 0;
            this.rbXAxis.TabStop = true;
            this.rbXAxis.Text = "X Axis";
            this.rbXAxis.UseVisualStyleBackColor = true;
            this.rbXAxis.Click += new System.EventHandler(this.rbXAxis_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnToggleZXPlaneEnabled);
            this.groupBox2.Controls.Add(this.btnToggleYZPlaneEnabled);
            this.groupBox2.Controls.Add(this.btnToggleXYPlaneEnabled);
            this.groupBox2.Controls.Add(this.btnToggleFrameIsVisible);
            this.groupBox2.Controls.Add(this.lvFrame);
            this.groupBox2.Location = new System.Drawing.Point(12, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 142);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Frame List";
            // 
            // btnToggleZXPlaneEnabled
            // 
            this.btnToggleZXPlaneEnabled.Location = new System.Drawing.Point(115, 98);
            this.btnToggleZXPlaneEnabled.Name = "btnToggleZXPlaneEnabled";
            this.btnToggleZXPlaneEnabled.Size = new System.Drawing.Size(176, 23);
            this.btnToggleZXPlaneEnabled.TabIndex = 4;
            this.btnToggleZXPlaneEnabled.Text = "Toggle ZXPlaneEnabled";
            this.btnToggleZXPlaneEnabled.UseVisualStyleBackColor = true;
            this.btnToggleZXPlaneEnabled.Click += new System.EventHandler(this.btnToggleZXPlaneEnabled_Click);
            // 
            // btnToggleYZPlaneEnabled
            // 
            this.btnToggleYZPlaneEnabled.Location = new System.Drawing.Point(115, 73);
            this.btnToggleYZPlaneEnabled.Name = "btnToggleYZPlaneEnabled";
            this.btnToggleYZPlaneEnabled.Size = new System.Drawing.Size(176, 23);
            this.btnToggleYZPlaneEnabled.TabIndex = 3;
            this.btnToggleYZPlaneEnabled.Text = "Toggle YZPlaneEnabled";
            this.btnToggleYZPlaneEnabled.UseVisualStyleBackColor = true;
            this.btnToggleYZPlaneEnabled.Click += new System.EventHandler(this.btnToggleYZPlaneEnabled_Click);
            // 
            // btnToggleXYPlaneEnabled
            // 
            this.btnToggleXYPlaneEnabled.Location = new System.Drawing.Point(115, 48);
            this.btnToggleXYPlaneEnabled.Name = "btnToggleXYPlaneEnabled";
            this.btnToggleXYPlaneEnabled.Size = new System.Drawing.Size(176, 23);
            this.btnToggleXYPlaneEnabled.TabIndex = 2;
            this.btnToggleXYPlaneEnabled.Text = "Toggle XYPlaneEnabled";
            this.btnToggleXYPlaneEnabled.UseVisualStyleBackColor = true;
            this.btnToggleXYPlaneEnabled.Click += new System.EventHandler(this.btnToggleXYPlaneEnabled_Click);
            // 
            // btnToggleFrameIsVisible
            // 
            this.btnToggleFrameIsVisible.Location = new System.Drawing.Point(115, 20);
            this.btnToggleFrameIsVisible.Name = "btnToggleFrameIsVisible";
            this.btnToggleFrameIsVisible.Size = new System.Drawing.Size(176, 23);
            this.btnToggleFrameIsVisible.TabIndex = 1;
            this.btnToggleFrameIsVisible.Text = "Toggle IsVisible";
            this.btnToggleFrameIsVisible.UseVisualStyleBackColor = true;
            this.btnToggleFrameIsVisible.Click += new System.EventHandler(this.btnToggleFrameIsVisible_Click);
            // 
            // lvFrame
            // 
            this.lvFrame.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvFrame.HideSelection = false;
            this.lvFrame.Location = new System.Drawing.Point(7, 20);
            this.lvFrame.MultiSelect = false;
            this.lvFrame.Name = "lvFrame";
            this.lvFrame.Size = new System.Drawing.Size(102, 97);
            this.lvFrame.TabIndex = 0;
            this.lvFrame.UseCompatibleStateImageBehavior = false;
            this.lvFrame.View = System.Windows.Forms.View.Details;
            this.lvFrame.SelectedIndexChanged += new System.EventHandler(this.lvFrame_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Frame ID";
            this.columnHeader1.Width = 71;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 709);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(318, 121);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 190);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnOpenAMFrame, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOpenTribonFrame, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCreateFrame, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnFrameLineColor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnExportFrame, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnImportFrame, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnHasFrame, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnClear, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnShowAllFrames, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnHideAllFrames, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(312, 170);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(159, 105);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 28);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnHasFrame
            // 
            this.btnHasFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHasFrame.Location = new System.Drawing.Point(3, 105);
            this.btnHasFrame.Name = "btnHasFrame";
            this.btnHasFrame.Size = new System.Drawing.Size(150, 28);
            this.btnHasFrame.TabIndex = 5;
            this.btnHasFrame.Text = "HasFrame";
            this.btnHasFrame.UseVisualStyleBackColor = true;
            this.btnHasFrame.Click += new System.EventHandler(this.btnHasFrame_Click);
            // 
            // btnImportFrame
            // 
            this.btnImportFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportFrame.Location = new System.Drawing.Point(159, 71);
            this.btnImportFrame.Name = "btnImportFrame";
            this.btnImportFrame.Size = new System.Drawing.Size(150, 28);
            this.btnImportFrame.TabIndex = 4;
            this.btnImportFrame.Text = "Import Frame";
            this.btnImportFrame.UseVisualStyleBackColor = true;
            this.btnImportFrame.Click += new System.EventHandler(this.btnImportFrame_Click);
            // 
            // btnExportFrame
            // 
            this.btnExportFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportFrame.Location = new System.Drawing.Point(3, 71);
            this.btnExportFrame.Name = "btnExportFrame";
            this.btnExportFrame.Size = new System.Drawing.Size(150, 28);
            this.btnExportFrame.TabIndex = 3;
            this.btnExportFrame.Text = "Export Frame";
            this.btnExportFrame.UseVisualStyleBackColor = true;
            this.btnExportFrame.Click += new System.EventHandler(this.btnExportFrame_Click);
            // 
            // btnCreateFrame
            // 
            this.btnCreateFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreateFrame.Location = new System.Drawing.Point(3, 37);
            this.btnCreateFrame.Name = "btnCreateFrame";
            this.btnCreateFrame.Size = new System.Drawing.Size(150, 28);
            this.btnCreateFrame.TabIndex = 2;
            this.btnCreateFrame.Text = "Create Frame";
            this.btnCreateFrame.UseVisualStyleBackColor = true;
            this.btnCreateFrame.Click += new System.EventHandler(this.btnCreateFrame_Click);
            // 
            // btnOpenTribonFrame
            // 
            this.btnOpenTribonFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenTribonFrame.Location = new System.Drawing.Point(159, 3);
            this.btnOpenTribonFrame.Name = "btnOpenTribonFrame";
            this.btnOpenTribonFrame.Size = new System.Drawing.Size(150, 28);
            this.btnOpenTribonFrame.TabIndex = 1;
            this.btnOpenTribonFrame.Text = "Open Tribon Frame";
            this.btnOpenTribonFrame.UseVisualStyleBackColor = true;
            this.btnOpenTribonFrame.Click += new System.EventHandler(this.btnOpenTribonFrame_Click);
            // 
            // btnOpenAMFrame
            // 
            this.btnOpenAMFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenAMFrame.Location = new System.Drawing.Point(3, 3);
            this.btnOpenAMFrame.Name = "btnOpenAMFrame";
            this.btnOpenAMFrame.Size = new System.Drawing.Size(150, 28);
            this.btnOpenAMFrame.TabIndex = 0;
            this.btnOpenAMFrame.Text = "Open AM Frame";
            this.btnOpenAMFrame.UseVisualStyleBackColor = true;
            this.btnOpenAMFrame.Click += new System.EventHandler(this.btnOpenAMFrame_Click);
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenModel.Location = new System.Drawing.Point(12, 12);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(318, 28);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "Open Model";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // btnShowAllFrames
            // 
            this.btnShowAllFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowAllFrames.Location = new System.Drawing.Point(3, 139);
            this.btnShowAllFrames.Name = "btnShowAllFrames";
            this.btnShowAllFrames.Size = new System.Drawing.Size(150, 28);
            this.btnShowAllFrames.TabIndex = 7;
            this.btnShowAllFrames.Text = "Show All Frames";
            this.btnShowAllFrames.UseVisualStyleBackColor = true;
            this.btnShowAllFrames.Click += new System.EventHandler(this.btnShowAllFrames_Click);
            // 
            // btnHideAllFrames
            // 
            this.btnHideAllFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHideAllFrames.Location = new System.Drawing.Point(159, 139);
            this.btnHideAllFrames.Name = "btnHideAllFrames";
            this.btnHideAllFrames.Size = new System.Drawing.Size(150, 28);
            this.btnHideAllFrames.TabIndex = 8;
            this.btnHideAllFrames.Text = "Hide All Frames";
            this.btnHideAllFrames.UseVisualStyleBackColor = true;
            this.btnHideAllFrames.Click += new System.EventHandler(this.btnHideAllFrames_Click);
            // 
            // btnFrameLineColor
            // 
            this.btnFrameLineColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFrameLineColor.Location = new System.Drawing.Point(159, 37);
            this.btnFrameLineColor.Name = "btnFrameLineColor";
            this.btnFrameLineColor.Size = new System.Drawing.Size(150, 28);
            this.btnFrameLineColor.TabIndex = 9;
            this.btnFrameLineColor.Text = "FrameLineColor";
            this.btnFrameLineColor.UseVisualStyleBackColor = true;
            this.btnFrameLineColor.Click += new System.EventHandler(this.btnFrameLineColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 836);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "VIZCore3DX.NET.Frame";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenAMFrame;
        private System.Windows.Forms.Button btnOpenTribonFrame;
        private System.Windows.Forms.Button btnCreateFrame;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnExportFrame;
        private System.Windows.Forms.Button btnImportFrame;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbZAxis;
        private System.Windows.Forms.RadioButton rbYAxis;
        private System.Windows.Forms.RadioButton rbXAxis;
        private System.Windows.Forms.ListView lvFrame;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnToggleFrameIsVisible;
        private System.Windows.Forms.ListView lvFrameLine;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnToggleFrameLineEnabled;
        private System.Windows.Forms.Button btnToggleXYPlaneEnabled;
        private System.Windows.Forms.Button btnToggleZXPlaneEnabled;
        private System.Windows.Forms.Button btnToggleYZPlaneEnabled;
        private System.Windows.Forms.Button btnHasFrame;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClearFrameLines;
        private System.Windows.Forms.Button btnHideAllFrames;
        private System.Windows.Forms.Button btnShowAllFrames;
        private System.Windows.Forms.Button btnFrameLineColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

