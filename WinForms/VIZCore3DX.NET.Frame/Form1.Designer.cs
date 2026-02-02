namespace VIZCore3DX.NET.Frame
{
    partial class Form1
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnHasFrame = new System.Windows.Forms.Button();
            this.btnImportFrame = new System.Windows.Forms.Button();
            this.btnExportFrame = new System.Windows.Forms.Button();
            this.btnCreateFrame = new System.Windows.Forms.Button();
            this.btnOpenTribonFrame = new System.Windows.Forms.Button();
            this.btnOpenAMFrame = new System.Windows.Forms.Button();
            this.btnOpenModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.splitContainer1.Size = new System.Drawing.Size(1231, 786);
            this.splitContainer1.SplitterDistance = 340;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lvFrameLine);
            this.groupBox4.Location = new System.Drawing.Point(12, 496);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(318, 148);
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
            this.lvFrameLine.Size = new System.Drawing.Size(312, 128);
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
            this.groupBox3.Controls.Add(this.btnClearFrameLines);
            this.groupBox3.Controls.Add(this.btnToggleFrameLineEnabled);
            this.groupBox3.Controls.Add(this.rbZAxis);
            this.groupBox3.Controls.Add(this.rbYAxis);
            this.groupBox3.Controls.Add(this.rbXAxis);
            this.groupBox3.Location = new System.Drawing.Point(15, 382);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(315, 103);
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
            this.groupBox2.Controls.Add(this.btnToggleZXPlaneEnabled);
            this.groupBox2.Controls.Add(this.btnToggleYZPlaneEnabled);
            this.groupBox2.Controls.Add(this.btnToggleXYPlaneEnabled);
            this.groupBox2.Controls.Add(this.btnToggleFrameIsVisible);
            this.groupBox2.Controls.Add(this.lvFrame);
            this.groupBox2.Location = new System.Drawing.Point(15, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 127);
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
            this.btnToggleZXPlaneEnabled.Text = "Toggle XYPlaneEnabled";
            this.btnToggleZXPlaneEnabled.UseVisualStyleBackColor = true;
            this.btnToggleZXPlaneEnabled.Click += new System.EventHandler(this.btnToggleZXPlaneEnabled_Click);
            // 
            // btnToggleYZPlaneEnabled
            // 
            this.btnToggleYZPlaneEnabled.Location = new System.Drawing.Point(115, 73);
            this.btnToggleYZPlaneEnabled.Name = "btnToggleYZPlaneEnabled";
            this.btnToggleYZPlaneEnabled.Size = new System.Drawing.Size(176, 23);
            this.btnToggleYZPlaneEnabled.TabIndex = 3;
            this.btnToggleYZPlaneEnabled.Text = "Toggle XYPlaneEnabled";
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
            this.richTextBox1.Location = new System.Drawing.Point(3, 659);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(334, 121);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnHasFrame);
            this.groupBox1.Controls.Add(this.btnImportFrame);
            this.groupBox1.Controls.Add(this.btnExportFrame);
            this.groupBox1.Controls.Add(this.btnCreateFrame);
            this.groupBox1.Controls.Add(this.btnOpenTribonFrame);
            this.groupBox1.Controls.Add(this.btnOpenAMFrame);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 163);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(165, 107);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(74, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnHasFrame
            // 
            this.btnHasFrame.Location = new System.Drawing.Point(7, 108);
            this.btnHasFrame.Name = "btnHasFrame";
            this.btnHasFrame.Size = new System.Drawing.Size(75, 23);
            this.btnHasFrame.TabIndex = 5;
            this.btnHasFrame.Text = "HasFrame";
            this.btnHasFrame.UseVisualStyleBackColor = true;
            this.btnHasFrame.Click += new System.EventHandler(this.btnHasFrame_Click);
            // 
            // btnImportFrame
            // 
            this.btnImportFrame.Location = new System.Drawing.Point(165, 78);
            this.btnImportFrame.Name = "btnImportFrame";
            this.btnImportFrame.Size = new System.Drawing.Size(129, 23);
            this.btnImportFrame.TabIndex = 4;
            this.btnImportFrame.Text = "Import Frame";
            this.btnImportFrame.UseVisualStyleBackColor = true;
            this.btnImportFrame.Click += new System.EventHandler(this.btnImportFrame_Click);
            // 
            // btnExportFrame
            // 
            this.btnExportFrame.Location = new System.Drawing.Point(7, 79);
            this.btnExportFrame.Name = "btnExportFrame";
            this.btnExportFrame.Size = new System.Drawing.Size(129, 23);
            this.btnExportFrame.TabIndex = 3;
            this.btnExportFrame.Text = "Export Frame";
            this.btnExportFrame.UseVisualStyleBackColor = true;
            this.btnExportFrame.Click += new System.EventHandler(this.btnExportFrame_Click);
            // 
            // btnCreateFrame
            // 
            this.btnCreateFrame.Location = new System.Drawing.Point(7, 50);
            this.btnCreateFrame.Name = "btnCreateFrame";
            this.btnCreateFrame.Size = new System.Drawing.Size(129, 23);
            this.btnCreateFrame.TabIndex = 2;
            this.btnCreateFrame.Text = "Create Frame";
            this.btnCreateFrame.UseVisualStyleBackColor = true;
            this.btnCreateFrame.Click += new System.EventHandler(this.btnCreateFrame_Click);
            // 
            // btnOpenTribonFrame
            // 
            this.btnOpenTribonFrame.Location = new System.Drawing.Point(165, 20);
            this.btnOpenTribonFrame.Name = "btnOpenTribonFrame";
            this.btnOpenTribonFrame.Size = new System.Drawing.Size(129, 23);
            this.btnOpenTribonFrame.TabIndex = 1;
            this.btnOpenTribonFrame.Text = "Open Tribon Frame";
            this.btnOpenTribonFrame.UseVisualStyleBackColor = true;
            this.btnOpenTribonFrame.Click += new System.EventHandler(this.btnOpenTribonFrame_Click);
            // 
            // btnOpenAMFrame
            // 
            this.btnOpenAMFrame.Location = new System.Drawing.Point(7, 21);
            this.btnOpenAMFrame.Name = "btnOpenAMFrame";
            this.btnOpenAMFrame.Size = new System.Drawing.Size(129, 23);
            this.btnOpenAMFrame.TabIndex = 0;
            this.btnOpenAMFrame.Text = "Open AM Frame";
            this.btnOpenAMFrame.UseVisualStyleBackColor = true;
            this.btnOpenAMFrame.Click += new System.EventHandler(this.btnOpenAMFrame_Click);
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Location = new System.Drawing.Point(12, 12);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(127, 23);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "Open Model";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 786);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
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
    }
}

