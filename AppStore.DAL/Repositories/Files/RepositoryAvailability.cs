using AppStore.DAL.Interfaces;
using AppStore.DAL.Models;
using CsvHelper;
using System.Globalization;
using Serilog;

namespace AppStore.DAL.Repositories.Files
{
    public class RepositoryAvailability : IRepositoryAvailability
    {
        private static RepositoryStore RepositoryStore { get; } = RepositoryStore.GetInstance();
        private static string ProductsFile { get; } = Path.Combine(AppContext.BaseDirectory, "products.csv");
        private static RepositoryAvailability Instance { get; set; }

        public static RepositoryAvailability GetInstance()
        {
            Instance ??= new RepositoryAvailability();
            return Instance;
        }

        public List<Product> GetListProducts(bool isAllProduct)
        {
            Log.Information("Files RepositoryAvailability: Get List Products");
            var lines = File.ReadAllLines(ProductsFile);
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
                    Price = Convert.ToInt32(valuesLine[3]),
                    Amount = Convert.ToInt32(valuesLine[4]),
                    
                };
                products.Add(product);
            }
            if (!isAllProduct)
            {
                products = products.Where(p => p.Amount != 0).ToList();
            }
            return products;
        }
        public List<ShowProduct> GetAllProducts(bool isAllProduct)
        {
            Log.Information("Files RepositoryAvailability: Get All Products");
            var products = GetListProducts(isAllProduct);
            var stores = RepositoryStore.GetListStores();
            var showProducts = products.Select(p => new ShowProduct
            {
                Product = p.Name,
                Store = stores.FirstOrDefault(s => s.Id == p.IdStore)?.Name,
                Price = p.Price,
                Amount = p.Amount
            }).ToList();
            return showProducts;
        }

        public bool DeliverGoodsToTheStore(int idStore, List<Consignment> consignments)
        {
            Log.Information("Files RepositoryAvailability: Deliver Goods To The Store");
            var countId = GetLastId();
            var writerStore = new StreamWriter(ProductsFile, true);
            var csvWriterStore = new CsvWriter(writerStore, CultureInfo.CurrentCulture);
            foreach (var consignment in consignments)
            {
                var product = new Product(countId, consignment.Product, idStore, consignment.Price, consignment.Amount);
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
            Log.Information("Files RepositoryAvailability: Get Last Id");
            var lines = File.ReadAllLines(ProductsFile);
            var lastLine = lines[lines.Length - 1];
            var valuesLine = lastLine.Split(';');
            var firstValue = Convert.ToInt32(valuesLine[0]) + 1;
            return firstValue;
        }
        public List<string> SearchStoreCheapestProduct(string nameProduct)
        {
            Log.Information("Files RepositoryAvailability: Search Store Cheapest Product");
            var products = GetAllProducts(false);
            var productsFilterProduct = products.Where(product => product.Product.Equals(nameProduct)).ToList();
            var cheapestProduct = productsFilterProduct.OrderBy(product => product.Price).FirstOrDefault();
            return [cheapestProduct.Store, cheapestProduct.Price.ToString()];
        }

        public List<ProductAmount> SearchProductOnTheSum(string nameStore, int sum)
        {
            Log.Information("Files RepositoryAvailability: Search Product On The Sum");
            var products = GetAllProducts(false);
            products = products.Where(product => product.Store.Equals(nameStore)).ToList();
            var result = new List<ProductAmount>();
            var amountProduct = int.MinValue;
            foreach (var product in products) 
            {
                amountProduct = sum / product.Price;
                if (amountProduct > 0)
                {
                    if(amountProduct > product.Amount)
                    {
                        amountProduct = product.Amount;
                    }
                    var productAmount = new ProductAmount { Product = product.Product, Amount = amountProduct };
                    result.Add(productAmount);
                }
            }
            return result;
        }
        public int BuyConsignmentInStore(string nameStore, List<Consignment> consignments, bool isChange)
        {
            Log.Information("Files RepositoryAvailability: Buy Consignment In Store");
            var products = GetListProducts(false);
            products = products.Where(product => RepositoryStore.GetStoreById(product.IdStore).Equals(nameStore)).ToList();
            var totalPrice = 0;
            var currentAmountConsignment = 0; // текущее количество товара данной поставки, которое надо найти
            var newAmount = int.MinValue;
            var commonAmount = 0;// сколько такого товара есть в магазине
            var isExistProduct = true;
            // проверка, что такие товары вообще есть в магазине  в нужном количестве
            foreach(var consignment in consignments)
            {
                currentAmountConsignment = consignment.Amount;
                commonAmount = 0;
                foreach (var product in products)
                {

                    if (commonAmount >= currentAmountConsignment)
                    {
                        break;
                    }
                    if (consignment.Product == product.Name)
                    {
                        commonAmount += product.Amount;
                    }
                }
            }
            if (commonAmount < currentAmountConsignment)
            {
                isExistProduct = false;
            }
            else
            {
                foreach (var consignment in consignments)
                {
                    currentAmountConsignment = consignment.Amount;
                    foreach (var product in products)
                    {
                        // если необходимо количество товара найдено
                        if (currentAmountConsignment == 0)
                        {
                            break;
                        }
                        if (consignment.Product == product.Name)
                        {
                            // если в данной поставке товара больше чем необходимо
                            if (product.Amount > currentAmountConsignment)
                            {
                                totalPrice += currentAmountConsignment * product.Price;
                                newAmount = product.Amount - currentAmountConsignment;
                                if (isChange) UpdateDataFile(product.Id, newAmount);
                                currentAmountConsignment = 0;
                                break;
                            }
                            else // если в поставке товара меньше
                            {
                                totalPrice += product.Amount * product.Price;
                                currentAmountConsignment -= product.Amount;
                                if(isChange) UpdateDataFile(product.Id, 0);
                            }
                        }
                    }
                }
            }
            if (isExistProduct) return totalPrice;
            else return 0;

        }

        private void UpdateDataFile(int idProduct, int newAmount) 
        {
            Log.Information("Files RepositoryAvailability: Update Data File");
            var lines = File.ReadAllLines(ProductsFile).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith(idProduct.ToString()))
                {
                    var objLine = ConvertToProduct(lines[i]);
                    objLine.Amount = newAmount;
                    lines[i] = $"{objLine.Id};{objLine.Name};{objLine.IdStore};{objLine.Price};{objLine.Amount}";
                    break;
                }
            }
            File.WriteAllLines(ProductsFile, lines);
        }

        private Product ConvertToProduct(string lineProduct)
        {
            Log.Information("Files RepositoryAvailability: Convert To Product");
            var values = lineProduct.Split(';');
            return new Product
            {
                Id = Convert.ToInt32(values[0]),
                Name = values[1],
                IdStore = Convert.ToInt32(values[2]),
                Price = Convert.ToInt32(values[3]),
                Amount = Convert.ToInt32(values[4])
            };
        }
    }
}
