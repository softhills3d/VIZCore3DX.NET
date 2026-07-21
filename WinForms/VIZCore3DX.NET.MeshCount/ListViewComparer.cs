using System.Windows.Forms;

namespace VIZCore3DX.NET.MeshCount
{
    public class ListViewComparer : System.Collections.IComparer
    {
        private int columnIndex;
        private SortOrder sortOrder;

        public ListViewComparer(int columnIndex, SortOrder sortOrder)
        {
            this.columnIndex = columnIndex;
            this.sortOrder = sortOrder;
        }

        public int Compare(object x, object y)
        {
            ListViewItem itemX = (ListViewItem)x;
            ListViewItem itemY = (ListViewItem)y;

            string textX = itemX.SubItems[columnIndex].Text;
            string textY = itemY.SubItems[columnIndex].Text;

            // 숫자면 숫자로 비교, 아니면 문자열로 비교
            double numX, numY;
            bool isNumX = double.TryParse(textX.Replace(",", ""), out numX);
            bool isNumY = double.TryParse(textY.Replace(",", ""), out numY);

            int result;
            if (isNumX && isNumY)
                result = numX.CompareTo(numY);
            else
                result = string.Compare(textX, textY);

            return sortOrder == SortOrder.Ascending ? result : -result;
        }
    }
}
