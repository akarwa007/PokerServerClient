using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Client.Support
{
    public class ViewModel_BetCollection : BaseViewModel
    {
        decimal _betChoosen = 0;

        public ViewModel_BetCollection()
        {

        }
        public decimal PostedBet
        {
            get; set;
        }
        public decimal CurrentBet
        {
            get; set;
        }
        public decimal MinBetAllowed
        {
            get; set;
        }
        public decimal PotValue
        {
            get; set;
        }
        public decimal AvailableMoney
        {
            get; set;
        }
        public void setBetChoosen(decimal bet)
        {
            _betChoosen = bet;
        }
        public decimal BetChoosen
        {
            get { return _betChoosen; }
        }
    }
}
