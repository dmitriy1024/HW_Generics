using System;
using System.Collections.Generic;

namespace HW_Generics.Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            var rand = new Random();

            for (int i = 0; i < 20; i++)
            {
                list.Add(rand.Next(100));
            }

            Console.WriteLine("Collection: ");
            foreach (var item in list)
            {
                Console.Write("{0,-4}", item);
            }

            Sorting.SelectionSort(list);

            Console.WriteLine("\n\nSorted collection: ");
            foreach (var item in list)
            {
                Console.Write("{0,-4}", item);
            }

            Console.ReadKey();
        }
    }

    static class Sorting
    {
        public static void SelectionSort<T>(IList<T> coll) where T : IComparable<T>
        {
            for (int i = 0; i < coll.Count; i++)
            {
                int min = i;
                for (int j = i + 1; j < coll.Count; j++)
                {
                    if(coll[min].CompareTo(coll[j]) < 0)
                    {
                        min = j;
                    }
                }

                T tmp = coll[i];
                coll[i] = coll[min];
                coll[min] = tmp;
            }
        }
    }
}
