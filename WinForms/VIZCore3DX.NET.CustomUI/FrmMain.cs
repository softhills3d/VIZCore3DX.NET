using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.CustomUI
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 사용자 버튼·사용자 탭의 이름 키 (툴바·패널 안에서 고유)
        private const string BtnText = "customui.text";
        private const string BtnIcon = "customui.icon";
        private const string BtnToggle = "customui.toggle";
        private const string TabName = "customui.inspection";

        // 패널 탭에 담을 응용프로그램 화면 (탭을 제거해도 Dispose 되지 않아 다시 부착할 때 재사용합니다)
        private InspectionControl _inspection;

        // 토글 버튼을 추가한 툴바 (null 이면 아직 추가하지 않음)
        private VIZCore3DX.NET.Data.ToolbarKind? _toggleToolbar;

        // '선택 탭 숨김' 으로 숨긴 탭 이름 ("패널:탭"). GetTabNames 에서 빠지므로 목록에 남겨 되돌릴 수 있게 합니다.
        private readonly HashSet<string> _hiddenTabs = new HashSet<string>();

        // '모두 되돌리기' 에서 복원할 시작 시점의 패널 위치
        private VIZCore3DX.NET.Data.PanelDockPosition _initialTreePosition;
        private VIZCore3DX.NET.Data.PanelDockPosition _initialAttributePosition;

        public FrmMain()
        {
            InitializeComponent();

            // 뷰어와 무관한 콤보 항목은 생성자에서 채웁니다.
            cmbToolbar.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.ToolbarKind));
            cmbToolbar.SelectedItem = VIZCore3DX.NET.Data.ToolbarKind.Main;
            cmbPanel.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.PanelKind));
            cmbPanel.SelectedItem = VIZCore3DX.NET.Data.PanelKind.ModelTree;
            cmbPosition.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.PanelDockPosition));

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            _inspection = new InspectionControl(vizcore3dx);

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

        #region Initialize
        private void InitializeVIZCore3DX()
        {
            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();

            _initialTreePosition = vizcore3dx.View.ModelTreePanelPosition;
            _initialAttributePosition = vizcore3dx.View.AttributePanelPosition;

            RefreshTabList();
            SyncPositionCombo();
            SetStatus("툴바 버튼·패널 탭을 추가해 보세요.");
        }

        // 이 예제는 뷰어 이벤트를 구독하지 않습니다.
        private void InitializeVIZCore3DXEvent()
        {
        }

        #endregion

        #region 1. 모델
        // 검사 탭에서 읽을 모델을 엽니다. 툴바 버튼·패널 탭은 모델 없이도 동작합니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            SetStatus("모델을 열었습니다.");
        }
        #endregion

        #region 2. 툴바 사용자 버튼
        // 고른 툴바 끝에 글자만 있는 버튼을 추가합니다. 같은 이름이 이미 있으면 null 이 돌아옵니다.
        private void btnAddTextButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = vizcore3dx.Toolbar.AddButton(SelectedToolbar(), BtnText, "텍스트 버튼", null,
                (s, a) => SetStatus("텍스트 버튼을 눌렀습니다."));

            SetStatus(button != null ? "텍스트 버튼을 추가했습니다." : "텍스트 버튼이 이미 있습니다.");
        }

        // 아이콘 버튼을 추가합니다. 누르면 화면을 모델에 맞춥니다.
        private void btnAddIconButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = vizcore3dx.Toolbar.AddButton(SelectedToolbar(), BtnIcon, "화면 맞춤", Properties.Resources.circle_16,
                (s, a) =>
                {
                    if (vizcore3dx.Model.IsOpen()) vizcore3dx.View.FitToView();
                    SetStatus("아이콘 버튼을 눌렀습니다.");
                });

            SetStatus(button != null ? "아이콘 버튼을 추가했습니다." : "아이콘 버튼이 이미 있습니다.");
        }

        // 누를 때마다 눌림 상태가 바뀌는 토글 버튼을 추가합니다. 누르면 모델 트리 패널에 검사 탭을 부착해 보여 주고, 다시 누르면 숨깁니다.
        private void btnAddToggleButton_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.ToolbarKind kind = SelectedToolbar();
            ToolStripButton button = vizcore3dx.Toolbar.AddButton(kind, BtnToggle, "검사 탭", Properties.Resources.square_16,
                (s, a) => ToggleInspectionTab(vizcore3dx.Toolbar.GetChecked(kind, BtnToggle)),
                checkOnClick: true);

            if (button != null) _toggleToolbar = kind;
            SetStatus(button != null ? "토글 버튼을 추가했습니다." : "토글 버튼이 이미 있습니다.");
        }

        // 토글 버튼의 눌림 상태를 코드로 지정합니다. 상태만 바뀌고 Click 은 호출되지 않습니다.
        private void chkToggleChecked_CheckedChanged(object sender, EventArgs e)
        {
            if (_toggleToolbar == null) { SetStatus("먼저 토글 버튼을 추가하세요."); return; }

            vizcore3dx.Toolbar.SetChecked(_toggleToolbar.Value, BtnToggle, chkToggleChecked.Checked);
        }

        // 토글 버튼의 현재 눌림 상태를 읽습니다.
        private void btnReadToggle_Click(object sender, EventArgs e)
        {
            if (_toggleToolbar == null) { SetStatus("먼저 토글 버튼을 추가하세요."); return; }

            bool on = vizcore3dx.Toolbar.GetChecked(_toggleToolbar.Value, BtnToggle);
            SetStatus(string.Format("토글 버튼 눌림 상태 : {0}", on));
        }

        // 추가한 사용자 버튼 3개를 모든 툴바에서 제거합니다.
        private void btnRemoveButtons_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (string name in new[] { BtnText, BtnIcon, BtnToggle })
                if (RemoveFromAllToolbars(name)) count++;

            _toggleToolbar = null;

            SetStatus(string.Format("사용자 버튼 {0}개를 제거했습니다.", count));
        }
        #endregion

        #region 3. 패널 사용자 탭
        // 고른 패널의 두 번째 자리에 검사 화면(UserControl)을 담은 탭을 부착하고 선택합니다.
        // 속성 패널은 접힌 채 시작하므로 부착 뒤 AttributePanelVisible = true 로 펼칩니다.
        private void btnAddTab_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.PanelKind kind = SelectedPanel();
            if (_inspection.Parent != null)
            {
                SetStatus("이미 부착된 탭입니다. 먼저 탭을 제거하세요.");
                return;
            }

            TabPage page = vizcore3dx.Panel.AddTab(kind, TabName, txtTabText.Text, _inspection, 1);
            if (page == null)
            {
                SetStatus("이미 부착된 탭입니다.");
                return;
            }

            vizcore3dx.Panel.SelectTab(kind, TabName);
            if (kind == VIZCore3DX.NET.Data.PanelKind.Attribute) vizcore3dx.AttributePanelVisible = true;

            RefreshTabList();
            SetStatus(string.Format("{0} 패널에 탭을 부착했습니다.", kind));
        }

        // 사용자 탭에 표시되는 글자를 바꿉니다.
        private void btnRenameTab_Click(object sender, EventArgs e)
        {
            bool ok = vizcore3dx.Panel.SetTabText(SelectedPanel(), TabName, txtTabText.Text);
            SetStatus(ok ? string.Format("탭 이름 : {0}", vizcore3dx.Panel.GetTabText(SelectedPanel(), TabName)) : "부착된 탭이 없습니다.");
        }

        // 사용자 탭을 맨 앞으로 옮깁니다.
        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            bool ok = vizcore3dx.Panel.MoveTab(SelectedPanel(), TabName, 0);
            RefreshTabList();
            SetStatus(ok ? "탭을 맨 앞으로 옮겼습니다." : "부착된 탭이 없습니다.");
        }

        // 사용자 탭을 맨 뒤로 옮깁니다.
        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.PanelKind kind = SelectedPanel();
            bool ok = vizcore3dx.Panel.MoveTab(kind, TabName, vizcore3dx.Panel.GetTabNames(kind).Count - 1);
            RefreshTabList();
            SetStatus(ok ? "탭을 맨 뒤로 옮겼습니다." : "부착된 탭이 없습니다.");
        }

        // 사용자 탭을 제거합니다. 담긴 검사 화면은 Dispose 되지 않아 다시 부착할 수 있습니다.
        private void btnRemoveTab_Click(object sender, EventArgs e)
        {
            bool ok = vizcore3dx.Panel.RemoveTab(SelectedPanel(), TabName);
            RefreshTabList();
            SetStatus(ok ? "탭을 제거했습니다." : "부착된 탭이 없습니다.");
        }

        // 목록에서 고른 탭을 숨깁니다. 내장 탭(예: tabPageSnapshot)도 숨길 수 있습니다.
        private void btnHideTab_Click(object sender, EventArgs e)
        {
            string name = lstTabs.SelectedItem as string;
            if (name == null) { SetStatus("목록에서 탭을 선택하세요."); return; }

            bool ok = vizcore3dx.Panel.SetTabVisible(SelectedPanel(), name, false);
            if (ok) _hiddenTabs.Add(SelectedPanel() + ":" + name);

            RefreshTabList();
            lstTabs.SelectedItem = name;
            SetStatus(ok ? string.Format("{0} 탭을 숨겼습니다. '선택 탭 표시' 로 되돌립니다.", name) : "숨기지 못했습니다.");
        }

        // 목록에서 고른 탭을 다시 표시합니다.
        private void btnShowTab_Click(object sender, EventArgs e)
        {
            string name = lstTabs.SelectedItem as string;
            if (name == null) { SetStatus("목록에서 탭을 선택하세요."); return; }

            bool ok = vizcore3dx.Panel.SetTabVisible(SelectedPanel(), name, true);
            if (ok) _hiddenTabs.Remove(SelectedPanel() + ":" + name);

            RefreshTabList();
            lstTabs.SelectedItem = name;
            SetStatus(ok ? string.Format("{0} 탭을 표시했습니다.", name) : "표시하지 못했습니다.");
        }

        // 목록의 탭을 두 번 클릭하면 패널에서 그 탭을 선택합니다.
        private void lstTabs_DoubleClick(object sender, EventArgs e)
        {
            string name = lstTabs.SelectedItem as string;
            if (name == null) return;

            vizcore3dx.Panel.SelectTab(SelectedPanel(), name);
        }

        // 패널 종류를 바꾸면 그 패널의 탭 목록과 현재 위치를 다시 읽습니다.
        private void cmbPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTabList();
            SyncPositionCombo();
        }

        // 고른 패널을 화면 왼쪽 또는 오른쪽으로 옮깁니다. 두 패널을 같은 쪽에 둘 수도 있습니다.
        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vizcore3dx == null || cmbPanel.SelectedItem == null || cmbPosition.SelectedItem == null) return;   // 생성자에서 콤보를 채울 때는 뷰어가 아직 없습니다.

            VIZCore3DX.NET.Data.PanelDockPosition position = (VIZCore3DX.NET.Data.PanelDockPosition)cmbPosition.SelectedItem;
            if (position == CurrentPosition()) return;

            if (SelectedPanel() == VIZCore3DX.NET.Data.PanelKind.ModelTree)
                vizcore3dx.View.ModelTreePanelPosition = position;
            else
            {
                vizcore3dx.View.AttributePanelPosition = position;
                vizcore3dx.AttributePanelVisible = true;   // 속성 패널은 접힌 채 시작하므로 펼쳐서 이동을 보여 줍니다.
            }

            SetStatus(string.Format("{0} 패널을 {1} 으로 옮겼습니다.", SelectedPanel(), position));
        }
        #endregion

        #region 4. 정리
        // 사용자 버튼·사용자 탭을 모두 되돌립니다.
        private void btnCleanup_Click(object sender, EventArgs e)
        {
            foreach (string name in new[] { BtnText, BtnIcon, BtnToggle })
                RemoveFromAllToolbars(name);

            vizcore3dx.Panel.RemoveTab(VIZCore3DX.NET.Data.PanelKind.ModelTree, TabName);
            vizcore3dx.Panel.RemoveTab(VIZCore3DX.NET.Data.PanelKind.Attribute, TabName);

            _toggleToolbar = null;
            chkToggleChecked.Checked = false;

            vizcore3dx.View.ModelTreePanelPosition = _initialTreePosition;
            vizcore3dx.View.AttributePanelPosition = _initialAttributePosition;
            SyncPositionCombo();

            RefreshTabList();
            SetStatus("사용자 버튼·탭을 모두 되돌렸습니다.");
        }
        #endregion

        #region Helpers
        private void SetStatus(string message)
        {
            lblStatus.Text = message;
        }

        private VIZCore3DX.NET.Data.ToolbarKind SelectedToolbar()
        {
            return (VIZCore3DX.NET.Data.ToolbarKind)cmbToolbar.SelectedItem;
        }

        private VIZCore3DX.NET.Data.PanelKind SelectedPanel()
        {
            return (VIZCore3DX.NET.Data.PanelKind)cmbPanel.SelectedItem;
        }

        // 토글 버튼이 눌리면 검사 탭을 모델 트리 패널에 부착(처음 한 번)하고 보여 주며, 다시 누르면 숨깁니다.
        private void ToggleInspectionTab(bool on)
        {
            const VIZCore3DX.NET.Data.PanelKind kind = VIZCore3DX.NET.Data.PanelKind.ModelTree;

            bool ok;
            if (on && _inspection.Parent == null)
                ok = vizcore3dx.Panel.AddTab(kind, TabName, txtTabText.Text, _inspection, 1) != null;
            else
                ok = vizcore3dx.Panel.SetTabVisible(kind, TabName, on);

            if (ok && on) vizcore3dx.Panel.SelectTab(kind, TabName);
            RefreshTabList();

            if (!ok) SetStatus("모델 트리 패널에 검사 탭이 없습니다. 속성 패널에 부착돼 있으면 먼저 제거하세요.");
            else SetStatus(on ? "검사 탭을 부착·표시했습니다." : "검사 탭을 숨겼습니다.");
        }

        // 고른 패널의 현재 위치(왼쪽/오른쪽)입니다.
        private VIZCore3DX.NET.Data.PanelDockPosition CurrentPosition()
        {
            return SelectedPanel() == VIZCore3DX.NET.Data.PanelKind.ModelTree
                ? vizcore3dx.View.ModelTreePanelPosition
                : vizcore3dx.View.AttributePanelPosition;
        }

        // 위치 콤보를 고른 패널의 현재 위치로 맞춥니다. 값이 같으면 이동 핸들러는 아무것도 하지 않습니다.
        private void SyncPositionCombo()
        {
            if (vizcore3dx == null || cmbPanel.SelectedItem == null) return;
            cmbPosition.SelectedItem = CurrentPosition();
        }

        // 어느 툴바에 추가했든 지울 수 있도록 모든 툴바에서 같은 이름의 버튼을 제거합니다.
        private bool RemoveFromAllToolbars(string name)
        {
            bool removed = false;
            foreach (VIZCore3DX.NET.Data.ToolbarKind kind in Enum.GetValues(typeof(VIZCore3DX.NET.Data.ToolbarKind)))
                if (vizcore3dx.Toolbar.RemoveButton(kind, name)) removed = true;
            return removed;
        }

        // 고른 패널의 탭 이름을 표시 순서대로 목록에 채우고, 이 예제에서 숨긴 탭은 뒤에 덧붙여 되돌릴 수 있게 합니다.
        private void RefreshTabList()
        {
            if (vizcore3dx == null || cmbPanel.SelectedItem == null) return;   // 생성자에서 콤보를 채울 때는 뷰어가 아직 없습니다.

            lstTabs.Items.Clear();
            foreach (string name in vizcore3dx.Panel.GetTabNames(SelectedPanel()))
                lstTabs.Items.Add(name);

            string prefix = SelectedPanel() + ":";
            foreach (string key in _hiddenTabs)
                if (key.StartsWith(prefix) && !lstTabs.Items.Contains(key.Substring(prefix.Length)))
                    lstTabs.Items.Add(key.Substring(prefix.Length));
        }

        // 지정한 탭만 남기고 나머지 툴바(=리본 탭)와 모델 트리 패널의 같은 이름 탭을 숨깁니다. 홈 탭·모델 트리는 항상 표시합니다.
        // 패널 탭은 GetTabNames 로 지금 있는 탭을 읽어 처리하므로, 나중에 탭이 늘어도 이 함수는 고칠 필요가 없습니다.
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
