using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.NET.CameraDataSaver
{
    public partial class Form1: Form
    {
        /// <summary>
        /// VIZCore3DX.NET Control
        /// </summary>
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        private VIZCore3DX.NET.Data.CameraData cameraData { get; set; }

        public Form1()
        {
            InitializeComponent();

            // VIZCore3DX Module Init
            VIZCore3DX.NET.ModuleInitializer.Run();
            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3D_OnInitializedVIZCore3D;

            // Panel Control Add
            splitContainer1.Panel2.Controls.Add(vizcore3dx);
        }

        private void VIZCore3D_OnInitializedVIZCore3D(object sender, EventArgs e)
        {
            // 라이선스 서버를 통한 인증
            vizcore3dx.License.LicenseServer("192.168.0.215", 8901);
        }

        /// <summary>
        /// 카메라 데이터 저장 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCameraSave_Click(object sender, EventArgs e)
        {
            // 카메라 데이터 저장 
            cameraData = vizcore3dx.View.GetCameraData();
            if (cameraData != null)
            {
                MessageBox.Show("현재 화면이 저장되었습니다.");

                #region Console Visual Text
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===========================================");
                Console.WriteLine("             Camera Data                   ");
                Console.WriteLine("===========================================");

                // Camera Direction
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Camera Direction : ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"X = {cameraData.CameraDirection.X}, Y = {cameraData.CameraDirection.Y}, Z = {cameraData.CameraDirection.Z}");

                // Eye Position
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Eye Position     : ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"X = {cameraData.EyePosition.X}, Y = {cameraData.EyePosition.Y}, Z = {cameraData.EyePosition.Z}");

                // Pivot Position
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Pivot Position   : ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"X = {cameraData.PivotPosition.X}, Y = {cameraData.PivotPosition.Y}, Z = {cameraData.PivotPosition.Z}");

                // Projection Type
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Projection Type  : ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{cameraData.ProjectionType}");

                // Up Direction
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Up Direction     : ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"X = {cameraData.UpDirection.X}, Y = {cameraData.UpDirection.Y}, Z = {cameraData.UpDirection.Z}");

                // Zoom
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Zoom Level       : ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{cameraData.Zoom}");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===========================================");

                Console.ResetColor();
                #endregion

                return;
            }
        }

        /// <summary>
        /// 카메라 데이터 로드 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCameraLoad_Click(object sender, EventArgs e)
        {
            if (cameraData == null) return;

            // 카메라 데이터 로드
            // 실제 필요한 카메라 데이터 [ CameraDirection, EyePosition, PivotPosition, ProjectionType, UpDirection, Zoom ]
            vizcore3dx.View.SetCameraData(cameraData);
        }

        /// <summary>
        /// 액션 카메라 데이터 로드 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActionLoad_Click(object sender, EventArgs e)
        {
            if (cameraData == null) return;

            // 카메라 액션 이동 시간 지정
            TimeSpan timeSpan = TimeSpan.FromSeconds(Convert.ToInt64(numCameraMoveTime.Value));

            // 카메라 데이터 로드 및 이동 시간 할당
            vizcore3dx.View.SetCameraData(cameraData, timeSpan);
        }
    }
}
