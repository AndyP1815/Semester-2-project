using classes.Managers;
using classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1
{
    public class ClothingModel : PageModel
    {
		public string? SearchPhrase { get; set; }
		private Productmanager productmanager;
		public List<List<ProductDTO>> ProductDTOsList;
		private IProductRepo productRepo;
		public int Count;
        private ProductDisplay productDisplay = new ProductDisplay();


        public ClothingModel(IProductRepo IproductRepo)
		{
			this.ProductDTOsList = new List<List<ProductDTO>>();
			this.productRepo = IproductRepo;
			this.productmanager = new Productmanager(productRepo);

		}

        public List<List<ProductDTO>> ProductDTOs(List<Product> products, List<int> numberList)
        {
            List<List<ProductDTO>> productDTOs = new List<List<ProductDTO>>();

            foreach (var i in productDisplay.ProductDTOs(products, numberList))
            {
                List<ProductDTO> ChildList = new List<ProductDTO>();
                foreach (var product in i)
                {
                    ChildList.Add(new ProductDTO(product));
                }
                productDTOs.Add(ChildList);
            }
            return productDTOs;

        }


        public IActionResult OnGet(string searchphrase)
		{
			try
			{
				this.SearchPhrase = searchphrase;
				ProductDTOsList = ProductDTOs(productmanager.GetClothes(),productDisplay.GetNumber(productmanager.GetClothes().Count));
				Count = productmanager.GetClothes().Count;
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

