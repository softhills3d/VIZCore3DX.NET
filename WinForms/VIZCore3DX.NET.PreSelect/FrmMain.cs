using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.PreSelect
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 컨트롤 값을 코드에서 바꾸는 동안 핸들러가 뷰어에 되돌려 쓰지 않도록 막습니다.
        private bool _syncing;

        public FrmMain()
        {
            InitializeComponent();

            // 뷰어와 무관한 콤보 항목은 생성자에서 채웁니다. 채우는 동안은 핸들러가 뷰어를 건드리지 않습니다.
            _syncing = true;
            cmbNodeNameTarget.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.PreSelectionNodeNameTarget));
            _syncing = false;

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
            ShowRibbonTabs();
            ShowAttributeTabs();

            ReadToControls();
            SetStatus("모델을 열어 주세요.");
        }

        private void InitializeVIZCore3DXEvent()
        {
            // 마우스가 노드 위에 머물러 사전 선택이 되거나 풀릴 때, 사전 선택 노드가 속한 그룹이 바뀔 때 알림을 받습니다.
            vizcore3dx.View.PreSelect.OnPreSelected += PreSelect_OnPreSelected;
            vizcore3dx.View.PreSelect.OnPreDeselected += PreSelect_OnPreDeselected;
            vizcore3dx.View.PreSelect.OnPreSelectedGroupChanged += PreSelect_OnPreSelectedGroupChanged;
        }

        #region 1. 모델
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (!vizcore3dx.Model.OpenFileDialog()) return;

            SetStatus("모델을 열었습니다. 뷰에서 노드 위로 마우스를 움직여 보세요.");
        }
        #endregion

        #region 2. 설정
        // 마우스 오버 시 노드 형상을 미리 강조하는 기능을 켜고 끕니다.
        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.PreSelect.Enable = chkEnable.Checked;
            SetStatus(chkEnable.Checked ? "사전 선택을 켰습니다." : "사전 선택을 껐습니다.");
        }

        // 강조 외곽선 색
        private void btnOutlineColor_Click(object sender, EventArgs e)
        {
            if (!PickColor(btnOutlineColor)) return;

            vizcore3dx.View.PreSelect.OutlineColor = btnOutlineColor.BackColor;
        }

        // 마우스가 멈춘 뒤 강조까지의 지연 시간(초)
        private void numDelay_ValueChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.PreSelect.Delay = (float)numDelay.Value;
        }

        // 한 번에 강조할 최대 블록 개수. 큰 어셈블리에서 강조 비용을 제한합니다.
        private void numLimit_ValueChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.PreSelect.PreSelectionLimit = (uint)numLimit.Value;
        }

        // 사전 선택 노드 이름을 뷰에 표시할지 여부
        private void chkNodeNameVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.PreSelect.NodeNameVisible = chkNodeNameVisible.Checked;
        }

        // 표시할 이름: 사전 선택 노드 자체 / 상위 파트 / 상위 어셈블리
        private void cmbNodeNameTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.PreSelect.NodeNameTarget = (VIZCore3DX.NET.Data.PreSelectionNodeNameTarget)cmbNodeNameTarget.SelectedItem;
        }

        // 사전 선택된 노드로 모델 트리를 자동 스크롤할지 여부
        private void chkAutoScroll_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.PreSelect.ModelTreeAutoScrollEnabled = chkAutoScroll.Checked;
        }
        #endregion

        #region 3. 동작
        // 지금 강조된 노드를 실제 선택 상태로 바꿉니다(클릭과 같은 결과).
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            if (vizcore3dx.View.PreSelect.PreSelectedNode == null)
            {
                SetStatus("강조된 노드가 없습니다. 노드 위에 마우스를 올린 뒤 누르세요.");
                return;
            }

            vizcore3dx.View.PreSelect.SelectPreSelected();
            SetStatus("사전 선택 노드를 선택했습니다.");
        }

        // 잠그면 마우스를 움직여도 현재 강조가 유지됩니다. 메뉴를 띄우는 등 강조 대상을 고정할 때 씁니다.
        private void btnLock_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            if (vizcore3dx.View.PreSelect.IsLocked)
                vizcore3dx.View.PreSelect.Unlock();
            else
                vizcore3dx.View.PreSelect.Lock();

            ReadLockState();
            SetStatus(vizcore3dx.View.PreSelect.IsLocked ? "사전 선택을 잠갔습니다." : "사전 선택 잠금을 풀었습니다.");
        }

        // 현재 강조를 지웁니다.
        private void btnClearPreSelection_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            vizcore3dx.View.PreSelect.ClearPreSelection();
            SetStatus("사전 선택을 지웠습니다.");
        }
        #endregion

        #region 4. 이벤트 로그
        private void PreSelect_OnPreSelected(object sender, VIZCore3DX.NET.Event.EventManager.PreSelectEventArgs e)
        {
            RunOnUi(() =>
            {
                AppendLog("강조", e.Node);
                lblCurrent.Text = "현재: " + NodeName(e.Node);
            });
        }

        private void PreSelect_OnPreDeselected(object sender, VIZCore3DX.NET.Event.EventManager.PreSelectEventArgs e)
        {
            RunOnUi(() =>
            {
                AppendLog("해제", e.Node);
                lblCurrent.Text = "현재: -";
            });
        }

        private void PreSelect_OnPreSelectedGroupChanged(object sender, VIZCore3DX.NET.Event.EventManager.PreSelectGroupChangedEventArgs e)
        {
            RunOnUi(() => AppendLog("그룹", string.Format("{0} → {1}", GroupName(e.PreviousGroup), GroupName(e.CurrentGroup))));
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
        }
        #endregion

        #region 5. 정리
        // 사전 선택을 끄고 잠금·강조·로그를 모두 비웁니다.
        private void btnReset_Click(object sender, EventArgs e)
        {
            vizcore3dx.View.PreSelect.Unlock();
            vizcore3dx.View.PreSelect.ClearPreSelection();
            vizcore3dx.View.PreSelect.Enable = false;

            lstLog.Items.Clear();
            lblCurrent.Text = "현재: -";
            ReadToControls();
            SetStatus("사전 선택을 끄고 정리했습니다.");
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

        // 뷰어 이벤트는 UI 스레드가 아닐 수 있으므로 컨트롤을 건드리기 전에 넘겨 줍니다.
        private void RunOnUi(Action action)
        {
            if (InvokeRequired) BeginInvoke(action);
            else action();
        }

        // 뷰어의 현재 사전 선택 설정을 컨트롤에 반영합니다.
        private void ReadToControls()
        {
            VIZCore3DX.NET.Manager.PreSelectManager pre = vizcore3dx.View.PreSelect;

            _syncing = true;
            try
            {
                chkEnable.Checked = pre.Enable;
                btnOutlineColor.BackColor = pre.OutlineColor;
                numDelay.Value = Clamp(numDelay, pre.Delay);
                numLimit.Value = Clamp(numLimit, pre.PreSelectionLimit);
                chkNodeNameVisible.Checked = pre.NodeNameVisible;
                cmbNodeNameTarget.SelectedItem = pre.NodeNameTarget;
                chkAutoScroll.Checked = pre.ModelTreeAutoScrollEnabled;
                ReadLockState();
            }
            finally
            {
                _syncing = false;
            }
        }

        private void ReadLockState()
        {
            btnLock.Text = vizcore3dx.View.PreSelect.IsLocked ? "잠금 해제" : "잠금";
        }

        // 값을 NumericUpDown 범위 안의 decimal 로 바꿉니다. NaN 이면 최소값으로 둡니다.
        private static decimal Clamp(NumericUpDown control, float value)
        {
            if (float.IsNaN(value) || float.IsInfinity(value)) return control.Minimum;

            decimal d = (decimal)value;
            return Math.Max(control.Minimum, Math.Min(control.Maximum, d));
        }

        // 색 선택 대화상자를 띄워 버튼 배경색으로 반영합니다. 취소하면 false 입니다.
        private bool PickColor(Button button)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = button.BackColor;
                dialog.FullOpen = true;
                if (dialog.ShowDialog(this) != DialogResult.OK) return false;

                button.BackColor = dialog.Color;
                return true;
            }
        }

        private void AppendLog(string kind, VIZCore3DX.NET.Data.Node node)
        {
            AppendLog(kind, NodeName(node));
        }

        private void AppendLog(string kind, string detail)
        {
            lstLog.Items.Add(string.Format("{0:HH:mm:ss.fff}  {1}  {2}", DateTime.Now, kind, detail));
            lstLog.TopIndex = lstLog.Items.Count - 1;
        }

        private static string NodeName(VIZCore3DX.NET.Data.Node node)
        {
            return node == null ? "-" : node.NodeName;
        }

        private static string GroupName(VIZCore3DX.NET.Data.GroupItem group)
        {
            return group == null ? "(없음)" : group.Name;
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
