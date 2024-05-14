using System.Security.Claims;
using classes;
using classes.Interfaces;
using classes.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1 
{
    [Authorize]
    public class OrderSinglePageModel : PageModel
    {
        private OrderManager orderManager;
        public OrderDTO orderDTO;
        public decimal TotalPrice;

        public OrderSinglePageModel(IOrderRepository orderRepository,IProductRepo productRepo)
        {
            orderManager = new OrderManager(orderRepository, productRepo);
        }
        public IActionResult OnGet(int id)
        {
            try
            {
                TotalPrice = 0;
                int UserId = Int32.Parse(User.FindFirstValue("id"));
                var order = orderManager.GetOrderByOrderId(id, UserId);
                orderDTO = new OrderDTO(order);
                foreach(var item in orderDTO.OrderProduct)
                {
                    TotalPrice += item.Product.CalculatePrice() * item.Quantity; 
                }
                return Page();
			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = "An error occurred while processing the request.";
				return RedirectToPage("/Error");
			}
		}
    }
}
