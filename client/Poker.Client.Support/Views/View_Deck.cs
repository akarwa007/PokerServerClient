using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Shared;

namespace Poker.Client.Support.Views
{
    public class View_Deck
    {
        static View_Deck _instance = new View_Deck();
        Dictionary<string, Bitmap> _dict = new Dictionary<string, Bitmap>();
        Bitmap _backcard;
        string[] rank = { "2", "3", "4", "5", "6", "7", "8", "9", "T", "K", "Q", "J", "A" };
        string[] suit = { "S", "H", "C", "D" };
        Dictionary<Rank, string> dictRank;
        Dictionary<Suit, string> dictSuit;
        private View_Deck()
        {
            init();
        }
        private void init()
        {
            string path = "resources/Cards.png"; // @"C:\Programs\theBorgata\BorgataPoker\Images\NewGameTable\Modern\cards.png";
            Bitmap b = new Bitmap(path, true);
          
            int x = 0;
            int y = 0;
            int count = 0;
            int width = 56;
            int margin = 3;
            int height = 80;
            _dict = new Dictionary<string, Bitmap>();
            string[] rank = { "2", "3", "4", "5", "6", "7", "8", "9", "T", "K", "Q", "J", "A" };
            string[] suit = { "S", "H", "C", "D" };
            string[] cards = new string[52];
            int i = 0;
            foreach (string s in suit)
            {
                foreach (string r in rank)
                {
                    cards[i++] = s + r;
                }
            }
            while (count < 52)
            {
                x = (width + margin) * count;
                Bitmap c = b.Clone(new Rectangle(x, 0, width, height), System.Drawing.Imaging.PixelFormat.DontCare);
                _dict[cards[count]] = c;
                count++;
            }

            dictRank = new Dictionary<Rank, string>()
            {
                {Rank.Ace,"A" },
                {Rank.Eight,"8" },
                {Rank.Five,"5" },
                {Rank.Four,"4" },
                {Rank.Jack,"J" },
                {Rank.King,"K" },
                {Rank.Nine,"9" },
                {Rank.Queen,"Q" },
                {Rank.Seven,"7" },
                {Rank.Six,"6" },
                {Rank.Ten,"T" },
                {Rank.Three,"3" },
                {Rank.Two,"2" }
            };
            dictSuit = new Dictionary<Suit, string>()
            {
                {Suit.Club,"C" },
                {Suit.Diamond,"D" },
                {Suit.Heart,"H" },
                {Suit.Spade,"S" }
            };

            // load and store back card

            path = "resources/back_card.png"; // @"C:\Programs\theBorgata\BorgataPoker\Images\NewGameTable\Modern\cards.png";
            
            _backcard= new Bitmap(path, true);

        }
        public static View_Deck Instance
        {
            get { return _instance; }
        }
        public Bitmap GetCard(A_Card card)
        {
            if ((card.Rank == Rank.Blank) || (card.Suit == Suit.Blank))
                return GetBackCard();
            string r = dictRank[card.Rank];
            string s = dictSuit[card.Suit];
            Bitmap result = _dict[s+r];
            return result;
        }
        public Bitmap GetBackCard()
        {
            return _backcard;
        }
    }
}
