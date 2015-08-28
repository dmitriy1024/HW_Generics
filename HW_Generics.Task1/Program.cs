using System;

namespace HW_Generics.Task1
{
    class Program
    {
        static void Main(string[] args)
        {   
            var myList = new MyList<int>();

            int cnt = 11;
            for (int i = 0; i < cnt; i++)
            {
                myList.Add(i);
            }

            Console.WriteLine("List of elements: ");
            foreach (var item in myList)
            {
                Console.Write("{0}  ", item);
            }
            Console.WriteLine("| Count = {0}", myList.Count);

            myList.RemoveAt(5);
            myList.RemoveAt(5);
            myList.RemoveAt(5);

            Console.WriteLine("\nList of elements with removed elements: ");
            foreach (var item in myList)
            {
                Console.Write("{0}  ", item);
            }
            Console.WriteLine("| Count = {0}", myList.Count);

            Console.WriteLine("\nElement with index = 3:  {0}", myList[3]);

            Console.ReadKey();
        }
    }
}
