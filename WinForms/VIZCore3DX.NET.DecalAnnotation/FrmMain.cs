using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIZCore3DX.NET.DecalAnnotation
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET Control
        private VIZCore3DX.NET.VIZCore3DXControl vizcore3dx;

        private VIZCore3DX.NET.Data.DecalItem selectedDecal;
        private readonly List<Image> loadedImages = new List<Image>();

        public FrmMain()
        {
            InitializeComponent();

            cmbArrowSizeType.SelectedIndex = 0;

            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

            vizcore3dx.OnInitializedVIZCore3DX += VIZCore3DX_OnInitializedVIZCore3DX;
        }

        private void VIZCore3DX_OnInitializedVIZCore3DX(object sender, EventArgs e)
        {
            // 라이선스 파일을 통한 인증
            // VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\Temp\\VIZCore3DX.NET.lic");

            // 라이선스 서버를 통한 인증
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseServer("127.0.0.1", 8901);

            if (result != VIZCore3DX.NET.Data.LicenseResults.SUCCESS)
            {
                MessageBox.Show(string.Format("LICENSE CODE : {0}", result), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeVIZCore3DX();
        }

        private void InitializeVIZCore3DX()
        {
            vizcore3dx.Decal.RotationAngleStep = (float)numRotationStep.Value;

            vizcore3dx.Decal.OnDecalCreated += Decal_OnDecalCreatedOrSelected;
            vizcore3dx.Decal.OnDecalDeleted += Decal_OnDecalDeleted;
            vizcore3dx.Decal.OnDecalSelected += Decal_OnDecalCreatedOrSelected;
            vizcore3dx.Decal.OnDecalDeselected += Decal_OnDecalDeselected;
            vizcore3dx.Decal.OnDecalShown += Decal_OnDecalChanged;
            vizcore3dx.Decal.OnDecalHidden += Decal_OnDecalChanged;
            vizcore3dx.Decal.OnDecalMoved += Decal_OnDecalChanged;
            vizcore3dx.Decal.OnDecalRotated += Decal_OnDecalChanged;
            vizcore3dx.Decal.OnDecalTextChanged += Decal_OnDecalChanged;
            vizcore3dx.Decal.OnDecalImageChanged += Decal_OnDecalChanged;

            vizcore3dx.Decal.SetHighlightable(true);

            RefreshUI();
        }

        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.OpenFileDialog() == false) return;

            selectedDecal = null;
            RefreshUI();
            vizcore3dx.View.FitToView();
        }

        private void btnFitToView_Click(object sender, EventArgs e)
        {
            vizcore3dx.View.FitToView();
        }

        private async Task<VIZCore3DX.NET.Data.OsnapResult> PickSurface(string commandText)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 먼저 열어주세요.", "Decal Annotation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            VIZCore3DX.NET.Data.OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();
            if (osnap == null) return null;

            osnap.CommandText = commandText;
            osnap.PlaneSnap = true;
            osnap.LineSnap = false;
            osnap.EdgeEndpointSnap = false;
            osnap.EdgeMidpointSnap = false;
            osnap.CircleSnap = false;
            osnap.CircleCenterSnap = false;
            osnap.CylinderSnap = false;

            VIZCore3DX.NET.Data.OsnapResult result = await osnap.GetResultAsync();
            if (result == null) return null;

            if (result.Facet == null)
            {
                MessageBox.Show("모델의 평면을 선택해주세요.", "Decal Annotation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            return result;
        }

        private VIZCore3DX.NET.Data.Vector3D GetUpDirection(VIZCore3DX.NET.Data.Vector3D normal)
        {
            VIZCore3DX.NET.Data.Vector3D normalized = normal.GetNormalized();
            VIZCore3DX.NET.Data.Vector3D reference = Math.Abs(normalized.Z) < 0.9f ? new VIZCore3DX.NET.Data.Vector3D(0.0f, 0.0f, 1.0f) : new VIZCore3DX.NET.Data.Vector3D(0.0f, 1.0f, 0.0f);
            VIZCore3DX.NET.Data.Vector3D right = reference.Cross(normalized).GetNormalized();
            return normalized.Cross(right).GetNormalized();
        }

        private float GetRotationAngle(VIZCore3DX.NET.Data.DecalItem decal)
        {
            if (decal == null) return 0.0f;

            VIZCore3DX.NET.Data.Vector3D normal = decal.Normal.GetNormalized();
            VIZCore3DX.NET.Data.Vector3D baseUpDirection = GetUpDirection(normal);
            VIZCore3DX.NET.Data.Vector3D currentUpDirection = decal.UpDirection.GetNormalized();

            float cos = baseUpDirection.Dot(currentUpDirection);
            cos = Math.Max(-1.0f, Math.Min(1.0f, cos));

            VIZCore3DX.NET.Data.Vector3D cross = baseUpDirection.Cross(currentUpDirection);
            float sin = normal.Dot(cross);

            double angle = Math.Atan2(sin, cos) * 180.0 / Math.PI;
            if (angle < 0.0) angle += 360.0;
            if (Math.Abs(angle - 360.0) < 0.001) angle = 0.0;

            return (float)angle;
        }

        private async void btnCreateText_Click(object sender, EventArgs e)
        {
            string text = txtDecalText.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Text Decal에 표시할 문자열을 입력해주세요.", "Decal Annotation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            VIZCore3DX.NET.Data.OsnapResult result = await PickSurface("Text Decal을 배치할 모델 표면을 선택하세요.");
            if (result == null) return;

            VIZCore3DX.NET.Data.Vector3D normal = result.Facet.Normal;
            VIZCore3DX.NET.Data.Vector3D upDirection = GetUpDirection(normal);

            vizcore3dx.Decal.AddDecalText(text, btnTextColor.BackColor, result.Position, normal, upDirection, (float)numTextHeight.Value, (float)numTextWidth.Value);
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            SelectColor(btnTextColor);
        }

        private void btnArrowColor_Click(object sender, EventArgs e)
        {
            SelectColor(btnArrowColor);
        }

        private void SelectColor(Button button)
        {
            colorDialog1.Color = button.BackColor;
            if (colorDialog1.ShowDialog() != DialogResult.OK) return;
            button.BackColor = colorDialog1.Color;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            if (openFileDialogImage.ShowDialog() != DialogResult.OK) return;
            txtImageFile.Text = openFileDialogImage.FileName;
        }

        private async void btnCreateImage_Click(object sender, EventArgs e)
        {
            string imageFilePath = txtImageFile.Text.Trim();

            if (string.IsNullOrEmpty(imageFilePath))
            {
                MessageBox.Show("Image Decal에 사용할 이미지 파일을 선택해주세요.", "Decal Annotation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            VIZCore3DX.NET.Data.OsnapResult result = await PickSurface("Image Decal을 배치할 모델 표면을 선택하세요.");
            if (result == null) return;

            Image image = null;

            try
            {
                image = new Bitmap(imageFilePath);

                VIZCore3DX.NET.Data.Vector3D normal = result.Facet.Normal;
                VIZCore3DX.NET.Data.Vector3D upDirection = GetUpDirection(normal);

                vizcore3dx.Decal.AddDecalImage(image, result.Position, normal, upDirection, (float)numImageHeight.Value, (float)numImageWidth.Value, (float)numImageAlpha.Value);

                loadedImages.Add(image);
                image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Decal Annotation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (image != null) image.Dispose();
            }
        }

        private async void btnRelocate_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.DecalItem decal = GetSelectedDecal();
            if (decal == null) return;

            VIZCore3DX.NET.Data.OsnapResult result = await PickSurface("Decal을 이동할 모델 표면을 선택하세요.");
            if (result == null) return;

            VIZCore3DX.NET.Data.Vector3D normal = result.Facet.Normal;
            VIZCore3DX.NET.Data.Vector3D upDirection = GetUpDirection(normal);

            vizcore3dx.Decal.ReLocate(decal, result.Position, normal, upDirection);
        }

        private void btnShowSelected_Click(object sender, EventArgs e)
        {
            SetSelectedVisible(true);
        }

        private void btnHideSelected_Click(object sender, EventArgs e)
        {
            SetSelectedVisible(false);
        }

        private void SetSelectedVisible(bool visible)
        {
            VIZCore3DX.NET.Data.DecalItem decal = GetSelectedDecal();
            if (decal == null) return;

            vizcore3dx.Decal.SetVisible(new List<VIZCore3DX.NET.Data.DecalItem>() { decal }, visible);
        }

        private void numRotationStep_ValueChanged(object sender, EventArgs e)
        {
            if (vizcore3dx == null) return;

            vizcore3dx.Decal.RotationAngleStep = (float)numRotationStep.Value;
            RefreshSelectedDecal();
        }

        private void btnRotateClockwise_Click(object sender, EventArgs e)
        {
            RotateSelectedDecal(-vizcore3dx.Decal.RotationAngleStep);
        }

        private void btnRotateCounterClockwise_Click(object sender, EventArgs e)
        {
            RotateSelectedDecal(vizcore3dx.Decal.RotationAngleStep);
        }

        private void RotateSelectedDecal(float angle)
        {
            VIZCore3DX.NET.Data.DecalItem decal = GetSelectedDecal();
            if (decal == null) return;

            VIZCore3DX.NET.Data.Vector3D normal = decal.Normal.GetNormalized();
            VIZCore3DX.NET.Data.Vector3D upDirection = decal.UpDirection.GetNormalized();
            VIZCore3DX.NET.Data.Vector3D rotatedUpDirection = RotateVectorAroundAxis(upDirection, normal, angle);

            vizcore3dx.Decal.ReLocate(decal, decal.Position, normal, rotatedUpDirection);
        }

        private VIZCore3DX.NET.Data.Vector3D RotateVectorAroundAxis(VIZCore3DX.NET.Data.Vector3D vector, VIZCore3DX.NET.Data.Vector3D axis, float angle)
        {
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            double dot = vector.Dot(axis);

            VIZCore3DX.NET.Data.Vector3D cross = axis.Cross(vector);

            float x = (float)(vector.X * cos + cross.X * sin + axis.X * dot * (1.0 - cos));
            float y = (float)(vector.Y * cos + cross.Y * sin + axis.Y * dot * (1.0 - cos));
            float z = (float)(vector.Z * cos + cross.Z * sin + axis.Z * dot * (1.0 - cos));

            return new VIZCore3DX.NET.Data.Vector3D(x, y, z).GetNormalized();
        }

        private void chkSelectable_CheckedChanged(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.DecalItem decal = GetSelectedDecal(false);
            if (decal == null) return;

            decal.IsSelectable = chkSelectable.Checked;
        }

        private void chkMovable_CheckedChanged(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.DecalItem decal = GetSelectedDecal(false);
            if (decal == null) return;

            decal.IsMovable = chkMovable.Checked;
        }

        private void cmbArrowSizeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArrowSizeType.SelectedIndex == 0)
            {
                numArrowSize.DecimalPlaces = 2;
                numArrowSize.Minimum = 0.01M;
                numArrowSize.Maximum = 0.50M;
                numArrowSize.Increment = 0.05M;

                if (numArrowSize.Value > 0.50M) numArrowSize.Value = 0.15M;
            }
            else
            {
                numArrowSize.DecimalPlaces = 1;
                numArrowSize.Minimum = 0.1M;
                numArrowSize.Maximum = 1000000.0M;
                numArrowSize.Increment = 10.0M;

                if (numArrowSize.Value <= 0.50M) numArrowSize.Value = 100.0M;
            }
        }

        private void btnAddArrow_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.DecalItem decal = GetSelectedDecal();
            if (decal == null) return;

            VIZCore3DX.NET.Data.DecalArrowHeadSizeType arrowHeadSizeType = cmbArrowSizeType.SelectedIndex == 0 ? VIZCore3DX.NET.Data.DecalArrowHeadSizeType.Ratio : VIZCore3DX.NET.Data.DecalArrowHeadSizeType.Fixed;

            if (vizcore3dx.Decal.AddArrow(decal, btnArrowColor.BackColor, (float)numArrowSize.Value, arrowHeadSizeType) == false)
            {
                MessageBox.Show("화살표를 생성할 수 없습니다. 이미 연결되어 있거나 현재 실행할 수 없는 상태입니다.", "Decal Annotation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSetArrow_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.DecalItem decal = GetSelectedDecal();
            if (decal == null) return;

            if (vizcore3dx.Decal.SetArrow(decal) == false)
            {
                MessageBox.Show("화살표를 다시 설정할 수 없습니다. 연결된 화살표가 없거나 현재 실행할 수 없는 상태입니다.", "Decal Annotation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteArrow_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.DecalItem decal = GetSelectedDecal();
            if (decal == null) return;

            if (vizcore3dx.Decal.DeleteArrow(decal) == false)
            {
                MessageBox.Show("선택한 Decal에 연결된 화살표가 없습니다.", "Decal Annotation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RefreshUI();
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.DecalItem decal = GetSelectedDecal();
            if (decal == null) return;

            decal.IsHighlighted = false;
            vizcore3dx.Decal.Delete(new List<VIZCore3DX.NET.Data.DecalItem>() { decal });
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            SetAllVisible(true);
        }

        private void btnHideAll_Click(object sender, EventArgs e)
        {
            SetAllVisible(false);
        }

        private void SetAllVisible(bool visible)
        {
            if (vizcore3dx.Decal.Decals.Count == 0) return;

            vizcore3dx.Decal.SetVisible(vizcore3dx.Decal.Decals, visible);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Decal.Decals.Count == 0) return;

            vizcore3dx.Decal.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void dgvDecals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            VIZCore3DX.NET.Data.DecalItem decal = dgvDecals.Rows[e.RowIndex].Tag as VIZCore3DX.NET.Data.DecalItem;
            if (decal == null || decal.IsDeleted || decal.IsValid == false) return;

            selectedDecal = decal;
            SetDecalHighlight(selectedDecal);
            RefreshSelectedDecal();
        }

        private void SetDecalHighlight(VIZCore3DX.NET.Data.DecalItem target)
        {
            if (vizcore3dx == null) return;

            List<VIZCore3DX.NET.Data.DecalItem> decals = vizcore3dx.Decal.Decals;

            for (int i = 0; i < decals.Count; i++)
            {
                VIZCore3DX.NET.Data.DecalItem decal = decals[i];

                if (decal == null || decal.IsDeleted || decal.IsValid == false) continue;

                decal.IsHighlighted = ReferenceEquals(decal, target);
            }
        }

        private VIZCore3DX.NET.Data.DecalItem GetSelectedDecal(bool showMessage = true)
        {
            if (selectedDecal != null && selectedDecal.IsDeleted == false && selectedDecal.IsValid) return selectedDecal;

            if (showMessage)
            {
                MessageBox.Show("View 또는 Decal 목록에서 관리할 Decal을 선택해주세요.", "Decal Annotation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return null;
        }

        private string GetDecalContent(VIZCore3DX.NET.Data.DecalItem decal)
        {
            if (decal.Type == VIZCore3DX.NET.Data.DecalType.Text) return string.IsNullOrEmpty(decal.DecalText) ? "(빈 문자열)" : decal.DecalText;
            return "(Image)";
        }

        private void RefreshUI()
        {
            RefreshDecalList();
            RefreshSelectedDecal();
        }

        private void RefreshDecalList()
        {
            if (vizcore3dx == null) return;

            dgvDecals.Rows.Clear();

            List<VIZCore3DX.NET.Data.DecalItem> decals = vizcore3dx.Decal.Decals;
            int selectedRowIndex = -1;

            for (int i = 0; i < decals.Count; i++)
            {
                VIZCore3DX.NET.Data.DecalItem decal = decals[i];

                if (decal == null || decal.IsDeleted) continue;

                int rowIndex = dgvDecals.Rows.Add(dgvDecals.Rows.Count + 1, decal.Type.ToString(), GetDecalContent(decal), decal.IsVisible ? "표시" : "숨김", vizcore3dx.Decal.HasArrow(decal) ? "있음" : "없음", string.Format("{0:0.##}°", GetRotationAngle(decal)));

                DataGridViewRow row = dgvDecals.Rows[rowIndex];
                row.Tag = decal;

                if (ReferenceEquals(decal, selectedDecal))
                {
                    selectedRowIndex = rowIndex;
                }
            }

            dgvDecals.ClearSelection();

            if (selectedRowIndex >= 0 && selectedRowIndex < dgvDecals.Rows.Count)
            {
                dgvDecals.Rows[selectedRowIndex].Selected = true;

                if (dgvDecals.Rows[selectedRowIndex].Cells.Count > 0)
                {
                    dgvDecals.CurrentCell = dgvDecals.Rows[selectedRowIndex].Cells[0];
                }

                if (dgvDecals.Rows[selectedRowIndex].Displayed == false)
                {
                    dgvDecals.FirstDisplayedScrollingRowIndex = selectedRowIndex;
                }
            }
            else
            {
                dgvDecals.CurrentCell = null;
            }

            lblDecalCount.Text = string.Format("Decal : {0}", dgvDecals.Rows.Count);
        }

        private void RefreshSelectedDecal()
        {
            bool hasDecal = selectedDecal != null && selectedDecal.IsDeleted == false && selectedDecal.IsValid;

            btnRelocate.Enabled = hasDecal;
            btnShowSelected.Enabled = hasDecal;
            btnHideSelected.Enabled = hasDecal;
            btnRotateClockwise.Enabled = hasDecal;
            btnRotateCounterClockwise.Enabled = hasDecal;
            chkSelectable.Enabled = hasDecal;
            chkMovable.Enabled = hasDecal;
            groupArrow.Enabled = hasDecal;
            btnDeleteSelected.Enabled = hasDecal;

            if (hasDecal == false)
            {
                lblSelectedInfo.Text = "선택된 Decal : 없음";
                lblSelectedPosition.Text = "Position : -";
                lblSelectedRotation.Text = "Rotation : -";
                chkSelectable.Checked = false;
                chkMovable.Checked = false;
                return;
            }

            lblSelectedInfo.Text = string.Format("선택된 Decal : {0} / {1}", selectedDecal.Type, GetDecalContent(selectedDecal));
            lblSelectedPosition.Text = string.Format("Position : X {0:0.##}, Y {1:0.##}, Z {2:0.##}", selectedDecal.Position.X, selectedDecal.Position.Y, selectedDecal.Position.Z);
            lblSelectedRotation.Text = string.Format("Rotation : {0:0.##}° / Step : {1:0.##}° / Arrow : {2}", GetRotationAngle(selectedDecal), vizcore3dx.Decal.RotationAngleStep, vizcore3dx.Decal.HasArrow(selectedDecal) ? "있음" : "없음");
            chkSelectable.Checked = selectedDecal.IsSelectable;
            chkMovable.Checked = selectedDecal.IsMovable;
        }

        private void Decal_OnDecalCreatedOrSelected(object sender, VIZCore3DX.NET.Event.EventManager.DecalEventArgs e)
        {
            if (e.Decals != null && e.Decals.Count > 0)
            {
                selectedDecal = e.Decals[e.Decals.Count - 1];
            }

            RefreshUI();
        }

        private void Decal_OnDecalDeleted(object sender, VIZCore3DX.NET.Event.EventManager.DecalEventArgs e)
        {
            if (selectedDecal != null && selectedDecal.IsDeleted)
            {
                selectedDecal = null;
            }

            RefreshUI();
        }

        private void Decal_OnDecalDeselected(object sender, VIZCore3DX.NET.Event.EventManager.DecalEventArgs e)
        {
            selectedDecal = null;

            SetDecalHighlight(null);
            RefreshUI();
        }

        private void Decal_OnDecalChanged(object sender, VIZCore3DX.NET.Event.EventManager.DecalEventArgs e)
        {
            RefreshUI();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            for (int i = 0; i < loadedImages.Count; i++)
            {
                loadedImages[i].Dispose();
            }

            loadedImages.Clear();

            base.OnFormClosed(e);
        }
    }
}