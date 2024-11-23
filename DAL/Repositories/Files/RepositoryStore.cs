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
        public static int GetLastId()
        {
            string[] lines = File.ReadAllLines(storesFile);
            string lastLine = lines[lines.Length - 1];
            string[] valuesLine = lastLine.Split(';');
            int firstValue = Convert.ToInt32(valuesLine[0]) + 1;
            return firstValue;
        }
        public int GetStoreByName(string store)
        {
            return 0;
        }

        public new List<string> ShowAllStores()
        {
            string[] lines = File.ReadAllLines(storesFile);
            string[] valuesLine;
            var stores = new List<string>();
            foreach (var line in lines)
            {
                valuesLine = line.Split(';');
                stores.Add(valuesLine[2]);
            }
            return stores;
        }

        public new async Task<string> GetStoreById(int idStore)
        {
            Batteries.Init();
            using var connection = new SqliteConnection("_connectionString");
            await connection.OpenAsync();
            using var command = new SqliteCommand("select Name from Store where Id=@idStore", connection);
            command.Parameters.AddWithValue("@idStore", idStore);
            string store = "";
            using (var reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    store = reader["Name"].ToString();
                }
            }
            return store;
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
