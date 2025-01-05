using AppStore.BLL.Strategies;
using AppStore.DAL.Configuration;

namespace AppStore.BLL
{
    public class StoreService
    {
        private IDataDisplay DataDisplay { get; set; }
        public StoreService()
        {
            if (Config.TypeDal == "Database")
            {
                DataDisplay = new DataDisplayDatabase();
            }
            else
            {
                DataDisplay = new DataDisplayFiles();
            }
        }
        public bool CreateStore(string name, string address)
        {
            return DataDisplay.CreateStore(name, address);
        }
        public List<string> AllStores()
        {
            return DataDisplay.ShowAllStores();
        }

        public List<string> SearchStoreCheapestProduct(string product)
        {
            return DataDisplay.SearchStoreCheapestProduct(product);
        }
    }
}
