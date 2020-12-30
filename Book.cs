using ConsoleTables;
using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Data.Linq;
using static BookStoreOOP.DB;

namespace BookStoreOOP
{
    public class Book
    {
        private static string bookTitle, bookAuthor, bookGenre, bookISBN_str;
        private static ulong bookISBN;
        private static decimal bookPrice;

        private static void InputBookInfo()
        {

            Console.Write("Enter Book Title: ");
            bookTitle = Console.ReadLine().ToLower();
            Console.Write("Enter Author name: ");
            bookAuthor = Console.ReadLine().ToLower();
            Console.Write("Enter ISBN Number: ");
            bookISBN = Convert.ToUInt64(Console.ReadLine());
            bookISBN_str = bookISBN.ToString();
            Console.Write("Enter Price: ");
            bookPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter genre: ");
            bookGenre = Console.ReadLine().ToLower();
        }

        public static void AddBook()
        {
            OpenConnection();
            InputBookInfo();
            string addBookQuery = "insert into tblBook (title, author, isbn ,price, genre) " +
                         "values('" + bookTitle + "', '" + bookAuthor + "', " +
                         "'" + bookISBN_str + "', '" + bookPrice + "', '" + bookGenre + "')";
            int ctr = ExecuteQueries(addBookQuery);
            if(ctr > 0)
                Console.WriteLine("\nNew book added....\n");
            CloseConnection();
        }

        public static void DeleteBookByID(uint bookID)
        {
            OpenConnection();
            string deleteBookbyId = "delete from tblBook where Id = '" + bookID + "'";
            int ctr = ExecuteQueries(deleteBookbyId);
            if(ctr > 0)
                Console.WriteLine("\nBook id: {0} deleted....\n", bookID);
            else
                Console.WriteLine("\nBook id: {0} available in the database....\n", bookID);
            CloseConnection();
        }

        public static void DeleteBookByTitle(string bookTitle)
        {
            OpenConnection();
            string deleteBookbyTitle = "delete from tblBook where title = '" + bookTitle.ToLower() + "'";
            int ctr = ExecuteQueries(deleteBookbyTitle);
            if (ctr > 0)
                Console.WriteLine("\nNo. of books deleted: {0}\n", ctr.ToString());
            else
                Console.WriteLine("\nBook title: '{0}' not available in the database....\n", bookTitle);
            CloseConnection();
        }

        public static void ShowBookCount()
        {
            Console.WriteLine("Available books: {0}\n", CountRecords().ToString());
        }

        public static void ShowAllBooks()
        {
            OpenConnection();
            Console.WriteLine("\nSHOWING ALL BOOKS:\n");
            string[] val;
            var table = new ConsoleTable("ID", "Title", "Author", "Price");
            string showAllBooks = "select id, title, author, price from tblBook";
            SqlDataReader reader = DataReader(showAllBooks);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    val = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                        val[i] = Convert.ToString(reader.GetValue(i));
                    table.AddRow(val[0], val[1], val[2], "$" + val[3].ToString());
                }
                table.Write();
                Console.WriteLine();
            }
            else
                Console.WriteLine("No Records available in the database....\n");
            CloseConnection();
        }

        public static void UpdateBookByID(uint bookID)
        {
            if(CheckPkExists(bookID))
            {
                GetBookDetails(bookID);
                InputBookInfo();
                OpenConnection();
                string updateBookbyId = "update tblBook set title = '" + bookTitle + "', author = " +
                             "'" + bookAuthor + "', isbn = '" + bookISBN + "', price = " +
                             "'" + bookPrice + "', genre = '" + bookGenre + "' where Id = '" + bookID + "'";
                ExecuteQueries(updateBookbyId);
                Console.WriteLine("\nBook id: {0} updated sucessfully....\n", bookID);
                CloseConnection();
            }
            else
                Console.WriteLine("\nBook id: {0} does not exist in database....\n", bookID);
        }

        public static void GetBookDetails(uint bookID)
        {
            OpenConnection();
            string[] val;
            string getBookDetails = "SELECT title, author, isbn, price, genre FROM tblBook where Id = " +
                         "'" + bookID + "'";
            SqlDataReader reader = DataReader(getBookDetails);
            if (reader.HasRows)
            {
                val = new string[reader.FieldCount];
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        val[i] = Convert.ToString(reader.GetValue(i));
                }
                Console.WriteLine("\nTitle: {0}", val[0]);
                Console.WriteLine("Author: {0}", val[1]);
                Console.WriteLine("ISBN No.: {0}", val[2]);
                Console.WriteLine("Price: ${0}", val[3]);
                Console.WriteLine("Genre: {0}\n", val[4]);
            }
            else
                Console.WriteLine("\nBook id: {0} not availabe in the database....\n", bookID);
            CloseConnection();
        }

        public static uint GetBookID()
        {
            Console.Write("Enter ID: ");
            uint bookID = Convert.ToUInt16(Console.ReadLine());
            return bookID;
        }

        public static string GetBookTitle()
        {
            Console.Write("Enter Title: ");
            string bookTitle = Console.ReadLine();
            return bookTitle;
        }

    }
}
