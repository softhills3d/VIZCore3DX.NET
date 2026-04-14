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
            vizcore3dx.ToolbarMain.Visible = true;
            //vizcore3dx.ToolbarNote.Visible = false;
            //vizcore3dx.ToolbarMeasure.Visible = false;
            //vizcore3dx.ToolbarSection.Visible = false;
            //vizcore3dx.ToolbarSnapshot.Visible = false;

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }

        private void Animation_OnAnimationCreatedEvent(object sender, EventManager.AnimationEventArgs e)
        {
            Console.WriteLine($"OnAnimationCreatedEvent: Ani Count: {e.Animations.Count}");
        }

        private void Animation_OnAnimationDeletedEvent(object sender, EventManager.AnimationEventArgs e)
        {
            Console.WriteLine($"OnAnimationDeletedEvent: Ani Count: {e.Animations.Count}");
        }

        private void Animation_OnAnimationActivatedEvent(object sender, EventManager.AnimationEventArgs e)
        {
            Console.WriteLine($"OnAnimationActivatedEvent: Ani Count: {e.Animations.Count}");
        }

        private void Animation_OnAnimationDeactivatedEvent(object sender, EventManager.AnimationEventArgs e)
        {
            Console.WriteLine($"OnAnimationDeactivatedEvent: Ani Count: {e.Animations.Count}");
        }

        private void Animation_OnModelFileLoadedEvent(object sender, EventManager.AnimationEventArgs e)
        {
            Console.WriteLine($"OnModelFileLoadedEvent: Ani Count: {e.Animations.Count}");
        }

        private void Animation_OnModelFileClosedEvent(object sender, EventManager.AnimationEventArgs e)
        {
            Console.WriteLine($"OnModelFileClosedEvent: Ani Count: {e.Animations.Count}");
        }

        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            vizcore3dx.Model.Open("primitiveCrane.vizx");

            // 애니메이션 생성
            CreateAnimation();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            ani.Play();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            ani.Pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ani.Stop();
        }

        private void CreateAnimation()
        {
            // Animation 은 여러 개 생성할 수 있습니다.
            ani = vizcore3dx.Animation.CreateAnimation("Animation1");

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
        }

        private void Ani_OnAnimationStoppedEvent(object sender, EventManager.AnimationPlaybackEventArgs e)
        {
            Console.WriteLine($"OnAnimationStoppedEvent: Ani name: {e.Animation.Name}");
        }

        public float Deg2Rad(float degree)
        {
            return degree * (float)Math.PI / 180.0f;
        }
    }
}
