using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Server
{
    public class PlayerBankingService
    {
        private static PlayerBankingService _instance = new PlayerBankingService();
        private Dictionary<string, decimal> _bank = new Dictionary<string, decimal>();
        private PlayerBankingService()
        {
            init();

        }
        private void init()
        {
            _bank["Alok1"] = 100000;
            _bank["Alok2"] = 100000;
            _bank["Alok3"] = 100000;
            _bank["Alok4"] = 100000;
            _bank["Alok5"] = 100000;
        }
        public static PlayerBankingService Instance()
        {
            return _instance;
        }

        public  decimal GetBankBalance(string username)
        {
            if (_bank.ContainsKey(username))
                return _bank[username];
            else
                return 0;
        }
        public void UpdateBankBalance(string username , decimal amount)
        {
            if (_bank.ContainsKey(username))
                _bank[username] = amount;
        }
        public void UpdateBankBalanceByAmount(string username , decimal amount)
        {
            if (_bank.ContainsKey(username))
                _bank[username] += amount;
        }
    }
}
