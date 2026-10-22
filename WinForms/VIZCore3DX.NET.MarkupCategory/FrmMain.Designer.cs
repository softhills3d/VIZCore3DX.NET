namespace VIZCore3DX.NET.MarkupCategory
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
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeasure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDecal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSnapshot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpRun = new System.Windows.Forms.GroupBox();
            this.btnAddAllKinds = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpSetup = new System.Windows.Forms.GroupBox();
            this.numCount = new System.Windows.Forms.NumericUpDown();
            this.lblCount = new System.Windows.Forms.Label();
            this.cmbKind = new System.Windows.Forms.ComboBox();
            this.lblKind = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.grpRun.SuspendLayout();
            this.grpSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpResult);
            this.splitContainer1.Panel1.Controls.Add(this.grpRun);
            this.splitContainer1.Panel1.Controls.Add(this.grpSetup);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Controls.Add(this.grpCleanup);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 800);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 0;
            //
            // grpResult
            //
            this.grpResult.Controls.Add(this.btnRefresh);
            this.grpResult.Controls.Add(this.btnDelete);
            this.grpResult.Controls.Add(this.btnHide);
            this.grpResult.Controls.Add(this.btnShow);
            this.grpResult.Controls.Add(this.dgvCategories);
            this.grpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResult.Location = new System.Drawing.Point(8, 282);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(344, 428);
            this.grpResult.TabIndex = 3;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "4. 결과";
            //
            // btnRefresh
            //
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(10, 362);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "새로 고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // btnDelete
            //
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(222, 332);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "카테고리 삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnHide
            //
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHide.Location = new System.Drawing.Point(116, 332);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(100, 23);
            this.btnHide.TabIndex = 2;
            this.btnHide.Text = "숨기기";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            //
            // btnShow
            //
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShow.Location = new System.Drawing.Point(10, 332);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(100, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "보이기";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            //
            // dgvCategories
            //
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AllowUserToResizeRows = false;
            this.dgvCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCategory,
            this.colNote,
            this.colMeasure,
            this.colDecal,
            this.colSnapshot,
            this.colShape});
            this.dgvCategories.Location = new System.Drawing.Point(10, 20);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.RowTemplate.Height = 23;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(324, 300);
            this.dgvCategories.TabIndex = 0;
            this.dgvCategories.SelectionChanged += new System.EventHandler(this.dgvCategories_SelectionChanged);
            //
            // colCategory
            //
            this.colCategory.FillWeight = 120F;
            this.colCategory.HeaderText = "카테고리";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            //
            // colNote
            //
            this.colNote.FillWeight = 50F;
            this.colNote.HeaderText = "노트";
            this.colNote.Name = "colNote";
            this.colNote.ReadOnly = true;
            //
            // colMeasure
            //
            this.colMeasure.FillWeight = 50F;
            this.colMeasure.HeaderText = "측정";
            this.colMeasure.Name = "colMeasure";
            this.colMeasure.ReadOnly = true;
            //
            // colDecal
            //
            this.colDecal.FillWeight = 50F;
            this.colDecal.HeaderText = "데칼";
            this.colDecal.Name = "colDecal";
            this.colDecal.ReadOnly = true;
            //
            // colSnapshot
            //
            this.colSnapshot.FillWeight = 60F;
            this.colSnapshot.HeaderText = "스냅샷";
            this.colSnapshot.Name = "colSnapshot";
            this.colSnapshot.ReadOnly = true;
            //
            // colShape
            //
            this.colShape.FillWeight = 50F;
            this.colShape.HeaderText = "형상";
            this.colShape.Name = "colShape";
            this.colShape.ReadOnly = true;
            //
            // grpRun
            //
            this.grpRun.Controls.Add(this.btnAddAllKinds);
            this.grpRun.Controls.Add(this.btnAdd);
            this.grpRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRun.Location = new System.Drawing.Point(8, 222);
            this.grpRun.Name = "grpRun";
            this.grpRun.Size = new System.Drawing.Size(344, 60);
            this.grpRun.TabIndex = 2;
            this.grpRun.TabStop = false;
            this.grpRun.Text = "3. 실행";
            //
            // btnAddAllKinds
            //
            this.btnAddAllKinds.Location = new System.Drawing.Point(136, 22);
            this.btnAddAllKinds.Name = "btnAddAllKinds";
            this.btnAddAllKinds.Size = new System.Drawing.Size(120, 23);
            this.btnAddAllKinds.TabIndex = 1;
            this.btnAddAllKinds.Text = "5종 모두 추가";
            this.btnAddAllKinds.UseVisualStyleBackColor = true;
            this.btnAddAllKinds.Click += new System.EventHandler(this.btnAddAllKinds_Click);
            //
            // btnAdd
            //
            this.btnAdd.Location = new System.Drawing.Point(10, 22);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // grpSetup
            //
            this.grpSetup.Controls.Add(this.numCount);
            this.grpSetup.Controls.Add(this.lblCount);
            this.grpSetup.Controls.Add(this.cmbKind);
            this.grpSetup.Controls.Add(this.lblKind);
            this.grpSetup.Controls.Add(this.txtCategory);
            this.grpSetup.Controls.Add(this.lblCategory);
            this.grpSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSetup.Location = new System.Drawing.Point(8, 104);
            this.grpSetup.Name = "grpSetup";
            this.grpSetup.Size = new System.Drawing.Size(344, 118);
            this.grpSetup.TabIndex = 1;
            this.grpSetup.TabStop = false;
            this.grpSetup.Text = "2. 설정";
            //
            // numCount
            //
            this.numCount.Location = new System.Drawing.Point(80, 76);
            this.numCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(80, 21);
            this.numCount.TabIndex = 5;
            this.numCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            //
            // lblCount
            //
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(10, 79);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(29, 12);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "개수";
            //
            // cmbKind
            //
            this.cmbKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKind.Location = new System.Drawing.Point(80, 48);
            this.cmbKind.Name = "cmbKind";
            this.cmbKind.Size = new System.Drawing.Size(200, 20);
            this.cmbKind.TabIndex = 3;
            //
            // lblKind
            //
            this.lblKind.AutoSize = true;
            this.lblKind.Location = new System.Drawing.Point(10, 51);
            this.lblKind.Name = "lblKind";
            this.lblKind.Size = new System.Drawing.Size(29, 12);
            this.lblKind.TabIndex = 2;
            this.lblKind.Text = "종류";
            //
            // txtCategory
            //
            this.txtCategory.Location = new System.Drawing.Point(80, 20);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(200, 21);
            this.txtCategory.TabIndex = 1;
            this.txtCategory.Text = "CAT_A";
            //
            // lblCategory
            //
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(10, 23);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(53, 12);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "카테고리";
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
            this.lblModelHint.Location = new System.Drawing.Point(10, 52);
            this.lblModelHint.Name = "lblModelHint";
            this.lblModelHint.Size = new System.Drawing.Size(320, 32);
            this.lblModelHint.TabIndex = 1;
            this.lblModelHint.Text = "마크업은 모델 상자 위에 한 줄로 만듭니다.\r\n카테고리를 바꿔 가며 추가하면 묶음별 제어를 볼 수 있습니다.";
            //
            // btnOpenModel
            //
            this.btnOpenModel.Location = new System.Drawing.Point(10, 20);
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
            this.btnClearAll.Location = new System.Drawing.Point(10, 22);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(150, 23);
            this.btnClearAll.TabIndex = 0;
            this.btnClearAll.Text = "마크업 전부 지우기";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
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
            this.Text = "VIZCore3DX.NET.MarkupCategory";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.grpRun.ResumeLayout(false);
            this.grpSetup.ResumeLayout(false);
            this.grpSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).EndInit();
            this.grpModel.ResumeLayout(false);
            this.grpCleanup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.Label lblModelHint;
        private System.Windows.Forms.GroupBox grpSetup;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblKind;
        private System.Windows.Forms.ComboBox cmbKind;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.NumericUpDown numCount;
        private System.Windows.Forms.GroupBox grpRun;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddAllKinds;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeasure;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDecal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSnapshot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShape;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label lblStatus;
    }
}
