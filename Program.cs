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

            Console.WriteLine(s);
            // /тест удалить



            // Диалоговое окно
            StartDialogs begginTxtToDB = new StartDialogs();

            // Парсинг слов из текста
            PrepareText prepareText;

            // Обновление данных базы данных
            RefreshDB refreshDB = null;

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


                foreach (KeyValuePair<string, int> show in Hash)
                {
                    Console.WriteLine(show.Key + " " + Convert.ToString(show.Value));
                };

                refreshDB = new RefreshDB(Hash);

            }



            // =========================================================================================================
            // тестирование удалить

            string selectDB = "SELECT Count FROM t WHERE Word = 'tommi'";

            string ExistConnetion = @"Data Source=.\SQLEXPRESS;Initial Catalog = MyDatabase;Integrated Security = True";

            using (SqlConnection conn = new SqlConnection(ExistConnetion))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(selectDB, conn);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    int Count = Convert.ToInt32(reader.GetValue(0));
                    if (Count > 0)
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("None");
                    }
                    Count++;
                    //object word = reader.GetValue(1);
                    //object count = reader.GetValue(2);
                    Console.WriteLine(Count);
                }
            }

        }
    }
}
