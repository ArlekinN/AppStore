using AppStore.DAL.Models;
using AppStore.DAL.Repositories.Files;

namespace AppStore.BLL.Strategies
{
    internal class DataDisplayFiles: IDataDisplay
    {
        private RepositoryAvailability RepositoryAvailability { get;} = RepositoryAvailability.GetInstance();
        private RepositoryStore RepositoryStore { get; } = RepositoryStore.GetInstance();
        private RepositoryProduct RepositoryProduct { get; } = RepositoryProduct.GetInstance();

        // все продукты 
        public List<ShowProduct> ShowAllProducts()
        {
            return RepositoryAvailability.GetAllProducts(false); 
        }

        // все магазины
        public List<string> ShowAllStores()
        {
            return RepositoryStore.ShowAllStores();
        }

        // список продуктов
        public List<string> ShowUniqueProducts()
        {
            return RepositoryProduct.ShowUniqueProducts();
        }

        // создать магазин
        public bool CreateStore(string name, string address)
        {
            return RepositoryStore.CreateStore(name, address);
        }

        // создать продукт
        public bool CreateProduct(string name)
        {
            return RepositoryProduct.CreateProduct(name);
        }

        // завести партию товаров в магазин
        public bool DeliverGoodsToTheStore(string nameStore, List<Consignment> consignments)
        {
            var idStore = RepositoryStore.GetStoreByName(nameStore);
            return RepositoryAvailability.DeliverGoodsToTheStore(idStore, consignments);
        }

        // найти магазин магазин с самым дешевым товаром
        public List<string> SearchStoreCheapestProduct(string nameProduct)
        {
            return RepositoryAvailability.SearchStoreCheapestProduct(nameProduct);
        }

        // найти товары, которые можно купить на сумму sum
        public List<ProductAmount> SearchProductOnTheSum(string nameStore, int sum)
        {
            return RepositoryAvailability.SearchProductOnTheSum(nameStore, sum);
        }

        //  Купить партию товаров 
        public int BuyConsignmentInStore(string nameStore, List<Consignment> consignment)
        {
            return RepositoryAvailability.BuyConsignmentInStore(nameStore, consignment, true);
        }

        // найти магазин, в которым партия товаров самая дешевая 
        public string SearchStoreCheapestConsignment(List<Consignment> consignment)
        {
            var stores = RepositoryStore.ShowAllStores();
            var minPrice = -1;
            var priceCurrentStore = int.MinValue;
            var storeResult = string.Empty;
            foreach (var store in stores)
            {
                priceCurrentStore = RepositoryAvailability.BuyConsignmentInStore(store, consignment, false);
                if ((minPrice == -1 && priceCurrentStore != 0) || (priceCurrentStore < minPrice && priceCurrentStore!=0))
                {
                    minPrice = priceCurrentStore;
                    storeResult = store;
                }
            }
            if (minPrice <= 0) return "";
            return storeResult;
        }
    }
}
