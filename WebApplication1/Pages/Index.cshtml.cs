using classes;
using classes.Managers;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1
{
    public class IndexModel : PageModel
    {
        private Productmanager productmanager;
        public List<ProductDTO> productDTOs;
        private ProductDisplay productDisplay = new ProductDisplay();

        private ProductRepo productRepo = new ProductRepo();
    public IndexModel()
        {
            this.productDTOs = new List<ProductDTO>();
            this.productmanager = new Productmanager(productRepo);
        }
    

        public IActionResult OnGet()
        {
            try
            {

                foreach (int i in productDisplay.GetNumber(8))
                {
                    productDTOs.Add(new ProductDTO(productmanager.Products[i]));
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