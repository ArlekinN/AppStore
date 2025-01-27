using AppStore.BLL;
using AppStore.DAL.Models;
using System.Data;
using Serilog;
using AppStore.API.Managers.Models;
using AppStore.API.Managers;

namespace AppStore.API.WinForms
{
    public partial class DeliverGoodsToTheStoreForm : Form
    {
        private readonly MainForm _mainForm;
        private int _textBoxCount = 1;
        private bool _isError = false;
        private MessagesForms MessagesForms { get; } = ManagerJsonFiles.GetData<MessagesForms>(PathsFiles.MessagesForms);
        public DeliverGoodsToTheStoreForm(MainForm mainForm)
        {
            Log.Information("Open Deliver Goods To The Store Form");
            InitializeComponent();
            LoadDataStore();
            LoadDataProduct("1");
            _mainForm = mainForm;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Back");
            _textBoxCount = 1;
            _mainForm.Show();
            this.Close();
        }

        private void LoadDataStore()
        {
            Log.Debug("Load list stores");
            comboBoxStores.Items.Clear();
            var storeService = new StoreService();
            var stores = storeService.AllStores();
            foreach (string store in stores)
            {
                comboBoxStores.Items.Add(store);
            }
        }
        private void LoadDataProduct(string i)
        {
            Log.Debug("Load list products");
            var nameComboBoxProduct = $"comboBoxProduct{i}";
            var comboBox = this.Controls.Find(nameComboBoxProduct, true).FirstOrDefault() as ComboBox;
            comboBox.Items.Clear();
            var productService = new ProductService();
            var products = productService.ShowUniqueProducts();
            foreach (string product in products)
            {
                comboBox.Items.Add(product);
            }
        }

        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Add Product");
            _textBoxCount += 1;
            var comboBox1 = new ComboBox
            {
                Name = $"comboBoxProduct{_textBoxCount}",
                Location = new System.Drawing.Point(35, 153 + (_textBoxCount-1) * 37),
                Size = new Size(125, 27)
            };
            this.Controls.Add(comboBox1);
            LoadDataProduct(_textBoxCount.ToString());

            var  textBox2 = new TextBox
            {
                Name = $"textBoxPrice{_textBoxCount}",
                Location = new System.Drawing.Point(183, 153 + (_textBoxCount - 1) * 37),
                Size = new Size(125, 27)
            };

            var textBox3 = new TextBox
            {
                Name = $"textBoxAmount{_textBoxCount}",
                Location = new System.Drawing.Point(328, 153 + (_textBoxCount - 1) * 37),
                Size = new Size(125, 27)
            };
            var labelError = new Label
            {
                Name = $"labelErrorType{_textBoxCount}",
                Location = new System.Drawing.Point(459, 156 + (_textBoxCount - 1) * 37),
                ForeColor = Color.Red,
                Size = new Size(157, 20)
            };
            labelError.Visible=false;
            this.Controls.Add(textBox2);
            this.Controls.Add(textBox3);
            this.Controls.Add(labelError);
        }

        private void ButtonCreateConsignment_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Create Consignment");
            _isError = false;
            var consignments = new List<Consignment>();
            var product = string.Empty;
            var price = string.Empty;
            var amount = string.Empty;
            var productFields = this.Controls.OfType<ComboBox>()
                .Where(tb => tb.Name.StartsWith("comboBoxProduct"))
                .OrderBy(tb => tb.Name);

            var priceFields = this.Controls.OfType<TextBox>()
                .Where(tb => tb.Name.StartsWith("textBoxPrice"))
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
                    price = priceFields.ElementAt(i).Text;
                    amount = amountFields.ElementAt(i).Text;
                    if (!string.IsNullOrEmpty(product) && !string.IsNullOrEmpty(price) && !string.IsNullOrEmpty(amount))
                    {
                        consignments.Add(new Consignment
                        {
                            Product = product,
                            Price = Convert.ToInt32(price),
                            Amount = Convert.ToInt32(amount)
                        });
                    }
                    else
                    {
                        var label = this.Controls.Find($"labelErrorType{i+1}", true).FirstOrDefault() as Label;
                        label.Text = MessagesForms.EmptyFiledError;
                        label.Visible = true;
                        _isError = true;
                        Log.Error("Empty \"product\" or \"amount\" or \"price\" field value");
                    }
                }
                catch
                {
                    var label = this.Controls.Find($"labelErrorType{i+1}", true).FirstOrDefault() as Label;
                    label.Text = MessagesForms.DataTypeError;
                    label.Visible = true;
                    _isError = true;
                    Log.Error("Invalid data type in the quantity field");
                }
            }
            if (string.IsNullOrEmpty(comboBoxStores.Text))
            {
                labelResult.Text = MessagesForms.UnselectedStoreError;
                labelResult.Visible = true;
                labelResult.ForeColor = Color.Red;
                _isError = true;
                Log.Error("Store not selected from the list");
            }
            if (consignments.Count != 0 && !_isError)
            {
                var availabilityService = new AvailabilityService();
                var isCreate = availabilityService.DeliverGoodsToTheStore(comboBoxStores.Text, consignments);
                if (isCreate)
                {
                    labelResult.ForeColor = Color.Green;
                    labelResult.Text = MessagesForms.Successfully;
                    labelResult.Visible = true;
                }
                    
            }
        }
    }
}
