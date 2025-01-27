using AppStore.DAL.Interfaces;
using AppStore.DAL.Models;
using CsvHelper;
using System.Globalization;
using Serilog;

namespace AppStore.DAL.Repositories.Files
{
    public class RepositoryStore : IRepositoryStore
    {
        private static RepositoryStore Instance { get; set; }
        private static string StoresFile { get; } = Path.Combine(AppContext.BaseDirectory, "stores.csv");

        public static RepositoryStore GetInstance()
        {
            Instance ??= new RepositoryStore();
            return Instance;
        }

        public bool CreateStore(string nameStore, string address)
        {
            Log.Information("Files RepositoryStore: Create Store");
            var store = new Store(GetLastId(), nameStore, address);
            var writerStore = new StreamWriter(StoresFile, true);
            var csvWriterStore = new CsvWriter(writerStore, CultureInfo.CurrentCulture);
            csvWriterStore.WriteField(store.Id);
            csvWriterStore.WriteField(store.Name);
            csvWriterStore.WriteField(store.Address);
            csvWriterStore.NextRecord();
            return true;
        }

        public int GetLastId()
        {
            Log.Information("Files RepositoryStore: Get Last Id");
            var lines = File.ReadAllLines(StoresFile);
            var lastLine = lines[lines.Length - 1];
            var valuesLine = lastLine.Split(';');
            var firstValue = Convert.ToInt32(valuesLine[0]) + 1;
            return firstValue;
        }

        public int GetStoreByName(string storeName)
        {
            Log.Information("Files RepositoryStore: Get Store By Name");
            var stores = GetListStores();
            var idStore = stores
                .Where(store => store.Name.Equals(storeName))
                .Select(store => store.Id)
                .FirstOrDefault();
            return idStore;
        }

        public List<string> ShowAllStores()
        {
            Log.Information("Files RepositoryStore: Show All Stores");
            var stores = GetListStores();
            var namesStores = stores.Select(store => store.Name).ToList();
            return namesStores;
        }

        public string GetStoreById(int idStore)
        {
            Log.Information("Files RepositoryStore: Get Store By Id");
            var stores = GetListStores();
            var storeName = stores
                .Where(store => store.Id == idStore)
                .Select(store => store.Name)
                .FirstOrDefault();
            return storeName;
        }

        public List<Store> GetListStores()
        {
            Log.Information("Files RepositoryStore: Get List Stores");
            var lines = File.ReadAllLines(StoresFile);
            string[] valuesLine;
            var stores = new List<Store>();
            foreach (var line in lines)
            {
                valuesLine = line.Split(';');
                var store = new Store
                {
                    Id = Convert.ToInt32(valuesLine[0]),
                    Name = valuesLine[1].ToString()
                };
                stores.Add(store);
            }
            return stores;
        }
    }
}
