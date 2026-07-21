using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.ChildView
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;
        private ShowModelDialog ModelDialog;
        private List<Tuple<int, int>> SelectedNodeKeys;

        public FrmMain()
        {
            InitializeComponent();
            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            // license 인증
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            ModelDialog = null;

            SelectedNodeKeys = new List<Tuple<int, int>>();

        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================
            // 라이선스 파일을 통한 인증
            //vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("192.168.100.252", 8901);


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
            vizcore3dx.ToolbarMain.Visible = true;
            vizcore3dx.ToolbarNote.Visible = false;
            vizcore3dx.ToolbarMeasure.Visible = false;
            vizcore3dx.ToolbarSection.Visible = false;
            vizcore3dx.ToolbarSnapshot.Visible = false;

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================


            vizcore3dx.Model.OnModelOpenedEvent -= Model_OnModelOpenedEvent;
            vizcore3dx.Model.OnModelOpenedEvent += Model_OnModelOpenedEvent;

            vizcore3dx.Model.OnModelClosedEvent -= Model_OnModelClosedEvent;
            vizcore3dx.Model.OnModelClosedEvent += Model_OnModelClosedEvent;


            vizcore3dx.EndUpdate();
        }

        private void Model_OnModelOpenedEvent(object sender, EventManager.ModelOpendEventArgs e)
        {
            if (SelectedNodeKeys == null)
                SelectedNodeKeys = new List<Tuple<int, int>>();
            else
                SelectedNodeKeys.Clear();
        }

        private void Model_OnModelClosedEvent(object sender, EventArgs e)
        {
            if (SelectedNodeKeys == null)
                SelectedNodeKeys = new List<Tuple<int, int>>();
            else
                SelectedNodeKeys.Clear();
        }

        private void btnOpenChildView_Click(object sender, EventArgs e)
        {
            // 모델 오픈 여부 체크
            if (vizcore3dx.Model.IsOpen() == false) return;

            if (SelectedNodeKeys == null) SelectedNodeKeys = new List<Tuple<int, int>>();

            // 선택된 노드 가져오기
            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_PART);
            if (nodes == null || nodes.Count == 0) return;

            foreach (VIZCore3DX.NET.Data.Node node in nodes)
            {
                if (node == null) continue;
                bool exists = SelectedNodeKeys.Any(x => x.Item1 == node.EntityID && x.Item2 == node.Index);

                if (exists == false)
                    SelectedNodeKeys.Add(new Tuple<int, int>(node.EntityID, node.Index));
            }

            if (SelectedNodeKeys.Count == 0) return;

            List<string> modelFiles = vizcore3dx.Model.Files;
            if (modelFiles == null || modelFiles.Count == 0) return;


            if (ModelDialog == null || ModelDialog.IsDisposed)
            {
                ModelDialog = new ShowModelDialog(modelFiles, SelectedNodeKeys);
                ModelDialog.FormClosed += ModelDialog_FormClosed;
                ModelDialog.Show();
            }
            else
            {
                ModelDialog.UpdateSelection(SelectedNodeKeys);
                ModelDialog.Activate();
            }

        }

        private void ModelDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            ModelDialog = null;
        }

        private void btnClearItems_Click(object sender, EventArgs e)
        {
            SelectedNodeKeys.Clear();

            if (ModelDialog != null && ModelDialog.IsDisposed == false)
            {
                ModelDialog.Close();
                ModelDialog = null;
            }
        }
    }
}
