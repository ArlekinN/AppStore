using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.DAL.Repositories.Database;
using AppStore.Models;
using AppStore.Models.Database;


namespace AppStore.BLL.Strategies
{
    internal class DataDisplayDatabase: IDataDisplay
    {
        private static RepositoryAvailability _repositoryAvailability = RepositoryAvailability.GetInstance();
        private static RepositoryStore _repositoryStore = RepositoryStore.GetInstance();
        private static RepositoryProduct _repositoryProduct = RepositoryProduct.GetInstance();
        // все продукты 
        public override List<ShowProduct> ShowAllProducts()
        {
            return _repositoryAvailability.GetAllProducts().Result;
        }
        // все магазины 
        public override List<string> ShowAllStores()
        {
            return _repositoryStore.ShowAllStores().Result;
        }

        // список продуктов
        public override List<string> ShowUniqProducts()
        {
            return _repositoryProduct.ShowUniqProducts().Result;
        }

        // создать магазин
        public override bool CreateStore(string name, string address)
        {
            return _repositoryStore.CreateStore(name, address).Result;
        }
        // создать продукт
        public override bool CreateProduct(string name)
        {
            return _repositoryProduct.CreateProduct(name).Result;
        }
        // завести партию товаров в магазин
        public override bool DeliverGoodsToTheStore(string nameStore, List<Consigment> consigments)
        {
            int idStore = _repositoryStore.GetStoreByName(nameStore).Result;
            return _repositoryAvailability.DeliverGoodsToTheStore(idStore, consigments).Result;
        }
        // обновить цену партии товаров в магазине
        public override bool UpdatePriceOfGoodsInStore(string nameStore, List<Consigment> consigments)
        {
            return true;
        }
        // найти магазин магазин с самым дешевым товаром
        public override List<string> SearchStoreCheapestProduct(string nameProduct)
        {
            int idProduct = _repositoryProduct.GetProductByName(nameProduct).Result;
            return _repositoryAvailability.SearchStoreCheapestProduct(idProduct).Result;
        }
        // найти товары, которые можно купить на сумму sum
        public override List<ProductAmount> SearchProductOnTheSum(string nameStore, int sum)
        {
            int idStore = _repositoryStore.GetStoreByName(nameStore).Result;
            return _repositoryAvailability.SearchProductOnTheSum(idStore, sum).Result;
        }
        //  Купить партию товаров 
        public override int BuyConsignmentInStore(string nameStore, List<Consigment> consigment)
        {
            int idStore = _repositoryStore.GetStoreByName(nameStore).Result;
            return _repositoryAvailability.BuyConsignmentInStore(idStore, consigment).Result;
        }
        // найти магазин, в которым паратия товаров самая дешевая 
        public override string SearchStoreCheapestConsigment(List<Consigment> consigment)
        {
            var stores = _repositoryStore.ShowAllStores().Result;
            int minPrice = -1, priceCurrentStore;
            string storeResult = "";
            foreach (var store in stores)
            {
                priceCurrentStore = BuyConsignmentInStore(store, consigment);
                if (minPrice == -1 || priceCurrentStore < minPrice)
                {
                    minPrice = priceCurrentStore;
                    storeResult = store;
                }
            }
            if (minPrice == 0) return "";
            return storeResult;
        }
    }
}
