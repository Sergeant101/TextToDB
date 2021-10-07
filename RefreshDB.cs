using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace TextToDB
{
    class RefreshDB
    {

        // Путь к файлам базы данных по умолчанию
        private string pathCatalog = @"C:\Temp";

        // адресс базы, можно было бы искать доступные сервера, но нет времени
        private string ExistConnetion = @"Data Source=.\SQLEXPRESS;Initial Catalog = MyDatabase;Integrated Security = SSPI";

        public RefreshDB()
        {
            //CreateConnection = @"Data Source=.\SQLEXPRESS;Integrated security=SSPI;database=master";
            

            //проверяем есть ли директория для базы данных
            CheckPath(pathCatalog);
            //простейшая проверка существования базы
            CheckDB(ExistConnetion);

        }


        // чисто каталог есть нет создаём
        private void CheckPath(string _path)
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }


        // проверяем наличие базы
        private void CheckDB(string _pathDB)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_pathDB))
            {
                try
                {
                    Console.WriteLine("\tПроверка наличия базы данных");
                    sqlConnection.Open();
                    sqlConnection.Close();
                }
                catch
                {
                    // если не удалось соединиться с базой
                    CreateDB createDB = new CreateDB();
                }
            };
        }



    }
}
