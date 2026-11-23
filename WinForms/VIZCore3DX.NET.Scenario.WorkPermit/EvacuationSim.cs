using System;
using System.Collections.Generic;

namespace VIZCore3DX.NET.Scenario.WorkPermit
{
    // 대피 시뮬레이션 — 대피 길목(계단·사다리·통로) 그래프 위에서 사람마다 최단 시간 경로를 고르고,
    // 응답 시간·보행 속도·길목 통과량(폭 1 m 당 1.33 명/s)에 따라 움직입니다. 뷰어와 무관한 계산만 합니다.
    // 경로 탐색은 SDK 기능이 아니라 이 예제의 앱 로직입니다(다익스트라).
    internal class EvacuationSim
    {
        internal class Link
        {
            public int A, B;
            public double LengthM;     // 이동 길이(m). 계단은 경사 길이, 사다리는 수직 길이
            public string Kind;        // "walk" · "stair" · "ladder"
            public double Headway;     // 한 사람이 들어간 뒤 다음 사람이 들어가기까지(s). 0 이면 제한 없음
            public double NextFree;    // 다음 사람이 들어갈 수 있는 시각(s)
            public bool Blocked;
            public int Waiting;        // 지금 줄 서 있는 사람 수(표시용)
        }

        internal class Segment
        {
            public Data.Vector3D From, To;
            public List<Data.Vector3D> Points; // 충돌 보행으로 구한 꺾은선(From…To). null 이면 직선
            public double Duration;
            public Link Link;          // 길목이면 통과량 제한, 아니면 null
            public double Start = -1;  // 시작 시각(s). -1 이면 아직
        }

        public class Agent
        {
            public int AvatarID;
            public Data.Vector3D Position;
            public double Heading;
            public double Response;
            public bool Arrived;
            internal double Walk, StairUp;
            internal List<Segment> Path = new List<Segment>();
            internal int Index;
        }

        private readonly List<Data.Vector3D> _nodes = new List<Data.Vector3D>();
        private readonly List<string> _names = new List<string>();
        private readonly List<Link> _links = new List<Link>();
        private readonly int _muster;   // 집결지 노드

        public List<Agent> Agents { get; private set; }
        public double Time { get; private set; }

        public EvacuationSim()
        {
            Agents = new List<Agent>();

            int floorPort = AddNode(ScenarioScript.NodeFloorPortLadder, "좌현 사다리");
            int platPort = AddNode(ScenarioScript.NodePlatformPortLadder, "");
            int floorStbd = AddNode(ScenarioScript.NodeFloorStbdLadder, "우현 사다리");
            int platStbd = AddNode(ScenarioScript.NodePlatformStbdLadder, "");
            AddLink(floorPort, platPort, "ladder", ScenarioScript.LadderWidth);
            AddLink(floorStbd, platStbd, "ladder", ScenarioScript.LadderWidth);

            // 계단 탑 — 단마다 디딤판 구간(stair)을 오르고, 계단참(landing)에서 옆줄로 건너 되꺾습니다.
            float[] levels = ScenarioScript.StairLevels;
            float middle = (ScenarioScript.StairLaneA + ScenarioScript.StairLaneB) / 2f;
            int from = AddNode(new Data.Vector3D(ScenarioScript.StairX0, ScenarioScript.StairLaneA, levels[0]), "계단");
            AddLink(platPort, from, "walk", 0f);
            AddLink(platStbd, from, "walk", 0f);
            for (int i = 1; i < levels.Length; i++)
            {
                bool forward = i % 2 == 1;   // 홀수 단은 A 줄에서 X0 → X1, 짝수 단은 B 줄에서 X1 → X0
                float endX = forward ? ScenarioScript.StairX1 : ScenarioScript.StairX0;
                int top = AddNode(new Data.Vector3D(endX, forward ? ScenarioScript.StairLaneA : ScenarioScript.StairLaneB, levels[i]), "");
                AddLink(from, top, "stair", ScenarioScript.StairWidth);

                float landingX = forward ? endX + ScenarioScript.LandingDepth / 2f : endX - ScenarioScript.LandingDepth / 2f;
                int landing = AddNode(new Data.Vector3D(landingX, middle, levels[i]), i == levels.Length - 1 ? "상갑판 출구" : "");
                AddLink(top, landing, "landing", 0f);
                if (i == levels.Length - 1) { from = landing; break; }

                int next = AddNode(new Data.Vector3D(endX, forward ? ScenarioScript.StairLaneB : ScenarioScript.StairLaneA, levels[i]), "");
                AddLink(landing, next, "landing", 0f);
                from = next;
            }

            _muster = AddNode(ScenarioScript.NodeMuster, "");
            AddLink(from, _muster, "walk", 0f);
        }

