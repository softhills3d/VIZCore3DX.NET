using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.MeshCount
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 현재 정렬 기준 컬럼
        private ColumnHeader sortingColumn;

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
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

            try
            {
                // ================================================================
                // 설정 - 툴바
                // ================================================================
                vizcore3dx.ToolbarMain.Visible = true;
                vizcore3dx.ToolbarNote.Visible = false;
                vizcore3dx.ToolbarMeasure.Visible = false;
                vizcore3dx.ToolbarSection.Visible = false;
                vizcore3dx.ToolbarSnapshot.Visible = false;
            }
            finally
            {
                // ================================================================
                // 모델 열기 시, 3D 화면 Rendering 재시작
                // ================================================================
                vizcore3dx.EndUpdate();
            }
        }

        // ================================================
        // Event - 목록 조회 버튼 클릭
        // ================================================
        private void btnView_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            // ============================================================
            // 1. 시작은 무조건 ALL_INCLUDE_BODY
            // ============================================================
            List<Node> bodyItems = vizcore3dx.Object3D.FromFilter(Object3dFilter.ALL_INCLUDE_BODY);

            if (bodyItems == null || bodyItems.Count == 0)
            {
                MessageBox.Show("ALL_INCLUDE_BODY 결과가 없습니다.");
                return;
            }

            // ============================================================
            // 2. Body마다 부모를 한 번만 타고 올라가면서
            //    - resultNodes (화면에 표시할 노드 목록)
            //    - childMap (노드 key -> 그 아래 포함된 Body 목록)
            //    를 동시에 만든다.
            // ============================================================
            HashSet<string> addedNodeSet = new HashSet<string>();
            List<Node> resultNodes = new List<Node>();
            Dictionary<string, List<Node>> childMap = new Dictionary<string, List<Node>>();

            // Body별 Mesh Count도 여기서 같이 캐싱해 중복 GetMeshCount 호출 방지
            Dictionary<string, ulong> meshCache = new Dictionary<string, ulong>();

            foreach (Node body in bodyItems)
            {
                if (body == null) continue;

                string bodyKey = body.EntityID + "-" + body.Index;

                if (meshCache.ContainsKey(bodyKey) == false)
                    meshCache[bodyKey] = body.GetMeshCount();

                Node current = body;

                while (current != null)
                {
                    // Index만 쓰면 파일 여러 개 열었을 때 충돌 가능해서 EntityID + Index 조합 사용
                    string key = current.EntityID + "-" + current.Index;

                    if (addedNodeSet.Add(key) == true)
                        resultNodes.Add(current);

                    List<Node> childBodies;

                    if (childMap.TryGetValue(key, out childBodies) == false)
                    {
                        childBodies = new List<Node>();
                        childMap.Add(key, childBodies);
                    }

                    childBodies.Add(body);

                    Node parent;

                    try
                    {
                        parent = vizcore3dx.Object3D.GetParentNode(current);
                    }
                    catch
                    {
                        parent = null;
                    }

                    if (parent == null) break;

                    // 혹시 자기 자신이 부모로 반환되는 경우 무한루프 방지
                    if (parent.Index == current.Index && parent.EntityID == current.EntityID) break;

                    current = parent;
                }
            }

            resultNodes = resultNodes.OrderBy(x => x.Index).ToList();

            lvNode.BeginUpdate();

            try
            {
                lvNode.Items.Clear();

                foreach (Node item in resultNodes)
                {
                    if (item == null) continue;

                    string itemKey = item.EntityID + "-" + item.Index;

                    // ============================================================
                    // 3. item 아래 포함된 Body는 이제 childMap에서 바로 꺼내기만 함
                    // ============================================================
                    List<Node> childBodies;

                    if (childMap.TryGetValue(itemKey, out childBodies) == false || childBodies == null || childBodies.Count == 0) continue;

                    // ============================================================
                    // 4. Mesh Count 계산 (캐시에서 조회, 재계산 없음)
                    // ============================================================
                    ulong meshCount = 0;

                    foreach (Node body in childBodies)
                    {
                        string bodyKey = body.EntityID + "-" + body.Index;
                        ulong bodyMesh;

                        if (meshCache.TryGetValue(bodyKey, out bodyMesh) == true && bodyMesh > 0)
                            meshCount += bodyMesh;
                    }

                    if (meshCount == 0) continue;

                    // ============================================================
                    // 5. BoundBox 계산
                    // ============================================================
                    BoundBox3D boundBox;

                    try
                    {
                        boundBox = vizcore3dx.Object3D.GeometryProperty.FromNode(childBodies, false).GetBoundBox();
                    }
                    catch
                    {
                        boundBox = null;
                    }

                    if (boundBox == null || boundBox.IsValid() == false) continue;

                    float volume = boundBox.LengthX * boundBox.LengthY * boundBox.LengthZ;
                    int averageMesh = Convert.ToInt32(volume / meshCount * 0.01f);

                    ListViewItem lvi = new ListViewItem(new string[]
                    {
                        item.EntityID.ToString(),
                        item.Index.ToString(),
                        item.NodeName,
                        string.Format("{0:#,0}", meshCount),
                        string.Format("{0:#,0}", volume * 0.001f),
                        string.Format("{0:#,0}", averageMesh),
                        boundBox.ToString()
                    });

                    lvi.Tag = item;
                    lvNode.Items.Add(lvi);
                }
            }
            finally
            {
                lvNode.EndUpdate();
            }
        }

        // ================================================
        // Event - 목록 더블클릭 (해당 부품으로 화면 이동)
        // ================================================
        private void lvNode_DoubleClick(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            if (lvNode.SelectedItems.Count == 0) return;

            Node node = lvNode.SelectedItems[0].Tag as Node;
            if (node == null) return;

            vizcore3dx.BeginUpdate();

            try
            {
                if (vizcore3dx.View.XRay.Enable == true)
                {
                    vizcore3dx.View.XRay.Clear();

                    // XRay.Select() 인자 : 인덱스 목록(List<int>) → Node 목록(List<Node>) 으로 변경
                    vizcore3dx.View.XRay.Select(new List<Node>() { node }, true, true);
                }

                // Object3D.Select() 인자 : 인덱스 목록(List<int>) → Node 목록(List<Node>) 으로 변경
                vizcore3dx.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);
                vizcore3dx.Object3D.Select(new List<Node>() { node }, true, true);

                if (ckFly.Checked == true)
                    vizcore3dx.View.FlyToObject3d();
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        // ================================================
        // Event - 컬럼 클릭 (정렬)
        // ================================================
        private void lvNode_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader newSortingColumn = lvNode.Columns[e.Column];
            SortOrder sortOrder;

            if (sortingColumn == null)
            {
                sortOrder = SortOrder.Ascending;
            }
            else
            {
                if (newSortingColumn == sortingColumn)
                    sortOrder = sortingColumn.Text.StartsWith("> ") ? SortOrder.Descending : SortOrder.Ascending;
                else
                    sortOrder = SortOrder.Ascending;

                if (sortingColumn.Text.StartsWith("> ") || sortingColumn.Text.StartsWith("< "))
                    sortingColumn.Text = sortingColumn.Text.Substring(2);
            }

            sortingColumn = newSortingColumn;

            if (sortingColumn.Text.StartsWith("> ") || sortingColumn.Text.StartsWith("< "))
                sortingColumn.Text = sortingColumn.Text.Substring(2);

            sortingColumn.Text = (sortOrder == SortOrder.Ascending ? "> " : "< ") + sortingColumn.Text;

            // ListViewComparer - 기존과 동일하게 사용
            lvNode.ListViewItemSorter = new ListViewComparer(e.Column, sortOrder);
            lvNode.Sort();
        }

        // ================================================
        // Event - X-Ray 체크박스
        // ================================================
        private void ckXray_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.BeginUpdate();

            try
            {
                if (ckXray.Checked == true)
                {
                    // XRay 켜기
                    vizcore3dx.View.XRay.Enable = true;

                    // XRay 스타일 설정
                    vizcore3dx.View.XRay.ColorType = XRayColorTypes.OBJECT_COLOR;
                    vizcore3dx.View.XRay.SelectionObject3DType = SelectionObject3DTypes.ALL;
                    vizcore3dx.View.XRay.EdgeRendering = true;

                    // 일반 선택색/외곽선 끄기
                    vizcore3dx.View.SelectionColorEnabled = false;
                    vizcore3dx.View.SelectionOutlineEnabled = false;
                }
                else
                {
                    // XRay 끄기
                    vizcore3dx.View.XRay.Clear();
                    vizcore3dx.View.XRay.Enable = false;

                    // 일반 선택 표시 복구
                    vizcore3dx.View.SelectionColorEnabled = true;
                    vizcore3dx.View.SelectionOutlineEnabled = true;
                }
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }
    }
}