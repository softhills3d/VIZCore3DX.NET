using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace VIZCore3DX.NET.VIZXtoVIZ
{
    public partial class FrmMain : Form
    {
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
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
            // 설정 - 내보내기 범위
            // ================================================================
            cbExportOption.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.ExportOption));
            cbExportOption.SelectedItem = VIZCore3DX.NET.Data.ExportOption.ALL;
        }

        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore3dx.Model.OpenFilter;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Model.Open(dlg.FileName);
        }

        private void btnAddModels_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore3dx.Model.OpenFilter;
            dlg.Multiselect = true;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Model.Add(dlg.FileNames);
        }

        private void btnCloseModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Model.Close();
        }

        #region Export Current Model
        /// <summary>
        /// 현재 모델을 저장할 VIZ 파일 경로 지정
        /// </summary>
        private void btnBrowseExportOutput_Click(object sender, EventArgs e)
        {
            string defaultName = "Export.viz";
            if (vizcore3dx.Model.IsOpen() == true && vizcore3dx.Model.Files.Count > 0)
                defaultName = Path.GetFileNameWithoutExtension(vizcore3dx.Model.Files[0]) + ".viz";

            string path = ShowSaveVizDialog(defaultName);
            if (path == null) return;

            txtExportOutput.Text = path;
        }

        /// <summary>
        /// 현재 조회 중인 모델을 VIZ 파일로 내보내기
        /// </summary>
        private void btnExportModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            if (string.IsNullOrEmpty(txtExportOutput.Text) == true)
                btnBrowseExportOutput_Click(sender, e);
            if (string.IsNullOrEmpty(txtExportOutput.Text) == true) return;

            VIZCore3DX.NET.Data.ExportOption option = (VIZCore3DX.NET.Data.ExportOption)cbExportOption.SelectedItem;
            string output = txtExportOutput.Text;

            // ALL : 전체 모델 / VISIBLE : 보이는 개체 / RENDERED : 화면에 그려진 개체 / SELECTED : 선택된 개체
            // ALL 외의 범위는 단일 VIZX 모델을 조회 중일 때만 지원하며, 결과 파일에 마크업(노트/치수/단면/스냅샷 등)과 PMI 는 포함되지 않음
            bool result = false;
            try
            {
                Cursor = Cursors.WaitCursor;
                result = vizcore3dx.Model.ExportVIZ(output, option);
            }
            catch (ArgumentException)
            {
                // 대상 범위에 해당하는 개체가 없으면 예외가 발생
                MessageBox.Show(string.Format("내보낼 개체가 없습니다. ({0})", option), "VIZX to VIZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            ShowResult(string.Format("Export ({0})", option), output, result);
        }
        #endregion

        #region Convert VIZX File
        /// <summary>
        /// 변환할 VIZX 파일 선택
        /// </summary>
        private void btnBrowseConvertInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "VIZX File (*.vizx)|*.vizx";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            txtConvertInput.Text = dlg.FileName;

            // 출력 파일 기본값 : 같은 폴더, 같은 이름의 .viz
            txtConvertOutput.Text = Path.ChangeExtension(dlg.FileName, ".viz");
        }

        /// <summary>
        /// 변환된 VIZ 파일이 저장될 경로 지정
        /// </summary>
        private void btnBrowseConvertOutput_Click(object sender, EventArgs e)
        {
            string defaultName = "Export.viz";
            if (string.IsNullOrEmpty(txtConvertInput.Text) == false)
                defaultName = Path.GetFileNameWithoutExtension(txtConvertInput.Text) + ".viz";

            string path = ShowSaveVizDialog(defaultName);
            if (path == null) return;

            txtConvertOutput.Text = path;
        }

        /// <summary>
        /// VIZX 파일을 열지 않고 VIZ 파일로 변환
        /// </summary>
        private void btnConvertFile_Click(object sender, EventArgs e)
        {
            string input = txtConvertInput.Text;
            string output = txtConvertOutput.Text;

            if (File.Exists(input) == false)
            {
                MessageBox.Show(string.Format("File not found : \n{0}", input), "VIZX to VIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(output) == true) return;

            bool result = false;
            try
            {
                Cursor = Cursors.WaitCursor;
                result = vizcore3dx.Model.ExportVIZ(input, output);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            ShowResult("Convert", output, result);
        }
        #endregion

        #region Result
        private string ShowSaveVizDialog(string defaultName)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "VIZ File (*.viz)|*.viz";
            dlg.FileName = defaultName;
            if (dlg.ShowDialog() != DialogResult.OK) return null;

            return dlg.FileName;
        }

        private void ShowResult(string title, string output, bool result)
        {
            string message;

            if (result == true && File.Exists(output) == true)
                message = string.Format("[{0:HH:mm:ss}] {1} : OK - {2} ({3:N0} KB)", DateTime.Now, title, output, new FileInfo(output).Length / 1024);
            else
                message = string.Format("[{0:HH:mm:ss}] {1} : FAIL - {2}", DateTime.Now, title, output);

            txtResult.AppendText(message + Environment.NewLine);

            if (result == false)
            {
                MessageBox.Show("VIZ 파일로 내보내지 못했습니다.", "VIZX to VIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 결과 파일을 탐색기에서 선택된 상태로 표시
            if (chkShowInExplorer.Checked == true)
                Process.Start("explorer.exe", string.Format("/select,\"{0}\"", output));
        }
        #endregion
    }
}
