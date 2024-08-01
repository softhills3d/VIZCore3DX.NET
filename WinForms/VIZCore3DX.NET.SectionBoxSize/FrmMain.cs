using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;
using VIZCore3DX.NET.Manager;
using static VIZCore3DX.NET.Manager.SectionManager;

namespace VIZCore3DX.NET.SectionBoxSize
{
    public partial class FrmMain : Form
    {
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        public VIZCore3DX.NET.Data.Section Section { get; set; }

        private bool isScroll = false;

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
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX,NET.lic");
            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            vizcore3dx.Section.OnSectionEvent += VIZCore3DX_OnSectionEvent;
        }

        private void VIZCore3DX_OnSectionEvent(object sender, Event.EventManager.SectionEventArgs e)
        {
            if(e.EventType == SectionEventType.Moved)
            {
                if (isScroll)
                {
                   
                }
                else
                {
                    vizcore3dx.Frame.GridArea = e.Section.BoundBox;

                    BoundBox3D box = e.Section.BoundBox;

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

                    int MinX = Convert.ToInt32(box.MinX);
                    if(MinX < tbMinX.Minimum)
                    {
                        tbMinX.Value = tbMinX.Minimum;
                    }
                    else if (MinX > tbMinX.Maximum)
                    {
                        tbMinX.Value = tbMinX.Maximum;
                    } else
                    {
                        tbMinX.Value = MinX;

                    }
                    cbMinX.Text = GetFrameLabel(VIZCore3DX.NET.Data.Axis.X, tbMinX.Value);

                    int MaxX = Convert.ToInt32(box.MaxX);
                    if (MaxX < tbMaxX.Minimum)
                    {
                        tbMaxX.Value = tbMaxX.Minimum;
                    }
                    else if (MaxX > tbMaxX.Maximum)
                    {
                        tbMaxX.Value = tbMaxX.Maximum;
                    }
                    else
                    {
                        tbMaxX.Value = MaxX;

                    }
                    cbMaxX.Text = GetFrameLabel(VIZCore3DX.NET.Data.Axis.X, tbMaxX.Value);

                    int MinY = Convert.ToInt32(box.MinY);
                    if (MinY < tbMinY.Minimum)
                    {
                        tbMinY.Value = tbMinY.Minimum;
                    }
                    else if (MinY > tbMinY.Maximum)
                    {
                        tbMinY.Value = tbMinY.Maximum;
                    }
                    else
                    {
                        tbMinY.Value = MinY;

                    }
                    cbMinY.Text = GetFrameLabel(VIZCore3DX.NET.Data.Axis.Y, tbMinY.Value);

                    int MaxY = Convert.ToInt32(box.MaxY);
                    if (MaxY < tbMaxY.Minimum)
                    {
                        tbMaxY.Value = tbMaxY.Minimum;
                    }
                    else if (MaxY > tbMaxY.Maximum)
                    {
                        tbMaxY.Value = tbMaxY.Maximum;
                    }
                    else
                    {
                        tbMaxY.Value = MaxY;

                    }
                    cbMaxY.Text = GetFrameLabel(VIZCore3DX.NET.Data.Axis.Y, tbMaxY.Value);

                    int MinZ = Convert.ToInt32(box.MinZ);
                    if (MinZ < tbMinZ.Minimum)
                    {
                        tbMinZ.Value = tbMinZ.Minimum;
                    }
                    else if (MinZ > tbMinZ.Maximum)
                    {
                        tbMinZ.Value = tbMinZ.Maximum;
                    }
                    else
                    {
                        tbMinZ.Value = MinZ;

                    }
                    cbMinZ.Text = GetFrameLabel(VIZCore3DX.NET.Data.Axis.Z, tbMinZ.Value);

                    int MaxZ = Convert.ToInt32(box.MaxZ);
                    if (MaxZ < tbMaxZ.Minimum)
                    {
                        tbMaxZ.Value = tbMaxZ.Minimum;
                    }
                    else if (MaxZ > tbMinZ.Maximum)
                    {
                        tbMaxZ.Value = tbMaxZ.Maximum;
                    }
                    else
                    {
                        tbMaxZ.Value = MaxZ;

                    }
                    cbMaxZ.Text = GetFrameLabel(VIZCore3DX.NET.Data.Axis.Z, tbMaxZ.Value);

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

                    vizcore3dx.Update();
                }
            }
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


            tbMinX.Minimum = tbMaxX.Minimum = Convert.ToInt32(box.MinX);
            tbMinX.Maximum = tbMaxX.Maximum = Convert.ToInt32(box.MaxX);
            tbMinX.Value = tbMinX.Minimum;
            tbMaxX.Value = tbMaxX.Maximum;

            tbMinY.Minimum = tbMaxY.Minimum = Convert.ToInt32(box.MinY);
            tbMinY.Maximum = tbMaxY.Maximum = Convert.ToInt32(box.MaxY);
            tbMinY.Value = tbMinY.Minimum;
            tbMaxY.Value = tbMaxY.Maximum;

            tbMinZ.Minimum = tbMaxZ.Minimum = Convert.ToInt32(box.MinZ);
            tbMinZ.Maximum = tbMaxZ.Maximum = Convert.ToInt32(box.MaxZ);
            tbMinZ.Value = tbMinZ.Minimum;
            tbMaxZ.Value = tbMaxZ.Maximum;

            if (vizcore3dx.Frame.HasFrame == true)
            {
                List<VIZCore3DX.NET.Data.FrameItem> xItems = vizcore3dx.Frame.GetGridItems(VIZCore3DX.NET.Data.Axis.X);

                for (int i = 0; i < xItems.Count; i++)
                {
                    int position = GetFramePosition(VIZCore3DX.NET.Data.Axis.X, xItems[i].ToString());
                    if (position < (box.MinX - 0)) continue;
                    if ((box.MaxX + 0) < position) continue;

                    cbMinX.Items.Add(xItems[i].LabelStr);
                    cbMaxX.Items.Add(xItems[i].LabelStr);
                }

                cbMinX.Text = cbMinX.Items[0].ToString();
                cbMaxX.Text = cbMaxX.Items[cbMaxX.Items.Count - 1].ToString();

                List<VIZCore3DX.NET.Data.FrameItem> yItems = vizcore3dx.Frame.GetGridItems(VIZCore3DX.NET.Data.Axis.Y);

                for (int i = 0; i < yItems.Count; i++)
                {
                    int position = GetFramePosition(VIZCore3DX.NET.Data.Axis.Y, yItems[i].ToString());
                    if (position < (box.MinY - 0)) continue;
                    if ((box.MaxY + 0) < position) continue;

                    cbMinY.Items.Add(yItems[i].LabelStr);
                    cbMaxY.Items.Add(yItems[i].LabelStr);
                }

                cbMinY.Text = cbMinY.Items[0].ToString();
                cbMaxY.Text = cbMaxY.Items[cbMaxY.Items.Count - 1].ToString();

                List<VIZCore3DX.NET.Data.FrameItem> zItems = vizcore3dx.Frame.GetGridItems(VIZCore3DX.NET.Data.Axis.Z);

                for (int i = 0; i < zItems.Count; i++)
                {
                    int position = GetFramePosition(VIZCore3DX.NET.Data.Axis.Z, zItems[i].ToString());
                    if (position < (box.MinZ - 0)) continue;
                    if ((box.MaxZ + 0) < position) continue;

                    cbMinZ.Items.Add(zItems[i].LabelStr);
                    cbMaxZ.Items.Add(zItems[i].LabelStr);
                }

                cbMinZ.Text = cbMinZ.Items[0].ToString();
                cbMaxZ.Text = cbMaxZ.Items[cbMaxZ.Items.Count - 1].ToString();
            }

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

            vizcore3dx.Frame.GridAreaMode = GridAreaMode.Fixed;
            vizcore3dx.Frame.GridArea = vizcore3dx.Section.Sections[0].BoundBox;
            vizcore3dx.Update();
        }

