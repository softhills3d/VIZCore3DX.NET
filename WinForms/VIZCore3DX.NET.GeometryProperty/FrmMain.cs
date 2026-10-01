using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.GeometryProperty
{
    public partial class FrmMain : Form
    {
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
            splitContainer1.Panel1.Controls.Add(vizcore3dx);

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            InitializeAnalysisUI();
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
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // 마우스로 개체 선택 상태가 변경됐을 때
            vizcore3dx.Object3D.OnNodeEvent += Object3D_OnNodeEvent;
        }

        #region Geometry Property

        private void Object3D_OnNodeEvent(object sender, EventManager.NodeEventArgs e)
        {
            if (e == null || e.EventKind != VIZCore3DX.NET.Manager.Object3DManager.NodeEventKind.SELECTION_CHANGED_NODE) return;

            UpdateGeometryProperty();
        }

        private void GeometryReturnType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton == null || radioButton.Checked == false) return;

            UpdateGeometryProperty();
        }

        private void UpdateGeometryProperty()
        {
            List<VIZCore3DX.NET.Data.Node> selectedNodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);

            if (selectedNodes.Count == 0)
            {
                geometryPropertyGrid.SelectedObject = null;
                return;
            }

            // Geometry Property
            if (rdoFromSelectedObject3D.Checked)
            {
                geometryPropertyGrid.SelectedObject = vizcore3dx.Object3D.GeometryProperty.FromSelectedObject3D(false);
                return;
            }

            // 표면적 (m²)
            if (rdoGetSurfaceArea.Checked)
            {
                double surfaceArea = vizcore3dx.Object3D.GeometryProperty.GetSurfaceArea(selectedNodes);
                geometryPropertyGrid.SelectedObject = new { SurfaceArea = surfaceArea, Unit = "m²" };
                return;
            }

            // 부피 (m³)
            if (rdoGetVolume.Checked)
            {
                double volume = vizcore3dx.Object3D.GeometryProperty.GetVolume(selectedNodes);
                geometryPropertyGrid.SelectedObject = new { Volume = volume, Unit = "m³" };
                return;
            }

            // 부피 중심 (mm)
            if (rdoGetCenterOfVolume.Checked)
            {
                geometryPropertyGrid.SelectedObject = vizcore3dx.Object3D.GeometryProperty.GetCenterOfVolume(selectedNodes);
                return;
            }

            // 메시 기준 표면적 + 부피 + 질량 중심 + 삼각형 수
            if (rdoGetMeshGeometry.Checked)
            {
                geometryPropertyGrid.SelectedObject = vizcore3dx.Object3D.GeometryProperty.GetMeshGeometry(selectedNodes);
                return;
            }

            // 표면적 + 부피 + 부피 중심
            if (rdoGetGeometry.Checked)
            {
                geometryPropertyGrid.SelectedObject = vizcore3dx.Object3D.GeometryProperty.GetGeometry(selectedNodes);
            }
        }

        #endregion

        #region Common

        /// <summary>
        /// 분석 UI 초기화
        /// </summary>
        private void InitializeAnalysisUI()
        {
            foreach (VIZCore3DX.NET.Data.GeometryRankMetric metric in Enum.GetValues(typeof(VIZCore3DX.NET.Data.GeometryRankMetric)))
            {
                // 메시 기준 항목(Volume / SurfaceArea / TriangleCount)은 현재 DLL(1.5.26.928)에서 항상 0 으로 반환되어 제외
                if (metric == VIZCore3DX.NET.Data.GeometryRankMetric.Volume
                    || metric == VIZCore3DX.NET.Data.GeometryRankMetric.SurfaceArea
                    || metric == VIZCore3DX.NET.Data.GeometryRankMetric.TriangleCount) continue;

                cmbRankMetric.Items.Add(metric);
            }
            cmbRankMetric.SelectedItem = VIZCore3DX.NET.Data.GeometryRankMetric.BoundBoxVolume;

            foreach (VIZCore3DX.NET.Data.Axis axis in Enum.GetValues(typeof(VIZCore3DX.NET.Data.Axis)))
            {
                cmbAxis.Items.Add(axis);
            }
            cmbAxis.SelectedItem = VIZCore3DX.NET.Data.Axis.Z;
        }

        /// <summary>
        /// 분석 대상 노드 조회 (선택 개체만 : 선택된 노드, 그 외 : null)
        /// </summary>
        /// <param name="selectedOnly">선택 개체만 여부</param>
        /// <param name="nodes">분석 대상 노드</param>
        /// <returns>진행 가능 여부</returns>
        private bool TryGetTargetNodes(bool selectedOnly, out List<VIZCore3DX.NET.Data.Node> nodes)
        {
            nodes = null;
            if (selectedOnly == false) return true;

            nodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);
            if (nodes.Count > 0) return true;

            MessageBox.Show("선택된 개체가 없습니다.", "VIZCore3DX.NET.GeometryProperty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        /// <summary>
        /// 노드 선택 및 화면 이동
        /// </summary>
        /// <param name="nodes">선택할 노드</param>
        private void SelectNodes(List<VIZCore3DX.NET.Data.Node> nodes)
        {
            if (nodes == null || nodes.Count == 0) return;

            using (vizcore3dx.BeginUpdateScope())
            {
                vizcore3dx.Object3D.Select(nodes, true);
                vizcore3dx.View.FlyToObject3d(nodes, 1.0f);
            }
        }

        #endregion

        #region Shape Statistics

        private void btnShapeStatistics_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.Node> nodes;
            if (TryGetTargetNodes(chkShapeSelectedOnly.Checked, out nodes) == false) return;

            vizcore3dx.ShowWaitForm("Analyzing...", "Analyzing...");
            VIZCore3DX.NET.Data.ShapeStatistics statistics = nodes == null
                ? vizcore3dx.Object3D.GeometryProperty.GetShapeStatistics()
                : vizcore3dx.Object3D.GeometryProperty.GetShapeStatistics(nodes);
            vizcore3dx.CloseWaitForm();

            lvShapeGroup.BeginUpdate();
            lvShapeGroup.Items.Clear();
            if (statistics != null)
            {
                foreach (VIZCore3DX.NET.Data.ShapeGroup group in statistics.Groups)
                {
                    ListViewItem lvi = new ListViewItem(new string[]
                    {
                        group.Count.ToString(),
                        group.TriangleCount.ToString(),
                        group.Volume.ToString("0.######"),
                        group.SurfaceArea.ToString("0.######"),
                        group.Signature
                    });
                    lvi.Tag = group;
                    lvShapeGroup.Items.Add(lvi);
                }
            }
            lvShapeGroup.EndUpdate();

            if (statistics == null)
            {
                lblShapeInfo.Text = "조회 결과가 없습니다.";
                return;
            }

            lblShapeInfo.Text = string.Format("노드 {0} / 형상 종류 {1}  (더블 클릭 : 묶음 노드 선택)", statistics.NodeCount, statistics.UniqueShapeCount);
        }

        private void lvShapeGroup_DoubleClick(object sender, EventArgs e)
        {
            if (lvShapeGroup.SelectedItems.Count == 0) return;

            VIZCore3DX.NET.Data.ShapeGroup group = lvShapeGroup.SelectedItems[0].Tag as VIZCore3DX.NET.Data.ShapeGroup;
            if (group == null) return;

            SelectNodes(group.Nodes);
        }

        #endregion

        #region Ranking

        private void btnRanking_Click(object sender, EventArgs e)
        {
            if (cmbRankMetric.SelectedItem == null) return;

            List<VIZCore3DX.NET.Data.Node> nodes;
            if (TryGetTargetNodes(chkRankSelectedOnly.Checked, out nodes) == false) return;

            // GetRanking(metric, ...) 은 "선택된 개체" 기준이므로, 모델 전체 순위는 전체 파트를 직접 넘김
            if (nodes == null) nodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.PART);

            VIZCore3DX.NET.Data.GeometryRankMetric metric = (VIZCore3DX.NET.Data.GeometryRankMetric)cmbRankMetric.SelectedItem;
            int topN = (int)numRankTopN.Value;

            vizcore3dx.ShowWaitForm("Analyzing...", "Analyzing...");
            VIZCore3DX.NET.Data.GeometryRanking ranking = vizcore3dx.Object3D.GeometryProperty.GetRanking(nodes, metric, topN, chkDescending.Checked);
            vizcore3dx.CloseWaitForm();

            lvRanking.BeginUpdate();
            lvRanking.Items.Clear();
            if (ranking != null)
            {
                int rank = 1;
                foreach (VIZCore3DX.NET.Data.GeometryRankItem item in ranking.Items)
                {
                    ListViewItem lvi = new ListViewItem(new string[]
                    {
                        rank.ToString(),
                        item.Node == null ? string.Empty : item.Node.NodeName,
                        item.Value.ToString("0.######"),
                        item.Node == null ? string.Empty : item.Node.Index.ToString()
                    });
                    lvi.Tag = item.Node;
                    lvRanking.Items.Add(lvi);
                    rank++;
                }
            }
            lvRanking.EndUpdate();

            if (ranking == null)
            {
                lblRankInfo.Text = "조회 결과가 없습니다.";
                return;
            }

            lblRankInfo.Text = string.Format("{0} / 검사 노드 {1}{2}  (더블 클릭 : 노드 선택)", ranking.Metric, ranking.ScannedCount, ranking.Truncated ? " (상위 N개만 표시)" : string.Empty);
        }

        private void lvRanking_DoubleClick(object sender, EventArgs e)
        {
            if (lvRanking.SelectedItems.Count == 0) return;

            VIZCore3DX.NET.Data.Node node = lvRanking.SelectedItems[0].Tag as VIZCore3DX.NET.Data.Node;
            if (node == null) return;

            SelectNodes(new List<VIZCore3DX.NET.Data.Node>() { node });
        }

        #endregion

        #region Axis Distribution

        private void btnAxisDistribution_Click(object sender, EventArgs e)
        {
            if (cmbAxis.SelectedItem == null) return;

            VIZCore3DX.NET.Data.Axis axis = (VIZCore3DX.NET.Data.Axis)cmbAxis.SelectedItem;

            vizcore3dx.ShowWaitForm("Analyzing...", "Analyzing...");
            VIZCore3DX.NET.Data.AxisDistribution distribution = vizcore3dx.Object3D.GeometryProperty.GetAxisDistribution(axis, (int)numBandCount.Value, chkAxisVisibleOnly.Checked);
            vizcore3dx.CloseWaitForm();

            lvAxisBand.BeginUpdate();
            lvAxisBand.Items.Clear();
            if (distribution != null)
            {
                int band = 1;
                foreach (VIZCore3DX.NET.Data.AxisBand item in distribution.Items)
                {
                    ListViewItem lvi = new ListViewItem(new string[]
                    {
                        band.ToString(),
                        item.From.ToString("0.##"),
                        item.To.ToString("0.##"),
                        item.Count.ToString()
                    });
                    lvAxisBand.Items.Add(lvi);
                    band++;
                }
            }
            lvAxisBand.EndUpdate();

            if (distribution == null)
            {
                lblAxisInfo.Text = "조회 결과가 없습니다.";
                return;
            }

            lblAxisInfo.Text = string.Format("{0}축 범위 {1:0.##} ~ {2:0.##} / 구간 크기 {3:0.##}", distribution.Axis, distribution.RangeMin, distribution.RangeMax, distribution.BandSize);
        }

        #endregion

        #region Node Default Properties

        private void btnLoadDefaultProperties_Click(object sender, EventArgs e)
        {
            // 로드할 특성 종류 (플래그 조합)
            VIZCore3DX.NET.Data.NodeDefaultPropertyKind kinds = VIZCore3DX.NET.Data.NodeDefaultPropertyKind.None;
            if (chkKindColor.Checked) kinds |= VIZCore3DX.NET.Data.NodeDefaultPropertyKind.Color;
            if (chkKindSurfaceArea.Checked) kinds |= VIZCore3DX.NET.Data.NodeDefaultPropertyKind.SurfaceArea;
            if (chkKindVolume.Checked) kinds |= VIZCore3DX.NET.Data.NodeDefaultPropertyKind.Volume;
            if (chkKindCenterOfVolume.Checked) kinds |= VIZCore3DX.NET.Data.NodeDefaultPropertyKind.CenterOfVolume;
            if (chkKindTriangleCount.Checked) kinds |= VIZCore3DX.NET.Data.NodeDefaultPropertyKind.TriangleCount;

            if (kinds == VIZCore3DX.NET.Data.NodeDefaultPropertyKind.None)
            {
                MessageBox.Show("로드할 특성 종류를 하나 이상 선택하세요.", "VIZCore3DX.NET.GeometryProperty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> nodes;
            if (TryGetTargetNodes(chkDefaultSelectedOnly.Checked, out nodes) == false) return;

            Stopwatch stopwatch = Stopwatch.StartNew();

            vizcore3dx.ShowWaitForm("Loading...", "Loading...");
            if (nodes == null)
            {
                vizcore3dx.Model.LoadNodeDefaultProperties(kinds);
            }
            else
            {
                vizcore3dx.Model.LoadNodeDefaultProperties(kinds, nodes);
            }
            vizcore3dx.CloseWaitForm();

            stopwatch.Stop();

            if (vizcore3dx.Model.LastOperationStatus.IsFailure)
            {
                MessageBox.Show(string.Format("노드 기본 특성을 로드하지 못했습니다.\r\n\r\nResult : {0}", vizcore3dx.Model.LastOperationStatus.Result), "VIZCore3DX.NET.GeometryProperty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblDefaultInfo.Text = string.Format("로드 완료 : {0}\r\n대상 : {1}\r\n소요 시간 : {2} ms", kinds, nodes == null ? "전체 노드" : string.Format("선택 노드 {0}개", nodes.Count), stopwatch.ElapsedMilliseconds);

            // 로드한 특성을 노드별로 표시 (전체 노드는 파트 기준)
            UpdateDefaultPropertyList(nodes == null ? vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.PART) : nodes, kinds);
        }

        private void UpdateDefaultPropertyList(List<VIZCore3DX.NET.Data.Node> nodes, VIZCore3DX.NET.Data.NodeDefaultPropertyKind kinds)
        {
            // 표시 개수 제한 (노드가 많을 때 목록 갱신이 오래 걸리지 않도록)
            const int MaxDisplayCount = 1000;

            bool showColor = (kinds & VIZCore3DX.NET.Data.NodeDefaultPropertyKind.Color) != 0;
            bool showArea = (kinds & VIZCore3DX.NET.Data.NodeDefaultPropertyKind.SurfaceArea) != 0;
            bool showVolume = (kinds & VIZCore3DX.NET.Data.NodeDefaultPropertyKind.Volume) != 0;
            bool showCenter = (kinds & VIZCore3DX.NET.Data.NodeDefaultPropertyKind.CenterOfVolume) != 0;
            bool showTriangle = (kinds & VIZCore3DX.NET.Data.NodeDefaultPropertyKind.TriangleCount) != 0;

            lvDefaultResult.BeginUpdate();
            lvDefaultResult.Items.Clear();

            // 체크한 특성만 체크박스 순서대로 컬럼 구성
            lvDefaultResult.Columns.Clear();
            lvDefaultResult.Columns.Add(colDefName);
            if (showColor) lvDefaultResult.Columns.Add(colDefColor);
            if (showArea) lvDefaultResult.Columns.Add(colDefArea);
            if (showVolume) lvDefaultResult.Columns.Add(colDefVolume);
            if (showCenter) lvDefaultResult.Columns.Add(colDefCenter);
            if (showTriangle) lvDefaultResult.Columns.Add(colDefTriangle);

            if (nodes != null)
            {
                foreach (VIZCore3DX.NET.Data.Node node in nodes)
                {
                    if (lvDefaultResult.Items.Count >= MaxDisplayCount) break;

                    VIZCore3DX.NET.Data.Object3DProperty prop = vizcore3dx.Object3D.GeometryProperty.FromNode(node, false);
                    if (prop == null) continue;

                    ListViewItem lvi = new ListViewItem(node.NodeName);
                    if (showColor)
                    {
                        // 색상 셀 배경을 노드 색상으로 표시
                        System.Drawing.Color color = node.GetColor();
                        lvi.UseItemStyleForSubItems = false;
                        ListViewItem.ListViewSubItem colorItem = lvi.SubItems.Add(string.Format("{0}, {1}, {2}", color.R, color.G, color.B));
                        colorItem.BackColor = System.Drawing.Color.FromArgb(255, color);
                        colorItem.ForeColor = color.GetBrightness() < 0.5f ? System.Drawing.Color.White : System.Drawing.Color.Black;
                    }
                    if (showArea) lvi.SubItems.Add(prop.SurfaceArea);
                    if (showVolume) lvi.SubItems.Add(prop.Volume);
                    if (showCenter) lvi.SubItems.Add(prop.VolumeCenterPoint == null ? "" : prop.VolumeCenterPoint.ToString());
                    if (showTriangle) lvi.SubItems.Add(prop.TriangleCount.ToString("N0"));
                    lvDefaultResult.Items.Add(lvi);
                }
            }

            lvDefaultResult.EndUpdate();
        }

        #endregion

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
