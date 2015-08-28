using System;
using System.Collections.Generic;
using HW_Generics.Task1;

namespace HW_Generics.Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            Console.WriteLine("Array of T received from extension method: ");
            int[] array = list.GetArray();
            foreach (var item in array)
            {
                Console.Write("{0,-3}", item);
            }

            Console.ReadKey();
        }
    }

    static class MyListExt
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            var listForReturn = new List<T>(list.Count);
            foreach (var item in list)
            {
                listForReturn.Add(item);
            }

            return listForReturn.ToArray();
        }
    }
}
