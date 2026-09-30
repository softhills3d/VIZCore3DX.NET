namespace VIZCore3DX.NET.ExportNode
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
            this.groupExportObj = new System.Windows.Forms.GroupBox();
            this.btnExportObj = new System.Windows.Forms.Button();
            this.lblMtlPathInfo = new System.Windows.Forms.Label();
            this.btnMtlPath = new System.Windows.Forms.Button();
            this.txtMtlPath = new System.Windows.Forms.TextBox();
            this.lblMtlPath = new System.Windows.Forms.Label();
            this.chkObjSelectedOnly = new System.Windows.Forms.CheckBox();
            this.chkIncludeGroups = new System.Windows.Forms.CheckBox();
            this.chkIncludeNormals = new System.Windows.Forms.CheckBox();
            this.cmbMaterialGrouping = new System.Windows.Forms.ComboBox();
            this.lblMaterialGrouping = new System.Windows.Forms.Label();
            this.cmbVertexColor = new System.Windows.Forms.ComboBox();
            this.lblVertexColor = new System.Windows.Forms.Label();
            this.chkKeepAncestors = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckByNode = new System.Windows.Forms.CheckBox();
            this.rbSelectedNode = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupExportObj.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupExportObj);
            this.splitContainer1.Panel1.Controls.Add(this.btnExport);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(1280, 760);
            this.splitContainer1.SplitterDistance = 418;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupExportObj
            // 
            this.groupExportObj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupExportObj.Controls.Add(this.btnExportObj);
            this.groupExportObj.Controls.Add(this.lblMtlPathInfo);
            this.groupExportObj.Controls.Add(this.btnMtlPath);
            this.groupExportObj.Controls.Add(this.txtMtlPath);
            this.groupExportObj.Controls.Add(this.lblMtlPath);
            this.groupExportObj.Controls.Add(this.chkObjSelectedOnly);
            this.groupExportObj.Controls.Add(this.chkIncludeGroups);
            this.groupExportObj.Controls.Add(this.chkIncludeNormals);
            this.groupExportObj.Controls.Add(this.cmbMaterialGrouping);
            this.groupExportObj.Controls.Add(this.lblMaterialGrouping);
            this.groupExportObj.Controls.Add(this.cmbVertexColor);
            this.groupExportObj.Controls.Add(this.lblVertexColor);
            this.groupExportObj.Location = new System.Drawing.Point(12, 216);
            this.groupExportObj.Name = "groupExportObj";
            this.groupExportObj.Size = new System.Drawing.Size(394, 196);
            this.groupExportObj.TabIndex = 4;
            this.groupExportObj.TabStop = false;
            this.groupExportObj.Text = "OBJ 내보내기 (ObjExportOption)";
            // 
            // btnExportObj
            // 
            this.btnExportObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportObj.Location = new System.Drawing.Point(262, 158);
            this.btnExportObj.Name = "btnExportObj";
            this.btnExportObj.Size = new System.Drawing.Size(120, 28);
            this.btnExportObj.TabIndex = 11;
            this.btnExportObj.Text = "OBJ 내보내기";
            this.btnExportObj.UseVisualStyleBackColor = true;
            this.btnExportObj.Click += new System.EventHandler(this.btnExportObj_Click);
            // 
            // lblMtlPathInfo
            // 
            this.lblMtlPathInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMtlPathInfo.AutoEllipsis = true;
            this.lblMtlPathInfo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblMtlPathInfo.Location = new System.Drawing.Point(12, 136);
            this.lblMtlPathInfo.Name = "lblMtlPathInfo";
            this.lblMtlPathInfo.Size = new System.Drawing.Size(370, 16);
            this.lblMtlPathInfo.TabIndex = 10;
            this.lblMtlPathInfo.Text = "비워 두면 OBJ와 같은 이름의 .mtl로 저장";
            // 
            // btnMtlPath
            // 
            this.btnMtlPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMtlPath.Location = new System.Drawing.Point(307, 106);
            this.btnMtlPath.Name = "btnMtlPath";
            this.btnMtlPath.Size = new System.Drawing.Size(75, 23);
            this.btnMtlPath.TabIndex = 9;
            this.btnMtlPath.Text = "Select";
            this.btnMtlPath.UseVisualStyleBackColor = true;
            this.btnMtlPath.Click += new System.EventHandler(this.btnMtlPath_Click);
            // 
            // txtMtlPath
            // 
            this.txtMtlPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMtlPath.Location = new System.Drawing.Point(120, 107);
            this.txtMtlPath.Name = "txtMtlPath";
            this.txtMtlPath.Size = new System.Drawing.Size(181, 21);
            this.txtMtlPath.TabIndex = 8;
            // 
            // lblMtlPath
            // 
            this.lblMtlPath.AutoSize = true;
            this.lblMtlPath.Location = new System.Drawing.Point(15, 111);
            this.lblMtlPath.Name = "lblMtlPath";
            this.lblMtlPath.Size = new System.Drawing.Size(57, 12);
            this.lblMtlPath.TabIndex = 7;
            this.lblMtlPath.Text = "MTL 경로";
            // 
            // chkObjSelectedOnly
            // 
            this.chkObjSelectedOnly.AutoSize = true;
            this.chkObjSelectedOnly.Location = new System.Drawing.Point(255, 80);
            this.chkObjSelectedOnly.Name = "chkObjSelectedOnly";
            this.chkObjSelectedOnly.Size = new System.Drawing.Size(88, 16);
            this.chkObjSelectedOnly.TabIndex = 6;
            this.chkObjSelectedOnly.Text = "선택 노드만";
            this.chkObjSelectedOnly.UseVisualStyleBackColor = true;
            // 
            // chkIncludeGroups
            // 
            this.chkIncludeGroups.AutoSize = true;
            this.chkIncludeGroups.Location = new System.Drawing.Point(135, 80);
            this.chkIncludeGroups.Name = "chkIncludeGroups";
            this.chkIncludeGroups.Size = new System.Drawing.Size(76, 16);
            this.chkIncludeGroups.TabIndex = 5;
            this.chkIncludeGroups.Text = "그룹 포함";
            this.chkIncludeGroups.UseVisualStyleBackColor = true;
            // 
            // chkIncludeNormals
            // 
            this.chkIncludeNormals.AutoSize = true;
            this.chkIncludeNormals.Location = new System.Drawing.Point(15, 80);
            this.chkIncludeNormals.Name = "chkIncludeNormals";
            this.chkIncludeNormals.Size = new System.Drawing.Size(76, 16);
            this.chkIncludeNormals.TabIndex = 4;
            this.chkIncludeNormals.Text = "노멀 포함";
            this.chkIncludeNormals.UseVisualStyleBackColor = true;
            // 
            // cmbMaterialGrouping
            // 
            this.cmbMaterialGrouping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMaterialGrouping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterialGrouping.FormattingEnabled = true;
            this.cmbMaterialGrouping.Location = new System.Drawing.Point(120, 50);
            this.cmbMaterialGrouping.Name = "cmbMaterialGrouping";
            this.cmbMaterialGrouping.Size = new System.Drawing.Size(262, 20);
            this.cmbMaterialGrouping.TabIndex = 3;
            // 
            // lblMaterialGrouping
            // 
            this.lblMaterialGrouping.AutoSize = true;
            this.lblMaterialGrouping.Location = new System.Drawing.Point(15, 54);
            this.lblMaterialGrouping.Name = "lblMaterialGrouping";
            this.lblMaterialGrouping.Size = new System.Drawing.Size(81, 12);
            this.lblMaterialGrouping.TabIndex = 2;
            this.lblMaterialGrouping.Text = "재질 그룹 단위";
            // 
            // cmbVertexColor
            // 
            this.cmbVertexColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVertexColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVertexColor.FormattingEnabled = true;
            this.cmbVertexColor.Location = new System.Drawing.Point(120, 22);
            this.cmbVertexColor.Name = "cmbVertexColor";
            this.cmbVertexColor.Size = new System.Drawing.Size(262, 20);
            this.cmbVertexColor.TabIndex = 1;
            // 
            // lblVertexColor
            // 
            this.lblVertexColor.AutoSize = true;
            this.lblVertexColor.Location = new System.Drawing.Point(15, 26);
            this.lblVertexColor.Name = "lblVertexColor";
            this.lblVertexColor.Size = new System.Drawing.Size(81, 12);
            this.lblVertexColor.TabIndex = 0;
            this.lblVertexColor.Text = "정점 색상 방식";
            // 
            // chkKeepAncestors
            // 
            this.chkKeepAncestors.AutoSize = true;
            this.chkKeepAncestors.Checked = true;
            this.chkKeepAncestors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepAncestors.Location = new System.Drawing.Point(120, 66);
            this.chkKeepAncestors.Name = "chkKeepAncestors";
            this.chkKeepAncestors.Size = new System.Drawing.Size(104, 16);
            this.chkKeepAncestors.TabIndex = 3;
            this.chkKeepAncestors.Text = "상위 경로 유지";
            this.chkKeepAncestors.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(12, 178);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(394, 30);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnPath);
            this.groupBox3.Controls.Add(this.txtPath);
            this.groupBox3.Location = new System.Drawing.Point(12, 112);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(394, 58);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dest";
            // 
            // btnPath
            // 
            this.btnPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPath.Location = new System.Drawing.Point(307, 23);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(75, 23);
            this.btnPath.TabIndex = 1;
            this.btnPath.Text = "Select";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(12, 24);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(289, 21);
            this.txtPath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkKeepAncestors);
            this.groupBox2.Controls.Add(this.ckByNode);
            this.groupBox2.Controls.Add(this.rbSelectedNode);
            this.groupBox2.Controls.Add(this.rbAll);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 92);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Source";
            // 
            // ckByNode
            // 
            this.ckByNode.AutoSize = true;
            this.ckByNode.Location = new System.Drawing.Point(15, 66);
            this.ckByNode.Name = "ckByNode";
            this.ckByNode.Size = new System.Drawing.Size(73, 16);
            this.ckByNode.TabIndex = 2;
            this.ckByNode.Text = "By Node";
            this.ckByNode.UseVisualStyleBackColor = true;
            // 
            // rbSelectedNode
            // 
            this.rbSelectedNode.AutoSize = true;
            this.rbSelectedNode.Location = new System.Drawing.Point(15, 44);
            this.rbSelectedNode.Name = "rbSelectedNode";
            this.rbSelectedNode.Size = new System.Drawing.Size(106, 16);
            this.rbSelectedNode.TabIndex = 1;
            this.rbSelectedNode.Text = "Selected Node";
            this.rbSelectedNode.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(15, 22);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(71, 16);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All Node";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.ExportNode";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupExportObj.ResumeLayout(false);
            this.groupExportObj.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckByNode;
        private System.Windows.Forms.RadioButton rbSelectedNode;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox chkKeepAncestors;
        private System.Windows.Forms.GroupBox groupExportObj;
        private System.Windows.Forms.Label lblVertexColor;
        private System.Windows.Forms.ComboBox cmbVertexColor;
        private System.Windows.Forms.Label lblMaterialGrouping;
        private System.Windows.Forms.ComboBox cmbMaterialGrouping;
        private System.Windows.Forms.CheckBox chkIncludeNormals;
        private System.Windows.Forms.CheckBox chkIncludeGroups;
        private System.Windows.Forms.CheckBox chkObjSelectedOnly;
        private System.Windows.Forms.Label lblMtlPath;
        private System.Windows.Forms.TextBox txtMtlPath;
        private System.Windows.Forms.Button btnMtlPath;
        private System.Windows.Forms.Label lblMtlPathInfo;
        private System.Windows.Forms.Button btnExportObj;
    }
}

