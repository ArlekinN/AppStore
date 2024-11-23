using AppStore.DAL.Interfaces;
using AppStore.Models;
using AppStore.Models.Files;
using CsvHelper;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.DAL.Repositories.Files
{
    internal class RepositoryAvailability : IRepositoryAvailability
    {
        private static RepositoryStore _repositoryStore = RepositoryStore.GetInstance();
        private static string productsFile = Path.Combine(AppContext.BaseDirectory, "products.csv");
        private static RepositoryAvailability Instance { get; set; }
        private RepositoryAvailability() 
        {
            FileInfo fileProduct = new FileInfo(productsFile);
        }
        public static RepositoryAvailability GetInstance()
        {
            if (Instance == null)
            {
                Instance = new RepositoryAvailability();
            }
            return Instance;
        }

        public List<Product> GetListProducts()
        {
            string[] lines = File.ReadAllLines(productsFile);
            string[] valuesLine;
            var products = new List<Product>();
            foreach (var line in lines)
            {
                valuesLine = line.Split(';');
                var product = new Product
                {
                    Id = Convert.ToInt32(valuesLine[0]),
                    Name = valuesLine[1],
                    IdStore = Convert.ToInt32(valuesLine[2]),
                    Amount = Convert.ToInt32(valuesLine[3]),
                    Price = Convert.ToInt32(valuesLine[4]),
                };
                products.Add(product);

            }
            return products;
        }
        public new List<ShowProduct> GetAllProducts()
        {
            var products = GetListProducts();
            var stores = _repositoryStore.GetListStores();
            var showProducts = products.Select(p => new ShowProduct
            {
                Product = p.Name,
                Store = stores.FirstOrDefault(s => s.Id == p.IdStore)?.Name,
                Price = p.Price,
                Amount = p.Amount
            }).ToList();

            return showProducts;
        }

        public new bool DeliverGoodsToTheStore(int idStore, List<Consigment> consigments)
        {
            int countId = GetLastId();
            using var writerStore = new StreamWriter(productsFile, true);
            using var csvWriterStore = new CsvWriter(writerStore, CultureInfo.CurrentCulture);
            foreach (var consigment in consigments)
            {
                var product = new Product(countId, consigment.Product, idStore, consigment.Price, consigment.Amount);
                csvWriterStore.WriteField(product.Id);
                csvWriterStore.WriteField(product.Name);
                csvWriterStore.WriteField(product.IdStore);
                csvWriterStore.WriteField(product.Price);
                csvWriterStore.WriteField(product.Amount);
                csvWriterStore.NextRecord();
                countId++;
            }
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
        public new List<string> SearchStoreCheapestProduct(int idProduct)
        {
            
            return new List<string>();
        }

        public new List<ProductAmount> SearchProductOnTheSum(int idStore, int sum)
        {
            
            return new List<ProductAmount>();
        }
        public new int BuyConsignmentInStore(int idStore, List<Consigment> consigments)
        {
            return 0;

        }
    }
}
