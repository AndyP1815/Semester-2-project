using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class Cart_Item
    {
        private Product product;
        private int quantity;
        private int id;

        public Cart_Item(Product product, int quantity, int id)
        {
            this.product = product;
            this.quantity = quantity;
            this.id = id;   
        }
        public Cart_Item(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
            
        }
        public string ExtraInfo()
        {
            return $"product: {product.ProductName} \n" +
                $"Quantity: {quantity}\n" +
                $"Extra information: {product.ExtraProductInfo()}";
        }
        public void QuantityUp(int Times)
        {
            quantity = quantity + Times;
        }
        public void QuantityDown(int Times)
        {
            quantity = quantity - Times;
        }

        public override string ToString()
        {
            return $"Quantity : {quantity.ToString()} + Name:{product.ProductName}";
        }
        public Product Product { get { return product; } }
        public int Quantity { get { return quantity;} }
        public int Id { get { return id; } }
    }
}
