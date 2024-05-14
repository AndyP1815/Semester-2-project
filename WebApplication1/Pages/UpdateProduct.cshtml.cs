using classes.Managers;
using classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1
{
    [Authorize]
    public class UpdateProductModel : PageModel
    {
        private Productmanager productmanager;
        
        public UpdateProductModel(IProductRepo productRepo)
        {
            this.productmanager = new Productmanager(productRepo);
        }
        public IActionResult OnGet(string id)
		{
			Product product = productmanager.GetProductByInt(id);

            if(product is Poster)
            {
                return Redirect($"/UpdatePoster?id={id}");
            }
            if (product is Books)
            {
                return RedirectToPage("/UpdateBooks", new { id = id });
            }
            if (product is Figures)
            {
				return RedirectToPage($"/UpdateFigure", new { id = id });
			}
            if(product is Clothing)
            {
				return Redirect($"/UpdateClothing?id={id}");
			}
            return Page();
		}
    }
}
