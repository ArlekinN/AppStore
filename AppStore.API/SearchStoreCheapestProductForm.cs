using AppStore.BLL;

namespace AppStore.API.WinForms
{
    public partial class SearchStoreCheapestProductForm : Form
    {
        private MainForm _mainForm;
        public SearchStoreCheapestProductForm(MainForm mainForm)
        {
            InitializeComponent();
            LoadDataProducts();
            _mainForm = mainForm;
        }
        private void Back_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void LoadDataProducts()
        {
            comboBoxProduct.Items.Clear();
            ProductService productService = new ProductService();
            List<string> products = productService.ShowUniqProducts();
            foreach (string product in products)
            {
                comboBoxProduct.Items.Add(product);
            }
        }

        private void ButtonSearchStore_Click(object sender, EventArgs e)
        {
            var product = comboBoxProduct.Text;
            var result = new List<string>();
            if (!string.IsNullOrEmpty(product))
            {
                AvailabilityService availabilityService = new AvailabilityService();
                result = availabilityService.SearchStoreCheapestProduct(product);
                labelGetStore.Text = result[0];
                labelGetPrice.Text = result[1];
                labelGetPrice.Visible = true;
                labelGetStore.Visible = true;
                labelPrice.Visible = true;
                labelStore.Visible = true;
            }
        }
    }
}
