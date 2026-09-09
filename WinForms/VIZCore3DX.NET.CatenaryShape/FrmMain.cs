using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.CatenaryShape
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
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

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
        }

        private VIZCore3DX.NET.Data.Vector3D GetStartPoint()
        {
            return new VIZCore3DX.NET.Data.Vector3D((float)numP1X.Value, (float)numP1Y.Value, (float)numP1Z.Value);
        }

        private VIZCore3DX.NET.Data.Vector3D GetEndPoint()
        {
            return new VIZCore3DX.NET.Data.Vector3D((float)numP2X.Value, (float)numP2Y.Value, (float)numP2Z.Value);
        }

        private void SetStartPoint(VIZCore3DX.NET.Data.Vector3D position)
        {
            numP1X.Value = GetNumericValue(numP1X, position.X);
            numP1Y.Value = GetNumericValue(numP1Y, position.Y);
            numP1Z.Value = GetNumericValue(numP1Z, position.Z);
        }

        private void SetEndPoint(VIZCore3DX.NET.Data.Vector3D position)
        {
            numP2X.Value = GetNumericValue(numP2X, position.X);
            numP2Y.Value = GetNumericValue(numP2Y, position.Y);
            numP2Z.Value = GetNumericValue(numP2Z, position.Z);
        }

        private decimal GetNumericValue(NumericUpDown control, float value)
        {
            decimal result = Convert.ToDecimal(value);

            if (result < control.Minimum)
            {
                result = control.Minimum;
            }

            if (result > control.Maximum)
            {
                result = control.Maximum;
            }

            return result;
        }

        private bool IsSamePoint(VIZCore3DX.NET.Data.Vector3D p1, VIZCore3DX.NET.Data.Vector3D p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y && p1.Z == p2.Z;
        }

        private VIZCore3DX.NET.Data.OsnapController CreatePointOsnap(string commandText)
        {
            VIZCore3DX.NET.Data.OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();

            if (osnap == null)
            {
                return null;
            }

            osnap.CommandText = commandText;
            osnap.PlaneSnap = true;
            osnap.LineSnap = true;
            osnap.EdgeEndpointSnap = true;
            osnap.EdgeMidpointSnap = true;
            osnap.CircleSnap = true;
            osnap.CircleCenterSnap = true;
            osnap.CylinderSnap = true;

            return osnap;
        }

        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            vizcore3dx.Model.OpenFileDialog();

            if (vizcore3dx.Model.IsOpen() == true)
            {
                vizcore3dx.View.FitToView();
            }
        }

        private async void btnPickP1_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 먼저 열어주세요.", "Catenary Shape", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            VIZCore3DX.NET.Data.OsnapController osnap = CreatePointOsnap("Catenary 시작점 P1을 선택하세요.");

            if (osnap == null)
            {
                return;
            }

            VIZCore3DX.NET.Data.OsnapResult result = await osnap.GetResultAsync();

            if (result == null)
            {
                return;
            }

            SetStartPoint(result.Position);
            lblP1Status.Text = string.Format("P1 : {0}", result.Type);
        }

        private async void btnPickP2_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 먼저 열어주세요.", "Catenary Shape", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            VIZCore3DX.NET.Data.OsnapController osnap = CreatePointOsnap("Catenary 끝점 P2를 선택하세요.");

            if (osnap == null)
            {
                return;
            }

            VIZCore3DX.NET.Data.OsnapResult result = await osnap.GetResultAsync();

            if (result == null)
            {
                return;
            }

            SetEndPoint(result.Position);
            lblP2Status.Text = string.Format("P2 : {0}", result.Type);
        }

        private async void btnPickP1P2_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 먼저 열어주세요.", "Catenary Shape", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnPickP1.Enabled = false;
            btnPickP2.Enabled = false;
            btnPickP1P2.Enabled = false;

            try
            {
                VIZCore3DX.NET.Data.OsnapController p1Osnap = CreatePointOsnap("Catenary 시작점 P1을 선택하세요.");

                if (p1Osnap == null)
                {
                    return;
                }

                VIZCore3DX.NET.Data.OsnapResult p1Result = await p1Osnap.GetResultAsync();

                if (p1Result == null)
                {
                    return;
                }

                SetStartPoint(p1Result.Position);
                lblP1Status.Text = string.Format("P1 : {0}", p1Result.Type);

                VIZCore3DX.NET.Data.OsnapController p2Osnap = CreatePointOsnap("Catenary 끝점 P2를 선택하세요.");

                if (p2Osnap == null)
                {
                    return;
                }

                VIZCore3DX.NET.Data.OsnapResult p2Result = await p2Osnap.GetResultAsync();

                if (p2Result == null)
                {
                    return;
                }

                SetEndPoint(p2Result.Position);
                lblP2Status.Text = string.Format("P2 : {0}", p2Result.Type);
            }
            finally
            {
                btnPickP1.Enabled = true;
                btnPickP2.Enabled = true;
                btnPickP1P2.Enabled = true;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 먼저 열어주세요.", "Catenary Shape", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            VIZCore3DX.NET.Data.Vector3D p1 = GetStartPoint();
            VIZCore3DX.NET.Data.Vector3D p2 = GetEndPoint();

            if (IsSamePoint(p1, p2) == true)
            {
                MessageBox.Show("시작점 P1과 끝점 P2가 같습니다.", "Catenary Shape", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double lengthFactor = (double)numLengthFactor.Value;
            int samples = (int)numSamples.Value;
            List<VIZCore3DX.NET.Data.Vector3D> points = vizcore3dx.Shape.ComputeCatenaryPoints(p1, p2, lengthFactor, samples);

            dgvPoints.Rows.Clear();

            if (points == null || points.Count == 0)
            {
                lblPointCount.Text = "계산된 Point : 0";
                return;
            }

            for (int i = 0; i < points.Count; i++)
            {
                VIZCore3DX.NET.Data.Vector3D point = points[i];
                dgvPoints.Rows.Add(i, point.X.ToString("0.###"), point.Y.ToString("0.###"), point.Z.ToString("0.###"));
            }

            lblPointCount.Text = string.Format("계산된 Point : {0}", points.Count);
        }

        private void btnCreateLine_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 먼저 열어주세요.", "Catenary Shape", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            VIZCore3DX.NET.Data.Vector3D p1 = GetStartPoint();
            VIZCore3DX.NET.Data.Vector3D p2 = GetEndPoint();

            if (IsSamePoint(p1, p2) == true)
            {
                MessageBox.Show("시작점 P1과 끝점 P2가 같습니다.", "Catenary Shape", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkClearBeforeCreate.Checked == true)
            {
                vizcore3dx.Shape.Clear();
            }

            vizcore3dx.Shape.CreateCatenaryShape(p1, p2, (double)numLengthFactor.Value, (float)numLineThickness.Value, btnShapeColor.BackColor);
            vizcore3dx.View.FitToView();
        }

        private void btnCreateTube_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 먼저 열어주세요.", "Catenary Shape", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            VIZCore3DX.NET.Data.Vector3D p1 = GetStartPoint();
            VIZCore3DX.NET.Data.Vector3D p2 = GetEndPoint();

            if (IsSamePoint(p1, p2) == true)
            {
                MessageBox.Show("시작점 P1과 끝점 P2가 같습니다.", "Catenary Shape", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkClearBeforeCreate.Checked == true)
            {
                vizcore3dx.Shape.Clear();
            }

            vizcore3dx.Shape.CreateCatenaryTubeShape(p1, p2, (double)numLengthFactor.Value, (float)numTubeRadius.Value, btnShapeColor.BackColor);
            vizcore3dx.View.FitToView();
        }

        private void btnShapeColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = btnShapeColor.BackColor;
                dialog.FullOpen = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                btnShapeColor.BackColor = dialog.Color;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 먼저 열어주세요.", "Catenary Shape", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            vizcore3dx.Shape.Clear();
        }

        private void btnFitToView_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 먼저 열어주세요.", "Catenary Shape", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            vizcore3dx.View.FitToView();
        }

    }
}
