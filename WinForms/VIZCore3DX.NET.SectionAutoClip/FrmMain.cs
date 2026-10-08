using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;
using VIZCore3DX.NET.Manager;

namespace VIZCore3DX.NET.SectionAutoClip
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

            // 모델 로드
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

            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs(VIZCore3DX.NET.Data.ToolbarKind.Section);
            ShowAttributeTabs();


            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }
        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.Object3D.OnNodeEvent += Object3D_OnNodeEvent;
        }
        private void Object3D_OnNodeEvent(object sender, EventManager.NodeEventArgs e)
        {
            // 기능 활성화 여부 확인
            bool enable = ckEnable.Checked;

            // 비활성화 상태이면 처리하지 않음
            if (enable == false) return;

            // 선택 해제 또는 선택된 객체가 없으면 단면을 제거하고 종료
            if (e.EventKind == Object3DManager.NodeEventKind.SELECTION_UNSELECTED_NODE || e.Node == null || e.Node.Count == 0)
            {
                vizcore3dx.Section.Clear();
                return;
            }

            // 단면 생성 옵션 읽기
            bool modelBoundBox = ckModelBoundBox.Checked;
            bool parentObject = ckParentObject.Checked;
            bool margin = ckMargin.Checked;

            // 여백 값 읽기
            float marginX = 0.0f;
            float marginY = 0.0f;
            float marginZ = 0.0f;

            if (margin == true && (float.TryParse(txtX.Text, out marginX) == false || float.TryParse(txtY.Text, out marginY) == false || float.TryParse(txtZ.Text, out marginZ) == false))
            {
                MessageBox.Show("여백 값을 숫자로 입력해 주세요.");
                return;
            }

            BoundBox3D sectionBoxSize;

            // 선택이 변경된 경우에만 단면을 갱신
            if (e.EventKind == Object3DManager.NodeEventKind.SELECTION_CHANGED_NODE)
            {
                // 단면 기준 BoundBox 결정
                if (modelBoundBox == true)
                {
                    // 모델 전체 BoundBox 사용
                    sectionBoxSize = vizcore3dx.Model.BoundBox;
                }
                else
                {
                    if (parentObject == false)
                    {
                        // 선택된 객체들의 BoundBox 사용
                        sectionBoxSize = vizcore3dx.Object3D.GeometryProperty.FromSelectedObject3D().GetBoundBox();
                    }
                    else
                    {
                        // 선택된 노드 기준 상위 노드의 BoundBox 계산
                        List<Node> selectedTopNodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP);

                        if (selectedTopNodes == null || selectedTopNodes.Count == 0) return;

                        Node selectedNode = selectedTopNodes[0];

                        Node parent1 = vizcore3dx.Object3D.GetParentNode(selectedNode);
                        if (parent1 == null) return;

                        sectionBoxSize = vizcore3dx.Object3D.GeometryProperty.FromNode(new List<Node> { parent1 }, true).GetBoundBox();
                    }
                }

                // 설정된 여백만큼 단면 영역 확장
                if (margin == true)
                {
                    sectionBoxSize.MinX -= marginX * 0.5f;
                    sectionBoxSize.MinY -= marginY * 0.5f;
                    sectionBoxSize.MinZ -= marginZ * 0.5f;

                    sectionBoxSize.MaxX += marginX * 0.5f;
                    sectionBoxSize.MaxY += marginY * 0.5f;
                    sectionBoxSize.MaxZ += marginZ * 0.5f;
                }

                // 단면 생성 및 노트 표시 상태 갱신
                vizcore3dx.BeginUpdate();

                SectionItem section = vizcore3dx.Section.AddBox(false);
                if (section != null) vizcore3dx.Section.SetBoxSize(section.ID, sectionBoxSize);

                vizcore3dx.EndUpdate();
            }
        }


        private void btnHandleMove_Click(object sender, EventArgs e)
        {
            // 단면 조작 핸들 표시
            vizcore3dx.Section.ShowHandle(true);
        }

        private void btnClearSection_Click(object sender, EventArgs e)
        {
            // 생성된 모든 단면 제거
            vizcore3dx.Section.Clear();
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            // 모델이 열려있지 않으면 종료
            if (vizcore3dx.Model.IsOpen() == false) return;

            // 선택된 최상위 객체 목록 조회
            List<Node> items = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP);

            vizcore3dx.BeginUpdate();

            // 각 객체 중심 위치에 노트 생성
            foreach (Node item in items)
            {
                Vertex3D center = item.GetCenter();  // 모델 중심
                vizcore3dx.Note.AddNoteSurface(item.NodeName, center, center);
            }

            vizcore3dx.EndUpdate();
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
