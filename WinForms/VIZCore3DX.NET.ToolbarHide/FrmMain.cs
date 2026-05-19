using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;
using VIZCore3DX.NET.Manager;
using static VIZCore3DX.NET.Manager.SectionManager;

namespace VIZCore3DX.NET.ToolbarHide
{
    public partial class FrmMain : Form
    {
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        public VIZCore3DX.NET.Data.SectionItem Section { get; set; }

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
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");

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
            vizcore3dx.ToolbarDecal.Visible = false;
            vizcore3dx.ToolbarPrimitive.Visible = false;

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();

            AddToolbar();
        }

        private void InitializeVIZCore3DXEvent()
        {
            
        }

        private void AddToolbar()
        {
            cbToolbarList.Items.Clear();
            cbToolbarList.Items.Add("ToolbarMain");
            cbToolbarList.Items.Add("ToolbarNote");
            cbToolbarList.Items.Add("ToolbarMeasure");
            cbToolbarList.Items.Add("ToolbarSection");
            cbToolbarList.Items.Add("ToolbarSnapshot");
            cbToolbarList.Items.Add("ToolbarDecal");
            cbToolbarList.Items.Add("ToolbarPrimitive");

            if (cbToolbarList.Items.Count > 0)
                cbToolbarList.SelectedIndex = 0;

            lvToolbar.View = View.Details;
            lvToolbar.FullRowSelect = true;
            lvToolbar.MultiSelect = true;
            lvToolbar.Columns.Add("Name", 175);
            lvToolbar.Columns.Add("Type", 95);
            lvToolbar.Columns.Add("Visible", 55);
        }

        private System.Windows.Forms.ToolStrip GetToolbar(string name)
        {
            switch (name)
            {
                case "ToolbarMain":      return vizcore3dx.ToolbarMain;
                case "ToolbarNote":      return vizcore3dx.ToolbarNote;
                case "ToolbarMeasure":   return vizcore3dx.ToolbarMeasure;
                case "ToolbarSection":   return vizcore3dx.ToolbarSection;
                case "ToolbarSnapshot":  return vizcore3dx.ToolbarSnapshot;
                case "ToolbarDecal":     return vizcore3dx.ToolbarDecal;
                case "ToolbarPrimitive": return vizcore3dx.ToolbarPrimitive;
                default:                 return null;
            }
        }

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

        private void btnGetToolbarList_Click(object sender, EventArgs e)
        {
            lvToolbar.Items.Clear();

            string selected = cbToolbarList.SelectedItem as string;
            if (string.IsNullOrEmpty(selected)) return;

            System.Windows.Forms.ToolStrip toolbar = GetToolbar(selected);
            if (toolbar == null) return;

            foreach (ToolStripItem item in toolbar.Items)
            {
                ListViewItem lvi = new ListViewItem(item.Name);
                lvi.SubItems.Add(item.GetType().Name);
                lvi.SubItems.Add(item.Visible.ToString());
                lvi.Tag = Tuple.Create<string, string>(null, item.Name);
                lvToolbar.Items.Add(lvi);

                ToolStripDropDownButton dropDown = item as ToolStripDropDownButton;
                if (dropDown != null)
                {
                    foreach (ToolStripItem subItem in dropDown.DropDownItems)
                    {
                        ListViewItem subLvi = new ListViewItem("  └ " + subItem.Name);
                        subLvi.SubItems.Add(subItem.GetType().Name);
                        subLvi.SubItems.Add(subItem.Visible.ToString());
                        subLvi.Tag = Tuple.Create(dropDown.Name, subItem.Name);
                        lvToolbar.Items.Add(subLvi);
                    }
                }
            }
        }

        // Tag에 저장된 (부모명, 아이템명) 키로 ToolStripItem을 Name 기반으로 조회
        private ToolStripItem FindToolStripItem(System.Windows.Forms.ToolStrip toolbar, Tuple<string, string> key)
        {
            if (key.Item1 == null)
                return toolbar.Items[key.Item2];

            ToolStripDropDownButton parent = toolbar.Items[key.Item1] as ToolStripDropDownButton;
            if (parent == null) return null;

            return parent.DropDownItems[key.Item2];
        }

        private void SetSelectedItemsVisible(bool visible)
        {
            string selected = cbToolbarList.SelectedItem as string;
            if (string.IsNullOrEmpty(selected)) return;

            System.Windows.Forms.ToolStrip toolbar = GetToolbar(selected);
            if (toolbar == null) return;

            foreach (ListViewItem lvi in lvToolbar.SelectedItems)
            {
                Tuple<string, string> key = lvi.Tag as Tuple<string, string>;
                if (key == null) continue;

                ToolStripItem item = FindToolStripItem(toolbar, key);
                if (item == null) continue;

                item.Visible = visible;
                lvi.SubItems[2].Text = visible.ToString();
            }
        }

        private void btnToolbarShow_Click(object sender, EventArgs e)
        {
            SetSelectedItemsVisible(true);
        }

        private void btnToolbarHide_Click(object sender, EventArgs e)
        {
            SetSelectedItemsVisible(false);
        }
    }
}
