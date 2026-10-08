using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.PickAndScreen
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 마지막으로 우클릭한 뷰 좌표 (다음 개체 순환의 기준)
        private System.Drawing.Point _lastPoint;

        // 순환 중인 픽 순번 (우클릭마다 0 으로 되돌림)
        private int _pickIndex;

        // 우클릭 지점의 픽 결과 (dgvPick 과 같은 순서)
        private List<VIZCore3DX.NET.Data.PickableObject> _picks;

        // 카메라에서 우클릭 지점으로 쏜 광선의 충돌 결과 (dgvHits 와 같은 순서)
        private List<VIZCore3DX.NET.Data.RaycastHit> _hits;

        // 광선 시작점 (카메라 눈 위치)
        private VIZCore3DX.NET.Data.Vector3D _rayOrigin;

        // 광선 선 (0 이면 없음)
        private uint _rayLine;

        // 충돌점 (0 이면 없음)
        private uint _hitPoints;

        // 마지막으로 조회한 화면 영역과 그 테두리 선 (0 이면 없음)
        private System.Drawing.Rectangle _lastArea = System.Drawing.Rectangle.Empty;
        private uint _areaLine;

        // 마지막 영역 조회 결과. 있으면 우클릭 픽·광선 충돌을 이 개체들 안에서만 찾습니다. (null 이면 전체)
        private List<VIZCore3DX.NET.Data.Node> _areaNodes;

        // 표를 코드로 채우는 동안에는 표 선택을 뷰로 넘기지 않습니다.
        private bool _syncing;

        public FrmMain()
        {
            InitializeComponent();

            // 뷰어와 무관한 콤보 항목은 생성자에서 채웁니다.
            cmbFilter.Items.AddRange(new object[]
            {
                VIZCore3DX.NET.Data.PickableObjectFilter.All,
                VIZCore3DX.NET.Data.PickableObjectFilter.Node,
                VIZCore3DX.NET.Data.PickableObjectFilter.Note,
                VIZCore3DX.NET.Data.PickableObjectFilter.Measure,
                VIZCore3DX.NET.Data.PickableObjectFilter.Section,
                VIZCore3DX.NET.Data.PickableObjectFilter.Sketch,
                VIZCore3DX.NET.Data.PickableObjectFilter.Decal,
                VIZCore3DX.NET.Data.PickableObjectFilter.Shape
            });
            cmbFilter.SelectedIndex = 0;

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
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
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeVIZCore3DX();
        }

        private void InitializeVIZCore3DX()
        {
            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();

            // 3D 뷰의 마우스 누름을 받아 우클릭 지점을 조회합니다.
            vizcore3dx.View.OnViewDefaultMouseDownEvent -= View_OnViewDefaultMouseDownEvent;
            vizcore3dx.View.OnViewDefaultMouseDownEvent += View_OnViewDefaultMouseDownEvent;

            SetStatus("모델을 열어 주세요.");
        }

        // 3D 뷰에서 마우스 오른쪽 버튼을 누른 지점을 조회합니다. 뷰 이벤트는 UI 스레드로 넘겨 처리합니다.
        private void View_OnViewDefaultMouseDownEvent(object sender, MouseEventArgs e)
        {
            RunOnUi(() =>
            {
                if (e.Button != MouseButtons.Right) return;
                QueryPoint(e.Location);
            });
        }

        #region 1. 모델
        // 조회할 모델을 엽니다. 이전 결과는 비우고 FrontObjectOnly 체크는 현재 설정값으로 맞춥니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            ClearResults();
            chkFrontOnly.Checked = vizcore3dx.View.EnableBoxSelectionFrontObjectOnly;
            SetStatus("모델을 열었습니다.");
        }
        #endregion

        #region 2. 설정
        // 영역 조회에서 다른 개체에 가려진 개체를 뺄지 정합니다.
        private void chkFrontOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            vizcore3dx.View.EnableBoxSelectionFrontObjectOnly = chkFrontOnly.Checked;
            SetStatus(string.Format("FrontObjectOnly = {0}", vizcore3dx.View.EnableBoxSelectionFrontObjectOnly));
        }

        // 완전 포함 조건을 바꾸면 마지막으로 조회한 영역을 같은 조건으로 다시 조회합니다.
        private void chkFullContains_CheckedChanged(object sender, EventArgs e)
        {
            if (_lastArea.IsEmpty || !IsModelOpened()) return;

            QueryArea(_lastArea);
        }

        // 조회 영역 테두리 표시를 켜고 끕니다. 켜면 마지막 영역을 다시 그립니다.
        private void chkShowArea_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowArea.Checked) ShowArea();
            else HideArea();
        }

        // 광선·충돌점 표시를 켜고 끕니다. 켜면 마지막 결과를 다시 그립니다.
        private void chkShowRay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowRay.Checked) ShowRay();
            else HideRay();
        }
        #endregion

        #region 3. 영역 조회
        // 3D 뷰 가운데 절반(가로·세로 1/4 ~ 3/4)을 영역 좌표로 채웁니다.
        private void btnCenterRect_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            System.Drawing.Size size = ViewPixelSize();
            SetArea(size.Width / 4, size.Height / 4, size.Width * 3 / 4, size.Height * 3 / 4);
            SetStatus(string.Format("3D 뷰({0} x {1}) 가운데 절반을 영역으로 채웠습니다.", size.Width, size.Height));
        }

        // 입력한 화면 사각형(뷰 픽셀 좌표) 안의 노드를 조회해 선택합니다.
        private void btnScreenRect_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            QueryArea(System.Drawing.Rectangle.FromLTRB((int)numX1.Value, (int)numY1.Value, (int)numX2.Value, (int)numY2.Value));
        }

        // 3D 뷰 전체를 영역으로 삼아 노드를 조회해 선택합니다.
        private void btnScreenAll_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            // 조회한 범위가 보이도록 3D 뷰 전체 크기를 영역 좌표에도 채웁니다.
            System.Drawing.Size size = ViewPixelSize();
            SetArea(0, 0, size.Width, size.Height);

            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.FromScreen(chkFullContains.Checked);
            ApplyArea(nodes, new System.Drawing.Rectangle(0, 0, size.Width, size.Height));
        }
        #endregion

        #region 4. 결과
        // 픽 결과에서 고른 행이 노드면 그 노드만 선택합니다.
        private void dgvPick_SelectionChanged(object sender, EventArgs e)
        {
            if (_syncing) return;
            if (dgvPick.SelectedRows.Count == 0) return;

            SelectPick(dgvPick.SelectedRows[0].Tag as VIZCore3DX.NET.Data.PickableObject);
        }

        // 같은 지점에 겹친 개체를 index 로 하나씩 돌아가며 고릅니다. index 는 개수로 나눈 나머지로 순환합니다.
        private void btnNextPick_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            if (_picks == null || _picks.Count == 0)
            {
                SetStatus("먼저 3D 뷰에서 마우스 오른쪽 버튼으로 지점을 고르세요.");
                return;
            }

            _pickIndex++;
            VIZCore3DX.NET.Data.PickableObject pick = vizcore3dx.Object3D.GetPickableObject(_lastPoint, SelectedFilter(), _pickIndex);
            if (pick == null)
            {
                SetStatus("지점 아래 개체가 없습니다.");
                return;
            }

            int row = _pickIndex % _picks.Count;
            if (row < dgvPick.Rows.Count)
            {
                _syncing = true;
                try
                {
                    dgvPick.ClearSelection();
                    dgvPick.Rows[row].Selected = true;
                }
                finally
                {
                    _syncing = false;
                }
            }

            SelectPick(pick);
            SetStatus(string.Format("{0} 번째 개체 : {1} ({2})", row + 1, DescribeObject(pick), pick.Type));
        }

        // 광선 충돌에서 고른 행의 노드만 선택합니다.
        private void dgvHits_SelectionChanged(object sender, EventArgs e)
        {
            if (_syncing) return;
            if (dgvHits.SelectedRows.Count == 0) return;

            VIZCore3DX.NET.Data.RaycastHit hit = dgvHits.SelectedRows[0].Tag as VIZCore3DX.NET.Data.RaycastHit;
            if (hit != null) SelectOnly(hit.Node);
        }
        #endregion

        #region 5. 정리
        // 뷰의 선택을 모두 해제합니다. 결과 표는 남습니다.
        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);
            SetStatus("선택을 해제했습니다.");
        }

        // 결과 표와 광선 표시를 비웁니다.
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearResults();
            SetStatus("결과를 비웠습니다.");
        }
        #endregion

        #region Helpers
        // 모델이 열려 있지 않으면 상태 문구를 남기고 false 를 돌려줍니다.
        private bool IsModelOpened()
        {
            if (vizcore3dx.Model.IsOpen()) return true;

            SetStatus("먼저 모델을 여세요.");
            return false;
        }

        private void SetStatus(string message)
        {
            lblStatus.Text = message;
        }

        private void RunOnUi(Action action)
        {
            if (InvokeRequired) BeginInvoke(action);
            else action();
        }

        private VIZCore3DX.NET.Data.PickableObjectFilter SelectedFilter()
        {
            return (VIZCore3DX.NET.Data.PickableObjectFilter)cmbFilter.SelectedItem;
        }

        // 지점 아래의 픽 대상과, 카메라에서 그 지점을 지나는 광선의 충돌을 조회합니다.
        private void QueryPoint(System.Drawing.Point point)
        {
            if (!IsModelOpened()) return;

            _lastPoint = point;
            _pickIndex = 0;
            _picks = OnlyInArea(vizcore3dx.Object3D.GetPickableObjects(point, SelectedFilter()));
            FillPicks();

            int pickCount = _picks == null ? 0 : _picks.Count;
            Tuple<VIZCore3DX.NET.Data.Node, VIZCore3DX.NET.Data.Vector3D> target = vizcore3dx.View.GetNodeWithPosition(point);
            if (target == null)
            {
                _hits = null;
                FillHits();
                HideRay();
                SelectFirstPick();
                SetStatus(string.Format("지점 아래 개체 없음 : 픽 {0} 개", pickCount));
                return;
            }

            _rayOrigin = vizcore3dx.View.GetCameraEyePosition();
            VIZCore3DX.NET.Data.Vector3D direction = target.Item2 - _rayOrigin;
            if (direction.Length() < 1e-4f) return;

            // 영역 조회를 했으면 그 결과 개체만 광선 충돌 대상으로 삼습니다.
            VIZCore3DX.NET.Data.Ray3D ray = new VIZCore3DX.NET.Data.Ray3D(_rayOrigin, direction);
            if (_areaNodes == null) _hits = vizcore3dx.Object3D.RaycastAll(ray);
            else if (_areaNodes.Count == 0) _hits = new List<VIZCore3DX.NET.Data.RaycastHit>();
            else _hits = vizcore3dx.Object3D.RaycastAll(ray, _areaNodes);
            FillHits();
            if (chkShowRay.Checked) ShowRay();
            SelectFirstPick();

            int hitCount = _hits == null ? 0 : _hits.Count;
            float nearest = hitCount == 0 ? 0f : _hits[0].Distance;
            for (int i = 1; i < hitCount; i++) nearest = Math.Min(nearest, _hits[i].Distance);
            SetStatus(string.Format("픽 {0} 개, 광선 충돌 {1} 개 (가장 가까운 거리 {2:F1})", pickCount, hitCount, nearest));
        }

        // 픽 결과를 표에 넣습니다. 첫 행 선택은 SelectFirstPick 에서 합니다.
        private void FillPicks()
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            if (_picks != null)
            {
                for (int i = 0; i < _picks.Count; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvPick, _picks[i].Type, DescribeObject(_picks[i]), i + 1);
                    row.Tag = _picks[i];
                    rows.Add(row);
                }
            }

            _syncing = true;
            try
            {
                dgvPick.Rows.Clear();
                dgvPick.Rows.AddRange(rows.ToArray());
                dgvPick.ClearSelection();
            }
            finally
            {
                _syncing = false;
            }

            lblPick.Text = string.Format("픽 결과 (우클릭 지점) : {0} 개{1}", rows.Count, _areaNodes == null ? "" : " · 영역 결과 안에서");
        }

        // 광선 충돌 결과를 표에 넣습니다.
        private void FillHits()
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            if (_hits != null)
            {
                foreach (VIZCore3DX.NET.Data.RaycastHit hit in _hits)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvHits, hit.Node == null ? "" : hit.Node.NodeName, hit.Distance.ToString("F1"),
                        string.Format("{0:F1}, {1:F1}, {2:F1}", hit.Position.X, hit.Position.Y, hit.Position.Z));
                    row.Tag = hit;
                    rows.Add(row);
                }
            }

            _syncing = true;
            try
            {
                dgvHits.Rows.Clear();
                dgvHits.Rows.AddRange(rows.ToArray());
                dgvHits.ClearSelection();
            }
            finally
            {
                _syncing = false;
            }

            lblHits.Text = string.Format("광선 충돌 (카메라 → 지점) : {0} 개{1}", rows.Count, _areaNodes == null ? "" : " · 영역 결과 안에서");
        }

        // 픽 결과 첫 행을 고릅니다. 노드면 표 선택 이벤트에서 그 노드만 선택됩니다.
        private void SelectFirstPick()
        {
            if (dgvPick.Rows.Count > 0) dgvPick.Rows[0].Selected = true;
        }

        // 픽 대상이 노드면 그 노드만 선택합니다. 노드가 아니면 Object 는 해당 표식 객체입니다.
        private void SelectPick(VIZCore3DX.NET.Data.PickableObject pick)
        {
            if (pick == null || pick.Type != VIZCore3DX.NET.Data.PickableObjectType.Node) return;

            SelectOnly(pick.Object as VIZCore3DX.NET.Data.Node);
        }

        private void SelectOnly(VIZCore3DX.NET.Data.Node node)
        {
            if (node == null) return;

            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);
                vizcore3dx.Object3D.Select(node, true);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        private static string DescribeObject(VIZCore3DX.NET.Data.PickableObject pick)
        {
            VIZCore3DX.NET.Data.Node node = pick.Object as VIZCore3DX.NET.Data.Node;
            if (pick.Type == VIZCore3DX.NET.Data.PickableObjectType.Node && node != null) return node.NodeName;
            return pick.Object == null ? "" : pick.Object.GetType().Name;
        }

        // 화면 사각형 안의 노드를 조회합니다. 완전 포함 체크가 켜져 있으면 영역에 온전히 들어온 개체만 돌려받습니다.
        private void QueryArea(System.Drawing.Rectangle area)
        {
            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.FromScreen(area.Left, area.Top, area.Right, area.Bottom, chkFullContains.Checked);
            ApplyArea(nodes, area);
        }

        // 영역 조회 결과를 선택하고, 결과 개수와 영역을 표시합니다.
        private void ApplyArea(List<VIZCore3DX.NET.Data.Node> nodes, System.Drawing.Rectangle area)
        {
            if (nodes == null) nodes = new List<VIZCore3DX.NET.Data.Node>();

            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);
                if (nodes.Count > 0) vizcore3dx.Object3D.Select(nodes, true);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            lblArea.Text = string.Format("영역 조회 결과 : {0} 개  ({1}, {2}) - ({3}, {4})", nodes.Count, area.Left, area.Top, area.Right, area.Bottom);
            _lastArea = area;
            _areaNodes = nodes;
            if (chkShowArea.Checked) ShowArea();

            SetStatus(string.Format("영역 조회 완료 : {0} 개", nodes.Count));
        }

        // 3D 뷰 렌더링 영역의 픽셀 크기. 시선 위의 점은 화면 정중앙에 찍히므로 그 화면 좌표의 2배가 크기입니다.
        private System.Drawing.Size ViewPixelSize()
        {
            VIZCore3DX.NET.Data.Vector3D eye = vizcore3dx.View.GetCameraEyePosition();
            VIZCore3DX.NET.Data.Vector3D direction = vizcore3dx.View.GetCameraAxis()[2];
            VIZCore3DX.NET.Data.Vertex3D center = vizcore3dx.View.WorldToScreen((eye + direction * 1000f).ToVertex3D());

            return new System.Drawing.Size((int)Math.Round(center.X * 2), (int)Math.Round(center.Y * 2));
        }

        // 영역 조회 결과가 있으면 노드 픽 중 그 결과에 든 것만 남깁니다. 노드가 아닌 픽(표식 등)은 그대로 둡니다.
        private List<VIZCore3DX.NET.Data.PickableObject> OnlyInArea(List<VIZCore3DX.NET.Data.PickableObject> picks)
        {
            if (picks == null || _areaNodes == null) return picks;

            // 노드 고유키는 (EntityID, Index) 쌍입니다.
            HashSet<long> keys = new HashSet<long>();
            foreach (VIZCore3DX.NET.Data.Node node in _areaNodes) keys.Add(NodeKey(node));

            return picks.FindAll(pick =>
            {
                VIZCore3DX.NET.Data.Node node = pick.Object as VIZCore3DX.NET.Data.Node;
                return pick.Type != VIZCore3DX.NET.Data.PickableObjectType.Node || (node != null && keys.Contains(NodeKey(node)));
            });
        }

        private static long NodeKey(VIZCore3DX.NET.Data.Node node)
        {
            return ((long)node.EntityID << 32) | (uint)node.Index;
        }

        private void SetArea(int x1, int y1, int x2, int y2)
        {
            SetNumber(numX1, x1);
            SetNumber(numY1, y1);
            SetNumber(numX2, x2);
            SetNumber(numY2, y2);
        }

        // 마지막으로 조회한 화면 영역의 테두리를 3D 뷰에 하늘색 사각형으로 그립니다.
        private void ShowArea()
        {
            HideArea();
            if (_lastArea.IsEmpty) return;

            int[,] corners = { { _lastArea.Left, _lastArea.Top }, { _lastArea.Right, _lastArea.Top }, { _lastArea.Right, _lastArea.Bottom }, { _lastArea.Left, _lastArea.Bottom }, { _lastArea.Left, _lastArea.Top } };
            float[] line = new float[corners.GetLength(0) * 3];
            for (int i = 0; i < corners.GetLength(0); i++)
            {
                VIZCore3DX.NET.Data.Vertex3D p = vizcore3dx.View.ScreenToWorld(corners[i, 0], corners[i, 1], 0.5f);
                line[i * 3 + 0] = p.X; line[i * 3 + 1] = p.Y; line[i * 3 + 2] = p.Z;
            }

            VIZCore3DX.NET.Data.DataSetOptions options = new VIZCore3DX.NET.Data.DataSetOptions();
            options.Color = System.Drawing.Color.DeepSkyBlue;
            options.LineWidth = 3f;
            options.AlwaysOnTop = true;
            _areaLine = vizcore3dx.View.Effect.AddLineSet(line, new int[] { corners.GetLength(0) }, null, options);
        }

        private void HideArea()
        {
            if (_areaLine == 0) return;

            vizcore3dx.View.Effect.RemoveDataSet(_areaLine);
            _areaLine = 0;
        }

        private static void SetNumber(NumericUpDown num, int value)
        {
            num.Value = Math.Max(num.Minimum, Math.Min(num.Maximum, value));
        }

        // 카메라에서 가장 먼 충돌점까지 광선을 노란 선으로, 모든 충돌점을 빨간 점으로 그립니다.
        private void ShowRay()
        {
            HideRay();
            if (_hits == null || _hits.Count == 0 || _rayOrigin == null) return;

            VIZCore3DX.NET.Data.Vector3D far = _hits[0].Position;
            float farDistance = _hits[0].Distance;
            float[] points = new float[_hits.Count * 3];
            for (int i = 0; i < _hits.Count; i++)
            {
                VIZCore3DX.NET.Data.Vector3D p = _hits[i].Position;
                points[i * 3 + 0] = p.X; points[i * 3 + 1] = p.Y; points[i * 3 + 2] = p.Z;
                if (_hits[i].Distance > farDistance) { far = p; farDistance = _hits[i].Distance; }
            }

            float[] line = new float[] { _rayOrigin.X, _rayOrigin.Y, _rayOrigin.Z, far.X, far.Y, far.Z };

            VIZCore3DX.NET.Data.DataSetOptions lineOptions = new VIZCore3DX.NET.Data.DataSetOptions();
            lineOptions.Color = System.Drawing.Color.FromArgb(255, 220, 0);
            lineOptions.LineWidth = 2f;
            lineOptions.AlwaysOnTop = true;
            _rayLine = vizcore3dx.View.Effect.AddLineSet(line, null, null, lineOptions);

            VIZCore3DX.NET.Data.DataSetOptions pointOptions = new VIZCore3DX.NET.Data.DataSetOptions();
            pointOptions.Color = System.Drawing.Color.FromArgb(255, 0, 0);
            pointOptions.PointSizeMm = 40f;
            pointOptions.AlwaysOnTop = true;
            _hitPoints = vizcore3dx.View.Effect.AddPointCloud(points, null, pointOptions);
        }

        private void HideRay()
        {
            if (_rayLine != 0)
            {
                vizcore3dx.View.Effect.RemoveDataSet(_rayLine);
                _rayLine = 0;
            }

            if (_hitPoints != 0)
            {
                vizcore3dx.View.Effect.RemoveDataSet(_hitPoints);
                _hitPoints = 0;
            }
        }

        private void ClearResults()
        {
            HideRay();
            HideArea();
            _lastArea = System.Drawing.Rectangle.Empty;
            _areaNodes = null;
            lblArea.Text = "영역 조회 결과 : -";
            _picks = null;
            _hits = null;
            _pickIndex = 0;
            FillPicks();
            FillHits();
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
        #endregion
    }
}
