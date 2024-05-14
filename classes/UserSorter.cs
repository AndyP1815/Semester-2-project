using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using classes.Comparers;
using classes.Interfaces;
using classes.Managers;


namespace classes
{
	public class UserSorter
	{
		private Usermanager usermanager;
		private IComparer<User> NameComparer;

		public UserSorter(IUserRepo userRepo,ICartRepository cartRepository,IProductRepo productrepo)
		{
			usermanager = new Usermanager(userRepo,cartRepository, productrepo);
		}

		public List<User> FilterUser(int UserInt)
		{
			if(UserInt < 1)
			{
				return usermanager.GetAllUser();
			}
			if (UserInt == 1) 
			{
				return usermanager.GetUsers();
			}
			if(UserInt == 2)
			{
				List<User> users = new List<User>();	
				foreach(Seller s in usermanager.GetSellers())
				{
					users.Add(s);
				}
				return users;
			}
			if (UserInt > 2)
			{
				throw new IndexOutOfRangeException();
			}
			return null;

		}
		public User GetUserByName(List<User> users, string name)
		{
			foreach (User u in users)
				if(u.Username.Trim() == name)
				{
					return u;
				}
			return null;
		}
		public void SortUserByName(List<User> users)
		{
			if (NameComparer == null)
			{
				NameComparer = new UserNameComparer();
			}
			users.Sort(NameComparer);
		}
		

	}
}
