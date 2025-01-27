using AppStore.API.Managers.Models;
using AppStore.API.Managers;
using AppStore.BLL;
using Serilog;

namespace AppStore.API.WinForms
{
    public partial class CreateStoreForm : Form
    {
        private readonly MainForm _mainForm;
        private MessagesForms MessagesForms { get; } = ManagerJsonFiles.GetData<MessagesForms>(PathsFiles.MessagesForms);
        public CreateStoreForm(MainForm mainForm)
        {
            Log.Information("Open Create Store Form");
            InitializeComponent();
            _mainForm = mainForm;
        }
        private void Back_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Back");
            _mainForm.Show();
            this.Close();
        }

        private void ButtonCreateStore_Click(object sender, EventArgs e)
        {
            Log.Information("Click button :: Create Store");
            var store = textBoxNameStore.Text;
            var address = textBoxAddressStore.Text;
            if(!string.IsNullOrEmpty(store) && !string.IsNullOrEmpty(address))
            {
                var storeService = new StoreService();
                var isCreateStore = storeService.CreateStore(store, address);
                if (isCreateStore)
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
                Log.Error("Empty \"store\" or \"address\" field value");
            }
        }
    }
}
