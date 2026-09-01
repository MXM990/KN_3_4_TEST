using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KN_MAX_3.Contol
{
    internal class SQL_DO_IT
    {
        public static string Sql_conn ;
        public static SqlConnection CON_all;
        
        public static void Conntion_now()
        {
            Sql_conn = File.ReadAllText("AppConnection.txt");
        }
        public static void GetCon()
        {
            CON_all = new SqlConnection(Sql_conn);
        }
        public static bool StringConntionIsNotNull()
        {
            if (CON_all == null)
            {
                GetCon();
            }
            return true;
        }
        public static bool OpenConntion()
        {
            if (StringConntionIsNotNull())
            {
                try
                {
                    CON_all.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static void CloseConntion()
        {
            CON_all.Close();
        }

        public static bool Exec_proc(string procName, List<SqlParameter> parameters)
        {
            if (OpenConntion())
            {
                try
                {
                    using (SqlCommand sqlcmd = new SqlCommand(procName, CON_all))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddRange(parameters.ToArray());
                        sqlcmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch 
                {
                    return false;
                }
                finally
                {
                    CloseConntion();
                }
            }
            else
            {
                return false;
            }
        }
    }
}
