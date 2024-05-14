using classes.Managers;
using classes;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1
{
    [Authorize]
    public class CreateEbookModel : PageModel
    {
        [BindProperty]
        public EbookDTO EBooksDTO { get; set; }

       
        public List<SelectListItem> CatogoriesOptions { get; set; }
        private Productmanager productmanager;


        public CreateEbookModel(IProductRepo productRepo)
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


        public IActionResult OnPostEbook(EbookDTO EbooksDTO)
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
                        foreach (Catogories catogories in EbooksDTO.Catogories)
                        {
                            catogoriesProduct.Add(catogories);
                        }
                        Books NewBook = new Books(EbooksDTO.ProductName, EbooksDTO.Description, Convert.ToDecimal(EbooksDTO.Price), EbooksDTO.Url, EbooksDTO.Catogories, EbooksDTO.Pages, false);
                        Books NewEbook = new Ebook(NewBook, EbooksDTO.Downloadlink);
                        productmanager.CreateProduct(NewEbook, userId);


  

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

