using ShdCore.NET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ShdNodeAttribute = ShdCore.NET.NodeAttribute;
using ShdNodeKind = ShdCore.NET.NodeKind;
using ShdStructureManager = ShdCore.NET.StructureManager;
using ShdTreeNode = ShdCore.NET.TreeNode;
using WinTreeNode = System.Windows.Forms.TreeNode;

// <summary>
// VIZCore3DX.NET Structure
// x64로 빌드 후 실행. ZstdNet.dll, ShdCore.NET.dll, VIZCore3DX.NET.dll, TreeNodeImage 파일이 실행파일과 동일한 폴더에 존재해야 함.
// </summary>

namespace VIZCore3DX.NET.Structure
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DXControl vizcore3dx;
        private ShdStructureManager Structure { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            tvStructure.ImageList = imgList;

            // Initialize VIZCore3DX.NET
            ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            //License
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
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

            if (result != Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 모델 로드
            InitializeVIZCore3DX();
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

        private void btnVIZX_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = vizcore3dx.Model.OpenFilter;
                if (dlg.ShowDialog() != DialogResult.OK) return;

                Cursor = Cursors.WaitCursor;

                try
                {
                    ShowStructure(dlg.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("모델 구조를 불러오는 중 오류가 발생했습니다.\n\n{0}", ex.Message), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void ShowStructure(string path)
        {
            if (string.IsNullOrWhiteSpace(path) == true || File.Exists(path) == false)
            {
                MessageBox.Show("VIZX 파일을 찾을 수 없습니다.", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtVIZX.Text = path;

            // 기존에 로드된 트리 구조 제거
            tvStructure.Nodes.Clear();
            lvProperty.Items.Clear();

            // 모델 로드
            Structure = new ShdStructureManager(
                path,                     // VIZX 파일 경로 및 파일이름
                attribute: true,          // 노드별 속성 로드
                mesh: true,               // 노드별 트라이앵글 메시 카운트 로드
                includeBody: false        // Body/BodySet/Face 노드 트리 포함 여부
            );

            // 모델 트리 생성
            MakeModelTree();
        }

        private void MakeModelTree()
        {
            if (Structure == null || Structure.Roots == null) return;

            // 처리된 모델 구조 불러오기
            List<ShdTreeNode> roots = Structure.Roots;

            tvStructure.BeginUpdate();
            tvStructure.Nodes.Clear();

            // 최상위는 파일 노드이므로, 파일이름으로 생성
            WinTreeNode rootNode = tvStructure.Nodes.Add(Path.GetFileNameWithoutExtension(txtVIZX.Text));
            rootNode.ImageIndex = 0;
            rootNode.SelectedImageIndex = 0;

            // 최상위 루트 기준
            foreach (ShdTreeNode node in roots)
                BindNode(rootNode, node);

            // 최상위 노드 펼치기
            rootNode.Expand();

            tvStructure.EndUpdate();
        }

        private void BindNode(WinTreeNode parentNode, ShdTreeNode node)
        {
            if (node == null) return;

            // 트리 노드 생성
            WinTreeNode childNode = parentNode.Nodes.Add(node.Name);
            childNode.Tag = node;

            switch (node.Kind)
            {
                case ShdNodeKind.ASSEMBLY:
                    childNode.ImageIndex = 1;
                    childNode.SelectedImageIndex = 1;
                    break;

                case ShdNodeKind.PART:
                    childNode.ImageIndex = 2;
                    childNode.SelectedImageIndex = 2;
                    break;

                case ShdNodeKind.BODY:
                    childNode.ImageIndex = 3;
                    childNode.SelectedImageIndex = 3;
                    break;
            }

            // 하위 노드가 있는 경우, 재귀 호출
            if (node.Nodes == null) return;

            foreach (ShdTreeNode child in node.Nodes)
                BindNode(childNode, child);
        }

        private void tvStructure_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Structure == null || e.Node.Tag == null) return;

            ShdTreeNode node = (ShdTreeNode)e.Node.Tag;

            // 선택된 노드의 속성정보 불러오기
            List<ShdNodeAttribute> attributes = Structure.GetAttribute(Convert.ToInt32(node.EntityID));

            lvProperty.BeginUpdate();
            lvProperty.Items.Clear();

            if (attributes != null)
            {
                foreach (ShdNodeAttribute item in attributes)
                    lvProperty.Items.Add(new ListViewItem(new string[] { item.Key, item.Value }));
            }

            lvProperty.EndUpdate();
        }
    }
}