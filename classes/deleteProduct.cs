using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes.Interfaces;
using classes.Managers;

namespace classes
{
	public class deleteProduct
	{
		private Productmanager productmanager;
		private FavoriteListManager favoritelistmanager;
		private CartManager cartManager;
		private OrderManager orderManager;


		public deleteProduct(IProductRepo productRepo,IFavoritelistRepository favoritelistRepository,IOrderRepository orderRepository,ICartRepository cartRepository,IUserRepo userRepo) 
		{
			this.productmanager = new Productmanager(productRepo);
			this.favoritelistmanager = new FavoriteListManager(favoritelistRepository,productRepo,userRepo);
			this.orderManager = new OrderManager(orderRepository,productRepo);
			this.cartManager = new CartManager(cartRepository,productRepo);
		}
		public void DeleteProduct(string productId)
		{
			try
			{
				favoritelistmanager.ProductIsRemoved(productId);
				cartManager.ProductIsRemoved(productId);
				orderManager.ProductIsremoved(productId);
				productmanager.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }

	}
}
