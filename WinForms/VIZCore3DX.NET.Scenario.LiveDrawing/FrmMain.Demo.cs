using System;
using System.Drawing;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Scenario.LiveDrawing
{
    // 시연 연출 — 키 처리·카메라 이동·화면 문구·리본/패널 탭 정리. SDK 기능 사용과 무관하니 건너뛰어도 됩니다.
    public partial class FrmMain
    {
        #region 키

        // 재생 중에도 Esc 로 멈출 수 있게 합니다.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape && _runner.IsPlaying)
            {
                _runner.Reset();
                _onCameraArrived = null;
                SetStatus("재생을 중단했습니다.");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region 카메라

        // 3D 뷰를 도면과 똑같이 보이게 합니다. 평행 투영으로 바꾸고 도면의 오른쪽·위쪽이 화면의 오른쪽·위쪽이 되게 돌린 다음,
        // box 가 화면에 들어오도록 맞춥니다. (평행 투영에서는 거리가 아니라 맞춤으로 크기를 정합니다)
        private void LookLikeDrawing(Data.ProjectionItem item, Data.BoundBox3D box, double seconds)
        {
            Data.Vector3D up = TurnToDrawing(item, box, seconds);

            // 화면 위쪽으로 상자를 조금 늘려 맞춰, 대상이 리본 바로 아래에 붙지 않게 합니다.
            Data.Vector3D min = new Data.Vector3D(box.GetVertexMin());
            Data.Vector3D max = new Data.Vector3D(box.GetVertexMax());
            Data.Vector3D room = up * (box.MaxLength * ScenarioScript.TopRoom);
            Data.Vector3D low = new Data.Vector3D(Math.Min(min.X, min.X + room.X), Math.Min(min.Y, min.Y + room.Y), Math.Min(min.Z, min.Z + room.Z));
            Data.Vector3D high = new Data.Vector3D(Math.Max(max.X, max.X + room.X), Math.Max(max.Y, max.Y + room.Y), Math.Max(max.Z, max.Z + room.Z));
            _runner.After(seconds + 0.1, () => vizcore3dx.View.FlyToBoundingBox(low, high, 1.0f, TimeSpan.FromSeconds(1.0)));
        }

        // 평행 투영으로 바꾸고, 도면의 오른쪽·위쪽이 화면의 오른쪽·위쪽이 되게 카메라를 돌립니다. 화면 위쪽 방향을 돌려줍니다.
        private Data.Vector3D TurnToDrawing(Data.ProjectionItem item, Data.BoundBox3D box, double seconds)
        {
            vizcore3dx.View.Projection = Data.Projections.Orthographic;

            Data.Vector3D view, up;
            DrawingAxes(item, out view, out up);
            FlyCamera(new Data.Vector3D(box.GetCenter()), view, FitDistance(box.MaxLength), seconds, up);
            return up;
        }

        // 원근 투영으로 바꾸고 카메라를 비스듬히 기울여 블록 도면이 블록 위 허공에 떠 있는 모습을 보인 뒤,
        // 잠시 머물렀다가 천천히 위에서 내려다보는 방향(도면과 같은 화면)으로 돌아옵니다.
        private void TiltToFloatingDrawing(double seconds)
        {
            vizcore3dx.View.Projection = Data.Projections.Perspective;
            Data.Vector3D between = new Data.Vector3D(_blockBox.CenterX, _blockBox.CenterY, (_blockBox.CenterZ + DrawingPlane().Z) * 0.5f);

            // 바라보는 지점을 화면 오른쪽으로 옮기면 블록이 화면 왼쪽으로 옵니다(오른쪽 도구 모음에 가리지 않게).
            Data.Vector3D right = Data.Vector3D.Cross(ScenarioScript.ViewFloating, new Data.Vector3D(0f, 0f, 1f)).GetNormalized();
            Data.Vector3D target = between + right * (_blockBox.MaxLength * ScenarioScript.FloatingShift);
            FlyCamera(target, ScenarioScript.ViewFloating, FitDistance(_blockBox.MaxLength) * ScenarioScript.FloatingZoom, seconds);

            _runner.After(ScenarioScript.FloatingHoldSeconds, () => ReturnToDrawing(ScenarioScript.FloatingReturnSeconds));
        }

        // 기울였던 카메라를 seconds 초 동안 천천히 도면과 같은 방향으로 되돌리고, 다 돌아오면 평행 투영으로 맞춥니다.
        private void ReturnToDrawing(double seconds)
        {
            Data.Vector3D view, up;
            DrawingAxes(_blockDrawing, out view, out up);
            FlyCamera(new Data.Vector3D(_blockBox.GetCenter()), view, FitDistance(_blockBox.MaxLength), seconds, up);
            WhenCameraArrives(() => LookLikeDrawing(_blockDrawing, _blockBox, 0.5));
        }

        // 도면을 정면으로 보는 3D 시선과 위 방향을 구합니다.
        private void DrawingAxes(Data.ProjectionItem item, out Data.Vector3D view, out Data.Vector3D up)
        {
            // 도면 좌표의 두 축이 3D 에서 어느 방향인지 읽습니다. 뷰어는 도면의 +Y 를 화면 아래로 그리므로 화면 위쪽은 -Y 입니다.
            Data.Vector3D origin = item.LocalToWorld(new Data.Vector2(0f, 0f));
            Data.Vector3D right = (item.LocalToWorld(new Data.Vector2(1000f, 0f)) - origin).GetNormalized();
            up = (origin - item.LocalToWorld(new Data.Vector2(0f, 1000f))).GetNormalized();

            // 시선 = 위 × 오른쪽. 위 방향은 시선에 직교하는 이 값을 그대로 카메라에 넘깁니다.
            view = up.Cross(right);
        }

        // 크기 size 인 대상이 화면에 다 들어오는 카메라 거리를 시야각에서 구합니다.
        private float FitDistance(float size)
        {
            double fov = vizcore3dx.View.FOV;
            if (fov < 1.0 || fov > 120.0) fov = 30.0;

            return (float)(size * 0.5 / Math.Tan(fov * Math.PI / 360.0) * ScenarioScript.FitMargin);
        }

        // target 을 direction 방향으로 distance 만큼 떨어져 바라보도록 seconds 초 동안 이동합니다.
        // up 을 주지 않으면 Z 를 위로 삼습니다. 이때 direction 이 정확히 수직이면 안 됩니다.
        private void FlyCamera(Data.Vector3D target, Data.Vector3D direction, float distance, double seconds, Data.Vector3D up = null)
        {
            Data.CameraData camera = vizcore3dx.View.GetCameraData();
            if (camera == null) return;

            // 시선 방향 값의 부호는 지금 카메라가 쓰는 규칙을 그대로 따릅니다.
            Data.Vector3D current = new Data.Vector3D(camera.PivotPosition) - new Data.Vector3D(camera.EyePosition);
            float sign = current.Dot(new Data.Vector3D(camera.CameraDirection)) < 0f ? -1f : 1f;

            Data.Vector3D view = direction.GetNormalized();
            camera.PivotPosition = target.ToVertex3D();
            camera.EyePosition = (target - view * distance).ToVertex3D();
            camera.CameraDirection = (view * sign).ToVertex3D();

            // 위 방향은 시선에 직교해야 합니다. SetCameraData 가 시선에 맞게 다시 보정합니다.
            camera.UpDirection = (up ?? new Data.Vector3D(0f, 0f, 1f)).ToVertex3D();
            vizcore3dx.View.SetCameraData(camera, TimeSpan.FromSeconds(seconds));
        }

        #endregion

        #region 화면 문구·리본

        // 상태 문구를 창 제목줄에 적습니다.
        private void SetStatus(string text)
        {
            Text = "VIZCore3DX.NET.Scenario.LiveDrawing — " + text;
        }

        // 한 줄 입력 창을 띄웁니다. 취소하면 null 입니다.
        private string AskText(string title, string prompt, string value)
        {
            using (Form form = new Form())
            using (Label label = new Label())
            using (TextBox box = new TextBox())
            using (Button ok = new Button())
            using (Button cancel = new Button())
            {
                form.Text = title;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.ShowInTaskbar = false;
                form.ClientSize = new Size(360, 110);

                label.SetBounds(12, 12, 336, 20);
                label.Text = prompt;
                box.SetBounds(12, 38, 336, 23);
                box.Text = value;
                ok.SetBounds(192, 74, 75, 25);
                ok.Text = "확인";
                ok.DialogResult = DialogResult.OK;
                cancel.SetBounds(273, 74, 75, 25);
                cancel.Text = "취소";
                cancel.DialogResult = DialogResult.Cancel;

                form.Controls.AddRange(new Control[] { label, box, ok, cancel });
                form.AcceptButton = ok;
                form.CancelButton = cancel;
                return form.ShowDialog(this) == DialogResult.OK ? box.Text : null;
            }
        }

        // [블록] 버튼 아이콘 — 정육면체 윤곽. 리본이 넘겨 주는 색을 씁니다.
        private static void DrawBlockIcon(Graphics g, Rectangle b, Color color, bool enabled)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            float w = b.Width, h = b.Height, cx = b.X + w * 0.5f;
            PointF top = new PointF(cx, b.Y + h * 0.15f);
            PointF right = new PointF(b.X + w * 0.85f, b.Y + h * 0.33f);
            PointF rightLow = new PointF(b.X + w * 0.85f, b.Y + h * 0.67f);
            PointF bottom = new PointF(cx, b.Y + h * 0.85f);
            PointF leftLow = new PointF(b.X + w * 0.15f, b.Y + h * 0.67f);
            PointF left = new PointF(b.X + w * 0.15f, b.Y + h * 0.33f);
            PointF center = new PointF(cx, b.Y + h * 0.5f);

            using (Pen pen = new Pen(color, Math.Max(1.5f, w * 0.07f)) { LineJoin = System.Drawing.Drawing2D.LineJoin.Round })
            {
                g.DrawPolygon(pen, new[] { top, right, rightLow, bottom, leftLow, left });
                g.DrawLine(pen, center, left);
                g.DrawLine(pen, center, right);
                g.DrawLine(pen, center, bottom);
            }
        }

        // 지정한 탭만 남기고 나머지 툴바(=리본 탭)와 모델 트리 패널의 같은 탭을 숨깁니다. 홈 탭·모델 트리는 항상 표시합니다.
        private void ShowRibbonTabs(params VIZCore3DX.NET.Data.ToolbarKind[] keep)
        {
            foreach (VIZCore3DX.NET.Data.ToolbarKind kind in Enum.GetValues(typeof(VIZCore3DX.NET.Data.ToolbarKind)))
                vizcore3dx.Toolbar.SetVisible(kind, kind == VIZCore3DX.NET.Data.ToolbarKind.Main || Array.IndexOf(keep, kind) >= 0);

            // 남길 탭은 먼저 켜고(설정 파일로 꺼져 있을 수 있음), 그 다음 모델 트리를 뺀 나머지를 끕니다. 내장 탭 이름은 "tabPage" + 툴바 종류입니다.
            foreach (VIZCore3DX.NET.Data.ToolbarKind kind in keep)
                vizcore3dx.Panel.SetTabVisible(VIZCore3DX.NET.Data.PanelKind.ModelTree, "tabPage" + kind, true);

            foreach (string name in vizcore3dx.Panel.GetTabNames(VIZCore3DX.NET.Data.PanelKind.ModelTree))
            {
                if (name == "tabPageSceneTree") continue;
                bool show = Array.Exists(keep, kind => name == "tabPage" + kind);
                vizcore3dx.Panel.SetTabVisible(VIZCore3DX.NET.Data.PanelKind.ModelTree, name, show);
            }
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

        #endregion
    }
}
