using AppStore.BLL;
using AppStore.DAL.Models;
using System.Data;
using Serilog;
using AppStore.API.Managers.Models;
using AppStore.API.Managers;

namespace AppStore.API.WinForms
{
    public partial class SearchStoreCheapestConsignmentForm : Form
    {
        private readonly MainForm _mainForm;
        private int textBoxCount = 1;
        private bool isError = false;
        private MessagesForms MessagesForms { get; } = ManagerJsonFiles.GetData<MessagesForms>(PathsFiles.MessagesForms);
        public SearchStoreCheapestConsignmentForm(MainForm mainForm)
        {
            Log.Information("Open Search Store Cheapest Consignment Form");
            InitializeComponent();
            LoadDataProduct("1");
            _mainForm = mainForm;
        }
        private void Back_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Back");
            _mainForm.Show();
            this.Close();
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

        private void ButtonAddField_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Add Field");
            textBoxCount += 1;
            var comboBox1 = new ComboBox
            {
                Name = $"comboBoxProduct{textBoxCount}",
                Location = new System.Drawing.Point(12, 124 + (textBoxCount - 1) * 37),
                Size = new Size(151, 27)
            };
            this.Controls.Add(comboBox1);
            LoadDataProduct(textBoxCount.ToString());

            var textBox2 = new TextBox
            {
                Name = $"textBoxAmount{textBoxCount}",
                Location = new System.Drawing.Point(216, 124 + (textBoxCount - 1) * 37),
                Size = new Size(125, 27)
            };
            var labelError = new Label
            {
                Name = $"labelErrorType{textBoxCount}",
                Location = new System.Drawing.Point(403, 124 + (textBoxCount - 1) * 37),
                ForeColor = Color.Red,
                Text = MessagesForms.DataTypeError,
                Size = new Size(157, 20)
            };
            labelError.Visible = false;
            this.Controls.Add(textBox2);
            this.Controls.Add(labelError);
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Search");
            isError = false;
            labelResult.Visible = false;
            var consignments = new List<Consignment>();
            var product = string.Empty;
            var amount = string.Empty;
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
                        consignments.Add(new Consignment
                        {
                            Product = product,
                            Price = 0,
                            Amount = Convert.ToInt32(amount)
                        });
                    }
                    else
                    {
                        var label = this.Controls.Find($"labelErrorType{i + 1}", true).FirstOrDefault() as Label;
                        label.Text = MessagesForms.EmptyFiledError;
                        label.Visible = true;
                        isError = true;
                        Log.Error("Empty \"product\" or \"amount\" field value");
                    }
                }
                catch
                {
                    var label = this.Controls.Find($"labelErrorType{i + 1}", true).FirstOrDefault() as Label;
                    label.Text = MessagesForms.DataTypeError;
                    label.Visible = true;
                    isError = true;
                    Log.Error("Invalid data type in the quantity field");
                }
            }
            if (consignments.Count != 0 && !isError)
            {
                var availabilityService = new AvailabilityService();
                var store = availabilityService.SearchStoreCheapestConsignment(consignments);
                if (string.IsNullOrEmpty(store))
                {
                    labelResult.Text = MessagesForms.LackConsignmentError;
                    labelResult.ForeColor = Color.Red;
                    labelResult.Visible = true;
                }
                else
                {
                    labelResult.Text = store;
                    labelResult.ForeColor = Color.Lime;
                    labelResult.Visible = true;
                }
            }
        }
    }
}
