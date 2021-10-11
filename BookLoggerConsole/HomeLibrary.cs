using System;
using System.Collections.Generic;
using System.Text;

namespace BookLoggerConsole
{
    class HomeLibrary
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public bool Hardback { get; set; }
        public string Edition { get; set; }
        public int CategoryID { get; set; }
        public string Genre { get; set; }
        public DateTime DatePurchased { get; set; }
        public DateTime DatePrinted { get; set; }
        public int PageCount { get; set; }
        public bool Wishlist { get; set; }

    }
}
