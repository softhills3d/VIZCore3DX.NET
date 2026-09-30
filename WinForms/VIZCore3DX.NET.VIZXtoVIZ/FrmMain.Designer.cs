namespace VIZCore3DX.NET.VIZXtoVIZ
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
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.grpExportModel = new System.Windows.Forms.GroupBox();
            this.grpConvertFile = new System.Windows.Forms.GroupBox();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.tlpModel = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.btnAddModels = new System.Windows.Forms.Button();
            this.btnCloseModel = new System.Windows.Forms.Button();
            this.lblExportOption = new System.Windows.Forms.Label();
            this.cbExportOption = new System.Windows.Forms.ComboBox();
            this.lblExportOutput = new System.Windows.Forms.Label();
            this.txtExportOutput = new System.Windows.Forms.TextBox();
            this.btnBrowseExportOutput = new System.Windows.Forms.Button();
            this.btnExportModel = new System.Windows.Forms.Button();
            this.lblConvertInput = new System.Windows.Forms.Label();
            this.txtConvertInput = new System.Windows.Forms.TextBox();
            this.btnBrowseConvertInput = new System.Windows.Forms.Button();
            this.lblConvertOutput = new System.Windows.Forms.Label();
            this.txtConvertOutput = new System.Windows.Forms.TextBox();
            this.btnBrowseConvertOutput = new System.Windows.Forms.Button();
            this.btnConvertFile = new System.Windows.Forms.Button();
            this.chkShowInExplorer = new System.Windows.Forms.CheckBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpModel.SuspendLayout();
            this.grpExportModel.SuspendLayout();
            this.grpConvertFile.SuspendLayout();
            this.grpResult.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpResult);
            this.splitContainer1.Panel1.Controls.Add(this.grpConvertFile);
            this.splitContainer1.Panel1.Controls.Add(this.grpExportModel);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(1280, 760);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 0;
            // 
            // grpModel
            // 
            this.grpModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpModel.Controls.Add(this.tlpModel);
            this.grpModel.Location = new System.Drawing.Point(12, 12);
            this.grpModel.Name = "grpModel";
            this.grpModel.Size = new System.Drawing.Size(336, 66);
            this.grpModel.TabIndex = 0;
            this.grpModel.TabStop = false;
            this.grpModel.Text = "Model";
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
            this.tlpModel.Location = new System.Drawing.Point(9, 20);
            this.tlpModel.Name = "tlpModel";
            this.tlpModel.RowCount = 1;
            this.tlpModel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpModel.Size = new System.Drawing.Size(318, 36);
            this.tlpModel.TabIndex = 0;
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenModel.Location = new System.Drawing.Point(3, 3);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(100, 30);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "Open";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // btnAddModels
            // 
            this.btnAddModels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddModels.Location = new System.Drawing.Point(109, 3);
            this.btnAddModels.Name = "btnAddModels";
            this.btnAddModels.Size = new System.Drawing.Size(100, 30);
            this.btnAddModels.TabIndex = 1;
            this.btnAddModels.Text = "Add";
            this.btnAddModels.UseVisualStyleBackColor = true;
            this.btnAddModels.Click += new System.EventHandler(this.btnAddModels_Click);
            // 
            // btnCloseModel
            // 
            this.btnCloseModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCloseModel.Location = new System.Drawing.Point(215, 3);
            this.btnCloseModel.Name = "btnCloseModel";
            this.btnCloseModel.Size = new System.Drawing.Size(100, 30);
            this.btnCloseModel.TabIndex = 2;
            this.btnCloseModel.Text = "Close";
            this.btnCloseModel.UseVisualStyleBackColor = true;
            this.btnCloseModel.Click += new System.EventHandler(this.btnCloseModel_Click);
            // 
            // grpExportModel
            // 
            this.grpExportModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpExportModel.Controls.Add(this.btnExportModel);
            this.grpExportModel.Controls.Add(this.btnBrowseExportOutput);
            this.grpExportModel.Controls.Add(this.txtExportOutput);
            this.grpExportModel.Controls.Add(this.lblExportOutput);
            this.grpExportModel.Controls.Add(this.cbExportOption);
            this.grpExportModel.Controls.Add(this.lblExportOption);
            this.grpExportModel.Location = new System.Drawing.Point(12, 86);
            this.grpExportModel.Name = "grpExportModel";
            this.grpExportModel.Size = new System.Drawing.Size(336, 152);
            this.grpExportModel.TabIndex = 1;
            this.grpExportModel.TabStop = false;
            this.grpExportModel.Text = "Export Current Model (VIZ)";
            // 
            // lblExportOption
            // 
            this.lblExportOption.AutoSize = true;
            this.lblExportOption.Location = new System.Drawing.Point(12, 28);
            this.lblExportOption.Name = "lblExportOption";
            this.lblExportOption.Size = new System.Drawing.Size(40, 12);
            this.lblExportOption.TabIndex = 0;
            this.lblExportOption.Text = "Range";
            // 
            // cbExportOption
            // 
            this.cbExportOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExportOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExportOption.FormattingEnabled = true;
            this.cbExportOption.Location = new System.Drawing.Point(96, 24);
            this.cbExportOption.Name = "cbExportOption";
            this.cbExportOption.Size = new System.Drawing.Size(228, 20);
            this.cbExportOption.TabIndex = 1;
            // 
            // lblExportOutput
            // 
            this.lblExportOutput.AutoSize = true;
            this.lblExportOutput.Location = new System.Drawing.Point(12, 58);
            this.lblExportOutput.Name = "lblExportOutput";
            this.lblExportOutput.Size = new System.Drawing.Size(64, 12);
            this.lblExportOutput.TabIndex = 2;
            this.lblExportOutput.Text = "Output VIZ";
            // 
            // txtExportOutput
            // 
            this.txtExportOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportOutput.Location = new System.Drawing.Point(12, 76);
            this.txtExportOutput.Name = "txtExportOutput";
            this.txtExportOutput.Size = new System.Drawing.Size(266, 21);
            this.txtExportOutput.TabIndex = 3;
            // 
            // btnBrowseExportOutput
            // 
            this.btnBrowseExportOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseExportOutput.Location = new System.Drawing.Point(284, 75);
            this.btnBrowseExportOutput.Name = "btnBrowseExportOutput";
            this.btnBrowseExportOutput.Size = new System.Drawing.Size(40, 23);
            this.btnBrowseExportOutput.TabIndex = 4;
            this.btnBrowseExportOutput.Text = "...";
            this.btnBrowseExportOutput.UseVisualStyleBackColor = true;
            this.btnBrowseExportOutput.Click += new System.EventHandler(this.btnBrowseExportOutput_Click);
            // 
            // btnExportModel
            // 
            this.btnExportModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportModel.Location = new System.Drawing.Point(12, 108);
            this.btnExportModel.Name = "btnExportModel";
            this.btnExportModel.Size = new System.Drawing.Size(312, 30);
            this.btnExportModel.TabIndex = 5;
            this.btnExportModel.Text = "Export VIZ";
            this.btnExportModel.UseVisualStyleBackColor = true;
            this.btnExportModel.Click += new System.EventHandler(this.btnExportModel_Click);
            // 
            // grpConvertFile
            // 
            this.grpConvertFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConvertFile.Controls.Add(this.btnConvertFile);
            this.grpConvertFile.Controls.Add(this.btnBrowseConvertOutput);
            this.grpConvertFile.Controls.Add(this.txtConvertOutput);
            this.grpConvertFile.Controls.Add(this.lblConvertOutput);
            this.grpConvertFile.Controls.Add(this.btnBrowseConvertInput);
            this.grpConvertFile.Controls.Add(this.txtConvertInput);
            this.grpConvertFile.Controls.Add(this.lblConvertInput);
            this.grpConvertFile.Location = new System.Drawing.Point(12, 246);
            this.grpConvertFile.Name = "grpConvertFile";
            this.grpConvertFile.Size = new System.Drawing.Size(336, 170);
            this.grpConvertFile.TabIndex = 2;
            this.grpConvertFile.TabStop = false;
            this.grpConvertFile.Text = "Convert VIZX File to VIZ";
            // 
            // lblConvertInput
            // 
            this.lblConvertInput.AutoSize = true;
            this.lblConvertInput.Location = new System.Drawing.Point(12, 26);
            this.lblConvertInput.Name = "lblConvertInput";
            this.lblConvertInput.Size = new System.Drawing.Size(64, 12);
            this.lblConvertInput.TabIndex = 0;
            this.lblConvertInput.Text = "Input VIZX";
            // 
            // txtConvertInput
            // 
            this.txtConvertInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConvertInput.Location = new System.Drawing.Point(12, 44);
            this.txtConvertInput.Name = "txtConvertInput";
            this.txtConvertInput.Size = new System.Drawing.Size(266, 21);
            this.txtConvertInput.TabIndex = 1;
            // 
            // btnBrowseConvertInput
            // 
            this.btnBrowseConvertInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseConvertInput.Location = new System.Drawing.Point(284, 43);
            this.btnBrowseConvertInput.Name = "btnBrowseConvertInput";
            this.btnBrowseConvertInput.Size = new System.Drawing.Size(40, 23);
            this.btnBrowseConvertInput.TabIndex = 2;
            this.btnBrowseConvertInput.Text = "...";
            this.btnBrowseConvertInput.UseVisualStyleBackColor = true;
            this.btnBrowseConvertInput.Click += new System.EventHandler(this.btnBrowseConvertInput_Click);
            // 
            // lblConvertOutput
            // 
            this.lblConvertOutput.AutoSize = true;
            this.lblConvertOutput.Location = new System.Drawing.Point(12, 76);
            this.lblConvertOutput.Name = "lblConvertOutput";
            this.lblConvertOutput.Size = new System.Drawing.Size(64, 12);
            this.lblConvertOutput.TabIndex = 3;
            this.lblConvertOutput.Text = "Output VIZ";
            // 
            // txtConvertOutput
            // 
            this.txtConvertOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConvertOutput.Location = new System.Drawing.Point(12, 94);
            this.txtConvertOutput.Name = "txtConvertOutput";
            this.txtConvertOutput.Size = new System.Drawing.Size(266, 21);
            this.txtConvertOutput.TabIndex = 4;
            // 
            // btnBrowseConvertOutput
            // 
            this.btnBrowseConvertOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseConvertOutput.Location = new System.Drawing.Point(284, 93);
            this.btnBrowseConvertOutput.Name = "btnBrowseConvertOutput";
            this.btnBrowseConvertOutput.Size = new System.Drawing.Size(40, 23);
            this.btnBrowseConvertOutput.TabIndex = 5;
            this.btnBrowseConvertOutput.Text = "...";
            this.btnBrowseConvertOutput.UseVisualStyleBackColor = true;
            this.btnBrowseConvertOutput.Click += new System.EventHandler(this.btnBrowseConvertOutput_Click);
            // 
            // btnConvertFile
            // 
            this.btnConvertFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertFile.Location = new System.Drawing.Point(12, 126);
            this.btnConvertFile.Name = "btnConvertFile";
            this.btnConvertFile.Size = new System.Drawing.Size(312, 30);
            this.btnConvertFile.TabIndex = 6;
            this.btnConvertFile.Text = "Convert";
            this.btnConvertFile.UseVisualStyleBackColor = true;
            this.btnConvertFile.Click += new System.EventHandler(this.btnConvertFile_Click);
            // 
            // grpResult
            // 
            this.grpResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResult.Controls.Add(this.txtResult);
            this.grpResult.Controls.Add(this.chkShowInExplorer);
            this.grpResult.Location = new System.Drawing.Point(12, 424);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(336, 324);
            this.grpResult.TabIndex = 3;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "Result";
            // 
            // chkShowInExplorer
            // 
            this.chkShowInExplorer.AutoSize = true;
            this.chkShowInExplorer.Location = new System.Drawing.Point(12, 24);
            this.chkShowInExplorer.Name = "chkShowInExplorer";
            this.chkShowInExplorer.Size = new System.Drawing.Size(186, 16);
            this.chkShowInExplorer.TabIndex = 0;
            this.chkShowInExplorer.Text = "Show result file in Explorer";
            this.chkShowInExplorer.UseVisualStyleBackColor = true;
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(12, 48);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(312, 264);
            this.txtResult.TabIndex = 1;
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
            this.Text = "VIZCore3DX.NET.VIZXtoVIZ";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpModel.ResumeLayout(false);
            this.grpExportModel.ResumeLayout(false);
            this.grpExportModel.PerformLayout();
            this.grpConvertFile.ResumeLayout(false);
            this.grpConvertFile.PerformLayout();
            this.grpResult.ResumeLayout(false);
            this.grpResult.PerformLayout();
            this.tlpModel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.GroupBox grpExportModel;
        private System.Windows.Forms.GroupBox grpConvertFile;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.TableLayoutPanel tlpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Button btnAddModels;
        private System.Windows.Forms.Button btnCloseModel;
        private System.Windows.Forms.Label lblExportOption;
        private System.Windows.Forms.ComboBox cbExportOption;
        private System.Windows.Forms.Label lblExportOutput;
        private System.Windows.Forms.TextBox txtExportOutput;
        private System.Windows.Forms.Button btnBrowseExportOutput;
        private System.Windows.Forms.Button btnExportModel;
        private System.Windows.Forms.Label lblConvertInput;
        private System.Windows.Forms.TextBox txtConvertInput;
        private System.Windows.Forms.Button btnBrowseConvertInput;
        private System.Windows.Forms.Label lblConvertOutput;
        private System.Windows.Forms.TextBox txtConvertOutput;
        private System.Windows.Forms.Button btnBrowseConvertOutput;
        private System.Windows.Forms.Button btnConvertFile;
        private System.Windows.Forms.CheckBox chkShowInExplorer;
        private System.Windows.Forms.TextBox txtResult;
    }
}
