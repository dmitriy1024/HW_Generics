using System;

namespace HW_Generics.Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var carCollection = new CarCollection<Car>();

            carCollection.Add(new Car("BMW M3", 2000));
            carCollection.Add(new Car("Ford Mustang", 1967));
            carCollection.Add(new Car("Moskvich 412", 1975));
            carCollection.Add(new Car("Porshe 911", 2015));

            Console.WriteLine("   CAR COLLECTION");
            Console.WriteLine("{0,-15}  {1,-4}", "NAME", "MANUFACTURE YEAR");
            for (int i = 0; i < carCollection.Count; i++)
            {
                Console.WriteLine("{0,-15}  {1,-4}", carCollection[i].Name, carCollection[i].ManufactYear);
            }

            carCollection.Clear();
            Console.WriteLine("\nCollection was cleared. Count = {0}", carCollection.Count);

            Console.ReadKey();
        }
    }
}
