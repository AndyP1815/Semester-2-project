using System.Data.SqlClient;
using System.Text;
using classes;
using classes.Managers;
using DAL;


namespace AdminOverview
{
	public partial class ProductsForms : Form
	{
		Productmanager productmanager = new Productmanager(new ProductRepo());
		ProductSorter productSorter = new ProductSorter(new ProductRepo());



		public ProductsForms()
		{
			InitializeComponent();
			Text = "Products";
			try
			{
				ProducctListbox.DataSource = productmanager.Products;

				//foreach (Product product in products)
				//{
				//	ProducctListbox.Items.Add(product.ProductName);
				//}
			}
			catch (SqlException ex)
			{

				MessageBox.Show(ex.ToString());
			}
			catch (Exception ex)
			{
				MessageBox.Show("There is a error retrieving information + Error" + ex.Message);
			}

		}


		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void ProducctListbox_SelectedIndexChanged(object sender, EventArgs e)
		{




		}

		private void Filter_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click_1(object sender, EventArgs e)
		{

		}





		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void ProducctListbox_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			if (ProducctListbox.SelectedItem != null)
			{
				foreach (Product p in ProducctListbox.Items)
				{
					if (p.ToString() == ProducctListbox.SelectedItem.ToString())
					{
						Seeinfolabel3.Text = p.SeeInfo();
					}

				}
			}
			else
			{

			}
		}


		private void FilterByNameTxtbx_TextChanged(object sender, EventArgs e)
		{

		}





		private void SortByIdBtn_Click_1(object sender, EventArgs e)
		{
			if (ProducctListbox.Items.Count == 0)
			{
				MessageBox.Show("There are no items in the ListBox.");
			}
			else
			{
				List<Product> products = ProducctListbox.Items.Cast<Product>().ToList();
				if (products == null)
				{
					MessageBox.Show("The data source is not a list of products.");
				}
				else
				{
					productSorter.SortById(products);
					ProducctListbox.DataSource = products;
				}

			}
		}
		private void Filter_Click_2(object sender, EventArgs e)
		{
			ProducctListbox.DataSource = null;
            string product = comboBoxPorducts.SelectedValue?.ToString() ?? "";



            List<Product> products = productSorter.CatogriesFilter(productSorter.FilterProduct(product), comboBoxCatogories.SelectedIndex);

			if (String.IsNullOrEmpty(FilterByNameTxtbx.Text))
			{
				ProducctListbox.DataSource = products;
			}
			else
			{
				Product p = productSorter.Productname(products, FilterByNameTxtbx.Text);
				if (p != null)
				{
					ProducctListbox.Items.Add(p);
				}
				else
				{
					MessageBox.Show("No product found with that name");
				}
			}
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			Product product = productmanager.GetProductByInt(ProductInt.Text);
			if (product != null)
			{
				ProducctListbox.DataSource = null;
				ProducctListbox.Items.Add(product);
			}
			else
			{
				MessageBox.Show("Product not found.");
			}
		}

		private void SortyByPricePbtn_Click(object sender, EventArgs e)
		{
			if (ProducctListbox.Items.Count == 0)
			{
				MessageBox.Show("There are no items in the ListBox.");
			}
			else
			{
				List<Product> products = ProducctListbox.Items.Cast<Product>().ToList();
				if (products == null)
				{
					MessageBox.Show("The data source is not a list of products.");
				}
				else
				{
					products.Sort();
					ProducctListbox.DataSource = products;
				}
			}
		}

		private void ProducctListbox_SelectedIndexChanged_2(object sender, EventArgs e)
		{

		}

		private void ProductsForms_Load(object sender, EventArgs e)
		{

		}

		private void DelteBtn_Click(object sender, EventArgs e)
		{

		}
	}
}