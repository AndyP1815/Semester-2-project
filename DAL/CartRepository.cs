using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes;
using classes.classes;
using classes.Interfaces;


namespace DAL
{
    public class CartRepository :BaseRepository, ICartRepository
    {
        public void AddProductToCart(Cart_Item product, int user_id)
        {
            try {
                string query;
                if (product.Product.GetBool() > 1)
                {
                    query = "INSERT INTO Cart_Item VALUES ((SELECT MAX(id) FROM Cart_Item) + 1, @Quantity, NULL, NULL, @size, @Price, @ProductId, (SELECT cart_id FROM Cart WHERE User_id = @User_id))";
                }
                else
                {
                    query = "INSERT INTO Cart_Item VALUES ((SELECT MAX(id) FROM Cart_Item) + 1, @Quantity, @Option, @Bool, @size, @Price, @ProductId, (SELECT cart_id FROM Cart WHERE User_id = @User_id))";
                }

                List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@Bool", product.Product.GetBool()),
        new SqlParameter("@User_id", user_id),
        new SqlParameter("@Quantity", product.Quantity),
        new SqlParameter("@Option", product.Product.GetOption() ?? (object)DBNull.Value),
        new SqlParameter("@Price", product.Product.Price),
        new SqlParameter("@ProductId", product.Product.ID),
        new SqlParameter("@size",product.Product.Getsize())
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


        public void CreateCart(int userId)
        {
            try
            {
                string query = "INSERT INTO Cart VALUES ((SELECT MAX([Cart_id]) FROM Cart) + 1, @UserId);";
                List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@UserId", userId)
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

        public void DeleteCart(int id)
        {
            try
            {
                string query = "delete from [dbo].[Cart_Item] where cart_id = @id";
                List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@id", id)
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

            public int GetCartIdByUserId(int user_id)
        {

            if (user_id == 0)
            {
                throw new ArgumentNullException(nameof(user_id), "The user object cannot be null.");

            }
            try
            {
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"select Cart_id from cart where User_id = @ID", connection);
                    command.Parameters.AddWithValue("@ID", user_id);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                   return 0;
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

       

        public bool GetProductBool(int Cart_ItemId)
        {
            if(Cart_ItemId == 0)
            {
				throw new ArgumentNullException(nameof(Cart_ItemId), "The user object cannot be null.");
			}
			try
			{
				using (SqlConnection connection = new SqlConnection(base.ConnectionString))
				{
					connection.Open();
					var Bool = new List<bool>();
					SqlCommand command = new SqlCommand($"select Bool from Cart_Item where id = @ID", connection);
					command.Parameters.AddWithValue("@ID", Cart_ItemId);

					SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            return false;
                        }
						Bool.Add(reader.GetBoolean(0));
					}
					return Bool[0];
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

        public List<string> GetProductIdsInCart(int id)
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
                    var ids = new List<string>();
                    SqlCommand command = new SqlCommand($"select[Product_id] from Cart_Item inner join Cart on Cart.Cart_id = Cart_Item.Cart_id where User_id =  @ID", connection);
                    command.Parameters.AddWithValue("@ID", id);

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

		public List<Cart_Item> GetProductsInCart(List<Product> products, int id)
		{
            if (products.Count == 0)
            {
                return new List<Cart_Item>();
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                    {
                        connection.Open();
                        List<Cart_Item> cart_Items = new List<Cart_Item>();

                        SqlCommand command = new SqlCommand("SELECT Quantity, [id], Product_id FROM Cart_Item INNER JOIN Cart ON Cart.Cart_id = Cart_Item.Cart_id  WHERE Cart.User_id = @ID", connection);
                        command.Parameters.AddWithValue("@ID", id);
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Product product = null;
                            foreach (var item in products)
                            {
                                if (item.ID.Trim() == reader.GetString(2).Trim())
                                {
                                    product = item;
                                    break;
                                }
                            }

                            if (product != null)
                            {
                                cart_Items.Add(new Cart_Item(product, reader.GetInt32(0), reader.GetInt32(1)));
                            }
                        }

                        reader.Close();

                        return cart_Items;
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


        public string GetProductSize(int Cart_ItemId)
        {
			if (Cart_ItemId == 0)
			{
				throw new ArgumentNullException(nameof(Cart_ItemId), "The user object cannot be null.");
			}
			try
			{
				using (SqlConnection connection = new SqlConnection(base.ConnectionString))
				{
					connection.Open();
					var Size = new List<string>();
					SqlCommand command = new SqlCommand($"select Size from Cart_Item where id = @ID", connection);
					command.Parameters.AddWithValue("@ID", Cart_ItemId);

					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						Size.Add(reader.GetString(0));
					}
					return Size[0];
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
                string query = "delete from Cart_Item where Product_id = @Id";
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

        public void RemoveProductFromCart(int Cart_Item_id)
        {
            try
            {
                string query = "delete from Cart_Item where id = @ID";
                List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@Id", Cart_Item_id)
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

            public void UpdateCart(int id,int quantity)
        {
            try
            {
                string query = "update Cart_Item set Quantity = @quantity where id = @Id";
                List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@Id",id),
        new SqlParameter("@quantity",quantity)
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
