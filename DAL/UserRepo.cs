using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using classes;
using classes.Interfaces;


namespace DAL
{
	public class UserRepo : BaseRepository, IUserRepo
	{

		public List<User> GetUsers()
		{
			try
			{
				var Users = new List<User>();
				using (SqlDataReader reader = base.OpenConnection("Select UserName,password_Hash,Adress,Salt,U.User_id,Revenue,Description from [dbo].[User] U left join Seller on U.User_id = Seller.User_id"))
					while (reader.Read())
					{
						User user = new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));


						if (reader.GetValue(5) != DBNull.Value)
						{

						}
						else
						{
							Users.Add(user);
						}

					}
				if (Users.Count == 0)
				{
					throw new ArgumentNullException("There is a problem with reading data");
				}

				return Users;
			}
			catch (SqlException ex)
			{
				throw new InvalidOperationException("There is a problem with the database: " + ex.Message, ex);
			}
			catch (Exception ex)
			{
				throw new ArgumentException("There is an error: " + ex.Message, ex);
			}

		}
		public void CreateUser(User user)
		{
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user), "The user object cannot be null.");
			}

			try
			{
				string query = "INSERT INTO [dbo].[User] VALUES (@ID, @Password, @Salt, @Username, @Address)";
				List<SqlParameter> parameters = new List<SqlParameter>
		{
			new SqlParameter("@ID", user.ID),
			new SqlParameter("@Password", user.Password),
			new SqlParameter("@Salt", user.Salt),
			new SqlParameter("@Username", user.Username),
			new SqlParameter("@Address", user.Adress)
		};
                base.UseDatabase(query, parameters);
			}
			catch (SqlException ex)
			{
				throw new InvalidOperationException("There is a problem with the database: " + ex.Message, ex);
			}
			catch (NullReferenceException ex)
			{
				throw new NullReferenceException("A null reference error occurred while inserting user data into the database.", ex);
			}
			catch (Exception ex)
			{
				throw new ArgumentException("There is an error: " + ex.Message, ex);
			}
		}


		public List<Seller> GetSellers()
		{
			try
			{
				var Users = new List<Seller>();
				using (SqlDataReader reader = base.OpenConnection("Select UserName,password_Hash,Adress,Salt,U.User_id,Revenue,Description from [dbo].[User] U inner join Seller on U.User_id = Seller.User_id"))
					while (reader.Read())
					{
						User user = new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
						Seller s = new Seller(user, Convert.ToDouble(reader.GetValue(5)), reader.GetString(6));
						Users.Add(s);



					}
				if (Users.Count == 0)
				{
					throw new ArgumentNullException("There is a problem with reading data");
				}

				return Users;
			}
			catch (SqlException ex)
			{
				throw new InvalidOperationException("There is a problem with the database: " + ex.Message, ex);
			}
			catch (Exception ex)
			{
				throw new ArgumentException("There is an error: " + ex.Message, ex);
			}
		}

		public void UpdateUser(int id,User user)
		{
            try
            {
				if(user == null)
				{
					throw new NullReferenceException();
				}
                if(user is Seller)
				{
					string SellerQuery = "update Seller set Description = @Description where User_id = @Id";
					List<SqlParameter> Parameters = new List<SqlParameter>()
					{
						new SqlParameter("@Description",((Seller)user).Description),
						new SqlParameter("@Id",id)
						
                    };
                    base.UseDatabase(SellerQuery, Parameters);

                }
				string UserQuery = "update [dbo].[User] set UserName = @UserName, Adress = @Adress where User_id = @Id";
				List<SqlParameter> sqlParameters = new List<SqlParameter>()
				{
					new SqlParameter("@UserName",user.Username),
					new SqlParameter("@Adress",user.Adress),
					new SqlParameter("@Id",id)
				};
				base.UseDatabase(UserQuery, sqlParameters);

                

               
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("There is a problem with the database: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("There is an error: " + ex.Message, ex);
            }
        }

		public void RemoveUser(int id)
		{
            try
            {
                if (id == 0)
                {
                    throw new NullReferenceException();
                }
                
                    string SellerQuery = "Delete from Seller where User_id = @Id";
                    string UserQuery = "Delete from [dbo].[User] where User_id = @Id";
                List<SqlParameter> sqlParameters = new List<SqlParameter>()
                {
                    new SqlParameter("@Id",id)
                };
                base.UseDatabase(UserQuery, sqlParameters);
				base.UseDatabase(SellerQuery,sqlParameters);




            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("There is a problem with the database: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("There is an error: " + ex.Message, ex);
            }
        }

		public User GetUserByid(int id)
		{
			if (id == 0)
			{
				throw new ArgumentNullException(nameof(id), "The user object cannot be null.");

			}
			try
			{
				using (SqlConnection connection = new SqlConnection(base.ConnectionString))
				{
					connection.Open();

					SqlCommand command = new SqlCommand($"SELECT UserName, password_Hash, Adress, Salt, U.User_id, Revenue, Description FROM [dbo].[User] U LEFT JOIN Seller ON U.User_id = Seller.User_id WHERE U.User_id = @ID", connection);
					command.Parameters.AddWithValue("@ID", id);

					SqlDataReader reader = command.ExecuteReader();

					List<User> users = new List<User>();

					while (reader.Read())
					{
						User user = new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));

						if (reader.GetValue(5) != DBNull.Value)
						{
							Seller seller = new Seller(user, Convert.ToDouble(reader.GetValue(5)), reader.GetString(6));
							return seller;
						}
						else
						{ 
							return user;
						}
					}

					
				}

				return null;
			}
			catch (SqlException ex)
			{
				throw new InvalidOperationException("There is a problem with the database: " + ex.Message, ex);
			}
			catch (Exception ex)
			{
				throw new ArgumentException("There is an error: " + ex.Message, ex);
			}
		}

	
	public int GetUserId()
        {
            using (SqlDataReader SDT = base.OpenConnection("select max([User_id]) from [dbo].[User]"))
            {
                while (SDT.Read())
                {
                    int id;
                    id = Convert.ToInt32(SDT.GetValue(0)) + 1;
                    return id;
                }
            }
            return 0;
        }

        public void CreateSeller(Seller seller)
        {
            if (seller == null)
            {
                throw new ArgumentNullException(nameof(seller), "The user object cannot be null.");
            }
            try
            {
                CreateUser(seller);

                string sellerQuery = "INSERT INTO Seller VALUES ((SELECT MAX(Seller_id) FROM Seller) + 1, @Description, @Revenue, @ID);";
                List<SqlParameter> sellerParams = new List<SqlParameter>
    {
        new SqlParameter("@Description", seller.Description),
        new SqlParameter("@Revenue", seller.Revenue),
        new SqlParameter("@ID", seller.ID)
    };
                base.UseDatabase(sellerQuery, sellerParams);
            }
			catch (SqlException ex)
			{
				throw new InvalidOperationException("There is a problem with the database: " + ex.Message, ex);
			}
			catch (Exception ex)
			{
				throw new ArgumentException("There is an error: " + ex.Message, ex);
			}
		}


        public List<User> GetUserByName(string name)
        {
            if(name == null)
            {
                throw new ArgumentNullException(nameof(name), "The user object cannot be null.");

			}
            try
            {
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand($"SELECT UserName, password_Hash, Adress, Salt, U.User_id, Revenue, Description FROM [dbo].[User] U LEFT JOIN Seller ON U.User_id = Seller.User_id WHERE UserName = @Name", connection);
                    command.Parameters.AddWithValue("@Name", name);

                    SqlDataReader reader = command.ExecuteReader();

                    List<User> users = new List<User>();

                    while (reader.Read())
                    {
                        User user = new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));

                        if (reader.GetValue(5) != DBNull.Value)
                        {
                            Seller seller = new Seller(user, Convert.ToDouble(reader.GetValue(5)), reader.GetString(6));
                            users.Add(seller);
                        }
                        else
                        {
                            users.Add(user);
                        }
                    }

                    if (users.Count > 0)
                    {
                        return users;
                    }
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("There is a problem with the database: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("There is an error: " + ex.Message, ex);
            }
        }

		

		public List<User> GetAllUsers()
		{
          
            try
            {
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand($"SELECT UserName, password_Hash, Adress, Salt, U.User_id, Revenue, Description FROM [dbo].[User] U LEFT JOIN Seller ON U.User_id = Seller.User_id", connection);
                   

                    SqlDataReader reader = command.ExecuteReader();

                    List<User> users = new List<User>();

                    while (reader.Read())
                    {
                        User user = new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));

                        if (reader.GetValue(5) != DBNull.Value)
                        {
                            Seller seller = new Seller(user, Convert.ToDouble(reader.GetValue(5)), reader.GetString(6));
                            users.Add(seller);
                        }
                        else
                        {
                            users.Add(user);
                        }
                    }

                    if (users.Count > 0)
                    {
                        return users;
                    }
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("There is a problem with the database: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("There is an error: " + ex.Message, ex);
            }
            
		}

        public List<string> GetProductIdsFromSeller(int seller_id)
        {
           
                try
                {
                var ids = new List<string>();
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand($"SELECT Product_id from Seller_Product inner join Seller on Seller.Seller_id = Seller_Product.Seller_id  where User_id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", seller_id);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ids.Add(reader.GetString(0));
                    }
                    return ids;
                }
                    }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("There is a problem with the database: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("There is an error: " + ex.Message, ex);
            }
        }
    }
}



