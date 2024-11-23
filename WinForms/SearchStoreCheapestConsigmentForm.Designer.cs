namespace AppStore.WinForms
{
    partial class SearchStoreCheapestConsigmentForm
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
            labelListProduct = new Label();
            labelProduct = new Label();
            labelAmount = new Label();
            labelResult = new Label();
            buttonSearch = new Button();
            buttonAddField = new Button();
            comboBoxProduct1 = new ComboBox();
            textBoxAmount1 = new TextBox();
            labelErrorType1 = new Label();
            SuspendLayout();
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(422, 12);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(94, 29);
            buttonBack.TabIndex = 0;
            buttonBack.Text = "Назад";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += Back_Click;
            // 
            // labelListProduct
            // 
            labelListProduct.AutoSize = true;
            labelListProduct.Location = new Point(12, 59);
            labelListProduct.Name = "labelListProduct";
            labelListProduct.Size = new Size(121, 20);
            labelListProduct.TabIndex = 1;
            labelListProduct.Text = "Партия товаров";
            // 
            // labelProduct
            // 
            labelProduct.AutoSize = true;
            labelProduct.Location = new Point(12, 89);
            labelProduct.Name = "labelProduct";
            labelProduct.Size = new Size(51, 20);
            labelProduct.TabIndex = 2;
            labelProduct.Text = "Товар";
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Location = new Point(216, 94);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(90, 20);
            labelAmount.TabIndex = 3;
            labelAmount.Text = "Количество";
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(128, 16);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(50, 20);
            labelResult.TabIndex = 4;
            labelResult.Text = "label4";
            labelResult.Visible = false;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(7, 12);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(94, 29);
            buttonSearch.TabIndex = 5;
            buttonSearch.Text = "Найти";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += ButtonSearch_Click;
            // 
            // buttonAddField
            // 
            buttonAddField.Location = new Point(393, 85);
            buttonAddField.Name = "buttonAddField";
            buttonAddField.Size = new Size(142, 29);
            buttonAddField.TabIndex = 6;
            buttonAddField.Text = "Добавить поле";
            buttonAddField.UseVisualStyleBackColor = true;
            buttonAddField.Click += ButtonAddField_Click;
            // 
            // comboBoxProduct1
            // 
            comboBoxProduct1.FormattingEnabled = true;
            comboBoxProduct1.Location = new Point(12, 124);
            comboBoxProduct1.Name = "comboBoxProduct1";
            comboBoxProduct1.Size = new Size(151, 28);
            comboBoxProduct1.TabIndex = 7;
            // 
            // textBoxAmount1
            // 
            textBoxAmount1.Location = new Point(216, 124);
            textBoxAmount1.Name = "textBoxAmount1";
            textBoxAmount1.Size = new Size(125, 27);
            textBoxAmount1.TabIndex = 8;
            // 
            // labelErrorType1
            // 
            labelErrorType1.AutoSize = true;
            labelErrorType1.ForeColor = Color.Red;
            labelErrorType1.Location = new Point(403, 126);
            labelErrorType1.Name = "labelErrorType1";
            labelErrorType1.Size = new Size(50, 20);
            labelErrorType1.TabIndex = 9;
            labelErrorType1.Text = "label5";
            labelErrorType1.Visible = false;
            // 
            // SearchStoreCheapestConsigmentForm
            // 
            ClientSize = new Size(600, 500);
            Controls.Add(labelErrorType1);
            Controls.Add(textBoxAmount1);
            Controls.Add(comboBoxProduct1);
            Controls.Add(buttonAddField);
            Controls.Add(buttonSearch);
            Controls.Add(labelResult);
            Controls.Add(labelAmount);
            Controls.Add(labelProduct);
            Controls.Add(labelListProduct);
            Controls.Add(buttonBack);
            Name = "SearchStoreCheapestConsigmentForm";
            Text = "Поиск магазина с самой дешевой партией";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button buttonBack;
        private Label labelListProduct;
        private Label labelProduct;
        private Label labelAmount;
        private Label labelResult;
        private Button buttonSearch;
        private Button buttonAddField;
        private ComboBox comboBoxProduct1;
        private TextBox textBoxAmount1;
        private Label labelErrorType1;
    }
}