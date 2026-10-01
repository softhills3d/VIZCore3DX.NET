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

            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;

            splitContainer2.Panel1.Controls.Add(vizcore3dx);

            InitializeVIZCore3DXEvent();

            // 바운드 박스 초기화
            BoundingBox = new BoundBox3D();
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
            // 영역 선택 완료 이벤트
            vizcore3dx.View.OnSelectionBoxCreateFinished += (isSuccess) =>
            {
                if (isSuccess) SetBoundingBox(vizcore3dx.View.SelectSpatialSpace);
                else MessageBox.Show("선택 실패 !!!");
            };
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
            if (vizcore3dx.Model.IsOpen() == false) return;

            if (BoundingBox == null || !BoundingBox.IsValid())
            {
                MessageBox.Show("바운드 박스를 먼저 설정하세요.", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isResultUpdating = true;

            vizcore3dx.ShowWaitForm();

            gvResult.SuspendLayout();
            gvResult.Rows.Clear();
            vizcore3dx.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);

            // 검색 옵션 미선택 시 이전 결과 초기화
            searchResult = new List<Node>();

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
            if (vizcore3dx.SelectionBox.Items.Count > 0) return;

            if (!boundingBox.IsValid()) return;

            numMinX.Value = (decimal)boundingBox.MinX;
            numMinY.Value = (decimal)boundingBox.MinY;
            numMinZ.Value = (decimal)boundingBox.MinZ;

            numMaxX.Value = (decimal)boundingBox.MaxX;
            numMaxY.Value = (decimal)boundingBox.MaxY;
            numMaxZ.Value = (decimal)boundingBox.MaxZ;

            ApplyBoundingBox(boundingBox);
        }

        /// <summary>
        /// Min/Max 입력 필드에서 Enter : 값을 직접 입력해 바운드 박스 설정
        /// </summary>
        private void NumBoundingBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            Data.BoundBox3D boundingBox = new Data.BoundBox3D(
                (float)numMinX.Value, (float)numMinY.Value, (float)numMinZ.Value,
                (float)numMaxX.Value, (float)numMaxY.Value, (float)numMaxZ.Value);

            if (!boundingBox.IsValid())
            {
                MessageBox.Show("Max 값은 Min 값보다 커야 합니다.", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ApplyBoundingBox(boundingBox);
        }

        /// <summary>
        /// 바운드 박스를 검색 대상으로 확정하고 Selection Box를 갱신
        /// </summary>
        private void ApplyBoundingBox(Data.BoundBox3D boundingBox)
        {
            BoundingBox = boundingBox;

            vizcore3dx.SelectionBox.Clear();
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
            if (e.RowIndex < 0 || e.RowIndex >= searchResult.Count) return;

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
            if (vizcore3dx.Model.IsOpen() == false) return;

            // 검색 결과가 없으면 전체 개체가 삭제되므로 중단
            if (searchResult.Count == 0)
            {
                MessageBox.Show("검색 결과가 없습니다.", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 저장 경로 선택
            string path = string.Empty;
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "VIZX (*.vizx)|*.vizx";
                dlg.FileName = "SearchSpace.vizx";
                if (dlg.ShowDialog() != DialogResult.OK) return;
                path = dlg.FileName;
            }

            // 바운드 박스 외부 개체 삭제
            vizcore3dx.BeginUpdate();
            vizcore3dx.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);
            vizcore3dx.Object3D.Select(searchResult, true);
            vizcore3dx.Object3D.Select(Object3dSelectionModes.INVERT_SELECTION);
            List<Node> nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_ALL);
            vizcore3dx.Object3D.Delete(nodes);
            vizcore3dx.EndUpdate();

            // VIZX 형식으로 저장
            bool result = vizcore3dx.Model.SaveAsVIZX(path);
            if (result == false) return;

            // 모델 닫기
            vizcore3dx.Model.Close();

            // 이전 검색 결과 초기화 (닫힌 모델의 노드)
            searchResult = new List<Node>();
            gvResult.RowCount = 0;

            // 저장한 파일 다시 열기
            vizcore3dx.View.XRay.Enable = false;
            vizcore3dx.Model.Open(path);
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
