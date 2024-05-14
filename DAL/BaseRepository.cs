using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseRepository
    {
        
        const string connectionString = @"Data Source =mssqlstud.fhict.local;Database=dbi511859_webshop;User Id=dbi511859_webshop;Password=Arsenal1";

      
		public void UseDatabase( string query, List<SqlParameter> parameters)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						foreach (SqlParameter parameter in parameters)
						{
							command.Parameters.Add(parameter);
						}
						command.ExecuteNonQuery();
					}
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

       
        public SqlDataReader OpenConnection(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public string ConnectionString { get { return connectionString; } }
    }
}

