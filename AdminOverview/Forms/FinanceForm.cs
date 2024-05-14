using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using classes;
using classes.Managers;
using DAL;

namespace AdminOverview.Forms
{
    public partial class FinanceForm : Form
    {
        private Productmanager productmanager;
        private Usermanager usermanager;
        private OrderManager ordermanager;
        private FinanceSorter sorter;
        public FinanceForm()
        {
            InitializeComponent();
            productmanager = new Productmanager(new ProductRepo());
            sorter = new FinanceSorter();
            usermanager = new Usermanager(new UserRepo(), new CartRepository(), new ProductRepo());
            ordermanager = new OrderManager(new OrderRepository(),new ProductRepo());
            SellerListBox.DataSource = usermanager.GetSellers();
            ProductListBox.DataSource = productmanager.Products;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductListBox.DataSource = null;
            ProductListBox.Items.Clear();
            ProductListBox.DataSource = productmanager.Products;
        }

        private void AllSellerbtn_Click(object sender, EventArgs e)
        {
            SellerListBox.DataSource = null;
            SellerListBox.Items.Clear();
            SellerListBox.DataSource = usermanager.GetSellers();

        }

        private void SellerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductListBox.DataSource = null;
            ProductListBox.Items.Clear();
            if (SellerListBox.SelectedItem == null)
            {

            }
            else
            {
                foreach (Seller s in SellerListBox.SelectedItems)
                    if (s.ToString() == SellerListBox.SelectedItem.ToString())
                    {
                        ProductListBox.DataSource = s.Products;
                        ShowLabel.Text = s.Revenue.ToString();
                    }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowLabel.Text = sorter.GetTotalRevenue(usermanager.GetSellers()).ToString();
        }

        private void SortByRevenue_Click(object sender, EventArgs e)
        {

            List<Seller> Sellerscount = SellerListBox.Items.Cast<Seller>().ToList();

            sorter.SortSellerByrevenue(Sellerscount);

            SellerListBox.DataSource = null;
            SellerListBox.Items.Clear();
            SellerListBox.DataSource = Sellerscount;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProductListBox.DataSource = null;
            var items = ordermanager.ProductRevenue();
            sorter.SortProductRevenue(items);
           
           foreach(var item in items)
            {
                ProductListBox.Items.Add($"{item.Key.ProductName.Trim()} - ${item.Value.ToString()}");
            }


        }
    }
}
