using System;
using System.Drawing;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.MeetingNotes
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        public int NoteNo { get; set; }

        private static readonly Random _rand = new Random();

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer2.Panel1.Controls.Add(vizcore3dx);

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            NoteNo = 1;
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================
            // 라이선스 파일을 통한 인증
            //vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("127.0.0.1", 8901);

            // ================================================================
            // License
            // ================================================================
            // VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");
            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeVIZCore3DX();
            InitializeVIZCore3DXEvent();
        }

        private void InitializeVIZCore3DX()
        {
            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 차단
            // ================================================================
            vizcore3dx.BeginUpdate();

            try
            {
                // ================================================================
                // 설정 - 툴바
                // ================================================================

                // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
                vizcore3dx.RibbonMode = true;
                ShowRibbonTabs(VIZCore3DX.NET.Data.ToolbarKind.Note);
                ShowAttributeTabs();

            }
            finally
            {
                // ================================================================
                // 모델 열기 시, 3D 화면 Rendering 재시작
                // ================================================================
                vizcore3dx.EndUpdate();
            }

            SetNoteStyle();
        }

        private void InitializeVIZCore3DXEvent()
        {
            // 중복 등록 방지
            vizcore3dx.Note.OnNoteCreated -= Note_OnNoteCreated;
            vizcore3dx.Note.OnNoteCreated += Note_OnNoteCreated;
        }

        private void Note_OnNoteCreated(object sender, EventManager.NoteEventArgs e)
        {
            if (e == null || e.Note == null) return;

            // 방금 생성된 노트 하나에만 랜덤 스타일 적용
            e.Note.SetStyle(CreateRandomNoteStyle());

            ListViewItem lvi = new ListViewItem(new string[] { NoteNo.ToString(), "Note..." });
            lvi.Tag = vizcore3dx.View.GetCameraData();

            lvNotes.Items.Add(lvi);
            lvi.EnsureVisible();

            NoteNo++;

            if (ckRepeatMode.Checked == false) return;

            BeginInvoke(new Action(() => vizcore3dx.Note.AddNoteSurface("", NoteSymbolType.Circle, NoteNo.ToString())));
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            lvNotes.Items.Clear();
            NoteNo = 1;
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Note.AddNoteSurface("", NoteSymbolType.Circle, NoteNo.ToString());
        }

        // 기존 Stop을 Clear로 변경
        private void btnClearNote_Click(object sender, EventArgs e)
        {
            vizcore3dx.Note.Clear();
            lvNotes.Items.Clear();
            NoteNo = 1;
        }

        private void lvNotes_DoubleClick(object sender, EventArgs e)
        {
            if (lvNotes.SelectedItems.Count == 0) return;

            ListViewItem lvi = lvNotes.SelectedItems[0];
            CameraData camera = lvi.Tag as CameraData;

            if (camera == null) return;

            vizcore3dx.View.SetCameraData(camera);
        }

        private void SetNoteStyle()
        {
            NoteStyle style = vizcore3dx.Note.GetStyle();

            // 텍스트 박스 안 보이게
            style.BoxFillColor = Color.Transparent;
            style.BoxStrokeColor = Color.Transparent;
            style.HighlightedBoxFillColor = Color.Transparent;
            style.HighlightedBoxStrokeColor = Color.Transparent;
            style.SelectedBoxStrokeColor = Color.Transparent;
            style.TextColor = Color.Transparent;

            // 선/화살표 안 보이게
            style.LineStrokeColor = Color.Transparent;
            style.LineStrokeThickness = 1;
            style.ArrowColor = Color.Transparent;
            style.ArrowHeadSize = 0;

            // 심벌만 보이게
            style.SymbolFillColor = Color.Aquamarine;
            style.SymbolStrokeColor = Color.Black;
            style.SymbolSize = 18;
            style.SymbolTextColor = Color.Black;
            style.SymbolTextSize = TextSizeType.Size_14;

            vizcore3dx.Note.SetStyle(style);
        }

        private NoteCustomStyle CreateRandomNoteStyle()
        {
            NoteCustomStyle style = vizcore3dx.Note.CreateCustomStyle();

            // 텍스트 박스 안 보이게
            style.BoxFillColor = Color.Transparent;
            style.BoxStrokeColor = Color.Transparent;
            style.TextColor = Color.Transparent;

            // 선/화살표 안 보이게
            style.LineStrokeColor = Color.Transparent;
            style.LineStrokeThickness = 1;
            style.ArrowColor = Color.Transparent;
            style.ArrowHeadSize = 0;

            // 이 노트 하나에만 적용될 랜덤 심벌색
            style.SymbolFillColor = GetRandomColor();
            style.SymbolStrokeColor = Color.Black;
            style.SymbolSize = 18;
            style.SymbolTextColor = Color.Black;
            style.SymbolTextSize = TextSizeType.Size_14;

            return style;
        }

        private Color GetRandomColor()
        {
            Color[] colors =
            {
                Color.LightYellow,
                Color.LightCyan,
                Color.LightPink,
                Color.LightSalmon,
                Color.PaleGreen,
                Color.PaleTurquoise,
                Color.Plum,
                Color.Wheat,
                Color.Moccasin,
                Color.Aquamarine,
                Color.FromArgb(_rand.Next(10, 256), _rand.Next(10, 256), _rand.Next(10, 256)),
                Color.FromArgb(_rand.Next(10, 256), _rand.Next(10, 256), _rand.Next(10, 256)),
                Color.FromArgb(_rand.Next(10, 256), _rand.Next(10, 256), _rand.Next(10, 256))
            };

            return colors[_rand.Next(colors.Length)];
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
    }
}