using System.Drawing;

namespace VIZCore3DX.NET.Scenario.ConstructionReview
{
    // 대본 표입니다. 장면의 설명·길이와 장면에 쓰는 값(노드 이름·속성 키·색·카메라·문구)을 이 파일 한 곳에 모읍니다.
    // 이 이름과 속성 키는 SDK 샘플 모델 건축\Building_RevA.vizx · Building_RevB.vizx 의 값입니다. 실제 데이터에서는 이 표를 그 모델의 이름·속성에 맞게 갈아 끼웁니다.
    internal static class ScenarioScript
    {
        // ------------------------------------------------------------
        // 장면 (이름 · 설명 · 길이 초) — 재생 순서. 길이는 [전체 재생]에서 다음 장면으로 넘어가기까지의 시간입니다.
        // ------------------------------------------------------------
        public static readonly ScenarioShot Intro = new ScenarioShot("01 철골 10층",
            "기초만 남기고 건물 자리를 내려다보기", 9);

        // 4D 순서(약 30초)가 끝날 때까지 기다립니다.
        public static readonly ScenarioShot Sequence = new ScenarioShot("02 4D 시공 순서",
            "공정표 착수일대로 작업 패키지가 나타남", 34);

        public static readonly ScenarioShot Discipline = new ScenarioShot("03 공종별 보기",
            "공종 속성으로 색을 나누고 설비만 남기기", 9);

        public static readonly ScenarioShot SectionSweep = new ScenarioShot("04 층 단면",
            "옥상에서 아래층으로 수평 단면을 내림", 8);

        public static readonly ScenarioShot Walk = new ScenarioShot("05 실내 1인칭",
            "작업자 아바타를 따라 걷다 1인칭으로", 11);

        public static readonly ScenarioShot Progress = new ScenarioShot("06 기준일 공정 현황",
            "완료·진행·미착수를 색과 X-Ray 로", 13);

        public static readonly ScenarioShot Clash = new ScenarioShot("07 전체 간섭 검사",
            "전체 부품의 간섭을 검사", 12);

        public static readonly ScenarioShot ClashSummary = new ScenarioShot("08 공종 쌍별 집계",
            "간섭 부재만 남기고 공종 쌍별·층별 건수", 12);

        public static readonly ScenarioShot Penetration1 = new ScenarioShot("09 간섭 1",
            "두 부재만 X-Ray 로 남기고 교차선과 함께", 4);

        public static readonly ScenarioShot Penetration2 = new ScenarioShot("10 간섭 2",
            "두 부재만 X-Ray 로 남기고 교차선과 함께", 4);

        public static readonly ScenarioShot Penetration3 = new ScenarioShot("11 간섭 3",
            "두 부재만 X-Ray 로 남기고 교차선과 함께", 4);

        public static readonly ScenarioShot Sleeve = new ScenarioShot("12 관통부 확대",
            "상자 단면으로 잘라 보는 슬리브 자리", 10);

        // Rev B 를 여는 시간과 재검사 시간만큼 더 걸립니다.
        public static readonly ScenarioShot RevB = new ScenarioShot("13 설계 변경 Rev B",
            "Rev A 와 비교하고 Rev B 만으로 재검사", 20);

        public static readonly ScenarioShot Outro = new ScenarioShot("14 마무리",
            "결과 표시를 걷고 건물 전체로", 11);

        // 리본 장면 버튼의 문구 (재생 순서). 한 줄 80px 를 넘으면 띄어쓰기에서 두 줄로 나뉩니다.
        // 같은 문구가 이어지면 버튼 하나로 묶여, 누르면 그 장면들을 이어서 재생합니다.
        public static readonly string[] SceneLabels = { "철골", "4D 순서", "공종별", "층 단면", "아바타", "공정 현황", "간섭 검사", "쌍별 집계", "간섭 확인", "간섭 확인", "간섭 확인", "관통부", "Rev B", "마무리" };

        // ------------------------------------------------------------
        // 모델 트리 이름 (정확히 일치)
        // ------------------------------------------------------------
        public const string NameBuilding = "Steel Office 10F";
        public const string NameFoundation = "F00 Foundation";

