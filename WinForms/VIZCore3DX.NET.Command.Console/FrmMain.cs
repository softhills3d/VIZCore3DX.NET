using System;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Command.Console
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 결과 창에 그대로 보여 줄 최대 글자 수 (화면 캡처처럼 긴 결과는 앞부분만 표시)
        private const int MaxResultLength = 20000;

        public FrmMain()
        {
            InitializeComponent();

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

            LoadCommands();
            SetStatus("모델을 열고 명령을 골라 실행하세요.");
        }

        #region 1. 모델
        // 명령으로 조작할 모델을 엽니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            SetStatus("모델을 열었습니다.");
        }
        #endregion

        #region 2. 명령
        // 조회 명령만 볼지, 변경 명령까지 볼지 바꿉니다.
        private void chkReadOnlyOnly_CheckedChanged(object sender, EventArgs e)
        {
            LoadCommands();
        }

        // 고른 명령의 인자 형식(JSON Schema)을 보여 주고 인자 입력란을 비웁니다.
        private void dgvCommands_SelectionChanged(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.CommandItem item = GetSelectedCommand();

            txtSchema.Text = item == null ? string.Empty : item.ParameterSchema;
            txtArguments.Text = "{}";
        }
        #endregion

        #region 3. 실행
        // 고른 명령을 이름과 인자 JSON 으로 실행합니다. 잘못된 인자도 예외 없이 실패 결과로 돌아옵니다.
        private void btnExecute_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.CommandItem item = GetSelectedCommand();
            if (item == null)
            {
                SetStatus("실행할 명령을 고르세요.");
                return;
            }

            VIZCore3DX.NET.Data.CommandResult result = vizcore3dx.Command.Execute(item.Name, txtArguments.Text);

            ShowResult(item.Name, result);
        }

        // 열린 모델·선택·카메라 상태 요약을 봅니다. 외부 시스템에 "지금 화면"을 알려 줄 때 씁니다.
        private void btnContext_Click(object sender, EventArgs e)
        {
            lblResult.Text = "상태 요약";
            txtResult.Text = vizcore3dx.Command.GetContext();
            SetStatus("상태 요약을 가져왔습니다.");
        }

        // 명령 목록 전체를 JSON 으로 봅니다. AI(LLM)에 "쓸 수 있는 도구 목록"으로 그대로 넘기는 내용입니다.
        private void btnCatalog_Click(object sender, EventArgs e)
        {
            lblResult.Text = "명령 목록 JSON";
            txtResult.Text = vizcore3dx.Command.GetCatalog();
            SetStatus("명령 목록 JSON 을 가져왔습니다.");
        }
        #endregion

        #region Helpers
        // 등록된 명령 목록을 표에 채웁니다. 행의 Tag 에 명령 정의를 넣어 둡니다.
        private void LoadCommands()
        {
            dgvCommands.Rows.Clear();

            foreach (VIZCore3DX.NET.Data.CommandItem item in vizcore3dx.Command.GetCommands())
            {
                if (chkReadOnlyOnly.Checked && item.IsReadOnly == false) continue;

                int index = dgvCommands.Rows.Add(item.Name, item.IsReadOnly ? "조회" : "변경", item.Description);
                dgvCommands.Rows[index].Tag = item;
            }

            SetStatus(string.Format("명령 {0}개", dgvCommands.Rows.Count));
        }

        // 표에서 고른 명령을 돌려줍니다. 고른 행이 없으면 null 입니다.
        private VIZCore3DX.NET.Data.CommandItem GetSelectedCommand()
        {
            if (dgvCommands.CurrentRow == null) return null;

            return dgvCommands.CurrentRow.Tag as VIZCore3DX.NET.Data.CommandItem;
        }

        // 실행 결과를 보여 줍니다. 성공이면 결과 JSON, 실패면 사유를 표시합니다.
        private void ShowResult(string name, VIZCore3DX.NET.Data.CommandResult result)
        {
            string text = result.Success ? result.Json : result.ErrorMessage;
            if (text.Length > MaxResultLength)
                text = text.Substring(0, MaxResultLength) + string.Format(" ... (전체 {0}자)", text.Length);

            lblResult.Text = string.Format("{0} : {1}", result.Success ? "성공" : "실패", name);
            txtResult.Text = text;
            SetStatus(result.Success ? "명령을 실행했습니다." : "명령이 실패했습니다. 결과의 사유를 확인하세요.");
        }

        private void SetStatus(string message)
        {
            lblStatus.Text = message;
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
