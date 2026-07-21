using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.Projection2D
{
    public partial class ResultControl : UserControl
    {
        private ElementHost ctrlHost = null;

        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        private VIZCore3DX.NET.Controls.ProjectionViewerControl Viewer;
        public ResultControl()
        {
            InitializeComponent();
        }
        internal void SetVIZCore3DX(VIZCore3DX.NET.VIZCore3DXControl ctrl)
        {
            vizcore3dx = ctrl;
        }

        internal void SetData()
        {
            if (vizcore3dx == null || vizcore3dx.Model.IsOpen() == false) return;

            if (Viewer == null)
            {
                Viewer = new Controls.ProjectionViewerControl();
                Viewer.Dock = DockStyle.Fill;

                panelPath.Controls.Clear();
                panelPath.Controls.Add(Viewer);
            }

            vizcore3dx.Projection.Clear();

            List<Data.Node> nodes = vizcore3dx.Object3D.FromFilter(Data.Object3dFilter.ALL);
            if (nodes == null || nodes.Count == 0) return;

            Data.CameraData cameraData = vizcore3dx.View.GetCameraData();
            if (cameraData == null) return;

            // 카메라가 바라보는 방향을 Projection 평면의 법선 방향으로 사용
            Data.Vector3D eye = new Data.Vector3D(cameraData.EyePosition);
            Data.Vector3D pivot = new Data.Vector3D(cameraData.PivotPosition);
            Data.Vector3D viewDir = new Data.Vector3D(pivot.X - eye.X, pivot.Y - eye.Y, pivot.Z - eye.Z).GetNormalized();

            // 기존 EyePosition/PivotPosition 계산 대신 CameraDirection을 직접 사용하면 보는것과 약간 달라지는 부분이 잇어서, 직접 계산하는 방식을 사용했다.
            //Data.Vector3D viewDir = new Data.Vector3D(cameraData.CameraDirection).GetNormalized();

            Data.BoundBox3D boundBox = vizcore3dx.Object3D.GetBoundBox(nodes);
            if (boundBox == null) return;

            // 모델 중심점을 Projection 평면의 기준 위치로 사용
            Data.Vector3D planePosition = new Data.Vector3D(boundBox.GetCenter());

            // 현재 카메라 방향 기준으로 전체 모델 외곽선을 생성
            Data.ProjectionItem outline = vizcore3dx.Projection.CreateOutline(
                nodes, viewDir, planePosition, Color.Black, 1.0f, true, false
            );
            if (outline == null) return;

            // 생성된 Projection 결과 정보와 모델 바운드박스 정보를 설정
            SetProjectionInfo(outline, boundBox);

            // 생성된 외곽선 Projection 결과를 Viewer에 표시
            Viewer.SetResult(outline);

            // 3D 화면에는 Projection 결과를 표시하지 않음
            vizcore3dx.Projection.ShowAll(false);

        }

        private void SetProjectionInfo(Data.ProjectionItem item, Data.BoundBox3D nodeBox)
        {
            if (item == null) return;

            Data.ProjectionResultItem result = item.GetResult();
            if (result == null || result.IsEmpty) return;

            int elementCount = 0;
            int edgeCount = 0;
            int pointCount = 0;

            float minX = 0.0f;
            float minY = 0.0f;
            float maxX = 0.0f;
            float maxY = 0.0f;
            bool hasPoint = false;

            float minVX = 0.0f;
            float minVY = 0.0f;
            float minVZ = 0.0f;
            float maxVX = 0.0f;
            float maxVY = 0.0f;
            float maxVZ = 0.0f;
            bool hasVertex = false;

            double area = 0.0;

            StringBuilder points = new StringBuilder();
            StringBuilder vertex = new StringBuilder();
            StringBuilder pathGeometry = new StringBuilder();

            foreach (Data.ProjectionElementItem element in result.Elements)
            {
                if (element == null || element.Edges == null) continue;

                elementCount++;

                List<Data.Vector2> areaPoints = new List<Data.Vector2>();

                bool isFirstEdge = true;

                foreach (Data.ProjectionEdgeItem edge in element.Edges)
                {
                    if (edge == null) continue;

                    edgeCount++;

                    if (isFirstEdge == true)
                    {
                        Data.ProjectionPointItem point1 = edge.Point1;

                        Data.Vector2 p2D = point1.LocalPosition;
                        Data.Vector3D v3D = point1.SourcePosition;

                        points.AppendLine($"{pointCount:000} : ({p2D.X:0.###}, {p2D.Y:0.###})");
                        vertex.AppendLine($"{pointCount:000} : X={v3D.X:0.###}, Y={v3D.Y:0.###}, Z={v3D.Z:0.###}");
                        pathGeometry.Append($"M{p2D.X:0.###},{p2D.Y:0.###}");

                        areaPoints.Add(p2D);

                        if (hasPoint == false)
                        {
                            minX = p2D.X;
                            minY = p2D.Y;
                            maxX = p2D.X;
                            maxY = p2D.Y;
                            hasPoint = true;
                        }
                        else
                        {
                            minX = Math.Min(minX, p2D.X);
                            minY = Math.Min(minY, p2D.Y);
                            maxX = Math.Max(maxX, p2D.X);
                            maxY = Math.Max(maxY, p2D.Y);
                        }

                        if (hasVertex == false)
                        {
                            minVX = v3D.X;
                            minVY = v3D.Y;
                            minVZ = v3D.Z;
                            maxVX = v3D.X;
                            maxVY = v3D.Y;
                            maxVZ = v3D.Z;
                            hasVertex = true;
                        }
                        else
                        {
                            minVX = Math.Min(minVX, v3D.X);
                            minVY = Math.Min(minVY, v3D.Y);
                            minVZ = Math.Min(minVZ, v3D.Z);
                            maxVX = Math.Max(maxVX, v3D.X);
                            maxVY = Math.Max(maxVY, v3D.Y);
                            maxVZ = Math.Max(maxVZ, v3D.Z);
                        }

                        pointCount++;
                        isFirstEdge = false;
                    }

                    Data.ProjectionPointItem point2 = edge.Point2;

                    Data.Vector2 p = point2.LocalPosition;
                    Data.Vector3D v = point2.SourcePosition;

                    points.AppendLine($"{pointCount:000} : ({p.X:0.###}, {p.Y:0.###})");
                    vertex.AppendLine($"{pointCount:000} : X={v.X:0.###}, Y={v.Y:0.###}, Z={v.Z:0.###}");
                    pathGeometry.Append($"L{p.X:0.###},{p.Y:0.###}");

                    areaPoints.Add(p);

                    if (hasPoint == false)
                    {
                        minX = p.X;
                        minY = p.Y;
                        maxX = p.X;
                        maxY = p.Y;
                        hasPoint = true;
                    }
                    else
                    {
                        minX = Math.Min(minX, p.X);
                        minY = Math.Min(minY, p.Y);
                        maxX = Math.Max(maxX, p.X);
                        maxY = Math.Max(maxY, p.Y);
                    }

                    if (hasVertex == false)
                    {
                        minVX = v.X;
                        minVY = v.Y;
                        minVZ = v.Z;
                        maxVX = v.X;
                        maxVY = v.Y;
                        maxVZ = v.Z;
                        hasVertex = true;
                    }
                    else
                    {
                        minVX = Math.Min(minVX, v.X);
                        minVY = Math.Min(minVY, v.Y);
                        minVZ = Math.Min(minVZ, v.Z);
                        maxVX = Math.Max(maxVX, v.X);
                        maxVY = Math.Max(maxVY, v.Y);
                        maxVZ = Math.Max(maxVZ, v.Z);
                    }

                    pointCount++;
                }

                if (areaPoints.Count > 2)
                {
                    double elementArea = 0.0;

                    for (int i = 0; i < areaPoints.Count; i++)
                    {
                        Data.Vector2 current = areaPoints[i];
                        Data.Vector2 next = areaPoints[(i + 1) % areaPoints.Count];

                        elementArea += (current.X * next.Y) - (next.X * current.Y);
                    }

                    area += Math.Abs(elementArea) * 0.5;
                }

                pathGeometry.Append("z");
                pathGeometry.AppendLine();
            }

            // 기존 Projection2D.Area와 동일한 값은 ProjectionItem에 없음. 뭘 나타내는지 모르겠음
            txtArea.Text = area.ToString("0.###");
            // 기존 VertexCount 대체값
            txtVertexCount.Text = pointCount.ToString();
            // ProjectionResultItem BoundingBox
            txtVertexBoundBox.Text = hasVertex
                ? $"Min({minVX:0.###}, {minVY:0.###}, {minVZ:0.###}) / Max({maxVX:0.###}, {maxVY:0.###}, {maxVZ:0.###})"
                : "";
            // 원본 모델 BoundBox
            txtNodeBoundBox.Text = nodeBox == null ? "" : nodeBox.ToStringMax();
            // 기존 Projection2D.Matrix와 동일한 값은 ProjectionItem에 없음
            txtMatrix.Text =
                $"Normal({item.PlaneNormal.X:0.###}, {item.PlaneNormal.Y:0.###}, {item.PlaneNormal.Z:0.###}) / " +
                $"Position({item.PlanePosition.X:0.###}, {item.PlanePosition.Y:0.###}, {item.PlanePosition.Z:0.###})";
            // 기존 CorrectionFactor 없음
            txtCorrectionFactorX.Text = "";
            txtCorrectionFactorY.Text = "";
            // 기존 Points / Vertex / PathGeometryString 없음
            txtPoints.Text = points.ToString();
            txtVertex.Text = vertex.ToString();
            txtPathGeometry.Text = pathGeometry.ToString();

            txtMinX.Text = hasPoint ? minX.ToString("0.###") : "";
            txtMinY.Text = hasPoint ? minY.ToString("0.###") : "";
            txtMaxX.Text = hasPoint ? maxX.ToString("0.###") : "";
            txtMaxY.Text = hasPoint ? maxY.ToString("0.###") : "";
        }


    }
}
