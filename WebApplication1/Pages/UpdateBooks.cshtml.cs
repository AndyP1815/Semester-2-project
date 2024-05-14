using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using classes;
using classes.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1
{
    public class UpdateBooksModel : PageModel
    {
		[BindProperty]
		public BooksDTO BooksDTO { get; set; }
  //      [BindProperty]
  //      public BooksDTO EBooksDTO { get; set; }
		//[Required]
		//public string DownloadLink { get; set; }


        //public bool Ebook;
		public List<SelectListItem> CatogoriesOptions { get; set; }
		private Productmanager productmanager;

		public UpdateBooksModel(IProductRepo productRepo)
        {
            this.productmanager = new Productmanager(productRepo);
        }
        
        public IActionResult OnGet(string id)
        {
            try {
                
                    Product product = productmanager.GetProductByInt(id);
                    //if (product is Ebook)
                    //{
                    //    Ebook = true;
                    //    EBooksDTO = new BooksDTO(((Books)product));
                    //    DownloadLink = ((Ebook)product).DownloadLink;

                    //    if (EBooksDTO.Ebook)
                    //    {
                    //        string ID = id.Replace("E", "");
                    //        Product Bookp = productmanager.GetProductByInt(ID);
                    //        BooksDTO = new BooksDTO(((Books)Bookp));
                    //    }
                    //    else
                    //    {
                    //        BooksDTO = new BooksDTO(((Books)product));
                    //    }
                    //}
                    //else
                    //{
                        //Ebook = false;
                        BooksDTO = new BooksDTO(((Books)product));
                //        if (BooksDTO.Ebook)
                //        {
                //            Product EBookp = productmanager.GetProductByInt($"{id.Trim()}E");
                //            this.EBooksDTO = new BooksDTO(((Books)EBookp));
                //            DownloadLink = ((Ebook)EBookp).DownloadLink;
                //        }
                //        else
                //        {
                //            EBooksDTO = new BooksDTO(((Books)product));

                //        }
                //        return RedirectToPage("/index");
                //    }
                //}
                //else
                //{
                //    return Page();
                
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while processing the request.";
                return RedirectToPage("/Error");
            }

            CatogoriesOptions = new List<SelectListItem>();

            foreach (Catogories catogories in Enum.GetValues(typeof(Catogories)))
            {
                CatogoriesOptions.Add(new SelectListItem { Value = catogories.ToString(), Text = catogories.ToString() });
            }
            return Page();
        }
        public IActionResult OnPostBook(BooksDTO booksDTO, string id)
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

                        //Product product = productmanager.GetProductByInt(id + "E");
                        //if (((Books)product).Ebook)
                        //{
                        //    Books NewBook = new Books(booksDTO.ProductName, booksDTO.Description, product.Price, product.Url, booksDTO.Catogories, booksDTO.Pages, booksDTO.Ebook);
                        //    productmanager.UpdateProduct(id, NewBook);
                        //    productmanager.UpdateProduct(id + "E", NewBook);
                        //}
                        //else
                        //{
                        Books NewBook = new Books(booksDTO.ProductName, booksDTO.Description, Convert.ToDecimal(booksDTO.Price), booksDTO.Url, booksDTO.Catogories, booksDTO.Pages, booksDTO.Ebook);
                        productmanager.UpdateProduct(id, NewBook);
                        //}
                    }
                    else
                    {

                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Please enter everything in");
                    OnGet(id);
                    return Page();
                }
                
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while processing the request.";
                return RedirectToPage("/Error");
            }
        }

        //public IActionResult OnPostEbook(BooksDTO booksDTO,string downloadlink ,string id)
        //{
        //    try
        //    {
        //        string idValue = User.FindFirstValue("id");
        //        int userId;

        //        if (int.TryParse(idValue, out userId))
        //        {
        //            List<Catogories> catogoriesProduct = new List<Catogories>();
        //            foreach (Catogories catogories in booksDTO.Catogories)
        //            {
        //                catogoriesProduct.Add(catogories);
        //            }
        //            string bookid = id.Replace("E", "");
        //            Product product = productmanager.GetProductByInt(bookid);
        //            if (((Books)product).Ebook)
        //            {
                        
        //                Books NewBook = new Books(booksDTO.ProductName, booksDTO.Description, product.Price, product.Url, booksDTO.Catogories, booksDTO.Pages, booksDTO.Ebook);
        //                Books NewEbook = new Ebook(NewBook, downloadlink, NewBook.Price);
        //                productmanager.UpdateProduct(id, NewEbook);
        //                productmanager.UpdateProduct(bookid,NewBook);
        //            }
        //            else
        //            {
        //                Books NewBook = new Books(booksDTO.ProductName, booksDTO.Description, Convert.ToDecimal(booksDTO), booksDTO.Url, booksDTO.Catogories, booksDTO.Pages, booksDTO.Ebook);
        //                Books NewEbook = new Ebook(NewBook, downloadlink, NewBook.Price);
        //                productmanager.UpdateProduct(id, NewEbook);
        //            }
                   
        //            return RedirectToPage("/Index");
        //        }
        //        return RedirectToPage("/Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = "An error occurred while processing the request.";
        //        return RedirectToPage("/Error");
        //    }
        //}
    }


    }

