using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.ExportNode
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;
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

            // OBJ 내보내기 옵션 UI 초기화
            InitializeObjOptionUI();
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
            vizcore3dx.EndUpdate();

            // ================================================================
            // 설정 - Body 사용 (OBJ 내보내기의 전제 조건, 모델 열기 전에 설정)
            // ================================================================
            vizcore3dx.Model.EnableBody = true;
        }

        private void InitializeObjOptionUI()
        {
            // 기본값은 ObjExportOption 생성 시 값 사용
            ObjExportOption option = new ObjExportOption();

            cmbVertexColor.DataSource = Enum.GetValues(typeof(ObjVertexColorMode));
            cmbVertexColor.SelectedItem = option.VertexColor;

            cmbMaterialGrouping.DataSource = Enum.GetValues(typeof(ObjMaterialGrouping));
            cmbMaterialGrouping.SelectedItem = option.MaterialGrouping;

            chkIncludeNormals.Checked = option.IncludeNormals;
            chkIncludeGroups.Checked = option.IncludeGroups;
        }

        private void ShowOperationFailed(string message)
        {
            VIZCore3DX.NET.Data.OperationStatus status = vizcore3dx.Model.LastOperationStatus;
            string reason = status == null ? "알 수 없음" : status.ToString();

            MessageBox.Show(string.Format("{0}\n\n사유 : {1}", message, reason), "VIZCore3DX.NET.ExportNode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (String.IsNullOrEmpty(txtPath.Text) == false)
                dlg.SelectedPath = txtPath.Text;

            if (dlg.ShowDialog() != DialogResult.OK) return;
            txtPath.Text = dlg.SelectedPath;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 로드해 주세요.");
                return;
            }

            // ================================================================
            // Source : All Node - 전체 모델 / Selected Node - 선택한 노드(및 하위)
            // ================================================================
            List<Node> nodes = null;
            if (rbSelectedNode.Checked == true)
            {
                nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP);
                if (nodes == null || nodes.Count == 0)
                {
                    MessageBox.Show("내보낼 노드를 선택해 주세요.", "VIZCore3DX.NET.ExportNode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // By Node : 선택한 노드마다 Dest 폴더에 VIZX 파일을 하나씩 저장
            if (nodes != null && ckByNode.Checked == true)
            {
                ExportByNode(nodes);
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "VIZX (*.vizx)|*.vizx";
            if (String.IsNullOrEmpty(txtPath.Text) == false) dlg.InitialDirectory = txtPath.Text;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            bool result;
            if (nodes == null)
                result = vizcore3dx.Model.ExportVIZX(dlg.FileName);
            else
                result = vizcore3dx.Model.ExportVIZX(dlg.FileName, nodes);

            if (result == false)
            {
                ShowOperationFailed("내보내기 실패");
                return;
            }

            MessageBox.Show("내보내기 완료");
        }

        // ================================================================
        // 노드별 내보내기 : ExportNode
        // ================================================================
        private void ExportByNode(List<Node> nodes)
        {
            if (String.IsNullOrEmpty(txtPath.Text) == true || Directory.Exists(txtPath.Text) == false)
            {
                MessageBox.Show("Dest 폴더를 선택해 주세요.", "VIZCore3DX.NET.ExportNode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<string> fileNames = new List<string>();
            List<string> failed = new List<string>();

            foreach (Node node in nodes)
            {
                string path = Path.Combine(txtPath.Text, GetUniqueFileName(node.NodeName, fileNames) + ".vizx");

                // keepAncestors : true 이면 상위 어셈블리 경로를 유지하여 저장
                if (vizcore3dx.Model.ExportNode(path, node, chkKeepAncestors.Checked) == false)
                    failed.Add(node.NodeName);
            }

            if (failed.Count > 0)
            {
                ShowOperationFailed(string.Format("노드 내보내기 실패 : {0} / {1}\n\n{2}", failed.Count, nodes.Count, string.Join("\n", failed)));
                return;
            }

            MessageBox.Show(string.Format("노드 내보내기 완료 : {0}개\n\n폴더 : {1}", nodes.Count, txtPath.Text), "VIZCore3DX.NET.ExportNode", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 노드 이름을 파일 이름으로 사용 (사용할 수 없는 문자는 '_', 같은 이름은 번호를 붙임)
        private string GetUniqueFileName(string nodeName, List<string> used)
        {
            string name = String.IsNullOrWhiteSpace(nodeName) == true ? "Node" : nodeName.Trim();
            foreach (char c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');

            string unique = name;
            int index = 1;
            while (used.Contains(unique.ToLowerInvariant()) == true)
                unique = string.Format("{0}_{1}", name, ++index);

            used.Add(unique.ToLowerInvariant());
            return unique;
        }

        // ================================================================
        // OBJ 내보내기 : ExportObj(path, option) / ExportObj(path, nodes, option)
        // ================================================================
        private void btnMtlPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "MTL (*.mtl)|*.mtl";
            if (String.IsNullOrEmpty(txtMtlPath.Text) == false) dlg.FileName = txtMtlPath.Text;

            if (dlg.ShowDialog() != DialogResult.OK) return;
            txtMtlPath.Text = dlg.FileName;
        }

        private void btnExportObj_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 로드해 주세요.", "VIZCore3DX.NET.ExportNode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<Node> nodes = null;
            if (chkObjSelectedOnly.Checked == true)
            {
                nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP);
                if (nodes == null || nodes.Count == 0)
                {
                    MessageBox.Show("내보낼 노드를 선택해 주세요.", "VIZCore3DX.NET.ExportNode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "OBJ (*.obj)|*.obj";
            if (String.IsNullOrEmpty(txtPath.Text) == false) dlg.InitialDirectory = txtPath.Text;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            // OBJ 내보내기 옵션
            ObjExportOption option = new ObjExportOption();
            option.VertexColor = (ObjVertexColorMode)cmbVertexColor.SelectedItem;
            option.MaterialGrouping = (ObjMaterialGrouping)cmbMaterialGrouping.SelectedItem;
            option.IncludeNormals = chkIncludeNormals.Checked;
            option.IncludeGroups = chkIncludeGroups.Checked;
            if (String.IsNullOrWhiteSpace(txtMtlPath.Text) == false) option.MaterialPath = txtMtlPath.Text.Trim();

            // ExportObj 는 EnableBody 가 false 이거나 내보낼 메시가 없으면 예외 발생
            try
            {
                if (nodes == null)
                    vizcore3dx.Model.ExportObj(dlg.FileName, option);
                else
                    vizcore3dx.Model.ExportObj(dlg.FileName, nodes, option);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("OBJ 내보내기 실패\n\n사유 : {0}", ex.Message), "VIZCore3DX.NET.ExportNode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            VIZCore3DX.NET.Data.OperationStatus status = vizcore3dx.Model.LastOperationStatus;
            if ((status != null && status.IsFailure) || File.Exists(dlg.FileName) == false)
            {
                ShowOperationFailed("OBJ 내보내기 실패");
                return;
            }

            MessageBox.Show(string.Format("OBJ 내보내기 완료\n\n파일 : {0}", dlg.FileName), "VIZCore3DX.NET.ExportNode", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