        private void UpdateSectionBoxSize(SectionPlanePositionType type)
        {
            if (Section == null) return;
            float position = 0f;
            switch (type)
            {
                case SectionPlanePositionType.XMin:
                    position = tbMinX.Value;
                    vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, position);
                    break;
                case SectionPlanePositionType.XMax:
                    position = tbMaxX.Value;
                    vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, position);
                    break;
                case SectionPlanePositionType.YMin:
                    position = tbMinY.Value;
                    vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, position);
                    break;
                case SectionPlanePositionType.YMax:
                    position = tbMaxY.Value;
                    vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, position);
                    break;
                case SectionPlanePositionType.ZMin:
                    position = tbMinZ.Value;
                    vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, position);
                    break;
                case SectionPlanePositionType.ZMax:
                    position = tbMaxZ.Value;
                    vizcore3dx.Section.SetBoxPlaneSize(Section.ID, type, position);
                    break;
            }
        }

        private int GetFramePosition(VIZCore3DX.NET.Data.Axis axis, string frame)
        {
            VIZCore3DX.NET.Data.FramePosition fp = vizcore3dx.Frame.GetPosition(axis, frame);
            if (fp.ValidData == false) return 0;
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
            isScroll = true;
            cbMinX.SelectedIndexChanged -= new System.EventHandler(cbMinX_SelectedIndexChanged);
            cbMinX.Text = GetFrameLabel(VIZCore3DX.NET.Data.Axis.X, tbMinX.Value);
            cbMinX.SelectedIndexChanged += new System.EventHandler(cbMinX_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.XMin);
        }

        private void tbMaxX_Scroll(object sender, EventArgs e)
        {
            isScroll = true;
            cbMaxX.SelectedIndexChanged -= new System.EventHandler(cbMaxX_SelectedIndexChanged);
            cbMaxX.Text = GetFrameLabel(VIZCore3DX.NET.Data.Axis.X, tbMaxX.Value);
            cbMaxX.SelectedIndexChanged += new System.EventHandler(cbMaxX_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.XMax);
        }

        private void tbMinY_Scroll(object sender, EventArgs e)
        {
            isScroll = true;
            cbMinY.SelectedIndexChanged -= new System.EventHandler(cbMinY_SelectedIndexChanged);
            cbMinY.Text = GetFrameLabel(VIZCore3DX.NET.Data.Axis.Y, tbMinY.Value);
            cbMinY.SelectedIndexChanged += new System.EventHandler(cbMinY_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.YMin);
        }

        private void tbMaxY_Scroll(object sender, EventArgs e)
        {
            isScroll = true;
            cbMaxY.SelectedIndexChanged -= new System.EventHandler(cbMaxY_SelectedIndexChanged);
            cbMaxY.Text = GetFrameLabel(VIZCore3DX.NET.Data.Axis.Y, tbMaxY.Value);
            cbMaxY.SelectedIndexChanged += new System.EventHandler(cbMaxY_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.YMax);
        }

        private void tbMinZ_Scroll(object sender, EventArgs e)
        {
            isScroll = true;
            cbMinZ.SelectedIndexChanged -= new System.EventHandler(cbMinZ_SelectedIndexChanged);
            cbMinZ.Text = GetFrameLabel(VIZCore3DX.NET.Data.Axis.Z, tbMinZ.Value);
            cbMinZ.SelectedIndexChanged += new System.EventHandler(cbMinZ_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.ZMin);
        }

        private void tbMaxZ_Scroll(object sender, EventArgs e)
        {
            isScroll = true;
            cbMaxZ.SelectedIndexChanged -= new System.EventHandler(cbMaxZ_SelectedIndexChanged);
            cbMaxZ.Text = GetFrameLabel(VIZCore3DX.NET.Data.Axis.Z, tbMaxZ.Value);
            cbMaxZ.SelectedIndexChanged += new System.EventHandler(cbMaxZ_SelectedIndexChanged);

            UpdateSectionBoxSize(SectionPlanePositionType.ZMax);
        }

        private void cbMinX_SelectedIndexChanged(object sender, EventArgs e)
        {
            isScroll = true;
            tbMinX.Scroll -= new System.EventHandler(tbMinX_Scroll);
            tbMinX.Value = GetFramePosition(VIZCore3DX.NET.Data.Axis.X, cbMinX.Text);
            tbMinX.Scroll += new System.EventHandler(tbMinX_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.XMin);

            vizcore3dx.Frame.GridArea = vizcore3dx.Section.Sections[0].BoundBox;
            vizcore3dx.Update();
        }

        private void cbMaxX_SelectedIndexChanged(object sender, EventArgs e)
        {
            isScroll = true;
            tbMaxX.Scroll -= new System.EventHandler(tbMaxX_Scroll);
            tbMaxX.Value = GetFramePosition(VIZCore3DX.NET.Data.Axis.X, cbMaxX.Text);
            tbMaxX.Scroll += new System.EventHandler(tbMaxX_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.XMax);

            vizcore3dx.Frame.GridArea = vizcore3dx.Section.Sections[0].BoundBox;
            vizcore3dx.Update();
        }

        private void cbMinY_SelectedIndexChanged(object sender, EventArgs e)
        {
            isScroll = true;
            tbMinY.Scroll -= new System.EventHandler(tbMinY_Scroll);
            tbMinY.Value = GetFramePosition(VIZCore3DX.NET.Data.Axis.Y, cbMinY.Text);
            tbMinY.Scroll += new System.EventHandler(tbMinY_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.YMin);

            vizcore3dx.Frame.GridArea = vizcore3dx.Section.Sections[0].BoundBox;
            vizcore3dx.Update();
        }

        private void cbMaxY_SelectedIndexChanged(object sender, EventArgs e)
        {
            isScroll = true;
            tbMaxY.Scroll -= new System.EventHandler(tbMaxY_Scroll);
            tbMaxY.Value = GetFramePosition(VIZCore3DX.NET.Data.Axis.Y, cbMaxY.Text);
            tbMaxY.Scroll += new System.EventHandler(tbMaxY_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.YMax);

            vizcore3dx.Frame.GridArea = vizcore3dx.Section.Sections[0].BoundBox;
            vizcore3dx.Update();
        }

        private void cbMinZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            isScroll = true;
            tbMinZ.Scroll -= new System.EventHandler(tbMinZ_Scroll);
            tbMinZ.Value = GetFramePosition(VIZCore3DX.NET.Data.Axis.Z, cbMinZ.Text);
            tbMinZ.Scroll += new System.EventHandler(tbMinZ_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.ZMin);

            vizcore3dx.Frame.GridArea = vizcore3dx.Section.Sections[0].BoundBox;
            vizcore3dx.Update();
        }

        private void cbMaxZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            isScroll = true;
            tbMaxZ.Scroll -= new System.EventHandler(tbMaxZ_Scroll);
            tbMaxZ.Value = GetFramePosition(VIZCore3DX.NET.Data.Axis.Z, cbMaxZ.Text);
            tbMaxZ.Scroll += new System.EventHandler(tbMaxZ_Scroll);

            UpdateSectionBoxSize(SectionPlanePositionType.ZMax);

            vizcore3dx.Frame.GridArea = vizcore3dx.Section.Sections[0].BoundBox;
            vizcore3dx.Update();
        }

        private void tbMinX_MouseUp(object sender, MouseEventArgs e)
        {
            vizcore3dx.Frame.GridArea = vizcore3dx.Section.Sections[0].BoundBox;
            vizcore3dx.Update();
            isScroll = false;
        }

        private void tbMaxX_MouseUp(object sender, MouseEventArgs e)
        {
            vizcore3dx.Frame.GridArea = vizcore3dx.Section.Sections[0].BoundBox;
            vizcore3dx.Update();
            isScroll = false;
        }

        private void tbMinY_MouseUp(object sender, MouseEventArgs e)
        {
            vizcore3dx.Frame.GridArea = vizcore3dx.Section.Sections[0].BoundBox;
            vizcore3dx.Update();
            isScroll = false;
        }

        private void tbMaxY_MouseUp(object sender, MouseEventArgs e)
        {
            vizcore3dx.Frame.GridArea = vizcore3dx.Section.Sections[0].BoundBox;
            vizcore3dx.Update();
            isScroll = false;
        }

        private void tbMinZ_MouseUp(object sender, MouseEventArgs e)
        {
            vizcore3dx.Frame.GridArea = vizcore3dx.Section.Sections[0].BoundBox;
            vizcore3dx.Update();
            isScroll = false;
        }

        private void tbMaxZ_MouseUp(object sender, MouseEventArgs e)
        {
            vizcore3dx.Frame.GridArea = vizcore3dx.Section.Sections[0].BoundBox;
            vizcore3dx.Update();
            isScroll = false;
        }
    }
}
