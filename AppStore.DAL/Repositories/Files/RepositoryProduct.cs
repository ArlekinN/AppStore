using AppStore.DAL.Interfaces;
using AppStore.DAL.Models;
using CsvHelper;
using System.Globalization;
using Serilog;

namespace AppStore.DAL.Repositories.Files
{
    public class RepositoryProduct : IRepositoryProduct
    {
        private static RepositoryProduct Instance { get; set; }

        private static RepositoryAvailability RepositoryAvailability { get; } = RepositoryAvailability.GetInstance();
        private static string ProductsFile { get; } = Path.Combine(AppContext.BaseDirectory, "products.csv");
        public static RepositoryProduct GetInstance()
        {
            Instance ??= new RepositoryProduct();
            return Instance;
        }
   
        public bool CreateProduct(string nameProduct)
        {
            Log.Information("Files RepositoryProduct: Create Product");
            var product = new Product(GetLastId(), nameProduct, 0, 0, 0);
            var writerStore = new StreamWriter(ProductsFile, true);
            var csvWriterStore = new CsvWriter(writerStore, CultureInfo.CurrentCulture);
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
            Log.Information("Files RepositoryProduct: Get Last Id");
            var lines = File.ReadAllLines(ProductsFile);
            var lastLine = lines[lines.Length - 1];
            var valuesLine = lastLine.Split(';');
            var firstValue = Convert.ToInt32(valuesLine[0]) + 1;
            return firstValue;
        }

        public List<string> ShowUniqueProducts()
        {
            Log.Information("Files RepositoryProduct: Show Unique Products");
            var products = RepositoryAvailability.GetListProducts(true);
            var uniqueProduct = products.Select(product => product.Name).Distinct().ToList();
            return uniqueProduct;
        }
    }
}
