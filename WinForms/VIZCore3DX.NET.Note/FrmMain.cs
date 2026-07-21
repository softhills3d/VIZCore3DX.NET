using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.Note
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;
        private bool _symbolMode = false;

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            //Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
        }


        // ================================================
        // Event - VIZCore3D.NET
        // ================================================

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================
            // 라이선스 파일을 통한 인증
            //vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("192.168.100.252", 8901);


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
            InitializeVIZCore3DEvent();
        }

        private void InitializeVIZCore3DX()
        {
            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 차단
            // ================================================================
            vizcore3dx.BeginUpdate();

            // ================================================================
            // 설정 - 툴바
            // ================================================================
            vizcore3dx.ToolbarMain.Visible = true;
            vizcore3dx.ToolbarNote.Visible = false;
            vizcore3dx.ToolbarMeasure.Visible = false;
            vizcore3dx.ToolbarSection.Visible = false;
            vizcore3dx.ToolbarSnapshot.Visible = false;

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }

        private void InitializeVIZCore3DEvent()
        {
            // 마우스로 개체 클릭했을 때
            vizcore3dx.Object3D.OnNodeClick += Object3D_OnNodeClick;

            // 노트 이벤트리스트 작성
            vizcore3dx.Note.OnNoteCreated += Note_OnNoteCreated;
            vizcore3dx.Note.OnNoteMoved += Note_OnNoteMoved;
            vizcore3dx.Note.OnNoteSelectionChanged += Note_OnNoteSelectionChanged;
        }


        private void Note_OnNoteSelectionChanged(object sender, EventManager.NoteEventArgs e)
        {
            NoteItem note = vizcore3dx.Note.GetItem(e.ID);
            if (note == null) return;

            AddLog(string.Format("[NOTE 선택] ID:{0} / Title:{1} / Selected:{2}", note.ID, note.Title, note.Selected));

        }

        private void Note_OnNoteMoved(object sender, EventManager.NoteEventArgs e)
        {
            NoteItem note = vizcore3dx.Note.GetItem(e.ID);
            if (note == null) return;

            AddLog(string.Format("[NOTE 이동] ID:{0} / Title:{1} / Position:({2:F2}, {3:F2}, {4:F2})", note.ID, note.Title, note.TextPosition.X, note.TextPosition.Y, note.TextPosition.Z));
        }

        private void Note_OnNoteCreated(object sender, EventManager.NoteEventArgs e)
        {
            NoteItem note = vizcore3dx.Note.GetItem(e.ID);
            if (note == null) return;

            // 생성된 노트에만 현재 체크 상태 적용
            NoteCustomStyle style = note.CustomStyle;
            style.BoxFillColor = ckTransparent.Checked == true ? Color.FromArgb(0, Color.White) : Color.White;
            note.SetStyle(style);

            if (_symbolMode == true)
            {
                _symbolMode = false;
                vizcore3dx.Object3D.OnNodeClick -= Object3D_OnNodeClick;
                vizcore3dx.Object3D.OnNodeClick += Object3D_OnNodeClick;
            }

            AddLog(string.Format("[NOTE 생성] ID:{0} / Type:{1} / Title:{2} / Position:({3:F2}, {4:F2}, {5:F2})", note.ID, note.Type, note.Title, note.TextPosition.X, note.TextPosition.Y, note.TextPosition.Z));
        }

        private void AddLog(string str)
        {
            if (String.IsNullOrEmpty(str) == true) return;

            lbEvent.Invoke(new EventHandler(delegate
            {
                lbEvent.Items.Insert(0, str);
            }));

        }

        private void Object3D_OnNodeClick(object sender, EventManager.NodeMouseEventArgs e)
        {
            if (e == null || e.Node == null || ckEnable.Checked == false) return;

            // 기존 노트를 클릭한 경우 새 노트를 생성하지 않음
            List<NoteItem> notes = vizcore3dx.Note.GetSelectedItems();

            if (notes != null && notes.Count > 0)
            {
                vizcore3dx.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);
                return;
            }

            // 노드 선택 하이라이트 제거
            vizcore3dx.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);

            // 노트 공통 스타일 설정
            vizcore3dx.Note.SetStyle(CreateNoteStyle());

            // 공통 텍스트 생성
            string text = CreateNoteText(e.Node);

            // 심벌 노트
            if (ckUseSymbol.Checked == true)
            {
                _symbolMode = true;

                // 일반 클릭 이벤트 잠시 해제
                vizcore3dx.Object3D.OnNodeClick -= Object3D_OnNodeClick;

                vizcore3dx.Note.AddNoteSurface(text, NoteSymbolType.Circle, Convert.ToString(vizcore3dx.Note.GetID().Count + 1));
                return;
            }

            // 일반 노트
            AddSurfaceNoteForNode(e.X, e.Y, text);
        }

        private void AddSurfaceNoteForNode(int mouseX, int mouseY, string text)
        {
            // 클릭 위치 기준 Node + 3D Position 조회
            var pick = vizcore3dx.View.GetNodeWithPosition(new Point(mouseX, mouseY));
            if (pick == null || pick.Item1 == null) return;

            // 클릭한 실제 표면 위치
            Vertex3D surfacePt = pick.Item2.ToVertex3D();

            // 노트 텍스트 위치
            Vertex3D notePt = new Vertex3D(surfacePt.X + 2000.0f, surfacePt.Y, surfacePt.Z + 2000.0f);

            // 화면 갱신 차단
            vizcore3dx.BeginUpdate();
            vizcore3dx.Note.AddNoteSurface(text, notePt, surfacePt);
            vizcore3dx.EndUpdate();
        }

        private void btnGetSize_Click(object sender, EventArgs e)
        {
            // 현재 선택된 노트 목록 가져오기
            List<NoteItem> notes = vizcore3dx.Note.GetSelectedItems();

            // 선택된 노트 없으면 종료
            if (notes == null || notes.Count == 0)
            {
                AddLog("[NOTE SIZE] 선택된 노트가 없습니다.");
                return;
            }

            // 첫 번째 선택 노트
            NoteItem note = notes[0];

            // 다시 가져오기
            note = vizcore3dx.Note.GetItem(note.ID);

            // api 제공값
            SizeF sdkSize = note.ScreenDisplaySize;

            // api 값이 0이면 텍스트 기준으로 직접 계산
            Size textSize = TextRenderer.MeasureText(note.Title, new Font("Arial", 18.0f, FontStyle.Bold));

            txtWidth.Text = sdkSize.Width > 0 ? sdkSize.Width.ToString("F2") : textSize.Width.ToString();
            txtHeight.Text = sdkSize.Height > 0 ? sdkSize.Height.ToString("F2") : textSize.Height.ToString();

            AddLog(string.Format(
                "[NOTE SIZE] ID:{0} / Text:{1},{2} / SDK:{3:F2},{4:F2}",
                note.ID,
                textSize.Width,
                textSize.Height,
                sdkSize.Width,
                sdkSize.Height
            ));
        }

        private NoteStyle CreateNoteStyle()
        {
            NoteStyle style = vizcore3dx.Note.GetStyle();

            // 화살표 색상
            style.ArrowColor = Color.Black;

            // 노트 박스 선 색상
            style.BoxStrokeColor = Color.Black;

            // 선 설정
            style.LineStrokeColor = Color.Red;
            style.LineStrokePattern = StrokePattern.Solid;
            style.LineStrokeThickness = 3.0f;

            // 심벌 설정
            style.SymbolFillColor = Color.Yellow;
            style.SymbolStrokeColor = Color.Red;
            style.SymbolTextColor = Color.Black;
            style.SymbolTextSize = TextSizeType.Size_14;

            // 문자열 설정
            style.TextColor = Color.Black;
            style.TextSize = TextSizeType.Size_18;
            style.TextHorizontalAlignment = VIZCore3DX.NET.Data.HorizontalAlignment.Left;

            return style;
        }

        private string CreateNoteText(Node node)
        {
            if (node == null) return string.Empty;

            string modelName = "UNKNOWN";
            List<Node> roots = vizcore3dx.Object3D.FromFilter(Object3dFilter.ROOT);

            if (roots != null && roots.Count > 0 && roots[0] != null)
                modelName = roots[0].NodeName;

            string name = node.NodeName;

            // 선택한 노드가 BODY이면 상위 노드 이름 사용
            if (node.Kind == NodeKind.BODY)
            {
                Node parentNode = vizcore3dx.Object3D.GetParentNode(node);
                if (parentNode != null) name = parentNode.NodeName;
            }

            return "MODEL : " + modelName + Environment.NewLine + "NAME : " + name;
        }

        private void ckUseSymbol_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.Object3D.OnNodeClick -= Object3D_OnNodeClick;
            vizcore3dx.Object3D.OnNodeClick += Object3D_OnNodeClick;
        }
    }
}
