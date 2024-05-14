using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using classes;
using classes.Managers;
using DAL;

namespace AdminOverview.Forms
{
    public partial class FavortieForm : Form
    {

        private FavoriteListManager favoriteListManager;
        private Productmanager productmanager;
        private FavoriteSorter favoriteSorter;
        public FavortieForm()
        {
            InitializeComponent();
            favoriteListManager = new FavoriteListManager(new FavoritelistRepository(), new ProductRepo(), new UserRepo());
            productmanager = new Productmanager(new ProductRepo());
            favoriteSorter = new FavoriteSorter();
            ProductsListBox.DataSource = productmanager.Products;
            FavoriteListBox.DataSource = favoriteListManager.GetFavoriteList();

        }

        private void AllProductsbtn_Click(object sender, EventArgs e)
        {
            ProductsListBox.DataSource = null;
            ProductsListBox.Items.Clear();
            ProductsListBox.DataSource = productmanager.Products;
        }

        private void SortByMostFavoritebtn_Click(object sender, EventArgs e)
        {
            Dictionary<Product, int> SortedList = new Dictionary<Product, int>();
            Dictionary<Product, int> productscount = favoriteListManager.FavoriteProductCount();

            SortedList.Clear();
            foreach (Product product in ProductsListBox.Items)
            {
                foreach (Product p in productscount.Keys.ToList())
                    if (product.ID.Trim() == p.ID.Trim())
                    {
                        SortedList.Add(product, productscount[p]);
                    }
            }

            favoriteSorter.FavoriteProductSort(SortedList);

            ProductsListBox.DataSource = null;
            ProductsListBox.Items.Clear();
            ProductsListBox.DataSource = SortedList.Keys.ToList();
        }

        private void ProductsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FavoriteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (FavoriteListBox.SelectedItem == null)
            {

            }
            else
            {
                foreach (FavoriteList f in FavoriteListBox.SelectedItems)
                    if (f.ToString() == FavoriteListBox.SelectedItem.ToString())
                    {
                        ProductsListBox.DataSource = null;
                        ProductsListBox.Items.Clear();
                        ProductsListBox.DataSource = f.GetFavoriteProducts();
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CatogriesSellerListBox.Items.Clear();
            Dictionary<Seller, int> seller = favoriteListManager.FavoriteSeller();
            favoriteSorter.FavoriteSellerSort(seller);

            foreach (var item in seller)
            {
                CatogriesSellerListBox.Items.Add($"{item.Key.Username.Trim()} + {item.Value.ToString()}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CatogriesSellerListBox.Items.Clear();
            Dictionary<Catogories, int> catogories = favoriteListManager.FavoriteCatogories();
            favoriteSorter.FavoriteCatogoriesSort(catogories);

            foreach (var item in catogories)
            {
                CatogriesSellerListBox.Items.Add($"{item.Key.ToString()} + {item.Value.ToString()}");
            }
        }

        private void FavortieForm_Load(object sender, EventArgs e)
        {

        }
    }
}
