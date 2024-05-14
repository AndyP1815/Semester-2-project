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
    public class FavoriteListModel : PageModel
    {
        private Usermanager usermanager;
        private FavoriteListManager favoritemanager;
        public List<FavoriteListDTO> favoriteLists = new List<FavoriteListDTO>();
        [BindProperty]
        public UserDTO UserDTO { get; set; }
        public bool IsSeller;
        [BindProperty]
        public string Description { get; set; }

        public FavoriteListDTO favoriteListDTO;


        public FavoriteListModel(IUserRepo userRepo,IProductRepo productRepo,ICartRepository cartRepository,IFavoritelistRepository favoritelistRepository) 
        {
            usermanager = new Usermanager(userRepo,cartRepository,productRepo);
            favoritemanager = new FavoriteListManager(favoritelistRepository, productRepo,userRepo);
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
                    int Id = Convert.ToInt32(User.FindFirstValue("id"));
                    List<FavoriteList> UserList = favoritemanager.favoriteListId(Id);
                    foreach (FavoriteList list in UserList)
                    {
                        List<ProductDTO> productDTOs = new List<ProductDTO>();
                        foreach (Product p in list.GetFavoriteProducts())
                        {
                            productDTOs.Add(new ProductDTO(p));
                        }
                        favoriteLists.Add(new FavoriteListDTO(list,productDTOs));
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


        public IActionResult OnPost(FavoriteListDTO favoriteListDTO)
        {
            try
            {
                int id = Convert.ToInt32(User.FindFirstValue("id"));
                favoritemanager.CreateFavoriteList(id, favoriteListDTO.Name);
                return RedirectToPage("/FavoriteList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while processing the request.";
                return RedirectToPage("/Error");
            }

        }
    }
}
