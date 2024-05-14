using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes.classes;

namespace classes.Interfaces
{
    public interface IOrderRepository
    {

        Dictionary<int,int> GetOrderIds();
        void UpdateOrder(int id,Status status);
        void CreateOrder(Cart cart, int UserId);
        Order GetOrderByOrderId(int Order_id);
        List<Cart_Item> GetProductsInOrder(List<Product> products, int id,int orderId);
        List<string> GetProductIdsInOrder(int User_id,int Order_id);
        string GetOrderSize(int Item_id);
        bool GetOrderBool(int Item_id);
        void RemoveOrder(int id);
        Dictionary<string, decimal> GetProductSold();
		void ProductIsRemoved(string product_id);

	}
}
