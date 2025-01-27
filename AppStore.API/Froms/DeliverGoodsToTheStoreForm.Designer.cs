namespace AppStore.API.WinForms
{
    partial class DeliverGoodsToTheStoreForm
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
            buttonBack = new Button();
            labelNameStore = new Label();
            comboBoxStores = new ComboBox();
            labelListConsignment = new Label();
            labelProduct = new Label();
            labelPrice = new Label();
            labelAmount = new Label();
            buttonAddProduct = new Button();
            textBoxPrice1 = new TextBox();
            textBoxAmount1 = new TextBox();
            buttonCreateConsignment = new Button();
            labelErrorType1 = new Label();
            labelResult = new Label();
            comboBoxProduct1 = new ComboBox();
            SuspendLayout();
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(569, 12);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(94, 29);
            buttonBack.TabIndex = 0;
            buttonBack.Text = "Назад";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += Back_Click;
            // 
            // labelNameStore
            // 
            labelNameStore.AutoSize = true;
            labelNameStore.Location = new Point(35, 26);
            labelNameStore.Name = "labelNameStore";
            labelNameStore.Size = new Size(69, 20);
            labelNameStore.TabIndex = 1;
            labelNameStore.Text = "Магазин";
            // 
            // comboBoxStores
            // 
            comboBoxStores.FormattingEnabled = true;
            comboBoxStores.Location = new Point(168, 26);
            comboBoxStores.Name = "comboBoxStores";
            comboBoxStores.Size = new Size(151, 28);
            comboBoxStores.TabIndex = 3;
            // 
            // labelListConsignment
            // 
            labelListConsignment.AutoSize = true;
            labelListConsignment.Location = new Point(35, 68);
            labelListConsignment.Name = "labelListConsignment";
            labelListConsignment.Size = new Size(73, 20);
            labelListConsignment.TabIndex = 4;
            labelListConsignment.Text = "Поставка";
            // 
            // labelProduct
            // 
            labelProduct.AutoSize = true;
            labelProduct.Location = new Point(35, 105);
            labelProduct.Name = "labelProduct";
            labelProduct.Size = new Size(51, 20);
            labelProduct.TabIndex = 5;
            labelProduct.Text = "Товар";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(183, 105);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(45, 20);
            labelPrice.TabIndex = 6;
            labelPrice.Text = "Цена";
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Location = new Point(328, 105);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(90, 20);
            labelAmount.TabIndex = 7;
            labelAmount.Text = "Количество";
            // 
            // buttonAddProduct
            // 
            buttonAddProduct.Location = new Point(526, 118);
            buttonAddProduct.Name = "buttonAddProduct";
            buttonAddProduct.Size = new Size(122, 27);
            buttonAddProduct.TabIndex = 8;
            buttonAddProduct.Text = "Добавить поле";
            buttonAddProduct.UseVisualStyleBackColor = true;
            buttonAddProduct.Click += ButtonAddProduct_Click;
            // 
            // textBoxPrice1
            // 
            textBoxPrice1.Location = new Point(183, 153);
            textBoxPrice1.Name = "textBoxPrice1";
            textBoxPrice1.Size = new Size(125, 27);
            textBoxPrice1.TabIndex = 10;
            // 
            // textBoxAmount1
            // 
            textBoxAmount1.Location = new Point(328, 153);
            textBoxAmount1.Name = "textBoxAmount1";
            textBoxAmount1.Size = new Size(125, 27);
            textBoxAmount1.TabIndex = 11;
            // 
            // buttonCreateConsignment
            // 
            buttonCreateConsignment.Location = new Point(526, 62);
            buttonCreateConsignment.Name = "buttonCreateConsignment";
            buttonCreateConsignment.Size = new Size(122, 50);
            buttonCreateConsignment.TabIndex = 12;
            buttonCreateConsignment.Text = "Создать поставку";
            buttonCreateConsignment.UseVisualStyleBackColor = true;
            buttonCreateConsignment.Click += ButtonCreateConsignment_Click;
            // 
            // labelErrorType1
            // 
            labelErrorType1.AutoSize = true;
            labelErrorType1.ForeColor = Color.Red;
            labelErrorType1.Location = new Point(459, 156);
            labelErrorType1.Name = "labelErrorType1";
            labelErrorType1.Size = new Size(157, 20);
            labelErrorType1.TabIndex = 13;
            labelErrorType1.Text = "Ошибка типа данных";
            labelErrorType1.Visible = false;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelResult.ForeColor = Color.Lime;
            labelResult.Location = new Point(168, 64);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(84, 25);
            labelResult.TabIndex = 14;
            labelResult.Text = "Успешно";
            labelResult.Visible = false;
            // 
            // comboBoxProduct1
            // 
            comboBoxProduct1.FormattingEnabled = true;
            comboBoxProduct1.Location = new Point(35, 153);
            comboBoxProduct1.Name = "comboBoxProduct1";
            comboBoxProduct1.Size = new Size(125, 28);
            comboBoxProduct1.TabIndex = 15;
            // 
            // DeliverGoodsToTheStoreForm
            // 
            ClientSize = new Size(675, 500);
            Controls.Add(comboBoxProduct1);
            Controls.Add(labelResult);
            Controls.Add(labelErrorType1);
            Controls.Add(buttonCreateConsignment);
            Controls.Add(textBoxAmount1);
            Controls.Add(textBoxPrice1);
            Controls.Add(buttonAddProduct);
            Controls.Add(labelAmount);
            Controls.Add(labelPrice);
            Controls.Add(labelProduct);
            Controls.Add(labelListConsignment);
            Controls.Add(comboBoxStores);
            Controls.Add(labelNameStore);
            Controls.Add(buttonBack);
            Name = "DeliverGoodsToTheStoreForm";
            Text = "Поставка товаров в магазин";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button buttonBack;
        private Label labelNameStore;
        private ComboBox comboBoxStores;
        private Label labelListConsignment;
        private Label labelProduct;
        private Label labelPrice;
        private Label labelAmount;
        private Button buttonAddProduct;
        private TextBox textBoxPrice1;
        private TextBox textBoxAmount1;
        private Button buttonCreateConsignment;
        private Label labelErrorType1;
        private Label labelResult;
        private ComboBox comboBoxProduct1;
    }
}