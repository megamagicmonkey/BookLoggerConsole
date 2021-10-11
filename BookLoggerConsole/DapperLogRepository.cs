using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookLoggerConsole
{
    class DapperLogRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperLogRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Log> GetAllLogs()
        {
            return _connection.Query<Log>("SELECT * FROM log;");
        }
    }
}
