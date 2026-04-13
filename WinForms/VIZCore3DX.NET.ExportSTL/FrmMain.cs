using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.NET.ExportSTL
{
    public partial class FrmMain : Form
    {
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            splitContainer1.Panel2.Controls.Add(vizcore3dx);
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.LicenseResults result
                = vizcore3dx.License.LicenseServer("127.0.0.1", 8901);

            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS) return;
        }

        private void btnExportStlAscii_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "STL File (*.stl)|*.stl";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Model.ExportStl(dlg.FileName, true);
        }

        private void btnExportStlBinary_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "STL File (*.stl)|*.stl";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Model.ExportStl(dlg.FileName, false);
        }
    }
}
