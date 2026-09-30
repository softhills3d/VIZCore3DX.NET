namespace VIZCore3DX.NET.XRayInspection
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
            this.grpInspection = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemoveXRay = new System.Windows.Forms.Button();
            this.lstXRayNodes = new System.Windows.Forms.ListBox();
            this.lblXRayCount = new System.Windows.Forms.Label();
            this.chkSetPivot = new System.Windows.Forms.CheckBox();
            this.btnApplyXRay = new System.Windows.Forms.Button();
            this.lblInspectionGuide = new System.Windows.Forms.Label();
            this.grpXRay = new System.Windows.Forms.GroupBox();
            this.chkEdgeRendering = new System.Windows.Forms.CheckBox();
            this.cboSelectionObject3DType = new System.Windows.Forms.ComboBox();
            this.lblSelectionObject3DType = new System.Windows.Forms.Label();
            this.rdoObjectColor = new System.Windows.Forms.RadioButton();
            this.rdoSelectionColor = new System.Windows.Forms.RadioButton();
            this.lblColorType = new System.Windows.Forms.Label();
            this.cboAlphaLevel = new System.Windows.Forms.ComboBox();
            this.lblAlphaLevel = new System.Windows.Forms.Label();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.btnOpenModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpInspection.SuspendLayout();
            this.grpXRay.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpInspection);
            this.splitContainer1.Panel1.Controls.Add(this.grpXRay);
            this.splitContainer1.Panel1.Controls.Add(this.btnOpenModel);

            // 
            // splitContainer1
            // 
            this.splitContainer1.Size = new System.Drawing.Size(1100, 661);
            this.splitContainer1.SplitterDistance = 270;
            this.splitContainer1.TabIndex = 0;

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
            // grpXRay
            // 
            this.grpXRay.Controls.Add(this.chkEdgeRendering);
            this.grpXRay.Controls.Add(this.cboSelectionObject3DType);
            this.grpXRay.Controls.Add(this.lblSelectionObject3DType);
            this.grpXRay.Controls.Add(this.rdoObjectColor);
            this.grpXRay.Controls.Add(this.rdoSelectionColor);
            this.grpXRay.Controls.Add(this.lblColorType);
            this.grpXRay.Controls.Add(this.cboAlphaLevel);
            this.grpXRay.Controls.Add(this.lblAlphaLevel);
            this.grpXRay.Controls.Add(this.chkEnable);
            this.grpXRay.Location = new System.Drawing.Point(12, 48);
            this.grpXRay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpXRay.Name = "grpXRay";
            this.grpXRay.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpXRay.Size = new System.Drawing.Size(246, 226);
            this.grpXRay.TabIndex = 1;
            this.grpXRay.TabStop = false;
            this.grpXRay.Text = "X-Ray";

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
            // lblAlphaLevel
            // 
            this.lblAlphaLevel.AutoSize = true;
            this.lblAlphaLevel.Location = new System.Drawing.Point(12, 51);
            this.lblAlphaLevel.Name = "lblAlphaLevel";
            this.lblAlphaLevel.Size = new System.Drawing.Size(68, 12);
            this.lblAlphaLevel.TabIndex = 1;
            this.lblAlphaLevel.Text = "Alpha Level";

            // 
            // cboAlphaLevel
            // 
            this.cboAlphaLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlphaLevel.FormattingEnabled = true;
            this.cboAlphaLevel.Location = new System.Drawing.Point(92, 47);
            this.cboAlphaLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboAlphaLevel.Name = "cboAlphaLevel";
            this.cboAlphaLevel.Size = new System.Drawing.Size(139, 20);
            this.cboAlphaLevel.TabIndex = 2;
            this.cboAlphaLevel.SelectedIndexChanged += new System.EventHandler(this.CboAlphaLevel_SelectedIndexChanged);

            // 
            // lblColorType
            // 
            this.lblColorType.AutoSize = true;
            this.lblColorType.Location = new System.Drawing.Point(12, 82);
            this.lblColorType.Name = "lblColorType";
            this.lblColorType.Size = new System.Drawing.Size(64, 12);
            this.lblColorType.TabIndex = 3;
            this.lblColorType.Text = "Color Type";

            // 
            // rdoSelectionColor
            // 
            this.rdoSelectionColor.AutoSize = true;
            this.rdoSelectionColor.Location = new System.Drawing.Point(15, 102);
            this.rdoSelectionColor.Name = "rdoSelectionColor";
            this.rdoSelectionColor.Size = new System.Drawing.Size(99, 16);
            this.rdoSelectionColor.TabIndex = 4;
            this.rdoSelectionColor.TabStop = true;
            this.rdoSelectionColor.Text = "선택 색상 (빨강)";
            this.rdoSelectionColor.UseVisualStyleBackColor = true;
            this.rdoSelectionColor.CheckedChanged += new System.EventHandler(this.RdoSelectionColor_CheckedChanged);

            // 
            // rdoObjectColor
            // 
            this.rdoObjectColor.AutoSize = true;
            this.rdoObjectColor.Location = new System.Drawing.Point(126, 102);
            this.rdoObjectColor.Name = "rdoObjectColor";
            this.rdoObjectColor.Size = new System.Drawing.Size(75, 16);
            this.rdoObjectColor.TabIndex = 5;
            this.rdoObjectColor.TabStop = true;
            this.rdoObjectColor.Text = "원래 색상";
            this.rdoObjectColor.UseVisualStyleBackColor = true;
            this.rdoObjectColor.CheckedChanged += new System.EventHandler(this.RdoObjectColor_CheckedChanged);

            // 
            // lblSelectionObject3DType
            // 
            this.lblSelectionObject3DType.AutoSize = true;
            this.lblSelectionObject3DType.Location = new System.Drawing.Point(12, 135);
            this.lblSelectionObject3DType.Name = "lblSelectionObject3DType";
            this.lblSelectionObject3DType.Size = new System.Drawing.Size(95, 12);
            this.lblSelectionObject3DType.TabIndex = 6;
            this.lblSelectionObject3DType.Text = "Selection Object";

            // 
            // cboSelectionObject3DType
            // 
            this.cboSelectionObject3DType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectionObject3DType.FormattingEnabled = true;
            this.cboSelectionObject3DType.Location = new System.Drawing.Point(15, 155);
            this.cboSelectionObject3DType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboSelectionObject3DType.Name = "cboSelectionObject3DType";
            this.cboSelectionObject3DType.Size = new System.Drawing.Size(216, 20);
            this.cboSelectionObject3DType.TabIndex = 7;
            this.cboSelectionObject3DType.SelectedIndexChanged += new System.EventHandler(this.CboSelectionObject3DType_SelectedIndexChanged);

            // 
            // chkEdgeRendering
            // 
            this.chkEdgeRendering.AutoSize = true;
            this.chkEdgeRendering.Location = new System.Drawing.Point(15, 192);
            this.chkEdgeRendering.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkEdgeRendering.Name = "chkEdgeRendering";
            this.chkEdgeRendering.Size = new System.Drawing.Size(111, 16);
            this.chkEdgeRendering.TabIndex = 8;
            this.chkEdgeRendering.Text = "Edge Rendering";
            this.chkEdgeRendering.UseVisualStyleBackColor = true;
            this.chkEdgeRendering.CheckedChanged += new System.EventHandler(this.ChkEdgeRendering_CheckedChanged);

            // 
            // grpInspection
            // 
            this.grpInspection.Controls.Add(this.btnRefresh);
            this.grpInspection.Controls.Add(this.btnClear);
            this.grpInspection.Controls.Add(this.btnRemoveXRay);
            this.grpInspection.Controls.Add(this.lstXRayNodes);
            this.grpInspection.Controls.Add(this.lblXRayCount);
            this.grpInspection.Controls.Add(this.chkSetPivot);
            this.grpInspection.Controls.Add(this.btnApplyXRay);
            this.grpInspection.Controls.Add(this.lblInspectionGuide);
            this.grpInspection.Location = new System.Drawing.Point(12, 284);
            this.grpInspection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpInspection.Name = "grpInspection";
            this.grpInspection.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpInspection.Size = new System.Drawing.Size(246, 351);
            this.grpInspection.TabIndex = 2;
            this.grpInspection.TabStop = false;
            this.grpInspection.Text = "Inspection";

            // 
            // lblInspectionGuide
            // 
            this.lblInspectionGuide.AutoSize = true;
            this.lblInspectionGuide.Location = new System.Drawing.Point(12, 22);
            this.lblInspectionGuide.Name = "lblInspectionGuide";
            this.lblInspectionGuide.Size = new System.Drawing.Size(198, 12);
            this.lblInspectionGuide.TabIndex = 0;
            this.lblInspectionGuide.Text = "모델에서 검토할 노드를 선택한 후 적용";

            // 
            // btnApplyXRay
            // 
            this.btnApplyXRay.Location = new System.Drawing.Point(15, 43);
            this.btnApplyXRay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApplyXRay.Name = "btnApplyXRay";
            this.btnApplyXRay.Size = new System.Drawing.Size(216, 30);
            this.btnApplyXRay.TabIndex = 1;
            this.btnApplyXRay.Text = "현재 선택 노드 X-Ray 적용";
            this.btnApplyXRay.UseVisualStyleBackColor = true;
            this.btnApplyXRay.Click += new System.EventHandler(this.BtnApplyXRay_Click);

            // 
            // chkSetPivot
            // 
            this.chkSetPivot.AutoSize = true;
            this.chkSetPivot.Location = new System.Drawing.Point(15, 82);
            this.chkSetPivot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkSetPivot.Name = "chkSetPivot";
            this.chkSetPivot.Size = new System.Drawing.Size(161, 16);
            this.chkSetPivot.TabIndex = 2;
            this.chkSetPivot.Text = "선택 노드를 회전 중심으로";
            this.chkSetPivot.UseVisualStyleBackColor = true;

            // 
            // lblXRayCount
            // 
            this.lblXRayCount.AutoSize = true;
            this.lblXRayCount.Location = new System.Drawing.Point(12, 111);
            this.lblXRayCount.Name = "lblXRayCount";
            this.lblXRayCount.Size = new System.Drawing.Size(88, 12);
            this.lblXRayCount.TabIndex = 3;
            this.lblXRayCount.Text = "X-Ray 노드 : 0";

            // 
            // lstXRayNodes
            // 
            this.lstXRayNodes.FormattingEnabled = true;
            this.lstXRayNodes.HorizontalScrollbar = true;
            this.lstXRayNodes.ItemHeight = 12;
            this.lstXRayNodes.Location = new System.Drawing.Point(15, 131);
            this.lstXRayNodes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstXRayNodes.Name = "lstXRayNodes";
            this.lstXRayNodes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstXRayNodes.Size = new System.Drawing.Size(216, 148);
            this.lstXRayNodes.TabIndex = 4;

            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(15, 286);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(216, 25);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "X-Ray 선택 상태 새로고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);

            // 
            // btnRemoveXRay
            // 
            this.btnRemoveXRay.Location = new System.Drawing.Point(15, 317);
            this.btnRemoveXRay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveXRay.Name = "btnRemoveXRay";
            this.btnRemoveXRay.Size = new System.Drawing.Size(105, 25);
            this.btnRemoveXRay.TabIndex = 6;
            this.btnRemoveXRay.Text = "선택 X-Ray 해제";
            this.btnRemoveXRay.UseVisualStyleBackColor = true;
            this.btnRemoveXRay.Click += new System.EventHandler(this.BtnRemoveXRay_Click);

            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(126, 317);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(105, 25);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear (전체)";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

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
            this.Text = "VIZCore3DX.NET - XRay Inspection";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpInspection.ResumeLayout(false);
            this.grpInspection.PerformLayout();
            this.grpXRay.ResumeLayout(false);
            this.grpXRay.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.GroupBox grpXRay;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.Label lblAlphaLevel;
        private System.Windows.Forms.ComboBox cboAlphaLevel;
        private System.Windows.Forms.Label lblColorType;
        private System.Windows.Forms.RadioButton rdoSelectionColor;
        private System.Windows.Forms.RadioButton rdoObjectColor;
        private System.Windows.Forms.Label lblSelectionObject3DType;
        private System.Windows.Forms.ComboBox cboSelectionObject3DType;
        private System.Windows.Forms.CheckBox chkEdgeRendering;
        private System.Windows.Forms.GroupBox grpInspection;
        private System.Windows.Forms.Label lblInspectionGuide;
        private System.Windows.Forms.Button btnApplyXRay;
        private System.Windows.Forms.CheckBox chkSetPivot;
        private System.Windows.Forms.Label lblXRayCount;
        private System.Windows.Forms.ListBox lstXRayNodes;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRemoveXRay;
        private System.Windows.Forms.Button btnClear;
    }
}