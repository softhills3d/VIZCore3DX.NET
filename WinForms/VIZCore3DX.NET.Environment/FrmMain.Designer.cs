namespace VIZCore3DX.NET.Environment
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
            this.grpTexture = new System.Windows.Forms.GroupBox();
            this.lblTextureHint = new System.Windows.Forms.Label();
            this.lblSkyFile = new System.Windows.Forms.Label();
            this.lblGroundFile = new System.Windows.Forms.Label();
            this.btnSkyPanorama = new System.Windows.Forms.Button();
            this.btnGroundTexture = new System.Windows.Forms.Button();
            this.grpSurface = new System.Windows.Forms.GroupBox();
            this.numWaterHeight = new System.Windows.Forms.NumericUpDown();
            this.lblWaterHeight = new System.Windows.Forms.Label();
            this.chkShaderWater = new System.Windows.Forms.CheckBox();
            this.chkWater = new System.Windows.Forms.CheckBox();
            this.btnGridFaceColor = new System.Windows.Forms.Button();
            this.btnGridLineColor = new System.Windows.Forms.Button();
            this.chkFloorGrid = new System.Windows.Forms.CheckBox();
            this.numFloorHeight = new System.Windows.Forms.NumericUpDown();
            this.lblFloorHeight = new System.Windows.Forms.Label();
            this.grpEnvironment = new System.Windows.Forms.GroupBox();
            this.chkGroundExtend = new System.Windows.Forms.CheckBox();
            this.chkShadow = new System.Windows.Forms.CheckBox();
            this.cmbGroundPreset = new System.Windows.Forms.ComboBox();
            this.chkGround = new System.Windows.Forms.CheckBox();
            this.cmbSkyPreset = new System.Windows.Forms.ComboBox();
            this.chkSky = new System.Windows.Forms.CheckBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.lblModelHint = new System.Windows.Forms.Label();
            this.btnOpenModel = new System.Windows.Forms.Button();
            this.grpCleanup = new System.Windows.Forms.GroupBox();
            this.btnDisable = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpTexture.SuspendLayout();
            this.grpSurface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWaterHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloorHeight)).BeginInit();
            this.grpEnvironment.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpTexture);
            this.splitContainer1.Panel1.Controls.Add(this.grpSurface);
            this.splitContainer1.Panel1.Controls.Add(this.grpEnvironment);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Panel1.Controls.Add(this.grpCleanup);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 800);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 0;
            //
            // grpTexture
            //
            this.grpTexture.Controls.Add(this.lblTextureHint);
            this.grpTexture.Controls.Add(this.lblSkyFile);
            this.grpTexture.Controls.Add(this.lblGroundFile);
            this.grpTexture.Controls.Add(this.btnSkyPanorama);
            this.grpTexture.Controls.Add(this.btnGroundTexture);
            this.grpTexture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTexture.Location = new System.Drawing.Point(8, 380);
            this.grpTexture.Name = "grpTexture";
            this.grpTexture.Size = new System.Drawing.Size(344, 330);
            this.grpTexture.TabIndex = 3;
            this.grpTexture.TabStop = false;
            this.grpTexture.Text = "4. 사용자 텍스처";
            //
            // lblTextureHint
            //
            this.lblTextureHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextureHint.Location = new System.Drawing.Point(12, 104);
            this.lblTextureHint.Name = "lblTextureHint";
            this.lblTextureHint.Size = new System.Drawing.Size(320, 48);
            this.lblTextureHint.TabIndex = 4;
            this.lblTextureHint.Text = "사용자 이미지를 지정하면 프리셋 대신 그 이미지가 쓰입니다.\r\n[2. 환경]에서 프리셋을 다시 고르면 프리셋으로 돌아갑니다.";
            //
            // lblSkyFile
            //
            this.lblSkyFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSkyFile.AutoEllipsis = true;
            this.lblSkyFile.Location = new System.Drawing.Point(12, 80);
            this.lblSkyFile.Name = "lblSkyFile";
            this.lblSkyFile.Size = new System.Drawing.Size(320, 16);
            this.lblSkyFile.TabIndex = 3;
            this.lblSkyFile.Text = "하늘: (프리셋)";
            //
            // lblGroundFile
            //
            this.lblGroundFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGroundFile.AutoEllipsis = true;
            this.lblGroundFile.Location = new System.Drawing.Point(12, 60);
            this.lblGroundFile.Name = "lblGroundFile";
            this.lblGroundFile.Size = new System.Drawing.Size(320, 16);
            this.lblGroundFile.TabIndex = 2;
            this.lblGroundFile.Text = "지면: (프리셋)";
            //
            // btnSkyPanorama
            //
            this.btnSkyPanorama.Location = new System.Drawing.Point(172, 24);
            this.btnSkyPanorama.Name = "btnSkyPanorama";
            this.btnSkyPanorama.Size = new System.Drawing.Size(160, 23);
            this.btnSkyPanorama.TabIndex = 1;
            this.btnSkyPanorama.Text = "하늘 파노라마 이미지...";
            this.btnSkyPanorama.UseVisualStyleBackColor = true;
            this.btnSkyPanorama.Click += new System.EventHandler(this.btnSkyPanorama_Click);
            //
            // btnGroundTexture
            //
            this.btnGroundTexture.Location = new System.Drawing.Point(12, 24);
            this.btnGroundTexture.Name = "btnGroundTexture";
            this.btnGroundTexture.Size = new System.Drawing.Size(150, 23);
            this.btnGroundTexture.TabIndex = 0;
            this.btnGroundTexture.Text = "지면 텍스처 이미지...";
            this.btnGroundTexture.UseVisualStyleBackColor = true;
            this.btnGroundTexture.Click += new System.EventHandler(this.btnGroundTexture_Click);
            //
            // grpSurface
            //
            this.grpSurface.Controls.Add(this.numWaterHeight);
            this.grpSurface.Controls.Add(this.lblWaterHeight);
            this.grpSurface.Controls.Add(this.chkShaderWater);
            this.grpSurface.Controls.Add(this.chkWater);
            this.grpSurface.Controls.Add(this.btnGridFaceColor);
            this.grpSurface.Controls.Add(this.btnGridLineColor);
            this.grpSurface.Controls.Add(this.chkFloorGrid);
            this.grpSurface.Controls.Add(this.numFloorHeight);
            this.grpSurface.Controls.Add(this.lblFloorHeight);
            this.grpSurface.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSurface.Location = new System.Drawing.Point(8, 240);
            this.grpSurface.Name = "grpSurface";
            this.grpSurface.Size = new System.Drawing.Size(344, 140);
            this.grpSurface.TabIndex = 2;
            this.grpSurface.TabStop = false;
            this.grpSurface.Text = "3. 바닥 · 수면";
            //
            // numWaterHeight
            //
            this.numWaterHeight.DecimalPlaces = 1;
            this.numWaterHeight.Location = new System.Drawing.Point(112, 108);
            this.numWaterHeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numWaterHeight.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numWaterHeight.Name = "numWaterHeight";
            this.numWaterHeight.Size = new System.Drawing.Size(100, 21);
            this.numWaterHeight.TabIndex = 8;
            this.numWaterHeight.ValueChanged += new System.EventHandler(this.numWaterHeight_ValueChanged);
            //
            // lblWaterHeight
            //
            this.lblWaterHeight.AutoSize = true;
            this.lblWaterHeight.Location = new System.Drawing.Point(12, 112);
            this.lblWaterHeight.Name = "lblWaterHeight";
            this.lblWaterHeight.Size = new System.Drawing.Size(57, 12);
            this.lblWaterHeight.TabIndex = 7;
            this.lblWaterHeight.Text = "수면 높이";
            //
            // chkShaderWater
            //
            this.chkShaderWater.AutoSize = true;
            this.chkShaderWater.Location = new System.Drawing.Point(112, 86);
            this.chkShaderWater.Name = "chkShaderWater";
            this.chkShaderWater.Size = new System.Drawing.Size(104, 16);
            this.chkShaderWater.TabIndex = 6;
            this.chkShaderWater.Text = "물결 효과(쉐이더)";
            this.chkShaderWater.UseVisualStyleBackColor = true;
            this.chkShaderWater.CheckedChanged += new System.EventHandler(this.chkShaderWater_CheckedChanged);
            //
            // chkWater
            //
            this.chkWater.AutoSize = true;
            this.chkWater.Location = new System.Drawing.Point(12, 86);
            this.chkWater.Name = "chkWater";
            this.chkWater.Size = new System.Drawing.Size(48, 16);
            this.chkWater.TabIndex = 5;
            this.chkWater.Text = "수면";
            this.chkWater.UseVisualStyleBackColor = true;
            this.chkWater.CheckedChanged += new System.EventHandler(this.chkWater_CheckedChanged);
            //
            // btnGridFaceColor
            //
            this.btnGridFaceColor.Location = new System.Drawing.Point(222, 52);
            this.btnGridFaceColor.Name = "btnGridFaceColor";
            this.btnGridFaceColor.Size = new System.Drawing.Size(110, 23);
            this.btnGridFaceColor.TabIndex = 4;
            this.btnGridFaceColor.Text = "격자 면 색";
            this.btnGridFaceColor.UseVisualStyleBackColor = false;
            this.btnGridFaceColor.Click += new System.EventHandler(this.btnGridFaceColor_Click);
            //
            // btnGridLineColor
            //
            this.btnGridLineColor.Location = new System.Drawing.Point(112, 52);
            this.btnGridLineColor.Name = "btnGridLineColor";
            this.btnGridLineColor.Size = new System.Drawing.Size(100, 23);
            this.btnGridLineColor.TabIndex = 3;
            this.btnGridLineColor.Text = "격자 선 색";
            this.btnGridLineColor.UseVisualStyleBackColor = false;
            this.btnGridLineColor.Click += new System.EventHandler(this.btnGridLineColor_Click);
            //
            // chkFloorGrid
            //
            this.chkFloorGrid.AutoSize = true;
            this.chkFloorGrid.Location = new System.Drawing.Point(12, 56);
            this.chkFloorGrid.Name = "chkFloorGrid";
            this.chkFloorGrid.Size = new System.Drawing.Size(72, 16);
            this.chkFloorGrid.TabIndex = 2;
            this.chkFloorGrid.Text = "바닥 격자";
            this.chkFloorGrid.UseVisualStyleBackColor = true;
            this.chkFloorGrid.CheckedChanged += new System.EventHandler(this.chkFloorGrid_CheckedChanged);
            //
            // numFloorHeight
            //
            this.numFloorHeight.DecimalPlaces = 1;
            this.numFloorHeight.Location = new System.Drawing.Point(112, 24);
            this.numFloorHeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numFloorHeight.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numFloorHeight.Name = "numFloorHeight";
            this.numFloorHeight.Size = new System.Drawing.Size(100, 21);
            this.numFloorHeight.TabIndex = 1;
            this.numFloorHeight.ValueChanged += new System.EventHandler(this.numFloorHeight_ValueChanged);
            //
            // lblFloorHeight
            //
            this.lblFloorHeight.AutoSize = true;
            this.lblFloorHeight.Location = new System.Drawing.Point(12, 28);
            this.lblFloorHeight.Name = "lblFloorHeight";
            this.lblFloorHeight.Size = new System.Drawing.Size(57, 12);
            this.lblFloorHeight.TabIndex = 0;
            this.lblFloorHeight.Text = "바닥 높이";
            //
            // grpEnvironment
            //
            this.grpEnvironment.Controls.Add(this.chkGroundExtend);
            this.grpEnvironment.Controls.Add(this.chkShadow);
            this.grpEnvironment.Controls.Add(this.cmbGroundPreset);
            this.grpEnvironment.Controls.Add(this.chkGround);
            this.grpEnvironment.Controls.Add(this.cmbSkyPreset);
            this.grpEnvironment.Controls.Add(this.chkSky);
            this.grpEnvironment.Controls.Add(this.chkEnabled);
            this.grpEnvironment.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEnvironment.Location = new System.Drawing.Point(8, 104);
            this.grpEnvironment.Name = "grpEnvironment";
            this.grpEnvironment.Size = new System.Drawing.Size(344, 136);
            this.grpEnvironment.TabIndex = 1;
            this.grpEnvironment.TabStop = false;
            this.grpEnvironment.Text = "2. 환경";
            //
            // chkGroundExtend
            //
            this.chkGroundExtend.AutoSize = true;
            this.chkGroundExtend.Location = new System.Drawing.Point(172, 108);
            this.chkGroundExtend.Name = "chkGroundExtend";
            this.chkGroundExtend.Size = new System.Drawing.Size(128, 16);
            this.chkGroundExtend.TabIndex = 6;
            this.chkGroundExtend.Text = "지면 지평선까지 확장";
            this.chkGroundExtend.UseVisualStyleBackColor = true;
            this.chkGroundExtend.CheckedChanged += new System.EventHandler(this.chkGroundExtend_CheckedChanged);
            //
            // chkShadow
            //
            this.chkShadow.AutoSize = true;
            this.chkShadow.Location = new System.Drawing.Point(12, 108);
            this.chkShadow.Name = "chkShadow";
            this.chkShadow.Size = new System.Drawing.Size(84, 16);
            this.chkShadow.TabIndex = 5;
            this.chkShadow.Text = "접지 그림자";
            this.chkShadow.UseVisualStyleBackColor = true;
            this.chkShadow.CheckedChanged += new System.EventHandler(this.chkShadow_CheckedChanged);
            //
            // cmbGroundPreset
            //
            this.cmbGroundPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroundPreset.FormattingEnabled = true;
            this.cmbGroundPreset.Location = new System.Drawing.Point(112, 78);
            this.cmbGroundPreset.Name = "cmbGroundPreset";
            this.cmbGroundPreset.Size = new System.Drawing.Size(220, 20);
            this.cmbGroundPreset.TabIndex = 4;
            this.cmbGroundPreset.SelectedIndexChanged += new System.EventHandler(this.cmbGroundPreset_SelectedIndexChanged);
            //
            // chkGround
            //
            this.chkGround.AutoSize = true;
            this.chkGround.Location = new System.Drawing.Point(12, 80);
            this.chkGround.Name = "chkGround";
            this.chkGround.Size = new System.Drawing.Size(48, 16);
            this.chkGround.TabIndex = 3;
            this.chkGround.Text = "지면";
            this.chkGround.UseVisualStyleBackColor = true;
            this.chkGround.CheckedChanged += new System.EventHandler(this.chkGround_CheckedChanged);
            //
            // cmbSkyPreset
            //
            this.cmbSkyPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkyPreset.FormattingEnabled = true;
            this.cmbSkyPreset.Location = new System.Drawing.Point(112, 50);
            this.cmbSkyPreset.Name = "cmbSkyPreset";
            this.cmbSkyPreset.Size = new System.Drawing.Size(220, 20);
            this.cmbSkyPreset.TabIndex = 2;
            this.cmbSkyPreset.SelectedIndexChanged += new System.EventHandler(this.cmbSkyPreset_SelectedIndexChanged);
            //
            // chkSky
            //
            this.chkSky.AutoSize = true;
            this.chkSky.Location = new System.Drawing.Point(12, 52);
            this.chkSky.Name = "chkSky";
            this.chkSky.Size = new System.Drawing.Size(48, 16);
            this.chkSky.TabIndex = 1;
            this.chkSky.Text = "하늘";
            this.chkSky.UseVisualStyleBackColor = true;
            this.chkSky.CheckedChanged += new System.EventHandler(this.chkSky_CheckedChanged);
            //
            // chkEnabled
            //
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(12, 24);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(72, 16);
            this.chkEnabled.TabIndex = 0;
            this.chkEnabled.Text = "환경 켜기";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
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
            this.lblModelHint.Location = new System.Drawing.Point(12, 54);
            this.lblModelHint.Name = "lblModelHint";
            this.lblModelHint.Size = new System.Drawing.Size(320, 32);
            this.lblModelHint.TabIndex = 1;
            this.lblModelHint.Text = "모델을 연 뒤 [환경 켜기]를 체크하세요.\r\n오른쪽 속성 패널의 [환경] 탭과 같은 값을 다룹니다.";
            //
            // btnOpenModel
            //
            this.btnOpenModel.Location = new System.Drawing.Point(12, 24);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(120, 23);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "모델 열기";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            //
            // grpCleanup
            //
            this.grpCleanup.Controls.Add(this.btnDisable);
            this.grpCleanup.Controls.Add(this.btnRead);
            this.grpCleanup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCleanup.Location = new System.Drawing.Point(8, 710);
            this.grpCleanup.Name = "grpCleanup";
            this.grpCleanup.Size = new System.Drawing.Size(344, 60);
            this.grpCleanup.TabIndex = 4;
            this.grpCleanup.TabStop = false;
            this.grpCleanup.Text = "5. 정리";
            //
            // btnDisable
            //
            this.btnDisable.Location = new System.Drawing.Point(172, 24);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(150, 23);
            this.btnDisable.TabIndex = 1;
            this.btnDisable.Text = "환경 끄기";
            this.btnDisable.UseVisualStyleBackColor = true;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            //
            // btnRead
            //
            this.btnRead.Location = new System.Drawing.Point(12, 24);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(150, 23);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "현재 값 읽기";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
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
            this.Text = "VIZCore3DX.NET.Environment";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpTexture.ResumeLayout(false);
            this.grpSurface.ResumeLayout(false);
            this.grpSurface.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWaterHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloorHeight)).EndInit();
            this.grpEnvironment.ResumeLayout(false);
            this.grpEnvironment.PerformLayout();
            this.grpModel.ResumeLayout(false);
            this.grpCleanup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Label lblModelHint;
        private System.Windows.Forms.Button btnOpenModel;
        private System.Windows.Forms.GroupBox grpEnvironment;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.CheckBox chkSky;
        private System.Windows.Forms.ComboBox cmbSkyPreset;
        private System.Windows.Forms.CheckBox chkGround;
        private System.Windows.Forms.ComboBox cmbGroundPreset;
        private System.Windows.Forms.CheckBox chkShadow;
        private System.Windows.Forms.CheckBox chkGroundExtend;
        private System.Windows.Forms.GroupBox grpSurface;
        private System.Windows.Forms.Label lblFloorHeight;
        private System.Windows.Forms.NumericUpDown numFloorHeight;
        private System.Windows.Forms.CheckBox chkFloorGrid;
        private System.Windows.Forms.Button btnGridLineColor;
        private System.Windows.Forms.Button btnGridFaceColor;
        private System.Windows.Forms.CheckBox chkWater;
        private System.Windows.Forms.CheckBox chkShaderWater;
        private System.Windows.Forms.Label lblWaterHeight;
        private System.Windows.Forms.NumericUpDown numWaterHeight;
        private System.Windows.Forms.GroupBox grpTexture;
        private System.Windows.Forms.Button btnGroundTexture;
        private System.Windows.Forms.Button btnSkyPanorama;
        private System.Windows.Forms.Label lblGroundFile;
        private System.Windows.Forms.Label lblSkyFile;
        private System.Windows.Forms.Label lblTextureHint;
        private System.Windows.Forms.GroupBox grpCleanup;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.Label lblStatus;
    }
}
