using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Observer
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 목록 행 ↔ 옵저버 ID (표와 같은 순서)
        private List<int> _rowIds = new List<int>();

        // 목록 갱신 중에는 선택 이벤트를 되돌려 보내지 않습니다.
        private bool _syncing;

        // 마지막 분석 결과들 (광선 표시 토글용, 옵저버마다 하나)
        private List<VIZCore3DX.NET.Data.SightMapResult> _lastResults = new List<VIZCore3DX.NET.Data.SightMapResult>();

        // 화면에 그린 광선·시야 범위 선 (0 이면 없음)
        private uint _rayLines;
        private uint _rangeLines;

        public FrmMain()
        {
            InitializeComponent();

            // 뷰어와 무관한 콤보 항목은 생성자에서 채웁니다.
            cmbDirection.Items.AddRange(new object[] { "+X", "-X", "+Y", "-Y", "+Z", "-Z" });
            cmbDirection.SelectedIndex = 1;

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
            InitializeVIZCore3DXEvent();
        }

        private void InitializeVIZCore3DX()
        {
            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs(VIZCore3DX.NET.Data.ToolbarKind.Observer);
            ShowAttributeTabs();

            SetStatus("모델을 열어 주세요.");
        }

        // 옵저버 목록은 뷰어가 소유하므로, 변경 이벤트를 받아 표를 다시 그립니다.
        // 내장 옵저버 탭·우클릭 메뉴로 바뀐 것도 같은 이벤트로 들어옵니다.
        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.Observer.OnObserverCreatedEvent -= Observer_OnObserverCreatedEvent;
            vizcore3dx.Observer.OnObserverCreatedEvent += Observer_OnObserverCreatedEvent;
            vizcore3dx.Observer.OnObserverDeletedEvent -= Observer_OnObserverDeletedEvent;
            vizcore3dx.Observer.OnObserverDeletedEvent += Observer_OnObserverDeletedEvent;
            vizcore3dx.Observer.OnObserverClearedEvent -= Observer_OnObserverClearedEvent;
            vizcore3dx.Observer.OnObserverClearedEvent += Observer_OnObserverClearedEvent;
            vizcore3dx.Observer.OnObserverChangedEvent -= Observer_OnObserverChangedEvent;
            vizcore3dx.Observer.OnObserverChangedEvent += Observer_OnObserverChangedEvent;
            vizcore3dx.Observer.OnObserverSelectedChangedEvent -= Observer_OnObserverSelectedChangedEvent;
            vizcore3dx.Observer.OnObserverSelectedChangedEvent += Observer_OnObserverSelectedChangedEvent;
            vizcore3dx.Observer.OnObserverVisibleChangedEvent -= Observer_OnObserverVisibleChangedEvent;
            vizcore3dx.Observer.OnObserverVisibleChangedEvent += Observer_OnObserverVisibleChangedEvent;
        }

        private void Observer_OnObserverCreatedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ObserverEventArgs e)
        {
            RunOnUi(RefreshList);
        }

        private void Observer_OnObserverDeletedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ObserverEventArgs e)
        {
            RunOnUi(RefreshList);
        }

        private void Observer_OnObserverClearedEvent(object sender, EventArgs e)
        {
            RunOnUi(RefreshList);
        }

        private void Observer_OnObserverChangedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ObserverChangedEventArgs e)
        {
            RunOnUi(RefreshList);
        }

        // 뷰에서 표식을 우클릭해도 선택이 바뀌므로 표의 선택 행을 맞춥니다.
        private void Observer_OnObserverSelectedChangedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ObserverEventArgs e)
        {
            RunOnUi(SyncSelectionFromViewer);
        }

        private void Observer_OnObserverVisibleChangedEvent(object sender, VIZCore3DX.NET.Event.EventManager.ObserverEventArgs e)
        {
            RunOnUi(RefreshList);
        }

        #region 1. 모델
        // 옵저버를 배치할 모델을 엽니다. 옵저버 위치 입력은 모델 중심으로 채웁니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            VIZCore3DX.NET.Data.BoundBox3D box = vizcore3dx.Model.BoundBox;
            numPosX.Value = Clamp(numPosX, (decimal)box.CenterX);
            numPosY.Value = Clamp(numPosY, (decimal)box.CenterY);
            numPosZ.Value = Clamp(numPosZ, (decimal)box.CenterZ);

            _rayLines = 0;
            _rangeLines = 0;
            _lastResults.Clear();
            RefreshList();
            SetStatus("모델을 열었습니다.");
        }
        #endregion

        #region 2. 옵저버 추가
        // 입력한 좌표와 방향에 옵저버를 추가합니다. 표식은 뷰에 바로 그려집니다.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            VIZCore3DX.NET.Data.Vector3D position = new VIZCore3DX.NET.Data.Vector3D((float)numPosX.Value, (float)numPosY.Value, (float)numPosZ.Value);
            int id = vizcore3dx.Observer.Add(position, Direction(), txtName.Text);
            if (id < 0)
            {
                SetStatus("옵저버를 추가하지 못했습니다.");
                return;
            }

            ApplySight(id, (double)numMaxDistance.Value, (double)numAngularStep.Value, (double)numConeAngle.Value);
            vizcore3dx.Observer.SetSelectedOnly(id);
            SetStatus(string.Format("옵저버 {0}을(를) 추가했습니다.", id));
        }

        // 현재 카메라의 눈 위치와 시선 방향으로 옵저버를 추가합니다.
        private void btnAddFromCamera_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            int id = vizcore3dx.Observer.AddFromCamera(txtName.Text);
            if (id < 0)
            {
                SetStatus("카메라 정보를 읽지 못했습니다.");
                return;
            }

            ApplySight(id, (double)numMaxDistance.Value, (double)numAngularStep.Value, (double)numConeAngle.Value);
            vizcore3dx.Observer.SetSelectedOnly(id);
            SetStatus(string.Format("카메라 위치에 옵저버 {0}을(를) 추가했습니다.", id));
        }
        #endregion

        #region 3. 목록
        // 표에서 고른 행들을 뷰어의 선택 상태로 보냅니다. 선택된 표식은 밝은 색과 흰 테두리로 그려집니다.
        // 여러 행을 고르면 분석 시 합집합이 됩니다.
        private void dgvObservers_SelectionChanged(object sender, EventArgs e)
        {
            List<int> ids = SelectedIds();
            if (ids.Count > 0) LoadSight(ids[0]);
            if (chkRange.Checked) ShowRange(ids);

            if (_syncing) return;

            _syncing = true;
            try
            {
                for (int i = 0; i < _rowIds.Count; i++)
                    vizcore3dx.Observer.SetSelected(_rowIds[i], dgvObservers.Rows[i].Selected);
            }
            finally
            {
                _syncing = false;
            }
        }

        // 카메라를 선택한 옵저버의 눈 위치와 시선 방향으로 옮깁니다.
        private void btnMoveCamera_Click(object sender, EventArgs e)
        {
            int id = FirstSelectedId();
            if (id < 0) { SetStatus("목록에서 옵저버를 선택하세요."); return; }

            vizcore3dx.Observer.MoveCameraTo(id);
            SetStatus(string.Format("옵저버 {0} 시점으로 이동했습니다.", id));
        }

        // 선택한 옵저버의 표식을 보이거나 숨깁니다. 항목은 남아 있어 분석은 그대로 됩니다.
        private void btnToggleVisible_Click(object sender, EventArgs e)
        {
            List<int> ids = SelectedIds();
            if (ids.Count == 0) { SetStatus("목록에서 옵저버를 선택하세요."); return; }

            foreach (int id in ids)
            {
                VIZCore3DX.NET.Data.ObserverItem item = vizcore3dx.Observer.GetItem(id);
                if (item != null) vizcore3dx.Observer.SetVisible(id, !item.IsVisible);
            }
        }

        // 선택한 옵저버를 삭제합니다.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> ids = SelectedIds();
            if (ids.Count == 0) { SetStatus("목록에서 옵저버를 선택하세요."); return; }

            foreach (int id in ids) vizcore3dx.Observer.Delete(id);
            SetStatus(string.Format("옵저버 {0}개를 삭제했습니다.", ids.Count));
        }
        #endregion

        #region 4. 분석
        // 선택한 옵저버마다 시야를 분석하고, 2개 이상이면 합집합으로 합쳐 뷰에 칠합니다.
        // 화면의 시야 3값은 분석 직전에 옵저버에 기록되므로 다음 분석과 저장에도 유지됩니다.
        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            List<int> ids = SelectedIds();
            if (ids.Count == 0) { SetStatus("목록에서 옵저버를 선택하세요."); return; }
            if (vizcore3dx.Observer.IsAnalyzing) return;

            foreach (int id in ids)
                ApplySight(id, (double)numDistance.Value, (double)numStep.Value, (double)numCone.Value);
            if (chkRange.Checked) ShowRange(ids);

            Progress<int> progress = new Progress<int>(percent => progressBar.Value = Math.Max(0, Math.Min(100, percent)));
            List<VIZCore3DX.NET.Data.SightMapResult> results = new List<VIZCore3DX.NET.Data.SightMapResult>();

            SetRunning(true);
            try
            {
                foreach (int id in ids)
                {
                    SetStatus(string.Format("옵저버 {0} 분석 중입니다. ({1}/{2})", id, results.Count + 1, ids.Count));
                    VIZCore3DX.NET.Data.SightMapResult result = await vizcore3dx.Observer.AnalyzeAsync(id, progress);

                    if (result.IsCanceled) { SetStatus("취소했습니다."); return; }
                    if (!result.IsSucceeded)
                    {
                        SetStatus(string.Format("옵저버 {0} 분석 실패 : {1}", id, vizcore3dx.Observer.LastOperationResult));
                        return;
                    }
                    results.Add(result);
                }
            }
            finally
            {
                SetRunning(false);
            }

            VIZCore3DX.NET.Data.SightMapResult shown = results.Count == 1 ? results[0] : vizcore3dx.Observer.Union(results);
            if (!shown.IsSucceeded)
            {
                SetStatus(string.Format("합집합 실패 : {0}", vizcore3dx.Observer.LastOperationResult));
                return;
            }

            _lastResults = results;
            vizcore3dx.Observer.Show(shown);
            if (chkRays.Checked) ShowRays(results);

            int rays = 0, hits = 0;
            foreach (VIZCore3DX.NET.Data.SightMapResult r in results) { rays += r.RayCount; hits += r.HitCount; }
            SetStatus(string.Format("{0} : 광선 {1:N0}, 히트 {2:N0}, 보임 {3}, 사각 {4}",
                results.Count == 1 ? "옵저버 " + ids[0] : "합집합 " + results.Count + "개", rays, hits, shown.VisibleNodes.Count, shown.HiddenNodes.Count));
        }

        // 진행 중인 분석을 취소합니다.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            vizcore3dx.Observer.CancelAnalyzeAsync();
        }

        // 분석 결과 표시(개체 색·히트 점·광선)를 지웁니다. 옵저버 표식은 남습니다.
        private void btnHideResult_Click(object sender, EventArgs e)
        {
            vizcore3dx.Observer.Hide();
            HideRays();
            SetStatus("분석 결과 표시를 지웠습니다.");
        }

        // 광선 표시를 켜고 끕니다. 켜면 마지막 결과의 광선을 다시 그립니다.
        private void chkRays_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRays.Checked && _lastResults.Count > 0) ShowRays(_lastResults);
            else HideRays();
        }

        // 시야 범위(원뿔 또는 전방향 구)를 선으로 그려 어디까지 판정하는지 보여 줍니다.
        private void chkRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRange.Checked) ShowRange(SelectedIds());
            else HideRange();
        }
        #endregion

        #region 5. 파일·정리
        // 옵저버 전체를 JSON 파일로 저장합니다. ID 와 Tag 는 저장되지 않습니다.
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Observer.Count == 0) { SetStatus("저장할 옵저버가 없습니다."); return; }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Observer JSON (*.json)|*.json";
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                bool ok = vizcore3dx.Observer.Export(dialog.FileName);
                SetStatus(ok ? "옵저버를 저장했습니다." : "저장하지 못했습니다.");
            }
        }

        // JSON 파일의 옵저버를 현재 목록에 덧붙입니다. ID 는 새로 부여됩니다.
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Observer JSON (*.json)|*.json";
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                List<int> ids = vizcore3dx.Observer.Import(dialog.FileName, VIZCore3DX.NET.Data.ObserverImportMode.Append);
                SetStatus(ids.Count > 0 ? string.Format("옵저버 {0}개를 불러왔습니다.", ids.Count) : "불러온 옵저버가 없습니다.");
            }
        }

        // 분석 결과 표시를 지우고 옵저버를 전부 삭제합니다.
        private void btnClear_Click(object sender, EventArgs e)
        {
            vizcore3dx.Observer.Hide();
            HideRays();
            HideRange();
            _lastResults.Clear();
            vizcore3dx.Observer.Clear();
            SetStatus("옵저버를 모두 삭제했습니다.");
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

        // 분석 중에는 분석 버튼을 잠그고 취소 버튼만 엽니다.
        private void SetRunning(bool running)
        {
            btnAnalyze.Enabled = !running;
            btnCancel.Enabled = running;
            if (!running) progressBar.Value = 0;
        }

        // 시야 3값을 옵저버에 기록합니다. 원뿔 반각 0 은 전방향입니다.
        private void ApplySight(int id, double maxDistance, double angularStep, double coneAngle)
        {
            VIZCore3DX.NET.Data.ObserverItem item = vizcore3dx.Observer.GetItem(id);
            if (item == null) return;

            item.MaxDistanceMm = maxDistance;
            item.AngularStepDeg = angularStep;
            item.ConeAngleDeg = coneAngle;
        }

        // 선택한 옵저버의 시야 3값을 분석 입력에 보여 줍니다.
        private void LoadSight(int id)
        {
            VIZCore3DX.NET.Data.ObserverItem item = vizcore3dx.Observer.GetItem(id);
            if (item == null) return;

            numDistance.Value = Clamp(numDistance, (decimal)item.MaxDistanceMm);
            numStep.Value = Clamp(numStep, (decimal)item.AngularStepDeg);
            numCone.Value = Clamp(numCone, (decimal)item.ConeAngleDeg);
        }

        private static decimal Clamp(NumericUpDown control, decimal value)
        {
            return Math.Max(control.Minimum, Math.Min(control.Maximum, value));
        }

        // 콤보 선택(+X, -X, +Y, -Y, +Z, -Z)을 방향 벡터로 바꿉니다.
        private VIZCore3DX.NET.Data.Vector3D Direction()
        {
            switch (cmbDirection.SelectedIndex)
            {
                case 1: return new VIZCore3DX.NET.Data.Vector3D(-1, 0, 0);
                case 2: return new VIZCore3DX.NET.Data.Vector3D(0, 1, 0);
                case 3: return new VIZCore3DX.NET.Data.Vector3D(0, -1, 0);
                case 4: return new VIZCore3DX.NET.Data.Vector3D(0, 0, 1);
                case 5: return new VIZCore3DX.NET.Data.Vector3D(0, 0, -1);
                default: return new VIZCore3DX.NET.Data.Vector3D(1, 0, 0);
            }
        }

        private List<int> SelectedIds()
        {
            List<int> ids = new List<int>();
            for (int i = 0; i < _rowIds.Count; i++)
                if (dgvObservers.Rows[i].Selected) ids.Add(_rowIds[i]);
            return ids;
        }

        private int FirstSelectedId()
        {
            List<int> ids = SelectedIds();
            return ids.Count == 0 ? -1 : ids[0];
        }

        // 뷰어의 옵저버 목록을 표에 다시 채우고, 뷰어의 선택 상태를 표에 맞춥니다.
        private void RefreshList()
        {
            _syncing = true;
            try
            {
                dgvObservers.Rows.Clear();
                _rowIds.Clear();

                foreach (VIZCore3DX.NET.Data.ObserverItem item in vizcore3dx.Observer.Items)
                {
                    VIZCore3DX.NET.Data.Vector3D p = item.Position;
                    string sight = item.ConeAngleDeg > 0
                        ? string.Format("{0:N0}mm / {1}°", item.MaxDistanceMm, item.ConeAngleDeg)
                        : string.Format("{0:N0}mm / 전방향", item.MaxDistanceMm);
                    dgvObservers.Rows.Add(item.ID, item.Name, string.Format("{0:N0}, {1:N0}, {2:N0}", p.X, p.Y, p.Z), sight, item.IsVisible ? "보임" : "숨김");
                    _rowIds.Add(item.ID);
                }
            }
            finally
            {
                _syncing = false;
            }

            SyncSelectionFromViewer();
        }

        private void SyncSelectionFromViewer()
        {
            if (_syncing) return;

            List<int> selected = vizcore3dx.Observer.GetSelected();

            _syncing = true;
            try
            {
                dgvObservers.ClearSelection();
                for (int i = 0; i < _rowIds.Count; i++)
                    if (selected.Contains(_rowIds[i])) dgvObservers.Rows[i].Selected = true;
            }
            finally
            {
                _syncing = false;
            }

            if (chkRange.Checked) ShowRange(selected);
        }

        // 각 결과의 옵저버 위치에서 히트 지점까지 선을 그려 광선이 어디에 닿았는지 보여 줍니다.
        private void ShowRays(List<VIZCore3DX.NET.Data.SightMapResult> results)
        {
            HideRays();

            List<float> xyz = new List<float>();
            foreach (VIZCore3DX.NET.Data.SightMapResult result in results)
            {
                VIZCore3DX.NET.Data.Vector3D origin = result.OptionsUsed.Position;
                foreach (VIZCore3DX.NET.Data.Vector3D hit in result.HitPoints)
                {
                    xyz.Add(origin.X); xyz.Add(origin.Y); xyz.Add(origin.Z);
                    xyz.Add(hit.X); xyz.Add(hit.Y); xyz.Add(hit.Z);
                }
            }
            if (xyz.Count == 0) return;

            VIZCore3DX.NET.Data.DataSetOptions options = new VIZCore3DX.NET.Data.DataSetOptions();
            options.Color = System.Drawing.Color.FromArgb(255, 220, 0);
            options.Opacity = 0.5f;

            _rayLines = vizcore3dx.View.Effect.AddLineSet(xyz.ToArray(), null, null, options);
        }

        private void HideRays()
        {
            if (_rayLines == 0) return;

            vizcore3dx.View.Effect.RemoveDataSet(_rayLines);
            _rayLines = 0;
        }

        // 선택한 옵저버들의 시야 범위를 선으로 그립니다. 원뿔은 모선·가장자리 링, 전방향은 세 대원입니다.
        private void ShowRange(List<int> ids)
        {
            HideRange();

            List<float> xyz = new List<float>();
            List<int> sizes = new List<int>();
            foreach (int id in ids)
            {
                VIZCore3DX.NET.Data.ObserverItem item = vizcore3dx.Observer.GetItem(id);
                if (item == null) continue;

                if (item.ConeAngleDeg > 0) AppendCone(item.Position, item.Direction, item.MaxDistanceMm, item.ConeAngleDeg, xyz, sizes);
                else AppendSphere(item.Position, item.MaxDistanceMm, xyz, sizes);
            }
            if (xyz.Count == 0) return;

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
        private static void AppendCone(VIZCore3DX.NET.Data.Vector3D origin, VIZCore3DX.NET.Data.Vector3D axis, double radius, double halfAngleDeg,
            List<float> xyz, List<int> sizes)
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
