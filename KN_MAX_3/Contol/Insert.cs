using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using KN_MAX_3.Contol;

namespace KN_MAX_3.SQL
{
    internal class Insert
    {
        public Insert()
        {
            if (string.IsNullOrEmpty(SQL_DO_IT.Sql_conn))
            {
                SQL_DO_IT.Conntion_now();
                SQL_DO_IT.GetCon();
            }
        }

        public bool InsertGender(string Name_Of_Type)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Name_Gen", Name_Of_Type)
            };

            return SQL_DO_IT.Exec_proc("PR_Insert_Gender", parameters);
        }

      
        public bool InsertClass(string Name_Class, int max_size)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Guid_Class", Guid.NewGuid()),
                new SqlParameter("@Name_Class", Name_Class),
                new SqlParameter("@MAX_STUDNT", max_size)
            };

            return SQL_DO_IT.Exec_proc("PR_Insert_Class", parameters);
        }

       
        public bool Insertstu(string Name_Stu, string phone, Guid Gr_Guid)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@NAME_STU", Name_Stu),
                new SqlParameter("@PHONE", phone),
                new SqlParameter("@GUID_GEN", Gr_Guid)
            };

            return SQL_DO_IT.Exec_proc("PR_Insert_Student", parameters);
        }

       
        public bool InsertTech(string Name_th, string phone, string Name_Gen)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@NAME_TECH", Name_th),
                new SqlParameter("@PHONE", phone),
                new SqlParameter("@Name_GEN", Name_Gen)
            };

            return SQL_DO_IT.Exec_proc("PR_Insert_Tech", parameters);
        }

        
        public bool InsertStudentInClass(Guid Class_guid, Guid stu_guid)
        {
            try
            {
                if (!SQL_DO_IT.OpenConntion()) return false;

                string Qur_Insert_stu_CLASS = "INSERT INTO STU_CLASS VALUES (NEWID() , @CLASS_GUID_SENDER , @STU_GUID_SENDER)";

                using (SqlCommand cmd = new SqlCommand(Qur_Insert_stu_CLASS, SQL_DO_IT.CON_all))
                {
                    cmd.Parameters.AddWithValue("@CLASS_GUID_SENDER", Class_guid);
                    cmd.Parameters.AddWithValue("@STU_GUID_SENDER", stu_guid);
                    cmd.ExecuteNonQuery();
                    return true;
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
        }

       
        public bool insertTehcNew(Guid id_class, string name_th)
        {
            try
            {
                if (!SQL_DO_IT.OpenConntion()) return false;

                string Quray = @"DECLARE @GUID UNIQUEIDENTIFIER
                                 SET @GUID = (SELECT TOP 1 ID FROM TECH WHERE NAME_TECH = @nameTH)
                                 
                                 IF @GUID IS NOT NULL
                                 BEGIN 
                                     INSERT INTO TECH_CLASS VALUES (NEWID() , @GUIDCLASS , @GUID)
                                 END";

                using (SqlCommand cmd = new SqlCommand(Quray, SQL_DO_IT.CON_all))
                {
                    cmd.Parameters.AddWithValue("@nameTH", name_th);
                    cmd.Parameters.AddWithValue("@GUIDCLASS", id_class);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
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
        }
    }
}