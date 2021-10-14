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


        //Select All
        public IEnumerable<Log> GetAllLogs()
        {
            return _connection.Query<Log>("SELECT * FROM log;");
        }



        //arguments use the term old if it is referencing an old item and new if it is creating or editing new information

        //Both the session start and session end parameters cannot be edited to preserve data integrity. Date also cannot be edited.


        //Begins an entry when it is selected. SessionStart's time is set by the computer's clock when the method is called
        public void StartTimeLog(int oldBookID, TimeSpan newSessionStart, DateTime newDate ) 
        {
            _connection.Execute("INSERT INTO log (BookID, SessionStart, Date) VALUES (@BookID, @SessionStart, @Date);",
            new { BookID = oldBookID, SessionStart = newSessionStart, Date = newDate });
        }

        //When the timed session ends, it applies the computer's clock to SessionEnd and ties it to the LogID of the session created with StartTimeLog()
        public void EndTimeLog(int oldLogID, TimeSpan newSessionEnd)
        {
            _connection.Execute("UPDATE log SET SessionEnd = @SessionEnd WHERE LogID = @LogID;",
            new { LogID = oldLogID, SessionEnd = newSessionEnd });
        }

        //Creates a log of pages read independent of a timed session
        public void AddPageLog(int oldBookID, int newPagesRead, DateTime newDate)
        {
            _connection.Execute("INSERT INTO log (BookID, PagesRead, Date) VALUES (@BookID, PagesRead, Date);",
            new { BookID = oldBookID, PagesRead = newPagesRead, Date = newDate });
        }

        //To keep the session end time as accurate as possible, pages read during that session are applied through here instead of EndTimeLog()
        public void EditPageLog(int oldLogID, int newPagesRead)
        {
            _connection.Execute("UPDATE log SET PagesRead = @PagesRead WHERE LogID = @LogID;", 
            new { LogID = oldLogID, PagesRead = newPagesRead });
        }

        //Delete method
        public void DeleteEntry(int oldLogID)
        {
            _connection.Execute("DELETE FROM log WHERE LogID = @LogID;",
            new { LogID = oldLogID });
        }
    }
}
