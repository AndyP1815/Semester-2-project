namespace AdminOverview
{
	partial class ProductsForms
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			ProducctListbox = new ListBox();
			comboBoxCatogories = new ComboBox();
			FilterByNameTxtbx = new TextBox();
			Filter = new Button();
			ProductInt = new TextBox();
			button2 = new Button();
			SeeInfoLabel = new Label();
			comboBoxPorducts = new ComboBox();
			label1 = new Label();
			label2 = new Label();
			ID = new Label();
			Seeinfolabel3 = new Label();
			SortyByPricePbtn = new Button();
			SortByIdBtn = new Button();
			label3 = new Label();
			SuspendLayout();
			// 
			// ProducctListbox
			// 
			ProducctListbox.FormattingEnabled = true;
			ProducctListbox.ItemHeight = 25;
			ProducctListbox.Location = new Point(450, 11);
			ProducctListbox.Margin = new Padding(2);
			ProducctListbox.Name = "ProducctListbox";
			ProducctListbox.Size = new Size(372, 654);
			ProducctListbox.TabIndex = 0;
			ProducctListbox.SelectedIndexChanged += ProducctListbox_SelectedIndexChanged_2;
			// 
			// comboBoxCatogories
			// 
			comboBoxCatogories.FormattingEnabled = true;
			comboBoxCatogories.Items.AddRange(new object[] { "", "Action", "Romance", "Science_Fiction", "Old_Schools", "Brands", "Countries", "Animals", "Landscape" });
			comboBoxCatogories.Location = new Point(210, 120);
			comboBoxCatogories.Margin = new Padding(2);
			comboBoxCatogories.Name = "comboBoxCatogories";
			comboBoxCatogories.Size = new Size(182, 33);
			comboBoxCatogories.TabIndex = 1;
			// 
			// FilterByNameTxtbx
			// 
			FilterByNameTxtbx.Location = new Point(264, 52);
			FilterByNameTxtbx.Margin = new Padding(2);
			FilterByNameTxtbx.Name = "FilterByNameTxtbx";
			FilterByNameTxtbx.Size = new Size(182, 31);
			FilterByNameTxtbx.TabIndex = 2;
			// 
			// Filter
			// 
			Filter.Location = new Point(48, 52);
			Filter.Margin = new Padding(2);
			Filter.Name = "Filter";
			Filter.Size = new Size(112, 34);
			Filter.TabIndex = 3;
			Filter.Text = "Filter";
			Filter.UseVisualStyleBackColor = true;
			Filter.Click += Filter_Click_2;
			// 
			// ProductInt
			// 
			ProductInt.Location = new Point(214, 262);
			ProductInt.Margin = new Padding(2);
			ProductInt.Name = "ProductInt";
			ProductInt.Size = new Size(182, 31);
			ProductInt.TabIndex = 4;
			// 
			// button2
			// 
			button2.Location = new Point(35, 262);
			button2.Margin = new Padding(2);
			button2.Name = "button2";
			button2.Size = new Size(159, 34);
			button2.TabIndex = 5;
			button2.Text = "Get product";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click_1;
			// 
			// SeeInfoLabel
			// 
			SeeInfoLabel.AutoSize = true;
			SeeInfoLabel.Location = new Point(858, 24);
			SeeInfoLabel.Margin = new Padding(2, 0, 2, 0);
			SeeInfoLabel.Name = "SeeInfoLabel";
			SeeInfoLabel.Size = new Size(0, 25);
			SeeInfoLabel.TabIndex = 6;
			// 
			// comboBoxPorducts
			// 
			comboBoxPorducts.FormattingEnabled = true;
			comboBoxPorducts.Items.AddRange(new object[] { "", "Posters", "Books", "Clothing", "Figures" });
			comboBoxPorducts.Location = new Point(210, 182);
			comboBoxPorducts.Margin = new Padding(2);
			comboBoxPorducts.Name = "comboBoxPorducts";
			comboBoxPorducts.Size = new Size(182, 33);
			comboBoxPorducts.TabIndex = 7;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(59, 124);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(98, 25);
			label1.TabIndex = 8;
			label1.Text = "Catogories";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(59, 186);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(74, 25);
			label2.TabIndex = 9;
			label2.Text = "Product";
			// 
			// ID
			// 
			ID.AutoSize = true;
			ID.Location = new Point(292, 236);
			ID.Margin = new Padding(4, 0, 4, 0);
			ID.Name = "ID";
			ID.Size = new Size(30, 25);
			ID.TabIndex = 10;
			ID.Text = "ID";
			// 
			// Seeinfolabel3
			// 
			Seeinfolabel3.AutoSize = true;
			Seeinfolabel3.Location = new Point(865, 28);
			Seeinfolabel3.Margin = new Padding(2, 0, 2, 0);
			Seeinfolabel3.Name = "Seeinfolabel3";
			Seeinfolabel3.Size = new Size(0, 25);
			Seeinfolabel3.TabIndex = 11;
			// 
			// SortyByPricePbtn
			// 
			SortyByPricePbtn.Location = new Point(112, 362);
			SortyByPricePbtn.Margin = new Padding(2);
			SortyByPricePbtn.Name = "SortyByPricePbtn";
			SortyByPricePbtn.Size = new Size(168, 49);
			SortyByPricePbtn.TabIndex = 12;
			SortyByPricePbtn.Text = "Sort by Price";
			SortyByPricePbtn.UseVisualStyleBackColor = true;
			SortyByPricePbtn.Click += SortyByPricePbtn_Click;
			// 
			// SortByIdBtn
			// 
			SortByIdBtn.Location = new Point(112, 456);
			SortByIdBtn.Margin = new Padding(2);
			SortByIdBtn.Name = "SortByIdBtn";
			SortByIdBtn.Size = new Size(168, 50);
			SortByIdBtn.TabIndex = 13;
			SortByIdBtn.Text = "Sot by Id";
			SortByIdBtn.UseVisualStyleBackColor = true;
			SortByIdBtn.Click += SortByIdBtn_Click_1;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(182, 55);
			label3.Margin = new Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new Size(59, 25);
			label3.TabIndex = 14;
			label3.Text = "Name";
			// 
			// ProductsForms
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1195, 694);
			Controls.Add(label3);
			Controls.Add(SortByIdBtn);
			Controls.Add(SortyByPricePbtn);
			Controls.Add(Seeinfolabel3);
			Controls.Add(ID);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(comboBoxPorducts);
			Controls.Add(SeeInfoLabel);
			Controls.Add(button2);
			Controls.Add(ProductInt);
			Controls.Add(Filter);
			Controls.Add(FilterByNameTxtbx);
			Controls.Add(comboBoxCatogories);
			Controls.Add(ProducctListbox);
			Margin = new Padding(2);
			Name = "ProductsForms";
			Text = "Products";
			Load += ProductsForms_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ListBox ProducctListbox;
		private ComboBox comboBoxCatogories;
		private TextBox FilterByNameTxtbx;
		private Button Filter;
		private TextBox ProductInt;
		private Button button2;
		private Label SeeInfoLabel;
		private ComboBox comboBoxPorducts;
		private Label label1;
		private Label label2;
		private Label ID;
		private Label Seeinfolabel3;
		private Button SortyByPricePbtn;
		private Button SortByIdBtn;
		private Label label3;
	}
}