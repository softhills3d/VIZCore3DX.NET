using System.Drawing;

namespace VIZCore3DX.NET.Scenario.Safety
{
    // 대본 표입니다. 장면의 설명·길이·좌표·색·시각을 이 파일 한 곳에 모읍니다.
    // 장면 메서드(FrmMain)는 이 표의 값을 그대로 보여 줄 뿐이므로, 시연 내용을 바꾸려면 이 표만 고칩니다.
    // 좌표는 샘플 선박 모델 AftSection(선미부)의 기관실 8.93 m 플랫폼에 맞춰 있습니다(mm).
    internal static class ScenarioScript
    {
        // ------------------------------------------------------------
        // 장면 (이름 · 설명 · 길이 초) — 재생 순서
        // 1부: 작업 중 → 폭염 → 가스 누출 → 대피 / 2부: 화기 작업 허가 / 3부: 낙하물 · 추락
        // ------------------------------------------------------------
        public static readonly ScenarioShot Working = new ScenarioShot("01 현장 작업",
            "현장 작업\n기관실 플랫폼에서 6명이 작업 중입니다", 4.5);

        public static readonly ScenarioShot HeatStress = new ScenarioShot("02 폭염 이상 징후",
            "폭염 — 작업자 E 쓰러짐\n옆 작업자가 알아채 작업을 멈추고, 상태를 살핀 뒤 그늘로 데려가 쉬게 합니다", 16.5);

        public static readonly ScenarioShot GasLeak = new ScenarioShot("03 가스 누출",
            "가스 누출\n현장 옆 배관에서 가스가 새어 모두 작업을 멈춥니다", 4);

        public static readonly ScenarioShot Escape = new ScenarioShot("04 집결지 대피",
            "집결지 대피\n집결지 구역(Zone)이 들어온 인원을 세어 6명 전원 집결을 확인합니다", 9);

        public static readonly ScenarioShot Designate = new ScenarioShot("05 화기 작업 구역 지정",
            "화기 작업 구역 지정 — 허가 " + PermitNo + "\n가스를 조치한 뒤 현장을 구역으로 지정하고 폴리스 라인을 칩니다", 4);

        public static readonly ScenarioShot EnterPermitted = new ScenarioShot("06 허가자 입장",
            "허가자 입장\n용접공 A · 그라인더공 B 가 구역에 들어가 화기 작업을 시작합니다", 7.5);

        public static readonly ScenarioShot Intrude = new ScenarioShot("07 무허가 출입",
            "무허가 출입\n작업자 C 가 구역에 들어온 순간을 구역 이벤트가 잡습니다", 4.5);

        public static readonly ScenarioShot OrderOut = new ScenarioShot("08 퇴거 지시",
            "퇴거 지시\n경보 · 작업 중지, 화재감시자가 작업자 C 에게 나가라고 알립니다", 4);

        public static readonly ScenarioShot ComeOut = new ScenarioShot("09 퇴거 · 작업 재개",
            "무허가자 퇴거\n작업자 C 가 구역을 나가면 경보를 풀고 작업을 다시 시작합니다", 7);

        public static readonly ScenarioShot SparkFire = new ScenarioShot("10 불티 화재",
            "불티 화재\n용접 불티가 가연물에 옮겨붙고, 화재감시자가 발견해 경보합니다", 6);

        public static readonly ScenarioShot Extinguish = new ScenarioShot("11 초기 진화",
            "초기 진화\n작업자는 구역 밖으로 피하고, 화재감시자가 소화기로 불을 끕니다", 11);

        public static readonly ScenarioShot EndWork = new ScenarioShot("12 작업 종료 · 구역 해제",
            "작업 종료\n구역 안 잔류 인원 0명 — 구역을 해제하고 허가 " + PermitNo + " 를 반납합니다", 4);

        public static readonly ScenarioShot FallingObject = new ScenarioShot("13 낙하물",
            "낙하물\n통로 위 작업자 F 가 찬 자재가 아래 계단참 작업자 G 의 머리에 떨어집니다", 7);

        public static readonly ScenarioShot FallFromEdge = new ScenarioShot("14 추락 · 구호",
            "추락\n작업자 F 가 통로 끝에서 떨어지고, 아래층 작업자들이 달려와 구호를 시작합니다", 9.5);

        // 리본 장면 버튼의 문구 (재생 순서). 한 줄 80px 를 넘으면 띄어쓰기에서 두 줄로 나뉩니다.
        public static readonly string[] SceneLabels = { "작업 중", "폭염", "가스 누출", "대피", "구역 지정", "허가자", "무허가", "퇴거 지시", "작업 재개", "불티 화재", "초기 진화", "작업 종료", "낙하물", "추락" };

        // ------------------------------------------------------------
        // 현장 — 기관실 8.93 m 플랫폼 (mm)
        // ------------------------------------------------------------
        public const float Deck = 8930f;

        // 작업 현장 = 나중에 화기 작업 구역으로 지정하는 곳 (좌현 앞쪽)과 허가 번호
        public static readonly Data.BoundBox3D WorkArea = new Data.BoundBox3D(24000f, -11000f, Deck, 28500f, -7000f, Deck + 2500f);
        public const string PermitNo = "HW-012";

        // 폴리스 라인: 띠 높이(mm)
        public static readonly float[] TapeHeights = { 500f, 1000f };

