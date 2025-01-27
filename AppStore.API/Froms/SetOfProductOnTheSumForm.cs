using Serilog;
using AppStore.BLL;
using AppStore.API.Managers.Models;
using AppStore.API.Managers;

namespace AppStore.API.WinForms
{
    public partial class SetOfProductOnTheSumForm : Form
    {
        private readonly MainForm _mainForm;
        private MessagesForms MessagesForms { get; } = ManagerJsonFiles.GetData<MessagesForms>(PathsFiles.MessagesForms);
        public SetOfProductOnTheSumForm(MainForm mainForm)
        {
            Log.Information("Set of Product On The Sum Form");
            InitializeComponent();
            LoadDataStore();
            _mainForm = mainForm;
        }
        private void Back_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Back");
            _mainForm.Show();
            this.Close();
        }
        private void LoadDataStore()
        {
            Log.Debug("Load list stores");
            comboBoxStore.Items.Clear();
            var storeService = new StoreService();
            var stores = storeService.AllStores();
            foreach (string store in stores)
            {
                comboBoxStore.Items.Add(store);
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Search");
            labelTypeError.Visible = false;
            labelListProduct.Visible = false;
            dataGridViewProducts.Visible = false;
            labelListEmpty.Visible = false;
            var store = comboBoxStore.Text;
            try
            {
                if (string.IsNullOrEmpty(store) || string.IsNullOrEmpty(textBoxSum.Text))
                {
                    labelTypeError.Text = MessagesForms.EmptyFiledError;
                    labelTypeError.Visible = true;
                    Log.Error("Empty \"store\" or \"sum\" field value");
                }
                else
                {
                    var sum = Convert.ToInt32(textBoxSum.Text);
                    var availabilityService = new AvailabilityService();
                    var products = availabilityService.SearchProductOnTheSum(store, sum);
                    labelListProduct.Visible = true;
                    if (products.Count != 0)
                    {
                        dataGridViewProducts.DataSource = products;
                        dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridViewProducts.Visible = true;
                    }
                    else
                    {
                        labelTypeError.Text = MessagesForms.DataTypeError;
                        labelListEmpty.Visible = true;
                        Log.Error("Invalid data type in the quantity field");
                    }
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
