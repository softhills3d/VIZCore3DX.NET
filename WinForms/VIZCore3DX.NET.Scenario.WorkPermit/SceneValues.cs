using System.Collections.Generic;
using System.Drawing;

namespace VIZCore3DX.NET.Scenario.WorkPermit
{
    // 장면에 쓰는 값(위치·방향·색·판정 기준·문구)을 한 곳에 모읍니다.
    // 이 좌표들은 SDK 샘플 모델 선박\AftSection_RevA.vizx 에서 잰 값입니다. 실제 데이터에서는 이 표를 그 모델의 구획에 맞게 갈아 끼웁니다.
    //
    // 판정 기준 옆의 [ ] 는 근거 수준입니다 — [1차] 원문 확인 · [2차] 해설·2차 자료 · [예시값] 출처 없음(사내 기준으로 바꿀 값).
    internal static class SceneValues
    {
        // ------------------------------------------------------------
        // 3D 화면
        // ------------------------------------------------------------
        // 3D 뷰 왼쪽 위 문구 (화면 좌표)
        public static readonly Data.Vector2 HudPosition = new Data.Vector2(40f, 40f);
        public static readonly Color HudColor = Color.FromArgb(255, 214, 0);

        // 카메라가 대상을 바라보는 방향 (시선). 정확히 수직(0,0,±1)은 쓰지 않습니다.
        public static readonly Data.Vector3D ViewOverview = new Data.Vector3D(-0.6f, 0.6f, -0.5f);
        public static readonly Data.Vector3D ViewZone = new Data.Vector3D(-0.7f, 0.45f, -0.45f);
        public static readonly Data.Vector3D ViewEvacuation = new Data.Vector3D(0.55f, 0.65f, -0.5f);

        // 대피 중에는 사람들이 올라가는 계단 기둥(플랫폼 → 제2갑판 → 상갑판)을 좌현 쪽에서 거의 수평으로 봅니다 — 선미 구조가 앞을 가리지 않는 방향입니다.
        public static readonly Data.Vector3D ViewClimb = new Data.Vector3D(-0.1f, -1f, -0.15f);
        public static readonly Data.BoundBox3D ClimbBox = new Data.BoundBox3D(11500f, 0f, 5520f, 24500f, 10000f, 21000f);
        // 계단을 오르는 동안의 카메라 — 장면 시작 뒤 이 시각(초)에 이 상자로 옮깁니다 : 아래 두 단 가까이 → 위 두 단 가까이 → 다시 전체
        public static readonly KeyValuePair<double, Data.BoundBox3D>[] ClimbShots =
        {
            new KeyValuePair<double, Data.BoundBox3D>(9.0, new Data.BoundBox3D(14500f, 4800f, 8930f, 19400f, 7000f, 14500f)),
            new KeyValuePair<double, Data.BoundBox3D>(16.0, new Data.BoundBox3D(14500f, 4800f, 14500f, 19400f, 7000f, 21000f)),
            new KeyValuePair<double, Data.BoundBox3D>(23.0, ClimbBox),
        };
        public const double ClimbShotSeconds = 3.0;

        // 빠르게 재생 중이라는 표시 (화면 좌표) — 일반 안내 문구 아래에 크게
        public static readonly Data.Vector2 SpeedHudPosition = new Data.Vector2(40f, 80f);
        public const string SpeedHudText = "▶▶ {0:0}배속으로 빠르게 재생 중 — 실제 경과 {1:0}초";

        // 대상을 화면에 맞출 때 둘레에 두는 여유 (1 = 꽉 채움)
        public const float FitMargin = 1.3f;

        // 처음·마지막 장면에서 모델을 도는 각도(도)
        public const float OrbitDegrees = 30f;

