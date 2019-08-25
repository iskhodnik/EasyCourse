using System;
using System.Collections.Generic;

namespace Poker
{
    public class Croupier : Person
    {
        private Deck deck;

        public Croupier()
        {
            deck = new Deck();
        }

        public void ShuffleDeck()
        {
            if (deck != null)
            {
                var currentDeck = deck.GetDeck();
                var rand = new Random();

                Card tmp;
                for (int i = 0; i < currentDeck.Count; i++)
                {
                    tmp = currentDeck[0];
                    currentDeck.RemoveAt(0);
                    currentDeck.Insert(rand.Next(currentDeck.Count), tmp);
                }
            }
        }

        public List<Card> DistributionCards(int numberCards)
        {
            var deckCurrent = deck.GetDeck();
            var cards = deckCurrent.GetRange(0, numberCards);
            deckCurrent.RemoveRange(0, numberCards);
            return cards;
        }
    }
}
