﻿using AppStore.DAL.Interfaces;
using AppStore.Models;
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
        public override async Task<List<ShowProduct>> GetAllProducts()
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

        public async Task<bool> DeliverGoodsToTheStore(int idStore, List<Consigment> consigments)
        {
            var products = new List<ShowProduct>();
            Batteries.Init();
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            int idProduct;
            foreach (Consigment consigment in consigments)
            {

                idProduct = await _repositoryProduct.GetProductById(consigment.Product);
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
    }
}
