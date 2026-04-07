using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.ModelComparison
{
    public partial class FrmMain : Form
    {
        // 모델 비교를 위한 두 개의 VIZCore3DXControl
        private VIZCore3DX.NET.VIZCore3DXControl vizcore1;
        private VIZCore3DX.NET.VIZCore3DXControl vizcore2;

        public FrmMain()
        {
            InitializeComponent();

            VIZCore3DX.NET.ModuleInitializer.Run();

            // 모델1 뷰어 생성 및 분할 패널 왼쪽에 배치
            vizcore1 = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore1.Dock = DockStyle.Fill;
            splitContainer2.Panel1.Controls.Add(vizcore1);

            vizcore1.OnInitializedVIZCore3DX += VIZCore3D1_OnInitializedVIZCore3DX;

            // 모델2 뷰어 생성 및 분할 패널 오른쪽에 배치
            vizcore2 = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore2.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(vizcore2);

            vizcore2.OnInitializedVIZCore3DX += VIZCore3D2_OnInitializedVIZCore3DX;

            // 분할 패널을 좌우 동일한 크기로 설정
            splitContainer2.SplitterDistance = this.Width / 2;
        }

        #region Event - OnInitializedVIZCore3DX
        private void VIZCore3D1_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            #region 라이선스
            VIZCore3DX.NET.Utility.LicenseHelper.LicenseData licenseData = VIZCore3DX.NET.Utility.LicenseHelper.GetLicenseDataKind();

            if (licenseData == VIZCore3DX.NET.Utility.LicenseHelper.LicenseData.NONE)
            {
                VIZCore3DX.NET.Dialogs.LicenseDialog dlg = new VIZCore3DX.NET.Dialogs.LicenseDialog(vizcore1);
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    this.Close();
                    return;
                }
            }

            licenseData = VIZCore3DX.NET.Utility.LicenseHelper.GetLicenseDataKind();

            Dictionary<string, string> licenseInfo = VIZCore3DX.NET.Utility.LicenseHelper.GetLicenseInformation();
            VIZCore3DX.NET.Data.LicenseResults licenseResult = VIZCore3DX.NET.Data.LicenseResults.NONE;

            if (licenseData == VIZCore3DX.NET.Utility.LicenseHelper.LicenseData.SERVER)
            {
                licenseResult = vizcore1.License.LicenseServer(
                    licenseInfo.ContainsKey("LICENSE_IP") == true ? licenseInfo["LICENSE_IP"] : String.Empty
                    , licenseInfo.ContainsKey("LICENSE_PORT") == true ? Convert.ToInt32(licenseInfo["LICENSE_PORT"]) : 8901
                    , VIZCore3DX.NET.Data.Products.AUTO
                    );
            }
            else if (licenseData == VIZCore3DX.NET.Utility.LicenseHelper.LicenseData.FILE)
            {
                licenseResult = vizcore1.License.LicenseFile(
                    licenseInfo.ContainsKey("LICENSE_FILE") == true ? licenseInfo["LICENSE_FILE"] : String.Empty
                    , VIZCore3DX.NET.Data.Products.AUTO
                    );
            }

            if (licenseResult != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", licenseResult.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                VIZCore3DX.NET.Dialogs.LicenseDialog dlg = new VIZCore3DX.NET.Dialogs.LicenseDialog(vizcore1);
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    this.Close();
                    return;
                }
            }
            #endregion

            // 모델1 뷰어에서 불필요한 툴바 숨김
            vizcore1.ToolbarNote.Visible = false;
            vizcore1.ToolbarMeasure.Visible = false;
            vizcore1.ToolbarSection.Visible = false;
            vizcore1.ToolbarClash.Visible = false;
            vizcore1.ToolbarAnimation.Visible = false;

        }

        private void VIZCore3D2_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            #region 라이선스
            VIZCore3DX.NET.Utility.LicenseHelper.LicenseData licenseData = VIZCore3DX.NET.Utility.LicenseHelper.GetLicenseDataKind();

            if (licenseData == VIZCore3DX.NET.Utility.LicenseHelper.LicenseData.NONE)
            {
                VIZCore3DX.NET.Dialogs.LicenseDialog dlg = new VIZCore3DX.NET.Dialogs.LicenseDialog(vizcore2);
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    this.Close();
                    return;
                }
            }

            licenseData = VIZCore3DX.NET.Utility.LicenseHelper.GetLicenseDataKind();

            Dictionary<string, string> licenseInfo = VIZCore3DX.NET.Utility.LicenseHelper.GetLicenseInformation();
            VIZCore3DX.NET.Data.LicenseResults licenseResult = VIZCore3DX.NET.Data.LicenseResults.NONE;

            if (licenseData == VIZCore3DX.NET.Utility.LicenseHelper.LicenseData.SERVER)
            {
                licenseResult = vizcore2.License.LicenseServer(
                    licenseInfo.ContainsKey("LICENSE_IP") == true ? licenseInfo["LICENSE_IP"] : String.Empty
                    , licenseInfo.ContainsKey("LICENSE_PORT") == true ? Convert.ToInt32(licenseInfo["LICENSE_PORT"]) : 8901
                    , VIZCore3DX.NET.Data.Products.AUTO
                    );
            }
            else if (licenseData == VIZCore3DX.NET.Utility.LicenseHelper.LicenseData.FILE)
            {
                licenseResult = vizcore2.License.LicenseFile(
                    licenseInfo.ContainsKey("LICENSE_FILE") == true ? licenseInfo["LICENSE_FILE"] : String.Empty
                    , VIZCore3DX.NET.Data.Products.AUTO
                    );
            }

            if (licenseResult != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", licenseResult.ToString()), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                VIZCore3DX.NET.Dialogs.LicenseDialog dlg = new VIZCore3DX.NET.Dialogs.LicenseDialog(vizcore2);
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    this.Close();
                    return;
                }
            }
            #endregion

            // 모델2 뷰어에서 불필요한 툴바 숨김
            vizcore2.ToolbarNote.Visible = false;
            vizcore2.ToolbarMeasure.Visible = false;
            vizcore2.ToolbarSection.Visible = false;
            vizcore2.ToolbarClash.Visible = false;
            vizcore2.ToolbarAnimation.Visible = false;

        }
        #endregion

        private void btnOpen1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore1.Model.OpenFilter;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            txtModel1.Text = dlg.FileName;

            vizcore1.Model.Open(dlg.FileName);
        }

        private void btnOpen2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore2.Model.OpenFilter;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            txtModel2.Text = dlg.FileName;

            vizcore2.Model.Open(dlg.FileName);
        }

        /// <summary>
        /// 컨트롤의 모든 노드를 NodePath를 키로 하는 딕셔너리로 구성합니다.
        /// </summary>
        /// <param name="ctrl">대상 VIZCore3DX 컨트롤</param>
        /// <param name="includeBody">Body 노드 포함 여부 (두 모델 중 하나라도 Body를 사용하면 true)</param>
        private Dictionary<string, VIZCore3DX.NET.Data.Node> BuildNodePathMap(VIZCore3DX.NET.VIZCore3DXControl ctrl, bool includeBody)
        {
            VIZCore3DX.NET.Data.Object3dFilter filter = includeBody
                ? VIZCore3DX.NET.Data.Object3dFilter.ALL_INCLUDE_BODY
                : VIZCore3DX.NET.Data.Object3dFilter.ALL;

            List<VIZCore3DX.NET.Data.Node> nodes = ctrl.Object3D.FromFilter(filter);

            Dictionary<string, VIZCore3DX.NET.Data.Node> map = new Dictionary<string, VIZCore3DX.NET.Data.Node>();
            foreach (VIZCore3DX.NET.Data.Node node in nodes)
            {
                if (string.IsNullOrEmpty(node.NodePath)) continue;
                if (map.ContainsKey(node.NodePath) == false)
                    map.Add(node.NodePath, node);
            }
            return map;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            // 두 모델 중 하나라도 Body를 포함하면 Body 노드까지 비교 대상에 포함
            bool includeBody = vizcore1.Model.EnableBody == true || vizcore2.Model.EnableBody == true;

            // 각 모델의 NodePath → Node 맵 생성
            Dictionary<string, VIZCore3DX.NET.Data.Node> map1 = BuildNodePathMap(vizcore1, includeBody);
            Dictionary<string, VIZCore3DX.NET.Data.Node> map2 = BuildNodePathMap(vizcore2, includeBody);

            List<ModelComparisonItem> result = new List<ModelComparisonItem>();

            vizcore1.ShowWaitForm();


            // 모델1 기준으로 순회하며 모델2와 비교
            foreach (KeyValuePair<string, VIZCore3DX.NET.Data.Node> item in map1)
            {
                ModelComparisonItem model = new ModelComparisonItem();

                if (map2.ContainsKey(item.Key) == true)
                {
                    // 양쪽 모두 존재하는 노드: 위치(BBox) 및 형상(MeshCount) 비교
                    model.Node1 = item.Value;
                    model.Node2 = map2[item.Key];

                    model.BBox1 = item.Value.GetBoundBox();
                    model.BBox2 = model.Node2.GetBoundBox();

                    // PART/BODY 노드만 메시 개수 비교 (형상 변경 판별)
                    if (item.Value.Kind == VIZCore3DX.NET.Data.NodeKind.PART
                        || item.Value.Kind == VIZCore3DX.NET.Data.NodeKind.BODY)
                    {
                        model.MeshCount1 = item.Value.GetMeshCount();
                        model.MeshCount2 = model.Node2.GetMeshCount();
                    }

                    model.RESULT_EXIST_A = true;
                    model.RESULT_EXIST_B = true;
                    model.RESULT_EXIST_BOTH = true;

                    // 위치 및 형상 비교 수행
                    model.Compare();
                }
                else
                {
                    // 모델1에만 존재하는 노드: 삭제된 항목
                    model.Node1 = item.Value;

                    model.BBox1 = item.Value.GetBoundBox();

                    if (item.Value.Kind == VIZCore3DX.NET.Data.NodeKind.PART
                        || item.Value.Kind == VIZCore3DX.NET.Data.NodeKind.BODY)
                    {
                        model.MeshCount1 = item.Value.GetMeshCount();
                    }

                    model.RESULT_EXIST_A = true;
                    model.RESULT_EXIST_B = false;
                    model.RESULT_EXIST_BOTH = false;
                }

                result.Add(model);
            }

            // 모델2에만 존재하는 노드: 추가된 항목
            foreach (KeyValuePair<string, VIZCore3DX.NET.Data.Node> item in map2)
            {
                if (map1.ContainsKey(item.Key) == false)
                {
                    ModelComparisonItem model = new ModelComparisonItem();

                    model.Node2 = item.Value;

                    model.BBox2 = item.Value.GetBoundBox();

                    if (item.Value.Kind == VIZCore3DX.NET.Data.NodeKind.PART
                        || item.Value.Kind == VIZCore3DX.NET.Data.NodeKind.BODY)
                    {
                        model.MeshCount2 = item.Value.GetMeshCount();
                    }

                    model.RESULT_EXIST_A = false;
                    model.RESULT_EXIST_B = true;
                    model.RESULT_EXIST_BOTH = false;

                    result.Add(model);
                }
            }

            // 비교 결과를 ListView에 표시
            lvResult.BeginUpdate();
            lvResult.Items.Clear();
            foreach (ModelComparisonItem item in result)
            {
                // 열 구성: NAME1, NAME2, 구조변경, 위치변경, 형상변경, MeshCount1, MeshCount2, BBox1, BBox2
                string[] columns = new string[]
                {
                    item.RESULT_EXIST_A == true ? item.Node1.NodeName : String.Empty,
                    item.RESULT_EXIST_B == true ? item.Node2.NodeName : String.Empty,
                    item.RESULT_EXIST_BOTH == true ? String.Empty : (item.RESULT_EXIST_A == true ? "모델 삭제" : "모델 추가"),
                    item.RESULT_EXIST_BOTH == false ? String.Empty : (item.RESULT_LOCATION == true ? String.Empty : "위치 변경"),
                    item.RESULT_EXIST_BOTH == false ? String.Empty : ((item.Node1.Kind == VIZCore3DX.NET.Data.NodeKind.PART || item.Node1.Kind == VIZCore3DX.NET.Data.NodeKind.BODY) ? (item.RESULT_SHAPE == true ? String.Empty : "형상 변경") : String.Empty),
                    item.MeshCount1.ToString(),
                    item.MeshCount2.ToString(),
                    item.BBox1 != null ? item.BBox1.ToString() : String.Empty,
                    item.BBox2 != null ? item.BBox2.ToString() : String.Empty
                };
                ListViewItem lvi = new ListViewItem(columns);
                lvi.Tag = item;

                // 변경 항목만 표시 옵션이 켜진 경우 동일한 모델은 제외
                if (ckResultViewType.Checked == true)
                {
                    if (item.IsSameModel() == false)
                        lvResult.Items.Add(lvi);
                }
                else
                {
                    lvResult.Items.Add(lvi);
                }
            }
            lvResult.EndUpdate();

            vizcore1.CloseWaitForm();

            MessageBox.Show("Completed", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ResetView()
        {
            ResetViewFunc(vizcore1);
            ResetViewFunc(vizcore2);
        }

        /// <summary>
        /// X-Ray 모드를 해제하고 기본 뷰로 초기화합니다.
        /// </summary>
        private void ResetViewFunc(VIZCore3DX.NET.VIZCore3DXControl ctrl)
        {
            ctrl.View.XRay.Enable = false;
            ctrl.View.ResetView();
        }

        /// <summary>
        /// 비교 결과 항목에 해당하는 노드를 양쪽 뷰어에서 X-Ray로 강조하고 해당 위치로 이동합니다.
        /// </summary>
        private void HighlightModel(ModelComparisonItem model)
        {
            if (vizcore1.View.XRay.Enable == false)
                vizcore1.View.XRay.Enable = true;

            if (vizcore2.View.XRay.Enable == false)
                vizcore2.View.XRay.Enable = true;

            vizcore1.View.XRay.Clear();
            vizcore2.View.XRay.Clear();

            vizcore1.View.ResetView();
            vizcore2.View.ResetView();

            if (model.RESULT_EXIST_BOTH == true)
            {
                // 양쪽 모두 존재: 두 뷰어에서 각각 해당 노드로 이동 및 강조
                vizcore1.View.FlyToObject3d(new List<VIZCore3DX.NET.Data.Node>() { model.Node1 }, 1.0f);
                vizcore2.View.FlyToObject3d(new List<VIZCore3DX.NET.Data.Node>() { model.Node2 }, 1.0f);

                vizcore1.View.XRay.Select(new List<VIZCore3DX.NET.Data.Node>() { model.Node1 }, true);
                vizcore2.View.XRay.Select(new List<VIZCore3DX.NET.Data.Node>() { model.Node2 }, true);
            }
            else if (model.RESULT_EXIST_A == true)
            {
                // 모델1에만 존재(삭제된 노드): 모델1 뷰어에서만 강조
                vizcore1.View.FlyToObject3d(new List<VIZCore3DX.NET.Data.Node>() { model.Node1 }, 1.0f);

                vizcore1.View.XRay.Select(new List<VIZCore3DX.NET.Data.Node>() { model.Node1 }, true);
            }
            else
            {
                // 모델2에만 존재(추가된 노드): 모델2 뷰어에서만 강조
                vizcore2.View.FlyToObject3d(new List<VIZCore3DX.NET.Data.Node>() { model.Node2 }, 1.0f);

                vizcore2.View.XRay.Select(new List<VIZCore3DX.NET.Data.Node>() { model.Node2 }, true);
            }
        }

        private void lvResult_DoubleClick(object sender, EventArgs e)
        {
            if (lvResult.SelectedItems.Count == 0) return;

            ListViewItem lvi = lvResult.SelectedItems[0];
            if (lvi == null)
            {
                ResetView();
                return;
            }
            if (lvi.Tag == null)
            {
                ResetView();
                return;
            }

            ModelComparisonItem model = lvi.Tag as ModelComparisonItem;
            if (model == null)
            {
                ResetView();
                return;
            }

            HighlightModel(model);
        }
    }
}
