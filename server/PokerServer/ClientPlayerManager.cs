using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Shared;

namespace Poker.Server
{
    public class ClientPlayerManager
    {
        public ClientPlayerManager()
        {
        }
        public  void RequestAction(Player p)
        { 
            // this will wait with the client player and seek an action 


        }
        public  void SendFlop(Table t, Tuple<Card,Card,Card> flop)
        {
            
        }
        public  void SendTurn(Table t, Card turn)
        {
        }
        public  void SendRiver(Table t, Card river)
        {
        }
    }
}
