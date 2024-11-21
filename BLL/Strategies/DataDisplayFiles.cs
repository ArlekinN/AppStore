using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Models.Files;

namespace AppStore.BLL.Strategies
{
    internal class DataDisplayFiles<Consigment, Product>
    {
        // создать магазин
        public bool CreateStore(string name, string address)
        {
            return true;
        }
        // создать продукт
        public bool CreateProduct(string name)
        {
            return true;
        }
        // завести партию товаров в маг{азин
        public bool DeliverGoodsToTheStore(string nameStore, List<Consigment> consigments)
        {
            return true;
        }
        // обновить цену партии товаров в магазине
        public bool UpdatePriceOfGoodsInStore(string nameStore, List<Consigment> consigments)
        {
            return true;
        }
        // найти магазин магазин с самым дешевым товаром
        public string SearchStoreCheapestProduct(string nameProduct)
        {
            return "";
        }
        // найти товары, которые можно купить на сумму sum
        public List<Product> SearchProductOnTheSum(string nameStore, int sum)
        {
            List<Product> products = new List<Product>();
            return products;
        }
        //  Купить партию товаров 
        public int BuyConsignmentInStore(string nameStore, List<Consigment> consigment)
        {
            return 0;
        }
        // найти магазин, в которым паратия товаров самая дешевая 
        public string SearchStoreCheapestConsigment(List<Consigment> consigment)
        {
            return "";
        }
    }
}
