namespace AppStore.API.WinForms
{
    partial class CreateProductForm
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
            buttonCreateProduct = new Button();
            labelNameProduct = new Label();
            textBoxNameProduct = new TextBox();
            labelResultCreating = new Label();
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
            // buttonCreateProduct
            // 
            buttonCreateProduct.Location = new Point(31, 93);
            buttonCreateProduct.Name = "buttonCreateProduct";
            buttonCreateProduct.Size = new Size(152, 29);
            buttonCreateProduct.TabIndex = 1;
            buttonCreateProduct.Text = "Создать продукт";
            buttonCreateProduct.UseVisualStyleBackColor = true;
            buttonCreateProduct.Click += buttonCreateProduct_Click;
            // 
            // labelNameProduct
            // 
            labelNameProduct.AutoSize = true;
            labelNameProduct.Location = new Point(31, 34);
            labelNameProduct.Name = "labelNameProduct";
            labelNameProduct.Size = new Size(144, 20);
            labelNameProduct.TabIndex = 2;
            labelNameProduct.Text = "Название продукта";
            // 
            // textBoxNameProduct
            // 
            textBoxNameProduct.Location = new Point(196, 31);
            textBoxNameProduct.Name = "textBoxNameProduct";
            textBoxNameProduct.Size = new Size(125, 27);
            textBoxNameProduct.TabIndex = 4;
            // 
            // labelResultCreating
            // 
            labelResultCreating.AutoSize = true;
            labelResultCreating.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelResultCreating.ForeColor = Color.Lime;
            labelResultCreating.Location = new Point(232, 97);
            labelResultCreating.Name = "labelResultCreating";
            labelResultCreating.Size = new Size(84, 25);
            labelResultCreating.TabIndex = 6;
            labelResultCreating.Text = "Успешно";
            labelResultCreating.Visible = false;
            // 
            // CreateProductForm
            // 
            ClientSize = new Size(600, 500);
            Controls.Add(labelResultCreating);
            Controls.Add(textBoxNameProduct);
            Controls.Add(labelNameProduct);
            Controls.Add(buttonCreateProduct);
            Controls.Add(buttonBack);
            Name = "CreateProductForm";
            Text = "Создание товара";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button buttonBack;
        private Button buttonCreateProduct;
        private Label labelNameProduct;
        private TextBox textBoxNameProduct;
        private Label labelResultCreating;
    }
}