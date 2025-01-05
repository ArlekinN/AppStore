using AppStore.DAL.Models;

namespace AppStore.DAL.Interfaces
{
    public abstract class IRepositoryAvailability
    {
        public List<ShowProduct> GetAllProducts() { return new List<ShowProduct>(); }

        public bool DeliverGoodsToTheStore() { return true; }
        public List<string> SearchStoreCheapestProduct() { return new List<string>(); }

        public List<ProductAmount> SearchProductOnTheSum() { return new List<ProductAmount>(); }
        public int BuyConsignmentInStore() { return 0; }
    }
}