        // 집결지 (현장 선미 쪽 통로): 첫 자리와 자리 간격(mm). 여섯 자리를 3 × 2 로 둡니다.
        public static readonly float[] Muster = { 20000f, -8300f };
        public const float SlotGap = 900f;

        // 걸음(mm/s): 2부 이후 보통 걸음, 1부 걸음
        public const float WalkSpeed = 1600f, Part1Speed = 2100f;

        // 처음 자리 { X, Y, 방위 } — 용접공 A · 그라인더공 B 는 허가자, 작업자 C 는 무허가, 화재감시자는 구역 밖
        public static readonly float[] WelderAt = { 25000f, -10000f, 0f };
        public static readonly float[] GrinderAt = { 25300f, -8400f, 90f };
        public static readonly float[] IntruderAt = { 26800f, -9900f, 180f };
        public static readonly float[] WorkerDAt = { 27400f, -8000f, -90f };
        public static readonly float[] WorkerEAt = { 24600f, -7700f, 0f };
        public static readonly float[] WatchAt = { 26200f, -7400f, 180f };

        // ------------------------------------------------------------
        // 색
        // ------------------------------------------------------------
        public static readonly Color Yellow = Color.FromArgb(255, 214, 0);
        public static readonly Color Red = Color.FromArgb(230, 40, 40);
        public static readonly Color Green = Color.FromArgb(40, 170, 80);
        public static readonly Color GasColor = Color.FromArgb(225, 200, 40);

        // ------------------------------------------------------------
        // 장면 안 시각 (장면 시작 · 도착 뒤 초)
        // ------------------------------------------------------------
        // 폭염: 쓰러짐 · 옆 사람이 알아챔 · 두 명이 다가감 / 살피기 시작한 뒤 E 가 일어남 · 그늘로 감
        public const double HeatLieDownAt = 0.6, HeatNoticeAt = 1.8, HeatHelpAt = 3.8;
        public const double HeatSitUpAfter = 3.0, HeatToShadeAfter = 4.5;

        // 불티 화재: 불꽃으로 커짐 · 화재감시자 발견 / 초기 진화: 불꽃이 잦아듦 · 연기가 걷힘(뿌리기 시작한 뒤)
        public const double FlameAt = 2.0, FireAlarmAt = 3.0;
        public const double FlameOutAfter = 2.5, SmokeOutAfter = 4.0;

        // 작업 종료: 구역이 비었을 때 해제까지
        public const double ReleaseAfter = 0.3;

        // 낙하물: 작업자 F 가 걷기 시작하는 시각 (처음부터 볼 때 · 2부에 이어 카메라를 옮겨 올 때)
        public const double KickWalkAt = 1.5, KickWalkAtContinued = 2.2;

        // ------------------------------------------------------------
        // 3부 낙하 (mm)
        // ------------------------------------------------------------
        // 걷어차여 떨어지는 바닥 자재(모델 부품 이름), 플랫폼 난간 밖 계단 위 통로(8.63 m)에서
        // F 가 걷는 길(시작 X, Y, 끝 X), 자재를 놓아 둘 자리, 자재가 빠지는 통로 끝, 아래 계단참(5.52 m)의 G 자리
        public const string DropPart = "AS-O01-0077-PT013";
        public static readonly float[] DropWalk = { 18800f, -5050f, 19900f };
        public static readonly float[] DropStart = { 19300f, -4750f };
        public static readonly float[] DropEdge = { 19250f, -4560f };
        public static readonly float[] DropBelow = { 18800f, -3950f };

        // 3부 처음 구도 { 주시점 X, Y, Z, 방위, 고도, 거리 }, 추락: F 가 내려다보는 방향(+Y)과 바닥에 누운 방향(-X), 카메라 눈 자리(고정)
        public static readonly double[] FallViewStart = { 19900, -4350, 7000, 94, 42, 12500 };
        public const double FallHeading = 0, LandHeading = 90;
        public static readonly float[] FallEye = { 19300f, 2200f, 13800f };

        // 아래층(2.13 m 평평한 바닥)을 오가는 작업자들: 한 줄에 { 시작 X, Y, 끝 X, Y } (mm), 걷는·달리는 속도(mm/s)
        public static readonly float[][] BelowRoutes =
        {
            new[] { 21200f, -2600f, 23400f, -2700f },
            new[] { 22600f, -1800f, 20900f, -1700f },
            new[] { 23600f, -3200f, 21600f, -3100f },
            new[] { 22000f, -2200f, 23900f, -2000f },
        };
        public const float BelowWalk = 1100f, BelowRun = 3200f;

        // ------------------------------------------------------------
        // 화면
        // ------------------------------------------------------------
        // 처음 구도 { 주시점 높이(구역 바닥 위), 방위, 고도, 거리 }
        public static readonly double[] SiteView = { 300, 180, 22, 11500 };

        // 3D 뷰 왼쪽 위 문구 — 어두운 상자 위 글자(화면 고정 노트). 상자 왼쪽 위 모서리를 여백에 맞춥니다(Size_40 ≈ 33px 높이).
        public const float HudMarginPixels = 14f;
        public static readonly Color HudColor = Color.FromArgb(255, 214, 0);
        public const Data.TextSizeType HudTextSize = Data.TextSizeType.Size_40;

        // 노트 표시 — 어두운 상자 · 흰 글씨 · 주황 선
        public static readonly Color ColorPanel = Color.FromArgb(230, 22, 30, 44);
        public static readonly Color ColorAccent = Color.FromArgb(255, 160, 0);
    }
}
