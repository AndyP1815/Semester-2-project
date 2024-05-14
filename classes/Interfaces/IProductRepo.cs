

namespace classes
{
	public interface IProductRepo
	{

		List<Product> GetProducts();
		List<Product> GetPosters();
		List<Product> GetBooks();
		List<Product> GetClothes();
		List<Product> GetFigures();
		List<Catogories> GetCatogoriesForProduct(int ProductId);
		Product GetProductByInt(string id);
		void CreateProduct(Product product,int id);
		void CreatePoster(Poster poster, int id);
		void CreateBooks(Books Book, int id);
		//void CreateEBooks(Ebook ebook, int id);
		void CreateClothes(Clothing Clothing, int id);
		void CreateFigures(Figures Figure, int id);
		void UpdateProduct(string id,Product product);
		void RemoveProduct(string id);
		
		
	
		



	}
}
