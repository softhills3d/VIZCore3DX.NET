using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.Animation
{
    public partial class FrmMain : Form
    {
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        Data.Animation ani { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            cbFormat.SelectedIndex = 0;

            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

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
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("127.0.0.1", 8901);

            // ================================================================
            // License
            // ================================================================
            // VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");
            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeVIZCore3DX();
            InitializeVIZCore3DXEvent();
        }

        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.Animation.OnAnimationCreatedEvent += Animation_OnAnimationCreatedEvent;
            vizcore3dx.Animation.OnAnimationDeletedEvent += Animation_OnAnimationDeletedEvent;

            vizcore3dx.Animation.OnAnimationActivatedEvent += Animation_OnAnimationActivatedEvent;
            vizcore3dx.Animation.OnAnimationDeactivatedEvent += Animation_OnAnimationDeactivatedEvent;
            
            vizcore3dx.Animation.OnModelFileLoadedEvent += Animation_OnModelFileLoadedEvent;
            vizcore3dx.Animation.OnModelFileClosedEvent += Animation_OnModelFileClosedEvent;
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

            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }

        private void Animation_OnAnimationCreatedEvent(object sender, EventManager.AnimationEventArgs e)
        {
            Console.WriteLine($"OnAnimationCreatedEvent: Ani Count: {e.Animations.Count}");
            UpdateAnimationInfo();
        }

        private void Animation_OnAnimationDeletedEvent(object sender, EventManager.AnimationEventArgs e)
        {
            Console.WriteLine($"OnAnimationDeletedEvent: Ani Count: {e.Animations.Count}");
            UpdateAnimationInfo();
        }

        private void Animation_OnAnimationActivatedEvent(object sender, EventManager.AnimationEventArgs e)
        {
            Console.WriteLine($"OnAnimationActivatedEvent: Ani Count: {e.Animations.Count}");
            UpdateAnimationInfo();
        }

        private void Animation_OnAnimationDeactivatedEvent(object sender, EventManager.AnimationEventArgs e)
        {
            Console.WriteLine($"OnAnimationDeactivatedEvent: Ani Count: {e.Animations.Count}");
            UpdateAnimationInfo();
        }

        private void Animation_OnModelFileLoadedEvent(object sender, EventManager.AnimationEventArgs e)
        {
            Console.WriteLine($"OnModelFileLoadedEvent: Ani Count: {e.Animations.Count}");
            UpdateAnimationInfo();
        }

        private void Animation_OnModelFileClosedEvent(object sender, EventManager.AnimationEventArgs e)
        {
            Console.WriteLine($"OnModelFileClosedEvent: Ani Count: {e.Animations.Count}");

            // 모델을 닫으면 애니메이션 목록이 초기화되므로 보관 중인 참조도 해제
            ani = null;
            UpdateAnimationInfo();
        }

        /// <summary>
        /// 애니메이션 정보 표시 갱신
        /// </summary>
        private void UpdateAnimationInfo()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(UpdateAnimationInfo));
                return;
            }

            int count = vizcore3dx.Animation.Animations == null ? 0 : vizcore3dx.Animation.Animations.Count;
            if (ani == null || ani.IsValid == false)
                lblAnimationInfo.Text = string.Format("애니메이션 : 없음 (전체 {0}개)", count);
            else
                lblAnimationInfo.Text = string.Format("애니메이션 : {0} ({1:0.#}초){2}\n전체 {3}개", ani.Name, ani.Duration.TotalSeconds, ani.IsActive ? " - 활성" : "", count);
        }

        /// <summary>
        /// 사용 가능한 애니메이션 여부 확인
        /// </summary>
        /// <returns>사용 가능 여부</returns>
        private bool CheckAnimation()
        {
            if (ani != null && ani.IsValid) return true;

            MessageBox.Show("모델을 열어 애니메이션을 생성해 주세요.", "VIZCore3DX.NET.Animation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            vizcore3dx.Model.Open("primitiveCrane.vizx");

            // 애니메이션 생성
            CreateAnimation();
            UpdateAnimationInfo();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (CheckAnimation() == false) return;

            ani.Play();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (CheckAnimation() == false) return;

            ani.Pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (CheckAnimation() == false) return;

            ani.Stop();
        }

        // ================================================================
        // 내보내기 : PNG 프레임 시퀀스(ExportFrameSequenceAsync / StopFrameSequenceExport) 또는 MP4 동영상(StartRecordingWithWMF / StopRecording)
        // ================================================================

        /// <summary>
        /// 동영상 녹화 중 여부
        /// </summary>
        private bool isRecordingVideo = false;

        private bool IsPngFormat()
        {
            return cbFormat.SelectedIndex == 0;
        }

        private void cbFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFormatOptions(true);
        }

        /// <summary>
        /// 형식에 따라 PNG 전용 옵션(FPS, 파일 접두어, 출력 폴더) 사용 여부 변경
        /// </summary>
        /// <param name="enabled">내보내기 중이 아닐 때만 true</param>
        private void UpdateFormatOptions(bool enabled)
        {
            bool png = enabled && IsPngFormat();
            numFps.Enabled = png;
            txtFilePrefix.Enabled = png;
            btnOutputFolder.Enabled = png;
        }

        private void btnOutputFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (String.IsNullOrEmpty(txtOutputFolder.Text) == false) dlg.SelectedPath = txtOutputFolder.Text;

            if (dlg.ShowDialog() != DialogResult.OK) return;
            txtOutputFolder.Text = dlg.SelectedPath;
        }

        /// <summary>
        /// 내보내기 중 UI 상태 변경
        /// </summary>
        /// <param name="exporting">내보내기 중 여부</param>
        private void SetExporting(bool exporting)
        {
            btnExport.Enabled = !exporting;
            btnStopExport.Enabled = exporting;
            btnOpenModel.Enabled = !exporting;
            btnPlay.Enabled = !exporting;
            btnPause.Enabled = !exporting;
            btnStop.Enabled = !exporting;
            cbFormat.Enabled = !exporting;
            UpdateFormatOptions(!exporting);
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            if (CheckAnimation() == false) return;

            if (IsPngFormat())
                await ExportFrameSequence();
            else
                StartVideoRecording();
        }

        private async System.Threading.Tasks.Task ExportFrameSequence()
        {
            if (String.IsNullOrEmpty(txtOutputFolder.Text))
            {
                MessageBox.Show("출력 폴더를 선택해 주세요.", "VIZCore3DX.NET.Animation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string prefix = String.IsNullOrWhiteSpace(txtFilePrefix.Text) ? "frame" : txtFilePrefix.Text.Trim();
            int fps = (int)numFps.Value;

            // 출력 폴더 안에 내보내기 전용 폴더를 만들어 그 안에 PNG 파일 저장
            string folder = System.IO.Path.Combine(txtOutputFolder.Text, string.Format("{0}_{1:yyyyMMdd_HHmmss}", ani.Name, DateTime.Now));
            System.IO.Directory.CreateDirectory(folder);

            SetExporting(true);
            lblExportStatus.Text = string.Format("상태 : 내보내는 중... ({0} fps, 예상 {1}프레임)", fps, (int)Math.Ceiling(ani.Duration.TotalSeconds * fps));

            // 기본 진행창(Please Wait)이 3D 화면 위에 표시되면 캡처 이미지에 함께 저장되므로 내보내는 동안 비활성화
            bool enableProgressForm = vizcore3dx.EnableProgressForm;
            vizcore3dx.EnableProgressForm = false;

            int count = 0;
            try
            {
                // 애니메이션을 지정 fps로 재생하며 각 프레임을 PNG 파일로 저장 (반환값 : 저장된 프레임 수)
                count = await vizcore3dx.Animation.ExportFrameSequenceAsync(ani, folder, fps, prefix);
            }
            finally
            {
                vizcore3dx.EnableProgressForm = enableProgressForm;
                SetExporting(false);
            }

            VIZCore3DX.NET.Data.OperationStatus status = vizcore3dx.Animation.LastOperationStatus;
            if (count <= 0 || (status != null && status.IsFailure))
            {
                // 저장된 파일이 없으면 만든 폴더 삭제
                if (System.IO.Directory.GetFileSystemEntries(folder).Length == 0) System.IO.Directory.Delete(folder);

                lblExportStatus.Text = string.Format("상태 : 중지 또는 실패 ({0}프레임 저장)", count);
                MessageBox.Show(string.Format("프레임 시퀀스 내보내기가 중지되었거나 실패하였습니다.\n\n저장된 프레임 : {0}\n사유 : {1}", count, status == null ? "알 수 없음" : status.ToString()), "VIZCore3DX.NET.Animation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblExportStatus.Text = string.Format("상태 : 완료 ({0}프레임 저장)", count);
            MessageBox.Show(string.Format("프레임 시퀀스 내보내기 완료\n\n저장된 프레임 : {0}\n폴더 : {1}", count, folder), "VIZCore3DX.NET.Animation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void StartVideoRecording()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "MP4 (*.mp4)|*.mp4";
            dlg.FileName = string.Format("{0}.mp4", ani.Name);
            if (dlg.ShowDialog() != DialogResult.OK) return;

            // 재생 위치를 처음으로 되돌림
            ani.Stop();

            // WMF(Windows Media Foundation) 방식 녹화 : 별도 외부 도구(FFmpeg) 없이 MP4로 저장
            // 녹화 중 3D 화면 크기가 변경되면 녹화가 자동으로 중지됩니다.
            if (vizcore3dx.StartRecordingWithWMF(false, dlg.FileName) == false)
            {
                lblExportStatus.Text = "상태 : 녹화 시작 실패";
                return;
            }

            isRecordingVideo = true;
            SetExporting(true);
            lblExportStatus.Text = string.Format("상태 : 녹화 중... ({0:0.#}초)", ani.Duration.TotalSeconds);

            // 애니메이션 재생 : 끝에 도달하면 OnAnimationPausedEvent 에서 녹화 종료
            ani.Play();
        }

        private void btnStopExport_Click(object sender, EventArgs e)
        {
            if (isRecordingVideo)
            {
                ani.Pause();
                FinishVideoRecording(false);
                return;
            }

            // 프레임 시퀀스 내보내기 중지
            vizcore3dx.Animation.StopFrameSequenceExport();
            lblExportStatus.Text = "상태 : 중지 요청";
        }

        /// <summary>
        /// 동영상 녹화 종료
        /// </summary>
        /// <param name="completed">애니메이션 끝까지 녹화했는지 여부</param>
        private void FinishVideoRecording(bool completed)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(FinishVideoRecording), completed);
                return;
            }

            if (isRecordingVideo == false) return;
            isRecordingVideo = false;

            // 녹화 종료 및 MP4 파일 저장
            vizcore3dx.StopRecording();

            SetExporting(false);
            lblExportStatus.Text = completed ? "상태 : 저장 완료" : "상태 : 중지 (중지 시점까지 저장)";
        }

        private void CreateAnimation()
        {
            // Animation 은 여러 개 생성할 수 있습니다.
            ani = vizcore3dx.Animation.CreateAnimation("Animation1");
            if (ani == null)
            {
                VIZCore3DX.NET.Data.OperationStatus status = vizcore3dx.Animation.LastOperationStatus;
                MessageBox.Show(string.Format("애니메이션 생성에 실패하였습니다.\n\n사유 : {0}", status == null ? "알 수 없음" : status.ToString()), "VIZCore3DX.NET.Animation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ani.OnAnimationPlayedEvent += Ani_OnAnimationPlayedEvent;
            ani.OnAnimationPausedEvent += Ani_OnAnimationPausedEvent;           // 애니메이션을 플레이해서 끝에 도달할때도 콜백됩니다.
            ani.OnAnimationStoppedEvent += Ani_OnAnimationStoppedEvent;

            // 애니메이션의 총 길이
            ani.Duration = TimeSpan.FromSeconds(28.0);

            // 애니메이션 활성화는 1개만 가능합니다.
            // 애니메이션이 활성화 되면, 3D뷰의 외곽선이 파란색에서 황토색으로 변경됩니다.
            ani.Activate();

            // Animation 은 여러 개의 그룹을 가질 수 있으며, 그룹은 계층적으로 구성할 수 있습니다.
            // 그룹에 노드를 0개 이상 추가할 수 있습니다.
            // 액션은 그룹에 추가할 수 있으며, 그룹에 추가된 노드에 적용되고, 하위 그룹에도 액션이 적용됩니다.
            AnimationGroup craneGroup = ani.CreateGroup("Crane");

            AnimationGroup chassisGroup = craneGroup.CreateGroup("Chassis");
            AnimationGroup craneJibGroup = craneGroup.CreateGroup("Crane Jib");

            AnimationGroup boomGroup = craneJibGroup.CreateGroup("Boom");
            AnimationGroup boom1Group = boomGroup.CreateGroup("Boom1");
            AnimationGroup boom2Group = boom1Group.CreateGroup("Boom2");
            AnimationGroup boom3Group = boom2Group.CreateGroup("Boom3");
            AnimationGroup hookGroup = boom3Group.CreateGroup("Hook");

            AnimationGroup tankGroup = ani.CreateGroup("Tank");

            // 생성한 그룹의 계층 구조는 다음과 같습니다.
            //
            // Animation1
            // ├─ Crane
            // │  ├─ Chassis
            // │  └─ CraneJib
            // │     └─ Boom
            // │        └─ Boom1
            // │           └─ Boom2
            // │              └─ Boom3
            // │                 └─ Hook
            // └─ Tank

            // Chassis 그룹에 노드를 추가
            {
                Data.Node cabinNode = vizcore3dx.Object3D.Find.QuickSearch("Cabin", true, false, false, true).FirstOrDefault();
                Data.Node wheelsNode = vizcore3dx.Object3D.Find.QuickSearch("Wheels", true, false, false, true).FirstOrDefault();
                Data.Node chassisNode = vizcore3dx.Object3D.Find.QuickSearch("Chassis", true, false, false, true).FirstOrDefault();

                chassisGroup.AddNode(cabinNode);
                chassisGroup.AddNode(wheelsNode);
                chassisGroup.AddNode(chassisNode);
            }

            // Crane Jib 그룹에 노드를 추가
            {
                Data.Node turretNode = vizcore3dx.Object3D.Find.QuickSearch("Turret", true, false, false, true).FirstOrDefault();
                Data.Node SlewingBaseNode = vizcore3dx.Object3D.Find.QuickSearch("Slewing Base", true, false, false, true).FirstOrDefault();

                craneJibGroup.AddNode(turretNode);
                craneJibGroup.AddNode(SlewingBaseNode);
            }

            // Boom1 그룹에 노드를 추가
            {
                Data.Node boomSection1Node = vizcore3dx.Object3D.Find.QuickSearch("Boom Section 1", true, false, false, true).FirstOrDefault();

                boom1Group.AddNode(boomSection1Node);
            }

            // Boom2 그룹에 노드를 추가
            {
                Data.Node boomSection2Node = vizcore3dx.Object3D.Find.QuickSearch("Boom Section 2", true, false, false, true).FirstOrDefault();

                boom2Group.AddNode(boomSection2Node);
            }

            // Boom3 그룹에 노드를 추가
            {
                Data.Node boomSection3Node = vizcore3dx.Object3D.Find.QuickSearch("Boom Section 3", true, false, false, true).FirstOrDefault();
                Data.Node boomHeadNode = vizcore3dx.Object3D.Find.QuickSearch("Boom Head", true, false, false, true).FirstOrDefault();

                boom3Group.AddNode(boomSection3Node);
                boom3Group.AddNode(boomHeadNode);
            }

            // Hook 그룹에 노드를 추가
            {
                Data.Node hookNode = vizcore3dx.Object3D.Find.QuickSearch("Hook", true, false, false, true).FirstOrDefault();

                hookGroup.AddNode(hookNode);
            }

            // Tank 그룹에 노드를 추가
            {
                Data.Node tankNode = vizcore3dx.Object3D.Find.QuickSearch("Tank", true, false, false, true).FirstOrDefault();
                tankGroup.AddNode(tankNode);
            }

            // Crane 그룹에 액션을 추가
            {
                // 0초에서 2초 동안, (-1, 0, 0) 방향으로 20000mm 이동하는 액션
                craneGroup.CreateTranslationAction(TimeSpan.FromSeconds(0.0), TimeSpan.FromSeconds(2.0), new Vector3D(-1, 0, 0), 20000);

                // 0초에서 2초 동안, 회전의 중심이 (633, 0, 2897)이고, 회전의 축이 (0, 0, 1)인 회전축에 대해서 -90도 회전하는 액션
                craneGroup.CreateRotationAction(TimeSpan.FromSeconds(0.0), TimeSpan.FromSeconds(2.0), new Vector3D(633, 0, 2897), new Vector3D(0, 0, 1), Deg2Rad(-90.0f));
            }

            // Crane Jib 그룹에 액션을 추가
            {
                // 3초에서 1초 동안, 회전의 중심이 (1061, 29, 2200)이고, 회전의 축이 (0, 0, 1)인 회전축에 대해서 90도 회전하는 액션
                craneJibGroup.CreateRotationAction(TimeSpan.FromSeconds(3.0), TimeSpan.FromSeconds(1.0), new Vector3D(1061, 29, 2200), new Vector3D(0, 0, 1), Deg2Rad(90.0f));

                // 20초에서 1초 동안, 회전의 중심이 (1043, -58, 2200)이고, 회전의 축이 (0, 0, 1)인 회전축에 대해서 -90도 회전하는 액션
                craneJibGroup.CreateRotationAction(TimeSpan.FromSeconds(20.0), TimeSpan.FromSeconds(1.0), new Vector3D(1043, -58, 2200), new Vector3D(0, 0, 1), Deg2Rad(-90.0f));
            }

            // Boom 그룹에 액션을 추가
            {
                // 10초에서 2초 동안, 회전의 중심이 (936, -1000, 1810)이고, 회전의 축이 (0, -1, 0)인 회전축에 대해서 -30도 회전하는 액션
                boomGroup.CreateRotationAction(TimeSpan.FromSeconds(10.0), TimeSpan.FromSeconds(2.0), new Vector3D(936, -1000, 1810), new Vector3D(0, -1, 0), Deg2Rad(-30.0f));
            }

            // Boom2 그룹에 액션을 추가
            {
                // 5초에서 2초 동안, (0.71, 0, 0.71) 방향으로 3000mm 이동하는 액션. 붐을 뽑는 동작.
                boom2Group.CreateTranslationAction(TimeSpan.FromSeconds(5.0), TimeSpan.FromSeconds(2.0), new Vector3D(0.71, 0, 0.71), 3000);
            }

            // Boom3 그룹에 액션을 추가
            {
                // 0초에서 28초 동안, 붐 끝부분과 Hook 사이를 선으로 그림
                AnimationWireAction wireAction = boom3Group.CreateWireAction(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(28.0), hookGroup);
                wireAction.AddWire(new Vector3D(5227, 6, 5544), new Vector3D(5146, -3, 4756));

                // 7초에서 2초 동안, (0.71, 0, 0.71) 방향으로 2000mm 이동하는 액션. 붐을 뽑는 동작.
                boom3Group.CreateTranslationAction(TimeSpan.FromSeconds(7.0), TimeSpan.FromSeconds(2.0), new Vector3D(0.71, 0, 0.71), 2000);
            }

            // Hook 그룹에 액션을 추가
            {
                // 10초에서 2초 동안, 회전의 중심이 (5087, -200, 5594)이고, 회전의 축이 (0, -1, 0)인 회전축에 대해서 30도 회전하는 액션
                hookGroup.CreateRotationAction(TimeSpan.FromSeconds(10.0), TimeSpan.FromSeconds(2.0), new Vector3D(5087, -200, 5594), new Vector3D(0, -1, 0), Deg2Rad(30.0f));

                // 13초에서 2초 동안, (0, 0, -1) 방향으로 1000mm 이동하는 액션. 후크가 탱크를 향해 내려가는 동작.
                hookGroup.CreateTranslationAction(TimeSpan.FromSeconds(13.0), TimeSpan.FromSeconds(2.0), new Vector3D(0, 0, -1), 1000);

                // 16초에서 8초 동안, 후크와 텡크 사이를 선으로 그림
                AnimationWireAction wireAction = hookGroup.CreateWireAction(TimeSpan.FromSeconds(16), TimeSpan.FromSeconds(8.0), tankGroup);
                wireAction.AddWire(new Vector3D(5092, -95, 4555), new Vector3D(-3000, 10800, 1550));
                wireAction.AddWire(new Vector3D(5218, -77, 4542), new Vector3D(-1049, 10874, 1550));
                wireAction.AddWire(new Vector3D(5205, 92, 4536), new Vector3D(-1039, 13181, 1550));
                wireAction.AddWire(new Vector3D(5067, 77, 4557), new Vector3D(-2969, 13159, 1550));

                // 17초에서 7초 동안, 후크와 탱크를 연결. 후크 그룹을 이동하면 탱크도 함께 이동합니다.
                hookGroup.CreateLinkAction(TimeSpan.FromSeconds(17), TimeSpan.FromSeconds(7.0), tankGroup);

                // 17초에서 2초 동안, (0, 0, 1) 방향으로 1000mm 이동하는 액션. 후크가 탱크를 들어 올리는 동작.
                hookGroup.CreateTranslationAction(TimeSpan.FromSeconds(17.0), TimeSpan.FromSeconds(2.0), new Vector3D(0, 0, 1), 1000);

                // 22초에서 2초 동안, (0, 0, -1) 방향으로 1000mm 이동하는 액션. 후크가 탱크를 내려 놓는 동작.
                hookGroup.CreateTranslationAction(TimeSpan.FromSeconds(22.0), TimeSpan.FromSeconds(2.0), new Vector3D(0, 0, -1), 1000);

                // 25초에서 2초 동안, (0, 0, 1) 방향으로 1000mm 이동하는 액션. 후크가 다시 당겨지는 동작.
                hookGroup.CreateTranslationAction(TimeSpan.FromSeconds(25.0), TimeSpan.FromSeconds(2.0), new Vector3D(0, 0, 1), 1000);
            }

            // Tank 그룹에 액션 추가
            {
                // 16초에서 색상을 노란색으로 변경. 후크와 연결된 시점에 탱크 색상이 변경되는 효과.
                // 투명도는 -1로 설정하여 변경하지 않도록 합니다.
                // 만약 색상은 그대로 두고 투명도만 변경하려면, 색상의 RGB는 -1로 설정하고, 투명도만 0~255 사이의 값으로 설정하면 됩니다.
                tankGroup.CreateColorAlphaAction(TimeSpan.FromSeconds(16), new Color4n(255, 255, 0, -1));

                // 24초에서 색상을 원상복구. 후크와 연결이 해제되는 시점에 탱크 색상이 원래대로 돌아오는 효과.
                tankGroup.CreateColorAlphaAction(TimeSpan.FromSeconds(24), new Color4n(-1, -1, -1, -1));

                // 27초에서 탱크를 안보이게 함. 탱크가 원하는 위치에 놓인 후, 탱크가 사라지는 효과.
                tankGroup.CreateVisibilityAction(TimeSpan.FromSeconds(27), false);
            }
        }

        private void Ani_OnAnimationPlayedEvent(object sender, EventManager.AnimationPlaybackEventArgs e)
        {
            Console.WriteLine($"OnAnimationPlayedEvent: Ani name: {e.Animation.Name}");
        }

        private void Ani_OnAnimationPausedEvent(object sender, EventManager.AnimationPlaybackEventArgs e)
        {
            Console.WriteLine($"OnAnimationPausedEvent: Ani name: {e.Animation.Name}");

            // 동영상 녹화 중 애니메이션이 끝에 도달하면 녹화 종료
            if (isRecordingVideo && e.Animation.IsPlaybackCompleted)
                FinishVideoRecording(true);
        }

        private void Ani_OnAnimationStoppedEvent(object sender, EventManager.AnimationPlaybackEventArgs e)
        {
            Console.WriteLine($"OnAnimationStoppedEvent: Ani name: {e.Animation.Name}");
        }

        public float Deg2Rad(float degree)
        {
            return degree * (float)Math.PI / 180.0f;
        }

        // 지정한 탭만 남기고 나머지 툴바(=리본 탭)와 모델 트리 패널의 같은 탭을 숨깁니다. 홈 탭·모델 트리는 항상 표시합니다.
        private void ShowRibbonTabs(params VIZCore3DX.NET.Data.ToolbarKind[] keep)
        {
            foreach (VIZCore3DX.NET.Data.ToolbarKind kind in Enum.GetValues(typeof(VIZCore3DX.NET.Data.ToolbarKind)))
                vizcore3dx.Toolbar.SetVisible(kind, kind == VIZCore3DX.NET.Data.ToolbarKind.Main || Array.IndexOf(keep, kind) >= 0);

            vizcore3dx.TabSnapshotEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Snapshot) >= 0;
            vizcore3dx.TabNotetEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Note) >= 0;
            vizcore3dx.TabMeasureEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Measure) >= 0;
            vizcore3dx.TabSectionEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Section) >= 0;
            vizcore3dx.TabDecalEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Decal) >= 0;
            vizcore3dx.TabSelectionBoxEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.SelectionBox) >= 0;
            vizcore3dx.TabZoneEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Zone) >= 0;
            vizcore3dx.TabEffectEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Effect) >= 0;
            vizcore3dx.TabObserverEnabled = Array.IndexOf(keep, VIZCore3DX.NET.Data.ToolbarKind.Observer) >= 0;
        }

        // 속성 패널은 노드 특성·노드 속성만 기본으로 남기고, 예제가 다루는 탭만 켭니다.
        private void ShowAttributeTabs(bool attributeTree = false, bool nodeGroup = false, bool projection = false, bool pmi = false)
        {
            vizcore3dx.TabAttributeTreeEnabled = attributeTree;
            vizcore3dx.TabNodeGroupEnabled = nodeGroup;
            vizcore3dx.TabProjectionEnabled = projection;
            vizcore3dx.TabPmiEnabled = pmi;
            vizcore3dx.TabEnvironmentEnabled = false;
            vizcore3dx.TabGenericDataEnabled = false;
            vizcore3dx.AttributePanelVisible = attributeTree || nodeGroup || projection || pmi;
        }
    }
}
