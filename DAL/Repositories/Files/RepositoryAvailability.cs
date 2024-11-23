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

        public List<Product> GetListProducts(bool isAllProduct)
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
        public new List<ShowProduct> GetAllProducts(bool isAllProduct)
        {
            var products = GetListProducts(isAllProduct);
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
        public new List<string> SearchStoreCheapestProduct(string nameProduct)
        {
            var products = GetAllProducts(false);
            var productsFilterProduct = products.Where(product => product.Product.Equals(nameProduct)).ToList();
            var cheapestProduct = productsFilterProduct.OrderBy(product => product.Price).FirstOrDefault();
            return new List<string>() { cheapestProduct.Store, cheapestProduct.Price.ToString() };
        }

        public new List<ProductAmount> SearchProductOnTheSum(string nameStore, int sum)
        {
            var products = GetAllProducts(false);
            products = products.Where(product => product.Store.Equals(nameStore)).ToList();
            var result = new List<ProductAmount>();
            int amountProduct;
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
        public new int BuyConsignmentInStore(string nameStore, List<Consigment> consigments, bool isChange)
        {
            var products = GetListProducts(false);
            products = products.Where(product => _repositoryStore.GetStoreById(product.IdStore).Equals(nameStore)).ToList();
            int totalPrice = 0, currentAmountConsigment = 0; // текущее количество товара данной поставки, которое надо найти
            int newAmount;
            int commonAmount = 0;// сколько такого товара есть в магазине
            bool isExistProduct = true;
            // проверка, что такие товары вообще есть в магазине  в нужном количестве
            foreach(var consigment in consigments)
            {
                currentAmountConsigment = consigment.Amount;
                commonAmount = 0;
                foreach (var product in products)
                {

                    if (commonAmount >= currentAmountConsigment)
                    {
                        break;
                    }
                    if (consigment.Product == product.Name)
                    {
                        commonAmount += product.Amount;
                    }
                }
            }
            if (commonAmount < currentAmountConsigment)
            {
                isExistProduct = false;
            }
            else
            {
                foreach (var consigment in consigments)
                {
                    currentAmountConsigment = consigment.Amount;
                    foreach (var product in products)
                    {
                        // если необходимо количество товара найдено
                        if (currentAmountConsigment == 0)
                        {
                            break;
                        }
                        if (consigment.Product == product.Name)
                        {
                            // если в данной поставке товара больше чем необходимо
                            if (product.Amount > currentAmountConsigment)
                            {
                                totalPrice += currentAmountConsigment * product.Price;
                                newAmount = product.Amount - currentAmountConsigment;
                                if (isChange) UpdateDataFile(product.Id, newAmount);
                                currentAmountConsigment = 0;
                                break;
                            }
                            else // если в поставке товара меньше
                            {
                                totalPrice += product.Amount * product.Price;
                                currentAmountConsigment -= product.Amount;
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
            var lines = File.ReadAllLines(productsFile).ToList();
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
            File.WriteAllLines(productsFile, lines);
        }

        private Product ConvertToProduct(string lineProduct)
        {
            string[] values = lineProduct.Split(';');
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
