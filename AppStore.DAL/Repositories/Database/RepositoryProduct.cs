using AppStore.DAL.Interfaces;
using Microsoft.Data.Sqlite;
using Serilog;
using SQLitePCL;

namespace AppStore.DAL.Repositories.Database
{
    public class RepositoryProduct: IRepositoryProduct
    {
        private static RepositoryProduct Instance { get; set; }

        private static string ConnectionString { get; } = $"Data Source={Path.Combine(AppContext.BaseDirectory, "StoreDB.db")}";
        public static RepositoryProduct GetInstance()
        {
            Instance ??= new RepositoryProduct();
            return Instance;
        }
        public async Task<bool> CreateProduct(string nameProduct)
        {
            Log.Information("DataBase RepositoryProduct: Create Product");
            Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand()
            {
                Connection = connection,
                CommandText = @"
                INSERT INTO Product(Name)
                VALUES(@Name)"
            };
            command.Parameters.AddWithValue("@Name", nameProduct);
            await command.ExecuteNonQueryAsync();
            return true;
        }

        public async Task<int> GetProductByName(string product)
        {
            Log.Information("DataBase RepositoryProduct: Get Product By Name");
            Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand()
            {
                Connection = connection,
                CommandText = @$"select Id from Product where Name=@product"
            };
            command.Parameters.AddWithValue("@product", product);
            int idProduct=0;
            using (var reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    idProduct = Convert.ToInt32(reader.GetValue(0));
                }     
            }
            return idProduct;
        }

        public async Task<List<string>> ShowUniqueProducts()
        {
            Log.Information("DataBase RepositoryProduct: Show Unique Products");
            var products = new List<string>();
            Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand()
            {
                Connection = connection,
                CommandText = @"select Name from Product"
            };
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    products.Add(reader["Name"].ToString());
                }
            }
            return products;
        }
    }
}
