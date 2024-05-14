using classes;

namespace WebApplication1
{
    public class OrderDTO
{
        public int orderID;
        public List<Cart_Item> OrderProduct;
        public Status status;


        public OrderDTO(Order order) 
        {
            this.orderID = order.OrderID;
            this.OrderProduct = order.Products;
            this.status = order.Status; 
        }
        

    }
}
