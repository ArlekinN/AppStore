namespace AppStore.API.WinForms
{
    partial class MainForm
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
        private void InitializeComponent()
        {
            label1 = new Label();
            buttonListProducts = new Button();
            buttonCreateStore = new Button();
            buttonCreateProduct = new Button();
            buttonDeliverGoodsToTheStore = new Button();
            buttonSearchStoreCheapestProduct = new Button();
            buttonSetofProductOnTheSum = new Button();
            buttonBuyConsignment = new Button();
            buttonSearchCheapestConsigment = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(174, 9);
            label1.Name = "label1";
            label1.Size = new Size(166, 20);
            label1.TabIndex = 0;
            label1.Text = "Список возможностей";
            // 
            // buttonListProducts
            // 
            buttonListProducts.Location = new Point(20, 48);
            buttonListProducts.Name = "buttonListProducts";
            buttonListProducts.Size = new Size(149, 29);
            buttonListProducts.TabIndex = 1;
            buttonListProducts.Text = "Список продуктов";
            buttonListProducts.UseVisualStyleBackColor = true;
            buttonListProducts.Click += ListProducts_Click;
            // 
            // buttonCreateStore
            // 
            buttonCreateStore.Location = new Point(20, 97);
            buttonCreateStore.Name = "buttonCreateStore";
            buttonCreateStore.Size = new Size(149, 29);
            buttonCreateStore.TabIndex = 2;
            buttonCreateStore.Text = "Создать магазин";
            buttonCreateStore.UseVisualStyleBackColor = true;
            buttonCreateStore.Click += CreateStore_Click;
            // 
            // buttonCreateProduct
            // 
            buttonCreateProduct.Location = new Point(20, 146);
            buttonCreateProduct.Name = "buttonCreateProduct";
            buttonCreateProduct.Size = new Size(149, 29);
            buttonCreateProduct.TabIndex = 3;
            buttonCreateProduct.Text = "Создать товар";
            buttonCreateProduct.UseVisualStyleBackColor = true;
            buttonCreateProduct.Click += CreateProduct_Click;
            // 
            // buttonDeliverGoodsToTheStore
            // 
            buttonDeliverGoodsToTheStore.Location = new Point(20, 195);
            buttonDeliverGoodsToTheStore.Name = "buttonDeliverGoodsToTheStore";
            buttonDeliverGoodsToTheStore.Size = new Size(277, 29);
            buttonDeliverGoodsToTheStore.TabIndex = 4;
            buttonDeliverGoodsToTheStore.Text = "Завести партию товаров в магазин";
            buttonDeliverGoodsToTheStore.UseVisualStyleBackColor = true;
            buttonDeliverGoodsToTheStore.Click += DeliverGoodsToTheStore_Click;
            // 
            // buttonSearchStoreCheapestProduct
            // 
            buttonSearchStoreCheapestProduct.Location = new Point(20, 244);
            buttonSearchStoreCheapestProduct.Name = "buttonSearchStoreCheapestProduct";
            buttonSearchStoreCheapestProduct.Size = new Size(277, 29);
            buttonSearchStoreCheapestProduct.TabIndex = 5;
            buttonSearchStoreCheapestProduct.Text = "Магазин с самым дешевым товаром";
            buttonSearchStoreCheapestProduct.UseVisualStyleBackColor = true;
            buttonSearchStoreCheapestProduct.Click += SearchStoreCheapestProduct_Click;
            // 
            // buttonSetofProductOnTheSum
            // 
            buttonSetofProductOnTheSum.Location = new Point(20, 293);
            buttonSetofProductOnTheSum.Name = "buttonSetofProductOnTheSum";
            buttonSetofProductOnTheSum.Size = new Size(277, 29);
            buttonSetofProductOnTheSum.TabIndex = 6;
            buttonSetofProductOnTheSum.Text = "Набор товаров на сумму";
            buttonSetofProductOnTheSum.UseVisualStyleBackColor = true;
            buttonSetofProductOnTheSum.Click += SetofProductOnTheSum_Click;
            // 
            // buttonBuyConsignment
            // 
            buttonBuyConsignment.Location = new Point(20, 342);
            buttonBuyConsignment.Name = "buttonBuyConsignment";
            buttonBuyConsignment.Size = new Size(277, 29);
            buttonBuyConsignment.TabIndex = 7;
            buttonBuyConsignment.Text = "Купить партию товаров";
            buttonBuyConsignment.UseVisualStyleBackColor = true;
            buttonBuyConsignment.Click += BuyConsignment_Click;
            // 
            // buttonSearchCheapestConsigment
            // 
            buttonSearchCheapestConsigment.Location = new Point(21, 391);
            buttonSearchCheapestConsigment.Name = "buttonSearchCheapestConsigment";
            buttonSearchCheapestConsigment.Size = new Size(277, 29);
            buttonSearchCheapestConsigment.TabIndex = 8;
            buttonSearchCheapestConsigment.Text = "Дешевая партия товаров";
            buttonSearchCheapestConsigment.UseVisualStyleBackColor = true;
            buttonSearchCheapestConsigment.Click += SearchCheapestConsigment_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(547, 500);
            Controls.Add(buttonSearchCheapestConsigment);
            Controls.Add(buttonBuyConsignment);
            Controls.Add(buttonSetofProductOnTheSum);
            Controls.Add(buttonSearchStoreCheapestProduct);
            Controls.Add(buttonDeliverGoodsToTheStore);
            Controls.Add(buttonCreateProduct);
            Controls.Add(buttonCreateStore);
            Controls.Add(buttonListProducts);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "TatiShop";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Button buttonListProducts;
        private Button buttonCreateStore;
        private Button buttonCreateProduct;
        private Button buttonDeliverGoodsToTheStore;
        private Button buttonSearchStoreCheapestProduct;
        private Button buttonSetofProductOnTheSum;
        private Button buttonBuyConsignment;
        private Button buttonSearchCheapestConsigment;
    }
}