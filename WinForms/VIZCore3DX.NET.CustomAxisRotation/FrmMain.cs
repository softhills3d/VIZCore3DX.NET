using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.CustomAxisRotation
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        private Vertex3D v1 = null;
        private Vertex3D v2 = null;
        private float angle = 0.0f;

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
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
            ShowRibbonTabs();
            ShowAttributeTabs();

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = vizcore3dx.Model.OpenFilter;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            // 진행 중인 회전 애니메이션 중지
            timerAnimation.Enabled = false;

            // 기존 모델 닫기 (적용된 회전 정보도 초기화)
            if (vizcore3dx.Model.IsOpen() == true) vizcore3dx.Model.Close();
            appliedAngle = 0.0f;
            appliedV1 = null;
            appliedV2 = null;

            // 모델 열기
            bool result = vizcore3dx.Model.Open(dlg.FileName);

            if (result == false)
            {
                MessageBox.Show("모델 열기 실패");
                return;
            }

            vizcore3dx.View.FitToView();

        }

        private async void btnShowOsnap_Click(object sender, EventArgs e)
        {
            if (vizcore3dx == null || vizcore3dx.Model.IsOpen() == false) return;

            OsnapController osnap1 = vizcore3dx.GeometryUtility.Osnap();
            if (osnap1 == null) return;

            osnap1.CommandText = "회전축 첫 번째 점 선택";
            OsnapResult r1 = await osnap1.GetResultAsync();
            if (r1 == null || r1.Position == null) return;

            Vertex3D p1 = r1.Position.ToVertex3D();
            txtV1.Text = p1.ToString();

            OsnapController osnap2 = vizcore3dx.GeometryUtility.Osnap();
            if (osnap2 == null) return;

            osnap2.CommandText = "회전축 두 번째 점 선택";
            OsnapResult r2 = await osnap2.GetResultAsync();
            if (r2 == null || r2.Position == null) return;

            Vertex3D p2 = r2.Position.ToVertex3D();
            txtV2.Text = p2.ToString();

            // 같은 점이면 회전축을 만들 수 없으므로 축으로 쓰지 않습니다.
            if (p1 == p2)
            {
                MessageBox.Show("회전축의 두 점이 같습니다. 서로 다른 두 점을 선택하세요.");
                return;
            }

            v1 = p1;
            v2 = p2;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            timerAnimation.Enabled = false;

            ResetRotation();

            txtV1.Text = String.Empty;
            txtV2.Text = String.Empty;

            v1 = null;
            v2 = null;

            angle = 0.0f;
            totalAngle = 0;
        }

        private int totalAngle = 0;

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (vizcore3dx == null || vizcore3dx.Model.IsOpen() == false) return;

            // 회전축 좌표 (Osnap 선택 또는 직접 입력한 값)
            v1 = ParseVertex(txtV1.Text);
            v2 = ParseVertex(txtV2.Text);
            if (v1 == null || v2 == null)
            {
                MessageBox.Show("회전축 좌표(V1, V2)를 \"X, Y, Z\" 형식으로 입력하세요.");
                return;
            }

            if (v1 == v2)
            {
                MessageBox.Show("회전축의 두 점이 같습니다. 서로 다른 두 점을 입력하세요.");
                return;
            }

            int start, end;
            if (int.TryParse(txtStart.Text, out start) == false || int.TryParse(txtEnd.Text, out end) == false)
            {
                MessageBox.Show("Start / End 각도를 정수로 입력하세요.");
                return;
            }

            timerAnimation.Enabled = false;

            // 이전 회전을 되돌린 뒤 새 축 기준으로 시작 각도까지 회전
            ResetRotation();
            RotateTo(start, v1, v2);

            angle = start;
            totalAngle = end;

            timerAnimation.Enabled = true;
        }

        // 현재 모델에 적용된 회전 각도와 그때 사용한 회전축
        private float appliedAngle = 0.0f;
        private Vertex3D appliedV1 = null;
        private Vertex3D appliedV2 = null;

        // 현재 상태 기준(zeroBase = false)으로 목표 각도와의 차이만큼 증분 회전
        // zeroBase = true 는 파일에 들어 있던 원래 배치 행렬까지 초기화해서 파트가 흩어짐
        private void RotateTo(float target, Vertex3D axis1, Vertex3D axis2)
        {
            List<Node> nodes = vizcore3dx.Object3D.GetRootNodes();
            if (nodes == null || nodes.Count == 0) return;

            float delta = target - appliedAngle;
            if (delta != 0.0f) vizcore3dx.Object3D.Transform.Rotate(nodes, axis1, axis2, delta, false);

            appliedAngle = target;
            appliedV1 = axis1;
            appliedV2 = axis2;
        }

        // 적용된 회전을 같은 축 기준 역회전으로 원래 상태로 복원
        private void ResetRotation()
        {
            if (appliedV1 != null && appliedV2 != null && appliedAngle != 0.0f && vizcore3dx != null && vizcore3dx.Model.IsOpen())
                RotateTo(0.0f, appliedV1, appliedV2);

            appliedAngle = 0.0f;
            appliedV1 = null;
            appliedV2 = null;
        }

        private Vertex3D ParseVertex(string text)
        {
            try
            {
                List<Vertex3D> vertices = Vertex3D.GetVertexList(text);
                return vertices.Count == 1 ? vertices[0] : null;
            }
            catch (Exception ex) when (ex is FormatException || ex is OverflowException)
            {
                return null;
            }
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            timerAnimation.Enabled = false;

            if (v1 == null || v2 == null) return;

            if (angle >= totalAngle) return;

            vizcore3dx.BeginUpdate();

            try
            {
                RotateTo(angle, v1, v2);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            angle += 3.0f;

            timerAnimation.Enabled = true;
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
