using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using Poker.Shared;
using Poker.Common;

namespace Poker.Server
{
    
    public class PokerUser
    {
        private object lock_for_ProcessIncomingMessage = new object();
        ProducerConsumer _producerconsumer;
        Action<Message> _incomingmessage_callback;
        public PokerUser()
        {

        }
        public PokerUser(TcpClient client, Action<Message> incomingmessage_callback ,  string username)
        {
            TcpClient = client;
            _incomingmessage_callback = incomingmessage_callback;
            UserName = username;
            validate();
            init();
        }
        private bool validate() // this function validates the state of the PokerUser class.
        {
            return false;
        }
        private void init()
        {
            _producerconsumer = new ProducerConsumer(TcpClient, this);
            RegisterForIncomingMessages(new RecieveMessageDelegate(ProcessIncomingMessage));
            RegisterForIncomingMessages(new RecieveMessageDelegate(_incomingmessage_callback));
			SendMessage(new Message("ServerReady",MessageType.ServerReady));
           
        }
        internal TcpClient TcpClient
        {
            get;set;
        }
        public List<Player> PlayerInstances
        {
            get;set;
        }
        public Queue<Message> Incoming
        {
            get;set;
        }
        public string UserName
        {
            get;
            set;
        }
        private void ProcessIncomingMessage(Message m)
        {
            //lock (lock_for_ProcessIncomingMessage)
            Task.Run(() =>
            {
                if (m != null)
                {
                    Console.WriteLine("Inside ProcessinomingMessage " + m.Content);
                    if (m.MessageType == MessageType.PlayerSigningIn)
                    {
                        string[] arr = m.Content.Split(':');
                        UserName = arr[0];
                        MessageFactory.SendCasinoMessage(this);
                        // Also send the Player Bank Balance
                        MessageFactory.SendPlayerBankBalanceMessage(this);
                    }
                    if (m.MessageType == MessageType.PlayerJoiningGame)
                    {
                        string[] arr = m.Content.Split(':');
                        string tableNo = arr[0];
                        short seatNo = Convert.ToInt16(arr[1]);
                        decimal chipCount = Convert.ToDecimal(arr[2]);
                        Table t = TableManager.Instance.GetTable(tableNo);
                        if (chipCount >= 0)
                        {
                            t.AddPlayer(new Player(this, t, chipCount), seatNo);
                            PlayerBankingService.Instance().UpdateBankBalanceInUse(this.UserName,chipCount);
                            MessageFactory.SendPlayerBankBalanceMessage(this);
                        }
                        else
                            t.RemovePlayerEx(seatNo);
                    }
                    if (m.MessageType == MessageType.PlayerAction)
                    {
                        string[] arr = m.Content.Split(':');
                        string tableNo = arr[0];
                        decimal betsize = Convert.ToDecimal(arr[1]);

                        Table t = TableManager.Instance.GetTable(tableNo);
                        // set the wait to the receieve action for the player
                        lock(t.SynchronizeGame)
                        {
                            Player p = t.GetPlayer(this);
                            if (betsize < 0)
                            {
                                // player wants to fold the hand.
                                
                                p.FoldHand();
                            }
                            else
                            {
                                // update player bank account
                                PlayerBankingService.Instance().UpdateBankBalanceInUse(this.UserName, betsize);
                                //update pot size
                                t.AddToPot(betsize,p);
                                //update calling bet size
                                t.SetCurrentMinBet(betsize);

                            }
                            Monitor.PulseAll(t.SynchronizeGame);
                        }
                        Console.WriteLine("Received Bet from player " + this.UserName + " for size = " + betsize);
                    }
                }
            }
           );
        }
        public void SendMessage(Message m)
        {
            m.UserName = this.UserName;
            _producerconsumer.ProduceOutgoing(m);
        }
        public void RegisterForIncomingMessages(RecieveMessageDelegate handler)
        {
            _producerconsumer.ReceieveMessageHandler += handler;
        }
        public decimal TotalChips
        {
            get;set;
        }
        public decimal ChipsAvailable
        {
            get;set;
        }
    }

    
}
