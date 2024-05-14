using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace classes.Managers
{
    public class Productmanager
    {
        private List<Product> products;
        private IProductRepo repo;
        public Productmanager(IProductRepo repo)
        {
            products = repo.GetProducts();
            this.repo = repo;
        }
		delegate List<Product> GetProducts();
		public void CreateProduct(Product product,int id)
		{
			try
			{
				if (product is Poster)
				{
					repo.CreatePoster((Poster)product, id);
				}
				if (product is Books)
				{
					//if (product is Ebook)
					//{
					//	repo.CreateEBooks((Ebook)product, id);
					//}
					//else
					//{
						repo.CreateBooks((Books)product, id);
					//}
				}
				if (product is Figures)
				{
					repo.CreateFigures((Figures)product, id);
				}
				if (product is Clothing)
				{
					repo.CreateClothes((Clothing)product, id);
				}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }


        }
		public List<Product> GetBooks()
		{
			return HandleException(() => repo.GetBooks());
		}

		public List<Product> GetClothes()
		{
			return HandleException(() => repo.GetClothes());
		}

		public List<Product> GetPosters()
		{
			return HandleException(() => repo.GetPosters());
		}

		public List<Product> GetFigures()
		{
			return HandleException(() => repo.GetFigures());
		}

		private List<Product> HandleException(GetProducts action)
		{
			try
			{
				return action.Invoke();
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
		public Product GetProductByInt(string id)
		{
			try
			{
				Product product = repo.GetProductByInt(id);
				return product;
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
		public void DeleteProduct(string id)
		{
			try
			{
				repo.RemoveProduct(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
		public void UpdateProduct(string id,Product product)
		{
			try
			{
				repo.UpdateProduct(id, product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
	

		public List<Product> Products { get { return products; } }


    }
}

