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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        private void ListProducts_Click(object sender, EventArgs e)
        {
            ListProductsForm listProductForm = new ListProductsForm(this);

            listProductForm.Show();

            this.Hide();
        }

        private void CreateStore_Click(object sender, EventArgs e)
        {
            CreateStoreForm createStoreForm = new CreateStoreForm(this);

            createStoreForm.Show();

            this.Hide();
        }

        private void CreateProduct_Click(object sender, EventArgs e)
        {
            CreateProductForm createProductForm = new CreateProductForm(this);

            createProductForm.Show();

            this.Hide();
        }

        private void DeliverGoodsToTheStore_Click(object sender, EventArgs e)
        {
            DeliverGoodsToTheStoreForm deliverGoodsToTheStoreForm = new DeliverGoodsToTheStoreForm(this);
            
            deliverGoodsToTheStoreForm.Show();
            
            this.Hide();
        }

        private void SearchStoreCheapestProduct_Click(object sender, EventArgs e)
        {
            SearchStoreCheapestProductForm searchStoreCheapestProductForm = new SearchStoreCheapestProductForm(this);

            searchStoreCheapestProductForm.Show();

            this.Hide();
        }

        private void SetofProductOnTheSum_Click(object sender, EventArgs e)
        {
            SetofProductOnTheSumForm setofProductOnTheSumForm = new SetofProductOnTheSumForm(this);

            setofProductOnTheSumForm.Show();

            this.Hide();
        }

        private void BuyConsignment_Click(object sender, EventArgs e)
        {
            BuyConsigmentForm buyConsignmentForm = new BuyConsigmentForm(this);

            buyConsignmentForm.Show();

            this.Hide();
        }

        private void SearchCheapestConsigment_Click(object sender, EventArgs e)
        {
            SearchStoreCheapestConsigmentForm searchCheapestConsigmentForm = new SearchStoreCheapestConsigmentForm(this);

            searchCheapestConsigmentForm.Show();

            this.Hide();
        }
    }
}
