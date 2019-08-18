using System;
using System.Collections.Generic;

namespace CardValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = InputCode(); // 4561261212345464 - не валидна | 4561261212345467 - валидна
            var result = IsCardValid(code);
            Console.WriteLine(result ? "Карта валидна" : "Карта не валидна");

            Console.ReadKey();
        }

        public static int[] InputCode()
        {
            Console.WriteLine("Введите номмер карты:");

            var stingCode = Console.ReadLine();
            char[] arrayCharNumbers = stingCode.ToCharArray();
            var numbers = new List<int>();

            foreach (var charNumber in arrayCharNumbers)
            {
                var number = (int)char.GetNumericValue(charNumber);

                if(number == -1)
                {
                    Console.WriteLine("Введён неверный номмер карты.");
                    return InputCode();
                }
                else
                {
                    numbers.Add(number);
                }  
            }

            return numbers.ToArray();
        }

        public static bool IsCardValid(int[] cardNumbers)
        {
            var sum = 0;

            for (var i = 0; i < cardNumbers.Length; i++)
            {
                var cardNumber = cardNumbers[i];

                if ((cardNumbers.Length - i) % 2 == 0)
                {
                    cardNumber = cardNumber * 2;

                    if (cardNumber > 9)
                    {
                        cardNumber = cardNumber - 9;
                    }
                }
                sum += cardNumber;
            }

            return sum % 10 == 0;
        }
    }
}
