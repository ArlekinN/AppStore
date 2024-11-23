using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Models.Files;
using AppStore.Models;
using AppStore.DAL.Repositories.Files;

namespace AppStore.BLL.Strategies
{
    internal class DataDisplayFiles: IDataDisplay
    {
        private static RepositoryAvailability _repositoryAvailability = RepositoryAvailability.GetInstance();
        private static RepositoryStore _repositoryStore = RepositoryStore.GetInstance();
        private static RepositoryProduct _repositoryProduct = RepositoryProduct.GetInstance();
        // все продукты 
        public override List<ShowProduct> ShowAllProducts()
        {
            return _repositoryAvailability.GetAllProducts(false); 
        }
        // все магазины
        public override List<string> ShowAllStores()
        {
            return _repositoryStore.ShowAllStores();
        }
        // список продуктов
        public override List<string> ShowUniqProducts()
        {
            return _repositoryProduct.ShowUniqProducts();
        }
        // создать магазин
        public override bool CreateStore(string name, string address)
        {
            return _repositoryStore.CreateStore(name, address);
        }
        // создать продукт
        public override bool CreateProduct(string name)
        {
            return _repositoryProduct.CreateProduct(name);
        }
        // завести партию товаров в магазин
        public override bool DeliverGoodsToTheStore(string nameStore, List<Consigment> consigments)
        {
            int idStore = _repositoryStore.GetStoreByName(nameStore);
            return _repositoryAvailability.DeliverGoodsToTheStore(idStore, consigments);
        }

        // найти магазин магазин с самым дешевым товаром
        public override List<string> SearchStoreCheapestProduct(string nameProduct)
        {
            return _repositoryAvailability.SearchStoreCheapestProduct(nameProduct);
        }
        // найти товары, которые можно купить на сумму sum
        public override List<ProductAmount> SearchProductOnTheSum(string nameStore, int sum)
        {
            return _repositoryAvailability.SearchProductOnTheSum(nameStore, sum);
        }
        //  Купить партию товаров 
        public override int BuyConsignmentInStore(string nameStore, List<Consigment> consigment)
        {
            return _repositoryAvailability.BuyConsignmentInStore(nameStore, consigment, true);
        }
        // найти магазин, в которым паратия товаров самая дешевая 
        public override string SearchStoreCheapestConsigment(List<Consigment> consigment)
        {
            var stores = _repositoryStore.ShowAllStores();
            int minPrice = -1, priceCurrentStore;
            string storeResult = "";
            foreach (var store in stores)
            {
                priceCurrentStore = _repositoryAvailability.BuyConsignmentInStore(store, consigment, false);
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
