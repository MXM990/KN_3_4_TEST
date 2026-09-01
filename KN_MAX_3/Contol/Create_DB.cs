using System;
using System.Data.SqlClient;
using System.IO;

namespace KN_MAX_3.Contol
{
    internal class Create_DB
    {
        static private readonly string filePath = "Contol\\SQL Conntion.txt";


        static private string GetConnectionString()
        {
            string connString = File.ReadAllText(filePath);
            return connString;
        }

    
        public static bool CreateDatabase(string dbName)
        {
            
            string createDbQuery = $@"
                IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '{dbName}')
                BEGIN
                    CREATE DATABASE [{dbName}];
                END;";

            try
            {
                string connectionString = GetConnectionString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(createDbQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                return true; 
            }
            catch 
            {
                return false;
            }
        }
    }
}