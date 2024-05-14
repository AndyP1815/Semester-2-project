using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminOverview.Forms;

namespace AdminOverview
{
    public partial class MainForm : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public MainForm()
        {
            InitializeComponent();
            random = new Random();
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object sender)
        {
            if (sender != null)
            {
                if (currentButton != (Button)sender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)sender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    PanelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    CLoseBtn.Visible = true;
                }

            }
        }
        private void DisableButton()
        {
            foreach (Control previousbtn in PanelMenu.Controls)
            {
                if (previousbtn.GetType() == typeof(Button))
                {
                    previousbtn.BackColor = Color.FromArgb(112, 128, 144);
                    previousbtn.ForeColor = Color.Gainsboro;
                    previousbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            Labelttlt.Text = childForm.Text;
        }
        private void ProductsBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductsForms(), sender);
        }

        private void UsersBTN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserForms(), sender);
        }

        private void FavoriteBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FavortieForm(), sender);
        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new OrderForm(), sender);
        }

        private void FinanceBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FinanceForm(), sender);
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CLoseBtn_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                Reset();

            }
        }
        private void Reset()
        {
            DisableButton();
            Labelttlt.Text = "Home";
            PanelTitleBar.BackColor = Color.FromArgb(32, 178, 170);
            panelLogo.BackColor = Color.FromArgb(50, 50, 64);
            currentButton = null;
            CLoseBtn.Visible = false;
        }
    }
}
