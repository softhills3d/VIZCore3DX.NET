using System;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.Explode
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;
        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            //License
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

            // 모델 로드
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
            vizcore3dx.ToolbarSection.Visible = true;
            vizcore3dx.ToolbarSnapshot.Visible = false;
            vizcore3dx.ToolbarDecal.Visible = false;
            vizcore3dx.ToolbarPrimitive.Visible = false;


            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            int groupLevel = cbGroupLevel.SelectedIndex;
            if (groupLevel < 0) return;

            // 분해도가 활성화된 상태에서는 기존 그룹 구성이 유지되므로, 조립 상태로 복원 후 비활성화하고 그룹을 다시 생성
            DeactivateExplode();
            vizcore3dx.Object3D.Group.ClearGroup();

            if (groupLevel >= 0 && groupLevel < 5) vizcore3dx.Object3D.Group.CreateFlatGroups((uint)groupLevel);
            else if (groupLevel >= 5 && groupLevel < 9) vizcore3dx.Object3D.Group.CreateHierarchicalGroups((uint)(groupLevel - 5));
            // 전체 계층 : leaf assembly 기준으로 모든 상위 계층을 그룹으로 생성 (maxGroupDepth = -1)
            else if (groupLevel == 9) vizcore3dx.Object3D.Group.CreateHierarchicalGroups(-1);
        }

        private void btnClearGroup_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            DeactivateExplode();
            vizcore3dx.Object3D.Group.ClearGroup();
        }

        private void btnRestoreAll_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            DeactivateExplode();
        }

        /// <summary>
        /// 분해 이전 상태로 복원하고 분해도 비활성화 (다음 Explode 시 현재 그룹 구성으로 다시 Activate)
        /// </summary>
        private void DeactivateExplode()
        {
            if (vizcore3dx.Object3D.Explode.IsAnimating == true) return;
            if (vizcore3dx.Object3D.Explode.IsActive == false) return;

            vizcore3dx.Object3D.Explode.Restore();
            vizcore3dx.Object3D.Explode.Deactivate(true);
        }

        private void btnExplode_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            if (vizcore3dx.Object3D.Explode.IsAnimating == true) return;   // 애니메이션 진행 중 중복 실행 방지

            float explodeProgress, distanceRatio, leveldistanceDecay;
            if (float.TryParse(txtExplodeProgress.Text, out explodeProgress) == false          // 0.0 ~ 1.0 사이 값. 0.0은 분해 전 상태, 1.0은 완전 분해 상태.
                || float.TryParse(txtDistanceRatio.Text, out distanceRatio) == false           // 0.0 ~ 4.0 사이 값.  값이 클수록 여러 계층의 노드 그룹이 비슷한 거리만큼 분해됨.
                || float.TryParse(txtLevelDistanceDecay.Text, out leveldistanceDecay) == false) // 0.0 ~ 1.0 사이 값. 값이 작을수록 하위 계층의 분해 거리가 빠르게 감쇠.
            {
                MessageBox.Show("숫자 값을 입력하세요.");
                return;
            }

            if (explodeProgress < 0.0f || explodeProgress > 1.0f)
            {
                MessageBox.Show("0.0 ~ 1.0 사이 값을 입력하세요.");
                return;
            }
            if (distanceRatio < 0.0f || distanceRatio > 4.0f)
            {
                MessageBox.Show("0.0 ~ 4.0 사이 값을 입력하세요.");
                return;
            }
            if (leveldistanceDecay < 0.0f || leveldistanceDecay > 1.0f)
            {
                MessageBox.Show("0.0 ~ 1.0 사이 값을 입력하세요.");
                return;
            }

            vizcore3dx.Object3D.Explode.ExplodeProgress = explodeProgress;

            Vector3D vector;
            switch (cbAxis.Text)
            {
                case "X+":
                    vector = new Vector3D(1.0f, 0.0f, 0.0f);
                    break;

                case "X-":
                    vector = new Vector3D(-1.0f, 0.0f, 0.0f);
                    break;

                case "Y+":
                    vector = new Vector3D(0.0f, 1.0f, 0.0f);
                    break;

                case "Y-":
                    vector = new Vector3D(0.0f, -1.0f, 0.0f);
                    break;

                case "Z+":
                    vector = new Vector3D(0.0f, 0.0f, 1.0f);
                    break;

                case "Z-":
                    vector = new Vector3D(0.0f, 0.0f, -1.0f);
                    break;

                case "XYZ":
                    vector = new Vector3D(1.0f, 1.0f, 1.0f);
                    break;

                default:
                    vector = new Vector3D(0.0f, 0.0f, 1.0f);
                    break;
            }

            Data.ExplodeSetting explodeSetting = new Data.ExplodeSetting
            {
                Direction = vector,
                DistanceRatio = distanceRatio,
                LevelDistanceDecay = leveldistanceDecay,
                Mode = Data.ExplodeMode.Directional
            };

            // ExplodeProgress 값에서 완전 분해(1.0) 상태까지 애니메이션
            vizcore3dx.Object3D.Explode.AnimateExplodeDirectional(explodeProgress, 1f, 1.5f, vector, explodeSetting, false);
        }
    }
}
