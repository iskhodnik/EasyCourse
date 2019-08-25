using System;
using System.Collections.Generic;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            var croupier = new Croupier();
            var players = new List<Player>();

            Console.WriteLine("Введите количество игроков.");
            var numberPlayers = ParseValueToInt(ImputValue());

            for(var i = 0; i < numberPlayers; i++)
            {
                players.Add(new Player());
            }

            croupier.ShuffleDeck();

            foreach(var player in players)
            {
                player.Cards = croupier.DistributionCards(5);
            }

            foreach (var player in players)
            {
                player.ShowCards();
                Console.ReadLine();
            }

        }

        static private string ImputValue()
        {
            var param = Console.ReadLine();

            if (param.Equals(string.Empty))
            {
                ImputValue();
            }

            return param;
        }

        static private int ParseValueToInt(string value)
        {
            int convertedValue;
            try
            {
                convertedValue = int.Parse(value);

                if (convertedValue <= 0)
                {
                    Console.WriteLine($"Введите значение повторно.");
                    var newValue = ImputValue();
                    convertedValue = ParseValueToInt(newValue);
                }

                return convertedValue;
            }
            catch (SystemException)
            {
                Console.WriteLine($"Введите значение повторно.");
                var newValue = ImputValue();
                return ParseValueToInt(newValue);
            }
        }
    }
}
