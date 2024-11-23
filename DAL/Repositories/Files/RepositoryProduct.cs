using AppStore.DAL.Interfaces;
using AppStore.Models.Files;
using CsvHelper;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.DAL.Repositories.Files
{
    internal class RepositoryProduct : IRepositoryProduct
    {
        private static RepositoryProduct Instance { get; set; }

        private readonly string _connectionString = $"Data Source={Path.Combine(AppContext.BaseDirectory, "StoreDB.db")}";
        private static RepositoryAvailability _repositoryAvailability = RepositoryAvailability.GetInstance();
        private static string productsFile = Path.Combine(AppContext.BaseDirectory, "products.csv");
        public static RepositoryProduct GetInstance()
        {
            if (Instance == null)
            {
                Instance = new RepositoryProduct();
            }
            return Instance;
        }
        
        private RepositoryProduct() 
        {
            FileInfo fileProduct = new FileInfo(productsFile);
        }
        public new bool CreateProduct(string nameProduct)
        {
            var product = new Product(GetLastId(), nameProduct, 0, 0, 0);
            using var writerStore = new StreamWriter(productsFile, true);
            using var csvWriterStore = new CsvWriter(writerStore, CultureInfo.CurrentCulture);
            csvWriterStore.WriteField(product.Id);
            csvWriterStore.WriteField(product.Name);
            csvWriterStore.WriteField(product.IdStore);
            csvWriterStore.WriteField(product.Price);
            csvWriterStore.WriteField(product.Amount);
            csvWriterStore.NextRecord();
            return true;

        }
        public int GetLastId()
        {
            string[] lines = File.ReadAllLines(productsFile);
            string lastLine = lines[lines.Length - 1];
            string[] valuesLine = lastLine.Split(';');
            int firstValue = Convert.ToInt32(valuesLine[0]) + 1;
            return firstValue;
        }

        public new async Task<int> GetProductByName(string product)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@$"
                select Id from Product where Name=@product", connection);
            command.Parameters.AddWithValue("@product", product);
            int idProduct = 0;
            using (var reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    idProduct = Convert.ToInt32(reader.GetValue(0));
                }
            }
            return idProduct;
        }

        public new List<string> ShowUniqProducts()
        {
            var products = _repositoryAvailability.GetListProducts();
            var uniqProduct = products.Select(product => product.Name).Distinct().ToList();
            return uniqProduct;
        }
    }
}
