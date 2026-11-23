using System.Drawing;

namespace VIZCore3DX.NET.Scenario.Monitoring
{
    // 대본 표입니다. 장면의 설명·길이·좌표·사람 배치·색·문구를 이 파일 한 곳에 모읍니다.
    // 장면 메서드(FrmMain)는 이 표의 값을 그대로 보여 줄 뿐이므로, 시연 내용을 바꾸려면 이 표만 고칩니다.
    internal static class ScenarioScript
    {
        // ------------------------------------------------------------
        // 장면 (이름 · 설명 · 길이 초) — 재생 순서
        // ------------------------------------------------------------
        public static readonly ScenarioShot Watch = new ScenarioShot("01 상시 감시",
            "기관실 상시 감시\nCCTV 2대 · 레이더 · 가스 감지기 — 작업자 9명 · 순찰 5명", 7.5);

        public static readonly ScenarioShot Leak = new ScenarioShot("02 누수 발생",
            "이상 발생 — 신호수 옆 배관 누수\n가스 감지기 GD 1 경보", 6);

        public static readonly ScenarioShot LeakZoom = new ScenarioShot("03 누수 화면 확대",
            "CCTV 화면에 누수 포착\n화면 확대", 4.5);

        public static readonly ScenarioShot DispatchA = new ScenarioShot("04 정비사 A 출동",
            "정비사 A 출동\n누수 지점으로 달려갑니다", 6.5);

        public static readonly ScenarioShot Repair = new ScenarioShot("05 누수 조치",
            "누수 부위 조치\n조치 완료 — 가스 감지기 정상", 6.5);

        public static readonly ScenarioShot Resume = new ScenarioShot("06 정상 감시 재개",
            "정상 감시 재개\n신호수 복귀 · 4분할 화면", 5.5);

        public static readonly ScenarioShot Intrusion = new ScenarioShot("07 출입 금지 구역 침입",
            "RADAR 1 — 출입 금지 구역 침입 감지\n작업자 C", 5.5);

        public static readonly ScenarioShot IntruderZoom = new ScenarioShot("08 침입자 화면 확대",
            "CCTV 화면 확대\n침입자 확인", 5);

        public static readonly ScenarioShot Escort = new ScenarioShot("09 정비사 B 안내",
            "정비사 B 출동 — 구역 밖으로 안내\n작업자 C 구역 이탈", 9.5);

        public static readonly ScenarioShot AllClear = new ScenarioShot("10 경보 해제",
            "작업자 C 구역 이탈 — 경보 해제\n모든 이상 조치 완료 — 상시 감시 중", 5.5);

        // 리본 장면 버튼의 문구 (재생 순서). 한 줄 80px 를 넘으면 띄어쓰기에서 두 줄로 나뉘고, '/' 를 넣으면 그 자리에서 나뉩니다.
        // 같은 문구가 이어지면 버튼 하나로 묶여, 누르면 그 장면들을 이어서 재생합니다.
        public static readonly string[] SceneLabels = { "상시 감시", "누수 발생", "누수 확대", "정비사 A", "누수 조치", "감시 재개", "침입 감지", "침입 확대", "정비사 B", "경보 해제" };

