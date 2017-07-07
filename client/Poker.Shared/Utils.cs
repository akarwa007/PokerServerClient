using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Shared.Utils
{
    public class PConvert
    {
        private PConvert()
        {

        }
        private static List<A_Card> Extract(Message message)
        {
            string[] arr = message.Content.Split(':');
            List<A_Card> list = new List<A_Card>();
            for (int i = 1; i < arr.Length;)
            {
                Rank r = (Rank)Enum.Parse(typeof(Rank), arr[i++]);
                Suit s = (Suit)Enum.Parse(typeof(Suit), arr[i++]);
                A_Card card = new A_Card(r, s);
                list.Add(card);
            }
            return list;
        }
        public static A_Card ToSingleCard(Message message)
        {
            List<A_Card> list = Extract(message);
            if ((list == null) || (list.Count != 1))
                throw new Exception("ToSingleCard error in conversion");

            A_Card result = list[0];
           

            return result;
        }
        public static Tuple<A_Card,A_Card> ToHoleCards(Message message)
        {
            List<A_Card> list = Extract(message);
            if ((list == null) || (list.Count != 2))
                throw new Exception("ToHoleCards error in conversion");
            A_Card card1 = list[0];
            A_Card card2 = list[1];
            
            Tuple<A_Card, A_Card> result = new Tuple<A_Card, A_Card>(card1,card2);
            return result;
        }
        public static Tuple<A_Card, A_Card,A_Card> ToFlop(Message message)
        {
            List<A_Card> list = Extract(message);
            if ((list == null) || (list.Count != 3))
                throw new Exception("ToFlop error in conversion");
            A_Card card1 = list[0];
            A_Card card2 = list[1];
            A_Card card3 = list[2];

            Tuple<A_Card, A_Card, A_Card> result = new Tuple<A_Card, A_Card, A_Card>(card1, card2,card3);
            return result;
        }
    }
 
}
