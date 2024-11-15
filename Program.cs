using AppStore.DAL;
using Microsoft.Extensions.Configuration;

namespace AppStore
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
            InitializationDAL.Initialization(configuration);

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
        }
    }
}