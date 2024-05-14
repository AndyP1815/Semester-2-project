using System.Security.Claims;
using classes;
using classes.Interfaces;
using classes.Managers;
using DAL;
using classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using classes.classes;

namespace WebApplication1
{
    public class CartModel : PageModel
    {
        private Usermanager usermanager;
        private OrderManager ordermanager;
        private CartManager cartmanager;
        private User user;
        public List<CartDTO> CartProduct = new List<CartDTO>();
        public decimal TotalPrice;

        public CartModel(IUserRepo userRepo, ICartRepository cartRepository, IProductRepo productRepo,IOrderRepository orderRepository) 
        {
            this.ordermanager = new OrderManager(orderRepository,productRepo);
            this.usermanager = new Usermanager(userRepo, cartRepository, productRepo);
            this.cartmanager = new CartManager(cartRepository,productRepo);
           
        }
        public IActionResult OnGet()
		{
            try
            {
				TotalPrice = 0;
				int userId = int.Parse(User.FindFirstValue("id"));
                this.user = usermanager.GetUserById(userId);
                foreach (var cart in user.Cart.CartProducts)
                {
                    TotalPrice += cart.Product.Price * cart.Quantity;
                    CartProduct.Add(new CartDTO(cart));
                }
                
                return Page();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while processing the request.";
                return RedirectToPage("/Error");
            }

        }
        public IActionResult OnPostDelete(int id)
        {
			
            cartmanager.RemoveProductToCart(id);
            return RedirectToPage("/cart");
		}
        public IActionResult OnPostCheckOut()
        {
            try
            {
                int userId = int.Parse(User.FindFirstValue("id"));
                this.user = usermanager.GetUserById(userId);
                if (user.Cart.CartProducts.Count == 0)
                {
                    return Redirect("index");
                }
                else
                {
                    ordermanager.CreateOrder(user.Cart, userId);
                    cartmanager.DeleteCart(user.Cart.CartID);
                    return Redirect("/Purchase");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while processing the request.";
                return RedirectToPage("/Error");
            }
        }

    }
}
