using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Scenario.Monitoring
{
    // 시연 연출 — 키 처리·카메라 이동·화면 문구·리본/패널 탭 정리. SDK 기능 사용과 무관하니 건너뛰어도 됩니다.
    public partial class FrmMain
    {
        // 3D 뷰 왼쪽 위에 띄운 노트와 그 문구
        private uint _hudNote;
        private string _hudText;

        #region 키 · 화면 정리

        // 재생 중에도 Esc 로 멈출 수 있게 합니다.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape && _runner.IsPlaying)
            {
                _runner.Reset();
                SetStatus("재생을 중단했습니다.");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // 리본과 3D 화면만 남김: 옆 뷰 툴바·모델 트리·속성 패널·상태바 숨김
        // 분할 화면을 만들면 뷰 툴바가 다시 보이므로 화면을 바꿀 때마다 부릅니다.
        private void HideViewerUI()
        {
            vizcore3dx.View.Toolbar.Enable = false;
            vizcore3dx.ModelingControlVisible = false;
            vizcore3dx.ModelTreeVisible = false;
            vizcore3dx.AttributePanelVisible = false;
            vizcore3dx.Statusbar.Visible = false;
        }

        // 사용자 탭만 남기고 나머지 툴바(=리본 탭)와 모델 트리 패널의 탭을 숨깁니다.
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

        // 속성 패널은 끕니다. 이 예제는 3D 뷰만 씁니다.
        private void ShowAttributeTabs()
        {
            vizcore3dx.TabAttributeTreeEnabled = false;
            vizcore3dx.TabNodeGroupEnabled = false;
            vizcore3dx.TabProjectionEnabled = false;
            vizcore3dx.TabPmiEnabled = false;
            vizcore3dx.TabEnvironmentEnabled = false;
            vizcore3dx.TabGenericDataEnabled = false;
            vizcore3dx.AttributePanelVisible = false;
        }

        #endregion

        #region 화면 문구

        private void SetStatus(string text)
        {
            Text = "VIZCore3DX.NET.Scenario.Monitoring — " + text;
        }

        // 장면 안의 문구 — 창 제목줄과 3D 뷰 왼쪽 위 문구의 첫 줄에 띄웁니다.
        private void Beat(string text)
        {
            _beat = text;
            SetStatus(text);
            RefreshHud();
        }

        // 3D 뷰 왼쪽 위 문구: 장면 안의 문구 아래에 가스 감지기 상태와 출입 금지 구역 안 인원을 붙입니다. 감시 중일 때만 띄웁니다.
        private void RefreshHud()
        {
            if (!_working || _noGoZone < 0 || !vizcore3dx.Model.IsOpen()) return;

            string tail = string.Format(ScenarioScript.TextHudTail, _gasAlarm ? ScenarioScript.TextGasOn : ScenarioScript.TextGasOff, vizcore3dx.Zone.GetContents(_noGoZone).Count);
            // 4분할이면 노트가 칸마다 그려지므로 꼬리 한 줄만 띄웁니다(장면 문구는 창 제목에 있습니다).
            bool split = vizcore3dx.View.GetSubViewCount() != 0;
            string text = split || string.IsNullOrEmpty(_beat) ? tail : _beat + "\n" + tail;
            if (text == _hudText) return;
            ShowHud(text);
        }

        // 3D 뷰 왼쪽 위에 문구 하나를 띄웁니다. 밝은 장면에서도 읽히도록 어두운 상자에 얹은 화면 고정 노트입니다. 이전 문구는 지웁니다.
        private void ShowHud(string text)
        {
            ClearHud();
            // 상자 왼쪽 위 모서리를 여백에 맞춥니다. 상자 크기는 노트와 같은 계산으로 SDK 가 구합니다(기준점 TopLeft).
            Size view = vizcore3dx.View.ViewPixelSize;
            if (view.Width == 0 || view.Height == 0) return;

            Data.NoteCustomStyle style = vizcore3dx.Note.CreateCustomStyle();
            style.BoxFillColor = ScenarioScript.ColorPanel;
            style.BoxStrokeColor = ScenarioScript.ColorAccent;
            style.TextColor = ScenarioScript.HudColor;
            style.TextSize = ScenarioScript.HudTextSize;
            style.TextHorizontalAlignment = Data.HorizontalAlignment.Left;

            float x = ScenarioScript.HudMarginPixels / view.Width;
            float y = ScenarioScript.HudMarginPixels / view.Height;
            _hudNote = vizcore3dx.Note.AddNote2D(text, x, y, style, ContentAlignment.TopLeft);
            _hudText = text;
        }

        // 3D 뷰 왼쪽 위 문구를 지웁니다.
        private void ClearHud()
        {
            if (_hudNote != 0) vizcore3dx.Note.Delete(new List<uint> { _hudNote });
            _hudNote = 0;
            _hudText = null;
        }

        #endregion
    }
}
