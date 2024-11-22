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
    internal class StoreService
    {
        private IDataDisplay DataDisplay { get; set; }
        public StoreService()
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
        public bool CreateStore(string name, string address)
        {
            return DataDisplay.CreateStore(name, address);
        }
        public List<string> AllStores()
        {
            return DataDisplay.ShowAllStores();
        }
    }
}
