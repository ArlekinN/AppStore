namespace AppStore.WinForms
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
            labelListConsigment = new Label();
            labelProduct = new Label();
            labelPrice = new Label();
            labelAmount = new Label();
            buttonAddProduct = new Button();
            textBoxProduct1 = new TextBox();
            textBoxPrice1 = new TextBox();
            textBoxAmount1 = new TextBox();
            buttonCreateConsigment = new Button();
            labelErrorType = new Label();
            labelResultCreating = new Label();
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
            // labelListConsigment
            // 
            labelListConsigment.AutoSize = true;
            labelListConsigment.Location = new Point(35, 68);
            labelListConsigment.Name = "labelListConsigment";
            labelListConsigment.Size = new Size(73, 20);
            labelListConsigment.TabIndex = 4;
            labelListConsigment.Text = "Поставка";
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
            // textBoxProduct1
            // 
            textBoxProduct1.Location = new Point(328, 62);
            textBoxProduct1.Name = "textBoxProduct1";
            textBoxProduct1.Size = new Size(125, 27);
            textBoxProduct1.TabIndex = 9;
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
            // buttonCreateConsigment
            // 
            buttonCreateConsigment.Location = new Point(526, 62);
            buttonCreateConsigment.Name = "buttonCreateConsigment";
            buttonCreateConsigment.Size = new Size(122, 50);
            buttonCreateConsigment.TabIndex = 12;
            buttonCreateConsigment.Text = "Создать поставку";
            buttonCreateConsigment.UseVisualStyleBackColor = true;
            buttonCreateConsigment.Click += ButtonCreateConsigment_Click;
            // 
            // labelErrorType
            // 
            labelErrorType.AutoSize = true;
            labelErrorType.ForeColor = Color.Red;
            labelErrorType.Location = new Point(506, 156);
            labelErrorType.Name = "labelErrorType";
            labelErrorType.Size = new Size(157, 20);
            labelErrorType.TabIndex = 13;
            labelErrorType.Text = "Ошибка типа данных";
            labelErrorType.Visible = false;
            // 
            // labelResultCreating
            // 
            labelResultCreating.AutoSize = true;
            labelResultCreating.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelResultCreating.ForeColor = Color.Lime;
            labelResultCreating.Location = new Point(392, 25);
            labelResultCreating.Name = "labelResultCreating";
            labelResultCreating.Size = new Size(84, 25);
            labelResultCreating.TabIndex = 14;
            labelResultCreating.Text = "Успешно";
            labelResultCreating.Visible = false;
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
            Controls.Add(labelResultCreating);
            Controls.Add(labelErrorType);
            Controls.Add(buttonCreateConsigment);
            Controls.Add(textBoxAmount1);
            Controls.Add(textBoxPrice1);
            Controls.Add(textBoxProduct1);
            Controls.Add(buttonAddProduct);
            Controls.Add(labelAmount);
            Controls.Add(labelPrice);
            Controls.Add(labelProduct);
            Controls.Add(labelListConsigment);
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
        private Label labelListConsigment;
        private Label labelProduct;
        private Label labelPrice;
        private Label labelAmount;
        private Button buttonAddProduct;
        private TextBox textBoxProduct1;
        private TextBox textBoxPrice1;
        private TextBox textBoxAmount1;
        private Button buttonCreateConsigment;
        private Label labelErrorType;
        private Label labelResultCreating;
        private ComboBox comboBoxProduct1;
    }
}