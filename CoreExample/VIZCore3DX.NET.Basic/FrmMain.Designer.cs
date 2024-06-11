namespace VIZCore3DX.NET.Basic
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
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewRenderingMode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewRenderingModeSmooth = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewRenderingModeSmoothEdge = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewRenderingModeSSAO = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewRenderingModeRealtimeShadow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewRenderingModeEnvironmentLight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewXray = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsLicenseFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsLicenseServer = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuView,
            this.menuTools});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(956, 24);
            this.menuBar.TabIndex = 0;
            this.menuBar.Text = "menu";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.menuFileOpen,
            this.menuFileAdd,
            this.toolStripSeparator1,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(43, 20);
            this.menuFile.Text = "파일";
            // 
            // menuFileNew
            // 
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.Size = new System.Drawing.Size(180, 22);
            this.menuFileNew.Text = "새 모델";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.Size = new System.Drawing.Size(180, 22);
            this.menuFileOpen.Text = "열기...";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileAdd
            // 
            this.menuFileAdd.Name = "menuFileAdd";
            this.menuFileAdd.Size = new System.Drawing.Size(180, 22);
            this.menuFileAdd.Text = "추가...";
            this.menuFileAdd.Click += new System.EventHandler(this.menuFileAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(180, 22);
            this.menuFileExit.Text = "종료";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditUndo,
            this.menuEditRedo});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(43, 20);
            this.menuEdit.Text = "편집";
            // 
            // menuEditUndo
            // 
            this.menuEditUndo.Name = "menuEditUndo";
            this.menuEditUndo.Size = new System.Drawing.Size(180, 22);
            this.menuEditUndo.Text = "실행 취소";
            this.menuEditUndo.Click += new System.EventHandler(this.menuEditUndo_Click);
            // 
            // menuEditRedo
            // 
            this.menuEditRedo.Name = "menuEditRedo";
            this.menuEditRedo.Size = new System.Drawing.Size(180, 22);
            this.menuEditRedo.Text = "다시 실행";
            this.menuEditRedo.Click += new System.EventHandler(this.menuEditRedo_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewRenderingMode,
            this.menuViewXray});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(43, 20);
            this.menuView.Text = "보기";
            // 
            // menuViewRenderingMode
            // 
            this.menuViewRenderingMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewRenderingModeSmooth,
            this.menuViewRenderingModeSmoothEdge,
            this.menuViewRenderingModeSSAO,
            this.menuViewRenderingModeRealtimeShadow,
            this.menuViewRenderingModeEnvironmentLight});
            this.menuViewRenderingMode.Name = "menuViewRenderingMode";
            this.menuViewRenderingMode.Size = new System.Drawing.Size(180, 22);
            this.menuViewRenderingMode.Text = "렌더링 모드";
            // 
            // menuViewRenderingModeSmooth
            // 
            this.menuViewRenderingModeSmooth.Name = "menuViewRenderingModeSmooth";
            this.menuViewRenderingModeSmooth.Size = new System.Drawing.Size(166, 22);
            this.menuViewRenderingModeSmooth.Text = "부드러운 음영";
            this.menuViewRenderingModeSmooth.Click += new System.EventHandler(this.menuViewRenderingModeSmooth_Click);
            // 
            // menuViewRenderingModeSmoothEdge
            // 
            this.menuViewRenderingModeSmoothEdge.Name = "menuViewRenderingModeSmoothEdge";
            this.menuViewRenderingModeSmoothEdge.Size = new System.Drawing.Size(166, 22);
            this.menuViewRenderingModeSmoothEdge.Text = "모서리 표시 음영";
            this.menuViewRenderingModeSmoothEdge.Click += new System.EventHandler(this.menuViewRenderingModeSmoothEdge_Click);
            // 
            // menuViewRenderingModeSSAO
            // 
            this.menuViewRenderingModeSSAO.Name = "menuViewRenderingModeSSAO";
            this.menuViewRenderingModeSSAO.Size = new System.Drawing.Size(166, 22);
            this.menuViewRenderingModeSSAO.Text = "SSAO";
            this.menuViewRenderingModeSSAO.Click += new System.EventHandler(this.menuViewRenderingModeSSAO_Click);
            // 
            // menuViewRenderingModeRealtimeShadow
            // 
            this.menuViewRenderingModeRealtimeShadow.Name = "menuViewRenderingModeRealtimeShadow";
            this.menuViewRenderingModeRealtimeShadow.Size = new System.Drawing.Size(166, 22);
            this.menuViewRenderingModeRealtimeShadow.Text = "그림자";
            this.menuViewRenderingModeRealtimeShadow.Click += new System.EventHandler(this.menuViewRenderingModeRealtimeShadow_Click);
            // 
            // menuViewRenderingModeEnvironmentLight
            // 
            this.menuViewRenderingModeEnvironmentLight.Name = "menuViewRenderingModeEnvironmentLight";
            this.menuViewRenderingModeEnvironmentLight.Size = new System.Drawing.Size(166, 22);
            this.menuViewRenderingModeEnvironmentLight.Text = "환경조명";
            this.menuViewRenderingModeEnvironmentLight.Click += new System.EventHandler(this.menuViewRenderingModeEnvironmentLight_Click);
            // 
            // menuViewXray
            // 
            this.menuViewXray.Name = "menuViewXray";
            this.menuViewXray.Size = new System.Drawing.Size(180, 22);
            this.menuViewXray.Text = "X-Ray";
            this.menuViewXray.Click += new System.EventHandler(this.menuViewXray_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolsLicense});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(43, 20);
            this.menuTools.Text = "도구";
            // 
            // menuToolsLicense
            // 
            this.menuToolsLicense.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolsLicenseFile,
            this.menuToolsLicenseServer});
            this.menuToolsLicense.Name = "menuToolsLicense";
            this.menuToolsLicense.Size = new System.Drawing.Size(180, 22);
            this.menuToolsLicense.Text = "라이선스";
            // 
            // menuToolsLicenseFile
            // 
            this.menuToolsLicenseFile.Name = "menuToolsLicenseFile";
            this.menuToolsLicenseFile.Size = new System.Drawing.Size(126, 22);
            this.menuToolsLicenseFile.Text = "파일 인증";
            this.menuToolsLicenseFile.Click += new System.EventHandler(this.menuToolsLicenseFile_Click);
            // 
            // menuToolsLicenseServer
            // 
            this.menuToolsLicenseServer.Name = "menuToolsLicenseServer";
            this.menuToolsLicenseServer.Size = new System.Drawing.Size(126, 22);
            this.menuToolsLicenseServer.Text = "서버 연결";
            this.menuToolsLicenseServer.Click += new System.EventHandler(this.menuToolsLicenseServer_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 24);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Size = new System.Drawing.Size(956, 517);
            this.splitContainerMain.SplitterDistance = 261;
            this.splitContainerMain.TabIndex = 1;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 541);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.Basic";
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem menuFileAdd;
        private System.Windows.Forms.ToolStripMenuItem menuEditUndo;
        private System.Windows.Forms.ToolStripMenuItem menuEditRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuToolsLicense;
        private System.Windows.Forms.ToolStripMenuItem menuToolsLicenseFile;
        private System.Windows.Forms.ToolStripMenuItem menuToolsLicenseServer;
        private System.Windows.Forms.ToolStripMenuItem menuViewRenderingMode;
        private System.Windows.Forms.ToolStripMenuItem menuViewRenderingModeSmooth;
        private System.Windows.Forms.ToolStripMenuItem menuViewRenderingModeSmoothEdge;
        private System.Windows.Forms.ToolStripMenuItem menuViewRenderingModeSSAO;
        private System.Windows.Forms.ToolStripMenuItem menuViewRenderingModeRealtimeShadow;
        private System.Windows.Forms.ToolStripMenuItem menuViewRenderingModeEnvironmentLight;
        private System.Windows.Forms.ToolStripMenuItem menuViewXray;
    }
}

