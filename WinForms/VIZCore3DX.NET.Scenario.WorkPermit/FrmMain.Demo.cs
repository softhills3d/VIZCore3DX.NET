// 시연 연출 — 키 처리·카메라 이동·화면 문구·리본/패널 탭 정리. SDK 기능 사용과 무관하니 건너뛰어도 됩니다.
// (카메라 방향·여백 맞춤 FlyToBox 는 View.FlyToBoundingBox 를 씁니다.)
using System;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Scenario.WorkPermit
{
    public partial class FrmMain
    {
        // 3D 뷰에 띄운 문구
        private Data.MessageItem _hud;

        // 대피 장면의 빠른 재생 표시
        private Data.MessageItem _speedHud;

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
        // 여백 비율 m 의 거리 배율이 1/(1-m) 이므로 FitMargin 배율에서 거꾸로 구합니다.
        private void FlyToBox(Data.BoundBox3D box, Data.Vector3D direction, double seconds)
        {
            double margin = Math.Max(0.0, 1.0 - 1.0 / ScenarioScript.FitMargin);
            vizcore3dx.View.FlyToBoundingBox(box, direction, margin, TimeSpan.FromSeconds(seconds));
        }

        // 두 상자가 함께 화면에 들어오도록 direction 방향에서 seconds 초 동안 이동합니다.
        private void FlyToBoxes(Data.BoundBox3D first, Data.BoundBox3D second, Data.Vector3D direction, double seconds)
        {
            Data.BoundBox3D view = new Data.BoundBox3D(first.GetVertexMin(), first.GetVertexMax());
            view.AddBox(second);
            FlyToBox(view, direction, seconds);
        }

        // 화재 구역부터 집결지까지 대피 범위 전체가 보이도록 물러납니다.
        private void FlyToEvacuationOverview()
        {
            Data.Vector3D muster = ScenarioScript.NodeMuster;
            float r = ScenarioScript.MusterRadius;
            Data.BoundBox3D view = new Data.BoundBox3D(10000f, -10000f, 5520f, 30000f, 10000f, 14500f);
            view.AddBox(new Data.BoundBox3D(muster.X - r, muster.Y - r, muster.Z, muster.X + r, muster.Y + r, muster.Z + 2500f));
            FlyToBox(view, ScenarioScript.ViewEvacuation, 2.5);
        }

        // 지금 보는 지점을 중심으로 수직축 둘레를 degrees 도만큼 seconds 초 동안 돕니다.
        private void Orbit(float degrees, double seconds)
        {
            vizcore3dx.View.OrbitCamera(new Data.Vector3D(0f, 0f, 1f), degrees, TimeSpan.FromSeconds(Math.Max(seconds, 1.0)));
        }

        #endregion

        #region 화면 문구·리본/패널 탭

        // 상태 문구를 창 제목줄에 적습니다.
        private void SetStatus(string text)
        {
            Text = "VIZCore3DX.NET.Scenario.WorkPermit — " + text;
        }

        // 3D 뷰 왼쪽 위에 문구 하나를 띄웁니다. 이전 문구는 지웁니다.
        private void ShowHud(string text)
        {
            if (_hud != null) vizcore3dx.View.Message.Delete(_hud);
            _hud = vizcore3dx.View.Message.Create(text, ScenarioScript.HudPosition, ScenarioScript.HudColor, Data.TextSizeType.Size_24, true, true);
        }

        // 3D 뷰 왼쪽 위 문구를 지웁니다. 빠른 재생 표시도 함께 지웁니다.
        private void ClearHud()
        {
            if (_hud != null) vizcore3dx.View.Message.Delete(_hud);
            _hud = null;
            ClearSpeedHud();
        }

        // 안내 문구 아래에 빠른 재생 표시를 크게 띄웁니다.
        private void ShowSpeedHud(string text)
        {
            if (_speedHud != null) vizcore3dx.View.Message.Delete(_speedHud);
            _speedHud = vizcore3dx.View.Message.Create(text, ScenarioScript.SpeedHudPosition, ScenarioScript.ColorAccent, Data.TextSizeType.Size_24, true, true);
        }

        private void ClearSpeedHud()
        {
            if (_speedHud != null) vizcore3dx.View.Message.Delete(_speedHud);
            _speedHud = null;
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
