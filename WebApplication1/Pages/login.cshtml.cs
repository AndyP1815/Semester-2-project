using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Cryptography;
using DAL;
using classes.Managers;
using classes.Interfaces;
using classes;

namespace WebApplication1
{

    public class loginModel : PageModel
	{

		[BindProperty]
		public UserLoginDTO UserLogin { get; set; }
		private Usermanager usermanager;
		

		public loginModel(IUserRepo userRepo, ICartRepository cartRepository, IProductRepo productRepo)
		{
		
			this.usermanager = new Usermanager(userRepo, cartRepository, productRepo);
			
		}
		public void OnGet()
		{
		
		}
		public IActionResult OnPost(UserLoginDTO UserLogin)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var user = usermanager.VerifyPassword(UserLogin.Password, UserLogin.UserName);

					if (user != null)
                    {

                        //HttpContext.Session.SetString("Username", UserLogin.Username);

                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, UserLogin.UserName));
						if(usermanager.GetUserByName(UserLogin.UserName) == null)
						{
							ModelState.AddModelError(string.Empty, "Invalid username or password.");
						}
					

                        claims.Add(new Claim("id", user.ID.ToString()));
                        ClaimsIdentity cid = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        HttpContext.SignInAsync(new ClaimsPrincipal(cid));
                        return RedirectToPage("/Index");   
                    }
					else
					{
						ModelState.AddModelError(string.Empty, "Invalid username or password.");
					
				}
                }
				catch(NullReferenceException ex)
				{
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                }
				catch (Exception ex)
				{
					ModelState.AddModelError(string.Empty, "There is a error: " + ex.Message);
                }
                
            }
		return Page();
			
		}
	}
}