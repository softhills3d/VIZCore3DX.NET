// 시연 연출 — 키 처리·카메라 이동·화면 문구·리본/패널 탭 정리. SDK 기능 사용과 무관하니 건너뛰어도 됩니다.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Scenario.Safety
{
    public partial class FrmMain
    {
        // 3D 뷰에 띄운 문구
        private uint _hudNote;

        // 카메라 구도를 옮기기 시작한 구도와 시각 (구도: 주시점 X·Y·Z, 방위, 고도, 거리)
        private double[] _camFrom;
        private double _camStart;

        // 구도를 옮기는 시간(초)
        private const double ShotSec = 0.6;
        private double _shotSec = ShotSec;

        private readonly Stopwatch _clock = Stopwatch.StartNew();

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

        #region 카메라

        // 지금 카메라에서 새 구도로 부드럽게 옮깁니다. target 과 alsoSee(걸어갈 곳 등)가 모두 트여 보이는 방위·고도를 고르고, 다 막히면 가까이 붙습니다.
        private void Shot(Data.Vector3D target, double az, double el, double dist, params Data.Vector3D[] alsoSee)
        {
            if (_track != null) target = _track();
            _shotSec = ShotSec;
            double[] fit = Fit(new[] { target }.Concat(alsoSee).ToArray(), az, el, dist);
            _camFrom = ReadCamera();
            double daz = fit[0] - _camFrom[3];
            while (daz > 180) daz -= 360;
            while (daz < -180) daz += 360;
            _camTo = new[] { target.X, target.Y, target.Z, _camFrom[3] + daz, fit[1], fit[2] };
            _camStart = _clock.Elapsed.TotalSeconds;
        }

        // 정한 구도 그대로 부드럽게 옮김 (가림 검사로 방향을 돌리지 않음)
        private void ShotExact(Data.Vector3D target, double az, double el, double dist, double sec = ShotSec)
        {
            _shotSec = sec;
            if (_track != null) target = _track();
            _camFrom = ReadCamera();
            double daz = az - _camFrom[3];
            while (daz > 180) daz -= 360;
            while (daz < -180) daz += 360;
            _camTo = new[] { target.X, target.Y, target.Z, _camFrom[3] + daz, el, dist };
            _camStart = _clock.Elapsed.TotalSeconds;
        }

        // 정한 구도 그대로 바로 바꿈 (가림 검사로 방향을 돌리지 않음)
        private void CutExact(Data.Vector3D target, double az, double el, double dist)
        {
            _camTo = null;
            Orbit(new double[] { target.X, target.Y, target.Z, az, el, dist });
        }

        // 구도 { 주시점 X, Y, Z, 방위, 고도, 거리 } 로 바로 바꿈
        private void View(double[] v)
        {
            CutExact(new Data.Vector3D((float)v[0], (float)v[1], (float)v[2]), v[3], v[4], v[5]);
        }

        // 눈 자리 eye 에서 at 을 바라봄
        private void LookFrom(float[] eye, Data.Vector3D at)
        {
            double dx = eye[0] - at.X, dy = eye[1] - at.Y, dz = eye[2] - at.Z, d = Math.Sqrt(dx * dx + dy * dy + dz * dz);
            View(new[] { at.X, at.Y, at.Z, Math.Atan2(dy, dx) * 180 / Math.PI, Math.Asin(dz / d) * 180 / Math.PI, d });
        }

        // 카메라가 이 사람들의 가운데를 따라감 (인자가 없으면 멈춤)
        private void Follow(params Person[] people)
        {
            if (people.Length == 0) { _track = null; return; }
            Data.Vector3D last = Center(900);
            _track = () =>
            {
                var live = people.Where(p => !p.Removed).Select(p => _crew.Info(p)).Where(i => i != null).ToList();
                if (live.Count > 0) last = new Data.Vector3D(live.Average(i => i.Position.X), live.Average(i => i.Position.Y), ScenarioScript.Deck + 900);
                return last;
            };
        }

        // 틱마다 부릅니다. 구도를 옮기는 중이거나 따라가는 중일 때만 카메라를 건드립니다.
        private void UpdateCamera()
        {
            if (_camTo == null)
            {
                if (_track != null) FollowPoint(_track());
                return;
            }

            if (_track != null)
            {
                Data.Vector3D g = _track();
                _camTo[0] = g.X; _camTo[1] = g.Y; _camTo[2] = g.Z;
            }
            double k = Math.Min(1, (_clock.Elapsed.TotalSeconds - _camStart) / _shotSec);
            double e = k * k * k * (k * (k * 6 - 15) + 10);
            double[] v = new double[6];
            for (int i = 0; i < 5; i++) v[i] = _camFrom[i] + (_camTo[i] - _camFrom[i]) * e;
            v[5] = Math.Exp(Math.Log(_camFrom[5]) + (Math.Log(_camTo[5]) - Math.Log(_camFrom[5])) * e);
            Orbit(v);
            if (k >= 1) _camTo = null;
        }

        // 주시점만 목표 쪽으로 부드럽게 옮김 (방위·고도·거리는 지금 카메라 그대로)
        private void FollowPoint(Data.Vector3D goal)
        {
            double[] c = ReadCamera();
            c[0] += (goal.X - c[0]) * 0.06;
            c[1] += (goal.Y - c[1]) * 0.06;
            c[2] += (goal.Z - c[2]) * 0.06;
            Orbit(c);
        }

        // 지금 카메라를 주시점·방위·고도·거리로 읽음
        private double[] ReadCamera()
        {
            Data.CameraData c = vizcore3dx.View.GetCameraData();
            double ex = c.EyePosition.X, ey = c.EyePosition.Y, ez = c.EyePosition.Z;
            double dx = c.CameraDirection.X, dy = c.CameraDirection.Y, dz = c.CameraDirection.Z;
            double dl = Math.Sqrt(dx * dx + dy * dy + dz * dz);
            dx /= dl; dy /= dl; dz /= dl;
            double dist = (c.PivotPosition.X - ex) * dx + (c.PivotPosition.Y - ey) * dy + (c.PivotPosition.Z - ez) * dz;
            if (dist < 500) dist = 5000;
            double tx = ex + dx * dist, ty = ey + dy * dist, tz = ez + dz * dist;
            double az = Math.Atan2(ey - ty, ex - tx) * 180 / Math.PI;
            double el = Math.Asin(Math.Max(-1, Math.Min(1, (ez - tz) / dist))) * 180 / Math.PI;
            return new[] { tx, ty, tz, az, el, dist };
        }

        // 트인 구도 찾기: 방위를 돌리고 고도를 낮춰 보고, 다 막히면 가장 멀리 트인 쪽에서 가까이 붙음 → { 방위, 고도, 거리 }
        private double[] Fit(Data.Vector3D[] ts, double az, double el, double dist)
        {
            double[] best = { az, el, 0 };
            foreach (double e in new[] { el, el - 8, el - 15 })
            {
                if (e < 8) continue;
                foreach (double d in new double[] { 0, 25, -25, 50, -50, 80, -80, 120, -120, 180 })
                {
                    double free = ts.Min(t => FreeDist(t, az + d, e, dist));
                    if (free >= dist) return new[] { az + d, e, dist };
                    if (free > best[2] + 300) best = new[] { az + d, e, free };
                }
            }
            return best;
        }

        // 주시점에서 눈 쪽으로 광선을 쏴 막히기 전까지 쓸 수 있는 거리 (주시점 바로 옆 0.6 m 는 무시)
        private double FreeDist(Data.Vector3D t, double az, double el, double dist)
        {
            const float skip = 600f, margin = 400f, min = 2000f;
            double a = az * Math.PI / 180, e = el * Math.PI / 180;
            float dx = (float)(Math.Cos(e) * Math.Cos(a)), dy = (float)(Math.Cos(e) * Math.Sin(a)), dz = (float)Math.Sin(e);
            var ray = new Data.Ray3D(
                new Data.Vector3D(t.X + dx * skip, t.Y + dy * skip, t.Z + dz * skip),
                new Data.Vector3D(dx, dy, dz));
            Data.RaycastHit h = vizcore3dx.Object3D.Raycast(ray, null, new Data.RaycastOptions { MaxDistance = (float)dist - skip });
            if (h == null) return dist;
            double hx = h.Position.X - t.X, hy = h.Position.Y - t.Y, hz = h.Position.Z - t.Z;
            return Math.Max(min, Math.Sqrt(hx * hx + hy * hy + hz * hz) - margin);
        }

        private void Orbit(double[] v)
        {
            double az = v[3] * Math.PI / 180, el = v[4] * Math.PI / 180;
            double ex = v[0] + v[5] * Math.Cos(el) * Math.Cos(az);
            double ey = v[1] + v[5] * Math.Cos(el) * Math.Sin(az);
            double ez = v[2] + v[5] * Math.Sin(el);
            double dx = v[0] - ex, dy = v[1] - ey, dz = v[2] - ez;
            double len = Math.Sqrt(dx * dx + dy * dy + dz * dz);
            dx /= len; dy /= len; dz /= len;

            // 위쪽은 세계 Z 기준 (화면이 기울지 않게)
            double ux = -dz * dx, uy = -dz * dy, uz = 1 - dz * dz;
            double ul = Math.Sqrt(ux * ux + uy * uy + uz * uz);
            Data.CameraData cam = vizcore3dx.View.GetCameraData();
            cam.EyePosition = new Data.Vertex3D((float)ex, (float)ey, (float)ez);
            cam.CameraDirection = new Data.Vertex3D((float)dx, (float)dy, (float)dz);
            cam.PivotPosition = new Data.Vertex3D((float)v[0], (float)v[1], (float)v[2]);
            cam.UpDirection = new Data.Vertex3D((float)(ux / ul), (float)(uy / ul), (float)(uz / ul));
            vizcore3dx.View.SetCameraData(cam);
        }

        #endregion

        #region 화면 문구 · 뷰어 UI

        private void SetStatus(string text)
        {
            Text = "VIZCore3DX.NET.Scenario.Safety — " + text;
        }

        // 진행 문구를 3D 뷰 왼쪽 위에 띄웁니다. 집결지·작업 구역이 있으면 그 안의 인원을 뒤에 붙입니다.
        private void Report(string message)
        {
            _hudText = message.Trim();
            RefreshHud();
        }

        // 지금 문구 뒤에 Zone 안의 인원을 붙여 다시 띄웁니다. Zone 이벤트가 올 때마다 부릅니다.
        private void RefreshHud()
        {
            if (_hudText == null) { ClearHud(); return; }

            string count = _muster >= 0 ? string.Format("집결 {0}/{1}명", vizcore3dx.Zone.GetContents(_muster).Count, _all.Length)
                         : _zone >= 0 ? string.Format("구역 안 {0}명 · 허가 2명", vizcore3dx.Zone.GetContents(_zone).Count)
                         : "";
            ShowHud(count.Length == 0 ? _hudText : _hudText + "   (" + count + ")");
        }

        // 3D 뷰 왼쪽 위에 문구 하나를 띄웁니다. 밝은 장면에서도 읽히도록 어두운 상자에 얹은 화면 고정 노트입니다. 이전 문구는 지웁니다.
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

        // 리본과 3D 화면만 남김: 뷰 툴바·모델 트리·속성 패널·상태바 숨김
        private void HideViewerUI()
        {
            vizcore3dx.View.Toolbar.Enable = false;
            vizcore3dx.ModelingControlVisible = false;
            vizcore3dx.ModelTreeVisible = false;
            vizcore3dx.AttributePanelVisible = false;
            vizcore3dx.Statusbar.Visible = false;
        }

        // 홈 탭만 남기고 나머지 툴바(=리본 탭)와 모델 트리 패널의 탭을 숨깁니다.
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
    }
}
