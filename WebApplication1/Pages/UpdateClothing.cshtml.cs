using classes.Managers;
using classes;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1
{
    public class UpdateClothingModel : PageModel
    {
        [BindProperty]
        public ClothingDTO clothingDTO { get; set; }
        public List<SelectListItem> CatogoriesOptions { get; set; }
        private Productmanager productmanager;
        public UpdateClothingModel(IProductRepo productRepo)
        {
            productmanager = new Productmanager(productRepo);
        }

        public void OnGet(string id)
        {
            Product product = productmanager.GetProductByInt(id);
            clothingDTO = new ClothingDTO((Clothing)product);

            CatogoriesOptions = new List<SelectListItem>();

            foreach (Catogories catogories in Enum.GetValues(typeof(Catogories)))
            {
                CatogoriesOptions.Add(new SelectListItem { Value = catogories.ToString(), Text = catogories.ToString() });
            }
        }
        public IActionResult OnPost(ClothingDTO clothingDTO,string id)
        {
            try
            {
                if (ModelState.IsValid) { 
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
                        productmanager.UpdateProduct(id, newClothing);

                        return RedirectToPage("/Index");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Please enter everything in");
                    OnGet(id);
                    return Page();
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
