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
        public VIZCore3DX.NET.Core vizcore3d { get; private set; }

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

            // 코어
            vizcore3d = new Core();

            // 뷰 컨트롤
            View = new ViewControl();
            View.Dock = DockStyle.Fill;
            View.Initialize(vizcore3d);
            this.splitContainerMain.Panel2.Controls.Add(View);

            // 씬 트리 컨트롤
            Scene = new SceneTreeControl();
            Scene.Dock = DockStyle.Fill;
            Scene.Initialize(vizcore3d);
            this.splitContainerMain.Panel1.Controls.Add(Scene);

            // 라이선스: File
            //VIZCore3DX.NET.License.AuthenticationResult result =
            //    vizcore3d.AuthenticateLicenseByFile("C:\\License\\VIZCore3DX.NET.lic");

            // 라이선스: Server
            VIZCore3DX.NET.License.AuthenticationResult result =
                vizcore3d.AuthenticateLicenseByServer("127.0.0.1", 8901);

            if (result != VIZCore3DX.NET.License.AuthenticationResult.Success)
            {
                MessageBox.Show(string.Format("Error Code = {0}", result), "License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region 메뉴 - 파일
        private void menuFileNew_Click(object sender, EventArgs e)
        {
            vizcore3d.CloseFile();
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "VIZX File (*.vizx)|*.vizx";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3d.OpenFile(dlg.FileName);
        }

        private void menuFileAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "VIZX File (*.vizx)|*.vizx";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3d.View.StopRender();

            foreach (string item in dlg.FileNames)
            {
                vizcore3d.AddFile(item);
            }

            vizcore3d.View.StartRender();
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region 메뉴 - 편집
        private void menuEditUndo_Click(object sender, EventArgs e)
        {
            vizcore3d.Undo();
        }

        private void menuEditRedo_Click(object sender, EventArgs e)
        {
            vizcore3d.Redo();
        }
        #endregion

        #region 메뉴 - 보기
        private void menuViewRenderingModeSmooth_Click(object sender, EventArgs e)
        {
            vizcore3d.View.IsEdgeEnabled = false;
        }

        private void menuViewRenderingModeSmoothEdge_Click(object sender, EventArgs e)
        {
            vizcore3d.View.IsEdgeEnabled = true;
        }

        private void menuViewRenderingModeSSAO_Click(object sender, EventArgs e)
        {
            vizcore3d.View.IsSsaoEnabled = !vizcore3d.View.IsSsaoEnabled;
        }

        private void menuViewRenderingModeRealtimeShadow_Click(object sender, EventArgs e)
        {
            vizcore3d.View.IsShadowEnabled = !vizcore3d.View.IsShadowEnabled;
        }

        private void menuViewRenderingModeEnvironmentLight_Click(object sender, EventArgs e)
        {
            vizcore3d.View.IsEnvironmentMapEnabled = !vizcore3d.View.IsEnvironmentMapEnabled;
        }

        private void menuViewXray_Click(object sender, EventArgs e)
        {
            vizcore3d.View.IsXRayEnabled = !vizcore3d.View.IsXRayEnabled;
        }
        #endregion

        #region 메뉴 - 도구
        private void menuToolsLicenseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "License (*.lic)|*.lic";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            VIZCore3DX.NET.License.AuthenticationResult result =
                vizcore3d.AuthenticateLicenseByFile(dlg.FileName);

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
                vizcore3d.AuthenticateLicenseByServer("127.0.0.1", 8901);

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
