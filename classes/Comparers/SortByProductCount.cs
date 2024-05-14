using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace classes.Comparers
{
    public class SortByProductCount : IComparer<KeyValuePair<Product, int>>
    {
        public int Compare(KeyValuePair<Product, int> x, KeyValuePair<Product, int> y)
        {
            return x.Value.CompareTo(y.Value);
        }
    }
}
