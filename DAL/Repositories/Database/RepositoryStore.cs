using AppStore.DAL.Interfaces;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.DAL.Repositories.Database
{
    internal class RepositoryStore: IRepositoryStore
    {
        private static RepositoryStore Instance { get; set; }

        private readonly string _connectionString = $"Data Source={Path.Combine(AppContext.BaseDirectory, "StoreDB.db")}";
        private static readonly object _dbLock = new();
        private RepositoryStore() { }
        public static RepositoryStore GetInstance()
        {
            if (Instance == null)
            {
                Instance = new RepositoryStore();
            }
            return Instance;
        }
        public override async Task<bool> CreateStore(string nameStore, string address)
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
    }
}
