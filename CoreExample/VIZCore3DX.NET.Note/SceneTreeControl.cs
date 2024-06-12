using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Note
{
    public partial class SceneTreeControl : UserControl
    {
        public SceneTreeControl()
        {
            InitializeComponent();
        }

        public void Initialize(VIZCore3DX.NET.Core vizcore3d)
        {
            vizcore3d.SceneTree.Initialize(Handle);

            MouseDown += (sender, e) => { vizcore3d.SceneTree.OnMouseDown(e); };
            MouseUp += (sender, e) => { vizcore3d.SceneTree.OnMouseUp(e); };
            MouseMove += (sender, e) => { vizcore3d.SceneTree.OnMouseMove(e); };
            MouseWheel += (sender, e) => { vizcore3d.SceneTree.OnMouseWheel(e); };
            KeyDown += (sender, e) => { vizcore3d.SceneTree.OnKeyDown(e); };

            Paint += (sender, e) => { vizcore3d.SceneTree.Render(); };
        }
    }
}
