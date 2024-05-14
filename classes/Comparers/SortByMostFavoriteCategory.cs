using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes.Comparers
{
    public class SortByMostFavoriteCategory : IComparer<KeyValuePair<Catogories, int>>
    {
        public int Compare(KeyValuePair<Catogories, int> x, KeyValuePair<Catogories, int> y)
        {
            return x.Value.CompareTo(y.Value);
        }
    }
}
