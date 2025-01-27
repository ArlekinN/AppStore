using Serilog;

namespace AppStore.API.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Log.Information("Open Main Form");
            InitializeComponent();
        }

        private void ListProducts_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: List Products");
            var listProductForm = new ListProductsForm(this);
            listProductForm.Show();
            this.Hide();
        }

        private void CreateStore_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Create Store");
            var createStoreForm = new CreateStoreForm(this);
            createStoreForm.Show();
            this.Hide();
        }

        private void CreateProduct_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Create Product");
            var createProductForm = new CreateProductForm(this);
            createProductForm.Show();
            this.Hide();
        }

        private void DeliverGoodsToTheStore_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Deliver Goods To The Store");
            var deliverGoodsToTheStoreForm = new DeliverGoodsToTheStoreForm(this);
            deliverGoodsToTheStoreForm.Show();   
            this.Hide();
        }

        private void SearchStoreCheapestProduct_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Search Store Cheapest Product");
            var searchStoreCheapestProductForm = new SearchStoreCheapestProductForm(this);
            searchStoreCheapestProductForm.Show();
            this.Hide();
        }

        private void SetOfProductOnTheSum_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Set Of Product On The Sum");
            var setOfProductOnTheSumForm = new SetOfProductOnTheSumForm(this);
            setOfProductOnTheSumForm.Show();
            this.Hide();
        }

        private void BuyConsignment_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Buy Consignment");
            var buyConsignmentForm = new BuyConsignmentForm(this);
            buyConsignmentForm.Show();
            this.Hide();
        }

        private void SearchCheapestConsignment_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Search Cheapest Consignment");
            var searchCheapestConsignmentForm = new SearchStoreCheapestConsignmentForm(this);
            searchCheapestConsignmentForm.Show();
            this.Hide();
        }
    }
}
