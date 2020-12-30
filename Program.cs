using System;
using static System.Console;
using static BookStoreOOP.Book;
using static BookStoreOOP.Strings;
using static BookStoreOOP.Login;

namespace BookStoreOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            uint count = 0;
            WriteLine(titleString);
            WriteLine("Please Login:");
            while(count <= 2)
            {
                GetLoginInfo();
                if (IsLoggedIn())
                {
                    Clear();
                    break;
                }
                else
                {
                    if (count == 2)
                    {
                        ForegroundColor = ConsoleColor.Red;
                        Write("Too many failed attempts....");
                        Environment.Exit(0);
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Invalid credentials. Try again....");
                        ResetColor();
                        count++;
                    }
                }
            }
          
        jump3:
            WriteLine(titleString);
        jump1:
            WriteLine(displayOperations);
        jump0:
            Write("Enter your operation: ");

            uint op1 = Convert.ToUInt16(ReadLine());

            switch (op1)
            {
                case 1:
                    WriteLine("\nADD BOOK:");
                    AddBook();
                    goto jump1;
                case 2:
                    WriteLine("\nDELETE BOOK: ");
                jump2:
                    WriteLine(displayOperations1);
                    Write("Enter your operation: ");
                    uint op2 = Convert.ToUInt16(ReadLine());
                    switch (op2)
                    {
                        case 1:
                            WriteLine("\nDELETE BOOK BY ID:\n");
                            DeleteBookByID(GetBookID());
                            goto jump2;
                        case 2:
                            WriteLine("\nDELETE BOOK BY TITLE:\n");
                            DeleteBookByTitle(GetBookTitle());
                            goto jump2;
                        case 3:
                            goto jump1;
                        default:
                            WriteLine("Invalid opearation. Enter again....");
                            goto jump2;
                    }
                case 3:
                    WriteLine("\nBOOK DETAIL: ");
                    GetBookDetails(GetBookID());
                    goto jump1;
                case 4:
                    WriteLine("\nBOOK COUNT: ");
                    ShowBookCount();
                    goto jump1;
                case 5:
                    ShowAllBooks();
                    goto jump1;
                case 7:
                    Clear();
                    goto jump3;
                case 6:
                    WriteLine("\nUPDATE BOOK RECORD:\n");
                    UpdateBookByID(GetBookID());
                    goto jump1;
                case 8:
                    WriteLine("Exiting program....");
                    break;
                default:
                    WriteLine("Invalid opearation. Enter again....");
                    goto jump0;
            }

        }

    }
}
