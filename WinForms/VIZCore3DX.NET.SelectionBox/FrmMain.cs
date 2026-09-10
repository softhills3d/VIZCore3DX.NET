using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.SelectionBox
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        public FrmMain()
        {
            InitializeComponent();

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
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            vizcore3dx.SelectionBox.IsManipulatorEnabled = chkManipulator.Checked;
            vizcore3dx.SelectionBox.IsNameVisible = chkNameVisible.Checked;
            SetStatus("Selection Box 예제를 사용할 수 있습니다.");
        }

        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (!vizcore3dx.Model.OpenFileDialog()) return;
            SetStatus("모델을 열었습니다.");
        }

        private void btnCreateFromSelected_Click(object sender, EventArgs e)
        {
            if (!vizcore3dx.Model.IsOpen())
            {
                MessageBox.Show("먼저 모델을 여세요.", "Selection Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<Node> nodes = vizcore3dx.Object3D.FromFilter(Object3dFilter.SELECTED_TOP);

            if (nodes.Count == 0)
            {
                MessageBox.Show("Selection Box를 생성할 모델 객체를 선택하세요.", "Selection Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BoundBox3D boundBox = vizcore3dx.Object3D.GetBoundBox(nodes, chkVisibleOnly.Checked);
            float margin = (float)numMargin.Value;
            BoundBox3D selectionBoundBox = new BoundBox3D(boundBox.MinX - margin, boundBox.MinY - margin, boundBox.MinZ - margin, boundBox.MaxX + margin, boundBox.MaxY + margin, boundBox.MaxZ + margin);
            int id = vizcore3dx.SelectionBox.Add(selectionBoundBox, "Selected Objects");

            SetNumericRange(selectionBoundBox);
            RefreshSelectionBoxList(new List<int> { id });
            SetStatus(string.Format("선택한 Node {0}개의 BoundBox로 Selection Box를 생성했습니다. ID: {1}", nodes.Count, id));
        }

        private async void btnPickOsnap_Click(object sender, EventArgs e)
        {
            if (!vizcore3dx.Model.IsOpen())
            {
                MessageBox.Show("먼저 모델을 여세요.", "Selection Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OsnapController controller = vizcore3dx.GeometryUtility.Osnap();
            if (controller == null) return;

            controller.CommandText = "Selection Box의 중심 위치를 선택하세요.";
            controller.EdgeEndpointSnap = chkEdgeEndpointSnap.Checked;
            controller.EdgeMidpointSnap = chkEdgeMidpointSnap.Checked;
            controller.LineSnap = chkLineSnap.Checked;
            controller.CircleSnap = chkCircleSnap.Checked;
            controller.CircleCenterSnap = chkCircleCenterSnap.Checked;
            controller.CylinderSnap = chkCylinderSnap.Checked;
            controller.PlaneSnap = chkPlaneSnap.Checked;

            SetStatus("모델에서 Selection Box의 중심 위치를 선택하세요.");

            OsnapResult result = await controller.GetResultAsync();

            if (result == null)
            {
                SetStatus("Osnap 위치 선택이 취소되었습니다.");
                return;
            }

            Vector3D position = result.Position;
            float lengthX = (float)numLengthX.Value;
            float lengthY = (float)numLengthY.Value;
            float lengthZ = (float)numLengthZ.Value;
            BoundBox3D boundBox = new BoundBox3D(position.X - lengthX / 2.0f, position.Y - lengthY / 2.0f, position.Z - lengthZ / 2.0f, position.X + lengthX / 2.0f, position.Y + lengthY / 2.0f, position.Z + lengthZ / 2.0f);

            SetNumericRange(boundBox);
            SetStatus(string.Format("{0} 위치를 Selection Box 좌표에 적용했습니다. Node: {1}", result.Type, result.Node == null ? "없음" : result.Node.NodeName));
        }

        private void btnCancelOsnap_Click(object sender, EventArgs e)
        {
            vizcore3dx.GeometryUtility.CancelOsnap();
            SetStatus("진행 중인 Osnap을 취소했습니다.");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!ValidateBoxRange()) return;

            BoundBox3D boundBox = new BoundBox3D((float)numMinX.Value, (float)numMinY.Value, (float)numMinZ.Value, (float)numMaxX.Value, (float)numMaxY.Value, (float)numMaxZ.Value);
            int id = vizcore3dx.SelectionBox.Add(boundBox, "Selection Box");

            RefreshSelectionBoxList(new List<int> { id });
            SetStatus(string.Format("Selection Box를 생성했습니다. ID: {0}", id));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> ids = vizcore3dx.SelectionBox.GetSelectedItems();
            if (ids.Count == 0) return;

            vizcore3dx.SelectionBox.Delete(ids);
            RefreshSelectionBoxList(null);
            lstObjects.Items.Clear();
            SetStatus(string.Format("Selection Box {0}개를 삭제했습니다.", ids.Count));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            vizcore3dx.SelectionBox.Clear();
            RefreshSelectionBoxList(null);
            lstObjects.Items.Clear();
            SetStatus("모든 Selection Box를 삭제했습니다.");
        }

        private void btnSetSize_Click(object sender, EventArgs e)
        {
            List<int> ids = vizcore3dx.SelectionBox.GetSelectedItems();

            if (ids.Count != 1)
            {
                MessageBox.Show("위치와 크기를 변경할 Selection Box 하나를 선택하세요.", "Selection Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateBoxRange()) return;

            vizcore3dx.SelectionBox.SetSize(ids[0], (float)numMinX.Value, (float)numMinY.Value, (float)numMinZ.Value, (float)numMaxX.Value, (float)numMaxY.Value, (float)numMaxZ.Value);
            SetStatus(string.Format("Selection Box의 위치와 크기를 변경했습니다. ID: {0}", ids[0]));
        }

        private void btnSetTitle_Click(object sender, EventArgs e)
        {
            List<int> ids = vizcore3dx.SelectionBox.GetSelectedItems();

            if (ids.Count != 1)
            {
                MessageBox.Show("이름을 변경할 Selection Box 하나를 선택하세요.", "Selection Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string title = txtSelectionBoxTitle.Text.Trim();

            if (title.Length == 0)
            {
                MessageBox.Show("변경할 이름을 입력하세요.", "Selection Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            VIZCore3DX.NET.Data.SelectionBox selectionBox = vizcore3dx.SelectionBox.GetItem(ids[0]);
            if (selectionBox == null || !selectionBox.IsValid) return;

            selectionBox.Title = title;
            RefreshSelectionBoxList(ids);
            SetStatus(string.Format("Selection Box 이름을 변경했습니다. ID: {0}, 이름: {1}", selectionBox.ID, selectionBox.Title));
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            List<int> ids = vizcore3dx.SelectionBox.GetSelectedItems();

            if (ids.Count != 1 || cmbAxis.SelectedItem == null)
            {
                MessageBox.Show("분할할 Selection Box 하나와 축을 선택하세요.", "Selection Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int newId = vizcore3dx.SelectionBox.Divide(ids[0], (Axis)cmbAxis.SelectedItem);
            RefreshSelectionBoxList(new List<int> { ids[0], newId });
            SetStatus(string.Format("Selection Box를 {0}축으로 분할했습니다. 새 ID: {1}", cmbAxis.SelectedItem, newId));
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            List<int> ids = vizcore3dx.SelectionBox.GetSelectedItems();

            if (ids.Count < 2)
            {
                MessageBox.Show("병합할 Selection Box를 두 개 이상 선택하세요.", "Selection Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!vizcore3dx.SelectionBox.Merge(ids))
            {
                SetStatus("Selection Box 병합에 실패했습니다.");
                return;
            }

            RefreshSelectionBoxList(new List<int> { ids[0] });
            SetStatus(string.Format("Selection Box {0}개를 ID {1}로 병합했습니다.", ids.Count, ids[0]));
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            List<int> ids = vizcore3dx.SelectionBox.GetSelectedItems();

            if (ids.Count < 2)
            {
                MessageBox.Show("그룹화할 Selection Box를 두 개 이상 선택하세요.", "Selection Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool result = chkGroupAxis.Checked && cmbAxis.SelectedItem != null ? vizcore3dx.SelectionBox.Grouping(ids, (Axis)cmbAxis.SelectedItem) : vizcore3dx.SelectionBox.Grouping(ids);
            SetStatus(result ? string.Format("Selection Box {0}개를 그룹화했습니다.", ids.Count) : "Selection Box 그룹화에 실패했습니다.");
        }

        private void btnUngroup_Click(object sender, EventArgs e)
        {
            bool result = vizcore3dx.SelectionBox.Ungroup();
            SetStatus(result ? "Selection Box 그룹을 해제했습니다." : "Selection Box 그룹 해제에 실패했습니다.");
        }

        private void btnGetObjects_Click(object sender, EventArgs e)
        {
            List<int> ids = vizcore3dx.SelectionBox.GetSelectedItems();

            if (ids.Count == 0 || cmbSearchOption.SelectedItem == null)
            {
                MessageBox.Show("내부 Object를 조회할 Selection Box와 검색 옵션을 선택하세요.", "Selection Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Dictionary<int, Node> nodes = new Dictionary<int, Node>();

            foreach (int id in ids)
            {
                List<Node> boxNodes = vizcore3dx.SelectionBox.GetObject3DIndex(id, (BoundBoxSearchOption)cmbSearchOption.SelectedItem, chkVisibleOnly.Checked, rdoPart.Checked);
                if (boxNodes == null) continue;

                foreach (Node node in boxNodes)
                {
                    if (node != null && !nodes.ContainsKey(node.Index)) nodes.Add(node.Index, node);
                }
            }

            lstObjects.BeginUpdate();
            lstObjects.Items.Clear();
            foreach (Node node in nodes.Values) lstObjects.Items.Add(string.Format("[{0}] {1} ({2})", node.Index, node.NodeName, node.Kind));
            lstObjects.EndUpdate();

            SetStatus(string.Format("Selection Box {0}개에서 중복을 제외한 Object {1}개를 조회했습니다.", ids.Count, nodes.Count));
        }

        private void chkManipulator_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.SelectionBox.IsManipulatorEnabled = chkManipulator.Checked;
            SetStatus(chkManipulator.Checked ? "Manipulator를 활성화했습니다." : "Manipulator를 비활성화했습니다.");
        }

        private void chkNameVisible_CheckedChanged(object sender, EventArgs e)
        {
            vizcore3dx.SelectionBox.IsNameVisible = chkNameVisible.Checked;
        }

        private void lstSelectionBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            foreach (VIZCore3DX.NET.Data.SelectionBox selectionBox in lstSelectionBoxes.SelectedItems) ids.Add(selectionBox.ID);

            vizcore3dx.SelectionBox.Select(false);
            if (ids.Count > 0) vizcore3dx.SelectionBox.Select(ids, true);

            if (ids.Count == 1)
            {
                VIZCore3DX.NET.Data.SelectionBox selectionBox = (VIZCore3DX.NET.Data.SelectionBox)lstSelectionBoxes.SelectedItems[0];
                SetNumericRange(selectionBox.BoundBox);
                txtSelectionBoxTitle.Text = selectionBox.Title;
            }
            else txtSelectionBoxTitle.Clear();
        }

        private void RefreshSelectionBoxList(List<int> selectedIds)
        {
            List<int> idsToSelect = selectedIds ?? vizcore3dx.SelectionBox.GetSelectedItems();

            lstSelectionBoxes.SelectedIndexChanged -= lstSelectionBoxes_SelectedIndexChanged;
            lstSelectionBoxes.BeginUpdate();
            lstSelectionBoxes.Items.Clear();

            foreach (VIZCore3DX.NET.Data.SelectionBox selectionBox in vizcore3dx.SelectionBox.Items)
            {
                if (selectionBox != null && selectionBox.IsValid) lstSelectionBoxes.Items.Add(selectionBox);
            }

            for (int index = 0; index < lstSelectionBoxes.Items.Count; index++)
            {
                VIZCore3DX.NET.Data.SelectionBox selectionBox = (VIZCore3DX.NET.Data.SelectionBox)lstSelectionBoxes.Items[index];
                if (idsToSelect.Contains(selectionBox.ID)) lstSelectionBoxes.SetSelected(index, true);
            }

            lstSelectionBoxes.EndUpdate();
            lstSelectionBoxes.SelectedIndexChanged += lstSelectionBoxes_SelectedIndexChanged;

            if (selectedIds != null)
            {
                vizcore3dx.SelectionBox.Select(false);
                if (selectedIds.Count > 0) vizcore3dx.SelectionBox.Select(selectedIds, true);
            }
        }

        private void lstSelectionBoxes_Format(object sender, ListControlConvertEventArgs e)
        {
            VIZCore3DX.NET.Data.SelectionBox selectionBox = e.ListItem as VIZCore3DX.NET.Data.SelectionBox;
            if (selectionBox == null) return;

            e.Value = string.Format("[{0}] {1}", selectionBox.ID, selectionBox.Title);
        }

        private bool ValidateBoxRange()
        {
            bool valid = numMinX.Value < numMaxX.Value && numMinY.Value < numMaxY.Value && numMinZ.Value < numMaxZ.Value;
            if (!valid) MessageBox.Show("각 축의 Max 값은 Min 값보다 커야 합니다.", "Selection Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return valid;
        }

        private void SetNumericRange(BoundBox3D boundBox)
        {
            numMinX.Value = (decimal)boundBox.MinX;
            numMinY.Value = (decimal)boundBox.MinY;
            numMinZ.Value = (decimal)boundBox.MinZ;
            numMaxX.Value = (decimal)boundBox.MaxX;
            numMaxY.Value = (decimal)boundBox.MaxY;
            numMaxZ.Value = (decimal)boundBox.MaxZ;
        }

        private void SetStatus(string message)
        {
            lblStatus.Text = message;
        }
    }
}
