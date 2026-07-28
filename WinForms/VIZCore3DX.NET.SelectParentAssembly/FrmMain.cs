using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;
using VIZCore3DX.NET.Manager;

namespace VIZCore3DX.NET.SelectParentAssembly
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DXControl vizcore3dx;
        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            //License
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

            // 모델 로드
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
            vizcore3dx.ToolbarDecal.Visible = false;
            vizcore3dx.ToolbarPrimitive.Visible = false;


            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }
        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.Object3D.OnNodeEvent += Object3D_OnNodeEvent;
        }

        private void Object3D_OnNodeEvent(object sender, EventManager.NodeEventArgs e)
        {
            List<Node> selected = null;

            if (e.EventKind == Object3DManager.NodeEventKind.SELECTION_CHANGED_NODE)
            {
                if (ckSelected_Object.Checked)
                    selected = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_ALL);

                else if (ckPart_Node.Checked)
                    selected = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP);

                else if (ckAssembly.Checked)
                {
                    selected = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_ALL);

                    while (selected[0].Kind != Data.NodeKind.ASSEMBLY)
                    {
                        Node selectedNode = selected[0];
                        Node parentNode = vizcore3dx.Object3D.GetParentNode(selectedNode);
                        selected = new List<Node> { parentNode };
                    }
                }
                else if (ckWhole_Model.Checked)
                {
                    selected = vizcore3dx.Object3D.GetRootNodes();

                }

                vizcore3dx.Object3D.Select(selected, true, true);
                if (ckShow_Selection_Only.Checked) vizcore3dx.Object3D.ShowSelection(selected);

                if (groupBox1.Controls.OfType<RadioButton>().Any(r => r.Checked))
                {
                    vizcore3dx.ModelTree.AttachModelTreeControl(splitContainer2.Panel2, DockStyle.Fill);
                    vizcore3dx.ModelTree.Focus(selected[0]);
                }
                else return;
            }

            if (e.EventKind == Object3DManager.NodeEventKind.SELECTION_UNSELECTED_NODE)
            {
                vizcore3dx.Object3D.Show(vizcore3dx.Object3D.GetRootNodes(), true);
            }
        }

        private void ckEnable_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.View.EnableSelection = ckEnable.Checked;

            if (!ckEnable.Checked)
            {
                ckSelected_Object.Checked = ckEnable.Checked;
                ckPart_Node.Checked = ckEnable.Checked;
                ckAssembly.Checked = ckEnable.Checked;
                ckWhole_Model.Checked = ckEnable.Checked;
            }

            ckSelected_Object.Enabled = ckEnable.Checked;
            ckPart_Node.Enabled = ckEnable.Checked;
            ckAssembly.Enabled = ckEnable.Checked;
            ckWhole_Model.Enabled = ckEnable.Checked;

        }
    }
}
