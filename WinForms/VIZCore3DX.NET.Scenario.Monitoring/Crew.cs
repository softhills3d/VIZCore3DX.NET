using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.Scenario.Monitoring
{
    // 작업자 한 명
    internal class Person
    {
        public int Id;
        public string Name;
        public float Speed;
        public int Token;
        public bool Removed;

        // 걷는 중: 길, 다음 길 점, 지금 자리·방향
        public List<Vector3D> Path;
        public int PathIdx, WalkToken;
        public Vector3D Sim;
        public double Heading, NextStep, ProgressAt;
        public float BestRemain;
        public Action OnArrive;

        // 서 있는 칸(다른 사람이 피함), 출입 금지 구역 출입 허용
        public bool Standing;
        public Point Cell;
        public bool AllowNoGo;

        // 이 사람에게 딸린 이펙트를 지우는 동작: 걷기 시작하면 함께 지움
        public readonly List<Action> Owned = new List<Action>();
    }

    // 작업자들: 배치, 사람처럼 걷기, 제자리 작업 동작
    // 엔진에서 아바타가 움직이는 동안·자세를 바꿀 때마다 GDI 개체가 새므로, 상시 순찰 없이 사건 때만 걷고 자세는 드물게 바꿉니다.
    internal class Crew
    {
        public const string PresetName = "Scenario Worker";
        public const string Group = "Monitoring";

        // 걸음: 0.12초마다 몸이 향한 쪽으로 나아가고, 길 쪽으로는 초당 240°까지 돌아섬
        private const double StepSec = 0.12, TurnRate = 240;

        // 작업 불꽃 전체 크기 배율
        private const float SparkScale = 1.7f;

        private readonly VIZCore3DXControl _v;
        private readonly FloorMap _map;
        private readonly Cues _cues;
        private readonly List<Person> _people = new List<Person>();
        private Random _rand = new Random(3);

        // 출입 금지 구역 안인지(점, 여유 mm)
        public Func<Vector3D, float, bool> InNoGo = (p, m) => false;

        public Crew(VIZCore3DXControl viewer, FloorMap map, Cues cues)
        {
            _v = viewer;
            _map = map;
            _cues = cues;
        }

        private VIZCore3DX.NET.Manager.EffectManager Effect { get { return _v.View.Effect; } }

        public void Clear()
        {
            foreach (Person p in _people) p.Removed = true;
            _people.Clear();
            _v.Avatar.Clear();
            _rand = new Random(3);
        }

        #region 배치·상태
        public Person Spawn(Vector3D at, double heading, string name)
        {
            var p = new Person { Name = name, Speed = 1220f + _rand.Next(0, 220), Standing = true, Cell = _map.ToCell(at) };
            p.Id = _v.Avatar.Place(PresetName, at, heading);
            _v.Avatar.SetName(p.Id, name);
            _people.Add(p);
            return p;
        }

        // 그 자세를 잡아도 앞 부재에 닿지 않는 자리에 놓음
        public Person SpawnFit(float x, float y, double heading, string posture, string name)
        {
            return Spawn(_map.Fit(x, y, heading, FloorMap.Reach(posture)), heading, name);
        }

        public AvatarItem Info(Person p) { return _v.Avatar.Find(p.Id); }
        public Vector3D Pos(Person p) { return Info(p).Position; }
        public int NewToken(Person p) { return ++p.Token; }
        public bool Live(Person p, int token) { return !p.Removed && p.Token == token; }
        public void Posture(Person p, string name) { _v.Avatar.SetPosture(p.Id, name); }

        // 몸 앞으로 d, 위로 dz 떨어진 점
        public Vector3D Ahead(Person p, float d, float dz)
        {
            AvatarItem a = Info(p);
            double r = a.HeadingDegrees * Math.PI / 180;
            return new Vector3D(a.Position.X - (float)Math.Sin(r) * d, a.Position.Y + (float)Math.Cos(r) * d, a.Position.Z + dz);
        }

        // 이 사람에게 딸린 이펙트로 등록 (걷기 시작하면 remove 로 지움)
        public uint Own(Person p, uint id, Action<uint> remove)
        {
            p.Owned.Add(() => remove(id));
            return id;
        }

        private static void DropOwned(Person p)
        {
            foreach (Action a in p.Owned) a();
            p.Owned.Clear();
        }
        #endregion

        #region 걷기
        // 사람처럼 걷기(W 키처럼): 길을 둥글게 다듬고, 몸이 향한 쪽으로만 나아감. 실제 이동은 Update 가 이어 붙임.
        public void Walk(Person p, Vector3D to, Action arrive)
        {
            DropOwned(p);
            p.WalkToken = NewToken(p);
            Posture(p, null);
            p.Standing = false;
            p.Sim = Pos(p);
            p.Heading = Info(p).HeadingDegrees;
            p.Path = FloorMap.Smooth(_map.FindPath(p.Sim, to, StandingCells(p), NoGoCells(p)));
            p.PathIdx = 1;
            p.OnArrive = arrive;
            p.NextStep = 0;
            p.BestRemain = float.MaxValue;
            p.ProgressAt = _cues.Now;
        }

        public void Update()
        {
            double now = _cues.Now;
            foreach (Person p in _people.ToList())
            {
                if (p.Path == null) continue;
                if (!Live(p, p.WalkToken)) { p.Path = null; continue; }
                if (now < p.NextStep) continue;
                p.NextStep = now + StepSec;

                // 0.45 m 안에 들어온 길 점은 지나가고 그다음 점을 향함
                while (p.PathIdx < p.Path.Count - 1 && Geo.Dist(p.Sim, p.Path[p.PathIdx]) < 450) p.PathIdx++;
                Vector3D goal = p.Path[p.PathIdx];
                float left = Geo.Dist(p.Sim, goal);
                bool last = p.PathIdx == p.Path.Count - 1;
                if (last && left < 60) { FinishWalk(p); continue; }

                // 길 쪽으로 돌아서며, 많이 틀어져 있으면 제자리에서 먼저 돎
                double diff = Geo.AngleDiff(p.Heading, Geo.Heading(goal.X - p.Sim.X, goal.Y - p.Sim.Y));
                double turn = TurnRate * StepSec;
                p.Heading += Math.Max(-turn, Math.Min(turn, diff));
                double ad = Math.Abs(diff);
                float move = ad > 75 ? 0f : (float)(p.Speed * StepSec * (ad > 35 ? 0.5 : 1.0));
                if (last) move = Math.Min(move, left);
                double r = p.Heading * Math.PI / 180;
                var next = new Vector3D(p.Sim.X - (float)Math.Sin(r) * move, p.Sim.Y + (float)Math.Cos(r) * move, goal.Z);
                if (move > 0 && !_map.OpenAt(next))
                {
                    // 몸 방향으로는 막힘 → 길 점 쪽으로 몸을 맞춰 따라감
                    p.Heading = Geo.Heading(goal.X - p.Sim.X, goal.Y - p.Sim.Y);
                    float k = Math.Min(move, left) / Math.Max(1f, left);
                    next = new Vector3D(p.Sim.X + (goal.X - p.Sim.X) * k, p.Sim.Y + (goal.Y - p.Sim.Y) * k, goal.Z);
                }
                p.Sim = next;
                // 다음 걸음이 오기 전에 끝나지 않게 조금 길게 줘서 걷기 동작이 끊기지 않게 함
                _v.Avatar.MoveTo(p.Id, next, p.Heading, (int)(StepSec * 1000) + 40);

                // 1.5초 넘게 남은 거리가 줄지 않으면 다음 길 점으로 넘어감
                float remain = Geo.Dist(p.Sim, p.Path[p.Path.Count - 1]);
                if (remain < p.BestRemain - 100) { p.BestRemain = remain; p.ProgressAt = now; }
                else if (now - p.ProgressAt > 1.5)
                {
                    if (p.PathIdx >= p.Path.Count - 1) { FinishWalk(p); continue; }
                    p.PathIdx++;
                    p.ProgressAt = now;
                }
            }
        }

        private void FinishWalk(Person p)
        {
            Action arrive = p.OnArrive;
            int token = p.WalkToken;
            p.Path = null;
            _v.Avatar.MoveTo(p.Id, p.Sim, p.Heading, 150);
            p.Standing = true;
            p.Cell = _map.ToCell(p.Sim);
            // 걷기가 끝나 기본 동작으로 돌아간 뒤에 다음 동작
            if (arrive != null) _cues.After(0.3, () => { if (Live(p, token)) arrive(); });
        }

        // 다른 사람이 서 있는 칸 둘레 (피해서 감)
        private HashSet<Point> StandingCells(Person walker)
        {
            var set = new HashSet<Point>();
            foreach (Person o in _people)
                if (o != walker && o.Standing)
                    for (int di = -1; di <= 1; di++)
                        for (int dj = -1; dj <= 1; dj++)
                            set.Add(new Point(o.Cell.X + di, o.Cell.Y + dj));
            return set;
        }

        // 출입 금지 구역 칸 (허용된 사람이거나 이미 구역 안에 있으면 막지 않음)
        private HashSet<Point> NoGoCells(Person walker)
        {
            var set = new HashSet<Point>();
            if (walker.AllowNoGo || InNoGo(walker.Sim, 0)) return set;
            foreach (Point c in _map.Cells())
                if (InNoGo(_map.CellPos(c), 300)) set.Add(c);
            return set;
        }

        // 제자리에서 heading 쪽으로 돌아섬 (12° 미만이면 생략, 180°에 약 0.7초)
        public void Turn(Person p, int token, double heading, Action then)
        {
            double diff = Math.Abs(Geo.AngleDiff(Info(p).HeadingDegrees, heading));
            if (diff < 12) { then(); return; }
            int ms = Math.Max(300, (int)(diff * 4));
            Posture(p, null);
            _v.Avatar.MoveTo(p.Id, Pos(p), heading, ms);
            _cues.After(ms / 1000.0 + 0.05, () => { if (Live(p, token)) then(); });
        }

        public void TurnTo(Person p, int token, Vector3D target, Action then)
        {
            Vector3D a = Pos(p);
            Turn(p, token, Geo.Heading(target.X - a.X, target.Y - a.Y), then);
        }
        #endregion

        #region 작업 동작
        // 불꽃 작업: 자세는 한 번만 잡고 불똥만 9~13초 켰다가 1.5~2.5초 쉬기를 되풀이
        // kind: weld(바닥 용접) · grind(그라인더) · cut(절단) · overhead(머리 위 용접), scale: 불똥 크기
        public void WorkLoop(Person p, string posture, string kind, float scale)
        {
            int token = NewToken(p);
            Posture(p, posture);
            _cues.After(0.7, () =>
            {
                if (!Live(p, token)) return;
                Vector3D at = WorkPoint(p, posture) ?? Ahead(p, 450, 450);
                WorkCycle(p, token, at, kind, scale);
            });
        }

        private void WorkCycle(Person p, int token, Vector3D at, string kind, float size)
        {
            if (!Live(p, token)) return;
            float scale = size * SparkScale;
            double hr = Info(p).HeadingDegrees * Math.PI / 180;
            Vector3D dir = kind == "overhead" ? new Vector3D(0, 0, -1)
                         : kind == "grind" ? Geo.Norm(new Vector3D(-(float)Math.Sin(hr) * 0.7f, (float)Math.Cos(hr) * 0.7f, 0.6f))
                         : new Vector3D(0, 0, 1);
            uint sparks = Own(p, Effect.AddParticleEmitter(at, SparkOptions(dir, kind == "overhead" ? 0.4f : 0.3f, scale)), id => Effect.RemoveParticleEmitter(id));

            // 용접·절단은 아크 빛(작고 빠르게 깜빡이는 흰 구)
            uint glow = kind == "grind" ? 0 : Own(p, Effect.AddPulseSphere(at, new PulseSphereOptions { MinRadius = 30 * scale, MaxRadius = 110 * scale, PeriodMs = 160, Color = Color.FromArgb(255, 245, 210), Opacity = 0.9f, Group = Group }), id => Effect.RemovePulseSphere(id));
            _cues.After(9 + _rand.NextDouble() * 4, () =>
            {
                if (!Live(p, token)) return;
                Effect.RemoveParticleEmitter(sparks);
                if (glow != 0) Effect.RemovePulseSphere(glow);
                p.Owned.Clear();
                _cues.After(1.5 + _rand.NextDouble(), () => WorkCycle(p, token, at, kind, size));
            });
        }

        // 불똥: 바닥을 뚫고 통과하므로 작업 면에서 dir 쪽으로 튀었다가 짧은 수명 안에 사라지게 함
        // (AddWeldingSpark 는 수명·중력을 바꿀 수 없어 바닥 아래층까지 떨어짐)
        public static ParticleOptions SparkOptions(Vector3D dir, float life, float scale)
        {
            float sp = (float)Math.Sqrt(scale);
            var o = new ParticleOptions(ParticlePreset.Sparks)
            {
                Direction = dir,
                ConeAngleDeg = 60,
                LifetimeMinSec = life * 0.4f,
                LifetimeMaxSec = life,
                GravityMmPerSec2 = -4000,
                DragPerSec = 1.5f,
                SpeedMinMmPerSec = 700 * sp,
                SpeedMaxMmPerSec = 2000 * sp,
                Group = Group,
            };
            o.RatePerSec = (int)Math.Round(o.RatePerSec * scale);
            o.LineWidth *= Math.Max(0.7f, sp);
            return o;
        }

        // 불꽃이 손목이 아니라 공구가 닿는 면에서 나오게: 자세별로 앞 바닥·머리 위 부재를 광선으로 찾음
        private Vector3D WorkPoint(Person p, string posture)
        {
            RaycastHit h;
            switch (posture)
            {
                case "Sit 2": h = _map.Cast(Ahead(p, 520, 450), new Vector3D(0, 0, -1), 1000); break;
                case "Seeing 90": h = _map.Cast(Ahead(p, 650, 500), new Vector3D(0, 0, -1), 1000); break;
                case "Seeing 30":
                    double r = Info(p).HeadingDegrees * Math.PI / 180;
                    h = _map.Cast(Ahead(p, 0, 1000), Geo.Norm(new Vector3D(-(float)Math.Sin(r) * 0.55f, (float)Math.Cos(r) * 0.55f, -0.83f)), 1600);
                    break;
                case "Hands Half Up": h = _map.Cast(Ahead(p, 250, 1500), new Vector3D(0, 0, 1), 1300); break;
                default: h = null; break;
            }
            if (h == null) return null;

            // 손이 닿는 거리 안의 면만 씀: 앞이 개구부라 광선이 아래층까지 내려가면 그 자리에는 불꽃을 내지 않음
            Vector3D feet = Pos(p);
            float dz = h.Position.Z - feet.Z, reach = Geo.Dist(h.Position, feet);
            bool ok = posture == "Hands Half Up" ? dz > 1900 && dz < 2800
                    : posture == "Seeing 30" ? dz > -150 && dz < 1200 && reach < 1300
                    : Math.Abs(dz) < 300 && reach < 1000;
            if (!ok) return null;
            return Geo.Up(h.Position, posture == "Hands Half Up" ? -30 : 15);
        }

        // 머리 위 2.0~2.8 m 에 부재가 있고 둘레 2 m 가 트인(개구부·난간에서 떨어진) 자리. 없으면 null
        public Vector3D FindOverhead(float x, float y, out double heading)
        {
            heading = 0;
            Point c0 = _map.ToCell(new Vector3D(x, y, _map.Deck));
            foreach (Point c in _map.Cells().Where(c => _map.Clearance(c) >= 4 && !InNoGo(_map.CellPos(c), 1500))
                                            .OrderBy(c => (c.X - c0.X) * (c.X - c0.X) + (c.Y - c0.Y) * (c.Y - c0.Y)).Take(200))
                foreach (double h in new double[] { 0, 90, 180, -90 })
                {
                    double r = h * Math.PI / 180;
                    Vector3D pos = _map.CellPos(c);
                    RaycastHit up = _map.Cast(new Vector3D(pos.X - (float)Math.Sin(r) * 250, pos.Y + (float)Math.Cos(r) * 250, pos.Z + 1500), new Vector3D(0, 0, 1), 1300);
                    if (up == null || up.Position.Z - pos.Z < 1950) continue;
                    heading = h;
                    return pos;
                }
            return null;
        }

        // 제자리 점검: 걷지 않고 서 있기(idle) 대신 작업 자세끼리만 7~10초마다 바꿈
        public void IdleWork(Person p, double heading, bool deep)
        {
            IdleCycle(p, NewToken(p), heading, deep, 0);
        }

        private void IdleCycle(Person p, int token, double heading, bool deep, int k)
        {
            if (!Live(p, token)) return;
            Turn(p, token, heading, () =>
            {
                Posture(p, k % 2 == 0 ? "Seeing 30" : deep ? "Seeing 90" : "Hands Half Up");
                _cues.After(7 + _rand.NextDouble() * 3, () => IdleCycle(p, token, heading, deep, k + 1));
            });
        }

        // 신호수: 개구부 아래를 내려다보다가 손을 들어 아래쪽에 신호
        public void SignalLoop(Person p, double heading)
        {
            SignalCycle(p, NewToken(p), heading);
        }

        private void SignalCycle(Person p, int token, double heading)
        {
            if (!Live(p, token)) return;
            Turn(p, token, heading, () =>
            {
                Posture(p, "Seeing 30");
                _cues.After(6, () =>
                {
                    if (!Live(p, token)) return;
                    Posture(p, "Hands Half Up");
                    _cues.After(3, () => SignalCycle(p, token, heading));
                });
            });
        }

        // 지켜보기: 대상을 보며 손으로 가리켰다가 들여다봄
        public void WatchLoop(Person p, Vector3D target)
        {
            WatchCycle(p, NewToken(p), target);
        }

        private void WatchCycle(Person p, int token, Vector3D target)
        {
            if (!Live(p, token)) return;
            TurnTo(p, token, target, () =>
            {
                Posture(p, "Hands Half Up");
                _cues.After(2.5, () =>
                {
                    if (!Live(p, token)) return;
                    Posture(p, "Seeing 30");
                    _cues.After(3, () => WatchCycle(p, token, target));
                });
            });
        }
        #endregion

        // 걷기 동작이 있는 프리셋을 씁니다. 없으면 기본 패키지로 만들고 빈 이동 키를 채워 저장합니다.
        public static void EnsurePreset(VIZCore3DXControl v)
        {
            if (v.Avatar.Presets.Any(p => p.Name == PresetName)) return;
            if (v.Avatar.Library.Count == 0) v.Avatar.ImportBuiltInModels();
            AvatarPresetItem preset = v.Avatar.CreatePreset(PresetName, "Worker (M)");
            if (preset == null) return;
            v.Avatar.FillEmptyKeySlots(preset);
            v.Avatar.SavePreset(preset);
        }
    }
}
