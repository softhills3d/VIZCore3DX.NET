using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Basic
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// VIZCore3DX
        /// </summary>
        public VIZCore3DX.NET.Core VIZCore { get; private set; }

        /// <summary>
        /// View Control
        /// </summary>
        public ViewControl View { get; set; }

        /// <summary>
        /// Scene Tree Control
        /// </summary>
        public SceneTreeControl Scene { get; set; }

        public FrmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load; // 폼 로드 이벤트 핸들러 등록
            this.Disposed += FrmMain_Disposed; // 폼 해제 이벤트 핸들러 등록
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 코어
            VIZCore = new Core();

            // 뷰 컨트롤
            View = new ViewControl();
            View.Dock = DockStyle.Fill;
            View.Initialize(VIZCore);
            this.splitContainerMain.Panel2.Controls.Add(View);

            // 씬 트리 컨트롤
            Scene = new SceneTreeControl();
            Scene.Dock = DockStyle.Fill;
            Scene.Initialize(VIZCore);
            this.splitContainerMain.Panel1.Controls.Add(Scene);

            // 모델 트리 닫기
            splitContainerMain.Panel1Collapsed = true;

            LicenseCheck();
        }

        private void LicenseCheck()
        {
            // 라이선스: File
            //VIZCore3DX.NET.License.AuthenticationResult result =
            //    VIZCore.AuthenticateLicenseByFile("C:\\License\\VIZCore3DX.NET.lic");

            // 라이선스: Server
            VIZCore3DX.NET.License.AuthenticationResult result = VIZCore.AuthenticateLicenseByServer("127.0.0.1", 8901);

            if (result != VIZCore3DX.NET.License.AuthenticationResult.Success)
            {
                MessageBox.Show(string.Format("Error Code = {0}", result), "License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMain_Disposed(object sender, EventArgs e)
        {
            if (VIZCore != null)
                VIZCore.Dispose();
        }


        #region 메뉴 - 파일
        private void menuFileNew_Click(object sender, EventArgs e)
        {
            VIZCore.CloseFile();
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "VIZX File (*.vizx)|*.vizx";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            VIZCore.OpenFile(dlg.FileName);
        }

        private void menuFileAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "VIZX File (*.vizx)|*.vizx";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            VIZCore.View.StopRender();

            foreach (string item in dlg.FileNames)
            {
                VIZCore.AddFile(item);
            }

            VIZCore.View.StartRender();
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region 메뉴 - 편집
        private void menuEditUndo_Click(object sender, EventArgs e)
        {
            VIZCore.Undo();
        }

        private void menuEditRedo_Click(object sender, EventArgs e)
        {
            VIZCore.Redo();
        }
        #endregion

        #region 메뉴 - 보기
        private void menuViewRenderingModeSmooth_Click(object sender, EventArgs e)
        {
            VIZCore.View.IsEdgeEnabled = false;
        }

        private void menuViewRenderingModeSmoothEdge_Click(object sender, EventArgs e)
        {
            VIZCore.View.IsEdgeEnabled = true;
        }

        private void menuViewRenderingModeSSAO_Click(object sender, EventArgs e)
        {
            VIZCore.View.IsSsaoEnabled = !VIZCore.View.IsSsaoEnabled;
        }

        private void menuViewRenderingModeRealtimeShadow_Click(object sender, EventArgs e)
        {
            VIZCore.View.IsShadowEnabled = !VIZCore.View.IsShadowEnabled;
        }

        private void menuViewRenderingModeEnvironmentLight_Click(object sender, EventArgs e)
        {
            VIZCore.View.IsEnvironmentMapEnabled = !VIZCore.View.IsEnvironmentMapEnabled;
        }

        private void menuViewXray_Click(object sender, EventArgs e)
        {
            VIZCore.View.IsXRayEnabled = !VIZCore.View.IsXRayEnabled;
        }
        #endregion

        #region 메뉴 - 도구
        private void menuToolsLicenseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "License (*.lic)|*.lic";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            VIZCore3DX.NET.License.AuthenticationResult result =
                VIZCore.AuthenticateLicenseByFile(dlg.FileName);

            if (result != VIZCore3DX.NET.License.AuthenticationResult.Success)
            {
                MessageBox.Show(string.Format("Error Code = {0}", result), "License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("License = Success", "License", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menuToolsLicenseServer_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.License.AuthenticationResult result =
                VIZCore.AuthenticateLicenseByServer("127.0.0.1", 8901);

            if (result != VIZCore3DX.NET.License.AuthenticationResult.Success)
            {
                MessageBox.Show(string.Format("Error Code = {0}", result), "License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("License = Success", "License", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
