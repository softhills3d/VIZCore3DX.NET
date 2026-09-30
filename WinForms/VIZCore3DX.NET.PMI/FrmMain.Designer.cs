namespace VIZCore3DX.NET.PMI
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
            this.tabControlPmi = new System.Windows.Forms.TabControl();
            this.tabPageElements = new System.Windows.Forms.TabPage();
            this.groupBoxElementList = new System.Windows.Forms.GroupBox();
            this.lblColorGuide = new System.Windows.Forms.Label();
            this.btnResetColors = new System.Windows.Forms.Button();
            this.btnResetElementsColor = new System.Windows.Forms.Button();
            this.btnSetElementsColor = new System.Windows.Forms.Button();
            this.btnElementColor = new System.Windows.Forms.Button();
            this.lblElementColor = new System.Windows.Forms.Label();
            this.btnCurrentListHide = new System.Windows.Forms.Button();
            this.btnCurrentListShow = new System.Windows.Forms.Button();
            this.dgvElements = new System.Windows.Forms.DataGridView();
            this.lblResultCount = new System.Windows.Forms.Label();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.btnCategoryTypeElements = new System.Windows.Forms.Button();
            this.btnAllElements = new System.Windows.Forms.Button();
            this.btnTypeElements = new System.Windows.Forms.Button();
            this.lblTypeCount = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.btnCategoryElements = new System.Windows.Forms.Button();
            this.lblCategoryCount = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnPmiElements = new System.Windows.Forms.Button();
            this.cmbPmiName = new System.Windows.Forms.ComboBox();
            this.lblPmiName = new System.Windows.Forms.Label();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblElementTotalCount = new System.Windows.Forms.Label();
            this.lblPmiCount = new System.Windows.Forms.Label();
            this.tabPageView = new System.Windows.Forms.TabPage();
            this.groupBoxView = new System.Windows.Forms.GroupBox();
            this.btnRefreshViews = new System.Windows.Forms.Button();
            this.btnDeactivateView = new System.Windows.Forms.Button();
            this.btnNextView = new System.Windows.Forms.Button();
            this.btnActivateView = new System.Windows.Forms.Button();
            this.btnPreviousView = new System.Windows.Forms.Button();
            this.lblActiveViewIndex = new System.Windows.Forms.Label();
            this.lblActiveView = new System.Windows.Forms.Label();
            this.lblViewCount = new System.Windows.Forms.Label();
            this.lvViews = new System.Windows.Forms.ListView();
            this.colViewIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colViewInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPmiName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOwnerNode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelectedNodeElements = new System.Windows.Forms.Button();
            this.chkIncludeChildNodes = new System.Windows.Forms.CheckBox();
            this.lblSelectedNodeInfo = new System.Windows.Forms.Label();
            this.tlpFilterButtons = new System.Windows.Forms.TableLayoutPanel();
            this.tlpListVisibility = new System.Windows.Forms.TableLayoutPanel();
            this.tlpColorButtons = new System.Windows.Forms.TableLayoutPanel();
            this.tlpViewButtons = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlPmi.SuspendLayout();
            this.tabPageElements.SuspendLayout();
            this.groupBoxElementList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElements)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.tabPageView.SuspendLayout();
            this.groupBoxView.SuspendLayout();
            this.tlpFilterButtons.SuspendLayout();
            this.tlpListVisibility.SuspendLayout();
            this.tlpColorButtons.SuspendLayout();
            this.tlpViewButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlPmi);
            this.splitContainer1.Panel2MinSize = 650;
            this.splitContainer1.Size = new System.Drawing.Size(1500, 900);
            this.splitContainer1.SplitterDistance = 830;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControlPmi
            // 
            this.tabControlPmi.Controls.Add(this.tabPageElements);
            this.tabControlPmi.Controls.Add(this.tabPageView);
            this.tabControlPmi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPmi.Location = new System.Drawing.Point(0, 0);
            this.tabControlPmi.Name = "tabControlPmi";
            this.tabControlPmi.SelectedIndex = 0;
            this.tabControlPmi.Size = new System.Drawing.Size(666, 900);
            this.tabControlPmi.TabIndex = 0;
            // 
            // tabPageElements
            // 
            this.tabPageElements.Controls.Add(this.groupBoxElementList);
            this.tabPageElements.Controls.Add(this.groupBoxFilter);
            this.tabPageElements.Controls.Add(this.groupBoxStatus);
            this.tabPageElements.Location = new System.Drawing.Point(4, 22);
            this.tabPageElements.Name = "tabPageElements";
            this.tabPageElements.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageElements.Size = new System.Drawing.Size(658, 874);
            this.tabPageElements.TabIndex = 0;
            this.tabPageElements.Text = "PMI 요소";
            this.tabPageElements.UseVisualStyleBackColor = true;
            // 
            // groupBoxElementList
            // 
            this.groupBoxElementList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxElementList.Controls.Add(this.tlpColorButtons);
            this.groupBoxElementList.Controls.Add(this.lblColorGuide);
            this.groupBoxElementList.Controls.Add(this.btnElementColor);
            this.groupBoxElementList.Controls.Add(this.lblElementColor);
            this.groupBoxElementList.Controls.Add(this.tlpListVisibility);
            this.groupBoxElementList.Controls.Add(this.dgvElements);
            this.groupBoxElementList.Controls.Add(this.lblResultCount);
            this.groupBoxElementList.Location = new System.Drawing.Point(10, 355);
            this.groupBoxElementList.Name = "groupBoxElementList";
            this.groupBoxElementList.Size = new System.Drawing.Size(638, 509);
            this.groupBoxElementList.TabIndex = 2;
            this.groupBoxElementList.TabStop = false;
            this.groupBoxElementList.Text = "PMI 요소";
            // 
            // lblColorGuide
            // 
            this.lblColorGuide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblColorGuide.AutoSize = true;
            this.lblColorGuide.Location = new System.Drawing.Point(15, 401);
            this.lblColorGuide.Name = "lblColorGuide";
            this.lblColorGuide.Size = new System.Drawing.Size(311, 12);
            this.lblColorGuide.TabIndex = 3;
            this.lblColorGuide.Text = "색상을 변경할 PMI 요소는 위 목록에서 행을 선택하세요.";
            // 
            // tlpColorButtons
            // 
            this.tlpColorButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpColorButtons.ColumnCount = 3;
            this.tlpColorButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpColorButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpColorButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpColorButtons.Controls.Add(this.btnSetElementsColor, 0, 0);
            this.tlpColorButtons.Controls.Add(this.btnResetElementsColor, 1, 0);
            this.tlpColorButtons.Controls.Add(this.btnResetColors, 2, 0);
            this.tlpColorButtons.Location = new System.Drawing.Point(12, 459);
            this.tlpColorButtons.Name = "tlpColorButtons";
            this.tlpColorButtons.RowCount = 1;
            this.tlpColorButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpColorButtons.Size = new System.Drawing.Size(614, 38);
            this.tlpColorButtons.TabIndex = 6;
            // 
            // btnResetColors
            // 
            this.btnResetColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResetColors.Location = new System.Drawing.Point(411, 3);
            this.btnResetColors.Name = "btnResetColors";
            this.btnResetColors.Size = new System.Drawing.Size(200, 32);
            this.btnResetColors.TabIndex = 2;
            this.btnResetColors.Text = "전체 PMI 색상 초기화";
            this.btnResetColors.UseVisualStyleBackColor = true;
            this.btnResetColors.Click += new System.EventHandler(this.btnResetColors_Click);
            // 
            // btnResetElementsColor
            // 
            this.btnResetElementsColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResetElementsColor.Location = new System.Drawing.Point(207, 3);
            this.btnResetElementsColor.Name = "btnResetElementsColor";
            this.btnResetElementsColor.Size = new System.Drawing.Size(198, 32);
            this.btnResetElementsColor.TabIndex = 1;
            this.btnResetElementsColor.Text = "선택 행 색상 초기화";
            this.btnResetElementsColor.UseVisualStyleBackColor = true;
            this.btnResetElementsColor.Click += new System.EventHandler(this.btnResetElementsColor_Click);
            // 
            // btnSetElementsColor
            // 
            this.btnSetElementsColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetElementsColor.Location = new System.Drawing.Point(3, 3);
            this.btnSetElementsColor.Name = "btnSetElementsColor";
            this.btnSetElementsColor.Size = new System.Drawing.Size(198, 32);
            this.btnSetElementsColor.TabIndex = 0;
            this.btnSetElementsColor.Text = "선택 행 색상 적용";
            this.btnSetElementsColor.UseVisualStyleBackColor = true;
            this.btnSetElementsColor.Click += new System.EventHandler(this.btnSetElementsColor_Click);
            // 
            // btnElementColor
            // 
            this.btnElementColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnElementColor.BackColor = System.Drawing.Color.White;
            this.btnElementColor.Location = new System.Drawing.Point(95, 423);
            this.btnElementColor.Name = "btnElementColor";
            this.btnElementColor.Size = new System.Drawing.Size(528, 30);
            this.btnElementColor.TabIndex = 5;
            this.btnElementColor.Text = "색상 선택";
            this.btnElementColor.UseVisualStyleBackColor = false;
            this.btnElementColor.Click += new System.EventHandler(this.btnElementColor_Click);
            // 
            // lblElementColor
            // 
            this.lblElementColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblElementColor.AutoSize = true;
            this.lblElementColor.Location = new System.Drawing.Point(15, 432);
            this.lblElementColor.Name = "lblElementColor";
            this.lblElementColor.Size = new System.Drawing.Size(57, 12);
            this.lblElementColor.TabIndex = 4;
            this.lblElementColor.Text = "적용 색상";
            // 
            // tlpListVisibility
            // 
            this.tlpListVisibility.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpListVisibility.ColumnCount = 2;
            this.tlpListVisibility.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpListVisibility.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpListVisibility.Controls.Add(this.btnCurrentListShow, 0, 0);
            this.tlpListVisibility.Controls.Add(this.btnCurrentListHide, 1, 0);
            this.tlpListVisibility.Location = new System.Drawing.Point(12, 355);
            this.tlpListVisibility.Name = "tlpListVisibility";
            this.tlpListVisibility.RowCount = 1;
            this.tlpListVisibility.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpListVisibility.Size = new System.Drawing.Size(614, 38);
            this.tlpListVisibility.TabIndex = 2;
            // 
            // btnCurrentListHide
            // 
            this.btnCurrentListHide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCurrentListHide.Location = new System.Drawing.Point(310, 3);
            this.btnCurrentListHide.Name = "btnCurrentListHide";
            this.btnCurrentListHide.Size = new System.Drawing.Size(301, 32);
            this.btnCurrentListHide.TabIndex = 1;
            this.btnCurrentListHide.Text = "현재 목록 전체 숨김";
            this.btnCurrentListHide.UseVisualStyleBackColor = true;
            this.btnCurrentListHide.Click += new System.EventHandler(this.btnCurrentListHide_Click);
            // 
            // btnCurrentListShow
            // 
            this.btnCurrentListShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCurrentListShow.Location = new System.Drawing.Point(3, 3);
            this.btnCurrentListShow.Name = "btnCurrentListShow";
            this.btnCurrentListShow.Size = new System.Drawing.Size(301, 32);
            this.btnCurrentListShow.TabIndex = 0;
            this.btnCurrentListShow.Text = "현재 목록 전체 표시";
            this.btnCurrentListShow.UseVisualStyleBackColor = true;
            this.btnCurrentListShow.Click += new System.EventHandler(this.btnCurrentListShow_Click);
            // 
            // dgvElements
            // 
            this.dgvElements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvElements.AllowUserToAddRows = false;
            this.dgvElements.AllowUserToDeleteRows = false;
            this.dgvElements.AllowUserToResizeRows = false;
            this.dgvElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVisible,
            this.colNo,
            this.colPmiName,
            this.colCategory,
            this.colType,
            this.colOwnerNode});
            this.dgvElements.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvElements.Location = new System.Drawing.Point(15, 48);
            this.dgvElements.Name = "dgvElements";
            this.dgvElements.RowHeadersVisible = false;
            this.dgvElements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvElements.Size = new System.Drawing.Size(608, 301);
            this.dgvElements.TabIndex = 1;
            // 
            // lblResultCount
            // 
            this.lblResultCount.AutoSize = true;
            this.lblResultCount.Location = new System.Drawing.Point(15, 25);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Size = new System.Drawing.Size(87, 12);
            this.lblResultCount.TabIndex = 0;
            this.lblResultCount.Text = "조회 결과 : 0개";
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFilter.Controls.Add(this.lblSelectedNodeInfo);
            this.groupBoxFilter.Controls.Add(this.tlpFilterButtons);
            this.groupBoxFilter.Controls.Add(this.btnTypeElements);
            this.groupBoxFilter.Controls.Add(this.lblTypeCount);
            this.groupBoxFilter.Controls.Add(this.cmbType);
            this.groupBoxFilter.Controls.Add(this.lblType);
            this.groupBoxFilter.Controls.Add(this.btnCategoryElements);
            this.groupBoxFilter.Controls.Add(this.lblCategoryCount);
            this.groupBoxFilter.Controls.Add(this.cmbCategory);
            this.groupBoxFilter.Controls.Add(this.lblCategory);
            this.groupBoxFilter.Controls.Add(this.btnPmiElements);
            this.groupBoxFilter.Controls.Add(this.cmbPmiName);
            this.groupBoxFilter.Controls.Add(this.lblPmiName);
            this.groupBoxFilter.Location = new System.Drawing.Point(10, 85);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(638, 260);
            this.groupBoxFilter.TabIndex = 1;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "PMI 요소 조회";
            // 
            // tlpFilterButtons
            // 
            this.tlpFilterButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFilterButtons.ColumnCount = 2;
            this.tlpFilterButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFilterButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFilterButtons.Controls.Add(this.btnAllElements, 0, 0);
            this.tlpFilterButtons.Controls.Add(this.btnCategoryTypeElements, 1, 0);
            this.tlpFilterButtons.Controls.Add(this.btnSelectedNodeElements, 0, 1);
            this.tlpFilterButtons.Controls.Add(this.chkIncludeChildNodes, 1, 1);
            this.tlpFilterButtons.Location = new System.Drawing.Point(12, 149);
            this.tlpFilterButtons.Name = "tlpFilterButtons";
            this.tlpFilterButtons.RowCount = 2;
            this.tlpFilterButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFilterButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFilterButtons.Size = new System.Drawing.Size(614, 76);
            this.tlpFilterButtons.TabIndex = 11;
            // 
            // btnCategoryTypeElements
            // 
            this.btnCategoryTypeElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCategoryTypeElements.Location = new System.Drawing.Point(310, 3);
            this.btnCategoryTypeElements.Name = "btnCategoryTypeElements";
            this.btnCategoryTypeElements.Size = new System.Drawing.Size(301, 32);
            this.btnCategoryTypeElements.TabIndex = 1;
            this.btnCategoryTypeElements.Text = "선택한 분류 + 유형";
            this.btnCategoryTypeElements.UseVisualStyleBackColor = true;
            this.btnCategoryTypeElements.Click += new System.EventHandler(this.btnCategoryTypeElements_Click);
            // 
            // btnSelectedNodeElements
            // 
            this.btnSelectedNodeElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectedNodeElements.Location = new System.Drawing.Point(3, 41);
            this.btnSelectedNodeElements.Name = "btnSelectedNodeElements";
            this.btnSelectedNodeElements.Size = new System.Drawing.Size(301, 32);
            this.btnSelectedNodeElements.TabIndex = 2;
            this.btnSelectedNodeElements.Text = "선택 노드의 PMI 조회";
            this.btnSelectedNodeElements.UseVisualStyleBackColor = true;
            this.btnSelectedNodeElements.Click += new System.EventHandler(this.btnSelectedNodeElements_Click);
            // 
            // chkIncludeChildNodes
            // 
            this.chkIncludeChildNodes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIncludeChildNodes.AutoSize = true;
            this.chkIncludeChildNodes.Location = new System.Drawing.Point(310, 49);
            this.chkIncludeChildNodes.Name = "chkIncludeChildNodes";
            this.chkIncludeChildNodes.Size = new System.Drawing.Size(104, 16);
            this.chkIncludeChildNodes.TabIndex = 3;
            this.chkIncludeChildNodes.Text = "하위 노드 포함";
            this.chkIncludeChildNodes.UseVisualStyleBackColor = true;
            // 
            // lblSelectedNodeInfo
            // 
            this.lblSelectedNodeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedNodeInfo.AutoEllipsis = true;
            this.lblSelectedNodeInfo.Location = new System.Drawing.Point(15, 232);
            this.lblSelectedNodeInfo.Name = "lblSelectedNodeInfo";
            this.lblSelectedNodeInfo.Size = new System.Drawing.Size(608, 18);
            this.lblSelectedNodeInfo.TabIndex = 12;
            this.lblSelectedNodeInfo.Text = "조회 노드 : -";
            // 
            // btnAllElements
            // 
            this.btnAllElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAllElements.Location = new System.Drawing.Point(3, 3);
            this.btnAllElements.Name = "btnAllElements";
            this.btnAllElements.Size = new System.Drawing.Size(301, 32);
            this.btnAllElements.TabIndex = 0;
            this.btnAllElements.Text = "전체 PMI 요소";
            this.btnAllElements.UseVisualStyleBackColor = true;
            this.btnAllElements.Click += new System.EventHandler(this.btnAllElements_Click);
            // 
            // btnTypeElements
            // 
            this.btnTypeElements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTypeElements.Location = new System.Drawing.Point(483, 107);
            this.btnTypeElements.Name = "btnTypeElements";
            this.btnTypeElements.Size = new System.Drawing.Size(140, 27);
            this.btnTypeElements.TabIndex = 10;
            this.btnTypeElements.Text = "유형 요소 보기";
            this.btnTypeElements.UseVisualStyleBackColor = true;
            this.btnTypeElements.Click += new System.EventHandler(this.btnTypeElements_Click);
            // 
            // lblTypeCount
            // 
            this.lblTypeCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTypeCount.AutoSize = true;
            this.lblTypeCount.Location = new System.Drawing.Point(403, 114);
            this.lblTypeCount.Name = "lblTypeCount";
            this.lblTypeCount.Size = new System.Drawing.Size(23, 12);
            this.lblTypeCount.TabIndex = 9;
            this.lblTypeCount.Text = "0개";
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(95, 110);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(300, 20);
            this.cmbType.TabIndex = 8;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(15, 114);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(29, 12);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "유형";
            // 
            // btnCategoryElements
            // 
            this.btnCategoryElements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategoryElements.Location = new System.Drawing.Point(483, 65);
            this.btnCategoryElements.Name = "btnCategoryElements";
            this.btnCategoryElements.Size = new System.Drawing.Size(140, 27);
            this.btnCategoryElements.TabIndex = 6;
            this.btnCategoryElements.Text = "분류 요소 보기";
            this.btnCategoryElements.UseVisualStyleBackColor = true;
            this.btnCategoryElements.Click += new System.EventHandler(this.btnCategoryElements_Click);
            // 
            // lblCategoryCount
            // 
            this.lblCategoryCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategoryCount.AutoSize = true;
            this.lblCategoryCount.Location = new System.Drawing.Point(403, 72);
            this.lblCategoryCount.Name = "lblCategoryCount";
            this.lblCategoryCount.Size = new System.Drawing.Size(23, 12);
            this.lblCategoryCount.TabIndex = 5;
            this.lblCategoryCount.Text = "0개";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(95, 68);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(300, 20);
            this.cmbCategory.TabIndex = 4;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(15, 72);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(29, 12);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "분류";
            // 
            // btnPmiElements
            // 
            this.btnPmiElements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPmiElements.Location = new System.Drawing.Point(483, 23);
            this.btnPmiElements.Name = "btnPmiElements";
            this.btnPmiElements.Size = new System.Drawing.Size(140, 27);
            this.btnPmiElements.TabIndex = 2;
            this.btnPmiElements.Text = "요소 보기";
            this.btnPmiElements.UseVisualStyleBackColor = true;
            this.btnPmiElements.Click += new System.EventHandler(this.btnPmiElements_Click);
            // 
            // cmbPmiName
            // 
            this.cmbPmiName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPmiName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPmiName.FormattingEnabled = true;
            this.cmbPmiName.Location = new System.Drawing.Point(95, 26);
            this.cmbPmiName.Name = "cmbPmiName";
            this.cmbPmiName.Size = new System.Drawing.Size(380, 20);
            this.cmbPmiName.TabIndex = 1;
            // 
            // lblPmiName
            // 
            this.lblPmiName.AutoSize = true;
            this.lblPmiName.Location = new System.Drawing.Point(15, 30);
            this.lblPmiName.Name = "lblPmiName";
            this.lblPmiName.Size = new System.Drawing.Size(55, 12);
            this.lblPmiName.TabIndex = 0;
            this.lblPmiName.Text = "PMI 이름";
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxStatus.Controls.Add(this.btnRefresh);
            this.groupBoxStatus.Controls.Add(this.lblElementTotalCount);
            this.groupBoxStatus.Controls.Add(this.lblPmiCount);
            this.groupBoxStatus.Location = new System.Drawing.Point(10, 10);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(638, 65);
            this.groupBoxStatus.TabIndex = 0;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "현재 모델 PMI";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(508, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(115, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "새로 고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblElementTotalCount
            // 
            this.lblElementTotalCount.AutoSize = true;
            this.lblElementTotalCount.Location = new System.Drawing.Point(145, 30);
            this.lblElementTotalCount.Name = "lblElementTotalCount";
            this.lblElementTotalCount.Size = new System.Drawing.Size(85, 12);
            this.lblElementTotalCount.TabIndex = 1;
            this.lblElementTotalCount.Text = "PMI 요소 : 0개";
            // 
            // lblPmiCount
            // 
            this.lblPmiCount.AutoSize = true;
            this.lblPmiCount.Location = new System.Drawing.Point(18, 30);
            this.lblPmiCount.Name = "lblPmiCount";
            this.lblPmiCount.Size = new System.Drawing.Size(57, 12);
            this.lblPmiCount.TabIndex = 0;
            this.lblPmiCount.Text = "PMI : 0개";
            // 
            // tabPageView
            // 
            this.tabPageView.Controls.Add(this.groupBoxView);
            this.tabPageView.Location = new System.Drawing.Point(4, 22);
            this.tabPageView.Name = "tabPageView";
            this.tabPageView.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageView.Size = new System.Drawing.Size(658, 874);
            this.tabPageView.TabIndex = 1;
            this.tabPageView.Text = "PMI 뷰";
            this.tabPageView.UseVisualStyleBackColor = true;
            // 
            // groupBoxView
            // 
            this.groupBoxView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxView.Controls.Add(this.tlpViewButtons);
            this.groupBoxView.Controls.Add(this.lblActiveViewIndex);
            this.groupBoxView.Controls.Add(this.lblActiveView);
            this.groupBoxView.Controls.Add(this.lblViewCount);
            this.groupBoxView.Controls.Add(this.lvViews);
            this.groupBoxView.Location = new System.Drawing.Point(10, 10);
            this.groupBoxView.Name = "groupBoxView";
            this.groupBoxView.Size = new System.Drawing.Size(638, 854);
            this.groupBoxView.TabIndex = 0;
            this.groupBoxView.TabStop = false;
            this.groupBoxView.Text = "PMI 뷰";
            // 
            // tlpViewButtons
            // 
            this.tlpViewButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpViewButtons.ColumnCount = 5;
            this.tlpViewButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpViewButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpViewButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpViewButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpViewButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpViewButtons.Controls.Add(this.btnPreviousView, 0, 0);
            this.tlpViewButtons.Controls.Add(this.btnActivateView, 1, 0);
            this.tlpViewButtons.Controls.Add(this.btnNextView, 2, 0);
            this.tlpViewButtons.Controls.Add(this.btnDeactivateView, 3, 0);
            this.tlpViewButtons.Controls.Add(this.btnRefreshViews, 4, 0);
            this.tlpViewButtons.Location = new System.Drawing.Point(12, 804);
            this.tlpViewButtons.Name = "tlpViewButtons";
            this.tlpViewButtons.RowCount = 1;
            this.tlpViewButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpViewButtons.Size = new System.Drawing.Size(614, 38);
            this.tlpViewButtons.TabIndex = 4;
            // 
            // btnRefreshViews
            // 
            this.btnRefreshViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefreshViews.Location = new System.Drawing.Point(491, 3);
            this.btnRefreshViews.Name = "btnRefreshViews";
            this.btnRefreshViews.Size = new System.Drawing.Size(120, 32);
            this.btnRefreshViews.TabIndex = 4;
            this.btnRefreshViews.Text = "새로 고침";
            this.btnRefreshViews.UseVisualStyleBackColor = true;
            this.btnRefreshViews.Click += new System.EventHandler(this.btnRefreshViews_Click);
            // 
            // btnDeactivateView
            // 
            this.btnDeactivateView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeactivateView.Location = new System.Drawing.Point(369, 3);
            this.btnDeactivateView.Name = "btnDeactivateView";
            this.btnDeactivateView.Size = new System.Drawing.Size(116, 32);
            this.btnDeactivateView.TabIndex = 3;
            this.btnDeactivateView.Text = "뷰 비활성화";
            this.btnDeactivateView.UseVisualStyleBackColor = true;
            this.btnDeactivateView.Click += new System.EventHandler(this.btnDeactivateView_Click);
            // 
            // btnNextView
            // 
            this.btnNextView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNextView.Location = new System.Drawing.Point(247, 3);
            this.btnNextView.Name = "btnNextView";
            this.btnNextView.Size = new System.Drawing.Size(116, 32);
            this.btnNextView.TabIndex = 2;
            this.btnNextView.Text = "다음 뷰";
            this.btnNextView.UseVisualStyleBackColor = true;
            this.btnNextView.Click += new System.EventHandler(this.btnNextView_Click);
            // 
            // btnActivateView
            // 
            this.btnActivateView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnActivateView.Location = new System.Drawing.Point(125, 3);
            this.btnActivateView.Name = "btnActivateView";
            this.btnActivateView.Size = new System.Drawing.Size(116, 32);
            this.btnActivateView.TabIndex = 1;
            this.btnActivateView.Text = "선택 뷰 활성화";
            this.btnActivateView.UseVisualStyleBackColor = true;
            this.btnActivateView.Click += new System.EventHandler(this.btnActivateView_Click);
            // 
            // btnPreviousView
            // 
            this.btnPreviousView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPreviousView.Location = new System.Drawing.Point(3, 3);
            this.btnPreviousView.Name = "btnPreviousView";
            this.btnPreviousView.Size = new System.Drawing.Size(116, 32);
            this.btnPreviousView.TabIndex = 0;
            this.btnPreviousView.Text = "이전 뷰";
            this.btnPreviousView.UseVisualStyleBackColor = true;
            this.btnPreviousView.Click += new System.EventHandler(this.btnPreviousView_Click);
            // 
            // lblActiveViewIndex
            // 
            this.lblActiveViewIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblActiveViewIndex.AutoSize = true;
            this.lblActiveViewIndex.Location = new System.Drawing.Point(15, 782);
            this.lblActiveViewIndex.Name = "lblActiveViewIndex";
            this.lblActiveViewIndex.Size = new System.Drawing.Size(109, 12);
            this.lblActiveViewIndex.TabIndex = 3;
            this.lblActiveViewIndex.Text = "활성 뷰 인덱스 : -1";
            // 
            // lblActiveView
            // 
            this.lblActiveView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblActiveView.AutoSize = true;
            this.lblActiveView.Location = new System.Drawing.Point(15, 758);
            this.lblActiveView.Name = "lblActiveView";
            this.lblActiveView.Size = new System.Drawing.Size(109, 12);
            this.lblActiveView.TabIndex = 2;
            this.lblActiveView.Text = "현재 활성 뷰 : 없음";
            // 
            // lblViewCount
            // 
            this.lblViewCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblViewCount.AutoSize = true;
            this.lblViewCount.Location = new System.Drawing.Point(15, 734);
            this.lblViewCount.Name = "lblViewCount";
            this.lblViewCount.Size = new System.Drawing.Size(73, 12);
            this.lblViewCount.TabIndex = 1;
            this.lblViewCount.Text = "PMI 뷰 : 0개";
            // 
            // lvViews
            // 
            this.lvViews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvViews.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colViewIndex,
            this.colViewInfo});
            this.lvViews.FullRowSelect = true;
            this.lvViews.GridLines = true;
            this.lvViews.HideSelection = false;
            this.lvViews.Location = new System.Drawing.Point(15, 25);
            this.lvViews.MultiSelect = false;
            this.lvViews.Name = "lvViews";
            this.lvViews.Size = new System.Drawing.Size(608, 701);
            this.lvViews.TabIndex = 0;
            this.lvViews.UseCompatibleStateImageBehavior = false;
            this.lvViews.View = System.Windows.Forms.View.Details;
            this.lvViews.DoubleClick += new System.EventHandler(this.lvViews_DoubleClick);
            // 
            // colViewIndex
            // 
            this.colViewIndex.Text = "인덱스";
            this.colViewIndex.Width = 70;
            // 
            // colViewInfo
            // 
            this.colViewInfo.Text = "PMI 뷰";
            this.colViewInfo.Width = 500;
            // 
            // colVisible
            // 
            this.colVisible.HeaderText = "표시";
            this.colVisible.Name = "colVisible";
            this.colVisible.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colVisible.Width = 55;
            // 
            // colNo
            // 
            this.colNo.HeaderText = "순번";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Width = 55;
            // 
            // colPmiName
            // 
            this.colPmiName.HeaderText = "PMI";
            this.colPmiName.Name = "colPmiName";
            this.colPmiName.ReadOnly = true;
            this.colPmiName.Width = 110;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "분류";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 110;
            // 
            // colType
            // 
            this.colType.HeaderText = "유형";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 130;
            // 
            // colOwnerNode
            // 
            this.colOwnerNode.HeaderText = "소유 노드";
            this.colOwnerNode.Name = "colOwnerNode";
            this.colOwnerNode.ReadOnly = true;
            this.colOwnerNode.Width = 125;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 900);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1250, 760);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.PMI";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlPmi.ResumeLayout(false);
            this.tabPageElements.ResumeLayout(false);
            this.groupBoxElementList.ResumeLayout(false);
            this.groupBoxElementList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElements)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            this.tabPageView.ResumeLayout(false);
            this.groupBoxView.ResumeLayout(false);
            this.groupBoxView.PerformLayout();
            this.tlpFilterButtons.ResumeLayout(false);
            this.tlpFilterButtons.PerformLayout();
            this.tlpListVisibility.ResumeLayout(false);
            this.tlpColorButtons.ResumeLayout(false);
            this.tlpViewButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlPmi;
        private System.Windows.Forms.TabPage tabPageElements;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.Label lblPmiCount;
        private System.Windows.Forms.Label lblElementTotalCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label lblPmiName;
        private System.Windows.Forms.ComboBox cmbPmiName;
        private System.Windows.Forms.Button btnPmiElements;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategoryCount;
        private System.Windows.Forms.Button btnCategoryElements;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblTypeCount;
        private System.Windows.Forms.Button btnTypeElements;
        private System.Windows.Forms.Button btnAllElements;
        private System.Windows.Forms.Button btnCategoryTypeElements;
        private System.Windows.Forms.GroupBox groupBoxElementList;
        private System.Windows.Forms.Label lblResultCount;
        private System.Windows.Forms.DataGridView dgvElements;
        private System.Windows.Forms.Button btnCurrentListShow;
        private System.Windows.Forms.Button btnCurrentListHide;
        private System.Windows.Forms.Label lblColorGuide;
        private System.Windows.Forms.Label lblElementColor;
        private System.Windows.Forms.Button btnElementColor;
        private System.Windows.Forms.Button btnSetElementsColor;
        private System.Windows.Forms.Button btnResetElementsColor;
        private System.Windows.Forms.Button btnResetColors;
        private System.Windows.Forms.TabPage tabPageView;
        private System.Windows.Forms.GroupBox groupBoxView;
        private System.Windows.Forms.ListView lvViews;
        private System.Windows.Forms.ColumnHeader colViewIndex;
        private System.Windows.Forms.ColumnHeader colViewInfo;
        private System.Windows.Forms.Label lblViewCount;
        private System.Windows.Forms.Label lblActiveView;
        private System.Windows.Forms.Label lblActiveViewIndex;
        private System.Windows.Forms.Button btnPreviousView;
        private System.Windows.Forms.Button btnActivateView;
        private System.Windows.Forms.Button btnNextView;
        private System.Windows.Forms.Button btnDeactivateView;
        private System.Windows.Forms.Button btnRefreshViews;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colVisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPmiName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOwnerNode;
        private System.Windows.Forms.Button btnSelectedNodeElements;
        private System.Windows.Forms.CheckBox chkIncludeChildNodes;
        private System.Windows.Forms.Label lblSelectedNodeInfo;
        private System.Windows.Forms.TableLayoutPanel tlpFilterButtons;
        private System.Windows.Forms.TableLayoutPanel tlpListVisibility;
        private System.Windows.Forms.TableLayoutPanel tlpColorButtons;
        private System.Windows.Forms.TableLayoutPanel tlpViewButtons;
    }
}