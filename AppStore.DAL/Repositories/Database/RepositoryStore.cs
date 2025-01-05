using AppStore.DAL.Interfaces;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace AppStore.DAL.Repositories.Database
{
    public class RepositoryStore: IRepositoryStore
    {
        private static RepositoryStore Instance { get; set; }

        private readonly string _connectionString = $"Data Source={Path.Combine(AppContext.BaseDirectory, "StoreDB.db")}";
        private RepositoryStore() { }
        public static RepositoryStore GetInstance()
        {
            if (Instance == null)
            {
                Instance = new RepositoryStore();
            }
            return Instance;
        }

        public new async Task<bool> CreateStore(string nameStore, string address)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@$"
                INSERT INTO STORE(Name, Address)
                VALUES
                (@nameStore, @address)", connection);
            command.Parameters.AddWithValue("@nameStore", nameStore);
            command.Parameters.AddWithValue("@address", address);
            await command.ExecuteNonQueryAsync();
            return true;
        }

        public new async Task<int> GetStoreByName(string store)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand("select Id from Store where Name=@store", connection);
            command.Parameters.AddWithValue("@store", store);
            int idStore=0;
            using (var reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    idStore = Convert.ToInt32(reader["Id"]);
                }
            }
            return idStore;
        }

        public new async Task<List<string>> ShowAllStores()
        {
            var stores = new List<string>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"select Name from Store";
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    stores.Add(reader["Name"].ToString());
                }
            }

            return stores;
        }

        public new async Task<string> GetStoreById(int idStore)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand("select Name from Store where Id=@idStore", connection);
            command.Parameters.AddWithValue("@idStore", idStore);
            string store = "";
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
