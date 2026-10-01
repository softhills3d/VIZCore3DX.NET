using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Environment
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        // 컨트롤 값을 코드에서 바꾸는 동안 핸들러가 뷰어에 되돌려 쓰지 않도록 막습니다.
        private bool _syncing;

        public FrmMain()
        {
            InitializeComponent();

            // 뷰어와 무관한 콤보 항목은 생성자에서 채웁니다. 채우는 동안은 핸들러가 뷰어를 건드리지 않습니다.
            _syncing = true;
            cmbSkyPreset.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.EnvironmentSkyPreset));
            cmbGroundPreset.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.EnvironmentGroundPreset));
            _syncing = false;

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // ================================================================
            // Example
            // ================================================================

            // 라이선스 파일을 통한 인증
            //VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("127.0.0.1", 8901);

            // ================================================================
            // License
            // ================================================================

            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeVIZCore3DX();
        }

        private void InitializeVIZCore3DX()
        {
            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs();
            ShowAttributeTabs();

            // 환경 설정은 속성 패널에 전용 탭이 있으므로 이 예제에서는 그 탭을 켜서 내장 UI 와 나란히 비교할 수 있게 합니다.
            vizcore3dx.TabEnvironmentEnabled = true;
            vizcore3dx.AttributePanelVisible = true;

            ReadToControls();
            SetStatus("모델을 열고 [환경 켜기]를 체크하세요.");
        }

        #region 1. 모델
        // 환경 렌더링은 모델 없이도 켜지지만, 지면·수면 높이는 모델이 있어야 비교할 수 있습니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (!vizcore3dx.Model.OpenFileDialog()) return;

            SetStatus("모델을 열었습니다. [환경 켜기]를 체크한 뒤 하늘·지면 프리셋을 바꿔 보세요.");
        }
        #endregion

        #region 2. 환경
        // 환경 렌더링 전체를 켜고 끕니다. 아래 하늘·지면·수면·그림자는 이 값이 켜져 있을 때만 보입니다.
        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.Environment.Enabled = chkEnabled.Checked;
            SetStatus(chkEnabled.Checked ? "환경 렌더링을 켰습니다." : "환경 렌더링을 껐습니다.");
        }

        // 하늘 파노라마 표시 여부
        private void chkSky_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.Environment.SkyEnabled = chkSky.Checked;
        }

        // 하늘 프리셋(맑음·약간 흐림·흐림·석양). 사용자 파노라마가 지정돼 있으면 프리셋으로 되돌립니다.
        private void cmbSkyPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.Environment.SkyPreset = (VIZCore3DX.NET.Data.EnvironmentSkyPreset)cmbSkyPreset.SelectedItem;
            ReadTextureFiles();
        }

        // 지면(지형 텍스처) 표시 여부
        private void chkGround_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.Environment.GroundEnabled = chkGround.Checked;
        }

        // 지면 프리셋(사막·초원·암반 …). 사용자 텍스처가 지정돼 있으면 프리셋으로 되돌립니다.
        private void cmbGroundPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.Environment.GroundPreset = (VIZCore3DX.NET.Data.EnvironmentGroundPreset)cmbGroundPreset.SelectedItem;
            ReadTextureFiles();
        }

        // 지면을 지평선까지 확장할지 여부
        private void chkGroundExtend_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.Environment.GroundExtendEnabled = chkGroundExtend.Checked;
        }

        // 접지 그림자 표시 여부
        private void chkShadow_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.Environment.ShadowEnabled = chkShadow.Checked;
        }
        #endregion

        #region 3. 지면·수면
        // 바닥 평면(격자·접지 그림자·지형)의 Z 높이
        private void numFloorHeight_ValueChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.Environment.FloorHeight = (float)numFloorHeight.Value;
        }

        // 바닥 격자 표시 여부
        private void chkFloorGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.Environment.FloorGridEnabled = chkFloorGrid.Checked;
        }

        // 격자 선 색
        private void btnGridLineColor_Click(object sender, EventArgs e)
        {
            if (!PickColor(btnGridLineColor)) return;

            vizcore3dx.View.Environment.GridLineColor = btnGridLineColor.BackColor;
        }

        // 격자 면 색
        private void btnGridFaceColor_Click(object sender, EventArgs e)
        {
            if (!PickColor(btnGridFaceColor)) return;

            vizcore3dx.View.Environment.GridFaceColor = btnGridFaceColor.BackColor;
        }

        // 수면 표시 여부
        private void chkWater_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.Environment.WaterEnabled = chkWater.Checked;
        }

        // 쉐이더 수면(물결 효과) 사용 여부
        private void chkShaderWater_CheckedChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.Environment.ShaderWaterEnabled = chkShaderWater.Checked;
        }

        // 수면의 Z 높이
        private void numWaterHeight_ValueChanged(object sender, EventArgs e)
        {
            if (_syncing) return;

            vizcore3dx.View.Environment.WaterHeight = (float)numWaterHeight.Value;
        }
        #endregion

        #region 4. 사용자 텍스처
        // 지면 프리셋 대신 사용자 이미지 파일을 지형 텍스처로 씁니다.
        private void btnGroundTexture_Click(object sender, EventArgs e)
        {
            string file = PickImageFile("지면 텍스처 이미지 선택");
            if (file == null) return;

            bool result = vizcore3dx.View.Environment.SetGroundTexture(file);
            ReadTextureFiles();
            SetStatus(result ? "지면 텍스처를 바꿨습니다." : "지면 텍스처를 적용하지 못했습니다.");
        }

        // 하늘 프리셋 대신 사용자 파노라마 이미지를 하늘로 씁니다.
        private void btnSkyPanorama_Click(object sender, EventArgs e)
        {
            string file = PickImageFile("하늘 파노라마 이미지 선택");
            if (file == null) return;

            bool result = vizcore3dx.View.Environment.SetSkyPanorama(file);
            ReadTextureFiles();
            SetStatus(result ? "하늘 파노라마를 바꿨습니다." : "하늘 파노라마를 적용하지 못했습니다.");
        }
        #endregion

        #region 5. 정리
        // 내장 환경 탭 등 다른 경로로 바뀐 값을 컨트롤에 다시 읽어 옵니다.
        private void btnRead_Click(object sender, EventArgs e)
        {
            ReadToControls();
            SetStatus("현재 환경 설정을 읽어 왔습니다.");
        }

        // 환경 렌더링을 끕니다. 개별 설정값은 그대로 남습니다.
        private void btnDisable_Click(object sender, EventArgs e)
        {
            vizcore3dx.View.Environment.Enabled = false;
            ReadToControls();
            SetStatus("환경 렌더링을 껐습니다.");
        }
        #endregion

        #region Helpers
        private void SetStatus(string message)
        {
            lblStatus.Text = message;
        }

        // 뷰어의 현재 환경 설정을 컨트롤에 반영합니다.
        private void ReadToControls()
        {
            VIZCore3DX.NET.Manager.EnvironmentManager env = vizcore3dx.View.Environment;

            _syncing = true;
            try
            {
                chkEnabled.Checked = env.Enabled;
                chkSky.Checked = env.SkyEnabled;
                cmbSkyPreset.SelectedItem = env.SkyPreset;
                chkGround.Checked = env.GroundEnabled;
                cmbGroundPreset.SelectedItem = env.GroundPreset;
                chkGroundExtend.Checked = env.GroundExtendEnabled;
                chkShadow.Checked = env.ShadowEnabled;

                numFloorHeight.Value = Clamp(numFloorHeight, env.FloorHeight);
                chkFloorGrid.Checked = env.FloorGridEnabled;
                btnGridLineColor.BackColor = env.GridLineColor;
                btnGridFaceColor.BackColor = env.GridFaceColor;
                chkWater.Checked = env.WaterEnabled;
                chkShaderWater.Checked = env.ShaderWaterEnabled;
                numWaterHeight.Value = Clamp(numWaterHeight, env.WaterHeight);

                ReadTextureFiles();
            }
            finally
            {
                _syncing = false;
            }
        }

        // 사용자 텍스처 파일 경로를 표시합니다. 프리셋 사용 중이면 null 이 돌아옵니다.
        private void ReadTextureFiles()
        {
            lblGroundFile.Text = "지면: " + (vizcore3dx.View.Environment.GroundTextureFile ?? "(프리셋)");
            lblSkyFile.Text = "하늘: " + (vizcore3dx.View.Environment.SkyPanoramaFile ?? "(프리셋)");
        }

        // float 값을 NumericUpDown 범위 안의 decimal 로 바꿉니다. NaN 이면 0 으로 둡니다.
        private static decimal Clamp(NumericUpDown control, float value)
        {
            if (float.IsNaN(value) || float.IsInfinity(value)) return 0;

            decimal d = (decimal)value;
            return Math.Max(control.Minimum, Math.Min(control.Maximum, d));
        }

        // 색 선택 대화상자를 띄워 버튼 배경색으로 반영합니다. 취소하면 false 입니다.
        private bool PickColor(Button button)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = button.BackColor;
                dialog.FullOpen = true;
                if (dialog.ShowDialog(this) != DialogResult.OK) return false;

                button.BackColor = dialog.Color;
                return true;
            }
        }

        // 이미지 파일 선택 대화상자. 취소하면 null 입니다.
        private string PickImageFile(string title)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = title;
                dialog.Filter = "이미지 파일 (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|모든 파일 (*.*)|*.*";
                return dialog.ShowDialog(this) == DialogResult.OK ? dialog.FileName : null;
            }
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
        #endregion
    }
}