        // ------------------------------------------------------------
        // 속성(UDA) 키 — 샘플 모델의 General / Schedule 분류
        // ------------------------------------------------------------
        public const string UdaCategory = "General";
        public const string UdaType = "Type";
        public const string TypeWorkPackage = "Work Package";
        public const string UdaLevel = "Level";
        public const string UdaActivity = "Activity";
        public const string UdaInstallSeq = "InstallSeq";
        public const string UdaPlannedStart = "PlannedStart";
        public const string UdaSection = "Section";
        public const string UdaSystem = "System";
        public const string UdaMaterial = "Material";
        public const string UdaStatus = "Status";

        // 공종별 보기 — (속성 값, 화면 이름, 색, 숨기는 단계: 0 = 처음부터(외장이 안쪽을 덮음) · 1 = 설비만 볼 때 · 2 = 숨기지 않음)
        public const string UdaDiscipline = "Discipline";
        public static readonly System.Tuple<string, string, Color, int>[] Disciplines =
        {
            System.Tuple.Create("Structure", "구조", Color.FromArgb(200, 125, 75), 1),
            System.Tuple.Create("Architecture", "건축", Color.FromArgb(190, 190, 195), 0),
            System.Tuple.Create("Mechanical", "기계", Color.FromArgb(60, 140, 230), 2),
            System.Tuple.Create("Fire Protection", "소방", Color.FromArgb(225, 55, 55), 2),
            System.Tuple.Create("Electrical", "전기", Color.FromArgb(245, 200, 40), 2),
        };
        public const float MepZoom = 0.6f;
        public const double DisciplineIsolateAt = 4.0;

        // 층 단면 — 옥상 위에서 이 층 바닥 + SweepCutAbove 까지 SweepSeconds 동안 내립니다.
        // 바닥 위 1.2 m(평면도 높이)는 빈 바닥과 기둥뿐이라, 위층 보 아래 천장 속(3.3 m)을 잘라 층마다 배관·덕트가 보이게 합니다.
        public const string UdaElevation = "Elevation(mm)";
        public static readonly string[] Levels = { "L01", "L02", "L03", "L04", "L05", "L06", "L07", "L08", "L09", "L10", "RF Roof" };
        public const string SweepStopLevel = "L05";
        public const float SweepCutAbove = 3300f;
        public const float SweepZoom = 1.15f;
        public const double SweepSeconds = 4.0;

        // 실내 1인칭 — 이 층 바닥에 작업자 아바타를 세워 +X 로 걷게 하고, 뒤에서 따라가다 1인칭으로 넘어갑니다.
        public const string AvatarPresetName = "Worker (M)";
        public const string WalkLevel = "L05";
        public const float WalkStartRatioX = 0.2f;
        public const float WalkStartRatioY = 0.35f;
        public const float WalkDistance = 9000f;
        public const double WalkHeading = -90.0;
        public const double WalkSeconds = 8.0;
        public const double WalkFirstPersonAt = 4.0;

        // 기준일 공정 현황 — 상태는 Schedule 분류, 기준일은 건물 노드의 DataDate
        public const string UdaScheduleCategory = "Schedule";
        public const string UdaDataDate = "DataDate";
        public const string StatusCompleted = "Completed";
        public const string StatusInProgress = "In Progress";
        public const string StatusNotStarted = "Not Started";
        public static readonly Color ColorDone = Color.FromArgb(90, 175, 120);
        public static readonly Color ColorDoing = Color.FromArgb(255, 150, 30);
        public const double ProgressFocusAt = 4.5;
        public const float ProgressZoom = 0.75f;

