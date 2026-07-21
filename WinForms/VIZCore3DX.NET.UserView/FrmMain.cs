using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.UserView
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DXControl vizcore3dx;

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(vizcore3dx);

            // license 인증
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            tvUserView.ImageList = imgList;
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================
            // 라이선스 파일을 통한 인증
            //vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            Data.LicenseResults result = vizcore3dx.License.LicenseServer("192.168.100.252", 8901);

            // ================================================================
            // License
            // ================================================================
            // VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");
            if (result != Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeVIZCore3DX();
            InitializeVIZCore3DEvent();
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
            vizcore3dx.ToolbarSnapshot.Visible = false;

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }

        private void InitializeVIZCore3DEvent()
        {
            vizcore3dx.Model.OnModelOpenedEvent += Model_OnModelOpenedEvent;
            vizcore3dx.Model.OnModelClosedEvent += Model_OnModelClosedEvent;
        }

        private void Model_OnModelClosedEvent(object sender, EventArgs e)
        {
            InitControl();
        }

        private void Model_OnModelOpenedEvent(object sender, EventManager.ModelOpendEventArgs e)
        {
            InitControl();

            List<string> files = vizcore3dx.Model.Files;
            string path = files[0];
            vizcore3dx.Model.ImportMarkupJson(path, false, false, false, true, false, false);

            ImportSnapshotTree();

            string file = TreePath();
            if (string.IsNullOrWhiteSpace(file) == false && File.Exists(file)) LoadTree(file);
        }

        private void InitControl()
        {
            tvUserView.Nodes.Clear();
            pbImage.Image = null;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            vizcore3dx.Model.OpenFileDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Model.SaveFileDialog();

            string file = TreePath();
            if (string.IsNullOrWhiteSpace(file) == false) SaveTree(file);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Snapshot.Clear();

            bool result = vizcore3dx.Model.ImportMarkupJsonDialog(
                false,  // 노트
                false,  // 측정
                false,  // 단면
                true,   // 스냅샷
                false,  // 데칼
                false   // 격자
            );

            if (result == false) return;

            ImportSnapshotTree();

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "스냅샷 폴더 불러오기";
                dlg.Filter = "Snapshot Tree (*.snapshotTree.xml)|*.snapshotTree.xml";

                if (dlg.ShowDialog() == DialogResult.OK) LoadTree(dlg.FileName);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            bool result = vizcore3dx.Model.ExportMarkupJsonDialog(false, false, false, true, false, false); // 노트, 측정, 단면, 스냅샷, 데칼, 격자
            if (result == false) return;

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = "스냅샷 폴더 저장";
                dlg.Filter = "Snapshot Tree (*.snapshotTree.xml)|*.snapshotTree.xml";
                dlg.FileName = "SnapshotTree.snapshotTree.xml";

                if (dlg.ShowDialog() != DialogResult.OK) return;

                SaveTree(dlg.FileName);
            }

            MessageBox.Show("저장 완료");
        }

        private void ImportSnapshotTree()
        {
            tvUserView.Nodes.Clear();

            List<Data.SnapshotItem> items = vizcore3dx.Snapshot.Snapshots;
            if (items == null || items.Count == 0) return;

            foreach (Data.SnapshotItem item in items)
            {
                TreeNode snapshot = new TreeNode(item.Text, 2, 2);
                snapshot.Name = item.ID.ToString();
                snapshot.Tag = item;

                tvUserView.Nodes.Add(snapshot);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string name = string.Format("Snapshot #{0}", tvUserView.GetNodeCount(true));

            // Add 결과 ID 받기
            uint id = vizcore3dx.Snapshot.Add(name);

            Data.SnapshotItem item = vizcore3dx.Snapshot.GetItem(id);
            if (item == null) return;

            // 미리보기 이미지 표시
            System.Drawing.Image img = vizcore3dx.Snapshot.GetSnapshotImage(id);

            if (img == null) img = vizcore3dx.View.CaptureImage();
            if (img != null) pbImage.Image = img;

            // TreeNode에 SnapshotItem 연결
            TreeNode snapshot = new TreeNode(item.Text, 2, 2);
            snapshot.Name = id.ToString();
            snapshot.Tag = item;

            if (tvUserView.SelectedNode != null && tvUserView.SelectedNode.Tag != null && tvUserView.SelectedNode.Tag.ToString() == "FOLDER_TYPE")
            {
                tvUserView.SelectedNode.Nodes.Add(snapshot);
                tvUserView.SelectedNode.Expand();
            }
            else
            {
                tvUserView.Nodes.Add(snapshot);
            }

            tvUserView.SelectedNode = snapshot;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            TreeNode selectedNode = tvUserView.SelectedNode;

            if (selectedNode == null) tvUserView.Nodes.Clear();
            else selectedNode.Remove();

            tvUserView.SelectedNode = null;
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            int snapshotCount = 0;
            CountSnpshots(tvUserView.Nodes, ref snapshotCount);

            MessageBox.Show($"현재 등록된 전체 스냅샷의 개수는 {snapshotCount}개 입니다.", "노드 카운트", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CountSnpshots(TreeNodeCollection nodes, ref int snapshotCount)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag == null || node.Tag.ToString() != "FOLDER_TYPE") snapshotCount++;
                if (node.Nodes.Count > 0) CountSnpshots(node.Nodes, ref snapshotCount);
            }
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            VIZCore3DX.NET.Dialogs.AddNodeDialog dlg = new VIZCore3DX.NET.Dialogs.AddNodeDialog();
            dlg.NodeName = "Node...";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            string nodeName = dlg.NodeName;
            TreeNode node = new TreeNode(nodeName, 0, 1);
            node.Tag = "FOLDER_TYPE";

            if (tvUserView.SelectedNode == null)
            {
                tvUserView.Nodes.Add(node);
            }
            else
            {
                TreeNode selectedNode = tvUserView.SelectedNode;

                if (selectedNode.Tag != null && selectedNode.Tag.ToString() == "FOLDER_TYPE")
                {
                    // 선택한 게 폴더가 맞다면, 그 폴더의 자식으로 새 폴더를 집어넣음 (폴더 인 폴더)
                    selectedNode.Nodes.Add(node);
                    selectedNode.Expand(); // 펼치기
                }
                else
                {
                    if (selectedNode.Parent != null) selectedNode.Parent.Nodes.Add(node);
                    else tvUserView.Nodes.Add(node);
                }
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false || tvUserView.SelectedNode == null) return;

            TreeNode selectedNode = tvUserView.SelectedNode;

            Dialogs.AddNodeDialog dlg = new Dialogs.AddNodeDialog();
            dlg.NodeName = selectedNode.Text;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            string newName = dlg.NodeName.Trim();

            if (selectedNode.Tag != null && selectedNode.Tag.ToString() == "FOLDER_TYPE")
            {
                selectedNode.Text = newName;
                return;
            }
        }

        private void ckAnimation_CheckedChanged(object sender, EventArgs e)
        {
            tvUserView.SelectedNode = null;
        }

        private async void tvUserView_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = tvUserView.SelectedNode;
            if (node == null || node.Tag == null) return;

            // 폴더면 펼치기/접기
            if (node.Tag.ToString() == "FOLDER_TYPE")
            {
                node.Toggle();
                return;
            }

            // 스냅샷이면 해당 시점으로 이동
            if (node.Tag is Data.SnapshotItem item)
            {
                System.Drawing.Image img = vizcore3dx.Snapshot.GetSnapshotImage(item.ID);
                pbImage.Image = img;

                if (ckView.Checked == false) return;

                if (ckAnimation.Checked == true)
                {
                    // 애니메이션 적용
                    item.Restore(TimeSpan.FromSeconds(1.0));
                    await Task.Delay(1000);
                }
                else
                {
                    // 즉시 복구
                    item.Restore();
                }
            }
        }

        private void ckView_CheckedChanged(object sender, EventArgs e)
        {
            if (ckView.Checked == false) ckAnimation.Checked = false;
        }

        // 모델 파일 옆에 저장할 폴더트리 XML 경로
        private string TreePath()
        {
            if (vizcore3dx.Model.IsOpen() == false) return null;
            if (vizcore3dx.Model.Files == null || vizcore3dx.Model.Files.Count == 0) return null;

            return Path.ChangeExtension(vizcore3dx.Model.Files[0], ".snapshotTree.xml");
        }

        // TreeView 구조 저장
        private void SaveTree(string file)
        {
            if (string.IsNullOrWhiteSpace(file)) return;

            XElement root = new XElement("SnapshotTree");

            foreach (TreeNode node in tvUserView.Nodes)
            {
                XElement elem = ToXml(node);
                if (elem != null) root.Add(elem);
            }

            new XDocument(root).Save(file);
        }

        // TreeNode -> XML
        private XElement ToXml(TreeNode node)
        {
            if (node == null) return null;

            XElement elem = null;

            // 폴더 저장
            if (node.Tag != null && node.Tag.ToString() == "FOLDER_TYPE")
            {
                elem = new XElement("Node", new XAttribute("Type", "Folder"), new XAttribute("Text", node.Text));
            }
            // 스냅샷 저장
            else if (node.Tag is Data.SnapshotItem item)
            {
                elem = new XElement("Node", new XAttribute("Type", "Snapshot"), new XAttribute("Text", item.Text), new XAttribute("ID", item.ID));
            }
            else
            {
                return null;
            }

            // 자식도 같이 저장
            foreach (TreeNode child in node.Nodes)
            {
                XElement childElem = ToXml(child);
                if (childElem != null) elem.Add(childElem);
            }

            return elem;
        }

        // XML에서 TreeView 구조 복원
        private void LoadTree(string file)
        {
            if (string.IsNullOrWhiteSpace(file)) return;
            if (File.Exists(file) == false) return;

            XDocument doc = XDocument.Load(file);
            if (doc.Root == null) return;

            tvUserView.BeginUpdate();
            tvUserView.Nodes.Clear();

            foreach (XElement elem in doc.Root.Elements("Node"))
            {
                TreeNode node = ToTreeNode(elem);
                if (node != null) tvUserView.Nodes.Add(node);
            }

            tvUserView.EndUpdate();
        }

        // XML -> TreeNode
        private TreeNode ToTreeNode(XElement elem)
        {
            if (elem == null) return null;

            string type = elem.Attribute("Type")?.Value ?? "";
            string text = elem.Attribute("Text")?.Value ?? "";
            TreeNode node = null;

            // 폴더 복원
            if (type == "Folder")
            {
                node = new TreeNode(text, 0, 1);
                node.Tag = "FOLDER_TYPE";
            }
            // 스냅샷 복원
            else if (type == "Snapshot")
            {
                uint id = 0;
                uint.TryParse(elem.Attribute("ID")?.Value, out id);

                Data.SnapshotItem item = null;
                if (id > 0) item = vizcore3dx.Snapshot.GetItem(id);
                if (item == null) item = vizcore3dx.Snapshot.Snapshots.FirstOrDefault(x => x.Text == text);
                if (item == null) return null;

                node = new TreeNode(item.Text, 2, 2);
                node.Name = item.ID.ToString();
                node.Tag = item;
            }

            if (node == null) return null;

            // 자식 복원
            foreach (XElement child in elem.Elements("Node"))
            {
                TreeNode childNode = ToTreeNode(child);
                if (childNode != null) node.Nodes.Add(childNode);
            }

            return node;
        }
    }
}