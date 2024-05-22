using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.Control.Basic
{
    public partial class FrmMain : Form
    {
        public VIZCore3DX.Control.VIZCore3DControl vizcore3d { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            VIZCore3DX.Control.ModuleInitializer.Run();

            vizcore3d = new Control.VIZCore3DControl();
            vizcore3d.Dock = DockStyle.Fill;
            this.Controls.Add(vizcore3d);

            vizcore3d.OnInitializedVIZCore3D += VIZCore3D_OnInitializedVIZCore3D;
        }

        private void VIZCore3D_OnInitializedVIZCore3D(object sender, EventArgs e)
        {
            VIZCore3DX.Control.Data.LicenseResults resultFile =
                vizcore3d.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");

            //VIZCore3DX.Control.Data.LicenseResults resultServer =
            //    vizcore3d.License.LicenseServer("127.0.0.1", 8901);

            if (resultFile != Control.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("License = {0}", resultFile), "License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            vizcore3d.ToolbarMeasure.Visible = true;
            vizcore3d.ToolbarNote.Visible = true;
            vizcore3d.ToolbarSection.Visible = true;
            vizcore3d.ToolbarSnapshot.Visible = true;
        }
    }
}
