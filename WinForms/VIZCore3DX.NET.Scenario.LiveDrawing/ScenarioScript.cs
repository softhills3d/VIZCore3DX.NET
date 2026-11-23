using System.Drawing;

namespace VIZCore3DX.NET.Scenario.LiveDrawing
{
    // 대본 표입니다. 장면의 설명·길이와 장면에 쓰는 값(방향·높이·색·개수)을 이 파일 한 곳에 모읍니다.
    // 위치는 모두 대상 경계 상자에 대한 비율이라 어떤 모델에서도 그대로 동작합니다. 실제 데이터가 있으면 이 값을 갈아 끼웁니다.
    internal static class ScenarioScript
    {
        // ------------------------------------------------------------
        // 장면 (이름 · 설명 · 길이 초) — 재생 순서. 길이는 [전체 재생]에서 다음 장면으로 넘어가기까지의 시간입니다.
        // ------------------------------------------------------------
        public static readonly ScenarioShot Section = new ScenarioShot("01 전체 단면",
            "3D 를 자르고 같은 평면의 도면 만들기", 6);

        public static readonly ScenarioShot LiveMap = new ScenarioShot("02 살아 있는 도면",
            "3D 카메라를 도면 위 표식으로", 13);

        public static readonly ScenarioShot BlockDrawing = new ScenarioShot("03 블록 도면",
            "가려진 선을 지운 도면", 6);

        public static readonly ScenarioShot ClosedAreas = new ScenarioShot("04 닫힌 영역 면적",
            "2D 와 3D 에 함께 칠하기", 8);

        public static readonly ScenarioShot Measure = new ScenarioShot("05 치수",
            "2D 측정과 같은 값의 3D 치수선", 18);

        public static readonly ScenarioShot PointTour = new ScenarioShot("06 도면 점 → 3D",
            "도면 위 경로로 카메라 이동", 13);

        public static readonly ScenarioShot ZoomDetail = new ScenarioShot("07 확대",
            "도면의 한 부분을 자세히", 4);

        public static readonly ScenarioShot Export = new ScenarioShot("08 내보내기",
            "DXF · SVG", 4);

        // 리본 장면 버튼의 문구 (재생 순서). 한 줄 80px 를 넘으면 띄어쓰기에서 두 줄로 나뉩니다.
        public static readonly string[] SceneLabels = { "전체 단면", "카메라 표식", "블록 도면", "면적", "치수", "도면->3D", "확대", "내보내기" };

        // ------------------------------------------------------------
        // 도면 생성
        // ------------------------------------------------------------
        // 자르고 투영하는 평면의 법선. 아래(-Z)로 주면 도면이 위에서 내려다본 그림이 됩니다(위(+Z)면 아래에서 올려다본 그림).
        public static readonly Data.Vector3D PlaneNormal = new Data.Vector3D(0f, 0f, -1f);

        // 전체 단면을 자르는 높이 (0 = 모델 바닥, 1 = 꼭대기)
        public const float SectionHeight = 0.25f;

        // 3D 단면 — Z 축 단면은 그대로 두면 평면 위쪽이 남으므로, 위에서 내려다보는 도면에 맞추려면 뒤집어 아래쪽을 남깁니다.
        public const Data.Axis SectionAxis = Data.Axis.Z;
        public static readonly bool SectionInvert = true;

        // 블록 도면 평면을 블록 꼭대기에서 띄우는 높이(블록 높이에 대한 비율).
        // 평행 투영이라 도면은 평면 높이와 상관없이 같고, 3D 에서는 도면이 블록 위에 떠 보입니다.
        public const float DrawingLift = 0.35f;

        public static readonly Color DrawingColor = Color.Black;
        public static readonly Color DrawingAccent = Color.FromArgb(0, 96, 200);
        public const float DrawingThickness = 1.0f;

        // ------------------------------------------------------------
        // 카메라
        // ------------------------------------------------------------
        // 대상을 화면에 맞출 때 둘레에 두는 여유 (1 = 꽉 채움)
        public const float FitMargin = 1.25f;

        // 도면과 같은 방향으로 맞출 때 화면 위쪽에 남기는 여백(대상 긴 변에 대한 비율)
        public const float TopRoom = 0.15f;

