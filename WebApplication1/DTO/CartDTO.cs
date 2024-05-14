using System.ComponentModel.DataAnnotations;
using classes;

namespace WebApplication1
{
    public class CartDTO
	{
	
		public Product product;
		public int quantity;
		public int id;
		public string ExtraInfo;

		public CartDTO(Cart_Item cart_Item)
		{
			this.product = cart_Item.Product;
			this.quantity = cart_Item.Quantity;
			this.id = cart_Item.Id;
			this.ExtraInfo = cart_Item.ExtraInfo();
		}


	}
}
