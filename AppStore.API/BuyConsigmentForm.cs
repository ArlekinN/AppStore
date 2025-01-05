using AppStore.BLL;
using AppStore.DAL.Models;
using System.Data;

namespace AppStore.API.WinForms
{
    public partial class BuyConsigmentForm : Form
    {
        private MainForm _mainForm;
        private int textBoxCount = 1;
        private bool isError = false;
        public BuyConsigmentForm(MainForm mainForm)
        {
            InitializeComponent();
            LoadDataStore();
            LoadDataProduct("1");
            _mainForm = mainForm;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void LoadDataStore()
        {
            comboBoxStore.Items.Clear();
            StoreService storeService = new StoreService();
            List<string> stores = storeService.AllStores();
            foreach (string store in stores)
            {
                comboBoxStore.Items.Add(store);
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

        private void ButtonBuy_Click(object sender, EventArgs e)
        {
            isError = false;
            labelResult.Visible = false;
            labelSum.Visible = false;
            List<Consigment> consigments = new List<Consigment>();
            string product, amount;
            var productFields = this.Controls.OfType<ComboBox>()
                .Where(tb => tb.Name.StartsWith("comboBoxProduct"))
                .OrderBy(tb => tb.Name);

            var amountFields = this.Controls.OfType<TextBox>()
                .Where(tb => tb.Name.StartsWith("textBoxAmount"))
                .OrderBy(tb => tb.Name);

            var errorFields = this.Controls.OfType<Label>()
                .Where(tb => tb.Name.StartsWith("labelErrorType"))
                .OrderBy(tb => tb.Name);
            
            for (int i = 0; i < errorFields.Count(); i++)
            {
                var label = this.Controls.Find($"labelErrorType{i + 1}", true).FirstOrDefault() as Label;
                label.Visible = false;
            }
            
            for (int i = 0; i < productFields.Count(); i++)
            {
                try
                {
                    product = productFields.ElementAt(i).Text;
                    amount = amountFields.ElementAt(i).Text;
                    if (!string.IsNullOrEmpty(product) && !string.IsNullOrEmpty(amount))
                    {
                        consigments.Add(new Consigment
                        {
                            Product = product,
                            Price = 0,
                            Amount = Convert.ToInt32(amount)
                        });
                    }
                    else
                    {
                        var label = this.Controls.Find($"labelErrorType{i + 1}", true).FirstOrDefault() as Label;
                        label.Text = "Пустое значение";
                        label.Visible = true;
                        isError = true;
                    }
                }
                catch
                {
                    var label = this.Controls.Find($"labelErrorType{i + 1}", true).FirstOrDefault() as Label;
                    label.Text = "Ошибка типа данных";
                    label.Visible = true;
                    isError = true;
                }
            }
            if (consigments.Count != 0 && !isError && !string.IsNullOrEmpty(comboBoxStore.Text))
            {
                AvailabilityService availabilityService = new AvailabilityService();
                int commonPrice = availabilityService.BuyConsignmentInStore(comboBoxStore.Text, consigments);
                if (commonPrice == 0)
                {
                    labelResult.Text = "Невозможно совершить такую покупку";
                    labelResult.ForeColor = Color.Red;
                    labelResult.Visible = true;
                }
                else
                {
                    labelResult.Text = "Общая сумма:";
                    labelResult.Visible = true;
                    labelResult.ForeColor = Color.Black;
                    labelSum.Text = commonPrice.ToString();
                    labelSum.Visible = true;
                    labelSum.ForeColor = Color.Lime;
                    labelSum.TabIndex = 11;
                }
            }   
        }

        private void ButtonAddField_Click(object sender, EventArgs e)
        {
            textBoxCount += 1;
            ComboBox comboBox1 = new ComboBox
            {
                Name = $"comboBoxProduct{textBoxCount}",
                Location = new System.Drawing.Point(23, 156 + (textBoxCount - 1) * 37),
                Size = new Size(151, 27)
            };
            this.Controls.Add(comboBox1);
            LoadDataProduct(textBoxCount.ToString());

            TextBox textBox2 = new TextBox
            {
                Name = $"textBoxAmount{textBoxCount}",
                Location = new System.Drawing.Point(229, 156 + (textBoxCount - 1) * 37),
                Size = new Size(125, 27)
            };
            Label labelError = new Label
            {
                Name = $"labelErrorType{textBoxCount}",
                Location = new System.Drawing.Point(403, 156 + (textBoxCount - 1) * 37),
                ForeColor = Color.Red,
                Text = "Ошибка типа данных",
                Size = new Size(157, 20)
            };
            labelError.Visible = false;
            this.Controls.Add(textBox2);
            this.Controls.Add(labelError);
        }
    }
}
