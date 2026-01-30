using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;

namespace VIZCore3DX.NET.Frame
{
    public partial class Form1 : Form
    {
        public VIZCore3DX.NET.VIZCore3DXControl vizcore3dx { get; set; }

        public Form1()
        {
            InitializeComponent();

            VIZCore3DX.NET.ModuleInitializer.Run();

            vizcore3dx = new VIZCore3DX.NET.VIZCore3DXControl();
            vizcore3dx.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(vizcore3dx);

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
            //vizcore3dx.License.LicenseServer("127.0.0.1", 8901);


            // ================================================================
            // License
            // ================================================================
            VIZCore3DX.NET.Data.LicenseResults result = vizcore3dx.License.LicenseFile("C:\\License\\VIZCore3DX.NET.lic");
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
            // Frame Event
            vizcore3dx.Frame.OnFrameCreatedEvent += Frame_OnFrameCreatedEvent;
            vizcore3dx.Frame.OnFrameImportedEvent += Frame_OnFrameImportedEvent;
            vizcore3dx.Frame.OnFrameShownEvent += Frame_OnFrameShownEvent;
            vizcore3dx.Frame.OnFrameHiddenEvent += Frame_OnFrameHiddenEvent;
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
            vizcore3dx.ToolbarMain.Visible = true;
            //vizcore3dx.ToolbarNote.Visible = false;
            //vizcore3dx.ToolbarMeasure.Visible = false;
            //vizcore3dx.ToolbarSection.Visible = false;
            //vizcore3dx.ToolbarSnapshot.Visible = false;

            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 재시작
            // ================================================================
            vizcore3dx.EndUpdate();
        }

        private void Frame_OnFrameCreatedEvent(object sender, EventManager.FrameCreatedEventArgs e)
        {
            Log($"OnFrameCreatedEvent, Frame Count: {e.Frames.Count}");

            UpdateFrameListView();
        }

        private void Frame_OnFrameImportedEvent(object sender, EventManager.FrameImportedEventArgs e)
        {
            Log($"OnFrameImportedEvent, Frame Count: {e.Frames.Count}");

            UpdateFrameListView();
        }

        private void Frame_OnFrameShownEvent(object sender, EventManager.FrameShownEventArgs e)
        {
            Log($"OnFrameShownEvent, Frame Count: {e.Frames.Count}");
        }

        private void Frame_OnFrameHiddenEvent(object sender, EventManager.FrameHiddenEventArgs e)
        {
            Log($"OnFrameHiddenEvent, Frame Count: {e.Frames.Count}");
        }

        private void btnOpenModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = vizcore3dx.Model.OpenFilter;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Model.Open(dlg.FileName);
        }

