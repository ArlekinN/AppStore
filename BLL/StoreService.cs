using AppStore.BLL.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.BLL
{
    internal class StoreService<Consigment, Product>
    {
        private IDataDisplay<Consigment, Product> DataDisplay { get; set; }
        public StoreService()
        {
            DataDisplay = FactoryDataDisplay<Consigment, Product>.CreateDataDisplay();
        }
        public bool CreateStore(string name, string address)
        {
            return DataDisplay.CreateStore(name, address);
        }
    }
}
