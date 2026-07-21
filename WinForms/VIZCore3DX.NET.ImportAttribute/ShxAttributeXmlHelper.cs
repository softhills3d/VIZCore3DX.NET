using System;
using System.Collections.Generic;
using System.Xml;
// XML 구조
// ModelPublishingData
//  └─ Models
//      └─ Model
//          └─ Item(node)
//              └─ FormProperties
//                  └─ Property(name, value)

namespace VIZCore3DX.NET.ImportAttribute
{
    /// <summary>
    /// XML 속성(Attribute) 파일을 읽어
    /// 노드별 속성 목록을 생성하는 Helper 클래스
    /// </summary>
    public class ShxAttributeXmlHelper
    {
        /// <summary>
        /// XML에서 읽어온 속성(Node) 목록
        /// </summary>
        public List<ShxAttributeXmlNode> AttributeList { get; } = new List<ShxAttributeXmlNode>();


        /// <summary>
        /// XML 파일을 읽어 속성 정보를 생성
        /// </summary>
        /// <param name="path">XML 파일 경로</param>
        public void Import(string path)
        {
            // XML Reader 설정
            XmlReaderSettings settings = new XmlReaderSettings
            {
                IgnoreComments = true,             // XML 주석 무시
                ValidationType = ValidationType.None   // XML 검증 사용 안 함
            };

            // XML 파일 열기
            using (XmlReader reader = XmlReader.Create(path, settings))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);

                XmlNode rootNode = null;

                // 최상위 노드(ModelPublishingData) 검색
                foreach (XmlNode childNode in doc.ChildNodes)
                {
                    if (childNode.Name == "ModelPublishingData")
                    {
                        rootNode = childNode;
                        break;
                    }
                }

                // 루트 노드가 존재하면 하위 노드 읽기
                if (rootNode != null)
                    LoadModels(rootNode);
            }
        }

        /// <summary>
        /// Models 노드를 검색
        /// </summary>
        /// <param name="rootNode">ModelPublishingData 노드</param>
        private void LoadModels(XmlNode rootNode)
        {
            XmlNode modelsNode = null;

            // Models 노드 검색
            foreach (XmlNode childNode in rootNode.ChildNodes)
            {
                if (childNode.Name == "Models")
                {
                    modelsNode = childNode;
                    break;
                }
            }

            // Model 노드 읽기
            if (modelsNode != null)
                LoadModel(modelsNode);
        }

        /// <summary>
        /// Model 노드 내부의 Item 정보를 읽음
        /// </summary>
        /// <param name="modelsNode">Models 노드</param>
        private void LoadModel(XmlNode modelsNode)
        {
            foreach (XmlNode childNode in modelsNode.ChildNodes)
            {
                if (childNode.Name == "Model")
                    LoadItem(childNode);
            }
        }

        /// <summary>
        /// Item 노드의 속성(Property)을 읽어 AttributeList에 저장
        /// </summary>
        /// <param name="modelNode">Model 노드</param>
        private void LoadItem(XmlNode modelNode)
        {
            foreach (XmlNode childNode in modelNode.ChildNodes)
            {
                // Item 노드만 처리 (공백/주석 등 비-엘리먼트 노드는 자동으로 걸러짐)
                if (childNode.NodeType != XmlNodeType.Element) continue;
                if (childNode.Name != "Item")
                    continue;

                // Item 이름 생성
                ShxAttributeXmlNode item = new ShxAttributeXmlNode(
                    GetXmlAttribute(childNode, "name"));

                // FormProperties 노드를 이름으로 직접 검색 (공백 텍스트 노드 영향 없음)
                XmlNode formPropertiesNode = null;
                foreach (XmlNode itemChild in childNode.ChildNodes)
                {
                    if (itemChild.NodeType != XmlNodeType.Element) continue;
                    if (itemChild.Name == "FormProperties")
                    {
                        formPropertiesNode = itemChild;
                        break;
                    }
                }

                // FormProperties가 존재하는 경우 속성 읽기
                if (formPropertiesNode != null)
                {
                    foreach (XmlNode propNode in formPropertiesNode.ChildNodes)
                    {
                        if (propNode.NodeType != XmlNodeType.Element) continue;

                        item.Add(
                            GetXmlAttribute(propNode, "name"),
                            GetXmlAttribute(propNode, "value"),
                            true);
                    }
                }

                // 읽은 Item 저장
                AttributeList.Add(item);
            }
        }

        /// <summary>
        /// XML 노드의 Attribute 값을 반환
        /// </summary>
        /// <param name="node">대상 XML 노드</param>
        /// <param name="name">Attribute 이름</param>
        /// <returns>Attribute 값 (없으면 빈 문자열)</returns>
        private string GetXmlAttribute(XmlNode node, string name)
        {
            if (node.Attributes.GetNamedItem(name) == null)
                return String.Empty;
            else
                return node.Attributes.GetNamedItem(name).Value;
        }
    }
}