using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.BLL.Strategies
{
    internal interface IDataDisplay<C, P>
    {
        // создать магазин
        bool CreateStore(string name, string address );
        // создать продукт
        bool CreateProduct(string name);
        // завести партию товаров в магазин
        bool DeliverGoodsToTheStore(string nameStore, List<C> consigments);
        // обновить цену партии товаров в магазине
        bool UpdatePriceOfGoodsInStore(string nameStore, List<C> consigments);
        // найти магазин магазин с самым дешевым товаром
        string SearchStoreCheapestProduct(string nameProduct);
        // найти товары, которые можно купить на сумму sum
        List<P> SearchProductOnTheSum(string nameStore, int sum);
        //  Купить партию товаров 
        int BuyConsignmentInStore(string nameStore, List<C> consigment);
        // найти магазин, в которым паратия товаров самая дешевая 
        string SearchStoreCheapestConsigment(List<C> consigment);
    }
}
