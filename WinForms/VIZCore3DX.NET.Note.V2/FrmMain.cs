using System;
using System.Drawing;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.Note.V2
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DXControl vizcore3dx;
        private bool _symbolMode = false;
        private MessageItem msg;

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
        }

        // ================================================
        // Event - VIZCore3DX.NET
        // ================================================
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

            // 체크박스 클릭했을 때
            ckEnable.CheckedChanged += CheckBox_CheckedChanged;
            ckSymbol.CheckedChanged += CheckBox_CheckedChanged;

            // ESC 키 눌렀을 때
            vizcore3dx.OnVIZCore3DXKeyDown += VIZCore3DX_OnVIZCore3DXKeyDown;

            // 노트 생성 이벤트
            vizcore3dx.Note.OnNoteCreated += Note_OnNoteCreated;
        }

        // ESC 키 눌렀을 때
        private void VIZCore3DX_OnVIZCore3DXKeyDown(object sender, EventManager.VIZCoreKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) ckEnable.Checked = false;
        }

        // 체크박스 클릭했을 때
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (vizcore3dx?.View?.Message == null) return;

            // 기존 메시지 삭제
            if (msg != null)
            {
                vizcore3dx.View.Message.Delete(msg);
                msg = null;
            }

            // 일반 노트 생성 모드일 때 안내 메시지 표시
            if (ckEnable.Checked == true && ckSymbol.Checked == false)
                msg = vizcore3dx.View.Message.Create("표면점을 선택하여 주십시오.", new Vector2(10, 20), Color.Black, TextSizeType.Size_18, true, true);
        }

        // 심벌 노트 생성 후 연속적으로 노트를 생성하기 위해 클릭 이벤트 다시 연결
        private void Note_OnNoteCreated(object sender, EventManager.NoteEventArgs e)
        {
            if (_symbolMode == false) return;

            _symbolMode = false;
            vizcore3dx.Object3D.OnNodeClick -= Object3D_OnNodeClick;
            vizcore3dx.Object3D.OnNodeClick += Object3D_OnNodeClick;
        }

        private void Object3D_OnNodeClick(object sender, EventManager.NodeMouseEventArgs e)
        {
            if (e == null || e.Node == null || ckEnable.Checked == false) return;

            // 클릭 위치의 노드와 표면점 조회
            var pick = vizcore3dx.View.GetNodeWithPosition(new Point(e.X, e.Y));
            if (pick == null || pick.Item1 == null) return;

            Node node = pick.Item1;
            Vertex3D surfacePt = pick.Item2.ToVertex3D();

            // 선택 지점과 노드 중심을 이용해 Normal Vector 계산
            Vertex3D centerPt = node.GetCenter();
            Vector3D normal = new Vector3D(surfacePt.X - centerPt.X, surfacePt.Y - centerPt.Y, surfacePt.Z - centerPt.Z);
            normal.Normalize();

            // XYZ 반올림
            normal.X = (float)Math.Round(normal.X);
            normal.Y = (float)Math.Round(normal.Y);
            normal.Z = (float)Math.Round(normal.Z);

            string name = node.NodeName;

            // 선택한 노드가 BODY이면 상위 노드 이름 사용
            if (node.Kind == NodeKind.BODY)
            {
                Node parentNode = vizcore3dx.Object3D.GetParentNode(node);
                if (parentNode != null) name = parentNode.NodeName;
            }

            // 노트 텍스트 생성
            string text = name + Environment.NewLine + "VERTEX : " + surfacePt + Environment.NewLine + "NORMAL : " + normal;

            // 노트 공통 스타일 설정
            NoteStyle style = vizcore3dx.Note.GetStyle();

            // 화살표 설정
            style.ArrowHeadSize = 10.0f;
            style.ArrowColor = Color.Red;

            // 지시선 설정
            style.LineStrokeColor = Color.Black;
            style.LineStrokeThickness = 3.0f;
            style.LineStrokePattern = StrokePattern.Solid;

            // 텍스트 박스 설정
            style.BoxFillColor = Color.Yellow;
            style.BoxStrokeColor = Color.Black;
            style.TextColor = Color.Black;
            style.TextSize = TextSizeType.Size_14;
            style.TextHorizontalAlignment = VIZCore3DX.NET.Data.HorizontalAlignment.Left;

            // 심벌 설정
            style.SymbolSize = 12.0f;
            style.SymbolFillColor = Color.Red;
            style.SymbolTextColor = Color.White;
            style.SymbolTextSize = TextSizeType.Size_14;

            vizcore3dx.Note.SetStyle(style);

            // 심벌 노트
            if (ckSymbol.Checked == true)
            {
                _symbolMode = true;

                // 일반 클릭 이벤트 잠시 해제
                vizcore3dx.Object3D.OnNodeClick -= Object3D_OnNodeClick;
                vizcore3dx.Note.AddNoteSurface(text, NoteSymbolType.Circle, Convert.ToString(vizcore3dx.Note.GetID().Count + 1));
            }
            // 일반 노트
            else
            {
                Vertex3D notePt = new Vertex3D(surfacePt.X + 1000.0f, surfacePt.Y, surfacePt.Z + 1000.0f);
                vizcore3dx.Note.AddNoteSurface(text, notePt, surfacePt);
            }

            // 선택 하이라이트 제거
            vizcore3dx.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);
        }
    }
}