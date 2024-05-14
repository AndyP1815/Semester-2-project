using System.ComponentModel.DataAnnotations;
using classes;

namespace WebApplication1
{
    public class ProductDTO
{
		public string Id;
        [Required]
        public string ProductName {get;set;}
        [Required]
        public string Description { get; set; }
        [Required]
        [RegularExpression(@"^\d+(\,\d+)?$", ErrorMessage = "Please enter a valid decimal or integer.")]
        public decimal? Price { get; set; }
        [Required]
        public string Url { get; set; }

		[Required]
        public List<Catogories> Catogories { get; set; }
        public string ExtraInfo;
	
		public ProductDTO() 
		{

		}
		public ProductDTO(Product product)
		{
			this.Id = product.ID;
			this.ProductName = product.ProductName;
			this.Description = product.Description;
			this.Price = product.Price;
			this.Url = product.Url;
			this.Catogories = product.Catogories;
			this.ExtraInfo = product.ExtraProductInfo();
		

		}
       
    }
}
