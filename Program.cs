using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
            // /тест удалить


            // Диалоговое окно
            StartDialogs begginTxtToDB = new StartDialogs();

            // Парсинг слов из текста
            PrepareText prepareText;

            // приглашение к вводу данных и диалоги
            begginTxtToDB.Hello();
            // проверка файла
            begginTxtToDB.Check();

            // проверка файла прошла успешно
            if (begginTxtToDB.IsFileCkeck)
            {
                // извлекаем данные
                prepareText = new PrepareText(begginTxtToDB.GetPath);    
                
                if (prepareText.IsComplete)
                {
                    Hash = prepareText.GetHash;
                }
            }

            
            // =========================================================================================================
            // тестирование удалить


            foreach(KeyValuePair<string, int> show in Hash)
            {
                Console.WriteLine(show.Key + " " + Convert.ToString(show.Value));
            };


 

        }
    }
}
