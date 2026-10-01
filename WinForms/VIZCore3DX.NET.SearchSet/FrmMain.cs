using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.SearchSet
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 검색 결과 목록 (4. 결과 표와 같은 순서)
        private List<VIZCore3DX.NET.Data.Node> _results = new List<VIZCore3DX.NET.Data.Node>();

        // 표를 코드로 채우는 동안에는 표 선택을 뷰로 넘기지 않습니다.
        private bool _syncing;

        private const string JsonFilter = "JSON 파일 (*.json)|*.json|모든 파일 (*.*)|*.*";

        public FrmMain()
        {
            InitializeComponent();

            // 뷰어와 무관한 콤보 항목은 생성자에서 채웁니다.
            cmbMatch.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.NameMatchMode));
            cmbMatch.SelectedItem = VIZCore3DX.NET.Data.NameMatchMode.Contains;

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

            // 저장 검색 세트는 모델이 아니라 사용자별로 보관되므로 모델을 열기 전에도 목록을 읽습니다.
            RefreshSets();
            SetStatus("모델을 열어 주세요.");
        }

        #region 1. 모델
        // 검색할 모델을 엽니다. 이전 검색 결과는 비웁니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            ClearResults();
            SetStatus("모델을 열었습니다.");
        }
        #endregion

        #region 3. 실행
        // 이름으로 빠르게 검색합니다. 일치 방식이 Exact 면 전체 일치, 그 밖에는 부분 일치입니다.
        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            string text = txtName.Text.Trim();
            if (text.Length == 0)
            {
                SetStatus("검색어를 입력하십시오.");
                return;
            }

            bool fullMatch = (VIZCore3DX.NET.Data.NameMatchMode)cmbMatch.SelectedItem == VIZCore3DX.NET.Data.NameMatchMode.Exact;
            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.Find.QuickSearch(text, false, chkVisibleOnly.Checked, false, fullMatch, chkCaseSensitive.Checked);
            ApplyResults(nodes, "빠른 검색");
        }

        // 검색어를 정규식으로 해석해 이름을 검색합니다. 잘못된 정규식은 예외로 알려 줍니다.
        private void btnRegexSearch_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            string text = txtName.Text.Trim();
            if (text.Length == 0)
            {
                SetStatus("검색어를 입력하십시오.");
                return;
            }

            try
            {
                List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.Find.RegexSearch(text, false, chkVisibleOnly.Checked, false, chkCaseSensitive.Checked);
                ApplyResults(nodes, "정규식 검색");
            }
            catch (ArgumentException ex)
            {
                SetStatus(string.Format("잘못된 정규식입니다 : {0}", ex.Message));
            }
        }

        // 2. 검색 조건 전체(일치 방식·종류·보이는 노드)를 저장하지 않은 검색 세트로 한 번 실행합니다.
        private void btnRunCondition_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.Find.RunSearchSet(BuildItem(""));
            ApplyResults(nodes, "조건 검색");

            if (_results.Count == 0)
                SetStatus(string.Format("조건 검색 결과 없음 : {0}", vizcore3dx.Object3D.Find.LastOperationResult));
        }

        // 현재 검색 조건을 이름을 붙여 저장 검색 세트로 보관합니다. 같은 이름이면 덮어씁니다.
        private void btnSaveSet_Click(object sender, EventArgs e)
        {
            string name = txtSetName.Text.Trim();
            if (name.Length == 0)
            {
                SetStatus("세트 이름을 입력하십시오.");
                return;
            }

            if (!vizcore3dx.Object3D.Find.AddSearchSet(BuildItem(name)))
            {
                SetStatus(string.Format("저장 세트 추가 실패 : {0}", vizcore3dx.Object3D.Find.LastOperationResult));
                return;
            }

            RefreshSets();
            cmbSets.SelectedItem = name;
            SetStatus(string.Format("저장 세트 추가 : {0}", name));
        }

        // 콤보에서 세트를 고르면 저장된 조건을 2. 검색 조건 컨트롤에 되돌려 보여 줍니다. 수정 후 같은 이름으로 저장하면 덮어씁니다.
        private void cmbSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cmbSets.SelectedItem as string;
            if (name == null) return;

            VIZCore3DX.NET.Data.SearchSetItem item = vizcore3dx.Object3D.Find.GetSearchSet(name);
            if (item == null) return;

            WriteToControls(item);
            SetStatus(string.Format("세트 불러옴 : {0} ({1}, 검색어 \"{2}\")", item.Name, item.NameMatch, item.NameText));
        }

        // 콤보에서 고른 저장 검색 세트를 실행합니다.
        private void btnRunSet_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            string name = cmbSets.SelectedItem as string;
            if (name == null)
            {
                SetStatus("실행할 세트를 선택하십시오.");
                return;
            }

            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.Find.RunSearchSet(name);
            ApplyResults(nodes, string.Format("세트 실행 : {0}", name));
        }

        // 콤보에서 고른 저장 검색 세트를 삭제합니다.
        private void btnRemoveSet_Click(object sender, EventArgs e)
        {
            string name = cmbSets.SelectedItem as string;
            if (name == null)
            {
                SetStatus("삭제할 세트를 선택하십시오.");
                return;
            }

            if (!vizcore3dx.Object3D.Find.RemoveSearchSet(name))
            {
                SetStatus(string.Format("저장 세트 삭제 실패 : {0}", vizcore3dx.Object3D.Find.LastOperationResult));
                return;
            }

            RefreshSets();
            SetStatus(string.Format("저장 세트 삭제 : {0}", name));
        }

        // 저장 검색 세트 전체를 JSON 파일로 내보냅니다.
        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = JsonFilter;
                dialog.FileName = "SearchSets.json";
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                if (vizcore3dx.Object3D.Find.ExportSearchSet(dialog.FileName))
                    SetStatus(string.Format("내보내기 완료 : {0}", dialog.FileName));
                else
                    SetStatus(string.Format("내보내기 실패 : {0}", vizcore3dx.Object3D.Find.LastOperationResult));
            }
        }

        // JSON 파일의 검색 세트를 불러와 저장 목록에 더합니다.
        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = JsonFilter;
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                int count = vizcore3dx.Object3D.Find.ImportSearchSet(dialog.FileName);
                if (count < 0)
                {
                    SetStatus(string.Format("불러오기 실패 : {0}", vizcore3dx.Object3D.Find.LastOperationResult));
                    return;
                }

                RefreshSets();
                SetStatus(string.Format("불러오기 완료 : {0} 개", count));
            }
        }
        #endregion

        #region 4. 결과
        // 표에서 고른 행의 노드만 뷰에서 선택합니다.
        private void dgvResults_SelectionChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            List<VIZCore3DX.NET.Data.Node> picked = SelectedNodes();
            if (picked.Count == 0) return;

            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);
                vizcore3dx.Object3D.Select(picked, true);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        // 검색 결과 전체를 다시 선택하고 카메라를 결과로 옮깁니다.
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            if (_results.Count == 0)
            {
                SetStatus("선택할 결과가 없습니다.");
                return;
            }

            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);
                vizcore3dx.Object3D.Select(_results, true);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            vizcore3dx.View.FlyToObject3d(_results);
            SetStatus(string.Format("결과 전체 선택 : {0} 개", _results.Count));
        }

        // 표에서 고른 행(없으면 결과 전체)으로 카메라를 옮깁니다.
        private void btnFly_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            List<VIZCore3DX.NET.Data.Node> nodes = SelectedNodes();
            if (nodes.Count == 0) nodes = _results;
            if (nodes.Count == 0)
            {
                SetStatus("카메라를 옮길 결과가 없습니다.");
                return;
            }

            vizcore3dx.View.FlyToObject3d(nodes);
            SetStatus(string.Format("카메라 이동 : {0} 개", nodes.Count));
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

        // 검색 결과 표를 비웁니다.
        private void btnClearResults_Click(object sender, EventArgs e)
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

        // 2. 검색 조건 입력을 검색 세트 항목으로 옮깁니다.
        private VIZCore3DX.NET.Data.SearchSetItem BuildItem(string name)
        {
            VIZCore3DX.NET.Data.SearchSetItem item = new VIZCore3DX.NET.Data.SearchSetItem();
            item.Name = name;
            item.NameText = txtName.Text.Trim();
            item.NameMatch = (VIZCore3DX.NET.Data.NameMatchMode)cmbMatch.SelectedItem;
            item.NameCaseSensitive = chkCaseSensitive.Checked;
            item.TypeAssembly = chkAssembly.Checked;
            item.TypePart = chkPart.Checked;
            item.TypeBody = chkBody.Checked;
            item.Visible = chkVisibleOnly.Checked ? (bool?)true : null;
            return item;
        }

        // 결과를 표에 넣고 뷰에서 선택한 뒤 카메라를 결과로 옮깁니다.
        // 결과는 수만 개가 될 수 있으므로 행을 미리 만들어 AddRange 로 한 번에 넣습니다.
        private void ApplyResults(List<VIZCore3DX.NET.Data.Node> nodes, string what)
        {
            _results = nodes ?? new List<VIZCore3DX.NET.Data.Node>();

            List<DataGridViewRow> rows = new List<DataGridViewRow>(_results.Count);
            foreach (VIZCore3DX.NET.Data.Node node in _results)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvResults, node.NodeName, node.Kind, node.Index);
                row.Tag = node;
                rows.Add(row);
            }

            _syncing = true;
            try
            {
                dgvResults.Rows.Clear();
                dgvResults.Rows.AddRange(rows.ToArray());
                dgvResults.ClearSelection();
            }
            finally
            {
                _syncing = false;
            }

            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);
                if (_results.Count > 0) vizcore3dx.Object3D.Select(_results, true);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            if (_results.Count > 0) vizcore3dx.View.FlyToObject3d(_results);

            lblStrategy.Text = string.Format("검색 방식 : {0}  결과 : {1} 개", vizcore3dx.Object3D.Find.LastSearchStrategy, _results.Count);
            SetStatus(string.Format("{0} 완료 : {1} 개", what, _results.Count));
        }

        // 표에서 고른 행의 노드
        private List<VIZCore3DX.NET.Data.Node> SelectedNodes()
        {
            List<VIZCore3DX.NET.Data.Node> picked = new List<VIZCore3DX.NET.Data.Node>();
            foreach (DataGridViewRow row in dgvResults.SelectedRows)
            {
                VIZCore3DX.NET.Data.Node node = row.Tag as VIZCore3DX.NET.Data.Node;
                if (node != null) picked.Add(node);
            }
            return picked;
        }

        // 저장 검색 세트 이름으로 콤보를 다시 채웁니다. 고르던 세트가 남아 있으면 선택을 유지합니다.
        private void RefreshSets()
        {
            string current = cmbSets.SelectedItem as string;
            List<string> names = vizcore3dx.Object3D.Find.GetSearchSetNames() ?? new List<string>();

            cmbSets.Items.Clear();
            cmbSets.Items.AddRange(names.ToArray());
            if (current != null && names.Contains(current)) cmbSets.SelectedItem = current;
            else if (names.Count > 0) cmbSets.SelectedIndex = 0;

            btnRunSet.Enabled = names.Count > 0;
            btnRemoveSet.Enabled = names.Count > 0;
        }

        // BuildItem 의 역방향. 저장 검색 세트의 조건을 2. 검색 조건 컨트롤에 씁니다.
        private void WriteToControls(VIZCore3DX.NET.Data.SearchSetItem item)
        {
            txtName.Text = item.NameText;
            cmbMatch.SelectedItem = item.NameMatch;
            chkCaseSensitive.Checked = item.NameCaseSensitive;
            chkAssembly.Checked = item.TypeAssembly;
            chkPart.Checked = item.TypePart;
            chkBody.Checked = item.TypeBody;
            chkVisibleOnly.Checked = item.Visible == true;
            txtSetName.Text = item.Name;
        }

        private void ClearResults()
        {
            _results = new List<VIZCore3DX.NET.Data.Node>();

            _syncing = true;
            try
            {
                dgvResults.Rows.Clear();
            }
            finally
            {
                _syncing = false;
            }

            lblStrategy.Text = "검색 방식 : -";
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
