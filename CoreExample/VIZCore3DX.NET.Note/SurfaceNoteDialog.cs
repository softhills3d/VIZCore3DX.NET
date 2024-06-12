using System;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Note
{
    /// <summary>
    /// Surface Note Dialog
    /// </summary>
    public partial class SurfaceNoteDialog : Form
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
        /// Use Symbol
        /// </summary>
        public bool UseSymbol
        {
            get
            {
                return ckUseSymbol.Checked;
            }
            set
            {
                ckUseSymbol.Checked = value;
            }
        }

        /// <summary>
        /// Model Name Level
        /// </summary>
        public int ModelNameLevel
        {
            get
            {
                return cbAssemblyNameLevel.SelectedIndex;
            }
            set
            {
                cbAssemblyNameLevel.SelectedIndex = value;
            }
        }

        /// <summary>
        /// Symbol Text
        /// </summary>
        public string SymbolText
        {
            get
            {
                return txtSymbolText.Text;
            }
            set
            {
                txtSymbolText.Text = value;
            }
        }

        /// <summary>
        /// Construction
        /// </summary>
        public SurfaceNoteDialog()
        {
            InitializeComponent();

            ///미구현
            ckUseSymbol.Visible = false;
            txtSymbolText.Visible = false;
            label1.Visible = false;
            cbAssemblyNameLevel.Visible = false;
            label2.Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtText.Text) == true) return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSelectModel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            lbLength.Invoke(new EventHandler(delegate
            {
                lbLength.Text = string.Format("({0:#0} / {1:#0})", txtText.Text.Length, txtText.MaxLength);
            }));
        }
    }
}