using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes.classes;

namespace classes.Interfaces
{
    public interface ICartRepository
    {
        void UpdateCart(int id,int quantity);
        void CreateCart(int UserId);
        List<string> GetProductIdsInCart(int id);
        List<Cart_Item>GetProductsInCart(List<Product> products,int id);
        void DeleteCart(int id);
        string GetProductSize(int Cart_ItemId);
        bool GetProductBool(int Cart_ItemId);
        int GetCartIdByUserId(int user_id);
        void AddProductToCart(Cart_Item product , int user_id);
        void RemoveProductFromCart(int Cart_Item_id);
        void ProductIsRemoved(string product_id);
    }
}