        // 설계 변경 — 연 모델과 같은 폴더의 Rev B 파일을 더해 비교합니다. Rev A 에만 있는 부재 · Rev B 에만 있는 부재 · 같은 부재(거의 투명)
        public const string RevBFileName = "Building_RevB.vizx";
        public static readonly Color ColorRevA = Color.FromArgb(220, 230, 60, 60);
        public static readonly Color ColorRevB = Color.FromArgb(220, 40, 140, 255);
        public static readonly Color ColorRevSame = Color.FromArgb(12, 255, 255, 255);
        public const double RevBCompareHold = 12.0;
        // 건물 전체에서 비교 결과를 보인 뒤 위쪽 층(바뀐 설비가 몰린 곳)으로 다가가는 시각(초) · 그때 화면 맞춤 배율 · 도는 각도
        public const double RevBUpperAt = 4.5;
        public const float RevBUpperZoom = 0.8f;
        public const float RevBOrbitDegrees = 35f;
        // 비교 화면에 띄우는 변경 내용
        public const string RevBChangeNote = "상층 덕트·트레이 경로 변경 · 옥상 장비 이동 · 큰보 단면 · 유리 교체";
        // 재검사 뒤 남은 간섭을 보일 때 건물 맞춤 배율
        public const float RevBRemainZoom = 1.3f;

        // 기초 층은 첫 장면부터 보이므로 4D 에서 뺍니다.
        public const string LevelFoundation = "F00";

        // 위에서 꽂히듯 내려오는 작업 (기둥) — Activity 가 이 말로 끝나는 작업 패키지
        public const string DropInActivitySuffix = " Columns";
        public const float DropHeight = 3000f;
        public const double DropSeconds = 0.4;

        // 첫 순간에 위로 올려 두는 시간 — 너무 짧으면(10 ms) 적용되지 않습니다(0.2 초는 적용).
        public const double LiftSeconds = 0.2;

        // 공정표 첫 착수일 ~ 마지막 착수일을 이 시간(초)에 펼칩니다. 같은 날 시작하는 작업은 함께 나타납니다.
        public const double SequenceSeconds = 29.0;
        public const double SequenceLead = 0.3;

        // 가까이 볼 간섭 — (먼저 부를 부재의 속성 Type, 상대 부재의 Type). 유형마다 가장 낮은 층의 한 곳을 고릅니다.
        // 마지막 곳(배관 ↔ 작은보 웹)은 다음 장면에서 상자 단면으로 잘라 봅니다.
        public static readonly string[][] FocusTypes =
        {
            new[] { "Branch Duct", "Girder" },
            new[] { "Cable Tray", "Pipe" },
            new[] { "Pipe", "Beam" },
        };

        // 간섭 집계 · 노트에 쓰는 이름 — 공종(Discipline) · 부재 종류(Type) · 배관 계통(System, Type 이 Pipe 일 때)
        public static readonly System.Collections.Generic.Dictionary<string, string> DisciplineNames = new System.Collections.Generic.Dictionary<string, string>
        {
            { "Structure", "구조" }, { "Architecture", "건축" }, { "Mechanical", "기계" },
            { "Fire Protection", "소방" }, { "Electrical", "전기" }, { "Plumbing", "위생" },
        };
        public static readonly System.Collections.Generic.Dictionary<string, string> TypeNames = new System.Collections.Generic.Dictionary<string, string>
        {
            { "Girder", "큰보" }, { "Beam", "작은보" }, { "Column", "기둥" }, { "Duct", "덕트" }, { "Branch Duct", "분기 덕트" },
            { "Cable Tray", "케이블 트레이" }, { "Drop Pipe", "스프링클러 하향관" }, { "Pipe", "배관" },
        };
        public static readonly System.Collections.Generic.Dictionary<string, string> PipeNames = new System.Collections.Generic.Dictionary<string, string>
        {
            { "DRAIN", "배수관" }, { "CD", "응축수 배관" }, { "HYDRANT", "소화전 배관" }, { "CHWS", "냉수 공급관" }, { "CHWR", "냉수 환수관" },
        };
        public const string TypePipe = "Pipe";

        // 공종 쌍별 집계 장면 — 층별 건수 문구로 바꾸는 시각(초) · 건물 맞춤 배율 · 도는 각도
        public const double SummaryLevelsAt = 5.0;
        public const float SummaryZoom = 1.3f;
        public const float SummaryOrbitDegrees = 40f;

        // 교차선 굵기
        public const float IntersectionLineThickness = 3f;

        // 관통부 단면 상자 여유(mm)
        public const float SleeveBoxMargin = 600f;

