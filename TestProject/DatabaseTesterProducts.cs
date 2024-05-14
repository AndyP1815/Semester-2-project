using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace TestProject
{
    [TestClass]
    public  class DatabaseTesterProducts
    {
        [TestMethod]
        public void TestGetBooks()
        {
            ProductRepo p = new ProductRepo();

            Assert.IsNotNull(p.GetBooks());
        }
        [TestMethod]
        public void TestGetFigures()
        {
            ProductRepo p = new ProductRepo();

            Assert.IsNotNull(p.GetFigures());
        }
        [TestMethod]
        public void TestGetClothing()
        {
            ProductRepo p = new ProductRepo();

            Assert.IsNotNull(p.GetClothes());
        }
        [TestMethod]
        public void TestGetPosters()
        {
            ProductRepo p = new ProductRepo();

            Assert.IsNotNull(p.GetPosters());
        }
    
   
    }
}
