namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Hand : IHand
    {
        public Hand(IList<ICard> cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("List of cards cannot be null.");
            }

            foreach (var item in cards)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("Card cannot be null");
                }
            }

            this.Cards = cards;
        }

        public enum Type
        {
            HighCard = 0,
            OnePair = 1,
            TwoPair = 2,
            ThreeOfAKind = 3,
            Straight = 4,
            Flush = 5,
            FullHouse = 6,
            FourOfAKind = 7,
            StraightFlush = 8
        }

        public IList<ICard> Cards { get; private set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < this.Cards.Count; i++)
            {
                if (i < this.Cards.Count - 1)
                {
                    builder.Append(this.Cards[i] + " / ");
                }
                else
                {
                    builder.Append(this.Cards[i]);
                }
            }

            return builder.ToString();
        }
    }
}