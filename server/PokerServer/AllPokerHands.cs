using Poker.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Server
{
    public class AllPokerHands
    {
        public AllPokerHands()
        {
            
        }
        public void init()
        {
            Deck d = Deck.GetShuffledDeck();
            
            Tuple<Card, Card, Card, Card, Card> hand = new Tuple<Card, Card, Card, Card, Card>(
                                                        new Card(Suit.Diamond, Rank.Nine),
                                                        new Card(Suit.Club, Rank.King),
                                                        new Card(Suit.Club, Rank.Queen),
                                                        new Card(Suit.Club, Rank.Jack),
                                                        new Card(Suit.Club, Rank.Ten)
                                                        );
            HandRankings h = new HandRankings(hand);
            List<Card> d1 = d.cards.ToList();
            List<Card> d2 = d.cards.ToList();
            List<Card> d3 = d.cards.ToList();
            List<Card> d4 = d.cards.ToList();
            List<Card> d5 = d.cards.ToList();
            List<Tuple<Card, Card, Card, Card, Card>> allpokerhands = new List<Tuple<Card, Card, Card, Card, Card>>();
            List<HandRankings> allpokerhands_1 = new List<HandRankings>();

            DateTime start = DateTime.Now;
            int counter = 10;
            for (int i = 0; i < d1.Count;i++)
            {
                for (int j = i+1; j < d1.Count; j++)
                {
                    for (int k = j + 1; k < d1.Count; k++)
                    {
                        for (int l = k + 1; l < d1.Count; l++)
                        {
                            for (int m = l + 1; m< d1.Count; m++)
                            {
                                allpokerhands.Add(new Tuple<Card, Card, Card, Card, Card>(d1[i],d1[j],d1[k],d1[l],d1[m]));
                                allpokerhands_1.Add(new HandRankings(new Tuple<Card, Card, Card, Card, Card>(d1[i], d1[j], d1[k], d1[l], d1[m])));
                                //if (--counter < 0)
                                //    break;

                            }
                        }
                    }
                }
            }
            DateTime end = DateTime.Now;
            //List<HandRankings> allpokerhands_s = allpokerhands_1.Where(a => a.HandType == HandType.FOUR_OF_A_KIND).ToList();
            allpokerhands_1.Sort(new HandComparer());
            DateTime end1 = DateTime.Now;
            int royalflushcount = allpokerhands_1.Count(a => a.HandType == HandType.ROYAL_FLUSH);
            int straightflushcount = allpokerhands_1.Count(a => a.HandType == HandType.STRAIGHT_FLUSH);
            int fourofakindcount = allpokerhands_1.Count(a => a.HandType == HandType.FOUR_OF_A_KIND);
            int fullhousecount = allpokerhands_1.Count(a => a.HandType == HandType.FULL_HOUSE);
            int flushcount = allpokerhands_1.Count(a => a.HandType == HandType.FLUSH);
            int straightcount = allpokerhands_1.Count(a => a.HandType == HandType.STRAIGHT);
            int threeofakindcount = allpokerhands_1.Count(a => a.HandType == HandType.THREE_OF_A_KIND);
            int twopaircount = allpokerhands_1.Count(a => a.HandType == HandType.TWO_PAIR);            
            int onepaircount = allpokerhands_1.Count(a => a.HandType == HandType.ONE_PAIR);

            Console.WriteLine("Royal Flush count = " + royalflushcount.ToString());
            Console.WriteLine("Straight Flush count = " + straightflushcount.ToString());
            Console.WriteLine("Four of a kind count = " + fourofakindcount.ToString());
            Console.WriteLine("Full House count = " + fullhousecount.ToString());
            Console.WriteLine("Flush count = " + flushcount.ToString());
            Console.WriteLine("Straight count = " + straightcount.ToString());
            Console.WriteLine("Three of a kind count = " + threeofakindcount.ToString());
            Console.WriteLine("Two pair count = " + twopaircount.ToString());
            Console.WriteLine("One pair count = " + onepaircount.ToString());
            string s = "";
        }

    }
}
