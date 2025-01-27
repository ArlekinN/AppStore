using AppStore.BLL.Strategies;
using AppStore.DAL.Configuration;
using Serilog;

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
            Log.Information("StoreService: Create Store");
            return DataDisplay.CreateStore(name, address);
        }

        public List<string> AllStores()
        {
            Log.Information("StoreService: All Stores");
            return DataDisplay.ShowAllStores();
        }

        public List<string> SearchStoreCheapestProduct(string product)
        {
            Log.Information("StoreService: Search Store Cheapest Product");
            return DataDisplay.SearchStoreCheapestProduct(product);
        }
    }
}