        // ------------------------------------------------------------
        // 작업 허가 — 샘플 모델의 실제 구획에서 잰 좌표(mm)입니다.
        // 갑판 높이: 이중저 윗면 약 2,115 · 기관실 플로어 5,520 · 플랫폼 8,930 · 제2갑판 14,500 · 상갑판 약 19,700 · 연돌 꼭대기 갑판 약 37,700.
        // ------------------------------------------------------------
        // P1 도장 — 이중저 탱크 칸. 앞뒤는 늑판 자리(X 18,894 · 24,494), 나머지 네 면은 둘레의 실제 판에서 찾은 평면으로 닫습니다
        // (안쪽 거더 · 바깥 빌지 외판 · 위 이중저 윗면 · 아래 선저 외판). 선저가 30° 기울어 있어 단면이 쐐기 모양입니다. 활성.
        // 이 상자는 판을 찾는 범위·카메라 맞춤·다른 모델 확인에 쓰고, 판을 못 찾으면 이 상자 그대로 공간이 됩니다.
        // 중앙부(Y ±1,190)는 600·1,600 mm 높이 수평판으로 칸이 나뉘어 사람이 들어갈 수 없으므로 그 옆 칸을 씁니다.
        public static readonly Data.BoundBox3D ZoneKeel = new Data.BoundBox3D(18894f, 1990f, 0f, 24494f, 3470f, 2115f);
        // 탱크 안의 한 점(판이 어느 쪽에 있는지의 기준)과 둘레 판을 찾는 범위
        public static readonly Data.Vector3D TankSeed = new Data.Vector3D(21500f, 2730f, 1300f);
        public static readonly Data.BoundBox3D TankSearch = new Data.BoundBox3D(18894f, 1500f, -300f, 24494f, 4600f, 2500f);

        // P2 화기 — 이중저 탱크 바로 위 기관실 플로어 용접 (플로어 ~ 작업 높이 2.3 m). 요청.
        public static readonly Data.BoundBox3D ZoneFloorHot = new Data.BoundBox3D(20000f, -3000f, 5520f, 27000f, 3000f, 7800f);

        // P3 화기 — 기관실 플랫폼 위 배관 지지대 용접 (지지대·발판이 가장 많이 몰린 곳). 활성.
        public static readonly Data.BoundBox3D ZonePlatformHot = new Data.BoundBox3D(22000f, 4000f, 8930f, 28000f, 11800f, 12000f);

        // P4 고소 — 연돌 상부 의장. 위·아래는 작업 범위 높이, 옆 네 면은 연돌의 실제 판에서 찾은 평면으로 닫습니다
        // (옆판은 위로 3° 좁아지고 선미 쪽 판은 10° 누워 있음). 판을 못 찾으면 이 상자 그대로. 활성.
        public static readonly Data.BoundBox3D ZoneFunnel = new Data.BoundBox3D(7700f, -2800f, 34500f, 15700f, 2800f, 38700f);
        // 둘레 판을 찾을 때 상자를 이만큼 키워 봅니다(mm). 판으로 볼 최소 넓이(m²)와, 찾는 방향에 대한 판의 기울기 한도(코사인)
        public const float WallSearchMargin = 600f;
        public const double WallMinArea = 1.0;
        public const float WallMinAlign = 0.8f;

        // P5 상갑판 계류 의장 — 연돌 아래 상갑판. 정지(교대 대기).
        public static readonly Data.BoundBox3D ZoneDeck = new Data.BoundBox3D(14000f, -6000f, 19700f, 20000f, 6000f, 22000f);

        // 플랫폼 화기 바로 아래 플로어의 가연물(보온재·도장면) 자리 — 허가가 아니라 위험물 자리
        public static readonly Data.BoundBox3D ZoneCombustible = new Data.BoundBox3D(19000f, 4000f, 5520f, 25000f, 11800f, 7800f);

        public const string NameKeel = "P1 도장 · 이중저 탱크";
        public const string NameFloorHot = "P2 화기 · 플로어 용접 (요청)";
        public const string NamePlatformHot = "P3 화기 · 플랫폼 배관 지지대";
        public const string NameFunnel = "P4 고소 · 연돌 상부 의장";
        public const string NameDeck = "P5 상갑판 계류 의장 (정지)";
        public const string NameCombustible = "가연물 · 보온재·도장면";
        public const string NameDrop = "낙하물 통제 구역";

