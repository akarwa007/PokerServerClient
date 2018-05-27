using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
    
namespace Poker.Shared
{   
    public class Message : IAsyncResult
    {
        public Guid MessageID = Guid.NewGuid();
        MessageType _messageType;
        MessageDirection _messageDirection;
        String _content;
        AsyncCallback _callback;
        EventWaitHandle _waithandle = new EventWaitHandle(true, EventResetMode.AutoReset);
      

        public Message(String content, MessageType mtype)
        {
            _content = content;
            _messageType = mtype;
        }
        [JsonProperty("Content", Required = Required.Always)]
        public String Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }
        //[JsonProperty("UserName", Required = Required.Always)]
        public String UserName
        {
            get;set;
        }
        [JsonProperty("MessageDirection", Required = Required.Always)]
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
        [JsonProperty("MessageType", Required = Required.Always)]
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
        [JsonIgnore]
        public AsyncCallback Callback   
        {
            get
            {
                return _callback;
            }
            set
            {
                _callback = value;
            }

        }
        object IAsyncResult.AsyncState
        {
            get { return this; }
        }

        System.Threading.WaitHandle IAsyncResult.AsyncWaitHandle
        {
            get { return _waithandle; }
        }

        bool IAsyncResult.CompletedSynchronously
        {
            get { throw new NotImplementedException(); }
        }

        bool IAsyncResult.IsCompleted
        {
            get { throw new NotImplementedException(); }
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
   
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageType
    {
        PlayerJoiningGame,
        PlayerLeavingGame,
        PlayerJoiningTable,
        PlayerLeavingTable,
        PlayerAddingChips,
        PlayerSigningIn,
        PlayerSigningOut,
        PlayerBankBalance,
        PlayerAction,
        GameUpdate,
        DealerButtonPosition,
        TableSendHoleCards,
        TableSendFlop,
        TableSendTurn,
        TableSendRiver,
        TableSendWinner,
        PlayerActionRequestBet,
        PlayerActionAssignedHoleCards,
        PlayerReaction,
        TableUpdate,
        CasinoUpdate,
        GeneralPurpose,
		ServerReady,
        AnnounceWinner
    }
  
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageDirection
    {
        Incoming,
        Outgoing
    }

    public delegate void JoinedTableHandler(string TableNo, short SeatNo, decimal ChipCounts);
    public delegate void ReceiveBetHandler(string TableNo, decimal betsize , string gameStage); // betsize = -1 is fold

}
