using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Shared;

namespace Poker.Server.ClientView
{
    public class CardView
    {
        Card _card;
        public CardView(Card card)
        {
            _card = card;
        }
        public Rank Rank
        {
            get
            {
                if (_card == null)
                    return Rank.Blank;
                else
                    return _card.Rank;
            }
        }
        public Suit Suit
        {
            get
            {
                if (_card == null)
                    return Suit.Blank;
                else
                    return _card.Suit;
            }
        }
    }
}
