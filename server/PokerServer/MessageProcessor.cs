using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Poker.Shared;

namespace Poker.Server
{
    public class MessageProcessor
    {
        public MessageProcessor()
        {
        }

        public Message Process(StreamReader reader )
        {
            Poker.Shared.Message m = null;
            String line = reader.ReadLine();
            if (line != null)
            {
                m = Poker.Shared.Message.DeSerialize(line);
            }

            return m;

        }
    }

}
