using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static VIZCore3DX.NET.Event.EventManager;

namespace VIZCore3DX.NET.ZoneObjects
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DXControl vizcore3dx;
        private int SelectionBox = -1;

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(vizcore3dx);

            // License
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

            if (result != Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeVIZCore3DX();
            InitializeVIZCore3DXEvent();
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
            vizcore3dx.ToolbarClash.Visible = false;
            vizcore3dx.ToolbarDecal.Visible = false;
            vizcore3dx.ToolbarPrimitive.Visible = false;
            vizcore3dx.ToolbarAnimation.Visible = false;
            vizcore3dx.ToolbarSimulation.Visible = false;

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }

        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.SelectionBox.OnSelectionBoxSelectedEvent -= SelectionBox_OnSelected;
            vizcore3dx.SelectionBox.OnSelectionBoxSelectedEvent += SelectionBox_OnSelected;

            vizcore3dx.SelectionBox.OnSelectionBoxDeselectedEvent -= SelectionBox_DeSelected;
            vizcore3dx.SelectionBox.OnSelectionBoxDeselectedEvent += SelectionBox_DeSelected;
        }

        private void SelectionBox_DeSelected(object sender, SelectionBoxEventArgs e)
        {
            // 선택 해제되면 핸들 비활성화
            vizcore3dx.SelectionBox.IsManipulatorEnabled = false;

            // 다시 선택상자를 마우스로 선택할 수 있도록 선택 모드 활성화
            vizcore3dx.SelectionBox.EnabledMouseSelection(true);
        }

        private void SelectionBox_OnSelected(object sender, SelectionBoxEventArgs e)
        {
            // 선택상자가 선택되면 선택 모드 비활성화
            vizcore3dx.SelectionBox.EnabledMouseSelection(false);

            // 선택 후 ESC를 입력해야 핸들이 활성화됨
            SendKeys.Send("{ESC}");

            // 핸들 활성화
            vizcore3dx.SelectionBox.IsManipulatorEnabled = true;
        }

        private void btnAddBox_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            Data.BoundBox3D box = vizcore3dx.Model.BoundBox;

            vizcore3dx.SelectionBox.Clear();

            // 핸들은 선택 전에 미리 활성화
            vizcore3dx.SelectionBox.IsManipulatorEnabled = true;

            SelectionBox = vizcore3dx.SelectionBox.Add(
                box,
                vizcore3dx.SelectionBox.GetTransparencyColor(Color.White, 80),
                vizcore3dx.SelectionBox.DefaultSelectionBoxStrokeColor,
                string.Empty
            );

            // 생성한 선택상자를 선택 상태로 설정해야 핸들이 표시됨
            vizcore3dx.SelectionBox.Select(true);
        }

        private void btnGetZoneObjects_Click(object sender, EventArgs e)
        {
            if (SelectionBox == -1 || cbFilter.SelectedIndex == -1) return;

            Data.BoundBox3D box = vizcore3dx.SelectionBox.GetItem(SelectionBox).BoundBox;
            Data.BoundBoxSearchOption option = (Data.BoundBoxSearchOption)cbFilter.SelectedIndex;
            List<Data.Node> items = vizcore3dx.Object3D.FromZone(box, option);

            dataGridNode.DataSource = items;
            gbObjects.Text = string.Format("Objects - {0:N0}", items.Count);
        }
    }
}