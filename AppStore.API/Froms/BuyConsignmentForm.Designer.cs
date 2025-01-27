namespace AppStore.API.WinForms
{
    partial class BuyConsignmentForm
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
            labelStore = new Label();
            comboBoxStores = new ComboBox();
            labelConsignment = new Label();
            labelProduct = new Label();
            labelAmount = new Label();
            comboBoxProduct1 = new ComboBox();
            textBoxAmount1 = new TextBox();
            buttonBuy = new Button();
            buttonAddField = new Button();
            labelResult = new Label();
            labelSum = new Label();
            labelErrorType1 = new Label();
            SuspendLayout();
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(519, 12);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(94, 29);
            buttonBack.TabIndex = 0;
            buttonBack.Text = "Назад";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += Back_Click;
            // 
            // labelStore
            // 
            labelStore.AutoSize = true;
            labelStore.Location = new Point(23, 26);
            labelStore.Name = "labelStore";
            labelStore.Size = new Size(69, 20);
            labelStore.TabIndex = 1;
            labelStore.Text = "Магазин";
            // 
            // comboBoxStore
            // 
            comboBoxStores.FormattingEnabled = true;
            comboBoxStores.Location = new Point(128, 23);
            comboBoxStores.Name = "comboBoxStores";
            comboBoxStores.Size = new Size(151, 28);
            comboBoxStores.TabIndex = 2;
            // 
            // labelConsignment
            // 
            labelConsignment.AutoSize = true;
            labelConsignment.Location = new Point(23, 65);
            labelConsignment.Name = "labelConsignment";
            labelConsignment.Size = new Size(121, 20);
            labelConsignment.TabIndex = 3;
            labelConsignment.Text = "Партия товаров";
            // 
            // labelProduct
            // 
            labelProduct.AutoSize = true;
            labelProduct.Location = new Point(23, 105);
            labelProduct.Name = "labelProduct";
            labelProduct.Size = new Size(51, 20);
            labelProduct.TabIndex = 4;
            labelProduct.Text = "Товар";
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Location = new Point(229, 105);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(90, 20);
            labelAmount.TabIndex = 5;
            labelAmount.Text = "Количество";
            // 
            // comboBoxProduct1
            // 
            comboBoxProduct1.FormattingEnabled = true;
            comboBoxProduct1.Location = new Point(23, 146);
            comboBoxProduct1.Name = "comboBoxProduct1";
            comboBoxProduct1.Size = new Size(151, 28);
            comboBoxProduct1.TabIndex = 6;
            // 
            // textBoxAmount1
            // 
            textBoxAmount1.Location = new Point(229, 146);
            textBoxAmount1.Name = "textBoxAmount1";
            textBoxAmount1.Size = new Size(125, 27);
            textBoxAmount1.TabIndex = 7;
            // 
            // buttonBuy
            // 
            buttonBuy.Location = new Point(403, 12);
            buttonBuy.Name = "buttonBuy";
            buttonBuy.Size = new Size(94, 29);
            buttonBuy.TabIndex = 8;
            buttonBuy.Text = "Купить";
            buttonBuy.UseVisualStyleBackColor = true;
            buttonBuy.Click += ButtonBuy_Click;
            // 
            // buttonAddField
            // 
            buttonAddField.Location = new Point(388, 97);
            buttonAddField.Name = "buttonAddField";
            buttonAddField.Size = new Size(128, 36);
            buttonAddField.TabIndex = 9;
            buttonAddField.Text = "Добавить поле";
            buttonAddField.UseVisualStyleBackColor = true;
            buttonAddField.Click += ButtonAddField_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(341, 44);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(50, 20);
            labelResult.TabIndex = 11;
            labelResult.Text = "label4";
            labelResult.Visible = false;
            // 
            // labelSum
            // 
            labelSum.AutoSize = true;
            labelSum.Location = new Point(341, 74);
            labelSum.Name = "labelSum";
            labelSum.Size = new Size(50, 20);
            labelSum.TabIndex = 11;
            labelSum.Text = "label1";
            labelSum.Visible = false;
            // 
            // labelErrorType1
            // 
            labelErrorType1.AutoSize = true;
            labelErrorType1.ForeColor = Color.Red;
            labelErrorType1.Location = new Point(403, 146);
            labelErrorType1.Name = "labelErrorType1";
            labelErrorType1.Size = new Size(50, 20);
            labelErrorType1.TabIndex = 12;
            labelErrorType1.Text = "label1";
            labelErrorType1.Visible = false;
            // 
            // BuyConsignmentForm
            // 
            ClientSize = new Size(637, 500);
            Controls.Add(labelErrorType1);
            Controls.Add(labelSum);
            Controls.Add(labelResult);
            Controls.Add(buttonAddField);
            Controls.Add(buttonBuy);
            Controls.Add(textBoxAmount1);
            Controls.Add(comboBoxProduct1);
            Controls.Add(labelAmount);
            Controls.Add(labelProduct);
            Controls.Add(labelConsignment);
            Controls.Add(comboBoxStores);
            Controls.Add(labelStore);
            Controls.Add(buttonBack);
            Name = "BuyConsignmentForm";
            Text = "Покупка партии товаров";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button buttonBack;
        private Label labelStore;
        private ComboBox comboBoxStores;
        private Label labelConsignment;
        private Label labelProduct;
        private Label labelAmount;
        private ComboBox comboBoxProduct1;
        private TextBox textBoxAmount1;
        private Button buttonBuy;
        private Button buttonAddField;
        private Label labelResult;
        private Label labelSum;
        private Label labelErrorType1;
    }
}