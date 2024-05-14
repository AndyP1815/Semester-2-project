using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using classes.classes;


namespace classes
{
    public class Seller: User
    {
        List<Product> products = new List<Product>();
        private double revenue;
        private string description;

  
		public Seller(string username, string password, string adress,string salt, int id)
		: base(username, password, adress, salt, id)
		{
			this.revenue = 0;
			this.description = "";
		}
		public Seller(string username, string password, string adress, string salt, int id,string description)
		: base(username, password, adress, salt, id)
		{
			
			this.description = description;
		}
		public Seller(User u,double revenue,string description)
    : base(u.Username, u.Password, u.Adress, u.Salt, u.ID)
        {
            this.revenue = revenue;
            this.description = description;
        }
        public Seller(string username, string password, string adress, string salt, Cart cart, List<Order> orders, List<FavoriteList> favoritelist, int id, double revenue, string description)
            : base(username, password, adress, salt, cart, orders, favoritelist, id)
        {
            this.revenue = revenue;
            this.description = description;
        }
        public Seller(Seller s,Cart cart,List<Product> products):base(s,cart)
        {
            this.products = products;
            this.revenue = s.revenue;
            this.description = s.description;
            

        }
        public void addProduct(Product p)
        {
            products.Add(p);
        }
        public void RemoveProduct(Product p)
        {
            products.Remove(p);
        }
		public override string ToString()
		{
			return $"{base.ID} - {base.Username.Trim()} - Seller";
		}
		public override string Seeinfo()
        {
            return base.Seeinfo() + $"revenue = {this.revenue.ToString()}\n" +
                $"desription = {this.description}";
        }

        public string Description {get { return this.description;}}
        public double Revenue { get { return this.revenue;  } }
        public List<Product> Products { get { return this.products; } }

    }
}
