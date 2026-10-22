namespace VIZCore3DX.NET.BulkNodes
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
            this.btnClearRows = new System.Windows.Forms.Button();
            this.dgvTimes = new System.Windows.Forms.DataGridView();
            this.colStep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNodes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaving = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpRun = new System.Windows.Forms.GroupBox();
            this.lblRunHint = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.grpSetup = new System.Windows.Forms.GroupBox();
            this.numRepeat = new System.Windows.Forms.NumericUpDown();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.numMove = new System.Windows.Forms.NumericUpDown();
            this.lblMove = new System.Windows.Forms.Label();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimes)).BeginInit();
            this.grpRun.SuspendLayout();
            this.grpSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMove)).BeginInit();
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
            this.grpResult.Controls.Add(this.btnClearRows);
            this.grpResult.Controls.Add(this.dgvTimes);
            this.grpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResult.Location = new System.Drawing.Point(8, 314);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(344, 396);
            this.grpResult.TabIndex = 3;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "4. 결과";
            //
            // btnClearRows
            //
            this.btnClearRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearRows.Location = new System.Drawing.Point(10, 358);
            this.btnClearRows.Name = "btnClearRows";
            this.btnClearRows.Size = new System.Drawing.Size(100, 23);
            this.btnClearRows.TabIndex = 1;
            this.btnClearRows.Text = "표 비우기";
            this.btnClearRows.UseVisualStyleBackColor = true;
            this.btnClearRows.Click += new System.EventHandler(this.btnClearRows_Click);
            //
            // dgvTimes
            //
            this.dgvTimes.AllowUserToAddRows = false;
            this.dgvTimes.AllowUserToDeleteRows = false;
            this.dgvTimes.AllowUserToResizeRows = false;
            this.dgvTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStep,
            this.colNodes,
            this.colEntries,
            this.colSaving,
            this.colCount});
            this.dgvTimes.Location = new System.Drawing.Point(10, 20);
            this.dgvTimes.MultiSelect = false;
            this.dgvTimes.Name = "dgvTimes";
            this.dgvTimes.ReadOnly = true;
            this.dgvTimes.RowHeadersVisible = false;
            this.dgvTimes.RowTemplate.Height = 23;
            this.dgvTimes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimes.Size = new System.Drawing.Size(324, 330);
            this.dgvTimes.TabIndex = 0;
            //
            // colStep
            //
            this.colStep.FillWeight = 130F;
            this.colStep.HeaderText = "단계";
            this.colStep.Name = "colStep";
            this.colStep.ReadOnly = true;
            //
            // colNodes
            //
            this.colNodes.FillWeight = 70F;
            this.colNodes.HeaderText = "노드 목록";
            this.colNodes.Name = "colNodes";
            this.colNodes.ReadOnly = true;
            //
            // colEntries
            //
            this.colEntries.FillWeight = 70F;
            this.colEntries.HeaderText = "항목 목록";
            this.colEntries.Name = "colEntries";
            this.colEntries.ReadOnly = true;
            //
            // colSaving
            //
            this.colSaving.FillWeight = 50F;
            this.colSaving.HeaderText = "절감";
            this.colSaving.Name = "colSaving";
            this.colSaving.ReadOnly = true;
            //
            // colCount
            //
            this.colCount.FillWeight = 60F;
            this.colCount.HeaderText = "건수";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            //
            // grpRun
            //
            this.grpRun.Controls.Add(this.lblRunHint);
            this.grpRun.Controls.Add(this.btnApply);
            this.grpRun.Controls.Add(this.btnQuery);
            this.grpRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRun.Location = new System.Drawing.Point(8, 222);
            this.grpRun.Name = "grpRun";
            this.grpRun.Size = new System.Drawing.Size(344, 92);
            this.grpRun.TabIndex = 2;
            this.grpRun.TabStop = false;
            this.grpRun.Text = "3. 실행";
            //
            // lblRunHint
            //
            this.lblRunHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRunHint.Location = new System.Drawing.Point(10, 52);
            this.lblRunHint.Name = "lblRunHint";
            this.lblRunHint.Size = new System.Drawing.Size(320, 32);
            this.lblRunHint.TabIndex = 2;
            this.lblRunHint.Text = "조회는 GC 후 반복 평균, 적용은 노드 목록으로 한 번·항목 목록으로 한 번 실행합니다.";
            //
            // btnApply
            //
            this.btnApply.Location = new System.Drawing.Point(166, 22);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(150, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "적용 시간 비교";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            //
            // btnQuery
            //
            this.btnQuery.Location = new System.Drawing.Point(10, 22);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(150, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "조회 시간 비교";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            //
            // grpSetup
            //
            this.grpSetup.Controls.Add(this.numRepeat);
            this.grpSetup.Controls.Add(this.lblRepeat);
            this.grpSetup.Controls.Add(this.numMove);
            this.grpSetup.Controls.Add(this.lblMove);
            this.grpSetup.Controls.Add(this.cmbAction);
            this.grpSetup.Controls.Add(this.lblAction);
            this.grpSetup.Controls.Add(this.cmbFilter);
            this.grpSetup.Controls.Add(this.lblFilter);
            this.grpSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSetup.Location = new System.Drawing.Point(8, 104);
            this.grpSetup.Name = "grpSetup";
            this.grpSetup.Size = new System.Drawing.Size(344, 118);
            this.grpSetup.TabIndex = 1;
            this.grpSetup.TabStop = false;
            this.grpSetup.Text = "2. 설정";
            //
            // numRepeat
            //
            this.numRepeat.Location = new System.Drawing.Point(260, 76);
            this.numRepeat.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRepeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRepeat.Name = "numRepeat";
            this.numRepeat.Size = new System.Drawing.Size(74, 21);
            this.numRepeat.TabIndex = 7;
            this.numRepeat.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            //
            // lblRepeat
            //
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.Location = new System.Drawing.Point(222, 79);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(29, 12);
            this.lblRepeat.TabIndex = 6;
            this.lblRepeat.Text = "반복";
            //
            // numMove
            //
            this.numMove.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMove.Location = new System.Drawing.Point(100, 76);
            this.numMove.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMove.Name = "numMove";
            this.numMove.Size = new System.Drawing.Size(100, 21);
            this.numMove.TabIndex = 5;
            this.numMove.ThousandsSeparator = true;
            this.numMove.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            //
            // lblMove
            //
            this.lblMove.AutoSize = true;
            this.lblMove.Location = new System.Drawing.Point(10, 79);
            this.lblMove.Name = "lblMove";
            this.lblMove.Size = new System.Drawing.Size(84, 12);
            this.lblMove.TabIndex = 4;
            this.lblMove.Text = "이동 거리(mm)";
            //
            // cmbAction
            //
            this.cmbAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.Location = new System.Drawing.Point(100, 48);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(234, 20);
            this.cmbAction.TabIndex = 3;
            //
            // lblAction
            //
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(10, 51);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(57, 12);
            this.lblAction.TabIndex = 2;
            this.lblAction.Text = "적용 동작";
            //
            // cmbFilter
            //
            this.cmbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Location = new System.Drawing.Point(100, 20);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(234, 20);
            this.cmbFilter.TabIndex = 1;
            //
            // lblFilter
            //
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(10, 23);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(57, 12);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "조회 대상";
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
            this.lblModelHint.Text = "노드가 많은 모델일수록 차이가 큽니다.\r\n조회 → 적용 순서로 누르면 표에 시간이 쌓입니다.";
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
            this.grpCleanup.Controls.Add(this.btnClear);
            this.grpCleanup.Controls.Add(this.btnRestore);
            this.grpCleanup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCleanup.Location = new System.Drawing.Point(8, 710);
            this.grpCleanup.Name = "grpCleanup";
            this.grpCleanup.Size = new System.Drawing.Size(344, 60);
            this.grpCleanup.TabIndex = 4;
            this.grpCleanup.TabStop = false;
            this.grpCleanup.Text = "5. 정리";
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(136, 22);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "전부 지우기";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnRestore
            //
            this.btnRestore.Location = new System.Drawing.Point(10, 22);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(120, 23);
            this.btnRestore.TabIndex = 0;
            this.btnRestore.Text = "원래대로";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
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
            this.Text = "VIZCore3DX.NET.BulkNodes";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimes)).EndInit();
            this.grpRun.ResumeLayout(false);
            this.grpSetup.ResumeLayout(false);
            this.grpSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMove)).EndInit();
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
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.Label lblMove;
        private System.Windows.Forms.NumericUpDown numMove;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.NumericUpDown numRepeat;
        private System.Windows.Forms.GroupBox grpRun;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblRunHint;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.DataGridView dgvTimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntries;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaving;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.Button btnClearRows;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStatus;
    }
}
