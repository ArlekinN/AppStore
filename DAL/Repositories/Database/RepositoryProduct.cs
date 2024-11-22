using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AppStore.DAL.Interfaces;
using AppStore.Models;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace AppStore.DAL.Repositories.Database
{
    internal class RepositoryProduct: IRepositoryProduct
    {
        private static RepositoryProduct Instance { get; set; }

        private readonly string _connectionString = $"Data Source={Path.Combine(AppContext.BaseDirectory, "StoreDB.db")}";
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

        public override async Task<int> GetProductByName(string product)
        {
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            using var command = new SqliteCommand(@$"
                select Id from Product where Name=@product", connection);
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

        public override async Task<List<string>> ShowUniqProducts()
        {
            var products = new List<string>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"select Name from Product";
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
