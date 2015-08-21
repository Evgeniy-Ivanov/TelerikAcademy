namespace Poker.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CardToStringSpadesShouldReturnCorrect()
        {
            var card = new Card(CardFace.Jack, CardSuit.Spades);
            var expected = "Jack of Spades ♣";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void CardToStringDiamondsShouldReturnCorrect()
        {
            var card = new Card(CardFace.Jack, CardSuit.Diamonds);
            var expected = "Jack of Diamonds ♦";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void CardToStringHeartsShouldReturnCorrect()
        {
            var card = new Card(CardFace.Jack, CardSuit.Hearts);
            var expected = "Jack of Hearts ♥";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void CardToStringClubsShouldReturnCorrect()
        {
            var card = new Card(CardFace.Jack, CardSuit.Clubs);
            var expected = "Jack of Clubs ♠";

            Assert.AreEqual(expected, card.ToString());
        }
    }
}
