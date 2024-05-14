using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes.classes;

namespace classes.Interfaces
{
    public interface IFavoritelistRepository
    {
        List<FavoriteList> GetFavoritelist();
        void AddProduct(int id,string product_id);
        void RemoveProduct(int id, string product_id);
        void CreateFavoritelist( int UserId,string name);
        List<string> GetFavortieListProducts(int favortielistid);
        List<FavoriteList> GetListFavoritelistById(int User_id);
        FavoriteList GetFavoritelistById(int id);
        void RemoveFavoritelist(int id);
        Dictionary<string,int> GetFavoriteProductCount();
        Dictionary<Catogories, int> GetFavoriteCatogories();
        Dictionary<int, int> GetFavoriteSeller();
		void ProductIsRemoved(string product_id);
        void UpdateName(string name,int id);
	}
}
