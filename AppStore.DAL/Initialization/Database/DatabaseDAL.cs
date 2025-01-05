using Microsoft.Data.Sqlite;
using SQLitePCL;

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
            Id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, 
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
                (1, 'Brain'),
                (2, 'Heart'),
                (3, 'Hand'),
                (4, 'Finger'),
                (5, 'Stomach');
            INSERT INTO STORE(Id, Name, Address)
            VALUES
                (1, 'NewBody', 'Millionnaya 30'),
                (2, 'Donor.Net', 'Rosa 6'),
                (3, 'ThreeFingers', 'Red 18');
        ";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();

            command.CommandText = @"
            INSERT INTO AVAILABILITY(Id, IdStore, IdProduct, Price, Amount)
            VALUES
                (1, 1, 1, 400, 4 ),
                (2, 1, 3, 250, 20 ),
                (3, 1, 5, 380, 7 ),
                (4, 2, 1, 650, 8 ),
                (5, 2, 2, 800, 3 ),
                (6, 2, 4, 150, 25 ),
                (7, 2, 5, 350, 18 ),
                (8, 3, 5, 410, 12 ),
                (9, 3, 2, 910, 7 ),
                (10, 3, 1, 510, 9 ),
                (11, 3, 4, 170, 22 ),
                (12, 3, 3, 260, 11 )";
            command.ExecuteNonQueryAsync().GetAwaiter().GetResult();
        }
    }

}
