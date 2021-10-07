using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace TextToDB
{
    class Program
    {

        static void Main(string[] args)
        {
            // Путь к файлу
            string Path = null;


            // тест удалить
            List<string> teststring = new List<string>();

            Dictionary<string, int> Hash = new Dictionary<string, int>();


            string s = RuntimeInformation.FrameworkDescription;
            // /тест удалить



            Console.WriteLine(s);

            // Диалоговое окно
            StartDialogs begginTxtToDB = new StartDialogs();

            // Парсинг слов из текста
            PrepareText prepareText;

            // Работа с базой данных
            RefreshDB refreshDB = new RefreshDB();

            // приглашение к вводу данных и диалоги
            begginTxtToDB.Hello();
            // проверка файла
            begginTxtToDB.Check();

            // проверка файла прошла успешно
            if (begginTxtToDB.IsFileCkeck)
            {
                // извлекаем данные
                prepareText = new PrepareText(begginTxtToDB.GetPath);    
                
                // ждём пока всё извлечётся
                while (true)
                {
                    if (prepareText.IsComplete)
                    {
                        Hash = prepareText.GetHash;
                        break;
                    }
                }

            }


            
            // =========================================================================================================
            // тестирование удалить


            foreach(KeyValuePair<string, int> show in Hash)
            {
                Console.WriteLine(show.Key + " " + Convert.ToString(show.Value));
            };

            
            
            string ExistConnetion = @"Data Source=.\SQLEXPRESS;Initial Catalog = MyDatabase;Integrated Security = True";

            string UpDataDB = "UPDATE MyDatabase SET Count = 2 WHERE id = 2";

            string InsertDB = "INSERT INTO t (Word, Count) VALUES ('tommi', 18)";

            using (SqlConnection conn = new SqlConnection(ExistConnetion))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand sqlCommand = new SqlCommand(InsertDB, conn);
                    sqlCommand.ExecuteNonQuery();
                    conn.Close();
 
                }               
                    
            }
            
            
        }
    }
}
