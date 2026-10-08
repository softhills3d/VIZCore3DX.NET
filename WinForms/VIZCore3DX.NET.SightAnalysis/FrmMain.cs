using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.SightAnalysis
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 분석 결과 목록 (4. 결과 표와 같은 순서)
        private List<VIZCore3DX.NET.Data.SightMapResult> _results = new List<VIZCore3DX.NET.Data.SightMapResult>();

        // 시연용 벽의 루트 노드 (5. 정리에서 삭제)
        private VIZCore3DX.NET.Data.Node _wallRoot;

        // 옵저버에서 히트 지점까지 그린 광선 (0 이면 없음)
        private uint _rayLines;

        // 시야 범위(원뿔·구) 선 (0 이면 없음)
        private uint _rangeLines;

        public FrmMain()
        {
            InitializeComponent();

            // 뷰어와 무관한 콤보 항목은 생성자에서 채웁니다.
            cmbConeDirection.Items.AddRange(new object[] { "+X", "-X", "+Y", "-Y", "+Z", "-Z" });
            cmbConeDirection.SelectedIndex = 0;

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
            ShowRibbonTabs(VIZCore3DX.NET.Data.ToolbarKind.Observer);
            ShowAttributeTabs();

            SetStatus("모델을 열어 주세요.");
        }

        #region 1. 모델
        // 시야를 분석할 모델을 엽니다. 옵저버 위치는 모델 중심으로 채웁니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            _wallRoot = null;
            FillPositionFromModelCenter();
            SetStatus("모델을 열었습니다.");
        }
        #endregion

        #region 2. 설정
        // 옵저버 위치를 모델 상자의 중심으로 되돌립니다.
        private void btnCenter_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            FillPositionFromModelCenter();
            SetStatus("옵저버 위치를 모델 중심으로 설정했습니다.");
        }

        // 결과를 눈으로 확인하기 위한 시연 벽을 만듭니다.
        // 옵저버를 모델 밖 +X 5m 에 두고 모델을 향해(-X) 60° 원뿔로 보게 하되, 2m 앞에 2m x 2m 벽을 세워 시야 가운데를 가립니다.
        // 광선이 처음 닿은 개체가 "보임", 원뿔 안에 있지만 벽에 가려 한 번도 닿지 않은 개체가 "사각"입니다.
        private void btnDemoWall_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            DeleteDemoWall();

            VIZCore3DX.NET.Data.BoundBox3D box = vizcore3dx.Model.BoundBox;
            VIZCore3DX.NET.Data.Vector3D observer = new VIZCore3DX.NET.Data.Vector3D(box.MaxX + 5000f, box.CenterY, box.CenterZ);
            VIZCore3DX.NET.Data.Vector3D wallCenter = new VIZCore3DX.NET.Data.Vector3D(observer.X - 2000f, observer.Y, observer.Z);
            VIZCore3DX.NET.Data.Vector3D wallSize = new VIZCore3DX.NET.Data.Vector3D(200f, 2000f, 2000f);

            _wallRoot = vizcore3dx.Object3D.Primitive.AddRootNode("ObserverDemo");
            VIZCore3DX.NET.Data.Node wall = vizcore3dx.Object3D.Primitive.AddPrimitiveBox(_wallRoot, "ObserverWall", false, VIZCore3DX.NET.Data.AxisAnchor.Center,
                System.Drawing.Color.Gray, wallSize, wallCenter);
            if (wall == null)
            {
                _wallRoot = null;
                SetStatus("시연 벽을 만들지 못했습니다.");
                return;
            }

            numPosX.Value = (decimal)observer.X;
            numPosY.Value = (decimal)observer.Y;
            numPosZ.Value = (decimal)observer.Z;
            numMaxDistance.Value = Math.Min(numMaxDistance.Maximum, (decimal)(5000f + box.LengthX));
            chkCone.Checked = true;
            cmbConeDirection.SelectedIndex = 1;   // -X : 모델 쪽
            numConeAngle.Value = 60;
            chkUseCache.Checked = false;

            // 벽이 모델 밖에 있으므로 전체가 보이도록 카메라를 맞춥니다.
            vizcore3dx.View.FitToView();

            SetStatus("시연 벽을 만들었습니다. 분석하면 벽에 가려진 개체는 사각, 광선이 닿은 개체는 보임입니다.");
        }

        // 원뿔 시야를 끄면 방향·각도 입력을 잠급니다.
        private void chkCone_CheckedChanged(object sender, EventArgs e)
        {
            cmbConeDirection.Enabled = chkCone.Checked;
            numConeAngle.Enabled = chkCone.Checked;
            setup_Changed(sender, e);
        }

        // 시야 범위(원뿔 또는 전방향 구)를 선으로 그려 어디까지 판정하는지 보여 줍니다.
        private void chkRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRange.Checked) ShowRange();
            else HideRange();
        }

        // 위치·거리·원뿔 입력이 바뀌면 표시 중인 범위를 다시 그립니다.
        private void setup_Changed(object sender, EventArgs e)
        {
            if (chkRange.Checked) ShowRange();
        }
        #endregion

        #region 3. 실행
        // 입력한 옵션으로 시야를 분석하고, 결과를 목록에 추가한 뒤 화면에 표시합니다.
        private async void btnRun_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;
            if (vizcore3dx.Observer.IsAnalyzing) return;

            VIZCore3DX.NET.Data.ObserverOptions options = BuildOptions();
            Progress<int> progress = new Progress<int>(percent => progressBar.Value = Math.Max(0, Math.Min(100, percent)));

            SetRunning(true);
            SetStatus("분석 중입니다. 첫 분석은 장애물 추출로 시간이 걸릴 수 있습니다.");

            VIZCore3DX.NET.Data.SightMapResult result;
            try
            {
                result = await vizcore3dx.Observer.AnalyzeAsync(options, progress);
            }
            finally
            {
                // 예외가 나도 실행 버튼 잠금 해제
                SetRunning(false);
            }

            if (result.IsCanceled)
            {
                SetStatus(string.Format("취소했습니다. ({0:N2}초)", result.ElapsedSeconds));
                return;
            }
            if (!result.IsSucceeded)
            {
                SetStatus(string.Format("분석 실패 : {0}", vizcore3dx.Observer.LastOperationResult));
                return;
            }

            _results.Add(result);
            dgvResults.Rows.Add(_results.Count, result.RayCount, result.HitCount, result.VisibleNodes.Count, result.HiddenNodes.Count, result.ElapsedSeconds.ToString("N2"));
            dgvResults.ClearSelection();
            dgvResults.Rows[dgvResults.Rows.Count - 1].Selected = true;

            vizcore3dx.Observer.Show(result);
            if (chkRays.Checked) ShowRays(result);
            SetStatus(string.Format("분석 완료 : 광선 {0:N0}, 히트 {1:N0}, 보임 {2}, 사각 {3}", result.RayCount, result.HitCount, result.VisibleNodes.Count, result.HiddenNodes.Count));
        }

        // 진행 중인 분석을 취소합니다. 취소된 결과는 IsCanceled 가 true 입니다.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            vizcore3dx.Observer.CancelAnalyzeAsync();
        }
        #endregion

        #region 4. 결과
        // 선택한 결과의 보이는 개체와 사각 개체를 아래 표에 나열합니다.
        private void dgvResults_SelectionChanged(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.SightMapResult result = SelectedResult();
            if (result != null) FillNodes(result);
        }

        // 선택한 결과의 히트 지점을 화면에 다시 표시합니다.
        private void btnShow_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.SightMapResult result = SelectedResult();
            if (result == null)
            {
                SetStatus("표시할 결과를 목록에서 선택하세요.");
                return;
            }

            vizcore3dx.Observer.Show(result);
            if (chkRays.Checked) ShowRays(result);
            SetStatus("선택한 결과를 표시했습니다.");
        }

        // 표에서 고른 결과(2개 미만이면 전체)를 하나로 합쳐 표시합니다.
        // 어느 옵저버에서든 보인 개체는 보임(히트 = 본 옵저버 수), 어디서도 안 보인 개체만 사각으로 남습니다.
        private void btnUnion_Click(object sender, EventArgs e)
        {
            List<VIZCore3DX.NET.Data.SightMapResult> picked = SelectedResults();
            if (picked.Count < 2) picked = _results;
            if (picked.Count < 2)
            {
                SetStatus("합집합은 결과가 2개 이상일 때 만들 수 있습니다. 위치를 바꿔 다시 분석하세요.");
                return;
            }

            VIZCore3DX.NET.Data.SightMapResult union = vizcore3dx.Observer.Union(picked);
            if (!union.IsSucceeded)
            {
                SetStatus(string.Format("합집합 실패 : {0}", vizcore3dx.Observer.LastOperationResult));
                return;
            }

            FillNodes(union);
            vizcore3dx.Observer.Show(union);
            HideRays();   // 합집합에는 히트 지점이 없습니다.
            SetStatus(string.Format("합집합 {0}개 : 보임 {1}, 사각 {2}", picked.Count, union.VisibleNodes.Count, union.HiddenNodes.Count));
        }

        // 광선 표시를 켜고 끕니다. 켜면 선택한 결과의 광선을 다시 그립니다.
        private void chkRays_CheckedChanged(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.SightMapResult result = SelectedResult();
            if (chkRays.Checked && result != null) ShowRays(result);
            else HideRays();
        }
        #endregion

        #region 5. 정리
        // 화면의 옵저버 표식을 숨깁니다. 결과 목록은 남습니다.
        private void btnHide_Click(object sender, EventArgs e)
        {
            vizcore3dx.Observer.Hide();
            HideRays();
            SetStatus("표식을 숨겼습니다.");
        }

        // 표식을 숨기고 결과 목록을 비웁니다.
        private void btnClear_Click(object sender, EventArgs e)
        {
            vizcore3dx.Observer.Hide();
            HideRays();
            _results.Clear();
            dgvResults.Rows.Clear();
            dgvNodes.Rows.Clear();
            SetStatus("결과를 비웠습니다.");
        }

        // 시연 벽을 모델에서 삭제합니다.
        private void btnDeleteWall_Click(object sender, EventArgs e)
        {
            if (_wallRoot == null)
            {
                SetStatus("삭제할 시연 벽이 없습니다.");
                return;
            }

            DeleteDemoWall();
            SetStatus("시연 벽을 삭제했습니다. 이후 분석은 장애물 캐시를 해제한 채 실행하세요.");
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

        // 분석 중에는 실행 버튼을 잠그고 취소 버튼만 엽니다.
        private void SetRunning(bool running)
        {
            btnRun.Enabled = !running;
            btnCancel.Enabled = running;
            grpSetup.Enabled = !running;
            if (!running) progressBar.Value = 0;
        }

        // 화면 입력을 분석 옵션으로 옮깁니다.
        private VIZCore3DX.NET.Data.ObserverOptions BuildOptions()
        {
            VIZCore3DX.NET.Data.ObserverOptions options = new VIZCore3DX.NET.Data.ObserverOptions();
            options.Position = new VIZCore3DX.NET.Data.Vector3D((float)numPosX.Value, (float)numPosY.Value, (float)numPosZ.Value);
            options.MaxDistanceMm = (double)numMaxDistance.Value;
            options.AngularStepDeg = (double)numAngularStep.Value;
            options.UseObstacleCache = chkUseCache.Checked;

            if (chkCone.Checked)
            {
                options.ConeDirection = ConeDirection();
                options.ConeAngleDeg = (double)numConeAngle.Value;
            }

            return options;
        }

        // 콤보 선택(+X, -X, +Y, -Y, +Z, -Z)을 방향 벡터로 바꿉니다.
        private VIZCore3DX.NET.Data.Vector3D ConeDirection()
        {
            switch (cmbConeDirection.SelectedIndex)
            {
                case 1: return new VIZCore3DX.NET.Data.Vector3D(-1, 0, 0);
                case 2: return new VIZCore3DX.NET.Data.Vector3D(0, 1, 0);
                case 3: return new VIZCore3DX.NET.Data.Vector3D(0, -1, 0);
                case 4: return new VIZCore3DX.NET.Data.Vector3D(0, 0, 1);
                case 5: return new VIZCore3DX.NET.Data.Vector3D(0, 0, -1);
                default: return new VIZCore3DX.NET.Data.Vector3D(1, 0, 0);
            }
        }

        private void FillPositionFromModelCenter()
        {
            VIZCore3DX.NET.Data.BoundBox3D box = vizcore3dx.Model.BoundBox;
            numPosX.Value = (decimal)box.CenterX;
            numPosY.Value = (decimal)box.CenterY;
            numPosZ.Value = (decimal)box.CenterZ;
        }

        private VIZCore3DX.NET.Data.SightMapResult SelectedResult()
        {
            List<VIZCore3DX.NET.Data.SightMapResult> picked = SelectedResults();
            return picked.Count == 0 ? null : picked[0];
        }

        // 표에서 고른 행들의 결과 (표 순서)
        private List<VIZCore3DX.NET.Data.SightMapResult> SelectedResults()
        {
            List<VIZCore3DX.NET.Data.SightMapResult> picked = new List<VIZCore3DX.NET.Data.SightMapResult>();
            for (int i = 0; i < _results.Count && i < dgvResults.Rows.Count; i++)
                if (dgvResults.Rows[i].Selected) picked.Add(_results[i]);
            return picked;
        }

        // 보이는 개체(히트 수·비율)를 먼저, 사각 개체를 뒤에 나열합니다.
        // 사각 개체는 수만 개가 될 수 있으므로 행을 미리 만들어 AddRange 로 한 번에 넣습니다.
        private void FillNodes(VIZCore3DX.NET.Data.SightMapResult result)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>(result.VisibleNodes.Count + result.HiddenNodes.Count);

            foreach (VIZCore3DX.NET.Data.SightMapNodeHit hit in result.VisibleNodes)
                rows.Add(CreateNodeRow(hit.Node.NodeName, "보임", hit.HitCount, hit.Ratio.ToString("P1")));

            foreach (VIZCore3DX.NET.Data.Node node in result.HiddenNodes)
                rows.Add(CreateNodeRow(node.NodeName, "사각", 0, ""));

            dgvNodes.SuspendLayout();
            try
            {
                dgvNodes.Rows.Clear();
                dgvNodes.Rows.AddRange(rows.ToArray());
            }
            finally
            {
                dgvNodes.ResumeLayout();
            }
        }

        private DataGridViewRow CreateNodeRow(string name, string kind, int hits, string ratio)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvNodes, name, kind, hits, ratio);
            return row;
        }

        // 옵저버 위치에서 히트 지점까지 선을 그려 광선이 어디에 닿았는지 보여 줍니다.
        private void ShowRays(VIZCore3DX.NET.Data.SightMapResult result)
        {
            HideRays();
            if (result.HitPoints.Count == 0) return;

            VIZCore3DX.NET.Data.Vector3D origin = result.OptionsUsed.Position;
            float[] xyz = new float[result.HitPoints.Count * 6];
            for (int i = 0; i < result.HitPoints.Count; i++)
            {
                VIZCore3DX.NET.Data.Vector3D hit = result.HitPoints[i];
                xyz[i * 6 + 0] = origin.X; xyz[i * 6 + 1] = origin.Y; xyz[i * 6 + 2] = origin.Z;
                xyz[i * 6 + 3] = hit.X; xyz[i * 6 + 4] = hit.Y; xyz[i * 6 + 5] = hit.Z;
            }

            VIZCore3DX.NET.Data.DataSetOptions options = new VIZCore3DX.NET.Data.DataSetOptions();
            options.Color = System.Drawing.Color.FromArgb(255, 220, 0);
            options.Opacity = 0.5f;

            _rayLines = vizcore3dx.View.Effect.AddLineSet(xyz, null, null, options);
        }

        private void HideRays()
        {
            if (_rayLines == 0) return;

            vizcore3dx.View.Effect.RemoveDataSet(_rayLines);
            _rayLines = 0;
        }

        // 현재 입력값으로 시야 범위를 그립니다. 원뿔은 모선·가장자리 링, 전방향은 세 대원입니다.
        private void ShowRange()
        {
            HideRange();

            VIZCore3DX.NET.Data.Vector3D origin = new VIZCore3DX.NET.Data.Vector3D((float)numPosX.Value, (float)numPosY.Value, (float)numPosZ.Value);
            double radius = (double)numMaxDistance.Value;
            List<float> xyz = new List<float>();
            List<int> sizes = new List<int>();

            if (chkCone.Checked) AppendCone(origin, ConeDirection(), radius, (double)numConeAngle.Value, xyz, sizes);
            else AppendSphere(origin, radius, xyz, sizes);

            VIZCore3DX.NET.Data.DataSetOptions options = new VIZCore3DX.NET.Data.DataSetOptions();
            options.Color = System.Drawing.Color.FromArgb(0, 200, 255);
            options.Opacity = 0.7f;

            _rangeLines = vizcore3dx.View.Effect.AddLineSet(xyz.ToArray(), sizes.ToArray(), null, options);
        }

        private void HideRange()
        {
            if (_rangeLines == 0) return;

            vizcore3dx.View.Effect.RemoveDataSet(_rangeLines);
            _rangeLines = 0;
        }

        private const int RingSegments = 48;

        // 원뿔: 축 방향으로 r·cos(반각) 떨어진 곳에 반지름 r·sin(반각) 링을 두고, 정점에서 링까지 모선 8개를 잇습니다.
        private static void AppendCone(VIZCore3DX.NET.Data.Vector3D origin, VIZCore3DX.NET.Data.Vector3D axis, double radius, double halfAngleDeg, List<float> xyz, List<int> sizes)
        {
            double half = VIZCore3DX.NET.Utility.AngleFormatHelper.DegreesToRadians(halfAngleDeg);
            VIZCore3DX.NET.Data.Vector3D u, v;
            MakeBasis(axis, out u, out v);

            VIZCore3DX.NET.Data.Vector3D ringCenter = origin + axis * (float)(radius * Math.Cos(half));
            double ringRadius = radius * Math.Sin(half);
            List<VIZCore3DX.NET.Data.Vector3D> ring = Circle(ringCenter, u, v, ringRadius);
            AppendPolyline(ring, xyz, sizes);

            for (int i = 0; i < 8; i++)
                AppendPolyline(new List<VIZCore3DX.NET.Data.Vector3D> { origin, ring[i * RingSegments / 8] }, xyz, sizes);
        }

        // 전방향: 세 좌표평면의 대원.
        private static void AppendSphere(VIZCore3DX.NET.Data.Vector3D origin, double radius, List<float> xyz, List<int> sizes)
        {
            VIZCore3DX.NET.Data.Vector3D x = new VIZCore3DX.NET.Data.Vector3D(1, 0, 0);
            VIZCore3DX.NET.Data.Vector3D y = new VIZCore3DX.NET.Data.Vector3D(0, 1, 0);
            VIZCore3DX.NET.Data.Vector3D z = new VIZCore3DX.NET.Data.Vector3D(0, 0, 1);
            AppendPolyline(Circle(origin, x, y, radius), xyz, sizes);
            AppendPolyline(Circle(origin, y, z, radius), xyz, sizes);
            AppendPolyline(Circle(origin, z, x, radius), xyz, sizes);
        }

        private static List<VIZCore3DX.NET.Data.Vector3D> Circle(VIZCore3DX.NET.Data.Vector3D center, VIZCore3DX.NET.Data.Vector3D u, VIZCore3DX.NET.Data.Vector3D v, double radius)
        {
            List<VIZCore3DX.NET.Data.Vector3D> points = new List<VIZCore3DX.NET.Data.Vector3D>(RingSegments + 1);
            for (int i = 0; i <= RingSegments; i++)
            {
                double t = 2.0 * Math.PI * i / RingSegments;
                points.Add(center + u * (float)(radius * Math.Cos(t)) + v * (float)(radius * Math.Sin(t)));
            }
            return points;
        }

        // 축에 수직인 두 단위 벡터를 만듭니다.
        private static void MakeBasis(VIZCore3DX.NET.Data.Vector3D axis, out VIZCore3DX.NET.Data.Vector3D u, out VIZCore3DX.NET.Data.Vector3D v)
        {
            VIZCore3DX.NET.Data.Vector3D helper = Math.Abs(axis.Z) < 0.9f ? new VIZCore3DX.NET.Data.Vector3D(0, 0, 1) : new VIZCore3DX.NET.Data.Vector3D(1, 0, 0);
            u = axis.Cross(helper).GetNormalized();
            v = axis.Cross(u).GetNormalized();
        }

        private static void AppendPolyline(List<VIZCore3DX.NET.Data.Vector3D> points, List<float> xyz, List<int> sizes)
        {
            foreach (VIZCore3DX.NET.Data.Vector3D p in points) { xyz.Add(p.X); xyz.Add(p.Y); xyz.Add(p.Z); }
            sizes.Add(points.Count);
        }

        private void DeleteDemoWall()
        {
            if (_wallRoot == null) return;

            vizcore3dx.Object3D.Delete(new List<VIZCore3DX.NET.Data.Node> { _wallRoot });
            _wallRoot = null;
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
