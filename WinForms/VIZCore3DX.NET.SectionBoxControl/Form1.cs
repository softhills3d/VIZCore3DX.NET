using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.SectionBoxControl
{
    public partial class Form1: Form
    {
        /// <summary>
        /// VIZCore3DX.NET Control
        /// </summary>
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        /// <summary>
        /// Section 정보
        /// </summary>
        public VIZCore3DX.NET.Data.SectionItem Section { get; set; }

        public Form1()
        {
            InitializeComponent();

            // VIZCore3DX Module Init
            VIZCore3DX.NET.ModuleInitializer.Run();
            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3D_OnInitializedVIZCore3D;

            // Panel Control Add
            splitContainer1.Panel2.Controls.Add(vizcore3dx);
        }

        private void VIZCore3D_OnInitializedVIZCore3D(object sender, EventArgs e)
        {
            // 라이선스 서버를 통한 인증
            vizcore3dx.License.LicenseServer("192.168.0.215", 8901);

            InitializeVIZCore3DXEvent();
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
        /// 링크 참고 https://softhills.net/SHDC/VIZCore3DX.NET/Help/html/E_VIZCore3DX_NET_Manager_SectionManager_OnSectionEvent.htm
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
            vizcore3dx.Section.SetBoxPlaneSize(Section.ID, planeType, current);
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

    }
}
