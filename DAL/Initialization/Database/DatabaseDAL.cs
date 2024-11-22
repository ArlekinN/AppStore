using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.DAL.Initialization.Database
{
    internal static class DatabaseDAL
    {
        private static readonly string dbPath = Path.Combine(AppContext.BaseDirectory, "StoreDB.db");
        public static void InitializationDatabase()
        {
            if (!File.Exists(dbPath))
            {
                CreateDatabase();
                Seed();
            }
        }
        private static void CreateDatabase()
        {
            Batteries.Init();
            using var connection = new SqliteConnection($"Data Source={dbPath}");
            connection.OpenAsync().GetAwaiter().GetResult();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"CREATE TABLE IF NOT EXISTS  PRODUCT( 
            Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, 
            Name VARCHAR(50) NOT NULL);
                
            CREATE TABLE IF NOT EXISTS  STORE(
            Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
            Name VARCHAR(50) NOT NULL,
            Address VARCHAR(50) NOT NULL);

            CREATE TABLE IF NOT EXISTS  AVAILABILITY(
            IdStore INTEGER NOT NULL,
            IdProduct INTEGER NOT NULL,
            Price INTEGER NOT NULL,
            Amount INTEGER NOT NULL,
            FOREIGN KEY (IdStore) REFERENCES Store(Id) ON DELETE CASCADE,
            FOREIGN KEY (IdProduct) REFERENCES Product(Id) ON DELETE CASCADE)";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();
        }

        private static void Seed()
        {
            Batteries.Init();
            using var connection = new SqliteConnection($"Data Source={dbPath}");
            connection.OpenAsync().GetAwaiter().GetResult();
            SqliteCommand command = new() { Connection = connection };
            command.CommandText = @"
            INSERT INTO PRODUCT(Id, Name)
            VALUES
                (1, 'Milk'),
                (2, 'Bread'),
                (3, 'Oil'),
                (4, 'Eggs'),
                (5, 'Jogurt');
            INSERT INTO STORE(Id, Name, Address)
            VALUES
                (1, 'KateStore', 'Millionnaya 30'),
                (2, 'Goh', 'Rosa 6'),
                (3, 'FiveOne', 'Red 18');
        ";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();

            command.CommandText = @"
            INSERT INTO AVAILABILITY(IdStore, IdProduct, Price, Amount)
            VALUES
                (1, 1, 115, 30 ),
                (1, 3, 110, 40 ),
                (1, 5, 56, 112 ),
                (2, 1, 120, 40 ),
                (2, 2, 32, 210 ),
                (2, 4, 12, 400 ),
                (2, 5, 70, 30 ),
                (3, 5, 67, 80 ),
                (3, 2, 30, 90 ),
                (3, 1, 90, 50 ),
                (3, 4, 9, 300 ),
                (3, 3, 135, 70 )";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();
        }
    }

}
