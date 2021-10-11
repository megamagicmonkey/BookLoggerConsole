using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace BookLoggerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var bookRepo = new DapperBooksRepository(conn);
            var catRepo = new DapperCategoriesRepository(conn);
            var libRepo = new DapperHomeLibraryRepository(conn);
            var logRepo = new DapperLogRepository(conn);
            var noteRepo = new DapperNotesRepository(conn);

            

        }
    }
}
