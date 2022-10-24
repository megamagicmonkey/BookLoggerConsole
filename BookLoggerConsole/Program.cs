using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BookLoggerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            var bookRepo = new DapperBooksRepository(conn);
            var catRepo = new DapperCategoriesRepository(conn);
            var libRepo = new DapperHomeLibraryRepository(conn);
            var logRepo = new DapperLogRepository(conn);
            var noteRepo = new DapperNotesRepository(conn);
            var joinRepo = new DapperJoinedRepository(conn);


            string input;
            bool run = true;


            Console.WriteLine("Welcome to BookLogger! Your personal book organization software!");
            Console.WriteLine("Press 'enter' to continue.");
            Console.ReadLine();
            while (run)
            {
                Console.Clear();
                Console.WriteLine("Main Menu - Please enter the number of the option you would like to interact with.");
                Console.WriteLine("1) Book Listings | 2) Your Library | 3) Your Wishlist");
                Console.WriteLine("4) Your BookLog  | 5) Your Notes   | 6) I'm not sure!");
                Console.WriteLine("7) Exit Program");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        YourBooks(bookRepo);
                        break;
                    case "2":
                        YourLibrary();
                        break;
                    case "3":
                        YourWishlist();
                        break;
                    case "4":
                        YourLog();
                        break;
                    case "5":
                        YourNotes();
                        break;
                    case "6":
                        Tutorial();
                        break;
                    case "7":
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Thank you for using BookLogger! We hope you enjoy your books, and have a wonderful day!");
                        Console.WriteLine("Press 'enter' to continue.");
                        Console.ReadLine();
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

        public static void Tutorial() //Option 6 from the main menu. Allows users to learn more about each option on the main menu.
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
                        Console.WriteLine("Interacting with the BookListings field will let you add or search for books in your list. After searching, you");
                        Console.WriteLine("may choose to edit or delete any among your entries listed.");
                        Console.WriteLine("**Be very careful when deleting books!** Any books deleted from your listing will also remove any information");
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
                        Console.WriteLine("Interacting with the Your Library field will let you add or search for books from your library. From a search you");
                        Console.WriteLine("also choose to edit or delete an entry.");
                        //TODO: Edit the following tutorial line. This design does not work.
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
                        Console.WriteLine();
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

        public static void YourBooks(DapperBooksRepository bookRepo) //The menu for adding, editing, searching for, and deleting books. The heart of the program.
        {
            string input;
            bool run = true;
            string name;
            string author = "";
            string search;

            while (run)
            {
                Console.Clear();
                Console.WriteLine("Your Books - Please enter the number of the option you would like.");
                Console.WriteLine("1) Add a book    | 2) Search for a book");
                Console.WriteLine("3) Return to Main Menu");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("What is the name of the book you wish to add?");
                        name = Console.ReadLine().Trim();
                        if (name != "")
                        {
                            Console.WriteLine("Who is the book's author/s? Leave the field blank if you want no author listed.");
                            author = Console.ReadLine().Trim();
                            if (author != "")
                            {
                                bookRepo.AddBook(name, author);

                                Console.WriteLine($"{name} by {author} added to Your Books!");
                            }
                            else
                            {
                                bookRepo.AddBook(name);
                                Console.WriteLine($"{name} added to Your Books!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("That is not a valid book name.");
                        }

                        Console.WriteLine("Press 'enter' to continue.");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Please enter your search criteria. If left blank, your search will return every item.");
                        search = Console.ReadLine();
                        if (search != "")
                        {
                            Console.WriteLine("Did you wish to search book names, authors, or both? Please enter the number of the option.");
                            Console.WriteLine("1) Book names | 2) Authors | 3) Both");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    Console.WriteLine("The books that meet your query are:");
                                    var bookSearch = bookRepo.SearchBook(search);
                                    foreach (var book in bookSearch)
                                    {
                                        if (book.Author != null)
                                        {
                                            Console.WriteLine($"{book.BookID} ~ {book.BookName} ~ {book.Author}");
                                            Console.WriteLine();
                                        }
                                        else
                                        {
                                            Console.WriteLine($"{book.BookID} ~ {book.BookName}");
                                            Console.WriteLine();
                                        }
                                    }
                                    Console.WriteLine("If you would like to edit an entry, input its number, or leave the field blank");
                                    Console.WriteLine("to return to the Your Books menu selection.");
                                    input = Console.ReadLine();
                                    if (input != "")
                                    {
                                        EditBook(bookRepo, bookSearch, input);
                                    }
                                    break;
                                case "2":
                                    Console.WriteLine("The books that meet your query are:");
                                    bookSearch = bookRepo.SearchAuthor(search);
                                    foreach (var book in bookSearch)
                                    {
                                        Console.WriteLine($"{book.BookID} ~ {book.BookName} ~ {book.Author}");
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine("If you would like to edit an entry, input its number, or leave the field blank");
                                    Console.WriteLine("to return to the Your Books menu selection.");
                                    input = Console.ReadLine();
                                    if (input != "")
                                    {
                                        EditBook(bookRepo, bookSearch, input);
                                    }
                                    break;
                                case "3":
                                    Console.WriteLine("The books that meet your query are:");
                                    bookSearch = bookRepo.SearchAll(search);
                                    foreach (var book in bookSearch)
                                    {
                                        if (book.Author != null)
                                        {
                                            Console.WriteLine($"{book.BookID} ~ {book.BookName} ~ {book.Author}");
                                            Console.WriteLine();
                                        }
                                        else
                                        {
                                            Console.WriteLine($"{book.BookID} ~ {book.BookName}");
                                            Console.WriteLine();
                                        }
                                    }
                                    Console.WriteLine("If you would like to edit an entry, input its number, or leave the field blank");
                                    Console.WriteLine("to return to the Your Books menu selection.");
                                    input = Console.ReadLine();
                                    if (input != "")
                                    {
                                        EditBook(bookRepo, bookSearch, input);
                                    }
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
                        else
                        {
                            Console.WriteLine("Your book collection is:");
                            var bookSearch = bookRepo.GetAllBooks();
                            foreach (var book in bookSearch)
                            {
                                if (book.Author != null)
                                {
                                    Console.WriteLine($"{book.BookID} ~ {book.BookName} ~ {book.Author}");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine($"{book.BookID} ~ {book.BookName}");
                                    Console.WriteLine();
                                }
                            }
                            Console.WriteLine("If you would like to edit an entry, input its number, or leave the field blank");
                            Console.WriteLine("to return to the Your Books menu selection.");
                            input = Console.ReadLine();
                            if (input != "")
                            {
                                EditBook(bookRepo, bookSearch, input);
                            }
                        }

                        break;
                    case "3":
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

        public static void EditBook(DapperBooksRepository bookRepo, IEnumerable<Books> books, string bookID) //The method call for editing a book after searching for it.
        {
            bool confirmed = false;
            bool run = true;
            Console.Clear();
            if (int.TryParse(bookID, out int x))
            {
                foreach (var book in books)
                {
                    if (x == book.BookID)
                    {
                        confirmed = true;
                    }
                }
                if (confirmed)
                {
                    while (run)
                    {
                        var book = bookRepo.SearchID(x);
                        Console.WriteLine("Name ~ Author(blank if empty)");
                        Console.WriteLine($"{book.BookName} ~ {book.Author}");
                        Console.WriteLine("Which you you wish to edit? Please input the number of your option.");
                        Console.WriteLine("1) Name | 2) Author | 3) Cancel");
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                Console.WriteLine("What do you want the new book name to be?");
                                input = Console.ReadLine();
                                bookRepo.EditBookName(x, input);
                                Console.Clear();
                                break;
                            case "2":
                                Console.WriteLine("Who do you want the new author(s) to be?");
                                input = Console.ReadLine();
                                bookRepo.EditAuthor(x, input);
                                Console.Clear();
                                break;
                            case "3":
                                run = false;
                                break;
                            default:
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Sorry, I don't recognize that option. Please select a number from the list.");
                                Console.WriteLine("Press 'enter' to continue.");
                                Console.ReadLine();
                                break;
                        }
                    }

                }
                else
                {
                    Console.WriteLine($"The value {bookID} is not valid. Please try again.");
                    Console.WriteLine("Press 'enter' to continue.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine($"The value {bookID} is not valid. Please try again.");
                Console.WriteLine("Press 'enter' to continue.");
                Console.ReadLine();
            }

        }

        public static void YourLibrary() //The menu for adding, editing, searching for, and deleting entries from your library.
        {
            string input;
            bool run = true;

            while (run)
            {
                Console.Clear();
                Console.WriteLine("Your Library - Please enter the number of the option you would like.");
                Console.WriteLine("1) Add a library entry | 2) Search for an entry");
                Console.WriteLine("3) Return to Main Menu");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //You'll need the ID from Books that you'll want to add. Either make the search section a method that can be suitably called by
                        //these entries or find a way to preserve a book choice globally.
                        //All information that can be added to an entry are optional.
                        break;
                    case "2":
                        //These will edit YourLibrary entries directly, following much the same pattern as search/edit in Books
                        break;
                    case "3":
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

        public static void YourWishlist() //The menu for adding, editing, searching for, deleting, and transitioning entries from your wishlist.
        {
            string input;
            bool run = true;

            while (run)
            {
                Console.Clear();
                Console.WriteLine("Your Wishlist - Please enter the number of the option you would like.");
                Console.WriteLine("1) Add a wishlist entry | 2) Search for an entry");
                Console.WriteLine("3) Return to Main Menu");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":
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

        public static void YourLog() //The menu for starting and stopping timed sessions and tracking pages read.
        {
            string input;
            bool run = true;

            while (run)
            {
                Console.Clear();
                Console.WriteLine("Your Log - Please enter the number of the option you would like.");
                Console.WriteLine("1) Time yourself    | 2) Add an untimed log | 3) Edit a log");
                Console.WriteLine("4) Search for a log | 5) Delete a log       | 6)Return to Main Menu");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    case "5":

                        break;
                    case "6":
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

        public static void YourNotes() //The menu for adding, editing, searching for, and deleting notes.
        {
            string input;
            bool run = true;

            while (run)
            {
                Console.Clear();
                Console.WriteLine("Your Books - Please enter the number of the option you would like.");
                Console.WriteLine("1) Add a note    | 2) Edit a note | 3) Search for a note");
                Console.WriteLine("4) Delete a note | 5) Return to Main Menu");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    case "5":
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
