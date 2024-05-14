namespace AdminOverview.Forms
{
    partial class FinanceForm
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
            SellerListBox = new ListBox();
            ProductListBox = new ListBox();
            ShowLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            AllSellerbtn = new Button();
            SortByRevenue = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // SellerListBox
            // 
            SellerListBox.FormattingEnabled = true;
            SellerListBox.ItemHeight = 25;
            SellerListBox.Location = new Point(566, 46);
            SellerListBox.Margin = new Padding(4);
            SellerListBox.Name = "SellerListBox";
            SellerListBox.Size = new Size(264, 529);
            SellerListBox.TabIndex = 0;
            SellerListBox.SelectedIndexChanged += SellerListBox_SelectedIndexChanged;
            // 
            // ProductListBox
            // 
            ProductListBox.FormattingEnabled = true;
            ProductListBox.ItemHeight = 25;
            ProductListBox.Location = new Point(154, 46);
            ProductListBox.Margin = new Padding(4);
            ProductListBox.Name = "ProductListBox";
            ProductListBox.Size = new Size(225, 529);
            ProductListBox.TabIndex = 1;
            // 
            // ShowLabel
            // 
            ShowLabel.AutoSize = true;
            ShowLabel.Location = new Point(975, 165);
            ShowLabel.Margin = new Padding(4, 0, 4, 0);
            ShowLabel.Name = "ShowLabel";
            ShowLabel.Size = new Size(0, 25);
            ShowLabel.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(660, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 3;
            label1.Text = "Seller";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(206, 12);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 4;
            label2.Text = "Products";
            // 
            // AllSellerbtn
            // 
            AllSellerbtn.Location = new Point(425, 75);
            AllSellerbtn.Margin = new Padding(4);
            AllSellerbtn.Name = "AllSellerbtn";
            AllSellerbtn.Size = new Size(118, 36);
            AllSellerbtn.TabIndex = 5;
            AllSellerbtn.Text = "All Sellers";
            AllSellerbtn.UseVisualStyleBackColor = true;
            AllSellerbtn.Click += AllSellerbtn_Click;
            // 
            // SortByRevenue
            // 
            SortByRevenue.Location = new Point(425, 155);
            SortByRevenue.Margin = new Padding(4);
            SortByRevenue.Name = "SortByRevenue";
            SortByRevenue.Size = new Size(118, 65);
            SortByRevenue.TabIndex = 6;
            SortByRevenue.Text = "Sort Revenue";
            SortByRevenue.UseVisualStyleBackColor = true;
            SortByRevenue.Click += SortByRevenue_Click;
            // 
            // button3
            // 
            button3.Location = new Point(15, 75);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(118, 71);
            button3.TabIndex = 7;
            button3.Text = "All Products";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(15, 165);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(118, 66);
            button4.TabIndex = 8;
            button4.Text = "Sort Sold Products";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(954, 46);
            button5.Margin = new Padding(4);
            button5.Name = "button5";
            button5.Size = new Size(118, 65);
            button5.TabIndex = 9;
            button5.Text = "Total Revenue";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // FinanceForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1192, 646);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(SortByRevenue);
            Controls.Add(AllSellerbtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ShowLabel);
            Controls.Add(ProductListBox);
            Controls.Add(SellerListBox);
            Margin = new Padding(4);
            Name = "FinanceForm";
            Text = "FinanceForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox SellerListBox;
        private ListBox ProductListBox;
        private Label ShowLabel;
        private Label label1;
        private Label label2;
        private Button AllSellerbtn;
        private Button SortByRevenue;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}