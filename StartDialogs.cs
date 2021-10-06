using System;
using System.Collections.Generic;
using System.Text;

namespace TextToDB
{
    class StartDialogs
    {
        private string Path = null;

        // класс для проверки txt файла
        CheckFile checker = null;

        private bool FilePassChek;

        // =========================================================================================================
        // Приглашение к выбору файла
        public void Hello()
        {
            Console.WriteLine("\tСойдайте текстовый файл для загрузки в базу в папке " + @"С:\Temp\Example.txt" + " и нажмите Enter\r\n");
            Console.WriteLine("\tили введите путь:\r\n");

            Path = Convert.ToString(Console.ReadLine());
            Console.WriteLine("\r\n");
        }


        // =========================================================================================================
        // проверка файла
        public void Check()
        {
            // если задан путь к файлу берём его, иначе по умолчанию из C:\Test\Example.txt
            // можно было бы проверку на наличие расширения .txt сделать если вдруг не указан !!!
            if (Path != "")
            {
                checker = new CheckFile(Path);
            }
            else
            {
                checker = new CheckFile();
            }

            // файл не прошел проверку на существование
            if (!checker.IsExist)
            {
                Console.WriteLine("\tФайл не найден");
            }

            // файл не прошел проверку на размер
            if (checker.IsExist && !checker.IsLessThan100)
            {
                Console.WriteLine("\tФайл более 100 Мбайт");
            }

            // файл не прошел проверку на кодировку
            if (checker.IsLessThan100 && !checker.IsFileUTF8)
            {
                Console.WriteLine("\tФайл не сохранён в формате UTF-8");
            }

            // C файлом всё норм
            FilePassChek = false;
            if (checker.IsExist && checker.IsLessThan100 && checker.IsFileUTF8)
            {
                FilePassChek = true;
                Console.WriteLine("\tФайл прошел проверку.");
            }
        }


        // =========================================================================================================
        // Возвращаем путь к файлу
        public string GetPath
        {
            get
            {
                return checker.GetPath;
            }
        }


        // =========================================================================================================
        // Возвращаем признак прохождения проверки
        public bool IsFileCkeck
        {
            get
            {
                return FilePassChek;
            }
        }

    }
}
