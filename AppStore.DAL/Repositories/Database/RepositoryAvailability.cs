using AppStore.DAL.Interfaces;
using AppStore.DAL.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using Serilog;

namespace AppStore.DAL.Repositories.Database
{
    public class RepositoryAvailability: IRepositoryAvailability
    {
        private RepositoryStore RepositoryStore { get; } = RepositoryStore.GetInstance();
        private RepositoryProduct RepositoryProduct { get; } = RepositoryProduct.GetInstance();
        private static RepositoryAvailability Instance { get; set; }

        private static string ConnectionString { get; } = $"Data Source={Path.Combine(AppContext.BaseDirectory, "StoreDB.db")}";

        public static RepositoryAvailability GetInstance()
        {
            Instance ??= new RepositoryAvailability();
            return Instance;
        }

        public async Task<List<ShowProduct>> GetAllProducts()
        {
            Log.Information("Database RepositoryAvailability: Get All Products");
            var products = new List<ShowProduct>();
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand()
            {
                Connection = connection,
                CommandText = @"select s.Name as Store, p.Name as Product, Price, Amount from AVAILABILITY as a
                join STORE as s on s.Id=a.IdStore
                join PRODUCT as p on p.Id=IdProduct"
            };
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

        public async Task<bool> DeliverGoodsToTheStore(int idStore, List<Consignment> consignments)
        {
            Log.Information("DataBase RepositoryAvailability: Deliver Goods To The Store");
            var products = new List<ShowProduct>();
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            int idProduct;
            foreach (Consignment consignment in consignments)
            {
                idProduct = await RepositoryProduct.GetProductByName(consignment.Product);
                var command = new SqliteCommand()
                {
                    Connection = connection,
                    CommandText = @"
                INSERT INTO Availability(idStore, idProduct, Price, Amount)
                VALUES(@idStore, @idProduct, @Price, @Amount)"
                };
                command.Parameters.AddWithValue("@idStore", idStore);
                command.Parameters.AddWithValue("@idProduct", idProduct);
                command.Parameters.AddWithValue("@Price", consignment.Price);
                command.Parameters.AddWithValue("@Amount", consignment.Amount);
                await command.ExecuteNonQueryAsync();
            }
            return true;
        }
        public async Task<List<string>> SearchStoreCheapestProduct(int idProduct)
        {
            Log.Information("DataBase RepositoryAvailability: Search Store Cheapest Product");
            Batteries.Init();
            var result = new List<string>();
            var idStore = int.MinValue; 
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand()
            {
                Connection = connection,
                CommandText = @"select IdStore, min(price) as price from AVAILABILITY WHERE
                idProduct = @idProduct"
            };
            command.Parameters.AddWithValue("@idProduct", idProduct);
            using (var reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    idStore = Convert.ToInt32(reader["idStore"]);
                    result.Add(RepositoryStore.GetStoreById(idStore).Result);
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

        public async Task<List<ProductAmount>> SearchProductOnTheSum(int idStore, int sum)
        {
            Log.Information("DataBase RepositoryAvailability: Search Product On The Sum");
            var products = new List<ProductAmount>();
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand()
            {
                Connection = connection,
                CommandText = @"
                    select p.Name as Product, Price, Amount from AVAILABILITY as a
                    JOIN PRODUCT as p on p.Id=a.IdProduct
                    where IdStore =  @idStore"
            };
            command.Parameters.AddWithValue("@idStore", idStore);
            var price = int.MinValue;
            var amountCommon = int.MinValue;
            var amount = int.MinValue;
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

        public async Task<int> BuyConsignmentInStore(int idStore, List<Consignment> consignments, bool isChange)
        {
            Log.Information("DataBase RepositoryAvailability: Buy Consignment In Store");
            var totalPrice = 0;
            var isExistProduct = true;
            var consignmentsDB = new List<Consignment>();
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand()
            {
                Connection = connection,
                CommandText = @"
                    select a.Id, p.Name as Product, Price, Amount from AVAILABILITY as a
                    JOIN PRODUCT as p on p.Id=a.IdProduct
                    where IdStore =  @idStore"
            };
            command.Parameters.AddWithValue("@idStore", idStore);
            // получение всех поставок с данного магазина
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    var consignment = new Consignment
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Product = reader["Product"].ToString(),
                        Price = Convert.ToInt32(reader["Price"]),
                        Amount = Convert.ToInt32(reader["Amount"])
                    };
                    consignmentsDB.Add(consignment);
                }
            }
            // текущее количество товара данной поставки, которое надо найти
            var currentAmountConsignment = 0;
            var newAmount = int.MinValue; 
            var commonAmount = 0; // сколько такого товара есть в магазине
            // проверка на то, что в магазине есть нужное количество товаров
            foreach (var consignment in consignments)
            {
                currentAmountConsignment = consignment.Amount;
                commonAmount = 0;
                foreach (var consignmentDB in consignmentsDB)
                {

                    if (commonAmount >= currentAmountConsignment)
                    {
                        break;
                    }
                    if (consignment.Product == consignmentDB.Product)
                    {
                        commonAmount += consignmentDB.Amount;
                    }
                }
            }
            if (commonAmount < currentAmountConsignment)
            {
                isExistProduct = false;
            }
            else {
                foreach (var consignment in consignments)
                {
                    currentAmountConsignment = consignment.Amount;

                    foreach (var consignmentDB in consignmentsDB)
                    {
                        // если необходимо количество товара найдено
                        if (currentAmountConsignment == 0)
                        {
                            break;
                        }
                        // в поставке найден нужный товар
                        if (consignment.Product == consignmentDB.Product)
                        {
                            // если в данной поставке товара больше чем необходимо
                            if (consignmentDB.Amount > currentAmountConsignment)
                            {
                                totalPrice += currentAmountConsignment * consignmentDB.Price;
                                newAmount = consignmentDB.Amount - currentAmountConsignment;
                                // обновление данных о поставке
                                if(isChange)UpdateConsignment(consignmentDB.Id, newAmount);
                                currentAmountConsignment = 0;
                                break;
                            }
                            else // если в поставке товара меньше
                            {
                                totalPrice += consignmentDB.Amount * consignmentDB.Price;
                                currentAmountConsignment -= consignmentDB.Amount;
                                // удаление данных о поставке их БД
                                if(isChange) DeleteConsignment(consignmentDB.Id);
                            }
                        }
                    }
                }
            }
            if (isExistProduct) return totalPrice;
            else return 0;
        }

        private async void DeleteConsignment(int id)
        {
            Log.Information("DataBase RepositoryAvailability: Delete Consignment");
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand()
            {
                Connection = connection,
                CommandText = @"
                    DELETE FROM AVAILABILITY WHERE
                    Id = @id"
            };
            command.Parameters.AddWithValue("@id", id);
            await command.ExecuteNonQueryAsync();
        }

        private async void UpdateConsignment(int id, int newAmount)
        {
            Log.Information("DataBase RepositoryAvailability: Update Consignment");
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand()
            {
                Connection = connection,
                CommandText = @"
                    UPDATE AVAILABILITY 
                    SET Amount = @newAmount
                    WHERE Id=@id"
            };
            command.Parameters.AddWithValue("@newAmount", newAmount);
            command.Parameters.AddWithValue("@id", id);
            await command.ExecuteNonQueryAsync();
        }
    }
}
