
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using classes.classes;
using classes.Interfaces;

namespace classes.Managers
{
    public class Usermanager
    {
        private List<User> users = new List<User>();
        private IUserRepo repo;
        private CartManager cartManager;
        private Productmanager productmanager;
        private const int saltSize = 32;
        private const int hashSize = 32;
        private const int iterations = 10000;
        public Usermanager(IUserRepo userRepo,ICartRepository cartRepository,IProductRepo productRepo)
        {
            users = userRepo.GetUsers();
            repo = userRepo;
            this.cartManager = new CartManager(cartRepository,productRepo);
            this.productmanager = new Productmanager(productRepo);
        }

        public void CreateUser(User user)
        {
            try
            {
                if (user is Seller)
                {
                    repo.CreateSeller(((Seller)user));
                }
                else
                {
                    repo.CreateUser(user);
                }
            }
            catch { }
        }

        public List<User> Users { get { return users; } }
        public List<User> GetUserByName(string name)
        {
            try
            {
                if (repo.GetUserByName(name) == null)
                {
                    return null;
                }
                else
                {
                    return repo.GetUserByName(name);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }


        }

       

        public string HashPassword(string password, out string salt)
        {
            try
            {
                using (var rng = RandomNumberGenerator.Create())
                {
                    var saltBytes = new byte[saltSize];
                    rng.GetBytes(saltBytes);
                    salt = Convert.ToBase64String(saltBytes);
                }

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), iterations, HashAlgorithmName.SHA256))
                {
                    var hashBytes = pbkdf2.GetBytes(hashSize);
                    return Convert.ToBase64String(hashBytes);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }

		public User VerifyPassword(string password, string username)
		{
			try
			{
				foreach (var u in GetUserByName(username))
				{
					string salt = u.Salt;
					string hashedPassword = u.Password;
					using (var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), iterations, HashAlgorithmName.SHA256))
					{
						var hashBytes = pbkdf2.GetBytes(hashSize);
						var storedHashBytes = Convert.FromBase64String(hashedPassword);

						if (hashBytes.SequenceEqual(storedHashBytes))
						{
							return u;
						}
					}
				}

				return null; 
			}
			catch (NullReferenceException ex)
			{
				throw new NullReferenceException();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}


		public void UpdateProduct(int id,User user)
        {
            try
            {
                repo.UpdateUser(id, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public int GetUserID()
        {
            try
            {
                return repo.GetUserId();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public List<Product> GetProductsOfSeller(int sellerId)
        {
            try
            {
                var ids = repo.GetProductIdsFromSeller(sellerId);
                List<Product> products = new List<Product>();
                foreach (var id in ids)
                {
                    products.Add(productmanager.GetProductByInt(id));
                }
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        
        public List<User> GetUsers()
        {
            try
            {
                var users = new List<User>();

                foreach (User user in repo.GetUsers())
                {
                    users.Add(new User(user, cartManager.GetCartByUserId(user.ID)));
                }
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public List<Seller> GetSellers()
        {
            try
            {
                var sellers = new List<Seller>();

                foreach (Seller s in repo.GetSellers())
                {
                    sellers.Add(new Seller(s, cartManager.GetCartByUserId(s.ID), GetProductsOfSeller(s.ID)));
                }
                return sellers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public List <User> GetAllUser()
        {
            try
            {
                List<User> AllUsers = new List<User>();
                foreach (User u in repo.GetAllUsers())
                {
                  
                    if (u is Seller)
                    {
                        AllUsers.Add(new Seller((Seller)u, cartManager.GetCartByUserId(u.ID), GetProductsOfSeller(u.ID)));
                    }
                    if (AllUsers.FirstOrDefault(user => user.ID == u.ID) == null)
                    {
                        AllUsers.Add(new User(u, cartManager.GetCartByUserId(u.ID)));
                    }

                }
                return AllUsers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public User GetUserById(int id)
        {
            try
            {
                User user = repo.GetUserByid(id);
                Cart cart = cartManager.GetCartByUserId(id);


                if (repo.GetUserByid(id) is Seller)
                {
                    return new Seller((Seller)user, cart, GetProductsOfSeller(user.ID));
                }
                else
                {
                    return new User(user, cart);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
      
    }
}
