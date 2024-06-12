namespace VIZCore3DX.NET.Note
{
    partial class SurfaceNoteDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurfaceNoteDialog));
            this.txtText = new System.Windows.Forms.TextBox();
            this.ckUseSymbol = new System.Windows.Forms.CheckBox();
            this.txtSymbolText = new System.Windows.Forms.TextBox();
            this.btnSelectModel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbAssemblyNameLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Location = new System.Drawing.Point(16, 12);
            this.txtText.MaxLength = 127;
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(359, 185);
            this.txtText.TabIndex = 0;
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            // 
            // ckUseSymbol
            // 
            this.ckUseSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckUseSymbol.AutoSize = true;
            this.ckUseSymbol.Location = new System.Drawing.Point(16, 209);
            this.ckUseSymbol.Name = "ckUseSymbol";
            this.ckUseSymbol.Size = new System.Drawing.Size(100, 16);
            this.ckUseSymbol.TabIndex = 1;
            this.ckUseSymbol.Text = "원형심벌 사용";
            this.ckUseSymbol.UseVisualStyleBackColor = true;
            // 
            // txtSymbolText
            // 
            this.txtSymbolText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSymbolText.Location = new System.Drawing.Point(122, 207);
            this.txtSymbolText.Name = "txtSymbolText";
            this.txtSymbolText.Size = new System.Drawing.Size(50, 21);
            this.txtSymbolText.TabIndex = 2;
            // 
            // btnSelectModel
            // 
            this.btnSelectModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectModel.Location = new System.Drawing.Point(122, 271);
            this.btnSelectModel.Name = "btnSelectModel";
            this.btnSelectModel.Size = new System.Drawing.Size(75, 23);
            this.btnSelectModel.TabIndex = 4;
            this.btnSelectModel.Text = "모델 선택";
            this.btnSelectModel.UseVisualStyleBackColor = true;
            this.btnSelectModel.Click += new System.EventHandler(this.btnSelectModel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(219, 271);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(300, 271);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbAssemblyNameLevel
            // 
            this.cbAssemblyNameLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAssemblyNameLevel.FormattingEnabled = true;
            this.cbAssemblyNameLevel.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbAssemblyNameLevel.Location = new System.Drawing.Point(122, 233);
            this.cbAssemblyNameLevel.Name = "cbAssemblyNameLevel";
            this.cbAssemblyNameLevel.Size = new System.Drawing.Size(50, 20);
            this.cbAssemblyNameLevel.TabIndex = 7;
            this.cbAssemblyNameLevel.Text = "1";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "모델 이름 레벨";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "(0 : Part, 1 : Leaf Assembly, ...)";
            // 
            // lbLength
            // 
            this.lbLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLength.Location = new System.Drawing.Point(287, 204);
            this.lbLength.Name = "lbLength";
            this.lbLength.Size = new System.Drawing.Size(85, 21);
            this.lbLength.TabIndex = 10;
            this.lbLength.Text = "(0 / 127)";
            this.lbLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SurfaceNoteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(387, 306);
            this.Controls.Add(this.lbLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbAssemblyNameLevel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.btnSelectModel);
            this.Controls.Add(this.txtSymbolText);
            this.Controls.Add(this.ckUseSymbol);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SurfaceNoteDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "표면 노트";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.CheckBox ckUseSymbol;
        private System.Windows.Forms.TextBox txtSymbolText;
        private System.Windows.Forms.Button btnSelectModel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbAssemblyNameLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbLength;
    }
}