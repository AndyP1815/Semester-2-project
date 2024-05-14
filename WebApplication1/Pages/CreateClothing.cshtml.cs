using System.Security.Claims;
using classes;
using classes.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1
{
    [Authorize]
    public class CreateClothingModel : PageModel
    {
        [BindProperty]
       public ClothingDTO clothingDTO { get; set; }
        public List<SelectListItem> CatogoriesOptions { get; set; }
        private Productmanager productmanager;
        public CreateClothingModel(IProductRepo productRepo)
        {
            productmanager = new Productmanager(productRepo);
        }

        public void OnGet()
        {
            CatogoriesOptions = new List<SelectListItem>();

            foreach (Catogories catogories in Enum.GetValues(typeof(Catogories)))
            {
                CatogoriesOptions.Add(new SelectListItem { Value = catogories.ToString(), Text = catogories.ToString() });
            }
        }
        public IActionResult OnPost(ClothingDTO clothingDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string idValue = User.FindFirstValue("id");
                    int userId;

                    if (int.TryParse(idValue, out userId))
                    {
                        List<Catogories> catogoriesProduct = new List<Catogories>();
                        foreach (Catogories catogories in clothingDTO.Catogories)
                        {
                            catogoriesProduct.Add(catogories);
                        }
                        Clothing newClothing = new Clothing(clothingDTO.ProductName, clothingDTO.Description, Convert.ToDecimal(clothingDTO.Price), clothingDTO.Url, catogoriesProduct);
                        productmanager.CreateProduct(newClothing, userId);

                        return RedirectToPage("/Index");
                    }
                }
                else
                {
					ModelState.AddModelError(string.Empty, "Please enter everything in");
					OnGet();
				}
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while processing the request.";
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Index");

        }
    }
}
