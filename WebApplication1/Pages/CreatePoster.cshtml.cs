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
    public class CreatePosterModel : PageModel
    {
        [BindProperty]
        public PosterDTO PosterDTO { get; set; }
        
     
        [Required]
        public List<SelectListItem> CatogoriesOptions { get; set; }
        private Productmanager productmanager;

        public CreatePosterModel(IProductRepo productRepo)
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
        public IActionResult OnPost(PosterDTO posterDTO)
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
                        foreach (Catogories catogories in posterDTO.Catogories)
                        {
                            catogoriesProduct.Add(catogories);
                        }
                        Poster NewPoster = new Poster(posterDTO.ProductName, posterDTO.Description, Convert.ToDecimal(posterDTO.Price), posterDTO.Url, posterDTO.Catogories, posterDTO.Direction);
                        productmanager.CreateProduct(NewPoster, userId);


                        return RedirectToPage("/Index");
                    }
                }
                else
                {
					ModelState.AddModelError(string.Empty,"Please enter everything in");
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

