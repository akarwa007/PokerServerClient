using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Server
{
    public static class ClientConnections
    {
        private static object _locker = new object();
        private static Dictionary<PokerUser, PokerUserConnection> _connectionList = new Dictionary<PokerUser, PokerUserConnection>();

        public static void AddPlayerConnection(PokerUser p , PokerUserConnection pc)
        {
            lock (_locker)
            {
                _connectionList.Add(p, pc);
            }
        }
        public static void RemovePlayerConnection(PokerUser p, PokerUserConnection pc)
        {
            lock (_locker)
            {
                _connectionList.Remove(p);
            }
        }
        public static PokerUserConnection GetPlayerConnection(PokerUser p)
        {
            lock (_locker)
            {
                return _connectionList[p];
            }
        }
    }
}
