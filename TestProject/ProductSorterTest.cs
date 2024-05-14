using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using classes;
using classes.Managers;
using FakeDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class ProductSorterTest
    {
        private ProductSorter _sorter = new ProductSorter(new FakeProductRepository());
        private Productmanager productmanager = new Productmanager(new FakeProductRepository());
        List<Product> products = new List<Product>();


        public ProductSorterTest() 
        {
            products = productmanager.Products;
        }
        [TestMethod]
        public void ProductFilter()
        {
            List<Product> products = _sorter.FilterProduct("");
            List<Product> posters = _sorter.FilterProduct("Posters");
            List<Product> Books = _sorter.FilterProduct("Books");
            List<Product> clothing = _sorter.FilterProduct("Clothing");
            List<Product> figures = _sorter.FilterProduct("Figures");

            Assert.IsInstanceOfType(products[0], typeof(Product));
            Assert.IsInstanceOfType(posters[0], typeof(Poster));
            Assert.IsInstanceOfType(Books[0], typeof(Books));
            Assert.IsInstanceOfType(clothing[0], typeof(Clothing));
            Assert.IsInstanceOfType(figures[0], typeof(Figures));
        }

        [TestMethod]
        public void PorductFilterOutOfIndex()
        {
            

            Assert.ThrowsException<IndexOutOfRangeException>(() => _sorter.FilterProduct("nothing"));
        }
        [TestMethod]
        public void ProductNameFilter()
        {
            Product product = _sorter.Productname(products, "Poster");

            Assert.IsNotNull(product);

        }
        public void ProductNameFilterNoName()
        {
            Product product = _sorter.Productname(products, "NoName");

            Assert.IsNull(product);

        }
        [TestMethod]
        public void ProductCatogoriesFilter()
        {
            _sorter.CatogriesFilter(products, 6);

            Assert.IsNotNull(products[0]);
        }
        [TestMethod]
        public void ProductCatogoriesFilterOutOfIndex()
        {
            int MoreThen = 9;
            int LessThen = -2;

            Assert.ThrowsException<IndexOutOfRangeException>(() => _sorter.CatogriesFilter(products,MoreThen));
            Assert.ThrowsException<IndexOutOfRangeException>(() => _sorter.CatogriesFilter(products, LessThen));
        }
        [TestMethod]
        public void SortByPriceTest()
        {
            
            List<Product> products = productmanager.Products;

            products.Sort();

            Assert.AreEqual(10, products[0].Price);
            Assert.AreEqual(10, products[1].Price);
            Assert.AreEqual(15, products[2].Price);
            Assert.AreEqual(15, products[3].Price);
            Assert.AreEqual(15, products[4].Price);
            Assert.AreEqual(20, products[5].Price);
            Assert.AreEqual(40, products[6].Price);
            
        }
        [TestMethod]
        public void SortById()
        {
       
            List<Product> products = productmanager.Products;

            _sorter.SortById(products);

            Assert.AreEqual("1", products[0].ID);
            Assert.AreEqual("2", products[1].ID);
            Assert.AreEqual("3", products[2].ID);
            Assert.AreEqual("4", products[3].ID);
            Assert.AreEqual("5", products[4].ID);
            Assert.AreEqual("5E", products[5].ID);
            Assert.AreEqual("6", products[6].ID);

        }
    }
}
