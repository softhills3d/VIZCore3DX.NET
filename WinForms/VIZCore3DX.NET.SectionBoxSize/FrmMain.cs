using System;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using static VIZCore3DX.NET.Manager.SectionManager;

namespace VIZCore3DX.NET.SectionBoxSize
{
    public partial class FrmMain : Form
    {
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        public VIZCore3DX.NET.Data.SectionItem Section { get; set; }

        private bool isScroll = false;

        public FrmMain()
        {
            InitializeComponent();

            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;

            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            splitContainer1.Panel2.Controls.Add(vizcore3dx);
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

            // ================================================================
            // 설정 - 툴바
            // ================================================================

            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs(VIZCore3DX.NET.Data.ToolbarKind.Section);
            ShowAttributeTabs();

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }
        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.Section.OnSectionEvent += VIZCore3DX_OnSectionEvent;
        }

        private void VIZCore3DX_OnSectionEvent(object sender, Event.EventManager.SectionEventArgs e)
        {
            if (e.EventType == EventType.Moved)
            {
                if (isScroll)
                {

                }
                else
                {
                    BoundBox3D box = e.Section.BoundBox;

                    cbMinX.SelectedIndexChanged -= new System.EventHandler(cbMinX_SelectedIndexChanged);
                    cbMinY.SelectedIndexChanged -= new System.EventHandler(cbMinY_SelectedIndexChanged);
                    cbMinZ.SelectedIndexChanged -= new System.EventHandler(cbMinZ_SelectedIndexChanged);

                    cbMaxX.SelectedIndexChanged -= new System.EventHandler(cbMaxX_SelectedIndexChanged);
                    cbMaxY.SelectedIndexChanged -= new System.EventHandler(cbMaxY_SelectedIndexChanged);
                    cbMaxZ.SelectedIndexChanged -= new System.EventHandler(cbMaxZ_SelectedIndexChanged);

                    tbMinX.Scroll -= new System.EventHandler(tbMinX_Scroll);
                    tbMinY.Scroll -= new System.EventHandler(tbMinY_Scroll);
                    tbMinZ.Scroll -= new System.EventHandler(tbMinZ_Scroll);

                    tbMaxX.Scroll -= new System.EventHandler(tbMaxX_Scroll);
                    tbMaxY.Scroll -= new System.EventHandler(tbMaxY_Scroll);
                    tbMaxZ.Scroll -= new System.EventHandler(tbMaxZ_Scroll);

                    int MinX = Convert.ToInt32(box.MinX);
                    if (MinX < tbMinX.Minimum)
                    {
                        tbMinX.Value = tbMinX.Minimum;
                    }
                    else if (MinX > tbMinX.Maximum)
                    {
                        tbMinX.Value = tbMinX.Maximum;
                    }
                    else
                    {
                        tbMinX.Value = MinX;

                    }

                    int MaxX = Convert.ToInt32(box.MaxX);
                    if (MaxX < tbMaxX.Minimum)
                    {
                        tbMaxX.Value = tbMaxX.Minimum;
                    }
                    else if (MaxX > tbMaxX.Maximum)
                    {
                        tbMaxX.Value = tbMaxX.Maximum;
                    }
                    else
                    {
                        tbMaxX.Value = MaxX;

                    }

                    int MinY = Convert.ToInt32(box.MinY);
                    if (MinY < tbMinY.Minimum)
                    {
                        tbMinY.Value = tbMinY.Minimum;
                    }
                    else if (MinY > tbMinY.Maximum)
                    {
                        tbMinY.Value = tbMinY.Maximum;
                    }
                    else
                    {
                        tbMinY.Value = MinY;

                    }

                    int MaxY = Convert.ToInt32(box.MaxY);
                    if (MaxY < tbMaxY.Minimum)
                    {
                        tbMaxY.Value = tbMaxY.Minimum;
                    }
                    else if (MaxY > tbMaxY.Maximum)
                    {
                        tbMaxY.Value = tbMaxY.Maximum;
                    }
                    else
                    {
                        tbMaxY.Value = MaxY;

                    }

                    int MinZ = Convert.ToInt32(box.MinZ);
                    if (MinZ < tbMinZ.Minimum)
                    {
                        tbMinZ.Value = tbMinZ.Minimum;
                    }
                    else if (MinZ > tbMinZ.Maximum)
                    {
                        tbMinZ.Value = tbMinZ.Maximum;
                    }
                    else
                    {
                        tbMinZ.Value = MinZ;

                    }

                    int MaxZ = Convert.ToInt32(box.MaxZ);
                    if (MaxZ < tbMaxZ.Minimum)
                    {
                        tbMaxZ.Value = tbMaxZ.Minimum;
                    }
                    else if (MaxZ > tbMaxZ.Maximum)
                    {
                        tbMaxZ.Value = tbMaxZ.Maximum;
                    }
                    else
                    {
                        tbMaxZ.Value = MaxZ;

                    }

                    cbMinX.SelectedIndexChanged += new System.EventHandler(cbMinX_SelectedIndexChanged);
                    cbMinY.SelectedIndexChanged += new System.EventHandler(cbMinY_SelectedIndexChanged);
                    cbMinZ.SelectedIndexChanged += new System.EventHandler(cbMinZ_SelectedIndexChanged);

                    cbMaxX.SelectedIndexChanged += new System.EventHandler(cbMaxX_SelectedIndexChanged);
                    cbMaxY.SelectedIndexChanged += new System.EventHandler(cbMaxY_SelectedIndexChanged);
                    cbMaxZ.SelectedIndexChanged += new System.EventHandler(cbMaxZ_SelectedIndexChanged);

                    tbMinX.Scroll += new System.EventHandler(tbMinX_Scroll);
                    tbMinY.Scroll += new System.EventHandler(tbMinY_Scroll);
                    tbMinZ.Scroll += new System.EventHandler(tbMinZ_Scroll);

                    tbMaxX.Scroll += new System.EventHandler(tbMaxX_Scroll);
                    tbMaxY.Scroll += new System.EventHandler(tbMaxY_Scroll);
                    tbMaxZ.Scroll += new System.EventHandler(tbMaxZ_Scroll);

                    vizcore3dx.Update();
                }
            }
        }

        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            vizcore3dx.Model.OpenFileDialog();
        }

        private void btnLoadFrame_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Frame.OpenTribonFileDialog() == false) return;

            vizcore3dx.Frame.Visible = true;

            // Section Box가 이미 있으면 새로 불러온 Frame 기준으로 콤보 목록 갱신
            if (Section == null) return;

            VIZCore3DX.NET.Data.BoundBox3D box = Section.BoundBox;

            FillFrameList(VIZCore3DX.NET.Data.Axis.X, box.MinX, box.MaxX, cbMinX, cbMaxX);
            FillFrameList(VIZCore3DX.NET.Data.Axis.Y, box.MinY, box.MaxY, cbMinY, cbMaxY);
            FillFrameList(VIZCore3DX.NET.Data.Axis.Z, box.MinZ, box.MaxZ, cbMinZ, cbMaxZ);
        }

        private void btnAddSectionBox_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            Section = vizcore3dx.Section.AddBox(false);
            if (Section == null) return;
            VIZCore3DX.NET.Data.BoundBox3D box = Section.BoundBox;

            cbMinX.SelectedIndexChanged -= new System.EventHandler(cbMinX_SelectedIndexChanged);
            cbMinY.SelectedIndexChanged -= new System.EventHandler(cbMinY_SelectedIndexChanged);
            cbMinZ.SelectedIndexChanged -= new System.EventHandler(cbMinZ_SelectedIndexChanged);

            cbMaxX.SelectedIndexChanged -= new System.EventHandler(cbMaxX_SelectedIndexChanged);
            cbMaxY.SelectedIndexChanged -= new System.EventHandler(cbMaxY_SelectedIndexChanged);
            cbMaxZ.SelectedIndexChanged -= new System.EventHandler(cbMaxZ_SelectedIndexChanged);

            tbMinX.Scroll -= new System.EventHandler(tbMinX_Scroll);
            tbMinY.Scroll -= new System.EventHandler(tbMinY_Scroll);
            tbMinZ.Scroll -= new System.EventHandler(tbMinZ_Scroll);

            tbMaxX.Scroll -= new System.EventHandler(tbMaxX_Scroll);
            tbMaxY.Scroll -= new System.EventHandler(tbMaxY_Scroll);
            tbMaxZ.Scroll -= new System.EventHandler(tbMaxZ_Scroll);


            tbMinX.Minimum = tbMaxX.Minimum = Convert.ToInt32(box.MinX);
            tbMinX.Maximum = tbMaxX.Maximum = Convert.ToInt32(box.MaxX);
            tbMinX.Value = tbMinX.Minimum;
            tbMaxX.Value = tbMaxX.Maximum;

            tbMinY.Minimum = tbMaxY.Minimum = Convert.ToInt32(box.MinY);
            tbMinY.Maximum = tbMaxY.Maximum = Convert.ToInt32(box.MaxY);
            tbMinY.Value = tbMinY.Minimum;
            tbMaxY.Value = tbMaxY.Maximum;

            tbMinZ.Minimum = tbMaxZ.Minimum = Convert.ToInt32(box.MinZ);
            tbMinZ.Maximum = tbMaxZ.Maximum = Convert.ToInt32(box.MaxZ);
            tbMinZ.Value = tbMinZ.Minimum;
            tbMaxZ.Value = tbMaxZ.Maximum;

            // 단면상자 범위 내의 프레임 좌표 목록 구성
            FillFrameList(VIZCore3DX.NET.Data.Axis.X, box.MinX, box.MaxX, cbMinX, cbMaxX);
            FillFrameList(VIZCore3DX.NET.Data.Axis.Y, box.MinY, box.MaxY, cbMinY, cbMaxY);
            FillFrameList(VIZCore3DX.NET.Data.Axis.Z, box.MinZ, box.MaxZ, cbMinZ, cbMaxZ);

            cbMinX.SelectedIndexChanged += new System.EventHandler(cbMinX_SelectedIndexChanged);
            cbMinY.SelectedIndexChanged += new System.EventHandler(cbMinY_SelectedIndexChanged);
            cbMinZ.SelectedIndexChanged += new System.EventHandler(cbMinZ_SelectedIndexChanged);

            cbMaxX.SelectedIndexChanged += new System.EventHandler(cbMaxX_SelectedIndexChanged);
            cbMaxY.SelectedIndexChanged += new System.EventHandler(cbMaxY_SelectedIndexChanged);
            cbMaxZ.SelectedIndexChanged += new System.EventHandler(cbMaxZ_SelectedIndexChanged);

            tbMinX.Scroll += new System.EventHandler(tbMinX_Scroll);
            tbMinY.Scroll += new System.EventHandler(tbMinY_Scroll);
            tbMinZ.Scroll += new System.EventHandler(tbMinZ_Scroll);

            tbMaxX.Scroll += new System.EventHandler(tbMaxX_Scroll);
            tbMaxY.Scroll += new System.EventHandler(tbMaxY_Scroll);
            tbMaxZ.Scroll += new System.EventHandler(tbMaxZ_Scroll);

            vizcore3dx.Update();
        }

        private void UpdateSectionBoxSize(SectionPlanePositionType type)
        {
            if (Section == null) return;
            float position = 0f;
            switch (type)
            {
                case SectionPlanePositionType.XMin:
                    position = tbMinX.Value;
                    vizcore3dx.Section.SetBoxPlaneSize(Section.ID, (int)type, position);
                    break;
                case SectionPlanePositionType.XMax:
                    position = tbMaxX.Value;
                    vizcore3dx.Section.SetBoxPlaneSize(Section.ID, (int)type, position);
                    break;
                case SectionPlanePositionType.YMin:
                    position = tbMinY.Value;
                    vizcore3dx.Section.SetBoxPlaneSize(Section.ID, (int)type, position);
                    break;
                case SectionPlanePositionType.YMax:
                    position = tbMaxY.Value;
                    vizcore3dx.Section.SetBoxPlaneSize(Section.ID, (int)type, position);
                    break;
                case SectionPlanePositionType.ZMin:
                    position = tbMinZ.Value;
                    vizcore3dx.Section.SetBoxPlaneSize(Section.ID, (int)type, position);
                    break;
                case SectionPlanePositionType.ZMax:
                    position = tbMaxZ.Value;
                    vizcore3dx.Section.SetBoxPlaneSize(Section.ID, (int)type, position);
                    break;
            }
        }

        private int GetFramePosition(VIZCore3DX.NET.Data.Axis axis, string frame, TrackBar trackBar)
        {
            // 프레임 좌표가 유효하지 않으면 현재 값 유지
            VIZCore3DX.NET.Data.FramePosition fp = vizcore3dx.Frame.GetPosition(axis, frame);
            if (fp == null || fp.ValidData == false) return trackBar.Value;

            // TrackBar 범위 내로 제한 (범위를 벗어난 값 지정 시 예외 발생)
            int position = Convert.ToInt32(fp.Position);
            if (position < trackBar.Minimum) return trackBar.Minimum;
            if (position > trackBar.Maximum) return trackBar.Maximum;
            return position;
        }

        private void FillFrameList(VIZCore3DX.NET.Data.Axis axis, float min, float max, ComboBox cbMin, ComboBox cbMax)
        {
            cbMin.Items.Clear();
            cbMax.Items.Clear();

            // 첫번째 프레임의 프레임 라인 중, 단면상자 범위 내의 항목만 추가
            System.Collections.Generic.List<VIZCore3DX.NET.Data.FrameLine> lines = vizcore3dx.Frame.HasFrame ? vizcore3dx.Frame.GetFrameLines(axis) : null;

            if (lines != null)
            {
                foreach (VIZCore3DX.NET.Data.FrameLine line in lines)
                {
                    if (line.Offset < min || line.Offset > max) continue;

                    string frame = vizcore3dx.Frame.GetSnapString(axis, line.Offset);
                    if (string.IsNullOrEmpty(frame)) continue;

                    cbMin.Items.Add(frame);
                    cbMax.Items.Add(frame);
                }
            }

            // Frame 데이터가 없거나 범위 내 라인이 없으면 빈 콤보 대신 안내 문구 표시
            bool hasFrameItems = cbMin.Items.Count > 0;

            if (hasFrameItems == false)
            {
                cbMin.Items.Add("(Frame 없음)");
                cbMax.Items.Add("(Frame 없음)");
                cbMin.SelectedIndex = 0;
                cbMax.SelectedIndex = 0;
            }

            cbMin.Enabled = hasFrameItems;
            cbMax.Enabled = hasFrameItems;
        }

        private void tbMinX_Scroll(object sender, EventArgs e)
        {
            isScroll = true;
            cbMinX.SelectedIndexChanged -= new System.EventHandler(cbMinX_SelectedIndexChanged);
            cbMinX.SelectedIndexChanged += new System.EventHandler(cbMinX_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.XMin);
        }

        private void tbMaxX_Scroll(object sender, EventArgs e)
        {
            isScroll = true;
            cbMaxX.SelectedIndexChanged -= new System.EventHandler(cbMaxX_SelectedIndexChanged);
            cbMaxX.SelectedIndexChanged += new System.EventHandler(cbMaxX_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.XMax);
        }

        private void tbMinY_Scroll(object sender, EventArgs e)
        {
            isScroll = true;
            cbMinY.SelectedIndexChanged -= new System.EventHandler(cbMinY_SelectedIndexChanged);
            cbMinY.SelectedIndexChanged += new System.EventHandler(cbMinY_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.YMin);
        }

        private void tbMaxY_Scroll(object sender, EventArgs e)
        {
            isScroll = true;
            cbMaxY.SelectedIndexChanged -= new System.EventHandler(cbMaxY_SelectedIndexChanged);
            cbMaxY.SelectedIndexChanged += new System.EventHandler(cbMaxY_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.YMax);
        }

        private void tbMinZ_Scroll(object sender, EventArgs e)
        {
            isScroll = true;
            cbMinZ.SelectedIndexChanged -= new System.EventHandler(cbMinZ_SelectedIndexChanged);
            cbMinZ.SelectedIndexChanged += new System.EventHandler(cbMinZ_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.ZMin);
        }

        private void tbMaxZ_Scroll(object sender, EventArgs e)
        {
            isScroll = true;
            cbMaxZ.SelectedIndexChanged -= new System.EventHandler(cbMaxZ_SelectedIndexChanged);
            cbMaxZ.SelectedIndexChanged += new System.EventHandler(cbMaxZ_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.ZMax);
        }

        private void cbMinX_SelectedIndexChanged(object sender, EventArgs e)
        {
            isScroll = true;
            tbMinX.Scroll -= new System.EventHandler(tbMinX_Scroll);
            tbMinX.Value = GetFramePosition(VIZCore3DX.NET.Data.Axis.X, cbMinX.Text, tbMinX);
            tbMinX.Scroll += new System.EventHandler(tbMinX_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.XMin);

            vizcore3dx.Update();
            isScroll = false;
        }

        private void cbMaxX_SelectedIndexChanged(object sender, EventArgs e)
        {
            isScroll = true;
            tbMaxX.Scroll -= new System.EventHandler(tbMaxX_Scroll);
            tbMaxX.Value = GetFramePosition(VIZCore3DX.NET.Data.Axis.X, cbMaxX.Text, tbMaxX);
            tbMaxX.Scroll += new System.EventHandler(tbMaxX_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.XMax);

            vizcore3dx.Update();
            isScroll = false;
        }

        private void cbMinY_SelectedIndexChanged(object sender, EventArgs e)
        {
            isScroll = true;
            tbMinY.Scroll -= new System.EventHandler(tbMinY_Scroll);
            tbMinY.Value = GetFramePosition(VIZCore3DX.NET.Data.Axis.Y, cbMinY.Text, tbMinY);
            tbMinY.Scroll += new System.EventHandler(tbMinY_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.YMin);

            vizcore3dx.Update();
            isScroll = false;
        }

        private void cbMaxY_SelectedIndexChanged(object sender, EventArgs e)
        {
            isScroll = true;
            tbMaxY.Scroll -= new System.EventHandler(tbMaxY_Scroll);
            tbMaxY.Value = GetFramePosition(VIZCore3DX.NET.Data.Axis.Y, cbMaxY.Text, tbMaxY);
            tbMaxY.Scroll += new System.EventHandler(tbMaxY_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.YMax);

            vizcore3dx.Update();
            isScroll = false;
        }

        private void cbMinZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            isScroll = true;
            tbMinZ.Scroll -= new System.EventHandler(tbMinZ_Scroll);
            tbMinZ.Value = GetFramePosition(VIZCore3DX.NET.Data.Axis.Z, cbMinZ.Text, tbMinZ);
            tbMinZ.Scroll += new System.EventHandler(tbMinZ_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.ZMin);

            vizcore3dx.Update();
            isScroll = false;
        }

        private void cbMaxZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            isScroll = true;
            tbMaxZ.Scroll -= new System.EventHandler(tbMaxZ_Scroll);
            tbMaxZ.Value = GetFramePosition(VIZCore3DX.NET.Data.Axis.Z, cbMaxZ.Text, tbMaxZ);
            tbMaxZ.Scroll += new System.EventHandler(tbMaxZ_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.ZMax);

            vizcore3dx.Update();
            isScroll = false;
        }

        private void tbMinX_MouseUp(object sender, MouseEventArgs e)
        {
            vizcore3dx.Update();
            isScroll = false;
        }

        private void tbMaxX_MouseUp(object sender, MouseEventArgs e)
        {
            vizcore3dx.Update();
            isScroll = false;
        }

        private void tbMinY_MouseUp(object sender, MouseEventArgs e)
        {
            vizcore3dx.Update();
            isScroll = false;
        }

        private void tbMaxY_MouseUp(object sender, MouseEventArgs e)
        {
            vizcore3dx.Update();
            isScroll = false;
        }

        private void tbMinZ_MouseUp(object sender, MouseEventArgs e)
        {
            vizcore3dx.Update();
            isScroll = false;
        }

        private void tbMaxZ_MouseUp(object sender, MouseEventArgs e)
        {
            vizcore3dx.Update();
            isScroll = false;
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
