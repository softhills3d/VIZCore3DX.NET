namespace VIZCore3DX.NET.MeasureFrame
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenFrame = new System.Windows.Forms.Button();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.btnShowFrame = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtZ = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowOsnap = new System.Windows.Forms.Button();
            this.groupMeasureData = new System.Windows.Forms.GroupBox();
            this.tlpMeasureJson = new System.Windows.Forms.TableLayoutPanel();
            this.btnMeasureToJson = new System.Windows.Forms.Button();
            this.btnMeasureFromJson = new System.Windows.Forms.Button();
            this.tlpMeasureEdit = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddDistance = new System.Windows.Forms.Button();
            this.btnClearMeasure = new System.Windows.Forms.Button();
            this.chkClearBeforeFromJson = new System.Windows.Forms.CheckBox();
            this.txtMeasureJson = new System.Windows.Forms.TextBox();
            this.btnExportMeasureCsv = new System.Windows.Forms.Button();
            this.lblMeasureCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupMeasureData.SuspendLayout();
            this.tlpMeasureJson.SuspendLayout();
            this.tlpMeasureEdit.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupMeasureData);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.btnShowFrame);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1MinSize = 280;
            this.splitContainer1.Size = new System.Drawing.Size(1280, 760);
            this.splitContainer1.SplitterDistance = 340;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnOpenFrame);
            this.groupBox2.Controls.Add(this.btnOpenModel);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 89);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Model / Frame";
            // 
            // btnOpenFrame
            // 
            this.btnOpenFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFrame.Location = new System.Drawing.Point(16, 49);
            this.btnOpenFrame.Name = "btnOpenFrame";
            this.btnOpenFrame.Size = new System.Drawing.Size(282, 23);
            this.btnOpenFrame.TabIndex = 1;
            this.btnOpenFrame.Text = "Open Frame";
            this.btnOpenFrame.UseVisualStyleBackColor = true;
            this.btnOpenFrame.Click += new System.EventHandler(this.btnOpenFrame_Click);
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenModel.Location = new System.Drawing.Point(16, 20);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(282, 23);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "Open Model";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // btnShowFrame
            // 
            this.btnShowFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowFrame.Location = new System.Drawing.Point(234, 271);
            this.btnShowFrame.Name = "btnShowFrame";
            this.btnShowFrame.Size = new System.Drawing.Size(97, 23);
            this.btnShowFrame.TabIndex = 1;
            this.btnShowFrame.Text = "Show Frame";
            this.btnShowFrame.UseVisualStyleBackColor = true;
            this.btnShowFrame.Click += new System.EventHandler(this.btnShowFrame_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtZ);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtY);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtX);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnShowOsnap);
            this.groupBox1.Location = new System.Drawing.Point(12, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Measure Point";
            // 
            // txtZ
            // 
            this.txtZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZ.Location = new System.Drawing.Point(43, 116);
            this.txtZ.Name = "txtZ";
            this.txtZ.Size = new System.Drawing.Size(255, 21);
            this.txtZ.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Z";
            // 
            // txtY
            // 
            this.txtY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtY.Location = new System.Drawing.Point(43, 89);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(255, 21);
            this.txtY.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y";
            // 
            // txtX
            // 
            this.txtX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtX.Location = new System.Drawing.Point(43, 62);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(255, 21);
            this.txtX.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            // 
            // btnShowOsnap
            // 
            this.btnShowOsnap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowOsnap.Location = new System.Drawing.Point(16, 20);
            this.btnShowOsnap.Name = "btnShowOsnap";
            this.btnShowOsnap.Size = new System.Drawing.Size(282, 23);
            this.btnShowOsnap.TabIndex = 0;
            this.btnShowOsnap.Text = "Show Osnap";
            this.btnShowOsnap.UseVisualStyleBackColor = true;
            this.btnShowOsnap.Click += new System.EventHandler(this.btnShowOsnap_Click);
            //
            // groupMeasureData
            //
            this.groupMeasureData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupMeasureData.Controls.Add(this.tlpMeasureJson);
            this.groupMeasureData.Controls.Add(this.tlpMeasureEdit);
            this.groupMeasureData.Controls.Add(this.chkClearBeforeFromJson);
            this.groupMeasureData.Controls.Add(this.txtMeasureJson);
            this.groupMeasureData.Controls.Add(this.btnExportMeasureCsv);
            this.groupMeasureData.Controls.Add(this.lblMeasureCount);
            this.groupMeasureData.Location = new System.Drawing.Point(12, 300);
            this.groupMeasureData.Name = "groupMeasureData";
            this.groupMeasureData.Size = new System.Drawing.Size(319, 448);
            this.groupMeasureData.TabIndex = 8;
            this.groupMeasureData.TabStop = false;
            this.groupMeasureData.Text = "측정 목록 내보내기 / 저장·복원";
            //
            // tlpMeasureEdit
            //
            this.tlpMeasureEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMeasureEdit.ColumnCount = 2;
            this.tlpMeasureEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMeasureEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMeasureEdit.Controls.Add(this.btnAddDistance, 0, 0);
            this.tlpMeasureEdit.Controls.Add(this.btnClearMeasure, 1, 0);
            this.tlpMeasureEdit.Location = new System.Drawing.Point(13, 17);
            this.tlpMeasureEdit.Name = "tlpMeasureEdit";
            this.tlpMeasureEdit.RowCount = 1;
            this.tlpMeasureEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMeasureEdit.Size = new System.Drawing.Size(288, 29);
            this.tlpMeasureEdit.TabIndex = 0;
            //
            // btnAddDistance
            //
            this.btnAddDistance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddDistance.Location = new System.Drawing.Point(3, 3);
            this.btnAddDistance.Name = "btnAddDistance";
            this.btnAddDistance.Size = new System.Drawing.Size(138, 23);
            this.btnAddDistance.TabIndex = 0;
            this.btnAddDistance.Text = "프레임 거리 측정";
            this.btnAddDistance.UseVisualStyleBackColor = true;
            this.btnAddDistance.Click += new System.EventHandler(this.btnAddDistance_Click);
            //
            // btnClearMeasure
            //
            this.btnClearMeasure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearMeasure.Location = new System.Drawing.Point(147, 3);
            this.btnClearMeasure.Name = "btnClearMeasure";
            this.btnClearMeasure.Size = new System.Drawing.Size(138, 23);
            this.btnClearMeasure.TabIndex = 1;
            this.btnClearMeasure.Text = "측정 모두 삭제";
            this.btnClearMeasure.UseVisualStyleBackColor = true;
            this.btnClearMeasure.Click += new System.EventHandler(this.btnClearMeasure_Click);
            //
            // lblMeasureCount
            //
            this.lblMeasureCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMeasureCount.AutoEllipsis = true;
            this.lblMeasureCount.Location = new System.Drawing.Point(16, 49);
            this.lblMeasureCount.Name = "lblMeasureCount";
            this.lblMeasureCount.Size = new System.Drawing.Size(282, 20);
            this.lblMeasureCount.TabIndex = 1;
            this.lblMeasureCount.Text = "측정 개수 : 0";
            this.lblMeasureCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnExportMeasureCsv
            //
            this.btnExportMeasureCsv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportMeasureCsv.Location = new System.Drawing.Point(16, 72);
            this.btnExportMeasureCsv.Name = "btnExportMeasureCsv";
            this.btnExportMeasureCsv.Size = new System.Drawing.Size(282, 23);
            this.btnExportMeasureCsv.TabIndex = 2;
            this.btnExportMeasureCsv.Text = "CSV 내보내기";
            this.btnExportMeasureCsv.UseVisualStyleBackColor = true;
            this.btnExportMeasureCsv.Click += new System.EventHandler(this.btnExportMeasureCsv_Click);
            //
            // tlpMeasureJson
            //
            this.tlpMeasureJson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMeasureJson.ColumnCount = 2;
            this.tlpMeasureJson.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMeasureJson.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMeasureJson.Controls.Add(this.btnMeasureToJson, 0, 0);
            this.tlpMeasureJson.Controls.Add(this.btnMeasureFromJson, 1, 0);
            this.tlpMeasureJson.Location = new System.Drawing.Point(13, 98);
            this.tlpMeasureJson.Name = "tlpMeasureJson";
            this.tlpMeasureJson.RowCount = 1;
            this.tlpMeasureJson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMeasureJson.Size = new System.Drawing.Size(288, 29);
            this.tlpMeasureJson.TabIndex = 3;
            //
            // btnMeasureToJson
            //
            this.btnMeasureToJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMeasureToJson.Location = new System.Drawing.Point(3, 3);
            this.btnMeasureToJson.Name = "btnMeasureToJson";
            this.btnMeasureToJson.Size = new System.Drawing.Size(138, 23);
            this.btnMeasureToJson.TabIndex = 0;
            this.btnMeasureToJson.Text = "ToJson";
            this.btnMeasureToJson.UseVisualStyleBackColor = true;
            this.btnMeasureToJson.Click += new System.EventHandler(this.btnMeasureToJson_Click);
            //
            // btnMeasureFromJson
            //
            this.btnMeasureFromJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMeasureFromJson.Location = new System.Drawing.Point(147, 3);
            this.btnMeasureFromJson.Name = "btnMeasureFromJson";
            this.btnMeasureFromJson.Size = new System.Drawing.Size(138, 23);
            this.btnMeasureFromJson.TabIndex = 1;
            this.btnMeasureFromJson.Text = "FromJson";
            this.btnMeasureFromJson.UseVisualStyleBackColor = true;
            this.btnMeasureFromJson.Click += new System.EventHandler(this.btnMeasureFromJson_Click);
            //
            // txtMeasureJson
            //
            this.txtMeasureJson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMeasureJson.Location = new System.Drawing.Point(16, 131);
            this.txtMeasureJson.MaxLength = 0;
            this.txtMeasureJson.Multiline = true;
            this.txtMeasureJson.Name = "txtMeasureJson";
            this.txtMeasureJson.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMeasureJson.Size = new System.Drawing.Size(282, 287);
            this.txtMeasureJson.TabIndex = 4;
            this.txtMeasureJson.WordWrap = false;
            //
            // chkClearBeforeFromJson
            //
            this.chkClearBeforeFromJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkClearBeforeFromJson.AutoSize = true;
            this.chkClearBeforeFromJson.Checked = true;
            this.chkClearBeforeFromJson.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClearBeforeFromJson.Location = new System.Drawing.Point(16, 424);
            this.chkClearBeforeFromJson.Name = "chkClearBeforeFromJson";
            this.chkClearBeforeFromJson.Size = new System.Drawing.Size(172, 16);
            this.chkClearBeforeFromJson.TabIndex = 5;
            this.chkClearBeforeFromJson.Text = "복원 전 기존 측정 모두 삭제";
            this.chkClearBeforeFromJson.UseVisualStyleBackColor = true;
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
            this.Text = "VIZCore3DX.NET.MeasureFrame";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupMeasureData.ResumeLayout(false);
            this.groupMeasureData.PerformLayout();
            this.tlpMeasureJson.ResumeLayout(false);
            this.tlpMeasureEdit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOpenFrame;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Button btnShowFrame;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowOsnap;
        private System.Windows.Forms.GroupBox groupMeasureData;
        private System.Windows.Forms.TableLayoutPanel tlpMeasureEdit;
        private System.Windows.Forms.Button btnAddDistance;
        private System.Windows.Forms.Button btnClearMeasure;
        private System.Windows.Forms.Label lblMeasureCount;
        private System.Windows.Forms.Button btnExportMeasureCsv;
        private System.Windows.Forms.TableLayoutPanel tlpMeasureJson;
        private System.Windows.Forms.Button btnMeasureToJson;
        private System.Windows.Forms.Button btnMeasureFromJson;
        private System.Windows.Forms.TextBox txtMeasureJson;
        private System.Windows.Forms.CheckBox chkClearBeforeFromJson;
    }
}

