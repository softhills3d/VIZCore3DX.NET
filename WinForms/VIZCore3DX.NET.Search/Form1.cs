using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Search
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// VIZCore3DX.NET Control
        /// </summary>
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        public Form1()
        {
            InitializeComponent();

            // VIZCore3DX Module Init
            VIZCore3DX.NET.ModuleInitializer.Run();
            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3D_OnInitializedVIZCore3D;

            // Panel Control Add
            splitContainer1.Panel2.Controls.Add(vizcore3dx);
        }

        private void VIZCore3D_OnInitializedVIZCore3D(object sender, EventArgs e)
        {
            // 라이선스 서버를 통한 인증
            vizcore3dx.License.LicenseServer("192.168.0.215", 8901);

            InitializeVIZCore3DXEvent();
        }

        /// <summary>
        /// VIZCore3DX.NET 전역 이벤트 초기화
        /// </summary>
        private void InitializeVIZCore3DXEvent()
        {
            
        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            vizcore3dx.ShowWaitForm("Searching...", "Searching...");

            List<string> keyword = new List<string>();
            keyword.Add(txtKeyword1.Text.Trim());

            List<Data.Node> nodes = vizcore3dx.Object3D.Find.QuickSearch
            (keyword
              , false /* Join Condition : True - And, False - Or */
              , false /* True : Assembly Only, False : Assembly + Part */
              , true /* True : Visible Only, False : All Node */
              , false /* True : Selected Object, False : All Node */
              , false /* True : Full Match, False : Contains */
            );

            vizcore3dx.Object3D.Select(nodes, true);

            lvResult1.Items.Clear();

            lvResult1.BeginUpdate();
            foreach (VIZCore3DX.NET.Data.Node item in nodes)
            {
                ListViewItem lvi = new ListViewItem(new string[] { item.Index.ToString(), item.EntityID.ToString(), item.NodeName });
                lvResult1.Items.Add(lvi);
            }
            lvResult1.EndUpdate();

            vizcore3dx.CloseWaitForm();
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            vizcore3dx.ShowWaitForm("Searching...", "Searching...");

            List<string> keyword = new List<string>();
            keyword.Add("*OBST*");
            keyword.Add("*INSU*");

            List<Data.Node> nodes = vizcore3dx.Object3D.Find.QuickSearch
            (keyword
              , false /* Join Condition : True - And, False - Or */
              , false /* True : Assembly Only, False : Assembly + Part */
              , true /* True : Visible Only, False : All Node */
              , false /* True : Selected Object, False : All Node */
              , false /* True : Full Match, False : Contains */
            );

            vizcore3dx.Object3D.Select(nodes, true);

            lvResult2.Items.Clear();

            lvResult2.BeginUpdate();
            foreach (VIZCore3DX.NET.Data.Node item in nodes)
            {
                ListViewItem lvi = new ListViewItem(new string[] { item.Index.ToString(), item.EntityID.ToString(), item.NodeName });
                lvResult2.Items.Add(lvi);
            }
            lvResult2.EndUpdate();

            vizcore3dx.CloseWaitForm();
        }
    }
}