        // ------------------------------------------------------------
        // 장면 안의 문구 (3D 뷰 왼쪽 위 · 창 제목줄)
        // ------------------------------------------------------------
        public const string TextWatch = "기관실 상시 감시 — CCTV 2대 · 레이더 · 가스 감지기";
        public const string TextLeak = "이상 발생 — 신호수 옆 배관 누수";
        public const string TextGasAlarm = "가스 감지기 GD 1 경보 — 누수 지점까지 {0:0.0} m";
        public const string TextLeakZoom = "{0}에 누수 포착 — 화면 확대";
        public const string TextDispatchA = "정비사 A 출동";
        public const string TextRepairing = "{0} — 누수 부위 조치 중…";
        public const string TextRepaired = "누수 조치 완료 — 가스 감지기 정상";
        public const string TextResume = "정상 감시 재개";
        public const string TextIntruderMoving = "작업자 C 가 출입 금지 구역 쪽으로 이동";
        public const string TextIntrusion = "RADAR 1 — 출입 금지 구역 침입 감지 · 작업자 C";
        public const string TextIntruderZoom = "{0} 화면 확대 — 침입자 확인";
        public const string TextDispatchB = "정비사 B 출동 — 구역 밖으로 안내";
        public const string TextExit = "작업자 C 구역 이탈 — 경보 해제";
        public const string TextAllClear = "모든 이상 조치 완료 — 상시 감시 중";
        // 문구 아래 줄 — 가스 감지기 상태와 출입 금지 구역 안 인원
        public const string TextHudTail = "가스 감지기 {0} · 출입 금지 구역 {1}명";
        public const string TextGasOn = "경보";
        public const string TextGasOff = "정상";

        // 3D 효과 문구
        public const string LabelGas = "⚠ GD 1 가스 감지";
        public const string LabelLeak = "누수";
        public const string LabelRepaired = "누수 조치 완료";
        public const string LabelIntrusion = "⚠ RADAR 1 — 출입 금지 구역 침입";
        public const string LabelExit = "✔ 구역 이탈 확인";
        public const string NoGoName = "출입 금지 구역";

        // ------------------------------------------------------------
        // 모델 — 샘플 선박 모델(선미부) 기관실 8.93 m 플랫폼 (mm)
        // ------------------------------------------------------------
        public const float Deck = 8930f;

        // 출입 금지 구역 (좌현 앞쪽)
        public static readonly Data.BoundBox3D NoGo = new Data.BoundBox3D(24000f, -11000f, Deck, 28500f, -7000f, Deck + 2500f);

        // 누수: CAM 2 에 보이는 우현 쪽 벽 바로 앞
        public static readonly Data.Vector3D LeakPoint = new Data.Vector3D(23113.81f, 5295.913f, 10754.07f);

        // ------------------------------------------------------------
        // 센서 — 자리·방향은 이 모델에 맞춰 미리 정해 둔 값
        // ------------------------------------------------------------
        // CAM 1: 좌현 선미 천장 돔, 앞쪽 플랫폼을 넓게
        public static readonly Data.Vector3D CamAPosition = new Data.Vector3D(11500f, -9500f, 14302.31f);
        public static readonly Data.Vector3D CamADirection = new Data.Vector3D(0.8517048f, 0.2839016f, -0.440453f);
        // CAM 2: 좌현 선측 벽 불릿, 가운데 개구부 너머 우현을 봄
        public static readonly Data.Vector3D CamBPosition = new Data.Vector3D(20000f, -14930.03f, 12800f);
        public static readonly Data.Vector3D CamBDirection = new Data.Vector3D(0.09285233f, 0.9754616f, -0.1996325f);
        public static readonly Data.Vector3D CamBMount = new Data.Vector3D(0, -1, 0);
        // 레이더: 출입 금지 구역 옆 천장에서 구역을 내려다봄
        public static readonly Data.Vector3D RadarPosition = new Data.Vector3D(22500f, -7000f, 14018.47f);
        public static readonly Data.Vector3D RadarDirection = new Data.Vector3D(0.6144496f, -0.3277064f, -0.7176771f);
        public static readonly Data.Vector3D RadarMount = new Data.Vector3D(0, 0, 1);
        public const float RadarDistance = 6103f;
        public const float RadarRangeExtra = 4000f;
        // 가스 감지기: 누수 앞 통로 천장
        public static readonly Data.Vector3D GasPosition = new Data.Vector3D(22713.81f, 4195.913f, 14055.5f);
        public static readonly Data.Vector3D GasDirection = new Data.Vector3D(0, 0, -1);

