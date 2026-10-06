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

                // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
                vizcore3dx.RibbonMode = true;
                ShowRibbonTabs();
                ShowAttributeTabs();

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

            List<Node> nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.ALL_INCLUDE_BODY);

            if (nodes == null || nodes.Count == 0)
            {
                MessageBox.Show("ALL_INCLUDE_BODY 결과가 없습니다.");
                return;
            }

            lvNode.BeginUpdate();

            try
            {
                lvNode.Items.Clear();

                foreach (Node item in nodes.OrderBy(x => x.Index))
                {
                    // 하위 모든 노드의 Mesh Count 합
                    ulong meshCount = item.GetAllChildrenMeshCount();
                    if (meshCount == 0) continue;

                    BoundBox3D boundBox = item.GetBoundBox();
                    if (boundBox == null || boundBox.IsValid() == false) continue;

                    float volume = boundBox.LengthX * boundBox.LengthY * boundBox.LengthZ;
                    long averageMesh = Convert.ToInt64(volume / meshCount * 0.01f);

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
                    vizcore3dx.View.FlyToObject3d(new List<Node>() { node });
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

        // 지정한 탭만 남기고 나머지 툴바(=리본 탭)와 모델 트리 패널의 같은 탭을 숨깁니다. 홈 탭·모델 트리는 항상 표시합니다.
        private void ShowRibbonTabs(params VIZCore3DX.NET.Data.ToolbarKind[] keep)
        {
            foreach (VIZCore3DX.NET.Data.ToolbarKind kind in Enum.GetValues(typeof(VIZCore3DX.NET.Data.ToolbarKind)))
                vizcore3dx.Toolbar.SetVisible(kind, kind == VIZCore3DX.NET.Data.ToolbarKind.Main || Array.IndexOf(keep, kind) >= 0);

            vizcore3dx.TabSnapshotEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Snapshot) >= 0;
            vizcore3dx.TabNotetEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Note) >= 0;
            vizcore3dx.TabMeasureEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Measure) >= 0;
            vizcore3dx.TabSectionEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Section) >= 0;
            vizcore3dx.TabDecalEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Decal) >= 0;
            vizcore3dx.TabSelectionBoxEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.SelectionBox) >= 0;
            vizcore3dx.TabZoneEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Zone) >= 0;
            vizcore3dx.TabEffectEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Effect) >= 0;
            vizcore3dx.TabObserverEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Observer) >= 0;
        }

        // 속성 패널은 노드 특성·노드 속성만 기본으로 남기고, 예제가 다루는 탭만 켭니다.
        private void ShowAttributeTabs(bool attributeTree = false, bool nodeGroup = false, bool projection = false, bool pmi = false)
        {
            vizcore3dx.TabAttributeTreeEnabled = attributeTree;
            vizcore3dx.TabNodeGroupEnabled = nodeGroup;
            vizcore3dx.TabProjectionEnabled = projection;
            vizcore3dx.TabPmiEnabled = pmi;
            vizcore3dx.TabEnvironmentEnabled = false;
            vizcore3dx.TabGenericDataEnabled = false;
            vizcore3dx.AttributePanelVisible = attributeTree || nodeGroup || projection || pmi;
        }
    }
}