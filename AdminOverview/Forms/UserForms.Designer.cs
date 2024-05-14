namespace AdminOverview.Forms
{
    partial class UserForms
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
            ListBoxUsers = new ListBox();
            UserCombobox = new ComboBox();
            UserLabel = new Label();
            SortByIdBtn = new Button();
            GetByUserIdbtn = new Button();
            UseridTxtbox = new TextBox();
            Nametxtbox = new TextBox();
            label1 = new Label();
            Filterbtn = new Button();
            DisplayLabel = new Label();
            SortByName = new Button();
            SuspendLayout();
            // 
            // ListBoxUsers
            // 
            ListBoxUsers.FormattingEnabled = true;
            ListBoxUsers.ItemHeight = 25;
            ListBoxUsers.Location = new Point(453, 22);
            ListBoxUsers.Name = "ListBoxUsers";
            ListBoxUsers.Size = new Size(411, 754);
            ListBoxUsers.TabIndex = 0;
            ListBoxUsers.SelectedIndexChanged += ListBoxUsers_SelectedIndexChanged;
            // 
            // UserCombobox
            // 
            UserCombobox.FormattingEnabled = true;
            UserCombobox.Items.AddRange(new object[] { "", "User", "Seller" });
            UserCombobox.Location = new Point(186, 250);
            UserCombobox.Name = "UserCombobox";
            UserCombobox.Size = new Size(190, 33);
            UserCombobox.TabIndex = 1;
            // 
            // UserLabel
            // 
            UserLabel.AutoSize = true;
            UserLabel.Location = new Point(50, 250);
            UserLabel.Name = "UserLabel";
            UserLabel.Size = new Size(47, 25);
            UserLabel.TabIndex = 2;
            UserLabel.Text = "User";
            // 
            // SortByIdBtn
            // 
            SortByIdBtn.Location = new Point(123, 450);
            SortByIdBtn.Name = "SortByIdBtn";
            SortByIdBtn.Size = new Size(172, 54);
            SortByIdBtn.TabIndex = 3;
            SortByIdBtn.Text = "Sort by Id";
            SortByIdBtn.UseVisualStyleBackColor = true;
            SortByIdBtn.Click += SortByIdBtn_Click;
            // 
            // GetByUserIdbtn
            // 
            GetByUserIdbtn.Location = new Point(12, 356);
            GetByUserIdbtn.Name = "GetByUserIdbtn";
            GetByUserIdbtn.Size = new Size(139, 42);
            GetByUserIdbtn.TabIndex = 4;
            GetByUserIdbtn.Text = "Get by user id";
            GetByUserIdbtn.UseVisualStyleBackColor = true;
            GetByUserIdbtn.Click += GetByUserIdbtn_Click;
            // 
            // UseridTxtbox
            // 
            UseridTxtbox.Location = new Point(186, 362);
            UseridTxtbox.Name = "UseridTxtbox";
            UseridTxtbox.Size = new Size(189, 31);
            UseridTxtbox.TabIndex = 5;
            // 
            // Nametxtbox
            // 
            Nametxtbox.Location = new Point(187, 174);
            Nametxtbox.Name = "Nametxtbox";
            Nametxtbox.Size = new Size(189, 31);
            Nametxtbox.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 180);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 7;
            label1.Text = "Name";
            // 
            // Filterbtn
            // 
            Filterbtn.Location = new Point(123, 94);
            Filterbtn.Name = "Filterbtn";
            Filterbtn.Size = new Size(112, 34);
            Filterbtn.TabIndex = 8;
            Filterbtn.Text = "Filter";
            Filterbtn.UseVisualStyleBackColor = true;
            Filterbtn.Click += Filterbtn_Click;
            // 
            // DisplayLabel
            // 
            DisplayLabel.AutoSize = true;
            DisplayLabel.Location = new Point(919, 62);
            DisplayLabel.Name = "DisplayLabel";
            DisplayLabel.Size = new Size(0, 25);
            DisplayLabel.TabIndex = 9;
            // 
            // SortByName
            // 
            SortByName.Location = new Point(123, 552);
            SortByName.Name = "SortByName";
            SortByName.Size = new Size(172, 62);
            SortByName.TabIndex = 10;
            SortByName.Text = "Sort by name";
            SortByName.UseVisualStyleBackColor = true;
            SortByName.Click += SortByName_Click;
            // 
            // UserForms
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 807);
            Controls.Add(SortByName);
            Controls.Add(DisplayLabel);
            Controls.Add(Filterbtn);
            Controls.Add(label1);
            Controls.Add(Nametxtbox);
            Controls.Add(UseridTxtbox);
            Controls.Add(GetByUserIdbtn);
            Controls.Add(SortByIdBtn);
            Controls.Add(UserLabel);
            Controls.Add(UserCombobox);
            Controls.Add(ListBoxUsers);
            Name = "UserForms";
            Text = "UserForms";
            Load += UserForms_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ListBoxUsers;
        private ComboBox UserCombobox;
        private Label UserLabel;
        private Button SortByIdBtn;
        private Button GetByUserIdbtn;
        private TextBox UseridTxtbox;
        private TextBox Nametxtbox;
        private Label label1;
        private Button Filterbtn;
        private Label DisplayLabel;
        private Button SortByName;
    }
}