        public const string NameCamA = "CAM 1";
        public const string NameCamB = "CAM 2";
        public const string NameRadar = "RADAR 1";
        public const string NameGas = "GD 1";

        // 센서 기본 시야: CCTV 화각(가로·세로°), 판정 거리(mm) · 표식 크기(mm)
        public const double CctvH = 100, CctvV = 65, CctvRange = 25000;
        public const double RadarH = 110, RadarV = 75;
        public const double GasRange = 4500;
        public const int SensorSizeMm = 450;

        // 확대(PTZ) 화각(°)과 걸리는 시간(초)
        public const double ZoomFov = 24, ZoomSec = 2.2;

        // ------------------------------------------------------------
        // 사람 배치 (x, y, 방위°)
        // ------------------------------------------------------------
        // 제자리 작업자 — 사람마다 다른 자세로 일함
        public static readonly WorkerSpot[] Workers =
        {
            new WorkerSpot(16500, -7300, 20, "Sit 2", "용접공 1", "Sit 2", "weld", 1.3f),
            new WorkerSpot(19500, -7600, 150, "Seeing 30", "그라인더공", "Seeing 30", "grind", 2.4f),
            new WorkerSpot(22000, -6300, 0, "Seeing 30", "용접공 2", "Hands Half Up", "overhead", 0.8f),
            new WorkerSpot(17500, 7600, 90, "Sit 2", "용접공 3", "Sit 3", "weld", 0.7f),
            new WorkerSpot(26000, 7200, 0, "Sit 2", "절단공", "Sit 2", "cut", 1.7f),
        };

        // 신호수 — 개구부 앞에서 아래쪽에 신호. 누수가 나면 물러나 지켜볼 자리
        public const float SignalX = 21800, SignalY = 4300;
        public const double SignalHeading = 180;
        public const string SignalFitPosture = "Seeing 90";
        public const string SignalName = "신호수";
        public const float SignalWatchX = 25200, SignalWatchY = 4600;
        // 손을 든 뒤 물러나기까지(초)
        public const double SignalRaiseSec = 1.5;

        // 정비사 A · 정비사 B · 작업자 C
        public const float TechAX = 17000, TechAY = 6200;
        public const double TechAHeading = 90;
        public const string TechAName = "정비사 A";
        public const float TechBX = 21800, TechBY = -10300;
        public const double TechBHeading = 180;
        public const string TechBName = "정비사 B";
        public const float WorkerCX = 22500, WorkerCY = -8800;
        public const double WorkerCHeading = -90;
        public const string WorkerCName = "작업자 C";
        public const string StandFitPosture = "Seeing 30";
        public const string WorkerCPosture = "Hands Half Up";

        // 순찰자 5명: 두 지점 사이를 계속 오감 (출입 금지 구역은 피해 감) — (출발 x, y, 도착 x, y, 방위°, 이름)
        public static readonly System.Tuple<float, float, float, float, double, string>[] Patrols =
        {
            System.Tuple.Create(14000f, -8500f, 23000f, -12000f, -90.0, "순찰 1"),
            System.Tuple.Create(14500f, 8500f, 28000f, 9500f, -90.0, "순찰 2"),
            System.Tuple.Create(12000f, -3500f, 12000f, 3500f, 0.0, "순찰 3"),
            System.Tuple.Create(29500f, -6000f, 29500f, 6000f, 0.0, "순찰 4"),
            System.Tuple.Create(20000f, 11500f, 13000f, 6500f, 90.0, "순찰 5"),
        };
        // 순찰 끝에서 섰다가 되돌아가기까지(초)
        public const double PatrolPauseSec = 1.0;

        // 정비사 A 가 설 자리 — 누수 지점에서 통로 쪽(-Y)으로
        public const float TechSpotOffsetY = -900f;

        // 출동할 때 · 평소 걸음(mm/s)
        public const float HurrySpeed = 1750f;
        public const float WalkSpeed = 1300f;

