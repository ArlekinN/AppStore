using AppStore.DAL.Interfaces;
using AppStore.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.DAL.Repositories.Database
{
    internal class RepositoryStore: IRepositoryStore
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

        public override async Task<int> GetStoreById(string store)
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

        public override async Task<List<string>> ShowAllStores()
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
    }
}