        // 계단을 나와 집결지로 가는 통로의 양 끝 (통로 판을 그릴 자리)
        public KeyValuePair<Data.Vector3D, Data.Vector3D> ExitWalk()
        {
            Link last = _links[_links.Count - 1];
            return new KeyValuePair<Data.Vector3D, Data.Vector3D>(_nodes[last.A], _nodes[last.B]);
        }

        // 화재 구역(margin 만큼 키운 상자) 안에 끝점이 있는 길목을 막습니다. 막힌 길목 수를 돌려줍니다.
        public int BlockNear(Data.BoundBox3D fire, float margin)
        {
            Data.BoundBox3D grown = new Data.BoundBox3D(fire.MinX - margin, fire.MinY - margin, fire.MinZ - margin, fire.MaxX + margin, fire.MaxY + margin, fire.MaxZ + margin);
            int count = 0;
            foreach (Link link in _links)
            {
                if (!grown.Contains(_nodes[link.A].ToVertex3D()) && !grown.Contains(_nodes[link.B].ToVertex3D())) continue;
                link.Blocked = true;
                count++;
            }
            return count;
        }

        // 막힌 길목의 이름과 위치 (표시용)
        public List<KeyValuePair<string, Data.Vector3D>> BlockedLinks()
        {
            var list = new List<KeyValuePair<string, Data.Vector3D>>();
            foreach (Link link in _links)
                if (link.Blocked && link.Kind != "walk") list.Add(new KeyValuePair<string, Data.Vector3D>(_names[link.A] + _names[link.B], Mid(link)));
            return list;
        }

        // 길목마다 줄 선 사람 수 (표시용, 사다리·계단만)
        public List<KeyValuePair<Data.Vector3D, int>> Queues()
        {
            var list = new List<KeyValuePair<Data.Vector3D, int>>();
            foreach (Link link in _links)
                if (link.Kind != "walk" && link.Waiting > 0) list.Add(new KeyValuePair<Data.Vector3D, int>(_nodes[link.A], link.Waiting));
            return list;
        }

        // 막히지 않은 길목의 선 (경로선 표시용). 계단 위에도 겹쳐 그려 디딤판 위의 줄무늬처럼 보이게 합니다.
        public List<List<Data.Vector3D>> OpenRoutes()
        {
            var routes = new List<List<Data.Vector3D>>();
            foreach (Link link in _links)
                if (!link.Blocked) routes.Add(new List<Data.Vector3D> { _nodes[link.A], _nodes[link.B] });
            return routes;
        }

        // 출발점에서 들어갈 길목 입구 — 같은 층(높이 차 0.5 m 이내) 노드 중 입구까지 걷는 시간 + 입구에서 집결지까지 최단 시간이 가장 작은 곳.
        // 평균 속도로 정하므로 같은 출발점이면 누구나 같은 입구입니다(입구까지의 충돌 보행 경로를 미리 구해 두기 위해). 없으면 null.
        public Data.Vector3D EntryFor(Data.Vector3D start)
        {
            int entry = Entry(start);
            return entry < 0 ? null : _nodes[entry];
        }

        // 길목 사이를 걷는 구간(사다리·계단이 아닌 곳)의 양 끝 — 충돌 보행 경로를 미리 구해 둘 구간
        public List<KeyValuePair<Data.Vector3D, Data.Vector3D>> WalkLinks()
        {
            var list = new List<KeyValuePair<Data.Vector3D, Data.Vector3D>>();
            foreach (Link link in _links)
                if (link.Kind == "walk" && !link.Blocked) list.Add(new KeyValuePair<Data.Vector3D, Data.Vector3D>(_nodes[link.A], _nodes[link.B]));
            return list;
        }

