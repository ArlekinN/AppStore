using AppStore.BLL.Strategies;
using AppStore.DAL.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.BLL
{
    internal class ProductService
    {
        private IDataDisplay DataDisplay { get; set; }
        public ProductService()
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
        public bool CreateProduct(string name)
        {
            return DataDisplay.CreateProduct(name);
        }
    }
}
