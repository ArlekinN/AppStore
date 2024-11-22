namespace AppStore.WinForms
{
    partial class SearchStoreCheapestProductForm
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
            labelProduct = new Label();
            comboBoxProduct = new ComboBox();
            buttonSearchStore = new Button();
            labelStore = new Label();
            labelGetStore = new Label();
            labelPrice = new Label();
            labelGetPrice = new Label();
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
            // labelProduct
            // 
            labelProduct.AutoSize = true;
            labelProduct.Location = new Point(29, 41);
            labelProduct.Name = "labelProduct";
            labelProduct.Size = new Size(66, 20);
            labelProduct.TabIndex = 1;
            labelProduct.Text = "Продукт";
            // 
            // comboBoxProduct
            // 
            comboBoxProduct.FormattingEnabled = true;
            comboBoxProduct.Location = new Point(138, 43);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(151, 28);
            comboBoxProduct.TabIndex = 2;
            // 
            // buttonSearchStore
            // 
            buttonSearchStore.Location = new Point(39, 95);
            buttonSearchStore.Name = "buttonSearchStore";
            buttonSearchStore.Size = new Size(166, 29);
            buttonSearchStore.TabIndex = 3;
            buttonSearchStore.Text = "Найти магазин";
            buttonSearchStore.UseVisualStyleBackColor = true;
            buttonSearchStore.Click += ButtonSearchStore_Click;
            // 
            // labelStore
            // 
            labelStore.AutoSize = true;
            labelStore.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelStore.Location = new Point(35, 151);
            labelStore.Name = "labelStore";
            labelStore.Size = new Size(70, 20);
            labelStore.TabIndex = 4;
            labelStore.Text = "Магазин";
            labelStore.Visible = false;
            // 
            // labelGetStore
            // 
            labelGetStore.AutoSize = true;
            labelGetStore.Location = new Point(129, 151);
            labelGetStore.Name = "labelGetStore";
            labelGetStore.Size = new Size(50, 20);
            labelGetStore.TabIndex = 5;
            labelGetStore.Text = "label3";
            labelGetStore.Visible = false;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelPrice.Location = new Point(39, 201);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(46, 20);
            labelPrice.TabIndex = 6;
            labelPrice.Text = "Цена";
            labelPrice.Visible = false;
            // 
            // labelGetPrice
            // 
            labelGetPrice.AutoSize = true;
            labelGetPrice.Location = new Point(129, 201);
            labelGetPrice.Name = "labelGetPrice";
            labelGetPrice.Size = new Size(50, 20);
            labelGetPrice.TabIndex = 7;
            labelGetPrice.Text = "label5";
            labelGetPrice.Visible = false;
            // 
            // SearchStoreCheapestProductForm
            // 
            ClientSize = new Size(547, 500);
            Controls.Add(labelGetPrice);
            Controls.Add(labelPrice);
            Controls.Add(labelGetStore);
            Controls.Add(labelStore);
            Controls.Add(buttonSearchStore);
            Controls.Add(comboBoxProduct);
            Controls.Add(labelProduct);
            Controls.Add(buttonBack);
            Name = "SearchStoreCheapestProductForm";
            Text = "Поиск магазина с самым дешевым продуктом";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button buttonBack;
        private Label labelProduct;
        private ComboBox comboBoxProduct;
        private Button buttonSearchStore;
        private Label labelStore;
        private Label labelGetStore;
        private Label labelPrice;
        private Label labelGetPrice;
    }
}