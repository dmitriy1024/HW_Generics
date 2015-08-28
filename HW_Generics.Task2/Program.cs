using System;

namespace HW_Generics.Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var myDict = new MyDictionary<string, string>();

            int cnt = 22;
            for (int i = 0; i < cnt; i++)
            {
                myDict.Add(i.ToString(), Math.Pow(i, 2).ToString());
            }

            string[] keys = myDict.Keys;
            string[] values = myDict.Values;

            Console.WriteLine("Keys (numbers as strings): ");
            for (int i = 0; i < myDict.Count; i++)
                Console.Write("{0,-5}", keys[i]);

            Console.WriteLine("\nValues (numbers in second degree as strings): ");
            for (int i = 0; i < myDict.Count; i++)
                Console.Write("{0,-5}", values[i]);
           
            Console.Write("| Count = {0}", myDict.Count);

            Console.WriteLine();
            for (int i = 15; i < cnt; i++)
            {
                myDict.Remove(i.ToString());
            }


            Console.WriteLine("\n\nSome elements were removed\n");
            keys = myDict.Keys;
            values = myDict.Values;

            Console.WriteLine("Keys (numbers as strings): ");
            for (int i = 0; i < myDict.Count; i++)
                Console.Write("{0,-5}", keys[i]);

            Console.WriteLine("\nValues (numbers in second degree as strings): ");
            for (int i = 0; i < myDict.Count; i++)
                Console.Write("{0,-5}", values[i]);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("| Count = {0}", myDict.Count);
            Console.ResetColor();

            Console.WriteLine("\n\nChanging the element with index = 4");
            
            myDict["4"] = "999";

            keys = myDict.Keys;
            values = myDict.Values;

            Console.WriteLine("\nKeys (numbers as strings): ");
            for (int i = 0; i < myDict.Count; i++)
            {   
                if (keys[i] == "4")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0,-5}", keys[i]);
                    Console.ResetColor();
                }
                else
                    Console.Write("{0,-5}", keys[i]);
            }
                
            Console.WriteLine("\nValues (numbers as strings): ");
            for (int i = 0; i < myDict.Count; i++)
            {
                if (values[i] == myDict["4"])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0,-5}", values[i]);
                    Console.ResetColor();
                }                    
                else
                    Console.Write("{0,-5}", values[i]);
            }

            Console.ReadKey();
        }
    }
}
