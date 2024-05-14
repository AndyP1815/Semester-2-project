using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes;


namespace FakeDAL
{
    public class FakeProductRepository : IProductRepo
    {
        public List<Product> products = new List<Product>();
        private Product Poster1;
        private Product Book1;
        private Product Book0;
        private Product Figure;
        private Product Ebook0;
        private Product Ebook1;
        private Product Clothes;

        public FakeProductRepository()
        {	this.Clothes = new Clothing("4", "Clothing", "description", 15, "url"); Clothes.AddCatogories(Catogories.Landscape); Clothes.AddCatogories(Catogories.Animals);
            this.Figure = new Figures("3", "Figure", "description", 40, "url", "10-10-20"); Figure.AddCatogories(Catogories.Animals);
			this.Poster1 = new Poster("1", "Poster", "Description", 20, "url", "V"); Poster1.AddCatogories(Catogories.Brands);
			this.Book0 = new Books("2", "Book0", "description", 15, "url", 200, false); Book0.AddCatogories(Catogories.Countries);
			this.Book1 = new Books("5", "Book1", "description", 15, "url", 200, true);Book1.AddCatogories(Catogories.Action);
            this.Ebook1 = new Ebook("5E", "Book1", "description", 10, "url", 200, true,"Link");Ebook1.AddCatogories(Catogories.Romance);
			this.Ebook0 = new Ebook("6", "Ebook", "Description", 10, "url", 300, false, "Link");Ebook0.AddCatogories(Catogories.Science_Fiction);
            
			products.Add(Clothes);
			products.Add(Figure);
			products.Add(Poster1);
			products.Add(Book0);
			products.Add(Book1);
			products.Add(Ebook1);
			products.Add(Ebook0);




        }
        public void CreateBooks(Books Book)
        {
            throw new NotImplementedException();
        }

        public void CreateBooks(Books Book, int id)
        {
            throw new NotImplementedException();
        }

        public void CreateClothes(Clothing Clothing)
        {
            throw new NotImplementedException();
        }

        public void CreateClothes(Clothing Clothing, int id)
        {
            throw new NotImplementedException();
        }

        public void CreateEBooks(Ebook ebook)
        {
            throw new NotImplementedException();
        }

        public void CreateEBooks(Ebook ebook, int id)
        {
            throw new NotImplementedException();
        }

        public void CreateFigures(Figures Figure)
        {
            throw new NotImplementedException();
        }

        public void CreateFigures(Figures Figure, int id)
        {
            throw new NotImplementedException();
        }

        public void CreatePoster(Poster poster)
        {
            throw new NotImplementedException();
        }

        public void CreatePoster(Poster poster, int id)
        {
            throw new NotImplementedException();
        }

        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void CreateProduct(Product product, int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetBooks()
        {
            List<Product> ReturnPodruct = new List<Product>();
            foreach (Product product in products)
                if(product is Books)
            {
                    ReturnPodruct.Add(product);
            }
            return ReturnPodruct;
        }

        public List<Catogories> GetCatogoriesForProduct(int ProductId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetClothes()
        {
            List<Product> ReturnPodruct = new List<Product>();
            foreach (Product product in products)
                if (product is Clothing)
                {
                    ReturnPodruct.Add(product);
                }
            return ReturnPodruct;
        }

        public List<Product> GetFigures()
        {
            List<Product> ReturnPodruct = new List<Product>();
            foreach (Product product in products)
                if (product is Figures)
                {
                    ReturnPodruct.Add(product);
                }
            return ReturnPodruct;
        }

        public List<Product> GetPosters()
        {
            List<Product> ReturnPodruct = new List<Product>();
            foreach (Product product in products)
                if (product is Poster)
                {
                    ReturnPodruct.Add(product);
                }
            return ReturnPodruct;
        }

        public Product GetProductByInt(string id)
        {
            foreach(Product p in products)
                if(p.ID.Trim() == id.Trim())
            {
                    return p;
            }
            return null; 
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void RemoveProduct(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(string id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
