namespace Poker.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PokerHandsCheckerTest
    {
        private const int FirstHandIsBigger = 1;
        private const int HandsAreEqual = 0;
        private const int SecondHandIsBigger = -1;
        private IPokerHandsChecker pokerHandsChecker;

        [TestInitialize]
        public void TestInitialize()
        {
            this.pokerHandsChecker = new PokerHandsChecker();
        }
 
        [TestMethod]
        public void IsValidHandShouldReturnTrueWithValidHand()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Clubs), 
                new Card(CardFace.Two, CardSuit.Diamonds), 
                new Card(CardFace.Eight, CardSuit.Hearts), 
                new Card(CardFace.Jack, CardSuit.Spades), 
                new Card(CardFace.Seven, CardSuit.Clubs) 
            };
            var hand = new Hand(cards);
            checker.IsValidHand(hand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsValidHandShouldThrowExceptionWhenNullHandIsPassed()
        {
            var checker = new PokerHandsChecker();
            IHand hand = null;
            checker.IsValidHand(hand);
        }

        [TestMethod]

        [ExpectedException(typeof(ArgumentException))]
        public void IsValidHandShouldThrowExceptionWhenHandContainsIsufficientCards()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> { new Card(CardFace.Ace, CardSuit.Diamonds) };
            var hand = new Hand(cards);

            checker.IsValidHand(hand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsValidHandShouldReturnFalseWithFiveCardsOfSameFace()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard>
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds), 
                new Card(CardFace.Ace, CardSuit.Diamonds), 
                new Card(CardFace.Ace, CardSuit.Spades), 
                new Card(CardFace.Ace, CardSuit.Clubs), 
                new Card(CardFace.Ace, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]

        [ExpectedException(typeof(ArgumentException))]
        public void IsValidHandShouldReturnFalseWithTwoEqualCards()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard>
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds), 
                new Card(CardFace.King, CardSuit.Diamonds), 
                new Card(CardFace.Two, CardSuit.Spades), 
                new Card(CardFace.Two, CardSuit.Spades), 
                new Card(CardFace.Five, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            checker.IsValidHand(hand);
        }

        [TestMethod]
        public void IsHighCardShoudReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard>
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds), 
                new Card(CardFace.King, CardSuit.Diamonds), 
                new Card(CardFace.Two, CardSuit.Spades), 
                new Card(CardFace.Three, CardSuit.Spades), 
                new Card(CardFace.Five, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsTrue(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void IsHighCardShoudReturnFalseWhenNotMatchingHandPassed_OnePair()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds), 
                new Card(CardFace.King, CardSuit.Diamonds), 
                new Card(CardFace.Two, CardSuit.Spades), 
                new Card(CardFace.Two, CardSuit.Diamonds), 
                new Card(CardFace.Five, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void IsOnePairShouldReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds), 
                new Card(CardFace.King, CardSuit.Diamonds), 
                new Card(CardFace.Two, CardSuit.Spades), 
                new Card(CardFace.Two, CardSuit.Hearts), 
                new Card(CardFace.Five, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsTrue(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void IsOnePairShouldReturnFalseWhenNotMatchingHandPassed_ThreeOfAKind()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds), 
                new Card(CardFace.Two, CardSuit.Spades), 
                new Card(CardFace.Two, CardSuit.Hearts), 
                new Card(CardFace.Five, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void IsTwoPairShouldReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds), 
                new Card(CardFace.Two, CardSuit.Diamonds), 
                new Card(CardFace.Two, CardSuit.Spades), 
                new Card(CardFace.Ace, CardSuit.Hearts), 
                new Card(CardFace.Five, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsTrue(checker.IsTwoPairs(hand));
        }

        [TestMethod]
        public void IsTwoPairShouldReturnFalseWhenNotMatchingHandPassed_FullHouse()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds), 
                new Card(CardFace.Two, CardSuit.Diamonds), 
                new Card(CardFace.Two, CardSuit.Spades), 
                new Card(CardFace.Ace, CardSuit.Hearts), 
                new Card(CardFace.Two, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsTwoPairs(hand));
        }

        [TestMethod]
        public void IsTwoPairShouldReturnFalseWhenNotMatchingHandPassed_OnePair()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds), 
                new Card(CardFace.Ace, CardSuit.Spades), 
                new Card(CardFace.Two, CardSuit.Spades), 
                new Card(CardFace.King, CardSuit.Hearts), 
                new Card(CardFace.Five, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsTwoPairs(hand));
        }

        [TestMethod]
        public void IsThreeOfAKindShouldReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds), 
                new Card(CardFace.Two, CardSuit.Diamonds), 
                new Card(CardFace.Two, CardSuit.Spades), 
                new Card(CardFace.Two, CardSuit.Hearts), 
                new Card(CardFace.Five, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsTrue(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void IsThreeOfAKindShouldReturnFalseWhenNotMatchingHandPassed_FullHouse()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds), 
                new Card(CardFace.Two, CardSuit.Diamonds), 
                new Card(CardFace.Two, CardSuit.Spades), 
                new Card(CardFace.Two, CardSuit.Hearts), 
                new Card(CardFace.Ace, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void IsStraightShouldReturnTrue_AceToFive()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds), 
                new Card(CardFace.Two, CardSuit.Diamonds), 
                new Card(CardFace.Three, CardSuit.Spades), 
                new Card(CardFace.Four, CardSuit.Hearts), 
                new Card(CardFace.Five, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsTrue(checker.IsStraight(hand));
        }

        [TestMethod]
        public void IsStraightShouldReturnTrue_JackToAce()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds), 
                new Card(CardFace.King, CardSuit.Diamonds), 
                new Card(CardFace.Queen, CardSuit.Spades), 
                new Card(CardFace.Jack, CardSuit.Hearts), 
                new Card(CardFace.Ten, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsTrue(checker.IsStraight(hand));
        }

        [TestMethod]
        public void IsStraightShouldReturnTrue_FourToEight()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Four, CardSuit.Diamonds), 
                new Card(CardFace.Five, CardSuit.Diamonds), 
                new Card(CardFace.Six, CardSuit.Spades), 
                new Card(CardFace.Seven, CardSuit.Hearts), 
                new Card(CardFace.Eight, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsTrue(checker.IsStraight(hand));
        }

        [TestMethod]
        public void IsStraightShouldReturnFalseWhenNotMatchingHandPassed_StraightFlush()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Four, CardSuit.Diamonds), 
                new Card(CardFace.Five, CardSuit.Diamonds), 
                new Card(CardFace.Six, CardSuit.Diamonds), 
                new Card(CardFace.Seven, CardSuit.Diamonds), 
                new Card(CardFace.Eight, CardSuit.Diamonds) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsStraight(hand));
        }

        [TestMethod]
        public void IsStraightShouldReturnFalseWhenNotMatchingHandPassed_OnePair()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Four, CardSuit.Diamonds), 
                new Card(CardFace.Five, CardSuit.Diamonds), 
                new Card(CardFace.Six, CardSuit.Spades), 
                new Card(CardFace.Seven, CardSuit.Hearts), 
                new Card(CardFace.Seven, CardSuit.Clubs) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsStraight(hand));
        }

        [TestMethod]
        public void IsFlushShouldReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Four, CardSuit.Clubs), 
                new Card(CardFace.Five, CardSuit.Clubs), 
                new Card(CardFace.Six, CardSuit.Clubs), 
                new Card(CardFace.Seven, CardSuit.Clubs), 
                new Card(CardFace.Ten, CardSuit.Clubs) 
            };
            var hand = new Hand(cards);

            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void IsFlushShouldReturnFalseWhenNotMatchingHandPassed_StraightFlush()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Four, CardSuit.Diamonds), 
                new Card(CardFace.Five, CardSuit.Diamonds), 
                new Card(CardFace.Six, CardSuit.Diamonds), 
                new Card(CardFace.Seven, CardSuit.Diamonds), 
                new Card(CardFace.Eight, CardSuit.Diamonds) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void IsFlushShouldReturnFalseWhenNotMatchingHandPassed()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Four, CardSuit.Diamonds), 
                new Card(CardFace.Five, CardSuit.Diamonds), 
                new Card(CardFace.Six, CardSuit.Diamonds), 
                new Card(CardFace.Queen, CardSuit.Clubs), 
                new Card(CardFace.Eight, CardSuit.Diamonds) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void IsFullHouseShouldReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Four, CardSuit.Diamonds), 
                new Card(CardFace.Five, CardSuit.Diamonds), 
                new Card(CardFace.Four, CardSuit.Spades), 
                new Card(CardFace.Four, CardSuit.Clubs), 
                new Card(CardFace.Five, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsTrue(checker.IsFullHouse(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFullHouseShouldThrowException_TwoOfTheSameCards()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Four, CardSuit.Spades), 
                new Card(CardFace.Five, CardSuit.Diamonds), 
                new Card(CardFace.Four, CardSuit.Spades), 
                new Card(CardFace.Four, CardSuit.Clubs), 
                new Card(CardFace.Five, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            checker.IsFullHouse(hand);
        }

        [TestMethod]
        public void IsFullHouseShouldReturnFalseWhenNotMatchingHandPassed_ThreeOfAKind()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Four, CardSuit.Spades), 
                new Card(CardFace.Five, CardSuit.Diamonds), 
                new Card(CardFace.Four, CardSuit.Hearts), 
                new Card(CardFace.Four, CardSuit.Clubs), 
                new Card(CardFace.Six, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void IsFourOfAKindShouldReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds), 
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Clubs), 
                new Card(CardFace.Four, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFourOfAKindShouldThrowException_FiveOfAKind()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds), 
                new Card(CardFace.Four, CardSuit.Hearts), 
                new Card(CardFace.Four, CardSuit.Clubs), 
                new Card(CardFace.Four, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            checker.IsFullHouse(hand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsValidHandShouldThrowException_FiveOfAKind()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            {
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds), 
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs), 
                new Card(CardFace.Four, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            checker.IsValidHand(hand);
        }

        [TestMethod]
        public void IsFourOfAKindShouldReturnFalseWhenNotMatchingHandPassed_ThreeOfAKind()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds), 
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs), 
                new Card(CardFace.Six, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void IsFourOfAKindShouldReturnFalseWhenNotMatchingHandPassed_TwoPairs()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard>
            { 
                new Card(CardFace.Queen, CardSuit.Spades), 
                new Card(CardFace.Queen, CardSuit.Diamonds), 
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs), 
                new Card(CardFace.Four, CardSuit.Hearts) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void IsStraightFlushShouldReturnTrue_AceToFive()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            {
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs), 
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs), 
                new Card(CardFace.Five, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsTrue(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void IsStraightFlushShouldReturnTrue_TenToAce()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Clubs), 
                new Card(CardFace.Ten, CardSuit.Clubs), 
                new Card(CardFace.King, CardSuit.Clubs), 
                new Card(CardFace.Jack, CardSuit.Clubs), 
                new Card(CardFace.Queen, CardSuit.Clubs) 
            };
            var hand = new Hand(cards);

            Assert.IsTrue(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void IsStraightFlushShouldReturnTrue_SevenToJack()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs), 
                new Card(CardFace.Nine, CardSuit.Clubs), 
                new Card(CardFace.Ten, CardSuit.Clubs), 
                new Card(CardFace.Jack, CardSuit.Clubs) 
            };
            var hand = new Hand(cards);

            Assert.IsTrue(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void IsStraightFlushShouldReturnFalseWhenNotMatchingHandPassed_Straight()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs), 
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts), 
                new Card(CardFace.Jack, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void IsStraightFlushShouldReturnFalseWhenNotMatchingHandPassed_Flush()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> 
            { 
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs), 
                new Card(CardFace.Nine, CardSuit.Clubs), 
                new Card(CardFace.Ten, CardSuit.Clubs), 
                new Card(CardFace.Jack, CardSuit.Clubs) 
            };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsStraightFlush(hand));
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ComparingNullHands()
        {
            IHand firstHand = null;
            IHand secondHand = null;
            var checker = new PokerHandsChecker();

            checker.CompareHands(firstHand, secondHand);
        }

        [TestMethod]
        public void CompareHands_DifferentRank_FirstHandHasStraightFlushSecondHandHasFourOfAKind()
        {
            Hand firstHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts)
            });

            Hand secondHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Hearts)
            });

            int expected = FirstHandIsBigger;
            int result = this.pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CompareHands_DifferentRank_FirstHandHasFlushSecondHandHasFullHouse()
        {
            Hand firstHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts)
            });

            Hand secondHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts)
            });

            int expected = SecondHandIsBigger;
            int result = this.pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CompareHands_DifferentRank_FirstHandHasStraightSecondHandHasThreeOfAKind()
        {
            Hand firstHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds)
            });

            Hand secondHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts)
            });

            int expected = FirstHandIsBigger;
            int result = this.pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CompareHands_DifferentRank_FirstHandHasOnePairSecondHandHasTwoPair()
        {
            Hand firstHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds)
            });

            Hand secondHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Hearts)
            });

            int expected = SecondHandIsBigger;
            int result = this.pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CompareHands_DifferentRank_FirstHandHasOnePairSecondHandHasHighCard()
        {
            Hand firstHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            });

            Hand secondHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            });

            int expected = FirstHandIsBigger;
            int result = this.pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CompareHands_SameRank_FirstHandHasBiggerCard()
        {
            Hand firstHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades)
            });

            Hand secondHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades)
            });

            int expected = FirstHandIsBigger;
            int result = this.pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CompareHands_SameRank_SecondHandHasBiggerCard()
        {
            Hand firstHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Hearts)
            });

            Hand secondHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Hearts)
            });

            int expected = SecondHandIsBigger;
            int result = this.pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CompareHands_SameRank_EqualHands()
        {
            Hand firstHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            });

            Hand secondHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            });

            int expected = HandsAreEqual;
            int result = this.pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CompareFlushHands()
        {
            Hand firstHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            });

            Hand secondHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            });

            int expected = SecondHandIsBigger;
            int result = this.pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void CompareFullHouseHands()
        {
            Hand firstHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs)
            });

            Hand secondHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades)
            });

            int expected = SecondHandIsBigger;
            int result = this.pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CompareOnePairHands()
        {
            Hand firstHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs)
            });

            Hand secondHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades)
            });

            int expected = SecondHandIsBigger;
            int result = this.pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CompareThreeOfAKindHands()
        {
            Hand firstHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs)
            });

            Hand secondHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades)
            });

            int expected = SecondHandIsBigger;
            int result = this.pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CompareTwoPairHands()
        {
            Hand firstHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs)
            });

            Hand secondHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades)
            });

            int expected = SecondHandIsBigger;
            int result = this.pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CompareHighCardHands()
        {
            Hand firstHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs)
            });

            Hand secondHand = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades)
            });

            int expected = SecondHandIsBigger;
            int result = this.pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, result);
        }
    }
}