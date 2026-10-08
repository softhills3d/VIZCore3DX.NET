using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.Osnap
{
    public partial class FrmMain : Form
    {
        // VIZCore3DX.NET 선언
        private VIZCore3DXControl vizcore3dx;

        public FrmMain()
        {
            InitializeComponent();

            // Initialize VIZCore3DX.NET
            VIZCore3DX.NET.ModuleInitializer.Run();

            // Construction
            vizcore3dx = new VIZCore3DXControl();
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

        private async void btnShowOsnap_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            OsnapController osnap = vizcore3dx.GeometryUtility.Osnap();
            if (osnap == null) return;

            // 스냅 옵션 설정
            osnap.PlaneSnap = ckSurface.Checked;
            osnap.EdgeEndpointSnap = ckVertex.Checked;
            osnap.EdgeMidpointSnap = ckVertex.Checked;
            osnap.LineSnap = ckLine.Checked;
            osnap.CircleSnap = ckCircle.Checked;
            osnap.CircleCenterSnap = ckCircle.Checked;
            osnap.CylinderSnap = ckCircle.Checked;
            osnap.CommandText = "측정할 요소를 선택하세요.";

            vizcore3dx.Focus();

            // 사용자가 화면에서 선택할 때까지 대기 (대기 중 중복 실행 방지)
            OsnapResult result;
            btnShowOsnap.Enabled = false;
            try
            {
                result = await osnap.GetResultAsync();
            }
            finally
            {
                btnShowOsnap.Enabled = true;
            }
            if (result == null || result.Position == null) return;

            Vector3D point = result.Position;
            Vector3D start = null;
            Vector3D end = null;
            Vector3D center = null;
            Vector3D normal = null;

            // 선택한 형상 정보 조회
            switch (result.Type)
            {
                case GeometryType.Line:
                    if (result.Line == null) break;

                    start = result.Line.Start3D.ToVector3D();
                    end = result.Line.End3D.ToVector3D();
                    center = result.Line.Center;
                    break;

                case GeometryType.Facet:
                    if (result.Facet == null) break;

                    start = point;
                    end = point;
                    center = point;
                    normal = result.Facet.Normal;
                    break;

                case GeometryType.Circle:
                    if (result.Circle == null) break;

                    center = result.Circle.Center.ToVector3D();
                    start = center;
                    end = center;
                    normal = result.Circle.Normal;
                    break;

                case GeometryType.Point:
                    if (result.Point == null) break;

                    center = new Vector3D(result.Point);
                    start = center;
                    end = center;
                    break;
            }

            // 선택 결과를 목록에 표시
            lvOsnap.BeginUpdate();
            lvOsnap.Items.Add(new ListViewItem(new string[]
            {
                result.Type.ToString(),
                point?.ToString() ?? string.Empty,
                start?.ToString() ?? string.Empty,
                end?.ToString() ?? string.Empty,
                center?.ToString() ?? string.Empty,
                normal?.ToString() ?? string.Empty
            }));
            lvOsnap.EndUpdate();

            if (ckAddNote.Checked == false) return;

            // 선택 위치에 노트 생성
            Vertex3D surfacePt = point.ToVertex3D();
            Vertex3D notePt = surfacePt + 100.0f;

            vizcore3dx.Note.AddNoteSurface(point.ToString(), notePt, surfacePt, false);
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