using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes;
using classes.Managers;
using DAL;
using FakeDAL;

namespace TestProject
{
    [TestClass]
    public class FinanceSorterTest
    {
        private FinanceSorter financeSorter;
        private Usermanager usermanager;
        public FinanceSorterTest() 
        {
            financeSorter = new FinanceSorter();
            usermanager = new Usermanager(new FakeUserRepository(),new CartRepository(),new ProductRepo());
        }
        [TestMethod]
        public void GetTotalRevenue()
        {
            List<Seller> RevenueSellers = usermanager.GetSellers();

           
            double Revenue = financeSorter.GetTotalRevenue(RevenueSellers);
            double ExpectedRevenue = 0;

            foreach (Seller s in RevenueSellers)
            {
                ExpectedRevenue += s.Revenue;
            }

            Assert.AreEqual(ExpectedRevenue, Revenue);
        }
        public void SortByRevenueTest()
        {
          

            List<Seller> Sellers = usermanager.GetSellers();

            financeSorter.SortSellerByrevenue(Sellers);

            Assert.AreEqual(10.25, Sellers[0]);
            Assert.AreEqual(100, Sellers[1]);
        }

    }
}
