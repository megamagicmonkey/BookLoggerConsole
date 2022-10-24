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

        //Select All
        public IEnumerable<Books> GetAllBooks()
        {
            return _connection.Query<Books>("SELECT * FROM books;");
        }

        //Search Authors
        public IEnumerable<Books> SearchAuthor(string newSearch)
        {
            return _connection.Query<Books>("SELECT * FROM books WHERE Author LIKE @search;",
                new { search = "%" + newSearch + "%" });
        }

        //Search BookNames
        public IEnumerable<Books> SearchBook(string newSearch)
        {
            return _connection.Query<Books>("SELECT * FROM books WHERE BookName LIKE @search;",
                new { search = "%" + newSearch + "%" });
        }

        //Search Both
        public IEnumerable<Books> SearchAll(string newSearch)
        {
            return _connection.Query<Books>("SELECT * FROM books WHERE BookName LIKE @search OR Author LIKE @search;",
                new { search = "%" + newSearch + "%" });
        }

        //Select specific book
        public Books SearchID(int newSearch)
        {
            return _connection.QuerySingle<Books>("SELECT * FROM books WHERE BookID = @search;",
                new { search = newSearch });
        }

        //arguments use the term old if it is referencing an old item and new if it is creating or editing new information



        //Adds a new book to the book list
        public void AddBook(string newBookName)
        {
            _connection.Execute("INSERT INTO books (BookName) VALUES (@bookName);",
            new { bookName = newBookName });
        }

        //An overload that also allows the author to be submitted with the book name
        public void AddBook(string newBookName, string newAuthor)
        {
            _connection.Execute("INSERT INTO books (BookName , Author) VALUES (@BookName , @Author);",
            new { BookName = newBookName, Author = newAuthor });
        }

        //This method edits the author listing of a book
        public void EditAuthor(int oldBookID, string newAuthor)
        {
            _connection.Execute("UPDATE books SET Author = @Author WHERE BookID = @BookID;",
            new { BookID = oldBookID, Author = newAuthor });
        }

        //This method edits the name of the book
        public void EditBookName(int oldBookID, string newBookName)
        {
            _connection.Execute("UPDATE books SET BookName = @BookName WHERE BookID = @BookID;",
            new { BookID = oldBookID, BookName = newBookName });
        }

        //Delete method
        public void DeleteEntry(int oldBookID)
        {
            _connection.Execute("DELETE FROM books WHERE BookID = @BookID;",
            new {BookID = oldBookID});
        }
    }
}
