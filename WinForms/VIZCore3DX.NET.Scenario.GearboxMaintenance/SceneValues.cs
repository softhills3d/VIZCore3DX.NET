using System.Drawing;

namespace VIZCore3DX.NET.Scenario.GearboxMaintenance
{
    // 장면에 쓰는 값(부품 이름·속성 키·이동 거리·시간·색·카메라 방향)을 한 곳에 모읍니다.
    // 이 이름·속성은 SDK 샘플 모델 부품\Gearbox.vizx 기준입니다. 실제 데이터에서는 이 표를 그 모델의 부품 이름·속성에 맞게 갈아 끼웁니다.
    // 이야기 : 돌고 있던 감속기를 멈춰 → 커버를 열고 → 출력축을 뺄 방향을 찾아 빼고 → 다시 넣는 경로를 검사하고 → 치수를 확인한 뒤 → 다시 돌립니다.
    internal static class SceneValues
    {
        // ------------------------------------------------------------
        // 부품 이름 (모델 트리 이름과 정확히 일치 — 샘플 모델은 모든 노드 이름이 유일합니다)
        // ------------------------------------------------------------
        public const string NameReducer = "GR2-10 Gear Reducer";
        public const string NameFlangeBolts = "Flange Bolts";
        public static readonly string[] NameLidParts = { "Upper Cover", "Inspection Cover", "Lifting Eye 1", "Lifting Eye 2" };
        public const string NameOutputShaftAssy = "Output Shaft Assembly";
        public const string NameHousing = "Housing";

        // 축 조립품 3개 (입력 → 중간 → 출력) — 기어와 함께 돌립니다. 축 방향은 모델 Y, 축끼리는 X 로 떨어져 있습니다.
        public static readonly string[] NameShaftAssemblies = { "Input Shaft Assembly", "Intermediate Shaft Assembly", "Output Shaft Assembly" };

        // 축 조립품 가운데 실제로 도는 부품의 종류(속성 Type) — 베어링 캡·볼트·외륜은 하우징에 고정돼 돌지 않습니다.
        public static readonly string[] SpinTypes = { "Shaft", "Gear", "Key" };

        // 축 3개 — 축간 거리를 잴 때 중심을 읽습니다.
        public static readonly string[] NameShafts = { "Input Shaft", "Intermediate Shaft", "Output Shaft" };

        // 이 사이 틈을 잴 기어 (상대 피니언은 속성 Mate 에서 읽음)
        public const string NameMeshGear = "Gear Z61";

        // ------------------------------------------------------------
        // 속성(UDA) 키 — 샘플 모델의 General / Design 분류
        // ------------------------------------------------------------
        public const string UdaCategory = "General";
        public const string UdaType = "Type";
        public const string TypeBolt = "Bolt";
        public const string TypeNut = "Nut";
        public const string TypeWasher = "Washer";
        public const string TypeGear = "Gear";
        public const string UdaTeeth = "Teeth";
        public const string UdaMate = "Mate";
        public const string UdaTorque = "Torque(Nm)";
        public const string UdaCenterDistance = "CenterDistance(mm)";
        public const string UdaInputSpeed = "InputSpeed(rpm)";
        public const string UdaOutputSpeed = "OutputSpeed(rpm)";

        // ------------------------------------------------------------
        // 기어 돌리기 (애니메이션) — 축마다 속도는 잇수 비로 정해집니다(입력이 가장 빠르고 출력이 가장 느림).
        // ------------------------------------------------------------
        // 입력축 화면 회전 속도(초당 바퀴). 너무 빠르면 화면에서 이가 거꾸로 도는 것처럼 보입니다.
        public const double SpinInputTurnsPerSecond = 0.6;
        // 서서히 멈추기·돌기 시작하는 시간과 그 구간을 나누는 조각 수
        public const double SpinRampSeconds = 1.5;
        public const int SpinRampSteps = 6;

        // 01 운전 — 기어열이 돌기 시작해 서서히 멈출 때까지(초). 카메라도 이 시간 동안 모델을 돕니다.
        public const double RunningSeconds = 9.0;
        // 08 재가동 — 기어열을 다시 돌리는 시간(초)과, 물러나며 모델을 도는 시간(초)
        public const double RestartSpinSeconds = 14.0;
        public const double OutroOrbitSeconds = 7.5;

