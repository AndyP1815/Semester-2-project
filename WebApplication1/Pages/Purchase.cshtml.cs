using System.Security.Claims;
using classes;
using classes.Interfaces;
using classes.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1
{
    public class PurchaseModel : PageModel
    {
        public UserDTO userDTO;
        private Usermanager usermanager;

        public PurchaseModel(IUserRepo userRepo,ICartRepository cartRepository,IProductRepo productRepo)
        {
            userDTO = new UserDTO();
            usermanager = new Usermanager(userRepo,cartRepository,productRepo);
        }
        public void OnGet()
        {
            int userId = int.Parse(User.FindFirstValue("id"));
            userDTO = new UserDTO(usermanager.GetUserById(userId));
        }
    }
}
