using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KN_MAX_3.Contol
{
    internal class Create_proc
    {
        static private readonly string PR_InsertGender = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_Insert_Gender]') AND type in (N'P', N'PC'))
            BEGIN
                EXEC('CREATE PROC PR_Insert_Gender (@Name_Gen VARCHAR(255))
                AS	
                    INSERT INTO GENDER 
                    VALUES (NEWID() , @Name_Gen)')
            END";

        static private readonly string PR_Insert_Class = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_Insert_Class]') AND type in (N'P', N'PC'))
            BEGIN
                EXEC('CREATE PROC PR_Insert_Class (@Guid_Class UNIQUEIDENTIFIER, @Name_Class VARCHAR(255), @MAX_STUDNT INT)
                AS
                    INSERT INTO CLASS 
                    VALUES (@Guid_Class, @Name_Class, @MAX_STUDNT)')
            END";

        static private readonly string PR_Insert_Student = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_Insert_Student]') AND type in (N'P', N'PC'))
            BEGIN
                EXEC('CREATE PROC PR_Insert_Student (@NAME_STU VARCHAR(255), @PHONE VARCHAR(255), @GUID_GEN UNIQUEIDENTIFIER)
                AS
                    INSERT INTO STUDENT
                    VALUES (NEWID(), @NAME_STU, @PHONE, @GUID_GEN)')
            END";

        static private readonly string PR_Insert_Tech = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_Insert_Tech]') AND type in (N'P', N'PC'))
            BEGIN
                EXEC('CREATE PROC PR_Insert_Tech (@NAME_TECH VARCHAR(255), @PHONE VARCHAR(255), @Name_GEN VARCHAR(255))
                AS
                    DECLARE @GUID_GEN UNIQUEIDENTIFIER 
                    SET @GUID_GEN = (SELECT TOP 1 G.ID FROM GENDER AS G WHERE G.KIND = @Name_GEN)
                    
                    INSERT INTO TECH
                    VALUES (NEWID(), @NAME_TECH, @PHONE, @GUID_GEN)')
            END";



        static private readonly string PR_Get_Gender = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_Get_Gender]') AND type in (N'P', N'PC'))
            BEGIN
                EXEC('CREATE PROC PR_Get_Gender
                AS
                    SELECT ID, KIND FROM GENDER')
            END";

        static private readonly string PR_Get_Class = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_Get_Class]') AND type in (N'P', N'PC'))
            BEGIN
                EXEC('CREATE PROC PR_Get_Class
                AS
                    SELECT ID, NAME_CLASS FROM CLASS')
            END";

        static private readonly string PR_Check_Student = @"
            IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_Check_Student]') AND type in (N'P', N'PC'))
            BEGIN
                EXEC('CREATE PROC PR_Check_Student (@NAME_STU VARCHAR(255))
                AS
                    SELECT TOP 1 ID FROM STUDENT WHERE NAME_STU = @NAME_STU')
            END";

        static List<string> procedures = new List<string>
        {
            PR_InsertGender,
            PR_Insert_Class,
            PR_Insert_Tech,
            PR_Get_Gender,
            PR_Get_Class,
            PR_Check_Student
        };

        static public bool ExecuteAllProcedures(string sql_con)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sql_con))
                {
                    conn.Open();

                    foreach (var procQuery in procedures)
                    {
                        using (SqlCommand cmd = new SqlCommand(procQuery, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
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