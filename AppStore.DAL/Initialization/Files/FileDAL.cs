using AppStore.DAL.Models;
using CsvHelper;
using System.Globalization;

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
                new Store(1, "NewBody", "Millionnaya 30"),
                new Store(2, "Donor.Net", "Rosa 6"),
                new Store(3, "ThreeFingers", "Red 18"),
            };
            var products = new List<Product>
            {
                new Product(1, "Brain", 1, 400, 4),
                new Product(2, "Hand", 1, 250, 20),
                new Product(3, "Stomach", 1, 380, 7),
                new Product(4, "Brain", 2, 650, 8),
                new Product(5, "Heart", 2, 800, 3),
                new Product(6, "Finger", 2, 150, 25),
                new Product(7, "Stomach", 2, 350, 18),
                new Product(8, "Stomach", 3, 410, 12),
                new Product(9, "Heart", 3, 910, 7),
                new Product(10, "Brain", 3, 510, 9),
                new Product(11, "Finger", 3, 170, 22),
                new Product(12, "Hand", 3, 260, 11)
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
