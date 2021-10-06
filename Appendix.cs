using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TextToDB
{
    class Appendix
    {

        Hashtable testHash = new Hashtable();

        private void one()
        {

            testHash.Add("Возвращает", 5);

            string teststringhash = "нудопустим";

            // проверка есть ли значение в хеш таблице если нет то добавляем
            if (!testHash.ContainsKey(teststringhash))
            {
                testHash.Add(teststringhash, 1);
            }

            //testHash[teststringhash] = 2;

            int value = Convert.ToInt32(testHash["нудопустим"]);
            //testHash["нудопустим"] = value++;

            Console.WriteLine(testHash["нудопустим"].ToString());
            //TestInt.ForEach(delegate(int s){
            //    Console.WriteLine(s);
            //});
        }

    }
}
