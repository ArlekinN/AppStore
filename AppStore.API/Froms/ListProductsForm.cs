using AppStore.BLL;
using Serilog;

namespace AppStore.API.WinForms
{
    public partial class ListProductsForm : Form
    {
        private readonly MainForm _mainForm;
        
        public ListProductsForm(MainForm mainForm)
        {
            Log.Information("Open List Products Form");
            InitializeComponent();
            _mainForm = mainForm;
            LoadProductsIntoGrid();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Back");
            _mainForm.Show();
            this.Close();
        }

        private void LoadProductsIntoGrid()
        {
            Log.Debug("Load list products into grid");
            var products = new AvailabilityService();
            dataGridViewListProduct.DataSource = products.ShowAllProducts();
            dataGridViewListProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
