using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Settings
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 화면에서 편집 중인 설정 사본
        private VIZCore3DX.NET.Data.SettingItems _items;

        // 대체 폰트 기본 목록
        private static readonly string[] DefaultFallbackFontFamilies = { "Arial", "맑은 고딕", "Microsoft YaHei", "Meiryo" };

        // 글자 크기 콤보 항목 (TextSizeType.Size_N = N)
        private static readonly int[] TextSizes = { 10, 12, 14, 18, 24, 40, 52, 80, 104 };

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================

            // 라이선스 파일을 통한 인증
            //VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("127.0.0.1", 8901);

            // ================================================================
            // License
            // ================================================================

            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeVIZCore3DX();
        }

        private void InitializeVIZCore3DX()
        {
            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();

            InitializeCombos();
            ReadFromViewer();
        }

        #region 1. 모델
        // 설정 변경을 확인할 모델 파일을 엽니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            SetStatus("모델을 열었습니다.");
        }
        #endregion

        #region Combo Items
        // 모든 콤보 항목을 채웁니다.
        private void InitializeCombos()
        {
            string[] textSizes = { "10", "12", "14", "18", "24", "40", "52", "80", "104" };
            string[] strokePatterns = { "실선", "점선(Dashed)", "점선(Dotted)" };
            string[] alignments = { "왼쪽", "가운데", "오른쪽" };
            string[] frameLabels = { "표시안함", "프레임 좌표", "전역 좌표", "사용자 정의" };
            string[] capColorModes = { "사용자 지정 색상", "모델 색상" };
            string[] panelPositions = { "왼쪽", "오른쪽" };

            // 기본
            FillCombo(cbCameraMode, "자유 궤도", "위 고정 궤도", "구 궤도", "구형 궤도");
            FillCombo(cbProjection, "원근", "평행");
            FillCombo(comboXRaySelectionColor, "기본 선택 색상", "객체 색상");
            FillCombo(cbSelectionObject3DType, "전체", "불투명한 개체", "투명한 개체");
            FillCombo(cbBackgroundColorCount, "단색", "두가지 색", "세가지 색");
            FillCombo(cbBackgroundMode, "단색", "선형 그라데이션", "방사형 그라데이션");
            FillCombo(cbSelectionBoxStrokePattern, strokePatterns);
            FillCombo(cbSelectionBoxTextSize, textSizes);

            // 보기
            List<string> fonts = new List<string>();
            fonts.Add("사용 안 함");
            foreach (System.Drawing.FontFamily family in System.Drawing.FontFamily.Families)
                fonts.Add(family.Name);
            FillCombo(cbFallbackFontFamilies, fonts.ToArray());
            FillCombo(cbViewCubeFontSize, textSizes);
            FillCombo(cbZoomBoxStrokePattern, strokePatterns);

            // 노트
            FillCombo(cbNoteFontSize, textSizes);
            FillCombo(cbNoteTextHorizontalAlignment, alignments);
            FillCombo(cbNoteLineStrokePattern, strokePatterns);
            FillCombo(cbNoteSymbolTextSize, textSizes);

            // 측정
            FillCombo(cbMeasureDistanceUnit, "Millimeter", "Centimeter", "Meter", "Kilometer", "Inch", "Feet", "Yard", "Mile");
            FillCombo(cbMeasureUnit, "SquareMillimeter", "SquareCentimeter", "SquareMeter", "SquareKilometer", "SquareInch", "SquareFeet", "SquareYard", "SquareMile");
            FillCombo(cbMeasureDecimalPoint, "0", "1", "2", "3", "4");
            FillCombo(cbMeasureFontSize, textSizes);
            FillCombo(cbMeasureTextHorizontalAlignment, alignments);
            FillCombo(cbMeasureLineStrokePattern, strokePatterns);

            // 단면
            FillCombo(cbSectionBoundaryStrokePattern, strokePatterns);
            FillCombo(cbSectionManipulatorDisplayMode, "선택 단면", "활성 단면", "모든 단면");
            FillCombo(cbCapFillColorMode, capColorModes);
            FillCombo(cbCapStrokeColorMode, capColorModes);

            // 프레임
            FillCombo(comboBoxFrameXLabel, frameLabels);
            FillCombo(comboBoxFrameYLabel, frameLabels);
            FillCombo(comboBoxFrameZLabel, frameLabels);
            FillCombo(cbFramePlaneStrokePattern, strokePatterns);
            FillCombo(cbGridLineStrokePattern, strokePatterns);

            // 사전 선택
            FillCombo(cbPreSelectNodeNameTarget, "사전선택 노드", "파트 상위", "어셈블리 상위");

            // 툴바
            FillCombo(cbRibbonTheme, "밝게", "회색", "어둡게");

            // 창
            FillCombo(cbModelTreePanelPosition, panelPositions);
            FillCombo(cbAttributePanelPosition, panelPositions);
        }

        private void FillCombo(ComboBox cb, params string[] items)
        {
            cb.Items.Clear();
            cb.Items.AddRange(items);
            if (cb.Items.Count > 0) cb.SelectedIndex = 0;
        }
        #endregion

        #region Read / Write
        // 뷰어의 현재 설정을 읽어 화면에 표시합니다.
        private void ReadFromViewer()
        {
            _items = vizcore3dx.Setting.GetItems();
            if (_items == null)
            {
                SetStatus("설정을 읽지 못했습니다.");
                return;
            }

            WriteToControls(_items);
        }

        // 설정 사본의 값을 화면 컨트롤에 씁니다.
        private void WriteToControls(VIZCore3DX.NET.Data.SettingItems items)
        {
            WriteHome(items);
            WriteView(items);
            WriteInput(items);
            WriteNote(items);
            WriteMeasure(items);
            WriteSection(items);
            WriteDecal(items);
            WriteFrame(items);
            WriteObserver(items);
            WritePreSelect(items);
            WriteToolbar(items);
            WriteWindow(items);
            WriteDevTools(items);
        }

        // 화면 컨트롤의 값을 설정 사본에 읽어 넣습니다.
        private void ReadFromControls(VIZCore3DX.NET.Data.SettingItems items)
        {
            ReadHome(items);
            ReadView(items);
            ReadInput(items);
            ReadNote(items);
            ReadMeasure(items);
            ReadSection(items);
            ReadDecal(items);
            ReadFrame(items);
            ReadObserver(items);
            ReadPreSelect(items);
            ReadToolbar(items);
            ReadWindow(items);
            ReadDevTools(items);
        }
        #endregion

        #region 기본
        private void WriteHome(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 모델
            ckEnableBody.Checked = items.EnableBody;
            ckEnableFace.Checked = items.EnableFace;
            ckEnableNodeLock.Checked = items.EnableNodeLock;

            // 보기
            cbCameraMode.SelectedIndex = ClampIndex(items.CameraMode, cbCameraMode);
            ckEnableEdge.Checked = items.EnableEdge;
            ckEnableShadow.Checked = items.EnableShadow;
            ckEnableSsao.Checked = items.EnableSsao;
            cbProjection.SelectedIndex = ClampIndex(items.Projection, cbProjection);
            btnEdgeColor.BackColor = items.EdgeColor;

            // 카메라
            ckInitialCamera.Checked = items.EnableInitialCamera;
            SetNumeric(numCameraBoundingBoxMinX, items.InitialCameraBoundBoxMinX);
            SetNumeric(numCameraBoundingBoxMinY, items.InitialCameraBoundBoxMinY);
            SetNumeric(numCameraBoundingBoxMinZ, items.InitialCameraBoundBoxMinZ);
            SetNumeric(numCameraBoundingBoxMaxX, items.InitialCameraBoundBoxMaxX);
            SetNumeric(numCameraBoundingBoxMaxY, items.InitialCameraBoundBoxMaxY);
            SetNumeric(numCameraBoundingBoxMaxZ, items.InitialCameraBoundBoxMaxZ);
            SetNumeric(numCameraInitialFov, items.FOV);

            // 선택
            btnSelectionColor.BackColor = items.SelectionColor;
            btnSelectionBoxFillColor.BackColor = items.SelectionBoxFillColor;
            btnSelectionBoxStrokeColor.BackColor = items.SelectionBoxStrokeColor;
            ckSelectionOutline.Checked = items.EnableSelectionOutline;
            btnSelectionOutlineColor.BackColor = items.SelectionOutlineColor;
            comboXRaySelectionColor.SelectedIndex = ClampIndex(items.OverrideColorModeSelectionColor, comboXRaySelectionColor);
            cbSelectionObject3DType.SelectedIndex = ClampIndex(items.SelectionObject3DType, cbSelectionObject3DType);
            ckBoxSelectionFrontObjectOnly.Checked = items.EnableBoxSelectionFrontObjectOnly;

            // 배경 (유형 먼저, 색 개수 다음)
            cbBackgroundMode.SelectedIndex = ClampIndex((int)items.BackgroundMode, cbBackgroundMode);
            cbBackgroundMode_SelectedIndexChanged(cbBackgroundMode, EventArgs.Empty);
            cbBackgroundColorCount.SelectedIndex = ClampIndex((int)items.BackgroundColorCount, cbBackgroundColorCount);
            cbBackgroundColorCount_SelectedIndexChanged(cbBackgroundColorCount, EventArgs.Empty);
            btnBackgroundColor1.BackColor = items.BackgroundColor1;
            btnBackgroundColor2.BackColor = items.BackgroundColor2;
            btnBackgroundColor3.BackColor = items.BackgroundColor3;
            txtGradientPosition1.Text = items.GradientPosition1.ToString(System.Globalization.CultureInfo.InvariantCulture);
            txtGradientPosition2.Text = items.GradientPosition2.ToString(System.Globalization.CultureInfo.InvariantCulture);
            txtGradientPosition3.Text = items.GradientPosition3.ToString(System.Globalization.CultureInfo.InvariantCulture);
            txtGradientVectorX.Text = items.GradientVectorX.ToString(System.Globalization.CultureInfo.InvariantCulture);
            txtGradientVectorY.Text = items.GradientVectorY.ToString(System.Globalization.CultureInfo.InvariantCulture);

            // 스냅
            SetNumeric(numSnapPlaneSize, items.SnapPlaneSize);
            SetNumeric(numSnapPointSize, items.SnapPointSize);
            SetNumeric(numSnapCylinderAxisSize, items.SnapCylinderAxisSize);
            btnSnapColor.BackColor = items.SnapColor;
            btnSnapHighlightColor.BackColor = items.SnapHighlightColor;

            // 선택 상자
            btnSelectionBoxDefaultFillColor.BackColor = items.SelectionBoxDefaultFillColor;
            btnSelectionBoxDefaultStrokeColor.BackColor = items.SelectionBoxDefaultStrokeColor;
            btnSelectionBoxHighlightedFillColor.BackColor = items.SelectionBoxHighlightedFillColor;
            btnSelectionBoxHighlightedStrokeColor.BackColor = items.SelectionBoxHighlightedStrokeColor;
            btnSelectionBoxSelectedFillColor.BackColor = items.SelectionBoxSelectedFillColor;
            btnSelectionBoxSelectedStrokeColor.BackColor = items.SelectionBoxSelectedStrokeColor;
            cbSelectionBoxStrokePattern.SelectedIndex = ClampIndex((int)items.SelectionBoxStrokePattern, cbSelectionBoxStrokePattern);
            SetNumeric(numSelectionBoxStrokeThickness, items.SelectionBoxStrokeThickness);
            cbSelectionBoxTextSize.SelectedIndex = ToTextSizeIndex(items.SelectionBoxTextSize);
            btnSelectionBoxTextColor.BackColor = items.SelectionBoxTextColor;

            // 다면체 공간
            btnZoneFaceColor.BackColor = items.ZoneFaceColor;
            btnZoneLineColor.BackColor = items.ZoneLineColor;
            SetNumeric(numZoneFaceOpacity, items.ZoneFaceOpacity);
        }

        private void ReadHome(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 모델
            items.EnableBody = ckEnableBody.Checked;
            items.EnableFace = ckEnableFace.Checked;
            items.EnableNodeLock = ckEnableNodeLock.Checked;

            // 보기
            items.CameraMode = cbCameraMode.SelectedIndex;
            items.EnableEdge = ckEnableEdge.Checked;
            items.EnableShadow = ckEnableShadow.Checked;
            items.EnableSsao = ckEnableSsao.Checked;
            items.Projection = cbProjection.SelectedIndex;
            items.EdgeColor = btnEdgeColor.BackColor;

            // 카메라
            items.EnableInitialCamera = ckInitialCamera.Checked;
            items.InitialCameraBoundBoxMinX = (float)numCameraBoundingBoxMinX.Value;
            items.InitialCameraBoundBoxMinY = (float)numCameraBoundingBoxMinY.Value;
            items.InitialCameraBoundBoxMinZ = (float)numCameraBoundingBoxMinZ.Value;
            items.InitialCameraBoundBoxMaxX = (float)numCameraBoundingBoxMaxX.Value;
            items.InitialCameraBoundBoxMaxY = (float)numCameraBoundingBoxMaxY.Value;
            items.InitialCameraBoundBoxMaxZ = (float)numCameraBoundingBoxMaxZ.Value;
            items.FOV = (float)numCameraInitialFov.Value;

            // 선택
            items.SelectionColor = btnSelectionColor.BackColor;
            items.SelectionBoxFillColor = btnSelectionBoxFillColor.BackColor;
            items.SelectionBoxStrokeColor = btnSelectionBoxStrokeColor.BackColor;
            items.EnableSelectionOutline = ckSelectionOutline.Checked;
            items.SelectionOutlineColor = btnSelectionOutlineColor.BackColor;
            items.OverrideColorModeSelectionColor = comboXRaySelectionColor.SelectedIndex;
            items.SelectionObject3DType = cbSelectionObject3DType.SelectedIndex;
            items.EnableBoxSelectionFrontObjectOnly = ckBoxSelectionFrontObjectOnly.Checked;

            // 배경
            items.BackgroundMode = (VIZCore3DX.NET.Data.BackgroundModes)cbBackgroundMode.SelectedIndex;
            items.BackgroundColorCount = (VIZCore3DX.NET.Data.BackgroundColorCount)cbBackgroundColorCount.SelectedIndex;
            items.BackgroundColor1 = btnBackgroundColor1.BackColor;
            items.BackgroundColor2 = btnBackgroundColor2.BackColor;
            items.BackgroundColor3 = btnBackgroundColor3.BackColor;
            items.GradientPosition1 = ParseFloat(txtGradientPosition1, items.GradientPosition1);
            items.GradientPosition2 = ParseFloat(txtGradientPosition2, items.GradientPosition2);
            items.GradientPosition3 = ParseFloat(txtGradientPosition3, items.GradientPosition3);
            items.GradientVectorX = ParseFloat(txtGradientVectorX, items.GradientVectorX);
            items.GradientVectorY = ParseFloat(txtGradientVectorY, items.GradientVectorY);

            // 스냅
            items.SnapPlaneSize = (float)numSnapPlaneSize.Value;
            items.SnapPointSize = (float)numSnapPointSize.Value;
            items.SnapCylinderAxisSize = (float)numSnapCylinderAxisSize.Value;
            items.SnapColor = btnSnapColor.BackColor;
            items.SnapHighlightColor = btnSnapHighlightColor.BackColor;

            // 선택 상자
            items.SelectionBoxDefaultFillColor = btnSelectionBoxDefaultFillColor.BackColor;
            items.SelectionBoxDefaultStrokeColor = btnSelectionBoxDefaultStrokeColor.BackColor;
            items.SelectionBoxHighlightedFillColor = btnSelectionBoxHighlightedFillColor.BackColor;
            items.SelectionBoxHighlightedStrokeColor = btnSelectionBoxHighlightedStrokeColor.BackColor;
            items.SelectionBoxSelectedFillColor = btnSelectionBoxSelectedFillColor.BackColor;
            items.SelectionBoxSelectedStrokeColor = btnSelectionBoxSelectedStrokeColor.BackColor;
            items.SelectionBoxStrokePattern = (VIZCore3DX.NET.Data.StrokePattern)cbSelectionBoxStrokePattern.SelectedIndex;
            items.SelectionBoxStrokeThickness = (float)numSelectionBoxStrokeThickness.Value;
            items.SelectionBoxTextSize = ToTextSize(cbSelectionBoxTextSize);
            items.SelectionBoxTextColor = btnSelectionBoxTextColor.BackColor;

            // 다면체 공간
            items.ZoneFaceColor = btnZoneFaceColor.BackColor;
            items.ZoneLineColor = btnZoneLineColor.BackColor;
            items.ZoneFaceOpacity = (int)numZoneFaceOpacity.Value;
        }

        // Body 조회를 끄면 Face 조회도 함께 꺼지는 연동을 보여줍니다.
        private void ckEnableBody_CheckedChanged(object sender, EventArgs e)
        {
            if (ckEnableBody.Checked == false) ckEnableFace.Checked = false;
        }

        // Face 조회를 켜면 Body 조회도 함께 켜지는 연동을 보여줍니다.
        private void ckEnableFace_CheckedChanged(object sender, EventArgs e)
        {
            if (ckEnableFace.Checked == true) ckEnableBody.Checked = true;
        }

        // 배경 유형에 따라 색 개수 항목과 그라데이션 벡터 입력을 바꿉니다.
        private void cbBackgroundMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.BackgroundModes mode = (VIZCore3DX.NET.Data.BackgroundModes)cbBackgroundMode.SelectedIndex;

            cbBackgroundColorCount.Items.Clear();
            if (mode == VIZCore3DX.NET.Data.BackgroundModes.COLOR_ONE)
            {
                cbBackgroundColorCount.Items.Add("단색");
                cbBackgroundColorCount.SelectedIndex = 0;
            }
            else
            {
                cbBackgroundColorCount.Items.AddRange(new string[] { "단색", "두가지 색", "세가지 색" });
                cbBackgroundColorCount.SelectedIndex = 1;
            }

            bool linear = mode == VIZCore3DX.NET.Data.BackgroundModes.LINEAR_GRADIENT;
            txtGradientVectorX.Enabled = linear;
            txtGradientVectorY.Enabled = linear;
        }

        // 배경 색 개수에 따라 사용하는 색·위치 입력만 활성화합니다.
        private void cbBackgroundColorCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = cbBackgroundColorCount.SelectedIndex;

            btnBackgroundColor2.Enabled = count >= 1;
            txtGradientPosition2.Enabled = count >= 1;
            btnBackgroundColor3.Enabled = count >= 2;
            txtGradientPosition3.Enabled = count >= 2;
        }
        #endregion

        #region 보기
        private void WriteView(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 보기
            ckEnableAnimation.Checked = items.EnableAnimation;
            ckEnableAutoFit.Checked = items.EnableAutoFit;
            ckViewToolbarEnable.Checked = items.ViewToolbarEnable;
            SetNumeric(numRenderScale, items.RenderScale);
            cbFallbackFontFamilies.SelectedIndex = ToFallbackFontIndex(items.FallbackFontFamilies);

            // 확대/축소
            SetNumeric(numZoomRatio, items.ZoomRatio);

            // 뷰큐브
            ckViewCubeEnable.Checked = items.ViewCubeEnable;
            btnViewCubeFillColor.BackColor = items.ViewCubeFillColor;
            btnViewCubeStrokeColor.BackColor = items.ViewCubeStrokeColor;
            btnViewCubeHighlightedFillColor.BackColor = items.ViewCubeHighlightedFillColor;
            btnViewCubeHighlightedStrokeColor.BackColor = items.ViewCubeHighlightedStrokeColor;
            btnViewCubeFontColor.BackColor = items.ViewCubeTextColor;
            cbViewCubeFontSize.SelectedIndex = ToTextSizeIndex(items.ViewCubeTextSize);

            // 뷰큐브 면 문자열
            txtViewCubeTop.Text = items.ViewCubeTopFaceString ?? string.Empty;
            txtViewCubeBottom.Text = items.ViewCubeBottomFaceString ?? string.Empty;
            txtViewCubeLeft.Text = items.ViewCubeLeftFaceString ?? string.Empty;
            txtViewCubeRight.Text = items.ViewCubeRightFaceString ?? string.Empty;
            txtViewCubeFront.Text = items.ViewCubeFrontFaceString ?? string.Empty;
            txtViewCubeBack.Text = items.ViewCubeBackFaceString ?? string.Empty;

            // 명령
            btnCommandMessageTextColor.BackColor = items.CommandMessageTextColor;

            // 환경조명
            ckEnvironmentLight.Checked = items.EnableEnvironmentMap;
            ckEnvironmentLight_CheckedChanged(ckEnvironmentLight, EventArgs.Empty);
            txtLightDirX.Text = items.LightDirectionX.ToString("F3", System.Globalization.CultureInfo.InvariantCulture);
            txtLightDirY.Text = items.LightDirectionY.ToString("F3", System.Globalization.CultureInfo.InvariantCulture);
            txtLightDirZ.Text = items.LightDirectionZ.ToString("F3", System.Globalization.CultureInfo.InvariantCulture);
            btnAmbientColor.BackColor = items.AmbientColor;
            btnLightColor.BackColor = items.LightColor;
            SetNumeric(numShininess, items.Shininess);
            SetNumeric(numSpecularIntensity, items.SpecularIntensity);

            // 확대 상자
            btnZoomBoxFillColor.BackColor = items.ZoomBoxFillColor;
            btnZoomBoxStrokeColor.BackColor = items.ZoomBoxStrokeColor;
            cbZoomBoxStrokePattern.SelectedIndex = ClampIndex((int)items.ZoomBoxStrokePattern, cbZoomBoxStrokePattern);
            SetNumeric(numZoomBoxStrokeThickness, items.ZoomBoxStrokeThickness);
        }

        private void ReadView(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 보기
            items.EnableAnimation = ckEnableAnimation.Checked;
            items.EnableAutoFit = ckEnableAutoFit.Checked;
            items.ViewToolbarEnable = ckViewToolbarEnable.Checked;
            items.RenderScale = (float)numRenderScale.Value;

            List<string> fallbackFonts = new List<string>(DefaultFallbackFontFamilies);
            if (cbFallbackFontFamilies.SelectedIndex > 0 && fallbackFonts.Contains(cbFallbackFontFamilies.Text) == false)
                fallbackFonts.Add(cbFallbackFontFamilies.Text);
            items.FallbackFontFamilies = fallbackFonts;

            // 확대/축소
            items.ZoomRatio = (float)numZoomRatio.Value;

            // 뷰큐브
            items.ViewCubeEnable = ckViewCubeEnable.Checked;
            items.ViewCubeFillColor = btnViewCubeFillColor.BackColor;
            items.ViewCubeStrokeColor = btnViewCubeStrokeColor.BackColor;
            items.ViewCubeHighlightedFillColor = btnViewCubeHighlightedFillColor.BackColor;
            items.ViewCubeHighlightedStrokeColor = btnViewCubeHighlightedStrokeColor.BackColor;
            items.ViewCubeTextColor = btnViewCubeFontColor.BackColor;
            items.ViewCubeTextSize = ToTextSize(cbViewCubeFontSize);

            // 뷰큐브 면 문자열
            items.ViewCubeTopFaceString = txtViewCubeTop.Text;
            items.ViewCubeBottomFaceString = txtViewCubeBottom.Text;
            items.ViewCubeLeftFaceString = txtViewCubeLeft.Text;
            items.ViewCubeRightFaceString = txtViewCubeRight.Text;
            items.ViewCubeFrontFaceString = txtViewCubeFront.Text;
            items.ViewCubeBackFaceString = txtViewCubeBack.Text;

            // 명령
            items.CommandMessageTextColor = btnCommandMessageTextColor.BackColor;

            // 환경조명
            items.EnableEnvironmentMap = ckEnvironmentLight.Checked;
            items.LightDirectionX = ParseFloat(txtLightDirX, 0f);
            items.LightDirectionY = ParseFloat(txtLightDirY, 0f);
            items.LightDirectionZ = ParseFloat(txtLightDirZ, 0f);
            items.AmbientColor = btnAmbientColor.BackColor;
            items.LightColor = btnLightColor.BackColor;
            items.Shininess = (float)numShininess.Value;
            items.SpecularIntensity = (float)numSpecularIntensity.Value;

            // 확대 상자
            items.ZoomBoxFillColor = btnZoomBoxFillColor.BackColor;
            items.ZoomBoxStrokeColor = btnZoomBoxStrokeColor.BackColor;
            items.ZoomBoxStrokePattern = (VIZCore3DX.NET.Data.StrokePattern)cbZoomBoxStrokePattern.SelectedIndex;
            items.ZoomBoxStrokeThickness = (float)numZoomBoxStrokeThickness.Value;
        }

        // 기본 목록에 없는 첫 대체 폰트의 콤보 위치를 찾습니다.
        private int ToFallbackFontIndex(List<string> fonts)
        {
            if (fonts == null) return 0;

            foreach (string font in fonts)
            {
                if (string.IsNullOrWhiteSpace(font)) continue;
                if (Array.IndexOf(DefaultFallbackFontFamilies, font) >= 0) continue;

                int index = cbFallbackFontFamilies.FindStringExact(font);
                return index > 0 ? index : 0;
            }

            return 0;
        }

        // 환경조명을 끄면 조명 세부 입력을 비활성화합니다.
        private void ckEnvironmentLight_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control control in grpViewLight.Controls)
            {
                if (control == ckEnvironmentLight) continue;
                control.Enabled = ckEnvironmentLight.Checked;
            }
        }
        #endregion

        #region 조작
        private void WriteInput(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 모델링 컨트롤
            ckModelingControl.Checked = items.ModelingControlVisible;
            SelectRadio(items.ModelingControlSize, rbMcSizeSmall, rbMcSizeMedium, rbMcSizeLarge);
            SelectRadio(items.ModelingControlPosition, rbMcPosTL, rbMcPosTC, rbMcPosTR, rbMcPosBL, rbMcPosBC, rbMcPosBR, rbMcPosLS, rbMcPosRS);
            SelectRadio(items.ModelingControlOrientation, rbMcOrientH, rbMcOrientV);
            SelectRadio(items.ModelingControlColor, rbMcColorBlack, rbMcColorGray, rbMcColorWhite);
            SelectRadio(items.ModelingControlBackground, rbMcBgTransparent, rbMcBgSemi, rbMcBgColored);
            SelectRadio(items.ModelingControlBackgroundColor, rbMcBgColorBlack, rbMcBgColorGray, rbMcBgColorWhite);
            ckModelingControl_CheckedChanged(ckModelingControl, EventArgs.Empty);

            // 감도
            SetNumeric(numInputOrbitSens, items.InputOrbitSensitivity);
            SetNumeric(numInputPanSens, items.InputPanSensitivity);
            SetNumeric(numInputZoomSens, items.InputZoomDragSensitivity);
            SetNumeric(numInputRollSens, items.InputRollSensitivity);
            SetNumeric(numInputLookSens, items.InputLookSensitivity);

            // 이동 속도
            SetNumeric(numInputWalkSpeed, items.InputWalkSpeedRatio);
            SetNumeric(numInputWalkBoost, items.InputWalkSpeedBoostScale);
            SetNumeric(numInputFlySpeed, items.InputFlySpeedRatio);
            SetNumeric(numInputFlyBoost, items.InputFlySpeedBoostScale);

            // 클릭 판정·휠
            ckInputWheelInvert.Checked = items.InputWheelDirectionInverted;
            SetNumeric(numInputClickDuration, items.InputClickDurationMs);
            SetNumeric(numInputLongPress, items.InputLongPressDurationMs);
            SetNumeric(numInputClickTolerance, items.InputClickTolerancePixels);
        }

        private void ReadInput(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 모델링 컨트롤 (위치 라디오가 모두 해제된 자유 위치는 기존 값 유지)
            items.ModelingControlVisible = ckModelingControl.Checked;
            items.ModelingControlSize = RadioIndex(1, rbMcSizeSmall, rbMcSizeMedium, rbMcSizeLarge);
            items.ModelingControlPosition = RadioIndex(items.ModelingControlPosition, rbMcPosTL, rbMcPosTC, rbMcPosTR, rbMcPosBL, rbMcPosBC, rbMcPosBR, rbMcPosLS, rbMcPosRS);
            items.ModelingControlOrientation = RadioIndex(0, rbMcOrientH, rbMcOrientV);
            items.ModelingControlColor = RadioIndex(1, rbMcColorBlack, rbMcColorGray, rbMcColorWhite);
            items.ModelingControlBackground = RadioIndex(2, rbMcBgTransparent, rbMcBgSemi, rbMcBgColored);
            items.ModelingControlBackgroundColor = RadioIndex(1, rbMcBgColorBlack, rbMcBgColorGray, rbMcBgColorWhite);

            // 감도
            items.InputOrbitSensitivity = (double)numInputOrbitSens.Value;
            items.InputPanSensitivity = (double)numInputPanSens.Value;
            items.InputZoomDragSensitivity = (double)numInputZoomSens.Value;
            items.InputRollSensitivity = (double)numInputRollSens.Value;
            items.InputLookSensitivity = (double)numInputLookSens.Value;

            // 이동 속도
            items.InputWalkSpeedRatio = (double)numInputWalkSpeed.Value;
            items.InputWalkSpeedBoostScale = (double)numInputWalkBoost.Value;
            items.InputFlySpeedRatio = (double)numInputFlySpeed.Value;
            items.InputFlySpeedBoostScale = (double)numInputFlyBoost.Value;

            // 클릭 판정·휠
            items.InputWheelDirectionInverted = ckInputWheelInvert.Checked;
            items.InputClickDurationMs = (int)numInputClickDuration.Value;
            items.InputLongPressDurationMs = (int)numInputLongPress.Value;
            items.InputClickTolerancePixels = (int)numInputClickTolerance.Value;
        }

        // 모델링 컨트롤을 끄면 세부 옵션 그룹을 비활성화합니다.
        private void ckModelingControl_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = ckModelingControl.Checked;

            grpMcSize.Enabled = enabled;
            grpMcPosition.Enabled = enabled;
            grpMcOrientation.Enabled = enabled;
            grpMcColor.Enabled = enabled;
            grpMcBackground.Enabled = enabled;
            grpMcBackgroundColor.Enabled = enabled && rbMcBgTransparent.Checked == false;
        }

        // 배경이 투명이면 배경 색상 선택을 비활성화합니다.
        private void rbMcBackground_CheckedChanged(object sender, EventArgs e)
        {
            grpMcBackgroundColor.Enabled = ckModelingControl.Checked && rbMcBgTransparent.Checked == false;
        }
        #endregion

        #region 노트
        private void WriteNote(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 스타일
            btnNoteBoxFillColor.BackColor = items.NoteBoxFillColor;
            btnNoteBoxStrokeColor.BackColor = items.NoteBoxStrokeColor;
            btnNoteHighlightedBoxFillColor.BackColor = items.NoteHighlightedBoxFillColor;
            btnNoteHighlightedBoxStrokeColor.BackColor = items.NoteHighlightedBoxStrokeColor;
            btnNoteSelectedBoxStrokeColor.BackColor = items.NoteSelectedBoxStrokeColor;
            btnNoteTextColor.BackColor = items.NoteTextColor;
            cbNoteFontSize.SelectedIndex = ToTextSizeIndex(items.NoteTextSize);
            cbNoteTextHorizontalAlignment.SelectedIndex = ClampIndex(items.NoteTextHorizontalAlignment, cbNoteTextHorizontalAlignment);
            btnNoteLineColor.BackColor = items.NoteLineStrokeColor;
            txtNoteLineWidth.Text = items.NoteLineStrokeThickness.ToString(System.Globalization.CultureInfo.InvariantCulture);
            cbNoteLineStrokePattern.SelectedIndex = ClampIndex(items.NoteLineStrokePattern, cbNoteLineStrokePattern);
            btnNoteArrowColor.BackColor = items.NoteArrowColor;
            txtNoteArrowSize.Text = items.NoteArrowHeadSize.ToString(System.Globalization.CultureInfo.InvariantCulture);

            // 심벌 옵션
            btnNoteSymbolFillColor.BackColor = items.SymbolFillColor;
            btnNoteSymbolStrokeColor.BackColor = items.SymbolStrokeColor;
            txtNoteSymbolSize.Text = items.SymbolSize.ToString(System.Globalization.CultureInfo.InvariantCulture);
            btnNoteSymbolTextColor.BackColor = items.SymbolTextColor;
            cbNoteSymbolTextSize.SelectedIndex = ToTextSizeIndex(items.SymbolTextSize);
        }

        private void ReadNote(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 스타일
            items.NoteBoxFillColor = btnNoteBoxFillColor.BackColor;
            items.NoteBoxStrokeColor = btnNoteBoxStrokeColor.BackColor;
            items.NoteHighlightedBoxFillColor = btnNoteHighlightedBoxFillColor.BackColor;
            items.NoteHighlightedBoxStrokeColor = btnNoteHighlightedBoxStrokeColor.BackColor;
            items.NoteSelectedBoxStrokeColor = btnNoteSelectedBoxStrokeColor.BackColor;
            items.NoteTextColor = btnNoteTextColor.BackColor;
            items.NoteTextSize = ToTextSize(cbNoteFontSize);
            items.NoteTextHorizontalAlignment = cbNoteTextHorizontalAlignment.SelectedIndex;
            items.NoteLineStrokeColor = btnNoteLineColor.BackColor;
            items.NoteLineStrokeThickness = ParseFloat(txtNoteLineWidth, items.NoteLineStrokeThickness);
            items.NoteLineStrokePattern = cbNoteLineStrokePattern.SelectedIndex;
            items.NoteArrowColor = btnNoteArrowColor.BackColor;
            items.NoteArrowHeadSize = ParseFloat(txtNoteArrowSize, items.NoteArrowHeadSize);

            // 심벌 옵션
            items.SymbolFillColor = btnNoteSymbolFillColor.BackColor;
            items.SymbolStrokeColor = btnNoteSymbolStrokeColor.BackColor;
            items.SymbolSize = ParseFloat(txtNoteSymbolSize, items.SymbolSize);
            items.SymbolTextColor = btnNoteSymbolTextColor.BackColor;
            items.SymbolTextSize = ToTextSize(cbNoteSymbolTextSize);
        }
        #endregion

        #region 측정
        private void WriteMeasure(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 옵션
            ckMeasureDxDyDz.Checked = items.IsAxisDistanceEnabled;
            ckMeasureFrame.Checked = items.IsGridCoordinateEnabled;
            ckMeasureType.Checked = items.IsTypeEnabled;
            ckMeasureUnit.Checked = items.IsUnitEnabled;
            ckMeasureXYZAxisDistanceDecomposed.Checked = items.IsXYZAxisDistanceDecomposed;
            cbMeasureDistanceUnit.SelectedIndex = ClampIndex((int)items.LengthUnit, cbMeasureDistanceUnit);
            cbMeasureUnit.SelectedIndex = ClampIndex((int)items.AreaUnit, cbMeasureUnit);
            cbMeasureDecimalPoint.SelectedIndex = ClampIndex(items.DecimalPlace, cbMeasureDecimalPoint);

            // 스타일
            btnMeasureBoxFillColor.BackColor = items.MeasureBoxFillColor;
            btnMeasureBoxStrokeColor.BackColor = items.MeasureBoxStrokeColor;
            btnMeasureHighlightedBoxFillColor.BackColor = items.MeasureHighlightedBoxFillColor;
            btnMeasureHighlightedBoxStrokeColor.BackColor = items.MeasureHighlightedBoxStrokeColor;
            btnMeasureSelectedBoxStrokeColor.BackColor = items.MeasureSelectedBoxStrokeColor;
            btnMeasureTextColor.BackColor = items.MeasureTextColor;
            btnMeasureLineColor.BackColor = items.MeasureLineStrokeColor;
            btnMeasureArrowColor.BackColor = items.MeasureArrowColor;
            cbMeasureFontSize.SelectedIndex = ToTextSizeIndex(items.MeasureTextSize);
            cbMeasureTextHorizontalAlignment.SelectedIndex = ClampIndex(items.MeasureTextHorizontalAlignment, cbMeasureTextHorizontalAlignment);
            cbMeasureLineStrokePattern.SelectedIndex = ClampIndex(items.MeasureLineStrokePattern, cbMeasureLineStrokePattern);
            txtMeasureLineWidth.Text = items.MeasureLineStrokeThickness.ToString(System.Globalization.CultureInfo.InvariantCulture);
            txtMeasureArrowSize.Text = items.MeasureArrowHeadSize.ToString(System.Globalization.CultureInfo.InvariantCulture);

            // 스냅
            SetNumeric(numMeasureSnapPlaneSize, items.MeasureSnapPlaneSize);
            SetNumeric(numMeasureSnapPointSize, items.MeasureSnapPointSize);
            SetNumeric(numMeasureSnapCylinderAxisSize, items.MeasureSnapCylinderAxisSize);
        }

        private void ReadMeasure(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 옵션
            items.IsAxisDistanceEnabled = ckMeasureDxDyDz.Checked;
            items.IsGridCoordinateEnabled = ckMeasureFrame.Checked;
            items.IsTypeEnabled = ckMeasureType.Checked;
            items.IsUnitEnabled = ckMeasureUnit.Checked;
            items.IsXYZAxisDistanceDecomposed = ckMeasureXYZAxisDistanceDecomposed.Checked;
            items.LengthUnit = (VIZCore3DX.NET.Data.LengthUnit)cbMeasureDistanceUnit.SelectedIndex;
            items.AreaUnit = (VIZCore3DX.NET.Data.AreaUnit)cbMeasureUnit.SelectedIndex;
            items.DecimalPlace = cbMeasureDecimalPoint.SelectedIndex;

            // 스타일
            items.MeasureBoxFillColor = btnMeasureBoxFillColor.BackColor;
            items.MeasureBoxStrokeColor = btnMeasureBoxStrokeColor.BackColor;
            items.MeasureHighlightedBoxFillColor = btnMeasureHighlightedBoxFillColor.BackColor;
            items.MeasureHighlightedBoxStrokeColor = btnMeasureHighlightedBoxStrokeColor.BackColor;
            items.MeasureSelectedBoxStrokeColor = btnMeasureSelectedBoxStrokeColor.BackColor;
            items.MeasureTextColor = btnMeasureTextColor.BackColor;
            items.MeasureLineStrokeColor = btnMeasureLineColor.BackColor;
            items.MeasureArrowColor = btnMeasureArrowColor.BackColor;
            items.MeasureTextSize = ToTextSize(cbMeasureFontSize);
            items.MeasureTextHorizontalAlignment = cbMeasureTextHorizontalAlignment.SelectedIndex;
            items.MeasureLineStrokePattern = cbMeasureLineStrokePattern.SelectedIndex;
            items.MeasureLineStrokeThickness = ParseFloat(txtMeasureLineWidth, items.MeasureLineStrokeThickness);
            items.MeasureArrowHeadSize = ParseFloat(txtMeasureArrowSize, items.MeasureArrowHeadSize);

            // 스냅
            items.MeasureSnapPlaneSize = (float)numMeasureSnapPlaneSize.Value;
            items.MeasureSnapPointSize = (float)numMeasureSnapPointSize.Value;
            items.MeasureSnapCylinderAxisSize = (float)numMeasureSnapCylinderAxisSize.Value;
        }
        #endregion

        #region 단면
        private void WriteSection(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 스타일
            btnSectionFaceFillColor.BackColor = items.SectionFaceFillColor;
            btnSectionBoundaryStrokeColor.BackColor = items.SectionBoundaryStrokeColor;
            btnSectionDisabledFaceFillColor.BackColor = items.SectionDisabledFaceFillColor;
            btnSectionDisabledBoundaryStrokeColor.BackColor = items.SectionDisabledBoundaryStrokeColor;
            btnSectionSelectedBoundaryStrokeColor.BackColor = items.SectionSelectedBoundaryStrokeColor;
            btnSectionHighlightedBoundaryStrokeColor.BackColor = items.SectionHighlightedBoundaryStrokeColor;
            txtSectionBoundaryStrokeThickness.Text = items.SectionBoundaryStrokeThickness.ToString(System.Globalization.CultureInfo.InvariantCulture);
            cbSectionBoundaryStrokePattern.SelectedIndex = ClampIndex((int)items.SectionBoundaryStrokePattern, cbSectionBoundaryStrokePattern);
            cbSectionManipulatorDisplayMode.SelectedIndex = ClampIndex((int)items.SectionManipulatorDisplayMode, cbSectionManipulatorDisplayMode);

            // 단면 캡 설정
            cbCapFill.Checked = items.SectionIsCapFillEnabled;
            cbCapStroke.Checked = items.SectionIsCapStrokeEnabled;
            btnCapFillColor.BackColor = items.SectionCapFillColor;
            btnCapStrokeColor.BackColor = items.SectionCapStrokeColor;
            cbCapFillColorMode.SelectedIndex = ClampIndex((int)items.SectionCapFillColorMode, cbCapFillColorMode);
            cbCapStrokeColorMode.SelectedIndex = ClampIndex((int)items.SectionCapStrokeColorMode, cbCapStrokeColorMode);
            txtCapStrokeThickness.Text = items.SectionCapStrokeThickness.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        private void ReadSection(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 스타일
            items.SectionFaceFillColor = btnSectionFaceFillColor.BackColor;
            items.SectionBoundaryStrokeColor = btnSectionBoundaryStrokeColor.BackColor;
            items.SectionDisabledFaceFillColor = btnSectionDisabledFaceFillColor.BackColor;
            items.SectionDisabledBoundaryStrokeColor = btnSectionDisabledBoundaryStrokeColor.BackColor;
            items.SectionSelectedBoundaryStrokeColor = btnSectionSelectedBoundaryStrokeColor.BackColor;
            items.SectionHighlightedBoundaryStrokeColor = btnSectionHighlightedBoundaryStrokeColor.BackColor;
            items.SectionBoundaryStrokeThickness = ParseFloat(txtSectionBoundaryStrokeThickness, items.SectionBoundaryStrokeThickness);
            items.SectionBoundaryStrokePattern = (VIZCore3DX.NET.Data.StrokePattern)cbSectionBoundaryStrokePattern.SelectedIndex;
            items.SectionManipulatorDisplayMode = (VIZCore3DX.NET.Data.SectionManipulatorDisplayMode)cbSectionManipulatorDisplayMode.SelectedIndex;

            // 단면 캡 설정
            items.SectionIsCapFillEnabled = cbCapFill.Checked;
            items.SectionIsCapStrokeEnabled = cbCapStroke.Checked;
            items.SectionCapFillColor = btnCapFillColor.BackColor;
            items.SectionCapStrokeColor = btnCapStrokeColor.BackColor;
            items.SectionCapFillColorMode = (VIZCore3DX.NET.Data.SectionCapColorMode)cbCapFillColorMode.SelectedIndex;
            items.SectionCapStrokeColorMode = (VIZCore3DX.NET.Data.SectionCapColorMode)cbCapStrokeColorMode.SelectedIndex;
            items.SectionCapStrokeThickness = ParseFloat(txtCapStrokeThickness, items.SectionCapStrokeThickness);
        }
        #endregion

        #region 데칼
        private void WriteDecal(VIZCore3DX.NET.Data.SettingItems items)
        {
            btnDecalHighlightedBoxFillColor.BackColor = items.DecalHighlightedBoxFillColor;
            btnDecalHighlightedBoxStrokeColor.BackColor = items.DecalHighlightedBoxStrokeColor;
            btnDecalSelectedBoxStrokeColor.BackColor = items.DecalSelectedBoxStrokeColor;
            SetNumeric(numDecalRotationAngleStep, items.DecalRotationAngleStep);
        }

        private void ReadDecal(VIZCore3DX.NET.Data.SettingItems items)
        {
            items.DecalHighlightedBoxFillColor = btnDecalHighlightedBoxFillColor.BackColor;
            items.DecalHighlightedBoxStrokeColor = btnDecalHighlightedBoxStrokeColor.BackColor;
            items.DecalSelectedBoxStrokeColor = btnDecalSelectedBoxStrokeColor.BackColor;
            items.DecalRotationAngleStep = (float)numDecalRotationAngleStep.Value;
        }
        #endregion

        #region 프레임
        private void WriteFrame(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 조회
            ckFrameXYPlane.Checked = items.FrameIsXYPlaneEnabled;
            ckFrameYZPlane.Checked = items.FrameIsYZPlaneEnabled;
            ckFrameZXPlane.Checked = items.FrameIsZXPlaneEnabled;
            ckFrameXLine.Checked = items.FrameIsXFrameLineEnabled;
            ckFrameYLine.Checked = items.FrameIsYFrameLineEnabled;
            ckFrameZLine.Checked = items.FrameIsZFrameLineEnabled;
            comboBoxFrameXLabel.SelectedIndex = ClampIndex(items.FrameXFrameLineLabelType, comboBoxFrameXLabel);
            comboBoxFrameYLabel.SelectedIndex = ClampIndex(items.FrameYFrameLineLabelType, comboBoxFrameYLabel);
            comboBoxFrameZLabel.SelectedIndex = ClampIndex(items.FrameZFrameLineLabelType, comboBoxFrameZLabel);

            // 색상
            btnFramePlaneColor.BackColor = items.FramePlaneStrokeColor;
            btnFrameLineColor.BackColor = items.FrameLineStrokeColor;
            btnFrameLabelColor.BackColor = items.FrameLineLabelTextColor;
            SetNumeric(numFramePlaneThickness, items.FramePlaneStrokeThickness);
            SetNumeric(numFrameLineThickness, items.FrameLineStrokeThickness);
            cbFramePlaneStrokePattern.SelectedIndex = ClampIndex(items.FramePlaneStrokePattern, cbFramePlaneStrokePattern);
            cbGridLineStrokePattern.SelectedIndex = ClampIndex(items.FrameLineStrokePattern, cbGridLineStrokePattern);
        }

        private void ReadFrame(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 조회
            items.FrameIsXYPlaneEnabled = ckFrameXYPlane.Checked;
            items.FrameIsYZPlaneEnabled = ckFrameYZPlane.Checked;
            items.FrameIsZXPlaneEnabled = ckFrameZXPlane.Checked;
            items.FrameIsXFrameLineEnabled = ckFrameXLine.Checked;
            items.FrameIsYFrameLineEnabled = ckFrameYLine.Checked;
            items.FrameIsZFrameLineEnabled = ckFrameZLine.Checked;
            items.FrameXFrameLineLabelType = comboBoxFrameXLabel.SelectedIndex;
            items.FrameYFrameLineLabelType = comboBoxFrameYLabel.SelectedIndex;
            items.FrameZFrameLineLabelType = comboBoxFrameZLabel.SelectedIndex;

            // 색상
            items.FramePlaneStrokeColor = btnFramePlaneColor.BackColor;
            items.FrameLineStrokeColor = btnFrameLineColor.BackColor;
            items.FrameLineLabelTextColor = btnFrameLabelColor.BackColor;
            items.FramePlaneStrokeThickness = (float)numFramePlaneThickness.Value;
            items.FrameLineStrokeThickness = (float)numFrameLineThickness.Value;
            items.FramePlaneStrokePattern = cbFramePlaneStrokePattern.SelectedIndex;
            items.FrameLineStrokePattern = cbGridLineStrokePattern.SelectedIndex;
        }
        #endregion

        #region 옵저버
        private void WriteObserver(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 표식
            ckObserverShowFigure.Checked = items.ObserverShowFigure;
            SetNumeric(numObserverFigureSize, items.ObserverFigureSizeMm);
            btnObserverFigureColor.BackColor = items.ObserverFigureColor;
            btnObserverRingColor.BackColor = items.ObserverRingColor;
            btnObserverNoseColor.BackColor = items.ObserverNoseColor;

            // 분석 결과 색
            btnObserverVisibleColor.BackColor = items.ObserverVisibleColor;
            btnObserverHiddenColor.BackColor = items.ObserverHiddenColor;

            // 시야 기본값
            SetNumeric(numObserverAngularStep, items.ObserverAngularStepDeg);
            SetNumeric(numObserverMaxDistance, items.ObserverMaxDistanceMm);
            SetNumeric(numObserverEyeHeight, items.ObserverEyeHeightMm);
        }

        private void ReadObserver(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 표식
            items.ObserverShowFigure = ckObserverShowFigure.Checked;
            items.ObserverFigureSizeMm = (double)numObserverFigureSize.Value;
            items.ObserverFigureColor = btnObserverFigureColor.BackColor;
            items.ObserverRingColor = btnObserverRingColor.BackColor;
            items.ObserverNoseColor = btnObserverNoseColor.BackColor;

            // 분석 결과 색
            items.ObserverVisibleColor = btnObserverVisibleColor.BackColor;
            items.ObserverHiddenColor = btnObserverHiddenColor.BackColor;

            // 시야 기본값
            items.ObserverAngularStepDeg = (double)numObserverAngularStep.Value;
            items.ObserverMaxDistanceMm = (double)numObserverMaxDistance.Value;
            items.ObserverEyeHeightMm = (double)numObserverEyeHeight.Value;
        }
        #endregion

        #region 사전 선택
        private void WritePreSelect(VIZCore3DX.NET.Data.SettingItems items)
        {
            ckPreSelectEnable.Checked = items.PreSelectEnable;
            btnPreSelectOutlineColor.BackColor = items.PreSelectOutlineColor;
            SetNumeric(numPreSelectDelay, items.PreSelectDelay);
            SetNumeric(numPreSelectLimit, items.PreSelectLimit);
            ckPreSelectAutoScroll.Checked = items.PreSelectAutoScrollEnabled;
            ckModelTreeAutoExpand.Checked = items.ModelTreeSelectionAutoExpandEnabled;
            ckModelTreeAutoScroll.Checked = items.ModelTreeSelectionAutoScrollEnabled;
            ckPreSelectNodeNameVisible.Checked = items.PreSelectNodeNameVisible;
            cbPreSelectNodeNameTarget.SelectedIndex = ClampIndex(items.PreSelectNodeNameTarget, cbPreSelectNodeNameTarget);
        }

        private void ReadPreSelect(VIZCore3DX.NET.Data.SettingItems items)
        {
            items.PreSelectEnable = ckPreSelectEnable.Checked;
            items.PreSelectOutlineColor = btnPreSelectOutlineColor.BackColor;
            items.PreSelectDelay = (float)numPreSelectDelay.Value;
            items.PreSelectLimit = (int)numPreSelectLimit.Value;
            items.PreSelectAutoScrollEnabled = ckPreSelectAutoScroll.Checked;
            items.ModelTreeSelectionAutoExpandEnabled = ckModelTreeAutoExpand.Checked;
            items.ModelTreeSelectionAutoScrollEnabled = ckModelTreeAutoScroll.Checked;
            items.PreSelectNodeNameVisible = ckPreSelectNodeNameVisible.Checked;
            items.PreSelectNodeNameTarget = cbPreSelectNodeNameTarget.SelectedIndex;
        }
        #endregion

        #region 툴바
        private void WriteToolbar(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 리본
            ckRibbonMode.Checked = items.RibbonMode;
            if (string.Equals(items.RibbonTheme, "Gray", StringComparison.OrdinalIgnoreCase)) cbRibbonTheme.SelectedIndex = 1;
            else if (string.Equals(items.RibbonTheme, "Dark", StringComparison.OrdinalIgnoreCase)) cbRibbonTheme.SelectedIndex = 2;
            else cbRibbonTheme.SelectedIndex = 0;
            ckRibbonMode_CheckedChanged(ckRibbonMode, EventArgs.Empty);

            // 툴바 그룹
            WriteToolbarGroup(ckToolbarHome, rbToolbarHomeTop, rbToolbarHomeLeft, rbToolbarHomeRight, numToolbarHomeRow, numToolbarHomeOrder, items.ToolbarHome, items.ToolbarHomePosition, items.ToolbarHomeRow, items.ToolbarHomeOrder);
            WriteToolbarGroup(ckToolbarNote, rbToolbarNoteTop, rbToolbarNoteLeft, rbToolbarNoteRight, numToolbarNoteRow, numToolbarNoteOrder, items.ToolbarNote, items.ToolbarNotePosition, items.ToolbarNoteRow, items.ToolbarNoteOrder);
            WriteToolbarGroup(ckToolbarMeasure, rbToolbarMeasureTop, rbToolbarMeasureLeft, rbToolbarMeasureRight, numToolbarMeasureRow, numToolbarMeasureOrder, items.ToolbarMeasure, items.ToolbarMeasurePosition, items.ToolbarMeasureRow, items.ToolbarMeasureOrder);
            WriteToolbarGroup(ckToolbarSection, rbToolbarSectionTop, rbToolbarSectionLeft, rbToolbarSectionRight, numToolbarSectionRow, numToolbarSectionOrder, items.ToolbarSection, items.ToolbarSectionPosition, items.ToolbarSectionRow, items.ToolbarSectionOrder);
            WriteToolbarGroup(ckToolbarSnapshot, rbToolbarSnapshotTop, rbToolbarSnapshotLeft, rbToolbarSnapshotRight, numToolbarSnapshotRow, numToolbarSnapshotOrder, items.ToolbarSnapShot, items.ToolbarSnapShotPosition, items.ToolbarSnapShotRow, items.ToolbarSnapShotOrder);
            WriteToolbarGroup(ckToolbarDecal, rbToolbarDecalTop, rbToolbarDecalLeft, rbToolbarDecalRight, numToolbarDecalRow, numToolbarDecalOrder, items.ToolbarDecal, items.ToolbarDecalPosition, items.ToolbarDecalRow, items.ToolbarDecalOrder);
            WriteToolbarGroup(ckToolbarPrimitive, rbToolbarPrimitiveTop, rbToolbarPrimitiveLeft, rbToolbarPrimitiveRight, numToolbarPrimitiveRow, numToolbarPrimitiveOrder, items.ToolbarPrimitive, items.ToolbarPrimitivePosition, items.ToolbarPrimitiveRow, items.ToolbarPrimitiveOrder);
            WriteToolbarGroup(ckToolbarSelectionBox, rbToolbarSelectionBoxTop, rbToolbarSelectionBoxLeft, rbToolbarSelectionBoxRight, numToolbarSelectionBoxRow, numToolbarSelectionBoxOrder, items.ToolbarSelectionBox, items.ToolbarSelectionBoxPosition, items.ToolbarSelectionBoxRow, items.ToolbarSelectionBoxOrder);
            WriteToolbarGroup(ckToolbarZone, rbToolbarZoneTop, rbToolbarZoneLeft, rbToolbarZoneRight, numToolbarZoneRow, numToolbarZoneOrder, items.ToolbarZone, items.ToolbarZonePosition, items.ToolbarZoneRow, items.ToolbarZoneOrder);
            WriteToolbarGroup(ckToolbarEffect, rbToolbarEffectTop, rbToolbarEffectLeft, rbToolbarEffectRight, numToolbarEffectRow, numToolbarEffectOrder, items.ToolbarEffect, items.ToolbarEffectPosition, items.ToolbarEffectRow, items.ToolbarEffectOrder);
            WriteToolbarGroup(ckToolbarObserver, rbToolbarObserverTop, rbToolbarObserverLeft, rbToolbarObserverRight, numToolbarObserverRow, numToolbarObserverOrder, items.ToolbarObserver, items.ToolbarObserverPosition, items.ToolbarObserverRow, items.ToolbarObserverOrder);
        }

        private void ReadToolbar(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 리본
            items.RibbonMode = ckRibbonMode.Checked;
            if (cbRibbonTheme.SelectedIndex == 1) items.RibbonTheme = "Gray";
            else if (cbRibbonTheme.SelectedIndex == 2) items.RibbonTheme = "Dark";
            else items.RibbonTheme = "Light";

            // 홈
            items.ToolbarHome = ckToolbarHome.Checked;
            items.ToolbarHomeRow = (int)numToolbarHomeRow.Value;
            items.ToolbarHomeOrder = (int)numToolbarHomeOrder.Value;
            items.ToolbarHomePrePosition = items.ToolbarHomePosition;
            items.ToolbarHomePosition = ReadToolbarPosition(rbToolbarHomeTop, rbToolbarHomeLeft);

            // 노트
            items.ToolbarNote = ckToolbarNote.Checked;
            items.ToolbarNoteRow = (int)numToolbarNoteRow.Value;
            items.ToolbarNoteOrder = (int)numToolbarNoteOrder.Value;
            items.ToolbarNotePrePosition = items.ToolbarNotePosition;
            items.ToolbarNotePosition = ReadToolbarPosition(rbToolbarNoteTop, rbToolbarNoteLeft);

            // 측정
            items.ToolbarMeasure = ckToolbarMeasure.Checked;
            items.ToolbarMeasureRow = (int)numToolbarMeasureRow.Value;
            items.ToolbarMeasureOrder = (int)numToolbarMeasureOrder.Value;
            items.ToolbarMeasurePrePosition = items.ToolbarMeasurePosition;
            items.ToolbarMeasurePosition = ReadToolbarPosition(rbToolbarMeasureTop, rbToolbarMeasureLeft);

            // 단면
            items.ToolbarSection = ckToolbarSection.Checked;
            items.ToolbarSectionRow = (int)numToolbarSectionRow.Value;
            items.ToolbarSectionOrder = (int)numToolbarSectionOrder.Value;
            items.ToolbarSectionPrePosition = items.ToolbarSectionPosition;
            items.ToolbarSectionPosition = ReadToolbarPosition(rbToolbarSectionTop, rbToolbarSectionLeft);

            // 스냅샷
            items.ToolbarSnapShot = ckToolbarSnapshot.Checked;
            items.ToolbarSnapShotRow = (int)numToolbarSnapshotRow.Value;
            items.ToolbarSnapShotOrder = (int)numToolbarSnapshotOrder.Value;
            items.ToolbarSnapShotPrePosition = items.ToolbarSnapShotPosition;
            items.ToolbarSnapShotPosition = ReadToolbarPosition(rbToolbarSnapshotTop, rbToolbarSnapshotLeft);

            // 데칼
            items.ToolbarDecal = ckToolbarDecal.Checked;
            items.ToolbarDecalRow = (int)numToolbarDecalRow.Value;
            items.ToolbarDecalOrder = (int)numToolbarDecalOrder.Value;
            items.ToolbarDecalPrePosition = items.ToolbarDecalPosition;
            items.ToolbarDecalPosition = ReadToolbarPosition(rbToolbarDecalTop, rbToolbarDecalLeft);

            // 형상 생성
            items.ToolbarPrimitive = ckToolbarPrimitive.Checked;
            items.ToolbarPrimitiveRow = (int)numToolbarPrimitiveRow.Value;
            items.ToolbarPrimitiveOrder = (int)numToolbarPrimitiveOrder.Value;
            items.ToolbarPrimitivePrePosition = items.ToolbarPrimitivePosition;
            items.ToolbarPrimitivePosition = ReadToolbarPosition(rbToolbarPrimitiveTop, rbToolbarPrimitiveLeft);

            // 선택상자
            items.ToolbarSelectionBox = ckToolbarSelectionBox.Checked;
            items.ToolbarSelectionBoxRow = (int)numToolbarSelectionBoxRow.Value;
            items.ToolbarSelectionBoxOrder = (int)numToolbarSelectionBoxOrder.Value;
            items.ToolbarSelectionBoxPrePosition = items.ToolbarSelectionBoxPosition;
            items.ToolbarSelectionBoxPosition = ReadToolbarPosition(rbToolbarSelectionBoxTop, rbToolbarSelectionBoxLeft);

            // 다면체 공간
            items.ToolbarZone = ckToolbarZone.Checked;
            items.ToolbarZoneRow = (int)numToolbarZoneRow.Value;
            items.ToolbarZoneOrder = (int)numToolbarZoneOrder.Value;
            items.ToolbarZonePrePosition = items.ToolbarZonePosition;
            items.ToolbarZonePosition = ReadToolbarPosition(rbToolbarZoneTop, rbToolbarZoneLeft);

            // 특수 효과
            items.ToolbarEffect = ckToolbarEffect.Checked;
            items.ToolbarEffectRow = (int)numToolbarEffectRow.Value;
            items.ToolbarEffectOrder = (int)numToolbarEffectOrder.Value;
            items.ToolbarEffectPrePosition = items.ToolbarEffectPosition;
            items.ToolbarEffectPosition = ReadToolbarPosition(rbToolbarEffectTop, rbToolbarEffectLeft);

            // 옵저버
            items.ToolbarObserver = ckToolbarObserver.Checked;
            items.ToolbarObserverRow = (int)numToolbarObserverRow.Value;
            items.ToolbarObserverOrder = (int)numToolbarObserverOrder.Value;
            items.ToolbarObserverPrePosition = items.ToolbarObserverPosition;
            items.ToolbarObserverPosition = ReadToolbarPosition(rbToolbarObserverTop, rbToolbarObserverLeft);
        }

        // 툴바 그룹 하나의 표시·위치·줄·순서를 화면에 씁니다.
        private void WriteToolbarGroup(CheckBox ck, RadioButton top, RadioButton left, RadioButton right, NumericUpDown row, NumericUpDown order, bool visible, string position, int rowValue, int orderValue)
        {
            ck.Checked = visible;

            if (string.Equals(position, "Left", StringComparison.OrdinalIgnoreCase)) left.Checked = true;
            else if (string.Equals(position, "Right", StringComparison.OrdinalIgnoreCase)) right.Checked = true;
            else top.Checked = true;

            SetNumeric(row, rowValue);
            SetNumeric(order, orderValue);
        }

        // 툴바 그룹의 위치 라디오를 위치 문자열로 바꿉니다.
        private string ReadToolbarPosition(RadioButton top, RadioButton left)
        {
            if (top.Checked == true) return "Top";
            if (left.Checked == true) return "Left";
            return "Right";
        }

        // 리본 모드에서는 테마를 고르고, 툴바 모드에서는 순서를 지정하도록 전환합니다.
        private void ckRibbonMode_CheckedChanged(object sender, EventArgs e)
        {
            bool ribbon = ckRibbonMode.Checked;

            cbRibbonTheme.Enabled = ribbon;

            numToolbarHomeOrder.Enabled = !ribbon;
            numToolbarNoteOrder.Enabled = !ribbon;
            numToolbarMeasureOrder.Enabled = !ribbon;
            numToolbarSectionOrder.Enabled = !ribbon;
            numToolbarSnapshotOrder.Enabled = !ribbon;
            numToolbarDecalOrder.Enabled = !ribbon;
            numToolbarPrimitiveOrder.Enabled = !ribbon;
            numToolbarSelectionBoxOrder.Enabled = !ribbon;
            numToolbarZoneOrder.Enabled = !ribbon;
            numToolbarEffectOrder.Enabled = !ribbon;
            numToolbarObserverOrder.Enabled = !ribbon;
        }
        #endregion

        #region 창
        private void WriteWindow(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 모델 트리 탭
            ckModelTreePanelVisible.Checked = items.ModelTreePanelVisible;
            cbModelTreePanelPosition.SelectedIndex = ClampIndex(items.ModelTreePanelPosition, cbModelTreePanelPosition);
            SetNumeric(numModelTreePanelWidth, items.ModelTreePanelWidth);

            // 특성 및 속성 탭
            ckAttributePanelVisible.Checked = items.AttributePanelVisible;
            cbAttributePanelPosition.SelectedIndex = ClampIndex(items.AttributePanelPosition, cbAttributePanelPosition);
            SetNumeric(numAttributePanelWidth, items.AttributePanelWidth);

            // 두 패널이 같은 위치일 때
            SelectRadio(items.PanelSplitDirection, rbSplitTop, rbSplitBottom, rbSplitLeft, rbSplitRight);
            cbPanelPosition_SelectedIndexChanged(cbModelTreePanelPosition, EventArgs.Empty);
        }

        private void ReadWindow(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 모델 트리 탭
            items.ModelTreePanelVisible = ckModelTreePanelVisible.Checked;
            items.ModelTreePanelPosition = cbModelTreePanelPosition.SelectedIndex;
            items.ModelTreePanelWidth = (int)numModelTreePanelWidth.Value;

            // 특성 및 속성 탭
            items.AttributePanelVisible = ckAttributePanelVisible.Checked;
            items.AttributePanelPosition = cbAttributePanelPosition.SelectedIndex;
            items.AttributePanelWidth = (int)numAttributePanelWidth.Value;

            // 두 패널이 같은 위치일 때
            items.PanelSplitDirection = RadioIndex(items.PanelSplitDirection, rbSplitTop, rbSplitBottom, rbSplitLeft, rbSplitRight);
        }

        // 두 패널이 같은 위치면 속성 너비를 모델 트리에 맞추고 분할 방향을 고르게 합니다.
        private void cbPanelPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool samePosition = cbModelTreePanelPosition.SelectedIndex == cbAttributePanelPosition.SelectedIndex;

            if (samePosition)
            {
                numAttributePanelWidth.Enabled = false;
                numAttributePanelWidth.Value = Math.Max(numAttributePanelWidth.Minimum, Math.Min(numAttributePanelWidth.Maximum, numModelTreePanelWidth.Value));
                grpWindowSplit.Enabled = true;
            }
            else
            {
                numAttributePanelWidth.Enabled = true;
                grpWindowSplit.Enabled = false;
            }
        }
        #endregion

        #region 개발 도구
        private void WriteDevTools(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 정보
            checkDebugInfo.Checked = items.IsDebugInfoEnabled;

            // 캐시
            SetNumeric(numericPermanentCacheSize, items.PermanentCacheSize);
            SetNumeric(numericTemporaryCacheSize, items.TemporaryCacheSize);

            // 점진적 렌더링
            SetNumeric(numericRenderingLimitInControl, items.RenderingLimitInControl);
            SetNumeric(numericRenderingLimitPerStep, items.RenderingLimitPerStep);
            checkAutomaticRenderingLimit.Checked = items.IsAutomaticRenderingLimitEnabled;
        }

        private void ReadDevTools(VIZCore3DX.NET.Data.SettingItems items)
        {
            // 정보
            items.IsDebugInfoEnabled = checkDebugInfo.Checked;

            // 캐시
            items.PermanentCacheSize = (int)numericPermanentCacheSize.Value;
            items.TemporaryCacheSize = (int)numericTemporaryCacheSize.Value;

            // 점진적 렌더링
            items.RenderingLimitInControl = (int)numericRenderingLimitInControl.Value;
            items.RenderingLimitPerStep = (int)numericRenderingLimitPerStep.Value;
            items.IsAutomaticRenderingLimitEnabled = checkAutomaticRenderingLimit.Checked;
        }
        #endregion

        #region 3. 적용
        // 뷰어의 현재 설정을 다시 읽어 옵니다.
        private void btnRead_Click(object sender, EventArgs e)
        {
            ReadFromViewer();
            if (_items != null) SetStatus("현재 설정을 읽었습니다.");
        }

        // 화면에서 편집한 값을 한 번에 뷰어에 적용합니다.
        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyControls();
        }

        // 기본값을 화면에 채웁니다. 적용 버튼을 눌러야 뷰어에 반영됩니다.
        private void btnDefault_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.SettingItems defaults = vizcore3dx.Setting.GetDefaultItems();
            if (defaults == null) return;

            _items = defaults;
            WriteToControls(_items);
            SetStatus("기본값을 채웠습니다. 적용 버튼으로 반영합니다.");
        }

        // 화면 값을 적용한 뒤 설정 파일로 저장합니다.
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ApplyControls() == false) return;

            if (vizcore3dx.Setting.ExportDialog() == true) SetStatus("파일로 저장했습니다.");
        }

        // 설정 파일을 불러와 뷰어에 적용하고 화면을 다시 채웁니다.
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Setting.LoadDialog() == false) return;

            ReadFromViewer();
            if (_items != null) SetStatus("파일에서 불러왔습니다.");
        }

        // 화면 값을 설정 사본에 모아 적용합니다.
        private bool ApplyControls()
        {
            if (_items == null) _items = vizcore3dx.Setting.GetItems();
            if (_items == null)
            {
                SetStatus("설정을 읽지 못했습니다.");
                return false;
            }

            ReadFromControls(_items);

            if (vizcore3dx.Setting.Apply(_items) == true)
            {
                SetStatus("적용했습니다.");
                return true;
            }

            SetStatus(string.Format("적용 실패 : {0}", vizcore3dx.Setting.LastOperationResult));
            return false;
        }
        #endregion

        #region Helpers
        private void SetStatus(string message)
        {
            lblStatus.Text = message;
        }

        // 색 버튼을 눌러 색을 고르면 버튼 배경색에 보관합니다.
        private void btnColor_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;

            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.FullOpen = true;
                dialog.Color = button.BackColor;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                    button.BackColor = dialog.Color;
            }
        }

        // 범위를 벗어난 값은 잘라서 넣습니다.
        private void SetNumeric(NumericUpDown num, double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                num.Value = num.Minimum;
                return;
            }

            double min = (double)num.Minimum;
            double max = (double)num.Maximum;
            num.Value = (decimal)Math.Max(min, Math.Min(max, value));
        }

        private float ParseFloat(TextBox txt, float fallback)
        {
            float value;
            if (float.TryParse(txt.Text, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out value) == true)
                return value;

            return fallback;
        }

        private int ToTextSizeIndex(VIZCore3DX.NET.Data.TextSizeType size)
        {
            int index = Array.IndexOf(TextSizes, (int)size);
            return index >= 0 ? index : Array.IndexOf(TextSizes, 14);
        }

        private VIZCore3DX.NET.Data.TextSizeType ToTextSize(ComboBox cb)
        {
            if (cb.SelectedIndex < 0 || cb.SelectedIndex >= TextSizes.Length)
                return VIZCore3DX.NET.Data.TextSizeType.Size_14;

            return (VIZCore3DX.NET.Data.TextSizeType)TextSizes[cb.SelectedIndex];
        }

        private int ClampIndex(int value, ComboBox cb)
        {
            if (value < 0 || value >= cb.Items.Count) return 0;
            return value;
        }

        // 값에 해당하는 라디오만 선택합니다. 범위 밖이면 모두 해제합니다.
        private void SelectRadio(int value, params RadioButton[] radios)
        {
            for (int i = 0; i < radios.Length; i++)
                radios[i].Checked = i == value;
        }

        // 선택된 라디오의 순번을 돌려줍니다. 선택이 없으면 fallback 을 돌려줍니다.
        private int RadioIndex(int fallback, params RadioButton[] radios)
        {
            for (int i = 0; i < radios.Length; i++)
            {
                if (radios[i].Checked == true) return i;
            }

            return fallback;
        }

        // 지정한 탭만 남기고 나머지 툴바(=리본 탭)와 모델 트리 패널의 같은 탭을 숨깁니다. 홈 탭·모델 트리는 항상 표시합니다.
        private void ShowRibbonTabs(params VIZCore3DX.NET.Data.ToolbarKind[] keep)
        {
            foreach (VIZCore3DX.NET.Data.ToolbarKind kind in Enum.GetValues(typeof(VIZCore3DX.NET.Data.ToolbarKind)))
                vizcore3dx.Toolbar.SetVisible(kind, kind == VIZCore3DX.NET.Data.ToolbarKind.Main || Array.IndexOf(keep, kind) >= 0);

            vizcore3dx.TabSnapshotEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Snapshot) >= 0;
            vizcore3dx.TabNotetEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Note) >= 0;
            vizcore3dx.TabMeasureEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Measure) >= 0;
            vizcore3dx.TabSectionEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Section) >= 0;
            vizcore3dx.TabDecalEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Decal) >= 0;
            vizcore3dx.TabSelectionBoxEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.SelectionBox) >= 0;
            vizcore3dx.TabZoneEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Zone) >= 0;
            vizcore3dx.TabEffectEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Effect) >= 0;
            vizcore3dx.TabObserverEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Observer) >= 0;
        }

        // 속성 패널은 노드 특성·노드 속성만 기본으로 남기고, 예제가 다루는 탭만 켭니다.
        private void ShowAttributeTabs(bool attributeTree = false, bool nodeGroup = false, bool projection = false, bool pmi = false)
        {
            vizcore3dx.TabAttributeTreeEnabled = attributeTree;
            vizcore3dx.TabNodeGroupEnabled = nodeGroup;
            vizcore3dx.TabProjectionEnabled = projection;
            vizcore3dx.TabPmiEnabled = pmi;
            vizcore3dx.TabEnvironmentEnabled = false;
            vizcore3dx.TabGenericDataEnabled = false;
            vizcore3dx.AttributePanelVisible = attributeTree || nodeGroup || projection || pmi;
        }
        #endregion
    }
}
