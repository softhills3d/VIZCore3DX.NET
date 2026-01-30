using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.SearchSpace
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// VIZCore3DX.NET Control
        /// </summary>
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        /// <summary>
        /// 결과 업데이트 중인지 여부
        /// </summary>
        private bool _isResultUpdating = false;

        /// <summary>
        /// 검색된 결과 리스트
        /// </summary>
        private List<Node> searchResult = new List<Node>();

        /// <summary>
        /// 바운드 박스 
        /// </summary>
        private BoundBox3D BoundingBox;

        public FrmMain()
        {
            InitializeComponent();

            VIZCore3DX.NET.ModuleInitializer.Run();

            // VIZCore3DX.NET Control 생성 및 초기화
            vizcore3dx = new VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;

            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3D_OnInitializedVIZCore3D;

            splitContainer2.Panel1.Controls.Add(vizcore3dx);

            InitializeVIZCore3DXEvent();

            // 바운드 박스 초기화
            BoundingBox = new BoundBox3D();
        }

        private void VIZCore3D_OnInitializedVIZCore3D(object sender, EventArgs e)
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
            //InitializeVIZCore3DXEvent();
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
            // 설정 - Body 유형 보기 옵션
            // ================================================================
            vizcore3dx.Model.EnableBody = true;

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();

        }

        /// <summary>
        /// 이벤트 초기화
        /// </summary>
        private void InitializeVIZCore3DXEvent()
        {
            // 키 다운 이벤트 (영역 선택 완료 이벤트)
            vizcore3dx.OnVIZCore3DXKeyDown += Vizcore3dx_OnVIZCore3DXKeyDown;
        }

        private void Vizcore3dx_OnVIZCore3DXKeyDown(object sender, Event.EventManager.VIZCoreKeyDownEventArgs e)
        {
            // 영역 선택이 완료되었을 때
            if (vizcore3dx.View.SelectSpatialSpace != null)
            {
                // BoundBox 값 표시
                SetBoundingBox(vizcore3dx.View.SelectSpatialSpace);
            }
        }

        /// <summary>
        /// 모델 열기
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            // 모델 다이얼로그 통해 열기
            vizcore3dx.Model.OpenFileDialog();
        }

        /// <summary>
        /// 검색 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _isResultUpdating = true;

            vizcore3dx.ShowWaitForm();

            gvResult.SuspendLayout();
            gvResult.Rows.Clear();
            vizcore3dx.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);

            // 검색 옵션에 따른 검색
            if (ckFullyContained.Checked)
            {
                // 바운드 박스 기준 분할
                //  vizcore3dx.Object3D.SplitMesh(BoundingBox);
                // 완전히 포함된 개체 검색
                searchResult = vizcore3dx.Object3D.FromZone(BoundingBox, BoundBoxSearchOption.FullyContained, false, true);
            }
            else if (ckIncludingPart.Checked)
            {
                // 걸쳐있는 개체 포함 검색
                searchResult = vizcore3dx.Object3D.FromZone(BoundingBox, BoundBoxSearchOption.IncludingPart, false, true);
            }
            else if (ckIncludingPartOnly.Checked)
            {
                // 걸쳐있는 개체만 검색
                searchResult = vizcore3dx.Object3D.FromZone(BoundingBox, BoundBoxSearchOption.IncludingPartOnly, false, true);
            }

            gvResult.RowCount = searchResult.Count;

            gvResult.ClearSelection();
            gvResult.CurrentCell = null;
            gvResult.ResumeLayout();

            // 검색된 개체 선택 및 X-Ray 모드 설정
            vizcore3dx.View.XRay.Enable = true;
            vizcore3dx.View.XRay.ColorType = XRayColorTypes.OBJECT_COLOR;
            vizcore3dx.View.XRay.Select(searchResult, true);

            vizcore3dx.CloseWaitForm();

            _isResultUpdating = false;
        }

        private void SetBoundingBox(Data.BoundBox3D boundingBox)
        {
            if (boundingBox == null) return;

            // 바운드 박스 설정
            BoundingBox = boundingBox;

            if (!BoundingBox.IsValid()) return;

            numMinX.Value = (decimal)boundingBox.MinX;
            numMinY.Value = (decimal)boundingBox.MinY;
            numMinZ.Value = (decimal)boundingBox.MinZ;

            numMaxX.Value = (decimal)boundingBox.MaxX;
            numMaxY.Value = (decimal)boundingBox.MaxY;
            numMaxZ.Value = (decimal)boundingBox.MaxZ;

            // Selection Box 추가
            vizcore3dx.SelectionBox.Add(BoundingBox, System.Drawing.Color.FromArgb(100, 192, 192, 192), System.Drawing.Color.Black, "");
        }

        /// <summary>
        /// 바운드 박스 설정 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetBoundbox_Click(object sender, EventArgs e)
        {
            gvResult.Rows.Clear();
            gvResult.ClearSelection();
            vizcore3dx.View.XRay.Enable = false;

            // 선택 박스 초기화
            vizcore3dx.SelectionBox.Clear();

            // 영역 설정
            vizcore3dx.View.GetSelectSpatialSpace();
        }

        private void gvResult_CellValueChanged(object sender, DataGridViewCellValueEventArgs e)
        {
            if (searchResult.Count == 0) return;

            // 현재 그리드 행(Row)에 해당하는 원본 데이터 아이템 추출
            var resultItem = searchResult[e.RowIndex];

            switch (e.ColumnIndex)
            {
                case 0: // Entity ID
                    e.Value = resultItem.EntityID.ToString();
                    break;

                case 1: // Index
                    e.Value = resultItem.Index.ToString();
                    break;

                case 2: // Node Name
                    var node = vizcore3dx.Object3D.GetNodes(resultItem.EntityID, resultItem.Index);
                    e.Value = (node != null) ? node.NodeName : "";
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 체크박스 변경 이벤트 (검색 옵션)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                if (sender == ckFullyContained)
                {
                    ckIncludingPart.Checked = false;
                    ckIncludingPartOnly.Checked = false;
                }
                else if (sender == ckIncludingPart)
                {
                    ckFullyContained.Checked = false;
                    ckIncludingPartOnly.Checked = false;
                }
                else if (sender == ckIncludingPartOnly)
                {
                    ckFullyContained.Checked = false;
                    ckIncludingPart.Checked = false;
                }
            }
        }

        /// <summary>
        /// 검색 결과 선택 변경 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvResult_SelectionChanged(object sender, EventArgs e)
        {
            if (gvResult.SelectedRows.Count == 0) return;
            if (_isResultUpdating) return;

            int rowIndex = gvResult.SelectedRows[0].Index;

            if (rowIndex >= 0 && rowIndex < searchResult.Count)
            {
                Node item = searchResult[rowIndex] as Node;

                if (item != null)
                {
                    vizcore3dx.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);
                    vizcore3dx.Object3D.Select(item, true);
                }
            }

        }

        /// <summary>
        /// 검색 결과 내보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            // 바운드 박스 외부 개체 삭제
            vizcore3dx.BeginUpdate();
            vizcore3dx.Object3D.Select(searchResult, true);
            vizcore3dx.Object3D.Select(Object3dSelectionModes.INVERT_SELECTION);
            List<Node> nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_ALL);
            vizcore3dx.Object3D.Delete(nodes);
            vizcore3dx.EndUpdate();

            // VIZX 형식으로 저장
            bool result = vizcore3dx.Model.SaveAsVIZX("C:\\Temp\\SearchSpace.vizx");
            if (result == false) return;

            // 모델 닫기
            vizcore3dx.Model.Close();

            // 저장한 파일 다시 열기
            vizcore3dx.View.XRay.Enable = false;
            vizcore3dx.Model.Open("C:\\Temp\\SearchSpace.vizx");
        }
    }
}
