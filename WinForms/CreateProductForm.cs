using AppStore.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppStore.WinForms
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
            labelResultCreating.Hide();
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
                if(isCreating) labelResultCreating.Show();
            }
        }
    }
}
