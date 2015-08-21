namespace Poker
{
    public class Card : ICard
    {
        private const int MaxCardFaceAsNumber = (int)CardFace.Ten;
 
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            var cardSuit = string.Empty;
            switch (this.Suit)
            {
                case CardSuit.Spades:
                    cardSuit = this.Suit + " ♣";
                    break;
                case CardSuit.Diamonds:
                    cardSuit = this.Suit + " ♦";
                    break;
                case CardSuit.Hearts:
                    cardSuit = this.Suit + " ♥";
                    break;
                case CardSuit.Clubs:
                    cardSuit = this.Suit + " ♠";
                    break;
                default:
                    throw new System.InvalidOperationException("Invalid suit: " + this.Suit);
            }
            
            return string.Format("{0} of {1}", this.Face, cardSuit);
        }

        public override bool Equals(object otherCard)
        {
            var card = otherCard as Card;
            if (card == null)
            {
                return false;
            }

            return this.Face == card.Face && this.Suit == card.Suit;
        }

        public override int GetHashCode()
        {
            return this.Face.GetHashCode() ^ this.Suit.GetHashCode();
        }
    }
}