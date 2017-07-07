using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Shared;

namespace Poker.Server
{
    public class HandRankings
    {
        private Card[] _cards;
        private HandType _handtype;
        public HandRankings( Card[] cards)
        {
            if (cards.Length != 5)
                throw new Exception("Expecting 5 cards in the Cards array");
            _cards = cards;
            CalcHandType();
        }
        public HandRankings(Tuple<Card,Card,Card,Card,Card> fivecards)
        {
            _cards = new Card[5];
            short index = 0;
            _cards[index++] = fivecards.Item1;
            _cards[index++] = fivecards.Item2;
            _cards[index++] = fivecards.Item3;
            _cards[index++] = fivecards.Item4;
            _cards[index++] = fivecards.Item5;

            if (index != 5)
                throw new Exception("Index should have been 4");
            CalcHandType();
        }
        private void CalcHandType()
        {
            var suit_count = _cards.GroupBy(x => x.Suit).Select(g => new {g,g.ToList().Count });
            var rank_count = _cards.GroupBy(x => x.Rank).Select(g => new { g, g.ToList().Count });
            var ranks = _cards.Select(a => a.Rank);
          
            rank_count = rank_count.OrderByDescending(g => g.Count);
            suit_count = suit_count.OrderByDescending(g => g.Count);
            ranks = ranks.OrderByDescending(a => (int)a);

            Rank highCard;
            bool straight = false;
            bool flush = false;

            highCard = ranks.First();

            if ((ranks.First() - ranks.Last()) == 4)
            {
                straight = true;
                _handtype = HandType.STRAIGHT;
                Console.WriteLine("its a straight");
            }

            if ((ranks.First() == Rank.King) && (ranks.Last() == Rank.Ace))
            {
                straight = true;
                _handtype = HandType.STRAIGHT;
                Console.WriteLine("its also a straight");
            }

            if (suit_count.First().Count == 5)
            {
                // hand type can be flush , straight flush or royal flush
                if (straight)
                {
                    if (ranks.Last() == Rank.Ace)
                    {
                        _handtype = HandType.ROYAL_FLUSH;
                        Console.WriteLine("its a royal flush");
                    }
                    else
                    {
                        _handtype = HandType.STRAIGHT_FLUSH;
                        Console.WriteLine("its a straight flush");
                    }
                }
                else
                {
                    _handtype = HandType.FLUSH;
                    Console.WriteLine("its a flush");
                }
               
            }

           
            if (rank_count.First().Count == 4)
            {
                _handtype = HandType.FOUR_OF_A_KIND;
                Console.WriteLine("its a four of a kind");
            
            }
            if ((rank_count.First().Count == 3) && (rank_count.Count() == 2))
            {
                _handtype = HandType.FULL_HOUSE;
                Console.WriteLine("its a full house");

            }
            if ((rank_count.First().Count == 3) && (rank_count.Count() == 3))
            {
                _handtype = HandType.THREE_OF_A_KIND;
                Console.WriteLine("its a three of a kind");

            }
            if ((rank_count.First().Count == 2) && (rank_count.Count() == 3))
            {
                _handtype = HandType.TWO_PAIR;
                Console.WriteLine("its a two pair");

            }
            if ((rank_count.First().Count == 2) && (rank_count.Count() == 4))
            {
                _handtype = HandType.ONE_PAIR;
                Console.WriteLine("its a one pair");

            }
           
           
        }

    }
    public enum HandType
    {
        STANDARD,
        ONE_PAIR,
        TWO_PAIR,
        THREE_OF_A_KIND,
        STRAIGHT,
        FLUSH,
        FULL_HOUSE,
        FOUR_OF_A_KIND,
        STRAIGHT_FLUSH,
        ROYAL_FLUSH
    }

}
