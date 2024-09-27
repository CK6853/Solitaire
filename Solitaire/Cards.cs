using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire
{
    /// <summary>
    /// Enum for card suits
    /// </summary>
    public enum Suit
    {
        Clubs,
        Diamonds,
        Spades,
        Hearts
    }

    /// <summary>
    /// A single Card
    /// </summary>
    public class Card
    {
        public int value;
        public Suit suit;

        public Card(int value, Suit suit)
        {
            this.value = value;
            this.suit = suit;
        }

        /// <summary>
        /// Show a single Card as a string
        /// Format: "Ace of Hearts", "2 of Diamonds", "King of Spades" etc.
        /// </summary>
        /// <returns>String name of a Card</returns>
        public override string ToString()
        {
            string valueString;
            if (value < 11 && value != 1)
            {
                valueString = value.ToString();
            } else
            {
                switch(value)
                {
                    case 1:
                        valueString = "Ace";
                        break;
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

    /// <summary>
    /// A List of Cards
    /// </summary>
    public class CardDeck : LinkedList<Card>
    {
        public void CreateFullDeck()
        {
            Clear();
            for (int suitIndex = 0; suitIndex <=3; suitIndex++)
            {
                Suit suit = (Suit)suitIndex;
                for (int value = 1; value <= 13; value++)
                {
                    AddLast(new Card(value, suit));
                }
            }
        }

        public void Shuffle()
        {
            Randomize();
        }




        // Split at index
        // Deal
        // PlaceTop
        // PlaceBottom
    }
}
