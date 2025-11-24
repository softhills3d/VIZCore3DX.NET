using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;
using VIZCore3DX.NET.Manager;
using static VIZCore3DX.NET.Manager.SectionManager;

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

            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3D_OnInitializedVIZCore3D;
        }

        private void VIZCore3D_OnInitializedVIZCore3D(object sender, EventArgs e)
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
            vizcore3dx.EndUpdate();
        }

        /// <summary>
        /// VIZX to VIZ 변환
        /// </summary>
        /// <param name="inputFilePath">변환 전 vizx 파일</param>
        /// <param name="outputFilePath">변환 후 저장할 viz 파일</param>
        /// <param name="exeFileName">VIZX to VIZ 변환기 프로그램</param>
        /// <param name="argument">스냅샷 분할 여부를 체크하는 argument</param>
        private void convertVizxToViz(string inputFilePath, string outputFilePath, string exeFileName, string argument)
        {
            if (!System.IO.File.Exists(inputFilePath))
            {
                MessageBox.Show($"File not found : \n{inputFilePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string currentPath = Application.StartupPath;
            string convertFilePath = Path.Combine(currentPath, exeFileName);

            ProcessStartInfo startInfo = new ProcessStartInfo();

            /*
             * VIZX to VIZ 사용법
             * 중요!!! : 같은 디렉토리 내에 VIZXMigration.exe 파일과 ShdCore.dll 파일이 존재해야함.
             *
             * 1. 일반적인 사용 방법
             * VIZXMigration.exe -mode VIZX2VIZ -i "변환 전 vizx 파일경로" -o "변환 후 viz 파일 경로"
             *
             * 2. 스냅샷 별로 파일 분할이 필요한 경우
             * VIZXMigration.exe -mode VIZX2VIZ -i "변환 전 vizx 파일경로" -o "변환 후 viz 파일 경로" -export_snapshot_to_viz t
            */


            // CMD 창을 띄우지 않고 백그라운드에서 실행
            if (!cbViewCmd.Checked)
            {
                startInfo.FileName = exeFileName;
                startInfo.Arguments = $"-mode VIZX2VIZ -i \"{inputFilePath}\" -o \"{outputFilePath}\" {argument}";
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
            }
            else
            {
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/k {exeFileName} -mode VIZX2VIZ -i \"{inputFilePath}\" -o \"{outputFilePath}\" {argument}";
            }

                try
                {
                    bool status = vizcore3dx.EnableWaitForm;
                    Process p = Process.Start(startInfo);

                    vizcore3dx.EnableWaitForm = false;
                    vizcore3dx.ShowWaitForm();
                    vizcore3dx.UpdateWaitForm("Please Wait...", "Processing...");

                    // VIZX to VIZ 변환기가 종료될 때 까지 Wait
                    p.WaitForExit();

                    vizcore3dx.CloseWaitForm();
                    vizcore3dx.EnableWaitForm = status;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error : {ex.Message}");
                }
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

        /// <summary>
        ///  viz 변환된 파일이 저장 될 경로 지정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetConvertPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.Description = "Please Set Convert Path.";

            if (folderDlg.ShowDialog() == DialogResult.OK)
            {
                convertPath.Text = folderDlg.SelectedPath;
            }
        }

        /// <summary>
        /// VIZX to VIZ 변환기 실행
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            if (convertPath.Text == "") return;

            DialogResult result = MessageBox.Show("The current file is saved.", "Caution", MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            if (result == DialogResult.Cancel) return;

            string outputFileName = "output.viz";
            string inputFilePath;
            string outputFilePath = Path.Combine(convertPath.Text, outputFileName);
            string convertExe = "VIZXMigration.exe";
            string argument = "";

            vizcore3dx.Model.SaveFileDialog();
            inputFilePath = vizcore3dx.Model.Files[0];

            // 스냅샷 별로 분할하여 viz 파일들을 저장하는 args : -export_snapshot_to_viz t
            if (cbSnapshotCheck.Checked)
            {
                argument = "-export_snapshot_to_viz t";
            }

            convertVizxToViz(inputFilePath, outputFilePath, convertExe, argument);
        }

    }
}
