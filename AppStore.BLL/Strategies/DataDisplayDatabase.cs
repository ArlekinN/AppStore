using AppStore.DAL.Repositories.Database;
using AppStore.DAL.Models;

namespace AppStore.BLL.Strategies
{
    internal class DataDisplayDatabase: IDataDisplay
    {
        private RepositoryAvailability RepositoryAvailability { get; } = RepositoryAvailability.GetInstance();
        private RepositoryStore RepositoryStore { get; } = RepositoryStore.GetInstance();
        private RepositoryProduct RepositoryProduct { get; } = RepositoryProduct.GetInstance();
        
        // все продукты 
        public List<ShowProduct> ShowAllProducts()
        {
            return RepositoryAvailability.GetAllProducts().Result;
        }
        // все магазины 
        public List<string> ShowAllStores()
        {
            return RepositoryStore.ShowAllStores().Result;
        }

        // список продуктов
        public List<string> ShowUniqueProducts()
        {
            return RepositoryProduct.ShowUniqueProducts().Result;
        }

        // создать магазин
        public bool CreateStore(string name, string address)
        {
            return RepositoryStore.CreateStore(name, address).Result;
        }

        // создать продукт
        public bool CreateProduct(string name)
        {
            return RepositoryProduct.CreateProduct(name).Result;
        }

        // завести партию товаров в магазин
        public bool DeliverGoodsToTheStore(string nameStore, List<Consignment> consignments)
        {
            var idStore = RepositoryStore.GetIdStoreByName(nameStore).Result;
            return RepositoryAvailability.DeliverGoodsToTheStore(idStore, consignments).Result;
        }

        // найти магазин магазин с самым дешевым товаром
        public List<string> SearchStoreCheapestProduct(string nameProduct)
        {
            var idProduct = RepositoryProduct.GetProductByName(nameProduct).Result;
            return RepositoryAvailability.SearchStoreCheapestProduct(idProduct).Result;
        }

        // найти товары, которые можно купить на сумму sum
        public List<ProductAmount> SearchProductOnTheSum(string nameStore, int sum)
        {
            var idStore = RepositoryStore.GetIdStoreByName(nameStore).Result;
            return RepositoryAvailability.SearchProductOnTheSum(idStore, sum).Result;
        }

        //  Купить партию товаров 
        public int BuyConsignmentInStore(string nameStore, List<Consignment> consignment)
        {
            var idStore = RepositoryStore.GetIdStoreByName(nameStore).Result;
            return RepositoryAvailability.BuyConsignmentInStore(idStore, consignment, true).Result;
        }

        // найти магазин, в которым партия товаров самая дешевая 
        public string SearchStoreCheapestConsignment(List<Consignment> consignment)
        {
            var stores = RepositoryStore.ShowAllStores().Result;
            var minPrice = -1;
            var priceCurrentStore = int.MinValue;
            var storeResult = string.Empty;
            foreach (var store in stores)
            {
                var idStore = RepositoryStore.GetIdStoreByName(store).Result;
                priceCurrentStore = RepositoryAvailability.BuyConsignmentInStore(idStore, consignment, false).Result;
                if ((minPrice == -1 && priceCurrentStore != 0) || (priceCurrentStore < minPrice && priceCurrentStore != 0))
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
