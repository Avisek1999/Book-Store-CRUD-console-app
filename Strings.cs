using System;

namespace BookStoreOOP
{
    class Strings
    {

        public static readonly string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BookStoreDB;Integrated Security=True";

        public static string titleString = "\t\t\t\t..........Book Management System..........\n";

        public static string displayOperations = "Operations:\n[1] Add new book\t\t\t[2] Delete book \t\t" +
                                                 "[3] Book details by ID\n[4] Show no. of available books " + 
                                                 "\t[5] Show all books\t\t[6] Update book by ID\n[7] Clear Screen" +
                                                 "\t\t\t[8] Exit Program\n";

        public static string displayOperations1 = "[1] Delete book by ID\t[2] Delete book by Title\t[3] Cancel Operation\n";
    }
}
