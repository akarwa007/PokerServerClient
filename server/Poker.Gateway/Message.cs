using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Poker.Gateway
{
    public class Message
    {
        MessageType _messageType;
        MessageDirection _messageDirection;
        String _content;

        public Message(String content, MessageType mtype)
        {
            _content = content;
            _messageType = mtype;
        }
        public String Content
        {
            get
            {
                return _content;
            }
            private set
            {
                _content = value;
            }
        }
        public MessageDirection MessageDirection
        {
            get
            {
                return _messageDirection;
            }
            private set
            {
                _messageDirection = value;
            }
        }
        public MessageType MessageType
        {
            get
            {
                return _messageType;
            }
            private set
            {
                _messageType = value;
            }
        }
        public String Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static Message DeSerialize(String jsonString)
        {
            Message m = JsonConvert.DeserializeObject<Message>(jsonString);
            return m;
        }
       
    }
    public enum MessageType
    {
        PlayerJoiningGame,
        PlayerLeavingGame,
        PlayerSigningIn,
        PlayerSigningOut,
        PlayerAction
    }
    public enum MessageDirection
    {
        Incoming,
        Outgoing
    }


}
