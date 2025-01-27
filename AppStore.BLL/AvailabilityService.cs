using AppStore.BLL.Strategies;
using AppStore.DAL.Configuration;
using AppStore.DAL.Models;
using Serilog;

namespace AppStore.BLL
{
    public class AvailabilityService
    {
        private IDataDisplay DataDisplay { get; set; }
        public AvailabilityService()
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

        public List<ShowProduct> ShowAllProducts()
        {
            Log.Information("AvailabilityService: ShowAllProducts");
            return DataDisplay.ShowAllProducts();
        }

        public bool DeliverGoodsToTheStore(string nameStore, List<Consignment> consignments)
        {
            Log.Information("AvailabilityService: Deliver Goods To The Store");
            return DataDisplay.DeliverGoodsToTheStore(nameStore, consignments);
        }

        public List<ProductAmount> SearchProductOnTheSum(string nameStore, int sum)
        {
            Log.Information("AvailabilityService: Search Product On The Sum");
            return DataDisplay.SearchProductOnTheSum(nameStore, sum);
        }

        public int BuyConsignmentInStore(string nameStore, List<Consignment> consignment)
        {
            Log.Information("AvailabilityService: Buy Consignment In Store");
            return DataDisplay.BuyConsignmentInStore(nameStore, consignment);
        }

        public List<string> SearchStoreCheapestProduct(string nameProduct)
        {
            Log.Information("AvailabilityService: Search Store Cheapest Product");
            return DataDisplay.SearchStoreCheapestProduct(nameProduct);
        }

        public string SearchStoreCheapestConsignment(List<Consignment> consignment)
        {
            Log.Information("AvailabilityService: Search Store Cheapest Consignment");
            return DataDisplay.SearchStoreCheapestConsignment(consignment);
        }
    }
}
