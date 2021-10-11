using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookLoggerConsole
{
    class DapperNotesRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperNotesRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Notes> GetAllNotes()
        {
            return _connection.Query<Notes>("SELECT * FROM notes;");
        }
    }
}
