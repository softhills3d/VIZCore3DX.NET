using System.Collections.Generic;

namespace VIZCore3DX.NET.ImportAttribute
{
    public class ShxAttributeXmlNode
    {
        public string Name { get; set; }
        public Dictionary<string, string> Properties { get; }

        public ShxAttributeXmlNode(string name)
        {
            Name = name;
            Properties = new Dictionary<string, string>();
        }

        public bool Add(string key, string val, bool allowNullValue = true)
        {
            if (!allowNullValue && string.IsNullOrEmpty(val)) return false;

            key = key.ToUpperInvariant();
            val = (val ?? string.Empty).ToUpperInvariant();

            if (Properties.ContainsKey(key)) return false;

            Properties.Add(key, val);
            return true;
        }
    }
}
