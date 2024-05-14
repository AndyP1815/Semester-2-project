using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes.Comparers
{
    public class SortByOrderPrice : IComparer<Order>
    {
        public int Compare(Order? x, Order? y)
        {
            if (x.Products.Count == 0 && y.Products.Count == 0)
            {
                return 0;
            }
            else if (x.Products.Count == 0)
            {
                return -1;
            }
            else if (y.Products.Count == 0)
            {
                return 1;
            }
            else
            {
                decimal xPrice = x.GetPrice();
                decimal yPrice = y.GetPrice();
                return xPrice.CompareTo(yPrice);
            }
        }
    }

}