        public static readonly Color ColorPaint = Color.FromArgb(40, 120, 230);
        // 색 역할 — 빨강은 "지금 불을 쓰는 활성 화기"와 금지 표시에만, 강조선(반경·겹침·치수)은 노랑, 위험물 자리는 청록.
        public static readonly Color ColorHot = Color.FromArgb(230, 60, 40);
        public static readonly Color ColorHotRequested = Color.FromArgb(240, 140, 170);
        public static readonly Color ColorAccent = Color.FromArgb(255, 214, 0);
        public static readonly Color ColorNote = Color.FromArgb(50, 55, 65);
        // 탱크 바닥(선저 외판)을 밝게 — 원래 색이 배경과 같은 남색이라 그대로는 작업자가 떠 보입니다. 정리할 때 되돌립니다.
        public static readonly Color ColorTankFloor = Color.FromArgb(205, 210, 215);
        public static readonly Color ColorHeight = Color.FromArgb(250, 160, 20);
        // 정지 허가 — 회색은 X-Ray 배경에 묻히므로 다른 역할과 겹치지 않는 갈색으로
        public static readonly Color ColorSuspended = Color.FromArgb(165, 110, 55);
        public static readonly Color ColorCombustible = Color.FromArgb(0, 175, 165);
        public static readonly Color ColorConfined = Color.FromArgb(150, 80, 210);
        public static readonly Color ColorSafe = Color.FromArgb(40, 190, 90);
        public static readonly Color ColorEvacuation = Color.FromArgb(0, 220, 120);

        // 실내 장면(밀폐 인원·대피)에서 숨기는 그룹 — X-Ray 반투명 선체와 구역의 반투명 면은 안쪽 아바타를 가리므로,
        // X-Ray 를 끄고 바깥 껍데기를 걷어 내며 구역은 경계선만 남깁니다.
        // 이름은 샘플 모델의 파일 노드(모델 루트 바로 아래) 이름입니다.
        public static readonly string[] CutawayGroups = { "Shell", "Casing", "Deckhouse", "Upper Decks", "Main Deck" };

        // 구역 면 불투명도 (0~100, 0 이면 경계선만)
        public const int ZoneOpacity = 12;
        public const int SuspendedOpacity = 12;

        // 구역이 하나씩 나타나는 간격(초)
        public const double ZoneStepSeconds = 1.2;

        // ------------------------------------------------------------
        // 판정 기준 (근거 수준)
        // ------------------------------------------------------------
        // 화기 작업 반경 안 가연물 → 화재감시자 배치. KR 11 m [2차 산안기준규칙 제241조의2] · OSHA 35 ft = 10.7 m, 수평·수직 [1차 1915.504(b)(3)]
        public const float HotWorkRadius = 11000f;
        // 3D 라벨은 한 줄·폭 제한이라 짧게 쓰고, 근거 조문은 왼쪽 위 안내 문구(여러 줄 가능)에 적습니다.
        public const string HotWorkRadiusLabel = "화기 반경 11 m";
        public const string HotWorkRadiusSource = "산안기준규칙 제241조의2 [2차] · OSHA 1915.504 35 ft [1차]";

        // 작업 종료 후 화재 감시 — OSHA 30분 [1차 1915.504] · NFPA 51B 60분 [2차]
        public const string FireWatchLabel = "화재감시자";
        public const string FireWatchText = "화재감시자 배치 · 작업 종료 후 30분 감시 [1차 OSHA 1915.504]\n바닥 아래 가연물 → 방화포 (산안기준규칙 제241조의2)";

        // 인접 구획 도장 중 화기 금지 [1차 OSHA 조선 eTool] · 인접 공간 10 % LEL 이상이면 Not Safe for Hot Work [1차 1915.14(c)]
        public const string AdjacentRuleText = "인접 구획 도장 중 → 화기 금지 [1차 OSHA 1915.14]";

        // 이중저 탱크 도장 허가에 적힌 인원과 가스 측정값 — 가스값은 센서가 없어 시뮬레이션 값입니다.
        public const int PermitHeadcount = 2;
        public const string GasReadingLabel = "O₂ 20.9 % · LEL 6 %";
        public const string GasReadingText = "가스 측정(시뮬레이션 값): O₂ 20.9 % · LEL 6 % · CO 0 ppm · H₂S 0 ppm\n기준 O₂ 18~23.5 % · LEL 10 % 미만 [2차 산안기준규칙 제618조]";

        // 탱크 안 작업자 위치(mm, 늑판 사이 칸 가운데, 기울어진 선저 외판 위) — 셋째는 허가 명단에 없는 출입자. 넷째는 위 기관실 플로어라 구역 밖.
        // 구역 안인지는 발이 아니라 몸 가운데(발 + WorkerBodyHeight)로 판정합니다 — 발은 경계인 바닥 판에 닿아 있습니다.
        public static readonly Data.Vector3D[] KeelWorkers =
        {
            new Data.Vector3D(20087f, 2730f, 690f),
            new Data.Vector3D(21688f, 2730f, 525f),
            new Data.Vector3D(23288f, 2730f, 360f),
            new Data.Vector3D(22000f, 4800f, 5520f),
        };
        public const float WorkerBodyHeight = 900f;