        // 작업자 C 가 들어갈 칸 — 구역 경계에서 들어가는 깊이 · 구역 앞뒤 가장자리 여유 · 구역 안쪽 판정 여유(mm)
        public const float IntrudeDepth = 1500f;
        public const float IntrudeEdgeMargin = 800f;
        public const float IntrudeInnerMargin = -700f;

        // 정비사 B 가 설 자리(구역 앞 x 여유, y) · 작업자 C 가 나가서 설 자리
        public const float EscortOffsetX = 700f, EscortY = -9000f;
        public const float ExitOffsetX = 1400f, ExitY = -8000f;

        // 경보 해제 뒤 작업자 C · 정비사 B 가 제자리 점검할 때 바라볼 방위(°)
        public const double WorkerCIdleHeading = 180;
        public const double TechBIdleHeading = -90;

        // ------------------------------------------------------------
        // 장면 안의 시각 (장면 시작 기준 초)
        // ------------------------------------------------------------
        public const double GasAlarmAt = 2.5;
        public const double RepairSec = 4.0;
        public const double ResumeSignalAt = 1.0;
        public const double ResumeTechAt = 2.0;
        public const double ResumeSplitAt = 2.5;
        public const double AllClearIdleAt = 1.5;
        public const double AllClearSplitAt = 3.0;
        // 정비사 B 가 손짓한 뒤 작업자 C 가 돌아서기까지 · 돌아선 뒤 걷기 시작하기까지(초)
        public const double EscortTurnDelay = 0.6;
        public const double EscortWalkDelay = 1.0;

        // ------------------------------------------------------------
        // 색 · 크기
        // ------------------------------------------------------------
        public static readonly Color Orange = Color.FromArgb(255, 140, 0);
        public static readonly Color Red = Color.FromArgb(230, 40, 40);
        public static readonly Color Green = Color.FromArgb(40, 170, 80);
        public static readonly Color GasColor = Color.FromArgb(225, 200, 40);
        public static readonly Color RadarPulseColor = Color.FromArgb(0, 200, 255);
        public static readonly Color WaterStartColor = Color.FromArgb(120, 190, 255);
        public static readonly Color WaterEndColor = Color.FromArgb(60, 150, 255);

        public const int LabelSizePx = 28;
        public const int GasLabelSizePx = 30;
        public const int MarkerSizePx = 68;
        public const int SpinnerSizePx = 72;
        public const int SpinnerThicknessPx = 9;

        // ------------------------------------------------------------
        // 3D 화면
        // ------------------------------------------------------------
        // 3D 뷰 왼쪽 위 문구 — 어두운 상자 위 글자(화면 고정 노트). 상자 왼쪽 위 모서리를 여백에 맞춥니다(Size_40 ≈ 33px 높이).
        public const float HudMarginPixels = 14f;
        public static readonly Color HudColor = Color.FromArgb(255, 214, 0);
        public const Data.TextSizeType HudTextSize = Data.TextSizeType.Size_24;

        // 노트 표시 — 어두운 상자 · 주황 선
        public static readonly Color ColorPanel = Color.FromArgb(230, 22, 30, 44);
        public static readonly Color ColorAccent = Color.FromArgb(255, 160, 0);
    }

    // 제자리 작업자 한 명 — 자리(x, y, 방위°), 자리 맞춤 자세, 이름, 작업 자세, 작업 종류(weld · grind · cut · overhead), 불똥 크기
    internal class WorkerSpot
    {
        public readonly float X, Y;
        public readonly double Heading;
        public readonly string FitPosture, Name, WorkPosture, Kind;
        public readonly float Scale;

        public WorkerSpot(float x, float y, double heading, string fitPosture, string name, string workPosture, string kind, float scale)
        {
            X = x;
            Y = y;
            Heading = heading;
            FitPosture = fitPosture;
            Name = name;
            WorkPosture = workPosture;
            Kind = kind;
            Scale = scale;
        }
    }
}
