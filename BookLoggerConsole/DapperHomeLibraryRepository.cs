using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookLoggerConsole
{
    class DapperHomeLibraryRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperHomeLibraryRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<HomeLibrary> GetLibrary()
        {
            return _connection.Query<HomeLibrary>("SELECT * FROM home_library;");
        }

        //arguments use the term old if it is referencing an old item and new if it is creating or editing new information

        public void AddEntry(int oldBookID, bool isHardback, string newEdition, int newCategoryID, string newGenre, DateTime newDatePurchased, DateTime newDatePrinted, int newPageCount, bool isWishlist)
        {
            _connection.Execute("INSERT INTO home_library (BookID, Hardback, Edition, CategoryID, Genre, DatePurchased, DatePrinted, PageCount, Wishlist) " +
                "VALUES (@BookID, @Hardback, @Edition, @CategoryID, @Genre, @DatePurchased, @DatePrinted, @PageCount, @Wishlist);",
            new { BookID = oldBookID , Hardback = isHardback, Edition = newEdition, CategoryID = newCategoryID, Genre = newGenre, 
                DatePurchased = newDatePurchased, DatePrinted = newDatePrinted, PageCount = newPageCount, Wishlist = isWishlist });
        }
    }
}
