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



        public RefreshDB(Dictionary<string, int> _hash)
        {
            //CreateConnection = @"Data Source=.\SQLEXPRESS;Integrated security=SSPI;database=master";

            

            //проверяем есть ли директория для базы данных
            CheckPath(pathCatalog);
            //простейшая проверка существования базы
            CheckDB(ExistConnetion);

            HashToDB(_hash);
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

        private void HashToDB(Dictionary<string, int> _hash)
        {

            // ищем поле Words в таблице, название которой соответствует первой букве слова
            foreach (KeyValuePair<string, int> h in _hash)
            {
                string selectDB = "SELECT Count FROM " + h.Key.Substring(0, 1) + " WHERE Word = '" + h.Key + "'";

                string ExistConnetion = @"Data Source=.\SQLEXPRESS;Initial Catalog = MyDatabase;Integrated Security = True";

                using (SqlConnection conn = new SqlConnection(ExistConnetion))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(selectDB, conn);
                    
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        int Count = Convert.ToInt32(reader.GetValue(0));
                        // если значение уже было добавлено ранее добавляем к счетчику слов текущее значение

                        string sqlUpdate = "UPDATE " + h.Key.Substring(0, 1) + " SET Count = " + Convert.ToString(Count + h.Value) +
                            " WHERE Word = '" + h.Key + "'";

                        using (SqlConnection connection = new SqlConnection(ExistConnetion))
                        {
                            connection.Open();

                            SqlCommand commandUpdate = new SqlCommand(sqlUpdate, connection);

                            commandUpdate.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // если значения не существует создаём новую запись в базе
                        string sqlExpression = "INSERT INTO " + h.Key.Substring(0, 1) + " (Word, Count) VALUES ('" + h.Key + "', " + Convert.ToString(h.Value) + ")";
                        Console.WriteLine(sqlExpression);

                        using (SqlConnection connection = new SqlConnection(ExistConnetion))
                        {
                            connection.Open();

                            SqlCommand commandUpdate = new SqlCommand(sqlExpression, connection);

                            commandUpdate.ExecuteNonQuery();
                        }
                    }

                    
                    
                }
            }
        }

    }
}
