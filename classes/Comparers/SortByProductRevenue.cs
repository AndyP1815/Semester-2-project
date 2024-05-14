using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes.Comparers
{
    public class SortByProductRevenue : IComparer<KeyValuePair<Product, decimal>>
    {
        public int Compare(KeyValuePair<Product, decimal> x, KeyValuePair<Product, decimal> y)
        {
            return x.Value.CompareTo(y.Value);
        }
    }
}
