using System;
using System.Collections.Generic;
using System.Text;

namespace BookLoggerConsole
{
    public class BookLogger
    {
        public static void Tutorial()
        {
            string input;
            bool run = true;

            while (run)
            {
                Console.Clear();
                Console.WriteLine("Which field would you like to learn more about? If it's your first time using this program,");
                Console.WriteLine("I would suggest picking '1' to begin with. Please enter the number of the field to continue.");
                Console.WriteLine("1) Book Listings | 2) Your Library | 3) Your Wishlist");
                Console.WriteLine("4) Your BookLog  | 5) Your Notes   | 6) Exit This Guide");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Your Book Listings is the heart of BookLogger. If no books are listed here, there won't be anything to log!");
                        Console.WriteLine("This listing should cover every book you want BookLogger to track, whether it be books you own, books you want,");
                        Console.WriteLine("or even just books you know about! Every book needs at least a name or title, but you only need one listing for");
                        Console.WriteLine("each book. No need for duplicate entries here if the title and author are the same!");
                        Console.WriteLine();
                        Console.WriteLine("Now, as far as BookLogger is concerned, the books in your Book Listing are the only books that exist, so the");
                        Console.WriteLine("other fields can only work with entries in your Book Listing! So the more robust your Book Listing, the more you");
                        Console.WriteLine("can do with BookLogger!");
                        Console.WriteLine();
                        Console.WriteLine("Interacting with the BookListings field will let you add, edit, search for, or remove books from your list.");
                        Console.WriteLine("Be very careful when deleting books though! Any books deleted from your listing will also remove any information");
                        Console.WriteLine("associated with it, such as logs and notes! When adding an entry, remember a name/title is necessary, but the");
                        Console.WriteLine("author can be kept blank if there is no author, or the author is unknown. Also, if a work has multiple authors,");
                        Console.WriteLine("you may input them in all at once.");
                        Console.WriteLine();
                        Console.WriteLine("Hopefully this teaches you all you need to know about Book Listings!");
                        Console.WriteLine("Press 'enter' to continue.");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Your Library represents all the books you own! All the information logged in here is optional, so it's only as");
                        Console.WriteLine("detailed as you need or want it to be. The library can reference the same book multiple times, so you can make");
                        Console.WriteLine("a listing for each copy you own, whether distinct or duplicate!");
                        Console.WriteLine();
                        Console.WriteLine("Your Library can record a wide range of information on your books to help you keep track of distinct differences");
                        Console.WriteLine("between copies you might own! Your Library can record the edition of your book, if it's hardback or not, which");
                        Console.WriteLine("category it belongs to of a set list (such as novel, manual, magazine, liturgical, etc.), when the book was printed,");
                        Console.WriteLine("when the book was purchased, what genre it belongs to, and its page count!");
                        Console.WriteLine();
                        Console.WriteLine("Interacting with the Your Library field will let you add, edit, search for, or remove books from your library.");
                        Console.WriteLine("If you're adding an entry, simply pick a book from your Book Listings and add the relevant information. This new");
                        Console.WriteLine("entry will serve to mark a copy you own of that book!");
                        Console.WriteLine();
                        Console.WriteLine("Hopefully this teaches you all you need to know about Your Library!");
                        Console.WriteLine("Press 'enter' to continue.");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Your Wishlist is much the same as Your Library, but represents books you're interested in, rather than books you");
                        Console.WriteLine("have. Just like Your Library, you can fill it out with all kinds of distinct information, so you can keep a record");
                        Console.WriteLine("of distinct versions of the same book. Maybe you have the latest edition, but you wish for a first edition as well?");
                        Console.WriteLine("The wishlist makes not only keeping track of these things easy, but with a simple command, you can move all the");
                        Console.WriteLine("information contained in a wishlist item to Your Library! Updating your wishlist into your collection has never");
                        Console.WriteLine("been easier!");
                        Console.WriteLine();
                        Console.WriteLine("Just like in Your Library, you can add, edit, search for, and delete items. Like mentioned above, you can also easily");
                        Console.WriteLine("transition an item from Your Wishlist to Your Library! All the same information is stored in Your Wishlist as Your");
                        Console.WriteLine("Library except for the date it was purchased. When you transition the information over, you can choose to assign the");
                        Console.WriteLine("purchase date as the day you enact the tranition, or input a date manually if at all.");
                        Console.WriteLine("Hopefully this teaches you all you need to know about Your Wishlist!");
                        Console.WriteLine("Press 'enter' to continue.");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Your BookLog is a tool designed to help keep track of your reading habits or help you manage your reading schedule!");
                        Console.WriteLine("The log can hold information on when you started and stopped a session of reading with a book as well as how many");
                        Console.WriteLine("pages you read! To time yourself, choose the option \"Begin Timed Session\". This will log the time into a database.");
                        Console.WriteLine("When your reading session is over, simply choose to end the session. When your session ends, you can choose to log how");
                        Console.WriteLine("many pages you read as well. This should make observing your own habits with your books more apparent to you! Are");
                        Console.WriteLine("Some books easier to read than others? Do you read more and more easily in the morning? Or perhaps you're logging a");
                        Console.WriteLine("study session? The log is here to help you! Even if you're not interested in logging your time with books, you can");
                        Console.WriteLine("still keep track of the number of pages you've read independently of a timer!");
                        Console.WriteLine();
                        Console.WriteLine("Interacting with the Your BookLog field lets you start and stop a timer for your reading time. You can also add and");
                        Console.WriteLine("edit the pages read entries in each log, or delete a log altogether! Each log is also dated, so you can search for");
                        Console.WriteLine("specific log entries!");
                        Console.WriteLine();
                        Console.WriteLine("Hopefully this teaches you all you need to know about Your BookLog!");
                        Console.WriteLine("Press 'enter' to continue.");
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Your Notes keeps track of any information you wish to personally write about a book. The nature of these notes is");
                        Console.WriteLine("Entirely up to you! Maybe write a review? Or write the address of the bookstore you have it ordered with. Perhaps");
                        Console.WriteLine("write up an essay on its themes and message? Each note is a freeform space for you to write anything you want! You");
                        Console.WriteLine("can even write notes about books you don't own, or have multiple notes tied to the same book!");
                        Console.WriteLine();
                        Console.WriteLine("Interacting with the Your Notes field lets you create, edit, or delete notes on any book in the Your Books section.");
                        Console.WriteLine("You can also search for your notes by looking up specific books or phrases contained in the notes themselves!");
                        Console.WriteLine();
                        Console.WriteLine("Hopefully this teaches you all you need to know about Your Notes!");
                        Console.WriteLine("Press 'enter' to continue.");
                        Console.ReadLine();
                        break;
                    case "6":
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("I hope you found this guide useful!");
                        Console.WriteLine("Press 'enter' to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        run = false;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Sorry, I don't recognize that option. Please select a number from the list.");
                        Console.WriteLine("Press 'enter' to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
