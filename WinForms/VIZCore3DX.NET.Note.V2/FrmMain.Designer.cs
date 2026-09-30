namespace VIZCore3DX.NET.Note.V2
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
            this.ckSymbol = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckEnable = new System.Windows.Forms.CheckBox();
            this.groupNoteList = new System.Windows.Forms.GroupBox();
            this.btnArrangeText = new System.Windows.Forms.Button();
            this.btnRefreshNotes = new System.Windows.Forms.Button();
            this.tlpNoteList = new System.Windows.Forms.TableLayoutPanel();
            this.dgvNotes = new System.Windows.Forms.DataGridView();
            this.colNoteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoteType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoteTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoteTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupTargetPosition = new System.Windows.Forms.GroupBox();
            this.btnSetTargetOsnap = new System.Windows.Forms.Button();
            this.lblTargetPosition = new System.Windows.Forms.Label();
            this.groupNoteData = new System.Windows.Forms.GroupBox();
            this.chkClearBeforeFromJson = new System.Windows.Forms.CheckBox();
            this.txtJson = new System.Windows.Forms.TextBox();
            this.btnFromJson = new System.Windows.Forms.Button();
            this.btnToJson = new System.Windows.Forms.Button();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.tlpNoteData = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupNoteList.SuspendLayout();
            this.tlpNoteList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotes)).BeginInit();
            this.groupTargetPosition.SuspendLayout();
            this.groupNoteData.SuspendLayout();
            this.tlpNoteData.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupNoteData);
            this.splitContainer1.Panel1.Controls.Add(this.groupTargetPosition);
            this.splitContainer1.Panel1.Controls.Add(this.groupNoteList);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(1285, 760);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ckSymbol);
            this.groupBox2.Location = new System.Drawing.Point(12, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 60);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option";
            // 
            // ckSymbol
            // 
            this.ckSymbol.AutoSize = true;
            this.ckSymbol.Location = new System.Drawing.Point(25, 27);
            this.ckSymbol.Name = "ckSymbol";
            this.ckSymbol.Size = new System.Drawing.Size(67, 16);
            this.ckSymbol.TabIndex = 1;
            this.ckSymbol.Text = "Symbol";
            this.ckSymbol.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ckEnable);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pick Surface And Add Note";
            // 
            // ckEnable
            // 
            this.ckEnable.AutoSize = true;
            this.ckEnable.Location = new System.Drawing.Point(25, 33);
            this.ckEnable.Name = "ckEnable";
            this.ckEnable.Size = new System.Drawing.Size(63, 16);
            this.ckEnable.TabIndex = 0;
            this.ckEnable.Text = "Enable";
            this.ckEnable.UseVisualStyleBackColor = true;
            // 
            // groupNoteList
            // 
            this.groupNoteList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupNoteList.Controls.Add(this.tlpNoteList);
            this.groupNoteList.Controls.Add(this.dgvNotes);
            this.groupNoteList.Location = new System.Drawing.Point(12, 160);
            this.groupNoteList.Name = "groupNoteList";
            this.groupNoteList.Size = new System.Drawing.Size(356, 230);
            this.groupNoteList.TabIndex = 2;
            this.groupNoteList.TabStop = false;
            this.groupNoteList.Text = "노트 목록";
            // 
            // tlpNoteList
            // 
            this.tlpNoteList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpNoteList.ColumnCount = 2;
            this.tlpNoteList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpNoteList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpNoteList.Controls.Add(this.btnRefreshNotes, 0, 0);
            this.tlpNoteList.Controls.Add(this.btnArrangeText, 1, 0);
            this.tlpNoteList.Location = new System.Drawing.Point(7, 186);
            this.tlpNoteList.Name = "tlpNoteList";
            this.tlpNoteList.RowCount = 1;
            this.tlpNoteList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNoteList.Size = new System.Drawing.Size(342, 34);
            this.tlpNoteList.TabIndex = 1;
            // 
            // btnArrangeText
            // 
            this.btnArrangeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnArrangeText.Location = new System.Drawing.Point(174, 3);
            this.btnArrangeText.Name = "btnArrangeText";
            this.btnArrangeText.Size = new System.Drawing.Size(165, 28);
            this.btnArrangeText.TabIndex = 1;
            this.btnArrangeText.Text = "텍스트 자동 배치";
            this.btnArrangeText.UseVisualStyleBackColor = true;
            this.btnArrangeText.Click += new System.EventHandler(this.btnArrangeText_Click);
            // 
            // btnRefreshNotes
            // 
            this.btnRefreshNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefreshNotes.Location = new System.Drawing.Point(3, 3);
            this.btnRefreshNotes.Name = "btnRefreshNotes";
            this.btnRefreshNotes.Size = new System.Drawing.Size(165, 28);
            this.btnRefreshNotes.TabIndex = 0;
            this.btnRefreshNotes.Text = "새로고침";
            this.btnRefreshNotes.UseVisualStyleBackColor = true;
            this.btnRefreshNotes.Click += new System.EventHandler(this.btnRefreshNotes_Click);
            // 
            // dgvNotes
            // 
            this.dgvNotes.AllowUserToAddRows = false;
            this.dgvNotes.AllowUserToDeleteRows = false;
            this.dgvNotes.AllowUserToResizeRows = false;
            this.dgvNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNoteId,
            this.colNoteType,
            this.colNoteTitle,
            this.colNoteTarget});
            this.dgvNotes.Location = new System.Drawing.Point(10, 20);
            this.dgvNotes.MultiSelect = false;
            this.dgvNotes.Name = "dgvNotes";
            this.dgvNotes.ReadOnly = true;
            this.dgvNotes.RowHeadersVisible = false;
            this.dgvNotes.RowTemplate.Height = 23;
            this.dgvNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotes.Size = new System.Drawing.Size(336, 160);
            this.dgvNotes.TabIndex = 0;
            this.dgvNotes.SelectionChanged += new System.EventHandler(this.dgvNotes_SelectionChanged);
            // 
            // colNoteId
            // 
            this.colNoteId.HeaderText = "ID";
            this.colNoteId.Name = "colNoteId";
            this.colNoteId.ReadOnly = true;
            this.colNoteId.Width = 40;
            // 
            // colNoteType
            // 
            this.colNoteType.HeaderText = "유형";
            this.colNoteType.Name = "colNoteType";
            this.colNoteType.ReadOnly = true;
            this.colNoteType.Width = 60;
            // 
            // colNoteTitle
            // 
            this.colNoteTitle.HeaderText = "제목";
            this.colNoteTitle.Name = "colNoteTitle";
            this.colNoteTitle.ReadOnly = true;
            this.colNoteTitle.Width = 80;
            // 
            // colNoteTarget
            // 
            this.colNoteTarget.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNoteTarget.HeaderText = "대상점";
            this.colNoteTarget.Name = "colNoteTarget";
            this.colNoteTarget.ReadOnly = true;
            // 
            // groupTargetPosition
            // 
            this.groupTargetPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupTargetPosition.Controls.Add(this.btnSetTargetOsnap);
            this.groupTargetPosition.Controls.Add(this.lblTargetPosition);
            this.groupTargetPosition.Location = new System.Drawing.Point(12, 398);
            this.groupTargetPosition.Name = "groupTargetPosition";
            this.groupTargetPosition.Size = new System.Drawing.Size(356, 84);
            this.groupTargetPosition.TabIndex = 3;
            this.groupTargetPosition.TabStop = false;
            this.groupTargetPosition.Text = "표면 노트 대상점 이동";
            // 
            // btnSetTargetOsnap
            // 
            this.btnSetTargetOsnap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetTargetOsnap.Location = new System.Drawing.Point(10, 46);
            this.btnSetTargetOsnap.Name = "btnSetTargetOsnap";
            this.btnSetTargetOsnap.Size = new System.Drawing.Size(336, 28);
            this.btnSetTargetOsnap.TabIndex = 1;
            this.btnSetTargetOsnap.Text = "대상점 선택 (Osnap)";
            this.btnSetTargetOsnap.UseVisualStyleBackColor = true;
            this.btnSetTargetOsnap.Click += new System.EventHandler(this.btnSetTargetOsnap_Click);
            // 
            // lblTargetPosition
            // 
            this.lblTargetPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTargetPosition.AutoEllipsis = true;
            this.lblTargetPosition.Location = new System.Drawing.Point(10, 20);
            this.lblTargetPosition.Name = "lblTargetPosition";
            this.lblTargetPosition.Size = new System.Drawing.Size(336, 20);
            this.lblTargetPosition.TabIndex = 0;
            this.lblTargetPosition.Text = "대상점 : -";
            this.lblTargetPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupNoteData
            // 
            this.groupNoteData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupNoteData.Controls.Add(this.chkClearBeforeFromJson);
            this.groupNoteData.Controls.Add(this.txtJson);
            this.groupNoteData.Controls.Add(this.tlpNoteData);
            this.groupNoteData.Location = new System.Drawing.Point(12, 490);
            this.groupNoteData.Name = "groupNoteData";
            this.groupNoteData.Size = new System.Drawing.Size(356, 258);
            this.groupNoteData.TabIndex = 4;
            this.groupNoteData.TabStop = false;
            this.groupNoteData.Text = "내보내기 / 문자열 저장·복원";
            // 
            // chkClearBeforeFromJson
            // 
            this.chkClearBeforeFromJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkClearBeforeFromJson.AutoSize = true;
            this.chkClearBeforeFromJson.Checked = true;
            this.chkClearBeforeFromJson.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClearBeforeFromJson.Location = new System.Drawing.Point(10, 232);
            this.chkClearBeforeFromJson.Name = "chkClearBeforeFromJson";
            this.chkClearBeforeFromJson.Size = new System.Drawing.Size(172, 16);
            this.chkClearBeforeFromJson.TabIndex = 2;
            this.chkClearBeforeFromJson.Text = "복원 전 기존 노트 모두 삭제";
            this.chkClearBeforeFromJson.UseVisualStyleBackColor = true;
            // 
            // txtJson
            // 
            this.txtJson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJson.Location = new System.Drawing.Point(10, 58);
            this.txtJson.MaxLength = 0;
            this.txtJson.Multiline = true;
            this.txtJson.Name = "txtJson";
            this.txtJson.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtJson.Size = new System.Drawing.Size(336, 168);
            this.txtJson.TabIndex = 1;
            this.txtJson.WordWrap = false;
            // 
            // btnFromJson
            // 
            this.btnFromJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFromJson.Location = new System.Drawing.Point(231, 3);
            this.btnFromJson.Name = "btnFromJson";
            this.btnFromJson.Size = new System.Drawing.Size(108, 28);
            this.btnFromJson.TabIndex = 2;
            this.btnFromJson.Text = "FromJson";
            this.btnFromJson.UseVisualStyleBackColor = true;
            this.btnFromJson.Click += new System.EventHandler(this.btnFromJson_Click);
            // 
            // btnToJson
            // 
            this.btnToJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToJson.Location = new System.Drawing.Point(117, 3);
            this.btnToJson.Name = "btnToJson";
            this.btnToJson.Size = new System.Drawing.Size(108, 28);
            this.btnToJson.TabIndex = 1;
            this.btnToJson.Text = "ToJson";
            this.btnToJson.UseVisualStyleBackColor = true;
            this.btnToJson.Click += new System.EventHandler(this.btnToJson_Click);
            // 
            // tlpNoteData
            // 
            this.tlpNoteData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpNoteData.ColumnCount = 3;
            this.tlpNoteData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpNoteData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpNoteData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpNoteData.Controls.Add(this.btnExportCsv, 0, 0);
            this.tlpNoteData.Controls.Add(this.btnToJson, 1, 0);
            this.tlpNoteData.Controls.Add(this.btnFromJson, 2, 0);
            this.tlpNoteData.Location = new System.Drawing.Point(7, 20);
            this.tlpNoteData.Name = "tlpNoteData";
            this.tlpNoteData.RowCount = 1;
            this.tlpNoteData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNoteData.Size = new System.Drawing.Size(342, 34);
            this.tlpNoteData.TabIndex = 0;
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportCsv.Location = new System.Drawing.Point(3, 3);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(108, 28);
            this.btnExportCsv.TabIndex = 0;
            this.btnExportCsv.Text = "CSV 내보내기";
            this.btnExportCsv.UseVisualStyleBackColor = true;
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 760);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.Note.V2";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupNoteList.ResumeLayout(false);
            this.tlpNoteList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotes)).EndInit();
            this.groupTargetPosition.ResumeLayout(false);
            this.groupTargetPosition.PerformLayout();
            this.groupNoteData.ResumeLayout(false);
            this.groupNoteData.PerformLayout();
            this.tlpNoteData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckSymbol;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckEnable;
        private System.Windows.Forms.GroupBox groupNoteList;
        private System.Windows.Forms.DataGridView dgvNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoteId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoteType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoteTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoteTarget;
        private System.Windows.Forms.Button btnRefreshNotes;
        private System.Windows.Forms.Button btnArrangeText;
        private System.Windows.Forms.TableLayoutPanel tlpNoteList;
        private System.Windows.Forms.GroupBox groupTargetPosition;
        private System.Windows.Forms.Label lblTargetPosition;
        private System.Windows.Forms.Button btnSetTargetOsnap;
        private System.Windows.Forms.GroupBox groupNoteData;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.Button btnToJson;
        private System.Windows.Forms.Button btnFromJson;
        private System.Windows.Forms.TableLayoutPanel tlpNoteData;
        private System.Windows.Forms.TextBox txtJson;
        private System.Windows.Forms.CheckBox chkClearBeforeFromJson;
    }
}

