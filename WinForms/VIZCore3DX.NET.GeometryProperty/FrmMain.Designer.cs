namespace VIZCore3DX.NET.GeometryProperty
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
            this.splitContainerProperty = new System.Windows.Forms.SplitContainer();
            this.grpReturnType = new System.Windows.Forms.GroupBox();
            this.rdoGetGeometry = new System.Windows.Forms.RadioButton();
            this.rdoGetCenterOfVolume = new System.Windows.Forms.RadioButton();
            this.rdoGetVolume = new System.Windows.Forms.RadioButton();
            this.rdoGetSurfaceArea = new System.Windows.Forms.RadioButton();
            this.rdoFromSelectedObject3D = new System.Windows.Forms.RadioButton();
            this.geometryPropertyGrid = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerProperty)).BeginInit();
            this.splitContainerProperty.Panel1.SuspendLayout();
            this.splitContainerProperty.Panel2.SuspendLayout();
            this.splitContainerProperty.SuspendLayout();
            this.grpReturnType.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.splitContainerProperty);
            this.splitContainer1.Size = new System.Drawing.Size(1088, 632);
            this.splitContainer1.SplitterDistance = 811;
            this.splitContainer1.TabIndex = 0;

            // 
            // splitContainerProperty
            // 
            this.splitContainerProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerProperty.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerProperty.Location = new System.Drawing.Point(0, 0);
            this.splitContainerProperty.Name = "splitContainerProperty";
            this.splitContainerProperty.Orientation = System.Windows.Forms.Orientation.Horizontal;

            // 
            // splitContainerProperty.Panel1
            // 
            this.splitContainerProperty.Panel1.Controls.Add(this.grpReturnType);

            // 
            // splitContainerProperty.Panel2
            // 
            this.splitContainerProperty.Panel2.Controls.Add(this.geometryPropertyGrid);
            this.splitContainerProperty.Size = new System.Drawing.Size(273, 632);
            this.splitContainerProperty.SplitterDistance = 125;
            this.splitContainerProperty.TabIndex = 0;

            // 
            // grpReturnType
            // 
            this.grpReturnType.Controls.Add(this.rdoGetGeometry);
            this.grpReturnType.Controls.Add(this.rdoGetCenterOfVolume);
            this.grpReturnType.Controls.Add(this.rdoGetVolume);
            this.grpReturnType.Controls.Add(this.rdoGetSurfaceArea);
            this.grpReturnType.Controls.Add(this.rdoFromSelectedObject3D);
            this.grpReturnType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReturnType.Location = new System.Drawing.Point(0, 0);
            this.grpReturnType.Name = "grpReturnType";
            this.grpReturnType.Padding = new System.Windows.Forms.Padding(8);
            this.grpReturnType.Size = new System.Drawing.Size(273, 125);
            this.grpReturnType.TabIndex = 0;
            this.grpReturnType.TabStop = false;
            this.grpReturnType.Text = "Geometry Property";

            // 
            // rdoFromSelectedObject3D
            // 
            this.rdoFromSelectedObject3D.AutoSize = true;
            this.rdoFromSelectedObject3D.Checked = true;
            this.rdoFromSelectedObject3D.Location = new System.Drawing.Point(12, 22);
            this.rdoFromSelectedObject3D.Name = "rdoFromSelectedObject3D";
            this.rdoFromSelectedObject3D.Size = new System.Drawing.Size(154, 16);
            this.rdoFromSelectedObject3D.TabIndex = 0;
            this.rdoFromSelectedObject3D.TabStop = true;
            this.rdoFromSelectedObject3D.Text = "FromSelectedObject3D";
            this.rdoFromSelectedObject3D.UseVisualStyleBackColor = true;
            this.rdoFromSelectedObject3D.CheckedChanged += new System.EventHandler(this.GeometryReturnType_CheckedChanged);

            // 
            // rdoGetSurfaceArea
            // 
            this.rdoGetSurfaceArea.AutoSize = true;
            this.rdoGetSurfaceArea.Location = new System.Drawing.Point(12, 46);
            this.rdoGetSurfaceArea.Name = "rdoGetSurfaceArea";
            this.rdoGetSurfaceArea.Size = new System.Drawing.Size(111, 16);
            this.rdoGetSurfaceArea.TabIndex = 1;
            this.rdoGetSurfaceArea.Text = "GetSurfaceArea";
            this.rdoGetSurfaceArea.UseVisualStyleBackColor = true;
            this.rdoGetSurfaceArea.CheckedChanged += new System.EventHandler(this.GeometryReturnType_CheckedChanged);

            // 
            // rdoGetVolume
            // 
            this.rdoGetVolume.AutoSize = true;
            this.rdoGetVolume.Location = new System.Drawing.Point(143, 46);
            this.rdoGetVolume.Name = "rdoGetVolume";
            this.rdoGetVolume.Size = new System.Drawing.Size(84, 16);
            this.rdoGetVolume.TabIndex = 2;
            this.rdoGetVolume.Text = "GetVolume";
            this.rdoGetVolume.UseVisualStyleBackColor = true;
            this.rdoGetVolume.CheckedChanged += new System.EventHandler(this.GeometryReturnType_CheckedChanged);

            // 
            // rdoGetCenterOfVolume
            // 
            this.rdoGetCenterOfVolume.AutoSize = true;
            this.rdoGetCenterOfVolume.Location = new System.Drawing.Point(12, 70);
            this.rdoGetCenterOfVolume.Name = "rdoGetCenterOfVolume";
            this.rdoGetCenterOfVolume.Size = new System.Drawing.Size(133, 16);
            this.rdoGetCenterOfVolume.TabIndex = 3;
            this.rdoGetCenterOfVolume.Text = "GetCenterOfVolume";
            this.rdoGetCenterOfVolume.UseVisualStyleBackColor = true;
            this.rdoGetCenterOfVolume.CheckedChanged += new System.EventHandler(this.GeometryReturnType_CheckedChanged);

            // 
            // rdoGetGeometry
            // 
            this.rdoGetGeometry.AutoSize = true;
            this.rdoGetGeometry.Location = new System.Drawing.Point(12, 94);
            this.rdoGetGeometry.Name = "rdoGetGeometry";
            this.rdoGetGeometry.Size = new System.Drawing.Size(94, 16);
            this.rdoGetGeometry.TabIndex = 4;
            this.rdoGetGeometry.Text = "GetGeometry";
            this.rdoGetGeometry.UseVisualStyleBackColor = true;
            this.rdoGetGeometry.CheckedChanged += new System.EventHandler(this.GeometryReturnType_CheckedChanged);

            // 
            // geometryPropertyGrid
            // 
            this.geometryPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geometryPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.geometryPropertyGrid.Name = "geometryPropertyGrid";
            this.geometryPropertyGrid.Size = new System.Drawing.Size(273, 503);
            this.geometryPropertyGrid.TabIndex = 0;

            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 632);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.GeometryProperty";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerProperty.Panel1.ResumeLayout(false);
            this.splitContainerProperty.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerProperty)).EndInit();
            this.splitContainerProperty.ResumeLayout(false);
            this.grpReturnType.ResumeLayout(false);
            this.grpReturnType.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;

        // 우측 영역을 조회 방식 / 결과 영역으로 분할
        private System.Windows.Forms.SplitContainer splitContainerProperty;
        private System.Windows.Forms.GroupBox grpReturnType;
        private System.Windows.Forms.RadioButton rdoFromSelectedObject3D;
        private System.Windows.Forms.RadioButton rdoGetSurfaceArea;
        private System.Windows.Forms.RadioButton rdoGetVolume;
        private System.Windows.Forms.RadioButton rdoGetCenterOfVolume;
        private System.Windows.Forms.RadioButton rdoGetGeometry;

        private System.Windows.Forms.PropertyGrid geometryPropertyGrid;
    }
}