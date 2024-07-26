using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.SectionBoxSize
{
    public partial class FrmMain : Form
    {
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        public VIZCore3DX.NET.Data.Section Section { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;

            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3D_OnInitializedVIZCore3D;

            splitContainer1.Panel2.Controls.Add(vizcore3dx);
        }

        private void VIZCore3D_OnInitializedVIZCore3D(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================
            // 라이선스 파일을 통한 인증
            //vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            //vizcore3dx.License.LicenseServer("127.0.0.1", 8901);


            // ================================================================
            // License
            // ================================================================
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");
            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            vizcore3dx.Model.OnModelClosedEvent += Model_OnModelClosedEvent;
            vizcore3dx.Model.OnModelOpenedEvent += Model_OnModelClosedEvent;
        }

        private void Model_OnModelClosedEvent(object sender, EventArgs e)
        {
            Clear();
            groupBox3.Enabled = false;
        }

        private void Clear()
        {
            cbMinX.Items.Clear();
            cbMaxX.Items.Clear();
            cbMinY.Items.Clear();
            cbMaxY.Items.Clear();
            cbMinZ.Items.Clear();
            cbMaxZ.Items.Clear();

            cbMinX.Text = string.Empty;
            cbMaxX.Text = string.Empty;
            cbMinY.Text = string.Empty;
            cbMaxY.Text = string.Empty;
            cbMinZ.Text = string.Empty;
            cbMaxZ.Text = string.Empty;
        }
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            vizcore3dx.Model.OpenFileDialog();
        }

        private void btnOpenFrame_Click(object sender, EventArgs e)
        {
            vizcore3dx.Frame.OpenFileDialog();
        }

        private void btnAddSectionBox_Click(object sender, EventArgs e)
        {
            Section = vizcore3dx.Section.AddBox(false);
            VIZCore3DX.NET.Data.BoundBox3D box = Section.BoundBox;

            cbMinX.SelectedIndexChanged -= new System.EventHandler(cbMinX_SelectedIndexChanged);
            cbMinY.SelectedIndexChanged -= new System.EventHandler(cbMinY_SelectedIndexChanged);
            cbMinZ.SelectedIndexChanged -= new System.EventHandler(cbMinZ_SelectedIndexChanged);

            cbMaxX.SelectedIndexChanged -= new System.EventHandler(cbMaxX_SelectedIndexChanged);
            cbMaxY.SelectedIndexChanged -= new System.EventHandler(cbMaxY_SelectedIndexChanged);
            cbMaxZ.SelectedIndexChanged -= new System.EventHandler(cbMaxZ_SelectedIndexChanged);

            tbMinX.Scroll -= new System.EventHandler(tbMinX_Scroll);
            tbMinY.Scroll -= new System.EventHandler(tbMinY_Scroll);
            tbMinZ.Scroll -= new System.EventHandler(tbMinZ_Scroll);

            tbMaxX.Scroll -= new System.EventHandler(tbMaxX_Scroll);
            tbMaxY.Scroll -= new System.EventHandler(tbMaxY_Scroll);
            tbMaxZ.Scroll -= new System.EventHandler(tbMaxZ_Scroll);

            Clear();

            if (vizcore3dx.Frame.HasFrame)
            {
                groupBox3.Enabled = true;

                List<VIZCore3DX.NET.Data.FrameItem> xItems = vizcore3dx.Frame.GetGridItems(VIZCore3DX.NET.Data.Axis.X);

                cbMinX.Items.Add("MinX");
                cbMaxX.Items.Add("MinX");
                for (int i = 0; i < xItems.Count; i++)
                {
                    int position = GetFramePosition(VIZCore3DX.NET.Data.Axis.X, xItems[i].ToString());
                    if (position < (box.MinX - 0)) continue;
                    if ((box.MaxX + 0) < position) continue;

                    cbMinX.Items.Add(xItems[i].LabelStr);
                    cbMaxX.Items.Add(xItems[i].LabelStr);
                }
                cbMinX.Items.Add("MaxX");
                cbMaxX.Items.Add("MaxX");

                cbMinX.Text = cbMinX.Items[0].ToString();
                cbMaxX.Text = cbMaxX.Items[cbMaxX.Items.Count - 1].ToString();

                List<VIZCore3DX.NET.Data.FrameItem> yItems = vizcore3dx.Frame.GetGridItems(VIZCore3DX.NET.Data.Axis.Y);

                cbMinY.Items.Add("MinY");
                cbMaxY.Items.Add("MinY");
                for (int i = 0; i < yItems.Count; i++)
                {
                    int position = GetFramePosition(VIZCore3DX.NET.Data.Axis.Y, yItems[i].ToString());
                    if (position < (box.MinY - 0)) continue;
                    if ((box.MaxY + 0) < position) continue;

                    cbMinY.Items.Add(yItems[i].LabelStr);
                    cbMaxY.Items.Add(yItems[i].LabelStr);
                }
                cbMinY.Items.Add("MaxY");
                cbMaxY.Items.Add("MaxY");

                cbMinY.Text = cbMinY.Items[0].ToString();
                cbMaxY.Text = cbMaxY.Items[cbMaxY.Items.Count - 1].ToString();

                List<VIZCore3DX.NET.Data.FrameItem> zItems = vizcore3dx.Frame.GetGridItems(VIZCore3DX.NET.Data.Axis.Z);

                cbMinZ.Items.Add("MinZ");
                cbMaxZ.Items.Add("MinZ");
                for (int i = 0; i < zItems.Count; i++)
                {
                    int position = GetFramePosition(VIZCore3DX.NET.Data.Axis.Z, zItems[i].ToString());
                    if (position < (box.MinZ - 0)) continue;
                    if ((box.MaxZ + 0) < position) continue;

                    cbMinZ.Items.Add(zItems[i].LabelStr);
                    cbMaxZ.Items.Add(zItems[i].LabelStr);
                }
                cbMinZ.Items.Add("MaxZ");
                cbMaxZ.Items.Add("MaxZ");

                cbMinZ.Text = cbMinZ.Items[0].ToString();
                cbMaxZ.Text = cbMaxZ.Items[cbMaxZ.Items.Count - 1].ToString();
            }

            tbMinX.Minimum = tbMaxX.Minimum = 0;
            tbMinX.Maximum = tbMaxX.Maximum = cbMaxX.Items.Count-1;

            tbMinX.Value = tbMinX.Minimum;
            tbMaxX.Value = tbMaxX.Maximum;

            tbMinY.Minimum = tbMaxY.Minimum =0;
            tbMinY.Maximum = tbMaxY.Maximum = cbMaxY.Items.Count-1;

            tbMinY.Value = tbMinY.Minimum;
            tbMaxY.Value = tbMaxY.Maximum;

            tbMinZ.Minimum = tbMaxZ.Minimum = 0;
            tbMinZ.Maximum = tbMaxZ.Maximum = cbMaxZ.Items.Count-1;

            tbMinZ.Value = tbMinZ.Minimum;
            tbMaxZ.Value = tbMaxZ.Maximum;


            cbMinX.SelectedIndexChanged += new System.EventHandler(cbMinX_SelectedIndexChanged);
            cbMinY.SelectedIndexChanged += new System.EventHandler(cbMinY_SelectedIndexChanged);
            cbMinZ.SelectedIndexChanged += new System.EventHandler(cbMinZ_SelectedIndexChanged);

            cbMaxX.SelectedIndexChanged += new System.EventHandler(cbMaxX_SelectedIndexChanged);
            cbMaxY.SelectedIndexChanged += new System.EventHandler(cbMaxY_SelectedIndexChanged);
            cbMaxZ.SelectedIndexChanged += new System.EventHandler(cbMaxZ_SelectedIndexChanged);

            tbMinX.Scroll += new System.EventHandler(tbMinX_Scroll);
            tbMinY.Scroll += new System.EventHandler(tbMinY_Scroll);
            tbMinZ.Scroll += new System.EventHandler(tbMinZ_Scroll);

            tbMaxX.Scroll += new System.EventHandler(tbMaxX_Scroll);
            tbMaxY.Scroll += new System.EventHandler(tbMaxY_Scroll);
            tbMaxZ.Scroll += new System.EventHandler(tbMaxZ_Scroll);
        }


        private void UpdateSectionBoxSize(SectionPlanePositionType type)
        {
            if (Section == null) return;
            float position = 0f;
            switch (type)
            {
                case SectionPlanePositionType.XMin:
                    if (cbMinX.Text == "MinX")
                    {
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, Section.BoundBox.MinX);
                    }
                    else if(cbMinX.Text == "MaxX")
                    {
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, Section.BoundBox.MaxX);
                    }
                    else
                    {
                        position = GetFramePosition(VIZCore3DX.NET.Data.Axis.X, cbMinX.Text);
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, position);
                    }
                    break;
                case SectionPlanePositionType.XMax:
                    if (cbMaxX.Text == "MaxX")
                    {
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, Section.BoundBox.MaxX);
                    }
                    else if(cbMaxX.Text == "MinX")
                    {
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, Section.BoundBox.MinX);
                    }
                    else
                    {
                        position = GetFramePosition(VIZCore3DX.NET.Data.Axis.X, cbMaxX.Text);
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, position);
                    }
                    break;
                case SectionPlanePositionType.YMin:
                    if (cbMinY.Text == "MinY")
                    {
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, Section.BoundBox.MinY);
                    }
                    else if(cbMinY.Text == "MaxY")
                    {
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, Section.BoundBox.MaxY);
                    }
                    else
                    {
                        position = GetFramePosition(VIZCore3DX.NET.Data.Axis.Y, cbMinY.Text);
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, position);
                    }
                    break;
                case SectionPlanePositionType.YMax:
                    if (cbMaxY.Text == "MaxY")
                    {
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, Section.BoundBox.MaxY);
                    }
                    else if(cbMaxY.Text == "MinY")
                    {
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, Section.BoundBox.MinY);
                    }
                    else
                    {
                        position = GetFramePosition(VIZCore3DX.NET.Data.Axis.Y, cbMaxY.Text);
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, position);
                    }
                    break;
                case SectionPlanePositionType.ZMin:
                    if (cbMinZ.Text == "MinZ")
                    {
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, Section.BoundBox.MinZ);
                    }
                    else if (cbMinZ.Text == "MaxZ")
                    {
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, Section.BoundBox.MaxZ);
                    }
                    else
                    {
                        position = GetFramePosition(VIZCore3DX.NET.Data.Axis.Z, cbMinZ.Text);
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, position);
                    }
                    break;
                case SectionPlanePositionType.ZMax:
                    if (cbMaxZ.Text == "MaxZ")
                    {
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, Section.BoundBox.MaxZ);
                    }
                    else if(cbMaxZ.Text == "MinZ")
                    {
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, Section.BoundBox.MinZ);
                    }
                    else
                    {
                        position = GetFramePosition(VIZCore3DX.NET.Data.Axis.Z, cbMaxZ.Text);
                        vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, position);
                    }
                    break;
            }
        }

        private int GetFramePosition(VIZCore3DX.NET.Data.Axis axis, string frame)
        {
            VIZCore3DX.NET.Data.FramePosition fp = vizcore3dx.Frame.GetPosition(axis, frame);
            if (!fp.ValidData) return 0;
            else return Convert.ToInt32(fp.Position);
        }

        private string GetFrameLabel(VIZCore3DX.NET.Data.Axis axis, int position)
        {
            VIZCore3DX.NET.Data.FrameItem fi = vizcore3dx.Frame.GetSnap(axis, position);
            string str = fi.LabelStr;
            if (str == "0") return String.Empty;
            else return str;
        }

        private void tbMinX_Scroll(object sender, EventArgs e)
        {
            cbMinX.SelectedIndexChanged -= new System.EventHandler(cbMinX_SelectedIndexChanged);
            cbMinX.SelectedIndex = tbMinX.Value;
            cbMinX.SelectedIndexChanged += new System.EventHandler(cbMinX_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.XMin);
        }

        private void tbMaxX_Scroll(object sender, EventArgs e)
        {
            cbMaxX.SelectedIndexChanged -= new System.EventHandler(cbMaxX_SelectedIndexChanged);
            cbMaxX.SelectedIndex = tbMaxX.Value;
            cbMaxX.SelectedIndexChanged += new System.EventHandler(cbMaxX_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.XMax);
        }

        private void tbMinY_Scroll(object sender, EventArgs e)
        {
            cbMinY.SelectedIndexChanged -= new System.EventHandler(cbMinY_SelectedIndexChanged);
            cbMinY.SelectedIndex = tbMinY.Value;
            cbMinY.SelectedIndexChanged += new System.EventHandler(cbMinY_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.YMin);
        }

        private void tbMaxY_Scroll(object sender, EventArgs e)
        {
            cbMaxY.SelectedIndexChanged -= new System.EventHandler(cbMaxY_SelectedIndexChanged);
            cbMaxY.SelectedIndex = tbMaxY.Value;
            cbMaxY.SelectedIndexChanged += new System.EventHandler(cbMaxY_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.YMax);
        }

        private void tbMinZ_Scroll(object sender, EventArgs e)
        {
            cbMinZ.SelectedIndexChanged -= new System.EventHandler(cbMinZ_SelectedIndexChanged);
            cbMinZ.SelectedIndex = tbMinZ.Value;
            cbMinZ.SelectedIndexChanged += new System.EventHandler(cbMinZ_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.ZMin);
        }

        private void tbMaxZ_Scroll(object sender, EventArgs e)
        {
            cbMaxZ.SelectedIndexChanged -= new System.EventHandler(cbMaxZ_SelectedIndexChanged);
            cbMaxZ.SelectedIndex = tbMaxZ.Value;
            cbMaxZ.SelectedIndexChanged += new System.EventHandler(cbMaxZ_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.ZMax);
        }

        private void cbMinX_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbMinX.Scroll -= new System.EventHandler(tbMinX_Scroll);
            tbMinX.Value = cbMinX.SelectedIndex;
            tbMinX.Scroll += new System.EventHandler(tbMinX_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.XMin);
        }

        private void cbMaxX_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbMaxX.Scroll -= new System.EventHandler(tbMaxX_Scroll);
            tbMaxX.Value = cbMaxX.SelectedIndex;
            tbMaxX.Scroll += new System.EventHandler(tbMaxX_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.XMax);
        }

        private void cbMinY_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbMinY.Scroll -= new System.EventHandler(tbMinY_Scroll);
            tbMinY.Value = cbMinY.SelectedIndex;
            tbMinY.Scroll += new System.EventHandler(tbMinY_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.YMin);
        }

        private void cbMaxY_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbMaxY.Scroll -= new System.EventHandler(tbMaxY_Scroll);
            tbMaxY.Value = cbMaxY.SelectedIndex;
            tbMaxY.Scroll += new System.EventHandler(tbMaxY_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.YMax);
        }

        private void cbMinZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbMinZ.Scroll -= new System.EventHandler(tbMinZ_Scroll);
            tbMinZ.Value = cbMinZ.SelectedIndex;
            tbMinZ.Scroll += new System.EventHandler(tbMinZ_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.ZMin);
        }

        private void cbMaxZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbMaxZ.Scroll -= new System.EventHandler(tbMaxZ_Scroll);
            tbMaxZ.Value = cbMaxZ.SelectedIndex;
            tbMaxZ.Scroll += new System.EventHandler(tbMaxZ_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.ZMax);
        }
    }
}
