using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Poker.Shared;

namespace Poker.Server
{
    public class Deck 
    {
        private Card[] _cards = new Card[52];
        private short _currentPosition = 0;

        private Deck()
        {
            initialize();
        }
        private void initialize()
        {
            short index = 0;
            foreach (Suit s in Enum.GetValues(typeof(Suit)))              
            {
                if (s == Suit.Blank)
                    continue;
                foreach (Rank r in Enum.GetValues(typeof(Rank)))
                {
                    if (r == Rank.Blank)
                        continue;
                    _cards[index++] = new Card(s, r);
                }
            }
        }
        internal void PrintDeck()
        {
            short index = 0;
            foreach (Card c in this._cards)
            {
                Console.WriteLine("card at index " + index + "  " + c.Suit.ToString() + "  " + c.Rank.ToString());
                index++;
            }
        }
        private void Shuffle()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            
            Random r = new Random(DateTime.Now.Millisecond*1236733498);
            int d = ((int)r.NextDouble()) * 1000000;
            int count = 1000000; // number of swaps
            int index1 = 0;
            int index2 = 0;
            Card temp;
            while (count-- > 0)
            {
                index1 = ((int)(r.NextDouble() * 1000000))%52;

                index2 = ((int)(r.NextDouble() * 1000000)) % 52;
               // Console.WriteLine("index1 " + index1 + "index2 " + index2);
                temp = this._cards[index1];
                this._cards[index1] = this._cards[index2];
                this._cards[index2] = temp;
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds*1000);
        }
        public static  Deck GetShuffledDeck()
        {
            Deck deck = new Deck();
            deck.Shuffle();
            return deck;
        }
        public static void TestShuffle()
        {
            Deck d1 = Deck.GetShuffledDeck();
            Deck d2 = Deck.GetShuffledDeck();
            Deck d3 = Deck.GetShuffledDeck();
            Deck d4 = Deck.GetShuffledDeck();



        }




        private Card Current
        {
            get {return  this._cards[this._currentPosition]; }
           // get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public Card[] cards
        {
            get { return _cards; }
            set { _cards = value; }
        }
        public string serialize()
        {
            var json = new JavaScriptSerializer();
            var json1 = Newtonsoft.Json.JsonConvert.SerializeObject(this);

            return json1;
        }
        public Card GetNext()
        {
            Card result =  Current;
            MoveNext();
            return result;

        }
        private bool MoveNext()
        {
            if (this._currentPosition < (this._cards.Length - 1))
            {
                this._currentPosition++;
                return true;
            }
            return false;
         //   throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

     
    }
}
