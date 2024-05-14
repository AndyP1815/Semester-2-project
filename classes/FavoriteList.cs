using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace classes
{
    public class FavoriteList
    {
        List<Product> FavoriteProducts = new List<Product>();
        private int favoriteListid;
        private string Name;

        public FavoriteList(int id,string Name)
        {
            this.Name = Name;
            this.favoriteListid = id;
        }
        public FavoriteList(List<Product> favoriteProducts, int favoriteListid, string name)
        {
            FavoriteProducts = favoriteProducts;
            this.favoriteListid = favoriteListid;
            Name = name;
        }

        public void AddProduct(Product p)
        {
            FavoriteProducts.Add(p);
        }
        public void RemoveProduct(Product p)
        {
            FavoriteProducts.Remove(p);
        }
        public override string ToString()
        {
            return Name;
        }
        public List<Product> GetFavoriteProducts() {  return FavoriteProducts; }
        public int GetFavoriteListid() {  return favoriteListid; }
        public string GetName() { return Name; }    
    }
}
