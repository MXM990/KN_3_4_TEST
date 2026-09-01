using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace KN_MAX_3.Contol
{
    internal class DatabaseInitializer
    {
        public static string AppConnectionString { get; private set; }

        private static readonly string appConnFilePath = "AppConnection.txt";

        public static bool CreateFullStructure(string dbName)
        {
            try
            {

                if (!Create_DB.CreateDatabase(dbName))
                {
                    return false;
                }

                AppConnectionString = @"Server =.\MXM ;Database = " + dbName+" ; User Id = sa ; Password = 123;";


                File.WriteAllText(appConnFilePath, AppConnectionString);

                if (!Create_Tables.ExecuteAllTables(AppConnectionString ))
                {
                    return false;
                }

                if (!Create_proc.ExecuteAllProcedures(AppConnectionString))
                {
                    return false;
                }
                SQL_DO_IT.Conntion_now();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}