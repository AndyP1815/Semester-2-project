namespace AdminOverview.Forms
{
    partial class OrderForm
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
            listBoxOrders = new ListBox();
            ListBoxProducts = new ListBox();
            label1 = new Label();
            AllOrderBtn = new Button();
            SortByPrice = new Button();
            label2 = new Label();
            ChangeStatus = new Button();
            StatusCMBX = new ComboBox();
            labelShow = new Label();
            OrderLabel = new Label();
            SuspendLayout();
            // 
            // listBoxOrders
            // 
            listBoxOrders.FormattingEnabled = true;
            listBoxOrders.ItemHeight = 25;
            listBoxOrders.Location = new Point(128, 69);
            listBoxOrders.Margin = new Padding(4);
            listBoxOrders.Name = "listBoxOrders";
            listBoxOrders.Size = new Size(232, 479);
            listBoxOrders.TabIndex = 0;
            listBoxOrders.SelectedIndexChanged += listBoxOrders_SelectedIndexChanged;
            // 
            // ListBoxProducts
            // 
            ListBoxProducts.FormattingEnabled = true;
            ListBoxProducts.ItemHeight = 25;
            ListBoxProducts.Location = new Point(738, 69);
            ListBoxProducts.Margin = new Padding(4);
            ListBoxProducts.Name = "ListBoxProducts";
            ListBoxProducts.Size = new Size(216, 479);
            ListBoxProducts.TabIndex = 1;
            ListBoxProducts.SelectedIndexChanged += ListBoxProducts_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1010, 69);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(97, 25);
            label1.TabIndex = 2;
            label1.Text = "ShowLabel";
            // 
            // AllOrderBtn
            // 
            AllOrderBtn.Location = new Point(2, 80);
            AllOrderBtn.Margin = new Padding(4);
            AllOrderBtn.Name = "AllOrderBtn";
            AllOrderBtn.Size = new Size(118, 36);
            AllOrderBtn.TabIndex = 3;
            AllOrderBtn.Text = "All orders";
            AllOrderBtn.UseVisualStyleBackColor = true;
            AllOrderBtn.Click += AllOrderBtn_Click;
            // 
            // SortByPrice
            // 
            SortByPrice.Location = new Point(2, 124);
            SortByPrice.Margin = new Padding(4);
            SortByPrice.Name = "SortByPrice";
            SortByPrice.Size = new Size(118, 85);
            SortByPrice.TabIndex = 4;
            SortByPrice.Text = "Sort By price";
            SortByPrice.UseVisualStyleBackColor = true;
            SortByPrice.Click += SortByPrice_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(440, 128);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 6;
            label2.Text = "Status";
            // 
            // ChangeStatus
            // 
            ChangeStatus.Location = new Point(384, 174);
            ChangeStatus.Margin = new Padding(4);
            ChangeStatus.Name = "ChangeStatus";
            ChangeStatus.Size = new Size(118, 36);
            ChangeStatus.TabIndex = 7;
            ChangeStatus.Text = "change";
            ChangeStatus.UseVisualStyleBackColor = true;
            ChangeStatus.Click += ChangeStatus_Click;
            // 
            // StatusCMBX
            // 
            StatusCMBX.FormattingEnabled = true;
            StatusCMBX.Items.AddRange(new object[] { "InProgress", "Delayed        ", "Canceled", "Delivered", "OnHisWay" });
            StatusCMBX.Location = new Point(525, 174);
            StatusCMBX.Margin = new Padding(4);
            StatusCMBX.Name = "StatusCMBX";
            StatusCMBX.Size = new Size(188, 33);
            StatusCMBX.TabIndex = 8;
            // 
            // labelShow
            // 
            labelShow.AutoSize = true;
            labelShow.Location = new Point(1010, 109);
            labelShow.Name = "labelShow";
            labelShow.Size = new Size(0, 25);
            labelShow.TabIndex = 9;
            // 
            // OrderLabel
            // 
            OrderLabel.AutoSize = true;
            OrderLabel.Location = new Point(537, 128);
            OrderLabel.Name = "OrderLabel";
            OrderLabel.Size = new Size(0, 25);
            OrderLabel.TabIndex = 10;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 612);
            Controls.Add(OrderLabel);
            Controls.Add(labelShow);
            Controls.Add(StatusCMBX);
            Controls.Add(ChangeStatus);
            Controls.Add(label2);
            Controls.Add(SortByPrice);
            Controls.Add(AllOrderBtn);
            Controls.Add(label1);
            Controls.Add(ListBoxProducts);
            Controls.Add(listBoxOrders);
            Margin = new Padding(4);
            Name = "OrderForm";
            Text = "OrderForm";
            Load += OrderForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxOrders;
        private ListBox ListBoxProducts;
        private Label label1;
        private Button AllOrderBtn;
        private Button SortByPrice;
        private Label label2;
        private Button ChangeStatus;
        private ComboBox StatusCMBX;
        private Label labelShow;
        private Label OrderLabel;
    }
}