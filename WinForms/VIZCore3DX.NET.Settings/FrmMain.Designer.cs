namespace VIZCore3DX.NET.Settings
{
    partial class FrmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tpHome = new System.Windows.Forms.TabPage();
            this.tpView = new System.Windows.Forms.TabPage();
            this.tpInput = new System.Windows.Forms.TabPage();
            this.tpNote = new System.Windows.Forms.TabPage();
            this.tpMeasure = new System.Windows.Forms.TabPage();
            this.tpSection = new System.Windows.Forms.TabPage();
            this.tpDecal = new System.Windows.Forms.TabPage();
            this.tpSpace = new System.Windows.Forms.TabPage();
            this.tpFrame = new System.Windows.Forms.TabPage();
            this.tpObserver = new System.Windows.Forms.TabPage();
            this.tpPreSelect = new System.Windows.Forms.TabPage();
            this.tpToolbar = new System.Windows.Forms.TabPage();
            this.tpWindow = new System.Windows.Forms.TabPage();
            this.tpDevTools = new System.Windows.Forms.TabPage();
            this.grpHomeModel = new System.Windows.Forms.GroupBox();
            this.ckEnableFace = new System.Windows.Forms.CheckBox();
            this.ckEnableBody = new System.Windows.Forms.CheckBox();
            this.ckEnableNodeLock = new System.Windows.Forms.CheckBox();
            this.grpHomeView = new System.Windows.Forms.GroupBox();
            this.cbCameraMode = new System.Windows.Forms.ComboBox();
            this.lblCameraMode = new System.Windows.Forms.Label();
            this.cbProjection = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ckEnableSsao = new System.Windows.Forms.CheckBox();
            this.ckEnableShadow = new System.Windows.Forms.CheckBox();
            this.ckEnableEdge = new System.Windows.Forms.CheckBox();
            this.lblEdgeColor = new System.Windows.Forms.Label();
            this.btnEdgeColor = new System.Windows.Forms.Button();
            this.grpHomeCamera = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numCameraInitialFov = new System.Windows.Forms.NumericUpDown();
            this.numCameraBoundingBoxMaxZ = new System.Windows.Forms.NumericUpDown();
            this.numCameraBoundingBoxMaxY = new System.Windows.Forms.NumericUpDown();
            this.numCameraBoundingBoxMaxX = new System.Windows.Forms.NumericUpDown();
            this.numCameraBoundingBoxMinZ = new System.Windows.Forms.NumericUpDown();
            this.numCameraBoundingBoxMinY = new System.Windows.Forms.NumericUpDown();
            this.numCameraBoundingBoxMinX = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.ckInitialCamera = new System.Windows.Forms.CheckBox();
            this.grpHomeSelection = new System.Windows.Forms.GroupBox();
            this.label77 = new System.Windows.Forms.Label();
            this.cbSelectionObject3DType = new System.Windows.Forms.ComboBox();
            this.label78 = new System.Windows.Forms.Label();
            this.ckSelectionOutline = new System.Windows.Forms.CheckBox();
            this.btnSelectionOutlineColor = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.comboXRaySelectionColor = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.ckBoxSelectionFrontObjectOnly = new System.Windows.Forms.CheckBox();
            this.btnSelectionBoxStrokeColor = new System.Windows.Forms.Button();
            this.btnSelectionBoxFillColor = new System.Windows.Forms.Button();
            this.btnSelectionColor = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.grpHomeBackground = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGradientVectorY = new System.Windows.Forms.TextBox();
            this.txtGradientVectorX = new System.Windows.Forms.TextBox();
            this.txtGradientPosition3 = new System.Windows.Forms.TextBox();
            this.txtGradientPosition2 = new System.Windows.Forms.TextBox();
            this.txtGradientPosition1 = new System.Windows.Forms.TextBox();
            this.cbBackgroundColorCount = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.labelGradientVector = new System.Windows.Forms.Label();
            this.cbBackgroundMode = new System.Windows.Forms.ComboBox();
            this.labelBackgroundMode = new System.Windows.Forms.Label();
            this.btnBackgroundColor3 = new System.Windows.Forms.Button();
            this.btnBackgroundColor2 = new System.Windows.Forms.Button();
            this.btnBackgroundColor1 = new System.Windows.Forms.Button();
            this.labelBackgroundColor = new System.Windows.Forms.Label();
            this.grpHomeSnap = new System.Windows.Forms.GroupBox();
            this.btnSnapHighlightColor = new System.Windows.Forms.Button();
            this.btnSnapColor = new System.Windows.Forms.Button();
            this.label83 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.numSnapCylinderAxisSize = new System.Windows.Forms.NumericUpDown();
            this.numSnapPointSize = new System.Windows.Forms.NumericUpDown();
            this.numSnapPlaneSize = new System.Windows.Forms.NumericUpDown();
            this.label81 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.grpSpaceSelectionBox = new System.Windows.Forms.GroupBox();
            this.cbSelectionBoxStrokePattern = new System.Windows.Forms.ComboBox();
            this.label101 = new System.Windows.Forms.Label();
            this.cbSelectionBoxTextSize = new System.Windows.Forms.ComboBox();
            this.label104 = new System.Windows.Forms.Label();
            this.btnSelectionBoxTextColor = new System.Windows.Forms.Button();
            this.label103 = new System.Windows.Forms.Label();
            this.numSelectionBoxStrokeThickness = new System.Windows.Forms.NumericUpDown();
            this.label102 = new System.Windows.Forms.Label();
            this.btnSelectionBoxHighlightedStrokeColor = new System.Windows.Forms.Button();
            this.label100 = new System.Windows.Forms.Label();
            this.btnSelectionBoxDefaultStrokeColor = new System.Windows.Forms.Button();
            this.label99 = new System.Windows.Forms.Label();
            this.btnSelectionBoxSelectedStrokeColor = new System.Windows.Forms.Button();
            this.label98 = new System.Windows.Forms.Label();
            this.btnSelectionBoxSelectedFillColor = new System.Windows.Forms.Button();
            this.label97 = new System.Windows.Forms.Label();
            this.btnSelectionBoxHighlightedFillColor = new System.Windows.Forms.Button();
            this.label96 = new System.Windows.Forms.Label();
            this.btnSelectionBoxDefaultFillColor = new System.Windows.Forms.Button();
            this.label95 = new System.Windows.Forms.Label();
            this.grpSpaceZone = new System.Windows.Forms.GroupBox();
            this.numZoneFaceOpacity = new System.Windows.Forms.NumericUpDown();
            this.lblZoneFaceOpacity = new System.Windows.Forms.Label();
            this.btnZoneLineColor = new System.Windows.Forms.Button();
            this.lblZoneLineColor = new System.Windows.Forms.Label();
            this.btnZoneFaceColor = new System.Windows.Forms.Button();
            this.lblZoneFaceColor = new System.Windows.Forms.Label();
            this.grpViewView = new System.Windows.Forms.GroupBox();
            this.ckEnableAnimation = new System.Windows.Forms.CheckBox();
            this.ckEnableAutoFit = new System.Windows.Forms.CheckBox();
            this.lblRenderScaleRange = new System.Windows.Forms.Label();
            this.numRenderScale = new System.Windows.Forms.NumericUpDown();
            this.lblRenderScale = new System.Windows.Forms.Label();
            this.ckViewToolbarEnable = new System.Windows.Forms.CheckBox();
            this.lblFallbackFontFamilies = new System.Windows.Forms.Label();
            this.cbFallbackFontFamilies = new System.Windows.Forms.ComboBox();
            this.grpViewZoom = new System.Windows.Forms.GroupBox();
            this.numZoomRatio = new System.Windows.Forms.NumericUpDown();
            this.label84 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.grpViewCube = new System.Windows.Forms.GroupBox();
            this.ckViewCubeEnable = new System.Windows.Forms.CheckBox();
            this.cbViewCubeFontSize = new System.Windows.Forms.ComboBox();
            this.btnViewCubeFontColor = new System.Windows.Forms.Button();
            this.btnViewCubeHighlightedStrokeColor = new System.Windows.Forms.Button();
            this.btnViewCubeHighlightedFillColor = new System.Windows.Forms.Button();
            this.btnViewCubeStrokeColor = new System.Windows.Forms.Button();
            this.btnViewCubeFillColor = new System.Windows.Forms.Button();
            this.label94 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.grpViewCubeFace = new System.Windows.Forms.GroupBox();
            this.lblViewCubeTop = new System.Windows.Forms.Label();
            this.txtViewCubeTop = new System.Windows.Forms.TextBox();
            this.lblViewCubeBottom = new System.Windows.Forms.Label();
            this.txtViewCubeBottom = new System.Windows.Forms.TextBox();
            this.lblViewCubeLeft = new System.Windows.Forms.Label();
            this.txtViewCubeLeft = new System.Windows.Forms.TextBox();
            this.lblViewCubeRight = new System.Windows.Forms.Label();
            this.txtViewCubeRight = new System.Windows.Forms.TextBox();
            this.lblViewCubeFront = new System.Windows.Forms.Label();
            this.txtViewCubeFront = new System.Windows.Forms.TextBox();
            this.lblViewCubeBack = new System.Windows.Forms.Label();
            this.txtViewCubeBack = new System.Windows.Forms.TextBox();
            this.grpViewCommand = new System.Windows.Forms.GroupBox();
            this.btnCommandMessageTextColor = new System.Windows.Forms.Button();
            this.label105 = new System.Windows.Forms.Label();
            this.grpViewLight = new System.Windows.Forms.GroupBox();
            this.ckEnvironmentLight = new System.Windows.Forms.CheckBox();
            this.lblLightDir = new System.Windows.Forms.Label();
            this.lblDirX = new System.Windows.Forms.Label();
            this.txtLightDirX = new System.Windows.Forms.TextBox();
            this.lblDirY = new System.Windows.Forms.Label();
            this.txtLightDirY = new System.Windows.Forms.TextBox();
            this.lblDirZ = new System.Windows.Forms.Label();
            this.txtLightDirZ = new System.Windows.Forms.TextBox();
            this.lblAmbientColor = new System.Windows.Forms.Label();
            this.btnAmbientColor = new System.Windows.Forms.Button();
            this.lblLightColor = new System.Windows.Forms.Label();
            this.btnLightColor = new System.Windows.Forms.Button();
            this.lblShininess = new System.Windows.Forms.Label();
            this.numShininess = new System.Windows.Forms.NumericUpDown();
            this.lblShininessRange = new System.Windows.Forms.Label();
            this.lblSpecularIntensity = new System.Windows.Forms.Label();
            this.numSpecularIntensity = new System.Windows.Forms.NumericUpDown();
            this.lblSpecularRange = new System.Windows.Forms.Label();
            this.grpViewZoomBox = new System.Windows.Forms.GroupBox();
            this.lblZoomBoxFillColor = new System.Windows.Forms.Label();
            this.btnZoomBoxFillColor = new System.Windows.Forms.Button();
            this.lblZoomBoxStrokeColor = new System.Windows.Forms.Label();
            this.btnZoomBoxStrokeColor = new System.Windows.Forms.Button();
            this.lblZoomBoxStrokePattern = new System.Windows.Forms.Label();
            this.cbZoomBoxStrokePattern = new System.Windows.Forms.ComboBox();
            this.lblZoomBoxStrokeThickness = new System.Windows.Forms.Label();
            this.numZoomBoxStrokeThickness = new System.Windows.Forms.NumericUpDown();
            this.grpWindowModelingControl = new System.Windows.Forms.GroupBox();
            this.ckModelingControl = new System.Windows.Forms.CheckBox();
            this.grpMcSize = new System.Windows.Forms.GroupBox();
            this.rbMcSizeSmall = new System.Windows.Forms.RadioButton();
            this.rbMcSizeMedium = new System.Windows.Forms.RadioButton();
            this.rbMcSizeLarge = new System.Windows.Forms.RadioButton();
            this.grpMcPosition = new System.Windows.Forms.GroupBox();
            this.rbMcPosTL = new System.Windows.Forms.RadioButton();
            this.rbMcPosTC = new System.Windows.Forms.RadioButton();
            this.rbMcPosTR = new System.Windows.Forms.RadioButton();
            this.rbMcPosBL = new System.Windows.Forms.RadioButton();
            this.rbMcPosBC = new System.Windows.Forms.RadioButton();
            this.rbMcPosBR = new System.Windows.Forms.RadioButton();
            this.rbMcPosLS = new System.Windows.Forms.RadioButton();
            this.rbMcPosRS = new System.Windows.Forms.RadioButton();
            this.grpMcColor = new System.Windows.Forms.GroupBox();
            this.rbMcColorBlack = new System.Windows.Forms.RadioButton();
            this.rbMcColorGray = new System.Windows.Forms.RadioButton();
            this.rbMcColorWhite = new System.Windows.Forms.RadioButton();
            this.grpMcBackground = new System.Windows.Forms.GroupBox();
            this.rbMcBgTransparent = new System.Windows.Forms.RadioButton();
            this.rbMcBgSemi = new System.Windows.Forms.RadioButton();
            this.rbMcBgColored = new System.Windows.Forms.RadioButton();
            this.grpMcBackgroundColor = new System.Windows.Forms.GroupBox();
            this.rbMcBgColorBlack = new System.Windows.Forms.RadioButton();
            this.rbMcBgColorGray = new System.Windows.Forms.RadioButton();
            this.rbMcBgColorWhite = new System.Windows.Forms.RadioButton();
            this.grpMcOrientation = new System.Windows.Forms.GroupBox();
            this.rbMcOrientH = new System.Windows.Forms.RadioButton();
            this.rbMcOrientV = new System.Windows.Forms.RadioButton();
            this.grpInputSensitivity = new System.Windows.Forms.GroupBox();
            this.lblInputOrbitSens = new System.Windows.Forms.Label();
            this.numInputOrbitSens = new System.Windows.Forms.NumericUpDown();
            this.lblInputPanSens = new System.Windows.Forms.Label();
            this.numInputPanSens = new System.Windows.Forms.NumericUpDown();
            this.lblInputZoomSens = new System.Windows.Forms.Label();
            this.numInputZoomSens = new System.Windows.Forms.NumericUpDown();
            this.lblInputRollSens = new System.Windows.Forms.Label();
            this.numInputRollSens = new System.Windows.Forms.NumericUpDown();
            this.lblInputLookSens = new System.Windows.Forms.Label();
            this.numInputLookSens = new System.Windows.Forms.NumericUpDown();
            this.grpInputSpeed = new System.Windows.Forms.GroupBox();
            this.lblInputWalkSpeed = new System.Windows.Forms.Label();
            this.numInputWalkSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblInputWalkBoost = new System.Windows.Forms.Label();
            this.numInputWalkBoost = new System.Windows.Forms.NumericUpDown();
            this.lblInputFlySpeed = new System.Windows.Forms.Label();
            this.numInputFlySpeed = new System.Windows.Forms.NumericUpDown();
            this.lblInputFlyBoost = new System.Windows.Forms.Label();
            this.numInputFlyBoost = new System.Windows.Forms.NumericUpDown();
            this.grpInputClick = new System.Windows.Forms.GroupBox();
            this.ckInputWheelInvert = new System.Windows.Forms.CheckBox();
            this.lblInputClickDuration = new System.Windows.Forms.Label();
            this.numInputClickDuration = new System.Windows.Forms.NumericUpDown();
            this.lblInputLongPress = new System.Windows.Forms.Label();
            this.numInputLongPress = new System.Windows.Forms.NumericUpDown();
            this.lblInputClickTolerance = new System.Windows.Forms.Label();
            this.numInputClickTolerance = new System.Windows.Forms.NumericUpDown();
            this.grpNoteStyle = new System.Windows.Forms.GroupBox();
            this.cbNoteTextHorizontalAlignment = new System.Windows.Forms.ComboBox();
            this.label75 = new System.Windows.Forms.Label();
            this.cbNoteLineStrokePattern = new System.Windows.Forms.ComboBox();
            this.label51 = new System.Windows.Forms.Label();
            this.txtNoteArrowSize = new System.Windows.Forms.TextBox();
            this.txtNoteLineWidth = new System.Windows.Forms.TextBox();
            this.cbNoteFontSize = new System.Windows.Forms.ComboBox();
            this.btnNoteArrowColor = new System.Windows.Forms.Button();
            this.btnNoteLineColor = new System.Windows.Forms.Button();
            this.btnNoteTextColor = new System.Windows.Forms.Button();
            this.btnNoteSelectedBoxStrokeColor = new System.Windows.Forms.Button();
            this.btnNoteHighlightedBoxStrokeColor = new System.Windows.Forms.Button();
            this.btnNoteHighlightedBoxFillColor = new System.Windows.Forms.Button();
            this.btnNoteBoxStrokeColor = new System.Windows.Forms.Button();
            this.btnNoteBoxFillColor = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.grpNoteSymbol = new System.Windows.Forms.GroupBox();
            this.txtNoteSymbolSize = new System.Windows.Forms.TextBox();
            this.btnNoteSymbolTextColor = new System.Windows.Forms.Button();
            this.cbNoteSymbolTextSize = new System.Windows.Forms.ComboBox();
            this.btnNoteSymbolStrokeColor = new System.Windows.Forms.Button();
            this.btnNoteSymbolFillColor = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.grpMeasureOption = new System.Windows.Forms.GroupBox();
            this.ckMeasureXYZAxisDistanceDecomposed = new System.Windows.Forms.CheckBox();
            this.cbMeasureDecimalPoint = new System.Windows.Forms.ComboBox();
            this.cbMeasureUnit = new System.Windows.Forms.ComboBox();
            this.cbMeasureDistanceUnit = new System.Windows.Forms.ComboBox();
            this.ckMeasureUnit = new System.Windows.Forms.CheckBox();
            this.ckMeasureType = new System.Windows.Forms.CheckBox();
            this.ckMeasureFrame = new System.Windows.Forms.CheckBox();
            this.ckMeasureDxDyDz = new System.Windows.Forms.CheckBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.grpMeasureStyle = new System.Windows.Forms.GroupBox();
            this.cbMeasureTextHorizontalAlignment = new System.Windows.Forms.ComboBox();
            this.label76 = new System.Windows.Forms.Label();
            this.cbMeasureLineStrokePattern = new System.Windows.Forms.ComboBox();
            this.label65 = new System.Windows.Forms.Label();
            this.txtMeasureArrowSize = new System.Windows.Forms.TextBox();
            this.txtMeasureLineWidth = new System.Windows.Forms.TextBox();
            this.cbMeasureFontSize = new System.Windows.Forms.ComboBox();
            this.btnMeasureArrowColor = new System.Windows.Forms.Button();
            this.btnMeasureLineColor = new System.Windows.Forms.Button();
            this.btnMeasureTextColor = new System.Windows.Forms.Button();
            this.btnMeasureSelectedBoxStrokeColor = new System.Windows.Forms.Button();
            this.btnMeasureHighlightedBoxStrokeColor = new System.Windows.Forms.Button();
            this.btnMeasureHighlightedBoxFillColor = new System.Windows.Forms.Button();
            this.btnMeasureBoxStrokeColor = new System.Windows.Forms.Button();
            this.btnMeasureBoxFillColor = new System.Windows.Forms.Button();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.grpMeasureSnap = new System.Windows.Forms.GroupBox();
            this.numMeasureSnapCylinderAxisSize = new System.Windows.Forms.NumericUpDown();
            this.numMeasureSnapPointSize = new System.Windows.Forms.NumericUpDown();
            this.numMeasureSnapPlaneSize = new System.Windows.Forms.NumericUpDown();
            this.label86 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.grpSectionStyle = new System.Windows.Forms.GroupBox();
            this.btnSectionDisabledBoundaryStrokeColor = new System.Windows.Forms.Button();
            this.label74 = new System.Windows.Forms.Label();
            this.btnSectionHighlightedBoundaryStrokeColor = new System.Windows.Forms.Button();
            this.label73 = new System.Windows.Forms.Label();
            this.cbSectionManipulatorDisplayMode = new System.Windows.Forms.ComboBox();
            this.label72 = new System.Windows.Forms.Label();
            this.btnSectionSelectedBoundaryStrokeColor = new System.Windows.Forms.Button();
            this.label71 = new System.Windows.Forms.Label();
            this.btnSectionDisabledFaceFillColor = new System.Windows.Forms.Button();
            this.label70 = new System.Windows.Forms.Label();
            this.cbSectionBoundaryStrokePattern = new System.Windows.Forms.ComboBox();
            this.label69 = new System.Windows.Forms.Label();
            this.btnSectionBoundaryStrokeColor = new System.Windows.Forms.Button();
            this.label68 = new System.Windows.Forms.Label();
            this.txtSectionBoundaryStrokeThickness = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.btnSectionFaceFillColor = new System.Windows.Forms.Button();
            this.label66 = new System.Windows.Forms.Label();
            this.grpSectionCap = new System.Windows.Forms.GroupBox();
            this.txtCapStrokeThickness = new System.Windows.Forms.TextBox();
            this.lblCapStrokeThickness = new System.Windows.Forms.Label();
            this.cbCapStrokeColorMode = new System.Windows.Forms.ComboBox();
            this.lblCapStrokeColorMode = new System.Windows.Forms.Label();
            this.btnCapStrokeColor = new System.Windows.Forms.Button();
            this.lblCapStrokeColor = new System.Windows.Forms.Label();
            this.cbCapFillColorMode = new System.Windows.Forms.ComboBox();
            this.lblCapFillColorMode = new System.Windows.Forms.Label();
            this.btnCapFillColor = new System.Windows.Forms.Button();
            this.lblCapFillColor = new System.Windows.Forms.Label();
            this.cbCapStroke = new System.Windows.Forms.CheckBox();
            this.cbCapFill = new System.Windows.Forms.CheckBox();
            this.grpDecal = new System.Windows.Forms.GroupBox();
            this.lblDecalHighlightedBoxFillColor = new System.Windows.Forms.Label();
            this.btnDecalHighlightedBoxFillColor = new System.Windows.Forms.Button();
            this.lblDecalHighlightedBoxStrokeColor = new System.Windows.Forms.Label();
            this.btnDecalHighlightedBoxStrokeColor = new System.Windows.Forms.Button();
            this.lblDecalSelectedBoxStrokeColor = new System.Windows.Forms.Label();
            this.btnDecalSelectedBoxStrokeColor = new System.Windows.Forms.Button();
            this.lblDecalRotationAngleStep = new System.Windows.Forms.Label();
            this.numDecalRotationAngleStep = new System.Windows.Forms.NumericUpDown();
            this.lblDecalRotationAngleStepUnit = new System.Windows.Forms.Label();
            this.grpFrameView = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBoxFrameZLabel = new System.Windows.Forms.ComboBox();
            this.comboBoxFrameYLabel = new System.Windows.Forms.ComboBox();
            this.comboBoxFrameXLabel = new System.Windows.Forms.ComboBox();
            this.ckFrameZLine = new System.Windows.Forms.CheckBox();
            this.ckFrameZXPlane = new System.Windows.Forms.CheckBox();
            this.ckFrameYLine = new System.Windows.Forms.CheckBox();
            this.ckFrameYZPlane = new System.Windows.Forms.CheckBox();
            this.ckFrameXLine = new System.Windows.Forms.CheckBox();
            this.ckFrameXYPlane = new System.Windows.Forms.CheckBox();
            this.grpFrameColor = new System.Windows.Forms.GroupBox();
            this.cbFramePlaneStrokePattern = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbGridLineStrokePattern = new System.Windows.Forms.ComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.btnFrameLabelColor = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.numFrameLineThickness = new System.Windows.Forms.NumericUpDown();
            this.numFramePlaneThickness = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnFrameLineColor = new System.Windows.Forms.Button();
            this.btnFramePlaneColor = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.grpPreSelect = new System.Windows.Forms.GroupBox();
            this.ckPreSelectEnable = new System.Windows.Forms.CheckBox();
            this.lblPreSelectOutlineColor = new System.Windows.Forms.Label();
            this.btnPreSelectOutlineColor = new System.Windows.Forms.Button();
            this.lblPreSelectDelay = new System.Windows.Forms.Label();
            this.numPreSelectDelay = new System.Windows.Forms.NumericUpDown();
            this.lblPreSelectLimit = new System.Windows.Forms.Label();
            this.numPreSelectLimit = new System.Windows.Forms.NumericUpDown();
            this.ckPreSelectAutoScroll = new System.Windows.Forms.CheckBox();
            this.ckModelTreeAutoExpand = new System.Windows.Forms.CheckBox();
            this.ckModelTreeAutoScroll = new System.Windows.Forms.CheckBox();
            this.ckPreSelectNodeNameVisible = new System.Windows.Forms.CheckBox();
            this.lblPreSelectNodeNameTarget = new System.Windows.Forms.Label();
            this.cbPreSelectNodeNameTarget = new System.Windows.Forms.ComboBox();
            this.grpWindowModelTree = new System.Windows.Forms.GroupBox();
            this.ckModelTreePanelVisible = new System.Windows.Forms.CheckBox();
            this.lblModelTreePanelPosition = new System.Windows.Forms.Label();
            this.cbModelTreePanelPosition = new System.Windows.Forms.ComboBox();
            this.lblModelTreePanelWidth = new System.Windows.Forms.Label();
            this.numModelTreePanelWidth = new System.Windows.Forms.NumericUpDown();
            this.grpWindowAttribute = new System.Windows.Forms.GroupBox();
            this.ckAttributePanelVisible = new System.Windows.Forms.CheckBox();
            this.lblAttributePanelPosition = new System.Windows.Forms.Label();
            this.cbAttributePanelPosition = new System.Windows.Forms.ComboBox();
            this.lblAttributePanelWidth = new System.Windows.Forms.Label();
            this.numAttributePanelWidth = new System.Windows.Forms.NumericUpDown();
            this.grpWindowSplit = new System.Windows.Forms.GroupBox();
            this.rbSplitTop = new System.Windows.Forms.RadioButton();
            this.rbSplitBottom = new System.Windows.Forms.RadioButton();
            this.rbSplitLeft = new System.Windows.Forms.RadioButton();
            this.rbSplitRight = new System.Windows.Forms.RadioButton();
            this.grpObserverFigure = new System.Windows.Forms.GroupBox();
            this.ckObserverShowFigure = new System.Windows.Forms.CheckBox();
            this.lblObserverFigureSize = new System.Windows.Forms.Label();
            this.numObserverFigureSize = new System.Windows.Forms.NumericUpDown();
            this.lblObserverFigureColor = new System.Windows.Forms.Label();
            this.btnObserverFigureColor = new System.Windows.Forms.Button();
            this.lblObserverRingColor = new System.Windows.Forms.Label();
            this.btnObserverRingColor = new System.Windows.Forms.Button();
            this.lblObserverNoseColor = new System.Windows.Forms.Label();
            this.btnObserverNoseColor = new System.Windows.Forms.Button();
            this.grpObserverResultColor = new System.Windows.Forms.GroupBox();
            this.lblObserverVisibleColor = new System.Windows.Forms.Label();
            this.btnObserverVisibleColor = new System.Windows.Forms.Button();
            this.lblObserverHiddenColor = new System.Windows.Forms.Label();
            this.btnObserverHiddenColor = new System.Windows.Forms.Button();
            this.grpObserverView = new System.Windows.Forms.GroupBox();
            this.lblObserverAngularStep = new System.Windows.Forms.Label();
            this.numObserverAngularStep = new System.Windows.Forms.NumericUpDown();
            this.lblObserverMaxDistance = new System.Windows.Forms.Label();
            this.numObserverMaxDistance = new System.Windows.Forms.NumericUpDown();
            this.lblObserverEyeHeight = new System.Windows.Forms.Label();
            this.numObserverEyeHeight = new System.Windows.Forms.NumericUpDown();
            this.grpDevInfo = new System.Windows.Forms.GroupBox();
            this.checkDebugInfo = new System.Windows.Forms.CheckBox();
            this.grpDevCache = new System.Windows.Forms.GroupBox();
            this.numericTemporaryCacheSize = new System.Windows.Forms.NumericUpDown();
            this.numericPermanentCacheSize = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.grpDevRendering = new System.Windows.Forms.GroupBox();
            this.checkAutomaticRenderingLimit = new System.Windows.Forms.CheckBox();
            this.numericRenderingLimitPerStep = new System.Windows.Forms.NumericUpDown();
            this.numericRenderingLimitInControl = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.grpToolbarRibbon = new System.Windows.Forms.GroupBox();
            this.cbRibbonTheme = new System.Windows.Forms.ComboBox();
            this.lblRibbonTheme = new System.Windows.Forms.Label();
            this.ckRibbonMode = new System.Windows.Forms.CheckBox();
            this.grpToolbarHome = new System.Windows.Forms.GroupBox();
            this.lblToolbarHomeRow = new System.Windows.Forms.Label();
            this.numToolbarHomeRow = new System.Windows.Forms.NumericUpDown();
            this.lblToolbarHomeOrder = new System.Windows.Forms.Label();
            this.numToolbarHomeOrder = new System.Windows.Forms.NumericUpDown();
            this.rbToolbarHomeRight = new System.Windows.Forms.RadioButton();
            this.rbToolbarHomeLeft = new System.Windows.Forms.RadioButton();
            this.rbToolbarHomeTop = new System.Windows.Forms.RadioButton();
            this.ckToolbarHome = new System.Windows.Forms.CheckBox();
            this.grpToolbarNote = new System.Windows.Forms.GroupBox();
            this.lblToolbarNoteRow = new System.Windows.Forms.Label();
            this.numToolbarNoteRow = new System.Windows.Forms.NumericUpDown();
            this.lblToolbarNoteOrder = new System.Windows.Forms.Label();
            this.numToolbarNoteOrder = new System.Windows.Forms.NumericUpDown();
            this.rbToolbarNoteRight = new System.Windows.Forms.RadioButton();
            this.rbToolbarNoteLeft = new System.Windows.Forms.RadioButton();
            this.rbToolbarNoteTop = new System.Windows.Forms.RadioButton();
            this.ckToolbarNote = new System.Windows.Forms.CheckBox();
            this.grpToolbarMeasure = new System.Windows.Forms.GroupBox();
            this.lblToolbarMeasureRow = new System.Windows.Forms.Label();
            this.numToolbarMeasureRow = new System.Windows.Forms.NumericUpDown();
            this.lblToolbarMeasureOrder = new System.Windows.Forms.Label();
            this.numToolbarMeasureOrder = new System.Windows.Forms.NumericUpDown();
            this.rbToolbarMeasureRight = new System.Windows.Forms.RadioButton();
            this.rbToolbarMeasureLeft = new System.Windows.Forms.RadioButton();
            this.rbToolbarMeasureTop = new System.Windows.Forms.RadioButton();
            this.ckToolbarMeasure = new System.Windows.Forms.CheckBox();
            this.grpToolbarSection = new System.Windows.Forms.GroupBox();
            this.lblToolbarSectionRow = new System.Windows.Forms.Label();
            this.numToolbarSectionRow = new System.Windows.Forms.NumericUpDown();
            this.lblToolbarSectionOrder = new System.Windows.Forms.Label();
            this.numToolbarSectionOrder = new System.Windows.Forms.NumericUpDown();
            this.rbToolbarSectionRight = new System.Windows.Forms.RadioButton();
            this.rbToolbarSectionLeft = new System.Windows.Forms.RadioButton();
            this.rbToolbarSectionTop = new System.Windows.Forms.RadioButton();
            this.ckToolbarSection = new System.Windows.Forms.CheckBox();
            this.grpToolbarSnapshot = new System.Windows.Forms.GroupBox();
            this.lblToolbarSnapshotRow = new System.Windows.Forms.Label();
            this.numToolbarSnapshotRow = new System.Windows.Forms.NumericUpDown();
            this.lblToolbarSnapshotOrder = new System.Windows.Forms.Label();
            this.numToolbarSnapshotOrder = new System.Windows.Forms.NumericUpDown();
            this.rbToolbarSnapshotRight = new System.Windows.Forms.RadioButton();
            this.rbToolbarSnapshotLeft = new System.Windows.Forms.RadioButton();
            this.rbToolbarSnapshotTop = new System.Windows.Forms.RadioButton();
            this.ckToolbarSnapshot = new System.Windows.Forms.CheckBox();
            this.grpToolbarDecal = new System.Windows.Forms.GroupBox();
            this.lblToolbarDecalRow = new System.Windows.Forms.Label();
            this.numToolbarDecalRow = new System.Windows.Forms.NumericUpDown();
            this.lblToolbarDecalOrder = new System.Windows.Forms.Label();
            this.numToolbarDecalOrder = new System.Windows.Forms.NumericUpDown();
            this.rbToolbarDecalRight = new System.Windows.Forms.RadioButton();
            this.rbToolbarDecalLeft = new System.Windows.Forms.RadioButton();
            this.rbToolbarDecalTop = new System.Windows.Forms.RadioButton();
            this.ckToolbarDecal = new System.Windows.Forms.CheckBox();
            this.grpToolbarPrimitive = new System.Windows.Forms.GroupBox();
            this.lblToolbarPrimitiveRow = new System.Windows.Forms.Label();
            this.numToolbarPrimitiveRow = new System.Windows.Forms.NumericUpDown();
            this.lblToolbarPrimitiveOrder = new System.Windows.Forms.Label();
            this.numToolbarPrimitiveOrder = new System.Windows.Forms.NumericUpDown();
            this.rbToolbarPrimitiveRight = new System.Windows.Forms.RadioButton();
            this.rbToolbarPrimitiveLeft = new System.Windows.Forms.RadioButton();
            this.rbToolbarPrimitiveTop = new System.Windows.Forms.RadioButton();
            this.ckToolbarPrimitive = new System.Windows.Forms.CheckBox();
            this.grpToolbarSelectionBox = new System.Windows.Forms.GroupBox();
            this.lblToolbarSelectionBoxRow = new System.Windows.Forms.Label();
            this.numToolbarSelectionBoxRow = new System.Windows.Forms.NumericUpDown();
            this.lblToolbarSelectionBoxOrder = new System.Windows.Forms.Label();
            this.numToolbarSelectionBoxOrder = new System.Windows.Forms.NumericUpDown();
            this.rbToolbarSelectionBoxRight = new System.Windows.Forms.RadioButton();
            this.rbToolbarSelectionBoxLeft = new System.Windows.Forms.RadioButton();
            this.rbToolbarSelectionBoxTop = new System.Windows.Forms.RadioButton();
            this.ckToolbarSelectionBox = new System.Windows.Forms.CheckBox();
            this.grpToolbarZone = new System.Windows.Forms.GroupBox();
            this.lblToolbarZoneRow = new System.Windows.Forms.Label();
            this.numToolbarZoneRow = new System.Windows.Forms.NumericUpDown();
            this.lblToolbarZoneOrder = new System.Windows.Forms.Label();
            this.numToolbarZoneOrder = new System.Windows.Forms.NumericUpDown();
            this.rbToolbarZoneRight = new System.Windows.Forms.RadioButton();
            this.rbToolbarZoneLeft = new System.Windows.Forms.RadioButton();
            this.rbToolbarZoneTop = new System.Windows.Forms.RadioButton();
            this.ckToolbarZone = new System.Windows.Forms.CheckBox();
            this.grpToolbarEffect = new System.Windows.Forms.GroupBox();
            this.lblToolbarEffectRow = new System.Windows.Forms.Label();
            this.numToolbarEffectRow = new System.Windows.Forms.NumericUpDown();
            this.lblToolbarEffectOrder = new System.Windows.Forms.Label();
            this.numToolbarEffectOrder = new System.Windows.Forms.NumericUpDown();
            this.rbToolbarEffectRight = new System.Windows.Forms.RadioButton();
            this.rbToolbarEffectLeft = new System.Windows.Forms.RadioButton();
            this.rbToolbarEffectTop = new System.Windows.Forms.RadioButton();
            this.ckToolbarEffect = new System.Windows.Forms.CheckBox();
            this.grpToolbarObserver = new System.Windows.Forms.GroupBox();
            this.lblToolbarObserverRow = new System.Windows.Forms.Label();
            this.numToolbarObserverRow = new System.Windows.Forms.NumericUpDown();
            this.lblToolbarObserverOrder = new System.Windows.Forms.Label();
            this.numToolbarObserverOrder = new System.Windows.Forms.NumericUpDown();
            this.rbToolbarObserverRight = new System.Windows.Forms.RadioButton();
            this.rbToolbarObserverLeft = new System.Windows.Forms.RadioButton();
            this.rbToolbarObserverTop = new System.Windows.Forms.RadioButton();
            this.ckToolbarObserver = new System.Windows.Forms.CheckBox();
            this.grpApply = new System.Windows.Forms.GroupBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpModel = new System.Windows.Forms.GroupBox();
            this.btnOpenModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tpHome.SuspendLayout();
            this.grpHomeModel.SuspendLayout();
            this.grpHomeView.SuspendLayout();
            this.grpHomeCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraInitialFov)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraBoundingBoxMaxZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraBoundingBoxMaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraBoundingBoxMaxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraBoundingBoxMinZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraBoundingBoxMinY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraBoundingBoxMinX)).BeginInit();
            this.grpHomeSelection.SuspendLayout();
            this.grpHomeBackground.SuspendLayout();
            this.grpHomeSnap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSnapCylinderAxisSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSnapPointSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSnapPlaneSize)).BeginInit();
            this.grpSpaceSelectionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectionBoxStrokeThickness)).BeginInit();
            this.grpSpaceZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZoneFaceOpacity)).BeginInit();
            this.tpView.SuspendLayout();
            this.grpViewView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRenderScale)).BeginInit();
            this.grpViewZoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZoomRatio)).BeginInit();
            this.grpViewCube.SuspendLayout();
            this.grpViewCubeFace.SuspendLayout();
            this.grpViewCommand.SuspendLayout();
            this.grpViewLight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numShininess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecularIntensity)).BeginInit();
            this.grpViewZoomBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZoomBoxStrokeThickness)).BeginInit();
            this.tpInput.SuspendLayout();
            this.grpWindowModelingControl.SuspendLayout();
            this.grpMcSize.SuspendLayout();
            this.grpMcPosition.SuspendLayout();
            this.grpMcColor.SuspendLayout();
            this.grpMcBackground.SuspendLayout();
            this.grpMcBackgroundColor.SuspendLayout();
            this.grpMcOrientation.SuspendLayout();
            this.grpInputSensitivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInputOrbitSens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputPanSens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputZoomSens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputRollSens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputLookSens)).BeginInit();
            this.grpInputSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInputWalkSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputWalkBoost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputFlySpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputFlyBoost)).BeginInit();
            this.grpInputClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInputClickDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputLongPress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputClickTolerance)).BeginInit();
            this.tpNote.SuspendLayout();
            this.grpNoteStyle.SuspendLayout();
            this.grpNoteSymbol.SuspendLayout();
            this.tpMeasure.SuspendLayout();
            this.grpMeasureOption.SuspendLayout();
            this.grpMeasureStyle.SuspendLayout();
            this.grpMeasureSnap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMeasureSnapCylinderAxisSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeasureSnapPointSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeasureSnapPlaneSize)).BeginInit();
            this.tpSection.SuspendLayout();
            this.grpSectionStyle.SuspendLayout();
            this.grpSectionCap.SuspendLayout();
            this.tpDecal.SuspendLayout();
            this.tpSpace.SuspendLayout();
            this.grpDecal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDecalRotationAngleStep)).BeginInit();
            this.tpFrame.SuspendLayout();
            this.grpFrameView.SuspendLayout();
            this.grpFrameColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameLineThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFramePlaneThickness)).BeginInit();
            this.tpPreSelect.SuspendLayout();
            this.grpPreSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPreSelectDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreSelectLimit)).BeginInit();
            this.tpWindow.SuspendLayout();
            this.grpWindowModelTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numModelTreePanelWidth)).BeginInit();
            this.grpWindowAttribute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAttributePanelWidth)).BeginInit();
            this.grpWindowSplit.SuspendLayout();
            this.tpObserver.SuspendLayout();
            this.grpObserverFigure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numObserverFigureSize)).BeginInit();
            this.grpObserverResultColor.SuspendLayout();
            this.grpObserverView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numObserverAngularStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numObserverMaxDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numObserverEyeHeight)).BeginInit();
            this.tpDevTools.SuspendLayout();
            this.grpDevInfo.SuspendLayout();
            this.grpDevCache.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTemporaryCacheSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPermanentCacheSize)).BeginInit();
            this.grpDevRendering.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRenderingLimitPerStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRenderingLimitInControl)).BeginInit();
            this.tpToolbar.SuspendLayout();
            this.grpToolbarRibbon.SuspendLayout();
            this.grpToolbarHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarHomeRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarHomeOrder)).BeginInit();
            this.grpToolbarNote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarNoteRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarNoteOrder)).BeginInit();
            this.grpToolbarMeasure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarMeasureRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarMeasureOrder)).BeginInit();
            this.grpToolbarSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarSectionRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarSectionOrder)).BeginInit();
            this.grpToolbarSnapshot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarSnapshotRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarSnapshotOrder)).BeginInit();
            this.grpToolbarDecal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarDecalRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarDecalOrder)).BeginInit();
            this.grpToolbarPrimitive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarPrimitiveRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarPrimitiveOrder)).BeginInit();
            this.grpToolbarSelectionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarSelectionBoxRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarSelectionBoxOrder)).BeginInit();
            this.grpToolbarZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarZoneRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarZoneOrder)).BeginInit();
            this.grpToolbarEffect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarEffectRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarEffectOrder)).BeginInit();
            this.grpToolbarObserver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarObserverRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarObserverOrder)).BeginInit();
            this.grpApply.SuspendLayout();
            this.grpModel.SuspendLayout();
            this.SuspendLayout();
            //
            // splitContainer1
            //
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            //
            // splitContainer1.Panel1
            //
            this.splitContainer1.Panel1.Controls.Add(this.tabSettings);
            this.splitContainer1.Panel1.Controls.Add(this.grpApply);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Controls.Add(this.grpModel);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 800);
            this.splitContainer1.SplitterDistance = 676;
            this.splitContainer1.TabIndex = 0;
            //
            // tabSettings
            //
            this.tabSettings.Controls.Add(this.tpHome);
            this.tabSettings.Controls.Add(this.tpView);
            this.tabSettings.Controls.Add(this.tpSpace);
            this.tabSettings.Controls.Add(this.tpWindow);
            this.tabSettings.Controls.Add(this.tpToolbar);
            this.tabSettings.Controls.Add(this.tpInput);
            this.tabSettings.Controls.Add(this.tpPreSelect);
            this.tabSettings.Controls.Add(this.tpNote);
            this.tabSettings.Controls.Add(this.tpMeasure);
            this.tabSettings.Controls.Add(this.tpSection);
            this.tabSettings.Controls.Add(this.tpDecal);
            this.tabSettings.Controls.Add(this.tpFrame);
            this.tabSettings.Controls.Add(this.tpObserver);
            this.tabSettings.Controls.Add(this.tpDevTools);
            this.tabSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSettings.Location = new System.Drawing.Point(0, 58);
            this.tabSettings.Multiline = true;
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(676, 658);
            this.tabSettings.TabIndex = 0;
            //
            // tpHome
            //
            this.tpHome.AutoScroll = true;
            this.tpHome.Controls.Add(this.grpHomeSnap);
            this.tpHome.Controls.Add(this.grpHomeBackground);
            this.tpHome.Controls.Add(this.grpHomeSelection);
            this.tpHome.Controls.Add(this.grpHomeCamera);
            this.tpHome.Controls.Add(this.grpHomeView);
            this.tpHome.Controls.Add(this.grpHomeModel);
            this.tpHome.Location = new System.Drawing.Point(4, 40);
            this.tpHome.Name = "tpHome";
            this.tpHome.Padding = new System.Windows.Forms.Padding(3);
            this.tpHome.Size = new System.Drawing.Size(668, 614);
            this.tpHome.TabIndex = 0;
            this.tpHome.Text = "기본";
            this.tpHome.UseVisualStyleBackColor = true;
            //
            // grpSpaceZone
            //
            this.grpSpaceZone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSpaceZone.Controls.Add(this.numZoneFaceOpacity);
            this.grpSpaceZone.Controls.Add(this.lblZoneFaceOpacity);
            this.grpSpaceZone.Controls.Add(this.btnZoneLineColor);
            this.grpSpaceZone.Controls.Add(this.lblZoneLineColor);
            this.grpSpaceZone.Controls.Add(this.btnZoneFaceColor);
            this.grpSpaceZone.Controls.Add(this.lblZoneFaceColor);
            this.grpSpaceZone.Location = new System.Drawing.Point(6, 188);
            this.grpSpaceZone.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpSpaceZone.Name = "grpSpaceZone";
            this.grpSpaceZone.Size = new System.Drawing.Size(590, 76);
            this.grpSpaceZone.TabIndex = 1;
            this.grpSpaceZone.TabStop = false;
            this.grpSpaceZone.Text = "다면체 공간";
            //
            // numZoneFaceOpacity
            //
            this.numZoneFaceOpacity.Location = new System.Drawing.Point(147, 53);
            this.numZoneFaceOpacity.Name = "numZoneFaceOpacity";
            this.numZoneFaceOpacity.Size = new System.Drawing.Size(120, 21);
            this.numZoneFaceOpacity.TabIndex = 5;
            //
            // lblZoneFaceOpacity
            //
            this.lblZoneFaceOpacity.AutoSize = true;
            this.lblZoneFaceOpacity.Location = new System.Drawing.Point(15, 57);
            this.lblZoneFaceOpacity.Name = "lblZoneFaceOpacity";
            this.lblZoneFaceOpacity.Size = new System.Drawing.Size(93, 12);
            this.lblZoneFaceOpacity.TabIndex = 4;
            this.lblZoneFaceOpacity.Text = "경계면 불투명도";
            //
            // btnZoneLineColor
            //
            this.btnZoneLineColor.Location = new System.Drawing.Point(442, 25);
            this.btnZoneLineColor.Name = "btnZoneLineColor";
            this.btnZoneLineColor.Size = new System.Drawing.Size(120, 23);
            this.btnZoneLineColor.TabIndex = 3;
            this.btnZoneLineColor.UseVisualStyleBackColor = false;
            this.btnZoneLineColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // lblZoneLineColor
            //
            this.lblZoneLineColor.AutoSize = true;
            this.lblZoneLineColor.Location = new System.Drawing.Point(293, 30);
            this.lblZoneLineColor.Name = "lblZoneLineColor";
            this.lblZoneLineColor.Size = new System.Drawing.Size(69, 12);
            this.lblZoneLineColor.TabIndex = 2;
            this.lblZoneLineColor.Text = "경계선 색상";
            //
            // btnZoneFaceColor
            //
            this.btnZoneFaceColor.Location = new System.Drawing.Point(147, 25);
            this.btnZoneFaceColor.Name = "btnZoneFaceColor";
            this.btnZoneFaceColor.Size = new System.Drawing.Size(120, 23);
            this.btnZoneFaceColor.TabIndex = 1;
            this.btnZoneFaceColor.UseVisualStyleBackColor = false;
            this.btnZoneFaceColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // lblZoneFaceColor
            //
            this.lblZoneFaceColor.AutoSize = true;
            this.lblZoneFaceColor.Location = new System.Drawing.Point(15, 30);
            this.lblZoneFaceColor.Name = "lblZoneFaceColor";
            this.lblZoneFaceColor.Size = new System.Drawing.Size(69, 12);
            this.lblZoneFaceColor.TabIndex = 0;
            this.lblZoneFaceColor.Text = "경계면 색상";
            //
            // grpSpaceSelectionBox
            //
            this.grpSpaceSelectionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSpaceSelectionBox.Controls.Add(this.cbSelectionBoxStrokePattern);
            this.grpSpaceSelectionBox.Controls.Add(this.label101);
            this.grpSpaceSelectionBox.Controls.Add(this.cbSelectionBoxTextSize);
            this.grpSpaceSelectionBox.Controls.Add(this.label104);
            this.grpSpaceSelectionBox.Controls.Add(this.btnSelectionBoxTextColor);
            this.grpSpaceSelectionBox.Controls.Add(this.label103);
            this.grpSpaceSelectionBox.Controls.Add(this.numSelectionBoxStrokeThickness);
            this.grpSpaceSelectionBox.Controls.Add(this.label102);
            this.grpSpaceSelectionBox.Controls.Add(this.btnSelectionBoxHighlightedStrokeColor);
            this.grpSpaceSelectionBox.Controls.Add(this.label100);
            this.grpSpaceSelectionBox.Controls.Add(this.btnSelectionBoxDefaultStrokeColor);
            this.grpSpaceSelectionBox.Controls.Add(this.label99);
            this.grpSpaceSelectionBox.Controls.Add(this.btnSelectionBoxSelectedStrokeColor);
            this.grpSpaceSelectionBox.Controls.Add(this.label98);
            this.grpSpaceSelectionBox.Controls.Add(this.btnSelectionBoxSelectedFillColor);
            this.grpSpaceSelectionBox.Controls.Add(this.label97);
            this.grpSpaceSelectionBox.Controls.Add(this.btnSelectionBoxHighlightedFillColor);
            this.grpSpaceSelectionBox.Controls.Add(this.label96);
            this.grpSpaceSelectionBox.Controls.Add(this.btnSelectionBoxDefaultFillColor);
            this.grpSpaceSelectionBox.Controls.Add(this.label95);
            this.grpSpaceSelectionBox.Location = new System.Drawing.Point(6, 6);
            this.grpSpaceSelectionBox.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpSpaceSelectionBox.Name = "grpSpaceSelectionBox";
            this.grpSpaceSelectionBox.Size = new System.Drawing.Size(590, 176);
            this.grpSpaceSelectionBox.TabIndex = 0;
            this.grpSpaceSelectionBox.TabStop = false;
            this.grpSpaceSelectionBox.Text = "3D 선택 상자";
            //
            // cbSelectionBoxStrokePattern
            //
            this.cbSelectionBoxStrokePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectionBoxStrokePattern.FormattingEnabled = true;
            this.cbSelectionBoxStrokePattern.Location = new System.Drawing.Point(147, 112);
            this.cbSelectionBoxStrokePattern.Name = "cbSelectionBoxStrokePattern";
            this.cbSelectionBoxStrokePattern.Size = new System.Drawing.Size(120, 20);
            this.cbSelectionBoxStrokePattern.TabIndex = 56;
            //
            // label101
            //
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(22, 145);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(57, 12);
            this.label101.TabIndex = 55;
            this.label101.Text = "글자 크기";
            //
            // cbSelectionBoxTextSize
            //
            this.cbSelectionBoxTextSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectionBoxTextSize.FormattingEnabled = true;
            this.cbSelectionBoxTextSize.Location = new System.Drawing.Point(147, 142);
            this.cbSelectionBoxTextSize.Name = "cbSelectionBoxTextSize";
            this.cbSelectionBoxTextSize.Size = new System.Drawing.Size(120, 20);
            this.cbSelectionBoxTextSize.TabIndex = 54;
            //
            // label104
            //
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(22, 115);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(85, 12);
            this.label104.TabIndex = 53;
            this.label104.Text = "상자 라인 유형";
            //
            // btnSelectionBoxTextColor
            //
            this.btnSelectionBoxTextColor.Location = new System.Drawing.Point(442, 140);
            this.btnSelectionBoxTextColor.Name = "btnSelectionBoxTextColor";
            this.btnSelectionBoxTextColor.Size = new System.Drawing.Size(120, 23);
            this.btnSelectionBoxTextColor.TabIndex = 52;
            this.btnSelectionBoxTextColor.UseVisualStyleBackColor = false;
            this.btnSelectionBoxTextColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label103
            //
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(293, 145);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(57, 12);
            this.label103.TabIndex = 51;
            this.label103.Text = "글자 색상";
            //
            // numSelectionBoxStrokeThickness
            //
            this.numSelectionBoxStrokeThickness.Location = new System.Drawing.Point(442, 111);
            this.numSelectionBoxStrokeThickness.Maximum = new decimal(new int[] {
            104,
            0,
            0,
            0});
            this.numSelectionBoxStrokeThickness.Name = "numSelectionBoxStrokeThickness";
            this.numSelectionBoxStrokeThickness.Size = new System.Drawing.Size(120, 21);
            this.numSelectionBoxStrokeThickness.TabIndex = 50;
            this.numSelectionBoxStrokeThickness.ThousandsSeparator = true;
            //
            // label102
            //
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(293, 115);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(85, 12);
            this.label102.TabIndex = 49;
            this.label102.Text = "상자 라인 두께";
            //
            // btnSelectionBoxHighlightedStrokeColor
            //
            this.btnSelectionBoxHighlightedStrokeColor.Location = new System.Drawing.Point(442, 50);
            this.btnSelectionBoxHighlightedStrokeColor.Name = "btnSelectionBoxHighlightedStrokeColor";
            this.btnSelectionBoxHighlightedStrokeColor.Size = new System.Drawing.Size(120, 23);
            this.btnSelectionBoxHighlightedStrokeColor.TabIndex = 46;
            this.btnSelectionBoxHighlightedStrokeColor.UseVisualStyleBackColor = false;
            this.btnSelectionBoxHighlightedStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label100
            //
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(293, 55);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(85, 12);
            this.label100.TabIndex = 45;
            this.label100.Text = "강조 라인 색상";
            //
            // btnSelectionBoxDefaultStrokeColor
            //
            this.btnSelectionBoxDefaultStrokeColor.Location = new System.Drawing.Point(442, 20);
            this.btnSelectionBoxDefaultStrokeColor.Name = "btnSelectionBoxDefaultStrokeColor";
            this.btnSelectionBoxDefaultStrokeColor.Size = new System.Drawing.Size(120, 23);
            this.btnSelectionBoxDefaultStrokeColor.TabIndex = 44;
            this.btnSelectionBoxDefaultStrokeColor.UseVisualStyleBackColor = false;
            this.btnSelectionBoxDefaultStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label99
            //
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(293, 25);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(85, 12);
            this.label99.TabIndex = 43;
            this.label99.Text = "기본 라인 색상";
            //
            // btnSelectionBoxSelectedStrokeColor
            //
            this.btnSelectionBoxSelectedStrokeColor.Location = new System.Drawing.Point(442, 80);
            this.btnSelectionBoxSelectedStrokeColor.Name = "btnSelectionBoxSelectedStrokeColor";
            this.btnSelectionBoxSelectedStrokeColor.Size = new System.Drawing.Size(120, 23);
            this.btnSelectionBoxSelectedStrokeColor.TabIndex = 42;
            this.btnSelectionBoxSelectedStrokeColor.UseVisualStyleBackColor = false;
            this.btnSelectionBoxSelectedStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label98
            //
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(293, 85);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(85, 12);
            this.label98.TabIndex = 41;
            this.label98.Text = "선택 라인 색상";
            //
            // btnSelectionBoxSelectedFillColor
            //
            this.btnSelectionBoxSelectedFillColor.Location = new System.Drawing.Point(147, 80);
            this.btnSelectionBoxSelectedFillColor.Name = "btnSelectionBoxSelectedFillColor";
            this.btnSelectionBoxSelectedFillColor.Size = new System.Drawing.Size(120, 23);
            this.btnSelectionBoxSelectedFillColor.TabIndex = 40;
            this.btnSelectionBoxSelectedFillColor.UseVisualStyleBackColor = false;
            this.btnSelectionBoxSelectedFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label97
            //
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(22, 85);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(97, 12);
            this.label97.TabIndex = 39;
            this.label97.Text = "선택 채우기 색상";
            //
            // btnSelectionBoxHighlightedFillColor
            //
            this.btnSelectionBoxHighlightedFillColor.Location = new System.Drawing.Point(147, 50);
            this.btnSelectionBoxHighlightedFillColor.Name = "btnSelectionBoxHighlightedFillColor";
            this.btnSelectionBoxHighlightedFillColor.Size = new System.Drawing.Size(120, 23);
            this.btnSelectionBoxHighlightedFillColor.TabIndex = 38;
            this.btnSelectionBoxHighlightedFillColor.UseVisualStyleBackColor = false;
            this.btnSelectionBoxHighlightedFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label96
            //
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(22, 55);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(97, 12);
            this.label96.TabIndex = 37;
            this.label96.Text = "강조 채우기 색상";
            //
            // btnSelectionBoxDefaultFillColor
            //
            this.btnSelectionBoxDefaultFillColor.Location = new System.Drawing.Point(147, 20);
            this.btnSelectionBoxDefaultFillColor.Name = "btnSelectionBoxDefaultFillColor";
            this.btnSelectionBoxDefaultFillColor.Size = new System.Drawing.Size(120, 23);
            this.btnSelectionBoxDefaultFillColor.TabIndex = 36;
            this.btnSelectionBoxDefaultFillColor.UseVisualStyleBackColor = false;
            this.btnSelectionBoxDefaultFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label95
            //
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(22, 25);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(97, 12);
            this.label95.TabIndex = 35;
            this.label95.Text = "기본 채우기 색상";
            //
            // grpHomeSnap
            //
            this.grpHomeSnap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHomeSnap.Controls.Add(this.btnSnapHighlightColor);
            this.grpHomeSnap.Controls.Add(this.btnSnapColor);
            this.grpHomeSnap.Controls.Add(this.label83);
            this.grpHomeSnap.Controls.Add(this.label82);
            this.grpHomeSnap.Controls.Add(this.numSnapCylinderAxisSize);
            this.grpHomeSnap.Controls.Add(this.numSnapPointSize);
            this.grpHomeSnap.Controls.Add(this.numSnapPlaneSize);
            this.grpHomeSnap.Controls.Add(this.label81);
            this.grpHomeSnap.Controls.Add(this.label80);
            this.grpHomeSnap.Controls.Add(this.label79);
            this.grpHomeSnap.Location = new System.Drawing.Point(6, 748);
            this.grpHomeSnap.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpHomeSnap.Name = "grpHomeSnap";
            this.grpHomeSnap.Size = new System.Drawing.Size(590, 112);
            this.grpHomeSnap.TabIndex = 18;
            this.grpHomeSnap.TabStop = false;
            this.grpHomeSnap.Text = "스냅 표식";
            //
            // btnSnapHighlightColor
            //
            this.btnSnapHighlightColor.Location = new System.Drawing.Point(442, 50);
            this.btnSnapHighlightColor.Name = "btnSnapHighlightColor";
            this.btnSnapHighlightColor.Size = new System.Drawing.Size(120, 23);
            this.btnSnapHighlightColor.TabIndex = 35;
            this.btnSnapHighlightColor.UseVisualStyleBackColor = false;
            this.btnSnapHighlightColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnSnapColor
            //
            this.btnSnapColor.Location = new System.Drawing.Point(442, 20);
            this.btnSnapColor.Name = "btnSnapColor";
            this.btnSnapColor.Size = new System.Drawing.Size(120, 23);
            this.btnSnapColor.TabIndex = 34;
            this.btnSnapColor.UseVisualStyleBackColor = false;
            this.btnSnapColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label83
            //
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(294, 50);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(113, 12);
            this.label83.TabIndex = 7;
            this.label83.Text = "스냅 형상 강조 색상";
            //
            // label82
            //
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(294, 25);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(85, 12);
            this.label82.TabIndex = 6;
            this.label82.Text = "스냅 형상 색상";
            //
            // numSnapCylinderAxisSize
            //
            this.numSnapCylinderAxisSize.DecimalPlaces = 1;
            this.numSnapCylinderAxisSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSnapCylinderAxisSize.Location = new System.Drawing.Point(147, 78);
            this.numSnapCylinderAxisSize.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numSnapCylinderAxisSize.Name = "numSnapCylinderAxisSize";
            this.numSnapCylinderAxisSize.Size = new System.Drawing.Size(120, 21);
            this.numSnapCylinderAxisSize.TabIndex = 5;
            //
            // numSnapPointSize
            //
            this.numSnapPointSize.DecimalPlaces = 1;
            this.numSnapPointSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSnapPointSize.Location = new System.Drawing.Point(147, 48);
            this.numSnapPointSize.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numSnapPointSize.Name = "numSnapPointSize";
            this.numSnapPointSize.Size = new System.Drawing.Size(120, 21);
            this.numSnapPointSize.TabIndex = 4;
            //
            // numSnapPlaneSize
            //
            this.numSnapPlaneSize.DecimalPlaces = 1;
            this.numSnapPlaneSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSnapPlaneSize.Location = new System.Drawing.Point(147, 20);
            this.numSnapPlaneSize.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numSnapPlaneSize.Name = "numSnapPlaneSize";
            this.numSnapPlaneSize.Size = new System.Drawing.Size(120, 21);
            this.numSnapPlaneSize.TabIndex = 3;
            //
            // label81
            //
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(22, 50);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(73, 12);
            this.label81.TabIndex = 2;
            this.label81.Text = "스냅 점 크기";
            //
            // label80
            //
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(22, 25);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(85, 12);
            this.label80.TabIndex = 1;
            this.label80.Text = "스냅 평면 크기";
            //
            // label79
            //
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(22, 75);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(101, 12);
            this.label79.TabIndex = 0;
            this.label79.Text = "스냅 원통 축 크기";
            //
            // grpHomeBackground
            //
            this.grpHomeBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHomeBackground.Controls.Add(this.label3);
            this.grpHomeBackground.Controls.Add(this.label2);
            this.grpHomeBackground.Controls.Add(this.label1);
            this.grpHomeBackground.Controls.Add(this.txtGradientVectorY);
            this.grpHomeBackground.Controls.Add(this.txtGradientVectorX);
            this.grpHomeBackground.Controls.Add(this.txtGradientPosition3);
            this.grpHomeBackground.Controls.Add(this.txtGradientPosition2);
            this.grpHomeBackground.Controls.Add(this.txtGradientPosition1);
            this.grpHomeBackground.Controls.Add(this.cbBackgroundColorCount);
            this.grpHomeBackground.Controls.Add(this.label30);
            this.grpHomeBackground.Controls.Add(this.label29);
            this.grpHomeBackground.Controls.Add(this.labelGradientVector);
            this.grpHomeBackground.Controls.Add(this.cbBackgroundMode);
            this.grpHomeBackground.Controls.Add(this.labelBackgroundMode);
            this.grpHomeBackground.Controls.Add(this.btnBackgroundColor3);
            this.grpHomeBackground.Controls.Add(this.btnBackgroundColor2);
            this.grpHomeBackground.Controls.Add(this.btnBackgroundColor1);
            this.grpHomeBackground.Controls.Add(this.labelBackgroundColor);
            this.grpHomeBackground.Location = new System.Drawing.Point(6, 571);
            this.grpHomeBackground.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpHomeBackground.Name = "grpHomeBackground";
            this.grpHomeBackground.Size = new System.Drawing.Size(590, 171);
            this.grpHomeBackground.TabIndex = 17;
            this.grpHomeBackground.TabStop = false;
            this.grpHomeBackground.Text = "배경";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "(0.0 ~ 1.0)";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(488, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "(0.0 ~ 1.0)";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(488, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "(0.0 ~ 1.0)";
            //
            // txtGradientVectorY
            //
            this.txtGradientVectorY.Location = new System.Drawing.Point(382, 139);
            this.txtGradientVectorY.Name = "txtGradientVectorY";
            this.txtGradientVectorY.Size = new System.Drawing.Size(102, 21);
            this.txtGradientVectorY.TabIndex = 30;
            //
            // txtGradientVectorX
            //
            this.txtGradientVectorX.Location = new System.Drawing.Point(256, 139);
            this.txtGradientVectorX.Name = "txtGradientVectorX";
            this.txtGradientVectorX.Size = new System.Drawing.Size(102, 21);
            this.txtGradientVectorX.TabIndex = 29;
            //
            // txtGradientPosition3
            //
            this.txtGradientPosition3.Location = new System.Drawing.Point(364, 110);
            this.txtGradientPosition3.Name = "txtGradientPosition3";
            this.txtGradientPosition3.Size = new System.Drawing.Size(121, 21);
            this.txtGradientPosition3.TabIndex = 28;
            //
            // txtGradientPosition2
            //
            this.txtGradientPosition2.Location = new System.Drawing.Point(363, 81);
            this.txtGradientPosition2.Name = "txtGradientPosition2";
            this.txtGradientPosition2.Size = new System.Drawing.Size(121, 21);
            this.txtGradientPosition2.TabIndex = 27;
            //
            // txtGradientPosition1
            //
            this.txtGradientPosition1.Location = new System.Drawing.Point(363, 52);
            this.txtGradientPosition1.Name = "txtGradientPosition1";
            this.txtGradientPosition1.Size = new System.Drawing.Size(121, 21);
            this.txtGradientPosition1.TabIndex = 26;
            //
            // cbBackgroundColorCount
            //
            this.cbBackgroundColorCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBackgroundColorCount.FormattingEnabled = true;
            this.cbBackgroundColorCount.Location = new System.Drawing.Point(364, 26);
            this.cbBackgroundColorCount.Name = "cbBackgroundColorCount";
            this.cbBackgroundColorCount.Size = new System.Drawing.Size(120, 20);
            this.cbBackgroundColorCount.TabIndex = 25;
            this.cbBackgroundColorCount.SelectedIndexChanged += new System.EventHandler(this.cbBackgroundColorCount_SelectedIndexChanged);
            //
            // label30
            //
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(366, 143);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(13, 12);
            this.label30.TabIndex = 24;
            this.label30.Text = "Y";
            //
            // label29
            //
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(237, 143);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(13, 12);
            this.label29.TabIndex = 23;
            this.label29.Text = "X";
            //
            // labelGradientVector
            //
            this.labelGradientVector.AutoSize = true;
            this.labelGradientVector.Location = new System.Drawing.Point(22, 141);
            this.labelGradientVector.Name = "labelGradientVector";
            this.labelGradientVector.Size = new System.Drawing.Size(121, 12);
            this.labelGradientVector.TabIndex = 22;
            this.labelGradientVector.Text = "선형 그라데이션 벡터";
            //
            // cbBackgroundMode
            //
            this.cbBackgroundMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBackgroundMode.FormattingEnabled = true;
            this.cbBackgroundMode.Location = new System.Drawing.Point(238, 26);
            this.cbBackgroundMode.Name = "cbBackgroundMode";
            this.cbBackgroundMode.Size = new System.Drawing.Size(120, 20);
            this.cbBackgroundMode.TabIndex = 6;
            this.cbBackgroundMode.SelectedIndexChanged += new System.EventHandler(this.cbBackgroundMode_SelectedIndexChanged);
            //
            // labelBackgroundMode
            //
            this.labelBackgroundMode.AutoSize = true;
            this.labelBackgroundMode.Location = new System.Drawing.Point(22, 29);
            this.labelBackgroundMode.Name = "labelBackgroundMode";
            this.labelBackgroundMode.Size = new System.Drawing.Size(57, 12);
            this.labelBackgroundMode.TabIndex = 5;
            this.labelBackgroundMode.Text = "배경 유형";
            //
            // btnBackgroundColor3
            //
            this.btnBackgroundColor3.Location = new System.Drawing.Point(239, 110);
            this.btnBackgroundColor3.Name = "btnBackgroundColor3";
            this.btnBackgroundColor3.Size = new System.Drawing.Size(120, 23);
            this.btnBackgroundColor3.Text = "배경색 3";
            this.btnBackgroundColor3.TabIndex = 13;
            this.btnBackgroundColor3.UseVisualStyleBackColor = false;
            this.btnBackgroundColor3.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnBackgroundColor2
            //
            this.btnBackgroundColor2.Location = new System.Drawing.Point(238, 81);
            this.btnBackgroundColor2.Name = "btnBackgroundColor2";
            this.btnBackgroundColor2.Size = new System.Drawing.Size(120, 23);
            this.btnBackgroundColor2.Text = "배경색 2";
            this.btnBackgroundColor2.TabIndex = 12;
            this.btnBackgroundColor2.UseVisualStyleBackColor = false;
            this.btnBackgroundColor2.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnBackgroundColor1
            //
            this.btnBackgroundColor1.Location = new System.Drawing.Point(238, 52);
            this.btnBackgroundColor1.Name = "btnBackgroundColor1";
            this.btnBackgroundColor1.Size = new System.Drawing.Size(120, 23);
            this.btnBackgroundColor1.Text = "배경색 1";
            this.btnBackgroundColor1.TabIndex = 8;
            this.btnBackgroundColor1.UseVisualStyleBackColor = false;
            this.btnBackgroundColor1.Click += new System.EventHandler(this.btnColor_Click);
            //
            // labelBackgroundColor
            //
            this.labelBackgroundColor.AutoSize = true;
            this.labelBackgroundColor.Location = new System.Drawing.Point(22, 57);
            this.labelBackgroundColor.Name = "labelBackgroundColor";
            this.labelBackgroundColor.Size = new System.Drawing.Size(41, 12);
            this.labelBackgroundColor.TabIndex = 7;
            this.labelBackgroundColor.Text = "배경색";
            //
            // grpHomeSelection
            //
            this.grpHomeSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHomeSelection.Controls.Add(this.label77);
            this.grpHomeSelection.Controls.Add(this.cbSelectionObject3DType);
            this.grpHomeSelection.Controls.Add(this.label78);
            this.grpHomeSelection.Controls.Add(this.ckSelectionOutline);
            this.grpHomeSelection.Controls.Add(this.btnSelectionOutlineColor);
            this.grpHomeSelection.Controls.Add(this.label28);
            this.grpHomeSelection.Controls.Add(this.comboXRaySelectionColor);
            this.grpHomeSelection.Controls.Add(this.label31);
            this.grpHomeSelection.Controls.Add(this.ckBoxSelectionFrontObjectOnly);
            this.grpHomeSelection.Controls.Add(this.btnSelectionBoxStrokeColor);
            this.grpHomeSelection.Controls.Add(this.btnSelectionBoxFillColor);
            this.grpHomeSelection.Controls.Add(this.btnSelectionColor);
            this.grpHomeSelection.Controls.Add(this.label23);
            this.grpHomeSelection.Location = new System.Drawing.Point(6, 402);
            this.grpHomeSelection.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpHomeSelection.Name = "grpHomeSelection";
            this.grpHomeSelection.Size = new System.Drawing.Size(590, 163);
            this.grpHomeSelection.TabIndex = 14;
            this.grpHomeSelection.TabStop = false;
            this.grpHomeSelection.Text = "선택";
            //
            // label77
            //
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(428, 110);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(151, 12);
            this.label77.TabIndex = 23;
            this.label77.Text = "(X-Ray, 플라스틱 모드 등)";
            //
            // cbSelectionObject3DType
            //
            this.cbSelectionObject3DType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectionObject3DType.FormattingEnabled = true;
            this.cbSelectionObject3DType.Location = new System.Drawing.Point(229, 107);
            this.cbSelectionObject3DType.Name = "cbSelectionObject3DType";
            this.cbSelectionObject3DType.Size = new System.Drawing.Size(193, 20);
            this.cbSelectionObject3DType.TabIndex = 22;
            //
            // label78
            //
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(22, 110);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(85, 12);
            this.label78.TabIndex = 21;
            this.label78.Text = "선택 가능 개체";
            //
            // ckSelectionOutline
            //
            this.ckSelectionOutline.AutoSize = true;
            this.ckSelectionOutline.Location = new System.Drawing.Point(24, 53);
            this.ckSelectionOutline.Name = "ckSelectionOutline";
            this.ckSelectionOutline.Size = new System.Drawing.Size(88, 16);
            this.ckSelectionOutline.TabIndex = 20;
            this.ckSelectionOutline.Text = "선택 외곽선";
            this.ckSelectionOutline.UseVisualStyleBackColor = true;
            //
            // btnSelectionOutlineColor
            //
            this.btnSelectionOutlineColor.Location = new System.Drawing.Point(229, 49);
            this.btnSelectionOutlineColor.Name = "btnSelectionOutlineColor";
            this.btnSelectionOutlineColor.Size = new System.Drawing.Size(110, 23);
            this.btnSelectionOutlineColor.Text = "선택 외곽선";
            this.btnSelectionOutlineColor.TabIndex = 19;
            this.btnSelectionOutlineColor.UseVisualStyleBackColor = false;
            this.btnSelectionOutlineColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label28
            //
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(428, 81);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(151, 12);
            this.label28.TabIndex = 18;
            this.label28.Text = "(X-Ray, 플라스틱 모드 등)";
            //
            // comboXRaySelectionColor
            //
            this.comboXRaySelectionColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboXRaySelectionColor.FormattingEnabled = true;
            this.comboXRaySelectionColor.Location = new System.Drawing.Point(229, 78);
            this.comboXRaySelectionColor.Name = "comboXRaySelectionColor";
            this.comboXRaySelectionColor.Size = new System.Drawing.Size(193, 20);
            this.comboXRaySelectionColor.TabIndex = 17;
            //
            // label31
            //
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(22, 84);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(157, 12);
            this.label31.TabIndex = 16;
            this.label31.Text = "전역 색상 모드 시 선택 색상";
            //
            // ckBoxSelectionFrontObjectOnly
            //
            this.ckBoxSelectionFrontObjectOnly.AutoSize = true;
            this.ckBoxSelectionFrontObjectOnly.Location = new System.Drawing.Point(24, 135);
            this.ckBoxSelectionFrontObjectOnly.Name = "ckBoxSelectionFrontObjectOnly";
            this.ckBoxSelectionFrontObjectOnly.Size = new System.Drawing.Size(198, 16);
            this.ckBoxSelectionFrontObjectOnly.TabIndex = 15;
            this.ckBoxSelectionFrontObjectOnly.Text = "맨 앞의 개체만 선택 (영역 선택)";
            this.ckBoxSelectionFrontObjectOnly.UseVisualStyleBackColor = true;
            //
            // btnSelectionBoxStrokeColor
            //
            this.btnSelectionBoxStrokeColor.Location = new System.Drawing.Point(461, 20);
            this.btnSelectionBoxStrokeColor.Name = "btnSelectionBoxStrokeColor";
            this.btnSelectionBoxStrokeColor.Size = new System.Drawing.Size(111, 23);
            this.btnSelectionBoxStrokeColor.Text = "드래그 영역 경계";
            this.btnSelectionBoxStrokeColor.TabIndex = 13;
            this.btnSelectionBoxStrokeColor.UseVisualStyleBackColor = false;
            this.btnSelectionBoxStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnSelectionBoxFillColor
            //
            this.btnSelectionBoxFillColor.Location = new System.Drawing.Point(345, 20);
            this.btnSelectionBoxFillColor.Name = "btnSelectionBoxFillColor";
            this.btnSelectionBoxFillColor.Size = new System.Drawing.Size(110, 23);
            this.btnSelectionBoxFillColor.Text = "드래그 영역";
            this.btnSelectionBoxFillColor.TabIndex = 12;
            this.btnSelectionBoxFillColor.UseVisualStyleBackColor = false;
            this.btnSelectionBoxFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnSelectionColor
            //
            this.btnSelectionColor.Location = new System.Drawing.Point(229, 20);
            this.btnSelectionColor.Name = "btnSelectionColor";
            this.btnSelectionColor.Size = new System.Drawing.Size(110, 23);
            this.btnSelectionColor.Text = "선택";
            this.btnSelectionColor.TabIndex = 8;
            this.btnSelectionColor.UseVisualStyleBackColor = false;
            this.btnSelectionColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label23
            //
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(22, 25);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(57, 12);
            this.label23.TabIndex = 7;
            this.label23.Text = "선택 색상";
            //
            // grpHomeCamera
            //
            this.grpHomeCamera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHomeCamera.Controls.Add(this.label5);
            this.grpHomeCamera.Controls.Add(this.numCameraInitialFov);
            this.grpHomeCamera.Controls.Add(this.numCameraBoundingBoxMaxZ);
            this.grpHomeCamera.Controls.Add(this.numCameraBoundingBoxMaxY);
            this.grpHomeCamera.Controls.Add(this.numCameraBoundingBoxMaxX);
            this.grpHomeCamera.Controls.Add(this.numCameraBoundingBoxMinZ);
            this.grpHomeCamera.Controls.Add(this.numCameraBoundingBoxMinY);
            this.grpHomeCamera.Controls.Add(this.numCameraBoundingBoxMinX);
            this.grpHomeCamera.Controls.Add(this.label24);
            this.grpHomeCamera.Controls.Add(this.label4);
            this.grpHomeCamera.Controls.Add(this.label25);
            this.grpHomeCamera.Controls.Add(this.label26);
            this.grpHomeCamera.Controls.Add(this.ckInitialCamera);
            this.grpHomeCamera.Location = new System.Drawing.Point(6, 211);
            this.grpHomeCamera.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpHomeCamera.Name = "grpHomeCamera";
            this.grpHomeCamera.Size = new System.Drawing.Size(590, 185);
            this.grpHomeCamera.TabIndex = 13;
            this.grpHomeCamera.TabStop = false;
            this.grpHomeCamera.Text = "카메라";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "(1.0 ~ 120.0)";
            //
            // numCameraInitialFov
            //
            this.numCameraInitialFov.Location = new System.Drawing.Point(238, 148);
            this.numCameraInitialFov.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numCameraInitialFov.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCameraInitialFov.Name = "numCameraInitialFov";
            this.numCameraInitialFov.Size = new System.Drawing.Size(120, 21);
            this.numCameraInitialFov.TabIndex = 4;
            this.numCameraInitialFov.ThousandsSeparator = true;
            this.numCameraInitialFov.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // numCameraBoundingBoxMaxZ
            //
            this.numCameraBoundingBoxMaxZ.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCameraBoundingBoxMaxZ.Location = new System.Drawing.Point(364, 110);
            this.numCameraBoundingBoxMaxZ.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numCameraBoundingBoxMaxZ.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numCameraBoundingBoxMaxZ.Name = "numCameraBoundingBoxMaxZ";
            this.numCameraBoundingBoxMaxZ.Size = new System.Drawing.Size(120, 21);
            this.numCameraBoundingBoxMaxZ.TabIndex = 2;
            this.numCameraBoundingBoxMaxZ.ThousandsSeparator = true;
            //
            // numCameraBoundingBoxMaxY
            //
            this.numCameraBoundingBoxMaxY.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCameraBoundingBoxMaxY.Location = new System.Drawing.Point(364, 83);
            this.numCameraBoundingBoxMaxY.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numCameraBoundingBoxMaxY.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numCameraBoundingBoxMaxY.Name = "numCameraBoundingBoxMaxY";
            this.numCameraBoundingBoxMaxY.Size = new System.Drawing.Size(120, 21);
            this.numCameraBoundingBoxMaxY.TabIndex = 2;
            this.numCameraBoundingBoxMaxY.ThousandsSeparator = true;
            //
            // numCameraBoundingBoxMaxX
            //
            this.numCameraBoundingBoxMaxX.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCameraBoundingBoxMaxX.Location = new System.Drawing.Point(364, 56);
            this.numCameraBoundingBoxMaxX.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numCameraBoundingBoxMaxX.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numCameraBoundingBoxMaxX.Name = "numCameraBoundingBoxMaxX";
            this.numCameraBoundingBoxMaxX.Size = new System.Drawing.Size(120, 21);
            this.numCameraBoundingBoxMaxX.TabIndex = 2;
            this.numCameraBoundingBoxMaxX.ThousandsSeparator = true;
            //
            // numCameraBoundingBoxMinZ
            //
            this.numCameraBoundingBoxMinZ.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCameraBoundingBoxMinZ.Location = new System.Drawing.Point(238, 110);
            this.numCameraBoundingBoxMinZ.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numCameraBoundingBoxMinZ.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numCameraBoundingBoxMinZ.Name = "numCameraBoundingBoxMinZ";
            this.numCameraBoundingBoxMinZ.Size = new System.Drawing.Size(120, 21);
            this.numCameraBoundingBoxMinZ.TabIndex = 2;
            this.numCameraBoundingBoxMinZ.ThousandsSeparator = true;
            //
            // numCameraBoundingBoxMinY
            //
            this.numCameraBoundingBoxMinY.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCameraBoundingBoxMinY.Location = new System.Drawing.Point(238, 83);
            this.numCameraBoundingBoxMinY.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numCameraBoundingBoxMinY.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numCameraBoundingBoxMinY.Name = "numCameraBoundingBoxMinY";
            this.numCameraBoundingBoxMinY.Size = new System.Drawing.Size(120, 21);
            this.numCameraBoundingBoxMinY.TabIndex = 2;
            this.numCameraBoundingBoxMinY.ThousandsSeparator = true;
            //
            // numCameraBoundingBoxMinX
            //
            this.numCameraBoundingBoxMinX.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCameraBoundingBoxMinX.Location = new System.Drawing.Point(238, 56);
            this.numCameraBoundingBoxMinX.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numCameraBoundingBoxMinX.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numCameraBoundingBoxMinX.Name = "numCameraBoundingBoxMinX";
            this.numCameraBoundingBoxMinX.Size = new System.Drawing.Size(120, 21);
            this.numCameraBoundingBoxMinX.TabIndex = 2;
            this.numCameraBoundingBoxMinX.ThousandsSeparator = true;
            //
            // label24
            //
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(22, 112);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(137, 12);
            this.label24.TabIndex = 1;
            this.label24.Text = "카메라 초기 위치 Z 범위";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "카메라 초기 수직 시야각(FOV)";
            //
            // label25
            //
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(22, 85);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(137, 12);
            this.label25.TabIndex = 1;
            this.label25.Text = "카메라 초기 위치 Y 범위";
            //
            // label26
            //
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(22, 58);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(137, 12);
            this.label26.TabIndex = 1;
            this.label26.Text = "카메라 초기 위치 X 범위";
            //
            // ckInitialCamera
            //
            this.ckInitialCamera.AutoSize = true;
            this.ckInitialCamera.Location = new System.Drawing.Point(24, 29);
            this.ckInitialCamera.Name = "ckInitialCamera";
            this.ckInitialCamera.Size = new System.Drawing.Size(152, 16);
            this.ckInitialCamera.TabIndex = 0;
            this.ckInitialCamera.Text = "카메라 초기위치 활성화";
            this.ckInitialCamera.UseVisualStyleBackColor = true;
            //
            // grpHomeView
            //
            this.grpHomeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHomeView.Controls.Add(this.cbCameraMode);
            this.grpHomeView.Controls.Add(this.lblCameraMode);
            this.grpHomeView.Controls.Add(this.cbProjection);
            this.grpHomeView.Controls.Add(this.label14);
            this.grpHomeView.Controls.Add(this.ckEnableSsao);
            this.grpHomeView.Controls.Add(this.ckEnableShadow);
            this.grpHomeView.Controls.Add(this.ckEnableEdge);
            this.grpHomeView.Controls.Add(this.lblEdgeColor);
            this.grpHomeView.Controls.Add(this.btnEdgeColor);
            this.grpHomeView.Location = new System.Drawing.Point(6, 71);
            this.grpHomeView.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpHomeView.Name = "grpHomeView";
            this.grpHomeView.Size = new System.Drawing.Size(590, 134);
            this.grpHomeView.TabIndex = 8;
            this.grpHomeView.TabStop = false;
            this.grpHomeView.Text = "렌더링";
            //
            // cbCameraMode
            //
            this.cbCameraMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCameraMode.FormattingEnabled = true;
            this.cbCameraMode.Location = new System.Drawing.Point(111, 26);
            this.cbCameraMode.Name = "cbCameraMode";
            this.cbCameraMode.Size = new System.Drawing.Size(121, 20);
            this.cbCameraMode.TabIndex = 7;
            //
            // lblCameraMode
            //
            this.lblCameraMode.AutoSize = true;
            this.lblCameraMode.Location = new System.Drawing.Point(22, 29);
            this.lblCameraMode.Name = "lblCameraMode";
            this.lblCameraMode.Size = new System.Drawing.Size(69, 12);
            this.lblCameraMode.TabIndex = 8;
            this.lblCameraMode.Text = "카메라 모드";
            //
            // cbProjection
            //
            this.cbProjection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjection.FormattingEnabled = true;
            this.cbProjection.Location = new System.Drawing.Point(111, 94);
            this.cbProjection.Name = "cbProjection";
            this.cbProjection.Size = new System.Drawing.Size(121, 20);
            this.cbProjection.TabIndex = 4;
            //
            // label14
            //
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "원근 / 평행";
            //
            // ckEnableSsao
            //
            this.ckEnableSsao.AutoSize = true;
            this.ckEnableSsao.Location = new System.Drawing.Point(320, 59);
            this.ckEnableSsao.Name = "ckEnableSsao";
            this.ckEnableSsao.Size = new System.Drawing.Size(57, 16);
            this.ckEnableSsao.TabIndex = 2;
            this.ckEnableSsao.Text = "SSAO";
            this.ckEnableSsao.UseVisualStyleBackColor = true;
            //
            // ckEnableShadow
            //
            this.ckEnableShadow.AutoSize = true;
            this.ckEnableShadow.Location = new System.Drawing.Point(172, 59);
            this.ckEnableShadow.Name = "ckEnableShadow";
            this.ckEnableShadow.Size = new System.Drawing.Size(60, 16);
            this.ckEnableShadow.TabIndex = 1;
            this.ckEnableShadow.Text = "그림자";
            this.ckEnableShadow.UseVisualStyleBackColor = true;
            //
            // ckEnableEdge
            //
            this.ckEnableEdge.AutoSize = true;
            this.ckEnableEdge.Location = new System.Drawing.Point(24, 59);
            this.ckEnableEdge.Name = "ckEnableEdge";
            this.ckEnableEdge.Size = new System.Drawing.Size(60, 16);
            this.ckEnableEdge.TabIndex = 0;
            this.ckEnableEdge.Text = "외곽선";
            this.ckEnableEdge.UseVisualStyleBackColor = true;
            //
            // lblEdgeColor
            //
            this.lblEdgeColor.AutoSize = true;
            this.lblEdgeColor.Location = new System.Drawing.Point(293, 97);
            this.lblEdgeColor.Name = "lblEdgeColor";
            this.lblEdgeColor.Size = new System.Drawing.Size(69, 12);
            this.lblEdgeColor.TabIndex = 5;
            this.lblEdgeColor.Text = "외곽선 색상";
            //
            // btnEdgeColor
            //
            this.btnEdgeColor.Location = new System.Drawing.Point(379, 92);
            this.btnEdgeColor.Name = "btnEdgeColor";
            this.btnEdgeColor.Size = new System.Drawing.Size(128, 22);
            this.btnEdgeColor.TabIndex = 6;
            this.btnEdgeColor.UseVisualStyleBackColor = false;
            this.btnEdgeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // grpHomeModel
            //
            this.grpHomeModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHomeModel.Controls.Add(this.ckEnableFace);
            this.grpHomeModel.Controls.Add(this.ckEnableBody);
            this.grpHomeModel.Controls.Add(this.ckEnableNodeLock);
            this.grpHomeModel.Location = new System.Drawing.Point(6, 6);
            this.grpHomeModel.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpHomeModel.Name = "grpHomeModel";
            this.grpHomeModel.Size = new System.Drawing.Size(590, 59);
            this.grpHomeModel.TabIndex = 2;
            this.grpHomeModel.TabStop = false;
            this.grpHomeModel.Text = "모델";
            //
            // ckEnableFace
            //
            this.ckEnableFace.AutoSize = true;
            this.ckEnableFace.Location = new System.Drawing.Point(172, 26);
            this.ckEnableFace.Name = "ckEnableFace";
            this.ckEnableFace.Size = new System.Drawing.Size(108, 16);
            this.ckEnableFace.TabIndex = 1;
            this.ckEnableFace.Text = "Face 유형 조회";
            this.ckEnableFace.UseVisualStyleBackColor = true;
            this.ckEnableFace.CheckedChanged += new System.EventHandler(this.ckEnableFace_CheckedChanged);
            //
            // ckEnableBody
            //
            this.ckEnableBody.AutoSize = true;
            this.ckEnableBody.Location = new System.Drawing.Point(24, 26);
            this.ckEnableBody.Name = "ckEnableBody";
            this.ckEnableBody.Size = new System.Drawing.Size(109, 16);
            this.ckEnableBody.TabIndex = 0;
            this.ckEnableBody.Text = "Body 유형 조회";
            this.ckEnableBody.UseVisualStyleBackColor = true;
            this.ckEnableBody.CheckedChanged += new System.EventHandler(this.ckEnableBody_CheckedChanged);
            //
            // ckEnableNodeLock
            //
            this.ckEnableNodeLock.AutoSize = true;
            this.ckEnableNodeLock.Location = new System.Drawing.Point(320, 26);
            this.ckEnableNodeLock.Name = "ckEnableNodeLock";
            this.ckEnableNodeLock.Size = new System.Drawing.Size(144, 16);
            this.ckEnableNodeLock.TabIndex = 2;
            this.ckEnableNodeLock.Text = "노드 잠금 기능 활성화";
            this.ckEnableNodeLock.UseVisualStyleBackColor = true;
            //
            // tpView
            //
            this.tpView.AutoScroll = true;
            this.tpView.Controls.Add(this.grpViewCommand);
            this.tpView.Controls.Add(this.grpViewLight);
            this.tpView.Controls.Add(this.grpViewCube);
            this.tpView.Controls.Add(this.grpViewZoom);
            this.tpView.Controls.Add(this.grpViewView);
            this.tpView.Location = new System.Drawing.Point(4, 40);
            this.tpView.Name = "tpView";
            this.tpView.Padding = new System.Windows.Forms.Padding(3);
            this.tpView.Size = new System.Drawing.Size(668, 614);
            this.tpView.TabIndex = 1;
            this.tpView.Text = "보기";
            this.tpView.UseVisualStyleBackColor = true;
            //
            // grpViewZoomBox
            //
            this.grpViewZoomBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpViewZoomBox.Controls.Add(this.lblZoomBoxFillColor);
            this.grpViewZoomBox.Controls.Add(this.btnZoomBoxFillColor);
            this.grpViewZoomBox.Controls.Add(this.lblZoomBoxStrokeColor);
            this.grpViewZoomBox.Controls.Add(this.btnZoomBoxStrokeColor);
            this.grpViewZoomBox.Controls.Add(this.lblZoomBoxStrokePattern);
            this.grpViewZoomBox.Controls.Add(this.cbZoomBoxStrokePattern);
            this.grpViewZoomBox.Controls.Add(this.lblZoomBoxStrokeThickness);
            this.grpViewZoomBox.Controls.Add(this.numZoomBoxStrokeThickness);
            this.grpViewZoomBox.Location = new System.Drawing.Point(10, 76);
            this.grpViewZoomBox.MinimumSize = new System.Drawing.Size(570, 0);
            this.grpViewZoomBox.Name = "grpViewZoomBox";
            this.grpViewZoomBox.Size = new System.Drawing.Size(570, 170);
            this.grpViewZoomBox.TabIndex = 2;
            this.grpViewZoomBox.TabStop = false;
            this.grpViewZoomBox.Text = "확대 상자";
            //
            // lblZoomBoxFillColor
            //
            this.lblZoomBoxFillColor.AutoSize = true;
            this.lblZoomBoxFillColor.Location = new System.Drawing.Point(16, 31);
            this.lblZoomBoxFillColor.Name = "lblZoomBoxFillColor";
            this.lblZoomBoxFillColor.Size = new System.Drawing.Size(69, 12);
            this.lblZoomBoxFillColor.TabIndex = 0;
            this.lblZoomBoxFillColor.Text = "채우기 색상";
            //
            // btnZoomBoxFillColor
            //
            this.btnZoomBoxFillColor.Location = new System.Drawing.Point(200, 26);
            this.btnZoomBoxFillColor.Name = "btnZoomBoxFillColor";
            this.btnZoomBoxFillColor.Size = new System.Drawing.Size(80, 23);
            this.btnZoomBoxFillColor.TabIndex = 1;
            this.btnZoomBoxFillColor.UseVisualStyleBackColor = false;
            this.btnZoomBoxFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // lblZoomBoxStrokeColor
            //
            this.lblZoomBoxStrokeColor.AutoSize = true;
            this.lblZoomBoxStrokeColor.Location = new System.Drawing.Point(16, 63);
            this.lblZoomBoxStrokeColor.Name = "lblZoomBoxStrokeColor";
            this.lblZoomBoxStrokeColor.Size = new System.Drawing.Size(45, 12);
            this.lblZoomBoxStrokeColor.TabIndex = 2;
            this.lblZoomBoxStrokeColor.Text = "선 색상";
            //
            // btnZoomBoxStrokeColor
            //
            this.btnZoomBoxStrokeColor.Location = new System.Drawing.Point(200, 58);
            this.btnZoomBoxStrokeColor.Name = "btnZoomBoxStrokeColor";
            this.btnZoomBoxStrokeColor.Size = new System.Drawing.Size(80, 23);
            this.btnZoomBoxStrokeColor.TabIndex = 3;
            this.btnZoomBoxStrokeColor.UseVisualStyleBackColor = false;
            this.btnZoomBoxStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // lblZoomBoxStrokePattern
            //
            this.lblZoomBoxStrokePattern.AutoSize = true;
            this.lblZoomBoxStrokePattern.Location = new System.Drawing.Point(16, 95);
            this.lblZoomBoxStrokePattern.Name = "lblZoomBoxStrokePattern";
            this.lblZoomBoxStrokePattern.Size = new System.Drawing.Size(45, 12);
            this.lblZoomBoxStrokePattern.TabIndex = 4;
            this.lblZoomBoxStrokePattern.Text = "선 패턴";
            //
            // cbZoomBoxStrokePattern
            //
            this.cbZoomBoxStrokePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZoomBoxStrokePattern.FormattingEnabled = true;
            this.cbZoomBoxStrokePattern.Location = new System.Drawing.Point(200, 91);
            this.cbZoomBoxStrokePattern.Name = "cbZoomBoxStrokePattern";
            this.cbZoomBoxStrokePattern.Size = new System.Drawing.Size(120, 20);
            this.cbZoomBoxStrokePattern.TabIndex = 5;
            //
            // lblZoomBoxStrokeThickness
            //
            this.lblZoomBoxStrokeThickness.AutoSize = true;
            this.lblZoomBoxStrokeThickness.Location = new System.Drawing.Point(16, 127);
            this.lblZoomBoxStrokeThickness.Name = "lblZoomBoxStrokeThickness";
            this.lblZoomBoxStrokeThickness.Size = new System.Drawing.Size(45, 12);
            this.lblZoomBoxStrokeThickness.TabIndex = 6;
            this.lblZoomBoxStrokeThickness.Text = "선 두께";
            //
            // numZoomBoxStrokeThickness
            //
            this.numZoomBoxStrokeThickness.DecimalPlaces = 1;
            this.numZoomBoxStrokeThickness.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numZoomBoxStrokeThickness.Location = new System.Drawing.Point(200, 123);
            this.numZoomBoxStrokeThickness.Name = "numZoomBoxStrokeThickness";
            this.numZoomBoxStrokeThickness.Size = new System.Drawing.Size(80, 21);
            this.numZoomBoxStrokeThickness.TabIndex = 7;
            //
            // grpViewCubeFace
            //
            this.grpViewCubeFace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpViewCubeFace.Controls.Add(this.lblViewCubeTop);
            this.grpViewCubeFace.Controls.Add(this.txtViewCubeTop);
            this.grpViewCubeFace.Controls.Add(this.lblViewCubeBottom);
            this.grpViewCubeFace.Controls.Add(this.txtViewCubeBottom);
            this.grpViewCubeFace.Controls.Add(this.lblViewCubeLeft);
            this.grpViewCubeFace.Controls.Add(this.txtViewCubeLeft);
            this.grpViewCubeFace.Controls.Add(this.lblViewCubeRight);
            this.grpViewCubeFace.Controls.Add(this.txtViewCubeRight);
            this.grpViewCubeFace.Controls.Add(this.lblViewCubeFront);
            this.grpViewCubeFace.Controls.Add(this.txtViewCubeFront);
            this.grpViewCubeFace.Controls.Add(this.lblViewCubeBack);
            this.grpViewCubeFace.Controls.Add(this.txtViewCubeBack);
            this.grpViewCubeFace.Location = new System.Drawing.Point(10, 176);
            this.grpViewCubeFace.MinimumSize = new System.Drawing.Size(570, 0);
            this.grpViewCubeFace.Name = "grpViewCubeFace";
            this.grpViewCubeFace.Size = new System.Drawing.Size(570, 130);
            this.grpViewCubeFace.TabIndex = 1;
            this.grpViewCubeFace.TabStop = false;
            this.grpViewCubeFace.Text = "뷰큐브 면 문자열";
            //
            // lblViewCubeTop
            //
            this.lblViewCubeTop.AutoSize = true;
            this.lblViewCubeTop.Location = new System.Drawing.Point(16, 34);
            this.lblViewCubeTop.Name = "lblViewCubeTop";
            this.lblViewCubeTop.Size = new System.Drawing.Size(29, 12);
            this.lblViewCubeTop.TabIndex = 0;
            this.lblViewCubeTop.Text = "윗면";
            //
            // txtViewCubeTop
            //
            this.txtViewCubeTop.Location = new System.Drawing.Point(110, 31);
            this.txtViewCubeTop.Name = "txtViewCubeTop";
            this.txtViewCubeTop.Size = new System.Drawing.Size(150, 21);
            this.txtViewCubeTop.TabIndex = 1;
            //
            // lblViewCubeBottom
            //
            this.lblViewCubeBottom.AutoSize = true;
            this.lblViewCubeBottom.Location = new System.Drawing.Point(310, 34);
            this.lblViewCubeBottom.Name = "lblViewCubeBottom";
            this.lblViewCubeBottom.Size = new System.Drawing.Size(41, 12);
            this.lblViewCubeBottom.TabIndex = 2;
            this.lblViewCubeBottom.Text = "아랫면";
            //
            // txtViewCubeBottom
            //
            this.txtViewCubeBottom.Location = new System.Drawing.Point(404, 31);
            this.txtViewCubeBottom.Name = "txtViewCubeBottom";
            this.txtViewCubeBottom.Size = new System.Drawing.Size(150, 21);
            this.txtViewCubeBottom.TabIndex = 3;
            //
            // lblViewCubeLeft
            //
            this.lblViewCubeLeft.AutoSize = true;
            this.lblViewCubeLeft.Location = new System.Drawing.Point(16, 66);
            this.lblViewCubeLeft.Name = "lblViewCubeLeft";
            this.lblViewCubeLeft.Size = new System.Drawing.Size(41, 12);
            this.lblViewCubeLeft.TabIndex = 4;
            this.lblViewCubeLeft.Text = "왼쪽면";
            //
            // txtViewCubeLeft
            //
            this.txtViewCubeLeft.Location = new System.Drawing.Point(110, 63);
            this.txtViewCubeLeft.Name = "txtViewCubeLeft";
            this.txtViewCubeLeft.Size = new System.Drawing.Size(150, 21);
            this.txtViewCubeLeft.TabIndex = 5;
            //
            // lblViewCubeRight
            //
            this.lblViewCubeRight.AutoSize = true;
            this.lblViewCubeRight.Location = new System.Drawing.Point(310, 66);
            this.lblViewCubeRight.Name = "lblViewCubeRight";
            this.lblViewCubeRight.Size = new System.Drawing.Size(53, 12);
            this.lblViewCubeRight.TabIndex = 6;
            this.lblViewCubeRight.Text = "오른쪽면";
            //
            // txtViewCubeRight
            //
            this.txtViewCubeRight.Location = new System.Drawing.Point(404, 63);
            this.txtViewCubeRight.Name = "txtViewCubeRight";
            this.txtViewCubeRight.Size = new System.Drawing.Size(150, 21);
            this.txtViewCubeRight.TabIndex = 7;
            //
            // lblViewCubeFront
            //
            this.lblViewCubeFront.AutoSize = true;
            this.lblViewCubeFront.Location = new System.Drawing.Point(16, 98);
            this.lblViewCubeFront.Name = "lblViewCubeFront";
            this.lblViewCubeFront.Size = new System.Drawing.Size(29, 12);
            this.lblViewCubeFront.TabIndex = 8;
            this.lblViewCubeFront.Text = "앞면";
            //
            // txtViewCubeFront
            //
            this.txtViewCubeFront.Location = new System.Drawing.Point(110, 95);
            this.txtViewCubeFront.Name = "txtViewCubeFront";
            this.txtViewCubeFront.Size = new System.Drawing.Size(150, 21);
            this.txtViewCubeFront.TabIndex = 9;
            //
            // lblViewCubeBack
            //
            this.lblViewCubeBack.AutoSize = true;
            this.lblViewCubeBack.Location = new System.Drawing.Point(310, 98);
            this.lblViewCubeBack.Name = "lblViewCubeBack";
            this.lblViewCubeBack.Size = new System.Drawing.Size(29, 12);
            this.lblViewCubeBack.TabIndex = 10;
            this.lblViewCubeBack.Text = "뒷면";
            //
            // txtViewCubeBack
            //
            this.txtViewCubeBack.Location = new System.Drawing.Point(404, 95);
            this.txtViewCubeBack.Name = "txtViewCubeBack";
            this.txtViewCubeBack.Size = new System.Drawing.Size(150, 21);
            this.txtViewCubeBack.TabIndex = 11;
            //
            // grpViewCommand
            //
            this.grpViewCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpViewCommand.Controls.Add(this.btnCommandMessageTextColor);
            this.grpViewCommand.Controls.Add(this.label105);
            this.grpViewCommand.Location = new System.Drawing.Point(6, 692);
            this.grpViewCommand.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpViewCommand.Name = "grpViewCommand";
            this.grpViewCommand.Size = new System.Drawing.Size(590, 54);
            this.grpViewCommand.TabIndex = 3;
            this.grpViewCommand.TabStop = false;
            this.grpViewCommand.Text = "명령 메시지";
            //
            // btnCommandMessageTextColor
            //
            this.btnCommandMessageTextColor.Location = new System.Drawing.Point(185, 20);
            this.btnCommandMessageTextColor.Name = "btnCommandMessageTextColor";
            this.btnCommandMessageTextColor.Size = new System.Drawing.Size(190, 23);
            this.btnCommandMessageTextColor.TabIndex = 8;
            this.btnCommandMessageTextColor.UseVisualStyleBackColor = false;
            this.btnCommandMessageTextColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label105
            //
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(22, 25);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(69, 12);
            this.label105.TabIndex = 7;
            this.label105.Text = "명령어 색상";
            //
            // grpViewLight
            //
            this.grpViewLight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpViewLight.Controls.Add(this.ckEnvironmentLight);
            this.grpViewLight.Controls.Add(this.lblLightDir);
            this.grpViewLight.Controls.Add(this.lblDirX);
            this.grpViewLight.Controls.Add(this.txtLightDirX);
            this.grpViewLight.Controls.Add(this.lblDirY);
            this.grpViewLight.Controls.Add(this.txtLightDirY);
            this.grpViewLight.Controls.Add(this.lblDirZ);
            this.grpViewLight.Controls.Add(this.txtLightDirZ);
            this.grpViewLight.Controls.Add(this.lblAmbientColor);
            this.grpViewLight.Controls.Add(this.btnAmbientColor);
            this.grpViewLight.Controls.Add(this.lblLightColor);
            this.grpViewLight.Controls.Add(this.btnLightColor);
            this.grpViewLight.Controls.Add(this.lblShininess);
            this.grpViewLight.Controls.Add(this.numShininess);
            this.grpViewLight.Controls.Add(this.lblShininessRange);
            this.grpViewLight.Controls.Add(this.lblSpecularIntensity);
            this.grpViewLight.Controls.Add(this.numSpecularIntensity);
            this.grpViewLight.Controls.Add(this.lblSpecularRange);
            this.grpViewLight.Location = new System.Drawing.Point(6, 752);
            this.grpViewLight.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpViewLight.Name = "grpViewLight";
            this.grpViewLight.Size = new System.Drawing.Size(590, 187);
            this.grpViewLight.TabIndex = 4;
            this.grpViewLight.TabStop = false;
            this.grpViewLight.Text = "환경조명";
            //
            // ckEnvironmentLight
            //
            this.ckEnvironmentLight.AutoSize = true;
            this.ckEnvironmentLight.Location = new System.Drawing.Point(19, 26);
            this.ckEnvironmentLight.Name = "ckEnvironmentLight";
            this.ckEnvironmentLight.Size = new System.Drawing.Size(112, 16);
            this.ckEnvironmentLight.TabIndex = 0;
            this.ckEnvironmentLight.Text = "환경조명 활성화";
            this.ckEnvironmentLight.UseVisualStyleBackColor = true;
            this.ckEnvironmentLight.CheckedChanged += new System.EventHandler(this.ckEnvironmentLight_CheckedChanged);
            //
            // lblLightDir
            //
            this.lblLightDir.AutoSize = true;
            this.lblLightDir.Location = new System.Drawing.Point(16, 60);
            this.lblLightDir.Name = "lblLightDir";
            this.lblLightDir.Size = new System.Drawing.Size(57, 12);
            this.lblLightDir.TabIndex = 1;
            this.lblLightDir.Text = "빛의 방향";
            //
            // lblDirX
            //
            this.lblDirX.AutoSize = true;
            this.lblDirX.Location = new System.Drawing.Point(99, 60);
            this.lblDirX.Name = "lblDirX";
            this.lblDirX.Size = new System.Drawing.Size(13, 12);
            this.lblDirX.TabIndex = 2;
            this.lblDirX.Text = "X";
            //
            // txtLightDirX
            //
            this.txtLightDirX.Location = new System.Drawing.Point(114, 57);
            this.txtLightDirX.Name = "txtLightDirX";
            this.txtLightDirX.Size = new System.Drawing.Size(60, 21);
            this.txtLightDirX.TabIndex = 3;
            //
            // lblDirY
            //
            this.lblDirY.AutoSize = true;
            this.lblDirY.Location = new System.Drawing.Point(184, 60);
            this.lblDirY.Name = "lblDirY";
            this.lblDirY.Size = new System.Drawing.Size(13, 12);
            this.lblDirY.TabIndex = 4;
            this.lblDirY.Text = "Y";
            //
            // txtLightDirY
            //
            this.txtLightDirY.Location = new System.Drawing.Point(199, 57);
            this.txtLightDirY.Name = "txtLightDirY";
            this.txtLightDirY.Size = new System.Drawing.Size(60, 21);
            this.txtLightDirY.TabIndex = 5;
            //
            // lblDirZ
            //
            this.lblDirZ.AutoSize = true;
            this.lblDirZ.Location = new System.Drawing.Point(269, 60);
            this.lblDirZ.Name = "lblDirZ";
            this.lblDirZ.Size = new System.Drawing.Size(13, 12);
            this.lblDirZ.TabIndex = 6;
            this.lblDirZ.Text = "Z";
            //
            // txtLightDirZ
            //
            this.txtLightDirZ.Location = new System.Drawing.Point(284, 57);
            this.txtLightDirZ.Name = "txtLightDirZ";
            this.txtLightDirZ.Size = new System.Drawing.Size(60, 21);
            this.txtLightDirZ.TabIndex = 7;
            //
            // lblAmbientColor
            //
            this.lblAmbientColor.AutoSize = true;
            this.lblAmbientColor.Location = new System.Drawing.Point(16, 93);
            this.lblAmbientColor.Name = "lblAmbientColor";
            this.lblAmbientColor.Size = new System.Drawing.Size(69, 12);
            this.lblAmbientColor.TabIndex = 8;
            this.lblAmbientColor.Text = "주변광 색상";
            //
            // btnAmbientColor
            //
            this.btnAmbientColor.Location = new System.Drawing.Point(99, 88);
            this.btnAmbientColor.Name = "btnAmbientColor";
            this.btnAmbientColor.Size = new System.Drawing.Size(80, 23);
            this.btnAmbientColor.TabIndex = 9;
            this.btnAmbientColor.UseVisualStyleBackColor = false;
            this.btnAmbientColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // lblLightColor
            //
            this.lblLightColor.AutoSize = true;
            this.lblLightColor.Location = new System.Drawing.Point(199, 93);
            this.lblLightColor.Name = "lblLightColor";
            this.lblLightColor.Size = new System.Drawing.Size(57, 12);
            this.lblLightColor.TabIndex = 10;
            this.lblLightColor.Text = "광원 색상";
            //
            // btnLightColor
            //
            this.btnLightColor.Location = new System.Drawing.Point(274, 88);
            this.btnLightColor.Name = "btnLightColor";
            this.btnLightColor.Size = new System.Drawing.Size(80, 23);
            this.btnLightColor.TabIndex = 11;
            this.btnLightColor.UseVisualStyleBackColor = false;
            this.btnLightColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // lblShininess
            //
            this.lblShininess.AutoSize = true;
            this.lblShininess.Location = new System.Drawing.Point(16, 125);
            this.lblShininess.Name = "lblShininess";
            this.lblShininess.Size = new System.Drawing.Size(29, 12);
            this.lblShininess.TabIndex = 12;
            this.lblShininess.Text = "광택";
            //
            // numShininess
            //
            this.numShininess.Location = new System.Drawing.Point(99, 121);
            this.numShininess.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numShininess.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numShininess.Name = "numShininess";
            this.numShininess.Size = new System.Drawing.Size(80, 21);
            this.numShininess.TabIndex = 13;
            this.numShininess.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // lblShininessRange
            //
            this.lblShininessRange.AutoSize = true;
            this.lblShininessRange.Location = new System.Drawing.Point(189, 125);
            this.lblShininessRange.Name = "lblShininessRange";
            this.lblShininessRange.Size = new System.Drawing.Size(56, 12);
            this.lblShininessRange.TabIndex = 14;
            this.lblShininessRange.Text = "(1 ~ 256)";
            //
            // lblSpecularIntensity
            //
            this.lblSpecularIntensity.AutoSize = true;
            this.lblSpecularIntensity.Location = new System.Drawing.Point(16, 157);
            this.lblSpecularIntensity.Name = "lblSpecularIntensity";
            this.lblSpecularIntensity.Size = new System.Drawing.Size(69, 12);
            this.lblSpecularIntensity.TabIndex = 15;
            this.lblSpecularIntensity.Text = "정반사 강도";
            //
            // numSpecularIntensity
            //
            this.numSpecularIntensity.DecimalPlaces = 2;
            this.numSpecularIntensity.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numSpecularIntensity.Location = new System.Drawing.Point(99, 153);
            this.numSpecularIntensity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpecularIntensity.Name = "numSpecularIntensity";
            this.numSpecularIntensity.Size = new System.Drawing.Size(80, 21);
            this.numSpecularIntensity.TabIndex = 16;
            //
            // lblSpecularRange
            //
            this.lblSpecularRange.AutoSize = true;
            this.lblSpecularRange.Location = new System.Drawing.Point(189, 157);
            this.lblSpecularRange.Name = "lblSpecularRange";
            this.lblSpecularRange.Size = new System.Drawing.Size(44, 12);
            this.lblSpecularRange.TabIndex = 17;
            this.lblSpecularRange.Text = "(0 ~ 1)";
            //
            // grpViewCube
            //
            this.grpViewCube.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpViewCube.Controls.Add(this.ckViewCubeEnable);
            this.grpViewCube.Controls.Add(this.cbViewCubeFontSize);
            this.grpViewCube.Controls.Add(this.btnViewCubeFontColor);
            this.grpViewCube.Controls.Add(this.btnViewCubeHighlightedStrokeColor);
            this.grpViewCube.Controls.Add(this.btnViewCubeHighlightedFillColor);
            this.grpViewCube.Controls.Add(this.btnViewCubeStrokeColor);
            this.grpViewCube.Controls.Add(this.btnViewCubeFillColor);
            this.grpViewCube.Controls.Add(this.label94);
            this.grpViewCube.Controls.Add(this.label93);
            this.grpViewCube.Controls.Add(this.label92);
            this.grpViewCube.Controls.Add(this.label91);
            this.grpViewCube.Controls.Add(this.label90);
            this.grpViewCube.Controls.Add(this.label89);
            this.grpViewCube.Controls.Add(this.grpViewCubeFace);
            this.grpViewCube.Location = new System.Drawing.Point(6, 372);
            this.grpViewCube.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpViewCube.Name = "grpViewCube";
            this.grpViewCube.Size = new System.Drawing.Size(590, 314);
            this.grpViewCube.TabIndex = 2;
            this.grpViewCube.TabStop = false;
            this.grpViewCube.Text = "뷰큐브";
            //
            // ckViewCubeEnable
            //
            this.ckViewCubeEnable.AutoSize = true;
            this.ckViewCubeEnable.Location = new System.Drawing.Point(19, 29);
            this.ckViewCubeEnable.Name = "ckViewCubeEnable";
            this.ckViewCubeEnable.Size = new System.Drawing.Size(60, 16);
            this.ckViewCubeEnable.TabIndex = 22;
            this.ckViewCubeEnable.Text = "활성화";
            this.ckViewCubeEnable.UseVisualStyleBackColor = true;
            //
            // cbViewCubeFontSize
            //
            this.cbViewCubeFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbViewCubeFontSize.FormattingEnabled = true;
            this.cbViewCubeFontSize.Location = new System.Drawing.Point(364, 85);
            this.cbViewCubeFontSize.Name = "cbViewCubeFontSize";
            this.cbViewCubeFontSize.Size = new System.Drawing.Size(75, 20);
            this.cbViewCubeFontSize.TabIndex = 21;
            //
            // btnViewCubeFontColor
            //
            this.btnViewCubeFontColor.Location = new System.Drawing.Point(364, 55);
            this.btnViewCubeFontColor.Name = "btnViewCubeFontColor";
            this.btnViewCubeFontColor.Size = new System.Drawing.Size(75, 23);
            this.btnViewCubeFontColor.TabIndex = 10;
            this.btnViewCubeFontColor.UseVisualStyleBackColor = false;
            this.btnViewCubeFontColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnViewCubeHighlightedStrokeColor
            //
            this.btnViewCubeHighlightedStrokeColor.Location = new System.Drawing.Point(162, 145);
            this.btnViewCubeHighlightedStrokeColor.Name = "btnViewCubeHighlightedStrokeColor";
            this.btnViewCubeHighlightedStrokeColor.Size = new System.Drawing.Size(75, 23);
            this.btnViewCubeHighlightedStrokeColor.TabIndex = 9;
            this.btnViewCubeHighlightedStrokeColor.UseVisualStyleBackColor = false;
            this.btnViewCubeHighlightedStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnViewCubeHighlightedFillColor
            //
            this.btnViewCubeHighlightedFillColor.Location = new System.Drawing.Point(162, 115);
            this.btnViewCubeHighlightedFillColor.Name = "btnViewCubeHighlightedFillColor";
            this.btnViewCubeHighlightedFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnViewCubeHighlightedFillColor.TabIndex = 8;
            this.btnViewCubeHighlightedFillColor.UseVisualStyleBackColor = false;
            this.btnViewCubeHighlightedFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnViewCubeStrokeColor
            //
            this.btnViewCubeStrokeColor.Location = new System.Drawing.Point(162, 85);
            this.btnViewCubeStrokeColor.Name = "btnViewCubeStrokeColor";
            this.btnViewCubeStrokeColor.Size = new System.Drawing.Size(75, 23);
            this.btnViewCubeStrokeColor.TabIndex = 7;
            this.btnViewCubeStrokeColor.UseVisualStyleBackColor = false;
            this.btnViewCubeStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnViewCubeFillColor
            //
            this.btnViewCubeFillColor.Location = new System.Drawing.Point(162, 55);
            this.btnViewCubeFillColor.Name = "btnViewCubeFillColor";
            this.btnViewCubeFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnViewCubeFillColor.TabIndex = 6;
            this.btnViewCubeFillColor.UseVisualStyleBackColor = false;
            this.btnViewCubeFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label94
            //
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(261, 90);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(97, 12);
            this.label94.TabIndex = 5;
            this.label94.Text = "뷰큐브 글자 크기";
            //
            // label93
            //
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(261, 60);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(81, 12);
            this.label93.TabIndex = 4;
            this.label93.Text = "뷰큐브 글자색";
            //
            // label92
            //
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(17, 60);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(81, 12);
            this.label92.TabIndex = 3;
            this.label92.Text = "뷰큐브 배경색";
            //
            // label91
            //
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(17, 90);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(81, 12);
            this.label91.TabIndex = 2;
            this.label91.Text = "뷰큐브 라인색";
            //
            // label90
            //
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(17, 150);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(109, 12);
            this.label90.TabIndex = 1;
            this.label90.Text = "강조 뷰큐브 라인색";
            //
            // label89
            //
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(17, 120);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(109, 12);
            this.label89.TabIndex = 0;
            this.label89.Text = "강조 뷰큐브 배경색";
            //
            // grpViewZoom
            //
            this.grpViewZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpViewZoom.Controls.Add(this.numZoomRatio);
            this.grpViewZoom.Controls.Add(this.label84);
            this.grpViewZoom.Controls.Add(this.label85);
            this.grpViewZoom.Controls.Add(this.grpViewZoomBox);
            this.grpViewZoom.Location = new System.Drawing.Point(6, 112);
            this.grpViewZoom.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpViewZoom.Name = "grpViewZoom";
            this.grpViewZoom.Size = new System.Drawing.Size(590, 254);
            this.grpViewZoom.TabIndex = 1;
            this.grpViewZoom.TabStop = false;
            this.grpViewZoom.Text = "확대/축소";
            //
            // numZoomRatio
            //
            this.numZoomRatio.Location = new System.Drawing.Point(162, 43);
            this.numZoomRatio.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numZoomRatio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numZoomRatio.Name = "numZoomRatio";
            this.numZoomRatio.Size = new System.Drawing.Size(120, 21);
            this.numZoomRatio.TabIndex = 3;
            this.numZoomRatio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // label84
            //
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(294, 48);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(50, 12);
            this.label84.TabIndex = 2;
            this.label84.Text = "(1 ~ 90)";
            //
            // label85
            //
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(17, 43);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(87, 12);
            this.label85.TabIndex = 0;
            this.label85.Text = "확대/축소 비율";
            //
            // grpViewView
            //
            this.grpViewView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpViewView.Controls.Add(this.ckEnableAnimation);
            this.grpViewView.Controls.Add(this.ckEnableAutoFit);
            this.grpViewView.Controls.Add(this.lblRenderScaleRange);
            this.grpViewView.Controls.Add(this.numRenderScale);
            this.grpViewView.Controls.Add(this.lblRenderScale);
            this.grpViewView.Controls.Add(this.ckViewToolbarEnable);
            this.grpViewView.Controls.Add(this.lblFallbackFontFamilies);
            this.grpViewView.Controls.Add(this.cbFallbackFontFamilies);
            this.grpViewView.Location = new System.Drawing.Point(6, 6);
            this.grpViewView.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpViewView.Name = "grpViewView";
            this.grpViewView.Size = new System.Drawing.Size(590, 100);
            this.grpViewView.TabIndex = 0;
            this.grpViewView.TabStop = false;
            this.grpViewView.Text = "화면";
            //
            // ckEnableAnimation
            //
            this.ckEnableAnimation.AutoSize = true;
            this.ckEnableAnimation.Location = new System.Drawing.Point(19, 29);
            this.ckEnableAnimation.Name = "ckEnableAnimation";
            this.ckEnableAnimation.Size = new System.Drawing.Size(112, 16);
            this.ckEnableAnimation.TabIndex = 3;
            this.ckEnableAnimation.Text = "자동 애니메이션";
            this.ckEnableAnimation.UseVisualStyleBackColor = true;
            //
            // ckEnableAutoFit
            //
            this.ckEnableAutoFit.AutoSize = true;
            this.ckEnableAutoFit.Location = new System.Drawing.Point(162, 29);
            this.ckEnableAutoFit.Name = "ckEnableAutoFit";
            this.ckEnableAutoFit.Size = new System.Drawing.Size(104, 16);
            this.ckEnableAutoFit.TabIndex = 1;
            this.ckEnableAutoFit.Text = "자동 화면 맞춤";
            this.ckEnableAutoFit.UseVisualStyleBackColor = true;
            //
            // lblRenderScaleRange
            //
            this.lblRenderScaleRange.AutoSize = true;
            this.lblRenderScaleRange.Location = new System.Drawing.Point(192, 69);
            this.lblRenderScaleRange.Name = "lblRenderScaleRange";
            this.lblRenderScaleRange.Size = new System.Drawing.Size(64, 12);
            this.lblRenderScaleRange.TabIndex = 20;
            this.lblRenderScaleRange.Text = "(1.0 ~ 4.0)";
            //
            // numRenderScale
            //
            this.numRenderScale.DecimalPlaces = 1;
            this.numRenderScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numRenderScale.Location = new System.Drawing.Point(102, 65);
            this.numRenderScale.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numRenderScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRenderScale.Name = "numRenderScale";
            this.numRenderScale.Size = new System.Drawing.Size(80, 21);
            this.numRenderScale.TabIndex = 19;
            this.numRenderScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // lblRenderScale
            //
            this.lblRenderScale.AutoSize = true;
            this.lblRenderScale.Location = new System.Drawing.Point(19, 69);
            this.lblRenderScale.Name = "lblRenderScale";
            this.lblRenderScale.Size = new System.Drawing.Size(65, 12);
            this.lblRenderScale.TabIndex = 18;
            this.lblRenderScale.Text = "렌더스케일";
            //
            // ckViewToolbarEnable
            //
            this.ckViewToolbarEnable.AutoSize = true;
            this.ckViewToolbarEnable.Location = new System.Drawing.Point(306, 29);
            this.ckViewToolbarEnable.Name = "ckViewToolbarEnable";
            this.ckViewToolbarEnable.Size = new System.Drawing.Size(100, 16);
            this.ckViewToolbarEnable.TabIndex = 23;
            this.ckViewToolbarEnable.Text = "뷰툴바 활성화";
            this.ckViewToolbarEnable.UseVisualStyleBackColor = true;
            //
            // lblFallbackFontFamilies
            //
            this.lblFallbackFontFamilies.AutoSize = true;
            this.lblFallbackFontFamilies.Location = new System.Drawing.Point(306, 69);
            this.lblFallbackFontFamilies.Name = "lblFallbackFontFamilies";
            this.lblFallbackFontFamilies.Size = new System.Drawing.Size(57, 12);
            this.lblFallbackFontFamilies.TabIndex = 21;
            this.lblFallbackFontFamilies.Text = "대체 폰트";
            //
            // cbFallbackFontFamilies
            //
            this.cbFallbackFontFamilies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFallbackFontFamilies.FormattingEnabled = true;
            this.cbFallbackFontFamilies.Location = new System.Drawing.Point(372, 65);
            this.cbFallbackFontFamilies.Name = "cbFallbackFontFamilies";
            this.cbFallbackFontFamilies.Size = new System.Drawing.Size(208, 20);
            this.cbFallbackFontFamilies.TabIndex = 22;
            //
            // tpInput
            //
            this.tpInput.AutoScroll = true;
            this.tpInput.Controls.Add(this.grpInputClick);
            this.tpInput.Controls.Add(this.grpInputSpeed);
            this.tpInput.Controls.Add(this.grpInputSensitivity);
            this.tpInput.Location = new System.Drawing.Point(4, 40);
            this.tpInput.Name = "tpInput";
            this.tpInput.Padding = new System.Windows.Forms.Padding(3);
            this.tpInput.Size = new System.Drawing.Size(668, 614);
            this.tpInput.TabIndex = 5;
            this.tpInput.Text = "입력 (마우스/키)";
            this.tpInput.UseVisualStyleBackColor = true;
            //
            // grpInputClick
            //
            this.grpInputClick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInputClick.Controls.Add(this.ckInputWheelInvert);
            this.grpInputClick.Controls.Add(this.lblInputClickDuration);
            this.grpInputClick.Controls.Add(this.numInputClickDuration);
            this.grpInputClick.Controls.Add(this.lblInputLongPress);
            this.grpInputClick.Controls.Add(this.numInputLongPress);
            this.grpInputClick.Controls.Add(this.lblInputClickTolerance);
            this.grpInputClick.Controls.Add(this.numInputClickTolerance);
            this.grpInputClick.Location = new System.Drawing.Point(6, 346);
            this.grpInputClick.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpInputClick.Name = "grpInputClick";
            this.grpInputClick.Size = new System.Drawing.Size(590, 150);
            this.grpInputClick.TabIndex = 2;
            this.grpInputClick.TabStop = false;
            this.grpInputClick.Text = "클릭 판정·휠";
            //
            // ckInputWheelInvert
            //
            this.ckInputWheelInvert.AutoSize = true;
            this.ckInputWheelInvert.Location = new System.Drawing.Point(19, 29);
            this.ckInputWheelInvert.Name = "ckInputWheelInvert";
            this.ckInputWheelInvert.Size = new System.Drawing.Size(92, 16);
            this.ckInputWheelInvert.TabIndex = 0;
            this.ckInputWheelInvert.Text = "휠 방향 반전";
            this.ckInputWheelInvert.UseVisualStyleBackColor = true;
            //
            // lblInputClickDuration
            //
            this.lblInputClickDuration.AutoSize = true;
            this.lblInputClickDuration.Location = new System.Drawing.Point(19, 59);
            this.lblInputClickDuration.Name = "lblInputClickDuration";
            this.lblInputClickDuration.Size = new System.Drawing.Size(141, 12);
            this.lblInputClickDuration.TabIndex = 1;
            this.lblInputClickDuration.Text = "클릭 최대 누름 시간(ms)";
            //
            // numInputClickDuration
            //
            this.numInputClickDuration.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numInputClickDuration.Location = new System.Drawing.Point(238, 57);
            this.numInputClickDuration.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numInputClickDuration.Name = "numInputClickDuration";
            this.numInputClickDuration.Size = new System.Drawing.Size(100, 21);
            this.numInputClickDuration.TabIndex = 2;
            //
            // lblInputLongPress
            //
            this.lblInputLongPress.AutoSize = true;
            this.lblInputLongPress.Location = new System.Drawing.Point(19, 87);
            this.lblInputLongPress.Name = "lblInputLongPress";
            this.lblInputLongPress.Size = new System.Drawing.Size(141, 12);
            this.lblInputLongPress.TabIndex = 3;
            this.lblInputLongPress.Text = "길게 누름 최소 시간(ms)";
            //
            // numInputLongPress
            //
            this.numInputLongPress.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numInputLongPress.Location = new System.Drawing.Point(238, 85);
            this.numInputLongPress.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numInputLongPress.Name = "numInputLongPress";
            this.numInputLongPress.Size = new System.Drawing.Size(100, 21);
            this.numInputLongPress.TabIndex = 4;
            //
            // lblInputClickTolerance
            //
            this.lblInputClickTolerance.AutoSize = true;
            this.lblInputClickTolerance.Location = new System.Drawing.Point(19, 115);
            this.lblInputClickTolerance.Name = "lblInputClickTolerance";
            this.lblInputClickTolerance.Size = new System.Drawing.Size(119, 12);
            this.lblInputClickTolerance.TabIndex = 5;
            this.lblInputClickTolerance.Text = "클릭 허용 이동(픽셀)";
            //
            // numInputClickTolerance
            //
            this.numInputClickTolerance.Location = new System.Drawing.Point(238, 113);
            this.numInputClickTolerance.Name = "numInputClickTolerance";
            this.numInputClickTolerance.Size = new System.Drawing.Size(100, 21);
            this.numInputClickTolerance.TabIndex = 6;
            //
            // grpInputSpeed
            //
            this.grpInputSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInputSpeed.Controls.Add(this.lblInputWalkSpeed);
            this.grpInputSpeed.Controls.Add(this.numInputWalkSpeed);
            this.grpInputSpeed.Controls.Add(this.lblInputWalkBoost);
            this.grpInputSpeed.Controls.Add(this.numInputWalkBoost);
            this.grpInputSpeed.Controls.Add(this.lblInputFlySpeed);
            this.grpInputSpeed.Controls.Add(this.numInputFlySpeed);
            this.grpInputSpeed.Controls.Add(this.lblInputFlyBoost);
            this.grpInputSpeed.Controls.Add(this.numInputFlyBoost);
            this.grpInputSpeed.Location = new System.Drawing.Point(6, 190);
            this.grpInputSpeed.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpInputSpeed.Name = "grpInputSpeed";
            this.grpInputSpeed.Size = new System.Drawing.Size(590, 150);
            this.grpInputSpeed.TabIndex = 1;
            this.grpInputSpeed.TabStop = false;
            this.grpInputSpeed.Text = "이동 속도";
            //
            // lblInputWalkSpeed
            //
            this.lblInputWalkSpeed.AutoSize = true;
            this.lblInputWalkSpeed.Location = new System.Drawing.Point(19, 31);
            this.lblInputWalkSpeed.Name = "lblInputWalkSpeed";
            this.lblInputWalkSpeed.Size = new System.Drawing.Size(85, 12);
            this.lblInputWalkSpeed.TabIndex = 0;
            this.lblInputWalkSpeed.Text = "보행 속도 배율";
            //
            // numInputWalkSpeed
            //
            this.numInputWalkSpeed.DecimalPlaces = 2;
            this.numInputWalkSpeed.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numInputWalkSpeed.Location = new System.Drawing.Point(238, 29);
            this.numInputWalkSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numInputWalkSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numInputWalkSpeed.Name = "numInputWalkSpeed";
            this.numInputWalkSpeed.Size = new System.Drawing.Size(100, 21);
            this.numInputWalkSpeed.TabIndex = 1;
            this.numInputWalkSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            //
            // lblInputWalkBoost
            //
            this.lblInputWalkBoost.AutoSize = true;
            this.lblInputWalkBoost.Location = new System.Drawing.Point(19, 59);
            this.lblInputWalkBoost.Name = "lblInputWalkBoost";
            this.lblInputWalkBoost.Size = new System.Drawing.Size(85, 12);
            this.lblInputWalkBoost.TabIndex = 2;
            this.lblInputWalkBoost.Text = "보행 가속 배율";
            //
            // numInputWalkBoost
            //
            this.numInputWalkBoost.DecimalPlaces = 2;
            this.numInputWalkBoost.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numInputWalkBoost.Location = new System.Drawing.Point(238, 57);
            this.numInputWalkBoost.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numInputWalkBoost.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numInputWalkBoost.Name = "numInputWalkBoost";
            this.numInputWalkBoost.Size = new System.Drawing.Size(100, 21);
            this.numInputWalkBoost.TabIndex = 3;
            this.numInputWalkBoost.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            //
            // lblInputFlySpeed
            //
            this.lblInputFlySpeed.AutoSize = true;
            this.lblInputFlySpeed.Location = new System.Drawing.Point(19, 87);
            this.lblInputFlySpeed.Name = "lblInputFlySpeed";
            this.lblInputFlySpeed.Size = new System.Drawing.Size(85, 12);
            this.lblInputFlySpeed.TabIndex = 4;
            this.lblInputFlySpeed.Text = "비행 속도 배율";
            //
            // numInputFlySpeed
            //
            this.numInputFlySpeed.DecimalPlaces = 2;
            this.numInputFlySpeed.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numInputFlySpeed.Location = new System.Drawing.Point(238, 85);
            this.numInputFlySpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numInputFlySpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numInputFlySpeed.Name = "numInputFlySpeed";
            this.numInputFlySpeed.Size = new System.Drawing.Size(100, 21);
            this.numInputFlySpeed.TabIndex = 5;
            this.numInputFlySpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            //
            // lblInputFlyBoost
            //
            this.lblInputFlyBoost.AutoSize = true;
            this.lblInputFlyBoost.Location = new System.Drawing.Point(19, 115);
            this.lblInputFlyBoost.Name = "lblInputFlyBoost";
            this.lblInputFlyBoost.Size = new System.Drawing.Size(85, 12);
            this.lblInputFlyBoost.TabIndex = 6;
            this.lblInputFlyBoost.Text = "비행 가속 배율";
            //
            // numInputFlyBoost
            //
            this.numInputFlyBoost.DecimalPlaces = 2;
            this.numInputFlyBoost.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numInputFlyBoost.Location = new System.Drawing.Point(238, 113);
            this.numInputFlyBoost.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numInputFlyBoost.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numInputFlyBoost.Name = "numInputFlyBoost";
            this.numInputFlyBoost.Size = new System.Drawing.Size(100, 21);
            this.numInputFlyBoost.TabIndex = 7;
            this.numInputFlyBoost.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            //
            // grpInputSensitivity
            //
            this.grpInputSensitivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInputSensitivity.Controls.Add(this.lblInputOrbitSens);
            this.grpInputSensitivity.Controls.Add(this.numInputOrbitSens);
            this.grpInputSensitivity.Controls.Add(this.lblInputPanSens);
            this.grpInputSensitivity.Controls.Add(this.numInputPanSens);
            this.grpInputSensitivity.Controls.Add(this.lblInputZoomSens);
            this.grpInputSensitivity.Controls.Add(this.numInputZoomSens);
            this.grpInputSensitivity.Controls.Add(this.lblInputRollSens);
            this.grpInputSensitivity.Controls.Add(this.numInputRollSens);
            this.grpInputSensitivity.Controls.Add(this.lblInputLookSens);
            this.grpInputSensitivity.Controls.Add(this.numInputLookSens);
            this.grpInputSensitivity.Location = new System.Drawing.Point(6, 6);
            this.grpInputSensitivity.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpInputSensitivity.Name = "grpInputSensitivity";
            this.grpInputSensitivity.Size = new System.Drawing.Size(590, 178);
            this.grpInputSensitivity.TabIndex = 0;
            this.grpInputSensitivity.TabStop = false;
            this.grpInputSensitivity.Text = "감도";
            //
            // lblInputOrbitSens
            //
            this.lblInputOrbitSens.AutoSize = true;
            this.lblInputOrbitSens.Location = new System.Drawing.Point(19, 31);
            this.lblInputOrbitSens.Name = "lblInputOrbitSens";
            this.lblInputOrbitSens.Size = new System.Drawing.Size(63, 12);
            this.lblInputOrbitSens.TabIndex = 0;
            this.lblInputOrbitSens.Text = "회전(궤도)";
            //
            // numInputOrbitSens
            //
            this.numInputOrbitSens.DecimalPlaces = 2;
            this.numInputOrbitSens.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numInputOrbitSens.Location = new System.Drawing.Point(238, 29);
            this.numInputOrbitSens.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numInputOrbitSens.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numInputOrbitSens.Name = "numInputOrbitSens";
            this.numInputOrbitSens.Size = new System.Drawing.Size(100, 21);
            this.numInputOrbitSens.TabIndex = 1;
            this.numInputOrbitSens.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            //
            // lblInputPanSens
            //
            this.lblInputPanSens.AutoSize = true;
            this.lblInputPanSens.Location = new System.Drawing.Point(19, 59);
            this.lblInputPanSens.Name = "lblInputPanSens";
            this.lblInputPanSens.Size = new System.Drawing.Size(79, 12);
            this.lblInputPanSens.TabIndex = 2;
            this.lblInputPanSens.Text = "화면 이동(팬)";
            //
            // numInputPanSens
            //
            this.numInputPanSens.DecimalPlaces = 2;
            this.numInputPanSens.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numInputPanSens.Location = new System.Drawing.Point(238, 57);
            this.numInputPanSens.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numInputPanSens.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numInputPanSens.Name = "numInputPanSens";
            this.numInputPanSens.Size = new System.Drawing.Size(100, 21);
            this.numInputPanSens.TabIndex = 3;
            this.numInputPanSens.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            //
            // lblInputZoomSens
            //
            this.lblInputZoomSens.AutoSize = true;
            this.lblInputZoomSens.Location = new System.Drawing.Point(19, 87);
            this.lblInputZoomSens.Name = "lblInputZoomSens";
            this.lblInputZoomSens.Size = new System.Drawing.Size(105, 12);
            this.lblInputZoomSens.TabIndex = 4;
            this.lblInputZoomSens.Text = "확대/축소(드래그)";
            //
            // numInputZoomSens
            //
            this.numInputZoomSens.DecimalPlaces = 2;
            this.numInputZoomSens.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numInputZoomSens.Location = new System.Drawing.Point(238, 85);
            this.numInputZoomSens.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numInputZoomSens.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numInputZoomSens.Name = "numInputZoomSens";
            this.numInputZoomSens.Size = new System.Drawing.Size(100, 21);
            this.numInputZoomSens.TabIndex = 5;
            this.numInputZoomSens.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            //
            // lblInputRollSens
            //
            this.lblInputRollSens.AutoSize = true;
            this.lblInputRollSens.Location = new System.Drawing.Point(19, 115);
            this.lblInputRollSens.Name = "lblInputRollSens";
            this.lblInputRollSens.Size = new System.Drawing.Size(63, 12);
            this.lblInputRollSens.TabIndex = 6;
            this.lblInputRollSens.Text = "기울임(롤)";
            //
            // numInputRollSens
            //
            this.numInputRollSens.DecimalPlaces = 2;
            this.numInputRollSens.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numInputRollSens.Location = new System.Drawing.Point(238, 113);
            this.numInputRollSens.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numInputRollSens.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numInputRollSens.Name = "numInputRollSens";
            this.numInputRollSens.Size = new System.Drawing.Size(100, 21);
            this.numInputRollSens.TabIndex = 7;
            this.numInputRollSens.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            //
            // lblInputLookSens
            //
            this.lblInputLookSens.AutoSize = true;
            this.lblInputLookSens.Location = new System.Drawing.Point(19, 143);
            this.lblInputLookSens.Name = "lblInputLookSens";
            this.lblInputLookSens.Size = new System.Drawing.Size(87, 12);
            this.lblInputLookSens.TabIndex = 8;
            this.lblInputLookSens.Text = "둘러보기(시선)";
            //
            // numInputLookSens
            //
            this.numInputLookSens.DecimalPlaces = 2;
            this.numInputLookSens.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numInputLookSens.Location = new System.Drawing.Point(238, 141);
            this.numInputLookSens.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numInputLookSens.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numInputLookSens.Name = "numInputLookSens";
            this.numInputLookSens.Size = new System.Drawing.Size(100, 21);
            this.numInputLookSens.TabIndex = 9;
            this.numInputLookSens.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            //
            // grpWindowModelingControl
            //
            this.grpWindowModelingControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpWindowModelingControl.Controls.Add(this.ckModelingControl);
            this.grpWindowModelingControl.Controls.Add(this.grpMcSize);
            this.grpWindowModelingControl.Controls.Add(this.grpMcPosition);
            this.grpWindowModelingControl.Controls.Add(this.grpMcColor);
            this.grpWindowModelingControl.Controls.Add(this.grpMcBackground);
            this.grpWindowModelingControl.Controls.Add(this.grpMcBackgroundColor);
            this.grpWindowModelingControl.Controls.Add(this.grpMcOrientation);
            this.grpWindowModelingControl.Location = new System.Drawing.Point(6, 324);
            this.grpWindowModelingControl.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpWindowModelingControl.Name = "grpWindowModelingControl";
            this.grpWindowModelingControl.Size = new System.Drawing.Size(590, 386);
            this.grpWindowModelingControl.TabIndex = 3;
            this.grpWindowModelingControl.TabStop = false;
            this.grpWindowModelingControl.Text = "모델링 컨트롤";
            //
            // ckModelingControl
            //
            this.ckModelingControl.AutoSize = true;
            this.ckModelingControl.Checked = true;
            this.ckModelingControl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckModelingControl.Location = new System.Drawing.Point(15, 22);
            this.ckModelingControl.Name = "ckModelingControl";
            this.ckModelingControl.Size = new System.Drawing.Size(60, 16);
            this.ckModelingControl.TabIndex = 0;
            this.ckModelingControl.Text = "활성화";
            this.ckModelingControl.UseVisualStyleBackColor = true;
            this.ckModelingControl.CheckedChanged += new System.EventHandler(this.ckModelingControl_CheckedChanged);
            //
            // grpMcSize
            //
            this.grpMcSize.Controls.Add(this.rbMcSizeSmall);
            this.grpMcSize.Controls.Add(this.rbMcSizeMedium);
            this.grpMcSize.Controls.Add(this.rbMcSizeLarge);
            this.grpMcSize.Location = new System.Drawing.Point(15, 45);
            this.grpMcSize.Name = "grpMcSize";
            this.grpMcSize.Size = new System.Drawing.Size(339, 50);
            this.grpMcSize.TabIndex = 1;
            this.grpMcSize.TabStop = false;
            this.grpMcSize.Text = "크기";
            //
            // rbMcSizeSmall
            //
            this.rbMcSizeSmall.AutoSize = true;
            this.rbMcSizeSmall.Location = new System.Drawing.Point(15, 20);
            this.rbMcSizeSmall.Name = "rbMcSizeSmall";
            this.rbMcSizeSmall.Size = new System.Drawing.Size(47, 16);
            this.rbMcSizeSmall.TabIndex = 0;
            this.rbMcSizeSmall.Text = "작게";
            this.rbMcSizeSmall.UseVisualStyleBackColor = true;
            //
            // rbMcSizeMedium
            //
            this.rbMcSizeMedium.AutoSize = true;
            this.rbMcSizeMedium.Checked = true;
            this.rbMcSizeMedium.Location = new System.Drawing.Point(110, 20);
            this.rbMcSizeMedium.Name = "rbMcSizeMedium";
            this.rbMcSizeMedium.Size = new System.Drawing.Size(47, 16);
            this.rbMcSizeMedium.TabIndex = 1;
            this.rbMcSizeMedium.TabStop = true;
            this.rbMcSizeMedium.Text = "보통";
            this.rbMcSizeMedium.UseVisualStyleBackColor = true;
            //
            // rbMcSizeLarge
            //
            this.rbMcSizeLarge.AutoSize = true;
            this.rbMcSizeLarge.Location = new System.Drawing.Point(205, 20);
            this.rbMcSizeLarge.Name = "rbMcSizeLarge";
            this.rbMcSizeLarge.Size = new System.Drawing.Size(47, 16);
            this.rbMcSizeLarge.TabIndex = 2;
            this.rbMcSizeLarge.Text = "크게";
            this.rbMcSizeLarge.UseVisualStyleBackColor = true;
            //
            // grpMcPosition
            //
            this.grpMcPosition.Controls.Add(this.rbMcPosTL);
            this.grpMcPosition.Controls.Add(this.rbMcPosTC);
            this.grpMcPosition.Controls.Add(this.rbMcPosTR);
            this.grpMcPosition.Controls.Add(this.rbMcPosBL);
            this.grpMcPosition.Controls.Add(this.rbMcPosBC);
            this.grpMcPosition.Controls.Add(this.rbMcPosBR);
            this.grpMcPosition.Controls.Add(this.rbMcPosLS);
            this.grpMcPosition.Controls.Add(this.rbMcPosRS);
            this.grpMcPosition.Location = new System.Drawing.Point(15, 103);
            this.grpMcPosition.Name = "grpMcPosition";
            this.grpMcPosition.Size = new System.Drawing.Size(339, 97);
            this.grpMcPosition.TabIndex = 2;
            this.grpMcPosition.TabStop = false;
            this.grpMcPosition.Text = "위치";
            //
            // rbMcPosTL
            //
            this.rbMcPosTL.AutoSize = true;
            this.rbMcPosTL.Location = new System.Drawing.Point(15, 20);
            this.rbMcPosTL.Name = "rbMcPosTL";
            this.rbMcPosTL.Size = new System.Drawing.Size(75, 16);
            this.rbMcPosTL.TabIndex = 0;
            this.rbMcPosTL.Text = "좌측 상단";
            this.rbMcPosTL.UseVisualStyleBackColor = true;
            //
            // rbMcPosTC
            //
            this.rbMcPosTC.AutoSize = true;
            this.rbMcPosTC.Location = new System.Drawing.Point(110, 20);
            this.rbMcPosTC.Name = "rbMcPosTC";
            this.rbMcPosTC.Size = new System.Drawing.Size(75, 16);
            this.rbMcPosTC.TabIndex = 1;
            this.rbMcPosTC.Text = "중앙 상단";
            this.rbMcPosTC.UseVisualStyleBackColor = true;
            //
            // rbMcPosTR
            //
            this.rbMcPosTR.AutoSize = true;
            this.rbMcPosTR.Location = new System.Drawing.Point(205, 20);
            this.rbMcPosTR.Name = "rbMcPosTR";
            this.rbMcPosTR.Size = new System.Drawing.Size(75, 16);
            this.rbMcPosTR.TabIndex = 2;
            this.rbMcPosTR.Text = "우측 상단";
            this.rbMcPosTR.UseVisualStyleBackColor = true;
            //
            // rbMcPosBL
            //
            this.rbMcPosBL.AutoSize = true;
            this.rbMcPosBL.Location = new System.Drawing.Point(15, 46);
            this.rbMcPosBL.Name = "rbMcPosBL";
            this.rbMcPosBL.Size = new System.Drawing.Size(75, 16);
            this.rbMcPosBL.TabIndex = 3;
            this.rbMcPosBL.Text = "좌측 하단";
            this.rbMcPosBL.UseVisualStyleBackColor = true;
            //
            // rbMcPosBC
            //
            this.rbMcPosBC.AutoSize = true;
            this.rbMcPosBC.Location = new System.Drawing.Point(110, 46);
            this.rbMcPosBC.Name = "rbMcPosBC";
            this.rbMcPosBC.Size = new System.Drawing.Size(75, 16);
            this.rbMcPosBC.TabIndex = 4;
            this.rbMcPosBC.Text = "중앙 하단";
            this.rbMcPosBC.UseVisualStyleBackColor = true;
            //
            // rbMcPosBR
            //
            this.rbMcPosBR.AutoSize = true;
            this.rbMcPosBR.Location = new System.Drawing.Point(205, 46);
            this.rbMcPosBR.Name = "rbMcPosBR";
            this.rbMcPosBR.Size = new System.Drawing.Size(75, 16);
            this.rbMcPosBR.TabIndex = 5;
            this.rbMcPosBR.Text = "우측 하단";
            this.rbMcPosBR.UseVisualStyleBackColor = true;
            //
            // rbMcPosLS
            //
            this.rbMcPosLS.AutoSize = true;
            this.rbMcPosLS.Location = new System.Drawing.Point(15, 72);
            this.rbMcPosLS.Name = "rbMcPosLS";
            this.rbMcPosLS.Size = new System.Drawing.Size(47, 16);
            this.rbMcPosLS.TabIndex = 6;
            this.rbMcPosLS.Text = "좌측";
            this.rbMcPosLS.UseVisualStyleBackColor = true;
            //
            // rbMcPosRS
            //
            this.rbMcPosRS.AutoSize = true;
            this.rbMcPosRS.Checked = true;
            this.rbMcPosRS.Location = new System.Drawing.Point(110, 72);
            this.rbMcPosRS.Name = "rbMcPosRS";
            this.rbMcPosRS.Size = new System.Drawing.Size(47, 16);
            this.rbMcPosRS.TabIndex = 7;
            this.rbMcPosRS.TabStop = true;
            this.rbMcPosRS.Text = "우측";
            this.rbMcPosRS.UseVisualStyleBackColor = true;
            //
            // grpMcColor
            //
            this.grpMcColor.Controls.Add(this.rbMcColorBlack);
            this.grpMcColor.Controls.Add(this.rbMcColorGray);
            this.grpMcColor.Controls.Add(this.rbMcColorWhite);
            this.grpMcColor.Location = new System.Drawing.Point(15, 208);
            this.grpMcColor.Name = "grpMcColor";
            this.grpMcColor.Size = new System.Drawing.Size(339, 50);
            this.grpMcColor.TabIndex = 3;
            this.grpMcColor.TabStop = false;
            this.grpMcColor.Text = "색상";
            //
            // rbMcColorBlack
            //
            this.rbMcColorBlack.AutoSize = true;
            this.rbMcColorBlack.Location = new System.Drawing.Point(15, 20);
            this.rbMcColorBlack.Name = "rbMcColorBlack";
            this.rbMcColorBlack.Size = new System.Drawing.Size(47, 16);
            this.rbMcColorBlack.TabIndex = 0;
            this.rbMcColorBlack.Text = "검정";
            this.rbMcColorBlack.UseVisualStyleBackColor = true;
            //
            // rbMcColorGray
            //
            this.rbMcColorGray.AutoSize = true;
            this.rbMcColorGray.Checked = true;
            this.rbMcColorGray.Location = new System.Drawing.Point(110, 20);
            this.rbMcColorGray.Name = "rbMcColorGray";
            this.rbMcColorGray.Size = new System.Drawing.Size(47, 16);
            this.rbMcColorGray.TabIndex = 1;
            this.rbMcColorGray.TabStop = true;
            this.rbMcColorGray.Text = "회색";
            this.rbMcColorGray.UseVisualStyleBackColor = true;
            //
            // rbMcColorWhite
            //
            this.rbMcColorWhite.AutoSize = true;
            this.rbMcColorWhite.Location = new System.Drawing.Point(205, 20);
            this.rbMcColorWhite.Name = "rbMcColorWhite";
            this.rbMcColorWhite.Size = new System.Drawing.Size(47, 16);
            this.rbMcColorWhite.TabIndex = 2;
            this.rbMcColorWhite.Text = "흰색";
            this.rbMcColorWhite.UseVisualStyleBackColor = true;
            //
            // grpMcBackground
            //
            this.grpMcBackground.Controls.Add(this.rbMcBgTransparent);
            this.grpMcBackground.Controls.Add(this.rbMcBgSemi);
            this.grpMcBackground.Controls.Add(this.rbMcBgColored);
            this.grpMcBackground.Location = new System.Drawing.Point(15, 266);
            this.grpMcBackground.Name = "grpMcBackground";
            this.grpMcBackground.Size = new System.Drawing.Size(339, 50);
            this.grpMcBackground.TabIndex = 4;
            this.grpMcBackground.TabStop = false;
            this.grpMcBackground.Text = "배경";
            //
            // rbMcBgTransparent
            //
            this.rbMcBgTransparent.AutoSize = true;
            this.rbMcBgTransparent.Location = new System.Drawing.Point(15, 20);
            this.rbMcBgTransparent.Name = "rbMcBgTransparent";
            this.rbMcBgTransparent.Size = new System.Drawing.Size(47, 16);
            this.rbMcBgTransparent.TabIndex = 0;
            this.rbMcBgTransparent.Text = "투명";
            this.rbMcBgTransparent.UseVisualStyleBackColor = true;
            this.rbMcBgTransparent.CheckedChanged += new System.EventHandler(this.rbMcBackground_CheckedChanged);
            //
            // rbMcBgSemi
            //
            this.rbMcBgSemi.AutoSize = true;
            this.rbMcBgSemi.Location = new System.Drawing.Point(110, 20);
            this.rbMcBgSemi.Name = "rbMcBgSemi";
            this.rbMcBgSemi.Size = new System.Drawing.Size(59, 16);
            this.rbMcBgSemi.TabIndex = 1;
            this.rbMcBgSemi.Text = "반투명";
            this.rbMcBgSemi.UseVisualStyleBackColor = true;
            this.rbMcBgSemi.CheckedChanged += new System.EventHandler(this.rbMcBackground_CheckedChanged);
            //
            // rbMcBgColored
            //
            this.rbMcBgColored.AutoSize = true;
            this.rbMcBgColored.Checked = true;
            this.rbMcBgColored.Location = new System.Drawing.Point(205, 20);
            this.rbMcBgColored.Name = "rbMcBgColored";
            this.rbMcBgColored.Size = new System.Drawing.Size(47, 16);
            this.rbMcBgColored.TabIndex = 2;
            this.rbMcBgColored.TabStop = true;
            this.rbMcBgColored.Text = "색상";
            this.rbMcBgColored.UseVisualStyleBackColor = true;
            this.rbMcBgColored.CheckedChanged += new System.EventHandler(this.rbMcBackground_CheckedChanged);
            //
            // grpMcBackgroundColor
            //
            this.grpMcBackgroundColor.Controls.Add(this.rbMcBgColorBlack);
            this.grpMcBackgroundColor.Controls.Add(this.rbMcBgColorGray);
            this.grpMcBackgroundColor.Controls.Add(this.rbMcBgColorWhite);
            this.grpMcBackgroundColor.Location = new System.Drawing.Point(15, 324);
            this.grpMcBackgroundColor.Name = "grpMcBackgroundColor";
            this.grpMcBackgroundColor.Size = new System.Drawing.Size(339, 50);
            this.grpMcBackgroundColor.TabIndex = 5;
            this.grpMcBackgroundColor.TabStop = false;
            this.grpMcBackgroundColor.Text = "배경 색상";
            //
            // rbMcBgColorBlack
            //
            this.rbMcBgColorBlack.AutoSize = true;
            this.rbMcBgColorBlack.Location = new System.Drawing.Point(15, 20);
            this.rbMcBgColorBlack.Name = "rbMcBgColorBlack";
            this.rbMcBgColorBlack.Size = new System.Drawing.Size(47, 16);
            this.rbMcBgColorBlack.TabIndex = 0;
            this.rbMcBgColorBlack.Text = "검정";
            this.rbMcBgColorBlack.UseVisualStyleBackColor = true;
            //
            // rbMcBgColorGray
            //
            this.rbMcBgColorGray.AutoSize = true;
            this.rbMcBgColorGray.Location = new System.Drawing.Point(110, 20);
            this.rbMcBgColorGray.Name = "rbMcBgColorGray";
            this.rbMcBgColorGray.Size = new System.Drawing.Size(47, 16);
            this.rbMcBgColorGray.TabIndex = 1;
            this.rbMcBgColorGray.Text = "회색";
            this.rbMcBgColorGray.UseVisualStyleBackColor = true;
            //
            // rbMcBgColorWhite
            //
            this.rbMcBgColorWhite.AutoSize = true;
            this.rbMcBgColorWhite.Checked = true;
            this.rbMcBgColorWhite.Location = new System.Drawing.Point(205, 20);
            this.rbMcBgColorWhite.Name = "rbMcBgColorWhite";
            this.rbMcBgColorWhite.Size = new System.Drawing.Size(47, 16);
            this.rbMcBgColorWhite.TabIndex = 2;
            this.rbMcBgColorWhite.TabStop = true;
            this.rbMcBgColorWhite.Text = "흰색";
            this.rbMcBgColorWhite.UseVisualStyleBackColor = true;
            //
            // grpMcOrientation
            //
            this.grpMcOrientation.Controls.Add(this.rbMcOrientH);
            this.grpMcOrientation.Controls.Add(this.rbMcOrientV);
            this.grpMcOrientation.Location = new System.Drawing.Point(360, 45);
            this.grpMcOrientation.Name = "grpMcOrientation";
            this.grpMcOrientation.Size = new System.Drawing.Size(218, 50);
            this.grpMcOrientation.TabIndex = 6;
            this.grpMcOrientation.TabStop = false;
            this.grpMcOrientation.Text = "방향";
            //
            // rbMcOrientH
            //
            this.rbMcOrientH.AutoSize = true;
            this.rbMcOrientH.Location = new System.Drawing.Point(15, 20);
            this.rbMcOrientH.Name = "rbMcOrientH";
            this.rbMcOrientH.Size = new System.Drawing.Size(47, 16);
            this.rbMcOrientH.TabIndex = 0;
            this.rbMcOrientH.Text = "수평";
            this.rbMcOrientH.UseVisualStyleBackColor = true;
            //
            // rbMcOrientV
            //
            this.rbMcOrientV.AutoSize = true;
            this.rbMcOrientV.Checked = true;
            this.rbMcOrientV.Location = new System.Drawing.Point(110, 20);
            this.rbMcOrientV.Name = "rbMcOrientV";
            this.rbMcOrientV.Size = new System.Drawing.Size(47, 16);
            this.rbMcOrientV.TabIndex = 1;
            this.rbMcOrientV.TabStop = true;
            this.rbMcOrientV.Text = "수직";
            this.rbMcOrientV.UseVisualStyleBackColor = true;
            //
            // tpNote
            //
            this.tpNote.AutoScroll = true;
            this.tpNote.Controls.Add(this.grpNoteSymbol);
            this.tpNote.Controls.Add(this.grpNoteStyle);
            this.tpNote.Location = new System.Drawing.Point(4, 40);
            this.tpNote.Name = "tpNote";
            this.tpNote.Padding = new System.Windows.Forms.Padding(3);
            this.tpNote.Size = new System.Drawing.Size(668, 614);
            this.tpNote.TabIndex = 7;
            this.tpNote.Text = "노트";
            this.tpNote.UseVisualStyleBackColor = true;
            //
            // grpNoteSymbol
            //
            this.grpNoteSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNoteSymbol.Controls.Add(this.txtNoteSymbolSize);
            this.grpNoteSymbol.Controls.Add(this.btnNoteSymbolTextColor);
            this.grpNoteSymbol.Controls.Add(this.cbNoteSymbolTextSize);
            this.grpNoteSymbol.Controls.Add(this.btnNoteSymbolStrokeColor);
            this.grpNoteSymbol.Controls.Add(this.btnNoteSymbolFillColor);
            this.grpNoteSymbol.Controls.Add(this.label43);
            this.grpNoteSymbol.Controls.Add(this.label44);
            this.grpNoteSymbol.Controls.Add(this.label48);
            this.grpNoteSymbol.Controls.Add(this.label45);
            this.grpNoteSymbol.Controls.Add(this.label46);
            this.grpNoteSymbol.Location = new System.Drawing.Point(6, 275);
            this.grpNoteSymbol.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpNoteSymbol.Name = "grpNoteSymbol";
            this.grpNoteSymbol.Size = new System.Drawing.Size(590, 137);
            this.grpNoteSymbol.TabIndex = 13;
            this.grpNoteSymbol.TabStop = false;
            this.grpNoteSymbol.Text = "심벌 옵션";
            //
            // txtNoteSymbolSize
            //
            this.txtNoteSymbolSize.Location = new System.Drawing.Point(421, 30);
            this.txtNoteSymbolSize.Name = "txtNoteSymbolSize";
            this.txtNoteSymbolSize.Size = new System.Drawing.Size(75, 21);
            this.txtNoteSymbolSize.TabIndex = 22;
            //
            // btnNoteSymbolTextColor
            //
            this.btnNoteSymbolTextColor.Location = new System.Drawing.Point(421, 61);
            this.btnNoteSymbolTextColor.Name = "btnNoteSymbolTextColor";
            this.btnNoteSymbolTextColor.Size = new System.Drawing.Size(75, 23);
            this.btnNoteSymbolTextColor.TabIndex = 21;
            this.btnNoteSymbolTextColor.UseVisualStyleBackColor = false;
            this.btnNoteSymbolTextColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // cbNoteSymbolTextSize
            //
            this.cbNoteSymbolTextSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNoteSymbolTextSize.FormattingEnabled = true;
            this.cbNoteSymbolTextSize.Location = new System.Drawing.Point(421, 96);
            this.cbNoteSymbolTextSize.Name = "cbNoteSymbolTextSize";
            this.cbNoteSymbolTextSize.Size = new System.Drawing.Size(75, 20);
            this.cbNoteSymbolTextSize.TabIndex = 21;
            //
            // btnNoteSymbolStrokeColor
            //
            this.btnNoteSymbolStrokeColor.Location = new System.Drawing.Point(171, 61);
            this.btnNoteSymbolStrokeColor.Name = "btnNoteSymbolStrokeColor";
            this.btnNoteSymbolStrokeColor.Size = new System.Drawing.Size(75, 23);
            this.btnNoteSymbolStrokeColor.TabIndex = 22;
            this.btnNoteSymbolStrokeColor.UseVisualStyleBackColor = false;
            this.btnNoteSymbolStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnNoteSymbolFillColor
            //
            this.btnNoteSymbolFillColor.Location = new System.Drawing.Point(171, 28);
            this.btnNoteSymbolFillColor.Name = "btnNoteSymbolFillColor";
            this.btnNoteSymbolFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnNoteSymbolFillColor.TabIndex = 21;
            this.btnNoteSymbolFillColor.UseVisualStyleBackColor = false;
            this.btnNoteSymbolFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label43
            //
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(316, 66);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(69, 12);
            this.label43.TabIndex = 25;
            this.label43.Text = "심벌 글자색";
            //
            // label44
            //
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(316, 99);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(85, 12);
            this.label44.TabIndex = 24;
            this.label44.Text = "심벌 글자 크기";
            //
            // label48
            //
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(26, 33);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(69, 12);
            this.label48.TabIndex = 21;
            this.label48.Text = "심벌 배경색";
            //
            // label45
            //
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(316, 33);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(57, 12);
            this.label45.TabIndex = 23;
            this.label45.Text = "심벌 크기";
            //
            // label46
            //
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(26, 66);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(69, 12);
            this.label46.TabIndex = 22;
            this.label46.Text = "심벌 라인색";
            //
            // grpNoteStyle
            //
            this.grpNoteStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNoteStyle.Controls.Add(this.cbNoteTextHorizontalAlignment);
            this.grpNoteStyle.Controls.Add(this.label75);
            this.grpNoteStyle.Controls.Add(this.cbNoteLineStrokePattern);
            this.grpNoteStyle.Controls.Add(this.label51);
            this.grpNoteStyle.Controls.Add(this.txtNoteArrowSize);
            this.grpNoteStyle.Controls.Add(this.txtNoteLineWidth);
            this.grpNoteStyle.Controls.Add(this.cbNoteFontSize);
            this.grpNoteStyle.Controls.Add(this.btnNoteArrowColor);
            this.grpNoteStyle.Controls.Add(this.btnNoteLineColor);
            this.grpNoteStyle.Controls.Add(this.btnNoteTextColor);
            this.grpNoteStyle.Controls.Add(this.btnNoteSelectedBoxStrokeColor);
            this.grpNoteStyle.Controls.Add(this.btnNoteHighlightedBoxStrokeColor);
            this.grpNoteStyle.Controls.Add(this.btnNoteHighlightedBoxFillColor);
            this.grpNoteStyle.Controls.Add(this.btnNoteBoxStrokeColor);
            this.grpNoteStyle.Controls.Add(this.btnNoteBoxFillColor);
            this.grpNoteStyle.Controls.Add(this.label32);
            this.grpNoteStyle.Controls.Add(this.label33);
            this.grpNoteStyle.Controls.Add(this.label34);
            this.grpNoteStyle.Controls.Add(this.label35);
            this.grpNoteStyle.Controls.Add(this.label36);
            this.grpNoteStyle.Controls.Add(this.label37);
            this.grpNoteStyle.Controls.Add(this.label38);
            this.grpNoteStyle.Controls.Add(this.label39);
            this.grpNoteStyle.Controls.Add(this.label40);
            this.grpNoteStyle.Controls.Add(this.label41);
            this.grpNoteStyle.Controls.Add(this.label42);
            this.grpNoteStyle.Location = new System.Drawing.Point(6, 6);
            this.grpNoteStyle.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpNoteStyle.Name = "grpNoteStyle";
            this.grpNoteStyle.Size = new System.Drawing.Size(590, 263);
            this.grpNoteStyle.TabIndex = 12;
            this.grpNoteStyle.TabStop = false;
            this.grpNoteStyle.Text = "스타일";
            //
            // cbNoteTextHorizontalAlignment
            //
            this.cbNoteTextHorizontalAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNoteTextHorizontalAlignment.FormattingEnabled = true;
            this.cbNoteTextHorizontalAlignment.Location = new System.Drawing.Point(421, 96);
            this.cbNoteTextHorizontalAlignment.Name = "cbNoteTextHorizontalAlignment";
            this.cbNoteTextHorizontalAlignment.Size = new System.Drawing.Size(75, 20);
            this.cbNoteTextHorizontalAlignment.TabIndex = 25;
            //
            // label75
            //
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(316, 99);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(57, 12);
            this.label75.TabIndex = 24;
            this.label75.Text = "글자 정렬";
            //
            // cbNoteLineStrokePattern
            //
            this.cbNoteLineStrokePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNoteLineStrokePattern.FormattingEnabled = true;
            this.cbNoteLineStrokePattern.Location = new System.Drawing.Point(422, 196);
            this.cbNoteLineStrokePattern.Name = "cbNoteLineStrokePattern";
            this.cbNoteLineStrokePattern.Size = new System.Drawing.Size(110, 20);
            this.cbNoteLineStrokePattern.TabIndex = 23;
            //
            // label51
            //
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(316, 198);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(45, 12);
            this.label51.TabIndex = 22;
            this.label51.Text = "선 패턴";
            //
            // txtNoteArrowSize
            //
            this.txtNoteArrowSize.Location = new System.Drawing.Point(421, 228);
            this.txtNoteArrowSize.Name = "txtNoteArrowSize";
            this.txtNoteArrowSize.Size = new System.Drawing.Size(75, 21);
            this.txtNoteArrowSize.TabIndex = 21;
            //
            // txtNoteLineWidth
            //
            this.txtNoteLineWidth.Location = new System.Drawing.Point(421, 162);
            this.txtNoteLineWidth.Name = "txtNoteLineWidth";
            this.txtNoteLineWidth.Size = new System.Drawing.Size(75, 21);
            this.txtNoteLineWidth.TabIndex = 14;
            //
            // cbNoteFontSize
            //
            this.cbNoteFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNoteFontSize.FormattingEnabled = true;
            this.cbNoteFontSize.Location = new System.Drawing.Point(421, 63);
            this.cbNoteFontSize.Name = "cbNoteFontSize";
            this.cbNoteFontSize.Size = new System.Drawing.Size(75, 20);
            this.cbNoteFontSize.TabIndex = 20;
            //
            // btnNoteArrowColor
            //
            this.btnNoteArrowColor.Location = new System.Drawing.Point(171, 193);
            this.btnNoteArrowColor.Name = "btnNoteArrowColor";
            this.btnNoteArrowColor.Size = new System.Drawing.Size(75, 23);
            this.btnNoteArrowColor.TabIndex = 18;
            this.btnNoteArrowColor.UseVisualStyleBackColor = false;
            this.btnNoteArrowColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnNoteLineColor
            //
            this.btnNoteLineColor.Location = new System.Drawing.Point(421, 127);
            this.btnNoteLineColor.Name = "btnNoteLineColor";
            this.btnNoteLineColor.Size = new System.Drawing.Size(75, 23);
            this.btnNoteLineColor.TabIndex = 17;
            this.btnNoteLineColor.UseVisualStyleBackColor = false;
            this.btnNoteLineColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnNoteTextColor
            //
            this.btnNoteTextColor.Location = new System.Drawing.Point(421, 28);
            this.btnNoteTextColor.Name = "btnNoteTextColor";
            this.btnNoteTextColor.Size = new System.Drawing.Size(75, 23);
            this.btnNoteTextColor.TabIndex = 16;
            this.btnNoteTextColor.UseVisualStyleBackColor = false;
            this.btnNoteTextColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnNoteSelectedBoxStrokeColor
            //
            this.btnNoteSelectedBoxStrokeColor.Location = new System.Drawing.Point(171, 160);
            this.btnNoteSelectedBoxStrokeColor.Name = "btnNoteSelectedBoxStrokeColor";
            this.btnNoteSelectedBoxStrokeColor.Size = new System.Drawing.Size(75, 23);
            this.btnNoteSelectedBoxStrokeColor.TabIndex = 15;
            this.btnNoteSelectedBoxStrokeColor.UseVisualStyleBackColor = false;
            this.btnNoteSelectedBoxStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnNoteHighlightedBoxStrokeColor
            //
            this.btnNoteHighlightedBoxStrokeColor.Location = new System.Drawing.Point(171, 127);
            this.btnNoteHighlightedBoxStrokeColor.Name = "btnNoteHighlightedBoxStrokeColor";
            this.btnNoteHighlightedBoxStrokeColor.Size = new System.Drawing.Size(75, 23);
            this.btnNoteHighlightedBoxStrokeColor.TabIndex = 14;
            this.btnNoteHighlightedBoxStrokeColor.UseVisualStyleBackColor = false;
            this.btnNoteHighlightedBoxStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnNoteHighlightedBoxFillColor
            //
            this.btnNoteHighlightedBoxFillColor.Location = new System.Drawing.Point(171, 94);
            this.btnNoteHighlightedBoxFillColor.Name = "btnNoteHighlightedBoxFillColor";
            this.btnNoteHighlightedBoxFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnNoteHighlightedBoxFillColor.TabIndex = 13;
            this.btnNoteHighlightedBoxFillColor.UseVisualStyleBackColor = false;
            this.btnNoteHighlightedBoxFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnNoteBoxStrokeColor
            //
            this.btnNoteBoxStrokeColor.Location = new System.Drawing.Point(171, 61);
            this.btnNoteBoxStrokeColor.Name = "btnNoteBoxStrokeColor";
            this.btnNoteBoxStrokeColor.Size = new System.Drawing.Size(75, 23);
            this.btnNoteBoxStrokeColor.TabIndex = 12;
            this.btnNoteBoxStrokeColor.UseVisualStyleBackColor = false;
            this.btnNoteBoxStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnNoteBoxFillColor
            //
            this.btnNoteBoxFillColor.Location = new System.Drawing.Point(171, 28);
            this.btnNoteBoxFillColor.Name = "btnNoteBoxFillColor";
            this.btnNoteBoxFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnNoteBoxFillColor.TabIndex = 11;
            this.btnNoteBoxFillColor.UseVisualStyleBackColor = false;
            this.btnNoteBoxFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label32
            //
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(316, 231);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(69, 12);
            this.label32.TabIndex = 10;
            this.label32.Text = "화살표 크기";
            //
            // label33
            //
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(26, 198);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(69, 12);
            this.label33.TabIndex = 9;
            this.label33.Text = "화살표 색상";
            //
            // label34
            //
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(316, 165);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(45, 12);
            this.label34.TabIndex = 8;
            this.label34.Text = "선 두께";
            //
            // label35
            //
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(316, 132);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(45, 12);
            this.label35.TabIndex = 7;
            this.label35.Text = "선 색상";
            //
            // label36
            //
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(316, 66);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(57, 12);
            this.label36.TabIndex = 6;
            this.label36.Text = "글자 크기";
            //
            // label37
            //
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(316, 33);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(41, 12);
            this.label37.TabIndex = 5;
            this.label37.Text = "글자색";
            //
            // label38
            //
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(26, 132);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(97, 12);
            this.label38.TabIndex = 4;
            this.label38.Text = "강조 박스 라인색";
            //
            // label39
            //
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(26, 165);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(97, 12);
            this.label39.TabIndex = 3;
            this.label39.Text = "선택 박스 라인색";
            //
            // label40
            //
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(26, 99);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(97, 12);
            this.label40.TabIndex = 2;
            this.label40.Text = "강조 박스 배경색";
            //
            // label41
            //
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(26, 66);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(69, 12);
            this.label41.TabIndex = 1;
            this.label41.Text = "박스 라인색";
            //
            // label42
            //
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(26, 33);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(69, 12);
            this.label42.TabIndex = 0;
            this.label42.Text = "박스 배경색";
            //
            // tpMeasure
            //
            this.tpMeasure.AutoScroll = true;
            this.tpMeasure.Controls.Add(this.grpMeasureSnap);
            this.tpMeasure.Controls.Add(this.grpMeasureStyle);
            this.tpMeasure.Controls.Add(this.grpMeasureOption);
            this.tpMeasure.Location = new System.Drawing.Point(4, 40);
            this.tpMeasure.Name = "tpMeasure";
            this.tpMeasure.Padding = new System.Windows.Forms.Padding(3);
            this.tpMeasure.Size = new System.Drawing.Size(668, 614);
            this.tpMeasure.TabIndex = 8;
            this.tpMeasure.Text = "측정";
            this.tpMeasure.UseVisualStyleBackColor = true;
            //
            // grpMeasureSnap
            //
            this.grpMeasureSnap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMeasureSnap.Controls.Add(this.numMeasureSnapCylinderAxisSize);
            this.grpMeasureSnap.Controls.Add(this.numMeasureSnapPointSize);
            this.grpMeasureSnap.Controls.Add(this.numMeasureSnapPlaneSize);
            this.grpMeasureSnap.Controls.Add(this.label86);
            this.grpMeasureSnap.Controls.Add(this.label87);
            this.grpMeasureSnap.Controls.Add(this.label88);
            this.grpMeasureSnap.Location = new System.Drawing.Point(6, 482);
            this.grpMeasureSnap.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpMeasureSnap.Name = "grpMeasureSnap";
            this.grpMeasureSnap.Size = new System.Drawing.Size(590, 112);
            this.grpMeasureSnap.TabIndex = 28;
            this.grpMeasureSnap.TabStop = false;
            this.grpMeasureSnap.Text = "측정 스냅";
            //
            // numMeasureSnapCylinderAxisSize
            //
            this.numMeasureSnapCylinderAxisSize.DecimalPlaces = 1;
            this.numMeasureSnapCylinderAxisSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMeasureSnapCylinderAxisSize.Location = new System.Drawing.Point(172, 78);
            this.numMeasureSnapCylinderAxisSize.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numMeasureSnapCylinderAxisSize.Name = "numMeasureSnapCylinderAxisSize";
            this.numMeasureSnapCylinderAxisSize.Size = new System.Drawing.Size(120, 21);
            this.numMeasureSnapCylinderAxisSize.TabIndex = 5;
            //
            // numMeasureSnapPointSize
            //
            this.numMeasureSnapPointSize.DecimalPlaces = 1;
            this.numMeasureSnapPointSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMeasureSnapPointSize.Location = new System.Drawing.Point(172, 48);
            this.numMeasureSnapPointSize.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numMeasureSnapPointSize.Name = "numMeasureSnapPointSize";
            this.numMeasureSnapPointSize.Size = new System.Drawing.Size(120, 21);
            this.numMeasureSnapPointSize.TabIndex = 4;
            //
            // numMeasureSnapPlaneSize
            //
            this.numMeasureSnapPlaneSize.DecimalPlaces = 1;
            this.numMeasureSnapPlaneSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMeasureSnapPlaneSize.Location = new System.Drawing.Point(172, 20);
            this.numMeasureSnapPlaneSize.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numMeasureSnapPlaneSize.Name = "numMeasureSnapPlaneSize";
            this.numMeasureSnapPlaneSize.Size = new System.Drawing.Size(120, 21);
            this.numMeasureSnapPlaneSize.TabIndex = 3;
            this.numMeasureSnapPlaneSize.ThousandsSeparator = true;
            //
            // label86
            //
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(22, 50);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(73, 12);
            this.label86.TabIndex = 2;
            this.label86.Text = "스냅 점 크기";
            //
            // label87
            //
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(22, 25);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(85, 12);
            this.label87.TabIndex = 1;
            this.label87.Text = "스냅 평면 크기";
            //
            // label88
            //
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(22, 75);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(101, 12);
            this.label88.TabIndex = 0;
            this.label88.Text = "스냅 원통 축 크기";
            //
            // grpMeasureStyle
            //
            this.grpMeasureStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMeasureStyle.Controls.Add(this.cbMeasureTextHorizontalAlignment);
            this.grpMeasureStyle.Controls.Add(this.label76);
            this.grpMeasureStyle.Controls.Add(this.cbMeasureLineStrokePattern);
            this.grpMeasureStyle.Controls.Add(this.label65);
            this.grpMeasureStyle.Controls.Add(this.txtMeasureArrowSize);
            this.grpMeasureStyle.Controls.Add(this.txtMeasureLineWidth);
            this.grpMeasureStyle.Controls.Add(this.cbMeasureFontSize);
            this.grpMeasureStyle.Controls.Add(this.btnMeasureArrowColor);
            this.grpMeasureStyle.Controls.Add(this.btnMeasureLineColor);
            this.grpMeasureStyle.Controls.Add(this.btnMeasureTextColor);
            this.grpMeasureStyle.Controls.Add(this.btnMeasureSelectedBoxStrokeColor);
            this.grpMeasureStyle.Controls.Add(this.btnMeasureHighlightedBoxStrokeColor);
            this.grpMeasureStyle.Controls.Add(this.btnMeasureHighlightedBoxFillColor);
            this.grpMeasureStyle.Controls.Add(this.btnMeasureBoxStrokeColor);
            this.grpMeasureStyle.Controls.Add(this.btnMeasureBoxFillColor);
            this.grpMeasureStyle.Controls.Add(this.label54);
            this.grpMeasureStyle.Controls.Add(this.label55);
            this.grpMeasureStyle.Controls.Add(this.label56);
            this.grpMeasureStyle.Controls.Add(this.label57);
            this.grpMeasureStyle.Controls.Add(this.label58);
            this.grpMeasureStyle.Controls.Add(this.label59);
            this.grpMeasureStyle.Controls.Add(this.label60);
            this.grpMeasureStyle.Controls.Add(this.label61);
            this.grpMeasureStyle.Controls.Add(this.label62);
            this.grpMeasureStyle.Controls.Add(this.label63);
            this.grpMeasureStyle.Controls.Add(this.label64);
            this.grpMeasureStyle.Location = new System.Drawing.Point(6, 213);
            this.grpMeasureStyle.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpMeasureStyle.Name = "grpMeasureStyle";
            this.grpMeasureStyle.Size = new System.Drawing.Size(590, 263);
            this.grpMeasureStyle.TabIndex = 11;
            this.grpMeasureStyle.TabStop = false;
            this.grpMeasureStyle.Text = "스타일";
            //
            // cbMeasureTextHorizontalAlignment
            //
            this.cbMeasureTextHorizontalAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMeasureTextHorizontalAlignment.FormattingEnabled = true;
            this.cbMeasureTextHorizontalAlignment.Location = new System.Drawing.Point(433, 96);
            this.cbMeasureTextHorizontalAlignment.Name = "cbMeasureTextHorizontalAlignment";
            this.cbMeasureTextHorizontalAlignment.Size = new System.Drawing.Size(75, 20);
            this.cbMeasureTextHorizontalAlignment.TabIndex = 27;
            //
            // label76
            //
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(320, 99);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(57, 12);
            this.label76.TabIndex = 26;
            this.label76.Text = "글자 정렬";
            //
            // cbMeasureLineStrokePattern
            //
            this.cbMeasureLineStrokePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMeasureLineStrokePattern.FormattingEnabled = true;
            this.cbMeasureLineStrokePattern.Location = new System.Drawing.Point(433, 196);
            this.cbMeasureLineStrokePattern.Name = "cbMeasureLineStrokePattern";
            this.cbMeasureLineStrokePattern.Size = new System.Drawing.Size(110, 20);
            this.cbMeasureLineStrokePattern.TabIndex = 25;
            //
            // label65
            //
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(320, 198);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(45, 12);
            this.label65.TabIndex = 24;
            this.label65.Text = "선 패턴";
            //
            // txtMeasureArrowSize
            //
            this.txtMeasureArrowSize.Location = new System.Drawing.Point(433, 228);
            this.txtMeasureArrowSize.Name = "txtMeasureArrowSize";
            this.txtMeasureArrowSize.Size = new System.Drawing.Size(75, 21);
            this.txtMeasureArrowSize.TabIndex = 22;
            //
            // txtMeasureLineWidth
            //
            this.txtMeasureLineWidth.Location = new System.Drawing.Point(433, 162);
            this.txtMeasureLineWidth.Name = "txtMeasureLineWidth";
            this.txtMeasureLineWidth.Size = new System.Drawing.Size(75, 21);
            this.txtMeasureLineWidth.TabIndex = 21;
            //
            // cbMeasureFontSize
            //
            this.cbMeasureFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMeasureFontSize.FormattingEnabled = true;
            this.cbMeasureFontSize.Location = new System.Drawing.Point(433, 63);
            this.cbMeasureFontSize.Name = "cbMeasureFontSize";
            this.cbMeasureFontSize.Size = new System.Drawing.Size(75, 20);
            this.cbMeasureFontSize.TabIndex = 20;
            //
            // btnMeasureArrowColor
            //
            this.btnMeasureArrowColor.Location = new System.Drawing.Point(178, 193);
            this.btnMeasureArrowColor.Name = "btnMeasureArrowColor";
            this.btnMeasureArrowColor.Size = new System.Drawing.Size(75, 23);
            this.btnMeasureArrowColor.TabIndex = 18;
            this.btnMeasureArrowColor.UseVisualStyleBackColor = false;
            this.btnMeasureArrowColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnMeasureLineColor
            //
            this.btnMeasureLineColor.Location = new System.Drawing.Point(433, 127);
            this.btnMeasureLineColor.Name = "btnMeasureLineColor";
            this.btnMeasureLineColor.Size = new System.Drawing.Size(75, 23);
            this.btnMeasureLineColor.TabIndex = 17;
            this.btnMeasureLineColor.UseVisualStyleBackColor = false;
            this.btnMeasureLineColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnMeasureTextColor
            //
            this.btnMeasureTextColor.Location = new System.Drawing.Point(433, 28);
            this.btnMeasureTextColor.Name = "btnMeasureTextColor";
            this.btnMeasureTextColor.Size = new System.Drawing.Size(75, 23);
            this.btnMeasureTextColor.TabIndex = 16;
            this.btnMeasureTextColor.UseVisualStyleBackColor = false;
            this.btnMeasureTextColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnMeasureSelectedBoxStrokeColor
            //
            this.btnMeasureSelectedBoxStrokeColor.Location = new System.Drawing.Point(178, 160);
            this.btnMeasureSelectedBoxStrokeColor.Name = "btnMeasureSelectedBoxStrokeColor";
            this.btnMeasureSelectedBoxStrokeColor.Size = new System.Drawing.Size(75, 23);
            this.btnMeasureSelectedBoxStrokeColor.TabIndex = 15;
            this.btnMeasureSelectedBoxStrokeColor.UseVisualStyleBackColor = false;
            this.btnMeasureSelectedBoxStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnMeasureHighlightedBoxStrokeColor
            //
            this.btnMeasureHighlightedBoxStrokeColor.Location = new System.Drawing.Point(178, 127);
            this.btnMeasureHighlightedBoxStrokeColor.Name = "btnMeasureHighlightedBoxStrokeColor";
            this.btnMeasureHighlightedBoxStrokeColor.Size = new System.Drawing.Size(75, 23);
            this.btnMeasureHighlightedBoxStrokeColor.TabIndex = 14;
            this.btnMeasureHighlightedBoxStrokeColor.UseVisualStyleBackColor = false;
            this.btnMeasureHighlightedBoxStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnMeasureHighlightedBoxFillColor
            //
            this.btnMeasureHighlightedBoxFillColor.Location = new System.Drawing.Point(178, 94);
            this.btnMeasureHighlightedBoxFillColor.Name = "btnMeasureHighlightedBoxFillColor";
            this.btnMeasureHighlightedBoxFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnMeasureHighlightedBoxFillColor.TabIndex = 13;
            this.btnMeasureHighlightedBoxFillColor.UseVisualStyleBackColor = false;
            this.btnMeasureHighlightedBoxFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnMeasureBoxStrokeColor
            //
            this.btnMeasureBoxStrokeColor.Location = new System.Drawing.Point(178, 61);
            this.btnMeasureBoxStrokeColor.Name = "btnMeasureBoxStrokeColor";
            this.btnMeasureBoxStrokeColor.Size = new System.Drawing.Size(75, 23);
            this.btnMeasureBoxStrokeColor.TabIndex = 12;
            this.btnMeasureBoxStrokeColor.UseVisualStyleBackColor = false;
            this.btnMeasureBoxStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnMeasureBoxFillColor
            //
            this.btnMeasureBoxFillColor.Location = new System.Drawing.Point(178, 28);
            this.btnMeasureBoxFillColor.Name = "btnMeasureBoxFillColor";
            this.btnMeasureBoxFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnMeasureBoxFillColor.TabIndex = 11;
            this.btnMeasureBoxFillColor.UseVisualStyleBackColor = false;
            this.btnMeasureBoxFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label54
            //
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(320, 231);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(69, 12);
            this.label54.TabIndex = 10;
            this.label54.Text = "화살표 크기";
            //
            // label55
            //
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(26, 198);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(69, 12);
            this.label55.TabIndex = 9;
            this.label55.Text = "화살표 색상";
            //
            // label56
            //
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(320, 165);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(45, 12);
            this.label56.TabIndex = 8;
            this.label56.Text = "선 두께";
            //
            // label57
            //
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(320, 132);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(45, 12);
            this.label57.TabIndex = 7;
            this.label57.Text = "선 색상";
            //
            // label58
            //
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(320, 66);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(57, 12);
            this.label58.TabIndex = 6;
            this.label58.Text = "글자 크기";
            //
            // label59
            //
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(320, 33);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(41, 12);
            this.label59.TabIndex = 5;
            this.label59.Text = "글자색";
            //
            // label60
            //
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(26, 132);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(97, 12);
            this.label60.TabIndex = 4;
            this.label60.Text = "강조 박스 라인색";
            //
            // label61
            //
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(26, 165);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(97, 12);
            this.label61.TabIndex = 3;
            this.label61.Text = "선택 박스 라인색";
            //
            // label62
            //
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(26, 99);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(97, 12);
            this.label62.TabIndex = 2;
            this.label62.Text = "강조 박스 배경색";
            //
            // label63
            //
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(26, 66);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(69, 12);
            this.label63.TabIndex = 1;
            this.label63.Text = "박스 라인색";
            //
            // label64
            //
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(26, 33);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(69, 12);
            this.label64.TabIndex = 0;
            this.label64.Text = "박스 배경색";
            //
            // grpMeasureOption
            //
            this.grpMeasureOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMeasureOption.Controls.Add(this.ckMeasureXYZAxisDistanceDecomposed);
            this.grpMeasureOption.Controls.Add(this.cbMeasureDecimalPoint);
            this.grpMeasureOption.Controls.Add(this.cbMeasureUnit);
            this.grpMeasureOption.Controls.Add(this.cbMeasureDistanceUnit);
            this.grpMeasureOption.Controls.Add(this.ckMeasureUnit);
            this.grpMeasureOption.Controls.Add(this.ckMeasureType);
            this.grpMeasureOption.Controls.Add(this.ckMeasureFrame);
            this.grpMeasureOption.Controls.Add(this.ckMeasureDxDyDz);
            this.grpMeasureOption.Controls.Add(this.label47);
            this.grpMeasureOption.Controls.Add(this.label52);
            this.grpMeasureOption.Controls.Add(this.label53);
            this.grpMeasureOption.Location = new System.Drawing.Point(6, 6);
            this.grpMeasureOption.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpMeasureOption.Name = "grpMeasureOption";
            this.grpMeasureOption.Size = new System.Drawing.Size(590, 201);
            this.grpMeasureOption.TabIndex = 1;
            this.grpMeasureOption.TabStop = false;
            this.grpMeasureOption.Text = "옵션";
            //
            // ckMeasureXYZAxisDistanceDecomposed
            //
            this.ckMeasureXYZAxisDistanceDecomposed.AutoSize = true;
            this.ckMeasureXYZAxisDistanceDecomposed.Location = new System.Drawing.Point(28, 165);
            this.ckMeasureXYZAxisDistanceDecomposed.Name = "ckMeasureXYZAxisDistanceDecomposed";
            this.ckMeasureXYZAxisDistanceDecomposed.Size = new System.Drawing.Size(120, 16);
            this.ckMeasureXYZAxisDistanceDecomposed.TabIndex = 16;
            this.ckMeasureXYZAxisDistanceDecomposed.Text = "축 거리 분할 표시";
            this.ckMeasureXYZAxisDistanceDecomposed.UseVisualStyleBackColor = true;
            //
            // cbMeasureDecimalPoint
            //
            this.cbMeasureDecimalPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMeasureDecimalPoint.FormattingEnabled = true;
            this.cbMeasureDecimalPoint.Location = new System.Drawing.Point(294, 101);
            this.cbMeasureDecimalPoint.Name = "cbMeasureDecimalPoint";
            this.cbMeasureDecimalPoint.Size = new System.Drawing.Size(121, 20);
            this.cbMeasureDecimalPoint.TabIndex = 13;
            //
            // cbMeasureUnit
            //
            this.cbMeasureUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMeasureUnit.FormattingEnabled = true;
            this.cbMeasureUnit.Location = new System.Drawing.Point(294, 68);
            this.cbMeasureUnit.Name = "cbMeasureUnit";
            this.cbMeasureUnit.Size = new System.Drawing.Size(121, 20);
            this.cbMeasureUnit.TabIndex = 12;
            //
            // cbMeasureDistanceUnit
            //
            this.cbMeasureDistanceUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMeasureDistanceUnit.FormattingEnabled = true;
            this.cbMeasureDistanceUnit.Location = new System.Drawing.Point(294, 34);
            this.cbMeasureDistanceUnit.Name = "cbMeasureDistanceUnit";
            this.cbMeasureDistanceUnit.Size = new System.Drawing.Size(121, 20);
            this.cbMeasureDistanceUnit.TabIndex = 11;
            //
            // ckMeasureUnit
            //
            this.ckMeasureUnit.AutoSize = true;
            this.ckMeasureUnit.Location = new System.Drawing.Point(28, 132);
            this.ckMeasureUnit.Name = "ckMeasureUnit";
            this.ckMeasureUnit.Size = new System.Drawing.Size(104, 16);
            this.ckMeasureUnit.TabIndex = 10;
            this.ckMeasureUnit.Text = "측정 단위 표시";
            this.ckMeasureUnit.UseVisualStyleBackColor = true;
            //
            // ckMeasureType
            //
            this.ckMeasureType.AutoSize = true;
            this.ckMeasureType.Location = new System.Drawing.Point(28, 99);
            this.ckMeasureType.Name = "ckMeasureType";
            this.ckMeasureType.Size = new System.Drawing.Size(104, 16);
            this.ckMeasureType.TabIndex = 9;
            this.ckMeasureType.Text = "측정 타입 표시";
            this.ckMeasureType.UseVisualStyleBackColor = true;
            //
            // ckMeasureFrame
            //
            this.ckMeasureFrame.AutoSize = true;
            this.ckMeasureFrame.Location = new System.Drawing.Point(28, 66);
            this.ckMeasureFrame.Name = "ckMeasureFrame";
            this.ckMeasureFrame.Size = new System.Drawing.Size(100, 16);
            this.ckMeasureFrame.TabIndex = 8;
            this.ckMeasureFrame.Text = "좌표계로 표시";
            this.ckMeasureFrame.UseVisualStyleBackColor = true;
            //
            // ckMeasureDxDyDz
            //
            this.ckMeasureDxDyDz.AutoSize = true;
            this.ckMeasureDxDyDz.Location = new System.Drawing.Point(28, 33);
            this.ckMeasureDxDyDz.Name = "ckMeasureDxDyDz";
            this.ckMeasureDxDyDz.Size = new System.Drawing.Size(88, 16);
            this.ckMeasureDxDyDz.TabIndex = 7;
            this.ckMeasureDxDyDz.Text = "DX, DY, DZ";
            this.ckMeasureDxDyDz.UseVisualStyleBackColor = true;
            //
            // label47
            //
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(168, 37);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(85, 12);
            this.label47.TabIndex = 6;
            this.label47.Text = "거리 표시 단위";
            //
            // label52
            //
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(168, 103);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(109, 12);
            this.label52.TabIndex = 1;
            this.label52.Text = "소수점 이하 자리수";
            //
            // label53
            //
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(168, 70);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(85, 12);
            this.label53.TabIndex = 0;
            this.label53.Text = "면적 표시 단위";
            //
            // tpSection
            //
            this.tpSection.AutoScroll = true;
            this.tpSection.Controls.Add(this.grpSectionCap);
            this.tpSection.Controls.Add(this.grpSectionStyle);
            this.tpSection.Location = new System.Drawing.Point(4, 40);
            this.tpSection.Name = "tpSection";
            this.tpSection.Size = new System.Drawing.Size(668, 614);
            this.tpSection.TabIndex = 9;
            this.tpSection.Text = "단면";
            this.tpSection.UseVisualStyleBackColor = true;
            //
            // grpSectionCap
            //
            this.grpSectionCap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSectionCap.Controls.Add(this.txtCapStrokeThickness);
            this.grpSectionCap.Controls.Add(this.lblCapStrokeThickness);
            this.grpSectionCap.Controls.Add(this.cbCapStrokeColorMode);
            this.grpSectionCap.Controls.Add(this.lblCapStrokeColorMode);
            this.grpSectionCap.Controls.Add(this.btnCapStrokeColor);
            this.grpSectionCap.Controls.Add(this.lblCapStrokeColor);
            this.grpSectionCap.Controls.Add(this.cbCapFillColorMode);
            this.grpSectionCap.Controls.Add(this.lblCapFillColorMode);
            this.grpSectionCap.Controls.Add(this.btnCapFillColor);
            this.grpSectionCap.Controls.Add(this.lblCapFillColor);
            this.grpSectionCap.Controls.Add(this.cbCapStroke);
            this.grpSectionCap.Controls.Add(this.cbCapFill);
            this.grpSectionCap.Location = new System.Drawing.Point(6, 232);
            this.grpSectionCap.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpSectionCap.Name = "grpSectionCap";
            this.grpSectionCap.Size = new System.Drawing.Size(590, 199);
            this.grpSectionCap.TabIndex = 2;
            this.grpSectionCap.TabStop = false;
            this.grpSectionCap.Text = "단면 캡 설정";
            //
            // txtCapStrokeThickness
            //
            this.txtCapStrokeThickness.Location = new System.Drawing.Point(443, 161);
            this.txtCapStrokeThickness.Name = "txtCapStrokeThickness";
            this.txtCapStrokeThickness.Size = new System.Drawing.Size(75, 21);
            this.txtCapStrokeThickness.TabIndex = 16;
            //
            // lblCapStrokeThickness
            //
            this.lblCapStrokeThickness.AutoSize = true;
            this.lblCapStrokeThickness.Location = new System.Drawing.Point(297, 164);
            this.lblCapStrokeThickness.Name = "lblCapStrokeThickness";
            this.lblCapStrokeThickness.Size = new System.Drawing.Size(85, 12);
            this.lblCapStrokeThickness.TabIndex = 15;
            this.lblCapStrokeThickness.Text = "캡 외곽선 두께";
            //
            // cbCapStrokeColorMode
            //
            this.cbCapStrokeColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCapStrokeColorMode.FormattingEnabled = true;
            this.cbCapStrokeColorMode.Location = new System.Drawing.Point(443, 126);
            this.cbCapStrokeColorMode.Name = "cbCapStrokeColorMode";
            this.cbCapStrokeColorMode.Size = new System.Drawing.Size(126, 20);
            this.cbCapStrokeColorMode.TabIndex = 14;
            //
            // lblCapStrokeColorMode
            //
            this.lblCapStrokeColorMode.AutoSize = true;
            this.lblCapStrokeColorMode.Location = new System.Drawing.Point(297, 129);
            this.lblCapStrokeColorMode.Name = "lblCapStrokeColorMode";
            this.lblCapStrokeColorMode.Size = new System.Drawing.Size(113, 12);
            this.lblCapStrokeColorMode.TabIndex = 13;
            this.lblCapStrokeColorMode.Text = "캡 외곽선 색상 모드";
            //
            // btnCapStrokeColor
            //
            this.btnCapStrokeColor.Location = new System.Drawing.Point(185, 126);
            this.btnCapStrokeColor.Name = "btnCapStrokeColor";
            this.btnCapStrokeColor.Size = new System.Drawing.Size(75, 23);
            this.btnCapStrokeColor.TabIndex = 12;
            this.btnCapStrokeColor.UseVisualStyleBackColor = false;
            this.btnCapStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // lblCapStrokeColor
            //
            this.lblCapStrokeColor.AutoSize = true;
            this.lblCapStrokeColor.Location = new System.Drawing.Point(15, 129);
            this.lblCapStrokeColor.Name = "lblCapStrokeColor";
            this.lblCapStrokeColor.Size = new System.Drawing.Size(85, 12);
            this.lblCapStrokeColor.TabIndex = 11;
            this.lblCapStrokeColor.Text = "캡 외곽선 색상";
            //
            // cbCapFillColorMode
            //
            this.cbCapFillColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCapFillColorMode.FormattingEnabled = true;
            this.cbCapFillColorMode.Location = new System.Drawing.Point(443, 91);
            this.cbCapFillColorMode.Name = "cbCapFillColorMode";
            this.cbCapFillColorMode.Size = new System.Drawing.Size(126, 20);
            this.cbCapFillColorMode.TabIndex = 10;
            //
            // lblCapFillColorMode
            //
            this.lblCapFillColorMode.AutoSize = true;
            this.lblCapFillColorMode.Location = new System.Drawing.Point(297, 94);
            this.lblCapFillColorMode.Name = "lblCapFillColorMode";
            this.lblCapFillColorMode.Size = new System.Drawing.Size(89, 12);
            this.lblCapFillColorMode.TabIndex = 9;
            this.lblCapFillColorMode.Text = "캡 면 색상 모드";
            //
            // btnCapFillColor
            //
            this.btnCapFillColor.Location = new System.Drawing.Point(185, 91);
            this.btnCapFillColor.Name = "btnCapFillColor";
            this.btnCapFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnCapFillColor.TabIndex = 8;
            this.btnCapFillColor.UseVisualStyleBackColor = false;
            this.btnCapFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // lblCapFillColor
            //
            this.lblCapFillColor.AutoSize = true;
            this.lblCapFillColor.Location = new System.Drawing.Point(15, 94);
            this.lblCapFillColor.Name = "lblCapFillColor";
            this.lblCapFillColor.Size = new System.Drawing.Size(61, 12);
            this.lblCapFillColor.TabIndex = 7;
            this.lblCapFillColor.Text = "캡 면 색상";
            //
            // cbCapStroke
            //
            this.cbCapStroke.AutoSize = true;
            this.cbCapStroke.Location = new System.Drawing.Point(17, 62);
            this.cbCapStroke.Name = "cbCapStroke";
            this.cbCapStroke.Size = new System.Drawing.Size(138, 16);
            this.cbCapStroke.TabIndex = 6;
            this.cbCapStroke.Text = "단면(캡) 외곽선 표시";
            this.cbCapStroke.UseVisualStyleBackColor = true;
            //
            // cbCapFill
            //
            this.cbCapFill.AutoSize = true;
            this.cbCapFill.Location = new System.Drawing.Point(17, 31);
            this.cbCapFill.Name = "cbCapFill";
            this.cbCapFill.Size = new System.Drawing.Size(114, 16);
            this.cbCapFill.TabIndex = 5;
            this.cbCapFill.Text = "단면(캡) 면 표시";
            this.cbCapFill.UseVisualStyleBackColor = true;
            //
            // grpSectionStyle
            //
            this.grpSectionStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSectionStyle.Controls.Add(this.btnSectionDisabledBoundaryStrokeColor);
            this.grpSectionStyle.Controls.Add(this.label74);
            this.grpSectionStyle.Controls.Add(this.btnSectionHighlightedBoundaryStrokeColor);
            this.grpSectionStyle.Controls.Add(this.label73);
            this.grpSectionStyle.Controls.Add(this.cbSectionManipulatorDisplayMode);
            this.grpSectionStyle.Controls.Add(this.label72);
            this.grpSectionStyle.Controls.Add(this.btnSectionSelectedBoundaryStrokeColor);
            this.grpSectionStyle.Controls.Add(this.label71);
            this.grpSectionStyle.Controls.Add(this.btnSectionDisabledFaceFillColor);
            this.grpSectionStyle.Controls.Add(this.label70);
            this.grpSectionStyle.Controls.Add(this.cbSectionBoundaryStrokePattern);
            this.grpSectionStyle.Controls.Add(this.label69);
            this.grpSectionStyle.Controls.Add(this.btnSectionBoundaryStrokeColor);
            this.grpSectionStyle.Controls.Add(this.label68);
            this.grpSectionStyle.Controls.Add(this.txtSectionBoundaryStrokeThickness);
            this.grpSectionStyle.Controls.Add(this.label67);
            this.grpSectionStyle.Controls.Add(this.btnSectionFaceFillColor);
            this.grpSectionStyle.Controls.Add(this.label66);
            this.grpSectionStyle.Location = new System.Drawing.Point(6, 6);
            this.grpSectionStyle.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpSectionStyle.Name = "grpSectionStyle";
            this.grpSectionStyle.Size = new System.Drawing.Size(590, 223);
            this.grpSectionStyle.TabIndex = 0;
            this.grpSectionStyle.TabStop = false;
            this.grpSectionStyle.Text = "스타일";
            //
            // btnSectionDisabledBoundaryStrokeColor
            //
            this.btnSectionDisabledBoundaryStrokeColor.Location = new System.Drawing.Point(185, 103);
            this.btnSectionDisabledBoundaryStrokeColor.Name = "btnSectionDisabledBoundaryStrokeColor";
            this.btnSectionDisabledBoundaryStrokeColor.Size = new System.Drawing.Size(75, 23);
            this.btnSectionDisabledBoundaryStrokeColor.TabIndex = 37;
            this.btnSectionDisabledBoundaryStrokeColor.UseVisualStyleBackColor = false;
            this.btnSectionDisabledBoundaryStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label74
            //
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(15, 108);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(109, 12);
            this.label74.TabIndex = 36;
            this.label74.Text = "비활성 경계선 색상";
            //
            // btnSectionHighlightedBoundaryStrokeColor
            //
            this.btnSectionHighlightedBoundaryStrokeColor.Location = new System.Drawing.Point(185, 177);
            this.btnSectionHighlightedBoundaryStrokeColor.Name = "btnSectionHighlightedBoundaryStrokeColor";
            this.btnSectionHighlightedBoundaryStrokeColor.Size = new System.Drawing.Size(75, 23);
            this.btnSectionHighlightedBoundaryStrokeColor.TabIndex = 35;
            this.btnSectionHighlightedBoundaryStrokeColor.UseVisualStyleBackColor = false;
            this.btnSectionHighlightedBoundaryStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label73
            //
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(15, 182);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(97, 12);
            this.label73.TabIndex = 34;
            this.label73.Text = "강조 경계선 색상";
            //
            // cbSectionManipulatorDisplayMode
            //
            this.cbSectionManipulatorDisplayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSectionManipulatorDisplayMode.FormattingEnabled = true;
            this.cbSectionManipulatorDisplayMode.Location = new System.Drawing.Point(443, 142);
            this.cbSectionManipulatorDisplayMode.Name = "cbSectionManipulatorDisplayMode";
            this.cbSectionManipulatorDisplayMode.Size = new System.Drawing.Size(126, 20);
            this.cbSectionManipulatorDisplayMode.TabIndex = 33;
            //
            // label72
            //
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(297, 144);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(97, 12);
            this.label72.TabIndex = 32;
            this.label72.Text = "조작자 표시 방식";
            //
            // btnSectionSelectedBoundaryStrokeColor
            //
            this.btnSectionSelectedBoundaryStrokeColor.Location = new System.Drawing.Point(185, 140);
            this.btnSectionSelectedBoundaryStrokeColor.Name = "btnSectionSelectedBoundaryStrokeColor";
            this.btnSectionSelectedBoundaryStrokeColor.Size = new System.Drawing.Size(75, 23);
            this.btnSectionSelectedBoundaryStrokeColor.TabIndex = 31;
            this.btnSectionSelectedBoundaryStrokeColor.UseVisualStyleBackColor = false;
            this.btnSectionSelectedBoundaryStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label71
            //
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(15, 145);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(97, 12);
            this.label71.TabIndex = 30;
            this.label71.Text = "선택 경계선 색상";
            //
            // btnSectionDisabledFaceFillColor
            //
            this.btnSectionDisabledFaceFillColor.Location = new System.Drawing.Point(185, 66);
            this.btnSectionDisabledFaceFillColor.Name = "btnSectionDisabledFaceFillColor";
            this.btnSectionDisabledFaceFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnSectionDisabledFaceFillColor.TabIndex = 29;
            this.btnSectionDisabledFaceFillColor.UseVisualStyleBackColor = false;
            this.btnSectionDisabledFaceFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label70
            //
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(15, 71);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(85, 12);
            this.label70.TabIndex = 28;
            this.label70.Text = "비활성 면 색상";
            //
            // cbSectionBoundaryStrokePattern
            //
            this.cbSectionBoundaryStrokePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSectionBoundaryStrokePattern.FormattingEnabled = true;
            this.cbSectionBoundaryStrokePattern.Location = new System.Drawing.Point(443, 105);
            this.cbSectionBoundaryStrokePattern.Name = "cbSectionBoundaryStrokePattern";
            this.cbSectionBoundaryStrokePattern.Size = new System.Drawing.Size(126, 20);
            this.cbSectionBoundaryStrokePattern.TabIndex = 27;
            //
            // label69
            //
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(297, 107);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(69, 12);
            this.label69.TabIndex = 26;
            this.label69.Text = "경계선 패턴";
            //
            // btnSectionBoundaryStrokeColor
            //
            this.btnSectionBoundaryStrokeColor.Location = new System.Drawing.Point(443, 27);
            this.btnSectionBoundaryStrokeColor.Name = "btnSectionBoundaryStrokeColor";
            this.btnSectionBoundaryStrokeColor.Size = new System.Drawing.Size(75, 23);
            this.btnSectionBoundaryStrokeColor.TabIndex = 25;
            this.btnSectionBoundaryStrokeColor.UseVisualStyleBackColor = false;
            this.btnSectionBoundaryStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label68
            //
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(297, 71);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(69, 12);
            this.label68.TabIndex = 24;
            this.label68.Text = "경계선 두께";
            //
            // txtSectionBoundaryStrokeThickness
            //
            this.txtSectionBoundaryStrokeThickness.Location = new System.Drawing.Point(443, 68);
            this.txtSectionBoundaryStrokeThickness.Name = "txtSectionBoundaryStrokeThickness";
            this.txtSectionBoundaryStrokeThickness.Size = new System.Drawing.Size(75, 21);
            this.txtSectionBoundaryStrokeThickness.TabIndex = 23;
            //
            // label67
            //
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(297, 32);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(69, 12);
            this.label67.TabIndex = 22;
            this.label67.Text = "경계선 색상";
            //
            // btnSectionFaceFillColor
            //
            this.btnSectionFaceFillColor.Location = new System.Drawing.Point(185, 27);
            this.btnSectionFaceFillColor.Name = "btnSectionFaceFillColor";
            this.btnSectionFaceFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnSectionFaceFillColor.TabIndex = 13;
            this.btnSectionFaceFillColor.UseVisualStyleBackColor = false;
            this.btnSectionFaceFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label66
            //
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(15, 32);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(45, 12);
            this.label66.TabIndex = 12;
            this.label66.Text = "면 색상";
            //
            // tpDecal
            //
            this.tpDecal.AutoScroll = true;
            this.tpDecal.Controls.Add(this.grpDecal);
            this.tpDecal.Location = new System.Drawing.Point(4, 40);
            this.tpDecal.Name = "tpDecal";
            this.tpDecal.Padding = new System.Windows.Forms.Padding(3);
            this.tpDecal.Size = new System.Drawing.Size(668, 614);
            this.tpDecal.TabIndex = 10;
            this.tpDecal.Text = "데칼";
            this.tpDecal.UseVisualStyleBackColor = true;
            //
            // tpSpace
            //
            this.tpSpace.AutoScroll = true;
            this.tpSpace.Controls.Add(this.grpSpaceZone);
            this.tpSpace.Controls.Add(this.grpSpaceSelectionBox);
            this.tpSpace.Location = new System.Drawing.Point(4, 40);
            this.tpSpace.Name = "tpSpace";
            this.tpSpace.Padding = new System.Windows.Forms.Padding(3);
            this.tpSpace.Size = new System.Drawing.Size(668, 614);
            this.tpSpace.TabIndex = 2;
            this.tpSpace.Text = "공간";
            this.tpSpace.UseVisualStyleBackColor = true;
            //
            // grpDecal
            //
            this.grpDecal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDecal.Controls.Add(this.lblDecalHighlightedBoxFillColor);
            this.grpDecal.Controls.Add(this.btnDecalHighlightedBoxFillColor);
            this.grpDecal.Controls.Add(this.lblDecalHighlightedBoxStrokeColor);
            this.grpDecal.Controls.Add(this.btnDecalHighlightedBoxStrokeColor);
            this.grpDecal.Controls.Add(this.lblDecalSelectedBoxStrokeColor);
            this.grpDecal.Controls.Add(this.btnDecalSelectedBoxStrokeColor);
            this.grpDecal.Controls.Add(this.lblDecalRotationAngleStep);
            this.grpDecal.Controls.Add(this.numDecalRotationAngleStep);
            this.grpDecal.Controls.Add(this.lblDecalRotationAngleStepUnit);
            this.grpDecal.Location = new System.Drawing.Point(6, 6);
            this.grpDecal.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpDecal.Name = "grpDecal";
            this.grpDecal.Size = new System.Drawing.Size(590, 170);
            this.grpDecal.TabIndex = 0;
            this.grpDecal.TabStop = false;
            this.grpDecal.Text = "데칼";
            //
            // lblDecalHighlightedBoxFillColor
            //
            this.lblDecalHighlightedBoxFillColor.AutoSize = true;
            this.lblDecalHighlightedBoxFillColor.Location = new System.Drawing.Point(16, 31);
            this.lblDecalHighlightedBoxFillColor.Name = "lblDecalHighlightedBoxFillColor";
            this.lblDecalHighlightedBoxFillColor.Size = new System.Drawing.Size(125, 12);
            this.lblDecalHighlightedBoxFillColor.TabIndex = 0;
            this.lblDecalHighlightedBoxFillColor.Text = "강조 박스 채우기 색상";
            //
            // btnDecalHighlightedBoxFillColor
            //
            this.btnDecalHighlightedBoxFillColor.Location = new System.Drawing.Point(200, 26);
            this.btnDecalHighlightedBoxFillColor.Name = "btnDecalHighlightedBoxFillColor";
            this.btnDecalHighlightedBoxFillColor.Size = new System.Drawing.Size(80, 23);
            this.btnDecalHighlightedBoxFillColor.TabIndex = 1;
            this.btnDecalHighlightedBoxFillColor.UseVisualStyleBackColor = false;
            this.btnDecalHighlightedBoxFillColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // lblDecalHighlightedBoxStrokeColor
            //
            this.lblDecalHighlightedBoxStrokeColor.AutoSize = true;
            this.lblDecalHighlightedBoxStrokeColor.Location = new System.Drawing.Point(16, 63);
            this.lblDecalHighlightedBoxStrokeColor.Name = "lblDecalHighlightedBoxStrokeColor";
            this.lblDecalHighlightedBoxStrokeColor.Size = new System.Drawing.Size(101, 12);
            this.lblDecalHighlightedBoxStrokeColor.TabIndex = 2;
            this.lblDecalHighlightedBoxStrokeColor.Text = "강조 박스 선 색상";
            //
            // btnDecalHighlightedBoxStrokeColor
            //
            this.btnDecalHighlightedBoxStrokeColor.Location = new System.Drawing.Point(200, 58);
            this.btnDecalHighlightedBoxStrokeColor.Name = "btnDecalHighlightedBoxStrokeColor";
            this.btnDecalHighlightedBoxStrokeColor.Size = new System.Drawing.Size(80, 23);
            this.btnDecalHighlightedBoxStrokeColor.TabIndex = 3;
            this.btnDecalHighlightedBoxStrokeColor.UseVisualStyleBackColor = false;
            this.btnDecalHighlightedBoxStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // lblDecalSelectedBoxStrokeColor
            //
            this.lblDecalSelectedBoxStrokeColor.AutoSize = true;
            this.lblDecalSelectedBoxStrokeColor.Location = new System.Drawing.Point(16, 95);
            this.lblDecalSelectedBoxStrokeColor.Name = "lblDecalSelectedBoxStrokeColor";
            this.lblDecalSelectedBoxStrokeColor.Size = new System.Drawing.Size(101, 12);
            this.lblDecalSelectedBoxStrokeColor.TabIndex = 4;
            this.lblDecalSelectedBoxStrokeColor.Text = "선택 박스 선 색상";
            //
            // btnDecalSelectedBoxStrokeColor
            //
            this.btnDecalSelectedBoxStrokeColor.Location = new System.Drawing.Point(200, 90);
            this.btnDecalSelectedBoxStrokeColor.Name = "btnDecalSelectedBoxStrokeColor";
            this.btnDecalSelectedBoxStrokeColor.Size = new System.Drawing.Size(80, 23);
            this.btnDecalSelectedBoxStrokeColor.TabIndex = 5;
            this.btnDecalSelectedBoxStrokeColor.UseVisualStyleBackColor = false;
            this.btnDecalSelectedBoxStrokeColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // lblDecalRotationAngleStep
            //
            this.lblDecalRotationAngleStep.AutoSize = true;
            this.lblDecalRotationAngleStep.Location = new System.Drawing.Point(16, 127);
            this.lblDecalRotationAngleStep.Name = "lblDecalRotationAngleStep";
            this.lblDecalRotationAngleStep.Size = new System.Drawing.Size(85, 12);
            this.lblDecalRotationAngleStep.TabIndex = 6;
            this.lblDecalRotationAngleStep.Text = "회전 각도 단계";
            //
            // numDecalRotationAngleStep
            //
            this.numDecalRotationAngleStep.Location = new System.Drawing.Point(200, 123);
            this.numDecalRotationAngleStep.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numDecalRotationAngleStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDecalRotationAngleStep.Name = "numDecalRotationAngleStep";
            this.numDecalRotationAngleStep.Size = new System.Drawing.Size(80, 21);
            this.numDecalRotationAngleStep.TabIndex = 7;
            this.numDecalRotationAngleStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // lblDecalRotationAngleStepUnit
            //
            this.lblDecalRotationAngleStepUnit.AutoSize = true;
            this.lblDecalRotationAngleStepUnit.Location = new System.Drawing.Point(286, 127);
            this.lblDecalRotationAngleStepUnit.Name = "lblDecalRotationAngleStepUnit";
            this.lblDecalRotationAngleStepUnit.Size = new System.Drawing.Size(27, 12);
            this.lblDecalRotationAngleStepUnit.TabIndex = 8;
            this.lblDecalRotationAngleStepUnit.Text = "(도)";
            //
            // tpFrame
            //
            this.tpFrame.AutoScroll = true;
            this.tpFrame.Controls.Add(this.grpFrameColor);
            this.tpFrame.Controls.Add(this.grpFrameView);
            this.tpFrame.Location = new System.Drawing.Point(4, 40);
            this.tpFrame.Name = "tpFrame";
            this.tpFrame.Padding = new System.Windows.Forms.Padding(3);
            this.tpFrame.Size = new System.Drawing.Size(668, 614);
            this.tpFrame.TabIndex = 11;
            this.tpFrame.Text = "프레임";
            this.tpFrame.UseVisualStyleBackColor = true;
            //
            // grpFrameColor
            //
            this.grpFrameColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFrameColor.Controls.Add(this.cbFramePlaneStrokePattern);
            this.grpFrameColor.Controls.Add(this.label20);
            this.grpFrameColor.Controls.Add(this.cbGridLineStrokePattern);
            this.grpFrameColor.Controls.Add(this.label50);
            this.grpFrameColor.Controls.Add(this.btnFrameLabelColor);
            this.grpFrameColor.Controls.Add(this.label15);
            this.grpFrameColor.Controls.Add(this.numFrameLineThickness);
            this.grpFrameColor.Controls.Add(this.numFramePlaneThickness);
            this.grpFrameColor.Controls.Add(this.label16);
            this.grpFrameColor.Controls.Add(this.label17);
            this.grpFrameColor.Controls.Add(this.btnFrameLineColor);
            this.grpFrameColor.Controls.Add(this.btnFramePlaneColor);
            this.grpFrameColor.Controls.Add(this.label18);
            this.grpFrameColor.Controls.Add(this.label19);
            this.grpFrameColor.Location = new System.Drawing.Point(6, 112);
            this.grpFrameColor.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpFrameColor.Name = "grpFrameColor";
            this.grpFrameColor.Size = new System.Drawing.Size(590, 141);
            this.grpFrameColor.TabIndex = 3;
            this.grpFrameColor.TabStop = false;
            this.grpFrameColor.Text = "색상";
            //
            // cbFramePlaneStrokePattern
            //
            this.cbFramePlaneStrokePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFramePlaneStrokePattern.FormattingEnabled = true;
            this.cbFramePlaneStrokePattern.Location = new System.Drawing.Point(164, 78);
            this.cbFramePlaneStrokePattern.Name = "cbFramePlaneStrokePattern";
            this.cbFramePlaneStrokePattern.Size = new System.Drawing.Size(110, 20);
            this.cbFramePlaneStrokePattern.TabIndex = 13;
            //
            // label20
            //
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(18, 82);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 12);
            this.label20.TabIndex = 12;
            this.label20.Text = "평면 선 패턴";
            //
            // cbGridLineStrokePattern
            //
            this.cbGridLineStrokePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGridLineStrokePattern.FormattingEnabled = true;
            this.cbGridLineStrokePattern.Location = new System.Drawing.Point(457, 81);
            this.cbGridLineStrokePattern.Name = "cbGridLineStrokePattern";
            this.cbGridLineStrokePattern.Size = new System.Drawing.Size(110, 20);
            this.cbGridLineStrokePattern.TabIndex = 11;
            //
            // label50
            //
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(336, 81);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(73, 12);
            this.label50.TabIndex = 10;
            this.label50.Text = "라인 선 패턴";
            //
            // btnFrameLabelColor
            //
            this.btnFrameLabelColor.Location = new System.Drawing.Point(164, 107);
            this.btnFrameLabelColor.Name = "btnFrameLabelColor";
            this.btnFrameLabelColor.Size = new System.Drawing.Size(110, 23);
            this.btnFrameLabelColor.TabIndex = 9;
            this.btnFrameLabelColor.UseVisualStyleBackColor = false;
            this.btnFrameLabelColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label15
            //
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 12);
            this.label15.TabIndex = 8;
            this.label15.Text = "문자 색상";
            //
            // numFrameLineThickness
            //
            this.numFrameLineThickness.Location = new System.Drawing.Point(457, 47);
            this.numFrameLineThickness.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numFrameLineThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFrameLineThickness.Name = "numFrameLineThickness";
            this.numFrameLineThickness.Size = new System.Drawing.Size(110, 21);
            this.numFrameLineThickness.TabIndex = 7;
            this.numFrameLineThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // numFramePlaneThickness
            //
            this.numFramePlaneThickness.Location = new System.Drawing.Point(164, 47);
            this.numFramePlaneThickness.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numFramePlaneThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFramePlaneThickness.Name = "numFramePlaneThickness";
            this.numFramePlaneThickness.Size = new System.Drawing.Size(110, 21);
            this.numFramePlaneThickness.TabIndex = 6;
            this.numFramePlaneThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // label16
            //
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(336, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 12);
            this.label16.TabIndex = 5;
            this.label16.Text = "라인 선 두께";
            //
            // label17
            //
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(18, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 12);
            this.label17.TabIndex = 4;
            this.label17.Text = "평면 선 두께";
            //
            // btnFrameLineColor
            //
            this.btnFrameLineColor.Location = new System.Drawing.Point(457, 18);
            this.btnFrameLineColor.Name = "btnFrameLineColor";
            this.btnFrameLineColor.Size = new System.Drawing.Size(110, 23);
            this.btnFrameLineColor.TabIndex = 3;
            this.btnFrameLineColor.UseVisualStyleBackColor = false;
            this.btnFrameLineColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // btnFramePlaneColor
            //
            this.btnFramePlaneColor.Location = new System.Drawing.Point(164, 16);
            this.btnFramePlaneColor.Name = "btnFramePlaneColor";
            this.btnFramePlaneColor.Size = new System.Drawing.Size(110, 23);
            this.btnFramePlaneColor.TabIndex = 2;
            this.btnFramePlaneColor.UseVisualStyleBackColor = false;
            this.btnFramePlaneColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // label18
            //
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(336, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 12);
            this.label18.TabIndex = 1;
            this.label18.Text = "라인 색상";
            //
            // label19
            //
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "평면 색상";
            //
            // grpFrameView
            //
            this.grpFrameView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFrameView.Controls.Add(this.label27);
            this.grpFrameView.Controls.Add(this.label22);
            this.grpFrameView.Controls.Add(this.label21);
            this.grpFrameView.Controls.Add(this.comboBoxFrameZLabel);
            this.grpFrameView.Controls.Add(this.comboBoxFrameYLabel);
            this.grpFrameView.Controls.Add(this.comboBoxFrameXLabel);
            this.grpFrameView.Controls.Add(this.ckFrameZLine);
            this.grpFrameView.Controls.Add(this.ckFrameZXPlane);
            this.grpFrameView.Controls.Add(this.ckFrameYLine);
            this.grpFrameView.Controls.Add(this.ckFrameYZPlane);
            this.grpFrameView.Controls.Add(this.ckFrameXLine);
            this.grpFrameView.Controls.Add(this.ckFrameXYPlane);
            this.grpFrameView.Location = new System.Drawing.Point(6, 6);
            this.grpFrameView.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpFrameView.Name = "grpFrameView";
            this.grpFrameView.Size = new System.Drawing.Size(590, 100);
            this.grpFrameView.TabIndex = 2;
            this.grpFrameView.TabStop = false;
            this.grpFrameView.Text = "조회";
            //
            // label27
            //
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(403, 69);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 12);
            this.label27.TabIndex = 7;
            this.label27.Text = "Z축 접두사";
            //
            // label22
            //
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(209, 72);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 6;
            this.label22.Text = "Y축 접두사";
            //
            // label21
            //
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(18, 72);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 5;
            this.label21.Text = "X축 접두사";
            //
            // comboBoxFrameZLabel
            //
            this.comboBoxFrameZLabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrameZLabel.FormattingEnabled = true;
            this.comboBoxFrameZLabel.Location = new System.Drawing.Point(486, 64);
            this.comboBoxFrameZLabel.Name = "comboBoxFrameZLabel";
            this.comboBoxFrameZLabel.Size = new System.Drawing.Size(93, 20);
            this.comboBoxFrameZLabel.TabIndex = 2;
            //
            // comboBoxFrameYLabel
            //
            this.comboBoxFrameYLabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrameYLabel.FormattingEnabled = true;
            this.comboBoxFrameYLabel.Location = new System.Drawing.Point(291, 67);
            this.comboBoxFrameYLabel.Name = "comboBoxFrameYLabel";
            this.comboBoxFrameYLabel.Size = new System.Drawing.Size(93, 20);
            this.comboBoxFrameYLabel.TabIndex = 3;
            //
            // comboBoxFrameXLabel
            //
            this.comboBoxFrameXLabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrameXLabel.FormattingEnabled = true;
            this.comboBoxFrameXLabel.Location = new System.Drawing.Point(98, 67);
            this.comboBoxFrameXLabel.Name = "comboBoxFrameXLabel";
            this.comboBoxFrameXLabel.Size = new System.Drawing.Size(93, 20);
            this.comboBoxFrameXLabel.TabIndex = 4;
            //
            // ckFrameZLine
            //
            this.ckFrameZLine.AutoSize = true;
            this.ckFrameZLine.Location = new System.Drawing.Point(405, 39);
            this.ckFrameZLine.Name = "ckFrameZLine";
            this.ckFrameZLine.Size = new System.Drawing.Size(100, 16);
            this.ckFrameZLine.TabIndex = 0;
            this.ckFrameZLine.Text = "Z 프레임 라인";
            this.ckFrameZLine.UseVisualStyleBackColor = true;
            //
            // ckFrameZXPlane
            //
            this.ckFrameZXPlane.AutoSize = true;
            this.ckFrameZXPlane.Location = new System.Drawing.Point(405, 17);
            this.ckFrameZXPlane.Name = "ckFrameZXPlane";
            this.ckFrameZXPlane.Size = new System.Drawing.Size(68, 16);
            this.ckFrameZXPlane.TabIndex = 0;
            this.ckFrameZXPlane.Text = "ZX 평면";
            this.ckFrameZXPlane.UseVisualStyleBackColor = true;
            //
            // ckFrameYLine
            //
            this.ckFrameYLine.AutoSize = true;
            this.ckFrameYLine.Location = new System.Drawing.Point(211, 42);
            this.ckFrameYLine.Name = "ckFrameYLine";
            this.ckFrameYLine.Size = new System.Drawing.Size(100, 16);
            this.ckFrameYLine.TabIndex = 0;
            this.ckFrameYLine.Text = "Y 프레임 라인";
            this.ckFrameYLine.UseVisualStyleBackColor = true;
            //
            // ckFrameYZPlane
            //
            this.ckFrameYZPlane.AutoSize = true;
            this.ckFrameYZPlane.Location = new System.Drawing.Point(211, 20);
            this.ckFrameYZPlane.Name = "ckFrameYZPlane";
            this.ckFrameYZPlane.Size = new System.Drawing.Size(68, 16);
            this.ckFrameYZPlane.TabIndex = 0;
            this.ckFrameYZPlane.Text = "YZ 평면";
            this.ckFrameYZPlane.UseVisualStyleBackColor = true;
            //
            // ckFrameXLine
            //
            this.ckFrameXLine.AutoSize = true;
            this.ckFrameXLine.Location = new System.Drawing.Point(18, 42);
            this.ckFrameXLine.Name = "ckFrameXLine";
            this.ckFrameXLine.Size = new System.Drawing.Size(100, 16);
            this.ckFrameXLine.TabIndex = 0;
            this.ckFrameXLine.Text = "X 프레임 라인";
            this.ckFrameXLine.UseVisualStyleBackColor = true;
            //
            // ckFrameXYPlane
            //
            this.ckFrameXYPlane.AutoSize = true;
            this.ckFrameXYPlane.Location = new System.Drawing.Point(18, 20);
            this.ckFrameXYPlane.Name = "ckFrameXYPlane";
            this.ckFrameXYPlane.Size = new System.Drawing.Size(68, 16);
            this.ckFrameXYPlane.TabIndex = 0;
            this.ckFrameXYPlane.Text = "XY 평면";
            this.ckFrameXYPlane.UseVisualStyleBackColor = true;
            //
            // tpPreSelect
            //
            this.tpPreSelect.AutoScroll = true;
            this.tpPreSelect.Controls.Add(this.grpPreSelect);
            this.tpPreSelect.Location = new System.Drawing.Point(4, 40);
            this.tpPreSelect.Name = "tpPreSelect";
            this.tpPreSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tpPreSelect.Size = new System.Drawing.Size(668, 614);
            this.tpPreSelect.TabIndex = 6;
            this.tpPreSelect.Text = "사전 선택";
            this.tpPreSelect.UseVisualStyleBackColor = true;
            //
            // grpPreSelect
            //
            this.grpPreSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPreSelect.Controls.Add(this.ckPreSelectEnable);
            this.grpPreSelect.Controls.Add(this.lblPreSelectOutlineColor);
            this.grpPreSelect.Controls.Add(this.btnPreSelectOutlineColor);
            this.grpPreSelect.Controls.Add(this.lblPreSelectDelay);
            this.grpPreSelect.Controls.Add(this.numPreSelectDelay);
            this.grpPreSelect.Controls.Add(this.lblPreSelectLimit);
            this.grpPreSelect.Controls.Add(this.numPreSelectLimit);
            this.grpPreSelect.Controls.Add(this.ckPreSelectAutoScroll);
            this.grpPreSelect.Controls.Add(this.ckPreSelectNodeNameVisible);
            this.grpPreSelect.Controls.Add(this.lblPreSelectNodeNameTarget);
            this.grpPreSelect.Controls.Add(this.cbPreSelectNodeNameTarget);
            this.grpPreSelect.Location = new System.Drawing.Point(6, 6);
            this.grpPreSelect.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpPreSelect.Name = "grpPreSelect";
            this.grpPreSelect.Size = new System.Drawing.Size(590, 250);
            this.grpPreSelect.TabIndex = 0;
            this.grpPreSelect.TabStop = false;
            this.grpPreSelect.Text = "사전 선택 강조";
            //
            // ckPreSelectEnable
            //
            this.ckPreSelectEnable.AutoSize = true;
            this.ckPreSelectEnable.Location = new System.Drawing.Point(19, 26);
            this.ckPreSelectEnable.Name = "ckPreSelectEnable";
            this.ckPreSelectEnable.Size = new System.Drawing.Size(116, 16);
            this.ckPreSelectEnable.TabIndex = 0;
            this.ckPreSelectEnable.Text = "사전 선택 활성화";
            this.ckPreSelectEnable.UseVisualStyleBackColor = true;
            //
            // lblPreSelectOutlineColor
            //
            this.lblPreSelectOutlineColor.AutoSize = true;
            this.lblPreSelectOutlineColor.Location = new System.Drawing.Point(16, 60);
            this.lblPreSelectOutlineColor.Name = "lblPreSelectOutlineColor";
            this.lblPreSelectOutlineColor.Size = new System.Drawing.Size(29, 12);
            this.lblPreSelectOutlineColor.TabIndex = 1;
            this.lblPreSelectOutlineColor.Text = "색상";
            //
            // btnPreSelectOutlineColor
            //
            this.btnPreSelectOutlineColor.Location = new System.Drawing.Point(200, 55);
            this.btnPreSelectOutlineColor.Name = "btnPreSelectOutlineColor";
            this.btnPreSelectOutlineColor.Size = new System.Drawing.Size(80, 23);
            this.btnPreSelectOutlineColor.TabIndex = 2;
            this.btnPreSelectOutlineColor.UseVisualStyleBackColor = false;
            this.btnPreSelectOutlineColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // lblPreSelectDelay
            //
            this.lblPreSelectDelay.AutoSize = true;
            this.lblPreSelectDelay.Location = new System.Drawing.Point(16, 92);
            this.lblPreSelectDelay.Name = "lblPreSelectDelay";
            this.lblPreSelectDelay.Size = new System.Drawing.Size(79, 12);
            this.lblPreSelectDelay.TabIndex = 3;
            this.lblPreSelectDelay.Text = "지연 시간(초)";
            //
            // numPreSelectDelay
            //
            this.numPreSelectDelay.DecimalPlaces = 2;
            this.numPreSelectDelay.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numPreSelectDelay.Location = new System.Drawing.Point(200, 88);
            this.numPreSelectDelay.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPreSelectDelay.Name = "numPreSelectDelay";
            this.numPreSelectDelay.Size = new System.Drawing.Size(80, 21);
            this.numPreSelectDelay.TabIndex = 4;
            //
            // lblPreSelectLimit
            //
            this.lblPreSelectLimit.AutoSize = true;
            this.lblPreSelectLimit.Location = new System.Drawing.Point(16, 124);
            this.lblPreSelectLimit.Name = "lblPreSelectLimit";
            this.lblPreSelectLimit.Size = new System.Drawing.Size(73, 12);
            this.lblPreSelectLimit.TabIndex = 5;
            this.lblPreSelectLimit.Text = "최대 블록 수";
            //
            // numPreSelectLimit
            //
            this.numPreSelectLimit.Location = new System.Drawing.Point(200, 120);
            this.numPreSelectLimit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPreSelectLimit.Name = "numPreSelectLimit";
            this.numPreSelectLimit.Size = new System.Drawing.Size(80, 21);
            this.numPreSelectLimit.TabIndex = 6;
            //
            // ckPreSelectAutoScroll
            //
            this.ckPreSelectAutoScroll.AutoSize = true;
            this.ckPreSelectAutoScroll.Location = new System.Drawing.Point(19, 152);
            this.ckPreSelectAutoScroll.Name = "ckPreSelectAutoScroll";
            this.ckPreSelectAutoScroll.Size = new System.Drawing.Size(144, 16);
            this.ckPreSelectAutoScroll.TabIndex = 7;
            this.ckPreSelectAutoScroll.Text = "모델 트리 자동 스크롤";
            this.ckPreSelectAutoScroll.UseVisualStyleBackColor = true;
            //
            // ckModelTreeAutoExpand
            //
            this.ckModelTreeAutoExpand.AutoSize = true;
            this.ckModelTreeAutoExpand.Location = new System.Drawing.Point(15, 84);
            this.ckModelTreeAutoExpand.Name = "ckModelTreeAutoExpand";
            this.ckModelTreeAutoExpand.Size = new System.Drawing.Size(152, 16);
            this.ckModelTreeAutoExpand.TabIndex = 11;
            this.ckModelTreeAutoExpand.Text = "선택 시 트리 자동 펼침";
            this.ckModelTreeAutoExpand.UseVisualStyleBackColor = true;
            //
            // ckModelTreeAutoScroll
            //
            this.ckModelTreeAutoScroll.AutoSize = true;
            this.ckModelTreeAutoScroll.Location = new System.Drawing.Point(300, 84);
            this.ckModelTreeAutoScroll.Name = "ckModelTreeAutoScroll";
            this.ckModelTreeAutoScroll.Size = new System.Drawing.Size(164, 16);
            this.ckModelTreeAutoScroll.TabIndex = 12;
            this.ckModelTreeAutoScroll.Text = "선택 시 트리 자동 스크롤";
            this.ckModelTreeAutoScroll.UseVisualStyleBackColor = true;
            //
            // ckPreSelectNodeNameVisible
            //
            this.ckPreSelectNodeNameVisible.AutoSize = true;
            this.ckPreSelectNodeNameVisible.Location = new System.Drawing.Point(19, 180);
            this.ckPreSelectNodeNameVisible.Name = "ckPreSelectNodeNameVisible";
            this.ckPreSelectNodeNameVisible.Size = new System.Drawing.Size(104, 16);
            this.ckPreSelectNodeNameVisible.TabIndex = 8;
            this.ckPreSelectNodeNameVisible.Text = "노드 이름 표시";
            this.ckPreSelectNodeNameVisible.UseVisualStyleBackColor = true;
            //
            // lblPreSelectNodeNameTarget
            //
            this.lblPreSelectNodeNameTarget.AutoSize = true;
            this.lblPreSelectNodeNameTarget.Location = new System.Drawing.Point(16, 216);
            this.lblPreSelectNodeNameTarget.Name = "lblPreSelectNodeNameTarget";
            this.lblPreSelectNodeNameTarget.Size = new System.Drawing.Size(85, 12);
            this.lblPreSelectNodeNameTarget.TabIndex = 9;
            this.lblPreSelectNodeNameTarget.Text = "노드 이름 대상";
            //
            // cbPreSelectNodeNameTarget
            //
            this.cbPreSelectNodeNameTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPreSelectNodeNameTarget.FormattingEnabled = true;
            this.cbPreSelectNodeNameTarget.Location = new System.Drawing.Point(200, 212);
            this.cbPreSelectNodeNameTarget.Name = "cbPreSelectNodeNameTarget";
            this.cbPreSelectNodeNameTarget.Size = new System.Drawing.Size(150, 20);
            this.cbPreSelectNodeNameTarget.TabIndex = 10;
            //
            // tpWindow
            //
            this.tpWindow.AutoScroll = true;
            this.tpWindow.Controls.Add(this.grpWindowSplit);
            this.tpWindow.Controls.Add(this.grpWindowAttribute);
            this.tpWindow.Controls.Add(this.grpWindowModelTree);
            this.tpWindow.Controls.Add(this.grpWindowModelingControl);
            this.tpWindow.Location = new System.Drawing.Point(4, 40);
            this.tpWindow.Name = "tpWindow";
            this.tpWindow.Padding = new System.Windows.Forms.Padding(3);
            this.tpWindow.Size = new System.Drawing.Size(668, 614);
            this.tpWindow.TabIndex = 3;
            this.tpWindow.Text = "창";
            this.tpWindow.UseVisualStyleBackColor = true;
            //
            // grpWindowSplit
            //
            this.grpWindowSplit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpWindowSplit.Controls.Add(this.rbSplitTop);
            this.grpWindowSplit.Controls.Add(this.rbSplitBottom);
            this.grpWindowSplit.Controls.Add(this.rbSplitLeft);
            this.grpWindowSplit.Controls.Add(this.rbSplitRight);
            this.grpWindowSplit.Location = new System.Drawing.Point(6, 248);
            this.grpWindowSplit.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpWindowSplit.Name = "grpWindowSplit";
            this.grpWindowSplit.Size = new System.Drawing.Size(590, 70);
            this.grpWindowSplit.TabIndex = 2;
            this.grpWindowSplit.TabStop = false;
            this.grpWindowSplit.Text = "두 패널이 같은 위치일 때 모델 트리 패널 위치";
            //
            // rbSplitTop
            //
            this.rbSplitTop.AutoSize = true;
            this.rbSplitTop.Location = new System.Drawing.Point(15, 32);
            this.rbSplitTop.Name = "rbSplitTop";
            this.rbSplitTop.Size = new System.Drawing.Size(35, 16);
            this.rbSplitTop.TabIndex = 0;
            this.rbSplitTop.TabStop = true;
            this.rbSplitTop.Text = "위";
            this.rbSplitTop.UseVisualStyleBackColor = true;
            //
            // rbSplitBottom
            //
            this.rbSplitBottom.AutoSize = true;
            this.rbSplitBottom.Location = new System.Drawing.Point(160, 32);
            this.rbSplitBottom.Name = "rbSplitBottom";
            this.rbSplitBottom.Size = new System.Drawing.Size(47, 16);
            this.rbSplitBottom.TabIndex = 1;
            this.rbSplitBottom.TabStop = true;
            this.rbSplitBottom.Text = "아래";
            this.rbSplitBottom.UseVisualStyleBackColor = true;
            //
            // rbSplitLeft
            //
            this.rbSplitLeft.AutoSize = true;
            this.rbSplitLeft.Location = new System.Drawing.Point(310, 32);
            this.rbSplitLeft.Name = "rbSplitLeft";
            this.rbSplitLeft.Size = new System.Drawing.Size(47, 16);
            this.rbSplitLeft.TabIndex = 2;
            this.rbSplitLeft.TabStop = true;
            this.rbSplitLeft.Text = "왼쪽";
            this.rbSplitLeft.UseVisualStyleBackColor = true;
            //
            // rbSplitRight
            //
            this.rbSplitRight.AutoSize = true;
            this.rbSplitRight.Location = new System.Drawing.Point(460, 32);
            this.rbSplitRight.Name = "rbSplitRight";
            this.rbSplitRight.Size = new System.Drawing.Size(59, 16);
            this.rbSplitRight.TabIndex = 3;
            this.rbSplitRight.TabStop = true;
            this.rbSplitRight.Text = "오른쪽";
            this.rbSplitRight.UseVisualStyleBackColor = true;
            //
            // grpWindowAttribute
            //
            this.grpWindowAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpWindowAttribute.Controls.Add(this.ckAttributePanelVisible);
            this.grpWindowAttribute.Controls.Add(this.lblAttributePanelPosition);
            this.grpWindowAttribute.Controls.Add(this.cbAttributePanelPosition);
            this.grpWindowAttribute.Controls.Add(this.lblAttributePanelWidth);
            this.grpWindowAttribute.Controls.Add(this.numAttributePanelWidth);
            this.grpWindowAttribute.Location = new System.Drawing.Point(6, 127);
            this.grpWindowAttribute.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpWindowAttribute.Name = "grpWindowAttribute";
            this.grpWindowAttribute.Size = new System.Drawing.Size(590, 115);
            this.grpWindowAttribute.TabIndex = 1;
            this.grpWindowAttribute.TabStop = false;
            this.grpWindowAttribute.Text = "특성 및 속성 탭";
            //
            // ckAttributePanelVisible
            //
            this.ckAttributePanelVisible.AutoSize = true;
            this.ckAttributePanelVisible.Location = new System.Drawing.Point(15, 24);
            this.ckAttributePanelVisible.Name = "ckAttributePanelVisible";
            this.ckAttributePanelVisible.Size = new System.Drawing.Size(76, 16);
            this.ckAttributePanelVisible.TabIndex = 0;
            this.ckAttributePanelVisible.Text = "패널 표시";
            this.ckAttributePanelVisible.UseVisualStyleBackColor = true;
            //
            // lblAttributePanelPosition
            //
            this.lblAttributePanelPosition.AutoSize = true;
            this.lblAttributePanelPosition.Location = new System.Drawing.Point(15, 54);
            this.lblAttributePanelPosition.Name = "lblAttributePanelPosition";
            this.lblAttributePanelPosition.Size = new System.Drawing.Size(29, 12);
            this.lblAttributePanelPosition.TabIndex = 1;
            this.lblAttributePanelPosition.Text = "위치";
            //
            // cbAttributePanelPosition
            //
            this.cbAttributePanelPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttributePanelPosition.FormattingEnabled = true;
            this.cbAttributePanelPosition.Location = new System.Drawing.Point(60, 51);
            this.cbAttributePanelPosition.Name = "cbAttributePanelPosition";
            this.cbAttributePanelPosition.Size = new System.Drawing.Size(120, 20);
            this.cbAttributePanelPosition.TabIndex = 2;
            this.cbAttributePanelPosition.SelectedIndexChanged += new System.EventHandler(this.cbPanelPosition_SelectedIndexChanged);
            //
            // lblAttributePanelWidth
            //
            this.lblAttributePanelWidth.AutoSize = true;
            this.lblAttributePanelWidth.Location = new System.Drawing.Point(199, 54);
            this.lblAttributePanelWidth.Name = "lblAttributePanelWidth";
            this.lblAttributePanelWidth.Size = new System.Drawing.Size(29, 12);
            this.lblAttributePanelWidth.TabIndex = 3;
            this.lblAttributePanelWidth.Text = "너비";
            //
            // numAttributePanelWidth
            //
            this.numAttributePanelWidth.Location = new System.Drawing.Point(244, 52);
            this.numAttributePanelWidth.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numAttributePanelWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numAttributePanelWidth.Name = "numAttributePanelWidth";
            this.numAttributePanelWidth.Size = new System.Drawing.Size(100, 21);
            this.numAttributePanelWidth.TabIndex = 4;
            this.numAttributePanelWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            //
            // grpWindowModelTree
            //
            this.grpWindowModelTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpWindowModelTree.Controls.Add(this.ckModelTreePanelVisible);
            this.grpWindowModelTree.Controls.Add(this.lblModelTreePanelPosition);
            this.grpWindowModelTree.Controls.Add(this.cbModelTreePanelPosition);
            this.grpWindowModelTree.Controls.Add(this.lblModelTreePanelWidth);
            this.grpWindowModelTree.Controls.Add(this.numModelTreePanelWidth);
            this.grpWindowModelTree.Controls.Add(this.ckModelTreeAutoExpand);
            this.grpWindowModelTree.Controls.Add(this.ckModelTreeAutoScroll);
            this.grpWindowModelTree.Location = new System.Drawing.Point(6, 6);
            this.grpWindowModelTree.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpWindowModelTree.Name = "grpWindowModelTree";
            this.grpWindowModelTree.Size = new System.Drawing.Size(590, 115);
            this.grpWindowModelTree.TabIndex = 0;
            this.grpWindowModelTree.TabStop = false;
            this.grpWindowModelTree.Text = "모델 트리 탭";
            //
            // ckModelTreePanelVisible
            //
            this.ckModelTreePanelVisible.AutoSize = true;
            this.ckModelTreePanelVisible.Location = new System.Drawing.Point(15, 24);
            this.ckModelTreePanelVisible.Name = "ckModelTreePanelVisible";
            this.ckModelTreePanelVisible.Size = new System.Drawing.Size(76, 16);
            this.ckModelTreePanelVisible.TabIndex = 0;
            this.ckModelTreePanelVisible.Text = "패널 표시";
            this.ckModelTreePanelVisible.UseVisualStyleBackColor = true;
            //
            // lblModelTreePanelPosition
            //
            this.lblModelTreePanelPosition.AutoSize = true;
            this.lblModelTreePanelPosition.Location = new System.Drawing.Point(15, 54);
            this.lblModelTreePanelPosition.Name = "lblModelTreePanelPosition";
            this.lblModelTreePanelPosition.Size = new System.Drawing.Size(29, 12);
            this.lblModelTreePanelPosition.TabIndex = 1;
            this.lblModelTreePanelPosition.Text = "위치";
            //
            // cbModelTreePanelPosition
            //
            this.cbModelTreePanelPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModelTreePanelPosition.FormattingEnabled = true;
            this.cbModelTreePanelPosition.Location = new System.Drawing.Point(60, 51);
            this.cbModelTreePanelPosition.Name = "cbModelTreePanelPosition";
            this.cbModelTreePanelPosition.Size = new System.Drawing.Size(120, 20);
            this.cbModelTreePanelPosition.TabIndex = 2;
            this.cbModelTreePanelPosition.SelectedIndexChanged += new System.EventHandler(this.cbPanelPosition_SelectedIndexChanged);
            //
            // lblModelTreePanelWidth
            //
            this.lblModelTreePanelWidth.AutoSize = true;
            this.lblModelTreePanelWidth.Location = new System.Drawing.Point(199, 55);
            this.lblModelTreePanelWidth.Name = "lblModelTreePanelWidth";
            this.lblModelTreePanelWidth.Size = new System.Drawing.Size(29, 12);
            this.lblModelTreePanelWidth.TabIndex = 3;
            this.lblModelTreePanelWidth.Text = "너비";
            //
            // numModelTreePanelWidth
            //
            this.numModelTreePanelWidth.Location = new System.Drawing.Point(244, 52);
            this.numModelTreePanelWidth.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numModelTreePanelWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numModelTreePanelWidth.Name = "numModelTreePanelWidth";
            this.numModelTreePanelWidth.Size = new System.Drawing.Size(100, 21);
            this.numModelTreePanelWidth.TabIndex = 4;
            this.numModelTreePanelWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            //
            // tpObserver
            //
            this.tpObserver.AutoScroll = true;
            this.tpObserver.Controls.Add(this.grpObserverFigure);
            this.tpObserver.Controls.Add(this.grpObserverResultColor);
            this.tpObserver.Controls.Add(this.grpObserverView);
            this.tpObserver.Location = new System.Drawing.Point(4, 40);
            this.tpObserver.Name = "tpObserver";
            this.tpObserver.Padding = new System.Windows.Forms.Padding(3);
            this.tpObserver.Size = new System.Drawing.Size(668, 614);
            this.tpObserver.TabIndex = 12;
            this.tpObserver.Text = "옵저버";
            this.tpObserver.UseVisualStyleBackColor = true;
            //
            // grpObserverFigure
            //
            this.grpObserverFigure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpObserverFigure.Controls.Add(this.ckObserverShowFigure);
            this.grpObserverFigure.Controls.Add(this.lblObserverFigureSize);
            this.grpObserverFigure.Controls.Add(this.numObserverFigureSize);
            this.grpObserverFigure.Controls.Add(this.lblObserverFigureColor);
            this.grpObserverFigure.Controls.Add(this.btnObserverFigureColor);
            this.grpObserverFigure.Controls.Add(this.lblObserverRingColor);
            this.grpObserverFigure.Controls.Add(this.btnObserverRingColor);
            this.grpObserverFigure.Controls.Add(this.lblObserverNoseColor);
            this.grpObserverFigure.Controls.Add(this.btnObserverNoseColor);
            this.grpObserverFigure.Location = new System.Drawing.Point(6, 6);
            this.grpObserverFigure.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpObserverFigure.Name = "grpObserverFigure";
            this.grpObserverFigure.Size = new System.Drawing.Size(590, 120);
            this.grpObserverFigure.TabIndex = 0;
            this.grpObserverFigure.TabStop = false;
            this.grpObserverFigure.Text = "표식";
            //
            // ckObserverShowFigure
            //
            this.ckObserverShowFigure.AutoSize = true;
            this.ckObserverShowFigure.Location = new System.Drawing.Point(19, 29);
            this.ckObserverShowFigure.Name = "ckObserverShowFigure";
            this.ckObserverShowFigure.Size = new System.Drawing.Size(84, 16);
            this.ckObserverShowFigure.TabIndex = 0;
            this.ckObserverShowFigure.Text = "표식 그리기";
            this.ckObserverShowFigure.UseVisualStyleBackColor = true;
            //
            // lblObserverFigureSize
            //
            this.lblObserverFigureSize.AutoSize = true;
            this.lblObserverFigureSize.Location = new System.Drawing.Point(300, 32);
            this.lblObserverFigureSize.Name = "lblObserverFigureSize";
            this.lblObserverFigureSize.Size = new System.Drawing.Size(81, 12);
            this.lblObserverFigureSize.TabIndex = 1;
            this.lblObserverFigureSize.Text = "기본 크기 (mm)";
            //
            // numObserverFigureSize
            //
            this.numObserverFigureSize.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numObserverFigureSize.Location = new System.Drawing.Point(442, 27);
            this.numObserverFigureSize.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numObserverFigureSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numObserverFigureSize.Name = "numObserverFigureSize";
            this.numObserverFigureSize.Size = new System.Drawing.Size(120, 21);
            this.numObserverFigureSize.TabIndex = 2;
            this.numObserverFigureSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            //
            // lblObserverFigureColor
            //
            this.lblObserverFigureColor.AutoSize = true;
            this.lblObserverFigureColor.Location = new System.Drawing.Point(17, 60);
            this.lblObserverFigureColor.Name = "lblObserverFigureColor";
            this.lblObserverFigureColor.Size = new System.Drawing.Size(45, 12);
            this.lblObserverFigureColor.TabIndex = 3;
            this.lblObserverFigureColor.Text = "몸체 색";
            //
            // btnObserverFigureColor
            //
            this.btnObserverFigureColor.Location = new System.Drawing.Point(162, 55);
            this.btnObserverFigureColor.Name = "btnObserverFigureColor";
            this.btnObserverFigureColor.Size = new System.Drawing.Size(120, 23);
            this.btnObserverFigureColor.TabIndex = 4;
            this.btnObserverFigureColor.UseVisualStyleBackColor = false;
            this.btnObserverFigureColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // lblObserverRingColor
            //
            this.lblObserverRingColor.AutoSize = true;
            this.lblObserverRingColor.Location = new System.Drawing.Point(300, 60);
            this.lblObserverRingColor.Name = "lblObserverRingColor";
            this.lblObserverRingColor.Size = new System.Drawing.Size(33, 12);
            this.lblObserverRingColor.TabIndex = 5;
            this.lblObserverRingColor.Text = "링 색";
            //
            // btnObserverRingColor
            //
            this.btnObserverRingColor.Location = new System.Drawing.Point(442, 55);
            this.btnObserverRingColor.Name = "btnObserverRingColor";
            this.btnObserverRingColor.Size = new System.Drawing.Size(120, 23);
            this.btnObserverRingColor.TabIndex = 6;
            this.btnObserverRingColor.UseVisualStyleBackColor = false;
            this.btnObserverRingColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // lblObserverNoseColor
            //
            this.lblObserverNoseColor.AutoSize = true;
            this.lblObserverNoseColor.Location = new System.Drawing.Point(17, 90);
            this.lblObserverNoseColor.Name = "lblObserverNoseColor";
            this.lblObserverNoseColor.Size = new System.Drawing.Size(45, 12);
            this.lblObserverNoseColor.TabIndex = 7;
            this.lblObserverNoseColor.Text = "노즈 색";
            //
            // btnObserverNoseColor
            //
            this.btnObserverNoseColor.Location = new System.Drawing.Point(162, 85);
            this.btnObserverNoseColor.Name = "btnObserverNoseColor";
            this.btnObserverNoseColor.Size = new System.Drawing.Size(120, 23);
            this.btnObserverNoseColor.TabIndex = 8;
            this.btnObserverNoseColor.UseVisualStyleBackColor = false;
            this.btnObserverNoseColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // grpObserverResultColor
            //
            this.grpObserverResultColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpObserverResultColor.Controls.Add(this.lblObserverVisibleColor);
            this.grpObserverResultColor.Controls.Add(this.btnObserverVisibleColor);
            this.grpObserverResultColor.Controls.Add(this.lblObserverHiddenColor);
            this.grpObserverResultColor.Controls.Add(this.btnObserverHiddenColor);
            this.grpObserverResultColor.Location = new System.Drawing.Point(6, 134);
            this.grpObserverResultColor.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpObserverResultColor.Name = "grpObserverResultColor";
            this.grpObserverResultColor.Size = new System.Drawing.Size(590, 60);
            this.grpObserverResultColor.TabIndex = 1;
            this.grpObserverResultColor.TabStop = false;
            this.grpObserverResultColor.Text = "분석 결과 색";
            //
            // lblObserverVisibleColor
            //
            this.lblObserverVisibleColor.AutoSize = true;
            this.lblObserverVisibleColor.Location = new System.Drawing.Point(17, 30);
            this.lblObserverVisibleColor.Name = "lblObserverVisibleColor";
            this.lblObserverVisibleColor.Size = new System.Drawing.Size(69, 12);
            this.lblObserverVisibleColor.TabIndex = 0;
            this.lblObserverVisibleColor.Text = "보이는 개체";
            //
            // btnObserverVisibleColor
            //
            this.btnObserverVisibleColor.Location = new System.Drawing.Point(162, 25);
            this.btnObserverVisibleColor.Name = "btnObserverVisibleColor";
            this.btnObserverVisibleColor.Size = new System.Drawing.Size(120, 23);
            this.btnObserverVisibleColor.TabIndex = 1;
            this.btnObserverVisibleColor.UseVisualStyleBackColor = false;
            this.btnObserverVisibleColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // lblObserverHiddenColor
            //
            this.lblObserverHiddenColor.AutoSize = true;
            this.lblObserverHiddenColor.Location = new System.Drawing.Point(300, 30);
            this.lblObserverHiddenColor.Name = "lblObserverHiddenColor";
            this.lblObserverHiddenColor.Size = new System.Drawing.Size(57, 12);
            this.lblObserverHiddenColor.TabIndex = 2;
            this.lblObserverHiddenColor.Text = "사각 개체";
            //
            // btnObserverHiddenColor
            //
            this.btnObserverHiddenColor.Location = new System.Drawing.Point(442, 25);
            this.btnObserverHiddenColor.Name = "btnObserverHiddenColor";
            this.btnObserverHiddenColor.Size = new System.Drawing.Size(120, 23);
            this.btnObserverHiddenColor.TabIndex = 3;
            this.btnObserverHiddenColor.UseVisualStyleBackColor = false;
            this.btnObserverHiddenColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // grpObserverView
            //
            this.grpObserverView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpObserverView.Controls.Add(this.lblObserverAngularStep);
            this.grpObserverView.Controls.Add(this.numObserverAngularStep);
            this.grpObserverView.Controls.Add(this.lblObserverMaxDistance);
            this.grpObserverView.Controls.Add(this.numObserverMaxDistance);
            this.grpObserverView.Controls.Add(this.lblObserverEyeHeight);
            this.grpObserverView.Controls.Add(this.numObserverEyeHeight);
            this.grpObserverView.Location = new System.Drawing.Point(6, 202);
            this.grpObserverView.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpObserverView.Name = "grpObserverView";
            this.grpObserverView.Size = new System.Drawing.Size(590, 90);
            this.grpObserverView.TabIndex = 2;
            this.grpObserverView.TabStop = false;
            this.grpObserverView.Text = "시야 기본값";
            //
            // lblObserverAngularStep
            //
            this.lblObserverAngularStep.AutoSize = true;
            this.lblObserverAngularStep.Location = new System.Drawing.Point(17, 30);
            this.lblObserverAngularStep.Name = "lblObserverAngularStep";
            this.lblObserverAngularStep.Size = new System.Drawing.Size(60, 12);
            this.lblObserverAngularStep.TabIndex = 0;
            this.lblObserverAngularStep.Text = "각 간격 (°)";
            //
            // numObserverAngularStep
            //
            this.numObserverAngularStep.DecimalPlaces = 1;
            this.numObserverAngularStep.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numObserverAngularStep.Location = new System.Drawing.Point(162, 26);
            this.numObserverAngularStep.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numObserverAngularStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numObserverAngularStep.Name = "numObserverAngularStep";
            this.numObserverAngularStep.Size = new System.Drawing.Size(120, 21);
            this.numObserverAngularStep.TabIndex = 1;
            this.numObserverAngularStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            //
            // lblObserverMaxDistance
            //
            this.lblObserverMaxDistance.AutoSize = true;
            this.lblObserverMaxDistance.Location = new System.Drawing.Point(300, 30);
            this.lblObserverMaxDistance.Name = "lblObserverMaxDistance";
            this.lblObserverMaxDistance.Size = new System.Drawing.Size(81, 12);
            this.lblObserverMaxDistance.TabIndex = 2;
            this.lblObserverMaxDistance.Text = "최대 거리 (mm)";
            //
            // numObserverMaxDistance
            //
            this.numObserverMaxDistance.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numObserverMaxDistance.Location = new System.Drawing.Point(442, 26);
            this.numObserverMaxDistance.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numObserverMaxDistance.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numObserverMaxDistance.Name = "numObserverMaxDistance";
            this.numObserverMaxDistance.Size = new System.Drawing.Size(120, 21);
            this.numObserverMaxDistance.TabIndex = 3;
            this.numObserverMaxDistance.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            //
            // lblObserverEyeHeight
            //
            this.lblObserverEyeHeight.AutoSize = true;
            this.lblObserverEyeHeight.Location = new System.Drawing.Point(17, 60);
            this.lblObserverEyeHeight.Name = "lblObserverEyeHeight";
            this.lblObserverEyeHeight.Size = new System.Drawing.Size(69, 12);
            this.lblObserverEyeHeight.TabIndex = 4;
            this.lblObserverEyeHeight.Text = "눈높이 (mm)";
            //
            // numObserverEyeHeight
            //
            this.numObserverEyeHeight.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numObserverEyeHeight.Location = new System.Drawing.Point(162, 56);
            this.numObserverEyeHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numObserverEyeHeight.Name = "numObserverEyeHeight";
            this.numObserverEyeHeight.Size = new System.Drawing.Size(120, 21);
            this.numObserverEyeHeight.TabIndex = 5;
            //
            // tpDevTools
            //
            this.tpDevTools.AutoScroll = true;
            this.tpDevTools.Controls.Add(this.grpDevRendering);
            this.tpDevTools.Controls.Add(this.grpDevCache);
            this.tpDevTools.Controls.Add(this.grpDevInfo);
            this.tpDevTools.Location = new System.Drawing.Point(4, 40);
            this.tpDevTools.Name = "tpDevTools";
            this.tpDevTools.Padding = new System.Windows.Forms.Padding(3);
            this.tpDevTools.Size = new System.Drawing.Size(668, 614);
            this.tpDevTools.TabIndex = 13;
            this.tpDevTools.Text = "개발 도구";
            this.tpDevTools.UseVisualStyleBackColor = true;
            //
            // grpDevRendering
            //
            this.grpDevRendering.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDevRendering.Controls.Add(this.checkAutomaticRenderingLimit);
            this.grpDevRendering.Controls.Add(this.numericRenderingLimitPerStep);
            this.grpDevRendering.Controls.Add(this.numericRenderingLimitInControl);
            this.grpDevRendering.Controls.Add(this.label10);
            this.grpDevRendering.Controls.Add(this.label11);
            this.grpDevRendering.Location = new System.Drawing.Point(6, 120);
            this.grpDevRendering.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpDevRendering.Name = "grpDevRendering";
            this.grpDevRendering.Size = new System.Drawing.Size(590, 81);
            this.grpDevRendering.TabIndex = 12;
            this.grpDevRendering.TabStop = false;
            this.grpDevRendering.Text = "점진적 렌더링";
            //
            // checkAutomaticRenderingLimit
            //
            this.checkAutomaticRenderingLimit.AutoSize = true;
            this.checkAutomaticRenderingLimit.Location = new System.Drawing.Point(24, 54);
            this.checkAutomaticRenderingLimit.Name = "checkAutomaticRenderingLimit";
            this.checkAutomaticRenderingLimit.Size = new System.Drawing.Size(238, 16);
            this.checkAutomaticRenderingLimit.TabIndex = 5;
            this.checkAutomaticRenderingLimit.Text = "자동 렌더링 블록 수 조절 (테스트 기능)";
            this.checkAutomaticRenderingLimit.UseVisualStyleBackColor = true;
            //
            // numericRenderingLimitPerStep
            //
            this.numericRenderingLimitPerStep.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericRenderingLimitPerStep.Location = new System.Drawing.Point(490, 20);
            this.numericRenderingLimitPerStep.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericRenderingLimitPerStep.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericRenderingLimitPerStep.Name = "numericRenderingLimitPerStep";
            this.numericRenderingLimitPerStep.Size = new System.Drawing.Size(84, 21);
            this.numericRenderingLimitPerStep.TabIndex = 2;
            this.numericRenderingLimitPerStep.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            //
            // numericRenderingLimitInControl
            //
            this.numericRenderingLimitInControl.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericRenderingLimitInControl.Location = new System.Drawing.Point(213, 20);
            this.numericRenderingLimitInControl.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericRenderingLimitInControl.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericRenderingLimitInControl.Name = "numericRenderingLimitInControl";
            this.numericRenderingLimitInControl.Size = new System.Drawing.Size(84, 21);
            this.numericRenderingLimitInControl.TabIndex = 1;
            this.numericRenderingLimitInControl.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            //
            // label10
            //
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(314, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "점진적 렌더링 블록 수";
            //
            // label11
            //
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "컨트롤 시 렌더링 블록 수";
            //
            // grpDevCache
            //
            this.grpDevCache.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDevCache.Controls.Add(this.numericTemporaryCacheSize);
            this.grpDevCache.Controls.Add(this.numericPermanentCacheSize);
            this.grpDevCache.Controls.Add(this.label12);
            this.grpDevCache.Controls.Add(this.label13);
            this.grpDevCache.Location = new System.Drawing.Point(6, 59);
            this.grpDevCache.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpDevCache.Name = "grpDevCache";
            this.grpDevCache.Size = new System.Drawing.Size(590, 55);
            this.grpDevCache.TabIndex = 11;
            this.grpDevCache.TabStop = false;
            this.grpDevCache.Text = "캐시 (설정 후 모델 파일 다시 열기 필요)";
            //
            // numericTemporaryCacheSize
            //
            this.numericTemporaryCacheSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericTemporaryCacheSize.Location = new System.Drawing.Point(490, 20);
            this.numericTemporaryCacheSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericTemporaryCacheSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericTemporaryCacheSize.Name = "numericTemporaryCacheSize";
            this.numericTemporaryCacheSize.Size = new System.Drawing.Size(84, 21);
            this.numericTemporaryCacheSize.TabIndex = 1;
            this.numericTemporaryCacheSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            //
            // numericPermanentCacheSize
            //
            this.numericPermanentCacheSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericPermanentCacheSize.Location = new System.Drawing.Point(213, 20);
            this.numericPermanentCacheSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericPermanentCacheSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericPermanentCacheSize.Name = "numericPermanentCacheSize";
            this.numericPermanentCacheSize.Size = new System.Drawing.Size(84, 21);
            this.numericPermanentCacheSize.TabIndex = 1;
            this.numericPermanentCacheSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            //
            // label12
            //
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(314, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "임시 캐시 크기 (MB)";
            //
            // label13
            //
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "고정 캐시 크기 (MB)";
            //
            // grpDevInfo
            //
            this.grpDevInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDevInfo.Controls.Add(this.checkDebugInfo);
            this.grpDevInfo.Location = new System.Drawing.Point(6, 6);
            this.grpDevInfo.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpDevInfo.Name = "grpDevInfo";
            this.grpDevInfo.Size = new System.Drawing.Size(590, 47);
            this.grpDevInfo.TabIndex = 10;
            this.grpDevInfo.TabStop = false;
            this.grpDevInfo.Text = "정보";
            //
            // checkDebugInfo
            //
            this.checkDebugInfo.AutoSize = true;
            this.checkDebugInfo.Location = new System.Drawing.Point(24, 20);
            this.checkDebugInfo.Name = "checkDebugInfo";
            this.checkDebugInfo.Size = new System.Drawing.Size(116, 16);
            this.checkDebugInfo.TabIndex = 4;
            this.checkDebugInfo.Text = "디버그 정보 보기";
            this.checkDebugInfo.UseVisualStyleBackColor = true;
            //
            // tpToolbar
            //
            this.tpToolbar.AutoScroll = true;
            this.tpToolbar.Controls.Add(this.grpToolbarSelectionBox);
            this.tpToolbar.Controls.Add(this.grpToolbarZone);
            this.tpToolbar.Controls.Add(this.grpToolbarEffect);
            this.tpToolbar.Controls.Add(this.grpToolbarObserver);
            this.tpToolbar.Controls.Add(this.grpToolbarRibbon);
            this.tpToolbar.Controls.Add(this.grpToolbarDecal);
            this.tpToolbar.Controls.Add(this.grpToolbarSnapshot);
            this.tpToolbar.Controls.Add(this.grpToolbarPrimitive);
            this.tpToolbar.Controls.Add(this.grpToolbarHome);
            this.tpToolbar.Controls.Add(this.grpToolbarSection);
            this.tpToolbar.Controls.Add(this.grpToolbarMeasure);
            this.tpToolbar.Controls.Add(this.grpToolbarNote);
            this.tpToolbar.Location = new System.Drawing.Point(4, 40);
            this.tpToolbar.Name = "tpToolbar";
            this.tpToolbar.Padding = new System.Windows.Forms.Padding(3);
            this.tpToolbar.Size = new System.Drawing.Size(668, 614);
            this.tpToolbar.TabIndex = 4;
            this.tpToolbar.Text = "툴바";
            this.tpToolbar.UseVisualStyleBackColor = true;
            //
            // grpToolbarRibbon
            //
            this.grpToolbarRibbon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpToolbarRibbon.Controls.Add(this.cbRibbonTheme);
            this.grpToolbarRibbon.Controls.Add(this.lblRibbonTheme);
            this.grpToolbarRibbon.Controls.Add(this.ckRibbonMode);
            this.grpToolbarRibbon.Location = new System.Drawing.Point(6, 6);
            this.grpToolbarRibbon.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpToolbarRibbon.Name = "grpToolbarRibbon";
            this.grpToolbarRibbon.Size = new System.Drawing.Size(590, 69);
            this.grpToolbarRibbon.TabIndex = 3;
            this.grpToolbarRibbon.TabStop = false;
            this.grpToolbarRibbon.Text = "리본";
            //
            // cbRibbonTheme
            //
            this.cbRibbonTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRibbonTheme.FormattingEnabled = true;
            this.cbRibbonTheme.Location = new System.Drawing.Point(203, 30);
            this.cbRibbonTheme.Name = "cbRibbonTheme";
            this.cbRibbonTheme.Size = new System.Drawing.Size(92, 20);
            this.cbRibbonTheme.TabIndex = 2;
            //
            // lblRibbonTheme
            //
            this.lblRibbonTheme.AutoSize = true;
            this.lblRibbonTheme.Location = new System.Drawing.Point(168, 34);
            this.lblRibbonTheme.Name = "lblRibbonTheme";
            this.lblRibbonTheme.Size = new System.Drawing.Size(29, 12);
            this.lblRibbonTheme.TabIndex = 1;
            this.lblRibbonTheme.Text = "테마";
            //
            // ckRibbonMode
            //
            this.ckRibbonMode.AutoSize = true;
            this.ckRibbonMode.Location = new System.Drawing.Point(34, 32);
            this.ckRibbonMode.Name = "ckRibbonMode";
            this.ckRibbonMode.Size = new System.Drawing.Size(91, 16);
            this.ckRibbonMode.TabIndex = 0;
            this.ckRibbonMode.Text = "리본 UI 사용";
            this.ckRibbonMode.UseVisualStyleBackColor = true;
            this.ckRibbonMode.CheckedChanged += new System.EventHandler(this.ckRibbonMode_CheckedChanged);
            //
            // grpToolbarHome
            //
            this.grpToolbarHome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpToolbarHome.Controls.Add(this.lblToolbarHomeRow);
            this.grpToolbarHome.Controls.Add(this.numToolbarHomeRow);
            this.grpToolbarHome.Controls.Add(this.lblToolbarHomeOrder);
            this.grpToolbarHome.Controls.Add(this.numToolbarHomeOrder);
            this.grpToolbarHome.Controls.Add(this.rbToolbarHomeRight);
            this.grpToolbarHome.Controls.Add(this.rbToolbarHomeLeft);
            this.grpToolbarHome.Controls.Add(this.rbToolbarHomeTop);
            this.grpToolbarHome.Controls.Add(this.ckToolbarHome);
            this.grpToolbarHome.Location = new System.Drawing.Point(6, 81);
            this.grpToolbarHome.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpToolbarHome.Name = "grpToolbarHome";
            this.grpToolbarHome.Size = new System.Drawing.Size(590, 69);
            this.grpToolbarHome.TabIndex = 4;
            this.grpToolbarHome.TabStop = false;
            this.grpToolbarHome.Text = "홈";
            //
            // lblToolbarHomeRow
            //
            this.lblToolbarHomeRow.AutoSize = true;
            this.lblToolbarHomeRow.Location = new System.Drawing.Point(400, 34);
            this.lblToolbarHomeRow.Name = "lblToolbarHomeRow";
            this.lblToolbarHomeRow.Size = new System.Drawing.Size(17, 12);
            this.lblToolbarHomeRow.TabIndex = 0;
            this.lblToolbarHomeRow.Text = "줄";
            //
            // numToolbarHomeRow
            //
            this.numToolbarHomeRow.Location = new System.Drawing.Point(420, 30);
            this.numToolbarHomeRow.Name = "numToolbarHomeRow";
            this.numToolbarHomeRow.Size = new System.Drawing.Size(46, 21);
            this.numToolbarHomeRow.TabIndex = 4;
            //
            // lblToolbarHomeOrder
            //
            this.lblToolbarHomeOrder.AutoSize = true;
            this.lblToolbarHomeOrder.Location = new System.Drawing.Point(475, 34);
            this.lblToolbarHomeOrder.Name = "lblToolbarHomeOrder";
            this.lblToolbarHomeOrder.Size = new System.Drawing.Size(29, 12);
            this.lblToolbarHomeOrder.TabIndex = 5;
            this.lblToolbarHomeOrder.Text = "순서";
            //
            // numToolbarHomeOrder
            //
            this.numToolbarHomeOrder.Location = new System.Drawing.Point(510, 30);
            this.numToolbarHomeOrder.Name = "numToolbarHomeOrder";
            this.numToolbarHomeOrder.Size = new System.Drawing.Size(46, 21);
            this.numToolbarHomeOrder.TabIndex = 5;
            //
            // rbToolbarHomeRight
            //
            this.rbToolbarHomeRight.AutoSize = true;
            this.rbToolbarHomeRight.Location = new System.Drawing.Point(296, 32);
            this.rbToolbarHomeRight.Name = "rbToolbarHomeRight";
            this.rbToolbarHomeRight.Size = new System.Drawing.Size(59, 16);
            this.rbToolbarHomeRight.TabIndex = 3;
            this.rbToolbarHomeRight.Text = "오른쪽";
            this.rbToolbarHomeRight.UseVisualStyleBackColor = true;
            //
            // rbToolbarHomeLeft
            //
            this.rbToolbarHomeLeft.AutoSize = true;
            this.rbToolbarHomeLeft.Location = new System.Drawing.Point(221, 32);
            this.rbToolbarHomeLeft.Name = "rbToolbarHomeLeft";
            this.rbToolbarHomeLeft.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarHomeLeft.TabIndex = 2;
            this.rbToolbarHomeLeft.Text = "왼쪽";
            this.rbToolbarHomeLeft.UseVisualStyleBackColor = true;
            //
            // rbToolbarHomeTop
            //
            this.rbToolbarHomeTop.AutoSize = true;
            this.rbToolbarHomeTop.Checked = true;
            this.rbToolbarHomeTop.Location = new System.Drawing.Point(145, 32);
            this.rbToolbarHomeTop.Name = "rbToolbarHomeTop";
            this.rbToolbarHomeTop.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarHomeTop.TabIndex = 1;
            this.rbToolbarHomeTop.TabStop = true;
            this.rbToolbarHomeTop.Text = "상단";
            this.rbToolbarHomeTop.UseVisualStyleBackColor = true;
            //
            // ckToolbarHome
            //
            this.ckToolbarHome.AutoSize = true;
            this.ckToolbarHome.Checked = true;
            this.ckToolbarHome.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckToolbarHome.Location = new System.Drawing.Point(34, 32);
            this.ckToolbarHome.Name = "ckToolbarHome";
            this.ckToolbarHome.Size = new System.Drawing.Size(60, 16);
            this.ckToolbarHome.TabIndex = 0;
            this.ckToolbarHome.Text = "보이기";
            this.ckToolbarHome.UseVisualStyleBackColor = true;
            //
            // grpToolbarNote
            //
            this.grpToolbarNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpToolbarNote.Controls.Add(this.lblToolbarNoteRow);
            this.grpToolbarNote.Controls.Add(this.numToolbarNoteRow);
            this.grpToolbarNote.Controls.Add(this.lblToolbarNoteOrder);
            this.grpToolbarNote.Controls.Add(this.numToolbarNoteOrder);
            this.grpToolbarNote.Controls.Add(this.rbToolbarNoteRight);
            this.grpToolbarNote.Controls.Add(this.rbToolbarNoteLeft);
            this.grpToolbarNote.Controls.Add(this.rbToolbarNoteTop);
            this.grpToolbarNote.Controls.Add(this.ckToolbarNote);
            this.grpToolbarNote.Location = new System.Drawing.Point(6, 156);
            this.grpToolbarNote.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpToolbarNote.Name = "grpToolbarNote";
            this.grpToolbarNote.Size = new System.Drawing.Size(590, 69);
            this.grpToolbarNote.TabIndex = 1;
            this.grpToolbarNote.TabStop = false;
            this.grpToolbarNote.Text = "노트";
            //
            // lblToolbarNoteRow
            //
            this.lblToolbarNoteRow.AutoSize = true;
            this.lblToolbarNoteRow.Location = new System.Drawing.Point(400, 34);
            this.lblToolbarNoteRow.Name = "lblToolbarNoteRow";
            this.lblToolbarNoteRow.Size = new System.Drawing.Size(17, 12);
            this.lblToolbarNoteRow.TabIndex = 0;
            this.lblToolbarNoteRow.Text = "줄";
            //
            // numToolbarNoteRow
            //
            this.numToolbarNoteRow.Location = new System.Drawing.Point(420, 30);
            this.numToolbarNoteRow.Name = "numToolbarNoteRow";
            this.numToolbarNoteRow.Size = new System.Drawing.Size(46, 21);
            this.numToolbarNoteRow.TabIndex = 4;
            //
            // lblToolbarNoteOrder
            //
            this.lblToolbarNoteOrder.AutoSize = true;
            this.lblToolbarNoteOrder.Location = new System.Drawing.Point(475, 34);
            this.lblToolbarNoteOrder.Name = "lblToolbarNoteOrder";
            this.lblToolbarNoteOrder.Size = new System.Drawing.Size(29, 12);
            this.lblToolbarNoteOrder.TabIndex = 5;
            this.lblToolbarNoteOrder.Text = "순서";
            //
            // numToolbarNoteOrder
            //
            this.numToolbarNoteOrder.Location = new System.Drawing.Point(510, 30);
            this.numToolbarNoteOrder.Name = "numToolbarNoteOrder";
            this.numToolbarNoteOrder.Size = new System.Drawing.Size(46, 21);
            this.numToolbarNoteOrder.TabIndex = 5;
            //
            // rbToolbarNoteRight
            //
            this.rbToolbarNoteRight.AutoSize = true;
            this.rbToolbarNoteRight.Location = new System.Drawing.Point(296, 32);
            this.rbToolbarNoteRight.Name = "rbToolbarNoteRight";
            this.rbToolbarNoteRight.Size = new System.Drawing.Size(59, 16);
            this.rbToolbarNoteRight.TabIndex = 3;
            this.rbToolbarNoteRight.Text = "오른쪽";
            this.rbToolbarNoteRight.UseVisualStyleBackColor = true;
            //
            // rbToolbarNoteLeft
            //
            this.rbToolbarNoteLeft.AutoSize = true;
            this.rbToolbarNoteLeft.Location = new System.Drawing.Point(221, 32);
            this.rbToolbarNoteLeft.Name = "rbToolbarNoteLeft";
            this.rbToolbarNoteLeft.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarNoteLeft.TabIndex = 2;
            this.rbToolbarNoteLeft.Text = "왼쪽";
            this.rbToolbarNoteLeft.UseVisualStyleBackColor = true;
            //
            // rbToolbarNoteTop
            //
            this.rbToolbarNoteTop.AutoSize = true;
            this.rbToolbarNoteTop.Checked = true;
            this.rbToolbarNoteTop.Location = new System.Drawing.Point(145, 32);
            this.rbToolbarNoteTop.Name = "rbToolbarNoteTop";
            this.rbToolbarNoteTop.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarNoteTop.TabIndex = 1;
            this.rbToolbarNoteTop.TabStop = true;
            this.rbToolbarNoteTop.Text = "상단";
            this.rbToolbarNoteTop.UseVisualStyleBackColor = true;
            //
            // ckToolbarNote
            //
            this.ckToolbarNote.AutoSize = true;
            this.ckToolbarNote.Checked = true;
            this.ckToolbarNote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckToolbarNote.Location = new System.Drawing.Point(34, 32);
            this.ckToolbarNote.Name = "ckToolbarNote";
            this.ckToolbarNote.Size = new System.Drawing.Size(60, 16);
            this.ckToolbarNote.TabIndex = 0;
            this.ckToolbarNote.Text = "보이기";
            this.ckToolbarNote.UseVisualStyleBackColor = true;
            //
            // grpToolbarMeasure
            //
            this.grpToolbarMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpToolbarMeasure.Controls.Add(this.lblToolbarMeasureRow);
            this.grpToolbarMeasure.Controls.Add(this.numToolbarMeasureRow);
            this.grpToolbarMeasure.Controls.Add(this.lblToolbarMeasureOrder);
            this.grpToolbarMeasure.Controls.Add(this.numToolbarMeasureOrder);
            this.grpToolbarMeasure.Controls.Add(this.rbToolbarMeasureRight);
            this.grpToolbarMeasure.Controls.Add(this.rbToolbarMeasureLeft);
            this.grpToolbarMeasure.Controls.Add(this.rbToolbarMeasureTop);
            this.grpToolbarMeasure.Controls.Add(this.ckToolbarMeasure);
            this.grpToolbarMeasure.Location = new System.Drawing.Point(6, 231);
            this.grpToolbarMeasure.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpToolbarMeasure.Name = "grpToolbarMeasure";
            this.grpToolbarMeasure.Size = new System.Drawing.Size(590, 69);
            this.grpToolbarMeasure.TabIndex = 2;
            this.grpToolbarMeasure.TabStop = false;
            this.grpToolbarMeasure.Text = "측정";
            //
            // lblToolbarMeasureRow
            //
            this.lblToolbarMeasureRow.AutoSize = true;
            this.lblToolbarMeasureRow.Location = new System.Drawing.Point(400, 34);
            this.lblToolbarMeasureRow.Name = "lblToolbarMeasureRow";
            this.lblToolbarMeasureRow.Size = new System.Drawing.Size(17, 12);
            this.lblToolbarMeasureRow.TabIndex = 0;
            this.lblToolbarMeasureRow.Text = "줄";
            //
            // numToolbarMeasureRow
            //
            this.numToolbarMeasureRow.Location = new System.Drawing.Point(420, 30);
            this.numToolbarMeasureRow.Name = "numToolbarMeasureRow";
            this.numToolbarMeasureRow.Size = new System.Drawing.Size(46, 21);
            this.numToolbarMeasureRow.TabIndex = 4;
            //
            // lblToolbarMeasureOrder
            //
            this.lblToolbarMeasureOrder.AutoSize = true;
            this.lblToolbarMeasureOrder.Location = new System.Drawing.Point(475, 34);
            this.lblToolbarMeasureOrder.Name = "lblToolbarMeasureOrder";
            this.lblToolbarMeasureOrder.Size = new System.Drawing.Size(29, 12);
            this.lblToolbarMeasureOrder.TabIndex = 5;
            this.lblToolbarMeasureOrder.Text = "순서";
            //
            // numToolbarMeasureOrder
            //
            this.numToolbarMeasureOrder.Location = new System.Drawing.Point(510, 30);
            this.numToolbarMeasureOrder.Name = "numToolbarMeasureOrder";
            this.numToolbarMeasureOrder.Size = new System.Drawing.Size(46, 21);
            this.numToolbarMeasureOrder.TabIndex = 5;
            //
            // rbToolbarMeasureRight
            //
            this.rbToolbarMeasureRight.AutoSize = true;
            this.rbToolbarMeasureRight.Location = new System.Drawing.Point(296, 28);
            this.rbToolbarMeasureRight.Name = "rbToolbarMeasureRight";
            this.rbToolbarMeasureRight.Size = new System.Drawing.Size(59, 16);
            this.rbToolbarMeasureRight.TabIndex = 6;
            this.rbToolbarMeasureRight.Text = "오른쪽";
            this.rbToolbarMeasureRight.UseVisualStyleBackColor = true;
            //
            // rbToolbarMeasureLeft
            //
            this.rbToolbarMeasureLeft.AutoSize = true;
            this.rbToolbarMeasureLeft.Location = new System.Drawing.Point(221, 28);
            this.rbToolbarMeasureLeft.Name = "rbToolbarMeasureLeft";
            this.rbToolbarMeasureLeft.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarMeasureLeft.TabIndex = 5;
            this.rbToolbarMeasureLeft.Text = "왼쪽";
            this.rbToolbarMeasureLeft.UseVisualStyleBackColor = true;
            //
            // rbToolbarMeasureTop
            //
            this.rbToolbarMeasureTop.AutoSize = true;
            this.rbToolbarMeasureTop.Checked = true;
            this.rbToolbarMeasureTop.Location = new System.Drawing.Point(145, 28);
            this.rbToolbarMeasureTop.Name = "rbToolbarMeasureTop";
            this.rbToolbarMeasureTop.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarMeasureTop.TabIndex = 4;
            this.rbToolbarMeasureTop.TabStop = true;
            this.rbToolbarMeasureTop.Text = "상단";
            this.rbToolbarMeasureTop.UseVisualStyleBackColor = true;
            //
            // ckToolbarMeasure
            //
            this.ckToolbarMeasure.AutoSize = true;
            this.ckToolbarMeasure.Checked = true;
            this.ckToolbarMeasure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckToolbarMeasure.Location = new System.Drawing.Point(34, 29);
            this.ckToolbarMeasure.Name = "ckToolbarMeasure";
            this.ckToolbarMeasure.Size = new System.Drawing.Size(60, 16);
            this.ckToolbarMeasure.TabIndex = 1;
            this.ckToolbarMeasure.Text = "보이기";
            this.ckToolbarMeasure.UseVisualStyleBackColor = true;
            //
            // grpToolbarSection
            //
            this.grpToolbarSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpToolbarSection.Controls.Add(this.lblToolbarSectionRow);
            this.grpToolbarSection.Controls.Add(this.numToolbarSectionRow);
            this.grpToolbarSection.Controls.Add(this.lblToolbarSectionOrder);
            this.grpToolbarSection.Controls.Add(this.numToolbarSectionOrder);
            this.grpToolbarSection.Controls.Add(this.rbToolbarSectionRight);
            this.grpToolbarSection.Controls.Add(this.rbToolbarSectionLeft);
            this.grpToolbarSection.Controls.Add(this.rbToolbarSectionTop);
            this.grpToolbarSection.Controls.Add(this.ckToolbarSection);
            this.grpToolbarSection.Location = new System.Drawing.Point(6, 306);
            this.grpToolbarSection.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpToolbarSection.Name = "grpToolbarSection";
            this.grpToolbarSection.Size = new System.Drawing.Size(590, 69);
            this.grpToolbarSection.TabIndex = 3;
            this.grpToolbarSection.TabStop = false;
            this.grpToolbarSection.Text = "단면";
            //
            // lblToolbarSectionRow
            //
            this.lblToolbarSectionRow.AutoSize = true;
            this.lblToolbarSectionRow.Location = new System.Drawing.Point(400, 34);
            this.lblToolbarSectionRow.Name = "lblToolbarSectionRow";
            this.lblToolbarSectionRow.Size = new System.Drawing.Size(17, 12);
            this.lblToolbarSectionRow.TabIndex = 0;
            this.lblToolbarSectionRow.Text = "줄";
            //
            // numToolbarSectionRow
            //
            this.numToolbarSectionRow.Location = new System.Drawing.Point(420, 30);
            this.numToolbarSectionRow.Name = "numToolbarSectionRow";
            this.numToolbarSectionRow.Size = new System.Drawing.Size(46, 21);
            this.numToolbarSectionRow.TabIndex = 4;
            //
            // lblToolbarSectionOrder
            //
            this.lblToolbarSectionOrder.AutoSize = true;
            this.lblToolbarSectionOrder.Location = new System.Drawing.Point(475, 34);
            this.lblToolbarSectionOrder.Name = "lblToolbarSectionOrder";
            this.lblToolbarSectionOrder.Size = new System.Drawing.Size(29, 12);
            this.lblToolbarSectionOrder.TabIndex = 5;
            this.lblToolbarSectionOrder.Text = "순서";
            //
            // numToolbarSectionOrder
            //
            this.numToolbarSectionOrder.Location = new System.Drawing.Point(510, 30);
            this.numToolbarSectionOrder.Name = "numToolbarSectionOrder";
            this.numToolbarSectionOrder.Size = new System.Drawing.Size(46, 21);
            this.numToolbarSectionOrder.TabIndex = 5;
            //
            // rbToolbarSectionRight
            //
            this.rbToolbarSectionRight.AutoSize = true;
            this.rbToolbarSectionRight.Location = new System.Drawing.Point(296, 29);
            this.rbToolbarSectionRight.Name = "rbToolbarSectionRight";
            this.rbToolbarSectionRight.Size = new System.Drawing.Size(59, 16);
            this.rbToolbarSectionRight.TabIndex = 9;
            this.rbToolbarSectionRight.Text = "오른쪽";
            this.rbToolbarSectionRight.UseVisualStyleBackColor = true;
            //
            // rbToolbarSectionLeft
            //
            this.rbToolbarSectionLeft.AutoSize = true;
            this.rbToolbarSectionLeft.Location = new System.Drawing.Point(221, 29);
            this.rbToolbarSectionLeft.Name = "rbToolbarSectionLeft";
            this.rbToolbarSectionLeft.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarSectionLeft.TabIndex = 8;
            this.rbToolbarSectionLeft.Text = "왼쪽";
            this.rbToolbarSectionLeft.UseVisualStyleBackColor = true;
            //
            // rbToolbarSectionTop
            //
            this.rbToolbarSectionTop.AutoSize = true;
            this.rbToolbarSectionTop.Checked = true;
            this.rbToolbarSectionTop.Location = new System.Drawing.Point(145, 29);
            this.rbToolbarSectionTop.Name = "rbToolbarSectionTop";
            this.rbToolbarSectionTop.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarSectionTop.TabIndex = 7;
            this.rbToolbarSectionTop.TabStop = true;
            this.rbToolbarSectionTop.Text = "상단";
            this.rbToolbarSectionTop.UseVisualStyleBackColor = true;
            //
            // ckToolbarSection
            //
            this.ckToolbarSection.AutoSize = true;
            this.ckToolbarSection.Checked = true;
            this.ckToolbarSection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckToolbarSection.Location = new System.Drawing.Point(34, 30);
            this.ckToolbarSection.Name = "ckToolbarSection";
            this.ckToolbarSection.Size = new System.Drawing.Size(60, 16);
            this.ckToolbarSection.TabIndex = 2;
            this.ckToolbarSection.Text = "보이기";
            this.ckToolbarSection.UseVisualStyleBackColor = true;
            //
            // grpToolbarSnapshot
            //
            this.grpToolbarSnapshot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpToolbarSnapshot.Controls.Add(this.lblToolbarSnapshotRow);
            this.grpToolbarSnapshot.Controls.Add(this.numToolbarSnapshotRow);
            this.grpToolbarSnapshot.Controls.Add(this.lblToolbarSnapshotOrder);
            this.grpToolbarSnapshot.Controls.Add(this.numToolbarSnapshotOrder);
            this.grpToolbarSnapshot.Controls.Add(this.rbToolbarSnapshotRight);
            this.grpToolbarSnapshot.Controls.Add(this.rbToolbarSnapshotLeft);
            this.grpToolbarSnapshot.Controls.Add(this.rbToolbarSnapshotTop);
            this.grpToolbarSnapshot.Controls.Add(this.ckToolbarSnapshot);
            this.grpToolbarSnapshot.Location = new System.Drawing.Point(6, 531);
            this.grpToolbarSnapshot.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpToolbarSnapshot.Name = "grpToolbarSnapshot";
            this.grpToolbarSnapshot.Size = new System.Drawing.Size(590, 69);
            this.grpToolbarSnapshot.TabIndex = 7;
            this.grpToolbarSnapshot.TabStop = false;
            this.grpToolbarSnapshot.Text = "스냅샷";
            //
            // lblToolbarSnapshotRow
            //
            this.lblToolbarSnapshotRow.AutoSize = true;
            this.lblToolbarSnapshotRow.Location = new System.Drawing.Point(400, 34);
            this.lblToolbarSnapshotRow.Name = "lblToolbarSnapshotRow";
            this.lblToolbarSnapshotRow.Size = new System.Drawing.Size(17, 12);
            this.lblToolbarSnapshotRow.TabIndex = 0;
            this.lblToolbarSnapshotRow.Text = "줄";
            //
            // numToolbarSnapshotRow
            //
            this.numToolbarSnapshotRow.Location = new System.Drawing.Point(420, 30);
            this.numToolbarSnapshotRow.Name = "numToolbarSnapshotRow";
            this.numToolbarSnapshotRow.Size = new System.Drawing.Size(46, 21);
            this.numToolbarSnapshotRow.TabIndex = 4;
            //
            // lblToolbarSnapshotOrder
            //
            this.lblToolbarSnapshotOrder.AutoSize = true;
            this.lblToolbarSnapshotOrder.Location = new System.Drawing.Point(475, 34);
            this.lblToolbarSnapshotOrder.Name = "lblToolbarSnapshotOrder";
            this.lblToolbarSnapshotOrder.Size = new System.Drawing.Size(29, 12);
            this.lblToolbarSnapshotOrder.TabIndex = 5;
            this.lblToolbarSnapshotOrder.Text = "순서";
            //
            // numToolbarSnapshotOrder
            //
            this.numToolbarSnapshotOrder.Location = new System.Drawing.Point(510, 30);
            this.numToolbarSnapshotOrder.Name = "numToolbarSnapshotOrder";
            this.numToolbarSnapshotOrder.Size = new System.Drawing.Size(46, 21);
            this.numToolbarSnapshotOrder.TabIndex = 5;
            //
            // rbToolbarSnapshotRight
            //
            this.rbToolbarSnapshotRight.AutoSize = true;
            this.rbToolbarSnapshotRight.Location = new System.Drawing.Point(296, 32);
            this.rbToolbarSnapshotRight.Name = "rbToolbarSnapshotRight";
            this.rbToolbarSnapshotRight.Size = new System.Drawing.Size(59, 16);
            this.rbToolbarSnapshotRight.TabIndex = 3;
            this.rbToolbarSnapshotRight.Text = "오른쪽";
            this.rbToolbarSnapshotRight.UseVisualStyleBackColor = true;
            //
            // rbToolbarSnapshotLeft
            //
            this.rbToolbarSnapshotLeft.AutoSize = true;
            this.rbToolbarSnapshotLeft.Location = new System.Drawing.Point(221, 32);
            this.rbToolbarSnapshotLeft.Name = "rbToolbarSnapshotLeft";
            this.rbToolbarSnapshotLeft.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarSnapshotLeft.TabIndex = 2;
            this.rbToolbarSnapshotLeft.Text = "왼쪽";
            this.rbToolbarSnapshotLeft.UseVisualStyleBackColor = true;
            //
            // rbToolbarSnapshotTop
            //
            this.rbToolbarSnapshotTop.AutoSize = true;
            this.rbToolbarSnapshotTop.Checked = true;
            this.rbToolbarSnapshotTop.Location = new System.Drawing.Point(145, 32);
            this.rbToolbarSnapshotTop.Name = "rbToolbarSnapshotTop";
            this.rbToolbarSnapshotTop.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarSnapshotTop.TabIndex = 1;
            this.rbToolbarSnapshotTop.TabStop = true;
            this.rbToolbarSnapshotTop.Text = "상단";
            this.rbToolbarSnapshotTop.UseVisualStyleBackColor = true;
            //
            // ckToolbarSnapshot
            //
            this.ckToolbarSnapshot.AutoSize = true;
            this.ckToolbarSnapshot.Checked = true;
            this.ckToolbarSnapshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckToolbarSnapshot.Location = new System.Drawing.Point(34, 32);
            this.ckToolbarSnapshot.Name = "ckToolbarSnapshot";
            this.ckToolbarSnapshot.Size = new System.Drawing.Size(60, 16);
            this.ckToolbarSnapshot.TabIndex = 0;
            this.ckToolbarSnapshot.Text = "보이기";
            this.ckToolbarSnapshot.UseVisualStyleBackColor = true;
            //
            // grpToolbarDecal
            //
            this.grpToolbarDecal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpToolbarDecal.Controls.Add(this.lblToolbarDecalRow);
            this.grpToolbarDecal.Controls.Add(this.numToolbarDecalRow);
            this.grpToolbarDecal.Controls.Add(this.lblToolbarDecalOrder);
            this.grpToolbarDecal.Controls.Add(this.numToolbarDecalOrder);
            this.grpToolbarDecal.Controls.Add(this.rbToolbarDecalRight);
            this.grpToolbarDecal.Controls.Add(this.rbToolbarDecalLeft);
            this.grpToolbarDecal.Controls.Add(this.rbToolbarDecalTop);
            this.grpToolbarDecal.Controls.Add(this.ckToolbarDecal);
            this.grpToolbarDecal.Location = new System.Drawing.Point(6, 381);
            this.grpToolbarDecal.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpToolbarDecal.Name = "grpToolbarDecal";
            this.grpToolbarDecal.Size = new System.Drawing.Size(590, 69);
            this.grpToolbarDecal.TabIndex = 5;
            this.grpToolbarDecal.TabStop = false;
            this.grpToolbarDecal.Text = "데칼";
            //
            // lblToolbarDecalRow
            //
            this.lblToolbarDecalRow.AutoSize = true;
            this.lblToolbarDecalRow.Location = new System.Drawing.Point(400, 34);
            this.lblToolbarDecalRow.Name = "lblToolbarDecalRow";
            this.lblToolbarDecalRow.Size = new System.Drawing.Size(17, 12);
            this.lblToolbarDecalRow.TabIndex = 0;
            this.lblToolbarDecalRow.Text = "줄";
            //
            // numToolbarDecalRow
            //
            this.numToolbarDecalRow.Location = new System.Drawing.Point(420, 30);
            this.numToolbarDecalRow.Name = "numToolbarDecalRow";
            this.numToolbarDecalRow.Size = new System.Drawing.Size(46, 21);
            this.numToolbarDecalRow.TabIndex = 4;
            //
            // lblToolbarDecalOrder
            //
            this.lblToolbarDecalOrder.AutoSize = true;
            this.lblToolbarDecalOrder.Location = new System.Drawing.Point(475, 34);
            this.lblToolbarDecalOrder.Name = "lblToolbarDecalOrder";
            this.lblToolbarDecalOrder.Size = new System.Drawing.Size(29, 12);
            this.lblToolbarDecalOrder.TabIndex = 5;
            this.lblToolbarDecalOrder.Text = "순서";
            //
            // numToolbarDecalOrder
            //
            this.numToolbarDecalOrder.Location = new System.Drawing.Point(510, 30);
            this.numToolbarDecalOrder.Name = "numToolbarDecalOrder";
            this.numToolbarDecalOrder.Size = new System.Drawing.Size(46, 21);
            this.numToolbarDecalOrder.TabIndex = 5;
            //
            // rbToolbarDecalRight
            //
            this.rbToolbarDecalRight.AutoSize = true;
            this.rbToolbarDecalRight.Location = new System.Drawing.Point(296, 32);
            this.rbToolbarDecalRight.Name = "rbToolbarDecalRight";
            this.rbToolbarDecalRight.Size = new System.Drawing.Size(59, 16);
            this.rbToolbarDecalRight.TabIndex = 3;
            this.rbToolbarDecalRight.Text = "오른쪽";
            this.rbToolbarDecalRight.UseVisualStyleBackColor = true;
            //
            // rbToolbarDecalLeft
            //
            this.rbToolbarDecalLeft.AutoSize = true;
            this.rbToolbarDecalLeft.Location = new System.Drawing.Point(221, 32);
            this.rbToolbarDecalLeft.Name = "rbToolbarDecalLeft";
            this.rbToolbarDecalLeft.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarDecalLeft.TabIndex = 2;
            this.rbToolbarDecalLeft.Text = "왼쪽";
            this.rbToolbarDecalLeft.UseVisualStyleBackColor = true;
            //
            // rbToolbarDecalTop
            //
            this.rbToolbarDecalTop.AutoSize = true;
            this.rbToolbarDecalTop.Checked = true;
            this.rbToolbarDecalTop.Location = new System.Drawing.Point(145, 32);
            this.rbToolbarDecalTop.Name = "rbToolbarDecalTop";
            this.rbToolbarDecalTop.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarDecalTop.TabIndex = 1;
            this.rbToolbarDecalTop.TabStop = true;
            this.rbToolbarDecalTop.Text = "상단";
            this.rbToolbarDecalTop.UseVisualStyleBackColor = true;
            //
            // ckToolbarDecal
            //
            this.ckToolbarDecal.AutoSize = true;
            this.ckToolbarDecal.Checked = true;
            this.ckToolbarDecal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckToolbarDecal.Location = new System.Drawing.Point(34, 32);
            this.ckToolbarDecal.Name = "ckToolbarDecal";
            this.ckToolbarDecal.Size = new System.Drawing.Size(60, 16);
            this.ckToolbarDecal.TabIndex = 0;
            this.ckToolbarDecal.Text = "보이기";
            this.ckToolbarDecal.UseVisualStyleBackColor = true;
            //
            // grpToolbarPrimitive
            //
            this.grpToolbarPrimitive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpToolbarPrimitive.AutoSize = true;
            this.grpToolbarPrimitive.Controls.Add(this.lblToolbarPrimitiveRow);
            this.grpToolbarPrimitive.Controls.Add(this.numToolbarPrimitiveRow);
            this.grpToolbarPrimitive.Controls.Add(this.lblToolbarPrimitiveOrder);
            this.grpToolbarPrimitive.Controls.Add(this.numToolbarPrimitiveOrder);
            this.grpToolbarPrimitive.Controls.Add(this.rbToolbarPrimitiveRight);
            this.grpToolbarPrimitive.Controls.Add(this.rbToolbarPrimitiveLeft);
            this.grpToolbarPrimitive.Controls.Add(this.rbToolbarPrimitiveTop);
            this.grpToolbarPrimitive.Controls.Add(this.ckToolbarPrimitive);
            this.grpToolbarPrimitive.Location = new System.Drawing.Point(6, 456);
            this.grpToolbarPrimitive.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpToolbarPrimitive.Name = "grpToolbarPrimitive";
            this.grpToolbarPrimitive.Size = new System.Drawing.Size(590, 69);
            this.grpToolbarPrimitive.TabIndex = 6;
            this.grpToolbarPrimitive.TabStop = false;
            this.grpToolbarPrimitive.Text = "형상 생성";
            //
            // lblToolbarPrimitiveRow
            //
            this.lblToolbarPrimitiveRow.AutoSize = true;
            this.lblToolbarPrimitiveRow.Location = new System.Drawing.Point(400, 32);
            this.lblToolbarPrimitiveRow.Name = "lblToolbarPrimitiveRow";
            this.lblToolbarPrimitiveRow.Size = new System.Drawing.Size(17, 12);
            this.lblToolbarPrimitiveRow.TabIndex = 0;
            this.lblToolbarPrimitiveRow.Text = "줄";
            //
            // numToolbarPrimitiveRow
            //
            this.numToolbarPrimitiveRow.Location = new System.Drawing.Point(420, 28);
            this.numToolbarPrimitiveRow.Name = "numToolbarPrimitiveRow";
            this.numToolbarPrimitiveRow.Size = new System.Drawing.Size(46, 21);
            this.numToolbarPrimitiveRow.TabIndex = 4;
            //
            // lblToolbarPrimitiveOrder
            //
            this.lblToolbarPrimitiveOrder.AutoSize = true;
            this.lblToolbarPrimitiveOrder.Location = new System.Drawing.Point(475, 32);
            this.lblToolbarPrimitiveOrder.Name = "lblToolbarPrimitiveOrder";
            this.lblToolbarPrimitiveOrder.Size = new System.Drawing.Size(29, 12);
            this.lblToolbarPrimitiveOrder.TabIndex = 5;
            this.lblToolbarPrimitiveOrder.Text = "순서";
            //
            // numToolbarPrimitiveOrder
            //
            this.numToolbarPrimitiveOrder.Location = new System.Drawing.Point(510, 28);
            this.numToolbarPrimitiveOrder.Name = "numToolbarPrimitiveOrder";
            this.numToolbarPrimitiveOrder.Size = new System.Drawing.Size(46, 21);
            this.numToolbarPrimitiveOrder.TabIndex = 5;
            //
            // rbToolbarPrimitiveRight
            //
            this.rbToolbarPrimitiveRight.AutoSize = true;
            this.rbToolbarPrimitiveRight.Location = new System.Drawing.Point(296, 30);
            this.rbToolbarPrimitiveRight.Name = "rbToolbarPrimitiveRight";
            this.rbToolbarPrimitiveRight.Size = new System.Drawing.Size(59, 16);
            this.rbToolbarPrimitiveRight.TabIndex = 9;
            this.rbToolbarPrimitiveRight.Text = "오른쪽";
            this.rbToolbarPrimitiveRight.UseVisualStyleBackColor = true;
            //
            // rbToolbarPrimitiveLeft
            //
            this.rbToolbarPrimitiveLeft.AutoSize = true;
            this.rbToolbarPrimitiveLeft.Location = new System.Drawing.Point(221, 30);
            this.rbToolbarPrimitiveLeft.Name = "rbToolbarPrimitiveLeft";
            this.rbToolbarPrimitiveLeft.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarPrimitiveLeft.TabIndex = 8;
            this.rbToolbarPrimitiveLeft.Text = "왼쪽";
            this.rbToolbarPrimitiveLeft.UseVisualStyleBackColor = true;
            //
            // rbToolbarPrimitiveTop
            //
            this.rbToolbarPrimitiveTop.AutoSize = true;
            this.rbToolbarPrimitiveTop.Checked = true;
            this.rbToolbarPrimitiveTop.Location = new System.Drawing.Point(145, 30);
            this.rbToolbarPrimitiveTop.Name = "rbToolbarPrimitiveTop";
            this.rbToolbarPrimitiveTop.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarPrimitiveTop.TabIndex = 7;
            this.rbToolbarPrimitiveTop.TabStop = true;
            this.rbToolbarPrimitiveTop.Text = "상단";
            this.rbToolbarPrimitiveTop.UseVisualStyleBackColor = true;
            //
            // ckToolbarPrimitive
            //
            this.ckToolbarPrimitive.AutoSize = true;
            this.ckToolbarPrimitive.Checked = true;
            this.ckToolbarPrimitive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckToolbarPrimitive.Location = new System.Drawing.Point(34, 31);
            this.ckToolbarPrimitive.Name = "ckToolbarPrimitive";
            this.ckToolbarPrimitive.Size = new System.Drawing.Size(60, 16);
            this.ckToolbarPrimitive.TabIndex = 6;
            this.ckToolbarPrimitive.Text = "보이기";
            this.ckToolbarPrimitive.UseVisualStyleBackColor = true;
            //
            // grpToolbarSelectionBox
            //
            this.grpToolbarSelectionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpToolbarSelectionBox.AutoSize = true;
            this.grpToolbarSelectionBox.Controls.Add(this.lblToolbarSelectionBoxRow);
            this.grpToolbarSelectionBox.Controls.Add(this.numToolbarSelectionBoxRow);
            this.grpToolbarSelectionBox.Controls.Add(this.lblToolbarSelectionBoxOrder);
            this.grpToolbarSelectionBox.Controls.Add(this.numToolbarSelectionBoxOrder);
            this.grpToolbarSelectionBox.Controls.Add(this.rbToolbarSelectionBoxRight);
            this.grpToolbarSelectionBox.Controls.Add(this.rbToolbarSelectionBoxLeft);
            this.grpToolbarSelectionBox.Controls.Add(this.rbToolbarSelectionBoxTop);
            this.grpToolbarSelectionBox.Controls.Add(this.ckToolbarSelectionBox);
            this.grpToolbarSelectionBox.Location = new System.Drawing.Point(6, 608);
            this.grpToolbarSelectionBox.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpToolbarSelectionBox.Name = "grpToolbarSelectionBox";
            this.grpToolbarSelectionBox.Size = new System.Drawing.Size(590, 69);
            this.grpToolbarSelectionBox.TabIndex = 12;
            this.grpToolbarSelectionBox.TabStop = false;
            this.grpToolbarSelectionBox.Text = "선택상자";
            //
            // lblToolbarSelectionBoxRow
            //
            this.lblToolbarSelectionBoxRow.AutoSize = true;
            this.lblToolbarSelectionBoxRow.Location = new System.Drawing.Point(400, 32);
            this.lblToolbarSelectionBoxRow.Name = "lblToolbarSelectionBoxRow";
            this.lblToolbarSelectionBoxRow.Size = new System.Drawing.Size(17, 12);
            this.lblToolbarSelectionBoxRow.TabIndex = 0;
            this.lblToolbarSelectionBoxRow.Text = "줄";
            //
            // numToolbarSelectionBoxRow
            //
            this.numToolbarSelectionBoxRow.Location = new System.Drawing.Point(420, 28);
            this.numToolbarSelectionBoxRow.Name = "numToolbarSelectionBoxRow";
            this.numToolbarSelectionBoxRow.Size = new System.Drawing.Size(46, 21);
            this.numToolbarSelectionBoxRow.TabIndex = 4;
            //
            // lblToolbarSelectionBoxOrder
            //
            this.lblToolbarSelectionBoxOrder.AutoSize = true;
            this.lblToolbarSelectionBoxOrder.Location = new System.Drawing.Point(475, 32);
            this.lblToolbarSelectionBoxOrder.Name = "lblToolbarSelectionBoxOrder";
            this.lblToolbarSelectionBoxOrder.Size = new System.Drawing.Size(29, 12);
            this.lblToolbarSelectionBoxOrder.TabIndex = 5;
            this.lblToolbarSelectionBoxOrder.Text = "순서";
            //
            // numToolbarSelectionBoxOrder
            //
            this.numToolbarSelectionBoxOrder.Location = new System.Drawing.Point(510, 28);
            this.numToolbarSelectionBoxOrder.Name = "numToolbarSelectionBoxOrder";
            this.numToolbarSelectionBoxOrder.Size = new System.Drawing.Size(46, 21);
            this.numToolbarSelectionBoxOrder.TabIndex = 5;
            //
            // rbToolbarSelectionBoxRight
            //
            this.rbToolbarSelectionBoxRight.AutoSize = true;
            this.rbToolbarSelectionBoxRight.Location = new System.Drawing.Point(296, 30);
            this.rbToolbarSelectionBoxRight.Name = "rbToolbarSelectionBoxRight";
            this.rbToolbarSelectionBoxRight.Size = new System.Drawing.Size(59, 16);
            this.rbToolbarSelectionBoxRight.TabIndex = 9;
            this.rbToolbarSelectionBoxRight.Text = "오른쪽";
            this.rbToolbarSelectionBoxRight.UseVisualStyleBackColor = true;
            //
            // rbToolbarSelectionBoxLeft
            //
            this.rbToolbarSelectionBoxLeft.AutoSize = true;
            this.rbToolbarSelectionBoxLeft.Location = new System.Drawing.Point(221, 30);
            this.rbToolbarSelectionBoxLeft.Name = "rbToolbarSelectionBoxLeft";
            this.rbToolbarSelectionBoxLeft.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarSelectionBoxLeft.TabIndex = 8;
            this.rbToolbarSelectionBoxLeft.Text = "왼쪽";
            this.rbToolbarSelectionBoxLeft.UseVisualStyleBackColor = true;
            //
            // rbToolbarSelectionBoxTop
            //
            this.rbToolbarSelectionBoxTop.AutoSize = true;
            this.rbToolbarSelectionBoxTop.Checked = true;
            this.rbToolbarSelectionBoxTop.Location = new System.Drawing.Point(145, 30);
            this.rbToolbarSelectionBoxTop.Name = "rbToolbarSelectionBoxTop";
            this.rbToolbarSelectionBoxTop.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarSelectionBoxTop.TabIndex = 7;
            this.rbToolbarSelectionBoxTop.TabStop = true;
            this.rbToolbarSelectionBoxTop.Text = "상단";
            this.rbToolbarSelectionBoxTop.UseVisualStyleBackColor = true;
            //
            // ckToolbarSelectionBox
            //
            this.ckToolbarSelectionBox.AutoSize = true;
            this.ckToolbarSelectionBox.Checked = true;
            this.ckToolbarSelectionBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckToolbarSelectionBox.Location = new System.Drawing.Point(34, 31);
            this.ckToolbarSelectionBox.Name = "ckToolbarSelectionBox";
            this.ckToolbarSelectionBox.Size = new System.Drawing.Size(60, 16);
            this.ckToolbarSelectionBox.TabIndex = 6;
            this.ckToolbarSelectionBox.Text = "보이기";
            this.ckToolbarSelectionBox.UseVisualStyleBackColor = true;
            //
            // grpToolbarZone
            //
            this.grpToolbarZone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpToolbarZone.AutoSize = true;
            this.grpToolbarZone.Controls.Add(this.lblToolbarZoneRow);
            this.grpToolbarZone.Controls.Add(this.numToolbarZoneRow);
            this.grpToolbarZone.Controls.Add(this.lblToolbarZoneOrder);
            this.grpToolbarZone.Controls.Add(this.numToolbarZoneOrder);
            this.grpToolbarZone.Controls.Add(this.rbToolbarZoneRight);
            this.grpToolbarZone.Controls.Add(this.rbToolbarZoneLeft);
            this.grpToolbarZone.Controls.Add(this.rbToolbarZoneTop);
            this.grpToolbarZone.Controls.Add(this.ckToolbarZone);
            this.grpToolbarZone.Location = new System.Drawing.Point(6, 683);
            this.grpToolbarZone.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpToolbarZone.Name = "grpToolbarZone";
            this.grpToolbarZone.Size = new System.Drawing.Size(590, 69);
            this.grpToolbarZone.TabIndex = 13;
            this.grpToolbarZone.TabStop = false;
            this.grpToolbarZone.Text = "다면체 공간";
            //
            // lblToolbarZoneRow
            //
            this.lblToolbarZoneRow.AutoSize = true;
            this.lblToolbarZoneRow.Location = new System.Drawing.Point(400, 32);
            this.lblToolbarZoneRow.Name = "lblToolbarZoneRow";
            this.lblToolbarZoneRow.Size = new System.Drawing.Size(17, 12);
            this.lblToolbarZoneRow.TabIndex = 0;
            this.lblToolbarZoneRow.Text = "줄";
            //
            // numToolbarZoneRow
            //
            this.numToolbarZoneRow.Location = new System.Drawing.Point(420, 28);
            this.numToolbarZoneRow.Name = "numToolbarZoneRow";
            this.numToolbarZoneRow.Size = new System.Drawing.Size(46, 21);
            this.numToolbarZoneRow.TabIndex = 4;
            //
            // lblToolbarZoneOrder
            //
            this.lblToolbarZoneOrder.AutoSize = true;
            this.lblToolbarZoneOrder.Location = new System.Drawing.Point(475, 32);
            this.lblToolbarZoneOrder.Name = "lblToolbarZoneOrder";
            this.lblToolbarZoneOrder.Size = new System.Drawing.Size(29, 12);
            this.lblToolbarZoneOrder.TabIndex = 5;
            this.lblToolbarZoneOrder.Text = "순서";
            //
            // numToolbarZoneOrder
            //
            this.numToolbarZoneOrder.Location = new System.Drawing.Point(510, 28);
            this.numToolbarZoneOrder.Name = "numToolbarZoneOrder";
            this.numToolbarZoneOrder.Size = new System.Drawing.Size(46, 21);
            this.numToolbarZoneOrder.TabIndex = 5;
            //
            // rbToolbarZoneRight
            //
            this.rbToolbarZoneRight.AutoSize = true;
            this.rbToolbarZoneRight.Location = new System.Drawing.Point(296, 30);
            this.rbToolbarZoneRight.Name = "rbToolbarZoneRight";
            this.rbToolbarZoneRight.Size = new System.Drawing.Size(59, 16);
            this.rbToolbarZoneRight.TabIndex = 9;
            this.rbToolbarZoneRight.Text = "오른쪽";
            this.rbToolbarZoneRight.UseVisualStyleBackColor = true;
            //
            // rbToolbarZoneLeft
            //
            this.rbToolbarZoneLeft.AutoSize = true;
            this.rbToolbarZoneLeft.Location = new System.Drawing.Point(221, 30);
            this.rbToolbarZoneLeft.Name = "rbToolbarZoneLeft";
            this.rbToolbarZoneLeft.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarZoneLeft.TabIndex = 8;
            this.rbToolbarZoneLeft.Text = "왼쪽";
            this.rbToolbarZoneLeft.UseVisualStyleBackColor = true;
            //
            // rbToolbarZoneTop
            //
            this.rbToolbarZoneTop.AutoSize = true;
            this.rbToolbarZoneTop.Checked = true;
            this.rbToolbarZoneTop.Location = new System.Drawing.Point(145, 30);
            this.rbToolbarZoneTop.Name = "rbToolbarZoneTop";
            this.rbToolbarZoneTop.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarZoneTop.TabIndex = 7;
            this.rbToolbarZoneTop.TabStop = true;
            this.rbToolbarZoneTop.Text = "상단";
            this.rbToolbarZoneTop.UseVisualStyleBackColor = true;
            //
            // ckToolbarZone
            //
            this.ckToolbarZone.AutoSize = true;
            this.ckToolbarZone.Location = new System.Drawing.Point(34, 31);
            this.ckToolbarZone.Name = "ckToolbarZone";
            this.ckToolbarZone.Size = new System.Drawing.Size(60, 16);
            this.ckToolbarZone.TabIndex = 6;
            this.ckToolbarZone.Text = "보이기";
            this.ckToolbarZone.UseVisualStyleBackColor = true;
            //
            // grpToolbarEffect
            //
            this.grpToolbarEffect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpToolbarEffect.AutoSize = true;
            this.grpToolbarEffect.Controls.Add(this.lblToolbarEffectRow);
            this.grpToolbarEffect.Controls.Add(this.numToolbarEffectRow);
            this.grpToolbarEffect.Controls.Add(this.lblToolbarEffectOrder);
            this.grpToolbarEffect.Controls.Add(this.numToolbarEffectOrder);
            this.grpToolbarEffect.Controls.Add(this.rbToolbarEffectRight);
            this.grpToolbarEffect.Controls.Add(this.rbToolbarEffectLeft);
            this.grpToolbarEffect.Controls.Add(this.rbToolbarEffectTop);
            this.grpToolbarEffect.Controls.Add(this.ckToolbarEffect);
            this.grpToolbarEffect.Location = new System.Drawing.Point(6, 758);
            this.grpToolbarEffect.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpToolbarEffect.Name = "grpToolbarEffect";
            this.grpToolbarEffect.Size = new System.Drawing.Size(590, 69);
            this.grpToolbarEffect.TabIndex = 14;
            this.grpToolbarEffect.TabStop = false;
            this.grpToolbarEffect.Text = "특수 효과";
            //
            // lblToolbarEffectRow
            //
            this.lblToolbarEffectRow.AutoSize = true;
            this.lblToolbarEffectRow.Location = new System.Drawing.Point(400, 32);
            this.lblToolbarEffectRow.Name = "lblToolbarEffectRow";
            this.lblToolbarEffectRow.Size = new System.Drawing.Size(17, 12);
            this.lblToolbarEffectRow.TabIndex = 0;
            this.lblToolbarEffectRow.Text = "줄";
            //
            // numToolbarEffectRow
            //
            this.numToolbarEffectRow.Location = new System.Drawing.Point(420, 28);
            this.numToolbarEffectRow.Name = "numToolbarEffectRow";
            this.numToolbarEffectRow.Size = new System.Drawing.Size(46, 21);
            this.numToolbarEffectRow.TabIndex = 4;
            //
            // lblToolbarEffectOrder
            //
            this.lblToolbarEffectOrder.AutoSize = true;
            this.lblToolbarEffectOrder.Location = new System.Drawing.Point(475, 32);
            this.lblToolbarEffectOrder.Name = "lblToolbarEffectOrder";
            this.lblToolbarEffectOrder.Size = new System.Drawing.Size(29, 12);
            this.lblToolbarEffectOrder.TabIndex = 5;
            this.lblToolbarEffectOrder.Text = "순서";
            //
            // numToolbarEffectOrder
            //
            this.numToolbarEffectOrder.Location = new System.Drawing.Point(510, 28);
            this.numToolbarEffectOrder.Name = "numToolbarEffectOrder";
            this.numToolbarEffectOrder.Size = new System.Drawing.Size(46, 21);
            this.numToolbarEffectOrder.TabIndex = 5;
            //
            // rbToolbarEffectRight
            //
            this.rbToolbarEffectRight.AutoSize = true;
            this.rbToolbarEffectRight.Location = new System.Drawing.Point(296, 30);
            this.rbToolbarEffectRight.Name = "rbToolbarEffectRight";
            this.rbToolbarEffectRight.Size = new System.Drawing.Size(59, 16);
            this.rbToolbarEffectRight.TabIndex = 9;
            this.rbToolbarEffectRight.Text = "오른쪽";
            this.rbToolbarEffectRight.UseVisualStyleBackColor = true;
            //
            // rbToolbarEffectLeft
            //
            this.rbToolbarEffectLeft.AutoSize = true;
            this.rbToolbarEffectLeft.Location = new System.Drawing.Point(221, 30);
            this.rbToolbarEffectLeft.Name = "rbToolbarEffectLeft";
            this.rbToolbarEffectLeft.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarEffectLeft.TabIndex = 8;
            this.rbToolbarEffectLeft.Text = "왼쪽";
            this.rbToolbarEffectLeft.UseVisualStyleBackColor = true;
            //
            // rbToolbarEffectTop
            //
            this.rbToolbarEffectTop.AutoSize = true;
            this.rbToolbarEffectTop.Checked = true;
            this.rbToolbarEffectTop.Location = new System.Drawing.Point(145, 30);
            this.rbToolbarEffectTop.Name = "rbToolbarEffectTop";
            this.rbToolbarEffectTop.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarEffectTop.TabIndex = 7;
            this.rbToolbarEffectTop.TabStop = true;
            this.rbToolbarEffectTop.Text = "상단";
            this.rbToolbarEffectTop.UseVisualStyleBackColor = true;
            //
            // ckToolbarEffect
            //
            this.ckToolbarEffect.AutoSize = true;
            this.ckToolbarEffect.Location = new System.Drawing.Point(34, 31);
            this.ckToolbarEffect.Name = "ckToolbarEffect";
            this.ckToolbarEffect.Size = new System.Drawing.Size(60, 16);
            this.ckToolbarEffect.TabIndex = 6;
            this.ckToolbarEffect.Text = "보이기";
            this.ckToolbarEffect.UseVisualStyleBackColor = true;
            //
            // grpToolbarObserver
            //
            this.grpToolbarObserver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpToolbarObserver.AutoSize = true;
            this.grpToolbarObserver.Controls.Add(this.lblToolbarObserverRow);
            this.grpToolbarObserver.Controls.Add(this.numToolbarObserverRow);
            this.grpToolbarObserver.Controls.Add(this.lblToolbarObserverOrder);
            this.grpToolbarObserver.Controls.Add(this.numToolbarObserverOrder);
            this.grpToolbarObserver.Controls.Add(this.rbToolbarObserverRight);
            this.grpToolbarObserver.Controls.Add(this.rbToolbarObserverLeft);
            this.grpToolbarObserver.Controls.Add(this.rbToolbarObserverTop);
            this.grpToolbarObserver.Controls.Add(this.ckToolbarObserver);
            this.grpToolbarObserver.Location = new System.Drawing.Point(6, 833);
            this.grpToolbarObserver.MinimumSize = new System.Drawing.Size(590, 0);
            this.grpToolbarObserver.Name = "grpToolbarObserver";
            this.grpToolbarObserver.Size = new System.Drawing.Size(590, 69);
            this.grpToolbarObserver.TabIndex = 15;
            this.grpToolbarObserver.TabStop = false;
            this.grpToolbarObserver.Text = "옵저버";
            //
            // lblToolbarObserverRow
            //
            this.lblToolbarObserverRow.AutoSize = true;
            this.lblToolbarObserverRow.Location = new System.Drawing.Point(400, 32);
            this.lblToolbarObserverRow.Name = "lblToolbarObserverRow";
            this.lblToolbarObserverRow.Size = new System.Drawing.Size(17, 12);
            this.lblToolbarObserverRow.TabIndex = 0;
            this.lblToolbarObserverRow.Text = "줄";
            //
            // numToolbarObserverRow
            //
            this.numToolbarObserverRow.Location = new System.Drawing.Point(420, 28);
            this.numToolbarObserverRow.Name = "numToolbarObserverRow";
            this.numToolbarObserverRow.Size = new System.Drawing.Size(46, 21);
            this.numToolbarObserverRow.TabIndex = 4;
            //
            // lblToolbarObserverOrder
            //
            this.lblToolbarObserverOrder.AutoSize = true;
            this.lblToolbarObserverOrder.Location = new System.Drawing.Point(475, 32);
            this.lblToolbarObserverOrder.Name = "lblToolbarObserverOrder";
            this.lblToolbarObserverOrder.Size = new System.Drawing.Size(29, 12);
            this.lblToolbarObserverOrder.TabIndex = 5;
            this.lblToolbarObserverOrder.Text = "순서";
            //
            // numToolbarObserverOrder
            //
            this.numToolbarObserverOrder.Location = new System.Drawing.Point(510, 28);
            this.numToolbarObserverOrder.Name = "numToolbarObserverOrder";
            this.numToolbarObserverOrder.Size = new System.Drawing.Size(46, 21);
            this.numToolbarObserverOrder.TabIndex = 5;
            //
            // rbToolbarObserverRight
            //
            this.rbToolbarObserverRight.AutoSize = true;
            this.rbToolbarObserverRight.Location = new System.Drawing.Point(296, 30);
            this.rbToolbarObserverRight.Name = "rbToolbarObserverRight";
            this.rbToolbarObserverRight.Size = new System.Drawing.Size(59, 16);
            this.rbToolbarObserverRight.TabIndex = 9;
            this.rbToolbarObserverRight.Text = "오른쪽";
            this.rbToolbarObserverRight.UseVisualStyleBackColor = true;
            //
            // rbToolbarObserverLeft
            //
            this.rbToolbarObserverLeft.AutoSize = true;
            this.rbToolbarObserverLeft.Location = new System.Drawing.Point(221, 30);
            this.rbToolbarObserverLeft.Name = "rbToolbarObserverLeft";
            this.rbToolbarObserverLeft.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarObserverLeft.TabIndex = 8;
            this.rbToolbarObserverLeft.Text = "왼쪽";
            this.rbToolbarObserverLeft.UseVisualStyleBackColor = true;
            //
            // rbToolbarObserverTop
            //
            this.rbToolbarObserverTop.AutoSize = true;
            this.rbToolbarObserverTop.Checked = true;
            this.rbToolbarObserverTop.Location = new System.Drawing.Point(145, 30);
            this.rbToolbarObserverTop.Name = "rbToolbarObserverTop";
            this.rbToolbarObserverTop.Size = new System.Drawing.Size(47, 16);
            this.rbToolbarObserverTop.TabIndex = 7;
            this.rbToolbarObserverTop.TabStop = true;
            this.rbToolbarObserverTop.Text = "상단";
            this.rbToolbarObserverTop.UseVisualStyleBackColor = true;
            //
            // ckToolbarObserver
            //
            this.ckToolbarObserver.AutoSize = true;
            this.ckToolbarObserver.Location = new System.Drawing.Point(34, 31);
            this.ckToolbarObserver.Name = "ckToolbarObserver";
            this.ckToolbarObserver.Size = new System.Drawing.Size(60, 16);
            this.ckToolbarObserver.TabIndex = 6;
            this.ckToolbarObserver.Text = "보이기";
            this.ckToolbarObserver.UseVisualStyleBackColor = true;
            //
            // grpApply
            //
            this.grpApply.Controls.Add(this.btnRead);
            this.grpApply.Controls.Add(this.btnApply);
            this.grpApply.Controls.Add(this.btnDefault);
            this.grpApply.Controls.Add(this.btnSave);
            this.grpApply.Controls.Add(this.btnLoad);
            this.grpApply.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpApply.Location = new System.Drawing.Point(0, 716);
            this.grpApply.Name = "grpApply";
            this.grpApply.Size = new System.Drawing.Size(676, 62);
            this.grpApply.TabIndex = 1;
            this.grpApply.TabStop = false;
            this.grpApply.Text = "3. 적용";
            //
            // btnRead
            //
            this.btnRead.Location = new System.Drawing.Point(8, 22);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(126, 28);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "현재 값 읽기";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            //
            // btnApply
            //
            this.btnApply.Location = new System.Drawing.Point(140, 22);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(126, 28);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            //
            // btnDefault
            //
            this.btnDefault.Location = new System.Drawing.Point(272, 22);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(126, 28);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "기본값";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(404, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "파일로 저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnLoad
            //
            this.btnLoad.Location = new System.Drawing.Point(536, 22);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(126, 28);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "파일에서 불러오기";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            //
            // lblStatus
            //
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(0, 778);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(676, 22);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // grpModel
            //
            this.grpModel.Controls.Add(this.btnOpenModel);
            this.grpModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpModel.Location = new System.Drawing.Point(0, 0);
            this.grpModel.Name = "grpModel";
            this.grpModel.Size = new System.Drawing.Size(676, 58);
            this.grpModel.TabIndex = 3;
            this.grpModel.TabStop = false;
            this.grpModel.Text = "1. 모델";
            //
            // btnOpenModel
            //
            this.btnOpenModel.Location = new System.Drawing.Point(8, 22);
            this.btnOpenModel.Name = "btnOpenModel";
            this.btnOpenModel.Size = new System.Drawing.Size(120, 28);
            this.btnOpenModel.TabIndex = 0;
            this.btnOpenModel.Text = "모델 열기";
            this.btnOpenModel.UseVisualStyleBackColor = true;
            this.btnOpenModel.Click += new System.EventHandler(this.btnOpenModel_Click);
            //
            // FrmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZCore3DX.NET.Settings";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.tpHome.ResumeLayout(false);
            this.grpHomeModel.ResumeLayout(false);
            this.grpHomeModel.PerformLayout();
            this.grpHomeView.ResumeLayout(false);
            this.grpHomeView.PerformLayout();
            this.grpHomeCamera.ResumeLayout(false);
            this.grpHomeCamera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraInitialFov)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraBoundingBoxMaxZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraBoundingBoxMaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraBoundingBoxMaxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraBoundingBoxMinZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraBoundingBoxMinY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCameraBoundingBoxMinX)).EndInit();
            this.grpHomeSelection.ResumeLayout(false);
            this.grpHomeSelection.PerformLayout();
            this.grpHomeBackground.ResumeLayout(false);
            this.grpHomeBackground.PerformLayout();
            this.grpHomeSnap.ResumeLayout(false);
            this.grpHomeSnap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSnapCylinderAxisSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSnapPointSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSnapPlaneSize)).EndInit();
            this.grpSpaceSelectionBox.ResumeLayout(false);
            this.grpSpaceSelectionBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectionBoxStrokeThickness)).EndInit();
            this.grpSpaceZone.ResumeLayout(false);
            this.grpSpaceZone.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZoneFaceOpacity)).EndInit();
            this.tpView.ResumeLayout(false);
            this.grpViewView.ResumeLayout(false);
            this.grpViewView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRenderScale)).EndInit();
            this.grpViewZoom.ResumeLayout(false);
            this.grpViewZoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZoomRatio)).EndInit();
            this.grpViewCube.ResumeLayout(false);
            this.grpViewCube.PerformLayout();
            this.grpViewCubeFace.ResumeLayout(false);
            this.grpViewCubeFace.PerformLayout();
            this.grpViewCommand.ResumeLayout(false);
            this.grpViewCommand.PerformLayout();
            this.grpViewLight.ResumeLayout(false);
            this.grpViewLight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numShininess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecularIntensity)).EndInit();
            this.grpViewZoomBox.ResumeLayout(false);
            this.grpViewZoomBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZoomBoxStrokeThickness)).EndInit();
            this.tpInput.ResumeLayout(false);
            this.grpWindowModelingControl.ResumeLayout(false);
            this.grpWindowModelingControl.PerformLayout();
            this.grpMcSize.ResumeLayout(false);
            this.grpMcSize.PerformLayout();
            this.grpMcPosition.ResumeLayout(false);
            this.grpMcPosition.PerformLayout();
            this.grpMcColor.ResumeLayout(false);
            this.grpMcColor.PerformLayout();
            this.grpMcBackground.ResumeLayout(false);
            this.grpMcBackground.PerformLayout();
            this.grpMcBackgroundColor.ResumeLayout(false);
            this.grpMcBackgroundColor.PerformLayout();
            this.grpMcOrientation.ResumeLayout(false);
            this.grpMcOrientation.PerformLayout();
            this.grpInputSensitivity.ResumeLayout(false);
            this.grpInputSensitivity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInputOrbitSens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputPanSens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputZoomSens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputRollSens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputLookSens)).EndInit();
            this.grpInputSpeed.ResumeLayout(false);
            this.grpInputSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInputWalkSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputWalkBoost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputFlySpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputFlyBoost)).EndInit();
            this.grpInputClick.ResumeLayout(false);
            this.grpInputClick.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInputClickDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputLongPress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInputClickTolerance)).EndInit();
            this.tpNote.ResumeLayout(false);
            this.grpNoteStyle.ResumeLayout(false);
            this.grpNoteStyle.PerformLayout();
            this.grpNoteSymbol.ResumeLayout(false);
            this.grpNoteSymbol.PerformLayout();
            this.tpMeasure.ResumeLayout(false);
            this.grpMeasureOption.ResumeLayout(false);
            this.grpMeasureOption.PerformLayout();
            this.grpMeasureStyle.ResumeLayout(false);
            this.grpMeasureStyle.PerformLayout();
            this.grpMeasureSnap.ResumeLayout(false);
            this.grpMeasureSnap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMeasureSnapCylinderAxisSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeasureSnapPointSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeasureSnapPlaneSize)).EndInit();
            this.tpSection.ResumeLayout(false);
            this.grpSectionStyle.ResumeLayout(false);
            this.grpSectionStyle.PerformLayout();
            this.grpSectionCap.ResumeLayout(false);
            this.grpSectionCap.PerformLayout();
            this.tpDecal.ResumeLayout(false);
            this.tpSpace.ResumeLayout(false);
            this.grpDecal.ResumeLayout(false);
            this.grpDecal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDecalRotationAngleStep)).EndInit();
            this.tpFrame.ResumeLayout(false);
            this.grpFrameView.ResumeLayout(false);
            this.grpFrameView.PerformLayout();
            this.grpFrameColor.ResumeLayout(false);
            this.grpFrameColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameLineThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFramePlaneThickness)).EndInit();
            this.tpPreSelect.ResumeLayout(false);
            this.grpPreSelect.ResumeLayout(false);
            this.grpPreSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPreSelectDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreSelectLimit)).EndInit();
            this.tpWindow.ResumeLayout(false);
            this.grpWindowModelTree.ResumeLayout(false);
            this.grpWindowModelTree.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numModelTreePanelWidth)).EndInit();
            this.grpWindowAttribute.ResumeLayout(false);
            this.grpWindowAttribute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAttributePanelWidth)).EndInit();
            this.grpWindowSplit.ResumeLayout(false);
            this.grpWindowSplit.PerformLayout();
            this.tpObserver.ResumeLayout(false);
            this.grpObserverFigure.ResumeLayout(false);
            this.grpObserverFigure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numObserverFigureSize)).EndInit();
            this.grpObserverResultColor.ResumeLayout(false);
            this.grpObserverResultColor.PerformLayout();
            this.grpObserverView.ResumeLayout(false);
            this.grpObserverView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numObserverAngularStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numObserverMaxDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numObserverEyeHeight)).EndInit();
            this.tpDevTools.ResumeLayout(false);
            this.grpDevInfo.ResumeLayout(false);
            this.grpDevInfo.PerformLayout();
            this.grpDevCache.ResumeLayout(false);
            this.grpDevCache.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTemporaryCacheSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPermanentCacheSize)).EndInit();
            this.grpDevRendering.ResumeLayout(false);
            this.grpDevRendering.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRenderingLimitPerStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRenderingLimitInControl)).EndInit();
            this.tpToolbar.ResumeLayout(false);
            this.tpToolbar.PerformLayout();
            this.grpToolbarRibbon.ResumeLayout(false);
            this.grpToolbarRibbon.PerformLayout();
            this.grpToolbarHome.ResumeLayout(false);
            this.grpToolbarHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarHomeRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarHomeOrder)).EndInit();
            this.grpToolbarNote.ResumeLayout(false);
            this.grpToolbarNote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarNoteRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarNoteOrder)).EndInit();
            this.grpToolbarMeasure.ResumeLayout(false);
            this.grpToolbarMeasure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarMeasureRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarMeasureOrder)).EndInit();
            this.grpToolbarSection.ResumeLayout(false);
            this.grpToolbarSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarSectionRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarSectionOrder)).EndInit();
            this.grpToolbarSnapshot.ResumeLayout(false);
            this.grpToolbarSnapshot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarSnapshotRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarSnapshotOrder)).EndInit();
            this.grpToolbarDecal.ResumeLayout(false);
            this.grpToolbarDecal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarDecalRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarDecalOrder)).EndInit();
            this.grpToolbarPrimitive.ResumeLayout(false);
            this.grpToolbarPrimitive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarPrimitiveRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarPrimitiveOrder)).EndInit();
            this.grpToolbarSelectionBox.ResumeLayout(false);
            this.grpToolbarSelectionBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarSelectionBoxRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarSelectionBoxOrder)).EndInit();
            this.grpToolbarZone.ResumeLayout(false);
            this.grpToolbarZone.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarZoneRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarZoneOrder)).EndInit();
            this.grpToolbarEffect.ResumeLayout(false);
            this.grpToolbarEffect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarEffectRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarEffectOrder)).EndInit();
            this.grpToolbarObserver.ResumeLayout(false);
            this.grpToolbarObserver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarObserverRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToolbarObserverOrder)).EndInit();
            this.grpApply.ResumeLayout(false);
            this.grpModel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tpHome;
        private System.Windows.Forms.TabPage tpView;
        private System.Windows.Forms.TabPage tpInput;
        private System.Windows.Forms.TabPage tpNote;
        private System.Windows.Forms.TabPage tpMeasure;
        private System.Windows.Forms.TabPage tpSection;
        private System.Windows.Forms.TabPage tpDecal;
        private System.Windows.Forms.TabPage tpSpace;
        private System.Windows.Forms.TabPage tpFrame;
        private System.Windows.Forms.TabPage tpObserver;
        private System.Windows.Forms.TabPage tpPreSelect;
        private System.Windows.Forms.TabPage tpToolbar;
        private System.Windows.Forms.TabPage tpWindow;
        private System.Windows.Forms.TabPage tpDevTools;
        private System.Windows.Forms.GroupBox grpHomeModel;
        private System.Windows.Forms.CheckBox ckEnableFace;
        private System.Windows.Forms.CheckBox ckEnableBody;
        private System.Windows.Forms.CheckBox ckEnableNodeLock;
        private System.Windows.Forms.GroupBox grpHomeView;
        private System.Windows.Forms.ComboBox cbCameraMode;
        private System.Windows.Forms.Label lblCameraMode;
        private System.Windows.Forms.ComboBox cbProjection;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox ckEnableSsao;
        private System.Windows.Forms.CheckBox ckEnableShadow;
        private System.Windows.Forms.CheckBox ckEnableEdge;
        private System.Windows.Forms.Label lblEdgeColor;
        private System.Windows.Forms.Button btnEdgeColor;
        private System.Windows.Forms.GroupBox grpHomeCamera;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numCameraInitialFov;
        private System.Windows.Forms.NumericUpDown numCameraBoundingBoxMaxZ;
        private System.Windows.Forms.NumericUpDown numCameraBoundingBoxMaxY;
        private System.Windows.Forms.NumericUpDown numCameraBoundingBoxMaxX;
        private System.Windows.Forms.NumericUpDown numCameraBoundingBoxMinZ;
        private System.Windows.Forms.NumericUpDown numCameraBoundingBoxMinY;
        private System.Windows.Forms.NumericUpDown numCameraBoundingBoxMinX;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox ckInitialCamera;
        private System.Windows.Forms.GroupBox grpHomeSelection;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.ComboBox cbSelectionObject3DType;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.CheckBox ckSelectionOutline;
        private System.Windows.Forms.Button btnSelectionOutlineColor;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox comboXRaySelectionColor;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox ckBoxSelectionFrontObjectOnly;
        private System.Windows.Forms.Button btnSelectionBoxStrokeColor;
        private System.Windows.Forms.Button btnSelectionBoxFillColor;
        private System.Windows.Forms.Button btnSelectionColor;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox grpHomeBackground;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGradientVectorY;
        private System.Windows.Forms.TextBox txtGradientVectorX;
        private System.Windows.Forms.TextBox txtGradientPosition3;
        private System.Windows.Forms.TextBox txtGradientPosition2;
        private System.Windows.Forms.TextBox txtGradientPosition1;
        private System.Windows.Forms.ComboBox cbBackgroundColorCount;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label labelGradientVector;
        private System.Windows.Forms.ComboBox cbBackgroundMode;
        private System.Windows.Forms.Label labelBackgroundMode;
        private System.Windows.Forms.Button btnBackgroundColor3;
        private System.Windows.Forms.Button btnBackgroundColor2;
        private System.Windows.Forms.Button btnBackgroundColor1;
        private System.Windows.Forms.Label labelBackgroundColor;
        private System.Windows.Forms.GroupBox grpHomeSnap;
        private System.Windows.Forms.Button btnSnapHighlightColor;
        private System.Windows.Forms.Button btnSnapColor;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.NumericUpDown numSnapCylinderAxisSize;
        private System.Windows.Forms.NumericUpDown numSnapPointSize;
        private System.Windows.Forms.NumericUpDown numSnapPlaneSize;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.GroupBox grpSpaceSelectionBox;
        private System.Windows.Forms.ComboBox cbSelectionBoxStrokePattern;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.ComboBox cbSelectionBoxTextSize;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.Button btnSelectionBoxTextColor;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.NumericUpDown numSelectionBoxStrokeThickness;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.Button btnSelectionBoxHighlightedStrokeColor;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Button btnSelectionBoxDefaultStrokeColor;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Button btnSelectionBoxSelectedStrokeColor;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Button btnSelectionBoxSelectedFillColor;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Button btnSelectionBoxHighlightedFillColor;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Button btnSelectionBoxDefaultFillColor;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.GroupBox grpSpaceZone;
        private System.Windows.Forms.NumericUpDown numZoneFaceOpacity;
        private System.Windows.Forms.Label lblZoneFaceOpacity;
        private System.Windows.Forms.Button btnZoneLineColor;
        private System.Windows.Forms.Label lblZoneLineColor;
        private System.Windows.Forms.Button btnZoneFaceColor;
        private System.Windows.Forms.Label lblZoneFaceColor;
        private System.Windows.Forms.GroupBox grpViewView;
        private System.Windows.Forms.CheckBox ckEnableAnimation;
        private System.Windows.Forms.CheckBox ckEnableAutoFit;
        private System.Windows.Forms.Label lblRenderScaleRange;
        private System.Windows.Forms.NumericUpDown numRenderScale;
        private System.Windows.Forms.Label lblRenderScale;
        private System.Windows.Forms.CheckBox ckViewToolbarEnable;
        private System.Windows.Forms.Label lblFallbackFontFamilies;
        private System.Windows.Forms.ComboBox cbFallbackFontFamilies;
        private System.Windows.Forms.GroupBox grpViewZoom;
        private System.Windows.Forms.NumericUpDown numZoomRatio;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.GroupBox grpViewCube;
        private System.Windows.Forms.CheckBox ckViewCubeEnable;
        private System.Windows.Forms.ComboBox cbViewCubeFontSize;
        private System.Windows.Forms.Button btnViewCubeFontColor;
        private System.Windows.Forms.Button btnViewCubeHighlightedStrokeColor;
        private System.Windows.Forms.Button btnViewCubeHighlightedFillColor;
        private System.Windows.Forms.Button btnViewCubeStrokeColor;
        private System.Windows.Forms.Button btnViewCubeFillColor;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.GroupBox grpViewCubeFace;
        private System.Windows.Forms.Label lblViewCubeTop;
        private System.Windows.Forms.TextBox txtViewCubeTop;
        private System.Windows.Forms.Label lblViewCubeBottom;
        private System.Windows.Forms.TextBox txtViewCubeBottom;
        private System.Windows.Forms.Label lblViewCubeLeft;
        private System.Windows.Forms.TextBox txtViewCubeLeft;
        private System.Windows.Forms.Label lblViewCubeRight;
        private System.Windows.Forms.TextBox txtViewCubeRight;
        private System.Windows.Forms.Label lblViewCubeFront;
        private System.Windows.Forms.TextBox txtViewCubeFront;
        private System.Windows.Forms.Label lblViewCubeBack;
        private System.Windows.Forms.TextBox txtViewCubeBack;
        private System.Windows.Forms.GroupBox grpViewCommand;
        private System.Windows.Forms.Button btnCommandMessageTextColor;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.GroupBox grpViewLight;
        private System.Windows.Forms.CheckBox ckEnvironmentLight;
        private System.Windows.Forms.Label lblLightDir;
        private System.Windows.Forms.Label lblDirX;
        private System.Windows.Forms.TextBox txtLightDirX;
        private System.Windows.Forms.Label lblDirY;
        private System.Windows.Forms.TextBox txtLightDirY;
        private System.Windows.Forms.Label lblDirZ;
        private System.Windows.Forms.TextBox txtLightDirZ;
        private System.Windows.Forms.Label lblAmbientColor;
        private System.Windows.Forms.Button btnAmbientColor;
        private System.Windows.Forms.Label lblLightColor;
        private System.Windows.Forms.Button btnLightColor;
        private System.Windows.Forms.Label lblShininess;
        private System.Windows.Forms.NumericUpDown numShininess;
        private System.Windows.Forms.Label lblShininessRange;
        private System.Windows.Forms.Label lblSpecularIntensity;
        private System.Windows.Forms.NumericUpDown numSpecularIntensity;
        private System.Windows.Forms.Label lblSpecularRange;
        private System.Windows.Forms.GroupBox grpViewZoomBox;
        private System.Windows.Forms.Label lblZoomBoxFillColor;
        private System.Windows.Forms.Button btnZoomBoxFillColor;
        private System.Windows.Forms.Label lblZoomBoxStrokeColor;
        private System.Windows.Forms.Button btnZoomBoxStrokeColor;
        private System.Windows.Forms.Label lblZoomBoxStrokePattern;
        private System.Windows.Forms.ComboBox cbZoomBoxStrokePattern;
        private System.Windows.Forms.Label lblZoomBoxStrokeThickness;
        private System.Windows.Forms.NumericUpDown numZoomBoxStrokeThickness;
        private System.Windows.Forms.GroupBox grpWindowModelingControl;
        private System.Windows.Forms.CheckBox ckModelingControl;
        private System.Windows.Forms.GroupBox grpMcSize;
        private System.Windows.Forms.RadioButton rbMcSizeSmall;
        private System.Windows.Forms.RadioButton rbMcSizeMedium;
        private System.Windows.Forms.RadioButton rbMcSizeLarge;
        private System.Windows.Forms.GroupBox grpMcPosition;
        private System.Windows.Forms.RadioButton rbMcPosTL;
        private System.Windows.Forms.RadioButton rbMcPosTC;
        private System.Windows.Forms.RadioButton rbMcPosTR;
        private System.Windows.Forms.RadioButton rbMcPosBL;
        private System.Windows.Forms.RadioButton rbMcPosBC;
        private System.Windows.Forms.RadioButton rbMcPosBR;
        private System.Windows.Forms.RadioButton rbMcPosLS;
        private System.Windows.Forms.RadioButton rbMcPosRS;
        private System.Windows.Forms.GroupBox grpMcColor;
        private System.Windows.Forms.RadioButton rbMcColorBlack;
        private System.Windows.Forms.RadioButton rbMcColorGray;
        private System.Windows.Forms.RadioButton rbMcColorWhite;
        private System.Windows.Forms.GroupBox grpMcBackground;
        private System.Windows.Forms.RadioButton rbMcBgTransparent;
        private System.Windows.Forms.RadioButton rbMcBgSemi;
        private System.Windows.Forms.RadioButton rbMcBgColored;
        private System.Windows.Forms.GroupBox grpMcBackgroundColor;
        private System.Windows.Forms.RadioButton rbMcBgColorBlack;
        private System.Windows.Forms.RadioButton rbMcBgColorGray;
        private System.Windows.Forms.RadioButton rbMcBgColorWhite;
        private System.Windows.Forms.GroupBox grpMcOrientation;
        private System.Windows.Forms.RadioButton rbMcOrientH;
        private System.Windows.Forms.RadioButton rbMcOrientV;
        private System.Windows.Forms.GroupBox grpInputSensitivity;
        private System.Windows.Forms.Label lblInputOrbitSens;
        private System.Windows.Forms.NumericUpDown numInputOrbitSens;
        private System.Windows.Forms.Label lblInputPanSens;
        private System.Windows.Forms.NumericUpDown numInputPanSens;
        private System.Windows.Forms.Label lblInputZoomSens;
        private System.Windows.Forms.NumericUpDown numInputZoomSens;
        private System.Windows.Forms.Label lblInputRollSens;
        private System.Windows.Forms.NumericUpDown numInputRollSens;
        private System.Windows.Forms.Label lblInputLookSens;
        private System.Windows.Forms.NumericUpDown numInputLookSens;
        private System.Windows.Forms.GroupBox grpInputSpeed;
        private System.Windows.Forms.Label lblInputWalkSpeed;
        private System.Windows.Forms.NumericUpDown numInputWalkSpeed;
        private System.Windows.Forms.Label lblInputWalkBoost;
        private System.Windows.Forms.NumericUpDown numInputWalkBoost;
        private System.Windows.Forms.Label lblInputFlySpeed;
        private System.Windows.Forms.NumericUpDown numInputFlySpeed;
        private System.Windows.Forms.Label lblInputFlyBoost;
        private System.Windows.Forms.NumericUpDown numInputFlyBoost;
        private System.Windows.Forms.GroupBox grpInputClick;
        private System.Windows.Forms.CheckBox ckInputWheelInvert;
        private System.Windows.Forms.Label lblInputClickDuration;
        private System.Windows.Forms.NumericUpDown numInputClickDuration;
        private System.Windows.Forms.Label lblInputLongPress;
        private System.Windows.Forms.NumericUpDown numInputLongPress;
        private System.Windows.Forms.Label lblInputClickTolerance;
        private System.Windows.Forms.NumericUpDown numInputClickTolerance;
        private System.Windows.Forms.GroupBox grpNoteStyle;
        private System.Windows.Forms.ComboBox cbNoteTextHorizontalAlignment;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.ComboBox cbNoteLineStrokePattern;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox txtNoteArrowSize;
        private System.Windows.Forms.TextBox txtNoteLineWidth;
        private System.Windows.Forms.ComboBox cbNoteFontSize;
        private System.Windows.Forms.Button btnNoteArrowColor;
        private System.Windows.Forms.Button btnNoteLineColor;
        private System.Windows.Forms.Button btnNoteTextColor;
        private System.Windows.Forms.Button btnNoteSelectedBoxStrokeColor;
        private System.Windows.Forms.Button btnNoteHighlightedBoxStrokeColor;
        private System.Windows.Forms.Button btnNoteHighlightedBoxFillColor;
        private System.Windows.Forms.Button btnNoteBoxStrokeColor;
        private System.Windows.Forms.Button btnNoteBoxFillColor;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.GroupBox grpNoteSymbol;
        private System.Windows.Forms.TextBox txtNoteSymbolSize;
        private System.Windows.Forms.Button btnNoteSymbolTextColor;
        private System.Windows.Forms.ComboBox cbNoteSymbolTextSize;
        private System.Windows.Forms.Button btnNoteSymbolStrokeColor;
        private System.Windows.Forms.Button btnNoteSymbolFillColor;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.GroupBox grpMeasureOption;
        private System.Windows.Forms.CheckBox ckMeasureXYZAxisDistanceDecomposed;
        private System.Windows.Forms.ComboBox cbMeasureDecimalPoint;
        private System.Windows.Forms.ComboBox cbMeasureUnit;
        private System.Windows.Forms.ComboBox cbMeasureDistanceUnit;
        private System.Windows.Forms.CheckBox ckMeasureUnit;
        private System.Windows.Forms.CheckBox ckMeasureType;
        private System.Windows.Forms.CheckBox ckMeasureFrame;
        private System.Windows.Forms.CheckBox ckMeasureDxDyDz;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.GroupBox grpMeasureStyle;
        private System.Windows.Forms.ComboBox cbMeasureTextHorizontalAlignment;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.ComboBox cbMeasureLineStrokePattern;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TextBox txtMeasureArrowSize;
        private System.Windows.Forms.TextBox txtMeasureLineWidth;
        private System.Windows.Forms.ComboBox cbMeasureFontSize;
        private System.Windows.Forms.Button btnMeasureArrowColor;
        private System.Windows.Forms.Button btnMeasureLineColor;
        private System.Windows.Forms.Button btnMeasureTextColor;
        private System.Windows.Forms.Button btnMeasureSelectedBoxStrokeColor;
        private System.Windows.Forms.Button btnMeasureHighlightedBoxStrokeColor;
        private System.Windows.Forms.Button btnMeasureHighlightedBoxFillColor;
        private System.Windows.Forms.Button btnMeasureBoxStrokeColor;
        private System.Windows.Forms.Button btnMeasureBoxFillColor;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.GroupBox grpMeasureSnap;
        private System.Windows.Forms.NumericUpDown numMeasureSnapCylinderAxisSize;
        private System.Windows.Forms.NumericUpDown numMeasureSnapPointSize;
        private System.Windows.Forms.NumericUpDown numMeasureSnapPlaneSize;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.GroupBox grpSectionStyle;
        private System.Windows.Forms.Button btnSectionDisabledBoundaryStrokeColor;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Button btnSectionHighlightedBoundaryStrokeColor;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.ComboBox cbSectionManipulatorDisplayMode;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Button btnSectionSelectedBoundaryStrokeColor;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Button btnSectionDisabledFaceFillColor;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.ComboBox cbSectionBoundaryStrokePattern;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Button btnSectionBoundaryStrokeColor;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.TextBox txtSectionBoundaryStrokeThickness;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Button btnSectionFaceFillColor;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.GroupBox grpSectionCap;
        private System.Windows.Forms.TextBox txtCapStrokeThickness;
        private System.Windows.Forms.Label lblCapStrokeThickness;
        private System.Windows.Forms.ComboBox cbCapStrokeColorMode;
        private System.Windows.Forms.Label lblCapStrokeColorMode;
        private System.Windows.Forms.Button btnCapStrokeColor;
        private System.Windows.Forms.Label lblCapStrokeColor;
        private System.Windows.Forms.ComboBox cbCapFillColorMode;
        private System.Windows.Forms.Label lblCapFillColorMode;
        private System.Windows.Forms.Button btnCapFillColor;
        private System.Windows.Forms.Label lblCapFillColor;
        private System.Windows.Forms.CheckBox cbCapStroke;
        private System.Windows.Forms.CheckBox cbCapFill;
        private System.Windows.Forms.GroupBox grpDecal;
        private System.Windows.Forms.Label lblDecalHighlightedBoxFillColor;
        private System.Windows.Forms.Button btnDecalHighlightedBoxFillColor;
        private System.Windows.Forms.Label lblDecalHighlightedBoxStrokeColor;
        private System.Windows.Forms.Button btnDecalHighlightedBoxStrokeColor;
        private System.Windows.Forms.Label lblDecalSelectedBoxStrokeColor;
        private System.Windows.Forms.Button btnDecalSelectedBoxStrokeColor;
        private System.Windows.Forms.Label lblDecalRotationAngleStep;
        private System.Windows.Forms.NumericUpDown numDecalRotationAngleStep;
        private System.Windows.Forms.Label lblDecalRotationAngleStepUnit;
        private System.Windows.Forms.GroupBox grpFrameView;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comboBoxFrameZLabel;
        private System.Windows.Forms.ComboBox comboBoxFrameYLabel;
        private System.Windows.Forms.ComboBox comboBoxFrameXLabel;
        private System.Windows.Forms.CheckBox ckFrameZLine;
        private System.Windows.Forms.CheckBox ckFrameZXPlane;
        private System.Windows.Forms.CheckBox ckFrameYLine;
        private System.Windows.Forms.CheckBox ckFrameYZPlane;
        private System.Windows.Forms.CheckBox ckFrameXLine;
        private System.Windows.Forms.CheckBox ckFrameXYPlane;
        private System.Windows.Forms.GroupBox grpFrameColor;
        private System.Windows.Forms.ComboBox cbFramePlaneStrokePattern;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbGridLineStrokePattern;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Button btnFrameLabelColor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numFrameLineThickness;
        private System.Windows.Forms.NumericUpDown numFramePlaneThickness;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnFrameLineColor;
        private System.Windows.Forms.Button btnFramePlaneColor;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox grpPreSelect;
        private System.Windows.Forms.CheckBox ckPreSelectEnable;
        private System.Windows.Forms.Label lblPreSelectOutlineColor;
        private System.Windows.Forms.Button btnPreSelectOutlineColor;
        private System.Windows.Forms.Label lblPreSelectDelay;
        private System.Windows.Forms.NumericUpDown numPreSelectDelay;
        private System.Windows.Forms.Label lblPreSelectLimit;
        private System.Windows.Forms.NumericUpDown numPreSelectLimit;
        private System.Windows.Forms.CheckBox ckPreSelectAutoScroll;
        private System.Windows.Forms.CheckBox ckModelTreeAutoExpand;
        private System.Windows.Forms.CheckBox ckModelTreeAutoScroll;
        private System.Windows.Forms.CheckBox ckPreSelectNodeNameVisible;
        private System.Windows.Forms.Label lblPreSelectNodeNameTarget;
        private System.Windows.Forms.ComboBox cbPreSelectNodeNameTarget;
        private System.Windows.Forms.GroupBox grpWindowModelTree;
        private System.Windows.Forms.CheckBox ckModelTreePanelVisible;
        private System.Windows.Forms.Label lblModelTreePanelPosition;
        private System.Windows.Forms.ComboBox cbModelTreePanelPosition;
        private System.Windows.Forms.Label lblModelTreePanelWidth;
        private System.Windows.Forms.NumericUpDown numModelTreePanelWidth;
        private System.Windows.Forms.GroupBox grpWindowAttribute;
        private System.Windows.Forms.CheckBox ckAttributePanelVisible;
        private System.Windows.Forms.Label lblAttributePanelPosition;
        private System.Windows.Forms.ComboBox cbAttributePanelPosition;
        private System.Windows.Forms.Label lblAttributePanelWidth;
        private System.Windows.Forms.NumericUpDown numAttributePanelWidth;
        private System.Windows.Forms.GroupBox grpWindowSplit;
        private System.Windows.Forms.RadioButton rbSplitTop;
        private System.Windows.Forms.RadioButton rbSplitBottom;
        private System.Windows.Forms.RadioButton rbSplitLeft;
        private System.Windows.Forms.RadioButton rbSplitRight;
        private System.Windows.Forms.GroupBox grpObserverFigure;
        private System.Windows.Forms.CheckBox ckObserverShowFigure;
        private System.Windows.Forms.Label lblObserverFigureSize;
        private System.Windows.Forms.NumericUpDown numObserverFigureSize;
        private System.Windows.Forms.Label lblObserverFigureColor;
        private System.Windows.Forms.Button btnObserverFigureColor;
        private System.Windows.Forms.Label lblObserverRingColor;
        private System.Windows.Forms.Button btnObserverRingColor;
        private System.Windows.Forms.Label lblObserverNoseColor;
        private System.Windows.Forms.Button btnObserverNoseColor;
        private System.Windows.Forms.GroupBox grpObserverResultColor;
        private System.Windows.Forms.Label lblObserverVisibleColor;
        private System.Windows.Forms.Button btnObserverVisibleColor;
        private System.Windows.Forms.Label lblObserverHiddenColor;
        private System.Windows.Forms.Button btnObserverHiddenColor;
        private System.Windows.Forms.GroupBox grpObserverView;
        private System.Windows.Forms.Label lblObserverAngularStep;
        private System.Windows.Forms.NumericUpDown numObserverAngularStep;
        private System.Windows.Forms.Label lblObserverMaxDistance;
        private System.Windows.Forms.NumericUpDown numObserverMaxDistance;
        private System.Windows.Forms.Label lblObserverEyeHeight;
        private System.Windows.Forms.NumericUpDown numObserverEyeHeight;
        private System.Windows.Forms.GroupBox grpDevInfo;
        private System.Windows.Forms.CheckBox checkDebugInfo;
        private System.Windows.Forms.GroupBox grpDevCache;
        private System.Windows.Forms.NumericUpDown numericTemporaryCacheSize;
        private System.Windows.Forms.NumericUpDown numericPermanentCacheSize;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox grpDevRendering;
        private System.Windows.Forms.CheckBox checkAutomaticRenderingLimit;
        private System.Windows.Forms.NumericUpDown numericRenderingLimitPerStep;
        private System.Windows.Forms.NumericUpDown numericRenderingLimitInControl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grpToolbarRibbon;
        private System.Windows.Forms.ComboBox cbRibbonTheme;
        private System.Windows.Forms.Label lblRibbonTheme;
        private System.Windows.Forms.CheckBox ckRibbonMode;
        private System.Windows.Forms.GroupBox grpToolbarHome;
        private System.Windows.Forms.Label lblToolbarHomeRow;
        private System.Windows.Forms.NumericUpDown numToolbarHomeRow;
        private System.Windows.Forms.Label lblToolbarHomeOrder;
        private System.Windows.Forms.NumericUpDown numToolbarHomeOrder;
        private System.Windows.Forms.RadioButton rbToolbarHomeRight;
        private System.Windows.Forms.RadioButton rbToolbarHomeLeft;
        private System.Windows.Forms.RadioButton rbToolbarHomeTop;
        private System.Windows.Forms.CheckBox ckToolbarHome;
        private System.Windows.Forms.GroupBox grpToolbarNote;
        private System.Windows.Forms.Label lblToolbarNoteRow;
        private System.Windows.Forms.NumericUpDown numToolbarNoteRow;
        private System.Windows.Forms.Label lblToolbarNoteOrder;
        private System.Windows.Forms.NumericUpDown numToolbarNoteOrder;
        private System.Windows.Forms.RadioButton rbToolbarNoteRight;
        private System.Windows.Forms.RadioButton rbToolbarNoteLeft;
        private System.Windows.Forms.RadioButton rbToolbarNoteTop;
        private System.Windows.Forms.CheckBox ckToolbarNote;
        private System.Windows.Forms.GroupBox grpToolbarMeasure;
        private System.Windows.Forms.Label lblToolbarMeasureRow;
        private System.Windows.Forms.NumericUpDown numToolbarMeasureRow;
        private System.Windows.Forms.Label lblToolbarMeasureOrder;
        private System.Windows.Forms.NumericUpDown numToolbarMeasureOrder;
        private System.Windows.Forms.RadioButton rbToolbarMeasureRight;
        private System.Windows.Forms.RadioButton rbToolbarMeasureLeft;
        private System.Windows.Forms.RadioButton rbToolbarMeasureTop;
        private System.Windows.Forms.CheckBox ckToolbarMeasure;
        private System.Windows.Forms.GroupBox grpToolbarSection;
        private System.Windows.Forms.Label lblToolbarSectionRow;
        private System.Windows.Forms.NumericUpDown numToolbarSectionRow;
        private System.Windows.Forms.Label lblToolbarSectionOrder;
        private System.Windows.Forms.NumericUpDown numToolbarSectionOrder;
        private System.Windows.Forms.RadioButton rbToolbarSectionRight;
        private System.Windows.Forms.RadioButton rbToolbarSectionLeft;
        private System.Windows.Forms.RadioButton rbToolbarSectionTop;
        private System.Windows.Forms.CheckBox ckToolbarSection;
        private System.Windows.Forms.GroupBox grpToolbarSnapshot;
        private System.Windows.Forms.Label lblToolbarSnapshotRow;
        private System.Windows.Forms.NumericUpDown numToolbarSnapshotRow;
        private System.Windows.Forms.Label lblToolbarSnapshotOrder;
        private System.Windows.Forms.NumericUpDown numToolbarSnapshotOrder;
        private System.Windows.Forms.RadioButton rbToolbarSnapshotRight;
        private System.Windows.Forms.RadioButton rbToolbarSnapshotLeft;
        private System.Windows.Forms.RadioButton rbToolbarSnapshotTop;
        private System.Windows.Forms.CheckBox ckToolbarSnapshot;
        private System.Windows.Forms.GroupBox grpToolbarDecal;
        private System.Windows.Forms.Label lblToolbarDecalRow;
        private System.Windows.Forms.NumericUpDown numToolbarDecalRow;
        private System.Windows.Forms.Label lblToolbarDecalOrder;
        private System.Windows.Forms.NumericUpDown numToolbarDecalOrder;
        private System.Windows.Forms.RadioButton rbToolbarDecalRight;
        private System.Windows.Forms.RadioButton rbToolbarDecalLeft;
        private System.Windows.Forms.RadioButton rbToolbarDecalTop;
        private System.Windows.Forms.CheckBox ckToolbarDecal;
        private System.Windows.Forms.GroupBox grpToolbarPrimitive;
        private System.Windows.Forms.Label lblToolbarPrimitiveRow;
        private System.Windows.Forms.NumericUpDown numToolbarPrimitiveRow;
        private System.Windows.Forms.Label lblToolbarPrimitiveOrder;
        private System.Windows.Forms.NumericUpDown numToolbarPrimitiveOrder;
        private System.Windows.Forms.RadioButton rbToolbarPrimitiveRight;
        private System.Windows.Forms.RadioButton rbToolbarPrimitiveLeft;
        private System.Windows.Forms.RadioButton rbToolbarPrimitiveTop;
        private System.Windows.Forms.CheckBox ckToolbarPrimitive;
        private System.Windows.Forms.GroupBox grpToolbarSelectionBox;
        private System.Windows.Forms.Label lblToolbarSelectionBoxRow;
        private System.Windows.Forms.NumericUpDown numToolbarSelectionBoxRow;
        private System.Windows.Forms.Label lblToolbarSelectionBoxOrder;
        private System.Windows.Forms.NumericUpDown numToolbarSelectionBoxOrder;
        private System.Windows.Forms.RadioButton rbToolbarSelectionBoxRight;
        private System.Windows.Forms.RadioButton rbToolbarSelectionBoxLeft;
        private System.Windows.Forms.RadioButton rbToolbarSelectionBoxTop;
        private System.Windows.Forms.CheckBox ckToolbarSelectionBox;
        private System.Windows.Forms.GroupBox grpToolbarZone;
        private System.Windows.Forms.Label lblToolbarZoneRow;
        private System.Windows.Forms.NumericUpDown numToolbarZoneRow;
        private System.Windows.Forms.Label lblToolbarZoneOrder;
        private System.Windows.Forms.NumericUpDown numToolbarZoneOrder;
        private System.Windows.Forms.RadioButton rbToolbarZoneRight;
        private System.Windows.Forms.RadioButton rbToolbarZoneLeft;
        private System.Windows.Forms.RadioButton rbToolbarZoneTop;
        private System.Windows.Forms.CheckBox ckToolbarZone;
        private System.Windows.Forms.GroupBox grpToolbarEffect;
        private System.Windows.Forms.Label lblToolbarEffectRow;
        private System.Windows.Forms.NumericUpDown numToolbarEffectRow;
        private System.Windows.Forms.Label lblToolbarEffectOrder;
        private System.Windows.Forms.NumericUpDown numToolbarEffectOrder;
        private System.Windows.Forms.RadioButton rbToolbarEffectRight;
        private System.Windows.Forms.RadioButton rbToolbarEffectLeft;
        private System.Windows.Forms.RadioButton rbToolbarEffectTop;
        private System.Windows.Forms.CheckBox ckToolbarEffect;
        private System.Windows.Forms.GroupBox grpToolbarObserver;
        private System.Windows.Forms.Label lblToolbarObserverRow;
        private System.Windows.Forms.NumericUpDown numToolbarObserverRow;
        private System.Windows.Forms.Label lblToolbarObserverOrder;
        private System.Windows.Forms.NumericUpDown numToolbarObserverOrder;
        private System.Windows.Forms.RadioButton rbToolbarObserverRight;
        private System.Windows.Forms.RadioButton rbToolbarObserverLeft;
        private System.Windows.Forms.RadioButton rbToolbarObserverTop;
        private System.Windows.Forms.CheckBox ckToolbarObserver;
        private System.Windows.Forms.GroupBox grpApply;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpModel;
        private System.Windows.Forms.Button btnOpenModel;
    }
}
