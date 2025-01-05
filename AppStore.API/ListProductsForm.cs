using AppStore.BLL;

namespace AppStore.API.WinForms
{
    public partial class ListProductsForm : Form
    {
        private MainForm _mainForm;
        
        public ListProductsForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            LoadProductsIntoGrid();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void LoadProductsIntoGrid()
        {
            var products = new AvailabilityService();
            dataGridViewListProduct.DataSource = products.ShowAllProducts();
            dataGridViewListProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
