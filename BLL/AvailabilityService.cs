using AppStore.BLL.Strategies;
using AppStore.DAL.Configuration;
using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.BLL
{
    internal class AvailabilityService
    {
        private IDataDisplay DataDisplay { get; set; }
        public AvailabilityService()
        {
            if (Config.TypeDal == "Database")
            {
                DataDisplay = new DataDisplayDatabase();
            }
            else
            {
                DataDisplay = new DataDisplayFiles();
            }
        }
        public List<ShowProduct> ShowAllProducts()
        {
            return DataDisplay.ShowAllProducts();
        }
        public bool DeliverGoodsToTheStore(string nameStore, List<Consigment> consigments)
        {
            return DataDisplay.DeliverGoodsToTheStore(nameStore, consigments);
        }
        public bool UpdatePriceOfGoodsInStore(string nameStore, List<Consigment> consigments)
        {
            return DataDisplay.UpdatePriceOfGoodsInStore(nameStore, consigments);
        }
        public List<dynamic> SearchProductOnTheSum(string nameStore, int sum)
        {
            return DataDisplay.SearchProductOnTheSum(nameStore, sum);
        }
        public int BuyConsignmentInStore(string nameStore, List<Consigment> consigment)
        {
            return DataDisplay.BuyConsignmentInStore(nameStore, consigment);
        }
        public List<string> SearchStoreCheapestProduct(string nameProduct)
        {
            return DataDisplay.SearchStoreCheapestProduct(nameProduct);
        }
        public string SearchStoreCheapestConsigment(List<Consigment> consigment)
        {
            return DataDisplay.SearchStoreCheapestConsigment(consigment);
        }




    }
}
