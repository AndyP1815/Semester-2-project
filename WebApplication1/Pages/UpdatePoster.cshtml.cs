using classes.Managers;
using classes;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1
{
    public class UpdatePosterModel : PageModel
    {

        [BindProperty]
        public PosterDTO PosterDTO { get; set; }
        [Required]
        public List<SelectListItem> CatogoriesOptions { get; set; }
        private Productmanager productmanager;

        public UpdatePosterModel(IProductRepo productRepo)
        {
            productmanager = new Productmanager(productRepo);
        }
        public void OnGet(string id)
        {
            Product poster = productmanager.GetProductByInt(id);
            this.PosterDTO = new PosterDTO((Poster)poster);
            
           CatogoriesOptions = new List<SelectListItem>();

            foreach (Catogories catogories in Enum.GetValues(typeof(Catogories)))
            {
                CatogoriesOptions.Add(new SelectListItem { Value = catogories.ToString(), Text = catogories.ToString() });
            }
        }
        public IActionResult OnPost(PosterDTO posterDTO,string id)
        {
            try
            {
                if (ModelState.IsValid) { 
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
                        productmanager.UpdateProduct(id, NewPoster);


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
            return Page();
        }
    }
}
