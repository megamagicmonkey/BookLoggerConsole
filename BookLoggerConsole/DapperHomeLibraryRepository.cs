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


        //The method call for adding entries must declare all arguments, but blank fields will be submitted as null. All fields but ID fields can be submitted as null
        public void AddEntry(int oldBookID, bool isHardback, string newEdition, int newCategoryID, string newGenre, DateTime newDatePurchased, DateTime newDatePrinted, int newPageCount, bool isWishlist)
        {
            _connection.Execute("INSERT INTO home_library (BookID, Hardback, Edition, CategoryID, Genre, DatePurchased, DatePrinted, PageCount, Wishlist) " +
                "VALUES (@BookID, @Hardback, @Edition, @CategoryID, @Genre, @DatePurchased, @DatePrinted, @PageCount, @Wishlist);",
            new { BookID = oldBookID, Hardback = isHardback, Edition = newEdition, CategoryID = newCategoryID, Genre = newGenre,
                DatePurchased = newDatePurchased, DatePrinted = newDatePrinted, PageCount = newPageCount, Wishlist = isWishlist });
        }


        //The individual edit methods for each field. All fields can be edited except ID fields
        public void EditHardback(int oldID, bool isHardback){
            _connection.Execute("UPDATE home_library SET Hardback = @Hardback WHERE ID = @ID;", 
            new { ID = oldID, Hardback = isHardback });
        }

        public void EditEdition(int oldID, string newEdition)
        {
            _connection.Execute("UPDATE home_library SET Edition = @Edition WHERE ID = @ID;",
            new { ID = oldID, Edition = newEdition });
        }

        public void EditCategoryID(int oldID, int newCategoryID)
        {
            _connection.Execute("UPDATE home_library SET CategoryID = @CategoryID WHERE ID = @ID;",
            new { ID = oldID, CategoryID = newCategoryID });
        }

        public void EditGenre(int oldID, string newGenre)
        {
            _connection.Execute("UPDATE home_library SET Genre = @Genre WHERE ID = @ID;",
            new { ID = oldID, Genre = newGenre });
        }

        public void EditDatePurchased(int oldID, DateTime newDatePurchased)
        {
            _connection.Execute("UPDATE home_library SET DatePurchased = @DatePurchased WHERE ID = @ID;",
            new { ID = oldID, DatePurchased = newDatePurchased });
        }

        public void EditDatePrinted(int oldID, DateTime newDatePrinted)
        {
            _connection.Execute("UPDATE home_library SET DatePrinted = @DatePrinted WHERE ID = @ID;",
            new { ID = oldID, DatePrinted = newDatePrinted });
        }

        public void Edit(int oldID, int newPageCount)
        {
            _connection.Execute("UPDATE home_library SET PageCount = @PageCount WHERE ID = @ID;",
            new { ID = oldID, PageCount = newPageCount });
        }

        public void EditWishlist(int oldID, bool isWishlist)
        {
            _connection.Execute("UPDATE home_library SET Wishlist = @Wishlist WHERE ID = @ID;",
            new { ID = oldID, Wishlist = isWishlist });
        }

        public void Edit(int oldID)
        {
            _connection.Execute("UPDATE home_library SET XXX = @XXX WHERE ID = @ID;",
            new { ID = oldID });
        }

        //Delete method
        public void DeleteEntry(int oldID)
        {
            _connection.Execute("DELETE FROM home_library WHERE ID = @ID;",
            new { ID = oldID });
        }
    }
}
