using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes;
using classes.classes;
using classes.Interfaces;

namespace FakeDAL
{
    public class FakeCartRepositroy : ICartRepository
    {
        List<Cart> carts = new List<Cart>();
        public FakeCartRepositroy() 
        {
            carts.Add(new Cart(1));
            carts.Add(new Cart(2));

        }
        public void AddProductToCart(Cart_Item product, int user_id)
        {
            throw new NotImplementedException();
        }

        public void CreateCart(int UserId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCart(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCartIdByUserId(int user_id)
        {
           foreach (Cart cart in carts)
                if(cart.CartID == user_id)
                {
                    return cart.CartID;
                }
           return 0;
        }

        public bool GetProductBool(int Cart_ItemId)
        {
            return false;
        }

        public List<string> GetProductIdsInCart(int id)
        {
            List<string> list = new List<string>();
            return list;
        }

    

        public List<Cart_Item> GetProductsInCart(List<Product> products, int id)
        {
            List<Cart_Item> list = new List<Cart_Item>();
            return list;
        }

        public string GetProductSize(int Cart_ItemId)
        {
            return "S";
        }

        public void ProductIsRemoved(string product_id)
        {
            throw new NotImplementedException();
        }

        public void RemoveProductFromCart(int Cart_Item_id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCart(int id, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
