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
    }
}