        // 3D 카메라 ↔ 도면 표식 장면 — 카메라가 차례로 바라볼 지점(모델 범위 안의 비율)과 시선, 거리(모델 긴 변에 대한 비율)
        public static readonly PointF[] LiveMapTargets =
        {
            new PointF(0.80f, 0.50f), new PointF(0.55f, 0.35f), new PointF(0.35f, 0.65f), new PointF(0.15f, 0.50f),
        };
        public static readonly Data.Vector3D[] LiveMapViews =
        {
            new Data.Vector3D(-0.8f, 0.4f, -0.45f), new Data.Vector3D(-0.2f, 0.9f, -0.4f),
            new Data.Vector3D(0.7f, 0.6f, -0.4f), new Data.Vector3D(0.8f, -0.4f, -0.45f),
        };
        public const float LiveMapDistance = 0.25f;
        public const double LiveMapSecondsPerView = 2.9;

        // 카메라가 모델 밖에서 바라보므로, 카메라 표식이 도면 밖으로 나가지 않게 도면 둘레에 두는 여백(카메라 거리에 대한 비율)
        public const float LiveMapMargin = 1.1f;

        // 블록을 비스듬히 볼 때의 시선
        public static readonly Data.Vector3D ViewBlock = new Data.Vector3D(-0.6f, 0.55f, -0.58f);

        // 치수 장면 — 도면이 블록 위에 떠 있는 모습을 보여 주는 시선·거리·화면 왼쪽으로 옮기는 정도, 기울인 채 머무는 시간(초)
        public static readonly Data.Vector3D ViewFloating = new Data.Vector3D(-0.65f, 0.5f, -0.55f);
        public const float FloatingZoom = 1.2f;
        public const float FloatingShift = 0.12f;
        public const double FloatingHoldSeconds = 4.0;
        public const double FloatingReturnSeconds = 10.0;

        // ------------------------------------------------------------
        // 도면 위 표시
        // ------------------------------------------------------------
        public static readonly Color CameraMarkerColor = Color.FromArgb(220, 40, 40);
        public static readonly Color TargetPointColor = Color.FromArgb(255, 150, 0);
        public const float MarkerSizePx = 22f;

        // 닫힌 영역 면적 — 이보다 좁은 영역은 찾지 않음(도면 단위의 제곱, mm 모델이면 200000 = 0.2 m²), 색칠할 개수·간격(초)·색
        public const float AreaMinimum = 200000f;
        public const int AreaCount = 10;
        public const double AreaStepSeconds = 0.6;
        public static readonly Color[] AreaColors =
        {
            Color.FromArgb(120, 66, 133, 244), Color.FromArgb(120, 52, 168, 83), Color.FromArgb(120, 251, 188, 5),
            Color.FromArgb(120, 234, 67, 53), Color.FromArgb(120, 154, 80, 200), Color.FromArgb(120, 0, 172, 193),
        };

        // 3D 에 영역 색 면을 도면 평면보다 내려 까는 높이(모델 단위) — 도면 선·치수선이 색 면 위에 보이게 합니다.
        public const float AreaLift = 50f;

        // 면적(도면 단위의 제곱)을 m² 로 바꾸는 값. 모델 단위가 mm 이면 0.000001 입니다.
        public const double AreaToSquareMeter = 0.000001;

        // 치수 — 넓은 순서로 몇 개의 영역을 잴지, 측정 하나가 나타나는 간격(초),
        // 거리 글자를 놓을 선 위의 자리(0 = 시작점, 1 = 끝점, 측정마다 돌아가며 써서 글자끼리 겹치지 않게 함)
        public const int MeasureShapeCount = 4;
        public const double MeasureStepSeconds = 1.2;
        public static readonly float[] MeasureLabelPositions = { 0.25f, 0.5f, 0.75f, 0.35f, 0.65f };

        // 도면 점 → 3D — 블록 도면 범위 안의 비율로 고른 경로, 점마다 걸리는 시간(초), 다가가는 거리(블록이 다 보이는 거리에 대한 비율)
        public static readonly PointF[] TourPoints =
        {
            new PointF(0.20f, 0.25f), new PointF(0.50f, 0.70f), new PointF(0.80f, 0.35f),
        };
        public static readonly string[] TourLabels = { "A", "B", "C" };
        public const double TourSecondsPerPoint = 3.3;
        public const float TourZoom = 0.5f;
        public static readonly Color TourColor = Color.FromArgb(0, 150, 90);

        // 확대 — 마지막 경로 점 주변으로 보여 줄 범위(도면 범위에 대한 비율)
        public const float ZoomWindow = 0.18f;

        // 3D 표시(이펙트)를 한 번에 지우기 위한 묶음 이름
        public const string EffectGroup = "Scenario.LiveDrawing";
    }
}
