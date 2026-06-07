using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.NET.RibbonEx
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        public FrmMain()
        {
            InitializeComponent();

            // Module Initialize
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Init.
            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
            this.panelView.Controls.Add(vizcore3dx);
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.LicenseResults result =
                vizcore3dx.License.LicenseServer("127.0.0.1", 8901);

            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show("License Error : " + result.ToString());
                return;
            }

            vizcore3dx.ToolbarMain.Visible = false;
            vizcore3dx.ToolbarAnimation.Visible = false;
            vizcore3dx.ToolbarMeasure.Visible = false;
            vizcore3dx.ToolbarSection.Visible = false;
            vizcore3dx.ToolbarNote.Visible = false;
            vizcore3dx.ToolbarSnapshot.Visible = false;
            vizcore3dx.ToolbarDecal.Visible = false;
            vizcore3dx.ToolbarPrimitive.Visible = false;
            vizcore3dx.ToolbarClash.Visible = false;
            vizcore3dx.ToolbarSimulation.Visible = false;

            vizcore3dx.Statusbar.Visible = false;

            // Ribbon 토글 버튼 초기 상태 동기화
            chkModelTree.Checked = vizcore3dx.ModelTreeVisible;
            chkViewCube.Checked = vizcore3dx.ViewCube.Enable;
            chkViewToolbar.Checked = vizcore3dx.View.Toolbar.Enable;
        }

        /// <summary>
        /// 모델 열림 여부 확인
        /// </summary>
        private bool IsModelOpened()
        {
            if (vizcore3dx == null) return false;
            return vizcore3dx.Model.IsOpen();
        }

        // ================================================
        // 홈 - 모델
        // ================================================
        #region Ribbon - 홈 : 모델
        private void btnModelOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 모델 열기
            vizcore3dx.Model.OpenFileDialog();
        }

        private void btnModelAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 모델 추가
            if (!IsModelOpened()) return;
            vizcore3dx.Model.AddFileDialog();
        }

        private void btnModelSaveAs_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 다른 이름으로 저장
            if (!IsModelOpened()) return;
            vizcore3dx.Model.SaveAsFileDialog();
        }

        private void btnModelClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 모델 닫기
            if (!IsModelOpened()) return;
            vizcore3dx.Model.Close();
        }
        #endregion

        // ================================================
        // 홈 - 마크업
        // ================================================
        #region Ribbon - 홈 : 마크업
        private void btnMarkup_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnMarkupOpen)
            {
                // 마크업 열기 (노트, 측정, 단면, 스냅샷, 데칼, Grid System)
                vizcore3dx.Model.ImportMarkupJsonDialog(true, true, true, true, true, true);
            }
            else if (e.Item == btnMarkupSave)
            {
                // 마크업 저장 (노트, 측정, 단면, 스냅샷, 데칼, Grid System)
                vizcore3dx.Model.ExportMarkupJsonDialog(true, true, true, true, true, true);
            }
        }
        #endregion

        // ================================================
        // 홈 - 패널
        // ================================================
        #region Ribbon - 홈 : 패널
        private void chkModelTree_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 모델 트리 보이기/숨기기
            vizcore3dx.ModelTreeVisible = chkModelTree.Checked;
        }

        private void btnPanel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnQuickSearch)
            {
                // 빠른 검색 다이얼로그
                vizcore3dx.Object3D.Find.ShowQuickSearchDialog();
            }
            else if (e.Item == btnMiniView)
            {
                // Mini View 다이얼로그
                vizcore3dx.View.MiniView.ShowDialog(400, 300, VIZCore3DX.NET.Data.CameraDirection.ISO_PLUS, true);
            }
        }
        #endregion

        // ================================================
        // 홈 - 선택
        // ================================================
        #region Ribbon - 홈 : 선택
        private void btnSelection_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnSelectAll)
                vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.SELECT_ALL);
            else if (e.Item == btnDeselectAll)
                vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.DESELECT_ALL);
            else if (e.Item == btnInvertSelection)
                vizcore3dx.Object3D.Select(VIZCore3DX.NET.Data.Object3dSelectionModes.INVERT_SELECTION);
        }

        private void chkSelectionBox_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) { chkSelectionBox.Checked = false; return; }

            if (chkSelectionBox.Checked)
            {
                chkSelectionBoxMulti.Checked = false;
                vizcore3dx.Object3D.SelectByBox(VIZCore3DX.NET.Data.Object3DSelectionBoxModes.SINGLE);
            }
            else
            {
                vizcore3dx.Object3D.SelectByBox(VIZCore3DX.NET.Data.Object3DSelectionBoxModes.CANCEL);
            }
        }

        private void chkSelectionBoxMulti_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) { chkSelectionBoxMulti.Checked = false; return; }

            if (chkSelectionBoxMulti.Checked)
            {
                chkSelectionBox.Checked = false;
                vizcore3dx.Object3D.SelectByBox(VIZCore3DX.NET.Data.Object3DSelectionBoxModes.MULTI);
            }
            else
            {
                vizcore3dx.Object3D.SelectByBox(VIZCore3DX.NET.Data.Object3DSelectionBoxModes.CANCEL);
            }
        }
        #endregion

        // ================================================
        // 홈 - 개체 켜기/끄기
        // ================================================
        #region Ribbon - 홈 : 개체 켜기/끄기
        private void btnVisible_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnHideSelected)
                vizcore3dx.Object3D.Show(VIZCore3DX.NET.Data.Object3DKind.SELECTED, false);
            else if (e.Item == btnHideUnselected)
                vizcore3dx.Object3D.Show(VIZCore3DX.NET.Data.Object3DKind.UNSELECTED, false);
            else if (e.Item == btnShowAll)
                vizcore3dx.Object3D.Show(VIZCore3DX.NET.Data.Object3DKind.ALL, true);
            else if (e.Item == btnHideAll)
                vizcore3dx.Object3D.Show(VIZCore3DX.NET.Data.Object3DKind.ALL, false);
        }
        #endregion

        // ================================================
        // 보기 - 화면
        // ================================================
        #region Ribbon - 보기 : 화면
        private void btnViewReset_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 뷰 초기화
            if (!IsModelOpened()) return;
            vizcore3dx.View.ResetView();
        }

        private void btnViewFit_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 화면에 맞춤
            if (!IsModelOpened()) return;
            vizcore3dx.View.FitToView();
        }

        private void btnViewZoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnBoxZoom)
            {
                // 박스 줌 (마우스로 영역 지정)
                vizcore3dx.View.BoxZoom();
            }
            else if (e.Item == btnMoveCenter)
            {
                // 선택 개체로 중심 이동
                vizcore3dx.View.MoveCenterToObject3d();
            }
            else if (e.Item == btnFlyTo)
            {
                // 선택 개체로 비행
                vizcore3dx.View.FlyToObject3d(1.0f, TimeSpan.FromSeconds(1));
            }
        }
        #endregion

        // ================================================
        // 보기 - 화면 표시
        // ================================================
        #region Ribbon - 보기 : 화면 표시
        private void chkViewCube_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 뷰 큐브 표시
            vizcore3dx.ViewCube.Enable = chkViewCube.Checked;
        }

        private void chkViewToolbar_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 뷰 툴바 표시
            vizcore3dx.View.Toolbar.Enable = chkViewToolbar.Checked;
        }
        #endregion

        // ================================================
        // 스케치
        // ================================================
        #region Ribbon - 스케치
        private void btnSketch_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnSketchText)
            {
                // 글자 스케치 (텍스트 입력 후 위치 지정)
                string text = DevExpress.XtraEditors.XtraInputBox.Show("스케치 문자열을 입력하십시오.", "스케치", "TEXT");
                if (string.IsNullOrEmpty(text)) return;

                vizcore3dx.Sketch.CreateTextSketch(text);
                return;
            }

            if (e.Item == btnSketchPen)
                vizcore3dx.Sketch.CreateSketch(VIZCore3DX.NET.Data.SketchType.Pen);
            else if (e.Item == btnSketchLine)
                vizcore3dx.Sketch.CreateSketch(VIZCore3DX.NET.Data.SketchType.Line);
            else if (e.Item == btnSketchPolyline)
                vizcore3dx.Sketch.CreateSketch(VIZCore3DX.NET.Data.SketchType.Polyline);
            else if (e.Item == btnSketchFreehand)
                vizcore3dx.Sketch.CreateSketch(VIZCore3DX.NET.Data.SketchType.FreehandCurve);
            else if (e.Item == btnSketchArrow)
                vizcore3dx.Sketch.CreateSketch(VIZCore3DX.NET.Data.SketchType.Arrow);
            else if (e.Item == btnSketchCircle)
                vizcore3dx.Sketch.CreateSketch(VIZCore3DX.NET.Data.SketchType.Circle);
            else if (e.Item == btnSketchEllipse)
                vizcore3dx.Sketch.CreateSketch(VIZCore3DX.NET.Data.SketchType.Ellipse);
            else if (e.Item == btnSketchRectangle)
                vizcore3dx.Sketch.CreateSketch(VIZCore3DX.NET.Data.SketchType.Rectangle);
            else if (e.Item == btnSketchCloud)
                vizcore3dx.Sketch.CreateSketch(VIZCore3DX.NET.Data.SketchType.Cloud);
            else if (e.Item == btnSketchFixedCloud)
                vizcore3dx.Sketch.CreateSketch(VIZCore3DX.NET.Data.SketchType.FixedCloud);
        }

        private void btnSketchDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnSketchDeleteBox)
                vizcore3dx.Sketch.DeleteBox();
            else if (e.Item == btnSketchDeleteSelected)
                vizcore3dx.Sketch.DeleteSelected();
            else if (e.Item == btnSketchDeleteAll)
                vizcore3dx.Sketch.DeleteAll();
        }
        #endregion

        // ================================================
        // 보기 - 카메라 방향
        // ================================================
        #region Ribbon - 보기 : 카메라 방향
        private void btnCamera_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnCameraISO)
                vizcore3dx.View.MoveCamera(VIZCore3DX.NET.Data.CameraDirection.ISO_PLUS);
            else if (e.Item == btnCameraXPlus)
                vizcore3dx.View.MoveCamera(VIZCore3DX.NET.Data.CameraDirection.X_PLUS);
            else if (e.Item == btnCameraXMinus)
                vizcore3dx.View.MoveCamera(VIZCore3DX.NET.Data.CameraDirection.X_MINUS);
            else if (e.Item == btnCameraYPlus)
                vizcore3dx.View.MoveCamera(VIZCore3DX.NET.Data.CameraDirection.Y_PLUS);
            else if (e.Item == btnCameraYMinus)
                vizcore3dx.View.MoveCamera(VIZCore3DX.NET.Data.CameraDirection.Y_MINUS);
            else if (e.Item == btnCameraZPlus)
                vizcore3dx.View.MoveCamera(VIZCore3DX.NET.Data.CameraDirection.Z_PLUS);
            else if (e.Item == btnCameraZMinus)
                vizcore3dx.View.MoveCamera(VIZCore3DX.NET.Data.CameraDirection.Z_MINUS);
        }
        #endregion

        // ================================================
        // 보기 - 화면 회전
        // ================================================
        #region Ribbon - 보기 : 화면 회전
        private void btnRotate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            // 화면 축 기준 회전 각도 (Degree)
            const float ANGLE = 15.0f;

            if (e.Item == btnRotateXPlus)
                vizcore3dx.View.RotateCameraByScreenAxis(ANGLE, 0.0f, 0.0f);
            else if (e.Item == btnRotateXMinus)
                vizcore3dx.View.RotateCameraByScreenAxis(-ANGLE, 0.0f, 0.0f);
            else if (e.Item == btnRotateYPlus)
                vizcore3dx.View.RotateCameraByScreenAxis(0.0f, ANGLE, 0.0f);
            else if (e.Item == btnRotateYMinus)
                vizcore3dx.View.RotateCameraByScreenAxis(0.0f, -ANGLE, 0.0f);
            else if (e.Item == btnRotateZPlus)
                vizcore3dx.View.RotateCameraByScreenAxis(0.0f, 0.0f, ANGLE);
            else if (e.Item == btnRotateZMinus)
                vizcore3dx.View.RotateCameraByScreenAxis(0.0f, 0.0f, -ANGLE);
        }
        #endregion

        // ================================================
        // 보기 - 투영
        // ================================================
        #region Ribbon - 보기 : 투영
        private void chkProjection_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == chkProjPerspective)
                vizcore3dx.View.Projection = VIZCore3DX.NET.Data.Projections.Perspective;
            else if (e.Item == chkProjOrthographic)
                vizcore3dx.View.Projection = VIZCore3DX.NET.Data.Projections.Orthographic;
        }
        #endregion

        // ================================================
        // 보기 - 캡처
        // ================================================
        #region Ribbon - 보기 : 캡처
        private void btnCaptureClipboard_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 화면 이미지를 클립보드로 복사
            if (!IsModelOpened()) return;
            vizcore3dx.View.CaptureImageToClipboard();
        }
        #endregion

        // ================================================
        // 조작 - 렌더링
        // ================================================
        #region Ribbon - 조작 : 렌더링
        private void chkRenderMode_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == chkRenderSmooth)
                vizcore3dx.View.SetRenderMode(VIZCore3DX.NET.Data.RenderModes.SMOOTH);
            else if (e.Item == chkRenderWire)
                vizcore3dx.View.SetRenderMode(VIZCore3DX.NET.Data.RenderModes.WIRE);
            else if (e.Item == chkRenderVisibleWire)
                vizcore3dx.View.SetRenderMode(VIZCore3DX.NET.Data.RenderModes.VISIBLE_WIRE);
        }
        #endregion

        // ================================================
        // 조작 - 효과
        // ================================================
        #region Ribbon - 조작 : 효과
        private void chkXRay_ItemClick(object sender, ItemClickEventArgs e)
        {
            // X-Ray
            if (!IsModelOpened()) return;
            vizcore3dx.View.XRay.Enable = chkXRay.Checked;
        }

        private void chkSilhouetteEdge_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 모서리 표시
            if (!IsModelOpened()) return;
            vizcore3dx.View.SilhouetteEdge = chkSilhouetteEdge.Checked;
        }

        private void chkRealtimeShadow_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 실시간 그림자
            if (!IsModelOpened()) return;
            vizcore3dx.View.RealtimeShadow = chkRealtimeShadow.Checked;
        }

        private void chkPhongShading_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Phong 음영
            if (!IsModelOpened()) return;
            vizcore3dx.View.PhongShading = chkPhongShading.Checked;
        }

        private void chkSsao_ItemClick(object sender, ItemClickEventArgs e)
        {
            // SSAO (Screen Space Ambient Occlusion)
            if (!IsModelOpened()) return;
            vizcore3dx.View.Ssao = chkSsao.Checked;
        }

        private void chkEnvironmentLight_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 환경 조명
            if (!IsModelOpened()) return;
            vizcore3dx.View.EnvironmentLight = chkEnvironmentLight.Checked;
        }
        #endregion

        // ================================================
        // 조작 - 변환 (개체 이동/회전)
        // ================================================
        #region Ribbon - 조작 : 변환
        private void btnTransform_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnTransformMove)
                vizcore3dx.Object3D.Transform.MoveDialog();
            else if (e.Item == btnTransformRotate)
                vizcore3dx.Object3D.Transform.RotateDialog();
            else if (e.Item == btnTransformRestore)
                vizcore3dx.Object3D.Transform.RestoreTransform();
            else if (e.Item == btnTransformRestoreAll)
                vizcore3dx.Object3D.Transform.RestoreTransformAll();
        }
        #endregion

        // ================================================
        // 조작 - 분해
        // ================================================
        #region Ribbon - 조작 : 분해
        private void chkExplode_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) { chkExplode.Checked = false; return; }

            if (chkExplode.Checked)
            {
                // 분해도 활성화
                if (vizcore3dx.Object3D.Explode.Activate() == false)
                    chkExplode.Checked = false;
            }
            else
            {
                // 분해도 비활성화 (분해 이전 상태로 복원)
                vizcore3dx.Object3D.Explode.Deactivate(true);
            }
        }

        private void btnExplode_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;
            if (vizcore3dx.Object3D.Explode.IsActive == false) return;

            if (e.Item == btnExplodePlus)
            {
                // 분해 진행률 증가 (0.0 ~ 1.0)
                vizcore3dx.Object3D.Explode.ExplodeProgress =
                    Math.Min(1.0f, vizcore3dx.Object3D.Explode.ExplodeProgress + 0.1f);
            }
            else if (e.Item == btnExplodeMinus)
            {
                // 분해 진행률 감소 (0.0 ~ 1.0)
                vizcore3dx.Object3D.Explode.ExplodeProgress =
                    Math.Max(0.0f, vizcore3dx.Object3D.Explode.ExplodeProgress - 0.1f);
            }
            else if (e.Item == btnExplodeRestore)
            {
                // 분해 이전 상태로 복원
                vizcore3dx.Object3D.Explode.Restore();
            }
        }
        #endregion

        // ================================================
        // 조작 - 색상/투명도
        // ================================================
        #region Ribbon - 조작 : 색상/투명도
        private void btnColorChange_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 선택 개체 색상 변경
            if (!IsModelOpened()) return;
            vizcore3dx.Object3D.Color.ChangeColorDialog();
        }

        private void btnAlphaChange_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 선택 개체 투명도 변경
            if (!IsModelOpened()) return;
            vizcore3dx.Object3D.Color.ChangeAlphaDialog();
        }

        private void btnColorRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 선택 개체 색상/투명도 복원
            if (!IsModelOpened()) return;
            vizcore3dx.Object3D.Color.Restore();
        }

        private void btnColorRestoreAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 전체 개체 색상/투명도 복원
            if (!IsModelOpened()) return;
            vizcore3dx.Object3D.Color.RestoreAll();
        }
        #endregion

        // ================================================
        // 측정 - 측정 추가
        // ================================================
        #region Ribbon - 측정 : 측정 추가
        private void btnMeasureAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnMeasurePosition)
                vizcore3dx.Measure.AddPosition();
            else if (e.Item == btnMeasureDistance)
                vizcore3dx.Measure.AddDistance();
            else if (e.Item == btnMeasureAngle)
                vizcore3dx.Measure.AddAngle();
            else if (e.Item == btnMeasureMinDistance)
                vizcore3dx.Measure.AddDistanceMinimum();
            else if (e.Item == btnMeasureArea)
                vizcore3dx.Measure.AddArea();
        }
        #endregion

        // ================================================
        // 측정 - 정밀 측정
        // ================================================
        #region Ribbon - 측정 : 정밀 측정
        private void btnMeasureDetail_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnMeasureDistXYZ)
                vizcore3dx.Measure.AddDistanceAxialDirectionXYZ();
            else if (e.Item == btnMeasureDistX)
                vizcore3dx.Measure.AddDistanceAxialDirectionX();
            else if (e.Item == btnMeasureDistY)
                vizcore3dx.Measure.AddDistanceAxialDirectionY();
            else if (e.Item == btnMeasureDistZ)
                vizcore3dx.Measure.AddDistanceAxialDirectionZ();
            else if (e.Item == btnMeasureContinuous)
                vizcore3dx.Measure.AddDistanceContinuous();
            else if (e.Item == btnMeasureParallel)
                vizcore3dx.Measure.AddDistanceParallelPlane();
            else if (e.Item == btnMeasureBOP)
                vizcore3dx.Measure.AddDistanceBOP();
            else if (e.Item == btnMeasureCOP)
                vizcore3dx.Measure.AddDistanceCOP();
        }
        #endregion

        // ================================================
        // 측정 - 측정 관리
        // ================================================
        #region Ribbon - 측정 : 측정 관리
        private void btnMeasureManage_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnMeasureShowAll)
                vizcore3dx.Measure.Show(true);
            else if (e.Item == btnMeasureHideAll)
                vizcore3dx.Measure.Show(false);
            else if (e.Item == btnMeasureDelete)
                vizcore3dx.Measure.Delete();
            else if (e.Item == btnMeasureClear)
                vizcore3dx.Measure.Clear();
        }
        #endregion

        // ================================================
        // 측정 - 노트
        // ================================================
        #region Ribbon - 측정 : 노트
        private void btnNoteAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            // 노트 내용 입력
            string text = DevExpress.XtraEditors.XtraInputBox.Show("노트 내용을 입력하십시오.", "노트", "NOTE");
            if (string.IsNullOrEmpty(text)) return;

            if (e.Item == btnNoteSurface)
                vizcore3dx.Note.AddNoteSurface(text);
            else if (e.Item == btnNote3D)
                vizcore3dx.Note.AddNote3D(text);
            else if (e.Item == btnNote2D)
                vizcore3dx.Note.AddNote2D(text);
        }

        private void btnNoteManage_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnNoteShowAll)
                vizcore3dx.Note.Show(true);
            else if (e.Item == btnNoteHideAll)
                vizcore3dx.Note.Show(false);
            else if (e.Item == btnNoteDelete)
                vizcore3dx.Note.Delete();
            else if (e.Item == btnNoteClear)
                vizcore3dx.Note.Clear();
        }
        #endregion

        // ================================================
        // 단면
        // ================================================
        #region Ribbon - 단면
        private void btnSectionAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnSectionPlane)
                vizcore3dx.Section.Add(false, VIZCore3DX.NET.Data.Axis.X);
            else if (e.Item == btnSectionBox)
                vizcore3dx.Section.AddBox(false);
        }

        private void btnSectionAlign_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnSectionAlignX)
                vizcore3dx.Section.Align(VIZCore3DX.NET.Data.SectionPlaneDirectionType.XPlus);
            else if (e.Item == btnSectionAlignY)
                vizcore3dx.Section.Align(VIZCore3DX.NET.Data.SectionPlaneDirectionType.YPlus);
            else if (e.Item == btnSectionAlignZ)
                vizcore3dx.Section.Align(VIZCore3DX.NET.Data.SectionPlaneDirectionType.ZPlus);
        }

        private void btnSectionManage_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnSectionDelete)
                vizcore3dx.Section.Delete();
            else if (e.Item == btnSectionClear)
                vizcore3dx.Section.Clear();
        }

        private void btnSectionControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnSectionShowAll)
                vizcore3dx.Section.Show(true);
            else if (e.Item == btnSectionHideAll)
                vizcore3dx.Section.Show(false);
            else if (e.Item == btnSectionEnableAll)
                vizcore3dx.Section.EnableAll(true);
            else if (e.Item == btnSectionDisableAll)
                vizcore3dx.Section.EnableAll(false);
            else if (e.Item == btnSectionInvert)
                vizcore3dx.Section.InvertDirection();
        }
        #endregion

        // ================================================
        // 도구 - 스냅샷 (사용자 뷰)
        // ================================================
        #region Ribbon - 도구 : 스냅샷
        private void btnSnapshot_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnSnapshotAdd)
            {
                // 스냅샷 제목 입력
                string text = DevExpress.XtraEditors.XtraInputBox.Show("스냅샷 제목을 입력하십시오.", "스냅샷", "SNAPSHOT");
                if (string.IsNullOrEmpty(text)) return;

                vizcore3dx.Snapshot.Add(text);
            }
            else if (e.Item == btnSnapshotDialog)
            {
                // 사용자 뷰 다이얼로그
                vizcore3dx.Snapshot.ShowUserViewDialog();
            }
            else if (e.Item == btnSnapshotClear)
            {
                // 스냅샷 초기화
                vizcore3dx.Snapshot.Clear();
            }
        }
        #endregion

        // ================================================
        // 도구 - 데칼
        // ================================================
        #region Ribbon - 도구 : 데칼
        private void btnDecal_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnDecalText)
                vizcore3dx.Decal.AddDecalDialog(VIZCore3DX.NET.Data.DecalType.Text);
            else if (e.Item == btnDecalImage)
                vizcore3dx.Decal.AddDecalDialog(VIZCore3DX.NET.Data.DecalType.Image);
            else if (e.Item == btnDecalClear)
                vizcore3dx.Decal.Clear();
        }
        #endregion

        // ================================================
        // 도구 - 애니메이션
        // ================================================
        #region Ribbon - 도구 : 애니메이션
        private void btnAnimation_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            // 활성화된 애니메이션
            VIZCore3DX.NET.Data.Animation animation = vizcore3dx.Animation.ActiveAnimation;
            if (animation == null) return;

            if (e.Item == btnAnimationPlay)
                animation.Play();
            else if (e.Item == btnAnimationPause)
                animation.Pause();
            else if (e.Item == btnAnimationStop)
                animation.Stop();
        }
        #endregion

        // ================================================
        // 도구 - 간섭 검사
        // ================================================
        #region Ribbon - 도구 : 간섭 검사
        private void btnClash_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnClashCheck)
            {
                // 등록된 모든 간섭 검사 수행
                vizcore3dx.Clash.PerformInterferenceCheck();
            }
            else if (e.Item == btnClashClearSymbol)
            {
                // 간섭 결과 심볼 지우기
                vizcore3dx.Clash.ClearResultSymbol();
            }
            else if (e.Item == btnClashClear)
            {
                // 간섭 검사 초기화
                vizcore3dx.Clash.Clear();
            }
        }
        #endregion

        // ================================================
        // 도구 - 내보내기
        // ================================================
        #region Ribbon - 도구 : 내보내기
        private void btnExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsModelOpened()) return;

            if (e.Item == btnExportModel)
            {
                // 3D 모델 내보내기 다이얼로그
                vizcore3dx.Model.ExportModelDialog();
            }
            else if (e.Item == btnExportStructure)
            {
                // 모델 구조 내보내기 다이얼로그
                vizcore3dx.Model.ExportStructureDialog();
            }
            else if (e.Item == btnPreview)
            {
                // 미리보기 다이얼로그
                vizcore3dx.View.Preview.ShowDialog(VIZCore3DX.NET.Data.CameraDirection.ISO_PLUS, true);
            }
        }
        #endregion
    }
}
