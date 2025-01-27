using AppStore.API.Managers.Models;
using AppStore.API.Managers;
using AppStore.BLL;
using Serilog;

namespace AppStore.API.WinForms
{
    public partial class CreateProductForm : Form
    {
        private readonly MainForm _mainForm;
        private MessagesForms MessagesForms { get; } = ManagerJsonFiles.GetData<MessagesForms>(PathsFiles.MessagesForms);
        public CreateProductForm(MainForm mainForm)
        {
            Log.Information("Open Create Product Form");
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Back");
            _mainForm.Show();
            this.Close();
        }

        private void ButtonCreateProduct_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Create Product");
            var product = textBoxNameProduct.Text;
            if (!string.IsNullOrEmpty(product))
            {
                var productService = new ProductService();
                var isCreating = productService.CreateProduct(product);
                if (isCreating)
                {
                    labelResultCreating.ForeColor = Color.Green;
                    labelResultCreating.Text = MessagesForms.Successfully;
                    labelResultCreating.Visible = true;
                }      
            }
            else
            {
                labelResultCreating.ForeColor = Color.Red;
                labelResultCreating.Text = MessagesForms.DataTypeError;
                labelResultCreating.Visible = true;
                Log.Error("Empty \"product\" field value");
            }
        }
    }
}
