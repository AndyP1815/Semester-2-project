using classes;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using classes.Managers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1
{
    [Authorize]
    public class CreateFigureModel : PageModel
    {
        [BindProperty]
        public FiguresDTO FiguresDTO { get; set; }
        public List<SelectListItem> CatogoriesOptions { get; set; }
        private Productmanager productmanager;
       public CreateFigureModel(IProductRepo productRepo)
        {
            this.productmanager = new Productmanager(productRepo);
        }
        public void OnGet()
        {
            CatogoriesOptions = new List<SelectListItem>();

            foreach (Catogories catogories in Enum.GetValues(typeof(Catogories)))
            {
                CatogoriesOptions.Add(new SelectListItem { Value = catogories.ToString(), Text = catogories.ToString() });
            }
        }
        public IActionResult OnPost(FiguresDTO figuresDTO)
        {
            try {
                if (ModelState.IsValid)
                {
                    string idValue = User.FindFirstValue("id");
                    int userId;

                    if (int.TryParse(idValue, out userId))
                    {
                        List<Catogories> catogoriesProduct = new List<Catogories>();
                        foreach (Catogories catogories in figuresDTO.Catogories)
                        {
                            catogoriesProduct.Add(catogories);
                        }
                        Figures NewFigure = new Figures(figuresDTO.ProductName, figuresDTO.Description, Convert.ToDecimal(figuresDTO.Price), figuresDTO.Url, figuresDTO.Catogories, figuresDTO.Dimensions);
                        productmanager.CreateProduct(NewFigure, userId);

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
            return Page();
        }
    }
}

