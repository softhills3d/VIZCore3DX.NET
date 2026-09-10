using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.Effect
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
            splitContainer1.Panel1.Controls.Add(vizcore3dx);

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
                MessageBox.Show(string.Format("라이선스 인증에 실패했습니다.\r\n라이선스 코드 : {0}", result), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            vizcore3dx.BeginUpdate();

            vizcore3dx.ToolbarMain.Visible = true;
            vizcore3dx.ToolbarNote.Visible = false;
            vizcore3dx.ToolbarMeasure.Visible = false;
            vizcore3dx.ToolbarSection.Visible = false;
            vizcore3dx.ToolbarSnapshot.Visible = false;

            vizcore3dx.EndUpdate();

            vizcore3dx.View.Effect.OnEffectAddedEvent += Effect_OnEffectAddedEvent;
            vizcore3dx.View.Effect.OnEffectRemovedEvent += Effect_OnEffectRemovedEvent;

            RefreshEffectList();
            RefreshEffectStatus();
        }

        private bool CheckModel()
        {
            if (vizcore3dx.Model.IsOpen()) return true;

            MessageBox.Show("먼저 모델을 열어주세요.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        private void SetNumber(NumericUpDown control, decimal minimum, decimal maximum, decimal value, int decimalPlaces)
        {
            control.Minimum = minimum;
            control.Maximum = maximum;
            control.DecimalPlaces = decimalPlaces;
            control.Increment = decimalPlaces == 0 ? 1.0M : 0.1M;

            if (value < minimum) value = minimum;
            if (value > maximum) value = maximum;

            control.Value = value;
        }

        private void cmbEffectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvPoints.Items.Clear();
            lblCreateResult.Text = "생성 결과 : -";

            foreach (Control control in groupBoxOptions.Controls) control.Visible = false;

            cmbSpecial.Items.Clear();
            lblColor.Text = "색상";

            switch (cmbEffectType.SelectedIndex)
            {
                case 0:
                    DimensionLineOptions dimensionOptions = new DimensionLineOptions();

                    lblColor.Visible = btnEffectColor.Visible = true;
                    btnEffectColor.BackColor = dimensionOptions.Color;

                    lblOption1.Visible = numOption1.Visible = true;
                    lblOption1.Text = "선 두께";
                    SetNumber(numOption1, 0.1M, 20.0M, (decimal)dimensionOptions.LineWidth, 1);

                    lblOption2.Visible = numOption2.Visible = true;
                    lblOption2.Text = "소수점 자릿수";
                    SetNumber(numOption2, 0, 6, dimensionOptions.Decimals, 0);

                    chkOption1.Visible = true;
                    chkOption1.Text = "거리 문자열 표시";
                    chkOption1.Checked = dimensionOptions.ShowText;

                    chkOption2.Visible = true;
                    chkOption2.Text = "항상 위에 표시";
                    chkOption2.Checked = dimensionOptions.AlwaysOnTop;
                    break;

                case 1:
                    GasCloudOptions gasOptions = new GasCloudOptions();

                    lblColor.Visible = btnEffectColor.Visible = true;
                    btnEffectColor.BackColor = gasOptions.Color;

                    lblOption1.Visible = numOption1.Visible = true;
                    lblOption1.Text = "시작 반경(mm)";
                    SetNumber(numOption1, 1.0M, 1000000.0M, (decimal)gasOptions.MinRadius, 1);

                    lblOption2.Visible = numOption2.Visible = true;
                    lblOption2.Text = "최대 반경(mm)";
                    SetNumber(numOption2, 1.0M, 1000000.0M, (decimal)gasOptions.MaxRadius, 1);

                    lblOption3.Visible = numOption3.Visible = true;
                    lblOption3.Text = "불투명도";
                    SetNumber(numOption3, 0.0M, 1.0M, (decimal)gasOptions.Opacity, 2);
                    break;

                case 2:
                    GroundRingOptions groundRingOptions = new GroundRingOptions();

                    lblColor.Visible = btnEffectColor.Visible = true;
                    btnEffectColor.BackColor = groundRingOptions.Color;

                    lblOption1.Visible = numOption1.Visible = true;
                    lblOption1.Text = "반지름(mm)";
                    SetNumber(numOption1, 1.0M, 1000000.0M, (decimal)groundRingOptions.RadiusMm, 1);

                    lblOption2.Visible = numOption2.Visible = true;
                    lblOption2.Text = "선 굵기(px)";
                    SetNumber(numOption2, 0.1M, 20.0M, (decimal)groundRingOptions.LineWidth, 1);

                    lblOption3.Visible = numOption3.Visible = true;
                    lblOption3.Text = "물결 개수";
                    SetNumber(numOption3, 0, 20, groundRingOptions.RippleCount, 0);

                    chkOption1.Visible = true;
                    chkOption1.Text = "바닥까지 수직선 표시";
                    chkOption1.Checked = groundRingOptions.ShowStem;

                    chkOption2.Visible = true;
                    chkOption2.Text = "항상 위에 표시";
                    chkOption2.Checked = groundRingOptions.AlwaysOnTop;
                    break;

                case 3:
                    DataSetOptions lineSetOptions = new DataSetOptions();

                    lblColor.Visible = btnEffectColor.Visible = true;
                    btnEffectColor.BackColor = lineSetOptions.Color;

                    lblOption1.Visible = numOption1.Visible = true;
                    lblOption1.Text = "선 굵기(px)";
                    SetNumber(numOption1, 0.1M, 20.0M, (decimal)lineSetOptions.LineWidth, 1);

                    lblOption2.Visible = numOption2.Visible = true;
                    lblOption2.Text = "불투명도";
                    SetNumber(numOption2, 0.0M, 1.0M, (decimal)lineSetOptions.Opacity, 2);

                    chkOption1.Visible = true;
                    chkOption1.Text = "항상 위에 표시";
                    chkOption1.Checked = lineSetOptions.AlwaysOnTop;

                    lblSpecial.Visible = cmbSpecial.Visible = true;
                    lblSpecial.Text = "연결 방식";
                    cmbSpecial.Items.AddRange(new object[] { "연속 폴리라인", "점 2개씩 선분" });
                    cmbSpecial.SelectedIndex = 0;
                    break;

                case 4:
                    MarkerOptions markerOptions = new MarkerOptions();

                    lblOption1.Visible = numOption1.Visible = true;
                    lblOption1.Text = "아이콘 크기(px)";
                    SetNumber(numOption1, 1, 512, markerOptions.SizePx, 0);

                    lblOption2.Visible = numOption2.Visible = true;
                    lblOption2.Text = "페이드 시작 거리(mm)";
                    SetNumber(numOption2, 0.0M, 10000000.0M, (decimal)markerOptions.FadeStartMm, 1);

                    lblOption3.Visible = numOption3.Visible = true;
                    lblOption3.Text = "페이드 종료 거리(mm)";
                    SetNumber(numOption3, 0.0M, 10000000.0M, (decimal)markerOptions.FadeEndMm, 1);

                    chkOption1.Visible = true;
                    chkOption1.Text = "항상 위에 표시";
                    chkOption1.Checked = markerOptions.AlwaysOnTop;

                    chkOption2.Visible = true;
                    chkOption2.Text = "화면 밖 방향 표시";
                    chkOption2.Checked = markerOptions.ShowOffscreenIndicator;

                    lblSpecial.Visible = cmbSpecial.Visible = true;
                    lblSpecial.Text = "마커 아이콘";
                    cmbSpecial.Items.AddRange(new object[] { "경고", "금지", "정보", "화기", "가스/유증기", "확인" });
                    cmbSpecial.SelectedIndex = 0;

                    lblOptionText.Visible = txtOptionText.Visible = true;
                    lblOptionText.Text = "라벨";
                    txtOptionText.Text = string.Empty;
                    break;

                case 5:
                    ParticleOptions particleOptions = new ParticleOptions(ParticlePreset.Smoke);

                    lblColor.Visible = btnEffectColor.Visible = true;
                    lblColor.Text = "시작 색상";
                    btnEffectColor.BackColor = particleOptions.StartColor;

                    lblOption1.Visible = numOption1.Visible = true;
                    lblOption1.Text = "파티클 크기(mm)";
                    SetNumber(numOption1, 1.0M, 1000000.0M, (decimal)particleOptions.ParticleSizeMm, 1);

                    lblOption2.Visible = numOption2.Visible = true;
                    lblOption2.Text = "원뿔 반각(도)";
                    SetNumber(numOption2, 0.0M, 180.0M, (decimal)particleOptions.ConeAngleDeg, 1);

                    lblSpecial.Visible = cmbSpecial.Visible = true;
                    lblSpecial.Text = "프리셋";
                    cmbSpecial.Items.AddRange(new object[] { "불똥", "연기", "증기", "물방울" });
                    cmbSpecial.SelectedIndex = 1;
                    break;

                case 6:
                    PathLineOptions pathLineOptions = new PathLineOptions();

                    lblColor.Visible = btnEffectColor.Visible = true;
                    btnEffectColor.BackColor = pathLineOptions.Color;

                    lblOption1.Visible = numOption1.Visible = true;
                    lblOption1.Text = "선 두께(px)";
                    SetNumber(numOption1, 0.1M, 20.0M, (decimal)pathLineOptions.LineWidth, 1);

                    lblOption2.Visible = numOption2.Visible = true;
                    lblOption2.Text = "패턴 길이(mm)";
                    SetNumber(numOption2, 1.0M, 1000000.0M, (decimal)pathLineOptions.PatternLengthMm, 1);

                    lblOption3.Visible = numOption3.Visible = true;
                    lblOption3.Text = "빈 구간 비율";
                    SetNumber(numOption3, 0.0M, 1.0M, (decimal)pathLineOptions.GapRatio, 2);

                    chkOption1.Visible = true;
                    chkOption1.Text = "화살촉 표시";
                    chkOption1.Checked = pathLineOptions.ShowArrow;

                    chkOption2.Visible = true;
                    chkOption2.Text = "항상 위에 표시";
                    chkOption2.Checked = pathLineOptions.AlwaysOnTop;
                    break;

                case 7:
                    DataSetOptions pointCloudOptions = new DataSetOptions();

                    lblColor.Visible = btnEffectColor.Visible = true;
                    btnEffectColor.BackColor = pointCloudOptions.Color;

                    lblOption1.Visible = numOption1.Visible = true;
                    lblOption1.Text = "점 지름(mm)";
                    SetNumber(numOption1, 0.1M, 1000000.0M, (decimal)pointCloudOptions.PointSizeMm, 1);

                    lblOption2.Visible = numOption2.Visible = true;
                    lblOption2.Text = "불투명도";
                    SetNumber(numOption2, 0.0M, 1.0M, (decimal)pointCloudOptions.Opacity, 2);

                    chkOption1.Visible = true;
                    chkOption1.Text = "항상 위에 표시";
                    chkOption1.Checked = pointCloudOptions.AlwaysOnTop;
                    break;

                case 8:
                    PulseOutlineOptions pulseOutlineOptions = new PulseOutlineOptions();

                    lblColor.Visible = btnEffectColor.Visible = true;
                    btnEffectColor.BackColor = pulseOutlineOptions.Color;

                    lblOption1.Visible = numOption1.Visible = true;
                    lblOption1.Text = "외곽선 두께(px)";
                    SetNumber(numOption1, 0.1M, 20.0M, (decimal)pulseOutlineOptions.LineWidth, 1);

                    chkOption1.Visible = true;
                    chkOption1.Text = "항상 위에 표시";
                    chkOption1.Checked = pulseOutlineOptions.AlwaysOnTop;

                    lblSpecial.Visible = cmbSpecial.Visible = true;
                    lblSpecial.Text = "영역 지정";
                    cmbSpecial.Items.AddRange(new object[] { "선택 객체의 경계 영역", "오스냅 모서리 목록" });
                    cmbSpecial.SelectedIndex = 0;
                    break;

                case 9:
                    PulseSphereOptions pulseSphereOptions = new PulseSphereOptions();

                    lblColor.Visible = btnEffectColor.Visible = true;
                    btnEffectColor.BackColor = pulseSphereOptions.Color;

                    lblOption1.Visible = numOption1.Visible = true;
                    lblOption1.Text = "시작 반경(mm)";
                    SetNumber(numOption1, 1.0M, 1000000.0M, (decimal)pulseSphereOptions.MinRadius, 1);

                    lblOption2.Visible = numOption2.Visible = true;
                    lblOption2.Text = "최대 반경(mm)";
                    SetNumber(numOption2, 1.0M, 1000000.0M, (decimal)pulseSphereOptions.MaxRadius, 1);

                    lblOption3.Visible = numOption3.Visible = true;
                    lblOption3.Text = "불투명도";
                    SetNumber(numOption3, 0.0M, 1.0M, (decimal)pulseSphereOptions.Opacity, 2);
                    break;

                case 10:
                    SpinnerOptions spinnerOptions = new SpinnerOptions();

                    lblColor.Visible = btnEffectColor.Visible = true;
                    btnEffectColor.BackColor = spinnerOptions.Color;

                    lblOption1.Visible = numOption1.Visible = true;
                    lblOption1.Text = "바깥 지름(px)";
                    SetNumber(numOption1, 1, 512, spinnerOptions.SizePx, 0);

                    lblOption2.Visible = numOption2.Visible = true;
                    lblOption2.Text = "고리 두께(px)";
                    SetNumber(numOption2, 1, 100, spinnerOptions.ThicknessPx, 0);

                    lblOption3.Visible = numOption3.Visible = true;
                    lblOption3.Text = "진행률(-1 ~ 1)";
                    SetNumber(numOption3, -1.0M, 1.0M, (decimal)spinnerOptions.Progress, 2);

                    chkOption1.Visible = true;
                    chkOption1.Text = "바탕 고리 표시";
                    chkOption1.Checked = spinnerOptions.ShowTrack;

                    chkOption2.Visible = true;
                    chkOption2.Text = "항상 위에 표시";
                    chkOption2.Checked = spinnerOptions.AlwaysOnTop;
                    break;

                case 11:
                    TextLabelOptions textLabelOptions = new TextLabelOptions();

                    lblColor.Visible = btnEffectColor.Visible = true;
                    lblColor.Text = "글자 색";
                    btnEffectColor.BackColor = textLabelOptions.TextColor;

                    lblOption1.Visible = numOption1.Visible = true;
                    lblOption1.Text = "글자 높이(px)";
                    SetNumber(numOption1, 1, 512, textLabelOptions.SizePx, 0);

                    lblOption2.Visible = numOption2.Visible = true;
                    lblOption2.Text = "페이드 시작 거리(mm)";
                    SetNumber(numOption2, 0.0M, 10000000.0M, (decimal)textLabelOptions.FadeStartMm, 1);

                    lblOption3.Visible = numOption3.Visible = true;
                    lblOption3.Text = "페이드 종료 거리(mm)";
                    SetNumber(numOption3, 0.0M, 10000000.0M, (decimal)textLabelOptions.FadeEndMm, 1);

                    chkOption1.Visible = true;
                    chkOption1.Text = "항상 위에 표시";
                    chkOption1.Checked = textLabelOptions.AlwaysOnTop;

                    chkOption2.Visible = true;
                    chkOption2.Text = "화면 밖 방향 표시";
                    chkOption2.Checked = textLabelOptions.ShowOffscreenIndicator;

                    lblOptionText.Visible = txtOptionText.Visible = true;
                    lblOptionText.Text = "표시 문자열";
                    txtOptionText.Text = "VIZCore3DX.NET Effect";
                    break;

                case 12:
                    VaporOptions vaporOptions = new VaporOptions();

                    lblColor.Visible = btnEffectColor.Visible = true;
                    btnEffectColor.BackColor = vaporOptions.Color;

                    lblOption1.Visible = numOption1.Visible = true;
                    lblOption1.Text = "시작 반경(mm)";
                    SetNumber(numOption1, 1.0M, 1000000.0M, (decimal)vaporOptions.StartRadius, 1);

                    lblOption2.Visible = numOption2.Visible = true;
                    lblOption2.Text = "끝 반경(mm)";
                    SetNumber(numOption2, 1.0M, 1000000.0M, (decimal)vaporOptions.EndRadius, 1);

                    lblOption3.Visible = numOption3.Visible = true;
                    lblOption3.Text = "상승 높이(mm)";
                    SetNumber(numOption3, 1.0M, 1000000.0M, (decimal)vaporOptions.Height, 1);
                    break;

                case 13:
                    lblNoOptions.Visible = true;
                    lblNoOptions.Text = "개별 옵션이 없습니다. 용접 불꽃 효과 설정은 조회 / 관리 탭에서 변경합니다.";
                    break;
            }


            UpdatePointGuide();
        }

        private void cmbSpecial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEffectType.SelectedIndex == 5 && cmbSpecial.SelectedIndex >= 0)
            {
                ParticleOptions options = new ParticleOptions((ParticlePreset)cmbSpecial.SelectedIndex);
                btnEffectColor.BackColor = options.StartColor;
                SetNumber(numOption1, 1.0M, 1000000.0M, (decimal)options.ParticleSizeMm, 1);
                SetNumber(numOption2, 0.0M, 180.0M, (decimal)options.ConeAngleDeg, 1);
            }

            if (cmbEffectType.SelectedIndex == 8 && cmbSpecial.SelectedIndex >= 0)
            {
                lvPoints.Items.Clear();
                lblCreateResult.Text = "생성 결과 : -";
                UpdatePointGuide();
            }
        }

        private void btnEffectColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = btnEffectColor.BackColor;

                if (dialog.ShowDialog() != DialogResult.OK) return;

                btnEffectColor.BackColor = dialog.Color;
            }
        }

        private int GetPointLimit()
        {
            int index = cmbEffectType.SelectedIndex;

            if (index == 0) return 2;
            if (index < 0 || index == 3 || index == 6 || index == 7 || index == 8) return 0;

            return 1;
        }

        private void UpdatePointGuide()
        {
            string[] guides = new string[]
            {
                "치수선의 시작점과 끝점을 선택해주세요. 최근 두 점만 유지됩니다.",
                "가스 확산 구름을 표시할 위치를 선택해주세요.",
                "지면 투영 링의 기준 지점을 선택해주세요.",
                "선 무리에 사용할 점을 순서대로 선택해주세요.",
                "마커를 표시할 위치를 선택해주세요.",
                "파티클 이미터를 표시할 위치를 선택해주세요.",
                "흐르는 경로선을 구성할 점을 순서대로 선택해주세요.",
                "점 무리에 사용할 점을 선택해주세요.",
                "펄스 외곽선의 시작점과 끝점을 한 쌍씩 선택해주세요.",
                "확산 구를 표시할 위치를 선택해주세요.",
                "회전 스피너를 표시할 위치를 선택해주세요.",
                "텍스트 라벨을 표시할 위치를 선택해주세요.",
                "유증기를 표시할 위치를 선택해주세요.",
                "용접 불꽃 효과를 표시할 위치를 선택해주세요."
            };

            int index = cmbEffectType.SelectedIndex;
            bool useOsnap = index != 8 || cmbSpecial.SelectedIndex != 0;

            if (index >= 0 && index < guides.Length) lblPointGuide.Text = index == 8 && !useOsnap ? "3D 화면에서 객체를 선택해주세요. 선택 객체의 경계 영역을 사용합니다." : guides[index];

            chkSnapSurface.Enabled = useOsnap;
            chkSnapVertex.Enabled = useOsnap;
            chkSnapLine.Enabled = useOsnap;
            chkSnapCircle.Enabled = useOsnap;
            btnPickPoint.Enabled = useOsnap;
            btnRemovePoint.Enabled = useOsnap;
            btnClearPoints.Enabled = useOsnap;
            lvPoints.Enabled = useOsnap;
        }

        private async void btnPickPoint_Click(object sender, EventArgs e)
        {
            if (!CheckModel()) return;

            if (!chkSnapSurface.Checked && !chkSnapVertex.Checked && !chkSnapLine.Checked && !chkSnapCircle.Checked)
            {
                MessageBox.Show("사용할 오스냅 항목을 하나 이상 선택해주세요.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();
            if (osnap == null) return;

            osnap.PlaneSnap = chkSnapSurface.Checked;
            osnap.EdgeEndpointSnap = chkSnapVertex.Checked;
            osnap.EdgeMidpointSnap = chkSnapVertex.Checked;
            osnap.LineSnap = chkSnapLine.Checked;
            osnap.CircleSnap = chkSnapCircle.Checked;
            osnap.CircleCenterSnap = chkSnapCircle.Checked;
            osnap.CylinderSnap = chkSnapCircle.Checked;
            osnap.CommandText = "이펙트를 표시할 위치를 선택해주세요.";

            vizcore3dx.Focus();

            OsnapResult result = await osnap.GetResultAsync();
            if (result == null || result.Position == null) return;

            Vector3D position = result.Position;
            string positionText = string.Format("X:{0:0.###}, Y:{1:0.###}, Z:{2:0.###}", position.X, position.Y, position.Z);
            ListViewItem item = new ListViewItem(new string[] { (lvPoints.Items.Count + 1).ToString(), result.Type.ToString(), positionText });
            item.Tag = position;
            lvPoints.Items.Add(item);

            int pointLimit = GetPointLimit();
            while (pointLimit > 0 && lvPoints.Items.Count > pointLimit) lvPoints.Items.RemoveAt(0);
            for (int i = 0; i < lvPoints.Items.Count; i++) lvPoints.Items[i].Text = (i + 1).ToString();
        }

        private void btnRemovePoint_Click(object sender, EventArgs e)
        {
            if (lvPoints.Items.Count == 0) return;

            if (lvPoints.SelectedItems.Count > 0) lvPoints.Items.Remove(lvPoints.SelectedItems[0]);
            else lvPoints.Items.RemoveAt(lvPoints.Items.Count - 1);

            for (int i = 0; i < lvPoints.Items.Count; i++) lvPoints.Items[i].Text = (i + 1).ToString();
        }

        private void btnClearPoints_Click(object sender, EventArgs e)
        {
            lvPoints.Items.Clear();
        }

        private void btnCreateEffect_Click(object sender, EventArgs e)
        {
            if (!CheckModel()) return;

            List<Vector3D> points = new List<Vector3D>();

            foreach (ListViewItem item in lvPoints.Items)
            {
                Vector3D position = item.Tag as Vector3D;
                if (position != null) points.Add(position);
            }

            int pointLimit = GetPointLimit();

            if (pointLimit > 0 && points.Count != pointLimit)
            {
                MessageBox.Show(string.Format("이펙트 생성에 필요한 위치를 {0}개 선택해주세요.", pointLimit), "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            uint id = 0;

            switch (cmbEffectType.SelectedIndex)
            {
                case 0:
                    DimensionLineOptions dimensionOptions = new DimensionLineOptions();
                    dimensionOptions.Color = btnEffectColor.BackColor;
                    dimensionOptions.LineWidth = (float)numOption1.Value;
                    dimensionOptions.Decimals = (int)numOption2.Value;
                    dimensionOptions.ShowText = chkOption1.Checked;
                    dimensionOptions.AlwaysOnTop = chkOption2.Checked;

                    id = vizcore3dx.View.Effect.AddDimensionLine(points[0], points[1], dimensionOptions);
                    break;

                case 1:
                    if (numOption1.Value >= numOption2.Value)
                    {
                        MessageBox.Show("최대 반경은 시작 반경보다 크게 설정해주세요.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    GasCloudOptions gasOptions = new GasCloudOptions();
                    gasOptions.Color = btnEffectColor.BackColor;
                    gasOptions.MinRadius = (float)numOption1.Value;
                    gasOptions.MaxRadius = (float)numOption2.Value;
                    gasOptions.Opacity = (float)numOption3.Value;

                    id = vizcore3dx.View.Effect.AddGasCloud(points[0], gasOptions);
                    break;

                case 2:
                    GroundRingOptions groundRingOptions = new GroundRingOptions();
                    groundRingOptions.Color = btnEffectColor.BackColor;
                    groundRingOptions.RadiusMm = (float)numOption1.Value;
                    groundRingOptions.LineWidth = (float)numOption2.Value;
                    groundRingOptions.RippleCount = (int)numOption3.Value;
                    groundRingOptions.ShowStem = chkOption1.Checked;
                    groundRingOptions.AlwaysOnTop = chkOption2.Checked;

                    id = vizcore3dx.View.Effect.AddGroundRing(points[0], groundRingOptions);
                    break;

                case 3:
                    if (points.Count < 2)
                    {
                        MessageBox.Show("선 무리에 사용할 점을 두 개 이상 선택해주세요.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (cmbSpecial.SelectedIndex == 1 && points.Count % 2 != 0)
                    {
                        MessageBox.Show("점 2개씩 선분으로 표시하려면 짝수 개의 점을 선택해주세요.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DataSetOptions lineSetOptions = new DataSetOptions();
                    lineSetOptions.Color = btnEffectColor.BackColor;
                    lineSetOptions.LineWidth = (float)numOption1.Value;
                    lineSetOptions.Opacity = (float)numOption2.Value;
                    lineSetOptions.AlwaysOnTop = chkOption1.Checked;

                    float[] lineXYZ = new float[points.Count * 3];

                    for (int i = 0; i < points.Count; i++)
                    {
                        lineXYZ[(i * 3) + 0] = points[i].X;
                        lineXYZ[(i * 3) + 1] = points[i].Y;
                        lineXYZ[(i * 3) + 2] = points[i].Z;
                    }

                    int[] polylineSizes = cmbSpecial.SelectedIndex == 0 ? new int[] { points.Count } : null;

                    id = vizcore3dx.View.Effect.AddLineSet(lineXYZ, polylineSizes, null, lineSetOptions);
                    break;

                case 4:
                    MarkerOptions markerOptions = new MarkerOptions();
                    markerOptions.SizePx = (int)numOption1.Value;
                    markerOptions.FadeStartMm = (float)numOption2.Value;
                    markerOptions.FadeEndMm = (float)numOption3.Value;
                    markerOptions.AlwaysOnTop = chkOption1.Checked;
                    markerOptions.ShowOffscreenIndicator = chkOption2.Checked;
                    markerOptions.Label = string.IsNullOrWhiteSpace(txtOptionText.Text) ? null : txtOptionText.Text;

                    id = vizcore3dx.View.Effect.AddMarker(points[0], (MarkerIcon)cmbSpecial.SelectedIndex, markerOptions);
                    vizcore3dx.View.Effect.SetMarkerVisible(chkMarkerVisible.Checked);
                    break;

                case 5:
                    ParticleOptions particleOptions = new ParticleOptions((ParticlePreset)cmbSpecial.SelectedIndex);
                    particleOptions.StartColor = btnEffectColor.BackColor;
                    particleOptions.ParticleSizeMm = (float)numOption1.Value;
                    particleOptions.ConeAngleDeg = (float)numOption2.Value;

                    id = vizcore3dx.View.Effect.AddParticleEmitter(points[0], particleOptions);
                    break;

                case 6:
                    if (points.Count < 2)
                    {
                        MessageBox.Show("흐르는 경로선을 구성할 점을 두 개 이상 선택해주세요.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    PathLineOptions pathLineOptions = new PathLineOptions();
                    pathLineOptions.Color = btnEffectColor.BackColor;
                    pathLineOptions.LineWidth = (float)numOption1.Value;
                    pathLineOptions.PatternLengthMm = (float)numOption2.Value;
                    pathLineOptions.GapRatio = (float)numOption3.Value;
                    pathLineOptions.ShowArrow = chkOption1.Checked;
                    pathLineOptions.AlwaysOnTop = chkOption2.Checked;

                    id = vizcore3dx.View.Effect.AddPathLine(points, pathLineOptions);
                    break;

                case 7:
                    if (points.Count < 1)
                    {
                        MessageBox.Show("점 무리에 사용할 점을 하나 이상 선택해주세요.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DataSetOptions pointCloudOptions = new DataSetOptions();
                    pointCloudOptions.Color = btnEffectColor.BackColor;
                    pointCloudOptions.PointSizeMm = (float)numOption1.Value;
                    pointCloudOptions.Opacity = (float)numOption2.Value;
                    pointCloudOptions.AlwaysOnTop = chkOption1.Checked;

                    id = vizcore3dx.View.Effect.AddPointCloud(points, null, pointCloudOptions);
                    break;

                case 8:
                    PulseOutlineOptions pulseOutlineOptions = new PulseOutlineOptions();
                    pulseOutlineOptions.Color = btnEffectColor.BackColor;
                    pulseOutlineOptions.LineWidth = (float)numOption1.Value;
                    pulseOutlineOptions.AlwaysOnTop = chkOption1.Checked;

                    if (cmbSpecial.SelectedIndex == 0)
                    {
                        List<Node> nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP);

                        if (nodes.Count == 0)
                        {
                            MessageBox.Show("펄스 외곽선을 표시할 객체를 3D 화면에서 먼저 선택해주세요.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        id = vizcore3dx.View.Effect.AddPulseOutline(nodes[0].GetBoundBox(), pulseOutlineOptions);
                    }
                    else
                    {
                        if (points.Count < 2)
                        {
                            MessageBox.Show("펄스 외곽선의 시작점과 끝점을 두 개 이상 선택해주세요.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (points.Count % 2 != 0)
                        {
                            MessageBox.Show("펄스 외곽선은 시작점과 끝점이 한 쌍이 되도록 짝수 개의 점을 선택해주세요.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        id = vizcore3dx.View.Effect.AddPulseOutline(points, pulseOutlineOptions);
                    }

                    break;

                case 9:
                    if (numOption1.Value >= numOption2.Value)
                    {
                        MessageBox.Show("최대 반경은 시작 반경보다 크게 설정해주세요.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    PulseSphereOptions pulseSphereOptions = new PulseSphereOptions();
                    pulseSphereOptions.Color = btnEffectColor.BackColor;
                    pulseSphereOptions.MinRadius = (float)numOption1.Value;
                    pulseSphereOptions.MaxRadius = (float)numOption2.Value;
                    pulseSphereOptions.Opacity = (float)numOption3.Value;

                    id = vizcore3dx.View.Effect.AddPulseSphere(points[0], pulseSphereOptions);
                    break;

                case 10:
                    SpinnerOptions spinnerOptions = new SpinnerOptions();
                    spinnerOptions.Color = btnEffectColor.BackColor;
                    spinnerOptions.SizePx = (int)numOption1.Value;
                    spinnerOptions.ThicknessPx = (int)numOption2.Value;
                    spinnerOptions.Progress = (float)numOption3.Value;
                    spinnerOptions.ShowTrack = chkOption1.Checked;
                    spinnerOptions.AlwaysOnTop = chkOption2.Checked;

                    id = vizcore3dx.View.Effect.AddSpinner(points[0], spinnerOptions);
                    break;

                case 11:
                    if (string.IsNullOrWhiteSpace(txtOptionText.Text))
                    {
                        MessageBox.Show("텍스트 라벨에 표시할 문자열을 입력해주세요.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    TextLabelOptions textLabelOptions = new TextLabelOptions();
                    textLabelOptions.TextColor = btnEffectColor.BackColor;
                    textLabelOptions.SizePx = (int)numOption1.Value;
                    textLabelOptions.FadeStartMm = (float)numOption2.Value;
                    textLabelOptions.FadeEndMm = (float)numOption3.Value;
                    textLabelOptions.AlwaysOnTop = chkOption1.Checked;
                    textLabelOptions.ShowOffscreenIndicator = chkOption2.Checked;

                    id = vizcore3dx.View.Effect.AddTextLabel(points[0], txtOptionText.Text, textLabelOptions);
                    vizcore3dx.View.Effect.SetTextLabelVisible(chkTextLabelVisible.Checked);
                    break;

                case 12:
                    VaporOptions vaporOptions = new VaporOptions();
                    vaporOptions.Color = btnEffectColor.BackColor;
                    vaporOptions.StartRadius = (float)numOption1.Value;
                    vaporOptions.EndRadius = (float)numOption2.Value;
                    vaporOptions.Height = (float)numOption3.Value;

                    id = vizcore3dx.View.Effect.AddVapor(points[0], vaporOptions);
                    break;

                case 13:
                    id = vizcore3dx.View.Effect.AddWeldingSpark(points[0]);
                    break;
            }

            if (id == 0)
            {
                lblCreateResult.Text = "생성 결과 : 실패";
                MessageBox.Show("이펙트를 생성하지 못했습니다. 입력한 값과 등록 가능한 최대 개수를 확인해주세요.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblCreateResult.Text = string.Format("생성 결과 : {0}-{1}", cmbEffectType.Text, id);
            lvPoints.Items.Clear();
        }

        private void cmbQueryMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbQueryType.Enabled = cmbQueryMode.SelectedIndex == 1;
        }

        private void btnRefreshEffects_Click(object sender, EventArgs e)
        {
            RefreshEffectList();
        }

        private void RefreshEffectList()
        {
            if (vizcore3dx == null || vizcore3dx.View == null || vizcore3dx.View.Effect == null) return;

            List<EffectItem> effects;

            if (cmbQueryMode.SelectedIndex == 1) effects = vizcore3dx.View.Effect.GetEffects((EffectType)cmbQueryType.SelectedIndex);
            else effects = vizcore3dx.View.Effect.GetEffects();

            lvEffects.BeginUpdate();
            lvEffects.Items.Clear();

            foreach (EffectItem effect in effects)
            {
                string position = effect.Position == null ? string.Empty : effect.Position.ToString();
                ListViewItem item = new ListViewItem(new string[] { string.Format("{0}-{1}", effect.Type, effect.ID), effect.Type.ToString(), position, effect.Summary ?? string.Empty });
                item.Tag = effect;
                lvEffects.Items.Add(item);
            }

            lvEffects.EndUpdate();
            lblEffectListCount.Text = string.Format("조회 결과 : {0}개", effects.Count);
        }

        private EffectItem GetSelectedEffect()
        {
            if (lvEffects.SelectedItems.Count == 0) return null;

            return lvEffects.SelectedItems[0].Tag as EffectItem;
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            EffectItem effect = GetSelectedEffect();

            if (effect == null)
            {
                MessageBox.Show("제거할 이펙트를 목록에서 선택해주세요.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool result = false;

            switch (effect.Type)
            {
                case EffectType.Marker: result = vizcore3dx.View.Effect.RemoveMarker(effect.ID); break;
                case EffectType.TextLabel: result = vizcore3dx.View.Effect.RemoveTextLabel(effect.ID); break;
                case EffectType.WeldingSpark: result = vizcore3dx.View.Effect.RemoveWeldingSpark(effect.ID); break;
                case EffectType.GasCloud: result = vizcore3dx.View.Effect.RemoveGasCloud(effect.ID); break;
                case EffectType.Vapor: result = vizcore3dx.View.Effect.RemoveVapor(effect.ID); break;
                case EffectType.PulseSphere: result = vizcore3dx.View.Effect.RemovePulseSphere(effect.ID); break;
                case EffectType.PulseOutline: result = vizcore3dx.View.Effect.RemovePulseOutline(effect.ID); break;
                case EffectType.DimensionLine: result = vizcore3dx.View.Effect.RemoveDimensionLine(effect.ID); break;
                case EffectType.PathLine: result = vizcore3dx.View.Effect.RemovePathLine(effect.ID); break;
                case EffectType.ParticleEmitter: result = vizcore3dx.View.Effect.RemoveParticleEmitter(effect.ID); break;
                case EffectType.Spinner: result = vizcore3dx.View.Effect.RemoveSpinner(effect.ID); break;
                case EffectType.GroundRing: result = vizcore3dx.View.Effect.RemoveGroundRing(effect.ID); break;
                case EffectType.DataSet: result = vizcore3dx.View.Effect.RemoveDataSet(effect.ID); break;
            }

            if (!result) MessageBox.Show("선택한 이펙트를 제거하지 못했습니다.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnClearType_Click(object sender, EventArgs e)
        {
            ClearEffect((EffectType)cmbClearType.SelectedIndex);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            foreach (EffectType type in Enum.GetValues(typeof(EffectType))) ClearEffect(type);
        }

        private void ClearEffect(EffectType type)
        {
            switch (type)
            {
                case EffectType.Marker: vizcore3dx.View.Effect.ClearMarkers(); break;
                case EffectType.TextLabel: vizcore3dx.View.Effect.ClearTextLabels(); break;
                case EffectType.WeldingSpark: vizcore3dx.View.Effect.ClearWeldingSparks(); break;
                case EffectType.GasCloud: vizcore3dx.View.Effect.ClearGasClouds(); break;
                case EffectType.Vapor: vizcore3dx.View.Effect.ClearVapors(); break;
                case EffectType.PulseSphere: vizcore3dx.View.Effect.ClearPulseSpheres(); break;
                case EffectType.PulseOutline: vizcore3dx.View.Effect.ClearPulseOutlines(); break;
                case EffectType.DimensionLine: vizcore3dx.View.Effect.ClearDimensionLines(); break;
                case EffectType.PathLine: vizcore3dx.View.Effect.ClearPathLines(); break;
                case EffectType.ParticleEmitter: vizcore3dx.View.Effect.ClearParticleEmitters(); break;
                case EffectType.Spinner: vizcore3dx.View.Effect.ClearSpinners(); break;
                case EffectType.GroundRing: vizcore3dx.View.Effect.ClearGroundRings(); break;
                case EffectType.DataSet: vizcore3dx.View.Effect.ClearDataSets(); break;
            }
        }

        private void chkMarkerVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (vizcore3dx == null || vizcore3dx.View == null || vizcore3dx.View.Effect == null) return;

            vizcore3dx.View.Effect.SetMarkerVisible(chkMarkerVisible.Checked);
        }

        private void chkTextLabelVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (vizcore3dx == null || vizcore3dx.View == null || vizcore3dx.View.Effect == null) return;

            vizcore3dx.View.Effect.SetTextLabelVisible(chkTextLabelVisible.Checked);
        }

        private void btnSetSpinnerProgress_Click(object sender, EventArgs e)
        {
            EffectItem effect = GetSelectedEffect();

            if (effect == null || effect.Type != EffectType.Spinner)
            {
                MessageBox.Show("이펙트 목록에서 회전 스피너를 선택해주세요.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            float progress = chkSpinnerContinuous.Checked ? -1.0f : (float)numSpinnerProgress.Value / 100.0f;
            bool result = vizcore3dx.View.Effect.SetSpinnerProgress(effect.ID, progress);

            if (!result) MessageBox.Show("회전 스피너의 진행률을 변경하지 못했습니다.", "VIZCore3DX.NET.Effect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnApplyWeldingSettings_Click(object sender, EventArgs e)
        {
            vizcore3dx.View.Effect.WeldingSparkBounce = chkWeldingSparkBounce.Checked;
            vizcore3dx.View.Effect.WeldingSparkCapacity = (int)numWeldingSparkCapacity.Value;

            RefreshEffectStatus();
        }

        private void RefreshEffectStatus()
        {
            if (vizcore3dx == null || vizcore3dx.View == null || vizcore3dx.View.Effect == null) return;

            txtEffectCount.Text = string.Join(Environment.NewLine, new string[]
            {
                string.Format("전체 이펙트 : {0}", vizcore3dx.View.Effect.EffectCount),
                string.Format("치수선 : {0}", vizcore3dx.View.Effect.DimensionLineCount),
                string.Format("가스 확산 구름 : {0}", vizcore3dx.View.Effect.GasCloudCount),
                string.Format("지면 투영 링 : {0}", vizcore3dx.View.Effect.GroundRingCount),
                string.Format("마커 : {0}", vizcore3dx.View.Effect.MarkerCount),
                string.Format("파티클 이미터 : {0}", vizcore3dx.View.Effect.ParticleEmitterCount),
                string.Format("흐르는 경로선 : {0}", vizcore3dx.View.Effect.PathLineCount),
                string.Format("펄스 외곽선 : {0}", vizcore3dx.View.Effect.PulseOutlineCount),
                string.Format("확산 구 : {0}", vizcore3dx.View.Effect.PulseSphereCount),
                string.Format("회전 스피너 : {0}", vizcore3dx.View.Effect.SpinnerCount),
                string.Format("텍스트 라벨 : {0}", vizcore3dx.View.Effect.TextLabelCount),
                string.Format("유증기 : {0}", vizcore3dx.View.Effect.VaporCount),
                string.Format("용접 불꽃 효과 : {0}", vizcore3dx.View.Effect.WeldingSparkCount),
                string.Format("좌표·색 데이터 : {0}", vizcore3dx.View.Effect.DataSetCount),
                string.Format("좌표·색 데이터 사용 정점 : {0}", vizcore3dx.View.Effect.DataSetVertexCount),
                string.Format("좌표·색 데이터 정점 배열 용량 : {0}", vizcore3dx.View.Effect.DataSetVertexCapacity)
            });

            EffectCapacity capacity = vizcore3dx.View.Effect.Capacity;

            txtEffectCapacity.Text = string.Join(Environment.NewLine, new string[]
            {
                string.Format("좌표·색 데이터 : {0}", capacity.DataSetCount),
                string.Format("점 무리 좌표 / 항목 : {0}", capacity.DataSetPointCount),
                string.Format("선 무리 좌표 / 항목 : {0}", capacity.DataSetLinePointCount),
                string.Format("좌표·색 데이터 전체 정점 : {0}", capacity.DataSetVertexCount),
                string.Format("치수선 : {0}", capacity.DimensionLineCount),
                string.Format("가스 확산 구름 : {0}", capacity.GasCloudCount),
                string.Format("지면 투영 링 : {0}", capacity.GroundRingCount),
                string.Format("마커 : {0}", capacity.MarkerCount),
                string.Format("파티클 : {0}", capacity.ParticleCount),
                string.Format("파티클 이미터 : {0}", capacity.ParticleEmitterCount),
                string.Format("흐르는 경로선 : {0}", capacity.PathLineCount),
                string.Format("경로선 좌표 / 항목 : {0}", capacity.PathLinePointCount),
                string.Format("펄스 외곽선 : {0}", capacity.PulseOutlineCount),
                string.Format("펄스 외곽선 좌표 / 항목 : {0}", capacity.PulseOutlinePointCount),
                string.Format("확산 구 : {0}", capacity.PulseSphereCount),
                string.Format("회전 스피너 : {0}", capacity.SpinnerCount),
                string.Format("텍스트 라벨 : {0}", capacity.TextLabelCount),
                string.Format("유증기 : {0}", capacity.VaporCount),
                string.Format("용접 불꽃 효과 : {0}", capacity.WeldingSparkCount)
            });

            chkWeldingSparkBounce.Checked = vizcore3dx.View.Effect.WeldingSparkBounce;

            int weldingCapacity = vizcore3dx.View.Effect.WeldingSparkCapacity;
            if (weldingCapacity < numWeldingSparkCapacity.Minimum) weldingCapacity = (int)numWeldingSparkCapacity.Minimum;
            if (weldingCapacity > numWeldingSparkCapacity.Maximum) weldingCapacity = (int)numWeldingSparkCapacity.Maximum;
            numWeldingSparkCapacity.Value = weldingCapacity;
        }

        private void Effect_OnEffectAddedEvent(object sender, VIZCore3DX.NET.Event.EventManager.EffectAddedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Effect_OnEffectAddedEvent(sender, e)));
                return;
            }

            UpdateEffectEvent(e.Items, "추가");
        }

        private void Effect_OnEffectRemovedEvent(object sender, VIZCore3DX.NET.Event.EventManager.EffectRemovedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Effect_OnEffectRemovedEvent(sender, e)));
                return;
            }

            UpdateEffectEvent(e.Items, "제거");
        }

        private void UpdateEffectEvent(IEnumerable<EffectItem> items, string action)
        {
            foreach (EffectItem item in items) listBoxEvent.Items.Insert(0, string.Format("{0} : {1}-{2}", action, item.Type, item.ID));

            while (listBoxEvent.Items.Count > 500) listBoxEvent.Items.RemoveAt(listBoxEvent.Items.Count - 1);

            RefreshEffectList();
            RefreshEffectStatus();
        }
    }
}