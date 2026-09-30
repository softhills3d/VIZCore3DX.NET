using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
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

            foreach (VIZCore3DX.NET.Data.ArrowDecalHeadKind headKind in Enum.GetValues(typeof(VIZCore3DX.NET.Data.ArrowDecalHeadKind)))
            {
                cmbArrowHeadKind.Items.Add(headKind);
            }
            cmbArrowHeadKind.SelectedItem = VIZCore3DX.NET.Data.ArrowDecalHeadKind.Triangle;

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
            vizcore3dx.Decal.OnDecalImported += Decal_OnDecalChanged;
            vizcore3dx.Decal.OnDecalLoaded += Decal_OnDecalChanged;

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

        private VIZCore3DX.NET.Data.ArrowDecalStyle GetArrowStyle()
        {
            VIZCore3DX.NET.Data.ArrowDecalStyle defaultStyle = vizcore3dx.Decal.DefaultArrowDecalStyle;
            VIZCore3DX.NET.Data.ArrowDecalStyle style = defaultStyle != null ? defaultStyle.Clone() : new VIZCore3DX.NET.Data.ArrowDecalStyle();

            style.HeadKind = (VIZCore3DX.NET.Data.ArrowDecalHeadKind)cmbArrowHeadKind.SelectedItem;
            style.ArrowHeadSize = (float)numArrowHeadSize.Value;
            style.LineStrokeThickness = (float)numArrowThickness.Value;
            style.LineStrokeColor = btnArrowColor.BackColor;
            style.ArrowColor = btnArrowColor.BackColor;
            style.IsDoubleHeaded = chkArrowDoubleHeaded.Checked;

            return style;
        }

        private void LoadArrowStyle(VIZCore3DX.NET.Data.DecalItem decal)
        {
            if (decal == null || vizcore3dx.Decal.IsArrowDecal(decal) == false) return;

            VIZCore3DX.NET.Data.ArrowDecalStyle style = vizcore3dx.Decal.GetArrowDecalStyle(decal);
            if (style == null) return;

            cmbArrowHeadKind.SelectedItem = style.HeadKind;
            numArrowHeadSize.Value = Math.Max(numArrowHeadSize.Minimum, Math.Min(numArrowHeadSize.Maximum, (decimal)style.ArrowHeadSize));
            numArrowThickness.Value = Math.Max(numArrowThickness.Minimum, Math.Min(numArrowThickness.Maximum, (decimal)style.LineStrokeThickness));
            btnArrowColor.BackColor = style.ArrowColor;
            chkArrowDoubleHeaded.Checked = style.IsDoubleHeaded;
        }

        private async void btnAddArrow_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.OsnapResult result = await PickSurface("화살표 Decal을 배치할 모델 표면을 선택하세요.");
            if (result == null) return;

            VIZCore3DX.NET.Data.Vector3D normal = result.Facet.Normal;
            VIZCore3DX.NET.Data.Vector3D upDirection = GetUpDirection(normal);

            vizcore3dx.Decal.AddDecalArrow(GetArrowStyle(), (float)numArrowLength.Value, result.Position, normal, upDirection);
            CheckLastOperation("화살표 Decal을 생성할 수 없습니다.");
        }

        private async void btnAddArrowTwoPoint_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.OsnapResult start = await PickSurface("화살표의 시작점을 선택하세요.");
            if (start == null) return;

            VIZCore3DX.NET.Data.OsnapResult end = await PickSurface("화살표의 끝점(촉 위치)을 선택하세요.");
            if (end == null) return;

            if (start.Position.X == end.Position.X && start.Position.Y == end.Position.Y && start.Position.Z == end.Position.Z)
            {
                MessageBox.Show("화살표의 시작점과 끝점은 같을 수 없습니다.", "Decal Annotation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            vizcore3dx.Decal.AddDecalArrow(GetArrowStyle(), start.Position, end.Position, start.Facet.Normal);
            CheckLastOperation("화살표 Decal을 생성할 수 없습니다.");
        }

        private void btnAddArrowDialog_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 먼저 열어주세요.", "Decal Annotation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            vizcore3dx.Decal.AddDecalArrowDialog();
        }

        private void btnApplyArrowStyle_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.DecalItem decal = GetSelectedArrowDecal();
            if (decal == null) return;

            if (vizcore3dx.Decal.SetArrowDecalStyle(decal, GetArrowStyle()) == false)
            {
                CheckLastOperation("화살표 스타일을 적용할 수 없습니다.");
                return;
            }

            RefreshUI();
        }

        private void btnApplyArrowLength_Click(object sender, EventArgs e)
        {
            VIZCore3DX.NET.Data.DecalItem decal = GetSelectedArrowDecal();
            if (decal == null) return;

            if (vizcore3dx.Decal.SetArrowDecalLength(decal, (float)numArrowLength.Value) == false)
            {
                CheckLastOperation("화살표 길이를 적용할 수 없습니다.");
                return;
            }

            RefreshUI();
        }

        private VIZCore3DX.NET.Data.DecalItem GetSelectedArrowDecal()
        {
            VIZCore3DX.NET.Data.DecalItem decal = GetSelectedDecal();
            if (decal == null) return null;

            if (vizcore3dx.Decal.IsArrowDecal(decal) == false)
            {
                MessageBox.Show("선택한 Decal은 화살표 Decal이 아닙니다.", "Decal Annotation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            return decal;
        }

        private void CheckLastOperation(string message)
        {
            VIZCore3DX.NET.Data.OperationStatus status = vizcore3dx.Decal.LastOperationStatus;
            if (status == null || status.IsSuccess) return;

            MessageBox.Show(string.Format("{0}\n\n사유 : {1}", message, status.Result), "Decal Annotation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnExportJson_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Decal.Decals.Count == 0)
            {
                MessageBox.Show("저장할 Decal이 없습니다.", "Decal Annotation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Decal JSON (*.json)|*.json";
                dlg.FileName = "Decal.json";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                string json = vizcore3dx.Decal.ToJson();
                if (string.IsNullOrEmpty(json))
                {
                    CheckLastOperation("Decal 목록을 JSON으로 변환할 수 없습니다.");
                    return;
                }

                File.WriteAllText(dlg.FileName, json, Encoding.UTF8);
            }
        }

        private void btnImportJson_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델을 먼저 열어주세요.", "Decal Annotation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Decal JSON (*.json)|*.json";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                if (vizcore3dx.Decal.FromJson(File.ReadAllText(dlg.FileName, Encoding.UTF8)) == false)
                {
                    CheckLastOperation("JSON에서 Decal 목록을 복원할 수 없습니다.");
                    return;
                }
            }

            selectedDecal = null;
            RefreshUI();
        }

        private void dgvDecals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            VIZCore3DX.NET.Data.DecalItem decal = dgvDecals.Rows[e.RowIndex].Tag as VIZCore3DX.NET.Data.DecalItem;
            if (decal == null || decal.IsDeleted || decal.IsValid == false) return;

            selectedDecal = decal;
            SetDecalHighlight(selectedDecal);
            LoadArrowStyle(selectedDecal);
            RefreshSelectedDecal();
        }

        // 표시 체크박스 : 행마다 개별적으로 표시 / 숨김
        private void dgvDecals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colVisible.Index) return;

            VIZCore3DX.NET.Data.DecalItem decal = dgvDecals.Rows[e.RowIndex].Tag as VIZCore3DX.NET.Data.DecalItem;
            if (decal == null || decal.IsDeleted || decal.IsValid == false) return;

            bool visible = !decal.IsVisible;
            vizcore3dx.Decal.SetVisible(new List<VIZCore3DX.NET.Data.DecalItem>() { decal }, visible);

            dgvDecals.Rows[e.RowIndex].Cells[colVisible.Index].Value = decal.IsVisible;
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

        private string GetDecalTypeText(VIZCore3DX.NET.Data.DecalItem decal)
        {
            return vizcore3dx.Decal.IsArrowDecal(decal) ? "Arrow" : decal.Type.ToString();
        }

        private string GetDecalContent(VIZCore3DX.NET.Data.DecalItem decal)
        {
            if (vizcore3dx.Decal.IsArrowDecal(decal))
            {
                VIZCore3DX.NET.Data.ArrowDecalStyle style = vizcore3dx.Decal.GetArrowDecalStyle(decal);
                if (style == null) return "(Arrow)";
                return string.Format("({0}{1})", style.HeadKind, style.IsDoubleHeaded ? ", 양쪽 촉" : "");
            }

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

                int rowIndex = dgvDecals.Rows.Add(dgvDecals.Rows.Count + 1, GetDecalTypeText(decal), GetDecalContent(decal), decal.IsVisible, string.Format("{0:0.##}°", GetRotationAngle(decal)));

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
            btnDeleteSelected.Enabled = hasDecal;

            bool isArrowDecal = hasDecal && vizcore3dx.Decal.IsArrowDecal(selectedDecal);
            btnApplyArrowStyle.Enabled = isArrowDecal;
            btnApplyArrowLength.Enabled = isArrowDecal;

            if (hasDecal == false)
            {
                lblSelectedInfo.Text = "선택된 Decal : 없음";
                lblSelectedPosition.Text = "Position : -";
                lblSelectedRotation.Text = "Rotation : -";
                chkSelectable.Checked = false;
                chkMovable.Checked = false;
                return;
            }

            lblSelectedInfo.Text = string.Format("선택된 Decal : {0} / {1}", GetDecalTypeText(selectedDecal), GetDecalContent(selectedDecal));
            lblSelectedPosition.Text = string.Format("Position : X {0:0.##}, Y {1:0.##}, Z {2:0.##}", selectedDecal.Position.X, selectedDecal.Position.Y, selectedDecal.Position.Z);
            lblSelectedRotation.Text = string.Format("Rotation : {0:0.##}° / Step : {1:0.##}°", GetRotationAngle(selectedDecal), vizcore3dx.Decal.RotationAngleStep);
            chkSelectable.Checked = selectedDecal.IsSelectable;
            chkMovable.Checked = selectedDecal.IsMovable;
        }

        private void Decal_OnDecalCreatedOrSelected(object sender, VIZCore3DX.NET.Event.EventManager.DecalEventArgs e)
        {
            if (e.Decals != null && e.Decals.Count > 0)
            {
                selectedDecal = e.Decals[e.Decals.Count - 1];
                LoadArrowStyle(selectedDecal);
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