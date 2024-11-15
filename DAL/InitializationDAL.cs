using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.DAL.Database;

namespace AppStore.DAL
{
    internal class InitializationDAL
    {
        public static void Initialization(IConfiguration config)
        {
            var dalType = config["DAL:Type"];
            if (dalType == "Database")
            {
                DatabaseDAL.InitializationDatabase();
            }
            else if (dalType == "File")
            {
                
            }
        }

    }
}
