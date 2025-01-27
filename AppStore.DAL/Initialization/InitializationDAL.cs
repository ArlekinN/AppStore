using Microsoft.Extensions.Configuration;
using AppStore.DAL.Initialization.Files;
using AppStore.DAL.Initialization.Database;
using AppStore.DAL.Configuration;

namespace AppStore.DAL.Initialization
{
    public class InitializationDAL
    {
        public static void Initialization(IConfiguration config)
        {
            var dalType = config["DAL_Type"];
            if (dalType == "Database")
            {
                DatabaseDAL.InitializationDatabase();
                Config.GetInstance(dalType);
            }
            else if (dalType == "File")
            {
                FileDAL.InitializationFile();
                Config.GetInstance(dalType);
            }
        }
    }
}
