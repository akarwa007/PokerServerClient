using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Shared;

namespace PokerClient
{
    public class MessageFactory
    {
        PokerUserC _user;
        Dictionary<MessageType, Action<Message>> _dict = new Dictionary<MessageType, Action<Message>>();
        private object syncObj = new object();
        public MessageFactory(PokerUserC user)
        {
            _user = user;
        }
        public  void SendTableJoinMessage(string TableNo,short SeatNo,decimal ChipCount)
        {
            string content = TableNo + ":" + SeatNo + ":" + ChipCount;
            Poker.Shared.Message m = new Poker.Shared.Message(content, MessageType.PlayerJoiningGame);
            if (_user != null)
            {
                _user.SendMessage(m);
            }
           // Console.WriteLine("MessageFactory:Sent TableJoin Message for user " + this._user.UserName);
        }
        public void SendReceiveBetMessage(string TableNo, decimal ChipCount, string gameStage)
        {
            string content = TableNo + ":" + ChipCount + ":" + gameStage;
            Poker.Shared.Message m = new Poker.Shared.Message(content, MessageType.PlayerAction);
            if (_user != null)
            {
                _user.SendMessage(m);
            }
            Console.WriteLine("MessageFactory:Sent ReceiveBet Message for user " + this._user.UserName);
        }
        public void RegisterCallback(Action<Message> callback , MessageType messageType)
        {
            try
            {
                if (!_dict.ContainsKey(messageType))
                    _dict[messageType] = callback;
                else
                    _dict[messageType] += callback;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }      
        public void ProcessMessage(Poker.Shared.Message message)
        {

            Console.WriteLine("Incoming message for " + message.UserName + " " + message.MessageType + " size=" + message.Content.Length.ToString());
            lock (this.syncObj)
            {
                if ((message != null) && (_dict.ContainsKey(message.MessageType)))
                    _dict[message.MessageType](message);
                if ((message != null) && (_dict.ContainsKey(MessageType.GeneralPurpose)))
                    _dict[MessageType.GeneralPurpose](message);
                if ((message != null) && (message.MessageType == MessageType.ServerReady))
                    _user.ServerReady = true;
            }
        }

    }

}
