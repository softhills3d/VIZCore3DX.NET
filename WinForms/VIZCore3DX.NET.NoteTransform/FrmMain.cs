using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.NoteTransform
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DXControl vizcore3dx;

        // 노드 하나에 여러 노트 연결
        private Dictionary<int, List<uint>> nodeNoteMap = new Dictionary<int, List<uint>>();

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            // Event
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

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            List<Node> nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP)?.Where(x => x != null).ToList() ?? new List<Node>();

            // 선택된 개체가 없으면 ROOT 노드 사용
            if (nodes.Count == 0)
            {
                Node root = vizcore3dx.Object3D.FromFilter(Object3dFilter.ROOT)?.FirstOrDefault(x => x != null);
                if (root == null) return;

                nodes.Add(root);
            }

            // 대상 노드 목록 표시
            lvNodes.BeginUpdate();
            lvNodes.Items.Clear();

            foreach (Node node in nodes)
                lvNodes.Items.Add(new ListViewItem(new string[] { node.Index.ToString(), node.NodeName }) { Tag = node });

            lvNodes.EndUpdate();

            // 대상 노드에 노트 생성
            vizcore3dx.BeginUpdate();

            foreach (Node node in nodes)
            {
                Vertex3D surface = node.GetCenter();
                Vertex3D text = surface.Clone();
                text.Z += 1000.0f;

                uint noteId = vizcore3dx.Note.AddNoteSurface(node.NodeName, text, surface);

                if (nodeNoteMap.TryGetValue(node.Index, out List<uint> noteIds) == false)
                    nodeNoteMap[node.Index] = noteIds = new List<uint>();

                noteIds.Add(noteId);
            }

            vizcore3dx.EndUpdate();
        }

        private void btnClearNote_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Note.Clear();
            nodeNoteMap.Clear();
            lvNodes.Items.Clear();
        }

        private void btnGetSelectedNodes_Click(object sender, EventArgs e)
        {
            List<Node> nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP)?.Where(x => x != null).ToList();
            if (nodes == null || nodes.Count == 0) return;

            lvNodes.BeginUpdate();
            lvNodes.Items.Clear();

            foreach (Node node in nodes)
                lvNodes.Items.Add(new ListViewItem(new string[] { node.Index.ToString(), node.NodeName }) { Tag = node });

            lvNodes.EndUpdate();
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtAngleX.Text, out float x) == false || float.TryParse(txtAngleY.Text, out float y) == false || float.TryParse(txtAngleZ.Text, out float z) == false) return;

            List<Node> nodes = lvNodes.Items.Cast<ListViewItem>().Select(item => item.Tag as Node).Where(node => node != null).ToList();
            if (nodes.Count == 0) return;

            // 화면 갱신 차단
            vizcore3dx.BeginUpdate();

            // 기존 선택 해제 후 대상 노드 회전
            vizcore3dx.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);
            vizcore3dx.Object3D.Select(nodes, true, true);
            vizcore3dx.Object3D.Transform.Rotate(x, y, z, false);

            // 화면 갱신 차단 해제
            vizcore3dx.EndUpdate();
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtDistanceX.Text, out float x) == false || float.TryParse(txtDistanceY.Text, out float y) == false || float.TryParse(txtDistanceZ.Text, out float z) == false) return;

            List<Node> nodes = lvNodes.Items.Cast<ListViewItem>().Select(item => item.Tag as Node).Where(node => node != null).ToList();
            if (nodes.Count == 0) return;

            // 화면 갱신 차단
            vizcore3dx.BeginUpdate();

            // 기존 선택 해제 후 노드 이동
            vizcore3dx.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);
            vizcore3dx.Object3D.Transform.Move(nodes, x, y, z, false);

            // 이동 노드와 하위 노드 중 노트가 연결된 노드 조회
            Dictionary<int, Node> noteNodes = new Dictionary<int, Node>();

            foreach (Node movedNode in nodes)
            {
                if (nodeNoteMap.ContainsKey(movedNode.Index) == true)
                    noteNodes[movedNode.Index] = movedNode;

                List<Node> children = vizcore3dx.Object3D.GetChildObject3d(movedNode, Object3DChildOption.ALL_CHILDREN);
                if (children == null) continue;

                foreach (Node child in children)
                {
                    if (child != null && nodeNoteMap.ContainsKey(child.Index) == true)
                        noteNodes[child.Index] = child;
                }
            }

            // 이동값에 맞춰 연결된 노트 위치 갱신
            foreach (Node node in noteNodes.Values)
            {
                List<uint> newNoteIds = new List<uint>();

                foreach (uint noteId in nodeNoteMap[node.Index].ToList())
                {
                    NoteItem note = vizcore3dx.Note.GetItem(noteId);
                    if (note == null || note.IsDeleted == true) continue;

                    Vertex3D text = new Vertex3D(note.TextPosition.X + x, note.TextPosition.Y + y, note.TextPosition.Z + z);
                    Vertex3D surface = node.GetCenter();

                    vizcore3dx.Note.Delete(noteId);
                    newNoteIds.Add(vizcore3dx.Note.AddNoteSurface(node.NodeName, text, surface, false));
                }

                if (newNoteIds.Count > 0)
                    nodeNoteMap[node.Index] = newNoteIds;
                else
                    nodeNoteMap.Remove(node.Index);
            }

            // 화면 갱신 차단 해제
            vizcore3dx.EndUpdate();
        }
    }
}