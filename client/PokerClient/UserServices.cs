using Poker.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerClient
{
    public class UserServices : IUserServices
    {
        private static UserServices _instance = new UserServices();
        Dictionary<string, PlayerProfile> _dict = new Dictionary<string, PlayerProfile>();
        private UserServices()
        {

        }
        public static UserServices Instance()
        {
            if (_instance != null)
                return _instance;
            else
            {
               _instance = new UserServices();
                return  _instance;
            }
        }
        public void update(string username, decimal totalmoney , decimal availablemoney)
        {
            if (!_dict.ContainsKey(username))
                _dict[username] = new PlayerProfile();
            _dict[username].TotalMoneyAvailable = totalmoney;
            _dict[username].MoneyInPlay = availablemoney;
        }
        public IPlayerProfile GetPlayerProfile(string username)
        {
            if (!_dict.ContainsKey(username))
                _dict[username] = new PlayerProfile();
            return _dict[username];
        }
        public void ProcessMessage(Poker.Shared.Message message)
        {

            if (message.MessageType == MessageType.PlayerBankBalance)
            {
                string temp = message.Content;
                decimal total_money = Convert.ToDecimal(temp.Split(';')[0]);
                decimal avail_money = Convert.ToDecimal(temp.Split(';')[1]);

                this.update(message.UserName, total_money, avail_money);
            }
        }
    }
}
