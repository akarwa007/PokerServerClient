using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Poker.Shared
{
    public  class A_Card
    {
        public A_Card(Rank r, Suit s)
        {
            Rank = r;
            Suit = s;
        }
        public A_Card()
        {
            Rank = Rank.Blank;
            Suit = Suit.Blank;
        }
        public Suit Suit
        {
            get;
            protected set;
        }
        public Rank Rank
        {
            get;
            protected set;
        }
        public bool IsCardBlank()
        {
            if ((Suit == Suit.Blank) || (Rank == Rank.Blank))
                return true;
            return false;
        }
        public string Serialize()
        {
            string jsonString = JsonConvert.SerializeObject(this);
            return jsonString;
        }
    }
    public enum Suit
    {
        Spade,
        Heart,
        Club,
        Diamond,
        Blank
    }
    public enum Rank
    {
        Two  = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace,
        Blank
    }
}
