namespace Poker
{
    public class Card
    {
        public enum Suit
        {
            hearts = 1,
            tiles,
            clovers,
            pikes
        }

        public enum Advantages
        {
            ace = 1,
            two,
            three,
            four,
            five,
            six,
            seve,
            eight,
            nine,
            ten,
            jack,
            queen,
            king
        }

        private Suit suit;
        private Advantages advantages;

        public Card(Suit suit, Advantages advantages)
        {
            this.suit = suit;
            this.advantages = advantages;
        }

        public override string ToString()
        {
            return $"{suit.ToString()} - {advantages.ToString()}";
        }
    }
}
