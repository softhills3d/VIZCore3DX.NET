using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIZCore3DX.NET.License;

namespace VIZCore3DX.NET.SubView
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// VIZCore3DX
        /// </summary>
        public VIZCore3DX.NET.Core VIZCore { get; private set; }

        internal List<ViewControl> SubViewCtrls = new List<ViewControl>(3);

        /// <summary>
        /// View Control
        /// </summary>
        public ViewControl View { get; set; }

        /// <summary>
        /// Scene Tree Control
        /// </summary>
        public SceneTreeControl Scene { get; set; }

        public FrmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load; // 폼 로드 이벤트 핸들러 등록
            this.Disposed += FrmMain_Disposed; // 폼 해제 이벤트 핸들러 등록
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 코어
            VIZCore = new Core();

            splitViews.Panel2Collapsed = true;
            splitLeftViews.Panel2Collapsed = true;
            splitRightViews.Panel2Collapsed = true;

            // 뷰 컨트롤
            View = new ViewControl();
            View.Dock = DockStyle.Fill;
            View.Initialize(VIZCore);
            splitLeftViews.Panel1.Controls.Add(View);

            for (int i = 0; i < 3; i++)
                SubViewCtrls.Add(null);

            // 씬 트리 컨트롤
            Scene = new SceneTreeControl();
            Scene.Dock = DockStyle.Fill;
            Scene.Initialize(VIZCore);
            this.splitContainerMain.Panel1.Controls.Add(Scene);

            // 모델 트리 닫기
            splitContainerMain.Panel1Collapsed = true;

            VIZCore.Settings.Load();

            LicenseCheck();
        }

        private void LicenseCheck()
        {
            // 라이선스: File
            //VIZCore3DX.NET.License.AuthenticationResult result =
            //    VIZCore.AuthenticateLicenseByFile("C:\\License\\VIZCore3DX.NET.lic");

            // 라이선스: Server
            //VIZCore3DX.NET.License.AuthenticationResult result = VIZCore.AuthenticateLicenseByServer("127.0.0.1", 8901);

            VIZCore3DX.NET.License.AuthenticationResult result = VIZCore.AuthenticateLicenseByFile(@"C:\License\20240611_DM파트.lic");

            if (result != VIZCore3DX.NET.License.AuthenticationResult.Success)
            {
                MessageBox.Show(string.Format("Error Code = {0}", result), "License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMain_Disposed(object sender, EventArgs e)
        {
            if (VIZCore != null)
                VIZCore.Dispose();
        }

        private void btnModelOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "VIZX File (*.vizx)|*.vizx";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            VIZCore.OpenFile(dlg.FileName);
        }

        private void btnModelTree_Click(object sender, EventArgs e)
        {
            if (splitContainerMain.Panel1Collapsed)
            {
                splitContainerMain.Panel1Collapsed = false;
            }
            else
            {
                splitContainerMain.Panel1Collapsed = true;
            }
        }

        #region SubView

        private void btnView1_Click(object sender, EventArgs e)
        {
            SplitView(1);
        }

        private void btnView2_Click(object sender, EventArgs e)
        {
            SplitView(2);
        }

        private void btnView3_Click(object sender, EventArgs e)
        {
            SplitView(3);
        }

        private void btnView4_Click(object sender, EventArgs e)
        {
            SplitView(4);
        }

        private void SplitView(int viewCount)
        {
            int subViewCount = 0;
            if (viewCount == 1)
            {
                splitViews.Panel2Collapsed = true;
                splitLeftViews.Panel2Collapsed = true;
                splitRightViews.Panel2Collapsed = true;

                subViewCount = 0;
            }
            else if (viewCount == 2)
            {
                splitViews.Panel2Collapsed = false;
                splitLeftViews.Panel2Collapsed = true;
                splitRightViews.Panel2Collapsed = true;

                splitViews.SplitterDistance = splitViews.Width / 2;

                subViewCount = 1;
            }
            else if (viewCount == 3)
            {
                splitViews.Panel2Collapsed = false;
                splitLeftViews.Panel2Collapsed = true;
                splitRightViews.Panel2Collapsed = false;

                splitViews.SplitterDistance = splitViews.Width / 2;
                splitRightViews.SplitterDistance = splitRightViews.Height / 2;

                subViewCount = 2;
            }
            else if (viewCount == 4)
            {
                splitViews.Panel2Collapsed = false;
                splitLeftViews.Panel2Collapsed = false;
                splitRightViews.Panel2Collapsed = false;

                splitViews.SplitterDistance = splitViews.Width / 2;
                splitRightViews.SplitterDistance = splitRightViews.Height / 2;
                splitLeftViews.SplitterDistance = splitLeftViews.Height / 2;

                subViewCount = 3;
            }

            while (subViewCount < VIZCore.SubViews.Count)
                DeleteSubViewControl(VIZCore.SubViews.Count - 1);

            while (subViewCount > VIZCore.SubViews.Count)
                CreateSubViewControl(VIZCore.SubViews.Count);

            VIZCore.StartRenderViews();
        }

        private void DeleteSubViewControl(int index)
        {
            if (index < 0 || index > 2)
                return;

            var subViewControl = SubViewCtrls[index];

            if (index == 0)
                splitRightViews.Panel1.Controls.Remove(subViewControl);
            else if (index == 1)
                splitRightViews.Panel2.Controls.Remove(subViewControl);
            else
                splitLeftViews.Panel2.Controls.Remove(subViewControl);

            subViewControl.Dispose();
            SubViewCtrls[index] = null;
            VIZCore.DeleteSubView(index);
        }

        private void CreateSubViewControl(int index)
        {
            if (index < 0 || index > 2)
                return;

            var subView = VIZCore.CreateSubView();

            var subViewControl = new ViewControl();
            subViewControl.Dock = DockStyle.Fill;
            subViewControl.Initialize(subView);
            SubViewCtrls[index] = subViewControl;

            subView.Lock();

            if (index == 0)
            {
                splitRightViews.Panel1.Controls.Add(subViewControl);
                VIZCore.SubViews[index].Camera.Initialize(CameraDirection.Top);
            }
            else if (index == 1)
            {
                splitRightViews.Panel2.Controls.Add(subViewControl);
                VIZCore.SubViews[index].Camera.Initialize(CameraDirection.Right);
            }
            else
            {
                splitLeftViews.Panel2.Controls.Add(subViewControl);
                VIZCore.SubViews[index].Camera.Initialize(CameraDirection.Front);
            }

            subView.Unlock();
        }
        #endregion


        #region Camera
        private void btnCameraISO_Click(object sender, EventArgs e)
        {
            VIZCore.ActiveView.Camera.Initialize(CameraDirection.ISO);
        }

        private void btnCameraX1_Click(object sender, EventArgs e)
        {
            VIZCore.ActiveView.Camera.Initialize(CameraDirection.Right);
        }

        private void btnCameraX2_Click(object sender, EventArgs e)
        {
            VIZCore.ActiveView.Camera.Initialize(CameraDirection.Left);
        }

        private void btnCameraY1_Click(object sender, EventArgs e)
        {
            VIZCore.ActiveView.Camera.Initialize(CameraDirection.Back);
        }

        private void btnCameraY2_Click(object sender, EventArgs e)
        {
            VIZCore.ActiveView.Camera.Initialize(CameraDirection.Front);
        }

        private void btnCameraZ1_Click(object sender, EventArgs e)
        {
            VIZCore.ActiveView.Camera.Initialize(CameraDirection.Top);
        }

        private void btnCameraZ2_Click(object sender, EventArgs e)
        {
            VIZCore.ActiveView.Camera.Initialize(CameraDirection.Bottom);
        }

        #endregion
    }
}
