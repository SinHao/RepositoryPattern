using System;
using Dapper;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Connections.IConnection connection = new Connections.SqliteConnectionService(new System.Data.SQLite.SQLiteConnection("Data Source=test.db"));
            Databases.IMyDatabase myDatabase = new Databases.MySqlite(connection);

            myDatabase.BeginTransaction();
            myDatabase.Table1.AddTable1(new Models.Table1
            {
                Id = 222,
                Column1 = "v1"
            });
            myDatabase.Rollback();
        }
    }
}
