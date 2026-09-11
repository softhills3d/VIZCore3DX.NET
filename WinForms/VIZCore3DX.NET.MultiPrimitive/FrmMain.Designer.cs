namespace VIZCore3DX.NET.MultiPrimitive
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
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.lblPrimitiveType = new System.Windows.Forms.Label();
            this.cmbPrimitiveType = new System.Windows.Forms.ComboBox();
            this.lblNodeName = new System.Windows.Forms.Label();
            this.txtNodeName = new System.Windows.Forms.TextBox();
            this.chkCreateAssembly = new System.Windows.Forms.CheckBox();
            this.lblAxisAnchor = new System.Windows.Forms.Label();
            this.cmbAxisAnchor = new System.Windows.Forms.ComboBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.grpParameter = new System.Windows.Forms.GroupBox();
            this.lblValue1 = new System.Windows.Forms.Label();
            this.numValue1 = new System.Windows.Forms.NumericUpDown();
            this.lblValue2 = new System.Windows.Forms.Label();
            this.numValue2 = new System.Windows.Forms.NumericUpDown();
            this.lblValue3 = new System.Windows.Forms.Label();
            this.numValue3 = new System.Windows.Forms.NumericUpDown();
            this.lblGuide = new System.Windows.Forms.Label();
            this.grpPlacement = new System.Windows.Forms.GroupBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.numCount = new System.Windows.Forms.NumericUpDown();
            this.btnOsnap = new System.Windows.Forms.Button();
            this.lblMoveX = new System.Windows.Forms.Label();
            this.numMoveX = new System.Windows.Forms.NumericUpDown();
            this.lblMoveY = new System.Windows.Forms.Label();
            this.numMoveY = new System.Windows.Forms.NumericUpDown();
            this.lblMoveZ = new System.Windows.Forms.Label();
            this.numMoveZ = new System.Windows.Forms.NumericUpDown();
            this.lblIntervalX = new System.Windows.Forms.Label();
            this.numIntervalX = new System.Windows.Forms.NumericUpDown();
            this.lblIntervalY = new System.Windows.Forms.Label();
            this.numIntervalY = new System.Windows.Forms.NumericUpDown();
            this.lblIntervalZ = new System.Windows.Forms.Label();
            this.numIntervalZ = new System.Windows.Forms.NumericUpDown();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.grpParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue3)).BeginInit();
            this.grpPlacement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIntervalX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIntervalY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIntervalZ)).BeginInit();
            this.SuspendLayout();

            // splitContainer1
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel2.Controls.Add(this.grpMain);
            this.splitContainer1.Panel2.Controls.Add(this.grpParameter);
            this.splitContainer1.Panel2.Controls.Add(this.grpPlacement);
            this.splitContainer1.Panel2.Controls.Add(this.btnCreate);
            this.splitContainer1.Panel2.Controls.Add(this.lblResult);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 661);
            this.splitContainer1.SplitterDistance = 830;
            this.splitContainer1.TabIndex = 0;

            // grpMain
            this.grpMain.Location = new System.Drawing.Point(8, 8);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(326, 155);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "Multi Primitive";
            this.grpMain.Controls.Add(this.lblPrimitiveType);
            this.grpMain.Controls.Add(this.cmbPrimitiveType);
            this.grpMain.Controls.Add(this.lblNodeName);
            this.grpMain.Controls.Add(this.txtNodeName);
            this.grpMain.Controls.Add(this.chkCreateAssembly);
            this.grpMain.Controls.Add(this.lblAxisAnchor);
            this.grpMain.Controls.Add(this.cmbAxisAnchor);
            this.grpMain.Controls.Add(this.lblColor);
            this.grpMain.Controls.Add(this.btnColor);

            this.lblPrimitiveType.AutoSize = true;
            this.lblPrimitiveType.Location = new System.Drawing.Point(12, 28);
            this.lblPrimitiveType.Name = "lblPrimitiveType";
            this.lblPrimitiveType.Size = new System.Drawing.Size(29, 12);
            this.lblPrimitiveType.TabIndex = 0;
            this.lblPrimitiveType.Text = "종류";
            // cmbPrimitiveType
            this.cmbPrimitiveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrimitiveType.FormattingEnabled = true;
            this.cmbPrimitiveType.Items.AddRange(new object[] { "Box", "Cone", "Cylinder", "Mesh", "Pyramid", "RectangularTorus", "Sphere", "SphericalCap", "Torus" });
            this.cmbPrimitiveType.Location = new System.Drawing.Point(90, 24);
            this.cmbPrimitiveType.Name = "cmbPrimitiveType";
            this.cmbPrimitiveType.Size = new System.Drawing.Size(220, 20);
            this.cmbPrimitiveType.TabIndex = 1;
            this.cmbPrimitiveType.SelectedIndexChanged += new System.EventHandler(this.cmbPrimitiveType_SelectedIndexChanged);

            this.lblNodeName.AutoSize = true;
            this.lblNodeName.Location = new System.Drawing.Point(12, 62);
            this.lblNodeName.Name = "lblNodeName";
            this.lblNodeName.Size = new System.Drawing.Size(57, 12);
            this.lblNodeName.TabIndex = 2;
            this.lblNodeName.Text = "노드 이름";
            // txtNodeName
            this.txtNodeName.Location = new System.Drawing.Point(90, 58);
            this.txtNodeName.Name = "txtNodeName";
            this.txtNodeName.Size = new System.Drawing.Size(220, 21);
            this.txtNodeName.TabIndex = 3;
            this.txtNodeName.Text = "Multi Primitive Box";

            // chkCreateAssembly
            this.chkCreateAssembly.AutoSize = true;
            this.chkCreateAssembly.Checked = true;
            this.chkCreateAssembly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreateAssembly.Location = new System.Drawing.Point(90, 91);
            this.chkCreateAssembly.Name = "chkCreateAssembly";
            this.chkCreateAssembly.Size = new System.Drawing.Size(108, 16);
            this.chkCreateAssembly.TabIndex = 4;
            this.chkCreateAssembly.Text = "Assembly 생성";
            this.chkCreateAssembly.UseVisualStyleBackColor = true;

            this.lblAxisAnchor.AutoSize = true;
            this.lblAxisAnchor.Location = new System.Drawing.Point(12, 129);
            this.lblAxisAnchor.Name = "lblAxisAnchor";
            this.lblAxisAnchor.Size = new System.Drawing.Size(69, 12);
            this.lblAxisAnchor.TabIndex = 5;
            this.lblAxisAnchor.Text = "Axis Anchor";
            // cmbAxisAnchor
            this.cmbAxisAnchor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAxisAnchor.FormattingEnabled = true;
            this.cmbAxisAnchor.Items.AddRange(new object[] {
            VIZCore3DX.NET.Data.AxisAnchor.Min,
            VIZCore3DX.NET.Data.AxisAnchor.Center,
            VIZCore3DX.NET.Data.AxisAnchor.Max});
            this.cmbAxisAnchor.Location = new System.Drawing.Point(90, 125);
            this.cmbAxisAnchor.Name = "cmbAxisAnchor";
            this.cmbAxisAnchor.Size = new System.Drawing.Size(100, 20);
            this.cmbAxisAnchor.TabIndex = 6;
            this.cmbAxisAnchor.SelectedIndex = 0;

            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(205, 129);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(29, 12);
            this.lblColor.TabIndex = 7;
            this.lblColor.Text = "색상";
            // btnColor
            this.btnColor.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Location = new System.Drawing.Point(250, 122);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(60, 27);
            this.btnColor.TabIndex = 8;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);

            // grpParameter
            this.grpParameter.Location = new System.Drawing.Point(8, 171);
            this.grpParameter.Name = "grpParameter";
            this.grpParameter.Size = new System.Drawing.Size(326, 170);
            this.grpParameter.TabIndex = 1;
            this.grpParameter.TabStop = false;
            this.grpParameter.Text = "형상 파라미터";
            this.grpParameter.Controls.Add(this.lblValue1);
            this.grpParameter.Controls.Add(this.numValue1);
            this.grpParameter.Controls.Add(this.lblValue2);
            this.grpParameter.Controls.Add(this.numValue2);
            this.grpParameter.Controls.Add(this.lblValue3);
            this.grpParameter.Controls.Add(this.numValue3);
            this.grpParameter.Controls.Add(this.lblGuide);

            this.lblValue1.AutoSize = true;
            this.lblValue1.Location = new System.Drawing.Point(12, 30);
            this.lblValue1.Name = "lblValue1";
            this.lblValue1.Size = new System.Drawing.Size(38, 12);
            this.lblValue1.TabIndex = 0;
            this.lblValue1.Text = "Size X";
            // numValue1
            this.numValue1.DecimalPlaces = 1;
            this.numValue1.Location = new System.Drawing.Point(120, 26);
            this.numValue1.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numValue1.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numValue1.Name = "numValue1";
            this.numValue1.Size = new System.Drawing.Size(190, 21);
            this.numValue1.TabIndex = 1;
            this.numValue1.Value = new decimal(new int[] { 1000, 0, 0, 0 });

            this.lblValue2.AutoSize = true;
            this.lblValue2.Location = new System.Drawing.Point(12, 62);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(38, 12);
            this.lblValue2.TabIndex = 2;
            this.lblValue2.Text = "Size Y";
            // numValue2
            this.numValue2.DecimalPlaces = 1;
            this.numValue2.Location = new System.Drawing.Point(120, 58);
            this.numValue2.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numValue2.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numValue2.Name = "numValue2";
            this.numValue2.Size = new System.Drawing.Size(190, 21);
            this.numValue2.TabIndex = 3;
            this.numValue2.Value = new decimal(new int[] { 1000, 0, 0, 0 });

            this.lblValue3.AutoSize = true;
            this.lblValue3.Location = new System.Drawing.Point(12, 94);
            this.lblValue3.Name = "lblValue3";
            this.lblValue3.Size = new System.Drawing.Size(38, 12);
            this.lblValue3.TabIndex = 4;
            this.lblValue3.Text = "Size Z";
            // numValue3
            this.numValue3.DecimalPlaces = 1;
            this.numValue3.Location = new System.Drawing.Point(120, 90);
            this.numValue3.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numValue3.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numValue3.Name = "numValue3";
            this.numValue3.Size = new System.Drawing.Size(190, 21);
            this.numValue3.TabIndex = 5;
            this.numValue3.Value = new decimal(new int[] { 1000, 0, 0, 0 });

            // lblGuide
            this.lblGuide.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblGuide.Location = new System.Drawing.Point(12, 126);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(298, 32);
            this.lblGuide.TabIndex = 6;
            this.lblGuide.Text = "API : AddMultiPrimitiveBox";

            // grpPlacement
            this.grpPlacement.Location = new System.Drawing.Point(8, 349);
            this.grpPlacement.Name = "grpPlacement";
            this.grpPlacement.Size = new System.Drawing.Size(326, 180);
            this.grpPlacement.TabIndex = 2;
            this.grpPlacement.TabStop = false;
            this.grpPlacement.Text = "배치";

            this.grpPlacement.Controls.Add(this.lblCount);
            this.grpPlacement.Controls.Add(this.numCount);
            this.grpPlacement.Controls.Add(this.btnOsnap);
            this.grpPlacement.Controls.Add(this.lblMoveX);
            this.grpPlacement.Controls.Add(this.numMoveX);
            this.grpPlacement.Controls.Add(this.lblMoveY);
            this.grpPlacement.Controls.Add(this.numMoveY);
            this.grpPlacement.Controls.Add(this.lblMoveZ);
            this.grpPlacement.Controls.Add(this.numMoveZ);
            this.grpPlacement.Controls.Add(this.lblIntervalX);
            this.grpPlacement.Controls.Add(this.numIntervalX);
            this.grpPlacement.Controls.Add(this.lblIntervalY);
            this.grpPlacement.Controls.Add(this.numIntervalY);
            this.grpPlacement.Controls.Add(this.lblIntervalZ);
            this.grpPlacement.Controls.Add(this.numIntervalZ);

            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(12, 30);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(29, 12);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "개수";
            // numCount
            this.numCount.Location = new System.Drawing.Point(90, 26);
            this.numCount.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            this.numCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(100, 21);
            this.numCount.TabIndex = 1;
            this.numCount.Value = new decimal(new int[] { 3, 0, 0, 0 });

            // btnOsnap
            this.btnOsnap.Location = new System.Drawing.Point(205, 24);
            this.btnOsnap.Name = "btnOsnap";
            this.btnOsnap.Size = new System.Drawing.Size(105, 25);
            this.btnOsnap.TabIndex = 2;
            this.btnOsnap.Text = "Osnap 위치";
            this.btnOsnap.UseVisualStyleBackColor = true;
            this.btnOsnap.Click += new System.EventHandler(this.btnOsnap_Click);

            // lblMoveX
            this.lblMoveX.AutoSize = true;
            this.lblMoveX.Location = new System.Drawing.Point(12, 68);
            this.lblMoveX.Name = "lblMoveX";
            this.lblMoveX.Size = new System.Drawing.Size(42, 12);
            this.lblMoveX.TabIndex = 2;
            this.lblMoveX.Text = "Move X";
            // numMoveX
            this.numMoveX.DecimalPlaces = 1;
            this.numMoveX.Location = new System.Drawing.Point(12, 85);
            this.numMoveX.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numMoveX.Minimum = new decimal(new int[] { 10000000, 0, 0, -2147483648 });
            this.numMoveX.Name = "numMoveX";
            this.numMoveX.Size = new System.Drawing.Size(95, 21);
            this.numMoveX.TabIndex = 3;

            // lblMoveY
            this.lblMoveY.AutoSize = true;
            this.lblMoveY.Location = new System.Drawing.Point(121, 68);
            this.lblMoveY.Name = "lblMoveY";
            this.lblMoveY.Size = new System.Drawing.Size(42, 12);
            this.lblMoveY.TabIndex = 4;
            this.lblMoveY.Text = "Move Y";
            // numMoveY
            this.numMoveY.DecimalPlaces = 1;
            this.numMoveY.Location = new System.Drawing.Point(121, 85);
            this.numMoveY.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numMoveY.Minimum = new decimal(new int[] { 10000000, 0, 0, -2147483648 });
            this.numMoveY.Name = "numMoveY";
            this.numMoveY.Size = new System.Drawing.Size(95, 21);
            this.numMoveY.TabIndex = 5;

            // lblMoveZ
            this.lblMoveZ.AutoSize = true;
            this.lblMoveZ.Location = new System.Drawing.Point(230, 68);
            this.lblMoveZ.Name = "lblMoveZ";
            this.lblMoveZ.Size = new System.Drawing.Size(42, 12);
            this.lblMoveZ.TabIndex = 6;
            this.lblMoveZ.Text = "Move Z";
            // numMoveZ
            this.numMoveZ.DecimalPlaces = 1;
            this.numMoveZ.Location = new System.Drawing.Point(230, 85);
            this.numMoveZ.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numMoveZ.Minimum = new decimal(new int[] { 10000000, 0, 0, -2147483648 });
            this.numMoveZ.Name = "numMoveZ";
            this.numMoveZ.Size = new System.Drawing.Size(80, 21);
            this.numMoveZ.TabIndex = 7;

            // lblIntervalX
            this.lblIntervalX.AutoSize = true;
            this.lblIntervalX.Location = new System.Drawing.Point(12, 121);
            this.lblIntervalX.Name = "lblIntervalX";
            this.lblIntervalX.Size = new System.Drawing.Size(54, 12);
            this.lblIntervalX.TabIndex = 8;
            this.lblIntervalX.Text = "Interval X";
            // numIntervalX
            this.numIntervalX.DecimalPlaces = 1;
            this.numIntervalX.Location = new System.Drawing.Point(12, 138);
            this.numIntervalX.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numIntervalX.Minimum = new decimal(new int[] { 10000000, 0, 0, -2147483648 });
            this.numIntervalX.Name = "numIntervalX";
            this.numIntervalX.Size = new System.Drawing.Size(95, 21);
            this.numIntervalX.TabIndex = 9;
            this.numIntervalX.Value = new decimal(new int[] { 2000, 0, 0, 0 });

            // lblIntervalY
            this.lblIntervalY.AutoSize = true;
            this.lblIntervalY.Location = new System.Drawing.Point(121, 121);
            this.lblIntervalY.Name = "lblIntervalY";
            this.lblIntervalY.Size = new System.Drawing.Size(54, 12);
            this.lblIntervalY.TabIndex = 10;
            this.lblIntervalY.Text = "Interval Y";
            // numIntervalY
            this.numIntervalY.DecimalPlaces = 1;
            this.numIntervalY.Location = new System.Drawing.Point(121, 138);
            this.numIntervalY.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numIntervalY.Minimum = new decimal(new int[] { 10000000, 0, 0, -2147483648 });
            this.numIntervalY.Name = "numIntervalY";
            this.numIntervalY.Size = new System.Drawing.Size(95, 21);
            this.numIntervalY.TabIndex = 11;

            // lblIntervalZ
            this.lblIntervalZ.AutoSize = true;
            this.lblIntervalZ.Location = new System.Drawing.Point(230, 121);
            this.lblIntervalZ.Name = "lblIntervalZ";
            this.lblIntervalZ.Size = new System.Drawing.Size(54, 12);
            this.lblIntervalZ.TabIndex = 12;
            this.lblIntervalZ.Text = "Interval Z";
            // numIntervalZ
            this.numIntervalZ.DecimalPlaces = 1;
            this.numIntervalZ.Location = new System.Drawing.Point(230, 138);
            this.numIntervalZ.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numIntervalZ.Minimum = new decimal(new int[] { 10000000, 0, 0, -2147483648 });
            this.numIntervalZ.Name = "numIntervalZ";
            this.numIntervalZ.Size = new System.Drawing.Size(80, 21);
            this.numIntervalZ.TabIndex = 13;

            // btnCreate
            this.btnCreate.Location = new System.Drawing.Point(8, 539);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(326, 38);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Multi Primitive 생성";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);

            // lblResult
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(10, 592);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(81, 12);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "생성 결과 : -";

            // FrmMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.MultiPrimitive";
            this.cmbPrimitiveType.SelectedIndex = 0;
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.grpParameter.ResumeLayout(false);
            this.grpParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValue3)).EndInit();
            this.grpPlacement.ResumeLayout(false);
            this.grpPlacement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIntervalX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIntervalY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIntervalZ)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Label lblPrimitiveType;
        private System.Windows.Forms.ComboBox cmbPrimitiveType;
        private System.Windows.Forms.Label lblNodeName;
        private System.Windows.Forms.TextBox txtNodeName;
        private System.Windows.Forms.CheckBox chkCreateAssembly;
        private System.Windows.Forms.Label lblAxisAnchor;
        private System.Windows.Forms.ComboBox cmbAxisAnchor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.GroupBox grpParameter;
        private System.Windows.Forms.Label lblValue1;
        private System.Windows.Forms.NumericUpDown numValue1;
        private System.Windows.Forms.Label lblValue2;
        private System.Windows.Forms.NumericUpDown numValue2;
        private System.Windows.Forms.Label lblValue3;
        private System.Windows.Forms.NumericUpDown numValue3;
        private System.Windows.Forms.Label lblGuide;
        private System.Windows.Forms.GroupBox grpPlacement;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.NumericUpDown numCount;
        private System.Windows.Forms.Button btnOsnap;
        private System.Windows.Forms.Label lblMoveX;
        private System.Windows.Forms.NumericUpDown numMoveX;
        private System.Windows.Forms.Label lblMoveY;
        private System.Windows.Forms.NumericUpDown numMoveY;
        private System.Windows.Forms.Label lblMoveZ;
        private System.Windows.Forms.NumericUpDown numMoveZ;
        private System.Windows.Forms.Label lblIntervalX;
        private System.Windows.Forms.NumericUpDown numIntervalX;
        private System.Windows.Forms.Label lblIntervalY;
        private System.Windows.Forms.NumericUpDown numIntervalY;
        private System.Windows.Forms.Label lblIntervalZ;
        private System.Windows.Forms.NumericUpDown numIntervalZ;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblResult;
    }
}
