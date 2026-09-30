namespace VIZCore3DX.NET.SectionBoxControl
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
            this.tlpBoxButtons = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tlpMaxMove = new System.Windows.Forms.TableLayoutPanel();
            this.btnMaxMoveX_M = new System.Windows.Forms.Button();
            this.txtMoveMaxOffset = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnMaxMoveY_M = new System.Windows.Forms.Button();
            this.btnMaxMoveZ_P = new System.Windows.Forms.Button();
            this.btnMaxMoveY_P = new System.Windows.Forms.Button();
            this.btnMaxMoveZ_M = new System.Windows.Forms.Button();
            this.btnMaxMoveX_P = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tlpMinMove = new System.Windows.Forms.TableLayoutPanel();
            this.btnMinMoveX_M = new System.Windows.Forms.Button();
            this.txtMoveMinOffset = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMinMoveY_M = new System.Windows.Forms.Button();
            this.btnMinMoveZ_P = new System.Windows.Forms.Button();
            this.btnMinMoveY_P = new System.Windows.Forms.Button();
            this.btnMinMoveZ_M = new System.Windows.Forms.Button();
            this.btnMinMoveX_P = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tlpMaxSize = new System.Windows.Forms.TableLayoutPanel();
            this.txtMaxZ = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaxY = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnMaxResize = new System.Windows.Forms.Button();
            this.txtMaxX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tlpMinSize = new System.Windows.Forms.TableLayoutPanel();
            this.txtMinZ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMinY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMinResize = new System.Windows.Forms.Button();
            this.txtMinX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBoxShow = new System.Windows.Forms.Button();
            this.btnBoxReset = new System.Windows.Forms.Button();
            this.btnBoxHide = new System.Windows.Forms.Button();
            this.btnAddBox = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.groupSectionJson = new System.Windows.Forms.GroupBox();
            this.tlpSectionJson = new System.Windows.Forms.TableLayoutPanel();
            this.btnSectionSaveJson = new System.Windows.Forms.Button();
            this.btnSectionLoadJson = new System.Windows.Forms.Button();
            this.groupSectionBoundary = new System.Windows.Forms.GroupBox();
            this.chkBoundaryVisible = new System.Windows.Forms.CheckBox();
            this.pnlBoundaryColor = new System.Windows.Forms.Panel();
            this.btnBoundaryColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tlpBoxButtons.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tlpMaxMove.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tlpMinMove.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tlpMaxSize.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tlpMinSize.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupSectionJson.SuspendLayout();
            this.tlpSectionJson.SuspendLayout();
            this.groupSectionBoundary.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1280, 760);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupSectionBoundary);
            this.groupBox2.Controls.Add(this.groupSectionJson);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.tlpBoxButtons);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 668);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Section Box";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.groupBox9);
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Location = new System.Drawing.Point(12, 298);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(352, 220);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Move Control";
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.txtMoveMaxOffset);
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Controls.Add(this.tlpMaxMove);
            this.groupBox9.Location = new System.Drawing.Point(12, 118);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(328, 90);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Max";
            // 
            // tlpMaxMove
            // 
            this.tlpMaxMove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMaxMove.ColumnCount = 3;
            this.tlpMaxMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMaxMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMaxMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpMaxMove.Controls.Add(this.btnMaxMoveX_P, 0, 0);
            this.tlpMaxMove.Controls.Add(this.btnMaxMoveY_P, 1, 0);
            this.tlpMaxMove.Controls.Add(this.btnMaxMoveZ_P, 2, 0);
            this.tlpMaxMove.Controls.Add(this.btnMaxMoveX_M, 0, 1);
            this.tlpMaxMove.Controls.Add(this.btnMaxMoveY_M, 1, 1);
            this.tlpMaxMove.Controls.Add(this.btnMaxMoveZ_M, 2, 1);
            this.tlpMaxMove.Location = new System.Drawing.Point(138, 18);
            this.tlpMaxMove.Name = "tlpMaxMove";
            this.tlpMaxMove.RowCount = 2;
            this.tlpMaxMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMaxMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMaxMove.Size = new System.Drawing.Size(181, 64);
            this.tlpMaxMove.TabIndex = 2;
            // 
            // btnMaxMoveX_M
            // 
            this.btnMaxMoveX_M.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMaxMoveX_M.Location = new System.Drawing.Point(3, 35);
            this.btnMaxMoveX_M.Name = "btnMaxMoveX_M";
            this.btnMaxMoveX_M.Size = new System.Drawing.Size(54, 26);
            this.btnMaxMoveX_M.TabIndex = 0;
            this.btnMaxMoveX_M.TabStop = false;
            this.btnMaxMoveX_M.Text = "X -";
            this.btnMaxMoveX_M.UseVisualStyleBackColor = true;
            this.btnMaxMoveX_M.Click += new System.EventHandler(this.btnMaxMoveX_M_Click);
            // 
            // txtMoveMaxOffset
            // 
            this.txtMoveMaxOffset.Location = new System.Drawing.Point(58, 39);
            this.txtMoveMaxOffset.Name = "txtMoveMaxOffset";
            this.txtMoveMaxOffset.Size = new System.Drawing.Size(70, 21);
            this.txtMoveMaxOffset.TabIndex = 1;
            this.txtMoveMaxOffset.Text = "1000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 9F);
            this.label11.Location = new System.Drawing.Point(12, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "Offset";
            // 
            // btnMaxMoveY_M
            // 
            this.btnMaxMoveY_M.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMaxMoveY_M.Location = new System.Drawing.Point(63, 35);
            this.btnMaxMoveY_M.Name = "btnMaxMoveY_M";
            this.btnMaxMoveY_M.Size = new System.Drawing.Size(55, 26);
            this.btnMaxMoveY_M.TabIndex = 0;
            this.btnMaxMoveY_M.TabStop = false;
            this.btnMaxMoveY_M.Text = "Y -";
            this.btnMaxMoveY_M.UseVisualStyleBackColor = true;
            this.btnMaxMoveY_M.Click += new System.EventHandler(this.btnMaxMoveY_M_Click);
            // 
            // btnMaxMoveZ_P
            // 
            this.btnMaxMoveZ_P.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMaxMoveZ_P.Location = new System.Drawing.Point(124, 3);
            this.btnMaxMoveZ_P.Name = "btnMaxMoveZ_P";
            this.btnMaxMoveZ_P.Size = new System.Drawing.Size(54, 26);
            this.btnMaxMoveZ_P.TabIndex = 0;
            this.btnMaxMoveZ_P.TabStop = false;
            this.btnMaxMoveZ_P.Text = "Z +";
            this.btnMaxMoveZ_P.UseVisualStyleBackColor = true;
            this.btnMaxMoveZ_P.Click += new System.EventHandler(this.btnMaxMoveZ_P_Click);
            // 
            // btnMaxMoveY_P
            // 
            this.btnMaxMoveY_P.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMaxMoveY_P.Location = new System.Drawing.Point(63, 3);
            this.btnMaxMoveY_P.Name = "btnMaxMoveY_P";
            this.btnMaxMoveY_P.Size = new System.Drawing.Size(55, 26);
            this.btnMaxMoveY_P.TabIndex = 0;
            this.btnMaxMoveY_P.TabStop = false;
            this.btnMaxMoveY_P.Text = "Y +";
            this.btnMaxMoveY_P.UseVisualStyleBackColor = true;
            this.btnMaxMoveY_P.Click += new System.EventHandler(this.btnMaxMoveY_P_Click);
            // 
            // btnMaxMoveZ_M
            // 
            this.btnMaxMoveZ_M.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMaxMoveZ_M.Location = new System.Drawing.Point(124, 35);
            this.btnMaxMoveZ_M.Name = "btnMaxMoveZ_M";
            this.btnMaxMoveZ_M.Size = new System.Drawing.Size(54, 26);
            this.btnMaxMoveZ_M.TabIndex = 0;
            this.btnMaxMoveZ_M.TabStop = false;
            this.btnMaxMoveZ_M.Text = "Z -";
            this.btnMaxMoveZ_M.UseVisualStyleBackColor = true;
            this.btnMaxMoveZ_M.Click += new System.EventHandler(this.btnMaxMoveZ_M_Click);
            // 
            // btnMaxMoveX_P
            // 
            this.btnMaxMoveX_P.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMaxMoveX_P.Location = new System.Drawing.Point(3, 3);
            this.btnMaxMoveX_P.Name = "btnMaxMoveX_P";
            this.btnMaxMoveX_P.Size = new System.Drawing.Size(54, 26);
            this.btnMaxMoveX_P.TabIndex = 0;
            this.btnMaxMoveX_P.TabStop = false;
            this.btnMaxMoveX_P.Text = "X +";
            this.btnMaxMoveX_P.UseVisualStyleBackColor = true;
            this.btnMaxMoveX_P.Click += new System.EventHandler(this.btnMaxMoveX_P_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.txtMoveMinOffset);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.tlpMinMove);
            this.groupBox8.Location = new System.Drawing.Point(12, 22);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(328, 90);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Min";
            // 
            // tlpMinMove
            // 
            this.tlpMinMove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMinMove.ColumnCount = 3;
            this.tlpMinMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMinMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMinMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpMinMove.Controls.Add(this.btnMinMoveX_P, 0, 0);
            this.tlpMinMove.Controls.Add(this.btnMinMoveY_P, 1, 0);
            this.tlpMinMove.Controls.Add(this.btnMinMoveZ_P, 2, 0);
            this.tlpMinMove.Controls.Add(this.btnMinMoveX_M, 0, 1);
            this.tlpMinMove.Controls.Add(this.btnMinMoveY_M, 1, 1);
            this.tlpMinMove.Controls.Add(this.btnMinMoveZ_M, 2, 1);
            this.tlpMinMove.Location = new System.Drawing.Point(138, 18);
            this.tlpMinMove.Name = "tlpMinMove";
            this.tlpMinMove.RowCount = 2;
            this.tlpMinMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMinMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMinMove.Size = new System.Drawing.Size(181, 64);
            this.tlpMinMove.TabIndex = 2;
            // 
            // btnMinMoveX_M
            // 
            this.btnMinMoveX_M.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinMoveX_M.Location = new System.Drawing.Point(3, 35);
            this.btnMinMoveX_M.Name = "btnMinMoveX_M";
            this.btnMinMoveX_M.Size = new System.Drawing.Size(54, 26);
            this.btnMinMoveX_M.TabIndex = 0;
            this.btnMinMoveX_M.TabStop = false;
            this.btnMinMoveX_M.Text = "X -";
            this.btnMinMoveX_M.UseVisualStyleBackColor = true;
            this.btnMinMoveX_M.Click += new System.EventHandler(this.btnMinMoveX_M_Click);
            // 
            // txtMoveMinOffset
            // 
            this.txtMoveMinOffset.Location = new System.Drawing.Point(58, 39);
            this.txtMoveMinOffset.Name = "txtMoveMinOffset";
            this.txtMoveMinOffset.Size = new System.Drawing.Size(70, 21);
            this.txtMoveMinOffset.TabIndex = 1;
            this.txtMoveMinOffset.Text = "1000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9F);
            this.label6.Location = new System.Drawing.Point(12, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Offset";
            // 
            // btnMinMoveY_M
            // 
            this.btnMinMoveY_M.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinMoveY_M.Location = new System.Drawing.Point(63, 35);
            this.btnMinMoveY_M.Name = "btnMinMoveY_M";
            this.btnMinMoveY_M.Size = new System.Drawing.Size(55, 26);
            this.btnMinMoveY_M.TabIndex = 0;
            this.btnMinMoveY_M.TabStop = false;
            this.btnMinMoveY_M.Text = "Y -";
            this.btnMinMoveY_M.UseVisualStyleBackColor = true;
            this.btnMinMoveY_M.Click += new System.EventHandler(this.btnMinMoveY_M_Click);
            // 
            // btnMinMoveZ_P
            // 
            this.btnMinMoveZ_P.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinMoveZ_P.Location = new System.Drawing.Point(124, 3);
            this.btnMinMoveZ_P.Name = "btnMinMoveZ_P";
            this.btnMinMoveZ_P.Size = new System.Drawing.Size(54, 26);
            this.btnMinMoveZ_P.TabIndex = 0;
            this.btnMinMoveZ_P.TabStop = false;
            this.btnMinMoveZ_P.Text = "Z +";
            this.btnMinMoveZ_P.UseVisualStyleBackColor = true;
            this.btnMinMoveZ_P.Click += new System.EventHandler(this.btnMinMoveZ_P_Click);
            // 
            // btnMinMoveY_P
            // 
            this.btnMinMoveY_P.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinMoveY_P.Location = new System.Drawing.Point(63, 3);
            this.btnMinMoveY_P.Name = "btnMinMoveY_P";
            this.btnMinMoveY_P.Size = new System.Drawing.Size(55, 26);
            this.btnMinMoveY_P.TabIndex = 0;
            this.btnMinMoveY_P.TabStop = false;
            this.btnMinMoveY_P.Text = "Y +";
            this.btnMinMoveY_P.UseVisualStyleBackColor = true;
            this.btnMinMoveY_P.Click += new System.EventHandler(this.btnMinMoveY_P_Click);
            // 
            // btnMinMoveZ_M
            // 
            this.btnMinMoveZ_M.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinMoveZ_M.Location = new System.Drawing.Point(124, 35);
            this.btnMinMoveZ_M.Name = "btnMinMoveZ_M";
            this.btnMinMoveZ_M.Size = new System.Drawing.Size(54, 26);
            this.btnMinMoveZ_M.TabIndex = 0;
            this.btnMinMoveZ_M.TabStop = false;
            this.btnMinMoveZ_M.Text = "Z -";
            this.btnMinMoveZ_M.UseVisualStyleBackColor = true;
            this.btnMinMoveZ_M.Click += new System.EventHandler(this.btnMinMoveZ_M_Click);
            // 
            // btnMinMoveX_P
            // 
            this.btnMinMoveX_P.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinMoveX_P.Location = new System.Drawing.Point(3, 3);
            this.btnMinMoveX_P.Name = "btnMinMoveX_P";
            this.btnMinMoveX_P.Size = new System.Drawing.Size(54, 26);
            this.btnMinMoveX_P.TabIndex = 0;
            this.btnMinMoveX_P.TabStop = false;
            this.btnMinMoveX_P.Text = "X +";
            this.btnMinMoveX_P.UseVisualStyleBackColor = true;
            this.btnMinMoveX_P.Click += new System.EventHandler(this.btnMinMoveX_P_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Location = new System.Drawing.Point(12, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(352, 228);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Size Control";
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.btnMaxResize);
            this.groupBox7.Controls.Add(this.tlpMaxSize);
            this.groupBox7.Location = new System.Drawing.Point(12, 122);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(328, 94);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Max";
            // 
            // tlpMaxSize
            // 
            this.tlpMaxSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMaxSize.ColumnCount = 6;
            this.tlpMaxSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMaxSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMaxSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMaxSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMaxSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMaxSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpMaxSize.Controls.Add(this.label10, 0, 0);
            this.tlpMaxSize.Controls.Add(this.txtMaxX, 1, 0);
            this.tlpMaxSize.Controls.Add(this.label9, 2, 0);
            this.tlpMaxSize.Controls.Add(this.txtMaxY, 3, 0);
            this.tlpMaxSize.Controls.Add(this.label8, 4, 0);
            this.tlpMaxSize.Controls.Add(this.txtMaxZ, 5, 0);
            this.tlpMaxSize.Location = new System.Drawing.Point(9, 20);
            this.tlpMaxSize.Name = "tlpMaxSize";
            this.tlpMaxSize.RowCount = 1;
            this.tlpMaxSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMaxSize.Size = new System.Drawing.Size(310, 30);
            this.tlpMaxSize.TabIndex = 0;
            // 
            // txtMaxZ
            // 
            this.txtMaxZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaxZ.Location = new System.Drawing.Point(230, 4);
            this.txtMaxZ.Name = "txtMaxZ";
            this.txtMaxZ.Size = new System.Drawing.Size(77, 21);
            this.txtMaxZ.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9F);
            this.label8.Location = new System.Drawing.Point(210, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Z";
            // 
            // txtMaxY
            // 
            this.txtMaxY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaxY.Location = new System.Drawing.Point(126, 4);
            this.txtMaxY.Name = "txtMaxY";
            this.txtMaxY.Size = new System.Drawing.Size(78, 21);
            this.txtMaxY.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(106, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "Y";
            // 
            // btnMaxResize
            // 
            this.btnMaxResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaxResize.Location = new System.Drawing.Point(226, 56);
            this.btnMaxResize.Name = "btnMaxResize";
            this.btnMaxResize.Size = new System.Drawing.Size(90, 28);
            this.btnMaxResize.TabIndex = 0;
            this.btnMaxResize.TabStop = false;
            this.btnMaxResize.Text = "Resize";
            this.btnMaxResize.UseVisualStyleBackColor = true;
            this.btnMaxResize.Click += new System.EventHandler(this.btnMaxResize_Click);
            // 
            // txtMaxX
            // 
            this.txtMaxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaxX.Location = new System.Drawing.Point(23, 4);
            this.txtMaxX.Name = "txtMaxX";
            this.txtMaxX.Size = new System.Drawing.Size(77, 21);
            this.txtMaxX.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 9F);
            this.label10.Location = new System.Drawing.Point(3, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "X";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.btnMinResize);
            this.groupBox5.Controls.Add(this.tlpMinSize);
            this.groupBox5.Location = new System.Drawing.Point(12, 22);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(328, 94);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Min";
            // 
            // tlpMinSize
            // 
            this.tlpMinSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMinSize.ColumnCount = 6;
            this.tlpMinSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMinSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMinSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMinSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMinSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMinSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpMinSize.Controls.Add(this.label7, 0, 0);
            this.tlpMinSize.Controls.Add(this.txtMinX, 1, 0);
            this.tlpMinSize.Controls.Add(this.label5, 2, 0);
            this.tlpMinSize.Controls.Add(this.txtMinY, 3, 0);
            this.tlpMinSize.Controls.Add(this.label4, 4, 0);
            this.tlpMinSize.Controls.Add(this.txtMinZ, 5, 0);
            this.tlpMinSize.Location = new System.Drawing.Point(9, 20);
            this.tlpMinSize.Name = "tlpMinSize";
            this.tlpMinSize.RowCount = 1;
            this.tlpMinSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMinSize.Size = new System.Drawing.Size(310, 30);
            this.tlpMinSize.TabIndex = 0;
            // 
            // txtMinZ
            // 
            this.txtMinZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinZ.Location = new System.Drawing.Point(230, 4);
            this.txtMinZ.Name = "txtMinZ";
            this.txtMinZ.Size = new System.Drawing.Size(77, 21);
            this.txtMinZ.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F);
            this.label4.Location = new System.Drawing.Point(210, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Z";
            // 
            // txtMinY
            // 
            this.txtMinY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinY.Location = new System.Drawing.Point(126, 4);
            this.txtMinY.Name = "txtMinY";
            this.txtMinY.Size = new System.Drawing.Size(78, 21);
            this.txtMinY.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(106, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "Y";
            // 
            // btnMinResize
            // 
            this.btnMinResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinResize.Location = new System.Drawing.Point(226, 56);
            this.btnMinResize.Name = "btnMinResize";
            this.btnMinResize.Size = new System.Drawing.Size(90, 28);
            this.btnMinResize.TabIndex = 0;
            this.btnMinResize.TabStop = false;
            this.btnMinResize.Text = "Resize";
            this.btnMinResize.UseVisualStyleBackColor = true;
            this.btnMinResize.Click += new System.EventHandler(this.btnMinResize_Click);
            // 
            // txtMinX
            // 
            this.txtMinX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinX.Location = new System.Drawing.Point(23, 4);
            this.txtMinX.Name = "txtMinX";
            this.txtMinX.Size = new System.Drawing.Size(77, 21);
            this.txtMinX.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 9F);
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "X";
            // 
            // tlpBoxButtons
            // 
            this.tlpBoxButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpBoxButtons.ColumnCount = 4;
            this.tlpBoxButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBoxButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBoxButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBoxButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBoxButtons.Controls.Add(this.btnAddBox, 0, 0);
            this.tlpBoxButtons.Controls.Add(this.btnBoxHide, 1, 0);
            this.tlpBoxButtons.Controls.Add(this.btnBoxShow, 2, 0);
            this.tlpBoxButtons.Controls.Add(this.btnBoxReset, 3, 0);
            this.tlpBoxButtons.Location = new System.Drawing.Point(9, 20);
            this.tlpBoxButtons.Name = "tlpBoxButtons";
            this.tlpBoxButtons.RowCount = 1;
            this.tlpBoxButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBoxButtons.Size = new System.Drawing.Size(358, 34);
            this.tlpBoxButtons.TabIndex = 0;
            // 
            // btnBoxShow
            // 
            this.btnBoxShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBoxShow.Location = new System.Drawing.Point(182, 3);
            this.btnBoxShow.Name = "btnBoxShow";
            this.btnBoxShow.Size = new System.Drawing.Size(83, 28);
            this.btnBoxShow.TabIndex = 0;
            this.btnBoxShow.TabStop = false;
            this.btnBoxShow.Text = "Show";
            this.btnBoxShow.UseVisualStyleBackColor = true;
            this.btnBoxShow.Click += new System.EventHandler(this.btnBoxShow_Click);
            // 
            // btnBoxReset
            // 
            this.btnBoxReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBoxReset.Location = new System.Drawing.Point(271, 3);
            this.btnBoxReset.Name = "btnBoxReset";
            this.btnBoxReset.Size = new System.Drawing.Size(84, 28);
            this.btnBoxReset.TabIndex = 0;
            this.btnBoxReset.TabStop = false;
            this.btnBoxReset.Text = "Reset";
            this.btnBoxReset.UseVisualStyleBackColor = true;
            this.btnBoxReset.Click += new System.EventHandler(this.btnBoxReset_Click);
            // 
            // btnBoxHide
            // 
            this.btnBoxHide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBoxHide.Location = new System.Drawing.Point(93, 3);
            this.btnBoxHide.Name = "btnBoxHide";
            this.btnBoxHide.Size = new System.Drawing.Size(83, 28);
            this.btnBoxHide.TabIndex = 0;
            this.btnBoxHide.TabStop = false;
            this.btnBoxHide.Text = "Hide";
            this.btnBoxHide.UseVisualStyleBackColor = true;
            this.btnBoxHide.Click += new System.EventHandler(this.btnBoxHide_Click);
            // 
            // btnAddBox
            // 
            this.btnAddBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddBox.Location = new System.Drawing.Point(3, 3);
            this.btnAddBox.Name = "btnAddBox";
            this.btnAddBox.Size = new System.Drawing.Size(84, 28);
            this.btnAddBox.TabIndex = 0;
            this.btnAddBox.TabStop = false;
            this.btnAddBox.Text = "Add";
            this.btnAddBox.UseVisualStyleBackColor = true;
            this.btnAddBox.Click += new System.EventHandler(this.btnAddBox_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnOpenModel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Open";
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenModel.Location = new System.Drawing.Point(12, 22);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(352, 28);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.TabStop = false;
            this.btnOpenModel.Text = "Model";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // groupSectionJson
            // 
            this.groupSectionJson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSectionJson.Controls.Add(this.tlpSectionJson);
            this.groupSectionJson.Location = new System.Drawing.Point(12, 526);
            this.groupSectionJson.Name = "groupSectionJson";
            this.groupSectionJson.Size = new System.Drawing.Size(352, 62);
            this.groupSectionJson.TabIndex = 3;
            this.groupSectionJson.TabStop = false;
            this.groupSectionJson.Text = "JSON 저장 / 복원 (ToJson / FromJson)";
            // 
            // tlpSectionJson
            // 
            this.tlpSectionJson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpSectionJson.ColumnCount = 2;
            this.tlpSectionJson.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSectionJson.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSectionJson.Controls.Add(this.btnSectionSaveJson, 0, 0);
            this.tlpSectionJson.Controls.Add(this.btnSectionLoadJson, 1, 0);
            this.tlpSectionJson.Location = new System.Drawing.Point(9, 20);
            this.tlpSectionJson.Name = "tlpSectionJson";
            this.tlpSectionJson.RowCount = 1;
            this.tlpSectionJson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSectionJson.Size = new System.Drawing.Size(334, 34);
            this.tlpSectionJson.TabIndex = 0;
            // 
            // btnSectionSaveJson
            // 
            this.btnSectionSaveJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSectionSaveJson.Location = new System.Drawing.Point(3, 3);
            this.btnSectionSaveJson.Name = "btnSectionSaveJson";
            this.btnSectionSaveJson.Size = new System.Drawing.Size(161, 28);
            this.btnSectionSaveJson.TabIndex = 0;
            this.btnSectionSaveJson.Text = "JSON 파일로 저장";
            this.btnSectionSaveJson.UseVisualStyleBackColor = true;
            this.btnSectionSaveJson.Click += new System.EventHandler(this.btnSectionSaveJson_Click);
            // 
            // btnSectionLoadJson
            // 
            this.btnSectionLoadJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSectionLoadJson.Location = new System.Drawing.Point(170, 3);
            this.btnSectionLoadJson.Name = "btnSectionLoadJson";
            this.btnSectionLoadJson.Size = new System.Drawing.Size(161, 28);
            this.btnSectionLoadJson.TabIndex = 1;
            this.btnSectionLoadJson.Text = "JSON 파일에서 불러오기";
            this.btnSectionLoadJson.UseVisualStyleBackColor = true;
            this.btnSectionLoadJson.Click += new System.EventHandler(this.btnSectionLoadJson_Click);
            // 
            // groupSectionBoundary
            // 
            this.groupSectionBoundary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSectionBoundary.Controls.Add(this.btnBoundaryColor);
            this.groupSectionBoundary.Controls.Add(this.pnlBoundaryColor);
            this.groupSectionBoundary.Controls.Add(this.chkBoundaryVisible);
            this.groupSectionBoundary.Location = new System.Drawing.Point(12, 596);
            this.groupSectionBoundary.Name = "groupSectionBoundary";
            this.groupSectionBoundary.Size = new System.Drawing.Size(352, 60);
            this.groupSectionBoundary.TabIndex = 4;
            this.groupSectionBoundary.TabStop = false;
            this.groupSectionBoundary.Text = "단면 경계선 색상/숨김";
            // 
            // chkBoundaryVisible
            // 
            this.chkBoundaryVisible.AutoSize = true;
            this.chkBoundaryVisible.Checked = true;
            this.chkBoundaryVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoundaryVisible.Location = new System.Drawing.Point(12, 27);
            this.chkBoundaryVisible.Name = "chkBoundaryVisible";
            this.chkBoundaryVisible.Size = new System.Drawing.Size(88, 16);
            this.chkBoundaryVisible.TabIndex = 0;
            this.chkBoundaryVisible.Text = "경계선 표시";
            this.chkBoundaryVisible.UseVisualStyleBackColor = true;
            this.chkBoundaryVisible.CheckedChanged += new System.EventHandler(this.chkBoundaryVisible_CheckedChanged);
            // 
            // pnlBoundaryColor
            // 
            this.pnlBoundaryColor.BackColor = System.Drawing.Color.Red;
            this.pnlBoundaryColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBoundaryColor.Location = new System.Drawing.Point(130, 24);
            this.pnlBoundaryColor.Name = "pnlBoundaryColor";
            this.pnlBoundaryColor.Size = new System.Drawing.Size(30, 21);
            this.pnlBoundaryColor.TabIndex = 1;
            // 
            // btnBoundaryColor
            // 
            this.btnBoundaryColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBoundaryColor.Location = new System.Drawing.Point(210, 20);
            this.btnBoundaryColor.Name = "btnBoundaryColor";
            this.btnBoundaryColor.Size = new System.Drawing.Size(130, 28);
            this.btnBoundaryColor.TabIndex = 2;
            this.btnBoundaryColor.Text = "경계선 색상 선택";
            this.btnBoundaryColor.UseVisualStyleBackColor = true;
            this.btnBoundaryColor.Click += new System.EventHandler(this.btnBoundaryColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.SectionBoxControl";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tlpBoxButtons.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tlpMaxMove.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tlpMinMove.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tlpMaxSize.ResumeLayout(false);
            this.tlpMaxSize.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tlpMinSize.ResumeLayout(false);
            this.tlpMinSize.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupSectionJson.ResumeLayout(false);
            this.tlpSectionJson.ResumeLayout(false);
            this.groupSectionBoundary.ResumeLayout(false);
            this.groupSectionBoundary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tlpBoxButtons;
        private System.Windows.Forms.Button btnBoxHide;
        private System.Windows.Forms.Button btnAddBox;
        private System.Windows.Forms.Button btnBoxShow;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBoxReset;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnMinMoveZ_P;
        private System.Windows.Forms.TextBox txtMoveMinOffset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnMinMoveY_M;
        private System.Windows.Forms.Button btnMinMoveY_P;
        private System.Windows.Forms.Button btnMinMoveX_P;
        private System.Windows.Forms.Button btnMinMoveX_M;
        private System.Windows.Forms.Button btnMinMoveZ_M;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tlpMinSize;
        private System.Windows.Forms.TextBox txtMinZ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMinY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMinResize;
        private System.Windows.Forms.TextBox txtMinX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TableLayoutPanel tlpMaxSize;
        private System.Windows.Forms.TextBox txtMaxZ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaxY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnMaxResize;
        private System.Windows.Forms.TextBox txtMaxX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TableLayoutPanel tlpMinMove;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TableLayoutPanel tlpMaxMove;
        private System.Windows.Forms.Button btnMaxMoveX_M;
        private System.Windows.Forms.TextBox txtMoveMaxOffset;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnMaxMoveY_M;
        private System.Windows.Forms.Button btnMaxMoveZ_P;
        private System.Windows.Forms.Button btnMaxMoveY_P;
        private System.Windows.Forms.Button btnMaxMoveZ_M;
        private System.Windows.Forms.Button btnMaxMoveX_P;
        private System.Windows.Forms.GroupBox groupSectionJson;
        private System.Windows.Forms.TableLayoutPanel tlpSectionJson;
        private System.Windows.Forms.Button btnSectionSaveJson;
        private System.Windows.Forms.Button btnSectionLoadJson;
        private System.Windows.Forms.GroupBox groupSectionBoundary;
        private System.Windows.Forms.CheckBox chkBoundaryVisible;
        private System.Windows.Forms.Panel pnlBoundaryColor;
        private System.Windows.Forms.Button btnBoundaryColor;
    }
}

