using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using classes;


namespace DAL
{
    public class ProductRepo : BaseRepository, IProductRepo
    {
        List<Product> products = new List<Product>();

        public ProductRepo()
        {
            products = GetProducts();

        }

        public List<Product> GetPosters()
        {
            try {
                List<Product> posters = new List<Product>();
                string Query = @"SELECT p.Product_id, p.Product_Name, p.Description, p.Image_Url, p.Price, cp.Catogories_id, po.Poster_Direction 
                                                  FROM Product p 
                                                  INNER JOIN Poster po ON p.Product_id = po.Product_id 
                                                  INNER JOIN Catogories_Product cp ON p.Product_id = cp.Product_id 
                                                  INNER JOIN Catogories c ON cp.Catogories_id = c.Catogories_id 
                                                  ORDER BY p.Product_id";
                using (SqlDataReader reader = base.OpenConnection(Query))
                {
                    while (reader.Read())
                    {
                        string id = reader.GetString(0).Trim();

                        Poster poster = (Poster)posters.FirstOrDefault(o => o.ID == id);
                        if (poster == null)
                        {
                            poster = new Poster(id,
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetDecimal(4),
                                reader.GetString(3),
                                reader.GetString(6));
                            posters.Add(poster);
                        }

                        poster.AddCatogories((Catogories)Enum.GetValues(typeof(Catogories)).GetValue(reader.GetInt32(5) - 1));
                    }
                }
                return posters;
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

        public List<Product> GetBooks()
        {
            try {
                List<Product> books = new List<Product>();
                string Query = "SELECT Product.Product_id, Product_Name, Product.Description, Image_Url, Price, Pages, Catogories.Catogories_id, DownloadUrl, Has_Option FROM Product " +
                    "INNER JOIN Books ON Product.Product_id = Books.Product_id INNER JOIN Catogories_Product ON Product.Product_id = Catogories_Product.Product_id INNER JOIN Catogories ON Catogories_Product.Catogories_id = Catogories.Catogories_id" +
                    " LEFT JOIN EBook ON Books.Book_id = EBook.book_id";

                using (SqlDataReader reader = base.OpenConnection(Query))
                {
                    while (reader.Read())
                    {
                        string id = reader.GetString(0).Trim();

                        Books book = (Books)books.FirstOrDefault(o => o.ID == id);
                        if (book == null)
                        {
                            book = new Books(
                                id,
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetDecimal(4),
                                reader.GetString(3),
                                reader.GetInt32(5),
                                reader.GetBoolean(8));

                        }

                        book.AddCatogories((Catogories)Enum.GetValues(typeof(Catogories)).GetValue(reader.GetInt32(6) - 1));


                        string downloadLink = reader.GetValue(7).ToString();
                        if (!reader.IsDBNull(7))
                        {
                            Ebook ebook = new Ebook(book, downloadLink);
                            books.Add(ebook);
                        }
                        else
                        {
                            books.Add(book);
                        }
                    }
                }
                return books;
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

        public List<Product> GetFigures()
        {
            try {
                List<Product> figures = new List<Product>();
                string query = "SELECT P.Product_id, P.Product_Name, P.Description, P.Image_Url, P.Price, F.Dimension, CP.Catogories_id " +
                               "FROM Product P " +
                               "INNER JOIN Figures F ON P.Product_id = F.Product_id " +
                               "INNER JOIN Catogories_Product CP ON P.Product_id = CP.Product_id " +
                               "INNER JOIN Catogories C ON CP.Catogories_id = C.Catogories_id " +
                               "ORDER BY P.Product_id";
                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {

                    using (SqlDataReader reader = base.OpenConnection(query))
                    {
                        while (reader.Read())
                        {
                            string id = reader.GetValue(0).ToString().Trim();

                            Figures figure = (Figures)figures.FirstOrDefault(o => o.ID == id);
                            if (figure == null)
                            {
                                figure = new Figures(id,
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetDecimal(4),
                                reader.GetString(3),
                                reader.GetString(5));
                                figures.Add(figure);
                            }

                            figure.AddCatogories((Catogories)Enum.GetValues(typeof(Catogories)).GetValue(Convert.ToInt32(reader.GetValue(6)) - 1));

                        }
                    }
                }
                return figures;
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

        public List<Product> GetClothes()
        {
            try {
                List<Product> clothes = new List<Product>();
                string query = "Select product.Product_id,Product_Name,product.Description,Image_Url,Price,Catogories.Catogories_id from Product inner join Clothing on Product.Product_id = Clothing.Product_id inner join Catogories_Product on Product.Product_id = Catogories_Product.Product_id inner join Catogories on Catogories_product.Catogories_id = Catogories.Catogories_id order by product.Product_id";
                using (SqlDataReader C = OpenConnection(query))
                {
                    while (C.Read())
                    {
                        string id = C.GetValue(0).ToString().Trim();

                        Clothing clothing = (Clothing)clothes.FirstOrDefault(o => o.ID == id);
                        if (clothing == null)
                        {
                            clothing = new Clothing(id,
                            C.GetValue(1).ToString(),
                            C.GetValue(2).ToString(),
                            Convert.ToDecimal(C.GetValue(4)),
                            C.GetValue(3).ToString());
                            clothes.Add(clothing);
                        }

                        clothing.AddCatogories(((Catogories)Enum.GetValues(typeof(Catogories)).GetValue(Convert.ToInt32(C.GetValue(5)) - 1)));
                    }
                }

                return clothes;
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


        public List<Product> GetProducts()
        {
            List<Product> Allproducts = new List<Product>();
            foreach (Figures f in GetFigures())
            {
                Allproducts.Add(f);
            }
            foreach (Books b in GetBooks())
            {
                Allproducts.Add(b);
            }

            foreach (Poster p in GetPosters())
            {
                Allproducts.Add(p);
            }

            foreach (Clothing c in GetClothes())
            {
                Allproducts.Add(c);
            }
            return Allproducts;


        }
        public Product GetProductByInt(string id)
        {
            foreach (Product p in products)
                if (id.Trim() == p.ID.Trim())
                {
                    return p;
                }
            throw new NullReferenceException();
        }

        public void CreateProduct(Product product,int User_id)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "There is problem with this product");
            }
            try {

                string query = "insert into Product values((select count(*) from (SELECT * FROM Product WHERE RIGHT(TRIM(product_id), 1) != 'E') as Id)+ 1, @ProductName, @Description, @Url, @Price);";
                List<SqlParameter> parameters = new List<SqlParameter>
    {

        new SqlParameter("@ProductName", product.ProductName),
        new SqlParameter("@Description", product.Description),
        new SqlParameter("@Url", product.Url),
        new SqlParameter("@Price", product.Price)
    };
                base.UseDatabase(query, parameters);

                foreach (Catogories c in product.Catogories)
                {
                    string catQuery = "insert into catogories_product values((SELECT MAX(id) FROM catogories_product) + 1 ,@CategoryID, (select count(*) from (SELECT * FROM Product WHERE RIGHT(TRIM(product_id), 1) != 'E') as Id));";
                    List<SqlParameter> catParameters = new List<SqlParameter>
        {
            new SqlParameter("@CategoryID", (int)c+1),
        };
                    base.UseDatabase(catQuery, catParameters);
                }
                string queryInsert = "insert into Seller_Product values ((select max(id) from Seller_Product)+ 1,(select Seller_id from Seller where User_id = @User_Id),(select count(*) from (SELECT * FROM Product WHERE RIGHT(TRIM(product_id), 1) != 'E') as Id))";
                List<SqlParameter> Parameters = new List<SqlParameter>()
    {
        new SqlParameter("@User_Id",User_id)
        

    };
                base.UseDatabase(queryInsert, Parameters);
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

        public void CreatePoster(Poster poster, int id)
        {
			if (poster == null)
			{
				throw new ArgumentNullException(nameof(poster), "There is problem with this product");
			}
			CreateProduct(poster,id);

            try
            {
                string query = "INSERT INTO Poster VALUES ((SELECT MAX(Poster_id) FROM Poster) + 1, @Direction,  (select count(*) from (SELECT * FROM Product WHERE RIGHT(TRIM(product_id), 1) != 'E') as Id))";
                List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@Direction", poster.PosterDirection),

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

        public void CreateBooks(Books book,int id)
        {
			if (book == null)
			{
				throw new ArgumentNullException(nameof(book), "There is problem with this product");
			}
			try
            {
                {
                    CreateProduct(book,id);

                    int ebookAsInt = book.Ebook ? 1 : 0;

                    string query = "INSERT INTO Books (Book_id, Pages, Has_Option, Product_id) VALUES ((SELECT MAX(Book_id) FROM Books) + 1, 12, 0, (select count(*) from (SELECT * FROM Product WHERE RIGHT(TRIM(product_id), 1) != 'E') as Id));";

                    List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@pages", book.Pages),
        new SqlParameter("@ebook", ebookAsInt),
   
    };

                    base.UseDatabase(query, parameters);
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

        public void CreateClothes(Clothing clothing, int id)
        {
			if (clothing == null)
			{
				throw new ArgumentNullException(nameof(clothing), "There is problem with this product");
			}
			try {
                CreateProduct(clothing,id);
                string query = "INSERT INTO Clothing (Clothing_id, Product_id) VALUES ((SELECT MAX(Clothing_id) FROM Clothing) + 1,(select count(*) from (SELECT * FROM Product WHERE RIGHT(TRIM(product_id), 1) != 'E') as Id));";
                List<SqlParameter> parameters = new List<SqlParameter>
    {
       
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


        public void CreateFigures(Figures figures, int id)
        {
			if (figures == null)
			{
				throw new ArgumentNullException(nameof(figures), "There is problem with this product");
			}
			try
            {
                CreateProduct(figures,id);
                int boolInsert = figures.Colored ? 1 : 0;

                string query = "INSERT INTO Figures VALUES " +
                               "((SELECT MAX(Figures_id) FROM Figures) + 1, @Dimensions, (select count(*) from (SELECT * FROM Product WHERE RIGHT(TRIM(product_id), 1) != 'E') as Id))";

                List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@Dimensions", figures.Dimensions),
  
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

			public void UpdateProduct(string id,Product product)
        {
			try
            {
                string UpdateProduct = "update Product " +
                      "set Product_Name = @ProductName,Description = @Description,Image_URL = @Image_Url,Price = @price " +
                      "where Product_id = @id";

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@ProductName",product.ProductName),
                    new SqlParameter("@Description",product.Description),
                    new SqlParameter("@Image_Url",product.Url),
                    new SqlParameter("@price",product.Price),
                    new SqlParameter("@id",id)
                };

                base.UseDatabase(UpdateProduct,parameters);

                List<SqlParameter> parametersSubClasses = new List<SqlParameter>
                {
                    new SqlParameter("@id",id)
                };
                if (product is Poster)
                {
                    string queryposter = "update Poster set Poster_Direction = @Direction where Product_id = @id";
                    parametersSubClasses.Add(new SqlParameter("@Direction", ((Poster)product).PosterDirection));
                    base.UseDatabase(queryposter,parametersSubClasses);
                }
                if(product is Books)
                {
                    string queryBooks = "update Books set Pages = @Pages where Product_id = @id";
                    parametersSubClasses.Add(new SqlParameter("@Pages", ((Books)product).Pages));
                    base.UseDatabase(queryBooks, parametersSubClasses);
                    if (product is Ebook)
                    {
                        string queryEbooks = "update EBook set DownloadUrl = @Url where Book_id = (Select Book_id from Books where Product_id = @id)";
                        parametersSubClasses.Add(new SqlParameter("@Url", ((Ebook)product).Url));
                        base.UseDatabase(queryEbooks, parametersSubClasses);
                    }
                }
                if(product is Figures)
                {
                    string queryFigures = "update Figures set Dimension = @Dimensions where Product_id = @id";
                    parametersSubClasses.Add(new SqlParameter("@Dimensions", ((Figures)product).Dimensions));
                    base.UseDatabase(queryFigures, parametersSubClasses);
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

        public void RemoveProduct(string id)
        {
			try
			{
				string productQuery = "DELETE FROM Product WHERE Product_id = @Id";
				List<string> queries = new List<string>
	{
		"DELETE FROM EBook WHERE Book_id = (SELECT Book_id FROM Books WHERE Product_id = @Id)",
		"DELETE FROM Figures WHERE Product_id = @Id",
		"DELETE FROM Clothing WHERE Product_id = @Id",
		"DELETE FROM Poster WHERE Product_id = @Id",
		"DELETE FROM Books WHERE Product_id = @Id",
		"DELETE FROM [dbo].[Seller_Product] WHERE Product_id = @Id",
		"DELETE FROM Catogories_Product WHERE Product_id = @Id"
	};

				List<SqlParameter> parameters = new List<SqlParameter>
	{
		new SqlParameter("@Id", id)
	};

				foreach (string query in queries)
				{
					List<SqlParameter> queryParameters = new List<SqlParameter>
		{
			new SqlParameter("@Id", id)
		};

					base.UseDatabase(query, queryParameters);
				}

				base.UseDatabase(productQuery, parameters);
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

		public List<Catogories> GetCatogoriesForProduct(int ProductId)
        {
            if(ProductId < 0)
            {
                throw new ArgumentNullException("The product Id cannot be 0 or a minus number");
            }
            try
            {
                List<Catogories> catogories = new List<Catogories>();
                SqlDataReader CatogoriesReader = base.OpenConnection($"Select [Catogories_id] from [dbo].[catogories_product] where Product_id = {ProductId}");
                while (CatogoriesReader.Read())
                {
                    catogories.Add((Catogories)CatogoriesReader.GetValue(0));
                }

                return catogories;
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

  //      public void CreateEBooks(Ebook ebook, int id)
  //      {
		//	if (ebook == null)
		//	{
		//		throw new ArgumentNullException(nameof(ebook), "There is problem with this product");
		//	}
		//	try
  //          {

  //              CreateBooks(ebook,id);
  //              string query = "INSERT INTO EBook VALUES ((SELECT MAX(Ebook_id) FROM EBook) + 1,(select Book_id from Books where Product_id = (SELECT REPLACE(Product_id, 'E', '') from Product where Product_id = '37E')),@Download)";
  //              List<SqlParameter> parameters = new List<SqlParameter>()
  //  {
  //      new SqlParameter("@Download", ebook.DownloadLink),
  //  };
  //              base.UseDatabase(query, parameters);
  //          }
		//	catch (SqlException ex)
		//	{
		//		throw new InvalidOperationException("There is a problem with the database: " + ex.Message, ex);
		//	}
		//	catch (Exception ex)
		//	{
		//		throw new ArgumentException("There is an error: " + ex.Message, ex);
		//	}
		//}

       
    }
    }
