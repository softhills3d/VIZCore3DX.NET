using System;
using System.Windows.Forms;

namespace VIZCore3DX.NET.CameraDataSaver
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// VIZCore3DX.NET Control
        /// </summary>
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        private VIZCore3DX.NET.Data.CameraData cameraData { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            // VIZCore3DX Module Init
            VIZCore3DX.NET.ModuleInitializer.Run();
            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            // Panel Control Add
            splitContainer1.Panel2.Controls.Add(vizcore3dx);
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

            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();
        }

        /// <summary>
        /// 카메라 데이터 저장 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCameraSave_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            // 카메라 데이터 저장 
            cameraData = vizcore3dx.View.GetCameraData();
            if (cameraData != null)
            {
                MessageBox.Show("현재 화면이 저장되었습니다.");

                #region Console Visual Text
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===========================================");
                Console.WriteLine("             Camera Data                   ");
                Console.WriteLine("===========================================");

                // Camera Direction
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Camera Direction : ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"X = {cameraData.CameraDirection.X}, Y = {cameraData.CameraDirection.Y}, Z = {cameraData.CameraDirection.Z}");

                // Eye Position
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Eye Position     : ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"X = {cameraData.EyePosition.X}, Y = {cameraData.EyePosition.Y}, Z = {cameraData.EyePosition.Z}");

                // Pivot Position
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Pivot Position   : ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"X = {cameraData.PivotPosition.X}, Y = {cameraData.PivotPosition.Y}, Z = {cameraData.PivotPosition.Z}");

                // Projection Type
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Projection Type  : ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{cameraData.ProjectionType}");

                // Up Direction
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Up Direction     : ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"X = {cameraData.UpDirection.X}, Y = {cameraData.UpDirection.Y}, Z = {cameraData.UpDirection.Z}");

                // Zoom
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Zoom Level       : ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{cameraData.Zoom}");

                // Fov
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Fov              : ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{cameraData.Fov}");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===========================================");

                Console.ResetColor();
                #endregion

                return;
            }
        }

        /// <summary>
        /// 카메라 데이터 로드 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCameraLoad_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            if (cameraData == null) return;

            // 카메라 데이터 로드
            // 실제 필요한 카메라 데이터 [ CameraDirection, EyePosition, PivotPosition, ProjectionType, UpDirection, Zoom, Fov ]
            vizcore3dx.View.SetCameraData(cameraData);
        }

        /// <summary>
        /// 액션 카메라 데이터 로드 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActionLoad_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            if (cameraData == null) return;

            // 카메라 액션 이동 시간 지정
            TimeSpan timeSpan = TimeSpan.FromSeconds(Convert.ToInt64(numCameraMoveTime.Value));

            // 카메라 데이터 로드 및 이동 시간 할당
            vizcore3dx.View.SetCameraData(cameraData, timeSpan);
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
