using AppStore.API.Managers.Models;
using AppStore.API.Managers;
using AppStore.BLL;
using Serilog;

namespace AppStore.API.WinForms
{
    public partial class SearchStoreCheapestProductForm : Form
    {
        private readonly MainForm _mainForm;
        private MessagesForms MessagesForms { get; } = ManagerJsonFiles.GetData<MessagesForms>(PathsFiles.MessagesForms);
        public SearchStoreCheapestProductForm(MainForm mainForm)
        {
            Log.Information("Open Search Store Cheapest Product Form");
            InitializeComponent();
            LoadDataProducts();
            _mainForm = mainForm;
        }
        private void Back_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Back");
            _mainForm.Show();
            this.Close();
        }

        private void LoadDataProducts()
        {
            Log.Debug("Load list products");
            comboBoxProduct.Items.Clear();
            var productService = new ProductService();
            var products = productService.ShowUniqueProducts();
            foreach (string product in products)
            {
                comboBoxProduct.Items.Add(product);
            }
        }

        private void ButtonSearchStore_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Search Store");
            var product = comboBoxProduct.Text;
            var result = new List<string>();
            if (!string.IsNullOrEmpty(product))
            {
                labelErrorType.Visible = false;
                var availabilityService = new AvailabilityService();
                result = availabilityService.SearchStoreCheapestProduct(product);
                labelGetStore.Text = result[0];
                labelGetPrice.Text = result[1];
                labelGetPrice.Visible = true;
                labelGetStore.Visible = true;
                labelPrice.Visible = true;
                labelStore.Visible = true;
            }
            else
            {
                labelErrorType.Text = MessagesForms.EmptyFiledError;
                labelErrorType.Visible = true;
                Log.Error("Empty \"product\" field value");
            }
        }
    }
}
