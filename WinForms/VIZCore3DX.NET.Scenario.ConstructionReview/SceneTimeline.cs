using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Scenario.ConstructionReview
{
    // 장면 안의 동작을 시간 순서로 실행합니다. (예: 영역을 하나씩 칠하기, 카메라를 차례로 이동하기)
    // UI 스레드의 타이머로 돌기 때문에 예약한 동작에서 뷰어 API 를 그대로 호출할 수 있습니다.
    internal class SceneTimeline
    {
        private class Pending { public double DueMs; public Action Action; }

        private readonly Timer _timer = new Timer();
        private readonly Stopwatch _clock = Stopwatch.StartNew();
        private readonly List<Pending> _pending = new List<Pending>();

        // 타이머가 돌 때마다 (실시간 표시 갱신용)
        public event Action Tick;

        public SceneTimeline()
        {
            _timer.Interval = 15;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        // 지금부터 seconds 초 뒤에 action 을 실행합니다.
        public void After(double seconds, Action action)
        {
            _pending.Add(new Pending { DueMs = _clock.Elapsed.TotalMilliseconds + seconds * 1000.0, Action = action });
        }

        // 아직 실행하지 않은 예약을 모두 취소합니다.
        public void Clear()
        {
            _pending.Clear();
        }

        public void Stop()
        {
            _timer.Stop();
            _pending.Clear();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            double now = _clock.Elapsed.TotalMilliseconds;

            // 실행 중에 After 가 다시 불릴 수 있으므로 사본으로 돕니다.
            foreach (Pending item in _pending.ToArray())
            {
                if (item.DueMs > now) continue;
                _pending.Remove(item);
                item.Action();
            }

            if (Tick != null) Tick();
        }
    }
}