        // ------------------------------------------------------------
        // 볼트 풀기 (애니메이션, 초 · mm) — 볼트 조마다 너트가 돌며 내려가고, 이어서 볼트가 돌며 올라간 뒤 숨깁니다.
        // ------------------------------------------------------------
        public const double UnscrewStagger = 0.15;
        public const double NutSeconds = 0.8;
        public const float NutDrop = 40f;
        public const double BoltSeconds = 1.0;
        public const float BoltRise = 80f;
        public const float UnscrewTurns = 3f;
        public const double HideAfter = 0.1;

        // 커버(점검 덮개·아이볼트 포함) 들어 올린 뒤 옆으로 치우기 — 옆으로 치워야 출력축 위가 비어 +Z 가 통과로 나옵니다(실측).
        public const double LidLiftSeconds = 1.5;
        public const float LidLift = 250f;
        public const double LidAsideSeconds = 1.2;
        // 카메라 반대쪽(+Y, 뒤)으로 치워 화면을 가리지 않게 합니다.
        public static readonly Data.Vector3D LidAsideDirection = new Data.Vector3D(0f, 1f, 0f);
        public const float LidAside = 700f;

        // 04 에서 이어 붙이는 출력축 인출
        public const double ShaftPullSeconds = 3.0;
        // 베어링 캡 볼트가 돌며 바깥쪽(축 방향)으로 빠지는 거리 — 시간·회전수는 플랜지 볼트와 같습니다.
        public const float CapBoltBackOut = 40f;
        // 캡 볼트를 다 뺀 뒤 축을 들기 시작할 때까지
        public const double CapRemovedHold = 0.6;
        public const float ShaftPull = 300f;

        // ------------------------------------------------------------
        // 방향 스윕 — 기본 표본 수로는 약 30초, 표본 2만 개로 줄이면 2초에 같은 판정(실측)
        // ------------------------------------------------------------
        public const double SweepMaxDistance = 600;
        public const int SweepMaxSamples = 20000;

        // 맞닿음으로 볼 거리 — 기본 5 mm 면 베어링이 끼워진 하우징이 장애물에서 빠져 ±X 가 거짓 통과(실측), 0.1 mm 면 +Z 만 통과
        public const double SweepContactTolerance = 0.1;

        // 스윕 표시 — 볼륨을 옅게 (기본은 화면을 덮음)
        public const double SweepVolumeOpacity = 0.22;
        public static readonly Color SweepFreeColor = Color.FromArgb(40, 200, 120);
        public static readonly Color SweepBlockedColor = Color.FromArgb(230, 70, 60);

        // 검사 결과를 보이며 모델을 도는 시간(초)
        public const double SweepOrbitSeconds = 7.0;

        // ------------------------------------------------------------
        // 탑재 경로 이동 간섭 검사 — 인출한 높이(ShaftPull)에서 이 간격들로 내려 안착시킵니다(합 = ShaftPull).
        // 캡 볼트를 끼운 채면 안착 25 mm 앞에서 볼트 4개가 하우징을 관통하고, 볼트를 숨기면(숨긴 부품은 검사에서 빠짐) 간섭 0 (실측).
        // ★예제 창에서는 단계마다 약 0.6초 걸립니다(25 mm 씩 13단계 = 8초, 5단계 = 약 5초) — 멀리서는 크게, 안착 근처만 잘게 나눕니다.
        // ------------------------------------------------------------
        public static readonly float[] MountPath = { 150f, 100f, 25f, 25f };
        public const double MountHoldSeconds = 4.0;
        public static readonly Color ColorClash = Color.FromArgb(235, 40, 40);
        // 관통한 볼트를 가까이 볼 때 카메라 거리 (mm)
        public const float ClashViewDistance = 700f;

