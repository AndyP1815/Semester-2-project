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
    public class FavoriteSorter
    {
        
        private SortByProductCount sortByProductMostFavorite;
        private SortByMostFavoriteCategory sortByMostFavoriteCategory;
        private SortByProductMostFavoriteSeller sortByProductMostFavoriteSeller;

        public FavoriteSorter()
        {
            sortByProductMostFavorite = new SortByProductCount();
            sortByMostFavoriteCategory = new SortByMostFavoriteCategory();
            sortByProductMostFavoriteSeller = new SortByProductMostFavoriteSeller();
        }

   
        public void FavoriteProductSort(Dictionary<Product, int> productCount)
        {
            try
            {
                List<KeyValuePair<Product, int>> sortedList = new List<KeyValuePair<Product, int>>(productCount);
                sortedList.Sort(sortByProductMostFavorite);
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
    
       public void FavoriteCatogoriesSort(Dictionary<Catogories, int> productCount)
        {
            try
            {
                List<KeyValuePair<Catogories, int>> sortedList = new List<KeyValuePair<Catogories, int>>(productCount);
                sortedList.Sort(sortByMostFavoriteCategory);

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
        
            public void FavoriteSellerSort(Dictionary<Seller, int> productCount)
        {
            try
            {
                List<KeyValuePair<Seller, int>> sortedList = new List<KeyValuePair<Seller, int>>(productCount);
                sortedList.Sort(sortByProductMostFavoriteSeller);
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
    }
}
