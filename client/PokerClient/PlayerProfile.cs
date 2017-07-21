using Poker.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerClient
{
    public class PlayerProfile : IPlayerProfile
    {
        public PlayerProfile()
        {

        }
        public decimal TotalMoneyAvailable
        {
            get;set;
        }
        public decimal MoneyInPlay
        {
            get; set;
        }
    }
}
