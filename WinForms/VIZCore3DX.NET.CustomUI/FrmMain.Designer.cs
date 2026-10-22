namespace VIZCore3DX.NET.CustomUI
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
            this.grpPanel = new System.Windows.Forms.GroupBox();
            this.btnShowTab = new System.Windows.Forms.Button();
            this.btnHideTab = new System.Windows.Forms.Button();
            this.lstTabs = new System.Windows.Forms.ListBox();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.btnRemoveTab = new System.Windows.Forms.Button();
            this.btnMoveLast = new System.Windows.Forms.Button();
            this.btnMoveFirst = new System.Windows.Forms.Button();
            this.btnRenameTab = new System.Windows.Forms.Button();
            this.btnAddTab = new System.Windows.Forms.Button();
            this.txtTabText = new System.Windows.Forms.TextBox();
            this.lblTabText = new System.Windows.Forms.Label();
            this.cmbPanel = new System.Windows.Forms.ComboBox();
            this.lblPanel = new System.Windows.Forms.Label();
            this.grpToolbar = new System.Windows.Forms.GroupBox();
            this.lblToolbarInfo = new System.Windows.Forms.Label();
            this.btnRemoveButtons = new System.Windows.Forms.Button();
            this.btnReadToggle = new System.Windows.Forms.Button();
            this.chkToggleChecked = new System.Windows.Forms.CheckBox();
            this.btnAddToggleButton = new System.Windows.Forms.Button();
            this.btnAddIconButton = new System.Windows.Forms.Button();
            this.btnAddTextButton = new System.Windows.Forms.Button();
            this.cmbToolbar = new System.Windows.Forms.ComboBox();
            this.lblToolbar = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelInfo = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnCleanup = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpPanel.SuspendLayout();
            this.grpToolbar.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpPanel);
            this.splitContainer1.Panel1.Controls.Add(this.grpToolbar);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Controls.Add(this.grpCleanup);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 800);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 0;
            //
            // grpPanel
            //
            this.grpPanel.Controls.Add(this.btnShowTab);
            this.grpPanel.Controls.Add(this.btnHideTab);
            this.grpPanel.Controls.Add(this.lstTabs);
            this.grpPanel.Controls.Add(this.btnRemoveTab);
            this.grpPanel.Controls.Add(this.btnMoveLast);
            this.grpPanel.Controls.Add(this.btnMoveFirst);
            this.grpPanel.Controls.Add(this.btnRenameTab);
            this.grpPanel.Controls.Add(this.btnAddTab);
            this.grpPanel.Controls.Add(this.txtTabText);
            this.grpPanel.Controls.Add(this.lblTabText);
            this.grpPanel.Controls.Add(this.cmbPosition);
            this.grpPanel.Controls.Add(this.lblPosition);
            this.grpPanel.Controls.Add(this.cmbPanel);
            this.grpPanel.Controls.Add(this.lblPanel);
            this.grpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPanel.Location = new System.Drawing.Point(8, 340);
            this.grpPanel.Name = "grpPanel";
            this.grpPanel.Size = new System.Drawing.Size(344, 370);
            this.grpPanel.TabIndex = 2;
            this.grpPanel.TabStop = false;
            this.grpPanel.Text = "3. 패널 사용자 탭";
            //
            // btnShowTab
            //
            this.btnShowTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowTab.Location = new System.Drawing.Point(176, 335);
            this.btnShowTab.Name = "btnShowTab";
            this.btnShowTab.Size = new System.Drawing.Size(156, 23);
            this.btnShowTab.TabIndex = 11;
            this.btnShowTab.Text = "선택 탭 표시";
            this.btnShowTab.UseVisualStyleBackColor = true;
            this.btnShowTab.Click += new System.EventHandler(this.btnShowTab_Click);
            //
            // btnHideTab
            //
            this.btnHideTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHideTab.Location = new System.Drawing.Point(12, 335);
            this.btnHideTab.Name = "btnHideTab";
            this.btnHideTab.Size = new System.Drawing.Size(156, 23);
            this.btnHideTab.TabIndex = 10;
            this.btnHideTab.Text = "선택 탭 숨김";
            this.btnHideTab.UseVisualStyleBackColor = true;
            this.btnHideTab.Click += new System.EventHandler(this.btnHideTab_Click);
            //
            // lstTabs
            //
            this.lstTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTabs.IntegralHeight = false;
            this.lstTabs.ItemHeight = 12;
            this.lstTabs.Location = new System.Drawing.Point(12, 112);
            this.lstTabs.Name = "lstTabs";
            this.lstTabs.Size = new System.Drawing.Size(320, 217);
            this.lstTabs.TabIndex = 9;
            this.lstTabs.DoubleClick += new System.EventHandler(this.lstTabs_DoubleClick);
            //
            // btnRemoveTab
            //
            this.btnRemoveTab.Location = new System.Drawing.Point(272, 52);
            this.btnRemoveTab.Name = "btnRemoveTab";
            this.btnRemoveTab.Size = new System.Drawing.Size(60, 23);
            this.btnRemoveTab.TabIndex = 8;
            this.btnRemoveTab.Text = "탭 제거";
            this.btnRemoveTab.UseVisualStyleBackColor = true;
            this.btnRemoveTab.Click += new System.EventHandler(this.btnRemoveTab_Click);
            //
            // btnMoveLast
            //
            this.btnMoveLast.Location = new System.Drawing.Point(207, 52);
            this.btnMoveLast.Name = "btnMoveLast";
            this.btnMoveLast.Size = new System.Drawing.Size(60, 23);
            this.btnMoveLast.TabIndex = 7;
            this.btnMoveLast.Text = "맨 뒤";
            this.btnMoveLast.UseVisualStyleBackColor = true;
            this.btnMoveLast.Click += new System.EventHandler(this.btnMoveLast_Click);
            //
            // btnMoveFirst
            //
            this.btnMoveFirst.Location = new System.Drawing.Point(142, 52);
            this.btnMoveFirst.Name = "btnMoveFirst";
            this.btnMoveFirst.Size = new System.Drawing.Size(60, 23);
            this.btnMoveFirst.TabIndex = 6;
            this.btnMoveFirst.Text = "맨 앞";
            this.btnMoveFirst.UseVisualStyleBackColor = true;
            this.btnMoveFirst.Click += new System.EventHandler(this.btnMoveFirst_Click);
            //
            // btnRenameTab
            //
            this.btnRenameTab.Location = new System.Drawing.Point(77, 52);
            this.btnRenameTab.Name = "btnRenameTab";
            this.btnRenameTab.Size = new System.Drawing.Size(60, 23);
            this.btnRenameTab.TabIndex = 5;
            this.btnRenameTab.Text = "이름 변경";
            this.btnRenameTab.UseVisualStyleBackColor = true;
            this.btnRenameTab.Click += new System.EventHandler(this.btnRenameTab_Click);
            //
            // btnAddTab
            //
            this.btnAddTab.Location = new System.Drawing.Point(12, 52);
            this.btnAddTab.Name = "btnAddTab";
            this.btnAddTab.Size = new System.Drawing.Size(60, 23);
            this.btnAddTab.TabIndex = 4;
            this.btnAddTab.Text = "탭 부착";
            this.btnAddTab.UseVisualStyleBackColor = true;
            this.btnAddTab.Click += new System.EventHandler(this.btnAddTab_Click);
            //
            // txtTabText
            //
            this.txtTabText.Location = new System.Drawing.Point(236, 24);
            this.txtTabText.Name = "txtTabText";
            this.txtTabText.Size = new System.Drawing.Size(96, 21);
            this.txtTabText.TabIndex = 3;
            this.txtTabText.Text = "검사 결과";
            //
            // lblTabText
            //
            this.lblTabText.AutoSize = true;
            this.lblTabText.Location = new System.Drawing.Point(188, 28);
            this.lblTabText.Name = "lblTabText";
            this.lblTabText.Size = new System.Drawing.Size(41, 12);
            this.lblTabText.TabIndex = 2;
            this.lblTabText.Text = "탭 이름";
            //
            // cmbPanel
            //
            this.cmbPanel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPanel.Location = new System.Drawing.Point(60, 24);
            this.cmbPanel.Name = "cmbPanel";
            this.cmbPanel.Size = new System.Drawing.Size(120, 20);
            this.cmbPanel.TabIndex = 1;
            this.cmbPanel.SelectedIndexChanged += new System.EventHandler(this.cmbPanel_SelectedIndexChanged);
            //
            // cmbPosition
            //
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.Location = new System.Drawing.Point(60, 84);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(120, 20);
            this.cmbPosition.TabIndex = 13;
            this.cmbPosition.SelectedIndexChanged += new System.EventHandler(this.cmbPosition_SelectedIndexChanged);
            //
            // lblPosition
            //
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(12, 88);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(29, 12);
            this.lblPosition.TabIndex = 12;
            this.lblPosition.Text = "위치";
            //
            // lblPanel
            //
            this.lblPanel.AutoSize = true;
            this.lblPanel.Location = new System.Drawing.Point(12, 28);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Size = new System.Drawing.Size(29, 12);
            this.lblPanel.TabIndex = 0;
            this.lblPanel.Text = "패널";
            //
            // grpToolbar
            //
            this.grpToolbar.Controls.Add(this.lblToolbarInfo);
            this.grpToolbar.Controls.Add(this.btnRemoveButtons);
            this.grpToolbar.Controls.Add(this.btnReadToggle);
            this.grpToolbar.Controls.Add(this.chkToggleChecked);
            this.grpToolbar.Controls.Add(this.btnAddToggleButton);
            this.grpToolbar.Controls.Add(this.btnAddIconButton);
            this.grpToolbar.Controls.Add(this.btnAddTextButton);
            this.grpToolbar.Controls.Add(this.cmbToolbar);
            this.grpToolbar.Controls.Add(this.lblToolbar);
            this.grpToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpToolbar.Location = new System.Drawing.Point(8, 104);
            this.grpToolbar.Name = "grpToolbar";
            this.grpToolbar.Size = new System.Drawing.Size(344, 236);
            this.grpToolbar.TabIndex = 1;
            this.grpToolbar.TabStop = false;
            this.grpToolbar.Text = "2. 툴바 사용자 버튼";
            //
            // lblToolbarInfo
            //
            this.lblToolbarInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToolbarInfo.Location = new System.Drawing.Point(12, 194);
            this.lblToolbarInfo.Name = "lblToolbarInfo";
            this.lblToolbarInfo.Size = new System.Drawing.Size(320, 32);
            this.lblToolbarInfo.TabIndex = 8;
            this.lblToolbarInfo.Text = "리본 모드에서는 선택한 탭 끝의 \'사용자 정의\' 그룹에 같은 버튼이 자동으로 나타납니다.";
            //
            // btnRemoveButtons
            //
            this.btnRemoveButtons.Location = new System.Drawing.Point(196, 164);
            this.btnRemoveButtons.Name = "btnRemoveButtons";
            this.btnRemoveButtons.Size = new System.Drawing.Size(136, 23);
            this.btnRemoveButtons.TabIndex = 7;
            this.btnRemoveButtons.Text = "사용자 버튼 모두 제거";
            this.btnRemoveButtons.UseVisualStyleBackColor = true;
            this.btnRemoveButtons.Click += new System.EventHandler(this.btnRemoveButtons_Click);
            //
            // btnReadToggle
            //
            this.btnReadToggle.Location = new System.Drawing.Point(12, 164);
            this.btnReadToggle.Name = "btnReadToggle";
            this.btnReadToggle.Size = new System.Drawing.Size(180, 23);
            this.btnReadToggle.TabIndex = 6;
            this.btnReadToggle.Text = "토글 상태 읽기 (GetChecked)";
            this.btnReadToggle.UseVisualStyleBackColor = true;
            this.btnReadToggle.Click += new System.EventHandler(this.btnReadToggle_Click);
            //
            // chkToggleChecked
            //
            this.chkToggleChecked.AutoSize = true;
            this.chkToggleChecked.Location = new System.Drawing.Point(12, 140);
            this.chkToggleChecked.Name = "chkToggleChecked";
            this.chkToggleChecked.Size = new System.Drawing.Size(180, 16);
            this.chkToggleChecked.TabIndex = 5;
            this.chkToggleChecked.Text = "토글 상태 지정 (SetChecked)";
            this.chkToggleChecked.UseVisualStyleBackColor = true;
            this.chkToggleChecked.CheckedChanged += new System.EventHandler(this.chkToggleChecked_CheckedChanged);
            //
            // btnAddToggleButton
            //
            this.btnAddToggleButton.Location = new System.Drawing.Point(12, 108);
            this.btnAddToggleButton.Name = "btnAddToggleButton";
            this.btnAddToggleButton.Size = new System.Drawing.Size(320, 23);
            this.btnAddToggleButton.TabIndex = 4;
            this.btnAddToggleButton.Text = "토글 버튼 추가 (검사 탭 부착·표시)";
            this.btnAddToggleButton.UseVisualStyleBackColor = true;
            this.btnAddToggleButton.Click += new System.EventHandler(this.btnAddToggleButton_Click);
            //
            // btnAddIconButton
            //
            this.btnAddIconButton.Location = new System.Drawing.Point(12, 80);
            this.btnAddIconButton.Name = "btnAddIconButton";
            this.btnAddIconButton.Size = new System.Drawing.Size(320, 23);
            this.btnAddIconButton.TabIndex = 3;
            this.btnAddIconButton.Text = "아이콘 버튼 추가 (화면 맞춤)";
            this.btnAddIconButton.UseVisualStyleBackColor = true;
            this.btnAddIconButton.Click += new System.EventHandler(this.btnAddIconButton_Click);
            //
            // btnAddTextButton
            //
            this.btnAddTextButton.Location = new System.Drawing.Point(12, 52);
            this.btnAddTextButton.Name = "btnAddTextButton";
            this.btnAddTextButton.Size = new System.Drawing.Size(320, 23);
            this.btnAddTextButton.TabIndex = 2;
            this.btnAddTextButton.Text = "텍스트 버튼 추가";
            this.btnAddTextButton.UseVisualStyleBackColor = true;
            this.btnAddTextButton.Click += new System.EventHandler(this.btnAddTextButton_Click);
            //
            // cmbToolbar
            //
            this.cmbToolbar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToolbar.Location = new System.Drawing.Point(60, 24);
            this.cmbToolbar.Name = "cmbToolbar";
            this.cmbToolbar.Size = new System.Drawing.Size(140, 20);
            this.cmbToolbar.TabIndex = 1;
            //
            // lblToolbar
            //
            this.lblToolbar.AutoSize = true;
            this.lblToolbar.Location = new System.Drawing.Point(12, 28);
            this.lblToolbar.Name = "lblToolbar";
            this.lblToolbar.Size = new System.Drawing.Size(29, 12);
            this.lblToolbar.TabIndex = 0;
            this.lblToolbar.Text = "툴바";
            //
            // grpModel
            //
            this.grpModel.Controls.Add(this.lblModelInfo);
            this.grpModel.Controls.Add(this.btnOpenModel);
            this.grpModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpModel.Location = new System.Drawing.Point(8, 8);
            this.grpModel.Name = "grpModel";
            this.grpModel.Size = new System.Drawing.Size(344, 96);
            this.grpModel.TabIndex = 0;
            this.grpModel.TabStop = false;
            this.grpModel.Text = "1. 모델";
            //
            // lblModelInfo
            //
            this.lblModelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModelInfo.Location = new System.Drawing.Point(12, 54);
            this.lblModelInfo.Name = "lblModelInfo";
            this.lblModelInfo.Size = new System.Drawing.Size(320, 32);
            this.lblModelInfo.TabIndex = 1;
            this.lblModelInfo.Text = "툴바 버튼·패널 탭은 모델 없이도 동작합니다.\r\n검사 탭의 '선택 노드 읽기' 는 모델을 열고 개체를 고른 뒤 누르세요.";
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
            this.grpCleanup.Controls.Add(this.btnCleanup);
            this.grpCleanup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCleanup.Location = new System.Drawing.Point(8, 710);
            this.grpCleanup.Name = "grpCleanup";
            this.grpCleanup.Size = new System.Drawing.Size(344, 60);
            this.grpCleanup.TabIndex = 4;
            this.grpCleanup.TabStop = false;
            this.grpCleanup.Text = "4. 정리";
            //
            // btnCleanup
            //
            this.btnCleanup.Location = new System.Drawing.Point(12, 24);
            this.btnCleanup.Name = "btnCleanup";
            this.btnCleanup.Size = new System.Drawing.Size(150, 23);
            this.btnCleanup.TabIndex = 0;
            this.btnCleanup.Text = "모두 되돌리기";
            this.btnCleanup.UseVisualStyleBackColor = true;
            this.btnCleanup.Click += new System.EventHandler(this.btnCleanup_Click);
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
            this.Text = "VIZCore3DX.NET.CustomUI";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpPanel.ResumeLayout(false);
            this.grpPanel.PerformLayout();
            this.grpToolbar.ResumeLayout(false);
            this.grpToolbar.PerformLayout();
            this.grpModel.ResumeLayout(false);
            this.grpModel.PerformLayout();
            this.grpCleanup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Label lblModelInfo;
        private System.Windows.Forms.GroupBox grpToolbar;
        private System.Windows.Forms.Label lblToolbar;
        private System.Windows.Forms.ComboBox cmbToolbar;
        private System.Windows.Forms.Button btnAddTextButton;
        private System.Windows.Forms.Button btnAddIconButton;
        private System.Windows.Forms.Button btnAddToggleButton;
        private System.Windows.Forms.CheckBox chkToggleChecked;
        private System.Windows.Forms.Button btnReadToggle;
        private System.Windows.Forms.Button btnRemoveButtons;
        private System.Windows.Forms.Label lblToolbarInfo;
        private System.Windows.Forms.GroupBox grpPanel;
        private System.Windows.Forms.Label lblPanel;
        private System.Windows.Forms.ComboBox cmbPanel;
        private System.Windows.Forms.Label lblTabText;
        private System.Windows.Forms.TextBox txtTabText;
        private System.Windows.Forms.Button btnAddTab;
        private System.Windows.Forms.Button btnRenameTab;
        private System.Windows.Forms.Button btnMoveFirst;
        private System.Windows.Forms.Button btnMoveLast;
        private System.Windows.Forms.Button btnRemoveTab;
        private System.Windows.Forms.ListBox lstTabs;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Button btnHideTab;
        private System.Windows.Forms.Button btnShowTab;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.Button btnCleanup;
        private System.Windows.Forms.Label lblStatus;
    }
}
