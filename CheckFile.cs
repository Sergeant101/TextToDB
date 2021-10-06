using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TextToDB
{
    class CheckFile
    {
        // Путь к файлу
        private string Path = null;

        // Признак существования файла
        private bool ExistFile = false;

        // Признак файла меньше 100 МБ
        private bool LessThan100 = false;

        // Признак кодировки UTF-8
        private bool FileUTF8 = false;


        public CheckFile()
        {
            Path = @"C:\Temp\Example.txt";

            ProcCheckFile();
        }

        public CheckFile(string _Path)
        {
            Path = _Path;

            ProcCheckFile();
        }


        // =========================================================================================================
        // Проводим процедуру проверки файлов
        private void ProcCheckFile()
        {
            ExistFile = FileExist();

            if (ExistFile)
            {
                // если файл существует проверяем размер
                LessThan100 = FileSize();
                // проверяем кодировку
                FileUTF8 = FileEncoding();
            }
        }


        // =========================================================================================================
        // Проверяем существует ли файл вообще
        private bool FileExist()
        {
            if (File.Exists(Path))
            {
                return true;
            }
            
            return false;
        }


        // =========================================================================================================
        // Проверяем размер
        private bool FileSize()
        {
            FileInfo someFileInfo = new FileInfo(Path);
            long fileByteSize = someFileInfo.Length;

            // файл должен быть меньше 100 МБ, перевод из рассчёта 1 МБ = 1024 КБ, 1 КБ = 1024 Б  
            if (fileByteSize < 104857600)
            {
                return true;
            }

            return false;
        }


        // =========================================================================================================
        // Проверяем кодировку
        private bool FileEncoding()
        {
            StreamReader streamEncoding = new StreamReader(Path, Encoding.UTF8, true);


            // дефолтная функция определения кодировки работает косячно
            if (streamEncoding.CurrentEncoding == Encoding.UTF8)
            {

                return true;
                // Задолбало потом разберусь !!!
                //return HasBOM(streamEncoding);
            }

            return false;
        }


        // =========================================================================================================
        // Проверка BOM
        private bool HasBOM(StreamReader fs)
        {
            bool flag = false;
            try
            {
                char[] b = new char[3];
                int nBytesRead = fs.Read(b, 0, 3);

                if (nBytesRead == 3 &&
                    b[0] == 0xEF &&
                    b[1] == 0xBB &&
                    b[2] == 0xBF)
                    flag = true;                
            }
            catch 
            {
                // здесь просто как заглушка: если ошибка при чтении то принимаем что не UTF8
                return false;
            }
            return flag;
        }


        // =========================================================================================================
        // Признак существования файла
        public bool IsExist
        {
            get
            {
                return ExistFile;
            }
        }


        // =========================================================================================================
        // Признак файла меньше 100 МБ
        public bool IsLessThan100
        {
            get
            {
                return LessThan100;
            }
        }


        // =========================================================================================================
        // Признак файла с кодировкой UTF8
        public bool IsFileUTF8
        {
            get
            {
                return FileUTF8;
            }
        }


        // =========================================================================================================
        // Возвращаем путь к файлу
        public string GetPath
        {
            get
            {
                return Path;
            }
        }
    }
}
