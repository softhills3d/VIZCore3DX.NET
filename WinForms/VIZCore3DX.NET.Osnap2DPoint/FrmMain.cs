using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.Osnap2DPoint
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DXControl vizcore3dx;

        // 좌표 찍기 중에는 버튼을 다시 눌러도 새로 시작하지 않습니다.
        private bool _picking;

        // 카메라를 움직이는 마우스 동작
        private static readonly InputAction[] CameraActions =
        {
            InputAction.Orbit, InputAction.Pan, InputAction.ZoomDrag, InputAction.Roll, InputAction.LookAround,
            InputAction.ZoomWheel, InputAction.Tilt, InputAction.CenterViewAtCursor, InputAction.FitAtCursor, InputAction.SetPivotAtCursor
        };

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

            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }

        // 위에서 내려다본 2D 화면으로 고정하고, Esc 로 끝낼 때까지 Osnap 한 지점마다 XY 좌표 노트를 찍습니다.
        private async void btnShowOsnap_Click(object sender, EventArgs e)
        {
            if (_picking) return;
            if (vizcore3dx.Object3D.GetNodeCount() <= 0) return;

            _picking = true;
            LockTopView();
            try
            {
                while (true)
                {
                    OsnapResult result = await CreatePointOsnap().GetResultAsync();
                    if (result?.Position == null) break;   // Esc 등으로 취소하면 종료

                    AddPointNote(result.Position.ToVertex3D());
                }
            }
            finally
            {
                UnlockTopView();
                _picking = false;
            }
        }

        // 점 스냅만 켠 Osnap
        private OsnapController CreatePointOsnap()
        {
            OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();
            osnap.EdgeEndpointSnap = true;
            osnap.EdgeMidpointSnap = true;
            osnap.PlaneSnap = false;
            osnap.LineSnap = false;
            osnap.CircleSnap = false;
            osnap.CircleCenterSnap = false;
            osnap.CylinderSnap = false;
            osnap.CommandText = "모서리 끝점·중점을 선택하세요. (Esc : 종료)";

            vizcore3dx.Focus();
            return osnap;
        }

        // 선택 위치의 XY 좌표를 노트로 표시
        private void AddPointNote(Vertex3D surfacePos)
        {
            Vertex3D notePos = surfacePos + new Vector3D(0.0f, 500.0f, 0.0f);
            string text = string.Format("{0:F2}, {1:F2}", surfacePos.X, surfacePos.Y);

            vizcore3dx.Note.AddNoteSurface(text, notePos, surfacePos, false);
        }

        // 평면도(Z+ 위에서 내려다봄) + 정사영으로 맞추고, 카메라를 움직이는 입력을 모두 막습니다.
        private void LockTopView()
        {
            vizcore3dx.View.EnableAnimation = false;
            vizcore3dx.View.EnableAutoFit = false;
            vizcore3dx.View.Projection = Projections.Orthographic;
            vizcore3dx.View.MoveCamera(CameraDirection.Z_PLUS);
            vizcore3dx.View.RotationAngle = 0.0f;

            List<InputBindingItem> bindings = vizcore3dx.Input.GetCustomBindings();
            foreach (InputBindingItem item in bindings)
            {
                if (Array.IndexOf(CameraActions, item.Action) >= 0) item.Assigned = false;
            }
            vizcore3dx.Input.ApplyCustomBindings(bindings);

            vizcore3dx.View.NavigationDragMode = NavigationDragMode.NONE;
            vizcore3dx.Shortcuts.Enable = false;
            vizcore3dx.ViewCube.Enable = false;
            vizcore3dx.View.Toolbar.Enable = false;
        }

        // 좌표 찍기를 끝내면 카메라 입력과 투영 방식을 기본값으로 되돌립니다.
        private void UnlockTopView()
        {
            vizcore3dx.Input.ResetCustomBindings();

            vizcore3dx.Shortcuts.Enable = true;
            vizcore3dx.ViewCube.Enable = true;
            vizcore3dx.View.Toolbar.Enable = true;
            vizcore3dx.View.Projection = Projections.Perspective;
            vizcore3dx.View.EnableAutoFit = true;
            vizcore3dx.View.EnableAnimation = true;
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