using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Shared;

namespace Poker.Client.Support
{
    public class ViewModel_Player : BaseViewModel
    {
        private Tuple<A_Card, A_Card> _holecards = null;
        public ViewModel_Player()
        {
        }
        public Tuple<A_Card, A_Card> HoleCards
        {
            get { return _holecards; }
            set { _holecards = value; }
        }
        
    }
}
