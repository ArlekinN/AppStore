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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppStore.WinForms
{
    public partial class CreateStoreForm : Form
    {
        private MainForm _mainForm;
        public CreateStoreForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }
        private void Back_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void ButtonCreateStore_Click(object sender, EventArgs e)
        {
            string store = textBoxNameStore.Text;
            string address = textBoxAddressStore.Text;
            if(!string.IsNullOrEmpty(store) && !string.IsNullOrEmpty(address))
            {
                StoreService storeService = new StoreService();
                bool isCreatinhStore = storeService.CreateStore(store, address);
                if (isCreatinhStore) labelResultCreating.Visible=true;
            }
           
        }
    }
}
