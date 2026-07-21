using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.MiniView
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;
        private MiniViewDialog MiniViewDlg;
        private MiniViewControl MiniViewCtrl;

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            // license 인증
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            MiniViewDlg = new MiniViewDialog();
            MiniViewDlg.FormClosing += MiniViewDlg_FormClosing;

            MiniViewCtrl = new MiniViewControl();
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================
            // 라이선스 파일을 통한 인증
            //vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result =
                vizcore3dx.License.LicenseServer("192.168.100.252", 8901);

            // ================================================================
            // License
            // ================================================================
            // VIZCore3DX.NET.Data.LicenseResults result =
            //     vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");

            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(
                    string.Format("LICENSE CODE : {0}", result.ToString()),
                    "VIZCore3DX.NET",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

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

        private void MiniViewDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            MiniViewDlg.Hide();
            MiniViewDlg.ShowInTaskbar = false;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            ResetMiniView();
        }

        private void ckTopMost_CheckedChanged(object sender, EventArgs e)
        {
            // TopMost는 선택 노드와 관계없는 Dialog 속성이므로 바로 반영한다.
            if (MiniViewDlg == null || MiniViewDlg.IsDisposed == true) return;

            MiniViewDlg.TopMost = ckTopMost.Checked;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 로드해 주세요.");
                return;
            }

            List<VIZCore3DX.NET.Data.Node> items = new List<VIZCore3DX.NET.Data.Node>();

            if (rbSelected.Checked == true)
            {
                items = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);
            }
            else if (rbIndex.Checked == true)
            {
                if (String.IsNullOrWhiteSpace(txtIndex.Text) == true)
                {
                    MessageBox.Show("Node Index를 입력해 주세요.");
                    return;
                }

                int targetIndex;
                if (int.TryParse(txtIndex.Text.Trim(), out targetIndex) == false)
                {
                    MessageBox.Show("Node Index는 숫자로 입력해야 합니다.");
                    return;
                }

                List<VIZCore3DX.NET.Data.Node> allNodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.ALL);

                if (allNodes != null && allNodes.Count > 0)
                {
                    VIZCore3DX.NET.Data.Node node = allNodes.Find(n => n.Index == targetIndex);

                    if (node != null)
                        items.Add(node);
                }
            }

            if (items.Count == 0)
            {
                MessageBox.Show("MiniView에 표시할 노드가 없습니다.");
                return;
            }

            ResetMiniView();

            MiniViewCtrl = new MiniViewControl();
            MiniViewCtrl.Dock = DockStyle.Fill;
            MiniViewCtrl.Visible = true;

            // MiniViewManager는 표시할 노드 목록을 직접 받지 않음. 따라서 MiniView 표시 전에 대상 노드를 선택 상태로 만들어 둔다.
            vizcore3dx.Object3D.Select(items, true);

            if (rbDefault＿Dialog.Checked == true)
            {
                ShowMiniViewInDialog(CameraDirection.ISO_PLUS);
                return;
            }
            else if (rbEmbedded＿Panel.Checked == true)
            {
                MiniViewContainer.Controls.Clear();

                MiniViewCtrl.Dock = DockStyle.Fill;
                MiniViewCtrl.Visible = true;

                // MiniViewControl 내부에 있는 기본 Label/Text 컨트롤이 실제 MiniView ViewControl을 가릴 수 있으므로 비운다.
                MiniViewCtrl.Controls.Clear();

                MiniViewContainer.Controls.Add(MiniViewCtrl);

                MiniViewCtrl.CreateControl();

                // Handle 생성 보장
                IntPtr handle = MiniViewCtrl.Handle;

                // 컨테이너 레이아웃이 끝난 다음 MiniView 연결
                MiniViewContainer.BeginInvoke(new Action(() =>
                {
                    if (MiniViewCtrl == null || MiniViewCtrl.IsDisposed == true) return;

                    vizcore3dx.View.MiniView.SetMiniViewContainer(MiniViewCtrl, CameraDirection.ISO_PLUS);

                    // SetMiniViewContainer 내부에서 추가된 실제 ViewControl을 앞으로 올린다.
                    BringMiniViewInnerControlToFront();

                    vizcore3dx.View.MiniView.FitToView();

                    MiniViewCtrl.Invalidate(true);
                    MiniViewCtrl.Refresh();
                }));

                return;
            }
            else if (rbCustom＿Dialog.Checked == true)
            {
                ShowMiniViewInDialog(CameraDirection.Y_PLUS);
                return;
            }
            else if (rbInfo＿Panel.Checked == true)
            {
                vizcore3dx.InformationPanel.Controls.Clear();

                MiniViewCtrl.Dock = DockStyle.Fill;
                MiniViewCtrl.Visible = true;

                MiniViewCtrl.Controls.Clear();

                vizcore3dx.InformationPanel.Controls.Add(MiniViewCtrl);
                vizcore3dx.InformationPanel.Visible = true;
                vizcore3dx.InformationPanel.BringToFront();

                MiniViewCtrl.CreateControl();

                IntPtr handle = MiniViewCtrl.Handle;

                vizcore3dx.InformationPanel.BeginInvoke(new Action(() =>
                {
                    if (MiniViewCtrl == null || MiniViewCtrl.IsDisposed == true) return;

                    vizcore3dx.View.MiniView.SetMiniViewContainer(MiniViewCtrl, CameraDirection.ISO_PLUS);

                    BringMiniViewInnerControlToFront();

                    vizcore3dx.View.MiniView.FitToView();

                    MiniViewCtrl.Invalidate(true);
                    MiniViewCtrl.Refresh();
                }));

                return;
            }
        }

        private void ShowMiniViewInDialog(CameraDirection direction)
        {
            if (MiniViewDlg == null || MiniViewDlg.IsDisposed)
            {
                MiniViewDlg = new MiniViewDialog();
                MiniViewDlg.FormClosing += MiniViewDlg_FormClosing;
            }

            MiniViewDlg.Controls.Clear();

            MiniViewCtrl.Dock = DockStyle.Fill;
            MiniViewCtrl.Visible = true;

            // MiniViewControl 내부에 있는 "Mini View" Label 같은 기본 컨트롤이 실제 MiniView 화면을 가릴 수 있으므로 제거한다.
            MiniViewCtrl.Controls.Clear();

            MiniViewDlg.Controls.Add(MiniViewCtrl);

            MiniViewDlg.TopMost = ckTopMost.Checked;
            MiniViewDlg.ShowInTaskbar = false;

            // Dialog 크기 보정
            if (MiniViewDlg.Width < 400) MiniViewDlg.Width = 400;
            if (MiniViewDlg.Height < 400) MiniViewDlg.Height = 400;

            if (MiniViewDlg.Visible == false)
                MiniViewDlg.Show();
            else
                MiniViewDlg.BringToFront();

            MiniViewDlg.CreateControl();
            MiniViewCtrl.CreateControl();

            // Handle 생성 보장
            IntPtr dialogHandle = MiniViewDlg.Handle;
            IntPtr ctrlHandle = MiniViewCtrl.Handle;

            // Show 직후 바로 SetMiniViewContainer 하지 않고, UI 레이아웃이 끝난 다음 MiniView를 연결한다.
            MiniViewDlg.BeginInvoke(new Action(() =>
            {
                if (MiniViewCtrl == null || MiniViewCtrl.IsDisposed == true) return;

                vizcore3dx.View.MiniView.SetMiniViewContainer(MiniViewCtrl, direction);

                BringMiniViewInnerControlToFront();

                vizcore3dx.View.MiniView.FitToView();

                MiniViewCtrl.Invalidate(true);
                MiniViewCtrl.Refresh();
            }));
        }

        private void BringMiniViewInnerControlToFront()
        {
            if (MiniViewCtrl == null || MiniViewCtrl.IsDisposed == true) return;
            if (MiniViewCtrl.Controls.Count == 0) return;

            // SetMiniViewContainer 내부에서 마지막에 추가된 컨트롤이 실제 MiniView ViewControl일 가능성이 높다.
            Control view = MiniViewCtrl.Controls[MiniViewCtrl.Controls.Count - 1];

            view.Dock = DockStyle.Fill;
            view.Visible = true;
            view.BringToFront();
            view.Invalidate(true);
            view.Refresh();
        }

        private void ResetMiniView()
        {
            // Dialog 숨김
            if (MiniViewDlg != null && MiniViewDlg.IsDisposed == false)
            {
                if (MiniViewDlg.Visible == true)
                    MiniViewDlg.Hide();

                MiniViewDlg.Controls.Clear();
            }

            // InfoPanel 숨김
            if (vizcore3dx != null && vizcore3dx.InformationPanel != null)
            {
                vizcore3dx.InformationPanel.Visible = false;
                vizcore3dx.InformationPanel.Controls.Clear();
            }

            if (MiniViewContainer != null)
            {
                MiniViewContainer.Controls.Clear();

                if (vizcore3dx != null && vizcore3dx.InformationPanel != null)
                    vizcore3dx.InformationPanel.Visible = false;
            }

            // 컨트롤 상태 초기화
            if (MiniViewCtrl != null)
            {
                if (MiniViewCtrl.IsDisposed == false)
                {
                    if (MiniViewCtrl.Parent != null)
                    {
                        MiniViewCtrl.Parent.Controls.Remove(MiniViewCtrl);
                    }

                    MiniViewCtrl.Dispose();
                }

                MiniViewCtrl = null;
            }
        }
    }
}