        // ------------------------------------------------------------
        // 전개도 (애니메이션, 초 · mm) — 세 단계: 볼트·너트·커버 → 축 들어 올리기 → 축 방향 펼치기
        // ------------------------------------------------------------
        public const double ExplodePhaseSeconds = 1.8;
        public const float ExplodeBoltUp = 950f;
        public const float ExplodeNutDown = 220f;
        public const float ExplodeWasherGap = 60f;
        public const float ExplodeCoverUp = 650f;
        public const float ExplodeLidPartsUp = 150f;
        public const float ExplodeDowelUp = 330f;
        public const float ExplodeShaftUp = 330f;
        public const float ExplodeBearingOut = 170f;
        public const float ExplodeCapOut = 300f;
        public const float ExplodeCapBoltOut = 430f;
        public const string TypeBearing = "Bearing";
        public static readonly string[] NameDowelPins = { "Dowel Pin 1", "Dowel Pin 2" };
        public const float ExplodeZoom = 0.7f;
        public const float ExplodeOrbitDegrees = 60f;
        public const double ExplodeOrbitSeconds = 11.0;

        // ------------------------------------------------------------
        // 3D 화면
        // ------------------------------------------------------------
        // 장면이 시작해 문구를 띄운 뒤 동작(재생·검사)을 시작할 때까지 — 무엇을 할지 읽을 시간
        public const double ReadPause = 1.5;

        // 3D 뷰 왼쪽 위 문구 (화면 좌표)
        public static readonly Data.Vector2 HudPosition = new Data.Vector2(40f, 40f);
        public static readonly Color HudColor = Color.FromArgb(255, 214, 0);
        public const Data.TextSizeType HudTextSize = Data.TextSizeType.Size_40;

        // 측정·노트 표시 — 어두운 상자 · 흰 글씨 · 주황 선
        public static readonly Color ColorPanel = Color.FromArgb(230, 22, 30, 44);
        public static readonly Color ColorAccent = Color.FromArgb(255, 160, 0);
        public static readonly Color ColorText = Color.White;
        public const Data.TextSizeType LabelTextSize = Data.TextSizeType.Size_24;
        public const Data.TextSizeType KeyLabelTextSize = Data.TextSizeType.Size_40;
        public const float LineThickness = 3f;
        public const float ArrowHeadSize = 14f;

        // 카메라가 대상을 바라보는 방향 (시선). 정확히 수직(0,0,±1)은 쓰지 않습니다.
        public static readonly Data.Vector3D ViewIntro = new Data.Vector3D(-0.55f, 0.7f, -0.45f);
        public static readonly Data.Vector3D ViewWork = new Data.Vector3D(-0.6f, 0.75f, -0.55f);
        public static readonly Data.Vector3D ViewBolts = new Data.Vector3D(-0.9f, 0.45f, -0.45f);
        public static readonly Data.Vector3D ViewSweep = new Data.Vector3D(-0.55f, 0.8f, -0.3f);
        public static readonly Data.Vector3D ViewMount = new Data.Vector3D(-0.75f, 0.6f, -0.3f);
        public static readonly Data.Vector3D ViewSection = new Data.Vector3D(-0.35f, 0.6f, -1f);
        public static readonly Data.Vector3D ViewMesh = new Data.Vector3D(-0.15f, 0.75f, -0.65f);

        // 화면 맞춤 거리 배율 (1 = 꽉 채움 + FitMargin)
        public const float IntroZoom = 0.9f;
        public const float BoltsZoom = 0.9f;
        public const float LidZoom = 0.8f;
        public const float SweepZoom = 0.85f;
        public const float PullZoom = 1.0f;
        public const float MountZoom = 1.15f;
        public const float SectionZoom = 0.75f;
        public const float MeshZoom = 0.9f;
        public const float OutroZoom = 1.0f;

        // 대상을 화면에 맞출 때 둘레에 두는 여유 (1 = 꽉 채움)
        public const float FitMargin = 1.3f;

        // 맞물림부를 가까이 볼 때 카메라 거리 (mm)
        public const float MeshViewDistance = 650f;

        // 조립 검증에서 축간 거리를 보여 준 뒤 맞물림부로 넘어가는 시각(초)
        public const double VerifyMeshAt = 6.5;

        // 장면에서 모델을 도는 각도(도)
        public const float IntroOrbitDegrees = 35f;
        public const float SweepOrbitDegrees = 25f;
        public const float OutroOrbitDegrees = 50f;

        // 축간 거리 치수 글자 높이 (축 위로 mm)
        public const float DimensionLift = 60f;
    }
}
