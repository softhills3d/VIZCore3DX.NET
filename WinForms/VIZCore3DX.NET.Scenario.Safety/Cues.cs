using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace VIZCore3DX.NET.Scenario.Safety
{
    // 타임라인: 몇 초 뒤에 할 일을 모아 두었다가 타이머에서 시간 순서대로 실행합니다.
    internal class Cues
    {
        private readonly Stopwatch _clock = Stopwatch.StartNew();
        private readonly List<KeyValuePair<double, Action>> _list = new List<KeyValuePair<double, Action>>();
        private int _generation;

        public double Now { get { return _clock.Elapsed.TotalSeconds; } }

        public void After(double sec, Action action)
        {
            _list.Add(new KeyValuePair<double, Action>(Now + sec, action));
        }

        // 남은 일을 모두 버립니다. 이번 차례에 이미 꺼낸 일도 더 실행하지 않습니다.
        public void Clear()
        {
            _list.Clear();
            _generation++;
        }

        public void Run()
        {
            double now = Now;
            int generation = _generation;
            List<KeyValuePair<double, Action>> due = _list.Where(c => c.Key <= now).OrderBy(c => c.Key).ToList();
            foreach (KeyValuePair<double, Action> c in due)
            {
                if (generation != _generation) return;
                _list.Remove(c);
                c.Value();
            }
        }
    }
}
