namespace VIZCore3DX.NET.RibbonCustomization
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.GroupBox grpRibbonSetting;
        private System.Windows.Forms.CheckBox chkRibbonMode;
        private System.Windows.Forms.Label lblRibbonTheme;
        private System.Windows.Forms.ComboBox cmbRibbonTheme;
        private System.Windows.Forms.Button btnShowDefaultTabs;
        private System.Windows.Forms.Button btnHideDefaultTabs;
        private System.Windows.Forms.Button btnResetRibbon;
        private System.Windows.Forms.GroupBox grpStructure;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label lblCustom;
        private System.Windows.Forms.TreeView treeAvailable;
        private System.Windows.Forms.TreeView treeCustom;
        private System.Windows.Forms.Button btnMoveToCustom;
        private System.Windows.Forms.Button btnRestoreItem;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TableLayoutPanel tlpStructure;
        private System.Windows.Forms.Button btnMoveTabLeft;
        private System.Windows.Forms.Button btnMoveTabRight;
        private System.Windows.Forms.Button btnAddQuickAccess;
        private System.Windows.Forms.Button btnRemoveQuickAccess;
        private System.Windows.Forms.Button btnQuickAccessDialog;
        private System.Windows.Forms.Button btnAddButton;
        private System.Windows.Forms.GroupBox grpAdd;
        private System.Windows.Forms.Label lblNewRibbonName;
        private System.Windows.Forms.TextBox txtNewRibbonName;
        private System.Windows.Forms.Button btnAddTab;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Label lblAddDescription;
        private System.Windows.Forms.GroupBox grpSelected;
        private System.Windows.Forms.Label lblSelectedType;
        private System.Windows.Forms.Label lblSelectedTypeValue;
        private System.Windows.Forms.Label lblSelectedParent;
        private System.Windows.Forms.TextBox txtSelectedParent;
        private System.Windows.Forms.Label lblSelectedName;
        private System.Windows.Forms.TextBox txtSelectedName;
        private System.Windows.Forms.Label lblSelectedText;
        private System.Windows.Forms.TextBox txtSelectedText;
        private System.Windows.Forms.GroupBox grpVisible;
        private System.Windows.Forms.RadioButton rdoVisible;
        private System.Windows.Forms.RadioButton rdoHidden;
        private System.Windows.Forms.GroupBox grpSize;
        private System.Windows.Forms.RadioButton rdoLarge;
        private System.Windows.Forms.RadioButton rdoSmall;
        private System.Windows.Forms.Button btnApplySelected;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.grpSelected = new System.Windows.Forms.GroupBox();
            this.btnApplySelected = new System.Windows.Forms.Button();
            this.grpSize = new System.Windows.Forms.GroupBox();
            this.rdoSmall = new System.Windows.Forms.RadioButton();
            this.rdoLarge = new System.Windows.Forms.RadioButton();
            this.grpVisible = new System.Windows.Forms.GroupBox();
            this.rdoHidden = new System.Windows.Forms.RadioButton();
            this.rdoVisible = new System.Windows.Forms.RadioButton();
            this.txtSelectedText = new System.Windows.Forms.TextBox();
            this.lblSelectedText = new System.Windows.Forms.Label();
            this.txtSelectedName = new System.Windows.Forms.TextBox();
            this.lblSelectedName = new System.Windows.Forms.Label();
            this.txtSelectedParent = new System.Windows.Forms.TextBox();
            this.lblSelectedParent = new System.Windows.Forms.Label();
            this.lblSelectedTypeValue = new System.Windows.Forms.Label();
            this.lblSelectedType = new System.Windows.Forms.Label();
            this.grpAdd = new System.Windows.Forms.GroupBox();
            this.lblAddDescription = new System.Windows.Forms.Label();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnAddTab = new System.Windows.Forms.Button();
            this.txtNewRibbonName = new System.Windows.Forms.TextBox();
            this.lblNewRibbonName = new System.Windows.Forms.Label();
            this.grpStructure = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tlpStructure = new System.Windows.Forms.TableLayoutPanel();
            this.btnMoveTabLeft = new System.Windows.Forms.Button();
            this.btnMoveTabRight = new System.Windows.Forms.Button();
            this.btnAddQuickAccess = new System.Windows.Forms.Button();
            this.btnRemoveQuickAccess = new System.Windows.Forms.Button();
            this.btnQuickAccessDialog = new System.Windows.Forms.Button();
            this.btnAddButton = new System.Windows.Forms.Button();
            this.btnRestoreItem = new System.Windows.Forms.Button();
            this.btnMoveToCustom = new System.Windows.Forms.Button();
            this.treeCustom = new System.Windows.Forms.TreeView();
            this.treeAvailable = new System.Windows.Forms.TreeView();
            this.lblCustom = new System.Windows.Forms.Label();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.grpRibbonSetting = new System.Windows.Forms.GroupBox();
            this.btnResetRibbon = new System.Windows.Forms.Button();
            this.btnHideDefaultTabs = new System.Windows.Forms.Button();
            this.btnShowDefaultTabs = new System.Windows.Forms.Button();
            this.cmbRibbonTheme = new System.Windows.Forms.ComboBox();
            this.lblRibbonTheme = new System.Windows.Forms.Label();
            this.chkRibbonMode = new System.Windows.Forms.CheckBox();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlEditor.SuspendLayout();
            this.grpSelected.SuspendLayout();
            this.grpSize.SuspendLayout();
            this.grpVisible.SuspendLayout();
            this.grpAdd.SuspendLayout();
            this.grpStructure.SuspendLayout();
            this.tlpStructure.SuspendLayout();
            this.grpRibbonSetting.SuspendLayout();
            this.SuspendLayout();

            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.pnlEditor);
            this.splitContainer1.Size = new System.Drawing.Size(1500, 900);
            this.splitContainer1.SplitterDistance = 700;
            this.splitContainer1.TabIndex = 0;

            this.pnlEditor.AutoScroll = true;
            this.pnlEditor.Controls.Add(this.grpSelected);
            this.pnlEditor.Controls.Add(this.grpAdd);
            this.pnlEditor.Controls.Add(this.grpStructure);
            this.pnlEditor.Controls.Add(this.grpRibbonSetting);
            this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEditor.Location = new System.Drawing.Point(0, 0);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Size = new System.Drawing.Size(700, 900);
            this.pnlEditor.TabIndex = 0;

            this.grpRibbonSetting.Controls.Add(this.btnResetRibbon);
            this.grpRibbonSetting.Controls.Add(this.btnHideDefaultTabs);
            this.grpRibbonSetting.Controls.Add(this.btnShowDefaultTabs);
            this.grpRibbonSetting.Controls.Add(this.cmbRibbonTheme);
            this.grpRibbonSetting.Controls.Add(this.lblRibbonTheme);
            this.grpRibbonSetting.Controls.Add(this.chkRibbonMode);
            this.grpRibbonSetting.Location = new System.Drawing.Point(12, 12);
            this.grpRibbonSetting.Name = "grpRibbonSetting";
            this.grpRibbonSetting.Size = new System.Drawing.Size(665, 100);
            this.grpRibbonSetting.TabIndex = 0;
            this.grpRibbonSetting.TabStop = false;
            this.grpRibbonSetting.Text = "리본 설정";

            this.chkRibbonMode.AutoSize = true;
            this.chkRibbonMode.Location = new System.Drawing.Point(18, 29);
            this.chkRibbonMode.Name = "chkRibbonMode";
            this.chkRibbonMode.Size = new System.Drawing.Size(76, 16);
            this.chkRibbonMode.TabIndex = 0;
            this.chkRibbonMode.Text = "리본 사용";
            this.chkRibbonMode.UseVisualStyleBackColor = true;
            this.chkRibbonMode.CheckedChanged += new System.EventHandler(this.chkRibbonMode_CheckedChanged);

            this.lblRibbonTheme.AutoSize = true;
            this.lblRibbonTheme.Location = new System.Drawing.Point(18, 67);
            this.lblRibbonTheme.Name = "lblRibbonTheme";
            this.lblRibbonTheme.Size = new System.Drawing.Size(29, 12);
            this.lblRibbonTheme.TabIndex = 1;
            this.lblRibbonTheme.Text = "테마";

            this.cmbRibbonTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRibbonTheme.FormattingEnabled = true;
            this.cmbRibbonTheme.Location = new System.Drawing.Point(70, 63);
            this.cmbRibbonTheme.Name = "cmbRibbonTheme";
            this.cmbRibbonTheme.Size = new System.Drawing.Size(175, 20);
            this.cmbRibbonTheme.TabIndex = 2;
            this.cmbRibbonTheme.SelectedIndexChanged += new System.EventHandler(this.cmbRibbonTheme_SelectedIndexChanged);

            this.btnShowDefaultTabs.Location = new System.Drawing.Point(265, 30);
            this.btnShowDefaultTabs.Name = "btnShowDefaultTabs";
            this.btnShowDefaultTabs.Size = new System.Drawing.Size(115, 34);
            this.btnShowDefaultTabs.TabIndex = 3;
            this.btnShowDefaultTabs.Text = "기본 탭 표시";
            this.btnShowDefaultTabs.UseVisualStyleBackColor = true;
            this.btnShowDefaultTabs.Click += new System.EventHandler(this.btnShowDefaultTabs_Click);

            this.btnHideDefaultTabs.Location = new System.Drawing.Point(390, 30);
            this.btnHideDefaultTabs.Name = "btnHideDefaultTabs";
            this.btnHideDefaultTabs.Size = new System.Drawing.Size(115, 34);
            this.btnHideDefaultTabs.TabIndex = 4;
            this.btnHideDefaultTabs.Text = "기본 탭 숨김";
            this.btnHideDefaultTabs.UseVisualStyleBackColor = true;
            this.btnHideDefaultTabs.Click += new System.EventHandler(this.btnHideDefaultTabs_Click);

            this.btnResetRibbon.Location = new System.Drawing.Point(515, 30);
            this.btnResetRibbon.Name = "btnResetRibbon";
            this.btnResetRibbon.Size = new System.Drawing.Size(125, 34);
            this.btnResetRibbon.TabIndex = 5;
            this.btnResetRibbon.Text = "구성 초기화";
            this.btnResetRibbon.UseVisualStyleBackColor = true;
            this.btnResetRibbon.Click += new System.EventHandler(this.btnResetRibbon_Click);

            this.grpStructure.Controls.Add(this.tlpStructure);
            this.grpStructure.Controls.Add(this.btnRestoreItem);
            this.grpStructure.Controls.Add(this.btnMoveToCustom);
            this.grpStructure.Controls.Add(this.treeCustom);
            this.grpStructure.Controls.Add(this.treeAvailable);
            this.grpStructure.Controls.Add(this.lblCustom);
            this.grpStructure.Controls.Add(this.lblAvailable);
            this.grpStructure.Location = new System.Drawing.Point(12, 120);
            this.grpStructure.Name = "grpStructure";
            this.grpStructure.Size = new System.Drawing.Size(665, 420);
            this.grpStructure.TabIndex = 1;
            this.grpStructure.TabStop = false;
            this.grpStructure.Text = "리본 구성";

            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Location = new System.Drawing.Point(18, 26);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(93, 12);
            this.lblAvailable.TabIndex = 0;
            this.lblAvailable.Text = "사용 가능한 기능";

            this.lblCustom.AutoSize = true;
            this.lblCustom.Location = new System.Drawing.Point(372, 26);
            this.lblCustom.Name = "lblCustom";
            this.lblCustom.Size = new System.Drawing.Size(77, 12);
            this.lblCustom.TabIndex = 1;
            this.lblCustom.Text = "내 리본 구성";

            this.treeAvailable.HideSelection = false;
            this.treeAvailable.Location = new System.Drawing.Point(18, 46);
            this.treeAvailable.Name = "treeAvailable";
            this.treeAvailable.Size = new System.Drawing.Size(275, 310);
            this.treeAvailable.TabIndex = 2;
            this.treeAvailable.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeAvailable_AfterSelect);

            this.treeCustom.HideSelection = false;
            this.treeCustom.Location = new System.Drawing.Point(372, 46);
            this.treeCustom.Name = "treeCustom";
            this.treeCustom.Size = new System.Drawing.Size(267, 310);
            this.treeCustom.TabIndex = 3;
            this.treeCustom.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeCustom_AfterSelect);

            this.btnMoveToCustom.Enabled = false;
            this.btnMoveToCustom.Location = new System.Drawing.Point(304, 130);
            this.btnMoveToCustom.Name = "btnMoveToCustom";
            this.btnMoveToCustom.Size = new System.Drawing.Size(56, 38);
            this.btnMoveToCustom.TabIndex = 4;
            this.btnMoveToCustom.Text = "→";
            this.btnMoveToCustom.UseVisualStyleBackColor = true;
            this.btnMoveToCustom.Click += new System.EventHandler(this.btnMoveToCustom_Click);

            this.btnRestoreItem.Enabled = false;
            this.btnRestoreItem.Location = new System.Drawing.Point(304, 180);
            this.btnRestoreItem.Name = "btnRestoreItem";
            this.btnRestoreItem.Size = new System.Drawing.Size(56, 38);
            this.btnRestoreItem.TabIndex = 5;
            this.btnRestoreItem.Text = "←";
            this.btnRestoreItem.UseVisualStyleBackColor = true;
            this.btnRestoreItem.Click += new System.EventHandler(this.btnRestoreItem_Click);

            //
            // tlpStructure
            //
            this.tlpStructure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpStructure.ColumnCount = 6;
            this.tlpStructure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpStructure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpStructure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpStructure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpStructure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpStructure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpStructure.Controls.Add(this.btnRefresh, 0, 0);
            this.tlpStructure.Controls.Add(this.btnMoveTabLeft, 1, 0);
            this.tlpStructure.Controls.Add(this.btnMoveTabRight, 2, 0);
            this.tlpStructure.Controls.Add(this.btnAddQuickAccess, 3, 0);
            this.tlpStructure.Controls.Add(this.btnRemoveQuickAccess, 4, 0);
            this.tlpStructure.Controls.Add(this.btnQuickAccessDialog, 5, 0);
            this.tlpStructure.Location = new System.Drawing.Point(15, 365);
            this.tlpStructure.Name = "tlpStructure";
            this.tlpStructure.RowCount = 1;
            this.tlpStructure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStructure.Size = new System.Drawing.Size(627, 36);
            this.tlpStructure.TabIndex = 10;
            //
            // btnMoveTabLeft
            //
            this.btnMoveTabLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveTabLeft.Location = new System.Drawing.Point(107, 3);
            this.btnMoveTabLeft.Name = "btnMoveTabLeft";
            this.btnMoveTabLeft.Size = new System.Drawing.Size(98, 30);
            this.btnMoveTabLeft.TabIndex = 1;
            this.btnMoveTabLeft.Text = "탭 ◀";
            this.btnMoveTabLeft.UseVisualStyleBackColor = true;
            this.btnMoveTabLeft.Click += new System.EventHandler(this.btnMoveTabLeft_Click);
            //
            // btnMoveTabRight
            //
            this.btnMoveTabRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveTabRight.Location = new System.Drawing.Point(211, 3);
            this.btnMoveTabRight.Name = "btnMoveTabRight";
            this.btnMoveTabRight.Size = new System.Drawing.Size(98, 30);
            this.btnMoveTabRight.TabIndex = 2;
            this.btnMoveTabRight.Text = "탭 ▶";
            this.btnMoveTabRight.UseVisualStyleBackColor = true;
            this.btnMoveTabRight.Click += new System.EventHandler(this.btnMoveTabRight_Click);
            //
            // btnAddQuickAccess
            //
            this.btnAddQuickAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddQuickAccess.Location = new System.Drawing.Point(315, 3);
            this.btnAddQuickAccess.Name = "btnAddQuickAccess";
            this.btnAddQuickAccess.Size = new System.Drawing.Size(98, 30);
            this.btnAddQuickAccess.TabIndex = 3;
            this.btnAddQuickAccess.Text = "빠른 실행 추가";
            this.btnAddQuickAccess.UseVisualStyleBackColor = true;
            this.btnAddQuickAccess.Click += new System.EventHandler(this.btnAddQuickAccess_Click);
            //
            // btnRemoveQuickAccess
            //
            this.btnRemoveQuickAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveQuickAccess.Location = new System.Drawing.Point(419, 3);
            this.btnRemoveQuickAccess.Name = "btnRemoveQuickAccess";
            this.btnRemoveQuickAccess.Size = new System.Drawing.Size(98, 30);
            this.btnRemoveQuickAccess.TabIndex = 4;
            this.btnRemoveQuickAccess.Text = "빠른 실행 제거";
            this.btnRemoveQuickAccess.UseVisualStyleBackColor = true;
            this.btnRemoveQuickAccess.Click += new System.EventHandler(this.btnRemoveQuickAccess_Click);
            //
            // btnQuickAccessDialog
            //
            this.btnQuickAccessDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuickAccessDialog.Location = new System.Drawing.Point(523, 3);
            this.btnQuickAccessDialog.Name = "btnQuickAccessDialog";
            this.btnQuickAccessDialog.Size = new System.Drawing.Size(98, 30);
            this.btnQuickAccessDialog.TabIndex = 5;
            this.btnQuickAccessDialog.Text = "빠른 실행 설정";
            this.btnQuickAccessDialog.UseVisualStyleBackColor = true;
            this.btnQuickAccessDialog.Click += new System.EventHandler(this.btnQuickAccessDialog_Click);

            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 30);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.grpAdd.Controls.Add(this.lblAddDescription);
            this.grpAdd.Controls.Add(this.btnAddButton);
            this.grpAdd.Controls.Add(this.btnAddGroup);
            this.grpAdd.Controls.Add(this.btnAddTab);
            this.grpAdd.Controls.Add(this.txtNewRibbonName);
            this.grpAdd.Controls.Add(this.lblNewRibbonName);
            this.grpAdd.Location = new System.Drawing.Point(12, 548);
            this.grpAdd.Name = "grpAdd";
            this.grpAdd.Size = new System.Drawing.Size(665, 115);
            this.grpAdd.TabIndex = 2;
            this.grpAdd.TabStop = false;
            this.grpAdd.Text = "구성 추가";

            this.lblNewRibbonName.AutoSize = true;
            this.lblNewRibbonName.Location = new System.Drawing.Point(18, 30);
            this.lblNewRibbonName.Name = "lblNewRibbonName";
            this.lblNewRibbonName.Size = new System.Drawing.Size(53, 12);
            this.lblNewRibbonName.TabIndex = 0;
            this.lblNewRibbonName.Text = "표시 이름";

            this.txtNewRibbonName.Location = new System.Drawing.Point(90, 26);
            this.txtNewRibbonName.Name = "txtNewRibbonName";
            this.txtNewRibbonName.Size = new System.Drawing.Size(260, 21);
            this.txtNewRibbonName.TabIndex = 1;

            this.btnAddTab.Location = new System.Drawing.Point(365, 22);
            this.btnAddTab.Name = "btnAddTab";
            this.btnAddTab.Size = new System.Drawing.Size(88, 30);
            this.btnAddTab.TabIndex = 2;
            this.btnAddTab.Text = "탭 추가";
            this.btnAddTab.UseVisualStyleBackColor = true;
            this.btnAddTab.Click += new System.EventHandler(this.btnAddTab_Click);

            this.btnAddGroup.Enabled = false;
            //
            // btnAddButton
            //
            this.btnAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddButton.Location = new System.Drawing.Point(553, 22);
            this.btnAddButton.Name = "btnAddButton";
            this.btnAddButton.Size = new System.Drawing.Size(88, 30);
            this.btnAddButton.TabIndex = 5;
            this.btnAddButton.Text = "버튼 추가";
            this.btnAddButton.UseVisualStyleBackColor = true;
            this.btnAddButton.Click += new System.EventHandler(this.btnAddButton_Click);

            this.btnAddGroup.Location = new System.Drawing.Point(459, 22);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(88, 30);
            this.btnAddGroup.TabIndex = 3;
            this.btnAddGroup.Text = "그룹 추가";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);

            this.lblAddDescription.Location = new System.Drawing.Point(18, 66);
            this.lblAddDescription.Name = "lblAddDescription";
            this.lblAddDescription.Size = new System.Drawing.Size(621, 34);
            this.lblAddDescription.TabIndex = 4;
            this.lblAddDescription.Text = "탭 추가: 표시 이름 입력 후 추가\r\n그룹 / 버튼 추가: 오른쪽에서 대상 탭 / 그룹을 선택한 후 표시 이름 입력";

            this.grpSelected.Controls.Add(this.btnApplySelected);
            this.grpSelected.Controls.Add(this.grpSize);
            this.grpSelected.Controls.Add(this.grpVisible);
            this.grpSelected.Controls.Add(this.txtSelectedText);
            this.grpSelected.Controls.Add(this.lblSelectedText);
            this.grpSelected.Controls.Add(this.txtSelectedName);
            this.grpSelected.Controls.Add(this.lblSelectedName);
            this.grpSelected.Controls.Add(this.txtSelectedParent);
            this.grpSelected.Controls.Add(this.lblSelectedParent);
            this.grpSelected.Controls.Add(this.lblSelectedTypeValue);
            this.grpSelected.Controls.Add(this.lblSelectedType);
            this.grpSelected.Location = new System.Drawing.Point(12, 671);
            this.grpSelected.Name = "grpSelected";
            this.grpSelected.Size = new System.Drawing.Size(665, 220);
            this.grpSelected.TabIndex = 3;
            this.grpSelected.TabStop = false;
            this.grpSelected.Text = "선택 항목";

            this.lblSelectedType.AutoSize = true;
            this.lblSelectedType.Location = new System.Drawing.Point(18, 29);
            this.lblSelectedType.Name = "lblSelectedType";
            this.lblSelectedType.Size = new System.Drawing.Size(29, 12);
            this.lblSelectedType.TabIndex = 0;
            this.lblSelectedType.Text = "종류";

            this.lblSelectedTypeValue.AutoSize = true;
            this.lblSelectedTypeValue.Location = new System.Drawing.Point(90, 29);
            this.lblSelectedTypeValue.Name = "lblSelectedTypeValue";
            this.lblSelectedTypeValue.Size = new System.Drawing.Size(11, 12);
            this.lblSelectedTypeValue.TabIndex = 1;
            this.lblSelectedTypeValue.Text = "-";

            this.lblSelectedParent.AutoSize = true;
            this.lblSelectedParent.Location = new System.Drawing.Point(18, 61);
            this.lblSelectedParent.Name = "lblSelectedParent";
            this.lblSelectedParent.Size = new System.Drawing.Size(53, 12);
            this.lblSelectedParent.TabIndex = 2;
            this.lblSelectedParent.Text = "상위 항목";

            this.txtSelectedParent.Location = new System.Drawing.Point(90, 57);
            this.txtSelectedParent.Name = "txtSelectedParent";
            this.txtSelectedParent.ReadOnly = true;
            this.txtSelectedParent.Size = new System.Drawing.Size(235, 21);
            this.txtSelectedParent.TabIndex = 3;

            this.lblSelectedName.AutoSize = true;
            this.lblSelectedName.Location = new System.Drawing.Point(340, 61);
            this.lblSelectedName.Name = "lblSelectedName";
            this.lblSelectedName.Size = new System.Drawing.Size(53, 12);
            this.lblSelectedName.TabIndex = 4;
            this.lblSelectedName.Text = "내부 이름";

            this.txtSelectedName.Location = new System.Drawing.Point(405, 57);
            this.txtSelectedName.Name = "txtSelectedName";
            this.txtSelectedName.ReadOnly = true;
            this.txtSelectedName.Size = new System.Drawing.Size(234, 21);
            this.txtSelectedName.TabIndex = 5;

            this.lblSelectedText.AutoSize = true;
            this.lblSelectedText.Location = new System.Drawing.Point(18, 94);
            this.lblSelectedText.Name = "lblSelectedText";
            this.lblSelectedText.Size = new System.Drawing.Size(53, 12);
            this.lblSelectedText.TabIndex = 6;
            this.lblSelectedText.Text = "표시 이름";

            this.txtSelectedText.Enabled = false;
            this.txtSelectedText.Location = new System.Drawing.Point(90, 90);
            this.txtSelectedText.Name = "txtSelectedText";
            this.txtSelectedText.Size = new System.Drawing.Size(549, 21);
            this.txtSelectedText.TabIndex = 7;

            this.grpVisible.Controls.Add(this.rdoHidden);
            this.grpVisible.Controls.Add(this.rdoVisible);
            this.grpVisible.Location = new System.Drawing.Point(18, 123);
            this.grpVisible.Name = "grpVisible";
            this.grpVisible.Size = new System.Drawing.Size(200, 58);
            this.grpVisible.TabIndex = 8;
            this.grpVisible.TabStop = false;
            this.grpVisible.Text = "표시 상태";

            this.rdoVisible.AutoSize = true;
            this.rdoVisible.Location = new System.Drawing.Point(28, 25);
            this.rdoVisible.Name = "rdoVisible";
            this.rdoVisible.Size = new System.Drawing.Size(47, 16);
            this.rdoVisible.TabIndex = 0;
            this.rdoVisible.TabStop = true;
            this.rdoVisible.Text = "표시";
            this.rdoVisible.UseVisualStyleBackColor = true;

            this.rdoHidden.AutoSize = true;
            this.rdoHidden.Location = new System.Drawing.Point(112, 25);
            this.rdoHidden.Name = "rdoHidden";
            this.rdoHidden.Size = new System.Drawing.Size(47, 16);
            this.rdoHidden.TabIndex = 1;
            this.rdoHidden.TabStop = true;
            this.rdoHidden.Text = "숨김";
            this.rdoHidden.UseVisualStyleBackColor = true;

            this.grpSize.Controls.Add(this.rdoSmall);
            this.grpSize.Controls.Add(this.rdoLarge);
            this.grpSize.Location = new System.Drawing.Point(230, 123);
            this.grpSize.Name = "grpSize";
            this.grpSize.Size = new System.Drawing.Size(200, 58);
            this.grpSize.TabIndex = 9;
            this.grpSize.TabStop = false;
            this.grpSize.Text = "기능 크기";

            this.rdoLarge.AutoSize = true;
            this.rdoLarge.Location = new System.Drawing.Point(28, 25);
            this.rdoLarge.Name = "rdoLarge";
            this.rdoLarge.Size = new System.Drawing.Size(47, 16);
            this.rdoLarge.TabIndex = 0;
            this.rdoLarge.TabStop = true;
            this.rdoLarge.Text = "크게";
            this.rdoLarge.UseVisualStyleBackColor = true;

            this.rdoSmall.AutoSize = true;
            this.rdoSmall.Location = new System.Drawing.Point(112, 25);
            this.rdoSmall.Name = "rdoSmall";
            this.rdoSmall.Size = new System.Drawing.Size(47, 16);
            this.rdoSmall.TabIndex = 1;
            this.rdoSmall.TabStop = true;
            this.rdoSmall.Text = "작게";
            this.rdoSmall.UseVisualStyleBackColor = true;

            this.btnApplySelected.Enabled = false;
            this.btnApplySelected.Location = new System.Drawing.Point(446, 133);
            this.btnApplySelected.Name = "btnApplySelected";
            this.btnApplySelected.Size = new System.Drawing.Size(193, 40);
            this.btnApplySelected.TabIndex = 10;
            this.btnApplySelected.Text = "적용";
            this.btnApplySelected.UseVisualStyleBackColor = true;
            this.btnApplySelected.Click += new System.EventHandler(this.btnApplySelected_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 900);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1250, 750);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.RibbonCustomization";

            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlEditor.ResumeLayout(false);
            this.grpSelected.ResumeLayout(false);
            this.grpSelected.PerformLayout();
            this.grpSize.ResumeLayout(false);
            this.grpSize.PerformLayout();
            this.grpVisible.ResumeLayout(false);
            this.grpVisible.PerformLayout();
            this.grpAdd.ResumeLayout(false);
            this.grpAdd.PerformLayout();
            this.grpStructure.ResumeLayout(false);
            this.tlpStructure.ResumeLayout(false);
            this.grpStructure.PerformLayout();
            this.grpRibbonSetting.ResumeLayout(false);
            this.grpRibbonSetting.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}