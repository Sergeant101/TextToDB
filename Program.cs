using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace TextToDB
{
    class Program
    {

        static void Main(string[] args)
        {
            // Путь к файлу
            string Path = null;

            List<string> teststring = new List<string>();
            Hashtable testHash = new Hashtable();

            // Диалоговое окно
            StartDialogs begginTxtToDB = new StartDialogs();

            begginTxtToDB.Hello();
            begginTxtToDB.Check();


            // =========================================================================================================
            // тестирование удалить

            string test = "Возвращает индекс отсчетом от нуля первого вхождения значения указанной строки в данном экземпляре. Поиск начинается с указанной позиции знака; проверяется заданное количество позиций.";

            ParseLine(test, teststring);

            testHash.Add("Возвращает", 5);

            string teststringhash = "нудопустим";

            // проверка есть ли значение в хеш таблице если нет то добавляем
            if (!testHash.ContainsKey(teststringhash))
            {
                testHash.Add(teststringhash, 1);
            }

            testHash[teststringhash] = 2;

            Console.WriteLine(testHash["нудопустим"].ToString());
            //TestInt.ForEach(delegate(int s){
            //    Console.WriteLine(s);
            //});

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

                    // получаем позиции разделителей строк
                    GetDelimiterPos(lineSource, posDelimiter);

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


            // возвращаем позиции ограничителей слова
            void GetDelimiterPos(string WorkLine, List<int> Delimiters)
            {
                Delimiters.Clear();
                // 1 адрес первого пробела с начала строки
                Delimiters.Insert(0, WorkLine.IndexOf(' '));
                // 2 точки
                Delimiters.Insert(1, WorkLine.IndexOf('.'));
                // 3 запятой
                Delimiters.Insert(2, WorkLine.IndexOf(','));
                // 4 отрывающей скобки
                Delimiters.Insert(3, WorkLine.IndexOf('('));
                // 5 закрывающей скобки
                Delimiters.Insert(4, WorkLine.IndexOf(')'));
                // 6 двоеточия
                Delimiters.Insert(5, WorkLine.IndexOf(':'));
                // 7 точки с запятой
                Delimiters.Insert(6, WorkLine.IndexOf(';'));
                // 8 тире
                Delimiters.Insert(7, WorkLine.IndexOf('-'));
                // 9 обратный слэш
                Delimiters.Insert(8, WorkLine.IndexOf('/'));
                // 10 прямой слэш
                Delimiters.Insert(9, WorkLine.IndexOf('\\'));
                // 11 восклицательный знак
                Delimiters.Insert(10, WorkLine.IndexOf('!'));
                // 12 вопросительный знак
                Delimiters.Insert(11, WorkLine.IndexOf('?'));
                // 13 одинарные ковычки
                Delimiters.Insert(12, WorkLine.IndexOf('\''));
                // 14 двойные ковычки
                Delimiters.Insert(13, WorkLine.IndexOf('"'));
                // 15 треугольные влево
                Delimiters.Insert(14, WorkLine.IndexOf('<'));
                // 16 треугольные вправо
                Delimiters.Insert(15, WorkLine.IndexOf('>'));
            }

            void HashingWord(List<string> ToHash)
            {
                ToHash.ForEach(delegate (string wordToHash)
                {

                });
            }

        }
    }
}
