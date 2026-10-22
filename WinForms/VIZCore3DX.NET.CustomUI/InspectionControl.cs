using System;
using System.Windows.Forms;

namespace VIZCore3DX.NET.CustomUI
{
    // 패널 사용자 탭에 담는 응용프로그램 화면입니다. 뷰어의 선택 노드를 읽어 목록에 보여 줍니다.
    public partial class InspectionControl : UserControl
    {
        private VIZCore3DX.NET.VIZCore3DXControl _vizcore3dx;

        // 디자이너용 생성자입니다.
        public InspectionControl()
        {
            InitializeComponent();
        }

        public InspectionControl(VIZCore3DX.NET.VIZCore3DXControl vizcore3dx) : this()
        {
            _vizcore3dx = vizcore3dx;
        }

        // 뷰에서 선택한 최상위 노드(SELECTED_TOP)의 이름을 목록에 채웁니다.
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lstNodes.Items.Clear();
            if (_vizcore3dx == null || !_vizcore3dx.Model.IsOpen())
            {
                lstNodes.Items.Add("(모델 없음)");
                return;
            }

            foreach (VIZCore3DX.NET.Data.Node node in _vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP))
                lstNodes.Items.Add(node.NodeName);
        }
    }
}
