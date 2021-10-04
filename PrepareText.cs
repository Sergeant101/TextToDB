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
        private void ParseLine(string lineSource, List <String> WordParce)
        {
            // слова выделяем по пробелам делая проход с начала строки
            // добавим в самый конец пробел чтобы он там точно был
            lineSource = lineSource + " ";

            // нижняя граница длины слова
            int LoLimit = 3;

            // верхняя граница длины слова
            int HiLimit = 20;
                        
            do
            {

                // 1 адрес первого пробела с начала строки
                int AddrSpace       = lineSource.IndexOf(' ');
                // 2 точки
                int AddrDot         = lineSource.IndexOf('.');
                // 3 запятой
                int AddrComma       = lineSource.IndexOf(',');
                // 4 отрывающей скобки
                int AddrOpenPar     = lineSource.IndexOf('(');
                // 5 закрывающей скобки
                int AddrClosePar    = lineSource.IndexOf(')');
                // 6 двоеточия
                int AddrColon       = lineSource.IndexOf(':');
                // 7 точки с запятой
                int AddrSemicolon   = lineSource.IndexOf(';');
                // 8 тире
                int AddrDash        = lineSource.IndexOf('-');
                // 9 обратный слэш
                int AddrBackslach   = lineSource.IndexOf('/');
                // 10 прямой слэш
                int AddrForwardslach = lineSource.IndexOf('\\');
                // 11 восклицательный знак
                int AddrExlamPoint = lineSource.IndexOf('!');
                // 12 вопросительный знак
                int AddrQuestMark = lineSource.IndexOf('?');
                // 13 одинарные ковычки
                int AddrSinglQuotes = lineSource.IndexOf('\'');
                // 14 двойные ковычки
                int AddrDoubleQuotes = lineSource.IndexOf('"');
                // 15 треугольные влево
                int AddrTriangleLeft = lineSource.IndexOf('<');
                // 16 треугольные вправо
                int AddrTriangleRight = lineSource.IndexOf('>');


                // здесь лучше всего было бы вычислить сумму адресов и если они равны -12 
                // завершить цикл (если символ не найден IndexOf возвращает -1)
                // всего признаков, по которым выделяем слова 12
                int cancelCycle = AddrSpace + AddrDot + AddrComma + AddrOpenPar + AddrClosePar +
                    AddrColon + AddrSemicolon + AddrDash + AddrBackslach + AddrForwardslach +
                    AddrExlamPoint + AddrQuestMark;
                // заканчивает парсинг строки если в строке не найдено ни одного
                // символа, который может ограничивать слово
                if (cancelCycle <= -12 )
                {
                    break;
                }

                // проверяем вхождение выделенного слова в заданные границы
                if ((AddrSpace <= LoLimit) || (AddrSpace >= HiLimit))
                {
                    // если полученное слово/символ не входят в границы
                    // удаляем из строки
                    lineSource = lineSource.Remove(0, AddrSpace);
                }
                else
                {
                    // получаем слово из строки
                    string WordFromString = lineSource.Substring(0, AddrSpace);
                    WordParce.Add(WordFromString);
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
                if ((ch >= 'А' && ch <= 'я') || (ch == 'ё') || (ch == 'Ё'))
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
