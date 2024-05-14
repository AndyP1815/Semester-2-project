using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes;
using classes.classes;
using classes.Interfaces;

namespace DAL
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public void CreateOrder(Cart cart, int UserId)
        {
            if(cart == null ^UserId == 0)
            {
                throw new NullReferenceException();
            }
            try
            {
                string query = $"insert into [dbo].[Order] values ((SELECT MAX([Order_id]) FROM [dbo].[Order]) + 1, @UserId,'{Status.InProgress.ToString()}')";
                List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@UserId", UserId)
    };
                base.UseDatabase(query, parameters);
                foreach (Cart_Item c in cart.CartProducts)
                {
                    string queryProduct;
                    if (c.Product.GetBool() >= 2)
                    {
                        queryProduct = "insert into [dbo].[Order_Item] values ((select max(id) from Order_Item)+1,@Quantity,NULL,NULL,@Size,@TotalPrice,@Product_id,(select MAX([Order_id]) FROM [dbo].[Order]))";
                    }
                    else
                    {
                        queryProduct = "insert into [dbo].[Order_Item] values ((select max(id) from Order_Item)+1,@Quantity,@option,@Bool,@Size,@TotalPrice,@Product_id,(select MAX([Order_id]) FROM [dbo].[Order]))";
                    }



                    List<SqlParameter> parametersProduct = new List<SqlParameter>
                {
                    new SqlParameter("@Quantity",c.Quantity),
                    new SqlParameter("@option",c.Product.GetOption() ?? (object)DBNull.Value),
                    new SqlParameter("@Bool",c.Product.GetBool()),
                    new SqlParameter("@Size",c.Product.Getsize()),
                    new SqlParameter("@TotalPrice",c.Product.CalculatePrice()),
                    new SqlParameter("@Product_id",c.Product.ID)
                };
                    base.UseDatabase(queryProduct, parametersProduct);

                    string QueryRevenue = "UPDATE Seller SET Revenue = Revenue + (SELECT Total_Price FROM Order_Item WHERE id = (SELECT MAX(id) FROM Order_Item)) WHERE Seller_id = (SELECT Seller.Seller_id FROM Seller INNER JOIN [dbo].[Seller_Product] AS sp ON Seller.Seller_id = sp.Seller_id WHERE Product_id = @ProductID)";
                    List<SqlParameter> parametersRevenue = new List<SqlParameter>
                {
                    new SqlParameter("@ProductID",c.Product.ID)};

                    base.UseDatabase(QueryRevenue, parametersRevenue);

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

        public bool GetOrderBool(int Item_id)
        {
            if (Item_id == 0)
            {
                throw new ArgumentNullException(nameof(Item_id), "The user object cannot be null.");
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();
                    var Bool = new List<bool>();
                    SqlCommand command = new SqlCommand($"select Bool from Order_Item where id = @ID", connection);
                    command.Parameters.AddWithValue("@ID", Item_id);

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

        public Order GetOrderByOrderId(int OrderId)
        {
            if (OrderId == 0)
            {
                throw new ArgumentNullException(nameof(OrderId), "The user object cannot be null.");

            }
            try
            {
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    Status status;
                    connection.Open();
                    SqlCommand command = new SqlCommand($"select Order_id,Status from [dbo].[Order] where Order_id = @ID", connection);
                    command.Parameters.AddWithValue("@ID", OrderId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (Enum.TryParse(reader.GetString(1), out status))
                        {
                            return new Order(reader.GetInt32(0), status);
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException();
                        }

                    }
                    return null;
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

        public Dictionary<int, int> GetOrderIds()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();
                    var Ids = new Dictionary<int, int>();
                    SqlCommand command = new SqlCommand($"select Order_id,User_id from [dbo].[Order]", connection);


                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Ids.Add(reader.GetInt32(0), reader.GetInt32(1));
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

        public string GetOrderSize(int Item_id)
        {
            if (Item_id == 0)
            {
                throw new ArgumentNullException(nameof(Item_id), "The user object cannot be null.");
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();
                    var Size = new List<string>();
                    SqlCommand command = new SqlCommand($"select Size from [dbo].[Order_Item] where id = @ID", connection);
                    command.Parameters.AddWithValue("@ID", Item_id);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            return "No Size";
                        }
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

        public List<string> GetProductIdsInOrder(int OrderId, int id)
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
                    SqlCommand command = new SqlCommand($"select[Product_id] from Order_Item inner join [dbo].[Order] as o on o.Order_id = Order_Item.Order_id where User_id =  @ID and o.Order_id = @Orderid", connection);
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Orderid", OrderId);

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

        public List<Cart_Item> GetProductsInOrder(List<Product> products, int orderId, int id)
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

                        SqlCommand command = new SqlCommand("SELECT Quantity, [id], Product_id FROM Order_Item INNER JOIN [dbo].[Order] as o ON Order_Item.Order_id = o.Order_id  WHERE o.User_id = @ID and o.Order_id = @Orderid", connection);
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Orderid", orderId);
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

        public Dictionary<string, decimal> GetProductSold()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    connection.Open();
                    var Products = new Dictionary<string, decimal>();

                    SqlCommand command = new SqlCommand("SELECT Product_id, SUM(Total_Price) AS total FROM Order_Item GROUP BY Product_id;", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        Products.Add(reader.GetString(0),reader.GetDecimal(1));

                       
                    }

                    reader.Close();

                    return Products;
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
				string query = "delete from Order_Item where Product_id = @Id";
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

		public void RemoveOrder(int id)
        {
            try
            {
                string Item = " delete from Order_Item where Order_id = @id";
                string order = "delete from[dbo].[Order] where Order_id = @id";
                List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id),
            };
                base.UseDatabase(Item, parameters);
                base.UseDatabase(order, parameters);
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

        public void UpdateOrder(int id, Status status)
        {
            try
            {


                string Query = "Update [dbo].[Order] set Status = @Status where Order_id = @id";
                List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Status",status.ToString()),
                new SqlParameter("@id",id)
            };
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
    }
}
