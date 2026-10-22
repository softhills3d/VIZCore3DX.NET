using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VIZCore3DX.NET.MarkupCategory
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        public FrmMain()
        {
            InitializeComponent();

            // 뷰어와 무관한 콤보 항목은 생성자에서 채웁니다.
            cmbKind.Items.AddRange(new object[] { "노트", "측정", "데칼", "스냅샷", "형상" });
            cmbKind.SelectedIndex = 0;

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
            ShowRibbonTabs(VIZCore3DX.NET.Data.ToolbarKind.Note, VIZCore3DX.NET.Data.ToolbarKind.Measure, VIZCore3DX.NET.Data.ToolbarKind.Snapshot, VIZCore3DX.NET.Data.ToolbarKind.Decal);
            ShowAttributeTabs();

            SetStatus("모델을 열어 주세요.");
        }

        #region 1. 모델
        // 마크업을 올려 둘 모델을 엽니다.
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            RefreshCategories();
            SetStatus("모델을 열었습니다. 카테고리와 종류를 고른 뒤 추가하세요.");
        }
        #endregion

        #region 3. 실행
        // 고른 종류의 마크업을 입력한 카테고리로 묶어 추가합니다.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            string category = txtCategory.Text.Trim();
            if (category.Length == 0)
            {
                SetStatus("카테고리를 입력하세요.");
                return;
            }

            int kind = cmbKind.SelectedIndex;
            int count = (int)numCount.Value;
            AddItems(kind, category, count);
            RefreshCategories();

            // 노트·스냅샷은 3차원 위치가 없으므로 카메라를 맞출 필요가 없습니다.
            if (kind == 1 || kind == 2 || kind == 4) vizcore3dx.View.FitToView();

            SetStatus(string.Format("{0} : {1} {2}개 추가", category, KindName(kind), count));
        }

        // 다섯 종류의 마크업을 모두 같은 카테고리로 추가합니다.
        private void btnAddAllKinds_Click(object sender, EventArgs e)
        {
            if (!IsModelOpened()) return;

            string category = txtCategory.Text.Trim();
            if (category.Length == 0)
            {
                SetStatus("카테고리를 입력하세요.");
                return;
            }

            int count = (int)numCount.Value;
            for (int kind = 0; kind < 5; kind++)
                AddItems(kind, category, count);
            RefreshCategories();

            vizcore3dx.View.FitToView();
            SetStatus(string.Format("{0} : 5종 각 {1}개 추가", category, count));
        }
        #endregion

        #region 4. 결과
        // 표에서 고른 카테고리를 입력칸에 옮깁니다.
        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0) return;

            txtCategory.Text = Convert.ToString(dgvCategories.SelectedRows[0].Cells[0].Value);
        }

        // 카테고리에 속한 마크업을 종류와 관계없이 한꺼번에 보입니다.
        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowCategory(true);
        }

        // 카테고리에 속한 마크업을 종류와 관계없이 한꺼번에 숨깁니다.
        private void btnHide_Click(object sender, EventArgs e)
        {
            ShowCategory(false);
        }

        // 카테고리에 속한 마크업을 다섯 종류 모두에서 지웁니다.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string category = CurrentCategory();
            if (category.Length == 0)
            {
                SetStatus("삭제할 카테고리를 고르세요.");
                return;
            }

            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.Note.Delete(category);
                vizcore3dx.Measure.Delete(category);
                vizcore3dx.Decal.Delete(category);
                vizcore3dx.Snapshot.Delete(category);
                vizcore3dx.Shape.Delete(category);
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            RefreshCategories();
            SetStatus(string.Format("{0} 카테고리를 삭제했습니다.", category));
        }

        // 각 종류의 카테고리 목록을 다시 읽어 표를 채웁니다.
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshCategories();
            SetStatus(string.Format("카테고리 {0}개", dgvCategories.Rows.Count));
        }
        #endregion

        #region 5. 정리
        // 다섯 종류의 마크업을 카테고리와 관계없이 모두 지웁니다.
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.Note.Clear();
                vizcore3dx.Measure.Clear();
                vizcore3dx.Decal.Clear();
                vizcore3dx.Snapshot.Clear();
                vizcore3dx.Shape.Clear();
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            RefreshCategories();
            SetStatus("마크업을 모두 지웠습니다.");
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

        // 콤보 순서(노트, 측정, 데칼, 스냅샷, 형상)의 이름입니다.
        private string KindName(int kind)
        {
            switch (kind)
            {
                case 1: return "측정";
                case 2: return "데칼";
                case 3: return "스냅샷";
                case 4: return "형상";
                default: return "노트";
            }
        }

        // 표에서 고른 카테고리, 없으면 입력칸의 카테고리입니다.
        private string CurrentCategory()
        {
            if (dgvCategories.SelectedRows.Count > 0)
                return Convert.ToString(dgvCategories.SelectedRows[0].Cells[0].Value);

            return txtCategory.Text.Trim();
        }

        // 다섯 종류의 카테고리를 중복 없이 모아 정렬합니다.
        private List<string> AllCategories()
        {
            List<string> categories = new List<string>();
            List<List<string>> sources = new List<List<string>>
            {
                vizcore3dx.Note.GetCategories(),
                vizcore3dx.Measure.GetCategories(),
                vizcore3dx.Decal.GetCategories(),
                vizcore3dx.Snapshot.GetCategories(),
                vizcore3dx.Shape.GetCategories()
            };

            foreach (List<string> source in sources)
                foreach (string category in source)
                    if (!categories.Contains(category)) categories.Add(category);

            categories.Sort();
            return categories;
        }

        // 카테고리마다 종류별 개수를 한 행으로 채웁니다. 입력 중인 카테고리는 그대로 둡니다.
        private void RefreshCategories()
        {
            string keep = txtCategory.Text;

            dgvCategories.Rows.Clear();
            foreach (string category in AllCategories())
            {
                dgvCategories.Rows.Add(category,
                    vizcore3dx.Note.FromCategory(category).Count,
                    vizcore3dx.Measure.FromCategory(category).Count,
                    vizcore3dx.Decal.FromCategory(category).Count,
                    vizcore3dx.Snapshot.FromCategory(category).Count,
                    vizcore3dx.Shape.FromCategory(category).Count);
            }

            // 행을 넣으면 첫 행이 자동으로 선택되므로, 입력칸과 같은 행만 다시 고릅니다.
            dgvCategories.ClearSelection();
            txtCategory.Text = keep;
            foreach (DataGridViewRow row in dgvCategories.Rows)
                if (Convert.ToString(row.Cells[0].Value) == keep.Trim()) row.Selected = true;
        }

        // 보이기/숨기기는 노트·측정·데칼·형상에만 있습니다.
        private void ShowCategory(bool visible)
        {
            string category = CurrentCategory();
            if (category.Length == 0)
            {
                SetStatus("카테고리를 고르세요.");
                return;
            }

            vizcore3dx.BeginUpdate();
            try
            {
                vizcore3dx.Note.Show(visible, category);
                vizcore3dx.Measure.Show(visible, category);
                vizcore3dx.Decal.Show(visible, category);
                vizcore3dx.Shape.Show(visible, category);
                // 스냅샷은 화면에 그려지는 마크업이 아니므로 보이기/숨기기가 없습니다.
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }

            SetStatus(string.Format("{0} 카테고리를 {1}", category, visible ? "보였습니다." : "숨겼습니다."));
        }

        // 종류별로 마크업을 만들고 카테고리를 지정합니다.
        private void AddItems(int kind, string category, int count)
        {
            int row = CategoryRow(category);

            vizcore3dx.BeginUpdate();
            try
            {
                switch (kind)
                {
                    case 1: AddMeasures(category, count, row); break;
                    case 2: AddDecals(category, count, row); break;
                    case 3: AddSnapshots(category, count); break;
                    case 4: AddShapes(category, count, row); break;
                    default: AddNotes(category, count, row); break;
                }
            }
            finally
            {
                vizcore3dx.EndUpdate();
            }
        }

        // 표에 이미 있는 카테고리는 그 행 번호, 새 카테고리는 다음 행 번호입니다.
        private int CategoryRow(string category)
        {
            for (int i = 0; i < dgvCategories.Rows.Count; i++)
                if (Convert.ToString(dgvCategories.Rows[i].Cells[0].Value) == category) return i;

            return dgvCategories.Rows.Count;
        }

        // 노트는 화면 비율(0~1) 좌표에 놓입니다. 카테고리 행마다 아래로 내려 겹치지 않게 합니다.
        private void AddNotes(string category, int count, int row)
        {
            for (int i = 0; i < count; i++)
            {
                float x = Math.Min(0.9f, 0.15f + 0.12f * i);
                float y = Math.Min(0.9f, 0.15f + 0.1f * row);
                uint id = vizcore3dx.Note.AddNote2D(string.Format("{0} N{1}", category, i + 1), x, y);
                vizcore3dx.Note.GetItem(id).Category = category;
            }
        }

        // 측정은 만든 뒤 목록의 마지막 항목에 카테고리를 지정합니다.
        private void AddMeasures(string category, int count, int row)
        {
            float step = Step();
            for (int i = 0; i < count; i++)
            {
                VIZCore3DX.NET.Data.Vector3D p1 = ItemPosition(i, count, row);
                VIZCore3DX.NET.Data.Vector3D p2 = p1 + new VIZCore3DX.NET.Data.Vector3D(step * 0.6f, 0, 0);
                vizcore3dx.Measure.AddCustomDistance(p1, p2);

                List<VIZCore3DX.NET.Data.MeasureItem> measures = vizcore3dx.Measure.Measures;
                if (measures.Count > 0) measures[measures.Count - 1].Category = category;
            }
        }

        // 데칼은 모델 윗면 높이에 위(+Z)를 향하도록 붙이고, 목록의 마지막 항목에 카테고리를 지정합니다.
        private void AddDecals(string category, int count, int row)
        {
            float height = Step() * 0.2f;
            for (int i = 0; i < count; i++)
            {
                vizcore3dx.Decal.AddDecalText(string.Format("{0} D{1}", category, i + 1), System.Drawing.Color.Black, ItemPosition(i, count, row),
                    new VIZCore3DX.NET.Data.Vector3D(0, 0, 1), new VIZCore3DX.NET.Data.Vector3D(0, 1, 0), height);

                List<VIZCore3DX.NET.Data.DecalItem> decals = vizcore3dx.Decal.Decals;
                if (decals.Count > 0) decals[decals.Count - 1].Category = category;
            }
        }

        // 스냅샷은 현재 화면을 저장하므로 위치가 필요 없습니다.
        private void AddSnapshots(string category, int count)
        {
            for (int i = 0; i < count; i++)
            {
                uint id = vizcore3dx.Snapshot.Add(string.Format("{0} S{1}", category, i + 1));
                vizcore3dx.Snapshot.GetItem(id).Category = category;
            }
        }

        // 형상은 만들 때 돌려받은 항목에 바로 카테고리를 지정합니다.
        private void AddShapes(string category, int count, int row)
        {
            for (int i = 0; i < count; i++)
            {
                VIZCore3DX.NET.Data.ShapeItem.PointShape shape = vizcore3dx.Shape.CreatePointShape(ItemPosition(i, count, row), 6.0f, System.Drawing.Color.Red);
                shape.Category = category;
            }
        }

        // 배치 간격: 모델 상자 최대 길이의 10%
        private float Step()
        {
            return vizcore3dx.Model.BoundBox.MaxLength * 0.1f;
        }

        // 모델 상자 위에 X 방향 한 줄로 놓고, 카테고리 행마다 Y 방향으로 한 칸씩 옮깁니다.
        private VIZCore3DX.NET.Data.Vector3D ItemPosition(int i, int count, int row)
        {
            VIZCore3DX.NET.Data.BoundBox3D box = vizcore3dx.Model.BoundBox;
            float step = box.MaxLength * 0.1f;
            float x = box.CenterX - step * (count - 1) / 2f + step * i;
            float y = box.CenterY + step * row;
            float z = box.MaxZ + step * 0.5f;
            return new VIZCore3DX.NET.Data.Vector3D(x, y, z);
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
