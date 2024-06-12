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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using VIZCore3DX.NET.Markup;

namespace VIZCore3DX.NET.Note
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// VIZCore3DX
        /// </summary>
        public VIZCore3DX.NET.Core VIZCore { get; private set; }

        /// <summary>
        /// View Control
        /// </summary>
        public ViewControl View { get; set; }

        /// <summary>
        /// Scene Tree Control
        /// </summary>
        public SceneTreeControl Scene { get; set; }

        /// <summary>
        /// Note Control
        /// </summary>
        public NoteControl Note { get; set; }

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
            VIZCore.Settings.Load();

            // 뷰 컨트롤
            View = new ViewControl();
            View.Dock = DockStyle.Fill;
            splitContainerMain.Panel2.Controls.Add(View);
            View.Initialize(VIZCore);

            // 씬 트리 컨트롤
            Scene = new SceneTreeControl();
            Scene.Dock = DockStyle.Fill;
            tabControlMain.TabPages[0].Controls.Add(Scene);
            Scene.Initialize(VIZCore);

            // 노트 컨트롤
            Note = new NoteControl();
            Note.Dock = DockStyle.Fill;
            tabControlMain.TabPages[1].Controls.Add(Note);
            Note.Initialize(VIZCore);

            // 모델 트리 닫기
            splitContainerMain.Panel1Collapsed = true;

            LicenseCheck();
        }

        private void LicenseCheck()
        {
            // 라이선스: File
            //VIZCore3DX.NET.License.AuthenticationResult result =
            //    VIZCore.AuthenticateLicenseByFile("C:\\License\\VIZCore3DX.NET.lic");

            // 라이선스: Server
            VIZCore3DX.NET.License.AuthenticationResult result = VIZCore.AuthenticateLicenseByServer("127.0.0.1", 8901);

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

        #region Create
        private void btnSurfaceNote_Click(object sender, EventArgs e)
        {
            var dlg = new SurfaceNoteDialog();
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
                VIZCore.ReviewManager.CreateReview(ReviewType.NoteSurface, dlg.NoteText);
            else if (dlgResult == DialogResult.Retry) // 모델 선택
                VIZCore.ReviewManager.CreateReview(ReviewType.NoteSurface, String.Empty);
        }

        private void btnNote2D_Click(object sender, EventArgs e)
        {
            var dlg = new EditNoteDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                VIZCore.ReviewManager.CreateReview(ReviewType.Note2D, dlg.NoteText);
        }

        private void btnNote3D_Click(object sender, EventArgs e)
        {
            var dlg = new EditNoteDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                VIZCore.ReviewManager.CreateReview(ReviewType.Note3D, dlg.NoteText);
        }
        #endregion


        #region Show
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            VIZCore.ReviewManager.ShowReviews(VIZCore.ReviewManager.Notes, true);
        }

        private void btnHideAll_Click(object sender, EventArgs e)
        {
            VIZCore.ReviewManager.ShowReviews(VIZCore.ReviewManager.Notes, false);
        }

        private void btnShowSelection_Click(object sender, EventArgs e)
        {
            VIZCore.ReviewManager.ShowReviews(VIZCore.ReviewManager.Notes.Where(n => n.IsSelected == true), true);
        }

        private void btnHideSelection_Click(object sender, EventArgs e)
        {
            VIZCore.ReviewManager.ShowReviews(VIZCore.ReviewManager.Notes.Where(n => n.IsSelected == true), false);
        }

        private void btnShowNonSelection_Click(object sender, EventArgs e)
        {
            VIZCore.ReviewManager.ShowReviews(VIZCore.ReviewManager.Notes.Where(n => n.IsSelected == false), true);
        }

        private void btnHideNonSelection_Click(object sender, EventArgs e)
        {
            VIZCore.ReviewManager.ShowReviews(VIZCore.ReviewManager.Notes.Where(n => n.IsSelected == false), false);
        }
        #endregion

        #region Delete
        private void btnDeleteSelection_Click(object sender, EventArgs e)
        {
            VIZCore.ReviewManager.DeleteReviews(VIZCore.ReviewManager.Notes.Where(r => r.IsSelected));
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            VIZCore.ReviewManager.DeleteReviews(VIZCore.ReviewManager.Notes);
        }
        #endregion
    }
}
