using System;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Command.WebSocket
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 웹 페이지의 요청을 받아 명령으로 실행하는 서버
        private WebSocketServer _server;

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

            _server = new WebSocketServer(vizcore3dx);
            _server.Log += Server_Log;

            ShowAddress();
            SetStatus("모델을 열고 서버를 시작하세요.");
        }

        // 서버는 뷰어가 정리되기 전에 먼저 멈춰야 합니다.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_server != null)
            {
                _server.Log -= Server_Log;
                _server.Stop();
            }

            base.OnFormClosing(e);
        }

        #region 1. 모델
        // 명령으로 조작할 모델을 엽니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            SetStatus("모델을 열었습니다.");
        }
        #endregion

        #region 2. 서버
        // 지정한 포트로 WebSocket 서버를 시작합니다. 포트를 다른 프로그램이 쓰고 있으면 실패를 알립니다.
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_server == null) return;

            _server.ReadOnlyOnly = chkReadOnlyOnly.Checked;

            try
            {
                _server.Start((int)numPort.Value);
            }
            catch (System.Net.HttpListenerException ex)
            {
                SetStatus("서버를 시작하지 못했습니다 : " + ex.Message);
                return;
            }

            SetRunning(true);
            SetStatus("서버를 시작했습니다. 시험 페이지를 열어 명령을 보내 보세요.");
        }

        // 서버를 정지하고 접속해 있는 페이지를 모두 끊습니다.
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_server == null) return;

            _server.Stop();
            SetRunning(false);
            SetStatus("서버를 정지했습니다.");
        }

        // 서버가 보여 주는 시험 페이지를 기본 브라우저로 엽니다.
        private void btnOpenPage_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtUrl.Text);
        }

        // 조회 명령만 받을지 바꿉니다. 서버가 실행 중이어도 바로 적용됩니다.
        private void chkReadOnlyOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (_server == null) return;

            _server.ReadOnlyOnly = chkReadOnlyOnly.Checked;
        }

        // 포트를 바꾸면 시험 페이지 주소를 다시 보여 줍니다.
        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            ShowAddress();
        }
        #endregion

        #region 3. 요청 기록
        // 요청 기록을 지웁니다.
        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        // 서버가 알리는 접속·요청을 기록에 한 줄씩 덧붙입니다. 서버 스레드에서 오므로 UI 스레드로 넘깁니다.
        private void Server_Log(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(Server_Log), message);
                return;
            }

            txtLog.AppendText(string.Format("{0:HH:mm:ss}  {1}\r\n", DateTime.Now, message));
        }
        #endregion

        #region Helpers
        // 서버 실행 여부에 맞춰 버튼과 포트 입력을 켜고 끕니다.
        private void SetRunning(bool running)
        {
            btnStart.Enabled = !running;
            btnStop.Enabled = running;
            btnOpenPage.Enabled = running;
            numPort.Enabled = !running;
        }

        // 현재 포트로 시험 페이지 주소를 보여 줍니다.
        private void ShowAddress()
        {
            txtUrl.Text = string.Format("http://127.0.0.1:{0}/", (int)numPort.Value);
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
