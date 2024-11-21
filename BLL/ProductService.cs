using AppStore.BLL.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.BLL
{
    internal class ProductService<Consigment, Product>
    {
        private IDataDisplay<Consigment, Product> DataDisplay { get; set; }
        public ProductService()
        {
            DataDisplay = FactoryDataDisplay<Consigment, Product>.CreateDataDisplay();
        }
        public bool CreateProduct(string name)
        {
            return DataDisplay.CreateProduct(name);
        }
    }
}
