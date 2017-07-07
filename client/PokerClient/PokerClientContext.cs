using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Poker.Client.Support;
using Poker.Client.Support.Views;
using Poker.Shared;
namespace PokerClient
{
    public class PokerClientContext
    {
        
        public PokerClientContext()
        {

        }
        public PokerUserC PokerUser
        {
            get;set;
        }
        public MessageFactory MessageFactory
        {
            get; set;
        }
        public ViewModel_Casino CasinoModel
        {
            get;set;
        }

    }
}
