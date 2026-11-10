using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Command.Chat
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // AI 공급자 (Claude / OpenAI 호환). 대화 기록도 공급자가 보관합니다.
        private ChatProvider _provider;

        // 요청 한 번에 AI 가 명령을 이어서 부를 수 있는 최대 횟수
        private const int MaxRounds = 10;

        // 대화 창에 보여 줄 명령 결과의 최대 글자 수 (AI 에는 전체를 전달합니다)
        private const int MaxResultLength = 500;

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

            // 공급자 목록 (순서 = cmbProvider_SelectedIndexChanged 의 index)
            cmbProvider.Items.Add("Claude (Anthropic)");
            cmbProvider.Items.Add("OpenAI 호환 (사내·로컬 LLM)");
            cmbProvider.SelectedIndex = 0;
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

            SetStatus("모델을 열고 AI 연결 정보를 입력한 뒤 요청을 보내세요.");
        }

        #region 1. 모델
        // AI 가 명령으로 조작할 모델을 엽니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            SetStatus("모델을 열었습니다.");
        }
        #endregion

        #region 2. AI 연결
        // 공급자를 바꿉니다. 공급자마다 요청 형식이 달라 대화는 새로 시작합니다.
        private void cmbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isClaude = cmbProvider.SelectedIndex == 0;

            if (isClaude) _provider = new ClaudeProvider();
            else _provider = new OpenAiProvider();

            txtEndpoint.Text = isClaude ? ClaudeProvider.DefaultEndpoint : OpenAiProvider.DefaultEndpoint;
            txtModel.Text = isClaude ? ClaudeProvider.DefaultModel : OpenAiProvider.DefaultModel;
            txtChat.Clear();
            SetStatus("공급자를 바꿨습니다. 주소·모델·API 키를 확인하세요.");
        }
        #endregion

        #region 3. 대화
        // 요청을 AI 에 보냅니다. AI 가 명령을 부르면 실행해 결과를 돌려주고, AI 가 답을 마칠 때까지 되풀이합니다.
        private async void btnSend_Click(object sender, EventArgs e)
        {
            string text = txtInput.Text.Trim();
            if (text.Length == 0 || CheckSettings() == false) return;

            _provider.Endpoint = txtEndpoint.Text.Trim();
            _provider.Model = txtModel.Text.Trim();
            _provider.ApiKey = txtApiKey.Text.Trim();
            _provider.AddUser(text);

            AppendChat("나", text);
            txtInput.Clear();
            SetBusy(true);

            try
            {
                await RunTurnAsync();
                SetStatus("응답을 받았습니다.");
            }
            catch (Exception ex)
            {
                AppendChat("오류", ex.Message);
                SetStatus("AI 호출에 실패했습니다. 주소·모델·API 키를 확인하세요.");
            }

            SetBusy(false);
        }

        // 대화 기록을 지우고 새로 시작합니다. 뷰어 상태는 그대로 둡니다.
        private void btnReset_Click(object sender, EventArgs e)
        {
            _provider.Reset();
            txtChat.Clear();
            SetStatus("대화를 초기화했습니다.");
        }
        #endregion

        #region Helpers
        // AI 응답 → 명령 실행 → 결과 전달을 AI 가 명령을 더 부르지 않을 때까지 되풀이합니다.
        private async Task RunTurnAsync()
        {
            // 안내문(명령 조합법)과 지금 화면 상태를 AI 에 알려 줍니다.
            string system = vizcore3dx.Command.GetGuide() + "\n\nCurrent viewer state (JSON): " + vizcore3dx.Command.GetContext();
            List<VIZCore3DX.NET.Data.CommandItem> tools = GetTools();

            for (int round = 0; round < MaxRounds; round++)
            {
                ChatReply reply = await _provider.SendAsync(system, tools);

                if (reply.Text.Length > 0) AppendChat("AI", reply.Text);
                if (reply.Calls.Count == 0) return;

                foreach (ChatToolCall call in reply.Calls)
                    ExecuteCall(call, tools);
            }

            AppendChat("안내", string.Format("명령 호출이 {0}회를 넘어 멈췄습니다.", MaxRounds));
        }

        // AI 에 공개할 명령 목록을 만듭니다. 명령 정의(이름·설명·인자 형식)가 그대로 AI 의 도구 정의가 됩니다.
        private List<VIZCore3DX.NET.Data.CommandItem> GetTools()
        {
            List<VIZCore3DX.NET.Data.CommandItem> tools = new List<VIZCore3DX.NET.Data.CommandItem>();

            foreach (VIZCore3DX.NET.Data.CommandItem item in vizcore3dx.Command.GetCommands())
            {
                // 화면 캡처는 결과(이미지)가 커서 글로 주고받는 이 예제에서는 뺍니다.
                if (item.Name == "capture_screenshot") continue;
                if (chkReadOnlyOnly.Checked && item.IsReadOnly == false) continue;

                tools.Add(item);
            }

            return tools;
        }

        // AI 가 요청한 명령 하나를 실행하고 결과를 대화 기록에 더합니다. 실패 사유도 그대로 전달해 AI 가 스스로 고치게 합니다.
        private void ExecuteCall(ChatToolCall call, List<VIZCore3DX.NET.Data.CommandItem> tools)
        {
            // 공개하지 않은 명령은 실행하지 않습니다.
            if (tools.Exists(x => x.Name == call.Name) == false)
            {
                _provider.AddToolResult(call, "This command is not available.", true);
                AppendChat("명령", call.Name + " → 거절");
                return;
            }

            VIZCore3DX.NET.Data.CommandResult result = vizcore3dx.Command.Execute(call.Name, call.ArgumentsJson);
            string content = result.Success ? result.Json : result.ErrorMessage;

            _provider.AddToolResult(call, content, result.Success == false);

            if (content.Length > MaxResultLength) content = content.Substring(0, MaxResultLength) + " ...";
            AppendChat("명령", string.Format("{0} {1} → {2} : {3}", call.Name, call.ArgumentsJson, result.Success ? "성공" : "실패", content));
        }

        // 보내기 전에 입력을 확인합니다. 주소·모델 이름은 공통으로, API 키는 Claude 에 필요합니다.
        private bool CheckSettings()
        {
            if (txtEndpoint.Text.Trim().Length == 0 || txtModel.Text.Trim().Length == 0)
            {
                SetStatus("주소와 모델 이름을 입력하세요.");
                return false;
            }

            if (_provider is ClaudeProvider && txtApiKey.Text.Trim().Length == 0)
            {
                SetStatus("API 키를 입력하세요.");
                return false;
            }

            return true;
        }

        // 응답을 기다리는 동안 입력을 잠급니다.
        private void SetBusy(bool busy)
        {
            btnSend.Enabled = !busy;
            btnReset.Enabled = !busy;
            cmbProvider.Enabled = !busy;
            if (busy) SetStatus("AI 의 응답을 기다리는 중입니다...");
        }

        private void AppendChat(string who, string text)
        {
            txtChat.AppendText(string.Format("[{0}] {1}\r\n\r\n", who, text.Replace("\r\n", "\n").Replace("\n", "\r\n")));
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
