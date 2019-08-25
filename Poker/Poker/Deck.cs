using System;
using System.Collections.Generic;

namespace Poker
{
    public class Deck
    {
        private List<Card> deck;

        public List<Card> GetDeck()
        {
            return deck;
        }

        public void SetDeck(List<Card> value)
        {
            deck = value;
        }

        public Deck()
        {
            deck = new List<Card>();

            foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
            {
                foreach (Card.Advantages advantage in Enum.GetValues(typeof(Card.Advantages)))
                {
                    deck.Add(new Card(suit, advantage));
                }
            }
        }
    }
}
