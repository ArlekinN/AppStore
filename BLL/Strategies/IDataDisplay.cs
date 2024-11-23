using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.BLL.Strategies
{
    internal abstract class  IDataDisplay
    {
        // все продукты
        public abstract List<ShowProduct> ShowAllProducts();

        // все магазины
        public abstract List<string> ShowAllStores();

        // список продуктов
        public abstract List<string> ShowUniqProducts();

        // создать магазин
        public abstract bool CreateStore(string name, string address);
        // создать продукт
        public abstract bool CreateProduct(string name);
        // завести партию товаров в магазин
        public abstract bool DeliverGoodsToTheStore(string nameStore, List<Consigment> consigments);
        // обновить цену партии товаров в магазине
        public abstract bool UpdatePriceOfGoodsInStore(string nameStore, List<Consigment> consigments);
        // найти магазин магазин с самым дешевым товаром
        public abstract List<string> SearchStoreCheapestProduct(string nameProduct);
        // найти товары, которые можно купить на сумму sum
        public abstract List<ProductAmount> SearchProductOnTheSum(string nameStore, int sum);
        //  Купить партию товаров 
        public abstract int BuyConsignmentInStore(string nameStore, List<Consigment> consigment);
        // найти магазин, в которым паратия товаров самая дешевая 
        public abstract string SearchStoreCheapestConsigment(List<Consigment> consigment);
    }
}
