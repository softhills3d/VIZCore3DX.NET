using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.Demo
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
            VIZCore3DX.Control.Data.LicenseResults result =
                vizcore3d.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");

            if(result != Control.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("License = {0}", result), "License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
