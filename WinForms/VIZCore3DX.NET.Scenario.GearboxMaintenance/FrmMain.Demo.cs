using System;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Scenario.GearboxMaintenance
{
    // 시연 연출 — 키 처리·카메라 이동·화면 문구·리본/패널 탭 정리. SDK 기능 사용과 무관하니 건너뛰어도 됩니다.
    // (카메라 방향·여백 맞춤 FlyToBox 는 View.FlyToBoundingBox 를 씁니다.)
    public partial class FrmMain
    {
        // 3D 뷰에 띄운 문구
        private Data.MessageItem _hud;

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

        #endregion

        #region 화면 문구 · 리본/패널 탭

        // 상태 문구를 창 제목줄에 적습니다.
        private void SetStatus(string text)
        {
            Text = "VIZCore3DX.NET.Scenario.GearboxMaintenance — " + text;
        }

        // 3D 뷰 왼쪽 위에 문구 하나를 띄웁니다. 이전 문구는 지웁니다.
        private void ShowHud(string text)
        {
            if (_hud != null) vizcore3dx.View.Message.Delete(_hud);
            _hud = vizcore3dx.View.Message.Create(text, ScenarioScript.HudPosition, ScenarioScript.HudColor, ScenarioScript.HudTextSize, true, true);
        }

        // 3D 뷰 왼쪽 위 문구를 지웁니다.
        private void ClearHud()
        {
            if (_hud != null) vizcore3dx.View.Message.Delete(_hud);
            _hud = null;
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
