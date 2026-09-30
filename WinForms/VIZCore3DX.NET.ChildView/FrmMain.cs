using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.ChildView
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;
        // 열려 있는 팝업(Child View) 목록 : Show Child View 를 누를 때마다 새 팝업 생성
        private readonly List<ShowModelDialog> ModelDialogs = new List<ShowModelDialog>();
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

            InitializeSubViewOption();
        }

        private void InitializeSubViewOption()
        {
            // SetSubView(count) : 주 화면 외에 추가할 서브뷰 구성 (0 ~ 4)
            cmbSubViewLayout.Items.Clear();
            cmbSubViewLayout.Items.Add("0 : 단일 화면 (서브뷰 없음)");
            cmbSubViewLayout.Items.Add("1 : 좌우 2분할");
            cmbSubViewLayout.Items.Add("2 : 1+2 분할 (우측 서브뷰 2개)");
            cmbSubViewLayout.Items.Add("3 : 2x2 4분할");
            cmbSubViewLayout.Items.Add("4 : 1+3 분할 (우측 서브뷰 3개)");
            cmbSubViewLayout.SelectedIndex = 4;

            // 서브뷰 생성 시 화면 설정 초기화 방식
            cmbSubViewInitMode.Items.Clear();
            foreach (VIZCore3DX.NET.Data.SubViewInitMode mode in Enum.GetValues(typeof(VIZCore3DX.NET.Data.SubViewInitMode))) cmbSubViewInitMode.Items.Add(mode);
            cmbSubViewInitMode.SelectedItem = vizcore3dx.View.SubViewInitMode;

            UpdateSubViewCount();
        }

        private void UpdateSubViewCount()
        {
            lblSubViewCount.Text = string.Format("현재 서브뷰 수 : {0}", vizcore3dx.View.GetSubViewCount());
        }

        private void btnApplySubView_Click(object sender, EventArgs e)
        {
            if (cmbSubViewLayout.SelectedIndex < 0) return;

            if (cmbSubViewInitMode.SelectedItem != null)
                vizcore3dx.View.SubViewInitMode = (VIZCore3DX.NET.Data.SubViewInitMode)cmbSubViewInitMode.SelectedItem;

            // 콤보박스 인덱스 = SetSubView 인자 (4 : 주 화면 + 우측 서브뷰 3개)
            vizcore3dx.View.SetSubView(cmbSubViewLayout.SelectedIndex);

            UpdateSubViewCount();
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
            // 선택된 노드 가져오기
            // 선택한 파트가 있으면 그 파트만, 없으면 모델 전체를 새 팝업에 표시
            List<Tuple<int, int>> nodeKeys = new List<Tuple<int, int>>();
            List<string> modelFiles = new List<string>();

            if (vizcore3dx.Model.IsOpen() == true)
            {
                List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_PART);
                if (nodes != null)
                {
                    foreach (VIZCore3DX.NET.Data.Node node in nodes)
                    {
                        if (node == null) continue;
                        nodeKeys.Add(new Tuple<int, int>(node.EntityID, node.Index));
                    }
                }

                if (vizcore3dx.Model.Files != null) modelFiles.AddRange(vizcore3dx.Model.Files);
            }

            ShowModelDialog dialog = new ShowModelDialog(modelFiles, nodeKeys);
            dialog.Text = string.Format("Child View #{0} ({1})", ModelDialogs.Count + 1, nodeKeys.Count == 0 ? "전체" : nodeKeys.Count + " Parts");
            dialog.FormClosed += ModelDialog_FormClosed;
            ModelDialogs.Add(dialog);
            dialog.Show();
        }

        private void ModelDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            ModelDialogs.Remove(sender as ShowModelDialog);
        }

        private void btnClearItems_Click(object sender, EventArgs e)
        {
            if (ModelDialogs.Count == 0)
            {
                MessageBox.Show("열려 있는 팝업이 없습니다.", "VIZCore3DX.NET.ChildView", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 열려 있는 팝업 모두 닫기
            foreach (ShowModelDialog dialog in ModelDialogs.ToArray())
            {
                if (dialog.IsDisposed == false) dialog.Close();
            }

            ModelDialogs.Clear();
        }
    }
}