        // 사람을 추가하고 경로를 정합니다. 걷는 구간은 walkPath 가 준 꺾은선(충돌 보행 경로)을, 없으면(null) 직선을 따릅니다. 경로가 없으면 false.
        public bool AddAgent(int avatarID, Data.Vector3D start, Random random, Data.Vector3D musterSlot, Func<Data.Vector3D, Data.Vector3D, List<Data.Vector3D>> walkPath)
        {
            Agent agent = new Agent
            {
                AvatarID = avatarID,
                Position = start,
                Walk = Uniform(random, ScenarioScript.WalkSpeedMin, ScenarioScript.WalkSpeedMax),
                StairUp = Uniform(random, ScenarioScript.StairUpSpeedMin, ScenarioScript.StairUpSpeedMax),
                Response = random.NextDouble() * ScenarioScript.ResponseMaxSeconds,
            };

            int entry = Entry(start);
            if (entry < 0) return false;

            double[] cost;
            int[] previous;
            Dijkstra(AverageAgent(), out cost, out previous);

            agent.Path.Add(WalkSegment(agent, start, _nodes[entry], walkPath));
            for (int node = entry; node != _muster; node = previous[node])
            {
                Link link = Find(node, previous[node]);
                Segment segment = link.Kind == "walk"
                    ? WalkSegment(agent, _nodes[node], _nodes[previous[node]], walkPath)
                    : new Segment { From = _nodes[node], To = _nodes[previous[node]], Duration = link.LengthM / Speed(agent, link) };
                segment.Link = link;
                agent.Path.Add(segment);
            }

            // 마지막 구간은 집결지 가운데가 아니라 자기 자리로 — 꺾은선 끝에 자리를 덧붙입니다.
            Segment last = agent.Path[agent.Path.Count - 1];
            if (last.Points != null) last.Points.Add(musterSlot);
            last.To = musterSlot;
            last.Duration = (last.Points != null ? PolyLength(last.Points) : Distance(last.From, musterSlot)) / agent.Walk;
            Agents.Add(agent);
            return true;
        }

        private Segment WalkSegment(Agent agent, Data.Vector3D from, Data.Vector3D to, Func<Data.Vector3D, Data.Vector3D, List<Data.Vector3D>> walkPath)
        {
            List<Data.Vector3D> points = walkPath == null ? null : walkPath(from, to);
            double length = points != null ? PolyLength(points) : Distance(from, to);
            return new Segment { From = from, To = to, Points = points, Duration = length / agent.Walk };
        }

        private int Entry(Data.Vector3D start)
        {
            double[] cost;
            int[] previous;
            Agent average = AverageAgent();
            Dijkstra(average, out cost, out previous);

            int entry = -1;
            double best = double.MaxValue;
            for (int i = 0; i < _nodes.Count; i++)
            {
                if (Math.Abs(_nodes[i].Z - start.Z) > 500f || double.IsInfinity(cost[i])) continue;
                double total = Distance(start, _nodes[i]) / average.Walk + cost[i];
                if (total < best) { best = total; entry = i; }
            }
            return entry;
        }

        private static Agent AverageAgent()
        {
            return new Agent
            {
                Walk = (ScenarioScript.WalkSpeedMin + ScenarioScript.WalkSpeedMax) / 2,
                StairUp = (ScenarioScript.StairUpSpeedMin + ScenarioScript.StairUpSpeedMax) / 2,
            };
        }

        // 시각을 dt 초 진행하고 사람마다 위치를 갱신합니다.
        public void Step(double dt)
        {
            Time += dt;
            foreach (Link link in _links) link.Waiting = 0;

            foreach (Agent agent in Agents)
            {
                if (agent.Arrived || Time < agent.Response) continue;

                while (agent.Index < agent.Path.Count)
                {
                    Segment s = agent.Path[agent.Index];
                    if (s.Start < 0)
                    {
                        // 길목은 앞사람이 들어간 뒤 Headway 만큼 지나야 들어갑니다(통과량 상한).
                        double earliest = Math.Max(Time - dt, agent.Response);
                        s.Start = s.Link == null ? earliest : Math.Max(earliest, s.Link.NextFree);
                        if (s.Link != null) s.Link.NextFree = s.Start + s.Link.Headway;
                    }
                    if (Time < s.Start)
                    {
                        if (s.Link != null) s.Link.Waiting++;
                        break;
                    }

                    double t = s.Duration <= 0 ? 1.0 : Math.Min(1.0, (Time - s.Start) / s.Duration);
                    Data.Vector3D before = agent.Position;
                    agent.Position = s.Points != null ? AlongPolyline(s.Points, t) : Lerp(s.From, s.To, t);
                    double dx = agent.Position.X - before.X, dy = agent.Position.Y - before.Y;
                    if (Math.Abs(dx) + Math.Abs(dy) > 1.0) agent.Heading = Math.Atan2(-dx, dy) * 180.0 / Math.PI;
                    if (t < 1.0) break;
                    agent.Index++;
                }
                if (agent.Index >= agent.Path.Count) agent.Arrived = true;
            }
        }

