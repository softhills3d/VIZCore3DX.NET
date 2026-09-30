using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.SectionBoxControl
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// VIZCore3DX.NET Control
        /// </summary>
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        /// <summary>
        /// Section 정보
        /// </summary>
        public VIZCore3DX.NET.Data.SectionItem Section { get; set; }

        /// <summary>
        /// 단면 경계선 색상 (숨김 시에도 표시 색상 보관)
        /// </summary>
        private Color boundaryColor = Color.Red;

        public FrmMain()
        {
            InitializeComponent();

            // VIZCore3DX Module Init
            VIZCore3DX.NET.ModuleInitializer.Run();
            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            // Panel Control Add
            splitContainer1.Panel2.Controls.Add(vizcore3dx);
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

            InitializeVIZCore3DXEvent();
            InitializeBoundaryStyle();
        }

        /// <summary>
        /// 현재 단면 기본 스타일의 경계선 색상을 UI에 반영
        /// </summary>
        private void InitializeBoundaryStyle()
        {
            SectionStyle style = vizcore3dx.Section.GetStyle();
            if (style == null) return;

            Color color = style.BoundaryStrokeColor;

            // 알파 0 = 경계선 숨김 상태
            chkBoundaryVisible.CheckedChanged -= chkBoundaryVisible_CheckedChanged;
            chkBoundaryVisible.Checked = color.A != 0;
            chkBoundaryVisible.CheckedChanged += chkBoundaryVisible_CheckedChanged;

            if (color.A != 0) boundaryColor = color;
            pnlBoundaryColor.BackColor = boundaryColor;
        }

        /// <summary>
        /// VIZCore3DX.NET 전역 이벤트 초기화
        /// </summary>
        private void InitializeVIZCore3DXEvent()
        {
            // Section 관련 이벤트
            vizcore3dx.Section.OnSectionEvent += VIZCore3DX_OnSectionEvent;
        }

        /// <summary>
        /// Section Box Control 이벤트
        /// 링크 참고 https://docs.softhills.net/VIZCore3DX.NET/api/VIZCore3DX.NET/VIZCore3DX.NET.Manager/SectionManager/Events/OnSectionEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VIZCore3DX_OnSectionEvent(object sender, EventManager.SectionEventArgs e)
        {
            // Section Box 이동 이벤트
            if (e.EventType == Manager.SectionManager.EventType.Moved)
            {
                // Section Box의 바운드 박스(사이즈) 정보 가져오기 
                VIZCore3DX.NET.Data.BoundBox3D bbox = e.Section.BoundBox;

                // Min 값
                txtMinX.Text = bbox.MinX.ToString();
                txtMinY.Text = bbox.MinY.ToString();
                txtMinZ.Text = bbox.MinZ.ToString();

                // Max 값
                txtMaxX.Text = bbox.MaxX.ToString();
                txtMaxY.Text = bbox.MaxY.ToString();
                txtMaxZ.Text = bbox.MaxZ.ToString();
            }
        }

        /// <summary>
        /// 모델 오픈 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            // 모델 다이얼로그 통해 열기
            vizcore3dx.Model.OpenFileDialog();
        }

        /// <summary>
        /// Section Box Add 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddBox_Click(object sender, EventArgs e)
        {
            // 모델 오픈 검증
            if (vizcore3dx.Model.IsOpen() == false) return;

            NewSectionBox();
        }

        /// <summary>
        /// Section Box Show 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBoxShow_Click(object sender, EventArgs e)
        {
            // 모델 오픈 및 Section 검증
            if (vizcore3dx.Model.IsOpen() == false || Section == null) return;

            // Section Box 보이기
            vizcore3dx.Section.Show(Section, true);
        }

        /// <summary>
        /// Section Box Hide 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBoxHide_Click(object sender, EventArgs e)
        {
            // 모델 오픈 및 Section 검증
            if (vizcore3dx.Model.IsOpen() == false || Section == null) return;

            // Section Box 숨기기
            vizcore3dx.Section.Show(Section, false);
        }

        /// <summary>
        /// Section Box Reset 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBoxReset_Click(object sender, EventArgs e)
        {
            // 모델 오픈 및 Section 검증
            if (vizcore3dx.Model.IsOpen() == false || Section == null) return;

            // Section 삭제 후 재생성
            vizcore3dx.Section.Delete(Section);
            NewSectionBox();
        }

        /// <summary>
        /// Section Box Min Resize 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinResize_Click(object sender, EventArgs e)
        {
            // 모델 오픈 및 Section 검증
            if (vizcore3dx.Model.IsOpen() == false || Section == null) return;

            // Section Box의 바운드 박스(사이즈) 정보 가져오기 
            VIZCore3DX.NET.Data.BoundBox3D bbox = Section.BoundBox;

            // Min 값 지정 하여 Section Box 반영
            bbox.MinX = Convert.ToSingle(txtMinX.Text);
            bbox.MinY = Convert.ToSingle(txtMinY.Text);
            bbox.MinZ = Convert.ToSingle(txtMinZ.Text);

            vizcore3dx.Section.SetBoxSize(Section.ID, bbox);
            vizcore3dx.Update();
        }

        /// <summary>
        /// Section Box Max Resize 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaxResize_Click(object sender, EventArgs e)
        {
            // 모델 오픈 및 Section 검증
            if (vizcore3dx.Model.IsOpen() == false || Section == null) return;

            // Section Box의 바운드 박스(사이즈) 정보 가져오기 
            VIZCore3DX.NET.Data.BoundBox3D bbox = Section.BoundBox;

            // Min 값 지정 하여 Section Box 반영
            bbox.MaxX = Convert.ToSingle(txtMaxX.Text);
            bbox.MaxY = Convert.ToSingle(txtMaxY.Text);
            bbox.MaxZ = Convert.ToSingle(txtMaxZ.Text);

            vizcore3dx.Section.SetBoxSize(Section.ID, bbox);
            vizcore3dx.Update();
        }

        /// <summary>
        /// Section Box Min X Offset 증가 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinMoveX_P_Click(object sender, EventArgs e)
        {
            MoveOffset(SectionPlanePositionType.XMin, txtMinX, txtMoveMinOffset, true);
        }

        /// <summary>
        /// Section Box Min X Offset 감소 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinMoveX_M_Click(object sender, EventArgs e)
        {
            MoveOffset(SectionPlanePositionType.XMin, txtMinX, txtMoveMinOffset, false);
        }

        /// <summary>
        /// Section Box Min Y Offset 증가 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinMoveY_P_Click(object sender, EventArgs e)
        {
            MoveOffset(SectionPlanePositionType.YMin, txtMinY, txtMoveMinOffset, true);
        }

        /// <summary>
        /// Section Box Min Y Offset 감소 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinMoveY_M_Click(object sender, EventArgs e)
        {
            MoveOffset(SectionPlanePositionType.YMin, txtMinY, txtMoveMinOffset, false);
        }

        /// <summary>
        /// Section Box Min Z Offset 증가 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinMoveZ_P_Click(object sender, EventArgs e)
        {
            MoveOffset(SectionPlanePositionType.ZMin, txtMinZ, txtMoveMinOffset, true);
        }

        /// <summary>
        /// Section Box Min Z Offset 감소 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinMoveZ_M_Click(object sender, EventArgs e)
        {
            MoveOffset(SectionPlanePositionType.ZMin, txtMinZ, txtMoveMinOffset, false);
        }

        /// <summary>
        /// Section Box Max X Offset 증가 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaxMoveX_P_Click(object sender, EventArgs e)
        {
            MoveOffset(SectionPlanePositionType.XMax, txtMaxX, txtMoveMaxOffset, true);
        }

        /// <summary>
        /// Section Box Max X Offset 감소 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaxMoveX_M_Click(object sender, EventArgs e)
        {
            MoveOffset(SectionPlanePositionType.XMax, txtMaxX, txtMoveMaxOffset, false);
        }

        /// <summary>
        /// Section Box Max Y Offset 증가 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaxMoveY_P_Click(object sender, EventArgs e)
        {
            MoveOffset(SectionPlanePositionType.YMax, txtMaxY, txtMoveMaxOffset, true);
        }

        /// <summary>
        /// Section Box Max Y Offset 감소 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaxMoveY_M_Click(object sender, EventArgs e)
        {
            MoveOffset(SectionPlanePositionType.YMax, txtMaxY, txtMoveMaxOffset, false);
        }

        /// <summary>
        /// Section Box Max Z Offset 증가 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaxMoveZ_P_Click(object sender, EventArgs e)
        {
            MoveOffset(SectionPlanePositionType.ZMax, txtMaxZ, txtMoveMaxOffset, true);
        }

        /// <summary>
        /// Section Box Max Z Offset 감소 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaxMoveZ_M_Click(object sender, EventArgs e)
        {
            MoveOffset(SectionPlanePositionType.ZMax, txtMaxZ, txtMoveMaxOffset, false);
        }


        /// <summary>
        /// Section Box Min/Max Offset 이동 함수
        /// </summary>
        /// <param name="planeType">이동할 Section 방향 (XMin, XMax, YMin, YMax 등)</param>
        /// <param name="minMaxValue">현재 위치 값을 표시하는 TextBox</param>
        /// <param name="offsetValue">적용 할 offset TextBox</param>
        /// <param name="increase">true = 증가, false = 감소</param>
        private void MoveOffset(SectionPlanePositionType planeType, TextBox minMaxValue, TextBox offsetValue, bool increase)
        {
            // 모델 오픈 및 Section 검증
            if (vizcore3dx.Model.IsOpen() == false || Section == null) return;

            // offset 값 가져오기
            float offset = Convert.ToSingle(offsetValue.Text);

            // 현재 Min/Max 값 가져오기
            float current = Convert.ToSingle(minMaxValue.Text);

            // 증가 또는 감소 연산
            current += increase ? offset : -offset;

            // 값 적용
            minMaxValue.Text = current.ToString();
            vizcore3dx.Section.SetBoxPlaneSize(Section.ID, (int)planeType, current);
            vizcore3dx.Update();
        }


        /// <summary>
        /// Section Box 새로 생성
        /// </summary>
        private void NewSectionBox()
        {
            // Section Box 추가
            Section = vizcore3dx.Section.AddBox();

            // Section Box의 바운드 박스(사이즈) 정보 가져오기 
            VIZCore3DX.NET.Data.BoundBox3D bbox = Section.BoundBox;

            // Min 값
            txtMinX.Text = bbox.MinX.ToString();
            txtMinY.Text = bbox.MinY.ToString();
            txtMinZ.Text = bbox.MinZ.ToString();

            // Max 값
            txtMaxX.Text = bbox.MaxX.ToString();
            txtMaxY.Text = bbox.MaxY.ToString();
            txtMaxZ.Text = bbox.MaxZ.ToString();

            // View 업데이트
            vizcore3dx.Update();
        }

        /// <summary>
        /// Section 목록 JSON 파일 저장 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSectionSaveJson_Click(object sender, EventArgs e)
        {
            // 모델 오픈 검증
            if (vizcore3dx.Model.IsOpen() == false) return;

            if (vizcore3dx.Section.Sections.Count == 0)
            {
                MessageBox.Show("저장할 단면이 없습니다.", "SectionBoxControl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Section 목록을 JSON 문자열로 변환
            string json = vizcore3dx.Section.ToJson();

            if (string.IsNullOrEmpty(json))
            {
                ShowOperationFailure("단면 JSON 문자열 생성에 실패했습니다.");
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "JSON 파일 (*.json)|*.json|모든 파일 (*.*)|*.*";
                dialog.FileName = "Section.json";
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                File.WriteAllText(dialog.FileName, json, Encoding.UTF8);
            }
        }

        /// <summary>
        /// Section 목록 JSON 파일 불러오기 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSectionLoadJson_Click(object sender, EventArgs e)
        {
            // 모델 오픈 검증
            if (vizcore3dx.Model.IsOpen() == false) return;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "JSON 파일 (*.json)|*.json|모든 파일 (*.*)|*.*";
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                string json = File.ReadAllText(dialog.FileName, Encoding.UTF8);

                // JSON 문자열로 Section 목록 복원
                if (!vizcore3dx.Section.FromJson(json))
                {
                    ShowOperationFailure("단면 JSON 불러오기에 실패했습니다.");
                    return;
                }
            }

            // 복원된 Section Box를 현재 제어 대상으로 지정
            Section = null;
            foreach (SectionItem item in vizcore3dx.Section.Sections)
            {
                if (item != null && item.IsValid && item.SectionType == Manager.SectionManager.SectionTypes.SECTION_BOX) Section = item;
            }

            if (Section != null) UpdateBoxText(Section.BoundBox);
            vizcore3dx.Update();
        }

        /// <summary>
        /// 단면 경계선 표시 여부 변경 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBoundaryVisible_CheckedChanged(object sender, EventArgs e)
        {
            ApplyBoundaryColor();
        }

        /// <summary>
        /// 단면 경계선 색상 선택 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBoundaryColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = boundaryColor;
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                boundaryColor = dialog.Color;
                pnlBoundaryColor.BackColor = boundaryColor;
            }

            ApplyBoundaryColor();
        }

        /// <summary>
        /// 단면 기본 스타일에 경계선 색상 적용 (숨김 = 알파 0)
        /// ※ 기존 ShowSectionLine 속성은 삭제되어 SectionStyle.BoundaryStrokeColor로 대체
        /// </summary>
        private void ApplyBoundaryColor()
        {
            SectionStyle style = vizcore3dx.Section.GetStyle();
            if (style == null) return;

            style.BoundaryStrokeColor = chkBoundaryVisible.Checked ? boundaryColor : Color.FromArgb(0, boundaryColor);
            vizcore3dx.Section.SetStyle(style);
            vizcore3dx.Update();
        }

        /// <summary>
        /// Section Box 바운드 박스 값을 Min/Max TextBox에 표시
        /// </summary>
        /// <param name="bbox">바운드 박스</param>
        private void UpdateBoxText(VIZCore3DX.NET.Data.BoundBox3D bbox)
        {
            // Min 값
            txtMinX.Text = bbox.MinX.ToString();
            txtMinY.Text = bbox.MinY.ToString();
            txtMinZ.Text = bbox.MinZ.ToString();

            // Max 값
            txtMaxX.Text = bbox.MaxX.ToString();
            txtMaxY.Text = bbox.MaxY.ToString();
            txtMaxZ.Text = bbox.MaxZ.ToString();
        }

        /// <summary>
        /// 실패 메시지와 LastOperationStatus 원인 표시
        /// </summary>
        /// <param name="message">실패 메시지</param>
        private void ShowOperationFailure(string message)
        {
            OperationStatus status = vizcore3dx.Section.LastOperationStatus;
            string detail = status == null ? string.Empty : string.Format("\n원인 : {0}", status.Result);

            MessageBox.Show(message + detail, "SectionBoxControl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
