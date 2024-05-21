using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Demo
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
        public SceneControl Scene { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            vizcore3d = new Core();

            View = new ViewControl();
            View.Dock = DockStyle.Fill;
            View.Initialize(vizcore3d);
            this.splitContainer1.Panel2.Controls.Add(View);

            Scene = new SceneControl();
            Scene.Dock = DockStyle.Fill;
            Scene.Initialize(vizcore3d);
            this.splitContainer1.Panel1.Controls.Add(Scene);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.License.AuthenticationResult resultFile =
                vizcore3d.AuthenticateLicenseByFile("C:\\License\\VIZCore3DX.NET.lic");

            //VIZCore3DX.NET.License.AuthenticationResult resultServer =
            //    vizcore3d.AuthenticateLicenseByServer("127.0.0.1", 8901);

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "VIZX (*.vizx)|*.vizx";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3d.OpenFile(dlg.FileName);
        }
    }
}
