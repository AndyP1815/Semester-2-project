using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Security.Claims;
using classes;
using classes.classes;
using classes.Interfaces;
using classes.Managers;
using DAL;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Pages;

namespace WebApplication1
{
    public class ProductModel : PageModel
    {
        private Productmanager productmanager;
        public ProductDTO productDTO;
        public Product product;
        private Usermanager usermanager;
        private ProductReworker productReworker;
        private CartManager cartManager;
        private FavoriteListManager favoritemanager;

        public List<FavoriteListDTO> favoriteLists { get; set; }

        [BindProperty]
        public bool MyBoolean { get; set; }
        [BindProperty]
        public string Size { get; set; }
        public decimal TotalPrice;

        public ProductModel(IProductRepo productRepo, IUserRepo userRepo, ICartRepository cartRepository, IFavoritelistRepository favoritelistRepository)
        {
            this.productmanager = new Productmanager(productRepo);
            this.usermanager = new Usermanager(userRepo, cartRepository, productRepo);
            productReworker = new ProductReworker();
            this.cartManager = new CartManager(cartRepository, productRepo);
            this.favoritemanager = new FavoriteListManager(favoritelistRepository, productRepo,userRepo);
        }

        public void SetFavoriteList()
        {
            try
            {

                favoriteLists = new List<FavoriteListDTO>();
                string idValue = User.FindFirstValue("id");
                int userId;

                if (int.TryParse(idValue, out userId))
                {
                    var userList = favoritemanager.favoriteListId(userId);
                    foreach (FavoriteList list in userList)
                    {
                        List<ProductDTO> productDTOs = new List<ProductDTO>();
                        foreach(Product p in list.GetFavoriteProducts())
                        {
                            productDTOs.Add(new ProductDTO(p));
                        }
                        favoriteLists.Add(new FavoriteListDTO(list,productDTOs));
                        //test

                      
                    }
                }
            }catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public IActionResult OnGet(string id)
        {
            try
            {
                SetFavoriteList();
                HttpContext.Session.Clear();
                product = productmanager.GetProductByInt(id);
                productDTO = new ProductDTO(product);
                TotalPrice = Convert.ToDecimal(productDTO.Price);
       
                return Page();
            }catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while processing the request.";
                return RedirectToPage("/Error");
            }
        }

        [HttpPost]
        public IActionResult OnPostBool(string id, bool myBoolean, string size)
        {
            try
            {
                SetFavoriteList();
                product = productmanager.GetProductByInt(id);
                Product updatedProduct = productReworker.ChangeSize(productReworker.ChangeBool(product, myBoolean), size);
                int session = myBoolean ? 1 : 0;

                HttpContext.Session.SetInt32("Bool", session);
                if (size != null)
                {
                    HttpContext.Session.SetString("Size", size);
                }
                TotalPrice = updatedProduct.CalculatePrice();
                productDTO = new ProductDTO(updatedProduct);
                return Page();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while processing the request.";
                return RedirectToPage("/Error");
            }
          
        }

        public IActionResult OnPostAdd(string id)
        {
            try
            {
                string idValue = User.FindFirstValue("id");
                int userId;

                if (!int.TryParse(idValue, out userId))
                {
                    return RedirectToPage("/Login");
                }

                User pageUser = usermanager.GetUserById(userId);
                Product product = productmanager.GetProductByInt(id);

                bool boolValue = HttpContext.Session.GetInt32("Bool") == 1;
                string size = HttpContext.Session.GetString("Size");
                string selectedSize = size ?? string.Empty;

                cartManager.AddOrUpdateProductToCart(pageUser, product, boolValue, size, productReworker);

                return RedirectToPage("/Cart");
            }
            catch(NullReferenceException ex)
            {
                TempData["ErrorMessage"] = "An error occurred while processing the request.";
                return RedirectToPage("/Error");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while processing the request.";
                return RedirectToPage("/Error");
            }
        }


        [HttpPost]
        public IActionResult OnPostFavorite(List<FavoriteListDTO> favoriteLists, string id)
        {
            try
            {
                SetFavoriteList();
                string idValue = User.FindFirstValue("id");
                int userId;

                if (int.TryParse(idValue, out userId))
                {
                    Dictionary<int, bool> SelectedList = new Dictionary<int, bool>();
                    List<FavoriteList> OriginalList = new List<FavoriteList>();

                    
                    foreach (var item in favoriteLists)
                    {
                        SelectedList.Add(item.ID, item.Selected);
                    }
                    foreach(var item in this.favoriteLists)
                    {
                        List<Product> products = new List<Product>();
                        foreach (var product in item.Product)
                        {
                            products.Add(new Product(product.Id,product.ProductName,product.Description,Convert.ToDecimal(product),product.Url));
                        }

                       
                        OriginalList.Add(new FavoriteList(products,item.ID,item.Name));
                    }
                    favoritemanager.ProductAddManager(id,SelectedList,OriginalList);

                    
                }
                else
                {
                    return RedirectToPage("/Login");
                }

                return RedirectToPage("/Product", new { id = id });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while processing the request.";
                return RedirectToPage("/Error");
            }
        }
    }
}