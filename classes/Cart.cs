using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace classes
{
    namespace classes
    {
		public class Cart
		{
			private List<Cart_Item> cartProduct = new List<Cart_Item>();
			private int cartId;

			public Cart(int cartId)
			{
				this.cartId = cartId;
			}

			public Cart(int id, List<Cart_Item> products)
			{
				this.cartId = id;
				this.cartProduct = products;
			}

			public void AddProduct(Cart_Item p)
			{
				cartProduct.Add(p);
			}

			public void RemoveProduct(Cart_Item p)
			{
				cartProduct.Remove(p);
			}

			public int CartID => cartId;

			public List<Cart_Item> CartProducts => cartProduct;
		}
	}
}
