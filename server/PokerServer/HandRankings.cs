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
        private HandType _handtype = HandType.STANDARD;
        private Rank[] _rank_ordered_significant;
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
        public string UserName
        {
            get;set;
        }
        public HandType HandType
        {
            get { return _handtype; }
        }
        public Card[] Cards
        {
            get { return _cards; }
        }
        public Rank[] SignificantRankssOrdered
        {
            get { return _rank_ordered_significant; }
        }
        private void CalcHandType()
        {
            var suit_count = _cards.GroupBy(x => x.Suit).Select(g => new {g,g.ToList().Count });
            var rank_count = _cards.GroupBy(x => x.Rank).Select(g => new { g, g.ToList().Count });
            var ranks = _cards.Select(a => a.Rank);
          
            rank_count = rank_count.OrderByDescending(g => g.Count).ThenByDescending(a => a.g.Key);
            suit_count = suit_count.OrderByDescending(g => g.Count);
            ranks = ranks.OrderByDescending(a => (int)a);

            _rank_ordered_significant = rank_count.Select(a => a.g.Key).ToArray();
            // move Ace to the front, because right now if present , its at the end of the array
            //if (_rank_ordered_significant.Last() == Rank.Ace)
            //{
            //    Rank[] _temp = new Rank[5]; 
            //    _rank_ordered_significant.CopyTo(_temp,0);
            //    for(int i =1;i<5;i++)
            //    {
            //        _rank_ordered_significant[i] = _temp[i - 1];
            //    }
            //    _rank_ordered_significant[0] = _temp[4];
            //}

            Rank highCard;
            bool straight = false;
            bool flush = false;

            highCard = ranks.First();

            if ((rank_count.First().Count == 1) && ( ((ranks.First() - ranks.Last()) == 4) || ((ranks.Sum(a => (int)a) == 28) && (ranks.Min() == Rank.Two))))
            {
                straight = true;
                _handtype = HandType.STRAIGHT;
               // Console.WriteLine("its a straight");
            }

            if (suit_count.First().Count == 5)
            {
                // hand type can be flush , straight flush or royal flush
                if (straight)
                {
                    if ((ranks.Last() == Rank.Ten) && (ranks.First() == Rank.Ace))
                    {
                        _handtype = HandType.ROYAL_FLUSH;
                      //  Console.WriteLine("its a royal flush");
                    }
                    else
                    {
                        _handtype = HandType.STRAIGHT_FLUSH;
                        //Console.WriteLine("its a straight flush");
                    }
                }
                else
                {
                    _handtype = HandType.FLUSH;
                    //Console.WriteLine("its a flush");
                }
                return;
            }

           
            if (rank_count.First().Count == 4)
            {
                _handtype = HandType.FOUR_OF_A_KIND;
                //Console.WriteLine("its a four of a kind");
                return;
            }
            if ((rank_count.First().Count == 3) && (rank_count.Count() == 2))
            {
                _handtype = HandType.FULL_HOUSE;
                //Console.WriteLine("its a full house");
                return;
            }
            if ((rank_count.First().Count == 3) && (rank_count.Count() == 3))
            {
                _handtype = HandType.THREE_OF_A_KIND;
                //Console.WriteLine("its a three of a kind");
                return;
            }
            if ((rank_count.First().Count == 2) && (rank_count.Count() == 3))
            {
                _handtype = HandType.TWO_PAIR;
                //Console.WriteLine("its a two pair");
                return;
            }
            if ((rank_count.First().Count == 2) && (rank_count.Count() == 4))
            {
                _handtype = HandType.ONE_PAIR;
                //Console.WriteLine("its a one pair");
                return;
            }
           
           
        }
        public static HandRankings ComputeBestHand(Player player, Tuple<Card, Card, Card, Card, Card> board)
        {
            Tuple<Card, Card> userholecards = player.GetHoleCards();

;            List<Card[]> result = new List<Card[]>();
            int cardsSelected = 0;
           
            Card[] cardlist = new Card[] { userholecards.Item1, userholecards.Item2, board.Item1, board.Item2, board.Item3, board.Item4, board.Item5 };

            // select first card not to be in the hand
            for (int firstCard = 0; firstCard < 7; firstCard++)
            {
                // select first card not to be in the hand
                for (int secondCard = firstCard + 1; secondCard < 7; secondCard++)
                {
                    Card[] fivecardhand = new Card[5];
                    // every card that is not the first or second will added to the hand
                    for (int i = 0; i < 7; i++)
                    {
                        if (i != firstCard && i != secondCard)
                        {
                            fivecardhand[cardsSelected++] = cardlist[i];
                        }
                    }
                    // next hand
                    cardsSelected = 0;
                    result.Add(fivecardhand);
                   
                }
            }
            List<HandRankings> hlist = result.Select(a => new HandRankings(a)).ToList<HandRankings>();
            hlist.Sort(new HandComparer());
            hlist[20].UserName = player.UserName;
            return hlist[20];
        }
    }
    public enum HandType
    {
        STANDARD = 0,
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
