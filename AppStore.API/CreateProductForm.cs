using AppStore.BLL;

namespace AppStore.API.WinForms
{
    public partial class CreateProductForm : Form
    {
        private MainForm _mainForm;
        public CreateProductForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void buttonCreateProduct_Click(object sender, EventArgs e)
        {
            string product = textBoxNameProduct.Text;
            if (!string.IsNullOrEmpty(product))
            {
                ProductService productService = new ProductService();
                bool isCreating = productService.CreateProduct(product);
                if(isCreating) labelResultCreating.Visible=true;
            }
        }
    }
}
