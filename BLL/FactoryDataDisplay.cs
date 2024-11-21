using AppStore.BLL.Strategies;
using AppStore.DAL.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.BLL
{
    internal class FactoryDataDisplay<Consigment, Product>
    {
        public static IDataDisplay<Consigment, Product> CreateDataDisplay()
        {
            if (Config.TypeDal == "Database")
            {
                return (IDataDisplay<Consigment, Product>)new DataDisplayDatabase();
            }
            else
            {
                return (IDataDisplay<Consigment, Product>)new DataDisplayFiles();
            }
        }
    }
}
