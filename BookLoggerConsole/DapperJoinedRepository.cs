using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookLoggerConsole
{
    /// <summary>
    ///This class is for combining base repositories through the join command
    /// </summary>
    class DapperJoinedRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperJoinedRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Joined> MainLibraryOut()
        {
            return _connection.Query<Joined>("SELECT B.BookName, B.Author, H.Hardback, C.Category, H.Genre, H.DatePrinted, H.DatePurchased, H.PageCount " +
                "FROM books AS B LEFT JOIN home_library as H ON B.BookID = H.BookID LEFT JOIN categories AS C ON H.CategoryID = C.CategoryID " +
                "WHERE H.Wishlist = 0;");
        }

        public IEnumerable<Joined> MainWishlistOut()
        {
            return _connection.Query<Joined>("SELECT B.BookName, B.Author, H.Hardback, C.Category, H.Genre, H.DatePrinted, H.PageCount " +
                "FROM books AS B LEFT JOIN home_library as H ON B.BookID = H.BookID LEFT JOIN categories AS C ON H.CategoryID = C.CategoryID " +
                "WHERE H.Wishlist = 1;");
        }

        public IEnumerable<Joined> MainNotesOut()
        {
            return _connection.Query<Joined>("Select B.BookName, B.Author, N.Note FROM books As B LEFT JOIN notes AS N ON B.BookID = N.BookID; ");
        }

        public IEnumerable<Joined> MainLogsOut()
        {
            return _connection.Query<Joined>("Select B.BookName, B.Author, L.SessionStart, L.SessionEnd, L.PagesRead, L.Date " +
                "FROM books As B LEFT JOIN log AS L ON B.BookID = L.BookID;");
        }



    }
}
