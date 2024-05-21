using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIZCore3DX.NET.Markup;

namespace VIZCore3DX.NET.Demo
{
    public partial class ViewControl : UserControl
    {
        public VIZCore3DX.NET.Core vizcore3d {  get; set; }
        public VIZCore3DX.NET.View View { get; private set; }

        public ViewControl()
        {
            InitializeComponent();
        }

        public void Initialize(VIZCore3DX.NET.Core core)
        {
            vizcore3d = core;
            View = core.View;

            vizcore3d.View.Initialize(Handle);

            MouseDown += (sender, e) => { View.OnMouseDown(e); };
            MouseUp += (sender, e) => { View.OnMouseUp(e); };
            MouseMove += (sender, e) => { View.OnMouseMove(e); };
            MouseWheel += (sender, e) => { View.OnMouseWheel(e); };
            MouseDoubleClick += (sender, e) => { View.OnMouseDoubleClick(e); };

            PreviewKeyDown += (sender, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                    case Keys.Right:
                    case Keys.Up:
                    case Keys.Left:
                        e.IsInputKey = true;
                        break;
                }
            };
            KeyDown += (sender, e) => { View.OnKeyDown(e); };

            Paint += (sender, e) => { View.Render(); };
            Resize += (sender, e) => { View.StartRender(); };

            //View.ContextMenuOpened += (sender, e) =>
            //{
            //    if (e.SelectedObject == null)
            //        contextMenuBackground.Show(Cursor.Position);
            //    else if (e.SelectedObject is Node)
            //        contextMenuNode.Show(Cursor.Position);
            //    else if (e.SelectedObject is Review)
            //    {
            //        contextMenuReview.Tag = e.SelectedObject;
            //        contextMenuReview.Show(Cursor.Position);
            //    }
            //};
        }
    }
}
