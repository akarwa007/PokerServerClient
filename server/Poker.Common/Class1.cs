using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Poker.Shared;

namespace Poker.Common
{
    public delegate bool createpokeruser_callback(TcpClient client, Action<Message> incomingmessage_callback ,   string username, string encrypted_pwd);
    public delegate void RecieveMessageDelegate(Message m);

    [JsonConverter(typeof(StringEnumConverter))]
    public enum GameName
    {
        Texas_Holdem,
        Omaha_Hi_Low,
        Seven_Card_Stud
    }
     [JsonConverter(typeof(StringEnumConverter))]
    public enum GameSubName
    {
        Limit_Holdem,
        No_Limit_Holdem
    }

}
