using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes;
using classes.Managers;
using FakeDAL;

namespace TestProject
{
    [TestClass]
    public class ProductDisplayTest
    {
        private Productmanager productmanager;
        private ProductDisplay productDisplay = new ProductDisplay();
        List<Product> products = new List<Product>();

        public ProductDisplayTest()
        {
            productmanager = new Productmanager(new FakeProductRepository());
            products = productmanager.Products;
        }

        [TestMethod]
        public void GetNumber()
        {
            int number = 18;

            var test = productDisplay.GetNumber(number);

            Assert.AreEqual(18, test.Count);
        }
        [TestMethod]
        public void GetNumberAbove24()
        {
            int number = 100;

            var test = productDisplay.GetNumber(number);

            int count = test.Count;
            Assert.AreEqual(24, count);
        }
        [TestMethod]
        public void GetNumberExceptions()
        {
            int number = 0;

            int number2 = -1;

            Assert.ThrowsException<IndexOutOfRangeException>(() => productDisplay.GetNumber(number));
            Assert.ThrowsException<IndexOutOfRangeException>(() => productDisplay.GetNumber(number2));

        }
      
        [TestMethod]
        public void GetProductInList()
        {
            var products = this.products;
            List<int> numbers = new List<int>
            {
                1,2,3,4,5,6
            };
            List<int> numbers2 = new List<int>
            {
                1,2,3
            };


            var SameCount = productDisplay.ProductDTOs(products, numbers);
            var MoreProducts = productDisplay.ProductDTOs(products, numbers2);

            Assert.IsNotNull(SameCount);
            Assert.IsNotNull(MoreProducts);
        }
        [TestMethod]
        public void GetProductInListExceptions()
        {
            var products = this.products;
            List<int> numbers = new List<int>
            {
                1,2,3,4,5,6,7,8
            };
            List<int> nonumbers = new List<int>();
            var NoProducts = new List<Product>();


            Assert.ThrowsException<IndexOutOfRangeException>(() => productDisplay.ProductDTOs(products, numbers));
            Assert.ThrowsException<IndexOutOfRangeException>(() => productDisplay.ProductDTOs(NoProducts, numbers));
            Assert.ThrowsException<IndexOutOfRangeException>(() => productDisplay.ProductDTOs(products, nonumbers));
            Assert.ThrowsException<IndexOutOfRangeException>(() => productDisplay.ProductDTOs(NoProducts, nonumbers));
        }

    }


}

