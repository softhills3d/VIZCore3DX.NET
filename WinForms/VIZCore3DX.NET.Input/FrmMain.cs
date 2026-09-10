using System;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.Input
{
    public partial class FrmMain : Form
    {
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        private readonly InputProfile defaultProfile = new InputProfile { Name = "기본 설정" };
        private readonly InputProfile precisionProfile = new InputProfile { Name = "정밀 조작" };
        private readonly InputProfile fastProfile = new InputProfile { Name = "빠른 탐색" };
        private readonly InputProfile userProfile = new InputProfile { Name = "사용자 설정" };
        private readonly InputProfile initialProfile = new InputProfile();

        public FrmMain()
        {
            InitializeComponent();

            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(vizcore3dx);

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
                MessageBox.Show(string.Format("라이선스 인증에 실패했습니다.\r\n라이선스 코드 : {0}", result), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 최초 Input 값을 기준으로 기본/정밀/빠른/사용자 프로필 구성
            vizcore3dx.Input.LoadDefault();
            initialProfile.CopyFrom(CaptureCurrentProfile("초기 설정"));
            ResetProfiles();

            cmbProfile.Items.AddRange(new object[] { defaultProfile, precisionProfile, fastProfile, userProfile });
            cmbProfile.SelectedItem = defaultProfile;
        }

        private void ResetProfiles()
        {
            defaultProfile.CopyFrom(initialProfile);

            precisionProfile.CopyFrom(initialProfile);
            precisionProfile.OrbitSensitivity *= 0.75;
            precisionProfile.PanSensitivity *= 0.75;
            precisionProfile.ZoomDragSensitivity *= 0.75;
            precisionProfile.RollSensitivity *= 0.75;
            precisionProfile.LookSensitivity *= 0.75;
            precisionProfile.WalkSpeedRatio *= 0.75;
            precisionProfile.FlySpeedRatio *= 0.75;

            fastProfile.CopyFrom(initialProfile);
            fastProfile.OrbitSensitivity *= 1.25;
            fastProfile.PanSensitivity *= 1.25;
            fastProfile.ZoomDragSensitivity *= 1.25;
            fastProfile.RollSensitivity *= 1.25;
            fastProfile.LookSensitivity *= 1.25;
            fastProfile.WalkSpeedRatio *= 1.25;
            fastProfile.WalkSpeedBoostScale *= 1.25;
            fastProfile.FlySpeedRatio *= 1.25;
            fastProfile.FlySpeedBoostScale *= 1.25;

            userProfile.CopyFrom(initialProfile);
        }

        private InputProfile CaptureCurrentProfile(string name)
        {
            InputProfile profile = new InputProfile();

            profile.Name = name;
            profile.Preset = vizcore3dx.Input.CurrentPreset;
            profile.OrbitSensitivity = vizcore3dx.Input.OrbitSensitivity;
            profile.PanSensitivity = vizcore3dx.Input.PanSensitivity;
            profile.ZoomDragSensitivity = vizcore3dx.Input.ZoomDragSensitivity;
            profile.RollSensitivity = vizcore3dx.Input.RollSensitivity;
            profile.LookSensitivity = vizcore3dx.Input.LookSensitivity;
            profile.WalkSpeedRatio = vizcore3dx.Input.WalkSpeedRatio;
            profile.WalkSpeedBoostScale = vizcore3dx.Input.WalkSpeedBoostScale;
            profile.FlySpeedRatio = vizcore3dx.Input.FlySpeedRatio;
            profile.FlySpeedBoostScale = vizcore3dx.Input.FlySpeedBoostScale;
            profile.ClickDuration = vizcore3dx.Input.ClickDuration;
            profile.LongPressDuration = vizcore3dx.Input.LongPressDuration;
            profile.ClickToleranceInPixels = vizcore3dx.Input.ClickToleranceInPixels;
            profile.IsWheelDirectionInverted = vizcore3dx.Input.IsWheelDirectionInverted;

            return profile;
        }

        private InputProfile CaptureControlProfile(string name)
        {
            InputProfile profile = new InputProfile();

            profile.Name = name;
            profile.Preset = (InputPreset)cmbPreset.SelectedItem;
            profile.OrbitSensitivity = (double)numOrbitSensitivity.Value;
            profile.PanSensitivity = (double)numPanSensitivity.Value;
            profile.ZoomDragSensitivity = (double)numZoomDragSensitivity.Value;
            profile.RollSensitivity = (double)numRollSensitivity.Value;
            profile.LookSensitivity = (double)numLookSensitivity.Value;
            profile.WalkSpeedRatio = (double)numWalkSpeedRatio.Value;
            profile.WalkSpeedBoostScale = (double)numWalkSpeedBoostScale.Value;
            profile.FlySpeedRatio = (double)numFlySpeedRatio.Value;
            profile.FlySpeedBoostScale = (double)numFlySpeedBoostScale.Value;
            profile.ClickDuration = TimeSpan.FromMilliseconds((double)numClickDuration.Value);
            profile.LongPressDuration = TimeSpan.FromMilliseconds((double)numLongPressDuration.Value);
            profile.ClickToleranceInPixels = (int)numClickTolerance.Value;
            profile.IsWheelDirectionInverted = chkWheelDirectionInverted.Checked;

            return profile;
        }

        private bool ApplyProfile(InputProfile profile)
        {
            if (profile == null) return false;

            // Custom은 저장된 사용자 정의 프리셋 API로 적용
            if (profile.Preset == InputPreset.Custom)
            {
                if (!vizcore3dx.Input.ApplyCustomPreset(userProfile.Name)) return false;
            }
            else vizcore3dx.Input.ApplyPreset(profile.Preset);

            vizcore3dx.Input.OrbitSensitivity = profile.OrbitSensitivity;
            vizcore3dx.Input.PanSensitivity = profile.PanSensitivity;
            vizcore3dx.Input.ZoomDragSensitivity = profile.ZoomDragSensitivity;
            vizcore3dx.Input.RollSensitivity = profile.RollSensitivity;
            vizcore3dx.Input.LookSensitivity = profile.LookSensitivity;
            vizcore3dx.Input.WalkSpeedRatio = profile.WalkSpeedRatio;
            vizcore3dx.Input.WalkSpeedBoostScale = profile.WalkSpeedBoostScale;
            vizcore3dx.Input.FlySpeedRatio = profile.FlySpeedRatio;
            vizcore3dx.Input.FlySpeedBoostScale = profile.FlySpeedBoostScale;
            vizcore3dx.Input.ClickDuration = profile.ClickDuration;
            vizcore3dx.Input.LongPressDuration = profile.LongPressDuration;
            vizcore3dx.Input.ClickToleranceInPixels = profile.ClickToleranceInPixels;
            vizcore3dx.Input.IsWheelDirectionInverted = profile.IsWheelDirectionInverted;

            return true;
        }

        private void LoadProfileToControls(InputProfile profile)
        {
            if (profile == null) return;

            cmbPreset.SelectedItem = profile.Preset;

            SetNumericValue(numOrbitSensitivity, profile.OrbitSensitivity);
            SetNumericValue(numPanSensitivity, profile.PanSensitivity);
            SetNumericValue(numZoomDragSensitivity, profile.ZoomDragSensitivity);
            SetNumericValue(numRollSensitivity, profile.RollSensitivity);
            SetNumericValue(numLookSensitivity, profile.LookSensitivity);
            SetNumericValue(numWalkSpeedRatio, profile.WalkSpeedRatio);
            SetNumericValue(numWalkSpeedBoostScale, profile.WalkSpeedBoostScale);
            SetNumericValue(numFlySpeedRatio, profile.FlySpeedRatio);
            SetNumericValue(numFlySpeedBoostScale, profile.FlySpeedBoostScale);
            SetNumericValue(numClickDuration, profile.ClickDuration.TotalMilliseconds);
            SetNumericValue(numLongPressDuration, profile.LongPressDuration.TotalMilliseconds);
            SetNumericValue(numClickTolerance, profile.ClickToleranceInPixels);

            chkWheelDirectionInverted.Checked = profile.IsWheelDirectionInverted;
        }

        private void SetNumericValue(NumericUpDown control, double value)
        {
            decimal number = (decimal)value;

            if (number < control.Minimum) number = control.Minimum;
            if (number > control.Maximum) number = control.Maximum;

            control.Value = number;
        }

        private void RefreshComparison()
        {
            InputProfile selectedProfile = cmbProfile.SelectedItem as InputProfile;
            if (selectedProfile == null) return;

            InputProfile currentProfile = CaptureCurrentProfile("현재 설정");
            string currentPreset = currentProfile.Preset == InputPreset.Custom ? vizcore3dx.Input.CurrentCustomPresetName : currentProfile.Preset.ToString();
            string profilePreset = selectedProfile.Preset == InputPreset.Custom ? selectedProfile.Name : selectedProfile.Preset.ToString();

            dgvComparison.Rows.Clear();

            AddComparisonRow("조작 프리셋", currentPreset, profilePreset);
            AddComparisonRow("회전 감도", currentProfile.OrbitSensitivity.ToString("0.###"), selectedProfile.OrbitSensitivity.ToString("0.###"));
            AddComparisonRow("화면 이동 감도", currentProfile.PanSensitivity.ToString("0.###"), selectedProfile.PanSensitivity.ToString("0.###"));
            AddComparisonRow("드래그 확대/축소 감도", currentProfile.ZoomDragSensitivity.ToString("0.###"), selectedProfile.ZoomDragSensitivity.ToString("0.###"));
            AddComparisonRow("화면 기울임 감도", currentProfile.RollSensitivity.ToString("0.###"), selectedProfile.RollSensitivity.ToString("0.###"));
            AddComparisonRow("시선 회전 감도", currentProfile.LookSensitivity.ToString("0.###"), selectedProfile.LookSensitivity.ToString("0.###"));
            AddComparisonRow("보행 속도 배율", currentProfile.WalkSpeedRatio.ToString("0.###"), selectedProfile.WalkSpeedRatio.ToString("0.###"));
            AddComparisonRow("보행 부스트 배율", currentProfile.WalkSpeedBoostScale.ToString("0.###"), selectedProfile.WalkSpeedBoostScale.ToString("0.###"));
            AddComparisonRow("비행 속도 배율", currentProfile.FlySpeedRatio.ToString("0.###"), selectedProfile.FlySpeedRatio.ToString("0.###"));
            AddComparisonRow("비행 부스트 배율", currentProfile.FlySpeedBoostScale.ToString("0.###"), selectedProfile.FlySpeedBoostScale.ToString("0.###"));
            AddComparisonRow("클릭 최대 시간", string.Format("{0:0} ms", currentProfile.ClickDuration.TotalMilliseconds), string.Format("{0:0} ms", selectedProfile.ClickDuration.TotalMilliseconds));
            AddComparisonRow("길게 누름 시간", string.Format("{0:0} ms", currentProfile.LongPressDuration.TotalMilliseconds), string.Format("{0:0} ms", selectedProfile.LongPressDuration.TotalMilliseconds));
            AddComparisonRow("클릭 이동 허용 거리", string.Format("{0} px", currentProfile.ClickToleranceInPixels), string.Format("{0} px", selectedProfile.ClickToleranceInPixels));
            AddComparisonRow("휠 방향 반전", currentProfile.IsWheelDirectionInverted ? "사용" : "사용 안 함", selectedProfile.IsWheelDirectionInverted ? "사용" : "사용 안 함");
        }

        private void AddComparisonRow(string name, string currentValue, string profileValue)
        {
            dgvComparison.Rows.Add(name, currentValue, profileValue, currentValue == profileValue ? "같음" : "변경");
        }

        private void cmbProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            InputProfile profile = cmbProfile.SelectedItem as InputProfile;
            if (profile == null) return;

            LoadProfileToControls(profile);
            RefreshComparison();
        }

        private void btnSaveUserProfile_Click(object sender, EventArgs e)
        {
            InputProfile profile = CaptureControlProfile(userProfile.Name);

            // 현재 UI 값을 먼저 실제 Input 설정에 적용
            if (!ApplyProfile(profile))
            {
                MessageBox.Show("사용자 정의 프리셋을 적용할 수 없습니다.", "VIZCore3DX.NET.Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // SaveCustomPreset은 현재 조작 바인딩을 저장하고 같은 이름이 있으면 덮어씀
            if (!vizcore3dx.Input.SaveCustomPreset(userProfile.Name))
            {
                MessageBox.Show("사용자 설정 저장에 실패했습니다.", "VIZCore3DX.NET.Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!vizcore3dx.Input.ApplyCustomPreset(userProfile.Name))
            {
                MessageBox.Show("저장한 사용자 설정을 적용하지 못했습니다.", "VIZCore3DX.NET.Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 감도/속도/입력 판정 값은 CustomPreset 바인딩과 별도로 예제 프로필에 유지
            profile.Preset = InputPreset.Custom;
            userProfile.CopyFrom(profile);

            cmbProfile.SelectedItem = userProfile;
            LoadProfileToControls(userProfile);
            RefreshComparison();
        }

        private void btnRestoreDefault_Click(object sender, EventArgs e)
        {
            // 저장된 예제용 사용자 CustomPreset까지 삭제하고 최초 값으로 복원
            if (vizcore3dx.Input.GetCustomPresetNames().Contains(userProfile.Name)) vizcore3dx.Input.DeleteCustomPreset(userProfile.Name);

            ResetProfiles();
            ApplyProfile(defaultProfile);

            cmbProfile.SelectedIndex = -1;
            cmbProfile.SelectedItem = defaultProfile;
        }

        private void btnApplyInputSetting_Click(object sender, EventArgs e)
        {
            if (!ApplyProfile(CaptureControlProfile("현재 설정")))
            {
                MessageBox.Show("적용할 사용자 정의 프리셋이 없습니다.", "VIZCore3DX.NET.Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RefreshComparison();
        }

        private sealed class InputProfile
        {
            public string Name { get; set; }
            public InputPreset Preset { get; set; }
            public double OrbitSensitivity { get; set; }
            public double PanSensitivity { get; set; }
            public double ZoomDragSensitivity { get; set; }
            public double RollSensitivity { get; set; }
            public double LookSensitivity { get; set; }
            public double WalkSpeedRatio { get; set; }
            public double WalkSpeedBoostScale { get; set; }
            public double FlySpeedRatio { get; set; }
            public double FlySpeedBoostScale { get; set; }
            public TimeSpan ClickDuration { get; set; }
            public TimeSpan LongPressDuration { get; set; }
            public int ClickToleranceInPixels { get; set; }
            public bool IsWheelDirectionInverted { get; set; }

            public void CopyFrom(InputProfile profile)
            {
                Preset = profile.Preset;
                OrbitSensitivity = profile.OrbitSensitivity;
                PanSensitivity = profile.PanSensitivity;
                ZoomDragSensitivity = profile.ZoomDragSensitivity;
                RollSensitivity = profile.RollSensitivity;
                LookSensitivity = profile.LookSensitivity;
                WalkSpeedRatio = profile.WalkSpeedRatio;
                WalkSpeedBoostScale = profile.WalkSpeedBoostScale;
                FlySpeedRatio = profile.FlySpeedRatio;
                FlySpeedBoostScale = profile.FlySpeedBoostScale;
                ClickDuration = profile.ClickDuration;
                LongPressDuration = profile.LongPressDuration;
                ClickToleranceInPixels = profile.ClickToleranceInPixels;
                IsWheelDirectionInverted = profile.IsWheelDirectionInverted;
            }
        }
    }
}
