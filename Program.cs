using Microsoft.Extensions.Configuration;

using AppStore.WinForms;
using System.Diagnostics;
using AppStore.DAL.Initialization;
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
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();
            InitializationDAL.Initialization(configuration);

            ApplicationConfiguration.Initialize();

            Application.Run(new MainForm());
        }
    }
}