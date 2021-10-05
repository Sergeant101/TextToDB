using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TextToDB
{
    class PrepareText
    {
        // Путь к файлу
        private string Path = null;

        public PrepareText(string _path)
        {
            // Получаем путь к файлу для парсинга
            Path = _path;
        }


        // =========================================================================================================
        // Читаем потрочно из файла
        private void PrepareLine()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    // строка для чтения данных из файла
                    string line;

                    int i = 0;

                    // читаем в цикле пока не закончатся строки
                    while ((line = sr.ReadLine()) != null)
                    {

                    }
                }
            }
            finally
            {
                
            }
        }


        // =========================================================================================================
        // Парсим строку
        void ParseLine(string lineSource, List<String> WordParce)
        {
            // слова выделяем делая проход с начала строки
            // добавим в самый конец пробел чтобы он там точно был
            lineSource = lineSource + " ";

            // нижняя граница длины слова
            int LoLimit = 3;

            // верхняя граница длины слова
            int HiLimit = 20;

            // список с позициями разделителей слов
            List<int> posDelimiter = new List<int>(16);

            posDelimiter.ForEach(delegate (int i) {
                posDelimiter.Add(0);
            });

            posDelimiter.ForEach(delegate (int i)
            {
                Console.WriteLine(Convert.ToString(i));
            });


            do
            {
                // бит завершает цикл если не осталось символов в строке
                bool StopLoop = true;

                // ближайший символ, который может ограничивать слово
                int NextDelimiter = 2147483647;

                posDelimiter.Clear();
                // 1 адрес первого пробела с начала строки
                posDelimiter.Insert(0, lineSource.IndexOf(' '));
                // 2 точки
                posDelimiter.Insert(1, lineSource.IndexOf('.'));
                // 3 запятой
                posDelimiter.Insert(2, lineSource.IndexOf(','));
                // 4 отрывающей скобки
                posDelimiter.Insert(3, lineSource.IndexOf('('));
                // 5 закрывающей скобки
                posDelimiter.Insert(4, lineSource.IndexOf(')'));
                // 6 двоеточия
                posDelimiter.Insert(5, lineSource.IndexOf(':'));
                // 7 точки с запятой
                posDelimiter.Insert(6, lineSource.IndexOf(';'));
                // 8 тире
                posDelimiter.Insert(7, lineSource.IndexOf('-'));
                // 9 обратный слэш
                posDelimiter.Insert(8, lineSource.IndexOf('/'));
                // 10 прямой слэш
                posDelimiter.Insert(9, lineSource.IndexOf('\\'));
                // 11 восклицательный знак
                posDelimiter.Insert(10, lineSource.IndexOf('!'));
                // 12 вопросительный знак
                posDelimiter.Insert(11, lineSource.IndexOf('?'));
                // 13 одинарные ковычки
                posDelimiter.Insert(12, lineSource.IndexOf('\''));
                // 14 двойные ковычки
                posDelimiter.Insert(13, lineSource.IndexOf('"'));
                // 15 треугольные влево
                posDelimiter.Insert(14, lineSource.IndexOf('<'));
                // 16 треугольные вправо
                posDelimiter.Insert(15, lineSource.IndexOf('>'));


                // заканчивает парсинг строки если в строке не найдено ни одного
                // символа, который может ограничивать слово 
                // т.е. все позиции делимитеров равны -1
                posDelimiter.ForEach(delegate (int i)
                {
                    if (i > 0)
                    {
                        StopLoop = false;
                    }
                    if ((i < NextDelimiter) && (i >= 0))
                    {
                        NextDelimiter = i;
                    }
                });

                if (StopLoop)
                {
                    break;
                }

                // проверяем вхождение выделенного слова в заданные границы
                if ((NextDelimiter < LoLimit) || (NextDelimiter > HiLimit))
                {
                    // если полученное слово/символ не входят в границы
                    // удаляем из строки
                    lineSource = lineSource.Remove(0, NextDelimiter + 1);
                }
                else
                {
                    // получаем слово из строки
                    string WordFromString = lineSource.Substring(0, NextDelimiter);
                    // обрезаем по делимитер
                    lineSource = lineSource.Remove(0, NextDelimiter + 1);
                    // делаем все прописными и в список
                    WordParce.Add(WordFromString.ToLower());
                }

            } while (true);
        }


        // =========================================================================================================
        // Проверяем чтобы слова состояли только из русских и английских символов
        // пока отложим на перспективу !!!
        private bool CheckWord(string sourceWord)
        {

            bool CharRus = true;

            // делаем проход по кирилице, если всё ок оставляем
            // в маркере true
            foreach (char ch in sourceWord)
            {
                if ((ch >= 'а' && ch <= 'я') || (ch == 'ё') || (ch == 'Ё'))
                {
                    
                }
                else
                {
                    CharRus = false;
                    break;
                }
            }

            return true;
        }


    }
}
