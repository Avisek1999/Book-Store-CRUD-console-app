﻿using System;
using System.Text;
using System.Data.SqlClient;
using static BookStoreOOP.DB;

namespace BookStoreOOP
{
    class Login
    {
        private static string userName, passWord;

        public static void GetLoginInfo()
        {
            Console.Write("\nUSERNAME: ");
            userName = Console.ReadLine();
            Console.Write("PASSWORD: ");
            passWord = ReadLineMasked();
        }

        public static bool IsLoggedIn()
        {
            OpenConnection();
            string sql = "SELECT TOP 1 1 FROM tblLogin WHERE username = '" + userName + 
                "' AND password = '" + passWord + "'";
            SqlDataReader reader = DataReader(sql);
            if(reader.HasRows)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        private static string ReadLineMasked(char mask = '*')
        {
            var sb = new StringBuilder();
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    sb.Append(keyInfo.KeyChar);
                    Console.Write(mask);
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);

                    if (Console.CursorLeft == 0)
                    {
                        Console.SetCursorPosition(Console.BufferWidth - 1, Console.CursorTop - 1);
                        Console.Write(' ');
                        Console.SetCursorPosition(Console.BufferWidth - 1, Console.CursorTop - 1);
                    }
                    else Console.Write("\b \b");
                }
            }
            Console.WriteLine();
            return sb.ToString();
        }
    }
}
