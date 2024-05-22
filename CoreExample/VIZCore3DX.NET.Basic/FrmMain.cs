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

            // 라이선스
            //VIZCore3DX.NET.License.AuthenticationResult resultFile =
            //    vizcore3d.AuthenticateLicenseByFile("C:\\License\\VIZCore3DX.NET.lic");

            VIZCore3DX.NET.License.AuthenticationResult resultServer =
                vizcore3d.AuthenticateLicenseByServer("127.0.0.1", 8901);
        }

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
    }
}
