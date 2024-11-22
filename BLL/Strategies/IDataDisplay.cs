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

        // создать магазин
        public abstract bool CreateStore(string name, string address);
        // создать продукт
        public abstract bool CreateProduct(string name);
        // завести партию товаров в магазин
        public abstract bool DeliverGoodsToTheStore(string nameStore, List<dynamic> consigments);
        // обновить цену партии товаров в магазине
        public abstract bool UpdatePriceOfGoodsInStore(string nameStore, List<dynamic> consigments);
        // найти магазин магазин с самым дешевым товаром
        public abstract string SearchStoreCheapestProduct(string nameProduct);
        // найти товары, которые можно купить на сумму sum
        public abstract List<dynamic> SearchProductOnTheSum(string nameStore, int sum);
        //  Купить партию товаров 
        public abstract int BuyConsignmentInStore(string nameStore, List<dynamic> consigment);
        // найти магазин, в которым паратия товаров самая дешевая 
        public abstract string SearchStoreCheapestConsigment(List<dynamic> consigment);
    }
}
