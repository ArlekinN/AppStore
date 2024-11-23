using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.DAL.Interfaces
{
    internal abstract class IRepositoryAvailability
    {
        public List<ShowProduct> GetAllProducts() { return new List<ShowProduct>(); }

        public bool DeliverGoodsToTheStore() { return true; }
        public List<string> SearchStoreCheapestProduct() { return new List<string>(); }

        public List<ProductAmount> SearchProductOnTheSum(int idStore, int sum) { return new List<ProductAmount>(); }
        public int BuyConsignmentInStore(int idStore, List<Consigment> consigments) { return 0; }
    }
}
