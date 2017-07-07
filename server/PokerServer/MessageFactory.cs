using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Shared;

namespace Poker.Server
{
    public class MessageFactory
    {
        public MessageFactory()
        {

        }
        public static void SendCasinoMessage()
        {
            Poker.Shared.Message m = new Shared.Message("CasinoUpdate", MessageType.CasinoUpdate);
            m.Content = ClientView.CasinoView.Serialize();
            foreach (PokerUser puser in PokerUserFactory.GetListPokerUsers())
            {
                puser.SendMessage(m);
            }
        }
        public static void SendCasinoMessage(PokerUser user)
        {
            Poker.Shared.Message m = new Shared.Message("CasinoUpdate", MessageType.CasinoUpdate);
            m.Content = ClientView.CasinoView.Serialize();
            if ((user != null) && (user.TcpClient != null) && (user.TcpClient.Connected))
            {
                user.SendMessage(m);
            }
        }
		public static void SendServerReadyMessage(PokerUser user)
		{
			Poker.Shared.Message m = new Shared.Message("ServerReady", MessageType.ServerReady);
			m.Content = "ServerReady";
			if ((user != null) && (user.TcpClient != null) && (user.TcpClient.Connected))
			{
				user.SendMessage(m);
			}
		}
		public static void SendPlayerBankBalanceMessage(PokerUser user)
        {
            Poker.Shared.Message m = new Shared.Message("PlayerBankBalance", MessageType.PlayerBankBalance);
            m.Content = PlayerBankingService.Instance().GetBankBalance(user.UserName).ToString();
            if ((user != null) && (user.TcpClient != null) && (user.TcpClient.Connected))
            {
                user.SendMessage(m);
            }
        }
        public static void RequestAction(Table t, Player p, string comment)
        {
            // this will wait with the client player and seek an action 
            Message m = new Message("RequestBet", MessageType.PlayerActionRequestBet);
            m.Content = t.TableNo + ":" + comment; // Add more elements like min and max bet size etc later
            lock (t) // this will synchronize this call with any previous pending call to SendToTablePlayers
            {
                SendMessageToPlayer(p, m);
            }

        }
        public static void SendMessageToPlayer(Player p, Message m)
        {
            if ((p != null) && (p.UserName != null) && (p.UserName != "Empty"))
                {
                    p.PokerUser.SendMessage(m);
                }
        }

        public static void SendFlop(Table t, Tuple<Card, Card, Card> flop)
        {
            Poker.Shared.Message message = new Shared.Message("", MessageType.TableSendFlop);
            message.Content = t.TableNo + ":";
            message.Content += flop.Item1.Rank + ":" + flop.Item1.Suit + ":";
            message.Content += flop.Item2.Rank + ":" + flop.Item2.Suit + ":";
            message.Content += flop.Item3.Rank + ":" + flop.Item3.Suit;
            SendToTablePlayers(t, message);
        }
        public static void SendTurn(Table t, Card turn)
        {
            Poker.Shared.Message message = new Shared.Message("", MessageType.TableSendTurn);
            message.Content = t.TableNo + ":";
            message.Content += turn.Rank + ":" + turn.Suit;
            SendToTablePlayers(t, message);
        }
        public static void SendRiver(Table t, Card river)
        {
            Poker.Shared.Message message = new Shared.Message("", MessageType.TableSendRiver);
            message.Content = t.TableNo + ":";
            message.Content += river.Rank + ":" + river.Suit;
            SendToTablePlayers(t, message);
        }
       
        public static void  SendTableUpdateMessage(Table t)
        {
            Message m = new Message("TableUpdate", MessageType.TableUpdate);
            m.Content = (new ClientView.TableView(t)).Serialize();
            SendToTablePlayers(t, m);
        }
        public static void SendGameUpdateMessage(Table t)
        {
            Message m = new Message("GameUpdate", MessageType.GameUpdate);
            m.Content = t.GameState + ":" + t.DealerPosition.ToString();
            SendToTablePlayers(t, m);
        }
        public static void SendToTablePlayers(Table t, Message m)
        {
            if ((m == null) || (t == null))
                return;

            lock (t) // Watch for performance issuses around this call
            {
                if ((t.Seats == null) || (t.Seats.Values == null))
                    return;

                foreach (Player p in t.Seats.Values)
                {
                    if ((p != null) && (p.UserName != null) && (p.UserName != "Empty"))
                    {
                        p.PokerUser.SendMessage(m);
                    }
                }
                if (t.RemovedPlayer != null)
                {
                    Player p = t.RemovedPlayer;
                    if ((p != null) && (p.UserName != null) && (p.UserName != "Empty"))
                    {
                        p.PokerUser.SendMessage(m);
                    }
                    t.RemovedPlayer = null;
                }
            }
        }
    }
  
}
