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
    public class FavoriteSorterTest
    {
        private Productmanager productmanager;
        private FavoriteSorter favoriteSorter;
        private Usermanager usermanager;

        public FavoriteSorterTest()
        {
            productmanager = new Productmanager(new FakeProductRepository());
            favoriteSorter = new FavoriteSorter();
            usermanager = new Usermanager(new FakeUserRepository(),new FakeCartRepositroy(),new FakeProductRepository());

        }

        [TestMethod]
        public void SortByMostFavoriteProduct()
        {
            List<Product> products = productmanager.Products;
            Dictionary<Product, int> DictionaryProducts = new Dictionary<Product, int>();
            int Count = 1;

            foreach (Product product in products)
            {
                DictionaryProducts.Add(product, Count);
                Count++;
            }
            favoriteSorter.FavoriteProductSort(DictionaryProducts);

            Assert.AreEqual(1, DictionaryProducts.Values.ElementAt(0));
            Assert.AreEqual(2, DictionaryProducts.Values.ElementAt(1));
            Assert.AreEqual(3, DictionaryProducts.Values.ElementAt(2));
            Assert.AreEqual(4, DictionaryProducts.Values.ElementAt(3));
            Assert.AreEqual(5, DictionaryProducts.Values.ElementAt(4));
            Assert.AreEqual(6, DictionaryProducts.Values.ElementAt(5));
            Assert.AreEqual(7, DictionaryProducts.Values.ElementAt(6));
        }

        [TestMethod]
        public void SortByMostFavoriteCatogories()
        {
            Dictionary<Catogories, int> DictionaryCatogories = new Dictionary<Catogories, int>();
            DictionaryCatogories.Add(Catogories.Action, 1);
            DictionaryCatogories.Add(Catogories.Countries, 5);
            DictionaryCatogories.Add(Catogories.Animals, 3);
            DictionaryCatogories.Add(Catogories.Romance, 4);
            DictionaryCatogories.Add(Catogories.Science_Fiction, 2);
            DictionaryCatogories.Add(Catogories.Brands, 7);
            DictionaryCatogories.Add(Catogories.Old_Schools, 6);
            DictionaryCatogories.Add(Catogories.Landscape, 8);

            favoriteSorter.FavoriteCatogoriesSort(DictionaryCatogories);


            Assert.AreEqual(1, DictionaryCatogories.Values.ElementAt(0));
            Assert.AreEqual(2, DictionaryCatogories.Values.ElementAt(1));
            Assert.AreEqual(3, DictionaryCatogories.Values.ElementAt(2));
            Assert.AreEqual(4, DictionaryCatogories.Values.ElementAt(3));
            Assert.AreEqual(5, DictionaryCatogories.Values.ElementAt(4));
            Assert.AreEqual(6, DictionaryCatogories.Values.ElementAt(5));
            Assert.AreEqual(7, DictionaryCatogories.Values.ElementAt(6));
            Assert.AreEqual(8, DictionaryCatogories.Values.ElementAt(7));

        }
        [TestMethod]
        public void SortByMostFavoriteSeller()
        {
            Dictionary<Seller, int> DictionarySeller = new Dictionary<Seller, int>();
            List<Seller> sellers = usermanager.GetSellers();
            DictionarySeller.Add(sellers[0],2);
            DictionarySeller.Add(sellers[1], 1);

            favoriteSorter.FavoriteSellerSort(DictionarySeller);

            Assert.AreEqual(1, DictionarySeller.Values.ElementAt(0));
            Assert.AreEqual(2, DictionarySeller.Values.ElementAt(1));




        }
    }
}
