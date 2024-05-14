using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes;
using classes.Interfaces;

namespace DAL
{
    public class FavoritelistRepository : BaseRepository, IFavoritelistRepository
    {
        public void AddProduct(int id, string product_id)
        {
            try
            {
                string query = "Insert into Favorite_Item values ((select max(Favorite_Item_id)from Favorite_Item)+ 1,@Product_id,@id)";

                List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@id",id),
                new SqlParameter("@Product_id",product_id)
            };

                base.UseDatabase(query, parameters);
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

        public void CreateFavoritelist( int UserId, string name)
		{
            try
            {
                string query = "Insert into Favoritelist values ((SELECT MAX(Favoritelist_id) FROM Favoritelist)+1,@User_id,@Name)";

                List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@User_id",UserId),
                new SqlParameter("@Name",name)
            };

                base.UseDatabase(query, parameters);
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

        public Dictionary<Catogories, int> GetFavoriteCatogories()
        {
            Dictionary<Catogories, int> ProductCount = new Dictionary<Catogories, int>();
            string query = "Select Catogories_id,COUNT(Catogories_id) as countProducts from Favorite_Item  inner join Catogories_Product on Favorite_Item.Product_id = Catogories_Product.Product_id group by Catogories_id";
            try
            {
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();
                    var ids = new List<string>();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductCount.Add(((Catogories)reader.GetInt32(0)), reader.GetInt32(1));
                    }
                    return ProductCount;
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

        public List<FavoriteList> GetFavoritelist()
        {
            List < FavoriteList > favoriteLists = new List<FavoriteList>();
           string query = "select Favoritelist_id, Name from Favoritelist";
            try
            {
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();
                    var ids = new List<string>();
                    SqlCommand command = new SqlCommand(query, connection);
                  

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                       favoriteLists.Add(new FavoriteList(reader.GetInt32(0),reader.GetString(1)));
                    }
                    return favoriteLists;
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

        public List<FavoriteList> GetListFavoritelistById(int user_id)
        {
            List<FavoriteList> favoriteLists = new List<FavoriteList>();
            string query = "select Favoritelist_id,Name from Favoritelist where User_id = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();
                    var ids = new List<string>();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", user_id);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        favoriteLists.Add(new FavoriteList(reader.GetInt32(0),reader.GetString(1)));
                    }
                    return favoriteLists;
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

        public FavoriteList GetFavoritelistById(int id)
        {
            List<FavoriteList> favoriteLists = new List<FavoriteList>();
            string query = "select Favoritelist_id, Name from Favoritelist where Favoritelist_id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();
                    var ids = new List<string>();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id",id);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        favoriteLists.Add(new FavoriteList(reader.GetInt32(0), reader.GetString(1)));
                    }
                    return favoriteLists[0];
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

        public Dictionary<string, int> GetFavoriteProductCount()
        {
            Dictionary<string, int> ProductCount = new Dictionary<string, int>();
            string query = "Select Product_id,COUNT(Product_id) as countProducts from Favorite_Item group by Product_id";
            try
            {
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();
                    var ids = new List<string>();
                    SqlCommand command = new SqlCommand(query, connection);
                   
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductCount.Add(reader.GetString(0), reader.GetInt32(1));
                    }
                    return ProductCount;
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

        public Dictionary<int, int> GetFavoriteSeller()
        {
            Dictionary<int, int> ProductCount = new Dictionary<int, int>();
            string query = "Select User_id ,COUNT(Favorite_Item.Product_id) as countProducts from Favorite_Item  inner join Seller_Product on Seller_Product.Product_id = Favorite_Item.Product_id inner join Seller on Seller.Seller_id = Seller_Product.Seller_id group by User_id";
            try
            {
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();
                    var ids = new List<string>();
                    SqlCommand command = new SqlCommand(query, connection);
                   


                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductCount.Add(reader.GetInt32(0), reader.GetInt32(1));
                    }

                    return ProductCount;


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

        public List<string> GetFavortieListProducts(int favortielistid)
        {
            List<string> Ids = new List<string>();
            string query = "select Product_id from Favorite_Item where Favorite_List_id  = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();
                    var ids = new List<string>();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", favortielistid);


                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                       Ids.Add((reader.GetString(0)));
                    }
                   
                        return Ids;
                    
                    
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

		public void ProductIsRemoved(string product_id)
		{
			try
			{
				string query = "delete from Favorite_Item where Product_id = @Id";
				List<SqlParameter> parameters = new List<SqlParameter>()
	{
		new SqlParameter("@Id", product_id)
	};
				base.UseDatabase(query, parameters);

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

		public void RemoveFavoritelist(int id)
        {
            try
            {
                string query = "delete Favorite_Item where Favorite_List_id = @id";

                List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@id",id),
            };
                base.UseDatabase(query, parameters);


                string Query = "Delete Favoritelistwhere Favorite_List_id = @id ";

                base.UseDatabase(Query, parameters);
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

        public void RemoveProduct(int id, string product_id)
        {
            try
            {
                string query = "delete Favorite_Item where Favorite_List_id = @id and Product_id = @Product_id";

                List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@id",id),
                new SqlParameter("@Product_id",product_id)
            };

                base.UseDatabase(query, parameters);
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

        public void UpdateName(string name,int id)
        {
            try
            {
                string query = "update Favoritelist set Name = @name where Favoritelist_id = @id";

                List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@id",id),
                new SqlParameter("@name",name)
            };

                base.UseDatabase(query, parameters);
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
