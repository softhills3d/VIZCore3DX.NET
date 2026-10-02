using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace VIZCore3DX.NET.DemoLauncher
{
    public partial class FrmMain : Form
    {
        private const string Prefix = "VIZCore3DX.NET.";
        private const string SelfName = "VIZCore3DX.NET.DemoLauncher";
        private const string UnlistedCategory = "기타";
        private const int ThumbW = 64, ThumbH = 40, GridW = 192, GridH = 120;

        [DllImport("user32.dll")] private static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);
        [DllImport("user32.dll")] private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")] private static extern bool ShowWindow(IntPtr hWnd, int cmd);
        [DllImport("user32.dll")] private static extern bool IsIconic(IntPtr hWnd);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT { public int Left, Top, Right, Bottom; }

        private class Sample
        {
            public string Name;
            public string Category;
            public string Desc;
            public string Version;
            public string ExePath;
        }

        private readonly List<Sample> samples = new List<Sample>();
        private string rootDir;
        private Image previewImage;

        private readonly System.Windows.Forms.Timer tmrAlive = new System.Windows.Forms.Timer { Interval = 1000 };
        private readonly System.Windows.Forms.Timer tmrRefresh = new System.Windows.Forms.Timer { Interval = 1000 };
        private readonly List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();
        private readonly Dictionary<string, Bitmap> nodeThumbs = new Dictionary<string, Bitmap>();
        private readonly Bitmap noThumb = MakeNoImageThumb(ThumbW, ThumbH);
        private readonly ImageList gridImages = new ImageList { ImageSize = new Size(GridW, GridH), ColorDepth = ColorDepth.Depth32Bit };
        private readonly Dictionary<string, KeyValuePair<DateTime, Bitmap>> thumbCache = new Dictionary<string, KeyValuePair<DateTime, Bitmap>>();

        public FrmMain()
        {
            InitializeComponent();
            // 예제 노드에만 썸네일을 직접 그림 (카테고리는 이미지 없음)
            tvList.ShowLines = true;
            tvList.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            tvList.DrawNode += tvList_DrawNode;
            tvList.MouseDown += tvList_MouseDown;
            tvList.MouseDoubleClick += tvList_MouseDoubleClick;
            lvGrid.LargeImageList = gridImages;
            tvList.ItemHeight = ThumbH + 4;
            rootDir = FindRoot();
            LoadSamples();
            BuildTree();
            StartWatching();
        }

        // 폴더/솔루션/README/exe 변경을 감시해서 목록을 자동 갱신
        private void StartWatching()
        {
            tmrRefresh.Tick += (s, e) => { tmrRefresh.Stop(); RefreshList(); };
            tmrAlive.Tick += (s, e) => UpdateExitButton();
            tmrAlive.Start();
            Watch(AppDomain.CurrentDomain.BaseDirectory, false);
            if (rootDir == null) return;
            Watch(rootDir, false);
            Watch(Path.Combine(rootDir, "WinForms"), true);
            if (Directory.Exists(ImagesDir)) Watch(ImagesDir, false);
        }

        private void Watch(string dir, bool subdirs)
        {
            try
            {
                var w = new FileSystemWatcher(dir) { IncludeSubdirectories = subdirs, EnableRaisingEvents = true };
                FileSystemEventHandler h = (s, e) => OnFsChanged(e.FullPath);
                w.Created += h; w.Deleted += h; w.Changed += h;
                w.Renamed += (s, e) => OnFsChanged(e.FullPath);
                watchers.Add(w);
            }
            catch { }
        }

        private void OnFsChanged(string path)
        {
            string ext = Path.GetExtension(path).ToLowerInvariant();
            if (ext != "" && ext != ".exe" && ext != ".csproj" && ext != ".sln" && ext != ".md" && ext != ".png") return;
            if (ext == ".md" && !string.Equals(Path.GetFileName(path), "README.md", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(Path.GetFileName(path), "ReadMe.md", StringComparison.OrdinalIgnoreCase)) return;
            if (!IsHandleCreated || IsDisposed) return;
            BeginInvoke((Action)(() => { tmrRefresh.Stop(); tmrRefresh.Start(); }));   // 연속 변경은 1초 뒤 한 번만 갱신
        }

        private void RefreshList()
        {
            Sample sel = tvList.SelectedNode == null ? null : tvList.SelectedNode.Tag as Sample;
            string selCat = tvList.SelectedNode != null && sel == null ? tvList.SelectedNode.Text : null;
            try
            {
                samples.Clear();
                LoadSamples();
            }
            catch { return; }
            BuildTree(sel == null ? null : sel.Name, selCat);
        }

        private static string[] ReadLines(string path)
        {
            var lines = new List<string>();
            using (var sr = new StringReader(ReadShared(path)))
            {
                string l;
                while ((l = sr.ReadLine()) != null) lines.Add(l);
            }
            return lines.ToArray();
        }

        private static string ReadShared(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            using (var sr = new StreamReader(fs))
                return sr.ReadToEnd();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            foreach (var w in watchers) w.Dispose();
            tmrRefresh.Dispose();
            tmrAlive.Dispose();
            base.OnFormClosed(e);
        }

        private static string FindRoot()
        {
            for (DirectoryInfo d = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory); d != null; d = d.Parent)
            {
                if (File.Exists(Path.Combine(d.FullName, "README.md")) && Directory.Exists(Path.Combine(d.FullName, "WinForms")))
                    return d.FullName;
            }
            return null;
        }

        private string ImagesDir
        {
            get
            {
                string local = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                if (Directory.Exists(local) || rootDir == null) return local;
                return Path.Combine(rootDir, "Images");
            }
        }

        // 목록 = README 표 + bin 폴더의 exe + WinForms 프로젝트 폴더 (새 예제는 자동 추가)
        private void LoadSamples()
        {
            var byName = new Dictionary<string, Sample>(StringComparer.OrdinalIgnoreCase);

            string readme = rootDir == null ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "README.md") : Path.Combine(rootDir, "README.md");
            if (File.Exists(readme))
            {
                var row = new Regex(@"^\|\s*\*\*(?<n>[^*]+)\*\*\s*\|\s*(?<d>.*?)\s*\|\s*(?<v>[^|]*?)\s*\|\s*$");
                string category = "";
                foreach (string line in ReadLines(readme))
                {
                    if (line.StartsWith("### "))
                    {
                        category = line.Substring(4).Trim();
                        continue;
                    }
                    Match m = row.Match(line);
                    if (!m.Success) continue;
                    string name = m.Groups["n"].Value.Trim();
                    byName[name] = new Sample { Name = name, Category = category, Desc = m.Groups["d"].Value, Version = m.Groups["v"].Value };
                }
            }

            var found = new List<string>();
            foreach (string exe in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, Prefix + "*.exe"))
                found.Add(Path.GetFileNameWithoutExtension(exe));
            if (rootDir != null)
            {
                string winforms = Path.Combine(rootDir, "WinForms");
                foreach (string dir in Directory.GetDirectories(winforms, Prefix + "*"))
                    if (Directory.GetFiles(dir, "*.csproj").Length > 0) found.Add(Path.GetFileName(dir));
            }
            // 솔루션에 등록된 프로젝트만 자동 추가 (삭제됐거나 테스트용으로 남은 폴더 제외)
            string sln = rootDir == null ? null : Directory.GetFiles(rootDir, "*.sln").Select(ReadShared).FirstOrDefault();
            foreach (string name in found)
            {
                if (byName.ContainsKey(name)) continue;
                if (sln != null && sln.IndexOf(name + ".csproj", StringComparison.OrdinalIgnoreCase) < 0) continue;
                byName[name] = new Sample { Name = name, Category = UnlistedCategory, Desc = ReadProjectDesc(name), Version = "" };
            }

            byName.Remove(SelfName);
            foreach (Sample s in byName.Values)
            {
                s.ExePath = FindExe(s.Name);
                // README에만 있고 실제 프로젝트(폴더/exe)가 없는 항목은 제외
                bool exists = s.ExePath != null || (rootDir != null && Directory.Exists(Path.Combine(rootDir, "WinForms", s.Name)));
                if (exists) samples.Add(s);
            }
        }

        // 프로젝트 폴더의 ReadMe.md 첫 본문 줄을 설명으로 사용
        private string ReadProjectDesc(string name)
        {
            const string none = "설명이 등록되지 않았습니다. README.md 표에 추가하면 이 곳에 표시됩니다.";
            if (rootDir == null) return none;
            string dir = Path.Combine(rootDir, "WinForms", name);
            if (!Directory.Exists(dir)) return none;
            foreach (string f in Directory.GetFiles(dir, "readme.md"))
            {
                foreach (string line in ReadLines(f))
                {
                    string t = line.Trim();
                    if (t.Length > 0 && !t.StartsWith("#")) return t;
                }
            }
            return none;
        }

        // 공통 출력 폴더 → 프로젝트 자체 bin 폴더 순으로 탐색 (가장 최근 빌드 사용)
        private string FindExe(string name)
        {
            // exe 이름은 csproj의 AssemblyName을 따름 (폴더명과 다를 수 있음)
            var exeNames = new List<string> { name };
            if (rootDir != null)
            {
                string dir = Path.Combine(rootDir, "WinForms", name);
                if (Directory.Exists(dir))
                {
                    foreach (string csproj in Directory.GetFiles(dir, "*.csproj"))
                    {
                        Match m = Regex.Match(ReadShared(csproj), "<AssemblyName>(.*?)</AssemblyName>");
                        if (m.Success && !exeNames.Contains(m.Groups[1].Value.Trim())) exeNames.Add(m.Groups[1].Value.Trim());
                    }
                }
            }

            var paths = new List<string>();
            foreach (string exe in exeNames)
            {
                paths.Add(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, exe + ".exe"));
                if (rootDir == null) continue;
                foreach (string cfg in new[] { "Debug", "Release" })
                    paths.Add(Path.Combine(rootDir, "WinForms", name, "bin", cfg, exe + ".exe"));
            }
            return paths.Where(File.Exists).OrderByDescending(File.GetLastWriteTime).FirstOrDefault();
        }

        private void BuildTree(string keepName = null, string keepCat = null)
        {
            var expanded = new HashSet<string>(tvList.Nodes.Cast<TreeNode>().Where(n => n.IsExpanded).Select(n => n.Text));
            TreeNode keep = null;
            TreeNode keepCatNode = null;
            string filter = txtSearch.Text.Trim();
            var list = samples.Where(s => filter.Length == 0
                || s.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0
                || s.Desc.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            // README 카테고리 순서 유지, 미등록은 맨 뒤
            var groups = list.GroupBy(s => s.Category).OrderBy(g => g.Key == UnlistedCategory ? 1 : 0).ToList();

            tvList.BeginUpdate();
            tvList.Nodes.Clear();
            nodeThumbs.Clear();
            foreach (var g in groups)
            {
                TreeNode cat = tvList.Nodes.Add(g.Key);
                foreach (Sample s in g.OrderBy(x => x.Name))
                {
                    TreeNode n = cat.Nodes.Add(ShortName(s.Name));
                    n.Tag = s;
                    n.ToolTipText = s.Desc;
                    nodeThumbs[s.Name] = GetThumb(s, ThumbW, ThumbH) ?? noThumb;
                    if (s.ExePath == null) n.ForeColor = Color.Gray;
                    if (s.Name == keepName) keep = n;
                }
                if (g.Key == keepCat) keepCatNode = cat;
                if (keepName != null && expanded.Contains(g.Key)) cat.Expand();
            }
            if (filter.Length > 0) tvList.ExpandAll();
            else if (keepName == null && keepCat == null && tvList.Nodes.Count > 0) tvList.Nodes[0].Expand();
            tvList.EndUpdate();

            int ready = list.Count(s => s.ExePath != null);
            lblCount.Text = string.Format("예제 {0}개 (실행 가능 {1}개, 빌드 필요 {2}개) - 폴더 변경 자동 반영", list.Count, ready, list.Count - ready);
            // 선택 복원, 없으면 첫 카테고리를 선택해 전체 이미지 표를 보여줌
            if (keep != null) tvList.SelectedNode = keep;
            else if (keepCatNode != null) tvList.SelectedNode = keepCatNode;
            else if (tvList.Nodes.Count > 0) tvList.SelectedNode = tvList.Nodes[0];
            else ShowDetail(null);
        }

        private static Bitmap MakeNoImageThumb(int w, int h)
        {
            var bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.WhiteSmoke);
                g.DrawRectangle(Pens.LightGray, 0, 0, w - 1, h - 1);
                TextRenderer.DrawText(g, "No Image", SystemFonts.SmallCaptionFont, new Rectangle(0, 0, w, h), Color.Gray,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            return bmp;
        }

        // 캡처 이미지를 w x h 썸네일로 축소 (파일이 바뀔 때만 다시 생성)
        private Bitmap GetThumb(Sample s, int w, int h)
        {
            string path = ImagePath(s);
            if (!File.Exists(path)) return null;
            string key = path + "|" + w + "x" + h;
            DateTime t = File.GetLastWriteTime(path);
            KeyValuePair<DateTime, Bitmap> c;
            if (thumbCache.TryGetValue(key, out c) && c.Key == t) return c.Value;
            try
            {
                using (var ms = new MemoryStream(File.ReadAllBytes(path)))
                using (var src = Image.FromStream(ms))
                {
                    var bmp = new Bitmap(w, h);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        float k = Math.Min((float)w / src.Width, (float)h / src.Height);
                        int iw = (int)(src.Width * k), ih = (int)(src.Height * k);
                        g.DrawImage(src, (w - iw) / 2, (h - ih) / 2, iw, ih);
                    }
                    thumbCache[key] = new KeyValuePair<DateTime, Bitmap>(t, bmp);
                    return bmp;
                }
            }
            catch { return null; }
        }

        // 카테고리 선택: 소속 예제를 이미지 표로 표시
        private void ShowCategory(TreeNode cat)
        {
            SetGridMode(true);
            SetPreview(null);
            var list = cat.Nodes.Cast<TreeNode>().Select(n => n.Tag as Sample).Where(x => x != null).ToList();
            lblName.Text = cat.Text;
            lblDesc.Text = lblState.Text = "";
            lblCategory.Text = string.Format("예제 {0}개 (클릭: 상세, 더블클릭: 실행)", list.Count);

            gridImages.Images.Clear();
            gridImages.Images.Add("none", MakeNoImageThumb(GridW, GridH));
            lvGrid.BeginUpdate();
            lvGrid.Items.Clear();
            foreach (Sample s in list)
            {
                Bitmap tb = GetThumb(s, GridW, GridH);
                if (tb != null) gridImages.Images.Add(s.Name, tb);
                var it = new ListViewItem(ShortName(s.Name)) { Tag = s, ToolTipText = s.Desc, ImageKey = tb != null ? s.Name : "none" };
                if (s.ExePath == null) it.ForeColor = Color.Gray;
                lvGrid.Items.Add(it);
            }
            lvGrid.EndUpdate();
        }

        private void SetGridMode(bool grid)
        {
            lvGrid.Visible = grid;
            pbPreview.Visible = lblDesc.Visible = pnlFoot.Visible = !grid;
        }

        private static string ShortName(string name)
        {
            return name.StartsWith(Prefix) ? name.Substring(Prefix.Length) : name;
        }

        private string ImagePath(Sample s)
        {
            return Path.Combine(ImagesDir, s.Name + ".png");
        }

        private void SetPreview(Sample s)
        {
            Image old = previewImage;
            previewImage = null;
            if (s != null && File.Exists(ImagePath(s)))
            {
                try
                {
                    // 파일 잠금을 피하기 위해 메모리로 읽음
                    using (var ms = new MemoryStream(File.ReadAllBytes(ImagePath(s))))
                        previewImage = new Bitmap(Image.FromStream(ms));
                }
                catch { previewImage = null; }
            }
            pbPreview.Image = previewImage;
            if (old != null) old.Dispose();
            pbPreview.Invalidate();
        }

        private void ShowDetail(Sample s)
        {
            SetGridMode(false);
            SetPreview(s);
            if (s == null)
            {
                lblCategory.Text = lblName.Text = lblDesc.Text = lblState.Text = "";
                btnRun.Enabled = btnCapture.Enabled = false;
                return;
            }
            lblCategory.Text = s.Category;
            lblName.Text = ShortName(s.Name);
            lblDesc.Text = s.Desc + (s.Version.Length > 0 ? "\r\n\r\nAPI version: " + s.Version : "");
            lblState.Text = s.ExePath != null ? s.ExePath : "실행 파일이 없습니다. 솔루션을 빌드하세요.";
            btnRun.Enabled = btnCapture.Enabled = s.ExePath != null;
        }

        private void Run(Sample s)
        {
            if (s == null || s.ExePath == null) return;
            try
            {
                Process.Start(new ProcessStartInfo(s.ExePath) { WorkingDirectory = Path.GetDirectoryName(s.ExePath) });
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "실행 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 실행 중인 예제의 창을 캡처해 Images\<프로젝트명>.png 로 저장
        private void CaptureWindow(Sample s)
        {
            if (s == null || s.ExePath == null) return;
            Process p = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(s.ExePath)).FirstOrDefault(x => x.MainWindowHandle != IntPtr.Zero);
            if (p == null)
            {
                MessageBox.Show(this, "먼저 예제를 실행하고 모델을 불러온 뒤 다시 눌러 주세요.", "캡처", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            IntPtr h = p.MainWindowHandle;
            if (IsIconic(h)) ShowWindow(h, 9);
            SetForegroundWindow(h);
            Thread.Sleep(500);

            RECT r;
            GetWindowRect(h, out r);
            int w = r.Right - r.Left, ht = r.Bottom - r.Top;
            if (w <= 0 || ht <= 0) return;

            try
            {
                Directory.CreateDirectory(ImagesDir);
                using (var bmp = new Bitmap(w, ht, PixelFormat.Format32bppArgb))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                        g.CopyFromScreen(r.Left, r.Top, 0, 0, new Size(w, ht));
                    bmp.Save(ImagePath(s), ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "캡처 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Activate();
            BuildTree(s.Name);
        }

        private void pbPreview_Paint(object sender, PaintEventArgs e)
        {
            if (pbPreview.Image != null) return;
            TextRenderer.DrawText(e.Graphics, "미리보기 이미지 없음\r\n(예제 실행 후 '실행 중 화면 캡처')", Font,
                pbPreview.ClientRectangle, Color.Gray, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // 전체 직접 그리기 모드에서는 연결선과 +/- 도 직접 그려야 함
        private void DrawTreeLines(DrawTreeNodeEventArgs e)
        {
            int ind = tvList.Indent, lv = e.Node.Level;
            Rectangle b = e.Node.Bounds;   // e.Bounds는 줄 전체(X=0)이므로 라벨 위치는 Node.Bounds 사용
            int ox = b.X - (lv + 1) * ind;
            int cy = b.Y + b.Height / 2;
            Graphics g = e.Graphics;

            using (var br = new SolidBrush(tvList.BackColor)) g.FillRectangle(br, 0, b.Y, Math.Max(0, b.X), b.Height);
            using (var pen = new Pen(Color.Gray) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot })
            {
                if (lv == 0)
                {
                    if (e.Node.Nodes.Count == 0) return;
                    int gx = ox + ind / 2;
                    if (e.Node.IsExpanded) g.DrawLine(pen, gx, cy + 5, gx, b.Bottom);
                    var box = new Rectangle(gx - 4, cy - 4, 8, 8);
                    g.FillRectangle(Brushes.White, box);
                    g.DrawRectangle(Pens.Gray, box);
                    g.DrawLine(Pens.Black, gx - 2, cy, gx + 2, cy);
                    if (!e.Node.IsExpanded) g.DrawLine(Pens.Black, gx, cy - 2, gx, cy + 2);
                }
                else
                {
                    int gx = ox + (lv - 1) * ind + ind / 2;   // 부모 +/- 의 x 좌표
                    g.DrawLine(pen, gx, b.Y, gx, e.Node.NextNode == null ? cy : b.Bottom);
                    g.DrawLine(pen, gx, cy, b.X - 4, cy);
                }
            }
        }

        private void tvList_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Bounds.Height <= 0) return;
            DrawTreeLines(e);
            Sample s = e.Node.Tag as Sample;
            bool sel = (e.State & TreeNodeStates.Selected) != 0;
            int lx = e.Node.Bounds.X;
            Rectangle row = new Rectangle(lx, e.Bounds.Y, Math.Max(0, tvList.ClientSize.Width - lx), e.Bounds.Height);

            Color back = sel ? (tvList.Focused ? SystemColors.Highlight : SystemColors.ControlLight) : tvList.BackColor;
            Color fore = sel && tvList.Focused ? SystemColors.HighlightText : (e.Node.ForeColor.IsEmpty ? tvList.ForeColor : e.Node.ForeColor);
            using (var br = new SolidBrush(back)) e.Graphics.FillRectangle(br, row);

            int tx = row.X + 2;
            Bitmap tb;
            if (s != null && nodeThumbs.TryGetValue(s.Name, out tb))
            {
                e.Graphics.DrawImage(tb, row.X + 2, row.Y + (row.Height - ThumbH) / 2, ThumbW, ThumbH);
                tx += ThumbW + 6;
            }
            TextRenderer.DrawText(e.Graphics, e.Node.Text, tvList.Font, new Rectangle(tx, row.Y, Math.Max(0, row.Right - tx), row.Height), fore,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BuildTree();
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Sample s = e.Node.Tag as Sample;
            if (s != null) ShowDetail(s); else ShowCategory(e.Node);
            UpdateExitButton();
        }

        private TreeNode FindNode(Sample s)
        {
            return tvList.Nodes.Cast<TreeNode>().SelectMany(c => c.Nodes.Cast<TreeNode>()).FirstOrDefault(n => n.Tag == s);
        }

        private void lvGrid_Click(object sender, EventArgs e)
        {
            if (lvGrid.SelectedItems.Count == 0) return;
            TreeNode n = FindNode(lvGrid.SelectedItems[0].Tag as Sample);
            if (n != null) tvList.SelectedNode = n;
        }

        private void lvGrid_ItemActivate(object sender, EventArgs e)
        {
            if (lvGrid.SelectedItems.Count > 0) Run(lvGrid.SelectedItems[0].Tag as Sample);
        }

        // 썸네일 영역도 클릭되도록 줄(y 좌표) 기준으로 노드를 찾음 (연결선 표시 중에는 FullRowSelect 사용 불가)
        private TreeNode RowAt(Point p)
        {
            for (TreeNode n = tvList.TopNode; n != null; n = n.NextVisibleNode)
            {
                Rectangle b = n.Bounds;
                if (b.Y > tvList.ClientSize.Height) break;
                if (p.Y >= b.Y && p.Y < b.Y + b.Height && p.X >= b.X) return n;
            }
            return null;
        }

        private void tvList_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode n = RowAt(e.Location);
            if (e.Button == MouseButtons.Left && n != null) tvList.SelectedNode = n;
        }

        private void tvList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode n = RowAt(e.Location);
            if (e.Button == MouseButtons.Left && n != null) Run(n.Tag as Sample);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Run(tvList.SelectedNode == null ? null : tvList.SelectedNode.Tag as Sample);
        }

        private Sample CurrentSample()
        {
            if (lvGrid.Visible && lvGrid.SelectedItems.Count > 0) return lvGrid.SelectedItems[0].Tag as Sample;
            return tvList.SelectedNode == null ? null : tvList.SelectedNode.Tag as Sample;
        }

        private static Process[] RunningOf(Sample s)
        {
            if (s == null || s.ExePath == null) return new Process[0];
            return Process.GetProcessesByName(Path.GetFileNameWithoutExtension(s.ExePath));
        }

        // 선택한 예제가 실행 중일 때만 종료 버튼 활성화
        private void UpdateExitButton()
        {
            btnExit.Enabled = RunningOf(CurrentSample()).Length > 0;
        }

        // 선택한 예제의 실행 창을 닫음 (런처는 유지)
        private void btnExit_Click(object sender, EventArgs e)
        {
            Process[] procs = RunningOf(CurrentSample());
            foreach (Process p in procs) { try { p.CloseMainWindow(); } catch { } }
            foreach (Process p in procs)
            {
                try
                {
                    if (p.WaitForExit(3000)) continue;
                    if (MessageBox.Show(this, "예제가 종료되지 않습니다. 강제 종료할까요?", "실행 창 종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        p.Kill();
                }
                catch { }
            }
            UpdateExitButton();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            CaptureWindow(tvList.SelectedNode == null ? null : tvList.SelectedNode.Tag as Sample);
        }
    }
}
