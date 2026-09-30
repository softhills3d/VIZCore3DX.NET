namespace VIZCore3DX.NET.PlasticFocusReview
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
            this.grpFocus = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemovePlastic = new System.Windows.Forms.Button();
            this.lstPlasticNodes = new System.Windows.Forms.ListBox();
            this.lblPlasticCount = new System.Windows.Forms.Label();
            this.chkSetPivot = new System.Windows.Forms.CheckBox();
            this.btnApplyPlastic = new System.Windows.Forms.Button();
            this.lblFocusGuide = new System.Windows.Forms.Label();
            this.grpPlastic = new System.Windows.Forms.GroupBox();
            this.cboSelectionObject3DType = new System.Windows.Forms.ComboBox();
            this.lblSelectionObject3DType = new System.Windows.Forms.Label();
            this.rdoObjectColor = new System.Windows.Forms.RadioButton();
            this.rdoSelectionColor = new System.Windows.Forms.RadioButton();
            this.lblColorType = new System.Windows.Forms.Label();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.btnOpenModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpFocus.SuspendLayout();
            this.grpPlastic.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpFocus);
            this.splitContainer1.Panel1.Controls.Add(this.grpPlastic);
            this.splitContainer1.Panel1.Controls.Add(this.btnOpenModel);
            this.splitContainer1.Size = new System.Drawing.Size(1100, 661);
            this.splitContainer1.SplitterDistance = 270;
            this.splitContainer1.TabIndex = 0;
            // 
            // grpFocus
            // 
            this.grpFocus.Controls.Add(this.btnClear);
            this.grpFocus.Controls.Add(this.btnRemovePlastic);
            this.grpFocus.Controls.Add(this.lstPlasticNodes);
            this.grpFocus.Controls.Add(this.lblPlasticCount);
            this.grpFocus.Controls.Add(this.chkSetPivot);
            this.grpFocus.Controls.Add(this.btnApplyPlastic);
            this.grpFocus.Controls.Add(this.lblFocusGuide);
            this.grpFocus.Location = new System.Drawing.Point(12, 216);
            this.grpFocus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpFocus.Name = "grpFocus";
            this.grpFocus.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpFocus.Size = new System.Drawing.Size(246, 419);
            this.grpFocus.TabIndex = 2;
            this.grpFocus.TabStop = false;
            this.grpFocus.Text = "Focus Review";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(134, 361);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(97, 30);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear (전체)";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnRemovePlastic
            // 
            this.btnRemovePlastic.Location = new System.Drawing.Point(15, 361);
            this.btnRemovePlastic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemovePlastic.Name = "btnRemovePlastic";
            this.btnRemovePlastic.Size = new System.Drawing.Size(113, 30);
            this.btnRemovePlastic.TabIndex = 5;
            this.btnRemovePlastic.Text = "선택 Plastic 해제";
            this.btnRemovePlastic.UseVisualStyleBackColor = true;
            this.btnRemovePlastic.Click += new System.EventHandler(this.BtnRemovePlastic_Click);
            // 
            // lstPlasticNodes
            // 
            this.lstPlasticNodes.FormattingEnabled = true;
            this.lstPlasticNodes.HorizontalScrollbar = true;
            this.lstPlasticNodes.ItemHeight = 12;
            this.lstPlasticNodes.Location = new System.Drawing.Point(15, 135);
            this.lstPlasticNodes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstPlasticNodes.Name = "lstPlasticNodes";
            this.lstPlasticNodes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstPlasticNodes.Size = new System.Drawing.Size(216, 208);
            this.lstPlasticNodes.TabIndex = 4;
            // 
            // lblPlasticCount
            // 
            this.lblPlasticCount.AutoSize = true;
            this.lblPlasticCount.Location = new System.Drawing.Point(12, 115);
            this.lblPlasticCount.Name = "lblPlasticCount";
            this.lblPlasticCount.Size = new System.Drawing.Size(89, 12);
            this.lblPlasticCount.TabIndex = 3;
            this.lblPlasticCount.Text = "Plastic 노드 : 0";
            // 
            // chkSetPivot
            // 
            this.chkSetPivot.AutoSize = true;
            this.chkSetPivot.Location = new System.Drawing.Point(15, 83);
            this.chkSetPivot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkSetPivot.Name = "chkSetPivot";
            this.chkSetPivot.Size = new System.Drawing.Size(168, 16);
            this.chkSetPivot.TabIndex = 2;
            this.chkSetPivot.Text = "선택 노드를 회전 중심으로";
            this.chkSetPivot.UseVisualStyleBackColor = true;
            // 
            // btnApplyPlastic
            // 
            this.btnApplyPlastic.Location = new System.Drawing.Point(15, 43);
            this.btnApplyPlastic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApplyPlastic.Name = "btnApplyPlastic";
            this.btnApplyPlastic.Size = new System.Drawing.Size(216, 30);
            this.btnApplyPlastic.TabIndex = 1;
            this.btnApplyPlastic.Text = "현재 선택 노드 Plastic 적용";
            this.btnApplyPlastic.UseVisualStyleBackColor = true;
            this.btnApplyPlastic.Click += new System.EventHandler(this.BtnApplyPlastic_Click);
            // 
            // lblFocusGuide
            // 
            this.lblFocusGuide.AutoSize = true;
            this.lblFocusGuide.Location = new System.Drawing.Point(12, 22);
            this.lblFocusGuide.Name = "lblFocusGuide";
            this.lblFocusGuide.Size = new System.Drawing.Size(219, 12);
            this.lblFocusGuide.TabIndex = 0;
            this.lblFocusGuide.Text = "모델에서 노드를 선택한 후 Plastic 적용";
            // 
            // grpPlastic
            // 
            this.grpPlastic.Controls.Add(this.cboSelectionObject3DType);
            this.grpPlastic.Controls.Add(this.lblSelectionObject3DType);
            this.grpPlastic.Controls.Add(this.rdoObjectColor);
            this.grpPlastic.Controls.Add(this.rdoSelectionColor);
            this.grpPlastic.Controls.Add(this.lblColorType);
            this.grpPlastic.Controls.Add(this.chkEnable);
            this.grpPlastic.Location = new System.Drawing.Point(12, 48);
            this.grpPlastic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpPlastic.Name = "grpPlastic";
            this.grpPlastic.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpPlastic.Size = new System.Drawing.Size(246, 158);
            this.grpPlastic.TabIndex = 1;
            this.grpPlastic.TabStop = false;
            this.grpPlastic.Text = "Plastic";
            // 
            // cboSelectionObject3DType
            // 
            this.cboSelectionObject3DType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectionObject3DType.FormattingEnabled = true;
            this.cboSelectionObject3DType.Location = new System.Drawing.Point(15, 119);
            this.cboSelectionObject3DType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboSelectionObject3DType.Name = "cboSelectionObject3DType";
            this.cboSelectionObject3DType.Size = new System.Drawing.Size(216, 20);
            this.cboSelectionObject3DType.TabIndex = 5;
            this.cboSelectionObject3DType.SelectedIndexChanged += new System.EventHandler(this.CboSelectionObject3DType_SelectedIndexChanged);
            // 
            // lblSelectionObject3DType
            // 
            this.lblSelectionObject3DType.AutoSize = true;
            this.lblSelectionObject3DType.Location = new System.Drawing.Point(12, 99);
            this.lblSelectionObject3DType.Name = "lblSelectionObject3DType";
            this.lblSelectionObject3DType.Size = new System.Drawing.Size(97, 12);
            this.lblSelectionObject3DType.TabIndex = 4;
            this.lblSelectionObject3DType.Text = "Selection Object";
            // 
            // rdoObjectColor
            // 
            this.rdoObjectColor.AutoSize = true;
            this.rdoObjectColor.Location = new System.Drawing.Point(126, 67);
            this.rdoObjectColor.Name = "rdoObjectColor";
            this.rdoObjectColor.Size = new System.Drawing.Size(75, 16);
            this.rdoObjectColor.TabIndex = 3;
            this.rdoObjectColor.TabStop = true;
            this.rdoObjectColor.Text = "원래 색상";
            this.rdoObjectColor.UseVisualStyleBackColor = true;
            this.rdoObjectColor.CheckedChanged += new System.EventHandler(this.RdoObjectColor_CheckedChanged);
            // 
            // rdoSelectionColor
            // 
            this.rdoSelectionColor.AutoSize = true;
            this.rdoSelectionColor.Location = new System.Drawing.Point(15, 67);
            this.rdoSelectionColor.Name = "rdoSelectionColor";
            this.rdoSelectionColor.Size = new System.Drawing.Size(113, 16);
            this.rdoSelectionColor.TabIndex = 2;
            this.rdoSelectionColor.TabStop = true;
            this.rdoSelectionColor.Text = "선택 색상 (빨강)";
            this.rdoSelectionColor.UseVisualStyleBackColor = true;
            this.rdoSelectionColor.CheckedChanged += new System.EventHandler(this.RdoSelectionColor_CheckedChanged);
            // 
            // lblColorType
            // 
            this.lblColorType.AutoSize = true;
            this.lblColorType.Location = new System.Drawing.Point(12, 49);
            this.lblColorType.Name = "lblColorType";
            this.lblColorType.Size = new System.Drawing.Size(68, 12);
            this.lblColorType.TabIndex = 1;
            this.lblColorType.Text = "Color Type";
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(15, 21);
            this.chkEnable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(63, 16);
            this.chkEnable.TabIndex = 0;
            this.chkEnable.Text = "Enable";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.ChkEnable_CheckedChanged);
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Location = new System.Drawing.Point(12, 10);
            this.btnOpenModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(246, 28);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "모델 불러오기";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.BtnOpenModel_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 661);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET - Plastic Focus Review";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpFocus.ResumeLayout(false);
            this.grpFocus.PerformLayout();
            this.grpPlastic.ResumeLayout(false);
            this.grpPlastic.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.GroupBox grpPlastic;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.Label lblColorType;
        private System.Windows.Forms.RadioButton rdoSelectionColor;
        private System.Windows.Forms.RadioButton rdoObjectColor;
        private System.Windows.Forms.Label lblSelectionObject3DType;
        private System.Windows.Forms.ComboBox cboSelectionObject3DType;
        private System.Windows.Forms.GroupBox grpFocus;
        private System.Windows.Forms.Label lblFocusGuide;
        private System.Windows.Forms.Button btnApplyPlastic;
        private System.Windows.Forms.CheckBox chkSetPivot;
        private System.Windows.Forms.Label lblPlasticCount;
        private System.Windows.Forms.ListBox lstPlasticNodes;
        private System.Windows.Forms.Button btnRemovePlastic;
        private System.Windows.Forms.Button btnClear;
    }
}