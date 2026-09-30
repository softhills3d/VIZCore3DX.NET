using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.Primitive
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
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Toolbar
            vizcore3dx.BeginUpdate();
            vizcore3dx.ToolbarMain.Visible = true;
            vizcore3dx.ToolbarNote.Visible = false;
            vizcore3dx.ToolbarMeasure.Visible = false;
            vizcore3dx.ToolbarSection.Visible = false;
            vizcore3dx.ToolbarSnapshot.Visible = false;
            vizcore3dx.EndUpdate();
        }

        // 선택된 TOP Node를 우선 사용하고 대상이 없으면 ROOT Node를 사용합니다.
        private Node GetParentNode()
        {
            List<Node> nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP);
            if (nodes.Count > 0) return nodes[0];

            nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.ROOT);
            if (nodes.Count > 0) return nodes[0];

            MessageBox.Show("Primitive를 생성할 부모 노드가 없습니다.\n빈 씬에서는 'Node / Dialog / File' 탭의 AddRootNode로 루트 노드를 먼저 생성하세요.", "VIZCore3DX.NET.Primitive", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }

        // 실패 메시지와 함께 Primitive Manager의 마지막 작업 결과를 표시합니다.
        private void ShowOperationFailure(string message)
        {
            OperationStatus status = vizcore3dx.Object3D.Primitive.LastOperationStatus;
            string detail = status == null || status.IsSuccess ? string.Empty : string.Format("\n원인 : {0}", status.Result);

            MessageBox.Show(message + detail, "VIZCore3DX.NET.Primitive", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Primitive 형식에 맞춰 필요한 입력 항목만 표시합니다.
        private void cmbPrimitiveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblValue1.Visible = false;
            numValue1.Visible = false;
            lblValue2.Visible = false;
            numValue2.Visible = false;
            lblValue3.Visible = false;
            numValue3.Visible = false;
            cmbAxisAnchor.Enabled = true;
            btnColor.Enabled = true;
            lblGuide.Text = string.Empty;
            txtNodeName.Text = string.Format("Primitive {0}", cmbPrimitiveType.Text);

            switch (cmbPrimitiveType.Text)
            {
                case "Box":
                    lblValue1.Text = "Size X";
                    lblValue2.Text = "Size Y";
                    lblValue3.Text = "Size Z";
                    numValue1.Value = 1000;
                    numValue2.Value = 1000;
                    numValue3.Value = 1000;
                    lblValue1.Visible = numValue1.Visible = true;
                    lblValue2.Visible = numValue2.Visible = true;
                    lblValue3.Visible = numValue3.Visible = true;
                    break;

                case "Cone":
                    lblValue1.Text = "Radius";
                    lblValue2.Text = "Height";
                    lblValue3.Text = "Segment Count";
                    numValue1.Value = 500;
                    numValue2.Value = 1000;
                    numValue3.Value = 32;
                    lblValue1.Visible = numValue1.Visible = true;
                    lblValue2.Visible = numValue2.Visible = true;
                    lblValue3.Visible = numValue3.Visible = true;
                    break;

                case "Cylinder":
                    lblValue1.Text = "Radius";
                    lblValue2.Text = "Height";
                    lblValue3.Text = "Segment Count";
                    numValue1.Value = 500;
                    numValue2.Value = 1000;
                    numValue3.Value = 32;
                    lblValue1.Visible = numValue1.Visible = true;
                    lblValue2.Visible = numValue2.Visible = true;
                    lblValue3.Visible = numValue3.Visible = true;
                    break;

                case "Hemisphere":
                    lblValue1.Text = "Radius";
                    lblValue2.Text = "Segment Count";
                    numValue1.Value = 700;
                    numValue2.Value = 32;
                    lblValue1.Visible = numValue1.Visible = true;
                    lblValue2.Visible = numValue2.Visible = true;
                    lblGuide.Text = "반구(Hemisphere) : 반지름으로 반구를 생성합니다.";
                    break;

                case "Mesh":
                    cmbAxisAnchor.Enabled = false;
                    btnColor.Enabled = false;
                    lblGuide.Text = "샘플 ColorMeshVertex와 삼각형 인덱스로 Mesh를 생성합니다.";
                    break;

                case "Pyramid":
                    lblValue1.Text = "Bottom Size X";
                    lblValue2.Text = "Bottom Size Y";
                    lblValue3.Text = "Height";
                    numValue1.Value = 1000;
                    numValue2.Value = 1000;
                    numValue3.Value = 1200;
                    lblValue1.Visible = numValue1.Visible = true;
                    lblValue2.Visible = numValue2.Visible = true;
                    lblValue3.Visible = numValue3.Visible = true;
                    break;

                case "RectangularTorus":
                    lblValue1.Text = "Torus Radius";
                    lblValue2.Text = "Tube Size X";
                    lblValue3.Text = "Tube Size Y";
                    numValue1.Value = 1000;
                    numValue2.Value = 400;
                    numValue3.Value = 400;
                    lblValue1.Visible = numValue1.Visible = true;
                    lblValue2.Visible = numValue2.Visible = true;
                    lblValue3.Visible = numValue3.Visible = true;
                    break;

                case "Sphere":
                    lblValue1.Text = "Radius";
                    lblValue2.Text = "Segment Count";
                    numValue1.Value = 700;
                    numValue2.Value = 32;
                    lblValue1.Visible = numValue1.Visible = true;
                    lblValue2.Visible = numValue2.Visible = true;
                    break;

                case "SphericalCap":
                    lblValue1.Text = "Radius";
                    lblValue2.Text = "Height";
                    lblValue3.Text = "Segment Count";
                    numValue1.Value = 1000;
                    numValue2.Value = 500;
                    numValue3.Value = 32;
                    lblValue1.Visible = numValue1.Visible = true;
                    lblValue2.Visible = numValue2.Visible = true;
                    lblValue3.Visible = numValue3.Visible = true;
                    lblGuide.Text = "구면 캡(SphericalCap) : 구의 반지름과 캡 높이로 생성합니다.";
                    break;

                case "Spheroid":
                    lblValue1.Text = "Horizontal Radius";
                    lblValue2.Text = "Vertical Radius";
                    lblValue3.Text = "Segment Count";
                    numValue1.Value = 1000;
                    numValue2.Value = 500;
                    numValue3.Value = 24;
                    lblValue1.Visible = numValue1.Visible = true;
                    lblValue2.Visible = numValue2.Visible = true;
                    lblValue3.Visible = numValue3.Visible = true;
                    lblGuide.Text = "타원체(Spheroid) : 수평 반지름과 수직 반지름으로 생성합니다.";
                    break;

                case "Torus":
                    lblValue1.Text = "Torus Radius";
                    lblValue2.Text = "Tube Radius";
                    lblValue3.Text = "Segment Count";
                    numValue1.Value = 1000;
                    numValue2.Value = 300;
                    numValue3.Value = 32;
                    lblValue1.Visible = numValue1.Visible = true;
                    lblValue2.Visible = numValue2.Visible = true;
                    lblValue3.Visible = numValue3.Visible = true;
                    break;
            }
        }


        private async void btnOsnap_Click(object sender, EventArgs e)
        {
            // Osnap으로 Primitive 위치를 선택합니다.
            OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();
            osnap.CommandText = "Primitive 위치를 선택하세요.";

            OsnapResult position = await osnap.GetResultAsync();
            if (position == null) return;

            numMoveX.Value = Math.Max(numMoveX.Minimum, Math.Min(numMoveX.Maximum, (decimal)position.Position.X));
            numMoveY.Value = Math.Max(numMoveY.Minimum, Math.Min(numMoveY.Maximum, (decimal)position.Position.Y));
            numMoveZ.Value = Math.Max(numMoveZ.Minimum, Math.Min(numMoveZ.Maximum, (decimal)position.Position.Z));
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            // Primitive 색상을 선택합니다.
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = btnColor.BackColor;
                if (dialog.ShowDialog() != DialogResult.OK) return;
                btnColor.BackColor = dialog.Color;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // 선택된 Primitive API를 실행합니다.
            Node parent = GetParentNode();
            if (parent == null) return;

            string nodeName = txtNodeName.Text.Trim();
            if (nodeName.Length == 0) return;

            AxisAnchor axisAnchor = (AxisAnchor)cmbAxisAnchor.SelectedItem;
            Color color = btnColor.BackColor;
            Vector3D move = new Vector3D((float)numMoveX.Value, (float)numMoveY.Value, (float)numMoveZ.Value);
            bool createAssembly = chkCreateAssembly.Checked;
            Node node = null;

            try
            {
                switch (cmbPrimitiveType.Text)
                {
                    case "Box":
                        node = vizcore3dx.Object3D.Primitive.AddPrimitiveBox(parent, nodeName, createAssembly, axisAnchor, color, new Vector3D((float)numValue1.Value, (float)numValue2.Value, (float)numValue3.Value), move);
                        break;

                    case "Cone":
                        node = vizcore3dx.Object3D.Primitive.AddPrimitiveCone(parent, nodeName, createAssembly, axisAnchor, color, (float)numValue1.Value, (float)numValue2.Value, move, (ushort)numValue3.Value);
                        break;

                    case "Cylinder":
                        node = vizcore3dx.Object3D.Primitive.AddPrimitiveCylinder(parent, nodeName, createAssembly, axisAnchor, color, (float)numValue1.Value, (float)numValue2.Value, move, (ushort)numValue3.Value);
                        break;

                    case "Hemisphere":
                        node = vizcore3dx.Object3D.Primitive.AddPrimitiveHemisphere(parent, nodeName, createAssembly, axisAnchor, color, (float)numValue1.Value, move, (ushort)numValue2.Value);
                        break;

                    case "Mesh":
                        List<ColorMeshVertex> vertices = new List<ColorMeshVertex> { new ColorMeshVertex(new Vector3D(0, 0, 0), Axis.Z, Color.Red), new ColorMeshVertex(new Vector3D(1000, 0, 0), Axis.Z, Color.Green), new ColorMeshVertex(new Vector3D(1000, 1000, 0), Axis.Z, Color.Blue), new ColorMeshVertex(new Vector3D(0, 1000, 0), Axis.Z, Color.Yellow), new ColorMeshVertex(new Vector3D(500, 1500, 0), Axis.Z, Color.Magenta) };
                        List<ushort> indices = new List<ushort> { 0, 1, 2, 0, 2, 3, 3, 2, 4 };
                        node = vizcore3dx.Object3D.Primitive.AddPrimitiveMesh(parent, nodeName, createAssembly, vertices, indices, move);
                        break;

                    case "Pyramid":
                        node = vizcore3dx.Object3D.Primitive.AddPrimitivePyramid(parent, nodeName, createAssembly, axisAnchor, color, new Vector2((float)numValue1.Value, (float)numValue2.Value), (float)numValue3.Value, move);
                        break;

                    case "RectangularTorus":
                        node = vizcore3dx.Object3D.Primitive.AddPrimitiveRectangularTorus(parent, nodeName, createAssembly, axisAnchor, color, (float)numValue1.Value, new Vector2((float)numValue2.Value, (float)numValue3.Value), move, 32);
                        break;

                    case "Sphere":
                        node = vizcore3dx.Object3D.Primitive.AddPrimitiveSphere(parent, nodeName, createAssembly, axisAnchor, color, (float)numValue1.Value, move, (ushort)numValue2.Value);
                        break;

                    case "SphericalCap":
                        node = vizcore3dx.Object3D.Primitive.AddPrimitiveSphericalCap(parent, nodeName, createAssembly, axisAnchor, color, (float)numValue1.Value, (float)numValue2.Value, move, (ushort)numValue3.Value);
                        break;

                    case "Spheroid":
                        node = vizcore3dx.Object3D.Primitive.AddPrimitiveSpheroid(parent, nodeName, createAssembly, axisAnchor, color, (float)numValue1.Value, (float)numValue2.Value, move, (ushort)numValue3.Value);
                        break;

                    case "Torus":
                        node = vizcore3dx.Object3D.Primitive.AddPrimitiveTorus(parent, nodeName, createAssembly, axisAnchor, color, (float)numValue1.Value, (float)numValue2.Value, move, (ushort)numValue3.Value);
                        break;
                }

                lblResult.Text = node == null ? "생성 결과 : 실패" : string.Format("생성 결과 : {0}", node.NodeName);
                if (node != null) vizcore3dx.StatusbarInfo.Text = string.Format("'{0}' 노드 생성", node.NodeName);
                else ShowOperationFailure("Primitive를 생성하지 못했습니다.");
            }
            catch (ArgumentException ex)
            {
                // 삭제되었거나 무효화된 노드 참조를 전달하면 ArgumentException이 발생합니다.
                lblResult.Text = "생성 결과 : 실패";
                ShowOperationFailure(string.Format("잘못된 인수입니다. 삭제되었거나 무효화된 노드 참조일 수 있으니 부모 노드를 다시 선택하세요.\n{0}", ex.Message));
            }
            catch (Exception ex)
            {
                lblResult.Text = "생성 결과 : 실패";
                ShowOperationFailure(ex.Message);
            }
        }

        private void btnAddNode_Click(object sender, EventArgs e)
        {
            // 선택된 부모 Node 기준으로 일반 Node를 생성합니다.
            Node parent = GetParentNode();
            if (parent == null) return;

            string nodeName = txtAddNodeName.Text.Trim();
            if (nodeName.Length == 0) return;

            try
            {
                Node node = vizcore3dx.Object3D.Primitive.AddNode(parent, nodeName, chkNodeAssembly.Checked);
                lblNodeResult.Text = node == null ? "생성 결과 : 실패" : string.Format("생성 결과 : {0}", node.NodeName);
                if (node == null) ShowOperationFailure("노드를 생성하지 못했습니다.");
            }
            catch (Exception ex)
            {
                lblNodeResult.Text = "생성 결과 : 실패";
                ShowOperationFailure(ex.Message);
            }
        }

        private void btnAddRootNode_Click(object sender, EventArgs e)
        {
            // 모델이 없는 빈 씬에 루트 Assembly 노드를 생성합니다.
            string nodeName = txtRootNodeName.Text.Trim();
            if (nodeName.Length == 0) return;

            try
            {
                Node node = vizcore3dx.Object3D.Primitive.AddRootNode(nodeName);
                lblRootNodeResult.Text = node == null ? "생성 결과 : 실패" : string.Format("생성 결과 : {0}", node.NodeName);
                if (node == null) ShowOperationFailure("루트 노드를 생성하지 못했습니다.");
            }
            catch (Exception ex)
            {
                lblRootNodeResult.Text = "생성 결과 : 실패";
                ShowOperationFailure(ex.Message);
            }
        }

        private void btnBrowseMeshFile_Click(object sender, EventArgs e)
        {
            // 가져올 메시 파일을 선택합니다.
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Mesh Files (*.stl;*.obj;*.ply)|*.stl;*.obj;*.ply|STL (*.stl)|*.stl|OBJ (*.obj)|*.obj|PLY (*.ply)|*.ply";
                if (dialog.ShowDialog() != DialogResult.OK) return;

                txtMeshFile.Text = dialog.FileName;
                txtMeshNodeName.Text = System.IO.Path.GetFileNameWithoutExtension(dialog.FileName);
            }
        }

        private void btnMeshColor_Click(object sender, EventArgs e)
        {
            // 정점 색상이 없는 파일에 적용할 기본 색상을 선택합니다.
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = btnMeshColor.BackColor;
                if (dialog.ShowDialog() != DialogResult.OK) return;
                btnMeshColor.BackColor = dialog.Color;
            }
        }

        private void btnAddMeshFile_Click(object sender, EventArgs e)
        {
            // STL / OBJ / PLY 파일을 읽어 선택된 부모 Node 아래에 추가합니다.
            string filePath = txtMeshFile.Text.Trim();
            if (filePath.Length == 0 || !System.IO.File.Exists(filePath))
            {
                MessageBox.Show("가져올 메시 파일을 선택하세요.", "VIZCore3DX.NET.Primitive", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Node parent = GetParentNode();
            if (parent == null) return;

            string nodeName = txtMeshNodeName.Text.Trim();
            if (nodeName.Length == 0) return;

            Vector3D move = new Vector3D((float)numMoveX.Value, (float)numMoveY.Value, (float)numMoveZ.Value);

            try
            {
                Node node = vizcore3dx.Object3D.Primitive.AddPrimitiveMeshFromFile(parent, nodeName, filePath, btnMeshColor.BackColor, move);
                lblMeshFileResult.Text = node == null ? "생성 결과 : 실패" : string.Format("생성 결과 : {0}", node.NodeName);
                if (node != null) vizcore3dx.StatusbarInfo.Text = string.Format("'{0}' 메시 파일 추가", node.NodeName);
                else ShowOperationFailure("메시 파일을 추가하지 못했습니다.");
            }
            catch (Exception ex)
            {
                lblMeshFileResult.Text = "생성 결과 : 실패";
                ShowOperationFailure(ex.Message);
            }
        }

        private void btnShowDialog_Click(object sender, EventArgs e)
        {
            // 선택한 Primitive 형식의 기본 Dialog를 실행합니다.
            // SPHEROID는 타원체, HEMISPHERE는 반구 Dialog를 표시합니다.
            if (cmbDialogPrimitive.SelectedItem == null) return;
            vizcore3dx.Object3D.Primitive.ShowAddPrimitiveDialog((Primitives)cmbDialogPrimitive.SelectedItem);
        }
    }
}
