using AppStore.DAL.Models;

namespace AppStore.DAL.Interfaces
{
    public interface IRepositoryAvailability
    {
        List<ShowProduct> GetAllProducts() { return []; }

        bool DeliverGoodsToTheStore() { return false; }

        List<string> SearchStoreCheapestProduct() { return []; }

        List<ProductAmount> SearchProductOnTheSum() { return []; }

        int BuyConsignmentInStore() { return 0; }
    }
}
