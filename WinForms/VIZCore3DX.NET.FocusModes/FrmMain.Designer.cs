namespace VIZCore3DX.NET.FocusModes
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
            this.grpList = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lstNodes = new System.Windows.Forms.ListBox();
            this.grpApply = new System.Windows.Forms.GroupBox();
            this.chkPivot = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.grpMode = new System.Windows.Forms.GroupBox();
            this.chkEdgeRendering = new System.Windows.Forms.CheckBox();
            this.cmbAlphaLevel = new System.Windows.Forms.ComboBox();
            this.lblAlphaLevel = new System.Windows.Forms.Label();
            this.cmbObjectType = new System.Windows.Forms.ComboBox();
            this.lblObjectType = new System.Windows.Forms.Label();
            this.pnlColorType = new System.Windows.Forms.Panel();
            this.rdoObjectColor = new System.Windows.Forms.RadioButton();
            this.rdoSelectionColor = new System.Windows.Forms.RadioButton();
            this.lblColorType = new System.Windows.Forms.Label();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.rdoTransparent = new System.Windows.Forms.RadioButton();
            this.rdoPlastic = new System.Windows.Forms.RadioButton();
            this.rdoXRay = new System.Windows.Forms.RadioButton();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpList.SuspendLayout();
            this.grpApply.SuspendLayout();
            this.grpMode.SuspendLayout();
            this.pnlColorType.SuspendLayout();
            this.grpModel.SuspendLayout();
            this.grpCleanup.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpList);
            this.splitContainer1.Panel1.Controls.Add(this.grpApply);
            this.splitContainer1.Panel1.Controls.Add(this.grpMode);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Controls.Add(this.grpCleanup);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 800);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 0;
            //
            // grpList
            //
            this.grpList.Controls.Add(this.btnRefresh);
            this.grpList.Controls.Add(this.btnRemove);
            this.grpList.Controls.Add(this.lstNodes);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Location = new System.Drawing.Point(8, 360);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(344, 350);
            this.grpList.TabIndex = 3;
            this.grpList.TabStop = false;
            this.grpList.Text = "4. 적용 목록";
            //
            // btnRefresh
            //
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(212, 312);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "새로 고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // btnRemove
            //
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Location = new System.Drawing.Point(12, 312);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(120, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "선택 해제";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // lstNodes
            //
            this.lstNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstNodes.FormattingEnabled = true;
            this.lstNodes.ItemHeight = 12;
            this.lstNodes.Location = new System.Drawing.Point(12, 24);
            this.lstNodes.Name = "lstNodes";
            this.lstNodes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstNodes.Size = new System.Drawing.Size(320, 279);
            this.lstNodes.TabIndex = 0;
            this.lstNodes.DoubleClick += new System.EventHandler(this.lstNodes_DoubleClick);
            //
            // grpApply
            //
            this.grpApply.Controls.Add(this.chkPivot);
            this.grpApply.Controls.Add(this.btnApply);
            this.grpApply.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpApply.Location = new System.Drawing.Point(8, 300);
            this.grpApply.Name = "grpApply";
            this.grpApply.Size = new System.Drawing.Size(344, 60);
            this.grpApply.TabIndex = 2;
            this.grpApply.TabStop = false;
            this.grpApply.Text = "3. 적용";
            //
            // chkPivot
            //
            this.chkPivot.AutoSize = true;
            this.chkPivot.Checked = true;
            this.chkPivot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPivot.Location = new System.Drawing.Point(172, 28);
            this.chkPivot.Name = "chkPivot";
            this.chkPivot.Size = new System.Drawing.Size(124, 16);
            this.chkPivot.TabIndex = 1;
            this.chkPivot.Text = "회전 중심으로 설정";
            this.chkPivot.UseVisualStyleBackColor = true;
            //
            // btnApply
            //
            this.btnApply.Location = new System.Drawing.Point(12, 24);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(150, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "선택 노드 적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            //
            // grpMode
            //
            this.grpMode.Controls.Add(this.chkEdgeRendering);
            this.grpMode.Controls.Add(this.cmbAlphaLevel);
            this.grpMode.Controls.Add(this.lblAlphaLevel);
            this.grpMode.Controls.Add(this.cmbObjectType);
            this.grpMode.Controls.Add(this.lblObjectType);
            this.grpMode.Controls.Add(this.pnlColorType);
            this.grpMode.Controls.Add(this.lblColorType);
            this.grpMode.Controls.Add(this.chkEnable);
            this.grpMode.Controls.Add(this.rdoTransparent);
            this.grpMode.Controls.Add(this.rdoPlastic);
            this.grpMode.Controls.Add(this.rdoXRay);
            this.grpMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMode.Location = new System.Drawing.Point(8, 104);
            this.grpMode.Name = "grpMode";
            this.grpMode.Size = new System.Drawing.Size(344, 196);
            this.grpMode.TabIndex = 1;
            this.grpMode.TabStop = false;
            this.grpMode.Text = "2. 모드";
            //
            // chkEdgeRendering
            //
            this.chkEdgeRendering.AutoSize = true;
            this.chkEdgeRendering.Location = new System.Drawing.Point(112, 162);
            this.chkEdgeRendering.Name = "chkEdgeRendering";
            this.chkEdgeRendering.Size = new System.Drawing.Size(118, 16);
            this.chkEdgeRendering.TabIndex = 10;
            this.chkEdgeRendering.Text = "엣지 표시 (X-Ray)";
            this.chkEdgeRendering.UseVisualStyleBackColor = true;
            this.chkEdgeRendering.CheckedChanged += new System.EventHandler(this.chkEdgeRendering_CheckedChanged);
            //
            // cmbAlphaLevel
            //
            this.cmbAlphaLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlphaLevel.FormattingEnabled = true;
            this.cmbAlphaLevel.Location = new System.Drawing.Point(112, 134);
            this.cmbAlphaLevel.Name = "cmbAlphaLevel";
            this.cmbAlphaLevel.Size = new System.Drawing.Size(220, 20);
            this.cmbAlphaLevel.TabIndex = 9;
            this.cmbAlphaLevel.SelectedIndexChanged += new System.EventHandler(this.cmbAlphaLevel_SelectedIndexChanged);
            //
            // lblAlphaLevel
            //
            this.lblAlphaLevel.AutoSize = true;
            this.lblAlphaLevel.Location = new System.Drawing.Point(12, 138);
            this.lblAlphaLevel.Name = "lblAlphaLevel";
            this.lblAlphaLevel.Size = new System.Drawing.Size(85, 12);
            this.lblAlphaLevel.TabIndex = 8;
            this.lblAlphaLevel.Text = "투명도 (X-Ray)";
            //
            // cmbObjectType
            //
            this.cmbObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObjectType.FormattingEnabled = true;
            this.cmbObjectType.Location = new System.Drawing.Point(112, 106);
            this.cmbObjectType.Name = "cmbObjectType";
            this.cmbObjectType.Size = new System.Drawing.Size(220, 20);
            this.cmbObjectType.TabIndex = 7;
            this.cmbObjectType.SelectedIndexChanged += new System.EventHandler(this.cmbObjectType_SelectedIndexChanged);
            //
            // lblObjectType
            //
            this.lblObjectType.AutoSize = true;
            this.lblObjectType.Location = new System.Drawing.Point(12, 110);
            this.lblObjectType.Name = "lblObjectType";
            this.lblObjectType.Size = new System.Drawing.Size(29, 12);
            this.lblObjectType.TabIndex = 6;
            this.lblObjectType.Text = "대상";
            //
            // pnlColorType
            //
            this.pnlColorType.Controls.Add(this.rdoObjectColor);
            this.pnlColorType.Controls.Add(this.rdoSelectionColor);
            this.pnlColorType.Location = new System.Drawing.Point(112, 78);
            this.pnlColorType.Name = "pnlColorType";
            this.pnlColorType.Size = new System.Drawing.Size(220, 22);
            this.pnlColorType.TabIndex = 5;
            //
            // rdoObjectColor
            //
            this.rdoObjectColor.AutoSize = true;
            this.rdoObjectColor.Location = new System.Drawing.Point(100, 2);
            this.rdoObjectColor.Name = "rdoObjectColor";
            this.rdoObjectColor.Size = new System.Drawing.Size(71, 16);
            this.rdoObjectColor.TabIndex = 1;
            this.rdoObjectColor.Text = "원본 색상";
            this.rdoObjectColor.UseVisualStyleBackColor = true;
            this.rdoObjectColor.CheckedChanged += new System.EventHandler(this.rdoColorType_CheckedChanged);
            //
            // rdoSelectionColor
            //
            this.rdoSelectionColor.AutoSize = true;
            this.rdoSelectionColor.Checked = true;
            this.rdoSelectionColor.Location = new System.Drawing.Point(0, 2);
            this.rdoSelectionColor.Name = "rdoSelectionColor";
            this.rdoSelectionColor.Size = new System.Drawing.Size(71, 16);
            this.rdoSelectionColor.TabIndex = 0;
            this.rdoSelectionColor.TabStop = true;
            this.rdoSelectionColor.Text = "선택 색상";
            this.rdoSelectionColor.UseVisualStyleBackColor = true;
            this.rdoSelectionColor.CheckedChanged += new System.EventHandler(this.rdoColorType_CheckedChanged);
            //
            // lblColorType
            //
            this.lblColorType.AutoSize = true;
            this.lblColorType.Location = new System.Drawing.Point(12, 82);
            this.lblColorType.Name = "lblColorType";
            this.lblColorType.Size = new System.Drawing.Size(41, 12);
            this.lblColorType.TabIndex = 4;
            this.lblColorType.Text = "강조 색";
            //
            // chkEnable
            //
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(12, 52);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(72, 16);
            this.chkEnable.TabIndex = 3;
            this.chkEnable.Text = "모드 켜기";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            //
            // rdoTransparent
            //
            this.rdoTransparent.AutoSize = true;
            this.rdoTransparent.Location = new System.Drawing.Point(212, 24);
            this.rdoTransparent.Name = "rdoTransparent";
            this.rdoTransparent.Size = new System.Drawing.Size(59, 16);
            this.rdoTransparent.TabIndex = 2;
            this.rdoTransparent.Text = "반투명";
            this.rdoTransparent.UseVisualStyleBackColor = true;
            this.rdoTransparent.CheckedChanged += new System.EventHandler(this.rdoMode_CheckedChanged);
            //
            // rdoPlastic
            //
            this.rdoPlastic.AutoSize = true;
            this.rdoPlastic.Location = new System.Drawing.Point(112, 24);
            this.rdoPlastic.Name = "rdoPlastic";
            this.rdoPlastic.Size = new System.Drawing.Size(71, 16);
            this.rdoPlastic.TabIndex = 1;
            this.rdoPlastic.Text = "플라스틱";
            this.rdoPlastic.UseVisualStyleBackColor = true;
            this.rdoPlastic.CheckedChanged += new System.EventHandler(this.rdoMode_CheckedChanged);
            //
            // rdoXRay
            //
            this.rdoXRay.AutoSize = true;
            this.rdoXRay.Checked = true;
            this.rdoXRay.Location = new System.Drawing.Point(12, 24);
            this.rdoXRay.Name = "rdoXRay";
            this.rdoXRay.Size = new System.Drawing.Size(55, 16);
            this.rdoXRay.TabIndex = 0;
            this.rdoXRay.TabStop = true;
            this.rdoXRay.Text = "X-Ray";
            this.rdoXRay.UseVisualStyleBackColor = true;
            this.rdoXRay.CheckedChanged += new System.EventHandler(this.rdoMode_CheckedChanged);
            //
            // grpModel
            //
            this.grpModel.Controls.Add(this.lblModelHint);
            this.grpModel.Controls.Add(this.btnOpenModel);
            this.grpModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpModel.Location = new System.Drawing.Point(8, 8);
            this.grpModel.Name = "grpModel";
            this.grpModel.Size = new System.Drawing.Size(344, 96);
            this.grpModel.TabIndex = 0;
            this.grpModel.TabStop = false;
            this.grpModel.Text = "1. 모델";
            //
            // lblModelHint
            //
            this.lblModelHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModelHint.Location = new System.Drawing.Point(12, 54);
            this.lblModelHint.Name = "lblModelHint";
            this.lblModelHint.Size = new System.Drawing.Size(320, 32);
            this.lblModelHint.TabIndex = 1;
            this.lblModelHint.Text = "뷰에서 노드를 선택한 뒤 [선택 노드 적용]을 누르세요.\r\n강조 모드는 한 번에 하나만 켜집니다.";
            //
            // btnOpenModel
            //
            this.btnOpenModel.Location = new System.Drawing.Point(12, 24);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(120, 23);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "모델 열기";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            //
            // grpCleanup
            //
            this.grpCleanup.Controls.Add(this.btnClearAll);
            this.grpCleanup.Controls.Add(this.btnClear);
            this.grpCleanup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCleanup.Location = new System.Drawing.Point(8, 710);
            this.grpCleanup.Name = "grpCleanup";
            this.grpCleanup.Size = new System.Drawing.Size(344, 60);
            this.grpCleanup.TabIndex = 4;
            this.grpCleanup.TabStop = false;
            this.grpCleanup.Text = "5. 정리";
            //
            // btnClearAll
            //
            this.btnClearAll.Location = new System.Drawing.Point(172, 24);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(150, 23);
            this.btnClearAll.TabIndex = 1;
            this.btnClearAll.Text = "모든 모드 끄기";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(12, 24);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "현재 모드 지우기";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // lblStatus
            //
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(8, 770);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(344, 22);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // FrmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.FocusModes";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            this.grpApply.ResumeLayout(false);
            this.grpApply.PerformLayout();
            this.grpMode.ResumeLayout(false);
            this.grpMode.PerformLayout();
            this.pnlColorType.ResumeLayout(false);
            this.pnlColorType.PerformLayout();
            this.grpModel.ResumeLayout(false);
            this.grpModel.PerformLayout();
            this.grpCleanup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Label lblModelHint;
        private System.Windows.Forms.GroupBox grpMode;
        private System.Windows.Forms.RadioButton rdoXRay;
        private System.Windows.Forms.RadioButton rdoPlastic;
        private System.Windows.Forms.RadioButton rdoTransparent;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.Label lblColorType;
        private System.Windows.Forms.Panel pnlColorType;
        private System.Windows.Forms.RadioButton rdoSelectionColor;
        private System.Windows.Forms.RadioButton rdoObjectColor;
        private System.Windows.Forms.Label lblObjectType;
        private System.Windows.Forms.ComboBox cmbObjectType;
        private System.Windows.Forms.Label lblAlphaLevel;
        private System.Windows.Forms.ComboBox cmbAlphaLevel;
        private System.Windows.Forms.CheckBox chkEdgeRendering;
        private System.Windows.Forms.GroupBox grpApply;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.CheckBox chkPivot;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.ListBox lstNodes;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label lblStatus;
    }
}
