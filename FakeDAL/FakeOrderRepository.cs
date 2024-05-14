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
    public class FakeOrderRepository : IOrderRepository
    {
        public void CreateOrder(Cart cart, int UserId)
        {
            throw new NotImplementedException();
        }

        public bool GetOrderBool(int Item_id)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByOrderId(int Order_id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, int> GetOrderIds()
        {
            throw new NotImplementedException();
        }

        public string GetOrderSize(int Item_id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetProductIdsInOrder(int User_id, int Order_id)
        {
            throw new NotImplementedException();
        }

        public List<Cart_Item> GetProductsInOrder(List<Product> products, int id, int orderId)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, decimal> GetProductSold()
        {
            throw new NotImplementedException();
        }

        public void ProductIsRemoved(string product_id)
        {
            throw new NotImplementedException();
        }

        public void RemoveOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(int id, Status status)
        {
            throw new NotImplementedException();
        }
    }
}
