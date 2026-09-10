using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.GeometryProperty
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
            splitContainer1.Panel1.Controls.Add(vizcore3dx);

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
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // 마우스로 개체 선택 상태가 변경됐을 때
            vizcore3dx.Object3D.OnNodeEvent += Object3D_OnNodeEvent;
        }

        #region Geometry Property

        private void Object3D_OnNodeEvent(object sender, EventManager.NodeEventArgs e)
        {
            if (e == null || e.EventKind != VIZCore3DX.NET.Manager.Object3DManager.NodeEventKind.SELECTION_CHANGED_NODE) return;

            UpdateGeometryProperty();
        }

        private void GeometryReturnType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton == null || radioButton.Checked == false) return;

            UpdateGeometryProperty();
        }

        private void UpdateGeometryProperty()
        {
            List<VIZCore3DX.NET.Data.Node> selectedNodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);

            if (selectedNodes.Count == 0)
            {
                geometryPropertyGrid.SelectedObject = null;
                return;
            }

            // Geometry Property
            if (rdoFromSelectedObject3D.Checked)
            {
                geometryPropertyGrid.SelectedObject = vizcore3dx.Object3D.GeometryProperty.FromSelectedObject3D(false);
                return;
            }

            // 표면적 (m²)
            if (rdoGetSurfaceArea.Checked)
            {
                double surfaceArea = vizcore3dx.Object3D.GeometryProperty.GetSurfaceArea(selectedNodes);
                geometryPropertyGrid.SelectedObject = new { SurfaceArea = surfaceArea, Unit = "m²" };
                return;
            }

            // 부피 (m³)
            if (rdoGetVolume.Checked)
            {
                double volume = vizcore3dx.Object3D.GeometryProperty.GetVolume(selectedNodes);
                geometryPropertyGrid.SelectedObject = new { Volume = volume, Unit = "m³" };
                return;
            }

            // 부피 중심 (mm)
            if (rdoGetCenterOfVolume.Checked)
            {
                geometryPropertyGrid.SelectedObject = vizcore3dx.Object3D.GeometryProperty.GetCenterOfVolume(selectedNodes);
                return;
            }

            // 표면적 + 부피 + 부피 중심
            if (rdoGetGeometry.Checked)
            {
                geometryPropertyGrid.SelectedObject = vizcore3dx.Object3D.GeometryProperty.GetGeometry(selectedNodes);
            }
        }

        #endregion
    }
}
