using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AppStore.DAL.Interfaces;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace AppStore.DAL.Repositories.Database
{
    internal class RepositoryProduct: IRepositoryProduct
    {
        private static RepositoryProduct Instance { get; set; }

        private readonly string _connectionString = $"Data Source={Path.Combine(AppContext.BaseDirectory, "StoreDB.db")}";
        private static readonly object _dbLock = new();
        private RepositoryProduct() { }
        public static RepositoryProduct GetInstance()
        {
            if (Instance == null)
            {
                Instance = new RepositoryProduct();
            }
            return Instance;
        }
        public override async Task<bool> CreateProduct(string nameProduct)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@"
                INSERT INTO Product(Name)
                VALUES(@Name)", connection);
            command.Parameters.AddWithValue("@Name", nameProduct);
            await command.ExecuteNonQueryAsync();
            return true;
            
        }
    }
}
