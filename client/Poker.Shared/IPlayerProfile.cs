using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Shared
{
    public interface IPlayerProfile
    {
         decimal TotalMoneyAvailable{get; set;}
         decimal MoneyInPlay{get; set;}
    }
    public interface IUserServices
    {
        void update(string username, decimal totalmoney, decimal availablemoney);

        IPlayerProfile GetPlayerProfile(string username);

        void ProcessMessage(Poker.Shared.Message message);
        
    }
}
