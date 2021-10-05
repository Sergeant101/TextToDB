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

            List<string> TestList = new List<string>();
            List<int> TestInt = new List<int>(3) { 1, 2, 3 };

            // Диалоговое окно
            StartDialogs begginTxtToDB = new StartDialogs();

            begginTxtToDB.Hello();
            begginTxtToDB.Check();


            // =========================================================================================================
            // тестирование удалить

            string test = "Возвращает индекс с ' отсчетом от нуля первого вхождения значения указанной строки в данном экземпляре. Поиск начинается с указанной позиции знака; проверяется заданное количество позиций.";

            //ParseLine(test, TestList);

            foreach(int i in TestInt)
            {
                Console.WriteLine(Convert.ToString(TestInt) + "\r\n");
            }


        }
    }
}
