using classes;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using classes.Managers;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1
{
    [Authorize]
    public class CreateBookModel : PageModel
    {
        [BindProperty]
        public BooksDTO BooksDTO{ get; set; }
    
    
        public List<SelectListItem> CatogoriesOptions { get; set; }
        private Productmanager productmanager;


        public CreateBookModel(IProductRepo productRepo)
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

		public IActionResult OnPost(BooksDTO booksDTO)
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
                        foreach (Catogories catogories in booksDTO.Catogories)
                        {
                            catogoriesProduct.Add(catogories);
                        }
                       
                            Books ReturnBook = new Books(booksDTO.ProductName, booksDTO.Description, Convert.ToDecimal(booksDTO.Price), booksDTO.Url, booksDTO.Catogories, booksDTO.Pages, true);
                            productmanager.CreateProduct(ReturnBook, userId);
                        

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


