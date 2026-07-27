using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VIZCore3DX.NET.Data;
using VIZCore3DX.NET.Event;
using VIZCore3DX.NET.Importer;

namespace VIZCore3DX.NET.ImportAttribute
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
            splitContainer1.Panel1.Controls.Add(vizcore3dx);

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
            InitializeVIZCore3DXEvent();
        }

        private void InitializeVIZCore3DX()
        {
            // ================================================================
            // 모델 열기 시, 3D 화면 Rendering 차단
            // ================================================================
            vizcore3dx.BeginUpdate();

            try
            {
                // ================================================================
                // 설정 - 툴바
                // ================================================================
                vizcore3dx.ToolbarMain.Visible = true;
                vizcore3dx.ToolbarNote.Visible = false;
                vizcore3dx.ToolbarMeasure.Visible = false;
                vizcore3dx.ToolbarSection.Visible = false;
                vizcore3dx.ToolbarSnapshot.Visible = false;
            }
            finally
            {
                // ================================================================
                // 모델 열기 시, 3D 화면 Rendering 재시작
                // ================================================================
                vizcore3dx.EndUpdate();
            }
        }

        private void InitializeVIZCore3DXEvent()
        {
            // 이벤트 중복 등록 방지
            vizcore3dx.Object3D.OnNodeEvent -= Object3D_OnNodeEvent;
            vizcore3dx.Object3D.OnNodeEvent += Object3D_OnNodeEvent;
        }

        private void Object3D_OnNodeEvent(object sender, EventManager.NodeEventArgs e)
        {
            if (e == null || e.Node == null || e.Node.Count == 0)
            {
                lvAttribute.BeginUpdate();
                lvAttribute.Items.Clear();
                lvAttribute.EndUpdate();
                return;
            }

            // 선택한 노드의 UDA 속성 조회
            ObjectAttributeCollection attributes = vizcore3dx.Object3D.UDA.FromNode(e.Node[0], true);
            Dictionary<string, string> attribute = new Dictionary<string, string>();

            if (attributes != null)
            {
                foreach (ObjectAttribute item in attributes)
                {
                    if (item == null || string.IsNullOrWhiteSpace(item.Key)) continue;

                    // 같은 Key가 있으면 덮어쓰기
                    attribute[item.Key] = item.Val;
                }
            }

            lvAttribute.BeginUpdate();
            lvAttribute.Items.Clear();

            foreach (KeyValuePair<string, string> item in attribute)
            {
                ListViewItem lvi = new ListViewItem(new string[] { item.Key, item.Value });
                lvAttribute.Items.Add(lvi);
            }

            lvAttribute.EndUpdate();
        }

        private void btnImportDump_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델 파일을 먼저 [열기] 하여 주시기 바랍니다.");
                return;
            }

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Dump 파일 선택";
                dlg.Filter = "Attribute (*.att)|*.att|Text (*.txt)|*.txt";

                if (dlg.ShowDialog() != DialogResult.OK) return;

                Cursor = Cursors.WaitCursor;

                try
                {
                    List<Node> rootNodes = vizcore3dx.Object3D.GetRootNodes();

                    if (rootNodes == null || rootNodes.Count == 0)
                    {
                        MessageBox.Show("Root 노드를 찾을 수 없습니다.", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    ShxAttribute attribute = new ShxAttribute(Path.GetDirectoryName(dlg.FileName));
                    attribute.ImportAttributeNode(Path.GetFileNameWithoutExtension(dlg.FileName), rootNodes[0].NodePath);

                    if (attribute.AttributeList.Count == 0 || attribute.AttributeList[0].Count == 0)
                    {
                        MessageBox.Show("속성정보를 불러오지 못했습니다.");
                        return;
                    }

                    // 모델과 속성 파일의 노드 경로에서 슬래시를 제거하여 비교
                    Dictionary<string, Node> nodeMap = vizcore3dx.Object3D.GetNodePathMap().ToDictionary(x => x.Key.Replace("/", ""), x => x.Value);

                    int nodeCount = 0;
                    int attCount = 0;

                    foreach (var item in attribute.AttributeList[0])
                    {
                        Node node;

                        if (nodeMap.TryGetValue(item.NodePath.Replace("/", ""), out node) == false) continue;

                        nodeCount++;

                        foreach (var prop in item.Property)
                        {
                            if (string.IsNullOrWhiteSpace(prop.Value)) continue;

                            vizcore3dx.Object3D.UDA.Add(node.GetInstanceID(), "ATT", prop.Key, prop.Value);
                            attCount++;
                        }
                    }

                    MessageBox.Show(string.Format("RESULT - NODE : {0} / ATT. : {1}", nodeCount, attCount), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR : " + ex.Message, "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void btnCustomXML_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델 파일을 먼저 [열기] 하여 주시기 바랍니다.");
                return;
            }

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "XML 파일 선택";
                dlg.Filter = "XML (*.xml)|*.xml";

                if (dlg.ShowDialog() != DialogResult.OK) return;

                Cursor = Cursors.WaitCursor;

                try
                {
                    ShxAttributeXmlHelper attribute = new ShxAttributeXmlHelper();
                    attribute.Import(dlg.FileName);

                    if (attribute.AttributeList.Count == 0)
                    {
                        MessageBox.Show("속성정보를 불러오지 못했습니다.");
                        return;
                    }

                    // 모델과 XML 속성 파일의 노드 경로에서 슬래시를 제거하여 비교
                    Dictionary<string, Node> nodeMap = vizcore3dx.Object3D.GetNodePathMap().ToDictionary(x => x.Key.Replace("/", ""), x => x.Value);

                    int nodeCount = 0;
                    int attCount = 0;

                    foreach (var item in attribute.AttributeList)
                    {
                        Node node;

                        // XML의 name 속성이 NodePath라고 가정
                        if (nodeMap.TryGetValue(item.Name.Replace("/", ""), out node) == false) continue;

                        nodeCount++;

                        foreach (var prop in item.Properties)
                        {
                            if (string.IsNullOrWhiteSpace(prop.Value)) continue;

                            vizcore3dx.Object3D.UDA.Add(node.GetInstanceID(), "ATT", prop.Key, prop.Value);
                            attCount++;
                        }
                    }

                    MessageBox.Show(string.Format("RESULT - NODE : {0} / ATT. : {1}", nodeCount, attCount), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR : " + ex.Message, "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void btnImportMultiAttribute_Click(object sender, EventArgs e)
        {
            if (vizcore3dx.Model.IsOpen() == false)
            {
                MessageBox.Show("모델 파일을 먼저 [열기] 하여 주시기 바랍니다.");
                return;
            }

            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                Cursor = Cursors.WaitCursor;

                try
                {
                    string Normalize(string nodePath) => nodePath.Replace("/", "");

                    List<Node> rootNodes = vizcore3dx.Object3D.GetRootNodes();

                    if (rootNodes == null || rootNodes.Count == 0)
                    {
                        MessageBox.Show("Root 노드를 찾을 수 없습니다.", "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string root = rootNodes[0].NodePath;
                    Dictionary<string, Node> nodeMap = vizcore3dx.Object3D.GetNodePathMap().ToDictionary(x => Normalize(x.Key), x => x.Value);

                    int nodeCount = 0;
                    int attCount = 0;

                    // ===================== .att / .txt 처리 =====================
                    ShxAttribute attribute = new ShxAttribute(dlg.SelectedPath);
                    attribute.ImportAttributeNode(Path.GetFileName(dlg.SelectedPath), root);

                    foreach (var item in attribute.AttributeList.SelectMany(x => x))
                    {
                        Node node;

                        if (nodeMap.TryGetValue(Normalize(item.NodePath), out node) == false) continue;

                        nodeCount++;

                        foreach (var prop in item.Property)
                        {
                            if (string.IsNullOrWhiteSpace(prop.Value)) continue;

                            vizcore3dx.Object3D.UDA.Add(node.GetInstanceID(), "General", prop.Key, prop.Value);
                            attCount++;
                        }
                    }

                    // ===================== .xml 처리 =====================
                    ShxAttributeXmlHelper xmlAttribute = new ShxAttributeXmlHelper();

                    foreach (string xmlFile in Directory.GetFiles(dlg.SelectedPath, "*.xml"))
                        xmlAttribute.Import(xmlFile);

                    foreach (var item in xmlAttribute.AttributeList)
                    {
                        Node node;

                        if (nodeMap.TryGetValue(Normalize(item.Name), out node) == false) continue;

                        nodeCount++;

                        foreach (var prop in item.Properties)
                        {
                            if (string.IsNullOrWhiteSpace(prop.Value)) continue;

                            vizcore3dx.Object3D.UDA.Add(node.GetInstanceID(), "General", prop.Key, prop.Value);
                            attCount++;
                        }
                    }

                    // ===================== 둘 다 없으면 =====================
                    if (attribute.AttributeList.Count == 0 && xmlAttribute.AttributeList.Count == 0)
                    {
                        MessageBox.Show("속성정보 없음");
                        return;
                    }

                    MessageBox.Show(string.Format("RESULT - NODE : {0} / ATT. : {1}", nodeCount, attCount), "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR : " + ex.Message, "VIZCore3DX.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            vizcore3dx.Model.ExportFileDialog(true);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            vizcore3dx.Model.Close();

            lvAttribute.BeginUpdate();
            lvAttribute.Items.Clear();
            lvAttribute.EndUpdate();
        }
    }
}