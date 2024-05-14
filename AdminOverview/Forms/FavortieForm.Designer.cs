namespace AdminOverview.Forms
{
    partial class FavortieForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FavoriteListBox = new ListBox();
            ProductsListBox = new ListBox();
            label1 = new Label();
            label2 = new Label();
            AllProductsbtn = new Button();
            CatogriesSellerListBox = new ListBox();
            button2 = new Button();
            button3 = new Button();
            SortByMostFavoritebtn = new Button();
            SuspendLayout();
            // 
            // FavoriteListBox
            // 
            FavoriteListBox.FormattingEnabled = true;
            FavoriteListBox.ItemHeight = 25;
            FavoriteListBox.Location = new Point(48, 65);
            FavoriteListBox.Margin = new Padding(4);
            FavoriteListBox.Name = "FavoriteListBox";
            FavoriteListBox.Size = new Size(270, 579);
            FavoriteListBox.TabIndex = 0;
            FavoriteListBox.SelectedIndexChanged += FavoriteListBox_SelectedIndexChanged;
            // 
            // ProductsListBox
            // 
            ProductsListBox.FormattingEnabled = true;
            ProductsListBox.ItemHeight = 25;
            ProductsListBox.Location = new Point(510, 65);
            ProductsListBox.Margin = new Padding(4);
            ProductsListBox.Name = "ProductsListBox";
            ProductsListBox.Size = new Size(286, 579);
            ProductsListBox.TabIndex = 1;
            ProductsListBox.SelectedIndexChanged += ProductsListBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(114, 24);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 2;
            label1.Text = "FavortieList";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(600, 36);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 3;
            label2.Text = "Products";
            // 
            // AllProductsbtn
            // 
            AllProductsbtn.Location = new Point(374, 79);
            AllProductsbtn.Margin = new Padding(4);
            AllProductsbtn.Name = "AllProductsbtn";
            AllProductsbtn.Size = new Size(118, 70);
            AllProductsbtn.TabIndex = 4;
            AllProductsbtn.Text = "All Products";
            AllProductsbtn.UseVisualStyleBackColor = true;
            AllProductsbtn.Click += AllProductsbtn_Click;
            // 
            // CatogriesSellerListBox
            // 
            CatogriesSellerListBox.FormattingEnabled = true;
            CatogriesSellerListBox.ItemHeight = 25;
            CatogriesSellerListBox.Location = new Point(970, 65);
            CatogriesSellerListBox.Margin = new Padding(4);
            CatogriesSellerListBox.Name = "CatogriesSellerListBox";
            CatogriesSellerListBox.Size = new Size(203, 579);
            CatogriesSellerListBox.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(845, 96);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(118, 36);
            button2.TabIndex = 6;
            button2.Text = "Sellers";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(845, 174);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(118, 36);
            button3.TabIndex = 7;
            button3.Text = "catogories";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // SortByMostFavoritebtn
            // 
            SortByMostFavoritebtn.Location = new Point(374, 174);
            SortByMostFavoritebtn.Margin = new Padding(4);
            SortByMostFavoritebtn.Name = "SortByMostFavoritebtn";
            SortByMostFavoritebtn.Size = new Size(118, 65);
            SortByMostFavoritebtn.TabIndex = 8;
            SortByMostFavoritebtn.Text = "favorite sort";
            SortByMostFavoritebtn.UseVisualStyleBackColor = true;
            SortByMostFavoritebtn.Click += SortByMostFavoritebtn_Click;
            // 
            // FavortieForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 681);
            Controls.Add(SortByMostFavoritebtn);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(CatogriesSellerListBox);
            Controls.Add(AllProductsbtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ProductsListBox);
            Controls.Add(FavoriteListBox);
            Margin = new Padding(4);
            Name = "FavortieForm";
            Text = "FavortieForm";
            Load += FavortieForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox FavoriteListBox;
        private ListBox ProductsListBox;
        private Label label1;
        private Label label2;
        private Button AllProductsbtn;
        private ListBox CatogriesSellerListBox;
        private Button button2;
        private Button button3;
        private Button SortByMostFavoritebtn;
    }
}