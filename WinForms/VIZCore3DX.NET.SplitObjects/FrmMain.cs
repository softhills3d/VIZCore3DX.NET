using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.NET.SplitObjects
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
                = vizcore3dx.License.LicenseServer("192.168.100.252", 8901);

            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS) return;
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> selectedPart =
                    vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_ALL);

            if (selectedPart.Count == 0)
            {
                MessageBox.Show("Selected Items is empty.");
                return;
            }

            VIZCore3DX.NET.Data.Plane3D plane = new VIZCore3DX.NET.Data.Plane3D(
                new VIZCore3DX.NET.Data.Vector3D(
                    Convert.ToSingle(ptX.Text)
                    , Convert.ToSingle(ptY.Text)
                    , Convert.ToSingle(ptZ.Text)
                    ),

                new VIZCore3DX.NET.Data.Vector3D(
                    Convert.ToSingle(vX.Text)
                    , Convert.ToSingle(vY.Text)
                    , Convert.ToSingle(vZ.Text)
                    )
                );

            vizcore3dx.Object3D.SplitMesh(selectedPart, plane);
        }
    }
}
