using AppStore.DAL.Interfaces;
using AppStore.Models;
using AppStore.Models.Database;
using AppStore.Models.Files;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.DAL.Repositories.Database
{
    internal class RepositoryAvailability: IRepositoryAvailability
    {
        private static RepositoryStore _repositoryStore = RepositoryStore.GetInstance();
        private static RepositoryProduct _repositoryProduct = RepositoryProduct.GetInstance();
        private static RepositoryAvailability Instance { get; set; }

        private readonly string _connectionString = $"Data Source={Path.Combine(AppContext.BaseDirectory, "StoreDB.db")}";
        private RepositoryAvailability() { }
        public static RepositoryAvailability GetInstance()
        {
            if(Instance == null)
            {
                Instance = new RepositoryAvailability();
            }
            return Instance;
        }
        public new async Task<List<ShowProduct>> GetAllProducts()
        {
            var products = new List<ShowProduct>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"select s.Name as Store, p.Name as Product, Price, Amount from AVAILABILITY as a
                join STORE as s on s.Id=a.IdStore
                join PRODUCT as p on p.Id=IdProduct";

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    var product = new ShowProduct
                    {
                        Product = reader["Product"].ToString(),
                        Store = reader["Store"].ToString(),
                        Price = Convert.ToInt32(reader["Price"]),
                        Amount = Convert.ToInt32(reader["Amount"])
                    };
                    products.Add(product);
                }
            }
            
            return products;
        }

        public new async Task<bool> DeliverGoodsToTheStore(int idStore, List<Consigment> consigments)
        {
            var products = new List<ShowProduct>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            int idProduct;
            foreach (Consigment consigment in consigments)
            {

                idProduct = await _repositoryProduct.GetProductByName(consigment.Product);
                using var command = new SqliteCommand(@"
                INSERT INTO Availability(idStore, idProduct, Price, Amount)
                VALUES(@idStore, @idProduct, @Price, @Amount)", connection);
                command.Parameters.AddWithValue("@idStore", idStore);
                command.Parameters.AddWithValue("@idProduct", idProduct);
                command.Parameters.AddWithValue("@Price", consigment.Price);
                command.Parameters.AddWithValue("@Amount", consigment.Amount);
                await command.ExecuteNonQueryAsync();
            }
            return true;
        }
        public new async Task<List<string>> SearchStoreCheapestProduct(int idProduct)
        {
            Batteries.Init();
            var result = new List<string>();
            int idStore; 
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand( @"select IdStore, min(price) as price from AVAILABILITY WHERE
                idProduct = @idProduct", connection);
            command.Parameters.AddWithValue("@idProduct", idProduct);
            using (var reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    idStore = Convert.ToInt32(reader["idStore"]);
                    result.Add(_repositoryStore.GetStoreById(idStore).Result);
                    result.Add(reader["price"].ToString());
                }
            }
            return result;
        }

        private int AmountProduct(int price, int amountCommon, int sum)
        {
            int amount = sum/price;
            if (amount > amountCommon) return amountCommon;
            else return amount;
            
        }
        public new async Task<List<ProductAmount>> SearchProductOnTheSum(int idStore, int sum)
        {
            var products = new List<ProductAmount>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                    select p.Name as Product, Price, Amount from AVAILABILITY as a
                    JOIN PRODUCT as p on p.Id=a.IdProduct
                    where IdStore =  @idStore", connection);
            command.Parameters.AddWithValue("@idStore", idStore);
            int price, amountCommon, amount;
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    price = Convert.ToInt32(reader["Price"]);
                    amountCommon = Convert.ToInt32(reader["Amount"]);
                    amount = AmountProduct(price, amountCommon, sum);
                    if(amount > 0)
                    {
                        var productAmount = new ProductAmount
                        {
                            Product = reader["Product"].ToString(),
                            Amount = amount
                        };
                        products.Add(productAmount);
                    }
                }
            }
            return products;
        }
        public new async Task<int> BuyConsignmentInStore(int idStore, List<Consigment> consigments, bool isChange)
        {
            int totalPrice = 0;
            bool isExistProduct = true;
            var consigmentsDB = new List<Consigment>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                    select a.Id, p.Name as Product, Price, Amount from AVAILABILITY as a
                    JOIN PRODUCT as p on p.Id=a.IdProduct
                    where IdStore =  @idStore", connection);
            command.Parameters.AddWithValue("@idStore", idStore);
            // получение всех поставок с данного магазина
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    var consigment = new Consigment
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Product = reader["Product"].ToString(),
                        Price = Convert.ToInt32(reader["Price"]),
                        Amount = Convert.ToInt32(reader["Amount"])
                    };
                    consigmentsDB.Add(consigment);
                }
            }
            // текущее количество товара данной поставки, которое надо найти
            int currentAmountConsigment = 0;
            int newAmount, commonAmount=0; // сколько такого товара есть в магазине
            // проверка на то, что в магазине есть нужное количество товаров
            foreach (var consigment in consigments)
            {
                currentAmountConsigment = consigment.Amount;
                commonAmount = 0;
                foreach (var consigmentDB in consigmentsDB)
                {

                    if (commonAmount >= currentAmountConsigment)
                    {
                        break;
                    }
                    if (consigment.Product == consigmentDB.Product)
                    {
                        commonAmount += consigmentDB.Amount;
                    }
                }
            }
            if (commonAmount < currentAmountConsigment)
            {
                isExistProduct = false;
            }
            else {
                foreach (var consigment in consigments)
                {
                    currentAmountConsigment = consigment.Amount;

                    foreach (var consigmentDB in consigmentsDB)
                    {
                        // если необходимо количество товара найдено
                        if (currentAmountConsigment == 0)
                        {
                            break;
                        }
                        // в поставке найден нужный товар
                        if (consigment.Product == consigmentDB.Product)
                        {
                            // если в данной поставке товара больше чем необходимо
                            if (consigmentDB.Amount > currentAmountConsigment)
                            {
                                totalPrice += currentAmountConsigment * consigmentDB.Price;
                                newAmount = consigmentDB.Amount - currentAmountConsigment;
                                // обновление данных о поставке
                                if(isChange)UpdateConsigment(consigmentDB.Id, newAmount);
                                currentAmountConsigment = 0;
                                break;
                            }
                            else // если в поставке товара меньше
                            {
                                totalPrice += consigmentDB.Amount * consigmentDB.Price;
                                currentAmountConsigment -= consigmentDB.Amount;
                                // удаление данных о поставке их БД
                                if(isChange) DeleteConsigment(consigmentDB.Id);
                            }
                        }
                    }
                }
            }
            if (isExistProduct) return totalPrice;
            else return 0;

        }

        private async void DeleteConsigment(int id)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                    DELETE FROM AVAILABILITY WHERE
                    Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            await command.ExecuteNonQueryAsync();
        }

        private async void UpdateConsigment(int id, int newAmount)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                    UPDATE AVAILABILITY 
                    SET Amount = @newAmount
                    WHERE Id=@id", connection);
            command.Parameters.AddWithValue("@newAmount", newAmount);
            command.Parameters.AddWithValue("@id", id);
            await command.ExecuteNonQueryAsync();
        }
    }
}
