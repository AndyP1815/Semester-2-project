using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes.classes;


namespace classes
{
	public class User : IComparable<User>
	{

        private string username;
        private string passwordHash;
        private string salt;
        private int iD;
        private Cart? cart;
        private string adress;
        private  readonly List<FavoriteList> favoriteList = new List<FavoriteList>();
        private readonly List<Order>? orders;

       
        public void AddProductToCart(Cart_Item p)
        {
            if (cart == null)
            {
                throw new NullReferenceException();
            }
            cart.AddProduct(p);
        }
        

		public User(string username, string password, string adress, string salt, int id)
		{
			this.salt = salt;
			this.adress = adress;
			this.username = username;
			this.passwordHash = password;
			this.iD = id;

		}
        public User(User user,Cart cart)
        {
            this.salt = user.Salt;
            this.adress = user.Adress;
            this.username = user.Username;
            this.passwordHash = user.Password;
            this.iD = user.ID;
            this.cart = cart;

        }


        public User(string username, string password, string adress, string salt, Cart cart, List<Order> orders,List<FavoriteList> favoritelist,int id)
        {
            this.salt=salt;
            this.orders = orders;
            this.cart = cart;
            this.favoriteList = favoritelist;
            this.adress = adress;
            this.username = username;
            this.passwordHash = password;
            this.iD = id;

        }
        public string Username { get { return username; } }
        public string Password { get { return passwordHash; } }
        public int ID { get { return iD; } }
        public string Adress { get { return adress; } }
        public Cart? Cart { get { return cart; } }
        public List<Order>? Orders { get { return orders; } }
        public List<FavoriteList>? FavoriteList {get {return favoriteList;} }
        public string Salt { get { return salt; } }

		public override string ToString()
		{
            return $"{this.ID.ToString().Trim()} - {this.username.Trim()} - User";
		}
		public virtual string Seeinfo()
        {
            return $"Username = {this.username}\n" +
                $"iD = {this.iD}\n"+
                $"Adress = {this.adress}";
        }

		public int CompareTo(User other)
		{
			return this.ID.CompareTo(other.ID);
		}
	}
}
