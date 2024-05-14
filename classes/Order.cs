using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace classes
{
   public class Order
    {
        private int orderID;
        private List<Cart_Item> orderProduct;
        private Status status;

        public Order(int orderid, Status status,List<Cart_Item> items)
        {
            this.orderID = orderid;
            this.status = status;
            this.orderProduct = items;
        }
        public Order(int orderid,Status status)
        {
            this.orderID = orderid;
            this.status = status;
        }
        public Order(int orderid)
        {
            this.orderID = orderid;
            this.status = Status.InProgress;
        }

        public override string ToString()
        {
            return $"{orderID.ToString()}-{status.ToString()}";
        }
        public void ChangeStatus(int status)
        {
            if(this.status == Status.Delivered)
            {

            }
            else
            {
                this.status = (Status)status;
            }
            
        }

        public decimal GetPrice()
        {
            decimal totalPrice = 0;
            foreach(Cart_Item item in orderProduct)
            {
                totalPrice += item.Product.Price;
            }
            return totalPrice;
        }

        public int OrderID { get { return orderID; } }
        public List<Cart_Item> Products { get { return orderProduct; } }
        public Status Status { get { return status; } }

    }
}
