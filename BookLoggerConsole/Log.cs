using System;
using System.Collections.Generic;
using System.Text;

namespace BookLoggerConsole
{
    class Log
    {
        public int LogID { get; set; }
        public int BookID { get; set; }
        public TimeSpan SessionStart { get; set; }
        public TimeSpan SessionEnd { get; set; }
        public int? PagesRead { get; set; }
        public DateTime Date { get; set; }
    }
}
