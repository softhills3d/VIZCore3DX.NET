using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.FramePrefix
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

            // license 인증
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
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }

        private void buttonModelOpen_Click(object sender, EventArgs e)
        {
            string fileName = "VIZZARD_SHIP.vizx";
            string rootPath = vizcore3dx.GetEntryAssemblyPath();

            string path = System.IO.Path.GetFullPath(
                System.IO.Path.Combine(rootPath, @"..\..\..\..\bin\Debug", fileName)
            );

            if (System.IO.File.Exists(path) == true)
            {
                bool result = vizcore3dx.Model.Open(path);

                if (result == false)
                {
                    MessageBox.Show("모델 파일을 열 수 없습니다.");
                    return;
                }

                return;
            }

            vizcore3dx.Model.OpenFileDialog();
        }

        private void buttonFrameOpen_Click(object sender, EventArgs e)
        {
            string fileName = "VIZZARD_SHIP.dmp";
            string rootPath = vizcore3dx.GetEntryAssemblyPath();

            // 현재 실행 위치 기준으로 루트 bin\Debug의 Frame 파일 경로 생성
            string path = System.IO.Path.GetFullPath(
                System.IO.Path.Combine(rootPath, @"..\..\..\..\bin\Debug", fileName)
            );

            bool result;

            if (System.IO.File.Exists(path) == true)
            {
                // DMP 파일이지만 예제/파일 형식에 따라 AM 또는 Tribon 방식으로 열릴 수 있으므로 순차 시도
                result = vizcore3dx.Frame.OpenAM(path);

                if (result == false)
                    result = vizcore3dx.Frame.OpenTribon(path);
            }
            else
            {
                // 자동 경로에 파일이 없으면 사용자가 직접 선택 (취소 시 종료, 선택한 파일로 AM → Tribon 순차 시도)
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = vizcore3dx.Frame.Filter;
                if (dlg.ShowDialog() != DialogResult.OK) return;

                result = vizcore3dx.Frame.OpenAM(dlg.FileName);

                if (result == false)
                    result = vizcore3dx.Frame.OpenTribon(dlg.FileName);
            }

            if (result == false)
            {
                MessageBox.Show("Frame 파일을 열 수 없습니다.");
                return;
            }

            vizcore3dx.Frame.Visible = true;
            vizcore3dx.Frame.ReDraw();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Frame.HasFrame == false)
            {
                MessageBox.Show("Frame을 먼저 로드해 주세요.");
                return;
            }

            if (checkBoxX.Checked == false &&
                checkBoxY.Checked == false &&
                checkBoxZ.Checked == false)
            {
                MessageBox.Show("반영할 축을 선택해주세요.");
                return;
            }

            string prefix = string.Empty;

            if (checkBoxSetPrefix.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(textBoxPrefix.Text) == true)
                {
                    MessageBox.Show("Prefix를 입력해주세요.");
                    return;
                }

                prefix = textBoxPrefix.Text;
            }

            bool useID = radioButtonID.Checked;

            vizcore3dx.BeginUpdate();

            if (checkBoxX.Checked == true)
                SetFrameTypePrefix(Axis.X, useID, prefix);

            if (checkBoxY.Checked == true)
                SetFrameTypePrefix(Axis.Y, useID, prefix);

            if (checkBoxZ.Checked == true)
                SetFrameTypePrefix(Axis.Z, useID, prefix);

            vizcore3dx.EndUpdate();

            vizcore3dx.Frame.ReDraw();
        }

        private void SetFrameTypePrefix(Axis axis, bool useID, string prefix)
        {
            foreach (FrameItem frame in vizcore3dx.Frame.Frames)
            {
                if (frame == null || frame.IsValid == false) continue;

                FrameAxisItem axisItem = GetFrameAxisItem(frame, axis);
                if (axisItem == null || axisItem.IsValid == false) continue;

                List<FrameLine> lines = axisItem.GetFrameLines();
                if (lines == null || lines.Count == 0) continue;

                foreach (FrameLine line in lines)
                {
                    string text;

                    if (useID == true)
                    {
                        // ID 표시
                        text = line.ID.ToString();
                    }
                    else
                    {
                        // Position 표시: 월드 좌표 Offset을 프레임 좌표 문자열로 변환
                        text = axisItem.ToFrameCoordinate(line.Offset);
                    }

                    line.CustomLabel = prefix + text;
                }

                axisItem.SetFrameLines(lines);
                axisItem.FrameLineLabelType = FrameLineLabelType.Custom;
            }
        }

        private FrameAxisItem GetFrameAxisItem(FrameItem frame, Axis axis)
        {
            if (axis == Axis.X) return frame.XAxis;
            if (axis == Axis.Y) return frame.YAxis;
            if (axis == Axis.Z) return frame.ZAxis;

            return null;
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