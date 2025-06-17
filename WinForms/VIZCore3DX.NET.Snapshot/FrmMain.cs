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
    public partial class FrmMain : Form
    {
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        private VIZCore3DX.NET.Data.SnapshotItem tempSnapshot;

        public FrmMain()
        {
            InitializeComponent();

            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;

            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3D_OnInitializedVIZCore3D;

            splitContainer1.Panel2.Controls.Add(vizcore3dx);
        }

        private void VIZCore3D_OnInitializedVIZCore3D(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================
            // 라이선스 파일을 통한 인증
            //vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            //vizcore3dx.License.LicenseServer("127.0.0.1", 8901);

            // ================================================================
            // License
            // ================================================================
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("192.168.0.215", 8901);
            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeVIZCore3DX();
            InitializeVIZCore3DXEvent();
        }

        private void InitializeVIZCore3DX()
        {
            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 차단
            // ================================================================
            vizcore3dx.BeginUpdate();

            // ================================================================
            // 설정 - 툴바
            // ================================================================
            vizcore3dx.ToolbarMain.Visible = true;
            vizcore3dx.ToolbarNote.Visible = false;
            vizcore3dx.ToolbarMeasure.Visible = false;
            vizcore3dx.ToolbarSection.Visible = false;
            vizcore3dx.ToolbarSnapshot.Visible = true;

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }
        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.Model.OnModelOpenedEvent += Model_OnModelOpenedEvent;
            vizcore3dx.Model.OnModelClosedEvent += Model_OnModelClosedEvent;
            vizcore3dx.Snapshot.OnSnapshotCreated += Snapshot_OnSnapshotCreated;
        }

        private void Model_OnModelClosedEvent(object sender, EventArgs e)
        {
            // Model Close
            tempSnapshot = null;
            listView1.Items.Clear();
        }

        private void Model_OnModelOpenedEvent(object sender, EventArgs e)
        {
            //Model Open
            tempSnapshot = null;
            listView1.Items.Clear();
        }

        private void Snapshot_OnSnapshotCreated(object sender, Event.EventManager.SnapshotEventArgs e)
        {
            // Snapshot Created
            if (vizcore3dx.Snapshot.GetItem(e.ID).Text.Equals("Snapshot"))
            {
                tempSnapshot = vizcore3dx.Snapshot.GetItem(e.ID);
            }
        }

        private void btnAddSnapshot_Click(object sender, EventArgs e)
        {
            // Add Snapshot
            if (vizcore3dx.Model.IsOpen() == false) return;

            AddSnapshotDialog dlg = new AddSnapshotDialog();
            DialogResult dlgResult = dlg.ShowDialog();

            uint ID = 0;

            if (dlgResult == DialogResult.OK)
            {
                if (tempSnapshot != null)
                {
                    ID = tempSnapshot.ID;
                    vizcore3dx.Snapshot.EditSnapshotText(ID, dlg.SnapshotName);
                    tempSnapshot = null;
                }
                else
                {
                    ID = vizcore3dx.Snapshot.Add(dlg.SnapshotName);
                }

                if (ID > 0)
                {
                    ListViewItem listView = new ListViewItem(new string[] { ID.ToString(), vizcore3dx.Snapshot.GetItem(ID).Text });

                    listView1.Items.Add(listView);
                }
            }            
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            // Restore Snapshot
            if (vizcore3dx.Model.IsOpen() == false) return;

            var selectedItem = listView1.SelectedItems[0].Text;

            vizcore3dx.Snapshot.GetItem(uint.Parse(selectedItem)).Restore();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Export Snapshot to JSON File
            if (vizcore3dx.Model.IsOpen() == false) return;

            if (listView1.Items.Count == 0) return;

            //if (vizcore3dx.Snapshot.ExportJson(textBox1.Text)
            if (vizcore3dx.Model.ExportMarkupJson(textBox1.Text, true, true, true, true, true))
            {
                MessageBox.Show("Export Success", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Export Failed", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Import Snapshot from JSON File
            if (vizcore3dx.Model.IsOpen() == false) return;

            //vizcore3dx.Snapshot.ImportJson(textBox1.Text);
            vizcore3dx.Model.ImportMarkupJson(textBox1.Text, true, true, true, true, true);

            tempSnapshot = null;
            listView1.Items.Clear();

            if (vizcore3dx.Snapshot.Snapshots.Count == 0) return;

            foreach (var item in vizcore3dx.Snapshot.Snapshots)
            {
                ListViewItem listView = new ListViewItem(new string[] { item.ID.ToString(), item.Text });

                listView1.Items.Add(listView);
            }
        }
    }
}
