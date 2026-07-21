namespace VIZCore3DX.NET.CameraControl
{
    internal class CameraItem
    {
        //public VIZCore3DX.NET.Data.CameraData Camera { get; set; }
        public VIZCore3DX.NET.Data.Vertex3D EyePosition { get; set; }
        public VIZCore3DX.NET.Data.Vertex3D PivotPosition { get; set; }
        public VIZCore3DX.NET.Data.Vertex3D CameraDirection { get; set; }
        public VIZCore3DX.NET.Data.Vertex3D UpDirection { get; set; }
        public float Zoom { get; set; }
        public VIZCore3DX.NET.Data.Projections ProjectionType { get; set; }
        public System.Drawing.Image Snapshot { get; set; }

        public CameraItem()
        {

        }
    }
}
