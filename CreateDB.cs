using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace TextToDB
{
    class CreateDB
    {

        public CreateDB()
        {
            createDB();          
        }


        private void createDB()
        {
            Console.WriteLine("\tСоздание базы данных.");

            // Строка для создания таблиц базы данных по буквам
            string source_abc = "абвгдеёжзийклмнопрстуфхцчшщэюяabcdefghijklmnpqrstuvwxyz";

            /*
            string BeginTable = "CREATE TABLE a" +
                "(id CHAR(1) CONSTRAINT PKeyid PRIMARY KEY,"+
                "Count INT)";
            */

            string connection = @"Data Source=.\SQLEXPRESS;Integrated security=True;database=master";
            string existConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog = MyDatabase;Integrated Security = True";

            string str = "CREATE DATABASE MyDatabase ON PRIMARY " +
                "(NAME = MyDatabase_Data, " +
                "FILENAME = 'C:\\Temp\\MyDatabaseData.mdf', " +
                "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
                "LOG ON (NAME = MyDatabase_Log, " +
                "FILENAME = 'C:\\Temp\\MyDatabaseLog.ldf', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)";

            // создание базы данных
            using(SqlConnection myConn = new SqlConnection(connection))
            {
                SqlCommand myCommand = new SqlCommand(str, myConn);

                myConn.Open();
                myCommand.ExecuteNonQuery();
                myConn.Close();
            }

/*
            string BeginTable = "CREATE TABLE " + chTable +
                       "(id INT CONSTRAINT PKeyid" + chTable + " PRIMARY KEY," +
                       "Word NCHAR(20)," + "Count INT)";

*/

            //создание таблиц базы данных
            using (SqlConnection ExistDB = new SqlConnection(existConnection))
            {

                foreach (char chTable in source_abc)
                {

                    string BeginTable = "CREATE TABLE " + chTable +
                       "(id INT IDENTITY(1,1) PRIMARY KEY," +
                       "Word NCHAR(20)," + "Count INT)";

                    // создание таблиц

                    SqlCommand CreatTable = new SqlCommand(BeginTable, ExistDB);

                    ExistDB.Open();
                    CreatTable.ExecuteNonQuery();
                    ExistDB.Close();
                }
            }
            

            Console.WriteLine("\tБаза данных создана.");

        }

    }
}
