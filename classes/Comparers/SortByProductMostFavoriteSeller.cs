using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes.Comparers
{
    public class SortByProductMostFavoriteSeller : IComparer<KeyValuePair<Seller, int>>
    {
        public int Compare(KeyValuePair<Seller, int> x, KeyValuePair<Seller, int> y)
        {
            return x.Value.CompareTo(y.Value);
        }
    }
    
    
}
