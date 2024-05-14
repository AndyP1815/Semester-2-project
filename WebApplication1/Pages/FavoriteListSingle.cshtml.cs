using classes;
using classes.Interfaces;
using classes.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1
{
    public class FavoriteListSingleModel : PageModel
    {
        private FavoriteListManager FavoriteListManager;
        public FavoriteListDTO FavoriteListDTO;
        [BindProperty]
        public string ProductId { get; set; }

        public FavoriteListSingleModel(IFavoritelistRepository favoritelistRepository, IUserRepo userRepo, IProductRepo productRepo)
        {
            this.FavoriteListManager = new FavoriteListManager(favoritelistRepository, productRepo, userRepo);
        }
        public void OnGet(int id)
        {
            var list = FavoriteListManager.GetFavoriteListById(id);
            var productList = new List<ProductDTO>();
            foreach (var item in list.GetFavoriteProducts())
            {
                productList.Add(new ProductDTO(item));
            }
            this.FavoriteListDTO = new FavoriteListDTO(list, productList);

        }
        public IActionResult OnPost(FavoriteListDTO favoriteListDTO, int id)
        {
            try
            {
                FavoriteListManager.UpdateFavoriteList(favoriteListDTO.Name, id);
                OnGet(id);
                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }
        }
        public IActionResult OnPostDelete(int id, string ProductId)
        {
            try
            {


                FavoriteListManager.RemoveProduct(id, ProductId);
                OnGet(id);
                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
