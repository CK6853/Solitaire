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

        public override string ToString()
        {
            string valueString;
            if (value < 11)
            {
                valueString = value.ToString();
            } else
            {
                switch(value)
                {
                    case 11:
                        valueString = "Jack";
                        break;
                    case 12:
                        valueString = "Queen";
                        break;
                    case 13:
                        valueString = "King";
                        break;
                    default:
                        valueString = "";
                        break;
                }
            }
            return $"{valueString} of {suit.ToString()}";
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
