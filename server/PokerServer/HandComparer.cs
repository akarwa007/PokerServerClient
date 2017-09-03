using Poker.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Server
{
    public class HandComparer : IComparer<HandRankings>
    {
        public HandComparer()
        {

        }
        public int Compare(HandRankings x, HandRankings y)
        {
            if (x.HandType > y.HandType)
                return 1;
            if (x.HandType < y.HandType)
                return -1;
            if (x.HandType == y.HandType)
            {
                // need further comparison
                // get ranks in descending order
                Rank[] _cards_x = x.SignificantRankssOrdered;
                Rank[] _cards_y = y.SignificantRankssOrdered;

                
                for (int i =0; i < _cards_x.Length; i++)
                {
                    if (_cards_x[i] > _cards_y[i])
                        return 1;
                    if (_cards_x[i] < _cards_y[i])
                        return -1;
                }
                return 0; // they are same
            }

            return 0;
        }
    }
}
