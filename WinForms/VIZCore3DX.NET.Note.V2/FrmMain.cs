using System;
using System.Collections.Generic;
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
        private bool _suppressNoteListRefresh = false;

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

            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs(VIZCore3DX.NET.Data.ToolbarKind.Note);
            ShowAttributeTabs();

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

            // 노트 목록 갱신 이벤트 (생성 / 삭제 / 이동)
            vizcore3dx.Note.OnNoteCreated += Note_OnNoteListChanged;
            vizcore3dx.Note.OnNoteDeleted += Note_OnNoteListChanged;
            vizcore3dx.Note.OnNoteMoved += Note_OnNoteListChanged;
        }

        // 노트 생성 / 삭제 / 이동 시 목록 갱신
        private void Note_OnNoteListChanged(object sender, EventManager.NoteEventArgs e)
        {
            if (_suppressNoteListRefresh == true) return;

            RefreshNoteList(GetSelectedNoteId());
        }

        // ================================================
        // 노트 목록
        // ================================================
        private void RefreshNoteList(uint selectId)
        {
            dgvNotes.SelectionChanged -= dgvNotes_SelectionChanged;
            dgvNotes.Rows.Clear();

            List<NoteItem> notes = vizcore3dx.Note.Notes ?? new List<NoteItem>();

            foreach (NoteItem note in notes)
            {
                if (note == null || note.IsDeleted == true) continue;

                string target = note.Type == NoteType.Surface ? FormatPosition(note.TargetPosition) : "-";
                int index = dgvNotes.Rows.Add(note.ID, note.Type, GetFirstLine(note.Title), target);
                dgvNotes.Rows[index].Tag = note.ID;
            }

            dgvNotes.ClearSelection();
            foreach (DataGridViewRow row in dgvNotes.Rows)
            {
                if ((uint)row.Tag != selectId) continue;

                row.Selected = true;
                break;
            }

            dgvNotes.SelectionChanged += dgvNotes_SelectionChanged;
            UpdateTargetPositionLabel();
        }

        private uint GetSelectedNoteId()
        {
            if (dgvNotes.SelectedRows.Count == 0 || dgvNotes.SelectedRows[0].Tag == null) return 0;

            return (uint)dgvNotes.SelectedRows[0].Tag;
        }

        private NoteItem GetSelectedNote()
        {
            uint id = GetSelectedNoteId();
            if (id == 0) return null;

            return vizcore3dx.Note.GetItem(id);
        }

        private void UpdateTargetPositionLabel()
        {
            NoteItem note = GetSelectedNote();

            if (note == null)
                lblTargetPosition.Text = "대상점 : -";
            else if (note.Type != NoteType.Surface)
                lblTargetPosition.Text = "대상점 : - (표면 노트가 아닙니다)";
            else
                lblTargetPosition.Text = "대상점 : " + FormatPosition(note.TargetPosition);
        }

        private string FormatPosition(Vector3D position)
        {
            if (position == null) return "-";

            return string.Format("{0:F1}, {1:F1}, {2:F1}", position.X, position.Y, position.Z);
        }

        private string GetFirstLine(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;

            int index = text.IndexOfAny(new char[] { '\r', '\n' });
            return index < 0 ? text : text.Substring(0, index);
        }

        private void dgvNotes_SelectionChanged(object sender, EventArgs e)
        {
            UpdateTargetPositionLabel();
        }

        private void btnRefreshNotes_Click(object sender, EventArgs e)
        {
            RefreshNoteList(GetSelectedNoteId());
        }

        private void btnArrangeText_Click(object sender, EventArgs e)
        {
            List<NoteItem> notes = vizcore3dx.Note.GetVisibleItems();
            if (notes == null || notes.Count == 0) return;

            // 자동 배치 : 각 노트의 TargetPosition(대상점)을 기준점으로 텍스트를 화면에 맞춰 배치
            vizcore3dx.View.FitAndArrangeText(notes);
        }

        // ================================================
        // 표면 노트 대상점 이동
        // ================================================
        private async void btnSetTargetOsnap_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            NoteItem note = GetSelectedNote();
            if (note == null)
            {
                MessageBox.Show("노트 목록에서 대상점을 이동할 노트를 선택해주세요.", "VIZCore3DX.NET.Note.V2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (note.Type != NoteType.Surface)
            {
                MessageBox.Show("표면 노트만 대상점을 이동할 수 있습니다.", "VIZCore3DX.NET.Note.V2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 대상점 선택 중 노트가 추가되지 않도록 노트 생성 모드 해제
            ckEnable.Checked = false;

            OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();
            osnap.CommandText = "노트가 가리킬 새 대상점을 선택하세요.";
            OsnapResult result = await osnap.GetResultAsync();
            if (result == null) return;

            // 노트가 가리키는 지점 이동 (OnNoteMoved 발생, Undo 가능)
            Vertex3D target = result.Position.ToVertex3D();
            if (vizcore3dx.Note.SetTargetPosition(note.ID, target) == false)
            {
                ShowLastOperationStatus("대상점을 이동하지 못했습니다.");
                return;
            }

            RefreshNoteList(note.ID);
        }

        // ================================================
        // 내보내기 / 문자열 저장·복원
        // ================================================
        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Note.GetCount() == 0)
            {
                MessageBox.Show("내보낼 노트가 없습니다.", "VIZCore3DX.NET.Note.V2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "CSV (*.csv)|*.csv";
            dlg.FileName = "Notes.csv";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            if (vizcore3dx.Note.ExportCsv(dlg.FileName) == false)
            {
                ShowLastOperationStatus("노트 목록을 CSV로 내보내지 못했습니다.");
                return;
            }

            MessageBox.Show("노트 목록을 CSV로 내보냈습니다.\n\n" + dlg.FileName, "VIZCore3DX.NET.Note.V2", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnToJson_Click(object sender, EventArgs e)
        {
            // 노트 목록을 JSON 문자열로 변환
            string json = vizcore3dx.Note.ToJson();
            if (string.IsNullOrEmpty(json))
            {
                ShowLastOperationStatus("노트 목록을 JSON 문자열로 변환하지 못했습니다.");
                return;
            }

            txtJson.Text = json;
        }

        private void btnFromJson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJson.Text)) return;

            bool result;
            _suppressNoteListRefresh = true;

            try
            {
                using (vizcore3dx.BeginUpdateScope())
                {
                    // 기존 노트 삭제 후 JSON 문자열로부터 노트 목록 복원
                    if (chkClearBeforeFromJson.Checked == true) vizcore3dx.Note.Clear();

                    result = vizcore3dx.Note.FromJson(txtJson.Text);
                }
            }
            finally
            {
                _suppressNoteListRefresh = false;
            }

            RefreshNoteList(0);

            if (result == false) ShowLastOperationStatus("JSON 문자열로부터 노트를 복원하지 못했습니다.");
        }

        private void ShowLastOperationStatus(string message)
        {
            OperationStatus status = vizcore3dx.Note.LastOperationStatus;
            if (status != null && status.Result == OperationResult.OperationCancelled) return;

            string reason = status == null ? "-" : status.Result.ToString();
            MessageBox.Show(string.Format("{0}\n\n사유 : {1}", message, reason), "VIZCore3DX.NET.Note.V2", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // 심벌 노트 배치를 ESC 등으로 취소한 경우 클릭 이벤트 복구
            if (ckEnable.Checked == false && _symbolMode == true)
            {
                _symbolMode = false;
                vizcore3dx.Object3D.OnNodeClick -= Object3D_OnNodeClick;
                vizcore3dx.Object3D.OnNodeClick += Object3D_OnNodeClick;
            }

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
            Vector3D normal = new Vector3D(surfacePt - centerPt).GetNormalized();

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
                vizcore3dx.Note.AddNoteSurface(text, NoteSymbolType.Circle, Convert.ToString(vizcore3dx.Note.GetCount() + 1));
            }
            // 일반 노트
            else
            {
                Vertex3D notePt = surfacePt + new Vector3D(1000.0f, 0.0f, 1000.0f);
                vizcore3dx.Note.AddNoteSurface(text, notePt, surfacePt);
            }

            // 선택 하이라이트 제거
            vizcore3dx.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);
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