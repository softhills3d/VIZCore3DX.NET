using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.GridThreeD
{
    public partial class FrmMain : Form
    {
        // ================================================
        // Attribute & Property
        // ================================================

        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dxExplode;
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dxGrid;
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dxView;

        // Grid Viewer SelectionBox ID -> GridBoxItem
        private readonly Dictionary<int, GridBoxItem> GridBoxMap = new Dictionary<int, GridBoxItem>();

        // 전체 Grid 데이터
        private readonly List<GridBoxItem> GridBoxes = new List<GridBoxItem>();

        private string GridPath { get; set; }

        // Grid 하나에 대한 이름과 BoundBox 정보
        private sealed class GridBoxItem
        {
            public string Key { get; set; }
            public BoundBox3D Box { get; set; }
        }

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Main Viewer
            vizcore3dx = CreateViewer(splitContainer3.Panel1, true, null);

            // Export 후 분할 파일들을 합쳐서 분해도 형태로 보여주는 Viewer
            vizcore3dxExplode = CreateViewer(splitContainer3.Panel2, true, null);

            // Grid Box만 보여주는 Viewer
            vizcore3dxGrid = CreateViewer(splitContainer4.Panel1, false, InitializeGridViewer);

            // 선택한 Grid 영역 하나만 보여주는 상세 Viewer
            vizcore3dxView = CreateViewer(splitContainer4.Panel2, false, null);
        }

        // Viewer를 생성하고 초기화 이벤트에서 라이선스 인증과 기본 설정 적용
        private VIZCore3DX.NET.VIZCore3DXControl CreateViewer(Control parent, bool showToolbar, Action<VIZCore3DX.NET.VIZCore3DXControl> init)
        {
            VIZCore3DX.NET.VIZCore3DXControl viewer = new VIZCore3DX.NET.VIZCore3DXControl();
            viewer.Dock = DockStyle.Fill;

            viewer.OnInitializedVIZCore3DX += (sender, e) =>
            {
                VIZCore3DX.NET.VIZCore3DXControl ctrl = sender as VIZCore3DX.NET.VIZCore3DXControl;
                if (ctrl == null) return;

                bool result = VIZCore3DXHelper.OnInitializedVIZCore3DX(ctrl);
                if (result == false) return;

                // false일 때만 숨기지 말고, true/false 모두 명확하게 적용
                ctrl.ToolbarMain.Visible = showToolbar;

                if (init != null) init(ctrl);
            };

            parent.Controls.Add(viewer);

            return viewer;
        }

        // ================================================
        // Model
        // ================================================

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string path = string.Format("{0}\\Models\\VIZCore3DX.NET.GridThreeD\\H0000.vizx", vizcore3dx.GetEntryAssemblyPath());

            if (File.Exists(path))
                vizcore3dx.Model.Open(path);
            else
                vizcore3dx.Model.OpenFileDialog();
        }

        // 현재 Viewer에 열린 원본 모델 파일 목록 반환
        private List<string> GetModelFiles(VIZCore3DX.NET.VIZCore3DXControl viewer)
        {
            if (viewer == null || viewer.Model.IsOpen() == false) return new List<string>();

            return viewer.Model.Files.Where(file => string.IsNullOrWhiteSpace(file) == false && File.Exists(file)).ToList();
        }

        // 지정 Viewer에 모델 파일 목록을 다시 로드
        private bool OpenModelFiles(VIZCore3DX.NET.VIZCore3DXControl viewer, List<string> files, bool enableBody)
        {
            if (viewer == null || files == null || files.Count == 0) return false;

            List<string> validFiles = files.Where(file => string.IsNullOrWhiteSpace(file) == false && File.Exists(file)).ToList();
            if (validFiles.Count == 0) return false;

            try
            {
                viewer.Model.Close();

                // Body Mesh 접근이 필요한 Export / Grid 상세 보기 단계에서만 true
                viewer.Model.EnableBody = enableBody;
                viewer.Model.Open(validFiles[0]);

                if (validFiles.Count > 1) viewer.Model.Add(validFiles.Skip(1).ToList());

                return viewer.Model.IsOpen();
            }
            catch
            {
                return false;
            }
        }

        // ================================================
        // Bounding Box
        // ================================================

        private void btnBoxAdd_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 로드해 주세요.");
                return;
            }

            int xCount;
            int yCount;
            int zCount;

            if (ReadGridCount(out xCount, out yCount, out zCount) == false) return;

            BuildGridData(xCount, yCount, zCount);
            DrawMainBoxes();
            DrawGridBoxes();
        }

        // X/Y/Z 입력값을 읽고 유효성 검사
        private bool ReadGridCount(out int xCount, out int yCount, out int zCount)
        {
            xCount = 0;
            yCount = 0;
            zCount = 0;

            if (int.TryParse(txtBoxX.Text, out xCount) == false || xCount <= 0)
            {
                MessageBox.Show("X 값을 1 이상 숫자로 입력해 주세요.");
                return false;
            }

            if (int.TryParse(txtBoxY.Text, out yCount) == false || yCount <= 0)
            {
                MessageBox.Show("Y 값을 1 이상 숫자로 입력해 주세요.");
                return false;
            }

            if (int.TryParse(txtBoxZ.Text, out zCount) == false || zCount <= 0)
            {
                MessageBox.Show("Z 값을 1 이상 숫자로 입력해 주세요.");
                return false;
            }

            return true;
        }

        // 모델 BoundBox를 X/Y/Z 개수만큼 나눠 Grid Box 데이터를 생성
        private void BuildGridData(int xCount, int yCount, int zCount)
        {
            GridBoxes.Clear();
            GridBoxMap.Clear();

            BoundBox3D box = vizcore3dx.Model.BoundBox;
            if (box == null || box.IsValid() == false) return;

            float xWidth = box.LengthX / xCount;
            float yWidth = box.LengthY / yCount;
            float zWidth = box.LengthZ / zCount;

            for (int x = 0; x < xCount; x++)
            {
                for (int y = 0; y < yCount; y++)
                {
                    for (int z = 0; z < zCount; z++)
                    {
                        float minX = box.MinX + (xWidth * x);
                        float minY = box.MinY + (yWidth * y);
                        float minZ = box.MinZ + (zWidth * z);
                        float maxX = minX + xWidth;
                        float maxY = minY + yWidth;
                        float maxZ = minZ + zWidth;

                        GridBoxItem item = new GridBoxItem();
                        item.Key = string.Format("{0}-{1}-{2}", x + 1, y + 1, z + 1);
                        item.Box = new BoundBox3D(minX, minY, minZ, maxX, maxY, maxZ);

                        GridBoxes.Add(item);
                    }
                }
            }
        }

        // 메인 Viewer에 Grid SelectionBox 표시
        private void DrawMainBoxes()
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.BeginUpdate();

            try
            {
                vizcore3dx.SelectionBox.Clear();

                foreach (GridBoxItem item in GridBoxes)
                    vizcore3dx.SelectionBox.Add(item.Box, Color.FromArgb(10, Color.White), Color.Black, "");
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        private void btnBoxClear_Click(object sender, EventArgs e)
        {
            vizcore3dx.BeginUpdate();

            try
            {
                vizcore3dx.SelectionBox.Clear();
                GridBoxMap.Clear();
                GridBoxes.Clear();
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            vizcore3dxGrid.SelectionBox.Clear();
            vizcore3dxView.Model.Close();
            vizcore3dxExplode.Model.Close();
        }

        // ================================================
        // Export
        // ================================================

        private string GetGridExportPath(bool deleteOldGridFiles)
        {
            if (string.IsNullOrWhiteSpace(GridPath))
            {
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    dlg.Description = "Grid Export 폴더를 생성할 위치를 선택하세요.";

                    if (dlg.ShowDialog() != DialogResult.OK) return string.Empty;

                    GridPath = Path.Combine(dlg.SelectedPath, "GridExport");
                }
            }

            try
            {
                Directory.CreateDirectory(GridPath);

                if (deleteOldGridFiles)
                {
                    foreach (string file in Directory.GetFiles(GridPath, "*.vizx"))
                        File.Delete(file);
                }

                return GridPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Grid Export 폴더를 준비하는 중 오류가 발생했습니다.\n\n" + ex.Message, "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }
        }

        private void btnExportGrid_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 로드해 주세요.");
                return;
            }

            if (GridBoxes.Count == 0)
            {
                MessageBox.Show("먼저 Grid Box를 생성해 주세요.");
                return;
            }

            GridPath = GetGridExportPath(true);
            if (string.IsNullOrWhiteSpace(GridPath)) return;

            List<string> files = GetModelFiles(vizcore3dx);

            if (files.Count == 0)
            {
                MessageBox.Show("원본 모델 파일 경로를 찾을 수 없습니다.");
                return;
            }

            // 실제 export 성공 파일 목록을 저장
            List<string> exportedFiles = new List<string>();

            vizcore3dx.ShowWaitForm();

            try
            {
                foreach (GridBoxItem item in GridBoxes)
                {
                    vizcore3dx.UpdateWaitForm("Export Grid...", item.Key);

                    // Grid 하나 저장할 때마다 원본 모델을 다시 열어서 깨끗한 상태에서 절단
                    if (OpenModelFiles(vizcore3dx, files, true) == false) continue;

                    // 현재 Grid 영역만 남겨서 저장
                    if (KeepGridOnly(vizcore3dx, item.Box) == false) continue;

                    // 삭제 끝난 현재 상태 저장
                    string output = Path.Combine(GridPath, GetSafeFileName(item.Key) + ".vizx");
                    bool exportResult = vizcore3dx.Model.ExportVIZX(output);

                    if (exportResult == false || File.Exists(output) == false || new FileInfo(output).Length <= 0) continue;

                    exportedFiles.Add(output);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Export가 끝나면 메인 Viewer를 원본 모델 상태로 복원
                OpenModelFiles(vizcore3dx, files, false);

                // 원본 모델을 다시 열면 SelectionBox가 사라질 수 있으므로 Grid Box 다시 표시
                DrawMainBoxes();

                vizcore3dx.CloseWaitForm();
            }

            if (exportedFiles.Count == 0)
            {
                MessageBox.Show("Export된 Grid 파일이 없습니다.");
                return;
            }

            exportedFiles = exportedFiles.OrderBy(file => file).ToList();

            // 첫 번째 파일은 새로 열기
            if (OpenModelFiles(vizcore3dxExplode, new List<string> { exportedFiles[0] }, true) == false)
            {
                MessageBox.Show("첫 번째 분할 파일을 열 수 없습니다.\n\n" + exportedFiles[0]);
                return;
            }

            // 나머지 파일은 현재 모델에 추가
            for (int i = 1; i < exportedFiles.Count; i++)
            {
                string file = exportedFiles[i];

                if (File.Exists(file) == false) continue;

                vizcore3dxExplode.Model.Add(new List<string> { file }, false);
            }

            vizcore3dxExplode.View.FitToView();
        }

        private string GetSafeFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return "EMPTY";

            foreach (char c in Path.GetInvalidFileNameChars())
                fileName = fileName.Replace(c, '_');

            return fileName;
        }

        // ================================================
        // Explode
        // ================================================

        private void btnExplode_Click(object sender, EventArgs e)
        {
            if (vizcore3dxExplode.Model.IsOpen() == false)
            {
                MessageBox.Show("분해할 모델을 먼저 로드해 주세요.");
                return;
            }

            vizcore3dxExplode.Object3D.Group.CreateHierarchicalGroups(3);
            vizcore3dxExplode.Object3D.Explode.AnimateExplodeRadial(0.0f, 0.3f, 1.0f, null, false);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (vizcore3dxExplode.Model.IsOpen() == false) return;

            // 분해 이전 상태로 복원 후 분해 모드 비활성화
            vizcore3dxExplode.Object3D.Explode.Restore();
            vizcore3dxExplode.Object3D.Explode.Deactivate();

            vizcore3dxExplode.View.ResetView();
        }

        // ================================================
        // Grid
        // ================================================

        private void InitializeGridViewer(VIZCore3DX.NET.VIZCore3DXControl viewer)
        {
            viewer.View.EnableSelection = false;

            viewer.SelectionBox.OnSelectionBoxSelectedEvent -= SelectionBox_OnSelected;
            viewer.SelectionBox.OnSelectionBoxSelectedEvent += SelectionBox_OnSelected;

            viewer.SelectionBox.EnabledMouseSelection(true);
            viewer.SelectionBox.IsManipulatorEnabled = false;
            viewer.SelectionBox.IsNameVisible = false;

            viewer.SelectionBox.DefaultSelectionBoxFillColor = Color.FromArgb(25, Color.White);
            viewer.SelectionBox.DefaultSelectionBoxStrokeColor = Color.FromArgb(120, Color.Gray);
            viewer.SelectionBox.SelectionBoxFillColor = Color.FromArgb(180, Color.Red);
            viewer.SelectionBox.SelectionBoxStrokeColor = Color.Red;
            viewer.SelectionBox.SelectionBoxStrokeThickness = 1.0f;
        }

        // Grid Viewer는 실제 모델은 숨기고 SelectionBox만 보여줌
        private void DrawGridBoxes()
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            List<string> sourceFiles = GetModelFiles(vizcore3dx);
            if (sourceFiles.Count == 0) return;

            // Grid Viewer에 원본 모델을 다시 열어서 ROOT 확보
            if (OpenModelFiles(vizcore3dxGrid, sourceFiles, false) == false) return;

            // 원본 모델 노드는 숨김
            List<Node> originalNodes = vizcore3dxGrid.Object3D.FromFilter(Object3dFilter.ALL);

            if (originalNodes != null && originalNodes.Count > 0)
                vizcore3dxGrid.Object3D.Show(originalNodes, false);

            vizcore3dxGrid.BeginUpdate();

            try
            {
                vizcore3dxGrid.SelectionBox.Clear();
                GridBoxMap.Clear();

                foreach (GridBoxItem item in GridBoxes)
                {
                    int id = vizcore3dxGrid.SelectionBox.Add(item.Box, Color.FromArgb(25, Color.White), Color.FromArgb(120, Color.Gray), "");
                    GridBoxMap[id] = item;
                }
            }
            finally
            {
                vizcore3dxGrid.EndUpdate();
            }

            FitGrid(false);
        }

        private void SelectionBox_OnSelected(object sender, EventManager.SelectionBoxEventArgs e)
        {
            if (e == null || e.IDs == null || e.IDs.Count == 0) return;

            // true는 기존 Grid VIZX 파일을 삭제할 수 있음.
            if (string.IsNullOrWhiteSpace(GridPath))
            {
                MessageBox.Show("먼저 Grid Export를 실행해 주세요.");
                return;
            }

            int boxId = e.IDs[0];

            GridBoxItem item;
            if (GridBoxMap.TryGetValue(boxId, out item) == false) return;
            if (item == null || string.IsNullOrWhiteSpace(item.Key)) return;

            string output = Path.Combine(GridPath, GetSafeFileName(item.Key) + ".vizx");

            if (File.Exists(output) == false)
            {
                MessageBox.Show("선택한 Grid 파일을 찾을 수 없습니다.\n\n" + output);
                return;
            }

            if (new FileInfo(output).Length <= 0)
            {
                MessageBox.Show("선택한 Grid 파일이 비어 있습니다.\n\n" + output);
                return;
            }

            Cursor = Cursors.WaitCursor;

            try
            {
                // 선택한 Grid에 해당하는 VIZX 파일을 상세 Viewer에 열기
                if (OpenModelFiles(vizcore3dxView, new List<string> { output }, true) == false)
                {
                    MessageBox.Show("선택한 Grid 파일을 상세 Viewer에 열지 못했습니다.\n\n" + output);
                    return;
                }

                vizcore3dxView.View.FitToView();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnGrid3D_Click(object sender, EventArgs e)
        {
            FitGrid(false);
        }

        private void btnGrid2D_Click(object sender, EventArgs e)
        {
            FitGrid(true);
        }

        // Grid Viewer 카메라를 전체 Grid 영역 기준으로 맞춤
        private void FitGrid(bool topView)
        {
            if (vizcore3dxGrid.Model.IsOpen() == false) return;

            BoundBox3D box = GetGridTotalBoundBox();
            if (box == null || box.IsValid() == false) return;

            vizcore3dxGrid.SelectionBox.EnabledMouseSelection(false);

            try
            {
                vizcore3dxGrid.View.EnableInitialCamera = true;
                vizcore3dxGrid.View.InitialCameraBoundBox = box;
                vizcore3dxGrid.View.ResetView();

                if (topView) vizcore3dxGrid.View.MoveCamera(CameraDirection.Z_PLUS);
            }
            finally
            {
                vizcore3dxGrid.SelectionBox.EnabledMouseSelection(true);
            }
        }

        private BoundBox3D GetGridTotalBoundBox()
        {
            if (GridBoxes.Count == 0) return null;

            float minX = GridBoxes[0].Box.MinX;
            float minY = GridBoxes[0].Box.MinY;
            float minZ = GridBoxes[0].Box.MinZ;
            float maxX = GridBoxes[0].Box.MaxX;
            float maxY = GridBoxes[0].Box.MaxY;
            float maxZ = GridBoxes[0].Box.MaxZ;

            for (int i = 1; i < GridBoxes.Count; i++)
            {
                BoundBox3D box = GridBoxes[i].Box;

                minX = Math.Min(minX, box.MinX);
                minY = Math.Min(minY, box.MinY);
                minZ = Math.Min(minZ, box.MinZ);
                maxX = Math.Max(maxX, box.MaxX);
                maxY = Math.Max(maxY, box.MaxY);
                maxZ = Math.Max(maxZ, box.MaxZ);
            }

            return new BoundBox3D(minX, minY, minZ, maxX, maxY, maxZ);
        }

        // ================================================
        // Grid Cut
        // ================================================

        // Viewer에 열린 원본 모델에서 지정 Grid Box 영역만 남김
        private bool KeepGridOnly(VIZCore3DX.NET.VIZCore3DXControl viewer, BoundBox3D box)
        {
            if (viewer == null || viewer.Model.IsOpen() == false) return false;
            if (box == null || box.IsValid() == false) return false;

            viewer.BeginUpdate();

            try
            {
                // 원본 Grid Box 기준 SelectionBox 생성
                int boxId = viewer.SelectionBox.Add(box, Color.FromArgb(10, Color.White), Color.Black, "");

                // Grid Box와 겹치는 원본 Part 후보 조회 box 경계에 걸친 Part까지 SplitMesh 대상으로 넣어야 하기 때문에 IncludingPart 사용
                List<Node> partNodes = viewer.SelectionBox.GetObject3DIndex(boxId, BoundBoxSearchOption.IncludingPart, false, true);

                if (partNodes == null || partNodes.Count == 0) return false;

                // 후보 Part만 남기고 나머지 삭제
                viewer.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);
                viewer.Object3D.Select(partNodes, true);
                viewer.Object3D.Select(Object3dSelectionModes.INVERT_SELECTION);

                List<Node> deleteNodes = viewer.Object3D.FromFilter(Object3dFilter.SELECTED_ALL);

                if (deleteNodes != null && deleteNodes.Count > 0)
                    viewer.Object3D.Delete(deleteNodes);

                viewer.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);

                // Box 경계 기준으로 Mesh 분할
                viewer.Object3D.SplitMesh(box);

                // SplitMesh 이후 생성된 조각 중 box 안에 들어온 애들만 다시 조회 너무 빡세게 잡히면 1.005f 또는 1.01f 정도로 살짝 키워야 함
                BoundBox3D searchBox = ExpandBoxByScale(box, 1.005f);
                int splitBoxId = viewer.SelectionBox.Add(searchBox, Color.FromArgb(10, Color.White), Color.Black, "");
                List<Node> keepNodes = viewer.SelectionBox.GetObject3DIndex(splitBoxId, BoundBoxSearchOption.FullyContained, false, true);

                // keepNodes가 없는데 INVERT_SELECTION 하면 전체 삭제될 수 있음
                if (keepNodes == null || keepNodes.Count == 0) return false;

                // box 안쪽 조각만 남기고 나머지 삭제
                viewer.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);
                viewer.Object3D.Select(keepNodes, true);
                viewer.Object3D.Select(Object3dSelectionModes.INVERT_SELECTION);

                List<Node> deleteAfterSplit = viewer.Object3D.FromFilter(Object3dFilter.SELECTED_ALL);

                if (deleteAfterSplit != null && deleteAfterSplit.Count > 0)
                    viewer.Object3D.Delete(deleteAfterSplit);

                viewer.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);

                return true;
            }
            finally
            {
                viewer.SelectionBox.Clear();
                viewer.Object3D.Select(Object3dSelectionModes.DESELECT_ALL);
                viewer.EndUpdate();
            }
        }

        private BoundBox3D ExpandBoxByScale(BoundBox3D box, float scale)
        {
            if (box == null || box.IsValid() == false) return box;
            if (scale <= 0.0f) scale = 1.0f;

            Vertex3D center = box.GetCenter();

            return new BoundBox3D(center, box.LengthX * scale, box.LengthY * scale, box.LengthZ * scale);
        }
    }
}