using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.Demo
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer2.Panel1.Controls.Add(vizcore3dx);

            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
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
            InitializeVIZCore3DXEvent();
        }

        private void InitializeVIZCore3DXEvent()
        {
            // Section Event
            vizcore3dx.Section.OnSectionEvent += Section_OnSectionEvent;
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
            ShowRibbonTabs(VIZCore3DX.NET.Data.ToolbarKind.Note, VIZCore3DX.NET.Data.ToolbarKind.Section);
            ShowAttributeTabs(true, true, true, true);

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }


        //==========================================================================
        // Model
        //==========================================================================
        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore3dx.Model.OpenFilter;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Model.Open(dlg.FileName);
        }

        private void btnAddModels_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore3dx.Model.OpenFilter;
            dlg.Multiselect = true;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Model.Add(dlg.FileNames);
        }

        private void btnCloseModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Model.Close();
        }

        private void btnModelBoundBox_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            VIZCore3DX.NET.Data.BoundBox3D box =
                vizcore3dx.Model.BoundBox;

            MessageBox.Show(box.ToString(), "Model BoundBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //==========================================================================
        // Object
        //==========================================================================
        private void btnAllObjects_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            List<VIZCore3DX.NET.Data.Node> nodes =
                vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.ALL);

            if (nodes.Count == 0)
            {
                MessageBox.Show("Node count is 0", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgView.DataSource = nodes;
        }

        private void btnSelectedAllObjects_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            List<VIZCore3DX.NET.Data.Node> nodes =
                vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_ALL);

            if (nodes.Count == 0)
            {
                MessageBox.Show("Node count is 0", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgView.DataSource = nodes;
        }

        private void btnSelectedTopObjects_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            List<VIZCore3DX.NET.Data.Node> nodes =
                vizcore3dx.Object3D.FromFilter(VIZCore3DX.NET.Data.Object3dFilter.SELECTED_TOP);

            if (nodes.Count == 0)
            {
                MessageBox.Show("Node count is 0", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgView.DataSource = nodes;
        }


        //==========================================================================
        // Section
        //==========================================================================
        #region Section
        private void btnAddSectionBox_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            VIZCore3DX.NET.Data.SectionItem section = vizcore3dx.Section.AddBox(false);
            if (section == null) return;

            MessageBox.Show(section.BoundBox.ToString(), "BoundBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClearSection_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Section.Clear();
        }

        private void btnUpdateSectionBoxSize_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            VIZCore3DX.NET.Data.BoundBox3D box = vizcore3dx.Model.BoundBox;

            // 모델 중심 기준으로 각 축 길이를 절반으로 줄인 박스
            box = new VIZCore3DX.NET.Data.BoundBox3D(box.GetCenter(), box.LengthX * 0.5f, box.LengthY * 0.5f, box.LengthZ * 0.5f);

            vizcore3dx.Section.Clear();
            VIZCore3DX.NET.Data.SectionItem section = vizcore3dx.Section.AddBox(true);
            if (section == null) return;

            vizcore3dx.Section.SetBoxSize(section.ID, box);
        }

        /// <summary>
        /// 단면상자 핸들 활성화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowHandle_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Section.ShowHandle();
        }

        /// <summary>
        /// Get Center
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetCenter_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            if (cbSectionID.SelectedItem == null || cbSectionSubID.SelectedItem == null) return;

            Vertex3D center = vizcore3dx.Section.GetCenter((uint)Convert.ToInt32(cbSectionID.SelectedItem), Convert.ToInt32(cbSectionSubID.SelectedItem));
            if (center == null) return;

            txtSectionX.Text = center.X.ToString();
            txtSectionY.Text = center.Y.ToString();
            txtSectionZ.Text = center.Z.ToString();
        }

        /// <summary>
        /// Set Center
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetCenter_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            if (String.IsNullOrEmpty(txtCenterPosition.Text)) return;
            if (cbSectionID.SelectedItem == null || cbSectionSubID.SelectedItem == null) return;

            float position;
            if (float.TryParse(txtCenterPosition.Text, out position) == false)
            {
                MessageBox.Show("Position 값을 숫자로 입력하세요.", "Section", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            vizcore3dx.Section.SetCenter((uint)Convert.ToInt32(cbSectionID.SelectedItem), Convert.ToInt32(cbSectionSubID.SelectedItem), position);
        }

        private void Section_OnSectionEvent(object sender, Event.EventManager.SectionEventArgs e)
        {
            cbSectionID.SelectedIndexChanged -= cbSectionID_SelectedIndexChanged;

            // Section 생성 이벤트
            if (e.EventType == Manager.SectionManager.EventType.Created)
            {
                cbSectionSubID.Items.Clear();

                cbSectionID.Items.Add(e.Section.ID);
                cbSectionID.SelectedItem = e.Section.ID;

                if (e.Section.SectionType == Manager.SectionManager.SectionTypes.SECTION)
                {
                    cbSectionSubID.Items.Add(-1);
                    cbSectionSubID.SelectedItem = -1;
                }
                else
                {
                    for (int i = 0; i < e.Section.Planes.Count; i++)
                    {
                        cbSectionSubID.Items.Add(i);
                    }
                    cbSectionSubID.SelectedItem = 0;
                }
            }
            // Section 삭제 이벤트
            else if (e.EventType == Manager.SectionManager.EventType.Deleted)
            {
                cbSectionID.Items.Remove(e.Section.ID);
                cbSectionSubID.Items.Clear();
            }

            cbSectionID.SelectedIndexChanged += cbSectionID_SelectedIndexChanged;
        }

        private void cbSectionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SectionItem section = vizcore3dx.Section.FromID((uint)Convert.ToInt32(cbSectionID.SelectedItem));

            cbSectionSubID.Items.Clear();
            if (section == null) return;

            if (section.SectionType == Manager.SectionManager.SectionTypes.SECTION)
            {
                cbSectionSubID.Items.Add(-1);
                cbSectionSubID.SelectedItem = -1;
            }
            else
            {
                for (int i = 0; i < section.Planes.Count; i++)
                {
                    cbSectionSubID.Items.Add(i);
                }

                cbSectionSubID.SelectedItem = 0;
            }
        }
        #endregion

        //==========================================================================
        // View
        //==========================================================================
        #region View
        private void btnXrayEnable_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.View.XRay.Enable = true;
        }

        private void btnXrayDisable_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.View.XRay.Enable = false;
        }

        private void btnXrayColor1_Click(object sender, EventArgs e)
        {
            vizcore3dx.View.XRay.ColorType = VIZCore3DX.NET.Data.XRayColorTypes.SELECTION_COLOR;
        }

        private void btnXrayColor2_Click(object sender, EventArgs e)
        {
            vizcore3dx.View.XRay.ColorType = VIZCore3DX.NET.Data.XRayColorTypes.OBJECT_COLOR;
        }

        private void btnXraySelectObjects_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string keyword = txtXrayObjects.Text;

            if (String.IsNullOrEmpty(keyword) == true)
            {
                MessageBox.Show("Keyword is empty", "Keyword", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> items =
                vizcore3dx.Object3D.Find.QuickSearch(keyword, false);

            if (items.Count == 0)
            {
                MessageBox.Show("Node count is 0", "Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vizcore3dx.View.XRay.Clear();
            vizcore3dx.View.XRay.Select(items, true);
        }

        private void btnXrayClearObjects_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.View.XRay.Clear();
        }

        private void btnSetColor_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string keyword = txtColorObjects.Text;

            if (String.IsNullOrEmpty(keyword) == true)
            {
                MessageBox.Show("Keyword is empty", "Keyword", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> items =
                vizcore3dx.Object3D.Find.QuickSearch(keyword, false);

            if (items.Count == 0)
            {
                MessageBox.Show("Node count is 0", "Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vizcore3dx.Object3D.Color.SetColor(items, Color.Yellow);
        }

        private void btnRestoreColor_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Object3D.Color.RestoreColor();
            //vizcore3dx.Object3D.Color.Restore();
            //vizcore3dx.Object3D.Color.RestoreAll();
            //vizcore3dx.Object3D.Color.RestoreColorAll();
        }

        private void btnSetAlpha_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string keyword = txtAlphaObjects.Text;

            if (String.IsNullOrEmpty(keyword) == true)
            {
                MessageBox.Show("Keyword is empty", "Keyword", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> items =
                vizcore3dx.Object3D.Find.QuickSearch(keyword, false);

            if (items.Count == 0)
            {
                MessageBox.Show("Node count is 0", "Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vizcore3dx.Object3D.Color.SetAlpha(items, 50);
        }

        private void btnRestoreAlpha_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Object3D.Color.RestoreAlpha();
            //vizcore3dx.Object3D.Color.RestoreAll();
            //vizcore3dx.Object3D.Color.RestoreColorAll();
        }

        /// <summary>
        /// 선택된 개체 재선택 시, 상위 개체 선택 기능 활성화/비활성화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckEnableParentSelection_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.View.EnableParentSelection = ckEnableParentSelection.Checked;
        }

        /// <summary>
        /// Mouse Double Click 시, 선택된 모델 초점 및 자동화면 맞춤 활성화/비활성화.
        /// 노드를 더블클릭 할 경우 해당 노드로 카메라 이동
        /// 배경을 더블클릭 할 경우 전체 모델이 화면에 보이도록 카메라 이동
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckEnableDoubleClickFocusAndFit_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.View.EnableDoubleClickFocusAndFit = ckEnableDoubleClickFocusAndFit.Checked;
        }

        /// <summary>
        /// 개체 선택 활성화/비활성화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckEnableSelection_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.View.EnableSelection = ckEnableSelection.Checked;
        }

        /// <summary>
        /// 마우스 오른쪽 버튼으로 개체 선택 활성화/비활성. 기본값 True
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckEnableSelectionMouseRButtonUp_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.View.EnableSelectionMouseRButtonUp = ckEnableSelectionMouseRButtonUp.Checked;
        }

        /// <summary>
        ///  확대/축소 비율
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numZoomRatio_ValueChanged(object sender, EventArgs e)
        {
            vizcore3dx.View.ZoomRatio = Convert.ToSingle(numZoomRatio.Value);
        }

        /// <summary>
        /// 선택된 개체의 BoundBox 가져오기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewGetBoundBox_Click(object sender, EventArgs e)
        {
            // 선택이 없으면 이전 값을 남기지 않고 Min/Max 칸을 비웁니다.
            txtViewBounboxMinX.Text = txtViewBounboxMinY.Text = txtViewBounboxMinZ.Text = string.Empty;
            txtViewBounboxMaxX.Text = txtViewBounboxMaxY.Text = txtViewBounboxMaxZ.Text = string.Empty;

            if (vizcore3dx.Model.IsOpen() == false) return;

            List<Node> selected = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP);
            if (selected == null || selected.Count == 0) return;

            Node node = selected[0];
            if (node == null) return;

            Data.BoundBox3D bb = node.GetBoundBox();

            txtViewBounboxMinX.Text = bb.MinX.ToString();
            txtViewBounboxMinY.Text = bb.MinY.ToString();
            txtViewBounboxMinZ.Text = bb.MinZ.ToString();

            txtViewBounboxMaxX.Text = bb.MaxX.ToString();
            txtViewBounboxMaxY.Text = bb.MaxY.ToString();
            txtViewBounboxMaxZ.Text = bb.MaxZ.ToString();
        }

        /// <summary>
        /// Box Zoom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewBoxZoom_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            if (String.IsNullOrEmpty(txtViewBounboxMinX.Text)
                || String.IsNullOrEmpty(txtViewBounboxMinY.Text)
                || String.IsNullOrEmpty(txtViewBounboxMinZ.Text)
                || String.IsNullOrEmpty(txtViewBounboxMaxX.Text)
                || String.IsNullOrEmpty(txtViewBounboxMaxY.Text)
                || String.IsNullOrEmpty(txtViewBounboxMaxZ.Text)) return;

            float minX, minY, minZ, maxX, maxY, maxZ;
            if (float.TryParse(txtViewBounboxMinX.Text, out minX) == false
                || float.TryParse(txtViewBounboxMinY.Text, out minY) == false
                || float.TryParse(txtViewBounboxMinZ.Text, out minZ) == false
                || float.TryParse(txtViewBounboxMaxX.Text, out maxX) == false
                || float.TryParse(txtViewBounboxMaxY.Text, out maxY) == false
                || float.TryParse(txtViewBounboxMaxZ.Text, out maxZ) == false)
            {
                MessageBox.Show("Min / Max 값을 숫자로 입력하세요.", "Box Zoom", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Data.Vector3D min = new Vector3D(minX, minY, minZ);
            Data.Vector3D max = new Vector3D(maxX, maxY, maxZ);

            TimeSpan timeSpan = TimeSpan.FromSeconds(1);

            vizcore3dx.View.BoxZoom(min, max, timeSpan);
        }
        #endregion

        //==========================================================================
        // UDA
        //==========================================================================
        #region UDA
        private void btnUDAInfo_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string keyword = txtUDA1.Text;

            if (String.IsNullOrEmpty(keyword) == true)
            {
                MessageBox.Show("Keyword is empty", "Keyword", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> items =
                vizcore3dx.Object3D.Find.QuickSearch(keyword, false);

            if (items.Count == 0)
            {
                MessageBox.Show("Node count is 0", "Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //vizcore3dx.Object3D.UDA.FromEntry(items[0].EntityID, items[0].Index) 함수 대체 소스 수정
            var udaItem = vizcore3dx.Object3D.UDA.FromNode(items[0]);
            if (udaItem == null)
            {
                MessageBox.Show("UDA is null", "Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Dictionary<string, string> uda = udaItem.ToDictionary();

            List<string> keyItems = new List<string>();
            List<string> valueItems = new List<string>();

            ICollection<string> keys = uda.Keys;
            foreach (string key in keys)
            {
                keyItems.Add(key);
            }

            ICollection<string> values = uda.Values;
            foreach (string value in values)
            {
                valueItems.Add(value);
            }

            lvUDAResult.Columns[0].Text = "Key";
            lvUDAResult.Columns[1].Text = "Value";

            if (lvUDAResult.Items.Count > 0) lvUDAResult.Items.Clear();

            for (int i = 0; i < keyItems.Count; i++)
            {
                ListViewItem listView = new ListViewItem(new string[] { keyItems[i], valueItems[i] });
                lvUDAResult.Items.Add(listView);
            }
        }

        private void btnUDAKeys_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            List<string> keys = vizcore3dx.Object3D.UDA.Names;

            if (keys.Count == 0)
            {
                MessageBox.Show("UDA-Key is null", "Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lvUDAResult.Columns[0].Text = "Key";
            lvUDAResult.Columns[1].Text = "Value";

            if (lvUDAResult.Items.Count > 0) lvUDAResult.Items.Clear();

            for (int i = 0; i < keys.Count; i++)
            {
                ListViewItem listView = new ListViewItem(new string[] { keys[i] });
                lvUDAResult.Items.Add(listView);
            }
        }

        private void btnUDAValues_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string keyword = txtUDAKey.Text;

            if (String.IsNullOrEmpty(keyword) == true)
            {
                MessageBox.Show("Keyword is empty", "Keyword", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> values = vizcore3dx.Object3D.UDA.GetValues(keyword);

            if (values.Count == 0)
            {
                MessageBox.Show("UDA-Value is null", "Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lvUDAResult.Columns[0].Text = "Key";
            lvUDAResult.Columns[1].Text = "Value";

            if (lvUDAResult.Items.Count > 0) lvUDAResult.Items.Clear();

            for (int i = 0; i < values.Count; i++)
            {
                ListViewItem listView = new ListViewItem(new string[] { keyword, values[i] });
                lvUDAResult.Items.Add(listView);
            }
        }

        private void btnUDANodes_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            string key = txtUDAKey1.Text;

            if (String.IsNullOrEmpty(key) == true)
            {
                MessageBox.Show("Keyword is empty", "Keyword", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string val = txtUDAValue1.Text;

            if (String.IsNullOrEmpty(val) == true)
            {
                MessageBox.Show("Keyword is empty", "Keyword", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<VIZCore3DX.NET.Data.Node> nodes = vizcore3dx.Object3D.UDA.GetCategoryNameValueNodes("General", key, val, false);

            if (nodes.Count == 0)
            {
                MessageBox.Show("Node count is 0", "Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lvUDAResult.Columns[0].Text = "EntityID";
            lvUDAResult.Columns[1].Text = "Index";

            if (lvUDAResult.Items.Count > 0) lvUDAResult.Items.Clear();

            for (int i = 0; i < nodes.Count; i++)
            {
                ListViewItem listView = new ListViewItem(new string[] { nodes[i].EntityID.ToString(), nodes[i].Index.ToString() });
                lvUDAResult.Items.Add(listView);
            }
        }
        #endregion

        //==========================================================================
        // Note
        //==========================================================================
        #region Note
        /// <summary>
        /// 표면 노트 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoteSurfaceNote_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            vizcore3dx.Note.AddNoteSurfaceDialog();
        }

        /// <summary>
        /// 2D 노트 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNote2DNote_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            vizcore3dx.Note.AddNote2DDialog();
        }

        /// <summary>
        /// 3D 노트 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNote3DNote_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            vizcore3dx.Note.AddNote3DDialog();
        }

        /// <summary>
        /// 선택된 노트 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoteDelete_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            vizcore3dx.Note.Delete();
        }

        /// <summary>
        /// 노트 모두 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoteClear_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            vizcore3dx.Note.Clear();
        }

        /// <summary>
        /// Box Fill Color 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoteBoxFillColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.AllowFullOpen = true;
            dlg.ShowHelp = true;
            dlg.Color = btnNoteBoxFillColor.BackColor;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            btnNoteBoxFillColor.BackColor = dlg.Color;

            NoteStyle noteStyle = vizcore3dx.Note.GetStyle();
            noteStyle.BoxFillColor = Color.FromArgb(Convert.ToInt32(numNoteBoxFillAlpha.Value), dlg.Color.R, dlg.Color.G, dlg.Color.B);
            vizcore3dx.Note.SetStyle(noteStyle);
        }

        /// <summary>
        /// Box Stroke Color 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoteBoxStrokeColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.AllowFullOpen = true;
            dlg.ShowHelp = true;
            dlg.Color = btnNoteBoxStrokeColor.BackColor;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            btnNoteBoxStrokeColor.BackColor = dlg.Color;

            NoteStyle noteStyle = vizcore3dx.Note.GetStyle();
            noteStyle.BoxStrokeColor = Color.FromArgb(Convert.ToInt32(numNoteBoxStrokeAlpha.Value), dlg.Color.R, dlg.Color.G, dlg.Color.B);
            vizcore3dx.Note.SetStyle(noteStyle);
        }

        /// <summary>
        /// 배경색 없음 옵션
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckNoteBackgroundTransparent_CheckedChanged(object sender, EventArgs e)
        {
            if (ckNoteBackgroundTransparent.Checked == true)
            {
                NoteStyle noteStyle = vizcore3dx.Note.GetStyle();
                noteStyle.BoxFillColor = Color.FromArgb(0, btnNoteBoxFillColor.BackColor.R, btnNoteBoxFillColor.BackColor.G, btnNoteBoxFillColor.BackColor.B);
                noteStyle.BoxStrokeColor = Color.FromArgb(0, btnNoteBoxStrokeColor.BackColor.R, btnNoteBoxStrokeColor.BackColor.G, btnNoteBoxStrokeColor.BackColor.B);
                vizcore3dx.Note.SetStyle(noteStyle);
            }
            else
            {
                NoteStyle noteStyle = vizcore3dx.Note.GetStyle();
                noteStyle.BoxFillColor = Color.FromArgb(Convert.ToInt32(numNoteBoxFillAlpha.Value), btnNoteBoxFillColor.BackColor.R, btnNoteBoxFillColor.BackColor.G, btnNoteBoxFillColor.BackColor.B);
                noteStyle.BoxStrokeColor = Color.FromArgb(Convert.ToInt32(numNoteBoxStrokeAlpha.Value), btnNoteBoxStrokeColor.BackColor.R, btnNoteBoxStrokeColor.BackColor.G, btnNoteBoxStrokeColor.BackColor.B);
                vizcore3dx.Note.SetStyle(noteStyle);
            }

        }
        #endregion

        //==========================================================================
        // ModelTree
        //==========================================================================
        #region ModelTree
        /// <summary>
        /// ModelTree Focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModelTreeFocus_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;
            if (String.IsNullOrEmpty(txtModelTreeIndex.Text)) return;

            List<Node> found = vizcore3dx.Object3D.GetNodes(txtModelTreeIndex.Text);
            if (found == null || found.Count == 0) return;

            Node node = found[0];
            if (node == null) return;

            vizcore3dx.ModelTree.Focus(node);
        }
        #endregion

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
