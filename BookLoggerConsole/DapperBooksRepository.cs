using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookLoggerConsole
{
    class DapperBooksRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperBooksRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Books> GetAllBooks()
        {
            return _connection.Query<Books>("SELECT * FROM books;");
        }

        public void AddBook(string newBookName)
        {
            _connection.Execute("INSERT INTO books (BookName) VALUES (@bookName);",
            new { bookName = newBookName });
        }
        public void AddBook(string newBookName, string newAuthor)
        {
            _connection.Execute("INSERT INTO books (BookName , Author) VALUES (@bookName , @author);", //This line is almost certainly wrong
            new { bookName = newBookName });
            //new { author = newAuthor }
        }
    }
}
