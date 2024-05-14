using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes.Comparers;
using classes.Managers;


namespace classes
{
    public class ProductSorter
    {
        private Productmanager productmanager { get; set; }
        private IProductRepo productRepo { get; set; }
        private IComparer<Product> CompareById;

        public ProductSorter(IProductRepo ProductRepo)
        {
            this.productRepo = ProductRepo;
            this.productmanager = new Productmanager(productRepo);

        }
        public List<Product> FilterProduct(string Products)
        {
            
            List<Product> ProductList;

            if (Products  == "")
            {
                ProductList = productmanager.Products;
                return ProductList;
            }
            else if (Products == "Posters")
            {
                ProductList = productmanager.GetPosters();
                return ProductList;
            }
            else if (Products == "Books")
            {
                ProductList = productmanager.GetBooks();
                return ProductList;
            }
            else if (Products == "Clothing")
            {
                ProductList = productmanager.GetClothes();
                return ProductList;
            }
            else if (Products == "Figures")
            {
                ProductList = productmanager.GetFigures();
                return ProductList;

            }

            else
            {
                throw new IndexOutOfRangeException();
            }

        }
        public List<Product> CatogriesFilter(List<Product> products, int catogoriesI)
        {
            try
            {
                List<Product> returnProduct = new List<Product>();
                if (catogoriesI == 0 ^ catogoriesI == -1)
                {
                    return products;
                }
                if (catogoriesI > 8 ^ catogoriesI < -1)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    foreach (Product product in products)
                        if (product.Catogories.Contains((Catogories)catogoriesI - 1))
                        {
                            returnProduct.Add(product);
                        }
                }
                return returnProduct;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public Product Productname(List<Product> products, string name)
        {
            try
            {
                foreach (Product product in products)
                    if (product.ProductName.Trim() == name)
                    {
                        return product;
                    }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public void SortById(List<Product> products)
        {
            if(products == null)
            {
                throw new Exception();
            }

			if (this.CompareById == null)
				this.CompareById = new CompareById();
            products.Sort(CompareById);
		}
     
	


	}
}
