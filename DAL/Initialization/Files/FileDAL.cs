using AppStore.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Models.Files;

namespace AppStore.DAL.Initialization.Files
{
    internal static class FileDAL
    {
        private static string storesFile = Path.Combine(AppContext.BaseDirectory, "stores.csv");
        private static string productsFile = Path.Combine(AppContext.BaseDirectory, "products.csv");
        public static void InitializationFile()
        {
            FileInfo fileStore = new FileInfo(storesFile);
            FileInfo fileProduct = new FileInfo(productsFile);
            if (!(fileProduct.Exists && fileStore.Exists))
            {
                using (fileStore.Create()) { }
                using (fileProduct.Create()) { }
                Seed();
            }
        }
        private static void Seed()
        {
            var stores = new List<Store>
            {
                new Store(1, "KateStore", "Millionnaya 30"),
                new Store(2, "Goh", "Rosa 6"),
                new Store(3, "FiveOne", "Red 18"),
            };
            var products = new List<Product>
            {
                new Product(1, "Milk", 1, 115, 30),
                new Product(2, "Oil", 1, 110, 40),
                new Product(3, "Jogurt", 1, 56, 112),
                new Product(4, "Milk", 2, 120, 40),
                new Product(5, "Bread", 2, 32, 210),
                new Product(6, "Eggs", 2, 12, 400),
                new Product(7, "Jogurt", 2, 70, 30),
                new Product(8, "Jogurt", 3, 67, 80),
                new Product(9, "Bread", 3, 30, 90),
                new Product(10, "Milk", 3, 90, 50),
                new Product(11, "Eggs", 3, 9, 300),
                new Product(12, "Oil", 3, 135, 70)
            };
            // запись магазинов
            using var writerStore = new StreamWriter(storesFile, true);
            using var csvWriterStore = new CsvWriter(writerStore, CultureInfo.CurrentCulture);

            foreach (var store in stores)
            {
                csvWriterStore.WriteField(store.Id);
                csvWriterStore.WriteField(store.Name);
                csvWriterStore.WriteField(store.Address);
                csvWriterStore.NextRecord();
            }
            // запись продуктов
            using var writerProduct = new StreamWriter(productsFile, true);
            using var csvWriterProduct = new CsvWriter(writerProduct, CultureInfo.CurrentCulture);
            foreach (var product in products)
            {
                csvWriterProduct.WriteField(product.Id);
                csvWriterProduct.WriteField(product.Name);
                csvWriterProduct.WriteField(product.IdStore);
                csvWriterProduct.WriteField(product.Price);
                csvWriterProduct.WriteField(product.Amount);
                csvWriterProduct.NextRecord();
            }

        }
    }

}
