using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes.Comparers;
using classes.Interfaces;
using classes.Managers;

namespace classes
{
    public class FinanceSorter
    {
      
        private SortByProductCount sortByProductCount;
        private SortSellerByRevenue sortSellerByRevenue;
        private SortByOrderPrice sortByOrderPrice;
        private SortByProductRevenue sortByProductRevenue;
        public FinanceSorter() 
        {
   
            sortByProductCount = new SortByProductCount();
            sortSellerByRevenue = new SortSellerByRevenue();
            sortByOrderPrice = new SortByOrderPrice();
            sortByProductRevenue = new SortByProductRevenue();
        }

        public double GetTotalRevenue(List<Seller>sellers)
        {
            try
            {
                double revenue = 0;

                foreach (Seller user in sellers)
                {
                    revenue += user.Revenue;
                }
                return revenue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public void SortProductsOrdered(Dictionary<Product, int> productCount)
        {
            try
            {
                List<KeyValuePair<Product, int>> sortedList = new List<KeyValuePair<Product, int>>(productCount);
                sortedList.Sort(sortByProductCount);
                productCount.Clear();
                foreach (var kvp in sortedList)
                {
                    productCount[kvp.Key] = kvp.Value;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public void SortSellerByrevenue(List<Seller> productCount)
        {
            if (productCount == null)
            {
                    throw new Exception("The inputed value or list is null");
                
            }
            productCount.Sort(sortSellerByRevenue);

        }

        public void SortProductRevenue(Dictionary<Product, decimal> Revenue)
        {
            try
            {
                List<KeyValuePair<Product, decimal>> sortedList = new List<KeyValuePair<Product, decimal>>(Revenue);
                sortedList.Sort(sortByProductRevenue);
                Revenue.Clear();
                foreach (var kvp in sortedList)
                {
                    Revenue[kvp.Key] = kvp.Value;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public void SortByOrderPrice(List<Order> orders)

        {
            if (orders == null)
            {
                throw new Exception("The inputed value or list is null");

            }
            orders.Sort(sortByOrderPrice);
        }


    }
}
