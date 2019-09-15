using System;
using System.Collections.Generic;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            var myArr = new MyArrayList<string>();

            myArr.Add("1");
            myArr.Add("2");
            myArr.Add("3");
            myArr.Add("4");
            myArr.Add("5");
            myArr.Add("4");
            myArr.Add("3");
            myArr.Add("2");
            myArr.Add("1");

            myArr.ForEach(Console.WriteLine);
            Console.WriteLine();

            myArr.Remove(3);
            myArr.ForEach(Console.WriteLine);
            Console.WriteLine();

            myArr.Remove("1");
            myArr.ForEach(Console.WriteLine);
            Console.WriteLine();

            Console.WriteLine(myArr.IndexOf("5"));
            Console.WriteLine();

            Array.ForEach(myArr.Get("3"), Console.Write);
            Console.WriteLine();

            Console.WriteLine(myArr.Get(3));

            Console.ReadKey();

        }
    }


    
    

}