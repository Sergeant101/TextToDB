﻿using System;
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

            TestInt.ForEach(delegate(int s){
                Console.WriteLine(Convert.ToString(s) + "\r\n");
            });

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

                do
                {
                    // бит завершает цикл если не осталось символов в строке
                    bool StopLoop = true;

                    // ближайший символ, который может ограничивать слово
                    int NextDelimiter = 2147483647;

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

                    /*
                    // заканчивает парсинг строки если в строке не найдено ни одного
                    // символа, который может ограничивать слово 
                    // т.е. все позиции делимитеров равны -1
                    foreach (int i in posDelimiter)
                    {
                        if (i > 0)
                        {
                            StopLoop = false;
                            // по пути поищем ближайший разделитель слов
                            if (i < NextDelimiter)
                            {
                                NextDelimiter = i;
                            }
                        }
                    }

                    if (StopLoop)
                    {
                        break;
                    }


                    // проверяем вхождение выделенного слова в заданные границы
                    if ((NextDelimiter <= LoLimit) || (NextDelimiter >= HiLimit))
                    {
                        // если полученное слово/символ не входят в границы
                        // удаляем из строки
                        lineSource = lineSource.Remove(0, NextDelimiter);
                    }
                    else
                    {
                        // получаем слово из строки
                        string WordFromString = lineSource.Substring(0, NextDelimiter);
                        // делаем все прописными
                        WordParce.Add(WordFromString.ToLower());
                    }

                } while (true);
            }

        }
    }
}