        private void btnOpenAMFrame_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Frame.OpenAMFileDialog();
        }

        private void btnOpenTribonFrame_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Frame.OpenTribonFileDialog();
        }

        private void btnCreateFrame_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.BeginUpdate();

            FrameItem frame = vizcore3dx.Frame.CreateFrame();

            frame.XMargin = 5000.0f;
            frame.YMargin = 5000.0f;
            frame.ZMargin = 5000.0f;

            // X-Axis
            {
                frame.XAxis.Label = "X";
                frame.XAxis.FrameLineLabelTextColor = Color.Red;
                frame.XAxis.FrameLineLabelType = FrameLineLabelType.Custom;
                frame.XAxis.FrameLineStrokePattern = StrokePattern.Dashed;
                frame.XAxis.FrameLineStrokeThickness = 1.0f;

                var xFrameLines = new List<FrameLine>();

                for (int i = 0; i <= 20; i++)
                    xFrameLines.Add(new FrameLine() { ID = i, Offset = i * 5000.0f, CustomLabel = string.Format(" {0} mm ", i * 5000.0f) });

                frame.XAxis.SetFrameLines(xFrameLines);
            }

            // Y-Axis
            {
                frame.YAxis.Label = "LP";
                frame.YAxis.FrameLineLabelTextColor = Color.Green;
                frame.YAxis.FrameLineLabelType = FrameLineLabelType.FrameCoordinate;
                frame.YAxis.FrameLineStrokePattern = StrokePattern.Dashed;
                frame.YAxis.FrameLineStrokeThickness = 2.0f;

                var yFrameLines = new List<FrameLine>();

                for (int i = -10; i <= 10; i++)
                    yFrameLines.Add(new FrameLine() { ID = i, Offset = i * 2000.0f });

                frame.YAxis.SetFrameLines(yFrameLines);
            }

            // Z-Axis
            {
                frame.ZAxis.Label = "Z";
                frame.ZAxis.FrameLineLabelTextColor = Color.Blue;
                frame.ZAxis.FrameLineLabelType = FrameLineLabelType.WorldCoordinate;
                frame.ZAxis.FrameLineStrokePattern = StrokePattern.Dotted;
                frame.ZAxis.FrameLineStrokeColor = Color.Orange;
                frame.ZAxis.FrameLineStrokeThickness = 3.0f;

                var zFrameLines = new List<FrameLine>();

                for (int i = 0; i <= 10; i++)
                    zFrameLines.Add(new FrameLine() { ID = i, Offset = i * 2000.0f });

                frame.ZAxis.SetFrameLines(zFrameLines);
            }

            vizcore3dx.EndUpdate();
        }

        public void Log(string message)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;
            richTextBox1.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
            richTextBox1.ScrollToCaret(); // 최신 로그로 스크롤
        }

        private void btnExportFrame_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            dlg.DefaultExt = "json";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Frame.Export(dlg.FileName);
        }

        private void btnImportFrame_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            vizcore3dx.Frame.Import(dlg.FileName);
        }

        private void btnHasFrame_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            Log($"HasFrame: {vizcore3dx.Frame.HasFrame}");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false) return;

            vizcore3dx.Frame.Clear();

            UpdateFrameListView();
            UpdateFrameLineListView();
        }

        private void UpdateFrameListView()
        {
            lvFrame.Items.Clear();

            foreach (FrameItem frame in vizcore3dx.Frame.Frames)
            {
                ListViewItem item = new ListViewItem(new string[] { frame.ID.ToString() });
                lvFrame.Items.Add(item);
            }
        }

        private void UpdateFrameLineListView()
        {
            lvFrameLine.Items.Clear();

            FrameAxisItem frameAxis = GetSelectedFrameAxis();
            if (frameAxis == null) return;

            foreach (FrameLine line in frameAxis.GetFrameLines())
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    line.ID.ToString(),
                    line.Offset.ToString("N2"),
                    line.CustomLabel
                });

                lvFrameLine.Items.Add(item);
            }
        }

        private void lvFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCount = lvFrame.SelectedItems.Count;
            int selectedIndex = (selectedCount > 0 ? lvFrame.SelectedItems[0].Index : -1);
            Log($"selected index changed : {selectedIndex}");

            UpdateFrameLineListView();
        }

        private FrameItem GetSelectedFrame()
        {
            if (lvFrame.SelectedItems.Count <= 0) return null;

            int frameID = int.Parse(lvFrame.SelectedItems[0].SubItems[0].Text);
            FrameItem frame = vizcore3dx.Frame.GetFrame(frameID);

            if (frame == null) return null;
            if (frame.IsDeleted) return null;
            if (frame.IsValid == false) return null;

            return frame;
        }

        private FrameAxisItem GetSelectedFrameAxis()
        {
            FrameItem frame = GetSelectedFrame();
            if (frame == null) return null;

            FrameAxisItem frameAxis = null;

            if (rbXAxis.Checked)
            {
                frameAxis = frame.XAxis;
            }
            else if (rbYAxis.Checked)
            {
                frameAxis = frame.YAxis;
            }
            else if (rbZAxis.Checked)
            {
                frameAxis = frame.ZAxis;
            }

            if (frameAxis == null) return null;
            if (frameAxis.IsValid == false) return null;

            return frameAxis;
        }

        private void btnToggleFrameIsVisible_Click(object sender, EventArgs e)
        {
            FrameItem frame = GetSelectedFrame();
            if (frame == null) return;

            frame.IsVisible = !frame.IsVisible;
        }

        private void btnToggleXYPlaneEnabled_Click(object sender, EventArgs e)
        {
            FrameItem frame = GetSelectedFrame();
            if (frame == null) return;

            frame.IsXYPlaneEnabled = !frame.IsXYPlaneEnabled;
        }

        private void btnToggleYZPlaneEnabled_Click(object sender, EventArgs e)
        {
            FrameItem frame = GetSelectedFrame();
            if (frame == null) return;

            frame.IsYZPlaneEnabled = !frame.IsYZPlaneEnabled;
        }

        private void btnToggleZXPlaneEnabled_Click(object sender, EventArgs e)
        {
            FrameItem frame = GetSelectedFrame();
            if (frame == null) return;

            frame.IsZXPlaneEnabled = !frame.IsZXPlaneEnabled;
        }

        private void rbXAxis_Click(object sender, EventArgs e)
        {
            UpdateFrameLineListView();
        }

        private void rbYAxis_Click(object sender, EventArgs e)
        {
            UpdateFrameLineListView();
        }

        private void rbZAxis_Click(object sender, EventArgs e)
        {
            UpdateFrameLineListView();
        }

        private void btnToggleFrameLineEnabled_Click(object sender, EventArgs e)
        {
            FrameAxisItem frameAxis = GetSelectedFrameAxis();
            if (frameAxis == null) return;

            frameAxis.IsFrameLineEnabled = !frameAxis.IsFrameLineEnabled;
        }

        private void btnClearFrameLines_Click(object sender, EventArgs e)
        {
            FrameAxisItem frameAxis = GetSelectedFrameAxis();
            if (frameAxis == null) return;

            frameAxis.ClearFrameLines();

            UpdateFrameLineListView();
        }
    }
}
