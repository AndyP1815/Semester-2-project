using System;
using System.Security.Cryptography.X509Certificates;
using classes;
using classes.Managers;
using DAL;
using FakeDAL;

namespace TestProject
{
	[TestClass]
	public class ProductTesting
	{
		
		private Productmanager productmanager = new Productmanager(new FakeProductRepository());
		List<Product> products = new List<Product>();
		public ProductTesting()
		{
			this.products = productmanager.Products;

		}
		[TestMethod]
		public void ChangeProductSize()
		{
			foreach (Product product in products)
				if (product is Clothing)
				{
					((Clothing)product).ChangeClothingSize("L");
					Assert.AreEqual("L", ((Clothing)product).Clothsize);
				}
				else if (product is Poster)
				{
					((Poster)product).ChangeSize("L");
					Assert.AreEqual("L", ((Poster)product).Size);

				}
		}
		public void ChangeProductSizeIncorrect()
		{
            foreach (Product product in products)
                if (product is Clothing)
                {
                    string testsize = ((Poster)product).Size;
                    ((Clothing)product).ChangeClothingSize("X");
                    Assert.AreEqual(testsize, ((Clothing)product).Clothsize);
                }
                else if (product is Poster)
                {
					string testsize = ((Poster)product).Size;
                    ((Poster)product).ChangeSize("X");
                    Assert.AreEqual(testsize, ((Poster)product).Size);

                }
        }

		[TestMethod]
		public void CalculatePrice()
		{
			foreach (Product product in products)
				if (product is Clothing)
				{
					((Clothing)product).ChangeClothingSize("L");
				}

				else if (product is Poster)
				{
					((Poster)product).ChangeSize("L");


				}
			foreach (Product p in products)
			{
				if (p is Poster)
				{

					((Poster)(p)).ChangeFrame(true);
				}
				if (p is Figures)
				{

					((Figures)(p)).ChangeCollored(true);
				}
				
			}
			foreach (Product p in products)
			{
				if (p is Books)
				{
					Assert.AreEqual(p.Price, p.CalculatePrice());

				}
				else
				{
					Assert.AreNotEqual(p.Price, p.CalculatePrice());
				}
			}

		}
		
        }

	}
		
	
