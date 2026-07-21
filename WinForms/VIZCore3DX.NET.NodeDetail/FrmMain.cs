using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.NodeDetail
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;
        private Node node;

        private readonly Dictionary<int, Vector3D> _nodeMoveMap = new Dictionary<int, Vector3D>();
        private readonly Dictionary<int, List<RotateHistory>> _nodeRotateHistoryMap = new Dictionary<int, List<RotateHistory>>();
        private readonly Dictionary<int, Vector3D> _nodeRotateValueMap = new Dictionary<int, Vector3D>();

        private Vector3D _rotateStartValue = new Vector3D(0, 0, 0);

        private class RotateHistory
        {
            public float X { get; private set; }
            public float Y { get; private set; }
            public float Z { get; private set; }

            public RotateHistory(float x, float y, float z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

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
            LicenseResults result = vizcore3dx.License.LicenseServer("192.168.100.252", 8901);

            // ================================================================
            // License
            // ================================================================
            //LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");
            if (result != LicenseResults.SUCCESS)
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

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }

        private void InitializeVIZCore3DXEvent()
        {
            // 마우스로 개체 클릭했을 때
            vizcore3dx.Object3D.OnNodeClick -= Object3D_OnNodeClick;
            vizcore3dx.Object3D.OnNodeClick += Object3D_OnNodeClick;

            tbRotateX.MouseDown -= TrackBarRotate_MouseDown;
            tbRotateY.MouseDown -= TrackBarRotate_MouseDown;
            tbRotateZ.MouseDown -= TrackBarRotate_MouseDown;

            tbRotateX.MouseDown += TrackBarRotate_MouseDown;
            tbRotateY.MouseDown += TrackBarRotate_MouseDown;
            tbRotateZ.MouseDown += TrackBarRotate_MouseDown;

            tbRotateX.MouseUp -= TrackBarRotate_MouseUp;
            tbRotateY.MouseUp -= TrackBarRotate_MouseUp;
            tbRotateZ.MouseUp -= TrackBarRotate_MouseUp;

            tbRotateX.MouseUp += TrackBarRotate_MouseUp;
            tbRotateY.MouseUp += TrackBarRotate_MouseUp;
            tbRotateZ.MouseUp += TrackBarRotate_MouseUp;
        }

        private void Object3D_OnNodeClick(object sender, EventManager.NodeMouseEventArgs e)
        {
            // 클릭된 노드가 없는 경우 예외 처리
            if (e == null || e.Node == null)
            {
                txtNodeIndex.Text = string.Empty;
                node = null;
                pgNode.SelectedObject = null;
                ResetInputValues();
                return;
            }

            // 전역 변수 데이터 바인딩
            txtNodeIndex.Text = e.Node.Index.ToString();
            node = e.Node;
            pgNode.SelectedObject = node;

            // 선택 효과 적용
            vizcore3dx.View.SelectionColorEnabled = false;
            vizcore3dx.View.SelectionOutlineEnabled = true;
            vizcore3dx.Object3D.Select(new List<Node>() { node }, true, true);

            vizcore3dx.Model.EnableUndoRedo = true;
            ResetInputValues();
        }

        // ================================================
        // Color
        // ================================================
        private void btnGetColor_Click(object sender, EventArgs e)
        {
            if (node == null) return;

            Color color = node.GetColor();

            txtColorR.Text = color.R.ToString();
            txtColorG.Text = color.G.ToString();
            txtColorB.Text = color.B.ToString();
        }

        private void btnSetColor_Click(object sender, EventArgs e)
        {
            if (node == null) return;

            int colorR;
            int colorG;
            int colorB;

            if (int.TryParse(txtColorR.Text, out colorR) == false || int.TryParse(txtColorG.Text, out colorG) == false || int.TryParse(txtColorB.Text, out colorB) == false)
            {
                MessageBox.Show("RGB 값을 숫자로 입력해 주세요.");
                return;
            }

            if (colorR < 0 || colorR > 255 || colorG < 0 || colorG > 255 || colorB < 0 || colorB > 255)
            {
                MessageBox.Show("RGB 값은 0부터 255 사이로 입력해 주세요.");
                return;
            }

            node.SetColor(Color.FromArgb(colorR, colorG, colorB));
        }

        private void btnColorReset_Click(object sender, EventArgs e)
        {
            if (node == null) return;

            node.ResetColor();

            txtColorR.Text = string.Empty;
            txtColorG.Text = string.Empty;
            txtColorB.Text = string.Empty;
        }

        private void tbTransparency_Scroll(object sender, EventArgs e)
        {
            if (node == null) return;

            node.SetTransparency(tbTransparency.Value);
        }

        private void btnResetTransparency_Click(object sender, EventArgs e)
        {
            if (node == null) return;

            // Transparency 초기화
            node.ResetTransparency();

            tbTransparency.Scroll -= tbTransparency_Scroll;
            tbTransparency.Value = 0;
            tbTransparency.Scroll += tbTransparency_Scroll;
        }

        // ================================================
        // Transform - Move
        // ================================================
        private void btnMove_Click(object sender, EventArgs e)
        {
            if (node == null) return;

            float x;
            float y;
            float z;

            if (float.TryParse(txtMoveX.Text, out x) == false || float.TryParse(txtMoveY.Text, out y) == false || float.TryParse(txtMoveZ.Text, out z) == false)
            {
                MessageBox.Show("이동 값을 숫자로 입력해 주세요.");
                return;
            }

            node.Move(x, y, z, false);

            Vector3D current;
            if (_nodeMoveMap.TryGetValue(node.Index, out current) == false) current = new Vector3D(0, 0, 0);

            _nodeMoveMap[node.Index] = new Vector3D(current.X + x, current.Y + y, current.Z + z);

            txtMoveX.Text = _nodeMoveMap[node.Index].X.ToString();
            txtMoveY.Text = _nodeMoveMap[node.Index].Y.ToString();
            txtMoveZ.Text = _nodeMoveMap[node.Index].Z.ToString();
        }

        private void btnResetMove_Click(object sender, EventArgs e)
        {
            if (node == null) return;

            Vector3D move;
            if (_nodeMoveMap.TryGetValue(node.Index, out move) == false) return;

            node.Move(-move.X, -move.Y, -move.Z, false);
            _nodeMoveMap[node.Index] = new Vector3D(0, 0, 0);

            txtMoveX.Text = "0";
            txtMoveY.Text = "0";
            txtMoveZ.Text = "0";
        }

        // ================================================
        // Transform - Rotate
        // ================================================
        private void btnResetRotate_Click(object sender, EventArgs e)
        {
            if (node == null) return;

            // 적용된 회전을 역순으로 되돌림
            List<RotateHistory> histories;
            if (_nodeRotateHistoryMap.TryGetValue(node.Index, out histories) == true)
            {
                for (int i = histories.Count - 1; i >= 0; i--)
                {
                    RotateHistory history = histories[i];
                    node.Rotate(-history.X, -history.Y, -history.Z, false);
                }

                histories.Clear();
            }

            _nodeRotateValueMap[node.Index] = new Vector3D(0, 0, 0);

            tbRotateX.Scroll -= tbRotateX_Scroll;
            tbRotateY.Scroll -= tbRotateY_Scroll;
            tbRotateZ.Scroll -= tbRotateZ_Scroll;

            tbRotateX.Value = 0;
            tbRotateY.Value = 0;
            tbRotateZ.Value = 0;

            tbRotateX.Scroll += tbRotateX_Scroll;
            tbRotateY.Scroll += tbRotateY_Scroll;
            tbRotateZ.Scroll += tbRotateZ_Scroll;
        }

        private void tbRotateX_Scroll(object sender, EventArgs e)
        {
            RotateNode();
        }

        private void tbRotateY_Scroll(object sender, EventArgs e)
        {
            RotateNode();
        }

        private void tbRotateZ_Scroll(object sender, EventArgs e)
        {
            RotateNode();
        }

        private void TrackBarRotate_MouseDown(object sender, MouseEventArgs e)
        {
            if (node == null) return;

            _rotateStartValue = new Vector3D(tbRotateX.Value, tbRotateY.Value, tbRotateZ.Value);

            // 드래그 중 발생하는 Rotate는 SDK Undo에 기록하지 않음
            vizcore3dx.Model.EnableUndoRedo = false;
        }

        private void TrackBarRotate_MouseUp(object sender, MouseEventArgs e)
        {
            if (node == null) return;

            float dx = tbRotateX.Value - _rotateStartValue.X;
            float dy = tbRotateY.Value - _rotateStartValue.Y;
            float dz = tbRotateZ.Value - _rotateStartValue.Z;

            // 드래그 중 미리보기로 적용된 회전을 되돌림
            if (dx != 0 || dy != 0 || dz != 0) node.Rotate(-dx, -dy, -dz, false);

            // 최종 회전값부터 SDK Undo 기록 활성화
            vizcore3dx.Model.EnableUndoRedo = true;

            if (dx == 0 && dy == 0 && dz == 0) return;

            // 최종 회전값만 한 번 적용
            node.Rotate(dx, dy, dz, false);

            List<RotateHistory> histories;
            if (_nodeRotateHistoryMap.TryGetValue(node.Index, out histories) == false)
            {
                histories = new List<RotateHistory>();
                _nodeRotateHistoryMap[node.Index] = histories;
            }

            // 사용자 정의 회전 초기화를 위해 최종값만 저장
            histories.Add(new RotateHistory(dx, dy, dz));

            ResetInputValues();
        }

        // 슬라이더 변화량만큼 노드를 실시간 회전
        private void RotateNode()
        {
            if (node == null) return;

            int currentX = tbRotateX.Value;
            int currentY = tbRotateY.Value;
            int currentZ = tbRotateZ.Value;

            Vector3D previous;
            if (_nodeRotateValueMap.TryGetValue(node.Index, out previous) == false) previous = new Vector3D(0, 0, 0);

            float deltaX = currentX - previous.X;
            float deltaY = currentY - previous.Y;
            float deltaZ = currentZ - previous.Z;

            // 슬라이더 이동 중에는 실시간 회전만 적용
            if (deltaX != 0) node.Rotate(deltaX, 0, 0, false);
            if (deltaY != 0) node.Rotate(0, deltaY, 0, false);
            if (deltaZ != 0) node.Rotate(0, 0, deltaZ, false);

            _nodeRotateValueMap[node.Index] = new Vector3D(currentX, currentY, currentZ);
        }

        private void ResetInputValues()
        {
            // Color 입력값 초기화
            txtColorR.Text = string.Empty;
            txtColorG.Text = string.Empty;
            txtColorB.Text = string.Empty;

            // Move 입력값 설정
            Vector3D move;
            if (node != null && _nodeMoveMap.TryGetValue(node.Index, out move) == true)
            {
                txtMoveX.Text = move.X.ToString();
                txtMoveY.Text = move.Y.ToString();
                txtMoveZ.Text = move.Z.ToString();
            }
            else
            {
                txtMoveX.Text = "0";
                txtMoveY.Text = "0";
                txtMoveZ.Text = "0";
            }

            // TrackBar 설정 중 RotateNode 호출 방지
            tbRotateX.Scroll -= tbRotateX_Scroll;
            tbRotateY.Scroll -= tbRotateY_Scroll;
            tbRotateZ.Scroll -= tbRotateZ_Scroll;

            Vector3D rotate;
            if (node != null && _nodeRotateValueMap.TryGetValue(node.Index, out rotate) == true)
            {
                tbRotateX.Value = ClampTrackBarValue(tbRotateX, (int)rotate.X);
                tbRotateY.Value = ClampTrackBarValue(tbRotateY, (int)rotate.Y);
                tbRotateZ.Value = ClampTrackBarValue(tbRotateZ, (int)rotate.Z);
            }
            else
            {
                tbRotateX.Value = 0;
                tbRotateY.Value = 0;
                tbRotateZ.Value = 0;
            }

            tbRotateX.Scroll += tbRotateX_Scroll;
            tbRotateY.Scroll += tbRotateY_Scroll;
            tbRotateZ.Scroll += tbRotateZ_Scroll;

            // Transparency 입력값 초기화
            tbTransparency.Scroll -= tbTransparency_Scroll;
            tbTransparency.Value = 0;
            tbTransparency.Scroll += tbTransparency_Scroll;
        }

        private int ClampTrackBarValue(TrackBar trackBar, int value)
        {
            if (value < trackBar.Minimum) return trackBar.Minimum;
            if (value > trackBar.Maximum) return trackBar.Maximum;
            return value;
        }

        // ================================================
        // UDA
        // ================================================
        private void btnGetUDA_Click(object sender, EventArgs e)
        {
            if (node == null) return;

            Dictionary<string, string> uda = node.GetUDA();

            lvList.BeginUpdate();

            try
            {
                lvList.Items.Clear();

                if (uda == null) return;

                foreach (KeyValuePair<string, string> item in uda)
                    lvList.Items.Add(new ListViewItem(new string[] { item.Key, item.Value }));
            }
            finally
            {
                lvList.EndUpdate();
            }
        }

        // ================================================
        // Geometry Property
        // ================================================
        private void btnGeometryProperty_Click(object sender, EventArgs e)
        {
            if (node == null) return;

            Object3DProperty property = node.GetGeometryProperty();
            propertyGrid.SelectedObject = property;
        }
    }
}