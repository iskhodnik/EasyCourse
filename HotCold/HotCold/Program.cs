using System;

namespace HotCold
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomNumber = new Random().Next(-1000, 1000);

            int currentNumber = 0;
            int previousNumber = 0;

            var exit = false;
            var firstStep = true;


            while (!exit)
            {
                var successParse = false;
                while (!successParse)
                {
                    Console.WriteLine("Введите число:");

                    successParse = int.TryParse(Console.ReadLine(), out currentNumber);
                    if (!successParse)
                    {
                        Console.WriteLine("Введено некорректное значение!");
                    }
                }

                if (firstStep)
                {
                    previousNumber = currentNumber;
                    firstStep = false;
                    continue;
                }

                if (currentNumber == randomNumber)
                {
                    Console.WriteLine("\nУспех");

                    Console.WriteLine("\nПовторить?(y/n)");
                    var successInput = false;
                    while (!successInput)
                    {
                        var input = Console.ReadLine();
                        if (input.Equals("y"))
                        {
                            successInput = true;
                            Console.Clear();
                            randomNumber = new Random().Next(-1000, 1000);
                            firstStep = true;
                        }
                        else if(input.Equals("n"))
                        {
                            successInput = true;
                            exit = true;
                        }
                    }
                }
                else if (Math.Abs(randomNumber - currentNumber) < Math.Abs(randomNumber - previousNumber))
                {
                    previousNumber = currentNumber;
                    Console.WriteLine("горячё");
                }
                else
                {
                    Console.WriteLine("холодно");
                }
            }
        }
    }
}
