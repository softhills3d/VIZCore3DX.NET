using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.MultiPrimitive
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
            //VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("127.0.0.1", 8901);
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("192.168.100.252", 8901);

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

            MessageBox.Show("Multi Primitive를 생성할 부모 노드가 없습니다.", "VIZCore3DX.NET.MultiPrimitive", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }

        // Multi Primitive 형식에 맞춰 필요한 입력 항목만 표시합니다.
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
            lblGuide.Text = string.Format("API : AddMultiPrimitive{0}", cmbPrimitiveType.Text);
            txtNodeName.Text = string.Format("Multi Primitive {0}", cmbPrimitiveType.Text);

            switch (cmbPrimitiveType.SelectedIndex)
            {
                case 0:
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

                case 1:
                case 2:
                    lblValue1.Text = "Radius";
                    lblValue2.Text = "Height";
                    numValue1.Value = 500;
                    numValue2.Value = 1000;
                    lblValue1.Visible = numValue1.Visible = true;
                    lblValue2.Visible = numValue2.Visible = true;
                    break;

                case 3:
                    cmbAxisAnchor.Enabled = false;
                    btnColor.Enabled = false;
                    lblGuide.Text = "API : AddMultiPrimitiveMesh / 샘플 Mesh 데이터";
                    break;

                case 4:
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

                case 5:
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

                case 6:
                    lblValue1.Text = "Radius";
                    numValue1.Value = 700;
                    lblValue1.Visible = numValue1.Visible = true;
                    break;

                case 7:
                    lblValue1.Text = "Radius";
                    lblValue2.Text = "Height";
                    numValue1.Value = 1000;
                    numValue2.Value = 500;
                    lblValue1.Visible = numValue1.Visible = true;
                    lblValue2.Visible = numValue2.Visible = true;
                    break;

                case 8:
                    lblValue1.Text = "Torus Radius";
                    lblValue2.Text = "Tube Radius";
                    numValue1.Value = 1000;
                    numValue2.Value = 300;
                    lblValue1.Visible = numValue1.Visible = true;
                    lblValue2.Visible = numValue2.Visible = true;
                    break;
            }
        }


        private async void btnOsnap_Click(object sender, EventArgs e)
        {
            // Osnap으로 Multi Primitive 기준 위치를 선택합니다.
            OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();
            osnap.CommandText = "Multi Primitive 기준 위치를 선택하세요.";

            OsnapResult position = await osnap.GetResultAsync();
            if (position == null) return;

            numMoveX.Value = Math.Max(numMoveX.Minimum, Math.Min(numMoveX.Maximum, (decimal)position.Position.X));
            numMoveY.Value = Math.Max(numMoveY.Minimum, Math.Min(numMoveY.Maximum, (decimal)position.Position.Y));
            numMoveZ.Value = Math.Max(numMoveZ.Minimum, Math.Min(numMoveZ.Maximum, (decimal)position.Position.Z));
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            // Multi Primitive 색상을 선택합니다.
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = btnColor.BackColor;
                if (dialog.ShowDialog() != DialogResult.OK) return;
                btnColor.BackColor = dialog.Color;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // 선택된 AddMultiPrimitive API를 실행합니다.
            Node parent = GetParentNode();
            if (parent == null) return;

            string nodeName = txtNodeName.Text.Trim();
            if (nodeName.Length == 0) return;

            int count = (int)numCount.Value;
            AxisAnchor axisAnchor = (AxisAnchor)cmbAxisAnchor.SelectedItem;
            Color color = btnColor.BackColor;
            Vector3D move = new Vector3D((float)numMoveX.Value, (float)numMoveY.Value, (float)numMoveZ.Value);
            float intervalX = (float)numIntervalX.Value;
            float intervalY = (float)numIntervalY.Value;
            float intervalZ = (float)numIntervalZ.Value;
            bool createAssembly = chkCreateAssembly.Checked;
            List<Node> nodes = null;

            try
            {
                switch (cmbPrimitiveType.SelectedIndex)
                {
                    case 0:
                        List<PrimitiveBox> boxes = new List<PrimitiveBox>();
                        for (int i = 0; i < count; i++) boxes.Add(new PrimitiveBox(string.Format("Box {0}", i + 1), axisAnchor, color, new Vector3D((float)numValue1.Value, (float)numValue2.Value, (float)numValue3.Value), new Vector3D(move.X + (intervalX * i), move.Y + (intervalY * i), move.Z + (intervalZ * i))));
                        nodes = vizcore3dx.Object3D.Primitive.AddMultiPrimitiveBox(parent, nodeName, boxes, createAssembly);
                        break;

                    case 1:
                        List<PrimitiveCone> cones = new List<PrimitiveCone>();
                        for (int i = 0; i < count; i++) cones.Add(new PrimitiveCone(string.Format("Cone {0}", i + 1), axisAnchor, color, (float)numValue1.Value, (float)numValue2.Value, new Vector3D(move.X + (intervalX * i), move.Y + (intervalY * i), move.Z + (intervalZ * i))));
                        nodes = vizcore3dx.Object3D.Primitive.AddMultiPrimitiveCone(parent, nodeName, cones, createAssembly);
                        break;

                    case 2:
                        List<PrimitiveCylinder> cylinders = new List<PrimitiveCylinder>();
                        for (int i = 0; i < count; i++) cylinders.Add(new PrimitiveCylinder(string.Format("Cylinder {0}", i + 1), axisAnchor, color, (float)numValue1.Value, (float)numValue2.Value, new Vector3D(move.X + (intervalX * i), move.Y + (intervalY * i), move.Z + (intervalZ * i))));
                        nodes = vizcore3dx.Object3D.Primitive.AddMultiPrimitiveCylinder(parent, nodeName, cylinders, createAssembly);
                        break;

                    case 3:
                        List<ColorMeshVertex> vertices = new List<ColorMeshVertex> { new ColorMeshVertex(new Vector3D(0, 0, 0), Axis.Z, Color.Red), new ColorMeshVertex(new Vector3D(1000, 0, 0), Axis.Z, Color.Green), new ColorMeshVertex(new Vector3D(1000, 1000, 0), Axis.Z, Color.Blue), new ColorMeshVertex(new Vector3D(0, 1000, 0), Axis.Z, Color.Yellow) };
                        List<ushort> indices = new List<ushort> { 0, 1, 2, 0, 2, 3 };
                        List<PrimitiveMesh> meshes = new List<PrimitiveMesh>();
                        for (int i = 0; i < count; i++) meshes.Add(new PrimitiveMesh(string.Format("Mesh {0}", i + 1), vertices, indices, new Vector3D(move.X + (intervalX * i), move.Y + (intervalY * i), move.Z + (intervalZ * i))));
                        nodes = vizcore3dx.Object3D.Primitive.AddMultiPrimitiveMesh(parent, nodeName, meshes, createAssembly);
                        break;

                    case 4:
                        List<PrimitivePyramid> pyramids = new List<PrimitivePyramid>();
                        for (int i = 0; i < count; i++) pyramids.Add(new PrimitivePyramid(string.Format("Pyramid {0}", i + 1), axisAnchor, color, new Vector2((float)numValue1.Value, (float)numValue2.Value), (float)numValue3.Value, new Vector3D(move.X + (intervalX * i), move.Y + (intervalY * i), move.Z + (intervalZ * i))));
                        nodes = vizcore3dx.Object3D.Primitive.AddMultiPrimitivePyramid(parent, nodeName, pyramids, createAssembly);
                        break;

                    case 5:
                        List<PrimitiveRectangularTorus> rectangularToruses = new List<PrimitiveRectangularTorus>();
                        for (int i = 0; i < count; i++) rectangularToruses.Add(new PrimitiveRectangularTorus(string.Format("RectangularTorus {0}", i + 1), axisAnchor, color, (float)numValue1.Value, new Vector2((float)numValue2.Value, (float)numValue3.Value), new Vector3D(move.X + (intervalX * i), move.Y + (intervalY * i), move.Z + (intervalZ * i))));
                        nodes = vizcore3dx.Object3D.Primitive.AddMultiPrimitiveRectangularTorus(parent, nodeName, rectangularToruses, createAssembly);
                        break;

                    case 6:
                        List<PrimitiveSphere> spheres = new List<PrimitiveSphere>();
                        for (int i = 0; i < count; i++) spheres.Add(new PrimitiveSphere(string.Format("Sphere {0}", i + 1), axisAnchor, color, (float)numValue1.Value, new Vector3D(move.X + (intervalX * i), move.Y + (intervalY * i), move.Z + (intervalZ * i))));
                        nodes = vizcore3dx.Object3D.Primitive.AddMultiPrimitiveSphere(parent, nodeName, spheres, createAssembly);
                        break;

                    case 7:
                        List<PrimitiveSphericalCap> sphericalCaps = new List<PrimitiveSphericalCap>();
                        for (int i = 0; i < count; i++) sphericalCaps.Add(new PrimitiveSphericalCap(string.Format("SphericalCap {0}", i + 1), axisAnchor, color, (float)numValue1.Value, (float)numValue2.Value, new Vector3D(move.X + (intervalX * i), move.Y + (intervalY * i), move.Z + (intervalZ * i))));
                        nodes = vizcore3dx.Object3D.Primitive.AddMultiPrimitiveSphericalCap(parent, nodeName, sphericalCaps, createAssembly);
                        break;

                    case 8:
                        List<PrimitiveTorus> toruses = new List<PrimitiveTorus>();
                        for (int i = 0; i < count; i++) toruses.Add(new PrimitiveTorus(string.Format("Torus {0}", i + 1), axisAnchor, color, (float)numValue1.Value, (float)numValue2.Value, new Vector3D(move.X + (intervalX * i), move.Y + (intervalY * i), move.Z + (intervalZ * i))));
                        nodes = vizcore3dx.Object3D.Primitive.AddMultiPrimitiveTorus(parent, nodeName, toruses, createAssembly);
                        break;
                }

                int createdCount = nodes == null ? 0 : nodes.Count;
                lblResult.Text = string.Format("생성 결과 : {0}개 Node", createdCount);
                vizcore3dx.StatusbarInfo.Text = string.Format("'{0}' : {1}개 Node", nodeName, createdCount);
            }
            catch (Exception ex)
            {
                lblResult.Text = "생성 결과 : 실패";
                MessageBox.Show(ex.Message, "VIZCore3DX.NET.MultiPrimitive", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
