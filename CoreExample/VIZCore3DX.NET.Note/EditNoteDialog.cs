using System;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Note
{
    /// <summary>
    /// Edit Note Dialog
    /// </summary>
    public partial class EditNoteDialog : Form
    {
        /// <summary>
        /// Note Text
        /// </summary>
        public string NoteText
        {
            get
            {
                return txtText.Text;
            }
            set
            {
                txtText.Text = value;
            }
        }

        /// <summary>
        /// Construction
        /// </summary>
        public EditNoteDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="text">Note Text</param>
        public EditNoteDialog(string text)
        {
            InitializeComponent();

            txtText.Text = text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtText.Text) == true)
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
                btnOK.PerformClick();
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbLength.Invoke(new EventHandler(delegate
                {
                    lbLength.Text = string.Format("({0:#0} / {1:#0})", txtText.Text.Length, txtText.MaxLength);
                }));
            }
            catch (Exception)
            {
            }
        }
    }
}