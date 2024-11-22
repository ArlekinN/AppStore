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
        private static Config Instance;
        private Config() { }
        public static Config GetInstance(string typeDal)
        {
            if (Instance == null)
            {
                Instance = new Config();
                Config.TypeDal = typeDal;
            }
            return Instance;
        }
    }
}
