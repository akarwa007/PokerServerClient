using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Poker.Shared;


namespace PokerClient
{

    public class PokerUserC
    {
        ProducerConsumerC _producerconsumer;
        PokerClientContext _context;
        Action<Message> _incomingmessage_callback;
        private string _password;
        public PokerUserC()
        {

        }
        public PokerUserC(TcpClient client, Action<Message> incomingmessage_callback, string username, string password)
        {
            TcpClient = client;
            _incomingmessage_callback = incomingmessage_callback;
            _password = password;
            UserName = username;
            validate();
            
        }
        public void setContext(PokerClientContext context)
        {
            _context = context;
            init();
        }
        private bool validate() // this function validates the state of the PokerUser class.
        {
            return false;
        }
        private void init()
        {

            _producerconsumer = new ProducerConsumerC(_context);
            // send the username to the server 
            string content = UserName + ":" + this._password;
            Message firstMessage = new Poker.Shared.Message(content, MessageType.PlayerSigningIn);

            this.SendMessage(firstMessage);

        }
        internal TcpClient TcpClient
        {
            get; set;
        }
        public List<PlayerC> PlayerInstances
        {
            get; set;
        }
        public Queue<Message> Incoming
        {
            get; set;
        }
        public string UserName
        {
            get;
            set;
        }
        public bool ServerReady
		{
			get; set;
		}
        public void SendMessage(Message m)
        {
            _producerconsumer.ProduceOutgoing(m);
        }

        public decimal TotalChips
        {
            get; set;
        }
        public decimal ChipsAvailable
        {
            get; set;
        }
    }


}

