using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.ChildView
{
    public partial class ShowModelDialog : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;
        public List<Tuple<int, int>> SelectedNodeKeys { get; set; }

        public List<string> ModelFiles { get; set; }


        public ShowModelDialog(List<string> modelFiles, List<Tuple<int, int>> selectedNodeKeys)
        {
            InitializeComponent();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            // 저장된 사용자 설정(리본 모드 등)을 무시하고 기본 설정으로 시작 (컨트롤 Load 전에 설정)
            vizcore3dx.LoadSavedSettingOnStartup = false;
            this.Controls.Add(vizcore3dx);

            // license 인증
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            ModelFiles = modelFiles;
            SelectedNodeKeys = selectedNodeKeys;
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

            InitializeVIZCore3DX();

            LoadModel();
        }

        private void InitializeVIZCore3DX()
        {
            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 차단
            // ================================================================
            vizcore3dx.BeginUpdate();

            // ================================================================
            // 설정 - 툴바
            // ================================================================
            // 팝업은 화면만 표시 (리본 / 상단 툴바 숨김)
            vizcore3dx.RibbonMode = false;
            vizcore3dx.ToolbarMain.Visible = false;
            vizcore3dx.Statusbar.Visible = false;
            vizcore3dx.ToolbarNote.Visible = false;
            vizcore3dx.ToolbarMeasure.Visible = false;
            vizcore3dx.ToolbarSection.Visible = false;
            vizcore3dx.ToolbarSnapshot.Visible = false;
            vizcore3dx.View.Toolbar.Enable = false;

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }
        private void LoadModel()
        {
            if (ModelFiles == null || ModelFiles.Count == 0) return;

            try
            {
                vizcore3dx.BeginUpdate();

                vizcore3dx.Model.Close();
                vizcore3dx.Model.Add(ModelFiles);

                List<Node> selectedNodes = new List<Node>();

                foreach (Tuple<int, int> key in SelectedNodeKeys)
                {
                    Node node = vizcore3dx.Object3D.FromEntry(key.Item1, key.Item2);

                    if (node != null)
                        selectedNodes.Add(node);
                }

                // 선택한 파트가 없으면 모델 전체 표시
                if (selectedNodes.Count > 0)
                    vizcore3dx.Object3D.ShowSelection(selectedNodes);

                vizcore3dx.View.FitToView();
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

        }
        internal void UpdateSelection(List<Tuple<int, int>> selectedNodeKeys)
        {
            SelectedNodeKeys = selectedNodeKeys == null
                ? new List<Tuple<int, int>>()
                : new List<Tuple<int, int>>(selectedNodeKeys);

            ApplySelectionOnly();
        }

        private void ApplySelectionOnly()
        {
            if (SelectedNodeKeys == null || SelectedNodeKeys.Count == 0) return;
            if (vizcore3dx.Model.IsOpen() == false) return;

            List<Node> selectedNodes = new List<Node>();

            foreach (Tuple<int, int> key in SelectedNodeKeys)
            {
                Node node = vizcore3dx.Object3D.FromEntry(key.Item1, key.Item2);
                if (node != null)
                    selectedNodes.Add(node);
            }

            if (selectedNodes.Count == 0) return;

            vizcore3dx.Object3D.ShowSelection(selectedNodes);
            vizcore3dx.View.FitToView();
        }
    }
}
