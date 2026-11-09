using MySql.Data.MySqlClient;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;



namespace BookshelfDAL
{
    public class DBConnection
    {
        public static string DBConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Bookshelf;Trusted_Connection=True;TrustServerCertificate=True;";
    
        public static bool TestConnection()
        {
            try
            {
                using var connection = new SqlConnection(DBConnectionString);
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    } 
}
