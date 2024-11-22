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
using AppStore.DAL.Repositories.Database;

namespace AppStore.WinForms
{
    public partial class ListProductsForm : Form
    {
        private MainForm _mainForm;
        private List<ShowProduct> _products;
        
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
        
    }
}
