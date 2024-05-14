using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes.classes;
using classes.Interfaces;

namespace classes.Managers
{
    public class OrderManager
    {
        private IOrderRepository orderRepository;
        private IProductRepo productRepo;
        private ProductReworker productReworker;

        public OrderManager(IOrderRepository orderRepository,IProductRepo productRepo)
        {
            this.orderRepository = orderRepository;
            this.productRepo = productRepo;
            this.productReworker = new ProductReworker();
        }
       public List<Order> GetAllOrders()
        {
            try
            {
                List<Order> orders = new List<Order>();
                var ids = orderRepository.GetOrderIds();
                foreach (var Ids in ids)
                {
                    foreach (var Order in GetOrderByUserId(Ids.Key))
                    {
                        orders.Add(Order);
                    }
                }
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public Dictionary<Product, decimal> ProductRevenue()
        {
            try {
                var Productrevenue = new Dictionary<Product, decimal>();
                var items = orderRepository.GetProductSold();

                foreach (var item in items)
                {
                    Productrevenue.Add(productRepo.GetProductByInt(item.Key), item.Value);
                }

                return Productrevenue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }

        public void CreateOrder(Cart c, int userId)
        {
            try
            {
                orderRepository.CreateOrder(c, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }

        public void RemoveOrder(int id)
        {
            try
            {
                orderRepository.RemoveOrder(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public void UpdateOrder(int id,Status status)
        {
            try
            {
                orderRepository.UpdateOrder(id, status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
       public List<Order> GetOrderByUserId(int user_id)
        {
            try
            {
                var orders = new List<Order>();

                var orderIds = orderRepository.GetOrderIds().Where(item => item.Value == user_id).Select(item => item.Key);

                foreach (var orderId in orderIds)
                {
                    var productIds = orderRepository.GetProductIdsInOrder(orderId, user_id);
                    var products = productIds.Select(id => productRepo.GetProductByInt(id)).ToList();

                    var cartItems = orderRepository.GetProductsInOrder(products, orderId, user_id);

                    var cartReturnItems = new List<Cart_Item>();
                    foreach (var item in cartItems)
                    {
                        var orderBool = orderRepository.GetOrderBool(item.Id);
                        var orderSize = orderRepository.GetOrderSize(item.Id);
                        var returnProduct = productReworker.MakeProduct(item.Product, orderBool, orderSize);

                        cartReturnItems.Add(new Cart_Item(returnProduct, item.Quantity, item.Id));
                    }

                    var order = orderRepository.GetOrderByOrderId(orderId);
                    orders.Add(new Order(order.OrderID, order.Status, cartReturnItems));
                }
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public void ProductIsremoved(string id)
        {
            try
            {
                orderRepository.ProductIsRemoved(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public Order GetOrderByOrderId(int OrderId, int UserId)
        {
			var productIds = orderRepository.GetProductIdsInOrder(OrderId, UserId);
			var products = productIds.Select(id => productRepo.GetProductByInt(id)).ToList();

			var cartItems = orderRepository.GetProductsInOrder(products, OrderId,UserId);

			var cartReturnItems = new List<Cart_Item>();
			foreach (var item in cartItems)
			{
				var orderBool = orderRepository.GetOrderBool(item.Id);
				var orderSize = orderRepository.GetOrderSize(item.Id);
				var returnProduct = productReworker.MakeProduct(item.Product, orderBool, orderSize);

				cartReturnItems.Add(new Cart_Item(returnProduct, item.Quantity, item.Id));
			}

			var order = orderRepository.GetOrderByOrderId(OrderId);
            return new Order(order.OrderID, order.Status, cartReturnItems);
		}

    }

}
