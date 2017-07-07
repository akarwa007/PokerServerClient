using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Poker.Shared;

namespace PokerClient
{

    public class MessageProcessor
    {
        public MessageProcessor()
        {
        }

        public static Message Process(StreamReader reader )
        {
            Poker.Shared.Message m = null;
            try
            {
                String line = reader.ReadLine();
                m = Poker.Shared.Message.DeSerialize(line);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return m;

        }
        public static void SendMessagePlayerSigned()
        {

        }
        public static void SendMessageJoinedTable(string tableno, short seatno)
        {

        }
        public static void SendMessageLeftTable(string tableno, short seatno)
        {

        }

    }

}
