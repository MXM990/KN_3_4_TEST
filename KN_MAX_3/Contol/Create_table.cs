using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KN_MAX_3.Contol
{
    internal class Create_Tables
    {
        static private readonly string Table_Gender = @"
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'GENDER')
            BEGIN
                CREATE TABLE GENDER (
                    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                    KIND VARCHAR(255) NOT NULL
                )
            END;";

        static private readonly string Table_Class = @"
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'CLASS')
            BEGIN
                CREATE TABLE CLASS (
                    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                    NAME_CLASS VARCHAR(255) NOT NULL,
                    MAX_STUDNT INT NOT NULL
                )
            END;";

        static private readonly string Table_Student = @"
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'STUDENT')
            BEGIN
                CREATE TABLE STUDENT (
                    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                    NAME_STU VARCHAR(255) NOT NULL,
                    PHONE VARCHAR(255),
                    GUID_GEN UNIQUEIDENTIFIER,
                    CONSTRAINT FK_STUDENT_GENDER FOREIGN KEY (GUID_GEN) REFERENCES GENDER(ID) 
                )
            END;";

        static private readonly string Table_Tech = @"
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TECH')
            BEGIN
                CREATE TABLE TECH (
                    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                    NAME_TECH VARCHAR(255) NOT NULL,
                    PHONE VARCHAR(255),
                    GUID_GEN UNIQUEIDENTIFIER,
                    CONSTRAINT FK_TECH_GENDER FOREIGN KEY (GUID_GEN) REFERENCES GENDER(ID) 
                )
            END;";

        static private readonly string Table_STU_CLASS = @"
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'STU_CLASS')
            BEGIN
                CREATE TABLE STU_CLASS (
                    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                    GUID_CLASS UNIQUEIDENTIFIER NOT NULL,
                    GUID_STU UNIQUEIDENTIFIER NOT NULL,
                    CONSTRAINT FK_STUCLASS_CLASS FOREIGN KEY (GUID_CLASS) REFERENCES CLASS(ID) ON DELETE CASCADE,
                    CONSTRAINT FK_STUCLASS_STUDENT FOREIGN KEY (GUID_STU) REFERENCES STUDENT(ID) ON DELETE CASCADE
                )
            END;";

        static private readonly string Table_TECH_CLASS = @"
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TECH_CLASS')
            BEGIN
                CREATE TABLE TECH_CLASS (
                    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                    GUID_CLASS UNIQUEIDENTIFIER NOT NULL,
                    GUID_TECH UNIQUEIDENTIFIER NOT NULL,
                    CONSTRAINT FK_TECHCLASS_CLASS FOREIGN KEY (GUID_CLASS) REFERENCES CLASS(ID) ON DELETE CASCADE,
                    CONSTRAINT FK_TECHCLASS_TECH FOREIGN KEY (GUID_TECH) REFERENCES TECH(ID) ON DELETE CASCADE
                )
            END;";

        static List<string> tablesQueries = new List<string>
        {
            Table_Gender,
            Table_Class,
            Table_Student,
            Table_Tech,
            Table_STU_CLASS,
            Table_TECH_CLASS
        };

        public static bool ExecuteAllTables(string sql_con)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sql_con))
                {
                    conn.Open();

                    foreach (var query in tablesQueries)
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
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