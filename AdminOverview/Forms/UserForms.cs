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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AdminOverview.Forms
{
    public partial class UserForms : Form
    {
        private Usermanager usermanager; 
        private UserSorter userSorter;


        public UserForms()
        {
            InitializeComponent();
            this.usermanager = new Usermanager(new UserRepo(), new CartRepository(), new ProductRepo());
            this. userSorter = new UserSorter(new UserRepo(), new CartRepository(), new ProductRepo());
            ListBoxUsers.DataSource = usermanager.GetAllUser();
        }

        private void UserForms_Load(object sender, EventArgs e)
        {

        }

        private void GetByUserIdbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string userInput = UseridTxtbox.Text;
                bool isInteger = int.TryParse(userInput, out int result);
                if (isInteger)
                {
                    User user = usermanager.GetUserById(Convert.ToInt32(UseridTxtbox.Text));

                    ListBoxUsers.DataSource = null;
                    ListBoxUsers.Items.Add(user);


                }

                else
                {
                    MessageBox.Show("Please fill in a number.");
                }
            }catch (Exception ex)
            {
                MessageBox.Show("nothing found");
            }

        }

        private void Filterbtn_Click(object sender, EventArgs e)
        {
            ListBoxUsers.DataSource = null;
            List<User> users = userSorter.FilterUser(UserCombobox.SelectedIndex);

            if (String.IsNullOrEmpty(Nametxtbox.Text))
            {
                ListBoxUsers.DataSource = users;
            }
            else
            {
                if (userSorter.GetUserByName(users, Nametxtbox.Text) == null)
                {
                    MessageBox.Show("There is no User with that name");
                }
                else
                {
                    ListBoxUsers.Items.Add(userSorter.GetUserByName(users, Nametxtbox.Text));
                }
            }

        }

        private void SortByIdBtn_Click(object sender, EventArgs e)
        {
            List<User> users = ListBoxUsers.Items.Cast<User>().ToList();
            ListBoxUsers.DataSource = null;
            users.Sort();
            ListBoxUsers.DataSource = users;
        }

        private void SortByName_Click(object sender, EventArgs e)
        {
            List<User> users = ListBoxUsers.Items.Cast<User>().ToList();
            ListBoxUsers.DataSource = null;
            userSorter.SortUserByName(users);
            ListBoxUsers.DataSource = users;
        }

        private void ListBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
