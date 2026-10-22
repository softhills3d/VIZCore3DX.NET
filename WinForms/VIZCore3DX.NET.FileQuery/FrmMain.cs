using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace VIZCore3DX.NET.FileQuery
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 영역 검색 결과 (4. 결과 표와 같은 순서)
        private List<VIZCore3DX.NET.Data.FileSpaceSearchResult> _results;

        // 검색 영역 상자 선 (0 이면 없음)
        private uint _areaLines;

        public FrmMain()
        {
            InitializeComponent();

            // 뷰어와 무관한 콤보 항목은 생성자에서 채웁니다.
            cmbTarget.Items.AddRange(new object[] { "파일", "노드" });
            cmbTarget.SelectedIndex = 0;

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

            // 파일을 읽을 때마다 진행 이벤트가 작업 스레드에서 발생합니다.
            vizcore3dx.Model.SpaceSearch.OnProgressEvent -= SpaceSearch_OnProgressEvent;
            vizcore3dx.Model.SpaceSearch.OnProgressEvent += SpaceSearch_OnProgressEvent;

            SetStatus("파일을 추가해 주세요. 모델은 열지 않아도 됩니다.");
        }

        #region 1. 모델
        // 모델을 엽니다. 열린 모델의 상자를 검색 영역의 기본값으로 채웁니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            // 모델을 열면 영역 선은 자동으로 지워집니다.
            _areaLines = 0;
            FillAreaFromModel();
            if (chkShowArea.Checked) ShowArea();
            SetStatus("모델을 열었습니다.");
        }
        #endregion

        #region 2. 파일
        // 검색 대상 파일을 추가하고, 파일을 열지 않고 형식·노드 수·크기를 조회합니다.
        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Multiselect = true;
                dlg.Filter = "VIZX/VIZ 파일|*.vizx;*.viz";
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                int added = vizcore3dx.Model.SpaceSearch.AddFiles(new List<string>(dlg.FileNames));
                FillFiles();
                SetStatus(string.Format("파일 {0}건 추가 (총 {1})", added, vizcore3dx.Model.SpaceSearch.Files.Count));
            }
        }

        // 검색 대상 파일 목록을 비웁니다.
        private void btnRemoveFiles_Click(object sender, EventArgs e)
        {
            vizcore3dx.Model.SpaceSearch.Clear();
            dgvFiles.Rows.Clear();
            SetStatus("파일 목록을 비웠습니다.");
        }
        #endregion

        #region 3. 영역 검색
        // 열린 모델의 상자로 검색 영역을 채웁니다.
        private void btnAreaFromModel_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            FillAreaFromModel();
            SetStatus("검색 영역을 모델 상자로 채웠습니다.");
        }

        // 검색 영역을 상자 선으로 표시하거나 지웁니다.
        private void chkShowArea_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowArea.Checked) ShowArea();
            else HideArea();
        }

        // 영역 입력이 바뀌면 표시 중인 상자를 다시 그립니다.
        private void area_Changed(object sender, EventArgs e)
        {
            if (chkShowArea.Checked) ShowArea();
        }

        // 영역에 걸치는 파일(또는 노드)을 파일을 열지 않고 찾습니다.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.SpaceSearch.Files.Count == 0)
            {
                SetStatus("먼저 파일을 추가하세요");
                return;
            }

            VIZCore3DX.NET.Data.BoundBox3D area = BuildArea();
            if (!area.IsValid())
            {
                SetStatus("검색 영역이 올바르지 않습니다. 최소·최대 값을 확인하세요.");
                return;
            }

            VIZCore3DX.NET.Manager.FileSpaceSearchManager.SearchTarget target = cmbTarget.SelectedIndex == 1
                ? VIZCore3DX.NET.Manager.FileSpaceSearchManager.SearchTarget.NODE
                : VIZCore3DX.NET.Manager.FileSpaceSearchManager.SearchTarget.FILE;

            _results = vizcore3dx.Model.SpaceSearch.Search(area, target);
            FillResults();
            SetStatus(string.Format("검색 완료 : {0}건 (대상 {1})", _results == null ? 0 : _results.Count, cmbTarget.SelectedIndex == 1 ? "노드" : "파일"));
        }

        // 검색 진행 상황을 상태 표시줄에 보여 줍니다. 작업 스레드에서 발생하므로 UI 스레드로 넘깁니다.
        private void SpaceSearch_OnProgressEvent(object sender, VIZCore3DX.NET.Event.EventManager.FileSpaceSearchProgressEventArgs e)
        {
            int index = e.Index;
            int count = e.Count;
            string name = Path.GetFileName(e.Path);
            RunOnUi(() => SetStatus(string.Format("읽는 중 {0}/{1} : {2}", index, count, name)));
        }
        #endregion

        #region 4. 결과
        // 선택한 결과 파일을 엽니다. 모델이 없으면 첫 파일을 열고 나머지를 추가합니다.
        private void btnLoad_Click(object sender, EventArgs e)
        {
            List<string> paths = new List<string>();
            foreach (VIZCore3DX.NET.Data.FileSpaceSearchResult hit in SelectedResults())
                paths.Add(hit.Path);

            if (paths.Count == 0)
            {
                SetStatus("열 파일을 결과 표에서 선택하세요.");
                return;
            }

            bool ok;
            if (!vizcore3dx.Model.IsOpen())
            {
                ok = vizcore3dx.Model.Open(paths[0]);
                if (ok && paths.Count > 1) ok = vizcore3dx.Model.Add(paths.GetRange(1, paths.Count - 1));
            }
            else
            {
                ok = vizcore3dx.Model.Add(paths);
            }

            vizcore3dx.View.FitToView();
            SetStatus(ok ? string.Format("파일 {0}건을 열었습니다.", paths.Count) : "파일을 열지 못했습니다.");
        }

        // 노드 검색 결과의 노드를 선택합니다.
        // EntityID 는 그 파일이 뷰어에 열려 있을 때만 의미가 있으므로, 먼저 "선택 파일 열기"로 여세요.
        private void btnSelectNodes_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            int count = 0;
            vizcore3dx.BeginUpdate();
            try
            {
                foreach (VIZCore3DX.NET.Data.FileSpaceSearchResult hit in SelectedResults())
                {
                    if (hit.Nodes.Count == 0) continue;

                    vizcore3dx.Object3D.Select(hit.Nodes, true);
                    count += hit.Nodes.Count;
                }
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            SetStatus(string.Format("노드 {0}개 선택 (그 파일이 열려 있어야 선택됩니다)", count));
        }
        #endregion

        #region 5. 정리
        // 검색 영역 상자 선을 지웁니다.
        private void btnHideArea_Click(object sender, EventArgs e)
        {
            HideArea();
            chkShowArea.Checked = false;
            SetStatus("영역 표시를 지웠습니다.");
        }

        // 파일 목록·검색 결과·영역 표시를 모두 지웁니다.
        private void btnClear_Click(object sender, EventArgs e)
        {
            vizcore3dx.Model.SpaceSearch.Clear();
            dgvFiles.Rows.Clear();
            dgvResults.Rows.Clear();
            _results = null;
            HideArea();
            SetStatus("전부 지웠습니다.");
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

        // 작업 스레드에서 호출돼도 UI 스레드에서 실행합니다.
        private void RunOnUi(Action action)
        {
            if (InvokeRequired) BeginInvoke(action);
            else action();
        }

        // 열린 모델의 상자를 영역 입력칸에 채웁니다.
        private void FillAreaFromModel()
        {
            if (!vizcore3dx.Model.IsOpen()) return;

            VIZCore3DX.NET.Data.BoundBox3D box = vizcore3dx.Model.BoundBox;
            SetValue(numMinX, box.MinX);
            SetValue(numMinY, box.MinY);
            SetValue(numMinZ, box.MinZ);
            SetValue(numMaxX, box.MaxX);
            SetValue(numMaxY, box.MaxY);
            SetValue(numMaxZ, box.MaxZ);
        }

        // 입력칸 범위를 벗어나거나 NaN 인 값은 범위 안으로 맞춰 넣습니다.
        private static void SetValue(NumericUpDown num, float value)
        {
            if (float.IsNaN(value)) value = 0f;
            double clamped = Math.Max((double)num.Minimum, Math.Min((double)num.Maximum, value));
            num.Value = (decimal)clamped;
        }

        // 영역 입력칸의 값으로 상자를 만듭니다. 최소·최대가 뒤바뀌어도 정렬됩니다.
        private VIZCore3DX.NET.Data.BoundBox3D BuildArea()
        {
            return new VIZCore3DX.NET.Data.BoundBox3D(
                (float)numMinX.Value, (float)numMinY.Value, (float)numMinZ.Value,
                (float)numMaxX.Value, (float)numMaxY.Value, (float)numMaxZ.Value);
        }

        // 검색 영역 상자의 모서리 12개를 선으로 그립니다.
        private void ShowArea()
        {
            HideArea();

            VIZCore3DX.NET.Data.BoundBox3D box = BuildArea();
            float[] x = { box.MinX, box.MaxX };
            float[] y = { box.MinY, box.MaxY };
            float[] z = { box.MinZ, box.MaxZ };

            List<float> xyz = new List<float>(12 * 6);
            for (int a = 0; a < 2; a++)
                for (int b = 0; b < 2; b++)
                {
                    AppendEdge(xyz, x[0], y[a], z[b], x[1], y[a], z[b]);   // X 방향
                    AppendEdge(xyz, x[a], y[0], z[b], x[a], y[1], z[b]);   // Y 방향
                    AppendEdge(xyz, x[a], y[b], z[0], x[a], y[b], z[1]);   // Z 방향
                }

            int[] sizes = new int[12];
            for (int i = 0; i < sizes.Length; i++) sizes[i] = 2;

            VIZCore3DX.NET.Data.DataSetOptions options = new VIZCore3DX.NET.Data.DataSetOptions();
            options.Color = System.Drawing.Color.FromArgb(0, 200, 255);
            options.Opacity = 0.7f;

            _areaLines = vizcore3dx.View.Effect.AddLineSet(xyz.ToArray(), sizes, null, options);
        }

        private static void AppendEdge(List<float> xyz, float x1, float y1, float z1, float x2, float y2, float z2)
        {
            xyz.Add(x1); xyz.Add(y1); xyz.Add(z1);
            xyz.Add(x2); xyz.Add(y2); xyz.Add(z2);
        }

        private void HideArea()
        {
            if (_areaLines == 0) return;

            vizcore3dx.View.Effect.RemoveDataSet(_areaLines);
            _areaLines = 0;
        }

        // 검색 대상 파일마다 파일을 열지 않고 정보를 조회해 표에 채웁니다.
        private void FillFiles()
        {
            dgvFiles.Rows.Clear();
            foreach (string path in vizcore3dx.Model.SpaceSearch.Files)
            {
                VIZCore3DX.NET.Data.ModelFileInfo info = vizcore3dx.Model.GetFileInfo(path);
                if (info == null)
                {
                    dgvFiles.Rows.Add(Path.GetFileName(path), "-", "-", "-");
                    continue;
                }

                dgvFiles.Rows.Add(Path.GetFileName(path), FormatText(info.Format), info.NodeCount, SizeText(info.BoundBox));
            }
        }

        private void FillResults()
        {
            dgvResults.Rows.Clear();
            if (_results == null) return;

            foreach (VIZCore3DX.NET.Data.FileSpaceSearchResult hit in _results)
                dgvResults.Rows.Add(Path.GetFileName(hit.Path), FormatText(hit.Format), hit.Nodes.Count);
        }

        // 표에서 고른 행들의 결과 (표 순서)
        private List<VIZCore3DX.NET.Data.FileSpaceSearchResult> SelectedResults()
        {
            List<VIZCore3DX.NET.Data.FileSpaceSearchResult> picked = new List<VIZCore3DX.NET.Data.FileSpaceSearchResult>();
            if (_results == null) return picked;

            for (int i = 0; i < _results.Count && i < dgvResults.Rows.Count; i++)
                if (dgvResults.Rows[i].Selected) picked.Add(_results[i]);
            return picked;
        }

        private static string FormatText(VIZCore3DX.NET.Data.ModelFileFormat format)
        {
            switch (format)
            {
                case VIZCore3DX.NET.Data.ModelFileFormat.VIZ: return "VIZ";
                case VIZCore3DX.NET.Data.ModelFileFormat.VIZX: return "VIZX";
                default: return "-";
            }
        }

        // 상자의 가장 긴 변을 m 단위로 표시합니다.
        private static string SizeText(VIZCore3DX.NET.Data.BoundBox3D box)
        {
            if (box == null || !box.IsValid()) return "-";
            return (box.MaxLength / 1000f).ToString("F1");
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
        #endregion
    }
}
