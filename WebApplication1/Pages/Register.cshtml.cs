using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using classes;
using classes.Interfaces;
using classes.Managers;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WebApplication1
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
	

		[BindProperty]
        public UserDTO UserRegister { get; set; }
        private Usermanager usermanager;
        private CartManager cartManager;
        [Required]
        public bool Bool;


        public RegisterModel(IUserRepo userRepo,ICartRepository cartRepository,IProductRepo productRepo)
        {
            this.usermanager = new Usermanager(userRepo, cartRepository, productRepo);
            this.cartManager = new CartManager(cartRepository,productRepo);
        }

		const int keySize = 64;
		const int iterations = 350000;
		HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        
        public void OnGet()
        {
            
        }
        public IActionResult OnPost(UserDTO UserRegister, bool myboolean)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hash = usermanager.HashPassword(UserRegister.Password, out var salt);
                    int id = usermanager.GetUserID();
                    User user;
                    if (myboolean == true)
                    {
                        user = new User(UserRegister.Username, hash, UserRegister.Adress, salt, id);

                    }
                    else
                    {
                        user = new Seller(UserRegister.Username, hash, UserRegister.Adress, salt, id);
                    }
                    usermanager.CreateUser(user);
                    cartManager.CreateCart(id);

                    return new RedirectToPageResult("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Please enter everything in");
                    return Page();
                }
            }
            catch (Exception ex) 
            {
                TempData["ErrorMessage"] = "An error occurred while processing the request.";
                return RedirectToPage("/Error");

            }
            return Page();
            
        }

    }
}
