using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.SelectByBox_IncludeAssembly
{
    public partial class FrmMain : Form
    {
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

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
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("192.168.100.252", 8901);


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

        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore3dx.Model.OpenFilter;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Model.Open(dlg.FileName);
        }

        private void btnAddModels_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore3dx.Model.OpenFilter;
            dlg.Multiselect = true;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Model.Add(dlg.FileNames);
        }

        private void btnCloseModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Model.Close();
        }
        private void btnSelectByBox_Click(object sender, EventArgs e)
        {
            vizcore3dx.Object3D.SelectByBox(VIZCore3DX.NET.Data.Object3DSelectionBoxModes.MULTI);
        }
        private void btnSelectedAll_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> selectedNode = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_ALL);

            resultGrid.DataSource = selectedNode;
            resultGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            MessageBox.Show("조회된 노드 수 : " + selectedNode.Count + "개");
        }

        private void btnIncludeAssembly_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> selectedNode = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_ALL); // selectByBox로 선택한 PART 노드
            List<VIZCore3DX.NET.Data.Node> fullNode = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.ALL); // 모델의 전체 노드

            var mapFull = fullNode.ToDictionary(n => n.Index); // 전체 노드의 Index Dictionary

            var resultList = new List<Node>(selectedNode); // 결과 리스트
            var resultSet = new HashSet<int>(selectedNode.Select(x => x.Index)); // 중복 방지용 HashSet

            var queue = new Queue<Node>(); // 상위 탐색 큐
            var childCounts = new Dictionary<int, int>(); // 자식노드 개수

            foreach (var node in selectedNode) // [Step 1] 선택된 노드(PART)들의 부모 노드 찾기
            {
                // 딕셔너리에서 바로 Index로 부모 조회
                if (mapFull.TryGetValue(node.ParentIndex, out Node parent))
                {
                    if (resultSet.Add(parent.Index))
                    {
                        resultList.Add(parent);
                        queue.Enqueue(parent);
                    }
                }
            }

            while (queue.Count > 0) // [Step 2] 모든 자식이 있는 경우 상위 노드(Assembly) 찾기
            {
                var child = queue.Dequeue();

                if (mapFull.TryGetValue(child.ParentIndex, out Node parent))
                {
                    if (!childCounts.ContainsKey(parent.Index))
                        childCounts[parent.Index] = 0;

                    childCounts[parent.Index]++;

                    if (childCounts[parent.Index] == parent.ChildCount)
                    {
                        if (resultSet.Add(parent.Index))
                        {
                            resultList.Add(parent);
                            queue.Enqueue(parent);
                        }
                    }
                }
            }

            resultList.Sort((a, b) => a.Index.CompareTo(b.Index)); // Index 기준으로 리스트 정렬

            resultGrid.DataSource = resultList;
            resultGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            MessageBox.Show("조회된 노드 수 : " + resultList.Count + "개");
        }
    }
}
