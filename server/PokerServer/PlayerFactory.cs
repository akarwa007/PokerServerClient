using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Server
{
    public sealed class PlayerFactory
    {
        private static object _locker = new object();
        private static PlayerFactory _instance;
        private List<Player> _playerList;

        private PlayerFactory()
        {
            _playerList = new List<Player>();
        }
        public static PlayerFactory Instance
        {
            get
            {
                lock (_locker)
                {
                    if (_instance == null)
                        _instance = new PlayerFactory();
                    return _instance;
                }
            }
        }
        /*
        public bool CreatePlayer(string username, string encyrpted_pwd)
        {
            if (Authenticate(username, encyrpted_pwd))
            {
                _playerList.Add(new Player(username));
                return true;
            }
            return false;
        }
        */
        private bool Authenticate(string username, string encrypted_pwd)
        {
            return true;
        }
    }
}