        // ------------------------------------------------------------
        // 3D 화면
        // ------------------------------------------------------------
        // 문구를 띄운 뒤 동작(열기·검사)을 시작할 때까지 — 무엇을 할지 읽을 시간
        public const double ReadPause = 1.5;

        // 3D 뷰 왼쪽 위 문구 — 어두운 상자 위 글자(화면 고정 노트). 상자 폭은 글자 폭을 재서 정합니다(Size_40 ≈ 33px 높이).
        public const string HudFontName = "Malgun Gothic";
        public const float HudFontPixels = 38f;
        public const float HudPaddingPixels = 40f;
        public const float HudMarginPixels = 14f;
        public const float HudBoxHeightPixels = 58f;
        public static readonly Color HudColor = Color.FromArgb(255, 214, 0);
        public const Data.TextSizeType HudTextSize = Data.TextSizeType.Size_40;

        // 노트 표시 — 어두운 상자 · 흰 글씨 · 주황 선
        public static readonly Color ColorPanel = Color.FromArgb(230, 22, 30, 44);
        public static readonly Color ColorAccent = Color.FromArgb(255, 160, 0);
        public static readonly Color ColorText = Color.White;
        public const Data.TextSizeType LabelTextSize = Data.TextSizeType.Size_24;
        public const float LineThickness = 3f;
        public const float ArrowHeadSize = 14f;

        // 카메라가 대상을 바라보는 방향 (시선). 정확히 수직(0,0,±1)은 쓰지 않습니다.
        public static readonly Data.Vector3D ViewAerial = new Data.Vector3D(-0.6f, 0.7f, -0.55f);
        public static readonly Data.Vector3D ViewSide = new Data.Vector3D(-0.55f, 0.8f, -0.12f);
        public static readonly Data.Vector3D ViewPlan = new Data.Vector3D(-0.35f, 0.45f, -0.85f);
        public static readonly Data.Vector3D ViewSleeve = new Data.Vector3D(-0.5f, 0.6f, -0.35f);
        public static readonly Data.Vector3D ViewPenetration = new Data.Vector3D(-0.55f, 0.7f, -0.45f);

        // 간섭부를 볼 때 카메라 거리 (mm) — FocusTypes 순서. 덕트는 폭이 넓어 더 물러납니다.
        public static readonly float[] FocusViewDistances = { 7500f, 3800f, 3800f };

        // 관통부 노트를 교차선 위로 띄우는 높이 (mm)
        public const float NoteLift = 250f;

        // 대상을 화면에 맞출 때 둘레에 두는 여유 (1 = 꽉 채움)
        public const float FitMargin = 1.2f;

        // 화면 맞춤 거리 배율 — 기초만 보일 때 · 건물 전체
        // 건물은 위에서 내려다보면 높이와 깊이가 함께 화면 세로를 차지해, 가장 긴 변으로만 맞추면 위아래가 잘립니다 — 넉넉히.
        public const float IntroZoom = 0.9f;
        public const float BuildingZoom = 1.55f;

        // 관통부를 가까이 볼 때 카메라 거리 (mm)
        public const float SleeveViewDistance = 2500f;

        // 장면마다 건물을 도는 각도(도)와 시간(초)
        public const float IntroOrbitDegrees = 25f;
        public const double IntroOrbitSeconds = 5.0;
        public const float SequenceOrbitDegrees = 120f;
        public const double SequenceOrbitSeconds = 28.5;
        public const float ClashOrbitDegrees = 10f;
        public const double ClashOrbitSeconds = 8.5;
        public const float DisciplineOrbitDegrees = 30f;
        public const float ProgressOrbitDegrees = 20f;
        public const double ProgressOrbitSeconds = 4.0;
        public const double SummaryOrbitSeconds = 7.5;
        public const float SleeveOrbitDegrees = 35f;
        public const double SleeveOrbitSeconds = 5.5;
        public const float OutroOrbitDegrees = 60f;
        public const double OutroOrbitSeconds = 6.5;

        // 관통 장면마다 시선을 이만큼(도) 수직축으로 돌려 같은 구도가 반복되지 않게 합니다.
        public static readonly float[] PenetrationAngles = { 0f, 40f, -40f };
    }
}
