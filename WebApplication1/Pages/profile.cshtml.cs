using System.Security.Claims;
using classes;
using classes.Interfaces;
using classes.Managers;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1
{
    [Authorize]

    public class ProfileModel : PageModel
    {
        [BindProperty]
		public UserDTO UserDTO { get; set; }
		private Usermanager usermanager;
       
        public bool IsSeller;
        [BindProperty]
        public string Description { get; set; }

        public ProfileModel(IUserRepo userRepo,ICartRepository cartRepository,IProductRepo productRepo)
        {
            this.usermanager = new Usermanager(userRepo,cartRepository,productRepo);
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
                        this.Description = ((Seller)u).Description;

                    }
                    else if (u is User)
                    {
                        IsSeller = false;
                    }

                    UserDTO = new UserDTO(u);
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
        public IActionResult OnPost(UserDTO userDTO,string description,int id)
        {
            try
            {
                User user = usermanager.GetUserById(id);
                if (user is Seller)
                {
                    Seller seller = new Seller(userDTO.Username, userDTO.Password, userDTO.Adress, userDTO.salt, id, description);
                    usermanager.UpdateProduct(id, seller);
                    return RedirectToPage("/Index");
                }
                else
                {
                    User u = new User(userDTO.Username, userDTO.Password, userDTO.Adress, userDTO.salt, id);
                    usermanager.UpdateProduct(id, u);
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