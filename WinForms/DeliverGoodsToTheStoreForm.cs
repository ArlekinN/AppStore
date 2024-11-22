using AppStore.BLL;
using AppStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AppStore.WinForms
{
    public partial class DeliverGoodsToTheStoreForm : Form
    {
        private MainForm _mainForm;
        private int textBoxCount = 1;
        public DeliverGoodsToTheStoreForm(MainForm mainForm)
        {
            InitializeComponent();
            LoadDataStore();
            LoadDataProduct("1");
            _mainForm = mainForm;
        }
        private void Back_Click(object sender, EventArgs e)
        {
            textBoxCount = 1;
            _mainForm.Show();
            this.Close();
        }
        private void LoadDataStore()
        {
            comboBoxStores.Items.Clear();
            StoreService storeService = new StoreService();
            List<string> stores = storeService.AllStores();
            foreach (string store in stores)
            {
                comboBoxStores.Items.Add(store);
            }
        }
        private void LoadDataProduct(string i)
        {
            string nameComboBoxProduct = $"comboBoxProduct{i}";
            var comboBox = this.Controls.Find($"comboBoxProduct{i}", true).FirstOrDefault() as ComboBox;
            comboBox.Items.Clear();
            ProductService productService = new ProductService();
            List<string> products = productService.ShowUniqProducts();
            foreach (string product in products)
            {
                comboBox.Items.Add(product);
            }
        }

        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            textBoxCount += 1;
            ComboBox comboBox1 = new ComboBox
            {
                Name = $"comboBoxProduct{textBoxCount}",
                Location = new System.Drawing.Point(35, 153 + (textBoxCount-1) * 37),
                Size = new Size(125, 27)
            };
            this.Controls.Add(comboBox1);
            LoadDataProduct(textBoxCount.ToString());

            TextBox textBox2 = new TextBox
            {
                Name = $"textBoxPrice{textBoxCount}",
                Location = new System.Drawing.Point(183, 153 + (textBoxCount - 1) * 37),
                Size = new Size(125, 27)
            };

            TextBox textBox3 = new TextBox
            {
                Name = $"textBoxAmount{textBoxCount}",
                Location = new System.Drawing.Point(328, 153 + (textBoxCount - 1) * 37),
                Size = new Size(125, 27)
            };
            Label labelError = new Label
            {
                Name = $"labelErrorType{textBoxCount}",
                Location = new System.Drawing.Point(506, 156 + (textBoxCount - 1) * 37),
                ForeColor = Color.Red,
                Text = "Ошибка типа данных",
                Size = new Size(157, 20)
            };
            labelError.Visible=false;

            
            this.Controls.Add(textBox2);
            this.Controls.Add(textBox3);
            this.Controls.Add(labelError);


        }

        private void ButtonCreateConsigment_Click(object sender, EventArgs e)
        {
            List<Consigment> consigments = new List<Consigment>();
            string product, price, amount;
            var productFields = this.Controls.OfType<ComboBox>()
                .Where(tb => tb.Name.StartsWith("comboBoxProduct"))
                .OrderBy(tb => tb.Name);

            var priceFields = this.Controls.OfType<TextBox>()
                .Where(tb => tb.Name.StartsWith("textBoxPrice"))
                .OrderBy(tb => tb.Name);

            var amountFields = this.Controls.OfType<TextBox>()
                .Where(tb => tb.Name.StartsWith("textBoxAmount"))
                .OrderBy(tb => tb.Name);
            for (int i = 0; i < productFields.Count(); i++)
            {
                try
                {
                    product = productFields.ElementAt(i).Text;
                    price = priceFields.ElementAt(i).Text;
                    amount = amountFields.ElementAt(i).Text;
                    if (!string.IsNullOrEmpty(product) && !string.IsNullOrEmpty(price) && !string.IsNullOrEmpty(amount))
                    {
                        consigments.Add(new Consigment
                        {
                            Product = product,
                            Price = Convert.ToInt32(price),
                            Amount = Convert.ToInt32(amount)
                        });
                    }
                    else
                    {
                        var label = this.Controls.Find($"labelErrorType{i+1}", true).FirstOrDefault() as Label;
                        label.Text = "Пустое значение";
                        label.Visible = true;
                    }
                }
                catch
                {
                    var label = this.Controls.Find($"labelErrorType{i+1}", true).FirstOrDefault() as Label;
                    label.Visible = true;
                }
            }
            AvailabilityService availabilityService = new AvailabilityService();
            bool isCreat = availabilityService.DeliverGoodsToTheStore(comboBoxStores.Text, consigments);
            if (isCreat) labelResultCreating.Visible = true;

        }
    }
}
