using System;
using System.Data.SqlClient;
using static BookStoreOOP.Strings;

namespace BookStoreOOP
{
    public class DB
    {
        static SqlConnection conn;

        public static void OpenConnection()
        {
            conn = new SqlConnection(connStr);
            conn.Open();
        }

        public static void CloseConnection()
        {
            conn.Close();
        }

        public static int ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, conn);
            int ctr = cmd.ExecuteNonQuery();
            return ctr;
        }

        public static int CountRecords()
        {
            OpenConnection();
            string sql = "SELECT COUNT(*) FROM tblBook";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int recordCount = Convert.ToInt32(cmd.ExecuteScalar());
            CloseConnection();
            return recordCount;
        }

        public static SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public static bool CheckPkExists(uint pk)
        {
            OpenConnection();
            string sql = "SELECT TOP 1 1 FROM tblBook WHERE Id = '" + pk + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }
    }
}
