using AppStore.DAL.Models;

namespace AppStore.BLL.Strategies
{
    internal interface IDataDisplay
    {
        // все продукты
        List<ShowProduct> ShowAllProducts();

        // все магазины
        List<string> ShowAllStores();

        // список продуктов
        List<string> ShowUniqueProducts();

        // создать магазин
        bool CreateStore(string name, string address);
        
        // создать продукт
        bool CreateProduct(string name);
        
        // завести партию товаров в магазин
        bool DeliverGoodsToTheStore(string nameStore, List<Consignment> consignments);

        // найти магазин магазин с самым дешевым товаром
        List<string> SearchStoreCheapestProduct(string nameProduct);
        
        // найти товары, которые можно купить на сумму sum
        List<ProductAmount> SearchProductOnTheSum(string nameStore, int sum);
        
        //  Купить партию товаров 
        int BuyConsignmentInStore(string nameStore, List<Consignment> consignment);
        
        // найти магазин, в которым партия товаров самая дешевая 
        string SearchStoreCheapestConsignment(List<Consignment> consignment);
    }
}
