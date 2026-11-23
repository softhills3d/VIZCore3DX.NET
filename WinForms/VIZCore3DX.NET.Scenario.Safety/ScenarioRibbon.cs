using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VIZCore3DX.NET.Scenario.Safety
{
    // 리본 사용자 탭 "시나리오" — [모델 열기] [전체 재생] [처음으로]  [1] [2] ... [끝번호]
    // 시나리오와 무관한 공통 코드이므로 다른 시나리오 예제에 네임스페이스만 바꿔 복사해 씁니다.
    // 아이콘은 모두 코드로 그립니다. 리본이 넘겨 주는 색을 쓰므로 테마·비활성 색을 따로 다루지 않습니다.
    internal class ScenarioRibbon
    {
        private const string TabName = "scenario";
        private const string ControlGroup = "scenario.control";
        private const string SceneGroup = "scenario.scenes";
        private const string ScenePrefix = "scenario.scene";

        // 장면 버튼 하나 — 같은 문구가 이어지는 장면들(First~Last, 1부터)을 묶습니다.
        private class SceneButton
        {
            public int First;
            public int Last;
            public string Label;
            public Controls.Ribbon.RibbonButton Button;
        }

        private readonly VIZCore3DXControl _viz;
        private readonly IList<string> _sceneNames;
        private readonly IList<string> _sceneLabels;
        private readonly List<SceneButton> _scenes = new List<SceneButton>();

        // [모델 열기]
        public event Action OpenModel;

        // [전체 재생]
        public event Action PlayAll;

        // [처음으로]
        public event Action Reset;

        // [N] — 그 버튼이 묶은 첫 장면과 마지막 장면 번호(1부터)
        public event Action<int, int> GoScene;

        // sceneLabels 는 버튼 문구, sceneNames 는 마우스를 올렸을 때 보일 장면 이름입니다(재생 순서, 개수 같음).
        // 같은 문구가 이어지면 버튼 하나로 묶고, 누르면 그 장면들을 이어서 재생합니다.
        public ScenarioRibbon(VIZCore3DXControl viz, IList<string> sceneLabels, IList<string> sceneNames)
        {
            _viz = viz;
            _sceneLabels = sceneLabels;
            _sceneNames = sceneNames;
        }

        // 사용자 탭을 만들어 그 탭만 남기고 선택합니다. RibbonMode 를 켜고 내장 탭을 정리한 뒤에 부릅니다.
        public void Build()
        {
            _viz.Ribbon.BeginUpdate();
            try
            {
                _viz.Ribbon.AddTab(TabName, "시나리오");

                _viz.Ribbon.AddGroup(TabName, ControlGroup, "재생");
                AddButton(ControlGroup, "scenario.open", "모델 열기", DrawFolder, () => Raise(OpenModel));
                AddButton(ControlGroup, "scenario.play", "전체 재생", DrawPlay, () => Raise(PlayAll));
                AddButton(ControlGroup, "scenario.reset", "처음으로", DrawRewind, () => Raise(Reset));

                _viz.Ribbon.AddGroup(TabName, SceneGroup, "장면");
                for (int i = 0; i < _sceneLabels.Count; i++)
                {
                    SceneButton previous = _scenes.Count > 0 ? _scenes[_scenes.Count - 1] : null;
                    if (previous != null && previous.Label == _sceneLabels[i]) previous.Last = i + 1;
                    else _scenes.Add(new SceneButton { First = i + 1, Last = i + 1, Label = _sceneLabels[i] });
                }

                for (int i = 0; i < _scenes.Count; i++)
                {
                    SceneButton scene = _scenes[i];
                    string digits = (i + 1).ToString();
                    scene.Button = AddButton(SceneGroup, ScenePrefix + digits, scene.Label,
                        (g, bounds, color, enabled) => DrawNumber(g, bounds, color, digits),
                        () => { if (GoScene != null) GoScene(scene.First, scene.Last); });

                    List<string> names = new List<string>();
                    for (int n = scene.First; n <= scene.Last; n++) names.Add(_sceneNames[n - 1]);
                    if (scene.Button != null) scene.Button.ToolTipText = string.Join("\n", names);
                }

                // 홈·사용자 정의 등 다른 탭은 모두 숨기고 이 탭만 남깁니다.
                foreach (string tab in _viz.Ribbon.GetTabNames())
                    _viz.Ribbon.SetTabVisible(tab, tab == TabName);
            }
            finally
            {
                _viz.Ribbon.EndUpdate();
            }

            _viz.Ribbon.SelectTab(TabName);
        }

        // 지금 장면 번호(1부터)가 든 버튼을 강조합니다. 0 이면 강조를 모두 끕니다.
        public void SetCurrent(int number)
        {
            if (_scenes.Count == 0) return;

            foreach (SceneButton scene in _scenes)
                if (scene.Button != null) scene.Button.Checked = scene.First <= number && number <= scene.Last;

            // Checked 는 바꿔도 다시 그리지 않으므로, 같은 문구를 다시 넣어 리본을 다시 그리게 합니다.
            _viz.Ribbon.SetItemText(ScenePrefix + "1", _scenes[0].Label);
        }

        private Controls.Ribbon.RibbonButton AddButton(string group, string name, string text, Controls.Ribbon.RibbonIconDraw icon, Action click)
        {
            Controls.Ribbon.RibbonButton button = _viz.Ribbon.AddButton(group, name, text, null,
                Controls.Ribbon.RibbonItemSize.Large, (sender, e) => click());
            if (button != null) button.Icon = icon;
            return button;
        }

        private static void Raise(Action action)
        {
            if (action != null) action();
        }

        #region 아이콘

        // 폴더
        private static void DrawFolder(Graphics g, Rectangle b, Color color, bool enabled)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float w = b.Width, h = b.Height;
            float x = b.X + w * 0.12f, y = b.Y + h * 0.22f, r = b.X + w * 0.88f, bottom = b.Y + h * 0.80f;
            PointF[] outline =
            {
                new PointF(x, y), new PointF(x + w * 0.28f, y), new PointF(x + w * 0.36f, y + h * 0.10f),
                new PointF(r, y + h * 0.10f), new PointF(r, bottom), new PointF(x, bottom),
            };
            using (Pen pen = new Pen(color, Math.Max(1.5f, w * 0.07f)) { LineJoin = LineJoin.Round })
            {
                g.DrawPolygon(pen, outline);
                g.DrawLine(pen, x, y + h * 0.24f, r, y + h * 0.24f);
            }
        }

        // 오른쪽 삼각형
        private static void DrawPlay(Graphics g, Rectangle b, Color color, bool enabled)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float w = b.Width, h = b.Height;
            PointF[] triangle =
            {
                new PointF(b.X + w * 0.28f, b.Y + h * 0.18f),
                new PointF(b.X + w * 0.82f, b.Y + h * 0.50f),
                new PointF(b.X + w * 0.28f, b.Y + h * 0.82f),
            };
            using (Brush brush = new SolidBrush(color)) g.FillPolygon(brush, triangle);
        }

        // 세로 막대 + 왼쪽 삼각형
        private static void DrawRewind(Graphics g, Rectangle b, Color color, bool enabled)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float w = b.Width, h = b.Height;
            using (Brush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, b.X + w * 0.18f, b.Y + h * 0.20f, w * 0.10f, h * 0.60f);
                PointF[] triangle =
                {
                    new PointF(b.X + w * 0.82f, b.Y + h * 0.20f),
                    new PointF(b.X + w * 0.32f, b.Y + h * 0.50f),
                    new PointF(b.X + w * 0.82f, b.Y + h * 0.80f),
                };
                g.FillPolygon(brush, triangle);
            }
        }

        // 둥근 사각형 안 숫자
        private static void DrawNumber(Graphics g, Rectangle b, Color color, string text)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float w = b.Width, h = b.Height;
            RectangleF box = new RectangleF(b.X + w * 0.12f, b.Y + h * 0.12f, w * 0.76f, h * 0.76f);
            float radius = box.Width * 0.22f;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(box.X, box.Y, radius * 2, radius * 2, 180, 90);
                path.AddArc(box.Right - radius * 2, box.Y, radius * 2, radius * 2, 270, 90);
                path.AddArc(box.Right - radius * 2, box.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                path.AddArc(box.X, box.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                path.CloseFigure();
                using (Pen pen = new Pen(color, Math.Max(1.5f, w * 0.06f))) g.DrawPath(pen, path);
            }

            float size = box.Height * (text.Length > 1 ? 0.42f : 0.52f);
            using (Font font = new Font("Segoe UI", Math.Max(6f, size), FontStyle.Bold, GraphicsUnit.Pixel))
            using (Brush brush = new SolidBrush(color))
            using (StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                g.DrawString(text, font, brush, box, format);
            }
        }

        #endregion
    }
}
