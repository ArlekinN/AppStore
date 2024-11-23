namespace AppStore.WinForms
{
    partial class SetofProductOnTheSumForm
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
            comboBoxStore = new ComboBox();
            labelSum = new Label();
            textBoxSum = new TextBox();
            labelListProduct = new Label();
            dataGridViewProducts = new DataGridView();
            labelTypeError = new Label();
            buttonSearch = new Button();
            labelListEmpty = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
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
            // labelStore
            // 
            labelStore.AutoSize = true;
            labelStore.Location = new Point(28, 28);
            labelStore.Name = "labelStore";
            labelStore.Size = new Size(69, 20);
            labelStore.TabIndex = 1;
            labelStore.Text = "Магазин";
            // 
            // comboBoxStore
            // 
            comboBoxStore.FormattingEnabled = true;
            comboBoxStore.Location = new Point(143, 28);
            comboBoxStore.Name = "comboBoxStore";
            comboBoxStore.Size = new Size(151, 28);
            comboBoxStore.TabIndex = 2;
            // 
            // labelSum
            // 
            labelSum.AutoSize = true;
            labelSum.Location = new Point(28, 67);
            labelSum.Name = "labelSum";
            labelSum.Size = new Size(55, 20);
            labelSum.TabIndex = 3;
            labelSum.Text = "Сумма";
            // 
            // textBoxSum
            // 
            textBoxSum.Location = new Point(143, 67);
            textBoxSum.Name = "textBoxSum";
            textBoxSum.Size = new Size(125, 27);
            textBoxSum.TabIndex = 4;
            // 
            // labelListProduct
            // 
            labelListProduct.AutoSize = true;
            labelListProduct.Location = new Point(28, 157);
            labelListProduct.Name = "labelListProduct";
            labelListProduct.Size = new Size(135, 20);
            labelListProduct.TabIndex = 5;
            labelListProduct.Text = "Список продуктов";
            labelListProduct.Visible = false;
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Location = new Point(28, 205);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.RowHeadersWidth = 51;
            dataGridViewProducts.Size = new Size(300, 188);
            dataGridViewProducts.TabIndex = 6;
            dataGridViewProducts.Visible = false;
            // 
            // labelTypeError
            // 
            labelTypeError.AutoSize = true;
            labelTypeError.ForeColor = Color.Red;
            labelTypeError.Location = new Point(317, 67);
            labelTypeError.Name = "labelTypeError";
            labelTypeError.Size = new Size(157, 20);
            labelTypeError.TabIndex = 7;
            labelTypeError.Text = "Ошибка типа данных";
            labelTypeError.Visible = false;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(28, 116);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(135, 29);
            buttonSearch.TabIndex = 8;
            buttonSearch.Text = "Найти продукты";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += ButtonSearch_Click;
            // 
            // labelListEmpty
            // 
            labelListEmpty.AutoSize = true;
            labelListEmpty.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelListEmpty.Location = new Point(28, 182);
            labelListEmpty.Name = "labelListEmpty";
            labelListEmpty.Size = new Size(127, 20);
            labelListEmpty.TabIndex = 9;
            labelListEmpty.Text = "Нет результатов";
            labelListEmpty.Visible = false;
            // 
            // SetofProductOnTheSumForm
            // 
            ClientSize = new Size(547, 500);
            Controls.Add(labelListEmpty);
            Controls.Add(buttonSearch);
            Controls.Add(labelTypeError);
            Controls.Add(dataGridViewProducts);
            Controls.Add(labelListProduct);
            Controls.Add(textBoxSum);
            Controls.Add(labelSum);
            Controls.Add(comboBoxStore);
            Controls.Add(labelStore);
            Controls.Add(buttonBack);
            Name = "SetofProductOnTheSumForm";
            Text = "Найти набор продуктов на сумму";
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button buttonBack;
        private Label labelStore;
        private ComboBox comboBoxStore;
        private Label labelSum;
        private TextBox textBoxSum;
        private Label labelListProduct;
        private DataGridView dataGridViewProducts;
        private Label labelTypeError;
        private Button buttonSearch;
        private Label labelListEmpty;
    }
}