using System;
using System.IO;

namespace TextToDB
{
    class Program
    {


        class PrepareData
        {

        }

        static void Main(string[] args)
        {

            // Путь к файлу
            string Path = null;

            // Диалоговое окно
            StartDialogs begginTxtToDB = new StartDialogs();

            begginTxtToDB.Hello();
            begginTxtToDB.Check();


            // =========================================================================================================
            // тестирование удалить

            string test = "Возвращает индекс с отсчетом! от нуля первого вхождения значения указанной строки в данном экземпляре. Поиск начинается с указанной позиции знака; проверяется заданное количество позиций.";

            Console.WriteLine(test.Substring(0, (test.IndexOf('!'))));

            char testChar = 'a';



        }
    }
}
