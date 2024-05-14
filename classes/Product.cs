using System.Globalization;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using classes;

namespace classes
{
	public class Product: IComparable<Product>
	{
		private string id;
		private string productName;
		private string description;
		private decimal price;
		private string url;
		private List<Catogories> catogories;

		// retrieving product
        public Product(string id, string productName, string description, decimal price, string url)
        {
            this.id = id;
            this.productName = productName;
            this.description = description;
            this.price = price;
            this.url = url;
			catogories = new List<Catogories>();	
		
        }

		// Creating product

		public Product(string productName, string description, decimal price, string url, List<Catogories> catogories)
		{
            this.productName = productName;
            this.description = description;
            this.price = price;
            this.url = url;
            this.catogories = catogories;
        }
		public Product(Product product)
		{
			this.id = product.id;
			this.productName = product.ProductName;
			this.description = product.description;
			this.price = product.price;
			this.url = product.url;
			this.catogories = product.catogories;
		}
		public virtual string ExtraProductInfo()
		{
			return "";
		}
		public virtual string GetOption()
		{
			return "";
		}
		public virtual string Getsize()
		{
			return "No size";
		}
		public virtual int GetBool()
		{
			return 0;
		}

		public virtual string SeeInfo()
		{
            return $"ID = {this.id}\n " +
				$"Product name = {this.productName}\n" +
				 $"Description = {this.description}\n" +
                  $"Price = {this.price}\n";
		}
		public override string ToString()
		{
			return $"{this.id.Trim()} - {this.productName.Trim()} - {this.CalculatePrice().ToString().Trim()}";
		}
		public void AddCatogories(Catogories Catogories)
		{
			catogories.Add(Catogories);
		}
		
		public virtual decimal CalculatePrice()
		{
			return price;
		}
		public int CompareTo(Product other)
		{
			if (other == null)
				return 1;

			return price.CompareTo(other.price);
		}

		public string ID { get { return id; } }
		public string ProductName { get {  return productName; } }
		public string Description { get { return description; } }
		public decimal Price { get { return price;} }
		public string Url { get { return url; } }
		public List<Catogories> Catogories { get {  return catogories; }
	}
	}


}
