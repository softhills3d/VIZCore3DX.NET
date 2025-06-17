using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Snapshot
{
    public partial class AddSnapshotDialog : Form
    {
        public string SnapshotName
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public AddSnapshotDialog()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void AddSnapshotDialog_Load(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(() => textBox1.Focus()));
        }
    }
}