        public bool IsFinished
        {
            get
            {
                foreach (Agent agent in Agents) if (!agent.Arrived) return false;
                return true;
            }
        }

        private int AddNode(Data.Vector3D position, string name)
        {
            _nodes.Add(position);
            _names.Add(name);
            return _nodes.Count - 1;
        }

        private void AddLink(int a, int b, string kind, float widthM)
        {
            // 계단·사다리도 양 끝을 잇는 실제 경사 길이 (속도는 Circ.1533 의 경사 길이 기준)
            double length = Distance(_nodes[a], _nodes[b]);
            double headway = widthM > 0f ? 1.0 / (ScenarioScript.FlowPerMeter * widthM) : 0.0;
            _links.Add(new Link { A = a, B = b, Kind = kind, LengthM = length, Headway = headway });
        }

        // 집결지에서 거꾸로 최단 시간을 구합니다. previous[i] 는 i 에서 집결지 쪽으로 다음 노드.
        private void Dijkstra(Agent agent, out double[] cost, out int[] previous)
        {
            int n = _nodes.Count;
            cost = new double[n];
            previous = new int[n];
            bool[] done = new bool[n];
            for (int i = 0; i < n; i++) { cost[i] = double.PositiveInfinity; previous[i] = -1; }
            cost[_muster] = 0;

            for (int round = 0; round < n; round++)
            {
                int u = -1;
                for (int i = 0; i < n; i++)
                    if (!done[i] && !double.IsInfinity(cost[i]) && (u < 0 || cost[i] < cost[u])) u = i;
                if (u < 0) break;
                done[u] = true;

                foreach (Link link in _links)
                {
                    if (link.Blocked || (link.A != u && link.B != u)) continue;
                    int v = link.A == u ? link.B : link.A;
                    double c = cost[u] + link.LengthM / Speed(agent, link);
                    if (c < cost[v]) { cost[v] = c; previous[v] = u; }
                }
            }
        }

        private Link Find(int a, int b)
        {
            foreach (Link link in _links)
                if ((link.A == a && link.B == b) || (link.A == b && link.B == a)) return link;
            return null;
        }

        private static double Speed(Agent agent, Link link)
        {
            if (link.Kind == "stair") return agent.StairUp;
            if (link.Kind == "ladder") return ScenarioScript.LadderUpSpeed;
            return agent.Walk;
        }

        private Data.Vector3D Mid(Link link)
        {
            return Lerp(_nodes[link.A], _nodes[link.B], 0.5);
        }

        private static double PolyLength(List<Data.Vector3D> points)
        {
            double length = 0;
            for (int i = 1; i < points.Count; i++) length += Distance(points[i - 1], points[i]);
            return length;
        }

        // 꺾은선 위에서 길이 비율 t(0~1) 자리
        private static Data.Vector3D AlongPolyline(List<Data.Vector3D> points, double t)
        {
            double target = PolyLength(points) * t;
            for (int i = 1; i < points.Count; i++)
            {
                double piece = Distance(points[i - 1], points[i]);
                if (target <= piece || i == points.Count - 1) return Lerp(points[i - 1], points[i], piece <= 0 ? 1.0 : Math.Min(1.0, target / piece));
                target -= piece;
            }
            return points[points.Count - 1];
        }

        private static double Distance(Data.Vector3D a, Data.Vector3D b)
        {
            return (b - a).Length() / 1000.0;
        }

        private static Data.Vector3D Lerp(Data.Vector3D a, Data.Vector3D b, double t)
        {
            return new Data.Vector3D(a.X + (b.X - a.X) * (float)t, a.Y + (b.Y - a.Y) * (float)t, a.Z + (b.Z - a.Z) * (float)t);
        }

        private static double Uniform(Random random, double min, double max)
        {
            return min + (max - min) * random.NextDouble();
        }
    }
}
