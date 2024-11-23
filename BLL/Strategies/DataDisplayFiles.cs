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
            return _repositoryAvailability.GetAllProducts(); 
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
            return new List<string>();
        }
        // найти товары, которые можно купить на сумму sum
        public override List<ProductAmount> SearchProductOnTheSum(string nameStore, int sum)
        {
            List<ProductAmount> products = new List<ProductAmount>();
            return products;
        }
        //  Купить партию товаров 
        public override int BuyConsignmentInStore(string nameStore, List<Consigment> consigment)
        {
            return 0;
        }
        // найти магазин, в которым паратия товаров самая дешевая 
        public override string SearchStoreCheapestConsigment(List<Consigment> consigment)
        {
            return "";
        }
    }
}
