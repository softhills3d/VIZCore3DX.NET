using System;
using System.Globalization;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.Camera.CCTV
{
    public partial class FrmMain : Form
    {
        public enum CctvRotateDirection
        {
            UP = 0,
            DOWN = 1,
            LEFT = 2,
            RIGHT = 3
        }

        private const float RotateDegree = 0.6f;
        private const float DefaultLookDistance = 1000.0f;
        private const double MinVectorLength = 0.0001;
        private const double ParallelDotLimit = 0.95;

        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // Timer
        private System.Windows.Forms.Timer loopTimer;

        // Camera Direction
        private CctvRotateDirection CameraDir;

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
            AddCctvItem("CCTV #1", "18200", "4095", "17354");
            AddCctvItem("CCTV #2", "18300", "-7741", "12679");
            AddCctvItem("CCTV #3", "18415", "-5890", "17340");

            // Timer
            loopTimer = new System.Windows.Forms.Timer();
            loopTimer.Tick += LoopTimer_Tick;
        }

        private void AddCctvItem(string name, string x, string y, string z)
        {
            lvList.Items.Add(new ListViewItem(new string[] { name, x, y, z }));
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

        private void InitializeVIZCore3DXEvent()
        {
            // 마우스로 개체 클릭했을 때
            vizcore3dx.Object3D.OnNodeClick -= Object3D_OnNodeClick;
            vizcore3dx.Object3D.OnNodeClick += Object3D_OnNodeClick;
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

            RotateCamera(CameraDir);
            UpdateCameraDirection();
        }

        private void RotateCamera(CctvRotateDirection dir)
        {
            CameraData camera = vizcore3dx.View.GetCameraData();

            if (camera == null) return;
            if (camera.EyePosition == null) return;
            if (camera.CameraDirection == null) return;

            Vector3D eye = camera.EyePosition.ToVector3D();
            Vector3D forward = camera.CameraDirection.ToVector3D();
            Vector3D up = GetCameraUpVector(camera, forward);
            float lookDistance = GetLookDistance(camera);

            if (TryNormalize(ref forward) == false) return;

            if (TryNormalize(ref up) == false)
            {
                up = GetSafeCameraUpVector(forward);
            }

            Vector3D right = Cross(forward, up);

            if (TryNormalize(ref right) == false)
            {
                up = GetSafeCameraUpVector(forward);
                right = Cross(forward, up);
            }

            if (TryNormalize(ref right) == false) return;

            RotateCameraByLocalAxis(dir, ref forward, ref up, right);
            vizcore3dx.View.SetPerspectiveCamera(eye, forward, up);
        }

        private void RotateCameraByLocalAxis(CctvRotateDirection dir, ref Vector3D forward, ref Vector3D up, Vector3D right)
        {
            switch (dir)
            {
                case CctvRotateDirection.UP:
                    forward = RotateVector(forward, right, RotateDegree);
                    up = RotateVector(up, right, RotateDegree);
                    break;

                case CctvRotateDirection.DOWN:
                    forward = RotateVector(forward, right, -RotateDegree);
                    up = RotateVector(up, right, -RotateDegree);
                    break;

                case CctvRotateDirection.LEFT:
                    forward = RotateVector(forward, up, RotateDegree);
                    break;

                case CctvRotateDirection.RIGHT:
                    forward = RotateVector(forward, up, -RotateDegree);
                    break;
            }

            NormalizeCameraAxis(ref forward, ref up);
        }

        private void NormalizeCameraAxis(ref Vector3D forward, ref Vector3D up)
        {
            if (TryNormalize(ref forward) == false) return;

            if (TryNormalize(ref up) == false)
            {
                up = GetSafeCameraUpVector(forward);
            }

            Vector3D right = Cross(forward, up);

            if (TryNormalize(ref right) == false)
            {
                up = GetSafeCameraUpVector(forward);
                right = Cross(forward, up);
            }

            if (TryNormalize(ref right) == false) return;

            up = Cross(right, forward);

            if (TryNormalize(ref up) == false)
            {
                up = GetSafeCameraUpVector(forward);
            }
        }


        private Vector3D GetCameraUpVector(CameraData camera, Vector3D forward)
        {
            if (camera.UpDirection == null)
            {
                return GetSafeCameraUpVector(forward);
            }

            Vector3D up = camera.UpDirection.ToVector3D();

            if (TryNormalize(ref up) == false)
            {
                return GetSafeCameraUpVector(forward);
            }

            return up;
        }

        private float GetLookDistance(CameraData camera)
        {
            if (camera.EyePosition == null) return DefaultLookDistance;
            if (camera.PivotPosition == null) return DefaultLookDistance;

            Vector3D eye = camera.EyePosition.ToVector3D();
            Vector3D pivot = camera.PivotPosition.ToVector3D();
            Vector3D diff = SubtractVector(pivot, eye);
            double length = Length(diff);

            if (length <= MinVectorLength) return DefaultLookDistance;

            return (float)length;
        }

        private Vector3D RotateVector(Vector3D vector, Vector3D axis, double degree)
        {
            Vector3D normalAxis = new Vector3D(axis.X, axis.Y, axis.Z);

            if (TryNormalize(ref normalAxis) == false)
            {
                return vector;
            }

            double radian = degree * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            double dot = Dot(normalAxis, vector);
            Vector3D cross = Cross(normalAxis, vector);

            return new Vector3D(
                (vector.X * cos) + (cross.X * sin) + (normalAxis.X * dot * (1.0 - cos)),
                (vector.Y * cos) + (cross.Y * sin) + (normalAxis.Y * dot * (1.0 - cos)),
                (vector.Z * cos) + (cross.Z * sin) + (normalAxis.Z * dot * (1.0 - cos))
            );
        }

        private void lvList_MouseDoubleClick(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            if (TryGetSelectedCctvPosition(out Vertex3D cameraPosition) == false) return;

            // 현재 카메라의 Pivot을 바라볼 대상으로 사용
            VIZCore3DX.NET.Data.CameraData camera = vizcore3dx.View.GetCameraData();
            VIZCore3DX.NET.Data.Vertex3D targetPosition = camera.PivotPosition;

            MoveCamera(cameraPosition, targetPosition);
        }

        private bool TryGetSelectedCctvPosition(out Vertex3D position)
        {
            position = null;

            if (lvList.SelectedItems.Count == 0) return false;

            ListViewItem item = lvList.SelectedItems[0];

            if (item.SubItems.Count < 4) return false;

            if (TryParseFloat(item.SubItems[1].Text, out float x) == false) return false;
            if (TryParseFloat(item.SubItems[2].Text, out float y) == false) return false;
            if (TryParseFloat(item.SubItems[3].Text, out float z) == false) return false;

            position = new Vertex3D(x, y, z);

            return true;
        }

        private bool TryParseFloat(string text, out float value)
        {
            if (float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value) == true) return true;
            if (float.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out value) == true) return true;

            return false;
        }

        private void MoveCamera(Vertex3D cameraPosition, Vertex3D targetPosition)
        {
            // 카메라 이동 시 시점이 임의로 틀어지는 문제를 방지하기 위해 Perspective로 고정
            vizcore3dx.View.Projection = Projections.Perspective;

            Vector3D eye = cameraPosition.ToVector3D();
            Vector3D target = targetPosition.ToVector3D();

            // 카메라가 항상 targetPosition을 바라보도록 방향 벡터 계산
            Vector3D dir = new Vector3D(
                target.X - eye.X,
                target.Y - eye.Y,
                target.Z - eye.Z
            );

            // 카메라 위치와 대상 위치가 같으면 방향을 만들 수 없으므로 종료
            if (TryNormalize(ref dir) == false) return;

            // SetPerspectiveCamera에는 거리보다 방향이 중요하므로 단위 벡터로 정규화
            dir.Normalize();

            // 카메라 방향과 Up 방향이 겹치면 화면이 뒤집히거나 틀어질 수 있으므로 현재 방향에 맞는 안전한 Up 벡터를 새로 계산
            Vector3D up = GetSafeCameraUpVector(dir);

            // 카메라 위치, 바라보는 방향, 위쪽 방향을 명확히 지정
            vizcore3dx.View.SetPerspectiveCamera(eye, dir, up);

            // 카메라 이동 후 UI 값도 현재 상태와 맞춤
            UpdateCameraDirection();
        }

        private Vector3D GetSafeCameraUpVector(Vector3D dir)
        {
            // 기본 Up 방향은 월드 Z축을 사용
            Vector3D worldUp = new Vector3D(0, 0, 1);

            // 카메라 방향과 기본 Up 방향이 거의 평행한지 확인 평행에 가까우면 Cross 결과가 0에 가까워져 카메라 축이 불안정해짐
            if (Math.Abs(Dot(dir, worldUp)) > ParallelDotLimit)
            {
                // 카메라가 위/아래 방향을 거의 정면으로 볼 경우 Z축 대신 Y축을 임시 Up 기준으로 사용
                worldUp = new Vector3D(0, 1, 0);
            }

            // 카메라의 오른쪽 방향 계산
            Vector3D right = Cross(dir, worldUp);

            // 그래도 오른쪽 방향 계산이 실패하면 X축을 기준으로 다시 계산
            if (TryNormalize(ref right) == false)
            {
                worldUp = new Vector3D(1, 0, 0);
                right = Cross(dir, worldUp);
            }

            if (TryNormalize(ref right) == false)
            {
                return new Vector3D(0, 0, 1);
            }

            // right와 dir을 기준으로 실제 사용할 Up 방향을 다시 계산
            Vector3D correctedUp = Cross(right, dir);

            if (TryNormalize(ref correctedUp) == false)
            {
                return new Vector3D(0, 0, 1);
            }

            return correctedUp;
        }

        // 안정적인 Up 벡터를 계산하기 위해 Cross Product를 직접 구현
        private VIZCore3DX.NET.Data.Vector3D Cross(VIZCore3DX.NET.Data.Vector3D a, VIZCore3DX.NET.Data.Vector3D b)
        {
            return new VIZCore3DX.NET.Data.Vector3D(
                (a.Y * b.Z) - (a.Z * b.Y),
                (a.Z * b.X) - (a.X * b.Z),
                (a.X * b.Y) - (a.Y * b.X)
            );
        }

        private double Dot(Vector3D a, Vector3D b)
        {
            return
                (a.X * b.X) +
                (a.Y * b.Y) +
                (a.Z * b.Z);
        }

        private double Length(Vector3D v)
        {
            return Math.Sqrt(
                (v.X * v.X) +
                (v.Y * v.Y) +
                (v.Z * v.Z)
            );
        }

        private bool TryNormalize(ref Vector3D v)
        {
            if (Length(v) <= MinVectorLength) return false;

            v.Normalize();

            return true;
        }

        private Vector3D CopyVector(Vector3D v)
        {
            return new Vector3D(v.X, v.Y, v.Z);
        }

        private Vector3D AddVector(Vector3D a, Vector3D b)
        {
            return new Vector3D(
                a.X + b.X,
                a.Y + b.Y,
                a.Z + b.Z
            );
        }

        private Vector3D SubtractVector(Vector3D a, Vector3D b)
        {
            return new Vector3D(
                a.X - b.X,
                a.Y - b.Y,
                a.Z - b.Z
            );
        }

        private Vector3D MultiplyVector(Vector3D v, double value)
        {
            return new Vector3D(
                v.X * value,
                v.Y * value,
                v.Z * value
            );
        }

        private Vertex3D ToVertex3D(Vector3D v)
        {
            return new Vertex3D(
                (float)v.X,
                (float)v.Y,
                (float)v.Z
            );
        }

        private void EnableLoop(CctvRotateDirection dir)
        {
            CameraDir = dir;
            loopTimer.Start();
        }

        private void DisableLoop()
        {
            loopTimer.Stop();
        }

        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            EnableLoop(CctvRotateDirection.UP);
        }

        private void btnUp_MouseUp(object sender, MouseEventArgs e)
        {
            DisableLoop();
        }

        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            EnableLoop(CctvRotateDirection.LEFT);
        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            DisableLoop();
        }

        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            EnableLoop(CctvRotateDirection.RIGHT);
        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            DisableLoop();
        }

        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            EnableLoop(CctvRotateDirection.DOWN);
        }

        private void btnDown_MouseUp(object sender, MouseEventArgs e)
        {
            DisableLoop();
        }

        private void tbFOV_ValueChanged(object sender, EventArgs e)
        {
            lbFOV.Text = string.Format("VALUE : {0}", tbFOV.Value);

            if (vizcore3dx.Model.IsOpen() == false) return;

            CameraData camera = vizcore3dx.View.GetCameraData();

            if (camera == null) return;

            camera.ProjectionType = Projections.Perspective;
            camera.Fov = tbFOV.Value;

            vizcore3dx.View.SetCameraData(camera);
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


    }
}