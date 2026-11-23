using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Scenario.ConstructionReview
{
    // 대본 한 줄입니다. 장면 이름 · 설명 · 길이(초) · 장면 메서드를 묶습니다.
    internal class ScenarioShot
    {
        public string Name { get; private set; }
        public string Caption { get; set; }
        public double Seconds { get; private set; }
        public Action Play { get; set; }

        // 번호 버튼으로 이 장면부터 볼 때 먼저 실행할 장면 번호(1부터). 앞 장면이 만든 상태가 필요할 때 적습니다.
        public int[] Before = new int[0];

        // 선행 장면으로 실행될 때, 장면이 시작한 비동기 작업(검사 등)이 끝났는지. 끝날 때까지 다음 장면으로 넘어가지 않습니다. null 이면 바로 넘어갑니다.
        public Func<bool> IsDone { get; set; }

        public ScenarioShot(string name, string caption, double seconds)
        {
            Name = name;
            Caption = caption;
            Seconds = seconds;
        }
    }

    // 대본을 순서대로 재생합니다. 번호 버튼으로 중간 장면부터 볼 때는 선행 장면을 먼저 실행합니다.
    // 시나리오와 무관한 공통 코드이므로 다른 시나리오 예제에 그대로 복사해 씁니다.
    internal class ScenarioRunner
    {
        private class Pending { public double DueMs; public Action Action; }

        private readonly List<ScenarioShot> _shots;
        private readonly Timer _timer = new Timer();
        private readonly Stopwatch _clock = new Stopwatch();
        private readonly List<Pending> _pending = new List<Pending>();
        private readonly HashSet<int> _done = new HashSet<int>();
        private bool _auto;
        private int _last;
        private double _nextShotMs;

        // 선행 장면 준비 — 남은 장면, 끝나면 할 일, 비동기 작업을 기다리는 장면
        private const double PrepareTimeoutSeconds = 60.0;
        private readonly Timer _waitTimer = new Timer();
        private readonly Stopwatch _waitClock = new Stopwatch();
        private Queue<int> _prepareQueue;
        private Action _prepared;
        private ScenarioShot _waiting;

        // 다음에 재생할 장면 번호 (0 부터)
        public int Index { get; private set; }

        // 자동 재생 중인지 여부
        public bool IsPlaying { get { return _auto; } }

        public int Count { get { return _shots.Count; } }

        // 장면이 시작될 때 (상태 표시용)
        public event Action<ScenarioShot> ShotStarted;

        // 재생 중 주기적으로 (실시간 표시 갱신용)
        public event Action Tick;

        public ScenarioRunner(List<ScenarioShot> shots)
        {
            _shots = shots;
            _timer.Interval = 15;
            _timer.Tick += Timer_Tick;
            _waitTimer.Interval = 100;
            _waitTimer.Tick += WaitTimer_Tick;
        }

        // 처음부터 끝까지 이어서 재생합니다.
        public void PlayAll()
        {
            Reset();
            _last = 0;
            if (Index >= _shots.Count) return;
            _auto = true;
            _clock.Start();
            _timer.Start();
            StartShot();
        }

        // 장면 하나만 재생합니다. 장면 길이를 기다리지 않고 다음 버튼을 기다립니다.
        public void PlayNext()
        {
            if (_auto || Index >= _shots.Count) return;
            _pending.Clear();
            _clock.Start();
            _timer.Start();
            StartShot();
        }

        // first 번 장면(1부터)을 지우지 않고 이어서 재생할 수 있는지 — 바로 다음 장면이고 선행 장면을 이미 실행해 끝났을 때입니다.
        public bool IsReadyFor(int first)
        {
            if (_auto || _prepareQueue != null || first - 1 != Index || first < 1 || first > _shots.Count) return false;
            foreach (int before in _shots[first - 1].Before)
            {
                if (!_done.Contains(before)) return false;
                ScenarioShot shot = _shots[before - 1];
                if (shot.IsDone != null && !shot.IsDone()) return false;
            }
            return true;
        }

        // first 번 장면의 선행 장면을 길이 0 으로 차례로 실행한 뒤 prepared 를 부릅니다.
        // 선행 장면이 비동기 작업을 시작했으면(IsDone 이 거짓) 끝날 때까지 기다립니다.
        public void Prepare(int first, Action prepared)
        {
            if (first < 1 || first > _shots.Count) return;

            _prepareQueue = new Queue<int>(_shots[first - 1].Before.Where(n => n >= 1 && n <= _shots.Count));
            _prepared = prepared;
            PrepareNext();
        }

        // first~last 번 장면(1부터)을 이어서 재생합니다. 마지막 장면이 시작된 뒤에는 다음 장면으로 넘어가지 않습니다.
        public void PlayFrom(int first, int last)
        {
            if (_auto || first < 1 || first > _shots.Count) return;
            Index = first - 1;
            _last = Math.Min(Math.Max(last, first), _shots.Count);
            _auto = _last > first;
            _pending.Clear();
            _clock.Start();
            _timer.Start();
            StartShot();
        }

        // 재생을 멈추고 처음 장면으로 되돌립니다.
        public void Reset()
        {
            _timer.Stop();
            _clock.Reset();
            _pending.Clear();
            _done.Clear();
            _waitTimer.Stop();
            _prepareQueue = null;
            _prepared = null;
            _waiting = null;
            _last = 0;
            _auto = false;
            Index = 0;
        }

        // 지금 장면이 시작된 뒤 seconds 초에 action 을 실행합니다. 장면 안의 순서를 만들 때 씁니다.
        public void After(double seconds, Action action)
        {
            _pending.Add(new Pending { DueMs = _clock.Elapsed.TotalMilliseconds + seconds * 1000.0, Action = action });
        }

        // 남은 선행 장면을 실행합니다. 비동기 작업을 시작한 장면이 있으면 멈추고 기다립니다.
        private void PrepareNext()
        {
            while (_prepareQueue != null && _prepareQueue.Count > 0)
            {
                int number = _prepareQueue.Dequeue();
                ScenarioShot shot = _shots[number - 1];
                _pending.Clear();
                shot.Play();
                _done.Add(number);

                // 장면이 예약한 동작을 시각 순으로 전부 바로 실행합니다(실행 중 더 예약되면 그것까지).
                while (_pending.Count > 0)
                {
                    Pending first = _pending.OrderBy(item => item.DueMs).First();
                    _pending.Remove(first);
                    first.Action();
                }

                if (_prepareQueue == null) return;   // 장면 안에서 Reset 된 경우
                if (shot.IsDone != null && !shot.IsDone())
                {
                    _waiting = shot;
                    _waitClock.Restart();
                    _waitTimer.Start();
                    return;
                }
            }

            Action prepared = _prepared;
            _prepareQueue = null;
            _prepared = null;
            if (prepared != null) prepared();
        }

        private void WaitTimer_Tick(object sender, EventArgs e)
        {
            if (_waiting == null) { _waitTimer.Stop(); return; }
            if (!_waiting.IsDone() && _waitClock.Elapsed.TotalSeconds < PrepareTimeoutSeconds) return;

            _waitTimer.Stop();
            _waiting = null;
            PrepareNext();
        }

        private void StartShot()
        {
            ScenarioShot shot = _shots[Index];
            Index++;
            _done.Add(Index);

            if (ShotStarted != null) ShotStarted(shot);

            shot.Play();

            // 장면 길이는 장면 메서드가 돌아온 뒤부터 셉니다. 생성에 걸린 시간이 장면을 깎지 않습니다.
            _nextShotMs = _clock.Elapsed.TotalMilliseconds + shot.Seconds * 1000.0;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            double now = _clock.Elapsed.TotalMilliseconds;
            RunPending(now);
            if (Tick != null) Tick();

            if (!_auto || now < _nextShotMs) return;

            if (Index < _shots.Count && (_last == 0 || Index < _last))
            {
                _pending.Clear();
                StartShot();
                return;
            }

            // 번호 버튼의 구간 재생 — 마지막 장면의 남은 예약은 계속 실행합니다.
            if (_last != 0)
            {
                _auto = false;
                _last = 0;
                return;
            }

            _auto = false;
            _timer.Stop();
            _clock.Stop();
        }

        private void RunPending(double now)
        {
            // 실행 중에 After 가 다시 불릴 수 있으므로 사본으로 돕니다.
            foreach (Pending item in _pending.ToArray())
            {
                if (item.DueMs > now) continue;
                _pending.Remove(item);
                item.Action();
            }
        }
    }
}
