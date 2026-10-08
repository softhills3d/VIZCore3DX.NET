using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VIZCore3DX.NET.Effect
{
    public partial class FrmMain : Form
    {
        // 만들 효과 종류입니다. 선 무리·점 무리는 좌표·색 데이터(DataSet) 효과로 만들어집니다.
        private enum EffectKind { DimensionLine, GasCloud, GroundRing, LineSet, Marker, ParticleEmitter, PathLine, PointCloud, PulseOutline, PulseSphere, Spinner, TextLabel, Vapor, WeldingSpark }

        // 선 무리의 점 연결 방식 (연속 폴리라인 / 점 2개씩 선분)
        private enum LineSetMode { Polyline, Segments }

        // 펄스 외곽선의 영역 지정 방식 (선택 노드의 경계 영역 / 오스냅으로 고른 모서리 목록)
        private enum OutlineSource { SelectedNodes, OsnapEdges }

        // 효과 목록 조회 방식 (전체 / 종류별)
        private enum QueryMode { All, ByType }

        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        public FrmMain()
        {
            InitializeComponent();

            // 뷰어와 무관한 콤보 항목은 생성자에서 채웁니다.
            cmbEffectType.DataSource = Enum.GetValues(typeof(EffectKind));
            cmbQueryMode.DataSource = Enum.GetValues(typeof(QueryMode));
            cmbQueryType.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.EffectType));
            cmbClearType.DataSource = Enum.GetValues(typeof(VIZCore3DX.NET.Data.EffectType));

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer2.Panel1.Controls.Add(vizcore3dx);

            // Event
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
        }

        #region Initialize
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
            InitializeVIZCore3DXEvent();
        }

        private void InitializeVIZCore3DX()
        {
            // 리본 UI 를 기본으로 켜고, 이 예제가 다루는 리본·패널 탭만 남깁니다.
            vizcore3dx.RibbonMode = true;
            ShowRibbonTabs(VIZCore3DX.NET.Data.ToolbarKind.Effect);
            ShowAttributeTabs();

            // 고른 종류의 기본 옵션을 채우고, 현재 효과 목록과 개수를 보여줍니다.
            ConfigureOptions(SelectedKind());
            RefreshEffectList();
            RefreshEffectStatus();

            SetStatus("모델을 열어 주세요.");
        }

        // 효과 목록은 뷰어가 소유하므로, 추가·제거 이벤트를 받아 목록과 개수를 다시 그립니다.
        private void InitializeVIZCore3DXEvent()
        {
            vizcore3dx.View.Effect.OnEffectAddedEvent -= Effect_OnEffectAddedEvent;
            vizcore3dx.View.Effect.OnEffectAddedEvent += Effect_OnEffectAddedEvent;
            vizcore3dx.View.Effect.OnEffectRemovedEvent -= Effect_OnEffectRemovedEvent;
            vizcore3dx.View.Effect.OnEffectRemovedEvent += Effect_OnEffectRemovedEvent;
        }

        // 종료 시 이벤트 구독을 먼저 끊습니다. 자식 컨트롤이 정리된 뒤에 이벤트가 오면 안 됩니다.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (vizcore3dx.View != null && vizcore3dx.View.Effect != null)
            {
                vizcore3dx.View.Effect.OnEffectAddedEvent -= Effect_OnEffectAddedEvent;
                vizcore3dx.View.Effect.OnEffectRemovedEvent -= Effect_OnEffectRemovedEvent;
            }

            base.OnFormClosing(e);
        }

        private void Effect_OnEffectAddedEvent(object sender, VIZCore3DX.NET.Event.EventManager.EffectAddedEventArgs e)
        {
            RunOnUi(() => { LogEvents(e.Items, "추가"); RefreshEffectList(); RefreshEffectStatus(); });
        }

        private void Effect_OnEffectRemovedEvent(object sender, VIZCore3DX.NET.Event.EventManager.EffectRemovedEventArgs e)
        {
            RunOnUi(() => { LogEvents(e.Items, "제거"); RefreshEffectList(); RefreshEffectStatus(); });
        }
        #endregion

        #region 1. 모델
        // 효과를 배치할 모델을 엽니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            RefreshEffectList();
            RefreshEffectStatus();
            SetStatus("모델을 열었습니다.");
        }
        #endregion

        #region 2. 종류·옵션
        // 종류를 바꾸면 그 종류의 옵션 칸만 보이고, 기본값은 옵션 객체의 기본값으로 채웁니다.
        private void cmbEffectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cmbEffectType.SelectedItem is EffectKind)) return;

            ConfigureOptions((EffectKind)cmbEffectType.SelectedItem);
        }

        // 파티클 프리셋을 바꾸면 그 프리셋의 기본 색·크기·각도로 다시 채우고, 펄스 외곽선 영역 방식을 바꾸면 위치 목록을 비웁니다.
        private void cmbSpecial_SelectedIndexChanged(object sender, EventArgs e)
        {
            EffectKind kind = SelectedKind();

            if (kind == EffectKind.ParticleEmitter && cmbSpecial.SelectedItem is VIZCore3DX.NET.Data.ParticlePreset)
                ApplyParticlePreset((VIZCore3DX.NET.Data.ParticlePreset)cmbSpecial.SelectedItem);

            if (kind == EffectKind.PulseOutline && cmbSpecial.SelectedItem is OutlineSource)
            {
                lvPoints.Items.Clear();
                UpdatePointControls();
            }
        }

        // 효과 색을 고릅니다. 버튼 바탕색이 지금 고른 색입니다.
        private void btnEffectColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = btnEffectColor.BackColor;
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                btnEffectColor.BackColor = dialog.Color;
            }
        }

        private void ConfigureOptions(EffectKind kind)
        {
            lvPoints.Items.Clear();
            foreach (Control control in grpSetup.Controls) control.Visible = control == lblEffectType || control == cmbEffectType;

            switch (kind)
            {
                case EffectKind.DimensionLine: ConfigureDimensionLine(); break;
                case EffectKind.GasCloud: ConfigureGasCloud(); break;
                case EffectKind.GroundRing: ConfigureGroundRing(); break;
                case EffectKind.LineSet: ConfigureLineSet(); break;
                case EffectKind.Marker: ConfigureMarker(); break;
                case EffectKind.ParticleEmitter: ConfigureParticleEmitter(); break;
                case EffectKind.PathLine: ConfigurePathLine(); break;
                case EffectKind.PointCloud: ConfigurePointCloud(); break;
                case EffectKind.PulseOutline: ConfigurePulseOutline(); break;
                case EffectKind.PulseSphere: ConfigurePulseSphere(); break;
                case EffectKind.Spinner: ConfigureSpinner(); break;
                case EffectKind.TextLabel: ConfigureTextLabel(); break;
                case EffectKind.Vapor: ConfigureVapor(); break;
                case EffectKind.WeldingSpark: ConfigureWeldingSpark(); break;
            }

            UpdatePointControls();
        }

        private void ConfigureDimensionLine()
        {
            VIZCore3DX.NET.Data.DimensionLineOptions options = new VIZCore3DX.NET.Data.DimensionLineOptions();
            ShowColor("색상", options.Color);
            ShowNumber(lblOption1, numOption1, "선 두께", 0.1M, 20.0M, (decimal)options.LineWidth, 1);
            ShowNumber(lblOption2, numOption2, "소수점 자릿수", 0, 6, options.Decimals, 0);
            ShowCheck(chkOption1, "거리 문자열 표시", options.ShowText);
            ShowCheck(chkOption2, "항상 위에 표시", options.AlwaysOnTop);
        }

        private void ConfigureGasCloud()
        {
            VIZCore3DX.NET.Data.GasCloudOptions options = new VIZCore3DX.NET.Data.GasCloudOptions();
            ShowColor("색상", options.Color);
            ShowNumber(lblOption1, numOption1, "시작 반경(mm)", 1.0M, 1000000.0M, (decimal)options.MinRadius, 1);
            ShowNumber(lblOption2, numOption2, "최대 반경(mm)", 1.0M, 1000000.0M, (decimal)options.MaxRadius, 1);
            ShowNumber(lblOption3, numOption3, "불투명도", 0.0M, 1.0M, (decimal)options.Opacity, 2);
        }

        private void ConfigureGroundRing()
        {
            VIZCore3DX.NET.Data.GroundRingOptions options = new VIZCore3DX.NET.Data.GroundRingOptions();
            ShowColor("색상", options.Color);
            ShowNumber(lblOption1, numOption1, "반지름(mm)", 1.0M, 1000000.0M, (decimal)options.RadiusMm, 1);
            ShowNumber(lblOption2, numOption2, "선 굵기(px)", 0.1M, 20.0M, (decimal)options.LineWidth, 1);
            ShowNumber(lblOption3, numOption3, "물결 개수", 0, 20, options.RippleCount, 0);
            ShowCheck(chkOption1, "바닥까지 수직선 표시", options.ShowStem);
            ShowCheck(chkOption2, "항상 위에 표시", options.AlwaysOnTop);
        }

        private void ConfigureLineSet()
        {
            VIZCore3DX.NET.Data.DataSetOptions options = new VIZCore3DX.NET.Data.DataSetOptions();
            ShowColor("색상", options.Color);
            ShowNumber(lblOption1, numOption1, "선 굵기(px)", 0.1M, 20.0M, (decimal)options.LineWidth, 1);
            ShowNumber(lblOption2, numOption2, "불투명도", 0.0M, 1.0M, (decimal)options.Opacity, 2);
            ShowCheck(chkOption1, "항상 위에 표시", options.AlwaysOnTop);
            ShowSpecial("연결 방식", typeof(LineSetMode), LineSetMode.Polyline);
        }

        private void ConfigureMarker()
        {
            VIZCore3DX.NET.Data.MarkerOptions options = new VIZCore3DX.NET.Data.MarkerOptions();
            ShowNumber(lblOption1, numOption1, "아이콘 크기(px)", 1, 512, options.SizePx, 0);
            ShowNumber(lblOption2, numOption2, "페이드 시작 거리(mm)", 0.0M, 10000000.0M, (decimal)options.FadeStartMm, 1);
            ShowNumber(lblOption3, numOption3, "페이드 종료 거리(mm)", 0.0M, 10000000.0M, (decimal)options.FadeEndMm, 1);
            ShowCheck(chkOption1, "항상 위에 표시", options.AlwaysOnTop);
            ShowCheck(chkOption2, "화면 밖 방향 표시", options.ShowOffscreenIndicator);
            ShowSpecial("마커 아이콘", typeof(VIZCore3DX.NET.Data.MarkerIcon), VIZCore3DX.NET.Data.MarkerIcon.Warning);
            ShowText("라벨", string.Empty);
        }

        private void ConfigureParticleEmitter()
        {
            VIZCore3DX.NET.Data.ParticleOptions options = new VIZCore3DX.NET.Data.ParticleOptions(VIZCore3DX.NET.Data.ParticlePreset.Smoke);
            ShowColor("시작 색상", options.StartColor);
            ShowNumber(lblOption1, numOption1, "파티클 크기(mm)", 1.0M, 1000000.0M, (decimal)options.ParticleSizeMm, 1);
            ShowNumber(lblOption2, numOption2, "원뿔 반각(도)", 0.0M, 180.0M, (decimal)options.ConeAngleDeg, 1);
            ShowSpecial("프리셋", typeof(VIZCore3DX.NET.Data.ParticlePreset), VIZCore3DX.NET.Data.ParticlePreset.Smoke);
        }

        private void ConfigurePathLine()
        {
            VIZCore3DX.NET.Data.PathLineOptions options = new VIZCore3DX.NET.Data.PathLineOptions();
            ShowColor("색상", options.Color);
            ShowNumber(lblOption1, numOption1, "선 두께(px)", 0.1M, 20.0M, (decimal)options.LineWidth, 1);
            ShowNumber(lblOption2, numOption2, "패턴 길이(mm)", 1.0M, 1000000.0M, (decimal)options.PatternLengthMm, 1);
            ShowNumber(lblOption3, numOption3, "빈 구간 비율", 0.0M, 1.0M, (decimal)options.GapRatio, 2);
            ShowCheck(chkOption1, "화살촉 표시", options.ShowArrow);
            ShowCheck(chkOption2, "항상 위에 표시", options.AlwaysOnTop);
        }

        private void ConfigurePointCloud()
        {
            VIZCore3DX.NET.Data.DataSetOptions options = new VIZCore3DX.NET.Data.DataSetOptions();
            ShowColor("색상", options.Color);
            ShowNumber(lblOption1, numOption1, "점 지름(mm)", 0.1M, 1000000.0M, (decimal)options.PointSizeMm, 1);
            ShowNumber(lblOption2, numOption2, "불투명도", 0.0M, 1.0M, (decimal)options.Opacity, 2);
            ShowCheck(chkOption1, "항상 위에 표시", options.AlwaysOnTop);
        }

        private void ConfigurePulseOutline()
        {
            VIZCore3DX.NET.Data.PulseOutlineOptions options = new VIZCore3DX.NET.Data.PulseOutlineOptions();
            ShowColor("색상", options.Color);
            ShowNumber(lblOption1, numOption1, "외곽선 두께(px)", 0.1M, 20.0M, (decimal)options.LineWidth, 1);
            ShowCheck(chkOption1, "항상 위에 표시", options.AlwaysOnTop);
            ShowSpecial("영역 지정", typeof(OutlineSource), OutlineSource.SelectedNodes);
        }

        private void ConfigurePulseSphere()
        {
            VIZCore3DX.NET.Data.PulseSphereOptions options = new VIZCore3DX.NET.Data.PulseSphereOptions();
            ShowColor("색상", options.Color);
            ShowNumber(lblOption1, numOption1, "시작 반경(mm)", 1.0M, 1000000.0M, (decimal)options.MinRadius, 1);
            ShowNumber(lblOption2, numOption2, "최대 반경(mm)", 1.0M, 1000000.0M, (decimal)options.MaxRadius, 1);
            ShowNumber(lblOption3, numOption3, "불투명도", 0.0M, 1.0M, (decimal)options.Opacity, 2);
        }

        private void ConfigureSpinner()
        {
            VIZCore3DX.NET.Data.SpinnerOptions options = new VIZCore3DX.NET.Data.SpinnerOptions();
            ShowColor("색상", options.Color);
            ShowNumber(lblOption1, numOption1, "바깥 지름(px)", 1, 512, options.SizePx, 0);
            ShowNumber(lblOption2, numOption2, "고리 두께(px)", 1, 100, options.ThicknessPx, 0);
            ShowNumber(lblOption3, numOption3, "진행률(-1 ~ 1)", -1.0M, 1.0M, (decimal)options.Progress, 2);
            ShowCheck(chkOption1, "바탕 고리 표시", options.ShowTrack);
            ShowCheck(chkOption2, "항상 위에 표시", options.AlwaysOnTop);
        }

        private void ConfigureTextLabel()
        {
            VIZCore3DX.NET.Data.TextLabelOptions options = new VIZCore3DX.NET.Data.TextLabelOptions();
            ShowColor("글자 색", options.TextColor);
            ShowNumber(lblOption1, numOption1, "글자 높이(px)", 1, 512, options.SizePx, 0);
            ShowNumber(lblOption2, numOption2, "페이드 시작 거리(mm)", 0.0M, 10000000.0M, (decimal)options.FadeStartMm, 1);
            ShowNumber(lblOption3, numOption3, "페이드 종료 거리(mm)", 0.0M, 10000000.0M, (decimal)options.FadeEndMm, 1);
            ShowCheck(chkOption1, "항상 위에 표시", options.AlwaysOnTop);
            ShowCheck(chkOption2, "화면 밖 방향 표시", options.ShowOffscreenIndicator);
            ShowText("표시 문자열", "VIZCore3DX.NET Effect");
        }

        private void ConfigureVapor()
        {
            VIZCore3DX.NET.Data.VaporOptions options = new VIZCore3DX.NET.Data.VaporOptions();
            ShowColor("색상", options.Color);
            ShowNumber(lblOption1, numOption1, "시작 반경(mm)", 1.0M, 1000000.0M, (decimal)options.StartRadius, 1);
            ShowNumber(lblOption2, numOption2, "끝 반경(mm)", 1.0M, 1000000.0M, (decimal)options.EndRadius, 1);
            ShowNumber(lblOption3, numOption3, "상승 높이(mm)", 1.0M, 1000000.0M, (decimal)options.Height, 1);
        }

        private void ConfigureWeldingSpark()
        {
            lblNoOptions.Visible = true;
            lblNoOptions.Text = "개별 옵션이 없습니다. 용접 불꽃 설정은 오른쪽 효과 목록 아래에서 바꿉니다.";
        }

        private void ApplyParticlePreset(VIZCore3DX.NET.Data.ParticlePreset preset)
        {
            VIZCore3DX.NET.Data.ParticleOptions options = new VIZCore3DX.NET.Data.ParticleOptions(preset);
            btnEffectColor.BackColor = options.StartColor;
            SetNumber(numOption1, 1.0M, 1000000.0M, (decimal)options.ParticleSizeMm, 1);
            SetNumber(numOption2, 0.0M, 180.0M, (decimal)options.ConeAngleDeg, 1);
        }
        #endregion

        #region 3. 위치
        // 뷰에서 오스냅으로 위치를 하나 집어 목록에 더합니다. 종류마다 필요한 개수를 넘으면 오래된 점부터 버립니다.
        private async void btnPickPoint_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            if (!chkSnapSurface.Checked && !chkSnapVertex.Checked && !chkSnapLine.Checked && !chkSnapCircle.Checked)
            {
                SetStatus("사용할 오스냅 항목을 하나 이상 선택하세요.");
                return;
            }

            VIZCore3DX.NET.Data.OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();
            if (osnap == null) return;

            ConfigureOsnap(osnap);
            vizcore3dx.Focus();

            VIZCore3DX.NET.Data.OsnapResult result = await osnap.GetResultAsync();
            if (result == null || result.Position == null) return;

            AddPoint(result);
            SetStatus(string.Format("위치 {0}개를 골랐습니다.", lvPoints.Items.Count));
        }

        // 목록에서 고른 점을 지웁니다. 고른 점이 없으면 마지막 점을 지웁니다.
        private void btnRemovePoint_Click(object sender, EventArgs e)
        {
            if (lvPoints.Items.Count == 0) return;

            if (lvPoints.SelectedItems.Count > 0) lvPoints.Items.Remove(lvPoints.SelectedItems[0]);
            else lvPoints.Items.RemoveAt(lvPoints.Items.Count - 1);

            RenumberPoints();
        }

        // 고른 위치를 모두 비웁니다.
        private void btnClearPoints_Click(object sender, EventArgs e)
        {
            lvPoints.Items.Clear();
        }

        private void ConfigureOsnap(VIZCore3DX.NET.Data.OsnapController osnap)
        {
            osnap.PlaneSnap = chkSnapSurface.Checked;
            osnap.EdgeEndpointSnap = chkSnapVertex.Checked;
            osnap.EdgeMidpointSnap = chkSnapVertex.Checked;
            osnap.LineSnap = chkSnapLine.Checked;
            osnap.CircleSnap = chkSnapCircle.Checked;
            osnap.CircleCenterSnap = chkSnapCircle.Checked;
            osnap.CylinderSnap = chkSnapCircle.Checked;
            osnap.CommandText = "이펙트를 표시할 위치를 선택해주세요.";
        }

        private void AddPoint(VIZCore3DX.NET.Data.OsnapResult result)
        {
            VIZCore3DX.NET.Data.Vector3D position = result.Position;
            string positionText = string.Format("X:{0:0.###}, Y:{1:0.###}, Z:{2:0.###}", position.X, position.Y, position.Z);
            ListViewItem item = new ListViewItem(new string[] { (lvPoints.Items.Count + 1).ToString(), positionText, result.Type.ToString() });
            item.Tag = position;
            lvPoints.Items.Add(item);

            int pointLimit = GetPointLimit();
            while (pointLimit > 0 && lvPoints.Items.Count > pointLimit) lvPoints.Items.RemoveAt(0);
            RenumberPoints();
        }

        private void RenumberPoints()
        {
            for (int i = 0; i < lvPoints.Items.Count; i++) lvPoints.Items[i].Text = (i + 1).ToString();
        }

        private List<VIZCore3DX.NET.Data.Vector3D> PickedPoints()
        {
            return lvPoints.Items.Cast<ListViewItem>().Select(item => item.Tag as VIZCore3DX.NET.Data.Vector3D).Where(position => position != null).ToList();
        }

        // 종류마다 필요한 위치 개수입니다. 0 이면 개수 제한이 없습니다.
        private int GetPointLimit()
        {
            switch (SelectedKind())
            {
                case EffectKind.DimensionLine: return 2;
                case EffectKind.LineSet: return 0;
                case EffectKind.PathLine: return 0;
                case EffectKind.PointCloud: return 0;
                case EffectKind.PulseOutline: return 0;
                default: return 1;
            }
        }

        // 펄스 외곽선을 선택 노드로 만들 때는 오스냅 위치를 쓰지 않으므로 위치 칸을 끕니다.
        private void UpdatePointControls()
        {
            bool useOsnap = !IsOutlineFromNodes();

            lblPointGuide.Text = useOsnap ? PointGuide(SelectedKind()) : "뷰에서 노드를 선택하세요. 선택 노드의 경계 영역을 사용합니다.";
            chkSnapSurface.Enabled = useOsnap;
            chkSnapVertex.Enabled = useOsnap;
            chkSnapLine.Enabled = useOsnap;
            chkSnapCircle.Enabled = useOsnap;
            btnPickPoint.Enabled = useOsnap;
            btnRemovePoint.Enabled = useOsnap;
            btnClearPoints.Enabled = useOsnap;
            lvPoints.Enabled = useOsnap;
        }

        private string PointGuide(EffectKind kind)
        {
            switch (kind)
            {
                case EffectKind.DimensionLine: return "치수선의 시작점과 끝점을 고르세요. 최근 두 점만 유지됩니다.";
                case EffectKind.GasCloud: return "가스 확산 구름을 표시할 위치를 고르세요.";
                case EffectKind.GroundRing: return "지면 투영 링의 기준 지점을 고르세요.";
                case EffectKind.LineSet: return "선 무리에 사용할 점을 순서대로 고르세요.";
                case EffectKind.Marker: return "마커를 표시할 위치를 고르세요.";
                case EffectKind.ParticleEmitter: return "파티클 이미터를 표시할 위치를 고르세요.";
                case EffectKind.PathLine: return "흐르는 경로선을 구성할 점을 순서대로 고르세요.";
                case EffectKind.PointCloud: return "점 무리에 사용할 점을 고르세요.";
                case EffectKind.PulseOutline: return "펄스 외곽선의 시작점과 끝점을 한 쌍씩 고르세요.";
                case EffectKind.PulseSphere: return "확산 구를 표시할 위치를 고르세요.";
                case EffectKind.Spinner: return "회전 스피너를 표시할 위치를 고르세요.";
                case EffectKind.TextLabel: return "텍스트 라벨을 표시할 위치를 고르세요.";
                case EffectKind.Vapor: return "유증기를 표시할 위치를 고르세요.";
                default: return "용접 불꽃 효과를 표시할 위치를 고르세요.";
            }
        }
        #endregion

        #region 4. 생성
        // 고른 종류·옵션·위치로 효과를 만듭니다. 입력이 맞지 않으면 상태줄에 사유를 남깁니다.
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            EffectKind kind = SelectedKind();
            List<VIZCore3DX.NET.Data.Vector3D> points = PickedPoints();
            int pointLimit = GetPointLimit();
            if (pointLimit > 0 && points.Count != pointLimit) { SetStatus(string.Format("효과를 만들려면 위치를 {0}개 고르세요.", pointLimit)); return; }

            // 종류별 입력 검사에 걸리면 그 사유로 상태줄이 바뀌고, 그 밖의 실패는 이 문구가 남습니다.
            SetStatus("생성 실패 : 입력한 값과 등록 가능한 최대 개수를 확인하세요.");
            uint id = CreateEffect(kind, points);
            if (id == 0) return;

            SetStatus(string.Format("생성 : {0}-{1}", kind, id));
            lvPoints.Items.Clear();
        }

        private uint CreateEffect(EffectKind kind, List<VIZCore3DX.NET.Data.Vector3D> points)
        {
            switch (kind)
            {
                case EffectKind.DimensionLine: return CreateDimensionLine(points);
                case EffectKind.GasCloud: return CreateGasCloud(points);
                case EffectKind.GroundRing: return CreateGroundRing(points);
                case EffectKind.LineSet: return CreateLineSet(points);
                case EffectKind.Marker: return CreateMarker(points);
                case EffectKind.ParticleEmitter: return CreateParticleEmitter(points);
                case EffectKind.PathLine: return CreatePathLine(points);
                case EffectKind.PointCloud: return CreatePointCloud(points);
                case EffectKind.PulseOutline: return CreatePulseOutline(points);
                case EffectKind.PulseSphere: return CreatePulseSphere(points);
                case EffectKind.Spinner: return CreateSpinner(points);
                case EffectKind.TextLabel: return CreateTextLabel(points);
                case EffectKind.Vapor: return CreateVapor(points);
                case EffectKind.WeldingSpark: return CreateWeldingSpark(points);
                default: return 0;
            }
        }

        private uint CreateDimensionLine(List<VIZCore3DX.NET.Data.Vector3D> points)
        {
            VIZCore3DX.NET.Data.DimensionLineOptions options = new VIZCore3DX.NET.Data.DimensionLineOptions();
            options.Color = btnEffectColor.BackColor;
            options.LineWidth = (float)numOption1.Value;
            options.Decimals = (int)numOption2.Value;
            options.ShowText = chkOption1.Checked;
            options.AlwaysOnTop = chkOption2.Checked;

            return vizcore3dx.View.Effect.AddDimensionLine(points[0], points[1], options);
        }

        private uint CreateGasCloud(List<VIZCore3DX.NET.Data.Vector3D> points)
        {
            if (numOption1.Value >= numOption2.Value) { SetStatus("최대 반경은 시작 반경보다 크게 설정하세요."); return 0; }

            VIZCore3DX.NET.Data.GasCloudOptions options = new VIZCore3DX.NET.Data.GasCloudOptions();
            options.Color = btnEffectColor.BackColor;
            options.MinRadius = (float)numOption1.Value;
            options.MaxRadius = (float)numOption2.Value;
            options.Opacity = (float)numOption3.Value;

            return vizcore3dx.View.Effect.AddGasCloud(points[0], options);
        }

        private uint CreateGroundRing(List<VIZCore3DX.NET.Data.Vector3D> points)
        {
            VIZCore3DX.NET.Data.GroundRingOptions options = new VIZCore3DX.NET.Data.GroundRingOptions();
            options.Color = btnEffectColor.BackColor;
            options.RadiusMm = (float)numOption1.Value;
            options.LineWidth = (float)numOption2.Value;
            options.RippleCount = (int)numOption3.Value;
            options.ShowStem = chkOption1.Checked;
            options.AlwaysOnTop = chkOption2.Checked;

            return vizcore3dx.View.Effect.AddGroundRing(points[0], options);
        }

        // 선 무리는 좌표 배열(x, y, z 반복)로 넘깁니다. 폴리라인 크기를 비우면 점 2개씩 선분이 됩니다.
        private uint CreateLineSet(List<VIZCore3DX.NET.Data.Vector3D> points)
        {
            LineSetMode mode = (LineSetMode)cmbSpecial.SelectedItem;
            if (points.Count < 2) { SetStatus("선 무리에 사용할 점을 두 개 이상 고르세요."); return 0; }
            if (mode == LineSetMode.Segments && points.Count % 2 != 0) { SetStatus("점 2개씩 선분으로 표시하려면 짝수 개의 점을 고르세요."); return 0; }

            VIZCore3DX.NET.Data.DataSetOptions options = new VIZCore3DX.NET.Data.DataSetOptions();
            options.Color = btnEffectColor.BackColor;
            options.LineWidth = (float)numOption1.Value;
            options.Opacity = (float)numOption2.Value;
            options.AlwaysOnTop = chkOption1.Checked;

            int[] polylineSizes = mode == LineSetMode.Polyline ? new int[] { points.Count } : null;
            return vizcore3dx.View.Effect.AddLineSet(VIZCore3DX.NET.Data.Vector3D.GetVectorFloatArray(points), polylineSizes, null, options);
        }

        private uint CreateMarker(List<VIZCore3DX.NET.Data.Vector3D> points)
        {
            VIZCore3DX.NET.Data.MarkerOptions options = new VIZCore3DX.NET.Data.MarkerOptions();
            options.SizePx = (int)numOption1.Value;
            options.FadeStartMm = (float)numOption2.Value;
            options.FadeEndMm = (float)numOption3.Value;
            options.AlwaysOnTop = chkOption1.Checked;
            options.ShowOffscreenIndicator = chkOption2.Checked;
            options.Label = string.IsNullOrWhiteSpace(txtOptionText.Text) ? null : txtOptionText.Text;

            uint id = vizcore3dx.View.Effect.AddMarker(points[0], (VIZCore3DX.NET.Data.MarkerIcon)cmbSpecial.SelectedItem, options);
            vizcore3dx.View.Effect.SetMarkerVisible(chkMarkerVisible.Checked);
            return id;
        }

        private uint CreateParticleEmitter(List<VIZCore3DX.NET.Data.Vector3D> points)
        {
            VIZCore3DX.NET.Data.ParticleOptions options = new VIZCore3DX.NET.Data.ParticleOptions((VIZCore3DX.NET.Data.ParticlePreset)cmbSpecial.SelectedItem);
            options.StartColor = btnEffectColor.BackColor;
            options.ParticleSizeMm = (float)numOption1.Value;
            options.ConeAngleDeg = (float)numOption2.Value;

            return vizcore3dx.View.Effect.AddParticleEmitter(points[0], options);
        }

        private uint CreatePathLine(List<VIZCore3DX.NET.Data.Vector3D> points)
        {
            if (points.Count < 2) { SetStatus("흐르는 경로선을 구성할 점을 두 개 이상 고르세요."); return 0; }

            VIZCore3DX.NET.Data.PathLineOptions options = new VIZCore3DX.NET.Data.PathLineOptions();
            options.Color = btnEffectColor.BackColor;
            options.LineWidth = (float)numOption1.Value;
            options.PatternLengthMm = (float)numOption2.Value;
            options.GapRatio = (float)numOption3.Value;
            options.ShowArrow = chkOption1.Checked;
            options.AlwaysOnTop = chkOption2.Checked;

            return vizcore3dx.View.Effect.AddPathLine(points, options);
        }

        private uint CreatePointCloud(List<VIZCore3DX.NET.Data.Vector3D> points)
        {
            if (points.Count < 1) { SetStatus("점 무리에 사용할 점을 하나 이상 고르세요."); return 0; }

            VIZCore3DX.NET.Data.DataSetOptions options = new VIZCore3DX.NET.Data.DataSetOptions();
            options.Color = btnEffectColor.BackColor;
            options.PointSizeMm = (float)numOption1.Value;
            options.Opacity = (float)numOption2.Value;
            options.AlwaysOnTop = chkOption1.Checked;

            return vizcore3dx.View.Effect.AddPointCloud(points, null, options);
        }

        // 펄스 외곽선은 선택 노드의 경계 영역으로 만들거나, 오스냅으로 고른 시작점·끝점 쌍으로 만듭니다.
        private uint CreatePulseOutline(List<VIZCore3DX.NET.Data.Vector3D> points)
        {
            VIZCore3DX.NET.Data.PulseOutlineOptions options = new VIZCore3DX.NET.Data.PulseOutlineOptions();
            options.Color = btnEffectColor.BackColor;
            options.LineWidth = (float)numOption1.Value;
            options.AlwaysOnTop = chkOption1.Checked;

            if (IsOutlineFromNodes())
            {
                List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);
                if (nodes.Count == 0) { SetStatus("펄스 외곽선을 표시할 노드를 뷰에서 먼저 선택하세요."); return 0; }

                return vizcore3dx.View.Effect.AddPulseOutline(nodes[0].GetBoundBox(), options);
            }

            if (points.Count < 2) { SetStatus("펄스 외곽선의 시작점과 끝점을 두 개 이상 고르세요."); return 0; }
            if (points.Count % 2 != 0) { SetStatus("펄스 외곽선은 시작점과 끝점이 한 쌍이 되도록 짝수 개의 점을 고르세요."); return 0; }

            return vizcore3dx.View.Effect.AddPulseOutline(points, options);
        }

        private uint CreatePulseSphere(List<VIZCore3DX.NET.Data.Vector3D> points)
        {
            if (numOption1.Value >= numOption2.Value) { SetStatus("최대 반경은 시작 반경보다 크게 설정하세요."); return 0; }

            VIZCore3DX.NET.Data.PulseSphereOptions options = new VIZCore3DX.NET.Data.PulseSphereOptions();
            options.Color = btnEffectColor.BackColor;
            options.MinRadius = (float)numOption1.Value;
            options.MaxRadius = (float)numOption2.Value;
            options.Opacity = (float)numOption3.Value;

            return vizcore3dx.View.Effect.AddPulseSphere(points[0], options);
        }

        private uint CreateSpinner(List<VIZCore3DX.NET.Data.Vector3D> points)
        {
            VIZCore3DX.NET.Data.SpinnerOptions options = new VIZCore3DX.NET.Data.SpinnerOptions();
            options.Color = btnEffectColor.BackColor;
            options.SizePx = (int)numOption1.Value;
            options.ThicknessPx = (int)numOption2.Value;
            options.Progress = (float)numOption3.Value;
            options.ShowTrack = chkOption1.Checked;
            options.AlwaysOnTop = chkOption2.Checked;

            return vizcore3dx.View.Effect.AddSpinner(points[0], options);
        }

        private uint CreateTextLabel(List<VIZCore3DX.NET.Data.Vector3D> points)
        {
            if (string.IsNullOrWhiteSpace(txtOptionText.Text)) { SetStatus("텍스트 라벨에 표시할 문자열을 입력하세요."); return 0; }

            VIZCore3DX.NET.Data.TextLabelOptions options = new VIZCore3DX.NET.Data.TextLabelOptions();
            options.TextColor = btnEffectColor.BackColor;
            options.SizePx = (int)numOption1.Value;
            options.FadeStartMm = (float)numOption2.Value;
            options.FadeEndMm = (float)numOption3.Value;
            options.AlwaysOnTop = chkOption1.Checked;
            options.ShowOffscreenIndicator = chkOption2.Checked;

            uint id = vizcore3dx.View.Effect.AddTextLabel(points[0], txtOptionText.Text, options);
            vizcore3dx.View.Effect.SetTextLabelVisible(chkTextLabelVisible.Checked);
            return id;
        }

        private uint CreateVapor(List<VIZCore3DX.NET.Data.Vector3D> points)
        {
            VIZCore3DX.NET.Data.VaporOptions options = new VIZCore3DX.NET.Data.VaporOptions();
            options.Color = btnEffectColor.BackColor;
            options.StartRadius = (float)numOption1.Value;
            options.EndRadius = (float)numOption2.Value;
            options.Height = (float)numOption3.Value;

            return vizcore3dx.View.Effect.AddVapor(points[0], options);
        }

        private uint CreateWeldingSpark(List<VIZCore3DX.NET.Data.Vector3D> points)
        {
            return vizcore3dx.View.Effect.AddWeldingSpark(points[0]);
        }

        #endregion

        #region 5. 정리
        // 고른 종류의 효과를 모두 지웁니다. 지운 결과는 제거 이벤트로 목록에 반영됩니다.
        private void btnClearType_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.EffectType type = (VIZCore3DX.NET.Data.EffectType)cmbClearType.SelectedItem;
            ClearByType(type);
            SetStatus(string.Format("정리 : {0} 전부", type));
        }

        // 모든 종류의 효과를 지웁니다. 뷰 잠금으로 종류마다 다시 그리지 않게 합니다.
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            vizcore3dx.BeginUpdate();
            try
            {
                foreach (VIZCore3DX.NET.Data.EffectType type in Enum.GetValues(typeof(VIZCore3DX.NET.Data.EffectType)))
                    ClearByType(type);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            SetStatus("효과를 모두 지웠습니다.");
        }

        private void ClearByType(VIZCore3DX.NET.Data.EffectType type)
        {
            switch (type)
            {
                case VIZCore3DX.NET.Data.EffectType.Marker: vizcore3dx.View.Effect.ClearMarkers(); break;
                case VIZCore3DX.NET.Data.EffectType.TextLabel: vizcore3dx.View.Effect.ClearTextLabels(); break;
                case VIZCore3DX.NET.Data.EffectType.WeldingSpark: vizcore3dx.View.Effect.ClearWeldingSparks(); break;
                case VIZCore3DX.NET.Data.EffectType.GasCloud: vizcore3dx.View.Effect.ClearGasClouds(); break;
                case VIZCore3DX.NET.Data.EffectType.Vapor: vizcore3dx.View.Effect.ClearVapors(); break;
                case VIZCore3DX.NET.Data.EffectType.PulseSphere: vizcore3dx.View.Effect.ClearPulseSpheres(); break;
                case VIZCore3DX.NET.Data.EffectType.PulseOutline: vizcore3dx.View.Effect.ClearPulseOutlines(); break;
                case VIZCore3DX.NET.Data.EffectType.DimensionLine: vizcore3dx.View.Effect.ClearDimensionLines(); break;
                case VIZCore3DX.NET.Data.EffectType.PathLine: vizcore3dx.View.Effect.ClearPathLines(); break;
                case VIZCore3DX.NET.Data.EffectType.ParticleEmitter: vizcore3dx.View.Effect.ClearParticleEmitters(); break;
                case VIZCore3DX.NET.Data.EffectType.Spinner: vizcore3dx.View.Effect.ClearSpinners(); break;
                case VIZCore3DX.NET.Data.EffectType.GroundRing: vizcore3dx.View.Effect.ClearGroundRings(); break;
                case VIZCore3DX.NET.Data.EffectType.DataSet: vizcore3dx.View.Effect.ClearDataSets(); break;
            }
        }
        #endregion

        #region 목록
        // 종류별 조회일 때만 종류 콤보를 켭니다.
        private void cmbQueryMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbQueryType.Enabled = Equals(cmbQueryMode.SelectedItem, QueryMode.ByType);
        }

        // 조회 방식대로 효과 목록을 다시 읽습니다.
        private void btnRefreshEffects_Click(object sender, EventArgs e)
        {
            RefreshEffectList();
        }

        // 목록에서 고른 효과를 종류에 맞는 제거 함수로 지웁니다.
        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.EffectItem effect = SelectedEffect();
            if (effect == null) { SetStatus("제거할 효과를 목록에서 고르세요."); return; }

            bool removed = RemoveByType(effect);
            SetStatus(removed ? string.Format("제거 : {0}-{1}", effect.Type, effect.ID) : "선택한 효과를 제거하지 못했습니다.");
        }

        // 마커 전체의 표시 여부를 바꿉니다.
        private void chkMarkerVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (vizcore3dx == null || vizcore3dx.View == null || vizcore3dx.View.Effect == null) return;

            vizcore3dx.View.Effect.SetMarkerVisible(chkMarkerVisible.Checked);
        }

        // 텍스트 라벨 전체의 표시 여부를 바꿉니다.
        private void chkTextLabelVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (vizcore3dx == null || vizcore3dx.View == null || vizcore3dx.View.Effect == null) return;

            vizcore3dx.View.Effect.SetTextLabelVisible(chkTextLabelVisible.Checked);
        }

        // 목록에서 고른 회전 스피너의 진행률(%)을 바꿉니다. 계속 회전을 켜면 -1 을 넘깁니다.
        private void btnSetSpinnerProgress_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.EffectItem effect = SelectedEffect();
            if (effect == null || effect.Type != VIZCore3DX.NET.Data.EffectType.Spinner) { SetStatus("효과 목록에서 회전 스피너를 고르세요."); return; }

            float progress = chkSpinnerContinuous.Checked ? -1.0f : (float)numSpinnerProgress.Value / 100.0f;
            bool result = vizcore3dx.View.Effect.SetSpinnerProgress(effect.ID, progress);
            SetStatus(result ? string.Format("진행률 : {0}-{1} = {2}", effect.Type, effect.ID, progress) : "회전 스피너의 진행률을 바꾸지 못했습니다.");
        }

        // 용접 불꽃의 바닥 튕김과 등록 가능한 지점 최대 개수를 바꿉니다.
        private void btnApplyWeldingSettings_Click(object sender, EventArgs e)
        {
            vizcore3dx.View.Effect.WeldingSparkBounce = chkWeldingBounce.Checked;
            vizcore3dx.View.Effect.WeldingSparkCapacity = (int)numWeldingCapacity.Value;

            RefreshEffectStatus();
            SetStatus("용접 불꽃 설정을 적용했습니다.");
        }

        private bool RemoveByType(VIZCore3DX.NET.Data.EffectItem effect)
        {
            switch (effect.Type)
            {
                case VIZCore3DX.NET.Data.EffectType.Marker: return vizcore3dx.View.Effect.RemoveMarker(effect.ID);
                case VIZCore3DX.NET.Data.EffectType.TextLabel: return vizcore3dx.View.Effect.RemoveTextLabel(effect.ID);
                case VIZCore3DX.NET.Data.EffectType.WeldingSpark: return vizcore3dx.View.Effect.RemoveWeldingSpark(effect.ID);
                case VIZCore3DX.NET.Data.EffectType.GasCloud: return vizcore3dx.View.Effect.RemoveGasCloud(effect.ID);
                case VIZCore3DX.NET.Data.EffectType.Vapor: return vizcore3dx.View.Effect.RemoveVapor(effect.ID);
                case VIZCore3DX.NET.Data.EffectType.PulseSphere: return vizcore3dx.View.Effect.RemovePulseSphere(effect.ID);
                case VIZCore3DX.NET.Data.EffectType.PulseOutline: return vizcore3dx.View.Effect.RemovePulseOutline(effect.ID);
                case VIZCore3DX.NET.Data.EffectType.DimensionLine: return vizcore3dx.View.Effect.RemoveDimensionLine(effect.ID);
                case VIZCore3DX.NET.Data.EffectType.PathLine: return vizcore3dx.View.Effect.RemovePathLine(effect.ID);
                case VIZCore3DX.NET.Data.EffectType.ParticleEmitter: return vizcore3dx.View.Effect.RemoveParticleEmitter(effect.ID);
                case VIZCore3DX.NET.Data.EffectType.Spinner: return vizcore3dx.View.Effect.RemoveSpinner(effect.ID);
                case VIZCore3DX.NET.Data.EffectType.GroundRing: return vizcore3dx.View.Effect.RemoveGroundRing(effect.ID);
                case VIZCore3DX.NET.Data.EffectType.DataSet: return vizcore3dx.View.Effect.RemoveDataSet(effect.ID);
                default: return false;
            }
        }

        private VIZCore3DX.NET.Data.EffectItem SelectedEffect()
        {
            if (lvEffects.SelectedItems.Count == 0) return null;

            return lvEffects.SelectedItems[0].Tag as VIZCore3DX.NET.Data.EffectItem;
        }

        // 뷰어의 효과 목록을 조회 방식대로 다시 채웁니다.
        private void RefreshEffectList()
        {
            if (vizcore3dx == null || vizcore3dx.View == null || vizcore3dx.View.Effect == null) return;

            List<VIZCore3DX.NET.Data.EffectItem> effects = Equals(cmbQueryMode.SelectedItem, QueryMode.ByType)
                ? vizcore3dx.View.Effect.GetEffects((VIZCore3DX.NET.Data.EffectType)cmbQueryType.SelectedItem)
                : vizcore3dx.View.Effect.GetEffects();

            lvEffects.BeginUpdate();
            lvEffects.Items.Clear();
            foreach (VIZCore3DX.NET.Data.EffectItem effect in effects)
            {
                string position = effect.Position == null ? string.Empty : effect.Position.ToString();
                ListViewItem item = new ListViewItem(new string[] { string.Format("{0}-{1}", effect.Type, effect.ID), effect.Type.ToString(), position, effect.Summary ?? string.Empty });
                item.Tag = effect;
                lvEffects.Items.Add(item);
            }
            lvEffects.EndUpdate();

            grpList.Text = string.Format("효과 목록 ({0}개)", effects.Count);
        }
        #endregion

        #region 상태·이벤트
        // 종류별 개수와 등록 가능한 최대 개수를 보여주고, 용접 불꽃 설정 칸을 현재 값에 맞춥니다.
        private void RefreshEffectStatus()
        {
            if (vizcore3dx == null || vizcore3dx.View == null || vizcore3dx.View.Effect == null) return;

            txtEffectCount.Text = "[개수]" + Environment.NewLine + CountText() + Environment.NewLine + Environment.NewLine
                + "[등록 가능 최대]" + Environment.NewLine + CapacityText();

            chkWeldingBounce.Checked = vizcore3dx.View.Effect.WeldingSparkBounce;

            int weldingCapacity = vizcore3dx.View.Effect.WeldingSparkCapacity;
            if (weldingCapacity < numWeldingCapacity.Minimum) weldingCapacity = (int)numWeldingCapacity.Minimum;
            if (weldingCapacity > numWeldingCapacity.Maximum) weldingCapacity = (int)numWeldingCapacity.Maximum;
            numWeldingCapacity.Value = weldingCapacity;
        }

        private string CountText()
        {
            return string.Join(Environment.NewLine, new string[]
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
        }

        private string CapacityText()
        {
            VIZCore3DX.NET.Data.EffectCapacity capacity = vizcore3dx.View.Effect.Capacity;

            return string.Join(Environment.NewLine, new string[]
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
        }

        // 추가·제거된 효과를 이벤트 목록 맨 위에 쌓습니다. 500줄을 넘으면 오래된 줄부터 버립니다.
        private void LogEvents(IEnumerable<VIZCore3DX.NET.Data.EffectItem> items, string action)
        {
            foreach (VIZCore3DX.NET.Data.EffectItem item in items) lstEvents.Items.Insert(0, string.Format("{0} : {1}-{2}", action, item.Type, item.ID));

            while (lstEvents.Items.Count > 500) lstEvents.Items.RemoveAt(lstEvents.Items.Count - 1);
        }
        #endregion

        #region Helpers
        // 모델이 열려 있지 않으면 상태 문구를 남기고 false 를 돌려줍니다.
        private bool IsModelOpened()
        {
            if (vizcore3dx.Model.IsOpen()) return true;

            SetStatus("먼저 모델을 여세요.");
            return false;
        }

        private void SetStatus(string message)
        {
            lblStatus.Text = message;
        }

        private void RunOnUi(Action action)
        {
            if (InvokeRequired) BeginInvoke(action);
            else action();
        }

        private EffectKind SelectedKind()
        {
            return cmbEffectType.SelectedItem is EffectKind ? (EffectKind)cmbEffectType.SelectedItem : EffectKind.DimensionLine;
        }

        private bool IsOutlineFromNodes()
        {
            return SelectedKind() == EffectKind.PulseOutline && Equals(cmbSpecial.SelectedItem, OutlineSource.SelectedNodes);
        }

        private void ShowColor(string text, Color color)
        {
            lblColor.Visible = btnEffectColor.Visible = true;
            lblColor.Text = text;
            btnEffectColor.BackColor = color;
        }

        private void ShowNumber(Label label, NumericUpDown control, string text, decimal minimum, decimal maximum, decimal value, int decimalPlaces)
        {
            label.Visible = control.Visible = true;
            label.Text = text;
            SetNumber(control, minimum, maximum, value, decimalPlaces);
        }

        private void ShowCheck(CheckBox control, string text, bool value)
        {
            control.Visible = true;
            control.Text = text;
            control.Checked = value;
        }

        // 종류마다 다른 추가 설정은 enum 값으로 채웁니다.
        private void ShowSpecial(string text, Type enumType, object selected)
        {
            lblSpecial.Visible = cmbSpecial.Visible = true;
            lblSpecial.Text = text;
            cmbSpecial.DataSource = Enum.GetValues(enumType);
            cmbSpecial.SelectedItem = selected;
        }

        private void ShowText(string text, string value)
        {
            lblText.Visible = txtOptionText.Visible = true;
            lblText.Text = text;
            txtOptionText.Text = value;
        }

        // 범위를 먼저 바꾼 뒤 값을 범위 안으로 맞춰 넣습니다.
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
