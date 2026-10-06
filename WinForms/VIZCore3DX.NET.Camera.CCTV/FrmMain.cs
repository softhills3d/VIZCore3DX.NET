using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.Camera.CCTV
{
    public partial class FrmMain : Form
    {
        private const float RotateDegree = 0.6f;

        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // Timer
        private System.Windows.Forms.Timer loopTimer;

        // 회전 축 (0 : Right(상하), 1 : Up(좌우)) 과 각도
        private int rotateAxis;
        private float rotateAngle;

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

            // Sample Position
            AddCctvItem("CCTV #1", new Vertex3D(18200, 4095, 17354));
            AddCctvItem("CCTV #2", new Vertex3D(18300, -7741, 12679));
            AddCctvItem("CCTV #3", new Vertex3D(18415, -5890, 17340));

            // Timer
            loopTimer = new System.Windows.Forms.Timer();
            loopTimer.Tick += LoopTimer_Tick;
        }

        private void AddCctvItem(string name, Vertex3D position)
        {
            ListViewItem item = new ListViewItem(new string[] { name, position.X.ToString(), position.Y.ToString(), position.Z.ToString() });
            item.Tag = position;
            lvList.Items.Add(item);
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

        private void InitializeVIZCore3DXEvent()
        {
            // 마우스로 개체 클릭했을 때
            vizcore3dx.Object3D.OnNodeClick -= Object3D_OnNodeClick;
            vizcore3dx.Object3D.OnNodeClick += Object3D_OnNodeClick;

            // 모델 열었을 때
            vizcore3dx.Model.OnModelOpenedEvent -= Model_OnModelOpenedEvent;
            vizcore3dx.Model.OnModelOpenedEvent += Model_OnModelOpenedEvent;
        }

        private void Model_OnModelOpenedEvent(object sender, EventManager.ModelOpendEventArgs e)
        {
            // 슬라이더 초기값(60)을 카메라 FOV에 반영
            tbFOV_ValueChanged(tbFOV, EventArgs.Empty);
        }

        private void Object3D_OnNodeClick(object sender, EventManager.NodeMouseEventArgs e)
        {
            // 클릭된 노드가 없는 경우 예외 처리
            if (e.Node == null) return;

            UpdateCameraDirection();
        }

        private void ckSilhouetteEdge_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.View.SilhouetteEdge = ckSilhouetteEdge.Checked;
        }

        private void ckRealtimeShadow_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.View.RealtimeShadow = ckRealtimeShadow.Checked;
        }

        private void ckShadingEffect_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.View.ShadingEffect = ckShadingEffect.Checked;
        }

        private void ckEnvironmentLight_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.View.EnvironmentLight = ckEnvironmentLight.Checked;
        }

        private void LoopTimer_Tick(object sender, EventArgs e)
        {
            if (vizcore3dx == null) return;
            if (vizcore3dx.Model.IsOpen() == false) return;

            RotateCamera();
            UpdateCameraDirection();
        }

        private void RotateCamera()
        {
            // 카메라 로컬축 (0 : Right, 1 : Up, 2 : 시선 방향)
            List<Vector3D> axis = vizcore3dx.View.GetCameraAxis();
            if (axis == null) return;

            // 카메라 위치 기준 회전
            vizcore3dx.View.RotateCamera(axis[rotateAxis], rotateAngle, TimeSpan.Zero);
        }

        private void lvList_MouseDoubleClick(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            if (lvList.SelectedItems.Count == 0) return;

            Vertex3D cameraPosition = lvList.SelectedItems[0].Tag as Vertex3D;

            // 모델 중심을 바라볼 대상으로 사용
            MoveCamera(cameraPosition, vizcore3dx.View.GetCameraData().ModelCenter);
        }

        private void MoveCamera(Vertex3D cameraPosition, Vertex3D targetPosition)
        {
            // 카메라 이동 시 시점이 임의로 틀어지는 문제를 방지하기 위해 Perspective로 고정
            vizcore3dx.View.Projection = Projections.Perspective;

            // CCTV 위치 → 대상 방향
            Vector3D dir = (targetPosition.ToVector3D() - cameraPosition.ToVector3D()).GetNormalized();
            if (dir.IsZero() == true) return;

            // 화면이 기울지 않도록 월드 Z(수직으로 볼 때는 Y)를 기준으로 Up 계산
            Vector3D worldUp = Math.Abs(dir.Z) > 0.95f ? new Vector3D(0, 1, 0) : new Vector3D(0, 0, 1);
            Vector3D up = dir.Cross(worldUp).Cross(dir).GetNormalized();

            vizcore3dx.View.SetPerspectiveCamera(cameraPosition.ToVector3D(), dir, up);
            vizcore3dx.View.SetPivotPosition(targetPosition);

            // 카메라 이동 후 UI 값도 현재 상태와 맞춤
            UpdateCameraDirection();
        }

        private void EnableLoop(int axis, float angle)
        {
            rotateAxis = axis;
            rotateAngle = angle;
            loopTimer.Start();
        }

        private void DisableLoop()
        {
            loopTimer.Stop();
        }

        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            EnableLoop(0, RotateDegree);
        }

        private void btnUp_MouseUp(object sender, MouseEventArgs e)
        {
            DisableLoop();
        }

        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            EnableLoop(1, RotateDegree);
        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            DisableLoop();
        }

        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            EnableLoop(1, -RotateDegree);
        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            DisableLoop();
        }

        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            EnableLoop(0, -RotateDegree);
        }

        private void btnDown_MouseUp(object sender, MouseEventArgs e)
        {
            DisableLoop();
        }

        private void tbFOV_ValueChanged(object sender, EventArgs e)
        {
            numFOV.Value = tbFOV.Value;

            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.View.Projection = Projections.Perspective;
            vizcore3dx.View.SetFov(tbFOV.Value, false, TimeSpan.Zero);
        }

        private void numFOV_ValueChanged(object sender, EventArgs e)
        {
            // 입력값을 슬라이더에 반영 (FOV 적용은 tbFOV_ValueChanged 에서)
            tbFOV.Value = (int)numFOV.Value;
        }

        private void UpdateCameraDirection()
        {
            if (vizcore3dx == null) return;
            if (vizcore3dx.Model.IsOpen() == false) return;
            if (IsHandleCreated == false) return;

            // 렌더/카메라 반영 후 읽도록 UI 큐 뒤로 밀기
            BeginInvoke((MethodInvoker)UpdateCameraDirectionText);
        }

        private void UpdateCameraDirectionText()
        {
            CameraData camera = vizcore3dx.View.GetCameraData();

            if (camera == null || camera.CameraDirection == null) return;

            txtDirX.Text = camera.CameraDirection.X.ToString("F4");
            txtDirY.Text = camera.CameraDirection.Y.ToString("F4");
            txtDirZ.Text = camera.CameraDirection.Z.ToString("F4");
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