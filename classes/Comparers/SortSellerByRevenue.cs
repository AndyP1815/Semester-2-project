using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes.Comparers
{
    public class SortSellerByRevenue : IComparer<Seller>
    {
   

        public int Compare(Seller? x, Seller? y)
        {
            return x.Revenue.CompareTo(y.Revenue);
        }
    }
}
