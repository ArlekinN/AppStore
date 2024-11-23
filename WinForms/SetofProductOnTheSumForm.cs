using AppStore.BLL;
using AppStore.Models;
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
    public partial class SetofProductOnTheSumForm : Form
    {
        private MainForm _mainForm;
        public SetofProductOnTheSumForm(MainForm mainForm)
        {
            InitializeComponent();
            LoadDataStore();
            _mainForm = mainForm;
        }
        private void Back_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }
        private void LoadDataStore()
        {
            comboBoxStore.Items.Clear();
            StoreService storeService = new StoreService();
            List<string> stores = storeService.AllStores();
            foreach (string store in stores)
            {
                comboBoxStore.Items.Add(store);
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            labelTypeError.Visible = false;
            labelListProduct.Visible = false;
            dataGridViewProducts.Visible = false;
            labelListEmpty.Visible = false;
            string store = comboBoxStore.Text;
            try
            {
                int sum = Convert.ToInt32(textBoxSum.Text);
                AvailabilityService availabilityService = new AvailabilityService();
                List<ProductAmount> products = availabilityService.SearchProductOnTheSum(store, sum);
                labelListProduct.Visible = true;
                if (products.Count!=0)
                {
                    dataGridViewProducts.DataSource = products;
                    dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewProducts.Visible = true;
                }
                else
                {
                    labelListEmpty.Visible = true;
                }
                
            }
            catch
            {
                labelTypeError.Visible = true;
                dataGridViewProducts.Visible = false;
                labelListProduct.Visible = false;
            }
        }
    }
}
