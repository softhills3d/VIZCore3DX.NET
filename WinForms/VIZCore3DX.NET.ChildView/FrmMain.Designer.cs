namespace VIZCore3DX.NET.ChildView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tlpCommand = new System.Windows.Forms.TableLayoutPanel();
            this.btnClearItems = new System.Windows.Forms.Button();
            this.btnOpenChildView = new System.Windows.Forms.Button();
            this.groupSubView = new System.Windows.Forms.GroupBox();
            this.lblSubViewCount = new System.Windows.Forms.Label();
            this.lblInitModeInfo = new System.Windows.Forms.Label();
            this.btnApplySubView = new System.Windows.Forms.Button();
            this.cmbSubViewInitMode = new System.Windows.Forms.ComboBox();
            this.lblSubViewInitMode = new System.Windows.Forms.Label();
            this.cmbSubViewLayout = new System.Windows.Forms.ComboBox();
            this.lblSubViewLayout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tlpCommand.SuspendLayout();
            this.groupSubView.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupSubView);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1MinSize = 260;
            this.splitContainer1.Size = new System.Drawing.Size(1280, 760);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tlpCommand);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Child View (팝업)";
            // 
            // tlpCommand
            // 
            this.tlpCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpCommand.ColumnCount = 2;
            this.tlpCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCommand.Controls.Add(this.btnOpenChildView, 0, 0);
            this.tlpCommand.Controls.Add(this.btnClearItems, 1, 0);
            this.tlpCommand.Location = new System.Drawing.Point(9, 22);
            this.tlpCommand.Name = "tlpCommand";
            this.tlpCommand.RowCount = 1;
            this.tlpCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCommand.Size = new System.Drawing.Size(318, 36);
            this.tlpCommand.TabIndex = 0;
            // 
            // btnClearItems
            // 
            this.btnClearItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearItems.Location = new System.Drawing.Point(162, 3);
            this.btnClearItems.Name = "btnClearItems";
            this.btnClearItems.Size = new System.Drawing.Size(153, 30);
            this.btnClearItems.TabIndex = 1;
            this.btnClearItems.Text = "Clear Items";
            this.btnClearItems.UseVisualStyleBackColor = true;
            this.btnClearItems.Click += new System.EventHandler(this.btnClearItems_Click);
            // 
            // btnOpenChildView
            // 
            this.btnOpenChildView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenChildView.Location = new System.Drawing.Point(3, 3);
            this.btnOpenChildView.Name = "btnOpenChildView";
            this.btnOpenChildView.Size = new System.Drawing.Size(153, 30);
            this.btnOpenChildView.TabIndex = 0;
            this.btnOpenChildView.Text = "Show Child View";
            this.btnOpenChildView.UseVisualStyleBackColor = true;
            this.btnOpenChildView.Click += new System.EventHandler(this.btnOpenChildView_Click);
            // 
            // groupSubView
            // 
            this.groupSubView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSubView.Controls.Add(this.lblInitModeInfo);
            this.groupSubView.Controls.Add(this.lblSubViewCount);
            this.groupSubView.Controls.Add(this.btnApplySubView);
            this.groupSubView.Controls.Add(this.cmbSubViewInitMode);
            this.groupSubView.Controls.Add(this.lblSubViewInitMode);
            this.groupSubView.Controls.Add(this.cmbSubViewLayout);
            this.groupSubView.Controls.Add(this.lblSubViewLayout);
            this.groupSubView.Location = new System.Drawing.Point(12, 88);
            this.groupSubView.Name = "groupSubView";
            this.groupSubView.Size = new System.Drawing.Size(336, 150);
            this.groupSubView.TabIndex = 1;
            this.groupSubView.TabStop = false;
            this.groupSubView.Text = "화면 분할 (Sub View)";
            // 
            // lblInitModeInfo
            // 
            this.lblInitModeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInitModeInfo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblInitModeInfo.Location = new System.Drawing.Point(12, 80);
            this.lblInitModeInfo.Name = "lblInitModeInfo";
            this.lblInitModeInfo.Size = new System.Drawing.Size(312, 28);
            this.lblInitModeInfo.TabIndex = 6;
            this.lblInitModeInfo.Text = "초기화 모드 : 서브뷰를 만들 때 렌더링 설정(배경·음영 등)을 가져올 기준 (카메라와는 무관)";
            // 
            // lblSubViewCount
            // 
            this.lblSubViewCount.AutoSize = true;
            this.lblSubViewCount.Location = new System.Drawing.Point(12, 122);
            this.lblSubViewCount.Name = "lblSubViewCount";
            this.lblSubViewCount.Size = new System.Drawing.Size(109, 12);
            this.lblSubViewCount.TabIndex = 5;
            this.lblSubViewCount.Text = "현재 서브뷰 수 : -";
            // 
            // btnApplySubView
            // 
            this.btnApplySubView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplySubView.Location = new System.Drawing.Point(244, 114);
            this.btnApplySubView.Name = "btnApplySubView";
            this.btnApplySubView.Size = new System.Drawing.Size(80, 28);
            this.btnApplySubView.TabIndex = 4;
            this.btnApplySubView.Text = "적용";
            this.btnApplySubView.UseVisualStyleBackColor = true;
            this.btnApplySubView.Click += new System.EventHandler(this.btnApplySubView_Click);
            // 
            // cmbSubViewInitMode
            // 
            this.cmbSubViewInitMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSubViewInitMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubViewInitMode.FormattingEnabled = true;
            this.cmbSubViewInitMode.Location = new System.Drawing.Point(100, 55);
            this.cmbSubViewInitMode.Name = "cmbSubViewInitMode";
            this.cmbSubViewInitMode.Size = new System.Drawing.Size(224, 20);
            this.cmbSubViewInitMode.TabIndex = 3;
            // 
            // lblSubViewInitMode
            // 
            this.lblSubViewInitMode.AutoSize = true;
            this.lblSubViewInitMode.Location = new System.Drawing.Point(12, 59);
            this.lblSubViewInitMode.Name = "lblSubViewInitMode";
            this.lblSubViewInitMode.Size = new System.Drawing.Size(69, 12);
            this.lblSubViewInitMode.TabIndex = 2;
            this.lblSubViewInitMode.Text = "초기화 모드";
            // 
            // cmbSubViewLayout
            // 
            this.cmbSubViewLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSubViewLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubViewLayout.FormattingEnabled = true;
            this.cmbSubViewLayout.Location = new System.Drawing.Point(100, 27);
            this.cmbSubViewLayout.Name = "cmbSubViewLayout";
            this.cmbSubViewLayout.Size = new System.Drawing.Size(224, 20);
            this.cmbSubViewLayout.TabIndex = 1;
            // 
            // lblSubViewLayout
            // 
            this.lblSubViewLayout.AutoSize = true;
            this.lblSubViewLayout.Location = new System.Drawing.Point(12, 31);
            this.lblSubViewLayout.Name = "lblSubViewLayout";
            this.lblSubViewLayout.Size = new System.Drawing.Size(57, 12);
            this.lblSubViewLayout.TabIndex = 0;
            this.lblSubViewLayout.Text = "분할 형태";
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
            this.Text = "VIZCore3DX.NET.ChildView";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tlpCommand.ResumeLayout(false);
            this.groupSubView.ResumeLayout(false);
            this.groupSubView.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tlpCommand;
        private System.Windows.Forms.Button btnClearItems;
        private System.Windows.Forms.Button btnOpenChildView;
        private System.Windows.Forms.GroupBox groupSubView;
        private System.Windows.Forms.Label lblSubViewLayout;
        private System.Windows.Forms.ComboBox cmbSubViewLayout;
        private System.Windows.Forms.Label lblSubViewInitMode;
        private System.Windows.Forms.ComboBox cmbSubViewInitMode;
        private System.Windows.Forms.Button btnApplySubView;
        private System.Windows.Forms.Label lblSubViewCount;
        private System.Windows.Forms.Label lblInitModeInfo;
    }
}

