namespace VIZCore3DX.NET.SectionBoxControl
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnMaxMoveX_M = new System.Windows.Forms.Button();
            this.txtMoveMaxOffset = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnMaxMoveY_M = new System.Windows.Forms.Button();
            this.btnMaxMoveZ_P = new System.Windows.Forms.Button();
            this.btnMaxMoveY_P = new System.Windows.Forms.Button();
            this.btnMaxMoveZ_M = new System.Windows.Forms.Button();
            this.btnMaxMoveX_P = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
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
            this.txtMaxZ = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaxY = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnMaxResize = new System.Windows.Forms.Button();
            this.txtMaxX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1043, 742);
            this.splitContainer1.SplitterDistance = 379;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnBoxShow);
            this.groupBox2.Controls.Add(this.btnBoxReset);
            this.groupBox2.Controls.Add(this.btnBoxHide);
            this.groupBox2.Controls.Add(this.btnAddBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 645);
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
            this.groupBox4.Location = new System.Drawing.Point(6, 274);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(340, 229);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Move Control";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnMaxMoveX_M);
            this.groupBox9.Controls.Add(this.txtMoveMaxOffset);
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Controls.Add(this.btnMaxMoveY_M);
            this.groupBox9.Controls.Add(this.btnMaxMoveZ_P);
            this.groupBox9.Controls.Add(this.btnMaxMoveY_P);
            this.groupBox9.Controls.Add(this.btnMaxMoveZ_M);
            this.groupBox9.Controls.Add(this.btnMaxMoveX_P);
            this.groupBox9.Location = new System.Drawing.Point(6, 121);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(328, 95);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Max";
            // 
            // btnMaxMoveX_M
            // 
            this.btnMaxMoveX_M.Location = new System.Drawing.Point(132, 53);
            this.btnMaxMoveX_M.Name = "btnMaxMoveX_M";
            this.btnMaxMoveX_M.Size = new System.Drawing.Size(59, 25);
            this.btnMaxMoveX_M.TabIndex = 0;
            this.btnMaxMoveX_M.TabStop = false;
            this.btnMaxMoveX_M.Text = "X -";
            this.btnMaxMoveX_M.UseVisualStyleBackColor = true;
            this.btnMaxMoveX_M.Click += new System.EventHandler(this.btnMaxMoveX_M_Click);
            // 
            // txtMoveMaxOffset
            // 
            this.txtMoveMaxOffset.Location = new System.Drawing.Point(46, 38);
            this.txtMoveMaxOffset.Name = "txtMoveMaxOffset";
            this.txtMoveMaxOffset.Size = new System.Drawing.Size(80, 21);
            this.txtMoveMaxOffset.TabIndex = 1;
            this.txtMoveMaxOffset.Text = "1000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 9F);
            this.label11.Location = new System.Drawing.Point(3, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "Offset";
            // 
            // btnMaxMoveY_M
            // 
            this.btnMaxMoveY_M.Location = new System.Drawing.Point(195, 53);
            this.btnMaxMoveY_M.Name = "btnMaxMoveY_M";
            this.btnMaxMoveY_M.Size = new System.Drawing.Size(59, 25);
            this.btnMaxMoveY_M.TabIndex = 0;
            this.btnMaxMoveY_M.TabStop = false;
            this.btnMaxMoveY_M.Text = "Y -";
            this.btnMaxMoveY_M.UseVisualStyleBackColor = true;
            this.btnMaxMoveY_M.Click += new System.EventHandler(this.btnMaxMoveY_M_Click);
            // 
            // btnMaxMoveZ_P
            // 
            this.btnMaxMoveZ_P.Location = new System.Drawing.Point(258, 22);
            this.btnMaxMoveZ_P.Name = "btnMaxMoveZ_P";
            this.btnMaxMoveZ_P.Size = new System.Drawing.Size(59, 25);
            this.btnMaxMoveZ_P.TabIndex = 0;
            this.btnMaxMoveZ_P.TabStop = false;
            this.btnMaxMoveZ_P.Text = "Z +";
            this.btnMaxMoveZ_P.UseVisualStyleBackColor = true;
            this.btnMaxMoveZ_P.Click += new System.EventHandler(this.btnMaxMoveZ_P_Click);
            // 
            // btnMaxMoveY_P
            // 
            this.btnMaxMoveY_P.Location = new System.Drawing.Point(195, 22);
            this.btnMaxMoveY_P.Name = "btnMaxMoveY_P";
            this.btnMaxMoveY_P.Size = new System.Drawing.Size(59, 25);
            this.btnMaxMoveY_P.TabIndex = 0;
            this.btnMaxMoveY_P.TabStop = false;
            this.btnMaxMoveY_P.Text = "Y +";
            this.btnMaxMoveY_P.UseVisualStyleBackColor = true;
            this.btnMaxMoveY_P.Click += new System.EventHandler(this.btnMaxMoveY_P_Click);
            // 
            // btnMaxMoveZ_M
            // 
            this.btnMaxMoveZ_M.Location = new System.Drawing.Point(259, 53);
            this.btnMaxMoveZ_M.Name = "btnMaxMoveZ_M";
            this.btnMaxMoveZ_M.Size = new System.Drawing.Size(59, 25);
            this.btnMaxMoveZ_M.TabIndex = 0;
            this.btnMaxMoveZ_M.TabStop = false;
            this.btnMaxMoveZ_M.Text = "Z -";
            this.btnMaxMoveZ_M.UseVisualStyleBackColor = true;
            this.btnMaxMoveZ_M.Click += new System.EventHandler(this.btnMaxMoveZ_M_Click);
            // 
            // btnMaxMoveX_P
            // 
            this.btnMaxMoveX_P.Location = new System.Drawing.Point(132, 22);
            this.btnMaxMoveX_P.Name = "btnMaxMoveX_P";
            this.btnMaxMoveX_P.Size = new System.Drawing.Size(59, 25);
            this.btnMaxMoveX_P.TabIndex = 0;
            this.btnMaxMoveX_P.TabStop = false;
            this.btnMaxMoveX_P.Text = "X +";
            this.btnMaxMoveX_P.UseVisualStyleBackColor = true;
            this.btnMaxMoveX_P.Click += new System.EventHandler(this.btnMaxMoveX_P_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnMinMoveX_M);
            this.groupBox8.Controls.Add(this.txtMoveMinOffset);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.btnMinMoveY_M);
            this.groupBox8.Controls.Add(this.btnMinMoveZ_P);
            this.groupBox8.Controls.Add(this.btnMinMoveY_P);
            this.groupBox8.Controls.Add(this.btnMinMoveZ_M);
            this.groupBox8.Controls.Add(this.btnMinMoveX_P);
            this.groupBox8.Location = new System.Drawing.Point(6, 20);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(328, 95);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Min";
            // 
            // btnMinMoveX_M
            // 
            this.btnMinMoveX_M.Location = new System.Drawing.Point(132, 53);
            this.btnMinMoveX_M.Name = "btnMinMoveX_M";
            this.btnMinMoveX_M.Size = new System.Drawing.Size(59, 25);
            this.btnMinMoveX_M.TabIndex = 0;
            this.btnMinMoveX_M.TabStop = false;
            this.btnMinMoveX_M.Text = "X -";
            this.btnMinMoveX_M.UseVisualStyleBackColor = true;
            this.btnMinMoveX_M.Click += new System.EventHandler(this.btnMinMoveX_M_Click);
            // 
            // txtMoveMinOffset
            // 
            this.txtMoveMinOffset.Location = new System.Drawing.Point(46, 38);
            this.txtMoveMinOffset.Name = "txtMoveMinOffset";
            this.txtMoveMinOffset.Size = new System.Drawing.Size(80, 21);
            this.txtMoveMinOffset.TabIndex = 1;
            this.txtMoveMinOffset.Text = "1000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9F);
            this.label6.Location = new System.Drawing.Point(3, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Offset";
            // 
            // btnMinMoveY_M
            // 
            this.btnMinMoveY_M.Location = new System.Drawing.Point(195, 53);
            this.btnMinMoveY_M.Name = "btnMinMoveY_M";
            this.btnMinMoveY_M.Size = new System.Drawing.Size(59, 25);
            this.btnMinMoveY_M.TabIndex = 0;
            this.btnMinMoveY_M.TabStop = false;
            this.btnMinMoveY_M.Text = "Y -";
            this.btnMinMoveY_M.UseVisualStyleBackColor = true;
            this.btnMinMoveY_M.Click += new System.EventHandler(this.btnMinMoveY_M_Click);
            // 
            // btnMinMoveZ_P
            // 
            this.btnMinMoveZ_P.Location = new System.Drawing.Point(258, 22);
            this.btnMinMoveZ_P.Name = "btnMinMoveZ_P";
            this.btnMinMoveZ_P.Size = new System.Drawing.Size(59, 25);
            this.btnMinMoveZ_P.TabIndex = 0;
            this.btnMinMoveZ_P.TabStop = false;
            this.btnMinMoveZ_P.Text = "Z +";
            this.btnMinMoveZ_P.UseVisualStyleBackColor = true;
            this.btnMinMoveZ_P.Click += new System.EventHandler(this.btnMinMoveZ_P_Click);
            // 
            // btnMinMoveY_P
            // 
            this.btnMinMoveY_P.Location = new System.Drawing.Point(195, 22);
            this.btnMinMoveY_P.Name = "btnMinMoveY_P";
            this.btnMinMoveY_P.Size = new System.Drawing.Size(59, 25);
            this.btnMinMoveY_P.TabIndex = 0;
            this.btnMinMoveY_P.TabStop = false;
            this.btnMinMoveY_P.Text = "Y +";
            this.btnMinMoveY_P.UseVisualStyleBackColor = true;
            this.btnMinMoveY_P.Click += new System.EventHandler(this.btnMinMoveY_P_Click);
            // 
            // btnMinMoveZ_M
            // 
            this.btnMinMoveZ_M.Location = new System.Drawing.Point(259, 53);
            this.btnMinMoveZ_M.Name = "btnMinMoveZ_M";
            this.btnMinMoveZ_M.Size = new System.Drawing.Size(59, 25);
            this.btnMinMoveZ_M.TabIndex = 0;
            this.btnMinMoveZ_M.TabStop = false;
            this.btnMinMoveZ_M.Text = "Z -";
            this.btnMinMoveZ_M.UseVisualStyleBackColor = true;
            this.btnMinMoveZ_M.Click += new System.EventHandler(this.btnMinMoveZ_M_Click);
            // 
            // btnMinMoveX_P
            // 
            this.btnMinMoveX_P.Location = new System.Drawing.Point(132, 22);
            this.btnMinMoveX_P.Name = "btnMinMoveX_P";
            this.btnMinMoveX_P.Size = new System.Drawing.Size(59, 25);
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
            this.groupBox3.Location = new System.Drawing.Point(6, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 207);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Size Control";
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.txtMaxZ);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.txtMaxY);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.btnMaxResize);
            this.groupBox7.Controls.Add(this.txtMaxX);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Location = new System.Drawing.Point(6, 109);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(328, 83);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Max";
            // 
            // txtMaxZ
            // 
            this.txtMaxZ.Location = new System.Drawing.Point(238, 25);
            this.txtMaxZ.Name = "txtMaxZ";
            this.txtMaxZ.Size = new System.Drawing.Size(80, 21);
            this.txtMaxZ.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9F);
            this.label8.Location = new System.Drawing.Point(219, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Z";
            // 
            // txtMaxY
            // 
            this.txtMaxY.Location = new System.Drawing.Point(130, 24);
            this.txtMaxY.Name = "txtMaxY";
            this.txtMaxY.Size = new System.Drawing.Size(80, 21);
            this.txtMaxY.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(113, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "Y";
            // 
            // btnMaxResize
            // 
            this.btnMaxResize.Location = new System.Drawing.Point(134, 51);
            this.btnMaxResize.Name = "btnMaxResize";
            this.btnMaxResize.Size = new System.Drawing.Size(74, 25);
            this.btnMaxResize.TabIndex = 0;
            this.btnMaxResize.TabStop = false;
            this.btnMaxResize.Text = "Resize";
            this.btnMaxResize.UseVisualStyleBackColor = true;
            this.btnMaxResize.Click += new System.EventHandler(this.btnMaxResize_Click);
            // 
            // txtMaxX
            // 
            this.txtMaxX.Location = new System.Drawing.Point(28, 24);
            this.txtMaxX.Name = "txtMaxX";
            this.txtMaxX.Size = new System.Drawing.Size(80, 21);
            this.txtMaxX.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 9F);
            this.label10.Location = new System.Drawing.Point(9, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "X";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtMinZ);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtMinY);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.btnMinResize);
            this.groupBox5.Controls.Add(this.txtMinX);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Location = new System.Drawing.Point(6, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(328, 83);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Min";
            // 
            // txtMinZ
            // 
            this.txtMinZ.Location = new System.Drawing.Point(238, 25);
            this.txtMinZ.Name = "txtMinZ";
            this.txtMinZ.Size = new System.Drawing.Size(80, 21);
            this.txtMinZ.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F);
            this.label4.Location = new System.Drawing.Point(219, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Z";
            // 
            // txtMinY
            // 
            this.txtMinY.Location = new System.Drawing.Point(130, 24);
            this.txtMinY.Name = "txtMinY";
            this.txtMinY.Size = new System.Drawing.Size(80, 21);
            this.txtMinY.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(113, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "Y";
            // 
            // btnMinResize
            // 
            this.btnMinResize.Location = new System.Drawing.Point(134, 51);
            this.btnMinResize.Name = "btnMinResize";
            this.btnMinResize.Size = new System.Drawing.Size(74, 25);
            this.btnMinResize.TabIndex = 0;
            this.btnMinResize.TabStop = false;
            this.btnMinResize.Text = "Resize";
            this.btnMinResize.UseVisualStyleBackColor = true;
            this.btnMinResize.Click += new System.EventHandler(this.btnMinResize_Click);
            // 
            // txtMinX
            // 
            this.txtMinX.Location = new System.Drawing.Point(28, 24);
            this.txtMinX.Name = "txtMinX";
            this.txtMinX.Size = new System.Drawing.Size(80, 21);
            this.txtMinX.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 9F);
            this.label7.Location = new System.Drawing.Point(9, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "X";
            // 
            // btnBoxShow
            // 
            this.btnBoxShow.Location = new System.Drawing.Point(179, 20);
            this.btnBoxShow.Name = "btnBoxShow";
            this.btnBoxShow.Size = new System.Drawing.Size(75, 25);
            this.btnBoxShow.TabIndex = 0;
            this.btnBoxShow.TabStop = false;
            this.btnBoxShow.Text = "Show";
            this.btnBoxShow.UseVisualStyleBackColor = true;
            this.btnBoxShow.Click += new System.EventHandler(this.btnBoxShow_Click);
            // 
            // btnBoxReset
            // 
            this.btnBoxReset.Location = new System.Drawing.Point(260, 20);
            this.btnBoxReset.Name = "btnBoxReset";
            this.btnBoxReset.Size = new System.Drawing.Size(75, 25);
            this.btnBoxReset.TabIndex = 0;
            this.btnBoxReset.TabStop = false;
            this.btnBoxReset.Text = "Reset";
            this.btnBoxReset.UseVisualStyleBackColor = true;
            this.btnBoxReset.Click += new System.EventHandler(this.btnBoxReset_Click);
            // 
            // btnBoxHide
            // 
            this.btnBoxHide.Location = new System.Drawing.Point(98, 20);
            this.btnBoxHide.Name = "btnBoxHide";
            this.btnBoxHide.Size = new System.Drawing.Size(75, 25);
            this.btnBoxHide.TabIndex = 0;
            this.btnBoxHide.TabStop = false;
            this.btnBoxHide.Text = "Hide";
            this.btnBoxHide.UseVisualStyleBackColor = true;
            this.btnBoxHide.Click += new System.EventHandler(this.btnBoxHide_Click);
            // 
            // btnAddBox
            // 
            this.btnAddBox.Location = new System.Drawing.Point(17, 20);
            this.btnAddBox.Name = "btnAddBox";
            this.btnAddBox.Size = new System.Drawing.Size(75, 25);
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
            this.groupBox1.Size = new System.Drawing.Size(352, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Open";
            // 
            // btnOpenModel
            // 
            this.btnOpenModel.Location = new System.Drawing.Point(17, 20);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(75, 23);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.TabStop = false;
            this.btnOpenModel.Text = "Model";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 742);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.SectionBoxControl";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.TextBox txtMinZ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMinY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMinResize;
        private System.Windows.Forms.TextBox txtMinX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtMaxZ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaxY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnMaxResize;
        private System.Windows.Forms.TextBox txtMaxX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnMaxMoveX_M;
        private System.Windows.Forms.TextBox txtMoveMaxOffset;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnMaxMoveY_M;
        private System.Windows.Forms.Button btnMaxMoveZ_P;
        private System.Windows.Forms.Button btnMaxMoveY_P;
        private System.Windows.Forms.Button btnMaxMoveZ_M;
        private System.Windows.Forms.Button btnMaxMoveX_P;
    }
}

