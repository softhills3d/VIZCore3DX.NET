using System;
using System.IO;
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

            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            splitContainer1.Panel2.Controls.Add(vizcore3dx);
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================
            // 라이선스 파일을 통한 인증
            //vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("127.0.0.1", 8901);

            // ================================================================
            // License
            // ================================================================
            // VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");
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
            vizcore3dx.Snapshot.OnSnapshotRestored += Snapshot_OnSnapshotRestored;
        }

        private void Snapshot_OnSnapshotRestored(object sender, Event.EventManager.SnapshotEventArgs e)
        {
            // Snapshot Restored
            VIZCore3DX.NET.Data.SnapshotItem item = vizcore3dx.Snapshot.GetItem(e.ID);
            lblJsonStatus.Text = string.Format("스냅샷을 복원했습니다. ID: {0}, 이름: {1}", e.ID, item == null ? string.Empty : item.Text);
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
            // Export Snapshot(마크업) to JSON File
            if (vizcore3dx.Model.IsOpen() == false) return;

            if (listView1.Items.Count == 0) return;

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "JSON 파일 (*.json)|*.json|모든 파일 (*.*)|*.*";
                dialog.FileName = Path.GetFileName(textBox1.Text);
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                textBox1.Text = dialog.FileName;
            }

            if (vizcore3dx.Model.ExportMarkupJson(textBox1.Text, true, true, true, true, true, true) == false)
            {
                ShowOperationFailure("내보내기에 실패했습니다.", vizcore3dx.Model.LastOperationStatus);
                return;
            }

            lblJsonStatus.Text = "내보내기가 완료됐습니다.";
            MessageBox.Show(lblJsonStatus.Text, "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Import Snapshot(마크업) from JSON File
            if (vizcore3dx.Model.IsOpen() == false) return;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "JSON 파일 (*.json)|*.json|모든 파일 (*.*)|*.*";
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                textBox1.Text = dialog.FileName;
            }

            if (vizcore3dx.Model.ImportMarkupJson(textBox1.Text, true, true, true, true, true, true) == false)
            {
                ShowOperationFailure("불러오기에 실패했습니다.", vizcore3dx.Model.LastOperationStatus);
                return;
            }

            RefreshSnapshotList();

            lblJsonStatus.Text = "불러오기가 완료됐습니다.";
            MessageBox.Show(lblJsonStatus.Text, "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RefreshSnapshotList()
        {
            tempSnapshot = null;
            listView1.Items.Clear();

            if (vizcore3dx.Snapshot.Snapshots.Count == 0) return;

            foreach (var item in vizcore3dx.Snapshot.Snapshots)
            {
                ListViewItem listView = new ListViewItem(new string[] { item.ID.ToString(), item.Text });

                listView1.Items.Add(listView);
            }
        }

        private void ShowOperationFailure(string message, VIZCore3DX.NET.Data.OperationStatus status)
        {
            string detail = status == null ? string.Empty : string.Format("\n원인 : {0}", status.Result);

            lblJsonStatus.Text = message;
            MessageBox.Show(message + detail, "Snapshot", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
