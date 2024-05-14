using classes.Interfaces;
using classes;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using classes.Managers;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1
{
	[Authorize]
	public class SellerProductsModel : PageModel
    {
		private Usermanager usermanager;
		public UserDTO UserDTO;
		public List<ProductDTO> Products = new List<ProductDTO>();
		private deleteProduct deleteProduct;
		

		public SellerProductsModel(IUserRepo userRepo, ICartRepository cartRepository, IProductRepo productRepo,IOrderRepository orderRepository,IFavoritelistRepository favoritelistRepository)
		{
			this.usermanager = new Usermanager(userRepo, cartRepository, productRepo);
			this.deleteProduct = new deleteProduct(productRepo,favoritelistRepository,orderRepository,cartRepository,userRepo);
		}

		public IActionResult OnGet(int? id)
		{
			try
			{
				int cookieID = Int32.Parse(User.FindFirstValue("id"));
				int userID = id ?? cookieID;
				User u = usermanager.GetUserById(userID);
				if (u != null)
				{
					UserDTO = new UserDTO(u);
					foreach (Product p in ((Seller)u).Products)
					{
						this.Products.Add(new ProductDTO(p));
					}
					return Page();
				}
				else
				{
					return RedirectToPage("/Index");

				}
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while processing the request.";
                return RedirectToPage("/Error");
            }
        }
		public IActionResult OnPostDelete(string id)
		{
			try
			{
				deleteProduct.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while processing the request.";
                return RedirectToPage("/Error");
            }

            return RedirectToPage("/index");
		}
	}
}
