using System.Windows.Forms;
using VIZCore3DX.NET.Markup;

namespace VIZCore3DX.NET.Note
{
    public partial class NoteControl : UserControl
    {
        private bool _isUpdating = false;
        VIZCore3DX.NET.Core VIZCore;

        public NoteControl()
        {
            InitializeComponent();
        }

        public void Initialize(VIZCore3DX.NET.Core vizcore3d)
        {
            VIZCore = vizcore3d;

            VIZCore.ReviewManager.Loaded += (sender, e) => { UpdateNoteList(); };
            VIZCore.ReviewManager.Closed += (sender, e) => { UpdateNoteList(); };

            VIZCore.ReviewManager.Created += (sender, e) => { UpdateNoteList(); };
            VIZCore.ReviewManager.Deleted += (sender, e) => { UpdateNoteList(); };
            VIZCore.ReviewManager.SelectionChanged += (sender, e) => { UpdateNoteList(); };
            VIZCore.ReviewManager.ShowChanged += (sender, e) => { UpdateNoteList(); };

        }

        public void UpdateNoteList()
        {
            _isUpdating = true;

            listViewNotes.Items.Clear();

            foreach (var review in VIZCore.ReviewManager.Reviews)
            {
                if (!review.IsNote)
                    continue;

                ListViewItem item = new ListViewItem();
                item.Selected = review.IsSelected;
                item.Tag = review;

                switch (review.Type)
                {
                    case ReviewType.NoteSurface:
                        item.ImageIndex = 0;
                        item.Text = "표면";
                        break;

                    case ReviewType.Note3D:
                        item.ImageIndex = 1;
                        item.Text = "3D";
                        break;

                    case ReviewType.Note2D:
                        item.ImageIndex = 2;
                        item.Text = "2D";
                        break;
                }

                item.SubItems.Add(review.Text);

                if (review.IsShown)
                    item.SubItems.Add("O");
                else
                    item.SubItems.Add("X");

                listViewNotes.Items.Add(item);
            }

            _isUpdating = false;
        }

        private void listViewNotes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_isUpdating)
                return;

            foreach (var review in VIZCore.ReviewManager.Reviews)
            {
                if (review.IsNote)
                    review.IsSelected = false;
            }

            foreach (ListViewItem item in listViewNotes.SelectedItems)
            {
                var review = item.Tag as Review;
                review.IsSelected = true;
            }

            VIZCore.RenderViews();
        }

        private void listViewNotes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Review review = listViewNotes.SelectedItems[0].Tag as Review;
            VIZCore?.ActiveView.Camera.SetStatus(review.CameraStatus);
            VIZCore?.ActiveView.StartRender();
        }
    }
}