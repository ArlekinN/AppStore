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
    }
}
