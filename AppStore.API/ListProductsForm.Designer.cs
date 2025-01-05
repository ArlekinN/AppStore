namespace AppStore.API.WinForms
{
    partial class ListProductsForm
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
            dataGridViewListProduct = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewListProduct).BeginInit();
            SuspendLayout();
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(494, 12);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(94, 29);
            buttonBack.TabIndex = 0;
            buttonBack.Text = "Назад";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += Back_Click;
            // 
            // dataGridViewListProduct
            // 
            dataGridViewListProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewListProduct.Location = new Point(12, 12);
            dataGridViewListProduct.Name = "dataGridViewListProduct";
            dataGridViewListProduct.RowHeadersWidth = 51;
            dataGridViewListProduct.Size = new Size(453, 470);
            dataGridViewListProduct.TabIndex = 1;
            // 
            // ListProductsForm
            // 
            ClientSize = new Size(600, 500);
            Controls.Add(dataGridViewListProduct);
            Controls.Add(buttonBack);
            Name = "ListProductsForm";
            Text = "Список продуктов";
            ((System.ComponentModel.ISupportInitialize)dataGridViewListProduct).EndInit();
            ResumeLayout(false);
        }

        private Button buttonBack;
        private DataGridView dataGridViewListProduct;
    }
}