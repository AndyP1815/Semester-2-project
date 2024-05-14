using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes.classes;
using classes.Interfaces;


namespace classes.Managers
{
    public class FavoriteListManager
    {
        private IFavoritelistRepository favoritelistRepository;
        private IProductRepo ProductRepository;
        private IUserRepo UserRepo;
        public FavoriteListManager(IFavoritelistRepository FavoritelistRepository, IProductRepo productRepository, IUserRepo userRepo)
        {
            this.favoritelistRepository = FavoritelistRepository;
            ProductRepository = productRepository;
            UserRepo = userRepo;
        }
        public void CreateFavoriteList(int userId, string name)
        {
            try
            {
                favoritelistRepository.CreateFavoritelist(userId, name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public void RemoveFavoritelist(int id)
        {
            try
            {
                favoritelistRepository.RemoveFavoritelist(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public void AddProduct(int id, string Product_id)
        {
            try
            {
                favoritelistRepository.AddProduct(id, Product_id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public void RemoveProduct(int id, string Product_id)
        {
            try
            {
                favoritelistRepository.RemoveProduct(id, Product_id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public List<FavoriteList> GetFavoriteList()
        {
            try
            {
                List<FavoriteList> favoriteLists = new List<FavoriteList>();
                foreach (FavoriteList favoriteList in favoritelistRepository.GetFavoritelist())
                {
                    foreach (string id in favoritelistRepository.GetFavortieListProducts(favoriteList.GetFavoriteListid()))
                    {
                        favoriteList.AddProduct(ProductRepository.GetProductByInt(id));
                    }
                    favoriteLists.Add(favoriteList);
                }
                return favoriteLists;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public List<FavoriteList> favoriteListId(int User_id)
        {
            try
            {
                List<FavoriteList> ReturnList = new List<FavoriteList>();
                foreach (FavoriteList favoriteList in favoritelistRepository.GetListFavoritelistById(User_id))
                {
                    foreach (string id in favoritelistRepository.GetFavortieListProducts(favoriteList.GetFavoriteListid()))
                    {
                        favoriteList.AddProduct(ProductRepository.GetProductByInt(id));
                    }
                    ReturnList.Add(favoriteList);
                }
                return ReturnList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }

        }

        public Dictionary<Product, int> FavoriteProductCount()
        {
            try
            {
                Dictionary<Product, int> productCount = new Dictionary<Product, int>();
                Dictionary<string, int> favoriteProductCount = favoritelistRepository.GetFavoriteProductCount();
                foreach (string id in favoriteProductCount.Keys)
                {
                    Product product = ProductRepository.GetProductByInt(id);
                    int count = favoriteProductCount[id];
                    productCount.Add(product, count);
                }
                return productCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public Dictionary<Catogories, int> FavoriteCatogories()
        {
            try
            {
                return favoritelistRepository.GetFavoriteCatogories();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public Dictionary<Seller, int> FavoriteSeller()
        {
            try
            {
                Dictionary<Seller, int> productCount = new Dictionary<Seller, int>();
                Dictionary<int, int> favoriteCatogoriesCount = favoritelistRepository.GetFavoriteSeller();
                foreach (int id in favoriteCatogoriesCount.Keys)
                {
                    Seller seller = (Seller)UserRepo.GetUserByid(id);
                    int count = favoriteCatogoriesCount[id];
                    productCount.Add(seller, count);
                }
                return productCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public void ProductIsRemoved(string id)
        {
            try
            {
                favoritelistRepository.ProductIsRemoved(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public FavoriteList GetFavoriteListById(int id)
        {
            try
            {
                var list = favoritelistRepository.GetFavoritelistById(id);

                foreach (string product in favoritelistRepository.GetFavortieListProducts(list.GetFavoriteListid()))
                {
                    list.AddProduct(ProductRepository.GetProductByInt(product));
                }
                return list;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        public void UpdateFavoriteList(string name, int id)
        {
            try
            {
                favoritelistRepository.UpdateName(name, id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        public void ProductAddManager(string productId, Dictionary<int, bool> SelectedList, List<FavoriteList> OriginalList)
        {

            foreach (var i in SelectedList)
            {
                if (i.Value)
                {
                    foreach (FavoriteList favorite in OriginalList)
                    {
                        if (i.Key == favorite.GetFavoriteListid())
                        {
                            if (favorite.GetFavoriteProducts().Any(p => p.ID == productId))
                            {

                            }
                            else
                            {

                                AddProduct(i.Key, productId);

                            }
                        }

                    }
                }
            }

        }
    }
}
