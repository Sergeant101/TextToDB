using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TextToDB
{
    class RefreshDB
    {
        // Путь к файлам базы данных по умолчанию
        private string pathCatalog = @"C:\Temp";

        // Строка для создания таблиц базы данных по буквам
        private string source_abc = "абвгдеёжзийклмнопрстуфхцчшщэюяabcdefghijklmnpqrstuvwxyz";

        private string CreateConnection = null;
        private string ExistConnetion = null;

        public RefreshDB(Dictionary<string, int> _hash)
        {
            CreateConnection = @"Data Source=.\SQLEXPRESS;Integrated security=SSPI;database=master";
            ExistConnetion = @"Data Source=.\SQLEXPRESS;Initial Catalog = MyDatabase;Integrated Security = True";

            //проверяем есть ли директория для базы данных
            CheckPath();

        }


        // чисто каталог есть нет создаём
        private void CheckPath()
        {
            if (!Directory.Exists(pathCatalog))
            {
                Directory.CreateDirectory(pathCatalog);
            }
        }



    }
}