        // 탱크 안을 내려다보는 시선 — 늑판(가로 벽) 사이로 보이게 거의 위에서
        public static readonly Data.Vector3D ViewTank = new Data.Vector3D(0.5f, 0.15f, -0.85f);
        // 탱크를 길이 방향에서 — 쐐기 단면이 보이는 방향
        public static readonly Data.Vector3D ViewTankSection = new Data.Vector3D(-1f, 0.25f, -0.2f);
        // 탱크와 그 위 플로어 화기 구역을 함께 — 높이 차가 보이도록 조금 눕혀서
        public static readonly Data.Vector3D ViewTankAbove = new Data.Vector3D(0.5f, 0.3f, -0.7f);

        // 낙하물 통제 반경 = max(2 m, 낙하 높이 / 5) [2차 업계 지침 — 법정 기준 아님]. 낙하 높이는 연돌 상부 바닥 → 상갑판.
        public const float DropMinRadius = 2000f;
        public const float DropRatio = 5f;
        public const float DropFloor = 19700f;
        public const string DropRuleText = "반경 = max(2 m, 낙하 높이/5) [2차 업계 지침, 법정 아님]";

        // ------------------------------------------------------------
        // 대피 (장면 06) — IMO MSC.1/Circ.1533 [1차] 값. 여객선 기준을 조선소 작업자에 준용한 것이라 화면에 밝힙니다.
        // ------------------------------------------------------------
        public const int EvacueesOnFloor = 70;
        public const int EvacueesOnPlatform = 50;

        // 사람이 모여 있는 자리(무리). 무리 가운데에서 길목 입구까지는 충돌 보행(Avatar.TraceWalkAsync)으로 실제 걷는 경로를 한 번 구해 모두가 따릅니다.
        // 기관실 플로어는 배관·장비 사이라 대부분 첫걸음에 막히고, 막힌 구간은 직선으로 대체해 화면에 그 수를 밝힙니다.
        public static readonly Data.Vector3D[] FloorGroups =
        {
            new Data.Vector3D(14000f, -6000f, 5520f), new Data.Vector3D(14000f, 4000f, 5520f), new Data.Vector3D(17000f, 0f, 5520f),
            new Data.Vector3D(20000f, -7000f, 5520f), new Data.Vector3D(26000f, -6000f, 5520f), new Data.Vector3D(28000f, 2000f, 5520f),
        };
        public static readonly Data.Vector3D[] PlatformGroups =
        {
            new Data.Vector3D(15000f, 0f, 8930f), new Data.Vector3D(16000f, -5000f, 8930f), new Data.Vector3D(11000f, 5000f, 8930f), new Data.Vector3D(12000f, -2000f, 8930f),
        };
        // 무리 안에서 흩어지는 반지름(mm)
        public const float GroupSpread = 800f;
        // 충돌 보행 한 걸음(mm)과, 끝 자리가 목표에서 이 거리 안이면 닿은 것으로 봅니다(mm)
        public const double TraceStep = 300.0;
        public const float TraceReach = 600f;

        // 평지 보행 속도(m/s) — 승무원 남성 범위 [1차]
        public const double WalkSpeedMin = 1.11, WalkSpeedMax = 1.85;
        // 계단 상승 속도(m/s, 경사 길이 기준) — 승무원 남성 범위 [1차]
        public const double StairUpSpeedMin = 0.50, StairUpSpeedMax = 0.84;
        // 수직 사다리 상승 속도(m/s) — Circ.1533 에 없음 [예시값]
        public const double LadderUpSpeed = 0.3;
        // 경보 후 응답 시간(s) — 주간 0~300 s 범위 [2차], 분포 모양(균등)은 [예시값]
        public const double ResponseMaxSeconds = 300.0;
        // 통과량 상한 — 폭 1 m 당 1.33 명/s [1차]
        public const double FlowPerMeter = 1.33;

        // 시뮬레이션 배속과 갱신 주기
        public const double TimeScale = 15.0;
        public const int EvacuationTickMs = 200;

