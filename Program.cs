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

            Dictionary<string, int> Hash = new Dictionary<string, int>();

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

                refreshDB = new RefreshDB(Hash);

                Console.WriteLine("\tПрограмма завершила работу");
            }
                         
            

        }
    }
}
