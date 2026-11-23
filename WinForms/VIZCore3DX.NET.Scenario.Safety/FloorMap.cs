using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.Scenario.Safety
{
    // 바닥 지도: 0.5 m 격자에서 걸을 수 있는 칸(미리 계산해 둔 FloorData) 위에서 길을 찾습니다.
    // 엔진의 아바타 충돌은 아바타 모드로 조종하는 한 명에게만 적용되므로, 부재를 피하는 일은 이 지도가 맡습니다.
    internal class FloorMap
    {
        private const float Cell = 500f;

        private readonly VIZCore3DXControl _v;
        private readonly float _deck;
        private float _gx, _gy;
        private int _nx, _ny;
        private float[,] _floor;
        private int[,] _clear;

        public FloorMap(VIZCore3DXControl viewer, float deck)
        {
            _v = viewer;
            _deck = deck;
        }

        public float Deck { get { return _deck; } }

        #region 만들기
        // 미리 계산해 둔 바닥 지도(FloorData)를 읽음
        public void Load()
        {
            _gx = FloorData.MinX;
            _gy = FloorData.MinY;
            _nx = FloorData.Heights.GetLength(0);
            _ny = FloorData.Heights.GetLength(1);
            _floor = new float[_nx, _ny];
            for (int i = 0; i < _nx; i++)
                for (int j = 0; j < _ny; j++)
                    _floor[i, j] = FloorData.Heights[i, j] == 0 ? float.NaN : FloorData.Heights[i, j];
            ComputeClearance();
        }

        // 각 칸에서 가장 가까운 막힌 칸까지 거리(칸)
        private void ComputeClearance()
        {
            _clear = new int[_nx, _ny];
            var q = new Queue<Point>();
            for (int i = 0; i < _nx; i++)
                for (int j = 0; j < _ny; j++)
                {
                    if (!IsOpen(i, j)) { _clear[i, j] = 0; q.Enqueue(new Point(i, j)); }
                    else if (i == 0 || j == 0 || i == _nx - 1 || j == _ny - 1) { _clear[i, j] = 1; q.Enqueue(new Point(i, j)); }
                    else _clear[i, j] = int.MaxValue;
                }
            while (q.Count > 0)
            {
                Point c = q.Dequeue();
                for (int di = -1; di <= 1; di++)
                    for (int dj = -1; dj <= 1; dj++)
                    {
                        int i = c.X + di, j = c.Y + dj;
                        if (i < 0 || j < 0 || i >= _nx || j >= _ny || _clear[i, j] <= _clear[c.X, c.Y] + 1) continue;
                        _clear[i, j] = _clear[c.X, c.Y] + 1;
                        q.Enqueue(new Point(i, j));
                    }
            }
        }
        #endregion

        #region 칸
        private float X(int i) { return _gx + i * Cell; }
        private float Y(int j) { return _gy + j * Cell; }
        private bool IsOpen(int i, int j) { return i >= 0 && j >= 0 && i < _nx && j < _ny && !float.IsNaN(_floor[i, j]); }

        public IEnumerable<Point> Cells()
        {
            for (int i = 0; i < _nx; i++)
                for (int j = 0; j < _ny; j++)
                    if (IsOpen(i, j)) yield return new Point(i, j);
        }

        public int Clearance(Point c) { return _clear[c.X, c.Y]; }

        public Vector3D CellPos(Point c) { return new Vector3D(X(c.X), Y(c.Y), _floor[c.X, c.Y]); }

        public Point ToCell(Vector3D p)
        {
            int i = Math.Max(0, Math.Min(_nx - 1, (int)Math.Round((p.X - _gx) / Cell)));
            int j = Math.Max(0, Math.Min(_ny - 1, (int)Math.Round((p.Y - _gy) / Cell)));
            if (IsOpen(i, j)) return new Point(i, j);
            return Cells().OrderBy(c => (c.X - i) * (c.X - i) + (c.Y - j) * (c.Y - j)).First();
        }

        public Vector3D Snap(float x, float y) { return CellPos(ToCell(new Vector3D(x, y, _deck))); }

        public bool OpenAt(Vector3D p)
        {
            return IsOpen((int)Math.Round((p.X - _gx) / Cell), (int)Math.Round((p.Y - _gy) / Cell));
        }

        // 자세를 잡아도 몸이 앞 부재(난간 등)에 닿지 않는 자리: 앞이 reach 만큼 트일 때까지 뒤로 물러남
        public Vector3D Fit(float x, float y, double heading, float reach)
        {
            Vector3D s = Snap(x, y);
            double r = heading * Math.PI / 180;
            float fx = -(float)Math.Sin(r), fy = (float)Math.Cos(r);
            for (int back = 0; back <= 1500; back += 100)
            {
                var c = new Vector3D(s.X - fx * back, s.Y - fy * back, s.Z);
                if (!OpenAt(c)) continue;
                if (new[] { 400f, 900f, 1300f }.All(h => Cast(new Vector3D(c.X, c.Y, c.Z + h), new Vector3D(fx, fy, 0), reach) == null)) return c;
            }
            return s;
        }

        // 자세별로 몸 앞에 필요한 빈 거리(mm)
        public static float Reach(string posture)
        {
            switch (posture)
            {
                case "Seeing 90": return 1050f;
                case "Seeing 30": return 800f;
                case "Sit 2": return 700f;
                default: return 450f;
            }
        }
        #endregion

        #region 길 찾기
        // soft: 서 있는 사람 둘레(너무 돌아가면 무시), hard: 지나가면 안 되는 칸(출입 금지 구역)
        public List<Vector3D> FindPath(Vector3D from, Vector3D to, HashSet<Point> soft, HashSet<Point> hard)
        {
            Point goal = ToCell(to), c = ToCell(from);
            var blocked = new HashSet<Point>(soft);
            blocked.UnionWith(hard);
            blocked.Remove(goal);
            blocked.Remove(c);
            var hardOnly = new HashSet<Point>(hard);
            hardOnly.Remove(goal);
            hardOnly.Remove(c);

            float[,] cost = PathCost(goal, blocked);
            float[,] free = PathCost(goal, hardOnly);
            // 서 있는 사람을 피하느라 1.5배 넘게 돌아가면 옆으로 스쳐 지나감
            if (float.IsInfinity(cost[c.X, c.Y]) || cost[c.X, c.Y] > free[c.X, c.Y] * 1.5f) { blocked = hardOnly; cost = free; }

            var cells = new List<Point> { c };
            while (c != goal && !float.IsInfinity(cost[c.X, c.Y]))
            {
                Point best = c;
                for (int di = -1; di <= 1; di++)
                    for (int dj = -1; dj <= 1; dj++)
                    {
                        int i = c.X + di, j = c.Y + dj;
                        if (IsOpen(i, j) && cost[i, j] < cost[best.X, best.Y]) best = new Point(i, j);
                    }
                if (best == c) break;
                c = best;
                cells.Add(c);
            }

            // 트인 구간은 직선으로 줄임
            var onPath = new HashSet<Point>(cells);
            var route = new List<Vector3D> { from };
            int k = 0;
            while (k < cells.Count - 1)
            {
                int far = k + 1;
                for (int m = cells.Count - 1; m > k + 1; m--)
                    if (LineClear(cells[k], cells[m], onPath, blocked)) { far = m; break; }
                route.Add(CellPos(cells[far]));
                k = far;
            }
            if (route.Count == 1) route.Add(to); else route[route.Count - 1] = to;
            return route;
        }

        // 한 칸에서 모든 칸까지 걷는 비용 (부재 옆은 비싸게)
        private float[,] PathCost(Point from, HashSet<Point> blocked)
        {
            var cost = new float[_nx, _ny];
            for (int i = 0; i < _nx; i++)
                for (int j = 0; j < _ny; j++)
                    cost[i, j] = float.PositiveInfinity;
            cost[from.X, from.Y] = 0;
            var open = new SortedSet<Tuple<float, int, int>> { Tuple.Create(0f, from.X, from.Y) };
            while (open.Count > 0)
            {
                Tuple<float, int, int> cur = open.Min;
                open.Remove(cur);
                if (cur.Item1 > cost[cur.Item2, cur.Item3]) continue;
                for (int di = -1; di <= 1; di++)
                    for (int dj = -1; dj <= 1; dj++)
                    {
                        int i = cur.Item2 + di, j = cur.Item3 + dj;
                        if ((di == 0 && dj == 0) || !IsOpen(i, j) || blocked.Contains(new Point(i, j))) continue;
                        if (di != 0 && dj != 0 && (!IsOpen(cur.Item2 + di, cur.Item3) || !IsOpen(cur.Item2, cur.Item3 + dj))) continue;
                        float step = (di != 0 && dj != 0 ? 1.414f : 1f) * (_clear[i, j] == 1 ? 6f : _clear[i, j] == 2 ? 1.5f : 1f);
                        float c = cur.Item1 + step;
                        if (c >= cost[i, j]) continue;
                        cost[i, j] = c;
                        open.Add(Tuple.Create(c, i, j));
                    }
            }
            return cost;
        }

        private bool LineClear(Point a, Point b, HashSet<Point> onPath, HashSet<Point> blocked)
        {
            int n = Math.Max(Math.Abs(b.X - a.X), Math.Abs(b.Y - a.Y)) * 3;
            for (int s = 1; s < n; s++)
            {
                var p = new Point((int)Math.Round(a.X + (b.X - a.X) * (double)s / n), (int)Math.Round(a.Y + (b.Y - a.Y) * (double)s / n));
                if (!IsOpen(p.X, p.Y) || blocked.Contains(p)) return false;
                if (_clear[p.X, p.Y] < 2 && !onPath.Contains(p)) return false;
            }
            return true;
        }

        // 꺾이는 점을 반지름 최대 0.9 m 곡선으로 바꿔 촘촘히 나눔
        public static List<Vector3D> Smooth(List<Vector3D> r)
        {
            if (r.Count < 3) return r;
            var o = new List<Vector3D> { r[0] };
            for (int k = 1; k < r.Count - 1; k++)
            {
                Vector3D a = r[k - 1], b = r[k], c = r[k + 1];
                float la = Geo.Dist(a, b), lc = Geo.Dist(b, c);
                float rad = Math.Min(900f, Math.Min(la, lc) * 0.45f);
                if (rad < 50) { o.Add(b); continue; }
                var p1 = new Vector3D(b.X + (a.X - b.X) / la * rad, b.Y + (a.Y - b.Y) / la * rad, b.Z);
                var p2 = new Vector3D(b.X + (c.X - b.X) / lc * rad, b.Y + (c.Y - b.Y) / lc * rad, b.Z);
                for (int s = 0; s <= 4; s++)
                {
                    float t = s / 4f, u = 1 - t;
                    o.Add(new Vector3D(u * u * p1.X + 2 * u * t * b.X + t * t * p2.X, u * u * p1.Y + 2 * u * t * b.Y + t * t * p2.Y, b.Z));
                }
            }
            o.Add(r[r.Count - 1]);
            return o;
        }
        #endregion

        public RaycastHit Cast(Vector3D from, Vector3D dir, float max)
        {
            return _v.Object3D.Raycast(new Ray3D(from, dir), null, new RaycastOptions { MaxDistance = max });
        }
    }

    // 좌표 계산 도우미
    internal static class Geo
    {
        public static Vector3D Dir(Vector3D a, Vector3D b) { return Norm(new Vector3D(b.X - a.X, b.Y - a.Y, b.Z - a.Z)); }
        public static Vector3D Norm(Vector3D d) { float l = (float)Math.Sqrt(d.X * d.X + d.Y * d.Y + d.Z * d.Z); return new Vector3D(d.X / l, d.Y / l, d.Z / l); }
        public static Vector3D Up(Vector3D p, float dz) { return new Vector3D(p.X, p.Y, p.Z + dz); }
        public static float Dist(Vector3D a, Vector3D b) { return (float)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y)); }
        public static float Dist3(Vector3D a, Vector3D b) { return (float)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y) + (a.Z - b.Z) * (a.Z - b.Z)); }

        // 이동 방향 → 아바타 방위(0° = +Y, 반시계)
        public static double Heading(double dx, double dy) { return Math.Atan2(-dx, dy) * 180.0 / Math.PI; }

        public static double AngleDiff(double a, double b)
        {
            double d = (b - a) % 360;
            if (d > 180) d -= 360;
            if (d < -180) d += 360;
            return d;
        }
    }
}
