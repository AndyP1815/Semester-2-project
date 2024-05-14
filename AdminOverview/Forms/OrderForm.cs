using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using classes;
using classes.Managers;
using DAL;

namespace AdminOverview.Forms
{
    public partial class OrderForm : Form
    {
        private OrderManager orderManager;
        private FinanceSorter financeSorter;
        public List<Order> orders = new List<Order>();
        public OrderForm()
        {
            InitializeComponent();
            this.orderManager = new OrderManager(new OrderRepository(), new ProductRepo());
            this.financeSorter = new FinanceSorter();
            orders = orderManager.GetAllOrders();
            LoadOrders();



        }

        public void LoadOrders()
        {
            listBoxOrders.DataSource = null;

            listBoxOrders.DataSource = orders;


        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

        }

        private void AllOrderBtn_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void ListBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<Cart_Item> itemsToModify = ListBoxProducts.Items.Cast<Cart_Item>().ToList();

            foreach (Cart_Item c in itemsToModify)
            {
                if (ReferenceEquals(c, ListBoxProducts.SelectedItem))
                {
                    labelShow.Text = $"Name: {c.Product.ProductName} - Price: {c.Product.Price}";
                }
            }



        }

        private void ChangeStatus_Click(object sender, EventArgs e)
        {
            List<Order> items = listBoxOrders.Items.Cast<Order>().ToList();
            foreach (Order order in items)
            {
                if (ReferenceEquals(order,listBoxOrders.SelectedItem))
                {
                    if(StatusCMBX.SelectedIndex <0)
                    {
                        MessageBox.Show("Please select something");
                    }
                    if(order.Status == Status.Delivered)
                    {
                        MessageBox.Show("You cannot change the status");
                    }
                    else
                    {
                        order.ChangeStatus(StatusCMBX.SelectedIndex);
                        orderManager.UpdateOrder(order.OrderID, order.Status);
                        LoadOrders();
                    }
                    
                }
            }
        }

        private void SortByPrice_Click(object sender, EventArgs e)
        {
            if (listBoxOrders.Items.Count == 0)
            {
                MessageBox.Show("There are no items in the ListBox.");
            }
            else
            {
                List<Order> orders = listBoxOrders.Items.Cast<Order>().ToList();
                if (orders == null)
                {
                    MessageBox.Show("The data source is not a list of products.");
                }
                else
                {
                    financeSorter.SortByOrderPrice(orders);
                    listBoxOrders.DataSource = orders;
                }
            }
        }

        private void listBoxOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxProducts.DataSource = null;
            foreach (Order order in orders)
            {

                if (listBoxOrders.SelectedItem == order)
                {

                    ListBoxProducts.DataSource = order.Products;
                    OrderLabel.Text = order.Status.ToString();
                }
            }
        }
    }
}
