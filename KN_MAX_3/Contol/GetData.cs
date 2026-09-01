using KN_MAX_3.Contol;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KN_MAX_3.SQL
{
    internal class GetData
    {
        public GetData()
        {
            if (string.IsNullOrEmpty(SQL_DO_IT.Sql_conn))
            {
                SQL_DO_IT.Conntion_now();
                SQL_DO_IT.GetCon();
            }
        }

        public void GetGender(List<model> GR_list)
        {
            try
            {
                if (!SQL_DO_IT.OpenConntion()) return;

                using (SqlCommand cmd = new SqlCommand("PR_Get_Gender", SQL_DO_IT.CON_all))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GR_list.Add(new model
                            {
                                ID = Guid.Parse(reader["ID"].ToString()),
                                type = reader["KIND"].ToString()
                            });
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                SQL_DO_IT.CloseConntion();
            }
        }

        public void GetClass(List<model> Cl_list)
        {
            try
            {
                if (!SQL_DO_IT.OpenConntion()) return;

                using (SqlCommand cmd = new SqlCommand("PR_Get_Class", SQL_DO_IT.CON_all))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cl_list.Add(new model
                            {
                                ID = Guid.Parse(reader["ID"].ToString()),
                                Name = reader["NAME_CLASS"].ToString()
                            });
                        }
                    }
                }
            }
            catch
            {
                
            }
            finally
            {
                SQL_DO_IT.CloseConntion();
            }
        }
    }
}