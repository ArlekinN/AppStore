using AppStore.DAL.Interfaces;
using AppStore.Models;
using CsvHelper;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace AppStore.DAL.Repositories.Files
{
    internal class RepositoryStore : IRepositoryStore
    {
        private static RepositoryStore Instance { get; set; }
        private static string storesFile = Path.Combine(AppContext.BaseDirectory, "stores.csv");
        


        private RepositoryStore() 
        {
            FileInfo fileStore = new FileInfo(storesFile);
        }
        public static RepositoryStore GetInstance()
        {
            if (Instance == null)
            {
                Instance = new RepositoryStore();
            }
            return Instance;
        }
        public new bool CreateStore(string nameStore, string address)
        {
            var store = new Store(GetLastId(), nameStore, address);
            using var writerStore = new StreamWriter(storesFile, true);
            using var csvWriterStore = new CsvWriter(writerStore, CultureInfo.CurrentCulture);
            csvWriterStore.WriteField(store.Id);
            csvWriterStore.WriteField(store.Name);
            csvWriterStore.WriteField(store.Address);
            csvWriterStore.NextRecord();
            return true;
        }
        public int GetLastId()
        {
            string[] lines = File.ReadAllLines(storesFile);
            string lastLine = lines[lines.Length - 1];
            string[] valuesLine = lastLine.Split(';');
            int firstValue = Convert.ToInt32(valuesLine[0]) + 1;
            return firstValue;
        }
        public int GetStoreByName(string storeName)
        {
            var stores = GetListStores();
            int idStore = stores
                .Where(store => store.Name.Equals(storeName))
                .Select(store => store.Id)
                .FirstOrDefault();
            return idStore;
        }

        public new List<string> ShowAllStores()
        {
            var stores = GetListStores();
            var namesStores = stores.Select(store => store.Name).ToList();
            return namesStores;
        }

        public new string GetStoreById(int idStore)
        {
            var stores = GetListStores();
            string storeName = stores
                .Where(store => store.Id == idStore)
                .Select(store => store.Name)
                .FirstOrDefault();
            return storeName;
        }

        public List<Store> GetListStores()
        {
            string[] lines = File.ReadAllLines(storesFile);
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
