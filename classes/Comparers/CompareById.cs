using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes.Comparers
{
    public class CompareById : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x == null || y == null)
                return 0;

            int xId = ExtractNumericId(x.ID);
            int yId = ExtractNumericId(y.ID);

            return xId.CompareTo(yId);
        }

        private int ExtractNumericId(string id)
        {
            string numericPart = new string(id.Where(char.IsDigit).ToArray());
            return int.Parse(numericPart);
        }
    }

}

