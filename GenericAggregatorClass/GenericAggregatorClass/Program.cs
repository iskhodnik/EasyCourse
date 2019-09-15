using System;
using System.Collections.Generic;

namespace GenericAggregatorClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new GenericNumericClass<double>(new List<double>() { 1.5, 3.5, 5.5, 7.5, 9.5 });

            Console.WriteLine(myList.Max());
            Console.WriteLine(myList.Min());
            Console.WriteLine(myList.Average());
            Console.ReadKey();
        }
    }
}
