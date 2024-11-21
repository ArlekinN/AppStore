using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using AppStore.DAL.Initialization.Files;
using AppStore.DAL.Initialization.Database;
using AppStore.DAL.Configuration;

namespace AppStore.DAL.Initialization
{
    internal class InitializationDAL
    {
        public static void Initialization(IConfiguration config)
        {
            var dalType = config["DAL:Type"];
            if (dalType == "Database")
            {
                DatabaseDAL.InitializationDatabase();
                Config.GetInstans(dalType);
            }
            else if (dalType == "File")
            {
                FileDAL.InitializationFile();
                Config.GetInstans(dalType);
            }
        }

    }
}
