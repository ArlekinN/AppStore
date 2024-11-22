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
        private RepositoryStore() { }
        public static RepositoryStore GetInstance()
        {
            if (Instance == null)
            {
                Instance = new RepositoryStore();
            }
            return Instance;
        }
        public override bool CreateStore(string nameStore, string address)
        {
            Console.WriteLine("Repositoty");
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            connection.OpenAsync().GetAwaiter().GetResult();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @$"INSERT INTO STORE(Name, Address)
            VALUES
                ('{nameStore}', '{address}')";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();
            return true;
        }
    }
}
