using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.PMI
{
    public partial class FrmMain : Form
    {
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

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

            vizcore3dx.PMI.OnPmiEvent += PMI_OnPmiEvent;
            vizcore3dx.PMI.OnPmiElementEvent += PMI_OnPmiElementEvent;

            RefreshPmiData();
        }

        private bool CheckPmi()
        {
            if (vizcore3dx.PMI.Pmis.Count > 0) return true;

            MessageBox.Show("PMI가 포함된 모델을 열어주세요.", "VIZCore3DX.NET.PMI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        private void RefreshPmiData()
        {
            cmbPmiName.Items.Clear();
            cmbCategory.Items.Clear();
            cmbType.Items.Clear();

            cmbPmiName.DisplayMember = "Name";
            lblCategoryCount.Text = "0개";
            lblTypeCount.Text = "0개";

            foreach (PmiItem pmi in vizcore3dx.PMI.Pmis) cmbPmiName.Items.Add(pmi);
            foreach (PmiCategory category in vizcore3dx.PMI.GetCountByCategory().Keys) cmbCategory.Items.Add(category);
            foreach (PmiType type in vizcore3dx.PMI.GetCountByType().Keys) cmbType.Items.Add(type);

            if (cmbPmiName.Items.Count > 0) cmbPmiName.SelectedIndex = 0;
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            if (cmbType.Items.Count > 0) cmbType.SelectedIndex = 0;

            IReadOnlyList<PmiElement> elements = vizcore3dx.PMI.FindElements(element => true);

            lblPmiCount.Text = string.Format("PMI : {0}개", vizcore3dx.PMI.Pmis.Count);
            lblElementTotalCount.Text = string.Format("PMI 요소 : {0}개", elements.Count);

            ShowElements(elements);
            RefreshViewList();
        }

        private void ShowElements(IEnumerable<PmiElement> elements)
        {
            dgvElements.Rows.Clear();

            int index = 1;

            foreach (PmiElement element in elements)
            {
                if (element == null || element.IsValid == false) continue;

                int rowIndex = dgvElements.Rows.Add(element.IsVisible, index, element.ParentPmi == null ? string.Empty : element.ParentPmi.Name, element.Category.ToString(), element.Type.ToString());
                dgvElements.Rows[rowIndex].Tag = element;
                index++;
            }

            lblResultCount.Text = string.Format("조회 결과 : {0}개", dgvElements.Rows.Count);
        }

        private void SetCurrentListVisible(bool visible)
        {
            Dictionary<PmiItem, List<PmiElement>> groups = new Dictionary<PmiItem, List<PmiElement>>();

            foreach (DataGridViewRow row in dgvElements.Rows)
            {
                PmiElement element = row.Tag as PmiElement;
                if (element == null || element.IsValid == false || element.ParentPmi == null) continue;

                List<PmiElement> elements;
                if (!groups.TryGetValue(element.ParentPmi, out elements))
                {
                    elements = new List<PmiElement>();
                    groups.Add(element.ParentPmi, elements);
                }

                elements.Add(element);
            }

            foreach (KeyValuePair<PmiItem, List<PmiElement>> group in groups) group.Key.SetElementsVisible(group.Value, visible);

            RefreshVisibleCells();
        }

        private void RefreshVisibleCells()
        {
            foreach (DataGridViewRow row in dgvElements.Rows)
            {
                PmiElement element = row.Tag as PmiElement;
                if (element == null || element.IsValid == false) continue;

                row.Cells[colVisible.Index].Value = element.IsVisible;
            }
        }

        private List<PmiElement> GetSelectedElements()
        {
            List<PmiElement> elements = new List<PmiElement>();

            foreach (DataGridViewRow row in dgvElements.SelectedRows)
            {
                PmiElement element = row.Tag as PmiElement;
                if (element != null && element.IsValid) elements.Add(element);
            }

            return elements;
        }

        private void RefreshViewList()
        {
            lvViews.BeginUpdate();
            lvViews.Items.Clear();

            for (int i = 0; i < vizcore3dx.PMI.Views.Count; i++)
            {
                PmiView view = vizcore3dx.PMI.Views[i];

                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(view == null ? string.Empty : view.ToString());
                item.Tag = view;

                lvViews.Items.Add(item);
            }

            lvViews.EndUpdate();

            lblViewCount.Text = string.Format("PMI 뷰 : {0}개", vizcore3dx.PMI.Views.Count);

            PmiView activeView = vizcore3dx.PMI.ActiveView;
            int activeViewIndex = vizcore3dx.PMI.ActiveViewIndex;

            lblActiveView.Text = activeView == null ? "현재 활성 뷰 : 없음" : string.Format("현재 활성 뷰 : {0}", activeView);
            lblActiveViewIndex.Text = string.Format("활성 뷰 인덱스 : {0}", activeViewIndex);

            if (activeViewIndex >= 0 && activeViewIndex < lvViews.Items.Count)
            {
                lvViews.Items[activeViewIndex].Selected = true;
                lvViews.Items[activeViewIndex].EnsureVisible();
            }
        }

        private void RefreshViewState()
        {
            RefreshViewList();
            RefreshVisibleCells();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem == null)
            {
                lblCategoryCount.Text = "0개";
                return;
            }

            PmiCategory category = (PmiCategory)cmbCategory.SelectedItem;
            IReadOnlyDictionary<PmiCategory, int> counts = vizcore3dx.PMI.GetCountByCategory();
            lblCategoryCount.Text = string.Format("{0}개", counts.ContainsKey(category) ? counts[category] : 0);
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedItem == null)
            {
                lblTypeCount.Text = "0개";
                return;
            }

            PmiType type = (PmiType)cmbType.SelectedItem;
            IReadOnlyDictionary<PmiType, int> counts = vizcore3dx.PMI.GetCountByType();
            lblTypeCount.Text = string.Format("{0}개", counts.ContainsKey(type) ? counts[type] : 0);
        }

        private void dgvElements_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvElements.IsCurrentCellDirty) dgvElements.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvElements_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colVisible.Index) return;

            DataGridViewRow row = dgvElements.Rows[e.RowIndex];
            PmiElement element = row.Tag as PmiElement;
            if (element == null || element.IsValid == false) return;

            bool visible = Convert.ToBoolean(row.Cells[colVisible.Index].Value);
            if (element.IsVisible == visible) return;

            element.IsVisible = visible;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPmiData();
        }

        private void btnPmiElements_Click(object sender, EventArgs e)
        {
            if (!CheckPmi()) return;

            PmiItem pmi = cmbPmiName.SelectedItem as PmiItem;
            if (pmi == null) return;

            ShowElements(pmi.Elements);
        }

        private void btnCategoryElements_Click(object sender, EventArgs e)
        {
            if (!CheckPmi()) return;
            if (cmbCategory.SelectedItem == null) return;

            ShowElements(vizcore3dx.PMI.FromCategory((PmiCategory)cmbCategory.SelectedItem));
        }

        private void btnTypeElements_Click(object sender, EventArgs e)
        {
            if (!CheckPmi()) return;
            if (cmbType.SelectedItem == null) return;

            ShowElements(vizcore3dx.PMI.FromType((PmiType)cmbType.SelectedItem));
        }

        private void btnAllElements_Click(object sender, EventArgs e)
        {
            if (!CheckPmi()) return;

            ShowElements(vizcore3dx.PMI.FindElements(element => true));
        }

        private void btnCategoryTypeElements_Click(object sender, EventArgs e)
        {
            if (!CheckPmi()) return;
            if (cmbCategory.SelectedItem == null || cmbType.SelectedItem == null) return;

            PmiCategory category = (PmiCategory)cmbCategory.SelectedItem;
            PmiType type = (PmiType)cmbType.SelectedItem;

            ShowElements(vizcore3dx.PMI.FindElements(element => element.Category == category && element.Type == type));
        }

        private void btnCurrentListShow_Click(object sender, EventArgs e)
        {
            if (!CheckPmi()) return;

            SetCurrentListVisible(true);
        }

        private void btnCurrentListHide_Click(object sender, EventArgs e)
        {
            if (!CheckPmi()) return;

            SetCurrentListVisible(false);
        }

        private void btnElementColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = btnElementColor.BackColor;

                if (dialog.ShowDialog() != DialogResult.OK) return;

                btnElementColor.BackColor = dialog.Color;
            }
        }

        private void btnSetElementsColor_Click(object sender, EventArgs e)
        {
            if (!CheckPmi()) return;

            List<PmiElement> elements = GetSelectedElements();

            if (elements.Count == 0)
            {
                MessageBox.Show("색상을 변경할 PMI 요소의 행을 선택해주세요.", "VIZCore3DX.NET.PMI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            vizcore3dx.PMI.SetElementsColor(elements, btnElementColor.BackColor);
        }

        private void btnResetElementsColor_Click(object sender, EventArgs e)
        {
            if (!CheckPmi()) return;

            List<PmiElement> elements = GetSelectedElements();

            if (elements.Count == 0)
            {
                MessageBox.Show("색상을 초기화할 PMI 요소의 행을 선택해주세요.", "VIZCore3DX.NET.PMI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            vizcore3dx.PMI.ResetElementsColor(elements);
        }

        private void btnResetColors_Click(object sender, EventArgs e)
        {
            if (!CheckPmi()) return;

            vizcore3dx.PMI.ResetColors();
        }

        private void btnActivateView_Click(object sender, EventArgs e)
        {
            if (!CheckPmi()) return;

            if (lvViews.SelectedItems.Count == 0)
            {
                MessageBox.Show("활성화할 PMI 뷰를 선택해주세요.", "VIZCore3DX.NET.PMI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PmiView view = lvViews.SelectedItems[0].Tag as PmiView;
            if (view == null) return;

            vizcore3dx.PMI.ActivateView(view);

            RefreshViewState();
        }

        private void btnDeactivateView_Click(object sender, EventArgs e)
        {
            if (!CheckPmi()) return;

            vizcore3dx.PMI.DeactivateView();

            RefreshViewState();
        }

        private void btnPreviousView_Click(object sender, EventArgs e)
        {
            if (!CheckPmi()) return;

            vizcore3dx.PMI.PreviousView();

            RefreshViewState();
        }

        private void btnNextView_Click(object sender, EventArgs e)
        {
            if (!CheckPmi()) return;

            vizcore3dx.PMI.NextView();

            RefreshViewState();
        }

        private void btnRefreshViews_Click(object sender, EventArgs e)
        {
            RefreshViewState();
        }

        private void PMI_OnPmiEvent(object sender, VIZCore3DX.NET.Event.EventManager.PmiEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => PMI_OnPmiEvent(sender, e)));
                return;
            }

            RefreshPmiData();
        }

        private void PMI_OnPmiElementEvent(object sender, VIZCore3DX.NET.Event.EventManager.PmiElementEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => PMI_OnPmiElementEvent(sender, e)));
                return;
            }

            if (e == null) return;

            if (e.EventType == VIZCore3DX.NET.Manager.PmiManager.ElementEventType.Shown || e.EventType == VIZCore3DX.NET.Manager.PmiManager.ElementEventType.Hidden || e.EventType == VIZCore3DX.NET.Manager.PmiManager.ElementEventType.Updated) RefreshVisibleCells();
        }
    }
}
