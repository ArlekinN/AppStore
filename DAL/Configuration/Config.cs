using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.DAL.Configuration
{
    internal class Config
    {
        public static string TypeDal { get; private set; }
        private static Config Instanse { get; set; }
        private Config() { }
        public static Config GetInstans(string typeDal)
        {
            if (Instanse == null)
            {
                Instanse = new Config();
                Config.TypeDal = typeDal;
            }
            return Instanse;
        }
    }
}
