using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes;
using classes.Interfaces;

namespace FakeDAL
{
    public class FakeUserRepository : IUserRepo
    {
        List<User> Users = new List<User>();
		List<Seller> Sellers = new List<Seller>();

		public FakeUserRepository()
        {
            User u1 = new User("123456", "EbqFJSDJM6ePy81JZfrxlpzelWnHnhoq0S7yv/f+zsM=", "Jansenstraat2", "NJw/W79qT4QM7VGy2EFgfWLn+1PY6NG61E8yp/elQtw=", 1);
            User s1 = new Seller("Seller", "Password", "Helmond", "SellerSalt", new classes.classes.Cart(2), new List<Order>(), new List<FavoriteList>(), 1, 10.25, "Description");
            User s2 = new Seller("Seller2","Password2","Eindhoven", "Salt",new classes.classes.Cart(1),new List<Order>(),new List<FavoriteList>(),1,100,"Description");
            Users.Add(u1);
            Users.Add(s1);
            Sellers.Add((Seller)s1);
            Sellers.Add((Seller)s2);
        }
        public void CreateSeller(Seller seller)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

		public List<User> GetAllUsers()
		{
			return Users;
		}

        public List<string> GetProductIdsFromSeller(int Seller_id)
        {
            return new List<string>
            {
                "1","2","3"
            };
        }

        public List<Seller> GetSellers()
        {
            return Sellers;
        }

        public void GetUserByid(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUserByName(string name)
        {
            var users = new List<User>();   
            foreach (User u in Users)
                if(name == u.Username)
            {
                    users.Add(u);
            }
            return users;
        }

        public int GetUserId()
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            return Users;
        }

        public void RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }

        User IUserRepo.GetUserByid(int id)
		{
			throw new NotImplementedException();
		}
	}
}
