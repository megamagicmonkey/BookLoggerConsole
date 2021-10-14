using System;
using System.Collections.Generic;
using System.Text;

namespace BookLoggerConsole
{
    class Joined
    {
        //Native to Books
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        //Native to Log (contains BookID)
        public int LogID { get; set; }
        public TimeSpan SessionStart { get; set; }
        public TimeSpan SessionEnd { get; set; }
        public int? PagesRead { get; set; }
        public DateTime Date { get; set; }
        //Native to categories
        public int CategoryID { get; set; }
        public string Category { get; set; }
        //Native to HomeLibrary (Contains BookID and CategoryID)
        public int ID { get; set; }
        public bool? Hardback { get; set; }
        public string Edition { get; set; }
        public string Genre { get; set; }
        public DateTime DatePurchased { get; set; }
        public DateTime DatePrinted { get; set; }
        public int? PageCount { get; set; }
        public bool? Wishlist { get; set; }
        //Native to Notes (contains BookID)
        public int NotesID { get; set; }
        public string Note { get; set; }

    }
}
