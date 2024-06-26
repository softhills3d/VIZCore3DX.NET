using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Demo
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer2.Panel1.Controls.Add(vizcore3dx);

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
            //vizcore3dx.License.LicenseServer("127.0.0.1", 8901);


            // ================================================================
            // License
            // ================================================================
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");
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
        }


        //==========================================================================
        // Model
        //==========================================================================
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore3dx.Model.OpenFilter;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Model.Open(dlg.FileName);
        }

        private void btnAddModels_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore3dx.Model.OpenFilter;
            dlg.Multiselect = true;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Model.Add(dlg.FileNames);
        }

        private void btnCloseModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Model.Close();
        }

        private void btnModelBoundBox_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            VIZCore3DX.NET.Data.BoundBox3D box = 
                vizcore3dx.Model.BoundBox;

            MessageBox.Show(box.ToString(), "Model BoundBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //==========================================================================
        // Object
        //==========================================================================
        private void btnAllObjects_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            List<VIZCore3DX.NET.Data.Node> nodes =
                vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.ALL);

            if (nodes.Count == 0)
            {
                MessageBox.Show("Node count is 0", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgView.DataSource = nodes;
        }

        private void btnSelectedAllObjects_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            List<VIZCore3DX.NET.Data.Node> nodes =
                vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_ALL);

            if (nodes.Count == 0)
            {
                MessageBox.Show("Node count is 0", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgView.DataSource = nodes;
        }

        private void btnSelectedTopObjects_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            List<VIZCore3DX.NET.Data.Node> nodes =
                vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);

            if (nodes.Count == 0)
            {
                MessageBox.Show("Node count is 0", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgView.DataSource = nodes;
        }


        //==========================================================================
        // Section
        //==========================================================================
        private void btnAddSectionBox_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            VIZCore3DX.NET.Data.Section section = vizcore3dx.Section.AddBox(false);

            MessageBox.Show(section.BoundBox.ToString(), "BoundBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClearSection_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Section.Clear();
        }

        private void btnUpdateSectionBoxSize_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            VIZCore3DX.NET.Data.BoundBox3D box = vizcore3dx.Model.BoundBox;

            float minX = box.MinX + (box.LengthX / 4);
            float minY = box.MinY + (box.LengthY / 4);
            float minZ = box.MinZ + (box.LengthZ / 4);

            float maxX = box.MaxX - (box.LengthX / 4);
            float maxY = box.MaxY - (box.LengthY / 4);
            float maxZ = box.MaxZ - (box.LengthZ / 4);

            box.MinX = minX;
            box.MinY = minY;
            box.MinZ = minZ;

            box.MaxX = maxX;
            box.MaxY = maxY;
            box.MaxZ = maxZ;

            vizcore3dx.Section.Clear();
            VIZCore3DX.NET.Data.Section section = vizcore3dx.Section.AddBox(true);

            vizcore3dx.Section.SetBoxSize(section.ID, box);
        }


        //==========================================================================
        // Frame
        //==========================================================================
        private void btnOpenFrame_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore3dx.Frame.Filter;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Frame.Open(dlg.FileName);
        }

        private void btnShowFrame_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Frame.HasFrame == false) return;

            vizcore3dx.Frame.Visible = true;
        }

        private void btnHideFrame_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Frame.HasFrame == false) return;

            vizcore3dx.Frame.Visible = false;
        }

        private void btnGetGridItemsX_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Frame.HasFrame == false) return;

            List<VIZCore3DX.NET.Data.FrameItem> items =
                vizcore3dx.Frame.GetGridItems(VIZCore3DX.NET.Data.Axis.X);

            if (items.Count == 0)
            {
                MessageBox.Show("FrameItem is 0", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvGridResult.Items.Count > 0) lvGridResult.Items.Clear();

            for (int i = 0; i < items.Count; i++)
            {
                VIZCore3DX.NET.Data.FrameItem item2 = items[i];
                VIZCore3DX.NET.Data.FramePosition position = vizcore3dx.Frame.GetPosition(VIZCore3DX.NET.Data.Axis.X, items[i].ToString());

               VIZCore3DX.NET.Data.FrameItem item = vizcore3dx.Frame.GetSnap(VIZCore3DX.NET.Data.Axis.X, (int)position.Position);

                ListViewItem listView = new ListViewItem(new string[] { item.GridID.ToString(), item.Axis.ToString(), item.Label.ToString(), item.Offset.ToString() });
                lvGridResult.Items.Add(listView);

            }
        }

        private void btnGetGridItemsY_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Frame.HasFrame == false) return; 

            List<VIZCore3DX.NET.Data.FrameItem> items =
                vizcore3dx.Frame.GetGridItems(VIZCore3DX.NET.Data.Axis.Y);

            if (items.Count == 0)
            {
                MessageBox.Show("FrameItem is 0", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvGridResult.Items.Count > 0) lvGridResult.Items.Clear();

            for (int i = 0; i < items.Count; i++)
            {
                VIZCore3DX.NET.Data.FramePosition position = vizcore3dx.Frame.GetPosition(VIZCore3DX.NET.Data.Axis.Y, items[i].ToString());

                VIZCore3DX.NET.Data.FrameItem item = vizcore3dx.Frame.GetSnap(VIZCore3DX.NET.Data.Axis.Y, (int)position.Position);

                ListViewItem listView = new ListViewItem(new string[] { item.GridID.ToString(), item.Axis.ToString(), item.Label.ToString(), item.Offset.ToString() });
                lvGridResult.Items.Add(listView);
            }
        }

        private void btnGetGridItemsZ_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Frame.HasFrame == false) return;

            List<VIZCore3DX.NET.Data.FrameItem> items =
                vizcore3dx.Frame.GetGridItems(VIZCore3DX.NET.Data.Axis.Z);

            if (items.Count == 0)
            {
                MessageBox.Show("FrameItem is 0", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvGridResult.Items.Count > 0) lvGridResult.Items.Clear();

            for (int i = 0; i < items.Count; i++)
            {
                VIZCore3DX.NET.Data.FramePosition position = vizcore3dx.Frame.GetPosition(VIZCore3DX.NET.Data.Axis.Z, items[i].ToString());

               VIZCore3DX.NET.Data.FrameItem item = vizcore3dx.Frame.GetSnap(VIZCore3DX.NET.Data.Axis.Z, (int)position.Position);

                ListViewItem listView = new ListViewItem(new string[] { item.GridID.ToString(), item.Axis.ToString(), item.Label.ToString(), item.Offset.ToString() });
                lvGridResult.Items.Add(listView);
            }
        }


        //==========================================================================
        // View
        //==========================================================================
        private void btnXrayEnable_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.View.XRay.Enable = true;
        }

        private void btnXrayDisable_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.View.XRay.Enable = false;
        }

        private void btnXrayColor1_Click(object sender, EventArgs e)
        {
            vizcore3dx.View.XRay.ColorType = VIZCore3DX.NET.Data.XRayColorTypes.SELECTION_COLOR;
        }

        private void btnXrayColor2_Click(object sender, EventArgs e)
        {
            vizcore3dx.View.XRay.ColorType = VIZCore3DX.NET.Data.XRayColorTypes.OBJECT_COLOR;
        }

        private void btnXraySelectObjects_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string keyword = txtXrayObjects.Text;

            if(String.IsNullOrEmpty(keyword) == true)
            {
                MessageBox.Show("Keyword is empty", "Keyword", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> items =
                vizcore3dx.Object3D.Find.QuickSearch(keyword, false);

            if(items.Count == 0)
            {
                MessageBox.Show("Node count is 0", "Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vizcore3dx.View.XRay.Clear();
            vizcore3dx.View.XRay.Select(items, true);
        }

        private void btnXrayClearObjects_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.View.XRay.Clear();
        }

        private void btnSetColor_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string keyword = txtColorObjects.Text;

            if (String.IsNullOrEmpty(keyword) == true)
            {
                MessageBox.Show("Keyword is empty", "Keyword", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> items =
                vizcore3dx.Object3D.Find.QuickSearch(keyword, false);

            if (items.Count == 0)
            {
                MessageBox.Show("Node count is 0", "Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vizcore3dx.Object3D.Color.SetColor(items, Color.Yellow);
        }

        private void btnRestoreColor_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Object3D.Color.RestoreColor();
            //vizcore3dx.Object3D.Color.Restore();
            //vizcore3dx.Object3D.Color.RestoreAll();
            //vizcore3dx.Object3D.Color.RestoreColorAll();
        }

        private void btnSetAlpha_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string keyword = txtAlphaObjects.Text;

            if (String.IsNullOrEmpty(keyword) == true)
            {
                MessageBox.Show("Keyword is empty", "Keyword", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> items =
                vizcore3dx.Object3D.Find.QuickSearch(keyword, false);

            if (items.Count == 0)
            {
                MessageBox.Show("Node count is 0", "Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vizcore3dx.Object3D.Color.SetAlpha(items, 50);
        }

        private void btnRestoreAlpha_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Object3D.Color.RestoreAlpha();
            //vizcore3dx.Object3D.Color.RestoreAll();
            //vizcore3dx.Object3D.Color.RestoreColorAll();
        }

        //==========================================================================
        // UDA
        //==========================================================================
        private void btnUDAInfo_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string keyword = txtUDA1.Text;

            if (String.IsNullOrEmpty(keyword) == true)
            {
                MessageBox.Show("Keyword is empty", "Keyword", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> items =
                vizcore3dx.Object3D.Find.QuickSearch(keyword, false);

            if (items.Count == 0)
            {
                MessageBox.Show("Node count is 0", "Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
         
            Dictionary<string, string> uda = vizcore3dx.Object3D.UDA.FromEntry(items[0].EntityID, items[0].Index); // 현재 없는 API. FromIndex 대체 함수 필요 = > FromEntry

            List<string> keyItems = new List<string>();
            List<string> valueItems= new List<string>();
           
            ICollection<string> keys = uda.Keys;
            foreach (string key in keys)
            {
                keyItems.Add(key);
            }

            ICollection<string> values = uda.Values;
            foreach (string value in values)
            {
                valueItems.Add(value);
            }

            lvUDAResult.Columns[0].Text = "Key";
            lvUDAResult.Columns[1].Text = "Value";

            if (lvUDAResult.Items.Count > 0) lvUDAResult.Items.Clear();

            for (int i =0; i < keyItems.Count; i++)
            {
                ListViewItem listView = new ListViewItem(new string[] { keyItems[i], valueItems[i] });
                lvUDAResult.Items.Add(listView);
            }
        }

        private void btnUDAKeys_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            List<string> keys = vizcore3dx.Object3D.UDA.Keys;

            if (keys.Count == 0)
            {
                MessageBox.Show("UDA-Key is null", "Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lvUDAResult.Columns[0].Text = "Key";
            lvUDAResult.Columns[1].Text = "Value";

            if (lvUDAResult.Items.Count > 0) lvUDAResult.Items.Clear();

            for (int i = 0; i < keys.Count; i++)
            {
                ListViewItem listView = new ListViewItem(new string[] { keys[i] });
                lvUDAResult.Items.Add(listView);
            }
        }

        private void btnUDAValues_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string keyword = txtUDAKey.Text;

            if (String.IsNullOrEmpty(keyword) == true)
            {
                MessageBox.Show("Keyword is empty", "Keyword", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> values = vizcore3dx.Object3D.UDA.GetValues(keyword);

            if (values.Count == 0)
            {
                MessageBox.Show("UDA-Value is null", "Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lvUDAResult.Columns[0].Text = "Key";
            lvUDAResult.Columns[1].Text = "Value";

            if (lvUDAResult.Items.Count > 0) lvUDAResult.Items.Clear();

            for (int i = 0; i < values.Count; i++)
            {
                ListViewItem listView = new ListViewItem(new string[] { keyword , values[i] });
                lvUDAResult.Items.Add(listView);
            }
        }

        private void btnUDANodes_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string key = txtUDAKey1.Text;

            if (String.IsNullOrEmpty(key) == true)
            {
                MessageBox.Show("Keyword is empty", "Keyword", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string val = txtUDAValue1.Text;

            if (String.IsNullOrEmpty(val) == true)
            {
                MessageBox.Show("Keyword is empty", "Keyword", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.UDA.GetNodes(key, val);

            if (nodes.Count == 0)
            {
                MessageBox.Show("Node count is 0", "Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            lvUDAResult.Columns[0].Text = "EntityID";
            lvUDAResult.Columns[1].Text = "Index";

            if (lvUDAResult.Items.Count > 0) lvUDAResult.Items.Clear();

            for (int i = 0; i < nodes.Count; i++)
            {
                ListViewItem listView = new ListViewItem(new string[] { nodes[i].EntityID.ToString(), nodes[i].Index.ToString() });
                lvUDAResult.Items.Add(listView);
            }
        }
    }
}
