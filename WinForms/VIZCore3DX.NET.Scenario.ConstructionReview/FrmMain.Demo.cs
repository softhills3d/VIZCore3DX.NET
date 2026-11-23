using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Scenario.ConstructionReview
{
    // 시연 연출 — 키 처리·카메라 이동·화면 문구·리본/패널 탭 정리. SDK 기능 사용과 무관하니 건너뛰어도 됩니다.
    // (카메라 방향·여백 맞춤 FlyToBox 는 View.FlyToBoundingBox 를 씁니다.)
    public partial class FrmMain
    {
        // 3D 뷰에 띄운 문구
        private uint _hudNote;

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

        #region 카메라

        // box 가 화면에 다 들어오도록 direction 방향에서 seconds 초 동안 이동합니다(View.FlyToBoundingBox 의 방향·여백 오버로드).
        // zoom 이 1 보다 크면 그만큼 더 물러납니다 — 여백 비율 m 의 거리 배율이 1/(1-m) 이므로 배율에서 거꾸로 구합니다.
        private void FlyToBox(Data.BoundBox3D box, Data.Vector3D direction, double seconds, float zoom = 1f)
        {
            double margin = Math.Max(0.0, 1.0 - 1.0 / (ScenarioScript.FitMargin * zoom));
            vizcore3dx.View.FlyToBoundingBox(box, direction, margin, TimeSpan.FromSeconds(seconds));
        }

        // 크기 size 인 대상이 화면에 다 들어오는 카메라 거리를 시야각에서 구합니다.
        private float FitDistance(float size)
        {
            double fov = vizcore3dx.View.FOV;
            if (fov < 1.0 || fov > 120.0) fov = 30.0;

            return (float)(size * 0.5 / Math.Tan(fov * Math.PI / 360.0) * ScenarioScript.FitMargin);
        }

        // target 을 direction 방향으로 distance 만큼 떨어져 바라보도록 seconds 초 동안 이동합니다.
        // 위 방향은 Z 입니다. direction 이 정확히 수직이면 안 됩니다.
        private void FlyCamera(Data.Vector3D target, Data.Vector3D direction, float distance, double seconds)
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
            camera.UpDirection = new Data.Vector3D(0f, 0f, 1f).ToVertex3D();
            vizcore3dx.View.SetCameraData(camera, TimeSpan.FromSeconds(seconds));
        }

        // 지금 보는 지점을 중심으로 수직축 둘레를 degrees 도만큼 seconds 초 동안 돕니다.
        private void Orbit(float degrees, double seconds)
        {
            vizcore3dx.View.OrbitCamera(new Data.Vector3D(0f, 0f, 1f), degrees, TimeSpan.FromSeconds(Math.Max(seconds, 1.0)));
        }

        // 시선 방향을 수직축(Z) 둘레로 degrees 도 돌립니다.
        private static Data.Vector3D RotateZ(Data.Vector3D v, float degrees)
        {
            double a = degrees * Math.PI / 180.0;
            return new Data.Vector3D((float)(v.X * Math.Cos(a) - v.Y * Math.Sin(a)), (float)(v.X * Math.Sin(a) + v.Y * Math.Cos(a)), v.Z);
        }

        #endregion

        #region 화면 문구 · 리본/패널 탭

        private void SetStatus(string text)
        {
            Text = "VIZCore3DX.NET.Scenario.ConstructionReview — " + text;
        }

        // 3D 뷰 왼쪽 위에 문구 하나를 띄웁니다. 밝은 장면(X-Ray·단면)에서도 읽히도록 어두운 상자에 얹은 화면 고정 노트입니다. 이전 문구는 지웁니다.
        private void ShowHud(string text)
        {
            ClearHud();
            Data.NoteCustomStyle style = vizcore3dx.Note.CreateCustomStyle();
            style.BoxFillColor = ScenarioScript.ColorPanel;
            style.BoxStrokeColor = ScenarioScript.ColorAccent;
            style.TextColor = ScenarioScript.HudColor;
            style.TextSize = ScenarioScript.HudTextSize;
            style.TextHorizontalAlignment = Data.HorizontalAlignment.Left;

            // 상자 왼쪽 위 모서리를 여백에 맞춥니다. 상자 크기는 노트와 같은 계산으로 SDK 가 구합니다(기준점 TopLeft).
            Size view = vizcore3dx.View.ViewPixelSize;
            if (view.Width == 0 || view.Height == 0) return;
            float x = ScenarioScript.HudMarginPixels / view.Width;
            float y = ScenarioScript.HudMarginPixels / view.Height;
            _hudNote = vizcore3dx.Note.AddNote2D(text, x, y, style, ContentAlignment.TopLeft);
        }

        // 3D 뷰 왼쪽 위 문구를 지웁니다.
        private void ClearHud()
        {
            if (_hudNote != 0) vizcore3dx.Note.Delete(new List<uint> { _hudNote });
            _hudNote = 0;
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