        // 대피 그래프 — 모델의 계단·사다리(BOM 계통 Stair/Ladder 경계 상자) 자리. 경사 사다리·계단은 상자의 긴 방향으로 기울여 오릅니다
        // (아래·위 끝 중 어느 쪽이 낮은지는 형상에 디딤판이 없어 알 수 없으므로 플랫폼 쪽을 위로 가정합니다).
        public static readonly Data.Vector3D NodeFloorPortLadder = new Data.Vector3D(20400f, -5150f, 5520f);    // 경사 사다리 AS-O01-0070 아래 (X 20,269~23,620)
        public static readonly Data.Vector3D NodePlatformPortLadder = new Data.Vector3D(23500f, -5150f, 8930f); // 같은 사다리 위
        public static readonly Data.Vector3D NodeFloorStbdLadder = new Data.Vector3D(24400f, 3600f, 5520f);     // 경사 사다리 AS-O01-0285 아래 (X 22,555~24,539)
        public static readonly Data.Vector3D NodePlatformStbdLadder = new Data.Vector3D(20400f, 3600f, 8930f);  // 이어지는 AS-O01-0286 위 (X 20,285~21,843)
        // 계단 탑 — 플랫폼(8,930)에서 상갑판(19,700)까지 4단으로 되꺾어 오릅니다. 모델의 계단(AS-O01-0015, X 17,540~18,888)은 프레임뿐
        // 디딤판이 없어, 그 자리에 디딤판·계단참을 형상(MeshShape)으로 그려 밟을 곳을 만듭니다.
        // 단마다 약 2.7 m 를 3.9 m 에 걸쳐 올라 경사 약 35°. 제2갑판(14,500)에서 한 번 맞춥니다. 화재 구역(+2 m)에 닿지 않게 X 20,000 안쪽에 둡니다.
        public const float StairX0 = 15000f, StairX1 = 18900f;        // 계단참 사이 디딤판 구간(X)
        public const float StairLaneA = 5300f, StairLaneB = 6500f;    // 올라가는 줄 / 되꺾어 오는 줄의 가운데(Y)
        public const float StairLaneWidth = 1000f;                    // 한 줄의 폭(mm)
        public const float LandingDepth = 1100f;                      // 계단참 깊이(mm)
        public static readonly float[] StairLevels = { 8930f, 11715f, 14500f, 17100f, 19700f };
        public const int StairSteps = 15;                             // 한 단의 디딤판 수 (단 높이 약 180 mm)
        public const int LadderSteps = 18;                            // 좌현 경사 사다리의 디딤판 수
        public const float LadderLaneWidth = 800f;
        // 상갑판 통로 판의 폭(mm) — 계단 출구에서 집결지까지. 실내 장면에서는 상갑판을 숨기므로 걷는 자리를 대신 그립니다.
        public const float WalkwayWidth = 1800f;
        public static readonly Color ColorStair = Color.FromArgb(176, 182, 192);
        public static readonly Color ColorWalkway = Color.FromArgb(150, 170, 160);
        public const string StairCategory = "Scenario.WorkPermit.Stair";
        public static readonly Data.Vector3D NodeMuster = new Data.Vector3D(2000f, 0f, 19700f);                 // 선미 계류 갑판 집결지
        public const float LadderWidth = 0.6f, StairWidth = 1.0f;

        // 화재가 난 뒤 이 거리 안의 대피 길목은 막힌 것으로 봅니다 [예시값]
        public const float FireBlockMargin = 2000f;

        // 집결지 자리 간격과 판정 구역 반지름(mm)
        public const float MusterSpacing = 700f;
        public const float MusterRadius = 5000f;

        // 3D 표시를 한 번에 지우기 위한 묶음 이름 — 구역 라벨 / 위험 표시 / 비상 / 상태 / 혼잡
        public const string GroupLabel = "Scenario.WorkPermit.Label";
        public const string GroupHazard = "Scenario.WorkPermit.Hazard";
        public const string GroupFire = "Scenario.WorkPermit.Fire";
        public const string GroupStatus = "Scenario.WorkPermit.Status";
        public const string GroupCrowd = "Scenario.WorkPermit.Crowd";
        public static readonly string[] Groups = { GroupLabel, GroupHazard, GroupFire, GroupStatus, GroupCrowd };
    }
}
