using AppStore.BLL.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.BLL
{
    internal class AvailabilityService<Consigment, Product> 
    {
        private IDataDisplay<Consigment, Product> DataDisplay { get; set; }
        public AvailabilityService()
        {
            DataDisplay = FactoryDataDisplay<Consigment, Product>.CreateDataDisplay();
        }
        public bool DeliverGoodsToTheStore(string nameStore, List<Consigment> consigments)
        {
            return DataDisplay.DeliverGoodsToTheStore(nameStore, consigments);
        }
        public bool UpdatePriceOfGoodsInStore(string nameStore, List<Consigment> consigments)
        {
            return DataDisplay.UpdatePriceOfGoodsInStore(nameStore, consigments);
        }
        public List<Product> SearchProductOnTheSum(string nameStore, int sum)
        {
            return DataDisplay.SearchProductOnTheSum(nameStore, sum);
        }
        public int BuyConsignmentInStore(string nameStore, List<Consigment> consigment)
        {
            return DataDisplay.BuyConsignmentInStore(nameStore, consigment);
        }
        public string SearchStoreCheapestProduct(string nameProduct)
        {
            return DataDisplay.SearchStoreCheapestProduct(nameProduct);
        }
        public string SearchStoreCheapestConsigment(List<Consigment> consigment)
        {
            return DataDisplay.SearchStoreCheapestConsigment(consigment);
        }



    }
}
