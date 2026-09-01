using KN_MAX_3.Contol;
using System;
using System.Data;
using System.Data.SqlClient;

namespace KN_MAX_3.SQL
{
    internal class CheackData
    {
        public model m_model;

        public CheackData()
        {
            if (string.IsNullOrEmpty(SQL_DO_IT.Sql_conn))
            {
                SQL_DO_IT.Conntion_now();
                SQL_DO_IT.GetCon();
            }
        }

        public bool IsNameExist(string Name_stu)
        {
            try
            {
                if (!SQL_DO_IT.OpenConntion()) return false;

                using (SqlCommand cmd = new SqlCommand("PR_Check_Student", SQL_DO_IT.CON_all))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NAME_STU", Name_stu);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        m_model = new model
                        {
                            ID = Guid.Parse(result.ToString())
                        };
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                SQL_DO_IT.CloseConntion();
            }

            return false;
        }
    }
}