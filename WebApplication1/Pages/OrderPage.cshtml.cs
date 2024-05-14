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
	public class OrderPageModel : PageModel
    {
		private Usermanager usermanager;
		private OrderManager orderManager;
		public UserDTO UserDTO;
		public List<OrderDTO> OrderDTOs = new List<OrderDTO>();
		public bool IsSeller;

		public OrderPageModel(IUserRepo userRepo, ICartRepository cartRepository, IProductRepo productRepo,IOrderRepository orderRepository)
		{
			this.usermanager = new Usermanager(userRepo, cartRepository, productRepo);
			this.orderManager = new OrderManager(orderRepository,productRepo);
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
					if (u is Seller)
					{
						IsSeller = true;
					}
					else if (u is User)
					{
						IsSeller = false;
					}
					UserDTO = new UserDTO(u);
					var orders = orderManager.GetOrderByUserId(userID);
					foreach(Order o in orders)
					{
						OrderDTOs.Add(new OrderDTO(o));
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
	}
}
