using System;
using System.Collections.Generic;

namespace Poker
{
    public class Person
    {
        List<Card> cards;
        public List<Card> Cards { get => cards; set => cards = value; }

        public Person()
        {
            cards = new List<Card>();
        }

        public Person(List<Card> cards)
        {
            this.cards = cards ?? throw new ArgumentNullException(nameof(cards));
        }

        public void ShowCards()
        {
            foreach(var card in cards)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}
