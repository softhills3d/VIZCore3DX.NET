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
            vizcore3dx.ToolbarMain.Visible = true;
            vizcore3dx.ToolbarNote.Visible = false;
            vizcore3dx.ToolbarMeasure.Visible = false;
            vizcore3dx.ToolbarSection.Visible = true;
            vizcore3dx.ToolbarSnapshot.Visible = false;
            vizcore3dx.ToolbarClash.Visible = false;
            vizcore3dx.ToolbarDecal.Visible = false;
            vizcore3dx.ToolbarPrimitive.Visible = false;
            vizcore3dx.ToolbarAnimation.Visible = false;
            vizcore3dx.ToolbarSimulation.Visible = false;


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
            if (e.EventKind == Object3DManager.NodeEventKind.SELECTION_UNSELECTED_NODE || e.Node.Count == 0)
            {
                vizcore3dx.Section.Clear();
                return;
            }

            // 단면 생성 옵션 읽기
            bool modelBoundBox = ckModelBoundBox.Checked;
            bool parentObject = ckParentObject.Checked;
            bool margin = ckMargin.Checked;

            // 여백 값 읽기
            float marginX = Convert.ToSingle(txtX.Text);
            float marginY = Convert.ToSingle(txtY.Text);
            float marginZ = Convert.ToSingle(txtZ.Text);

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
                vizcore3dx.Section.SetBoxSize(section.ID, sectionBoxSize);

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


    }
}
