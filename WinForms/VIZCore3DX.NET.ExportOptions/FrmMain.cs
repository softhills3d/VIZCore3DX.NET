using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.ExportOptions
{
    public partial class FrmMain : Form
    {
        // 파일 형식
        private enum ExportFormat { VIZX, VIZ, STL_ASCII, STL_BINARY, OBJ }

        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;
        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            // license 인증
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            InitializeOptionUI();
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("127.0.0.1", 8901);

            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeVIZCore3DX();
        }

        private void InitializeVIZCore3DX()
        {
            vizcore3dx.BeginUpdate();

            // 리본 UI 에서 단면·선택상자 탭만 남깁니다. (상자를 직접 만들고 편집할 수 있도록)
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs(VIZCore3DX.NET.Data.ToolbarKind.Section, VIZCore3DX.NET.Data.ToolbarKind.SelectionBox);
            ShowAttributeTabs();

            // 모델 트리는 처음에 숨김
            vizcore3dx.ModelTreeVisible = false;

            vizcore3dx.EndUpdate();

            // 상자·프레임 목록은 리본 탭에서 바뀌어도 반영되도록 주기적으로 확인 (바뀐 경우만 갱신)
            Timer tmrSync = new Timer();
            tmrSync.Interval = 500;
            tmrSync.Tick += (s, e) => SyncLists();
            tmrSync.Start();

            // 모델을 닫거나 새로 열면 프레임 선택을 비움
            vizcore3dx.Model.OnModelClosedEvent += (s, e) => BeginInvoke(new Action(ClearFrameCombos));
            vizcore3dx.Model.OnModelOpenedEvent += (s, e) => BeginInvoke(new Action(ClearFrameCombos));

            // STL / OBJ 내보내기의 전제 조건 (모델 열기 전에 설정)
            vizcore3dx.Model.EnableBody = true;
        }

        // 콤보박스 / 체크박스 초기값
        private void InitializeOptionUI()
        {
            cmbFormat.DataSource = Enum.GetValues(typeof(ExportFormat));
            cmbSearchOption.DataSource = Enum.GetValues(typeof(BoundBoxSearchOption));

            // OBJ 옵션 기본값은 ObjExportOption 생성 시 값 사용
            ObjExportOption option = new ObjExportOption();
            cmbVertexColor.DataSource = Enum.GetValues(typeof(ObjVertexColorMode));
            cmbVertexColor.SelectedItem = option.VertexColor;
            cmbMaterialGrouping.DataSource = Enum.GetValues(typeof(ObjMaterialGrouping));
            cmbMaterialGrouping.SelectedItem = option.MaterialGrouping;
            chkIncludeNormals.Checked = option.IncludeNormals;
            chkIncludeGroups.Checked = option.IncludeGroups;

            UpdateObjOptionUI();
            UpdateSourceUI();
        }

        // OBJ 옵션은 OBJ 형식일 때만 사용
        private void cmbFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateObjOptionUI();
        }

        private void UpdateObjOptionUI()
        {
            bool isObj = cmbFormat.SelectedItem != null && (ExportFormat)cmbFormat.SelectedItem == ExportFormat.OBJ;
            cmbVertexColor.Enabled = cmbMaterialGrouping.Enabled = chkIncludeNormals.Enabled = chkIncludeGroups.Enabled = isObj;
        }

        // ================================================================
        // 선택상자 / 단면상자 목록
        // ================================================================
        private void RefreshBoxList()
        {
            RefreshSelectionBoxCombo();
            RefreshSectionCombo();
            SyncFrames();
        }

        // 상자 / 프레임 목록이 바뀐 경우에만 콤보박스를 다시 채움
        private string boxSignature, sectionSignature, frameSignature;

        private void SyncLists()
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string box = string.Join(",", vizcore3dx.SelectionBox.Items.Select(b => b.ID + b.Title));
            if (box != boxSignature) RefreshSelectionBoxCombo();

            string section = string.Join(",", GetSectionBoxes().Select(s => s.ID + s.Title));
            if (section != sectionSignature) RefreshSectionCombo();

            SyncFrames(false);
        }

        // 콤보박스를 열 때도 목록을 다시 읽음
        private void cmbSelectionBox_DropDown(object sender, EventArgs e)
        {
            RefreshSelectionBoxCombo();
        }

        private void cmbSection_DropDown(object sender, EventArgs e)
        {
            RefreshSectionCombo();
        }

        private void RefreshSelectionBoxCombo()
        {
            boxSignature = string.Join(",", vizcore3dx.SelectionBox.Items.Select(b => b.ID + b.Title));
            FillCombo(cmbSelectionBox, vizcore3dx.SelectionBox.Items.ToList(), b => b.ID);
        }

        private void RefreshSectionCombo()
        {
            sectionSignature = string.Join(",", GetSectionBoxes().Select(s => s.ID + s.Title));
            FillCombo(cmbSection, GetSectionBoxes(), s => s.ID);
        }

        // 상자 모양의 단면만 (평면 단면, 인박스는 BoundBox 가 없음)
        private List<SectionItem> GetSectionBoxes()
        {
            return vizcore3dx.Section.Sections.Where(s => s.IsValid && s.SectionType == VIZCore3DX.NET.Manager.SectionManager.SectionTypes.SECTION_BOX).ToList();
        }

        // 목록을 다시 채우되, 선택했던 항목(ID 기준)은 유지
        private void FillCombo<T>(ComboBox combo, List<T> items, Func<T, long> getId)
        {
            long selectedId = combo.SelectedItem is T ? getId((T)combo.SelectedItem) : -1;

            combo.DisplayMember = "Title";
            combo.Items.Clear();
            foreach (T item in items) combo.Items.Add(item);

            int index = items.FindIndex(i => getId(i) == selectedId);
            combo.SelectedIndex = index >= 0 ? index : (items.Count > 0 ? 0 : -1);
        }

        // ================================================================
        // 프레임 : 프레임 파일 열기 / 축별 프레임 라인 범위
        // ================================================================
        private void btnOpenAM_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Frame.OpenAMFileDialog()) SyncFrames();
        }

        private void btnOpenTribon_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Frame.OpenTribonFileDialog()) SyncFrames();
        }

        private void cmbFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFrameLineCombos();
        }

        private string GetFrameSignature()
        {
            return string.Join(",", vizcore3dx.Frame.Frames.Select(f => f.ID + ":" + string.Join("/", new[] { f.XAxis, f.YAxis, f.ZAxis }.Select(a => a == null ? 0 : a.GetFrameLines().Count))));
        }

        // 프레임 목록이 바뀐 경우(force 이면 항상) 프레임 콤보박스를 다시 채움
        private void SyncFrames(bool force = true)
        {
            string signature = GetFrameSignature();
            if (force == false && signature == frameSignature) return;

            frameSignature = signature;
            cmbFrame.DataSource = vizcore3dx.Frame.Frames.ToList();
            FillFrameLineCombos();
        }

        // 모델을 닫거나 새로 열 때 프레임 선택(프레임, X / Y / Z 범위)을 비움
        private void ClearFrameCombos()
        {
            frameSignature = GetFrameSignature();
            cmbFrame.DataSource = null;
            FillFrameLineCombos();
        }

        // 축별 프레임 라인(원점 기준 거리 순)
        private List<FrameLine> GetFrameLines(FrameAxisItem axis)
        {
            return axis.GetFrameLines().OrderBy(l => l.Offset).ToList();
        }

        // 선택한 프레임의 X / Y / Z 프레임 라인을 From / To 콤보박스에 채움 (0번 항목 = 제한 없음, 프레임이 없으면 빈 목록)
        private void FillFrameLineCombos()
        {
            FrameItem frame = cmbFrame.SelectedItem as FrameItem;
            FrameAxisItem[] axes = frame == null ? new FrameAxisItem[3] : new FrameAxisItem[] { frame.XAxis, frame.YAxis, frame.ZAxis };
            ComboBox[][] combos = { new[] { cmbFrameXFrom, cmbFrameXTo }, new[] { cmbFrameYFrom, cmbFrameYTo }, new[] { cmbFrameZFrom, cmbFrameZTo } };

            for (int i = 0; i < 3; i++)
            {
                List<string> items = new List<string>();
                if (axes[i] != null)
                {
                    items.Add("(제한 없음)");
                    items.AddRange(GetFrameLines(axes[i]).Select(l => string.Format("{0:N0}  {1}", l.Offset, string.IsNullOrWhiteSpace(l.CustomLabel) ? "#" + l.ID : l.CustomLabel.Trim())));
                }

                foreach (ComboBox combo in combos[i])
                {
                    combo.DataSource = new List<string>(items);
                    combo.SelectedIndex = items.Count > 0 ? 0 : -1;
                }
            }
        }

        // 프레임 라인으로 지정한 범위 (제한 없는 축은 모델 전체 범위)
        private BoundBox3D GetFrameRange()
        {
            FrameItem frame = cmbFrame.SelectedItem as FrameItem;
            if (frame == null) return null;

            BoundBox3D model = vizcore3dx.Model.BoundBox;
            float[] min = { model.MinX, model.MinY, model.MinZ };
            float[] max = { model.MaxX, model.MaxY, model.MaxZ };
            FrameAxisItem[] axes = { frame.XAxis, frame.YAxis, frame.ZAxis };
            ComboBox[] from = { cmbFrameXFrom, cmbFrameYFrom, cmbFrameZFrom };
            ComboBox[] to = { cmbFrameXTo, cmbFrameYTo, cmbFrameZTo };

            for (int i = 0; i < 3; i++)
            {
                List<FrameLine> lines = GetFrameLines(axes[i]);
                if (from[i].SelectedIndex > 0) min[i] = lines[from[i].SelectedIndex - 1].Offset;
                if (to[i].SelectedIndex > 0) max[i] = lines[to[i].SelectedIndex - 1].Offset;
                if (min[i] > max[i]) { float tmp = min[i]; min[i] = max[i]; max[i] = tmp; }
            }

            return new BoundBox3D(min, max);
        }

        // ================================================================
        // 내보내기 대상에 해당하지 않는 설정은 비활성화
        // ================================================================
        private void rdoSource_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSourceUI();
        }

        private void UpdateSourceUI()
        {
            bool selectionBox = rdoSelectionBox.Checked;
            bool sectionBox = rdoSectionBox.Checked;
            bool frame = rdoFrame.Checked;
            bool range = selectionBox || sectionBox || frame;

            lblSelectionBox.Enabled = cmbSelectionBox.Enabled = btnAddSelectionBox.Enabled = selectionBox;
            lblSection.Enabled = cmbSection.Enabled = btnAddSection.Enabled = sectionBox;
            lblSearchOption.Enabled = cmbSearchOption.Enabled = btnRefresh.Enabled = chkVisibleOnly.Enabled = chkCut.Enabled = range;

            // 프레임 설정(버튼 포함)은 프레임 대상일 때만 사용
            foreach (Control control in new Control[] { lblFrame, cmbFrame, btnOpenAM, btnOpenTribon,
                lblFrameX, cmbFrameXFrom, lblFrameXSep, cmbFrameXTo, lblFrameY, cmbFrameYFrom, lblFrameYSep, cmbFrameYTo, lblFrameZ, cmbFrameZFrom, lblFrameZSep, cmbFrameZTo })
                control.Enabled = frame;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshBoxList();
        }

        // 선택한 노드 영역으로 선택상자 추가
        private void btnAddSelectionBox_Click(object sender, EventArgs e)
        {
            BoundBox3D box = GetSelectedNodesBoundBox();
            if (box == null) return;

            // 이름 : Selection Box 1, 2, 3 ... (이미 있는 이름은 건너뜀)
            int number = vizcore3dx.SelectionBox.Items.Count + 1;
            while (vizcore3dx.SelectionBox.Items.Any(b => b.Title == "Selection Box " + number)) number++;

            vizcore3dx.SelectionBox.Add(box, "Selection Box " + number);
            RefreshBoxList();
        }

        // 선택한 노드 영역으로 단면상자 추가
        private void btnAddSection_Click(object sender, EventArgs e)
        {
            BoundBox3D box = GetSelectedNodesBoundBox();
            if (box == null) return;

            vizcore3dx.Section.AddBox(box);
            RefreshBoxList();
        }

        private BoundBox3D GetSelectedNodesBoundBox()
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 로드해 주세요.", "VIZCore3DX.NET.ExportOptions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            List<Node> nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP);
            if (nodes == null || nodes.Count == 0)
            {
                MessageBox.Show("노드를 선택해 주세요. (리본 탭에서 직접 상자를 만들 수도 있습니다.)", "VIZCore3DX.NET.ExportOptions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            return vizcore3dx.Object3D.GetBoundBox(nodes);
        }

        // ================================================================
        // 내보내기
        // ================================================================
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 로드해 주세요.", "VIZCore3DX.NET.ExportOptions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ExportFormat format = (ExportFormat)cmbFormat.SelectedItem;

            // 대상 범위 : 상자·프레임 기준이 아니면 ExportOption, 맞으면 노드 목록으로 지정
            ExportOption option = ExportOption.ALL;
            List<Node> nodes = null;

            if (rdoVisible.Checked) option = ExportOption.VISIBLE;
            else if (rdoRendered.Checked) option = ExportOption.RENDERED;
            else if (rdoSelected.Checked) option = ExportOption.SELECTED;
            else if (rdoSelectionBox.Checked || rdoSectionBox.Checked) nodes = GetNodesInRange(GetBoxRange()) ?? new List<Node>();
            else if (rdoFrame.Checked) nodes = GetNodesInRange(GetFrameRange()) ?? new List<Node>();

            // 대상이 없으면 중단 (상자 미선택 / 상자 안에 개체 없음)
            if (nodes != null && nodes.Count == 0)
            {
                MessageBox.Show("상자·프레임을 선택하거나, 범위 안에 내보낼 개체가 없습니다.", "VIZCore3DX.NET.ExportOptions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = GetFileFilter(format);
            if (dlg.ShowDialog() != DialogResult.OK) return;

            // STL / OBJ 는 EnableBody 가 false 이거나 내보낼 메시가 없으면 예외 발생
            bool result;
            try
            {
                result = Export(dlg.FileName, format, option, nodes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("내보내기 실패\n\n사유 : {0}", ex.Message), "VIZCore3DX.NET.ExportOptions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (result == false || File.Exists(dlg.FileName) == false)
            {
                OperationStatus status = vizcore3dx.Model.LastOperationStatus;
                MessageBox.Show(string.Format("내보내기 실패\n\n사유 : {0}", status == null ? "알 수 없음" : status.ToString()), "VIZCore3DX.NET.ExportOptions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(string.Format("내보내기 완료\n\n파일 : {0}", dlg.FileName), "VIZCore3DX.NET.ExportOptions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 선택상자 / 단면상자의 범위
        private BoundBox3D GetBoxRange()
        {
            if (rdoSelectionBox.Checked)
            {
                VIZCore3DX.NET.Data.SelectionBox box = cmbSelectionBox.SelectedItem as VIZCore3DX.NET.Data.SelectionBox;
                return box == null ? null : box.BoundBox;
            }

            SectionItem section = cmbSection.SelectedItem as SectionItem;
            return section == null ? null : section.BoundBox;
        }

        // 범위 안에 포함된 파트 노드. 자르기를 켜면 범위 경계로 형상을 먼저 나눈 뒤, 범위 안의 조각만 대상으로 함
        private List<Node> GetNodesInRange(BoundBox3D range)
        {
            if (range == null) return null;

            BoundBoxSearchOption search = (BoundBoxSearchOption)cmbSearchOption.SelectedItem;
            if (chkCut.Checked)
            {
                vizcore3dx.Object3D.SplitMesh(range);
                search = BoundBoxSearchOption.FullyContained;
            }

            return vizcore3dx.Object3D.FromZone(range, search, chkVisibleOnly.Checked, true);
        }

        // 형식별 내보내기 : 노드 목록이 있으면 노드 목록 기준, 없으면 ExportOption 기준
        private bool Export(string path, ExportFormat format, ExportOption option, List<Node> nodes)
        {
            switch (format)
            {
                case ExportFormat.VIZX:
                    return nodes == null ? vizcore3dx.Model.ExportVIZX(path, option) : vizcore3dx.Model.ExportVIZX(path, nodes);

                case ExportFormat.VIZ:
                    return nodes == null ? vizcore3dx.Model.ExportVIZ(path, option) : vizcore3dx.Model.ExportVIZ(path, nodes);

                case ExportFormat.STL_ASCII:
                case ExportFormat.STL_BINARY:
                    bool ascii = format == ExportFormat.STL_ASCII;
                    if (nodes == null) vizcore3dx.Model.ExportStl(path, option, ascii);
                    else vizcore3dx.Model.ExportStl(path, nodes, ascii);
                    return true;

                default:
                    // ObjExportOption 은 노드 목록과 함께 사용 (ExportOption 범위는 노드 목록으로 변환)
                    // RENDERED 는 대응하는 노드 목록이 없어 OBJ 옵션 없이 내보냄 (ExportObj(path, ExportOption, ObjExportOption) 미제공)
                    if (nodes == null && option == ExportOption.RENDERED)
                    {
                        vizcore3dx.Model.ExportObj(path, option, true);
                        return true;
                    }
                    if (nodes == null) nodes = vizcore3dx.Object3D.FromFilter(option == ExportOption.VISIBLE ? Object3dFilter.VISIBLE_PART : option == ExportOption.SELECTED ? Object3dFilter.SELECTED_PART : Object3dFilter.PART);

                    ObjExportOption obj = new ObjExportOption();
                    obj.VertexColor = (ObjVertexColorMode)cmbVertexColor.SelectedItem;
                    obj.MaterialGrouping = (ObjMaterialGrouping)cmbMaterialGrouping.SelectedItem;
                    obj.IncludeNormals = chkIncludeNormals.Checked;
                    obj.IncludeGroups = chkIncludeGroups.Checked;
                    vizcore3dx.Model.ExportObj(path, nodes, obj);
                    return true;
            }
        }

        private string GetFileFilter(ExportFormat format)
        {
            switch (format)
            {
                case ExportFormat.VIZX: return "VIZX (*.vizx)|*.vizx";
                case ExportFormat.VIZ: return "VIZ (*.viz)|*.viz";
                case ExportFormat.OBJ: return "OBJ (*.obj)|*.obj";
                default: return "STL (*.stl)|*.stl";
            }
        }

        // 지정한 탭만 남기고 나머지 툴바(=리본 탭)와 모델 트리 패널의 같은 탭을 숨깁니다. 홈 탭·모델 트리는 항상 표시합니다.
        private void ShowRibbonTabs(params VIZCore3DX.NET.Data.ToolbarKind[] keep)
        {
            foreach (VIZCore3DX.NET.Data.ToolbarKind kind in Enum.GetValues(typeof(VIZCore3DX.NET.Data.ToolbarKind)))
                vizcore3dx.Toolbar.SetVisible(kind, kind == VIZCore3DX.NET.Data.ToolbarKind.Main || Array.IndexOf(keep, kind) >= 0);

            // 남길 탭은 먼저 켜고(설정 파일로 꺼져 있을 수 있음), 그 다음 모델 트리를 뺀 나머지를 끕니다. 내장 탭 이름은 "tabPage" + 툴바 종류입니다.
            foreach (VIZCore3DX.NET.Data.ToolbarKind kind in keep)
                vizcore3dx.Panel.SetTabVisible(VIZCore3DX.NET.Data.PanelKind.ModelTree, "tabPage" + kind, true);

            foreach (string name in vizcore3dx.Panel.GetTabNames(VIZCore3DX.NET.Data.PanelKind.ModelTree))
            {
                if (name == "tabPageSceneTree") continue;
                bool show = Array.Exists(keep, kind => name == "tabPage" + kind);
                vizcore3dx.Panel.SetTabVisible(VIZCore3DX.NET.Data.PanelKind.ModelTree, name, show);
            }
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
