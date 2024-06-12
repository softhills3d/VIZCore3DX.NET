using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIZCore3DX.NET.License;

namespace VIZCore3DX.NET.Viewer
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

            // 라이선스: File
            //VIZCore3DX.NET.License.AuthenticationResult result =
            //    VIZCore.AuthenticateLicenseByFile("C:\\License\\VIZCore3DX.NET.lic");

            // 라이선스: Server
            VIZCore3DX.NET.License.AuthenticationResult result = VIZCore.AuthenticateLicenseByServer("127.0.0.1", 8901);

            if (result != VIZCore3DX.NET.License.AuthenticationResult.Success)
            {
                MessageBox.Show(string.Format("Error Code = {0}", result), "License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 모델 트리 닫기
            splitContainerMain.Panel1Collapsed = true;
        }

        private void FrmMain_Disposed(object sender, EventArgs e)
        {
            if (VIZCore != null)
                VIZCore.Dispose();
        }

        private void btnModelOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "VIZX File (*.vizx)|*.vizx";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            VIZCore.OpenFile(dlg.FileName);
        }

        private void btnModelTree_Click(object sender, EventArgs e)
        {
            if (splitContainerMain.Panel1Collapsed)
            {
                splitContainerMain.Panel1Collapsed = false;
            }
            else
            {
                splitContainerMain.Panel1Collapsed = true;
            }
        }

        private void btnResetView_Click(object sender, EventArgs e)
        {
            VIZCore.ActiveView.Camera.Initialize();
        }

        private void btnFitView_Click(object sender, EventArgs e)
        {
            VIZCore.ActiveView.Camera.Fit();
        }

        private void btnMoveToObject_Click(object sender, EventArgs e)
        {
            if (VIZCore.Scene.Query(NodeFilter.DirectSelected).NodeCount < 1) return;

            VIZCore.ActiveView.Camera.TranslateToSelectedNodes(new TimeSpan(0, 0, 0, 0, 500));
        }

        private void btnFlyToObject_Click(object sender, EventArgs e)
        {
            if (VIZCore.Scene.Query(NodeFilter.DirectSelected).NodeCount < 1) return;

            VIZCore.ActiveView.Camera.FitToSelectedNodes(new TimeSpan(0, 0, 0, 0, 500));
        }

        private void btnPerspectiveView_Click(object sender, EventArgs e)
        {
            VIZCore.ActiveView.Camera.Projection = ProjectionType.Perspective;
        }

        private void btnOrthographicView_Click(object sender, EventArgs e)
        {
            VIZCore.ActiveView.Camera.Projection = ProjectionType.Orthographic;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            VIZCore.Scene.Query(NodeFilter.Root).ShowNodes(true);
            VIZCore.StartRenderViews();
            VIZCore.SceneTree.Render();
        }

        private void btnHideAll_Click(object sender, EventArgs e)
        {
            VIZCore.Scene.Query(NodeFilter.Root).ShowNodes(false);
            VIZCore.StartRenderViews();
            VIZCore.SceneTree.Render();
        }

        private void btnHideSelection_Click(object sender, EventArgs e)
        {
            VIZCore.Scene.Query(NodeFilter.DirectSelected).ShowNodes(false);
            VIZCore.StartRenderViews();
            VIZCore.SceneTree.Render();
        }

        private void btnHideNonSelection_Click(object sender, EventArgs e)
        {
            VIZCore.Scene.Query(NodeFilter.UnselectedLeaf).ShowNodes(false);
            VIZCore.StartRenderViews();
            VIZCore.SceneTree.Render();
        }
    }
}
