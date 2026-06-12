using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.ExportNodeStatus
{
    /// <summary>
    /// 노드 상태(Node Status) Export / Compare 예제.
    ///
    /// 시나리오(모델 버전 관리):
    ///   1) 모델을 연다.
    ///   2) [Add Review Object] 로 마크업(Note/Measure/Section/Snapshot/Decal)을 자동 생성한다.
    ///   3) [PIPE/VALVE/PLATE/PART] 버튼으로 UDA("파트타입") 값별 가시성을 숨김/보임 토글한다.
    ///   4) [Export Node Status] 로 현재 상태(+마크업)를 .vizxs 로 저장한다.
    ///   5) 버전이 바뀐 다른 모델을 열고 [Import (Compare &amp; Apply)] 로
    ///      추가(색상 강조)/변경(가시성·선택 복원)/마크업 복원을 적용한다.
    /// </summary>
    public partial class FrmMain : Form
    {
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        // UDA 조회 기준. 버튼 Text(PIPE/VALVE/PLATE/PART)가 곧 조회할 "값"이 된다. (모델에 맞게 수정)
        private const string UDA_CATEGORY = "General";
        private const string UDA_KEY = "파트타입";

        // UDA 값별 가시성 토글 상태 (없으면 보임으로 간주)
        private readonly Dictionary<string, bool> udaVisible = new Dictionary<string, bool>();

        public FrmMain()
        {
            InitializeComponent();

            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;

            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3D_OnInitializedVIZCore3D;

            splitContainer1.Panel2.Controls.Add(vizcore3dx);
        }

        private void VIZCore3D_OnInitializedVIZCore3D(object sender, EventArgs e)
        {
            // 라이선스 인증 (파일 / 서버 중 택1)
            //vizcore3dx.License.LicenseServer("127.0.0.1", 8901);
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");

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
            // BeginUpdate ~ EndUpdate 구간은 3D 렌더링을 멈춰 초기 설정을 일괄 적용한다.
            vizcore3dx.BeginUpdate();

            vizcore3dx.ToolbarMain.Visible = true;
            vizcore3dx.ToolbarNote.Visible = false;
            vizcore3dx.ToolbarMeasure.Visible = false;
            vizcore3dx.ToolbarSection.Visible = false;
            vizcore3dx.ToolbarSnapshot.Visible = false;
            vizcore3dx.ToolbarDecal.Visible = false;
            vizcore3dx.ToolbarPrimitive.Visible = false;

            vizcore3dx.EndUpdate();
        }

        private void InitializeVIZCore3DXEvent()
        {

        }

        private void Log(string message)
        {
            txtLog.AppendText(message + Environment.NewLine);
        }

        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore3dx.Model.OpenFilter;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Model.Open(dlg.FileName);

            udaVisible.Clear();
            Log("[Model] Open : " + dlg.FileName);
        }

        private void btnAddModels_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore3dx.Model.OpenFilter;
            dlg.Multiselect = true;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Model.Add(dlg.FileNames);

            udaVisible.Clear();
            Log(string.Format("[Model] Add : {0} file(s)", dlg.FileNames.Length));
        }

        private void btnCloseModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Model.Close();

            udaVisible.Clear();
            Log("[Model] Close");
        }

        /// <summary>
        /// 마크업(Note/Measure/Section/Snapshot/Decal)을 자동 생성한다.
        /// Export 시 includeMarkup:true 로 함께 저장되고, Import 시 복원된다.
        /// </summary>
        private void btnAddReview_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            List<Node> nodes = vizcore3dx.Object3D.FromFilter(Data.Object3dFilter.ALL);
            if (nodes == null || nodes.Count == 0)
            {
                Log("[Review] 노드가 없습니다.");
                return;
            }

            BoundBox3D box = vizcore3dx.Object3D.GetBoundBox(nodes);
            Vertex3D center = box.GetCenter();

            // 오브젝트가 한 곳에 겹치지 않도록, 모델 크기에 비례한 간격(step)만큼 서로 떨어뜨려 배치한다.
            float step = Math.Max(box.LengthX, Math.Max(box.LengthY, box.LengthZ)) * 0.2f;
            if (step < 1f) step = 1000f;

            // 마크업 종류별로 생성 API가 달라 개별 try/catch 로 일부 실패를 허용한다.
            try
            {
                Vertex3D notePos = new Data.Vertex3D(center.X + step, center.Y, center.Z + step);
                vizcore3dx.Note.AddNote3D("Review Note", notePos);
                Log("[Review] Note 생성");
            }
            catch (Exception ex) { Log("[Review] Note 실패 : " + ex.Message); }

            try
            {
                Vector3D mp1 = new Data.Vector3D(center.X - step, center.Y - step, center.Z);
                Vector3D mp2 = new Data.Vector3D(center.X + step, center.Y - step, center.Z);
                vizcore3dx.Measure.AddCustomDistance(mp1, mp2);
                Log("[Review] Measure 생성");
            }
            catch (Exception ex) { Log("[Review] Measure 실패 : " + ex.Message); }

            try
            {
                // X/Z 는 모델 전체, Y 길이만 절반인 클리핑 박스
                BoundBox3D sectionBox = new Data.BoundBox3D(center, box.LengthX, box.LengthY * 0.5f, box.LengthZ);
                vizcore3dx.Section.AddBox(sectionBox);
                Log("[Review] Section 생성");
            }
            catch (Exception ex) { Log("[Review] Section 실패 : " + ex.Message); }

            try
            {
                vizcore3dx.Snapshot.Add("Review Snapshot");
                Log("[Review] Snapshot 생성");
            }
            catch (Exception ex) { Log("[Review] Snapshot 실패 : " + ex.Message); }

            try
            {
                // 데칼의 normal(바라보는 방향)과 up(위 방향)은 서로 직교해야 한다.
                Vector3D decalPos = new Data.Vector3D(center.X - step, center.Y, center.Z - step);
                vizcore3dx.Decal.AddDecalText("REVIEW", Color.Yellow, decalPos,
                    new Data.Vector3D(0f, 0f, 1f), new Data.Vector3D(0f, 1f, 0f), 5000f);
                Log("[Review] Decal 생성");
            }
            catch (Exception ex) { Log("[Review] Decal 실패 : " + ex.Message); }
        }

        /// <summary>
        /// PIPE / VALVE / PLATE / PART 공용 핸들러.
        /// 버튼 Text 와 일치하는 UDA 값을 가진 노드를 찾아 가시성을 토글한다.
        /// </summary>
        private void btnUdaToggle_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            Button button = sender as Button;
            if (button == null) return;

            string value = button.Text;

            List<Node> nodes = vizcore3dx.Object3D.UDA.GetCategoryNameValueNodes(UDA_CATEGORY, UDA_KEY, value, true);

            if (nodes == null || nodes.Count == 0)
            {
                Log(string.Format("[UDA] {0}={1} : 0개 (해당 노드 없음)", UDA_KEY, value));
                return;
            }

            // 직전 상태를 뒤집어 숨김↔보임 토글
            bool currentVisible = (udaVisible.ContainsKey(value) == false) || udaVisible[value];
            bool nextVisible = !currentVisible;

            vizcore3dx.Object3D.Show(nodes, nextVisible);
            udaVisible[value] = nextVisible;

            Log(string.Format("[UDA] {0}={1} : {2}개 → {3}",
                UDA_KEY, value, nodes.Count, nextVisible ? "보임" : "숨김"));
        }

        /// <summary>
        /// 현재 모델의 전체 노드 상태(+마크업)를 .vizxs 파일로 저장한다.
        /// </summary>
        private void btnExportStatus_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string path = textBox1.Text;
            if (string.IsNullOrEmpty(path)) return;

            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));

                System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

                // 압축 기본값은 None(무압축·가장 빠름). 보관/전송이 잦으면 Fast/Best 권장.
                vizcore3dx.Model.ExportNodeStatus(path, cbIncludeMarkup.Checked);

                sw.Stop();

                long size = System.IO.File.Exists(path) ? new System.IO.FileInfo(path).Length : 0;
                Log(string.Format("[Export] {0}", path));
                Log(string.Format("         {0:N0} bytes ({1:N1} MB) / {2} ms / Markup={3}",
                    size, size / 1024.0 / 1024.0, sw.ElapsedMilliseconds, cbIncludeMarkup.Checked));
            }
            catch (Exception ex)
            {
                Log("[Export] 실패 : " + ex.Message);
            }
        }

        /// <summary>
        /// 저장된 상태 파일과 현재 모델을 비교(CompareNodeStatus)하여 결과를 적용한다.
        ///   Added   : 파일에 없고 현재 모델에만 있는 노드 → 색상 강조
        ///   Changed : 양쪽에 있으나 상태가 다른 노드 → 파일 시점의 가시성/선택으로 복원
        ///   Deleted : 파일에만 있는 노드(현재 모델엔 없음) → 적용 대상 아님, 경로만 기록
        ///   Include Markup 체크 시 파일의 마크업도 현재 모델에 복원
        /// </summary>
        private void btnImportStatus_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string path = textBox1.Text;
            if (System.IO.File.Exists(path) == false)
            {
                Log("[Import] 파일이 없습니다 : " + path);
                return;
            }

            NodeStatusDiff diff = vizcore3dx.Model.CompareNodeStatus(path, cbIncludeMarkup.Checked);
            if (diff == null)
            {
                Log("[Import] 비교 실패 (모델 없음 또는 포맷 불일치)");
                return;
            }

            Log(string.Format("[Compare] 추가={0} / 삭제={1} / 변경={2}",
                diff.Added.Count, diff.Deleted.Count, diff.Changed.Count));

            vizcore3dx.BeginUpdate();
            try
            {
                // Added: (EntityID, Index) 핸들로 벌크 조회 후 색상 강조.
                // 색은 선택(Select) 강조색과 겹치지 않도록 DodgerBlue 사용. (원하는 색으로 변경 가능)
                List<(int, int)> addedEntries = new List<(int, int)>();
                foreach (NodeStatusItem item in diff.Added)
                    addedEntries.Add((item.EntityID, item.Index));

                List<Node> addedNodes = vizcore3dx.Object3D.GetNodes(addedEntries);
                // SetColor/Show/Select 는 빈 리스트에 예외를 던지므로 Count>0 가드 필수.
                if (addedNodes.Count > 0)
                    vizcore3dx.Object3D.Color.SetColor(addedNodes, Color.DodgerBlue);

                // Changed: 항목의 Visible/Selected 는 "파일 시점(이전) 값"이므로 그대로 적용하면 복원이 된다.
                List<(int, int)> showOn = new List<(int, int)>();
                List<(int, int)> showOff = new List<(int, int)>();
                List<(int, int)> selectOn = new List<(int, int)>();
                foreach (NodeStatusItem item in diff.Changed)
                {
                    if (item.Visible) showOn.Add((item.EntityID, item.Index));
                    else showOff.Add((item.EntityID, item.Index));

                    if (item.Selected) selectOn.Add((item.EntityID, item.Index));
                }

                List<Node> showOnNodes = vizcore3dx.Object3D.GetNodes(showOn);
                List<Node> showOffNodes = vizcore3dx.Object3D.GetNodes(showOff);
                List<Node> selectOnNodes = vizcore3dx.Object3D.GetNodes(selectOn);

                if (showOnNodes.Count > 0) vizcore3dx.Object3D.Show(showOnNodes, true);
                if (showOffNodes.Count > 0) vizcore3dx.Object3D.Show(showOffNodes, false);
                if (selectOnNodes.Count > 0) vizcore3dx.Object3D.Select(selectOnNodes, true);

                Log(string.Format("[Apply] 강조={0} / 보임={1} / 숨김={2} / 선택={3} / Markup={4}",
                    addedNodes.Count, showOnNodes.Count, showOffNodes.Count, selectOnNodes.Count, cbIncludeMarkup.Checked));
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            // Deleted 는 현재 모델에 없으므로(EntityID/Index = -1) 적용하지 않고 경로만 기록한다.
            foreach (NodeStatusItem item in diff.Deleted)
                Log("[삭제됨] " + item.Path);
        }
    }
}
