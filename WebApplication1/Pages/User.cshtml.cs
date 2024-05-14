using classes;
using classes.Interfaces;
using classes.Managers;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1
{
    public class UserModel : PageModel
    {
        private Usermanager usermanager;
        public List<UserDTO> UsersList;
        private const string PageUrl = "/User";
        public UserDTO User;
        
        public UserModel(IUserRepo userRepo,ICartRepository cartRepository,IProductRepo productRepo)
        {

            this.usermanager = new Usermanager(userRepo, cartRepository, productRepo);
            this.UsersList = new List<UserDTO>();
            foreach (User u in usermanager.Users)
            {
                UsersList.Add(new UserDTO(u));
            }
     
        }
       
        public IActionResult OnGet(int id)
        { 
            foreach (UserDTO user in UsersList)
                if(id == user.ID)
                {
                    User = user;
                }
        
            return Page();
        }
    }
}
