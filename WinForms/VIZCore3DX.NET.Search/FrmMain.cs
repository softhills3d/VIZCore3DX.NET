using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Search
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// VIZCore3DX.NET Control
        /// </summary>
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            // VIZCore3DX Module Init
            VIZCore3DX.NET.ModuleInitializer.Run();
            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            // Panel Control Add
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            InitializeSearchSetUI();
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

            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();

            vizcore3dx.Model.EnableBody = false;

            InitializeVIZCore3DXEvent();

            RefreshSearchSetNames(null);
        }

        /// <summary>
        /// VIZCore3DX.NET 전역 이벤트 초기화
        /// </summary>
        private void InitializeVIZCore3DXEvent()
        {
            
        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            vizcore3dx.ShowWaitForm("Searching...", "Searching...");

            List<string> keyword = new List<string>();
            keyword.Add(txtKeyword1.Text.Trim());

            List<Data.Node> nodes = vizcore3dx.Object3D.Find.QuickSearch
            (keyword
              , false /* Join Condition : True - And, False - Or */
              , false /* True : Assembly Only, False : Assembly + Part */
              , true /* True : Visible Only, False : All Node */
              , false /* True : Selected Object, False : All Node */
              , false /* True : Full Match, False : Contains */
            );

            vizcore3dx.Object3D.Select(nodes, true);

            lvResult1.Items.Clear();

            lvResult1.BeginUpdate();
            foreach (VIZCore3DX.NET.Data.Node item in nodes)
            {
                ListViewItem lvi = new ListViewItem(new string[] { item.Index.ToString(), item.EntityID.ToString(), item.NodeName });
                lvResult1.Items.Add(lvi);
            }
            lvResult1.EndUpdate();

            vizcore3dx.CloseWaitForm();
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            vizcore3dx.ShowWaitForm("Searching...", "Searching...");

            List<string> keyword = new List<string>();
            keyword.Add("*OBST*");
            keyword.Add("*INSU*");

            List<Data.Node> nodes = vizcore3dx.Object3D.Find.QuickSearch
            (keyword
              , false /* Join Condition : True - And, False - Or */
              , false /* True : Assembly Only, False : Assembly + Part */
              , true /* True : Visible Only, False : All Node */
              , false /* True : Selected Object, False : All Node */
              , false /* True : Full Match, False : Contains */
            );

            vizcore3dx.Object3D.Select(nodes, true);

            lvResult2.Items.Clear();

            lvResult2.BeginUpdate();
            foreach (VIZCore3DX.NET.Data.Node item in nodes)
            {
                ListViewItem lvi = new ListViewItem(new string[] { item.Index.ToString(), item.EntityID.ToString(), item.NodeName });
                lvResult2.Items.Add(lvi);
            }
            lvResult2.EndUpdate();

            vizcore3dx.CloseWaitForm();
        }

        private void btnSearch3_Click(object sender, EventArgs e)
        {
            vizcore3dx.ShowWaitForm("Searching...", "Searching...");            

            List<Data.Node> nodes = vizcore3dx.Object3D.Find.QuickSearch(txtKeyword3.Text.Trim(), false);

            vizcore3dx.Object3D.Show(nodes, false);

            lvResult3.Items.Clear();

            lvResult3.BeginUpdate();
            foreach (VIZCore3DX.NET.Data.Node item in nodes)
            {
                ListViewItem lvi = new ListViewItem(new string[] { item.Index.ToString(), item.EntityID.ToString(), item.NodeName });
                lvResult3.Items.Add(lvi);
            }
            lvResult3.EndUpdate();

            vizcore3dx.CloseWaitForm();
        }

        #region Common

        /// <summary>
        /// 검색 결과를 목록에 표시하고 개체를 선택
        /// </summary>
        /// <param name="listView">결과 목록</param>
        /// <param name="nodes">검색 결과 노드</param>
        private void ShowSearchResult(ListView listView, List<Data.Node> nodes)
        {
            listView.BeginUpdate();
            listView.Items.Clear();
            if (nodes != null)
            {
                foreach (VIZCore3DX.NET.Data.Node item in nodes)
                {
                    ListViewItem lvi = new ListViewItem(new string[] { item.Index.ToString(), item.EntityID.ToString(), item.NodeName });
                    listView.Items.Add(lvi);
                }
            }
            listView.EndUpdate();

            if (nodes == null) return;

            vizcore3dx.Object3D.Select(nodes, true);
        }

        /// <summary>
        /// FindManager 실패 원인 표시
        /// </summary>
        /// <param name="message">표시할 메시지</param>
        private void ShowFindFailure(string message)
        {
            MessageBox.Show(string.Format("{0}\r\n\r\nResult : {1}", message, vizcore3dx.Object3D.Find.LastOperationStatus.Result), "VIZCore3DX.NET.Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region Search Set

        /// <summary>
        /// 검색 세트 UI 초기화
        /// </summary>
        private void InitializeSearchSetUI()
        {
            foreach (VIZCore3DX.NET.Data.NameMatchMode mode in Enum.GetValues(typeof(VIZCore3DX.NET.Data.NameMatchMode)))
            {
                cmbNameMatch.Items.Add(mode);
            }
            cmbNameMatch.SelectedItem = VIZCore3DX.NET.Data.NameMatchMode.Contains;

            foreach (VIZCore3DX.NET.Data.ConditionCombine combine in Enum.GetValues(typeof(VIZCore3DX.NET.Data.ConditionCombine)))
            {
                cmbNameCombine.Items.Add(combine);
            }
            cmbNameCombine.SelectedItem = VIZCore3DX.NET.Data.ConditionCombine.Or;
        }

        /// <summary>
        /// 화면에 입력된 조건으로 검색 세트 항목 생성
        /// </summary>
        /// <returns>검색 세트 항목</returns>
        private VIZCore3DX.NET.Data.SearchSetItem CreateSearchSetItem()
        {
            VIZCore3DX.NET.Data.SearchSetItem item = new VIZCore3DX.NET.Data.SearchSetItem();
            item.Name = txtSetName.Text.Trim();
            item.Description = string.Format("{0} : {1}", cmbNameMatch.SelectedItem, txtNameText.Text.Trim());

            // 이름 조건
            item.NameText = txtNameText.Text.Trim();
            item.NameMatch = (VIZCore3DX.NET.Data.NameMatchMode)cmbNameMatch.SelectedItem;
            item.NameCombine = (VIZCore3DX.NET.Data.ConditionCombine)cmbNameCombine.SelectedItem;
            item.NameCaseSensitive = chkNameCaseSensitive.Checked;

            // 노드 타입 조건
            item.TypeAssembly = chkTypeAssembly.Checked;
            item.TypePart = chkTypePart.Checked;

            // 보이기 조건 (null : 무관)
            item.Visible = chkSetVisibleOnly.Checked ? (bool?)true : null;

            return item;
        }

        /// <summary>
        /// 저장된 검색 세트 이름 목록 갱신
        /// </summary>
        /// <param name="selectName">갱신 후 선택할 이름</param>
        private void RefreshSearchSetNames(string selectName)
        {
            List<string> names = vizcore3dx.Object3D.Find.GetSearchSetNames();

            cmbSearchSet.BeginUpdate();
            cmbSearchSet.Items.Clear();
            if (names != null)
            {
                foreach (string name in names)
                {
                    cmbSearchSet.Items.Add(name);
                }
            }
            cmbSearchSet.EndUpdate();

            if (cmbSearchSet.Items.Count == 0)
            {
                lblSearchSetInfo.Text = "저장된 검색 세트가 없습니다.";
                return;
            }

            int index = string.IsNullOrEmpty(selectName) ? -1 : cmbSearchSet.Items.IndexOf(selectName);
            cmbSearchSet.SelectedIndex = index >= 0 ? index : 0;
        }

        private void cmbSearchSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchSet.SelectedItem == null) return;

            VIZCore3DX.NET.Data.SearchSetItem item = vizcore3dx.Object3D.Find.GetSearchSet(cmbSearchSet.SelectedItem.ToString());
            if (item == null)
            {
                lblSearchSetInfo.Text = string.Empty;
                return;
            }

            lblSearchSetInfo.Text = string.Format("설명 : {0}\r\n이름 조건 : {1} ({2}, {3})", item.Description, item.NameText, item.NameMatch, item.NameCombine);
        }

        private void btnAddSearchSet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSetName.Text.Trim()))
            {
                MessageBox.Show("검색 세트 이름을 입력하세요.", "VIZCore3DX.NET.Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            VIZCore3DX.NET.Data.SearchSetItem item = CreateSearchSetItem();

            if (vizcore3dx.Object3D.Find.AddSearchSet(item) == false)
            {
                ShowFindFailure("검색 세트를 추가하지 못했습니다.");
                return;
            }

            RefreshSearchSetNames(item.Name);
        }

        private void btnRunSearchSetItem_Click(object sender, EventArgs e)
        {
            // 저장하지 않고 입력된 조건으로 바로 실행
            VIZCore3DX.NET.Data.SearchSetItem item = CreateSearchSetItem();

            vizcore3dx.ShowWaitForm("Searching...", "Searching...");
            List<Data.Node> nodes = vizcore3dx.Object3D.Find.RunSearchSet(item);
            vizcore3dx.CloseWaitForm();

            ShowSearchResult(lvResult4, nodes);

            if (vizcore3dx.Object3D.Find.LastOperationStatus.IsFailure) ShowFindFailure("검색 세트를 실행하지 못했습니다.");
        }

        private void btnRunSearchSet_Click(object sender, EventArgs e)
        {
            if (cmbSearchSet.SelectedItem == null) return;

            vizcore3dx.ShowWaitForm("Searching...", "Searching...");
            List<Data.Node> nodes = vizcore3dx.Object3D.Find.RunSearchSet(cmbSearchSet.SelectedItem.ToString());
            vizcore3dx.CloseWaitForm();

            ShowSearchResult(lvResult4, nodes);

            if (vizcore3dx.Object3D.Find.LastOperationStatus.IsFailure) ShowFindFailure("검색 세트를 실행하지 못했습니다.");
        }

        private void btnRemoveSearchSet_Click(object sender, EventArgs e)
        {
            if (cmbSearchSet.SelectedItem == null) return;

            if (vizcore3dx.Object3D.Find.RemoveSearchSet(cmbSearchSet.SelectedItem.ToString()) == false)
            {
                ShowFindFailure("검색 세트를 삭제하지 못했습니다.");
                return;
            }

            RefreshSearchSetNames(null);
        }

        private void btnRefreshSearchSet_Click(object sender, EventArgs e)
        {
            RefreshSearchSetNames(cmbSearchSet.SelectedItem as string);
        }

        private void btnImportSearchSet_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "검색 세트 파일 (*.json)|*.json|모든 파일 (*.*)|*.*";
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                int count = vizcore3dx.Object3D.Find.ImportSearchSet(dlg.FileName);
                if (vizcore3dx.Object3D.Find.LastOperationStatus.IsFailure)
                {
                    ShowFindFailure("검색 세트를 가져오지 못했습니다.");
                    return;
                }

                RefreshSearchSetNames(null);

                MessageBox.Show(string.Format("{0}개의 검색 세트를 가져왔습니다.", count), "VIZCore3DX.NET.Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportSearchSet_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "검색 세트 파일 (*.json)|*.json";
                dlg.FileName = "SearchSets.json";
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                if (vizcore3dx.Object3D.Find.ExportSearchSet(dlg.FileName) == false)
                {
                    ShowFindFailure("검색 세트를 내보내지 못했습니다.");
                    return;
                }

                MessageBox.Show("검색 세트를 내보냈습니다.", "VIZCore3DX.NET.Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Regex / Case Sensitive

        private void btnRegexSearch_Click(object sender, EventArgs e)
        {
            string pattern = txtKeyword5.Text.Trim();
            if (string.IsNullOrEmpty(pattern)) return;

            vizcore3dx.ShowWaitForm("Searching...", "Searching...");

            List<Data.Node> nodes = vizcore3dx.Object3D.Find.RegexSearch
            (pattern
              , false /* True : Assembly Only, False : Assembly + Part */
              , chkVisibleOnly5.Checked /* True : Visible Only, False : All Node */
              , false /* True : Selected Object, False : All Node */
              , chkCaseSensitive5.Checked /* True : 대소문자 구분 */
            );

            vizcore3dx.CloseWaitForm();

            ShowSearchResult(lvResult5, nodes);
            UpdateSearchStrategy();

            if (vizcore3dx.Object3D.Find.LastOperationStatus.IsFailure) ShowFindFailure("정규식 검색에 실패했습니다.");
        }

        private void btnQuickSearchCase_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword5.Text.Trim();
            if (string.IsNullOrEmpty(keyword)) return;

            vizcore3dx.ShowWaitForm("Searching...", "Searching...");

            List<Data.Node> nodes = vizcore3dx.Object3D.Find.QuickSearch
            (keyword
              , false /* True : Assembly Only, False : Assembly + Part */
              , chkVisibleOnly5.Checked /* True : Visible Only, False : All Node */
              , false /* True : Selected Object, False : All Node */
              , chkFullMatch5.Checked /* True : Full Match, False : Contains */
              , chkCaseSensitive5.Checked /* True : 대소문자 구분 */
            );

            vizcore3dx.CloseWaitForm();

            ShowSearchResult(lvResult5, nodes);
            UpdateSearchStrategy();

            if (vizcore3dx.Object3D.Find.LastOperationStatus.IsFailure) ShowFindFailure("검색에 실패했습니다.");
        }

        /// <summary>
        /// 마지막 검색에 사용된 방식 표시
        /// </summary>
        private void UpdateSearchStrategy()
        {
            lblSearchStrategy.Text = string.Format("LastSearchStrategy : {0}  ({1}건)", vizcore3dx.Object3D.Find.LastSearchStrategy, lvResult5.Items.Count);
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
