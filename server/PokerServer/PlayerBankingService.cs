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
        private Dictionary<string, decimal> _bankTotal = new Dictionary<string, decimal>();
        private Dictionary<string, decimal> _bankInUse = new Dictionary<string, decimal>();
        private PlayerBankingService()
        {
            init();

        }
        private void init()
        {
            _bankTotal["Alok1"] = 1000001;
            _bankTotal["Alok2"] = 1000002;
            _bankTotal["Alok3"] = 1000003;
            _bankTotal["Alok4"] = 1000004;
            _bankTotal["Alok5"] = 1000005;
            _bankTotal["Alok6"] = 1000006;
            _bankTotal["Alok7"] = 1000007;
            _bankTotal["Alok8"] = 1000008;
            _bankTotal["Alok9"] = 1000009;
            _bankTotal["Alok10"] = 10000011;

            _bankInUse["Alok1"] = 101;
            _bankInUse["Alok2"] = 102;
            _bankInUse["Alok3"] = 103;
            _bankInUse["Alok4"] = 104;
            _bankInUse["Alok5"] = 105;
            _bankInUse["Alok6"] = 106;
            _bankInUse["Alok7"] = 107;
            _bankInUse["Alok8"] = 108;
            _bankInUse["Alok9"] = 109;
            _bankInUse["Alok10"] = 110;
        }
        public static PlayerBankingService Instance()
        {
            return _instance;
        }

        public Tuple<decimal, decimal> GetBankBalance(string username)
        {
            if (_bankTotal.ContainsKey(username))
                return new Tuple<decimal, decimal>(_bankTotal[username], _bankInUse[username]);
            else
                return new Tuple<decimal, decimal>(0,0);
        }
        public void UpdateTotalBankBalance(string username , decimal amount)
        {
            if (_bankTotal.ContainsKey(username))
                _bankTotal[username] = amount;
        }
        public void UpdateBankBalanceInUse(string username, decimal amount)
        {
            if (_bankTotal.ContainsKey(username))
                _bankInUse[username] += amount;
        }
        public void UpdateTotalBankBalanceByAmount(string username , decimal amount)
        {
            if (_bankTotal.ContainsKey(username))
                _bankTotal[username] += amount;
        }
    }
}
