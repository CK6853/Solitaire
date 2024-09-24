using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire
{
    public enum Suit
    {
        Clubs,
        Diamonds,
        Spades,
        Hearts
    }

    public class Card
    {
        public int value;
        public Suit suit;

        public Card(int value, Suit suit)
        {
            this.value = value;
            this.suit = suit;
        }
    }

    public class CardDeck
    {
        private Card[] cards;

        public CardDeck()
        {
            cards = new Card[0];
        }
    }
}
