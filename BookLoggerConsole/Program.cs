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
            var joinRepo = new DapperJoinedRepository(conn);

            string input;
            bool run = true;


            Console.WriteLine("Welcome to BookLogger! Your personal book organization software!");
            while (run)
            {

                Console.WriteLine("Select the number of the field would you like to interact with.");
                Console.WriteLine("1) Book Listings | 2) Your Library | 3) Your Wishlist");
                Console.WriteLine("4) Your BookLog  | 5) Your Notes   | 6) I'm not sure!");
                Console.WriteLine("7) Exit Program");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        BookLogger.Tutorial();
                        break;
                    case "7":
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Thank you for using BookLogger! We hope you enjoy your books, and have a wonderful day!");
                        Console.WriteLine("Press 'enter' to continue.");
                        Console.ReadLine();
                        run = false;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Sorry, I don't recognize that option. Please select a number from the list.");
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                }
            }
        }
        
    }
}
