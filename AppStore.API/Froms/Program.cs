using Microsoft.Extensions.Configuration;
using AppStore.API.WinForms;
using AppStore.DAL.Initialization;
using AppStore.Common;
using AppStore.API.Managers;

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
               .AddJsonFile(PathsFiles.AppSettings, optional: false, reloadOnChange: true)
               .Build();
            InitializationDAL.Initialization(configuration);

            ApplicationConfiguration.Initialize();
            Logger.Initialize();
            Application.Run(new MainForm());
        }
    }
}