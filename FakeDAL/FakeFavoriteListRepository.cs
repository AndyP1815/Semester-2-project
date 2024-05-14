using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes;
using classes.Interfaces;

namespace FakeDAL
{
    public class FakeFavoriteListRepository : IFavoritelistRepository
    {
        public void AddProduct(int id, string product_id)
        {
            throw new NotImplementedException();
        }

        public void CreateFavoritelist(int UserId, string name)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Catogories, int> GetFavoriteCatogories()
        {
            throw new NotImplementedException();
        }

        public List<FavoriteList> GetFavoritelist()
        {
            throw new NotImplementedException();
        }

        public FavoriteList GetFavoritelistById(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> GetFavoriteProductCount()
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, int> GetFavoriteSeller()
        {
            throw new NotImplementedException();
        }

        public List<string> GetFavortieListProducts(int favortielistid)
        {
            throw new NotImplementedException();
        }

        public List<FavoriteList> GetListFavoritelistById(int User_id)
        {
            throw new NotImplementedException();
        }

        public void ProductIsRemoved(string product_id)
        {
            throw new NotImplementedException();
        }

        public void RemoveFavoritelist(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(int id, string product_id)
        {
            throw new NotImplementedException();
        }

        public void UpdateName(string name, int id)
        {
            throw new NotImplementedException();
        }
    }
}
