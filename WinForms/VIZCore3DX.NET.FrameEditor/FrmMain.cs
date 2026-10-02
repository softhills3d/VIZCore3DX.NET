using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.FrameEditor
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 프레임 목록 (cmbFrame 항목과 같은 순서)
        private List<int> frameIDs = new List<int>();

        // 컨트롤 값 로딩 중에는 변경 이벤트를 무시
        private bool loading = false;

        public FrmMain()
        {
            InitializeComponent();
            InitializeControls();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            // license 인증
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            // 모델이 열리거나 닫히면 프레임 초기화
            vizcore3dx.Model.OnModelOpenedEvent += Model_OnModelOpenedEvent;
            vizcore3dx.Model.OnModelClosedEvent += Model_OnModelClosedEvent;
        }

        private void Model_OnModelOpenedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ModelOpendEventArgs e)
        {
            ResetFrames();
        }

        private void Model_OnModelClosedEvent(object sender, EventArgs e)
        {
            ResetFrames();
        }

        private void ResetFrames()
        {
            vizcore3dx.Frame.Clear();
            RefreshFrameList();
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
            ShowRibbonTabs();
            ShowAttributeTabs();

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }

        private void btnModelOpen_Click(object sender, EventArgs e)
        {
            vizcore3dx.Model.OpenFileDialog();
        }

        // ================================================================
        // 초기화 - 콤보박스 / 이벤트 연결
        // ================================================================
        private void InitializeControls()
        {
            FillCombo(cmbSpaceMode, typeof(FrameSpaceMode));
            FillCombo(cmbMarginType, typeof(FrameMarginType));
            FillCombo(cmbPlanePattern, typeof(StrokePattern));
            FillCombo(cmbStrokePattern, typeof(StrokePattern));
            FillCombo(cmbLabelType, typeof(FrameLineLabelType));
            FillCombo(cmbLineAxis, typeof(Axis));

            // All Axis 적용 방식: 축 범위 비율 유지 / 같은 Offset 그대로
            cmbAllAxisMode.Items.AddRange(new object[] { "Proportional", "Same Offset" });
            cmbAllAxisMode.SelectedIndex = 0;
            cmbAllAxisMode.Enabled = false;
            chkAllAxis.CheckedChanged += delegate { cmbAllAxisMode.Enabled = chkAllAxis.Checked; };

            cmbFrame.SelectedIndexChanged += cmbFrame_SelectedIndexChanged;
            chkVisible.CheckedChanged += chkVisible_CheckedChanged;
            rdoAxisX.CheckedChanged += rdoAxis_CheckedChanged;
            rdoAxisY.CheckedChanged += rdoAxis_CheckedChanged;
            rdoAxisZ.CheckedChanged += rdoAxis_CheckedChanged;
            cmbLineAxis.SelectedIndexChanged += cmbLineAxis_SelectedIndexChanged;

            SetEditable(false);
        }

        private void FillCombo(ComboBox combo, Type enumType)
        {
            foreach (object value in Enum.GetValues(enumType))
                combo.Items.Add(value);
            if (combo.Items.Count > 0)
                combo.SelectedIndex = 0;
        }

        // ================================================================
        // Frame - 목록 / 생성 / 가져오기 / 내보내기
        // ================================================================
        private FrameItem CurrentFrame
        {
            get
            {
                int index = cmbFrame.SelectedIndex;
                if (index < 0 || index >= frameIDs.Count) return null;
                return vizcore3dx.Frame.GetFrame(frameIDs[index]);
            }
        }

        // 프레임 목록을 다시 채우고, selectID 프레임(없으면 첫 번째)을 선택합니다.
        private void RefreshFrameList(int selectID = -1)
        {
            loading = true;

            frameIDs.Clear();
            cmbFrame.Items.Clear();

            foreach (FrameItem frame in vizcore3dx.Frame.Frames)
            {
                if (frame == null || frame.IsValid == false || frame.IsDeleted == true) continue;

                frameIDs.Add(frame.ID);
                // DLL의 ID는 건너뛰므로 화면에는 순번을 표시
                cmbFrame.Items.Add(string.Format("Frame {0}", frameIDs.Count));
            }

            int select = frameIDs.FindIndex(id => id == selectID);
            if (select < 0 && frameIDs.Count > 0) select = 0;
            cmbFrame.SelectedIndex = select;

            loading = false;

            LoadFrame();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // CreateFrame()이 반환하는 객체는 Frames 목록에 들어가는 프레임과 ID가 달라서(반환 18 → 목록 17),
            // 생성 전후 목록을 비교해 실제로 추가된 프레임을 찾아 사용합니다.
            List<int> beforeIDs = new List<int>();
            foreach (FrameItem item in vizcore3dx.Frame.Frames)
                beforeIDs.Add(item.ID);

            FrameItem created = vizcore3dx.Frame.CreateFrame();
            if (created == null)
            {
                MessageBox.Show("Frame을 생성할 수 없습니다.");
                return;
            }

            FrameItem frame = created;
            foreach (FrameItem item in vizcore3dx.Frame.Frames)
            {
                if (beforeIDs.Contains(item.ID) == false)
                {
                    frame = item;
                    break;
                }
            }

            InitializeFrameFromModel(frame);

            vizcore3dx.Frame.Visible = true;
            vizcore3dx.Frame.ReDraw();

            RefreshFrameList(frame.ID);
        }

        // 열려 있는 모델의 BoundBox로 Space를 정하고, 각 축에 균등 간격 라인을 만듭니다.
        private void InitializeFrameFromModel(FrameItem frame)
        {
            BoundBox3D box = vizcore3dx.Model.BoundBox;
            if (box == null || box.IsValid() == false) return;

            vizcore3dx.BeginUpdate();

            frame.FrameSpace = new BoundBox3D(box.MinX, box.MinY, box.MinZ, box.MaxX, box.MaxY, box.MaxZ);

            SetEvenLines(frame.XAxis, box.MinX, box.MaxX);
            SetEvenLines(frame.YAxis, box.MinY, box.MaxY);
            SetEvenLines(frame.ZAxis, box.MinZ, box.MaxZ);

            vizcore3dx.EndUpdate();
        }

        private void SetEvenLines(FrameAxisItem axisItem, float min, float max)
        {
            if (axisItem == null || axisItem.IsValid == false) return;

            int division = (int)numDivision.Value;

            List<FrameLine> lines = new List<FrameLine>();
            for (int i = 0; i <= division; i++)
            {
                FrameLine line = new FrameLine();
                line.ID = i + 1;
                line.Offset = min + (max - min) * i / division;
                lines.Add(line);
            }

            axisItem.SetFrameLines(lines);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files (*.*)|*.*";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            if (vizcore3dx.Frame.Import(dlg.FileName) == false)
            {
                MessageBox.Show("Frame 파일을 불러올 수 없습니다.\n(" + vizcore3dx.Frame.LastOperationResult + ")");
                return;
            }

            vizcore3dx.Frame.Visible = true;
            vizcore3dx.Frame.ReDraw();

            RefreshFrameList();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files (*.*)|*.*";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            if (vizcore3dx.Frame.Export(dlg.FileName) == false)
                MessageBox.Show("Frame을 내보낼 수 없습니다.");
        }

        private void cmbFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading == true) return;

            LoadFrame();
        }

        private void chkVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (loading == true) return;

            FrameItem frame = CurrentFrame;
            if (frame == null) return;

            frame.IsVisible = chkVisible.Checked;
            vizcore3dx.Frame.ReDraw();
        }

        // 선택한 프레임의 모든 설정을 화면에 불러옵니다.
        private void LoadFrame()
        {
            FrameItem frame = CurrentFrame;
            SetEditable(frame != null);
            if (frame == null)
            {
                dgvLine.Rows.Clear();
                return;
            }

            loading = true;

            chkVisible.Checked = frame.IsVisible;

            cmbSpaceMode.SelectedItem = frame.FrameSpaceMode;
            cmbMarginType.SelectedItem = frame.MarginType;

            BoundBox3D space = frame.FrameSpace;
            if (space != null)
            {
                SetValue(numMinX, space.MinX); SetValue(numMinY, space.MinY); SetValue(numMinZ, space.MinZ);
                SetValue(numMaxX, space.MaxX); SetValue(numMaxY, space.MaxY); SetValue(numMaxZ, space.MaxZ);
            }

            SetValue(numMarginX, frame.XMargin);
            SetValue(numMarginY, frame.YMargin);
            SetValue(numMarginZ, frame.ZMargin);

            chkXY.Checked = frame.IsXYPlaneEnabled;
            chkYZ.Checked = frame.IsYZPlaneEnabled;
            chkZX.Checked = frame.IsZXPlaneEnabled;
            btnPlaneColor.BackColor = frame.PlaneStrokeColor;
            cmbPlanePattern.SelectedItem = frame.PlaneStrokePattern;
            SetValue(numPlaneThickness, frame.PlaneStrokeThickness);

            loading = false;

            LoadAxis();
            LoadLines();
        }

        // ================================================================
        // Frame 탭 - 공간 / 여백 / 평면
        // ================================================================
        private void btnApplyFrame_Click(object sender, EventArgs e)
        {
            FrameItem frame = CurrentFrame;
            if (frame == null) return;

            if (numMaxX.Value <= numMinX.Value || numMaxY.Value <= numMinY.Value || numMaxZ.Value <= numMinZ.Value)
            {
                MessageBox.Show("Space Max는 Space Min보다 커야 합니다.");
                return;
            }

            FrameMarginType marginType = (FrameMarginType)cmbMarginType.SelectedItem;
            if (marginType == FrameMarginType.Ratio &&
                (numMarginX.Value > 1 || numMarginY.Value > 1 || numMarginZ.Value > 1))
            {
                MessageBox.Show("Ratio 여백은 0.0 ~ 1.0 범위여야 합니다.");
                return;
            }

            vizcore3dx.BeginUpdate();

            frame.FrameSpaceMode = (FrameSpaceMode)cmbSpaceMode.SelectedItem;
            frame.FrameSpace = new BoundBox3D(
                (float)numMinX.Value, (float)numMinY.Value, (float)numMinZ.Value,
                (float)numMaxX.Value, (float)numMaxY.Value, (float)numMaxZ.Value);

            frame.MarginType = marginType;
            frame.XMargin = (float)numMarginX.Value;
            frame.YMargin = (float)numMarginY.Value;
            frame.ZMargin = (float)numMarginZ.Value;

            frame.IsXYPlaneEnabled = chkXY.Checked;
            frame.IsYZPlaneEnabled = chkYZ.Checked;
            frame.IsZXPlaneEnabled = chkZX.Checked;
            frame.PlaneStrokeColor = btnPlaneColor.BackColor;
            frame.PlaneStrokePattern = (StrokePattern)cmbPlanePattern.SelectedItem;
            frame.PlaneStrokeThickness = (float)numPlaneThickness.Value;

            vizcore3dx.EndUpdate();
            vizcore3dx.Frame.ReDraw();
        }

        private void btnPlaneColor_Click(object sender, EventArgs e)
        {
            PickColor(btnPlaneColor);
        }

        // ================================================================
        // Axis 탭 - 축 옵션
        // ================================================================
        private Axis SelectedAxis
        {
            get
            {
                if (rdoAxisY.Checked == true) return Axis.Y;
                if (rdoAxisZ.Checked == true) return Axis.Z;
                return Axis.X;
            }
        }

        private FrameAxisItem GetAxisItem(FrameItem frame, Axis axis)
        {
            if (frame == null) return null;
            if (axis == Axis.X) return frame.XAxis;
            if (axis == Axis.Y) return frame.YAxis;
            return frame.ZAxis;
        }

        private void rdoAxis_CheckedChanged(object sender, EventArgs e)
        {
            if (loading == true) return;
            if (((RadioButton)sender).Checked == false) return;

            LoadAxis();
        }

        private void LoadAxis()
        {
            FrameAxisItem axisItem = GetAxisItem(CurrentFrame, SelectedAxis);
            if (axisItem == null || axisItem.IsValid == false) return;

            bool prev = loading;
            loading = true;

            txtAxisLabel.Text = axisItem.Label;
            chkLineEnabled.Checked = axisItem.IsFrameLineEnabled;
            cmbLabelType.SelectedItem = axisItem.FrameLineLabelType;
            btnTextColor.BackColor = axisItem.FrameLineLabelTextColor;
            btnStrokeColor.BackColor = axisItem.FrameLineStrokeColor;
            cmbStrokePattern.SelectedItem = axisItem.FrameLineStrokePattern;
            SetValue(numStrokeThickness, axisItem.FrameLineStrokeThickness);

            loading = prev;
        }

        private void btnApplyAxis_Click(object sender, EventArgs e)
        {
            FrameAxisItem axisItem = GetAxisItem(CurrentFrame, SelectedAxis);
            if (axisItem == null || axisItem.IsValid == false) return;

            vizcore3dx.BeginUpdate();

            axisItem.Label = txtAxisLabel.Text;
            axisItem.IsFrameLineEnabled = chkLineEnabled.Checked;
            axisItem.FrameLineLabelType = (FrameLineLabelType)cmbLabelType.SelectedItem;
            axisItem.FrameLineLabelTextColor = btnTextColor.BackColor;
            axisItem.FrameLineStrokeColor = btnStrokeColor.BackColor;
            axisItem.FrameLineStrokePattern = (StrokePattern)cmbStrokePattern.SelectedItem;
            axisItem.FrameLineStrokeThickness = (float)numStrokeThickness.Value;

            vizcore3dx.EndUpdate();
            vizcore3dx.Frame.ReDraw();
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            PickColor(btnTextColor);
        }

        private void btnStrokeColor_Click(object sender, EventArgs e)
        {
            PickColor(btnStrokeColor);
        }

        // ================================================================
        // Line 탭 - 프레임 라인
        // ================================================================
        private Axis SelectedLineAxis
        {
            get { return cmbLineAxis.SelectedItem is Axis ? (Axis)cmbLineAxis.SelectedItem : Axis.X; }
        }

        private void cmbLineAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading == true) return;

            LoadLines();
        }

        private void LoadLines()
        {
            dgvLine.Rows.Clear();

            FrameAxisItem axisItem = GetAxisItem(CurrentFrame, SelectedLineAxis);
            if (axisItem == null || axisItem.IsValid == false) return;

            List<FrameLine> lines = axisItem.GetFrameLines();
            if (lines == null) return;

            foreach (FrameLine line in lines)
                dgvLine.Rows.Add(line.ID, line.Offset, line.CustomLabel);
        }

        // 선택한 축의 Space Min~Max를 numDivision 등분한 라인으로 표를 다시 채웁니다. (Apply 전까지 적용 안 됨)
        private void btnLineGenerate_Click(object sender, EventArgs e)
        {
            float min, max;
            GetSpaceRange(SelectedLineAxis, out min, out max);

            if (max <= min)
            {
                MessageBox.Show("Frame 탭의 Space Min/Max를 먼저 설정해 주세요.");
                return;
            }

            int division = (int)numDivision.Value;

            dgvLine.Rows.Clear();
            for (int i = 0; i <= division; i++)
                dgvLine.Rows.Add(i + 1, min + (max - min) * i / division, string.Empty);
        }

        private void btnLineAdd_Click(object sender, EventArgs e)
        {
            int id = 0;
            foreach (DataGridViewRow row in dgvLine.Rows)
            {
                int rowID;
                if (int.TryParse(Convert.ToString(row.Cells[colId.Index].Value), out rowID) && rowID > id)
                    id = rowID;
            }

            int index = dgvLine.Rows.Add(id + 1, (float)numNewOffset.Value, string.Empty);
            dgvLine.CurrentCell = dgvLine.Rows[index].Cells[colOffset.Index];
        }

        private void btnLineRemove_Click(object sender, EventArgs e)
        {
            if (dgvLine.CurrentRow == null) return;

            dgvLine.Rows.Remove(dgvLine.CurrentRow);
        }

        private void btnLineClear_Click(object sender, EventArgs e)
        {
            dgvLine.Rows.Clear();
        }

        private void btnApplyLine_Click(object sender, EventArgs e)
        {
            FrameItem frame = CurrentFrame;
            if (frame == null) return;

            dgvLine.EndEdit();

            List<FrameLine> lines = new List<FrameLine>();
            foreach (DataGridViewRow row in dgvLine.Rows)
            {
                int id;
                float offset;

                if (int.TryParse(Convert.ToString(row.Cells[colId.Index].Value), out id) == false ||
                    float.TryParse(Convert.ToString(row.Cells[colOffset.Index].Value), out offset) == false)
                {
                    MessageBox.Show("ID 또는 Offset 값이 올바르지 않습니다.");
                    return;
                }

                FrameLine line = new FrameLine();
                line.ID = id;
                line.Offset = offset;
                line.CustomLabel = Convert.ToString(row.Cells[colLabel.Index].Value);
                lines.Add(line);
            }

            lines.Sort((a, b) => a.Offset.CompareTo(b.Offset));

            Axis axis = SelectedLineAxis;

            // 축별로 적용할 라인 목록을 먼저 만든다. (범위가 잘못되면 아무것도 적용하지 않음)
            Dictionary<Axis, List<FrameLine>> targets = new Dictionary<Axis, List<FrameLine>>();
            if (chkAllAxis.Checked == true)
            {
                bool proportional = cmbAllAxisMode.SelectedIndex == 0;

                foreach (Axis target in new Axis[] { Axis.X, Axis.Y, Axis.Z })
                {
                    if (proportional == false || target == axis)
                    {
                        targets[target] = lines;
                        continue;
                    }

                    List<FrameLine> scaled = ScaleLines(lines, axis, target);
                    if (scaled == null)
                    {
                        MessageBox.Show("Frame 탭의 Space Min/Max를 먼저 설정해 주세요. (비율 계산에 필요)");
                        return;
                    }

                    targets[target] = scaled;
                }
            }
            else
            {
                targets[axis] = lines;
            }

            vizcore3dx.BeginUpdate();

            foreach (KeyValuePair<Axis, List<FrameLine>> pair in targets)
                SetLines(frame, pair.Key, pair.Value);

            vizcore3dx.EndUpdate();
            vizcore3dx.Frame.ReDraw();

            LoadLines();
        }

        // 표에 입력된 Space 값에서 해당 축의 Min/Max를 가져옵니다.
        private void GetSpaceRange(Axis axis, out float min, out float max)
        {
            if (axis == Axis.X) { min = (float)numMinX.Value; max = (float)numMaxX.Value; }
            else if (axis == Axis.Y) { min = (float)numMinY.Value; max = (float)numMaxY.Value; }
            else { min = (float)numMinZ.Value; max = (float)numMaxZ.Value; }
        }

        // from 축 범위 안에서의 위치 비율을 유지한 채 to 축 범위로 라인을 옮깁니다. 범위가 올바르지 않으면 null.
        private List<FrameLine> ScaleLines(List<FrameLine> lines, Axis from, Axis to)
        {
            float fromMin, fromMax, toMin, toMax;
            GetSpaceRange(from, out fromMin, out fromMax);
            GetSpaceRange(to, out toMin, out toMax);

            if (fromMax <= fromMin || toMax <= toMin) return null;

            List<FrameLine> scaled = new List<FrameLine>();
            foreach (FrameLine line in lines)
            {
                FrameLine item = new FrameLine();
                item.ID = line.ID;
                item.CustomLabel = line.CustomLabel;
                item.Offset = toMin + (line.Offset - fromMin) / (fromMax - fromMin) * (toMax - toMin);
                scaled.Add(item);
            }

            return scaled;
        }

        // 축마다 별도 객체를 사용하도록 복사해서 설정합니다.
        private void SetLines(FrameItem frame, Axis axis, List<FrameLine> lines)
        {
            FrameAxisItem axisItem = GetAxisItem(frame, axis);
            if (axisItem == null || axisItem.IsValid == false) return;

            List<FrameLine> copy = new List<FrameLine>();
            foreach (FrameLine line in lines)
            {
                FrameLine item = new FrameLine();
                item.ID = line.ID;
                item.Offset = line.Offset;
                item.CustomLabel = line.CustomLabel;
                copy.Add(item);
            }

            axisItem.SetFrameLines(copy);
        }

        // ================================================================
        // 공통
        // ================================================================
        private void SetEditable(bool enabled)
        {
            tabMain.Enabled = enabled;
            chkVisible.Enabled = enabled;
            btnExport.Enabled = enabled;
        }

        private void SetValue(NumericUpDown num, float value)
        {
            // 빈 BoundBox 등 NaN/무한대/매우 큰 값은 decimal 변환 시 오버플로우가 나므로 범위로 제한
            if (float.IsNaN(value) || float.IsInfinity(value)) value = 0f;

            double v = Math.Max((double)num.Minimum, Math.Min((double)num.Maximum, (double)value));
            num.Value = (decimal)v;
        }

        private void PickColor(Button button)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = button.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
                button.BackColor = dlg.Color;
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