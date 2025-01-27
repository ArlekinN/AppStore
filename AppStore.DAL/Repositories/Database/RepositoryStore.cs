using AppStore.DAL.Interfaces;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using Serilog;

namespace AppStore.DAL.Repositories.Database
{
    public class RepositoryStore: IRepositoryStore
    {
        private static RepositoryStore Instance { get; set; }

        private static string ConnectionString { get; } = $"Data Source={Path.Combine(AppContext.BaseDirectory, "StoreDB.db")}";
        public static RepositoryStore GetInstance()
        {
            Instance ??= new RepositoryStore();
            return Instance;
        }

        public async Task<bool> CreateStore(string nameStore, string address)
        {
            Log.Information("DataBase RepositoryStore: Create Store");
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand()
            {
                Connection = connection,
                CommandText = @$"
                INSERT INTO STORE(Name, Address)
                VALUES
                (@nameStore, @address)"
            };
            command.Parameters.AddWithValue("@nameStore", nameStore);
            command.Parameters.AddWithValue("@address", address);
            await command.ExecuteNonQueryAsync();
            return true;
        }

        public async Task<int> GetIdStoreByName(string store)
        {
            Log.Information("DataBase RepositoryStore: Get Id Store By Name");
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand()
            {
                Connection = connection,
                CommandText = @"
                select Id from Store where Name=@store"
            };
            command.Parameters.AddWithValue("@store", store);
            var idStore = 0;
            using (var reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    idStore = Convert.ToInt32(reader["Id"]);
                }
            }
            return idStore;
        }

        public async Task<List<string>> ShowAllStores()
        {
            Log.Information("DataBase RepositoryStore: Show All Stores");
            var stores = new List<string>();
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand()
            {
                Connection = connection,
                CommandText = "select Name from Store"
            };
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    stores.Add(reader["Name"].ToString());
                }
            }

            return stores;
        }

        public async Task<string> GetStoreById(int idStore)
        {
            Log.Information("DataBase RepositoryStore: Get Store By Id");
            Batteries.Init();
            var connection = new SqliteConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new SqliteCommand()
            {
                Connection = connection,
                CommandText = "select Name from Store where Id=@idStore"
            };
            command.Parameters.AddWithValue("@idStore", idStore);
            var store = string.Empty;
            using (var reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    store = reader["Name"].ToString();
                }
            }
            return store;
        }
    }
}
